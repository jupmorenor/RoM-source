using System;
using UnityEngine;

[Serializable]
public class LandingGround : MonoBehaviour
{
	private float gravity;

	private bool isLanding;

	private CharacterController charControl;

	public readonly float LowerLimit;

	public readonly float HigherLimit;

	public float Gravity
	{
		get
		{
			return gravity;
		}
		set
		{
			gravity = value;
		}
	}

	public bool IsLanding
	{
		get
		{
			return isLanding;
		}
		set
		{
			isLanding = value;
		}
	}

	public LandingGround()
	{
		gravity = -9.8f;
		LowerLimit = -100f;
		HigherLimit = 100f;
	}

	public void Start()
	{
		charControl = GetComponent<CharacterController>();
	}

	public void FixedUpdate()
	{
		if ((bool)charControl && charControl.enabled && charControl.active)
		{
			Vector3 zero = Vector3.zero;
			zero += Vector3.up * gravity * Time.deltaTime;
			charControl.Move(zero);
			if (!(transform.position.y >= LowerLimit))
			{
				float higherLimit = HigherLimit;
				Vector3 position = transform.position;
				float num = (position.y = higherLimit);
				Vector3 vector2 = (transform.position = position);
			}
		}
	}
}
