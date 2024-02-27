using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ColosseumBattleResultHUD : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Win_002417376 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ColosseumBattleResultHUD _0024self__002417377;

			public _0024(ColosseumBattleResultHUD self_)
			{
				_0024self__002417377 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__002417377.resultDelay)) ? 1 : 0);
					break;
				case 2:
					GameSoundManager.PlaySeJingle(_0024self__002417377.winSE, 0, resumeBgm: false);
					_0024self__002417377.win.SetActive(value: true);
					result = (Yield(3, new WaitForSeconds(_0024self__002417377.resultWait)) ? 1 : 0);
					break;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumBattleResultHUD _0024self__002417378;

		public _0024Win_002417376(ColosseumBattleResultHUD self_)
		{
			_0024self__002417378 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002417378);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Lose_002417379 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ColosseumBattleResultHUD _0024self__002417380;

			public _0024(ColosseumBattleResultHUD self_)
			{
				_0024self__002417380 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024self__002417380.resultDelay)) ? 1 : 0);
					break;
				case 2:
					GameSoundManager.PlaySeJingle(_0024self__002417380.loseSE, 0, resumeBgm: false);
					_0024self__002417380.lose.SetActive(value: true);
					result = (Yield(3, new WaitForSeconds(_0024self__002417380.resultWait)) ? 1 : 0);
					break;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumBattleResultHUD _0024self__002417381;

		public _0024Lose_002417379(ColosseumBattleResultHUD self_)
		{
			_0024self__002417381 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002417381);
		}
	}

	public GameObject win;

	public string winSE;

	public GameObject lose;

	public string loseSE;

	public float resultDelay;

	public float resultWait;

	private GameSoundManager sndmgr;

	public ColosseumBattleResultHUD()
	{
		winSE = "se_arena_fight_win";
		loseSE = "se_arena_fight_lose";
		resultDelay = 2f;
		resultWait = 3f;
	}

	public void Awake()
	{
		sndmgr = GameSoundManager.Instance;
		sndmgr.LoadSe(winSE);
		sndmgr.LoadSe(loseSE);
		win.SetActive(value: false);
		lose.SetActive(value: false);
	}

	public void OnDestroy()
	{
		sndmgr.UnloadSe(winSE);
		sndmgr.UnloadSe(loseSE);
	}

	public IEnumerator Win()
	{
		return new _0024Win_002417376(this).GetEnumerator();
	}

	public IEnumerator Lose()
	{
		return new _0024Lose_002417379(this).GetEnumerator();
	}
}
