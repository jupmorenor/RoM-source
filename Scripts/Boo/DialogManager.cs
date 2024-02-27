using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class DialogManager : MonoBehaviour
{
	[Serializable]
	public enum MB_FLAG
	{
		MB_NONE,
		MB_ICONEXCLAMATION,
		MB_ICONWARNING,
		MB_ICONINFORMATION,
		MB_ICONASTERISK,
		MB_ICONQUESTION,
		MB_ICONSTOP,
		MB_ICONERROR,
		MB_ICONHAND
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/DialogManager";

	[NonSerialized]
	private static DialogManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	public bool dontDestroyOnLoad;

	public float dialogLayerZ;

	public float dialogLayerOffset;

	public UISprite iconExclamation;

	public UISprite iconWarning;

	public UISprite iconInformation;

	public UISprite iconAsterisk;

	public UISprite iconQuestion;

	public UISprite iconStop;

	public UISprite iconError;

	public UISprite iconHand;

	public UnityEngine.Object dialog1ButtonPrefab;

	public UnityEngine.Object dialog2ButtonPrefab;

	public UnityEngine.Object dialog3ButtonPrefab;

	public GameObject[] customDialogPrefab;

	public int textDurationMSec;

	public GameObject testCh1Icon;

	public GameObject testCh2Icon;

	public bool testFlag;

	[NonSerialized]
	public static bool GlobalTestFlag;

	public float chInSpeedPerMSec;

	private List<GameObject> dialogList;

	private GameObject modalCol;

	private int lastDialogCount;

	private EventWindow evWnd;

	[NonSerialized]
	private static int lastResult;

	private bool started;

	private bool _alreadyActiveCollider;

	public static DialogManager Instance
	{
		get
		{
			DialogManager _instance;
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
				__instance = ((DialogManager)UnityEngine.Object.FindObjectOfType(typeof(DialogManager))) as DialogManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static DialogManager CurrentInstance => __instance;

	public static int DialogCount => CurrentInstance ? CurrentInstance.dialogList.Count : 0;

	public static GameObject[] DialogArray => (!CurrentInstance) ? new GameObject[0] : CurrentInstance.dialogList.ToArray();

	public static Dialog CurrentDialog
	{
		get
		{
			GameObject[] dialogArray = DialogArray;
			GameObject gameObject = dialogArray[RuntimeServices.NormalizeArrayIndex(dialogArray, Mathf.Max(0, checked(DialogCount - 1)))];
			return (!gameObject) ? null : gameObject.GetComponent<Dialog>();
		}
	}

	public static int InitLastResult
	{
		set
		{
			lastResult = value;
		}
	}

	public static int LastResult
	{
		get
		{
			return lastResult;
		}
		private set
		{
			lastResult = value;
		}
	}

	private bool alreadyActiveCollider
	{
		get
		{
			return _alreadyActiveCollider;
		}
		set
		{
			_alreadyActiveCollider = value;
		}
	}

	public DialogManager()
	{
		dialogLayerZ = -2000f;
		dialogLayerOffset = -10f;
		textDurationMSec = 500;
		chInSpeedPerMSec = 1f;
		dialogList = new List<GameObject>();
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242489();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static DialogManager _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/DialogManager");
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
		gameObject2.name = "__" + "DialogManager" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		DialogManager dialogManager = ExtensionsModule.SetComponent<DialogManager>(gameObject2);
		if ((bool)dialogManager)
		{
			dialogManager._createInstance_callback();
		}
		return dialogManager;
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

	public void _0024singleton_0024appQuit_00242490()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242490();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00242489()
	{
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
		if (dontDestroyOnLoad)
		{
			SceneDontDestroyObject.dontDestroyOnLoad(this);
		}
	}

	public void OnLevelWasLoaded(int level)
	{
		started = false;
	}

	public void Start()
	{
		started = false;
	}

	public void OnDestroy()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
	}

	public static void ScenePreChangeEvent()
	{
		if ((bool)CurrentInstance)
		{
			CurrentInstance.AllClose(sceneChange: true);
		}
	}

	public void Update()
	{
		if (!started)
		{
			started = true;
			if (!modalCol)
			{
				modalCol = ModalCollider.GetCollider();
			}
		}
		int count = dialogList.Count;
		if (!modalCol || count == lastDialogCount)
		{
			return;
		}
		if (0 < count)
		{
			if (count == 1)
			{
				alreadyActiveCollider = modalCol.activeInHierarchy;
			}
			ModalCollider.SetActive(this, active: true);
			float z = dialogLayerZ - (float)checked(count - 1) * dialogLayerOffset + 1f;
			Vector3 localPosition = modalCol.transform.localPosition;
			float num = (localPosition.z = z);
			Vector3 vector2 = (modalCol.transform.localPosition = localPosition);
		}
		else if (count == 0)
		{
			ModalCollider.SetActive(this, active: false);
			alreadyActiveCollider = false;
		}
		lastDialogCount = count;
	}

	public void OnGUI_()
	{
		if (testFlag || GlobalTestFlag)
		{
			GUILayout.BeginArea(new Rect(400f, 100f, 100f, 200f));
			if (GUILayout.Button("Test Dialog"))
			{
				OpenDialog("Test", "Text" + dialogList.Count, MB_FLAG.MB_ICONEXCLAMATION, new string[3] { "Ok", "Cancel", "Help" });
			}
			GUILayout.EndArea();
		}
	}

	public UISprite GetIcon(MB_FLAG flag)
	{
		return flag switch
		{
			MB_FLAG.MB_ICONEXCLAMATION => iconExclamation, 
			MB_FLAG.MB_ICONWARNING => iconWarning, 
			MB_FLAG.MB_ICONINFORMATION => iconInformation, 
			MB_FLAG.MB_ICONASTERISK => iconAsterisk, 
			MB_FLAG.MB_ICONQUESTION => iconQuestion, 
			MB_FLAG.MB_ICONSTOP => iconStop, 
			MB_FLAG.MB_ICONERROR => iconError, 
			MB_FLAG.MB_ICONHAND => iconHand, 
			_ => null, 
		};
	}

	public void SetSceneActive(bool flag)
	{
		if (flag)
		{
			TimeScaleUtil.One();
		}
		else
		{
			TimeScaleUtil.Zero();
		}
		UIRoot[] array = (UIRoot[])UnityEngine.Object.FindObjectsOfType(typeof(UIRoot));
		int i = 0;
		UIRoot[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i].gameObject == gameObject)
				{
					continue;
				}
				UITweener[] componentsInChildren = array2[i].gameObject.GetComponentsInChildren<UITweener>();
				int j = 0;
				UITweener[] array3 = componentsInChildren;
				for (int length2 = array3.Length; j < length2; j++)
				{
					if (!(array3[j].gameObject.GetComponent<Dialog>() != null))
					{
						array3[j].enabled = flag;
						array3[j].ignoreTimeScale = true;
					}
				}
			}
		}
	}

	public static Dialog Open(string message, string title)
	{
		return Instance.OpenDialog(message, title, autoClose: true, MB_FLAG.MB_NONE, new string[1] { "OK" }, -1);
	}

	public static Dialog Open(string message, string title, string[] buttonString)
	{
		return Instance.OpenDialog(message, title, autoClose: true, MB_FLAG.MB_NONE, buttonString, -1);
	}

	public Dialog OpenDialog(string message, string title)
	{
		return OpenDialog(message, title, autoClose: true, MB_FLAG.MB_NONE, new string[1] { "OK" }, -1);
	}

	public Dialog OpenDialog(string message, string title, string[] buttonString)
	{
		return OpenDialog(message, title, autoClose: true, MB_FLAG.MB_NONE, buttonString, -1);
	}

	public Dialog OpenDialog(string message, string title, MB_FLAG flag, string[] buttonString)
	{
		return OpenDialog(message, title, autoClose: true, flag, buttonString, -1);
	}

	public Dialog OpenCustomDialog(string message, string title, MB_FLAG flag, string[] buttonString, int dialogType)
	{
		return OpenDialog(message, title, autoClose: true, flag, buttonString, dialogType);
	}

	public Dialog OpenDialog(string message, string title, bool autoClose, MB_FLAG flag, string[] buttonString, int dialogType)
	{
		UIButtonMessage.AllDisable = false;
		object result;
		if (modalCol == null)
		{
			modalCol = ModalCollider.GetCollider();
			if (modalCol == null)
			{
				result = null;
				goto IL_01ef;
			}
		}
		GameObject gameObject = null;
		if (dialogType < 0)
		{
			gameObject = ((buttonString.Length == 2) ? (UnityEngine.Object.Instantiate(dialog2ButtonPrefab) as GameObject) : ((buttonString.Length != 3) ? (UnityEngine.Object.Instantiate(dialog1ButtonPrefab) as GameObject) : (UnityEngine.Object.Instantiate(dialog3ButtonPrefab) as GameObject)));
		}
		else if (dialogType < customDialogPrefab.Length)
		{
			GameObject[] array = customDialogPrefab;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, dialogType)])
			{
				GameObject[] array2 = customDialogPrefab;
				gameObject = ((GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, dialogType)])) as GameObject;
			}
		}
		if (gameObject == null)
		{
			result = null;
		}
		else
		{
			Dialog dialog = gameObject.AddComponent("Dialog") as Dialog;
			if (dialog == null)
			{
				UnityEngine.Object.DestroyObject(gameObject);
				result = null;
			}
			else
			{
				dialogList.Add(gameObject);
				int count = dialogList.Count;
				gameObject.transform.parent = modalCol.transform.parent;
				gameObject.transform.localPosition = Vector3.zero;
				float z = dialogLayerZ - (float)checked(count - 1) * dialogLayerOffset;
				Vector3 localPosition = gameObject.transform.localPosition;
				float num = (localPosition.z = z);
				Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
				dialog.Init(this, title, message, autoClose, textDurationMSec, buttonString, GetIcon(flag));
				gameObject.transform.localScale = Vector3.zero;
				result = dialog;
			}
		}
		goto IL_01ef;
		IL_01ef:
		return (Dialog)result;
	}

	public void OnClose(Dialog dlg)
	{
		if ((bool)dlg)
		{
			dialogList.Remove(dlg.gameObject);
			UnityEngine.Object.DestroyObject(dlg.gameObject);
		}
	}

	public void OnButton(int index)
	{
		lastResult = index;
	}

	public void AllClose(bool sceneChange)
	{
		GameObject[] dialogArray = DialogArray;
		int i = 0;
		GameObject[] array = dialogArray;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!array[i])
			{
				continue;
			}
			if (sceneChange)
			{
				Dialog component = array[i].GetComponent<Dialog>();
				if ((bool)component && component.NoCloseSceneChange)
				{
					continue;
				}
			}
			UnityEngine.Object.DestroyObject(array[i]);
			dialogList.Remove(array[i]);
		}
	}
}
