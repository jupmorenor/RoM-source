using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestMapper : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024remapRoutine_002418911 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnumMapLinkDir _0024e_002418912;

			internal GameObject _0024linkObj_002418913;

			internal MeshRenderer _0024mr_002418914;

			internal QuestLinker _0024c_002418915;

			internal GameObject _0024posObj_002418916;

			internal QuestLinkPosition _0024pc_002418917;

			internal MStageBattles _0024btl_002418918;

			internal string _0024popName_002418919;

			internal GameObject _0024popObj_002418920;

			internal QuestBattleStarter _0024bc_002418921;

			internal Collider _0024pcol_002418922;

			internal GameObject _0024go_002418923;

			internal GameObject _0024go_002418924;

			internal MScenes _0024scn_002418925;

			internal EnumMapLinkDir _0024e_002418926;

			internal GameObject _0024obj_002418927;

			internal GameObject _0024lo_002418928;

			internal GameObject _0024pobj_002418929;

			internal QuestDropManager _0024sdm_002418930;

			internal int _0024_00249588_002418931;

			internal MStageBattles[] _0024_00249589_002418932;

			internal int _0024_00249590_002418933;

			internal int _0024_00249592_002418934;

			internal GameObject[] _0024_00249593_002418935;

			internal int _0024_00249594_002418936;

			internal int _0024_00249596_002418937;

			internal GameObject[] _0024_00249597_002418938;

			internal int _0024_00249598_002418939;

			internal IEnumerator _0024_0024iterator_002413705_002418940;

			internal IEnumerator _0024_0024iterator_002413706_002418941;

			internal IEnumerator _0024_0024iterator_002413707_002418942;

			internal Dictionary<EnumMapLinkDir, GameObject>.ValueCollection.Enumerator _0024_0024iterator_002413708_002418943;

			internal Dictionary<string, GameObject>.ValueCollection.Enumerator _0024_0024iterator_002413709_002418944;

			internal QuestMapper _0024self__002418945;

			public _0024(QuestMapper self_)
			{
				_0024self__002418945 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002418945.discardMap();
						if (!QuestSession.IsCurrentStageAvailable)
						{
							_0024self__002418945.disableAllUninitializedPops();
							goto case 1;
						}
						_0024_0024iterator_002413705_002418940 = Enum.GetValues(typeof(EnumMapLinkDir)).GetEnumerator();
						while (_0024_0024iterator_002413705_002418940.MoveNext())
						{
							_0024e_002418912 = (EnumMapLinkDir)_0024_0024iterator_002413705_002418940.Current;
							_0024linkObj_002418913 = ExtensionsModule.FindInChildrenIgnoreCase(_0024self__002418945.gameObject, LinkObjectName(_0024e_002418912));
							if (_0024linkObj_002418913 != null)
							{
								_0024linkObj_002418913.tag = "Portal";
								_0024mr_002418914 = _0024linkObj_002418913.GetComponent<MeshRenderer>();
								if ((bool)_0024mr_002418914)
								{
									_0024mr_002418914.enabled = false;
								}
								_0024linkObj_002418913.SetActive(value: false);
								_0024self__002418945.linkObjects[_0024e_002418912] = _0024linkObj_002418913;
								_0024c_002418915 = ExtensionsModule.SetComponent<QuestLinker>(_0024linkObj_002418913);
								_0024c_002418915.Direction = _0024e_002418912;
							}
							_0024posObj_002418916 = ExtensionsModule.FindInChildrenIgnoreCase(_0024self__002418945.gameObject, new StringBuilder("POS_").Append(_0024e_002418912).ToString());
							if (_0024posObj_002418916 == null && _0024linkObj_002418913 != null)
							{
								_0024posObj_002418916 = new GameObject(new StringBuilder("POS_").Append(_0024e_002418912).Append("_autogen").ToString());
								ExtensionsModule.SetParent(_0024posObj_002418916, ExtensionsModule.Parent(_0024linkObj_002418913));
								_0024posObj_002418916.transform.position = _0024linkObj_002418913.transform.position;
								_0024posObj_002418916.transform.position = _0024posObj_002418916.transform.position + _0024linkObj_002418913.transform.forward * 4f;
							}
							if (_0024posObj_002418916 != null)
							{
								_0024self__002418945.positionObjects[_0024e_002418912] = _0024posObj_002418916;
								_0024pc_002418917 = ExtensionsModule.SetComponent<QuestLinkPosition>(_0024posObj_002418916);
								_0024pc_002418917.Direction = _0024e_002418912;
							}
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
						_0024_00249588_002418931 = 0;
						_0024_00249589_002418932 = QuestSession.GetCurrentStageBattles();
						for (_0024_00249590_002418933 = _0024_00249589_002418932.Length; _0024_00249588_002418931 < _0024_00249590_002418933; _0024_00249588_002418931++)
						{
							_0024popName_002418919 = _0024_00249589_002418932[_0024_00249588_002418931].PositionObject;
							_0024popObj_002418920 = ExtensionsModule.FindInChildrenIgnoreCase(_0024self__002418945.gameObject, _0024popName_002418919);
							if (_0024popObj_002418920 != null)
							{
								_0024self__002418945.popObjects[_0024popName_002418919] = _0024popObj_002418920;
								_0024bc_002418921 = ExtensionsModule.SetComponent<QuestBattleStarter>(_0024popObj_002418920);
								if (!(_0024bc_002418921 != null))
								{
									throw new AssertionFailedException("bc != null");
								}
								_0024bc_002418921.StageBattle = _0024_00249589_002418932[_0024_00249588_002418931];
							}
						}
						_0024_0024iterator_002413706_002418941 = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(_0024self__002418945.gameObject, "pop").GetEnumerator();
						while (_0024_0024iterator_002413706_002418941.MoveNext())
						{
							object obj = _0024_0024iterator_002413706_002418941.Current;
							if (!(obj is GameObject))
							{
								obj = RuntimeServices.Coerce(obj, typeof(GameObject));
							}
							_0024popObj_002418920 = (GameObject)obj;
							_0024pcol_002418922 = _0024popObj_002418920.GetComponent<Collider>();
							if (_0024pcol_002418922 != null)
							{
								_0024pcol_002418922.isTrigger = true;
							}
							_0024_00249592_002418934 = 0;
							_0024_00249593_002418935 = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(_0024popObj_002418920, "petarea");
							for (_0024_00249594_002418936 = _0024_00249593_002418935.Length; _0024_00249592_002418934 < _0024_00249594_002418936; _0024_00249592_002418934++)
							{
								_0024pcol_002418922 = _0024_00249593_002418935[_0024_00249592_002418934].GetComponent<Collider>();
								if (_0024pcol_002418922 != null)
								{
									_0024pcol_002418922.isTrigger = true;
								}
							}
							_0024_00249596_002418937 = 0;
							_0024_00249597_002418938 = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(_0024popObj_002418920, "poparea");
							for (_0024_00249598_002418939 = _0024_00249597_002418938.Length; _0024_00249596_002418937 < _0024_00249598_002418939; _0024_00249596_002418937++)
							{
								_0024pcol_002418922 = _0024_00249597_002418938[_0024_00249596_002418937].GetComponent<Collider>();
								if (_0024pcol_002418922 != null)
								{
									_0024pcol_002418922.isTrigger = true;
								}
							}
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
					case 3:
						_0024self__002418945.checkPopActivation("step1");
						_0024self__002418945.disableAllUninitializedPops();
						result = (YieldDefault(4) ? 1 : 0);
						break;
					case 4:
						_0024self__002418945.checkPopActivation("step2");
						_0024scn_002418925 = QuestSession.CurrentScene;
						if (_0024scn_002418925 != null)
						{
							_0024_0024iterator_002413707_002418942 = Enum.GetValues(typeof(EnumMapLinkDir)).GetEnumerator();
							while (_0024_0024iterator_002413707_002418942.MoveNext())
							{
								_0024e_002418926 = (EnumMapLinkDir)_0024_0024iterator_002413707_002418942.Current;
								_0024obj_002418927 = ExtensionsModule.FindInChildrenIgnoreCase(_0024self__002418945.gameObject, new StringBuilder("BLOCK_").Append(_0024e_002418926).ToString());
								if (_0024obj_002418927 != null)
								{
									_0024obj_002418927.SetActive(_0024scn_002418925.isBlocked(_0024e_002418926));
								}
							}
						}
						result = (YieldDefault(5) ? 1 : 0);
						break;
					case 5:
						_0024self__002418945.checkPopActivation("step3");
						_0024_0024iterator_002413708_002418943 = _0024self__002418945.linkObjects.Values.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413708_002418943.MoveNext())
							{
								_0024lo_002418928 = _0024_0024iterator_002413708_002418943.Current;
								_0024lo_002418928.SetActive(value: true);
							}
						}
						finally
						{
							((IDisposable)_0024_0024iterator_002413708_002418943).Dispose();
						}
						result = (YieldDefault(6) ? 1 : 0);
						break;
					case 6:
						_0024self__002418945.checkPopActivation("step4");
						_0024_0024iterator_002413709_002418944 = _0024self__002418945.popObjects.Values.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413709_002418944.MoveNext())
							{
								_0024pobj_002418929 = _0024_0024iterator_002413709_002418944.Current;
								_0024pobj_002418929.SetActive(value: true);
								ExtensionsModule.ActivateChildren(_0024pobj_002418929, b: false);
							}
						}
						finally
						{
							((IDisposable)_0024_0024iterator_002413709_002418944).Dispose();
						}
						_0024sdm_002418930 = QuestSession.StageDropManager;
						_0024sdm_002418930.PutDropObjects(_0024scn_002418925, _0024self__002418945.gameObject, "kusamushi", "Prefab/Item/QuestKusamushi");
						_0024self__002418945.initPathfinder();
						_0024self__002418945.initialized = true;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal QuestMapper _0024self__002418946;

		public _0024remapRoutine_002418911(QuestMapper self_)
		{
			_0024self__002418946 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418946);
		}
	}

	[NonSerialized]
	private static QuestMapper currentMapper;

	[NonSerialized]
	private const string KUSAMUSHI_PREFAB_PATH = "Prefab/Item/QuestKusamushi";

	private bool initialized;

	private Dictionary<EnumMapLinkDir, GameObject> linkObjects;

	private Dictionary<EnumMapLinkDir, GameObject> positionObjects;

	private Dictionary<string, GameObject> popObjects;

	private Pathfinder pathfinder;

	[NonSerialized]
	private const int AUTO_GENPOS_OFFSET = 4;

	public static QuestMapper Current => currentMapper;

	public bool Initialized => initialized;

	public Pathfinder Pathfinder => pathfinder;

	public QuestMapper()
	{
		linkObjects = new Dictionary<EnumMapLinkDir, GameObject>();
		positionObjects = new Dictionary<EnumMapLinkDir, GameObject>();
		popObjects = new Dictionary<string, GameObject>();
	}

	public GameObject GetPositionObject(EnumMapLinkDir dir)
	{
		return (!positionObjects.ContainsKey(dir)) ? null : positionObjects[dir];
	}

	public GameObject GetPopObject(MStageBattles battle)
	{
		return (battle == null) ? null : GetPopObject(battle.PositionObject);
	}

	public GameObject GetPopObject(string name)
	{
		return (!popObjects.ContainsKey(name)) ? null : popObjects[name];
	}

	public GameObject GetLinkObject(EnumMapLinkDir dir)
	{
		return (!linkObjects.ContainsKey(dir)) ? null : linkObjects[dir];
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
		remap();
		currentMapper = this;
	}

	public void OnDisable()
	{
		currentMapper = null;
		discardMap();
	}

	public void OnDestroy()
	{
	}

	public void remap()
	{
		IEnumerator enumerator = remapRoutine();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator remapRoutine()
	{
		return new _0024remapRoutine_002418911(this).GetEnumerator();
	}

	public static string LinkObjectName(EnumMapLinkDir dir)
	{
		return new StringBuilder("LINK_").Append(dir).ToString();
	}

	private void disableAllUninitializedPops()
	{
		int i = 0;
		GameObject[] array = ExtensionsModule.Children(gameObject);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			string text = array[i].name.ToLower();
			if (text.StartsWith("pop") && array[i].GetComponent<QuestBattleStarter>() == null)
			{
				array[i].SetActive(value: false);
			}
		}
	}

	private void checkPopActivation(string msg)
	{
	}

	private void initPathfinder()
	{
		if (pathfinder != null)
		{
			UnityEngine.Object.Destroy(pathfinder);
		}
		pathfinder = ExtensionsModule.SetComponent<Pathfinder>(gameObject);
	}

	public void discardMap()
	{
		linkObjects.Clear();
		positionObjects.Clear();
		popObjects.Clear();
		UnityEngine.Object.Destroy(pathfinder);
		initialized = false;
	}
}
