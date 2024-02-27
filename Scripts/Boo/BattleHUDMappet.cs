using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDMappet : MonoBehaviour
{
	[Serializable]
	public class Compo
	{
		public UIButtonMessage button;

		public UISprite badIcon;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024rechargeGaugeAnimationMain_002421326 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024useGaugeAnimationMain_002421327 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Compo _0024c_002421328;

			internal float _0024_0024wait_sec_0024temp_00242475_002421329;

			internal int _0024index_002421330;

			internal BattleHUDMappet _0024self__002421331;

			public _0024(int index, BattleHUDMappet self_)
			{
				_0024index_002421330 = index;
				_0024self__002421331 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024self__002421331.isInvalidIndex(_0024index_002421330))
					{
						goto case 1;
					}
					Compo[] compoList = _0024self__002421331.CompoList;
					_0024c_002421328 = compoList[RuntimeServices.NormalizeArrayIndex(compoList, _0024index_002421330)];
					iTween.ScaleTo(_0024c_002421328.button.gameObject, iTween.Hash("x", 0.8f, "y", 0.8f, "time", 0.3f, "easetype", iTween.EaseType.easeOutExpo));
					_0024_0024wait_sec_0024temp_00242475_002421329 = 0.3f;
					goto case 2;
				}
				case 2:
					if (_0024_0024wait_sec_0024temp_00242475_002421329 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242475_002421329 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					iTween.ScaleTo(_0024c_002421328.button.gameObject, iTween.Hash("x", 1f, "y", 1f, "time", 0.3f));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024index_002421332;

		internal BattleHUDMappet _0024self__002421333;

		public _0024useGaugeAnimationMain_002421327(int index, BattleHUDMappet self_)
		{
			_0024index_002421332 = index;
			_0024self__002421333 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024index_002421332, _0024self__002421333);
		}
	}

	public Compo[] CompoList;

	public float YPosToShow;

	public float YPosToHide;

	private Hashtable showHash;

	private Hashtable hideHash;

	private UIDisplayMode dispMode;

	[NonSerialized]
	protected const float HUD_MOVE_TIME = 3f;

	[NonSerialized]
	protected const float RECHARGE_ANIMATION_TIME = 0.5f;

	[NonSerialized]
	protected const float RECHARGE_ANIMATION_ICON_SIZE = 1.2f;

	[NonSerialized]
	protected const float USE_GAUGE_ANIMATION_TIME = 0.3f;

	[NonSerialized]
	protected const float USE_GAUGE_ANIMATION_ICON_SIZE = 0.8f;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDMappet> _InstanceList = new Boo.Lang.List<BattleHUDMappet>();

	private bool isHide;

	public UIButtonMessage[] __AllButtons
	{
		get
		{
			Boo.Lang.List<UIButtonMessage> list = new Boo.Lang.List<UIButtonMessage>();
			int i = 0;
			Compo[] compoList = CompoList;
			for (int length = compoList.Length; i < length; i = checked(i + 1))
			{
				if (compoList[i] != null && compoList[i].button != null)
				{
					list.Add(compoList[i].button);
				}
			}
			return list.ToArray();
		}
	}

	public int __ButtonNum => CompoList.Length;

	public static BattleHUDMappet Instance
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

	public static UIButtonMessage[] AllButtons
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__AllButtons;
		}
	}

	public static int ButtonNum
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__ButtonNum;
		}
	}

	public BattleHUDMappet()
	{
		CompoList = new Compo[0];
		YPosToShow = 325f;
		YPosToHide = -270f;
		dispMode = UIDisplayMode.None;
		isHide = true;
	}

	public void Awake()
	{
		showHash = iTween.Hash("y", YPosToShow, "time", 3f, "islocal", true);
		hideHash = iTween.Hash("y", YPosToHide, "time", 3f, "islocal", true);
	}

	public void _0024hud_0024OnEnable()
	{
		dispMode = UIDisplayMode.None;
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

	public static void ActivateButtons(bool onoff)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__ActivateButtons(onoff);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ActivateButtons(bool onoff)
	{
		int i = 0;
		UIButtonMessage[] allButtons = AllButtons;
		for (int length = allButtons.Length; i < length; i = checked(i + 1))
		{
			allButtons[i].sendMessage = onoff;
		}
	}

	public bool isTargetMappet(GameObject t)
	{
		int num = 0;
		UIButtonMessage[] allButtons = AllButtons;
		int length = allButtons.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (allButtons[num].target == t)
				{
					result = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public static void SetTargetMappet(int index, GameObject t)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__SetTargetMappet(index, t);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetTargetMappet(int index, GameObject t)
	{
		if (isInvalidIndex(index))
		{
			return;
		}
		Compo[] compoList = CompoList;
		Compo compo = compoList[RuntimeServices.NormalizeArrayIndex(compoList, index)];
		compo.button.target = t;
		GameObject gameObject = compo.button.gameObject;
		if (!(gameObject != null))
		{
			return;
		}
		if (t != null)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(value: true);
			}
		}
		else if (gameObject.activeSelf)
		{
			gameObject.SetActive(value: false);
		}
	}

	public static void ResetTargetMappet(int index)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__ResetTargetMappet(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ResetTargetMappet(int index)
	{
		if (!isInvalidIndex(index))
		{
			Compo[] compoList = CompoList;
			Compo compo = compoList[RuntimeServices.NormalizeArrayIndex(compoList, index)];
			compo.button.gameObject.SetActive(value: false);
			compo.button.target = null;
		}
	}

	public static void setTargetMappetAndShow(int index, GameObject t)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__setTargetMappetAndShow(index, t);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setTargetMappetAndShow(int index, GameObject t)
	{
		SetTargetMappet(index, t);
		Show();
	}

	public static void Show()
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__Show();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Show()
	{
		if (isHide)
		{
			isHide = false;
			iTween.Stop(gameObject);
			iTween.MoveTo(gameObject, showHash);
		}
		dispMode = UIDisplayMode.Showing;
	}

	public static void Hide()
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__Hide();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Hide()
	{
		if (!isHide)
		{
			isHide = true;
			iTween.Stop(gameObject);
			iTween.MoveTo(gameObject, hideHash);
		}
		dispMode = UIDisplayMode.Hiding;
	}

	public static void RechargeGaugeAnimation(int index)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__RechargeGaugeAnimation(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __RechargeGaugeAnimation(int index)
	{
		if (!isInvalidIndex(index))
		{
			IEnumerator enumerator = rechargeGaugeAnimationMain(index);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator rechargeGaugeAnimationMain(int index)
	{
		return new _0024rechargeGaugeAnimationMain_002421326().GetEnumerator();
	}

	public static void UseGaugeAnimation(int index)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__UseGaugeAnimation(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __UseGaugeAnimation(int index)
	{
		if (!isInvalidIndex(index))
		{
			IEnumerator enumerator = useGaugeAnimationMain(index);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator useGaugeAnimationMain(int index)
	{
		return new _0024useGaugeAnimationMain_002421327(index, this).GetEnumerator();
	}

	public static void EnableBadIcon(bool b)
	{
		IEnumerator<BattleHUDMappet> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappet current = enumerator.Current;
				current.__EnableBadIcon(b);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableBadIcon(bool b)
	{
		int i = 0;
		Compo[] compoList = CompoList;
		for (int length = compoList.Length; i < length; i = checked(i + 1))
		{
			if (compoList[i] != null && !(compoList[i].badIcon == null))
			{
				compoList[i].badIcon.gameObject.SetActive(b);
			}
		}
	}

	private bool isInvalidIndex(int index)
	{
		int result;
		if (index >= 0 && index < CompoList.Length)
		{
			Compo[] compoList = CompoList;
			if (compoList[RuntimeServices.NormalizeArrayIndex(compoList, index)] != null)
			{
				Compo[] compoList2 = CompoList;
				if (!(compoList2[RuntimeServices.NormalizeArrayIndex(compoList2, index)].button == null))
				{
					result = 0;
					goto IL_0055;
				}
			}
		}
		result = 1;
		goto IL_0055;
		IL_0055:
		return (byte)result != 0;
	}
}
