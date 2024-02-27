using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SpriteFillGauge : MonoBehaviour
{
	public UISprite fillGauge;

	public float[] fillGaugeAmountLevel;

	public SpriteFillGauge()
	{
		fillGaugeAmountLevel = new float[11]
		{
			0.145f, 0.215f, 0.285f, 0.355f, 0.425f, 0.5f, 0.575f, 0.645f, 0.715f, 0.785f,
			0.86f
		};
	}

	public void updateGauge(float val, float limit, Color setColor)
	{
		updateGauge(val / limit, setColor);
	}

	public void updateGauge(float fillAmount)
	{
		updateGauge(fillAmount, fillGauge.color);
	}

	public void updateGauge(float fillAmount, Color setColor)
	{
		fillGauge.color = setColor;
		int index = checked((int)(fillAmount * (float)(fillGaugeAmountLevel.Length - 1)));
		UISprite uISprite = fillGauge;
		float[] array = fillGaugeAmountLevel;
		uISprite.fillAmount = array[RuntimeServices.NormalizeArrayIndex(array, index)];
	}
}
