using System;
using UnityEngine;

[Serializable]
public class TutorialArrow : MonoBehaviour
{
	public UISprite sprite;

	public GameObject target;

	public Vector3 offset;

	public UISprite arrowSprite => (!(sprite != null)) ? GetComponent<UISprite>() : sprite;

	public void enableArrowSprite(bool b)
	{
		UISprite uISprite = arrowSprite;
		if (!(uISprite == null))
		{
			uISprite.enabled = b;
		}
	}

	public void Start()
	{
		enableArrowSprite(b: false);
	}
}
