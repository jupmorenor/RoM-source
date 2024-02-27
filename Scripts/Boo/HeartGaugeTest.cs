using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HeartGaugeTest : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416577 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal double _0024life_002416578;

			internal double _0024lifemax_002416579;

			internal HeartGaugeTest _0024self__002416580;

			public _0024(HeartGaugeTest self_)
			{
				_0024self__002416580 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002416580.gauge == null)
						{
							goto case 1;
						}
						_0024life_002416578 = 10.0;
						_0024lifemax_002416579 = 10.0;
						goto case 2;
					case 2:
						_0024life_002416578 -= 0.1;
						if (!(_0024life_002416578 >= 0.0))
						{
							_0024life_002416578 = _0024lifemax_002416579;
						}
						_0024self__002416580.gauge.setMagic((int)_0024life_002416578, (int)_0024lifemax_002416579);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal HeartGaugeTest _0024self__002416581;

		public _0024main_002416577(HeartGaugeTest self_)
		{
			_0024self__002416581 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416581);
		}
	}

	public MagicGauge gauge;

	public void Start()
	{
		StartCoroutine(main());
	}

	private IEnumerator main()
	{
		return new _0024main_002416577(this).GetEnumerator();
	}
}
