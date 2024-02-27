using UnityEngine;

[ExecuteInEditMode]
public class IPNumberPicker : IPPickerLabelBase
{
	public int min;

	public int max = 9;

	public int step = 1;

	public int initValue;

	public string toStringFormat = "D2";

	public int CurrentValue { get; private set; }

	public void ResetPickerAtValue(int val)
	{
		int index = ValueToIndex(val);
		if (val < 0 || val >= _nbOfVirtualElements)
		{
			Debug.LogError("value out of picker range");
		}
		else
		{
			ResetPickerAtIndex(index);
		}
	}

	protected override int GetInitIndex()
	{
		return ValueToIndex(initValue);
	}

	protected override void UpdateCurrentValue()
	{
		CurrentValue = VirtualIndexToValue(_selectedIndex);
	}

	protected override void UpdateWidget(int widgetIndex, int contentIndex)
	{
		uiLabels[widgetIndex].text = VirtualIndexToValue(contentIndex).ToString(toStringFormat);
	}

	protected override void UpdateVirtualElementsCount()
	{
		_nbOfVirtualElements = (max - min) / step;
	}

	private int VirtualIndexToValue(int index)
	{
		return min + index * step;
	}

	private int ValueToIndex(int val)
	{
		return (val - min) / step;
	}
}
