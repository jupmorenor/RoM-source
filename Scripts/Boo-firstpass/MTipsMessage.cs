using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MTipsMessage : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Title;

	public string _0024var_0024Message;

	[NonSerialized]
	private MTexts Title__cache;

	[NonSerialized]
	private MTexts Message__cache;

	[NonSerialized]
	private static Dictionary<int, MTipsMessage> _0024mst_0024116 = new Dictionary<int, MTipsMessage>();

	[NonSerialized]
	private static MTipsMessage[] All_cache;

	public int Id => _0024var_0024Id;

	public MTexts Title
	{
		get
		{
			if (Title__cache == null)
			{
				Title__cache = MTexts.Get(_0024var_0024Title);
			}
			return Title__cache;
		}
	}

	public MTexts Message
	{
		get
		{
			if (Message__cache == null)
			{
				Message__cache = MTexts.Get(_0024var_0024Message);
			}
			return Message__cache;
		}
	}

	public static MTipsMessage[] All
	{
		get
		{
			MTipsMessage[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MTipsMessage");
				MTipsMessage[] array = (MTipsMessage[])Builtins.array(typeof(MTipsMessage), _0024mst_0024116.Values);
				if (array.Length > 0)
				{
					All_cache = array;
					result = All_cache;
				}
				else
				{
					result = array;
				}
			}
			else
			{
				result = All_cache;
			}
			return result;
		}
	}

	public override string ToString()
	{
		return new StringBuilder("MTips(").Append((object)Id).Append(":").Append(Title)
			.Append(", ")
			.Append(Message)
			.Append(")")
			.ToString();
	}

	public static MTipsMessage Get(int _id)
	{
		MerlinMaster.GetHandler("MTipsMessage");
		return (!_0024mst_0024116.ContainsKey(_id)) ? null : _0024mst_0024116[_id];
	}

	public static void Unload()
	{
		_0024mst_0024116.Clear();
		All_cache = null;
	}

	public static MTipsMessage New(Hashtable data)
	{
		object result;
		if (data == null || data.Count <= 0)
		{
			result = null;
		}
		else if (!data.ContainsKey("Id"))
		{
			result = null;
		}
		else
		{
			MTipsMessage mTipsMessage = Create(data);
			if (!_0024mst_0024116.ContainsKey(mTipsMessage.Id))
			{
				_0024mst_0024116[mTipsMessage.Id] = mTipsMessage;
			}
			result = mTipsMessage;
		}
		return (MTipsMessage)result;
	}

	public static MTipsMessage New2(string[] keys, object[] vals)
	{
		object result;
		if (keys == null || vals == null)
		{
			result = null;
		}
		else if (keys.Length <= 0 || vals.Length <= 0)
		{
			result = null;
		}
		else
		{
			Hashtable hashtable = new Hashtable();
			int num = ((vals.Length >= keys.Length) ? keys.Length : vals.Length);
			int num2 = 0;
			int num3 = num;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index = num2;
				num2++;
				hashtable[keys[RuntimeServices.NormalizeArrayIndex(keys, index)]] = vals[RuntimeServices.NormalizeArrayIndex(vals, index)];
			}
			result = New(hashtable);
		}
		return (MTipsMessage)result;
	}

	public static MTipsMessage Entry(MTipsMessage mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024116[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MTipsMessage)result;
	}

	public static void AddMst(MTipsMessage mst)
	{
		if (mst != null)
		{
			_0024mst_0024116[mst.Id] = mst;
		}
	}

	public static MTipsMessage Create(Hashtable data)
	{
		MTipsMessage mTipsMessage = new MTipsMessage();
		MTipsMessage result;
		if (data == null)
		{
			result = mTipsMessage;
		}
		else
		{
			IEnumerator enumerator = data.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				object obj = current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				mTipsMessage.setField((string)obj, data[current]);
			}
			result = mTipsMessage;
		}
		return result;
	}

	public void setField(string key, object val)
	{
		switch (key)
		{
		case "Id":
			_0024var_0024Id = MasterBaseClass.ToInt(val);
			break;
		case "Title":
			_0024var_0024Title = MasterBaseClass.ToStringValue(val);
			break;
		case "Message":
			_0024var_0024Message = MasterBaseClass.ToStringValue(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Title" => true, 
			"Message" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[3] { "Id", "Title", "Message" });
	}

	public int setStringValues(string[] vals)
	{
		int length = vals.Length;
		int result;
		if (length <= 0)
		{
			result = 0;
		}
		else
		{
			if (vals[0] != null)
			{
				_0024var_0024Id = MasterBaseClass.ParseInt(vals[0]);
			}
			if (length <= 1)
			{
				result = 1;
			}
			else
			{
				if (vals[1] != null)
				{
					_0024var_0024Title = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Message = vals[2];
					}
					int num = 3;
					result = num;
				}
			}
		}
		return result;
	}
}
