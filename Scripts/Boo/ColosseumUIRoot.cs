using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ColosseumUIRoot : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitCameraActive_002417424 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241492_002417425;

			internal ColosseumUIRoot _0024self__002417426;

			public _0024(ColosseumUIRoot self_)
			{
				_0024self__002417426 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241492_002417425 = _0024self__002417426.WaitForLoad();
					if (_0024_0024sco_0024temp_00241492_002417425 != null)
					{
						result = (Yield(2, _0024self__002417426.StartCoroutine(_0024_0024sco_0024temp_00241492_002417425)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__002417426.uiCamera.enabled = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumUIRoot _0024self__002417427;

		public _0024WaitCameraActive_002417424(ColosseumUIRoot self_)
		{
			_0024self__002417427 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417427);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartHUD_002417428 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241493_002417429;

			internal ColosseumUIRoot _0024self__002417430;

			public _0024(ColosseumUIRoot self_)
			{
				_0024self__002417430 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241493_002417429 = _0024self__002417430.battleStartHUD.Play();
					if (_0024_0024sco_0024temp_00241493_002417429 != null)
					{
						result = (Yield(2, _0024self__002417430.StartCoroutine(_0024_0024sco_0024temp_00241493_002417429)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					UnityEngine.Object.Destroy(_0024self__002417430.battleStartHUD.gameObject);
					_0024self__002417430.battleMainHUD.Show();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumUIRoot _0024self__002417431;

		public _0024StartHUD_002417428(ColosseumUIRoot self_)
		{
			_0024self__002417431 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417431);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitForLoad_002417432 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241494_002417433;

			internal ColosseumUIRoot _0024self__002417434;

			public _0024(ColosseumUIRoot self_)
			{
				_0024self__002417434 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241494_002417433 = _0024self__002417434.battleStartHUD.WaitForLoad();
					if (_0024_0024sco_0024temp_00241494_002417433 != null)
					{
						result = (Yield(2, _0024self__002417434.StartCoroutine(_0024_0024sco_0024temp_00241494_002417433)) ? 1 : 0);
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

		internal ColosseumUIRoot _0024self__002417435;

		public _0024WaitForLoad_002417432(ColosseumUIRoot self_)
		{
			_0024self__002417435 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417435);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResultHUD_002417436 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241495_002417437;

			internal IEnumerator _0024_0024sco_0024temp_00241496_002417438;

			internal bool _0024isWin_002417439;

			internal ColosseumUIRoot _0024self__002417440;

			public _0024(bool isWin, ColosseumUIRoot self_)
			{
				_0024isWin_002417439 = isWin;
				_0024self__002417440 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024isWin_002417439)
					{
						_0024_0024sco_0024temp_00241495_002417437 = _0024self__002417440.battleResultHUD.Win();
						if (_0024_0024sco_0024temp_00241495_002417437 != null)
						{
							result = (Yield(2, _0024self__002417440.StartCoroutine(_0024_0024sco_0024temp_00241495_002417437)) ? 1 : 0);
							break;
						}
					}
					else
					{
						_0024_0024sco_0024temp_00241496_002417438 = _0024self__002417440.battleResultHUD.Lose();
						if (_0024_0024sco_0024temp_00241496_002417438 != null)
						{
							result = (Yield(3, _0024self__002417440.StartCoroutine(_0024_0024sco_0024temp_00241496_002417438)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
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

		internal bool _0024isWin_002417441;

		internal ColosseumUIRoot _0024self__002417442;

		public _0024ResultHUD_002417436(bool isWin, ColosseumUIRoot self_)
		{
			_0024isWin_002417441 = isWin;
			_0024self__002417442 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024isWin_002417441, _0024self__002417442);
		}
	}

	[NonSerialized]
	public ColosseumBattleControl battleControl;

	public Camera uiCamera;

	public ColosseumBattleStartHUD battleStartHUD;

	public ColosseumBattleMainHUD battleMainHUD;

	public ColosseumBattleResultHUD battleResultHUD;

	public void Awake()
	{
		uiCamera.enabled = false;
	}

	public void Init(ColosseumBattleControl setBattleControl)
	{
		battleControl = setBattleControl;
		battleStartHUD.Init(battleControl);
		battleMainHUD.Init(battleControl);
		StartCoroutine(WaitCameraActive());
	}

	public IEnumerator WaitCameraActive()
	{
		return new _0024WaitCameraActive_002417424(this).GetEnumerator();
	}

	public void SetTeamData(ColosseumTeam setLeft, ColosseumTeam setRight)
	{
		battleStartHUD.SetTeamData(setLeft, setRight);
		battleMainHUD.SetTeamData(setLeft, setRight);
	}

	public IEnumerator StartHUD()
	{
		return new _0024StartHUD_002417428(this).GetEnumerator();
	}

	public IEnumerator WaitForLoad()
	{
		return new _0024WaitForLoad_002417432(this).GetEnumerator();
	}

	public IEnumerator ResultHUD(bool isWin)
	{
		return new _0024ResultHUD_002417436(isWin, this).GetEnumerator();
	}
}
