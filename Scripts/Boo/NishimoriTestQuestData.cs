using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class NishimoriTestQuestData : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024masterDataCheck_002416588 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241125_002416589;

			internal MStories _0024s_002416590;

			internal MQuests _0024q_002416591;

			internal MScenes _0024stg_002416592;

			internal string _0024s_002416593;

			internal MStageBattles _0024b_002416594;

			internal MScenes _0024stg_002416595;

			internal int _0024_00248263_002416596;

			internal MQuests[] _0024_00248264_002416597;

			internal int _0024_00248265_002416598;

			internal int _0024_00248267_002416599;

			internal MStageBattles[] _0024_00248268_002416600;

			internal int _0024_00248269_002416601;

			internal int _0024_00248271_002416602;

			internal MScenes[] _0024_00248272_002416603;

			internal int _0024_00248273_002416604;

			internal int _0024_00248275_002416605;

			internal MScenes[] _0024_00248276_002416606;

			internal int _0024_00248277_002416607;

			internal IEnumerator _0024_0024iterator_002413452_002416608;

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024wait_sec_0024temp_00241125_002416589 = 0.5f;
						goto case 2;
					case 2:
						if (_0024_0024wait_sec_0024temp_00241125_002416589 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241125_002416589 -= Time.deltaTime;
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_0024iterator_002413452_002416608 = MStories.All.GetEnumerator();
						while (_0024_0024iterator_002413452_002416608.MoveNext())
						{
							object obj = _0024_0024iterator_002413452_002416608.Current;
							if (!(obj is MStories))
							{
								obj = RuntimeServices.Coerce(obj, typeof(MStories));
							}
							_0024s_002416590 = (MStories)obj;
						}
						_0024_00248263_002416596 = 0;
						_0024_00248264_002416597 = MQuests.All;
						for (_0024_00248265_002416598 = _0024_00248264_002416597.Length; _0024_00248263_002416596 < _0024_00248265_002416598; _0024_00248263_002416596++)
						{
						}
						_0024_00248271_002416602 = 0;
						_0024_00248272_002416603 = MScenes.All;
						for (_0024_00248273_002416604 = _0024_00248272_002416603.Length; _0024_00248271_002416602 < _0024_00248273_002416604; _0024_00248271_002416602++)
						{
							_0024s_002416593 = new StringBuilder("MScenes: id:").Append((object)_0024_00248272_002416603[_0024_00248271_002416602].Id).Append(" Progname:").Append(_0024_00248272_002416603[_0024_00248271_002416602].Progname)
								.Append(" battles -- ")
								.ToString();
							_0024_00248267_002416599 = 0;
							_0024_00248268_002416600 = _0024_00248272_002416603[_0024_00248271_002416602].AllStageBattles;
							for (_0024_00248269_002416601 = _0024_00248268_002416600.Length; _0024_00248267_002416599 < _0024_00248269_002416601; _0024_00248267_002416599++)
							{
								if (_0024_00248268_002416600[_0024_00248267_002416599] == null)
								{
									throw new AssertionFailedException("b != null");
								}
								_0024s_002416593 += new StringBuilder("<").Append((object)_0024_00248268_002416600[_0024_00248267_002416599].Id).Append(" ").Append(_0024_00248268_002416600[_0024_00248267_002416599].Progname)
									.Append("> ")
									.ToString();
							}
						}
						_0024_00248275_002416605 = 0;
						_0024_00248276_002416606 = MScenes.All;
						for (_0024_00248277_002416607 = _0024_00248276_002416606.Length; _0024_00248275_002416605 < _0024_00248277_002416607; _0024_00248275_002416605++)
						{
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
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
		StartCoroutine(masterDataCheck());
	}

	private IEnumerator masterDataCheck()
	{
		return new _0024masterDataCheck_002416588().GetEnumerator();
	}
}
