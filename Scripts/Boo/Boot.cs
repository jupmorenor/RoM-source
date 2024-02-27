using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class Boot : MonoBehaviour
{
	[Serializable]
	internal class _0024checkPerfrmance_0024locals_002414336
	{
		internal bool _0024error;
	}

	[Serializable]
	internal class _0024checkPerfrmance_0024closure_00244277
	{
		internal _0024checkPerfrmance_0024locals_002414336 _0024_0024locals_002414780;

		public _0024checkPerfrmance_0024closure_00244277(_0024checkPerfrmance_0024locals_002414336 _0024_0024locals_002414780)
		{
			this._0024_0024locals_002414780 = _0024_0024locals_002414780;
		}

		public void Invoke()
		{
			_0024_0024locals_002414780._0024error = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416655 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal int _0024i_002416656;

			internal int _0024cmver_002416657;

			internal MemoryChecker _0024mc_002416658;

			internal RuntimeDebugMode _0024dm_002416659;

			internal GameLevelManager _0024gm_002416660;

			internal QuestManager _0024qm_002416661;

			internal MerlinServer _0024sv_002416662;

			internal PurchaseUtil _0024pu_002416663;

			internal SQEX_SoundPlayer _0024sm_002416664;

			internal MerlinLocalNotification _0024mln_002416665;

			internal KamcordRecorder _0024kr_002416666;

			internal IconAtlasPool _0024ip_002416667;

			internal DeviceInputManager _0024im_002416668;

			internal GCMUtil _0024gcm_002416669;

			internal int _0024i_002416670;

			internal IEnumerator _0024_0024sco_0024temp_00241189_002416671;

			internal int _0024_00248353_002416672;

			internal int _0024_00248354_002416673;

			internal Boot _0024self__002416674;

			public _0024(Boot self_)
			{
				_0024self__002416674 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					QuestInitializer.DisposeAll();
					_0024_00248353_002416672 = 0;
					goto case 2;
				case 2:
					if (_0024_00248353_002416672 < 2)
					{
						_0024i_002416656 = _0024_00248353_002416672;
						_0024_00248353_002416672++;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024cmver_002416657 = 0;
					int.TryParse(CurrentInfo.MasterVersion, out _0024cmver_002416657);
					if (ClientMasterArchive.HasCache && 0 < _0024cmver_002416657)
					{
						ClientMasterArchive.ReadMasterArchiveCacheASync(ClientMasterArchive.GetDefaultMasterArchivePath());
					}
					_0024mc_002416658 = MemoryChecker.Instance;
					_0024dm_002416659 = RuntimeDebugMode.Instance;
					AssetBundleLoader.DestroyAll();
					RuntimeAssetBundleDB.Instance.initializeFromSavedData();
					_0024gm_002416660 = GameLevelManager.Instance;
					_0024qm_002416661 = QuestManager.Instance;
					_0024sv_002416662 = MerlinServer.Instance;
					_0024sv_002416662.EnableLoadingLabel = false;
					_0024pu_002416663 = PurchaseUtil.Instance;
					_0024sm_002416664 = SQEX_SoundPlayer.Instance;
					_0024mln_002416665 = MerlinLocalNotification.Instance;
					MerlinLocalNotification.clear();
					_0024kr_002416666 = KamcordRecorder.Instance;
					_0024kr_002416666.initialize();
					TutorialFlowControl.Kill();
					MerlinGameCenter.Instance.AuthOnBoot();
					_0024ip_002416667 = IconAtlasPool.Instance;
					_0024im_002416668 = DeviceInputManager.Instance;
					_0024gcm_002416669 = GCMUtil.Instance;
					TheWorld.Init();
					ShadowCheck.Init();
					WebBannerTown.Reset();
					PlayerPoppetCache.Instance.dispose();
					_0024_00248354_002416673 = 0;
					goto case 3;
				case 3:
					if (_0024_00248354_002416673 < 2)
					{
						_0024i_002416670 = _0024_00248354_002416673;
						_0024_00248354_002416673++;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002416674.initCompleted = true;
					_0024_0024sco_0024temp_00241189_002416671 = _0024self__002416674.checkPerfrmance();
					if (_0024_0024sco_0024temp_00241189_002416671 != null)
					{
						result = (Yield(4, _0024self__002416674.StartCoroutine(_0024_0024sco_0024temp_00241189_002416671)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
				case 5:
					if (!FacebookBridge.Enabled)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					FacebookBridge.ActivateApp();
					SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Boot _0024self__002416675;

		public _0024main_002416655(Boot self_)
		{
			_0024self__002416675 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416675);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024checkPerfrmance_002416676 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024checkPerformanceSettting_002416677;

			internal ApiPlatformExtServer _0024extreq_002416678;

			internal PerformanceSetting _0024performSetting_002416679;

			internal _0024checkPerfrmance_0024locals_002414336 _0024_0024locals_002416680;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416680 = new _0024checkPerfrmance_0024locals_002414336();
					_0024checkPerformanceSettting_002416677 = true;
					if (!_0024checkPerformanceSettting_002416677)
					{
						goto case 1;
					}
					goto case 2;
				case 2:
					if (MerlinServer.Instance.IsBusy)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					MerlinServer.Busy = true;
					_0024_0024locals_002416680._0024error = false;
					_0024extreq_002416678 = new ApiPlatformExtServer();
					_0024extreq_002416678.Stealth = true;
					_0024extreq_002416678.retryCount = 0;
					_0024extreq_002416678.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024checkPerfrmance_0024closure_00244277(_0024_0024locals_002416680).Invoke);
					MerlinServer.ExRequest(_0024extreq_002416678);
					goto case 3;
				case 3:
					if (!_0024extreq_002416678.IsEnd && string.IsNullOrEmpty(_0024extreq_002416678.Error) && !_0024_0024locals_002416680._0024error)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (ServerURL.HasAssetSrvURL)
					{
						PerformanceSettingBase.enableDownloadDeviceList = true;
						_0024performSetting_002416679 = PerformanceSetting.Instance;
						goto case 4;
					}
					PerformanceSettingBase.SetSpec("lo");
					PerformanceSettingBase.SetRezo("large");
					PerformanceSettingBase.SetKamcord("false");
					PerformanceSettingBase.SetRaidPlayerCap(2);
					goto IL_018b;
				case 4:
					if (!PerformanceSettingBase.checkSpec)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					if (!PerformanceSettingBase.checkRezo)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_018b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_018b:
					MerlinServer.Busy = true;
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

	private bool initCompleted;

	public bool debug_performanceSettting;

	public bool InitCompleted => initCompleted;

	public void Awake()
	{
		initCompleted = false;
		Application.targetFrameRate = 60;
		MerlinLocalNotification.activateNotification = false;
		NotificationUpdate.Regist();
		FacebookBridge.Init();
		PyxisBridge.InitializeFuckPyxis();
		DeletePartyTrackFiles();
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002416655(this).GetEnumerator();
	}

	private IEnumerator checkPerfrmance()
	{
		return new _0024checkPerfrmance_002416676().GetEnumerator();
	}

	private static void DeletePartyTrackFiles()
	{
		string persistentDataPath = Application.persistentDataPath;
		int i = 0;
		string[] array = new string[3] { "partytrack.sqlite", "partytrack.sqlite-shm", "partytrack.sqlite-wal" };
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			string path = Path.Combine(persistentDataPath, array[i]);
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
				}
				catch (Exception)
				{
				}
			}
		}
	}
}
