using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class MGameParameters : MerlinMaster
{
	[Serializable]
	internal class _0024findByGameParameterId_0024locals_00242312
	{
		internal int _0024paramId;
	}

	[Serializable]
	internal class _0024findAllByGameParameterId_0024locals_00242313
	{
		internal int _0024paramId;
	}

	[Serializable]
	internal class _0024findByGameParameterId_0024closure_0024462
	{
		internal _0024findByGameParameterId_0024locals_00242312 _0024_0024locals_00242321;

		public _0024findByGameParameterId_0024closure_0024462(_0024findByGameParameterId_0024locals_00242312 _0024_0024locals_00242321)
		{
			this._0024_0024locals_00242321 = _0024_0024locals_00242321;
		}

		public bool Invoke(MGameParameters v)
		{
			return v.GameParameterId == _0024_0024locals_00242321._0024paramId;
		}
	}

	[Serializable]
	internal class _0024findAllByGameParameterId_0024closure_0024463
	{
		internal _0024findAllByGameParameterId_0024locals_00242313 _0024_0024locals_00242322;

		public _0024findAllByGameParameterId_0024closure_0024463(_0024findAllByGameParameterId_0024locals_00242313 _0024_0024locals_00242322)
		{
			this._0024_0024locals_00242322 = _0024_0024locals_00242322;
		}

		public bool Invoke(MGameParameters v)
		{
			return v.GameParameterId == _0024_0024locals_00242322._0024paramId;
		}
	}

	public int _0024var_0024Id;

	public int _0024var_0024GameParameterId;

	public string _0024var_0024Name;

	public string _0024var_0024EnumName;

	public int _0024var_0024Param;

	public int _0024var_0024Sort;

	public int _0024var_0024Rate;

	[NonSerialized]
	private static Dictionary<int, MGameParameters> _0024mst_002427 = new Dictionary<int, MGameParameters>();

	[NonSerialized]
	private static MGameParameters[] All_cache;

	public static int TutorialStepForRaidBattleRookie
	{
		get
		{
			MGameParameters mGameParameters = findByGameParameterId(33);
			if (mGameParameters == null)
			{
				throw new AssertionFailedException("m != null");
			}
			return mGameParameters.Param;
		}
	}

	public int Id => _0024var_0024Id;

	public int GameParameterId => _0024var_0024GameParameterId;

	public string Name => _0024var_0024Name;

	public string EnumName => _0024var_0024EnumName;

	public int Param => _0024var_0024Param;

	public int Sort => _0024var_0024Sort;

	public int Rate => _0024var_0024Rate;

	public static MGameParameters[] All
	{
		get
		{
			MGameParameters[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MGameParameters");
				MGameParameters[] array = (MGameParameters[])Builtins.array(typeof(MGameParameters), _0024mst_002427.Values);
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
		return new StringBuilder("MGameParameters( Id:").Append((object)Id).Append(", GameParameterId:").Append((object)GameParameterId)
			.Append(", ")
			.Append(Name)
			.Append(":")
			.Append(Name)
			.Append(", ")
			.Append(EnumName)
			.Append(":")
			.Append(EnumName)
			.Append(", Param:")
			.Append((object)Param)
			.Append(", Sort:")
			.Append((object)Sort)
			.Append(", Rate:")
			.Append((object)Rate)
			.Append(" )")
			.ToString();
	}

	public static MGameParameters findByGameParameterId(int paramId)
	{
		_0024findByGameParameterId_0024locals_00242312 _0024findByGameParameterId_0024locals_0024 = new _0024findByGameParameterId_0024locals_00242312();
		_0024findByGameParameterId_0024locals_0024._0024paramId = paramId;
		return Array.Find((MGameParameters[])Builtins.array(typeof(MGameParameters), All), _0024adaptor_0024__MGameParameters_findByGameParameterId_0024callable223_00241261_33___0024Predicate_00241.Adapt(new _0024findByGameParameterId_0024closure_0024462(_0024findByGameParameterId_0024locals_0024).Invoke));
	}

	public static MGameParameters[] findAllByGameParameterId(int paramId)
	{
		_0024findAllByGameParameterId_0024locals_00242313 _0024findAllByGameParameterId_0024locals_0024 = new _0024findAllByGameParameterId_0024locals_00242313();
		_0024findAllByGameParameterId_0024locals_0024._0024paramId = paramId;
		return Array.FindAll((MGameParameters[])Builtins.array(typeof(MGameParameters), All), _0024adaptor_0024__MGameParameters_findByGameParameterId_0024callable223_00241261_33___0024Predicate_00241.Adapt(new _0024findAllByGameParameterId_0024closure_0024463(_0024findAllByGameParameterId_0024locals_0024).Invoke));
	}

	public static MGameParameters Get(int _id)
	{
		MerlinMaster.GetHandler("MGameParameters");
		return (!_0024mst_002427.ContainsKey(_id)) ? null : _0024mst_002427[_id];
	}

	public static void Unload()
	{
		_0024mst_002427.Clear();
		All_cache = null;
	}

	public static MGameParameters New(Hashtable data)
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
			MGameParameters mGameParameters = Create(data);
			if (!_0024mst_002427.ContainsKey(mGameParameters.Id))
			{
				_0024mst_002427[mGameParameters.Id] = mGameParameters;
			}
			result = mGameParameters;
		}
		return (MGameParameters)result;
	}

	public static MGameParameters New2(string[] keys, object[] vals)
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
		return (MGameParameters)result;
	}

	public static MGameParameters Entry(MGameParameters mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_002427[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MGameParameters)result;
	}

	public static void AddMst(MGameParameters mst)
	{
		if (mst != null)
		{
			_0024mst_002427[mst.Id] = mst;
		}
	}

	public static MGameParameters Create(Hashtable data)
	{
		MGameParameters mGameParameters = new MGameParameters();
		MGameParameters result;
		if (data == null)
		{
			result = mGameParameters;
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
				mGameParameters.setField((string)obj, data[current]);
			}
			result = mGameParameters;
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
		case "GameParameterId":
			_0024var_0024GameParameterId = MasterBaseClass.ToInt(val);
			break;
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "EnumName":
			_0024var_0024EnumName = MasterBaseClass.ToStringValue(val);
			break;
		case "Param":
			_0024var_0024Param = MasterBaseClass.ToInt(val);
			break;
		case "Sort":
			_0024var_0024Sort = MasterBaseClass.ToInt(val);
			break;
		case "Rate":
			_0024var_0024Rate = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"GameParameterId" => true, 
			"Name" => true, 
			"EnumName" => true, 
			"Param" => true, 
			"Sort" => true, 
			"Rate" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[7] { "Id", "GameParameterId", "Name", "EnumName", "Param", "Sort", "Rate" });
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
					_0024var_0024GameParameterId = MasterBaseClass.ParseInt(vals[1]);
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
							_0024var_0024EnumName = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024Param = MasterBaseClass.ParseInt(vals[4]);
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024Sort = MasterBaseClass.ParseInt(vals[5]);
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Rate = MasterBaseClass.ParseInt(vals[6]);
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
}
