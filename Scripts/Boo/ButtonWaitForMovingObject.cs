using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ButtonWaitForMovingObject : MonoBehaviour
{
	public Transform[] checkObjectList;

	private Matrix4x4[] lastMatrix;

	private UIButtonMessage buttonMessage;

	private UIButton uiButton;

	public void Start()
	{
		buttonMessage = gameObject.GetComponent<UIButtonMessage>();
		uiButton = gameObject.GetComponent<UIButton>();
		if (checkObjectList != null)
		{
			int length = checkObjectList.Length;
			lastMatrix = new Matrix4x4[length];
		}
	}

	public void Update()
	{
		bool isEnabled = true;
		int num = 0;
		int i = 0;
		Transform[] array = checkObjectList;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					Matrix4x4[] array2 = lastMatrix;
					if (array2[RuntimeServices.NormalizeArrayIndex(array2, num)] != array[i].localToWorldMatrix)
					{
						isEnabled = false;
					}
					Matrix4x4[] array3 = lastMatrix;
					ref Matrix4x4 reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
					reference = array[i].localToWorldMatrix;
				}
				num++;
			}
			if ((bool)buttonMessage)
			{
				buttonMessage.enabled = isEnabled;
			}
			if ((bool)uiButton)
			{
				uiButton.isEnabled = isEnabled;
			}
		}
	}
}
