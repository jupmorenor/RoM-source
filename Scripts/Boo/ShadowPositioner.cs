using System;
using Boo.Lang.Runtime;
using ObjUtil;
using UnityEngine;

[Serializable]
public class ShadowPositioner : MonoBehaviour
{
	private Transform cog;

	private Vector3 originalScale;

	public void Start()
	{
		if (transform.parent.name == "y_ang")
		{
			cog = ObjUtilModule.Find1stDescendant(transform.parent, "cog");
			originalScale = transform.localScale;
			if (!(cog != null))
			{
				throw new AssertionFailedException("cog \ufffd\ufffd shadow \ufffdm\ufffdZ\ufffd\ufffd\ufffdɂ\u0742\u0082\ufffd\ufffd\ufffd\ufffdȂ\ufffd");
			}
		}
	}

	public void LateUpdate()
	{
		if ((bool)cog)
		{
			alignCOG();
		}
		alignGround();
	}

	public void alignCOG()
	{
		float x = cog.localPosition.x;
		Vector3 localPosition = transform.localPosition;
		float num = (localPosition.x = x);
		Vector3 vector2 = (transform.localPosition = localPosition);
		float z = cog.localPosition.z;
		Vector3 localPosition2 = transform.localPosition;
		float num2 = (localPosition2.z = z);
		Vector3 vector4 = (transform.localPosition = localPosition2);
	}

	public void alignGround()
	{
		object[] groundHeight = ObjUtilModule.GetGroundHeight(gameObject);
		object value = groundHeight[1];
		Vector3 position = transform.position;
		float num = (position.y = RuntimeServices.UnboxSingle(value));
		Vector3 vector2 = (transform.position = position);
		transform.rotation = Quaternion.FromToRotation(transform.rotation * Vector3.up, (Vector3)groundHeight[2]) * transform.rotation;
	}

	public void stretch()
	{
	}
}
