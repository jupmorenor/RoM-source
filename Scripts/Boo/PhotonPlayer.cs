using System;
using System.Collections;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(MerlinMotionPackControl))]
public class PhotonPlayer : MonoBehaviour
{
	public string currentState;

	public string prevState;

	private Hashtable sendData;

	private PhotonClientMain clientMain;

	private Hashtable lastRecvData;

	private bool transformInterpol;

	private float transformInterpolWeight;

	private Vector3 lerpOrgtPos;

	private Quaternion lerpOrgRot;

	private Vector3 lerpTargetPos;

	private Quaternion lerpTargetRot;

	private float runTimer;

	private float runSendTimeStep;

	private float bufferUpdateTimeStep;

	private GameObject shoutObject;

	private AttachMapetSpeak shoutAms;

	[NonSerialized]
	protected const byte NP_POSX = 1;

	[NonSerialized]
	protected const byte NP_POSZ = 2;

	[NonSerialized]
	protected const byte NP_ROTY = 3;

	[NonSerialized]
	protected const byte NP_STATE = 4;

	[NonSerialized]
	protected const byte NP_STATESTR = 5;

	[NonSerialized]
	protected const byte NP_STYLE = 6;

	[NonSerialized]
	protected const byte PARA_STYLE_TENSI = 0;

	[NonSerialized]
	protected const byte PARA_STYLE_AKUMA = 1;

	private __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ hitAttackHandler;

	private __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ hitAttackWithDamageHandler;

	private __PhotonPlayer_SkillEventHandler_0024callable84_002454_34__ skillEventHandler;

	public string myName;

	public bool IsDead => PCon.IsDead;

	public bool IsReady => PCon.IsReady;

	public bool IsOwner
	{
		get
		{
			return PCon.InputActive;
		}
		set
		{
			PCon.InputActive = value;
			PCon.enableColiYarare(value);
			PCon.DisableAttackColli = !value;
		}
	}

	public bool HasSendData => sendData.Count > 0;

	public string CurrentAnimationStateName
	{
		get
		{
			MerlinMotionPackControl component = GetComponent<MerlinMotionPackControl>();
			object result;
			if (component == null)
			{
				result = string.Empty;
			}
			else
			{
				string currentAnimName = component.CurrentAnimName;
				result = ((!(currentAnimName != null)) ? string.Empty : currentAnimName);
			}
			return (string)result;
		}
	}

	public int CurrentAnimType
	{
		get
		{
			MerlinMotionPackControl component = GetComponent<MerlinMotionPackControl>();
			return (!(component == null)) ? component.CurrentAnimType : (-1);
		}
	}

	public PlayerControl PCon => GetComponent<PlayerControl>();

	public bool HasName => !string.IsNullOrEmpty(myName);

	public Hashtable SendData => sendData;

	public PhotonClientMain ClientMain
	{
		get
		{
			return clientMain;
		}
		set
		{
			clientMain = value;
		}
	}

	public __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ HitAttackHandler
	{
		get
		{
			return hitAttackHandler;
		}
		set
		{
			hitAttackHandler = value;
		}
	}

	public __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ HitAttackWithDamageHandler
	{
		get
		{
			return hitAttackWithDamageHandler;
		}
		set
		{
			hitAttackWithDamageHandler = value;
		}
	}

	public __PhotonPlayer_SkillEventHandler_0024callable84_002454_34__ SkillEventHandler
	{
		get
		{
			return skillEventHandler;
		}
		set
		{
			skillEventHandler = value;
		}
	}

	public PhotonPlayer()
	{
		sendData = new Hashtable();
		runSendTimeStep = 0.5f;
		bufferUpdateTimeStep = 0.1f;
		myName = string.Empty;
	}

	public void Awake()
	{
	}

	public void Start()
	{
		PCon.enableContinuePanel(b: false);
		shoutObject = GameObject.Find("Battle UI Root/Camera/0 Main/AnchorCenter/Fukidashi Panel/Fukidashi");
		if (shoutObject != null)
		{
			shoutAms = (AttachMapetSpeak)shoutObject.GetComponent(typeof(AttachMapetSpeak));
		}
	}

	private void setRunModeSendData(int state, string stateStr)
	{
		Vector3 position = transform.position;
		Vector3 forward = transform.forward;
		forward.y = 0f;
		Vector3 vector = forward.normalized * runSendTimeStep * PCon.CurrentMoveSpeed;
		position += vector;
		short[] array = clientMain.fixPositionOnBaseTransform(position);
		sendData[(byte)4] = state;
		sendData[(byte)1] = array[0];
		sendData[(byte)2] = array[2];
		short num = clientMain.fixRotationOnBaseTransformInRadian(forward);
		sendData[(byte)3] = num;
		sendData[(byte)6] = PCon.IsTensi;
	}

	private void setNormalSendData(int state, string stateStr)
	{
		sendData[(byte)4] = state;
		sendData[(byte)5] = stateStr;
		short[] array = clientMain.fixPositionOnBaseTransform(transform.position);
		Vector3 forward = transform.forward;
		forward.y = 0f;
		short num = clientMain.fixRotationOnBaseTransformInRadian(forward);
		sendData[(byte)1] = array[0];
		sendData[(byte)2] = array[2];
		sendData[(byte)3] = num;
		sendData[(byte)6] = PCon.IsTensi;
	}

	private bool isRunState(string name)
	{
		bool num = name == "run";
		if (!num)
		{
			num = name.EndsWith("_run");
		}
		return num;
	}

	private bool isIdleState(string name)
	{
		bool num = name == "idle";
		if (!num)
		{
			num = name.EndsWith("_idle");
		}
		return num;
	}

	public void clearSendData()
	{
		sendData = new Hashtable();
	}

	public void OnGUI()
	{
	}

	public void FixedUpdate()
	{
		float y = 0f;
		Vector3 position = transform.position;
		float num = (position.y = y);
		Vector3 vector2 = (transform.position = position);
	}

	public void Update()
	{
		if (clientMain == null || !IsReady)
		{
			return;
		}
		PlayerLabelControl.setLabel(PCon, myName);
		string currentAnimationStateName = CurrentAnimationStateName;
		int currentAnimType = CurrentAnimType;
		Quaternion rotation = default(Quaternion);
		if (IsOwner)
		{
			bool num = PCon.isRun();
			if (!num)
			{
				num = PCon.isRunAttack();
			}
			bool flag = num;
			bool flag2 = PCon.isIdle();
			if (currentAnimationStateName != currentState)
			{
				prevState = currentState;
				currentState = currentAnimationStateName;
				if (flag)
				{
					setRunModeSendData(currentAnimType, currentAnimationStateName);
				}
				else
				{
					setNormalSendData(currentAnimType, currentAnimationStateName);
				}
				runTimer = 0f;
			}
			else if (flag)
			{
				runTimer += Time.deltaTime;
				if (!(runTimer < bufferUpdateTimeStep))
				{
					runTimer = 0f;
					setRunModeSendData(currentAnimType, currentAnimationStateName);
				}
			}
			else if (flag2)
			{
				runTimer += Time.deltaTime;
				if (!(runTimer < bufferUpdateTimeStep))
				{
					runTimer = 0f;
					setNormalSendData(currentAnimType, currentAnimationStateName);
				}
			}
		}
		else if (lastRecvData != null)
		{
			Hashtable hashtable = lastRecvData;
			lastRecvData = null;
			if (hashtable.ContainsKey((byte)4))
			{
				object obj = hashtable[(byte)5];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (!string.IsNullOrEmpty(text) && text != currentAnimationStateName)
				{
					PCon.playAnimationByName(text);
				}
				else
				{
					int num2 = RuntimeServices.UnboxInt32(hashtable[(byte)4]);
					if (!PCon.Mmpc.isAnimType(num2) && (PCon.isIdle() || PCon.isRun()))
					{
						if (num2 == -1)
						{
							PCon.playAnimationByType(PlayerAnimationTypes.Idle);
						}
						else
						{
							PCon.playAnimationByType((PlayerAnimationTypes)num2);
						}
					}
				}
			}
			Vector3 vector = clientMain.positionOnWorldFromFix(RuntimeServices.UnboxInt16(hashtable[(byte)1]), 0, RuntimeServices.UnboxInt16(hashtable[(byte)2]));
			vector.y = 0f;
			float y = clientMain.rotationOnWorldInDegreeFromFix(RuntimeServices.UnboxInt16(hashtable[(byte)3]));
			lerpOrgtPos = transform.position;
			rotation = transform.rotation;
			lerpTargetPos = vector;
			lerpTargetRot = Quaternion.Euler(0f, y, 0f);
			transformInterpol = true;
			transformInterpolWeight = 0f;
			if (hashtable.ContainsKey((byte)4))
			{
				object obj2 = hashtable[(byte)6];
				bool isTensi = PCon.IsTensi;
				if (!RuntimeServices.EqualityOperator(obj2, isTensi))
				{
					if (RuntimeServices.ToBool(obj2))
					{
						IEnumerator enumerator = PCon.ChangeToTensi();
						if (enumerator != null)
						{
							StartCoroutine(enumerator);
						}
					}
					else
					{
						IEnumerator enumerator2 = PCon.ChangeToAkuma();
						if (enumerator2 != null)
						{
							StartCoroutine(enumerator2);
						}
					}
				}
			}
		}
		if (transformInterpol)
		{
			float num3 = Time.deltaTime / runSendTimeStep;
			transformInterpolWeight += num3;
			float num4 = transformInterpolWeight;
			if (!(num4 <= 1f))
			{
				transform.position = lerpTargetPos;
				transform.rotation = lerpTargetRot;
				transformInterpol = false;
				bool b = PCon.ActionInput.isEnable();
				PCon.ActionInput.enable(b: true);
				PCon.ActionInput.idle();
				PCon.ActionInput.enable(b);
			}
			else
			{
				transform.position = Vector3.Lerp(lerpOrgtPos, lerpTargetPos, num4);
				transform.rotation = Quaternion.Lerp(rotation, lerpTargetRot, num4);
			}
		}
	}

	public void setRecvData(Hashtable h)
	{
		lastRecvData = h;
	}

	public void execSkillCommand(int skillID, bool isTensi)
	{
		PCon.DoSkillMain(skillID);
	}

	public void raidAttackHit(GameObject enemy)
	{
		if (hitAttackHandler != null)
		{
			hitAttackHandler(enemy);
		}
	}

	public void raidAttackHitWithDamage(int damage)
	{
		if (hitAttackWithDamageHandler != null)
		{
			hitAttackWithDamageHandler(damage);
		}
	}

	public void raidSkill(int skillID)
	{
		if (skillEventHandler != null)
		{
			skillEventHandler(skillID, PCon.IsTensi);
		}
	}

	public void raidGetDamage(YarareTypes yarare)
	{
		clientMain.rpcRandomWord(EnumRaidWordTypes.Damage, aOwn: true, 0.25f);
	}

	public void kill()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public void shoutWord(string aMsg)
	{
		if (shoutAms != null)
		{
			AttachMapetSpeak.showMessage(gameObject, aMsg);
		}
	}
}
