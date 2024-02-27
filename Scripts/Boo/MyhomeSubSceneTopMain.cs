using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MyhomeSubSceneTopMain : UIMain
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupWaitFromNoMyhome_002421812 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameLevelManager _0024glMan_002421813;

			internal MyHomeMain _0024myhomeMain_002421814;

			internal GameUIRoot _0024gameUiRoot_002421815;

			internal Camera[] _0024cams_002421816;

			internal Camera _0024cam_002421817;

			internal EventWindow[] _0024evWnds_002421818;

			internal EventWindow _0024wnd_002421819;

			internal NpcTalkControl[] _0024npcTalks_002421820;

			internal NpcTalkControl _0024talk_002421821;

			internal NpcTalkControl _0024talk_002421822;

			internal string[] _0024keepObjs_002421823;

			internal string _0024keepObjName_002421824;

			internal string _0024trimName_002421825;

			internal GameObject _0024obj_002421826;

			internal NpcTalkControl _0024tmpNpcCtrl_002421827;

			internal int _0024_002411432_002421828;

			internal Camera[] _0024_002411433_002421829;

			internal int _0024_002411434_002421830;

			internal int _0024_002411436_002421831;

			internal EventWindow[] _0024_002411437_002421832;

			internal int _0024_002411438_002421833;

			internal int _0024_002411440_002421834;

			internal NpcTalkControl[] _0024_002411441_002421835;

			internal int _0024_002411442_002421836;

			internal int _0024_002411444_002421837;

			internal string[] _0024_002411445_002421838;

			internal int _0024_002411446_002421839;

			internal int _0024_002411448_002421840;

			internal NpcTalkControl[] _0024_002411449_002421841;

			internal int _0024_002411450_002421842;

			internal MyhomeSubSceneTopMain _0024self__002421843;

			public _0024(MyhomeSubSceneTopMain self_)
			{
				_0024self__002421843 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002421843.asyncOp != null)
						{
							SceneChanger.Instance().dontReveal = true;
							_0024self__002421843.fadeWait = true;
							_0024glMan_002421813 = GameLevelManager.Instance;
							goto case 2;
						}
						goto IL_05a3;
					case 2:
						if (GameLevelManager.isBusy)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						homeModels = new GameObject[0];
						goto case 3;
					case 3:
						if (!_0024self__002421843.asyncOp.isDone)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024myhomeMain_002421814 = (MyHomeMain)UnityEngine.Object.FindObjectOfType(typeof(MyHomeMain));
						if ((bool)_0024myhomeMain_002421814)
						{
							_0024myhomeMain_002421814.enabled = false;
						}
						_0024gameUiRoot_002421815 = (GameUIRoot)UnityEngine.Object.FindObjectOfType(typeof(GameUIRoot));
						if ((bool)_0024gameUiRoot_002421815)
						{
							UnityEngine.Object.DestroyObject(_0024gameUiRoot_002421815.gameObject);
						}
						_0024glMan_002421813.Setup(SceneIDModule.SceneIDToName(SceneID.Myhome));
						result = (YieldDefault(4) ? 1 : 0);
						break;
					case 4:
					case 5:
						if (GameLevelManager.isBusy)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						_0024cams_002421816 = (Camera[])UnityEngine.Object.FindObjectsOfType(typeof(Camera));
						_0024_002411432_002421828 = 0;
						_0024_002411433_002421829 = _0024cams_002421816;
						for (_0024_002411434_002421830 = _0024_002411433_002421829.Length; _0024_002411432_002421828 < _0024_002411434_002421830; _0024_002411432_002421828++)
						{
							if (_0024_002411433_002421829[_0024_002411432_002421828].depth <= 0f || _0024_002411433_002421829[_0024_002411432_002421828].gameObject.name == "MyhomeCamera")
							{
								_0024_002411433_002421829[_0024_002411432_002421828].enabled = false;
							}
						}
						_0024self__002421843.custom3DCamera.enabled = true;
						_0024self__002421843.custom2DCamera.enabled = true;
						_0024evWnds_002421818 = (EventWindow[])UnityEngine.Object.FindObjectsOfType(typeof(EventWindow));
						_0024_002411436_002421831 = 0;
						_0024_002411437_002421832 = _0024evWnds_002421818;
						for (_0024_002411438_002421833 = _0024_002411437_002421832.Length; _0024_002411436_002421831 < _0024_002411438_002421833; _0024_002411436_002421831++)
						{
							UnityEngine.Object.DestroyObject(_0024_002411437_002421832[_0024_002411436_002421831]);
						}
						_0024npcTalks_002421820 = (NpcTalkControl[])UnityEngine.Object.FindObjectsOfType(typeof(NpcTalkControl));
						_0024_002411440_002421834 = 0;
						_0024_002411441_002421835 = _0024npcTalks_002421820;
						for (_0024_002411442_002421836 = _0024_002411441_002421835.Length; _0024_002411440_002421834 < _0024_002411442_002421836; _0024_002411440_002421834++)
						{
							if ((bool)_0024_002411441_002421835[_0024_002411440_002421834])
							{
								_0024_002411441_002421835[_0024_002411440_002421834].gameObject.SetActive(value: true);
							}
						}
						result = (YieldDefault(6) ? 1 : 0);
						break;
					case 6:
						_0024_002411448_002421840 = 0;
						_0024_002411449_002421841 = _0024npcTalks_002421820;
						for (_0024_002411450_002421842 = _0024_002411449_002421841.Length; _0024_002411448_002421840 < _0024_002411450_002421842; _0024_002411448_002421840++)
						{
							if (_0024_002411449_002421841[_0024_002411448_002421840].talkNextScene == SceneChanger.CurrentSceneName && _0024_002411449_002421841[_0024_002411448_002421840].MNpcTalks != null)
							{
								_0024keepObjs_002421823 = _0024_002411449_002421841[_0024_002411448_002421840].MNpcTalks.NextSceneKeepObjects.Split(',');
								_0024_002411444_002421837 = 0;
								_0024_002411445_002421838 = _0024keepObjs_002421823;
								for (_0024_002411446_002421839 = _0024_002411445_002421838.Length; _0024_002411444_002421837 < _0024_002411446_002421839; _0024_002411444_002421837++)
								{
									_0024trimName_002421825 = _0024_002411445_002421838[_0024_002411444_002421837].Trim();
									_0024obj_002421826 = GameObject.Find(_0024trimName_002421825) as GameObject;
									if (!_0024obj_002421826)
									{
										_0024obj_002421826 = GameObject.Find(_0024_002411445_002421838[_0024_002411444_002421837]) as GameObject;
									}
									if (!_0024obj_002421826)
									{
										_0024obj_002421826 = GameObject.Find(_0024trimName_002421825 + "(Clone)") as GameObject;
									}
									if (!_0024obj_002421826)
									{
										_0024obj_002421826 = GameObject.Find(_0024_002411445_002421838[_0024_002411444_002421837] + "(Clone)") as GameObject;
									}
									if ((bool)_0024obj_002421826)
									{
										_0024tmpNpcCtrl_002421827 = _0024obj_002421826.GetComponentInChildren<NpcTalkControl>();
										if ((bool)_0024tmpNpcCtrl_002421827)
										{
											_0024obj_002421826 = (GameObject)UnityEngine.Object.Instantiate(_0024obj_002421826);
											_0024tmpNpcCtrl_002421827 = _0024obj_002421826.GetComponentInChildren<NpcTalkControl>();
											UnityEngine.Object.Destroy(_0024tmpNpcCtrl_002421827);
										}
										NonQuestDontDestroyObjects.Entry(_0024obj_002421826);
										homeModels = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), homeModels, new GameObject[1] { _0024obj_002421826 });
									}
								}
							}
							UnityEngine.Object.DestroyObject(_0024_002411449_002421841[_0024_002411448_002421840].gameObject);
						}
						goto IL_05a3;
					case 1:
						{
							result = 0;
							break;
						}
						IL_05a3:
						_0024self__002421843.HomeInitCore();
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal MyhomeSubSceneTopMain _0024self__002421844;

		public _0024SetupWaitFromNoMyhome_002421812(MyhomeSubSceneTopMain self_)
		{
			_0024self__002421844 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421844);
		}
	}

	[NonSerialized]
	public static bool readMyhome = true;

	[NonSerialized]
	public static GameObject[] homeModels;

	[NonSerialized]
	public static string backScene;

	protected bool destroy3DMode;

	protected AsyncOperation asyncOp;

	public bool debugFlag;

	public Camera custom3DCamera;

	public Camera custom2DCamera;

	protected bool customMyhome;

	protected bool initFlag;

	protected int lightMapOffset;

	protected bool fadeWait;

	protected ICallable initFinishFucn;

	protected GameLevelManager gameLevelMan;

	public bool Destroy3DMode
	{
		get
		{
			return destroy3DMode;
		}
		set
		{
			destroy3DMode = value;
		}
	}

	public override void SceneStart()
	{
		HomeInit((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			StartCore();
		});
	}

	protected virtual void StartCore()
	{
	}

	public bool SetupFromNoMyhome()
	{
		int result;
		if (homeModels != null)
		{
			if (homeModels.Length > 0)
			{
				result = 0;
				goto IL_00bc;
			}
			homeModels = null;
		}
		if (!(ShortcutIcon.lastShortcutScnenName != SceneChanger.CurrentSceneName))
		{
			goto IL_0082;
		}
		if (SceneChanger.LastScene == SceneID.Ui_WorldQuest)
		{
			result = 0;
		}
		else if (SceneChanger.LastScene == SceneID.Ui_WorldChallenge)
		{
			result = 0;
		}
		else if (SceneChanger.LastScene == SceneID.Ui_WorldRaid)
		{
			result = 0;
		}
		else
		{
			if (SceneChanger.LastScene != SceneID.Myhome)
			{
				goto IL_0082;
			}
			result = 0;
		}
		goto IL_00bc;
		IL_00bc:
		return (byte)result != 0;
		IL_0082:
		MyhomeScene.noCreatePlayer = true;
		string levelName = SceneIDModule.SceneIDToName(SceneID.Myhome);
		asyncOp = Application.LoadLevelAdditiveAsync(levelName);
		asyncOp.priority = 0;
		StartCoroutine("SetupWaitFromNoMyhome");
		customMyhome = true;
		result = 1;
		goto IL_00bc;
	}

	public IEnumerator SetupWaitFromNoMyhome()
	{
		return new _0024SetupWaitFromNoMyhome_002421812(this).GetEnumerator();
	}

	public void HomeInit()
	{
		HomeInit(null);
	}

	public void HomeInit(ICallable func)
	{
		initFinishFucn = func;
		if (!readMyhome || !SetupFromNoMyhome())
		{
			HomeInitCore();
		}
	}

	public void HomeInitCore()
	{
		if (initFlag)
		{
			return;
		}
		gameLevelMan = GameLevelManager.Instance;
		initFlag = true;
		checked
		{
			if (homeModels != null)
			{
				if (customMyhome)
				{
					lightMapOffset = LightmapSettings.lightmaps.Length;
				}
				int i = 0;
				GameObject[] array = homeModels;
				for (int length = array.Length; i < length; i++)
				{
					if (!array[i])
					{
						continue;
					}
					if (lightMapOffset >= 0)
					{
						Terrain terrain = (Terrain)UnityEngine.Object.FindObjectOfType(typeof(Terrain));
						if ((bool)terrain)
						{
							int lightmapIndex = terrain.lightmapIndex;
							lightmapIndex -= lightMapOffset;
							if (lightmapIndex < 0 || 256 <= lightmapIndex)
							{
								lightmapIndex = -1;
							}
							terrain.lightmapIndex = lightmapIndex;
						}
						Renderer[] componentsInChildren = array[i].GetComponentsInChildren<Renderer>(includeInactive: true);
						int j = 0;
						Renderer[] array2 = componentsInChildren;
						for (int length2 = array2.Length; j < length2; j++)
						{
							int lightmapIndex = array2[j].lightmapIndex;
							lightmapIndex -= lightMapOffset;
							if (lightmapIndex < 0 || 256 <= lightmapIndex)
							{
								lightmapIndex = -1;
							}
							array2[j].lightmapIndex = lightmapIndex;
						}
					}
					array[i].SetActive(value: true);
				}
				lightMapOffset = 0;
			}
			else
			{
				if ((bool)gameLevelMan)
				{
					homeModels = gameLevelMan.DontDestroyFromKeepSceneObjectAll();
				}
				if (homeModels != null)
				{
					int k = 0;
					GameObject[] array3 = homeModels;
					for (int length3 = array3.Length; k < length3; k++)
					{
						NpcTalkControl[] componentsInChildren2 = array3[k].GetComponentsInChildren<NpcTalkControl>(includeInactive: true);
						int l = 0;
						NpcTalkControl[] array4 = componentsInChildren2;
						for (int length4 = array4.Length; l < length4; l++)
						{
							UnityEngine.Object.DestroyObject(array4[l]);
						}
						LookAtPlayer[] componentsInChildren3 = array3[k].GetComponentsInChildren<LookAtPlayer>(includeInactive: true);
						int m = 0;
						LookAtPlayer[] array5 = componentsInChildren3;
						for (int length5 = array5.Length; m < length5; m++)
						{
							if ((bool)array5[m])
							{
								array5[m].enableLookAt = false;
							}
						}
					}
				}
			}
			HomeInitFinish();
		}
	}

	public void HomeInitFinish()
	{
		if (initFinishFucn != null)
		{
			initFinishFucn.Call(new object[0]);
		}
		SceneChanger sceneChanger = SceneChanger.Instance();
		if (fadeWait)
		{
			while (sceneChanger.dontReveal)
			{
				sceneChanger.dontReveal = false;
			}
		}
		StartButton.ForceDestroy();
		fadeWait = false;
	}

	public virtual void OnDestroy()
	{
		if ((bool)gameLevelMan && homeModels == null)
		{
			homeModels = gameLevelMan.DontDestroyFromKeepSceneObjectAll();
		}
		bool num = destroy3DMode;
		if (!num)
		{
			num = customMyhome;
		}
		DestroyMyhomeModel(num);
	}

	public void BackMyhome()
	{
		if (string.IsNullOrEmpty(backScene))
		{
			SceneChanger.ChangeTo(SceneID.Myhome);
		}
		else
		{
			SceneChanger.Change(backScene);
			backScene = string.Empty;
		}
		destroy3DMode = true;
	}

	public static void DestroyMyhomeModel(bool destroy)
	{
		if (homeModels == null)
		{
			return;
		}
		int i = 0;
		GameObject[] array = homeModels;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].SetActive(value: false);
				}
			}
			if (destroy)
			{
				int j = 0;
				GameObject[] array2 = homeModels;
				for (int length2 = array2.Length; j < length2; j++)
				{
					UnityEngine.Object.DestroyObject(array2[j]);
				}
				homeModels = null;
			}
		}
	}

	internal void _0024SceneStart_0024closure_00243081()
	{
		StartCore();
	}
}
