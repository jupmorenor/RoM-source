using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class LinearCamera : MonoBehaviour
{
	[Serializable]
	public enum Type
	{
		FOREST_TRENTO,
		FOREST_IRIGUTI,
		DESERT_GAIA,
		MAX
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024init_002416908 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pl_002416909;

			internal LinearCamera _0024self__002416910;

			public _0024(LinearCamera self_)
			{
				_0024self__002416910 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!Camera.main)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416910.cameraTransform = Camera.main.transform;
					_0024self__002416910.cameraControl = Camera.main.gameObject.GetComponent<CameraControl>();
					if ((bool)_0024self__002416910.cameraControl)
					{
						_0024self__002416910.tempFieldDistanceMax = _0024self__002416910.cameraControl.FieldDistanceMax;
					}
					goto case 3;
				case 3:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024pl_002416909 = PlayerControl.CurrentPlayer;
					if ((bool)_0024pl_002416909)
					{
						_0024self__002416910.target = _0024pl_002416909.transform;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LinearCamera _0024self__002416911;

		public _0024init_002416908(LinearCamera self_)
		{
			_0024self__002416911 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416911);
		}
	}

	public Transform target;

	private Transform cameraTransform;

	private CameraControl cameraControl;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] updateFunctions;

	public Type stateType;

	private float tempFieldDistanceMax;

	public LinearCamera()
	{
		updateFunctions = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[3];
	}

	public void Start()
	{
		StartCoroutine(init());
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array = updateFunctions;
		array[RuntimeServices.NormalizeArrayIndex(array, 0)] = updateForestTrento;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array2 = updateFunctions;
		array2[RuntimeServices.NormalizeArrayIndex(array2, 1)] = updateForestIriguti;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array3 = updateFunctions;
		array3[RuntimeServices.NormalizeArrayIndex(array3, 2)] = updateDesertGaia;
	}

	private IEnumerator init()
	{
		return new _0024init_002416908(this).GetEnumerator();
	}

	public void FixedUpdate()
	{
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array = updateFunctions;
		array[RuntimeServices.NormalizeArrayIndex(array, (int)stateType)]();
	}

	public void updateForestTrento()
	{
		if (!(target == null) && !(cameraControl == null) && !(target.position.z > -20f) && !(target.position.z < -47f))
		{
			float num = target.position.z + 20f;
			cameraControl.distance = (float)(7.0 + (double)num * -0.25);
			double num2 = 25.36566 + (double)num * 1.1;
			Vector3 eulerAngles = cameraTransform.eulerAngles;
			float num3 = (eulerAngles.x = (float)num2);
			Vector3 vector2 = (cameraTransform.eulerAngles = eulerAngles);
		}
	}

	public void updateForestIriguti()
	{
		if (!(target == null) && !(cameraControl == null) && !(target.position.z > 36f) && !(target.position.z < 16f))
		{
			float num = target.position.z - 16f;
			cameraControl.distance = (float)(7.0 + (double)num * 0.15);
			double num2 = 25.36566 + (double)num * -0.9;
			Vector3 eulerAngles = cameraTransform.eulerAngles;
			float num3 = (eulerAngles.x = (float)num2);
			Vector3 vector2 = (cameraTransform.eulerAngles = eulerAngles);
		}
	}

	public void updateDesertGaia()
	{
		if (!(target == null) && !(cameraControl == null))
		{
			if (!(target.position.z > -30f))
			{
				float num = target.position.z + 30f;
				cameraControl.FieldDistanceMax = 20f;
				cameraControl.distance = (float)(7.0 + (double)num * -0.5);
				cameraControl.height = (float)(5.5 + (double)num * -0.15);
				double num2 = 25.36566 + (double)num * 0.6;
				Vector3 eulerAngles = cameraTransform.eulerAngles;
				float num3 = (eulerAngles.x = (float)num2);
				Vector3 vector2 = (cameraTransform.eulerAngles = eulerAngles);
			}
			else if ((bool)cameraControl)
			{
				cameraControl.FieldDistanceMax = tempFieldDistanceMax;
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)cameraControl)
		{
			cameraControl.FieldDistanceMax = tempFieldDistanceMax;
		}
	}
}
