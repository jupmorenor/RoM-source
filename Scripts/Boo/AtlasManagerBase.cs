using System;
using System.Collections.Generic;
using Boo.Lang;
using GameAsset;
using UnityEngine;

[Serializable]
public class AtlasManagerBase : MonoBehaviour
{
	private Dictionary<string, UIAtlas> _cache;

	public Dictionary<string, UIAtlas> cache => _cache;

	public AtlasManagerBase()
	{
		_cache = new Dictionary<string, UIAtlas>();
	}

	public void OnDestroy()
	{
		dispose();
	}

	public UIAtlas load(string path, string atlasName)
	{
		UIAtlas result = null;
		if (cache.ContainsKey(atlasName))
		{
			result = cache[atlasName];
		}
		else
		{
			GameObject gameObject = GameAssetModule.LoadPrefab(path + atlasName) as GameObject;
			if ((bool)gameObject)
			{
				result = gameObject.GetComponent<UIAtlas>();
			}
		}
		return result;
	}

	public virtual Boo.Lang.List<UIAtlas> init()
	{
		return null;
	}

	public void dispose()
	{
		foreach (UIAtlas value in cache.Values)
		{
			Resources.UnloadAsset(value);
		}
		cache.Clear();
	}

	public UIAtlas getAtlas(string iconName)
	{
		Boo.Lang.List<UIAtlas> list = init();
		UIAtlas uIAtlas;
		object result;
		if (list != null)
		{
			IEnumerator<UIAtlas> enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					UIAtlas current = enumerator.Current;
					BetterList<string> listOfSprites = current.GetListOfSprites();
					if (listOfSprites == null || !listOfSprites.Contains(iconName))
					{
						continue;
					}
					uIAtlas = current;
					goto IL_0068;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = null;
		}
		else
		{
			result = null;
		}
		goto IL_006a;
		IL_006a:
		return (UIAtlas)result;
		IL_0068:
		result = uIAtlas;
		goto IL_006a;
	}
}
