using System;
using UnityEngine;

[Serializable]
public class NavigationArrow : MonoBehaviour
{
	public UISprite spriteArrow;

	private Transform playerTransform;

	private PlayerControl playerControl;

	private bool hasGroundFollow;

	private bool bForceHideArrow;

	public Transform targetTransform;

	public void Start()
	{
		setInit();
	}

	public void setInit()
	{
		int num = 90;
		Vector3 eulerAngles = transform.eulerAngles;
		float num2 = (eulerAngles.x = num);
		Vector3 vector2 = (transform.eulerAngles = eulerAngles);
		bForceHideArrow = false;
		playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		Ef_GroundFollow component = gameObject.GetComponent<Ef_GroundFollow>();
		if ((bool)component)
		{
			component.rotToNormal = false;
			hasGroundFollow = true;
		}
		else
		{
			hasGroundFollow = false;
		}
	}

	public void HidArrow()
	{
		spriteArrow.enabled = false;
		bForceHideArrow = true;
	}

	public bool IsShowArrow()
	{
		return spriteArrow.enabled;
	}

	public void ShowArrow()
	{
		spriteArrow.enabled = true;
		bForceHideArrow = false;
	}

	public void StartLockOn(GameObject target)
	{
		if (!(spriteArrow == null))
		{
			spriteArrow.enabled = true;
			playerControl = target.GetComponent<PlayerControl>();
			if (!(playerControl == null))
			{
				playerTransform = target.transform;
			}
		}
	}

	public void Update()
	{
		if ((bool)playerTransform)
		{
			float x = playerTransform.position.x;
			Vector3 position = transform.position;
			float num = (position.x = x);
			Vector3 vector2 = (transform.position = position);
			float z = playerTransform.position.z;
			Vector3 position2 = transform.position;
			float num2 = (position2.z = z);
			Vector3 vector4 = (transform.position = position2);
			if (!hasGroundFollow)
			{
				float y = playerTransform.position.y;
				Vector3 position3 = transform.position;
				float num3 = (position3.y = y);
				Vector3 vector6 = (transform.position = position3);
				float y2 = 0.00125f;
				Vector3 position4 = transform.position;
				float num4 = (position4.y = y2);
				Vector3 vector8 = (transform.position = position4);
			}
			else if ((bool)targetTransform)
			{
				Ef_GroundFollow component = gameObject.GetComponent<Ef_GroundFollow>();
				if ((bool)component)
				{
					Vector3 pos = new Vector3(targetTransform.position.x, playerTransform.position.y + 0.6f, targetTransform.position.z);
					float y3 = playerTransform.position.y + 0.6f;
					Vector3 position5 = transform.position;
					float num5 = (position5.y = y3);
					Vector3 vector10 = (transform.position = position5);
					lookAtTarget(component, pos);
				}
				if (Vector3.Distance(transform.position, targetTransform.position) < 2f)
				{
					spriteArrow.enabled = false;
				}
				else if (!bForceHideArrow)
				{
					spriteArrow.enabled = true;
				}
			}
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	private void lookAtTarget(Ef_GroundFollow groundFollow, Vector3 pos)
	{
		if (!(groundFollow == null) && !(groundFollow.rotObj == null))
		{
			Transform rotObj = groundFollow.rotObj;
			Quaternion rotation = Quaternion.LookRotation(pos - rotObj.position, Vector3.up);
			rotObj.rotation = rotation;
		}
	}
}
