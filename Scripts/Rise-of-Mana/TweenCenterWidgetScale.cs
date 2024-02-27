using System.Collections;
using AnimationOrTween;
using UnityEngine;

public class TweenCenterWidgetScale : MonoBehaviour
{
	public float scaleFactor = 1.3f;

	public float duration = 0.3f;

	public UITweener.Method tweenMethod;

	public IPPickerBase _picker;

	private TweenScale _tweenScale;

	private UIWidget _centerWidget;

	private void OnSelectionStart()
	{
		if (!(_tweenScale == null))
		{
			StartCoroutine(StopTweenOnDirection());
		}
	}

	private IEnumerator StopTweenOnDirection()
	{
		while (_tweenScale.direction == Direction.Forward)
		{
			yield return null;
		}
		_tweenScale.style = UITweener.Style.Once;
	}

	private void OnPickerStopped()
	{
		_centerWidget = _picker.GetCenterWidget();
		GetOrAddTweener();
		_tweenScale.from = _centerWidget.cachedTransform.localScale;
		_tweenScale.to = _tweenScale.from * scaleFactor;
		_tweenScale.Play(forward: true);
	}

	private void GetOrAddTweener()
	{
		_tweenScale = _centerWidget.gameObject.GetComponent(typeof(TweenScale)) as TweenScale;
		if (_tweenScale == null)
		{
			_tweenScale = _centerWidget.gameObject.AddComponent(typeof(TweenScale)) as TweenScale;
			_tweenScale.duration = duration;
			_tweenScale.method = tweenMethod;
		}
		_tweenScale.style = UITweener.Style.PingPong;
	}
}
