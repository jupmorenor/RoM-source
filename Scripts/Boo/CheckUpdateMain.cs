using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class CheckUpdateMain : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421552 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
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

	public int count;

	public void Start()
	{
		count = 0;
		StartCoroutine(main());
	}

	private IEnumerator main()
	{
		return new _0024main_002421552().GetEnumerator();
	}
}
