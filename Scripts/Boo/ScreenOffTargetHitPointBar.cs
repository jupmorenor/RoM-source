using System;
using UnityEngine;

[Serializable]
public class ScreenOffTargetHitPointBar : MonoBehaviour
{
	private UISlider uiSlider;

	public void SetTarget(GameObject _target)
	{
		if ((bool)_target)
		{
			Renderer componentInChildren = _target.GetComponentInChildren<Renderer>();
			BaseControl component = _target.GetComponent<BaseControl>();
		}
	}

	public void Start()
	{
		uiSlider = GetComponentInChildren<UISlider>();
		uiSlider.gameObject.SetActive(value: false);
	}

	public void updateHitPointBar(GameObject target)
	{
		Renderer renderer = null;
		BaseControl baseControl = null;
		if ((bool)target)
		{
			renderer = target.GetComponentInChildren<Renderer>();
			baseControl = target.GetComponent<BaseControl>();
		}
		if (renderer == null || baseControl == null)
		{
			uiSlider.gameObject.SetActive(value: false);
		}
		if (renderer.isVisible)
		{
			uiSlider.gameObject.SetActive(value: false);
			return;
		}
		uiSlider.gameObject.SetActive(value: true);
		uiSlider.sliderValue = baseControl.HitPoint / baseControl.MaxHitPoint;
	}
}
