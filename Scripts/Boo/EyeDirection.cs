using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class EyeDirection : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_findTarget_002418286 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024count_002418287;

			internal EyeDirection _0024self__002418288;

			public _0024(EyeDirection self_)
			{
				_0024self__002418288 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024count_002418287 = 0;
						goto case 2;
					case 2:
						if (_0024self__002418288.target == null || _0024count_002418287 == _0024self__002418288.SEARCH_RETRY_COUNT)
						{
							_0024self__002418288.target = PlayerControl.CurrentPlayerGO;
							_0024count_002418287++;
							result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
							break;
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal EyeDirection _0024self__002418289;

		public _0024_findTarget_002418286(EyeDirection self_)
		{
			_0024self__002418289 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002418289);
		}
	}

	private readonly int SEARCH_RETRY_COUNT;

	public GameObject target;

	public Transform[] eyes;

	public Vector3 maxAngles;

	public Vector3 minAngles;

	private Dictionary<int, Vector3> bindPoseRotation;

	private float distance;

	private Vector3 tmpv;

	public EyeDirection()
	{
		SEARCH_RETRY_COUNT = 5;
		maxAngles = new Vector3(0.1f, 10f, 5.5f);
		minAngles = new Vector3(0f, -10f, -5.5f);
		bindPoseRotation = new Dictionary<int, Vector3>();
	}

	public void Awake()
	{
		StartCoroutine(_findTarget());
		int i = 0;
		Transform[] array = eyes;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			bindPoseRotation[array[i].GetInstanceID()] = array[i].localEulerAngles.normalized;
		}
	}

	public void Update()
	{
		if (gameObject.activeSelf && !(target == null) && _isActive())
		{
			int i = 0;
			Transform[] array = eyes;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				_turn(array[i]);
			}
		}
	}

	public bool _isActive()
	{
		distance = Vector3.Distance(target.transform.position, transform.position);
		return (distance < 100f) ? true : false;
	}

	public IEnumerator _findTarget()
	{
		return new _0024_findTarget_002418286(this).GetEnumerator();
	}

	public void _turn(Transform eye)
	{
		Vector3 vector = target.transform.position - transform.position;
		Vector3 worldPosition = eye.transform.position + vector;
		eye.LookAt(worldPosition);
		eye.Rotate(new Vector3(0f, 90f, 0f));
		_clamp(eye);
	}

	public void _clamp(Transform eye)
	{
		Vector3 localEulerAngles = eye.localEulerAngles;
		Vector3 toDirection = bindPoseRotation[eye.GetInstanceID()];
		Quaternion quaternion = default(Quaternion);
		quaternion.SetFromToRotation(localEulerAngles, toDirection);
		tmpv = quaternion.eulerAngles;
		localEulerAngles.x = 0f;
		localEulerAngles.z = Mathf.Clamp(localEulerAngles.z, minAngles.z + toDirection.z, maxAngles.z + toDirection.z);
		if (!(Mathf.Abs(localEulerAngles.y) <= 180f))
		{
			tmpv.y = ((localEulerAngles.y <= 1f) ? (-360f + localEulerAngles.y) : (360f - localEulerAngles.y));
		}
		else
		{
			tmpv.y = localEulerAngles.y;
		}
		tmpv.y = Mathf.Clamp(tmpv.y, minAngles.y + toDirection.y, maxAngles.y + toDirection.y);
		if (!(Mathf.Abs(localEulerAngles.y) <= 180f))
		{
			localEulerAngles.y = ((localEulerAngles.y <= 1f) ? (-360f - tmpv.y) : (360f - tmpv.y));
		}
		else
		{
			localEulerAngles.y = tmpv.y;
		}
		eye.localEulerAngles = localEulerAngles;
	}
}
