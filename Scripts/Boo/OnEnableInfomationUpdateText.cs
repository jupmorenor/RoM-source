using System;
using UnityEngine;

[Serializable]
public class OnEnableInfomationUpdateText : MonoBehaviour
{
	public string mTextMsg;

	public void OnEnable()
	{
		InfomationBarHUD.UpdateText(MTexts.Msg(mTextMsg));
	}
}
