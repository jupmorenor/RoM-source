using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SQEX_SoundPlayer : MonoBehaviour
{
	public class SoundBank
	{
		public string name;

		public int bankID;

		public int referenceCount;
	}

	public class PlayingSound
	{
		public int bankId;

		public int soundId;

		public float startVolume;

		public float curVolume;

		public float endVolume;

		public float volumeMSec;

		public float curVolumeMSec;

		public bool stopFlag;

		public int loop;

		public int count;
	}

	public class PlayingBgm
	{
		public PlayingSound ps = new PlayingSound();

		public string name;
	}

	private const string prefabPath = "Prefab/Sound/SoundManager";

	public const string bgmFolder = "Sound/BGM";

	public const string seFolder = "Sound/SE";

	public const string assetBundleName = "";

	public const int INVALID_BANK_ID = 0;

	public const int INVALID_SOUND_ID = 0;

	private static SQEX_SoundPlayer instance;

	public Dictionary<int, SoundBank> seBankList = new Dictionary<int, SoundBank>();

	public Dictionary<int, int> seSeError = new Dictionary<int, int>();

	private List<PlayingSound> sePlayList = new List<PlayingSound>();

	private List<PlayingBgm> bgmPlayList = new List<PlayingBgm>();

	public string startBgm;

	public string lastBgm;

	public int lastBgmLoop = -1;

	public float lastBgmVol = 1f;

	public float lastBgmPan;

	public bool enableBgm = true;

	public int bgmLoopCount = -1;

	public static float seVolume = 1f;

	public static float bgmVolume = 1f;

	public static float masterVolume = 1f;

	public static float masterBgmVolume = 1f;

	public static float reqMasterBgmVolume = 1f;

	public static float masterSeVolume = 1f;

	public static float reqMasterSeVolume = 1f;

	private static bool quitApp;

	private static bool pauseApp;

	private bool mute;

	private float cacheVolume = 1f;

	private int m_soundID;

	private float lastRealTime;

	private float delta;

	private float realTime;

	private bool m_isInitialized;

	private string m_bgmID;

	public int sameTimimgSeCount = 16;

	public int bgmSoundId;

	public static SQEX_SoundPlayer Instance
	{
		get
		{
			if (quitApp)
			{
				return null;
			}
			if (instance == null)
			{
				instance = UnityEngine.Object.FindObjectOfType(typeof(SQEX_SoundPlayer)) as SQEX_SoundPlayer;
				if (instance == null)
				{
					GameObject gameObject = GameObject.Find("__SoundManager__");
					if (gameObject != null)
					{
						UnityEngine.Object.DestroyObject(gameObject);
					}
					UnityEngine.Object @object = Resources.Load("Prefab/Sound/SoundManager");
					gameObject = (GameObject)UnityEngine.Object.Instantiate((GameObject)@object);
					gameObject.name = "__SoundManager__";
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					instance = gameObject.GetComponent<SQEX_SoundPlayer>();
				}
				else
				{
					GameObject gameObject2 = instance.gameObject;
					if (gameObject2.name != "__SoundManager__")
					{
						gameObject2.name = "__SoundManager__";
						UnityEngine.Object.DontDestroyOnLoad(gameObject2);
					}
				}
			}
			return instance;
		}
		set
		{
			instance = value;
			GameObject gameObject = instance.gameObject;
			if (gameObject.name != "__SoundManager__")
			{
				gameObject.name = "__SoundManager__";
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}
	}

	public int BgmLoopCount
	{
		get
		{
			return bgmLoopCount;
		}
		set
		{
			bgmLoopCount = value;
			if (bgmLoopCount < -1)
			{
				bgmLoopCount = -1;
			}
		}
	}

	public static float SeVolume
	{
		get
		{
			return seVolume;
		}
		set
		{
			seVolume = value;
			if (seVolume < 0f)
			{
				seVolume = 0f;
			}
			else if (seVolume > 1f)
			{
				seVolume = 1f;
			}
			if (instance != null)
			{
				instance.SetSeVoulme(CurSeVolume);
			}
		}
	}

	public static float CurSeVolume => seVolume * masterSeVolume;

	public static float BgmVolume
	{
		get
		{
			return bgmVolume;
		}
		set
		{
			bgmVolume = value;
			if (bgmVolume < 0f)
			{
				bgmVolume = 0f;
			}
			else if (bgmVolume > 1f)
			{
				bgmVolume = 1f;
			}
			if (instance != null)
			{
				instance.SetBgmVoulme(CurBgmVolume);
			}
		}
	}

	public static float CurBgmVolume => bgmVolume * masterBgmVolume;

	public static float MasterVolume
	{
		get
		{
			return masterVolume;
		}
		set
		{
			masterVolume = value;
			if (masterVolume < 0f)
			{
				masterVolume = 0f;
			}
			else if (masterVolume > 1f)
			{
				masterVolume = 1f;
			}
			if (instance != null)
			{
				instance.SetBgmVoulme(CurBgmVolume);
				instance.SetSeVoulme(CurSeVolume);
			}
		}
	}

	public static float MasterBgmVolume
	{
		get
		{
			return masterBgmVolume;
		}
		set
		{
			reqMasterBgmVolume = value;
			if (reqMasterBgmVolume < 0f)
			{
				reqMasterBgmVolume = 0f;
			}
			else if (reqMasterBgmVolume > 1f)
			{
				reqMasterBgmVolume = 1f;
			}
		}
	}

	public static float MasterSeVolume
	{
		get
		{
			return masterSeVolume;
		}
		set
		{
			reqMasterSeVolume = value;
			if (reqMasterSeVolume < 0f)
			{
				reqMasterSeVolume = 0f;
			}
			else if (reqMasterSeVolume > 1f)
			{
				reqMasterSeVolume = 1f;
			}
		}
	}

	public bool IsMute
	{
		get
		{
			return mute;
		}
		set
		{
			if (mute != value)
			{
				mute = value;
				if (mute)
				{
					cacheVolume = MasterVolume;
					MasterVolume = 0f;
				}
				else
				{
					MasterVolume = cacheVolume;
				}
			}
		}
	}

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_Create(string config);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_Release();

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_StartTimerMSEC(int intervalTimeMSec, int priority);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_StartTimerVSYNC(int intervalTimeMSec, int priority);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_AddData(IntPtr scdBin);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_RemoveData(int bankID);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_RemoveDataSync(int bankID, int sync);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_CreateSound(int bankID, int soundIndex);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_CreateSoundWithExternalID(int bankID, int soundIndex, int externalID);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_SoundCtrl_Start(int soundID, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_Stop(int soundID, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_SoundCtrl_IsExist(int soundID);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_SetPause(int soundID, int pauseOn, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern int SdSoundSystem_SoundCtrl_IsPaused(int soundID);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_SetVolume(int soundID, float volume, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern float SdSoundSystem_SoundCtrl_GetVolume(int soundID);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_SetPitch(int soundID, float pitch, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_SetPanning(int soundID, float panning, int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_SoundCtrl_SetLowPass(int soundID, float value);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_StopAllSounds(int transTimeMSec);

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_Suspend();

	[DllImport("sdlib_android")]
	private static extern void SdSoundSystem_Resume();

	public bool IsLastBgm(string bgmFile)
	{
		return lastBgm == bgmFile || lastBgm == bgmFile + ".android.akb.bytes";
	}

	public static void SetMasterBgmVolume(float vol)
	{
		masterBgmVolume = vol;
		if (masterBgmVolume < 0f)
		{
			masterBgmVolume = 0f;
		}
		else if (masterBgmVolume > 1f)
		{
			masterBgmVolume = 1f;
		}
		if (instance != null)
		{
			instance.SetBgmVoulme(CurBgmVolume);
		}
	}

	public static void SetMasterSeVolume(float vol)
	{
		masterSeVolume = vol;
		if (masterSeVolume < 0f)
		{
			masterSeVolume = 0f;
		}
		else if (masterSeVolume > 1f)
		{
			masterSeVolume = 1f;
		}
		if (instance != null)
		{
			instance.SetSeVoulme(CurSeVolume);
		}
	}

	public void Start()
	{
		if (quitApp)
		{
			UnityEngine.Object.DestroyImmediate(base.gameObject);
			return;
		}
		if (instance != null && instance != this)
		{
			UnityEngine.Object.DestroyObject(base.gameObject);
			return;
		}
		if (instance == null)
		{
			Instance = this;
			seBankList.Clear();
			seSeError.Clear();
			sePlayList.Clear();
		}
		InitializePlugin();
		LoadSe(216, "se_system_cursor");
		LoadSe(218, "se_system_cansel");
		LoadSe(217, "se_system_fix");
		PlayBgm(startBgm, bgmLoopCount);
	}

	public void Update()
	{
		if (reqMasterBgmVolume != masterBgmVolume)
		{
			SetMasterBgmVolume(reqMasterBgmVolume);
		}
		if (reqMasterSeVolume != masterSeVolume)
		{
			SetMasterSeVolume(reqMasterSeVolume);
		}
		realTime = Time.realtimeSinceStartup;
		if (lastRealTime > 0f)
		{
			delta = (realTime - lastRealTime) * 1000f;
		}
		lastRealTime = realTime;
		if (!m_isInitialized)
		{
			return;
		}
		for (int i = 0; i < bgmPlayList.Count; i++)
		{
			PlayingBgm playingBgm = bgmPlayList[i];
			if (!PlayingSoundUpdate(playingBgm.ps) || playingBgm.ps.soundId == 0)
			{
				UnregisterBgmBank(playingBgm);
				bgmPlayList.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < sePlayList.Count; j++)
		{
			PlayingSound playingSound = sePlayList[j];
			if (!PlayingSoundUpdate(playingSound) || playingSound.soundId == 0)
			{
				sePlayList.RemoveAt(j);
			}
		}
	}

	public void OnDestroy()
	{
		if (instance == this)
		{
			for (int i = 0; i < bgmPlayList.Count; i++)
			{
				PlayingBgm playingBgm = bgmPlayList[i];
				StopSound(playingBgm.ps);
				UnregisterBgmBank(playingBgm);
			}
			StopAllSe();
			UnregisterSeBank();
			FinalizePlugin();
		}
	}

	public void OnApplicationQuit()
	{
		quitApp = true;
		OnDestroy();
	}

	public void OnApplicationPause(bool pause)
	{
		if (!m_isInitialized)
		{
			return;
		}
		try
		{
			if (pause)
			{
				if (!pauseApp)
				{
					pauseApp = true;
					SdSoundSystem_Suspend();
				}
			}
			else if (pauseApp)
			{
				pauseApp = false;
				SdSoundSystem_Resume();
			}
		}
		catch (Exception)
		{
		}
	}

	private bool InitializePlugin()
	{
		if (m_isInitialized)
		{
			return true;
		}
		m_isInitialized = true;
		int num = SdSoundSystem_Create(string.Empty);
		if (num < 0)
		{
			return false;
		}
		int intervalTimeMSec = 16;
		int priority = -1;
		SdSoundSystem_StartTimerMSEC(intervalTimeMSec, priority);
		SdSoundSystem_StartTimerVSYNC(intervalTimeMSec, priority);
		return true;
	}

	private void FinalizePlugin()
	{
		if (m_isInitialized)
		{
			SdSoundSystem_StopAllSounds(0);
			SdSoundSystem_Release();
			m_isInitialized = false;
		}
	}

	public static string GetOsSoundFile(string file)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.OSXEditor)
		{
			return file + ".android.akb";
		}
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			return file + ".android.akb";
		}
		return null;
	}

	private void RegisterBgmBank(TextAsset textAsset, string resourceID, PlayingBgm pb)
	{
		if (pb == null)
		{
			return;
		}
		if (textAsset == null)
		{
			resourceID = GetOsSoundFile(resourceID);
			textAsset = Resources.Load(resourceID) as TextAsset;
		}
		if (!(null == textAsset))
		{
			byte[] bytes = textAsset.bytes;
			IntPtr intPtr = Marshal.AllocHGlobal(textAsset.bytes.Length);
			Marshal.Copy(bytes, 0, intPtr, textAsset.bytes.Length);
			int bankId = SdSoundSystem_AddData(intPtr);
			if (IntPtr.Zero != intPtr)
			{
				Marshal.FreeHGlobal(intPtr);
				intPtr = IntPtr.Zero;
			}
			pb.name = resourceID;
			pb.ps.bankId = bankId;
			m_bgmID = resourceID;
		}
	}

	private void UnregisterBgmBank(PlayingBgm pb)
	{
		if (pb != null)
		{
			if (pb.ps.bankId != 0)
			{
				SdSoundSystem_RemoveDataSync(pb.ps.bankId, 1);
				pb.ps.bankId = 0;
			}
			m_bgmID = null;
		}
	}

	private int RegisterSeBank(int index, string resourceID)
	{
		if (seBankList.ContainsKey(index))
		{
			return index;
		}
		resourceID = GetOsSoundFile(resourceID);
		TextAsset textAsset = Resources.Load(resourceID) as TextAsset;
		byte[] scdBytes = null;
		if (textAsset != null)
		{
			scdBytes = textAsset.bytes;
		}
		return RegisterSeBankFromBytes(index, resourceID, scdBytes);
	}

	public int RegisterSeBankFromBytes(int index, string resourceID, byte[] scdBytes)
	{
		SoundBank soundBank = null;
		if (seBankList.ContainsKey(index))
		{
			soundBank = seBankList[index];
			if (soundBank != null)
			{
				soundBank.referenceCount++;
				return soundBank.bankID;
			}
		}
		IntPtr zero = IntPtr.Zero;
		int num = -1;
		soundBank = new SoundBank();
		if (scdBytes != null && soundBank != null)
		{
			zero = Marshal.AllocHGlobal(scdBytes.Length);
			Marshal.Copy(scdBytes, 0, zero, scdBytes.Length);
			num = SdSoundSystem_AddData(zero);
			if (IntPtr.Zero != zero)
			{
				Marshal.FreeHGlobal(zero);
			}
			soundBank.bankID = num;
			soundBank.referenceCount = 1;
		}
		soundBank.name = resourceID;
		seBankList[index] = soundBank;
		return num;
	}

	public bool UnregisterSeBank(int seId, bool froceUnregister = false)
	{
		if (!seBankList.ContainsKey(seId))
		{
			return false;
		}
		SoundBank soundBank = seBankList[seId];
		if (soundBank == null)
		{
			seBankList.Remove(seId);
			return true;
		}
		soundBank.referenceCount--;
		if (soundBank.referenceCount > 0 && !froceUnregister)
		{
			return true;
		}
		SdSoundSystem_RemoveDataSync(soundBank.bankID, 1);
		seBankList.Remove(seId);
		return true;
	}

	public bool IsLoadSe(int id)
	{
		if (seBankList.ContainsKey(id))
		{
			SoundBank soundBank = seBankList[id];
			if (soundBank != null)
			{
				return soundBank.bankID >= 0;
			}
		}
		return false;
	}

	public bool IsLoadSe(string name)
	{
		if (!SQEX_SoundPlayerData.seNames.ContainsKey(name))
		{
			return false;
		}
		int id = SQEX_SoundPlayerData.seNames[name];
		return IsLoadSe(id);
	}

	private void UnregisterSeBank()
	{
		int[] array = new int[seBankList.Keys.Count];
		seBankList.Keys.CopyTo(array, 0);
		int[] array2 = array;
		foreach (int seId in array2)
		{
			UnregisterSeBank(seId, froceUnregister: true);
		}
		seBankList.Clear();
	}

	public bool LoadSe(int seIndex)
	{
		if (seIndex < 0 || SQEX_SoundPlayerData.seList.Length <= seIndex)
		{
			return false;
		}
		string text = SQEX_SoundPlayerData.seList[seIndex];
		return RegisterSeBank(seIndex, "Sound/SE/" + text) >= 0;
	}

	public bool LoadSe(int seIndex, string seName)
	{
		return RegisterSeBank(seIndex, "Sound/SE/" + seName) >= 0;
	}

	public bool UnloadSeType(int seType)
	{
		if (!SQEX_SoundPlayerData.seTypes.ContainsKey(seType))
		{
			return false;
		}
		int[] array = SQEX_SoundPlayerData.seTypes[seType];
		int num = 0;
		int[] array2 = array;
		foreach (int num2 in array2)
		{
			if (num2 >= 0 && SQEX_SoundPlayerData.seList.Length > num2 && UnregisterSeBank(num2))
			{
				num++;
			}
		}
		return num > 0;
	}

	public bool UnloadSeGroup(string seGroup)
	{
		if (!SQEX_SoundPlayerData.seGroups.ContainsKey(seGroup))
		{
			return false;
		}
		int[] array = SQEX_SoundPlayerData.seGroups[seGroup];
		int num = 0;
		int[] array2 = array;
		foreach (int num2 in array2)
		{
			if (num2 >= 0 && SQEX_SoundPlayerData.seList.Length > num2 && UnregisterSeBank(num2))
			{
				num++;
			}
		}
		return num > 0;
	}

	private int PlaySound(int seIndex, float vol = -1f, int extraId = -1)
	{
		int num = 0;
		num = ((extraId >= 0) ? SdSoundSystem_CreateSoundWithExternalID(seIndex, 0, extraId) : SdSoundSystem_CreateSound(seIndex, 0));
		if (num == 0)
		{
			return 0;
		}
		if (vol >= 0f)
		{
			if (vol > 1f)
			{
				vol = 1f;
			}
			SdSoundSystem_SoundCtrl_SetVolume(num, vol * masterVolume, 0);
		}
		SdSoundSystem_SoundCtrl_Start(num, 0);
		if (SdSoundSystem_SoundCtrl_IsExist(num) == 0)
		{
			return 0;
		}
		return num;
	}

	public bool StopSound(PlayingSound ps, int fadeOutMSec = 0)
	{
		if (ps == null)
		{
			return false;
		}
		if (ps.soundId == 0)
		{
			return false;
		}
		if (fadeOutMSec <= 0)
		{
			SdSoundSystem_SoundCtrl_Stop(ps.soundId, 0);
		}
		else
		{
			SetPlayingSoundVoulme(ps, 0f, fadeOutMSec, stopFlag: true);
		}
		return true;
	}

	private bool PlayingSoundUpdate(PlayingSound ps)
	{
		if (ps.soundId == 0)
		{
			return false;
		}
		if (!IsPlaySound(ps.soundId))
		{
			if (ps.loop > 0 || ps.loop < 0)
			{
				if (ps.loop > 0)
				{
					ps.loop--;
				}
				ps.soundId = PlaySound(ps.bankId);
			}
			else if (ps.loop == 0)
			{
				return false;
			}
		}
		if (ps.curVolumeMSec >= ps.volumeMSec)
		{
			ps.volumeMSec = 0f;
			ps.curVolumeMSec = 0f;
			SdSoundSystem_SoundCtrl_SetVolume(volume: (ps.curVolume = ps.endVolume) * masterVolume, soundID: ps.soundId, transTimeMSec: 0);
			if (ps.stopFlag)
			{
				SdSoundSystem_SoundCtrl_Stop(ps.soundId, 0);
				ps.soundId = 0;
				return false;
			}
		}
		else if (IsPlaySound(ps.soundId))
		{
			if (0f < ps.volumeMSec)
			{
				float num = ps.endVolume - ps.startVolume;
				num *= ps.curVolumeMSec / ps.volumeMSec;
				SdSoundSystem_SoundCtrl_SetVolume(volume: (ps.curVolume = num + ps.startVolume) * masterVolume, soundID: ps.soundId, transTimeMSec: 0);
			}
			ps.curVolumeMSec += delta;
		}
		ps.count++;
		return true;
	}

	private bool IsPlaySound(int soundID, bool checkPause = false)
	{
		if (soundID == 0)
		{
			return false;
		}
		if (SdSoundSystem_SoundCtrl_IsExist(soundID) != 0)
		{
			if (checkPause)
			{
				return !IsPauseSound(soundID);
			}
			return true;
		}
		return false;
	}

	private bool IsPauseSound(int soundID)
	{
		if (soundID == 0)
		{
			return false;
		}
		return SdSoundSystem_SoundCtrl_IsPaused(soundID) != 0;
	}

	public bool SetPlayingSoundVoulme(PlayingSound ps, float vol, int fadeMSec = 0, bool stopFlag = false)
	{
		if (ps == null)
		{
			return false;
		}
		if (ps.soundId == 0)
		{
			return false;
		}
		if (vol < 0f)
		{
			vol = 0f;
		}
		else if (vol > 1f)
		{
			vol = 1f;
		}
		ps.startVolume = ps.curVolume;
		ps.endVolume = vol;
		ps.volumeMSec = fadeMSec;
		ps.curVolumeMSec = 0f;
		ps.stopFlag = stopFlag;
		if (fadeMSec == 0)
		{
			SdSoundSystem_SoundCtrl_SetVolume(ps.soundId, vol * masterVolume, 0);
		}
		return true;
	}

	public int PlaySe(string name, int fadeInMSec = 0, int extraId = -1)
	{
		return PlaySeEx(name, fadeInMSec, extraId);
	}

	public int PlaySe(int seIndex, int fadeInMSec = 0, int extraId = -1)
	{
		return PlaySeEx(seIndex, fadeInMSec, extraId);
	}

	public int PlaySeEx(string name, int fadeInMSec = 0, int extraId = -1, int sameSoundCount = 2)
	{
		if (!SQEX_SoundPlayerData.seNames.ContainsKey(name))
		{
			return 0;
		}
		int seIndex = SQEX_SoundPlayerData.seNames[name];
		return PlaySeEx(seIndex, fadeInMSec, extraId, sameSoundCount);
	}

	public int PlaySeEx(int seIndex, int fadeInMSec = 0, int extraId = -1, int sameSoundCount = 2)
	{
		if (!seBankList.ContainsKey(seIndex))
		{
			SeError(seIndex);
			return 0;
		}
		SoundBank soundBank = seBankList[seIndex];
		if (soundBank == null)
		{
			SeError(seIndex);
			return 0;
		}
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			if (playingSound.bankId == soundBank.bankID && playingSound.count <= sameSoundCount)
			{
				return 0;
			}
		}
		int num = PlaySound(soundBank.bankID, CurSeVolume * masterVolume, extraId);
		if (num != 0)
		{
			float startVolume = 0f;
			if (fadeInMSec <= 0)
			{
				startVolume = CurSeVolume;
			}
			PlayingSound playingSound2 = new PlayingSound();
			playingSound2.bankId = soundBank.bankID;
			playingSound2.soundId = num;
			playingSound2.volumeMSec = fadeInMSec;
			playingSound2.curVolumeMSec = 0f;
			playingSound2.startVolume = startVolume;
			playingSound2.curVolume = 0f;
			playingSound2.endVolume = CurSeVolume;
			sePlayList.Add(playingSound2);
		}
		return num;
	}

	private void SeError(int seIndex)
	{
		int num = 0;
		if (seSeError.ContainsKey(seIndex))
		{
			num = seSeError[seIndex];
		}
		num++;
		seSeError[seIndex] = num;
	}

	public bool StopSe(int seIndex, int fadeOutMSec = 0)
	{
		if (seIndex < 0 || seIndex >= sePlayList.Count)
		{
			return false;
		}
		PlayingSound ps = sePlayList[seIndex];
		StopSound(ps, fadeOutMSec);
		return true;
	}

	public bool StopSeById(int soundID, int fadeOutMSec = 0)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			if (soundID == playingSound.soundId)
			{
				StopSound(playingSound, fadeOutMSec);
			}
		}
		return true;
	}

	public void StopAllSe(int fadeOutMSec = 0)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			StopSe(i, fadeOutMSec);
		}
	}

	public bool IsPlaySe(int soundID, bool checkPause = false)
	{
		return IsPlaySound(soundID, checkPause);
	}

	public bool IsPlayAllSe(bool checkPause = false)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			if (IsPlaySe(playingSound.soundId, checkPause))
			{
				return true;
			}
		}
		return false;
	}

	public bool PauseSe(int soundID, bool pause)
	{
		if (soundID == 0)
		{
			return false;
		}
		if (pause)
		{
			SdSoundSystem_SoundCtrl_SetPause(soundID, 1, 0);
		}
		else
		{
			SdSoundSystem_SoundCtrl_SetPause(soundID, 0, 0);
		}
		return true;
	}

	public void PauseAllSe(bool pause)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			PauseSe(playingSound.soundId, pause);
		}
	}

	public bool IsPauseSe(int soundID)
	{
		return IsPauseSound(soundID);
	}

	public bool SetSeVoulme(int soundID, float vol, int fadeMSec = 0)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			if (soundID == playingSound.soundId)
			{
				return SetPlayingSoundVoulme(playingSound, vol * CurSeVolume, fadeMSec);
			}
		}
		return false;
	}

	public void SetSeVoulme(float vol, int fadeMSec = 0)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound ps = sePlayList[i];
			SetPlayingSoundVoulme(ps, vol * CurSeVolume, fadeMSec);
		}
	}

	public void SetSePan(int soundID, float pan)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
			if (soundID == playingSound.soundId)
			{
			}
		}
	}

	public void SetSePan(float pan)
	{
		for (int i = 0; i < sePlayList.Count; i++)
		{
			PlayingSound playingSound = sePlayList[i];
		}
	}

	public int PlayBgm(int index, int loop = -1, int fadeInMSec = 0, int fadeOutMSec = 0)
	{
		if (index < 0 || SQEX_SoundPlayerData.bgmList.Length <= index)
		{
			return 0;
		}
		return PlayBgm(null, SQEX_SoundPlayerData.bgmList[index], loop, fadeInMSec, fadeOutMSec);
	}

	public int PlayBgm(string bgmName, int loop = -1, int fadeInMSec = 0, int fadeOutMSec = 0)
	{
		return PlayBgm(null, bgmName, loop, fadeInMSec, fadeOutMSec);
	}

	public int PlayBgm(TextAsset textAsset, string bgmName, int loop = -1, int fadeInMSec = 0, int fadeOutMSec = 0)
	{
		if (!enableBgm)
		{
			return 0;
		}
		if (string.IsNullOrEmpty(bgmName))
		{
			return 0;
		}
		string text = "Sound/BGM/" + bgmName;
		if (m_bgmID == GetOsSoundFile(text) && bgmSoundId != 0)
		{
			return bgmSoundId;
		}
		PlayingBgm playingBgm = null;
		float startVolume = 0f;
		if (lastBgm == bgmName && bgmPlayList.Count > 0)
		{
			playingBgm = bgmPlayList[bgmPlayList.Count - 1];
			bgmSoundId = playingBgm.ps.soundId;
			startVolume = playingBgm.ps.curVolume;
		}
		else
		{
			if (fadeOutMSec >= 0)
			{
				StopBgm(fadeOutMSec);
			}
			playingBgm = new PlayingBgm();
			bgmPlayList.Add(playingBgm);
			RegisterBgmBank(textAsset, text, playingBgm);
			bgmSoundId = PlaySound(playingBgm.ps.bankId, CurBgmVolume * masterVolume);
		}
		if (bgmSoundId != 0)
		{
			if (fadeInMSec <= 0)
			{
				startVolume = CurBgmVolume;
			}
			playingBgm.ps.soundId = bgmSoundId;
			playingBgm.ps.volumeMSec = fadeInMSec;
			playingBgm.ps.curVolumeMSec = 0f;
			playingBgm.ps.startVolume = startVolume;
			playingBgm.ps.curVolume = 0f;
			playingBgm.ps.endVolume = CurBgmVolume;
			playingBgm.ps.loop = loop;
			lastBgm = bgmName;
			lastBgmLoop = loop;
		}
		return bgmSoundId;
	}

	public bool StopBgm(int fadeOutMSec = 0)
	{
		int num = 0;
		for (int i = 0; i < bgmPlayList.Count; i++)
		{
			PlayingBgm playingBgm = bgmPlayList[i];
			if (playingBgm != null)
			{
				playingBgm.ps.loop = 0;
				if (StopSound(playingBgm.ps, fadeOutMSec))
				{
					num++;
				}
			}
		}
		return num > 0;
	}

	public bool IsPlayBgm(bool checkPause = false)
	{
		if (bgmPlayList.Count <= 0)
		{
			return false;
		}
		PlayingBgm playingBgm = bgmPlayList[bgmPlayList.Count - 1];
		if (playingBgm == null)
		{
			return false;
		}
		return IsPlaySound(playingBgm.ps.soundId, checkPause);
	}

	public bool PauseBgm(bool pause)
	{
		if (bgmPlayList.Count <= 0)
		{
			return false;
		}
		PlayingBgm playingBgm = bgmPlayList[bgmPlayList.Count - 1];
		if (playingBgm == null)
		{
			return false;
		}
		if (pause)
		{
			SdSoundSystem_SoundCtrl_SetPause(playingBgm.ps.soundId, 1, 0);
		}
		else
		{
			SdSoundSystem_SoundCtrl_SetPause(playingBgm.ps.soundId, 0, 0);
		}
		return true;
	}

	public bool IsPauseBgm()
	{
		if (bgmPlayList.Count <= 0)
		{
			return false;
		}
		PlayingBgm playingBgm = bgmPlayList[bgmPlayList.Count - 1];
		if (playingBgm == null)
		{
			return false;
		}
		return IsPauseSound(playingBgm.ps.soundId);
	}

	public bool SetBgmVoulme(float vol, int fadeMSec = 0)
	{
		if (bgmPlayList.Count <= 0)
		{
			return false;
		}
		PlayingBgm playingBgm = bgmPlayList[bgmPlayList.Count - 1];
		if (playingBgm == null)
		{
			return false;
		}
		bool result = SetPlayingSoundVoulme(playingBgm.ps, vol * CurBgmVolume, fadeMSec);
		lastBgmVol = vol;
		return result;
	}

	public bool SetBgmPan(float pan)
	{
		if (bgmPlayList.Count <= 0)
		{
			return false;
		}
		PlayingBgm playingBgm = bgmPlayList[bgmPlayList.Count - 1];
		if (playingBgm == null)
		{
			return false;
		}
		SdSoundSystem_SoundCtrl_SetPanning(playingBgm.ps.soundId, pan, 0);
		lastBgmPan = pan;
		return true;
	}
}
