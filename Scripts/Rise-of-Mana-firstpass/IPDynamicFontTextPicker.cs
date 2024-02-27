using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class IPDynamicFontTextPicker : IPPickerDynamicFontLabelBase
{
	public List<string> labelsText;

	private List<Color> colors;

	public int initIndex;

	public string CurrentLabelText { get; private set; }

	public int SelectedIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			ResetPickerAtIndex(value);
		}
	}

	public void InsertElement(string text)
	{
		PrepareColors();
		labelsText.Insert(_selectedIndex, text);
		colors.Insert(_selectedIndex, widgetsColor);
		_nbOfVirtualElements++;
		ResetPickerAtIndex(_selectedIndex);
	}

	public void RemoveElementAtIndex(int index)
	{
		if (_nbOfVirtualElements != 1)
		{
			PrepareColors();
			colors.RemoveAt(index);
			labelsText.RemoveAt(index);
			_nbOfVirtualElements--;
			ResetPickerAtIndex(IPTools.GetSelectedIndexAfterRemoveElement(index, _selectedIndex, _nbOfVirtualElements));
		}
	}

	public void ReplaceElements(string[] elements)
	{
		Debug.Log("ReplaceElements.0");
		colors = null;
		labelsText = null;
		_nbOfVirtualElements = 0;
		labelsText = new List<string>();
		int num = 0;
		foreach (string item in elements)
		{
			labelsText.Add(item);
			num++;
		}
		PrepareColors();
		UpdateVirtualElementsCount();
		ResetPicker();
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

	private void PrepareColors()
	{
		if (colors == null)
		{
			colors = new List<Color>();
			for (int i = 0; i < labelsText.Count; i++)
			{
				colors.Add(widgetsColor);
			}
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
		PrepareColors();
		uiLabels[widgetIndex].color = colors[contentIndex];
	}

	protected override void UpdateVirtualElementsCount()
	{
		_nbOfVirtualElements = labelsText.Count;
	}

	public void UpdateColor(int index, Color color)
	{
		PrepareColors();
		colors[index] = color;
		ResetPicker();
	}

	public void ResetColor(int index)
	{
		UpdateColor(index, widgetsColor);
	}

	public Color GetColor(int index)
	{
		PrepareColors();
		return colors[index];
	}
}
