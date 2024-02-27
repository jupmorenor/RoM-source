using System;
using UnityEngine;

[Serializable]
public class Ui_TownBlacksmith_Cam : MonoBehaviour
{
	public void Start()
	{
		animation.Play("Ui_TownBlacksmith_Cam_s");
		animation.PlayQueued("Ui_TownBlacksmith_Cam_l");
	}
}
