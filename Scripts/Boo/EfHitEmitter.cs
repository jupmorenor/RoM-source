using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using GameAsset;
using UnityEngine;

[Serializable]
public class EfHitEmitter : Ef_Base
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002419765 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241856_002419766;

			internal GameObject _0024ef_002419767;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_sec_0024temp_00241856_002419766 = 3f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241856_002419766 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241856_002419766 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024ef_002419767 = GameAssetModule.InstantiatePrefab("Prefab/Effect/Ef_Hit");
					goto case 3;
				case 3:
					if (!(_0024ef_002419767 == null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	public void Start()
	{
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		StartCoroutine(main());
	}

	private IEnumerator main()
	{
		return new _0024main_002419765().GetEnumerator();
	}
}
