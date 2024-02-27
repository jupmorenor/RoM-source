using System;
using UnityEngine;

[Serializable]
public class BlinkLine : MonoBehaviour
{
	public Color startColor;

	public Color endColor;

	private float blinkCount;

	public BlinkLine()
	{
		startColor = new Color(0.9f, 0.9f, 0.9f);
		endColor = new Color(0.9f, 0.9f, 0.9f);
	}

	public void Start()
	{
		blinkCount = 0f;
	}

	public void Update()
	{
		if (!GameParameter.lockonShader)
		{
			return;
		}
		Color color = default(Color);
		float f = blinkCount * 10.38f;
		f = Mathf.Sin(f);
		f = (f + 1f) / 2f;
		color = Color.Lerp(startColor, endColor, f);
		blinkCount += Time.deltaTime;
		int i = 0;
		Material[] array = (Material[])Resources.FindObjectsOfTypeAll(typeof(Material));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null) && array[i].HasProperty("_OutlineColor"))
			{
				if (array[i].shader.name == "Outlined/Silhouetted Unlit")
				{
					array[i].SetColor("_OutlineColor", color);
				}
				else if (array[i].shader.name == "Outlined/Silhouetted Unlit with Shadow")
				{
					array[i].SetColor("_OutlineColor", color);
				}
				else if (array[i].shader.name == "Outlined/Cutout/Silhouetted Unlit")
				{
					array[i].SetColor("_OutlineColor", color);
				}
				else if (array[i].shader.name == "Outlined/Cutout/Silhouetted Unlit with Shadow")
				{
					array[i].SetColor("_OutlineColor", color);
				}
			}
		}
	}
}
