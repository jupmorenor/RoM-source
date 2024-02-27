using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class MerlinMaster : MasterBaseClass
{
	[Serializable]
	private class MasterLoadMethodEntry
	{
		public Type masterType;

		public __MasterLoadMethodEntry_createInst_0024callable19_0024189_30__ createInst;

		public __MasterLoadMethodEntry_unload_0024callable20_0024190_26__ unload;

		public __MasterLoadMethodEntry_keyNameList_0024callable21_0024191_31__ keyNameList;

		public __MasterLoadMethodEntry_setStringValues_0024callable22_0024192_35__ setStringValues;

		public __MasterLoadMethodEntry_addMst_0024callable23_0024193_26__ addMst;
	}

	[NonSerialized]
	public const string CANCEL_ROW_MARK = "!@#$%deprecated%$#@!";

	[NonSerialized]
	private static Hash LoadedMasters = new Hash();

	[NonSerialized]
	private static Dictionary<string, MasterLoadMethodEntry> MasterMethodDict;

	public static Hash DebugLoadedMasters => LoadedMasters;

	public static void GetHandler(string masterName)
	{
		LoadMasterFromTSVResource(masterName);
	}

	public static bool IsLoadMarked(string masterName)
	{
		return LoadedMasters.ContainsKey(masterName);
	}

	public static void MarkUnloaded(string masterName)
	{
		if (!string.IsNullOrEmpty(masterName))
		{
			LoadedMasters.Remove(masterName);
		}
	}

	public static void MarkLoaded(string masterName)
	{
		if (!string.IsNullOrEmpty(masterName))
		{
			LoadedMasters[masterName] = true;
		}
	}

	public static void ClearAllMark()
	{
		LoadedMasters.Clear();
	}

	public static void LoadMasterFromBytes(string masterName, ClientMasterArchive arc)
	{
		LoadMasterFromBytes(masterName, arc.Read(masterName + ".txt"));
	}

	private static void LoadMasterFromTSVResource(string masterName)
	{
		if (!LoadedMasters.ContainsKey(masterName))
		{
			LoadedMasters[masterName] = true;
		}
	}

	private static void LoadMasterFromBytes(string masterName, byte[] bytes)
	{
		if (bytes == null || bytes.Length == 0)
		{
			WriteLineToConsole(new StringBuilder("MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(" bytes=null or len=0!").ToString());
			return;
		}
		WriteLineToConsole(new StringBuilder("MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(" bytes:").Append((object)(bytes?.Length ?? (-1)))
			.ToString());
		if (MasterMethodDict == null)
		{
			MasterMethodDict = InitLoadMethodTbl();
		}
		if (!MasterMethodDict.ContainsKey(masterName))
		{
			WriteLineToConsole(new StringBuilder("MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(" no method entry!!!").ToString());
			return;
		}
		MasterLoadMethodEntry masterLoadMethodEntry = MasterMethodDict[masterName];
		Type masterType = masterLoadMethodEntry.masterType;
		if (masterType == null)
		{
			WriteLineToConsole(new StringBuilder("MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(" no type !!!").ToString());
			return;
		}
		masterLoadMethodEntry.unload();
		string[] array = masterLoadMethodEntry.keyNameList();
		if (array == null)
		{
			throw new AssertionFailedException(new StringBuilder("MelrinMaster.LoadMasterFromBytes ").Append(masterName).Append(" mstKeys == null").ToString());
		}
		try
		{
			MemoryStream stream;
			IDisposable disposable = (stream = new MemoryStream(bytes)) as IDisposable;
			try
			{
				StreamReader streamReader;
				IDisposable disposable2 = (streamReader = new StreamReader(stream)) as IDisposable;
				try
				{
					Boo.Lang.List<string> list = new Boo.Lang.List<string>();
					int num = -1;
					string[] array2 = null;
					int[] array3 = null;
					while (true)
					{
						string text = streamReader.ReadLine();
						if (text == null)
						{
							break;
						}
						if (text.IndexOf("!@#$%deprecated%$#@!") >= 0)
						{
							continue;
						}
						string[] array4 = text.Replace("\\n", "\n").Split('\t');
						if ((num = checked(num + 1)) == 0)
						{
							array2 = array4;
							array3 = new int[array2.Length];
							int num2 = 0;
							int length = array2.Length;
							if (length < 0)
							{
								throw new ArgumentOutOfRangeException("max");
							}
							while (num2 < length)
							{
								int index = num2;
								num2++;
								int[] array5 = array3;
								int num3 = RuntimeServices.NormalizeArrayIndex(array5, index);
								string[] array6 = array2;
								array5[num3] = Array.IndexOf(array, array6[RuntimeServices.NormalizeArrayIndex(array6, index)]);
							}
							continue;
						}
						string[] array7 = new string[array.Length];
						int num4 = 0;
						int length2 = array2.Length;
						if (length2 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (num4 < length2)
						{
							int index2 = num4;
							num4++;
							int[] array8 = array3;
							int num5 = array8[RuntimeServices.NormalizeArrayIndex(array8, index2)];
							if (num5 >= 0)
							{
								array7[RuntimeServices.NormalizeArrayIndex(array7, num5)] = array4[RuntimeServices.NormalizeArrayIndex(array4, index2)];
							}
						}
						try
						{
							MerlinMaster merlinMaster = masterLoadMethodEntry.createInst();
							if (merlinMaster == null)
							{
								throw new AssertionFailedException("mobj != null");
							}
							masterLoadMethodEntry.setStringValues(merlinMaster, array7);
							masterLoadMethodEntry.addMst(merlinMaster);
						}
						catch (Exception ex)
						{
							WriteLineToConsole(new StringBuilder("master exception: ").Append(ex).Append("\n").ToString() + "vals:" + Builtins.join(array4, "/") + "\n" + ex.StackTrace);
						}
					}
					WriteLineToConsole(new StringBuilder("MerlinMaster: read ").Append(masterName).Append(" ").Append((object)num)
						.Append(" rows")
						.ToString());
				}
				finally
				{
					if (disposable2 != null)
					{
						disposable2.Dispose();
						disposable2 = null;
					}
				}
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
		}
		catch (Exception ex2)
		{
			WriteLineToConsole(new StringBuilder("MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(": e=").Append(ex2)
				.Append("\n")
				.ToString() + ex2.StackTrace);
		}
		WriteLineToConsole(new StringBuilder("end of MerlinMaster.LoadMasterFromBytes ").Append(masterName).Append(" bytes:").Append((object)(bytes?.Length ?? (-1)))
			.ToString());
	}

	private static string CheckDateTimeFormat(string dateString)
	{
		object result;
		if (dateString.IndexOf("/") >= 0)
		{
			result = null;
		}
		else
		{
			double result2 = default(double);
			result = (double.TryParse(dateString, out result2) ? DateTime.FromOADate(result2).ToString() : null);
		}
		return (string)result;
	}

	private static void WriteLineToConsole(string str)
	{
	}

	private static bool IsEmpty(Boo.Lang.List<string> values)
	{
		int result;
		bool flag;
		if (values == null || ((ICollection)values).Count == 0)
		{
			result = 1;
		}
		else
		{
			IEnumerator<string> enumerator = values.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (string.IsNullOrEmpty(current))
					{
						continue;
					}
					flag = false;
					goto IL_0056;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = 1;
		}
		goto IL_0057;
		IL_0057:
		return (byte)result != 0;
		IL_0056:
		result = (flag ? 1 : 0);
		goto IL_0057;
	}

	public virtual string ToDebugModeString()
	{
		return new StringBuilder().Append(this).ToString();
	}

	private static Dictionary<string, MasterLoadMethodEntry> InitLoadMethodTbl()
	{
		Dictionary<string, MasterLoadMethodEntry> dictionary = new Dictionary<string, MasterLoadMethodEntry>();
		MasterLoadMethodEntry masterLoadMethodEntry2 = (dictionary["MAbnormalStateParameters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAbnormalStateParameters);
		masterLoadMethodEntry2.unload = delegate
		{
			MAbnormalStateParameters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable71_0024197_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___00245.Adapt(() => new MAbnormalStateParameters());
		masterLoadMethodEntry2.keyNameList = () => MAbnormalStateParameters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAbnormalStateParameters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAbnormalStateParameters.AddMst(m as MAbnormalStateParameters);
		};
		masterLoadMethodEntry2 = (dictionary["MAbnormalStates"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAbnormalStates);
		masterLoadMethodEntry2.unload = delegate
		{
			MAbnormalStates.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable72_0024198_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___00246.Adapt(() => new MAbnormalStates());
		masterLoadMethodEntry2.keyNameList = () => MAbnormalStates.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAbnormalStates).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAbnormalStates.AddMst(m as MAbnormalStates);
		};
		masterLoadMethodEntry2 = (dictionary["MAppendixGachas"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAppendixGachas);
		masterLoadMethodEntry2.unload = delegate
		{
			MAppendixGachas.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable73_0024199_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___00247.Adapt(() => new MAppendixGachas());
		masterLoadMethodEntry2.keyNameList = () => MAppendixGachas.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAppendixGachas).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAppendixGachas.AddMst(m as MAppendixGachas);
		};
		masterLoadMethodEntry2 = (dictionary["MAreaGroups"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAreaGroups);
		masterLoadMethodEntry2.unload = delegate
		{
			MAreaGroups.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable74_0024200_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___00248.Adapt(() => new MAreaGroups());
		masterLoadMethodEntry2.keyNameList = () => MAreaGroups.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAreaGroups).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAreaGroups.AddMst(m as MAreaGroups);
		};
		masterLoadMethodEntry2 = (dictionary["MAreaTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAreaTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MAreaTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable75_0024201_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___00249.Adapt(() => new MAreaTypes());
		masterLoadMethodEntry2.keyNameList = () => MAreaTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAreaTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAreaTypes.AddMst(m as MAreaTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MAreas"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAreas);
		masterLoadMethodEntry2.unload = delegate
		{
			MAreas.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable76_0024202_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002410.Adapt(() => new MAreas());
		masterLoadMethodEntry2.keyNameList = () => MAreas.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAreas).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAreas.AddMst(m as MAreas);
		};
		masterLoadMethodEntry2 = (dictionary["MAutoFlowPoint"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MAutoFlowPoint);
		masterLoadMethodEntry2.unload = delegate
		{
			MAutoFlowPoint.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable77_0024203_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002411.Adapt(() => new MAutoFlowPoint());
		masterLoadMethodEntry2.keyNameList = () => MAutoFlowPoint.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MAutoFlowPoint).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MAutoFlowPoint.AddMst(m as MAutoFlowPoint);
		};
		masterLoadMethodEntry2 = (dictionary["MBgm"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MBgm);
		masterLoadMethodEntry2.unload = delegate
		{
			MBgm.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable78_0024204_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002412.Adapt(() => new MBgm());
		masterLoadMethodEntry2.keyNameList = () => MBgm.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MBgm).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MBgm.AddMst(m as MBgm);
		};
		masterLoadMethodEntry2 = (dictionary["MBreederRanks"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MBreederRanks);
		masterLoadMethodEntry2.unload = delegate
		{
			MBreederRanks.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable79_0024205_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002413.Adapt(() => new MBreederRanks());
		masterLoadMethodEntry2.keyNameList = () => MBreederRanks.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MBreederRanks).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MBreederRanks.AddMst(m as MBreederRanks);
		};
		masterLoadMethodEntry2 = (dictionary["MCampaignSegmentTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCampaignSegmentTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MCampaignSegmentTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable80_0024206_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002414.Adapt(() => new MCampaignSegmentTypes());
		masterLoadMethodEntry2.keyNameList = () => MCampaignSegmentTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCampaignSegmentTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCampaignSegmentTypes.AddMst(m as MCampaignSegmentTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MCampaignTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCampaignTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MCampaignTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable81_0024207_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002415.Adapt(() => new MCampaignTypes());
		masterLoadMethodEntry2.keyNameList = () => MCampaignTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCampaignTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCampaignTypes.AddMst(m as MCampaignTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MCampaigns"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCampaigns);
		masterLoadMethodEntry2.unload = delegate
		{
			MCampaigns.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable82_0024208_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002416.Adapt(() => new MCampaigns());
		masterLoadMethodEntry2.keyNameList = () => MCampaigns.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCampaigns).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCampaigns.AddMst(m as MCampaigns);
		};
		masterLoadMethodEntry2 = (dictionary["MChainSkillEffects"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChainSkillEffects);
		masterLoadMethodEntry2.unload = delegate
		{
			MChainSkillEffects.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable83_0024209_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002417.Adapt(() => new MChainSkillEffects());
		masterLoadMethodEntry2.keyNameList = () => MChainSkillEffects.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChainSkillEffects).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChainSkillEffects.AddMst(m as MChainSkillEffects);
		};
		masterLoadMethodEntry2 = (dictionary["MChainSkills"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChainSkills);
		masterLoadMethodEntry2.unload = delegate
		{
			MChainSkills.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable84_0024210_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002418.Adapt(() => new MChainSkills());
		masterLoadMethodEntry2.keyNameList = () => MChainSkills.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChainSkills).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChainSkills.AddMst(m as MChainSkills);
		};
		masterLoadMethodEntry2 = (dictionary["MChallengeQuestScheduleDetails"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChallengeQuestScheduleDetails);
		masterLoadMethodEntry2.unload = delegate
		{
			MChallengeQuestScheduleDetails.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable85_0024211_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002419.Adapt(() => new MChallengeQuestScheduleDetails());
		masterLoadMethodEntry2.keyNameList = () => MChallengeQuestScheduleDetails.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChallengeQuestScheduleDetails).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChallengeQuestScheduleDetails.AddMst(m as MChallengeQuestScheduleDetails);
		};
		masterLoadMethodEntry2 = (dictionary["MChallengeQuestSchedules"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChallengeQuestSchedules);
		masterLoadMethodEntry2.unload = delegate
		{
			MChallengeQuestSchedules.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable86_0024212_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002420.Adapt(() => new MChallengeQuestSchedules());
		masterLoadMethodEntry2.keyNameList = () => MChallengeQuestSchedules.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChallengeQuestSchedules).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChallengeQuestSchedules.AddMst(m as MChallengeQuestSchedules);
		};
		masterLoadMethodEntry2 = (dictionary["MChangeDeckMains"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChangeDeckMains);
		masterLoadMethodEntry2.unload = delegate
		{
			MChangeDeckMains.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable87_0024213_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002421.Adapt(() => new MChangeDeckMains());
		masterLoadMethodEntry2.keyNameList = () => MChangeDeckMains.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChangeDeckMains).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChangeDeckMains.AddMst(m as MChangeDeckMains);
		};
		masterLoadMethodEntry2 = (dictionary["MChangeDeckSupports"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChangeDeckSupports);
		masterLoadMethodEntry2.unload = delegate
		{
			MChangeDeckSupports.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable88_0024214_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002422.Adapt(() => new MChangeDeckSupports());
		masterLoadMethodEntry2.keyNameList = () => MChangeDeckSupports.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChangeDeckSupports).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChangeDeckSupports.AddMst(m as MChangeDeckSupports);
		};
		masterLoadMethodEntry2 = (dictionary["MChangePoppetDecks"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MChangePoppetDecks);
		masterLoadMethodEntry2.unload = delegate
		{
			MChangePoppetDecks.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable89_0024215_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002423.Adapt(() => new MChangePoppetDecks());
		masterLoadMethodEntry2.keyNameList = () => MChangePoppetDecks.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MChangePoppetDecks).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MChangePoppetDecks.AddMst(m as MChangePoppetDecks);
		};
		masterLoadMethodEntry2 = (dictionary["MCharacterActionTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCharacterActionTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MCharacterActionTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable90_0024216_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002424.Adapt(() => new MCharacterActionTypes());
		masterLoadMethodEntry2.keyNameList = () => MCharacterActionTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCharacterActionTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCharacterActionTypes.AddMst(m as MCharacterActionTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MCharacteristics"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCharacteristics);
		masterLoadMethodEntry2.unload = delegate
		{
			MCharacteristics.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable91_0024217_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002425.Adapt(() => new MCharacteristics());
		masterLoadMethodEntry2.keyNameList = () => MCharacteristics.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCharacteristics).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCharacteristics.AddMst(m as MCharacteristics);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumEventRankingPointNormaRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumEventRankingPointNormaRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumEventRankingPointNormaRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable92_0024218_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002426.Adapt(() => new MColosseumEventRankingPointNormaRewards());
		masterLoadMethodEntry2.keyNameList = () => MColosseumEventRankingPointNormaRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumEventRankingPointNormaRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumEventRankingPointNormaRewards.AddMst(m as MColosseumEventRankingPointNormaRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumEventRankingRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumEventRankingRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumEventRankingRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable93_0024219_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002427.Adapt(() => new MColosseumEventRankingRewards());
		masterLoadMethodEntry2.keyNameList = () => MColosseumEventRankingRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumEventRankingRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumEventRankingRewards.AddMst(m as MColosseumEventRankingRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumEventRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumEventRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumEventRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable94_0024220_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002428.Adapt(() => new MColosseumEventRewards());
		masterLoadMethodEntry2.keyNameList = () => MColosseumEventRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumEventRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumEventRewards.AddMst(m as MColosseumEventRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumEvents"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumEvents);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumEvents.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable95_0024221_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002429.Adapt(() => new MColosseumEvents());
		masterLoadMethodEntry2.keyNameList = () => MColosseumEvents.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumEvents).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumEvents.AddMst(m as MColosseumEvents);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumNpcOrganizes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumNpcOrganizes);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumNpcOrganizes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable96_0024222_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002430.Adapt(() => new MColosseumNpcOrganizes());
		masterLoadMethodEntry2.keyNameList = () => MColosseumNpcOrganizes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumNpcOrganizes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumNpcOrganizes.AddMst(m as MColosseumNpcOrganizes);
		};
		masterLoadMethodEntry2 = (dictionary["MColosseumNpcs"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MColosseumNpcs);
		masterLoadMethodEntry2.unload = delegate
		{
			MColosseumNpcs.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable97_0024223_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002431.Adapt(() => new MColosseumNpcs());
		masterLoadMethodEntry2.keyNameList = () => MColosseumNpcs.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MColosseumNpcs).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MColosseumNpcs.AddMst(m as MColosseumNpcs);
		};
		masterLoadMethodEntry2 = (dictionary["MComboBonus"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MComboBonus);
		masterLoadMethodEntry2.unload = delegate
		{
			MComboBonus.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable98_0024224_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002432.Adapt(() => new MComboBonus());
		masterLoadMethodEntry2.keyNameList = () => MComboBonus.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MComboBonus).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MComboBonus.AddMst(m as MComboBonus);
		};
		masterLoadMethodEntry2 = (dictionary["MComparisonOperator"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MComparisonOperator);
		masterLoadMethodEntry2.unload = delegate
		{
			MComparisonOperator.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable99_0024225_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002433.Adapt(() => new MComparisonOperator());
		masterLoadMethodEntry2.keyNameList = () => MComparisonOperator.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MComparisonOperator).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MComparisonOperator.AddMst(m as MComparisonOperator);
		};
		masterLoadMethodEntry2 = (dictionary["MCoverSkills"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCoverSkills);
		masterLoadMethodEntry2.unload = delegate
		{
			MCoverSkills.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable100_0024226_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002434.Adapt(() => new MCoverSkills());
		masterLoadMethodEntry2.keyNameList = () => MCoverSkills.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCoverSkills).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCoverSkills.AddMst(m as MCoverSkills);
		};
		masterLoadMethodEntry2 = (dictionary["MCycleSchedules"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MCycleSchedules);
		masterLoadMethodEntry2.unload = delegate
		{
			MCycleSchedules.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable101_0024227_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002435.Adapt(() => new MCycleSchedules());
		masterLoadMethodEntry2.keyNameList = () => MCycleSchedules.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MCycleSchedules).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MCycleSchedules.AddMst(m as MCycleSchedules);
		};
		masterLoadMethodEntry2 = (dictionary["MDailyPassiveSkillSchedules"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MDailyPassiveSkillSchedules);
		masterLoadMethodEntry2.unload = delegate
		{
			MDailyPassiveSkillSchedules.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable102_0024228_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002436.Adapt(() => new MDailyPassiveSkillSchedules());
		masterLoadMethodEntry2.keyNameList = () => MDailyPassiveSkillSchedules.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MDailyPassiveSkillSchedules).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MDailyPassiveSkillSchedules.AddMst(m as MDailyPassiveSkillSchedules);
		};
		masterLoadMethodEntry2 = (dictionary["MDebugRaidBossData"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MDebugRaidBossData);
		masterLoadMethodEntry2.unload = delegate
		{
			MDebugRaidBossData.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable103_0024229_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002437.Adapt(() => new MDebugRaidBossData());
		masterLoadMethodEntry2.keyNameList = () => MDebugRaidBossData.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MDebugRaidBossData).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MDebugRaidBossData.AddMst(m as MDebugRaidBossData);
		};
		masterLoadMethodEntry2 = (dictionary["MElementCorrelations"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MElementCorrelations);
		masterLoadMethodEntry2.unload = delegate
		{
			MElementCorrelations.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable104_0024230_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002438.Adapt(() => new MElementCorrelations());
		masterLoadMethodEntry2.keyNameList = () => MElementCorrelations.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MElementCorrelations).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MElementCorrelations.AddMst(m as MElementCorrelations);
		};
		masterLoadMethodEntry2 = (dictionary["MElements"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MElements);
		masterLoadMethodEntry2.unload = delegate
		{
			MElements.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable105_0024231_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002439.Adapt(() => new MElements());
		masterLoadMethodEntry2.keyNameList = () => MElements.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MElements).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MElements.AddMst(m as MElements);
		};
		masterLoadMethodEntry2 = (dictionary["MEventQuestRankingRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MEventQuestRankingRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MEventQuestRankingRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable106_0024232_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002440.Adapt(() => new MEventQuestRankingRewards());
		masterLoadMethodEntry2.keyNameList = () => MEventQuestRankingRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MEventQuestRankingRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MEventQuestRankingRewards.AddMst(m as MEventQuestRankingRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MEventQuestRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MEventQuestRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MEventQuestRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable107_0024233_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002441.Adapt(() => new MEventQuestRewards());
		masterLoadMethodEntry2.keyNameList = () => MEventQuestRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MEventQuestRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MEventQuestRewards.AddMst(m as MEventQuestRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MEvolutionInformations"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MEvolutionInformations);
		masterLoadMethodEntry2.unload = delegate
		{
			MEvolutionInformations.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable108_0024234_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002442.Adapt(() => new MEvolutionInformations());
		masterLoadMethodEntry2.keyNameList = () => MEvolutionInformations.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MEvolutionInformations).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MEvolutionInformations.AddMst(m as MEvolutionInformations);
		};
		masterLoadMethodEntry2 = (dictionary["MFixedEmissionGachas"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MFixedEmissionGachas);
		masterLoadMethodEntry2.unload = delegate
		{
			MFixedEmissionGachas.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable109_0024235_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002443.Adapt(() => new MFixedEmissionGachas());
		masterLoadMethodEntry2.keyNameList = () => MFixedEmissionGachas.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MFixedEmissionGachas).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MFixedEmissionGachas.AddMst(m as MFixedEmissionGachas);
		};
		masterLoadMethodEntry2 = (dictionary["MFlags"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MFlags);
		masterLoadMethodEntry2.unload = delegate
		{
			MFlags.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable110_0024236_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002444.Adapt(() => new MFlags());
		masterLoadMethodEntry2.keyNameList = () => MFlags.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MFlags).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MFlags.AddMst(m as MFlags);
		};
		masterLoadMethodEntry2 = (dictionary["MGachaBoxes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGachaBoxes);
		masterLoadMethodEntry2.unload = delegate
		{
			MGachaBoxes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable111_0024237_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002445.Adapt(() => new MGachaBoxes());
		masterLoadMethodEntry2.keyNameList = () => MGachaBoxes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGachaBoxes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGachaBoxes.AddMst(m as MGachaBoxes);
		};
		masterLoadMethodEntry2 = (dictionary["MGachaRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGachaRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MGachaRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable112_0024238_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002446.Adapt(() => new MGachaRewards());
		masterLoadMethodEntry2.keyNameList = () => MGachaRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGachaRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGachaRewards.AddMst(m as MGachaRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MGachaTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGachaTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MGachaTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable113_0024239_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002447.Adapt(() => new MGachaTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MGachaTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGachaTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGachaTypeValues.AddMst(m as MGachaTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MGachaTypesForClient"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGachaTypesForClient);
		masterLoadMethodEntry2.unload = delegate
		{
			MGachaTypesForClient.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable114_0024240_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002448.Adapt(() => new MGachaTypesForClient());
		masterLoadMethodEntry2.keyNameList = () => MGachaTypesForClient.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGachaTypesForClient).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGachaTypesForClient.AddMst(m as MGachaTypesForClient);
		};
		masterLoadMethodEntry2 = (dictionary["MGachas"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGachas);
		masterLoadMethodEntry2.unload = delegate
		{
			MGachas.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable115_0024241_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002449.Adapt(() => new MGachas());
		masterLoadMethodEntry2.keyNameList = () => MGachas.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGachas).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGachas.AddMst(m as MGachas);
		};
		masterLoadMethodEntry2 = (dictionary["MGameObjectNames"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGameObjectNames);
		masterLoadMethodEntry2.unload = delegate
		{
			MGameObjectNames.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable116_0024242_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002450.Adapt(() => new MGameObjectNames());
		masterLoadMethodEntry2.keyNameList = () => MGameObjectNames.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGameObjectNames).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGameObjectNames.AddMst(m as MGameObjectNames);
		};
		masterLoadMethodEntry2 = (dictionary["MGameParameters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGameParameters);
		masterLoadMethodEntry2.unload = delegate
		{
			MGameParameters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable117_0024243_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002451.Adapt(() => new MGameParameters());
		masterLoadMethodEntry2.keyNameList = () => MGameParameters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGameParameters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGameParameters.AddMst(m as MGameParameters);
		};
		masterLoadMethodEntry2 = (dictionary["MGenders"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MGenders);
		masterLoadMethodEntry2.unload = delegate
		{
			MGenders.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable118_0024244_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002452.Adapt(() => new MGenders());
		masterLoadMethodEntry2.keyNameList = () => MGenders.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MGenders).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MGenders.AddMst(m as MGenders);
		};
		masterLoadMethodEntry2 = (dictionary["MHonors"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MHonors);
		masterLoadMethodEntry2.unload = delegate
		{
			MHonors.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable119_0024245_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002453.Adapt(() => new MHonors());
		masterLoadMethodEntry2.keyNameList = () => MHonors.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MHonors).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MHonors.AddMst(m as MHonors);
		};
		masterLoadMethodEntry2 = (dictionary["MInAppProducts"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MInAppProducts);
		masterLoadMethodEntry2.unload = delegate
		{
			MInAppProducts.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable120_0024246_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002454.Adapt(() => new MInAppProducts());
		masterLoadMethodEntry2.keyNameList = () => MInAppProducts.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MInAppProducts).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MInAppProducts.AddMst(m as MInAppProducts);
		};
		masterLoadMethodEntry2 = (dictionary["MInviteRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MInviteRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MInviteRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable121_0024247_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002455.Adapt(() => new MInviteRewards());
		masterLoadMethodEntry2.keyNameList = () => MInviteRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MInviteRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MInviteRewards.AddMst(m as MInviteRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MItemGroupChilds"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MItemGroupChilds);
		masterLoadMethodEntry2.unload = delegate
		{
			MItemGroupChilds.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable122_0024248_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002456.Adapt(() => new MItemGroupChilds());
		masterLoadMethodEntry2.keyNameList = () => MItemGroupChilds.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MItemGroupChilds).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MItemGroupChilds.AddMst(m as MItemGroupChilds);
		};
		masterLoadMethodEntry2 = (dictionary["MItemGroups"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MItemGroups);
		masterLoadMethodEntry2.unload = delegate
		{
			MItemGroups.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable123_0024249_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002457.Adapt(() => new MItemGroups());
		masterLoadMethodEntry2.keyNameList = () => MItemGroups.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MItemGroups).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MItemGroups.AddMst(m as MItemGroups);
		};
		masterLoadMethodEntry2 = (dictionary["MItemTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MItemTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MItemTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable124_0024250_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002458.Adapt(() => new MItemTypes());
		masterLoadMethodEntry2.keyNameList = () => MItemTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MItemTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MItemTypes.AddMst(m as MItemTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MKeyItems"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MKeyItems);
		masterLoadMethodEntry2.unload = delegate
		{
			MKeyItems.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable125_0024251_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002459.Adapt(() => new MKeyItems());
		masterLoadMethodEntry2.keyNameList = () => MKeyItems.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MKeyItems).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MKeyItems.AddMst(m as MKeyItems);
		};
		masterLoadMethodEntry2 = (dictionary["MKusamushi"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MKusamushi);
		masterLoadMethodEntry2.unload = delegate
		{
			MKusamushi.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable126_0024252_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002460.Adapt(() => new MKusamushi());
		masterLoadMethodEntry2.keyNameList = () => MKusamushi.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MKusamushi).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MKusamushi.AddMst(m as MKusamushi);
		};
		masterLoadMethodEntry2 = (dictionary["MLevelUpTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLevelUpTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MLevelUpTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable127_0024253_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002461.Adapt(() => new MLevelUpTypes());
		masterLoadMethodEntry2.keyNameList = () => MLevelUpTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLevelUpTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLevelUpTypes.AddMst(m as MLevelUpTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MLoginBonusItems"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLoginBonusItems);
		masterLoadMethodEntry2.unload = delegate
		{
			MLoginBonusItems.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable128_0024254_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002462.Adapt(() => new MLoginBonusItems());
		masterLoadMethodEntry2.keyNameList = () => MLoginBonusItems.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLoginBonusItems).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLoginBonusItems.AddMst(m as MLoginBonusItems);
		};
		masterLoadMethodEntry2 = (dictionary["MLoginBonusTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLoginBonusTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MLoginBonusTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable129_0024255_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002463.Adapt(() => new MLoginBonusTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MLoginBonusTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLoginBonusTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLoginBonusTypeValues.AddMst(m as MLoginBonusTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MLoginBonuses"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLoginBonuses);
		masterLoadMethodEntry2.unload = delegate
		{
			MLoginBonuses.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable130_0024256_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002464.Adapt(() => new MLoginBonuses());
		masterLoadMethodEntry2.keyNameList = () => MLoginBonuses.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLoginBonuses).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLoginBonuses.AddMst(m as MLoginBonuses);
		};
		masterLoadMethodEntry2 = (dictionary["MLoginRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLoginRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MLoginRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable131_0024257_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002465.Adapt(() => new MLoginRewards());
		masterLoadMethodEntry2.keyNameList = () => MLoginRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLoginRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLoginRewards.AddMst(m as MLoginRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MLots"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MLots);
		masterLoadMethodEntry2.unload = delegate
		{
			MLots.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable132_0024258_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002466.Adapt(() => new MLots());
		masterLoadMethodEntry2.keyNameList = () => MLots.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MLots).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MLots.AddMst(m as MLots);
		};
		masterLoadMethodEntry2 = (dictionary["MMapLinkDir"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMapLinkDir);
		masterLoadMethodEntry2.unload = delegate
		{
			MMapLinkDir.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable133_0024259_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002467.Adapt(() => new MMapLinkDir());
		masterLoadMethodEntry2.keyNameList = () => MMapLinkDir.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMapLinkDir).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMapLinkDir.AddMst(m as MMapLinkDir);
		};
		masterLoadMethodEntry2 = (dictionary["MMarketTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMarketTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MMarketTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable134_0024260_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002468.Adapt(() => new MMarketTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MMarketTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMarketTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMarketTypeValues.AddMst(m as MMarketTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MMasterTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMasterTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MMasterTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable135_0024261_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002469.Adapt(() => new MMasterTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MMasterTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMasterTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMasterTypeValues.AddMst(m as MMasterTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MMissionConditionTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMissionConditionTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MMissionConditionTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable136_0024262_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002470.Adapt(() => new MMissionConditionTypes());
		masterLoadMethodEntry2.keyNameList = () => MMissionConditionTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMissionConditionTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMissionConditionTypes.AddMst(m as MMissionConditionTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MMissionTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMissionTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MMissionTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable137_0024263_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002471.Adapt(() => new MMissionTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MMissionTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMissionTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMissionTypeValues.AddMst(m as MMissionTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MMonsters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MMonsters);
		masterLoadMethodEntry2.unload = delegate
		{
			MMonsters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable138_0024264_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002472.Adapt(() => new MMonsters());
		masterLoadMethodEntry2.keyNameList = () => MMonsters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MMonsters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MMonsters.AddMst(m as MMonsters);
		};
		masterLoadMethodEntry2 = (dictionary["MNewFeatureDetails"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNewFeatureDetails);
		masterLoadMethodEntry2.unload = delegate
		{
			MNewFeatureDetails.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable139_0024265_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002473.Adapt(() => new MNewFeatureDetails());
		masterLoadMethodEntry2.keyNameList = () => MNewFeatureDetails.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNewFeatureDetails).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNewFeatureDetails.AddMst(m as MNewFeatureDetails);
		};
		masterLoadMethodEntry2 = (dictionary["MNormalAttackRange"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNormalAttackRange);
		masterLoadMethodEntry2.unload = delegate
		{
			MNormalAttackRange.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable140_0024266_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002474.Adapt(() => new MNormalAttackRange());
		masterLoadMethodEntry2.keyNameList = () => MNormalAttackRange.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNormalAttackRange).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNormalAttackRange.AddMst(m as MNormalAttackRange);
		};
		masterLoadMethodEntry2 = (dictionary["MNpcTalkIcons"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNpcTalkIcons);
		masterLoadMethodEntry2.unload = delegate
		{
			MNpcTalkIcons.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable141_0024267_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002475.Adapt(() => new MNpcTalkIcons());
		masterLoadMethodEntry2.keyNameList = () => MNpcTalkIcons.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNpcTalkIcons).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNpcTalkIcons.AddMst(m as MNpcTalkIcons);
		};
		masterLoadMethodEntry2 = (dictionary["MNpcTalkTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNpcTalkTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MNpcTalkTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable142_0024268_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002476.Adapt(() => new MNpcTalkTypes());
		masterLoadMethodEntry2.keyNameList = () => MNpcTalkTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNpcTalkTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNpcTalkTypes.AddMst(m as MNpcTalkTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MNpcTalks"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNpcTalks);
		masterLoadMethodEntry2.unload = delegate
		{
			MNpcTalks.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable143_0024269_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002477.Adapt(() => new MNpcTalks());
		masterLoadMethodEntry2.keyNameList = () => MNpcTalks.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNpcTalks).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNpcTalks.AddMst(m as MNpcTalks);
		};
		masterLoadMethodEntry2 = (dictionary["MNpcTexts"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNpcTexts);
		masterLoadMethodEntry2.unload = delegate
		{
			MNpcTexts.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable144_0024270_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002478.Adapt(() => new MNpcTexts());
		masterLoadMethodEntry2.keyNameList = () => MNpcTexts.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNpcTexts).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNpcTexts.AddMst(m as MNpcTexts);
		};
		masterLoadMethodEntry2 = (dictionary["MNpcs"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MNpcs);
		masterLoadMethodEntry2.unload = delegate
		{
			MNpcs.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable145_0024271_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002479.Adapt(() => new MNpcs());
		masterLoadMethodEntry2.keyNameList = () => MNpcs.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MNpcs).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MNpcs.AddMst(m as MNpcs);
		};
		masterLoadMethodEntry2 = (dictionary["MPackedSceneMap"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPackedSceneMap);
		masterLoadMethodEntry2.unload = delegate
		{
			MPackedSceneMap.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable146_0024272_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002480.Adapt(() => new MPackedSceneMap());
		masterLoadMethodEntry2.keyNameList = () => MPackedSceneMap.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPackedSceneMap).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPackedSceneMap.AddMst(m as MPackedSceneMap);
		};
		masterLoadMethodEntry2 = (dictionary["MParameterCorrects"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MParameterCorrects);
		masterLoadMethodEntry2.unload = delegate
		{
			MParameterCorrects.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable147_0024273_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002481.Adapt(() => new MParameterCorrects());
		masterLoadMethodEntry2.keyNameList = () => MParameterCorrects.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MParameterCorrects).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MParameterCorrects.AddMst(m as MParameterCorrects);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerDeckMains"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerDeckMains);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerDeckMains.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable148_0024274_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002482.Adapt(() => new MPlayerDeckMains());
		masterLoadMethodEntry2.keyNameList = () => MPlayerDeckMains.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerDeckMains).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerDeckMains.AddMst(m as MPlayerDeckMains);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerDeckSupports"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerDeckSupports);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerDeckSupports.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable149_0024275_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002483.Adapt(() => new MPlayerDeckSupports());
		masterLoadMethodEntry2.keyNameList = () => MPlayerDeckSupports.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerDeckSupports).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerDeckSupports.AddMst(m as MPlayerDeckSupports);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerGroups"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerGroups);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerGroups.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable150_0024276_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002484.Adapt(() => new MPlayerGroups());
		masterLoadMethodEntry2.keyNameList = () => MPlayerGroups.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerGroups).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerGroups.AddMst(m as MPlayerGroups);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerParameters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerParameters);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerParameters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable151_0024277_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002485.Adapt(() => new MPlayerParameters());
		masterLoadMethodEntry2.keyNameList = () => MPlayerParameters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerParameters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerParameters.AddMst(m as MPlayerParameters);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerPoppetDecks"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerPoppetDecks);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerPoppetDecks.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable152_0024278_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002486.Adapt(() => new MPlayerPoppetDecks());
		masterLoadMethodEntry2.keyNameList = () => MPlayerPoppetDecks.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerPoppetDecks).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerPoppetDecks.AddMst(m as MPlayerPoppetDecks);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayerRaces"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayerRaces);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayerRaces.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable153_0024279_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002487.Adapt(() => new MPlayerRaces());
		masterLoadMethodEntry2.keyNameList = () => MPlayerRaces.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayerRaces).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayerRaces.AddMst(m as MPlayerRaces);
		};
		masterLoadMethodEntry2 = (dictionary["MPlayers"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlayers);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlayers.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable154_0024280_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002488.Adapt(() => new MPlayers());
		masterLoadMethodEntry2.keyNameList = () => MPlayers.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlayers).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlayers.AddMst(m as MPlayers);
		};
		masterLoadMethodEntry2 = (dictionary["MPlusBonus"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPlusBonus);
		masterLoadMethodEntry2.unload = delegate
		{
			MPlusBonus.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable155_0024281_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002489.Adapt(() => new MPlusBonus());
		masterLoadMethodEntry2.keyNameList = () => MPlusBonus.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPlusBonus).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPlusBonus.AddMst(m as MPlusBonus);
		};
		masterLoadMethodEntry2 = (dictionary["MPoints"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPoints);
		masterLoadMethodEntry2.unload = delegate
		{
			MPoints.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable156_0024282_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002490.Adapt(() => new MPoints());
		masterLoadMethodEntry2.keyNameList = () => MPoints.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPoints).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPoints.AddMst(m as MPoints);
		};
		masterLoadMethodEntry2 = (dictionary["MPoppetChatTimings"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPoppetChatTimings);
		masterLoadMethodEntry2.unload = delegate
		{
			MPoppetChatTimings.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable157_0024283_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002491.Adapt(() => new MPoppetChatTimings());
		masterLoadMethodEntry2.keyNameList = () => MPoppetChatTimings.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPoppetChatTimings).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPoppetChatTimings.AddMst(m as MPoppetChatTimings);
		};
		masterLoadMethodEntry2 = (dictionary["MPoppetChats"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPoppetChats);
		masterLoadMethodEntry2.unload = delegate
		{
			MPoppetChats.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable158_0024284_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002492.Adapt(() => new MPoppetChats());
		masterLoadMethodEntry2.keyNameList = () => MPoppetChats.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPoppetChats).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPoppetChats.AddMst(m as MPoppetChats);
		};
		masterLoadMethodEntry2 = (dictionary["MPoppetPersonalities"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPoppetPersonalities);
		masterLoadMethodEntry2.unload = delegate
		{
			MPoppetPersonalities.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable159_0024285_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002493.Adapt(() => new MPoppetPersonalities());
		masterLoadMethodEntry2.keyNameList = () => MPoppetPersonalities.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPoppetPersonalities).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPoppetPersonalities.AddMst(m as MPoppetPersonalities);
		};
		masterLoadMethodEntry2 = (dictionary["MPoppets"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPoppets);
		masterLoadMethodEntry2.unload = delegate
		{
			MPoppets.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable160_0024286_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002494.Adapt(() => new MPoppets());
		masterLoadMethodEntry2.keyNameList = () => MPoppets.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPoppets).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPoppets.AddMst(m as MPoppets);
		};
		masterLoadMethodEntry2 = (dictionary["MPresentTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MPresentTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MPresentTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable161_0024287_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002495.Adapt(() => new MPresentTypes());
		masterLoadMethodEntry2.keyNameList = () => MPresentTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MPresentTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MPresentTypes.AddMst(m as MPresentTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MProductSalesTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MProductSalesTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MProductSalesTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable162_0024288_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002496.Adapt(() => new MProductSalesTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MProductSalesTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MProductSalesTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MProductSalesTypeValues.AddMst(m as MProductSalesTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestClearTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestClearTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestClearTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable163_0024289_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002497.Adapt(() => new MQuestClearTypes());
		masterLoadMethodEntry2.keyNameList = () => MQuestClearTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestClearTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestClearTypes.AddMst(m as MQuestClearTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestClears"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestClears);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestClears.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable164_0024290_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002498.Adapt(() => new MQuestClears());
		masterLoadMethodEntry2.keyNameList = () => MQuestClears.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestClears).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestClears.AddMst(m as MQuestClears);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestDrops"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestDrops);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestDrops.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable165_0024291_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___002499.Adapt(() => new MQuestDrops());
		masterLoadMethodEntry2.keyNameList = () => MQuestDrops.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestDrops).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestDrops.AddMst(m as MQuestDrops);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestFirstRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestFirstRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestFirstRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable166_0024292_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024100.Adapt(() => new MQuestFirstRewards());
		masterLoadMethodEntry2.keyNameList = () => MQuestFirstRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestFirstRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestFirstRewards.AddMst(m as MQuestFirstRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestMissions"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestMissions);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestMissions.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable167_0024293_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024101.Adapt(() => new MQuestMissions());
		masterLoadMethodEntry2.keyNameList = () => MQuestMissions.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestMissions).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestMissions.AddMst(m as MQuestMissions);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestMonsters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestMonsters);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestMonsters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable168_0024294_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024102.Adapt(() => new MQuestMonsters());
		masterLoadMethodEntry2.keyNameList = () => MQuestMonsters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestMonsters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestMonsters.AddMst(m as MQuestMonsters);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable169_0024295_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024103.Adapt(() => new MQuestRewards());
		masterLoadMethodEntry2.keyNameList = () => MQuestRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestRewards.AddMst(m as MQuestRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestTickets"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestTickets);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestTickets.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable170_0024296_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024104.Adapt(() => new MQuestTickets());
		masterLoadMethodEntry2.keyNameList = () => MQuestTickets.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestTickets).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestTickets.AddMst(m as MQuestTickets);
		};
		masterLoadMethodEntry2 = (dictionary["MQuestTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuestTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuestTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable171_0024297_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024105.Adapt(() => new MQuestTypes());
		masterLoadMethodEntry2.keyNameList = () => MQuestTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuestTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuestTypes.AddMst(m as MQuestTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MQuests"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MQuests);
		masterLoadMethodEntry2.unload = delegate
		{
			MQuests.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable172_0024298_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024106.Adapt(() => new MQuests());
		masterLoadMethodEntry2.keyNameList = () => MQuests.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MQuests).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MQuests.AddMst(m as MQuests);
		};
		masterLoadMethodEntry2 = (dictionary["MRaces"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaces);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaces.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable173_0024299_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024107.Adapt(() => new MRaces());
		masterLoadMethodEntry2.keyNameList = () => MRaces.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaces).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaces.AddMst(m as MRaces);
		};
		masterLoadMethodEntry2 = (dictionary["MRaidBattleRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaidBattleRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaidBattleRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable174_0024300_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024108.Adapt(() => new MRaidBattleRewards());
		masterLoadMethodEntry2.keyNameList = () => MRaidBattleRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaidBattleRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaidBattleRewards.AddMst(m as MRaidBattleRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MRaidBattles"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaidBattles);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaidBattles.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable175_0024301_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024109.Adapt(() => new MRaidBattles());
		masterLoadMethodEntry2.keyNameList = () => MRaidBattles.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaidBattles).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaidBattles.AddMst(m as MRaidBattles);
		};
		masterLoadMethodEntry2 = (dictionary["MRaidTutorialRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaidTutorialRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaidTutorialRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable176_0024302_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024110.Adapt(() => new MRaidTutorialRewards());
		masterLoadMethodEntry2.keyNameList = () => MRaidTutorialRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaidTutorialRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaidTutorialRewards.AddMst(m as MRaidTutorialRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MRaidWordTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaidWordTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaidWordTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable177_0024303_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024111.Adapt(() => new MRaidWordTypes());
		masterLoadMethodEntry2.keyNameList = () => MRaidWordTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaidWordTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaidWordTypes.AddMst(m as MRaidWordTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MRaidWords"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRaidWords);
		masterLoadMethodEntry2.unload = delegate
		{
			MRaidWords.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable178_0024304_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024112.Adapt(() => new MRaidWords());
		masterLoadMethodEntry2.keyNameList = () => MRaidWords.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRaidWords).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRaidWords.AddMst(m as MRaidWords);
		};
		masterLoadMethodEntry2 = (dictionary["MRankingRewardTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRankingRewardTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MRankingRewardTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable179_0024305_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024113.Adapt(() => new MRankingRewardTypes());
		masterLoadMethodEntry2.keyNameList = () => MRankingRewardTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRankingRewardTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRankingRewardTypes.AddMst(m as MRankingRewardTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MRankingRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRankingRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MRankingRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable180_0024306_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024114.Adapt(() => new MRankingRewards());
		masterLoadMethodEntry2.keyNameList = () => MRankingRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRankingRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRankingRewards.AddMst(m as MRankingRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MRares"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MRares);
		masterLoadMethodEntry2.unload = delegate
		{
			MRares.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable181_0024307_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024115.Adapt(() => new MRares());
		masterLoadMethodEntry2.keyNameList = () => MRares.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MRares).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MRares.AddMst(m as MRares);
		};
		masterLoadMethodEntry2 = (dictionary["MSaleGachaGroups"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSaleGachaGroups);
		masterLoadMethodEntry2.unload = delegate
		{
			MSaleGachaGroups.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable182_0024308_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024116.Adapt(() => new MSaleGachaGroups());
		masterLoadMethodEntry2.keyNameList = () => MSaleGachaGroups.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSaleGachaGroups).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSaleGachaGroups.AddMst(m as MSaleGachaGroups);
		};
		masterLoadMethodEntry2 = (dictionary["MSaleGachas"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSaleGachas);
		masterLoadMethodEntry2.unload = delegate
		{
			MSaleGachas.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable183_0024309_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024117.Adapt(() => new MSaleGachas());
		masterLoadMethodEntry2.keyNameList = () => MSaleGachas.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSaleGachas).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSaleGachas.AddMst(m as MSaleGachas);
		};
		masterLoadMethodEntry2 = (dictionary["MSaleTypeValues"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSaleTypeValues);
		masterLoadMethodEntry2.unload = delegate
		{
			MSaleTypeValues.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable184_0024310_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024118.Adapt(() => new MSaleTypeValues());
		masterLoadMethodEntry2.keyNameList = () => MSaleTypeValues.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSaleTypeValues).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSaleTypeValues.AddMst(m as MSaleTypeValues);
		};
		masterLoadMethodEntry2 = (dictionary["MSceneBgm"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSceneBgm);
		masterLoadMethodEntry2.unload = delegate
		{
			MSceneBgm.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable185_0024311_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024119.Adapt(() => new MSceneBgm());
		masterLoadMethodEntry2.keyNameList = () => MSceneBgm.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSceneBgm).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSceneBgm.AddMst(m as MSceneBgm);
		};
		masterLoadMethodEntry2 = (dictionary["MScenes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MScenes);
		masterLoadMethodEntry2.unload = delegate
		{
			MScenes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable186_0024312_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024120.Adapt(() => new MScenes());
		masterLoadMethodEntry2.keyNameList = () => MScenes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MScenes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MScenes.AddMst(m as MScenes);
		};
		masterLoadMethodEntry2 = (dictionary["MSe"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSe);
		masterLoadMethodEntry2.unload = delegate
		{
			MSe.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable187_0024313_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024121.Adapt(() => new MSe());
		masterLoadMethodEntry2.keyNameList = () => MSe.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSe).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSe.AddMst(m as MSe);
		};
		masterLoadMethodEntry2 = (dictionary["MSeTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSeTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MSeTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable188_0024314_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024122.Adapt(() => new MSeTypes());
		masterLoadMethodEntry2.keyNameList = () => MSeTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSeTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSeTypes.AddMst(m as MSeTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MSellTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSellTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MSellTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable189_0024315_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024123.Adapt(() => new MSellTypes());
		masterLoadMethodEntry2.keyNameList = () => MSellTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSellTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSellTypes.AddMst(m as MSellTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MSerialCampaigns"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSerialCampaigns);
		masterLoadMethodEntry2.unload = delegate
		{
			MSerialCampaigns.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable190_0024316_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024124.Adapt(() => new MSerialCampaigns());
		masterLoadMethodEntry2.keyNameList = () => MSerialCampaigns.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSerialCampaigns).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSerialCampaigns.AddMst(m as MSerialCampaigns);
		};
		masterLoadMethodEntry2 = (dictionary["MShopItems"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MShopItems);
		masterLoadMethodEntry2.unload = delegate
		{
			MShopItems.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable191_0024317_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024125.Adapt(() => new MShopItems());
		masterLoadMethodEntry2.keyNameList = () => MShopItems.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MShopItems).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MShopItems.AddMst(m as MShopItems);
		};
		masterLoadMethodEntry2 = (dictionary["MShopMessage"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MShopMessage);
		masterLoadMethodEntry2.unload = delegate
		{
			MShopMessage.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable192_0024318_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024126.Adapt(() => new MShopMessage());
		masterLoadMethodEntry2.keyNameList = () => MShopMessage.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MShopMessage).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MShopMessage.AddMst(m as MShopMessage);
		};
		masterLoadMethodEntry2 = (dictionary["MShopMessageTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MShopMessageTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MShopMessageTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable193_0024319_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024127.Adapt(() => new MShopMessageTypes());
		masterLoadMethodEntry2.keyNameList = () => MShopMessageTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MShopMessageTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MShopMessageTypes.AddMst(m as MShopMessageTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MShortcutChildIcons"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MShortcutChildIcons);
		masterLoadMethodEntry2.unload = delegate
		{
			MShortcutChildIcons.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable194_0024320_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024128.Adapt(() => new MShortcutChildIcons());
		masterLoadMethodEntry2.keyNameList = () => MShortcutChildIcons.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MShortcutChildIcons).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MShortcutChildIcons.AddMst(m as MShortcutChildIcons);
		};
		masterLoadMethodEntry2 = (dictionary["MShortcutIcons"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MShortcutIcons);
		masterLoadMethodEntry2.unload = delegate
		{
			MShortcutIcons.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable195_0024321_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024129.Adapt(() => new MShortcutIcons());
		masterLoadMethodEntry2.keyNameList = () => MShortcutIcons.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MShortcutIcons).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MShortcutIcons.AddMst(m as MShortcutIcons);
		};
		masterLoadMethodEntry2 = (dictionary["MSkillActionTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSkillActionTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MSkillActionTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable196_0024322_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024130.Adapt(() => new MSkillActionTypes());
		masterLoadMethodEntry2.keyNameList = () => MSkillActionTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSkillActionTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSkillActionTypes.AddMst(m as MSkillActionTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MSkillEffectTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MSkillEffectTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MSkillEffectTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable197_0024323_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024131.Adapt(() => new MSkillEffectTypes());
		masterLoadMethodEntry2.keyNameList = () => MSkillEffectTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MSkillEffectTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MSkillEffectTypes.AddMst(m as MSkillEffectTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MStageBattles"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStageBattles);
		masterLoadMethodEntry2.unload = delegate
		{
			MStageBattles.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable198_0024324_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024132.Adapt(() => new MStageBattles());
		masterLoadMethodEntry2.keyNameList = () => MStageBattles.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStageBattles).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStageBattles.AddMst(m as MStageBattles);
		};
		masterLoadMethodEntry2 = (dictionary["MStageMonsters"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStageMonsters);
		masterLoadMethodEntry2.unload = delegate
		{
			MStageMonsters.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable199_0024325_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024133.Adapt(() => new MStageMonsters());
		masterLoadMethodEntry2.keyNameList = () => MStageMonsters.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStageMonsters).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStageMonsters.AddMst(m as MStageMonsters);
		};
		masterLoadMethodEntry2 = (dictionary["MStages"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStages);
		masterLoadMethodEntry2.unload = delegate
		{
			MStages.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable200_0024326_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024134.Adapt(() => new MStages());
		masterLoadMethodEntry2.keyNameList = () => MStages.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStages).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStages.AddMst(m as MStages);
		};
		masterLoadMethodEntry2 = (dictionary["MStatus"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStatus);
		masterLoadMethodEntry2.unload = delegate
		{
			MStatus.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable201_0024327_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024135.Adapt(() => new MStatus());
		masterLoadMethodEntry2.keyNameList = () => MStatus.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStatus).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStatus.AddMst(m as MStatus);
		};
		masterLoadMethodEntry2 = (dictionary["MStepGachaTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStepGachaTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MStepGachaTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable202_0024328_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024136.Adapt(() => new MStepGachaTypes());
		masterLoadMethodEntry2.keyNameList = () => MStepGachaTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStepGachaTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStepGachaTypes.AddMst(m as MStepGachaTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MStories"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStories);
		masterLoadMethodEntry2.unload = delegate
		{
			MStories.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable203_0024329_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024137.Adapt(() => new MStories());
		masterLoadMethodEntry2.keyNameList = () => MStories.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStories).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStories.AddMst(m as MStories);
		};
		masterLoadMethodEntry2 = (dictionary["MStoryBooks"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStoryBooks);
		masterLoadMethodEntry2.unload = delegate
		{
			MStoryBooks.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable204_0024330_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024138.Adapt(() => new MStoryBooks());
		masterLoadMethodEntry2.keyNameList = () => MStoryBooks.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStoryBooks).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStoryBooks.AddMst(m as MStoryBooks);
		};
		masterLoadMethodEntry2 = (dictionary["MStoryGroups"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStoryGroups);
		masterLoadMethodEntry2.unload = delegate
		{
			MStoryGroups.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable205_0024331_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024139.Adapt(() => new MStoryGroups());
		masterLoadMethodEntry2.keyNameList = () => MStoryGroups.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStoryGroups).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStoryGroups.AddMst(m as MStoryGroups);
		};
		masterLoadMethodEntry2 = (dictionary["MStyles"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MStyles);
		masterLoadMethodEntry2.unload = delegate
		{
			MStyles.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable206_0024332_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024140.Adapt(() => new MStyles());
		masterLoadMethodEntry2.keyNameList = () => MStyles.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MStyles).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MStyles.AddMst(m as MStyles);
		};
		masterLoadMethodEntry2 = (dictionary["MTexts"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTexts);
		masterLoadMethodEntry2.unload = delegate
		{
			MTexts.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable207_0024333_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024141.Adapt(() => new MTexts());
		masterLoadMethodEntry2.keyNameList = () => MTexts.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTexts).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTexts.AddMst(m as MTexts);
		};
		masterLoadMethodEntry2 = (dictionary["MTipsMessage"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTipsMessage);
		masterLoadMethodEntry2.unload = delegate
		{
			MTipsMessage.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable208_0024334_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024142.Adapt(() => new MTipsMessage());
		masterLoadMethodEntry2.keyNameList = () => MTipsMessage.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTipsMessage).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTipsMessage.AddMst(m as MTipsMessage);
		};
		masterLoadMethodEntry2 = (dictionary["MTraits"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTraits);
		masterLoadMethodEntry2.unload = delegate
		{
			MTraits.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable209_0024335_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024143.Adapt(() => new MTraits());
		masterLoadMethodEntry2.keyNameList = () => MTraits.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTraits).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTraits.AddMst(m as MTraits);
		};
		masterLoadMethodEntry2 = (dictionary["MTutorialItems"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTutorialItems);
		masterLoadMethodEntry2.unload = delegate
		{
			MTutorialItems.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable210_0024336_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024144.Adapt(() => new MTutorialItems());
		masterLoadMethodEntry2.keyNameList = () => MTutorialItems.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTutorialItems).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTutorialItems.AddMst(m as MTutorialItems);
		};
		masterLoadMethodEntry2 = (dictionary["MTutorialMessages"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTutorialMessages);
		masterLoadMethodEntry2.unload = delegate
		{
			MTutorialMessages.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable211_0024337_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024145.Adapt(() => new MTutorialMessages());
		masterLoadMethodEntry2.keyNameList = () => MTutorialMessages.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTutorialMessages).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTutorialMessages.AddMst(m as MTutorialMessages);
		};
		masterLoadMethodEntry2 = (dictionary["MTutorials"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MTutorials);
		masterLoadMethodEntry2.unload = delegate
		{
			MTutorials.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable212_0024338_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024146.Adapt(() => new MTutorials());
		masterLoadMethodEntry2.keyNameList = () => MTutorials.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MTutorials).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MTutorials.AddMst(m as MTutorials);
		};
		masterLoadMethodEntry2 = (dictionary["MWarps"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWarps);
		masterLoadMethodEntry2.unload = delegate
		{
			MWarps.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable213_0024339_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024147.Adapt(() => new MWarps());
		masterLoadMethodEntry2.keyNameList = () => MWarps.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWarps).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWarps.AddMst(m as MWarps);
		};
		masterLoadMethodEntry2 = (dictionary["MWeaponSkills"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWeaponSkills);
		masterLoadMethodEntry2.unload = delegate
		{
			MWeaponSkills.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable214_0024340_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024148.Adapt(() => new MWeaponSkills());
		masterLoadMethodEntry2.keyNameList = () => MWeaponSkills.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWeaponSkills).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWeaponSkills.AddMst(m as MWeaponSkills);
		};
		masterLoadMethodEntry2 = (dictionary["MWeapons"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWeapons);
		masterLoadMethodEntry2.unload = delegate
		{
			MWeapons.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable215_0024341_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024149.Adapt(() => new MWeapons());
		masterLoadMethodEntry2.keyNameList = () => MWeapons.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWeapons).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWeapons.AddMst(m as MWeapons);
		};
		masterLoadMethodEntry2 = (dictionary["MWeek"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWeek);
		masterLoadMethodEntry2.unload = delegate
		{
			MWeek.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable216_0024342_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024150.Adapt(() => new MWeek());
		masterLoadMethodEntry2.keyNameList = () => MWeek.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWeek).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWeek.AddMst(m as MWeek);
		};
		masterLoadMethodEntry2 = (dictionary["MWeekBonus"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWeekBonus);
		masterLoadMethodEntry2.unload = delegate
		{
			MWeekBonus.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable217_0024343_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024151.Adapt(() => new MWeekBonus());
		masterLoadMethodEntry2.keyNameList = () => MWeekBonus.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWeekBonus).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWeekBonus.AddMst(m as MWeekBonus);
		};
		masterLoadMethodEntry2 = (dictionary["MWeekEvents"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWeekEvents);
		masterLoadMethodEntry2.unload = delegate
		{
			MWeekEvents.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable218_0024344_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024152.Adapt(() => new MWeekEvents());
		masterLoadMethodEntry2.keyNameList = () => MWeekEvents.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWeekEvents).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWeekEvents.AddMst(m as MWeekEvents);
		};
		masterLoadMethodEntry2 = (dictionary["MWholeRewards"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWholeRewards);
		masterLoadMethodEntry2.unload = delegate
		{
			MWholeRewards.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable219_0024345_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024153.Adapt(() => new MWholeRewards());
		masterLoadMethodEntry2.keyNameList = () => MWholeRewards.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWholeRewards).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWholeRewards.AddMst(m as MWholeRewards);
		};
		masterLoadMethodEntry2 = (dictionary["MWindowTypes"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MWindowTypes);
		masterLoadMethodEntry2.unload = delegate
		{
			MWindowTypes.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable220_0024346_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024154.Adapt(() => new MWindowTypes());
		masterLoadMethodEntry2.keyNameList = () => MWindowTypes.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MWindowTypes).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MWindowTypes.AddMst(m as MWindowTypes);
		};
		masterLoadMethodEntry2 = (dictionary["MURLSchemeAPI"] = new MasterLoadMethodEntry());
		masterLoadMethodEntry2.masterType = typeof(MURLSchemeAPI);
		masterLoadMethodEntry2.unload = delegate
		{
			MURLSchemeAPI.Unload();
		};
		masterLoadMethodEntry2.createInst = _0024adaptor_0024__MerlinMaster_0024callable221_0024348_9___0024__MasterLoadMethodEntry_createInst_0024callable19_0024189_30___0024155.Adapt(() => new MURLSchemeAPI());
		masterLoadMethodEntry2.keyNameList = () => MURLSchemeAPI.KeyNameList();
		masterLoadMethodEntry2.setStringValues = delegate(MerlinMaster m, string[] strs)
		{
			(m as MURLSchemeAPI).setStringValues(strs);
		};
		masterLoadMethodEntry2.addMst = delegate(MerlinMaster m)
		{
			MURLSchemeAPI.AddMst(m as MURLSchemeAPI);
		};
		return dictionary;
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024218()
	{
		MAbnormalStateParameters.Unload();
	}

	internal static MAbnormalStateParameters _0024InitLoadMethodTbl_0024closure_0024219()
	{
		return new MAbnormalStateParameters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024220()
	{
		return MAbnormalStateParameters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024221(MerlinMaster m, string[] strs)
	{
		(m as MAbnormalStateParameters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024222(MerlinMaster m)
	{
		MAbnormalStateParameters.AddMst(m as MAbnormalStateParameters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024223()
	{
		MAbnormalStates.Unload();
	}

	internal static MAbnormalStates _0024InitLoadMethodTbl_0024closure_0024224()
	{
		return new MAbnormalStates();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024225()
	{
		return MAbnormalStates.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024226(MerlinMaster m, string[] strs)
	{
		(m as MAbnormalStates).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024227(MerlinMaster m)
	{
		MAbnormalStates.AddMst(m as MAbnormalStates);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024228()
	{
		MAppendixGachas.Unload();
	}

	internal static MAppendixGachas _0024InitLoadMethodTbl_0024closure_0024229()
	{
		return new MAppendixGachas();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024230()
	{
		return MAppendixGachas.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024231(MerlinMaster m, string[] strs)
	{
		(m as MAppendixGachas).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024232(MerlinMaster m)
	{
		MAppendixGachas.AddMst(m as MAppendixGachas);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024233()
	{
		MAreaGroups.Unload();
	}

	internal static MAreaGroups _0024InitLoadMethodTbl_0024closure_0024234()
	{
		return new MAreaGroups();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024235()
	{
		return MAreaGroups.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024236(MerlinMaster m, string[] strs)
	{
		(m as MAreaGroups).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024237(MerlinMaster m)
	{
		MAreaGroups.AddMst(m as MAreaGroups);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024238()
	{
		MAreaTypes.Unload();
	}

	internal static MAreaTypes _0024InitLoadMethodTbl_0024closure_0024239()
	{
		return new MAreaTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024240()
	{
		return MAreaTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024241(MerlinMaster m, string[] strs)
	{
		(m as MAreaTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024242(MerlinMaster m)
	{
		MAreaTypes.AddMst(m as MAreaTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024243()
	{
		MAreas.Unload();
	}

	internal static MAreas _0024InitLoadMethodTbl_0024closure_0024244()
	{
		return new MAreas();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024245()
	{
		return MAreas.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024246(MerlinMaster m, string[] strs)
	{
		(m as MAreas).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024247(MerlinMaster m)
	{
		MAreas.AddMst(m as MAreas);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024248()
	{
		MAutoFlowPoint.Unload();
	}

	internal static MAutoFlowPoint _0024InitLoadMethodTbl_0024closure_0024261()
	{
		return new MAutoFlowPoint();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024262()
	{
		return MAutoFlowPoint.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024263(MerlinMaster m, string[] strs)
	{
		(m as MAutoFlowPoint).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024264(MerlinMaster m)
	{
		MAutoFlowPoint.AddMst(m as MAutoFlowPoint);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024265()
	{
		MBgm.Unload();
	}

	internal static MBgm _0024InitLoadMethodTbl_0024closure_0024266()
	{
		return new MBgm();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024267()
	{
		return MBgm.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024268(MerlinMaster m, string[] strs)
	{
		(m as MBgm).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024269(MerlinMaster m)
	{
		MBgm.AddMst(m as MBgm);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024270()
	{
		MBreederRanks.Unload();
	}

	internal static MBreederRanks _0024InitLoadMethodTbl_0024closure_0024271()
	{
		return new MBreederRanks();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024272()
	{
		return MBreederRanks.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024273(MerlinMaster m, string[] strs)
	{
		(m as MBreederRanks).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024274(MerlinMaster m)
	{
		MBreederRanks.AddMst(m as MBreederRanks);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024275()
	{
		MCampaignSegmentTypes.Unload();
	}

	internal static MCampaignSegmentTypes _0024InitLoadMethodTbl_0024closure_0024276()
	{
		return new MCampaignSegmentTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024277()
	{
		return MCampaignSegmentTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024278(MerlinMaster m, string[] strs)
	{
		(m as MCampaignSegmentTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024279(MerlinMaster m)
	{
		MCampaignSegmentTypes.AddMst(m as MCampaignSegmentTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024280()
	{
		MCampaignTypes.Unload();
	}

	internal static MCampaignTypes _0024InitLoadMethodTbl_0024closure_0024281()
	{
		return new MCampaignTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024282()
	{
		return MCampaignTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024283(MerlinMaster m, string[] strs)
	{
		(m as MCampaignTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024284(MerlinMaster m)
	{
		MCampaignTypes.AddMst(m as MCampaignTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024285()
	{
		MCampaigns.Unload();
	}

	internal static MCampaigns _0024InitLoadMethodTbl_0024closure_0024286()
	{
		return new MCampaigns();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024287()
	{
		return MCampaigns.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024288(MerlinMaster m, string[] strs)
	{
		(m as MCampaigns).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024289(MerlinMaster m)
	{
		MCampaigns.AddMst(m as MCampaigns);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024290()
	{
		MChainSkillEffects.Unload();
	}

	internal static MChainSkillEffects _0024InitLoadMethodTbl_0024closure_0024291()
	{
		return new MChainSkillEffects();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024292()
	{
		return MChainSkillEffects.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024293(MerlinMaster m, string[] strs)
	{
		(m as MChainSkillEffects).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024294(MerlinMaster m)
	{
		MChainSkillEffects.AddMst(m as MChainSkillEffects);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024295()
	{
		MChainSkills.Unload();
	}

	internal static MChainSkills _0024InitLoadMethodTbl_0024closure_0024296()
	{
		return new MChainSkills();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024297()
	{
		return MChainSkills.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024298(MerlinMaster m, string[] strs)
	{
		(m as MChainSkills).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024299(MerlinMaster m)
	{
		MChainSkills.AddMst(m as MChainSkills);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024300()
	{
		MChallengeQuestScheduleDetails.Unload();
	}

	internal static MChallengeQuestScheduleDetails _0024InitLoadMethodTbl_0024closure_0024302()
	{
		return new MChallengeQuestScheduleDetails();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024303()
	{
		return MChallengeQuestScheduleDetails.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024304(MerlinMaster m, string[] strs)
	{
		(m as MChallengeQuestScheduleDetails).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024305(MerlinMaster m)
	{
		MChallengeQuestScheduleDetails.AddMst(m as MChallengeQuestScheduleDetails);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024306()
	{
		MChallengeQuestSchedules.Unload();
	}

	internal static MChallengeQuestSchedules _0024InitLoadMethodTbl_0024closure_0024307()
	{
		return new MChallengeQuestSchedules();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024308()
	{
		return MChallengeQuestSchedules.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024309(MerlinMaster m, string[] strs)
	{
		(m as MChallengeQuestSchedules).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024310(MerlinMaster m)
	{
		MChallengeQuestSchedules.AddMst(m as MChallengeQuestSchedules);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024311()
	{
		MChangeDeckMains.Unload();
	}

	internal static MChangeDeckMains _0024InitLoadMethodTbl_0024closure_0024312()
	{
		return new MChangeDeckMains();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024313()
	{
		return MChangeDeckMains.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024314(MerlinMaster m, string[] strs)
	{
		(m as MChangeDeckMains).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024315(MerlinMaster m)
	{
		MChangeDeckMains.AddMst(m as MChangeDeckMains);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024316()
	{
		MChangeDeckSupports.Unload();
	}

	internal static MChangeDeckSupports _0024InitLoadMethodTbl_0024closure_0024317()
	{
		return new MChangeDeckSupports();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024318()
	{
		return MChangeDeckSupports.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024319(MerlinMaster m, string[] strs)
	{
		(m as MChangeDeckSupports).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024320(MerlinMaster m)
	{
		MChangeDeckSupports.AddMst(m as MChangeDeckSupports);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024321()
	{
		MChangePoppetDecks.Unload();
	}

	internal static MChangePoppetDecks _0024InitLoadMethodTbl_0024closure_0024322()
	{
		return new MChangePoppetDecks();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024323()
	{
		return MChangePoppetDecks.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024324(MerlinMaster m, string[] strs)
	{
		(m as MChangePoppetDecks).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024325(MerlinMaster m)
	{
		MChangePoppetDecks.AddMst(m as MChangePoppetDecks);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024326()
	{
		MCharacterActionTypes.Unload();
	}

	internal static MCharacterActionTypes _0024InitLoadMethodTbl_0024closure_0024327()
	{
		return new MCharacterActionTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024328()
	{
		return MCharacterActionTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024329(MerlinMaster m, string[] strs)
	{
		(m as MCharacterActionTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024330(MerlinMaster m)
	{
		MCharacterActionTypes.AddMst(m as MCharacterActionTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024331()
	{
		MCharacteristics.Unload();
	}

	internal static MCharacteristics _0024InitLoadMethodTbl_0024closure_0024332()
	{
		return new MCharacteristics();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024333()
	{
		return MCharacteristics.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024334(MerlinMaster m, string[] strs)
	{
		(m as MCharacteristics).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024335(MerlinMaster m)
	{
		MCharacteristics.AddMst(m as MCharacteristics);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024336()
	{
		MColosseumEventRankingPointNormaRewards.Unload();
	}

	internal static MColosseumEventRankingPointNormaRewards _0024InitLoadMethodTbl_0024closure_0024337()
	{
		return new MColosseumEventRankingPointNormaRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024338()
	{
		return MColosseumEventRankingPointNormaRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024339(MerlinMaster m, string[] strs)
	{
		(m as MColosseumEventRankingPointNormaRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024340(MerlinMaster m)
	{
		MColosseumEventRankingPointNormaRewards.AddMst(m as MColosseumEventRankingPointNormaRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024341()
	{
		MColosseumEventRankingRewards.Unload();
	}

	internal static MColosseumEventRankingRewards _0024InitLoadMethodTbl_0024closure_0024342()
	{
		return new MColosseumEventRankingRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024343()
	{
		return MColosseumEventRankingRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024344(MerlinMaster m, string[] strs)
	{
		(m as MColosseumEventRankingRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024345(MerlinMaster m)
	{
		MColosseumEventRankingRewards.AddMst(m as MColosseumEventRankingRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024346()
	{
		MColosseumEventRewards.Unload();
	}

	internal static MColosseumEventRewards _0024InitLoadMethodTbl_0024closure_0024347()
	{
		return new MColosseumEventRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024348()
	{
		return MColosseumEventRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024349(MerlinMaster m, string[] strs)
	{
		(m as MColosseumEventRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024350(MerlinMaster m)
	{
		MColosseumEventRewards.AddMst(m as MColosseumEventRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024351()
	{
		MColosseumEvents.Unload();
	}

	internal static MColosseumEvents _0024InitLoadMethodTbl_0024closure_0024352()
	{
		return new MColosseumEvents();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024353()
	{
		return MColosseumEvents.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024354(MerlinMaster m, string[] strs)
	{
		(m as MColosseumEvents).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024355(MerlinMaster m)
	{
		MColosseumEvents.AddMst(m as MColosseumEvents);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024356()
	{
		MColosseumNpcOrganizes.Unload();
	}

	internal static MColosseumNpcOrganizes _0024InitLoadMethodTbl_0024closure_0024357()
	{
		return new MColosseumNpcOrganizes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024358()
	{
		return MColosseumNpcOrganizes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024359(MerlinMaster m, string[] strs)
	{
		(m as MColosseumNpcOrganizes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024360(MerlinMaster m)
	{
		MColosseumNpcOrganizes.AddMst(m as MColosseumNpcOrganizes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024361()
	{
		MColosseumNpcs.Unload();
	}

	internal static MColosseumNpcs _0024InitLoadMethodTbl_0024closure_0024362()
	{
		return new MColosseumNpcs();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024363()
	{
		return MColosseumNpcs.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024364(MerlinMaster m, string[] strs)
	{
		(m as MColosseumNpcs).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024365(MerlinMaster m)
	{
		MColosseumNpcs.AddMst(m as MColosseumNpcs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024366()
	{
		MComboBonus.Unload();
	}

	internal static MComboBonus _0024InitLoadMethodTbl_0024closure_0024367()
	{
		return new MComboBonus();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024368()
	{
		return MComboBonus.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024369(MerlinMaster m, string[] strs)
	{
		(m as MComboBonus).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024370(MerlinMaster m)
	{
		MComboBonus.AddMst(m as MComboBonus);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024371()
	{
		MComparisonOperator.Unload();
	}

	internal static MComparisonOperator _0024InitLoadMethodTbl_0024closure_0024372()
	{
		return new MComparisonOperator();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024373()
	{
		return MComparisonOperator.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024374(MerlinMaster m, string[] strs)
	{
		(m as MComparisonOperator).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024375(MerlinMaster m)
	{
		MComparisonOperator.AddMst(m as MComparisonOperator);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024376()
	{
		MCoverSkills.Unload();
	}

	internal static MCoverSkills _0024InitLoadMethodTbl_0024closure_0024377()
	{
		return new MCoverSkills();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024378()
	{
		return MCoverSkills.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024379(MerlinMaster m, string[] strs)
	{
		(m as MCoverSkills).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024380(MerlinMaster m)
	{
		MCoverSkills.AddMst(m as MCoverSkills);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024381()
	{
		MCycleSchedules.Unload();
	}

	internal static MCycleSchedules _0024InitLoadMethodTbl_0024closure_0024382()
	{
		return new MCycleSchedules();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024383()
	{
		return MCycleSchedules.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024384(MerlinMaster m, string[] strs)
	{
		(m as MCycleSchedules).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024385(MerlinMaster m)
	{
		MCycleSchedules.AddMst(m as MCycleSchedules);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024386()
	{
		MDailyPassiveSkillSchedules.Unload();
	}

	internal static MDailyPassiveSkillSchedules _0024InitLoadMethodTbl_0024closure_0024387()
	{
		return new MDailyPassiveSkillSchedules();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024388()
	{
		return MDailyPassiveSkillSchedules.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024389(MerlinMaster m, string[] strs)
	{
		(m as MDailyPassiveSkillSchedules).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024390(MerlinMaster m)
	{
		MDailyPassiveSkillSchedules.AddMst(m as MDailyPassiveSkillSchedules);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024391()
	{
		MDebugRaidBossData.Unload();
	}

	internal static MDebugRaidBossData _0024InitLoadMethodTbl_0024closure_0024392()
	{
		return new MDebugRaidBossData();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024393()
	{
		return MDebugRaidBossData.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024394(MerlinMaster m, string[] strs)
	{
		(m as MDebugRaidBossData).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024395(MerlinMaster m)
	{
		MDebugRaidBossData.AddMst(m as MDebugRaidBossData);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024396()
	{
		MElementCorrelations.Unload();
	}

	internal static MElementCorrelations _0024InitLoadMethodTbl_0024closure_0024397()
	{
		return new MElementCorrelations();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024398()
	{
		return MElementCorrelations.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024399(MerlinMaster m, string[] strs)
	{
		(m as MElementCorrelations).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024400(MerlinMaster m)
	{
		MElementCorrelations.AddMst(m as MElementCorrelations);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024401()
	{
		MElements.Unload();
	}

	internal static MElements _0024InitLoadMethodTbl_0024closure_0024402()
	{
		return new MElements();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024403()
	{
		return MElements.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024404(MerlinMaster m, string[] strs)
	{
		(m as MElements).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024405(MerlinMaster m)
	{
		MElements.AddMst(m as MElements);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024406()
	{
		MEventQuestRankingRewards.Unload();
	}

	internal static MEventQuestRankingRewards _0024InitLoadMethodTbl_0024closure_0024407()
	{
		return new MEventQuestRankingRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024408()
	{
		return MEventQuestRankingRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024409(MerlinMaster m, string[] strs)
	{
		(m as MEventQuestRankingRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024410(MerlinMaster m)
	{
		MEventQuestRankingRewards.AddMst(m as MEventQuestRankingRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024411()
	{
		MEventQuestRewards.Unload();
	}

	internal static MEventQuestRewards _0024InitLoadMethodTbl_0024closure_0024412()
	{
		return new MEventQuestRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024413()
	{
		return MEventQuestRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024414(MerlinMaster m, string[] strs)
	{
		(m as MEventQuestRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024415(MerlinMaster m)
	{
		MEventQuestRewards.AddMst(m as MEventQuestRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024416()
	{
		MEvolutionInformations.Unload();
	}

	internal static MEvolutionInformations _0024InitLoadMethodTbl_0024closure_0024417()
	{
		return new MEvolutionInformations();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024418()
	{
		return MEvolutionInformations.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024419(MerlinMaster m, string[] strs)
	{
		(m as MEvolutionInformations).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024420(MerlinMaster m)
	{
		MEvolutionInformations.AddMst(m as MEvolutionInformations);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024421()
	{
		MFixedEmissionGachas.Unload();
	}

	internal static MFixedEmissionGachas _0024InitLoadMethodTbl_0024closure_0024422()
	{
		return new MFixedEmissionGachas();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024423()
	{
		return MFixedEmissionGachas.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024424(MerlinMaster m, string[] strs)
	{
		(m as MFixedEmissionGachas).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024425(MerlinMaster m)
	{
		MFixedEmissionGachas.AddMst(m as MFixedEmissionGachas);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024426()
	{
		MFlags.Unload();
	}

	internal static MFlags _0024InitLoadMethodTbl_0024closure_0024427()
	{
		return new MFlags();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024428()
	{
		return MFlags.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024429(MerlinMaster m, string[] strs)
	{
		(m as MFlags).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024430(MerlinMaster m)
	{
		MFlags.AddMst(m as MFlags);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024431()
	{
		MGachaBoxes.Unload();
	}

	internal static MGachaBoxes _0024InitLoadMethodTbl_0024closure_0024432()
	{
		return new MGachaBoxes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024433()
	{
		return MGachaBoxes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024434(MerlinMaster m, string[] strs)
	{
		(m as MGachaBoxes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024435(MerlinMaster m)
	{
		MGachaBoxes.AddMst(m as MGachaBoxes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024436()
	{
		MGachaRewards.Unload();
	}

	internal static MGachaRewards _0024InitLoadMethodTbl_0024closure_0024437()
	{
		return new MGachaRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024438()
	{
		return MGachaRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024439(MerlinMaster m, string[] strs)
	{
		(m as MGachaRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024440(MerlinMaster m)
	{
		MGachaRewards.AddMst(m as MGachaRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024441()
	{
		MGachaTypeValues.Unload();
	}

	internal static MGachaTypeValues _0024InitLoadMethodTbl_0024closure_0024442()
	{
		return new MGachaTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024443()
	{
		return MGachaTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024444(MerlinMaster m, string[] strs)
	{
		(m as MGachaTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024445(MerlinMaster m)
	{
		MGachaTypeValues.AddMst(m as MGachaTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024446()
	{
		MGachaTypesForClient.Unload();
	}

	internal static MGachaTypesForClient _0024InitLoadMethodTbl_0024closure_0024447()
	{
		return new MGachaTypesForClient();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024448()
	{
		return MGachaTypesForClient.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024449(MerlinMaster m, string[] strs)
	{
		(m as MGachaTypesForClient).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024450(MerlinMaster m)
	{
		MGachaTypesForClient.AddMst(m as MGachaTypesForClient);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024451()
	{
		MGachas.Unload();
	}

	internal static MGachas _0024InitLoadMethodTbl_0024closure_0024452()
	{
		return new MGachas();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024453()
	{
		return MGachas.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024454(MerlinMaster m, string[] strs)
	{
		(m as MGachas).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024455(MerlinMaster m)
	{
		MGachas.AddMst(m as MGachas);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024456()
	{
		MGameObjectNames.Unload();
	}

	internal static MGameObjectNames _0024InitLoadMethodTbl_0024closure_0024457()
	{
		return new MGameObjectNames();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024458()
	{
		return MGameObjectNames.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024459(MerlinMaster m, string[] strs)
	{
		(m as MGameObjectNames).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024460(MerlinMaster m)
	{
		MGameObjectNames.AddMst(m as MGameObjectNames);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024461()
	{
		MGameParameters.Unload();
	}

	internal static MGameParameters _0024InitLoadMethodTbl_0024closure_0024464()
	{
		return new MGameParameters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024465()
	{
		return MGameParameters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024466(MerlinMaster m, string[] strs)
	{
		(m as MGameParameters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024467(MerlinMaster m)
	{
		MGameParameters.AddMst(m as MGameParameters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024468()
	{
		MGenders.Unload();
	}

	internal static MGenders _0024InitLoadMethodTbl_0024closure_0024469()
	{
		return new MGenders();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024470()
	{
		return MGenders.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024471(MerlinMaster m, string[] strs)
	{
		(m as MGenders).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024472(MerlinMaster m)
	{
		MGenders.AddMst(m as MGenders);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024473()
	{
		MHonors.Unload();
	}

	internal static MHonors _0024InitLoadMethodTbl_0024closure_0024474()
	{
		return new MHonors();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024475()
	{
		return MHonors.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024476(MerlinMaster m, string[] strs)
	{
		(m as MHonors).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024477(MerlinMaster m)
	{
		MHonors.AddMst(m as MHonors);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024478()
	{
		MInAppProducts.Unload();
	}

	internal static MInAppProducts _0024InitLoadMethodTbl_0024closure_0024479()
	{
		return new MInAppProducts();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024480()
	{
		return MInAppProducts.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024481(MerlinMaster m, string[] strs)
	{
		(m as MInAppProducts).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024482(MerlinMaster m)
	{
		MInAppProducts.AddMst(m as MInAppProducts);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024483()
	{
		MInviteRewards.Unload();
	}

	internal static MInviteRewards _0024InitLoadMethodTbl_0024closure_0024484()
	{
		return new MInviteRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024485()
	{
		return MInviteRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024486(MerlinMaster m, string[] strs)
	{
		(m as MInviteRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024487(MerlinMaster m)
	{
		MInviteRewards.AddMst(m as MInviteRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024488()
	{
		MItemGroupChilds.Unload();
	}

	internal static MItemGroupChilds _0024InitLoadMethodTbl_0024closure_0024489()
	{
		return new MItemGroupChilds();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024490()
	{
		return MItemGroupChilds.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024491(MerlinMaster m, string[] strs)
	{
		(m as MItemGroupChilds).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024492(MerlinMaster m)
	{
		MItemGroupChilds.AddMst(m as MItemGroupChilds);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024493()
	{
		MItemGroups.Unload();
	}

	internal static MItemGroups _0024InitLoadMethodTbl_0024closure_0024494()
	{
		return new MItemGroups();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024495()
	{
		return MItemGroups.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024496(MerlinMaster m, string[] strs)
	{
		(m as MItemGroups).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024497(MerlinMaster m)
	{
		MItemGroups.AddMst(m as MItemGroups);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024498()
	{
		MItemTypes.Unload();
	}

	internal static MItemTypes _0024InitLoadMethodTbl_0024closure_0024499()
	{
		return new MItemTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024500()
	{
		return MItemTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024501(MerlinMaster m, string[] strs)
	{
		(m as MItemTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024502(MerlinMaster m)
	{
		MItemTypes.AddMst(m as MItemTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024503()
	{
		MKeyItems.Unload();
	}

	internal static MKeyItems _0024InitLoadMethodTbl_0024closure_0024504()
	{
		return new MKeyItems();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024505()
	{
		return MKeyItems.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024506(MerlinMaster m, string[] strs)
	{
		(m as MKeyItems).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024507(MerlinMaster m)
	{
		MKeyItems.AddMst(m as MKeyItems);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024508()
	{
		MKusamushi.Unload();
	}

	internal static MKusamushi _0024InitLoadMethodTbl_0024closure_0024509()
	{
		return new MKusamushi();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024510()
	{
		return MKusamushi.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024511(MerlinMaster m, string[] strs)
	{
		(m as MKusamushi).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024512(MerlinMaster m)
	{
		MKusamushi.AddMst(m as MKusamushi);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024513()
	{
		MLevelUpTypes.Unload();
	}

	internal static MLevelUpTypes _0024InitLoadMethodTbl_0024closure_0024514()
	{
		return new MLevelUpTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024515()
	{
		return MLevelUpTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024516(MerlinMaster m, string[] strs)
	{
		(m as MLevelUpTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024517(MerlinMaster m)
	{
		MLevelUpTypes.AddMst(m as MLevelUpTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024518()
	{
		MLoginBonusItems.Unload();
	}

	internal static MLoginBonusItems _0024InitLoadMethodTbl_0024closure_0024519()
	{
		return new MLoginBonusItems();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024520()
	{
		return MLoginBonusItems.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024521(MerlinMaster m, string[] strs)
	{
		(m as MLoginBonusItems).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024522(MerlinMaster m)
	{
		MLoginBonusItems.AddMst(m as MLoginBonusItems);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024523()
	{
		MLoginBonusTypeValues.Unload();
	}

	internal static MLoginBonusTypeValues _0024InitLoadMethodTbl_0024closure_0024524()
	{
		return new MLoginBonusTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024525()
	{
		return MLoginBonusTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024526(MerlinMaster m, string[] strs)
	{
		(m as MLoginBonusTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024527(MerlinMaster m)
	{
		MLoginBonusTypeValues.AddMst(m as MLoginBonusTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024528()
	{
		MLoginBonuses.Unload();
	}

	internal static MLoginBonuses _0024InitLoadMethodTbl_0024closure_0024529()
	{
		return new MLoginBonuses();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024530()
	{
		return MLoginBonuses.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024531(MerlinMaster m, string[] strs)
	{
		(m as MLoginBonuses).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024532(MerlinMaster m)
	{
		MLoginBonuses.AddMst(m as MLoginBonuses);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024533()
	{
		MLoginRewards.Unload();
	}

	internal static MLoginRewards _0024InitLoadMethodTbl_0024closure_0024534()
	{
		return new MLoginRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024535()
	{
		return MLoginRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024536(MerlinMaster m, string[] strs)
	{
		(m as MLoginRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024537(MerlinMaster m)
	{
		MLoginRewards.AddMst(m as MLoginRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024538()
	{
		MLots.Unload();
	}

	internal static MLots _0024InitLoadMethodTbl_0024closure_0024539()
	{
		return new MLots();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024540()
	{
		return MLots.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024541(MerlinMaster m, string[] strs)
	{
		(m as MLots).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024542(MerlinMaster m)
	{
		MLots.AddMst(m as MLots);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024543()
	{
		MMapLinkDir.Unload();
	}

	internal static MMapLinkDir _0024InitLoadMethodTbl_0024closure_0024544()
	{
		return new MMapLinkDir();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024545()
	{
		return MMapLinkDir.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024546(MerlinMaster m, string[] strs)
	{
		(m as MMapLinkDir).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024547(MerlinMaster m)
	{
		MMapLinkDir.AddMst(m as MMapLinkDir);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024548()
	{
		MMarketTypeValues.Unload();
	}

	internal static MMarketTypeValues _0024InitLoadMethodTbl_0024closure_0024549()
	{
		return new MMarketTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024550()
	{
		return MMarketTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024551(MerlinMaster m, string[] strs)
	{
		(m as MMarketTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024552(MerlinMaster m)
	{
		MMarketTypeValues.AddMst(m as MMarketTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024553()
	{
		MMasterTypeValues.Unload();
	}

	internal static MMasterTypeValues _0024InitLoadMethodTbl_0024closure_0024554()
	{
		return new MMasterTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024555()
	{
		return MMasterTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024556(MerlinMaster m, string[] strs)
	{
		(m as MMasterTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024557(MerlinMaster m)
	{
		MMasterTypeValues.AddMst(m as MMasterTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024558()
	{
		MMissionConditionTypes.Unload();
	}

	internal static MMissionConditionTypes _0024InitLoadMethodTbl_0024closure_0024559()
	{
		return new MMissionConditionTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024560()
	{
		return MMissionConditionTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024561(MerlinMaster m, string[] strs)
	{
		(m as MMissionConditionTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024562(MerlinMaster m)
	{
		MMissionConditionTypes.AddMst(m as MMissionConditionTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024563()
	{
		MMissionTypeValues.Unload();
	}

	internal static MMissionTypeValues _0024InitLoadMethodTbl_0024closure_0024564()
	{
		return new MMissionTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024565()
	{
		return MMissionTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024566(MerlinMaster m, string[] strs)
	{
		(m as MMissionTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024567(MerlinMaster m)
	{
		MMissionTypeValues.AddMst(m as MMissionTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024568()
	{
		MMonsters.Unload();
	}

	internal static MMonsters _0024InitLoadMethodTbl_0024closure_0024569()
	{
		return new MMonsters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024570()
	{
		return MMonsters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024571(MerlinMaster m, string[] strs)
	{
		(m as MMonsters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024572(MerlinMaster m)
	{
		MMonsters.AddMst(m as MMonsters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024573()
	{
		MNewFeatureDetails.Unload();
	}

	internal static MNewFeatureDetails _0024InitLoadMethodTbl_0024closure_0024576()
	{
		return new MNewFeatureDetails();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024577()
	{
		return MNewFeatureDetails.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024578(MerlinMaster m, string[] strs)
	{
		(m as MNewFeatureDetails).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024579(MerlinMaster m)
	{
		MNewFeatureDetails.AddMst(m as MNewFeatureDetails);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024580()
	{
		MNormalAttackRange.Unload();
	}

	internal static MNormalAttackRange _0024InitLoadMethodTbl_0024closure_0024581()
	{
		return new MNormalAttackRange();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024582()
	{
		return MNormalAttackRange.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024583(MerlinMaster m, string[] strs)
	{
		(m as MNormalAttackRange).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024584(MerlinMaster m)
	{
		MNormalAttackRange.AddMst(m as MNormalAttackRange);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024585()
	{
		MNpcTalkIcons.Unload();
	}

	internal static MNpcTalkIcons _0024InitLoadMethodTbl_0024closure_0024586()
	{
		return new MNpcTalkIcons();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024587()
	{
		return MNpcTalkIcons.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024588(MerlinMaster m, string[] strs)
	{
		(m as MNpcTalkIcons).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024589(MerlinMaster m)
	{
		MNpcTalkIcons.AddMst(m as MNpcTalkIcons);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024590()
	{
		MNpcTalkTypes.Unload();
	}

	internal static MNpcTalkTypes _0024InitLoadMethodTbl_0024closure_0024591()
	{
		return new MNpcTalkTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024592()
	{
		return MNpcTalkTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024593(MerlinMaster m, string[] strs)
	{
		(m as MNpcTalkTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024594(MerlinMaster m)
	{
		MNpcTalkTypes.AddMst(m as MNpcTalkTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024595()
	{
		MNpcTalks.Unload();
	}

	internal static MNpcTalks _0024InitLoadMethodTbl_0024closure_0024596()
	{
		return new MNpcTalks();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024597()
	{
		return MNpcTalks.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024598(MerlinMaster m, string[] strs)
	{
		(m as MNpcTalks).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024599(MerlinMaster m)
	{
		MNpcTalks.AddMst(m as MNpcTalks);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024600()
	{
		MNpcTexts.Unload();
	}

	internal static MNpcTexts _0024InitLoadMethodTbl_0024closure_0024601()
	{
		return new MNpcTexts();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024602()
	{
		return MNpcTexts.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024603(MerlinMaster m, string[] strs)
	{
		(m as MNpcTexts).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024604(MerlinMaster m)
	{
		MNpcTexts.AddMst(m as MNpcTexts);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024605()
	{
		MNpcs.Unload();
	}

	internal static MNpcs _0024InitLoadMethodTbl_0024closure_0024606()
	{
		return new MNpcs();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024607()
	{
		return MNpcs.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024608(MerlinMaster m, string[] strs)
	{
		(m as MNpcs).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024609(MerlinMaster m)
	{
		MNpcs.AddMst(m as MNpcs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024610()
	{
		MPackedSceneMap.Unload();
	}

	internal static MPackedSceneMap _0024InitLoadMethodTbl_0024closure_0024611()
	{
		return new MPackedSceneMap();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024612()
	{
		return MPackedSceneMap.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024613(MerlinMaster m, string[] strs)
	{
		(m as MPackedSceneMap).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024614(MerlinMaster m)
	{
		MPackedSceneMap.AddMst(m as MPackedSceneMap);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024615()
	{
		MParameterCorrects.Unload();
	}

	internal static MParameterCorrects _0024InitLoadMethodTbl_0024closure_0024616()
	{
		return new MParameterCorrects();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024617()
	{
		return MParameterCorrects.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024618(MerlinMaster m, string[] strs)
	{
		(m as MParameterCorrects).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024619(MerlinMaster m)
	{
		MParameterCorrects.AddMst(m as MParameterCorrects);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024620()
	{
		MPlayerDeckMains.Unload();
	}

	internal static MPlayerDeckMains _0024InitLoadMethodTbl_0024closure_0024621()
	{
		return new MPlayerDeckMains();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024622()
	{
		return MPlayerDeckMains.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024623(MerlinMaster m, string[] strs)
	{
		(m as MPlayerDeckMains).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024624(MerlinMaster m)
	{
		MPlayerDeckMains.AddMst(m as MPlayerDeckMains);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024625()
	{
		MPlayerDeckSupports.Unload();
	}

	internal static MPlayerDeckSupports _0024InitLoadMethodTbl_0024closure_0024626()
	{
		return new MPlayerDeckSupports();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024627()
	{
		return MPlayerDeckSupports.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024628(MerlinMaster m, string[] strs)
	{
		(m as MPlayerDeckSupports).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024629(MerlinMaster m)
	{
		MPlayerDeckSupports.AddMst(m as MPlayerDeckSupports);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024630()
	{
		MPlayerGroups.Unload();
	}

	internal static MPlayerGroups _0024InitLoadMethodTbl_0024closure_0024631()
	{
		return new MPlayerGroups();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024632()
	{
		return MPlayerGroups.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024633(MerlinMaster m, string[] strs)
	{
		(m as MPlayerGroups).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024634(MerlinMaster m)
	{
		MPlayerGroups.AddMst(m as MPlayerGroups);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024635()
	{
		MPlayerParameters.Unload();
	}

	internal static MPlayerParameters _0024InitLoadMethodTbl_0024closure_0024636()
	{
		return new MPlayerParameters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024637()
	{
		return MPlayerParameters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024638(MerlinMaster m, string[] strs)
	{
		(m as MPlayerParameters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024639(MerlinMaster m)
	{
		MPlayerParameters.AddMst(m as MPlayerParameters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024640()
	{
		MPlayerPoppetDecks.Unload();
	}

	internal static MPlayerPoppetDecks _0024InitLoadMethodTbl_0024closure_0024641()
	{
		return new MPlayerPoppetDecks();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024642()
	{
		return MPlayerPoppetDecks.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024643(MerlinMaster m, string[] strs)
	{
		(m as MPlayerPoppetDecks).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024644(MerlinMaster m)
	{
		MPlayerPoppetDecks.AddMst(m as MPlayerPoppetDecks);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024645()
	{
		MPlayerRaces.Unload();
	}

	internal static MPlayerRaces _0024InitLoadMethodTbl_0024closure_0024646()
	{
		return new MPlayerRaces();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024647()
	{
		return MPlayerRaces.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024648(MerlinMaster m, string[] strs)
	{
		(m as MPlayerRaces).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024649(MerlinMaster m)
	{
		MPlayerRaces.AddMst(m as MPlayerRaces);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024650()
	{
		MPlayers.Unload();
	}

	internal static MPlayers _0024InitLoadMethodTbl_0024closure_0024651()
	{
		return new MPlayers();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024652()
	{
		return MPlayers.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024653(MerlinMaster m, string[] strs)
	{
		(m as MPlayers).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024654(MerlinMaster m)
	{
		MPlayers.AddMst(m as MPlayers);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024655()
	{
		MPlusBonus.Unload();
	}

	internal static MPlusBonus _0024InitLoadMethodTbl_0024closure_0024656()
	{
		return new MPlusBonus();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024657()
	{
		return MPlusBonus.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024658(MerlinMaster m, string[] strs)
	{
		(m as MPlusBonus).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024659(MerlinMaster m)
	{
		MPlusBonus.AddMst(m as MPlusBonus);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024660()
	{
		MPoints.Unload();
	}

	internal static MPoints _0024InitLoadMethodTbl_0024closure_0024661()
	{
		return new MPoints();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024662()
	{
		return MPoints.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024663(MerlinMaster m, string[] strs)
	{
		(m as MPoints).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024664(MerlinMaster m)
	{
		MPoints.AddMst(m as MPoints);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024665()
	{
		MPoppetChatTimings.Unload();
	}

	internal static MPoppetChatTimings _0024InitLoadMethodTbl_0024closure_0024666()
	{
		return new MPoppetChatTimings();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024667()
	{
		return MPoppetChatTimings.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024668(MerlinMaster m, string[] strs)
	{
		(m as MPoppetChatTimings).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024669(MerlinMaster m)
	{
		MPoppetChatTimings.AddMst(m as MPoppetChatTimings);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024670()
	{
		MPoppetChats.Unload();
	}

	internal static MPoppetChats _0024InitLoadMethodTbl_0024closure_0024671()
	{
		return new MPoppetChats();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024672()
	{
		return MPoppetChats.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024673(MerlinMaster m, string[] strs)
	{
		(m as MPoppetChats).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024674(MerlinMaster m)
	{
		MPoppetChats.AddMst(m as MPoppetChats);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024675()
	{
		MPoppetPersonalities.Unload();
	}

	internal static MPoppetPersonalities _0024InitLoadMethodTbl_0024closure_0024676()
	{
		return new MPoppetPersonalities();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024677()
	{
		return MPoppetPersonalities.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024678(MerlinMaster m, string[] strs)
	{
		(m as MPoppetPersonalities).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024679(MerlinMaster m)
	{
		MPoppetPersonalities.AddMst(m as MPoppetPersonalities);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024680()
	{
		MPoppets.Unload();
	}

	internal static MPoppets _0024InitLoadMethodTbl_0024closure_0024681()
	{
		return new MPoppets();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024682()
	{
		return MPoppets.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024683(MerlinMaster m, string[] strs)
	{
		(m as MPoppets).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024684(MerlinMaster m)
	{
		MPoppets.AddMst(m as MPoppets);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024685()
	{
		MPresentTypes.Unload();
	}

	internal static MPresentTypes _0024InitLoadMethodTbl_0024closure_0024686()
	{
		return new MPresentTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024687()
	{
		return MPresentTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024688(MerlinMaster m, string[] strs)
	{
		(m as MPresentTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024689(MerlinMaster m)
	{
		MPresentTypes.AddMst(m as MPresentTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024690()
	{
		MProductSalesTypeValues.Unload();
	}

	internal static MProductSalesTypeValues _0024InitLoadMethodTbl_0024closure_0024691()
	{
		return new MProductSalesTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024692()
	{
		return MProductSalesTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024693(MerlinMaster m, string[] strs)
	{
		(m as MProductSalesTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024694(MerlinMaster m)
	{
		MProductSalesTypeValues.AddMst(m as MProductSalesTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024695()
	{
		MQuestClearTypes.Unload();
	}

	internal static MQuestClearTypes _0024InitLoadMethodTbl_0024closure_0024696()
	{
		return new MQuestClearTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024697()
	{
		return MQuestClearTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024698(MerlinMaster m, string[] strs)
	{
		(m as MQuestClearTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024699(MerlinMaster m)
	{
		MQuestClearTypes.AddMst(m as MQuestClearTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024700()
	{
		MQuestClears.Unload();
	}

	internal static MQuestClears _0024InitLoadMethodTbl_0024closure_0024701()
	{
		return new MQuestClears();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024702()
	{
		return MQuestClears.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024703(MerlinMaster m, string[] strs)
	{
		(m as MQuestClears).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024704(MerlinMaster m)
	{
		MQuestClears.AddMst(m as MQuestClears);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024705()
	{
		MQuestDrops.Unload();
	}

	internal static MQuestDrops _0024InitLoadMethodTbl_0024closure_0024706()
	{
		return new MQuestDrops();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024707()
	{
		return MQuestDrops.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024708(MerlinMaster m, string[] strs)
	{
		(m as MQuestDrops).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024709(MerlinMaster m)
	{
		MQuestDrops.AddMst(m as MQuestDrops);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024710()
	{
		MQuestFirstRewards.Unload();
	}

	internal static MQuestFirstRewards _0024InitLoadMethodTbl_0024closure_0024711()
	{
		return new MQuestFirstRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024712()
	{
		return MQuestFirstRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024713(MerlinMaster m, string[] strs)
	{
		(m as MQuestFirstRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024714(MerlinMaster m)
	{
		MQuestFirstRewards.AddMst(m as MQuestFirstRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024715()
	{
		MQuestMissions.Unload();
	}

	internal static MQuestMissions _0024InitLoadMethodTbl_0024closure_0024716()
	{
		return new MQuestMissions();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024717()
	{
		return MQuestMissions.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024718(MerlinMaster m, string[] strs)
	{
		(m as MQuestMissions).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024719(MerlinMaster m)
	{
		MQuestMissions.AddMst(m as MQuestMissions);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024720()
	{
		MQuestMonsters.Unload();
	}

	internal static MQuestMonsters _0024InitLoadMethodTbl_0024closure_0024721()
	{
		return new MQuestMonsters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024722()
	{
		return MQuestMonsters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024723(MerlinMaster m, string[] strs)
	{
		(m as MQuestMonsters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024724(MerlinMaster m)
	{
		MQuestMonsters.AddMst(m as MQuestMonsters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024725()
	{
		MQuestRewards.Unload();
	}

	internal static MQuestRewards _0024InitLoadMethodTbl_0024closure_0024736()
	{
		return new MQuestRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024737()
	{
		return MQuestRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024738(MerlinMaster m, string[] strs)
	{
		(m as MQuestRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024739(MerlinMaster m)
	{
		MQuestRewards.AddMst(m as MQuestRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024740()
	{
		MQuestTickets.Unload();
	}

	internal static MQuestTickets _0024InitLoadMethodTbl_0024closure_0024741()
	{
		return new MQuestTickets();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024742()
	{
		return MQuestTickets.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024743(MerlinMaster m, string[] strs)
	{
		(m as MQuestTickets).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024744(MerlinMaster m)
	{
		MQuestTickets.AddMst(m as MQuestTickets);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024745()
	{
		MQuestTypes.Unload();
	}

	internal static MQuestTypes _0024InitLoadMethodTbl_0024closure_0024746()
	{
		return new MQuestTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024747()
	{
		return MQuestTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024748(MerlinMaster m, string[] strs)
	{
		(m as MQuestTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024749(MerlinMaster m)
	{
		MQuestTypes.AddMst(m as MQuestTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024750()
	{
		MQuests.Unload();
	}

	internal static MQuests _0024InitLoadMethodTbl_0024closure_0024751()
	{
		return new MQuests();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024752()
	{
		return MQuests.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024753(MerlinMaster m, string[] strs)
	{
		(m as MQuests).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024754(MerlinMaster m)
	{
		MQuests.AddMst(m as MQuests);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024755()
	{
		MRaces.Unload();
	}

	internal static MRaces _0024InitLoadMethodTbl_0024closure_0024756()
	{
		return new MRaces();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024757()
	{
		return MRaces.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024758(MerlinMaster m, string[] strs)
	{
		(m as MRaces).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024759(MerlinMaster m)
	{
		MRaces.AddMst(m as MRaces);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024760()
	{
		MRaidBattleRewards.Unload();
	}

	internal static MRaidBattleRewards _0024InitLoadMethodTbl_0024closure_0024761()
	{
		return new MRaidBattleRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024762()
	{
		return MRaidBattleRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024763(MerlinMaster m, string[] strs)
	{
		(m as MRaidBattleRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024764(MerlinMaster m)
	{
		MRaidBattleRewards.AddMst(m as MRaidBattleRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024765()
	{
		MRaidBattles.Unload();
	}

	internal static MRaidBattles _0024InitLoadMethodTbl_0024closure_0024766()
	{
		return new MRaidBattles();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024767()
	{
		return MRaidBattles.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024768(MerlinMaster m, string[] strs)
	{
		(m as MRaidBattles).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024769(MerlinMaster m)
	{
		MRaidBattles.AddMst(m as MRaidBattles);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024770()
	{
		MRaidTutorialRewards.Unload();
	}

	internal static MRaidTutorialRewards _0024InitLoadMethodTbl_0024closure_0024771()
	{
		return new MRaidTutorialRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024772()
	{
		return MRaidTutorialRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024773(MerlinMaster m, string[] strs)
	{
		(m as MRaidTutorialRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024774(MerlinMaster m)
	{
		MRaidTutorialRewards.AddMst(m as MRaidTutorialRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024775()
	{
		MRaidWordTypes.Unload();
	}

	internal static MRaidWordTypes _0024InitLoadMethodTbl_0024closure_0024776()
	{
		return new MRaidWordTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024777()
	{
		return MRaidWordTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024778(MerlinMaster m, string[] strs)
	{
		(m as MRaidWordTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024779(MerlinMaster m)
	{
		MRaidWordTypes.AddMst(m as MRaidWordTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024780()
	{
		MRaidWords.Unload();
	}

	internal static MRaidWords _0024InitLoadMethodTbl_0024closure_0024781()
	{
		return new MRaidWords();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024782()
	{
		return MRaidWords.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024783(MerlinMaster m, string[] strs)
	{
		(m as MRaidWords).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024784(MerlinMaster m)
	{
		MRaidWords.AddMst(m as MRaidWords);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024785()
	{
		MRankingRewardTypes.Unload();
	}

	internal static MRankingRewardTypes _0024InitLoadMethodTbl_0024closure_0024786()
	{
		return new MRankingRewardTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024787()
	{
		return MRankingRewardTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024788(MerlinMaster m, string[] strs)
	{
		(m as MRankingRewardTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024789(MerlinMaster m)
	{
		MRankingRewardTypes.AddMst(m as MRankingRewardTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024790()
	{
		MRankingRewards.Unload();
	}

	internal static MRankingRewards _0024InitLoadMethodTbl_0024closure_0024791()
	{
		return new MRankingRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024792()
	{
		return MRankingRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024793(MerlinMaster m, string[] strs)
	{
		(m as MRankingRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024794(MerlinMaster m)
	{
		MRankingRewards.AddMst(m as MRankingRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024795()
	{
		MRares.Unload();
	}

	internal static MRares _0024InitLoadMethodTbl_0024closure_0024796()
	{
		return new MRares();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024797()
	{
		return MRares.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024798(MerlinMaster m, string[] strs)
	{
		(m as MRares).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024799(MerlinMaster m)
	{
		MRares.AddMst(m as MRares);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024800()
	{
		MSaleGachaGroups.Unload();
	}

	internal static MSaleGachaGroups _0024InitLoadMethodTbl_0024closure_0024801()
	{
		return new MSaleGachaGroups();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024802()
	{
		return MSaleGachaGroups.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024803(MerlinMaster m, string[] strs)
	{
		(m as MSaleGachaGroups).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024804(MerlinMaster m)
	{
		MSaleGachaGroups.AddMst(m as MSaleGachaGroups);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024805()
	{
		MSaleGachas.Unload();
	}

	internal static MSaleGachas _0024InitLoadMethodTbl_0024closure_0024806()
	{
		return new MSaleGachas();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024807()
	{
		return MSaleGachas.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024808(MerlinMaster m, string[] strs)
	{
		(m as MSaleGachas).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024809(MerlinMaster m)
	{
		MSaleGachas.AddMst(m as MSaleGachas);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024810()
	{
		MSaleTypeValues.Unload();
	}

	internal static MSaleTypeValues _0024InitLoadMethodTbl_0024closure_0024811()
	{
		return new MSaleTypeValues();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024812()
	{
		return MSaleTypeValues.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024813(MerlinMaster m, string[] strs)
	{
		(m as MSaleTypeValues).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024814(MerlinMaster m)
	{
		MSaleTypeValues.AddMst(m as MSaleTypeValues);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024815()
	{
		MSceneBgm.Unload();
	}

	internal static MSceneBgm _0024InitLoadMethodTbl_0024closure_0024816()
	{
		return new MSceneBgm();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024817()
	{
		return MSceneBgm.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024818(MerlinMaster m, string[] strs)
	{
		(m as MSceneBgm).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024819(MerlinMaster m)
	{
		MSceneBgm.AddMst(m as MSceneBgm);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024820()
	{
		MScenes.Unload();
	}

	internal static MScenes _0024InitLoadMethodTbl_0024closure_0024821()
	{
		return new MScenes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024822()
	{
		return MScenes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024823(MerlinMaster m, string[] strs)
	{
		(m as MScenes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024824(MerlinMaster m)
	{
		MScenes.AddMst(m as MScenes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024825()
	{
		MSe.Unload();
	}

	internal static MSe _0024InitLoadMethodTbl_0024closure_0024826()
	{
		return new MSe();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024827()
	{
		return MSe.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024828(MerlinMaster m, string[] strs)
	{
		(m as MSe).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024829(MerlinMaster m)
	{
		MSe.AddMst(m as MSe);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024830()
	{
		MSeTypes.Unload();
	}

	internal static MSeTypes _0024InitLoadMethodTbl_0024closure_0024831()
	{
		return new MSeTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024832()
	{
		return MSeTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024833(MerlinMaster m, string[] strs)
	{
		(m as MSeTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024834(MerlinMaster m)
	{
		MSeTypes.AddMst(m as MSeTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024835()
	{
		MSellTypes.Unload();
	}

	internal static MSellTypes _0024InitLoadMethodTbl_0024closure_0024836()
	{
		return new MSellTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024837()
	{
		return MSellTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024838(MerlinMaster m, string[] strs)
	{
		(m as MSellTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024839(MerlinMaster m)
	{
		MSellTypes.AddMst(m as MSellTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024840()
	{
		MSerialCampaigns.Unload();
	}

	internal static MSerialCampaigns _0024InitLoadMethodTbl_0024closure_0024841()
	{
		return new MSerialCampaigns();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024842()
	{
		return MSerialCampaigns.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024843(MerlinMaster m, string[] strs)
	{
		(m as MSerialCampaigns).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024844(MerlinMaster m)
	{
		MSerialCampaigns.AddMst(m as MSerialCampaigns);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024845()
	{
		MShopItems.Unload();
	}

	internal static MShopItems _0024InitLoadMethodTbl_0024closure_0024846()
	{
		return new MShopItems();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024847()
	{
		return MShopItems.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024848(MerlinMaster m, string[] strs)
	{
		(m as MShopItems).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024849(MerlinMaster m)
	{
		MShopItems.AddMst(m as MShopItems);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024850()
	{
		MShopMessage.Unload();
	}

	internal static MShopMessage _0024InitLoadMethodTbl_0024closure_0024851()
	{
		return new MShopMessage();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024852()
	{
		return MShopMessage.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024853(MerlinMaster m, string[] strs)
	{
		(m as MShopMessage).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024854(MerlinMaster m)
	{
		MShopMessage.AddMst(m as MShopMessage);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024855()
	{
		MShopMessageTypes.Unload();
	}

	internal static MShopMessageTypes _0024InitLoadMethodTbl_0024closure_0024856()
	{
		return new MShopMessageTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024857()
	{
		return MShopMessageTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024858(MerlinMaster m, string[] strs)
	{
		(m as MShopMessageTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024859(MerlinMaster m)
	{
		MShopMessageTypes.AddMst(m as MShopMessageTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024860()
	{
		MShortcutChildIcons.Unload();
	}

	internal static MShortcutChildIcons _0024InitLoadMethodTbl_0024closure_0024861()
	{
		return new MShortcutChildIcons();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024862()
	{
		return MShortcutChildIcons.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024863(MerlinMaster m, string[] strs)
	{
		(m as MShortcutChildIcons).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024864(MerlinMaster m)
	{
		MShortcutChildIcons.AddMst(m as MShortcutChildIcons);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024865()
	{
		MShortcutIcons.Unload();
	}

	internal static MShortcutIcons _0024InitLoadMethodTbl_0024closure_0024866()
	{
		return new MShortcutIcons();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024867()
	{
		return MShortcutIcons.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024868(MerlinMaster m, string[] strs)
	{
		(m as MShortcutIcons).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024869(MerlinMaster m)
	{
		MShortcutIcons.AddMst(m as MShortcutIcons);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024870()
	{
		MSkillActionTypes.Unload();
	}

	internal static MSkillActionTypes _0024InitLoadMethodTbl_0024closure_0024871()
	{
		return new MSkillActionTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024872()
	{
		return MSkillActionTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024873(MerlinMaster m, string[] strs)
	{
		(m as MSkillActionTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024874(MerlinMaster m)
	{
		MSkillActionTypes.AddMst(m as MSkillActionTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024875()
	{
		MSkillEffectTypes.Unload();
	}

	internal static MSkillEffectTypes _0024InitLoadMethodTbl_0024closure_0024876()
	{
		return new MSkillEffectTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024877()
	{
		return MSkillEffectTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024878(MerlinMaster m, string[] strs)
	{
		(m as MSkillEffectTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024879(MerlinMaster m)
	{
		MSkillEffectTypes.AddMst(m as MSkillEffectTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024880()
	{
		MStageBattles.Unload();
	}

	internal static MStageBattles _0024InitLoadMethodTbl_0024closure_0024881()
	{
		return new MStageBattles();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024882()
	{
		return MStageBattles.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024883(MerlinMaster m, string[] strs)
	{
		(m as MStageBattles).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024884(MerlinMaster m)
	{
		MStageBattles.AddMst(m as MStageBattles);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024885()
	{
		MStageMonsters.Unload();
	}

	internal static MStageMonsters _0024InitLoadMethodTbl_0024closure_0024886()
	{
		return new MStageMonsters();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024887()
	{
		return MStageMonsters.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024888(MerlinMaster m, string[] strs)
	{
		(m as MStageMonsters).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024889(MerlinMaster m)
	{
		MStageMonsters.AddMst(m as MStageMonsters);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024890()
	{
		MStages.Unload();
	}

	internal static MStages _0024InitLoadMethodTbl_0024closure_0024891()
	{
		return new MStages();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024892()
	{
		return MStages.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024893(MerlinMaster m, string[] strs)
	{
		(m as MStages).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024894(MerlinMaster m)
	{
		MStages.AddMst(m as MStages);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024895()
	{
		MStatus.Unload();
	}

	internal static MStatus _0024InitLoadMethodTbl_0024closure_0024896()
	{
		return new MStatus();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024897()
	{
		return MStatus.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024898(MerlinMaster m, string[] strs)
	{
		(m as MStatus).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024899(MerlinMaster m)
	{
		MStatus.AddMst(m as MStatus);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024900()
	{
		MStepGachaTypes.Unload();
	}

	internal static MStepGachaTypes _0024InitLoadMethodTbl_0024closure_0024901()
	{
		return new MStepGachaTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024902()
	{
		return MStepGachaTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024903(MerlinMaster m, string[] strs)
	{
		(m as MStepGachaTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024904(MerlinMaster m)
	{
		MStepGachaTypes.AddMst(m as MStepGachaTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024905()
	{
		MStories.Unload();
	}

	internal static MStories _0024InitLoadMethodTbl_0024closure_0024906()
	{
		return new MStories();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024907()
	{
		return MStories.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024908(MerlinMaster m, string[] strs)
	{
		(m as MStories).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024909(MerlinMaster m)
	{
		MStories.AddMst(m as MStories);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024910()
	{
		MStoryBooks.Unload();
	}

	internal static MStoryBooks _0024InitLoadMethodTbl_0024closure_0024911()
	{
		return new MStoryBooks();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024912()
	{
		return MStoryBooks.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024913(MerlinMaster m, string[] strs)
	{
		(m as MStoryBooks).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024914(MerlinMaster m)
	{
		MStoryBooks.AddMst(m as MStoryBooks);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024915()
	{
		MStoryGroups.Unload();
	}

	internal static MStoryGroups _0024InitLoadMethodTbl_0024closure_0024916()
	{
		return new MStoryGroups();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024917()
	{
		return MStoryGroups.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024918(MerlinMaster m, string[] strs)
	{
		(m as MStoryGroups).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024919(MerlinMaster m)
	{
		MStoryGroups.AddMst(m as MStoryGroups);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024920()
	{
		MStyles.Unload();
	}

	internal static MStyles _0024InitLoadMethodTbl_0024closure_0024921()
	{
		return new MStyles();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024922()
	{
		return MStyles.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024923(MerlinMaster m, string[] strs)
	{
		(m as MStyles).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024924(MerlinMaster m)
	{
		MStyles.AddMst(m as MStyles);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024925()
	{
		MTexts.Unload();
	}

	internal static MTexts _0024InitLoadMethodTbl_0024closure_0024926()
	{
		return new MTexts();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024927()
	{
		return MTexts.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024928(MerlinMaster m, string[] strs)
	{
		(m as MTexts).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024929(MerlinMaster m)
	{
		MTexts.AddMst(m as MTexts);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024930()
	{
		MTipsMessage.Unload();
	}

	internal static MTipsMessage _0024InitLoadMethodTbl_0024closure_0024931()
	{
		return new MTipsMessage();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024932()
	{
		return MTipsMessage.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024933(MerlinMaster m, string[] strs)
	{
		(m as MTipsMessage).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024934(MerlinMaster m)
	{
		MTipsMessage.AddMst(m as MTipsMessage);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024935()
	{
		MTraits.Unload();
	}

	internal static MTraits _0024InitLoadMethodTbl_0024closure_0024936()
	{
		return new MTraits();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024937()
	{
		return MTraits.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024938(MerlinMaster m, string[] strs)
	{
		(m as MTraits).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024939(MerlinMaster m)
	{
		MTraits.AddMst(m as MTraits);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024940()
	{
		MTutorialItems.Unload();
	}

	internal static MTutorialItems _0024InitLoadMethodTbl_0024closure_0024941()
	{
		return new MTutorialItems();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024942()
	{
		return MTutorialItems.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024943(MerlinMaster m, string[] strs)
	{
		(m as MTutorialItems).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024944(MerlinMaster m)
	{
		MTutorialItems.AddMst(m as MTutorialItems);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024945()
	{
		MTutorialMessages.Unload();
	}

	internal static MTutorialMessages _0024InitLoadMethodTbl_0024closure_0024946()
	{
		return new MTutorialMessages();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024947()
	{
		return MTutorialMessages.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024948(MerlinMaster m, string[] strs)
	{
		(m as MTutorialMessages).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024949(MerlinMaster m)
	{
		MTutorialMessages.AddMst(m as MTutorialMessages);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024950()
	{
		MTutorials.Unload();
	}

	internal static MTutorials _0024InitLoadMethodTbl_0024closure_0024951()
	{
		return new MTutorials();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024952()
	{
		return MTutorials.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024953(MerlinMaster m, string[] strs)
	{
		(m as MTutorials).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024954(MerlinMaster m)
	{
		MTutorials.AddMst(m as MTutorials);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024955()
	{
		MWarps.Unload();
	}

	internal static MWarps _0024InitLoadMethodTbl_0024closure_0024956()
	{
		return new MWarps();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024957()
	{
		return MWarps.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024958(MerlinMaster m, string[] strs)
	{
		(m as MWarps).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024959(MerlinMaster m)
	{
		MWarps.AddMst(m as MWarps);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024960()
	{
		MWeaponSkills.Unload();
	}

	internal static MWeaponSkills _0024InitLoadMethodTbl_0024closure_0024961()
	{
		return new MWeaponSkills();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024962()
	{
		return MWeaponSkills.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024963(MerlinMaster m, string[] strs)
	{
		(m as MWeaponSkills).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024964(MerlinMaster m)
	{
		MWeaponSkills.AddMst(m as MWeaponSkills);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024965()
	{
		MWeapons.Unload();
	}

	internal static MWeapons _0024InitLoadMethodTbl_0024closure_0024966()
	{
		return new MWeapons();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024967()
	{
		return MWeapons.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024968(MerlinMaster m, string[] strs)
	{
		(m as MWeapons).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024969(MerlinMaster m)
	{
		MWeapons.AddMst(m as MWeapons);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024970()
	{
		MWeek.Unload();
	}

	internal static MWeek _0024InitLoadMethodTbl_0024closure_0024971()
	{
		return new MWeek();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024972()
	{
		return MWeek.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024973(MerlinMaster m, string[] strs)
	{
		(m as MWeek).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024974(MerlinMaster m)
	{
		MWeek.AddMst(m as MWeek);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024975()
	{
		MWeekBonus.Unload();
	}

	internal static MWeekBonus _0024InitLoadMethodTbl_0024closure_0024976()
	{
		return new MWeekBonus();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024977()
	{
		return MWeekBonus.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024978(MerlinMaster m, string[] strs)
	{
		(m as MWeekBonus).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024979(MerlinMaster m)
	{
		MWeekBonus.AddMst(m as MWeekBonus);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024980()
	{
		MWeekEvents.Unload();
	}

	internal static MWeekEvents _0024InitLoadMethodTbl_0024closure_0024981()
	{
		return new MWeekEvents();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024982()
	{
		return MWeekEvents.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024983(MerlinMaster m, string[] strs)
	{
		(m as MWeekEvents).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024984(MerlinMaster m)
	{
		MWeekEvents.AddMst(m as MWeekEvents);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024985()
	{
		MWholeRewards.Unload();
	}

	internal static MWholeRewards _0024InitLoadMethodTbl_0024closure_0024986()
	{
		return new MWholeRewards();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024987()
	{
		return MWholeRewards.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024988(MerlinMaster m, string[] strs)
	{
		(m as MWholeRewards).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024989(MerlinMaster m)
	{
		MWholeRewards.AddMst(m as MWholeRewards);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024990()
	{
		MWindowTypes.Unload();
	}

	internal static MWindowTypes _0024InitLoadMethodTbl_0024closure_0024991()
	{
		return new MWindowTypes();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024992()
	{
		return MWindowTypes.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024993(MerlinMaster m, string[] strs)
	{
		(m as MWindowTypes).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024994(MerlinMaster m)
	{
		MWindowTypes.AddMst(m as MWindowTypes);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024995()
	{
		MURLSchemeAPI.Unload();
	}

	internal static MURLSchemeAPI _0024InitLoadMethodTbl_0024closure_0024996()
	{
		return new MURLSchemeAPI();
	}

	internal static string[] _0024InitLoadMethodTbl_0024closure_0024997()
	{
		return MURLSchemeAPI.KeyNameList();
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024998(MerlinMaster m, string[] strs)
	{
		(m as MURLSchemeAPI).setStringValues(strs);
	}

	internal static void _0024InitLoadMethodTbl_0024closure_0024999(MerlinMaster m)
	{
		MURLSchemeAPI.AddMst(m as MURLSchemeAPI);
	}
}
