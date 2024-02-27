using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class IPTextPicker : IPPickerLabelBase
{
	public List<string> labelsText;

	public int initIndex;

	public string CurrentLabelText { get; private set; }

	public void InsertElement(string text)
	{
		labelsText.Insert(_selectedIndex, text);
		_nbOfVirtualElements++;
		ResetPickerAtIndex(_selectedIndex);
	}

	public void RemoveElementAtIndex(int index)
	{
		if (_nbOfVirtualElements != 1)
		{
			labelsText.RemoveAt(index);
			_nbOfVirtualElements--;
			ResetPickerAtIndex(IPTools.GetSelectedIndexAfterRemoveElement(index, _selectedIndex, _nbOfVirtualElements));
		}
	}

	public void ResetPickerAtText(string labelText)
	{
		int num = labelsText.IndexOf(labelText);
		if (num < 0)
		{
			Debug.LogError("string not in picker");
		}
		else
		{
			ResetPickerAtIndex(num);
		}
	}

	public void ResetPickerAtContentIndex(int index)
	{
		if (index < 0 || index >= _nbOfVirtualElements)
		{
			Debug.LogError("Index out of range!");
		}
		else
		{
			ResetPickerAtIndex(index);
		}
	}

	protected override int GetInitIndex()
	{
		return initIndex;
	}

	protected override void UpdateCurrentValue()
	{
		CurrentLabelText = labelsText[_selectedIndex];
	}

	protected override void UpdateWidget(int widgetIndex, int contentIndex)
	{
		uiLabels[widgetIndex].text = labelsText[contentIndex];
	}

	protected override void UpdateVirtualElementsCount()
	{
		_nbOfVirtualElements = labelsText.Count;
	}
}
