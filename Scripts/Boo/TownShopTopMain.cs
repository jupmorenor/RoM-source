using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class TownShopTopMain : UIMain
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupWaitFromNoTown_002421942 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameLevelManager _0024glMan_002421943;

			internal TownMain _0024townMain_002421944;

			internal GameUIRoot _0024gameUiRoot_002421945;

			internal Camera[] _0024cams_002421946;

			internal Camera _0024cam_002421947;

			internal EventWindow[] _0024evWnds_002421948;

			internal EventWindow _0024wnd_002421949;

			internal NpcTalkControl[] _0024npcTalks_002421950;

			internal NpcTalkControl _0024talk_002421951;

			internal NpcTalkControl _0024talk_002421952;

			internal string[] _0024keepObjs_002421953;

			internal string _0024keepObjName_002421954;

			internal string _0024trimName_002421955;

			internal GameObject _0024obj_002421956;

			internal NpcTalkControl _0024tmpNpcCtrl_002421957;

			internal int _0024_002411664_002421958;

			internal Camera[] _0024_002411665_002421959;

			internal int _0024_002411666_002421960;

			internal int _0024_002411668_002421961;

			internal EventWindow[] _0024_002411669_002421962;

			internal int _0024_002411670_002421963;

			internal int _0024_002411672_002421964;

			internal NpcTalkControl[] _0024_002411673_002421965;

			internal int _0024_002411674_002421966;

			internal int _0024_002411676_002421967;

			internal string[] _0024_002411677_002421968;

			internal int _0024_002411678_002421969;

			internal int _0024_002411680_002421970;

			internal NpcTalkControl[] _0024_002411681_002421971;

			internal int _0024_002411682_002421972;

			internal TownShopTopMain _0024self__002421973;

			public _0024(TownShopTopMain self_)
			{
				_0024self__002421973 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002421973.asyncOp != null)
						{
							SceneChanger.Instance().dontReveal = true;
							_0024self__002421973.fadeWait = true;
							_0024glMan_002421943 = GameLevelManager.Instance;
							goto case 2;
						}
						goto IL_05a3;
					case 2:
						if (GameLevelManager.isBusy)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						townModels = new GameObject[0];
						goto case 3;
					case 3:
						if (!_0024self__002421973.asyncOp.isDone)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024townMain_002421944 = (TownMain)UnityEngine.Object.FindObjectOfType(typeof(TownMain));
						if ((bool)_0024townMain_002421944)
						{
							_0024townMain_002421944.enabled = false;
						}
						_0024gameUiRoot_002421945 = (GameUIRoot)UnityEngine.Object.FindObjectOfType(typeof(GameUIRoot));
						if ((bool)_0024gameUiRoot_002421945)
						{
							UnityEngine.Object.DestroyObject(_0024gameUiRoot_002421945.gameObject);
						}
						_0024glMan_002421943.Setup(SceneIDModule.SceneIDToName(SceneID.Town));
						result = (YieldDefault(4) ? 1 : 0);
						break;
					case 4:
					case 5:
						if (GameLevelManager.isBusy)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						_0024cams_002421946 = (Camera[])UnityEngine.Object.FindObjectsOfType(typeof(Camera));
						_0024_002411664_002421958 = 0;
						_0024_002411665_002421959 = _0024cams_002421946;
						for (_0024_002411666_002421960 = _0024_002411665_002421959.Length; _0024_002411664_002421958 < _0024_002411666_002421960; _0024_002411664_002421958++)
						{
							if (_0024_002411665_002421959[_0024_002411664_002421958].depth <= 5f || _0024_002411665_002421959[_0024_002411664_002421958].gameObject.layer == LayerMask.NameToLayer("2DUI"))
							{
								_0024_002411665_002421959[_0024_002411664_002421958].enabled = false;
							}
						}
						_0024self__002421973.custom3DCamera.enabled = true;
						_0024self__002421973.custom2DCamera.enabled = true;
						_0024evWnds_002421948 = (EventWindow[])UnityEngine.Object.FindObjectsOfType(typeof(EventWindow));
						_0024_002411668_002421961 = 0;
						_0024_002411669_002421962 = _0024evWnds_002421948;
						for (_0024_002411670_002421963 = _0024_002411669_002421962.Length; _0024_002411668_002421961 < _0024_002411670_002421963; _0024_002411668_002421961++)
						{
							UnityEngine.Object.DestroyObject(_0024_002411669_002421962[_0024_002411668_002421961]);
						}
						_0024npcTalks_002421950 = (NpcTalkControl[])UnityEngine.Object.FindObjectsOfType(typeof(NpcTalkControl));
						_0024_002411672_002421964 = 0;
						_0024_002411673_002421965 = _0024npcTalks_002421950;
						for (_0024_002411674_002421966 = _0024_002411673_002421965.Length; _0024_002411672_002421964 < _0024_002411674_002421966; _0024_002411672_002421964++)
						{
							if ((bool)_0024_002411673_002421965[_0024_002411672_002421964])
							{
								_0024_002411673_002421965[_0024_002411672_002421964].gameObject.SetActive(value: true);
							}
						}
						result = (YieldDefault(6) ? 1 : 0);
						break;
					case 6:
						_0024_002411680_002421970 = 0;
						_0024_002411681_002421971 = _0024npcTalks_002421950;
						for (_0024_002411682_002421972 = _0024_002411681_002421971.Length; _0024_002411680_002421970 < _0024_002411682_002421972; _0024_002411680_002421970++)
						{
							if (_0024_002411681_002421971[_0024_002411680_002421970].talkNextScene == SceneChanger.CurrentSceneName && _0024_002411681_002421971[_0024_002411680_002421970].MNpcTalks != null)
							{
								_0024keepObjs_002421953 = _0024_002411681_002421971[_0024_002411680_002421970].MNpcTalks.NextSceneKeepObjects.Split(',');
								_0024_002411676_002421967 = 0;
								_0024_002411677_002421968 = _0024keepObjs_002421953;
								for (_0024_002411678_002421969 = _0024_002411677_002421968.Length; _0024_002411676_002421967 < _0024_002411678_002421969; _0024_002411676_002421967++)
								{
									_0024trimName_002421955 = _0024_002411677_002421968[_0024_002411676_002421967].Trim();
									_0024obj_002421956 = GameObject.Find(_0024trimName_002421955) as GameObject;
									if (!_0024obj_002421956)
									{
										_0024obj_002421956 = GameObject.Find(_0024_002411677_002421968[_0024_002411676_002421967]) as GameObject;
									}
									if (!_0024obj_002421956)
									{
										_0024obj_002421956 = GameObject.Find(_0024trimName_002421955 + "(Clone)") as GameObject;
									}
									if (!_0024obj_002421956)
									{
										_0024obj_002421956 = GameObject.Find(_0024_002411677_002421968[_0024_002411676_002421967] + "(Clone)") as GameObject;
									}
									if ((bool)_0024obj_002421956)
									{
										_0024tmpNpcCtrl_002421957 = _0024obj_002421956.GetComponentInChildren<NpcTalkControl>();
										if ((bool)_0024tmpNpcCtrl_002421957)
										{
											_0024obj_002421956 = (GameObject)UnityEngine.Object.Instantiate(_0024obj_002421956);
											_0024tmpNpcCtrl_002421957 = _0024obj_002421956.GetComponentInChildren<NpcTalkControl>();
											UnityEngine.Object.Destroy(_0024tmpNpcCtrl_002421957);
										}
										NonQuestDontDestroyObjects.Entry(_0024obj_002421956);
										townModels = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), townModels, new GameObject[1] { _0024obj_002421956 });
									}
								}
							}
							UnityEngine.Object.DestroyObject(_0024_002411681_002421971[_0024_002411680_002421970].gameObject);
						}
						goto IL_05a3;
					case 1:
						{
							result = 0;
							break;
						}
						IL_05a3:
						_0024self__002421973.ShopInitCore();
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal TownShopTopMain _0024self__002421974;

		public _0024SetupWaitFromNoTown_002421942(TownShopTopMain self_)
		{
			_0024self__002421974 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421974);
		}
	}

	[NonSerialized]
	public static bool readTown = true;

	[NonSerialized]
	public static GameObject[] townModels;

	[NonSerialized]
	public static string backScene;

	protected bool destroy3DMode;

	protected AsyncOperation asyncOp;

	public bool debugFlag;

	public Camera custom3DCamera;

	public Camera custom2DCamera;

	protected bool customTown;

	protected bool initFlag;

	protected int lightMapOffset;

	protected bool fadeWait;

	protected ICallable initFinishFucn;

	protected GameLevelManager gameLevelMan;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _callbackStartCore;

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

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ CallbackStartCore
	{
		get
		{
			return _callbackStartCore;
		}
		set
		{
			_callbackStartCore = value;
		}
	}

	public override void SceneStart()
	{
		ShopInit((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			StartCore();
		});
	}

	protected virtual void StartCore()
	{
		if (_callbackStartCore != null)
		{
			_callbackStartCore();
		}
	}

	private bool SetupFromNoTown()
	{
		int result;
		if (townModels != null)
		{
			if (townModels.Length > 0)
			{
				result = 0;
				goto IL_0159;
			}
			townModels = null;
		}
		if (!(ShortcutIcon.lastShortcutScnenName == SceneChanger.CurrentSceneName) && SceneChanger.LastScene == SceneID.Town)
		{
			result = 0;
		}
		else
		{
			TownScene.noCreatePlayer = true;
			QuestManager instance = QuestManager.Instance;
			GameLevelManager instance2 = GameLevelManager.Instance;
			if (!instance)
			{
				result = 0;
			}
			else
			{
				if (instance.AreaConditionNumber < 0)
				{
					instance.CreatAreaGroupTable();
				}
				Hashtable areaGroupTable = instance.AreaGroupTable;
				if (areaGroupTable == null)
				{
					result = 0;
				}
				else
				{
					IEnumerator enumerator = areaGroupTable.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						int num = RuntimeServices.UnboxInt32(enumerator.Current);
						MAreas mAreas = null;
						if (areaGroupTable.ContainsKey(num))
						{
							object obj = areaGroupTable[num];
							if (!(obj is MAreas))
							{
								obj = RuntimeServices.Coerce(obj, typeof(MAreas));
							}
							mAreas = (MAreas)obj;
						}
						if (mAreas.JumpType == EnumAreaTypes.Town)
						{
							string levelName = SceneIDModule.SceneIDToName(SceneID.Town);
							asyncOp = Application.LoadLevelAdditiveAsync(levelName);
							asyncOp.priority = 0;
							break;
						}
					}
					IEnumerator enumerator2 = SetupWaitFromNoTown();
					if (enumerator2 != null)
					{
						StartCoroutine(enumerator2);
					}
					customTown = true;
					result = 1;
				}
			}
		}
		goto IL_0159;
		IL_0159:
		return (byte)result != 0;
	}

	private IEnumerator SetupWaitFromNoTown()
	{
		return new _0024SetupWaitFromNoTown_002421942(this).GetEnumerator();
	}

	public void ShopInit()
	{
		ShopInit(null);
	}

	public void ShopInit(ICallable func)
	{
		initFinishFucn = func;
		if (!readTown || !SetupFromNoTown())
		{
			readTown = true;
			ShopInitCore();
		}
	}

	private void ShopInitCore()
	{
		if (initFlag)
		{
			return;
		}
		gameLevelMan = GameLevelManager.Instance;
		initFlag = true;
		checked
		{
			if (townModels != null)
			{
				if (customTown)
				{
					lightMapOffset = LightmapSettings.lightmaps.Length;
				}
				int i = 0;
				GameObject[] array = townModels;
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
					townModels = gameLevelMan.DontDestroyFromKeepSceneObjectAll();
				}
				if (townModels != null)
				{
					int k = 0;
					GameObject[] array3 = townModels;
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
			ShopInitFinish();
		}
	}

	private void ShopInitFinish()
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

	protected virtual void OnDestroy()
	{
		if ((bool)gameLevelMan && townModels == null)
		{
			townModels = gameLevelMan.DontDestroyFromKeepSceneObjectAll();
		}
		bool num = destroy3DMode;
		if (!num)
		{
			num = customTown;
		}
		DestroyTownModel(num);
	}

	public void BackTown()
	{
		if (string.IsNullOrEmpty(backScene))
		{
			SceneChanger.ChangeTo(SceneID.Town);
		}
		else
		{
			SceneChanger.Change(backScene);
			backScene = string.Empty;
		}
		destroy3DMode = true;
	}

	public static void DestroyTownModel(bool destroy)
	{
		if (townModels == null)
		{
			return;
		}
		int i = 0;
		GameObject[] array = townModels;
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
				GameObject[] array2 = townModels;
				for (int length2 = array2.Length; j < length2; j++)
				{
					UnityEngine.Object.DestroyObject(array2[j]);
				}
				townModels = null;
			}
		}
	}

	internal void _0024SceneStart_0024closure_00242920()
	{
		StartCore();
	}
}
