using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using ObjUtil;
using UnityEngine;

[Serializable]
public class MerlinActionControl : BaseControl
{
	[Serializable]
	public class ActionSettingsType
	{
		public float defaultRotationSpeed;

		public ActionSettingsType()
		{
			defaultRotationSpeed = 360f;
		}
	}

	[Serializable]
	[Flags]
	public enum MovementFlags
	{
		NoVelocity = 0,
		NoMotionBase = 1,
		NoGravity = 2,
		NoExtraMove = 3,
		NoVolatileMove = 4
	}

	[Serializable]
	public class MotDefParam
	{
	}

	[Serializable]
	public abstract class ActCommand
	{
		[NonSerialized]
		private static int debugSerialID = 1;

		private int id;

		public MerlinActionControl parent;

		private float worldTime;

		public GameObject ParentGameObject => (!parent) ? null : parent.gameObject;

		public MerlinActionInput Input => (!parent) ? null : parent.ActionInput;

		public MerlinMotionPackControl Mmpc => (!parent) ? null : parent.Mmpc;

		public float MotionTime
		{
			get
			{
				MerlinActionControl merlinActionControl;
				return (!((!(merlinActionControl = parent)) ? ((MonoBehaviour)merlinActionControl) : ((MonoBehaviour)parent.Mmpc))) ? 0f : parent.Mmpc.MotionTime;
			}
		}

		public float MotionLength
		{
			get
			{
				MerlinActionControl merlinActionControl;
				return (!((!(merlinActionControl = parent)) ? ((MonoBehaviour)merlinActionControl) : ((MonoBehaviour)parent.Mmpc))) ? 0f : parent.Mmpc.MotionLength;
			}
		}

		public Vector3 CharPosition => (!parent) ? Vector3.zero : parent.gameObject.transform.position;

		public Vector3 TargetPos => (!parent) ? Vector3.zero : ((!parent.TargetChar) ? (parent.transform.position + parent.transform.forward) : parent.TargetChar.transform.position);

		public ActionSettingsType ActionSettings => (!parent) ? new ActionSettingsType() : parent.ActionSettings;

		public float UpdateDeltaTime => Mmpc.UpdateDeltaTime;

		public float WorldDeltaTime => Time.deltaTime;

		public override bool UpdateWithWorldTime => false;

		public override bool IsDead => false;

		public override bool DisposeAtMotionChange
		{
			get
			{
				bool num = !UpdateWithWorldTime;
				if (!num)
				{
					num = IsDead;
				}
				return num;
			}
		}

		public float WorldTime
		{
			get
			{
				return worldTime;
			}
			set
			{
				worldTime = value;
			}
		}

		public ActCommand()
		{
			id = checked(++debugSerialID);
		}

		public void deblog(string msg)
		{
			if (parent != null)
			{
				parent.deblog(new StringBuilder("<no parent ").Append(GetType().Name).Append(">:").ToString() + msg);
			}
		}

		public virtual void doInit()
		{
		}

		public virtual void doUpdate(float motionTime)
		{
		}

		public virtual void doDispose()
		{
		}

		public override string ToString()
		{
			return new StringBuilder("[").Append((object)id).Append(" ").ToString() + ObjUtilModule.DebugObjectInspection(this) + "]";
		}
	}

	[Serializable]
	public class ActCommandWithHandler : ActCommand
	{
		public ICallable doInitHandler;

		public __CooldownValue_UpdateHandler_0024callable50_002433_30__ doUpdateHandler;

		public ICallable doDisposeHandler;

		public override void doInit()
		{
			if (doInitHandler != null)
			{
				doInitHandler.Call(new object[0]);
			}
		}

		public override void doUpdate(float motionTime)
		{
			if (doUpdateHandler != null)
			{
				doUpdateHandler(motionTime);
			}
		}

		public override void doDispose()
		{
			if (doDisposeHandler != null)
			{
				doDisposeHandler.Call(new object[0]);
			}
		}
	}

	[Serializable]
	public class ActTimeCommand : ActCommand
	{
		[Serializable]
		private enum Step
		{
			awaked,
			started,
			mainDone,
			ended
		}

		private float _startTime;

		public float mainTime;

		public float endTime;

		public bool useMyTimer;

		public float myTimer;

		public bool stopMyTimer;

		private bool disposed;

		private Step step;

		public float startTime
		{
			get
			{
				return (_startTime >= 0f) ? _startTime : (MotionLength + _startTime);
			}
			set
			{
				_startTime = value;
			}
		}

		public float CurrentCommandTime => (!useMyTimer) ? Mmpc.MotionTime : myTimer;

		public bool IsValidTimeSetting
		{
			get
			{
				bool num = !(0f > startTime);
				if (num)
				{
					num = !(startTime > mainTime);
				}
				if (num)
				{
					num = !(mainTime > endTime);
				}
				return num;
			}
		}

		public bool IsInTime
		{
			get
			{
				bool num = Step.started <= step;
				if (num)
				{
					num = step < Step.ended;
				}
				return num;
			}
		}

		public bool Disposed => disposed;

		public Step CurrentTimeStep => step;

		public ActTimeCommand()
		{
			step = Step.awaked;
		}

		public void enableMyTimer()
		{
			useMyTimer = true;
		}

		public override void doUpdate(float motionTime)
		{
			if (disposed)
			{
				return;
			}
			MerlinMotionPackControl mmpc = parent.Mmpc;
			float num = motionTime;
			if (useMyTimer)
			{
				if (!stopMyTimer)
				{
					myTimer += WorldDeltaTime;
				}
				num = myTimer;
			}
			if (step == Step.awaked && !(startTime > num))
			{
				doStart();
				step = Step.started;
			}
			if (step == Step.started && !(mainTime > num))
			{
				doMain();
				step = Step.mainDone;
			}
			if ((step == Step.started || step == Step.mainDone) && !(endTime > num))
			{
				doEnd();
				step = Step.ended;
			}
			if (Step.started <= step && step < Step.ended)
			{
				doUpdateInTime();
			}
			doUpdateAllTime();
		}

		public override void doDispose()
		{
			if (step == Step.started || step == Step.mainDone)
			{
				doEnd();
			}
			disposed = true;
		}

		public virtual bool doStart()
		{
			return true;
		}

		public virtual bool doMain()
		{
			return true;
		}

		public virtual bool doEnd()
		{
			return true;
		}

		public virtual void doUpdateInTime()
		{
		}

		public virtual void doUpdateAllTime()
		{
		}

		public void setAllTime()
		{
			startTime = 0f;
			mainTime = 0f;
			endTime = float.PositiveInfinity;
		}

		public void setJustTime(float time)
		{
			startTime = time;
			mainTime = time;
			endTime = time;
		}

		public void setTimeRange(float start, float end)
		{
			startTime = start;
			mainTime = start;
			endTime = end;
		}
	}

	[Serializable]
	public struct AntiAreaDamages
	{
		public bool antiDamageArea;

		public bool antiSlowArea;

		public bool antiGravityArea;

		public AntiAreaDamages(bool antiDamage, bool antiSlow, bool antiGravity)
		{
			antiDamageArea = antiDamage;
			antiSlowArea = antiSlow;
			antiGravityArea = antiGravity;
		}

		public override string ToString()
		{
			return new StringBuilder("anti damage=").Append(antiDamageArea).Append(" slow=").Append(antiSlowArea)
				.Append(" grav=")
				.Append(antiGravityArea)
				.ToString();
		}
	}

	[Serializable]
	internal class _0024activateMmpcSetColiYarare_0024locals_002414342
	{
		internal bool _0024b;
	}

	[Serializable]
	internal class _0024setMmpcSetColiYarareLayer_0024locals_002414343
	{
		internal int _0024layer;
	}

	[Serializable]
	internal class _0024setMmpcSetAttackColiLayer_0024locals_002414344
	{
		internal int _0024layer;
	}

	[Serializable]
	internal class _0024changeMmpc_0024locals_002414345
	{
		internal bool _0024withEffect;
	}

	[Serializable]
	internal class _0024setBodyLayer_0024locals_002414346
	{
		internal int _0024layer;
	}

	[Serializable]
	internal class _0024SOUND_0024locals_002414347
	{
		internal string _0024soundName;
	}

	[Serializable]
	internal class _0024MOTMOV_SCALE_0024locals_002414348
	{
		internal float _0024scale;
	}

	[Serializable]
	internal class _0024HIDE_MESH_0024locals_002414349
	{
		internal string _0024lowName;
	}

	[Serializable]
	internal class _0024activateMmpcSetColiYarare_0024closure_00242871
	{
		internal _0024activateMmpcSetColiYarare_0024locals_002414342 _0024_0024locals_002414787;

		public _0024activateMmpcSetColiYarare_0024closure_00242871(_0024activateMmpcSetColiYarare_0024locals_002414342 _0024_0024locals_002414787)
		{
			this._0024_0024locals_002414787 = _0024_0024locals_002414787;
		}

		public void Invoke(Collider c)
		{
			c.gameObject.SetActive(_0024_0024locals_002414787._0024b);
		}
	}

	[Serializable]
	internal class _0024setMmpcSetColiYarareLayer_0024closure_00242872
	{
		internal _0024setMmpcSetColiYarareLayer_0024locals_002414343 _0024_0024locals_002414788;

		public _0024setMmpcSetColiYarareLayer_0024closure_00242872(_0024setMmpcSetColiYarareLayer_0024locals_002414343 _0024_0024locals_002414788)
		{
			this._0024_0024locals_002414788 = _0024_0024locals_002414788;
		}

		public void Invoke(Collider c)
		{
			c.gameObject.layer = _0024_0024locals_002414788._0024layer;
		}
	}

	[Serializable]
	internal class _0024setMmpcSetAttackColiLayer_0024closure_00242873
	{
		internal _0024setMmpcSetAttackColiLayer_0024locals_002414344 _0024_0024locals_002414789;

		public _0024setMmpcSetAttackColiLayer_0024closure_00242873(_0024setMmpcSetAttackColiLayer_0024locals_002414344 _0024_0024locals_002414789)
		{
			this._0024_0024locals_002414789 = _0024_0024locals_002414789;
		}

		public void Invoke(Collider c)
		{
			c.gameObject.layer = _0024_0024locals_002414789._0024layer;
		}
	}

	[Serializable]
	internal class _0024changeMmpc_0024_init_00242893
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416761 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal int _0024i_002416762;

				internal int _0024i_002416763;

				internal MerlinMotionPackControl _0024m_002416764;

				internal MerlinActionMMPCSet _0024mset_002416765;

				internal PlayerControl _0024player_002416766;

				internal GameObject _0024prefab_002416767;

				internal int _0024_00248450_002416768;

				internal int _0024_00248451_002416769;

				internal int _0024_00248452_002416770;

				internal int _0024_00248453_002416771;

				internal MerlinActionMMPCSet[] _0024ms_002416772;

				internal int _0024startIdx_002416773;

				internal _0024changeMmpc_0024_init_00242893 _0024self__002416774;

				public _0024(MerlinActionMMPCSet[] ms, int startIdx, _0024changeMmpc_0024_init_00242893 self_)
				{
					_0024ms_002416772 = ms;
					_0024startIdx_002416773 = startIdx;
					_0024self__002416774 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024self__002416774._0024this_002414790.isBusyToChange = true;
						_0024_00248450_002416768 = 0;
						_0024_00248451_002416769 = _0024ms_002416772.Length;
						if (_0024_00248451_002416769 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						goto IL_00ad;
					case 2:
					{
						MerlinActionMMPCSet[] array3 = _0024ms_002416772;
						if (!array3[RuntimeServices.NormalizeArrayIndex(array3, _0024i_002416762)].mmpc.Initialized)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_00ad;
					}
					case 3:
					{
						_0024_00248452_002416770 = 0;
						_0024_00248453_002416771 = _0024ms_002416772.Length;
						if (_0024_00248453_002416771 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (_0024_00248452_002416770 < _0024_00248453_002416771)
						{
							_0024i_002416763 = _0024_00248452_002416770;
							_0024_00248452_002416770++;
							MerlinActionMMPCSet[] array = _0024ms_002416772;
							_0024m_002416764 = array[RuntimeServices.NormalizeArrayIndex(array, _0024i_002416763)].mmpc;
							if (!(_0024m_002416764 == null))
							{
								_0024m_002416764.enabled = _0024i_002416763 == _0024startIdx_002416773;
							}
						}
						MerlinActionMMPCSet[] array2 = _0024ms_002416772;
						_0024mset_002416765 = array2[RuntimeServices.NormalizeArrayIndex(array2, _0024startIdx_002416773)];
						_0024self__002416774._0024this_002414790.playAnimationByType(PlayerAnimationTypes.Idle);
						_0024self__002416774._0024this_002414790.isBusyToChange = false;
						_0024player_002416766 = PlayerControl.CurrentPlayer;
						_0024self__002416774._0024this_002414790.setTemporaryElement(_0024mset_002416765.element);
						if (_0024self__002416774._0024_0024locals_002414791._0024withEffect && _0024player_002416766 != null)
						{
							_0024prefab_002416767 = _0024player_002416766.helixHealing;
							if (_0024prefab_002416767 != null)
							{
								UnityEngine.Object.Instantiate(_0024prefab_002416767, _0024self__002416774._0024this_002414790.transform.position, Quaternion.identity);
							}
						}
						YieldDefault(1);
						goto case 1;
					}
					case 1:
						{
							result = 0;
							break;
						}
						IL_00ad:
						if (_0024_00248450_002416768 < _0024_00248451_002416769)
						{
							_0024i_002416762 = _0024_00248450_002416768;
							_0024_00248450_002416768++;
							goto case 2;
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					return (byte)result != 0;
				}
			}

			internal MerlinActionMMPCSet[] _0024ms_002416775;

			internal int _0024startIdx_002416776;

			internal _0024changeMmpc_0024_init_00242893 _0024self__002416777;

			public _0024Invoke_002416761(MerlinActionMMPCSet[] ms, int startIdx, _0024changeMmpc_0024_init_00242893 self_)
			{
				_0024ms_002416775 = ms;
				_0024startIdx_002416776 = startIdx;
				_0024self__002416777 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024ms_002416775, _0024startIdx_002416776, _0024self__002416777);
			}
		}

		internal MerlinActionControl _0024this_002414790;

		internal _0024changeMmpc_0024locals_002414345 _0024_0024locals_002414791;

		public _0024changeMmpc_0024_init_00242893(MerlinActionControl _0024this_002414790, _0024changeMmpc_0024locals_002414345 _0024_0024locals_002414791)
		{
			this._0024this_002414790 = _0024this_002414790;
			this._0024_0024locals_002414791 = _0024_0024locals_002414791;
		}

		public IEnumerator Invoke(MerlinActionMMPCSet[] ms, int startIdx, int oldIndex)
		{
			return new _0024Invoke_002416761(ms, startIdx, this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024setBodyLayer_0024closure_00243835
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416778 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024setBodyLayer_0024closure_00243835 _0024self__002416779;

				public _0024(_0024setBodyLayer_0024closure_00243835 self_)
				{
					_0024self__002416779 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (_0024self__002416779._0024this_002414792.gameObject.layer == BasicCamera.HiddenLayer)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002416779._0024this_002414792.gameObject.layer = _0024self__002416779._0024_0024locals_002414793._0024layer;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024setBodyLayer_0024closure_00243835 _0024self__002416780;

			public _0024Invoke_002416778(_0024setBodyLayer_0024closure_00243835 self_)
			{
				_0024self__002416780 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002416780);
			}
		}

		internal MerlinActionControl _0024this_002414792;

		internal _0024setBodyLayer_0024locals_002414346 _0024_0024locals_002414793;

		public _0024setBodyLayer_0024closure_00243835(MerlinActionControl _0024this_002414792, _0024setBodyLayer_0024locals_002414346 _0024_0024locals_002414793)
		{
			this._0024this_002414792 = _0024this_002414792;
			this._0024_0024locals_002414793 = _0024_0024locals_002414793;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002416778(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024SOUND_0024closure_00243836
	{
		internal _0024SOUND_0024locals_002414347 _0024_0024locals_002414794;

		internal MerlinActionControl _0024this_002414795;

		public _0024SOUND_0024closure_00243836(_0024SOUND_0024locals_002414347 _0024_0024locals_002414794, MerlinActionControl _0024this_002414795)
		{
			this._0024_0024locals_002414794 = _0024_0024locals_002414794;
			this._0024this_002414795 = _0024this_002414795;
		}

		public void Invoke()
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (instance != null)
			{
				instance.PlaySe(_0024_0024locals_002414794._0024soundName, 0, _0024this_002414795.gameObject.GetInstanceID());
			}
		}
	}

	[Serializable]
	internal class _0024MOTMOV_SCALE_0024closure_00243847
	{
		internal MerlinActionControl _0024this_002414796;

		internal _0024MOTMOV_SCALE_0024locals_002414348 _0024_0024locals_002414797;

		public _0024MOTMOV_SCALE_0024closure_00243847(MerlinActionControl _0024this_002414796, _0024MOTMOV_SCALE_0024locals_002414348 _0024_0024locals_002414797)
		{
			this._0024this_002414796 = _0024this_002414796;
			this._0024_0024locals_002414797 = _0024_0024locals_002414797;
		}

		public void Invoke()
		{
			_0024this_002414796.motionMovementScale = _0024_0024locals_002414797._0024scale;
		}
	}

	[Serializable]
	internal class _0024HIDE_MESH_0024closure_00243851
	{
		internal _0024HIDE_MESH_0024locals_002414349 _0024_0024locals_002414798;

		internal MerlinActionControl _0024this_002414799;

		public _0024HIDE_MESH_0024closure_00243851(_0024HIDE_MESH_0024locals_002414349 _0024_0024locals_002414798, MerlinActionControl _0024this_002414799)
		{
			this._0024_0024locals_002414798 = _0024_0024locals_002414798;
			this._0024this_002414799 = _0024this_002414799;
		}

		public void Invoke()
		{
			_0024this_002414799.activateMesh(_0024_0024locals_002414798._0024lowName, b: false);
		}
	}

	[Serializable]
	internal class _0024HIDE_MESH_0024closure_00243852
	{
		internal MerlinActionControl _0024this_002414800;

		internal _0024HIDE_MESH_0024locals_002414349 _0024_0024locals_002414801;

		public _0024HIDE_MESH_0024closure_00243852(MerlinActionControl _0024this_002414800, _0024HIDE_MESH_0024locals_002414349 _0024_0024locals_002414801)
		{
			this._0024this_002414800 = _0024this_002414800;
			this._0024_0024locals_002414801 = _0024_0024locals_002414801;
		}

		public void Invoke()
		{
			_0024this_002414800.activateMesh(_0024_0024locals_002414801._0024lowName, b: true);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024bonusNoHitRoutine_002416755 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241233_002416756;

			internal float _0024tm_002416757;

			internal MerlinActionControl _0024self__002416758;

			public _0024(float tm, MerlinActionControl self_)
			{
				_0024tm_002416757 = tm;
				_0024self__002416758 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002416758.actionParameters.setNoAttackHit();
					_0024_0024wait_sec_0024temp_00241233_002416756 = _0024tm_002416757;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241233_002416756 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241233_002416756 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416758.actionParameters.resetNoAttackHit();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024tm_002416759;

		internal MerlinActionControl _0024self__002416760;

		public _0024bonusNoHitRoutine_002416755(float tm, MerlinActionControl self_)
		{
			_0024tm_002416759 = tm;
			_0024self__002416760 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024tm_002416759, _0024self__002416760);
		}
	}

	private MerlinMotionPackControl mmpc;

	public MerlinActionMMPCSet[] mmpcSet;

	private int currentMmpcSet;

	private bool isBusyToChange;

	private bool mmpcInitialized;

	private CharacterController charControl;

	private MerlinActionParameters actionParameters;

	private MerlinCharParameters charParameters;

	protected PlayerRaidData raidData;

	public int デバッグ用モンスターマスター番号;

	public Collider[] attackColliders;

	public float デフォ移動速度;

	public ActionSettingsType アクション設定;

	private ActionTypes currentActionTypes;

	private float motionSpeedScale;

	private float temporalMotionSpeedScale;

	public bool dontMove;

	private MovementFlags _movementMode;

	private float charMoveSpeed;

	private bool disablePositionalMovement;

	private Vector3 charMoveDir;

	private float gravity;

	private Vector3 charExtraMovement;

	private Vector3 charVolatileMovement;

	private float movementScale;

	private float motionMovementScale;

	private float dynMotionMovementScale;

	private float moveCommandSpeedScale;

	private Vector3[] updateFramePositions;

	private CharacterPathFinder charPathFinder;

	private bool nowBlockMode;

	private BetterList<Vector3> trajectory;

	private float trajectoryInterval;

	private float trajectoryDistThreshold;

	private float trajectoryTime;

	private bool defaultCommandsEnabled;

	private MerlinActionInput actionInput;

	private bool enableDefalutInputClearEveryFrame;

	private ArrayList commandList;

	private ArrayList unInitializedCommandList;

	private bool _commandBlockMode;

	private RespMonster monsterData;

	private RespPoppet poppetData;

	private IDamageCalcCharData damageCalcCharData;

	public bool enableIkariMode;

	private int lastIkariLevel;

	private string attackLayerName;

	private int startLayer;

	private RespPoppet _temporalMonsterData;

	private ActionCommandAttack _latestAttackCommand;

	private ActionCommandEffect lastEntriedEffectCommand;

	private ActionCommandTargetting lastEntriedTargettingCommand;

	private bool hasEffectWorldOffset;

	private Vector3 effectWorldOffset;

	private Hashtable _d540Var;

	private float _d540Timer;

	private int[] _attackMotions;

	public bool logging;

	protected PlayerAbnormalStateControl abnormalStateControl;

	protected AbnormalStateLimitter abnormalStateLimitter;

	private BetterList<StateChangeAreaData> inAreaData;

	private BetterList<StateChangeAreaData> lastInAreaData;

	private InAreaStates inAreaStateControl;

	private Collider lastStayingAreaObject;

	private StateChangeAreaData lastStayingAreaObjectData;

	private PlayerSkillEffectControl skillEffectControl;

	private CharSetupTypes setupType;

	private __MerlinActionControl_IkariLevelChanged_0024callable53_00241375_32__ _0024event_0024IkariLevelChanged;

	public MerlinMotionPackControl Mmpc
	{
		get
		{
			if (!mmpcInitialized)
			{
				initMmpc();
			}
			return (!(mmpc != null)) ? null : mmpc;
		}
	}

	public bool IsActionTypeAttack => isActionType(ActionTypes.Attack);

	public bool IsActionTypeYarareOrDead => isActionType(ActionTypes.Yarare);

	public bool IsActionTypeSkill => isActionType(ActionTypes.Skill);

	public MovementFlags movementMode
	{
		get
		{
			return (!dontMove) ? _movementMode : (MovementFlags.NoExtraMove | MovementFlags.NoVolatileMove);
		}
		set
		{
			_movementMode = value;
		}
	}

	public float MoveSpeed
	{
		get
		{
			return charMoveSpeed;
		}
		set
		{
			charMoveSpeed = value;
		}
	}

	public bool DisablePositionalMovement
	{
		get
		{
			return disablePositionalMovement;
		}
		set
		{
			disablePositionalMovement = value;
		}
	}

	public Vector3 MoveDir
	{
		get
		{
			return charMoveDir;
		}
		set
		{
			setMoveDir(value);
		}
	}

	public Vector3 UpdateDeltaPosition => updateFramePositions[0] - updateFramePositions[1];

	public override GameObject TargetChar => null;

	public override PlayerAnimationTypes AnimationTypeIdle => PlayerAnimationTypes.Idle;

	public override PlayerAnimationTypes AnimationTypeRun => PlayerAnimationTypes.Run;

	public bool CommandBlockMode
	{
		get
		{
			return _commandBlockMode;
		}
		set
		{
			_commandBlockMode = value;
		}
	}

	public override bool IsPlayer => false;

	public override bool IsTensi => false;

	public override bool IsAkuma => false;

	public override string CharacterName
	{
		get
		{
			object obj = null;
			if (HasMonsterData)
			{
				MMonsters master = monsterData.Master;
				if (master != null)
				{
					obj = new StringBuilder().Append(master.Name).ToString();
				}
			}
			else if (HasPoppetData)
			{
				MPoppets master2 = poppetData.Master;
				if (master2 != null)
				{
					obj = new StringBuilder().Append(master2.Name).ToString();
				}
			}
			if (obj == null)
			{
				obj = namae;
			}
			object obj2 = obj;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			return (string)obj2;
		}
	}

	public RespMonster MonsterData
	{
		get
		{
			if (monsterData == null)
			{
				if (DebugMonsterMasterId > 0)
				{
					monsterData = RespMonster.FromMasterId(DebugMonsterMasterId);
					if (monsterData == null)
					{
					}
				}
				if (monsterData == null || monsterData.Master == null)
				{
					int mstId = 1;
					string text = name.ToLower();
					int i = 0;
					MMonsters[] all = MMonsters.All;
					for (int length = all.Length; i < length; i = checked(i + 1))
					{
						if (text.StartsWith(all[i].PrefabName.ToLower()))
						{
							mstId = all[i].Id;
							break;
						}
					}
					monsterData = RespMonster.FromMasterId(mstId);
				}
			}
			return monsterData;
		}
		set
		{
			monsterData = value;
			if (monsterData != null)
			{
				setHitPointAndHitPointMax(monsterData.Hp);
				damageCalcCharData = new DamageCalcCharDataMonster((AIControl)this, monsterData);
			}
			abnormalStateLimitter.reset(monsterData);
		}
	}

	public bool HasMonsterData => monsterData != null;

	public RespPoppet PoppetData
	{
		get
		{
			if (poppetData == null)
			{
				poppetData = new RespPoppet(MonsterData);
			}
			return poppetData;
		}
		set
		{
			poppetData = value;
			if (poppetData != null)
			{
				setHitPointAndHitPointMax(poppetData.TotalHP);
				damageCalcCharData = new DamageCalcCharDataMonster((AIControl)this, poppetData);
			}
			abnormalStateLimitter.reset(poppetData);
		}
	}

	public bool HasPoppetData => poppetData != null;

	public MMonsters MonsterMaster => (!HasMonsterData) ? PoppetData.MonsterMaster : MonsterData.Master;

	public int IKARI_LEVEL
	{
		get
		{
			MMonsters mMonsters = null;
			if (!HasMonsterData && !HasPoppetData)
			{
				RespMonster respMonster = MonsterData;
				if (respMonster == null || respMonster.Master == null)
				{
					throw new AssertionFailedException("(md != null) and (md.Master != null)");
				}
				mMonsters = respMonster.Master;
			}
			else
			{
				mMonsters = ((!HasMonsterData) ? PoppetData.MonsterMaster : MonsterData.Master);
			}
			if (mMonsters == null)
			{
				throw new AssertionFailedException(new StringBuilder("MMonsters が取得できない ").Append(gameObject).ToString());
			}
			return mMonsters.ikariLevel(checked((int)(HitPointRate * 100f)));
		}
	}

	public int AttackLayer => LayerMask.NameToLayer(attackLayerName);

	public ActionCommandAttack ActiveAttack
	{
		get
		{
			IEnumerator enumerator = commandList.GetEnumerator();
			object result;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is ActCommand))
					{
						obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
					}
					ActCommand actCommand = (ActCommand)obj;
					if (actCommand is ActionCommandAttack)
					{
						result = actCommand as ActionCommandAttack;
						break;
					}
					continue;
				}
				result = null;
				break;
			}
			return (ActionCommandAttack)result;
		}
	}

	public int CurrentBodyLayer => gameObject.layer;

	protected RespPoppet TemporalPoppetData
	{
		get
		{
			if (_temporalMonsterData == null && HasMonsterData)
			{
				_temporalMonsterData = new RespPoppet(MonsterData);
			}
			return _temporalMonsterData;
		}
	}

	public EnumRares RARITY => HasMonsterData ? ((EnumRares)MonsterData.Rare.Id) : ((!HasPoppetData) ? EnumRares.normal : ((EnumRares)PoppetData.Rare.Id));

	public int MONSTER_ONLY => HasMonsterData ? 100 : 0;

	public int POPPET_ONLY => HasPoppetData ? 100 : 0;

	protected ActionCommandAttack LatestAttackCommand => _latestAttackCommand;

	public AttackDamageActors MySide => (this is PlayerControl) ? AttackDamageActors.PLAYER : ((!HasPoppetData) ? AttackDamageActors.MONSTER : AttackDamageActors.POPPET);

	public bool IsHitCancel => actionParameters.IsHitCancel;

	public bool IS_ANIM_IDLE => isIdle((PlayerAnimationTypes)Mmpc.CurrentAnimType);

	public bool HAS_ATTACK_COMMANDS => hasCommand<ActionCommandAttack>();

	public bool IS_ANIM_ATTACK
	{
		get
		{
			int currentAnimType = Mmpc.CurrentAnimType;
			bool num = currentAnimType == 3;
			if (!num)
			{
				num = currentAnimType == 4;
			}
			if (!num)
			{
				num = currentAnimType == 5;
			}
			if (!num)
			{
				num = currentAnimType == 6;
			}
			if (!num)
			{
				num = currentAnimType == 7;
			}
			if (!num)
			{
				num = currentAnimType == 8;
			}
			if (!num)
			{
				num = currentAnimType == 9;
			}
			if (!num)
			{
				num = currentAnimType == 10;
			}
			if (!num)
			{
				num = currentAnimType == 12;
			}
			return num;
		}
	}

	public bool IS_ANIM_YARARE_DEAD => Mmpc.CurrentAnimType == 13;

	public bool IS_ANIM_RUN => isRun((PlayerAnimationTypes)Mmpc.CurrentAnimType);

	public bool IS_END_OF_MOTION => Mmpc.IsEndOfMotion;

	public PlayerAnimationTypes NOW_ANIM => (PlayerAnimationTypes)Mmpc.CurrentAnimType;

	public int RAND100 => UnityEngine.Random.Range(0, 100);

	public float RAND => UnityEngine.Random.value;

	public float DELTATIME => Time.deltaTime;

	public float MOTIONTIME => Mmpc.MotionTime;

	public Vector3 RANDXZ
	{
		get
		{
			float x = UnityEngine.Random.Range(-1f, 1f);
			float z = UnityEngine.Random.Range(-1f, 1f);
			return new Vector3(x, 0f, z);
		}
	}

	public Vector3 MYPOS => transform.position;

	public Hashtable VAR
	{
		get
		{
			if (_d540Var == null)
			{
				_d540Var = new Hashtable();
			}
			return _d540Var;
		}
	}

	public float TIMER
	{
		get
		{
			return _d540Timer;
		}
		set
		{
			_d540Timer = value;
		}
	}

	public bool IS_ELITE => HasMonsterData && monsterData.IsElite;

	public bool IS_BOSS => HasMonsterData && monsterData.IsBoss;

	public int TENSHIN_NO => CurrentMmpcSet;

	public float YANG => transform.rotation.y;

	public EnumElements CurrentElement => HasMonsterData ? ((EnumElements)monsterData.Element.Id) : (HasPoppetData ? ((EnumElements)poppetData.ElementId) : ((EnumElements)0));

	public bool IS_FIRE => CurrentElement == EnumElements.fire;

	public bool IS_WATER => CurrentElement == EnumElements.water;

	public bool IS_EARTH => CurrentElement == EnumElements.earth;

	public bool IS_WIND => CurrentElement == EnumElements.wind;

	public PlayerAbnormalStateControl.StateParams AbnormalStateParams => abnormalStateControl.Params;

	public bool HasAnyAbnormalState
	{
		get
		{
			bool num = abnormalStateControl != null;
			if (num)
			{
				num = abnormalStateControl.HasAnyAbnormalState;
			}
			return num;
		}
	}

	public bool IsSimpleAttackAbnormalState => abnormalStateControl.IsSimpleAttack;

	public bool IsMonsterBlindedAbnormalState => abnormalStateControl.IsMonsterBlinded;

	public bool IsChainDisabledByAbnormalState => abnormalStateControl.Params.disableChain;

	public bool IsSkillDisabledByAbnormalState => abnormalStateControl.Params.disableSkill;

	public bool IsMoveDisabledByAbnormalState => abnormalStateControl.Params.disableMove;

	public bool IsAttackDisabledByAbnormalState => abnormalStateControl.Params.disableAttack;

	protected Vector3 InAreaStateExtraMovementOfFixedUpdate => inAreaStateControl.gravMov * Time.fixedDeltaTime;

	public SkillEffectData SkillEffect => skillEffectControl.CurrentData;

	public bool IsBareSetup => setupType == CharSetupTypes.Bare;

	public bool IsColosseumSetup => setupType == CharSetupTypes.Colosseum;

	public int CurrentMmpcSet => currentMmpcSet;

	public bool IsBusyToChange => isBusyToChange;

	public CharacterController CharControl => charControl;

	public MerlinActionParameters ActionParameters => actionParameters;

	public MerlinCharParameters CharParameters => charParameters;

	public PlayerRaidData RaidData => raidData;

	public int DebugMonsterMasterId => デバッグ用モンスターマスター番号;

	public float DefaultMoveSpeed
	{
		get
		{
			return デフォ移動速度;
		}
		set
		{
			デフォ移動速度 = value;
		}
	}

	public ActionSettingsType ActionSettings => アクション設定;

	public ActionTypes CurrentActionTypes => currentActionTypes;

	public float MotionSpeedScale
	{
		get
		{
			return motionSpeedScale;
		}
		set
		{
			motionSpeedScale = value;
		}
	}

	public float TemporalMotionSpeedScale
	{
		get
		{
			return temporalMotionSpeedScale;
		}
		set
		{
			temporalMotionSpeedScale = value;
		}
	}

	public float Gravity
	{
		get
		{
			return gravity;
		}
		set
		{
			gravity = value;
		}
	}

	public Vector3 ExtraMovement => charExtraMovement;

	public Vector3 CharVolatileMovement => charVolatileMovement;

	public float MovementScale
	{
		get
		{
			return movementScale;
		}
		set
		{
			movementScale = value;
		}
	}

	public float MoveCommandSpeedScale
	{
		get
		{
			return moveCommandSpeedScale;
		}
		set
		{
			moveCommandSpeedScale = value;
		}
	}

	public CharacterPathFinder CharPathFinder
	{
		get
		{
			return charPathFinder;
		}
		set
		{
			charPathFinder = value;
		}
	}

	public BetterList<Vector3> Trajectory => trajectory;

	public float TrajectoryInterval
	{
		get
		{
			return trajectoryInterval;
		}
		set
		{
			trajectoryInterval = value;
		}
	}

	public float TrajectoryDistThreshold
	{
		get
		{
			return trajectoryDistThreshold;
		}
		set
		{
			trajectoryDistThreshold = value;
		}
	}

	public bool DefaultCommandsEnabled
	{
		get
		{
			return defaultCommandsEnabled;
		}
		set
		{
			defaultCommandsEnabled = value;
		}
	}

	public MerlinActionInput ActionInput => actionInput;

	public bool EnableDefalutInputClearEveryFrame
	{
		get
		{
			return enableDefalutInputClearEveryFrame;
		}
		set
		{
			enableDefalutInputClearEveryFrame = value;
		}
	}

	public ArrayList CommandList => commandList;

	public IDamageCalcCharData DamageCalcCharData
	{
		get
		{
			return damageCalcCharData;
		}
		set
		{
			damageCalcCharData = value;
		}
	}

	public bool EnableIkariMode
	{
		get
		{
			return enableIkariMode;
		}
		set
		{
			enableIkariMode = value;
		}
	}

	public string AttackLayerName => attackLayerName;

	public ActionCommandEffect LastEntriedEffectCommand => lastEntriedEffectCommand;

	public bool HasEffectWorldOffset => hasEffectWorldOffset;

	public Vector3 EffectWorldOffset => effectWorldOffset;

	public PlayerAbnormalStateControl AbnormalStateControl => abnormalStateControl;

	public AbnormalStateLimitter AbnormalStateLimitter => abnormalStateLimitter;

	public BetterList<StateChangeAreaData> LastInAreaData => lastInAreaData;

	public InAreaStates InAreaStateControl => inAreaStateControl;

	public Collider LastStayingAreaObject => lastStayingAreaObject;

	public StateChangeAreaData LastStayingAreaObjectData => lastStayingAreaObjectData;

	public PlayerSkillEffectControl SkillEffectControl => skillEffectControl;

	public CharSetupTypes SetupType => setupType;

	public event __MerlinActionControl_IkariLevelChanged_0024callable53_00241375_32__ IkariLevelChanged
	{
		add
		{
			_0024event_0024IkariLevelChanged = (__MerlinActionControl_IkariLevelChanged_0024callable53_00241375_32__)Delegate.Combine(_0024event_0024IkariLevelChanged, value);
		}
		remove
		{
			_0024event_0024IkariLevelChanged = (__MerlinActionControl_IkariLevelChanged_0024callable53_00241375_32__)Delegate.Remove(_0024event_0024IkariLevelChanged, value);
		}
	}

	public MerlinActionControl()
	{
		currentMmpcSet = -1;
		actionParameters = new MerlinActionParameters();
		raidData = new PlayerRaidData();
		アクション設定 = new ActionSettingsType();
		motionSpeedScale = 1f;
		temporalMotionSpeedScale = 1f;
		charMoveSpeed = 5f;
		charMoveDir = Vector3.zero;
		gravity = -9.8f;
		charExtraMovement = Vector3.zero;
		charVolatileMovement = Vector3.zero;
		movementScale = 1f;
		motionMovementScale = 1f;
		dynMotionMovementScale = 1f;
		moveCommandSpeedScale = 1f;
		updateFramePositions = new Vector3[3];
		trajectory = new BetterList<Vector3>();
		trajectoryInterval = 1f;
		trajectoryDistThreshold = 1f;
		defaultCommandsEnabled = true;
		actionInput = new MerlinActionInput();
		enableDefalutInputClearEveryFrame = true;
		commandList = new ArrayList();
		unInitializedCommandList = new ArrayList();
		damageCalcCharData = new IDamageCalcCharData();
		enableIkariMode = true;
		attackLayerName = "Default";
		abnormalStateLimitter = new AbnormalStateLimitter();
		inAreaData = new BetterList<StateChangeAreaData>();
		lastInAreaData = new BetterList<StateChangeAreaData>();
		inAreaStateControl = new InAreaStates();
		skillEffectControl = new PlayerSkillEffectControl();
		setupType = CharSetupTypes.Bare;
	}

	protected void activateMmpcSetColiYarare(bool b)
	{
		_0024activateMmpcSetColiYarare_0024locals_002414342 _0024activateMmpcSetColiYarare_0024locals_0024 = new _0024activateMmpcSetColiYarare_0024locals_002414342();
		_0024activateMmpcSetColiYarare_0024locals_0024._0024b = b;
		iterateColiYarare(new _0024activateMmpcSetColiYarare_0024closure_00242871(_0024activateMmpcSetColiYarare_0024locals_0024).Invoke);
	}

	protected void setMmpcSetColiYarareLayer(int layer)
	{
		_0024setMmpcSetColiYarareLayer_0024locals_002414343 _0024setMmpcSetColiYarareLayer_0024locals_0024 = new _0024setMmpcSetColiYarareLayer_0024locals_002414343();
		_0024setMmpcSetColiYarareLayer_0024locals_0024._0024layer = layer;
		iterateColiYarare(new _0024setMmpcSetColiYarareLayer_0024closure_00242872(_0024setMmpcSetColiYarareLayer_0024locals_0024).Invoke);
	}

	protected void setMmpcSetAttackColiLayer(int layer)
	{
		_0024setMmpcSetAttackColiLayer_0024locals_002414344 _0024setMmpcSetAttackColiLayer_0024locals_0024 = new _0024setMmpcSetAttackColiLayer_0024locals_002414344();
		_0024setMmpcSetAttackColiLayer_0024locals_0024._0024layer = layer;
		iterateAttackColis(new _0024setMmpcSetAttackColiLayer_0024closure_00242873(_0024setMmpcSetAttackColiLayer_0024locals_0024).Invoke);
	}

	private void iterateColiYarare(__MerlinActionControl_iterateColiYarare_0024callable52_002458_41__ f)
	{
		if (f == null || mmpcSet == null || mmpcSet.Length <= 0)
		{
			return;
		}
		int i = 0;
		MerlinActionMMPCSet[] array = mmpcSet;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				Collider coliYarare = array[i].coliYarare;
				if (coliYarare != null)
				{
					f(coliYarare);
				}
			}
		}
	}

	private void iterateAttackColis(__MerlinActionControl_iterateColiYarare_0024callable52_002458_41__ f)
	{
		if (f == null || mmpcSet == null || mmpcSet.Length <= 0)
		{
			return;
		}
		int i = 0;
		MerlinActionMMPCSet[] array = mmpcSet;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == null || array[i].attackColliders == null)
				{
					continue;
				}
				int j = 0;
				Collider[] array2 = array[i].attackColliders;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if (array2[j] != null)
					{
						f(array2[j]);
					}
				}
			}
		}
	}

	public virtual RespWeapon getMainWeapon()
	{
		return null;
	}

	public bool isActionType(ActionTypes atype)
	{
		return (currentActionTypes & atype) != 0;
	}

	public void setActionType(ActionTypes atype)
	{
		currentActionTypes |= atype;
	}

	public void clearActionType(ActionTypes atype)
	{
		currentActionTypes &= ~atype;
	}

	public void resetMotionSpeedScale()
	{
		motionSpeedScale = 1f;
		temporalMotionSpeedScale = 1f;
	}

	public void resetTemporalMotionSpeedScale()
	{
		temporalMotionSpeedScale = 1f;
	}

	private void updateMotionSpeedToMMPC()
	{
		if (mmpc != null)
		{
			float num = motionSpeedScale * temporalMotionSpeedScale;
			if (mmpc.TimeScale != num)
			{
				mmpc.TimeScale = num;
			}
		}
	}

	public void disableAllMovementTypes()
	{
		movementMode = (MovementFlags)(-1);
	}

	public void disableGravity()
	{
		movementMode |= MovementFlags.NoGravity;
	}

	public void enableGravity()
	{
		movementMode &= ~MovementFlags.NoGravity;
	}

	public void disableAllMovementTypesWithout(params MovementFlags[] flags)
	{
		movementMode = (MovementFlags)(-1);
		int length = flags.Length;
		int num = 0;
		while (num < length)
		{
			MovementFlags movementFlags = flags[RuntimeServices.NormalizeArrayIndex(flags, checked(num++))];
			movementMode &= ~movementFlags;
		}
	}

	public void disableAllMovementTypesWithoutMotionMove()
	{
		disableAllMovementTypesWithout(MovementFlags.NoMotionBase);
	}

	public void enableAllMovementTypes()
	{
		movementMode = MovementFlags.NoVelocity;
	}

	public void setExtraMovement(Vector3 v)
	{
		charExtraMovement = v;
	}

	public void addVolatileMovement(Vector3 v)
	{
		charVolatileMovement += v;
	}

	public void setMoveDir(Vector3 vel)
	{
		charMoveDir = vel;
	}

	private void clearMovementData()
	{
		charMoveSpeed = 0f;
		charMoveDir = Vector3.zero;
		charExtraMovement = Vector3.zero;
		charVolatileMovement = Vector3.zero;
		movementScale = 1f;
		motionMovementScale = 1f;
		dynMotionMovementScale = 1f;
		moveCommandSpeedScale = 1f;
	}

	private void initMmpc()
	{
		if (mmpcInitialized)
		{
			return;
		}
		if (mmpcSet != null && mmpcSet.Length > 0)
		{
			Boo.Lang.List<MerlinMotionPackControl> list = new Boo.Lang.List<MerlinMotionPackControl>();
			int i = 0;
			MerlinActionMMPCSet[] array = mmpcSet;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				MerlinMotionPackControl merlinMotionPackControl = array[i].mmpc;
				if (!(merlinMotionPackControl != null))
				{
					throw new AssertionFailedException(new StringBuilder("mmpcSet に null が含まれている ").Append(gameObject).ToString());
				}
				if (list.Contains(merlinMotionPackControl))
				{
					throw new AssertionFailedException(new StringBuilder("mmpcSet に同一MMPCが２つ以上ある ").Append(gameObject).ToString());
				}
				list.Add(merlinMotionPackControl);
				setupMMPC(merlinMotionPackControl);
			}
			changeMmpc(0);
		}
		else
		{
			mmpc = GetComponent<MerlinMotionPackControl>();
			if (!(mmpc != null))
			{
				throw new AssertionFailedException("MMPC が貼られていない！");
			}
			setupMMPC(mmpc);
		}
		mmpcInitialized = true;
	}

	public void changeMmpc(int index)
	{
		changeMmpc(index, withEffect: false);
	}

	public void changeMmpc(int index, bool withEffect)
	{
		_0024changeMmpc_0024locals_002414345 _0024changeMmpc_0024locals_0024 = new _0024changeMmpc_0024locals_002414345();
		_0024changeMmpc_0024locals_0024._0024withEffect = withEffect;
		if (index >= 0 && !(mmpcSet == null) && mmpcSet.Length > 0 && index != currentMmpcSet)
		{
			MerlinActionMMPCSet[] array = mmpcSet;
			MerlinActionMMPCSet merlinActionMMPCSet = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (!(merlinActionMMPCSet != null))
			{
				throw new AssertionFailedException("minfo != null");
			}
			__MerlinActionControl_changeMmpc_0024callable130_0024374_13__ _MerlinActionControl_changeMmpc_0024callable130_0024374_13__ = new _0024changeMmpc_0024_init_00242893(this, _0024changeMmpc_0024locals_0024).Invoke;
			mmpc = merlinActionMMPCSet.mmpc;
			attackColliders = merlinActionMMPCSet.attackColliders;
			int oldIndex = currentMmpcSet;
			currentMmpcSet = index;
			IEnumerator enumerator = _MerlinActionControl_changeMmpc_0024callable130_0024374_13__(mmpcSet, index, oldIndex);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public virtual void Awake()
	{
		initMmpc();
		charControl = GetComponent<CharacterController>();
		if (!(charControl != null))
		{
			throw new AssertionFailedException("CharacterController が貼られていない！");
		}
		charParameters = new MerlinCharParameters(Mmpc);
		startLayer = CurrentBodyLayer;
		abnormalStateControl = new PlayerAbnormalStateControl(this);
		skillEffectControl.setParent(this);
	}

	private void setupMMPC(MerlinMotionPackControl _mmpc)
	{
		_mmpc.MotionChanged += delegate(MerlinMotionPackControl me, MerlinMotionPack.Entry entry)
		{
			if (me.enabled)
			{
				mmpc.BaseMovementScale = 1f;
				if (me != null)
				{
					me.enqueueStringToHistory(new StringBuilder().Append((object)Time.frameCount).Append(" motion changed ").Append((entry == null) ? "???" : entry.name)
						.ToString());
				}
				initStateAtMotionChange();
				clearMovementData();
				disposeCommandsAtMotionChange();
				actionInput.clearEveryMotionChange();
				actionParameters.initAtMotionChange();
				doMotionChanged();
				nowBlockMode = CommandBlockMode;
				CommandBlockMode = false;
			}
		};
		_mmpc.MotionChangedAfter += delegate(MerlinMotionPackControl me, MerlinMotionPack.Entry entry)
		{
			if (me.enabled)
			{
				if (me != null)
				{
					me.enqueueStringToHistory(new StringBuilder().Append((object)Time.frameCount).Append(" motion changed after ").Append((entry == null) ? "???" : entry.name)
						.ToString());
				}
				CommandBlockMode = nowBlockMode;
				initActionTypes();
				setRejectModeByActionType();
				addDefaultCommands();
				setOtherDefaultValues();
				doMotionChangedAfter();
			}
		};
	}

	protected virtual void doMotionChanged()
	{
	}

	protected virtual void doMotionChangedAfter()
	{
		float movementSpeedScaleByAbnormalState = getMovementSpeedScaleByAbnormalState();
		MovementScale = movementSpeedScaleByAbnormalState;
	}

	public virtual void Start()
	{
	}

	public override void Update()
	{
		if (Mmpc == null || Pause)
		{
			return;
		}
		base.Update();
		updateMotionSpeedToMMPC();
		resetTemporalMotionSpeedScale();
		execCommand();
		if (EnableDefalutInputClearEveryFrame)
		{
			actionInput.clearEveryFrame();
		}
		int length = updateFramePositions.Length;
		Array.Copy(updateFramePositions, 0, updateFramePositions, 1, checked(length - 1));
		ref Vector3 reference = ref updateFramePositions[0];
		reference = transform.position;
		updateTrajectory();
		if (enableIkariMode && (HasMonsterData || HasPoppetData))
		{
			int iKARI_LEVEL = IKARI_LEVEL;
			if (iKARI_LEVEL != lastIkariLevel)
			{
				lastIkariLevel = iKARI_LEVEL;
				raise_IkariLevelChanged(this, iKARI_LEVEL);
			}
		}
		updateAbnormalStateLimitter(Time.deltaTime);
		_d540Timer += Time.deltaTime;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		if (Mmpc != null)
		{
			destroyAllCommands();
		}
		abnormalStateControl = null;
		skillEffectControl = null;
	}

	public override void FixedUpdate()
	{
		if (!(Mmpc == null) && !Pause)
		{
			base.FixedUpdate();
			float num = ((!DisablePositionalMovement) ? movementScale : 0f);
			charMoveDir = limitMovementIfAbnormalState(charMoveDir);
			float num2 = Mmpc.FixedUpdateDeltaTime;
			Vector3 zero = Vector3.zero;
			if ((movementMode & MovementFlags.NoMotionBase) == 0)
			{
				zero += Mmpc.FixedTranslationDelta * num * motionMovementScale * dynMotionMovementScale;
			}
			if ((movementMode & MovementFlags.NoVelocity) == 0)
			{
				zero += charMoveDir.normalized * charMoveSpeed * num2 * num;
			}
			if ((movementMode & MovementFlags.NoExtraMove) == 0)
			{
				zero += charExtraMovement * Mmpc.DeltaTimeRate * num;
			}
			if ((movementMode & MovementFlags.NoVolatileMove) == 0)
			{
				zero += charVolatileMovement * Mmpc.DeltaTimeRate;
			}
			if ((movementMode & MovementFlags.NoGravity) == 0)
			{
				zero += Vector3.up * gravity * num2;
			}
			if (charControl.enabled)
			{
				charControl.Move(zero);
			}
			charVolatileMovement = Vector3.zero;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		SkillEffectData currentData = SkillEffectControl.CurrentData;
		AntiAreaDamages antiState = new AntiAreaDamages(currentData.invalidateDamageArea, currentData.invalidateSlowArea, currentData.invalidateGravityArea);
		addAreaDamageDataOnTriggerStay(other, antiState);
	}

	public void clearTrajectory()
	{
		trajectory = new BetterList<Vector3>();
		trajectoryInterval = 1f;
		trajectoryDistThreshold = 1f;
		trajectoryTime = 0f;
	}

	private void updateTrajectory()
	{
		trajectoryTime += Time.deltaTime;
		if (trajectoryTime < trajectoryInterval)
		{
			return;
		}
		trajectoryTime = 0f;
		Vector3 position = transform.position;
		if (!(trajectoryDistThreshold <= 0f))
		{
			float num = float.MaxValue;
			IEnumerator<Vector3> enumerator = trajectory.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Vector3 current = enumerator.Current;
					num = Math.Min(num, (current - position).magnitude);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			if (!(num <= trajectoryDistThreshold))
			{
				trajectory.Add(position);
			}
		}
		else
		{
			trajectory.Add(position);
		}
		while (trajectory.size > 64)
		{
			trajectory.RemoveAt(0);
		}
	}

	private void initStateAtMotionChange()
	{
		bool flag = false;
		superArmor = false;
		setLatestAttackCommand(null);
		lastEntriedEffectCommand = null;
		lastEntriedTargettingCommand = null;
	}

	private ActionCommandTargetting targetCommand()
	{
		ActionCommandTargetting result;
		if (lastEntriedTargettingCommand != null)
		{
			result = lastEntriedTargettingCommand;
		}
		else
		{
			ActionCommandTargetting actionCommandTargetting = (lastEntriedTargettingCommand = new ActionCommandTargetting());
			addCommand(actionCommandTargetting);
			result = actionCommandTargetting;
		}
		return result;
	}

	private void initActionTypes()
	{
		currentActionTypes = (ActionTypes)0;
		string[] currentKeywords = Mmpc.CurrentKeywords;
		if (currentKeywords != null)
		{
			string[] array = currentKeywords;
			int length = array.Length;
			int num = 0;
			while (num < length)
			{
				switch (array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))])
				{
				case "idle":
					setActionType(ActionTypes.Idle);
					break;
				case "run":
					setActionType(ActionTypes.Moving);
					break;
				case "attack":
					setActionType(ActionTypes.Attack);
					break;
				case "dead":
					setActionType(ActionTypes.Dead);
					break;
				case "yarare":
					setActionType(ActionTypes.Yarare);
					break;
				case "event":
					setActionType(ActionTypes.Event);
					break;
				case "skill":
					setActionType(ActionTypes.Skill);
					break;
				}
			}
		}
		int currentAnimType = Mmpc.CurrentAnimType;
		if (currentAnimType == 0 || currentAnimType == 19)
		{
			setActionType(ActionTypes.Idle);
			Mmpc.setLoopMode(loop: true);
		}
		if (currentAnimType == 1 || currentAnimType == 20)
		{
			setActionType(ActionTypes.Moving);
			Mmpc.setLoopMode(loop: true);
		}
		if (currentAnimType == 13)
		{
			setActionType(ActionTypes.Dead);
			Mmpc.setLoopMode(loop: false);
		}
		if (currentAnimType == 13 || currentAnimType == 14 || currentAnimType == 15 || currentAnimType == 16)
		{
			setActionType(ActionTypes.Yarare);
		}
		if (currentAnimType == 13 || currentAnimType == 14)
		{
			setActionType(ActionTypes.Down);
		}
		if (currentAnimType == 3 || currentAnimType == 4 || currentAnimType == 5 || currentAnimType == 6 || currentAnimType == 7 || currentAnimType == 8 || currentAnimType == 9 || currentAnimType == 10 || currentAnimType == 12)
		{
			setActionType(ActionTypes.Attack);
		}
		if (currentAnimType == 11)
		{
			setActionType(ActionTypes.Kaihi);
		}
	}

	private void setRejectModeByActionType()
	{
		if (isActionType(ActionTypes.Dead))
		{
			setRejectMode();
		}
	}

	protected void setRejectMode()
	{
	}

	protected void unsetRejectMode()
	{
	}

	private void setOtherDefaultValues()
	{
		if (!isActionType(ActionTypes.Moving))
		{
			return;
		}
		MoveSpeed = DefaultMoveSpeed;
		if (HasMonsterData && IS_ELITE)
		{
			MMonsters master = monsterData.Master;
			if (master != null)
			{
				movementScale = master.EliteSpeedMult;
			}
		}
	}

	private void addDefaultCommands()
	{
		if (defaultCommandsEnabled && (!Mmpc.isInCurrentKeywords("nodef") || ignoreNODEF()))
		{
			doAddDefaultCommands();
		}
	}

	protected virtual bool ignoreNODEF()
	{
		return false;
	}

	protected virtual void doAddDefaultCommands()
	{
		Mmpc.enqueueStringToHistory(new StringBuilder("addDefaultCommands: ").Append(gameObject).ToString());
		doAddDefaultCommandMove();
		doAddDefaultCommandRunningShift();
		doAddDefaultCommandDefaultNEXT();
		doAddDefaultCommandTargettingCommands();
		doAddDefaultCommandDead();
	}

	protected virtual void doAddDefaultCommandMove()
	{
		if (isActionType(ActionTypes.Idle) || isActionType(ActionTypes.Moving))
		{
			addCommandIgnoreBlockMode(doCreateCancel(0f));
		}
	}

	protected virtual ActCommand doCreateCancel(float startTime)
	{
		return new ActionDefaultShiftCommand(startTime);
	}

	protected virtual ActCommand doCreateMovingControl()
	{
		return new ActionCommandMovingControl();
	}

	protected virtual void doAddDefaultCommandRunningShift()
	{
		if (isActionType(ActionTypes.Moving))
		{
			addCommandIgnoreBlockMode(doCreateMovingControl());
			addCommandIgnoreBlockMode(new ActionCommandAttackShift(1, MotionID.ByType(12)));
		}
	}

	protected virtual void doAddDefaultCommandDefaultNEXT()
	{
		if (!hasCommand<ActionCommandNext>() && !isActionType(ActionTypes.Dead))
		{
			addCommandIgnoreBlockMode(new ActionCommandNext(PlayerAnimationTypes.Idle));
		}
	}

	protected virtual void doAddDefaultCommandTargettingCommands()
	{
		if (hasCommand<ActionCommandTargetting>())
		{
			return;
		}
		if (isActionType(ActionTypes.Moving))
		{
			addCommandIgnoreBlockMode(new ActionCommandTargetting());
		}
		else
		{
			if (!isActionType(ActionTypes.Attack))
			{
				return;
			}
			ActionCommandAttack[] array = collectAttackCommands();
			if (array.Length <= 0)
			{
				return;
			}
			ActionCommandAttack actionCommandAttack = array[0];
			ActionCommandAttack[] array2 = array;
			int length = array2.Length;
			int num = 0;
			while (num < length)
			{
				ActionCommandAttack actionCommandAttack2 = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num++))];
				if (!(actionCommandAttack.startTime <= actionCommandAttack2.startTime))
				{
					actionCommandAttack2 = actionCommandAttack;
				}
			}
			addCommandIgnoreBlockMode(new ActionCommandTargetting(0f, actionCommandAttack.startTime));
		}
	}

	protected virtual void doAddDefaultCommandDead()
	{
	}

	public void d540_motdef(MotDefParam p)
	{
		if (!(Mmpc != null))
		{
		}
	}

	public void inputIdle()
	{
		actionInput.idle();
	}

	public void inputMoveTo(GameObject targetObject)
	{
		if (!(targetObject == null))
		{
			actionInput.move(targetObject);
		}
	}

	public void inputMove()
	{
		actionInput.move(transform.position);
	}

	public void inputMoveToPos(Vector3 pos)
	{
		actionInput.move(pos);
	}

	public void inputAttack(int attackNo)
	{
		if (this is AIControl && IsSimpleAttackAbnormalState)
		{
			attackNo = 1;
		}
		actionInput.attack(attackNo);
	}

	public void disableInput()
	{
		actionInput.enable(b: false);
	}

	public void enableInput()
	{
		actionInput.enable(b: true);
	}

	public MerlinMotionPackControl.Command playAnimation(PlayerAnimationTypes motType)
	{
		return playAnimationByType(motType);
	}

	public MerlinMotionPackControl.Command playAnimationByType(PlayerAnimationTypes motType)
	{
		return playAnimationByType(motType, crossFadeIfNeed: true);
	}

	public MerlinMotionPackControl.Command playAnimationByType(PlayerAnimationTypes motType, bool crossFadeIfNeed)
	{
		float fadeTime = ((!IS_ANIM_IDLE && !IS_ANIM_RUN) ? 0f : 0.1f);
		if (!crossFadeIfNeed)
		{
			fadeTime = 0f;
		}
		PlayerAnimationTypes typeID = motType;
		if (isIdle(motType))
		{
			typeID = AnimationTypeIdle;
		}
		else if (isRun(motType))
		{
			typeID = AnimationTypeRun;
		}
		MerlinMotionPackControl.PlayReq req = new MerlinMotionPackControl.PlayReq((int)typeID, null, fadeTime);
		return playAnimationByReq(req);
	}

	public MerlinMotionPackControl.Command playAnimationByReq(MerlinMotionPackControl.PlayReq req)
	{
		return CommandBlockMode ? null : ((!(Mmpc == null)) ? Mmpc.playByReq(req) : null);
	}

	public MerlinMotionPackControl.Command playAnimationByName(string motName)
	{
		return CommandBlockMode ? null : ((!(Mmpc == null)) ? Mmpc.playByName(motName) : null);
	}

	public MerlinMotionPackControl.Command playAnimation(string motName)
	{
		deberr(new StringBuilder("invoked playAnimation(motName=").Append(motName).Append(")").ToString());
		return playAnimationByName(motName);
	}

	public MerlinMotionPackControl.Command playAnimation(MotionID motId)
	{
		return motId.notValid ? null : ((!motId.hasMotionName) ? playAnimationByType((PlayerAnimationTypes)motId.motionType) : playAnimationByName(motId.motionName));
	}

	public bool isRun(PlayerAnimationTypes type)
	{
		bool num = type == PlayerAnimationTypes.Run;
		if (!num)
		{
			num = type == PlayerAnimationTypes.EvRun;
		}
		return num;
	}

	public bool isIdle(PlayerAnimationTypes type)
	{
		bool num = type == PlayerAnimationTypes.Idle;
		if (!num)
		{
			num = type == PlayerAnimationTypes.EvIdle;
		}
		return num;
	}

	public bool isAnimType(PlayerAnimationTypes t)
	{
		return Mmpc.CurrentAnimType == (int)t;
	}

	public void addMotEndJob(ICallable c)
	{
		ActCommandWithHandler actCommandWithHandler = new ActCommandWithHandler();
		actCommandWithHandler.doDisposeHandler = c;
		addCommand(actCommandWithHandler);
	}

	private void initAllUninitializedCommands()
	{
		IEnumerator enumerator = unInitializedCommandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			actCommand.doInit();
		}
		unInitializedCommandList.Clear();
	}

	public void disposeCommandsAtMotionChange()
	{
		initAllUninitializedCommands();
		IEnumerator enumerator = commandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			if (actCommand.DisposeAtMotionChange)
			{
				actCommand.doDispose();
			}
		}
		int num = 0;
		while (num < commandList.Count)
		{
			ActCommand actCommand2 = commandList[num] as ActCommand;
			if (actCommand2.DisposeAtMotionChange)
			{
				commandList.RemoveAt(num);
			}
			else
			{
				num = checked(num + 1);
			}
		}
	}

	public void destroyAllCommands()
	{
		initAllUninitializedCommands();
		IEnumerator enumerator = commandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			actCommand.doDispose();
		}
		commandList.Clear();
	}

	public void disposeCommands(Type t)
	{
		IEnumerator enumerator = commandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			if (RuntimeServices.EqualityOperator(actCommand.GetType(), t))
			{
				actCommand.doDispose();
			}
		}
		int num = 0;
		while (num < commandList.Count)
		{
			ActCommand actCommand2 = commandList[num] as ActCommand;
			if (RuntimeServices.EqualityOperator(actCommand2.GetType(), t))
			{
				commandList.RemoveAt(num);
			}
			else
			{
				num = checked(num + 1);
			}
		}
	}

	private void execCommand()
	{
		if (Mmpc == null)
		{
			return;
		}
		float motionTime = Mmpc.MotionTime;
		initAllUninitializedCommands();
		IEnumerator enumerator = commandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			if (actCommand.UpdateWithWorldTime)
			{
				actCommand.WorldTime += Time.deltaTime;
				actCommand.doUpdate(actCommand.WorldTime);
			}
			else
			{
				actCommand.doUpdate(motionTime);
			}
			if (actCommand.IsDead)
			{
				actCommand.doDispose();
			}
		}
	}

	public bool addCommand(ActCommand cmd)
	{
		return addCommand(cmd, ignoreBlockMode: false);
	}

	public bool addCommandIgnoreBlockMode(ActCommand cmd)
	{
		return addCommand(cmd, ignoreBlockMode: true);
	}

	public bool addCommand(ActCommand cmd, bool ignoreBlockMode)
	{
		int result;
		if (cmd == null)
		{
			result = 0;
		}
		else
		{
			if (CommandBlockMode && !ignoreBlockMode)
			{
				deblog("ignored command: type=" + cmd.GetType() + "  cmd=" + cmd);
			}
			else
			{
				if (!(cmd.parent == null))
				{
					throw new AssertionFailedException(new StringBuilder("ActCommandが別のキャラ(").Append(cmd.parent).Append(")のじゃない？ cmd:").Append(cmd)
						.ToString());
				}
				cmd.parent = this;
				commandList.Add(cmd);
				unInitializedCommandList.Add(cmd);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool hasCommand<T>() where T : ActCommand
	{
		IEnumerator enumerator = commandList.GetEnumerator();
		int result;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is ActCommand))
				{
					obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
				}
				ActCommand actCommand = (ActCommand)obj;
				if (actCommand is T)
				{
					result = 1;
					break;
				}
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public ActionCommandAttack[] collectAttackCommands()
	{
		Boo.Lang.List<ActionCommandAttack> list = new Boo.Lang.List<ActionCommandAttack>();
		IEnumerator enumerator = commandList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is ActCommand))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ActCommand));
			}
			ActCommand actCommand = (ActCommand)obj;
			if (actCommand is ActionCommandAttack item)
			{
				list.Add(item);
			}
		}
		return (ActionCommandAttack[])Builtins.array(typeof(ActionCommandAttack), list);
	}

	public virtual bool isAStyle(MStyles style)
	{
		return false;
	}

	public virtual bool isAnElement(MElements e)
	{
		return HasMonsterData ? RuntimeServices.EqualityOperator(MonsterData.Element, e) : (HasPoppetData && RuntimeServices.EqualityOperator(PoppetData.Element, e));
	}

	[SpecialName]
	protected internal void raise_IkariLevelChanged(MerlinActionControl arg0, int arg1)
	{
		_0024event_0024IkariLevelChanged?.Invoke(arg0, arg1);
	}

	public Collider[] getAttackCollision(AttackPartTypes part)
	{
		object obj;
		if (attackColliders != null && AttackPartTypes.Default <= part && (int)part < attackColliders.Length)
		{
			obj = new Collider[1];
			object obj2 = obj;
			Collider[] array = attackColliders;
			((object[])obj2)[0] = array[RuntimeServices.NormalizeArrayIndex(array, (int)part)];
		}
		else
		{
			obj = null;
		}
		return (Collider[])obj;
	}

	public virtual Collider[] getAttackCollision(string partName)
	{
		return null;
	}

	public void setAttackLayer(string layerName)
	{
		attackLayerName = layerName;
		Collider[] array = attackColliders;
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			Collider myAttackLayer = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			setMyAttackLayer(myAttackLayer);
		}
		setMmpcSetAttackColiLayer(AttackLayer);
	}

	public void setMyAttackLayer(Collider c)
	{
		if (c != null)
		{
			c.gameObject.layer = AttackLayer;
		}
	}

	public void setBodyLayer(string layerName)
	{
		if (!(charControl == null))
		{
			setBodyLayer(LayerMask.NameToLayer(layerName));
		}
	}

	public void setBodyLayer(int layer)
	{
		_0024setBodyLayer_0024locals_002414346 _0024setBodyLayer_0024locals_0024 = new _0024setBodyLayer_0024locals_002414346();
		_0024setBodyLayer_0024locals_0024._0024layer = layer;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024setBodyLayer_0024closure_00243835(this, _0024setBodyLayer_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void setBodyLayerPlayer()
	{
		setBodyLayer("CHR_RAID");
	}

	public void setBodyLayerEnemy()
	{
		setBodyLayer("CHR");
	}

	public void setBodyLayerNoPushOut()
	{
		setBodyLayer("CHR_NOPUSHOUT");
	}

	public void setBodyStartLayer()
	{
		setBodyLayer(startLayer);
	}

	public virtual void effectEmitHandler(GameObject effectObject)
	{
		if (HasPoppetData)
		{
			effectObject.SendMessage("setPoppetMaster", PoppetData.Master, SendMessageOptions.DontRequireReceiver);
		}
		else if (HasMonsterData)
		{
			RespPoppet temporalPoppetData = TemporalPoppetData;
			if (temporalPoppetData != null)
			{
				effectObject.SendMessage("setPoppetMaster", temporalPoppetData.Master, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public override void doPause()
	{
		Mmpc.Pause = true;
		DisablePositionalMovement = true;
	}

	public override void doUnpause()
	{
		Mmpc.Pause = false;
		DisablePositionalMovement = false;
	}

	public Transform standGround(Transform t)
	{
		object[] groundHeight = ObjUtilModule.GetGroundHeight(t);
		float num = 0.08f;
		if (RuntimeServices.ToBool(groundHeight[0]))
		{
			float y = RuntimeServices.UnboxSingle(groundHeight[1]) + num;
			Vector3 position = t.position;
			float num2 = (position.y = y);
			Vector3 vector2 = (t.position = position);
		}
		else
		{
			float y2 = 0f + num;
			Vector3 position2 = t.position;
			float num3 = (position2.y = y2);
			Vector3 vector4 = (t.position = position2);
		}
		return null;
	}

	public void NEXT(MotionID nextMotion)
	{
		ActionCommandNext cmd = new ActionCommandNext(nextMotion);
		addCommand(cmd);
	}

	public void SHIFT_ATK1(MotionID motionID, float start, float end)
	{
		ActionCommandAttackShift cmd = new ActionCommandAttackShift(1, motionID, start, end);
		addCommand(cmd);
	}

	public void SHIFT_ATK2(MotionID motionID, float start, float end)
	{
		ActionCommandAttackShift cmd = new ActionCommandAttackShift(2, motionID, start, end);
		addCommand(cmd);
	}

	public void SOUND(float time, string soundName)
	{
		_0024SOUND_0024locals_002414347 _0024SOUND_0024locals_0024 = new _0024SOUND_0024locals_002414347();
		_0024SOUND_0024locals_0024._0024soundName = soundName;
		ActionTimerJob actionTimerJob = new ActionTimerJob(time, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024SOUND_0024closure_00243836(_0024SOUND_0024locals_0024, this).Invoke));
		actionTimerJob.myName = new StringBuilder("SOUND ").Append(_0024SOUND_0024locals_0024._0024soundName).ToString();
		addCommand(actionTimerJob);
	}

	public void SPEED(float spd)
	{
		charMoveSpeed = spd;
	}

	public int RARE3(int normal, int rare, int srare)
	{
		int result;
		if (!IsColosseumSetup && HasPoppetData)
		{
			result = 0;
		}
		else
		{
			switch (RARITY)
			{
			case EnumRares.normal:
			case EnumRares.normal_plus:
				result = normal;
				break;
			case EnumRares.rare:
			case EnumRares.rare_plus:
				result = rare;
				break;
			case EnumRares.special_rare:
			case EnumRares.special_rare_plus:
				result = srare;
				break;
			default:
				result = normal;
				break;
			}
		}
		return result;
	}

	public int RARE6(int r1, int r2, int r3, int r4, int r5, int r6)
	{
		return (IsColosseumSetup || !HasPoppetData) ? (RARITY switch
		{
			EnumRares.normal => r1, 
			EnumRares.normal_plus => r2, 
			EnumRares.rare => r3, 
			EnumRares.rare_plus => r4, 
			EnumRares.special_rare => r5, 
			EnumRares.special_rare_plus => r6, 
			_ => r1, 
		}) : 0;
	}

	public bool RARE3_RAND100(int normal, int rare, int srare)
	{
		int num = UnityEngine.Random.Range(0, 100);
		int num2 = RARE3(normal, rare, srare);
		return num < num2;
	}

	public bool RARE6_RAND100(int r1, int r2, int r3, int r4, int r5, int r6)
	{
		int num = UnityEngine.Random.Range(0, 100);
		int num2 = RARE6(r1, r2, r3, r4, r5, r6);
		return num < num2;
	}

	protected void setLatestAttackCommand(ActionCommandAttack cmd)
	{
		if (!RuntimeServices.EqualityOperator(_latestAttackCommand, cmd))
		{
			_latestAttackCommand = cmd;
			if (cmd != null)
			{
				addSkillAbnormalStateEffect(cmd);
				doOptionalAttackCommandAdj(cmd);
			}
		}
	}

	public virtual void doOptionalAttackCommandAdj(ActionCommandAttack cmd)
	{
	}

	public void ATTACK(EnumOrStringValue<AttackPartTypes> part, float start, float end, bool once, int damage, YarareTypes yarareType, float knockBackPow)
	{
		ActionCommandAttack actionCommandAttack = null;
		actionCommandAttack = ((!part.hasString) ? new ActionCommandAttack(getAttackCollision((AttackPartTypes)part.enumValue)) : new ActionCommandAttack(getAttackCollision(part.stringValue)));
		actionCommandAttack.startTime = start;
		actionCommandAttack.mainTime = start;
		actionCommandAttack.endTime = end;
		actionCommandAttack.once = once;
		actionCommandAttack.damage = damage;
		actionCommandAttack.knockBackPow = knockBackPow;
		actionCommandAttack.yarareType = yarareType;
		addCommand(actionCommandAttack);
		setLatestAttackCommand(actionCommandAttack);
	}

	public void ATK_INVSUPARM()
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1646 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_INVSUPARMはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.invalidSuperArmor = true;
		}
	}

	public void ATK_INVSUPARM_EX(AttackDamageActors atk, AttackDamageActors dfs)
	{
		LatestAttackCommand.InvalidSuperArmorAttackers |= (int)atk;
		LatestAttackCommand.InvalidSuperArmorDefensers |= (int)dfs;
	}

	public void ATK_LIMITCOUNT(int n)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1668 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_LIMITCOUNTはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else if (n <= 0)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1669 + "):" + "n > 0" + " -- message: " + new StringBuilder("ATK_LIMITCOUNT の値は1以上です(").Append((object)n).Append(")").ToString();
			Debug.LogError(message2);
		}
		else
		{
			LatestAttackCommand.once = false;
			LatestAttackCommand.hitCountLimit = n;
		}
	}

	public void ATK_INTERVAL(float interval)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1677 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_INTERVALはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else if (!(interval >= 0f))
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1678 + "):" + "interval >= 0" + " -- message: " + new StringBuilder("ATK_INTERVAL の値は0以上です(").Append(interval).Append(")").ToString();
			Debug.LogError(message2);
		}
		else
		{
			LatestAttackCommand.once = false;
			LatestAttackCommand.hitInterval = interval;
		}
	}

	public void ATK_HITEFF(GameObject prefab)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1684 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_HITEFFはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.hitEffect = prefab;
		}
	}

	public void ATK_GUARDCANCEL()
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1689 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_HITEFFはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.guardCancel = true;
		}
	}

	public void ATK_BREAKPOW(float breakPow)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1694 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_BREAKPOWはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.breakPow = Mathf.Clamp(breakPow, 0f, 1f);
		}
	}

	public void ATK_SE(string seName)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1699 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_SEはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.hitSE = seName;
		}
	}

	public void ATK_ABST(EnumAbnormalStates sid, int rate)
	{
		ATK_ABST_POW(sid, rate, 100);
	}

	public void ATK_ABST_POW(EnumAbnormalStates sid, int rate, int infectionPower)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1713 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_SEはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
			return;
		}
		int rate2 = rate;
		if (HasMonsterData && IS_ELITE)
		{
			MMonsters master = monsterData.Master;
			if (master != null)
			{
				rate2 = checked((int)((float)rate * master.EliteAbnormalStateRateMult));
			}
		}
		LatestAttackCommand.addAbnormalStateEffect(sid, rate2, infectionPower);
	}

	public void ATK_RDMG(float rate)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1725 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_RDMGはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.recoveryRate = rate / 100f;
		}
	}

	public void ATK_CRITICAL_RATE(float rate)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 1729 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_CRITICAL_RATEはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
		}
		else
		{
			LatestAttackCommand.criticalRate = rate;
		}
	}

	public void SetEffectWorldOffset(Vector3 offset)
	{
		hasEffectWorldOffset = true;
		effectWorldOffset = offset;
	}

	public void ResetEffectWorldOffset()
	{
		hasEffectWorldOffset = false;
	}

	public void EFFECT(GameObject prefab, float emitTime, string boneName, ActionCommandEffect.TransformMode emitMode, ActionCommandEffect.TransformMode constraintMode, float offset_x, float offset_y, float offset_z, float rot_x, float rot_y, float rot_z)
	{
		ActionCommandEffect actionCommandEffect = new ActionCommandEffect(prefab);
		actionCommandEffect.setJustTime(emitTime);
		actionCommandEffect.killAtDispose = true;
		actionCommandEffect.boneName = boneName;
		actionCommandEffect.emitMode = emitMode;
		actionCommandEffect.constraintMode = constraintMode;
		actionCommandEffect.offset = new Vector3(offset_x, offset_y, offset_z);
		actionCommandEffect.rotation = new Vector3(rot_x, rot_y, rot_z);
		addCommand(actionCommandEffect);
		lastEntriedEffectCommand = actionCommandEffect;
	}

	public void EFFECT_R100(GameObject prefab, float emitTime, string boneName, ActionCommandEffect.TransformMode emitMode, ActionCommandEffect.TransformMode constraintMode, float offset_x, float offset_y, float offset_z, float rot_x, float rot_y, float rot_z, int rate)
	{
		if (RAND100 < rate)
		{
			EFFECT(prefab, emitTime, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
		}
	}

	public void EFFECT_PROT(GameObject prefab, float emitTime, string boneName, ActionCommandEffect.TransformMode emitMode, ActionCommandEffect.TransformMode constraintMode, float offset_x, float offset_y, float offset_z, float rot_x, float rot_y, float rot_z)
	{
		EFFECT(prefab, emitTime, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.ApplyRotation = true;
		}
	}

	public void EFFECT_PROT_R100(GameObject prefab, float emitTime, string boneName, ActionCommandEffect.TransformMode emitMode, ActionCommandEffect.TransformMode constraintMode, float offset_x, float offset_y, float offset_z, float rot_x, float rot_y, float rot_z, int rate)
	{
		if (RAND100 < rate)
		{
			EFFECT_PROT(prefab, emitTime, boneName, emitMode, constraintMode, offset_x, offset_y, offset_z, rot_x, rot_y, rot_z);
		}
	}

	public void EFF_KILLTIME(float time, GameObject prefab)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.killAtDispose = false;
			lastEntriedEffectCommand.lifeTime = time;
			lastEntriedEffectCommand.deadEffect = prefab;
		}
	}

	public void EFF_KILLTIME_MCHG(float time, GameObject prefab)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.killAtDispose = true;
			lastEntriedEffectCommand.lifeTime = time;
			lastEntriedEffectCommand.deadEffect = prefab;
		}
	}

	public void EFF_DONT_KILL_MCHG()
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.aliveOverMotionChange = true;
		}
	}

	public void EFF_DANGLE()
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.dangle = true;
		}
	}

	public void EFF_MOV(float initVelX, float initVelY, float randVelocityXMin, float randVelocityXMax, float randVelocityYMin, float randVelocityYMax, float randRot, float speedZ, float speedY, float moveDelay, bool targetting)
	{
		if (lastEntriedEffectCommand != null)
		{
			ActionCommandEffect actionCommandEffect = lastEntriedEffectCommand;
			ThrowObjParams throwObjParams = actionCommandEffect.setThrowObjParam();
			throwObjParams.initVelocity.x = initVelX;
			throwObjParams.initVelocity.y = initVelY;
			throwObjParams.randVelocityXMin = randVelocityXMin;
			throwObjParams.randVelocityXMax = randVelocityXMax;
			throwObjParams.randVelocityYMin = randVelocityYMin;
			throwObjParams.randVelocityYMax = randVelocityYMax;
			throwObjParams.randRot = randRot;
			throwObjParams.speedZ = speedZ;
			throwObjParams.speedY = speedY;
			throwObjParams.moveDelay = moveDelay;
			throwObjParams.targetting = targetting;
		}
	}

	public void EFF_HOMING_Y()
	{
		if (lastEntriedEffectCommand != null)
		{
			if (lastEntriedEffectCommand.ThrowObjParams == null)
			{
				lastEntriedEffectCommand.setThrowObjParam();
			}
			lastEntriedEffectCommand.ThrowObjParams.adjustToLockOnY = true;
		}
	}

	public void EFF_SCALING(float scaleAdd)
	{
		if (lastEntriedEffectCommand != null)
		{
			ActionCommandEffect actionCommandEffect = lastEntriedEffectCommand;
			ThrowObjParams throwObjParams = actionCommandEffect.setThrowObjParam();
			throwObjParams.secScaleAdd = scaleAdd;
		}
	}

	public void EFF_ATTACK(float start, float end, bool once, int damage, YarareTypes yarareType, float knockBackPow)
	{
		if (lastEntriedEffectCommand != null)
		{
			ActionCommandEffectAttack actionCommandEffectAttack = new ActionCommandEffectAttack(lastEntriedEffectCommand);
			actionCommandEffectAttack.startTime = start;
			actionCommandEffectAttack.mainTime = start;
			actionCommandEffectAttack.endTime = end;
			actionCommandEffectAttack.once = once;
			actionCommandEffectAttack.damage = damage;
			actionCommandEffectAttack.knockBackPow = knockBackPow;
			actionCommandEffectAttack.yarareType = yarareType;
			actionCommandEffectAttack.chainSkillPoppet = lastEntriedEffectCommand.chainSkillPoppet;
			if (getMainWeapon() != null)
			{
				actionCommandEffectAttack.setOrigin(getMainWeapon());
			}
			else
			{
				actionCommandEffectAttack.setOriginElement(CurrentElement);
			}
			addCommand(actionCommandEffectAttack);
			setLatestAttackCommand(actionCommandEffectAttack);
		}
	}

	public void setChainSkillInfoToLastEffectAttack(RespPoppet basePoppetData, float damageScale)
	{
		if (basePoppetData != null && lastEntriedEffectCommand != null && LatestAttackCommand is ActionCommandEffectAttack)
		{
			lastEntriedEffectCommand.chainSkillPoppet = basePoppetData;
			ActionCommandEffectAttack actionCommandEffectAttack = LatestAttackCommand as ActionCommandEffectAttack;
			actionCommandEffectAttack.useChainPoppetAttack = damageScale;
			actionCommandEffectAttack.chainSkillPoppet = basePoppetData;
		}
	}

	public void EFF_COLOR(float red, float green, float blue)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.addMessage("setColor", new Color(red, green, blue, 1f));
		}
	}

	public void EFF_COLOR4(float red, float green, float blue, float alpha)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.addMessage("setColor", new Color(red, green, blue, alpha));
		}
	}

	public void EFF_TIME(float time)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.addMessage("setTime", time);
		}
	}

	public void EFF_AREA_DAMAGE(float damagePerSec)
	{
		if (lastEntriedEffectCommand != null)
		{
			float damagePerSec2 = damagePerSec * absoluteTypeAreaDamageRate();
			lastEntriedEffectCommand.AreaData = StateChangeAreaData.Damage(damagePerSec2);
			lastEntriedEffectCommand.AreaData.Origin = this;
		}
	}

	public void EFF_AREA_DAMAGE_REL(float damageRatePerSec)
	{
		if (lastEntriedEffectCommand != null)
		{
			float damageRatePerSec2 = damageRatePerSec / 100f;
			lastEntriedEffectCommand.AreaData = StateChangeAreaData.DamageHpMaxRel(damageRatePerSec2);
			lastEntriedEffectCommand.AreaData.Origin = this;
		}
	}

	public void EFF_AREA_GRAVITY(float gravity)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.AreaData = StateChangeAreaData.Gravity(gravity);
			lastEntriedEffectCommand.AreaData.Origin = this;
		}
	}

	public void EFF_AREA_SNARE(float speedScale)
	{
		if (lastEntriedEffectCommand != null)
		{
			lastEntriedEffectCommand.AreaData = StateChangeAreaData.Snare(speedScale);
			lastEntriedEffectCommand.AreaData.Origin = this;
		}
	}

	public void CAMSHAKE(float time)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(time, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			int i = 0;
			CameraControl[] array = (CameraControl[])UnityEngine.Object.FindObjectsOfType(typeof(CameraControl));
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				iTween.ShakePosition(array[i].gameObject, new Vector3(0f, 0.7f, 0f), 0.3f);
			}
		});
		actionTimerJob.myName = "CAMSHAKE";
		addCommand(actionTimerJob);
	}

	public void GUARD(float start, float end)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		actionTimerJob.startJob = delegate
		{
			actionParameters.guard = true;
		};
		actionTimerJob.endJob = delegate
		{
			actionParameters.guard = false;
		};
		actionTimerJob.myName = "GUARD";
		addCommand(actionTimerJob);
	}

	public virtual void MOVE(ActionDirections dir, float start, float end, float spd)
	{
		ActionCommandTranslate cmd = new ActionCommandTranslate(start, end, dir, spd);
		addCommand(cmd);
	}

	public void CANCEL(float cancelTime)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(cancelTime, float.MaxValue);
		actionTimerJob.startJob = delegate
		{
			setActionType(ActionTypes.Cancel);
		};
		actionTimerJob.endJob = delegate
		{
			clearActionType(ActionTypes.Cancel);
		};
		actionTimerJob.myName = "CANCEL";
		addCommand(actionTimerJob);
		addCommand(doCreateCancel(cancelTime));
	}

	public void TARGET(float startTime, float endTime, float speed)
	{
		if (!IsMonsterBlindedAbnormalState)
		{
			ActionCommandTargetting actionCommandTargetting = targetCommand();
			actionCommandTargetting.type = ActionCommandTargetting.Type.MyTarget;
			actionCommandTargetting.setTimeRange(startTime, endTime);
			actionCommandTargetting.rotationSpeed = speed;
		}
	}

	public virtual void NO_TARGET()
	{
		ActionCommandTargetting actionCommandTargetting = targetCommand();
		actionCommandTargetting.type = ActionCommandTargetting.Type.None;
	}

	public void LOOP(float init, float start, float end)
	{
		Mmpc.setPartialLoop(init, start, end);
	}

	public void NOHIT(float start, float end)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		actionTimerJob.startJob = delegate
		{
			actionParameters.setNoAttackHit();
		};
		actionTimerJob.endJob = delegate
		{
			actionParameters.resetNoAttackHit();
		};
		actionTimerJob.myName = "NOHIT";
		addCommand(actionTimerJob);
	}

	public void setBonusNoHit(float tm)
	{
		StartCoroutine("bonusNoHitRoutine", tm);
	}

	private IEnumerator bonusNoHitRoutine(float tm)
	{
		return new _0024bonusNoHitRoutine_002416755(tm, this).GetEnumerator();
	}

	public void clearNoHitAndGuard()
	{
		StopCoroutine("bonusNoHitRoutine");
		actionParameters.reset();
	}

	public void MOTMOV_SCALE(float start, float end, float scale)
	{
		_0024MOTMOV_SCALE_0024locals_002414348 _0024MOTMOV_SCALE_0024locals_0024 = new _0024MOTMOV_SCALE_0024locals_002414348();
		_0024MOTMOV_SCALE_0024locals_0024._0024scale = scale;
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		actionTimerJob.startJob = new _0024MOTMOV_SCALE_0024closure_00243847(this, _0024MOTMOV_SCALE_0024locals_0024).Invoke;
		actionTimerJob.endJob = delegate
		{
			motionMovementScale = 1f;
		};
		actionTimerJob.myName = "MOTMOV_SCALE";
		addCommand(actionTimerJob);
	}

	public void NO_PUSHOUT(float start, float end)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		actionTimerJob.startJob = delegate
		{
			setBodyLayerNoPushOut();
		};
		actionTimerJob.endJob = delegate
		{
			setBodyLayer(startLayer);
			transform.position = BattleUtil.AdjustYpos(transform.position);
		};
		actionTimerJob.myName = "NO_PUSHOUT";
		addCommand(actionTimerJob);
	}

	public void ATK_NAGE(string boneName, float endTime, MotionID dfcMot, float dfcStopTime, MotionID dfcResultMot, float dfcResultMotStartTime)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2131 + "):" + "LatestAttackCommand != null" + " -- message: " + "ATK_NAGEはATTACK指定の後でないとダメ！";
			Debug.LogError(message);
			return;
		}
		if (string.IsNullOrEmpty(boneName))
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2132 + "):" + "not string.IsNullOrEmpty(boneName)" + " -- message: " + "ATK_NAGE の骨名が空";
			Debug.LogError(message2);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		latestAttackCommand.nageInfo.nageBone = boneName;
		latestAttackCommand.nageInfo.endTime = endTime;
		latestAttackCommand.nageInfo.yarareMot = dfcMot;
		latestAttackCommand.nageInfo.yarareStopTime = dfcStopTime;
		latestAttackCommand.nageInfo.yarareResultMot = dfcResultMot;
		latestAttackCommand.nageInfo.yarareResultMotStartTime = dfcResultMotStartTime;
		latestAttackCommand.once = true;
	}

	public void ATK_NAGE_HIDE(float start, float end)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2145 + "):" + "LatestAttackCommand != null" + " -- message: " + new StringBuilder("ATK_NAGE_HIDEはATTACK指定の後でないとダメ！").Append(gameObject).ToString();
			Debug.LogError(message);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		if (!latestAttackCommand.nageInfo.IsValid)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2147 + "):" + "cmd.nageInfo.IsValid" + " -- message: " + new StringBuilder("ATK_NAGE設定なしに ATK_NAGE_MOTを使っている。").Append(gameObject).ToString();
			Debug.LogError(message2);
		}
		else
		{
			latestAttackCommand.nageInfo.hideTime = start;
			latestAttackCommand.nageInfo.showTime = end;
		}
	}

	public void ATK_NAGE_OFS(float x, float y, float z, float xrot, float yrot, float zrot)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2154 + "):" + "LatestAttackCommand != null" + " -- message: " + new StringBuilder("ATK_NAGE_OFSはATTACK指定の後でないとダメ！").Append(gameObject).ToString();
			Debug.LogError(message);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		if (!latestAttackCommand.nageInfo.IsValid)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2156 + "):" + "cmd.nageInfo.IsValid" + " -- message: " + new StringBuilder("ATK_NAGE設定なしに ATK_NAGE_MOTを使っている。").Append(gameObject).ToString();
			Debug.LogError(message2);
		}
		else
		{
			latestAttackCommand.nageInfo.yarareLocalPos = new Vector3(x, y, z);
			latestAttackCommand.nageInfo.yarareLocalRot = Quaternion.Euler(xrot, yrot, zrot);
		}
	}

	public void ATK_NAGE_SHIFT(MotionID つかみシフト, float つかみシフト開始時間)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2162 + "):" + "LatestAttackCommand != null" + " -- message: " + new StringBuilder("ATK_NAGE_SHIFTはATTACK指定の後でないとダメ！").Append(gameObject).ToString();
			Debug.LogError(message);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		if (!latestAttackCommand.nageInfo.IsValid)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2164 + "):" + "cmd.nageInfo.IsValid" + " -- message: " + new StringBuilder("ATK_NAGE設定なしに ATK_NAGE_SHIFTを使っている。").Append(gameObject).ToString();
			Debug.LogError(message2);
		}
		else
		{
			latestAttackCommand.nageInfo.attackMot = つかみシフト;
			latestAttackCommand.nageInfo.attackMotStart = つかみシフト開始時間;
		}
	}

	public void ATK_NAGE_DMGTIME(float time)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2169 + "):" + "LatestAttackCommand != null" + " -- message: " + new StringBuilder("ATK_NAGE_DMGTIMEはATTACK指定の後でないとダメ！").Append(gameObject).ToString();
			Debug.LogError(message);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		if (!latestAttackCommand.nageInfo.IsValid)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2171 + "):" + "cmd.nageInfo.IsValid" + " -- message: " + new StringBuilder("ATK_NAGE設定なしに ATK_NAGE_DMGTIMEを使っている。").Append(gameObject).ToString();
			Debug.LogError(message2);
		}
		else
		{
			latestAttackCommand.nageInfo.damageTime = time;
		}
	}

	public void ATK_NAGE_KNOCKBACK(float knockBackPow)
	{
		if (LatestAttackCommand == null)
		{
			string message = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2176 + "):" + "LatestAttackCommand != null" + " -- message: " + new StringBuilder("ATK_NAGE_KNOCKBACKはATTACK指定の後でないとダメ！").Append(gameObject).ToString();
			Debug.LogError(message);
			return;
		}
		ActionCommandAttack latestAttackCommand = LatestAttackCommand;
		if (!latestAttackCommand.nageInfo.IsValid)
		{
			string message2 = "MAC_ASSERT at " + "MerlinActionControl" + "(" + 2178 + "):" + "cmd.nageInfo.IsValid" + " -- message: " + new StringBuilder("ATK_NAGE設定なしに ATK_NAGE_KNOCKBACKを使っている。").Append(gameObject).ToString();
			Debug.LogError(message2);
		}
		else
		{
			latestAttackCommand.nageInfo.knockBackPow = knockBackPow;
		}
	}

	public void SUPERARMOR(float start, float end)
	{
		ActionCommandSuperArmor cmd = new ActionCommandSuperArmor(start, end);
		addCommand(cmd);
	}

	public void RESTORE(float start, float end, float restorationPercentage)
	{
		ActionCommandRestoreLife cmd = new ActionCommandRestoreLife(start, end, restorationPercentage / 100f);
		addCommand(cmd);
	}

	public void HIDE_MESH(float start, float end, string meshName)
	{
		_0024HIDE_MESH_0024locals_002414349 _0024HIDE_MESH_0024locals_0024 = new _0024HIDE_MESH_0024locals_002414349();
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		_0024HIDE_MESH_0024locals_0024._0024lowName = meshName.ToLower();
		actionTimerJob.startJob = new _0024HIDE_MESH_0024closure_00243851(_0024HIDE_MESH_0024locals_0024, this).Invoke;
		actionTimerJob.endJob = new _0024HIDE_MESH_0024closure_00243852(this, _0024HIDE_MESH_0024locals_0024).Invoke;
		actionTimerJob.myName = "HIDE_MESH";
		addCommand(actionTimerJob);
	}

	public void activateMesh(string meshName, bool b)
	{
		int i = 0;
		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			if (componentsInChildren[i].gameObject.name.ToLower().EndsWith(meshName))
			{
				componentsInChildren[i].enabled = b;
			}
		}
	}

	public void TTT(EnumOrStringValue<AttackPartTypes> val)
	{
	}

	public virtual void startHitCancel(int n)
	{
		actionParameters.setHitCancelCount(n);
	}

	public virtual void decHitCancelCount()
	{
		actionParameters.decHitCancelCount();
	}

	public virtual void stopHitCancel()
	{
		actionParameters.resetHitCancelCount();
	}

	public int randRange(int minimum, int maximum)
	{
		return UnityEngine.Random.Range(minimum, checked(maximum + 1));
	}

	public void resetTimer()
	{
		_d540Timer = 0f;
	}

	public void TENSHIN()
	{
		changeMmpc(checked(1 - CurrentMmpcSet), withEffect: true);
	}

	public void TENSHIN_IMM(int n)
	{
		changeMmpc(n, withEffect: true);
	}

	public float VAL_BY_HPRATE(float rate, float val1, float val2)
	{
		return (HitPointRate >= rate) ? val2 : val1;
	}

	public PlayerAnimationTypes inputRandomAttack()
	{
		PlayerAnimationTypes playerAnimationTypes = randomAttackNo();
		if (playerAnimationTypes > PlayerAnimationTypes.Idle)
		{
			inputAttack((int)playerAnimationTypes);
		}
		PlayerAnimationTypes result = default(PlayerAnimationTypes);
		return result;
	}

	private PlayerAnimationTypes randomAttackNo()
	{
		int[] array = attackNos();
		int result;
		if (array.Length == 0)
		{
			result = 0;
		}
		else
		{
			result = array[RuntimeServices.NormalizeArrayIndex(array, UnityEngine.Random.Range(0, array.Length))];
		}
		return (PlayerAnimationTypes)result;
	}

	private int[] attackNos()
	{
		if (_attackMotions == null)
		{
			Boo.Lang.List<int> list = new Boo.Lang.List<int>();
			int num = 0;
			while (num < 8)
			{
				int num2 = num;
				num++;
				if (Mmpc.containsOfType(3 + num2))
				{
					list.Add(checked(num2 + 1));
				}
			}
			_attackMotions = (int[])Builtins.array(typeof(int), list);
		}
		return _attackMotions;
	}

	public void pp(string s)
	{
	}

	public float distTo(Vector3 pos)
	{
		return (pos - transform.position).magnitude;
	}

	public void forceToIdle()
	{
		CommandBlockMode = false;
		resetMotionSpeedScale();
		playAnimationByType(PlayerAnimationTypes.Idle);
		Mmpc.resetBasePos();
		doForceToIdle();
	}

	protected virtual void doForceToIdle()
	{
	}

	public virtual void cleanUpAnimations()
	{
		CleanUpAnimations(Mmpc.motionTarget);
	}

	public static void CleanUpAnimations(GameObject targetObject)
	{
		if (!(targetObject == null))
		{
			CleanUpAnimations(targetObject.animation);
		}
	}

	public static void CleanUpAnimations(Animation anim)
	{
		if (anim == null)
		{
			return;
		}
		AnimationClip clip = anim.clip;
		Boo.Lang.List<AnimationClip> list = new Boo.Lang.List<AnimationClip>();
		IEnumerator enumerator = anim.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			if (!(animationState == null) && !(animationState.clip == null))
			{
				list.Add(animationState.clip);
			}
		}
		IEnumerator<AnimationClip> enumerator2 = list.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				AnimationClip current = enumerator2.Current;
				if (current != clip)
				{
					anim.RemoveClip(current);
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	public void ADD_YANG(float yang)
	{
		Vector3 eulerAngles = transform.eulerAngles;
		transform.eulerAngles = eulerAngles + new Vector3(0f, yang, 0f);
	}

	public void SET_YANG(float yang)
	{
		transform.eulerAngles = new Vector3(0f, yang, 0f);
	}

	public void MOVE_XY(float x, float z)
	{
		addVolatileMovement(new Vector3(x, 0f, z));
	}

	public void MOVE_F(float d)
	{
		Vector3 forward = transform.forward;
		addVolatileMovement(forward * d);
	}

	public Vector3 GEN_VEC3(float x, float y, float z)
	{
		return new Vector3(x, y, z);
	}

	public void SET_POS(Vector3 v)
	{
		transform.position = v;
	}

	public void SET_LOCAL_POS(Vector3 v)
	{
		transform.localPosition = v;
	}

	public void ELEMENT_FIRE()
	{
		setTemporaryElement(EnumElements.fire);
	}

	public void ELEMENT_WATER()
	{
		setTemporaryElement(EnumElements.water);
	}

	public void ELEMENT_EARTH()
	{
		setTemporaryElement(EnumElements.earth);
	}

	public void ELEMENT_WIND()
	{
		setTemporaryElement(EnumElements.wind);
	}

	public void RESET_ELEMENT()
	{
		if (HasMonsterData)
		{
			monsterData.ResetTemporaryElement();
		}
	}

	private void setTemporaryElement(EnumElements e)
	{
		if (!HasMonsterData)
		{
			return;
		}
		MElements mElements = MElements.Get((int)e);
		if (mElements != null)
		{
			monsterData.SetTemporaryElement(mElements);
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if (currentPlayer != null && currentPlayer.LockOnControl != null && currentPlayer.LockOnControl.Target == this)
			{
				currentPlayer.LockOnControl.refreshLockOnInfo((AIControl)this);
			}
		}
	}

	public void deblog(string msg)
	{
		if (!logging)
		{
		}
	}

	public void debwarn(string msg)
	{
	}

	public void deberr(string msg)
	{
	}

	protected void reflectAbnormalStateParameters()
	{
		PlayerAbnormalStateControl.StateParams @params = abnormalStateControl.Params;
		if (@params != null && MovementScale != @params.speed)
		{
			MovementScale = @params.speed;
		}
	}

	public virtual void resetAbnormalState()
	{
		inAreaData.Clear();
		inAreaStateControl.clear();
		abnormalStateControl.clearAll();
		abnormalStateLimitter.reset();
	}

	public void setAbnormalState(EnumAbnormalStates sid)
	{
		if (sid != 0)
		{
			playSE(SQEX_SoundPlayerData.SE.state_motion);
			abnormalStateControl.enable(sid);
			abnormalStateLimitter.infectAndReset(sid);
		}
	}

	public void resistAbnormalState(EnumAbnormalStates sid)
	{
		abnormalStateLimitter.infectAndReset(sid);
	}

	public bool hasAbnormalState(EnumAbnormalStates sid)
	{
		return abnormalStateControl.hasAbnormalState(sid);
	}

	private float getMovementSpeedScaleByAbnormalState()
	{
		PlayerAbnormalStateControl.StateParams @params = abnormalStateControl.Params;
		return @params.speed;
	}

	public void resetAbnormalStatesAtRaceChanging()
	{
		abnormalStateControl.playerChanged();
	}

	private void updateAbnormalStateLimitter(float dt)
	{
		abnormalStateLimitter.update(dt);
	}

	private Vector3 limitMovementIfAbnormalState(Vector3 mov)
	{
		Vector3 result;
		if (IsMonsterBlindedAbnormalState)
		{
			mov = transform.forward;
			mov.y = 0f;
			result = mov;
		}
		else
		{
			result = mov;
		}
		return result;
	}

	protected void inAreaStateFixedUpdate()
	{
		inAreaStateControl.clear();
		lastInAreaData.Clear();
		IEnumerator<StateChangeAreaData> enumerator = inAreaData.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				StateChangeAreaData current = enumerator.Current;
				MerlinActionControl origin = current.Origin;
				if (isEnemy(origin))
				{
					inAreaStateControl.fixedUpdate(current, transform.position, MaxHitPoint);
					lastInAreaData.Add(current);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		inAreaData.Clear();
	}

	protected void updateInAreaState(float dt)
	{
		InAreaStateControl.damageUpdate(this, dt);
	}

	protected void addAreaDamageDataOnTriggerStay(Collider areaObj, AntiAreaDamages antiState)
	{
		if (areaObj == null)
		{
			return;
		}
		StateChangeArea component = areaObj.GetComponent<StateChangeArea>();
		if (!(component == null) && component.AreaData != null)
		{
			StateChangeAreaData areaData = component.AreaData;
			lastStayingAreaObject = areaObj;
			lastStayingAreaObjectData = areaData;
			if ((!areaData.IsDamage || !antiState.antiDamageArea) && (!areaData.IsDamageHpMaxRel || !antiState.antiDamageArea) && (!areaData.IsSnare || !antiState.antiSlowArea) && (!areaData.IsGravity || !antiState.antiGravityArea))
			{
				inAreaData.Add(areaData);
			}
		}
	}

	protected virtual float getMovementSpeedScaleByAreaDamage()
	{
		return inAreaStateControl.speedRate;
	}

	public virtual bool isEnemy(MerlinActionControl other)
	{
		return true;
	}

	public void setupSkillEffectControl()
	{
		SkillEffectControl.initialize();
	}

	public bool canResistAbnormalStateBySkill(EnumAbnormalStates state)
	{
		return skillEffectControl.canResistAbnormalState(this, state);
	}

	private void addSkillAbnormalStateEffect(ActionCommandAttack cmd)
	{
		if (cmd != null)
		{
			skillEffectControl.setAbnormalStateToAttackCommand(cmd);
		}
	}

	protected void updateSkillEffectControl(float dt)
	{
		skillEffectControl.update(dt);
	}

	protected float calcHpMaxBySkill(float hpBase)
	{
		return SkillEffectControl.CurrentData.calcHpMax(hpBase);
	}

	public SkillEffector createChainSkillEffect(RespPoppet poppet)
	{
		return SkillEffectControl.createChainSkill(poppet);
	}

	public void setSetupTypeColosseum()
	{
		setupType = CharSetupTypes.Colosseum;
	}

	public void setSetupTypeRaidBoss()
	{
		setupType = CharSetupTypes.RaidBoss;
	}

	public void setSetupTypePlayer()
	{
		setupType = CharSetupTypes.Player;
	}

	public void setSetupTypeMonster()
	{
		setupType = CharSetupTypes.Monster;
	}

	private float absoluteTypeAreaDamageRate()
	{
		return (setupType != CharSetupTypes.Colosseum) ? 1f : 0.2f;
	}

	public float HitPointRecoveryRate(float recoveryRate)
	{
		return HitPointRecovery(MaxHitPoint * recoveryRate);
	}

	public virtual float HitPointRecovery(float recovery)
	{
		addHP(recovery);
		return recovery;
	}

	internal void _0024setupMMPC_0024closure_00242894(MerlinMotionPackControl me, MerlinMotionPack.Entry entry)
	{
		if (me.enabled)
		{
			mmpc.BaseMovementScale = 1f;
			if (me != null)
			{
				me.enqueueStringToHistory(new StringBuilder().Append((object)Time.frameCount).Append(" motion changed ").Append((entry == null) ? "???" : entry.name)
					.ToString());
			}
			initStateAtMotionChange();
			clearMovementData();
			disposeCommandsAtMotionChange();
			actionInput.clearEveryMotionChange();
			actionParameters.initAtMotionChange();
			doMotionChanged();
			nowBlockMode = CommandBlockMode;
			CommandBlockMode = false;
		}
	}

	internal void _0024setupMMPC_0024closure_00242895(MerlinMotionPackControl me, MerlinMotionPack.Entry entry)
	{
		if (me.enabled)
		{
			if (me != null)
			{
				me.enqueueStringToHistory(new StringBuilder().Append((object)Time.frameCount).Append(" motion changed after ").Append((entry == null) ? "???" : entry.name)
					.ToString());
			}
			CommandBlockMode = nowBlockMode;
			initActionTypes();
			setRejectModeByActionType();
			addDefaultCommands();
			setOtherDefaultValues();
			doMotionChangedAfter();
		}
	}

	internal void _0024CAMSHAKE_0024closure_00243840()
	{
		int i = 0;
		CameraControl[] array = (CameraControl[])UnityEngine.Object.FindObjectsOfType(typeof(CameraControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			iTween.ShakePosition(array[i].gameObject, new Vector3(0f, 0.7f, 0f), 0.3f);
		}
	}

	internal void _0024GUARD_0024closure_00243841()
	{
		actionParameters.guard = true;
	}

	internal void _0024GUARD_0024closure_00243842()
	{
		actionParameters.guard = false;
	}

	internal void _0024CANCEL_0024closure_00243843()
	{
		setActionType(ActionTypes.Cancel);
	}

	internal void _0024CANCEL_0024closure_00243844()
	{
		clearActionType(ActionTypes.Cancel);
	}

	internal void _0024NOHIT_0024closure_00243845()
	{
		actionParameters.setNoAttackHit();
	}

	internal void _0024NOHIT_0024closure_00243846()
	{
		actionParameters.resetNoAttackHit();
	}

	internal void _0024MOTMOV_SCALE_0024closure_00243848()
	{
		motionMovementScale = 1f;
	}

	internal void _0024NO_PUSHOUT_0024closure_00243849()
	{
		setBodyLayerNoPushOut();
	}

	internal void _0024NO_PUSHOUT_0024closure_00243850()
	{
		setBodyLayer(startLayer);
		transform.position = BattleUtil.AdjustYpos(transform.position);
	}
}
