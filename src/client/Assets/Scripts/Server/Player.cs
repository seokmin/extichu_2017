using EXTichu.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXTichu.Server
{
	public class Player
	{
		public int PlayerID;
		public string Name;
		public ushort Position;
		public bool IsReady;
		public HashSet<Card> Cards = new HashSet<Card>();
	}
}
