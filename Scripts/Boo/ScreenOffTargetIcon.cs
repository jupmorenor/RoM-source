using System;
using UnityEngine;

[Serializable]
public class ScreenOffTargetIcon : MonoBehaviour
{
	private UISprite uiSprite;

	private Renderer targetRenderer;

	private GameObject target;

	private GameObject player;

	public Vector3 targetPos;

	public Vector3 playerPos;

	public void SetTarget(GameObject _target)
	{
		target = _target;
		if ((bool)target)
		{
			targetRenderer = target.GetComponentInChildren<Renderer>();
		}
	}

	public void Start()
	{
		uiSprite = GetComponent<UISprite>();
		uiSprite.enabled = false;
		player = PlayerControl.CurrentPlayerGO;
	}

	public void Update()
	{
		if (target == null || player == null)
		{
			uiSprite.enabled = false;
		}
		else
		{
			if (targetRenderer == null)
			{
				return;
			}
			if (targetRenderer.isVisible)
			{
				uiSprite.enabled = false;
				return;
			}
			uiSprite.enabled = true;
			targetPos = Camera.main.WorldToScreenPoint(target.transform.position);
			playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
			float x;
			float y;
			if (!(targetPos.z >= 0f))
			{
				x = targetPos.x - playerPos.x;
				y = targetPos.y - playerPos.y;
			}
			else
			{
				x = playerPos.x - targetPos.x;
				y = playerPos.y - targetPos.y;
			}
			float z = Mathf.Atan2(y, x) * 57.29578f + 180f;
			Vector3 localEulerAngles = transform.localEulerAngles;
			float num = (localEulerAngles.z = z);
			Vector3 vector2 = (transform.localEulerAngles = localEulerAngles);
		}
	}
}
