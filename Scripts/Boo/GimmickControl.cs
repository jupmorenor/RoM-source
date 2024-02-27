using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class GimmickControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024workRoutine_002418427 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pc_002418428;

			internal GameObject _0024player_002418429;

			internal GimmickIconSystem _0024gis_002418430;

			internal GimmickIcon _0024raceIcon_002418431;

			internal bool _0024sameRace_002418432;

			internal GimmickIconTypes _0024iconType_002418433;

			internal GimmickIcon _0024icon_002418434;

			internal GimmickControl _0024self__002418435;

			public _0024(GimmickControl self_)
			{
				_0024self__002418435 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!PlayerControl.CurrentPlayer)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pc_002418428 = PlayerControl.CurrentPlayer;
					_0024player_002418429 = _0024pc_002418428.gameObject;
					goto case 3;
				case 3:
					if (!_0024self__002418435.fukidashiEnables)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024gis_002418430 = GimmickIconSystem.Instance;
					if ((bool)_0024gis_002418430)
					{
						_0024raceIcon_002418431 = _0024gis_002418430.getIcon(_0024self__002418435.iconAttachObj);
						goto case 4;
					}
					goto IL_0211;
				case 4:
					if (_0024self__002418435.isInMyTerritory(_0024player_002418429))
					{
						_0024sameRace_002418432 = false;
						if (_0024pc_002418428.IsTensi && _0024self__002418435.reactionRace == RACE_TYPE.Tensi)
						{
							_0024sameRace_002418432 = true;
						}
						else if (!_0024pc_002418428.IsTensi && _0024self__002418435.reactionRace == RACE_TYPE.Akuma)
						{
							_0024sameRace_002418432 = true;
						}
						if (_0024sameRace_002418432)
						{
							_0024iconType_002418433 = GimmickIconTypes.ANGEL;
							if (_0024self__002418435.reactionRace == RACE_TYPE.Tensi)
							{
								_0024iconType_002418433 = GimmickIconTypes.ANGEL;
							}
							else if (_0024self__002418435.reactionRace == RACE_TYPE.Tensi)
							{
								_0024iconType_002418433 = GimmickIconTypes.DEVIL;
							}
							_0024icon_002418434 = _0024gis_002418430.show(_0024self__002418435.iconAttachObj, _0024iconType_002418433);
							if (_0024icon_002418434.TouchIcon)
							{
								_0024gis_002418430.hide(_0024self__002418435.iconAttachObj);
								_0024self__002418435.fukidashiTouches = true;
								goto IL_0211;
							}
						}
						else
						{
							_0024gis_002418430.hide(_0024self__002418435.iconAttachObj);
						}
					}
					else
					{
						_0024gis_002418430.hide(_0024self__002418435.iconAttachObj);
					}
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0211:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GimmickControl _0024self__002418436;

		public _0024workRoutine_002418427(GimmickControl self_)
		{
			_0024self__002418436 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418436);
		}
	}

	public RACE_TYPE reactionRace;

	public GameObject iconAttachObj;

	public float reactionLength;

	public GameObject wakeupFuncTarget;

	public string wakeupFunction;

	public GameObject startFuncTarget;

	public string startFunction;

	public GameObject[] wakeupEnableObjects;

	public GameObject[] wakeupDisableObjects;

	public AnimationClip wakeupAnimation;

	public MFlags flag;

	protected float gimmickSpeed;

	protected float gimmickTime;

	protected int conditionNumber;

	protected bool enableWorkRoutine;

	protected bool startRoutine;

	[NonSerialized]
	public const string RACE_TENSI_SPRITE_NAME = "icon_light";

	[NonSerialized]
	public const string RACE_AKUMA_SPRITE_NAME = "icon_dark";

	private bool fukidashiEnables;

	private bool fukidashiTouches;

	public bool wakeUpFlag;

	protected AnimationEventHandler animEventHandler;

	public MFlags Flag
	{
		get
		{
			return flag;
		}
		set
		{
			flag = value;
			if (UserData.Current != null)
			{
				conditionNumber = UserData.Current.userMiscInfo.flagData.ConditionNumber;
			}
			if (flag != null && GameLevelManager.CheckCondition(new MFlags[1] { flag }, notFlag: false))
			{
				wakeUp(gimmickSpeed, 1f);
			}
		}
	}

	public float GimmickSpeed
	{
		get
		{
			return gimmickSpeed;
		}
		set
		{
			gimmickSpeed = value;
		}
	}

	public float GimmickTime
	{
		get
		{
			return gimmickTime;
		}
		set
		{
			gimmickTime = value;
		}
	}

	public bool EnableWorkRoutine
	{
		get
		{
			return enableWorkRoutine;
		}
		set
		{
			enableWorkRoutine = value;
		}
	}

	public bool FukidashiEnables
	{
		get
		{
			return fukidashiEnables;
		}
		set
		{
			fukidashiEnables = value;
		}
	}

	public bool FukidashiTouches => fukidashiTouches;

	public bool WakeUpFlag => wakeUpFlag;

	public GimmickControl()
	{
		reactionLength = 12f;
		gimmickSpeed = 1f;
	}

	public void ResetWakeup()
	{
		wakeUpFlag = false;
	}

	public void Awake()
	{
		animEventHandler = GetComponent<AnimationEventHandler>();
		if ((bool)startFuncTarget)
		{
			startFuncTarget.SendMessage(startFunction);
		}
		if (flag != null && GameLevelManager.CheckCondition(new MFlags[1] { flag }, notFlag: false))
		{
			wakeUp(gimmickSpeed, 1f);
		}
		else if ((bool)animation)
		{
			animation.Play();
			IEnumerator enumerator = animation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				animationState.speed = 0f;
			}
		}
		if (UserData.Current != null)
		{
			conditionNumber = UserData.Current.userMiscInfo.flagData.ConditionNumber;
		}
	}

	public void Update()
	{
		if (!wakeUpFlag)
		{
			if ((bool)animEventHandler && animEventHandler.Hidden)
			{
				animEventHandler.AnimationInitializeEventHandler();
			}
			if ((bool)animation)
			{
				IEnumerator enumerator = animation.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is AnimationState))
					{
						obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
					}
					AnimationState animationState = (AnimationState)obj;
					animationState.speed = 0f;
				}
			}
		}
		if (enableWorkRoutine && !startRoutine)
		{
			StartCoroutine(workRoutine());
			startRoutine = true;
		}
		if (UserData.Current != null && UserData.Current.userMiscInfo.flagData.ConditionNumber != conditionNumber)
		{
			conditionNumber = UserData.Current.userMiscInfo.flagData.ConditionNumber;
			if (flag != null && GameLevelManager.CheckCondition(new MFlags[1] { flag }, notFlag: false))
			{
				wakeUp(gimmickSpeed, gimmickTime);
			}
		}
	}

	private IEnumerator workRoutine()
	{
		return new _0024workRoutine_002418427(this).GetEnumerator();
	}

	public bool isInMyTerritory(Component p)
	{
		return !(p == null) && isInMyTerritory(p.gameObject);
	}

	public bool isInMyTerritory(GameObject p)
	{
		return !(p == null) && !((p.transform.position - transform.position).magnitude > reactionLength);
	}

	public void wakeUp(float speed, float time)
	{
		if (wakeUpFlag)
		{
			return;
		}
		wakeUpFlag = true;
		if ((bool)wakeupFuncTarget)
		{
			wakeupFuncTarget.SendMessage(wakeupFunction);
		}
		checked
		{
			if (wakeupEnableObjects != null)
			{
				int i = 0;
				GameObject[] array = wakeupEnableObjects;
				for (int length = array.Length; i < length; i++)
				{
					if (!(array[i] == null))
					{
						array[i].SetActive(value: true);
					}
				}
			}
			if (wakeupDisableObjects != null)
			{
				int j = 0;
				GameObject[] array2 = wakeupDisableObjects;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if (!(array2[j] == null))
					{
						array2[j].SetActive(value: false);
					}
				}
			}
			if (!animation)
			{
				return;
			}
			if ((bool)wakeupAnimation)
			{
				animation.Play(wakeupAnimation.name);
			}
			else
			{
				animation.Play();
			}
			IEnumerator enumerator = animation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				animationState.speed = speed;
				animationState.time = animationState.length * time;
			}
		}
	}
}
