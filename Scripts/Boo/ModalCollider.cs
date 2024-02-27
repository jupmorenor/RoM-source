using System;
using System.Collections;
using GameAsset;
using UnityEngine;

[Serializable]
public class ModalCollider : MonoBehaviour
{
	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/HUD/Dialog UI Root";

	[NonSerialized]
	private static ModalCollider __instance;

	[NonSerialized]
	protected static bool quitApp;

	public Transform dialogCamera;

	public GameObject modalCollider;

	public UIButtonMessage buttonMessage;

	[NonSerialized]
	protected static Hashtable modalTable = new Hashtable();

	public static ModalCollider Instance
	{
		get
		{
			ModalCollider _instance;
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
				__instance = ((ModalCollider)UnityEngine.Object.FindObjectOfType(typeof(ModalCollider))) as ModalCollider;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static ModalCollider CurrentInstance => __instance;

	public static Hashtable ModalTable => modalTable;

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242551();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static ModalCollider _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/HUD/Dialog UI Root");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "ModalCollider" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		ModalCollider modalCollider = ExtensionsModule.SetComponent<ModalCollider>(gameObject2);
		if ((bool)modalCollider)
		{
			modalCollider._createInstance_callback();
		}
		return modalCollider;
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

	public void _0024singleton_0024appQuit_00242552()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242552();
		quitApp = true;
	}

	public static GameObject GetCollider()
	{
		return Instance.modalCollider;
	}

	public void OnLevelWasLoaded(int level)
	{
		initialize();
	}

	public void _0024singleton_0024awake_00242551()
	{
		initialize();
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
		if (modalTable.Count > 0 && !modalCollider.activeSelf)
		{
			modalCollider.SetActive(value: true);
		}
	}

	private void initialize()
	{
		BoxCollider component = modalCollider.GetComponent<BoxCollider>();
		int i = 0;
		Camera[] allCameras = Camera.allCameras;
		for (int length = allCameras.Length; i < length; i = checked(i + 1))
		{
			if (allCameras[i].gameObject.layer == modalCollider.layer)
			{
				component.isTrigger = true;
				int num = 200000;
				Vector3 size = component.size;
				float num2 = (size.x = num);
				Vector3 vector2 = (component.size = size);
				int num3 = 200000;
				Vector3 size2 = component.size;
				float num4 = (size2.y = num3);
				Vector3 vector4 = (component.size = size2);
				int num5 = 0;
				Vector3 center = component.center;
				float num6 = (center.x = num5);
				Vector3 vector6 = (component.center = center);
				int num7 = 0;
				Vector3 center2 = component.center;
				float num8 = (center2.y = num7);
				Vector3 vector8 = (component.center = center2);
				int num9 = 0;
				Vector3 center3 = component.center;
				float num10 = (center3.z = num9);
				Vector3 vector10 = (component.center = center3);
				modalCollider.SetActive(value: false);
				break;
			}
		}
		int num11 = 1;
		Vector3 localScale = modalCollider.gameObject.transform.localScale;
		float num12 = (localScale.x = num11);
		Vector3 vector12 = (modalCollider.gameObject.transform.localScale = localScale);
		int num13 = 1;
		Vector3 localScale2 = modalCollider.gameObject.transform.localScale;
		float num14 = (localScale2.y = num13);
		Vector3 vector14 = (modalCollider.gameObject.transform.localScale = localScale2);
		Vector3 lossyScale = modalCollider.gameObject.transform.lossyScale;
		lossyScale.z = 1f;
		modalCollider.SetActive(modalTable.Count > 0);
	}

	public static void SetActive(UnityEngine.Object callObject, bool active)
	{
		int instanceID = callObject.GetInstanceID();
		bool flag = active;
		if (active)
		{
			modalTable[instanceID] = active;
		}
		else
		{
			if (modalTable.ContainsKey(instanceID))
			{
				modalTable.Remove(instanceID);
			}
			active = modalTable.Count > 0;
		}
		if ((bool)Instance.modalCollider)
		{
			Instance.modalCollider.SetActive(active);
		}
	}

	public void AddLayer(int layer)
	{
		int num = 1 << layer;
		dialogCamera.gameObject.GetComponent<Camera>().cullingMask |= num;
		UICamera component = dialogCamera.gameObject.GetComponent<UICamera>();
		component.eventReceiverMask = (int)component.eventReceiverMask | num;
	}

	public void RemoveLayer(int layer)
	{
		int num = 1 << layer;
		dialogCamera.gameObject.GetComponent<Camera>().cullingMask &= ~num;
		UICamera component = dialogCamera.gameObject.GetComponent<UICamera>();
		component.eventReceiverMask = (int)component.eventReceiverMask & ~num;
	}
}
