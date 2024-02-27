using UnityEngine;

public abstract class IPPickerLabelBase : IPPickerBase
{
	public UIFont font;

	[SerializeField]
	protected UILabel[] uiLabels;

	public override UIWidget GetCenterWidget()
	{
		return uiLabels[cycler.CenterWidgetIndex];
	}

	protected override void InitWidgets()
	{
		for (int i = 0; i < uiLabels.Length; i++)
		{
			uiLabels[i].font = font;
			uiLabels[i].MakePixelPerfect();
			uiLabels[i].color = widgetsColor;
			uiLabels[i].pivot = widgetsPivot;
			uiLabels[i].cachedTransform.localPosition = widgetOffsetInPicker;
		}
	}

	protected override void MakeWidgetComponents()
	{
		uiLabels = cycler.MakeWidgets<UILabel>();
		_nbOfWidgets = uiLabels.Length;
	}
}
