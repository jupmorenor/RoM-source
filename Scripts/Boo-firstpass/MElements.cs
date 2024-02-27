using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MElements : MerlinMaster
{
	public int _0024var_0024Id;

	public string _0024var_0024Name;

	public string _0024var_0024Icon;

	public string _0024var_0024WeaponIcon;

	public string _0024var_0024PoppetIcon;

	public string _0024var_0024MainIcon;

	public string _0024var_0024Progname;

	public int _0024var_0024ColorRed;

	public int _0024var_0024ColorGreen;

	public int _0024var_0024ColorBlue;

	public int _0024var_0024RenkeiForeRed;

	public int _0024var_0024RenkeiForeGreen;

	public int _0024var_0024RenkeiForeBlue;

	public int _0024var_0024RenkeiBackRed;

	public int _0024var_0024RenkeiBackGreen;

	public int _0024var_0024RenkeiBackBlue;

	[NonSerialized]
	private MTexts Name__cache;

	[NonSerialized]
	private static Dictionary<int, MElements> _0024mst_00248 = new Dictionary<int, MElements>();

	[NonSerialized]
	private static MElements[] All_cache;

	public Color Color => new Color((float)ColorRed / 255f, (float)ColorGreen / 255f, (float)ColorBlue / 255f);

	public Color RenkeiForeColor => new Color((float)RenkeiForeRed / 255f, (float)RenkeiForeGreen / 255f, (float)RenkeiForeBlue / 255f);

	public Color RenkeiBackColor => new Color((float)RenkeiBackRed / 255f, (float)RenkeiBackGreen / 255f, (float)RenkeiBackBlue / 255f);

	public int Id => _0024var_0024Id;

	public MTexts Name
	{
		get
		{
			if (Name__cache == null)
			{
				Name__cache = MTexts.Get(_0024var_0024Name);
			}
			return Name__cache;
		}
	}

	public string Icon => _0024var_0024Icon;

	public string WeaponIcon => _0024var_0024WeaponIcon;

	public string PoppetIcon => _0024var_0024PoppetIcon;

	public string MainIcon => _0024var_0024MainIcon;

	public string Progname => _0024var_0024Progname;

	public int ColorRed => _0024var_0024ColorRed;

	public int ColorGreen => _0024var_0024ColorGreen;

	public int ColorBlue => _0024var_0024ColorBlue;

	public int RenkeiForeRed => _0024var_0024RenkeiForeRed;

	public int RenkeiForeGreen => _0024var_0024RenkeiForeGreen;

	public int RenkeiForeBlue => _0024var_0024RenkeiForeBlue;

	public int RenkeiBackRed => _0024var_0024RenkeiBackRed;

	public int RenkeiBackGreen => _0024var_0024RenkeiBackGreen;

	public int RenkeiBackBlue => _0024var_0024RenkeiBackBlue;

	public static MElements[] All
	{
		get
		{
			MElements[] result;
			if (All_cache == null)
			{
				MerlinMaster.GetHandler("MElements");
				MElements[] array = (MElements[])Builtins.array(typeof(MElements), _0024mst_00248.Values);
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

	public MElements()
	{
		_0024var_0024RenkeiForeRed = 255;
		_0024var_0024RenkeiForeGreen = 255;
		_0024var_0024RenkeiForeBlue = 255;
		_0024var_0024RenkeiBackRed = 255;
		_0024var_0024RenkeiBackGreen = 255;
		_0024var_0024RenkeiBackBlue = 255;
	}

	public override string ToString()
	{
		return new StringBuilder("MElements(").Append((object)Id).Append(":").Append(Name)
			.Append(")")
			.ToString();
	}

	public static implicit operator int(MElements m)
	{
		return m.Id;
	}

	public static MElements Get(int _id)
	{
		MerlinMaster.GetHandler("MElements");
		return (!_0024mst_00248.ContainsKey(_id)) ? null : _0024mst_00248[_id];
	}

	public static void Unload()
	{
		_0024mst_00248.Clear();
		All_cache = null;
	}

	public static MElements New(Hashtable data)
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
			MElements mElements = Create(data);
			if (!_0024mst_00248.ContainsKey(mElements.Id))
			{
				_0024mst_00248[mElements.Id] = mElements;
			}
			result = mElements;
		}
		return (MElements)result;
	}

	public static MElements New2(string[] keys, object[] vals)
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
		return (MElements)result;
	}

	public static MElements Entry(MElements mst, object id)
	{
		object result;
		if (mst != null)
		{
			mst.setField("Id", id);
			_0024mst_00248[RuntimeServices.UnboxInt32(id)] = mst;
			result = mst;
		}
		else
		{
			result = null;
		}
		return (MElements)result;
	}

	public static void AddMst(MElements mst)
	{
		if (mst != null)
		{
			_0024mst_00248[mst.Id] = mst;
		}
	}

	public static MElements Create(Hashtable data)
	{
		MElements mElements = new MElements();
		MElements result;
		if (data == null)
		{
			result = mElements;
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
				mElements.setField((string)obj, data[current]);
			}
			result = mElements;
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
		case "Name":
			_0024var_0024Name = MasterBaseClass.ToStringValue(val);
			break;
		case "Icon":
			_0024var_0024Icon = MasterBaseClass.ToStringValue(val);
			break;
		case "WeaponIcon":
			_0024var_0024WeaponIcon = MasterBaseClass.ToStringValue(val);
			break;
		case "PoppetIcon":
			_0024var_0024PoppetIcon = MasterBaseClass.ToStringValue(val);
			break;
		case "MainIcon":
			_0024var_0024MainIcon = MasterBaseClass.ToStringValue(val);
			break;
		case "Progname":
			_0024var_0024Progname = MasterBaseClass.ToStringValue(val);
			break;
		case "ColorRed":
			_0024var_0024ColorRed = MasterBaseClass.ToInt(val);
			break;
		case "ColorGreen":
			_0024var_0024ColorGreen = MasterBaseClass.ToInt(val);
			break;
		case "ColorBlue":
			_0024var_0024ColorBlue = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiForeRed":
			_0024var_0024RenkeiForeRed = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiForeGreen":
			_0024var_0024RenkeiForeGreen = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiForeBlue":
			_0024var_0024RenkeiForeBlue = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiBackRed":
			_0024var_0024RenkeiBackRed = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiBackGreen":
			_0024var_0024RenkeiBackGreen = MasterBaseClass.ToInt(val);
			break;
		case "RenkeiBackBlue":
			_0024var_0024RenkeiBackBlue = MasterBaseClass.ToInt(val);
			break;
		}
	}

	public static bool HasKey(string key)
	{
		return key switch
		{
			"Id" => true, 
			"Name" => true, 
			"Icon" => true, 
			"WeaponIcon" => true, 
			"PoppetIcon" => true, 
			"MainIcon" => true, 
			"Progname" => true, 
			"ColorRed" => true, 
			"ColorGreen" => true, 
			"ColorBlue" => true, 
			"RenkeiForeRed" => true, 
			"RenkeiForeGreen" => true, 
			"RenkeiForeBlue" => true, 
			"RenkeiBackRed" => true, 
			"RenkeiBackGreen" => true, 
			"RenkeiBackBlue" => true, 
			_ => false, 
		};
	}

	public static string[] KeyNameList()
	{
		string[] lhs = new string[0];
		return (string[])RuntimeServices.AddArrays(typeof(string), lhs, new string[16]
		{
			"Id", "Name", "Icon", "WeaponIcon", "PoppetIcon", "MainIcon", "Progname", "ColorRed", "ColorGreen", "ColorBlue",
			"RenkeiForeRed", "RenkeiForeGreen", "RenkeiForeBlue", "RenkeiBackRed", "RenkeiBackGreen", "RenkeiBackBlue"
		});
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
					_0024var_0024Name = vals[1];
				}
				if (length <= 2)
				{
					result = 2;
				}
				else
				{
					if (vals[2] != null)
					{
						_0024var_0024Icon = vals[2];
					}
					if (length <= 3)
					{
						result = 3;
					}
					else
					{
						if (vals[3] != null)
						{
							_0024var_0024WeaponIcon = vals[3];
						}
						if (length <= 4)
						{
							result = 4;
						}
						else
						{
							if (vals[4] != null)
							{
								_0024var_0024PoppetIcon = vals[4];
							}
							if (length <= 5)
							{
								result = 5;
							}
							else
							{
								if (vals[5] != null)
								{
									_0024var_0024MainIcon = vals[5];
								}
								if (length <= 6)
								{
									result = 6;
								}
								else
								{
									if (vals[6] != null)
									{
										_0024var_0024Progname = vals[6];
									}
									if (length <= 7)
									{
										result = 7;
									}
									else
									{
										if (vals[7] != null)
										{
											_0024var_0024ColorRed = MasterBaseClass.ParseInt(vals[7]);
										}
										if (length <= 8)
										{
											result = 8;
										}
										else
										{
											if (vals[8] != null)
											{
												_0024var_0024ColorGreen = MasterBaseClass.ParseInt(vals[8]);
											}
											if (length <= 9)
											{
												result = 9;
											}
											else
											{
												if (vals[9] != null)
												{
													_0024var_0024ColorBlue = MasterBaseClass.ParseInt(vals[9]);
												}
												if (length <= 10)
												{
													result = 10;
												}
												else
												{
													if (vals[10] != null)
													{
														_0024var_0024RenkeiForeRed = MasterBaseClass.ParseInt(vals[10]);
													}
													if (length <= 11)
													{
														result = 11;
													}
													else
													{
														if (vals[11] != null)
														{
															_0024var_0024RenkeiForeGreen = MasterBaseClass.ParseInt(vals[11]);
														}
														if (length <= 12)
														{
															result = 12;
														}
														else
														{
															if (vals[12] != null)
															{
																_0024var_0024RenkeiForeBlue = MasterBaseClass.ParseInt(vals[12]);
															}
															if (length <= 13)
															{
																result = 13;
															}
															else
															{
																if (vals[13] != null)
																{
																	_0024var_0024RenkeiBackRed = MasterBaseClass.ParseInt(vals[13]);
																}
																if (length <= 14)
																{
																	result = 14;
																}
																else
																{
																	if (vals[14] != null)
																	{
																		_0024var_0024RenkeiBackGreen = MasterBaseClass.ParseInt(vals[14]);
																	}
																	if (length <= 15)
																	{
																		result = 15;
																	}
																	else
																	{
																		if (vals[15] != null)
																		{
																			_0024var_0024RenkeiBackBlue = MasterBaseClass.ParseInt(vals[15]);
																		}
																		int num = 16;
																		result = num;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
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
