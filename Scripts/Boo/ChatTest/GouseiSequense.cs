using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using S540;

namespace ChatTest;

[Serializable]
public class GouseiSequense : GouseiBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_init_002415631 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00245_002415632;

			internal object _0024___item_002415633;

			internal IEnumerator _0024_0024iterator_002413306_002415634;

			internal GouseiSequense _0024self__002415635;

			public _0024(GouseiSequense self_)
			{
				_0024self__002415635 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00245_002415632 = _0024self__002415635.S540_init(null);
					if (_0024_0024s540_0024ycode_00245_002415632 != null)
					{
						_0024_0024iterator_002413306_002415634 = _0024_0024s540_0024ycode_00245_002415632;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413306_002415634.MoveNext())
					{
						_0024___item_002415633 = _0024_0024iterator_002413306_002415634.Current;
						result = (Yield(2, _0024___item_002415633) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GouseiSequense _0024self__002415636;

		public _0024S540_init_002415631(GouseiSequense self_)
		{
			_0024self__002415636 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415636);
		}
	}

	public IEnumerator S540_init()
	{
		return new _0024S540_init_002415631(this).GetEnumerator();
	}

	public IEnumerator S540_init(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_init";
		Exec e = lastCreatedExec;
		Init();
		stop(e);
		return null;
	}

	protected override void startInitialState()
	{
		object obj = null;
		object obj2 = obj;
		if (!(obj2 is Exec))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Exec));
		}
		dtrace((Exec)obj2, "GouseiSequense.boo:10", "go命令 " + CurrentStateName + "->" + "S540_init" + "(" + string.Empty + ")");
		Exec e = createExecAsCurrent("S540_init");
		IEnumerator r = S540_init();
		entryCoroutine(e, r);
	}
}
