using System;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class TutorialText : MonoBehaviour
{
	public GameObject TextBox;

	public UIDynamicFontLabel TextLabel;

	private Vector2 initTextBoxPos;

	private readonly float ANIMATION_SCALE;

	private readonly float ANIMATION_TIME;

	public string Text
	{
		get
		{
			return (!(TextLabel != null)) ? string.Empty : TextLabel.m_Text;
		}
		set
		{
			if (TextLabel != null)
			{
				TextLabel.m_Text = value;
			}
		}
	}

	public TutorialText()
	{
		ANIMATION_SCALE = 1.4f;
		ANIMATION_TIME = 1f;
	}

	public void Awake()
	{
		initTextBoxPos.x = TextBox.transform.localPosition.x;
		initTextBoxPos.y = TextBox.transform.localPosition.y;
	}

	public static TutorialText Create()
	{
		UnityEngine.Object @object = GameAssetModule.LoadPrefab("Prefab/GUI/TutorialText");
		if (!(@object != null))
		{
			throw new AssertionFailedException("TutorialTextがないよ");
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("TutorialTextをInstantiateできなかった");
		}
		return ExtensionsModule.SetComponent<TutorialText>(gameObject);
	}

	public void startBigSizeAnimation()
	{
		iTween.ScaleTo(TextBox.gameObject, iTween.Hash("x", ANIMATION_SCALE, "y", ANIMATION_SCALE, "time", ANIMATION_TIME, "oncompletetarget", gameObject, "oncomplete", "startNormalSizeAnimation"));
		float num = initTextBoxPos.x * ANIMATION_SCALE;
		float num2 = initTextBoxPos.y * ANIMATION_SCALE;
		iTween.MoveTo(TextBox.gameObject, iTween.Hash("islocal", true, "x", num, "y", num2, "time", ANIMATION_TIME));
	}

	protected void startNormalSizeAnimation()
	{
		iTween.ScaleTo(TextBox.gameObject, iTween.Hash("x", 1, "y", 1, "time", ANIMATION_TIME));
		iTween.MoveTo(TextBox.gameObject, iTween.Hash("islocal", true, "x", initTextBoxPos.x, "y", initTextBoxPos.y, "time", 1f));
	}
}
