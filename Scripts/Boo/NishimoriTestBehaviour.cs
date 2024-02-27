using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class NishimoriTestBehaviour : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416586 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiPlatformExtServer _0024req_002416587;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002416587 = new ApiPlatformExtServer();
					MerlinServer.Request(_0024req_002416587);
					goto case 2;
				case 2:
					if (!_0024req_002416587.IsEnd)
					{
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002416586().GetEnumerator();
	}
}
