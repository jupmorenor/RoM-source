using UnityEngine;

public abstract class IPPickerDynamicFontLabelBase : IPPickerBase
{
	public Font font;

	[SerializeField]
	protected UIDynamicFontLabel[] uiLabels;

	public override UIWidget GetCenterWidget()
	{
		return uiLabels[cycler.CenterWidgetIndex];
	}

	protected override void InitWidgets()
	{
		for (int i = 0; i < uiLabels.Length; i++)
		{
			uiLabels[i].Font = font;
			uiLabels[i].color = widgetsColor;
			uiLabels[i].pivot = widgetsPivot;
			uiLabels[i].cachedTransform.localPosition = widgetOffsetInPicker;
		}
	}

	protected override void MakeWidgetComponents()
	{
		uiLabels = cycler.MakeWidgets<UIDynamicFontLabel>();
		_nbOfWidgets = uiLabels.Length;
	}
}
