using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CharacterCache : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418423 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB.Req _0024r_002418424;

			internal CharacterCache _0024self__002418425;

			public _0024(CharacterCache self_)
			{
				_0024self__002418425 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (((ICollection)_0024self__002418425.reqQueue).Count <= 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024r_002418424 = _0024self__002418425.reqQueue.Dequeue();
					goto case 3;
				case 3:
					if (!_0024r_002418424.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!_0024r_002418424.IsError)
					{
						_0024self__002418425.cache[_0024r_002418424.PrefabName] = _0024r_002418424.Prefab;
					}
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CharacterCache _0024self__002418426;

		public _0024main_002418423(CharacterCache self_)
		{
			_0024self__002418426 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418426);
		}
	}

	[NonSerialized]
	private static CharacterCache _Instance;

	private Dictionary<string, GameObject> cache;

	private Queue<RuntimeAssetBundleDB.Req> reqQueue;

	public static CharacterCache Instance
	{
		get
		{
			if (_Instance == null)
			{
				GameObject component = new GameObject("__CharacterCache__");
				_Instance = ExtensionsModule.SetComponent<CharacterCache>(component);
				if (!(_Instance != null))
				{
					throw new AssertionFailedException("_Instance != null");
				}
			}
			return _Instance;
		}
	}

	public bool IsWorking => ((ICollection)reqQueue).Count > 0;

	public CharacterCache()
	{
		cache = new Dictionary<string, GameObject>();
		reqQueue = new Queue<RuntimeAssetBundleDB.Req>();
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public GameObject load(string prefabName)
	{
		if (string.IsNullOrEmpty(prefabName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(prefabName)");
		}
		GameObject value = null;
		cache.TryGetValue(prefabName, out value);
		object result;
		if (value == null)
		{
			if (cache.ContainsKey(prefabName))
			{
				cache.Remove(prefabName);
			}
			if (!hasRequest(prefabName))
			{
				RuntimeAssetBundleDB.Req req = RuntimeAssetBundleDB.Instance.loadPrefab(prefabName);
				if (req == null)
				{
					throw new AssertionFailedException("r != null");
				}
				reqQueue.Enqueue(req);
			}
			result = null;
		}
		else
		{
			result = value;
		}
		return (GameObject)result;
	}

	public bool contains(string prefabName)
	{
		return !string.IsNullOrEmpty(prefabName) && cache.ContainsKey(prefabName) && cache[prefabName] != null;
	}

	public void dispose()
	{
		cache.Clear();
	}

	private bool hasRequest(string prefabName)
	{
		bool flag;
		foreach (RuntimeAssetBundleDB.Req item in reqQueue)
		{
			if (!(item.PrefabName == prefabName))
			{
				continue;
			}
			flag = true;
			goto IL_0051;
		}
		int result = 0;
		goto IL_0052;
		IL_0051:
		result = (flag ? 1 : 0);
		goto IL_0052;
		IL_0052:
		return (byte)result != 0;
	}

	private IEnumerator main()
	{
		return new _0024main_002418423(this).GetEnumerator();
	}
}
