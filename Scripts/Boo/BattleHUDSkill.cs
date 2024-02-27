using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDSkill : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		UNKNOWN,
		HIDDEN,
		SHOWN,
		SHOWN_CHANGE_ONLY
	}

	[Serializable]
	public class Compo
	{
		public UIButtonMessage button;

		public UILabel label;

		public UISprite @base;

		public UISprite badIcon;
	}

	public GameObject HUDTargetChar;

	public float YPosToShow;

	public float YPosToDisplayChangeButtonOnly;

	private float YPosToHide;

	public Compo[] SkillUIs;

	private UIButtonMessage[] allButtonsList;

	private float InitBaseY;

	public Mode mode;

	private Hashtable step1Hash;

	private Hashtable step2Hash;

	private Hashtable step3Hash;

	private Hashtable step4Hash;

	[NonSerialized]
	protected const float HUD_MOVE_TIME = 1f;

	[NonSerialized]
	protected const float RECHARGE_SKILL_ANIMATION_TIME = 0.5f;

	[NonSerialized]
	protected const float RECHARGE_SKILL_ANIMATION_ICON_SIZE = 1.2f;

	[NonSerialized]
	protected const float USE_SKILL_ANIMATION_TIME = 0.3f;

	[NonSerialized]
	protected const float USE_SKILL_ANIMATION_ICON_SIZE = 0.8f;

	[NonSerialized]
	protected const float BUTTON_SCALE_RESTORATION_TIME = 0.2f;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDSkill> _InstanceList = new Boo.Lang.List<BattleHUDSkill>();

	public UIButtonMessage[] __AllButtons => allButtonsList;

	public UILabel[] __AllLabels
	{
		get
		{
			Boo.Lang.List<UILabel> list = new Boo.Lang.List<UILabel>();
			int i = 0;
			Compo[] skillUIs = SkillUIs;
			for (int length = skillUIs.Length; i < length; i = checked(i + 1))
			{
				if (skillUIs[i] != null && skillUIs[i].label != null)
				{
					list.Add(skillUIs[i].label);
				}
			}
			return list.ToArray();
		}
	}

	public UISprite[] __AllBase
	{
		get
		{
			Boo.Lang.List<UISprite> list = new Boo.Lang.List<UISprite>();
			int i = 0;
			Compo[] skillUIs = SkillUIs;
			for (int length = skillUIs.Length; i < length; i = checked(i + 1))
			{
				if (skillUIs[i] != null && skillUIs[i].@base != null)
				{
					list.Add(skillUIs[i].@base);
				}
			}
			return list.ToArray();
		}
	}

	public static BattleHUDSkill Instance
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

	public static UILabel[] AllLabels
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__AllLabels;
		}
	}

	public static UISprite[] AllBase
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__AllBase;
		}
	}

	public BattleHUDSkill()
	{
		YPosToShow = 325f;
		YPosToDisplayChangeButtonOnly = 185f;
		mode = Mode.UNKNOWN;
	}

	public void Awake()
	{
		step1Hash = iTween.Hash("x", 1.2f, "y", 1.2f, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic, "oncomplete", "rechargeSkillAnimationStep2", "oncompletetarget", gameObject, "oncompleteparams", 0);
		step2Hash = iTween.Hash("x", 1f, "y", 1f, "time", 0.2f, "oncomplete", "rechargeSkillAnimationStep3", "oncompletetarget", gameObject, "oncompleteparams", 0);
		step3Hash = iTween.Hash("x", 0.8f, "y", 0.8f, "time", 0.3f, "easetype", iTween.EaseType.easeOutExpo, "oncomplete", "useSkillAnimationStep2", "oncompletetarget", gameObject, "oncompleteparams", 0);
		step4Hash = iTween.Hash("x", 1f, "y", 1f, "time", 0.2f);
	}

	public void Start()
	{
		Boo.Lang.List<UIButtonMessage> list = new Boo.Lang.List<UIButtonMessage>();
		int i = 0;
		Compo[] skillUIs = SkillUIs;
		for (int length = skillUIs.Length; i < length; i = checked(i + 1))
		{
			if (skillUIs[i] != null && skillUIs[i].button != null)
			{
				list.Add(skillUIs[i].button);
			}
		}
		allButtonsList = list.ToArray();
		InitBaseY = transform.localPosition.y;
		if (HUDTargetChar != null)
		{
			SetTargetChar(HUDTargetChar);
		}
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

	public static void activateButtons(bool onoff)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__activateButtons(onoff);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __activateButtons(bool onoff)
	{
		int i = 0;
		UIButtonMessage[] allButtons = AllButtons;
		for (int length = allButtons.Length; i < length; i = checked(i + 1))
		{
			allButtons[i].sendMessage = onoff;
		}
	}

	public static void SetTargetChar(GameObject t)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__SetTargetChar(t);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetTargetChar(GameObject t)
	{
		if (!(HUDTargetChar == t))
		{
			HUDTargetChar = t;
			int i = 0;
			UIButtonMessage[] allButtons = AllButtons;
			for (int length = allButtons.Length; i < length; i = checked(i + 1))
			{
				allButtons[i].target = t;
			}
		}
	}

	public static void SetButtonAttr(int index, string text, Color col)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__SetButtonAttr(index, text, col);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetButtonAttr(int index, string text, Color col)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			Compo compo = skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)];
			if (compo.label != null && compo.label.text != text)
			{
				compo.label.text = text;
			}
			if (compo.@base != null && compo.@base.color != col)
			{
				compo.@base.color = col;
			}
		}
	}

	public static void SetButtonSprite(int index, string sprite)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__SetButtonSprite(index, sprite);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetButtonSprite(int index, string sprite)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			Compo compo = skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)];
			if (!(compo.@base == null))
			{
				IconAtlasPool.SetSprite(compo.@base, sprite);
			}
		}
	}

	public static void SetButtonSpriteKeepAtlas(int index, string sprite)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__SetButtonSpriteKeepAtlas(index, sprite);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetButtonSpriteKeepAtlas(int index, string sprite)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			Compo compo = skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)];
			if (!(compo.@base == null))
			{
				compo.@base.spriteName = sprite;
			}
		}
	}

	public static void Show()
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
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
		if (!(HUDTargetChar == null) && mode != Mode.SHOWN)
		{
			TweenPosition.Begin(gameObject, 1f, new Vector3(gameObject.transform.localPosition.x, YPosToShow, gameObject.transform.localPosition.z));
			mode = Mode.SHOWN;
		}
	}

	public static void ShowChangeButtonOnly()
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__ShowChangeButtonOnly();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ShowChangeButtonOnly()
	{
		if (!(HUDTargetChar == null) && mode != Mode.SHOWN_CHANGE_ONLY)
		{
			TweenPosition.Begin(gameObject, 1f, new Vector3(gameObject.transform.localPosition.x, YPosToDisplayChangeButtonOnly, gameObject.transform.localPosition.z));
			mode = Mode.SHOWN_CHANGE_ONLY;
		}
	}

	public static void Hide()
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
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
		if (!(HUDTargetChar == null) && mode != Mode.HIDDEN)
		{
			TweenPosition.Begin(gameObject, 1f, new Vector3(gameObject.transform.localPosition.x, YPosToHide, gameObject.transform.localPosition.z));
			mode = Mode.HIDDEN;
		}
	}

	public static void RechargeSkillAnimation(int index)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__RechargeSkillAnimation(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __RechargeSkillAnimation(int index)
	{
		if (index >= 0 && index < SkillUIs.Length)
		{
			Compo[] skillUIs = SkillUIs;
			if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
			{
				rechargeSkillAnimationStep1(index);
			}
		}
	}

	public static void EnableSkillBadIcon(int index, bool b)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__EnableSkillBadIcon(index, b);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableSkillBadIcon(int index, bool b)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			if (!(skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)].badIcon == null))
			{
				Compo[] skillUIs3 = SkillUIs;
				skillUIs3[RuntimeServices.NormalizeArrayIndex(skillUIs3, index)].badIcon.gameObject.SetActive(b);
			}
		}
	}

	private void rechargeSkillAnimationStep1(int index)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			Compo compo = skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)];
			step1Hash["oncompleteparams"] = index;
			if (compo.button != null)
			{
				iTween.ScaleTo(compo.button.gameObject, step1Hash);
			}
		}
	}

	public void rechargeSkillAnimationStep2(int index)
	{
		Compo[] skillUIs = SkillUIs;
		Compo compo = skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)];
		SetButtonAttr(index, string.Empty, Color.white);
		step2Hash["oncompleteparams"] = index;
		if (compo.button != null)
		{
			iTween.ScaleTo(compo.button.gameObject, step2Hash);
		}
	}

	public void rechargeSkillAnimationStep3(int index)
	{
		SetButtonAttr(index, string.Empty, Color.white);
	}

	public static void UseSkillAnimation(int index)
	{
		IEnumerator<BattleHUDSkill> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDSkill current = enumerator.Current;
				current.__UseSkillAnimation(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __UseSkillAnimation(int index)
	{
		if (index >= 0 && index < SkillUIs.Length)
		{
			Compo[] skillUIs = SkillUIs;
			if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
			{
				useSkillAnimationStep1(index);
			}
		}
	}

	private void useSkillAnimationStep1(int index)
	{
		if (index < 0 || index >= SkillUIs.Length)
		{
			return;
		}
		Compo[] skillUIs = SkillUIs;
		if (skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)] != null)
		{
			Compo[] skillUIs2 = SkillUIs;
			Compo compo = skillUIs2[RuntimeServices.NormalizeArrayIndex(skillUIs2, index)];
			step3Hash["oncompleteparams"] = index;
			if (compo.button != null)
			{
				iTween.ScaleTo(compo.button.gameObject, step3Hash);
			}
		}
	}

	public void useSkillAnimationStep2(int index)
	{
		Compo[] skillUIs = SkillUIs;
		Compo compo = skillUIs[RuntimeServices.NormalizeArrayIndex(skillUIs, index)];
		if (compo.button != null)
		{
			iTween.ScaleTo(compo.button.gameObject, step4Hash);
		}
	}

	public void useSkillAnimationStep3(int index)
	{
		SetButtonAttr(index, string.Empty, Color.white);
	}
}
