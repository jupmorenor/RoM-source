using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class InitializeTest : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416582 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_002416583;

			internal float _0024_0024wait_sec_0024temp_00241123_002416584;

			internal int _0024_00248238_002416585;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_00248238_002416585 = 0;
					goto IL_0099;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241123_002416584 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241123_002416584 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0099;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0099:
					if (_0024_00248238_002416585 < 10)
					{
						_0024i_002416583 = _0024_00248238_002416585;
						_0024_00248238_002416585++;
						TestFlightUnity.PassCheckpoint(new StringBuilder("check point ").Append((object)_0024i_002416583).ToString());
						_0024_0024wait_sec_0024temp_00241123_002416584 = 1f;
						goto case 2;
					}
					TestFlightUnity.PassCheckpoint("check point end");
					YieldDefault(1);
					goto case 1;
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

	public GameObject[] objs;

	private float myTime;

	public void Start()
	{
		TestFlightUnity.TakeOff("a2631b3a-7d79-4336-8015-c8a487e8b44f");
		StartCoroutine(main());
	}

	public void Update()
	{
		myTime += Time.deltaTime;
		if (!(myTime <= 20f))
		{
			GameObject gameObject = null;
			gameObject.SetActive(value: true);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002416582().GetEnumerator();
	}

	public void OnGUI()
	{
		int num = 50;
		Rect position = new Rect(100f, num, 200f, 32f);
		checked
		{
			num += 80;
			GUI.Label(position, "time=" + myTime);
			position = new Rect(100f, num, 200f, 32f);
			num += 32;
			GUI.Label(position, "Initialize OK! : obj num=" + objs.Length);
			int i = 0;
			GameObject[] array = objs;
			for (int length = array.Length; i < length; i++)
			{
				position = new Rect(100f, num, 200f, 32f);
				num += 32;
				GUI.Label(position, "obj=" + array[i]);
			}
		}
	}
}
