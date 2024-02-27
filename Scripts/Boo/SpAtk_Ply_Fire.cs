using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class SpAtk_Ply_Fire : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002416723 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal SpAtk_Ply_Fire _0024self__002416724;

			public _0024(SpAtk_Ply_Fire self_)
			{
				_0024self__002416724 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416724.coli == null)
					{
						goto case 1;
					}
					_0024self__002416724.coli.radius = 0f;
					goto case 3;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					if (_0024self__002416724.coli.radius < 8f)
					{
						_0024self__002416724.coli.radius = _0024self__002416724.coli.radius + 0.2f;
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

		internal SpAtk_Ply_Fire _0024self__002416725;

		public _0024mainRoutine_002416723(SpAtk_Ply_Fire self_)
		{
			_0024self__002416725 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416725);
		}
	}

	public SphereCollider coli;

	[NonSerialized]
	private const float MAX_COLI_RADIUS = 8f;

	[NonSerialized]
	private const float COLI_RADIUS_CHANGE = 0.2f;

	public void Start()
	{
		StartCoroutine(mainRoutine());
	}

	public IEnumerator mainRoutine()
	{
		return new _0024mainRoutine_002416723(this).GetEnumerator();
	}
}
