using System;

[Serializable]
public class ManaPieceListItem : UIListItem
{
	public UILabelBase textTitleLabel;

	public UILabelBase textBodyLabel;

	public UILabelBase textCostLabel;

	public UILabelBase textDateLimitLabel;

	public UILabelBase textItemLabel;

	public UIWidget newIcon;

	public UIButtonMessage acceptButton;

	public void Update()
	{
		UIAutoTweener component = gameObject.GetComponent<UIAutoTweener>();
		TweenPosition component2 = gameObject.GetComponent<TweenPosition>();
		if ((bool)component2 && (bool)component)
		{
			component2.Sample(component2.tweenFactor, isFinished: false);
		}
	}
}
