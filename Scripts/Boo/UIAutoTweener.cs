using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class UIAutoTweener : MonoBehaviour
{
	[Serializable]
	public enum WhereFrom
	{
		left,
		top,
		right,
		bottom,
		free
	}

	public bool isStandAlone;

	public bool ignoreTimeScale;

	public bool ignoreDelayWithOut;

	public bool doPosition;

	public WhereFrom whereFrom;

	public float horizonPosition;

	public float verticalPosition;

	public float delay;

	public float duration;

	public UITweener.Method method;

	public bool doAlpha;

	public float alphaTo;

	public float alphaFrom;

	public float alphaDelay;

	public float alphaDuration;

	public UITweener.Method alphaMethod;

	public bool doScale;

	public Vector3 scaleTo;

	public Vector3 scaleFrom;

	public float scaleDelay;

	public float scaleDuration;

	public UITweener.Method scaleMethod;

	private UISituation situation;

	private float startTime;

	private float limitTime;

	private int finish_count;

	private int last_count;

	private int total_count;

	private UITweener[] m_tweens;

	private bool finished_initialize;

	[NonSerialized]
	public const float DefaultTweenPositionExitDurationFactor = 0.8f;

	[NonSerialized]
	public const float DefaultTweenScaleExitDurationFactor = 0.8f;

	[NonSerialized]
	public const float DefaultTweenAlphaExitDurationFactor = 0.3f;

	public float tweenPositionExitDurationFactor;

	public float tweenScaleExitDurationFactor;

	public float tweenAlphaExitDurationFactor;

	private bool nowfoward;

	public bool isPlayingAnimation => 0 < finish_count;

	public bool isNowEnd
	{
		get
		{
			bool num = 1 <= last_count;
			if (num)
			{
				num = finish_count == 0;
			}
			return num;
		}
	}

	private UITweener[] tweens => m_tweens;

	public bool nowForward => nowfoward;

	public int FinishCount => finish_count;

	public bool IsInit => finished_initialize;

	public UIAutoTweener()
	{
		doPosition = true;
		horizonPosition = 1400f;
		verticalPosition = 800f;
		duration = 0.3f;
		method = UITweener.Method.EaseInOut;
		alphaTo = 1f;
		alphaDuration = 0.3f;
		alphaMethod = UITweener.Method.EaseInOut;
		scaleTo = Vector3.one;
		scaleFrom = Vector3.zero;
		scaleDuration = 0.3f;
		scaleMethod = UITweener.Method.EaseInOut;
		tweenPositionExitDurationFactor = 0.8f;
		tweenScaleExitDurationFactor = 0.8f;
		tweenAlphaExitDurationFactor = 0.3f;
		nowfoward = true;
	}

	public void Start()
	{
		if (isStandAlone)
		{
			Initialize();
		}
	}

	public void Reset(UISituation s)
	{
		finished_initialize = false;
		RemoveAnimation();
		Initialize(s);
	}

	public void Initialize()
	{
		Initialize(null);
	}

	public void Initialize(UISituation s)
	{
		if (!Application.isPlaying || finished_initialize)
		{
			return;
		}
		UIPanel component = gameObject.GetComponent<UIPanel>();
		List<UITweener> list = new List<UITweener>();
		if (doPosition)
		{
			if ((bool)component && component.clipping != 0)
			{
				throw new AssertionFailedException("UIAutoTweener とクリッピングする UIPanel を付けないでください！！ : " + gameObject.name);
			}
			Vector3 localPosition = transform.localPosition;
			TweenPosition tweenPosition = TweenPosition.Begin(gameObject, duration, localPosition);
			tweenPosition.delay = delay;
			tweenPosition.method = method;
			tweenPosition.ignoreTimeScale = ignoreTimeScale;
			Vector3 from = default(Vector3);
			if (whereFrom == WhereFrom.left)
			{
				from = localPosition + new Vector3(0f - horizonPosition, 0f, 0f);
			}
			else if (whereFrom == WhereFrom.top)
			{
				from = localPosition + new Vector3(0f, verticalPosition, 0f);
			}
			else if (whereFrom == WhereFrom.right)
			{
				from = localPosition + new Vector3(horizonPosition, 0f, 0f);
			}
			else if (whereFrom == WhereFrom.bottom)
			{
				from = localPosition + new Vector3(0f, 0f - verticalPosition, 0f);
			}
			else if (whereFrom == WhereFrom.free)
			{
				from = new Vector3(horizonPosition, verticalPosition, 0f);
			}
			tweenPosition._from = from;
			list.Add(tweenPosition);
		}
		if (doAlpha)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(gameObject, alphaDuration, alphaTo);
			tweenAlpha._from = alphaFrom;
			tweenAlpha.delay = alphaDelay;
			tweenAlpha.method = alphaMethod;
			tweenAlpha.ignoreTimeScale = ignoreTimeScale;
			list.Add(tweenAlpha);
		}
		if (doScale)
		{
			TweenScale tweenScale = TweenScale.Begin(gameObject, scaleDuration, scaleTo);
			tweenScale._from = scaleFrom;
			tweenScale.delay = scaleDelay;
			tweenScale.method = scaleMethod;
			tweenScale.ignoreTimeScale = ignoreTimeScale;
			list.Add(tweenScale);
		}
		m_tweens = list.ToArray();
		if (!isStandAlone)
		{
			situation = ((!s) ? UISituation.Find(transform) : s);
			if ((bool)situation)
			{
				situation.forwardAnimationDelegateList += play_animation;
				situation.backAnimationDelegateList += play_animation;
				situation.stopAnimationDelegateList += stop_animation;
			}
			else
			{
				isStandAlone = true;
			}
		}
		finished_initialize = true;
	}

	public void RemoveAnimation()
	{
		if ((bool)situation)
		{
			situation.forwardAnimationDelegateList -= play_animation;
			situation.backAnimationDelegateList -= play_animation;
			situation.stopAnimationDelegateList -= stop_animation;
			situation.RemoveTweener(this);
		}
		int i = 0;
		UITweener[] components = GetComponents<UITweener>();
		for (int length = components.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.Destroy(components[i]);
		}
	}

	public void PlayForceAnimation(bool forward)
	{
		bool flag = isStandAlone;
		isStandAlone = true;
		play_animation(null, forward);
		isStandAlone = flag;
	}

	public void PlayAnimation(bool forward)
	{
		if (isStandAlone)
		{
			play_animation(null, forward);
		}
	}

	public void StopAnimation()
	{
		if (isStandAlone)
		{
			stop_animation(null);
		}
	}

	public void SetTargetPosition(Vector3 aTarget)
	{
		int num = 0;
		if (m_tweens != null)
		{
			num = m_tweens.Length;
		}
		TweenPosition tweenPosition = null;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			UITweener[] array = m_tweens;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] is TweenPosition)
			{
				UITweener[] array2 = m_tweens;
				tweenPosition = (TweenPosition)array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				break;
			}
		}
		if (tweenPosition == null)
		{
			tweenPosition = TweenPosition.Begin(gameObject, duration, aTarget);
			tweenPosition.delay = delay;
			tweenPosition.method = method;
			tweenPosition.ignoreTimeScale = ignoreTimeScale;
			List<UITweener> list = null;
			list.Add(tweenPosition);
			m_tweens = (UITweener[])Builtins.array(typeof(UITweener), list);
		}
		Vector3 from = default(Vector3);
		if (whereFrom == WhereFrom.left)
		{
			from = aTarget + new Vector3(0f - horizonPosition, 0f, 0f);
		}
		else if (whereFrom == WhereFrom.top)
		{
			from = aTarget + new Vector3(0f, verticalPosition, 0f);
		}
		else if (whereFrom == WhereFrom.right)
		{
			from = aTarget + new Vector3(horizonPosition, 0f, 0f);
		}
		else if (whereFrom == WhereFrom.bottom)
		{
			from = aTarget + new Vector3(0f, 0f - verticalPosition, 0f);
		}
		else if (whereFrom == WhereFrom.free)
		{
			from = new Vector3(horizonPosition, verticalPosition, 0f);
		}
		tweenPosition._from = from;
		tweenPosition.to = aTarget;
	}

	public void play_animation(UISituation sender, bool forward)
	{
		if (!finished_initialize)
		{
			throw new AssertionFailedException("UIAutoTweener が初期化されてないけどアニメ再生しようとしたよ！！");
		}
		nowfoward = forward;
		situation = sender;
		if (!isStandAlone)
		{
			situation.AddTweener(this);
		}
		last_count = (finish_count = 0);
		total_count = 0;
		if (tweens == null)
		{
			return;
		}
		int i = 0;
		UITweener[] array = tweens;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i] && array[i].gameObject.activeInHierarchy && array[i].style == UITweener.Style.Once)
				{
					finish_count++;
					array[i].ignoreDelayWithOut = ignoreDelayWithOut;
					if (array[i] is TweenAlpha)
					{
						array[i].duration = ((!forward) ? (alphaDuration * tweenAlphaExitDurationFactor) : alphaDuration);
					}
					if (array[i] is TweenScale)
					{
						array[i].duration = ((!forward) ? (scaleDuration * tweenScaleExitDurationFactor) : scaleDuration);
					}
					if (array[i] is TweenPosition)
					{
						array[i].duration = ((!forward) ? (duration * tweenPositionExitDurationFactor) : duration);
					}
					array[i].onFinished = delegate(UITweener tween)
					{
						tween.onFinished = null;
						finish_count--;
					};
					array[i].Play(forward);
					array[i].Reset();
				}
			}
			total_count = finish_count;
			if (!isStandAlone)
			{
				startTime = Time.timeSinceLevelLoad;
				limitTime = situation.GetLimit(forward);
			}
		}
	}

	public void stop_animation(UISituation sender)
	{
		if (tweens == null)
		{
			return;
		}
		int i = 0;
		UITweener[] array = tweens;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].enabled = false;
			}
		}
	}

	public void Update()
	{
		if (isPlayingAnimation && ((!(0f >= limitTime) && limitTime <= Time.timeSinceLevelLoad - startTime) || tweens == null || tweens.Length <= 0))
		{
			finish_count = 0;
		}
		if (last_count == finish_count)
		{
			return;
		}
		if (finish_count == 0)
		{
			if ((bool)situation)
			{
				situation.EndTweener(this);
			}
			situation = null;
		}
		last_count = finish_count;
	}

	internal void _0024play_animation_0024closure_00242943(UITweener tween)
	{
		tween.onFinished = null;
		checked
		{
			finish_count--;
		}
	}
}
