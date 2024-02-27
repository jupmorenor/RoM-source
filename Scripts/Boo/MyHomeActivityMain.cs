using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MyHomeActivityMain : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421717 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MyHomeActivityMain _0024self__002421718;

			public _0024(MyHomeActivityMain self_)
			{
				_0024self__002421718 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421718.count < 100)
					{
						_0024self__002421718.count = checked(_0024self__002421718.count + 1);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					SceneChanger.ChangeTo(SceneID.Ui_CheckUpdate);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeActivityMain _0024self__002421719;

		public _0024main_002421717(MyHomeActivityMain self_)
		{
			_0024self__002421719 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421719);
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
		return new _0024main_002421717(this).GetEnumerator();
	}
}
