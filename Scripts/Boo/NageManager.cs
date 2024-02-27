using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class NageManager : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024nageRoutine_002416814 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024atkBone_002416815;

			internal Renderer[] _0024dfcRndrs_002416816;

			internal Transform _0024tcog_002416817;

			internal Transform _0024dfct_002416818;

			internal float _0024elapsed_002416819;

			internal bool _0024hidden_002416820;

			internal bool _0024atkNotPlayed_002416821;

			internal bool _0024damaged_002416822;

			internal Transform _0024baseBone_002416823;

			internal Vector3 _0024yangdir_002416824;

			internal float _0024yang_002416825;

			internal Vector3 _0024gndPos_002416826;

			internal NageInfo _0024ninfo_002416827;

			internal MerlinActionControl _0024atk_002416828;

			internal MerlinActionControl _0024dfc_002416829;

			internal float _0024damage_002416830;

			internal NageManager _0024self__002416831;

			public _0024(NageInfo ninfo, MerlinActionControl atk, MerlinActionControl dfc, float damage, NageManager self_)
			{
				_0024ninfo_002416827 = ninfo;
				_0024atk_002416828 = atk;
				_0024dfc_002416829 = dfc;
				_0024damage_002416830 = damage;
				_0024self__002416831 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002416831.currentActors.Contains(_0024atk_002416828) || _0024self__002416831.currentActors.Contains(_0024dfc_002416829))
						{
							goto case 1;
						}
						_0024self__002416831.currentActors.Add(_0024atk_002416828);
						_0024self__002416831.currentActors.Add(_0024dfc_002416829);
						_0024atk_002416828.disableInput();
						_0024dfc_002416829.disableInput();
						_0024atkBone_002416815 = ExtensionsModule.FindInDescendants(_0024atk_002416828.transform, _0024ninfo_002416827.nageBone);
						if (!(_0024atkBone_002416815 != null))
						{
							throw new AssertionFailedException(new StringBuilder("'").Append(_0024ninfo_002416827.nageBone).Append("'という名前の骨が").Append(_0024atk_002416828.gameObject)
								.Append("に無い")
								.ToString());
						}
						_0024atk_002416828.disposeCommands(typeof(ActionCommandTargetting));
						_0024dfcRndrs_002416816 = Gen_array_macrosModule.GenArray<Renderer, Renderer>(_0024dfc_002416829.gameObject.GetComponentsInChildren<Renderer>(), (__NageManager_0024callable327_002439_15__)((Renderer _0024genarray_00241248) => _0024genarray_00241248), (__NageManager_0024callable328_002439_15__)((Renderer _0024genarray_00241248) => _0024genarray_00241248.enabled));
						_0024dfc_002416829.disableAllMovementTypes();
						_0024dfc_002416829.setBodyLayerNoPushOut();
						_0024dfc_002416829.playAnimation(_0024ninfo_002416827.yarareMot);
						_0024dfc_002416829.Mmpc.TimeScale = 1f;
						_0024tcog_002416817 = ExtensionsModule.FindInDescendants(_0024dfc_002416829.transform, "cog");
						if (_0024tcog_002416817 == null)
						{
							_0024tcog_002416817 = _0024dfc_002416829.transform;
						}
						_0024dfct_002416818 = _0024dfc_002416829.transform;
						_0024elapsed_002416819 = 0f;
						_0024hidden_002416820 = false;
						_0024atkNotPlayed_002416821 = true;
						_0024damaged_002416822 = false;
						goto case 2;
					case 2:
						if (_0024elapsed_002416819 < _0024ninfo_002416827.endTime && !(_0024atk_002416828 == null) && !(_0024dfc_002416829 == null))
						{
							_0024elapsed_002416819 += Time.deltaTime;
							if (_0024ninfo_002416827.attackMot.IsValid && !(_0024elapsed_002416819 < _0024ninfo_002416827.attackMotStart) && _0024atkNotPlayed_002416821)
							{
								_0024atk_002416828.playAnimation(_0024ninfo_002416827.attackMot);
								_0024atkNotPlayed_002416821 = false;
							}
							_0024self__002416831.alignDefencer(_0024dfct_002416818, _0024tcog_002416817, _0024atkBone_002416815.position, _0024atkBone_002416815.rotation, _0024ninfo_002416827.yarareLocalPos, _0024ninfo_002416827.yarareLocalRot, setRotation: true);
							if (!_0024damaged_002416822 && !(_0024ninfo_002416827.damageTime > _0024elapsed_002416819))
							{
								_0024damaged_002416822 = true;
								_0024dfc_002416829.HitAttack((int)_0024damage_002416830, YarareTypes.None, _0024atk_002416828.gameObject);
								if (_0024dfc_002416829 is PlayerControl)
								{
									DamageDisplay.DamagePlayerSide(_0024dfc_002416829.transform.position, (int)_0024damage_002416830);
								}
							}
							if (!(_0024elapsed_002416819 < _0024ninfo_002416827.yarareStopTime))
							{
								_0024dfc_002416829.Mmpc.TimeScale = 0f;
							}
							if (_0024ninfo_002416827.NeedHideAndShow)
							{
								_0024self__002416831.hideAndShow(_0024dfcRndrs_002416816, _0024elapsed_002416819, _0024ninfo_002416827.hideTime, _0024ninfo_002416827.showTime);
								_0024hidden_002416820 = true;
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024dfc_002416829 != null && _0024hidden_002416820)
						{
							_0024self__002416831.show(_0024dfcRndrs_002416816, b: true);
						}
						if (_0024dfc_002416829 != null)
						{
							_0024self__002416831.alignDefencer(_0024dfct_002416818, _0024tcog_002416817, _0024tcog_002416817.position, _0024tcog_002416817.rotation, _0024ninfo_002416827.yarareLocalPos, _0024ninfo_002416827.yarareLocalRot, setRotation: false);
						}
						if (_0024dfc_002416829 != null)
						{
							_0024dfc_002416829.setBodyStartLayer();
							_0024baseBone_002416823 = _0024dfc_002416829.Mmpc.CurrentBaseBone;
							if (_0024baseBone_002416823 == null)
							{
								_0024baseBone_002416823 = _0024dfct_002416818;
							}
							_0024yangdir_002416824 = new Vector3(_0024baseBone_002416823.forward.x, 0f, _0024baseBone_002416823.forward.z);
							_0024yang_002416825 = Mathf.Atan2(_0024yangdir_002416824.x, _0024yangdir_002416824.z) * 57.29578f;
							_0024dfct_002416818.rotation = Quaternion.Euler(0f, _0024yang_002416825, 0f);
							_0024dfc_002416829.enableAllMovementTypes();
							if (_0024ninfo_002416827.yarareResultMot.IsValid)
							{
								_0024dfc_002416829.playAnimation(_0024ninfo_002416827.yarareResultMot);
								_0024dfc_002416829.Mmpc.setPlayTime(_0024ninfo_002416827.yarareResultMotStartTime);
							}
							_0024dfc_002416829.Mmpc.TimeScale = 1f;
							if (!(_0024ninfo_002416827.knockBackPow <= 0f))
							{
								_0024dfc_002416829.KnockBack = _0024yangdir_002416824 * (0f - _0024ninfo_002416827.knockBackPow);
							}
							_0024dfc_002416829.disableGravity();
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						goto IL_064c;
					case 3:
						_0024dfc_002416829.enableGravity();
						_0024gndPos_002416826 = BattleUtil.AdjustYpos(_0024dfct_002416818.position, 0f) + new Vector3(0f, 1.5f, 0f);
						if (!(_0024gndPos_002416826.y <= _0024dfct_002416818.position.y))
						{
							_0024dfct_002416818.position = _0024gndPos_002416826;
						}
						goto IL_064c;
					case 1:
						{
							result = 0;
							break;
						}
						IL_064c:
						if (_0024atk_002416828 != null)
						{
							_0024atk_002416828.enableInput();
						}
						if (_0024dfc_002416829 != null)
						{
							_0024dfc_002416829.enableInput();
						}
						_0024self__002416831.currentActors.Remove(_0024atk_002416828);
						_0024self__002416831.currentActors.Remove(_0024dfc_002416829);
						_0024self__002416831.currentPlaying.Remove(_0024ninfo_002416827);
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal NageInfo _0024ninfo_002416832;

		internal MerlinActionControl _0024atk_002416833;

		internal MerlinActionControl _0024dfc_002416834;

		internal float _0024damage_002416835;

		internal NageManager _0024self__002416836;

		public _0024nageRoutine_002416814(NageInfo ninfo, MerlinActionControl atk, MerlinActionControl dfc, float damage, NageManager self_)
		{
			_0024ninfo_002416832 = ninfo;
			_0024atk_002416833 = atk;
			_0024dfc_002416834 = dfc;
			_0024damage_002416835 = damage;
			_0024self__002416836 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024ninfo_002416832, _0024atk_002416833, _0024dfc_002416834, _0024damage_002416835, _0024self__002416836);
		}
	}

	[NonSerialized]
	private static NageManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	private HashSet<NageInfo> currentPlaying;

	private HashSet<MerlinActionControl> currentActors;

	public GameObject nage;

	public GameObject yarare;

	public GameObject nageBone;

	private Quaternion nageInitRot;

	private Quaternion yarareInitRot;

	private AIControl aiControl;

	private PlayerControl playerControl;

	public static NageManager Instance
	{
		get
		{
			NageManager _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((NageManager)UnityEngine.Object.FindObjectOfType(typeof(NageManager))) as NageManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static NageManager CurrentInstance => __instance;

	public NageManager()
	{
		currentPlaying = new HashSet<NageInfo>();
		currentActors = new HashSet<MerlinActionControl>();
	}

	public void _0024singleton_0024awake_00241246()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241246();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static NageManager _createInstance()
	{
		string text = "__" + "NageManager" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		NageManager nageManager = ExtensionsModule.SetComponent<NageManager>(gameObject);
		if ((bool)nageManager)
		{
			nageManager._createInstance_callback();
		}
		return nageManager;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241247()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241247();
		quitApp = true;
	}

	public void start(NageInfo nageInfo, MerlinActionControl atk, MerlinActionControl dfc, float damage)
	{
		if (!(atk == null) && !(dfc == null) && nageInfo.IsValid && !currentPlaying.Contains(nageInfo))
		{
			currentPlaying.Add(nageInfo);
			StartCoroutine(nageRoutine(nageInfo, atk, dfc, damage));
		}
	}

	public bool isEntried(MerlinActionControl act)
	{
		bool num = act != null;
		if (num)
		{
			num = currentActors.Contains(act);
		}
		return num;
	}

	private IEnumerator nageRoutine(NageInfo ninfo, MerlinActionControl atk, MerlinActionControl dfc, float damage)
	{
		return new _0024nageRoutine_002416814(ninfo, atk, dfc, damage, this).GetEnumerator();
	}

	private void alignDefencer(Transform dfc, Transform tcog, Vector3 attachPosition, Quaternion attachRotation, Vector3 attachLocalPos, Quaternion attachLocalRot, bool setRotation)
	{
		Vector3 vector = tcog.position - dfc.position;
		Quaternion rotation = dfc.rotation;
		Quaternion rotation2 = tcog.rotation;
		Quaternion quaternion = Quaternion.Inverse(rotation2) * rotation;
		Vector3 vector2 = Quaternion.Inverse(rotation) * vector;
		Quaternion quaternion2 = attachRotation * attachLocalRot;
		dfc.position = quaternion2 * -vector2 + attachPosition + attachRotation * attachLocalPos;
		if (setRotation)
		{
			dfc.rotation = quaternion2 * quaternion;
		}
	}

	private void hideAndShow(Renderer[] rs, float tm, float start, float end)
	{
		bool num = !(start > tm);
		if (num)
		{
			num = tm < end;
		}
		show(rs, !num);
	}

	private void show(Renderer[] rs, bool b)
	{
		int i = 0;
		for (int length = rs.Length; i < length; i = checked(i + 1))
		{
			if (rs[i] != null)
			{
				rs[i].enabled = b;
			}
		}
	}

	internal Renderer _0024nageRoutine_0024closure_00243003(Renderer _0024genarray_00241248)
	{
		return _0024genarray_00241248;
	}

	internal bool _0024nageRoutine_0024closure_00243004(Renderer _0024genarray_00241248)
	{
		return _0024genarray_00241248.enabled;
	}
}
