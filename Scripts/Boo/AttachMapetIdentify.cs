using System;
using ObjUtil;
using UnityEngine;

[Serializable]
public class AttachMapetIdentify : MonoBehaviour
{
	public GameObject target;

	private readonly float DRAW_OFFSET_Y;

	public AttachMapetIdentify()
	{
		DRAW_OFFSET_Y = 100f;
	}

	public void show()
	{
		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(value: true);
		}
	}

	public void hide()
	{
		if (gameObject.activeSelf)
		{
			gameObject.SetActive(value: false);
		}
	}

	public void Update()
	{
		if (!(target == null) && !(target.transform == null) && !(Camera.main == null))
		{
			Vector3 screenPostion = ObjUtilModule.GetScreenPostion(transform, target, Camera.main);
			screenPostion.y += DRAW_OFFSET_Y;
			transform.localPosition = screenPostion;
		}
	}
}
