using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Ef_Twister_Collider : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024attackColiRoutine_002415372 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_0024674_002415373;

			internal Ef_Twister_Collider _0024self__002415374;

			public _0024(Ef_Twister_Collider self_)
			{
				_0024self__002415374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002415374.collider)
					{
						_0024self__002415374.collider.enabled = true;
					}
					_0024_0024wait_sec_0024temp_0024674_002415373 = 0.1f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_0024674_002415373 > 0f)
					{
						_0024_0024wait_sec_0024temp_0024674_002415373 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if ((bool)_0024self__002415374.collider)
					{
						_0024self__002415374.collider.enabled = false;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Ef_Twister_Collider _0024self__002415375;

		public _0024attackColiRoutine_002415372(Ef_Twister_Collider self_)
		{
			_0024self__002415375 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415375);
		}
	}

	public void Start()
	{
		StartCoroutine(attackColiRoutine());
	}

	private IEnumerator attackColiRoutine()
	{
		return new _0024attackColiRoutine_002415372(this).GetEnumerator();
	}
}
