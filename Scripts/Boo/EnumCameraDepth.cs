using System;
using UnityEngine;

[Serializable]
public class EnumCameraDepth : MonoBehaviour
{
	[Serializable]
	public enum Depth
	{
		Min = -100,
		Main3DCamera = -5,
		Mask3D = -4,
		_3d = 0,
		FilterOf3D = 2,
		Ui = 5,
		TutorialUI = 8,
		EventWindowChr = 15,
		EventWindow = 16,
		Info = 20,
		GameSystemMessage = 21,
		Error = 30,
		ScreenMask = 40,
		Renkei3D = 45,
		RenkeiLogo = 46,
		Pasue = 50,
		Fader = 80,
		SystemError = 90,
		ColorCorrection = 99,
		Max = 100
	}
}
