using UnityEngine;

public class TweenPanelClipSoftness : UITweener
{
	public Vector2 from;

	public Vector2 to;

	private UIPanel _panel;

	private void Awake()
	{
		_panel = base.gameObject.GetComponent(typeof(UIPanel)) as UIPanel;
		if (_panel == null)
		{
			Debug.LogError("TweenPanelClipRange needs a UIPanel!");
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		_panel.clipSoftness = from * (1f - factor) + to * factor;
	}

	public static TweenScale Begin(GameObject go, float duration, Vector3 scale)
	{
		TweenScale tweenScale = UITweener.Begin<TweenScale>(go, duration);
		tweenScale.from = tweenScale.scale;
		tweenScale.to = scale;
		if (duration <= 0f)
		{
			tweenScale.Sample(1f, isFinished: true);
			tweenScale.enabled = false;
		}
		return tweenScale;
	}
}
