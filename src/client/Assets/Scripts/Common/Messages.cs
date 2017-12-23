using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXTichu.Common
{
	public static class MsgID
	{
		public const short CSJoinRoom = 101;
		public const short SCJoinRoom = 102;
		public const short SCNewPlayer = 103;
		public const short CSSetReady = 104;
		public const short SCSetReady = 105;
	}

	public enum ErrorCode
	{
		EC_OK = 0,
		EC_ROOM_IS_FULL = 1,

	}

	public class Message { }

	public class CSJoinRoom : Message
	{
		public string Name;
	}

	public class SCJoinRoom : Message
	{
		public ErrorCode Result;
		public Dictionary<ushort, PlayerInfo> PlayersInPosition;
	}

	public class SCNewPlayer : Message
	{
		public PlayerInfo NewPlayer;
	}

	public class CSSetReady : Message
	{
		public bool IsReady;
	}

	public class SCSetReady : Message
	{
		public int PlayerID;
		public bool IsReady;
	}

	public class SCHandout : Message
	{
		public int PlayerID;
		public int NumOfCards;
		public Card[] Cards;
	}

	public class PlayerInfo
	{
		public string Name;
		/// <summary>
		/// 0 ~ 3
		/// </summary>
		public ushort Position;
	}
}