using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class JoinDeviceFlow
{
	[Serializable]
	internal class _0024TryRestoreFromWebClose_0024locals_002414570
	{
		internal bool _0024fin;

		internal bool _0024success;
	}

	[Serializable]
	internal class _0024TryRestore_0024locals_002414571
	{
		internal bool _0024fin;

		internal bool _0024success;
	}

	[Serializable]
	internal class _0024TryRestoreFromWebClose_0024cb_00245093
	{
		internal _0024TryRestoreFromWebClose_0024locals_002414570 _0024_0024locals_002415263;

		public _0024TryRestoreFromWebClose_0024cb_00245093(_0024TryRestoreFromWebClose_0024locals_002414570 _0024_0024locals_002415263)
		{
			this._0024_0024locals_002415263 = _0024_0024locals_002415263;
		}

		public void Invoke(RequestBase r)
		{
			_0024_0024locals_002415263._0024fin = true;
			_0024_0024locals_002415263._0024success = r.IsOk;
		}
	}

	[Serializable]
	internal class _0024TryRestore_0024cb_00245094
	{
		internal _0024TryRestore_0024locals_002414571 _0024_0024locals_002415264;

		public _0024TryRestore_0024cb_00245094(_0024TryRestore_0024locals_002414571 _0024_0024locals_002415264)
		{
			this._0024_0024locals_002415264 = _0024_0024locals_002415264;
		}

		public void Invoke(RequestBase r)
		{
			_0024_0024locals_002415264._0024fin = true;
			_0024_0024locals_002415264._0024success = r.IsOk;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TryRestoreFromWebClose_002423069 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024source_002423070;

			internal __MerlinServer_Request_0024callable86_0024160_56__ _0024cb_002423071;

			internal ApiPlatformAccessInfo _0024reqToken_002423072;

			internal ApiLocalDataDownload _0024reqDownload_002423073;

			internal _0024TryRestoreFromWebClose_0024locals_002414570 _0024_0024locals_002423074;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002423074 = new _0024TryRestoreFromWebClose_0024locals_002414570();
					if (trying)
					{
						goto case 1;
					}
					trying = true;
					_0024source_002423070 = WebViewBase.GetHtmlSource();
					if (_0024source_002423070.Contains("<title>JoinDeviceSucceed</title>"))
					{
						MarkJoinDevice();
						_0024_0024locals_002423074._0024fin = false;
						_0024_0024locals_002423074._0024success = false;
						_0024cb_002423071 = new _0024TryRestoreFromWebClose_0024cb_00245093(_0024_0024locals_002423074).Invoke;
						CurrentInfo.NotCreatedCharacter = false;
						goto IL_013d;
					}
					RestoreOldUUID();
					goto IL_0171;
				case 2:
					if (!_0024reqToken_002423072.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024reqToken_002423072.IsOk)
					{
						goto case 1;
					}
					_0024reqDownload_002423073 = new ApiLocalDataDownload();
					MerlinServer.ExRequest(_0024reqDownload_002423073, _0024cb_002423071);
					goto case 3;
				case 3:
					if (!_0024reqDownload_002423073.IsOk)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024reqDownload_002423073.IsOk)
					{
						goto IL_013d;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_013d:
					if (!_0024_0024locals_002423074._0024success)
					{
						_0024reqToken_002423072 = new ApiPlatformAccessInfo();
						MerlinServer.ExRequest(_0024reqToken_002423072);
						goto case 2;
					}
					if (_0024_0024locals_002423074._0024success)
					{
						QuestSession.DeleteSaveData();
					}
					UnMarkJoinDevice();
					goto IL_0171;
					IL_0171:
					trying = false;
					YieldDefault(1);
					goto case 1;
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

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TryRestore_002423075 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal __MerlinServer_Request_0024callable86_0024160_56__ _0024cb_002423076;

			internal ApiLocalDataDownload _0024reqDownload_002423077;

			internal _0024TryRestore_0024locals_002414571 _0024_0024locals_002423078;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002423078 = new _0024TryRestore_0024locals_002414571();
					if (NeedRestore)
					{
						_0024_0024locals_002423078._0024fin = false;
						_0024_0024locals_002423078._0024success = false;
						_0024cb_002423076 = new _0024TryRestore_0024cb_00245094(_0024_0024locals_002423078).Invoke;
						goto IL_00b7;
					}
					RestoreOldUUID();
					goto IL_00d6;
				case 2:
					if (!_0024reqDownload_002423077.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024reqDownload_002423077.IsOk)
					{
						goto IL_00b7;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b7:
					if (!_0024_0024locals_002423078._0024success)
					{
						_0024reqDownload_002423077 = new ApiLocalDataDownload();
						MerlinServer.ExRequest(_0024reqDownload_002423077, _0024cb_002423076);
						goto case 2;
					}
					UnMarkJoinDevice();
					goto IL_00d6;
					IL_00d6:
					YieldDefault(1);
					goto case 1;
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

	[NonSerialized]
	private static WebView webView;

	[NonSerialized]
	private const string NONE_UUID = "NONE";

	[NonSerialized]
	private static bool trying;

	private static bool NeedRestore
	{
		get
		{
			bool result = false;
			if (CurrentInfo.NeedRestore)
			{
				result = true;
			}
			else if (!(CurrentInfo.OldUUID == CurrentInfo.UUID))
			{
			}
			return result;
		}
	}

	public static void SetWebView(WebView wv)
	{
		webView = wv;
	}

	private static void MarkJoinDevice()
	{
		CurrentInfo.NeedRestore = true;
	}

	private static void UnMarkJoinDevice()
	{
		CurrentInfo.OldUUID = CurrentInfo.UUID;
		CurrentInfo.NeedRestore = false;
	}

	public static void BackupUUID()
	{
		if (string.IsNullOrEmpty(CurrentInfo.UUID))
		{
			CurrentInfo.OldUUID = "NONE";
		}
		else
		{
			CurrentInfo.OldUUID = CurrentInfo.UUID;
		}
	}

	private static void RestoreOldUUID()
	{
		if (!string.IsNullOrEmpty(CurrentInfo.OldUUID))
		{
			string uUID = CurrentInfo.UUID;
			if (CurrentInfo.OldUUID == "NONE")
			{
				CurrentInfo.UUID = null;
			}
			else
			{
				CurrentInfo.UUID = CurrentInfo.OldUUID;
			}
			if (uUID != CurrentInfo.UUID)
			{
				MerlinServer.Instance.disposeRequests();
			}
			CurrentInfo.OldUUID = null;
		}
	}

	public static IEnumerator TryRestoreFromWebClose()
	{
		return new _0024TryRestoreFromWebClose_002423069().GetEnumerator();
	}

	public static IEnumerator TryRestore()
	{
		return new _0024TryRestore_002423075().GetEnumerator();
	}
}
