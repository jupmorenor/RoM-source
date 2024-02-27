using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class CollisionTimer : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024routineTimer_002417323 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CollisionTimer _0024self__002417324;

			public _0024(CollisionTimer self_)
			{
				_0024self__002417324 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002417324.times > 0)
					{
						_0024self__002417324.leftTime -= Time.deltaTime;
						if (!(_0024self__002417324.leftTime > 0f))
						{
							_0024self__002417324.leftTime += _0024self__002417324.interval;
							_0024self__002417324.times = checked(_0024self__002417324.times - 1);
							if ((bool)_0024self__002417324.collider)
							{
								_0024self__002417324.collider.enabled = !_0024self__002417324.collider.enabled;
							}
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal CollisionTimer _0024self__002417325;

		public _0024routineTimer_002417323(CollisionTimer self_)
		{
			_0024self__002417325 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417325);
		}
	}

	public int times;

	public float interval;

	private float leftTime;

	public CollisionTimer()
	{
		times = 1;
		interval = 1f;
	}

	public void Start()
	{
		leftTime = interval;
		StartCoroutine(routineTimer());
	}

	private IEnumerator routineTimer()
	{
		return new _0024routineTimer_002417323(this).GetEnumerator();
	}
}
