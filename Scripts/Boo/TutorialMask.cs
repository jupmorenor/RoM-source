using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Camera))]
public class TutorialMask : MonoBehaviour
{
	[Serializable]
	public enum Operation
	{
		FADE_IN,
		FADE_OUT
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421216 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal TutorialMask _0024self__002421217;

			public _0024(TutorialMask self_)
			{
				_0024self__002421217 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421217.ope != 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421217.cam.enabled = true;
					goto case 3;
				case 3:
					if (!(_0024self__002421217.alpha >= 1f) && _0024self__002421217.ope == Operation.FADE_IN)
					{
						_0024self__002421217.alpha += Time.deltaTime / _0024self__002421217.FadeTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					if (_0024self__002421217.ope != Operation.FADE_OUT)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					if (!(_0024self__002421217.alpha <= 0f) && _0024self__002421217.ope == Operation.FADE_OUT)
					{
						_0024self__002421217.alpha -= Time.deltaTime / _0024self__002421217.FadeTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002421217.cam.enabled = false;
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialMask _0024self__002421218;

		public _0024main_002421216(TutorialMask self_)
		{
			_0024self__002421218 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421218);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024debug_002421219 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242463_002421220;

			internal float _0024_0024wait_sec_0024temp_00242464_002421221;

			internal float _0024_0024wait_sec_0024temp_00242465_002421222;

			internal float _0024_0024wait_sec_0024temp_00242466_002421223;

			internal TutorialMask _0024self__002421224;

			public _0024(TutorialMask self_)
			{
				_0024self__002421224 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421224.FadeTime = 1f;
					_0024_0024wait_sec_0024temp_00242463_002421220 = 3f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242463_002421220 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242463_002421220 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421224.Fade = true;
					_0024_0024wait_sec_0024temp_00242464_002421221 = 3f;
					goto case 3;
				case 3:
					if (_0024_0024wait_sec_0024temp_00242464_002421221 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242464_002421221 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002421224.Fade = false;
					_0024_0024wait_sec_0024temp_00242465_002421222 = 3f;
					goto case 4;
				case 4:
					if (_0024_0024wait_sec_0024temp_00242465_002421222 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242465_002421222 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002421224.Fade = true;
					_0024_0024wait_sec_0024temp_00242466_002421223 = 0.5f;
					goto case 5;
				case 5:
					if (_0024_0024wait_sec_0024temp_00242466_002421223 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242466_002421223 -= Time.deltaTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002421224.Fade = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialMask _0024self__002421225;

		public _0024debug_002421219(TutorialMask self_)
		{
			_0024self__002421225 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421225);
		}
	}

	public float FadeTime;

	private Operation ope;

	public bool Fade
	{
		get
		{
			return ope == Operation.FADE_IN;
		}
		set
		{
			ope = ((!value) ? Operation.FADE_OUT : Operation.FADE_IN);
		}
	}

	protected Camera cam => GetComponent<Camera>();

	protected float alpha
	{
		get
		{
			return cam.backgroundColor.a;
		}
		set
		{
			float a = Mathf.Clamp(value, 0f, 1f);
			Color backgroundColor = cam.backgroundColor;
			float num = (backgroundColor.a = a);
			Color color2 = (cam.backgroundColor = backgroundColor);
		}
	}

	public TutorialMask()
	{
		FadeTime = 0.5f;
		ope = Operation.FADE_OUT;
	}

	public void Start()
	{
		cam.clearFlags = CameraClearFlags.Color;
		cam.backgroundColor = new Color(0f, 0f, 0f, 0f);
		cam.enabled = false;
		StartCoroutine(main());
		StartCoroutine(debug());
	}

	private IEnumerator main()
	{
		return new _0024main_002421216(this).GetEnumerator();
	}

	private IEnumerator debug()
	{
		return new _0024debug_002421219(this).GetEnumerator();
	}
}
