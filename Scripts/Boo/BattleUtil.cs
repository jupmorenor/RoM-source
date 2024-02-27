using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class BattleUtil
{
	[Serializable]
	public struct AnimStopState
	{
		public Animation animation;

		public AnimationState animState;

		public float speed;

		public bool enabled;

		public AnimStopState(Animation _animation, AnimationState _animState)
		{
			animation = _animation;
			animState = _animState;
			speed = animState.speed;
		}

		public void restore()
		{
			if (!(animState == null))
			{
				animState.speed = speed;
			}
		}
	}

	[Serializable]
	internal class _0024SetAllAnimationSpeed_0024locals_002414340
	{
		internal float _0024spd;
	}

	[Serializable]
	internal class _0024SetAllAnimationSpeed_0024closure_00242859
	{
		internal _0024SetAllAnimationSpeed_0024locals_002414340 _0024_0024locals_002414785;

		public _0024SetAllAnimationSpeed_0024closure_00242859(_0024SetAllAnimationSpeed_0024locals_002414340 _0024_0024locals_002414785)
		{
			this._0024_0024locals_002414785 = _0024_0024locals_002414785;
		}

		public void Invoke(Animation anim)
		{
			IEnumerator enumerator = anim.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				LastStoppedInfo.Add(new AnimStopState(anim, animationState));
				animationState.speed = _0024_0024locals_002414785._0024spd;
			}
		}
	}

	[NonSerialized]
	private static Boo.Lang.List<AnimStopState> LastStoppedInfo = new Boo.Lang.List<AnimStopState>();

	public static Vector3 AdjustYpos(Vector3 pos)
	{
		return AdjustYpos(pos, 0.15f);
	}

	public static Vector3 AdjustYpos(Vector3 pos, float yofs)
	{
		Ray ray = new Ray(pos + new Vector3(0f, 200f, 0f), new Vector3(0f, -1f, 0f));
		RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity);
		RaycastHit[] array2 = array;
		int length = array2.Length;
		int num = 0;
		Vector3 result;
		while (true)
		{
			if (num < length)
			{
				RaycastHit raycastHit = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num++))];
				if (raycastHit.transform.tag == "Plane")
				{
					result = raycastHit.point + new Vector3(0f, yofs, 0f);
					break;
				}
				continue;
			}
			result = pos + new Vector3(0f, yofs, 0f);
			break;
		}
		return result;
	}

	public static void MapComponents<T>(__BattleUtil_MapComponents_0024callable49_002417_60__ m) where T : Component
	{
		int i = 0;
		T[] array = (T[])UnityEngine.Object.FindObjectsOfType(typeof(T));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				m(array[i]);
			}
		}
	}

	public static void ActivateAllComponents<T>(bool onoff) where T : MonoBehaviour
	{
		T[] array = (T[])UnityEngine.Object.FindObjectsOfType(typeof(T));
		int i = 0;
		T[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (!(array2[i] == null))
			{
				T val = array2[i];
				val.enabled = onoff;
			}
		}
	}

	public static void SetAllAnimationSpeed(float spd)
	{
		_0024SetAllAnimationSpeed_0024locals_002414340 _0024SetAllAnimationSpeed_0024locals_0024 = new _0024SetAllAnimationSpeed_0024locals_002414340();
		_0024SetAllAnimationSpeed_0024locals_0024._0024spd = spd;
		LastStoppedInfo.Clear();
		MapComponents<Animation>(_0024adaptor_0024__BattleUtil_SetAllAnimationSpeed_0024callable513_002451_36___0024__BattleUtil_MapComponents_0024callable49_002417_60___0024128.Adapt(new _0024SetAllAnimationSpeed_0024closure_00242859(_0024SetAllAnimationSpeed_0024locals_0024).Invoke));
	}

	public static void RestoreAllAnimationSpeed()
	{
		IEnumerator<AnimStopState> enumerator = LastStoppedInfo.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.restore();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		LastStoppedInfo.Clear();
	}
}
