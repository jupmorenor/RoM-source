using UnityEngine;

[AddComponentMenu("NGUI/Tween/Position")]
public class TweenPosition : UITweener
{
	public Vector3 from;

	public Vector3 to;

	private Transform mTrans;

	public Vector3 From
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

	public Vector3 _from
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

	public Transform cachedTransform
	{
		get
		{
			if (mTrans == null)
			{
				mTrans = base.transform;
			}
			return mTrans;
		}
	}

	public Vector3 position
	{
		get
		{
			return cachedTransform.localPosition;
		}
		set
		{
			cachedTransform.localPosition = value;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (!Application.isPlaying && mTrans == null)
		{
			from = base.transform.localPosition;
			to = base.transform.localPosition;
			to.y -= 100f;
		}
		cachedTransform.localPosition = from * (1f - factor) + to * factor;
	}

	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
		tweenPosition.from = tweenPosition.position;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, isFinished: true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}
}
