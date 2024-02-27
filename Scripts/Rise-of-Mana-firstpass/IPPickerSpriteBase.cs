using UnityEngine;

public abstract class IPPickerSpriteBase : IPPickerBase
{
	public UIAtlas atlas;

	[SerializeField]
	protected UISprite[] uiSprites;

	public override UIWidget GetCenterWidget()
	{
		return uiSprites[cycler.CenterWidgetIndex];
	}

	protected override void InitWidgets()
	{
		for (int i = 0; i < uiSprites.Length; i++)
		{
			uiSprites[i].atlas = atlas;
			uiSprites[i].color = widgetsColor;
			uiSprites[i].pivot = widgetsPivot;
			uiSprites[i].cachedTransform.localPosition = widgetOffsetInPicker;
		}
	}

	protected override void MakeWidgetComponents()
	{
		uiSprites = cycler.MakeWidgets<UISprite>();
		_nbOfWidgets = uiSprites.Length;
	}
}
