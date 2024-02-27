using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MyHomeProfileMain : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421806 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MyHomeProfileMain _0024self__002421807;

			public _0024(MyHomeProfileMain self_)
			{
				_0024self__002421807 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421807.count < 100)
					{
						_0024self__002421807.count = checked(_0024self__002421807.count + 1);
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

		internal MyHomeProfileMain _0024self__002421808;

		public _0024main_002421806(MyHomeProfileMain self_)
		{
			_0024self__002421808 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421808);
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
		return new _0024main_002421806(this).GetEnumerator();
	}
}
