using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PickerPopper : MonoBehaviour
{
	public GameObject pickerColliderObject;

	public IPPickerBase picker;

	public UIWidget pickerBackground;

	public UIPanel cyclerPanel;

	public Vector2 openCloseScaleTweenDuration = new Vector2(1f, 1f);

	public Vector2 openCloseClippingTweenDuration = new Vector2(1.2f, 0.8f);

	public UIWidget widgetForBlinkConfirmation;

	public Color blinkColor;

	public float confirmBlinkDuration;

	public GameObject notifyWhenCollapsing;

	public string message = "OnPickerCollapsed";

	private UIDragPanelContents _dragContents;

	private IPUserInteraction _pickerInteraction;

	private IPCycler _cycler;

	private TweenPanelClipRange _clipRangeTween;

	private TweenPanelClipSoftness _softnessTween;

	private TweenScale _scaleTween;

	private BoxCollider _pickerCollider;

	private BoxCollider _thisCollider;

	private bool _waitBeforeClosing;

	private bool _clippingIsTweening;

	private Color _initBlinkColor;

	private void Start()
	{
		if (widgetForBlinkConfirmation != null)
		{
			_initBlinkColor = widgetForBlinkConfirmation.color;
		}
		_cycler = cyclerPanel.gameObject.GetComponent(typeof(IPCycler)) as IPCycler;
		_dragContents = pickerColliderObject.GetComponent(typeof(UIDragPanelContents)) as UIDragPanelContents;
		_pickerInteraction = pickerColliderObject.GetComponent(typeof(IPUserInteraction)) as IPUserInteraction;
		_pickerCollider = pickerColliderObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
		_thisCollider = base.gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
		_clipRangeTween = cyclerPanel.gameObject.GetComponent(typeof(TweenPanelClipRange)) as TweenPanelClipRange;
		_softnessTween = cyclerPanel.gameObject.GetComponent(typeof(TweenPanelClipSoftness)) as TweenPanelClipSoftness;
		_scaleTween = pickerBackground.gameObject.GetComponent(typeof(TweenScale)) as TweenScale;
		cyclerPanel.clipRange = _clipRangeTween.from;
		cyclerPanel.clipSoftness = _softnessTween.from;
		_cycler.UpdateResetClipRange(_clipRangeTween.from);
		pickerBackground.cachedTransform.localScale = _scaleTween.from;
		_dragContents.enabled = false;
		_pickerCollider.enabled = false;
	}

	public IEnumerator OpenPicker()
	{
		_thisCollider.enabled = false;
		_scaleTween.duration = openCloseScaleTweenDuration.x;
		_scaleTween.Play(forward: true);
		_clipRangeTween.onFinished = OnTweenClipRangeFinished;
		_clippingIsTweening = true;
		_clipRangeTween.duration = openCloseClippingTweenDuration.x;
		_clipRangeTween.Play(forward: true);
		if (_softnessTween != null)
		{
			_softnessTween.duration = openCloseClippingTweenDuration.x;
			_softnessTween.Play(forward: true);
		}
		while (_clippingIsTweening)
		{
			yield return null;
		}
		_dragContents.enabled = true;
		_pickerCollider.enabled = true;
		IPUserInteraction pickerInteraction = _pickerInteraction;
		pickerInteraction.onPickerClicked = (IPUserInteraction.PickerClickedHandler)Delegate.Combine(pickerInteraction.onPickerClicked, new IPUserInteraction.PickerClickedHandler(PickerClicked));
		IPCycler cycler = _cycler;
		cycler.onCyclerSelectionStarted = (IPCycler.SelectionStartedHandler)Delegate.Combine(cycler.onCyclerSelectionStarted, new IPCycler.SelectionStartedHandler(OnPickerSelectionStarted));
		_cycler.UpdateResetClipRange(_clipRangeTween.to);
		IPCycler cycler2 = _cycler;
		cycler2.onCyclerStopped = (IPCycler.CyclerStoppedHandler)Delegate.Combine(cycler2.onCyclerStopped, new IPCycler.CyclerStoppedHandler(OnPickerStopped));
	}

	public IEnumerator ClosePicker()
	{
		_pickerCollider.enabled = false;
		_dragContents.enabled = false;
		IPUserInteraction pickerInteraction = _pickerInteraction;
		pickerInteraction.onPickerClicked = (IPUserInteraction.PickerClickedHandler)Delegate.Remove(pickerInteraction.onPickerClicked, new IPUserInteraction.PickerClickedHandler(PickerClicked));
		if (widgetForBlinkConfirmation != null)
		{
			StartCoroutine(BlinkWidget(2));
		}
		while (_waitBeforeClosing)
		{
			yield return null;
		}
		yield return null;
		picker.ResetPicker();
		_cycler.UpdateResetClipRange(_clipRangeTween.from);
		IPCycler cycler = _cycler;
		cycler.onCyclerSelectionStarted = (IPCycler.SelectionStartedHandler)Delegate.Remove(cycler.onCyclerSelectionStarted, new IPCycler.SelectionStartedHandler(OnPickerSelectionStarted));
		IPCycler cycler2 = _cycler;
		cycler2.onCyclerStopped = (IPCycler.CyclerStoppedHandler)Delegate.Remove(cycler2.onCyclerStopped, new IPCycler.CyclerStoppedHandler(OnPickerStopped));
		_thisCollider.enabled = true;
		_scaleTween.duration = openCloseScaleTweenDuration.y;
		_scaleTween.Play(forward: false);
		_clipRangeTween.duration = openCloseClippingTweenDuration.y;
		_clipRangeTween.Play(forward: false);
		if (_softnessTween != null)
		{
			_softnessTween.duration = openCloseClippingTweenDuration.y;
			_softnessTween.Play(forward: false);
		}
	}

	private void OnClick()
	{
		StartCoroutine(OpenPicker());
	}

	private void PickerClicked()
	{
		StartCoroutine(ClosePicker());
		if (notifyWhenCollapsing != null)
		{
			notifyWhenCollapsing.SendMessage(message);
		}
	}

	private void OnPickerSelectionStarted()
	{
		_waitBeforeClosing = true;
	}

	private void OnPickerStopped()
	{
		_waitBeforeClosing = false;
	}

	private void OnTweenClipRangeFinished(UITweener tweener)
	{
		_clippingIsTweening = false;
	}

	private IEnumerator BlinkWidget(int nbOfBlinks)
	{
		for (int i = 0; i < nbOfBlinks; i++)
		{
			yield return StartCoroutine(LerpBackgroundColor(blinkColor, confirmBlinkDuration / 2f));
			yield return StartCoroutine(LerpBackgroundColor(_initBlinkColor, confirmBlinkDuration / 2f));
		}
	}

	private IEnumerator LerpBackgroundColor(Color targetColor, float duration)
	{
		Color initValue = widgetForBlinkConfirmation.color;
		float i = 0f;
		float rate = 1f / duration;
		while (i < 1f)
		{
			i += Time.deltaTime * rate;
			widgetForBlinkConfirmation.color = Color.Lerp(initValue, targetColor, i);
			yield return null;
		}
	}
}
