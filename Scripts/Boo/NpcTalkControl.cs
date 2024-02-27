using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class NpcTalkControl : TutorialBase
{
	[Serializable]
	public enum CHECK_TALK_MODE
	{
		None,
		Init,
		Check,
		End
	}

	[Serializable]
	internal class _0024RestartWorld_0024locals_002414398
	{
		internal float _0024delay;
	}

	[Serializable]
	internal class _0024RestartWorld_0024closure_00243772
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002418282 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal float _0024_0024wait_sec_0024temp_00241628_002418283;

				internal _0024RestartWorld_0024closure_00243772 _0024self__002418284;

				public _0024(_0024RestartWorld_0024closure_00243772 self_)
				{
					_0024self__002418284 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024_0024wait_sec_0024temp_00241628_002418283 = _0024self__002418284._0024_0024locals_002414922._0024delay;
						goto case 2;
					case 2:
						if (_0024_0024wait_sec_0024temp_00241628_002418283 > 0f)
						{
							_0024_0024wait_sec_0024temp_00241628_002418283 -= Time.deltaTime;
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (stopFlag && !_0024self__002418284._0024this_002414923.changeScene)
						{
							TheWorld.RestartWorld();
						}
						stopFlag = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024RestartWorld_0024closure_00243772 _0024self__002418285;

			public _0024Invoke_002418282(_0024RestartWorld_0024closure_00243772 self_)
			{
				_0024self__002418285 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002418285);
			}
		}

		internal _0024RestartWorld_0024locals_002414398 _0024_0024locals_002414922;

		internal NpcTalkControl _0024this_002414923;

		public _0024RestartWorld_0024closure_00243772(_0024RestartWorld_0024locals_002414398 _0024_0024locals_002414922, NpcTalkControl _0024this_002414923)
		{
			this._0024_0024locals_002414922 = _0024_0024locals_002414922;
			this._0024this_002414923 = _0024this_002414923;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002418282(this).GetEnumerator();
		}
	}

	public int cutSceneId;

	[NonSerialized]
	public static bool isBusy;

	[NonSerialized]
	public static bool stopFlag;

	[NonSerialized]
	public static CHECK_TALK_MODE checkTalkMode;

	[NonSerialized]
	public static Vector3 checkTalkPos;

	[NonSerialized]
	public static float checkTalkR = 3f;

	[NonSerialized]
	public static float lastCheckTalkR = 3f;

	[NonSerialized]
	public static NpcTalkControl checkTalkNpc;

	[NonSerialized]
	public static NpcTalkControl requestTalkNpc;

	[NonSerialized]
	protected static int drawGizumoCount;

	[NonSerialized]
	protected static bool showPadTalkArea;

	protected MNpcs npc;

	protected NPCControl npcCtrl;

	protected MNpcTalks npcTalk;

	protected MNpcTalks lastTalk;

	protected MNpcTalks[] talkGroup;

	protected MNpcTalks[] talkRace;

	protected int curTalkId;

	protected int curRaceTalkId1;

	protected int curRaceTalkId2;

	protected string curTalkGroupId;

	[NonSerialized]
	protected static int lastNpcId = -1;

	[NonSerialized]
	protected static MNpcTalks curTalk;

	[NonSerialized]
	protected static EventWindow.Window eventWindow;

	[NonSerialized]
	protected static CutSceneManager cutSceneMan;

	public int curTalkCount;

	protected bool inCollider;

	protected bool lastInCollider;

	protected int playerConditionNumber;

	protected int playerRace;

	[NonSerialized]
	public static int languageType;

	[NonSerialized]
	public static int genderType;

	protected bool init;

	protected bool setup;

	protected bool nearFlag;

	protected GameLevelManager gamelevelMan;

	[NonSerialized]
	protected static FaderCore fader;

	protected int windowType;

	public string talkConditions;

	public GimmickIconTypes talkDistIcon;

	public GimmickIconTypes talkIcon;

	public BoxCollider talkBoxCollider;

	public float talkRange;

	public string talkMessage;

	public string talkCutsene;

	public string talkNextScene;

	public string talkResult;

	public int talkCount;

	protected GimmickIcon curIcon;

	[NonSerialized]
	protected static string subIconPrefabPath = "Prefab/GUI/IconObject/New";

	[NonSerialized]
	protected static GameObject subIconPrefab;

	protected GimmickIconTypes overwriteIcon;

	public GimmickIconTypes curTalkIcon;

	public float curTalkIconDist;

	public float nearIconDist;

	public float farIconDist;

	protected GimmickIconTypes lastTalkIcon;

	protected Vector3 lastRotation;

	protected bool lastNpcMoveFlag;

	protected bool isTouchTalk;

	protected int talkWait;

	protected bool isKeepChangeScene;

	[NonSerialized]
	protected static bool isApplicationQuit;

	public bool debguNoStopWorld;

	private StartButton startButton;

	protected bool changeScene;

	public GimmickIconTypes OverwriteIcon
	{
		get
		{
			return overwriteIcon;
		}
		set
		{
			if (overwriteIcon != value)
			{
				overwriteIcon = value;
				ResetTalkIcon();
			}
		}
	}

	private bool Paused => (bool)startButton && StartButton.Paused;

	public static bool IsBusy => isBusy;

	public static bool ShowPadTalkArea
	{
		get
		{
			return showPadTalkArea;
		}
		set
		{
			showPadTalkArea = value;
		}
	}

	public MNpcs MNpcs => npc;

	public NPCControl NPCControl => npcCtrl;

	public MNpcTalks MNpcTalks => npcTalk;

	public GimmickIcon CurIcon => curIcon;

	public bool IsKeepChangeScene
	{
		get
		{
			return isKeepChangeScene;
		}
		set
		{
			isKeepChangeScene = value;
		}
	}

	public NpcTalkControl()
	{
		windowType = 2;
		overwriteIcon = GimmickIconTypes.__NONE__;
		nearIconDist = 4f;
		farIconDist = 40f;
		talkWait = 1;
	}

	public override void Start()
	{
		fader = FaderCore.Instance;
		if (!gamelevelMan)
		{
			gamelevelMan = GameLevelManager.Instance;
		}
		startButton = StartButton.Instance;
	}

	public void OnApplicationQuit()
	{
		isApplicationQuit = true;
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
		if (!isApplicationQuit)
		{
			DisableTalkIcon();
		}
	}

	public override void OnDestroy()
	{
		if (RuntimeServices.EqualityOperator(curTalk, this))
		{
			TalkAbort();
		}
	}

	public override void Update()
	{
		if (!init)
		{
			gameObject.SetActive(value: false);
		}
		TalkCtrl();
	}

	public void TalkCtrl()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		if (curTalk == null)
		{
			if (playerConditionNumber != current.userMiscInfo.flagData.ConditionNumber)
			{
				npcTalk = GetCurrentTalks(update: true);
				playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
			}
			else if (playerRace != (int)current.userMiscInfo.playerRace)
			{
				npcTalk = GetCurrentTalks(update: false);
				playerRace = (int)current.userMiscInfo.playerRace;
			}
		}
		if (npcTalk == null || Paused)
		{
			return;
		}
		if (curTalk != null)
		{
			checkTalkMode = CHECK_TALK_MODE.None;
			talkWait = 1;
			if (eventWindow == null && cutSceneMan == null)
			{
				curTalk = null;
				if ((bool)fader && fader.isInCompleted)
				{
					fader.fadeOutEx(0f, 0f, 0f, 1f);
				}
				RestartWorld(0f);
			}
			return;
		}
		checked
		{
			if (talkWait > 0)
			{
				talkWait--;
				return;
			}
			bool flag = false;
			isTouchTalk = false;
			if ((bool)fader && !fader.isOutCompleted)
			{
				return;
			}
			SetTalkIcon(forceSetup: false);
			bool flag2 = false;
			bool flag3 = false;
			if (!(talkRange <= 0f) && CheckTalkRange())
			{
				if (npc.Id != lastNpcId)
				{
					flag = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (talkBoxCollider != null && inCollider)
			{
				if (npc.Id != lastNpcId)
				{
					flag = true;
					inCollider = false;
				}
			}
			else
			{
				flag3 = true;
			}
			if (talkBoxCollider == null && !(talkRange > 0f))
			{
				if ((bool)npcCtrl)
				{
					if (nearPlayer(gameObject, nearIconDist))
					{
						if (checkTalkMode == CHECK_TALK_MODE.None)
						{
							if (touch(npcCtrl))
							{
								flag = true;
							}
						}
						else if (checkTalkMode == CHECK_TALK_MODE.Check)
						{
							float num = Vector3.Distance(checkTalkPos, transform.position);
							if (!(num > checkTalkR) && !(num > lastCheckTalkR))
							{
								checkTalkNpc = this;
								lastCheckTalkR = num;
							}
						}
						else if (checkTalkMode == CHECK_TALK_MODE.End && requestTalkNpc == this)
						{
							flag = true;
							requestTalkNpc = null;
						}
						nearFlag = true;
						isTouchTalk = true;
					}
					else
					{
						if (nearFlag)
						{
							npcTalk = GetCurrentTalks(update: false);
						}
						nearFlag = false;
					}
				}
			}
			else if (talkIcon != GimmickIconTypes.TALK || talkDistIcon != GimmickIconTypes.TALK)
			{
				if (talkIcon == GimmickIconTypes.TALK)
				{
					talkIcon = talkDistIcon;
				}
				nearPlayer(gameObject, nearIconDist);
			}
			if (flag2 && flag3 && npc.Id == lastNpcId)
			{
				npcTalk = GetCurrentTalks(update: false);
				lastNpcId = -1;
				ResetTalkIcon();
			}
			if (flag)
			{
				StartTalk();
			}
		}
	}

	public void StartTalk()
	{
		checked
		{
			if (npcTalk != null && curTalk == null)
			{
				curTalk = npcTalk;
				DisableTalkIcon();
				lastNpcId = npc.Id;
				curTalkCount++;
				if (!Talk())
				{
					curTalk = null;
					npcTalk = GetCurrentTalks(update: false);
					lastNpcId = -1;
					ResetTalkIcon();
				}
			}
		}
	}

	public void Init(MNpcs npc)
	{
		this.npc = npc;
		if (!gamelevelMan)
		{
			gamelevelMan = GameLevelManager.Instance;
		}
		setup = false;
		CharacterController component = gameObject.GetComponent<CharacterController>();
		if (!component)
		{
			component = gameObject.AddComponent<CharacterController>();
			if ((bool)component)
			{
				component.enabled = false;
			}
		}
		npcCtrl = gameObject.GetComponent<NPCControl>();
		if (!npcCtrl)
		{
			npcCtrl = gameObject.AddComponent<NPCControl>();
			if ((bool)npcCtrl)
			{
				npcCtrl.isMove = false;
			}
		}
		UserData current = UserData.Current;
		playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
		playerRace = (int)current.userMiscInfo.playerRace;
		npcTalk = GetCurrentTalks(update: true);
		init = true;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (lastNpcId != 0 && curTalk == null && (bool)other && (bool)TutorialBase.Player && !(other.gameObject != TutorialBase.Player.gameObject) && (!fader || fader.isOutCompleted))
		{
			this?.StartCoroutine("InCollider");
		}
	}

	public IEnumerator InCollider()
	{
		inCollider = true;
		return null;
	}

	public bool CheckTalkRange()
	{
		int result;
		if (!((double)talkRange > 0.0))
		{
			result = 0;
		}
		else if ((bool)TutorialBase.Player)
		{
			float num = Vector3.Distance(TutorialBase.Player.gameObject.transform.position, transform.position);
			result = ((!(num > talkRange)) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void SetupTalk(MNpcTalks talk)
	{
		if (RuntimeServices.EqualityOperator(lastTalk, talk))
		{
			return;
		}
		lastTalk = talk;
		talkDistIcon = GimmickIconTypes.__NONE__;
		talkIcon = GimmickIconTypes.__NONE__;
		curTalkIcon = GimmickIconTypes.__NONE__;
		lastTalkIcon = GimmickIconTypes.__NONE__;
		talkMessage = string.Empty;
		string empty = string.Empty;
		talkConditions = string.Empty;
		talkResult = string.Empty;
		talkNextScene = string.Empty;
		talkCount = 0;
		talkRange = 0f;
		if ((bool)talkBoxCollider)
		{
			talkBoxCollider.enabled = false;
		}
		checked
		{
			if (talk != null)
			{
				setup = true;
				talkMessage = GetNpcText(talk.MNpcTextId);
				empty = talk.CutScene;
				int i = 0;
				MFlags[] allConditions = talk.AllConditions;
				for (int length = allConditions.Length; i < length; i++)
				{
					talkConditions += " " + allConditions[i].Progname + ",";
				}
				int j = 0;
				MFlags[] allNotConditions = talk.AllNotConditions;
				for (int length2 = allNotConditions.Length; j < length2; j++)
				{
					talkConditions += " -" + allNotConditions[j].Progname + ",";
				}
				int k = 0;
				MFlags[] allResults = talk.AllResults;
				for (int length3 = allResults.Length; k < length3; k++)
				{
					talkResult += " " + allResults[k].Progname + ",";
				}
				int l = 0;
				MFlags[] allNotResults = talk.AllNotResults;
				for (int length4 = allNotResults.Length; l < length4; l++)
				{
					talkResult += " -" + allNotResults[l].Progname + ",";
				}
				talkNextScene = talk.NextScene;
				talkCount = talk.TalkCount;
				if (!(talk.Distance <= 0f))
				{
					nearIconDist = talk.Distance;
				}
				farIconDist = nearIconDist * 10f;
				if (talk.Icon != 0)
				{
					try
					{
						talkIcon = (GimmickIconTypes)Enum.Parse(typeof(GimmickIconTypes), talk.IconMaster.Icon);
					}
					catch (Exception)
					{
						talkIcon = GimmickIconTypes.__NONE__;
					}
				}
				if (talk.DistantIcon != 0)
				{
					try
					{
						talkDistIcon = (GimmickIconTypes)Enum.Parse(typeof(GimmickIconTypes), talk.DistantIconMaster.Icon);
					}
					catch (Exception)
					{
						talkDistIcon = GimmickIconTypes.__NONE__;
					}
				}
				if (!(talk.Range <= 0f))
				{
					talkRange = talk.Range;
				}
				if (!string.IsNullOrEmpty(talk.Collision))
				{
					talkBoxCollider = ExtensionsModule.SetComponent<BoxCollider>(gameObject);
					if ((bool)talkBoxCollider)
					{
						talkBoxCollider.enabled = true;
						string[] array = talk.Collision.Split(',');
						try
						{
							talkBoxCollider.isTrigger = true;
							float x = float.Parse(array[0].Trim());
							Vector3 size = talkBoxCollider.size;
							float num = (size.x = x);
							Vector3 vector2 = (talkBoxCollider.size = size);
							float y = float.Parse(array[1].Trim());
							Vector3 size2 = talkBoxCollider.size;
							float num2 = (size2.y = y);
							Vector3 vector4 = (talkBoxCollider.size = size2);
							float z = float.Parse(array[2].Trim());
							Vector3 size3 = talkBoxCollider.size;
							float num3 = (size3.z = z);
							Vector3 vector6 = (talkBoxCollider.size = size3);
						}
						catch (Exception)
						{
							talkBoxCollider.enabled = false;
						}
					}
				}
			}
			ResetTalkIcon();
		}
	}

	public void EanbleTalkIcon(float dist)
	{
		if (!npcCtrl)
		{
			return;
		}
		DisableTalkIcon();
		if ((bool)npcCtrl)
		{
			npcCtrl.iconType = curTalkIcon;
		}
		if (curTalkIcon != GimmickIconTypes.__NONE__)
		{
			if (overwriteIcon != GimmickIconTypes.__NONE__)
			{
				npcCtrl.iconType = overwriteIcon;
			}
			curIcon = enableTownPeopleTouchMarker(npcCtrl, new Vector3(0f, npc.IconHeight, 0f));
			DispIconPlayerDistance = dist;
			if ((bool)curIcon && curTalkIcon != talkDistIcon && talkDistIcon == GimmickIconTypes.CAUTION)
			{
				SetSubIcon();
			}
		}
	}

	public void SetSubIcon()
	{
		if (!curIcon)
		{
			return;
		}
		if (!subIconPrefab)
		{
			subIconPrefab = (GameObject)GameAssetModule.LoadPrefab(subIconPrefabPath);
		}
		if ((bool)subIconPrefab)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(subIconPrefab);
			if ((bool)gameObject)
			{
				Vector3 localPosition = gameObject.transform.localPosition;
				Vector3 localScale = gameObject.transform.localScale;
				gameObject.transform.parent = curIcon.transform;
				gameObject.transform.localPosition = localPosition;
				gameObject.transform.localScale = localScale;
			}
		}
	}

	public void DisableTalkIcon()
	{
		if ((bool)npcCtrl)
		{
			disableTouchMarker(npcCtrl);
		}
		curIcon = null;
	}

	public void ResetTalkIcon()
	{
		SetTalkIcon(forceSetup: true);
	}

	public void SetTalkIcon(bool forceSetup)
	{
		if (talkDistIcon != GimmickIconTypes.__NONE__)
		{
			curTalkIcon = talkDistIcon;
			curTalkIconDist = farIconDist;
			if (talkIcon != GimmickIconTypes.__NONE__ && nearPlayer(gameObject, nearIconDist))
			{
				curTalkIcon = talkIcon;
				curTalkIconDist = nearIconDist;
			}
		}
		else if (talkIcon != GimmickIconTypes.__NONE__)
		{
			curTalkIcon = talkIcon;
			curTalkIconDist = nearIconDist;
		}
		else
		{
			curTalkIcon = GimmickIconTypes.__NONE__;
			curTalkIconDist = nearIconDist;
		}
		if (lastTalkIcon != curTalkIcon || forceSetup)
		{
			EanbleTalkIcon(curTalkIconDist);
			lastTalkIcon = curTalkIcon;
		}
	}

	public string GetNpcText(MNpcTexts npcText)
	{
		object result;
		if (npcText == null)
		{
			result = string.Empty;
		}
		else
		{
			string empty = string.Empty;
			result = ((languageType == 0) ? ((genderType != 0) ? npcText.Ja_F : npcText.Ja_M) : ((genderType != 0) ? npcText.En_F : npcText.En_M));
		}
		return (string)result;
	}

	public IEnumerator TalkTurn()
	{
		if ((bool)npcCtrl)
		{
			npcCtrl.UpdateLastRotY();
			lookAt(npcCtrl, PlayerPos, 0.5f);
		}
		return null;
	}

	public IEnumerator PlayerTalkTurn()
	{
		if ((bool)npcCtrl)
		{
			lookAt(TutorialBase.Player, npcCtrl.transform.position, 0.5f);
		}
		return null;
	}

	public bool Talk()
	{
		int result;
		if (eventWindow != null || cutSceneMan != null)
		{
			result = 0;
		}
		else if (!SceneChanger.isCompletelyReady)
		{
			result = 0;
		}
		else
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				result = 0;
			}
			else if (npc == null)
			{
				result = 0;
			}
			else
			{
				MNpcTalks mNpcTalks = npcTalk;
				if (mNpcTalks == null)
				{
					result = 0;
				}
				else if (mNpcTalks.TalkType == EnumNpcTalkTypes.ANGEL_TALK && current.userMiscInfo.playerRace != 0)
				{
					result = 0;
				}
				else if (mNpcTalks.TalkType == EnumNpcTalkTypes.DEVIL_TALK && current.userMiscInfo.playerRace != RACE_TYPE.Akuma)
				{
					result = 0;
				}
				else
				{
					if (mNpcTalks.TurnAround)
					{
						StartCoroutine("TalkTurn");
					}
					if (isTouchTalk)
					{
						lastRotation = gameObject.transform.eulerAngles;
						StartCoroutine("PlayerTalkTurn");
					}
					GameObject[] array = null;
					if (mNpcTalks.BustShot)
					{
						array = new GameObject[2]
						{
							TutorialBase.Player.gameObject,
							gameObject
						};
					}
					bool flag = false;
					bool flag2 = false;
					bool isResumeBgm = true;
					if (mNpcTalks.NoResumeLastBgm)
					{
						isResumeBgm = false;
					}
					if (mNpcTalks.ResultBgm.Id > -1)
					{
						isResumeBgm = false;
					}
					try
					{
						isBusy = true;
						lastNpcMoveFlag = npcCtrl.StopMove;
						if (string.IsNullOrEmpty(mNpcTalks.CutScene))
						{
							string[] array2 = new string[1];
							string text = null;
							string npcText = GetNpcText(mNpcTalks.MNpcTextId);
							if (!string.IsNullOrEmpty(npcText))
							{
								text = ((languageType != 0) ? npc.DisplayName_En : npc.DisplayName);
								text = TextTagCheck.CheckPlayerName(text);
								array2[0] = text;
								npcText = TextTagCheck.CheckPlayerName(npcText);
								string[] multiLineArray = TextTagCheck.GetMultiLineArray(npcText);
								EventWindow.CloseEventWindow(windowType);
								if (mNpcTalks.WindowType != 0)
								{
									windowType = (int)(mNpcTalks.WindowType - 1);
								}
								else
								{
									windowType = 2;
								}
								eventWindow = EventWindow.OpenEventWindow(multiLineArray, array2, new GameObject[1][] { array }, windowType);
								if (eventWindow != null)
								{
									eventWindow.HideLastPageNextButton = false;
									eventWindow.TextFinishAutoClose = true;
									eventWindow.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
									{
										TalkEnd();
									};
								}
								else
								{
									flag = true;
								}
							}
							else
							{
								flag2 = true;
							}
							if (!debguNoStopWorld)
							{
								StopWorld();
							}
						}
						else
						{
							CutSceneManager.Instance.autoStartFlag = true;
							CutSceneManager cutSceneManager = CutSceneManager.CutSceneEx(mNpcTalks.CutScene, gameObject, mNpcTalks.CutScene, autoStart: true);
							if (!cutSceneManager)
							{
								cutSceneManager = CutSceneManager.CutScene(mNpcTalks.CutScene, gameObject);
							}
							if (!cutSceneManager)
							{
								cutSceneManager = CutSceneManager.CutScene("CutScene/" + mNpcTalks.CutScene, gameObject);
							}
							if ((bool)cutSceneManager)
							{
								if ((bool)npcCtrl)
								{
									npcCtrl.idle();
								}
								cutSceneMan = cutSceneManager;
								cutSceneManager.IsResumeBgm = isResumeBgm;
								cutSceneManager.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
								{
									TalkEnd();
								};
							}
							else
							{
								flag = true;
							}
							if (!debguNoStopWorld)
							{
								StopWorldForCutScene();
							}
						}
					}
					catch (Exception)
					{
						flag = true;
					}
					bool flag3 = true;
					if (flag)
					{
						TalkAbort();
						flag3 = false;
					}
					else if (flag2)
					{
						TalkEnd();
						flag3 = false;
					}
					else
					{
						if (mNpcTalks.StartBgm.Id > -1)
						{
							GameSoundManager.PlayBgmDirect(mNpcTalks.StartBgm.File);
						}
						if (!string.IsNullOrEmpty(mNpcTalks.StartSe))
						{
							GameSoundManager.PlaySe(mNpcTalks.StartSe, mNpcTalks.StartSeDelayMsec);
						}
						if (mNpcTalks.StartRace != null)
						{
							RACE_TYPE raceType = MPlayerRaces.GetRaceType(mNpcTalks.StartRace);
							if (raceType != RACE_TYPE.Max)
							{
								StartCoroutine(TutorialBase.Player.ChangeTensiAkuma(raceType));
							}
						}
					}
					result = (flag3 ? 1 : 0);
				}
			}
		}
		return (byte)result != 0;
	}

	public static void TalkReset()
	{
		isBusy = false;
		eventWindow = null;
		cutSceneMan = null;
		curTalk = null;
	}

	public void TalkAbort()
	{
		isBusy = false;
		eventWindow = null;
		cutSceneMan = null;
		curTalk = null;
		if ((bool)fader)
		{
			fader.fadeOutEx(0f, 0f, 0f, 1f);
		}
		RestartWorld(0f);
		npcCtrl.StopMove = lastNpcMoveFlag;
	}

	public void TalkEnd()
	{
		MNpcTalks mNpcTalks = null;
		mNpcTalks = npcTalk;
		changeScene = false;
		bool flag = false;
		if (mNpcTalks != null)
		{
			if (mNpcTalks.TurnAround)
			{
				iTween.RotateTo(this.gameObject, lastRotation, 0.5f);
			}
			QuestClearConditionChecker.Instance.satisfyTalk(mNpcTalks.Id);
			if (!string.IsNullOrEmpty(mNpcTalks.ResultPlayerPosition) && (bool)TutorialBase.Player)
			{
				GameLevelManager.SetNpcPos(TutorialBase.Player.gameObject.transform, mNpcTalks.ResultPlayerPosition);
			}
			if (!string.IsNullOrEmpty(mNpcTalks.ResultNpcPosition))
			{
				GameLevelManager.SetNpcPos(this.gameObject.transform, mNpcTalks.ResultNpcPosition);
			}
			if (mNpcTalks.ResultBgm.Id > -1)
			{
				GameSoundManager.PlayBgmDirect(mNpcTalks.ResultBgm.File);
			}
			if (!string.IsNullOrEmpty(mNpcTalks.ResultSe))
			{
				GameSoundManager.PlaySe(mNpcTalks.ResultSe, mNpcTalks.ResultSeDelayMsec);
			}
			if (mNpcTalks.ResultRace != null)
			{
				RACE_TYPE raceType = MPlayerRaces.GetRaceType(mNpcTalks.ResultRace);
				if (raceType != RACE_TYPE.Max)
				{
					StartCoroutine(TutorialBase.Player.ChangeTensiAkuma(raceType));
				}
			}
			if (mNpcTalks.ResultPlayerAction != null)
			{
				SetupPlayerAction(TutorialBase.Player, mNpcTalks.ResultPlayerAction.Progname);
			}
			if (mNpcTalks.Warp != null)
			{
				QuestLinkRoutine.Instance.warp(mNpcTalks.Warp);
			}
			if (!string.IsNullOrEmpty(talkNextScene))
			{
				if (!string.IsNullOrEmpty(mNpcTalks.NextSceneKeepObjects))
				{
					string[] array = mNpcTalks.NextSceneKeepObjects.Split(',');
					int i = 0;
					string[] array2 = array;
					for (int length = array2.Length; i < length; i = checked(i + 1))
					{
						GameObject gameObject = GameObject.Find(array2[i].Trim()) as GameObject;
						if (!gameObject)
						{
							gameObject = GameObject.Find(array2[i]) as GameObject;
						}
						if (!gameObject)
						{
							gameObject = GameObject.Find(array2[i].Trim() + "(Clone)") as GameObject;
						}
						if (!gameObject)
						{
							gameObject = GameObject.Find(array2[i] + "(Clone)") as GameObject;
						}
						if ((bool)gameObject)
						{
							if (gameObject == this.gameObject)
							{
								isKeepChangeScene = true;
							}
							if (gameObject != this.gameObject)
							{
								gamelevelMan.KeepSceneObject = gameObject;
							}
							NonQuestDontDestroyObjects.Entry(gameObject);
						}
					}
				}
				gamelevelMan.SceneChangeWait = true;
				ChangerScene(talkNextScene);
				changeScene = true;
			}
			GameLevelManager.SetResultCondition(mNpcTalks.AllResults, notFlag: false);
			GameLevelManager.SetResultCondition(mNpcTalks.AllNotResults, notFlag: true);
			flag = true;
			if (mNpcTalks.FadeResult != null)
			{
				GameLevelManager.SetFlagWithFade(mNpcTalks.FadeResult);
				flag = false;
			}
		}
		npcTalk = GetCurrentTalks(update: false);
		isBusy = false;
		eventWindow = null;
		cutSceneMan = null;
		if (!changeScene)
		{
			if ((bool)fader && fader.isIn)
			{
				fader.fadeOutEx(0f, 0f, 0f, 1f);
			}
			RestartWorld(0f);
			npcCtrl.StopMove = lastNpcMoveFlag;
			ResetTalkIcon();
		}
		if (flag)
		{
			GameLevelManager.SendNpcTalkEndEvent();
		}
	}

	public void StopWorld()
	{
		TheWorld.StopWorldForTalk(this, npcCtrl);
		stopFlag = true;
	}

	public void StopWorldForCutScene()
	{
		TheWorld.StopWorldForCutscene(this);
		stopFlag = true;
	}

	public void RestartWorld(float delay)
	{
		_0024RestartWorld_0024locals_002414398 _0024RestartWorld_0024locals_0024 = new _0024RestartWorld_0024locals_002414398();
		_0024RestartWorld_0024locals_0024._0024delay = delay;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024RestartWorld_0024closure_00243772(_0024RestartWorld_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void RestartWorldForSceneChange()
	{
		if (stopFlag)
		{
			TheWorld.RestartWorld();
		}
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(RestartWorldForSceneChange);
		stopFlag = false;
	}

	public void ChangerScene(string scene)
	{
		changeScene = true;
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(RestartWorldForSceneChange);
		SceneChanger.Change(talkNextScene);
	}

	public static void SetupNpcAction(NPCControl npcCtrl, string actName, bool loop)
	{
		if (!npcCtrl || string.IsNullOrEmpty(actName))
		{
			return;
		}
		if (string.Compare(actName, "Last_Action") == 0)
		{
			actName = "Idle";
		}
		if (string.Compare(actName, "Idle") == 0)
		{
			if (loop)
			{
				npcCtrl.playLoop(npcCtrl.idleAnim);
			}
			else
			{
				npcCtrl.play(npcCtrl.idleAnim);
			}
		}
		else if (string.Compare(actName, "Run") == 0)
		{
			if (loop)
			{
				npcCtrl.playLoop(npcCtrl.runAnim);
			}
			else
			{
				npcCtrl.play(npcCtrl.runAnim);
			}
		}
		else if (string.Compare(actName, "Npc_Walk") == 0)
		{
			if (loop)
			{
				npcCtrl.playLoop(npcCtrl.walkAnim);
			}
			else
			{
				npcCtrl.play(npcCtrl.walkAnim);
			}
		}
		else if (string.Compare(actName, "Npc_Talk") == 0)
		{
			if (loop)
			{
				npcCtrl.playLoop(npcCtrl.talkAnim);
			}
			else
			{
				npcCtrl.play(npcCtrl.talkAnim);
			}
		}
		else
		{
			AnimationState animationState = npcCtrl.animation[actName];
			if ((bool)animationState)
			{
				npcCtrl.animation.Play(actName);
				animationState.speed = 1f;
				if (loop)
				{
					animationState.wrapMode = WrapMode.Loop;
				}
				else
				{
					animationState.wrapMode = WrapMode.Default;
				}
			}
		}
		if ((bool)npcCtrl)
		{
			npcCtrl.Pause = false;
		}
	}

	public static void SetupPlayerAction(MerlinActionControl actCtrl, string actName)
	{
		if (string.IsNullOrEmpty(actName))
		{
			return;
		}
		if (string.Compare(actName, "Last_Action") == 0)
		{
			actName = "Idle";
		}
		if (string.Compare(actName, "Idle") == 0)
		{
			if ((bool)actCtrl)
			{
				actCtrl.playAnimation(PlayerAnimationTypes.Idle);
			}
			return;
		}
		if (string.Compare(actName, "Run") == 0)
		{
			if ((bool)actCtrl)
			{
				actCtrl.playAnimation(PlayerAnimationTypes.Run);
			}
			return;
		}
		AnimationState animationState = actCtrl.animation[actName];
		if ((bool)animationState)
		{
			actCtrl.animation.Play(actName);
			animationState.speed = 1f;
		}
		else
		{
			PlayerAnimationTypes motType = (PlayerAnimationTypes)Enum.Parse(typeof(PlayerAnimationTypes), actName);
			actCtrl.playAnimation(motType);
		}
	}

	public MNpcTalks GetCurrentTalks(bool update)
	{
		if (update)
		{
			int num = curTalkId;
			int num2 = curRaceTalkId1;
			int num3 = curRaceTalkId2;
			string text = curTalkGroupId;
			CheckTalks();
			if (text != curTalkGroupId)
			{
				curTalkCount = 0;
			}
			else if (num != curTalkId)
			{
				curTalkCount = 0;
			}
			else if (num2 != curRaceTalkId1 || num3 != curRaceTalkId2)
			{
				curTalkCount = 0;
			}
		}
		MNpcTalks mNpcTalks = null;
		checked
		{
			if (talkRace != null && talkRace.Length > 0)
			{
				UserData current = UserData.Current;
				mNpcTalks = ((current.userMiscInfo.playerRace != 0) ? talkRace[1] : talkRace[0]);
				if (mNpcTalks != null && 0 < mNpcTalks.TalkCount && mNpcTalks.TalkCount <= curTalkCount)
				{
					mNpcTalks = null;
				}
			}
			else if (talkGroup != null && talkGroup.Length > 0)
			{
				float num4 = default(float);
				int i = 0;
				MNpcTalks[] array = talkGroup;
				for (int length = array.Length; i < length; i++)
				{
					if (0 >= array[i].TalkCount || array[i].TalkCount > curTalkCount)
					{
						num4 += array[i].Rate;
					}
				}
				num4 = UnityEngine.Random.RandomRange(0f, num4);
				int j = 0;
				MNpcTalks[] array2 = talkGroup;
				for (int length2 = array2.Length; j < length2; j++)
				{
					num4 -= array2[j].Rate;
					if ((0 >= array2[j].TalkCount || array2[j].TalkCount > curTalkCount) && !((double)num4 > 0.0))
					{
						mNpcTalks = array2[j];
						break;
					}
				}
			}
			SetupTalk(mNpcTalks);
			return mNpcTalks;
		}
	}

	public void CheckTalks()
	{
		talkGroup = null;
		talkRace = null;
		curTalkId = -1;
		curRaceTalkId1 = -1;
		curRaceTalkId2 = -1;
		curTalkGroupId = string.Empty;
		UserData current = UserData.Current;
		if (current != null)
		{
			MNpcTalks[] array = CheckTalksCore(current.userMiscInfo.flagData, gamelevelMan.CurMScene, npc, ref curTalkGroupId, ref curTalkId, ref curRaceTalkId1, ref curRaceTalkId2);
			if (!string.IsNullOrEmpty(curTalkGroupId) || curTalkId != -1)
			{
				talkGroup = array;
			}
			else
			{
				talkRace = array;
			}
		}
	}

	public static MNpcTalks[] CheckTalksCore(UserMiscInfo.FlagData flragData, MScenes scene, MNpcs tmpNpc, ref string dstGroupId, ref int dstTalkId, ref int dstRaceTalkId1, ref int dstRaceTalkId2)
	{
		dstTalkId = -1;
		dstRaceTalkId1 = -1;
		dstRaceTalkId2 = -1;
		dstGroupId = string.Empty;
		MNpcTalks[] array = new MNpcTalks[0];
		MNpcTalks[] result;
		if (tmpNpc == null)
		{
			result = array;
		}
		else
		{
			MNpcTalks mNpcTalks = null;
			MNpcTalks mNpcTalks2 = null;
			MNpcTalks mNpcTalks3 = null;
			Hashtable hashtable = new Hashtable();
			string text = null;
			int i = 0;
			MNpcTalks[] allNpcTalks = tmpNpc.AllNpcTalks;
			for (int length = allNpcTalks.Length; i < length; i = checked(i + 1))
			{
				if (mNpcTalks2 != null && mNpcTalks3 != null)
				{
					break;
				}
				if (allNpcTalks[i] == null || !CheckTalkCore(flragData, scene, allNpcTalks[i]))
				{
					continue;
				}
				if (string.IsNullOrEmpty(allNpcTalks[i].TalkGroupId) || !(allNpcTalks[i].Rate > 0f))
				{
					if (allNpcTalks[i].TalkType == EnumNpcTalkTypes.ANGEL_TALK)
					{
						if (mNpcTalks2 == null)
						{
							mNpcTalks2 = allNpcTalks[i];
						}
						continue;
					}
					if (allNpcTalks[i].TalkType != EnumNpcTalkTypes.DEVIL_TALK)
					{
						if (mNpcTalks == null)
						{
							mNpcTalks = allNpcTalks[i];
						}
						break;
					}
					if (mNpcTalks3 == null)
					{
						mNpcTalks3 = allNpcTalks[i];
					}
				}
				else
				{
					if (string.IsNullOrEmpty(allNpcTalks[i].TalkGroupId) || allNpcTalks[i].Rate <= 0f)
					{
						continue;
					}
					MNpcTalks[] array2 = null;
					if (hashtable.ContainsKey(allNpcTalks[i].TalkGroupId))
					{
						object obj = hashtable[allNpcTalks[i].TalkGroupId];
						if (!(obj is MNpcTalks[]))
						{
							obj = RuntimeServices.Coerce(obj, typeof(MNpcTalks[]));
						}
						array2 = (MNpcTalks[])obj;
					}
					array2 = ((array2 == null) ? new MNpcTalks[1] { allNpcTalks[i] } : ((MNpcTalks[])RuntimeServices.AddArrays(typeof(MNpcTalks), array2, new MNpcTalks[1] { allNpcTalks[i] })));
					hashtable[allNpcTalks[i].TalkGroupId] = array2;
					text = allNpcTalks[i].TalkGroupId;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				object obj2 = hashtable[text];
				if (!(obj2 is MNpcTalks[]))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(MNpcTalks[]));
				}
				array = (MNpcTalks[])obj2;
				dstGroupId = text;
			}
			else if (mNpcTalks != null)
			{
				array = new MNpcTalks[1] { mNpcTalks };
				dstTalkId = mNpcTalks.Id;
			}
			else if (mNpcTalks2 != null && mNpcTalks3 != null)
			{
				array = new MNpcTalks[2] { mNpcTalks2, mNpcTalks3 };
				dstRaceTalkId1 = mNpcTalks2.Id;
				dstRaceTalkId2 = mNpcTalks3.Id;
			}
			else if (mNpcTalks2 != null)
			{
				array = new MNpcTalks[2] { mNpcTalks2, null };
				dstRaceTalkId1 = mNpcTalks2.Id;
			}
			else if (mNpcTalks3 != null)
			{
				array = new MNpcTalks[2] { null, mNpcTalks3 };
				dstRaceTalkId2 = mNpcTalks3.Id;
			}
			result = array;
		}
		return result;
	}

	public bool CheckTalk(MNpcTalks checkTalk)
	{
		int result;
		if (gamelevelMan.CurMScene == null)
		{
			result = 0;
		}
		else
		{
			UserData current = UserData.Current;
			result = ((current != null && CheckTalkCore(current.userMiscInfo.flagData, gamelevelMan.CurMScene, checkTalk)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public static bool CheckTalkCore(UserMiscInfo.FlagData flragData, MScenes scene, MNpcTalks checkTalk)
	{
		int result;
		if (flragData == null)
		{
			result = 0;
		}
		else if (scene == null)
		{
			result = 0;
		}
		else if (checkTalk == null)
		{
			result = 0;
		}
		else
		{
			if (!string.IsNullOrEmpty(checkTalk.MSceneId))
			{
				string[] array = checkTalk.MSceneId.Split(',');
				bool flag = false;
				int i = 0;
				string[] array2 = array;
				for (int length = array2.Length; i < length; i = checked(i + 1))
				{
					if (scene.Progname == array2[i].Trim())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					result = 0;
					goto IL_00c9;
				}
			}
			result = (GameLevelManager.CheckConditionCore(flragData, checkTalk.AllConditions, notFlag: false) ? (GameLevelManager.CheckConditionCore(flragData, checkTalk.AllNotConditions, notFlag: true) ? 1 : 0) : 0);
		}
		goto IL_00c9;
		IL_00c9:
		return (byte)result != 0;
	}

	public static NpcTalkControl CheckTalkWithPlayerDirection(bool check)
	{
		object result;
		if (!PlayerControl.NeedControllerInput)
		{
			checkTalkMode = CHECK_TALK_MODE.None;
			result = null;
		}
		else
		{
			drawGizumoCount = 0;
			if (curTalk != null)
			{
				checkTalkMode = CHECK_TALK_MODE.None;
				result = null;
			}
			else
			{
				if (check && checkTalkMode == CHECK_TALK_MODE.None)
				{
					checkTalkMode = CHECK_TALK_MODE.Init;
				}
				if (checkTalkMode == CHECK_TALK_MODE.Init)
				{
					checkTalkPos = TutorialBase.Player.gameObject.transform.position + TutorialBase.Player.gameObject.transform.forward * checkTalkR;
					lastCheckTalkR = checkTalkR;
					checkTalkNpc = null;
					requestTalkNpc = null;
					checkTalkMode = CHECK_TALK_MODE.Check;
				}
				else if (checkTalkMode == CHECK_TALK_MODE.Check)
				{
					requestTalkNpc = checkTalkNpc;
					checkTalkMode = CHECK_TALK_MODE.End;
				}
				else if (checkTalkMode == CHECK_TALK_MODE.End && !check)
				{
					checkTalkMode = CHECK_TALK_MODE.None;
				}
				result = requestTalkNpc;
			}
		}
		return (NpcTalkControl)result;
	}

	public void OnDrawGizmos()
	{
		checked
		{
			if (showPadTalkArea && PlayerControl.NeedControllerInput && drawGizumoCount == 0)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(checkTalkPos, checkTalkR);
				drawGizumoCount++;
			}
		}
	}

	internal void _0024Talk_0024closure_00243773()
	{
		TalkEnd();
	}

	internal void _0024Talk_0024closure_00243774()
	{
		TalkEnd();
	}
}
