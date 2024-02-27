using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubModeMaster : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024263;

		public string _0024act_0024t_0024264;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024265;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024266;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024267;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024268;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024269;

		public __ActionBase__0024act_0024t_0024265_0024callable13_002419_5__ _0024act_0024t_0024270;

		public __ActionBase__0024act_0024t_0024271_0024callable14_002419_5__ _0024act_0024t_0024271;

		public IEnumerator _0024act_0024t_0024275;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024263.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
		public Boo.Lang.List<string> mstKeys;
	}

	[Serializable]
	public class ActionClassmasterBrowseMode : ActionBase
	{
		public Type mstType;

		public Boo.Lang.List<MerlinMaster> data;
	}

	[Serializable]
	public class ActionClassdetailViewMode : ActionBase
	{
		public MerlinMaster mst;

		public Type[] fieldTypes;

		public PropertyInfo[] props;

		public object[] values;
	}

	[Serializable]
	public class ActionClassweekEventEditMode : ActionBase
	{
		public MQuests mst;

		public MStories mstory;

		public Boo.Lang.List<MWeekEvents> wevents;
	}

	[Serializable]
	public class ActionClassdateTimeEditMode : ActionBase
	{
		public MerlinMaster mst;

		public PropertyInfo propInfo;

		public DateTime valDateTime;

		public int[] values;

		public string errmsg;
	}

	[Serializable]
	public enum ActionEnum
	{
		dateTimeEditMode,
		weekEventEditMode,
		detailViewMode,
		masterBrowseMode,
		mainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024editInt_0024locals_002414283
	{
		internal int _0024v;

		internal GUILayoutOption _0024bw;

		internal GUILayoutOption _0024vw;

		internal int _0024min;

		internal int _0024max;

		internal string _0024unit;
	}

	[Serializable]
	internal class _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284
	{
		internal GUILayoutOption _0024bw;

		internal ActionClassmasterBrowseMode _0024_0024act_0024t_0024278;
	}

	[Serializable]
	internal class _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285
	{
		internal GUILayoutOption _0024ebtnwidth;

		internal object _0024val;

		internal ActionClassdetailViewMode _0024_0024act_0024t_0024281;
	}

	[Serializable]
	internal class _0024_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545_0024closure_00243546
	{
		internal DebugSubModeMaster _0024this_002414644;

		internal _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414645;

		public _0024_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545_0024closure_00243546(DebugSubModeMaster _0024this_002414644, _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414645)
		{
			this._0024this_002414644 = _0024this_002414644;
			this._0024_0024locals_002414645 = _0024_0024locals_002414645;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("先頭へ"))
			{
				_0024this_002414644.viewTop = 0;
			}
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("前へ"))
				{
					_0024this_002414644.viewTop = Math.Max(0, _0024this_002414644.viewTop - _0024this_002414644.viewNum);
				}
				if (RuntimeDebugModeGuiMixin.button("次へ"))
				{
					_0024this_002414644.viewTop = Math.Min(_0024_0024locals_002414645._0024_0024act_0024t_0024278.data.Count - 1, _0024this_002414644.viewTop + _0024this_002414644.viewNum);
				}
				if (RuntimeDebugModeGuiMixin.button("最後へ"))
				{
					_0024this_002414644.viewTop = unchecked(_0024_0024locals_002414645._0024_0024act_0024t_0024278.data.Count / _0024this_002414644.viewNum) * _0024this_002414644.viewNum;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545
	{
		internal _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414646;

		internal DebugSubModeMaster _0024this_002414647;

		public _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414646, DebugSubModeMaster _0024this_002414647)
		{
			this._0024_0024locals_002414646 = _0024_0024locals_002414646;
			this._0024this_002414647 = _0024this_002414647;
		}

		public void Invoke()
		{
			if (_0024_0024locals_002414646._0024_0024act_0024t_0024278.data == null)
			{
				RuntimeDebugModeGuiMixin.label("あれあれ?");
				return;
			}
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)checked(_0024this_002414647.viewTop + 1)).Append("/").Append((object)_0024_0024locals_002414646._0024_0024act_0024t_0024278.data.Count)
				.ToString());
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545_0024closure_00243546(_0024this_002414647, _0024_0024locals_002414646).Invoke));
		}
	}

	[Serializable]
	internal class _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024closure_00243547
	{
		internal _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414648;

		internal DebugSubModeMaster _0024this_002414649;

		internal int _0024i_002414650;

		public _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024closure_00243547(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024locals_002414648, DebugSubModeMaster _0024this_002414649, int _0024i_002414650)
		{
			this._0024_0024locals_002414648 = _0024_0024locals_002414648;
			this._0024this_002414649 = _0024this_002414649;
			this._0024i_002414650 = _0024i_002414650;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("詳細", _0024_0024locals_002414648._0024bw))
			{
				_0024this_002414649.detailViewMode(_0024_0024locals_002414648._0024_0024act_0024t_0024278.data[_0024i_002414650]);
			}
			string text = _0024_0024locals_002414648._0024_0024act_0024t_0024278.data[_0024i_002414650].ToDebugModeString();
			if (_0024this_002414649.lastViewTypeIdInfo != null)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024this_002414649.lastViewTypeIdInfo.GetValue(_0024_0024locals_002414648._0024_0024act_0024t_0024278.data[_0024i_002414650])).Append(" ").ToString() + text);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(text);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatadetailViewMode_0024closure_00243551_0024closure_00243552
	{
		internal int _0024i_002414651;

		internal _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285 _0024_0024locals_002414652;

		internal DebugSubModeMaster _0024this_002414653;

		public _0024_0024createDatadetailViewMode_0024closure_00243551_0024closure_00243552(int _0024i_002414651, _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285 _0024_0024locals_002414652, DebugSubModeMaster _0024this_002414653)
		{
			this._0024i_002414651 = _0024i_002414651;
			this._0024_0024locals_002414652 = _0024_0024locals_002414652;
			this._0024this_002414653 = _0024this_002414653;
		}

		public void Invoke()
		{
			StringBuilder stringBuilder = new StringBuilder();
			PropertyInfo[] props = _0024_0024locals_002414652._0024_0024act_0024t_0024281.props;
			RuntimeDebugModeGuiMixin.slabel(stringBuilder.Append(props[RuntimeServices.NormalizeArrayIndex(props, _0024i_002414651)].Name).Append(": ").Append(_0024_0024locals_002414652._0024val)
				.ToString());
			if (RuntimeDebugModeGuiMixin.button("日付編集", _0024_0024locals_002414652._0024ebtnwidth))
			{
				DebugSubModeMaster debugSubModeMaster = _0024this_002414653;
				MerlinMaster mst = _0024_0024locals_002414652._0024_0024act_0024t_0024281.mst;
				PropertyInfo[] props2 = _0024_0024locals_002414652._0024_0024act_0024t_0024281.props;
				debugSubModeMaster.dateTimeEditMode(mst, props2[RuntimeServices.NormalizeArrayIndex(props2, _0024i_002414651)]);
			}
		}
	}

	[Serializable]
	internal class _0024editInt_0024closure_00243560
	{
		internal _0024editInt_0024locals_002414283 _0024_0024locals_002414654;

		public _0024editInt_0024closure_00243560(_0024editInt_0024locals_002414283 _0024_0024locals_002414654)
		{
			this._0024_0024locals_002414654 = _0024_0024locals_002414654;
		}

		public void Invoke()
		{
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("←", _0024_0024locals_002414654._0024bw))
				{
					_0024_0024locals_002414654._0024v = Math.Max(_0024_0024locals_002414654._0024min, _0024_0024locals_002414654._0024v - 1);
				}
				RuntimeDebugModeGuiMixin.label(new StringBuilder().Append((object)_0024_0024locals_002414654._0024v).Append(" ").Append(_0024_0024locals_002414654._0024unit)
					.ToString(), _0024_0024locals_002414654._0024vw);
				if (RuntimeDebugModeGuiMixin.button("→", _0024_0024locals_002414654._0024bw))
				{
					_0024_0024locals_002414654._0024v = Math.Min(_0024_0024locals_002414654._0024max, _0024_0024locals_002414654._0024v + 1);
				}
			}
		}
	}

	private Dictionary<string, ActionBase> _0024act_0024t_0024272;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024274;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024273;

	public bool actionDebugFlag;

	private Type lastViewType;

	private FieldInfo lastViewTypeIdInfo;

	private int viewTop;

	private int viewNum;

	private Boo.Lang.List<MerlinMaster> data;

	[NonSerialized]
	public static readonly Hashtable AllMasters = new Hash
	{
		{
			"MAbnormalStates",
			new Hash
			{
				{
					"type",
					typeof(MAbnormalStates)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MAbnormalStates.All.Length)
				}
			}
		},
		{
			"MAreaGroups",
			new Hash
			{
				{
					"type",
					typeof(MAreaGroups)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MAreaGroups.All.Length)
				}
			}
		},
		{
			"MAreaTypes",
			new Hash
			{
				{
					"type",
					typeof(MAreaTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MAreaTypes.All.Length)
				}
			}
		},
		{
			"MAreas",
			new Hash
			{
				{
					"type",
					typeof(MAreas)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MAreas.All.Length)
				}
			}
		},
		{
			"MBgm",
			new Hash
			{
				{
					"type",
					typeof(MBgm)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MBgm.All.Length)
				}
			}
		},
		{
			"MBreederRanks",
			new Hash
			{
				{
					"type",
					typeof(MBreederRanks)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MBreederRanks.All.Length)
				}
			}
		},
		{
			"MCampaignSegmentTypes",
			new Hash
			{
				{
					"type",
					typeof(MCampaignSegmentTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCampaignSegmentTypes.All.Length)
				}
			}
		},
		{
			"MCampaignTypes",
			new Hash
			{
				{
					"type",
					typeof(MCampaignTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCampaignTypes.All.Length)
				}
			}
		},
		{
			"MCampaigns",
			new Hash
			{
				{
					"type",
					typeof(MCampaigns)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCampaigns.All.Length)
				}
			}
		},
		{
			"MChainSkillEffects",
			new Hash
			{
				{
					"type",
					typeof(MChainSkillEffects)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MChainSkillEffects.All.Length)
				}
			}
		},
		{
			"MChainSkills",
			new Hash
			{
				{
					"type",
					typeof(MChainSkills)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MChainSkills.All.Length)
				}
			}
		},
		{
			"MChangeDeckMains",
			new Hash
			{
				{
					"type",
					typeof(MChangeDeckMains)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MChangeDeckMains.All.Length)
				}
			}
		},
		{
			"MChangeDeckSupports",
			new Hash
			{
				{
					"type",
					typeof(MChangeDeckSupports)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MChangeDeckSupports.All.Length)
				}
			}
		},
		{
			"MChangePoppetDecks",
			new Hash
			{
				{
					"type",
					typeof(MChangePoppetDecks)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MChangePoppetDecks.All.Length)
				}
			}
		},
		{
			"MCharacterActionTypes",
			new Hash
			{
				{
					"type",
					typeof(MCharacterActionTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCharacterActionTypes.All.Length)
				}
			}
		},
		{
			"MCharacteristics",
			new Hash
			{
				{
					"type",
					typeof(MCharacteristics)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCharacteristics.All.Length)
				}
			}
		},
		{
			"MColosseumEventRankingRewards",
			new Hash
			{
				{
					"type",
					typeof(MColosseumEventRankingRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MColosseumEventRankingRewards.All.Length)
				}
			}
		},
		{
			"MColosseumEventRewards",
			new Hash
			{
				{
					"type",
					typeof(MColosseumEventRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MColosseumEventRewards.All.Length)
				}
			}
		},
		{
			"MColosseumEvents",
			new Hash
			{
				{
					"type",
					typeof(MColosseumEvents)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MColosseumEvents.All.Length)
				}
			}
		},
		{
			"MColosseumNpcOrganizes",
			new Hash
			{
				{
					"type",
					typeof(MColosseumNpcOrganizes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MColosseumNpcOrganizes.All.Length)
				}
			}
		},
		{
			"MColosseumNpcs",
			new Hash
			{
				{
					"type",
					typeof(MColosseumNpcs)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MColosseumNpcs.All.Length)
				}
			}
		},
		{
			"MComboBonus",
			new Hash
			{
				{
					"type",
					typeof(MComboBonus)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MComboBonus.All.Length)
				}
			}
		},
		{
			"MCoverSkills",
			new Hash
			{
				{
					"type",
					typeof(MCoverSkills)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCoverSkills.All.Length)
				}
			}
		},
		{
			"MCycleSchedules",
			new Hash
			{
				{
					"type",
					typeof(MCycleSchedules)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MCycleSchedules.All.Length)
				}
			}
		},
		{
			"MDebugRaidBossData",
			new Hash
			{
				{
					"type",
					typeof(MDebugRaidBossData)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MDebugRaidBossData.All.Length)
				}
			}
		},
		{
			"MElementCorrelations",
			new Hash
			{
				{
					"type",
					typeof(MElementCorrelations)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MElementCorrelations.All.Length)
				}
			}
		},
		{
			"MElements",
			new Hash
			{
				{
					"type",
					typeof(MElements)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MElements.All.Length)
				}
			}
		},
		{
			"MEventQuestRankingRewards",
			new Hash
			{
				{
					"type",
					typeof(MEventQuestRankingRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MEventQuestRankingRewards.All.Length)
				}
			}
		},
		{
			"MEventQuestRewards",
			new Hash
			{
				{
					"type",
					typeof(MEventQuestRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MEventQuestRewards.All.Length)
				}
			}
		},
		{
			"MFixedEmissionGachas",
			new Hash
			{
				{
					"type",
					typeof(MFixedEmissionGachas)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MFixedEmissionGachas.All.Length)
				}
			}
		},
		{
			"MFlags",
			new Hash
			{
				{
					"type",
					typeof(MFlags)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MFlags.All.Length)
				}
			}
		},
		{
			"MGachaRewards",
			new Hash
			{
				{
					"type",
					typeof(MGachaRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGachaRewards.All.Length)
				}
			}
		},
		{
			"MGachaTypeValues",
			new Hash
			{
				{
					"type",
					typeof(MGachaTypeValues)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGachaTypeValues.All.Length)
				}
			}
		},
		{
			"MGachaTypesForClient",
			new Hash
			{
				{
					"type",
					typeof(MGachaTypesForClient)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGachaTypesForClient.All.Length)
				}
			}
		},
		{
			"MGachas",
			new Hash
			{
				{
					"type",
					typeof(MGachas)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGachas.All.Length)
				}
			}
		},
		{
			"MGameObjectNames",
			new Hash
			{
				{
					"type",
					typeof(MGameObjectNames)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGameObjectNames.All.Length)
				}
			}
		},
		{
			"MGameParameters",
			new Hash
			{
				{
					"type",
					typeof(MGameParameters)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGameParameters.All.Length)
				}
			}
		},
		{
			"MGenders",
			new Hash
			{
				{
					"type",
					typeof(MGenders)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MGenders.All.Length)
				}
			}
		},
		{
			"MHonors",
			new Hash
			{
				{
					"type",
					typeof(MHonors)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MHonors.All.Length)
				}
			}
		},
		{
			"MInAppProducts",
			new Hash
			{
				{
					"type",
					typeof(MInAppProducts)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MInAppProducts.All.Length)
				}
			}
		},
		{
			"MInviteRewards",
			new Hash
			{
				{
					"type",
					typeof(MInviteRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MInviteRewards.All.Length)
				}
			}
		},
		{
			"MItemTypes",
			new Hash
			{
				{
					"type",
					typeof(MItemTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MItemTypes.All.Length)
				}
			}
		},
		{
			"MKeyItems",
			new Hash
			{
				{
					"type",
					typeof(MKeyItems)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MKeyItems.All.Length)
				}
			}
		},
		{
			"MKusamushi",
			new Hash
			{
				{
					"type",
					typeof(MKusamushi)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MKusamushi.All.Length)
				}
			}
		},
		{
			"MLevelUpTypes",
			new Hash
			{
				{
					"type",
					typeof(MLevelUpTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MLevelUpTypes.All.Length)
				}
			}
		},
		{
			"MLoginBonusItems",
			new Hash
			{
				{
					"type",
					typeof(MLoginBonusItems)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MLoginBonusItems.All.Length)
				}
			}
		},
		{
			"MLoginBonusTypeValues",
			new Hash
			{
				{
					"type",
					typeof(MLoginBonusTypeValues)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MLoginBonusTypeValues.All.Length)
				}
			}
		},
		{
			"MLoginBonuses",
			new Hash
			{
				{
					"type",
					typeof(MLoginBonuses)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MLoginBonuses.All.Length)
				}
			}
		},
		{
			"MLoginRewards",
			new Hash
			{
				{
					"type",
					typeof(MLoginRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MLoginRewards.All.Length)
				}
			}
		},
		{
			"MMapLinkDir",
			new Hash
			{
				{
					"type",
					typeof(MMapLinkDir)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MMapLinkDir.All.Length)
				}
			}
		},
		{
			"MMarketTypeValues",
			new Hash
			{
				{
					"type",
					typeof(MMarketTypeValues)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MMarketTypeValues.All.Length)
				}
			}
		},
		{
			"MMasterTypeValues",
			new Hash
			{
				{
					"type",
					typeof(MMasterTypeValues)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MMasterTypeValues.All.Length)
				}
			}
		},
		{
			"MMonsters",
			new Hash
			{
				{
					"type",
					typeof(MMonsters)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MMonsters.All.Length)
				}
			}
		},
		{
			"MNormalAttackRange",
			new Hash
			{
				{
					"type",
					typeof(MNormalAttackRange)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNormalAttackRange.All.Length)
				}
			}
		},
		{
			"MNpcTalkIcons",
			new Hash
			{
				{
					"type",
					typeof(MNpcTalkIcons)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNpcTalkIcons.All.Length)
				}
			}
		},
		{
			"MNpcTalkTypes",
			new Hash
			{
				{
					"type",
					typeof(MNpcTalkTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNpcTalkTypes.All.Length)
				}
			}
		},
		{
			"MNpcTalks",
			new Hash
			{
				{
					"type",
					typeof(MNpcTalks)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNpcTalks.All.Length)
				}
			}
		},
		{
			"MNpcTexts",
			new Hash
			{
				{
					"type",
					typeof(MNpcTexts)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNpcTexts.All.Length)
				}
			}
		},
		{
			"MNpcs",
			new Hash
			{
				{
					"type",
					typeof(MNpcs)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MNpcs.All.Length)
				}
			}
		},
		{
			"MParameterCorrects",
			new Hash
			{
				{
					"type",
					typeof(MParameterCorrects)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MParameterCorrects.All.Length)
				}
			}
		},
		{
			"MPlayerDeckMains",
			new Hash
			{
				{
					"type",
					typeof(MPlayerDeckMains)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerDeckMains.All.Length)
				}
			}
		},
		{
			"MPlayerDeckSupports",
			new Hash
			{
				{
					"type",
					typeof(MPlayerDeckSupports)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerDeckSupports.All.Length)
				}
			}
		},
		{
			"MPlayerGroups",
			new Hash
			{
				{
					"type",
					typeof(MPlayerGroups)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerGroups.All.Length)
				}
			}
		},
		{
			"MPlayerParameters",
			new Hash
			{
				{
					"type",
					typeof(MPlayerParameters)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerParameters.All.Length)
				}
			}
		},
		{
			"MPlayerPoppetDecks",
			new Hash
			{
				{
					"type",
					typeof(MPlayerPoppetDecks)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerPoppetDecks.All.Length)
				}
			}
		},
		{
			"MPlayerRaces",
			new Hash
			{
				{
					"type",
					typeof(MPlayerRaces)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayerRaces.All.Length)
				}
			}
		},
		{
			"MPlayers",
			new Hash
			{
				{
					"type",
					typeof(MPlayers)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPlayers.All.Length)
				}
			}
		},
		{
			"MPoppetChatTimings",
			new Hash
			{
				{
					"type",
					typeof(MPoppetChatTimings)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPoppetChatTimings.All.Length)
				}
			}
		},
		{
			"MPoppetChats",
			new Hash
			{
				{
					"type",
					typeof(MPoppetChats)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPoppetChats.All.Length)
				}
			}
		},
		{
			"MPoppetPersonalities",
			new Hash
			{
				{
					"type",
					typeof(MPoppetPersonalities)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPoppetPersonalities.All.Length)
				}
			}
		},
		{
			"MPoppets",
			new Hash
			{
				{
					"type",
					typeof(MPoppets)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPoppets.All.Length)
				}
			}
		},
		{
			"MPresentTypes",
			new Hash
			{
				{
					"type",
					typeof(MPresentTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MPresentTypes.All.Length)
				}
			}
		},
		{
			"MQuestClearTypes",
			new Hash
			{
				{
					"type",
					typeof(MQuestClearTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestClearTypes.All.Length)
				}
			}
		},
		{
			"MQuestClears",
			new Hash
			{
				{
					"type",
					typeof(MQuestClears)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestClears.All.Length)
				}
			}
		},
		{
			"MQuestDrops",
			new Hash
			{
				{
					"type",
					typeof(MQuestDrops)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestDrops.All.Length)
				}
			}
		},
		{
			"MQuestFirstRewards",
			new Hash
			{
				{
					"type",
					typeof(MQuestFirstRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestFirstRewards.All.Length)
				}
			}
		},
		{
			"MQuestMonsters",
			new Hash
			{
				{
					"type",
					typeof(MQuestMonsters)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestMonsters.All.Length)
				}
			}
		},
		{
			"MQuestTypes",
			new Hash
			{
				{
					"type",
					typeof(MQuestTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuestTypes.All.Length)
				}
			}
		},
		{
			"MQuests",
			new Hash
			{
				{
					"type",
					typeof(MQuests)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MQuests.All.Length)
				}
			}
		},
		{
			"MRaces",
			new Hash
			{
				{
					"type",
					typeof(MRaces)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaces.All.Length)
				}
			}
		},
		{
			"MRaidBattleRewards",
			new Hash
			{
				{
					"type",
					typeof(MRaidBattleRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaidBattleRewards.All.Length)
				}
			}
		},
		{
			"MRaidBattles",
			new Hash
			{
				{
					"type",
					typeof(MRaidBattles)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaidBattles.All.Length)
				}
			}
		},
		{
			"MRaidTutorialRewards",
			new Hash
			{
				{
					"type",
					typeof(MRaidTutorialRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaidTutorialRewards.All.Length)
				}
			}
		},
		{
			"MRaidWordTypes",
			new Hash
			{
				{
					"type",
					typeof(MRaidWordTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaidWordTypes.All.Length)
				}
			}
		},
		{
			"MRaidWords",
			new Hash
			{
				{
					"type",
					typeof(MRaidWords)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRaidWords.All.Length)
				}
			}
		},
		{
			"MRankingRewardTypes",
			new Hash
			{
				{
					"type",
					typeof(MRankingRewardTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRankingRewardTypes.All.Length)
				}
			}
		},
		{
			"MRankingRewards",
			new Hash
			{
				{
					"type",
					typeof(MRankingRewards)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRankingRewards.All.Length)
				}
			}
		},
		{
			"MRares",
			new Hash
			{
				{
					"type",
					typeof(MRares)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MRares.All.Length)
				}
			}
		},
		{
			"MSaleGachaGroups",
			new Hash
			{
				{
					"type",
					typeof(MSaleGachaGroups)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSaleGachaGroups.All.Length)
				}
			}
		},
		{
			"MSaleGachas",
			new Hash
			{
				{
					"type",
					typeof(MSaleGachas)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSaleGachas.All.Length)
				}
			}
		},
		{
			"MSaleTypeValues",
			new Hash
			{
				{
					"type",
					typeof(MSaleTypeValues)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSaleTypeValues.All.Length)
				}
			}
		},
		{
			"MSceneBgm",
			new Hash
			{
				{
					"type",
					typeof(MSceneBgm)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSceneBgm.All.Length)
				}
			}
		},
		{
			"MScenes",
			new Hash
			{
				{
					"type",
					typeof(MScenes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MScenes.All.Length)
				}
			}
		},
		{
			"MSe",
			new Hash
			{
				{
					"type",
					typeof(MSe)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSe.All.Length)
				}
			}
		},
		{
			"MSeTypes",
			new Hash
			{
				{
					"type",
					typeof(MSeTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSeTypes.All.Length)
				}
			}
		},
		{
			"MSellTypes",
			new Hash
			{
				{
					"type",
					typeof(MSellTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSellTypes.All.Length)
				}
			}
		},
		{
			"MShopMessage",
			new Hash
			{
				{
					"type",
					typeof(MShopMessage)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MShopMessage.All.Length)
				}
			}
		},
		{
			"MShopMessageTypes",
			new Hash
			{
				{
					"type",
					typeof(MShopMessageTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MShopMessageTypes.All.Length)
				}
			}
		},
		{
			"MShortcutChildIcons",
			new Hash
			{
				{
					"type",
					typeof(MShortcutChildIcons)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MShortcutChildIcons.All.Length)
				}
			}
		},
		{
			"MShortcutIcons",
			new Hash
			{
				{
					"type",
					typeof(MShortcutIcons)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MShortcutIcons.All.Length)
				}
			}
		},
		{
			"MSkillActionTypes",
			new Hash
			{
				{
					"type",
					typeof(MSkillActionTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSkillActionTypes.All.Length)
				}
			}
		},
		{
			"MSkillEffectTypes",
			new Hash
			{
				{
					"type",
					typeof(MSkillEffectTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MSkillEffectTypes.All.Length)
				}
			}
		},
		{
			"MStageBattles",
			new Hash
			{
				{
					"type",
					typeof(MStageBattles)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStageBattles.All.Length)
				}
			}
		},
		{
			"MStageMonsters",
			new Hash
			{
				{
					"type",
					typeof(MStageMonsters)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStageMonsters.All.Length)
				}
			}
		},
		{
			"MStages",
			new Hash
			{
				{
					"type",
					typeof(MStages)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStages.All.Length)
				}
			}
		},
		{
			"MStatus",
			new Hash
			{
				{
					"type",
					typeof(MStatus)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStatus.All.Length)
				}
			}
		},
		{
			"MStepGachaTypes",
			new Hash
			{
				{
					"type",
					typeof(MStepGachaTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStepGachaTypes.All.Length)
				}
			}
		},
		{
			"MStories",
			new Hash
			{
				{
					"type",
					typeof(MStories)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStories.All.Length)
				}
			}
		},
		{
			"MStoryBooks",
			new Hash
			{
				{
					"type",
					typeof(MStoryBooks)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStoryBooks.All.Length)
				}
			}
		},
		{
			"MStoryGroups",
			new Hash
			{
				{
					"type",
					typeof(MStoryGroups)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStoryGroups.All.Length)
				}
			}
		},
		{
			"MStyles",
			new Hash
			{
				{
					"type",
					typeof(MStyles)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MStyles.All.Length)
				}
			}
		},
		{
			"MTexts",
			new Hash
			{
				{
					"type",
					typeof(MTexts)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MTexts.All.Length)
				}
			}
		},
		{
			"MTipsMessage",
			new Hash
			{
				{
					"type",
					typeof(MTipsMessage)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MTipsMessage.All.Length)
				}
			}
		},
		{
			"MTutorialItems",
			new Hash
			{
				{
					"type",
					typeof(MTutorialItems)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MTutorialItems.All.Length)
				}
			}
		},
		{
			"MWarps",
			new Hash
			{
				{
					"type",
					typeof(MWarps)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWarps.All.Length)
				}
			}
		},
		{
			"MWeaponSkills",
			new Hash
			{
				{
					"type",
					typeof(MWeaponSkills)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWeaponSkills.All.Length)
				}
			}
		},
		{
			"MWeapons",
			new Hash
			{
				{
					"type",
					typeof(MWeapons)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWeapons.All.Length)
				}
			}
		},
		{
			"MWeek",
			new Hash
			{
				{
					"type",
					typeof(MWeek)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWeek.All.Length)
				}
			}
		},
		{
			"MWeekBonus",
			new Hash
			{
				{
					"type",
					typeof(MWeekBonus)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWeekBonus.All.Length)
				}
			}
		},
		{
			"MWeekEvents",
			new Hash
			{
				{
					"type",
					typeof(MWeekEvents)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWeekEvents.All.Length)
				}
			}
		},
		{
			"MWindowTypes",
			new Hash
			{
				{
					"type",
					typeof(MWindowTypes)
				},
				{
					"num",
					(__DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)(() => MWindowTypes.All.Length)
				}
			}
		}
	};

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IsmasterBrowseMode => currActionID("$default$") == ActionEnum.masterBrowseMode;

	public ActionClassmasterBrowseMode masterBrowseModeData => currAction("$default$") as ActionClassmasterBrowseMode;

	public bool IsdetailViewMode => currActionID("$default$") == ActionEnum.detailViewMode;

	public ActionClassdetailViewMode detailViewModeData => currAction("$default$") as ActionClassdetailViewMode;

	public bool IsweekEventEditMode => currActionID("$default$") == ActionEnum.weekEventEditMode;

	public ActionClassweekEventEditMode weekEventEditModeData => currAction("$default$") as ActionClassweekEventEditMode;

	public bool IsdateTimeEditMode => currActionID("$default$") == ActionEnum.dateTimeEditMode;

	public ActionClassdateTimeEditMode dateTimeEditModeData => currAction("$default$") as ActionClassdateTimeEditMode;

	public DebugSubModeMaster()
	{
		_0024act_0024t_0024272 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024274 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override void Update()
	{
		actUpdate();
	}

	public override void LateUpdate()
	{
		actLateUpdate();
	}

	public override void FixedUpdate()
	{
		actFixedUpdate();
	}

	public override void OnGUI()
	{
		actOnGUI();
	}

	public override void Init()
	{
		mainMode();
	}

	public override bool AutoReturn()
	{
		return false;
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024272.ContainsKey(grp)) ? null : _0024act_0024t_0024272[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024274.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024274[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024272.ContainsKey(grp)) ? 0f : _0024act_0024t_0024272[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024272.ContainsKey(grp)) ? 0f : _0024act_0024t_0024272[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024272.ContainsKey(grp)) ? 0f : _0024act_0024t_0024272[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024274.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024264) && _0024act_0024t_0024272.ContainsKey(act._0024act_0024t_0024264) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024272[act._0024act_0024t_0024264]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.dateTimeEditMode <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_0024264))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$264)");
			}
			_0024act_0024t_0024272[act._0024act_0024t_0024264] = act;
			_0024act_0024t_0024274[act._0024act_0024t_0024264] = act._0024act_0024t_0024263;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024273) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024264);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024264)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024264)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024266 != null)
		{
			actionBase._0024act_0024t_0024266(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024265 != null)
			{
				act._0024act_0024t_0024265(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024271 != null)
			{
				act._0024act_0024t_0024275 = act._0024act_0024t_0024271(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_0024272.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024273 = 0;
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
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024267 != null)
			{
				actionBase._0024act_0024t_0024267(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024275 != null && !actionBase._0024act_0024t_0024275.MoveNext())
			{
				actionBase._0024act_0024t_0024275 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024272.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024273 = 0;
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
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024268 != null)
			{
				actionBase._0024act_0024t_0024268(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024273 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024272.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024272[array2[i]];
				if (actionBase._0024act_0024t_0024269 != null)
				{
					actionBase._0024act_0024t_0024269(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024272.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024264 + " - " + value._0024act_0024t_0024263 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024273 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024272.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024272[array2[i]];
			if (actionBase._0024act_0024t_0024270 != null)
			{
				actionBase._0024act_0024t_0024270(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubModeMaster" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.masterBrowseMode => createDatamasterBrowseMode(), 
			ActionEnum.detailViewMode => createDatadetailViewMode(), 
			ActionEnum.weekEventEditMode => createDataweekEventEditMode(), 
			ActionEnum.dateTimeEditMode => createDatadateTimeEditMode(), 
			_ => null, 
		};
	}

	public ActionClassmainMode mainMode()
	{
		ActionClassmainMode actionClassmainMode = createmainMode();
		changeAction(actionClassmainMode);
		return actionClassmainMode;
	}

	public ActionClassmainMode createDatamainMode()
	{
		ActionClassmainMode actionClassmainMode = new ActionClassmainMode();
		actionClassmainMode._0024act_0024t_0024263 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024264 = "$default$";
		actionClassmainMode._0024act_0024t_0024265 = _0024adaptor_0024__DebugSubModeMaster_0024callable202_002419_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002412.Adapt(delegate(ActionClassmainMode _0024act_0024t_0024262)
		{
			_0024act_0024t_0024262.mstKeys = new Boo.Lang.List<string>(AllMasters.Keys);
			_0024act_0024t_0024262.mstKeys.Sort();
		});
		actionClassmainMode._0024act_0024t_0024269 = _0024adaptor_0024__DebugSubModeMaster_0024callable202_002419_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002412.Adapt(delegate(ActionClassmainMode _0024act_0024t_0024262)
		{
			RuntimeDebugModeGuiMixin.label("全マスタ一覧");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("ボタンを押して内容表示");
			RuntimeDebugModeGuiMixin.space(10);
			IEnumerator<string> enumerator = _0024act_0024t_0024262.mstKeys.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					Hashtable hashtable = AllMasters[current] as Hashtable;
					Type type = hashtable["type"] as Type;
					int num = (hashtable["num"] as __DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)();
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(type).Append(":").Append((object)num)
						.ToString()))
					{
						masterBrowseMode(type);
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		});
		actionClassmainMode._0024act_0024t_0024267 = _0024adaptor_0024__DebugSubModeMaster_0024callable202_002419_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002412.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				KillMe();
			}
		});
		return actionClassmainMode;
	}

	public ActionClassmainMode createmainMode()
	{
		return createDatamainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024272.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024272["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClassmasterBrowseMode masterBrowseMode(Type mstType)
	{
		ActionClassmasterBrowseMode actionClassmasterBrowseMode = createmasterBrowseMode(mstType);
		changeAction(actionClassmasterBrowseMode);
		return actionClassmasterBrowseMode;
	}

	public ActionClassmasterBrowseMode createDatamasterBrowseMode()
	{
		ActionClassmasterBrowseMode actionClassmasterBrowseMode = new ActionClassmasterBrowseMode();
		actionClassmasterBrowseMode._0024act_0024t_0024263 = ActionEnum.masterBrowseMode;
		actionClassmasterBrowseMode._0024act_0024t_0024264 = "$default$";
		actionClassmasterBrowseMode._0024act_0024t_0024265 = _0024adaptor_0024__DebugSubModeMaster_0024callable204_002451_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002413.Adapt(delegate(ActionClassmasterBrowseMode _0024act_0024t_0024278)
		{
			_0024act_0024t_0024278.data = new Boo.Lang.List<MerlinMaster>();
			PropertyInfo property = _0024act_0024t_0024278.mstType.GetProperty("All");
			IEnumerator enumerator = RuntimeServices.GetEnumerable(property.GetValue(null, null)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is MerlinMaster))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MerlinMaster));
				}
				MerlinMaster merlinMaster = (MerlinMaster)obj;
				if (merlinMaster != null)
				{
					_0024act_0024t_0024278.data.Add(merlinMaster);
				}
			}
			lastViewTypeIdInfo = _0024act_0024t_0024278.mstType.GetField("$var$Id");
			if (lastViewTypeIdInfo != null)
			{
				_0024act_0024t_0024278.data.Sort(delegate(MerlinMaster a, MerlinMaster b)
				{
					Type fieldType = lastViewTypeIdInfo.FieldType;
					object value = lastViewTypeIdInfo.GetValue(a);
					object value2 = lastViewTypeIdInfo.GetValue(b);
					return (!RuntimeServices.EqualityOperator(fieldType, typeof(string))) ? checked(RuntimeServices.UnboxInt32(value) - RuntimeServices.UnboxInt32(value2)) : string.Compare(value as string, value2 as string);
				});
			}
			if (!RuntimeServices.EqualityOperator(_0024act_0024t_0024278.mstType, lastViewType))
			{
				viewTop = 0;
				viewNum = 50;
				lastViewType = _0024act_0024t_0024278.mstType;
			}
		});
		actionClassmasterBrowseMode._0024act_0024t_0024269 = _0024adaptor_0024__DebugSubModeMaster_0024callable204_002451_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002413.Adapt(delegate(ActionClassmasterBrowseMode _0024act_0024t_0024278)
		{
			_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024 = new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284();
			_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278 = _0024act_0024t_0024278;
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024, this).Invoke;
			_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
			RuntimeDebugModeGuiMixin.space(10);
			if (_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278.data != null)
			{
				_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024bw = RuntimeDebugModeGuiMixin.optWidth(80);
				int num = viewTop;
				int num2 = Math.Min(checked(viewTop + viewNum), _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278.data.Count);
				int num3 = 1;
				if (num2 < num)
				{
					num3 = -1;
				}
				while (num != num2)
				{
					int _0024i_0024 = num;
					num += num3;
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024closure_00243547(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024, this, _0024i_0024).Invoke));
				}
			}
			RuntimeDebugModeGuiMixin.space(10);
			_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
		});
		actionClassmasterBrowseMode._0024act_0024t_0024267 = _0024adaptor_0024__DebugSubModeMaster_0024callable204_002451_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002413.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassmasterBrowseMode;
	}

	public ActionClassmasterBrowseMode createmasterBrowseMode(Type mstType)
	{
		ActionClassmasterBrowseMode actionClassmasterBrowseMode = createDatamasterBrowseMode();
		actionClassmasterBrowseMode.mstType = mstType;
		return actionClassmasterBrowseMode;
	}

	public ActionClassdetailViewMode detailViewMode(MerlinMaster mst)
	{
		ActionClassdetailViewMode actionClassdetailViewMode = createdetailViewMode(mst);
		changeAction(actionClassdetailViewMode);
		return actionClassdetailViewMode;
	}

	public ActionClassdetailViewMode createDatadetailViewMode()
	{
		ActionClassdetailViewMode actionClassdetailViewMode = new ActionClassdetailViewMode();
		actionClassdetailViewMode._0024act_0024t_0024263 = ActionEnum.detailViewMode;
		actionClassdetailViewMode._0024act_0024t_0024264 = "$default$";
		actionClassdetailViewMode._0024act_0024t_0024265 = _0024adaptor_0024__DebugSubModeMaster_0024callable205_0024109_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002414.Adapt(delegate(ActionClassdetailViewMode _0024act_0024t_0024281)
		{
			Type type = ((object)_0024act_0024t_0024281.mst).GetType();
			MethodInfo method = type.GetMethod("KeyNameList");
			MethodInfo method2 = type.GetMethod("setValue");
			_0024act_0024t_0024281.props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			__DebugSubModeMaster__0024createDatadetailViewMode_0024closure_00243549_0024callable159_0024122_17__ from = delegate(PropertyInfo a, PropertyInfo b)
			{
				Type propertyType = a.PropertyType;
				Type propertyType2 = b.PropertyType;
				return RuntimeServices.EqualityOperator(propertyType, propertyType2) ? string.Compare(a.Name, b.Name) : (RuntimeServices.EqualityOperator(propertyType, typeof(DateTime)) ? (-1) : (RuntimeServices.EqualityOperator(propertyType2, typeof(DateTime)) ? 1 : string.Compare(a.Name, b.Name)));
			};
			Array.Sort(_0024act_0024t_0024281.props, _0024adaptor_0024__DebugSubModeMaster__0024createDatadetailViewMode_0024closure_00243549_0024callable159_0024122_17___0024Comparison_002417.Adapt(from));
			_0024act_0024t_0024281.values = new object[_0024act_0024t_0024281.props.Length];
			int num3 = 0;
			int length2 = _0024act_0024t_0024281.props.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < length2)
			{
				int index = num3;
				num3++;
				object[] values2 = _0024act_0024t_0024281.values;
				int num4 = RuntimeServices.NormalizeArrayIndex(values2, index);
				PropertyInfo[] props2 = _0024act_0024t_0024281.props;
				values2[num4] = props2[RuntimeServices.NormalizeArrayIndex(props2, index)].GetValue(_0024act_0024t_0024281.mst, null);
			}
		});
		actionClassdetailViewMode._0024act_0024t_0024269 = _0024adaptor_0024__DebugSubModeMaster_0024callable205_0024109_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002414.Adapt(delegate(ActionClassdetailViewMode _0024act_0024t_0024281)
		{
			_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285 _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024 = new _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285();
			_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281 = _0024act_0024t_0024281;
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst).ToString());
			if (_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst is MQuests)
			{
				RuntimeDebugModeGuiMixin.space(10);
				if (RuntimeDebugModeGuiMixin.button("このクエストのMWeekEvents編集"))
				{
					weekEventEditMode((MQuests)_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst);
				}
				RuntimeDebugModeGuiMixin.space(10);
			}
			_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024ebtnwidth = RuntimeDebugModeGuiMixin.optWidth(128);
			int num = 0;
			int length = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.props.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				object[] values = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.values;
				_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val = values[RuntimeServices.NormalizeArrayIndex(values, num2)];
				if (_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val is DateTime)
				{
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatadetailViewMode_0024closure_00243551_0024closure_00243552(num2, _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024, this).Invoke));
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					PropertyInfo[] props = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.props;
					RuntimeDebugModeGuiMixin.slabel(stringBuilder.Append(props[RuntimeServices.NormalizeArrayIndex(props, num2)].Name).Append(": ").Append(_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val)
						.ToString());
				}
			}
		});
		actionClassdetailViewMode._0024act_0024t_0024267 = _0024adaptor_0024__DebugSubModeMaster_0024callable205_0024109_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002414.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				masterBrowseMode(lastViewType);
			}
		});
		return actionClassdetailViewMode;
	}

	public ActionClassdetailViewMode createdetailViewMode(MerlinMaster mst)
	{
		ActionClassdetailViewMode actionClassdetailViewMode = createDatadetailViewMode();
		actionClassdetailViewMode.mst = mst;
		return actionClassdetailViewMode;
	}

	public ActionClassweekEventEditMode weekEventEditMode(MQuests mst)
	{
		ActionClassweekEventEditMode actionClassweekEventEditMode = createweekEventEditMode(mst);
		changeAction(actionClassweekEventEditMode);
		return actionClassweekEventEditMode;
	}

	public ActionClassweekEventEditMode createDataweekEventEditMode()
	{
		ActionClassweekEventEditMode actionClassweekEventEditMode = new ActionClassweekEventEditMode();
		actionClassweekEventEditMode._0024act_0024t_0024263 = ActionEnum.weekEventEditMode;
		actionClassweekEventEditMode._0024act_0024t_0024264 = "$default$";
		actionClassweekEventEditMode._0024act_0024t_0024265 = _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415.Adapt(checked(delegate(ActionClassweekEventEditMode _0024act_0024t_0024284)
		{
			_0024act_0024t_0024284.mstory = null;
			int i = 0;
			MStories[] all = MStories.All;
			for (int length = all.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(all[i].MQuestId, _0024act_0024t_0024284.mst))
				{
					_0024act_0024t_0024284.mstory = all[i];
				}
			}
			_0024act_0024t_0024284.wevents = new Boo.Lang.List<MWeekEvents>();
			int j = 0;
			MWeekEvents[] all2 = MWeekEvents.All;
			for (int length2 = all2.Length; j < length2; j++)
			{
				if (RuntimeServices.EqualityOperator(all2[j].MStoryId, _0024act_0024t_0024284.mstory))
				{
					_0024act_0024t_0024284.wevents.Add(all2[j]);
				}
			}
		}));
		actionClassweekEventEditMode._0024act_0024t_0024269 = _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415.Adapt(delegate(ActionClassweekEventEditMode _0024act_0024t_0024284)
		{
			RuntimeDebugModeGuiMixin.label("MWeekEvents編集モード");
			RuntimeDebugModeGuiMixin.label(new StringBuilder("クエスト: ").Append(_0024act_0024t_0024284.mst).ToString());
			if (_0024act_0024t_0024284.mstory == null)
			{
				RuntimeDebugModeGuiMixin.label("該当MStoriesが無い");
				return;
			}
			int num = 0;
			while (num < 7)
			{
				int num2 = num;
				num++;
				EnumWeek enumWeek = (EnumWeek)num2;
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder("関連MWeekEventsを").Append(enumWeek).Append("曜日全日にする").ToString()))
				{
					openAllWeekEvents(_0024act_0024t_0024284.wevents, enumWeek);
				}
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("関連MWeekEvents:");
			IEnumerator<MWeekEvents> enumerator = _0024act_0024t_0024284.wevents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					MWeekEvents current = enumerator.Current;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)current.Id).Append(" PGRP:").Append((object)current.PlayerGroupId)
						.Append(" ")
						.Append(current.Week)
						.Append(" ")
						.Append(current.BeginTime)
						.Append(" ~ ")
						.Append(current.EndTime)
						.ToString());
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		});
		actionClassweekEventEditMode._0024act_0024t_0024267 = _0024adaptor_0024__DebugSubModeMaster_0024callable206_0024158_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002415.Adapt(delegate(ActionClassweekEventEditMode _0024act_0024t_0024284)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				detailViewMode(_0024act_0024t_0024284.mst);
			}
		});
		return actionClassweekEventEditMode;
	}

	public ActionClassweekEventEditMode createweekEventEditMode(MQuests mst)
	{
		ActionClassweekEventEditMode actionClassweekEventEditMode = createDataweekEventEditMode();
		actionClassweekEventEditMode.mst = mst;
		return actionClassweekEventEditMode;
	}

	private void openAllWeekEvents(Boo.Lang.List<MWeekEvents> wevents, EnumWeek wday)
	{
		IEnumerator<MWeekEvents> enumerator = wevents.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MWeekEvents current = enumerator.Current;
				current.setField("Week", (int)wday);
				current.setField("BeginTime", "00:00:00");
				current.setField("EndTime", "23:59:59");
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public ActionClassdateTimeEditMode dateTimeEditMode(MerlinMaster mst, PropertyInfo propInfo)
	{
		ActionClassdateTimeEditMode actionClassdateTimeEditMode = createdateTimeEditMode(mst, propInfo);
		changeAction(actionClassdateTimeEditMode);
		return actionClassdateTimeEditMode;
	}

	public ActionClassdateTimeEditMode createDatadateTimeEditMode()
	{
		ActionClassdateTimeEditMode actionClassdateTimeEditMode = new ActionClassdateTimeEditMode();
		actionClassdateTimeEditMode._0024act_0024t_0024263 = ActionEnum.dateTimeEditMode;
		actionClassdateTimeEditMode._0024act_0024t_0024264 = "$default$";
		actionClassdateTimeEditMode._0024act_0024t_0024265 = _0024adaptor_0024__DebugSubModeMaster_0024callable207_0024196_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002416.Adapt(delegate(ActionClassdateTimeEditMode _0024act_0024t_0024287)
		{
			_0024act_0024t_0024287.values = new int[6];
			DateTime valDateTime = (DateTime)_0024act_0024t_0024287.propInfo.GetValue(_0024act_0024t_0024287.mst, null);
			_0024act_0024t_0024287.values[0] = valDateTime.Year;
			_0024act_0024t_0024287.values[1] = valDateTime.Month;
			_0024act_0024t_0024287.values[2] = valDateTime.Day;
			_0024act_0024t_0024287.values[3] = valDateTime.Hour;
			_0024act_0024t_0024287.values[4] = valDateTime.Minute;
			_0024act_0024t_0024287.values[5] = valDateTime.Second;
			_0024act_0024t_0024287.valDateTime = valDateTime;
		});
		actionClassdateTimeEditMode._0024act_0024t_0024269 = _0024adaptor_0024__DebugSubModeMaster_0024callable207_0024196_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002416.Adapt(delegate(ActionClassdateTimeEditMode _0024act_0024t_0024287)
		{
			if (lastViewTypeIdInfo != null)
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("ID=").Append(lastViewTypeIdInfo.GetValue(_0024act_0024t_0024287.mst)).Append("  ").Append(_0024act_0024t_0024287.mst)
					.ToString());
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024287.mst).ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (!string.IsNullOrEmpty(_0024act_0024t_0024287.errmsg))
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("エラー: ").Append(_0024act_0024t_0024287.errmsg).ToString());
			}
			RuntimeDebugModeGuiMixin.label(new StringBuilder("日付編集 ").Append(((object)_0024act_0024t_0024287.mst).GetType()).Append(" - ").Append(_0024act_0024t_0024287.propInfo.Name)
				.ToString());
			editDateTimeValues(_0024act_0024t_0024287.values);
			if (RuntimeDebugModeGuiMixin.button("上記で書き換え"))
			{
				try
				{
					DateTime dateTime = DateTime.Parse(toDateTimeStr(_0024act_0024t_0024287.values));
					lastViewType.GetField("$var$" + _0024act_0024t_0024287.propInfo.Name)?.SetValue(_0024act_0024t_0024287.mst, dateTime);
					detailViewMode(_0024act_0024t_0024287.mst);
				}
				catch (Exception)
				{
					_0024act_0024t_0024287.errmsg = "正しい日付を入力してください";
				}
			}
		});
		actionClassdateTimeEditMode._0024act_0024t_0024267 = _0024adaptor_0024__DebugSubModeMaster_0024callable207_0024196_5___0024__ActionBase__0024act_0024t_0024265_0024callable13_002419_5___002416.Adapt(delegate(ActionClassdateTimeEditMode _0024act_0024t_0024287)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				detailViewMode(_0024act_0024t_0024287.mst);
			}
		});
		return actionClassdateTimeEditMode;
	}

	public ActionClassdateTimeEditMode createdateTimeEditMode(MerlinMaster mst, PropertyInfo propInfo)
	{
		ActionClassdateTimeEditMode actionClassdateTimeEditMode = createDatadateTimeEditMode();
		actionClassdateTimeEditMode.mst = mst;
		actionClassdateTimeEditMode.propInfo = propInfo;
		return actionClassdateTimeEditMode;
	}

	public void editDateTimeValues(int[] values)
	{
		RuntimeDebugModeGuiMixin.label("値:" + toDateTimeStr(values));
		editInt(values, 0, 1900, 2100, "年");
		editInt(values, 1, 1, 12, "月");
		editInt(values, 2, 1, 31, "日");
		editInt(values, 3, 0, 23, "時");
		editInt(values, 4, 0, 59, "分");
		editInt(values, 5, 0, 59, "秒");
	}

	public string toDateTimeStr(int[] values)
	{
		return new StringBuilder().Append((object)values[0]).Append("/").Append((object)values[1])
			.Append("/")
			.Append((object)values[2])
			.Append(" ")
			.Append((object)values[3])
			.Append(":")
			.Append((object)values[4])
			.Append(":")
			.Append((object)values[5])
			.ToString();
	}

	public void editInt(int[] values, int index, int min, int max, string unit)
	{
		_0024editInt_0024locals_002414283 _0024editInt_0024locals_0024 = new _0024editInt_0024locals_002414283();
		_0024editInt_0024locals_0024._0024min = min;
		_0024editInt_0024locals_0024._0024max = max;
		_0024editInt_0024locals_0024._0024unit = unit;
		_0024editInt_0024locals_0024._0024v = values[RuntimeServices.NormalizeArrayIndex(values, index)];
		_0024editInt_0024locals_0024._0024bw = RuntimeDebugModeGuiMixin.optWidth(64);
		_0024editInt_0024locals_0024._0024vw = RuntimeDebugModeGuiMixin.optWidth(140);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024editInt_0024closure_00243560(_0024editInt_0024locals_0024).Invoke));
		values[RuntimeServices.NormalizeArrayIndex(values, index)] = _0024editInt_0024locals_0024._0024v;
	}

	internal void _0024createDatamainMode_0024closure_00243539(ActionClassmainMode _0024act_0024t_0024262)
	{
		_0024act_0024t_0024262.mstKeys = new Boo.Lang.List<string>(AllMasters.Keys);
		_0024act_0024t_0024262.mstKeys.Sort();
	}

	internal void _0024createDatamainMode_0024closure_00243540(ActionClassmainMode _0024act_0024t_0024262)
	{
		RuntimeDebugModeGuiMixin.label("全マスタ一覧");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("ボタンを押して内容表示");
		RuntimeDebugModeGuiMixin.space(10);
		IEnumerator<string> enumerator = _0024act_0024t_0024262.mstKeys.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				Hashtable hashtable = AllMasters[current] as Hashtable;
				Type type = hashtable["type"] as Type;
				int num = (hashtable["num"] as __DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__)();
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(type).Append(":").Append((object)num)
					.ToString()))
				{
					masterBrowseMode(type);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024createDatamainMode_0024closure_00243541(ActionClassmainMode _0024act_0024t_0024262)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDatamasterBrowseMode_0024closure_00243542(ActionClassmasterBrowseMode _0024act_0024t_0024278)
	{
		_0024act_0024t_0024278.data = new Boo.Lang.List<MerlinMaster>();
		PropertyInfo property = _0024act_0024t_0024278.mstType.GetProperty("All");
		IEnumerator enumerator = RuntimeServices.GetEnumerable(property.GetValue(null, null)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is MerlinMaster))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MerlinMaster));
			}
			MerlinMaster merlinMaster = (MerlinMaster)obj;
			if (merlinMaster != null)
			{
				_0024act_0024t_0024278.data.Add(merlinMaster);
			}
		}
		lastViewTypeIdInfo = _0024act_0024t_0024278.mstType.GetField("$var$Id");
		if (lastViewTypeIdInfo != null)
		{
			_0024act_0024t_0024278.data.Sort(delegate(MerlinMaster a, MerlinMaster b)
			{
				Type fieldType = lastViewTypeIdInfo.FieldType;
				object value = lastViewTypeIdInfo.GetValue(a);
				object value2 = lastViewTypeIdInfo.GetValue(b);
				return (!RuntimeServices.EqualityOperator(fieldType, typeof(string))) ? checked(RuntimeServices.UnboxInt32(value) - RuntimeServices.UnboxInt32(value2)) : string.Compare(value as string, value2 as string);
			});
		}
		if (!RuntimeServices.EqualityOperator(_0024act_0024t_0024278.mstType, lastViewType))
		{
			viewTop = 0;
			viewNum = 50;
			lastViewType = _0024act_0024t_0024278.mstType;
		}
	}

	internal int _0024_0024createDatamasterBrowseMode_0024closure_00243542_0024closure_00243543(MerlinMaster a, MerlinMaster b)
	{
		Type fieldType = lastViewTypeIdInfo.FieldType;
		object value = lastViewTypeIdInfo.GetValue(a);
		object value2 = lastViewTypeIdInfo.GetValue(b);
		return (!RuntimeServices.EqualityOperator(fieldType, typeof(string))) ? checked(RuntimeServices.UnboxInt32(value) - RuntimeServices.UnboxInt32(value2)) : string.Compare(value as string, value2 as string);
	}

	internal void _0024createDatamasterBrowseMode_0024closure_00243544(ActionClassmasterBrowseMode _0024act_0024t_0024278)
	{
		_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284 _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024 = new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_002414284();
		_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278 = _0024act_0024t_0024278;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024_paginationButtons_00243545(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024, this).Invoke;
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
		RuntimeDebugModeGuiMixin.space(10);
		if (_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278.data != null)
		{
			_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024bw = RuntimeDebugModeGuiMixin.optWidth(80);
			int num = viewTop;
			int num2 = Math.Min(checked(viewTop + viewNum), _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024._0024_0024act_0024t_0024278.data.Count);
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int _0024i_0024 = num;
				num += num3;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamasterBrowseMode_0024closure_00243544_0024closure_00243547(_0024_0024createDatamasterBrowseMode_0024closure_00243544_0024locals_0024, this, _0024i_0024).Invoke));
			}
		}
		RuntimeDebugModeGuiMixin.space(10);
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
	}

	internal void _0024createDatamasterBrowseMode_0024closure_00243548(ActionClassmasterBrowseMode _0024act_0024t_0024278)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatadetailViewMode_0024closure_00243549(ActionClassdetailViewMode _0024act_0024t_0024281)
	{
		Type type = ((object)_0024act_0024t_0024281.mst).GetType();
		MethodInfo method = type.GetMethod("KeyNameList");
		MethodInfo method2 = type.GetMethod("setValue");
		_0024act_0024t_0024281.props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		__DebugSubModeMaster__0024createDatadetailViewMode_0024closure_00243549_0024callable159_0024122_17__ from = delegate(PropertyInfo a, PropertyInfo b)
		{
			Type propertyType = a.PropertyType;
			Type propertyType2 = b.PropertyType;
			return RuntimeServices.EqualityOperator(propertyType, propertyType2) ? string.Compare(a.Name, b.Name) : (RuntimeServices.EqualityOperator(propertyType, typeof(DateTime)) ? (-1) : (RuntimeServices.EqualityOperator(propertyType2, typeof(DateTime)) ? 1 : string.Compare(a.Name, b.Name)));
		};
		Array.Sort(_0024act_0024t_0024281.props, _0024adaptor_0024__DebugSubModeMaster__0024createDatadetailViewMode_0024closure_00243549_0024callable159_0024122_17___0024Comparison_002417.Adapt(from));
		_0024act_0024t_0024281.values = new object[_0024act_0024t_0024281.props.Length];
		int num = 0;
		int length = _0024act_0024t_0024281.props.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			object[] values = _0024act_0024t_0024281.values;
			int num2 = RuntimeServices.NormalizeArrayIndex(values, index);
			PropertyInfo[] props = _0024act_0024t_0024281.props;
			values[num2] = props[RuntimeServices.NormalizeArrayIndex(props, index)].GetValue(_0024act_0024t_0024281.mst, null);
		}
	}

	internal int _0024_0024createDatadetailViewMode_0024closure_00243549_0024_comparer_00243550(PropertyInfo a, PropertyInfo b)
	{
		Type propertyType = a.PropertyType;
		Type propertyType2 = b.PropertyType;
		return RuntimeServices.EqualityOperator(propertyType, propertyType2) ? string.Compare(a.Name, b.Name) : (RuntimeServices.EqualityOperator(propertyType, typeof(DateTime)) ? (-1) : (RuntimeServices.EqualityOperator(propertyType2, typeof(DateTime)) ? 1 : string.Compare(a.Name, b.Name)));
	}

	internal void _0024createDatadetailViewMode_0024closure_00243551(ActionClassdetailViewMode _0024act_0024t_0024281)
	{
		_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285 _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024 = new _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_002414285();
		_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281 = _0024act_0024t_0024281;
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst).ToString());
		if (_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst is MQuests)
		{
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("このクエストのMWeekEvents編集"))
			{
				weekEventEditMode((MQuests)_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.mst);
			}
			RuntimeDebugModeGuiMixin.space(10);
		}
		_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024ebtnwidth = RuntimeDebugModeGuiMixin.optWidth(128);
		int num = 0;
		int length = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.props.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			object[] values = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.values;
			_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val = values[RuntimeServices.NormalizeArrayIndex(values, num2)];
			if (_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val is DateTime)
			{
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatadetailViewMode_0024closure_00243551_0024closure_00243552(num2, _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024, this).Invoke));
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder();
			PropertyInfo[] props = _0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024_0024act_0024t_0024281.props;
			RuntimeDebugModeGuiMixin.slabel(stringBuilder.Append(props[RuntimeServices.NormalizeArrayIndex(props, num2)].Name).Append(": ").Append(_0024_0024createDatadetailViewMode_0024closure_00243551_0024locals_0024._0024val)
				.ToString());
		}
	}

	internal void _0024createDatadetailViewMode_0024closure_00243553(ActionClassdetailViewMode _0024act_0024t_0024281)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			masterBrowseMode(lastViewType);
		}
	}

	internal void _0024createDataweekEventEditMode_0024closure_00243554(ActionClassweekEventEditMode _0024act_0024t_0024284)
	{
		_0024act_0024t_0024284.mstory = null;
		int i = 0;
		MStories[] all = MStories.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(all[i].MQuestId, _0024act_0024t_0024284.mst))
				{
					_0024act_0024t_0024284.mstory = all[i];
				}
			}
			_0024act_0024t_0024284.wevents = new Boo.Lang.List<MWeekEvents>();
			int j = 0;
			MWeekEvents[] all2 = MWeekEvents.All;
			for (int length2 = all2.Length; j < length2; j++)
			{
				if (RuntimeServices.EqualityOperator(all2[j].MStoryId, _0024act_0024t_0024284.mstory))
				{
					_0024act_0024t_0024284.wevents.Add(all2[j]);
				}
			}
		}
	}

	internal void _0024createDataweekEventEditMode_0024closure_00243555(ActionClassweekEventEditMode _0024act_0024t_0024284)
	{
		RuntimeDebugModeGuiMixin.label("MWeekEvents編集モード");
		RuntimeDebugModeGuiMixin.label(new StringBuilder("クエスト: ").Append(_0024act_0024t_0024284.mst).ToString());
		if (_0024act_0024t_0024284.mstory == null)
		{
			RuntimeDebugModeGuiMixin.label("該当MStoriesが無い");
			return;
		}
		int num = 0;
		while (num < 7)
		{
			int num2 = num;
			num++;
			EnumWeek enumWeek = (EnumWeek)num2;
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("関連MWeekEventsを").Append(enumWeek).Append("曜日全日にする").ToString()))
			{
				openAllWeekEvents(_0024act_0024t_0024284.wevents, enumWeek);
			}
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("関連MWeekEvents:");
		IEnumerator<MWeekEvents> enumerator = _0024act_0024t_0024284.wevents.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MWeekEvents current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)current.Id).Append(" PGRP:").Append((object)current.PlayerGroupId)
					.Append(" ")
					.Append(current.Week)
					.Append(" ")
					.Append(current.BeginTime)
					.Append(" ~ ")
					.Append(current.EndTime)
					.ToString());
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024createDataweekEventEditMode_0024closure_00243556(ActionClassweekEventEditMode _0024act_0024t_0024284)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			detailViewMode(_0024act_0024t_0024284.mst);
		}
	}

	internal void _0024createDatadateTimeEditMode_0024closure_00243557(ActionClassdateTimeEditMode _0024act_0024t_0024287)
	{
		_0024act_0024t_0024287.values = new int[6];
		DateTime valDateTime = (DateTime)_0024act_0024t_0024287.propInfo.GetValue(_0024act_0024t_0024287.mst, null);
		_0024act_0024t_0024287.values[0] = valDateTime.Year;
		_0024act_0024t_0024287.values[1] = valDateTime.Month;
		_0024act_0024t_0024287.values[2] = valDateTime.Day;
		_0024act_0024t_0024287.values[3] = valDateTime.Hour;
		_0024act_0024t_0024287.values[4] = valDateTime.Minute;
		_0024act_0024t_0024287.values[5] = valDateTime.Second;
		_0024act_0024t_0024287.valDateTime = valDateTime;
	}

	internal void _0024createDatadateTimeEditMode_0024closure_00243558(ActionClassdateTimeEditMode _0024act_0024t_0024287)
	{
		if (lastViewTypeIdInfo != null)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("ID=").Append(lastViewTypeIdInfo.GetValue(_0024act_0024t_0024287.mst)).Append("  ").Append(_0024act_0024t_0024287.mst)
				.ToString());
		}
		else
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024287.mst).ToString());
		}
		RuntimeDebugModeGuiMixin.space(10);
		if (!string.IsNullOrEmpty(_0024act_0024t_0024287.errmsg))
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("エラー: ").Append(_0024act_0024t_0024287.errmsg).ToString());
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("日付編集 ").Append(((object)_0024act_0024t_0024287.mst).GetType()).Append(" - ").Append(_0024act_0024t_0024287.propInfo.Name)
			.ToString());
		editDateTimeValues(_0024act_0024t_0024287.values);
		if (RuntimeDebugModeGuiMixin.button("上記で書き換え"))
		{
			try
			{
				DateTime dateTime = DateTime.Parse(toDateTimeStr(_0024act_0024t_0024287.values));
				lastViewType.GetField("$var$" + _0024act_0024t_0024287.propInfo.Name)?.SetValue(_0024act_0024t_0024287.mst, dateTime);
				detailViewMode(_0024act_0024t_0024287.mst);
			}
			catch (Exception)
			{
				_0024act_0024t_0024287.errmsg = "正しい日付を入力してください";
			}
		}
	}

	internal void _0024createDatadateTimeEditMode_0024closure_00243559(ActionClassdateTimeEditMode _0024act_0024t_0024287)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			detailViewMode(_0024act_0024t_0024287.mst);
		}
	}

	internal static int _0024constructor_0024closure_00243561()
	{
		return MAbnormalStates.All.Length;
	}

	internal static int _0024constructor_0024closure_00243562()
	{
		return MAreaGroups.All.Length;
	}

	internal static int _0024constructor_0024closure_00243563()
	{
		return MAreaTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243564()
	{
		return MAreas.All.Length;
	}

	internal static int _0024constructor_0024closure_00243565()
	{
		return MBgm.All.Length;
	}

	internal static int _0024constructor_0024closure_00243566()
	{
		return MBreederRanks.All.Length;
	}

	internal static int _0024constructor_0024closure_00243567()
	{
		return MCampaignSegmentTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243568()
	{
		return MCampaignTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243569()
	{
		return MCampaigns.All.Length;
	}

	internal static int _0024constructor_0024closure_00243570()
	{
		return MChainSkillEffects.All.Length;
	}

	internal static int _0024constructor_0024closure_00243571()
	{
		return MChainSkills.All.Length;
	}

	internal static int _0024constructor_0024closure_00243572()
	{
		return MChangeDeckMains.All.Length;
	}

	internal static int _0024constructor_0024closure_00243573()
	{
		return MChangeDeckSupports.All.Length;
	}

	internal static int _0024constructor_0024closure_00243574()
	{
		return MChangePoppetDecks.All.Length;
	}

	internal static int _0024constructor_0024closure_00243575()
	{
		return MCharacterActionTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243576()
	{
		return MCharacteristics.All.Length;
	}

	internal static int _0024constructor_0024closure_00243577()
	{
		return MColosseumEventRankingRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243578()
	{
		return MColosseumEventRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243579()
	{
		return MColosseumEvents.All.Length;
	}

	internal static int _0024constructor_0024closure_00243580()
	{
		return MColosseumNpcOrganizes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243581()
	{
		return MColosseumNpcs.All.Length;
	}

	internal static int _0024constructor_0024closure_00243582()
	{
		return MComboBonus.All.Length;
	}

	internal static int _0024constructor_0024closure_00243583()
	{
		return MCoverSkills.All.Length;
	}

	internal static int _0024constructor_0024closure_00243584()
	{
		return MCycleSchedules.All.Length;
	}

	internal static int _0024constructor_0024closure_00243585()
	{
		return MDebugRaidBossData.All.Length;
	}

	internal static int _0024constructor_0024closure_00243586()
	{
		return MElementCorrelations.All.Length;
	}

	internal static int _0024constructor_0024closure_00243587()
	{
		return MElements.All.Length;
	}

	internal static int _0024constructor_0024closure_00243588()
	{
		return MEventQuestRankingRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243589()
	{
		return MEventQuestRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243590()
	{
		return MFixedEmissionGachas.All.Length;
	}

	internal static int _0024constructor_0024closure_00243591()
	{
		return MFlags.All.Length;
	}

	internal static int _0024constructor_0024closure_00243592()
	{
		return MGachaRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243593()
	{
		return MGachaTypeValues.All.Length;
	}

	internal static int _0024constructor_0024closure_00243594()
	{
		return MGachaTypesForClient.All.Length;
	}

	internal static int _0024constructor_0024closure_00243595()
	{
		return MGachas.All.Length;
	}

	internal static int _0024constructor_0024closure_00243596()
	{
		return MGameObjectNames.All.Length;
	}

	internal static int _0024constructor_0024closure_00243597()
	{
		return MGameParameters.All.Length;
	}

	internal static int _0024constructor_0024closure_00243598()
	{
		return MGenders.All.Length;
	}

	internal static int _0024constructor_0024closure_00243599()
	{
		return MHonors.All.Length;
	}

	internal static int _0024constructor_0024closure_00243600()
	{
		return MInAppProducts.All.Length;
	}

	internal static int _0024constructor_0024closure_00243601()
	{
		return MInviteRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243602()
	{
		return MItemTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243603()
	{
		return MKeyItems.All.Length;
	}

	internal static int _0024constructor_0024closure_00243604()
	{
		return MKusamushi.All.Length;
	}

	internal static int _0024constructor_0024closure_00243605()
	{
		return MLevelUpTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243606()
	{
		return MLoginBonusItems.All.Length;
	}

	internal static int _0024constructor_0024closure_00243607()
	{
		return MLoginBonusTypeValues.All.Length;
	}

	internal static int _0024constructor_0024closure_00243608()
	{
		return MLoginBonuses.All.Length;
	}

	internal static int _0024constructor_0024closure_00243609()
	{
		return MLoginRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243610()
	{
		return MMapLinkDir.All.Length;
	}

	internal static int _0024constructor_0024closure_00243611()
	{
		return MMarketTypeValues.All.Length;
	}

	internal static int _0024constructor_0024closure_00243612()
	{
		return MMasterTypeValues.All.Length;
	}

	internal static int _0024constructor_0024closure_00243613()
	{
		return MMonsters.All.Length;
	}

	internal static int _0024constructor_0024closure_00243614()
	{
		return MNormalAttackRange.All.Length;
	}

	internal static int _0024constructor_0024closure_00243615()
	{
		return MNpcTalkIcons.All.Length;
	}

	internal static int _0024constructor_0024closure_00243616()
	{
		return MNpcTalkTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243617()
	{
		return MNpcTalks.All.Length;
	}

	internal static int _0024constructor_0024closure_00243618()
	{
		return MNpcTexts.All.Length;
	}

	internal static int _0024constructor_0024closure_00243619()
	{
		return MNpcs.All.Length;
	}

	internal static int _0024constructor_0024closure_00243620()
	{
		return MParameterCorrects.All.Length;
	}

	internal static int _0024constructor_0024closure_00243621()
	{
		return MPlayerDeckMains.All.Length;
	}

	internal static int _0024constructor_0024closure_00243622()
	{
		return MPlayerDeckSupports.All.Length;
	}

	internal static int _0024constructor_0024closure_00243623()
	{
		return MPlayerGroups.All.Length;
	}

	internal static int _0024constructor_0024closure_00243624()
	{
		return MPlayerParameters.All.Length;
	}

	internal static int _0024constructor_0024closure_00243625()
	{
		return MPlayerPoppetDecks.All.Length;
	}

	internal static int _0024constructor_0024closure_00243626()
	{
		return MPlayerRaces.All.Length;
	}

	internal static int _0024constructor_0024closure_00243627()
	{
		return MPlayers.All.Length;
	}

	internal static int _0024constructor_0024closure_00243628()
	{
		return MPoppetChatTimings.All.Length;
	}

	internal static int _0024constructor_0024closure_00243629()
	{
		return MPoppetChats.All.Length;
	}

	internal static int _0024constructor_0024closure_00243630()
	{
		return MPoppetPersonalities.All.Length;
	}

	internal static int _0024constructor_0024closure_00243631()
	{
		return MPoppets.All.Length;
	}

	internal static int _0024constructor_0024closure_00243632()
	{
		return MPresentTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243633()
	{
		return MQuestClearTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243634()
	{
		return MQuestClears.All.Length;
	}

	internal static int _0024constructor_0024closure_00243635()
	{
		return MQuestDrops.All.Length;
	}

	internal static int _0024constructor_0024closure_00243636()
	{
		return MQuestFirstRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243637()
	{
		return MQuestMonsters.All.Length;
	}

	internal static int _0024constructor_0024closure_00243638()
	{
		return MQuestTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243639()
	{
		return MQuests.All.Length;
	}

	internal static int _0024constructor_0024closure_00243640()
	{
		return MRaces.All.Length;
	}

	internal static int _0024constructor_0024closure_00243641()
	{
		return MRaidBattleRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243642()
	{
		return MRaidBattles.All.Length;
	}

	internal static int _0024constructor_0024closure_00243643()
	{
		return MRaidTutorialRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243644()
	{
		return MRaidWordTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243645()
	{
		return MRaidWords.All.Length;
	}

	internal static int _0024constructor_0024closure_00243646()
	{
		return MRankingRewardTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243647()
	{
		return MRankingRewards.All.Length;
	}

	internal static int _0024constructor_0024closure_00243648()
	{
		return MRares.All.Length;
	}

	internal static int _0024constructor_0024closure_00243649()
	{
		return MSaleGachaGroups.All.Length;
	}

	internal static int _0024constructor_0024closure_00243650()
	{
		return MSaleGachas.All.Length;
	}

	internal static int _0024constructor_0024closure_00243651()
	{
		return MSaleTypeValues.All.Length;
	}

	internal static int _0024constructor_0024closure_00243652()
	{
		return MSceneBgm.All.Length;
	}

	internal static int _0024constructor_0024closure_00243653()
	{
		return MScenes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243654()
	{
		return MSe.All.Length;
	}

	internal static int _0024constructor_0024closure_00243655()
	{
		return MSeTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243656()
	{
		return MSellTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243657()
	{
		return MShopMessage.All.Length;
	}

	internal static int _0024constructor_0024closure_00243658()
	{
		return MShopMessageTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243659()
	{
		return MShortcutChildIcons.All.Length;
	}

	internal static int _0024constructor_0024closure_00243660()
	{
		return MShortcutIcons.All.Length;
	}

	internal static int _0024constructor_0024closure_00243661()
	{
		return MSkillActionTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243662()
	{
		return MSkillEffectTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243663()
	{
		return MStageBattles.All.Length;
	}

	internal static int _0024constructor_0024closure_00243664()
	{
		return MStageMonsters.All.Length;
	}

	internal static int _0024constructor_0024closure_00243665()
	{
		return MStages.All.Length;
	}

	internal static int _0024constructor_0024closure_00243666()
	{
		return MStatus.All.Length;
	}

	internal static int _0024constructor_0024closure_00243667()
	{
		return MStepGachaTypes.All.Length;
	}

	internal static int _0024constructor_0024closure_00243668()
	{
		return MStories.All.Length;
	}

	internal static int _0024constructor_0024closure_00243669()
	{
		return MStoryBooks.All.Length;
	}

	internal static int _0024constructor_0024closure_00243670()
	{
		return MStoryGroups.All.Length;
	}

	internal static int _0024constructor_0024closure_00243671()
	{
		return MStyles.All.Length;
	}

	internal static int _0024constructor_0024closure_00243672()
	{
		return MTexts.All.Length;
	}

	internal static int _0024constructor_0024closure_00243673()
	{
		return MTipsMessage.All.Length;
	}

	internal static int _0024constructor_0024closure_00243674()
	{
		return MTutorialItems.All.Length;
	}

	internal static int _0024constructor_0024closure_00243675()
	{
		return MWarps.All.Length;
	}

	internal static int _0024constructor_0024closure_00243676()
	{
		return MWeaponSkills.All.Length;
	}

	internal static int _0024constructor_0024closure_00243677()
	{
		return MWeapons.All.Length;
	}

	internal static int _0024constructor_0024closure_00243678()
	{
		return MWeek.All.Length;
	}

	internal static int _0024constructor_0024closure_00243679()
	{
		return MWeekBonus.All.Length;
	}

	internal static int _0024constructor_0024closure_00243680()
	{
		return MWeekEvents.All.Length;
	}

	internal static int _0024constructor_0024closure_00243681()
	{
		return MWindowTypes.All.Length;
	}
}
