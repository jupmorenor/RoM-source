using UnityEngine;

public class TweenCenterWidgetScaleAndAlpha : MonoBehaviour
{
	public IPPickerBase picker;

	public float scaleFactor;

	public float duration;

	private TweenScale scaleTween;

	private TweenAlpha alphaTween;

	private UIWidget currentWidget;

	private void Grow()
	{
		currentWidget = picker.GetCenterWidget();
		scaleTween = currentWidget.gameObject.GetComponent(typeof(TweenScale)) as TweenScale;
		if (scaleTween == null)
		{
			AddTweeners();
		}
		else
		{
			alphaTween = currentWidget.gameObject.GetComponent(typeof(TweenAlpha)) as TweenAlpha;
		}
		scaleTween.Play(forward: true);
		alphaTween.Play(forward: true);
	}

	private void Shrink()
	{
		scaleTween.Play(forward: false);
		alphaTween.Play(forward: false);
	}

	private void AddTweeners()
	{
		scaleTween = currentWidget.gameObject.AddComponent(typeof(TweenScale)) as TweenScale;
		alphaTween = currentWidget.gameObject.AddComponent(typeof(TweenAlpha)) as TweenAlpha;
		scaleTween.from = currentWidget.cachedTransform.localScale;
		scaleTween.to = new Vector3(currentWidget.cachedTransform.localScale.x * scaleFactor, currentWidget.cachedTransform.localScale.y * scaleFactor, currentWidget.cachedTransform.localScale.z);
		scaleTween.duration = duration;
		alphaTween.to = 1f;
		alphaTween.from = currentWidget.alpha;
		alphaTween.duration = duration;
	}
}
