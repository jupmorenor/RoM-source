using System;
using System.Collections.Generic;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class QuestStartInfo : MonoBehaviour
{
	public float delay;

	public string lastSceneName;

	public UITweener tween;

	protected TweenPosition[] posTween;

	protected UIDynamicFontLabel placeLabel;

	protected UIDynamicFontLabel typeLabel;

	protected UIDynamicFontLabel nameLabel;

	protected UIDynamicFontLabel infoLabel;

	protected UIPanel softFadePanel;

	public Transform window;

	protected CutSceneManager cutSceneMan;

	protected int tweenMode;

	[NonSerialized]
	private static Boo.Lang.List<QuestStartInfo> _InstanceList = new Boo.Lang.List<QuestStartInfo>();

	public static QuestStartInfo Instance
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

	public static void OpenQuestStartInfo(string place, string type, string name, string info)
	{
		IEnumerator<QuestStartInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestStartInfo current = enumerator.Current;
				current.__OpenQuestStartInfo(place, type, name, info);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __OpenQuestStartInfo(string place, string type, string name, string info)
	{
		if ((bool)window)
		{
			softFadePanel = GetComponent<UIPanel>();
			if ((bool)softFadePanel)
			{
				int height = Screen.height;
				Vector4 clipRange = softFadePanel.clipRange;
				float num = (clipRange.w = height);
				Vector4 vector2 = (softFadePanel.clipRange = clipRange);
				float y = (0f - softFadePanel.clipRange.w) * 0.5f - 20f;
				Vector4 clipRange2 = softFadePanel.clipRange;
				float num2 = (clipRange2.y = y);
				Vector4 vector4 = (softFadePanel.clipRange = clipRange2);
			}
			lastSceneName = SceneChanger.LastSceneName;
			window.gameObject.SetActive(value: false);
			Transform transform = window.transform.Find("TextPlace") as Transform;
			if ((bool)transform)
			{
				placeLabel = transform.GetComponent<UIDynamicFontLabel>();
			}
			Transform transform2 = window.transform.Find("TextQuestType") as Transform;
			if ((bool)transform2)
			{
				typeLabel = transform2.GetComponent<UIDynamicFontLabel>();
			}
			Transform transform3 = window.transform.Find("TextQuestTitle") as Transform;
			if ((bool)transform3)
			{
				nameLabel = transform3.GetComponent<UIDynamicFontLabel>();
			}
			Transform transform4 = window.transform.Find("TextQuestInfo") as Transform;
			if ((bool)transform4)
			{
				infoLabel = transform4.GetComponent<UIDynamicFontLabel>();
			}
			if ((bool)placeLabel)
			{
				placeLabel.Text = place;
			}
			if ((bool)typeLabel)
			{
				typeLabel.Text = type;
			}
			if ((bool)nameLabel)
			{
				nameLabel.Text = name;
			}
			if ((bool)infoLabel)
			{
				infoLabel.Text = info;
			}
			tweenMode = 1;
		}
	}

	public void Open()
	{
		if (!window)
		{
			return;
		}
		tweenMode = 0;
		window.gameObject.SetActive(value: true);
		if (!tween)
		{
			return;
		}
		tween.enabled = true;
		tween.delay = 0f;
		tween.Play(forward: true);
		tween.Reset();
		tweenMode = 2;
		tween.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(delegate
		{
			if (tweenMode == 2)
			{
				tweenMode = 3;
				tween.delay = delay;
				tween.Play(forward: false);
				tween.Reset();
			}
			else if (tweenMode == 3)
			{
				tweenMode = 0;
				window.gameObject.SetActive(value: false);
			}
		});
	}

	public void Start()
	{
		window.gameObject.SetActive(value: false);
		cutSceneMan = CutSceneManager.Instance;
	}

	public void Update()
	{
		if (tweenMode == 1 && lastSceneName != SceneChanger.CurrentSceneName)
		{
			lastSceneName = SceneChanger.CurrentSceneName;
			Open();
		}
		if ((bool)cutSceneMan && cutSceneMan.isBusy)
		{
			tweenMode = 0;
			window.gameObject.SetActive(value: false);
		}
	}

	internal void _0024Open_0024closure_00243783()
	{
		if (tweenMode == 2)
		{
			tweenMode = 3;
			tween.delay = delay;
			tween.Play(forward: false);
			tween.Reset();
		}
		else if (tweenMode == 3)
		{
			tweenMode = 0;
			window.gameObject.SetActive(value: false);
		}
	}
}
