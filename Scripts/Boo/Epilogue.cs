using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Epilogue : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421665 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242606_002421666;

			internal Epilogue _0024self__002421667;

			public _0024(Epilogue self_)
			{
				_0024self__002421667 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00242606_002421666 = _0024self__002421667.fadeIn();
					if (_0024_0024sco_0024temp_00242606_002421666 != null)
					{
						result = (Yield(2, _0024self__002421667.StartCoroutine(_0024_0024sco_0024temp_00242606_002421666)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Epilogue _0024self__002421668;

		public _0024main_002421665(Epilogue self_)
		{
			_0024self__002421668 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421668);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024fadeIn_002421669 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal FaderCore _0024fader_002421670;

			internal PrologueMain _0024prmain_002421671;

			internal Epilogue _0024self__002421672;

			public _0024(Epilogue self_)
			{
				_0024self__002421672 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024fader_002421670 = FaderCore.Instance;
					_0024fader_002421670.fadeOutEx(0f, 0f, 0f, 0.5f);
					goto case 2;
				case 2:
					if (!_0024fader_002421670.isCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024prmain_002421671 = null;
					goto case 3;
				case 3:
					_0024prmain_002421671 = (PrologueMain)UnityEngine.Object.FindObjectOfType(typeof(PrologueMain));
					if (_0024prmain_002421671 != null)
					{
						goto case 4;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 4:
					if (!_0024prmain_002421671.IsEndOfPlay)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002421672.outLastMessage();
					SceneChanger.Change("Town");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Epilogue _0024self__002421673;

		public _0024fadeIn_002421669(Epilogue self_)
		{
			_0024self__002421673 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421673);
		}
	}

	public string[] finalMessagesFromUs;

	private void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002421665(this).GetEnumerator();
	}

	private IEnumerator fadeIn()
	{
		return new _0024fadeIn_002421669(this).GetEnumerator();
	}

	private void outLastMessage()
	{
		if (finalMessagesFromUs == null)
		{
			return;
		}
		int i = 0;
		string[] array = finalMessagesFromUs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!string.IsNullOrEmpty(array[i]))
			{
				Debug.Log(array[i]);
			}
		}
	}
}
