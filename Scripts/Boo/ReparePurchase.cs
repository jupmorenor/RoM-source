using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ReparePurchase : MonoBehaviour
{
	[Serializable]
	internal class _0024RepareCore_0024locals_002414408
	{
		internal bool _0024storeEnable;

		internal bool _0024flag;
	}

	[Serializable]
	internal class _0024RepareCore_0024closure_00243091
	{
		internal _0024RepareCore_0024locals_002414408 _0024_0024locals_002414944;

		public _0024RepareCore_0024closure_00243091(_0024RepareCore_0024locals_002414408 _0024_0024locals_002414944)
		{
			this._0024_0024locals_002414944 = _0024_0024locals_002414944;
		}

		public void Invoke(PurchaseUtil purchase)
		{
			_0024_0024locals_002414944._0024storeEnable = true;
		}
	}

	[Serializable]
	internal class _0024RepareCore_0024closure_00243092
	{
		internal _0024RepareCore_0024locals_002414408 _0024_0024locals_002414945;

		public _0024RepareCore_0024closure_00243092(_0024RepareCore_0024locals_002414408 _0024_0024locals_002414945)
		{
			this._0024_0024locals_002414945 = _0024_0024locals_002414945;
		}

		public void Invoke()
		{
			_0024_0024locals_002414945._0024flag = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RepareCore_002418369 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DateTime _0024timeOut_002418370;

			internal ApiPurchaseProductIdList _0024r_002418371;

			internal ApiPurchaseProductIdList.Resp _0024resp_002418372;

			internal PurchaseUtil.State _0024state_002418373;

			internal string _0024productId_002418374;

			internal string _0024transactionId_002418375;

			internal string _0024receipt_002418376;

			internal string _0024signature_002418377;

			internal DateTime _0024purchaseDate_002418378;

			internal ApiPurchaseVerify _0024req_002418379;

			internal _0024RepareCore_0024locals_002414408 _0024_0024locals_002418380;

			internal bool _0024selfDestroy_002418381;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024callback_002418382;

			internal ReparePurchase _0024self__002418383;

			public _0024(bool selfDestroy, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback, ReparePurchase self_)
			{
				_0024selfDestroy_002418381 = selfDestroy;
				_0024callback_002418382 = callback;
				_0024self__002418383 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418380 = new _0024RepareCore_0024locals_002414408();
					_0024_0024locals_002418380._0024storeEnable = false;
					PurchaseUtil.StartPurchase(new _0024RepareCore_0024closure_00243091(_0024_0024locals_002418380).Invoke);
					_0024timeOut_002418370 = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
					goto case 2;
				case 2:
					if (DateTime.UtcNow < _0024timeOut_002418370 && !_0024_0024locals_002418380._0024storeEnable)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024_0024locals_002418380._0024storeEnable)
					{
						if (_0024callback_002418382 != null)
						{
							_0024callback_002418382(arg0: false);
						}
						goto case 1;
					}
					_0024_0024locals_002418380._0024flag = false;
					_0024r_002418371 = new ApiPurchaseProductIdList();
					MerlinServer.Request(_0024r_002418371, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024RepareCore_0024closure_00243092(_0024_0024locals_002418380).Invoke));
					goto case 3;
				case 3:
					if (!_0024_0024locals_002418380._0024flag)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024resp_002418372 = _0024r_002418371.GetResponse();
					if (!PurchaseUtil.SetProductsList(_0024resp_002418372.ToString(), null))
					{
						if (_0024callback_002418382 != null)
						{
							_0024callback_002418382(arg0: false);
						}
						goto case 1;
					}
					_0024_0024locals_002418380._0024storeEnable = false;
					_0024timeOut_002418370 = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
					goto case 4;
				case 4:
					if (DateTime.UtcNow < _0024timeOut_002418370)
					{
						if (!PurchaseUtil.CheckProductsList())
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						_0024_0024locals_002418380._0024storeEnable = true;
					}
					if (!_0024_0024locals_002418380._0024storeEnable)
					{
						if (_0024callback_002418382 != null)
						{
							_0024callback_002418382(arg0: false);
						}
						goto case 1;
					}
					_0024state_002418373 = PurchaseUtil.State.None;
					_0024productId_002418374 = null;
					_0024transactionId_002418375 = null;
					_0024receipt_002418376 = null;
					_0024signature_002418377 = null;
					_0024purchaseDate_002418378 = default(DateTime);
					goto IL_0243;
				case 5:
					_0024state_002418373 = PurchaseUtil.GetRepareResult(ref _0024productId_002418374, ref _0024transactionId_002418375, ref _0024receipt_002418376, ref _0024signature_002418377, ref _0024purchaseDate_002418378);
					if (_0024state_002418373 != PurchaseUtil.State.Ok)
					{
						goto IL_035a;
					}
					_0024req_002418379 = new ApiPurchaseVerify();
					_0024req_002418379.ProductId = _0024productId_002418374;
					_0024req_002418379.Receipt = _0024receipt_002418376;
					_0024req_002418379.Signature = _0024signature_002418377;
					_0024req_002418379.TransactionId = _0024transactionId_002418375;
					_0024req_002418379.PurchaseDate = _0024purchaseDate_002418378;
					MerlinServer.StealthRequest(_0024req_002418379);
					goto case 6;
				case 6:
					if (!_0024req_002418379.IsEnd)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					if (_0024req_002418379.IsOk)
					{
						PurchaseUtil.CompletePurchase(_0024transactionId_002418375);
						goto case 7;
					}
					goto IL_035a;
				case 7:
					if (!PurchaseUtil.IsCompleteFinish())
					{
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					goto IL_0243;
				case 1:
					{
						result = 0;
						break;
					}
					IL_035a:
					PurchaseUtil.EndPurchase();
					if (_0024callback_002418382 != null)
					{
						_0024callback_002418382(arg0: true);
					}
					if (_0024selfDestroy_002418381)
					{
						UnityEngine.Object.DestroyObject(_0024self__002418383.gameObject);
					}
					YieldDefault(1);
					goto case 1;
					IL_0243:
					result = (YieldDefault(5) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024selfDestroy_002418384;

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024callback_002418385;

		internal ReparePurchase _0024self__002418386;

		public _0024RepareCore_002418369(bool selfDestroy, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback, ReparePurchase self_)
		{
			_0024selfDestroy_002418384 = selfDestroy;
			_0024callback_002418385 = callback;
			_0024self__002418386 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024selfDestroy_002418384, _0024callback_002418385, _0024self__002418386);
		}
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public static void RepareStone(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		GameObject gameObject = new GameObject();
		ReparePurchase reparePurchase = gameObject.AddComponent<ReparePurchase>();
		reparePurchase.Repare(selfDestroy: true, callback);
	}

	public IEnumerator RepareCore(bool selfDestroy, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		return new _0024RepareCore_002418369(selfDestroy, callback, this).GetEnumerator();
	}

	public void Repare(bool selfDestroy, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ callback)
	{
		IEnumerator enumerator = RepareCore(selfDestroy, callback);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}
}
