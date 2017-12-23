using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXTichu.Common
{

	public class Card
	{
		public enum ShapeType
		{
			kSpecial = 0,
			kShape1 = 1,
			kShape2 = 2,
			kShape3 = 3,
			kShape4 = 4,
		}

		public enum ValueType
		{
			kMahjong = 0,
			kDog = 1,
			k2 = 2,
			k3 = 3,
			k4 = 4,
			k5 = 5,
			k6 = 6,
			k7 = 7,
			k8 = 8,
			k9 = 9,
			k10 = 10,
			kJack = 11,
			kQueen = 12,
			kKing = 13,
			kAce = 14,
			kPhoenix = 15,
			kDragon = 16,
		}

		public int? Player;
		public ShapeType? Shape;
		public ValueType Value;

		public static readonly HashSet<Card> ALL =
			new HashSet<Card>
			{
				new Card{Shape = ShapeType.kSpecial, Value = ValueType.kMahjong } ,
				new Card{Shape = ShapeType.kSpecial, Value = ValueType.kDog     },
				new Card{Shape = ShapeType.kSpecial, Value = ValueType.kPhoenix },
				new Card{Shape = ShapeType.kSpecial, Value = ValueType.kDragon  },

				new Card{Shape = ShapeType.kShape1, Value = ValueType.k2        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k3        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k4        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k5        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k6        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k7        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k8        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k9        },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.k10       },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.kJack     },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.kQueen    },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.kKing     },
				new Card{Shape = ShapeType.kShape1, Value = ValueType.kAce      },

				new Card{Shape = ShapeType.kShape2, Value = ValueType.k2        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k3        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k4        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k5        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k6        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k7        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k8        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k9        },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.k10       },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.kJack     },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.kQueen    },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.kKing     },
				new Card{Shape = ShapeType.kShape2, Value = ValueType.kAce      },

				new Card{Shape = ShapeType.kShape3, Value = ValueType.k2        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k3        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k4        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k5        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k6        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k7        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k8        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k9        },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.k10       },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.kJack     },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.kQueen    },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.kKing     },
				new Card{Shape = ShapeType.kShape3, Value = ValueType.kAce      },

				new Card{Shape = ShapeType.kShape4, Value = ValueType.k2        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k3        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k4        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k5        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k6        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k7        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k8        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k9        },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.k10       },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.kJack     },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.kQueen    },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.kKing     },
				new Card{Shape = ShapeType.kShape4, Value = ValueType.kAce      },
			};
	}
}
