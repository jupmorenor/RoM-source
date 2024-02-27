using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class MChangeDeckSupports : MerlinMaster
{
	public int _0024var_0024Id;

	public Deck2FormTypes _0024var_0024FormType;

	public Deck2ItemTypes _0024var_0024ItemType;

	public int _0024var_0024No;

	public int _0024var_0024ItemId;

	[NonSerialized]
	private static Dictionary<int, MChangeDeckSupports> _0024mst_0024119 = new Dictionary<int, MChangeDeckSupports>();

	[NonSerialized]
	private static MChangeDeckSupports[] All_cache;

	public int Id => _0024var_0024Id;

	public Deck2FormTypes FormType => _0024var_0024FormType;

	public Deck2ItemTypes ItemType => _0024var_0024ItemType;

	public int No => _0024var_0024No;

	public int ItemId => _0024var_0024ItemId;

	public static MChangeDeckSupports[] All
	{
		get
		{
			MChangeDeckSupports[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MChangeDeckSupports");
				MChangeDeckSupports[] array = (MChangeDeckSupports[])Builtins.array(typeof(MChangeDeckSupports), _0024mst_0024119.Values);
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

	public MChangeDeckSupports()
	{
		_0024var_0024FormType = Deck2FormTypes.Angel;
		_0024var_0024ItemType = Deck2ItemTypes.Weapon;
	}

	public override string ToString()
	{
		return new StringBuilder("MChangeDeckSupports(").Append((object)Id).Append(",No:").Append((object)No)
			.Append(",")
			.Append(FormType)
			.Append(",")
			.Append(ItemType)
			.Append(",Item:")
			.Append((object)ItemId)
			.Append(")")
			.ToString();
	}

	public static MChangeDeckSupports Get(int _id)
	{
		MerlinMaster.GetHandler("MChangeDeckSupports");
		return (!_0024mst_0024119.ContainsKey(_id)) ? null : _0024mst_0024119[_id];
	}

	public static void Unload()
	{
		_0024mst_0024119.Clear();
		All_cache = null;
	}

	public static MChangeDeckSupports New(Hashtable data)
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
			MChangeDeckSupports mChangeDeckSupports = Create(data);
			if (!_0024mst_0024119.ContainsKey(mChangeDeckSupports.Id))
			{
				_0024mst_0024119[mChangeDeckSupports.Id] = mChangeDeckSupports;
			}
			result = mChangeDeckSupports;
		}
		return (MChangeDeckSupports)result;
	}

	public static MChangeDeckSupports New2(string[] keys, object[] vals)
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
		return (MChangeDeckSupports)result;
	}

	public static MChangeDeckSupports Entry(MChangeDeckSupports mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024119[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MChangeDeckSupports)result;
	}

	public static void AddMst(MChangeDeckSupports mst)
	{
		if (mst != null)
		{
			_0024mst_0024119[mst.Id] = mst;
		}
	}

	public static MChangeDeckSupports Create(Hashtable data)
	{
		MChangeDeckSupports mChangeDeckSupports = new MChangeDeckSupports();
		MChangeDeckSupports result;
		if (data == null)
		{
			result = mChangeDeckSupports;
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
				mChangeDeckSupports.setField((string)obj, data[current]);
			}
			result = mChangeDeckSupports;
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
		case "FormType":
			if (typeof(Deck2FormTypes).IsEnum)
			{
				_0024var_0024FormType = (Deck2FormTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "ItemType":
			if (typeof(Deck2ItemTypes).IsEnum)
			{
				_0024var_0024ItemType = (Deck2ItemTypes)MasterBaseClass.ToEnum(val);
			}
			break;
		case "No":
			_0024var_0024No = MasterBaseClass.ToInt(val);
			break;
		case "ItemId":
			_0024var_0024ItemId = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"FormType" => true, 
			"ItemType" => true, 
			"No" => true, 
			"ItemId" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[5] { "Id", "FormType", "ItemType", "No", "ItemId" });
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
				if (vals[1] != null && typeof(Deck2FormTypes).IsEnum)
				{
					_0024var_0024FormType = (Deck2FormTypes)MasterBaseClass.ParseEnum(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null && typeof(Deck2ItemTypes).IsEnum)
					{
						_0024var_0024ItemType = (Deck2ItemTypes)MasterBaseClass.ParseEnum(vals[2]);
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024No = MasterBaseClass.ParseInt(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024ItemId = MasterBaseClass.ParseInt(vals[4]);
							}
							int num = 5;
							result = num;
						}
					}
				}
			}
		}
		return result;
	}
}
