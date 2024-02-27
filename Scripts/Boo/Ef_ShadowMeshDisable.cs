using System;
using UnityEngine;

[Serializable]
public class Ef_ShadowMeshDisable : Ef_Base
{
	public float findWait;

	private float findTimer;

	public Ef_ShadowMeshDisable()
	{
		findWait = 1f;
	}

	public void Update()
	{
		if (SceneChanger.isCompletelyReady)
		{
			findTimer -= deltaTime;
			if (!(findTimer > 0f))
			{
				FindAndDeactiveShadow();
				findTimer = findWait;
			}
		}
	}

	public void FindAndDeactiveShadow()
	{
		BaseControl[] allControls = BaseControl.AllControls;
		int i = 0;
		BaseControl[] array = allControls;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] == null)
			{
				continue;
			}
			MerlinMotionPackControl component = array[i].gameObject.GetComponent<MerlinMotionPackControl>();
			if (!(component != null))
			{
				continue;
			}
			Animation motionTarget = component.motionTarget;
			if (!(motionTarget != null))
			{
				continue;
			}
			Transform transform = motionTarget.transform;
			if (!(transform != null))
			{
				continue;
			}
			Transform transform2 = transform.Find("y_ang");
			if (!(transform2 != null))
			{
				continue;
			}
			Transform transform3 = transform2.Find("shadow");
			if (transform3 != null)
			{
				if (transform3.renderer != null)
				{
					transform3.renderer.enabled = false;
				}
				transform3.gameObject.SetActive(value: false);
			}
		}
	}
}
