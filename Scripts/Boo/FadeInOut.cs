using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class FadeInOut : MonoBehaviour
{
	[Serializable]
	public enum FADE_STATE
	{
		Wait,
		FadeIn,
		FadeOut,
		Max
	}

	private UISprite darkMask;

	private float fadeRate;

	private FADE_STATE fadeState;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] updateFunctions;

	protected readonly float ALPHA_MAX;

	public FadeInOut()
	{
		fadeState = FADE_STATE.Wait;
		updateFunctions = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[3];
		ALPHA_MAX = 1f;
	}

	public void Start()
	{
		darkMask = GetComponent<UISprite>();
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array = updateFunctions;
		array[RuntimeServices.NormalizeArrayIndex(array, 0)] = UpdateWait;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array2 = updateFunctions;
		array2[RuntimeServices.NormalizeArrayIndex(array2, 1)] = UpdateFadeIn;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array3 = updateFunctions;
		array3[RuntimeServices.NormalizeArrayIndex(array3, 2)] = UpdateFadeOut;
	}

	public void Update()
	{
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array = updateFunctions;
		array[RuntimeServices.NormalizeArrayIndex(array, (int)fadeState)]();
	}

	public void UpdateWait()
	{
	}

	public void UpdateFadeIn()
	{
		float a = darkMask.color.a + fadeRate;
		Color color = darkMask.color;
		float num = (color.a = a);
		Color color3 = (darkMask.color = color);
		if (!(darkMask.color.a > 0f))
		{
			fadeState = FADE_STATE.Wait;
			darkMask.enabled = false;
		}
	}

	public void UpdateFadeOut()
	{
		float a = darkMask.color.a + fadeRate;
		Color color = darkMask.color;
		float num = (color.a = a);
		Color color3 = (darkMask.color = color);
		if (!(darkMask.color.a < ALPHA_MAX))
		{
			fadeState = FADE_STATE.Wait;
		}
	}

	public void FadeIn(float fadeTime)
	{
		fadeRate = (0f - ALPHA_MAX) / fadeTime * Time.deltaTime;
		float aLPHA_MAX = ALPHA_MAX;
		Color color = darkMask.color;
		float num = (color.a = aLPHA_MAX);
		Color color3 = (darkMask.color = color);
		darkMask.enabled = true;
		fadeState = FADE_STATE.FadeIn;
	}

	public void FadeOut(float fadeTime)
	{
		fadeRate = ALPHA_MAX / fadeTime * Time.deltaTime;
		float a = 0f;
		Color color = darkMask.color;
		float num = (color.a = a);
		Color color3 = (darkMask.color = color);
		darkMask.enabled = true;
		fadeState = FADE_STATE.FadeOut;
	}

	public bool isFade()
	{
		return fadeState != FADE_STATE.Wait;
	}
}
