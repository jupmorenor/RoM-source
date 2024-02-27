using System;
using UnityEngine;

[Serializable]
public class ResultShortcutWindow : MonoBehaviour
{
	public UILabelBase titleLabel;

	public UISprite retryIconSprite;

	public UILabelBase retryButtonLabel;

	public UIButtonMessage retryButton;

	public UILabelBase endButtonLabel;

	private UIBasicUtility.ButtonSet retryButtonSet;

	private void Start()
	{
		if (GameParameter.alwaysOpenResultShortcut)
		{
			UIBasicUtility.SetLabel(titleLabel, "※現在、全リザルトショートカットon", show: true);
			UIBasicUtility.SetLabelColor(titleLabel, Color.red);
		}
		else
		{
			UIBasicUtility.SetLabel(titleLabel, MTexts.Get("$RESULT_SHORTCUT_TITLE").ToString(), show: true);
		}
		UIBasicUtility.SetLabel(retryButtonLabel, MTexts.Get("$RESULT_SHORTCUT_RETRY").ToString(), show: true);
		UIBasicUtility.SetLabel(endButtonLabel, MTexts.Get("$RESULT_SHORTCUT_END").ToString(), show: true);
	}

	public void Init(ResultShortcut.IntoScene scene, bool valid)
	{
		switch (scene)
		{
		case ResultShortcut.IntoScene.Limited:
			UIBasicUtility.SetSprite(retryIconSprite, "icon_sp", null, show: true);
			break;
		case ResultShortcut.IntoScene.Grow:
			UIBasicUtility.SetSprite(retryIconSprite, "icon_training", null, show: true);
			break;
		case ResultShortcut.IntoScene.Challenge:
			UIBasicUtility.SetSprite(retryIconSprite, "icon_challenge", null, show: true);
			break;
		case ResultShortcut.IntoScene.Raid:
			UIBasicUtility.SetSprite(retryIconSprite, "icon_raid", null, show: true);
			break;
		case ResultShortcut.IntoScene.Colosseum:
			UIBasicUtility.SetSprite(retryIconSprite, "icon_colosseum", null, show: true);
			break;
		}
		if (retryButtonSet == null)
		{
			retryButtonSet = UIBasicUtility.CreateButtonSet(retryButton);
		}
		UIBasicUtility.SetButtonValid(retryButtonSet, valid);
		retryButtonSet.button.enabled = valid;
		retryButtonSet.button.collider.enabled = valid;
	}
}
