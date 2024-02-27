using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class WorldMain : MonoBehaviour
{
	[Serializable]
	public enum MapMode
	{
		None = -1,
		InitNewArea,
		CheckNewArea,
		MoveNewArea,
		IconNewArea,
		ConfInitNewArea,
		ConfNewArea,
		MapIdle
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024delayedSE_002422184 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00242682_002422185;

			internal float _0024_0024wait_until_0024temp_00242683_002422186;

			internal string _0024sename_002422187;

			internal float _0024delaySec_002422188;

			public _0024(string sename, float delaySec)
			{
				_0024sename_002422187 = sename;
				_0024delaySec_002422188 = delaySec;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_until_0024temp_00242682_002422185 = _0024delaySec_002422188;
					_0024_0024wait_until_0024temp_00242683_002422186 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (0 == 0 && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00242683_002422186 < _0024_0024wait_until_0024temp_00242682_002422185)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					GameSoundManager.PlaySe(_0024sename_002422187, 0);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sename_002422189;

		internal float _0024delaySec_002422190;

		public _0024delayedSE_002422184(string sename, float delaySec)
		{
			_0024sename_002422189 = sename;
			_0024delaySec_002422190 = delaySec;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024sename_002422189, _0024delaySec_002422190);
		}
	}

	[NonSerialized]
	protected static WorldMain _instance;

	public int count;

	public UIDynamicFontLabel debugLabel;

	public UIDynamicFontLabel infoLabel;

	public Texture textrue;

	public QuestManager questManager;

	public UIDraggablePanel mapDragPanel;

	public Vector2 mapOffset;

	public GameObject scrollUp;

	public GameObject scrollDown;

	public GameObject scrollLeft;

	public GameObject scrollRight;

	public Stack newAreaIcons;

	protected UIPanel panel;

	protected float mapX;

	protected float mapY;

	protected QuestAreaButton curNewAreaButton;

	protected MapMode mapMode;

	private float iconWait;

	private readonly float POP_NEWAREA_WAIT_TIME;

	private readonly float POP_SE_WAIT_TIME;

	private string popAreaSE;

	public bool debug;

	[NonSerialized]
	public static Vector2 lastMapOffset;

	public WorldMain()
	{
		newAreaIcons = new Stack();
		POP_NEWAREA_WAIT_TIME = 2f;
		POP_SE_WAIT_TIME = 0.3f;
		popAreaSE = "se_system_add_area";
	}

	public void Start()
	{
		_instance = this;
		ModalCollider.SetActive(this, active: false);
		GameLevelManager instance = GameLevelManager.Instance;
		questManager = QuestManager.Instance;
		if ((bool)questManager)
		{
			questManager.Setup();
		}
		if (SceneChanger.LastSceneName.StartsWith("Ui_World"))
		{
			mapOffset.x = lastMapOffset.x;
			mapOffset.y = lastMapOffset.y;
		}
		if ((bool)mapDragPanel)
		{
			panel = mapDragPanel.panel;
			if ((bool)panel)
			{
				float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(gameObject);
				Vector4 clipRange = panel.clipRange;
				clipRange.z = (float)Screen.width * pixelSizeAdjustment;
				clipRange.w = (float)Screen.height * pixelSizeAdjustment;
				panel.clipRange = clipRange;
			}
		}
		mapMode = MapMode.None;
		mapX = mapOffset.x;
		mapY = mapOffset.y;
		Scroll(mapX, mapY);
		count = 0;
		if ((bool)debugLabel)
		{
			debugLabel.m_Text = SceneIDModule.SceneIDToName(SceneID.Ui_WorldRaid);
		}
		SceneTitleHUD.UpdateTitle(MTexts.Msg("$W_WORLDMAP_TITLE"));
		InfomationBarHUD.UpdateText(MTexts.Msg("$W_WORLDMAP_INFO"));
		if (!debug)
		{
			MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				Initialize();
			});
		}
		else
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		mapMode = MapMode.InitNewArea;
	}

	public void OnDestroy()
	{
		ModalCollider.SetActive(_instance, active: false);
		_instance = null;
		QuestManager.Instance.detachWorldMapTexture();
	}

	public void Update()
	{
		checked
		{
			count++;
			if ((bool)infoLabel)
			{
				infoLabel.m_Text = textrue.width.ToString();
			}
			if (InventoryOverDialog.IsOpenInventoryOverDialog())
			{
				return;
			}
			NewAreaControl();
			if ((bool)mapDragPanel)
			{
				float x = mapDragPanel.transform.localPosition.x;
				float y = mapDragPanel.transform.localPosition.y;
				PosToMap(ref x, ref y);
				if ((bool)scrollUp)
				{
					scrollUp.SetActive(y < 0.95f);
				}
				if ((bool)scrollDown)
				{
					scrollDown.SetActive(y > 0.05f);
				}
				if ((bool)scrollLeft)
				{
					scrollLeft.SetActive(x < 0.95f);
				}
				if ((bool)scrollRight)
				{
					scrollRight.SetActive(x > 0.05f);
				}
			}
		}
	}

	public void MapToPos(ref float x, ref float y)
	{
		if (!panel || !mapDragPanel)
		{
			return;
		}
		Bounds bounds = mapDragPanel.bounds;
		if (bounds.min.x != bounds.max.x && bounds.min.y != bounds.max.x)
		{
			Vector4 clipRange = panel.clipRange;
			float num = clipRange.z * 0.5f;
			float num2 = clipRange.w * 0.5f;
			float num3 = bounds.min.x + num;
			float num4 = bounds.max.x - num;
			float num5 = bounds.min.y + num2;
			float num6 = bounds.max.y - num2;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num3 -= panel.clipSoftness.x;
				num4 += panel.clipSoftness.x;
				num5 -= panel.clipSoftness.y;
				num6 += panel.clipSoftness.y;
			}
			if (num4 - num3 != 0f)
			{
				x *= num4 - num3;
			}
			if (num5 - num6 != 0f)
			{
				y *= num5 - num6;
			}
			x += num3;
			y += num6;
		}
	}

	public void PosToMap(ref float x, ref float y)
	{
		if (!panel || !mapDragPanel)
		{
			return;
		}
		Bounds bounds = mapDragPanel.bounds;
		if (bounds.min.x != bounds.max.x && bounds.min.y != bounds.max.x)
		{
			Vector4 clipRange = panel.clipRange;
			float num = clipRange.z * 0.5f;
			float num2 = clipRange.w * 0.5f;
			float num3 = bounds.min.x + num;
			float num4 = bounds.max.x - num;
			float num5 = bounds.min.y + num2;
			float num6 = bounds.max.y - num2;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num3 -= panel.clipSoftness.x;
				num4 += panel.clipSoftness.x;
				num5 -= panel.clipSoftness.y;
				num6 += panel.clipSoftness.y;
			}
			if (!(x >= num3))
			{
				x = num3;
			}
			if (!(x <= num4))
			{
				x = num4;
			}
			if (!(y <= num6))
			{
				y = num6;
			}
			if (!(y >= num5))
			{
				y = num5;
			}
			x -= num3;
			y -= num6;
			if (num4 - num3 != 0f)
			{
				x /= num4 - num3;
			}
			if (num5 - num6 != 0f)
			{
				y /= num5 - num6;
			}
		}
	}

	public void Scroll(float x, float y)
	{
		PosToMap(ref x, ref y);
		mapDragPanel.SetDragAmount(x, y, updateScrollbars: false);
	}

	public void NewAreaControl()
	{
		if (mapMode == MapMode.InitNewArea)
		{
			ModalCollider.SetActive(this, active: false);
			questManager = QuestManager.Instance;
			QuestAreaButton[] areaIcons = questManager.AreaIcons;
			if (areaIcons == null)
			{
				return;
			}
			mapMode = MapMode.CheckNewArea;
			ModalCollider.SetActive(this, active: false);
			newAreaIcons.Clear();
			if (!debug)
			{
				if (areaIcons == null)
				{
					return;
				}
				IEnumerator enumerator = areaIcons.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is QuestAreaButton))
					{
						obj = RuntimeServices.Coerce(obj, typeof(QuestAreaButton));
					}
					QuestAreaButton questAreaButton = (QuestAreaButton)obj;
					if ((bool)questAreaButton && questAreaButton.IsNew)
					{
						newAreaIcons.Push(questAreaButton);
					}
				}
			}
			else
			{
				if (areaIcons == null)
				{
					return;
				}
				IEnumerator enumerator2 = areaIcons.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					if (!(obj2 is QuestAreaButton))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(QuestAreaButton));
					}
					QuestAreaButton questAreaButton2 = (QuestAreaButton)obj2;
					if ((bool)questAreaButton2)
					{
						newAreaIcons.Push(questAreaButton2);
					}
				}
			}
		}
		else if (mapMode == MapMode.CheckNewArea)
		{
			if (newAreaIcons.Count > 0)
			{
				ModalCollider.SetActive(this, active: true);
				object obj3 = newAreaIcons.Pop();
				if (!(obj3 is QuestAreaButton))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(QuestAreaButton));
				}
				QuestAreaButton questAreaButton3 = (QuestAreaButton)obj3;
				if ((bool)questAreaButton3)
				{
					curNewAreaButton = questAreaButton3;
					mapMode = MapMode.MoveNewArea;
					iTween.ValueTo(gameObject, new Hash
					{
						{ "from", mapX },
						{
							"to",
							questAreaButton3.gameObject.transform.localPosition.x
						},
						{ "time", 1.5f },
						{
							"easetype",
							iTween.EaseType.easeInOutSine
						},
						{ "onupdate", "UpdateMapX" },
						{ "oncomplete", "UpdateMapXEnd" },
						{ "oncompleteparams", this }
					});
					iTween.ValueTo(gameObject, new Hash
					{
						{ "from", mapY },
						{
							"to",
							questAreaButton3.gameObject.transform.localPosition.y
						},
						{ "time", 1.5f },
						{
							"easetype",
							iTween.EaseType.easeInOutSine
						},
						{ "onupdate", "UpdateMapY" }
					});
					notifyTutorialStepOfNewAreaIfNeed(questAreaButton3.AreaId);
				}
			}
		}
		else if (mapMode == MapMode.MoveNewArea)
		{
			Scroll(mapX, mapY);
			iconWait = 0f;
		}
		else if (mapMode == MapMode.IconNewArea)
		{
			if (iconWait == 0f)
			{
				curNewAreaButton.ShowIcon = true;
				IEnumerator enumerator3 = delayedSE(popAreaSE, POP_SE_WAIT_TIME);
				if (enumerator3 != null)
				{
					StartCoroutine(enumerator3);
				}
			}
			iconWait += Time.deltaTime;
			if (!(iconWait <= POP_NEWAREA_WAIT_TIME))
			{
				mapMode = MapMode.ConfInitNewArea;
			}
		}
		else if (mapMode == MapMode.ConfInitNewArea)
		{
			UpdateEndCore();
		}
		else if (mapMode == MapMode.ConfNewArea)
		{
			DialogManager instance = DialogManager.Instance;
			if ((bool)instance && DialogManager.LastResult != -1)
			{
				mapMode = MapMode.CheckNewArea;
				ModalCollider.SetActive(this, active: false);
			}
		}
	}

	private void notifyTutorialStepOfNewAreaIfNeed(int areaId)
	{
		MAreas mAreas = MAreas.Get(areaId);
		if (mAreas != null && mAreas.Progname == "area_cave")
		{
			MerlinServer.NotifyTutorialStep(300);
		}
	}

	private IEnumerator delayedSE(string sename, float delaySec)
	{
		return new _0024delayedSE_002422184(sename, delaySec).GetEnumerator();
	}

	public void UpdateMapX(float value)
	{
		mapX = value;
	}

	public void UpdateMapY(float value)
	{
		mapY = value;
	}

	public void UpdateMapXEnd(WorldMain obj)
	{
		mapMode = MapMode.IconNewArea;
	}

	public void UpdateEndCore()
	{
		if (!curNewAreaButton)
		{
			mapMode = MapMode.MapIdle;
			return;
		}
		DialogManager instance = DialogManager.Instance;
		if (!instance)
		{
			mapMode = MapMode.MapIdle;
			return;
		}
		string areaName = curNewAreaButton.AreaName;
		DialogManager.InitLastResult = -1;
		instance.OpenDialog(MTexts.Format("$W_WORLDMAP_NEW_AREA", areaName), MTexts.Msg("$W_WORLDMAP_NEW_AREA_TITLE"), autoClose: true, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }, 1);
		mapMode = MapMode.ConfNewArea;
	}

	public static void PushAreaButton(GameObject areaIcon)
	{
		if ((bool)_instance && (bool)areaIcon)
		{
			lastMapOffset.x = areaIcon.transform.localPosition.x;
			lastMapOffset.y = areaIcon.transform.localPosition.y;
			ModalCollider.SetActive(_instance, active: true);
		}
	}

	public void PushTown()
	{
		SceneChanger.ChangeTo(SceneID.Town);
	}

	public void PushQuestForest()
	{
		SceneChanger.ChangeTo(SceneID.Ui_WorldQuest);
	}

	public void PushQuestMountain()
	{
	}

	public void PushQuestCoast()
	{
	}

	public void PushQuestCave()
	{
	}

	public void PushQuestDesert()
	{
	}

	public void PushQuestTemple()
	{
	}

	public void PushRaid()
	{
	}

	public void PushQuestSnowfield()
	{
	}

	public void PushQuestHeaven()
	{
	}

	public void PushQuestSanctuary()
	{
	}

	public void PushQuestVolcano()
	{
	}

	public void PushBack()
	{
		SceneChanger.ChangeTo(SceneID.Town);
	}

	internal void _0024Start_0024closure_00243785()
	{
		Initialize();
	}
}
