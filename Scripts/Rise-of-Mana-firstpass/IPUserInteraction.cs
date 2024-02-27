using System;
using UnityEngine;

public class IPUserInteraction : MonoBehaviour
{
	public delegate void PickerClickedHandler();

	public IPCycler cycler;

	private bool _isScrolling;

	private bool _isPressed;

	public PickerClickedHandler onPickerClicked;

	private void OnPress(bool press)
	{
		if (_isPressed != press)
		{
			cycler.OnPress(press);
			_isPressed = press;
		}
	}

	private void OnScroll(float delta)
	{
		if (!_isScrolling)
		{
			ScrollWheelEvents.onScrollStartOrStop = (ScrollWheelEvents.ScrollStartStopHandler)Delegate.Combine(ScrollWheelEvents.onScrollStartOrStop, new ScrollWheelEvents.ScrollStartStopHandler(ScrollStartOrStop));
			_isScrolling = true;
		}
	}

	private void ScrollStartOrStop(bool start)
	{
		if (!start)
		{
			ScrollWheelEvents.onScrollStartOrStop = (ScrollWheelEvents.ScrollStartStopHandler)Delegate.Remove(ScrollWheelEvents.onScrollStartOrStop, new ScrollWheelEvents.ScrollStartStopHandler(ScrollStartOrStop));
			_isScrolling = false;
		}
		cycler.ScrollWheelStartOrStop(start);
	}

	private void OnClick()
	{
		if (onPickerClicked != null)
		{
			onPickerClicked();
		}
	}
}
