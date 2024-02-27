using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class QuestFactory
{
	[Serializable]
	public class QuestInfo
	{
		public string id;

		public string name;

		public string type;

		public string place;

		public string info;

		public string money;

		public string cost;

		public string[] iconTresure;

		public int hour;

		public int minute;
	}

	[NonSerialized]
	private static Hash table = new Hash
	{
		{
			"賢者トレントを探せ！",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！2",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！3",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！4",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！5",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！6",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！7",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！8",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		},
		{
			"賢者トレントを探せ！9",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- ストーリー -" },
				{ "info", "森でジャッカルが暴れているので何とかしてほしい。" }
			}
		}
	};

	[NonSerialized]
	private static Hash spcialTable = new Hash
	{
		{
			"スペシャル",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- スペシャル -" },
				{ "info", "スペシャルなクエスト" }
			}
		},
		{
			"スペシャル２",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- スペシャル -" },
				{ "info", "スペシャルなクエスト" }
			}
		},
		{
			"スペシャル３",
			new Hash
			{
				{ "place", "ウェンデルの森" },
				{ "type", "- スペシャル -" },
				{ "info", "スペシャルなクエスト" }
			}
		}
	};

	private static QuestInfo[] GetListToTable(Hash list)
	{
		QuestInfo[] array = new QuestInfo[list.Count];
		int num = 0;
		IDictionaryEnumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
			array[RuntimeServices.NormalizeArrayIndex(array, num)] = new QuestInfo();
			QuestInfo obj = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			object obj2 = dictionaryEntry.Key;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			obj.name = (string)obj2;
			Hash hash = dictionaryEntry.Value as Hash;
			QuestInfo obj3 = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			object obj4 = hash["place"];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			obj3.place = (string)obj4;
			QuestInfo obj5 = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			object obj6 = hash["type"];
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			obj5.type = (string)obj6;
			QuestInfo obj7 = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			object obj8 = hash["info"];
			if (!(obj8 is string))
			{
				obj8 = RuntimeServices.Coerce(obj8, typeof(string));
			}
			obj7.info = (string)obj8;
			array[RuntimeServices.NormalizeArrayIndex(array, num)].money = "10000";
			array[RuntimeServices.NormalizeArrayIndex(array, num)].cost = "-100";
			num = checked(num + 1);
		}
		return array;
	}

	public static QuestInfo[] GetQuestInfo()
	{
		return GetListToTable(table);
	}

	public static QuestInfo[] GetSpcialQuestInfo()
	{
		return GetListToTable(spcialTable);
	}
}
