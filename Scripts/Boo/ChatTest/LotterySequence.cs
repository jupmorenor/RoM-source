using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using S540;
using UnityEngine;

namespace ChatTest;

[Serializable]
public class LotterySequence : LotteryBase
{
	[Serializable]
	internal class _0024S540_FayStoneLottery_0024locals_002414329
	{
		internal Exec _0024_0024CUR_EXEC_0024;
	}

	[Serializable]
	internal class _0024S540_LoadFpBannerTaxture_0024locals_002414330
	{
		internal bool _0024ok;

		internal object _0024defTexture;
	}

	[Serializable]
	internal class _0024S540_LoadBannerHtml_0024locals_002414331
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024S540_ExecuteStoneList_0024locals_002414332
	{
		internal Exec _0024_0024CUR_EXEC_0024;
	}

	[Serializable]
	internal class _0024S540_FayStoneLottery_0024onEnd_00242954
	{
		internal LotterySequence _0024this_002414761;

		internal _0024S540_FayStoneLottery_0024locals_002414329 _0024_0024locals_002414762;

		public _0024S540_FayStoneLottery_0024onEnd_00242954(LotterySequence _0024this_002414761, _0024S540_FayStoneLottery_0024locals_002414329 _0024_0024locals_002414762)
		{
			this._0024this_002414761 = _0024this_002414761;
			this._0024_0024locals_002414762 = _0024_0024locals_002414762;
		}

		public void Invoke(bool cancel)
		{
			if ((bool)_0024this_002414761.stoneList)
			{
				_0024this_002414761.stoneList.Close();
				_0024this_002414761.stoneList.gameObject.SetActive(value: false);
			}
			_0024this_002414761.dtrace(_0024_0024locals_002414762._0024_0024CUR_EXEC_0024, "LotterySequence.boo:269", "go命令 " + _0024this_002414761.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
			Exec e = _0024this_002414761.createExecAsCurrent("S540_Home");
			IEnumerator r = _0024this_002414761.S540_Home();
			_0024this_002414761.entryCoroutine(e, r);
			_0024this_002414761.stop(_0024_0024locals_002414762._0024_0024CUR_EXEC_0024);
		}
	}

	[Serializable]
	internal class _0024S540_LoadBagTaxture_0024closure_00242955
	{
		internal int _0024_00248208_002414763;

		internal LotterySequence _0024this_002414764;

		internal MSaleGachas[] _0024_00248209_002414765;

		public _0024S540_LoadBagTaxture_0024closure_00242955(int _0024_00248208_002414763, LotterySequence _0024this_002414764, MSaleGachas[] _0024_00248209_002414765)
		{
			this._0024_00248208_002414763 = _0024_00248208_002414763;
			this._0024this_002414764 = _0024this_002414764;
			this._0024_00248209_002414765 = _0024_00248209_002414765;
		}

		public void Invoke(object obj)
		{
			Dictionary<int, Texture> bagTexture = _0024this_002414764.bagTexture;
			int id = _0024_00248209_002414765[_0024_00248208_002414763].Id;
			object obj2 = obj;
			if (!(obj2 is Texture))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Texture));
			}
			bagTexture[id] = (Texture)obj2;
		}
	}

	[Serializable]
	internal class _0024S540_LoadFpBannerTaxture_0024closure_00242956
	{
		internal _0024S540_LoadFpBannerTaxture_0024locals_002414330 _0024_0024locals_002414766;

		public _0024S540_LoadFpBannerTaxture_0024closure_00242956(_0024S540_LoadFpBannerTaxture_0024locals_002414330 _0024_0024locals_002414766)
		{
			this._0024_0024locals_002414766 = _0024_0024locals_002414766;
		}

		public void Invoke(object obj)
		{
			_0024_0024locals_002414766._0024defTexture = obj;
			_0024_0024locals_002414766._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024S540_LoadFpBannerTaxture_0024closure_00242957
	{
		internal _0024S540_LoadFpBannerTaxture_0024locals_002414330 _0024_0024locals_002414767;

		internal MSaleGachas[] _0024_00248213_002414768;

		internal LotterySequence _0024this_002414769;

		internal int _0024_00248212_002414770;

		public _0024S540_LoadFpBannerTaxture_0024closure_00242957(_0024S540_LoadFpBannerTaxture_0024locals_002414330 _0024_0024locals_002414767, MSaleGachas[] _0024_00248213_002414768, LotterySequence _0024this_002414769, int _0024_00248212_002414770)
		{
			this._0024_0024locals_002414767 = _0024_0024locals_002414767;
			this._0024_00248213_002414768 = _0024_00248213_002414768;
			this._0024this_002414769 = _0024this_002414769;
			this._0024_00248212_002414770 = _0024_00248212_002414770;
		}

		public void Invoke(object obj)
		{
			if (obj != null)
			{
				Dictionary<int, Texture> fpBannerTexture = _0024this_002414769.fpBannerTexture;
				int id = _0024_00248213_002414768[_0024_00248212_002414770].Id;
				object obj2 = obj;
				if (!(obj2 is Texture))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Texture));
				}
				fpBannerTexture[id] = (Texture)obj2;
			}
			else
			{
				Dictionary<int, Texture> fpBannerTexture2 = _0024this_002414769.fpBannerTexture;
				int id2 = _0024_00248213_002414768[_0024_00248212_002414770].Id;
				object obj3 = _0024_0024locals_002414767._0024defTexture;
				if (!(obj3 is Texture))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Texture));
				}
				fpBannerTexture2[id2] = (Texture)obj3;
			}
			_0024_0024locals_002414767._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024S540_LoadBannerHtml_0024closure_00242958
	{
		internal LotterySequence _0024this_002414771;

		internal int _0024_00248216_002414772;

		internal _0024S540_LoadBannerHtml_0024locals_002414331 _0024_0024locals_002414773;

		internal MSaleGachas[] _0024_00248217_002414774;

		public _0024S540_LoadBannerHtml_0024closure_00242958(LotterySequence _0024this_002414771, int _0024_00248216_002414772, _0024S540_LoadBannerHtml_0024locals_002414331 _0024_0024locals_002414773, MSaleGachas[] _0024_00248217_002414774)
		{
			this._0024this_002414771 = _0024this_002414771;
			this._0024_00248216_002414772 = _0024_00248216_002414772;
			this._0024_0024locals_002414773 = _0024_0024locals_002414773;
			this._0024_00248217_002414774 = _0024_00248217_002414774;
		}

		public void Invoke(object obj)
		{
			Dictionary<int, string> bannerHtml = _0024this_002414771.bannerHtml;
			int id = _0024_00248217_002414774[_0024_00248216_002414772].Id;
			object obj2 = obj;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			bannerHtml[id] = (string)obj2;
			_0024_0024locals_002414773._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024S540_ExecuteStoneList_0024update_00242977
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416563 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024S540_ExecuteStoneList_0024update_00242977 _0024self__002416564;

				public _0024(_0024S540_ExecuteStoneList_0024update_00242977 self_)
				{
					_0024self__002416564 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024self__002416564._0024this_002414775.stoneList.Download();
						goto IL_0060;
					case 2:
						if (!_0024self__002416564._0024_0024locals_002414776._0024_0024CUR_EXEC_0024.NotExecuting)
						{
							goto IL_0060;
						}
						goto case 1;
					case 3:
						if (!_0024self__002416564._0024_0024locals_002414776._0024_0024CUR_EXEC_0024.NotExecuting)
						{
							goto IL_0104;
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0060:
						if (!_0024self__002416564._0024this_002414775.stoneList.canStarted && !_0024self__002416564._0024this_002414775.stoneList.error)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002416564._0024this_002414775.stoneList.error)
						{
							_0024self__002416564._0024this_002414775.PushBack();
						}
						_0024self__002416564._0024this_002414775.stoneList.ShowDialog(StoneList.DIALOG_MODE.Buy);
						goto IL_0104;
						IL_0104:
						if (_0024self__002416564._0024this_002414775.stoneList.IsDialogUpdating(null))
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						YieldDefault(1);
						goto case 1;
					}
					return (byte)result != 0;
				}
			}

			internal _0024S540_ExecuteStoneList_0024update_00242977 _0024self__002416565;

			public _0024Invoke_002416563(_0024S540_ExecuteStoneList_0024update_00242977 self_)
			{
				_0024self__002416565 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002416565);
			}
		}

		internal LotterySequence _0024this_002414775;

		internal _0024S540_ExecuteStoneList_0024locals_002414332 _0024_0024locals_002414776;

		public _0024S540_ExecuteStoneList_0024update_00242977(LotterySequence _0024this_002414775, _0024S540_ExecuteStoneList_0024locals_002414332 _0024_0024locals_002414776)
		{
			this._0024this_002414775 = _0024this_002414775;
			this._0024_0024locals_002414776 = _0024_0024locals_002414776;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002416563(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_init_002415656 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024710_002415657;

			internal object _0024___item_002415658;

			internal IEnumerator _0024_0024iterator_002413317_002415659;

			internal LotterySequence _0024self__002415660;

			public _0024(LotterySequence self_)
			{
				_0024self__002415660 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024710_002415657 = _0024self__002415660.S540_init(null);
					if (_0024_0024s540_0024ycode_0024710_002415657 != null)
					{
						_0024_0024iterator_002413317_002415659 = _0024_0024s540_0024ycode_0024710_002415657;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413317_002415659.MoveNext())
					{
						_0024___item_002415658 = _0024_0024iterator_002413317_002415659.Current;
						result = (Yield(2, _0024___item_002415658) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002415661;

		public _0024S540_init_002415656(LotterySequence self_)
		{
			_0024self__002415661 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415661);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_init_002415662 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415663;

			internal Exec _0024_0024CUR_EXEC_0024_002415664;

			internal Exec _0024_0024s540_0024call_0024702_002415665;

			internal IEnumerator _0024_0024s540_0024call_0024701_002415666;

			internal object _0024_0024s540_0024call_0024703_002415667;

			internal Exec _0024_0024s540_0024call_0024705_002415668;

			internal IEnumerator _0024_0024s540_0024call_0024704_002415669;

			internal object _0024_0024s540_0024call_0024706_002415670;

			internal Exec _0024_0024s540_0024call_0024708_002415671;

			internal IEnumerator _0024_0024s540_0024call_0024707_002415672;

			internal object _0024_0024s540_0024call_0024709_002415673;

			internal Exec _0024_0024s540_0024go_0024699_002415674;

			internal IEnumerator _0024_0024s540_0024tmp_0024700_002415675;

			internal IEnumerator _0024_0024iterator_002413318_002415676;

			internal IEnumerator _0024_0024iterator_002413319_002415677;

			internal IEnumerator _0024_0024iterator_002413320_002415678;

			internal LotterySequence _0024self__002415679;

			public _0024(LotterySequence self_)
			{
				_0024self__002415679 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002415663 = "S540_init";
					_0024_0024CUR_EXEC_0024_002415664 = _0024self__002415679.lastCreatedExec;
					if (!_0024self__002415679.dispExplain)
					{
						_0024self__002415679.fayStoneExplain = null;
						_0024self__002415679.raidPointExplain = null;
						_0024self__002415679.friendPointExplain = null;
						_0024self__002415679.fayStoneEventExplain = null;
						_0024self__002415679.raidPointEventExplain = null;
						_0024self__002415679.friendPointEventExplain = null;
					}
					startUpdateFunc = null;
					endUpdateFunc = null;
					WebViewBase.Visible(flag: false);
					_0024self__002415679.labelFormatCacheDictionary = new Dictionary<UILabelBase, string>();
					plyrCtrl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (plyrCtrl != null)
					{
						plyrCtrl.Pause = true;
					}
					_0024self__002415679.Init();
					_0024self__002415679.CoverOff();
					goto IL_0129;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002415664.NotExecuting)
					{
						goto IL_0129;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413318_002415676.MoveNext())
					{
						_0024_0024s540_0024call_0024703_002415667 = _0024_0024iterator_002413318_002415676.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024703_002415667) ? 1 : 0);
						break;
					}
					goto IL_01db;
				case 4:
					if (_0024_0024iterator_002413319_002415677.MoveNext())
					{
						_0024_0024s540_0024call_0024706_002415670 = _0024_0024iterator_002413319_002415677.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024706_002415670) ? 1 : 0);
						break;
					}
					goto IL_0292;
				case 5:
					if (_0024_0024iterator_002413320_002415678.MoveNext())
					{
						_0024_0024s540_0024call_0024709_002415673 = _0024_0024iterator_002413320_002415678.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024709_002415673) ? 1 : 0);
						break;
					}
					goto IL_037a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01db:
					if (!_0024self__002415679.isExecuting(_0024_0024CUR_EXEC_0024_002415664))
					{
						goto case 1;
					}
					_0024self__002415679.dtrace(_0024_0024CUR_EXEC_0024_002415664, "LotterySequence.boo:113", "call命令");
					_0024_0024s540_0024call_0024705_002415668 = _0024self__002415679.createExec("S540_LoadFpBannerTaxture", _0024_0024CUR_EXEC_0024_002415664);
					_0024_0024s540_0024call_0024704_002415669 = _0024self__002415679.S540_LoadFpBannerTaxture(urlFpBannerTexutre);
					if (_0024_0024s540_0024call_0024704_002415669 != null)
					{
						_0024_0024iterator_002413319_002415677 = _0024_0024s540_0024call_0024704_002415669;
						goto case 4;
					}
					goto IL_0292;
					IL_037a:
					if (_0024self__002415679.isExecuting(_0024_0024CUR_EXEC_0024_002415664))
					{
						_0024self__002415679.dtrace(_0024_0024CUR_EXEC_0024_002415664, "LotterySequence.boo:122", "go命令 " + _0024self__002415679.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024699_002415674 = _0024self__002415679.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024700_002415675 = _0024self__002415679.S540_Home();
						_0024self__002415679.entryCoroutine(_0024_0024s540_0024go_0024699_002415674, _0024_0024s540_0024tmp_0024700_002415675);
						_0024self__002415679.stop(_0024_0024CUR_EXEC_0024_002415664);
					}
					goto case 1;
					IL_0129:
					if (_0024self__002415679.isWaitInitialize)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					MerlinServer.Busy = true;
					_0024self__002415679.dtrace(_0024_0024CUR_EXEC_0024_002415664, "LotterySequence.boo:112", "call命令");
					_0024_0024s540_0024call_0024702_002415665 = _0024self__002415679.createExec("S540_LoadBagTaxture", _0024_0024CUR_EXEC_0024_002415664);
					_0024_0024s540_0024call_0024701_002415666 = _0024self__002415679.S540_LoadBagTaxture(urlTexutre);
					if (_0024_0024s540_0024call_0024701_002415666 != null)
					{
						_0024_0024iterator_002413318_002415676 = _0024_0024s540_0024call_0024701_002415666;
						goto case 3;
					}
					goto IL_01db;
					IL_0292:
					if (!_0024self__002415679.isExecuting(_0024_0024CUR_EXEC_0024_002415664))
					{
						goto case 1;
					}
					MerlinServer.Busy = false;
					_0024self__002415679.PrizeHide();
					_0024self__002415679.TapHide();
					_0024self__002415679.CamStart();
					SceneTitleHUD.UpdateTitle("くじびき屋");
					_0024self__002415679.dtrace(_0024_0024CUR_EXEC_0024_002415664, "LotterySequence.boo:120", "call命令");
					_0024_0024s540_0024call_0024708_002415671 = _0024self__002415679.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002415664);
					_0024_0024s540_0024call_0024707_002415672 = _0024self__002415679.S540_WaitSec(0.2f);
					if (_0024_0024s540_0024call_0024707_002415672 != null)
					{
						_0024_0024iterator_002413320_002415678 = _0024_0024s540_0024call_0024707_002415672;
						goto case 5;
					}
					goto IL_037a;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002415680;

		public _0024S540_init_002415662(LotterySequence self_)
		{
			_0024self__002415680 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415680);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Home_002415681 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024765_002415682;

			internal object _0024___item_002415683;

			internal IEnumerator _0024_0024iterator_002413321_002415684;

			internal LotterySequence _0024self__002415685;

			public _0024(LotterySequence self_)
			{
				_0024self__002415685 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024765_002415682 = _0024self__002415685.S540_Home(null);
					if (_0024_0024s540_0024ycode_0024765_002415682 != null)
					{
						_0024_0024iterator_002413321_002415684 = _0024_0024s540_0024ycode_0024765_002415682;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413321_002415684.MoveNext())
					{
						_0024___item_002415683 = _0024_0024iterator_002413321_002415684.Current;
						result = (Yield(2, _0024___item_002415683) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002415686;

		public _0024S540_Home_002415681(LotterySequence self_)
		{
			_0024self__002415686 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415686);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Home_002415687 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415688;

			internal Exec _0024_0024CUR_EXEC_0024_002415689;

			internal float _0024waitSec_002415690;

			internal Exec _0024_0024s540_0024call_0024724_002415691;

			internal IEnumerator _0024_0024s540_0024call_0024723_002415692;

			internal object _0024_0024s540_0024call_0024725_002415693;

			internal Exec _0024_0024s540_0024call_0024727_002415694;

			internal IEnumerator _0024_0024s540_0024call_0024726_002415695;

			internal object _0024_0024s540_0024call_0024728_002415696;

			internal Exec _0024_0024s540_0024call_0024730_002415697;

			internal IEnumerator _0024_0024s540_0024call_0024729_002415698;

			internal object _0024_0024s540_0024call_0024731_002415699;

			internal Exec _0024_0024s540_0024call_0024733_002415700;

			internal IEnumerator _0024_0024s540_0024call_0024732_002415701;

			internal object _0024_0024s540_0024call_0024734_002415702;

			internal Exec _0024_0024s540_0024call_0024736_002415703;

			internal IEnumerator _0024_0024s540_0024call_0024735_002415704;

			internal object _0024_0024s540_0024call_0024737_002415705;

			internal Exec _0024_0024s540_0024call_0024739_002415706;

			internal IEnumerator _0024_0024s540_0024call_0024738_002415707;

			internal object _0024_0024s540_0024call_0024740_002415708;

			internal Exec _0024_0024s540_0024call_0024742_002415709;

			internal IEnumerator _0024_0024s540_0024call_0024741_002415710;

			internal object _0024_0024s540_0024call_0024743_002415711;

			internal Exec _0024_0024s540_0024call_0024745_002415712;

			internal IEnumerator _0024_0024s540_0024call_0024744_002415713;

			internal object _0024_0024s540_0024call_0024746_002415714;

			internal Exec _0024_0024s540_0024call_0024748_002415715;

			internal IEnumerator _0024_0024s540_0024call_0024747_002415716;

			internal object _0024_0024s540_0024call_0024749_002415717;

			internal Exec _0024_0024s540_0024go_0024713_002415718;

			internal IEnumerator _0024_0024s540_0024tmp_0024714_002415719;

			internal Exec _0024_0024s540_0024call_0024751_002415720;

			internal IEnumerator _0024_0024s540_0024call_0024750_002415721;

			internal object _0024_0024s540_0024call_0024752_002415722;

			internal Exec _0024_0024s540_0024go_0024715_002415723;

			internal IEnumerator _0024_0024s540_0024tmp_0024716_002415724;

			internal Exec _0024_0024s540_0024call_0024754_002415725;

			internal IEnumerator _0024_0024s540_0024call_0024753_002415726;

			internal object _0024_0024s540_0024call_0024755_002415727;

			internal Exec _0024_0024s540_0024call_0024757_002415728;

			internal IEnumerator _0024_0024s540_0024call_0024756_002415729;

			internal object _0024_0024s540_0024call_0024758_002415730;

			internal Exec _0024_0024s540_0024call_0024760_002415731;

			internal IEnumerator _0024_0024s540_0024call_0024759_002415732;

			internal object _0024_0024s540_0024call_0024761_002415733;

			internal Exec _0024_0024s540_0024go_0024717_002415734;

			internal IEnumerator _0024_0024s540_0024tmp_0024718_002415735;

			internal Exec _0024_0024s540_0024call_0024763_002415736;

			internal IEnumerator _0024_0024s540_0024call_0024762_002415737;

			internal object _0024_0024s540_0024call_0024764_002415738;

			internal Exec _0024_0024s540_0024go_0024719_002415739;

			internal IEnumerator _0024_0024s540_0024tmp_0024720_002415740;

			internal Exec _0024_0024s540_0024go_0024721_002415741;

			internal IEnumerator _0024_0024s540_0024tmp_0024722_002415742;

			internal IEnumerator _0024_0024iterator_002413322_002415743;

			internal IEnumerator _0024_0024iterator_002413323_002415744;

			internal IEnumerator _0024_0024iterator_002413324_002415745;

			internal IEnumerator _0024_0024iterator_002413325_002415746;

			internal IEnumerator _0024_0024iterator_002413326_002415747;

			internal IEnumerator _0024_0024iterator_002413327_002415748;

			internal IEnumerator _0024_0024iterator_002413328_002415749;

			internal IEnumerator _0024_0024iterator_002413329_002415750;

			internal IEnumerator _0024_0024iterator_002413330_002415751;

			internal IEnumerator _0024_0024iterator_002413331_002415752;

			internal IEnumerator _0024_0024iterator_002413332_002415753;

			internal IEnumerator _0024_0024iterator_002413333_002415754;

			internal IEnumerator _0024_0024iterator_002413334_002415755;

			internal IEnumerator _0024_0024iterator_002413335_002415756;

			internal LotterySequence _0024self__002415757;

			public _0024(LotterySequence self_)
			{
				_0024self__002415757 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002415688 = "S540_Home";
					_0024_0024CUR_EXEC_0024_002415689 = _0024self__002415757.lastCreatedExec;
					IconAtlasPool.UnloadAll();
					BattleHUDShortcut.Show();
					_0024self__002415757.SkipHide();
					_0024self__002415757.TapHide();
					_0024self__002415757.NikiIdle();
					WebViewBase.Visible(flag: false);
					_0024waitSec_002415690 = 1f;
					goto IL_0113;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002415689.NotExecuting)
					{
						goto IL_0113;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413322_002415743.MoveNext())
					{
						_0024_0024s540_0024call_0024725_002415693 = _0024_0024iterator_002413322_002415743.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024725_002415693) ? 1 : 0);
						break;
					}
					goto IL_01e8;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002415689.NotExecuting)
					{
						goto IL_0229;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413323_002415744.MoveNext())
					{
						_0024_0024s540_0024call_0024728_002415696 = _0024_0024iterator_002413323_002415744.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024728_002415696) ? 1 : 0);
						break;
					}
					goto IL_02d5;
				case 6:
					if (_0024_0024iterator_002413324_002415745.MoveNext())
					{
						_0024_0024s540_0024call_0024731_002415699 = _0024_0024iterator_002413324_002415745.Current;
						result = (Yield(6, _0024_0024s540_0024call_0024731_002415699) ? 1 : 0);
						break;
					}
					goto IL_03a7;
				case 7:
					if (_0024_0024iterator_002413325_002415746.MoveNext())
					{
						_0024_0024s540_0024call_0024734_002415702 = _0024_0024iterator_002413325_002415746.Current;
						result = (Yield(7, _0024_0024s540_0024call_0024734_002415702) ? 1 : 0);
						break;
					}
					goto IL_0488;
				case 8:
					if (_0024_0024iterator_002413326_002415747.MoveNext())
					{
						_0024_0024s540_0024call_0024737_002415705 = _0024_0024iterator_002413326_002415747.Current;
						result = (Yield(8, _0024_0024s540_0024call_0024737_002415705) ? 1 : 0);
						break;
					}
					goto IL_0559;
				case 9:
					if (_0024_0024iterator_002413327_002415748.MoveNext())
					{
						_0024_0024s540_0024call_0024740_002415708 = _0024_0024iterator_002413327_002415748.Current;
						result = (Yield(9, _0024_0024s540_0024call_0024740_002415708) ? 1 : 0);
						break;
					}
					goto IL_0687;
				case 10:
					if (_0024_0024iterator_002413328_002415749.MoveNext())
					{
						_0024_0024s540_0024call_0024743_002415711 = _0024_0024iterator_002413328_002415749.Current;
						result = (Yield(10, _0024_0024s540_0024call_0024743_002415711) ? 1 : 0);
						break;
					}
					goto IL_0750;
				case 11:
					if (_0024_0024iterator_002413329_002415750.MoveNext())
					{
						_0024_0024s540_0024call_0024746_002415714 = _0024_0024iterator_002413329_002415750.Current;
						result = (Yield(11, _0024_0024s540_0024call_0024746_002415714) ? 1 : 0);
						break;
					}
					goto IL_0804;
				case 12:
					if (_0024_0024iterator_002413330_002415751.MoveNext())
					{
						_0024_0024s540_0024call_0024749_002415717 = _0024_0024iterator_002413330_002415751.Current;
						result = (Yield(12, _0024_0024s540_0024call_0024749_002415717) ? 1 : 0);
						break;
					}
					goto IL_08e3;
				case 13:
					if (_0024_0024iterator_002413331_002415752.MoveNext())
					{
						_0024_0024s540_0024call_0024752_002415722 = _0024_0024iterator_002413331_002415752.Current;
						result = (Yield(13, _0024_0024s540_0024call_0024752_002415722) ? 1 : 0);
						break;
					}
					goto IL_0a60;
				case 14:
					if (_0024_0024iterator_002413332_002415753.MoveNext())
					{
						_0024_0024s540_0024call_0024755_002415727 = _0024_0024iterator_002413332_002415753.Current;
						result = (Yield(14, _0024_0024s540_0024call_0024755_002415727) ? 1 : 0);
						break;
					}
					goto IL_0bdd;
				case 15:
					if (_0024_0024iterator_002413333_002415754.MoveNext())
					{
						_0024_0024s540_0024call_0024758_002415730 = _0024_0024iterator_002413333_002415754.Current;
						result = (Yield(15, _0024_0024s540_0024call_0024758_002415730) ? 1 : 0);
						break;
					}
					goto IL_0c91;
				case 16:
					if (_0024_0024iterator_002413334_002415755.MoveNext())
					{
						_0024_0024s540_0024call_0024761_002415733 = _0024_0024iterator_002413334_002415755.Current;
						result = (Yield(16, _0024_0024s540_0024call_0024761_002415733) ? 1 : 0);
						break;
					}
					goto IL_0d60;
				case 17:
					if (_0024_0024iterator_002413335_002415756.MoveNext())
					{
						_0024_0024s540_0024call_0024764_002415738 = _0024_0024iterator_002413335_002415756.Current;
						result = (Yield(17, _0024_0024s540_0024call_0024764_002415738) ? 1 : 0);
						break;
					}
					goto IL_0edd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0113:
					if (_0024waitSec_002415690 > 0f)
					{
						_0024waitSec_002415690 -= Time.deltaTime;
						if (MerlinServer.Instance.IsBusy)
						{
							_0024waitSec_002415690 = 1f;
						}
						if (DialogManager.DialogCount > 0)
						{
							_0024waitSec_002415690 = 1f;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					WebViewBase.Visible(flag: true);
					if (!_0024self__002415757.gacha1stHome)
					{
						_0024self__002415757.gacha1stHome = true;
						if (startUpdateFunc != null)
						{
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:151", "call命令");
							_0024_0024s540_0024call_0024724_002415691 = _0024self__002415757.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024723_002415692 = _0024self__002415757.S540_WaitSec(0.1f);
							if (_0024_0024s540_0024call_0024723_002415692 != null)
							{
								_0024_0024iterator_002413322_002415743 = _0024_0024s540_0024call_0024723_002415692;
								goto case 3;
							}
							goto IL_01e8;
						}
					}
					goto IL_023e;
					IL_0edd:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:202", "go命令 " + _0024self__002415757.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "true" + ")");
						_0024_0024s540_0024go_0024719_002415739 = _0024self__002415757.createExecAsCurrent("S540_FriendPointLottery");
						_0024_0024s540_0024tmp_0024720_002415740 = _0024self__002415757.S540_FriendPointLottery(eventFlag: true);
						_0024self__002415757.entryCoroutine(_0024_0024s540_0024go_0024719_002415739, _0024_0024s540_0024tmp_0024720_002415740);
						_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					}
					goto case 1;
					IL_0687:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						if (btnNo == 0)
						{
							_0024self__002415757.gachaMode = 0;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:176", "call命令");
							_0024_0024s540_0024call_0024742_002415709 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024741_002415710 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024741_002415710 != null)
							{
								_0024_0024iterator_002413328_002415749 = _0024_0024s540_0024call_0024741_002415710;
								goto case 10;
							}
							goto IL_0750;
						}
						if (btnNo == 1 || _0024self__002415757.testMode)
						{
							_0024self__002415757.gachaMode = 1;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:181", "call命令");
							_0024_0024s540_0024call_0024748_002415715 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024747_002415716 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024747_002415716 != null)
							{
								_0024_0024iterator_002413330_002415751 = _0024_0024s540_0024call_0024747_002415716;
								goto case 12;
							}
							goto IL_08e3;
						}
						if (btnNo == 2)
						{
							_0024self__002415757.gachaMode = 2;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:186", "call命令");
							_0024_0024s540_0024call_0024751_002415720 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024750_002415721 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024750_002415721 != null)
							{
								_0024_0024iterator_002413331_002415752 = _0024_0024s540_0024call_0024750_002415721;
								goto case 13;
							}
							goto IL_0a60;
						}
						if (btnNo == 3)
						{
							_0024self__002415757.gachaMode = 3;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:191", "call命令");
							_0024_0024s540_0024call_0024754_002415725 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024753_002415726 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024753_002415726 != null)
							{
								_0024_0024iterator_002413332_002415753 = _0024_0024s540_0024call_0024753_002415726;
								goto case 14;
							}
							goto IL_0bdd;
						}
						if (btnNo == 4)
						{
							_0024self__002415757.gachaMode = 4;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:196", "call命令");
							_0024_0024s540_0024call_0024760_002415731 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024759_002415732 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024759_002415732 != null)
							{
								_0024_0024iterator_002413334_002415755 = _0024_0024s540_0024call_0024759_002415732;
								goto case 16;
							}
							goto IL_0d60;
						}
						if (btnNo == 5)
						{
							_0024self__002415757.gachaMode = 5;
							_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:201", "call命令");
							_0024_0024s540_0024call_0024763_002415736 = _0024self__002415757.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415689);
							_0024_0024s540_0024call_0024762_002415737 = _0024self__002415757.S540_PanelExit();
							if (_0024_0024s540_0024call_0024762_002415737 != null)
							{
								_0024_0024iterator_002413335_002415756 = _0024_0024s540_0024call_0024762_002415737;
								goto case 17;
							}
							goto IL_0edd;
						}
						if (btnNo != 6)
						{
							goto IL_1074;
						}
						_0024self__002415757.gachaMode = 6;
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:208", "go命令 " + _0024self__002415757.CurrentStateName + "->" + "S540_End" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024721_002415741 = _0024self__002415757.createExecAsCurrent("S540_End");
						_0024_0024s540_0024tmp_0024722_002415742 = _0024self__002415757.S540_End();
						_0024self__002415757.entryCoroutine(_0024_0024s540_0024go_0024721_002415741, _0024_0024s540_0024tmp_0024722_002415742);
						_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					}
					goto case 1;
					IL_01e8:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					goto IL_0229;
					IL_0229:
					if (!startUpdateFunc())
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					startUpdateFunc = null;
					goto IL_023e;
					IL_0750:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:177", "call命令");
					_0024_0024s540_0024call_0024745_002415712 = _0024self__002415757.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024744_002415713 = _0024self__002415757.S540_GoStoneGacha(eventFlag: false);
					if (_0024_0024s540_0024call_0024744_002415713 != null)
					{
						_0024_0024iterator_002413329_002415750 = _0024_0024s540_0024call_0024744_002415713;
						goto case 11;
					}
					goto IL_0804;
					IL_023e:
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:155", "call命令");
					_0024_0024s540_0024call_0024727_002415694 = _0024self__002415757.createExec("S540_BoxCheck", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024726_002415695 = _0024self__002415757.S540_BoxCheck();
					if (_0024_0024s540_0024call_0024726_002415695 != null)
					{
						_0024_0024iterator_002413323_002415744 = _0024_0024s540_0024call_0024726_002415695;
						goto case 5;
					}
					goto IL_02d5;
					IL_02d5:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					_0024self__002415757.BlackHalf();
					_0024self__002415757.PanelActive("Home", "GachaMenu");
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:160", "call命令");
					_0024_0024s540_0024call_0024730_002415697 = _0024self__002415757.createExec("S540_PanelIn", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024729_002415698 = _0024self__002415757.S540_PanelIn();
					if (_0024_0024s540_0024call_0024729_002415698 != null)
					{
						_0024_0024iterator_002413324_002415745 = _0024_0024s540_0024call_0024729_002415698;
						goto case 6;
					}
					goto IL_03a7;
					IL_1074:
					_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					goto case 1;
					IL_0804:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					goto IL_1074;
					IL_0bdd:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:192", "call命令");
					_0024_0024s540_0024call_0024757_002415728 = _0024self__002415757.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024756_002415729 = _0024self__002415757.S540_GoStoneGacha(eventFlag: true);
					if (_0024_0024s540_0024call_0024756_002415729 != null)
					{
						_0024_0024iterator_002413333_002415754 = _0024_0024s540_0024call_0024756_002415729;
						goto case 15;
					}
					goto IL_0c91;
					IL_03a7:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					if (!(_0024self__002415757.ScreenAspect() <= 1.5f))
					{
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:162", "call命令");
						_0024_0024s540_0024call_0024733_002415700 = _0024self__002415757.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415689);
						_0024_0024s540_0024call_0024732_002415701 = _0024self__002415757.S540_Selif(_0024self__002415757.selif_greeting, -410f, 160f, 10f);
						if (_0024_0024s540_0024call_0024732_002415701 != null)
						{
							_0024_0024iterator_002413325_002415746 = _0024_0024s540_0024call_0024732_002415701;
							goto case 7;
						}
						goto IL_0488;
					}
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:164", "call命令");
					_0024_0024s540_0024call_0024736_002415703 = _0024self__002415757.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024735_002415704 = _0024self__002415757.S540_Selif(_0024self__002415757.selif_greeting, -390f, 160f, -10f);
					if (_0024_0024s540_0024call_0024735_002415704 != null)
					{
						_0024_0024iterator_002413326_002415747 = _0024_0024s540_0024call_0024735_002415704;
						goto case 8;
					}
					goto IL_0559;
					IL_0d60:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:197", "go命令 " + _0024self__002415757.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "true" + ")");
						_0024_0024s540_0024go_0024717_002415734 = _0024self__002415757.createExecAsCurrent("S540_RaidPointLottery");
						_0024_0024s540_0024tmp_0024718_002415735 = _0024self__002415757.S540_RaidPointLottery(eventFlag: true);
						_0024self__002415757.entryCoroutine(_0024_0024s540_0024go_0024717_002415734, _0024_0024s540_0024tmp_0024718_002415735);
						_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					}
					goto case 1;
					IL_08e3:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:182", "go命令 " + _0024self__002415757.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "false" + ")");
						_0024_0024s540_0024go_0024713_002415718 = _0024self__002415757.createExecAsCurrent("S540_RaidPointLottery");
						_0024_0024s540_0024tmp_0024714_002415719 = _0024self__002415757.S540_RaidPointLottery(eventFlag: false);
						_0024self__002415757.entryCoroutine(_0024_0024s540_0024go_0024713_002415718, _0024_0024s540_0024tmp_0024714_002415719);
						_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					}
					goto case 1;
					IL_0488:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					goto IL_0574;
					IL_0c91:
					if (!_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto case 1;
					}
					goto IL_1074;
					IL_0a60:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:187", "go命令 " + _0024self__002415757.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "false" + ")");
						_0024_0024s540_0024go_0024715_002415723 = _0024self__002415757.createExecAsCurrent("S540_FriendPointLottery");
						_0024_0024s540_0024tmp_0024716_002415724 = _0024self__002415757.S540_FriendPointLottery(eventFlag: false);
						_0024self__002415757.entryCoroutine(_0024_0024s540_0024go_0024715_002415723, _0024_0024s540_0024tmp_0024716_002415724);
						_0024self__002415757.stop(_0024_0024CUR_EXEC_0024_002415689);
					}
					goto case 1;
					IL_0559:
					if (_0024self__002415757.isExecuting(_0024_0024CUR_EXEC_0024_002415689))
					{
						goto IL_0574;
					}
					goto case 1;
					IL_0574:
					_0024self__002415757.CamHome();
					_0024self__002415757.ShowHUD(show: true);
					if (startId >= 0)
					{
						_0024self__002415757.CheckUrl(startId.ToString());
						startId = -1;
					}
					_0024self__002415757.dtrace(_0024_0024CUR_EXEC_0024_002415689, "LotterySequence.boo:173", "call命令");
					_0024_0024s540_0024call_0024739_002415706 = _0024self__002415757.createExec("S540_WaitButtons", _0024_0024CUR_EXEC_0024_002415689);
					_0024_0024s540_0024call_0024738_002415707 = _0024self__002415757.S540_WaitButtons(new string[7] { "FayStone", "RaidPoint", "FriendPoint", "FayStoneEvent", "RaidPointEvent", "FriendPointEvent", "Back" });
					if (_0024_0024s540_0024call_0024738_002415707 != null)
					{
						_0024_0024iterator_002413327_002415748 = _0024_0024s540_0024call_0024738_002415707;
						goto case 9;
					}
					goto IL_0687;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002415758;

		public _0024S540_Home_002415687(LotterySequence self_)
		{
			_0024self__002415758 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415758);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_GoStoneGacha_002415759 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024768_002415760;

			internal object _0024___item_002415761;

			internal IEnumerator _0024_0024iterator_002413336_002415762;

			internal bool _0024eventFlag_002415763;

			internal LotterySequence _0024self__002415764;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415763 = eventFlag;
				_0024self__002415764 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024768_002415760 = _0024self__002415764.S540_GoStoneGacha(_0024eventFlag_002415763, null);
					if (_0024_0024s540_0024ycode_0024768_002415760 != null)
					{
						_0024_0024iterator_002413336_002415762 = _0024_0024s540_0024ycode_0024768_002415760;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413336_002415762.MoveNext())
					{
						_0024___item_002415761 = _0024_0024iterator_002413336_002415762.Current;
						result = (Yield(2, _0024___item_002415761) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415765;

		internal LotterySequence _0024self__002415766;

		public _0024S540_GoStoneGacha_002415759(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415765 = eventFlag;
			_0024self__002415766 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415765, _0024self__002415766);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FayStoneLottery_002415767 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024811_002415768;

			internal object _0024___item_002415769;

			internal IEnumerator _0024_0024iterator_002413337_002415770;

			internal bool _0024eventFlag_002415771;

			internal LotterySequence _0024self__002415772;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415771 = eventFlag;
				_0024self__002415772 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024811_002415768 = _0024self__002415772.S540_FayStoneLottery(_0024eventFlag_002415771, null);
					if (_0024_0024s540_0024ycode_0024811_002415768 != null)
					{
						_0024_0024iterator_002413337_002415770 = _0024_0024s540_0024ycode_0024811_002415768;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413337_002415770.MoveNext())
					{
						_0024___item_002415769 = _0024_0024iterator_002413337_002415770.Current;
						result = (Yield(2, _0024___item_002415769) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415773;

		internal LotterySequence _0024self__002415774;

		public _0024S540_FayStoneLottery_002415767(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415773 = eventFlag;
			_0024self__002415774 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415773, _0024self__002415774);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FayStoneLottery_002415775 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415776;

			internal int _0024price_002415777;

			internal int _0024turn_002415778;

			internal Exec _0024_0024s540_0024go_0024769_002415779;

			internal IEnumerator _0024_0024s540_0024tmp_0024770_002415780;

			internal Exec _0024_0024s540_0024call_0024782_002415781;

			internal IEnumerator _0024_0024s540_0024call_0024781_002415782;

			internal object _0024_0024s540_0024call_0024783_002415783;

			internal Exec _0024_0024s540_0024call_0024785_002415784;

			internal IEnumerator _0024_0024s540_0024call_0024784_002415785;

			internal object _0024_0024s540_0024call_0024786_002415786;

			internal Exec _0024_0024s540_0024call_0024788_002415787;

			internal IEnumerator _0024_0024s540_0024call_0024787_002415788;

			internal object _0024_0024s540_0024call_0024789_002415789;

			internal Exec _0024_0024s540_0024call_0024791_002415790;

			internal IEnumerator _0024_0024s540_0024call_0024790_002415791;

			internal object _0024_0024s540_0024call_0024792_002415792;

			internal Exec _0024_0024s540_0024call_0024794_002415793;

			internal IEnumerator _0024_0024s540_0024call_0024793_002415794;

			internal object _0024_0024s540_0024call_0024795_002415795;

			internal Exec _0024_0024s540_0024call_0024797_002415796;

			internal IEnumerator _0024_0024s540_0024call_0024796_002415797;

			internal object _0024_0024s540_0024call_0024798_002415798;

			internal Exec _0024_0024s540_0024call_0024800_002415799;

			internal IEnumerator _0024_0024s540_0024call_0024799_002415800;

			internal object _0024_0024s540_0024call_0024801_002415801;

			internal Exec _0024_0024s540_0024go_0024771_002415802;

			internal IEnumerator _0024_0024s540_0024tmp_0024772_002415803;

			internal Exec _0024_0024s540_0024go_0024773_002415804;

			internal IEnumerator _0024_0024s540_0024tmp_0024774_002415805;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002415806;

			internal Exec _0024_0024s540_0024call_0024803_002415807;

			internal IEnumerator _0024_0024s540_0024call_0024802_002415808;

			internal object _0024_0024s540_0024call_0024804_002415809;

			internal Exec _0024_0024s540_0024call_0024806_002415810;

			internal IEnumerator _0024_0024s540_0024call_0024805_002415811;

			internal object _0024_0024s540_0024call_0024807_002415812;

			internal Exec _0024_0024s540_0024go_0024777_002415813;

			internal IEnumerator _0024_0024s540_0024tmp_0024778_002415814;

			internal Exec _0024_0024s540_0024call_0024809_002415815;

			internal IEnumerator _0024_0024s540_0024call_0024808_002415816;

			internal object _0024_0024s540_0024call_0024810_002415817;

			internal Exec _0024_0024s540_0024go_0024779_002415818;

			internal IEnumerator _0024_0024s540_0024tmp_0024780_002415819;

			internal IEnumerator _0024_0024iterator_002413338_002415820;

			internal IEnumerator _0024_0024iterator_002413339_002415821;

			internal IEnumerator _0024_0024iterator_002413340_002415822;

			internal IEnumerator _0024_0024iterator_002413341_002415823;

			internal IEnumerator _0024_0024iterator_002413342_002415824;

			internal IEnumerator _0024_0024iterator_002413343_002415825;

			internal IEnumerator _0024_0024iterator_002413344_002415826;

			internal IEnumerator _0024_0024iterator_002413345_002415827;

			internal IEnumerator _0024_0024iterator_002413346_002415828;

			internal IEnumerator _0024_0024iterator_002413347_002415829;

			internal _0024S540_FayStoneLottery_0024locals_002414329 _0024_0024locals_002415830;

			internal bool _0024eventFlag_002415831;

			internal LotterySequence _0024self__002415832;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415831 = eventFlag;
				_0024self__002415832 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002415830 = new _0024S540_FayStoneLottery_0024locals_002414329();
					_0024_0024STATE_NAME_0024_002415776 = "S540_FayStoneLottery";
					_0024_0024locals_002415830._0024_0024CUR_EXEC_0024 = _0024self__002415832.lastCreatedExec;
					_0024self__002415832.lastEventFlag = _0024eventFlag_002415831;
					_0024price_002415777 = 1;
					_0024turn_002415778 = 1;
					if (!_0024self__002415832.testMode)
					{
						_0024self__002415832.curGacha.GetPriceAndTurn(ref _0024price_002415777, ref _0024turn_002415778);
					}
					if (_0024self__002415832.testMode)
					{
						_0024turn_002415778 = _0024self__002415832.testPrzNum;
					}
					WebViewBase.Visible(flag: false);
					goto IL_0108;
				case 2:
					if (!_0024_0024locals_002415830._0024_0024CUR_EXEC_0024.NotExecuting)
					{
						goto IL_0108;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413338_002415820.MoveNext())
					{
						_0024_0024s540_0024call_0024783_002415783 = _0024_0024iterator_002413338_002415820.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024783_002415783) ? 1 : 0);
						break;
					}
					goto IL_0465;
				case 4:
					if (_0024_0024iterator_002413339_002415821.MoveNext())
					{
						_0024_0024s540_0024call_0024786_002415786 = _0024_0024iterator_002413339_002415821.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024786_002415786) ? 1 : 0);
						break;
					}
					goto IL_0560;
				case 5:
					if (_0024_0024iterator_002413340_002415822.MoveNext())
					{
						_0024_0024s540_0024call_0024789_002415789 = _0024_0024iterator_002413340_002415822.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024789_002415789) ? 1 : 0);
						break;
					}
					goto IL_0640;
				case 6:
					if (_0024_0024iterator_002413341_002415823.MoveNext())
					{
						_0024_0024s540_0024call_0024792_002415792 = _0024_0024iterator_002413341_002415823.Current;
						result = (Yield(6, _0024_0024s540_0024call_0024792_002415792) ? 1 : 0);
						break;
					}
					goto IL_0735;
				case 7:
					if (_0024_0024iterator_002413342_002415824.MoveNext())
					{
						_0024_0024s540_0024call_0024795_002415795 = _0024_0024iterator_002413342_002415824.Current;
						result = (Yield(7, _0024_0024s540_0024call_0024795_002415795) ? 1 : 0);
						break;
					}
					goto IL_0815;
				case 8:
					if (_0024_0024iterator_002413343_002415825.MoveNext())
					{
						_0024_0024s540_0024call_0024798_002415798 = _0024_0024iterator_002413343_002415825.Current;
						result = (Yield(8, _0024_0024s540_0024call_0024798_002415798) ? 1 : 0);
						break;
					}
					goto IL_08ea;
				case 9:
					if (_0024_0024iterator_002413344_002415826.MoveNext())
					{
						_0024_0024s540_0024call_0024801_002415801 = _0024_0024iterator_002413344_002415826.Current;
						result = (Yield(9, _0024_0024s540_0024call_0024801_002415801) ? 1 : 0);
						break;
					}
					goto IL_09b6;
				case 10:
					if (_0024_0024iterator_002413345_002415827.MoveNext())
					{
						_0024_0024s540_0024call_0024804_002415809 = _0024_0024iterator_002413345_002415827.Current;
						result = (Yield(10, _0024_0024s540_0024call_0024804_002415809) ? 1 : 0);
						break;
					}
					goto IL_0c4e;
				case 11:
					if (_0024_0024iterator_002413346_002415828.MoveNext())
					{
						_0024_0024s540_0024call_0024807_002415812 = _0024_0024iterator_002413346_002415828.Current;
						result = (Yield(11, _0024_0024s540_0024call_0024807_002415812) ? 1 : 0);
						break;
					}
					goto IL_0d20;
				case 12:
					if (_0024_0024iterator_002413347_002415829.MoveNext())
					{
						_0024_0024s540_0024call_0024810_002415817 = _0024_0024iterator_002413347_002415829.Current;
						result = (Yield(12, _0024_0024s540_0024call_0024810_002415817) ? 1 : 0);
						break;
					}
					goto IL_0ea9;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0815:
					if (_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto IL_0835;
					}
					goto case 1;
					IL_0465:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					if (!_0024eventFlag_002415831)
					{
						if (!(_0024self__002415832.ScreenAspect() <= 1.5f))
						{
							_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:246", "call命令");
							_0024_0024s540_0024call_0024785_002415784 = _0024self__002415832.createExec("S540_Selif", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
							_0024_0024s540_0024call_0024784_002415785 = _0024self__002415832.S540_Selif(_0024self__002415832.selif_sel_stone, -410f, 160f, 10f);
							if (_0024_0024s540_0024call_0024784_002415785 != null)
							{
								_0024_0024iterator_002413339_002415821 = _0024_0024s540_0024call_0024784_002415785;
								goto case 4;
							}
							goto IL_0560;
						}
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:248", "call命令");
						_0024_0024s540_0024call_0024788_002415787 = _0024self__002415832.createExec("S540_Selif", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_0024787_002415788 = _0024self__002415832.S540_Selif(_0024self__002415832.selif_sel_stone, -390f, 160f, -10f);
						if (_0024_0024s540_0024call_0024787_002415788 != null)
						{
							_0024_0024iterator_002413340_002415822 = _0024_0024s540_0024call_0024787_002415788;
							goto case 5;
						}
						goto IL_0640;
					}
					if (!(_0024self__002415832.ScreenAspect() <= 1.5f))
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:251", "call命令");
						_0024_0024s540_0024call_0024791_002415790 = _0024self__002415832.createExec("S540_Selif", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_0024790_002415791 = _0024self__002415832.S540_Selif(_0024self__002415832.selif_sel_event, -410f, 160f, 10f);
						if (_0024_0024s540_0024call_0024790_002415791 != null)
						{
							_0024_0024iterator_002413341_002415823 = _0024_0024s540_0024call_0024790_002415791;
							goto case 6;
						}
						goto IL_0735;
					}
					_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:253", "call命令");
					_0024_0024s540_0024call_0024794_002415793 = _0024self__002415832.createExec("S540_Selif", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					_0024_0024s540_0024call_0024793_002415794 = _0024self__002415832.S540_Selif(_0024self__002415832.selif_sel_event, -390f, 160f, -10f);
					if (_0024_0024s540_0024call_0024793_002415794 != null)
					{
						_0024_0024iterator_002413342_002415824 = _0024_0024s540_0024call_0024793_002415794;
						goto case 7;
					}
					goto IL_0815;
					IL_0835:
					_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:255", "call命令");
					_0024_0024s540_0024call_0024797_002415796 = _0024self__002415832.createExec("S540_WaitButton", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					_0024_0024s540_0024call_0024796_002415797 = _0024self__002415832.S540_WaitButton("Single", "Back", "Info", string.Empty);
					if (_0024_0024s540_0024call_0024796_002415797 != null)
					{
						_0024_0024iterator_002413343_002415825 = _0024_0024s540_0024call_0024796_002415797;
						goto case 8;
					}
					goto IL_08ea;
					IL_0108:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					WebViewBase.Visible(flag: true);
					_0024self__002415832.przNum = _0024turn_002415778;
					if (!_0024self__002415832.testMode)
					{
						if (_0024self__002415832.curGacha == null)
						{
							_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:226", "go命令 " + _0024self__002415832.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024769_002415779 = _0024self__002415832.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024770_002415780 = _0024self__002415832.S540_Home();
							_0024self__002415832.entryCoroutine(_0024_0024s540_0024go_0024769_002415779, _0024_0024s540_0024tmp_0024770_002415780);
							_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
							goto case 1;
						}
						if (!_0024eventFlag_002415831)
						{
							if ((bool)_0024self__002415832.fayStoneTitle)
							{
								_0024self__002415832.fayStoneTitle.text = _0024self__002415832.curGacha.Name;
							}
							if ((bool)_0024self__002415832.fayStoneExplain)
							{
								_0024self__002415832.fayStoneExplain.text = _0024self__002415832.curGacha.Description;
							}
							_0024self__002415832.SetFormat(_0024self__002415832.faystoneNumText, UserData.Current.FayStone.ToString());
							_0024self__002415832.SetFormat(_0024self__002415832.faystonePriceText, _0024price_002415777.ToString());
							_0024self__002415832.PanelActive("FayStone", string.Empty);
						}
						else
						{
							if ((bool)_0024self__002415832.fayStoneEventTitle)
							{
								_0024self__002415832.fayStoneEventTitle.text = _0024self__002415832.curGacha.Name;
							}
							if ((bool)_0024self__002415832.fayStoneEventExplain)
							{
								_0024self__002415832.fayStoneEventExplain.text = _0024self__002415832.curGacha.Description;
							}
							_0024self__002415832.SetFormat(_0024self__002415832.faystoneEventNumText, UserData.Current.FayStone.ToString());
							_0024self__002415832.SetFormat(_0024self__002415832.faystoneEventPriceText, _0024price_002415777.ToString());
							_0024self__002415832.PanelActive("FayStoneEvent", string.Empty);
						}
					}
					else
					{
						_0024self__002415832.PanelActive("FayStone", string.Empty);
					}
					_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:242", "call命令");
					_0024_0024s540_0024call_0024782_002415781 = _0024self__002415832.createExec("S540_PanelIn", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					_0024_0024s540_0024call_0024781_002415782 = _0024self__002415832.S540_PanelIn();
					if (_0024_0024s540_0024call_0024781_002415782 != null)
					{
						_0024_0024iterator_002413338_002415820 = _0024_0024s540_0024call_0024781_002415782;
						goto case 3;
					}
					goto IL_0465;
					IL_08ea:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					if (btnNo == 0)
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:257", "call命令");
						_0024_0024s540_0024call_0024800_002415799 = _0024self__002415832.createExec("S540_PanelExit", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_0024799_002415800 = _0024self__002415832.S540_PanelExit();
						if (_0024_0024s540_0024call_0024799_002415800 != null)
						{
							_0024_0024iterator_002413344_002415826 = _0024_0024s540_0024call_0024799_002415800;
							goto case 9;
						}
						goto IL_09b6;
					}
					if (btnNo == 1)
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:274", "call命令");
						_0024_0024s540_0024call_0024806_002415810 = _0024self__002415832.createExec("S540_PanelExit", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_0024805_002415811 = _0024self__002415832.S540_PanelExit();
						if (_0024_0024s540_0024call_0024805_002415811 != null)
						{
							_0024_0024iterator_002413346_002415828 = _0024_0024s540_0024call_0024805_002415811;
							goto case 11;
						}
						goto IL_0d20;
					}
					if (btnNo == 2)
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:279", "call命令");
						_0024_0024s540_0024call_0024809_002415815 = _0024self__002415832.createExec("S540_PanelExit", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_0024808_002415816 = _0024self__002415832.S540_PanelExit();
						if (_0024_0024s540_0024call_0024808_002415816 != null)
						{
							_0024_0024iterator_002413347_002415829 = _0024_0024s540_0024call_0024808_002415816;
							goto case 12;
						}
						goto IL_0ea9;
					}
					goto IL_0f8a;
					IL_0560:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					goto IL_0835;
					IL_0ea9:
					if (_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:280", "go命令 " + _0024self__002415832.CurrentStateName + "->" + "S540_WebInfo" + "(" + "'FayStoneLottery'" + ")");
						_0024_0024s540_0024go_0024779_002415818 = _0024self__002415832.createExecAsCurrent("S540_WebInfo");
						_0024_0024s540_0024tmp_0024780_002415819 = _0024self__002415832.S540_WebInfo("FayStoneLottery");
						_0024self__002415832.entryCoroutine(_0024_0024s540_0024go_0024779_002415818, _0024_0024s540_0024tmp_0024780_002415819);
						_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					}
					goto case 1;
					IL_0d20:
					if (_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:275", "go命令 " + _0024self__002415832.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024777_002415813 = _0024self__002415832.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024778_002415814 = _0024self__002415832.S540_Home();
						_0024self__002415832.entryCoroutine(_0024_0024s540_0024go_0024777_002415813, _0024_0024s540_0024tmp_0024778_002415814);
						_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					}
					goto case 1;
					IL_0c4e:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					goto IL_0f8a;
					IL_0640:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					goto IL_0835;
					IL_0735:
					if (!_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					goto IL_0835;
					IL_0f8a:
					_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
					goto case 1;
					IL_09b6:
					if (_0024self__002415832.isExecuting(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024))
					{
						if (!_0024self__002415832.testMode && _0024price_002415777 > UserData.Current.FayStone)
						{
							_0024onEnd_002415806 = new _0024S540_FayStoneLottery_0024onEnd_00242954(_0024self__002415832, _0024_0024locals_002415830).Invoke;
							_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:270", "call命令");
							_0024_0024s540_0024call_0024803_002415807 = _0024self__002415832.createExec("S540_ExecuteStoneList", _0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
							_0024_0024s540_0024call_0024802_002415808 = _0024self__002415832.S540_ExecuteStoneList(_0024onEnd_002415806);
							if (_0024_0024s540_0024call_0024802_002415808 != null)
							{
								_0024_0024iterator_002413345_002415827 = _0024_0024s540_0024call_0024802_002415808;
								goto case 10;
							}
							goto IL_0c4e;
						}
						if (_0024turn_002415778 == 1)
						{
							_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:260", "go命令 " + _0024self__002415832.CurrentStateName + "->" + "S540_LotterySingle" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024771_002415802 = _0024self__002415832.createExecAsCurrent("S540_LotterySingle");
							_0024_0024s540_0024tmp_0024772_002415803 = _0024self__002415832.S540_LotterySingle();
							_0024self__002415832.entryCoroutine(_0024_0024s540_0024go_0024771_002415802, _0024_0024s540_0024tmp_0024772_002415803);
							_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						}
						else
						{
							_0024self__002415832.dtrace(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024, "LotterySequence.boo:262", "go命令 " + _0024self__002415832.CurrentStateName + "->" + "S540_LotteryMulti" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024773_002415804 = _0024self__002415832.createExecAsCurrent("S540_LotteryMulti");
							_0024_0024s540_0024tmp_0024774_002415805 = _0024self__002415832.S540_LotteryMulti();
							_0024self__002415832.entryCoroutine(_0024_0024s540_0024go_0024773_002415804, _0024_0024s540_0024tmp_0024774_002415805);
							_0024self__002415832.stop(_0024_0024locals_002415830._0024_0024CUR_EXEC_0024);
						}
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415833;

		internal LotterySequence _0024self__002415834;

		public _0024S540_FayStoneLottery_002415775(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415833 = eventFlag;
			_0024self__002415834 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415833, _0024self__002415834);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_RaidPointLottery_002415835 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024848_002415836;

			internal object _0024___item_002415837;

			internal IEnumerator _0024_0024iterator_002413348_002415838;

			internal bool _0024eventFlag_002415839;

			internal LotterySequence _0024self__002415840;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415839 = eventFlag;
				_0024self__002415840 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024848_002415836 = _0024self__002415840.S540_RaidPointLottery(_0024eventFlag_002415839, null);
					if (_0024_0024s540_0024ycode_0024848_002415836 != null)
					{
						_0024_0024iterator_002413348_002415838 = _0024_0024s540_0024ycode_0024848_002415836;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413348_002415838.MoveNext())
					{
						_0024___item_002415837 = _0024_0024iterator_002413348_002415838.Current;
						result = (Yield(2, _0024___item_002415837) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415841;

		internal LotterySequence _0024self__002415842;

		public _0024S540_RaidPointLottery_002415835(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415841 = eventFlag;
			_0024self__002415842 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415841, _0024self__002415842);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_RaidPointLottery_002415843 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415844;

			internal Exec _0024_0024CUR_EXEC_0024_002415845;

			internal int _0024price_002415846;

			internal int _0024turn_002415847;

			internal Exec _0024_0024s540_0024go_0024812_002415848;

			internal IEnumerator _0024_0024s540_0024tmp_0024813_002415849;

			internal UserData _0024ud_002415850;

			internal int _0024cnt_002415851;

			internal Exec _0024_0024s540_0024call_0024822_002415852;

			internal IEnumerator _0024_0024s540_0024call_0024821_002415853;

			internal object _0024_0024s540_0024call_0024823_002415854;

			internal Exec _0024_0024s540_0024call_0024825_002415855;

			internal IEnumerator _0024_0024s540_0024call_0024824_002415856;

			internal object _0024_0024s540_0024call_0024826_002415857;

			internal Exec _0024_0024s540_0024call_0024828_002415858;

			internal IEnumerator _0024_0024s540_0024call_0024827_002415859;

			internal object _0024_0024s540_0024call_0024829_002415860;

			internal Exec _0024_0024s540_0024call_0024831_002415861;

			internal IEnumerator _0024_0024s540_0024call_0024830_002415862;

			internal object _0024_0024s540_0024call_0024832_002415863;

			internal Exec _0024_0024s540_0024call_0024834_002415864;

			internal IEnumerator _0024_0024s540_0024call_0024833_002415865;

			internal object _0024_0024s540_0024call_0024835_002415866;

			internal int _0024_0024s540_0024loop_0024820_002415867;

			internal Exec _0024_0024s540_0024call_0024837_002415868;

			internal IEnumerator _0024_0024s540_0024call_0024836_002415869;

			internal object _0024_0024s540_0024call_0024838_002415870;

			internal Exec _0024_0024s540_0024call_0024840_002415871;

			internal IEnumerator _0024_0024s540_0024call_0024839_002415872;

			internal object _0024_0024s540_0024call_0024841_002415873;

			internal Exec _0024_0024s540_0024go_0024814_002415874;

			internal IEnumerator _0024_0024s540_0024tmp_0024815_002415875;

			internal Exec _0024_0024s540_0024call_0024843_002415876;

			internal IEnumerator _0024_0024s540_0024call_0024842_002415877;

			internal object _0024_0024s540_0024call_0024844_002415878;

			internal Exec _0024_0024s540_0024go_0024816_002415879;

			internal IEnumerator _0024_0024s540_0024tmp_0024817_002415880;

			internal Exec _0024_0024s540_0024call_0024846_002415881;

			internal IEnumerator _0024_0024s540_0024call_0024845_002415882;

			internal object _0024_0024s540_0024call_0024847_002415883;

			internal Exec _0024_0024s540_0024go_0024818_002415884;

			internal IEnumerator _0024_0024s540_0024tmp_0024819_002415885;

			internal IEnumerator _0024_0024iterator_002413349_002415886;

			internal IEnumerator _0024_0024iterator_002413350_002415887;

			internal IEnumerator _0024_0024iterator_002413351_002415888;

			internal IEnumerator _0024_0024iterator_002413352_002415889;

			internal IEnumerator _0024_0024iterator_002413353_002415890;

			internal IEnumerator _0024_0024iterator_002413354_002415891;

			internal IEnumerator _0024_0024iterator_002413355_002415892;

			internal IEnumerator _0024_0024iterator_002413356_002415893;

			internal IEnumerator _0024_0024iterator_002413357_002415894;

			internal bool _0024eventFlag_002415895;

			internal LotterySequence _0024self__002415896;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415895 = eventFlag;
				_0024self__002415896 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002415844 = "S540_RaidPointLottery";
					_0024_0024CUR_EXEC_0024_002415845 = _0024self__002415896.lastCreatedExec;
					_0024self__002415896.lastEventFlag = _0024eventFlag_002415895;
					_0024price_002415846 = 100;
					_0024turn_002415847 = 1;
					if (!_0024self__002415896.testMode)
					{
						_0024self__002415896.curGacha.GetPriceAndTurn(ref _0024price_002415846, ref _0024turn_002415847);
					}
					if (_0024self__002415896.testMode)
					{
						_0024turn_002415847 = _0024self__002415896.testPrzNum;
					}
					WebViewBase.Visible(flag: false);
					goto IL_00f4;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002415845.NotExecuting)
					{
						goto IL_00f4;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413349_002415886.MoveNext())
					{
						_0024_0024s540_0024call_0024823_002415854 = _0024_0024iterator_002413349_002415886.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024823_002415854) ? 1 : 0);
						break;
					}
					goto IL_0514;
				case 4:
					if (_0024_0024iterator_002413350_002415887.MoveNext())
					{
						_0024_0024s540_0024call_0024826_002415857 = _0024_0024iterator_002413350_002415887.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024826_002415857) ? 1 : 0);
						break;
					}
					goto IL_0600;
				case 5:
					if (_0024_0024iterator_002413351_002415888.MoveNext())
					{
						_0024_0024s540_0024call_0024829_002415860 = _0024_0024iterator_002413351_002415888.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024829_002415860) ? 1 : 0);
						break;
					}
					goto IL_06d1;
				case 6:
					if (_0024_0024iterator_002413352_002415889.MoveNext())
					{
						_0024_0024s540_0024call_0024832_002415863 = _0024_0024iterator_002413352_002415889.Current;
						result = (Yield(6, _0024_0024s540_0024call_0024832_002415863) ? 1 : 0);
						break;
					}
					goto IL_07b7;
				case 7:
					if (_0024_0024iterator_002413353_002415890.MoveNext())
					{
						_0024_0024s540_0024call_0024835_002415866 = _0024_0024iterator_002413353_002415890.Current;
						result = (Yield(7, _0024_0024s540_0024call_0024835_002415866) ? 1 : 0);
						break;
					}
					goto IL_0888;
				case 8:
					if (_0024_0024iterator_002413354_002415891.MoveNext())
					{
						_0024_0024s540_0024call_0024838_002415870 = _0024_0024iterator_002413354_002415891.Current;
						result = (Yield(8, _0024_0024s540_0024call_0024838_002415870) ? 1 : 0);
						break;
					}
					goto IL_0979;
				case 9:
					if (_0024_0024iterator_002413355_002415892.MoveNext())
					{
						_0024_0024s540_0024call_0024841_002415873 = _0024_0024iterator_002413355_002415892.Current;
						result = (Yield(9, _0024_0024s540_0024call_0024841_002415873) ? 1 : 0);
						break;
					}
					goto IL_0a42;
				case 10:
					if (_0024_0024iterator_002413356_002415893.MoveNext())
					{
						_0024_0024s540_0024call_0024844_002415878 = _0024_0024iterator_002413356_002415893.Current;
						result = (Yield(10, _0024_0024s540_0024call_0024844_002415878) ? 1 : 0);
						break;
					}
					goto IL_0bb7;
				case 11:
					if (_0024_0024iterator_002413357_002415894.MoveNext())
					{
						_0024_0024s540_0024call_0024847_002415883 = _0024_0024iterator_002413357_002415894.Current;
						result = (Yield(11, _0024_0024s540_0024call_0024847_002415883) ? 1 : 0);
						break;
					}
					goto IL_0d27;
				case 12:
					if (_0024_0024CUR_EXEC_0024_002415845.NotExecuting)
					{
						goto case 1;
					}
					goto IL_08c3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0bb7:
					if (_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:341", "go命令 " + _0024self__002415896.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024816_002415879 = _0024self__002415896.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024817_002415880 = _0024self__002415896.S540_Home();
						_0024self__002415896.entryCoroutine(_0024_0024s540_0024go_0024816_002415879, _0024_0024s540_0024tmp_0024817_002415880);
						_0024self__002415896.stop(_0024_0024CUR_EXEC_0024_002415845);
					}
					goto case 1;
					IL_07b7:
					if (!_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto case 1;
					}
					goto IL_08a3;
					IL_00f4:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					WebViewBase.Visible(flag: true);
					if (!_0024self__002415896.testMode)
					{
						if (_0024self__002415896.curGacha == null)
						{
							_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:293", "go命令 " + _0024self__002415896.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024812_002415848 = _0024self__002415896.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024813_002415849 = _0024self__002415896.S540_Home();
							_0024self__002415896.entryCoroutine(_0024_0024s540_0024go_0024812_002415848, _0024_0024s540_0024tmp_0024813_002415849);
							_0024self__002415896.stop(_0024_0024CUR_EXEC_0024_002415845);
							goto case 1;
						}
						_0024ud_002415850 = UserData.Current;
						_0024cnt_002415851 = 0;
						if (!_0024eventFlag_002415895)
						{
							if ((bool)_0024self__002415896.raidPointTitle)
							{
								_0024self__002415896.raidPointTitle.text = _0024self__002415896.curGacha.Name;
							}
							if ((bool)_0024self__002415896.raidPointExplain)
							{
								_0024self__002415896.raidPointExplain.text = _0024self__002415896.curGacha.Description;
							}
							if (_0024price_002415846 > 0)
							{
								_0024cnt_002415851 = _0024ud_002415850.Rp / _0024price_002415846;
							}
							_0024self__002415896.przNum = checked(_0024cnt_002415851 * _0024turn_002415847);
							if ((bool)_0024self__002415896.raidPointButtonValid)
							{
								_0024self__002415896.raidPointButtonValid.isValidColor = _0024cnt_002415851 > 0;
							}
							_0024self__002415896.SetFormat(_0024self__002415896.raidPointNumText, _0024ud_002415850.Rp.ToString());
							_0024self__002415896.SetFormat(_0024self__002415896.raidPointPriceText, _0024price_002415846.ToString());
							_0024self__002415896.PanelActive("RaidPoint", string.Empty);
						}
						else
						{
							if ((bool)_0024self__002415896.raidPointEventTitle)
							{
								_0024self__002415896.raidPointEventTitle.text = _0024self__002415896.curGacha.Name;
							}
							if ((bool)_0024self__002415896.raidPointEventExplain)
							{
								_0024self__002415896.raidPointEventExplain.text = _0024self__002415896.curGacha.Description;
							}
							if (_0024price_002415846 > 0)
							{
								_0024cnt_002415851 = _0024ud_002415850.Rp / _0024price_002415846;
							}
							_0024self__002415896.przNum = checked(_0024cnt_002415851 * _0024turn_002415847);
							if ((bool)_0024self__002415896.raidPointEventButtonValid)
							{
								_0024self__002415896.raidPointEventButtonValid.isValidColor = _0024cnt_002415851 > 0;
							}
							_0024self__002415896.SetFormat(_0024self__002415896.raidPointEventNumText, _0024ud_002415850.Rp.ToString());
							_0024self__002415896.SetFormat(_0024self__002415896.raidPointEventPriceText, _0024price_002415846.ToString());
							_0024self__002415896.PanelActive("RaidPointEvent", string.Empty);
						}
					}
					else
					{
						_0024self__002415896.PanelActive("RaidPointEvent", string.Empty);
					}
					_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:317", "call命令");
					_0024_0024s540_0024call_0024822_002415852 = _0024self__002415896.createExec("S540_PanelIn", _0024_0024CUR_EXEC_0024_002415845);
					_0024_0024s540_0024call_0024821_002415853 = _0024self__002415896.S540_PanelIn();
					if (_0024_0024s540_0024call_0024821_002415853 != null)
					{
						_0024_0024iterator_002413349_002415886 = _0024_0024s540_0024call_0024821_002415853;
						goto case 3;
					}
					goto IL_0514;
					IL_0514:
					if (!_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto case 1;
					}
					if (!_0024eventFlag_002415895)
					{
						if (!(_0024self__002415896.ScreenAspect() <= 1.5f))
						{
							_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:321", "call命令");
							_0024_0024s540_0024call_0024825_002415855 = _0024self__002415896.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415845);
							_0024_0024s540_0024call_0024824_002415856 = _0024self__002415896.S540_Selif(_0024self__002415896.selif_sel_raid, -410f, 160f, 10f);
							if (_0024_0024s540_0024call_0024824_002415856 != null)
							{
								_0024_0024iterator_002413350_002415887 = _0024_0024s540_0024call_0024824_002415856;
								goto case 4;
							}
							goto IL_0600;
						}
						_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:323", "call命令");
						_0024_0024s540_0024call_0024828_002415858 = _0024self__002415896.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415845);
						_0024_0024s540_0024call_0024827_002415859 = _0024self__002415896.S540_Selif(_0024self__002415896.selif_sel_raid, -390f, 160f, -10f);
						if (_0024_0024s540_0024call_0024827_002415859 != null)
						{
							_0024_0024iterator_002413351_002415888 = _0024_0024s540_0024call_0024827_002415859;
							goto case 5;
						}
						goto IL_06d1;
					}
					if (!(_0024self__002415896.ScreenAspect() <= 1.5f))
					{
						_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:326", "call命令");
						_0024_0024s540_0024call_0024831_002415861 = _0024self__002415896.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415845);
						_0024_0024s540_0024call_0024830_002415862 = _0024self__002415896.S540_Selif(_0024self__002415896.selif_sel_event, -410f, 160f, 10f);
						if (_0024_0024s540_0024call_0024830_002415862 != null)
						{
							_0024_0024iterator_002413352_002415889 = _0024_0024s540_0024call_0024830_002415862;
							goto case 6;
						}
						goto IL_07b7;
					}
					_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:328", "call命令");
					_0024_0024s540_0024call_0024834_002415864 = _0024self__002415896.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415845);
					_0024_0024s540_0024call_0024833_002415865 = _0024self__002415896.S540_Selif(_0024self__002415896.selif_sel_event, -390f, 160f, -10f);
					if (_0024_0024s540_0024call_0024833_002415865 != null)
					{
						_0024_0024iterator_002413353_002415890 = _0024_0024s540_0024call_0024833_002415865;
						goto case 7;
					}
					goto IL_0888;
					IL_0a42:
					if (_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:335", "go命令 " + _0024self__002415896.CurrentStateName + "->" + "S540_LotterySingle" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024814_002415874 = _0024self__002415896.createExecAsCurrent("S540_LotterySingle");
						_0024_0024s540_0024tmp_0024815_002415875 = _0024self__002415896.S540_LotterySingle();
						_0024self__002415896.entryCoroutine(_0024_0024s540_0024go_0024814_002415874, _0024_0024s540_0024tmp_0024815_002415875);
						_0024self__002415896.stop(_0024_0024CUR_EXEC_0024_002415845);
					}
					goto case 1;
					IL_0888:
					if (_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto IL_08a3;
					}
					goto case 1;
					IL_0600:
					if (!_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto case 1;
					}
					goto IL_08a3;
					IL_0d27:
					if (_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:346", "go命令 " + _0024self__002415896.CurrentStateName + "->" + "S540_WebInfo" + "(" + "'RaidPointLottery'" + ")");
						_0024_0024s540_0024go_0024818_002415884 = _0024self__002415896.createExecAsCurrent("S540_WebInfo");
						_0024_0024s540_0024tmp_0024819_002415885 = _0024self__002415896.S540_WebInfo("RaidPointLottery");
						_0024self__002415896.entryCoroutine(_0024_0024s540_0024go_0024818_002415884, _0024_0024s540_0024tmp_0024819_002415885);
						_0024self__002415896.stop(_0024_0024CUR_EXEC_0024_002415845);
					}
					goto case 1;
					IL_08c3:
					_0024_0024s540_0024loop_0024820_002415867 = Time.frameCount;
					_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:331", "call命令");
					_0024_0024s540_0024call_0024837_002415868 = _0024self__002415896.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002415845);
					_0024_0024s540_0024call_0024836_002415869 = _0024self__002415896.S540_WaitButton("Single", "Back", "Info", string.Empty);
					if (_0024_0024s540_0024call_0024836_002415869 != null)
					{
						_0024_0024iterator_002413354_002415891 = _0024_0024s540_0024call_0024836_002415869;
						goto case 8;
					}
					goto IL_0979;
					IL_08a3:
					_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:330", "loop命令");
					goto IL_08c3;
					IL_06d1:
					if (!_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto case 1;
					}
					goto IL_08a3;
					IL_0979:
					if (!_0024self__002415896.isExecuting(_0024_0024CUR_EXEC_0024_002415845))
					{
						goto case 1;
					}
					if (btnNo == 0)
					{
						if (_0024cnt_002415851 > 0)
						{
							_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:334", "call命令");
							_0024_0024s540_0024call_0024840_002415871 = _0024self__002415896.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415845);
							_0024_0024s540_0024call_0024839_002415872 = _0024self__002415896.S540_PanelExit();
							if (_0024_0024s540_0024call_0024839_002415872 != null)
							{
								_0024_0024iterator_002413355_002415892 = _0024_0024s540_0024call_0024839_002415872;
								goto case 9;
							}
							goto IL_0a42;
						}
					}
					else
					{
						if (btnNo == 1)
						{
							_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:340", "call命令");
							_0024_0024s540_0024call_0024843_002415876 = _0024self__002415896.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415845);
							_0024_0024s540_0024call_0024842_002415877 = _0024self__002415896.S540_PanelExit();
							if (_0024_0024s540_0024call_0024842_002415877 != null)
							{
								_0024_0024iterator_002413356_002415893 = _0024_0024s540_0024call_0024842_002415877;
								goto case 10;
							}
							goto IL_0bb7;
						}
						if (btnNo == 2)
						{
							_0024self__002415896.dtrace(_0024_0024CUR_EXEC_0024_002415845, "LotterySequence.boo:345", "call命令");
							_0024_0024s540_0024call_0024846_002415881 = _0024self__002415896.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415845);
							_0024_0024s540_0024call_0024845_002415882 = _0024self__002415896.S540_PanelExit();
							if (_0024_0024s540_0024call_0024845_002415882 != null)
							{
								_0024_0024iterator_002413357_002415894 = _0024_0024s540_0024call_0024845_002415882;
								goto case 11;
							}
							goto IL_0d27;
						}
					}
					if (_0024_0024s540_0024loop_0024820_002415867 == Time.frameCount)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					goto case 12;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415897;

		internal LotterySequence _0024self__002415898;

		public _0024S540_RaidPointLottery_002415843(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415897 = eventFlag;
			_0024self__002415898 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415897, _0024self__002415898);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FriendPointLottery_002415899 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024884_002415900;

			internal object _0024___item_002415901;

			internal IEnumerator _0024_0024iterator_002413358_002415902;

			internal bool _0024eventFlag_002415903;

			internal LotterySequence _0024self__002415904;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415903 = eventFlag;
				_0024self__002415904 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024884_002415900 = _0024self__002415904.S540_FriendPointLottery(_0024eventFlag_002415903, null);
					if (_0024_0024s540_0024ycode_0024884_002415900 != null)
					{
						_0024_0024iterator_002413358_002415902 = _0024_0024s540_0024ycode_0024884_002415900;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413358_002415902.MoveNext())
					{
						_0024___item_002415901 = _0024_0024iterator_002413358_002415902.Current;
						result = (Yield(2, _0024___item_002415901) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415905;

		internal LotterySequence _0024self__002415906;

		public _0024S540_FriendPointLottery_002415899(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415905 = eventFlag;
			_0024self__002415906 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415905, _0024self__002415906);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FriendPointLottery_002415907 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415908;

			internal Exec _0024_0024CUR_EXEC_0024_002415909;

			internal int _0024price_002415910;

			internal int _0024turn_002415911;

			internal Exec _0024_0024s540_0024go_0024849_002415912;

			internal IEnumerator _0024_0024s540_0024tmp_0024850_002415913;

			internal UserData _0024ud_002415914;

			internal int _0024cnt_002415915;

			internal Exec _0024_0024s540_0024call_0024861_002415916;

			internal IEnumerator _0024_0024s540_0024call_0024860_002415917;

			internal object _0024_0024s540_0024call_0024862_002415918;

			internal Exec _0024_0024s540_0024call_0024864_002415919;

			internal IEnumerator _0024_0024s540_0024call_0024863_002415920;

			internal object _0024_0024s540_0024call_0024865_002415921;

			internal Exec _0024_0024s540_0024call_0024867_002415922;

			internal IEnumerator _0024_0024s540_0024call_0024866_002415923;

			internal object _0024_0024s540_0024call_0024868_002415924;

			internal Exec _0024_0024s540_0024call_0024870_002415925;

			internal IEnumerator _0024_0024s540_0024call_0024869_002415926;

			internal object _0024_0024s540_0024call_0024871_002415927;

			internal Exec _0024_0024s540_0024call_0024873_002415928;

			internal IEnumerator _0024_0024s540_0024call_0024872_002415929;

			internal object _0024_0024s540_0024call_0024874_002415930;

			internal int _0024_0024s540_0024loop_0024859_002415931;

			internal Exec _0024_0024s540_0024call_0024876_002415932;

			internal IEnumerator _0024_0024s540_0024call_0024875_002415933;

			internal object _0024_0024s540_0024call_0024877_002415934;

			internal Exec _0024_0024s540_0024go_0024851_002415935;

			internal IEnumerator _0024_0024s540_0024tmp_0024852_002415936;

			internal Exec _0024_0024s540_0024go_0024853_002415937;

			internal IEnumerator _0024_0024s540_0024tmp_0024854_002415938;

			internal Exec _0024_0024s540_0024call_0024879_002415939;

			internal IEnumerator _0024_0024s540_0024call_0024878_002415940;

			internal object _0024_0024s540_0024call_0024880_002415941;

			internal Exec _0024_0024s540_0024go_0024855_002415942;

			internal IEnumerator _0024_0024s540_0024tmp_0024856_002415943;

			internal Exec _0024_0024s540_0024call_0024882_002415944;

			internal IEnumerator _0024_0024s540_0024call_0024881_002415945;

			internal object _0024_0024s540_0024call_0024883_002415946;

			internal Exec _0024_0024s540_0024go_0024857_002415947;

			internal IEnumerator _0024_0024s540_0024tmp_0024858_002415948;

			internal IEnumerator _0024_0024iterator_002413359_002415949;

			internal IEnumerator _0024_0024iterator_002413360_002415950;

			internal IEnumerator _0024_0024iterator_002413361_002415951;

			internal IEnumerator _0024_0024iterator_002413362_002415952;

			internal IEnumerator _0024_0024iterator_002413363_002415953;

			internal IEnumerator _0024_0024iterator_002413364_002415954;

			internal IEnumerator _0024_0024iterator_002413365_002415955;

			internal IEnumerator _0024_0024iterator_002413366_002415956;

			internal bool _0024eventFlag_002415957;

			internal LotterySequence _0024self__002415958;

			public _0024(bool eventFlag, LotterySequence self_)
			{
				_0024eventFlag_002415957 = eventFlag;
				_0024self__002415958 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002415908 = "S540_FriendPointLottery";
					_0024_0024CUR_EXEC_0024_002415909 = _0024self__002415958.lastCreatedExec;
					_0024self__002415958.lastEventFlag = _0024eventFlag_002415957;
					if (_0024self__002415958.curGacha != null)
					{
						_0024self__002415958.ChangeFpBannerTexture(_0024self__002415958.curGacha.Id);
					}
					_0024price_002415910 = 200;
					_0024turn_002415911 = 1;
					_0024self__002415958.curGacha.GetPriceAndTurn(ref _0024price_002415910, ref _0024turn_002415911);
					WebViewBase.Visible(flag: false);
					goto IL_00ed;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002415909.NotExecuting)
					{
						goto IL_00ed;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413359_002415949.MoveNext())
					{
						_0024_0024s540_0024call_0024862_002415918 = _0024_0024iterator_002413359_002415949.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024862_002415918) ? 1 : 0);
						break;
					}
					goto IL_0559;
				case 4:
					if (_0024_0024iterator_002413360_002415950.MoveNext())
					{
						_0024_0024s540_0024call_0024865_002415921 = _0024_0024iterator_002413360_002415950.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024865_002415921) ? 1 : 0);
						break;
					}
					goto IL_0645;
				case 5:
					if (_0024_0024iterator_002413361_002415951.MoveNext())
					{
						_0024_0024s540_0024call_0024868_002415924 = _0024_0024iterator_002413361_002415951.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024868_002415924) ? 1 : 0);
						break;
					}
					goto IL_0716;
				case 6:
					if (_0024_0024iterator_002413362_002415952.MoveNext())
					{
						_0024_0024s540_0024call_0024871_002415927 = _0024_0024iterator_002413362_002415952.Current;
						result = (Yield(6, _0024_0024s540_0024call_0024871_002415927) ? 1 : 0);
						break;
					}
					goto IL_07fc;
				case 7:
					if (_0024_0024iterator_002413363_002415953.MoveNext())
					{
						_0024_0024s540_0024call_0024874_002415930 = _0024_0024iterator_002413363_002415953.Current;
						result = (Yield(7, _0024_0024s540_0024call_0024874_002415930) ? 1 : 0);
						break;
					}
					goto IL_08cd;
				case 8:
					if (_0024_0024iterator_002413364_002415954.MoveNext())
					{
						_0024_0024s540_0024call_0024877_002415934 = _0024_0024iterator_002413364_002415954.Current;
						result = (Yield(8, _0024_0024s540_0024call_0024877_002415934) ? 1 : 0);
						break;
					}
					goto IL_09be;
				case 9:
					if (_0024_0024iterator_002413365_002415955.MoveNext())
					{
						_0024_0024s540_0024call_0024880_002415941 = _0024_0024iterator_002413365_002415955.Current;
						result = (Yield(9, _0024_0024s540_0024call_0024880_002415941) ? 1 : 0);
						break;
					}
					goto IL_0c11;
				case 10:
					if (_0024_0024iterator_002413366_002415956.MoveNext())
					{
						_0024_0024s540_0024call_0024883_002415946 = _0024_0024iterator_002413366_002415956.Current;
						result = (Yield(10, _0024_0024s540_0024call_0024883_002415946) ? 1 : 0);
						break;
					}
					goto IL_0d81;
				case 11:
					if (_0024_0024CUR_EXEC_0024_002415909.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0908;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0d81:
					if (_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:412", "go命令 " + _0024self__002415958.CurrentStateName + "->" + "S540_WebInfo" + "(" + "'FriendPointLottery'" + ")");
						_0024_0024s540_0024go_0024857_002415947 = _0024self__002415958.createExecAsCurrent("S540_WebInfo");
						_0024_0024s540_0024tmp_0024858_002415948 = _0024self__002415958.S540_WebInfo("FriendPointLottery");
						_0024self__002415958.entryCoroutine(_0024_0024s540_0024go_0024857_002415947, _0024_0024s540_0024tmp_0024858_002415948);
						_0024self__002415958.stop(_0024_0024CUR_EXEC_0024_002415909);
					}
					goto case 1;
					IL_00ed:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					WebViewBase.Visible(flag: true);
					if (_0024self__002415958.curGacha == null)
					{
						_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:358", "go命令 " + _0024self__002415958.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024849_002415912 = _0024self__002415958.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024850_002415913 = _0024self__002415958.S540_Home();
						_0024self__002415958.entryCoroutine(_0024_0024s540_0024go_0024849_002415912, _0024_0024s540_0024tmp_0024850_002415913);
						_0024self__002415958.stop(_0024_0024CUR_EXEC_0024_002415909);
						goto case 1;
					}
					_0024ud_002415914 = UserData.Current;
					_0024cnt_002415915 = 0;
					if (!_0024eventFlag_002415957)
					{
						if ((bool)_0024self__002415958.friendPointTitle)
						{
							_0024self__002415958.friendPointTitle.text = _0024self__002415958.curGacha.Name;
						}
						if ((bool)_0024self__002415958.friendPointExplain)
						{
							_0024self__002415958.friendPointExplain.text = _0024self__002415958.curGacha.Description;
						}
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointNumText, _0024ud_002415914.Fp.ToString());
						if (_0024price_002415910 > 0)
						{
							_0024cnt_002415915 = _0024ud_002415914.Fp / _0024price_002415910;
						}
						if (_0024cnt_002415915 >= 10)
						{
							_0024cnt_002415915 = 10;
						}
						_0024self__002415958.przNum = checked(_0024cnt_002415915 * _0024turn_002415911);
						if ((bool)_0024self__002415958.friendPointButtonValid)
						{
							_0024self__002415958.friendPointButtonValid.isValidColor = _0024self__002415958.przNum > 0;
						}
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointCountText, _0024cnt_002415915.ToString());
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointPriceText, _0024price_002415910.ToString());
						_0024self__002415958.PanelActive("FriendPoint", string.Empty);
					}
					else
					{
						if ((bool)_0024self__002415958.friendPointEventTitle)
						{
							_0024self__002415958.friendPointEventTitle.text = _0024self__002415958.curGacha.Name;
						}
						if ((bool)_0024self__002415958.friendPointEventExplain)
						{
							_0024self__002415958.friendPointEventExplain.text = _0024self__002415958.curGacha.Description;
						}
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointEventNumText, _0024ud_002415914.Fp.ToString());
						if (_0024price_002415910 > 0)
						{
							_0024cnt_002415915 = _0024ud_002415914.Fp / _0024price_002415910;
						}
						if (_0024cnt_002415915 >= 10)
						{
							_0024cnt_002415915 = 10;
						}
						_0024self__002415958.przNum = checked(_0024cnt_002415915 * _0024turn_002415911);
						if ((bool)_0024self__002415958.friendPointEventButtonValid)
						{
							_0024self__002415958.friendPointEventButtonValid.isValidColor = _0024self__002415958.przNum > 0;
						}
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointEventCountText, _0024cnt_002415915.ToString());
						_0024self__002415958.SetFormat(_0024self__002415958.friendPointEventPriceText, _0024price_002415910.ToString());
						_0024self__002415958.PanelActive("FriendPointEvent", string.Empty);
					}
					_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:384", "call命令");
					_0024_0024s540_0024call_0024861_002415916 = _0024self__002415958.createExec("S540_PanelIn", _0024_0024CUR_EXEC_0024_002415909);
					_0024_0024s540_0024call_0024860_002415917 = _0024self__002415958.S540_PanelIn();
					if (_0024_0024s540_0024call_0024860_002415917 != null)
					{
						_0024_0024iterator_002413359_002415949 = _0024_0024s540_0024call_0024860_002415917;
						goto case 3;
					}
					goto IL_0559;
					IL_0716:
					if (!_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto case 1;
					}
					goto IL_08e8;
					IL_09be:
					if (!_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto case 1;
					}
					if (btnNo == 0)
					{
						if (_0024self__002415958.przNum > 0)
						{
							if (_0024self__002415958.przNum == 1)
							{
								_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:402", "go命令 " + _0024self__002415958.CurrentStateName + "->" + "S540_LotterySingle" + "(" + string.Empty + ")");
								_0024_0024s540_0024go_0024851_002415935 = _0024self__002415958.createExecAsCurrent("S540_LotterySingle");
								_0024_0024s540_0024tmp_0024852_002415936 = _0024self__002415958.S540_LotterySingle();
								_0024self__002415958.entryCoroutine(_0024_0024s540_0024go_0024851_002415935, _0024_0024s540_0024tmp_0024852_002415936);
								_0024self__002415958.stop(_0024_0024CUR_EXEC_0024_002415909);
							}
							else
							{
								_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:404", "go命令 " + _0024self__002415958.CurrentStateName + "->" + "S540_LotteryMulti" + "(" + string.Empty + ")");
								_0024_0024s540_0024go_0024853_002415937 = _0024self__002415958.createExecAsCurrent("S540_LotteryMulti");
								_0024_0024s540_0024tmp_0024854_002415938 = _0024self__002415958.S540_LotteryMulti();
								_0024self__002415958.entryCoroutine(_0024_0024s540_0024go_0024853_002415937, _0024_0024s540_0024tmp_0024854_002415938);
								_0024self__002415958.stop(_0024_0024CUR_EXEC_0024_002415909);
							}
							goto case 1;
						}
					}
					else
					{
						if (btnNo == 1)
						{
							_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:407", "call命令");
							_0024_0024s540_0024call_0024879_002415939 = _0024self__002415958.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415909);
							_0024_0024s540_0024call_0024878_002415940 = _0024self__002415958.S540_PanelExit();
							if (_0024_0024s540_0024call_0024878_002415940 != null)
							{
								_0024_0024iterator_002413365_002415955 = _0024_0024s540_0024call_0024878_002415940;
								goto case 9;
							}
							goto IL_0c11;
						}
						if (btnNo == 2)
						{
							_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:411", "call命令");
							_0024_0024s540_0024call_0024882_002415944 = _0024self__002415958.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415909);
							_0024_0024s540_0024call_0024881_002415945 = _0024self__002415958.S540_PanelExit();
							if (_0024_0024s540_0024call_0024881_002415945 != null)
							{
								_0024_0024iterator_002413366_002415956 = _0024_0024s540_0024call_0024881_002415945;
								goto case 10;
							}
							goto IL_0d81;
						}
					}
					if (_0024_0024s540_0024loop_0024859_002415931 == Time.frameCount)
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					goto case 11;
					IL_0559:
					if (!_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto case 1;
					}
					if (!_0024eventFlag_002415957)
					{
						if (!(_0024self__002415958.ScreenAspect() <= 1.5f))
						{
							_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:388", "call命令");
							_0024_0024s540_0024call_0024864_002415919 = _0024self__002415958.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415909);
							_0024_0024s540_0024call_0024863_002415920 = _0024self__002415958.S540_Selif(_0024self__002415958.selif_sel_point, -410f, 160f, 10f);
							if (_0024_0024s540_0024call_0024863_002415920 != null)
							{
								_0024_0024iterator_002413360_002415950 = _0024_0024s540_0024call_0024863_002415920;
								goto case 4;
							}
							goto IL_0645;
						}
						_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:390", "call命令");
						_0024_0024s540_0024call_0024867_002415922 = _0024self__002415958.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415909);
						_0024_0024s540_0024call_0024866_002415923 = _0024self__002415958.S540_Selif(_0024self__002415958.selif_sel_point, -390f, 160f, -10f);
						if (_0024_0024s540_0024call_0024866_002415923 != null)
						{
							_0024_0024iterator_002413361_002415951 = _0024_0024s540_0024call_0024866_002415923;
							goto case 5;
						}
						goto IL_0716;
					}
					if (!(_0024self__002415958.ScreenAspect() <= 1.5f))
					{
						_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:393", "call命令");
						_0024_0024s540_0024call_0024870_002415925 = _0024self__002415958.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415909);
						_0024_0024s540_0024call_0024869_002415926 = _0024self__002415958.S540_Selif(_0024self__002415958.selif_sel_event, -410f, 160f, 10f);
						if (_0024_0024s540_0024call_0024869_002415926 != null)
						{
							_0024_0024iterator_002413362_002415952 = _0024_0024s540_0024call_0024869_002415926;
							goto case 6;
						}
						goto IL_07fc;
					}
					_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:395", "call命令");
					_0024_0024s540_0024call_0024873_002415928 = _0024self__002415958.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002415909);
					_0024_0024s540_0024call_0024872_002415929 = _0024self__002415958.S540_Selif(_0024self__002415958.selif_sel_event, -390f, 160f, -10f);
					if (_0024_0024s540_0024call_0024872_002415929 != null)
					{
						_0024_0024iterator_002413363_002415953 = _0024_0024s540_0024call_0024872_002415929;
						goto case 7;
					}
					goto IL_08cd;
					IL_08cd:
					if (_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto IL_08e8;
					}
					goto case 1;
					IL_0908:
					_0024_0024s540_0024loop_0024859_002415931 = Time.frameCount;
					_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:398", "call命令");
					_0024_0024s540_0024call_0024876_002415932 = _0024self__002415958.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002415909);
					_0024_0024s540_0024call_0024875_002415933 = _0024self__002415958.S540_WaitButton("Single", "Back", "Info", string.Empty);
					if (_0024_0024s540_0024call_0024875_002415933 != null)
					{
						_0024_0024iterator_002413364_002415954 = _0024_0024s540_0024call_0024875_002415933;
						goto case 8;
					}
					goto IL_09be;
					IL_0645:
					if (!_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto case 1;
					}
					goto IL_08e8;
					IL_07fc:
					if (!_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						goto case 1;
					}
					goto IL_08e8;
					IL_0c11:
					if (_0024self__002415958.isExecuting(_0024_0024CUR_EXEC_0024_002415909))
					{
						_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:408", "go命令 " + _0024self__002415958.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024855_002415942 = _0024self__002415958.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024856_002415943 = _0024self__002415958.S540_Home();
						_0024self__002415958.entryCoroutine(_0024_0024s540_0024go_0024855_002415942, _0024_0024s540_0024tmp_0024856_002415943);
						_0024self__002415958.stop(_0024_0024CUR_EXEC_0024_002415909);
					}
					goto case 1;
					IL_08e8:
					_0024self__002415958.dtrace(_0024_0024CUR_EXEC_0024_002415909, "LotterySequence.boo:397", "loop命令");
					goto IL_0908;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024eventFlag_002415959;

		internal LotterySequence _0024self__002415960;

		public _0024S540_FriendPointLottery_002415907(bool eventFlag, LotterySequence self_)
		{
			_0024eventFlag_002415959 = eventFlag;
			_0024self__002415960 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024eventFlag_002415959, _0024self__002415960);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WebInfo_002415961 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024902_002415962;

			internal object _0024___item_002415963;

			internal IEnumerator _0024_0024iterator_002413367_002415964;

			internal string _0024back_002415965;

			internal LotterySequence _0024self__002415966;

			public _0024(string back, LotterySequence self_)
			{
				_0024back_002415965 = back;
				_0024self__002415966 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024902_002415962 = _0024self__002415966.S540_WebInfo(_0024back_002415965, null);
					if (_0024_0024s540_0024ycode_0024902_002415962 != null)
					{
						_0024_0024iterator_002413367_002415964 = _0024_0024s540_0024ycode_0024902_002415962;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413367_002415964.MoveNext())
					{
						_0024___item_002415963 = _0024_0024iterator_002413367_002415964.Current;
						result = (Yield(2, _0024___item_002415963) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024back_002415967;

		internal LotterySequence _0024self__002415968;

		public _0024S540_WebInfo_002415961(string back, LotterySequence self_)
		{
			_0024back_002415967 = back;
			_0024self__002415968 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024back_002415967, _0024self__002415968);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WebInfo_002415969 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002415970;

			internal Exec _0024_0024CUR_EXEC_0024_002415971;

			internal Exec _0024_0024s540_0024call_0024894_002415972;

			internal IEnumerator _0024_0024s540_0024call_0024893_002415973;

			internal object _0024_0024s540_0024call_0024895_002415974;

			internal Exec _0024_0024s540_0024call_0024897_002415975;

			internal IEnumerator _0024_0024s540_0024call_0024896_002415976;

			internal object _0024_0024s540_0024call_0024898_002415977;

			internal Exec _0024_0024s540_0024call_0024900_002415978;

			internal IEnumerator _0024_0024s540_0024call_0024899_002415979;

			internal object _0024_0024s540_0024call_0024901_002415980;

			internal Exec _0024_0024s540_0024go_0024885_002415981;

			internal IEnumerator _0024_0024s540_0024tmp_0024886_002415982;

			internal Exec _0024_0024s540_0024go_0024887_002415983;

			internal IEnumerator _0024_0024s540_0024tmp_0024888_002415984;

			internal Exec _0024_0024s540_0024go_0024889_002415985;

			internal IEnumerator _0024_0024s540_0024tmp_0024890_002415986;

			internal Exec _0024_0024s540_0024go_0024891_002415987;

			internal IEnumerator _0024_0024s540_0024tmp_0024892_002415988;

			internal IEnumerator _0024_0024iterator_002413368_002415989;

			internal IEnumerator _0024_0024iterator_002413369_002415990;

			internal IEnumerator _0024_0024iterator_002413370_002415991;

			internal string _0024back_002415992;

			internal LotterySequence _0024self__002415993;

			public _0024(string back, LotterySequence self_)
			{
				_0024back_002415992 = back;
				_0024self__002415993 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002415970 = "S540_WebInfo";
					_0024_0024CUR_EXEC_0024_002415971 = _0024self__002415993.lastCreatedExec;
					_0024self__002415993.PanelActive("Info", "GachaDetail");
					_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:416", "call命令");
					_0024_0024s540_0024call_0024894_002415972 = _0024self__002415993.createExec("S540_PanelIn", _0024_0024CUR_EXEC_0024_002415971);
					_0024_0024s540_0024call_0024893_002415973 = _0024self__002415993.S540_PanelIn();
					if (_0024_0024s540_0024call_0024893_002415973 != null)
					{
						_0024_0024iterator_002413368_002415989 = _0024_0024s540_0024call_0024893_002415973;
						goto case 2;
					}
					goto IL_00e7;
				case 2:
					if (_0024_0024iterator_002413368_002415989.MoveNext())
					{
						_0024_0024s540_0024call_0024895_002415974 = _0024_0024iterator_002413368_002415989.Current;
						result = (Yield(2, _0024_0024s540_0024call_0024895_002415974) ? 1 : 0);
						break;
					}
					goto IL_00e7;
				case 3:
					if (_0024_0024iterator_002413369_002415990.MoveNext())
					{
						_0024_0024s540_0024call_0024898_002415977 = _0024_0024iterator_002413369_002415990.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024898_002415977) ? 1 : 0);
						break;
					}
					goto IL_01ad;
				case 4:
					if (_0024_0024iterator_002413370_002415991.MoveNext())
					{
						_0024_0024s540_0024call_0024901_002415980 = _0024_0024iterator_002413370_002415991.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024901_002415980) ? 1 : 0);
						break;
					}
					goto IL_027f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01ad:
					if (_0024self__002415993.isExecuting(_0024_0024CUR_EXEC_0024_002415971))
					{
						if (btnNo == 0 || btnNo == 1 || btnNo == 2)
						{
							_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:419", "call命令");
							_0024_0024s540_0024call_0024900_002415978 = _0024self__002415993.createExec("S540_PanelExit", _0024_0024CUR_EXEC_0024_002415971);
							_0024_0024s540_0024call_0024899_002415979 = _0024self__002415993.S540_PanelExit();
							if (_0024_0024s540_0024call_0024899_002415979 != null)
							{
								_0024_0024iterator_002413370_002415991 = _0024_0024s540_0024call_0024899_002415979;
								goto case 4;
							}
							goto IL_027f;
						}
						_0024self__002415993.stop(_0024_0024CUR_EXEC_0024_002415971);
					}
					goto case 1;
					IL_00e7:
					if (!_0024self__002415993.isExecuting(_0024_0024CUR_EXEC_0024_002415971))
					{
						goto case 1;
					}
					_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:417", "call命令");
					_0024_0024s540_0024call_0024897_002415975 = _0024self__002415993.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002415971);
					_0024_0024s540_0024call_0024896_002415976 = _0024self__002415993.S540_WaitButton("Back", "Close", "PushBack", string.Empty);
					if (_0024_0024s540_0024call_0024896_002415976 != null)
					{
						_0024_0024iterator_002413369_002415990 = _0024_0024s540_0024call_0024896_002415976;
						goto case 3;
					}
					goto IL_01ad;
					IL_027f:
					if (_0024self__002415993.isExecuting(_0024_0024CUR_EXEC_0024_002415971))
					{
						if (_0024back_002415992 == "FayStoneLottery")
						{
							_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:421", "go命令 " + _0024self__002415993.CurrentStateName + "->" + "S540_FayStoneLottery" + "(" + "lastEventFlag" + ")");
							_0024_0024s540_0024go_0024885_002415981 = _0024self__002415993.createExecAsCurrent("S540_FayStoneLottery");
							_0024_0024s540_0024tmp_0024886_002415982 = _0024self__002415993.S540_FayStoneLottery(_0024self__002415993.lastEventFlag);
							_0024self__002415993.entryCoroutine(_0024_0024s540_0024go_0024885_002415981, _0024_0024s540_0024tmp_0024886_002415982);
							_0024self__002415993.stop(_0024_0024CUR_EXEC_0024_002415971);
						}
						else if (_0024back_002415992 == "RaidPointLottery")
						{
							_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:423", "go命令 " + _0024self__002415993.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "lastEventFlag" + ")");
							_0024_0024s540_0024go_0024887_002415983 = _0024self__002415993.createExecAsCurrent("S540_RaidPointLottery");
							_0024_0024s540_0024tmp_0024888_002415984 = _0024self__002415993.S540_RaidPointLottery(_0024self__002415993.lastEventFlag);
							_0024self__002415993.entryCoroutine(_0024_0024s540_0024go_0024887_002415983, _0024_0024s540_0024tmp_0024888_002415984);
							_0024self__002415993.stop(_0024_0024CUR_EXEC_0024_002415971);
						}
						else if (_0024back_002415992 == "FriendPointLottery")
						{
							_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:425", "go命令 " + _0024self__002415993.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "lastEventFlag" + ")");
							_0024_0024s540_0024go_0024889_002415985 = _0024self__002415993.createExecAsCurrent("S540_FriendPointLottery");
							_0024_0024s540_0024tmp_0024890_002415986 = _0024self__002415993.S540_FriendPointLottery(_0024self__002415993.lastEventFlag);
							_0024self__002415993.entryCoroutine(_0024_0024s540_0024go_0024889_002415985, _0024_0024s540_0024tmp_0024890_002415986);
							_0024self__002415993.stop(_0024_0024CUR_EXEC_0024_002415971);
						}
						else
						{
							_0024self__002415993.dtrace(_0024_0024CUR_EXEC_0024_002415971, "LotterySequence.boo:427", "go命令 " + _0024self__002415993.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024891_002415987 = _0024self__002415993.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024892_002415988 = _0024self__002415993.S540_Home();
							_0024self__002415993.entryCoroutine(_0024_0024s540_0024go_0024891_002415987, _0024_0024s540_0024tmp_0024892_002415988);
							_0024self__002415993.stop(_0024_0024CUR_EXEC_0024_002415971);
						}
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024back_002415994;

		internal LotterySequence _0024self__002415995;

		public _0024S540_WebInfo_002415969(string back, LotterySequence self_)
		{
			_0024back_002415994 = back;
			_0024self__002415995 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024back_002415994, _0024self__002415995);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LotterySingle_002415996 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_0024987_002415997;

			internal object _0024___item_002415998;

			internal IEnumerator _0024_0024iterator_002413371_002415999;

			internal LotterySequence _0024self__002416000;

			public _0024(LotterySequence self_)
			{
				_0024self__002416000 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_0024987_002415997 = _0024self__002416000.S540_LotterySingle(null);
					if (_0024_0024s540_0024ycode_0024987_002415997 != null)
					{
						_0024_0024iterator_002413371_002415999 = _0024_0024s540_0024ycode_0024987_002415997;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413371_002415999.MoveNext())
					{
						_0024___item_002415998 = _0024_0024iterator_002413371_002415999.Current;
						result = (Yield(2, _0024___item_002415998) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416001;

		public _0024S540_LotterySingle_002415996(LotterySequence self_)
		{
			_0024self__002416001 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416001);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LotterySingle_002416002 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416003;

			internal Exec _0024_0024CUR_EXEC_0024_002416004;

			internal Exec _0024_0024s540_0024call_0024919_002416005;

			internal IEnumerator _0024_0024s540_0024call_0024918_002416006;

			internal object _0024_0024s540_0024call_0024920_002416007;

			internal Exec _0024_0024s540_0024go_0024903_002416008;

			internal IEnumerator _0024_0024s540_0024tmp_0024904_002416009;

			internal Exec _0024_0024s540_0024call_0024922_002416010;

			internal IEnumerator _0024_0024s540_0024call_0024921_002416011;

			internal object _0024_0024s540_0024call_0024923_002416012;

			internal Exec _0024_0024s540_0024call_0024925_002416013;

			internal IEnumerator _0024_0024s540_0024call_0024924_002416014;

			internal object _0024_0024s540_0024call_0024926_002416015;

			internal Exec _0024_0024s540_0024call_0024928_002416016;

			internal IEnumerator _0024_0024s540_0024call_0024927_002416017;

			internal object _0024_0024s540_0024call_0024929_002416018;

			internal int _0024_0024s540_0024loop_0024905_002416019;

			internal Exec _0024_0024s540_0024call_0024931_002416020;

			internal IEnumerator _0024_0024s540_0024call_0024930_002416021;

			internal object _0024_0024s540_0024call_0024932_002416022;

			internal Exec _0024_0024s540_0024call_0024934_002416023;

			internal IEnumerator _0024_0024s540_0024call_0024933_002416024;

			internal object _0024_0024s540_0024call_0024935_002416025;

			internal Exec _0024_0024s540_0024call_0024937_002416026;

			internal IEnumerator _0024_0024s540_0024call_0024936_002416027;

			internal object _0024_0024s540_0024call_0024938_002416028;

			internal Exec _0024_0024s540_0024call_0024940_002416029;

			internal IEnumerator _0024_0024s540_0024call_0024939_002416030;

			internal object _0024_0024s540_0024call_0024941_002416031;

			internal Exec _0024_0024s540_0024call_0024943_002416032;

			internal IEnumerator _0024_0024s540_0024call_0024942_002416033;

			internal object _0024_0024s540_0024call_0024944_002416034;

			internal Exec _0024_0024s540_0024call_0024946_002416035;

			internal IEnumerator _0024_0024s540_0024call_0024945_002416036;

			internal object _0024_0024s540_0024call_0024947_002416037;

			internal Exec _0024_0024s540_0024call_0024949_002416038;

			internal IEnumerator _0024_0024s540_0024call_0024948_002416039;

			internal object _0024_0024s540_0024call_0024950_002416040;

			internal Exec _0024_0024s540_0024call_0024952_002416041;

			internal IEnumerator _0024_0024s540_0024call_0024951_002416042;

			internal object _0024_0024s540_0024call_0024953_002416043;

			internal Exec _0024_0024s540_0024call_0024955_002416044;

			internal IEnumerator _0024_0024s540_0024call_0024954_002416045;

			internal object _0024_0024s540_0024call_0024956_002416046;

			internal Exec _0024_0024s540_0024call_0024958_002416047;

			internal IEnumerator _0024_0024s540_0024call_0024957_002416048;

			internal object _0024_0024s540_0024call_0024959_002416049;

			internal Exec _0024_0024s540_0024call_0024961_002416050;

			internal IEnumerator _0024_0024s540_0024call_0024960_002416051;

			internal object _0024_0024s540_0024call_0024962_002416052;

			internal Exec _0024_0024s540_0024call_0024964_002416053;

			internal IEnumerator _0024_0024s540_0024call_0024963_002416054;

			internal object _0024_0024s540_0024call_0024965_002416055;

			internal Exec _0024_0024s540_0024call_0024967_002416056;

			internal IEnumerator _0024_0024s540_0024call_0024966_002416057;

			internal object _0024_0024s540_0024call_0024968_002416058;

			internal Exec _0024_0024s540_0024call_0024970_002416059;

			internal IEnumerator _0024_0024s540_0024call_0024969_002416060;

			internal object _0024_0024s540_0024call_0024971_002416061;

			internal Exec _0024_0024s540_0024call_0024973_002416062;

			internal IEnumerator _0024_0024s540_0024call_0024972_002416063;

			internal object _0024_0024s540_0024call_0024974_002416064;

			internal Exec _0024_0024s540_0024call_0024976_002416065;

			internal IEnumerator _0024_0024s540_0024call_0024975_002416066;

			internal object _0024_0024s540_0024call_0024977_002416067;

			internal Exec _0024_0024s540_0024call_0024979_002416068;

			internal IEnumerator _0024_0024s540_0024call_0024978_002416069;

			internal object _0024_0024s540_0024call_0024980_002416070;

			internal Exec _0024_0024s540_0024go_0024906_002416071;

			internal IEnumerator _0024_0024s540_0024tmp_0024907_002416072;

			internal Exec _0024_0024s540_0024call_0024982_002416073;

			internal IEnumerator _0024_0024s540_0024call_0024981_002416074;

			internal object _0024_0024s540_0024call_0024983_002416075;

			internal Exec _0024_0024s540_0024go_0024908_002416076;

			internal IEnumerator _0024_0024s540_0024tmp_0024909_002416077;

			internal Exec _0024_0024s540_0024go_0024910_002416078;

			internal IEnumerator _0024_0024s540_0024tmp_0024911_002416079;

			internal Exec _0024_0024s540_0024call_0024985_002416080;

			internal IEnumerator _0024_0024s540_0024call_0024984_002416081;

			internal object _0024_0024s540_0024call_0024986_002416082;

			internal Exec _0024_0024s540_0024go_0024912_002416083;

			internal IEnumerator _0024_0024s540_0024tmp_0024913_002416084;

			internal Exec _0024_0024s540_0024go_0024914_002416085;

			internal IEnumerator _0024_0024s540_0024tmp_0024915_002416086;

			internal Exec _0024_0024s540_0024go_0024916_002416087;

			internal IEnumerator _0024_0024s540_0024tmp_0024917_002416088;

			internal IEnumerator _0024_0024iterator_002413372_002416089;

			internal IEnumerator _0024_0024iterator_002413373_002416090;

			internal IEnumerator _0024_0024iterator_002413374_002416091;

			internal IEnumerator _0024_0024iterator_002413375_002416092;

			internal IEnumerator _0024_0024iterator_002413376_002416093;

			internal IEnumerator _0024_0024iterator_002413377_002416094;

			internal IEnumerator _0024_0024iterator_002413378_002416095;

			internal IEnumerator _0024_0024iterator_002413379_002416096;

			internal IEnumerator _0024_0024iterator_002413380_002416097;

			internal IEnumerator _0024_0024iterator_002413381_002416098;

			internal IEnumerator _0024_0024iterator_002413382_002416099;

			internal IEnumerator _0024_0024iterator_002413383_002416100;

			internal IEnumerator _0024_0024iterator_002413384_002416101;

			internal IEnumerator _0024_0024iterator_002413385_002416102;

			internal IEnumerator _0024_0024iterator_002413386_002416103;

			internal IEnumerator _0024_0024iterator_002413387_002416104;

			internal IEnumerator _0024_0024iterator_002413388_002416105;

			internal IEnumerator _0024_0024iterator_002413389_002416106;

			internal IEnumerator _0024_0024iterator_002413390_002416107;

			internal IEnumerator _0024_0024iterator_002413391_002416108;

			internal IEnumerator _0024_0024iterator_002413392_002416109;

			internal IEnumerator _0024_0024iterator_002413393_002416110;

			internal IEnumerator _0024_0024iterator_002413394_002416111;

			internal LotterySequence _0024self__002416112;

			public _0024(LotterySequence self_)
			{
				_0024self__002416112 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416003 = "S540_LotterySingle";
					_0024_0024CUR_EXEC_0024_002416004 = _0024self__002416112.lastCreatedExec;
					BattleHUDShortcut.Hide();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:437", "call命令");
					_0024_0024s540_0024call_0024919_002416005 = _0024self__002416112.createExec("S540_HideWebView", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024918_002416006 = _0024self__002416112.S540_HideWebView();
					if (_0024_0024s540_0024call_0024918_002416006 != null)
					{
						_0024_0024iterator_002413372_002416089 = _0024_0024s540_0024call_0024918_002416006;
						goto case 2;
					}
					goto IL_012f;
				case 2:
					if (_0024_0024iterator_002413372_002416089.MoveNext())
					{
						_0024_0024s540_0024call_0024920_002416007 = _0024_0024iterator_002413372_002416089.Current;
						result = (Yield(2, _0024_0024s540_0024call_0024920_002416007) ? 1 : 0);
						break;
					}
					goto IL_012f;
				case 3:
					if (_0024_0024iterator_002413373_002416090.MoveNext())
					{
						_0024_0024s540_0024call_0024923_002416012 = _0024_0024iterator_002413373_002416090.Current;
						result = (Yield(3, _0024_0024s540_0024call_0024923_002416012) ? 1 : 0);
						break;
					}
					goto IL_035c;
				case 4:
					if (_0024_0024iterator_002413374_002416091.MoveNext())
					{
						_0024_0024s540_0024call_0024926_002416015 = _0024_0024iterator_002413374_002416091.Current;
						result = (Yield(4, _0024_0024s540_0024call_0024926_002416015) ? 1 : 0);
						break;
					}
					goto IL_040e;
				case 5:
					if (_0024_0024iterator_002413375_002416092.MoveNext())
					{
						_0024_0024s540_0024call_0024929_002416018 = _0024_0024iterator_002413375_002416092.Current;
						result = (Yield(5, _0024_0024s540_0024call_0024929_002416018) ? 1 : 0);
						break;
					}
					goto IL_050c;
				case 6:
					if (_0024_0024CUR_EXEC_0024_002416004.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0557;
				case 7:
					if (_0024_0024iterator_002413376_002416093.MoveNext())
					{
						_0024_0024s540_0024call_0024932_002416022 = _0024_0024iterator_002413376_002416093.Current;
						result = (Yield(7, _0024_0024s540_0024call_0024932_002416022) ? 1 : 0);
						break;
					}
					goto IL_0649;
				case 8:
					if (!_0024_0024CUR_EXEC_0024_002416004.NotExecuting)
					{
						goto IL_068a;
					}
					goto case 1;
				case 9:
					if (_0024_0024iterator_002413377_002416094.MoveNext())
					{
						_0024_0024s540_0024call_0024935_002416025 = _0024_0024iterator_002413377_002416094.Current;
						result = (Yield(9, _0024_0024s540_0024call_0024935_002416025) ? 1 : 0);
						break;
					}
					goto IL_0777;
				case 10:
					if (_0024_0024iterator_002413378_002416095.MoveNext())
					{
						_0024_0024s540_0024call_0024938_002416028 = _0024_0024iterator_002413378_002416095.Current;
						result = (Yield(10, _0024_0024s540_0024call_0024938_002416028) ? 1 : 0);
						break;
					}
					goto IL_0849;
				case 11:
					if (_0024_0024iterator_002413379_002416096.MoveNext())
					{
						_0024_0024s540_0024call_0024941_002416031 = _0024_0024iterator_002413379_002416096.Current;
						result = (Yield(11, _0024_0024s540_0024call_0024941_002416031) ? 1 : 0);
						break;
					}
					goto IL_0907;
				case 12:
					if (_0024_0024iterator_002413380_002416097.MoveNext())
					{
						_0024_0024s540_0024call_0024944_002416034 = _0024_0024iterator_002413380_002416097.Current;
						result = (Yield(12, _0024_0024s540_0024call_0024944_002416034) ? 1 : 0);
						break;
					}
					goto IL_09d5;
				case 13:
					if (_0024_0024iterator_002413381_002416098.MoveNext())
					{
						_0024_0024s540_0024call_0024947_002416037 = _0024_0024iterator_002413381_002416098.Current;
						result = (Yield(13, _0024_0024s540_0024call_0024947_002416037) ? 1 : 0);
						break;
					}
					goto IL_0aa9;
				case 14:
					if (_0024_0024iterator_002413382_002416099.MoveNext())
					{
						_0024_0024s540_0024call_0024950_002416040 = _0024_0024iterator_002413382_002416099.Current;
						result = (Yield(14, _0024_0024s540_0024call_0024950_002416040) ? 1 : 0);
						break;
					}
					goto IL_0b66;
				case 15:
					if (_0024_0024iterator_002413383_002416100.MoveNext())
					{
						_0024_0024s540_0024call_0024953_002416043 = _0024_0024iterator_002413383_002416100.Current;
						result = (Yield(15, _0024_0024s540_0024call_0024953_002416043) ? 1 : 0);
						break;
					}
					goto IL_0c2a;
				case 16:
					if (_0024_0024iterator_002413384_002416101.MoveNext())
					{
						_0024_0024s540_0024call_0024956_002416046 = _0024_0024iterator_002413384_002416101.Current;
						result = (Yield(16, _0024_0024s540_0024call_0024956_002416046) ? 1 : 0);
						break;
					}
					goto IL_0d03;
				case 17:
					if (_0024_0024iterator_002413385_002416102.MoveNext())
					{
						_0024_0024s540_0024call_0024959_002416049 = _0024_0024iterator_002413385_002416102.Current;
						result = (Yield(17, _0024_0024s540_0024call_0024959_002416049) ? 1 : 0);
						break;
					}
					goto IL_0dc6;
				case 18:
					if (_0024_0024iterator_002413386_002416103.MoveNext())
					{
						_0024_0024s540_0024call_0024962_002416052 = _0024_0024iterator_002413386_002416103.Current;
						result = (Yield(18, _0024_0024s540_0024call_0024962_002416052) ? 1 : 0);
						break;
					}
					goto IL_0ec5;
				case 19:
					if (_0024_0024iterator_002413387_002416104.MoveNext())
					{
						_0024_0024s540_0024call_0024965_002416055 = _0024_0024iterator_002413387_002416104.Current;
						result = (Yield(19, _0024_0024s540_0024call_0024965_002416055) ? 1 : 0);
						break;
					}
					goto IL_0fa2;
				case 20:
					if (_0024_0024iterator_002413388_002416105.MoveNext())
					{
						_0024_0024s540_0024call_0024968_002416058 = _0024_0024iterator_002413388_002416105.Current;
						result = (Yield(20, _0024_0024s540_0024call_0024968_002416058) ? 1 : 0);
						break;
					}
					goto IL_1065;
				case 21:
					if (_0024_0024iterator_002413389_002416106.MoveNext())
					{
						_0024_0024s540_0024call_0024971_002416061 = _0024_0024iterator_002413389_002416106.Current;
						result = (Yield(21, _0024_0024s540_0024call_0024971_002416061) ? 1 : 0);
						break;
					}
					goto IL_1137;
				case 22:
					if (_0024_0024iterator_002413390_002416107.MoveNext())
					{
						_0024_0024s540_0024call_0024974_002416064 = _0024_0024iterator_002413390_002416107.Current;
						result = (Yield(22, _0024_0024s540_0024call_0024974_002416064) ? 1 : 0);
						break;
					}
					goto IL_11f5;
				case 23:
					if (_0024_0024iterator_002413391_002416108.MoveNext())
					{
						_0024_0024s540_0024call_0024977_002416067 = _0024_0024iterator_002413391_002416108.Current;
						result = (Yield(23, _0024_0024s540_0024call_0024977_002416067) ? 1 : 0);
						break;
					}
					goto IL_12d9;
				case 24:
					if (_0024_0024iterator_002413392_002416109.MoveNext())
					{
						_0024_0024s540_0024call_0024980_002416070 = _0024_0024iterator_002413392_002416109.Current;
						result = (Yield(24, _0024_0024s540_0024call_0024980_002416070) ? 1 : 0);
						break;
					}
					goto IL_13dd;
				case 25:
					if (_0024_0024iterator_002413393_002416110.MoveNext())
					{
						_0024_0024s540_0024call_0024983_002416075 = _0024_0024iterator_002413393_002416110.Current;
						result = (Yield(25, _0024_0024s540_0024call_0024983_002416075) ? 1 : 0);
						break;
					}
					goto IL_1594;
				case 26:
					if (_0024_0024iterator_002413394_002416111.MoveNext())
					{
						_0024_0024s540_0024call_0024986_002416082 = _0024_0024iterator_002413394_002416111.Current;
						result = (Yield(26, _0024_0024s540_0024call_0024986_002416082) ? 1 : 0);
						break;
					}
					goto IL_17e6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0907:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.CamDraw();
					_0024self__002416112.NikiHand();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:470", "call命令");
					_0024_0024s540_0024call_0024943_002416032 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024942_002416033 = _0024self__002416112.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_0024942_002416033 != null)
					{
						_0024_0024iterator_002413380_002416097 = _0024_0024s540_0024call_0024942_002416033;
						goto case 12;
					}
					goto IL_09d5;
					IL_012f:
					if (_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						if (_0024self__002416112.testMode || (_0024self__002416112.curGacha != null && _0024self__002416112.curGacha.MGachaId != null))
						{
							_0024self__002416112.przNum = 1;
							if (_0024self__002416112.testMode)
							{
								_0024self__002416112.przNum = _0024self__002416112.testPrzNum;
							}
							if (!_0024self__002416112.testMode)
							{
								_0024self__002416112.SendLottery(_0024self__002416112.curGacha.MGachaId.Id, _0024self__002416112.przNum);
							}
							_0024self__002416112.Black();
							_0024self__002416112.NikiSeek();
							_0024self__002416112.CamSeek();
							_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:448", "call命令");
							_0024_0024s540_0024call_0024922_002416010 = _0024self__002416112.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416004);
							_0024_0024s540_0024call_0024921_002416011 = _0024self__002416112.S540_SelifHide();
							if (_0024_0024s540_0024call_0024921_002416011 != null)
							{
								_0024_0024iterator_002413373_002416090 = _0024_0024s540_0024call_0024921_002416011;
								goto case 3;
							}
							goto IL_035c;
						}
						_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:440", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_0024903_002416008 = _0024self__002416112.createExecAsCurrent("S540_Home");
						_0024_0024s540_0024tmp_0024904_002416009 = _0024self__002416112.S540_Home();
						_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024903_002416008, _0024_0024s540_0024tmp_0024904_002416009);
						_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
					}
					goto case 1;
					IL_11f5:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.HanabiOff();
					_0024self__002416112.PrizeHide();
					_0024self__002416112.HideDetail();
					_0024self__002416112.CamDraw_e();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:505", "call命令");
					_0024_0024s540_0024call_0024976_002416065 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024975_002416066 = _0024self__002416112.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_0024975_002416066 != null)
					{
						_0024_0024iterator_002413391_002416108 = _0024_0024s540_0024call_0024975_002416066;
						goto case 23;
					}
					goto IL_12d9;
					IL_09d5:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.SkipDisplay();
					if (_0024self__002416112.rare <= 4)
					{
						_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:473", "call命令");
						_0024_0024s540_0024call_0024946_002416035 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
						_0024_0024s540_0024call_0024945_002416036 = _0024self__002416112.S540_WaitSec(0.3f);
						if (_0024_0024s540_0024call_0024945_002416036 != null)
						{
							_0024_0024iterator_002413381_002416098 = _0024_0024s540_0024call_0024945_002416036;
							goto case 13;
						}
						goto IL_0aa9;
					}
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:475", "call命令");
					_0024_0024s540_0024call_0024949_002416038 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024948_002416039 = _0024self__002416112.S540_WaitSec(0.42f);
					if (_0024_0024s540_0024call_0024948_002416039 != null)
					{
						_0024_0024iterator_002413382_002416099 = _0024_0024s540_0024call_0024948_002416039;
						goto case 14;
					}
					goto IL_0b66;
					IL_1594:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					goto IL_1a51;
					IL_0ec5:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					goto IL_0fbd;
					IL_0fa2:
					if (_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto IL_0fbd;
					}
					goto case 1;
					IL_0aa9:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					goto IL_0c45;
					IL_035c:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:449", "call命令");
					_0024_0024s540_0024call_0024925_002416013 = _0024self__002416112.createExec("S540_TitleExit", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024924_002416014 = _0024self__002416112.S540_TitleExit();
					if (_0024_0024s540_0024call_0024924_002416014 != null)
					{
						_0024_0024iterator_002413374_002416091 = _0024_0024s540_0024call_0024924_002416014;
						goto case 4;
					}
					goto IL_040e;
					IL_13dd:
					if (_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						_0024self__002416112.NikiIdle();
						_0024self__002416112.LastPanelActive();
						BattleHUDShortcut.Show();
						if (_0024self__002416112.testMode || _0024self__002416112.curGacha.SaleGachaTypeIs != EnumStepGachaTypes.NO_STEP)
						{
							_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:517", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024906_002416071 = _0024self__002416112.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024907_002416072 = _0024self__002416112.S540_Home();
							_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024906_002416071, _0024_0024s540_0024tmp_0024907_002416072);
							_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
						}
						else
						{
							if (_0024self__002416112.gachaMode == 0)
							{
								_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:519", "call命令");
								_0024_0024s540_0024call_0024982_002416073 = _0024self__002416112.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002416004);
								_0024_0024s540_0024call_0024981_002416074 = _0024self__002416112.S540_GoStoneGacha(eventFlag: false);
								if (_0024_0024s540_0024call_0024981_002416074 != null)
								{
									_0024_0024iterator_002413393_002416110 = _0024_0024s540_0024call_0024981_002416074;
									goto case 25;
								}
								goto IL_1594;
							}
							if (_0024self__002416112.gachaMode == 1)
							{
								_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:521", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "false" + ")");
								_0024_0024s540_0024go_0024908_002416076 = _0024self__002416112.createExecAsCurrent("S540_RaidPointLottery");
								_0024_0024s540_0024tmp_0024909_002416077 = _0024self__002416112.S540_RaidPointLottery(eventFlag: false);
								_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024908_002416076, _0024_0024s540_0024tmp_0024909_002416077);
								_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
							}
							else if (_0024self__002416112.gachaMode == 2)
							{
								_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:523", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "false" + ")");
								_0024_0024s540_0024go_0024910_002416078 = _0024self__002416112.createExecAsCurrent("S540_FriendPointLottery");
								_0024_0024s540_0024tmp_0024911_002416079 = _0024self__002416112.S540_FriendPointLottery(eventFlag: false);
								_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024910_002416078, _0024_0024s540_0024tmp_0024911_002416079);
								_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
							}
							else
							{
								if (_0024self__002416112.gachaMode == 3)
								{
									_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:525", "call命令");
									_0024_0024s540_0024call_0024985_002416080 = _0024self__002416112.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002416004);
									_0024_0024s540_0024call_0024984_002416081 = _0024self__002416112.S540_GoStoneGacha(eventFlag: true);
									if (_0024_0024s540_0024call_0024984_002416081 != null)
									{
										_0024_0024iterator_002413394_002416111 = _0024_0024s540_0024call_0024984_002416081;
										goto case 26;
									}
									goto IL_17e6;
								}
								if (_0024self__002416112.gachaMode == 4)
								{
									_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:527", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "true" + ")");
									_0024_0024s540_0024go_0024912_002416083 = _0024self__002416112.createExecAsCurrent("S540_RaidPointLottery");
									_0024_0024s540_0024tmp_0024913_002416084 = _0024self__002416112.S540_RaidPointLottery(eventFlag: true);
									_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024912_002416083, _0024_0024s540_0024tmp_0024913_002416084);
									_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
								}
								else if (_0024self__002416112.gachaMode == 5)
								{
									_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:529", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "true" + ")");
									_0024_0024s540_0024go_0024914_002416085 = _0024self__002416112.createExecAsCurrent("S540_FriendPointLottery");
									_0024_0024s540_0024tmp_0024915_002416086 = _0024self__002416112.S540_FriendPointLottery(eventFlag: true);
									_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024914_002416085, _0024_0024s540_0024tmp_0024915_002416086);
									_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
								}
								else
								{
									if (_0024self__002416112.gachaMode != 6)
									{
										goto IL_1a51;
									}
									_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:531", "go命令 " + _0024self__002416112.CurrentStateName + "->" + "S540_End" + "(" + string.Empty + ")");
									_0024_0024s540_0024go_0024916_002416087 = _0024self__002416112.createExecAsCurrent("S540_End");
									_0024_0024s540_0024tmp_0024917_002416088 = _0024self__002416112.S540_End();
									_0024self__002416112.entryCoroutine(_0024_0024s540_0024go_0024916_002416087, _0024_0024s540_0024tmp_0024917_002416088);
									_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
								}
							}
						}
					}
					goto case 1;
					IL_040e:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					if (_0024self__002416112.curGacha != null)
					{
						_0024self__002416112.ChangeBagTexture(_0024self__002416112.curGacha.Id);
					}
					_0024self__002416112.rollSeId = _0024self__002416112.PlayJingle("Card_Get_Roll", resumeBgm: true);
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:452", "call命令");
					_0024_0024s540_0024call_0024928_002416016 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024927_002416017 = _0024self__002416112.S540_WaitSec(0.2f);
					if (_0024_0024s540_0024call_0024927_002416017 != null)
					{
						_0024_0024iterator_002413375_002416092 = _0024_0024s540_0024call_0024927_002416017;
						goto case 5;
					}
					goto IL_050c;
					IL_0fbd:
					_0024self__002416112.BlackHalf();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:496", "call命令");
					_0024_0024s540_0024call_0024967_002416056 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024966_002416057 = _0024self__002416112.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_0024966_002416057 != null)
					{
						_0024_0024iterator_002413388_002416105 = _0024_0024s540_0024call_0024966_002416057;
						goto case 20;
					}
					goto IL_1065;
					IL_1a51:
					_0024self__002416112.stop(_0024_0024CUR_EXEC_0024_002416004);
					goto case 1;
					IL_0b66:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					GameSoundManager.PlaySe("se_system_lottery_prizm", 0);
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:477", "call命令");
					_0024_0024s540_0024call_0024952_002416041 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024951_002416042 = _0024self__002416112.S540_WaitSec(1.08f);
					if (_0024_0024s540_0024call_0024951_002416042 != null)
					{
						_0024_0024iterator_002413383_002416100 = _0024_0024s540_0024call_0024951_002416042;
						goto case 15;
					}
					goto IL_0c2a;
					IL_050c:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					if (!_0024self__002416112.testMode)
					{
						_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:454", "loop命令");
						goto IL_0557;
					}
					goto IL_05ad;
					IL_12d9:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.SkipHide();
					if (_0024self__002416112.curGacha != null)
					{
						_0024self__002416112.RestoreBagTexture(_0024self__002416112.curGacha.Id);
						_0024self__002416112.RestoreFpBannerTexture(_0024self__002416112.curGacha.Id);
					}
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:511", "call命令");
					_0024_0024s540_0024call_0024979_002416068 = _0024self__002416112.createExec("S540_BoxCheck", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024978_002416069 = _0024self__002416112.S540_BoxCheck();
					if (_0024_0024s540_0024call_0024978_002416069 != null)
					{
						_0024_0024iterator_002413392_002416109 = _0024_0024s540_0024call_0024978_002416069;
						goto case 24;
					}
					goto IL_13dd;
					IL_0c2a:
					if (_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto IL_0c45;
					}
					goto case 1;
					IL_0557:
					_0024_0024s540_0024loop_0024905_002416019 = Time.frameCount;
					if (_0024self__002416112.CheckLotteryResult())
					{
						goto IL_05ad;
					}
					if (_0024_0024s540_0024loop_0024905_002416019 == Time.frameCount)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto case 6;
					IL_0c45:
					if (_0024self__002416112.skip)
					{
						_0024self__002416112.NikiHandSkip();
					}
					_0024self__002416112.SkipHide();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:481", "call命令");
					_0024_0024s540_0024call_0024955_002416044 = _0024self__002416112.createExec("S540_Prize", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024954_002416045 = _0024self__002416112.S540_Prize();
					if (_0024_0024s540_0024call_0024954_002416045 != null)
					{
						_0024_0024iterator_002413384_002416101 = _0024_0024s540_0024call_0024954_002416045;
						goto case 16;
					}
					goto IL_0d03;
					IL_05ad:
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:456", "call命令");
					_0024_0024s540_0024call_0024931_002416020 = _0024self__002416112.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024930_002416021 = _0024self__002416112.S540_WaitSec(0.8f);
					if (_0024_0024s540_0024call_0024930_002416021 != null)
					{
						_0024_0024iterator_002413376_002416093 = _0024_0024s540_0024call_0024930_002416021;
						goto case 7;
					}
					goto IL_0649;
					IL_1065:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.SkipDisplay();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:498", "call命令");
					_0024_0024s540_0024call_0024970_002416059 = _0024self__002416112.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024969_002416060 = _0024self__002416112.S540_WaitButton("Skip", "Back", string.Empty, string.Empty);
					if (_0024_0024s540_0024call_0024969_002416060 != null)
					{
						_0024_0024iterator_002413389_002416106 = _0024_0024s540_0024call_0024969_002416060;
						goto case 21;
					}
					goto IL_1137;
					IL_17e6:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					goto IL_1a51;
					IL_0649:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					goto IL_068a;
					IL_068a:
					if (_0024self__002416112.hokan)
					{
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					_0024self__002416112.PanelActive(string.Empty, string.Empty);
					_0024self__002416112.RareUpdate();
					_0024self__002416112.NikiSeekLight();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:463", "call命令");
					_0024_0024s540_0024call_0024934_002416023 = _0024self__002416112.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024933_002416024 = _0024self__002416112.S540_Selif(_0024self__002416112.selif_wait_tap, -230f, 180f, 30f);
					if (_0024_0024s540_0024call_0024933_002416024 != null)
					{
						_0024_0024iterator_002413377_002416094 = _0024_0024s540_0024call_0024933_002416024;
						goto case 9;
					}
					goto IL_0777;
					IL_0d03:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					_0024self__002416112.SkipDisplay();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:484", "call命令");
					_0024_0024s540_0024call_0024958_002416047 = _0024self__002416112.createExec("S540_NewItemPrizeDemo", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024957_002416048 = _0024self__002416112.S540_NewItemPrizeDemo();
					if (_0024_0024s540_0024call_0024957_002416048 != null)
					{
						_0024_0024iterator_002413385_002416102 = _0024_0024s540_0024call_0024957_002416048;
						goto case 17;
					}
					goto IL_0dc6;
					IL_0777:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.TapDisplay();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:465", "call命令");
					_0024_0024s540_0024call_0024937_002416026 = _0024self__002416112.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024936_002416027 = _0024self__002416112.S540_WaitButton("Tap", string.Empty, string.Empty, string.Empty);
					if (_0024_0024s540_0024call_0024936_002416027 != null)
					{
						_0024_0024iterator_002413378_002416095 = _0024_0024s540_0024call_0024936_002416027;
						goto case 10;
					}
					goto IL_0849;
					IL_1137:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.SkipDisplay();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:500", "call命令");
					_0024_0024s540_0024call_0024973_002416062 = _0024self__002416112.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024972_002416063 = _0024self__002416112.S540_SelifHide();
					if (_0024_0024s540_0024call_0024972_002416063 != null)
					{
						_0024_0024iterator_002413390_002416107 = _0024_0024s540_0024call_0024972_002416063;
						goto case 22;
					}
					goto IL_11f5;
					IL_0849:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.TapHide();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:467", "call命令");
					_0024_0024s540_0024call_0024940_002416029 = _0024self__002416112.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024939_002416030 = _0024self__002416112.S540_SelifHide();
					if (_0024_0024s540_0024call_0024939_002416030 != null)
					{
						_0024_0024iterator_002413379_002416096 = _0024_0024s540_0024call_0024939_002416030;
						goto case 11;
					}
					goto IL_0907;
					IL_0dc6:
					if (!_0024self__002416112.isExecuting(_0024_0024CUR_EXEC_0024_002416004))
					{
						goto case 1;
					}
					_0024self__002416112.SkipHide();
					if (_0024self__002416112.rare >= 5)
					{
						_0024self__002416112.NikiLuck();
						_0024self__002416112.Hanabi();
						_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:490", "call命令");
						_0024_0024s540_0024call_0024961_002416050 = _0024self__002416112.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416004);
						_0024_0024s540_0024call_0024960_002416051 = _0024self__002416112.S540_Selif(_0024self__002416112.selif_draw_rare, 350f, 240f, -10f);
						if (_0024_0024s540_0024call_0024960_002416051 != null)
						{
							_0024_0024iterator_002413386_002416103 = _0024_0024s540_0024call_0024960_002416051;
							goto case 18;
						}
						goto IL_0ec5;
					}
					_0024self__002416112.NikiWin();
					_0024self__002416112.dtrace(_0024_0024CUR_EXEC_0024_002416004, "LotterySequence.boo:493", "call命令");
					_0024_0024s540_0024call_0024964_002416053 = _0024self__002416112.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416004);
					_0024_0024s540_0024call_0024963_002416054 = _0024self__002416112.S540_Selif(_0024self__002416112.selif_draw_blank, 350f, 240f, -10f);
					if (_0024_0024s540_0024call_0024963_002416054 != null)
					{
						_0024_0024iterator_002413387_002416104 = _0024_0024s540_0024call_0024963_002416054;
						goto case 19;
					}
					goto IL_0fa2;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416113;

		public _0024S540_LotterySingle_002416002(LotterySequence self_)
		{
			_0024self__002416113 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416113);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LotteryMulti_002416114 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241074_002416115;

			internal object _0024___item_002416116;

			internal IEnumerator _0024_0024iterator_002413395_002416117;

			internal LotterySequence _0024self__002416118;

			public _0024(LotterySequence self_)
			{
				_0024self__002416118 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241074_002416115 = _0024self__002416118.S540_LotteryMulti(null);
					if (_0024_0024s540_0024ycode_00241074_002416115 != null)
					{
						_0024_0024iterator_002413395_002416117 = _0024_0024s540_0024ycode_00241074_002416115;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413395_002416117.MoveNext())
					{
						_0024___item_002416116 = _0024_0024iterator_002413395_002416117.Current;
						result = (Yield(2, _0024___item_002416116) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416119;

		public _0024S540_LotteryMulti_002416114(LotterySequence self_)
		{
			_0024self__002416119 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416119);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LotteryMulti_002416120 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416121;

			internal Exec _0024_0024CUR_EXEC_0024_002416122;

			internal Exec _0024_0024s540_0024call_00241006_002416123;

			internal IEnumerator _0024_0024s540_0024call_00241005_002416124;

			internal object _0024_0024s540_0024call_00241007_002416125;

			internal Exec _0024_0024s540_0024go_0024988_002416126;

			internal IEnumerator _0024_0024s540_0024tmp_0024989_002416127;

			internal Exec _0024_0024s540_0024go_0024990_002416128;

			internal IEnumerator _0024_0024s540_0024tmp_0024991_002416129;

			internal Exec _0024_0024s540_0024call_00241009_002416130;

			internal IEnumerator _0024_0024s540_0024call_00241008_002416131;

			internal object _0024_0024s540_0024call_00241010_002416132;

			internal Exec _0024_0024s540_0024call_00241012_002416133;

			internal IEnumerator _0024_0024s540_0024call_00241011_002416134;

			internal object _0024_0024s540_0024call_00241013_002416135;

			internal Exec _0024_0024s540_0024call_00241015_002416136;

			internal IEnumerator _0024_0024s540_0024call_00241014_002416137;

			internal object _0024_0024s540_0024call_00241016_002416138;

			internal int _0024_0024s540_0024loop_0024992_002416139;

			internal Exec _0024_0024s540_0024call_00241018_002416140;

			internal IEnumerator _0024_0024s540_0024call_00241017_002416141;

			internal object _0024_0024s540_0024call_00241019_002416142;

			internal Exec _0024_0024s540_0024call_00241021_002416143;

			internal IEnumerator _0024_0024s540_0024call_00241020_002416144;

			internal object _0024_0024s540_0024call_00241022_002416145;

			internal Exec _0024_0024s540_0024call_00241024_002416146;

			internal IEnumerator _0024_0024s540_0024call_00241023_002416147;

			internal object _0024_0024s540_0024call_00241025_002416148;

			internal Exec _0024_0024s540_0024call_00241027_002416149;

			internal IEnumerator _0024_0024s540_0024call_00241026_002416150;

			internal object _0024_0024s540_0024call_00241028_002416151;

			internal Exec _0024_0024s540_0024call_00241030_002416152;

			internal IEnumerator _0024_0024s540_0024call_00241029_002416153;

			internal object _0024_0024s540_0024call_00241031_002416154;

			internal Exec _0024_0024s540_0024call_00241033_002416155;

			internal IEnumerator _0024_0024s540_0024call_00241032_002416156;

			internal object _0024_0024s540_0024call_00241034_002416157;

			internal Exec _0024_0024s540_0024call_00241036_002416158;

			internal IEnumerator _0024_0024s540_0024call_00241035_002416159;

			internal object _0024_0024s540_0024call_00241037_002416160;

			internal Exec _0024_0024s540_0024call_00241039_002416161;

			internal IEnumerator _0024_0024s540_0024call_00241038_002416162;

			internal object _0024_0024s540_0024call_00241040_002416163;

			internal Exec _0024_0024s540_0024call_00241042_002416164;

			internal IEnumerator _0024_0024s540_0024call_00241041_002416165;

			internal object _0024_0024s540_0024call_00241043_002416166;

			internal Exec _0024_0024s540_0024call_00241045_002416167;

			internal IEnumerator _0024_0024s540_0024call_00241044_002416168;

			internal object _0024_0024s540_0024call_00241046_002416169;

			internal Exec _0024_0024s540_0024call_00241048_002416170;

			internal IEnumerator _0024_0024s540_0024call_00241047_002416171;

			internal object _0024_0024s540_0024call_00241049_002416172;

			internal Exec _0024_0024s540_0024call_00241051_002416173;

			internal IEnumerator _0024_0024s540_0024call_00241050_002416174;

			internal object _0024_0024s540_0024call_00241052_002416175;

			internal Exec _0024_0024s540_0024call_00241054_002416176;

			internal IEnumerator _0024_0024s540_0024call_00241053_002416177;

			internal object _0024_0024s540_0024call_00241055_002416178;

			internal Exec _0024_0024s540_0024call_00241057_002416179;

			internal IEnumerator _0024_0024s540_0024call_00241056_002416180;

			internal object _0024_0024s540_0024call_00241058_002416181;

			internal Exec _0024_0024s540_0024call_00241060_002416182;

			internal IEnumerator _0024_0024s540_0024call_00241059_002416183;

			internal object _0024_0024s540_0024call_00241061_002416184;

			internal Exec _0024_0024s540_0024call_00241063_002416185;

			internal IEnumerator _0024_0024s540_0024call_00241062_002416186;

			internal object _0024_0024s540_0024call_00241064_002416187;

			internal Exec _0024_0024s540_0024call_00241066_002416188;

			internal IEnumerator _0024_0024s540_0024call_00241065_002416189;

			internal object _0024_0024s540_0024call_00241067_002416190;

			internal Exec _0024_0024s540_0024go_0024993_002416191;

			internal IEnumerator _0024_0024s540_0024tmp_0024994_002416192;

			internal Exec _0024_0024s540_0024call_00241069_002416193;

			internal IEnumerator _0024_0024s540_0024call_00241068_002416194;

			internal object _0024_0024s540_0024call_00241070_002416195;

			internal Exec _0024_0024s540_0024go_0024995_002416196;

			internal IEnumerator _0024_0024s540_0024tmp_0024996_002416197;

			internal Exec _0024_0024s540_0024go_0024997_002416198;

			internal IEnumerator _0024_0024s540_0024tmp_0024998_002416199;

			internal Exec _0024_0024s540_0024call_00241072_002416200;

			internal IEnumerator _0024_0024s540_0024call_00241071_002416201;

			internal object _0024_0024s540_0024call_00241073_002416202;

			internal Exec _0024_0024s540_0024go_0024999_002416203;

			internal IEnumerator _0024_0024s540_0024tmp_00241000_002416204;

			internal Exec _0024_0024s540_0024go_00241001_002416205;

			internal IEnumerator _0024_0024s540_0024tmp_00241002_002416206;

			internal Exec _0024_0024s540_0024go_00241003_002416207;

			internal IEnumerator _0024_0024s540_0024tmp_00241004_002416208;

			internal IEnumerator _0024_0024iterator_002413396_002416209;

			internal IEnumerator _0024_0024iterator_002413397_002416210;

			internal IEnumerator _0024_0024iterator_002413398_002416211;

			internal IEnumerator _0024_0024iterator_002413399_002416212;

			internal IEnumerator _0024_0024iterator_002413400_002416213;

			internal IEnumerator _0024_0024iterator_002413401_002416214;

			internal IEnumerator _0024_0024iterator_002413402_002416215;

			internal IEnumerator _0024_0024iterator_002413403_002416216;

			internal IEnumerator _0024_0024iterator_002413404_002416217;

			internal IEnumerator _0024_0024iterator_002413405_002416218;

			internal IEnumerator _0024_0024iterator_002413406_002416219;

			internal IEnumerator _0024_0024iterator_002413407_002416220;

			internal IEnumerator _0024_0024iterator_002413408_002416221;

			internal IEnumerator _0024_0024iterator_002413409_002416222;

			internal IEnumerator _0024_0024iterator_002413410_002416223;

			internal IEnumerator _0024_0024iterator_002413411_002416224;

			internal IEnumerator _0024_0024iterator_002413412_002416225;

			internal IEnumerator _0024_0024iterator_002413413_002416226;

			internal IEnumerator _0024_0024iterator_002413414_002416227;

			internal IEnumerator _0024_0024iterator_002413415_002416228;

			internal IEnumerator _0024_0024iterator_002413416_002416229;

			internal IEnumerator _0024_0024iterator_002413417_002416230;

			internal IEnumerator _0024_0024iterator_002413418_002416231;

			internal LotterySequence _0024self__002416232;

			public _0024(LotterySequence self_)
			{
				_0024self__002416232 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416121 = "S540_LotteryMulti";
					_0024_0024CUR_EXEC_0024_002416122 = _0024self__002416232.lastCreatedExec;
					BattleHUDShortcut.Hide();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:540", "call命令");
					_0024_0024s540_0024call_00241006_002416123 = _0024self__002416232.createExec("S540_HideWebView", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241005_002416124 = _0024self__002416232.S540_HideWebView();
					if (_0024_0024s540_0024call_00241005_002416124 != null)
					{
						_0024_0024iterator_002413396_002416209 = _0024_0024s540_0024call_00241005_002416124;
						goto case 2;
					}
					goto IL_012f;
				case 2:
					if (_0024_0024iterator_002413396_002416209.MoveNext())
					{
						_0024_0024s540_0024call_00241007_002416125 = _0024_0024iterator_002413396_002416209.Current;
						result = (Yield(2, _0024_0024s540_0024call_00241007_002416125) ? 1 : 0);
						break;
					}
					goto IL_012f;
				case 3:
					if (_0024_0024iterator_002413397_002416210.MoveNext())
					{
						_0024_0024s540_0024call_00241010_002416132 = _0024_0024iterator_002413397_002416210.Current;
						result = (Yield(3, _0024_0024s540_0024call_00241010_002416132) ? 1 : 0);
						break;
					}
					goto IL_03f2;
				case 4:
					if (_0024_0024iterator_002413398_002416211.MoveNext())
					{
						_0024_0024s540_0024call_00241013_002416135 = _0024_0024iterator_002413398_002416211.Current;
						result = (Yield(4, _0024_0024s540_0024call_00241013_002416135) ? 1 : 0);
						break;
					}
					goto IL_04a4;
				case 5:
					if (_0024_0024iterator_002413399_002416212.MoveNext())
					{
						_0024_0024s540_0024call_00241016_002416138 = _0024_0024iterator_002413399_002416212.Current;
						result = (Yield(5, _0024_0024s540_0024call_00241016_002416138) ? 1 : 0);
						break;
					}
					goto IL_05a2;
				case 6:
					if (_0024_0024CUR_EXEC_0024_002416122.NotExecuting)
					{
						goto case 1;
					}
					goto IL_05ed;
				case 7:
					if (_0024_0024iterator_002413400_002416213.MoveNext())
					{
						_0024_0024s540_0024call_00241019_002416142 = _0024_0024iterator_002413400_002416213.Current;
						result = (Yield(7, _0024_0024s540_0024call_00241019_002416142) ? 1 : 0);
						break;
					}
					goto IL_06df;
				case 8:
					if (!_0024_0024CUR_EXEC_0024_002416122.NotExecuting)
					{
						goto IL_0720;
					}
					goto case 1;
				case 9:
					if (_0024_0024iterator_002413401_002416214.MoveNext())
					{
						_0024_0024s540_0024call_00241022_002416145 = _0024_0024iterator_002413401_002416214.Current;
						result = (Yield(9, _0024_0024s540_0024call_00241022_002416145) ? 1 : 0);
						break;
					}
					goto IL_080d;
				case 10:
					if (_0024_0024iterator_002413402_002416215.MoveNext())
					{
						_0024_0024s540_0024call_00241025_002416148 = _0024_0024iterator_002413402_002416215.Current;
						result = (Yield(10, _0024_0024s540_0024call_00241025_002416148) ? 1 : 0);
						break;
					}
					goto IL_08df;
				case 11:
					if (_0024_0024iterator_002413403_002416216.MoveNext())
					{
						_0024_0024s540_0024call_00241028_002416151 = _0024_0024iterator_002413403_002416216.Current;
						result = (Yield(11, _0024_0024s540_0024call_00241028_002416151) ? 1 : 0);
						break;
					}
					goto IL_099d;
				case 12:
					if (_0024_0024iterator_002413404_002416217.MoveNext())
					{
						_0024_0024s540_0024call_00241031_002416154 = _0024_0024iterator_002413404_002416217.Current;
						result = (Yield(12, _0024_0024s540_0024call_00241031_002416154) ? 1 : 0);
						break;
					}
					goto IL_0a6b;
				case 13:
					if (_0024_0024iterator_002413405_002416218.MoveNext())
					{
						_0024_0024s540_0024call_00241034_002416157 = _0024_0024iterator_002413405_002416218.Current;
						result = (Yield(13, _0024_0024s540_0024call_00241034_002416157) ? 1 : 0);
						break;
					}
					goto IL_0b3f;
				case 14:
					if (_0024_0024iterator_002413406_002416219.MoveNext())
					{
						_0024_0024s540_0024call_00241037_002416160 = _0024_0024iterator_002413406_002416219.Current;
						result = (Yield(14, _0024_0024s540_0024call_00241037_002416160) ? 1 : 0);
						break;
					}
					goto IL_0bfc;
				case 15:
					if (_0024_0024iterator_002413407_002416220.MoveNext())
					{
						_0024_0024s540_0024call_00241040_002416163 = _0024_0024iterator_002413407_002416220.Current;
						result = (Yield(15, _0024_0024s540_0024call_00241040_002416163) ? 1 : 0);
						break;
					}
					goto IL_0cc0;
				case 16:
					if (_0024_0024iterator_002413408_002416221.MoveNext())
					{
						_0024_0024s540_0024call_00241043_002416166 = _0024_0024iterator_002413408_002416221.Current;
						result = (Yield(16, _0024_0024s540_0024call_00241043_002416166) ? 1 : 0);
						break;
					}
					goto IL_0d99;
				case 17:
					if (_0024_0024iterator_002413409_002416222.MoveNext())
					{
						_0024_0024s540_0024call_00241046_002416169 = _0024_0024iterator_002413409_002416222.Current;
						result = (Yield(17, _0024_0024s540_0024call_00241046_002416169) ? 1 : 0);
						break;
					}
					goto IL_0e5c;
				case 18:
					if (_0024_0024iterator_002413410_002416223.MoveNext())
					{
						_0024_0024s540_0024call_00241049_002416172 = _0024_0024iterator_002413410_002416223.Current;
						result = (Yield(18, _0024_0024s540_0024call_00241049_002416172) ? 1 : 0);
						break;
					}
					goto IL_0f5b;
				case 19:
					if (_0024_0024iterator_002413411_002416224.MoveNext())
					{
						_0024_0024s540_0024call_00241052_002416175 = _0024_0024iterator_002413411_002416224.Current;
						result = (Yield(19, _0024_0024s540_0024call_00241052_002416175) ? 1 : 0);
						break;
					}
					goto IL_1038;
				case 20:
					if (_0024_0024iterator_002413412_002416225.MoveNext())
					{
						_0024_0024s540_0024call_00241055_002416178 = _0024_0024iterator_002413412_002416225.Current;
						result = (Yield(20, _0024_0024s540_0024call_00241055_002416178) ? 1 : 0);
						break;
					}
					goto IL_10fb;
				case 21:
					if (_0024_0024iterator_002413413_002416226.MoveNext())
					{
						_0024_0024s540_0024call_00241058_002416181 = _0024_0024iterator_002413413_002416226.Current;
						result = (Yield(21, _0024_0024s540_0024call_00241058_002416181) ? 1 : 0);
						break;
					}
					goto IL_11cd;
				case 22:
					if (_0024_0024iterator_002413414_002416227.MoveNext())
					{
						_0024_0024s540_0024call_00241061_002416184 = _0024_0024iterator_002413414_002416227.Current;
						result = (Yield(22, _0024_0024s540_0024call_00241061_002416184) ? 1 : 0);
						break;
					}
					goto IL_128b;
				case 23:
					if (_0024_0024iterator_002413415_002416228.MoveNext())
					{
						_0024_0024s540_0024call_00241064_002416187 = _0024_0024iterator_002413415_002416228.Current;
						result = (Yield(23, _0024_0024s540_0024call_00241064_002416187) ? 1 : 0);
						break;
					}
					goto IL_136f;
				case 24:
					if (_0024_0024iterator_002413416_002416229.MoveNext())
					{
						_0024_0024s540_0024call_00241067_002416190 = _0024_0024iterator_002413416_002416229.Current;
						result = (Yield(24, _0024_0024s540_0024call_00241067_002416190) ? 1 : 0);
						break;
					}
					goto IL_1473;
				case 25:
					if (_0024_0024iterator_002413417_002416230.MoveNext())
					{
						_0024_0024s540_0024call_00241070_002416195 = _0024_0024iterator_002413417_002416230.Current;
						result = (Yield(25, _0024_0024s540_0024call_00241070_002416195) ? 1 : 0);
						break;
					}
					goto IL_162a;
				case 26:
					if (_0024_0024iterator_002413418_002416231.MoveNext())
					{
						_0024_0024s540_0024call_00241073_002416202 = _0024_0024iterator_002413418_002416231.Current;
						result = (Yield(26, _0024_0024s540_0024call_00241073_002416202) ? 1 : 0);
						break;
					}
					goto IL_187c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_099d:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.CamDraw();
					_0024self__002416232.NikiHand();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:574", "call命令");
					_0024_0024s540_0024call_00241030_002416152 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241029_002416153 = _0024self__002416232.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_00241029_002416153 != null)
					{
						_0024_0024iterator_002413404_002416217 = _0024_0024s540_0024call_00241029_002416153;
						goto case 12;
					}
					goto IL_0a6b;
					IL_012f:
					if (_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						if (_0024self__002416232.testMode)
						{
							goto IL_02e0;
						}
						if (_0024self__002416232.przNum <= 0)
						{
							_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:543", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024988_002416126 = _0024self__002416232.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024989_002416127 = _0024self__002416232.S540_Home();
							_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024988_002416126, _0024_0024s540_0024tmp_0024989_002416127);
							_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
						}
						else
						{
							if (_0024self__002416232.przNum != 1)
							{
								goto IL_02e0;
							}
							_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:546", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_LotterySingle" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024990_002416128 = _0024self__002416232.createExecAsCurrent("S540_LotterySingle");
							_0024_0024s540_0024tmp_0024991_002416129 = _0024self__002416232.S540_LotterySingle();
							_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024990_002416128, _0024_0024s540_0024tmp_0024991_002416129);
							_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
						}
					}
					goto case 1;
					IL_128b:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.HanabiOff();
					_0024self__002416232.PrizeHide();
					_0024self__002416232.HideDetail();
					_0024self__002416232.CamDraw_e();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:609", "call命令");
					_0024_0024s540_0024call_00241063_002416185 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241062_002416186 = _0024self__002416232.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_00241062_002416186 != null)
					{
						_0024_0024iterator_002413415_002416228 = _0024_0024s540_0024call_00241062_002416186;
						goto case 23;
					}
					goto IL_136f;
					IL_162a:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					goto IL_1ae7;
					IL_0a6b:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.SkipDisplay();
					if (_0024self__002416232.rare <= 4)
					{
						_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:577", "call命令");
						_0024_0024s540_0024call_00241033_002416155 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
						_0024_0024s540_0024call_00241032_002416156 = _0024self__002416232.S540_WaitSec(0.3f);
						if (_0024_0024s540_0024call_00241032_002416156 != null)
						{
							_0024_0024iterator_002413405_002416218 = _0024_0024s540_0024call_00241032_002416156;
							goto case 13;
						}
						goto IL_0b3f;
					}
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:579", "call命令");
					_0024_0024s540_0024call_00241036_002416158 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241035_002416159 = _0024self__002416232.S540_WaitSec(0.42f);
					if (_0024_0024s540_0024call_00241035_002416159 != null)
					{
						_0024_0024iterator_002413406_002416219 = _0024_0024s540_0024call_00241035_002416159;
						goto case 14;
					}
					goto IL_0bfc;
					IL_02e0:
					if (_0024self__002416232.przNum > 11)
					{
						_0024self__002416232.przNum = 11;
					}
					if (!_0024self__002416232.testMode)
					{
						_0024self__002416232.SendLottery(_0024self__002416232.curGacha.MGachaId.Id, _0024self__002416232.przNum);
					}
					_0024self__002416232.Black();
					_0024self__002416232.NikiSeek();
					_0024self__002416232.CamSeek();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:552", "call命令");
					_0024_0024s540_0024call_00241009_002416130 = _0024self__002416232.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241008_002416131 = _0024self__002416232.S540_SelifHide();
					if (_0024_0024s540_0024call_00241008_002416131 != null)
					{
						_0024_0024iterator_002413397_002416210 = _0024_0024s540_0024call_00241008_002416131;
						goto case 3;
					}
					goto IL_03f2;
					IL_0f5b:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					goto IL_1053;
					IL_1038:
					if (_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto IL_1053;
					}
					goto case 1;
					IL_0b3f:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					goto IL_0cdb;
					IL_03f2:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:553", "call命令");
					_0024_0024s540_0024call_00241012_002416133 = _0024self__002416232.createExec("S540_TitleExit", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241011_002416134 = _0024self__002416232.S540_TitleExit();
					if (_0024_0024s540_0024call_00241011_002416134 != null)
					{
						_0024_0024iterator_002413398_002416211 = _0024_0024s540_0024call_00241011_002416134;
						goto case 4;
					}
					goto IL_04a4;
					IL_1473:
					if (_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						_0024self__002416232.NikiIdle();
						_0024self__002416232.LastPanelActive();
						BattleHUDShortcut.Show();
						if (_0024self__002416232.testMode || _0024self__002416232.curGacha.SaleGachaTypeIs != EnumStepGachaTypes.NO_STEP)
						{
							_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:621", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_Home" + "(" + string.Empty + ")");
							_0024_0024s540_0024go_0024993_002416191 = _0024self__002416232.createExecAsCurrent("S540_Home");
							_0024_0024s540_0024tmp_0024994_002416192 = _0024self__002416232.S540_Home();
							_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024993_002416191, _0024_0024s540_0024tmp_0024994_002416192);
							_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
						}
						else
						{
							if (_0024self__002416232.gachaMode == 0)
							{
								_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:623", "call命令");
								_0024_0024s540_0024call_00241069_002416193 = _0024self__002416232.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002416122);
								_0024_0024s540_0024call_00241068_002416194 = _0024self__002416232.S540_GoStoneGacha(eventFlag: false);
								if (_0024_0024s540_0024call_00241068_002416194 != null)
								{
									_0024_0024iterator_002413417_002416230 = _0024_0024s540_0024call_00241068_002416194;
									goto case 25;
								}
								goto IL_162a;
							}
							if (_0024self__002416232.gachaMode == 1)
							{
								_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:625", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "false" + ")");
								_0024_0024s540_0024go_0024995_002416196 = _0024self__002416232.createExecAsCurrent("S540_RaidPointLottery");
								_0024_0024s540_0024tmp_0024996_002416197 = _0024self__002416232.S540_RaidPointLottery(eventFlag: false);
								_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024995_002416196, _0024_0024s540_0024tmp_0024996_002416197);
								_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
							}
							else if (_0024self__002416232.gachaMode == 2)
							{
								_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:627", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "false" + ")");
								_0024_0024s540_0024go_0024997_002416198 = _0024self__002416232.createExecAsCurrent("S540_FriendPointLottery");
								_0024_0024s540_0024tmp_0024998_002416199 = _0024self__002416232.S540_FriendPointLottery(eventFlag: false);
								_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024997_002416198, _0024_0024s540_0024tmp_0024998_002416199);
								_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
							}
							else
							{
								if (_0024self__002416232.gachaMode == 3)
								{
									_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:629", "call命令");
									_0024_0024s540_0024call_00241072_002416200 = _0024self__002416232.createExec("S540_GoStoneGacha", _0024_0024CUR_EXEC_0024_002416122);
									_0024_0024s540_0024call_00241071_002416201 = _0024self__002416232.S540_GoStoneGacha(eventFlag: true);
									if (_0024_0024s540_0024call_00241071_002416201 != null)
									{
										_0024_0024iterator_002413418_002416231 = _0024_0024s540_0024call_00241071_002416201;
										goto case 26;
									}
									goto IL_187c;
								}
								if (_0024self__002416232.gachaMode == 4)
								{
									_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:631", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_RaidPointLottery" + "(" + "true" + ")");
									_0024_0024s540_0024go_0024999_002416203 = _0024self__002416232.createExecAsCurrent("S540_RaidPointLottery");
									_0024_0024s540_0024tmp_00241000_002416204 = _0024self__002416232.S540_RaidPointLottery(eventFlag: true);
									_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_0024999_002416203, _0024_0024s540_0024tmp_00241000_002416204);
									_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
								}
								else if (_0024self__002416232.gachaMode == 5)
								{
									_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:633", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_FriendPointLottery" + "(" + "true" + ")");
									_0024_0024s540_0024go_00241001_002416205 = _0024self__002416232.createExecAsCurrent("S540_FriendPointLottery");
									_0024_0024s540_0024tmp_00241002_002416206 = _0024self__002416232.S540_FriendPointLottery(eventFlag: true);
									_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_00241001_002416205, _0024_0024s540_0024tmp_00241002_002416206);
									_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
								}
								else
								{
									if (_0024self__002416232.gachaMode != 6)
									{
										goto IL_1ae7;
									}
									_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:635", "go命令 " + _0024self__002416232.CurrentStateName + "->" + "S540_End" + "(" + string.Empty + ")");
									_0024_0024s540_0024go_00241003_002416207 = _0024self__002416232.createExecAsCurrent("S540_End");
									_0024_0024s540_0024tmp_00241004_002416208 = _0024self__002416232.S540_End();
									_0024self__002416232.entryCoroutine(_0024_0024s540_0024go_00241003_002416207, _0024_0024s540_0024tmp_00241004_002416208);
									_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
								}
							}
						}
					}
					goto case 1;
					IL_04a4:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					if (_0024self__002416232.curGacha != null)
					{
						_0024self__002416232.ChangeBagTexture(_0024self__002416232.curGacha.Id);
					}
					_0024self__002416232.rollSeId = _0024self__002416232.PlayJingle("Card_Get_Roll", resumeBgm: true);
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:556", "call命令");
					_0024_0024s540_0024call_00241015_002416136 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241014_002416137 = _0024self__002416232.S540_WaitSec(0.2f);
					if (_0024_0024s540_0024call_00241014_002416137 != null)
					{
						_0024_0024iterator_002413399_002416212 = _0024_0024s540_0024call_00241014_002416137;
						goto case 5;
					}
					goto IL_05a2;
					IL_1053:
					_0024self__002416232.BlackHalf();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:600", "call命令");
					_0024_0024s540_0024call_00241054_002416176 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241053_002416177 = _0024self__002416232.S540_WaitSec(1f);
					if (_0024_0024s540_0024call_00241053_002416177 != null)
					{
						_0024_0024iterator_002413412_002416225 = _0024_0024s540_0024call_00241053_002416177;
						goto case 20;
					}
					goto IL_10fb;
					IL_1ae7:
					_0024self__002416232.stop(_0024_0024CUR_EXEC_0024_002416122);
					goto case 1;
					IL_0bfc:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					GameSoundManager.PlaySe("se_system_lottery_prizm", 0);
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:581", "call命令");
					_0024_0024s540_0024call_00241039_002416161 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241038_002416162 = _0024self__002416232.S540_WaitSec(1.08f);
					if (_0024_0024s540_0024call_00241038_002416162 != null)
					{
						_0024_0024iterator_002413407_002416220 = _0024_0024s540_0024call_00241038_002416162;
						goto case 15;
					}
					goto IL_0cc0;
					IL_05a2:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					if (!_0024self__002416232.testMode)
					{
						_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:558", "loop命令");
						goto IL_05ed;
					}
					goto IL_0643;
					IL_136f:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.SkipHide();
					if (_0024self__002416232.curGacha != null)
					{
						_0024self__002416232.RestoreBagTexture(_0024self__002416232.curGacha.Id);
						_0024self__002416232.RestoreFpBannerTexture(_0024self__002416232.curGacha.Id);
					}
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:615", "call命令");
					_0024_0024s540_0024call_00241066_002416188 = _0024self__002416232.createExec("S540_BoxCheck", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241065_002416189 = _0024self__002416232.S540_BoxCheck();
					if (_0024_0024s540_0024call_00241065_002416189 != null)
					{
						_0024_0024iterator_002413416_002416229 = _0024_0024s540_0024call_00241065_002416189;
						goto case 24;
					}
					goto IL_1473;
					IL_0cc0:
					if (_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto IL_0cdb;
					}
					goto case 1;
					IL_05ed:
					_0024_0024s540_0024loop_0024992_002416139 = Time.frameCount;
					if (_0024self__002416232.CheckLotteryResult())
					{
						goto IL_0643;
					}
					if (_0024_0024s540_0024loop_0024992_002416139 == Time.frameCount)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto case 6;
					IL_0cdb:
					if (_0024self__002416232.skip)
					{
						_0024self__002416232.NikiHandSkip();
					}
					_0024self__002416232.SkipHide();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:585", "call命令");
					_0024_0024s540_0024call_00241042_002416164 = _0024self__002416232.createExec("S540_Prize", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241041_002416165 = _0024self__002416232.S540_Prize();
					if (_0024_0024s540_0024call_00241041_002416165 != null)
					{
						_0024_0024iterator_002413408_002416221 = _0024_0024s540_0024call_00241041_002416165;
						goto case 16;
					}
					goto IL_0d99;
					IL_0643:
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:560", "call命令");
					_0024_0024s540_0024call_00241018_002416140 = _0024self__002416232.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241017_002416141 = _0024self__002416232.S540_WaitSec(0.8f);
					if (_0024_0024s540_0024call_00241017_002416141 != null)
					{
						_0024_0024iterator_002413400_002416213 = _0024_0024s540_0024call_00241017_002416141;
						goto case 7;
					}
					goto IL_06df;
					IL_10fb:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.SkipDisplay();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:602", "call命令");
					_0024_0024s540_0024call_00241057_002416179 = _0024self__002416232.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241056_002416180 = _0024self__002416232.S540_WaitButton("Skip", "Back", string.Empty, string.Empty);
					if (_0024_0024s540_0024call_00241056_002416180 != null)
					{
						_0024_0024iterator_002413413_002416226 = _0024_0024s540_0024call_00241056_002416180;
						goto case 21;
					}
					goto IL_11cd;
					IL_187c:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					goto IL_1ae7;
					IL_06df:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					goto IL_0720;
					IL_0720:
					if (_0024self__002416232.hokan)
					{
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					_0024self__002416232.PanelActive(string.Empty, string.Empty);
					_0024self__002416232.RareUpdate();
					_0024self__002416232.NikiSeekLight();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:567", "call命令");
					_0024_0024s540_0024call_00241021_002416143 = _0024self__002416232.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241020_002416144 = _0024self__002416232.S540_Selif(_0024self__002416232.selif_wait_tap, -230f, 180f, 30f);
					if (_0024_0024s540_0024call_00241020_002416144 != null)
					{
						_0024_0024iterator_002413401_002416214 = _0024_0024s540_0024call_00241020_002416144;
						goto case 9;
					}
					goto IL_080d;
					IL_0d99:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					_0024self__002416232.SkipDisplay();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:588", "call命令");
					_0024_0024s540_0024call_00241045_002416167 = _0024self__002416232.createExec("S540_NewItemPrizeDemo", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241044_002416168 = _0024self__002416232.S540_NewItemPrizeDemo();
					if (_0024_0024s540_0024call_00241044_002416168 != null)
					{
						_0024_0024iterator_002413409_002416222 = _0024_0024s540_0024call_00241044_002416168;
						goto case 17;
					}
					goto IL_0e5c;
					IL_080d:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.TapDisplay();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:569", "call命令");
					_0024_0024s540_0024call_00241024_002416146 = _0024self__002416232.createExec("S540_WaitButton", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241023_002416147 = _0024self__002416232.S540_WaitButton("Tap", string.Empty, string.Empty, string.Empty);
					if (_0024_0024s540_0024call_00241023_002416147 != null)
					{
						_0024_0024iterator_002413402_002416215 = _0024_0024s540_0024call_00241023_002416147;
						goto case 10;
					}
					goto IL_08df;
					IL_11cd:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.SkipDisplay();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:604", "call命令");
					_0024_0024s540_0024call_00241060_002416182 = _0024self__002416232.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241059_002416183 = _0024self__002416232.S540_SelifHide();
					if (_0024_0024s540_0024call_00241059_002416183 != null)
					{
						_0024_0024iterator_002413414_002416227 = _0024_0024s540_0024call_00241059_002416183;
						goto case 22;
					}
					goto IL_128b;
					IL_08df:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.TapHide();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:571", "call命令");
					_0024_0024s540_0024call_00241027_002416149 = _0024self__002416232.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241026_002416150 = _0024self__002416232.S540_SelifHide();
					if (_0024_0024s540_0024call_00241026_002416150 != null)
					{
						_0024_0024iterator_002413403_002416216 = _0024_0024s540_0024call_00241026_002416150;
						goto case 11;
					}
					goto IL_099d;
					IL_0e5c:
					if (!_0024self__002416232.isExecuting(_0024_0024CUR_EXEC_0024_002416122))
					{
						goto case 1;
					}
					_0024self__002416232.SkipHide();
					if (_0024self__002416232.rare >= 5)
					{
						_0024self__002416232.NikiLuck();
						_0024self__002416232.Hanabi();
						_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:594", "call命令");
						_0024_0024s540_0024call_00241048_002416170 = _0024self__002416232.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416122);
						_0024_0024s540_0024call_00241047_002416171 = _0024self__002416232.S540_Selif(_0024self__002416232.selif_draw_rare, 350f, 240f, -10f);
						if (_0024_0024s540_0024call_00241047_002416171 != null)
						{
							_0024_0024iterator_002413410_002416223 = _0024_0024s540_0024call_00241047_002416171;
							goto case 18;
						}
						goto IL_0f5b;
					}
					_0024self__002416232.NikiWin();
					_0024self__002416232.dtrace(_0024_0024CUR_EXEC_0024_002416122, "LotterySequence.boo:597", "call命令");
					_0024_0024s540_0024call_00241051_002416173 = _0024self__002416232.createExec("S540_Selif", _0024_0024CUR_EXEC_0024_002416122);
					_0024_0024s540_0024call_00241050_002416174 = _0024self__002416232.S540_Selif(_0024self__002416232.selif_draw_blank, 350f, 240f, -10f);
					if (_0024_0024s540_0024call_00241050_002416174 != null)
					{
						_0024_0024iterator_002413411_002416224 = _0024_0024s540_0024call_00241050_002416174;
						goto case 19;
					}
					goto IL_1038;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416233;

		public _0024S540_LotteryMulti_002416120(LotterySequence self_)
		{
			_0024self__002416233 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416233);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_End_002416234 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241081_002416235;

			internal object _0024___item_002416236;

			internal IEnumerator _0024_0024iterator_002413419_002416237;

			internal LotterySequence _0024self__002416238;

			public _0024(LotterySequence self_)
			{
				_0024self__002416238 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241081_002416235 = _0024self__002416238.S540_End(null);
					if (_0024_0024s540_0024ycode_00241081_002416235 != null)
					{
						_0024_0024iterator_002413419_002416237 = _0024_0024s540_0024ycode_00241081_002416235;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413419_002416237.MoveNext())
					{
						_0024___item_002416236 = _0024_0024iterator_002413419_002416237.Current;
						result = (Yield(2, _0024___item_002416236) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416239;

		public _0024S540_End_002416234(LotterySequence self_)
		{
			_0024self__002416239 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416239);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_End_002416240 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416241;

			internal Exec _0024_0024CUR_EXEC_0024_002416242;

			internal Exec _0024_0024s540_0024call_00241076_002416243;

			internal IEnumerator _0024_0024s540_0024call_00241075_002416244;

			internal object _0024_0024s540_0024call_00241077_002416245;

			internal Exec _0024_0024s540_0024call_00241079_002416246;

			internal IEnumerator _0024_0024s540_0024call_00241078_002416247;

			internal object _0024_0024s540_0024call_00241080_002416248;

			internal ApiPresent _0024req_002416249;

			internal IEnumerator _0024_0024iterator_002413420_002416250;

			internal IEnumerator _0024_0024iterator_002413421_002416251;

			internal LotterySequence _0024self__002416252;

			public _0024(LotterySequence self_)
			{
				_0024self__002416252 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416241 = "S540_End";
					_0024_0024CUR_EXEC_0024_002416242 = _0024self__002416252.lastCreatedExec;
					_0024self__002416252.PanelActive(string.Empty, string.Empty);
					_0024self__002416252.dtrace(_0024_0024CUR_EXEC_0024_002416242, "LotterySequence.boo:640", "call命令");
					_0024_0024s540_0024call_00241076_002416243 = _0024self__002416252.createExec("S540_PanelIn", _0024_0024CUR_EXEC_0024_002416242);
					_0024_0024s540_0024call_00241075_002416244 = _0024self__002416252.S540_PanelIn();
					if (_0024_0024s540_0024call_00241075_002416244 != null)
					{
						_0024_0024iterator_002413420_002416250 = _0024_0024s540_0024call_00241075_002416244;
						goto case 2;
					}
					goto IL_00ef;
				case 2:
					if (_0024_0024iterator_002413420_002416250.MoveNext())
					{
						_0024_0024s540_0024call_00241077_002416245 = _0024_0024iterator_002413420_002416250.Current;
						result = (Yield(2, _0024_0024s540_0024call_00241077_002416245) ? 1 : 0);
						break;
					}
					goto IL_00ef;
				case 3:
					if (_0024_0024iterator_002413421_002416251.MoveNext())
					{
						_0024_0024s540_0024call_00241080_002416248 = _0024_0024iterator_002413421_002416251.Current;
						result = (Yield(3, _0024_0024s540_0024call_00241080_002416248) ? 1 : 0);
						break;
					}
					goto IL_01b0;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002416242.NotExecuting)
					{
						goto IL_01f1;
					}
					goto case 1;
				case 5:
					if (!_0024_0024CUR_EXEC_0024_002416242.NotExecuting)
					{
						goto IL_0253;
					}
					goto case 1;
				case 6:
					if (!_0024_0024CUR_EXEC_0024_002416242.NotExecuting)
					{
						goto IL_029d;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01b0:
					if (!_0024self__002416252.isExecuting(_0024_0024CUR_EXEC_0024_002416242))
					{
						goto case 1;
					}
					goto IL_01f1;
					IL_01f1:
					if (!endUpdateFunc())
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					endUpdateFunc = null;
					goto IL_0206;
					IL_00ef:
					if (!_0024self__002416252.isExecuting(_0024_0024CUR_EXEC_0024_002416242))
					{
						goto case 1;
					}
					if (endUpdateFunc != null)
					{
						_0024self__002416252.dtrace(_0024_0024CUR_EXEC_0024_002416242, "LotterySequence.boo:643", "call命令");
						_0024_0024s540_0024call_00241079_002416246 = _0024self__002416252.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416242);
						_0024_0024s540_0024call_00241078_002416247 = _0024self__002416252.S540_WaitSec(0.1f);
						if (_0024_0024s540_0024call_00241078_002416247 != null)
						{
							_0024_0024iterator_002413421_002416251 = _0024_0024s540_0024call_00241078_002416247;
							goto case 3;
						}
						goto IL_01b0;
					}
					goto IL_0206;
					IL_0253:
					if (!_0024req_002416249.IsEnd)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					UserData.Current.userMiscInfo.flagData.updateCondition();
					goto IL_029d;
					IL_029d:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024self__002416252.EndLottery();
					_0024self__002416252.stop(_0024_0024CUR_EXEC_0024_002416242);
					goto case 1;
					IL_0206:
					if (_0024self__002416252.gachaCount > 0)
					{
						_0024req_002416249 = new ApiPresent();
						MerlinServer.Request(_0024req_002416249);
						goto IL_0253;
					}
					goto IL_029d;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416253;

		public _0024S540_End_002416240(LotterySequence self_)
		{
			_0024self__002416253 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416253);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_PanelIn_002416254 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241082_002416255;

			internal object _0024___item_002416256;

			internal IEnumerator _0024_0024iterator_002413422_002416257;

			internal LotterySequence _0024self__002416258;

			public _0024(LotterySequence self_)
			{
				_0024self__002416258 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241082_002416255 = _0024self__002416258.S540_PanelIn(null);
					if (_0024_0024s540_0024ycode_00241082_002416255 != null)
					{
						_0024_0024iterator_002413422_002416257 = _0024_0024s540_0024ycode_00241082_002416255;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413422_002416257.MoveNext())
					{
						_0024___item_002416256 = _0024_0024iterator_002413422_002416257.Current;
						result = (Yield(2, _0024___item_002416256) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416259;

		public _0024S540_PanelIn_002416254(LotterySequence self_)
		{
			_0024self__002416259 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416259);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_BackIn_002416260 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241083_002416261;

			internal object _0024___item_002416262;

			internal IEnumerator _0024_0024iterator_002413423_002416263;

			internal LotterySequence _0024self__002416264;

			public _0024(LotterySequence self_)
			{
				_0024self__002416264 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241083_002416261 = _0024self__002416264.S540_BackIn(null);
					if (_0024_0024s540_0024ycode_00241083_002416261 != null)
					{
						_0024_0024iterator_002413423_002416263 = _0024_0024s540_0024ycode_00241083_002416261;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413423_002416263.MoveNext())
					{
						_0024___item_002416262 = _0024_0024iterator_002413423_002416263.Current;
						result = (Yield(2, _0024___item_002416262) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416265;

		public _0024S540_BackIn_002416260(LotterySequence self_)
		{
			_0024self__002416265 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416265);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_PanelExit_002416266 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241084_002416267;

			internal object _0024___item_002416268;

			internal IEnumerator _0024_0024iterator_002413424_002416269;

			internal LotterySequence _0024self__002416270;

			public _0024(LotterySequence self_)
			{
				_0024self__002416270 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241084_002416267 = _0024self__002416270.S540_PanelExit(null);
					if (_0024_0024s540_0024ycode_00241084_002416267 != null)
					{
						_0024_0024iterator_002413424_002416269 = _0024_0024s540_0024ycode_00241084_002416267;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413424_002416269.MoveNext())
					{
						_0024___item_002416268 = _0024_0024iterator_002413424_002416269.Current;
						result = (Yield(2, _0024___item_002416268) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416271;

		public _0024S540_PanelExit_002416266(LotterySequence self_)
		{
			_0024self__002416271 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416271);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_PanelExit_002416272 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416273;

			internal Exec _0024_0024CUR_EXEC_0024_002416274;

			internal LotterySequence _0024self__002416275;

			public _0024(LotterySequence self_)
			{
				_0024self__002416275 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416273 = "S540_PanelExit";
					_0024_0024CUR_EXEC_0024_002416274 = _0024self__002416275.lastCreatedExec;
					_0024self__002416275.pnlIn = false;
					_0024self__002416275.alpTgt = 0f;
					_0024self__002416275.hokanRate = 0f;
					_0024self__002416275.hokan = true;
					goto IL_008b;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416274.NotExecuting)
					{
						goto IL_008b;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008b:
					if (_0024self__002416275.hokan)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416275.stop(_0024_0024CUR_EXEC_0024_002416274);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416276;

		public _0024S540_PanelExit_002416272(LotterySequence self_)
		{
			_0024self__002416276 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416276);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_TitleExit_002416277 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241085_002416278;

			internal object _0024___item_002416279;

			internal IEnumerator _0024_0024iterator_002413425_002416280;

			internal LotterySequence _0024self__002416281;

			public _0024(LotterySequence self_)
			{
				_0024self__002416281 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241085_002416278 = _0024self__002416281.S540_TitleExit(null);
					if (_0024_0024s540_0024ycode_00241085_002416278 != null)
					{
						_0024_0024iterator_002413425_002416280 = _0024_0024s540_0024ycode_00241085_002416278;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413425_002416280.MoveNext())
					{
						_0024___item_002416279 = _0024_0024iterator_002413425_002416280.Current;
						result = (Yield(2, _0024___item_002416279) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416282;

		public _0024S540_TitleExit_002416277(LotterySequence self_)
		{
			_0024self__002416282 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416282);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Selif_002416283 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241089_002416284;

			internal object _0024___item_002416285;

			internal IEnumerator _0024_0024iterator_002413426_002416286;

			internal string _0024msg_002416287;

			internal float _0024x_002416288;

			internal float _0024y_002416289;

			internal float _0024rot_002416290;

			internal LotterySequence _0024self__002416291;

			public _0024(string msg, float x, float y, float rot, LotterySequence self_)
			{
				_0024msg_002416287 = msg;
				_0024x_002416288 = x;
				_0024y_002416289 = y;
				_0024rot_002416290 = rot;
				_0024self__002416291 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241089_002416284 = _0024self__002416291.S540_Selif(_0024msg_002416287, _0024x_002416288, _0024y_002416289, _0024rot_002416290, null);
					if (_0024_0024s540_0024ycode_00241089_002416284 != null)
					{
						_0024_0024iterator_002413426_002416286 = _0024_0024s540_0024ycode_00241089_002416284;
						goto case 2;
					}
					goto IL_0090;
				case 2:
					if (_0024_0024iterator_002413426_002416286.MoveNext())
					{
						_0024___item_002416285 = _0024_0024iterator_002413426_002416286.Current;
						result = (Yield(2, _0024___item_002416285) ? 1 : 0);
						break;
					}
					goto IL_0090;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0090:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024msg_002416292;

		internal float _0024x_002416293;

		internal float _0024y_002416294;

		internal float _0024rot_002416295;

		internal LotterySequence _0024self__002416296;

		public _0024S540_Selif_002416283(string msg, float x, float y, float rot, LotterySequence self_)
		{
			_0024msg_002416292 = msg;
			_0024x_002416293 = x;
			_0024y_002416294 = y;
			_0024rot_002416295 = rot;
			_0024self__002416296 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg_002416292, _0024x_002416293, _0024y_002416294, _0024rot_002416295, _0024self__002416296);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Selif_002416297 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416298;

			internal Exec _0024_0024CUR_EXEC_0024_002416299;

			internal Exec _0024_0024s540_0024call_00241087_002416300;

			internal IEnumerator _0024_0024s540_0024call_00241086_002416301;

			internal object _0024_0024s540_0024call_00241088_002416302;

			internal IEnumerator _0024_0024iterator_002413427_002416303;

			internal string _0024msg_002416304;

			internal float _0024x_002416305;

			internal float _0024y_002416306;

			internal float _0024rot_002416307;

			internal LotterySequence _0024self__002416308;

			public _0024(string msg, float x, float y, float rot, LotterySequence self_)
			{
				_0024msg_002416304 = msg;
				_0024x_002416305 = x;
				_0024y_002416306 = y;
				_0024rot_002416307 = rot;
				_0024self__002416308 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416298 = "S540_Selif";
					_0024_0024CUR_EXEC_0024_002416299 = _0024self__002416308.lastCreatedExec;
					_0024self__002416308.dtrace(_0024_0024CUR_EXEC_0024_002416299, "LotterySequence.boo:705", "call命令");
					_0024_0024s540_0024call_00241087_002416300 = _0024self__002416308.createExec("S540_SelifHide", _0024_0024CUR_EXEC_0024_002416299);
					_0024_0024s540_0024call_00241086_002416301 = _0024self__002416308.S540_SelifHide();
					if (_0024_0024s540_0024call_00241086_002416301 != null)
					{
						_0024_0024iterator_002413427_002416303 = _0024_0024s540_0024call_00241086_002416301;
						goto case 2;
					}
					goto IL_00ca;
				case 2:
					if (_0024_0024iterator_002413427_002416303.MoveNext())
					{
						_0024_0024s540_0024call_00241088_002416302 = _0024_0024iterator_002413427_002416303.Current;
						result = (Yield(2, _0024_0024s540_0024call_00241088_002416302) ? 1 : 0);
						break;
					}
					goto IL_00ca;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ca:
					if (_0024self__002416308.isExecuting(_0024_0024CUR_EXEC_0024_002416299))
					{
						_0024self__002416308.NikiSelif(_0024msg_002416304, _0024x_002416305, _0024y_002416306, _0024rot_002416307);
						_0024self__002416308.pnlIn_s = true;
						_0024self__002416308.alpTgt_s = 1f;
						_0024self__002416308.hokan_s = true;
						_0024self__002416308.stop(_0024_0024CUR_EXEC_0024_002416299);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024msg_002416309;

		internal float _0024x_002416310;

		internal float _0024y_002416311;

		internal float _0024rot_002416312;

		internal LotterySequence _0024self__002416313;

		public _0024S540_Selif_002416297(string msg, float x, float y, float rot, LotterySequence self_)
		{
			_0024msg_002416309 = msg;
			_0024x_002416310 = x;
			_0024y_002416311 = y;
			_0024rot_002416312 = rot;
			_0024self__002416313 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg_002416309, _0024x_002416310, _0024y_002416311, _0024rot_002416312, _0024self__002416313);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_SelifHide_002416314 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241090_002416315;

			internal object _0024___item_002416316;

			internal IEnumerator _0024_0024iterator_002413428_002416317;

			internal LotterySequence _0024self__002416318;

			public _0024(LotterySequence self_)
			{
				_0024self__002416318 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241090_002416315 = _0024self__002416318.S540_SelifHide(null);
					if (_0024_0024s540_0024ycode_00241090_002416315 != null)
					{
						_0024_0024iterator_002413428_002416317 = _0024_0024s540_0024ycode_00241090_002416315;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413428_002416317.MoveNext())
					{
						_0024___item_002416316 = _0024_0024iterator_002413428_002416317.Current;
						result = (Yield(2, _0024___item_002416316) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416319;

		public _0024S540_SelifHide_002416314(LotterySequence self_)
		{
			_0024self__002416319 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416319);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_SelifHide_002416320 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416321;

			internal Exec _0024_0024CUR_EXEC_0024_002416322;

			internal LotterySequence _0024self__002416323;

			public _0024(LotterySequence self_)
			{
				_0024self__002416323 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416321 = "S540_SelifHide";
					_0024_0024CUR_EXEC_0024_002416322 = _0024self__002416323.lastCreatedExec;
					_0024self__002416323.pnlIn_s = false;
					_0024self__002416323.alpTgt_s = 0f;
					_0024self__002416323.hokanRate_s = 0f;
					_0024self__002416323.hokan_s = true;
					goto IL_008b;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416322.NotExecuting)
					{
						goto IL_008b;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008b:
					if (_0024self__002416323.hokan_s && !_0024self__002416323.skip)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416323.stop(_0024_0024CUR_EXEC_0024_002416322);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416324;

		public _0024S540_SelifHide_002416320(LotterySequence self_)
		{
			_0024self__002416324 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416324);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FadeOut_002416325 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241091_002416326;

			internal object _0024___item_002416327;

			internal IEnumerator _0024_0024iterator_002413429_002416328;

			internal LotterySequence _0024self__002416329;

			public _0024(LotterySequence self_)
			{
				_0024self__002416329 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241091_002416326 = _0024self__002416329.S540_FadeOut(null);
					if (_0024_0024s540_0024ycode_00241091_002416326 != null)
					{
						_0024_0024iterator_002413429_002416328 = _0024_0024s540_0024ycode_00241091_002416326;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413429_002416328.MoveNext())
					{
						_0024___item_002416327 = _0024_0024iterator_002413429_002416328.Current;
						result = (Yield(2, _0024___item_002416327) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416330;

		public _0024S540_FadeOut_002416325(LotterySequence self_)
		{
			_0024self__002416330 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416330);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FadeOut_002416331 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416332;

			internal Exec _0024_0024CUR_EXEC_0024_002416333;

			internal LotterySequence _0024self__002416334;

			public _0024(LotterySequence self_)
			{
				_0024self__002416334 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416332 = "S540_FadeOut";
					_0024_0024CUR_EXEC_0024_002416333 = _0024self__002416334.lastCreatedExec;
					_0024self__002416334.Fade();
					_0024self__002416334.hokan_f = true;
					goto IL_0070;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416333.NotExecuting)
					{
						goto IL_0070;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0070:
					if (_0024self__002416334.hokan_f)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416334.stop(_0024_0024CUR_EXEC_0024_002416333);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416335;

		public _0024S540_FadeOut_002416331(LotterySequence self_)
		{
			_0024self__002416335 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416335);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FadeIn_002416336 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241092_002416337;

			internal object _0024___item_002416338;

			internal IEnumerator _0024_0024iterator_002413430_002416339;

			internal LotterySequence _0024self__002416340;

			public _0024(LotterySequence self_)
			{
				_0024self__002416340 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241092_002416337 = _0024self__002416340.S540_FadeIn(null);
					if (_0024_0024s540_0024ycode_00241092_002416337 != null)
					{
						_0024_0024iterator_002413430_002416339 = _0024_0024s540_0024ycode_00241092_002416337;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413430_002416339.MoveNext())
					{
						_0024___item_002416338 = _0024_0024iterator_002413430_002416339.Current;
						result = (Yield(2, _0024___item_002416338) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416341;

		public _0024S540_FadeIn_002416336(LotterySequence self_)
		{
			_0024self__002416341 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416341);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_FadeIn_002416342 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416343;

			internal Exec _0024_0024CUR_EXEC_0024_002416344;

			internal LotterySequence _0024self__002416345;

			public _0024(LotterySequence self_)
			{
				_0024self__002416345 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416343 = "S540_FadeIn";
					_0024_0024CUR_EXEC_0024_002416344 = _0024self__002416345.lastCreatedExec;
					_0024self__002416345.FadeOff();
					_0024self__002416345.hokan_f = true;
					goto IL_0070;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416344.NotExecuting)
					{
						goto IL_0070;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0070:
					if (_0024self__002416345.hokan_f)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416345.stop(_0024_0024CUR_EXEC_0024_002416344);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416346;

		public _0024S540_FadeIn_002416342(LotterySequence self_)
		{
			_0024self__002416346 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416346);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WhiteOut_002416347 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241093_002416348;

			internal object _0024___item_002416349;

			internal IEnumerator _0024_0024iterator_002413431_002416350;

			internal LotterySequence _0024self__002416351;

			public _0024(LotterySequence self_)
			{
				_0024self__002416351 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241093_002416348 = _0024self__002416351.S540_WhiteOut(null);
					if (_0024_0024s540_0024ycode_00241093_002416348 != null)
					{
						_0024_0024iterator_002413431_002416350 = _0024_0024s540_0024ycode_00241093_002416348;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413431_002416350.MoveNext())
					{
						_0024___item_002416349 = _0024_0024iterator_002413431_002416350.Current;
						result = (Yield(2, _0024___item_002416349) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416352;

		public _0024S540_WhiteOut_002416347(LotterySequence self_)
		{
			_0024self__002416352 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416352);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WhiteOut_002416353 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416354;

			internal Exec _0024_0024CUR_EXEC_0024_002416355;

			internal LotterySequence _0024self__002416356;

			public _0024(LotterySequence self_)
			{
				_0024self__002416356 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416354 = "S540_WhiteOut";
					_0024_0024CUR_EXEC_0024_002416355 = _0024self__002416356.lastCreatedExec;
					_0024self__002416356.White();
					_0024self__002416356.hokan_f = true;
					goto IL_0070;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416355.NotExecuting)
					{
						goto IL_0070;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0070:
					if (_0024self__002416356.hokan_f)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416356.stop(_0024_0024CUR_EXEC_0024_002416355);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416357;

		public _0024S540_WhiteOut_002416353(LotterySequence self_)
		{
			_0024self__002416357 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416357);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WhiteIn_002416358 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241094_002416359;

			internal object _0024___item_002416360;

			internal IEnumerator _0024_0024iterator_002413432_002416361;

			internal LotterySequence _0024self__002416362;

			public _0024(LotterySequence self_)
			{
				_0024self__002416362 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241094_002416359 = _0024self__002416362.S540_WhiteIn(null);
					if (_0024_0024s540_0024ycode_00241094_002416359 != null)
					{
						_0024_0024iterator_002413432_002416361 = _0024_0024s540_0024ycode_00241094_002416359;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413432_002416361.MoveNext())
					{
						_0024___item_002416360 = _0024_0024iterator_002413432_002416361.Current;
						result = (Yield(2, _0024___item_002416360) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416363;

		public _0024S540_WhiteIn_002416358(LotterySequence self_)
		{
			_0024self__002416363 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416363);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WhiteIn_002416364 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416365;

			internal Exec _0024_0024CUR_EXEC_0024_002416366;

			internal LotterySequence _0024self__002416367;

			public _0024(LotterySequence self_)
			{
				_0024self__002416367 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416365 = "S540_WhiteIn";
					_0024_0024CUR_EXEC_0024_002416366 = _0024self__002416367.lastCreatedExec;
					_0024self__002416367.WhiteOff();
					_0024self__002416367.hokan_f = true;
					goto IL_0070;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416366.NotExecuting)
					{
						goto IL_0070;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0070:
					if (_0024self__002416367.hokan_f)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416367.stop(_0024_0024CUR_EXEC_0024_002416366);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416368;

		public _0024S540_WhiteIn_002416364(LotterySequence self_)
		{
			_0024self__002416368 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416368);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitButton_002416369 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241095_002416370;

			internal object _0024___item_002416371;

			internal IEnumerator _0024_0024iterator_002413433_002416372;

			internal string _0024msg0_002416373;

			internal string _0024msg1_002416374;

			internal string _0024msg2_002416375;

			internal string _0024msg3_002416376;

			internal LotterySequence _0024self__002416377;

			public _0024(string msg0, string msg1, string msg2, string msg3, LotterySequence self_)
			{
				_0024msg0_002416373 = msg0;
				_0024msg1_002416374 = msg1;
				_0024msg2_002416375 = msg2;
				_0024msg3_002416376 = msg3;
				_0024self__002416377 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241095_002416370 = _0024self__002416377.S540_WaitButton(_0024msg0_002416373, _0024msg1_002416374, _0024msg2_002416375, _0024msg3_002416376, null);
					if (_0024_0024s540_0024ycode_00241095_002416370 != null)
					{
						_0024_0024iterator_002413433_002416372 = _0024_0024s540_0024ycode_00241095_002416370;
						goto case 2;
					}
					goto IL_0090;
				case 2:
					if (_0024_0024iterator_002413433_002416372.MoveNext())
					{
						_0024___item_002416371 = _0024_0024iterator_002413433_002416372.Current;
						result = (Yield(2, _0024___item_002416371) ? 1 : 0);
						break;
					}
					goto IL_0090;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0090:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024msg0_002416378;

		internal string _0024msg1_002416379;

		internal string _0024msg2_002416380;

		internal string _0024msg3_002416381;

		internal LotterySequence _0024self__002416382;

		public _0024S540_WaitButton_002416369(string msg0, string msg1, string msg2, string msg3, LotterySequence self_)
		{
			_0024msg0_002416378 = msg0;
			_0024msg1_002416379 = msg1;
			_0024msg2_002416380 = msg2;
			_0024msg3_002416381 = msg3;
			_0024self__002416382 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg0_002416378, _0024msg1_002416379, _0024msg2_002416380, _0024msg3_002416381, _0024self__002416382);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitButton_002416383 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416384;

			internal Exec _0024_0024CUR_EXEC_0024_002416385;

			internal string _0024msg0_002416386;

			internal string _0024msg1_002416387;

			internal string _0024msg2_002416388;

			internal string _0024msg3_002416389;

			internal LotterySequence _0024self__002416390;

			public _0024(string msg0, string msg1, string msg2, string msg3, LotterySequence self_)
			{
				_0024msg0_002416386 = msg0;
				_0024msg1_002416387 = msg1;
				_0024msg2_002416388 = msg2;
				_0024msg3_002416389 = msg3;
				_0024self__002416390 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416384 = "S540_WaitButton";
					_0024_0024CUR_EXEC_0024_002416385 = _0024self__002416390.lastCreatedExec;
					goto IL_005d;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416385.NotExecuting)
					{
						goto IL_005d;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002416385.NotExecuting)
					{
						goto IL_00a9;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005d:
					if (_0024self__002416390.hokan)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416390.message = string.Empty;
					btnNo = -1;
					goto IL_00a9;
					IL_00a9:
					if (_0024self__002416390.message == string.Empty || (!(_0024self__002416390.message == _0024msg0_002416386) && !(_0024self__002416390.message == _0024msg1_002416387) && !(_0024self__002416390.message == _0024msg2_002416388) && !(_0024self__002416390.message == _0024msg3_002416389)))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024self__002416390.message == _0024msg0_002416386)
					{
						btnNo = 0;
					}
					else if (_0024self__002416390.message == _0024msg1_002416387)
					{
						btnNo = 1;
					}
					else if (_0024self__002416390.message == _0024msg2_002416388)
					{
						btnNo = 2;
					}
					else if (_0024self__002416390.message == _0024msg3_002416389)
					{
						btnNo = 3;
					}
					_0024self__002416390.stop(_0024_0024CUR_EXEC_0024_002416385);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024msg0_002416391;

		internal string _0024msg1_002416392;

		internal string _0024msg2_002416393;

		internal string _0024msg3_002416394;

		internal LotterySequence _0024self__002416395;

		public _0024S540_WaitButton_002416383(string msg0, string msg1, string msg2, string msg3, LotterySequence self_)
		{
			_0024msg0_002416391 = msg0;
			_0024msg1_002416392 = msg1;
			_0024msg2_002416393 = msg2;
			_0024msg3_002416394 = msg3;
			_0024self__002416395 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg0_002416391, _0024msg1_002416392, _0024msg2_002416393, _0024msg3_002416394, _0024self__002416395);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitButtons_002416396 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241097_002416397;

			internal object _0024___item_002416398;

			internal IEnumerator _0024_0024iterator_002413434_002416399;

			internal string[] _0024msgs_002416400;

			internal LotterySequence _0024self__002416401;

			public _0024(string[] msgs, LotterySequence self_)
			{
				_0024msgs_002416400 = msgs;
				_0024self__002416401 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241097_002416397 = _0024self__002416401.S540_WaitButtons(_0024msgs_002416400, null);
					if (_0024_0024s540_0024ycode_00241097_002416397 != null)
					{
						_0024_0024iterator_002413434_002416399 = _0024_0024s540_0024ycode_00241097_002416397;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413434_002416399.MoveNext())
					{
						_0024___item_002416398 = _0024_0024iterator_002413434_002416399.Current;
						result = (Yield(2, _0024___item_002416398) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string[] _0024msgs_002416402;

		internal LotterySequence _0024self__002416403;

		public _0024S540_WaitButtons_002416396(string[] msgs, LotterySequence self_)
		{
			_0024msgs_002416402 = msgs;
			_0024self__002416403 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msgs_002416402, _0024self__002416403);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitButtons_002416404 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416405;

			internal Exec _0024_0024CUR_EXEC_0024_002416406;

			internal int _0024_0024s540_0024loop_00241096_002416407;

			internal int _0024i_002416408;

			internal string _0024msg_002416409;

			internal int _0024_00248204_002416410;

			internal string[] _0024_00248205_002416411;

			internal int _0024_00248206_002416412;

			internal string[] _0024msgs_002416413;

			internal LotterySequence _0024self__002416414;

			public _0024(string[] msgs, LotterySequence self_)
			{
				_0024msgs_002416413 = msgs;
				_0024self__002416414 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024STATE_NAME_0024_002416405 = "S540_WaitButtons";
						_0024_0024CUR_EXEC_0024_002416406 = _0024self__002416414.lastCreatedExec;
						goto IL_0061;
					case 2:
						if (!_0024_0024CUR_EXEC_0024_002416406.NotExecuting)
						{
							goto IL_0061;
						}
						goto case 1;
					case 3:
						if (!_0024_0024CUR_EXEC_0024_002416406.NotExecuting)
						{
							goto IL_00d8;
						}
						goto case 1;
					case 4:
						if (_0024_0024CUR_EXEC_0024_002416406.NotExecuting)
						{
							goto case 1;
						}
						goto IL_00a7;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0061:
						if (_0024self__002416414.hokan)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002416414.message = string.Empty;
						btnNo = -1;
						_0024self__002416414.dtrace(_0024_0024CUR_EXEC_0024_002416406, "LotterySequence.boo:762", "loop命令");
						goto IL_00a7;
						IL_0144:
						btnNo = _0024i_002416408;
						_0024self__002416414.stop(_0024_0024CUR_EXEC_0024_002416406);
						goto case 1;
						IL_00a7:
						_0024_0024s540_0024loop_00241096_002416407 = Time.frameCount;
						goto IL_00d8;
						IL_00d8:
						if (_0024self__002416414.message == string.Empty)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024i_002416408 = 0;
						_0024_00248204_002416410 = 0;
						_0024_00248205_002416411 = _0024msgs_002416413;
						_0024_00248206_002416412 = _0024_00248205_002416411.Length;
						while (_0024_00248204_002416410 < _0024_00248206_002416412)
						{
							if (!(_0024self__002416414.message == _0024_00248205_002416411[_0024_00248204_002416410]))
							{
								_0024i_002416408++;
								_0024_00248204_002416410++;
								continue;
							}
							goto IL_0144;
						}
						if (_0024_0024s540_0024loop_00241096_002416407 == Time.frameCount)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						goto case 4;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string[] _0024msgs_002416415;

		internal LotterySequence _0024self__002416416;

		public _0024S540_WaitButtons_002416404(string[] msgs, LotterySequence self_)
		{
			_0024msgs_002416415 = msgs;
			_0024self__002416416 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msgs_002416415, _0024self__002416416);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitSec_002416417 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241098_002416418;

			internal object _0024___item_002416419;

			internal IEnumerator _0024_0024iterator_002413435_002416420;

			internal float _0024t_002416421;

			internal LotterySequence _0024self__002416422;

			public _0024(float t, LotterySequence self_)
			{
				_0024t_002416421 = t;
				_0024self__002416422 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241098_002416418 = _0024self__002416422.S540_WaitSec(_0024t_002416421, null);
					if (_0024_0024s540_0024ycode_00241098_002416418 != null)
					{
						_0024_0024iterator_002413435_002416420 = _0024_0024s540_0024ycode_00241098_002416418;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413435_002416420.MoveNext())
					{
						_0024___item_002416419 = _0024_0024iterator_002413435_002416420.Current;
						result = (Yield(2, _0024___item_002416419) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_002416423;

		internal LotterySequence _0024self__002416424;

		public _0024S540_WaitSec_002416417(float t, LotterySequence self_)
		{
			_0024t_002416423 = t;
			_0024self__002416424 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_002416423, _0024self__002416424);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_WaitSec_002416425 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416426;

			internal Exec _0024_0024CUR_EXEC_0024_002416427;

			internal float _0024t_002416428;

			internal LotterySequence _0024self__002416429;

			public _0024(float t, LotterySequence self_)
			{
				_0024t_002416428 = t;
				_0024self__002416429 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416426 = "S540_WaitSec";
					_0024_0024CUR_EXEC_0024_002416427 = _0024self__002416429.lastCreatedExec;
					_0024self__002416429.time = _0024t_002416428;
					goto IL_006a;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416427.NotExecuting)
					{
						goto IL_006a;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_006a:
					if (_0024self__002416429.time != 0f && !_0024self__002416429.skip)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416429.stop(_0024_0024CUR_EXEC_0024_002416427);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024t_002416430;

		internal LotterySequence _0024self__002416431;

		public _0024S540_WaitSec_002416425(float t, LotterySequence self_)
		{
			_0024t_002416430 = t;
			_0024self__002416431 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024t_002416430, _0024self__002416431);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Prize_002416432 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241099_002416433;

			internal object _0024___item_002416434;

			internal IEnumerator _0024_0024iterator_002413436_002416435;

			internal LotterySequence _0024self__002416436;

			public _0024(LotterySequence self_)
			{
				_0024self__002416436 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241099_002416433 = _0024self__002416436.S540_Prize(null);
					if (_0024_0024s540_0024ycode_00241099_002416433 != null)
					{
						_0024_0024iterator_002413436_002416435 = _0024_0024s540_0024ycode_00241099_002416433;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413436_002416435.MoveNext())
					{
						_0024___item_002416434 = _0024_0024iterator_002413436_002416435.Current;
						result = (Yield(2, _0024___item_002416434) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416437;

		public _0024S540_Prize_002416432(LotterySequence self_)
		{
			_0024self__002416437 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416437);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_Prize_002416438 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416439;

			internal Exec _0024_0024CUR_EXEC_0024_002416440;

			internal LotterySequence _0024self__002416441;

			public _0024(LotterySequence self_)
			{
				_0024self__002416441 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416439 = "S540_Prize";
					_0024_0024CUR_EXEC_0024_002416440 = _0024self__002416441.lastCreatedExec;
					_0024self__002416441.EnablePrizeButton(enable: false);
					_0024self__002416441.Prize();
					_0024self__002416441.hokan_p = true;
					goto IL_007c;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002416440.NotExecuting)
					{
						goto IL_007c;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007c:
					if (_0024self__002416441.hokan_p && !_0024self__002416441.skip)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416441.stop(_0024_0024CUR_EXEC_0024_002416440);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416442;

		public _0024S540_Prize_002416438(LotterySequence self_)
		{
			_0024self__002416442 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416442);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LoadBagTaxture_002416443 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241100_002416444;

			internal object _0024___item_002416445;

			internal IEnumerator _0024_0024iterator_002413437_002416446;

			internal string _0024urlTamplate_002416447;

			internal LotterySequence _0024self__002416448;

			public _0024(string urlTamplate, LotterySequence self_)
			{
				_0024urlTamplate_002416447 = urlTamplate;
				_0024self__002416448 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241100_002416444 = _0024self__002416448.S540_LoadBagTaxture(_0024urlTamplate_002416447, null);
					if (_0024_0024s540_0024ycode_00241100_002416444 != null)
					{
						_0024_0024iterator_002413437_002416446 = _0024_0024s540_0024ycode_00241100_002416444;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413437_002416446.MoveNext())
					{
						_0024___item_002416445 = _0024_0024iterator_002413437_002416446.Current;
						result = (Yield(2, _0024___item_002416445) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlTamplate_002416449;

		internal LotterySequence _0024self__002416450;

		public _0024S540_LoadBagTaxture_002416443(string urlTamplate, LotterySequence self_)
		{
			_0024urlTamplate_002416449 = urlTamplate;
			_0024self__002416450 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlTamplate_002416449, _0024self__002416450);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LoadFpBannerTaxture_002416451 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241101_002416452;

			internal object _0024___item_002416453;

			internal IEnumerator _0024_0024iterator_002413438_002416454;

			internal string _0024urlTamplate_002416455;

			internal LotterySequence _0024self__002416456;

			public _0024(string urlTamplate, LotterySequence self_)
			{
				_0024urlTamplate_002416455 = urlTamplate;
				_0024self__002416456 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241101_002416452 = _0024self__002416456.S540_LoadFpBannerTaxture(_0024urlTamplate_002416455, null);
					if (_0024_0024s540_0024ycode_00241101_002416452 != null)
					{
						_0024_0024iterator_002413438_002416454 = _0024_0024s540_0024ycode_00241101_002416452;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413438_002416454.MoveNext())
					{
						_0024___item_002416453 = _0024_0024iterator_002413438_002416454.Current;
						result = (Yield(2, _0024___item_002416453) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlTamplate_002416457;

		internal LotterySequence _0024self__002416458;

		public _0024S540_LoadFpBannerTaxture_002416451(string urlTamplate, LotterySequence self_)
		{
			_0024urlTamplate_002416457 = urlTamplate;
			_0024self__002416458 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlTamplate_002416457, _0024self__002416458);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LoadFpBannerTaxture_002416459 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416460;

			internal Exec _0024_0024CUR_EXEC_0024_002416461;

			internal DateTime _0024today_002416462;

			internal string _0024file_002416463;

			internal MSaleGachas _0024msaleGacha_002416464;

			internal int _0024_00248212_002416465;

			internal MSaleGachas[] _0024_00248213_002416466;

			internal int _0024_00248214_002416467;

			internal _0024S540_LoadFpBannerTaxture_0024locals_002414330 _0024_0024locals_002416468;

			internal string _0024urlTamplate_002416469;

			internal LotterySequence _0024self__002416470;

			public _0024(string urlTamplate, LotterySequence self_)
			{
				_0024urlTamplate_002416469 = urlTamplate;
				_0024self__002416470 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002416468 = new _0024S540_LoadFpBannerTaxture_0024locals_002414330();
						_0024_0024STATE_NAME_0024_002416460 = "S540_LoadFpBannerTaxture";
						_0024_0024CUR_EXEC_0024_002416461 = _0024self__002416470.lastCreatedExec;
						MerlinServer.Busy = true;
						_0024self__002416470.fpBannerTexture.Clear();
						_0024today_002416462 = MerlinDateTime.UtcNow;
						_0024_0024locals_002416468._0024ok = false;
						_0024file_002416463 = urlDefaultFpBannerTexutre;
						_0024_0024locals_002416468._0024defTexture = null;
						_0024self__002416470.LoadResource(_0024file_002416463, new _0024S540_LoadFpBannerTaxture_0024closure_00242956(_0024_0024locals_002416468).Invoke);
						goto IL_00d3;
					case 2:
						if (!_0024_0024CUR_EXEC_0024_002416461.NotExecuting)
						{
							goto IL_00d3;
						}
						goto case 1;
					case 3:
						if (!_0024_0024CUR_EXEC_0024_002416461.NotExecuting)
						{
							goto IL_0237;
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00d3:
						if (!_0024_0024locals_002416468._0024ok)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_00248212_002416465 = 0;
						_0024_00248213_002416466 = MSaleGachas.All;
						_0024_00248214_002416467 = _0024_00248213_002416466.Length;
						goto IL_0255;
						IL_0237:
						if (!_0024_0024locals_002416468._0024ok)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						goto IL_0247;
						IL_0255:
						if (_0024_00248212_002416465 < _0024_00248214_002416467)
						{
							if (_0024today_002416462 < _0024_00248213_002416466[_0024_00248212_002416465].StartDate || (_0024_00248213_002416466[_0024_00248212_002416465].EndDate < _0024today_002416462 && unchecked((int)_0024_00248213_002416466[_0024_00248212_002416465].EndDate.Ticks) != 0) || _0024_00248213_002416466[_0024_00248212_002416465].MGachaId.GachaTyepValue != EnumGachaTypeValues.Normal)
							{
								goto IL_0247;
							}
							_0024_0024locals_002416468._0024ok = false;
							_0024file_002416463 = UIBasicUtility.SafeFormat(_0024urlTamplate_002416469, _0024_00248213_002416466[_0024_00248212_002416465].Id);
							_0024self__002416470.LoadResource(_0024file_002416463, new _0024S540_LoadFpBannerTaxture_0024closure_00242957(_0024_0024locals_002416468, _0024_00248213_002416466, _0024self__002416470, _0024_00248212_002416465).Invoke);
							goto IL_0237;
						}
						MerlinServer.Busy = false;
						_0024self__002416470.stop(_0024_0024CUR_EXEC_0024_002416461);
						goto case 1;
						IL_0247:
						_0024_00248212_002416465++;
						goto IL_0255;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlTamplate_002416471;

		internal LotterySequence _0024self__002416472;

		public _0024S540_LoadFpBannerTaxture_002416459(string urlTamplate, LotterySequence self_)
		{
			_0024urlTamplate_002416471 = urlTamplate;
			_0024self__002416472 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlTamplate_002416471, _0024self__002416472);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LoadBannerHtml_002416473 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241102_002416474;

			internal object _0024___item_002416475;

			internal IEnumerator _0024_0024iterator_002413439_002416476;

			internal string _0024urlTamplate_002416477;

			internal LotterySequence _0024self__002416478;

			public _0024(string urlTamplate, LotterySequence self_)
			{
				_0024urlTamplate_002416477 = urlTamplate;
				_0024self__002416478 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241102_002416474 = _0024self__002416478.S540_LoadBannerHtml(_0024urlTamplate_002416477, null);
					if (_0024_0024s540_0024ycode_00241102_002416474 != null)
					{
						_0024_0024iterator_002413439_002416476 = _0024_0024s540_0024ycode_00241102_002416474;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413439_002416476.MoveNext())
					{
						_0024___item_002416475 = _0024_0024iterator_002413439_002416476.Current;
						result = (Yield(2, _0024___item_002416475) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlTamplate_002416479;

		internal LotterySequence _0024self__002416480;

		public _0024S540_LoadBannerHtml_002416473(string urlTamplate, LotterySequence self_)
		{
			_0024urlTamplate_002416479 = urlTamplate;
			_0024self__002416480 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlTamplate_002416479, _0024self__002416480);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_LoadBannerHtml_002416481 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416482;

			internal Exec _0024_0024CUR_EXEC_0024_002416483;

			internal DateTime _0024today_002416484;

			internal MSaleGachas _0024msaleGacha_002416485;

			internal string _0024file_002416486;

			internal int _0024_00248216_002416487;

			internal MSaleGachas[] _0024_00248217_002416488;

			internal int _0024_00248218_002416489;

			internal _0024S540_LoadBannerHtml_0024locals_002414331 _0024_0024locals_002416490;

			internal string _0024urlTamplate_002416491;

			internal LotterySequence _0024self__002416492;

			public _0024(string urlTamplate, LotterySequence self_)
			{
				_0024urlTamplate_002416491 = urlTamplate;
				_0024self__002416492 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002416490 = new _0024S540_LoadBannerHtml_0024locals_002414331();
						_0024_0024STATE_NAME_0024_002416482 = "S540_LoadBannerHtml";
						_0024_0024CUR_EXEC_0024_002416483 = _0024self__002416492.lastCreatedExec;
						MerlinServer.Busy = true;
						_0024self__002416492.bannerHtml.Clear();
						_0024today_002416484 = MerlinDateTime.UtcNow;
						_0024_00248216_002416487 = 0;
						_0024_00248217_002416488 = MSaleGachas.All;
						_0024_00248218_002416489 = _0024_00248217_002416488.Length;
						goto IL_01af;
					case 2:
						if (!_0024_0024CUR_EXEC_0024_002416483.NotExecuting)
						{
							goto IL_0191;
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01af:
						if (_0024_00248216_002416487 < _0024_00248218_002416489)
						{
							if (_0024today_002416484 < _0024_00248217_002416488[_0024_00248216_002416487].StartDate || (_0024_00248217_002416488[_0024_00248216_002416487].EndDate < _0024today_002416484 && unchecked((int)_0024_00248217_002416488[_0024_00248216_002416487].EndDate.Ticks) != 0))
							{
								goto IL_01a1;
							}
							_0024_0024locals_002416490._0024ok = false;
							_0024file_002416486 = UIBasicUtility.SafeFormat(_0024urlTamplate_002416491, _0024_00248217_002416488[_0024_00248216_002416487].Id);
							_0024self__002416492.LoadResource(_0024file_002416486, new _0024S540_LoadBannerHtml_0024closure_00242958(_0024self__002416492, _0024_00248216_002416487, _0024_0024locals_002416490, _0024_00248217_002416488).Invoke);
							goto IL_0191;
						}
						MerlinServer.Busy = false;
						_0024self__002416492.stop(_0024_0024CUR_EXEC_0024_002416483);
						goto case 1;
						IL_0191:
						if (!_0024_0024locals_002416490._0024ok)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_01a1;
						IL_01a1:
						_0024_00248216_002416487++;
						goto IL_01af;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024urlTamplate_002416493;

		internal LotterySequence _0024self__002416494;

		public _0024S540_LoadBannerHtml_002416481(string urlTamplate, LotterySequence self_)
		{
			_0024urlTamplate_002416493 = urlTamplate;
			_0024self__002416494 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024urlTamplate_002416493, _0024self__002416494);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_NewItemPrizeDemo_002416495 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241104_002416496;

			internal object _0024___item_002416497;

			internal IEnumerator _0024_0024iterator_002413440_002416498;

			internal LotterySequence _0024self__002416499;

			public _0024(LotterySequence self_)
			{
				_0024self__002416499 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241104_002416496 = _0024self__002416499.S540_NewItemPrizeDemo(null);
					if (_0024_0024s540_0024ycode_00241104_002416496 != null)
					{
						_0024_0024iterator_002413440_002416498 = _0024_0024s540_0024ycode_00241104_002416496;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413440_002416498.MoveNext())
					{
						_0024___item_002416497 = _0024_0024iterator_002413440_002416498.Current;
						result = (Yield(2, _0024___item_002416497) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416500;

		public _0024S540_NewItemPrizeDemo_002416495(LotterySequence self_)
		{
			_0024self__002416500 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416500);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_NewItemPrizeDemo_002416501 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416502;

			internal Exec _0024_0024CUR_EXEC_0024_002416503;

			internal bool _0024isNew_002416504;

			internal float _0024_0024wait_sec_0024temp_00241103_002416505;

			internal LotterySequence _0024self__002416506;

			public _0024(LotterySequence self_)
			{
				_0024self__002416506 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024STATE_NAME_0024_002416502 = "S540_NewItemPrizeDemo";
						_0024_0024CUR_EXEC_0024_002416503 = _0024self__002416506.lastCreatedExec;
						_0024self__002416506.demoAnimItemIndex = _0024self__002416506.przNum;
						SQEX_SoundPlayer.Instance.StopSeById(_0024self__002416506.rollSeId, 1000);
						goto IL_019b;
					case 2:
						if (!_0024_0024CUR_EXEC_0024_002416503.NotExecuting)
						{
							goto IL_00bd;
						}
						goto case 1;
					case 3:
						if (!_0024_0024CUR_EXEC_0024_002416503.NotExecuting)
						{
							goto IL_0178;
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_019b:
						if (0 < _0024self__002416506.demoAnimItemIndex)
						{
							_0024self__002416506.skip = false;
							_0024isNew_002416504 = _0024self__002416506.GetNewItemDemo(_0024self__002416506.demoAnimItemIndex - 1);
							goto IL_00bd;
						}
						_0024self__002416506.PushEndDemo(null);
						_0024self__002416506.EnablePrizeButton(enable: true);
						_0024self__002416506.stop(_0024_0024CUR_EXEC_0024_002416503);
						goto case 1;
						IL_00bd:
						if (!(_0024self__002416506.demoAnim == null) && !_0024self__002416506.skip)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002416506.demoAnim != null)
						{
							_0024self__002416506.PushSkipDemo(null);
						}
						_0024self__002416506.CoverOff(_0024self__002416506.demoAnimItemIndex - 1);
						_0024self__002416506.demoAnimItemIndex--;
						_0024_0024wait_sec_0024temp_00241103_002416505 = 0.333333f;
						goto IL_0178;
						IL_0178:
						if (_0024_0024wait_sec_0024temp_00241103_002416505 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241103_002416505 -= Time.deltaTime;
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (!_0024isNew_002416504)
						{
							_0024self__002416506.PlaySeByRarity();
						}
						goto IL_019b;
					}
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416507;

		public _0024S540_NewItemPrizeDemo_002416501(LotterySequence self_)
		{
			_0024self__002416507 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416507);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_HideWebView_002416508 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241105_002416509;

			internal object _0024___item_002416510;

			internal IEnumerator _0024_0024iterator_002413441_002416511;

			internal LotterySequence _0024self__002416512;

			public _0024(LotterySequence self_)
			{
				_0024self__002416512 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241105_002416509 = _0024self__002416512.S540_HideWebView(null);
					if (_0024_0024s540_0024ycode_00241105_002416509 != null)
					{
						_0024_0024iterator_002413441_002416511 = _0024_0024s540_0024ycode_00241105_002416509;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413441_002416511.MoveNext())
					{
						_0024___item_002416510 = _0024_0024iterator_002413441_002416511.Current;
						result = (Yield(2, _0024___item_002416510) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416513;

		public _0024S540_HideWebView_002416508(LotterySequence self_)
		{
			_0024self__002416513 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416513);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_ExecuteStoneList_002416514 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241115_002416515;

			internal object _0024___item_002416516;

			internal IEnumerator _0024_0024iterator_002413442_002416517;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002416518;

			internal LotterySequence _0024self__002416519;

			public _0024(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd, LotterySequence self_)
			{
				_0024onEnd_002416518 = onEnd;
				_0024self__002416519 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241115_002416515 = _0024self__002416519.S540_ExecuteStoneList(_0024onEnd_002416518, null);
					if (_0024_0024s540_0024ycode_00241115_002416515 != null)
					{
						_0024_0024iterator_002413442_002416517 = _0024_0024s540_0024ycode_00241115_002416515;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413442_002416517.MoveNext())
					{
						_0024___item_002416516 = _0024_0024iterator_002413442_002416517.Current;
						result = (Yield(2, _0024___item_002416516) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002416520;

		internal LotterySequence _0024self__002416521;

		public _0024S540_ExecuteStoneList_002416514(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd, LotterySequence self_)
		{
			_0024onEnd_002416520 = onEnd;
			_0024self__002416521 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024onEnd_002416520, _0024self__002416521);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_ExecuteStoneList_002416522 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416523;

			internal Exec _0024_0024s540_0024call_00241107_002416524;

			internal IEnumerator _0024_0024s540_0024call_00241106_002416525;

			internal object _0024_0024s540_0024call_00241108_002416526;

			internal Exec _0024_0024s540_0024call_00241110_002416527;

			internal IEnumerator _0024_0024s540_0024call_00241109_002416528;

			internal object _0024_0024s540_0024call_00241111_002416529;

			internal Exec _0024_0024s540_0024call_00241113_002416530;

			internal IEnumerator _0024_0024s540_0024call_00241112_002416531;

			internal object _0024_0024s540_0024call_00241114_002416532;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024update_002416533;

			internal IEnumerator _0024_0024iterator_002413443_002416534;

			internal IEnumerator _0024_0024iterator_002413444_002416535;

			internal IEnumerator _0024_0024iterator_002413445_002416536;

			internal _0024S540_ExecuteStoneList_0024locals_002414332 _0024_0024locals_002416537;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002416538;

			internal LotterySequence _0024self__002416539;

			public _0024(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd, LotterySequence self_)
			{
				_0024onEnd_002416538 = onEnd;
				_0024self__002416539 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416537 = new _0024S540_ExecuteStoneList_0024locals_002414332();
					_0024_0024STATE_NAME_0024_002416523 = "S540_ExecuteStoneList";
					_0024_0024locals_002416537._0024_0024CUR_EXEC_0024 = _0024self__002416539.lastCreatedExec;
					_0024self__002416539.dtrace(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024, "LotterySequence.boo:918", "call命令");
					_0024_0024s540_0024call_00241107_002416524 = _0024self__002416539.createExec("S540_PanelExit", _0024_0024locals_002416537._0024_0024CUR_EXEC_0024);
					_0024_0024s540_0024call_00241106_002416525 = _0024self__002416539.S540_PanelExit();
					if (_0024_0024s540_0024call_00241106_002416525 != null)
					{
						_0024_0024iterator_002413443_002416534 = _0024_0024s540_0024call_00241106_002416525;
						goto case 2;
					}
					goto IL_00f0;
				case 2:
					if (_0024_0024iterator_002413443_002416534.MoveNext())
					{
						_0024_0024s540_0024call_00241108_002416526 = _0024_0024iterator_002413443_002416534.Current;
						result = (Yield(2, _0024_0024s540_0024call_00241108_002416526) ? 1 : 0);
						break;
					}
					goto IL_00f0;
				case 3:
					if (_0024_0024iterator_002413444_002416535.MoveNext())
					{
						_0024_0024s540_0024call_00241111_002416529 = _0024_0024iterator_002413444_002416535.Current;
						result = (Yield(3, _0024_0024s540_0024call_00241111_002416529) ? 1 : 0);
						break;
					}
					goto IL_01f5;
				case 4:
					if (_0024_0024iterator_002413445_002416536.MoveNext())
					{
						_0024_0024s540_0024call_00241114_002416532 = _0024_0024iterator_002413445_002416536.Current;
						result = (Yield(4, _0024_0024s540_0024call_00241114_002416532) ? 1 : 0);
						break;
					}
					goto IL_02d5;
				case 5:
					if (!_0024_0024locals_002416537._0024_0024CUR_EXEC_0024.NotExecuting)
					{
						_0024self__002416539.stop(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024);
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01f5:
					if (!_0024self__002416539.isExecuting(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					goto IL_02f5;
					IL_00f0:
					if (!_0024self__002416539.isExecuting(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024))
					{
						goto case 1;
					}
					_0024self__002416539.PanelActive("StoneList", string.Empty);
					if (!(_0024self__002416539.ScreenAspect() <= 1.5f))
					{
						_0024self__002416539.dtrace(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024, "LotterySequence.boo:921", "call命令");
						_0024_0024s540_0024call_00241110_002416527 = _0024self__002416539.createExec("S540_Selif", _0024_0024locals_002416537._0024_0024CUR_EXEC_0024);
						_0024_0024s540_0024call_00241109_002416528 = _0024self__002416539.S540_Selif(_0024self__002416539.selif_insufficient, -410f, 160f, 10f);
						if (_0024_0024s540_0024call_00241109_002416528 != null)
						{
							_0024_0024iterator_002413444_002416535 = _0024_0024s540_0024call_00241109_002416528;
							goto case 3;
						}
						goto IL_01f5;
					}
					_0024self__002416539.dtrace(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024, "LotterySequence.boo:923", "call命令");
					_0024_0024s540_0024call_00241113_002416530 = _0024self__002416539.createExec("S540_Selif", _0024_0024locals_002416537._0024_0024CUR_EXEC_0024);
					_0024_0024s540_0024call_00241112_002416531 = _0024self__002416539.S540_Selif(_0024self__002416539.selif_insufficient, -390f, 160f, -10f);
					if (_0024_0024s540_0024call_00241112_002416531 != null)
					{
						_0024_0024iterator_002413445_002416536 = _0024_0024s540_0024call_00241112_002416531;
						goto case 4;
					}
					goto IL_02d5;
					IL_02d5:
					if (_0024self__002416539.isExecuting(_0024_0024locals_002416537._0024_0024CUR_EXEC_0024))
					{
						goto IL_02f5;
					}
					goto case 1;
					IL_02f5:
					if (!_0024self__002416539.uiParent)
					{
						_0024self__002416539.uiParent = GameObject.Find("Camera/0 Lottery/Center Anchor").transform;
					}
					if (!_0024self__002416539.stoneList)
					{
						_0024self__002416539.stoneList = StoneList.Create(_0024self__002416539.uiParent, _0024onEnd_002416538);
					}
					_0024self__002416539.stoneList.gameObject.SetActive(value: false);
					_0024self__002416539.stoneList.CreateBackButton(_0024self__002416539.gameObject);
					_0024update_002416533 = new _0024S540_ExecuteStoneList_0024update_00242977(_0024self__002416539, _0024_0024locals_002416537).Invoke;
					result = (Yield(5, _0024self__002416539.StartCoroutine(_0024update_002416533())) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024onEnd_002416540;

		internal LotterySequence _0024self__002416541;

		public _0024S540_ExecuteStoneList_002416522(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd, LotterySequence self_)
		{
			_0024onEnd_002416540 = onEnd;
			_0024self__002416541 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024onEnd_002416540, _0024self__002416541);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_BoxCheck_002416542 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241122_002416543;

			internal object _0024___item_002416544;

			internal IEnumerator _0024_0024iterator_002413446_002416545;

			internal LotterySequence _0024self__002416546;

			public _0024(LotterySequence self_)
			{
				_0024self__002416546 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241122_002416543 = _0024self__002416546.S540_BoxCheck(null);
					if (_0024_0024s540_0024ycode_00241122_002416543 != null)
					{
						_0024_0024iterator_002413446_002416545 = _0024_0024s540_0024ycode_00241122_002416543;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413446_002416545.MoveNext())
					{
						_0024___item_002416544 = _0024_0024iterator_002413446_002416545.Current;
						result = (Yield(2, _0024___item_002416544) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416547;

		public _0024S540_BoxCheck_002416542(LotterySequence self_)
		{
			_0024self__002416547 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416547);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_BoxCheck_002416548 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002416549;

			internal Exec _0024_0024CUR_EXEC_0024_002416550;

			internal int _0024lotteryBoxMax_002416551;

			internal MGameParameters _0024mgParam_002416552;

			internal Exec _0024_0024s540_0024call_00241117_002416553;

			internal IEnumerator _0024_0024s540_0024call_00241116_002416554;

			internal object _0024_0024s540_0024call_00241118_002416555;

			internal Exec _0024_0024s540_0024call_00241120_002416556;

			internal IEnumerator _0024_0024s540_0024call_00241119_002416557;

			internal object _0024_0024s540_0024call_00241121_002416558;

			internal IEnumerator _0024_0024iterator_002413447_002416559;

			internal IEnumerator _0024_0024iterator_002413448_002416560;

			internal LotterySequence _0024self__002416561;

			public _0024(LotterySequence self_)
			{
				_0024self__002416561 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002416549 = "S540_BoxCheck";
					_0024_0024CUR_EXEC_0024_002416550 = _0024self__002416561.lastCreatedExec;
					_0024lotteryBoxMax_002416551 = 2000;
					_0024mgParam_002416552 = MGameParameters.findByGameParameterId(63);
					if (_0024mgParam_002416552 != null)
					{
						_0024lotteryBoxMax_002416551 = _0024mgParam_002416552.Param;
					}
					if (UserData.Current.BoxCount > _0024lotteryBoxMax_002416551)
					{
						QuestManager.Instance.CheckBoxOver = true;
						_0024self__002416561.dtrace(_0024_0024CUR_EXEC_0024_002416550, "LotterySequence.boo:955", "call命令");
						_0024_0024s540_0024call_00241117_002416553 = _0024self__002416561.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416550);
						_0024_0024s540_0024call_00241116_002416554 = _0024self__002416561.S540_WaitSec(0.1f);
						if (_0024_0024s540_0024call_00241116_002416554 != null)
						{
							_0024_0024iterator_002413447_002416559 = _0024_0024s540_0024call_00241116_002416554;
							goto case 2;
						}
						goto IL_012b;
					}
					goto IL_0238;
				case 2:
					if (_0024_0024iterator_002413447_002416559.MoveNext())
					{
						_0024_0024s540_0024call_00241118_002416555 = _0024_0024iterator_002413447_002416559.Current;
						result = (Yield(2, _0024_0024s540_0024call_00241118_002416555) ? 1 : 0);
						break;
					}
					goto IL_012b;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002416550.NotExecuting)
					{
						goto IL_016c;
					}
					goto case 1;
				case 4:
					if (_0024_0024iterator_002413448_002416560.MoveNext())
					{
						_0024_0024s540_0024call_00241121_002416558 = _0024_0024iterator_002413448_002416560.Current;
						result = (Yield(4, _0024_0024s540_0024call_00241121_002416558) ? 1 : 0);
						break;
					}
					goto IL_0212;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0212:
					if (!_0024self__002416561.isExecuting(_0024_0024CUR_EXEC_0024_002416550))
					{
						goto case 1;
					}
					QuestManager.Instance.CheckBoxOver = false;
					goto IL_0238;
					IL_016c:
					if (InventoryOverDialog.IsInventoryOver())
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002416561.dtrace(_0024_0024CUR_EXEC_0024_002416550, "LotterySequence.boo:957", "call命令");
					_0024_0024s540_0024call_00241120_002416556 = _0024self__002416561.createExec("S540_WaitSec", _0024_0024CUR_EXEC_0024_002416550);
					_0024_0024s540_0024call_00241119_002416557 = _0024self__002416561.S540_WaitSec(0.1f);
					if (_0024_0024s540_0024call_00241119_002416557 != null)
					{
						_0024_0024iterator_002413448_002416560 = _0024_0024s540_0024call_00241119_002416557;
						goto case 4;
					}
					goto IL_0212;
					IL_0238:
					_0024self__002416561.stop(_0024_0024CUR_EXEC_0024_002416550);
					goto case 1;
					IL_012b:
					if (!_0024self__002416561.isExecuting(_0024_0024CUR_EXEC_0024_002416550))
					{
						goto case 1;
					}
					goto IL_016c;
				}
				return (byte)result != 0;
			}
		}

		internal LotterySequence _0024self__002416562;

		public _0024S540_BoxCheck_002416548(LotterySequence self_)
		{
			_0024self__002416562 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416562);
		}
	}

	[NonSerialized]
	protected static __LotterySequence_startUpdateFunc_0024callable42_002410_31__ startUpdateFunc;

	[NonSerialized]
	protected static __LotterySequence_startUpdateFunc_0024callable42_002410_31__ endUpdateFunc;

	private bool endFlag;

	[NonSerialized]
	private static PlayerControl plyrCtrl;

	[NonSerialized]
	private static int btnNo;

	public UILabelBase faystoneNumText;

	public UILabelBase raidPointNumText;

	public UILabelBase friendPointNumText;

	public UILabelBase faystoneEventNumText;

	public UILabelBase raidPointEventNumText;

	public UILabelBase friendPointEventNumText;

	public UILabelBase faystonePriceText;

	public UILabelBase raidPointPriceText;

	public UILabelBase friendPointPriceText;

	public UILabelBase faystoneEventPriceText;

	public UILabelBase raidPointEventPriceText;

	public UILabelBase friendPointEventPriceText;

	public UILabelBase friendPointCountText;

	public UILabelBase friendPointEventCountText;

	private Dictionary<UILabelBase, string> labelFormatCacheDictionary;

	private StoneList stoneList;

	[NonSerialized]
	private static string urlTexutre = "gacha_bag_{0}.png";

	[NonSerialized]
	private static string urlFpBannerTexutre = "gacha_friend_{0}.png";

	[NonSerialized]
	private static string urlDefaultFpBannerTexutre = "gacha_friend.png";

	public bool debug_no_friend_texture;

	public UILabelBase fayStoneTitle;

	public UILabelBase raidPointTitle;

	public UILabelBase friendPointTitle;

	public UILabelBase fayStoneEventTitle;

	public UILabelBase raidPointEventTitle;

	public UILabelBase friendPointEventTitle;

	public UIValidController faystoneButtonValid;

	public UIValidController raidPointButtonValid;

	public UIValidController friendPointButtonValid;

	public UIValidController faystoneEventButtonValid;

	public UIValidController raidPointEventButtonValid;

	public UIValidController friendPointEventButtonValid;

	public bool dispExplain;

	public UILabelBase fayStoneExplain;

	public UILabelBase raidPointExplain;

	public UILabelBase friendPointExplain;

	public UILabelBase fayStoneEventExplain;

	public UILabelBase raidPointEventExplain;

	public UILabelBase friendPointEventExplain;

	[NonSerialized]
	protected static int startId = -1;

	public Transform uiParent;

	private int rollSeId;

	private bool lastEventFlag;

	protected bool gacha1stHome;

	protected int gachaCount;

	public static int StartId
	{
		set
		{
			startId = value;
		}
	}

	public static bool EnableTutorial(__LotterySequence_startUpdateFunc_0024callable42_002410_31__ startFunc, __LotterySequence_startUpdateFunc_0024callable42_002410_31__ endFunc)
	{
		startUpdateFunc = startFunc;
		endUpdateFunc = endFunc;
		return false;
	}

	public IEnumerator S540_init()
	{
		return new _0024S540_init_002415656(this).GetEnumerator();
	}

	public IEnumerator S540_init(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_init_002415662(this).GetEnumerator();
	}

	protected override void startInitialState()
	{
		object obj = null;
		object obj2 = obj;
		if (!(obj2 is Exec))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Exec));
		}
		dtrace((Exec)obj2, "LotterySequence.boo:91", "go命令 " + CurrentStateName + "->" + "S540_init" + "(" + string.Empty + ")");
		Exec e = createExecAsCurrent("S540_init");
		IEnumerator r = S540_init();
		entryCoroutine(e, r);
	}

	public IEnumerator S540_Home()
	{
		return new _0024S540_Home_002415681(this).GetEnumerator();
	}

	public IEnumerator S540_Home(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_Home_002415687(this).GetEnumerator();
	}

	public IEnumerator S540_GoStoneGacha(bool eventFlag)
	{
		return new _0024S540_GoStoneGacha_002415759(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_GoStoneGacha(bool eventFlag, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_GoStoneGacha";
		Exec e = lastCreatedExec;
		dtrace(e, "LotterySequence.boo:211", "go命令 " + CurrentStateName + "->" + "S540_FayStoneLottery" + "(" + "eventFlag" + ")");
		Exec e2 = createExecAsCurrent("S540_FayStoneLottery");
		IEnumerator r = S540_FayStoneLottery(eventFlag);
		entryCoroutine(e2, r);
		stop(e);
		return null;
	}

	public IEnumerator S540_FayStoneLottery(bool eventFlag)
	{
		return new _0024S540_FayStoneLottery_002415767(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_FayStoneLottery(bool eventFlag, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_FayStoneLottery_002415775(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_RaidPointLottery(bool eventFlag)
	{
		return new _0024S540_RaidPointLottery_002415835(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_RaidPointLottery(bool eventFlag, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_RaidPointLottery_002415843(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_FriendPointLottery(bool eventFlag)
	{
		return new _0024S540_FriendPointLottery_002415899(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_FriendPointLottery(bool eventFlag, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_FriendPointLottery_002415907(eventFlag, this).GetEnumerator();
	}

	public IEnumerator S540_WebInfo(string back)
	{
		return new _0024S540_WebInfo_002415961(back, this).GetEnumerator();
	}

	public IEnumerator S540_WebInfo(string back, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WebInfo_002415969(back, this).GetEnumerator();
	}

	public IEnumerator S540_LotterySingle()
	{
		return new _0024S540_LotterySingle_002415996(this).GetEnumerator();
	}

	public IEnumerator S540_LotterySingle(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_LotterySingle_002416002(this).GetEnumerator();
	}

	public IEnumerator S540_LotteryMulti()
	{
		return new _0024S540_LotteryMulti_002416114(this).GetEnumerator();
	}

	public IEnumerator S540_LotteryMulti(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_LotteryMulti_002416120(this).GetEnumerator();
	}

	public IEnumerator S540_End()
	{
		return new _0024S540_End_002416234(this).GetEnumerator();
	}

	public IEnumerator S540_End(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_End_002416240(this).GetEnumerator();
	}

	public IEnumerator S540_PanelIn()
	{
		return new _0024S540_PanelIn_002416254(this).GetEnumerator();
	}

	public IEnumerator S540_PanelIn(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_PanelIn";
		Exec e = lastCreatedExec;
		pnlIn = true;
		bool flag = true;
		bool flag2 = true;
		alpTgt = 1f;
		alpTgt_t = 1f;
		alpTgt_b = 1f;
		hokan = true;
		SceneTitleHUD.SetActive(flag);
		ButtonBackHUD.SetActive(flag2);
		PlayerParameter.SetActive(flag);
		InfomationBarHUD.SetActive(flag);
		stop(e);
		return null;
	}

	public IEnumerator S540_BackIn()
	{
		return new _0024S540_BackIn_002416260(this).GetEnumerator();
	}

	public IEnumerator S540_BackIn(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_BackIn";
		Exec e = lastCreatedExec;
		bool flag = true;
		alpTgt_b = 1f;
		hokan = true;
		ButtonBackHUD.SetActive(flag);
		stop(e);
		return null;
	}

	public IEnumerator S540_PanelExit()
	{
		return new _0024S540_PanelExit_002416266(this).GetEnumerator();
	}

	public IEnumerator S540_PanelExit(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_PanelExit_002416272(this).GetEnumerator();
	}

	public IEnumerator S540_TitleExit()
	{
		return new _0024S540_TitleExit_002416277(this).GetEnumerator();
	}

	public IEnumerator S540_TitleExit(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_TitleExit";
		Exec e = lastCreatedExec;
		pnlIn = false;
		bool flag = false;
		bool flag2 = false;
		alpTgt = 0f;
		alpTgt_t = 0f;
		alpTgt_b = 0f;
		hokanRate = 0f;
		hokanRate_t = 0f;
		hokanRate_b = 0f;
		hokan = true;
		SceneTitleHUD.SetActive(flag);
		ButtonBackHUD.SetActive(flag2);
		PlayerParameter.SetActive(flag);
		InfomationBarHUD.SetActive(flag);
		stop(e);
		return null;
	}

	public IEnumerator S540_Selif(string msg, float x, float y, float rot)
	{
		return new _0024S540_Selif_002416283(msg, x, y, rot, this).GetEnumerator();
	}

	public IEnumerator S540_Selif(string msg, float x, float y, float rot, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_Selif_002416297(msg, x, y, rot, this).GetEnumerator();
	}

	public IEnumerator S540_SelifHide()
	{
		return new _0024S540_SelifHide_002416314(this).GetEnumerator();
	}

	public IEnumerator S540_SelifHide(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_SelifHide_002416320(this).GetEnumerator();
	}

	public IEnumerator S540_FadeOut()
	{
		return new _0024S540_FadeOut_002416325(this).GetEnumerator();
	}

	public IEnumerator S540_FadeOut(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_FadeOut_002416331(this).GetEnumerator();
	}

	public IEnumerator S540_FadeIn()
	{
		return new _0024S540_FadeIn_002416336(this).GetEnumerator();
	}

	public IEnumerator S540_FadeIn(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_FadeIn_002416342(this).GetEnumerator();
	}

	public IEnumerator S540_WhiteOut()
	{
		return new _0024S540_WhiteOut_002416347(this).GetEnumerator();
	}

	public IEnumerator S540_WhiteOut(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WhiteOut_002416353(this).GetEnumerator();
	}

	public IEnumerator S540_WhiteIn()
	{
		return new _0024S540_WhiteIn_002416358(this).GetEnumerator();
	}

	public IEnumerator S540_WhiteIn(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WhiteIn_002416364(this).GetEnumerator();
	}

	public IEnumerator S540_WaitButton(string msg0, string msg1, string msg2, string msg3)
	{
		return new _0024S540_WaitButton_002416369(msg0, msg1, msg2, msg3, this).GetEnumerator();
	}

	public IEnumerator S540_WaitButton(string msg0, string msg1, string msg2, string msg3, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WaitButton_002416383(msg0, msg1, msg2, msg3, this).GetEnumerator();
	}

	public IEnumerator S540_WaitButtons(string[] msgs)
	{
		return new _0024S540_WaitButtons_002416396(msgs, this).GetEnumerator();
	}

	public IEnumerator S540_WaitButtons(string[] msgs, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WaitButtons_002416404(msgs, this).GetEnumerator();
	}

	public IEnumerator S540_WaitSec(float t)
	{
		return new _0024S540_WaitSec_002416417(t, this).GetEnumerator();
	}

	public IEnumerator S540_WaitSec(float t, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_WaitSec_002416425(t, this).GetEnumerator();
	}

	public IEnumerator S540_Prize()
	{
		return new _0024S540_Prize_002416432(this).GetEnumerator();
	}

	public IEnumerator S540_Prize(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_Prize_002416438(this).GetEnumerator();
	}

	public IEnumerator S540_LoadBagTaxture(string urlTamplate)
	{
		return new _0024S540_LoadBagTaxture_002416443(urlTamplate, this).GetEnumerator();
	}

	public IEnumerator S540_LoadBagTaxture(string urlTamplate, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_LoadBagTaxture";
		Exec e = lastCreatedExec;
		MerlinServer.Busy = true;
		bagTexture.Clear();
		DateTime utcNow = MerlinDateTime.UtcNow;
		int i = 0;
		MSaleGachas[] all = MSaleGachas.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (!(utcNow < all[i].StartDate) && (!(all[i].EndDate < utcNow) || (int)all[i].EndDate.Ticks == 0))
			{
				string file = UIBasicUtility.SafeFormat(urlTamplate, all[i].Id);
				LoadResource(file, new _0024S540_LoadBagTaxture_0024closure_00242955(i, this, all).Invoke);
			}
		}
		MerlinServer.Busy = false;
		stop(e);
		return null;
	}

	public IEnumerator S540_LoadFpBannerTaxture(string urlTamplate)
	{
		return new _0024S540_LoadFpBannerTaxture_002416451(urlTamplate, this).GetEnumerator();
	}

	public IEnumerator S540_LoadFpBannerTaxture(string urlTamplate, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_LoadFpBannerTaxture_002416459(urlTamplate, this).GetEnumerator();
	}

	public IEnumerator S540_LoadBannerHtml(string urlTamplate)
	{
		return new _0024S540_LoadBannerHtml_002416473(urlTamplate, this).GetEnumerator();
	}

	public IEnumerator S540_LoadBannerHtml(string urlTamplate, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_LoadBannerHtml_002416481(urlTamplate, this).GetEnumerator();
	}

	public IEnumerator S540_NewItemPrizeDemo()
	{
		return new _0024S540_NewItemPrizeDemo_002416495(this).GetEnumerator();
	}

	public IEnumerator S540_NewItemPrizeDemo(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_NewItemPrizeDemo_002416501(this).GetEnumerator();
	}

	public IEnumerator S540_HideWebView()
	{
		return new _0024S540_HideWebView_002416508(this).GetEnumerator();
	}

	public IEnumerator S540_HideWebView(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_HideWebView";
		Exec e = lastCreatedExec;
		WebViewBase.Visible(flag: false);
		stop(e);
		return null;
	}

	private void SetFormat(UILabelBase label, string v)
	{
		if ((bool)label)
		{
			string text = label.text;
			if (labelFormatCacheDictionary.ContainsKey(label))
			{
				text = labelFormatCacheDictionary[label];
			}
			else
			{
				labelFormatCacheDictionary[label] = text;
			}
			label.text = UIBasicUtility.SafeFormat(text, v);
		}
	}

	public IEnumerator S540_ExecuteStoneList(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd)
	{
		return new _0024S540_ExecuteStoneList_002416514(onEnd, this).GetEnumerator();
	}

	public IEnumerator S540_ExecuteStoneList(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_ExecuteStoneList_002416522(onEnd, this).GetEnumerator();
	}

	public IEnumerator S540_BoxCheck()
	{
		return new _0024S540_BoxCheck_002416542(this).GetEnumerator();
	}

	public IEnumerator S540_BoxCheck(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_BoxCheck_002416548(this).GetEnumerator();
	}

	public override void PushBack()
	{
		if (!hokan && !endFlag && !MerlinServer.Instance.IsBusy)
		{
			if ((bool)stoneList && (bool)stoneList.gameObject && stoneList.gameObject.activeSelf)
			{
				S540_Home();
				stoneList.Close();
				stoneList.PushCancel();
			}
			else
			{
				base.PushBack();
			}
		}
	}

	public override void EndLottery()
	{
		if (!endFlag)
		{
			endFlag = true;
			if (plyrCtrl != null)
			{
				plyrCtrl.Pause = false;
			}
			WebViewBase.EndWebView();
			townModule.BackTown();
		}
	}

	public void SendLottery(int type, int num)
	{
		UnloadResource.UnloadUnusedAssets();
		object obj = UserData.Current.userMiscInfo.weaponBookData.Flags.Clone();
		if (!(obj is Hashtable))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
		}
		lastWeaponPicBookFlags = (Hashtable)obj;
		object obj2 = UserData.Current.userMiscInfo.poppetBookData.Flags.Clone();
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		lastPoppetPicBookFlags = (Hashtable)obj2;
		ApiGachaExec apiGachaExec = new ApiGachaExec();
		apiGachaExec.GachaId = type;
		apiGachaExec.Turn = num;
		apiGachaExec.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			EndLottery();
		});
		endSendLottery = false;
		checked
		{
			gachaCount++;
			MerlinServer.Request(apiGachaExec, _0024adaptor_0024__LotterySequence_SendLottery_0024callable498_00241001_36___0024__MerlinServer_Request_0024callable86_0024160_56___0024114.Adapt(base.CallBackLottery2));
		}
	}

	internal void _0024SendLottery_0024closure_00242978()
	{
		EndLottery();
	}
}
