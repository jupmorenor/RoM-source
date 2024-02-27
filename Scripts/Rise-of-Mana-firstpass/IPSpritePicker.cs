using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class IPSpritePicker : IPPickerSpriteBase
{
	public List<string> spriteNames;

	public bool normalzeSprites = true;

	public float normalizedMax = 50f;

	public int initIndex;

	public string CurrentSpriteName { get; private set; }

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

	public void InsertElement(string spriteName)
	{
		spriteNames.Insert(_selectedIndex, spriteName);
		_nbOfVirtualElements++;
		ResetPickerAtIndex(_selectedIndex);
	}

	public void RemoveElementAtIndex(int index)
	{
		if (_nbOfVirtualElements != 1)
		{
			spriteNames.RemoveAt(index);
			_nbOfVirtualElements--;
			ResetPickerAtIndex(IPTools.GetSelectedIndexAfterRemoveElement(index, _selectedIndex, _nbOfVirtualElements));
		}
	}

	protected override int GetInitIndex()
	{
		return initIndex;
	}

	protected override void UpdateCurrentValue()
	{
		CurrentSpriteName = spriteNames[_selectedIndex];
	}

	protected override void UpdateWidget(int widgetIndex, int contentIndex)
	{
		uiSprites[widgetIndex].spriteName = spriteNames[contentIndex];
		IPTools.NormalizeSprite(uiSprites[widgetIndex], normalizedMax);
	}

	protected override void UpdateVirtualElementsCount()
	{
		_nbOfVirtualElements = spriteNames.Count;
	}
}
