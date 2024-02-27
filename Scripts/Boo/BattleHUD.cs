using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BattleHUD : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		None,
		Show,
		ShowForTown,
		ShowForPauseTown,
		ShowNonBattle,
		ShowNonMappetHUD,
		Hide
	}

	public MagicGauge[] HUDMagicGauges;

	public UIButtonMessage DebugStartButton;

	public Transform mainLayerTrans;

	public Transform hudLayerTrans;

	public Transform shortcutLayerTrans;

	public GameObject parameterPrefab;

	[NonSerialized]
	private static BattleHUD _currentInstance;

	[NonSerialized]
	private static List<BattleHUD> _currentInstanceList = new List<BattleHUD>();

	[NonSerialized]
	private static bool tutorialWindow;

	[NonSerialized]
	private static bool isEventWindow;

	public bool debug;

	[NonSerialized]
	private static Mode mode;

	[NonSerialized]
	private static Mode lastMode;

	[NonSerialized]
	private static bool onEnableUpdate;

	public Camera[] HUDCameras;

	public static BattleHUD CurrentInstance => _currentInstance;

	public static bool TutorialWindow
	{
		get
		{
			return tutorialWindow;
		}
		set
		{
			tutorialWindow = value;
		}
	}

	public void OnEnable()
	{
		if (_currentInstanceList.Count > 2)
		{
		}
		_currentInstanceList.Add(this);
		if (_currentInstance != this)
		{
			_currentInstance = this;
		}
		QuestManager.Instance.Setup();
		SetupShortcutIcon();
		onEnableUpdate = true;
		SceneChanger.SceneChangeEvent += sceneChangeEvent;
	}

	public void OnDisable()
	{
		_currentInstanceList.Remove(this);
		if (_currentInstance == this)
		{
			if (_currentInstanceList.Count > 0)
			{
				_currentInstance = _currentInstanceList[checked(_currentInstanceList.Count - 1)];
			}
			else
			{
				_currentInstance = null;
			}
		}
		SceneChanger.SceneChangeEvent -= sceneChangeEvent;
	}

	private void sceneChangeEvent(SceneID sceneId, string sceneName)
	{
		onEnableUpdate = true;
	}

	public void SetupShortcutIcon()
	{
		if (shortcutLayerTrans != null)
		{
			BattleHUDShortcut.SetupShortcutIcon(shortcutLayerTrans);
		}
	}

	private void AddPrefab(Transform parent, GameObject obj)
	{
		AddPrefabEx(parent, obj, Vector3.zero, Vector3.one);
	}

	private void AddPrefabEx(Transform parent, GameObject obj, Vector3 ofs, Vector3 scl)
	{
		obj.transform.parent = parent;
		obj.transform.localScale = scl;
		obj.transform.localPosition = ofs;
	}

	public void Awake()
	{
		debug = false;
		if (SceneChanger.CurrentSceneName.StartsWith("Raid"))
		{
			RaidTimeCount.show();
		}
		AddPrefab(mainLayerTrans, GimmickIconSystem.Create().gameObject);
		string currentSceneName = SceneChanger.CurrentSceneName;
		if (currentSceneName == SceneID.Town.ToString() || currentSceneName == SceneID.Myhome.ToString())
		{
			AddPrefab(hudLayerTrans, (GameObject)UnityEngine.Object.Instantiate(parameterPrefab));
		}
	}

	public void Update()
	{
		if (EventWindow.isWindow == isEventWindow)
		{
			return;
		}
		if (EventWindow.isWindow)
		{
			if (!tutorialWindow)
			{
				Hide();
			}
			isEventWindow = true;
			return;
		}
		isEventWindow = false;
		if (!tutorialWindow)
		{
			LastShowMode();
		}
		tutorialWindow = false;
	}

	public static void SetDebugStartButton(GameObject debugUIObject)
	{
		if (!(CurrentInstance == null))
		{
			UIButtonMessage debugStartButton = CurrentInstance.DebugStartButton;
			if (!(debugStartButton == null))
			{
				debugStartButton.target = debugUIObject;
			}
		}
	}

	public void activateAllButtons(bool b)
	{
		BattleHUDSkill.activateButtons(b);
		BattleHUDMappet.ActivateButtons(b);
		if (DebugStartButton != null)
		{
			DebugStartButton.enabled = b;
		}
	}

	public static void ActivateAllButtons(bool b)
	{
		if (!(CurrentInstance == null))
		{
			CurrentInstance.activateAllButtons(b);
		}
	}

	public void SelectShowMode(Mode showMode)
	{
		if (showMode == Mode.Show)
		{
			Show();
		}
		if (showMode == Mode.ShowForTown)
		{
			ShowForTown();
		}
		if (showMode == Mode.ShowForPauseTown)
		{
			ShowForPauseTown();
		}
		if (showMode == Mode.ShowNonBattle)
		{
			ShowNonBattle();
		}
		if (showMode == Mode.ShowNonMappetHUD)
		{
			ShowNonMappetHUD();
		}
		if (showMode == Mode.Hide)
		{
			Hide();
		}
	}

	public void LastShowMode()
	{
		SelectShowMode(lastMode);
	}

	public static void Show()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.Show || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDPlayerInfo.Show();
				BattleHUDShortcut.Show();
				ApRpExp.Hide();
			}
			BattleHUDMappet.Show();
			BattleHUDSkill.Show();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.Show;
		}
	}

	public static void ShowForTown()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.ShowForTown || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDPlayerInfo.Hide();
				BattleHUDShortcut.Show();
				ApRpExp.Show();
			}
			BattleHUDMappet.Hide();
			BattleHUDSkill.ShowChangeButtonOnly();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.ShowForTown;
		}
	}

	public static void ShowForPauseTown()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.ShowForPauseTown || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDPlayerInfo.Hide();
				BattleHUDShortcut.Hide();
				ApRpExp.Show();
			}
			BattleHUDMappet.Hide();
			BattleHUDSkill.Hide();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.ShowForPauseTown;
		}
	}

	public static void ShowNonBattle()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.ShowNonBattle || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDPlayerInfo.Show();
				BattleHUDShortcut.Hide();
				ApRpExp.Hide();
			}
			BattleHUDMappet.Show();
			BattleHUDSkill.ShowChangeButtonOnly();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.ShowNonBattle;
		}
	}

	public static void ShowNonMappetHUD()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.ShowNonMappetHUD || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDPlayerInfo.Show();
				BattleHUDShortcut.Hide();
				ApRpExp.Hide();
			}
			BattleHUDMappet.Hide();
			BattleHUDSkill.Show();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.ShowNonMappetHUD;
		}
	}

	public static void Hide()
	{
		if (!isEventWindow)
		{
			if (mode != Mode.Hide || onEnableUpdate)
			{
				onEnableUpdate = false;
				BattleHUDMappet.Hide();
				BattleHUDPlayerInfo.Hide();
				BattleHUDShortcut.Hide();
				ApRpExp.Hide();
			}
			BattleHUDMappet.Hide();
			BattleHUDSkill.Hide();
			if (lastMode != mode)
			{
				lastMode = mode;
			}
			mode = Mode.Hide;
		}
	}

	public static MagicGauge GetMagicGauge(int index)
	{
		return (!(CurrentInstance == null)) ? CurrentInstance.getMagicGauge(index) : null;
	}

	private MagicGauge getMagicGauge(int index)
	{
		object result;
		if (index < 0 || index >= HUDMagicGauges.Length)
		{
			result = null;
		}
		else
		{
			MagicGauge[] hUDMagicGauges = HUDMagicGauges;
			result = hUDMagicGauges[RuntimeServices.NormalizeArrayIndex(hUDMagicGauges, index)];
		}
		return (MagicGauge)result;
	}

	public static void DisableTutorialArrows()
	{
		TutorialUI.DisableArrows();
	}

	public static void PointTutorialArrow(int index, GameObject widget)
	{
		TutorialUI.PointArrow(index, widget);
	}

	public static void PointTutorialArrowToPlayerElement()
	{
		TutorialUI.PointArrow(0, null);
	}

	public static void PointTutorialArrowToMapetButton()
	{
		TutorialUI.PointArrow(1);
	}

	public static void PointTutorialArrowToChangeButton()
	{
		TutorialUI.PointArrow(2);
	}

	public static void PointTutorialArrowToSkillButtons()
	{
		TutorialUI.PointArrow(3);
	}

	public static void PointTutorialArrowToEnemyElement()
	{
		TutorialUI.PointArrow(4);
	}

	public static void PointTutorialArrowToAutoBattle()
	{
		TutorialUI.PointArrow(5);
	}

	public static void PointTutorialArrowToQuestNew()
	{
		TutorialUI.PointArrow(5);
	}

	public static void PointTutorialArrowToWeaponSelect()
	{
		TutorialUI.PointArrow(6);
	}

	public static void PointTutorialArrowToPoppetSelect()
	{
		TutorialUI.PointArrow(7);
	}

	public static void PointTutorialArrowToFriendPoppetSelect()
	{
		TutorialUI.PointArrow(8);
	}

	public static void PointTutorialArrowToQuestStart()
	{
		TutorialUI.PointArrow(9);
	}

	public static void PointTutorialArrowToRaidBattleBonus()
	{
		TutorialUI.PointArrow(10);
	}

	public static void PointTutorialArrowToRaidNormalAttack()
	{
		TutorialUI.PointArrow(11);
	}

	public static void PointTutorialArrowToRaidFullAttack()
	{
		TutorialUI.PointArrow(12);
	}

	public static void PointTutorialArrowToQuestSupport()
	{
		TutorialUI.PointArrow(13);
	}

	public static void PointTutorialArrowToQuestEnemyInfo()
	{
		TutorialUI.PointArrow(14);
	}

	public static void PointTutorialArrowToQuestTreasureInfo()
	{
		TutorialUI.PointArrow(15);
	}

	public static void PointTutorialArrowToQuestEnemyInfoWeak()
	{
		TutorialUI.PointArrow(16);
	}

	public static void PointTutorialArrowToQuestDeck()
	{
		TutorialUI.PointArrow(17);
	}

	public static void PointTutorialArrowToColosseumDeckCost()
	{
		TutorialUI.PointArrow(18);
	}

	public static void PointTutorialArrowToColossumFrinendBattle()
	{
		TutorialUI.PointArrow(19);
	}

	public static void PointTutorialArrowToColossumPoppet1()
	{
		TutorialUI.PointArrow(20);
	}

	public static void PointTutorialArrowToColossumPoppet2()
	{
		TutorialUI.PointArrow(21);
	}

	public static void PointTutorialArrowToColossumPoppet3()
	{
		TutorialUI.PointArrow(22);
	}

	public static void PointTutorialArrowToColossumRandombattle()
	{
		TutorialUI.PointArrow(23);
	}

	public static void PointTutorialArrowToColossumRank()
	{
		TutorialUI.PointArrow(24);
	}

	public static void PointTutorialArrowToColossumRecord()
	{
		TutorialUI.PointArrow(25);
	}

	public static void PointTutorialArrowToColossumStart()
	{
		TutorialUI.PointArrow(26);
	}

	public static void PointTutorialArrowToColossumWeapon1()
	{
		TutorialUI.PointArrow(27);
	}

	public static void PointTutorialArrowToColossumWeapon2()
	{
		TutorialUI.PointArrow(28);
	}

	public static void PointTutorialArrowToColossumWeapon3()
	{
		TutorialUI.PointArrow(29);
	}

	public static void PointTutorialArrowToBoxWeapon()
	{
		TutorialUI.PointArrow(1);
		TutorialUI.PointArrow(2);
	}

	public static void PointTutorialArrowToBoxPoppet()
	{
		TutorialUI.PointArrow(0);
	}

	public static void PointTutorialArrowToBoxSupport()
	{
		TutorialUI.PointArrow(3);
	}

	public static void PointTutorialArrowToBoxDeck()
	{
		TutorialUI.PointArrow(4);
	}

	public static void PointTutorialArrowToBoxSupportAtkHp()
	{
		TutorialUI.PointArrow(5);
		TutorialUI.PointArrow(6);
	}

	public static void PointTutorialArrowToBoxSupportPoppetMain()
	{
		TutorialUI.PointArrow(7);
	}

	public static void PointTutorialArrowToBoxSupportPoppetSub()
	{
		TutorialUI.PointArrow(8);
	}

	public static void PointTutorialArrowToBoxSupportWeaponAngelMain()
	{
		TutorialUI.PointArrow(9);
	}

	public static void PointTutorialArrowToBoxSupportWeaponDemonMain()
	{
		TutorialUI.PointArrow(10);
	}

	public static void PointTutorialArrowToBoxSupportWeaponSub()
	{
		TutorialUI.PointArrow(11);
	}

	public static void DisableTutorialImages()
	{
		TutorialUI.DisableImages();
	}

	public static void DrawTutorialMoveTapImage()
	{
		TutorialUI.DrawImage(0);
	}

	public static void DrawTutorialMoveHoldImage()
	{
		TutorialUI.DrawImage(1);
	}

	public static void DrawTutorialChangeImage()
	{
		TutorialUI.DrawImage(2);
	}

	public static void DrawTutorialPlayerHPGaugeImage()
	{
		TutorialUI.DrawImage(3);
	}

	public static void DrawTutorialBunyuImage()
	{
		TutorialUI.DrawImage(4);
	}

	public static void DrawTutorialLockonImage()
	{
		TutorialUI.DrawImage(5);
	}

	public static void DrawTutorialKaihiImage()
	{
		TutorialUI.DrawImage(6);
	}

	public static void DrawTutorialWeaponSkillImage()
	{
		TutorialUI.DrawImage(7);
	}

	public static void DrawTutorialCoolDownImage()
	{
		TutorialUI.DrawImage(8);
	}

	public static void DrawTutorialElementImage()
	{
		TutorialUI.DrawImage(9);
	}

	public static void DrawTutorialAbstImage()
	{
		TutorialUI.DrawImage(10);
	}

	public static void DrawTutorialMoveHoldImageVirtualPad()
	{
		TutorialUI.DrawImage(11);
	}

	public static void DrawTutorialAttackImageVirtualPad()
	{
		TutorialUI.DrawImage(12);
	}

	public static void DrawTutorialLockonImageVirtualPad()
	{
		TutorialUI.DrawImage(13);
	}

	public static void DrawTutorialTalkImage()
	{
		TutorialUI.DrawImage(0);
	}

	public static void DrawTutorialSoulVoicesImage()
	{
		TutorialUI.DrawImage(1);
	}

	public static void DrawTutorialPoppetImage()
	{
		TutorialUI.DrawImage(0);
	}

	public static void DrawTutorialMagicGaugeImage()
	{
		TutorialUI.DrawImage(1);
	}

	public static void DrawTutorialChainSkillImage()
	{
		TutorialUI.DrawImage(2);
	}

	public static void DrawTutorialEventTalkImage()
	{
		TutorialUI.DrawImage(2);
	}

	public static void DrawTutorialFriendpointGatya()
	{
		TutorialUI.DrawImage(0);
	}

	public static void DrawTutorialFaystoneGatya()
	{
		TutorialUI.DrawImage(1);
	}

	public static void SetMagicGaugeFaceIcon(int index, RespPoppet ppt)
	{
		if (!(CurrentInstance == null))
		{
			MagicGauge[] hUDMagicGauges = CurrentInstance.HUDMagicGauges;
			if (!(hUDMagicGauges == null) && index >= 0 && index < hUDMagicGauges.Length)
			{
				hUDMagicGauges[RuntimeServices.NormalizeArrayIndex(hUDMagicGauges, index)].setFaceIcon(ppt);
			}
		}
	}

	public static void SetMagicGaugeName(int index, string mapetName)
	{
		if (!(CurrentInstance == null))
		{
			MagicGauge[] hUDMagicGauges = CurrentInstance.HUDMagicGauges;
			if (!(hUDMagicGauges == null) && index >= 0 && index < hUDMagicGauges.Length)
			{
				hUDMagicGauges[RuntimeServices.NormalizeArrayIndex(hUDMagicGauges, index)].setName(mapetName);
			}
		}
	}

	public static void HideTemporary()
	{
		if (CurrentInstance == null)
		{
			return;
		}
		Camera[] hUDCameras = CurrentInstance.HUDCameras;
		if (!(hUDCameras == null))
		{
			int i = 0;
			Camera[] array = hUDCameras;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].enabled = false;
			}
		}
	}

	public static void RestoreTemporaryHide()
	{
		if (CurrentInstance == null)
		{
			return;
		}
		Camera[] hUDCameras = CurrentInstance.HUDCameras;
		if (!(hUDCameras == null))
		{
			int i = 0;
			Camera[] array = hUDCameras;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].enabled = true;
			}
		}
	}
}
