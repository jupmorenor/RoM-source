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
public class MissionList : UIListBase
{
	[Serializable]
	public enum ListType
	{
		None = -1,
		Normal = 1,
		Result = 2,
		All = 3
	}

	[Serializable]
	public class MissionInfo
	{
		public RespQuestMission mission;

		public bool isClear;

		public bool isAnimFinished;

		public RespQuestMission newMission;
	}

	[Serializable]
	internal class _0024ClearAndNewItemAnimation_0024locals_002414473
	{
		internal MissionListItem _0024listItem;

		internal ICallable _0024finish;
	}

	[Serializable]
	internal class _0024PushMissionItem_0024locals_002414474
	{
		internal int _0024index;
	}

	[Serializable]
	internal class _0024_0024StartNewMissionAnimation_0024closure_00243237_0024locals_002414475
	{
		internal int _0024count;
	}

	[Serializable]
	internal class _0024ClearAndNewItemAnimation_0024closure_00243239
	{
		internal _0024ClearAndNewItemAnimation_0024locals_002414473 _0024_0024locals_002415044;

		public _0024ClearAndNewItemAnimation_0024closure_00243239(_0024ClearAndNewItemAnimation_0024locals_002414473 _0024_0024locals_002415044)
		{
			this._0024_0024locals_002415044 = _0024_0024locals_002415044;
		}

		public void Invoke()
		{
			_0024_0024locals_002415044._0024listItem.contentsRoot.gameObject.SetActive(value: false);
			if (_0024_0024locals_002415044._0024finish != null)
			{
				_0024_0024locals_002415044._0024finish.Call(new object[0]);
			}
		}
	}

	[Serializable]
	internal class _0024_0024StartNewMissionAnimation_0024closure_00243237_0024closure_00243238
	{
		internal int _0024i_002415045;

		internal _0024_0024StartNewMissionAnimation_0024closure_00243237_0024locals_002414475 _0024_0024locals_002415046;

		internal MissionList _0024this_002415047;

		public _0024_0024StartNewMissionAnimation_0024closure_00243237_0024closure_00243238(int _0024i_002415045, _0024_0024StartNewMissionAnimation_0024closure_00243237_0024locals_002414475 _0024_0024locals_002415046, MissionList _0024this_002415047)
		{
			this._0024i_002415045 = _0024i_002415045;
			this._0024_0024locals_002415046 = _0024_0024locals_002415046;
			this._0024this_002415047 = _0024this_002415047;
		}

		public void Invoke()
		{
			MissionInfo data = _0024this_002415047.GetData(_0024i_002415045).GetData<MissionInfo>();
			if (data != null)
			{
				data.isAnimFinished = true;
			}
			_0024_0024locals_002415046._0024count = checked(_0024_0024locals_002415046._0024count + 1);
		}
	}

	[Serializable]
	internal class _0024PushMissionItem_0024closure_00243240
	{
		internal _0024PushMissionItem_0024locals_002414474 _0024_0024locals_002415048;

		internal MissionList _0024this_002415049;

		public _0024PushMissionItem_0024closure_00243240(_0024PushMissionItem_0024locals_002414474 _0024_0024locals_002415048, MissionList _0024this_002415049)
		{
			this._0024_0024locals_002415048 = _0024_0024locals_002415048;
			this._0024this_002415049 = _0024this_002415049;
		}

		public void Invoke()
		{
			MissionInfo data = _0024this_002415049.GetData(_0024_0024locals_002415048._0024index).GetData<MissionInfo>();
			if (data != null)
			{
				data.isAnimFinished = true;
			}
			int num = 0;
			int num2 = 0;
			int num3 = _0024this_002415049.Count();
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index = num2;
				num2++;
				data = _0024this_002415049.GetData(index).GetData<MissionInfo>();
				if (data != null && (!data.isClear || data.isAnimFinished))
				{
					num = checked(num + 1);
				}
			}
			if (num == _0024this_002415049.Count() && null != _0024this_002415049._0024event_0024eventNewMissionAnimationFinish)
			{
				_0024this_002415049.raise_eventNewMissionAnimationFinish();
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024StartNewMissionAnimation_0024closure_00243237_002421389 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_002421390;

			internal int _0024_002410819_002421391;

			internal int _0024_002410820_002421392;

			internal _0024_0024StartNewMissionAnimation_0024closure_00243237_0024locals_002414475 _0024_0024locals_002421393;

			internal int _0024max_002421394;

			internal MissionList _0024self__002421395;

			public _0024(int max, MissionList self_)
			{
				_0024max_002421394 = max;
				_0024self__002421395 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421393 = new _0024_0024StartNewMissionAnimation_0024closure_00243237_0024locals_002414475();
					_0024_0024locals_002421393._0024count = 0;
					_0024_002410819_002421391 = 0;
					_0024_002410820_002421392 = _0024max_002421394;
					if (_0024_002410820_002421392 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (_0024_002410819_002421391 < _0024_002410820_002421392)
					{
						_0024i_002421390 = _0024_002410819_002421391;
						_0024_002410819_002421391++;
						_0024self__002421395.ClearAndNewItemAnimation(_0024i_002421390, _0024self__002421395.newMissionAnimItemsDelay * (float)_0024i_002421390, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024StartNewMissionAnimation_0024closure_00243237_0024closure_00243238(_0024i_002421390, _0024_0024locals_002421393, _0024self__002421395).Invoke));
					}
					goto case 2;
				case 2:
					if (_0024_0024locals_002421393._0024count != _0024max_002421394)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (null != _0024self__002421395._0024event_0024eventNewMissionAnimationFinish)
					{
						_0024self__002421395.raise_eventNewMissionAnimationFinish();
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024max_002421396;

		internal MissionList _0024self__002421397;

		public _0024_0024StartNewMissionAnimation_0024closure_00243237_002421389(int max, MissionList self_)
		{
			_0024max_002421396 = max;
			_0024self__002421397 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024max_002421396, _0024self__002421397);
		}
	}

	private DateTime now;

	private HashSet<int> olds;

	private System.Collections.Generic.List<RespQuestMission> original;

	private bool first;

	private UIMain uimain;

	private MQuests curQuest;

	public GameObject weaponIconPrefab;

	public GameObject mapetIconPrefab;

	public int dispMissionCount;

	public float newMissionAnimTime;

	public float newMissionAnimX;

	public float newMissionAnimStartDelay;

	public float newMissionAnimItemsDelay;

	private float startNewMissionAnimationTime;

	public bool autoStartNewMissionAnimation;

	private bool enablePushItemNewMissionAnimation;

	public bool debugFlag;

	public ListType debugListType;

	public bool debugNewAnimation;

	public bool debugInit;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024event_0024eventNewMissionAnimationFinish;

	public float StartNewMissionAnimationTime
	{
		get
		{
			return startNewMissionAnimationTime;
		}
		set
		{
			startNewMissionAnimationTime = value;
		}
	}

	public bool AutoStartNewMissionAnimation
	{
		get
		{
			return autoStartNewMissionAnimation;
		}
		set
		{
			autoStartNewMissionAnimation = value;
		}
	}

	public bool EnablePushItemNewMissionAnimation
	{
		get
		{
			return enablePushItemNewMissionAnimation;
		}
		set
		{
			enablePushItemNewMissionAnimation = value;
		}
	}

	public event __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ eventNewMissionAnimationFinish
	{
		add
		{
			_0024event_0024eventNewMissionAnimationFinish = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Combine(_0024event_0024eventNewMissionAnimationFinish, value);
		}
		remove
		{
			_0024event_0024eventNewMissionAnimationFinish = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Remove(_0024event_0024eventNewMissionAnimationFinish, value);
		}
	}

	public MissionList()
	{
		first = true;
		dispMissionCount = 3;
		newMissionAnimTime = 0.5f;
		newMissionAnimX = 1500f;
		newMissionAnimStartDelay = 1f;
		newMissionAnimItemsDelay = 0.5f;
		enablePushItemNewMissionAnimation = true;
		debugListType = ListType.None;
	}

	[SpecialName]
	protected internal void raise_eventNewMissionAnimationFinish()
	{
		_0024event_0024eventNewMissionAnimationFinish?.Invoke();
	}

	public void Awake()
	{
		debugFlag = false;
		base.HookSettingListItem = hookMissionSettingListItem;
		Transform parent = transform.parent;
		GameObject gameObject = null;
		while (null != parent)
		{
			gameObject = parent.gameObject;
			if (null != gameObject)
			{
				uimain = gameObject.GetComponent<UIMain>();
			}
			if (null != uimain)
			{
				break;
			}
			parent = parent.parent;
		}
	}

	public override void Update()
	{
		base.Update();
		if (debugFlag)
		{
			if (debugInit)
			{
				SetQuest(curQuest, debugListType);
				debugInit = false;
			}
			if (debugNewAnimation)
			{
				startNewMissionAnimationTime = 1f;
				debugNewAnimation = false;
			}
		}
		if (autoStartNewMissionAnimation && !(startNewMissionAnimationTime <= 0f))
		{
			startNewMissionAnimationTime -= Time.deltaTime;
			if (!(startNewMissionAnimationTime > 0f))
			{
				StartNewMissionAnimation();
			}
		}
	}

	private bool hookMissionSettingListItem(UIListItem item)
	{
		SetDetail((MissionListItem)item, item.GetData<MissionInfo>());
		return false;
	}

	private MissionInfo[] GetMissionInfo(RespQuestMission[] missions, RespQuestMission[] clearMissions, RespQuestMission[] newMissions, int max)
	{
		checked
		{
			object result;
			if (null == missions)
			{
				result = null;
			}
			else
			{
				MissionInfo[] array = new MissionInfo[0];
				int num = 0;
				int num2 = 0;
				int i = 0;
				for (int length = missions.Length; i < length; i++)
				{
					if (num2 >= max && max > 0)
					{
						break;
					}
					if (missions[i] == null)
					{
						continue;
					}
					num2++;
					MissionInfo missionInfo = new MissionInfo();
					missionInfo.mission = missions[i];
					if (clearMissions != null)
					{
						int j = 0;
						for (int length2 = clearMissions.Length; j < length2; j++)
						{
							if (clearMissions[j] != null && clearMissions[j].Id == missions[i].Id)
							{
								missionInfo.isClear = true;
								break;
							}
						}
					}
					if (missionInfo.isClear && newMissions != null && num < newMissions.Length)
					{
						missionInfo.newMission = newMissions[RuntimeServices.NormalizeArrayIndex(newMissions, num)];
						num++;
					}
					array = (MissionInfo[])RuntimeServices.AddArrays(typeof(MissionInfo), array, new MissionInfo[1] { missionInfo });
				}
				result = array;
			}
			return (MissionInfo[])result;
		}
	}

	private MissionInfo[] GetMissionInfo(MQuests quest, ListType listType)
	{
		RespQuestMission[] array = null;
		RespQuestMission[] array2 = null;
		RespQuestMission[] array3 = null;
		int max = dispMissionCount;
		switch (listType)
		{
		case ListType.Normal:
			array = UserData.Current.userQuestMission.getMissionsOf(quest);
			break;
		case ListType.Result:
			array = UserData.Current.userQuestMission.getMissionsOfIncludeClear(quest);
			array2 = UserData.Current.userQuestMission.getClearMissionsOf(quest);
			array3 = UserData.Current.userQuestMission.getNewMissionsOf(quest);
			if (debugFlag)
			{
				if (null == array2)
				{
					array2 = array;
				}
				else if (array2.Length == 0)
				{
					array2 = array;
				}
				if (null == array3)
				{
					array3 = array;
				}
				else if (array3.Length == 0)
				{
					array3 = array;
				}
			}
			break;
		case ListType.All:
			array = UserData.Current.userQuestMission.getMissionsOf(quest);
			max = 0;
			break;
		}
		return GetMissionInfo(array, array2, array3, max);
	}

	public bool SetQuest(MQuests quest, ListType listType)
	{
		curQuest = quest;
		int result;
		if (quest == null)
		{
			result = 0;
		}
		else
		{
			if (debugFlag && debugListType != ListType.None)
			{
				listType = debugListType;
			}
			if (listType != ListType.All && null != scrollBar)
			{
				scrollBar.gameObject.SetActive(value: false);
			}
			switch (listType)
			{
			case ListType.Normal:
				startNewMissionAnimationTime = 0f;
				break;
			case ListType.Result:
				startNewMissionAnimationTime = newMissionAnimStartDelay;
				break;
			case ListType.All:
				startNewMissionAnimationTime = 0f;
				break;
			}
			MissionInfo[] missionInfo = GetMissionInfo(quest, listType);
			if (null == missionInfo)
			{
				result = 0;
			}
			else
			{
				SetResponse(missionInfo);
				result = ((0 < missionInfo.Length) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	public void ClearAndNewItemAnimation(int i, float delay, ICallable finish)
	{
		_0024ClearAndNewItemAnimation_0024locals_002414473 _0024ClearAndNewItemAnimation_0024locals_0024 = new _0024ClearAndNewItemAnimation_0024locals_002414473();
		_0024ClearAndNewItemAnimation_0024locals_0024._0024finish = finish;
		MissionInfo data = GetData(i).GetData<MissionInfo>();
		GameObject gameObject = At(i);
		bool flag = false;
		if (data == null || null == gameObject)
		{
			if (_0024ClearAndNewItemAnimation_0024locals_0024._0024finish != null)
			{
				_0024ClearAndNewItemAnimation_0024locals_0024._0024finish.Call(new object[0]);
			}
			return;
		}
		_0024ClearAndNewItemAnimation_0024locals_0024._0024listItem = gameObject.GetComponent<MissionListItem>();
		if (null == _0024ClearAndNewItemAnimation_0024locals_0024._0024listItem)
		{
			if (_0024ClearAndNewItemAnimation_0024locals_0024._0024finish != null)
			{
				_0024ClearAndNewItemAnimation_0024locals_0024._0024finish.Call(new object[0]);
			}
			return;
		}
		if (null == _0024ClearAndNewItemAnimation_0024locals_0024._0024listItem.contentsRoot)
		{
			if (_0024ClearAndNewItemAnimation_0024locals_0024._0024finish != null)
			{
				_0024ClearAndNewItemAnimation_0024locals_0024._0024finish.Call(new object[0]);
			}
			return;
		}
		MissionListItem childMissionListItem = _0024ClearAndNewItemAnimation_0024locals_0024._0024listItem.childMissionListItem;
		if (data.isClear && !data.isAnimFinished)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(_0024ClearAndNewItemAnimation_0024locals_0024._0024listItem.contentsRoot.gameObject, newMissionAnimTime, new Vector3(0f - newMissionAnimX, 0f, 0f));
			if (null != tweenPosition)
			{
				tweenPosition.delay = delay;
				tweenPosition.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(new _0024ClearAndNewItemAnimation_0024closure_00243239(_0024ClearAndNewItemAnimation_0024locals_0024).Invoke);
				flag = true;
			}
			if (null != childMissionListItem && data.newMission != null)
			{
				childMissionListItem.gameObject.SetActive(value: true);
				TweenPosition tweenPosition2 = TweenPosition.Begin(childMissionListItem.contentsRoot.gameObject, newMissionAnimTime, Vector3.zero);
				if (null != tweenPosition2)
				{
					tweenPosition2.delay = delay;
				}
			}
		}
		if (!flag && _0024ClearAndNewItemAnimation_0024locals_0024._0024finish != null)
		{
			_0024ClearAndNewItemAnimation_0024locals_0024._0024finish.Call(new object[0]);
		}
	}

	public void StartNewMissionAnimation()
	{
		__MissionList_StartNewMissionAnimation_0024callable154_0024243_20__ _MissionList_StartNewMissionAnimation_0024callable154_0024243_20__ = (int max) => new _0024_0024StartNewMissionAnimation_0024closure_00243237_002421389(max, this).GetEnumerator();
		IEnumerator enumerator = _MissionList_StartNewMissionAnimation_0024callable154_0024243_20__(Count());
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void PushMissionItem(GameObject obj)
	{
		_0024PushMissionItem_0024locals_002414474 _0024PushMissionItem_0024locals_0024 = new _0024PushMissionItem_0024locals_002414474();
		if (EnablePushItemNewMissionAnimation)
		{
			_0024PushMissionItem_0024locals_0024._0024index = GetItemIndex(obj);
			if (0 <= _0024PushMissionItem_0024locals_0024._0024index)
			{
				ClearAndNewItemAnimation(_0024PushMissionItem_0024locals_0024._0024index, newMissionAnimItemsDelay, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PushMissionItem_0024closure_00243240(_0024PushMissionItem_0024locals_0024, this).Invoke));
			}
		}
	}

	public void SetResponse(MissionInfo[] missions)
	{
		if (!(null == missions))
		{
			Reset();
			Initialize(missions, gameObject, autoTween: true);
		}
	}

	public void SetDetail(MissionListItem target, MissionInfo missionInfo)
	{
		if (!(null != target))
		{
			throw new AssertionFailedException("null != target");
		}
		if (missionInfo == null)
		{
			throw new AssertionFailedException("null != missionInfo");
		}
		RespQuestMission mission = missionInfo.mission;
		if (mission == null)
		{
			throw new AssertionFailedException("null != mission");
		}
		SetDetail(target, mission);
		SetNewMission(target, missionInfo);
	}

	public void SetNewMission(MissionListItem target, MissionInfo missionInfo)
	{
		if (!(null != target))
		{
			throw new AssertionFailedException("null != target");
		}
		if (missionInfo == null)
		{
			throw new AssertionFailedException("null != missionInfo");
		}
		target.isClear = missionInfo.isClear;
		if (!target.isClear)
		{
			return;
		}
		if (null != target.clearIcon)
		{
			target.clearIcon.SetActive(value: true);
		}
		GameObject gameObject = null;
		if (missionInfo.newMission == null)
		{
			return;
		}
		gameObject = (GameObject)UnityEngine.Object.Instantiate(target.gameObject);
		if (!(null != gameObject))
		{
			return;
		}
		gameObject.transform.parent = target.transform;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(value: false);
		MissionListItem component = gameObject.GetComponent<MissionListItem>();
		if (null != component)
		{
			SetDetail(component, missionInfo.newMission);
			component.contentsRoot.transform.localPosition = new Vector3(newMissionAnimX, 0f, 0f);
			if (null != component.newIcon)
			{
				component.newIcon.SetActive(value: true);
			}
			target.childMissionListItem = component;
		}
	}

	public void SetDetail(MissionListItem target, RespQuestMission mission)
	{
		if (!(null != target))
		{
			throw new AssertionFailedException("null != target");
		}
		if (mission == null)
		{
			throw new AssertionFailedException("null != mission");
		}
		if (!(null != uimain))
		{
			throw new AssertionFailedException("null != uimain");
		}
		target.mission = mission;
		if (null != target.textDetailLabel)
		{
			target.textDetailLabel.text = mission.Detail;
		}
		if (null != target.mapetBGObject)
		{
			target.mapetBGObject.SetActive(value: false);
		}
		if (null != target.weaponBGObject)
		{
			target.weaponBGObject.SetActive(value: false);
		}
		if (null != target.commonIconObject)
		{
			target.commonIconObject.SetActive(value: false);
		}
		if (null != target.newIcon)
		{
			target.newIcon.SetActive(value: false);
		}
		if (null != target.clearIcon)
		{
			target.clearIcon.SetActive(value: false);
		}
		UIButtonMessage component = target.GetComponent<UIButtonMessage>();
		if (null != component)
		{
			component.target = this.gameObject;
			component.functionName = "PushMissionItem";
		}
		RespReward[] rewards = mission.Rewards;
		if (null == rewards)
		{
			if (null != target.textNumLabel)
			{
				target.textNumLabel.text = string.Empty;
			}
			if (null != target.numPanel)
			{
				target.numPanel.SetActive(value: false);
			}
			return;
		}
		if (rewards == null)
		{
			throw new AssertionFailedException("null != rewards");
		}
		if (1 != rewards.Length)
		{
			throw new AssertionFailedException("1 == rewards.Length");
		}
		RespReward respReward = rewards[0];
		int masterTypeValue = respReward.MasterTypeValue;
		MMasterTypeValues mMasterTypeValues = MMasterTypeValues.Get(masterTypeValue);
		int itemId = respReward.ItemId;
		int level = respReward.Level;
		int quantity = respReward.Quantity;
		if (null != target.textNumLabel)
		{
			target.textNumLabel.text = UIBasicUtility.SafeFormat("*{0}", quantity);
		}
		if (null != target.numPanel)
		{
			target.numPanel.SetActive(quantity > 0);
		}
		if (masterTypeValue == 0)
		{
			throw new AssertionFailedException("masterTypeValue != EnumMasterTypeValues.None");
		}
		UserData current = UserData.Current;
		switch (masterTypeValue)
		{
		case 3:
		{
			if (!(null != target.weaponBGObject))
			{
				break;
			}
			target.weaponBGObject.SetActive(value: true);
			GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(weaponIconPrefab);
			gameObject3.transform.parent = target.weaponBGObject.transform;
			gameObject3.transform.localScale = Vector3.one;
			gameObject3.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespWeapon respWeapon = new RespWeapon(itemId);
			respWeapon.Level = level;
			respWeapon.TraitId = respReward.TraitId;
			respWeapon.AttackBonus = respReward.AttackPlusBonus;
			respWeapon.HpBonus = respReward.HpPlusBonus;
			if (null != target.textRewardLabel)
			{
				target.textRewardLabel.text = new StringBuilder().Append(respWeapon.Master.Name).Append(" Lv ").Append((object)level)
					.ToString();
			}
			current.userMiscInfo.weaponBookData.look(respWeapon.Master);
			WeaponListItem component5 = gameObject3.GetComponent<WeaponListItem>();
			if (null != component5)
			{
				GameObject gameObject2 = component5.SetWeapon(respWeapon) as GameObject;
				if (null != gameObject2)
				{
					WeaponInfo component6 = gameObject2.GetComponent<WeaponInfo>();
					if (null != component6)
					{
						component6.DestroyPlus();
						component6.DestroyLevel();
					}
				}
			}
			component = gameObject3.GetComponent<UIButtonMessage>();
			component.target = uimain.gameObject;
			component.functionName = "PushDetail";
			component.waitTime = 0.8f;
			break;
		}
		case 4:
		{
			if (!(null != target.mapetBGObject))
			{
				break;
			}
			target.mapetBGObject.SetActive(value: true);
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(mapetIconPrefab);
			gameObject.transform.parent = target.mapetBGObject.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespPoppet respPoppet = new RespPoppet(itemId);
			respPoppet.Level = level;
			respPoppet.TraitId = respReward.TraitId;
			respPoppet.AttackBonus = respReward.AttackPlusBonus;
			respPoppet.HpBonus = respReward.HpPlusBonus;
			if (null != target.textRewardLabel)
			{
				target.textRewardLabel.text = new StringBuilder().Append(respPoppet.Master.Name).Append(" Lv ").Append((object)level)
					.ToString();
			}
			current.userMiscInfo.poppetBookData.look(respPoppet.Master);
			MapetListItem component3 = gameObject.GetComponent<MapetListItem>();
			if (null != component3)
			{
				GameObject gameObject2 = component3.SetMapet(respPoppet) as GameObject;
				if (null != gameObject2)
				{
					MuppetInfo component4 = gameObject2.GetComponent<MuppetInfo>();
					if (null != component4)
					{
						component4.DestroyPlus();
						component4.DestroyLevel();
					}
				}
			}
			component = gameObject.GetComponent<UIButtonMessage>();
			component.target = uimain.gameObject;
			component.functionName = "PushDetail";
			component.waitTime = 0.8f;
			break;
		}
		default:
			if (mMasterTypeValues == null)
			{
				break;
			}
			if (null != target.commonIconObject)
			{
				UISprite component2 = target.commonIconObject.GetComponent<UISprite>();
				if (null != component2)
				{
					component2.spriteName = mMasterTypeValues.Icon;
				}
				target.commonIconObject.SetActive(value: true);
			}
			if (null != target.textRewardLabel)
			{
				target.textRewardLabel.text = UIBasicUtility.SafeFormat(new StringBuilder().Append(mMasterTypeValues.Name_DisplayFormat).ToString(), quantity);
			}
			break;
		case 0:
			break;
		}
		NGUITools.DestroyAllSameComponent<UIPanel>(target.gameObject);
	}

	private new void PushSelectItem(GameObject obj)
	{
	}

	internal IEnumerator _0024StartNewMissionAnimation_0024closure_00243237(int max)
	{
		return new _0024_0024StartNewMissionAnimation_0024closure_00243237_002421389(max, this).GetEnumerator();
	}
}
