using UnityEngine;

public class PickerScrollButton : MonoBehaviour
{
	public enum ScrollDirection
	{
		Increase,
		Decrease
	}

	public IPCycler targetCycler;

	public float scrollSpeed = 1f;

	public ScrollDirection scrollDirection;

	private bool _pressed;

	private void Awake()
	{
		if (targetCycler == null)
		{
			Debug.LogError("PickerScrollButton needs a target picker ( component type : WidgetPicker ) ");
			return;
		}
		scrollSpeed = Mathf.Abs(scrollSpeed);
		if (targetCycler.direction == IPCycler.Direction.Horizontal)
		{
			if (scrollDirection == ScrollDirection.Decrease)
			{
				scrollSpeed = 0f - scrollSpeed;
			}
		}
		else if (scrollDirection == ScrollDirection.Increase)
		{
			scrollSpeed = 0f - scrollSpeed;
		}
	}

	private void OnPress(bool press)
	{
		_pressed = press;
		if (!press)
		{
			targetCycler.CenterOnChild();
		}
	}

	private void OnClick()
	{
		if (scrollDirection == ScrollDirection.Increase)
		{
			targetCycler.AutoScrollToNextElement();
		}
		else
		{
			targetCycler.AutoScrollToPreviousElement();
		}
	}

	private void Update()
	{
		if (_pressed)
		{
			targetCycler.Scroll(scrollSpeed);
		}
	}
}
