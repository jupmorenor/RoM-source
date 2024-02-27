using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class WaitActiveObject : MonoBehaviour
{
	[Serializable]
	private class WaitActiveObj
	{
		public GameObject obj;

		public float time;

		public bool active;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002423087 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242731_002423088;

			internal GameObject _0024obj_002423089;

			internal float _0024wait_002423090;

			internal bool _0024active_002423091;

			public _0024(GameObject obj, float wait, bool active)
			{
				_0024obj_002423089 = obj;
				_0024wait_002423090 = wait;
				_0024active_002423091 = active;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_sec_0024temp_00242731_002423088 = _0024wait_002423090;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242731_002423088 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242731_002423088 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024obj_002423089 == null))
					{
						_0024obj_002423089.SetActive(_0024active_002423091);
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024obj_002423092;

		internal float _0024wait_002423093;

		internal bool _0024active_002423094;

		public _0024mainRoutine_002423087(GameObject obj, float wait, bool active)
		{
			_0024obj_002423092 = obj;
			_0024wait_002423093 = wait;
			_0024active_002423094 = active;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024obj_002423092, _0024wait_002423093, _0024active_002423094);
		}
	}

	public WaitActiveObj[] waitObjects;

	public void Start()
	{
		int i = 0;
		WaitActiveObj[] array = waitObjects;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			StartCoroutine(mainRoutine(array[i].obj, array[i].time, array[i].active));
		}
	}

	public IEnumerator mainRoutine(GameObject obj, float wait, bool active)
	{
		return new _0024mainRoutine_002423087(obj, wait, active).GetEnumerator();
	}
}
