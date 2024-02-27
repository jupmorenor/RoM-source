using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MyHomeCamera : BasicCamera
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024findTarget_002416912 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pl_002416913;

			internal MyHomeCamera _0024self__002416914;

			public _0024(MyHomeCamera self_)
			{
				_0024self__002416914 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416914.target != null)
					{
						goto case 1;
					}
					goto case 2;
				case 2:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002416913 = PlayerControl.CurrentPlayer;
					_0024self__002416914.target = _0024pl_002416913.transform;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeCamera _0024self__002416915;

		public _0024findTarget_002416912(MyHomeCamera self_)
		{
			_0024self__002416915 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416915);
		}
	}

	public float movableAreaXMin;

	public float movableAreaXMax;

	public float movableAreaZMin;

	public float movableAreaZMax;

	public float rotateXMin;

	public float rotateXMax;

	public float rotateYMin;

	public float rotateYMax;

	private float targetHeight;

	private float heightVelocity;

	private float currentDistance;

	private float distanceVelocity;

	public MyHomeCamera()
	{
		targetHeight = 100000f;
		currentDistance = 3f;
	}

	public void Start()
	{
		IEnumerator enumerator = findTarget();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator findTarget()
	{
		return new _0024findTarget_002416912(this).GetEnumerator();
	}

	public void Apply()
	{
		Vector3 zero = Vector3.zero;
		zero = targetPosition + centerOffset;
		float y = transform.eulerAngles.y;
		targetHeight = zero.y + height;
		float y2 = transform.position.y;
		y2 = Mathf.SmoothDamp(y2, targetHeight, ref heightVelocity, heightSmoothLag);
		currentDistance = Mathf.SmoothDamp(currentDistance, distance, ref distanceVelocity, distanceSmoothLag);
		Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
		transform.position = zero;
		transform.position += quaternion * Vector3.back * currentDistance;
		float y3 = y2;
		Vector3 position = transform.position;
		float num = (position.y = y3);
		Vector3 vector2 = (transform.position = position);
		int num2 = 0;
		Vector3 position2 = transform.position;
		float num3 = (position2.x = num2);
		Vector3 vector4 = (transform.position = position2);
		float z = Mathf.Clamp(transform.position.z, movableAreaZMin, movableAreaZMax);
		Vector3 position3 = transform.position;
		float num4 = (position3.z = z);
		Vector3 vector6 = (transform.position = position3);
		transform.LookAt(targetPosition);
		float x = Mathf.Clamp(transform.eulerAngles.x, rotateXMin, rotateXMax);
		Vector3 eulerAngles = transform.eulerAngles;
		float num5 = (eulerAngles.x = x);
		Vector3 vector8 = (transform.eulerAngles = eulerAngles);
		float y4 = Mathf.Clamp(transform.eulerAngles.y, rotateYMin, rotateYMax);
		Vector3 eulerAngles2 = transform.eulerAngles;
		float num6 = (eulerAngles2.y = y4);
		Vector3 vector10 = (transform.eulerAngles = eulerAngles2);
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		Apply();
	}
}
