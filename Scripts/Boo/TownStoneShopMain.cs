using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class TownStoneShopMain : TownShopTopMain
{
	[Serializable]
	public enum STONE_SHOP_MODE
	{
		None = -1,
		ShopMenu,
		BuyList,
		CureStart,
		CureEnd,
		CureStartMP,
		CureEndMP,
		BoxExtendStart,
		BoxExtendEnd,
		BuyInformation,
		ExchangeManaPiece,
		DetailWeapon,
		DetailPoppet,
		CureStartBP,
		CureEndBP
	}

	[Serializable]
	internal class _0024PushCureYes_0024locals_002414539
	{
		internal ApiUpdateActionPoint _0024req;
	}

	[Serializable]
	internal class _0024PushCureYesMP_0024locals_002414540
	{
		internal ApiUpdateRaidPoint _0024req;
	}

	[Serializable]
	internal class _0024PushCureYesBP_0024locals_002414541
	{
		internal ApiPlayerUpdateBattlePoint _0024req;
	}

	[Serializable]
	internal class _0024PushBoxExtendYes_0024locals_002414542
	{
		internal UserData _0024ud;
	}

	[Serializable]
	internal class _0024PushExchange_0024locals_002414543
	{
		internal RespShopItem _0024item;

		internal UserData _0024ud;
	}

	[Serializable]
	internal class _0024OpenOKDialog_0024locals_002414544
	{
		internal bool _0024dlgEnd;

		internal Dialog _0024dialog;

		internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024func;
	}

	[Serializable]
	internal class _0024OpenDialogYesNo_0024locals_002414545
	{
		internal bool _0024dlgEnd;

		internal Dialog _0024dialog;

		internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024func;
	}

	[Serializable]
	internal class _0024PushCureYes_0024coroutine_00245113
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421986 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024PushCureYes_0024coroutine_00245113 _0024self__002421987;

				public _0024(_0024PushCureYes_0024coroutine_00245113 self_)
				{
					_0024self__002421987 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002421987._0024_0024locals_002415201._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal _0024PushCureYes_0024coroutine_00245113 _0024self__002421988;

			public _0024Invoke_002421986(_0024PushCureYes_0024coroutine_00245113 self_)
			{
				_0024self__002421988 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421988);
			}
		}

		internal _0024PushCureYes_0024locals_002414539 _0024_0024locals_002415201;

		public _0024PushCureYes_0024coroutine_00245113(_0024PushCureYes_0024locals_002414539 _0024_0024locals_002415201)
		{
			this._0024_0024locals_002415201 = _0024_0024locals_002415201;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421986(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024PushCureYesMP_0024coroutine_00245115
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421989 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024PushCureYesMP_0024coroutine_00245115 _0024self__002421990;

				public _0024(_0024PushCureYesMP_0024coroutine_00245115 self_)
				{
					_0024self__002421990 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002421990._0024_0024locals_002415202._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal _0024PushCureYesMP_0024coroutine_00245115 _0024self__002421991;

			public _0024Invoke_002421989(_0024PushCureYesMP_0024coroutine_00245115 self_)
			{
				_0024self__002421991 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421991);
			}
		}

		internal _0024PushCureYesMP_0024locals_002414540 _0024_0024locals_002415202;

		public _0024PushCureYesMP_0024coroutine_00245115(_0024PushCureYesMP_0024locals_002414540 _0024_0024locals_002415202)
		{
			this._0024_0024locals_002415202 = _0024_0024locals_002415202;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421989(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024PushCureYesBP_0024coroutine_00245117
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421992 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024PushCureYesBP_0024coroutine_00245117 _0024self__002421993;

				public _0024(_0024PushCureYesBP_0024coroutine_00245117 self_)
				{
					_0024self__002421993 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002421993._0024_0024locals_002415203._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal _0024PushCureYesBP_0024coroutine_00245117 _0024self__002421994;

			public _0024Invoke_002421992(_0024PushCureYesBP_0024coroutine_00245117 self_)
			{
				_0024self__002421994 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421994);
			}
		}

		internal _0024PushCureYesBP_0024locals_002414541 _0024_0024locals_002415203;

		public _0024PushCureYesBP_0024coroutine_00245117(_0024PushCureYesBP_0024locals_002414541 _0024_0024locals_002415203)
		{
			this._0024_0024locals_002415203 = _0024_0024locals_002415203;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421992(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024PushBoxExtendYes_0024closure_00245118
	{
		internal _0024PushBoxExtendYes_0024locals_002414542 _0024_0024locals_002415204;

		internal TownStoneShopMain _0024this_002415205;

		public _0024PushBoxExtendYes_0024closure_00245118(_0024PushBoxExtendYes_0024locals_002414542 _0024_0024locals_002415204, TownStoneShopMain _0024this_002415205)
		{
			this._0024_0024locals_002415204 = _0024_0024locals_002415204;
			this._0024this_002415205 = _0024this_002415205;
		}

		public void Invoke(RequestBase r)
		{
			GameApiResponseBase gameApiResponseBase = r.ResponseObj as GameApiResponseBase;
			if (gameApiResponseBase.StatusCode == "BoExt002")
			{
				_0024this_002415205.OpenOKDialog(MTexts.Format("$SS_BOX_MAX", _0024_0024locals_002415204._0024ud.userStatus.BoxExtensionCount, _0024_0024locals_002415204._0024ud.BoxExtendLimit), MTexts.Msg("$SS_BOX_MAX_TITLE"), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__GouseiSequense_S540_init_0024callable40_002410_5___0024209.Adapt(delegate
				{
					_0024this_002415205.mode = STONE_SHOP_MODE.ShopMenu;
				}));
			}
		}
	}

	[Serializable]
	internal class _0024PushBoxExtendYes_0024closure_00245120
	{
		internal TownStoneShopMain _0024this_002415206;

		internal _0024PushBoxExtendYes_0024locals_002414542 _0024_0024locals_002415207;

		public _0024PushBoxExtendYes_0024closure_00245120(TownStoneShopMain _0024this_002415206, _0024PushBoxExtendYes_0024locals_002414542 _0024_0024locals_002415207)
		{
			this._0024this_002415206 = _0024this_002415206;
			this._0024_0024locals_002415207 = _0024_0024locals_002415207;
		}

		public void Invoke(ApiBoxExtension r)
		{
			if (r.IsOk)
			{
				UIBasicUtility.SetLabel(_0024this_002415206.boxNewSizeLabel, _0024_0024locals_002415207._0024ud.BoxCapacity.ToString());
				UIBasicUtility.SetLabel(_0024this_002415206.limitNewSizeLabel, _0024_0024locals_002415207._0024ud.userStatus.BoxExtensionCount.ToString());
				UIBasicUtility.SetLabel(_0024this_002415206.limitNewMaxSizeLabel, _0024_0024locals_002415207._0024ud.BoxExtendLimit.ToString());
				_0024this_002415206.mode = STONE_SHOP_MODE.BoxExtendEnd;
			}
		}
	}

	[Serializable]
	internal class _0024PushExchange_0024closure_00245122
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421995 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal ApiShopPurchase _0024req_002421996;

				internal ApiPresent _0024req2_002421997;

				internal _0024PushExchange_0024closure_00245122 _0024self__002421998;

				public _0024(_0024PushExchange_0024closure_00245122 self_)
				{
					_0024self__002421998 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						MerlinServer.Busy = true;
						_0024req_002421996 = new ApiShopPurchase();
						_0024req_002421996.Id = _0024self__002421998._0024_0024locals_002415208._0024item.Id;
						MerlinServer.Request(_0024req_002421996);
						goto case 2;
					case 2:
						if (!_0024req_002421996.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024req2_002421997 = new ApiPresent();
						MerlinServer.Request(_0024req2_002421997);
						goto case 3;
					case 3:
						if (!_0024req2_002421997.IsEnd)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						MerlinServer.Busy = false;
						_0024self__002421998._0024_0024locals_002415208._0024ud = UserData.Current;
						if (_0024self__002421998._0024_0024locals_002415208._0024ud == null)
						{
							throw new AssertionFailedException("ud");
						}
						_0024self__002421998._0024_0024locals_002415208._0024ud.userMiscInfo.flagData.updateCondition();
						UIBasicUtility.SetLabel(_0024self__002421998._0024this_002415209.manaPeiceLabel, UIBasicUtility.SafeFormat("{0:N0}", _0024self__002421998._0024_0024locals_002415208._0024ud.userStatus.ManaFragment));
						_0024self__002421998._0024this_002415209.OpenOKDialog("アイテムを受信箱に送りました。", string.Empty);
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024PushExchange_0024closure_00245122 _0024self__002421999;

			public _0024Invoke_002421995(_0024PushExchange_0024closure_00245122 self_)
			{
				_0024self__002421999 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421999);
			}
		}

		internal _0024PushExchange_0024locals_002414543 _0024_0024locals_002415208;

		internal TownStoneShopMain _0024this_002415209;

		public _0024PushExchange_0024closure_00245122(_0024PushExchange_0024locals_002414543 _0024_0024locals_002415208, TownStoneShopMain _0024this_002415209)
		{
			this._0024_0024locals_002415208 = _0024_0024locals_002415208;
			this._0024this_002415209 = _0024this_002415209;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421995(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024OpenOKDialog_0024closure_00245106
	{
		internal _0024OpenOKDialog_0024locals_002414544 _0024_0024locals_002415210;

		internal TownStoneShopMain _0024this_002415211;

		public _0024OpenOKDialog_0024closure_00245106(_0024OpenOKDialog_0024locals_002414544 _0024_0024locals_002415210, TownStoneShopMain _0024this_002415211)
		{
			this._0024_0024locals_002415210 = _0024_0024locals_002415210;
			this._0024this_002415211 = _0024this_002415211;
		}

		public void Invoke(int btn)
		{
			if (btn == 1)
			{
				ModalCollider.SetActive(_0024this_002415211, active: false);
				if (_0024_0024locals_002415210._0024func != null)
				{
					IEnumerator enumerator = _0024_0024locals_002415210._0024func();
					if (enumerator != null)
					{
						_0024this_002415211.StartCoroutine(enumerator);
					}
				}
			}
			else
			{
				_0024this_002415211.dlgMan.OnButton(0);
			}
			_0024_0024locals_002415210._0024dlgEnd = true;
		}
	}

	[Serializable]
	internal class _0024OpenOKDialog_0024closure_00245107
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422000 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal STONE_SHOP_MODE _0024curMode_002422001;

				internal _0024OpenOKDialog_0024closure_00245107 _0024self__002422002;

				public _0024(STONE_SHOP_MODE curMode, _0024OpenOKDialog_0024closure_00245107 self_)
				{
					_0024curMode_002422001 = curMode;
					_0024self__002422002 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002422002._0024_0024locals_002415212._0024dlgEnd)
						{
							if (_0024curMode_002422001 != _0024self__002422002._0024this_002415213.mode)
							{
								_0024self__002422002._0024_0024locals_002415212._0024dialog.Close();
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal STONE_SHOP_MODE _0024curMode_002422003;

			internal _0024OpenOKDialog_0024closure_00245107 _0024self__002422004;

			public _0024Invoke_002422000(STONE_SHOP_MODE curMode, _0024OpenOKDialog_0024closure_00245107 self_)
			{
				_0024curMode_002422003 = curMode;
				_0024self__002422004 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024curMode_002422003, _0024self__002422004);
			}
		}

		internal _0024OpenOKDialog_0024locals_002414544 _0024_0024locals_002415212;

		internal TownStoneShopMain _0024this_002415213;

		public _0024OpenOKDialog_0024closure_00245107(_0024OpenOKDialog_0024locals_002414544 _0024_0024locals_002415212, TownStoneShopMain _0024this_002415213)
		{
			this._0024_0024locals_002415212 = _0024_0024locals_002415212;
			this._0024this_002415213 = _0024this_002415213;
		}

		public IEnumerator Invoke(STONE_SHOP_MODE curMode)
		{
			return new _0024Invoke_002422000(curMode, this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024OpenDialogYesNo_0024closure_00245110
	{
		internal TownStoneShopMain _0024this_002415214;

		internal _0024OpenDialogYesNo_0024locals_002414545 _0024_0024locals_002415215;

		public _0024OpenDialogYesNo_0024closure_00245110(TownStoneShopMain _0024this_002415214, _0024OpenDialogYesNo_0024locals_002414545 _0024_0024locals_002415215)
		{
			this._0024this_002415214 = _0024this_002415214;
			this._0024_0024locals_002415215 = _0024_0024locals_002415215;
		}

		public void Invoke(int btn)
		{
			ModalCollider.SetActive(_0024this_002415214, active: false);
			if (btn == 2 && _0024_0024locals_002415215._0024func != null)
			{
				IEnumerator enumerator = _0024_0024locals_002415215._0024func();
				if (enumerator != null)
				{
					_0024this_002415214.StartCoroutine(enumerator);
				}
			}
			_0024this_002415214.dlgMan.OnButton(0);
			_0024_0024locals_002415215._0024dlgEnd = true;
		}
	}

	[Serializable]
	internal class _0024OpenDialogYesNo_0024closure_00245111
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422005 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal STONE_SHOP_MODE _0024curMode_002422006;

				internal _0024OpenDialogYesNo_0024closure_00245111 _0024self__002422007;

				public _0024(STONE_SHOP_MODE curMode, _0024OpenDialogYesNo_0024closure_00245111 self_)
				{
					_0024curMode_002422006 = curMode;
					_0024self__002422007 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002422007._0024_0024locals_002415216._0024dlgEnd)
						{
							if (_0024curMode_002422006 != _0024self__002422007._0024this_002415217.mode)
							{
								_0024self__002422007._0024_0024locals_002415216._0024dialog.Close();
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal STONE_SHOP_MODE _0024curMode_002422008;

			internal _0024OpenDialogYesNo_0024closure_00245111 _0024self__002422009;

			public _0024Invoke_002422005(STONE_SHOP_MODE curMode, _0024OpenDialogYesNo_0024closure_00245111 self_)
			{
				_0024curMode_002422008 = curMode;
				_0024self__002422009 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024curMode_002422008, _0024self__002422009);
			}
		}

		internal _0024OpenDialogYesNo_0024locals_002414545 _0024_0024locals_002415216;

		internal TownStoneShopMain _0024this_002415217;

		public _0024OpenDialogYesNo_0024closure_00245111(_0024OpenDialogYesNo_0024locals_002414545 _0024_0024locals_002415216, TownStoneShopMain _0024this_002415217)
		{
			this._0024_0024locals_002415216 = _0024_0024locals_002415216;
			this._0024this_002415217 = _0024this_002415217;
		}

		public IEnumerator Invoke(STONE_SHOP_MODE curMode)
		{
			return new _0024Invoke_002422005(curMode, this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetManaPieceList_002421975 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespShopItem[] _0024shopItems_002421976;

			internal ApiShop _0024req_002421977;

			internal TownStoneShopMain _0024self__002421978;

			public _0024(TownStoneShopMain self_)
			{
				_0024self__002421978 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					MerlinServer.Busy = true;
					_0024shopItems_002421976 = new RespShopItem[0];
					_0024req_002421977 = new ApiShop();
					MerlinServer.Request(_0024req_002421977);
					goto case 2;
				case 2:
					if (!_0024req_002421977.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024shopItems_002421976 = _0024req_002421977.GetResponse().ShopItemLists;
					if ((bool)_0024self__002421978.manaPieceList)
					{
						_0024self__002421978.manaPieceList.SetResponse(_0024shopItems_002421976, _0024self__002421978.gameObject);
					}
					MerlinServer.Busy = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TownStoneShopMain _0024self__002421979;

		public _0024SetManaPieceList_002421975(TownStoneShopMain self_)
		{
			_0024self__002421979 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421979);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024PushBuyList_0024c_00245108_002421980 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal TownStoneShopMain _0024self__002421981;

			public _0024(TownStoneShopMain self_)
			{
				_0024self__002421981 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002421981.IsChangingSituation)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024self__002421981.IsChangingSituation)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024self__002421981.IsEnableButton())
					{
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TownStoneShopMain _0024self__002421982;

		public _0024_0024PushBuyList_0024c_00245108_002421980(TownStoneShopMain self_)
		{
			_0024self__002421982 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421982);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024OpenDialogForPurchaseeStone_0024closure_00245109_002421983 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal TownStoneShopMain _0024self__002421984;

			public _0024(TownStoneShopMain self_)
			{
				_0024self__002421984 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (DialogManager.DialogCount > 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421984.PushBuyList(null);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TownStoneShopMain _0024self__002421985;

		public _0024_0024OpenDialogForPurchaseeStone_0024closure_00245109_002421983(TownStoneShopMain self_)
		{
			_0024self__002421985 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421985);
		}
	}

	public int count;

	public GameObject shopMenu;

	public GameObject buyList;

	public GameObject cureStart;

	public GameObject cureEnd;

	public GameObject cureStartMP;

	public GameObject cureEndMP;

	public GameObject boxExtendStart;

	public GameObject boxExtendEnd;

	public UILabelBase boxSizeLabel;

	public UILabelBase boxAfterSizeLabel;

	public UILabelBase boxNewSizeLabel;

	public UILabelBase limitSizeLabel;

	public UILabelBase limitAfterSizeLabel;

	public UILabelBase limitMaxSizeLabel;

	public UILabelBase limitNewSizeLabel;

	public UILabelBase limitNewMaxSizeLabel;

	public StoneList stoneList;

	public UIButtonMessage stoneButton;

	public UIButtonMessage apButton;

	public UIButtonMessage rpButton;

	public UIButtonMessage boxButton;

	public ManaPieceList manaPieceList;

	public UILabelBase manaPeiceLabel;

	private STONE_SHOP_MODE mode;

	private STONE_SHOP_MODE lastMode;

	private DialogManager dlgMan;

	private UILabelBase topSelif;

	public WeaponInfo weaponDetail;

	public MuppetInfo poppetDetail;

	public bool IsEnableButton()
	{
		return SceneChanger.isCompletelyReady && !IsChangingSituation && 1 > DialogManager.DialogCount && !MerlinServer.Busy;
	}

	public override void StartCore()
	{
		UIAutoTweenerStandAloneEx.Hide(weaponDetail.gameObject);
		UIAutoTweenerStandAloneEx.Hide(poppetDetail.gameObject);
		SceneTitleHUD.UpdateTitle(MTexts.Msg("$SS_STONE_SHOP_TITLE"));
		dlgMan = DialogManager.Instance;
		MerlinServer.Busy = true;
		if ((bool)stoneList)
		{
			stoneList.Download();
		}
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			InitializeStoneShop();
		});
	}

	public void InitializeStoneShop()
	{
		initFlag = true;
		count = 0;
		lastMode = STONE_SHOP_MODE.None;
		mode = STONE_SHOP_MODE.ShopMenu;
		UISituation situation = GetSituation(0);
		if (!(situation != null) || !(situation.gameObject != null))
		{
			throw new AssertionFailedException("(topSituation != null) and (topSituation.gameObject != null)");
		}
		GameObject gameObject = ExtensionsModule.FindChild(situation.gameObject, "Selif Text");
		topSelif = gameObject.GetComponent<UILabelBase>();
		MerlinServer.Busy = false;
		IEnumerator enumerator = SetManaPieceList();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	protected IEnumerator SetManaPieceList()
	{
		return new _0024SetManaPieceList_002421975(this).GetEnumerator();
	}

	public override void SceneUpdate()
	{
		if (!SceneChanger.isCompletelyReady || IsChangingSituation)
		{
			return;
		}
		checked
		{
			count++;
			if (!initFlag || mode == lastMode)
			{
				return;
			}
			STONE_SHOP_MODE sTONE_SHOP_MODE = lastMode;
			lastMode = mode;
			if (mode == STONE_SHOP_MODE.ShopMenu)
			{
				UpdateTopSelif();
			}
			else if (mode == STONE_SHOP_MODE.BoxExtendStart)
			{
				UserData current = UserData.Current;
				UIBasicUtility.SetLabel(boxSizeLabel, current.BoxCapacity.ToString());
				UIBasicUtility.SetLabel(boxAfterSizeLabel, (current.BoxCapacity + 5).ToString());
				UIBasicUtility.SetLabel(limitSizeLabel, current.userStatus.BoxExtensionCount.ToString());
				UIBasicUtility.SetLabel(limitAfterSizeLabel, (current.userStatus.BoxExtensionCount + 1).ToString());
				UIBasicUtility.SetLabel(limitMaxSizeLabel, current.BoxExtendLimit.ToString());
				string text = string.Empty;
				if (sTONE_SHOP_MODE == STONE_SHOP_MODE.ShopMenu)
				{
					text = MTexts.Msg("$SS_BOX_MAX_TITLE");
				}
				if (current.BoxExtendLimit <= current.userStatus.BoxExtensionCount)
				{
					OpenOKDialog(MTexts.Format("$SS_BOX_MAX", current.userStatus.BoxExtensionCount, current.BoxExtendLimit), text, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__GouseiSequense_S540_init_0024callable40_002410_5___0024209.Adapt(delegate
					{
						mode = STONE_SHOP_MODE.ShopMenu;
					}));
					return;
				}
			}
			else if (mode == STONE_SHOP_MODE.ExchangeManaPiece)
			{
				UserData current = UserData.Current;
				if (current == null)
				{
					throw new AssertionFailedException("ud");
				}
				UIBasicUtility.SetLabel(manaPeiceLabel, UIBasicUtility.SafeFormat("{0:N0}", current.userStatus.ManaFragment));
			}
		}
		ChangeSituation(GetSituation((int)mode));
	}

	public void UpdateTopSelif()
	{
		UserData current = UserData.Current;
		string text = null;
		if (current.FayStone == 0)
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopStone0);
		}
		if (string.IsNullOrEmpty(text) && InventoryOverDialog.IsInventoryOver())
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopBoxFull);
		}
		if (string.IsNullOrEmpty(text) && current.Ap < 5)
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopAp0);
		}
		if (string.IsNullOrEmpty(text) && current.Rp == 0)
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopRp0);
		}
		if (string.IsNullOrEmpty(text) && current.Bp == 0)
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopBp0);
		}
		if (string.IsNullOrEmpty(text))
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.StoneShopNormal);
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new AssertionFailedException("精霊石ショップ店員のメッセージが無い");
		}
		topSelif.text = text;
	}

	public void PushShopMenu(GameObject obj)
	{
		if (IsEnableButton())
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
	}

	public void PushBuyList(GameObject obj)
	{
		if (IsEnableButton())
		{
			mode = STONE_SHOP_MODE.BuyList;
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024PushBuyList_0024c_00245108_002421980(this).GetEnumerator();
			StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		}
	}

	public void PushCureStart(GameObject obj)
	{
		if (IsEnableButton())
		{
			UserData current = UserData.Current;
			if (current.Ap >= current.MaxAp)
			{
				OpenOKDialog(MTexts.Msg("$SS_AP_FULL"), string.Empty);
			}
			else if (current.FayStone == 0)
			{
				OpenDialogForPurchaseeStone(MTexts.Msg("$SS_AP_NO_STONE"), MTexts.Msg("$SS_AP_NO_STONE_TITLE"));
			}
			else
			{
				mode = STONE_SHOP_MODE.CureStart;
			}
		}
	}

	public void PushCureYes(GameObject obj)
	{
		_0024PushCureYes_0024locals_002414539 _0024PushCureYes_0024locals_0024 = new _0024PushCureYes_0024locals_002414539();
		if (IsEnableButton())
		{
			_0024PushCureYes_0024locals_0024._0024req = new ApiUpdateActionPoint();
			MerlinServer.Request(_0024PushCureYes_0024locals_0024._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = STONE_SHOP_MODE.CureEnd;
				ApRpExp.CureApRp();
			}));
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PushCureYes_0024coroutine_00245113(_0024PushCureYes_0024locals_0024).Invoke;
			StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		}
	}

	public void PushCureStartMP(GameObject obj)
	{
		if (IsEnableButton())
		{
			UserData current = UserData.Current;
			if (current.Rp >= current.MaxRp)
			{
				OpenOKDialog(MTexts.Msg("$SS_RP_FULL"), string.Empty);
			}
			else if (current.FayStone == 0)
			{
				OpenDialogForPurchaseeStone(MTexts.Msg("$SS_RP_NO_STONE"), MTexts.Msg("$SS_RP_NO_STONE_TITLE"));
			}
			else
			{
				mode = STONE_SHOP_MODE.CureStartMP;
			}
		}
	}

	public void PushCureYesMP(GameObject obj)
	{
		_0024PushCureYesMP_0024locals_002414540 _0024PushCureYesMP_0024locals_0024 = new _0024PushCureYesMP_0024locals_002414540();
		if (IsEnableButton())
		{
			_0024PushCureYesMP_0024locals_0024._0024req = new ApiUpdateRaidPoint();
			MerlinServer.Request(_0024PushCureYesMP_0024locals_0024._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = STONE_SHOP_MODE.CureEndMP;
				ApRpExp.CureApRp();
			}));
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PushCureYesMP_0024coroutine_00245115(_0024PushCureYesMP_0024locals_0024).Invoke;
			StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		}
	}

	private void PushCureStartBP(GameObject obj)
	{
		if (IsEnableButton())
		{
			UserData current = UserData.Current;
			if (current.Bp >= current.MaxBp)
			{
				OpenOKDialog(MTexts.Msg("$SS_BP_FULL"), string.Empty);
			}
			else if (current.FayStone == 0)
			{
				OpenDialogForPurchaseeStone(MTexts.Msg("$SS_BP_NO_STONE"), MTexts.Msg("$SS_BP_NO_STONE_TITLE"));
			}
			else
			{
				mode = STONE_SHOP_MODE.CureStartBP;
			}
		}
	}

	private void PushCureYesBP(GameObject obj)
	{
		_0024PushCureYesBP_0024locals_002414541 _0024PushCureYesBP_0024locals_0024 = new _0024PushCureYesBP_0024locals_002414541();
		if (IsEnableButton())
		{
			_0024PushCureYesBP_0024locals_0024._0024req = new ApiPlayerUpdateBattlePoint();
			MerlinServer.Request(_0024PushCureYesBP_0024locals_0024._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = STONE_SHOP_MODE.CureEndBP;
				ApRpExp.CureApRp();
			}));
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PushCureYesBP_0024coroutine_00245117(_0024PushCureYesBP_0024locals_0024).Invoke;
			StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		}
	}

	public void PushBoxExtendStart(GameObject obj)
	{
		if (IsEnableButton())
		{
			mode = STONE_SHOP_MODE.BoxExtendStart;
		}
	}

	private bool CheckBoxExtend()
	{
		UserData current = UserData.Current;
		int result;
		if (current.FayStone == 0)
		{
			OpenDialogForPurchaseeStone(MTexts.Msg("$SS_BOX_NO_STONE"), MTexts.Msg("$SS_BOX_NO_STONE_TITLE"));
			result = 0;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public void PushBoxExtendYes(GameObject obj)
	{
		_0024PushBoxExtendYes_0024locals_002414542 _0024PushBoxExtendYes_0024locals_0024 = new _0024PushBoxExtendYes_0024locals_002414542();
		if (IsEnableButton() && CheckBoxExtend())
		{
			_0024PushBoxExtendYes_0024locals_0024._0024ud = UserData.Current;
			ApiBoxExtension apiBoxExtension = new ApiBoxExtension();
			apiBoxExtension.IgnoreErrorCodes = new string[1] { "BoExt002" };
			apiBoxExtension.ErrorHandler = new _0024PushBoxExtendYes_0024closure_00245118(_0024PushBoxExtendYes_0024locals_0024, this).Invoke;
			MerlinServer.Request(apiBoxExtension, _0024adaptor_0024__TownStoneShopMain_PushBoxExtendYes_0024callable606_0024292_29___0024__MerlinServer_Request_0024callable86_0024160_56___0024210.Adapt(new _0024PushBoxExtendYes_0024closure_00245120(this, _0024PushBoxExtendYes_0024locals_0024).Invoke));
		}
	}

	public void PushExchangeManaPiece()
	{
		if (IsEnableButton())
		{
			mode = STONE_SHOP_MODE.ExchangeManaPiece;
		}
	}

	public void PushExchange(GameObject go)
	{
		_0024PushExchange_0024locals_002414543 _0024PushExchange_0024locals_0024 = new _0024PushExchange_0024locals_002414543();
		if (!IsEnableButton() || mode != STONE_SHOP_MODE.ExchangeManaPiece)
		{
			return;
		}
		ManaPieceListItem component = go.transform.parent.GetComponent<ManaPieceListItem>();
		if (null == component)
		{
			return;
		}
		_0024PushExchange_0024locals_0024._0024item = component.GetData<RespShopItem>();
		if (_0024PushExchange_0024locals_0024._0024item != null)
		{
			_0024PushExchange_0024locals_0024._0024ud = UserData.Current;
			if (_0024PushExchange_0024locals_0024._0024ud == null)
			{
				throw new AssertionFailedException("ud");
			}
			int price = _0024PushExchange_0024locals_0024._0024item.Price;
			int manaFragment = _0024PushExchange_0024locals_0024._0024ud.userStatus.ManaFragment;
			__GouseiSequense_S540_init_0024callable40_002410_5__ func = () => (IEnumerator)null;
			if (price > manaFragment)
			{
				OpenOKDialog("マナのかけらが不足しています。", string.Empty, func);
				return;
			}
			__GouseiSequense_S540_init_0024callable40_002410_5__ func2 = new _0024PushExchange_0024closure_00245122(_0024PushExchange_0024locals_0024, this).Invoke;
			OpenDialogYesNo("マナのかけらを交換しますか？", string.Empty, func2);
		}
	}

	public void PushWeb(GameObject obj)
	{
		if (IsEnableButton())
		{
			mode = STONE_SHOP_MODE.BuyInformation;
		}
	}

	public void PushDetail(GameObject obj)
	{
		if (IsEnableButton() && mode != STONE_SHOP_MODE.DetailWeapon && mode != STONE_SHOP_MODE.DetailPoppet)
		{
			WeaponListItem componentInChildren = obj.GetComponentInChildren<WeaponListItem>();
			MapetListItem componentInChildren2 = obj.GetComponentInChildren<MapetListItem>();
			if (null != componentInChildren)
			{
				weaponDetail.SetWeapon(componentInChildren.weaponInfo, ignoreUnknown: true);
				mode = STONE_SHOP_MODE.DetailWeapon;
				UIAutoTweenerStandAloneEx.In(weaponDetail.gameObject);
			}
			else if (null != componentInChildren2)
			{
				poppetDetail.SetMuppet(componentInChildren2.mapetInfo, ignoreUnknown: true);
				mode = STONE_SHOP_MODE.DetailPoppet;
				UIAutoTweenerStandAloneEx.In(poppetDetail.gameObject);
			}
		}
	}

	public void PushBack(GameObject obj)
	{
		if (!IsEnableButton())
		{
			return;
		}
		if (mode == STONE_SHOP_MODE.ShopMenu)
		{
			BackTown();
		}
		else if (mode == STONE_SHOP_MODE.BuyList)
		{
			if (!stoneList.IsBusy && !stoneList.webViewPanel.active)
			{
				mode = STONE_SHOP_MODE.ShopMenu;
			}
		}
		else if (mode == STONE_SHOP_MODE.CureStart)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.CureEnd)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.CureStartMP)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.CureEndMP)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.BoxExtendStart)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.BoxExtendEnd)
		{
			mode = STONE_SHOP_MODE.BoxExtendStart;
		}
		else if (mode == STONE_SHOP_MODE.BuyInformation)
		{
			mode = STONE_SHOP_MODE.BuyList;
		}
		else if (mode == STONE_SHOP_MODE.ExchangeManaPiece)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.DetailWeapon)
		{
			UIAutoTweenerStandAloneEx.Out(weaponDetail.gameObject);
			mode = STONE_SHOP_MODE.ExchangeManaPiece;
		}
		else if (mode == STONE_SHOP_MODE.DetailPoppet)
		{
			UIAutoTweenerStandAloneEx.Out(poppetDetail.gameObject);
			mode = STONE_SHOP_MODE.ExchangeManaPiece;
		}
		else if (mode == STONE_SHOP_MODE.CureStartBP)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
		else if (mode == STONE_SHOP_MODE.CureEndBP)
		{
			mode = STONE_SHOP_MODE.ShopMenu;
		}
	}

	public void CallBackBuy(Hashtable resTab)
	{
		if ((bool)shopMenu)
		{
			shopMenu.SetActive(value: true);
		}
		if ((bool)buyList)
		{
			buyList.SetActive(value: false);
		}
		mode = STONE_SHOP_MODE.ShopMenu;
	}

	private void OpenOKDialog(string msg, string title)
	{
		OpenOKDialog(msg, title, null);
	}

	private void OpenOKDialog(string msg, string title, __GouseiSequense_S540_init_0024callable40_002410_5__ func)
	{
		_0024OpenOKDialog_0024locals_002414544 _0024OpenOKDialog_0024locals_0024 = new _0024OpenOKDialog_0024locals_002414544();
		_0024OpenOKDialog_0024locals_0024._0024func = func;
		ModalCollider.SetActive(this, active: true);
		_0024OpenOKDialog_0024locals_0024._0024dlgEnd = false;
		_0024OpenOKDialog_0024locals_0024._0024dialog = dlgMan.OpenDialog(msg, title, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
		_0024OpenOKDialog_0024locals_0024._0024dialog.ButtonHandler = new _0024OpenOKDialog_0024closure_00245106(_0024OpenOKDialog_0024locals_0024, this).Invoke;
		__TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__ _TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__ = new _0024OpenOKDialog_0024closure_00245107(_0024OpenOKDialog_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__(mode);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void OpenDialogForPurchaseeStone(string msg, string title)
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ func = () => new _0024_0024OpenDialogForPurchaseeStone_0024closure_00245109_002421983(this).GetEnumerator();
		OpenDialogYesNo(msg, title, func);
	}

	private void OpenDialogYesNo(string msg, string title, __GouseiSequense_S540_init_0024callable40_002410_5__ func)
	{
		_0024OpenDialogYesNo_0024locals_002414545 _0024OpenDialogYesNo_0024locals_0024 = new _0024OpenDialogYesNo_0024locals_002414545();
		_0024OpenDialogYesNo_0024locals_0024._0024func = func;
		ModalCollider.SetActive(this, active: true);
		dlgMan.OnButton(0);
		_0024OpenDialogYesNo_0024locals_0024._0024dlgEnd = false;
		_0024OpenDialogYesNo_0024locals_0024._0024dialog = dlgMan.OpenDialog(msg, title, DialogManager.MB_FLAG.MB_NONE, new string[2]
		{
			MTexts.Msg("exp_no"),
			MTexts.Msg("exp_yes")
		});
		_0024OpenDialogYesNo_0024locals_0024._0024dialog.ButtonHandler = new _0024OpenDialogYesNo_0024closure_00245110(this, _0024OpenDialogYesNo_0024locals_0024).Invoke;
		__TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__ _TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__ = new _0024OpenDialogYesNo_0024closure_00245111(_0024OpenDialogYesNo_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _TownStoneShopMain_OpenOKDialog_0024callable188_0024427_21__(mode);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	internal void _0024StartCore_0024closure_00245104()
	{
		InitializeStoneShop();
	}

	internal void _0024SceneUpdate_0024closure_00245105()
	{
		mode = STONE_SHOP_MODE.ShopMenu;
	}

	internal IEnumerator _0024PushBuyList_0024c_00245108()
	{
		return new _0024_0024PushBuyList_0024c_00245108_002421980(this).GetEnumerator();
	}

	internal IEnumerator _0024OpenDialogForPurchaseeStone_0024closure_00245109()
	{
		return new _0024_0024OpenDialogForPurchaseeStone_0024closure_00245109_002421983(this).GetEnumerator();
	}

	internal void _0024PushCureYes_0024closure_00245112()
	{
		mode = STONE_SHOP_MODE.CureEnd;
		ApRpExp.CureApRp();
	}

	internal void _0024PushCureYesMP_0024closure_00245114()
	{
		mode = STONE_SHOP_MODE.CureEndMP;
		ApRpExp.CureApRp();
	}

	internal void _0024PushCureYesBP_0024closure_00245116()
	{
		mode = STONE_SHOP_MODE.CureEndBP;
		ApRpExp.CureApRp();
	}

	internal void _0024_0024PushBoxExtendYes_0024closure_00245118_0024closure_00245119()
	{
		mode = STONE_SHOP_MODE.ShopMenu;
	}

	internal IEnumerator _0024PushExchange_0024closure_00245121()
	{
		return null;
	}
}
