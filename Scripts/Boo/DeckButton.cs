using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class DeckButton : MonoBehaviour
{
	public UIButtonMessage leftDeckButton;

	public UIButtonMessage rigthDeckButton;

	protected UIValidController leftButtonValidCtrl;

	protected UIValidController rightButtonValidCtrl;

	public UISprite deckIndexNumber;

	protected string deckIndexNumberName;

	public UISprite deckButtonSprite;

	protected string[] deckButtonSpriteName;

	public bool loop;

	protected bool init;

	public DeckButton()
	{
		deckIndexNumberName = "deck_num0{0}";
		deckButtonSpriteName = new string[5] { "button06", "button08", "button07", "button09", "button05" };
		loop = true;
	}

	public void Init()
	{
		if (!init)
		{
			init = true;
			leftButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(leftDeckButton.gameObject);
			rightButtonValidCtrl = ExtensionsModule.SetComponent<UIValidController>(rigthDeckButton.gameObject);
		}
	}

	public void Start()
	{
		Init();
	}

	public void Update()
	{
	}

	public void UpdateDeckButton(int index)
	{
		Init();
		if ((bool)deckIndexNumber)
		{
			deckIndexNumber.spriteName = string.Format(deckIndexNumberName, checked(index + 1));
		}
		UISprite uISprite = deckIndexNumber;
		Color[] deckNumberColors = MyHomeEquipMain.DeckNumberColors;
		uISprite.color = deckNumberColors[RuntimeServices.NormalizeArrayIndex(deckNumberColors, index)];
		UISprite uISprite2 = deckButtonSprite;
		string[] array = deckButtonSpriteName;
		uISprite2.spriteName = array[RuntimeServices.NormalizeArrayIndex(array, index)];
		if (!loop)
		{
			if ((bool)leftButtonValidCtrl)
			{
				leftButtonValidCtrl.isValidColor = index > 0;
			}
			if ((bool)rightButtonValidCtrl)
			{
				rightButtonValidCtrl.isValidColor = index < 4;
			}
		}
	}
}
