using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class MasterEffectPack : MonoBehaviour
{
	[Serializable]
	public class Entry
	{
		public string name;

		public GameObject prefab;
	}

	public Entry[] entries;

	[NonSerialized]
	private static MasterEffectPack _Instance;

	public static MasterEffectPack Instance
	{
		get
		{
			MasterEffectPack instance;
			if (_Instance != null)
			{
				instance = _Instance;
			}
			else
			{
				GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("MasterEffectPack");
				if (gameObject != null)
				{
					_Instance = gameObject.GetComponent<MasterEffectPack>();
				}
				instance = _Instance;
			}
			return instance;
		}
	}

	public GameObject find(string n)
	{
		int num = 0;
		Entry[] array = entries;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == n)
				{
					result = array[num].prefab;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (GameObject)result;
	}

	public GameObject findAndInstantiate(string n)
	{
		GameObject gameObject = find(n);
		return (!(gameObject == null)) ? ((GameObject)UnityEngine.Object.Instantiate(gameObject)) : null;
	}
}
