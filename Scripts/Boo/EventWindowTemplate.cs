using System;
using UnityEngine;

[Serializable]
public class EventWindowTemplate : MonoBehaviour
{
	public GameObject textRoot;

	public UIDynamicFontLabel title;

	public UIDynamicFontLabel message;

	public UIButtonMessage pushWindow;

	public UIButtonMessage closeButton;

	public UIButtonMessage nextButton;

	public Animation shakeAnim;

	public GameObject chrRoot;

	public GameObject chr1Anchor;

	public GameObject chr2Anchor;
}
