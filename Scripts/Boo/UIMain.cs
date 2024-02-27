using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class UIMain : MonoBehaviour
{
	[Serializable]
	internal class _0024ChangeSituation_0024locals_002414548
	{
		internal bool _0024wait_currSituation;
	}

	[Serializable]
	internal class _0024ChangeSituation_0024DoChangeSituation_00242973
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422051 : GenericGenerator<Coroutine>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
			{
				internal UIButtonMessage _0024btn_002422052;

				internal UIButtonMessage _0024btn_002422053;

				internal int _0024_002411770_002422054;

				internal UIButtonMessage[] _0024_002411771_002422055;

				internal int _0024_002411772_002422056;

				internal int _0024_002411774_002422057;

				internal UIButtonMessage[] _0024_002411775_002422058;

				internal int _0024_002411776_002422059;

				internal UISituation _0024situation_002422060;

				internal _0024ChangeSituation_0024DoChangeSituation_00242973 _0024self__002422061;

				public _0024(UISituation situation, _0024ChangeSituation_0024DoChangeSituation_00242973 self_)
				{
					_0024situation_002422060 = situation;
					_0024self__002422061 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							if (_0024self__002422061._0024this_002415220.buttonMssages != null)
							{
								_0024_002411770_002422054 = 0;
								_0024_002411771_002422055 = _0024self__002422061._0024this_002415220.buttonMssages;
								for (_0024_002411772_002422056 = _0024_002411771_002422055.Length; _0024_002411770_002422054 < _0024_002411772_002422056; _0024_002411770_002422054++)
								{
									if ((bool)_0024_002411771_002422055[_0024_002411770_002422054])
									{
										_0024_002411771_002422055[_0024_002411770_002422054].sendMessage = false;
									}
								}
							}
							_0024self__002422061._0024this_002415220.isChangingSituation = true;
							_0024self__002422061._0024this_002415220.OnModalCollider();
							if ((bool)_0024self__002422061._0024this_002415220.currSituation)
							{
								if (_0024self__002422061._0024_0024locals_002415221._0024wait_currSituation)
								{
									result = (Yield(2, _0024self__002422061._0024this_002415220.StartCoroutine(_0024self__002422061._0024this_002415220.EndSituation(_0024self__002422061._0024this_002415220.currSituation))) ? 1 : 0);
									break;
								}
								_0024self__002422061._0024this_002415220.StartCoroutine(_0024self__002422061._0024this_002415220.EndSituation(_0024self__002422061._0024this_002415220.currSituation));
							}
							goto case 2;
						case 2:
							result = (Yield(3, _0024self__002422061._0024this_002415220.StartCoroutine(_0024self__002422061._0024this_002415220.StartSituation(_0024situation_002422060))) ? 1 : 0);
							break;
						case 3:
							_0024self__002422061._0024this_002415220.OffModalCollider(_0024self__002422061._0024this_002415220.IsLoading);
							if (_0024self__002422061._0024this_002415220.buttonMssages != null)
							{
								_0024_002411774_002422057 = 0;
								_0024_002411775_002422058 = _0024self__002422061._0024this_002415220.buttonMssages;
								for (_0024_002411776_002422059 = _0024_002411775_002422058.Length; _0024_002411774_002422057 < _0024_002411776_002422059; _0024_002411774_002422057++)
								{
									if ((bool)_0024_002411775_002422058[_0024_002411774_002422057])
									{
										_0024_002411775_002422058[_0024_002411774_002422057].sendMessage = true;
									}
								}
							}
							_0024self__002422061._0024this_002415220.buttonMssages = null;
							_0024self__002422061._0024this_002415220.isChangingSituation = false;
							result = (YieldDefault(4) ? 1 : 0);
							break;
						case 4:
							_0024self__002422061._0024this_002415220.SetupAllNullButton();
							YieldDefault(1);
							goto case 1;
						case 1:
							result = 0;
							break;
						}
					}
					return (byte)result != 0;
				}
			}

			internal UISituation _0024situation_002422062;

			internal _0024ChangeSituation_0024DoChangeSituation_00242973 _0024self__002422063;

			public _0024Invoke_002422051(UISituation situation, _0024ChangeSituation_0024DoChangeSituation_00242973 self_)
			{
				_0024situation_002422062 = situation;
				_0024self__002422063 = self_;
			}

			public override IEnumerator<Coroutine> GetEnumerator()
			{
				return new _0024(_0024situation_002422062, _0024self__002422063);
			}
		}

		internal UIMain _0024this_002415220;

		internal _0024ChangeSituation_0024locals_002414548 _0024_0024locals_002415221;

		public _0024ChangeSituation_0024DoChangeSituation_00242973(UIMain _0024this_002415220, _0024ChangeSituation_0024locals_002414548 _0024_0024locals_002415221)
		{
			this._0024this_002415220 = _0024this_002415220;
			this._0024_0024locals_002415221 = _0024_0024locals_002415221;
		}

		public IEnumerator Invoke(UISituation situation)
		{
			return new _0024Invoke_002422051(situation, this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartSituation_002422026 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242654_002422027;

			internal UISituation _0024situation_002422028;

			internal UIMain _0024self__002422029;

			public _0024(UISituation situation, UIMain self_)
			{
				_0024situation_002422028 = situation;
				_0024self__002422029 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024situation_002422028)
					{
						if (!string.IsNullOrEmpty(_0024situation_002422028.help))
						{
							InfomationBarHUD.UpdateText(_0024situation_002422028.help);
						}
						_0024self__002422029.SwitchBg(_0024situation_002422028);
						_0024_0024sco_0024temp_00242654_002422027 = _0024self__002422029.play_animation(_0024situation_002422028, forward: true);
						if (_0024_0024sco_0024temp_00242654_002422027 != null)
						{
							result = (Yield(2, _0024self__002422029.StartCoroutine(_0024_0024sco_0024temp_00242654_002422027)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
					_0024self__002422029.currSituation = _0024situation_002422028;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UISituation _0024situation_002422030;

		internal UIMain _0024self__002422031;

		public _0024StartSituation_002422026(UISituation situation, UIMain self_)
		{
			_0024situation_002422030 = situation;
			_0024self__002422031 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024situation_002422030, _0024self__002422031);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024EndSituation_002422032 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242655_002422033;

			internal UISituation _0024situation_002422034;

			internal UIMain _0024self__002422035;

			public _0024(UISituation situation, UIMain self_)
			{
				_0024situation_002422034 = situation;
				_0024self__002422035 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00242655_002422033 = _0024self__002422035.play_animation(_0024situation_002422034, forward: false);
					if (_0024_0024sco_0024temp_00242655_002422033 != null)
					{
						result = (Yield(2, _0024self__002422035.StartCoroutine(_0024_0024sco_0024temp_00242655_002422033)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UISituation _0024situation_002422036;

		internal UIMain _0024self__002422037;

		public _0024EndSituation_002422032(UISituation situation, UIMain self_)
		{
			_0024situation_002422036 = situation;
			_0024self__002422037 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024situation_002422036, _0024self__002422037);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024play_animation_002422038 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UISituation _0024situation_002422039;

			internal bool _0024forward_002422040;

			public _0024(UISituation situation, bool forward)
			{
				_0024situation_002422039 = situation;
				_0024forward_002422040 = forward;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024situation_002422039 != null)
					{
						_0024situation_002422039.PlayAnimation(_0024forward_002422040);
					}
					goto case 2;
				case 2:
					if (_0024situation_002422039 != null && _0024situation_002422039.isPlayingAnimation)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal UISituation _0024situation_002422041;

		internal bool _0024forward_002422042;

		public _0024play_animation_002422038(UISituation situation, bool forward)
		{
			_0024situation_002422041 = situation;
			_0024forward_002422042 = forward;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024situation_002422041, _0024forward_002422042);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024LoadingUpdate_0024doLoading_00242796_002422043 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal UIMain _0024self__002422044;

			public _0024(UIMain self_)
			{
				_0024self__002422044 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, _0024self__002422044.StartCoroutine(_0024self__002422044.Loading())) ? 1 : 0);
					break;
				case 2:
					_0024self__002422044.EndLoading();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UIMain _0024self__002422045;

		public _0024_0024LoadingUpdate_0024doLoading_00242796_002422043(UIMain self_)
		{
			_0024self__002422045 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422045);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024LoadingUpdate_0024update_00242797_002422046 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024count_002422047;

			internal string _0024str_002422048;

			internal UIMain _0024self__002422049;

			public _0024(UIMain self_)
			{
				_0024self__002422049 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002422049.loadingLabel)
					{
						_0024count_002422047 = 0;
						_0024str_002422048 = null;
						_0024self__002422049.loadingLabel.gameObject.SetActive(value: true);
						goto case 2;
					}
					goto case 1;
				case 2:
					if (_0024self__002422049.isLoading)
					{
						if (_0024count_002422047 % 200 == 0)
						{
							_0024str_002422048 = "Now Loading";
						}
						if (_0024count_002422047 % 40 == 0)
						{
							_0024str_002422048 += ".";
						}
						checked
						{
							_0024count_002422047++;
							_0024self__002422049.loadingLabel.text = _0024str_002422048;
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
					}
					_0024self__002422049.loadingLabel.gameObject.SetActive(value: false);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UIMain _0024self__002422050;

		public _0024_0024LoadingUpdate_0024update_00242797_002422046(UIMain self_)
		{
			_0024self__002422050 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002422050);
		}
	}

	public string title;

	public bool ignoreTimeScale;

	public string startSituation;

	public UISituation[] situations;

	private IDictionary<string, UISituation> situationDict;

	private UISituation currSituation;

	private bool isChangingSituation;

	private GameObject modalCol;

	private bool modalColliderActive;

	protected MerlinServer server;

	public GameObject baseBg;

	private GameObject nowBg;

	protected UIHUDLayer hudLayer;

	private SQEX_SoundPlayer soundManager;

	private readonly float soundDelay;

	private readonly float soundFadeIn;

	private readonly float soundFadeOut;

	private UIButtonMessage[] buttonMssages;

	public UILabelBase loadingLabel;

	private bool isLoading;

	private __GouseiSequense_S540_init_0024callable40_002410_5__ Loading;

	public UISituation CurrentSituation => currSituation;

	protected SQEX_SoundPlayer sndmgr
	{
		get
		{
			SQEX_SoundPlayer result;
			if ((bool)soundManager)
			{
				result = soundManager;
			}
			else
			{
				soundManager = SQEX_SoundPlayer.Instance;
				result = soundManager;
			}
			return result;
		}
	}

	public bool IsLoading
	{
		get
		{
			return isLoading;
		}
		private set
		{
			isLoading = value;
		}
	}

	public bool IsChangingSituation => isChangingSituation;

	public UIMain()
	{
		situations = new UISituation[0];
		situationDict = new Dictionary<string, UISituation>();
		soundDelay = 2f;
		soundFadeIn = 2000f;
		soundFadeOut = 2000f;
	}

	public void OnModalCollider()
	{
		if ((bool)modalCol)
		{
			modalColliderActive = modalCol.activeSelf;
			modalCol.SetActive(value: true);
		}
	}

	public void OffModalCollider(bool revaer)
	{
		if ((bool)modalCol)
		{
			modalCol.SetActive(revaer && modalColliderActive);
		}
	}

	public UISituation GetSituation(string situ_title)
	{
		return situationDict[situ_title];
	}

	public UISituation GetSituation(int index)
	{
		UISituation[] array = situations;
		return array[RuntimeServices.NormalizeArrayIndex(array, index)];
	}

	public void SetSituation(UISituation s, int idx)
	{
		UISituation[] array = situations;
		array[RuntimeServices.NormalizeArrayIndex(array, idx)] = s;
	}

	public void StartLoadiong()
	{
		if (Loading != null)
		{
			isLoading = true;
			OnModalCollider();
			LoadingUpdate();
		}
		else
		{
			EndLoading();
		}
	}

	public void EndLoading()
	{
		isLoading = false;
		OffModalCollider(IsChangingSituation);
	}

	public void SetLoadingRoutine(__GouseiSequense_S540_init_0024callable40_002410_5__ loading)
	{
		Loading = loading;
	}

	private void LoadingUpdate()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024LoadingUpdate_0024doLoading_00242796_002422043(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__2 = () => new _0024_0024LoadingUpdate_0024update_00242797_002422046(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__2());
	}

	protected UIButtonMessage[] SetupAllNullButton()
	{
		UIButtonMessage[] array = new UIButtonMessage[0];
		UIButtonMessage[] lhs = ((UIButtonMessage[])UnityEngine.Object.FindObjectsOfType(typeof(UIButtonMessage))) as UIButtonMessage[];
		UIButtonMessage[] componentsInChildren = GetComponentsInChildren<UIButtonMessage>(includeInactive: true);
		lhs = (UIButtonMessage[])RuntimeServices.AddArrays(typeof(UIButtonMessage), lhs, componentsInChildren);
		int i = 0;
		UIButtonMessage[] array2 = lhs;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array2[i])
			{
				if (!array2[i].target)
				{
					array2[i].target = gameObject;
				}
				if (array2[i].sendMessage)
				{
					array = (UIButtonMessage[])RuntimeServices.AddArrays(typeof(UIButtonMessage), array, new UIButtonMessage[1] { array2[i] });
				}
			}
		}
		return array;
	}

	protected virtual void SceneAwake()
	{
	}

	protected virtual void SceneStart()
	{
	}

	protected virtual void SceneUpdate()
	{
	}

	protected void Awake()
	{
		isChangingSituation = false;
		modalCol = ModalCollider.GetCollider();
		SetupAllNullButton();
		server = MerlinServer.Instance;
		if (!server)
		{
			server = (MerlinServer)UnityEngine.Object.FindObjectOfType(typeof(MerlinServer));
		}
		GameObject gameObject = GameObject.Find("BG Panel");
		if ((bool)gameObject)
		{
			IEnumerator enumerator = gameObject.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (!(transform.parent != gameObject.transform))
				{
					transform.gameObject.SetActive(value: false);
					if (!baseBg)
					{
						baseBg = transform.gameObject;
					}
				}
			}
		}
		SwitchBg(baseBg);
		hudLayer = ((UIHUDLayer)UnityEngine.Object.FindObjectOfType(typeof(UIHUDLayer))) as UIHUDLayer;
		SceneAwake();
	}

	protected void Start()
	{
		if (!string.IsNullOrEmpty(title))
		{
			SceneTitleHUD.UpdateTitle(title);
		}
		int i = 0;
		UISituation[] array = situations;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].ignoreTimeScale = ignoreTimeScale;
					situationDict[array[i].title] = array[i];
					UISituation.Activate(array[i], activate: true);
				}
			}
			int j = 0;
			UISituation[] array2 = situations;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if ((bool)array2[j])
				{
					array2[j].StopAnimation();
				}
			}
			int k = 0;
			UISituation[] array3 = situations;
			for (int length3 = array3.Length; k < length3; k++)
			{
				if ((bool)array3[k])
				{
					UISituation.Activate(array3[k], activate: false);
				}
			}
			if (!string.IsNullOrEmpty(startSituation) && situationDict.ContainsKey(startSituation))
			{
				ChangeSituation(situationDict[startSituation]);
			}
			SceneStart();
			StartLoadiong();
		}
	}

	private void Update()
	{
		UIListItem.UpdateColorRadian(Time.deltaTime);
		if (!IsLoading && !IsChangingSituation)
		{
			SceneUpdate();
		}
	}

	public void OnDisable()
	{
		if (buttonMssages == null)
		{
			return;
		}
		int i = 0;
		UIButtonMessage[] array = buttonMssages;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].sendMessage = true;
			}
		}
		buttonMssages = null;
	}

	protected IEnumerator StartSituation(UISituation situation)
	{
		return new _0024StartSituation_002422026(situation, this).GetEnumerator();
	}

	protected IEnumerator EndSituation(UISituation situation)
	{
		return new _0024EndSituation_002422032(situation, this).GetEnumerator();
	}

	private IEnumerator play_animation(UISituation situation, bool forward)
	{
		return new _0024play_animation_002422038(situation, forward).GetEnumerator();
	}

	protected void SwitchBg(UISituation situation)
	{
		if (situation.showBg)
		{
			SwitchBg(situation.bg);
		}
		else if ((bool)nowBg)
		{
			nowBg.SetActive(value: false);
			nowBg = null;
		}
	}

	protected void SwitchBg(GameObject bg)
	{
		if (!bg)
		{
			if (!baseBg)
			{
				nowBg = null;
				return;
			}
			bg = baseBg;
		}
		if (!(nowBg == bg))
		{
			if ((bool)nowBg)
			{
				nowBg.SetActive(value: false);
			}
			bg.SetActive(value: true);
			nowBg = bg;
		}
	}

	public void ChangeSituation(UISituation situation)
	{
		ChangeSituation(situation, wait_currSituation: false);
	}

	public void ChangeSituation(UISituation situation, bool wait_currSituation)
	{
		_0024ChangeSituation_0024locals_002414548 _0024ChangeSituation_0024locals_0024 = new _0024ChangeSituation_0024locals_002414548();
		_0024ChangeSituation_0024locals_0024._0024wait_currSituation = wait_currSituation;
		if (!isChangingSituation && !(currSituation == situation))
		{
			buttonMssages = SetupAllNullButton();
			__UIMain_ChangeSituation_0024callable131_0024241_13__ _UIMain_ChangeSituation_0024callable131_0024241_13__ = new _0024ChangeSituation_0024DoChangeSituation_00242973(this, _0024ChangeSituation_0024locals_0024).Invoke;
			StartCoroutine(_UIMain_ChangeSituation_0024callable131_0024241_13__(situation));
		}
	}

	public virtual void PushChangeSituation(string situ_title)
	{
		ChangeSituation(GetSituation(situ_title), wait_currSituation: false);
	}

	protected void PlaySE(string seName)
	{
		if ((bool)sndmgr)
		{
			int soundID = sndmgr.PlaySe(seName, checked((int)soundDelay), gameObject.GetInstanceID());
			sndmgr.SetSeVoulme(soundID, 1f);
		}
	}

	protected void StopSE()
	{
		if ((bool)sndmgr)
		{
			sndmgr.StopAllSe(checked((int)soundDelay));
		}
	}

	public virtual void LockTouch(bool on)
	{
		ModalCollider.SetActive(this, on);
	}

	internal IEnumerator _0024LoadingUpdate_0024doLoading_00242796()
	{
		return new _0024_0024LoadingUpdate_0024doLoading_00242796_002422043(this).GetEnumerator();
	}

	internal IEnumerator _0024LoadingUpdate_0024update_00242797()
	{
		return new _0024_0024LoadingUpdate_0024update_00242797_002422046(this).GetEnumerator();
	}
}
