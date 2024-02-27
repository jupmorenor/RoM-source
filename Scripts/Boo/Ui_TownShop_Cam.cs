using System;
using UnityEngine;

[Serializable]
public class Ui_TownShop_Cam : MonoBehaviour
{
	public void Start()
	{
		animation.Play("Ui_TownShop_Cam_s");
		animation.PlayQueued("Ui_TownShop_Cam_l");
	}
}
