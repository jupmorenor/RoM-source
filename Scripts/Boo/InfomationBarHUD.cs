using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class InfomationBarHUD : MonoBehaviour
{
	public UILabelBase infomationLabel;

	private string cacheText;

	private GameObject target;

	public Vector3 target_from;

	private UITweener tween1st;

	private UITweener tween2nd;

	[NonSerialized]
	private static InfomationBarHUD instance;

	public string text
	{
		get
		{
			return infomationLabel.text;
		}
		set
		{
			infomationLabel.text = value;
			Refresh();
		}
	}

	public InfomationBarHUD()
	{
		target_from = new Vector3(-600f, 0f);
	}

	public static void SetActive(bool a)
	{
		InfomationBarHUD infomationBarHUD = Instance();
		if ((bool)infomationBarHUD)
		{
			infomationBarHUD.gameObject.SetActive(a);
		}
	}

	public static InfomationBarHUD Instance()
	{
		if (!instance)
		{
			instance = (InfomationBarHUD)UnityEngine.Object.FindObjectOfType(typeof(InfomationBarHUD));
		}
		return instance;
	}

	public static void UpdateText(string text)
	{
		InfomationBarHUD infomationBarHUD = Instance();
		if ((bool)infomationBarHUD)
		{
			infomationBarHUD.text = text;
			infomationBarHUD.StartTween();
		}
	}

	public void Awake()
	{
		if (!(infomationLabel != null))
		{
			throw new AssertionFailedException("dont attach the infomation label!!");
		}
		target = infomationLabel.gameObject;
	}

	private void Update()
	{
		if (infomationLabel.text != cacheText)
		{
			cacheText = infomationLabel.text;
			Refresh();
		}
	}

	public void Refresh()
	{
		UIDynamicFontLabel uIDynamicFontLabel = infomationLabel as UIDynamicFontLabel;
		uIDynamicFontLabel.UpdateLabel();
	}

	public void StartTween()
	{
		UnityEngine.Object.Destroy(tween1st);
		tween1st = null;
		UnityEngine.Object.Destroy(tween2nd);
		tween2nd = null;
		TextTween1st();
	}

	public void TextTween1st()
	{
		start_tween(ref tween1st, UITweener.Method.EaseOut, 0.1f, 0.5f, "TextTween2nd", target_from, Vector3.zero);
	}

	public void TextTween2nd()
	{
		float num = infomationLabel.relativeSize.x + 50f;
		start_tween(ref tween2nd, UITweener.Method.Linear, 2f, num * 0.01f, "TextTween1st", Vector3.zero, new Vector3(0f - num, 0f, 0f));
	}

	private void start_tween(ref UITweener tweenref, UITweener.Method type, float dly, float dur, string cb, Vector3 _from, Vector3 _to)
	{
		if (target != null)
		{
			TweenPosition tweenPosition = (TweenPosition)tweenref;
			if (!tweenPosition)
			{
				tweenPosition = (TweenPosition)target.AddComponent(typeof(TweenPosition));
				tweenPosition.method = type;
				tweenPosition.style = UITweener.Style.Once;
				tweenPosition.delay = dly;
				tweenPosition.duration = dur;
				tweenPosition.eventReceiver = gameObject;
				tweenPosition.callWhenFinished = cb;
				tweenPosition._from = _from;
				tweenPosition.to = _to;
				tweenref = tweenPosition;
			}
			tweenPosition.Play(forward: true);
			tweenPosition.Reset();
		}
	}
}
