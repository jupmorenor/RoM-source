using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class KaniExplosion : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418956 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024tm_002418957;

			internal int _0024i_002418958;

			internal float _0024x_002418959;

			internal float _0024y_002418960;

			internal float _0024z_002418961;

			internal float _0024_0024wait_sec_0024temp_00241733_002418962;

			internal int _0024_00249808_002418963;

			internal int _0024_00249809_002418964;

			internal float _0024time_002418965;

			internal KaniExplosion _0024self__002418966;

			public _0024(float time, KaniExplosion self_)
			{
				_0024time_002418965 = time;
				_0024self__002418966 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002418966.Effect == null || _0024self__002418966.Target == null)
					{
						goto case 1;
					}
					_0024tm_002418957 = 0;
					goto IL_0291;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241733_002418962 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241733_002418962 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024tm_002418957 = checked((int)((float)_0024tm_002418957 + _0024self__002418966.EmitStep));
					goto IL_0291;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0291:
					if ((float)_0024tm_002418957 < _0024time_002418965)
					{
						_0024_00249808_002418963 = 0;
						_0024_00249809_002418964 = _0024self__002418966.EmitNumPerStep;
						if (_0024_00249809_002418964 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (_0024_00249808_002418963 < _0024_00249809_002418964)
						{
							_0024i_002418958 = _0024_00249808_002418963;
							_0024_00249808_002418963++;
							_0024x_002418959 = UnityEngine.Random.Range(_0024self__002418966.EmitOffset.x - _0024self__002418966.EmitRange.x, _0024self__002418966.EmitOffset.x + _0024self__002418966.EmitRange.x);
							_0024y_002418960 = UnityEngine.Random.Range(_0024self__002418966.EmitOffset.y - _0024self__002418966.EmitRange.y, _0024self__002418966.EmitOffset.y + _0024self__002418966.EmitRange.y);
							_0024z_002418961 = UnityEngine.Random.Range(_0024self__002418966.EmitOffset.z - _0024self__002418966.EmitRange.z, _0024self__002418966.EmitOffset.z + _0024self__002418966.EmitRange.z);
							_0024x_002418959 += _0024self__002418966.Target.position.x;
							_0024y_002418960 += _0024self__002418966.Target.position.y;
							_0024z_002418961 += _0024self__002418966.Target.position.z;
							UnityEngine.Object.Instantiate(_0024self__002418966.Effect, new Vector3(_0024x_002418959, _0024y_002418960, _0024z_002418961), Quaternion.identity);
						}
						_0024_0024wait_sec_0024temp_00241733_002418962 = _0024self__002418966.EmitStep;
						goto case 2;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024time_002418967;

		internal KaniExplosion _0024self__002418968;

		public _0024main_002418956(float time, KaniExplosion self_)
		{
			_0024time_002418967 = time;
			_0024self__002418968 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024time_002418967, _0024self__002418968);
		}
	}

	public Transform Target;

	public GameObject Effect;

	public Vector3 EmitOffset;

	public Vector3 EmitRange;

	public float EmitTime;

	public int EmitNumPerStep;

	public float EmitStep;

	public KaniExplosion()
	{
		EmitOffset = new Vector3(0f, 1f, 0f);
		EmitRange = new Vector3(10f, 2f, 10f);
		EmitTime = 5f;
		EmitNumPerStep = 2;
		EmitStep = 0.1f;
	}

	public void explode()
	{
		StartCoroutine(main(EmitTime));
	}

	private IEnumerator main(float time)
	{
		return new _0024main_002418956(time, this).GetEnumerator();
	}
}
