using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EXTichu.Client
{

	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private GameUI _ui = null;

		[SerializeField]
		private string _hostAddress = "127.0.0.1";

		private NetworkClient _network = null;

		public void Awake()
		{
		}

		public IEnumerator Start()
		{
			yield return connectToServer();
			// connect to server

			yield return joinRoom();

			//_ui.ReadyButtonEnabled = true;
		}

		private IEnumerator joinRoom()
		{
			throw new NotImplementedException();
		}

		private IEnumerator connectToServer()
		{
			yield break;
		}
	}
}