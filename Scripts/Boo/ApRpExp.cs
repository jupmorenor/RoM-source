using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ApRpExp : MonoBehaviour
{
	[Serializable]
	public class Gauge
	{
		public GameObject root;

		public UISlider slider;

		public UILabelBase upperTextLabel;

		public UILabelBase lowerTextLabel;

		public string UpperText
		{
			get
			{
				return (!(upperTextLabel != null)) ? string.Empty : upperTextLabel.text;
			}
			set
			{
				if (upperTextLabel != null && upperTextLabel.text != value)
				{
					upperTextLabel.text = value;
				}
			}
		}

		public string LowerText
		{
			get
			{
				return (!(lowerTextLabel != null)) ? string.Empty : lowerTextLabel.text;
			}
			set
			{
				if (lowerTextLabel != null)
				{
					if (lowerTextLabel.text != value)
					{
						lowerTextLabel.text = value;
					}
					lowerTextLabel.gameObject.SetActive(value != null);
				}
			}
		}

		public void setSliderValue(int val, int maximum, bool withText)
		{
			if (withText)
			{
				string upperText = new StringBuilder().Append((object)val).Append("/").Append((object)maximum)
					.ToString();
				if (maximum < val)
				{
					string lhs = "[fb4e92]";
					upperText = lhs + new StringBuilder().Append((object)val).Append("[-]/").Append((object)maximum)
						.ToString();
				}
				UpperText = upperText;
			}
			float num = 0f;
			if (0 < maximum)
			{
				num = (float)val / (float)maximum;
			}
			if ((bool)slider && slider.sliderValue != Mathf.Clamp01(num))
			{
				slider.sliderValue = num;
			}
		}

		public void activate(bool b)
		{
			if (root != null)
			{
				root.SetActive(b);
			}
			if (slider != null)
			{
				slider.gameObject.SetActive(b);
			}
			if (upperTextLabel != null)
			{
				upperTextLabel.gameObject.SetActive(b);
			}
			if (lowerTextLabel != null)
			{
				lowerTextLabel.gameObject.SetActive(b);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CureApRpCore_002421236 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002421237;

			internal float _0024_0024wait_sec_0024temp_00242468_002421238;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024ud_002421237 = UserData.Current;
					if (_0024ud_002421237 == null)
					{
						goto case 1;
					}
					MoveMSec = 300;
					ApParam = _0024ud_002421237.Ap;
					RpParam = _0024ud_002421237.Rp;
					ExpParam = _0024ud_002421237.Exp;
					LvParam = _0024ud_002421237.Level;
					BpParam = _0024ud_002421237.Bp;
					goto case 2;
				case 2:
					if (MoveMSec > 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242468_002421238 = 0.5f;
					goto case 3;
				case 3:
					if (_0024_0024wait_sec_0024temp_00242468_002421238 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242468_002421238 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[NonSerialized]
	private const string OVER_MAX_COLOR_FORMAT = "[fb4e92]";

	public Gauge AP;

	public Gauge RP;

	public Gauge Exp;

	public Gauge BP;

	[NonSerialized]
	private static bool reset;

	[NonSerialized]
	private static int apParam;

	[NonSerialized]
	private static int rpParam;

	[NonSerialized]
	private static int expParam;

	[NonSerialized]
	private static int lvParam;

	[NonSerialized]
	private static int bpParam;

	[NonSerialized]
	private static int lastApParam;

	[NonSerialized]
	private static int lastRpParam;

	[NonSerialized]
	private static int lastExpParam;

	[NonSerialized]
	private static int lastLvParam;

	[NonSerialized]
	private static int lastBpParam;

	[NonSerialized]
	public static int moveMSec;

	[NonSerialized]
	private static int curMoveMSec;

	[NonSerialized]
	private static float lastRealTime;

	private UIDisplayMode dispMode;

	[NonSerialized]
	private static Boo.Lang.List<ApRpExp> _InstanceList = new Boo.Lang.List<ApRpExp>();

	public static int ApParam
	{
		get
		{
			return apParam;
		}
		set
		{
			lastApParam = apParam;
			apParam = value;
			curMoveMSec = 0;
		}
	}

	public static int RpParam
	{
		get
		{
			return rpParam;
		}
		set
		{
			lastRpParam = rpParam;
			rpParam = value;
			curMoveMSec = 0;
		}
	}

	public static int ExpParam
	{
		get
		{
			return expParam;
		}
		set
		{
			lastExpParam = expParam;
			expParam = value;
			curMoveMSec = 0;
		}
	}

	public static int LvParam
	{
		get
		{
			return lvParam;
		}
		set
		{
			lastLvParam = lvParam;
			lvParam = value;
			curMoveMSec = 0;
		}
	}

	public static int BpParam
	{
		get
		{
			return bpParam;
		}
		set
		{
			lastBpParam = bpParam;
			bpParam = value;
			curMoveMSec = 0;
		}
	}

	public static ApRpExp Instance
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

	public static bool Reset
	{
		get
		{
			return reset;
		}
		set
		{
			reset = value;
		}
	}

	public static int MoveMSec
	{
		get
		{
			return moveMSec;
		}
		set
		{
			moveMSec = value;
		}
	}

	public ApRpExp()
	{
		dispMode = UIDisplayMode.None;
	}

	public void Start()
	{
		UserData current = UserData.Current;
		if (current != null)
		{
			ApParam = current.Ap;
			RpParam = current.Rp;
			ExpParam = current.Exp;
			LvParam = current.Level;
			BpParam = current.Bp;
			moveMSec = 0;
			lastRealTime = Time.realtimeSinceStartup;
		}
	}

	public void _0024hud_0024OnEnable()
	{
		dispMode = UIDisplayMode.None;
	}

	public void _0024hud_0024OnDisable()
	{
		dispMode = UIDisplayMode.None;
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

	public static void Show()
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
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
		if (dispMode != UIDisplayMode.Showing)
		{
			int i = 0;
			GameObject[] array = ExtensionsModule.Children(gameObject);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].SetActive(value: true);
			}
			dispMode = UIDisplayMode.Showing;
		}
	}

	public static void Hide()
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
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
		if (dispMode != UIDisplayMode.Hiding)
		{
			int i = 0;
			GameObject[] array = ExtensionsModule.Children(gameObject);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].SetActive(value: false);
			}
			dispMode = UIDisplayMode.Hiding;
		}
	}

	private void setAP(int val, int maximum)
	{
		if (AP != null)
		{
			AP.setSliderValue(val, maximum, withText: true);
		}
	}

	private void setRP(int val, int maximum)
	{
		if (RP != null)
		{
			RP.setSliderValue(val, maximum, withText: true);
		}
	}

	private void setLvExp(int lv, int exp, int curLvExp, int nextLvExp)
	{
		checked
		{
			if (curLvExp < nextLvExp)
			{
				int num = exp - curLvExp;
				int num2 = nextLvExp - curLvExp;
				if (Exp != null)
				{
					Exp.LowerText = $"Next:{num2 - num:N0}";
					Exp.setSliderValue(num, num2, withText: false);
					Exp.UpperText = "lv" + lv.ToString();
				}
			}
		}
	}

	private void setBP(int val, int maximum)
	{
		if (BP != null)
		{
			BP.setSliderValue(val, maximum, withText: true);
		}
	}

	public static void SetAP(int val, int maximum)
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__SetAP(val, maximum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetAP(int val, int maximum)
	{
		setAP(val, maximum);
	}

	public static void SetRP(int val, int maximum)
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__SetRP(val, maximum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetRP(int val, int maximum)
	{
		setRP(val, maximum);
	}

	public static void SetLvExp(int lv, int exp, int curLvExp, int nextLvExp)
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__SetLvExp(lv, exp, curLvExp, nextLvExp);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetLvExp(int lv, int exp, int curLvExp, int nextLvExp)
	{
		setLvExp(lv, exp, curLvExp, nextLvExp);
	}

	public static void RestorationTime()
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__RestorationTime();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __RestorationTime()
	{
		UserData current = UserData.Current;
		checked
		{
			RestorationTime(AP, current.EndApRecoveryDateTime, (int)UserData.ApRecoverySec);
			RestorationTime(RP, current.EndRpRecoveryDateTime, (int)UserData.RpRecoverySec);
			RestorationTime(BP, current.EndBpRecoveryDateTime, (int)UserData.BpRecoverySec);
			if (current.Ap != apParam || current.Rp != rpParam || current.Bp != bpParam)
			{
				reset = true;
			}
		}
	}

	public static void SetBP(int val, int maximum)
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__SetBP(val, maximum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetBP(int val, int maximum)
	{
		setBP(val, maximum);
	}

	private void RestorationTime(Gauge gauge, DateTime end, int sec)
	{
		if (gauge != null)
		{
			gauge.LowerText = SecToMSByText(GetSecMS(end, sec));
		}
	}

	public static float GetSecMS(DateTime end, int recSec)
	{
		float num = (float)(end - MerlinDateTime.UtcNow).TotalSeconds;
		return (!(num < 0f) && !(end < MerlinDateTime.UtcNow)) ? (num % (float)recSec) : (-1f);
	}

	private static string SecToMSByText(float sec)
	{
		object result;
		if (!(sec >= 0f))
		{
			result = null;
		}
		else
		{
			int num = checked((int)(sec / 60f)) % 60;
			int num2 = checked((int)sec) % 60;
			result = $"{num:D1}:{num2:D2}";
		}
		return (string)result;
	}

	private int moveValue(int lastValue, int newValue)
	{
		checked
		{
			return (moveMSec > 0 && moveMSec > curMoveMSec) ? (lastValue + unchecked(checked(curMoveMSec * (newValue - lastValue)) / moveMSec)) : newValue;
		}
	}

	private void Update()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		float num = default(float);
		if (!(lastRealTime <= 0f))
		{
			num = (realtimeSinceStartup - lastRealTime) * 1000f;
		}
		lastRealTime = realtimeSinceStartup;
		if (reset)
		{
			apParam = current.Ap;
			rpParam = current.Rp;
			expParam = current.Exp;
			lvParam = current.Level;
			bpParam = current.Bp;
			reset = false;
		}
		int val = apParam;
		int val2 = rpParam;
		int exp = expParam;
		int lv = lvParam;
		int val3 = bpParam;
		if (curMoveMSec < moveMSec && moveMSec > 0)
		{
			curMoveMSec = checked((int)((float)curMoveMSec + num));
			val = moveValue(lastApParam, apParam);
			val2 = moveValue(lastRpParam, rpParam);
			exp = moveValue(lastExpParam, expParam);
			lv = moveValue(lastLvParam, lvParam);
			val3 = moveValue(lastBpParam, bpParam);
			if (curMoveMSec >= moveMSec)
			{
				lastApParam = apParam;
				lastRpParam = rpParam;
				lastExpParam = expParam;
				lastLvParam = lvParam;
				lastBpParam = bpParam;
				moveMSec = 0;
				curMoveMSec = 0;
			}
		}
		setAP(val, current.MaxAp);
		setRP(val2, current.MaxRp);
		setLvExp(lv, exp, current.CurrentLevelExp, current.NextLevelExp);
		setBP(val3, current.MaxBp);
		RestorationTime();
	}

	public static void CureApRp()
	{
		IEnumerator<ApRpExp> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ApRpExp current = enumerator.Current;
				current.__CureApRp();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __CureApRp()
	{
		StartCoroutine(CureApRpCore());
	}

	public IEnumerator CureApRpCore()
	{
		return new _0024CureApRpCore_002421236().GetEnumerator();
	}
}
