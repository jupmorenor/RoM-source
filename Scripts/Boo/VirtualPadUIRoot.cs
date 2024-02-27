using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class VirtualPadUIRoot : MonoBehaviour
{
	public GameObject stick;

	public Camera maincamera;

	[NonSerialized]
	private static VirtualPadUIRoot _Instance;

	private short zOffset;

	private Vector2 CurrentPos;

	private Vector2 Direction;

	private Vector2 DirectionNormal;

	private Vector3 StatPos;

	private bool touchIcon;

	private bool isTutorial;

	private Vector3 initPosition;

	private int layer2DUI;

	public static bool TouchIcon => _Instance != null && _Instance.touchIcon;

	private bool IsInvalidSetting
	{
		get
		{
			bool num = maincamera == null;
			if (!num)
			{
				num = stick == null;
			}
			return num;
		}
	}

	public VirtualPadUIRoot()
	{
		zOffset = (short)(-10);
		CurrentPos = Vector2.zero;
		Direction = Vector2.zero;
		DirectionNormal = Vector2.zero;
		StatPos = Vector3.zero;
		initPosition = new Vector3(-350f, -150f, zOffset);
	}

	public void Awake()
	{
	}

	public void Start()
	{
		_Instance = this;
		gameObject.SetActive(value: false);
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(SceneChangeEvent);
	}

	public void OnDestroy()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(SceneChangeEvent);
		if (_Instance == this)
		{
			_Instance = null;
		}
	}

	public void SceneChangeEvent()
	{
		HideVirtualPad();
	}

	public static void ShowVirtualPad(Vector3 defaultPos)
	{
		if (_Instance != null)
		{
			if (UserData.Current.Config.VirtualPadImageOn)
			{
				_Instance._ShowVirtualPad(defaultPos);
			}
			else
			{
				_Instance._HideVirtualPad();
			}
		}
	}

	public static void HideVirtualPad()
	{
		if (_Instance != null)
		{
			_Instance._HideVirtualPad();
		}
	}

	public static void MoveVirtualPad(Vector3 movepos)
	{
		if (_Instance != null)
		{
			if (UserData.Current.Config.VirtualPadImageOn)
			{
				_Instance._MoveVirtualPad(movepos);
			}
			else
			{
				_Instance._HideVirtualPad();
			}
		}
	}

	private void _ShowVirtualPad(Vector3 defaultPos)
	{
		if (!IsInvalidSetting)
		{
			Vector3 zero = Vector3.zero;
			Ray ray = maincamera.ScreenPointToRay(defaultPos);
			zero = new Vector3(ray.origin.x, ray.origin.y, 0f);
			gameObject.transform.position = zero;
			short num = zOffset;
			Vector3 localPosition = gameObject.transform.localPosition;
			float num2 = (localPosition.z = num);
			Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
			RaycastHit hitInfo = default(RaycastHit);
			bool flag = false;
			if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hitInfo, 200f) && 23 == hitInfo.collider.gameObject.layer)
			{
				touchIcon = true;
				return;
			}
			touchIcon = false;
			gameObject.SetActive(value: true);
		}
	}

	private void _HideVirtualPad()
	{
		if (!IsInvalidSetting && gameObject.activeSelf)
		{
			gameObject.SetActive(value: false);
			stick.transform.localPosition = new Vector3(0f, 0f, zOffset);
			gameObject.transform.localPosition = new Vector3(0f, 0f, zOffset);
		}
	}

	private void _MoveVirtualPad(Vector3 movepos)
	{
		if (!IsInvalidSetting)
		{
			Vector3 zero = Vector3.zero;
			Ray ray = maincamera.ScreenPointToRay(movepos);
			zero = new Vector3(ray.origin.x, ray.origin.y, 0f);
			short num = (short)50;
			stick.transform.position = zero;
			int num2 = 0;
			Vector3 localPosition = stick.transform.localPosition;
			float num3 = (localPosition.z = num2);
			Vector3 vector2 = (stick.transform.localPosition = localPosition);
			short num4 = checked((short)Mathf.Abs(Vector3.Distance(Vector3.zero, stick.transform.localPosition)));
			if (num4 > num)
			{
				stick.transform.localPosition = stick.transform.localPosition.normalized * 50f;
			}
			int num5 = -10;
			Vector3 localPosition2 = stick.transform.localPosition;
			float num6 = (localPosition2.z = num5);
			Vector3 vector4 = (stick.transform.localPosition = localPosition2);
		}
	}

	private bool SceneCheck()
	{
		return (SceneChanger.CurrentSceneName.StartsWith("Town") || SceneChanger.CurrentSceneName.StartsWith("Myhome")) ? true : false;
	}

	private void showTutorialMode()
	{
		if (QuestInitializer.IsInQuestScene("TutorialM000"))
		{
			isTutorial = true;
			gameObject.SetActive(value: true);
		}
	}

	private void hideTutorialMode()
	{
		if (!QuestInitializer.IsInQuestScene("TutorialM000"))
		{
			isTutorial = false;
			gameObject.SetActive(value: false);
			BattleHUD.DisableTutorialArrows();
		}
	}

	public void Update()
	{
	}
}
