using System;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class QuestAssets : MonoBehaviour
{
	[NonSerialized]
	private static QuestAssets _Instance;

	public QuestKusamushi 草虫;

	public TreasureGet 宝箱低級;

	public TreasureGet 宝箱中級;

	public TreasureGet 宝箱高級;

	public PotionGet まんまるドロップ;

	public NutGet 魔法のクルミ;

	public PotionGet ステージまんまるドロップ;

	public NutGet ステージ魔法のクルミ;

	public QuestKeyItem キーアイテム;

	public Ef_Coin_Scatter コイン;

	public Ef_Coin_Scatter ステージコイン;

	public GameObject 出現煙;

	public GameObject 死亡煙;

	public GameObject エリートエフェクト;

	public GameObject ボスサイン;

	public BattleHUDChainSkillLogo 連携技表示ロゴ;

	public static bool Exists => _Instance != null;

	public static QuestAssets Instance
	{
		get
		{
			if (_Instance == null)
			{
				GameObject gameObject = GameAssetModule.LoadPrefab("Prefab/QuestAssets") as GameObject;
				if (!(gameObject != null))
				{
					throw new AssertionFailedException("prefab != null");
				}
				GameObject gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
				if (!(gameObject2 != null))
				{
					throw new AssertionFailedException("obj != null");
				}
				_Instance = gameObject2.GetComponent<QuestAssets>();
				if (!(_Instance != null))
				{
					throw new AssertionFailedException("_Instance != null");
				}
			}
			return _Instance;
		}
	}

	public static void Unload()
	{
		if (_Instance != null)
		{
			UnityEngine.Object.Destroy(_Instance);
		}
		_Instance = null;
	}

	public QuestKusamushi instantiateKusamushi()
	{
		if (草虫 != null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '草虫') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(草虫.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '草虫') + ' をinstantiateできません'");
		}
		QuestKusamushi questKusamushi = ExtensionsModule.SetComponent<QuestKusamushi>(gameObject);
		if (questKusamushi == null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " に" + "QuestKusamushi" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '草虫') + ' に') + 'QuestKusamushi') + 'を貼れません'");
		}
		return questKusamushi;
	}

	public QuestKusamushi instantiateKusamushi(Vector3 position, Quaternion rotation)
	{
		if (草虫 != null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '草虫') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(草虫.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '草虫') + ' をinstantiateできません'");
		}
		QuestKusamushi questKusamushi = ExtensionsModule.SetComponent<QuestKusamushi>(gameObject);
		if (questKusamushi == null && string.IsNullOrEmpty("QuestAsset: " + "草虫" + " に" + "QuestKusamushi" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '草虫') + ' に') + 'QuestKusamushi') + 'を貼れません'");
		}
		return questKusamushi;
	}

	public TreasureGet instantiateTreasureLow()
	{
		if (宝箱低級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱低級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱低級.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱低級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱低級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public TreasureGet instantiateTreasureLow(Vector3 position, Quaternion rotation)
	{
		if (宝箱低級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱低級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱低級.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱低級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱低級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱低級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public TreasureGet instantiateTreasureMid()
	{
		if (宝箱中級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱中級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱中級.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱中級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱中級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public TreasureGet instantiateTreasureMid(Vector3 position, Quaternion rotation)
	{
		if (宝箱中級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱中級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱中級.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱中級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱中級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱中級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public TreasureGet instantiateTreasureHigh()
	{
		if (宝箱高級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱高級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱高級.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱高級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱高級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public TreasureGet instantiateTreasureHigh(Vector3 position, Quaternion rotation)
	{
		if (宝箱高級 != null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱高級') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(宝箱高級.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '宝箱高級') + ' をinstantiateできません'");
		}
		TreasureGet treasureGet = ExtensionsModule.SetComponent<TreasureGet>(gameObject);
		if (treasureGet == null && string.IsNullOrEmpty("QuestAsset: " + "宝箱高級" + " に" + "TreasureGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '宝箱高級') + ' に') + 'TreasureGet') + 'を貼れません'");
		}
		return treasureGet;
	}

	public PotionGet instantiateCandy()
	{
		if (まんまるドロップ != null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'まんまるドロップ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(まんまるドロップ.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'まんまるドロップ') + ' をinstantiateできません'");
		}
		PotionGet potionGet = ExtensionsModule.SetComponent<PotionGet>(gameObject);
		if (potionGet == null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " に" + "PotionGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'まんまるドロップ') + ' に') + 'PotionGet') + 'を貼れません'");
		}
		return potionGet;
	}

	public PotionGet instantiateCandy(Vector3 position, Quaternion rotation)
	{
		if (まんまるドロップ != null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'まんまるドロップ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(まんまるドロップ.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'まんまるドロップ') + ' をinstantiateできません'");
		}
		PotionGet potionGet = ExtensionsModule.SetComponent<PotionGet>(gameObject);
		if (potionGet == null && string.IsNullOrEmpty("QuestAsset: " + "まんまるドロップ" + " に" + "PotionGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'まんまるドロップ') + ' に') + 'PotionGet') + 'を貼れません'");
		}
		return potionGet;
	}

	public NutGet instantiateNut()
	{
		if (魔法のクルミ != null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '魔法のクルミ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(魔法のクルミ.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '魔法のクルミ') + ' をinstantiateできません'");
		}
		NutGet nutGet = ExtensionsModule.SetComponent<NutGet>(gameObject);
		if (nutGet == null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " に" + "NutGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '魔法のクルミ') + ' に') + 'NutGet') + 'を貼れません'");
		}
		return nutGet;
	}

	public NutGet instantiateNut(Vector3 position, Quaternion rotation)
	{
		if (魔法のクルミ != null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '魔法のクルミ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(魔法のクルミ.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '魔法のクルミ') + ' をinstantiateできません'");
		}
		NutGet nutGet = ExtensionsModule.SetComponent<NutGet>(gameObject);
		if (nutGet == null && string.IsNullOrEmpty("QuestAsset: " + "魔法のクルミ" + " に" + "NutGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '魔法のクルミ') + ' に') + 'NutGet') + 'を貼れません'");
		}
		return nutGet;
	}

	public PotionGet instantiateStageCandy()
	{
		if (ステージまんまるドロップ != null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージまんまるドロップ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージまんまるドロップ.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージまんまるドロップ') + ' をinstantiateできません'");
		}
		PotionGet potionGet = ExtensionsModule.SetComponent<PotionGet>(gameObject);
		if (potionGet == null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " に" + "PotionGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージまんまるドロップ') + ' に') + 'PotionGet') + 'を貼れません'");
		}
		return potionGet;
	}

	public PotionGet instantiateStageCandy(Vector3 position, Quaternion rotation)
	{
		if (ステージまんまるドロップ != null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージまんまるドロップ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージまんまるドロップ.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージまんまるドロップ') + ' をinstantiateできません'");
		}
		PotionGet potionGet = ExtensionsModule.SetComponent<PotionGet>(gameObject);
		if (potionGet == null && string.IsNullOrEmpty("QuestAsset: " + "ステージまんまるドロップ" + " に" + "PotionGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージまんまるドロップ') + ' に') + 'PotionGet') + 'を貼れません'");
		}
		return potionGet;
	}

	public NutGet instantiateStageNut()
	{
		if (ステージ魔法のクルミ != null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージ魔法のクルミ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージ魔法のクルミ.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージ魔法のクルミ') + ' をinstantiateできません'");
		}
		NutGet nutGet = ExtensionsModule.SetComponent<NutGet>(gameObject);
		if (nutGet == null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " に" + "NutGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージ魔法のクルミ') + ' に') + 'NutGet') + 'を貼れません'");
		}
		return nutGet;
	}

	public NutGet instantiateStageNut(Vector3 position, Quaternion rotation)
	{
		if (ステージ魔法のクルミ != null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージ魔法のクルミ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージ魔法のクルミ.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージ魔法のクルミ') + ' をinstantiateできません'");
		}
		NutGet nutGet = ExtensionsModule.SetComponent<NutGet>(gameObject);
		if (nutGet == null && string.IsNullOrEmpty("QuestAsset: " + "ステージ魔法のクルミ" + " に" + "NutGet" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージ魔法のクルミ') + ' に') + 'NutGet') + 'を貼れません'");
		}
		return nutGet;
	}

	public QuestKeyItem instantiateKeyItem()
	{
		if (キーアイテム != null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'キーアイテム') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(キーアイテム.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'キーアイテム') + ' をinstantiateできません'");
		}
		QuestKeyItem questKeyItem = ExtensionsModule.SetComponent<QuestKeyItem>(gameObject);
		if (questKeyItem == null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " に" + "QuestKeyItem" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'キーアイテム') + ' に') + 'QuestKeyItem') + 'を貼れません'");
		}
		return questKeyItem;
	}

	public QuestKeyItem instantiateKeyItem(Vector3 position, Quaternion rotation)
	{
		if (キーアイテム != null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'キーアイテム') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(キーアイテム.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'キーアイテム') + ' をinstantiateできません'");
		}
		QuestKeyItem questKeyItem = ExtensionsModule.SetComponent<QuestKeyItem>(gameObject);
		if (questKeyItem == null && string.IsNullOrEmpty("QuestAsset: " + "キーアイテム" + " に" + "QuestKeyItem" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'キーアイテム') + ' に') + 'QuestKeyItem') + 'を貼れません'");
		}
		return questKeyItem;
	}

	public Ef_Coin_Scatter instantiateCoin()
	{
		if (コイン != null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'コイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(コイン.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'コイン') + ' をinstantiateできません'");
		}
		Ef_Coin_Scatter ef_Coin_Scatter = ExtensionsModule.SetComponent<Ef_Coin_Scatter>(gameObject);
		if (ef_Coin_Scatter == null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " に" + "Ef_Coin_Scatter" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'コイン') + ' に') + 'Ef_Coin_Scatter') + 'を貼れません'");
		}
		return ef_Coin_Scatter;
	}

	public Ef_Coin_Scatter instantiateCoin(Vector3 position, Quaternion rotation)
	{
		if (コイン != null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'コイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(コイン.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'コイン') + ' をinstantiateできません'");
		}
		Ef_Coin_Scatter ef_Coin_Scatter = ExtensionsModule.SetComponent<Ef_Coin_Scatter>(gameObject);
		if (ef_Coin_Scatter == null && string.IsNullOrEmpty("QuestAsset: " + "コイン" + " に" + "Ef_Coin_Scatter" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'コイン') + ' に') + 'Ef_Coin_Scatter') + 'を貼れません'");
		}
		return ef_Coin_Scatter;
	}

	public Ef_Coin_Scatter instantiateStageCoin()
	{
		if (ステージコイン != null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージコイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージコイン.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージコイン') + ' をinstantiateできません'");
		}
		Ef_Coin_Scatter ef_Coin_Scatter = ExtensionsModule.SetComponent<Ef_Coin_Scatter>(gameObject);
		if (ef_Coin_Scatter == null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " に" + "Ef_Coin_Scatter" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージコイン') + ' に') + 'Ef_Coin_Scatter') + 'を貼れません'");
		}
		return ef_Coin_Scatter;
	}

	public Ef_Coin_Scatter instantiateStageCoin(Vector3 position, Quaternion rotation)
	{
		if (ステージコイン != null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージコイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ステージコイン.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ステージコイン') + ' をinstantiateできません'");
		}
		Ef_Coin_Scatter ef_Coin_Scatter = ExtensionsModule.SetComponent<Ef_Coin_Scatter>(gameObject);
		if (ef_Coin_Scatter == null && string.IsNullOrEmpty("QuestAsset: " + "ステージコイン" + " に" + "Ef_Coin_Scatter" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + 'ステージコイン') + ' に') + 'Ef_Coin_Scatter') + 'を貼れません'");
		}
		return ef_Coin_Scatter;
	}

	public GameObject instantiatePopSmoke()
	{
		if (出現煙 != null && string.IsNullOrEmpty("QuestAsset: " + "出現煙" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '出現煙') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(出現煙.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "出現煙" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '出現煙') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiatePopSmoke(Vector3 position, Quaternion rotation)
	{
		if (出現煙 != null && string.IsNullOrEmpty("QuestAsset: " + "出現煙" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '出現煙') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(出現煙.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "出現煙" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '出現煙') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateDeadSmoke()
	{
		if (死亡煙 != null && string.IsNullOrEmpty("QuestAsset: " + "死亡煙" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '死亡煙') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(死亡煙.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "死亡煙" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '死亡煙') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateDeadSmoke(Vector3 position, Quaternion rotation)
	{
		if (死亡煙 != null && string.IsNullOrEmpty("QuestAsset: " + "死亡煙" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '死亡煙') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(死亡煙.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "死亡煙" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '死亡煙') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateEliteEffect()
	{
		if (エリートエフェクト != null && string.IsNullOrEmpty("QuestAsset: " + "エリートエフェクト" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'エリートエフェクト') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(エリートエフェクト.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "エリートエフェクト" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'エリートエフェクト') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateEliteEffect(Vector3 position, Quaternion rotation)
	{
		if (エリートエフェクト != null && string.IsNullOrEmpty("QuestAsset: " + "エリートエフェクト" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'エリートエフェクト') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(エリートエフェクト.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "エリートエフェクト" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'エリートエフェクト') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateBossSign()
	{
		if (ボスサイン != null && string.IsNullOrEmpty("QuestAsset: " + "ボスサイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ボスサイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ボスサイン.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ボスサイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ボスサイン') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateBossSign(Vector3 position, Quaternion rotation)
	{
		if (ボスサイン != null && string.IsNullOrEmpty("QuestAsset: " + "ボスサイン" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ボスサイン') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ボスサイン.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ボスサイン" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ボスサイン') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public BattleHUDChainSkillLogo instantiateChainSkillLogo()
	{
		if (連携技表示ロゴ != null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '連携技表示ロゴ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(連携技表示ロゴ.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '連携技表示ロゴ') + ' をinstantiateできません'");
		}
		BattleHUDChainSkillLogo battleHUDChainSkillLogo = ExtensionsModule.SetComponent<BattleHUDChainSkillLogo>(gameObject);
		if (battleHUDChainSkillLogo == null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " に" + "BattleHUDChainSkillLogo" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '連携技表示ロゴ') + ' に') + 'BattleHUDChainSkillLogo') + 'を貼れません'");
		}
		return battleHUDChainSkillLogo;
	}

	public BattleHUDChainSkillLogo instantiateChainSkillLogo(Vector3 position, Quaternion rotation)
	{
		if (連携技表示ロゴ != null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '連携技表示ロゴ') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(連携技表示ロゴ.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + '連携技表示ロゴ') + ' をinstantiateできません'");
		}
		BattleHUDChainSkillLogo battleHUDChainSkillLogo = ExtensionsModule.SetComponent<BattleHUDChainSkillLogo>(gameObject);
		if (battleHUDChainSkillLogo == null && string.IsNullOrEmpty("QuestAsset: " + "連携技表示ロゴ" + " に" + "BattleHUDChainSkillLogo" + "を貼れません"))
		{
			throw new AssertionFailedException("((('QuestAsset: ' + '連携技表示ロゴ') + ' に') + 'BattleHUDChainSkillLogo') + 'を貼れません'");
		}
		return battleHUDChainSkillLogo;
	}

	public TreasureGet instantiateTreasureByLevel(int level)
	{
		return level switch
		{
			1 => instantiateTreasureLow(), 
			2 => instantiateTreasureMid(), 
			3 => instantiateTreasureHigh(), 
			_ => null, 
		};
	}
}
