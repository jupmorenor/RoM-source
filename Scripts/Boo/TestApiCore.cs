using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using MerlinAPI;
using SharpUnit;
using UnityEngine;

[Serializable]
public class TestApiCore : MerlinApiTestCase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestPlatformExtServer_002422566 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPlatformExtServer _0024req1_002422567;

			internal ApiPlatformExtServer _0024req2_002422568;

			internal TestApiCore _0024self__002422569;

			public _0024(TestApiCore self_)
			{
				_0024self__002422569 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422567 = new ApiPlatformExtServer();
					result = (Yield(2, _0024self__002422569.runner.StartCoroutine(_0024self__002422569.WaitRequest(_0024req1_002422567))) ? 1 : 0);
					break;
				case 2:
					_0024req2_002422568 = new ApiPlatformExtServer();
					result = (Yield(3, _0024self__002422569.runner.StartCoroutine(_0024self__002422569.WaitRequest(_0024req2_002422568))) ? 1 : 0);
					break;
				case 3:
					try
					{
						Assert.True(_0024req1_002422567.IsOk, new StringBuilder().Append("サーバー情報が取得できません").Append("\n ").Append(_0024self__002422569.readResponeString(_0024req1_002422567))
							.ToString());
						Assert.True(_0024req2_002422568.IsOk, new StringBuilder().Append("already requested PlatformExtServer").Append("\n ").Append(_0024self__002422569.readResponeString(_0024req2_002422568))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422569.MarkAsFailure(e);
					}
					_0024self__002422569.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422570;

		public _0024TestPlatformExtServer_002422566(TestApiCore self_)
		{
			_0024self__002422570 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422570);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestCreateUser_002422571 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiEcho _0024req1_002422572;

			internal ApiPlatformExtServer _0024req2_002422573;

			internal ApiEntryCreateUser _0024_00245230_002422574;

			internal ApiEntryCreateUser _0024req3_002422575;

			internal TestApiCore _0024self__002422576;

			public _0024(TestApiCore self_)
			{
				_0024self__002422576 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					CurrentInfo.Clear();
					_0024req1_002422572 = new ApiEcho();
					result = (Yield(2, _0024self__002422576.runner.StartCoroutine(_0024self__002422576.WaitRequest(_0024req1_002422572))) ? 1 : 0);
					break;
				case 2:
					_0024req2_002422573 = new ApiPlatformExtServer();
					result = (Yield(3, _0024self__002422576.runner.StartCoroutine(_0024self__002422576.WaitRequest(_0024req2_002422573))) ? 1 : 0);
					break;
				case 3:
				{
					ApiEntryCreateUser apiEntryCreateUser = (_0024_00245230_002422574 = new ApiEntryCreateUser());
					string text = (_0024_00245230_002422574.name = "自動テスト君");
					_0024req3_002422575 = _0024_00245230_002422574;
					result = (Yield(4, _0024self__002422576.runner.StartCoroutine(_0024self__002422576.WaitRequest(_0024req3_002422575))) ? 1 : 0);
					break;
				}
				case 4:
					try
					{
						Assert.True(_0024req1_002422572.IsOk, new StringBuilder().Append("ApiEcho failed").Append("\n ").Append(_0024self__002422576.readResponeString(_0024req1_002422572))
							.ToString());
						Assert.True(_0024req2_002422573.IsOk, new StringBuilder().Append("ApiPlatformExtServer failed").Append("\n ").Append(_0024self__002422576.readResponeString(_0024req2_002422573))
							.ToString());
						Assert.True(_0024req3_002422575.IsOk, new StringBuilder().Append("ApiEntryCreateUser failed").Append("\n ").Append(_0024self__002422576.readResponeString(_0024req3_002422575))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422576.MarkAsFailure(e);
					}
					_0024self__002422576.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422577;

		public _0024TestCreateUser_002422571(TestApiCore self_)
		{
			_0024self__002422577 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422577);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiCreateCharacter_002422578 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPlatformAccessInfo _0024req1_002422579;

			internal ApiCreateCharacter _0024_00245231_002422580;

			internal ApiCreateCharacter _0024req2_002422581;

			internal ApiIsCreate _0024req3_002422582;

			internal TestApiCore _0024self__002422583;

			public _0024(TestApiCore self_)
			{
				_0024self__002422583 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422579 = new ApiPlatformAccessInfo();
					result = (Yield(2, _0024self__002422583.runner.StartCoroutine(_0024self__002422583.WaitRequest(_0024req1_002422579))) ? 1 : 0);
					break;
				case 2:
				{
					ApiCreateCharacter apiCreateCharacter = (_0024_00245231_002422580 = new ApiCreateCharacter());
					string text = (_0024_00245231_002422580.AngelName = "an");
					string text2 = (_0024_00245231_002422580.DemonName = "dm");
					int num = (_0024_00245231_002422580.AngelGender = 1);
					int num2 = (_0024_00245231_002422580.DemonGender = 2);
					_0024req2_002422581 = _0024_00245231_002422580;
					result = (Yield(3, _0024self__002422583.runner.StartCoroutine(_0024self__002422583.WaitRequest(_0024req2_002422581))) ? 1 : 0);
					break;
				}
				case 3:
					_0024req3_002422582 = new ApiIsCreate();
					result = (Yield(4, _0024self__002422583.runner.StartCoroutine(_0024self__002422583.WaitRequest(_0024req3_002422582))) ? 1 : 0);
					break;
				case 4:
					try
					{
						Assert.True(_0024req1_002422579.IsOk, new StringBuilder().Append("アクセストークンが取得できません").Append("\n ").Append(_0024self__002422583.readResponeString(_0024req1_002422579))
							.ToString());
						Assert.True(_0024req2_002422581.IsOk, new StringBuilder().Append("キャラ作成失敗").Append("\n ").Append(_0024self__002422583.readResponeString(_0024req2_002422581))
							.ToString());
						Assert.True(_0024req3_002422582.GetResponse().Created, new StringBuilder().Append("既にキャラ作成済みかの確認").Append("\n ").Append(_0024self__002422583.readResponeString(_0024req3_002422582))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422583.MarkAsFailure(e);
					}
					_0024self__002422583.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422584;

		public _0024TestApiCreateCharacter_002422578(TestApiCore self_)
		{
			_0024self__002422584 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422584);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiHome_002422585 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHome _0024req1_002422586;

			internal ApiHomeSlim _0024req2_002422587;

			internal TestApiCore _0024self__002422588;

			public _0024(TestApiCore self_)
			{
				_0024self__002422588 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422586 = new ApiHome();
					result = (Yield(2, _0024self__002422588.runner.StartCoroutine(_0024self__002422588.WaitRequest(_0024req1_002422586))) ? 1 : 0);
					break;
				case 2:
					_0024req2_002422587 = new ApiHomeSlim();
					result = (Yield(3, _0024self__002422588.runner.StartCoroutine(_0024self__002422588.WaitRequest(_0024req2_002422587))) ? 1 : 0);
					break;
				case 3:
					try
					{
						Assert.True(_0024req1_002422586.IsOk, new StringBuilder().Append("ApiHome()").Append("\n ").Append(_0024self__002422588.readResponeString(_0024req1_002422586))
							.ToString());
						Assert.True(_0024req2_002422587.IsOk, new StringBuilder().Append("ApiHomeSlim()").Append("\n ").Append(_0024self__002422588.readResponeString(_0024req2_002422587))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422588.MarkAsFailure(e);
					}
					_0024self__002422588.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422589;

		public _0024TestApiHome_002422585(TestApiCore self_)
		{
			_0024self__002422589 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422589);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiPlayer_002422590 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPlayer _0024req1_002422591;

			internal TestApiCore _0024self__002422592;

			public _0024(TestApiCore self_)
			{
				_0024self__002422592 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422591 = new ApiPlayer();
					result = (Yield(2, _0024self__002422592.runner.StartCoroutine(_0024self__002422592.WaitRequest(_0024req1_002422591))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422591.IsOk, new StringBuilder().Append("ApiPlayer").Append("\n ").Append(_0024self__002422592.readResponeString(_0024req1_002422591))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422592.MarkAsFailure(e);
					}
					_0024self__002422592.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422593;

		public _0024TestApiPlayer_002422590(TestApiCore self_)
		{
			_0024self__002422593 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422593);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiUpdateTutorial_002422594 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiUpdateTutorial _0024_00245232_002422595;

			internal ApiUpdateTutorial _0024req1_002422596;

			internal ApiUpdateTutorial _0024_00245233_002422597;

			internal ApiUpdateTutorial _0024req2_002422598;

			internal ApiUpdateTutorial _0024_00245234_002422599;

			internal ApiUpdateTutorial _0024req3_002422600;

			internal ApiUpdateTutorial _0024_00245235_002422601;

			internal ApiUpdateTutorial _0024req4_002422602;

			internal ApiUpdateTutorial _0024_00245236_002422603;

			internal ApiUpdateTutorial _0024req5_002422604;

			internal ApiUpdateTutorial _0024_00245237_002422605;

			internal ApiUpdateTutorial _0024req6_002422606;

			internal ApiUpdateTutorial _0024_00245238_002422607;

			internal ApiUpdateTutorial _0024req7_002422608;

			internal ApiUpdateTutorial _0024_00245239_002422609;

			internal ApiUpdateTutorial _0024req8_002422610;

			internal TestApiCore _0024self__002422611;

			public _0024(TestApiCore self_)
			{
				_0024self__002422611 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					ApiUpdateTutorial apiUpdateTutorial = (_0024_00245232_002422595 = new ApiUpdateTutorial());
					int num = (_0024_00245232_002422595.TutorialStep = 0);
					_0024req1_002422596 = _0024_00245232_002422595;
					result = (Yield(2, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req1_002422596))) ? 1 : 0);
					break;
				}
				case 2:
				{
					ApiUpdateTutorial apiUpdateTutorial8 = (_0024_00245233_002422597 = new ApiUpdateTutorial());
					int num8 = (_0024_00245233_002422597.TutorialStep = 1);
					_0024req2_002422598 = _0024_00245233_002422597;
					result = (Yield(3, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req2_002422598))) ? 1 : 0);
					break;
				}
				case 3:
				{
					ApiUpdateTutorial apiUpdateTutorial7 = (_0024_00245234_002422599 = new ApiUpdateTutorial());
					int num7 = (_0024_00245234_002422599.TutorialStep = 10);
					_0024req3_002422600 = _0024_00245234_002422599;
					result = (Yield(4, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req3_002422600))) ? 1 : 0);
					break;
				}
				case 4:
				{
					ApiUpdateTutorial apiUpdateTutorial6 = (_0024_00245235_002422601 = new ApiUpdateTutorial());
					int num6 = (_0024_00245235_002422601.TutorialStep = 25);
					_0024req4_002422602 = _0024_00245235_002422601;
					result = (Yield(5, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req4_002422602))) ? 1 : 0);
					break;
				}
				case 5:
				{
					ApiUpdateTutorial apiUpdateTutorial5 = (_0024_00245236_002422603 = new ApiUpdateTutorial());
					int num5 = (_0024_00245236_002422603.TutorialStep = 500);
					_0024req5_002422604 = _0024_00245236_002422603;
					result = (Yield(6, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req5_002422604))) ? 1 : 0);
					break;
				}
				case 6:
				{
					ApiUpdateTutorial apiUpdateTutorial4 = (_0024_00245237_002422605 = new ApiUpdateTutorial());
					int num4 = (_0024_00245237_002422605.TutorialStep = 501);
					_0024req6_002422606 = _0024_00245237_002422605;
					result = (Yield(7, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req6_002422606))) ? 1 : 0);
					break;
				}
				case 7:
				{
					ApiUpdateTutorial apiUpdateTutorial3 = (_0024_00245238_002422607 = new ApiUpdateTutorial());
					int num3 = (_0024_00245238_002422607.TutorialStep = 256);
					_0024req7_002422608 = _0024_00245238_002422607;
					result = (Yield(8, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req7_002422608))) ? 1 : 0);
					break;
				}
				case 8:
				{
					ApiUpdateTutorial apiUpdateTutorial2 = (_0024_00245239_002422609 = new ApiUpdateTutorial());
					int num2 = (_0024_00245239_002422609.TutorialStep = 65536);
					_0024req8_002422610 = _0024_00245239_002422609;
					result = (Yield(9, _0024self__002422611.runner.StartCoroutine(_0024self__002422611.WaitRequest(_0024req8_002422610))) ? 1 : 0);
					break;
				}
				case 9:
					try
					{
						Assert.Equal(_0024self__002422611.lookStatusCodeInReq(_0024req1_002422596), "CoApi001", new StringBuilder().Append("チュートリアルステップ 範囲外な0を指定").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req1_002422596))
							.ToString());
						Assert.True(_0024req2_002422598.IsOk, new StringBuilder().Append("チュートリアルステップ1").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req2_002422598))
							.ToString());
						Assert.True(_0024req3_002422600.IsOk, new StringBuilder().Append("チュートリアルステップ10").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req3_002422600))
							.ToString());
						Assert.True(_0024req4_002422602.IsOk, new StringBuilder().Append("チュートリアルステップ25").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req4_002422602))
							.ToString());
						Assert.True(_0024req5_002422604.IsOk, new StringBuilder().Append("チュートリアルステップ 500 全て完了").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req5_002422604))
							.ToString());
						Assert.Equal(_0024self__002422611.lookStatusCodeInReq(_0024req6_002422606), "PlTuu003", new StringBuilder().Append("チュートリアルステップ最大値以上(501)を指定").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req6_002422606))
							.ToString());
						Assert.Equal(_0024self__002422611.lookStatusCodeInReq(_0024req7_002422608), "PlTuu002", new StringBuilder().Append("チュートリアルステップ巻き戻し").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req7_002422608))
							.ToString());
						Assert.Equal(_0024self__002422611.lookStatusCodeInReq(_0024req8_002422610), "PlTuu003", new StringBuilder().Append("チュートリアルステップでかい値を指定").Append("\n ").Append(_0024self__002422611.readResponeString(_0024req8_002422610))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422611.MarkAsFailure(e);
					}
					_0024self__002422611.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422612;

		public _0024TestApiUpdateTutorial_002422594(TestApiCore self_)
		{
			_0024self__002422612 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422612);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiUpdateActionPoint_002422613 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiUpdateActionPoint _0024req1_002422614;

			internal TestApiCore _0024self__002422615;

			public _0024(TestApiCore self_)
			{
				_0024self__002422615 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422614 = new ApiUpdateActionPoint();
					result = (Yield(2, _0024self__002422615.runner.StartCoroutine(_0024self__002422615.WaitRequest(_0024req1_002422614))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422614.IsOk, new StringBuilder().Append("AP 回復").Append("\n ").Append(_0024self__002422615.readResponeString(_0024req1_002422614))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422615.MarkAsFailure(e);
					}
					_0024self__002422615.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422616;

		public _0024TestApiUpdateActionPoint_002422613(TestApiCore self_)
		{
			_0024self__002422616 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422616);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiUpdateRaidPoint_002422617 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiUpdateRaidPoint _0024req1_002422618;

			internal TestApiCore _0024self__002422619;

			public _0024(TestApiCore self_)
			{
				_0024self__002422619 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422618 = new ApiUpdateRaidPoint();
					result = (Yield(2, _0024self__002422619.runner.StartCoroutine(_0024self__002422619.WaitRequest(_0024req1_002422618))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422618.IsOk, new StringBuilder().Append("RP 回復").Append("\n ").Append(_0024self__002422619.readResponeString(_0024req1_002422618))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422619.MarkAsFailure(e);
					}
					_0024self__002422619.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422620;

		public _0024TestApiUpdateRaidPoint_002422617(TestApiCore self_)
		{
			_0024self__002422620 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422620);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiUpdateDeck_002422621 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiUpdateDeck _0024req1_002422622;

			internal TestApiCore _0024self__002422623;

			public _0024(TestApiCore self_)
			{
				_0024self__002422623 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422622 = new ApiUpdateDeck();
					result = (Yield(2, _0024self__002422623.runner.StartCoroutine(_0024self__002422623.WaitRequest(_0024req1_002422622))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422622.IsOk, new StringBuilder().Append("デッキ変更").Append("\n ").Append(_0024self__002422623.readResponeString(_0024req1_002422622))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422623.MarkAsFailure(e);
					}
					_0024self__002422623.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422624;

		public _0024TestApiUpdateDeck_002422621(TestApiCore self_)
		{
			_0024self__002422624 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422624);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiPurchaseProductIdList_002422625 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPurchaseProductIdList _0024req1_002422626;

			internal ApiPurchaseVerify _0024req2_002422627;

			internal List _0024reqs_002422628;

			internal RespInAppProduct _0024info_002422629;

			internal ApiPurchaseVerify _0024req_002422630;

			internal int _0024_002411996_002422631;

			internal RespInAppProduct[] _0024_002411997_002422632;

			internal int _0024_002411998_002422633;

			internal TestApiCore _0024self__002422634;

			public _0024(TestApiCore self_)
			{
				_0024self__002422634 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024req1_002422626 = new ApiPurchaseProductIdList();
						result = (Yield(2, _0024self__002422634.runner.StartCoroutine(_0024self__002422634.WaitRequest(_0024req1_002422626))) ? 1 : 0);
						break;
					case 2:
						_0024req2_002422627 = new ApiPurchaseVerify();
						result = (Yield(3, _0024self__002422634.runner.StartCoroutine(_0024self__002422634.WaitRequest(_0024req2_002422627))) ? 1 : 0);
						break;
					case 3:
						_0024reqs_002422628 = new List();
						_0024_002411996_002422631 = 0;
						_0024_002411997_002422632 = _0024req1_002422626.GetResponse().ProductInfo;
						_0024_002411998_002422633 = _0024_002411997_002422632.Length;
						goto IL_0246;
					case 4:
						_0024reqs_002422628.Add(_0024req_002422630);
						_0024_002411996_002422631++;
						goto IL_0246;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0246:
						if (_0024_002411996_002422631 < _0024_002411998_002422633)
						{
							_0024self__002422634.logging(new StringBuilder("PRODUCT: ").Append((object)_0024_002411997_002422632[_0024_002411996_002422631].Id).Append("/").Append(_0024_002411997_002422632[_0024_002411996_002422631].ProductIdCode)
								.Append("/")
								.Append(_0024_002411997_002422632[_0024_002411996_002422631].Name)
								.Append("/")
								.Append((object)_0024_002411997_002422632[_0024_002411996_002422631].Price)
								.Append("/")
								.Append((object)_0024_002411997_002422632[_0024_002411996_002422631].Quantity)
								.ToString());
							_0024req_002422630 = new ApiPurchaseVerify();
							_0024req_002422630.ProductId = _0024_002411997_002422632[_0024_002411996_002422631].ProductIdCode;
							_0024req_002422630.Receipt = "hoge";
							_0024req_002422630.Signature = string.Empty;
							_0024req_002422630.TransactionId = string.Empty;
							_0024req_002422630.PurchaseDate = DateTime.UtcNow;
							result = (Yield(4, _0024self__002422634.runner.StartCoroutine(_0024self__002422634.WaitRequest(_0024req_002422630))) ? 1 : 0);
							break;
						}
						try
						{
							Assert.True(_0024req1_002422626.IsOk, new StringBuilder().Append("ApiPurchaseProductIdList()").Append("\n ").Append(_0024self__002422634.readResponeString(_0024req1_002422626))
								.ToString());
							Assert.NotNull(_0024req1_002422626.GetResponse().ProductInfo, "ApiPurchaseProductIdList() プロダクトインフォ");
							Assert.False(_0024req2_002422627.IsOk, new StringBuilder().Append("引数なし ApiPurchaseVerify()").Append("\n ").Append(_0024self__002422634.readResponeString(_0024req2_002422627))
								.ToString());
						}
						catch (TestException e)
						{
							_0024self__002422634.MarkAsFailure(e);
						}
						_0024self__002422634.DoneTesting();
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422635;

		public _0024TestApiPurchaseProductIdList_002422625(TestApiCore self_)
		{
			_0024self__002422635 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422635);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGachaExec_002422636 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGachaExec _0024_00245240_002422637;

			internal ApiGachaExec _0024req1_002422638;

			internal ApiGachaExec _0024_00245241_002422639;

			internal ApiGachaExec _0024req2_002422640;

			internal ApiGachaExec _0024_00245242_002422641;

			internal ApiGachaExec _0024req3_002422642;

			internal ApiGachaExec _0024_00245243_002422643;

			internal ApiGachaExec _0024req4_002422644;

			internal ApiGachaExec _0024_00245244_002422645;

			internal ApiGachaExec _0024req5_002422646;

			internal ApiGachaExec _0024_00245245_002422647;

			internal ApiGachaExec _0024req6_002422648;

			internal ApiGachaExec _0024_00245246_002422649;

			internal ApiGachaExec _0024req7_002422650;

			internal ApiGachaExec _0024_00245247_002422651;

			internal ApiGachaExec _0024req8_002422652;

			internal ApiGachaExec _0024_00245248_002422653;

			internal ApiGachaExec _0024req9_002422654;

			internal ApiGachaExec _0024_00245249_002422655;

			internal ApiGachaExec _0024req10_002422656;

			internal TestApiCore _0024self__002422657;

			public _0024(TestApiCore self_)
			{
				_0024self__002422657 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					ApiGachaExec apiGachaExec = (_0024_00245240_002422637 = new ApiGachaExec());
					int num = (_0024_00245240_002422637.GachaId = 0);
					int num2 = (_0024_00245240_002422637.Turn = 1);
					_0024req1_002422638 = _0024_00245240_002422637;
					result = (Yield(2, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req1_002422638))) ? 1 : 0);
					break;
				}
				case 2:
				{
					ApiGachaExec apiGachaExec10 = (_0024_00245241_002422639 = new ApiGachaExec());
					int num19 = (_0024_00245241_002422639.GachaId = 0);
					int num20 = (_0024_00245241_002422639.Turn = 1);
					_0024req2_002422640 = _0024_00245241_002422639;
					result = (Yield(3, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req2_002422640))) ? 1 : 0);
					break;
				}
				case 3:
				{
					ApiGachaExec apiGachaExec9 = (_0024_00245242_002422641 = new ApiGachaExec());
					int num17 = (_0024_00245242_002422641.GachaId = 1);
					int num18 = (_0024_00245242_002422641.Turn = 1);
					_0024req3_002422642 = _0024_00245242_002422641;
					result = (Yield(4, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req3_002422642))) ? 1 : 0);
					break;
				}
				case 4:
				{
					ApiGachaExec apiGachaExec8 = (_0024_00245243_002422643 = new ApiGachaExec());
					int num15 = (_0024_00245243_002422643.GachaId = 1);
					int num16 = (_0024_00245243_002422643.Turn = 100);
					_0024req4_002422644 = _0024_00245243_002422643;
					result = (Yield(5, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req4_002422644))) ? 1 : 0);
					break;
				}
				case 5:
				{
					ApiGachaExec apiGachaExec7 = (_0024_00245244_002422645 = new ApiGachaExec());
					int num13 = (_0024_00245244_002422645.GachaId = 2);
					int num14 = (_0024_00245244_002422645.Turn = 1);
					_0024req5_002422646 = _0024_00245244_002422645;
					result = (Yield(6, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req5_002422646))) ? 1 : 0);
					break;
				}
				case 6:
				{
					ApiGachaExec apiGachaExec6 = (_0024_00245245_002422647 = new ApiGachaExec());
					int num11 = (_0024_00245245_002422647.GachaId = 3);
					int num12 = (_0024_00245245_002422647.Turn = 1);
					_0024req6_002422648 = _0024_00245245_002422647;
					result = (Yield(7, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req6_002422648))) ? 1 : 0);
					break;
				}
				case 7:
				{
					ApiGachaExec apiGachaExec5 = (_0024_00245246_002422649 = new ApiGachaExec());
					int num9 = (_0024_00245246_002422649.GachaId = 4);
					int num10 = (_0024_00245246_002422649.Turn = 1);
					_0024req7_002422650 = _0024_00245246_002422649;
					result = (Yield(8, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req7_002422650))) ? 1 : 0);
					break;
				}
				case 8:
				{
					ApiGachaExec apiGachaExec4 = (_0024_00245247_002422651 = new ApiGachaExec());
					int num7 = (_0024_00245247_002422651.GachaId = 5);
					int num8 = (_0024_00245247_002422651.Turn = 1);
					_0024req8_002422652 = _0024_00245247_002422651;
					result = (Yield(9, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req8_002422652))) ? 1 : 0);
					break;
				}
				case 9:
				{
					ApiGachaExec apiGachaExec3 = (_0024_00245248_002422653 = new ApiGachaExec());
					int num5 = (_0024_00245248_002422653.GachaId = 6);
					int num6 = (_0024_00245248_002422653.Turn = 1);
					_0024req9_002422654 = _0024_00245248_002422653;
					result = (Yield(10, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req9_002422654))) ? 1 : 0);
					break;
				}
				case 10:
				{
					ApiGachaExec apiGachaExec2 = (_0024_00245249_002422655 = new ApiGachaExec());
					int num3 = (_0024_00245249_002422655.GachaId = 7);
					int num4 = (_0024_00245249_002422655.Turn = 1);
					_0024req10_002422656 = _0024_00245249_002422655;
					result = (Yield(11, _0024self__002422657.runner.StartCoroutine(_0024self__002422657.WaitRequest(_0024req10_002422656))) ? 1 : 0);
					break;
				}
				case 11:
					try
					{
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req1_002422638), "CoApi001", new StringBuilder().Append("ApiGachaExec( GachaId:0, Turn:1 )").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req1_002422638))
							.ToString());
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req2_002422640), "GaRlt002", new StringBuilder().Append("一日一回くじを二回ひく").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req2_002422640))
							.ToString());
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req3_002422642), "GaRlt003", new StringBuilder().Append("フレンドポイント不足で引けない").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req3_002422642))
							.ToString());
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req4_002422644), "GaRlt003", new StringBuilder().Append("フレンドポイント不足で引けない").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req4_002422644))
							.ToString());
						Assert.True(_0024req5_002422646.IsOk, new StringBuilder().Append("武器くじ").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req5_002422646))
							.ToString());
						Assert.True(_0024req6_002422648.IsOk, new StringBuilder().Append("ペットくじ").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req6_002422648))
							.ToString());
						Assert.True(_0024req7_002422650.IsOk, new StringBuilder().Append("コラボくじ").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req7_002422650))
							.ToString());
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req8_002422652), "GaRlt004", new StringBuilder().Append("レイドポイント不足").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req8_002422652))
							.ToString());
						Assert.True(_0024req9_002422654.IsOk, new StringBuilder().Append("イベントくじ").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req9_002422654))
							.ToString());
						Assert.Equal(_0024self__002422657.lookStatusCodeInReq(_0024req10_002422656), "GaRlt001", new StringBuilder().Append("無効なガチャ番号").Append("\n ").Append(_0024self__002422657.readResponeString(_0024req10_002422656))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422657.MarkAsFailure(e);
					}
					_0024self__002422657.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422658;

		public _0024TestApiGachaExec_002422636(TestApiCore self_)
		{
			_0024self__002422658 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422658);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGuild_002422659 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGuild _0024req1_002422660;

			internal TestApiCore _0024self__002422661;

			public _0024(TestApiCore self_)
			{
				_0024self__002422661 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422660 = new ApiGuild();
					result = (Yield(2, _0024self__002422661.runner.StartCoroutine(_0024self__002422661.WaitRequest(_0024req1_002422660))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422660.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422661.readResponeString(_0024req1_002422660))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422661.MarkAsFailure(e);
					}
					_0024self__002422661.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422662;

		public _0024TestApiGuild_002422659(TestApiCore self_)
		{
			_0024self__002422662 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422662);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGuildResult_002422663 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGuildResult _0024req1_002422664;

			internal TestApiCore _0024self__002422665;

			public _0024(TestApiCore self_)
			{
				_0024self__002422665 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422664 = new ApiGuildResult();
					result = (Yield(2, _0024self__002422665.runner.StartCoroutine(_0024self__002422665.WaitRequest(_0024req1_002422664))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.False(_0024req1_002422664.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422665.readResponeString(_0024req1_002422664))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422665.MarkAsFailure(e);
					}
					_0024self__002422665.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422666;

		public _0024TestApiGuildResult_002422663(TestApiCore self_)
		{
			_0024self__002422666 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422666);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiPresent_002422667 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiPresent _0024req1_002422668;

			internal ApiPresentReceipt _0024req2_002422669;

			internal TestApiCore _0024self__002422670;

			public _0024(TestApiCore self_)
			{
				_0024self__002422670 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422668 = new ApiPresent();
					result = (Yield(2, _0024self__002422670.runner.StartCoroutine(_0024self__002422670.WaitRequest(_0024req1_002422668))) ? 1 : 0);
					break;
				case 2:
					_0024req2_002422669 = new ApiPresentReceipt();
					result = (Yield(3, _0024self__002422670.runner.StartCoroutine(_0024self__002422670.WaitRequest(_0024req2_002422669))) ? 1 : 0);
					break;
				case 3:
					try
					{
						Assert.True(_0024req1_002422668.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422670.readResponeString(_0024req1_002422668))
							.ToString());
						Assert.False(_0024req2_002422669.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422670.readResponeString(_0024req2_002422669))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422670.MarkAsFailure(e);
					}
					_0024self__002422670.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422671;

		public _0024TestApiPresent_002422667(TestApiCore self_)
		{
			_0024self__002422671 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422671);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiFriendApplyList_002422672 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiFriendApplyList _0024req1_002422673;

			internal TestApiCore _0024self__002422674;

			public _0024(TestApiCore self_)
			{
				_0024self__002422674 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422673 = new ApiFriendApplyList();
					result = (Yield(2, _0024self__002422674.runner.StartCoroutine(_0024self__002422674.WaitRequest(_0024req1_002422673))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422673.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422674.readResponeString(_0024req1_002422673))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422674.MarkAsFailure(e);
					}
					_0024self__002422674.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422675;

		public _0024TestApiFriendApplyList_002422672(TestApiCore self_)
		{
			_0024self__002422675 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422675);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiFriendPlayerSearch_002422676 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiFriendPlayerSearch _0024req1_002422677;

			internal ApiFriendPlayerSearch _0024_00245250_002422678;

			internal ApiFriendPlayerSearch _0024req2_002422679;

			internal ApiFriendPlayerSearch _0024_00245251_002422680;

			internal ApiFriendPlayerSearch _0024req3_002422681;

			internal ApiFriendPlayerSearch _0024_00245252_002422682;

			internal ApiFriendPlayerSearch _0024req4_002422683;

			internal ApiFriendPlayerSearch _0024_00245253_002422684;

			internal ApiFriendPlayerSearch _0024req5_002422685;

			internal ApiFriendPlayerSearch _0024_00245254_002422686;

			internal ApiFriendPlayerSearch _0024req6_002422687;

			internal ApiFriendPlayerSearch _0024_00245255_002422688;

			internal ApiFriendPlayerSearch _0024req7_002422689;

			internal ApiFriendPlayerSearch _0024_00245256_002422690;

			internal ApiFriendPlayerSearch _0024req8_002422691;

			internal TestApiCore _0024self__002422692;

			public _0024(TestApiCore self_)
			{
				_0024self__002422692 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422677 = new ApiFriendPlayerSearch();
					result = (Yield(2, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req1_002422677))) ? 1 : 0);
					break;
				case 2:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch7 = (_0024_00245250_002422678 = new ApiFriendPlayerSearch());
					bool flag6 = (_0024_00245250_002422678.IsRecommend = true);
					_0024req2_002422679 = _0024_00245250_002422678;
					result = (Yield(3, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req2_002422679))) ? 1 : 0);
					break;
				}
				case 3:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch6 = (_0024_00245251_002422680 = new ApiFriendPlayerSearch());
					bool flag5 = (_0024_00245251_002422680.IsRecommend = true);
					int num4 = (_0024_00245251_002422680.Num = 10);
					_0024req3_002422681 = _0024_00245251_002422680;
					result = (Yield(4, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req3_002422681))) ? 1 : 0);
					break;
				}
				case 4:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch5 = (_0024_00245252_002422682 = new ApiFriendPlayerSearch());
					bool flag4 = (_0024_00245252_002422682.IsRecommend = true);
					int num3 = (_0024_00245252_002422682.Num = 100);
					_0024req4_002422683 = _0024_00245252_002422682;
					result = (Yield(5, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req4_002422683))) ? 1 : 0);
					break;
				}
				case 5:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch4 = (_0024_00245253_002422684 = new ApiFriendPlayerSearch());
					bool flag3 = (_0024_00245253_002422684.IsRecommend = true);
					int num2 = (_0024_00245253_002422684.Num = 1000);
					_0024req5_002422685 = _0024_00245253_002422684;
					result = (Yield(6, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req5_002422685))) ? 1 : 0);
					break;
				}
				case 6:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch3 = (_0024_00245254_002422686 = new ApiFriendPlayerSearch());
					string text = (_0024_00245254_002422686.Name = "ビル・ゲイツ");
					_0024req6_002422687 = _0024_00245254_002422686;
					result = (Yield(7, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req6_002422687))) ? 1 : 0);
					break;
				}
				case 7:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch2 = (_0024_00245255_002422688 = new ApiFriendPlayerSearch());
					bool flag2 = (_0024_00245255_002422688.IsRecommend = false);
					_0024req7_002422689 = _0024_00245255_002422688;
					result = (Yield(8, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req7_002422689))) ? 1 : 0);
					break;
				}
				case 8:
				{
					ApiFriendPlayerSearch apiFriendPlayerSearch = (_0024_00245256_002422690 = new ApiFriendPlayerSearch());
					bool flag = (_0024_00245256_002422690.IsRecommend = false);
					int num = (_0024_00245256_002422690.Num = 1000);
					_0024req8_002422691 = _0024_00245256_002422690;
					result = (Yield(9, _0024self__002422692.runner.StartCoroutine(_0024self__002422692.WaitRequest(_0024req8_002422691))) ? 1 : 0);
					break;
				}
				case 9:
					try
					{
						Assert.True(_0024req1_002422677.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req1_002422677))
							.ToString());
						Assert.True(_0024req2_002422679.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req2_002422679))
							.ToString());
						Assert.True(_0024req3_002422681.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req3_002422681))
							.ToString());
						Assert.True(_0024req4_002422683.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req4_002422683))
							.ToString());
						Assert.False(_0024req5_002422685.IsOk, new StringBuilder().Append("フレンド取得上限オーバー").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req5_002422685))
							.ToString());
						Assert.Equal(_0024self__002422692.lookStatusCodeInReq(_0024req6_002422687), "FrGet001", new StringBuilder().Append("NGワード使って名前でフレンド検索").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req6_002422687))
							.ToString());
						Assert.True(_0024req7_002422689.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req7_002422689))
							.ToString());
						Assert.False(_0024req8_002422691.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422692.readResponeString(_0024req8_002422691))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422692.MarkAsFailure(e);
					}
					_0024self__002422692.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422693;

		public _0024TestApiFriendPlayerSearch_002422676(TestApiCore self_)
		{
			_0024self__002422693 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422693);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiFriendApply_002422694 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiFriendApply _0024req1_002422695;

			internal ApiFriendApply _0024_00245257_002422696;

			internal ApiFriendApply _0024req2_002422697;

			internal ApiFriendApply _0024_00245258_002422698;

			internal ApiFriendApply _0024req3_002422699;

			internal TestApiCore _0024self__002422700;

			public _0024(TestApiCore self_)
			{
				_0024self__002422700 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422695 = new ApiFriendApply();
					result = (Yield(2, _0024self__002422700.runner.StartCoroutine(_0024self__002422700.WaitRequest(_0024req1_002422695))) ? 1 : 0);
					break;
				case 2:
				{
					ApiFriendApply apiFriendApply2 = (_0024_00245257_002422696 = new ApiFriendApply());
					int num2 = (_0024_00245257_002422696.Id = 1);
					_0024req2_002422697 = _0024_00245257_002422696;
					result = (Yield(3, _0024self__002422700.runner.StartCoroutine(_0024self__002422700.WaitRequest(_0024req2_002422697))) ? 1 : 0);
					break;
				}
				case 3:
				{
					ApiFriendApply apiFriendApply = (_0024_00245258_002422698 = new ApiFriendApply());
					int num = (_0024_00245258_002422698.Id = 0);
					_0024req3_002422699 = _0024_00245258_002422698;
					result = (Yield(4, _0024self__002422700.runner.StartCoroutine(_0024self__002422700.WaitRequest(_0024req3_002422699))) ? 1 : 0);
					break;
				}
				case 4:
					try
					{
						Assert.False(_0024req1_002422695.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422700.readResponeString(_0024req1_002422695))
							.ToString());
						Assert.True(_0024req2_002422697.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422700.readResponeString(_0024req2_002422697))
							.ToString());
						Assert.False(_0024req3_002422699.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422700.readResponeString(_0024req3_002422699))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422700.MarkAsFailure(e);
					}
					_0024self__002422700.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422701;

		public _0024TestApiFriendApply_002422694(TestApiCore self_)
		{
			_0024self__002422701 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422701);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiSerial_002422702 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiSerial _0024req1_002422703;

			internal TestApiCore _0024self__002422704;

			public _0024(TestApiCore self_)
			{
				_0024self__002422704 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422703 = new ApiSerial();
					result = (Yield(2, _0024self__002422704.runner.StartCoroutine(_0024self__002422704.WaitRequest(_0024req1_002422703))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422703.IsOk, new StringBuilder().Append("シリアルコード入力画面取得").Append("\n ").Append(_0024self__002422704.readResponeString(_0024req1_002422703))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422704.MarkAsFailure(e);
					}
					_0024self__002422704.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422705;

		public _0024TestApiSerial_002422702(TestApiCore self_)
		{
			_0024self__002422705 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422705);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiSerialInput_002422706 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiSerialInput _0024req1_002422707;

			internal TestApiCore _0024self__002422708;

			public _0024(TestApiCore self_)
			{
				_0024self__002422708 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422707 = new ApiSerialInput();
					result = (Yield(2, _0024self__002422708.runner.StartCoroutine(_0024self__002422708.WaitRequest(_0024req1_002422707))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422707.IsOk, new StringBuilder().Append("シリアルコード入力").Append("\n ").Append(_0024self__002422708.readResponeString(_0024req1_002422707))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422708.MarkAsFailure(e);
					}
					_0024self__002422708.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422709;

		public _0024TestApiSerialInput_002422706(TestApiCore self_)
		{
			_0024self__002422709 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422709);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiBox_002422710 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiBox _0024req1_002422711;

			internal TestApiCore _0024self__002422712;

			public _0024(TestApiCore self_)
			{
				_0024self__002422712 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422711 = new ApiBox();
					result = (Yield(2, _0024self__002422712.runner.StartCoroutine(_0024self__002422712.WaitRequest(_0024req1_002422711))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422711.IsOk, new StringBuilder().Append("ボックス取得").Append("\n ").Append(_0024self__002422712.readResponeString(_0024req1_002422711))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422712.MarkAsFailure(e);
					}
					_0024self__002422712.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422713;

		public _0024TestApiBox_002422710(TestApiCore self_)
		{
			_0024self__002422713 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422713);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiBoxExtension_002422714 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024initialBoxSize_002422715;

			internal int _0024x_002422716;

			internal ApiBoxExtension _0024req1_002422717;

			internal ApiHome _0024req_002422718;

			internal int _0024resultBoxSize_002422719;

			internal int _0024_002412000_002422720;

			internal TestApiCore _0024self__002422721;

			public _0024(TestApiCore self_)
			{
				_0024self__002422721 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024initialBoxSize_002422715 = UserData.Current.BoxCapacity;
					_0024_002412000_002422720 = 1;
					goto IL_0103;
				case 2:
					try
					{
						Assert.True(_0024req1_002422717.IsOk, new StringBuilder().Append(new StringBuilder().Append((object)_0024x_002422716).Append("回目のボックス拡張").ToString()).Append("\n ").Append(_0024self__002422721.readResponeString(_0024req1_002422717))
							.ToString());
					}
					catch (TestException e2)
					{
						_0024self__002422721.MarkAsFailure(e2);
					}
					goto IL_0103;
				case 3:
					_0024resultBoxSize_002422719 = UserData.Current.BoxCapacity;
					try
					{
						Assert.Equal(checked(_0024initialBoxSize_002422715 + 250), _0024resultBoxSize_002422719, new StringBuilder().Append("ボックス拡張結果ふえたかどうか").Append("\n ").Append(_0024self__002422721.readResponeString(_0024req1_002422717))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422721.MarkAsFailure(e);
					}
					_0024self__002422721.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0103:
					if (_0024_002412000_002422720 < 50)
					{
						_0024x_002422716 = _0024_002412000_002422720;
						_0024_002412000_002422720++;
						_0024req1_002422717 = new ApiBoxExtension();
						result = (Yield(2, _0024self__002422721.runner.StartCoroutine(_0024self__002422721.WaitRequest(_0024req1_002422717))) ? 1 : 0);
					}
					else
					{
						_0024req_002422718 = new ApiHome();
						result = (Yield(3, _0024self__002422721.runner.StartCoroutine(_0024self__002422721.WaitRequest(_0024req_002422718))) ? 1 : 0);
					}
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422722;

		public _0024TestApiBoxExtension_002422714(TestApiCore self_)
		{
			_0024self__002422722 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422722);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiUpdatePoppetName_002422723 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiUpdatePoppetName _0024_00245259_002422724;

			internal ApiUpdatePoppetName _0024req1_002422725;

			internal TestApiCore _0024self__002422726;

			public _0024(TestApiCore self_)
			{
				_0024self__002422726 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					ApiUpdatePoppetName apiUpdatePoppetName = (_0024_00245259_002422724 = new ApiUpdatePoppetName());
					string text = (_0024_00245259_002422724.PoppetName = "フォロン");
					_0024req1_002422725 = _0024_00245259_002422724;
					result = (Yield(2, _0024self__002422726.runner.StartCoroutine(_0024self__002422726.WaitRequest(_0024req1_002422725))) ? 1 : 0);
					break;
				}
				case 2:
					try
					{
						Assert.False(_0024req1_002422725.IsOk, new StringBuilder().Append("魔ペット名前設定 閉じとない").Append("\n ").Append(_0024self__002422726.readResponeString(_0024req1_002422725))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422726.MarkAsFailure(e);
					}
					_0024self__002422726.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422727;

		public _0024TestApiUpdatePoppetName_002422723(TestApiCore self_)
		{
			_0024self__002422727 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422727);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGetVersion_002422728 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGetVersion _0024req1_002422729;

			internal TestApiCore _0024self__002422730;

			public _0024(TestApiCore self_)
			{
				_0024self__002422730 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422729 = new ApiGetVersion();
					result = (Yield(2, _0024self__002422730.runner.StartCoroutine(_0024self__002422730.WaitRequest(_0024req1_002422729))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422729.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422730.readResponeString(_0024req1_002422729))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422730.MarkAsFailure(e);
					}
					_0024self__002422730.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422731;

		public _0024TestApiGetVersion_002422728(TestApiCore self_)
		{
			_0024self__002422731 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422731);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiInfo_002422732 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiInfo _0024req1_002422733;

			internal TestApiCore _0024self__002422734;

			public _0024(TestApiCore self_)
			{
				_0024self__002422734 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422733 = new ApiInfo();
					result = (Yield(2, _0024self__002422734.runner.StartCoroutine(_0024self__002422734.WaitRequest(_0024req1_002422733))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422733.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422734.readResponeString(_0024req1_002422733))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422734.MarkAsFailure(e);
					}
					_0024self__002422734.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422735;

		public _0024TestApiInfo_002422732(TestApiCore self_)
		{
			_0024self__002422735 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422735);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiInfoHistoryList_002422736 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiInfoHistoryList _0024req1_002422737;

			internal TestApiCore _0024self__002422738;

			public _0024(TestApiCore self_)
			{
				_0024self__002422738 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422737 = new ApiInfoHistoryList();
					result = (Yield(2, _0024self__002422738.runner.StartCoroutine(_0024self__002422738.WaitRequest(_0024req1_002422737))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422737.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422738.readResponeString(_0024req1_002422737))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422738.MarkAsFailure(e);
					}
					_0024self__002422738.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422739;

		public _0024TestApiInfoHistoryList_002422736(TestApiCore self_)
		{
			_0024self__002422739 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422739);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiInfoHistoryDetail_002422740 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiInfoHistoryDetail _0024req1_002422741;

			internal TestApiCore _0024self__002422742;

			public _0024(TestApiCore self_)
			{
				_0024self__002422742 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422741 = new ApiInfoHistoryDetail();
					result = (Yield(2, _0024self__002422742.runner.StartCoroutine(_0024self__002422742.WaitRequest(_0024req1_002422741))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422741.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422742.readResponeString(_0024req1_002422741))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422742.MarkAsFailure(e);
					}
					_0024self__002422742.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422743;

		public _0024TestApiInfoHistoryDetail_002422740(TestApiCore self_)
		{
			_0024self__002422743 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422743);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiInfoRecommendList_002422744 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiInfoRecommendList _0024req1_002422745;

			internal TestApiCore _0024self__002422746;

			public _0024(TestApiCore self_)
			{
				_0024self__002422746 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422745 = new ApiInfoRecommendList();
					result = (Yield(2, _0024self__002422746.runner.StartCoroutine(_0024self__002422746.WaitRequest(_0024req1_002422745))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422745.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422746.readResponeString(_0024req1_002422745))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422746.MarkAsFailure(e);
					}
					_0024self__002422746.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422747;

		public _0024TestApiInfoRecommendList_002422744(TestApiCore self_)
		{
			_0024self__002422747 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422747);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiInfoDevelopmentList_002422748 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiInfoDevelopmentList _0024req1_002422749;

			internal TestApiCore _0024self__002422750;

			public _0024(TestApiCore self_)
			{
				_0024self__002422750 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422749 = new ApiInfoDevelopmentList();
					result = (Yield(2, _0024self__002422750.runner.StartCoroutine(_0024self__002422750.WaitRequest(_0024req1_002422749))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422749.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422750.readResponeString(_0024req1_002422749))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422750.MarkAsFailure(e);
					}
					_0024self__002422750.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422751;

		public _0024TestApiInfoDevelopmentList_002422748(TestApiCore self_)
		{
			_0024self__002422751 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422751);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiHelp_002422752 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHelp _0024req1_002422753;

			internal TestApiCore _0024self__002422754;

			public _0024(TestApiCore self_)
			{
				_0024self__002422754 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422753 = new ApiHelp();
					result = (Yield(2, _0024self__002422754.runner.StartCoroutine(_0024self__002422754.WaitRequest(_0024req1_002422753))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422753.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422754.readResponeString(_0024req1_002422753))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422754.MarkAsFailure(e);
					}
					_0024self__002422754.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422755;

		public _0024TestApiHelp_002422752(TestApiCore self_)
		{
			_0024self__002422755 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422755);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiHelpDetail_002422756 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHelpDetail _0024req1_002422757;

			internal TestApiCore _0024self__002422758;

			public _0024(TestApiCore self_)
			{
				_0024self__002422758 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422757 = new ApiHelpDetail();
					result = (Yield(2, _0024self__002422758.runner.StartCoroutine(_0024self__002422758.WaitRequest(_0024req1_002422757))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422757.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422758.readResponeString(_0024req1_002422757))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422758.MarkAsFailure(e);
					}
					_0024self__002422758.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422759;

		public _0024TestApiHelpDetail_002422756(TestApiCore self_)
		{
			_0024self__002422759 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422759);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiTutorialPutInBox_002422760 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024id_002422761;

			internal ApiTutorialPutInBox _0024req1_002422762;

			internal TestApiCore _0024self__002422763;

			public _0024(TestApiCore self_)
			{
				_0024self__002422763 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024id_002422761 = 1;
					_0024req1_002422762 = new ApiTutorialPutInBox(_0024id_002422761);
					result = (Yield(2, _0024self__002422763.runner.StartCoroutine(_0024self__002422763.WaitRequest(_0024req1_002422762))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422762.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422763.readResponeString(_0024req1_002422762))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422763.MarkAsFailure(e);
					}
					_0024self__002422763.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422764;

		public _0024TestApiTutorialPutInBox_002422760(TestApiCore self_)
		{
			_0024self__002422764 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422764);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGacha_002422765 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGacha _0024req1_002422766;

			internal TestApiCore _0024self__002422767;

			public _0024(TestApiCore self_)
			{
				_0024self__002422767 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422766 = new ApiGacha();
					result = (Yield(2, _0024self__002422767.runner.StartCoroutine(_0024self__002422767.WaitRequest(_0024req1_002422766))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422766.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422767.readResponeString(_0024req1_002422766))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422767.MarkAsFailure(e);
					}
					_0024self__002422767.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422768;

		public _0024TestApiGacha_002422765(TestApiCore self_)
		{
			_0024self__002422768 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422768);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiGachaDetails_002422769 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiGachaDetails _0024req1_002422770;

			internal TestApiCore _0024self__002422771;

			public _0024(TestApiCore self_)
			{
				_0024self__002422771 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422770 = new ApiGachaDetails();
					result = (Yield(2, _0024self__002422771.runner.StartCoroutine(_0024self__002422771.WaitRequest(_0024req1_002422770))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422770.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422771.readResponeString(_0024req1_002422770))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422771.MarkAsFailure(e);
					}
					_0024self__002422771.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422772;

		public _0024TestApiGachaDetails_002422769(TestApiCore self_)
		{
			_0024self__002422772 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422772);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWebStaffCredit_002422773 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiWebStaffCredit _0024req1_002422774;

			internal TestApiCore _0024self__002422775;

			public _0024(TestApiCore self_)
			{
				_0024self__002422775 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422774 = new ApiWebStaffCredit();
					result = (Yield(2, _0024self__002422775.runner.StartCoroutine(_0024self__002422775.WaitRequest(_0024req1_002422774))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422774.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422775.readResponeString(_0024req1_002422774))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422775.MarkAsFailure(e);
					}
					_0024self__002422775.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422776;

		public _0024TestApiWebStaffCredit_002422773(TestApiCore self_)
		{
			_0024self__002422776 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422776);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWebSpecificTrade_002422777 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiWebSpecificTrade _0024req1_002422778;

			internal TestApiCore _0024self__002422779;

			public _0024(TestApiCore self_)
			{
				_0024self__002422779 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422778 = new ApiWebSpecificTrade();
					result = (Yield(2, _0024self__002422779.runner.StartCoroutine(_0024self__002422779.WaitRequest(_0024req1_002422778))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422778.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422779.readResponeString(_0024req1_002422778))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422779.MarkAsFailure(e);
					}
					_0024self__002422779.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422780;

		public _0024TestApiWebSpecificTrade_002422777(TestApiCore self_)
		{
			_0024self__002422780 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422780);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWebChallengeDetail_002422781 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiWebChallengeDetail _0024req1_002422782;

			internal TestApiCore _0024self__002422783;

			public _0024(TestApiCore self_)
			{
				_0024self__002422783 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422782 = new ApiWebChallengeDetail();
					result = (Yield(2, _0024self__002422783.runner.StartCoroutine(_0024self__002422783.WaitRequest(_0024req1_002422782))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422782.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422783.readResponeString(_0024req1_002422782))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422783.MarkAsFailure(e);
					}
					_0024self__002422783.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422784;

		public _0024TestApiWebChallengeDetail_002422781(TestApiCore self_)
		{
			_0024self__002422784 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422784);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWebFriendInviteInput_002422785 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiWebFriendInviteInput _0024req1_002422786;

			internal TestApiCore _0024self__002422787;

			public _0024(TestApiCore self_)
			{
				_0024self__002422787 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422786 = new ApiWebFriendInviteInput();
					result = (Yield(2, _0024self__002422787.runner.StartCoroutine(_0024self__002422787.WaitRequest(_0024req1_002422786))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422786.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422787.readResponeString(_0024req1_002422786))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422787.MarkAsFailure(e);
					}
					_0024self__002422787.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422788;

		public _0024TestApiWebFriendInviteInput_002422785(TestApiCore self_)
		{
			_0024self__002422788 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422788);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWebRanking_002422789 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiWebRanking _0024req1_002422790;

			internal TestApiCore _0024self__002422791;

			public _0024(TestApiCore self_)
			{
				_0024self__002422791 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422790 = new ApiWebRanking();
					result = (Yield(2, _0024self__002422791.runner.StartCoroutine(_0024self__002422791.WaitRequest(_0024req1_002422790))) ? 1 : 0);
					break;
				case 2:
					try
					{
						Assert.True(_0024req1_002422790.IsOk, new StringBuilder().Append("テスト未実装").Append("\n ").Append(_0024self__002422791.readResponeString(_0024req1_002422790))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422791.MarkAsFailure(e);
					}
					_0024self__002422791.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiCore _0024self__002422792;

		public _0024TestApiWebRanking_002422789(TestApiCore self_)
		{
			_0024self__002422792 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422792);
		}
	}

	[UnitTest]
	public IEnumerator TestPlatformExtServer()
	{
		return new _0024TestPlatformExtServer_002422566(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestCreateUser()
	{
		return new _0024TestCreateUser_002422571(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiCreateCharacter()
	{
		return new _0024TestApiCreateCharacter_002422578(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiHome()
	{
		return new _0024TestApiHome_002422585(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiPlayer()
	{
		return new _0024TestApiPlayer_002422590(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiUpdateTutorial()
	{
		return new _0024TestApiUpdateTutorial_002422594(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiUpdateActionPoint()
	{
		return new _0024TestApiUpdateActionPoint_002422613(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiUpdateRaidPoint()
	{
		return new _0024TestApiUpdateRaidPoint_002422617(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiUpdateDeck()
	{
		return new _0024TestApiUpdateDeck_002422621(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiPurchaseProductIdList()
	{
		return new _0024TestApiPurchaseProductIdList_002422625(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGachaExec()
	{
		return new _0024TestApiGachaExec_002422636(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGuild()
	{
		return new _0024TestApiGuild_002422659(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGuildResult()
	{
		return new _0024TestApiGuildResult_002422663(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiPresent()
	{
		return new _0024TestApiPresent_002422667(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiFriendApplyList()
	{
		return new _0024TestApiFriendApplyList_002422672(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiFriendPlayerSearch()
	{
		return new _0024TestApiFriendPlayerSearch_002422676(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiFriendApply()
	{
		return new _0024TestApiFriendApply_002422694(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiSerial()
	{
		return new _0024TestApiSerial_002422702(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiSerialInput()
	{
		return new _0024TestApiSerialInput_002422706(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiBox()
	{
		return new _0024TestApiBox_002422710(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiBoxExtension()
	{
		return new _0024TestApiBoxExtension_002422714(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiUpdatePoppetName()
	{
		return new _0024TestApiUpdatePoppetName_002422723(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGetVersion()
	{
		return new _0024TestApiGetVersion_002422728(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiInfo()
	{
		return new _0024TestApiInfo_002422732(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiInfoHistoryList()
	{
		return new _0024TestApiInfoHistoryList_002422736(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiInfoHistoryDetail()
	{
		return new _0024TestApiInfoHistoryDetail_002422740(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiInfoRecommendList()
	{
		return new _0024TestApiInfoRecommendList_002422744(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiInfoDevelopmentList()
	{
		return new _0024TestApiInfoDevelopmentList_002422748(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiHelp()
	{
		return new _0024TestApiHelp_002422752(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiHelpDetail()
	{
		return new _0024TestApiHelpDetail_002422756(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiTutorialPutInBox()
	{
		return new _0024TestApiTutorialPutInBox_002422760(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGacha()
	{
		return new _0024TestApiGacha_002422765(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiGachaDetails()
	{
		return new _0024TestApiGachaDetails_002422769(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWebStaffCredit()
	{
		return new _0024TestApiWebStaffCredit_002422773(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWebSpecificTrade()
	{
		return new _0024TestApiWebSpecificTrade_002422777(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWebChallengeDetail()
	{
		return new _0024TestApiWebChallengeDetail_002422781(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWebFriendInviteInput()
	{
		return new _0024TestApiWebFriendInviteInput_002422785(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWebRanking()
	{
		return new _0024TestApiWebRanking_002422789(this).GetEnumerator();
	}
}
