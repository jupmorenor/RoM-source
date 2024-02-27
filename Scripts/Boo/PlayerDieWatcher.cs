using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PlayerDieWatcher : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024die_002418437 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241661_002418438;

			internal QuestClearConditionChecker _0024qcc_002418439;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_sec_0024temp_00241661_002418438 = 3f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241661_002418438 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241661_002418438 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024qcc_002418439 = QuestClearConditionChecker.Instance;
					_0024qcc_002418439.doFail();
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

	private bool failed;

	public void Update()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer == null) && currentPlayer.IsDead && !failed)
		{
			failed = true;
			IEnumerator enumerator = die();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator die()
	{
		return new _0024die_002418437().GetEnumerator();
	}
}
