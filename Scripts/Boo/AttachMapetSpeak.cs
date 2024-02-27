using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;
using UnityEngine;

[Serializable]
public class AttachMapetSpeak : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024showRoutine_002421239 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024c_002421240;

			internal UITweener _0024t_002421241;

			internal int _0024_002410308_002421242;

			internal GameObject[] _0024_002410309_002421243;

			internal int _0024_002410310_002421244;

			internal int _0024_002410312_002421245;

			internal UITweener[] _0024_002410313_002421246;

			internal int _0024_002410314_002421247;

			internal GameObject _0024_target_002421248;

			internal MPoppetChats _0024chat_002421249;

			internal AttachMapetSpeak _0024self__002421250;

			public _0024(GameObject _target, MPoppetChats chat, AttachMapetSpeak self_)
			{
				_0024_target_002421248 = _target;
				_0024chat_002421249 = chat;
				_0024self__002421250 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002421250.fukidashiParts == null)
						{
							throw new AssertionFailedException("fukidashiParts != null");
						}
						if (!_0024self__002421250.fukidashiInActive)
						{
							goto case 1;
						}
						if (_0024_target_002421248 != null && _0024chat_002421249 != null)
						{
							_0024self__002421250.fukidashiInActive = false;
							_0024_002410308_002421242 = 0;
							_0024_002410309_002421243 = _0024self__002421250.fukidashiParts;
							for (_0024_002410310_002421244 = _0024_002410309_002421243.Length; _0024_002410308_002421242 < _0024_002410310_002421244; _0024_002410308_002421242++)
							{
								_0024_002410309_002421243[_0024_002410308_002421242].SetActive(value: true);
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						hide();
						goto IL_01d7;
					case 2:
						_0024self__002421250.initSpeakTime();
						_0024self__002421250.target = _0024_target_002421248;
						activeSpeak = _0024chat_002421249;
						_0024self__002421250.UpdatePos();
						if (_0024self__002421250.textLabel != null)
						{
							_0024self__002421250.textLabel.m_Text = _0024chat_002421249.GetText();
						}
						_0024_002410312_002421245 = 0;
						_0024_002410313_002421246 = _0024self__002421250.tweens;
						for (_0024_002410314_002421247 = _0024_002410313_002421246.Length; _0024_002410312_002421245 < _0024_002410314_002421247; _0024_002410312_002421245++)
						{
							if (!(_0024_002410313_002421246[_0024_002410312_002421245] == null))
							{
								_0024_002410313_002421246[_0024_002410312_002421245].Play(forward: true);
								_0024_002410313_002421246[_0024_002410312_002421245].Reset();
							}
						}
						goto IL_01d7;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01d7:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024_target_002421251;

		internal MPoppetChats _0024chat_002421252;

		internal AttachMapetSpeak _0024self__002421253;

		public _0024showRoutine_002421239(GameObject _target, MPoppetChats chat, AttachMapetSpeak self_)
		{
			_0024_target_002421251 = _target;
			_0024chat_002421252 = chat;
			_0024self__002421253 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024_target_002421251, _0024chat_002421252, _0024self__002421253);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024showMessageRoutine_002421254 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024c_002421255;

			internal UITweener _0024t_002421256;

			internal int _0024_002410316_002421257;

			internal GameObject[] _0024_002410317_002421258;

			internal int _0024_002410318_002421259;

			internal int _0024_002410320_002421260;

			internal UITweener[] _0024_002410321_002421261;

			internal int _0024_002410322_002421262;

			internal GameObject _0024_target_002421263;

			internal string _0024aMsg_002421264;

			internal AttachMapetSpeak _0024self__002421265;

			public _0024(GameObject _target, string aMsg, AttachMapetSpeak self_)
			{
				_0024_target_002421263 = _target;
				_0024aMsg_002421264 = aMsg;
				_0024self__002421265 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002421265.fukidashiParts == null)
						{
							goto case 1;
						}
						if (_0024_target_002421263 != null && _0024aMsg_002421264 != null)
						{
							_0024self__002421265.fukidashiInActive = false;
							_0024_002410316_002421257 = 0;
							_0024_002410317_002421258 = _0024self__002421265.fukidashiParts;
							for (_0024_002410318_002421259 = _0024_002410317_002421258.Length; _0024_002410316_002421257 < _0024_002410318_002421259; _0024_002410316_002421257++)
							{
								_0024_002410317_002421258[_0024_002410316_002421257].SetActive(value: true);
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						hide();
						goto IL_01b8;
					case 2:
						_0024self__002421265.initSpeakTime();
						_0024self__002421265.target = _0024_target_002421263;
						_0024self__002421265.UpdatePos();
						if (_0024self__002421265.textLabel != null)
						{
							_0024self__002421265.textLabel.m_Text = _0024aMsg_002421264;
						}
						_0024_002410320_002421260 = 0;
						_0024_002410321_002421261 = _0024self__002421265.tweens;
						for (_0024_002410322_002421262 = _0024_002410321_002421261.Length; _0024_002410320_002421260 < _0024_002410322_002421262; _0024_002410320_002421260++)
						{
							if (!(_0024_002410321_002421261[_0024_002410320_002421260] == null))
							{
								_0024_002410321_002421261[_0024_002410320_002421260].Play(forward: true);
								_0024_002410321_002421261[_0024_002410320_002421260].Reset();
							}
						}
						goto IL_01b8;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01b8:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024_target_002421266;

		internal string _0024aMsg_002421267;

		internal AttachMapetSpeak _0024self__002421268;

		public _0024showMessageRoutine_002421254(GameObject _target, string aMsg, AttachMapetSpeak self_)
		{
			_0024_target_002421266 = _target;
			_0024aMsg_002421267 = aMsg;
			_0024self__002421268 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024_target_002421266, _0024aMsg_002421267, _0024self__002421268);
		}
	}

	public GameObject target;

	public UIDynamicFontLabel textLabel;

	public UITweener[] tweens;

	public float drawOffsetY;

	private readonly float SPEAK_TIME;

	private float speakTime;

	private float initDrawOffsetY;

	private GameObject[] fukidashiParts;

	private bool fukidashiInActive;

	[NonSerialized]
	protected static MPoppetChats activeSpeak;

	private Transform mTrans;

	protected bool init;

	[NonSerialized]
	private static Boo.Lang.List<AttachMapetSpeak> _InstanceList = new Boo.Lang.List<AttachMapetSpeak>();

	public static AttachMapetSpeak Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public AttachMapetSpeak()
	{
		drawOffsetY = 150f;
		SPEAK_TIME = 3f;
		speakTime = SPEAK_TIME;
		fukidashiInActive = true;
	}

	public static MPoppetChats IsActiveChat(GameObject target)
	{
		return target ? activeSpeak : null;
	}

	public void Start()
	{
		Init();
	}

	public void Init()
	{
		if (init)
		{
			return;
		}
		mTrans = transform;
		init = true;
		fukidashiInActive = true;
		speakTime = 0f;
		initDrawOffsetY = drawOffsetY;
		int i = 0;
		UITweener[] array = tweens;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].enabled = false;
				}
			}
			fukidashiParts = ExtensionsModule.Children(gameObject);
			int j = 0;
			GameObject[] array2 = fukidashiParts;
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].SetActive(value: false);
			}
			mTrans.localScale = Vector3.zero;
		}
	}

	public void initSpeakTime()
	{
		speakTime = SPEAK_TIME;
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void setInitParam()
	{
		IEnumerator<AttachMapetSpeak> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttachMapetSpeak current = enumerator.Current;
				current.__setInitParam();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setInitParam()
	{
		drawOffsetY = initDrawOffsetY;
	}

	public static void show(GameObject _target, MPoppetChats chat)
	{
		IEnumerator<AttachMapetSpeak> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttachMapetSpeak current = enumerator.Current;
				current.__show(_target, chat);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __show(GameObject _target, MPoppetChats chat)
	{
		StartCoroutine(showRoutine(_target, chat));
	}

	public static void showMessage(GameObject _target, string aMsg)
	{
		IEnumerator<AttachMapetSpeak> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttachMapetSpeak current = enumerator.Current;
				current.__showMessage(_target, aMsg);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __showMessage(GameObject _target, string aMsg)
	{
		StartCoroutine(showMessageRoutine(_target, aMsg));
	}

	public static void hide()
	{
		IEnumerator<AttachMapetSpeak> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttachMapetSpeak current = enumerator.Current;
				current.__hide();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __hide()
	{
		if ((bool)target)
		{
			activeSpeak = null;
		}
		target = null;
		int i = 0;
		UITweener[] array = tweens;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].Play(forward: false);
			}
			array[i].Reset();
			array[i].onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(delegate
			{
				if (target == null)
				{
					fukidashiInActive = true;
				}
			});
		}
		speakTime = 0f;
	}

	public static void setDrawOffsetY(float ofsy)
	{
		IEnumerator<AttachMapetSpeak> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AttachMapetSpeak current = enumerator.Current;
				current.__setDrawOffsetY(ofsy);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setDrawOffsetY(float ofsy)
	{
		drawOffsetY = ofsy;
	}

	private IEnumerator showRoutine(GameObject _target, MPoppetChats chat)
	{
		return new _0024showRoutine_002421239(_target, chat, this).GetEnumerator();
	}

	public IEnumerator showMessageRoutine(GameObject _target, string aMsg)
	{
		return new _0024showMessageRoutine_002421254(_target, aMsg, this).GetEnumerator();
	}

	public void UpdatePos()
	{
		if (!(target == null) && !(Camera.main == null))
		{
			mTrans.localScale = Vector3.one;
			Vector3 screenPostion = ObjUtilModule.GetScreenPostion(mTrans, target, Camera.main);
			screenPostion.z = 1000f;
			screenPostion.y += drawOffsetY;
			mTrans.localPosition = screenPostion;
		}
	}

	public void Update()
	{
		if (!init)
		{
			Init();
		}
		if (fukidashiInActive)
		{
			int i = 0;
			GameObject[] array = fukidashiParts;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].activeSelf)
				{
					array[i].SetActive(value: false);
				}
			}
		}
		if (!(target == null) && !(Camera.main == null))
		{
			UpdatePos();
			speakTime -= Time.deltaTime;
			if (!(speakTime >= 0f))
			{
				hide();
			}
		}
	}

	internal void _0024__hide_0024closure_00243103()
	{
		if (target == null)
		{
			fukidashiInActive = true;
		}
	}
}
