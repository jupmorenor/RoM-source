using UnityEngine;

[AddComponentMenu("NGUI/Tween/Alpha")]
public class TweenAlpha : UITweener
{
	public float from = 1f;

	public float to = 1f;

	private Transform mTrans;

	private UIPanelAlpha mPanelAlpha;

	public float _from
	{
		get
		{
			return from;
		}
		set
		{
			from = value;
		}
	}

	public float alpha
	{
		get
		{
			if (mPanelAlpha != null)
			{
				return mPanelAlpha.alpha;
			}
			return 0f;
		}
		set
		{
			if (mPanelAlpha != null)
			{
				mPanelAlpha.alpha = value;
			}
		}
	}

	private void Awake()
	{
		mPanelAlpha = GetComponent<UIPanelAlpha>();
		if (mPanelAlpha == null)
		{
			mPanelAlpha = base.gameObject.AddComponent<UIPanelAlpha>();
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		alpha = Mathf.Lerp(from, to, factor);
	}

	public static TweenAlpha Begin(GameObject go, float duration, float alpha)
	{
		TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration);
		tweenAlpha.from = tweenAlpha.alpha;
		tweenAlpha.to = alpha;
		if (duration <= 0f)
		{
			tweenAlpha.Sample(1f, isFinished: true);
			tweenAlpha.enabled = false;
		}
		return tweenAlpha;
	}

	public void Sync(TweenAlpha sync)
	{
		from = sync.from;
		to = sync.to;
		alpha = sync.alpha;
		Sync((UITweener)sync);
	}
}
