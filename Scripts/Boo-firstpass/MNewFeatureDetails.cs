using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class MNewFeatureDetails : MerlinMaster
{
	[Serializable]
	internal class _0024GetNewDetails_0024locals_00242314
	{
		internal int _0024newest;
	}

	[Serializable]
	internal class _0024GetNewDetails_0024closure_0024575
	{
		internal _0024GetNewDetails_0024locals_00242314 _0024_0024locals_00242323;

		public _0024GetNewDetails_0024closure_0024575(_0024GetNewDetails_0024locals_00242314 _0024_0024locals_00242323)
		{
			this._0024_0024locals_00242323 = _0024_0024locals_00242323;
		}

		public bool Invoke(MNewFeatureDetails m)
		{
			bool num = !m.MustDisplay;
			if (num)
			{
				num = m.NewsId < _0024_0024locals_00242323._0024newest;
			}
			return num;
		}
	}

	public int _0024var_0024Id;

	public int _0024var_0024NewsId;

	public string _0024var_0024Name;

	public bool _0024var_0024MustDisplay;

	public int _0024var_0024DisplayPriority;

	public string _0024var_0024Title;

	public string _0024var_0024Message;

	[NonSerialized]
	private static Dictionary<int, MNewFeatureDetails> _0024mst_0024127 = new Dictionary<int, MNewFeatureDetails>();

	[NonSerialized]
	private static MNewFeatureDetails[] All_cache;

	public int Id => _0024var_0024Id;

	public int NewsId => _0024var_0024NewsId;

	public string Name => _0024var_0024Name;

	public bool MustDisplay => _0024var_0024MustDisplay;

	public int DisplayPriority => _0024var_0024DisplayPriority;

	public string Title => _0024var_0024Title;

	public string Message => _0024var_0024Message;

	public static MNewFeatureDetails[] All
	{
		get
		{
			MNewFeatureDetails[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MNewFeatureDetails");
				MNewFeatureDetails[] array = (MNewFeatureDetails[])Builtins.array(typeof(MNewFeatureDetails), _0024mst_0024127.Values);
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
		return new StringBuilder("MNewFeatureDetails(").Append((object)Id).Append(",NewsId=").Append((object)NewsId)
			.Append(",")
			.Append(Name)
			.Append(")")
			.ToString();
	}

	public static MNewFeatureDetails[] GetNewDetails(int currentDisplayedId)
	{
		_0024GetNewDetails_0024locals_00242314 _0024GetNewDetails_0024locals_0024 = new _0024GetNewDetails_0024locals_00242314();
		System.Collections.Generic.List<MNewFeatureDetails> list = new System.Collections.Generic.List<MNewFeatureDetails>();
		int i = 0;
		MNewFeatureDetails[] all = All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				if (all[i].NewsId > currentDisplayedId)
				{
					list.Add(all[i]);
				}
			}
			list.Sort(_0024adaptor_0024__Masters2_0024callable69_00243609_21___0024Comparison_00242.Adapt((MNewFeatureDetails a, MNewFeatureDetails b) => (a.NewsId != b.NewsId) ? (b.NewsId - a.NewsId) : (a.DisplayPriority - b.DisplayPriority)));
			if (list.Count > 0)
			{
				_0024GetNewDetails_0024locals_0024._0024newest = list[0].NewsId;
				list.RemoveAll(_0024adaptor_0024__MNewFeatureDetails_GetNewDetails_0024callable226_00243616_27___0024Predicate_00243.Adapt(new _0024GetNewDetails_0024closure_0024575(_0024GetNewDetails_0024locals_0024).Invoke));
			}
			return (MNewFeatureDetails[])Builtins.array(typeof(MNewFeatureDetails), list);
		}
	}

	public static MNewFeatureDetails Get(int _id)
	{
		MerlinMaster.GetHandler("MNewFeatureDetails");
		return (!_0024mst_0024127.ContainsKey(_id)) ? null : _0024mst_0024127[_id];
	}

	public static void Unload()
	{
		_0024mst_0024127.Clear();
		All_cache = null;
	}

	public static MNewFeatureDetails New(Hashtable data)
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
			MNewFeatureDetails mNewFeatureDetails = Create(data);
			if (!_0024mst_0024127.ContainsKey(mNewFeatureDetails.Id))
			{
				_0024mst_0024127[mNewFeatureDetails.Id] = mNewFeatureDetails;
			}
			result = mNewFeatureDetails;
		}
		return (MNewFeatureDetails)result;
	}

	public static MNewFeatureDetails New2(string[] keys, object[] vals)
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
		return (MNewFeatureDetails)result;
	}

	public static MNewFeatureDetails Entry(MNewFeatureDetails mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_0024127[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MNewFeatureDetails)result;
	}

	public static void AddMst(MNewFeatureDetails mst)
	{
		if (mst != null)
		{
			_0024mst_0024127[mst.Id] = mst;
		}
	}

	public static MNewFeatureDetails Create(Hashtable data)
	{
		MNewFeatureDetails mNewFeatureDetails = new MNewFeatureDetails();
		MNewFeatureDetails result;
		if (data == null)
		{
			result = mNewFeatureDetails;
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
				mNewFeatureDetails.setField((string)obj, data[current]);
			}
			result = mNewFeatureDetails;
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
		case "NewsId":
			_0024var_0024NewsId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "MustDisplay":
			_0024var_0024MustDisplay = MasterBaseClass.ToBool(val);
			break;
		case "DisplayPriority":
			_0024var_0024DisplayPriority = MasterBaseClass.ToInt(val);
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
			"NewsId" => true, 
			"Name" => true, 
			"MustDisplay" => true, 
			"DisplayPriority" => true, 
			"Title" => true, 
			"Message" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "NewsId", "Name", "MustDisplay", "DisplayPriority", "Title", "Message" });
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
					_0024var_0024NewsId = MasterBaseClass.ParseInt(vals[1]);
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Name = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024MustDisplay = MasterBaseClass.ParseBool(vals[3]);
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024DisplayPriority = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Title = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Message = vals[6];
									}
									int num = 7;
									result = num;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	internal static int _0024GetNewDetails_0024closure_0024574(MNewFeatureDetails a, MNewFeatureDetails b)
	{
		return checked((a.NewsId != b.NewsId) ? (b.NewsId - a.NewsId) : (a.DisplayPriority - b.DisplayPriority));
	}
}
