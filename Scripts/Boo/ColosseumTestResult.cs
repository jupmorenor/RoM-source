using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumTestResult : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002417420 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumSession _0024session_002417421;

			internal ColosseumTestResult _0024self__002417422;

			public _0024(ColosseumTestResult self_)
			{
				_0024self__002417422 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024session_002417421 = ColosseumSession.Instance;
					_0024session_002417421.closeSession();
					goto case 2;
				case 2:
					if (_0024session_002417421.IsClosing)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024session_002417421.IsClosed)
					{
						_0024self__002417422.resultResp = _0024session_002417421.Result;
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

		internal ColosseumTestResult _0024self__002417423;

		public _0024main_002417420(ColosseumTestResult self_)
		{
			_0024self__002417423 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417423);
		}
	}

	private RespColosseumBattleResult resultResp;

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
		return new _0024main_002417420(this).GetEnumerator();
	}

	public void OnGUI()
	{
		GUILayout.Label("Result");
		if (resultResp != null)
		{
			GUILayout.Label("  win=" + resultResp.Breeder.Win);
			GUILayout.Label("  loss=" + resultResp.Breeder.Loss);
			GUILayout.Label("  rankpoint=" + resultResp.Breeder.BreederRankPoint);
			GUILayout.Label("  rankid=" + resultResp.Breeder.BreederRankId);
		}
		else
		{
			GUILayout.Label("  requesting...");
		}
		if (GUILayout.Button("return"))
		{
			SceneChanger.Change("ColosseumMenuTest");
		}
	}
}
