using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PlayAllAnimations : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416572 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AnimationState _0024clip_002416573;

			internal IEnumerator _0024_0024iterator_002413451_002416574;

			internal PlayAllAnimations _0024self__002416575;

			public _0024(PlayAllAnimations self_)
			{
				_0024self__002416575 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024iterator_002413451_002416574 = _0024self__002416575.animation.GetEnumerator();
					goto IL_00cd;
				case 2:
					if (_0024self__002416575.animation.isPlaying)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416575.animation.Stop();
					_0024self__002416575.animation.Play(_0024clip_002416573.name, PlayMode.StopAll);
					_0024self__002416575.n = checked(_0024self__002416575.n + 1);
					goto IL_00cd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00cd:
					if (_0024_0024iterator_002413451_002416574.MoveNext())
					{
						object obj = _0024_0024iterator_002413451_002416574.Current;
						if (!(obj is AnimationState))
						{
							obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
						}
						_0024clip_002416573 = (AnimationState)obj;
						goto case 2;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayAllAnimations _0024self__002416576;

		public _0024main_002416572(PlayAllAnimations self_)
		{
			_0024self__002416576 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416576);
		}
	}

	protected int n;

	public void Start()
	{
		StartCoroutine(main());
	}

	public IEnumerator main()
	{
		return new _0024main_002416572(this).GetEnumerator();
	}

	public void OnGUI()
	{
		GUI.Label(new Rect(130f, 10f, 100f, 20f), new StringBuilder("N=").Append((object)n).Append("/").Append((object)animation.GetClipCount())
			.ToString());
	}
}
