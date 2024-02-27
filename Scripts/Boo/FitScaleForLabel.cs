using System;
using UnityEngine;

[Serializable]
public class FitScaleForLabel : MonoBehaviour
{
	public UILabel label;

	public int checkLenght;

	protected int lastLenght;

	public float fitScale;

	protected float baseScale;

	public FitScaleForLabel()
	{
		checkLenght = 10;
		fitScale = 0.8f;
		baseScale = 1f;
	}

	public void Start()
	{
		if (!label)
		{
			label = gameObject.GetComponent<UILabel>();
		}
		if ((bool)label)
		{
			baseScale = label.gameObject.transform.localScale.x;
		}
	}

	public void Update()
	{
		if (!label)
		{
			return;
		}
		int length = label.text.Length;
		if (lastLenght != length)
		{
			lastLenght = length;
			if (checkLenght <= length)
			{
				float x = baseScale * fitScale;
				Vector3 localScale = label.gameObject.transform.localScale;
				float num = (localScale.x = x);
				Vector3 vector2 = (label.gameObject.transform.localScale = localScale);
			}
			else
			{
				float x2 = baseScale;
				Vector3 localScale2 = label.gameObject.transform.localScale;
				float num2 = (localScale2.x = x2);
				Vector3 vector4 = (label.gameObject.transform.localScale = localScale2);
			}
		}
	}
}
