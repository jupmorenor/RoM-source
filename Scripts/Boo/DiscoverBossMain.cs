using System;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DiscoverBossMain : UIMain
{
	[Serializable]
	internal class _0024DiscoverRaidBoss_0024locals_002414499
	{
		internal CutSceneManager _0024cs;

		internal bool _0024resumeBgm;

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024endFunc;
	}

	[Serializable]
	internal class _0024DiscoverRaidBoss_0024closure_00243174
	{
		internal _0024DiscoverRaidBoss_0024locals_002414499 _0024_0024locals_002415096;

		public _0024DiscoverRaidBoss_0024closure_00243174(_0024DiscoverRaidBoss_0024locals_002414499 _0024_0024locals_002415096)
		{
			this._0024_0024locals_002415096 = _0024_0024locals_002415096;
		}

		public void Invoke()
		{
			_0024_0024locals_002415096._0024cs.IsResumeBgm = _0024_0024locals_002415096._0024resumeBgm;
			_0024_0024locals_002415096._0024endFunc();
		}
	}

	[NonSerialized]
	public static bool debugFlag;

	protected bool init;

	protected RespTCycleRaidBattle raid;

	public static bool DebugFlag
	{
		get
		{
			return debugFlag;
		}
		set
		{
			debugFlag = value;
		}
	}

	public override void SceneStart()
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			Initialize();
		});
	}

	public void Initialize()
	{
		raid = UserData.Current.userRaidInfo.raidBattle;
		if (raid == null)
		{
			SceneChanger.ChangeTo(SceneID.Town);
		}
		if (!debugFlag)
		{
			init = true;
		}
	}

	public override void SceneUpdate()
	{
		if (SceneChanger.isCompletelyReady && init)
		{
			init = false;
			if (!DiscoverRaidBoss(gameObject, raid, EndDemo))
			{
				EndDemo();
			}
		}
	}

	public void EndDemo()
	{
		SceneChanger.ChangeTo(SceneID.Town);
	}

	public void OnGUI()
	{
		if (debugFlag && GUILayout.Button("Start Boss Discover CutScene"))
		{
			init = true;
			debugFlag = false;
		}
	}

	public static bool DiscoverRaidBoss(GameObject gameObject, RespTCycleRaidBattle raidBattle, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endFunc)
	{
		return raidBattle != null && DiscoverRaidBoss(gameObject, raidBattle.MMonsterId, endFunc);
	}

	public static bool DiscoverRaidBoss(GameObject gameObject, int mobId, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endFunc)
	{
		_0024DiscoverRaidBoss_0024locals_002414499 _0024DiscoverRaidBoss_0024locals_0024 = new _0024DiscoverRaidBoss_0024locals_002414499();
		_0024DiscoverRaidBoss_0024locals_0024._0024endFunc = endFunc;
		MRaidBattles mRaidBattles = MRaidBattles.FindByMonster(mobId);
		int result;
		if (mRaidBattles == null)
		{
			result = 0;
		}
		else
		{
			string radomDiscoveryCutScenes = mRaidBattles.GetRadomDiscoveryCutScenes();
			if (string.IsNullOrEmpty(radomDiscoveryCutScenes))
			{
				result = 0;
			}
			else
			{
				CutSceneManager.Instance.autoStartFlag = true;
				_0024DiscoverRaidBoss_0024locals_0024._0024cs = CutSceneManager.CutSceneEx(radomDiscoveryCutScenes, gameObject, radomDiscoveryCutScenes, autoStart: true);
				if ((bool)_0024DiscoverRaidBoss_0024locals_0024._0024cs)
				{
					_0024DiscoverRaidBoss_0024locals_0024._0024resumeBgm = _0024DiscoverRaidBoss_0024locals_0024._0024cs.IsResumeBgm;
					_0024DiscoverRaidBoss_0024locals_0024._0024cs.IsResumeBgm = false;
					_0024DiscoverRaidBoss_0024locals_0024._0024cs.CloseHandler = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024DiscoverRaidBoss_0024closure_00243174(_0024DiscoverRaidBoss_0024locals_0024).Invoke);
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
		}
		return (byte)result != 0;
	}

	internal void _0024SceneStart_0024closure_00243173()
	{
		Initialize();
	}
}
