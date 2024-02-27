using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using ObjUtil;
using UnityEngine;

[Serializable]
public class AnimationEventHandler : MonoBehaviour
{
	[Serializable]
	public enum GroundType
	{
		soil,
		grass,
		sand,
		stone,
		snow,
		water
	}

	[Serializable]
	public enum CharacterType
	{
		npc,
		monster,
		player
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_whoami_002415282 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024mParent_002415283;

			internal PlayerControl _0024pc_002415284;

			internal PlayerModelSettings _0024pcsetting_002415285;

			internal NPCControl _0024npc_002415286;

			internal MapetSpeak _0024mps_002415287;

			internal AIControl _0024aic_002415288;

			internal AnimationEventHandler _0024self__002415289;

			public _0024(AnimationEventHandler self_)
			{
				_0024self__002415289 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024mParent_002415283 = _0024self__002415289.transform.parent;
					if (_0024mParent_002415283 == null)
					{
						goto case 1;
					}
					_0024pc_002415284 = _0024mParent_002415283.GetComponentInChildren<PlayerControl>();
					if ((bool)_0024pc_002415284)
					{
						goto case 2;
					}
					goto IL_00af;
				case 2:
					if (!_0024pc_002415284.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024pc_002415284 == PlayerControl.CurrentPlayer))
					{
						goto IL_00af;
					}
					_0024self__002415289.charType = CharacterType.player;
					goto case 1;
				case 3:
					if (!(_0024pcsetting_002415285 == null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_00f3;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00af:
					_0024pcsetting_002415285 = _0024mParent_002415283.GetComponentInChildren<PlayerModelSettings>();
					if (_0024pcsetting_002415285 != null)
					{
						goto case 3;
					}
					goto IL_00f3;
					IL_00f3:
					if (_0024mParent_002415283 == null)
					{
						_0024mParent_002415283 = _0024self__002415289.transform.parent;
					}
					_0024npc_002415286 = _0024mParent_002415283.GetComponent<NPCControl>();
					if ((bool)_0024npc_002415286)
					{
						_0024self__002415289.charType = CharacterType.npc;
					}
					else
					{
						_0024mps_002415287 = _0024mParent_002415283.GetComponent<MapetSpeak>();
						if ((bool)_0024mps_002415287)
						{
							_0024self__002415289.charType = CharacterType.npc;
						}
						else
						{
							_0024aic_002415288 = _0024mParent_002415283.GetComponent<AIControl>();
							if ((bool)_0024aic_002415288)
							{
								_0024self__002415289.charType = CharacterType.monster;
							}
							else
							{
								_0024self__002415289.charType = CharacterType.monster;
								YieldDefault(1);
							}
						}
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AnimationEventHandler _0024self__002415290;

		public _0024_whoami_002415282(AnimationEventHandler self_)
		{
			_0024self__002415290 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415290);
		}
	}

	public float 減衰力;

	public float baseDistance;

	public bool disableHideLayer;

	private readonly float NON_PLAYER_VOLUME_RATE;

	private SQEX_SoundPlayer sndmgr;

	public CharacterType charType;

	private BasicCamera cam;

	private GroundType[] texTypes;

	private readonly List texnameToType;

	private readonly List sceneToType;

	private TerrainData terrainData;

	private Vector3 terrainPos;

	private string DEFAULT_FOOTSTAMP_SE;

	protected int instId;

	protected Renderer[] renderers;

	protected int defLayer;

	protected Hashtable layers;

	protected bool initPrepareWait;

	protected bool prepareWait;

	protected int prepareWaitRenderer;

	protected Animation anim;

	protected int prepareWaitFrame;

	protected bool restoreFromHidden;

	protected SceneID lasstSceneId;

	protected NPCControl npcCtrl;

	protected NpcTalkControl npcTalkCtrl;

	protected bool disableHidden;

	private bool isPlayer => charType == CharacterType.player;

	private bool isInCutscene => CutSceneManager.Instance.isBusy;

	public float dumpRate
	{
		get
		{
			return 減衰力;
		}
		set
		{
			減衰力 = value;
		}
	}

	public bool Hidden => prepareWait;

	public bool RestoreFromHidden
	{
		get
		{
			return restoreFromHidden;
		}
		set
		{
			restoreFromHidden = value;
		}
	}

	public bool DisableHidden
	{
		get
		{
			return disableHidden;
		}
		set
		{
			disableHidden = value;
		}
	}

	public AnimationEventHandler()
	{
		減衰力 = 3f;
		baseDistance = 100f;
		NON_PLAYER_VOLUME_RATE = 0.1f;
		texnameToType = new List(new object[12]
		{
			new List(new object[2]
			{
				"mou_ground_01",
				GroundType.soil
			}, takeOwnership: true),
			new List(new object[2]
			{
				"mou_ground_02",
				GroundType.grass
			}, takeOwnership: true),
			new List(new object[2]
			{
				"mou_ground_03",
				GroundType.soil
			}, takeOwnership: true),
			new List(new object[2]
			{
				"coa_sand_02",
				GroundType.water
			}, takeOwnership: true),
			new List(new object[2]
			{
				"ground",
				GroundType.soil
			}, takeOwnership: true),
			new List(new object[2]
			{
				"sand",
				GroundType.sand
			}, takeOwnership: true),
			new List(new object[2]
			{
				"grass",
				GroundType.grass
			}, takeOwnership: true),
			new List(new object[2]
			{
				"water",
				GroundType.water
			}, takeOwnership: true),
			new List(new object[2]
			{
				"floor",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"rock",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"cliff",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"wall",
				GroundType.stone
			}, takeOwnership: true)
		}, takeOwnership: true);
		sceneToType = new List(new object[9]
		{
			new List(new object[2]
			{
				"town",
				GroundType.soil
			}, takeOwnership: true),
			new List(new object[2]
			{
				"myhome",
				GroundType.soil
			}, takeOwnership: true),
			new List(new object[2]
			{
				"snow",
				GroundType.snow
			}, takeOwnership: true),
			new List(new object[2]
			{
				"desert",
				GroundType.sand
			}, takeOwnership: true),
			new List(new object[2]
			{
				"cave",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"temple",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"heaven",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"sanctuary",
				GroundType.stone
			}, takeOwnership: true),
			new List(new object[2]
			{
				"volcano",
				GroundType.stone
			}, takeOwnership: true)
		}, takeOwnership: true);
		DEFAULT_FOOTSTAMP_SE = "soil";
	}

	public void HideLayerForPrepareAnimation()
	{
		if (!disableHidden && !prepareWait)
		{
			instId = GetInstanceID();
			int hiddenLayer = BasicCamera.HiddenLayer;
			if (renderers == null)
			{
				renderers = GetComponentsInChildren<Renderer>(includeInactive: true);
			}
			npcCtrl = GetComponent<NPCControl>();
			layers = new Hashtable();
			prepareWait = true;
			prepareWaitFrame = 0;
			UpdateLayerForPrepareAnimation();
		}
	}

	public void UpdateLayerForPrepareAnimation()
	{
		if (!prepareWait)
		{
			return;
		}
		int hiddenLayer = BasicCamera.HiddenLayer;
		if (hiddenLayer != gameObject.layer)
		{
			defLayer = gameObject.layer;
		}
		if (layers != null && renderers != null)
		{
			int i = 0;
			Renderer[] array = renderers;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].gameObject.layer != hiddenLayer)
				{
					layers[array[i].name] = array[i].gameObject.layer;
					array[i].gameObject.layer = hiddenLayer;
				}
			}
		}
		if (!anim)
		{
			anim = GetComponent<Animation>();
		}
		if ((bool)anim && (bool)anim.clip && anim.IsPlaying(anim.clip.name))
		{
			restoreFromHidden = true;
		}
	}

	public void RestoreLayerForPrepareAnimation()
	{
		if (!prepareWait)
		{
			return;
		}
		if (layers != null && renderers != null)
		{
			int hiddenLayer = BasicCamera.HiddenLayer;
			int i = 0;
			Renderer[] array = renderers;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if ((bool)array[i] && array[i].gameObject.layer == hiddenLayer)
				{
					if (layers.ContainsKey(array[i].name))
					{
						array[i].gameObject.layer = RuntimeServices.UnboxInt32(layers[array[i].name]);
						layers.Remove(array[i].name);
					}
					else
					{
						array[i].gameObject.layer = defLayer;
					}
				}
			}
		}
		renderers = null;
		layers = null;
		prepareWait = false;
		restoreFromHidden = false;
	}

	public void DisableRendererShadow()
	{
		if (renderers == null)
		{
			renderers = GetComponentsInChildren<Renderer>(includeInactive: true);
		}
		int i = 0;
		Renderer[] array = renderers;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].castShadows = false;
					array[i].receiveShadows = false;
				}
			}
			anim = GetComponent<Animation>();
			if ((bool)anim)
			{
				anim.cullingType = AnimationCullingType.BasedOnClipBounds;
			}
			LightTableReciever[] componentsInChildren = GetComponentsInChildren<LightTableReciever>(includeInactive: true);
			int j = 0;
			LightTableReciever[] array2 = componentsInChildren;
			for (int length2 = array2.Length; j < length2; j++)
			{
				UnityEngine.Object.Destroy(array2[j]);
			}
		}
	}

	public void Awake()
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			DisableRendererShadow();
		}
		lasstSceneId = SceneChanger.CurrentScene;
		if (!disableHideLayer)
		{
			HideLayerForPrepareAnimation();
		}
	}

	public void Start()
	{
		if (!disableHideLayer)
		{
			HideLayerForPrepareAnimation();
		}
		IEnumerator enumerator = _whoami();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		cam = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera;
	}

	public void Update()
	{
		if (!disableHideLayer)
		{
			if (lasstSceneId != SceneChanger.CurrentScene)
			{
				lasstSceneId = SceneChanger.CurrentScene;
				HideLayerForPrepareAnimation();
				restoreFromHidden = true;
			}
			else if (instId != GetInstanceID())
			{
				HideLayerForPrepareAnimation();
			}
			UpdateLayerForPrepareAnimation();
		}
		checked
		{
			if (restoreFromHidden ? true : false)
			{
				prepareWaitFrame++;
				if (prepareWaitFrame > 2)
				{
					RestoreLayerForPrepareAnimation();
				}
			}
		}
	}

	public void OnEnable()
	{
		if (!disableHideLayer)
		{
			HideLayerForPrepareAnimation();
		}
		IEnumerator enumerator = _whoami();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator _whoami()
	{
		return new _0024_whoami_002415282(this).GetEnumerator();
	}

	public void AnimationSoundEventHandler(string eventname)
	{
		_playSE(eventname);
	}

	public void AnimationEffectEventHandler()
	{
	}

	public void AnimationInitializeEventHandler()
	{
		if (!npcCtrl)
		{
			RestoreLayerForPrepareAnimation();
		}
	}

	private void _playSE(string name)
	{
		if (!sndmgr)
		{
			sndmgr = SQEX_SoundPlayer.Instance;
		}
		if ((bool)sndmgr)
		{
			float volume = getVolume();
			int soundID = sndmgr.PlaySe(name, 0, gameObject.GetInstanceID());
			sndmgr.SetSeVoulme(soundID, volume);
		}
	}

	private float getVolume()
	{
		float num = distanceToVolume(getDistanceToCamera());
		float result;
		if (isInCutscene)
		{
			result = num;
		}
		else
		{
			CharacterType characterType = charType;
			result = characterType switch
			{
				CharacterType.player => num, 
				CharacterType.npc => num *= NON_PLAYER_VOLUME_RATE, 
				CharacterType.monster => 0f, 
				_ => throw new MatchError(new StringBuilder("`charType` failed to match `").Append(characterType).Append("`").ToString()), 
			};
		}
		return result;
	}

	private float distanceToVolume(float dist)
	{
		float value = (float)(((double)dist - 3.0) / (double)baseDistance * (double)dumpRate);
		float value2 = Mathf.Pow(1f - Mathf.Clamp(value, 0f, 1f), 2f);
		return Mathf.Clamp(value2, 0f, 1f);
	}

	private float getDistanceToCamera()
	{
		if (!cam)
		{
			cam = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera;
		}
		return cam ? ObjUtilModule.Distance(gameObject, cam) : 10f;
	}

	public void FootStampL(string dum)
	{
		FootStamp("L");
	}

	public void FootStampR(string dum)
	{
		FootStamp("R");
	}

	public void FootStamp(string side)
	{
		string currentSceneName = SceneChanger.CurrentSceneName;
		string value = ((!Terrain.activeTerrain) ? getGroundSE(currentSceneName) : getGroundSE(currentSceneName));
		string text = new StringBuilder("se_map_foot_").Append(value).Append("_").Append(side)
			.ToString();
		_playSE(text);
	}

	private void readTexOrder()
	{
		List list = new List();
		int i = 0;
		SplatPrototype[] splatPrototypes = terrainData.splatPrototypes;
		for (int length = splatPrototypes.Length; i < length; i = checked(i + 1))
		{
			IEnumerator<object> enumerator = texnameToType.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is List))
					{
						obj = RuntimeServices.Coerce(obj, typeof(List));
					}
					List list2 = (List)obj;
					if (RuntimeServices.op_Member(list2[0] as string, splatPrototypes[i].texture.name))
					{
						list.Add(list2[1]);
						break;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		texTypes = (GroundType[])list.ToArray(typeof(GroundType));
	}

	private string typeToString(GroundType t)
	{
		return t switch
		{
			GroundType.soil => "soil", 
			GroundType.grass => "grass", 
			GroundType.sand => "sand", 
			GroundType.stone => "stone", 
			GroundType.snow => "snow", 
			GroundType.water => "water", 
			_ => null, 
		};
	}

	private string searchGroundMaterial(string sceneName)
	{
		TerrainData terrainData = Terrain.activeTerrain.terrainData;
		checked
		{
			object result;
			if ((bool)terrainData)
			{
				terrainPos = Terrain.activeTerrain.transform.position;
				if (!(terrainData == this.terrainData))
				{
					this.terrainData = terrainData;
					readTexOrder();
				}
				int num = Mathf.RoundToInt((transform.position.x - terrainPos.x) / this.terrainData.size.x * (float)this.terrainData.alphamapWidth);
				int num2 = Mathf.RoundToInt((transform.position.z - terrainPos.z) / this.terrainData.size.z * (float)this.terrainData.alphamapHeight);
				if (num >= this.terrainData.alphamapWidth)
				{
					num = this.terrainData.alphamapWidth - 1;
				}
				else if (num < 0)
				{
					num = 0;
				}
				if (num2 >= this.terrainData.alphamapHeight)
				{
					num2 = this.terrainData.alphamapHeight - 1;
				}
				else if (num2 < 0)
				{
					num2 = 0;
				}
				float[,,] alphamaps = this.terrainData.GetAlphamaps(num, num2, 1, 1);
				GroundType t = default(GroundType);
				float num3 = 0f;
				IEnumerator<object[]> enumerator = Builtins.enumerate(texTypes).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object[] current = enumerator.Current;
						object value = current[0];
						object obj = current[1];
						float num4;
						try
						{
							num4 = alphamaps[0, 0, RuntimeServices.UnboxInt32(value)];
						}
						catch (Exception)
						{
							num4 = 0f;
						}
						if (!(num4 <= num3))
						{
							t = (GroundType)obj;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				result = typeToString(t);
			}
			else
			{
				result = null;
			}
			return (string)result;
		}
	}

	private string getGroundSE(string sceneName)
	{
		IEnumerator<object> enumerator = sceneToType.GetEnumerator();
		string text;
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is List))
				{
					obj = RuntimeServices.Coerce(obj, typeof(List));
				}
				List list = (List)obj;
				if (!RuntimeServices.op_Member(list[0] as string, sceneName))
				{
					continue;
				}
				text = typeToString((GroundType)list[1]);
				goto IL_00a5;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = ((!Terrain.activeTerrain) ? DEFAULT_FOOTSTAMP_SE : searchGroundMaterial(sceneName));
		goto IL_00a6;
		IL_00a5:
		result = text;
		goto IL_00a6;
		IL_00a6:
		return (string)result;
	}
}
