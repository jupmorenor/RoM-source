using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PlayerPoppetCache : MonoBehaviour
{
	[Serializable]
	public class PlayerParams
	{
		public WeaponEquipments weaponEq;

		public Vector3 position;

		public Quaternion rotation;

		public bool isBattleMode;

		public bool IsValid
		{
			get
			{
				bool num = weaponEq != null;
				if (num)
				{
					num = weaponEq.IsValid;
				}
				return num;
			}
		}

		public PlayerParams()
		{
			weaponEq = new WeaponEquipments();
			position = Vector3.zero;
			rotation = Quaternion.identity;
			isBattleMode = true;
			weaponEq = WeaponEquipments.FromUserData();
		}
	}

	[Serializable]
	public class ConditionPlayer
	{
		public WeaponEquipments weaponEq;

		private bool _0024initialized__PlayerPoppetCache_ConditionPlayer_0024;

		public ConditionPlayer()
		{
			if (!_0024initialized__PlayerPoppetCache_ConditionPlayer_0024)
			{
				weaponEq = new WeaponEquipments();
				_0024initialized__PlayerPoppetCache_ConditionPlayer_0024 = true;
			}
		}

		public ConditionPlayer(WeaponEquipments wpns)
		{
			if (!_0024initialized__PlayerPoppetCache_ConditionPlayer_0024)
			{
				weaponEq = new WeaponEquipments();
				_0024initialized__PlayerPoppetCache_ConditionPlayer_0024 = true;
			}
			weaponEq = wpns;
		}

		public bool isEquals(ConditionPlayer cond)
		{
			return cond != null && weaponEq != null && cond.weaponEq != null && weaponEq.isSameAs(cond.weaponEq);
		}

		public void clear()
		{
			weaponEq = new WeaponEquipments();
		}

		public override string ToString()
		{
			return (weaponEq == null) ? "ConditionPlayer noweapon" : (weaponEq.IsValid ? new StringBuilder("ConditionPlayer weapon(").Append(weaponEq).Append(")").ToString() : "ConditionPlayer invalid");
		}
	}

	[Serializable]
	public class CachePlayer
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024initHUDs_002417167 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal RespWeapon _0024wpn_002417168;

				internal PlayerControl _0024pl_002417169;

				public _0024(PlayerControl pl)
				{
					_0024pl_002417169 = pl;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (_0024pl_002417169 == null || !_0024pl_002417169.useHUD)
						{
							goto case 1;
						}
						goto case 2;
					case 2:
						if (!_0024pl_002417169.IsReady)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024wpn_002417168 = _0024pl_002417169.getMainWeapon();
						if (_0024wpn_002417168 != null)
						{
							BattleHUDPlayerInfo.SetZokuseiIcon(_0024wpn_002417168.ElementMainIcon);
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal PlayerControl _0024pl_002417170;

			public _0024initHUDs_002417167(PlayerControl pl)
			{
				_0024pl_002417170 = pl;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024pl_002417170);
			}
		}

		private PlayerControl playerControl;

		private ConditionPlayer condition;

		private string spawnedName;

		public PlayerControl CachedPlayerControl => playerControl;

		public ConditionPlayer CachedCondition => condition;

		public CachePlayer()
		{
			condition = new ConditionPlayer();
			spawnedName = "??";
		}

		public PlayerControl request(PlayerParams param, ConditionPlayer cond, __PlayerPoppetCache_getPlayer_0024callable68_002434_55__ h)
		{
			if (cond == null)
			{
				throw new AssertionFailedException("cond != null");
			}
			if (playerControl == null)
			{
				playerControl = spawn(param);
				condition = cond;
			}
			else if (!condition.isEquals(cond))
			{
				param.weaponEq = cond.weaponEq;
				respawn(param, cond);
				condition = cond;
			}
			else
			{
				param.weaponEq = cond.weaponEq;
				revive(param);
				condition = cond;
			}
			if (!(playerControl != null))
			{
				throw new AssertionFailedException("playerControl != null");
			}
			try
			{
				if (h != null)
				{
					h(playerControl);
				}
			}
			catch (Exception)
			{
			}
			startInitHUDs(playerControl);
			return playerControl;
		}

		private PlayerControl spawn(PlayerParams param)
		{
			PlayerControl.SpawnParam spawnParam = new PlayerControl.SpawnParam(param.position, param.rotation);
			if (!param.isBattleMode)
			{
				spawnParam.setNonBattleMode();
			}
			spawnParam.weaponEquipments = param.weaponEq;
			UserConfigData config = UserData.Current.Config;
			spawnParam.withAutoBattle = config.IsAutoBattleEnabled;
			PlayerControl playerControl = PlayerControl.Spawn(spawnParam);
			SceneDontDestroyObject.dontDestroyOnLoad(playerControl.gameObject);
			if (!(playerControl != null))
			{
				throw new AssertionFailedException("pl != null");
			}
			spawnedName = playerControl.gameObject.name;
			return playerControl;
		}

		private void revive(PlayerParams param)
		{
			if (!(playerControl != null))
			{
				throw new AssertionFailedException("playerControl != null");
			}
			playerControl.gameObject.SetActive(value: true);
			ResetBaseControl(playerControl);
			iTween.Stop(playerControl.gameObject);
			playerControl.gameObject.name = spawnedName;
			playerControl.transform.localPosition = param.position;
			playerControl.transform.localRotation = param.rotation;
			playerControl.InputActive = false;
			playerControl.activateMesh(string.Empty, b: true);
			playerControl.weaponEquipments = param.weaponEq;
			playerControl.resetAbnormalState();
			playerControl.resetCooldowns();
			playerControl.DisableFaceMovement = false;
			playerControl.Pause = false;
			playerControl.resetAutoFlow();
			UserConfigData config = UserData.Current.Config;
			playerControl.EnableAuto = config.IsAutoBattleEnabled;
			if (param.isBattleMode)
			{
				playerControl.setBattleMode();
				playerControl.showWeapons(show: true);
			}
			else
			{
				playerControl.setNonBattleMode();
				playerControl.showWeapons(show: false);
			}
			playerControl.destroyAllCommands();
			playerControl.forceToIdle();
			playerControl.InputActive = true;
			playerControl.useHUD = true;
			playerControl.setSkillIcon();
			playerControl.clearNoHitAndGuard();
			playerControl.RaidData.reset();
			playerControl.enableColiYarare(b: true);
			playerControl.clearPoppets();
			playerControl.clearTrajectory();
			playerControl.EnableIkariMode = false;
			playerControl.stopHitCancel();
			playerControl.resetRaidPoppetData();
			PlayerControl.UpdateCurentPlayerList(playerControl);
		}

		private void respawn(PlayerParams param, ConditionPlayer cond)
		{
			revive(param);
			playerControl.equipWeapons(cond.weaponEq);
		}

		private void startInitHUDs(PlayerControl pl)
		{
			IEnumerator enumerator = initHUDs(playerControl);
			if (enumerator != null)
			{
				Instance.StartCoroutine(enumerator);
			}
		}

		private IEnumerator initHUDs(PlayerControl pl)
		{
			return new _0024initHUDs_002417167(pl).GetEnumerator();
		}

		public void dispose()
		{
			if (playerControl != null)
			{
				UnityEngine.Object.Destroy(playerControl.gameObject);
				playerControl = null;
			}
		}

		public void hide()
		{
			if (playerControl != null)
			{
				playerControl.gameObject.SetActive(value: false);
			}
		}

		public void update()
		{
		}
	}

	[Serializable]
	public class ConditionPoppet
	{
		private RespPoppet poppetData;

		private bool _0024initialized__PlayerPoppetCache_ConditionPoppet_0024;

		public bool IsValid
		{
			get
			{
				bool num = poppetData != null;
				if (num)
				{
					num = poppetData.IsValidMaster;
				}
				return num;
			}
		}

		public RespPoppet PoppetData => poppetData;

		public ConditionPoppet()
		{
			if (!_0024initialized__PlayerPoppetCache_ConditionPoppet_0024)
			{
				_0024initialized__PlayerPoppetCache_ConditionPoppet_0024 = true;
			}
		}

		public ConditionPoppet(RespPoppet ppt)
		{
			if (!_0024initialized__PlayerPoppetCache_ConditionPoppet_0024)
			{
				_0024initialized__PlayerPoppetCache_ConditionPoppet_0024 = true;
			}
			if (ppt == null || !ppt.IsValidMaster)
			{
				throw new AssertionFailedException("(ppt != null) and ppt.IsValidMaster");
			}
			poppetData = ppt;
		}

		public bool isEquals(ConditionPoppet cond)
		{
			return cond != null && poppetData != null && cond.PoppetData != null && RuntimeServices.EqualityOperator(poppetData.Id, cond.PoppetData.Id);
		}

		public void clear()
		{
			poppetData = null;
		}

		public override string ToString()
		{
			return new StringBuilder("ConditionPoppet poppet=").Append(poppetData).ToString();
		}
	}

	[Serializable]
	public class CachePoppet
	{
		[Serializable]
		internal class _0024spawn_0024locals_002414360
		{
			internal ConditionPoppet _0024cond;

			internal __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ _0024h;
		}

		[Serializable]
		internal class _0024spawn_0024closure_00242995
		{
			internal CachePoppet _0024this_002414839;

			internal _0024spawn_0024locals_002414360 _0024_0024locals_002414840;

			public _0024spawn_0024closure_00242995(CachePoppet _0024this_002414839, _0024spawn_0024locals_002414360 _0024_0024locals_002414840)
			{
				this._0024this_002414839 = _0024this_002414839;
				this._0024_0024locals_002414840 = _0024_0024locals_002414840;
			}

			public void Invoke(GameObject go)
			{
				_0024this_002414839.abReq = null;
				if (!(go == null))
				{
					AIControl component = go.GetComponent<AIControl>();
					if (!(component != null))
					{
						throw new AssertionFailedException(new StringBuilder().Append(go).Append("にはAIControlがない").ToString());
					}
					_0024this_002414839.spawnedName = go.name;
					_0024this_002414839.poppet = component;
					_0024this_002414839.poppet.PoppetData = _0024_0024locals_002414840._0024cond.PoppetData;
					_0024this_002414839.poppet.cacheChainEffect();
					SceneDontDestroyObject.dontDestroyOnLoad(go);
					if (_0024_0024locals_002414840._0024h != null)
					{
						_0024_0024locals_002414840._0024h(component);
					}
				}
			}
		}

		private AIControl poppet;

		private ConditionPoppet condition;

		private RuntimeAssetBundleDB.Req abReq;

		private string spawnedName;

		public AIControl CachedPoppet => poppet;

		public ConditionPoppet CachedCondition => condition;

		public RuntimeAssetBundleDB.Req AbReq => abReq;

		public CachePoppet()
		{
			condition = new ConditionPoppet();
			spawnedName = "??";
		}

		public void request(ConditionPoppet cond, __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ h)
		{
			if (cond == null || !cond.IsValid)
			{
				throw new AssertionFailedException("(cond != null) and cond.IsValid");
			}
			if (!condition.isEquals(cond))
			{
				spawn(cond, h);
			}
			else if (poppet != null)
			{
				revive();
				if (h != null)
				{
					h(poppet);
				}
			}
			else if (abReq == null)
			{
			}
		}

		private void spawn(ConditionPoppet cond, __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ h)
		{
			_0024spawn_0024locals_002414360 _0024spawn_0024locals_0024 = new _0024spawn_0024locals_002414360();
			_0024spawn_0024locals_0024._0024cond = cond;
			_0024spawn_0024locals_0024._0024h = h;
			if (abReq == null)
			{
				if (_0024spawn_0024locals_0024._0024cond == null || !_0024spawn_0024locals_0024._0024cond.IsValid)
				{
					throw new AssertionFailedException("(cond != null) and cond.IsValid");
				}
				dispose();
				condition = _0024spawn_0024locals_0024._0024cond;
				MPoppets master = _0024spawn_0024locals_0024._0024cond.PoppetData.Master;
				RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
				instance.instantiatePrefab(master.PrefabName, new _0024spawn_0024closure_00242995(this, _0024spawn_0024locals_0024).Invoke);
			}
		}

		private void revive()
		{
			if (!(poppet != null))
			{
				throw new AssertionFailedException("poppet != null");
			}
			poppet.gameObject.SetActive(value: true);
			poppet.gameObject.name = spawnedName;
			ResetBaseControl(poppet);
			poppet.forceToRevive();
			poppet.clearNoHitAndGuard();
			poppet.activateAiProgramComponent(b: true);
			poppet.RaidData.reset();
			poppet.activateMesh(string.Empty, b: true);
			poppet.stopHitCancel();
			poppet.Pause = false;
			poppet.resetAbnormalState();
		}

		public void dispose()
		{
			abReq = null;
			if (poppet != null)
			{
				UnityEngine.Object.Destroy(poppet.gameObject);
				poppet = null;
			}
			condition.clear();
		}

		public void update()
		{
			if (abReq != null && abReq.IsEnd && !abReq.IsOk)
			{
				abReq = null;
			}
		}

		public void hide()
		{
			if (poppet != null)
			{
				poppet.transform.position = Vector3.zero;
				poppet.transform.rotation = Quaternion.identity;
				poppet.gameObject.SetActive(value: false);
			}
		}
	}

	[NonSerialized]
	private static PlayerPoppetCache __instance;

	[NonSerialized]
	protected static bool quitApp;

	private CachePlayer playerCacher;

	private CachePoppet poppetCacher;

	private bool hideWhenSceneChanging;

	public static PlayerPoppetCache Instance
	{
		get
		{
			PlayerPoppetCache _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((PlayerPoppetCache)UnityEngine.Object.FindObjectOfType(typeof(PlayerPoppetCache))) as PlayerPoppetCache;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static PlayerPoppetCache CurrentInstance => __instance;

	public CachePlayer PlayerCacher => playerCacher;

	public CachePoppet PoppetCacher => poppetCacher;

	public bool HideWhenSceneChanging => hideWhenSceneChanging;

	public PlayerPoppetCache()
	{
		playerCacher = new CachePlayer();
		poppetCacher = new CachePoppet();
		hideWhenSceneChanging = true;
	}

	public void _0024singleton_0024awake_00241422()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241422();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static PlayerPoppetCache _createInstance()
	{
		string text = "__" + "PlayerPoppetCache" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		PlayerPoppetCache playerPoppetCache = ExtensionsModule.SetComponent<PlayerPoppetCache>(gameObject);
		if ((bool)playerPoppetCache)
		{
			playerPoppetCache._createInstance_callback();
		}
		return playerPoppetCache;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241423()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241423();
		quitApp = true;
	}

	public PlayerControl getPlayer(PlayerParams param)
	{
		return getPlayer(param, null);
	}

	public PlayerControl getPlayer(PlayerParams param, __PlayerPoppetCache_getPlayer_0024callable68_002434_55__ h)
	{
		if (!param.IsValid)
		{
			throw new AssertionFailedException("param.IsValid");
		}
		ConditionPlayer cond = new ConditionPlayer(param.weaponEq);
		return playerCacher.request(param, cond, h);
	}

	public void getPoppetFromUserData(__DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ h)
	{
		UserData current = UserData.Current;
		getPoppet(current.CurrentPoppetNewOrOldDeck, h);
	}

	public void getPoppet(RespPoppet poppet, __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ h)
	{
		if (poppet == null)
		{
			throw new AssertionFailedException("poppet != null");
		}
		ConditionPoppet cond = new ConditionPoppet(poppet);
		poppetCacher.request(cond, h);
	}

	public void dontHidePlayerWhenSceneChanging()
	{
		hideWhenSceneChanging = false;
	}

	public void hidePlayerWhenSceneChanging()
	{
		hideWhenSceneChanging = true;
	}

	public void dispose()
	{
		playerCacher.dispose();
		poppetCacher.dispose();
		hideWhenSceneChanging = true;
	}

	private void sceneChangeEvent(SceneID sceneId, string sceneName)
	{
		if (hideWhenSceneChanging)
		{
			hideAll();
		}
	}

	public void hideAll()
	{
		playerCacher.hide();
		poppetCacher.hide();
	}

	public void OnEnable()
	{
		SceneChanger.SceneChangeEvent += sceneChangeEvent;
	}

	public void OnDisable()
	{
		SceneChanger.SceneChangeEvent -= sceneChangeEvent;
	}

	public void Update()
	{
		playerCacher.update();
		poppetCacher.update();
	}

	private static void ResetBaseControl(BaseControl c)
	{
		if (!(c == null))
		{
			c.setHitPointMax();
			c.noDamage = false;
			c.noHitAttack = false;
			c.superArmor = false;
		}
	}
}
