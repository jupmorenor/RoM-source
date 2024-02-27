using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using Ionic.Zlib;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public abstract class RequestBase : IDisposable
{
	[Serializable]
	internal class _0024sendRoutine_0024locals_002414448
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024RawDataToReadableString_0024locals_002414449
	{
		internal __DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__ _0024_type;
	}

	[Serializable]
	internal class _0024sendRoutine_0024closure_00243968
	{
		internal _0024sendRoutine_0024locals_002414448 _0024_0024locals_002415000;

		public _0024sendRoutine_0024closure_00243968(_0024sendRoutine_0024locals_002414448 _0024_0024locals_002415000)
		{
			this._0024_0024locals_002415000 = _0024_0024locals_002415000;
		}

		public void Invoke()
		{
			_0024_0024locals_002415000._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024RawDataToReadableString_0024_type_and_val_00243971
	{
		internal _0024RawDataToReadableString_0024locals_002414449 _0024_0024locals_002415001;

		public _0024RawDataToReadableString_0024_type_and_val_00243971(_0024RawDataToReadableString_0024locals_002414449 _0024_0024locals_002415001)
		{
			this._0024_0024locals_002415001 = _0024_0024locals_002415001;
		}

		public string Invoke(object v)
		{
			return v + " as " + _0024_0024locals_002415001._0024_type(v);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024sendRoutine_002419523 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024timeout_002419524;

			internal DateTime _0024lastTrialTime_002419525;

			internal double _0024passed_002419526;

			internal float _0024_0024wait_realtime_sec_0024temp_00241834_002419527;

			internal float _0024_0024wait_realtime_sec_0024temp_00241835_002419528;

			internal float _0024_0024wait_sec_0024temp_00241836_002419529;

			internal string _0024emuWWWErr_002419530;

			internal string _0024wwwerror_002419531;

			internal string _0024resultText_002419532;

			internal GZipStream _0024readStream_002419533;

			internal IDisposable _0024_0024using_0024disposable_00241838_002419534;

			internal MemoryStream _0024writeStream_002419535;

			internal IDisposable _0024_0024using_0024disposable_00241837_002419536;

			internal byte[] _0024buffer_002419537;

			internal int _0024readCount_002419538;

			internal string _0024gstatus_002419539;

			internal float _0024_0024wait_realtime_sec_0024temp_00241839_002419540;

			internal float _0024_0024wait_realtime_sec_0024temp_00241840_002419541;

			internal float _0024_0024wait_sec_0024temp_00241841_002419542;

			internal object _0024robj_002419543;

			internal string _0024emuStatus_002419544;

			internal GameApiResponseBase _0024rsp_002419545;

			internal _0024sendRoutine_0024locals_002414448 _0024_0024locals_002419546;

			internal RequestBase _0024self__002419547;

			public _0024(RequestBase self_)
			{
				_0024self__002419547 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				int result;
				checked
				{
					try
					{
						switch (_state)
						{
						default:
							_0024_0024locals_002419546 = new _0024sendRoutine_0024locals_002414448();
							_0024self__002419547.serialRequestID = ++serialId;
							_0024self__002419547.retryNum = 0;
							_0024timeout_002419524 = false;
							_0024lastTrialTime_002419525 = DateTime.Now - new TimeSpan(0, 0, 4);
							goto IL_0825;
						case 3:
							if (_0024_0024locals_002419546._0024ok)
							{
								goto IL_0133;
							}
							flag = YieldDefault(3);
							goto IL_0880;
						case 4:
							if (Time.realtimeSinceStartup - _0024_0024wait_realtime_sec_0024temp_00241835_002419528 < _0024_0024wait_realtime_sec_0024temp_00241834_002419527)
							{
								flag = YieldDefault(4);
								goto IL_0880;
							}
							goto IL_0226;
						case 5:
							if (!(_0024_0024wait_sec_0024temp_00241836_002419529 > 0f))
							{
								goto IL_0226;
							}
							_0024_0024wait_sec_0024temp_00241836_002419529 -= Time.deltaTime;
							flag = YieldDefault(5);
							goto IL_0880;
						case 6:
							if (Time.realtimeSinceStartup - _0024self__002419547.startTime <= 30f)
							{
								goto IL_02d1;
							}
							_0024self__002419547.Dispose();
							_0024timeout_002419524 = true;
							goto IL_0300;
						case 7:
							if (Time.realtimeSinceStartup - _0024_0024wait_realtime_sec_0024temp_00241840_002419541 < _0024_0024wait_realtime_sec_0024temp_00241839_002419540)
							{
								flag = YieldDefault(7);
								goto IL_0880;
							}
							goto IL_06d6;
						case 8:
							if (!(_0024_0024wait_sec_0024temp_00241841_002419542 > 0f))
							{
								goto IL_06d6;
							}
							_0024_0024wait_sec_0024temp_00241841_002419542 -= Time.deltaTime;
							flag = YieldDefault(8);
							goto IL_0880;
						case 1:
						case 2:
							goto end_IL_0000;
							IL_02d1:
							if (_0024self__002419547.www.isDone || !string.IsNullOrEmpty(_0024self__002419547.www.error))
							{
								goto IL_0300;
							}
							_0024self__002419547.upCounter++;
							flag = YieldDefault(6);
							goto IL_0880;
							IL_0825:
							if (_0024self__002419547.retryCount >= 0 && _0024self__002419547.retryNum > _0024self__002419547.retryCount)
							{
								break;
							}
							_state = 2;
							_0024self__002419547.retryNum++;
							if (!_0024self__002419547.stealth && (unchecked(_0024self__002419547.retryNum % 5) == 0 || _0024timeout_002419524) && _0024self__002419547.useRetryDialog)
							{
								_0024_0024locals_002419546._0024ok = false;
								MerlinServer.RetryDialog(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024sendRoutine_0024closure_00243968(_0024_0024locals_002419546).Invoke));
								goto case 3;
							}
							goto IL_0133;
							IL_0300:
							_0024emuWWWErr_002419530 = _0024self__002419547.emulateWWWError();
							_0024wwwerror_002419531 = ((!string.IsNullOrEmpty(_0024emuWWWErr_002419530)) ? _0024emuWWWErr_002419530 : _0024self__002419547.www.error);
							if (!_0024timeout_002419524)
							{
								_0024self__002419547.setResult(_0024self__002419547.www, _0024wwwerror_002419531);
							}
							if (_0024timeout_002419524)
							{
								_0024self__002419547.isEnd = false;
								_0024self__002419547.status = 0;
							}
							else if (!string.IsNullOrEmpty(_0024wwwerror_002419531))
							{
								_0024self__002419547.isEnd = false;
								_0024self__002419547.status = 0;
							}
							else if (string.IsNullOrEmpty(_0024self__002419547.www.text) || string.IsNullOrEmpty(_0024self__002419547.www.text.Trim()) || _0024self__002419547.www.bytes == null || _0024self__002419547.www.bytes.Length == 0)
							{
								_0024self__002419547.isEnd = false;
								_0024self__002419547.status = 0;
							}
							else
							{
								_0024self__002419547.isEnd = true;
								_0024resultText_002419532 = string.Empty;
								if (USE_GZIP && ServerTypeModule.WillZipResponse(_0024self__002419547.Server))
								{
									try
									{
										_0024_0024using_0024disposable_00241838_002419534 = (_0024readStream_002419533 = new GZipStream(new MemoryStream(_0024self__002419547.www.bytes), CompressionMode.Decompress)) as IDisposable;
										try
										{
											_0024_0024using_0024disposable_00241837_002419536 = (_0024writeStream_002419535 = new MemoryStream()) as IDisposable;
											try
											{
												_0024buffer_002419537 = new byte[1024];
												while (true)
												{
													_0024readCount_002419538 = _0024readStream_002419533.Read(_0024buffer_002419537, 0, _0024buffer_002419537.Length);
													if (_0024readCount_002419538 <= 0)
													{
														break;
													}
													_0024writeStream_002419535.Write(_0024buffer_002419537, 0, _0024readCount_002419538);
												}
												_0024writeStream_002419535.Flush();
												_0024resultText_002419532 = Encoding.UTF8.GetString(_0024writeStream_002419535.ToArray());
											}
											finally
											{
												if (_0024_0024using_0024disposable_00241837_002419536 != null)
												{
													_0024_0024using_0024disposable_00241837_002419536.Dispose();
													_0024_0024using_0024disposable_00241837_002419536 = null;
												}
											}
										}
										finally
										{
											if (_0024_0024using_0024disposable_00241838_002419534 != null)
											{
												_0024_0024using_0024disposable_00241838_002419534.Dispose();
												_0024_0024using_0024disposable_00241838_002419534 = null;
											}
										}
									}
									catch (Exception)
									{
										_0024resultText_002419532 = _0024self__002419547.www.text;
									}
								}
								else
								{
									_0024resultText_002419532 = _0024self__002419547.www.text;
								}
								try
								{
									_0024self__002419547.result = _0024resultText_002419532;
									_0024self__002419547.responseJson = NGUIJson.jsonDecode(_0024resultText_002419532);
									_0024gstatus_002419539 = _0024self__002419547.GameServerResponseStatusCode;
								}
								catch (Exception)
								{
								}
								if (APIStatus.IsRetryStatus(_0024gstatus_002419539))
								{
									_0024self__002419547.isEnd = false;
									_0024self__002419547.status = 0;
									if (_0024self__002419547.useRealtimeRetryTimer)
									{
										_0024_0024wait_realtime_sec_0024temp_00241839_002419540 = 3f;
										_0024_0024wait_realtime_sec_0024temp_00241840_002419541 = Time.realtimeSinceStartup;
										goto case 7;
									}
									_0024_0024wait_sec_0024temp_00241841_002419542 = 3f;
									goto case 8;
								}
								try
								{
									_0024robj_002419543 = _0024self__002419547.setResponse(_0024self__002419547.responseJson);
									_0024emuStatus_002419544 = _0024self__002419547.emulateGameApiStatusError();
									if (_0024emuStatus_002419544 != null && _0024robj_002419543 == typeof(GameApiResponseBase))
									{
										_0024rsp_002419545 = _0024robj_002419543 as GameApiResponseBase;
										_0024rsp_002419545.StatusCode = _0024emuStatus_002419544;
									}
									_0024self__002419547.adjustDateTime();
									_0024self__002419547.postRequestJob();
									_0024self__002419547.setCurrentUserData();
								}
								catch (Exception)
								{
								}
								if (_0024self__002419547.www == null)
								{
									break;
								}
								if (!_0024self__002419547.IsOk)
								{
								}
							}
							_0024self__002419547.www = null;
							if (_0024self__002419547.IsOk)
							{
								break;
							}
							if (_0024self__002419547.HasValidStatus)
							{
								if (!_0024self__002419547.InfRetry)
								{
									break;
								}
								_0024self__002419547.retryJob();
							}
							_state = 1;
							_0024ensure2();
							goto IL_0825;
							IL_06d6:
							_0024self__002419547.www = null;
							goto IL_0825;
							IL_0226:
							_0024lastTrialTime_002419525 = DateTime.Now;
							_0024self__002419547.www = _0024self__002419547.createWWW(_0024self__002419547.serialRequestID, _0024self__002419547.retryNum);
							_0024timeout_002419524 = false;
							_0024self__002419547.startTime = Time.realtimeSinceStartup;
							goto IL_02d1;
							IL_0133:
							_0024self__002419547.clearResult();
							_0024self__002419547.preRequestJob();
							_0024passed_002419526 = (DateTime.Now - _0024lastTrialTime_002419525).TotalSeconds;
							if (!(_0024passed_002419526 >= 3.0))
							{
								if (_0024self__002419547.useRealtimeRetryTimer)
								{
									_0024_0024wait_realtime_sec_0024temp_00241834_002419527 = (float)(3.0 - _0024passed_002419526);
									_0024_0024wait_realtime_sec_0024temp_00241835_002419528 = Time.realtimeSinceStartup;
									goto case 4;
								}
								_0024_0024wait_sec_0024temp_00241836_002419529 = (float)(3.0 - _0024passed_002419526);
								goto case 5;
							}
							goto IL_0226;
						}
						_0024self__002419547.upCounter = -1;
						_0024self__002419547.isEnd = true;
						YieldDefault(1);
						end_IL_0000:;
					}
					catch
					{
						//try-fault
						Dispose();
						throw;
					}
					result = 0;
					goto IL_0882;
				}
				IL_0880:
				result = (flag ? 1 : 0);
				goto IL_0882;
				IL_0882:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024self__002419547.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal RequestBase _0024self__002419548;

		public _0024sendRoutine_002419523(RequestBase self_)
		{
			_0024self__002419548 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419548);
		}
	}

	[NonSerialized]
	public const bool WITH_X_MERLINVERSION_HEADER = true;

	[NonSerialized]
	private const double SHORTEST_PERIOD_TO_RETRY = 3.0;

	[NonSerialized]
	private const float OPTIMISTIC_ERROR_WAIT_TIME = 3f;

	[NonSerialized]
	private const int RETRY_NUM_UNTIL_INQUIRY = 5;

	private int _retryCount;

	private bool isEnd;

	private bool _exclusive;

	private bool stealth;

	private GameObject cbObj;

	private __MerlinServer_Request_0024callable86_0024160_56__ handler;

	private __MerlinServer_Request_0024callable86_0024160_56__ errorHandler;

	private __MerlinServer_Request_0024callable86_0024160_56__ finishedHandler;

	private __MerlinServer_Request_0024callable86_0024160_56__ preDialogErrorHandler;

	private string cbFunc;

	private string result;

	private int status;

	private string error;

	private object responseObj;

	private object responseJson;

	private Hashtable response;

	private string _apiKey;

	private WWW www;

	private bool _errorIgnored;

	private float startTime;

	private int retryNum;

	private bool useRealtimeRetryTimer;

	private bool useRetryDialog;

	private int upCounter;

	private int serialRequestID;

	[NonSerialized]
	private static int serialId;

	private bool _ignoreAllErrors;

	private string[] ignoreErrorCodes;

	private int wait;

	[NonSerialized]
	public static bool USE_GZIP;

	[NonSerialized]
	private const float TIMEOUT_1_HTTPREQ = 30f;

	public override bool IsOk
	{
		get
		{
			bool num = string.IsNullOrEmpty(error);
			if (num)
			{
				num = status == 200;
			}
			return num;
		}
	}

	public bool IsEnd => isEnd;

	public bool exclusive
	{
		get
		{
			return _exclusive;
		}
		set
		{
			_exclusive = value;
		}
	}

	public GameObject CallBackObject
	{
		set
		{
			cbObj = value;
		}
	}

	public string CallBackFunction
	{
		set
		{
			cbFunc = value;
		}
	}

	public bool Is500Error
	{
		get
		{
			bool num = !string.IsNullOrEmpty(error);
			if (num)
			{
				num = error.StartsWith("50");
			}
			return num;
		}
	}

	public bool Is400Error
	{
		get
		{
			bool num = !string.IsNullOrEmpty(error);
			if (num)
			{
				num = error.StartsWith("40");
			}
			return num;
		}
	}

	public override string ApiPath
	{
		get
		{
			throw new Exception("RequestBase.ApiPath could not be called immediately.");
		}
	}

	public override ServerType Server => ServerType.None;

	public override string ApiKey
	{
		get
		{
			return _apiKey;
		}
		set
		{
			_apiKey = value;
		}
	}

	public bool ErrorIgnored
	{
		get
		{
			return _errorIgnored;
		}
		set
		{
			_errorIgnored = value;
		}
	}

	public bool ForceNoError
	{
		set
		{
			if (value)
			{
				error = null;
				status = 200;
				if (ResponseObj is GameApiResponseBase gameApiResponseBase)
				{
					gameApiResponseBase.StatusCode = "0";
				}
			}
		}
	}

	public float SessionElapsedTime => Time.realtimeSinceStartup - startTime;

	public bool IsStoppedCoroutine => upCounter < 0;

	public bool UnderMaintenance
	{
		get
		{
			int num;
			if (!(responseJson is Hashtable hashtable))
			{
				num = 0;
			}
			else
			{
				num = (hashtable.ContainsKey("StatusCode") ? 1 : 0);
				if (num != 0)
				{
					num = (RuntimeServices.EqualityOperator(hashtable["StatusCode"], "CoApi999") ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	public string GameServerResponseStatusCode => (responseJson is Hashtable hashtable && hashtable.ContainsKey("StatusCode")) ? new StringBuilder().Append(hashtable["StatusCode"]).ToString() : string.Empty;

	public string MoveToUrlUnderMaintenance => (!UnderMaintenance) ? null : ((!(responseJson is Hashtable hashtable) || !hashtable.ContainsKey("moveURL")) ? null : new StringBuilder().Append(hashtable["moveURL"]).ToString());

	public bool GotoBootError => responseObj is GameApiResponseBase gameApiResponseBase && APIStatus.IsGotoBootStatusError(gameApiResponseBase.StatusCode);

	public bool HasClientVersionError
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = responseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = gameApiResponseBase.StatusCode == "CoApi006";
			}
			return num;
		}
	}

	public bool HasDataVersionError
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = responseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = gameApiResponseBase.StatusCode == "CoApi005";
			}
			return num;
		}
	}

	public bool HasMasterVersionError
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = responseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = gameApiResponseBase.StatusCode == "CoApi007";
			}
			return num;
		}
	}

	public override bool HasValidStatus => responseObj != null;

	public override bool InfRetry => false;

	protected string Url => ServerURL.ServerUrl(Server, ApiPath);

	protected UserData userData => UserData.Current;

	protected UserBoxData userBoxData => UserData.Current.userBoxData;

	public string[] IgnoreErrorCodes
	{
		get
		{
			return ignoreErrorCodes;
		}
		set
		{
			ignoreErrorCodes = value;
		}
	}

	public bool ShouldIgnoreError
	{
		get
		{
			int num;
			if (!(ResponseObj is GameApiResponseBase) || IgnoreErrorCodes == null)
			{
				num = 0;
			}
			else
			{
				GameApiResponseBase gameApiResponseBase = ResponseObj as GameApiResponseBase;
				int num2 = 0;
				string[] array = IgnoreErrorCodes;
				int length = array.Length;
				while (true)
				{
					if (num2 < length)
					{
						if (gameApiResponseBase.StatusCode == array[num2])
						{
							num = 1;
							break;
						}
						num2 = checked(num2 + 1);
						continue;
					}
					num = 0;
					break;
				}
			}
			return (byte)num != 0;
		}
	}

	public int retryCount
	{
		get
		{
			return _retryCount;
		}
		set
		{
			_retryCount = value;
		}
	}

	public bool Stealth
	{
		get
		{
			return stealth;
		}
		set
		{
			stealth = value;
		}
	}

	public __MerlinServer_Request_0024callable86_0024160_56__ Handler
	{
		get
		{
			return handler;
		}
		set
		{
			handler = value;
		}
	}

	public __MerlinServer_Request_0024callable86_0024160_56__ ErrorHandler
	{
		get
		{
			return errorHandler;
		}
		set
		{
			errorHandler = value;
		}
	}

	public __MerlinServer_Request_0024callable86_0024160_56__ FinishedHandler
	{
		get
		{
			return finishedHandler;
		}
		set
		{
			finishedHandler = value;
		}
	}

	public __MerlinServer_Request_0024callable86_0024160_56__ PreDialogErrorHandler
	{
		get
		{
			return preDialogErrorHandler;
		}
		set
		{
			preDialogErrorHandler = value;
		}
	}

	public string CbFunc
	{
		get
		{
			return cbFunc;
		}
		set
		{
			cbFunc = value;
		}
	}

	public string Result
	{
		get
		{
			return result;
		}
		set
		{
			result = value;
		}
	}

	public int Status
	{
		get
		{
			return status;
		}
		set
		{
			status = value;
		}
	}

	public string Error
	{
		get
		{
			return error;
		}
		set
		{
			error = value;
		}
	}

	public object ResponseObj
	{
		get
		{
			return responseObj;
		}
		set
		{
			responseObj = value;
		}
	}

	public object ResponseJson => responseJson;

	public Hashtable Response => response;

	public int RetryNum => retryNum;

	public bool UseRealtimeRetryTimer
	{
		get
		{
			return useRealtimeRetryTimer;
		}
		set
		{
			useRealtimeRetryTimer = value;
		}
	}

	public bool UseRetryDialog
	{
		get
		{
			return useRetryDialog;
		}
		set
		{
			useRetryDialog = value;
		}
	}

	public int UpCounter => upCounter;

	public bool ignoreAllErrors
	{
		get
		{
			return _ignoreAllErrors;
		}
		set
		{
			_ignoreAllErrors = value;
		}
	}

	public int WaitTime
	{
		get
		{
			return wait;
		}
		set
		{
			wait = value;
		}
	}

	protected RequestBase()
	{
		_retryCount = -1;
		_exclusive = true;
		_apiKey = ServerUtilModule.GenerateUUID();
		useRetryDialog = true;
	}

	public void setNotEnd()
	{
		isEnd = false;
		Status = 0;
	}

	public void InvokeHandler()
	{
		try
		{
			if (handler != null)
			{
				handler(this);
			}
			CallBack();
		}
		catch (Exception)
		{
		}
	}

	public void InvokeErrorHandler()
	{
		try
		{
			if (errorHandler != null)
			{
				errorHandler(this);
			}
		}
		catch (Exception)
		{
		}
	}

	public void InvokeFinishedHandler()
	{
		try
		{
			if (finishedHandler != null)
			{
				finishedHandler(this);
			}
		}
		catch (Exception)
		{
		}
	}

	public void InvokePreDialogErrorHandler()
	{
		try
		{
			if (preDialogErrorHandler != null)
			{
				preDialogErrorHandler(this);
			}
		}
		catch (Exception)
		{
		}
	}

	public virtual void Dispose()
	{
		if (www != null && status != 0)
		{
			try
			{
				www.Dispose();
			}
			catch (Exception)
			{
			}
			www = null;
			Status = 500;
		}
	}

	public virtual Type responseType()
	{
		return typeof(GameApiResponseBase);
	}

	public void realtimeRetyrTimerAndNoRetryDialog()
	{
		useRealtimeRetryTimer = true;
		useRetryDialog = false;
	}

	protected virtual object parameters()
	{
		FieldInfo field = GetType().GetField("__REQUEST__", BindingFlags.Instance | BindingFlags.Public);
		object obj2;
		if (field != null)
		{
			object obj;
			try
			{
				obj = ToJsonData(field.GetValue(this));
			}
			catch (Exception)
			{
				obj = null;
			}
			obj2 = obj;
		}
		else
		{
			obj2 = ToJsonData(this);
		}
		return obj2;
	}

	public static object ToJsonData(object obj)
	{
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			object obj3;
			try
			{
				Type type = obj.GetType();
				if (type.IsEnum)
				{
					obj3 = RuntimeServices.UnboxInt32(obj);
				}
				else if (type.IsPrimitive)
				{
					obj3 = obj;
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					obj3 = obj;
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(BoxId)))
				{
					BoxId boxId = (BoxId)obj;
					obj3 = boxId.Value;
				}
				else if (type.IsArray)
				{
					ArrayList arrayList = new ArrayList();
					IEnumerator enumerator = (obj as Array).GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						arrayList.Add(ToJsonData(current));
					}
					obj3 = Builtins.array(arrayList);
				}
				else if (obj is ArrayList)
				{
					obj3 = ObjArrayToJsonDataArray(obj as ArrayList);
				}
				else if (obj is Hashtable)
				{
					Hashtable hashtable = obj as Hashtable;
					Hashtable hashtable2 = new Hashtable();
					IEnumerator enumerator2 = hashtable.Keys.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object current2 = enumerator2.Current;
						hashtable2[current2] = ToJsonData(hashtable[current2]);
					}
					obj3 = hashtable2;
				}
				else if (obj is DateTime)
				{
					obj3 = obj.ToString();
				}
				else
				{
					Hashtable hashtable3 = new Hashtable();
					int i = 0;
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
					for (int length = fields.Length; i < length; i = checked(i + 1))
					{
						hashtable3[fields[i].Name] = ToJsonData(fields[i].GetValue(obj));
					}
					obj3 = hashtable3;
				}
			}
			catch (Exception)
			{
				obj3 = "ERROR<" + obj.GetType() + ">";
			}
			obj2 = obj3;
		}
		return obj2;
	}

	private static object[] ObjArrayToJsonDataArray(ArrayList ary)
	{
		Boo.Lang.List<object> list = new Boo.Lang.List<object>();
		IEnumerator enumerator = ary.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			list.Add(ToJsonData(current));
		}
		return list.ToArray();
	}

	protected virtual object setResponse(object @params)
	{
		object obj;
		if (!RuntimeServices.ToBool(@params))
		{
			obj = null;
		}
		else
		{
			Type type = responseType();
			responseObj = JsonBase.CreateFromJson(type, @params);
			if (responseObj == null)
			{
				throw new AssertionFailedException("responseObj != null");
			}
			obj = responseObj;
		}
		return obj;
	}

	protected virtual void setCurrentUserData()
	{
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		object obj = getResponsePublicField("Player");
		if (!(obj is RespPlayer))
		{
			obj = RuntimeServices.Coerce(obj, typeof(RespPlayer));
		}
		RespPlayer respPlayer = (RespPlayer)obj;
		if (respPlayer != null)
		{
			UserData.Current.setPlayerBasicInfo(respPlayer);
		}
		object obj2 = getResponsePublicField("PlayerInfo");
		if (!(obj2 is RespPlayerInfo))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(RespPlayerInfo));
		}
		RespPlayerInfo respPlayerInfo = (RespPlayerInfo)obj2;
		if (respPlayerInfo != null)
		{
			int tSocialPlayerId = UserData.Current.userStatus.TSocialPlayerId;
			UserData.Current.setPlayerStatus(respPlayerInfo);
			if (tSocialPlayerId != UserData.Current.userStatus.TSocialPlayerId)
			{
				TestFlightUnity.PassCheckpoint(new StringBuilder("SocialID:").Append((object)UserData.Current.userStatus.TSocialPlayerId).ToString());
			}
		}
		object obj3 = getResponsePublicField("Box");
		if (!(obj3 is RespPlayerBox[]))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(RespPlayerBox[]));
		}
		RespPlayerBox[] array = (RespPlayerBox[])obj3;
		if (array != null)
		{
			UserData.Current.setBox(array);
		}
		RespFriend[] array2 = getResponsePublicField("Friend") as RespFriend[];
		if (array2 == null)
		{
			array2 = getResponsePublicField("Friends") as RespFriend[];
		}
		if (array2 != null)
		{
			UpdateFriends(array2);
		}
		object obj4 = getResponsePublicField("PlayerRanking");
		if (!(obj4 is RespCycleGuildPlayerRanking))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(RespCycleGuildPlayerRanking));
		}
		RespCycleGuildPlayerRanking respCycleGuildPlayerRanking = (RespCycleGuildPlayerRanking)obj4;
		if (respCycleGuildPlayerRanking != null)
		{
			UserData.Current.setGuildPlayerRanking(respCycleGuildPlayerRanking);
		}
		object obj5 = getResponsePublicField("GuildRanking");
		if (!(obj5 is RespCycleGuildRanking))
		{
			obj5 = RuntimeServices.Coerce(obj5, typeof(RespCycleGuildRanking));
		}
		RespCycleGuildRanking respCycleGuildRanking = (RespCycleGuildRanking)obj5;
		if (respCycleGuildRanking != null)
		{
			UserData.Current.setGuildRanking(respCycleGuildRanking);
		}
		if (getResponsePublicField("GuildPlayer") is RespFriend[] guildPlayers)
		{
			UserData.Current.setGuildPlayers(guildPlayers);
		}
		object obj6 = getResponsePublicField("RaidBattle");
		if (!(obj6 is RespTCycleRaidBattle))
		{
			obj6 = RuntimeServices.Coerce(obj6, typeof(RespTCycleRaidBattle));
		}
		RespTCycleRaidBattle respTCycleRaidBattle = (RespTCycleRaidBattle)obj6;
		if (respTCycleRaidBattle != null)
		{
			UserData.Current.setRaidBattle(respTCycleRaidBattle);
			UserData.Current.userMiscInfo.flagData.updateCondition();
		}
		object obj7 = getResponsePublicField("QuestRanking");
		if (!(obj7 is RespChallengeQuestRankings))
		{
			obj7 = RuntimeServices.Coerce(obj7, typeof(RespChallengeQuestRankings));
		}
		RespChallengeQuestRankings respChallengeQuestRankings = (RespChallengeQuestRankings)obj7;
		if (respChallengeQuestRankings != null)
		{
			UserData.Current.setChallengeQuestRanking(respChallengeQuestRankings);
		}
		object obj8 = getResponsePublicField("PartyMember");
		if (!(obj8 is RespParty))
		{
			obj8 = RuntimeServices.Coerce(obj8, typeof(RespParty));
		}
		RespParty respParty = (RespParty)obj8;
		if (respParty != null)
		{
			int tSocialPlayerId2 = UserData.Current.TSocialPlayerId;
			if (respParty.Contains(tSocialPlayerId2))
			{
				UpdateParty(respParty);
			}
		}
		object obj9 = getResponsePublicField("PartyApplies");
		if (!(obj9 is RespApplyInfo[]))
		{
			obj9 = RuntimeServices.Coerce(obj9, typeof(RespApplyInfo[]));
		}
		RespApplyInfo[] array3 = (RespApplyInfo[])obj9;
		if (array3 != null)
		{
			UpdatePartyApplies(array3);
		}
		object obj10 = getResponsePublicField("FriendApplies");
		if (!(obj10 is RespApplyInfo[]))
		{
			obj10 = RuntimeServices.Coerce(obj10, typeof(RespApplyInfo[]));
		}
		RespApplyInfo[] array4 = (RespApplyInfo[])obj10;
		if (array4 != null)
		{
			UpdateFriendApplies(array4);
		}
		object obj11 = getResponsePublicField("PlayerLogin");
		if (!(obj11 is RespPlayerLogin[]))
		{
			obj11 = RuntimeServices.Coerce(obj11, typeof(RespPlayerLogin[]));
		}
		RespPlayerLogin[] array5 = (RespPlayerLogin[])obj11;
		if (array5 != null)
		{
			UserData.Current.setLoginBonus(array5);
		}
		object obj12 = getResponsePublicField("Decks");
		if (!(obj12 is RespDeck[]))
		{
			obj12 = RuntimeServices.Coerce(obj12, typeof(RespDeck[]));
		}
		RespDeck[] array6 = (RespDeck[])obj12;
		if (array6 != null)
		{
			UserData.Current.setDeck(array6);
		}
		else
		{
			object obj13 = getResponsePublicField("Deck");
			if (!(obj13 is RespDeck[]))
			{
				obj13 = RuntimeServices.Coerce(obj13, typeof(RespDeck[]));
			}
			array6 = (RespDeck[])obj13;
			if (array6 != null)
			{
				UserData.Current.setDeck(array6);
			}
		}
		object obj14 = getResponsePublicField("Decks2");
		if (!(obj14 is RespDeck2[]))
		{
			obj14 = RuntimeServices.Coerce(obj14, typeof(RespDeck2[]));
		}
		RespDeck2[] array7 = (RespDeck2[])obj14;
		if (array7 != null)
		{
			UserData.Current.setDeck2(array7);
		}
		object obj15 = getResponsePublicField("PresentBox");
		if (!(obj15 is RespPlayerPresentBox[]))
		{
			obj15 = RuntimeServices.Coerce(obj15, typeof(RespPlayerPresentBox[]));
		}
		RespPlayerPresentBox[] array8 = (RespPlayerPresentBox[])obj15;
		checked
		{
			if (array8 != null)
			{
				int num = 0;
				int i = 0;
				RespPlayerPresentBox[] array9 = array8;
				for (int length = array9.Length; i < length; i++)
				{
					if (!array9[i].IsReceive)
					{
						num++;
					}
				}
				UserData.Current.NewPresentData = num;
			}
			object responsePublicField = getResponsePublicField("InviteCode");
			if (responsePublicField is string)
			{
				UserData.Current.inviteCode = responsePublicField as string;
			}
			object responsePublicField2 = getResponsePublicField("QuestTickets");
			if (responsePublicField2 is RespQuestTicket[] array10)
			{
				RespQuestTicket.createQuestTable(array10);
				UserData.Current.questTickets = array10;
			}
			object obj16 = getResponsePublicField("PoppetDecks");
			if (!(obj16 is RespPoppetDeck[]))
			{
				obj16 = RuntimeServices.Coerce(obj16, typeof(RespPoppetDeck[]));
			}
			RespPoppetDeck[] array11 = (RespPoppetDeck[])obj16;
			if (array11 != null)
			{
				UserData.Current.setPoppetDeck(array11);
			}
			object obj17 = getResponsePublicField("Breeder");
			if (!(obj17 is RespBreeder))
			{
				obj17 = RuntimeServices.Coerce(obj17, typeof(RespBreeder));
			}
			RespBreeder respBreeder = (RespBreeder)obj17;
			if (respBreeder != null)
			{
				UserData.Current.userBreeder = respBreeder;
			}
			if (hasResposePublicField("ColosseumEvent"))
			{
				object obj18 = getResponsePublicField("ColosseumEvent");
				if (!(obj18 is RespColosseumEvent))
				{
					obj18 = RuntimeServices.Coerce(obj18, typeof(RespColosseumEvent));
				}
				RespColosseumEvent respColosseumEvent = (RespColosseumEvent)obj18;
				if (respColosseumEvent != null)
				{
					UserData.Current.userColosseumEvent.setColosseumEvent(new RespColosseumEvent[1] { respColosseumEvent });
				}
				else
				{
					UserData.Current.userColosseumEvent.setColosseumEvent(null);
				}
			}
			if (hasResposePublicField("ColosseumEventRanking"))
			{
				object obj19 = getResponsePublicField("ColosseumEventRanking");
				if (!(obj19 is RespColosseumEventRanking))
				{
					obj19 = RuntimeServices.Coerce(obj19, typeof(RespColosseumEventRanking));
				}
				RespColosseumEventRanking respColosseumEventRanking = (RespColosseumEventRanking)obj19;
				if (respColosseumEventRanking != null)
				{
					UserData.Current.userColosseumEvent.setColosseumEventRanking(respColosseumEventRanking);
				}
				else
				{
					UserData.Current.userColosseumEvent.setColosseumEventRanking(null);
				}
			}
			object responsePublicField3 = getResponsePublicField("ColosseumEventTotalRankingPoint");
			if (responsePublicField3 is double)
			{
				UserData.Current.userColosseumEvent.setColosseumEventTotalRankingPoint(RuntimeServices.UnboxDouble(responsePublicField3));
			}
			object obj20 = getResponsePublicField("ClearQuestMissions");
			if (!(obj20 is RespQuestMission[]))
			{
				obj20 = RuntimeServices.Coerce(obj20, typeof(RespQuestMission[]));
			}
			RespQuestMission[] array12 = (RespQuestMission[])obj20;
			if (array12 != null)
			{
				UserData.Current.userQuestMission.ClearQuestMissions = array12;
			}
			object obj21 = getResponsePublicField("NewQuestMissionIds");
			if (!(obj21 is int[]))
			{
				obj21 = RuntimeServices.Coerce(obj21, typeof(int[]));
			}
			int[] array13 = (int[])obj21;
			if (array13 != null)
			{
				UserData.Current.userQuestMission.NewQuestMissionIds = array13;
			}
			if (hasResposePublicField("IsHasNewMission"))
			{
				object responsePublicField4 = getResponsePublicField("IsHasNewMission");
				if (responsePublicField4 is bool)
				{
					UserData.Current.userQuestMission.IsHasNewMission = RuntimeServices.UnboxBoolean(responsePublicField4);
				}
			}
			object obj22 = getResponsePublicField("QuestMissions");
			if (!(obj22 is RespQuestMission[]))
			{
				obj22 = RuntimeServices.Coerce(obj22, typeof(RespQuestMission[]));
			}
			RespQuestMission[] array14 = (RespQuestMission[])obj22;
			if (array14 != null)
			{
				UserData.Current.userQuestMission.QuestMissions = array14;
			}
			object obj23 = getResponsePublicField("DailyPassiveSkills");
			if (!(obj23 is int[]))
			{
				obj23 = RuntimeServices.Coerce(obj23, typeof(int[]));
			}
			int[] array15 = (int[])obj23;
			if (array15 != null)
			{
				UserData.Current.userColosseumEvent.setDailyPassiveSkills(array15);
			}
		}
	}

	protected void SetLastGameResponse()
	{
		if (ResponseObj != null && ResponseObj is GameApiResponseBase)
		{
			CurrentInfo.LastGameResponse = ResponseObj as GameApiResponseBase;
		}
	}

	protected virtual void preRequestJob()
	{
	}

	private void convSafeName(object o)
	{
		string[][] array = new string[7][]
		{
			new string[2] { "RespPlayer", "Name" },
			new string[2] { "RespPlayerInfo", "AngelName" },
			new string[2] { "RespPlayerInfo", "DemonName" },
			new string[2] { "RespFriend", "Name" },
			new string[2] { "RespFriend", "AngelName" },
			new string[2] { "RespFriend", "DemonName" },
			new string[2] { "ApiFriendPlayerSearch", "Name" }
		};
		Type type = o.GetType();
		if (type.IsSubclassOf(typeof(RespFriend)))
		{
			type = typeof(RespFriend);
		}
		int i = 0;
		string[][] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (!(array2[i][0] == type.Name))
			{
				continue;
			}
			FieldInfo field = type.GetField(array2[i][1], BindingFlags.Instance | BindingFlags.Public);
			if (field != null && RuntimeServices.EqualityOperator(field.FieldType, typeof(string)))
			{
				object obj = field.GetValue(o);
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string str = (string)obj;
				str = Emoji.ConvertSafeCode(str);
				str = UIDynamicFontLabel.EscapeFontTag(str);
				field.SetValue(o, str);
			}
		}
	}

	protected void postRequestJob()
	{
		convSafeName(this);
		doPostRequestJob();
	}

	protected virtual void doPostRequestJob()
	{
		SetLastGameResponse();
	}

	protected virtual void retryJob()
	{
	}

	protected virtual string emulateWWWError()
	{
		return null;
	}

	protected virtual string emulateGameApiStatusError()
	{
		return null;
	}

	public virtual IEnumerator sendRoutine()
	{
		return new _0024sendRoutine_002419523(this).GetEnumerator();
	}

	public string shortDescription()
	{
		return new StringBuilder().Append(GetType()).Append("(").Append((object)serialRequestID)
			.Append(") Status:")
			.Append((object)Status)
			.Append(" stealth:")
			.Append(Stealth)
			.Append(" ignoreAllErrors:")
			.Append(ignoreAllErrors)
			.Append(" elapsed:")
			.Append(SessionElapsedTime)
			.Append(" retry:")
			.Append((object)RetryNum)
			.Append("/")
			.Append((object)retryCount)
			.Append(" upC:")
			.Append((object)UpCounter)
			.Append(" realtime:")
			.Append(useRealtimeRetryTimer)
			.Append(" dialog:")
			.Append(useRetryDialog)
			.ToString();
	}

	public void SetIgnoreErrorCodes(params string[] args)
	{
		ignoreErrorCodes = args;
	}

	protected void UpdateFriends(RespFriend[] friends)
	{
		if (friends != null)
		{
			UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
			UserData.Current.NewFriendData = alreadyReadData.GetNewFriends(friends).Count();
			UserData.Current.setFriendList(friends);
		}
	}

	protected void UpdateFriendApplies(RespApplyInfo[] applies)
	{
		if (applies != null)
		{
			UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
			UserData.Current.NewFriendApplyData = alreadyReadData.GetNewFriendApplies(applies).Count();
		}
	}

	protected void UpdateMembers(RespFriend[] members)
	{
		if (members != null)
		{
			UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
			UserData.Current.NewPartyMemberData = alreadyReadData.GetNewMembers(ArrayMapMain.FilterResps(members, (RespFriend x) => x.TSocialPlayerId != UserData.Current.TSocialPlayerId)).Count;
		}
	}

	protected void UpdateParty(RespParty party)
	{
		if (party != null && party.Members != null)
		{
			UpdateMembers(party.Members);
			UserData.Current.setParty(party);
		}
	}

	protected void UpdatePartyApplies(RespApplyInfo[] applies)
	{
		if (applies != null)
		{
			UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
			UserData.Current.NewPartyApplyData = alreadyReadData.GetNewPartyApplies(applies).Count();
		}
	}

	public void CallBack()
	{
		if ((bool)cbObj && !string.IsNullOrEmpty(cbFunc))
		{
			Hashtable resultHashtable = ServerUtilModule.GetResultHashtable(result);
			cbObj.SendMessage(cbFunc, resultHashtable);
		}
	}

	protected WWW createUnityWWW(int sid, int trial, ServerType stype, string url, Hashtable @params, Hashtable headers)
	{
		ApiSigner.Sign(@params, Server);
		string text = ServerUtilModule.HttpEncodedParameter(@params);
		WWW wWW;
		if (text.Length > 1024)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			wWW = new WWW(url, bytes, headers);
		}
		else
		{
			string url2 = ServerUtilModule.HttpGetMethodURL(url, @params);
			wWW = new WWW(url2, null, headers);
		}
		return wWW;
	}

	public WWW createWWW(int sid, int trial)
	{
		string url = Url;
		Hashtable hashtable = new Hashtable();
		if (true)
		{
			hashtable["x-merlinversion"] = CurrentInfo.ClientVersion;
		}
		Hashtable hashtable2 = null;
		ServerType server = Server;
		switch (server)
		{
		case ServerType.ExamVer:
			hashtable2 = parameters() as Hashtable;
			if (hashtable2 == null)
			{
				throw new AssertionFailedException("params != null");
			}
			break;
		case ServerType.Platform:
			hashtable2 = parameters() as Hashtable;
			if (hashtable2 == null)
			{
				throw new AssertionFailedException("params != null");
			}
			break;
		case ServerType.Entry:
			hashtable2 = parameters() as Hashtable;
			if (hashtable2 == null)
			{
				throw new AssertionFailedException("params != null");
			}
			break;
		case ServerType.Game:
		{
			if (!CurrentInfo.HasUUID || !CurrentInfo.HasToken)
			{
				throw new AssertionFailedException(new StringBuilder().Append(GetType()).Append(" uuid or token is invalid. ").Append(GetType())
					.Append(" -- uuid:")
					.Append(CurrentInfo.UUID)
					.Append(" token:")
					.Append(CurrentInfo.Token)
					.ToString());
			}
			hashtable2 = new Hashtable();
			hashtable2["data"] = NGUIJson.jsonEncode(parameters());
			if (!string.IsNullOrEmpty(ApiKey))
			{
				hashtable2["key"] = ApiKey;
			}
			hashtable2["token"] = CurrentInfo.Token;
			MerlinPlatform merlinPlatform = MerlinPlatformModule.CurrentMerlinPlatform();
			hashtable2["pltfm"] = new StringBuilder().Append(merlinPlatform).ToString();
			hashtable2["cv"] = CurrentBuildableVersion.CLIENT_VERSION;
			hashtable2["dv"] = CurrentBuildableVersion.DATA_VERSION;
			hashtable2["mv"] = CurrentBuildableVersion.MASTER_VERSION;
			hashtable2["cv"] = CurrentInfo.ClientVersion;
			hashtable2["dv"] = CurrentInfo.DataVersion;
			hashtable2["mv"] = CurrentInfo.MasterVersion;
			break;
		}
		default:
			throw new Exception(new StringBuilder("unknown server type: ").Append(server).ToString());
		}
		return createUnityWWW(sid, trial, server, url, hashtable2, hashtable);
	}

	private void clearResult()
	{
		isEnd = false;
		status = 0;
		result = string.Empty;
		error = null;
		responseObj = null;
		response = null;
	}

	protected void setResult(WWW www, string wwwerror)
	{
		status = 999;
		result = string.Empty;
		if (www != null)
		{
			error = wwwerror;
			if (!string.IsNullOrEmpty(error))
			{
			}
			try
			{
				if (!string.IsNullOrEmpty(wwwerror))
				{
					result = null;
					error = wwwerror;
					status = getStatusCodeFromError(wwwerror, 999);
				}
				else
				{
					result = www.text;
					status = 200;
				}
				return;
			}
			catch (Exception ex)
			{
				error = ex.ToString();
				return;
			}
		}
		error = "null pointer error";
	}

	private int getStatusCodeFromError(string err, int defval)
	{
		try
		{
			string[] array = err.Split(',');
			return int.Parse(array[0]);
		}
		catch (Exception)
		{
			return defval;
		}
	}

	public virtual bool UpdateParam()
	{
		return false;
	}

	private object getResponsePublicField(string n)
	{
		FieldInfo responsePublicFieldInfo = getResponsePublicFieldInfo(n);
		object obj2;
		if (responsePublicFieldInfo != null)
		{
			object obj;
			try
			{
				obj = responsePublicFieldInfo.GetValue(responseObj);
			}
			catch (Exception)
			{
				obj = null;
			}
			obj2 = obj;
		}
		else
		{
			obj2 = null;
		}
		return obj2;
	}

	private bool hasResposePublicField(string n)
	{
		return getResponsePublicFieldInfo(n) != null;
	}

	private FieldInfo getResponsePublicFieldInfo(string n)
	{
		object obj;
		if (responseObj != null)
		{
			Type type = responseObj.GetType();
			obj = type.GetField(n, BindingFlags.Instance | BindingFlags.Public);
		}
		else
		{
			obj = null;
		}
		return (FieldInfo)obj;
	}

	protected virtual string adjustDateTime()
	{
		if (responseObj is GameApiResponseBase)
		{
			GameApiResponseBase gameApiResponseBase = responseObj as GameApiResponseBase;
			if (!string.IsNullOrEmpty(gameApiResponseBase.RequestDate))
			{
				try
				{
					DateTime dateTime = DateTime.Parse(gameApiResponseBase.RequestDate);
					DateTime now = DateTime.Now;
					int num = 20;
					TimeSpan timeOffset = dateTime - now;
					if (!(Mathf.Abs((float)timeOffset.TotalMinutes) <= (float)num))
					{
						MerlinDateTime.SetTimeOffset(timeOffset);
					}
				}
				catch (Exception)
				{
				}
			}
		}
		return null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Type type = GetType();
		stringBuilder.Append(type + "{");
		int i = 0;
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
		object value = default(object);
		for (int length = fields.Length; i < length; i = checked(i + 1))
		{
			string text2;
			try
			{
				value = fields[i].GetValue(this);
				string text = value.GetType().ToString();
				if (text == "System.Collections.ArrayList")
				{
					text2 = string.Empty;
					IEnumerator enumerator = RuntimeServices.GetEnumerable(value).GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						text2 += new StringBuilder().Append(current).ToString();
					}
				}
				else
				{
					text2 = value.ToString();
				}
			}
			catch (Exception)
			{
				text2 = new StringBuilder("<<ERR:").Append(value).Append(">>").ToString();
			}
			stringBuilder.Append("\"" + fields[i].Name + "\":" + text2 + ",");
		}
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	public static string RawDataToReadableString(object d)
	{
		_0024RawDataToReadableString_0024locals_002414449 _0024RawDataToReadableString_0024locals_0024 = new _0024RawDataToReadableString_0024locals_002414449();
		object obj;
		if (d == null)
		{
			obj = "(null)";
		}
		else
		{
			_0024RawDataToReadableString_0024locals_0024._0024_type = (object v) => (v != null) ? v.GetType().ToString().Replace("System.", string.Empty) : "(null)";
			__DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__ _DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__ = new _0024RawDataToReadableString_0024_type_and_val_00243971(_0024RawDataToReadableString_0024locals_0024).Invoke;
			string text;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (d is Hashtable)
				{
					Hashtable hashtable = d as Hashtable;
					stringBuilder.Append("{");
					IEnumerator enumerator = hashtable.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						object d2 = hashtable[current];
						stringBuilder.Append(new StringBuilder().Append(current).Append(":").ToString());
						stringBuilder.Append(RawDataToReadableString(d2));
						stringBuilder.Append(",");
					}
					stringBuilder.Append("}");
					text = stringBuilder.ToString();
				}
				else if (d is ArrayList)
				{
					ArrayList arrayList = d as ArrayList;
					stringBuilder.Append("[");
					IEnumerator enumerator2 = arrayList.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object current2 = enumerator2.Current;
						stringBuilder.Append(RawDataToReadableString(current2));
						stringBuilder.Append(",");
					}
					stringBuilder.Append("]");
					text = stringBuilder.ToString();
				}
				else
				{
					text = _DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(d);
				}
			}
			catch (Exception)
			{
				text = "<exception>";
			}
			obj = text;
		}
		return (string)obj;
	}

	internal bool _0024UpdateMembers_0024closure_00243969(RespFriend x)
	{
		return x.TSocialPlayerId != UserData.Current.TSocialPlayerId;
	}

	internal static string _0024RawDataToReadableString_0024_type_00243970(object v)
	{
		return (v != null) ? v.GetType().ToString().Replace("System.", string.Empty) : "(null)";
	}
}
