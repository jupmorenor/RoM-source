using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using SharpUnit;
using UnityEngine;

[Serializable]
public class MerlinApiTestCase : UnityTestCase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitRequest_002422386 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024reqString_002422387;

			internal object _0024res_002422388;

			internal string _0024resString_002422389;

			internal RequestBase _0024creq_002422390;

			internal MerlinApiTestCase _0024self__002422391;

			public _0024(RequestBase creq, MerlinApiTestCase self_)
			{
				_0024creq_002422390 = creq;
				_0024self__002422391 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024reqString_002422387 = _0024creq_002422390.ToString();
					_0024reqString_002422387 = _0024reqString_002422387.Replace(",", ",\n");
					_0024creq_002422390.ErrorHandler = _0024self__002422391.communicationError;
					_0024self__002422391.logging("<<<<<<<<" + _0024creq_002422390.GetType() + "開始 :" + _0024reqString_002422387);
					MerlinServer.Request(_0024creq_002422390);
					goto case 2;
				case 2:
					if (!_0024creq_002422390.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024res_002422388 = _0024creq_002422390.ResponseObj;
					_0024resString_002422389 = string.Empty;
					if (RuntimeServices.ToBool(_0024res_002422388))
					{
						_0024resString_002422389 = _0024res_002422388.ToString();
					}
					_0024resString_002422389 = _0024resString_002422389.Replace(",", ",\n");
					if (string.IsNullOrEmpty(_0024resString_002422389))
					{
						_0024resString_002422389 = _0024creq_002422390.Result;
					}
					_0024self__002422391.logging("Response:" + _0024resString_002422389);
					_0024self__002422391.logging(">>>>>>>>" + _0024creq_002422390.GetType() + " 完了\n");
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RequestBase _0024creq_002422392;

		internal MerlinApiTestCase _0024self__002422393;

		public _0024WaitRequest_002422386(RequestBase creq, MerlinApiTestCase self_)
		{
			_0024creq_002422392 = creq;
			_0024self__002422393 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024creq_002422392, _0024self__002422393);
		}
	}

	public override void SetUp()
	{
	}

	public override void TearDown()
	{
	}

	protected void communicationError(RequestBase req)
	{
		MerlinServer.DebugResponseHook = null;
		string s = new StringBuilder("通信エラー\n").Append(req.GetType()).Append(":\nR:").Append(req.Result)
			.Append("\nE:")
			.Append(req.Error)
			.ToString();
		logging(s);
	}

	protected void logging(string s)
	{
		if ((bool)runner)
		{
			runner.gameObject.SendMessage("PutLog", s, SendMessageOptions.RequireReceiver);
		}
	}

	protected string lookStatusCodeInReq(RequestBase req)
	{
		GameApiResponseBase gameApiResponseBase = req.ResponseObj as GameApiResponseBase;
		return gameApiResponseBase.StatusCode;
	}

	protected string readResponeString(RequestBase req)
	{
		GameApiResponseBase gameApiResponseBase = req.ResponseObj as GameApiResponseBase;
		string empty = string.Empty;
		empty = new StringBuilder().Append(empty).Append("\n").Append(req.GetType())
			.Append(":\nR:")
			.Append(req.Result)
			.Append("\nE:")
			.Append(req.Error)
			.Append("\nS:")
			.Append((object)req.Status)
			.ToString();
		if (gameApiResponseBase != null)
		{
			empty = new StringBuilder().Append(empty).Append(gameApiResponseBase.ToString().Replace(",", ",\n")).ToString();
		}
		return empty;
	}

	protected IEnumerator WaitRequest(RequestBase creq)
	{
		return new _0024WaitRequest_002422386(creq, this).GetEnumerator();
	}
}
