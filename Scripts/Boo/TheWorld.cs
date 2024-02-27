using System;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class TheWorld
{
	[Serializable]
	public class WorldStopInfo
	{
		public object orderObj;

		private ICallable _stopFunc;

		private ICallable _restartFunc;

		public ICallable stopFunc
		{
			get
			{
				return _stopFunc;
			}
			set
			{
				_stopFunc = value;
			}
		}

		public ICallable restartFunc
		{
			get
			{
				return _restartFunc;
			}
			set
			{
				_restartFunc = value;
			}
		}
	}

	[Serializable]
	internal class _0024StopWorldForTalk_0024locals_002414457
	{
		internal bool _0024oldStopMove;

		internal NPCControl _0024npc;
	}

	[Serializable]
	internal class _0024StopWorldForTalk_0024closure_00242986
	{
		internal _0024StopWorldForTalk_0024locals_002414457 _0024_0024locals_002415011;

		public _0024StopWorldForTalk_0024closure_00242986(_0024StopWorldForTalk_0024locals_002414457 _0024_0024locals_002415011)
		{
			this._0024_0024locals_002415011 = _0024_0024locals_002415011;
		}

		public void Invoke()
		{
			StopWorldWithoutCharacters();
			SleepCharactersWithoutNPC();
			if (_0024_0024locals_002415011._0024npc != null)
			{
				_0024_0024locals_002415011._0024npc.StopMove = true;
			}
		}
	}

	[Serializable]
	internal class _0024StopWorldForTalk_0024closure_00242987
	{
		internal _0024StopWorldForTalk_0024locals_002414457 _0024_0024locals_002415012;

		public _0024StopWorldForTalk_0024closure_00242987(_0024StopWorldForTalk_0024locals_002414457 _0024_0024locals_002415012)
		{
			this._0024_0024locals_002415012 = _0024_0024locals_002415012;
		}

		public void Invoke()
		{
			RestartWorldWithoutCharacters();
			AwakeCharactersWithoutNPC();
			if (_0024_0024locals_002415012._0024npc != null)
			{
				_0024_0024locals_002415012._0024npc.StopMove = _0024_0024locals_002415012._0024oldStopMove;
			}
		}
	}

	[NonSerialized]
	private static ICallable PauseMethod;

	[NonSerialized]
	private static ICallable RestartMethod;

	[NonSerialized]
	private static AnimationStopper animationStopper = new AnimationStopper();

	[NonSerialized]
	private static NPCStopper npcStopper = new NPCStopper();

	[NonSerialized]
	private static WorldStopInfo pauseStop;

	public static bool WorldIsStopped => RestartMethod != null;

	public static void Init()
	{
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(delegate
		{
			if (pauseStop != null)
			{
				pauseStop.restartFunc.Call(new object[0]);
				pauseStop = null;
			}
			if (RestartMethod != null)
			{
				RestartMethod.Call(new object[0]);
				RestartMethod = null;
			}
			PauseMethod = null;
		});
	}

	public static void RestartWorld()
	{
		if (RestartMethod != null)
		{
			RestartMethod.Call(new object[0]);
			RestartMethod = null;
			PauseMethod = null;
		}
	}

	public static void RestartWorldForPause()
	{
		if (pauseStop != null)
		{
			pauseStop.restartFunc.Call(new object[0]);
			pauseStop = null;
			if (PauseMethod != null)
			{
				PauseMethod.Call(new object[0]);
			}
		}
	}

	public static void StopWorldForPause()
	{
		if (pauseStop != null)
		{
			return;
		}
		WorldStopInfo worldStopInfo = new WorldStopInfo();
		worldStopInfo.stopFunc = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			StopWorldWithoutCharacters();
			StopCharacters();
			if ((bool)CutSceneManager.CurrentInstance)
			{
				CutSceneManager.CurrentInstance.pause = true;
			}
		};
		worldStopInfo.restartFunc = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RestartWorldWithoutCharacters();
			RestartCharacters();
			if ((bool)CutSceneManager.CurrentInstance)
			{
				CutSceneManager.CurrentInstance.pause = false;
			}
		};
		worldStopInfo.stopFunc.Call(new object[0]);
		pauseStop = worldStopInfo;
	}

	public static void StopWorldAll(object orderObj)
	{
		if (!WorldIsStopped)
		{
			WorldStopInfo worldStopInfo = new WorldStopInfo();
			worldStopInfo.orderObj = orderObj;
			PauseMethod = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				StopWorldWithoutCharacters();
				StopCharacters();
			};
			PauseMethod.Call(new object[0]);
			RestartMethod = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RestartWorldWithoutCharacters();
				RestartCharacters();
			};
		}
	}

	public static void StopWorldForCutscene(object orderObj)
	{
		if (!WorldIsStopped)
		{
			PauseMethod = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				StopWorldWithoutCharacters();
				SleepCharactersWithoutNPC();
				SleepNPC();
			};
			PauseMethod.Call(new object[0]);
			RestartMethod = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RestartWorldWithoutCharacters();
				AwakeCharactersWithoutNPC();
				AwakeNPC();
			};
		}
	}

	public static void StopWorldForTalk(object orderObj, NPCControl npc)
	{
		_0024StopWorldForTalk_0024locals_002414457 _0024StopWorldForTalk_0024locals_0024 = new _0024StopWorldForTalk_0024locals_002414457();
		_0024StopWorldForTalk_0024locals_0024._0024npc = npc;
		if (!WorldIsStopped)
		{
			if (_0024StopWorldForTalk_0024locals_0024._0024npc != null)
			{
				_0024StopWorldForTalk_0024locals_0024._0024oldStopMove = _0024StopWorldForTalk_0024locals_0024._0024npc.StopMove;
			}
			PauseMethod = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024StopWorldForTalk_0024closure_00242986(_0024StopWorldForTalk_0024locals_0024).Invoke);
			PauseMethod.Call(new object[0]);
			RestartMethod = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024StopWorldForTalk_0024closure_00242987(_0024StopWorldForTalk_0024locals_0024).Invoke);
		}
	}

	private static void StopCharacters()
	{
		int i = 0;
		D540ScriptRunner[] array = (D540ScriptRunner[])UnityEngine.Object.FindObjectsOfType(typeof(D540ScriptRunner));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].EnabledUpdate = false;
			}
			int j = 0;
			MerlinActionControl[] array2 = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].Pause = true;
			}
			int k = 0;
			PlayerControl[] array3 = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
			for (int length3 = array3.Length; k < length3; k++)
			{
				array3[k].InputActive = false;
			}
			npcStopper.stop(null);
			animationStopper.stop();
		}
	}

	private static void RestartCharacters()
	{
		animationStopper.restart();
		int i = 0;
		D540ScriptRunner[] array = (D540ScriptRunner[])UnityEngine.Object.FindObjectsOfType(typeof(D540ScriptRunner));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].EnabledUpdate = true;
			}
			int j = 0;
			MerlinActionControl[] array2 = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].Pause = false;
			}
			int k = 0;
			PlayerControl[] array3 = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
			for (int length3 = array3.Length; k < length3; k++)
			{
				array3[k].forceToIdle();
				array3[k].InputActive = true;
			}
			npcStopper.restart();
		}
	}

	private static void SleepCharactersWithoutNPC()
	{
		int i = 0;
		MerlinActionControl[] array = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].forceToIdle();
			}
			int j = 0;
			PlayerControl[] array2 = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].InputActive = false;
			}
		}
	}

	private static void AwakeCharactersWithoutNPC()
	{
		int i = 0;
		MerlinActionControl[] array = (MerlinActionControl[])UnityEngine.Object.FindObjectsOfType(typeof(MerlinActionControl));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].forceToIdle();
			}
			int j = 0;
			PlayerControl[] array2 = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].InputActive = true;
			}
		}
	}

	private static void SleepNPC()
	{
		npcStopper.stop(null);
	}

	private static void AwakeNPC()
	{
		npcStopper.restart();
	}

	private static void StopWorldWithoutCharacters()
	{
		int i = 0;
		ParticleEmitter[] array = (ParticleEmitter[])UnityEngine.Object.FindObjectsOfType(typeof(ParticleEmitter));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].enabled = false;
			}
			int j = 0;
			rampDownParticle[] array2 = (rampDownParticle[])UnityEngine.Object.FindObjectsOfType(typeof(rampDownParticle));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].pause = true;
			}
			int k = 0;
			moveThis[] array3 = (moveThis[])UnityEngine.Object.FindObjectsOfType(typeof(moveThis));
			for (int length3 = array3.Length; k < length3; k++)
			{
				array3[k].pause = true;
			}
			int l = 0;
			destroyThisTimed[] array4 = (destroyThisTimed[])UnityEngine.Object.FindObjectsOfType(typeof(destroyThisTimed));
			for (int length4 = array4.Length; l < length4; l++)
			{
				array4[l].pause = true;
			}
			int m = 0;
			ThrowObject[] array5 = (ThrowObject[])UnityEngine.Object.FindObjectsOfType(typeof(ThrowObject));
			for (int length5 = array5.Length; m < length5; m++)
			{
				array5[m].pause = false;
			}
			int n = 0;
			Camera[] array6 = (Camera[])UnityEngine.Object.FindObjectsOfType(typeof(Camera));
			for (int length6 = array6.Length; n < length6; n++)
			{
				UITweener[] components = array6[n].GetComponents<UITweener>();
				int num = 0;
				UITweener[] array7 = components;
				for (int length7 = array7.Length; num < length7; num++)
				{
					array7[num].enabled = false;
				}
				iTween[] components2 = array6[n].GetComponents<iTween>();
				int num2 = 0;
				iTween[] array8 = components2;
				for (int length8 = array8.Length; num2 < length8; num2++)
				{
					array8[num2].enabled = false;
				}
			}
			BattleUtil.ActivateAllComponents<MapetSpeak>(onoff: false);
			QuestBattleStarter.SetInBattleTimeScaleIfBattleNow(0f);
			BattleHUD.ActivateAllButtons(b: false);
			GameObject gameObject = GameObject.Find("Ef_HelixHealing(Clone)");
			if ((bool)gameObject)
			{
				ParticleEmitter[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleEmitter>(includeInactive: true);
				int num3 = 0;
				ParticleEmitter[] array9 = componentsInChildren;
				for (int length9 = array9.Length; num3 < length9; num3++)
				{
					array9[num3].enabled = true;
				}
				rampDownParticle[] componentsInChildren2 = gameObject.GetComponentsInChildren<rampDownParticle>(includeInactive: true);
				int num4 = 0;
				rampDownParticle[] array10 = componentsInChildren2;
				for (int length10 = array10.Length; num4 < length10; num4++)
				{
					array10[num4].pause = false;
				}
				moveThis[] componentsInChildren3 = gameObject.GetComponentsInChildren<moveThis>(includeInactive: true);
				int num5 = 0;
				moveThis[] array11 = componentsInChildren3;
				for (int length11 = array11.Length; num5 < length11; num5++)
				{
					array11[num5].pause = false;
				}
				destroyThisTimed[] componentsInChildren4 = gameObject.GetComponentsInChildren<destroyThisTimed>(includeInactive: true);
				int num6 = 0;
				destroyThisTimed[] array12 = componentsInChildren4;
				for (int length12 = array12.Length; num6 < length12; num6++)
				{
					array12[num6].pause = false;
				}
				ThrowObject[] componentsInChildren5 = gameObject.GetComponentsInChildren<ThrowObject>(includeInactive: true);
				int num7 = 0;
				ThrowObject[] array13 = componentsInChildren5;
				for (int length13 = array13.Length; num7 < length13; num7++)
				{
					array13[num7].pause = false;
				}
			}
		}
	}

	private static void RestartWorldWithoutCharacters()
	{
		BattleHUD.ActivateAllButtons(b: true);
		QuestBattleStarter.SetInBattleTimeScaleIfBattleNow(1f);
		BattleUtil.ActivateAllComponents<MapetSpeak>(onoff: true);
		int i = 0;
		ThrowObject[] array = (ThrowObject[])UnityEngine.Object.FindObjectsOfType(typeof(ThrowObject));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				array[i].pause = false;
			}
			int j = 0;
			destroyThisTimed[] array2 = (destroyThisTimed[])UnityEngine.Object.FindObjectsOfType(typeof(destroyThisTimed));
			for (int length2 = array2.Length; j < length2; j++)
			{
				array2[j].pause = false;
			}
			int k = 0;
			moveThis[] array3 = (moveThis[])UnityEngine.Object.FindObjectsOfType(typeof(moveThis));
			for (int length3 = array3.Length; k < length3; k++)
			{
				array3[k].pause = false;
			}
			int l = 0;
			rampDownParticle[] array4 = (rampDownParticle[])UnityEngine.Object.FindObjectsOfType(typeof(rampDownParticle));
			for (int length4 = array4.Length; l < length4; l++)
			{
				array4[l].pause = false;
			}
			int m = 0;
			ParticleEmitter[] array5 = (ParticleEmitter[])UnityEngine.Object.FindObjectsOfType(typeof(ParticleEmitter));
			for (int length5 = array5.Length; m < length5; m++)
			{
				array5[m].enabled = true;
			}
			int n = 0;
			Camera[] array6 = (Camera[])UnityEngine.Object.FindObjectsOfType(typeof(Camera));
			for (int length6 = array6.Length; n < length6; n++)
			{
				UITweener[] components = array6[n].GetComponents<UITweener>();
				int num = 0;
				UITweener[] array7 = components;
				for (int length7 = array7.Length; num < length7; num++)
				{
					array7[num].enabled = false;
				}
				iTween[] components2 = array6[n].GetComponents<iTween>();
				int num2 = 0;
				iTween[] array8 = components2;
				for (int length8 = array8.Length; num2 < length8; num2++)
				{
					array8[num2].enabled = false;
				}
			}
		}
	}

	internal static void _0024Init_0024closure_00242979()
	{
		if (pauseStop != null)
		{
			pauseStop.restartFunc.Call(new object[0]);
			pauseStop = null;
		}
		if (RestartMethod != null)
		{
			RestartMethod.Call(new object[0]);
			RestartMethod = null;
		}
		PauseMethod = null;
	}

	internal static void _0024StopWorldForPause_0024closure_00242980()
	{
		StopWorldWithoutCharacters();
		StopCharacters();
		if ((bool)CutSceneManager.CurrentInstance)
		{
			CutSceneManager.CurrentInstance.pause = true;
		}
	}

	internal static void _0024StopWorldForPause_0024closure_00242981()
	{
		RestartWorldWithoutCharacters();
		RestartCharacters();
		if ((bool)CutSceneManager.CurrentInstance)
		{
			CutSceneManager.CurrentInstance.pause = false;
		}
	}

	internal static void _0024StopWorldAll_0024closure_00242982()
	{
		StopWorldWithoutCharacters();
		StopCharacters();
	}

	internal static void _0024StopWorldAll_0024closure_00242983()
	{
		RestartWorldWithoutCharacters();
		RestartCharacters();
	}

	internal static void _0024StopWorldForCutscene_0024closure_00242984()
	{
		StopWorldWithoutCharacters();
		SleepCharactersWithoutNPC();
		SleepNPC();
	}

	internal static void _0024StopWorldForCutscene_0024closure_00242985()
	{
		RestartWorldWithoutCharacters();
		AwakeCharactersWithoutNPC();
		AwakeNPC();
	}
}
