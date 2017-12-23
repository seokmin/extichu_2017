using EXTichu.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace EXTichu.Server
{
	public class GameServer : MonoBehaviour
	{
		private enum GameStep
		{
			kNotStarted,
			kFirstHandout,
			kSecondHandout,
		}

		private GameStep _currentStep { get; set; }

		private NetworkServerSimple _network { get; set; } = new NetworkServerSimple();

		private short _numOfPlayers { get; }

		private Dictionary<ushort, Player> _playersInPosition { get; set; } = new Dictionary<ushort, Player>()
		{
			{0, null },
			{1, null },
			{2, null },
			{3, null },
		};

		private HashSet<int> _players { get; set; } = new HashSet<int>();

		public void Awake()
		{
			installHandlers();
			
		}

		#region  network
		private void onMessage<T>(NetworkMessage msg, Action<int, T> handler) where T : Message
		{
			var unpackedMsg = JsonConvert.DeserializeObject<T>(msg.reader.ReadString());
			handler.Invoke(msg.conn.connectionId, unpackedMsg);
		}

		private void sendMessage<T>(int dest, T msg)
		{
			var packedMsg = JsonConvert.SerializeObject(msg);
#if DEBUG
			Debug.Log($"[{nameof(GameServer)}] Send msg : <color=blue>{packedMsg}</color>");
#endif
			var bytes = Encoding.UTF8.GetBytes(packedMsg);
			_network.SendBytesTo(dest, bytes, bytes.Length, 0);
		}

		private void sendAll<T>(T msg, int? except = null)
		{
			foreach (var eachClient in _players)
				if(except != null && except == eachClient)
					sendMessage(eachClient, msg);
		}

		#endregion

		private void installHandlers()
		{
			_network.RegisterHandler(MsgID.CSJoinRoom, msg => onMessage<CSJoinRoom>(msg, onCSJoinRoom));
			_network.RegisterHandler(MsgID.CSSetReady, msg => onMessage<CSSetReady>(msg, onCSSetReady));

		}

		private Player getPlayer(int id)
			=> _playersInPosition.Values.Where(player => player.PlayerID == id).FirstOrDefault();

		public IEnumerator Start()
		{
			_currentStep = GameStep.kNotStarted;
			yield return waitFor4PlayersJoined();
			yield return waitForAllPlayersReady();
			_currentStep = GameStep.kFirstHandout;

			var deck = new Queue<Card>(Card.ALL.OrderBy(_ => Guid.NewGuid()));
			foreach (var playerID in _players)
				handout(playerID, 6, ref deck);

			while (true)
				yield return null;
		}

		private IEnumerator waitFor4PlayersJoined()
		{
			while (_numOfPlayers != 4)
				yield return null;
		}

		private IEnumerator waitForAllPlayersReady()
		{
			yield break;
		}

		private void handout(int playerID, int count, ref Queue<Card> source)
		{
			var givenCards = new Card[count];
			for (int i = 0; i <= count; ++i)
			{
				var cardToGive = source.Dequeue();

				_playersInPosition.Values
					.Where(player => player.PlayerID == playerID)
					.First().Cards.Add(cardToGive);
				givenCards[i] = (cardToGive);
			}

			sendMessage(playerID, new SCHandout
			{
				PlayerID = playerID,
				NumOfCards = count,
				Cards = givenCards
			});
			sendAll(new SCHandout { PlayerID = playerID, NumOfCards = count }, except: playerID);
		}

		private void onCSJoinRoom(int sessionID, CSJoinRoom msg)
		{
			if (_numOfPlayers == 4)
			{
				sendMessage(sessionID, new SCJoinRoom { Result = ErrorCode.EC_ROOM_IS_FULL });
				return;
			}

			_players.Add(sessionID);

			var emptyPositions = from kvp in _playersInPosition
								 where kvp.Value == null
								 select kvp.Key;
			var newPosition = emptyPositions.First();

			var newPlayer = new Player
			{
				Name = msg.Name,
				Position = newPosition,
				PlayerID = sessionID,
			};

			var playerInfos = _playersInPosition
				.Where(kvp => kvp.Value != null)
				.Select(kvp => new PlayerInfo { Name = kvp.Value.Name, Position = kvp.Value.Position })
				.ToDictionary(playerInfo => playerInfo.Position);

			sendMessage(sessionID, new SCJoinRoom { PlayersInPosition = playerInfos });
			sendAll(new SCNewPlayer
			{
				NewPlayer = new PlayerInfo
				{
					Name = newPlayer.Name,
					Position = newPlayer.Position
				}
			}, except: sessionID);
			
		}

		private void onCSSetReady(int sessionID, CSSetReady msg)
		{
			if (_numOfPlayers < 4)
				return;
			if (_currentStep != GameStep.kNotStarted)
				return;

			var player = getPlayer(sessionID);
			player.IsReady = msg.IsReady;

			sendAll(new SCSetReady { PlayerID = player.PlayerID, IsReady = player.IsReady });
		}
	}
}