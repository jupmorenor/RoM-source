using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class InventoryOverDialog : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		Back,
		Stoneshop,
		Blacksmith
	}

	[NonSerialized]
	private static readonly string[] ERROR_BTNS = new string[3] { "戻る", "精霊石で拡張", "工房" };

	[NonSerialized]
	private static PlayerControl player;

	[NonSerialized]
	private static GameObject instance;

	[NonSerialized]
	public static __InventoryOverDialog_PushCallBack_0024callable97_002412_35__ pushCallBack;

	private SceneID backSceneId;

	private bool destroyTownModel;

	public static GameObject Instance => instance;

	public static __InventoryOverDialog_PushCallBack_0024callable97_002412_35__ PushCallBack
	{
		get
		{
			return pushCallBack;
		}
		set
		{
			pushCallBack = value;
		}
	}

	public InventoryOverDialog()
	{
		backSceneId = SceneID.Town;
	}

	public static bool IsInventoryOver()
	{
		UserData current = UserData.Current;
		return current.BoxCount > current.BoxCapacity;
	}

	public static bool IsOpenInventoryOverDialog()
	{
		return instance != null;
	}

	public static GameObject OpenInventoryOverDialog(SceneID backScene)
	{
		if (IsInventoryOver() && !instance)
		{
			SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(OnPreSceneChange);
			UnityEngine.Object original = GameAssetModule.LoadPrefab("Prefab/GUI/ItemOverflow");
			GameObject gameObject = UnityEngine.Object.Instantiate(original) as GameObject;
			GameObject gameObject2 = ModalCollider.GetCollider();
			gameObject.transform.parent = gameObject2.transform.parent;
			player = ((PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl))) as PlayerControl;
			if (player != null && player.InputActive)
			{
				player.InputActive = false;
			}
			else
			{
				player = null;
			}
			gameObject.transform.localPosition = Vector3.zero;
			instance = gameObject;
			ModalCollider.SetActive(instance, active: true);
			InventoryOverDialog componentInChildren = gameObject.GetComponentInChildren<InventoryOverDialog>();
			if ((bool)componentInChildren)
			{
				componentInChildren.backSceneId = backScene;
			}
		}
		return instance;
	}

	public void Start()
	{
		Setup();
	}

	public void OnEnable()
	{
		if ((bool)instance)
		{
			ModalCollider.SetActive(instance, active: true);
		}
		UIButtonMessage.AllDisable = false;
	}

	public void OnDisable()
	{
		if ((bool)instance)
		{
			ModalCollider.SetActive(instance, active: false);
		}
	}

	public void Setup()
	{
		UserData current = UserData.Current;
		int num = 0;
		int length = ERROR_BTNS.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject parent = gameObject;
			string panelName = index.ToString();
			string[] eRROR_BTNS = ERROR_BTNS;
			UpdateButton(parent, panelName, eRROR_BTNS[RuntimeServices.NormalizeArrayIndex(eRROR_BTNS, index)], gameObject);
		}
		ExtensionsModule.FindChild(gameObject, "TextTitle").GetComponent<UILabelBase>().text = "ボックスがいっぱいです";
		ExtensionsModule.FindChild(gameObject, "TextMessage").GetComponent<UILabelBase>().text = "ボックスを拡張するか合成、売却をして\nボックスを空けてください。";
		ExtensionsModule.FindChild(gameObject, "TextNum").GetComponent<UILabelBase>().text = UIBasicUtility.SafeFormat("{0}個オーバーしています。{1}/{2}", checked(current.BoxCount - current.BoxCapacity), current.BoxCount, current.BoxCapacity);
	}

	private void UpdateButton(GameObject parent, string panelName, string text, GameObject target)
	{
		GameObject gameObject = ExtensionsModule.FindChild(parent, panelName);
		ExtensionsModule.FindChild(gameObject, "Text").GetComponent<UILabelBase>().text = text;
		UIButtonMessage uIButtonMessage = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
		uIButtonMessage.eventHandler = _0024adaptor_0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024EventHandler_0024179.Adapt(Push);
	}

	private void Push(GameObject go)
	{
		Push((Mode)int.Parse(go.name));
	}

	private void Push(Mode index)
	{
		bool flag = false;
		if (pushCallBack != null)
		{
			flag = pushCallBack(index);
		}
		pushCallBack = null;
		destroyTownModel = true;
		if (!flag)
		{
			switch (index)
			{
			case Mode.Blacksmith:
				SceneChanger.ChangeTo(SceneID.Ui_TownBlacksmith);
				break;
			case Mode.Stoneshop:
				SceneChanger.ChangeTo(SceneID.Ui_TownStoneShop);
				break;
			case Mode.Back:
				SceneChanger.ChangeTo(backSceneId);
				break;
			}
		}
		gameObject.SetActive(value: false);
	}

	public static void OnPreSceneChange()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(OnPreSceneChange);
		UnityEngine.Object.DestroyObject(instance);
	}

	public void OnDestroy()
	{
		if (player != null)
		{
			player.InputActive = true;
		}
		if ((bool)instance)
		{
			ModalCollider.SetActive(instance, active: false);
		}
		if (destroyTownModel)
		{
			TownShopTopMain.DestroyTownModel(destroy: true);
		}
		instance = null;
	}

	public static void PushBack()
	{
		if ((bool)Instance)
		{
			InventoryOverDialog componentInChildren = Instance.GetComponentInChildren<InventoryOverDialog>();
			if ((bool)componentInChildren)
			{
				componentInChildren.Push(Mode.Back);
			}
		}
	}
}
