using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestMenuBase : UIMain
{
	[Serializable]
	public enum QUEST_INFO_TYPE
	{
		None = -1,
		TREASURE,
		MONSTER,
		Max
	}

	[Serializable]
	internal class _0024UpdateTreasureIcon_0024locals_002414536
	{
		internal int _0024n;

		internal Hashtable _0024getItemTab;
	}

	[Serializable]
	internal class _0024_sendConfQuestDeck_0024locals_002414537
	{
		internal ApiUpdateDeck2 _0024req;
	}

	[Serializable]
	internal class _0024UpdateTreasureIcon_0024setIcon_00243079
	{
		internal _0024UpdateTreasureIcon_0024locals_002414536 _0024_0024locals_002415195;

		internal QuestMenuBase _0024this_002415196;

		public _0024UpdateTreasureIcon_0024setIcon_00243079(_0024UpdateTreasureIcon_0024locals_002414536 _0024_0024locals_002415195, QuestMenuBase _0024this_002415196)
		{
			this._0024_0024locals_002415195 = _0024_0024locals_002415195;
			this._0024this_002415196 = _0024this_002415196;
		}

		public void Invoke(EnumRares rare, int id, string wpnOrPpt)
		{
			if (_0024_0024locals_002415195._0024n < _0024this_002415196.treasureIcon.Length && id > 0)
			{
				TreasureBoxIcon.BOX_ICON_TYPE iconType = ((debug_disp_treasure || (_0024_0024locals_002415195._0024getItemTab != null && _0024_0024locals_002415195._0024getItemTab.ContainsKey(new StringBuilder().Append(wpnOrPpt).Append((object)id).ToString()))) ? ((!(wpnOrPpt == "w")) ? TreasureBoxIcon.BOX_ICON_TYPE.Poppet : TreasureBoxIcon.BOX_ICON_TYPE.Weapon) : (rare switch
				{
					EnumRares.special_rare_plus => TreasureBoxIcon.BOX_ICON_TYPE.SuperRarePlus, 
					EnumRares.special_rare => TreasureBoxIcon.BOX_ICON_TYPE.SuperRare, 
					EnumRares.rare_plus => TreasureBoxIcon.BOX_ICON_TYPE.RarePlus, 
					EnumRares.rare => TreasureBoxIcon.BOX_ICON_TYPE.Rare, 
					EnumRares.normal_plus => TreasureBoxIcon.BOX_ICON_TYPE.NormalPlus, 
					_ => TreasureBoxIcon.BOX_ICON_TYPE.Normal, 
				}));
				TreasureBoxIcon[] treasureIcon = _0024this_002415196.treasureIcon;
				treasureIcon[RuntimeServices.NormalizeArrayIndex(treasureIcon, _0024_0024locals_002415195._0024n)].IgnoreUnknown = debug_disp_treasure;
				TreasureBoxIcon[] treasureIcon2 = _0024this_002415196.treasureIcon;
				treasureIcon2[RuntimeServices.NormalizeArrayIndex(treasureIcon2, _0024_0024locals_002415195._0024n)].SetIcon(iconType, id);
				_0024_0024locals_002415195._0024n = checked(_0024_0024locals_002415195._0024n + 1);
			}
		}
	}

	[Serializable]
	internal class _0024_sendConfQuestDeck_0024closure_00243285
	{
		internal _0024_sendConfQuestDeck_0024locals_002414537 _0024_0024locals_002415197;

		internal QuestMenuBase _0024this_002415198;

		public _0024_sendConfQuestDeck_0024closure_00243285(_0024_sendConfQuestDeck_0024locals_002414537 _0024_0024locals_002415197, QuestMenuBase _0024this_002415198)
		{
			this._0024_0024locals_002415197 = _0024_0024locals_002415197;
			this._0024this_002415198 = _0024this_002415198;
		}

		public void Invoke(RequestBase r)
		{
			if (!_0024_0024locals_002415197._0024req.HasMasterVersionError && !_0024_0024locals_002415197._0024req.HasDataVersionError && !_0024_0024locals_002415197._0024req.HasClientVersionError && !_0024_0024locals_002415197._0024req.GotoBootError && !_0024_0024locals_002415197._0024req.Is500Error && !_0024_0024locals_002415197._0024req.Is400Error)
			{
				_0024this_002415198._sendEquipError = true;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SendDeck2_002421898 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024run_002421899;

			internal IEnumerator _0024_0024sco_0024temp_00242639_002421900;

			internal QuestMenuBase _0024self__002421901;

			public _0024(QuestMenuBase self_)
			{
				_0024self__002421901 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!UserData.Current.IsValidDeck2)
					{
						goto IL_0112;
					}
					if (_0024self__002421901._sendEquipError)
					{
						_0024self__002421901._sendEquip = false;
					}
					if (DeckSelector.isDirty)
					{
						_0024self__002421901._sendEquip = false;
					}
					if (_0024self__002421901._sendEquip)
					{
						goto case 1;
					}
					_0024self__002421901._sendEquipResult = false;
					_0024self__002421901._sendEquipError = false;
					_0024run_002421899 = false;
					_0024self__002421901.CancelSendHook();
					_0024_0024sco_0024temp_00242639_002421900 = _0024self__002421901._sendConfQuestDeck();
					if (_0024_0024sco_0024temp_00242639_002421900 != null)
					{
						_0024self__002421901.StartCoroutine(_0024_0024sco_0024temp_00242639_002421900);
					}
					goto case 2;
				case 2:
					if (!_0024self__002421901._sendEquipResult)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024self__002421901._sendEquipError)
					{
						_0024run_002421899 = true;
					}
					if (!_0024run_002421899)
					{
						goto case 1;
					}
					goto IL_0112;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0112:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal QuestMenuBase _0024self__002421902;

		public _0024SendDeck2_002421898(QuestMenuBase self_)
		{
			_0024self__002421902 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421902);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartQuest_002421903 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242640_002421904;

			internal IEnumerator _0024_0024sco_0024temp_00242641_002421905;

			internal QuestMenuBase _0024self__002421906;

			public _0024(QuestMenuBase self_)
			{
				_0024self__002421906 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (DeckSelector.isSwipe)
					{
						goto case 1;
					}
					_0024self__002421906._sendEquipError = false;
					MerlinServer.Busy = true;
					_0024_0024sco_0024temp_00242640_002421904 = _0024self__002421906.SendDeck2();
					if (_0024_0024sco_0024temp_00242640_002421904 != null)
					{
						result = (Yield(2, _0024self__002421906.StartCoroutine(_0024_0024sco_0024temp_00242640_002421904)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (!_0024self__002421906._sendEquipError)
					{
						_0024_0024sco_0024temp_00242641_002421905 = _0024self__002421906.StartQuestCore();
						if (_0024_0024sco_0024temp_00242641_002421905 != null)
						{
							result = (Yield(3, _0024self__002421906.StartCoroutine(_0024_0024sco_0024temp_00242641_002421905)) ? 1 : 0);
							break;
						}
					}
					goto case 3;
				case 3:
					MerlinServer.Busy = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal QuestMenuBase _0024self__002421907;

		public _0024StartQuest_002421903(QuestMenuBase self_)
		{
			_0024self__002421907 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421907);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_sendConfQuestDeck_002421908 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002421909;

			internal int _0024currentIndex_002421910;

			internal _0024_sendConfQuestDeck_0024locals_002414537 _0024_0024locals_002421911;

			internal QuestMenuBase _0024self__002421912;

			public _0024(QuestMenuBase self_)
			{
				_0024self__002421912 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421911 = new _0024_sendConfQuestDeck_0024locals_002414537();
					if (_0024self__002421912._sendEquip)
					{
						goto case 1;
					}
					_0024self__002421912._sendEquip = true;
					_0024ud_002421909 = UserData.Current;
					if (_0024ud_002421909 == null)
					{
						throw new AssertionFailedException("ud");
					}
					_0024currentIndex_002421910 = DeckSelector.currentDeckIndex;
					if (DeckSelector.isDirty || _isEquipChanged)
					{
						_0024_0024locals_002421911._0024req = ConfQuest.CreateDeck2Request();
						_0024_0024locals_002421911._0024req.ErrorHandler = new _0024_sendConfQuestDeck_0024closure_00243285(_0024_0024locals_002421911, _0024self__002421912).Invoke;
						MerlinServer.Request(_0024_0024locals_002421911._0024req);
						goto case 2;
					}
					_0024self__002421912._sendEquipResult = true;
					goto IL_012a;
				case 2:
					if (!_0024_0024locals_002421911._0024req.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421912._sendEquipResult = true;
					if (!_0024self__002421912._sendEquipError)
					{
						DeckSelector.OnSent();
					}
					goto IL_012a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_012a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal QuestMenuBase _0024self__002421913;

		public _0024_sendConfQuestDeck_002421908(QuestMenuBase self_)
		{
			_0024self__002421913 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421913);
		}
	}

	public GameObject dropItemlist;

	public StoneList stoneList;

	protected bool stoneListBusy;

	public TreasureBoxIcon[] treasureIcon;

	public GameObject detailPoppetInfoPrefab;

	public Transform detailPoppetInfoParent;

	protected MuppetInfo detailPoppetInfo;

	public GameObject detailWeaponInfoPrefab;

	public Transform detailWeaponInfoParent;

	protected WeaponInfo detailWeaponInfo;

	public MuppetInfo mapetInfo;

	public MapetList mapetList;

	public DeckSelector confQuest;

	private WeaponInfo confMainWapIcon;

	private MuppetInfo confPetIcon;

	private MuppetInfo confFrPetIcon;

	public UIButtonMessage selFrPetButton;

	public UIButtonMessage confQuestButton;

	public UIButtonMessage detailButton;

	protected UIValidController selFrPetButtonValidCtrl;

	protected UIValidController confQuestButtonValidCtrl;

	protected UIValidController detailButtonValidCtrl;

	public UIButtonMessage treasureButton;

	public UIButtonMessage monsterButton;

	public MuppetInfo[] questMobPanels;

	public GameObject[] questInfoPanel;

	protected QUEST_INFO_TYPE curInfo;

	[NonSerialized]
	protected static RespFriend[] respFriends;

	protected MQuests curQuest;

	protected MQuests lastQuest;

	protected RespWeapon curWeapon;

	private RespWeapon lastWeapon;

	private RespWeapon curSub1Weapon;

	private RespWeapon lastSub1Weapon;

	private RespWeapon curSub2Weapon;

	private RespWeapon lastSub2Weapon;

	protected RespPoppet curPet;

	private RespPoppet lastPet;

	protected RespFriendPoppet curFrPet;

	private RespFriendPoppet lastFrPet;

	protected QuestManager questManager;

	protected DialogManager dlgMan;

	public MAreas curArea;

	public MissionList missionList;

	public UIButtonMessage missionButton;

	protected bool _sendEquipError;

	protected bool _sendEquipResult;

	protected bool _sendEquip;

	protected bool _isShowConfQuestSupportDialog;

	[NonSerialized]
	protected static bool _isEquipChanged;

	[NonSerialized]
	public static bool debug_disp_treasure;

	protected bool initConfQuest;

	protected bool isFromMyhomeEquip => (SceneChanger.LastSceneName == "Ui_MyHomeEquip" && !BattleHUDShortcut.IsSceneFromShortcut) ? true : false;

	public DeckSelector deckSelect => confQuest;

	public static bool IsEquipChanged
	{
		get
		{
			return _isEquipChanged;
		}
		set
		{
			_isEquipChanged = value;
		}
	}

	public bool IsShowConfQuestSupportDialog
	{
		get
		{
			return _isShowConfQuestSupportDialog;
		}
		set
		{
			_isShowConfQuestSupportDialog = value;
		}
	}

	public QuestMenuBase()
	{
		questMobPanels = new MuppetInfo[6];
		questInfoPanel = new GameObject[2];
		curInfo = QUEST_INFO_TYPE.MONSTER;
	}

	public override void SceneAwake()
	{
		curInfo = UserData.Current.userMiscInfo.questInfoType;
		_sendEquip = false;
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			InitDeck2Equip(isFromMyhomeEquip);
		});
	}

	protected void OnDestroy()
	{
		ModalCollider.SetActive(this, active: false);
		UserData.Current.userMiscInfo.questInfoType = curInfo;
	}

	protected void InitDetail()
	{
		if (null != detailWeaponInfoPrefab)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(detailWeaponInfoPrefab);
			detailWeaponInfo = gameObject.GetComponent<WeaponInfo>();
			gameObject.transform.parent = detailWeaponInfoParent;
			gameObject.transform.localPosition = new Vector3(0f, 0f, -200f);
			gameObject.transform.localScale = Vector3.one;
			gameObject.SetActive(value: false);
		}
		if (null != detailPoppetInfoPrefab)
		{
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(detailPoppetInfoPrefab);
			detailPoppetInfo = gameObject2.GetComponent<MuppetInfo>();
			gameObject2.transform.parent = detailPoppetInfoParent;
			gameObject2.transform.localPosition = new Vector3(0f, 0f, -200f);
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.SetActive(value: false);
		}
	}

	protected bool ResetRespFriends()
	{
		int result;
		if (isFromMyhomeEquip)
		{
			result = 0;
		}
		else
		{
			respFriends = null;
			result = 1;
		}
		return (byte)result != 0;
	}

	protected void InitFriendPetList()
	{
		UserData current = UserData.Current;
		if (current == null || !mapetList || mapetList.isInitFinished)
		{
			return;
		}
		RespPoppet[] array = new RespPoppet[0];
		int num = 0;
		checked
		{
			if (respFriends != null)
			{
				int num2 = 0;
				int i = 0;
				RespFriend[] array2 = respFriends;
				for (int length = array2.Length; i < length; i++)
				{
					if (array2[i] == null)
					{
						continue;
					}
					num++;
					RespFriendPoppet respFriendPoppet = new RespFriendPoppet(array2[i]);
					respFriendPoppet.Id = new BoxId(num2);
					if (string.IsNullOrEmpty(array2[i].Name))
					{
						continue;
					}
					respFriendPoppet.FriendPoint = 5;
					if (current.userFriendListData != null)
					{
						RespFriend respFriend = current.findFriend(array2[i].TSocialPlayerId);
						bool flag = respFriend != null;
						if (GameParameter.itsFriend)
						{
							respFriendPoppet.IsFriend = true;
							flag = true;
						}
						if (flag)
						{
							respFriendPoppet.FriendPoint = 10;
						}
					}
					array = (RespPoppet[])RuntimeServices.AddArrays(typeof(RespPoppet), array, new RespPoppet[1] { respFriendPoppet as RespPoppet });
					current.userMiscInfo.poppetBookData.look(respFriendPoppet.Master);
					num2++;
				}
				BoxId boxId = default(BoxId);
				if (curFrPet != null)
				{
					boxId = curFrPet.Id;
				}
				mapetList.SetFocusItem(boxId.Value);
				mapetList.DefaultSortFunc = SortFuncs.SetFriendPoppetListSortFuncs;
				mapetList.SetInputMapetList(array);
				if (curFrPet == null)
				{
					mapetList.SelectItem(0);
				}
				else
				{
					mapetList.SelectItemById(curFrPet.Id.Value, canDecide: false);
				}
			}
			if (num == 0)
			{
				Dialog dialog = DialogManager.Open(MTexts.Msg("$QM_FRIEND_LIST_ERROR"), string.Empty);
				dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					SceneChanger.ChangeTo(SceneID.Ui_World);
				};
			}
		}
	}

	protected bool hookFriendListSelect(UIListItem item)
	{
		MapetListItem mapetListItem = (MapetListItem)item;
		RespFriendPoppet data = item.GetData<RespFriendPoppet>();
		int result;
		if (RuntimeServices.EqualityOperator(curFrPet, data))
		{
			SelectPet();
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	protected virtual void SelectPet()
	{
	}

	protected bool hookFriendListSettingItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		if (!(item is MapetListItem))
		{
			throw new AssertionFailedException("MapetListItem じゃないUIListItemが渡されました");
		}
		MapetListItem mapetListItem = (MapetListItem)item;
		RespFriendPoppet data = item.GetData<RespFriendPoppet>();
		if (data != null)
		{
			mapetListItem.SetMapet(data, ignoreUnknown: true);
			RespFriend respFriend = data.RespFriend;
			if (respFriend != null)
			{
				DateTime utcNow = MerlinDateTime.UtcNow;
				TimeSpan timeSpan = utcNow - respFriend.LastAccessDate;
				string text = null;
				string[] array = new string[4]
				{
					MTexts.Msg("exp_1_hour_ago"),
					MTexts.Msg("exp_x_hours_ago"),
					MTexts.Msg("exp_x_days_ago"),
					MTexts.Msg("exp_5over_days_ago")
				};
				text = checked(((int)timeSpan.TotalDays >= 5) ? UIBasicUtility.SafeFormat(array[3], 5) : (((int)timeSpan.TotalDays > 0) ? UIBasicUtility.SafeFormat(array[2], (int)timeSpan.TotalDays) : (((int)timeSpan.TotalHours <= 0) ? UIBasicUtility.SafeFormat(array[0], (int)timeSpan.TotalMinutes) : UIBasicUtility.SafeFormat(array[1], (int)timeSpan.TotalHours))));
				mapetListItem.SetExtraParam(0, text);
				mapetListItem.SetExtraGameObject(0, activeFlag: true);
				string param = MTexts.Msg("exp_friend");
				string bgPanelSprite = "subwindow_a03";
				bool flag = UserData.Current.findFriend(respFriend.TSocialPlayerId) != null;
				if (GameParameter.itsFriend)
				{
					flag = true;
				}
				if (!flag)
				{
					bgPanelSprite = "subwindow_a05";
					param = string.Empty;
					mapetListItem.SetExtraGameObject(0, activeFlag: false);
				}
				mapetListItem.SetExtraParam(1, param);
				mapetListItem.SetBgPanelSprite(bgPanelSprite);
			}
		}
		NGUITools.DestroyAllSameComponent<UIPanel>(mapetListItem.gameObject);
		return true;
	}

	protected void FriendPetListCtrl()
	{
		if ((bool)mapetList)
		{
			curFrPet = mapetList.GetFocusData<RespFriendPoppet>();
			if (!RuntimeServices.EqualityOperator(curFrPet, lastFrPet))
			{
				if ((bool)mapetInfo)
				{
					mapetInfo.SetMuppet(curFrPet, ignoreUnknown: true);
				}
				lastFrPet = curFrPet;
			}
		}
		if (curFrPet != null)
		{
			if ((bool)selFrPetButtonValidCtrl)
			{
				selFrPetButtonValidCtrl.isValidColor = true;
			}
			if ((bool)detailButtonValidCtrl)
			{
				detailButtonValidCtrl.isValidColor = true;
			}
		}
		else
		{
			if ((bool)selFrPetButtonValidCtrl)
			{
				selFrPetButtonValidCtrl.isValidColor = false;
			}
			if ((bool)detailButtonValidCtrl)
			{
				detailButtonValidCtrl.isValidColor = false;
			}
		}
	}

	protected void InitQuestInfo()
	{
	}

	protected void SetQuestInfo(QUEST_INFO_TYPE type)
	{
		curInfo = type;
		UserData.Current.userMiscInfo.questInfoType = curInfo;
		int num = 0;
		int i = 0;
		GameObject[] array = questInfoPanel;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].SetActive(type == (QUEST_INFO_TYPE)num);
			}
			num = checked(num + 1);
		}
		Color color = Color.white;
		if (type != 0)
		{
			color = Color.grey;
		}
		TweenColor.Begin(treasureButton.gameObject, 0.2f, color);
		Color color2 = Color.white;
		if (type != QUEST_INFO_TYPE.MONSTER)
		{
			color2 = Color.grey;
		}
		TweenColor.Begin(monsterButton.gameObject, 0.2f, color2);
	}

	protected void UpdateMonsterList(MQuests quest)
	{
		int i = 0;
		checked
		{
			if (quest != null)
			{
				MQuestMonsters mQuestMonsters = MQuestMonsters.Get(quest.Id);
				if (mQuestMonsters == null)
				{
					throw new AssertionFailedException("qutstMob");
				}
				Boo.Lang.List<KeyValuePair<object, int[]>> list = new Boo.Lang.List<KeyValuePair<object, int[]>>();
				int j = 0;
				MMonsters[] monsters = mQuestMonsters.Monsters;
				for (int length = monsters.Length; j < length; j++)
				{
					MPoppets poppet = monsters[j].Poppet;
					list.Add(new KeyValuePair<object, int[]>(monsters[j], new int[2]
					{
						poppet.Rare.Id,
						poppet.Id
					}));
				}
				__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24__ from = (KeyValuePair<object, int[]> p1, KeyValuePair<object, int[]> p2) => (p1.Value[0] != p2.Value[0]) ? (p1.Value[0] - p2.Value[0]) : (p1.Value[1] - p2.Value[1]);
				list.Sort(_0024adaptor_0024__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24___0024Comparison_0024207.Adapt(from));
				RespPoppet respPoppet = null;
				for (; i < questMobPanels.Length; i++)
				{
					MuppetInfo[] array = questMobPanels;
					MuppetInfo muppetInfo = array[RuntimeServices.NormalizeArrayIndex(array, i)];
					if (!muppetInfo)
					{
						throw new AssertionFailedException("muppetInfo");
					}
					respPoppet = null;
					if (i < list.Count)
					{
						if (list[i].Key is MMonsters mMonsters)
						{
							respPoppet = new RespPoppet(mMonsters.Poppet.Id);
						}
						if (respPoppet != null && string.IsNullOrEmpty(respPoppet.Icon))
						{
							respPoppet = null;
						}
						if (respPoppet != null)
						{
							muppetInfo.SetMuppet(respPoppet, ignoreUnknown: true);
						}
					}
					muppetInfo.gameObject.SetActive(respPoppet != null);
				}
			}
			for (; i < questMobPanels.Length; i++)
			{
				MuppetInfo[] array2 = questMobPanels;
				MuppetInfo muppetInfo = array2[RuntimeServices.NormalizeArrayIndex(array2, i)];
				if (!muppetInfo)
				{
					throw new AssertionFailedException("muppetInfo");
				}
				muppetInfo.gameObject.SetActive(value: false);
			}
		}
	}

	public virtual void ConfQuestCtrl()
	{
		if (!initConfQuest)
		{
			DeckSelector.SetCurEquip();
			initConfQuest = true;
		}
		if (curFrPet != null && curQuest != null && curPet != null && curWeapon != null)
		{
			if ((bool)confQuestButtonValidCtrl)
			{
				confQuestButtonValidCtrl.isValidColor = true;
			}
		}
		else if ((bool)confQuestButtonValidCtrl)
		{
			confQuestButtonValidCtrl.isValidColor = false;
		}
	}

	protected void UpdateTreasureIcon(MQuests quest)
	{
		_0024UpdateTreasureIcon_0024locals_002414536 _0024UpdateTreasureIcon_0024locals_0024 = new _0024UpdateTreasureIcon_0024locals_002414536();
		debug_disp_treasure = false;
		_0024UpdateTreasureIcon_0024locals_0024._0024n = 0;
		if (quest != null)
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				return;
			}
			_0024UpdateTreasureIcon_0024locals_0024._0024getItemTab = current.userMiscInfo.treasureData.get(quest.Id.ToString());
			MQuestDrops mQuestDrops = MQuestDrops.Get(quest.Id);
			__QuestMenuBase_UpdateTreasureIcon_0024callable134_0024395_17__ _QuestMenuBase_UpdateTreasureIcon_0024callable134_0024395_17__ = new _0024UpdateTreasureIcon_0024setIcon_00243079(_0024UpdateTreasureIcon_0024locals_0024, this).Invoke;
			if (mQuestDrops != null)
			{
				Boo.Lang.List<KeyValuePair<object, int[]>> list = new Boo.Lang.List<KeyValuePair<object, int[]>>();
				IEnumerator enumerator = mQuestDrops.Weapons.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is MWeapons))
					{
						obj = RuntimeServices.Coerce(obj, typeof(MWeapons));
					}
					MWeapons mWeapons = (MWeapons)obj;
					list.Add(new KeyValuePair<object, int[]>(mWeapons, new int[2]
					{
						mWeapons.Rare.Id,
						mWeapons.Id
					}));
				}
				IEnumerator enumerator2 = mQuestDrops.Poppets.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					if (!(obj2 is MPoppets))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(MPoppets));
					}
					MPoppets mPoppets = (MPoppets)obj2;
					list.Add(new KeyValuePair<object, int[]>(mPoppets, new int[2]
					{
						mPoppets.Rare.Id,
						mPoppets.Id
					}));
				}
				__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24__ from = (KeyValuePair<object, int[]> p1, KeyValuePair<object, int[]> p2) => checked((p1.Value[0] != p2.Value[0]) ? (p1.Value[0] - p2.Value[0]) : (p1.Value[1] - p2.Value[1]));
				list.Sort(_0024adaptor_0024__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24___0024Comparison_0024207.Adapt(from));
				IEnumerator<KeyValuePair<object, int[]>> enumerator3 = list.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						KeyValuePair<object, int[]> current2 = enumerator3.Current;
						if (current2.Key is MWeapons mWeapons2)
						{
							_QuestMenuBase_UpdateTreasureIcon_0024callable134_0024395_17__((EnumRares)mWeapons2.Rare.Id, mWeapons2.Id, "w");
						}
						if (current2.Key is MPoppets mPoppets2)
						{
							_QuestMenuBase_UpdateTreasureIcon_0024callable134_0024395_17__((EnumRares)mPoppets2.Rare.Id, mPoppets2.Id, "p");
						}
					}
				}
				finally
				{
					enumerator3.Dispose();
				}
			}
		}
		checked
		{
			while (_0024UpdateTreasureIcon_0024locals_0024._0024n < treasureIcon.Length)
			{
				TreasureBoxIcon[] array = treasureIcon;
				array[RuntimeServices.NormalizeArrayIndex(array, _0024UpdateTreasureIcon_0024locals_0024._0024n)].SetIcon(TreasureBoxIcon.BOX_ICON_TYPE.None, 0);
				_0024UpdateTreasureIcon_0024locals_0024._0024n++;
			}
		}
	}

	private void SelectMainWeapon()
	{
		if (!DeckSelector.isSwipe)
		{
			_updateMyHomeArguments();
			GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE.MainWeaponList);
		}
	}

	private void SelectSub1Weapon()
	{
		if (!DeckSelector.isSwipe)
		{
			_updateMyHomeArguments();
			GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE.Sub1WeaponList);
		}
	}

	private void SelectSub2Weapon()
	{
		if (!DeckSelector.isSwipe)
		{
			_updateMyHomeArguments();
			GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE.Sub2WeaponList);
		}
	}

	private void SelectMyPet()
	{
		if (!DeckSelector.isSwipe)
		{
			_updateMyHomeArguments();
			GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE.PoppetList);
		}
	}

	private virtual void GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE startMode)
	{
	}

	protected IEnumerator SendDeck2()
	{
		return new _0024SendDeck2_002421898(this).GetEnumerator();
	}

	private IEnumerator StartQuest(GameObject obj)
	{
		return new _0024StartQuest_002421903(this).GetEnumerator();
	}

	private virtual IEnumerator StartQuestCore()
	{
		return null;
	}

	public void OnClickedSupportAtk(GameObject aObj)
	{
		ConfQuest.SetSupportTypeFromName(aObj.name, aClose: true);
	}

	public void OnClickedSupportHp(GameObject aObj)
	{
		ConfQuest.SetSupportTypeFromName(aObj.name, aClose: true);
	}

	public void OnClickedSupportCustom(GameObject aObj)
	{
		ConfQuest.SetSupportTypeFromName(aObj.name, aClose: false);
		_updateMyHomeArguments();
		GotoMyhome(MyHomeEquipMain.MY_HOME_EQUIP_START_MODE.Support);
	}

	protected void ChangeSceneLikeQuestSubScene(SceneID sceneId)
	{
		CancelSendHook();
		string currentSceneName = SceneChanger.CurrentSceneName;
		SceneChanger.ChangeTo(sceneId);
		BattleHUDShortcut.Instance.IgnoreSceneName = currentSceneName;
	}

	protected void InitDeck2Equip(bool fromMyhomeEquip)
	{
		if (fromMyhomeEquip)
		{
			_isEquipChanged = true;
			InitSendHook();
		}
	}

	protected void InitSendHook()
	{
		SceneChanger.Hook = HookSendEquip;
	}

	protected void CancelSendHook()
	{
		if (new __SceneChanger_Hook_0024callable38_002438_20__(HookSendEquip) == SceneChanger.Hook)
		{
			SceneChanger.Hook = null;
		}
	}

	private bool HookSendEquip(SceneID sceneId, string sceneName)
	{
		bool sendEquipResult;
		if (_sendEquip)
		{
			sendEquipResult = _sendEquipResult;
		}
		else
		{
			IEnumerator enumerator = _sendConfQuestDeck();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			sendEquipResult = _sendEquipResult;
		}
		return sendEquipResult;
	}

	public static DeckItemUi GetDeckItemUi(GameObject aObj)
	{
		DeckItemUi deckItemUi = null;
		return GetDeckItemUi(aObj.transform);
	}

	public static DeckItemUi GetDeckItemUi(Transform aTrs)
	{
		GameObject gameObject = aTrs.gameObject;
		DeckItemUi deckItemUi = gameObject.GetComponent<DeckItemUi>() as DeckItemUi;
		if (deckItemUi == null)
		{
			Transform parent = aTrs.parent;
			if (parent != null)
			{
				deckItemUi = GetDeckItemUi(parent);
			}
		}
		return deckItemUi;
	}

	public static int GetDeckIndex(GameObject aObj)
	{
		int result = 0;
		DeckItemUi deckItemUi = GetDeckItemUi(aObj);
		if (deckItemUi != null)
		{
			result = deckItemUi.deckIndex;
		}
		return result;
	}

	private void _updateMyHomeArguments()
	{
		int currentDeckIndex = DeckSelector.currentDeckIndex;
		ConfQuest.ApplyDeck2Data();
		MyHomeEquipMain.StartOtherDeck(currentDeckIndex);
	}

	protected virtual IEnumerator _sendConfQuestDeck()
	{
		return new _0024_sendConfQuestDeck_002421908(this).GetEnumerator();
	}

	internal void _0024SceneAwake_0024closure_00243047()
	{
		InitDeck2Equip(isFromMyhomeEquip);
	}

	internal void _0024InitFriendPetList_0024closure_00243072()
	{
		SceneChanger.ChangeTo(SceneID.Ui_World);
	}

	internal int _0024UpdateMonsterList_0024closure_00243073(KeyValuePair<object, int[]> p1, KeyValuePair<object, int[]> p2)
	{
		return checked((p1.Value[0] != p2.Value[0]) ? (p1.Value[0] - p2.Value[0]) : (p1.Value[1] - p2.Value[1]));
	}

	internal int _0024UpdateTreasureIcon_0024closure_00243080(KeyValuePair<object, int[]> p1, KeyValuePair<object, int[]> p2)
	{
		return checked((p1.Value[0] != p2.Value[0]) ? (p1.Value[0] - p2.Value[0]) : (p1.Value[1] - p2.Value[1]));
	}
}
