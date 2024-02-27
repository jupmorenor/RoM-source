using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ChainSkillRoutine : MonoBehaviour
{
	[Serializable]
	public class Params
	{
		public PlayerControl player;

		public AIControl poppet;

		public RespPoppet poppetData;

		public MChainSkills chainSkill;

		public int poppetIndex;

		private bool _0024initialized__ChainSkillRoutine_Params_0024;

		public bool IsValid => (player != null) ? (!(player == null) && player.IsReady && !(poppet == null) && poppetData != null && chainSkill != null && chainSkill.SkillEffect != null && chainSkill.SkillEffect.MSkillEffectTypeId != null) : (!(poppet == null) && poppetIndex < 0 && poppetData != null && chainSkill != null && chainSkill.SkillEffect != null && chainSkill.SkillEffect.MSkillEffectTypeId != null);

		public bool WithPlayerMode => player != null;

		public int ActionType => chainSkill.SkillEffect.MSkillEffectTypeId.SkillActionType;

		public MSkillActionTypes ActionTypeMaster => MSkillActionTypes.Get(ActionType);

		public Vector3 MagicSkillOffsetPos
		{
			get
			{
				MagicSkill magicSkillComponent = poppet.MagicSkillComponent;
				return (!(magicSkillComponent != null)) ? new Vector3(2f, 0f, 0f) : magicSkillComponent.mapetPosOffset;
			}
		}

		public Params(PlayerControl _player, int _poppetIndex)
		{
			if (!_0024initialized__ChainSkillRoutine_Params_0024)
			{
				_0024initialized__ChainSkillRoutine_Params_0024 = true;
			}
			player = _player;
			poppetIndex = _poppetIndex;
			if (player != null)
			{
				poppet = player.getPoppet(poppetIndex);
			}
			if (poppet != null)
			{
				poppetData = poppet.PoppetData;
			}
			if (poppetData != null)
			{
				chainSkill = poppetData.ChainSkill;
			}
		}

		public Params(AIControl _poppet)
		{
			if (!_0024initialized__ChainSkillRoutine_Params_0024)
			{
				_0024initialized__ChainSkillRoutine_Params_0024 = true;
			}
			player = null;
			poppetIndex = -1;
			poppet = _poppet;
			if (poppet != null)
			{
				poppetData = poppet.PoppetData;
			}
			if (poppetData != null)
			{
				chainSkill = poppetData.ChainSkill;
			}
		}

		public void dump()
		{
			string empty = string.Empty;
			empty += "連携スキル情報:\n";
			empty += new StringBuilder("player: ").Append(player).Append(" IsReady:").Append(player.IsReady)
				.Append("\n")
				.ToString();
			empty += new StringBuilder("poppet: ").Append(poppet).Append("\n").ToString();
			empty += new StringBuilder("poppetData: ").Append(poppetData).Append("\n").ToString();
			empty += new StringBuilder("poppetIndex: ").Append((object)poppetIndex).Append("\n").ToString();
			if (poppet != null)
			{
				MagicSkill magicSkillComponent = poppet.MagicSkillComponent;
				if (magicSkillComponent != null)
				{
					empty += new StringBuilder("poppet MP: ").Append(magicSkillComponent.MagicPoint).Append("/").Append(magicSkillComponent.MaxMagicPoint)
						.Append("\n")
						.ToString();
				}
			}
		}
	}

	[Serializable]
	public class IPlayerActionControl
	{
		public override bool IsPrologueActionEnd => false;

		public override bool IsChainActionPlaying => true;

		public override bool IsChainActionEnd => false;

		public virtual void stop()
		{
		}

		public virtual void startPrologueAction()
		{
		}

		public virtual void updatePrologueAction()
		{
		}

		public virtual void startChainAction()
		{
		}

		public virtual void updateWhileChainAction()
		{
		}

		public virtual void restoreToBattle()
		{
		}
	}

	[Serializable]
	public class PlayerActionControl : IPlayerActionControl
	{
		private PlayerControl player;

		private EnumSkillActionTypes actType;

		private MChainSkills chainSkillMst;

		private MerlinMotionPackControl.Command spStartActCmd;

		private MerlinMotionPackControl.Command spMainActCmd;

		private PlayerAnimationTypes spMainAnimType;

		public override bool IsPrologueActionEnd
		{
			get
			{
				int num;
				if (player != null)
				{
					num = ((spStartActCmd != null) ? 1 : 0);
					if (num != 0)
					{
						num = (spStartActCmd.isExecuted ? 1 : 0);
					}
					if (num != 0)
					{
						num = (player.IS_END_OF_MOTION ? 1 : 0);
					}
				}
				else
				{
					num = 1;
				}
				return (byte)num != 0;
			}
		}

		public override bool IsChainActionPlaying
		{
			get
			{
				int num;
				if (player != null)
				{
					num = ((spMainActCmd != null) ? 1 : 0);
					if (num != 0)
					{
						num = (spMainActCmd.isExecuted ? 1 : 0);
					}
					if (num != 0)
					{
						num = ((player.NOW_ANIM == spMainAnimType) ? 1 : 0);
					}
				}
				else
				{
					num = 0;
				}
				return (byte)num != 0;
			}
		}

		public override bool IsChainActionEnd
		{
			get
			{
				int num;
				if (player != null)
				{
					num = ((spMainActCmd != null) ? 1 : 0);
					if (num != 0)
					{
						num = (spMainActCmd.isExecuted ? 1 : 0);
					}
					if (num != 0)
					{
						num = ((player.NOW_ANIM != spMainAnimType) ? 1 : 0);
					}
				}
				else
				{
					num = 1;
				}
				return (byte)num != 0;
			}
		}

		public PlayerActionControl(PlayerControl _player, EnumSkillActionTypes _actType, MChainSkills _chainSkillMst)
		{
			player = _player;
			actType = _actType;
			chainSkillMst = _chainSkillMst;
		}

		public override void stop()
		{
			if (!(player == null))
			{
				player.state = PlayerControl.STATE.Wait;
				player.disableGravity();
				player.DisableFaceMovement = true;
			}
		}

		public override void startPrologueAction()
		{
			if (!(player == null))
			{
				player.enableColiYarare(b: false);
				player.playSE(START_SOUND);
				spStartActCmd = player.PlayAnimation(PlayerAnimationTypes.SpStart);
				if (spStartActCmd == null)
				{
					throw new AssertionFailedException("spStartActCmd != null");
				}
			}
		}

		public override void updatePrologueAction()
		{
		}

		public override void startChainAction()
		{
			if (!(player == null))
			{
				spMainAnimType = PlayerAnimationTypes.SpAtk1;
				if (actType == EnumSkillActionTypes.Attack)
				{
					spMainAnimType = PlayerAnimationTypes.SpAtk1;
				}
				else if (actType == EnumSkillActionTypes.Heal)
				{
					spMainAnimType = PlayerAnimationTypes.SpAtk2;
				}
				player.DisableFaceMovement = false;
				spMainActCmd = player.playChainSkillAction(spMainAnimType, chainSkillMst);
				if (spMainActCmd == null)
				{
					throw new AssertionFailedException("spMainActCmd != null");
				}
			}
		}

		public override void updateWhileChainAction()
		{
			if (!(player == null))
			{
				Vector3 position = player.transform.position;
				player.transform.position = BattleUtil.AdjustYpos(position);
			}
		}

		public override void restoreToBattle()
		{
			if (!(player == null))
			{
				player.enableGravity();
				player.state = PlayerControl.STATE.Battle;
				player.resetInputControl();
				player.enableColiYarare(b: true);
				player.setBonusNoHit(3f);
			}
		}
	}

	[Serializable]
	public class DummyPlayerActionControl : IPlayerActionControl
	{
		private bool prologueStarted;

		private float prologueTimer;

		public override bool IsPrologueActionEnd
		{
			get
			{
				bool num = prologueStarted;
				if (num)
				{
					num = !(prologueTimer > 0f);
				}
				return num;
			}
		}

		public override bool IsChainActionEnd => true;

		public DummyPlayerActionControl(float _prologueWaitTime)
		{
			prologueStarted = false;
			prologueTimer = _prologueWaitTime;
		}

		public override void stop()
		{
		}

		public override void startPrologueAction()
		{
			prologueStarted = true;
		}

		public override void updatePrologueAction()
		{
			prologueTimer -= Time.deltaTime;
		}

		public override void startChainAction()
		{
		}

		public override void updateWhileChainAction()
		{
		}

		public override void restoreToBattle()
		{
		}
	}

	[Serializable]
	public class PoppetActionControl
	{
		private AIControl poppet;

		private MerlinMotionPackControl.Command motCmd;

		private PlayerAnimationTypes motType;

		private bool useQuestAction;

		public bool IsEndOfAction
		{
			get
			{
				int num;
				if (useQuestAction)
				{
					num = (motCmd.isExecuted ? 1 : 0);
					if (num != 0)
					{
						num = ((poppet.Mmpc.CurrentAnimType != (int)motType) ? 1 : 0);
					}
				}
				else
				{
					num = 1;
				}
				return (byte)num != 0;
			}
		}

		public PoppetActionControl(AIControl _poppet, bool _useQuestAction)
		{
			poppet = _poppet;
			useQuestAction = _useQuestAction;
		}

		public void stop()
		{
			if (!(poppet == null))
			{
				poppet.forceToIdle();
				poppet.AIMODE_Renkei();
				poppet.disableGravity();
				poppet.activateYarareColi(b: false);
				poppet.DisableFaceMovement = true;
				poppet.targetPlayerControl = null;
			}
		}

		public void start()
		{
			if (useQuestAction)
			{
				motType = PlayerAnimationTypes.SpSkill;
			}
			else
			{
				motType = PlayerAnimationTypes.Idle;
			}
			motCmd = poppet.playAnimationByType(motType);
			if (motCmd == null)
			{
				throw new AssertionFailedException("motCmd != null");
			}
			poppet.Mmpc.setLoopMode(loop: false);
		}

		public void restoreToBattle()
		{
			poppet.forceToIdle();
			poppet.enableGravity();
			poppet.AIMODE_Battle();
			poppet.activateYarareColi(b: true);
			poppet.DisableFaceMovement = false;
		}
	}

	[Serializable]
	private class ActorPositionControl
	{
		private Transform player;

		private Transform poppet;

		private Vector3 anoyoPos;

		private Vector3 anoyoPoppetOffset;

		private Vector3 playerPos;

		private Quaternion playerRot;

		private Vector3 poppetPos;

		private Quaternion poppetRot;

		public ActorPositionControl(Transform _player, Transform _poppet, Vector3 _anoyoPos, Vector3 _anoyoPoppetOffset)
		{
			if (_player != null)
			{
				player = _player;
			}
			poppet = _poppet;
			anoyoPos = _anoyoPos;
			anoyoPoppetOffset = _anoyoPoppetOffset;
			save();
		}

		public void save()
		{
			if (player != null)
			{
				player = player.transform;
				playerPos = player.position;
				playerRot = player.rotation;
			}
			if (poppet != null)
			{
				poppet = poppet.transform;
				poppetPos = poppet.position;
				poppetRot = poppet.rotation;
			}
		}

		public void gotoAnoyo()
		{
			if (player != null)
			{
				player.transform.position = anoyoPos;
				player.transform.rotation = Quaternion.identity;
			}
			if (poppet != null)
			{
				poppet.position = anoyoPos + anoyoPoppetOffset;
				poppet.rotation = Quaternion.identity;
			}
		}

		public void restorePlayer()
		{
			if (player != null)
			{
				player.position = BattleUtil.AdjustYpos(playerPos);
				player.rotation = playerRot;
				player = null;
			}
		}

		public void restorePoppet()
		{
			if (poppet != null)
			{
				poppet.position = BattleUtil.AdjustYpos(poppetPos);
				poppet.rotation = poppetRot;
				poppet = null;
			}
		}
	}

	[Serializable]
	public class ChainMainCameraControl
	{
		private GameObject camObj;

		private CameraControl showCam;

		private Transform target;

		private GameObject tmpObject;

		private bool _0024initialized__ChainSkillRoutine_ChainMainCameraControl_0024;

		public ChainMainCameraControl(MerlinActionControl _target)
		{
			if (!_0024initialized__ChainSkillRoutine_ChainMainCameraControl_0024)
			{
				_0024initialized__ChainSkillRoutine_ChainMainCameraControl_0024 = true;
			}
			if (!(_target != null))
			{
				throw new AssertionFailedException("_target != null");
			}
			target = _target.transform;
		}

		public ChainMainCameraControl(Vector3 _pos)
		{
			if (!_0024initialized__ChainSkillRoutine_ChainMainCameraControl_0024)
			{
				_0024initialized__ChainSkillRoutine_ChainMainCameraControl_0024 = true;
			}
			tmpObject = new GameObject("ChainSkillRoutine.ChainMainCameraControl.target");
			Transform transform = tmpObject.transform;
			transform.position = _pos;
			target = tmpObject.transform;
		}

		public void start()
		{
			showCam = createShowCamera(target);
		}

		public void fix()
		{
			destroyShowCam();
		}

		public void dispose()
		{
			destroyShowCam();
			if (tmpObject != null)
			{
				UnityEngine.Object.Destroy(tmpObject.gameObject);
				tmpObject = null;
			}
			if (camObj != null)
			{
				UnityEngine.Object.Destroy(camObj);
				camObj = null;
			}
		}

		private CameraControl createShowCamera(Transform target)
		{
			camObj = GameAssetModule.InstantiatePrefab("Prefab/Camera/RenkeiCamera");
			object result;
			if (camObj != null)
			{
				CameraControl cameraControl = ExtensionsModule.SetComponent<CameraControl>(camObj);
				cameraControl.setTarget(target);
				cameraControl.battleCameraUpdate();
				result = cameraControl;
			}
			else
			{
				result = null;
			}
			return (CameraControl)result;
		}

		private void destroyShowCam()
		{
			if (showCam != null)
			{
				UnityEngine.Object.Destroy(showCam);
				showCam = null;
			}
		}
	}

	[Serializable]
	public class ChainBackCameraControl
	{
		private Transform retargetChar;

		private Camera main;

		private CameraControl norm;

		private RaidCamera raid;

		private ColosseumCamera colcam;

		public ChainBackCameraControl(Transform _retargetChar)
		{
			main = Camera.main;
			if (!(main == null))
			{
				norm = main.GetComponent<CameraControl>();
				raid = RaidCamera.Instance;
				colcam = main.GetComponent<ColosseumCamera>();
				retargetChar = _retargetChar;
			}
		}

		public void stop()
		{
			stopTween();
			fix();
		}

		public void restoreAndSetTarget()
		{
			restore();
		}

		public void dispose()
		{
		}

		private void stopTween()
		{
			__ChainBackCameraControl_stopTween_0024callable181_0024762_17__ _ChainBackCameraControl_stopTween_0024callable181_0024762_17__ = delegate(MonoBehaviour c)
			{
				if (!(c == null))
				{
					int i = 0;
					iTween[] components = c.GetComponents<iTween>();
					for (int length = components.Length; i < length; i = checked(i + 1))
					{
						UnityEngine.Object.Destroy(components[i]);
					}
				}
			};
			_ChainBackCameraControl_stopTween_0024callable181_0024762_17__(norm);
			_ChainBackCameraControl_stopTween_0024callable181_0024762_17__(raid);
			_ChainBackCameraControl_stopTween_0024callable181_0024762_17__(colcam);
		}

		private void restore()
		{
			if (norm != null)
			{
				if (retargetChar != null)
				{
					norm.setTarget(retargetChar);
				}
				norm.setInitParam();
			}
			if (raid != null)
			{
				raid.isPositioning = false;
				raid.enabled = true;
			}
			if (colcam != null)
			{
				colcam.enabled = true;
			}
		}

		private void fix()
		{
			if (norm != null)
			{
				norm.setBasicCameraModeNone();
				norm.battleCameraUpdate();
			}
			if (raid != null)
			{
				raid.enabled = false;
			}
			if (colcam != null)
			{
				colcam.enabled = false;
			}
		}

		internal void _0024stopTween_0024_stop_00244020(MonoBehaviour c)
		{
			if (!(c == null))
			{
				int i = 0;
				iTween[] components = c.GetComponents<iTween>();
				for (int length = components.Length; i < length; i = checked(i + 1))
				{
					UnityEngine.Object.Destroy(components[i]);
				}
			}
		}
	}

	[Serializable]
	public class StrangerStopper
	{
		private AIControl poppet;

		private MerlinActionControl altTarget;

		private Boo.Lang.List<AIControl> strangers;

		private bool afterPlayerActionMode;

		public StrangerStopper(AIControl _poppet, MerlinActionControl _altTarget, object _afeterPlayerActionMode)
		{
			strangers = new Boo.Lang.List<AIControl>();
			afterPlayerActionMode = true;
			poppet = _poppet;
			altTarget = _altTarget;
			afterPlayerActionMode = RuntimeServices.UnboxBoolean(_afeterPlayerActionMode);
			int i = 0;
			BaseControl[] allControls = BaseControl.AllControls;
			for (int length = allControls.Length; i < length; i = checked(i + 1))
			{
				if (allControls[i] is AIControl && allControls[i] != poppet)
				{
					strangers.Add(allControls[i] as AIControl);
				}
			}
		}

		public void stop()
		{
			IEnumerator<AIControl> enumerator = strangers.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					AIControl current = enumerator.Current;
					if (current != null)
					{
						current.AIMODE_Stop();
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}

		public void restartAfterPlayerPrologueAction()
		{
			if (afterPlayerActionMode)
			{
				restart();
			}
		}

		public void restartAfterPoppetAction()
		{
			if (!afterPlayerActionMode)
			{
				restart();
			}
		}

		private void restart()
		{
			IEnumerator<AIControl> enumerator = strangers.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					AIControl current = enumerator.Current;
					if (!(current == null))
					{
						current.AIMODE_Battle();
						if (current.targetPlayerControl == poppet && poppet != null)
						{
							current.targetPlayerControl = altTarget;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	[Serializable]
	public class NymphControl
	{
		private EnumElements element;

		private GameObject nymph;

		private Vector3 position;

		private bool noElement;

		private bool _0024initialized__ChainSkillRoutine_NymphControl_0024;

		public NymphControl(RespPoppet poppetData, Vector3 _position)
		{
			if (!_0024initialized__ChainSkillRoutine_NymphControl_0024)
			{
				_0024initialized__ChainSkillRoutine_NymphControl_0024 = true;
			}
			if (poppetData != null)
			{
				element = (EnumElements)poppetData.ElementId;
				position = _position;
				noElement = poppetData.Master.NoChainElementEffect;
			}
			else
			{
				noElement = true;
			}
		}

		public NymphControl(EnumElements elm, Vector3 _position)
		{
			if (!_0024initialized__ChainSkillRoutine_NymphControl_0024)
			{
				_0024initialized__ChainSkillRoutine_NymphControl_0024 = true;
			}
			element = elm;
			position = _position;
		}

		public void start()
		{
			if (!noElement)
			{
				create(position);
				playSound();
			}
		}

		public void dispose()
		{
			if (!noElement && nymph != null)
			{
				UnityEngine.Object.Destroy(nymph);
			}
		}

		private void create(Vector3 pos)
		{
			string text = null;
			if (element == EnumElements.fire)
			{
				text = "Prefab/Character/Seirei/Salamander";
			}
			else if (element == EnumElements.water)
			{
				text = "Prefab/Character/Seirei/Undine";
			}
			else if (element == EnumElements.wind)
			{
				text = "Prefab/Character/Seirei/Gin";
			}
			else if (element == EnumElements.earth)
			{
				text = "Prefab/Character/Seirei/Gnome";
			}
			if (text != null)
			{
				nymph = GameAssetModule.InstantiatePrefab(text);
				if (nymph != null)
				{
					nymph.transform.position = pos;
				}
			}
		}

		private void playSound()
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (!(instance == null))
			{
				int num = -1;
				if (element == EnumElements.fire)
				{
					num = 83;
				}
				else if (element == EnumElements.water)
				{
					num = 84;
				}
				else if (element == EnumElements.wind)
				{
					num = 85;
				}
				else if (element == EnumElements.earth)
				{
					num = 86;
				}
				if (num >= 0 && nymph != null)
				{
					instance.PlaySe(num, 0, nymph.GetInstanceID());
				}
			}
		}
	}

	[Serializable]
	public class LogoCont
	{
		private MChainSkills skillMst;

		private MElements element;

		private BattleHUDChainSkillLogo logoObj;

		private bool disableMode;

		public LogoCont(MChainSkills _skillMst, MElements _element, bool _disableMode)
		{
			skillMst = _skillMst;
			element = _element;
			logoObj = QuestAssets.Instance.instantiateChainSkillLogo();
			disableMode = _disableMode;
		}

		public void start()
		{
			if (skillMst != null)
			{
				if (disableMode)
				{
					logoObj.show(MTexts.Msg("exp_skillmsg_noeffect_logo"));
				}
				else if (logoObj != null && skillMst != null)
				{
					logoObj.show(skillMst, element);
				}
			}
		}

		public void hide()
		{
			if (logoObj != null)
			{
				logoObj.hide();
			}
		}

		public void dispose()
		{
			if (logoObj != null)
			{
				UnityEngine.Object.Destroy(logoObj.gameObject);
			}
		}
	}

	[Serializable]
	public abstract class ChainEffectEmitterBase
	{
		private AIControl poppet;

		private MerlinActionControl emitBaseChar;

		private EnumSkillActionTypes actType;

		private GameObject effectPrefab;

		private GameObject healHitPrefab;

		private MChainSkills chainSkill;

		private MChainSkillEffects effectConf;

		private float damageScale;

		private bool isPoppetOnly;

		public MChainSkills ChainSkill => chainSkill;

		public MChainSkillEffects EffectConf => effectConf;

		protected ChainEffectEmitterBase(AIControl _poppet, MerlinActionControl _emitBaseChar, EnumSkillActionTypes _actType)
		{
			if (!(_poppet != null))
			{
				throw new AssertionFailedException("_poppet != null");
			}
			if (!_poppet.HasPoppetData)
			{
				throw new AssertionFailedException("_poppet.HasPoppetData");
			}
			if (!(_emitBaseChar != null))
			{
				throw new AssertionFailedException("_emitBaseChar != null");
			}
			poppet = _poppet;
			emitBaseChar = _emitBaseChar;
			actType = _actType;
			if (poppet != null)
			{
				effectPrefab = poppet.ChainEffectCache.ChainEffect;
				healHitPrefab = poppet.ChainEffectCache.HealHitEffect;
			}
			else
			{
				effectPrefab = null;
				healHitPrefab = null;
			}
			chainSkill = null;
			if (poppet.PoppetData != null)
			{
				chainSkill = poppet.PoppetData.ChainSkill;
			}
			effectConf = MChainSkillEffects.Find(chainSkill);
			damageScale = 2f;
		}

		public virtual void startAtPlayerAction()
		{
		}

		public virtual void startAtPoppetAction()
		{
		}

		public void dispose()
		{
			poppet = null;
			emitBaseChar = null;
			effectPrefab = null;
		}

		protected void start(float delay, float downHitDelay)
		{
			if (!(poppet == null) && poppet.HasPoppetData)
			{
				emitMain(delay, downHitDelay);
			}
		}

		protected void emitMain(float delay, float downHitDelay)
		{
			if (actType == EnumSkillActionTypes.Attack)
			{
				emitAttack(delay);
			}
			else if (actType == EnumSkillActionTypes.Heal)
			{
				emitHeal(delay);
			}
			else
			{
				emitAttack(delay);
			}
			if (effectConf != null && effectConf.HasDownHit)
			{
				emitDownHitEffect(downHitDelay);
			}
		}

		protected void emitAttack(float delay)
		{
			if (effectPrefab == null)
			{
				if (!(poppet == null))
				{
				}
				return;
			}
			string boneName = "y_ang";
			ActionCommandEffect.TransformMode emitMode = ActionCommandEffect.TransformMode.PosRot;
			ActionCommandEffect.TransformMode constraintMode = ActionCommandEffect.TransformMode.None;
			float offset_x = 0f;
			float offset_y = 0.5f;
			float offset_z = 1f;
			float rot_x = 0f;
			float rot_y = 0f;
			float rot_z = 0f;
			string seName = "se_battle_spear_hit_l";
			bool once = false;
			float damage = damageScale;
			YarareTypes yarareType = YarareTypes.Weak;
			float knockBackPow = 0.5f;
			float num = 0f;
			if (effectConf != null)
			{
				emitMode = (ActionCommandEffect.TransformMode)effectConf.EmitMode;
				offset_x = effectConf.OfsX;
				offset_y = effectConf.OfsY;
				offset_z = effectConf.OfsZ;
				once = effectConf.Once;
				damage = effectConf.Damage;
				yarareType = effectConf.YarareType;
				knockBackPow = effectConf.KnockBackPow;
				num = effectConf.EffKillTime;
			}
			emitBaseChar.EFFECT(effectPrefab, delay, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
			if (!(num <= 0f))
			{
				emitBaseChar.EFF_KILLTIME(num, null);
			}
			if (!(damage <= 0f))
			{
				emitBaseChar.EFF_ATTACK(0f, 3f, once, 100, yarareType, knockBackPow);
				emitBaseChar.ATK_INTERVAL(0.2f);
				emitBaseChar.ATK_LIMITCOUNT(99);
				emitBaseChar.ATK_INVSUPARM();
				emitBaseChar.ATK_SE(seName);
				emitBaseChar.setChainSkillInfoToLastEffectAttack(poppet.PoppetData, damage);
			}
			if (effectConf != null && effectConf.AbnormalState != 0)
			{
				EnumAbnormalStates abnormalState = effectConf.AbnormalState;
				int abnormalStateRate = effectConf.AbnormalStateRate;
				int abnormalStatePower = effectConf.AbnormalStatePower;
				emitBaseChar.ATK_ABST_POW(abnormalState, abnormalStateRate, abnormalStatePower);
			}
		}

		protected void emitHeal(float delay)
		{
			if (effectPrefab == null)
			{
				return;
			}
			string boneName = "y_ang";
			ActionCommandEffect.TransformMode emitMode = ActionCommandEffect.TransformMode.Pos;
			ActionCommandEffect.TransformMode constraintMode = ActionCommandEffect.TransformMode.PosRot;
			float offset_x = 0f;
			float offset_y = 0f;
			float offset_z = 0f;
			float rot_x = 0f;
			float rot_y = 0f;
			float rot_z = 0f;
			float time = 20f;
			if (effectConf != null)
			{
				emitMode = (ActionCommandEffect.TransformMode)effectConf.EmitMode;
				offset_x = effectConf.OfsX;
				offset_y = effectConf.OfsY;
				offset_z = effectConf.OfsZ;
				if (!(effectConf.EffKillTime <= 0f))
				{
					time = effectConf.EffKillTime;
				}
			}
			emitBaseChar.EFFECT(effectPrefab, delay, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
			emitBaseChar.EFF_KILLTIME(time, null);
		}

		protected void emitDownHitEffect(float delay)
		{
			if (!(healHitPrefab == null))
			{
				string boneName = "y_ang";
				ActionCommandEffect.TransformMode emitMode = ActionCommandEffect.TransformMode.PosRot;
				ActionCommandEffect.TransformMode constraintMode = ActionCommandEffect.TransformMode.None;
				float offset_x = 0f;
				float offset_y = 0f;
				float offset_z = 0f;
				float rot_x = 0f;
				float rot_y = 0f;
				float rot_z = 0f;
				float time = 10f;
				string seName = "se_battle_spear_hit_l";
				emitBaseChar.EFFECT(healHitPrefab, delay, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
				emitBaseChar.EFF_TIME(time);
				emitBaseChar.EFF_ATTACK(0f, 3f, once: false, 1, YarareTypes.Down, 0.5f);
				emitBaseChar.ATK_LIMITCOUNT(1);
				emitBaseChar.ATK_INVSUPARM();
				emitBaseChar.ATK_SE(seName);
			}
		}
	}

	[Serializable]
	public class ChainEffectEmitterWithPlayer : ChainEffectEmitterBase
	{
		public ChainEffectEmitterWithPlayer(AIControl _poppet, MerlinActionControl _emitBaseChar, EnumSkillActionTypes _actType)
			: base(_poppet, _emitBaseChar, _actType)
		{
		}

		public override void startAtPlayerAction()
		{
			float delay = ((EffectConf == null) ? 1.08f : EffectConf.PlayerEmitDelay);
			float downHitDelay = ((EffectConf == null) ? 1.08f : EffectConf.DownHitEffectDelay);
			start(delay, downHitDelay);
		}
	}

	[Serializable]
	public class ChainEffectEmitterPoppetOnly : ChainEffectEmitterBase
	{
		private bool disableMode;

		public ChainEffectEmitterPoppetOnly(AIControl _poppet, MerlinActionControl _emitBaseChar, EnumSkillActionTypes _actType, bool _disableMode)
			: base(_poppet, _emitBaseChar, _actType)
		{
			disableMode = _disableMode;
		}

		public override void startAtPoppetAction()
		{
			float num = ((EffectConf == null) ? 0f : EffectConf.PoppetEmitDelay);
			if (disableMode)
			{
				emitDownHitEffect(num);
			}
			else
			{
				start(num, num);
			}
		}
	}

	[Serializable]
	public abstract class IGameSystemEffect
	{
		public virtual void preStagingHUDUpdate()
		{
		}

		public virtual void reviveAndUseMagicPoint()
		{
		}

		public virtual void instantEffect()
		{
		}

		public virtual void postStagingEffect()
		{
		}

		public virtual void dispose()
		{
		}

		protected void useMagicPoint(AIControl poppet)
		{
			if (!(poppet == null))
			{
				MagicSkill magicSkillComponent = poppet.MagicSkillComponent;
				if (magicSkillComponent != null)
				{
					magicSkillComponent.zeroMagicPoint();
				}
			}
		}
	}

	[Serializable]
	public class QuestGameSystemEffect : IGameSystemEffect
	{
		private PlayerControl player;

		private SkillEffector skillEffector;

		private AIControl poppet;

		private RespPoppet poppetData;

		private int poppetIndex;

		public QuestGameSystemEffect(PlayerControl _player, AIControl _poppet, RespPoppet _poppetData, int _poppetIndex)
		{
			if (!(_player != null))
			{
				throw new AssertionFailedException("_player != null");
			}
			player = _player;
			poppet = _poppet;
			poppetData = _poppetData;
			poppetIndex = _poppetIndex;
			skillEffector = player.createChainSkillEffect(poppetData);
		}

		public override void preStagingHUDUpdate()
		{
			BattleHUDMappet.UseGaugeAnimation(poppetIndex);
		}

		public override void reviveAndUseMagicPoint()
		{
			if (!(poppet == null))
			{
				poppet.Revive();
				useMagicPoint(poppet);
			}
		}

		public override void instantEffect()
		{
			if (!(player == null) && skillEffector != null)
			{
				skillEffector.effectAtSkillEmission(poppetData, player);
				skillEffector.effectAtSkillEmissionToEnemies(player);
				player.startHUDSkillTimerMode(poppetIndex, skillEffector);
			}
		}

		public override void postStagingEffect()
		{
			if (true && !(poppet == null))
			{
				poppet.setHitPointMax();
				poppet.showHPMiniBar();
			}
		}

		public override void dispose()
		{
			player = null;
			skillEffector = null;
			poppet = null;
			poppetData = null;
		}
	}

	[Serializable]
	public class ColosseumGameSystemEffect : IGameSystemEffect
	{
		private AIControl poppet;

		private RespPoppet poppetData;

		private Boo.Lang.List<AIControl> partners;

		private SkillEffector skillEffector;

		public ColosseumGameSystemEffect(AIControl _poppet, RespPoppet _poppetData)
		{
			partners = new Boo.Lang.List<AIControl>();
			poppet = _poppet;
			poppetData = _poppetData;
			if (poppetData != null)
			{
				skillEffector = poppet.createChainSkillEffect(poppetData);
			}
			int i = 0;
			BaseControl[] allControls = BaseControl.AllControls;
			for (int length = allControls.Length; i < length; i = checked(i + 1))
			{
				if (allControls[i] is AIControl)
				{
					AIControl aIControl = allControls[i] as AIControl;
					if (poppet.IsPlayer == aIControl.IsPlayer)
					{
						partners.Add(allControls[i] as AIControl);
					}
				}
			}
		}

		public override void preStagingHUDUpdate()
		{
		}

		public override void reviveAndUseMagicPoint()
		{
			if (!(poppet == null))
			{
				useMagicPoint(poppet);
			}
		}

		public override void instantEffect()
		{
			if (skillEffector == null)
			{
				return;
			}
			IEnumerator<AIControl> enumerator = partners.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					AIControl current = enumerator.Current;
					if (isEffective(current))
					{
						skillEffector.effectAtSkillEmission(poppetData, current);
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			skillEffector.effectAtSkillEmissionToEnemies(poppet);
		}

		public override void postStagingEffect()
		{
		}

		private bool isEffective(AIControl ai)
		{
			bool num = ai != null;
			if (num)
			{
				num = ai.IsAlive;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024mainRoutine_0024locals_002414341
	{
		internal IPlayerActionControl _0024playerActCont;

		internal NymphControl _0024nymphCont;

		internal ChainEffectEmitterBase _0024effectEmitter;

		internal bool _0024_endOfChainBodyMotion;
	}

	[Serializable]
	internal class _0024mainRoutine_0024waitPlayerAction_00244021
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416750 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal float _0024_0024wait_until_0024temp_00241202_002416751;

				internal float _0024_0024wait_until_0024temp_00241203_002416752;

				internal _0024mainRoutine_0024waitPlayerAction_00244021 _0024self__002416753;

				public _0024(_0024mainRoutine_0024waitPlayerAction_00244021 self_)
				{
					_0024self__002416753 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024_0024wait_until_0024temp_00241202_002416751 = 1f;
						_0024_0024wait_until_0024temp_00241203_002416752 = Time.realtimeSinceStartup;
						goto case 2;
					case 2:
						if (!_0024self__002416753._0024_0024locals_002414786._0024playerActCont.IsChainActionPlaying && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241203_002416752 < _0024_0024wait_until_0024temp_00241202_002416751)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002416753._0024_0024locals_002414786._0024effectEmitter.startAtPlayerAction();
						goto case 3;
					case 3:
						if (!_0024self__002416753._0024_0024locals_002414786._0024playerActCont.IsChainActionEnd)
						{
							_0024self__002416753._0024_0024locals_002414786._0024playerActCont.updateWhileChainAction();
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002416753._0024_0024locals_002414786._0024playerActCont.restoreToBattle();
						_0024self__002416753._0024_0024locals_002414786._0024nymphCont.dispose();
						_0024self__002416753._0024_0024locals_002414786._0024_endOfChainBodyMotion = true;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024mainRoutine_0024waitPlayerAction_00244021 _0024self__002416754;

			public _0024Invoke_002416750(_0024mainRoutine_0024waitPlayerAction_00244021 self_)
			{
				_0024self__002416754 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002416754);
			}
		}

		internal _0024mainRoutine_0024locals_002414341 _0024_0024locals_002414786;

		public _0024mainRoutine_0024waitPlayerAction_00244021(_0024mainRoutine_0024locals_002414341 _0024_0024locals_002414786)
		{
			this._0024_0024locals_002414786 = _0024_0024locals_002414786;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002416750(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002416726 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024player_002416727;

			internal AIControl _0024poppet_002416728;

			internal RespPoppet _0024poppetData_002416729;

			internal int _0024poppetIndex_002416730;

			internal MChainSkills _0024chainSkillMst_002416731;

			internal Vector3 _0024poppetOffset_002416732;

			internal Vector3 _0024ANOYO_POSITION_002416733;

			internal Vector3 _0024ANOYO_NYMPH_POSITION_002416734;

			internal PoppetActionControl _0024poppetActCont_002416735;

			internal ChainMainCameraControl _0024mainCamCont_002416736;

			internal ChainBackCameraControl _0024backCamCont_002416737;

			internal ActorPositionControl _0024actorPosCont_002416738;

			internal StrangerStopper _0024strangerCont_002416739;

			internal LogoCont _0024logoCont_002416740;

			internal IGameSystemEffect _0024gameSysEff_002416741;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024waitPlayerAction_002416742;

			internal IEnumerator _0024_0024sco_0024temp_00241204_002416743;

			internal float _0024_0024wait_sec_0024temp_00241205_002416744;

			internal _0024mainRoutine_0024locals_002414341 _0024_0024locals_002416745;

			internal Params _0024param_002416746;

			internal ChainSkillRoutine _0024self__002416747;

			public _0024(Params param, ChainSkillRoutine self_)
			{
				_0024param_002416746 = param;
				_0024self__002416747 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416745 = new _0024mainRoutine_0024locals_002414341();
					_0024self__002416747.debugCurrentState = 0;
					_0024self__002416747.isPlaying = true;
					_0024self__002416747.isPlayingMotion = true;
					_0024self__002416747.playParam = _0024param_002416746;
					_0024player_002416727 = _0024param_002416746.player;
					_0024poppet_002416728 = _0024param_002416746.poppet;
					_0024poppetData_002416729 = _0024param_002416746.poppetData;
					_0024poppetIndex_002416730 = _0024param_002416746.poppetIndex;
					_0024chainSkillMst_002416731 = _0024param_002416746.poppetData.ChainSkill;
					_0024poppetOffset_002416732 = _0024param_002416746.MagicSkillOffsetPos;
					_0024ANOYO_POSITION_002416733 = new Vector3(1000f, 0f, 1000f);
					_0024ANOYO_NYMPH_POSITION_002416734 = _0024ANOYO_POSITION_002416733 + new Vector3(0f, 3f, 0f);
					_0024_0024locals_002416745._0024playerActCont = null;
					_0024poppetActCont_002416735 = null;
					_0024mainCamCont_002416736 = null;
					_0024backCamCont_002416737 = null;
					_0024actorPosCont_002416738 = null;
					_0024strangerCont_002416739 = null;
					_0024_0024locals_002416745._0024nymphCont = null;
					_0024logoCont_002416740 = null;
					_0024_0024locals_002416745._0024effectEmitter = null;
					_0024gameSysEff_002416741 = null;
					if (_0024param_002416746.WithPlayerMode)
					{
						_0024_0024locals_002416745._0024playerActCont = new PlayerActionControl(_0024player_002416727, (EnumSkillActionTypes)_0024param_002416746.ActionType, _0024chainSkillMst_002416731);
						_0024poppetActCont_002416735 = new PoppetActionControl(_0024poppet_002416728, _useQuestAction: true);
						_0024mainCamCont_002416736 = new ChainMainCameraControl(_0024player_002416727);
						_0024backCamCont_002416737 = new ChainBackCameraControl(_0024player_002416727.transform);
						_0024actorPosCont_002416738 = new ActorPositionControl(_0024player_002416727.transform, _0024poppet_002416728.transform, _0024ANOYO_POSITION_002416733, _0024poppetOffset_002416732);
						_0024strangerCont_002416739 = new StrangerStopper(_0024poppet_002416728, _0024player_002416727, true);
						_0024_0024locals_002416745._0024nymphCont = new NymphControl(_0024poppetData_002416729, _0024ANOYO_NYMPH_POSITION_002416734);
						_0024logoCont_002416740 = new LogoCont(_0024chainSkillMst_002416731, _0024poppetData_002416729.Element, _disableMode: false);
						_0024_0024locals_002416745._0024effectEmitter = new ChainEffectEmitterWithPlayer(_0024poppet_002416728, _0024player_002416727, (EnumSkillActionTypes)_0024param_002416746.ActionType);
						_0024gameSysEff_002416741 = new QuestGameSystemEffect(_0024player_002416727, _0024poppet_002416728, _0024poppetData_002416729, _0024poppetIndex_002416730);
					}
					else
					{
						_0024_0024locals_002416745._0024playerActCont = new DummyPlayerActionControl(1.5f);
						_0024poppetActCont_002416735 = new PoppetActionControl(_0024poppet_002416728, _useQuestAction: false);
						_0024mainCamCont_002416736 = new ChainMainCameraControl(_0024ANOYO_POSITION_002416733);
						_0024backCamCont_002416737 = new ChainBackCameraControl(null);
						_0024actorPosCont_002416738 = new ActorPositionControl(null, _0024poppet_002416728.transform, _0024ANOYO_POSITION_002416733, Vector3.zero);
						_0024strangerCont_002416739 = new StrangerStopper(_0024poppet_002416728, _0024poppet_002416728, false);
						_0024_0024locals_002416745._0024nymphCont = new NymphControl(_0024poppetData_002416729, _0024ANOYO_NYMPH_POSITION_002416734);
						_0024logoCont_002416740 = new LogoCont(_0024chainSkillMst_002416731, _0024poppetData_002416729.Element, _0024poppetData_002416729.ColosseumChainDisabled);
						_0024_0024locals_002416745._0024effectEmitter = new ChainEffectEmitterPoppetOnly(_0024poppet_002416728, _0024poppet_002416728, (EnumSkillActionTypes)_0024param_002416746.ActionType, _0024poppetData_002416729.ColosseumChainDisabled);
						_0024gameSysEff_002416741 = new ColosseumGameSystemEffect(_0024poppet_002416728, _0024poppetData_002416729);
					}
					_0024self__002416747.debugCurrentState = 1;
					_0024gameSysEff_002416741.preStagingHUDUpdate();
					_0024gameSysEff_002416741.reviveAndUseMagicPoint();
					_0024self__002416747.debugCurrentState = 2;
					_0024strangerCont_002416739.stop();
					_0024backCamCont_002416737.stop();
					_0024_0024locals_002416745._0024playerActCont.stop();
					_0024poppetActCont_002416735.stop();
					_0024actorPosCont_002416738.gotoAnoyo();
					_0024mainCamCont_002416736.start();
					_0024self__002416747.debugCurrentState = 4;
					PlayerEventDispatcher.InvokeChain(_0024poppet_002416728);
					_0024_0024locals_002416745._0024nymphCont.start();
					_0024logoCont_002416740.start();
					_0024self__002416747.debugCurrentState = 5;
					ScreenMask.Instance.activate();
					_0024poppetActCont_002416735.start();
					_0024_0024locals_002416745._0024playerActCont.startPrologueAction();
					goto case 2;
				case 2:
					if (!_0024_0024locals_002416745._0024playerActCont.IsPrologueActionEnd)
					{
						_0024_0024locals_002416745._0024playerActCont.updatePrologueAction();
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					ScreenMask.deactivate();
					_0024self__002416747.debugCurrentState = 6;
					_0024actorPosCont_002416738.restorePlayer();
					_0024gameSysEff_002416741.instantEffect();
					_0024logoCont_002416740.hide();
					_0024strangerCont_002416739.restartAfterPlayerPrologueAction();
					_0024mainCamCont_002416736.fix();
					_0024self__002416747.debugCurrentState = 7;
					_0024_0024locals_002416745._0024playerActCont.startChainAction();
					_0024_0024locals_002416745._0024_endOfChainBodyMotion = false;
					_0024waitPlayerAction_002416742 = new _0024mainRoutine_0024waitPlayerAction_00244021(_0024_0024locals_002416745).Invoke;
					_0024_0024sco_0024temp_00241204_002416743 = _0024waitPlayerAction_002416742();
					if (_0024_0024sco_0024temp_00241204_002416743 != null)
					{
						_0024self__002416747.StartCoroutine(_0024_0024sco_0024temp_00241204_002416743);
					}
					goto case 3;
				case 3:
					if (!_0024poppetActCont_002416735.IsEndOfAction)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002416747.debugCurrentState = 8;
					_0024_0024locals_002416745._0024effectEmitter.startAtPoppetAction();
					_0024strangerCont_002416739.restartAfterPoppetAction();
					_0024actorPosCont_002416738.restorePoppet();
					_0024gameSysEff_002416741.postStagingEffect();
					_0024backCamCont_002416737.restoreAndSetTarget();
					_0024poppetActCont_002416735.restoreToBattle();
					goto case 4;
				case 4:
					if (!_0024_0024locals_002416745._0024_endOfChainBodyMotion)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024logoCont_002416740.dispose();
					_0024mainCamCont_002416736.dispose();
					_0024backCamCont_002416737.dispose();
					_0024_0024locals_002416745._0024effectEmitter.dispose();
					_0024gameSysEff_002416741.dispose();
					_0024self__002416747.isPlayingMotion = false;
					_0024_0024wait_sec_0024temp_00241205_002416744 = 0.5f;
					goto case 5;
				case 5:
					if (_0024_0024wait_sec_0024temp_00241205_002416744 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241205_002416744 -= Time.deltaTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002416747.isPlaying = false;
					_0024self__002416747.playParam = null;
					_0024self__002416747.debugCurrentState = 999;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Params _0024param_002416748;

		internal ChainSkillRoutine _0024self__002416749;

		public _0024mainRoutine_002416726(Params param, ChainSkillRoutine self_)
		{
			_0024param_002416748 = param;
			_0024self__002416749 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024param_002416748, _0024self__002416749);
		}
	}

	private bool isPlaying;

	private bool isPlayingMotion;

	private Params playParam;

	[NonSerialized]
	private static ChainSkillRoutine _Instance;

	[NonSerialized]
	public const string MAGIC_SKILL_CAMERA_PREFAB_PATH = "Prefab/Camera/RenkeiCamera";

	[NonSerialized]
	public const string SALA_PREFAB_PATH = "Prefab/Character/Seirei/Salamander";

	[NonSerialized]
	public const string UNDN_PREFAB_PATH = "Prefab/Character/Seirei/Undine";

	[NonSerialized]
	public const string GNOM_PREFAB_PATH = "Prefab/Character/Seirei/Gnome";

	[NonSerialized]
	public const string GIN_PREFAB_PATH = "Prefab/Character/Seirei/Gin";

	[NonSerialized]
	protected static readonly SQEX_SoundPlayerData.SE START_SOUND = SQEX_SoundPlayerData.SE.skill_motion;

	private int _debugCurrentState;

	public static bool IsPlaying
	{
		get
		{
			bool num = _Instance != null;
			if (num)
			{
				num = _Instance.isPlaying;
			}
			return num;
		}
	}

	public static bool IsPlayingMotion
	{
		get
		{
			bool num = _Instance != null;
			if (num)
			{
				num = _Instance.isPlayingMotion;
			}
			return num;
		}
	}

	public static ChainSkillRoutine Instance
	{
		get
		{
			if (_Instance == null)
			{
				GameObject component = new GameObject("__SSS_ChainSkillRoutine__");
				_Instance = ExtensionsModule.SetComponent<ChainSkillRoutine>(component);
			}
			if (!(_Instance != null))
			{
				throw new AssertionFailedException("_Instance != null");
			}
			return _Instance;
		}
	}

	protected int debugCurrentState
	{
		get
		{
			return _debugCurrentState;
		}
		set
		{
			_debugCurrentState = value;
		}
	}

	public static bool IsPlayingPoppet(AIControl poppet)
	{
		int num;
		if (_Instance == null || poppet == null)
		{
			num = 0;
		}
		else
		{
			Params @params = _Instance.playParam;
			num = (_Instance.isPlaying ? 1 : 0);
			if (num != 0)
			{
				num = ((@params != null) ? 1 : 0);
			}
			if (num != 0)
			{
				num = ((@params.poppet == poppet) ? 1 : 0);
			}
		}
		return (byte)num != 0;
	}

	public void execSkill(PlayerControl player, int poppetIndex)
	{
		if (isPlaying)
		{
			return;
		}
		Params @params = new Params(player, poppetIndex);
		if (!@params.IsValid)
		{
			@params.dump();
			return;
		}
		IEnumerator enumerator = mainRoutine(@params);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void execSkill(AIControl poppet)
	{
		if (isPlaying)
		{
			return;
		}
		Params @params = new Params(poppet);
		if (!@params.IsValid)
		{
			@params.dump();
			return;
		}
		IEnumerator enumerator = mainRoutine(@params);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator mainRoutine(Params param)
	{
		return new _0024mainRoutine_002416726(param, this).GetEnumerator();
	}
}
