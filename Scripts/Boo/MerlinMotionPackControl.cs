using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MerlinMotionPackControl : MonoBehaviour
{
	[Serializable]
	private enum CommandId
	{
		none,
		play,
		playByName,
		playByType,
		playByReq,
		stop,
		setPlayTime,
		timeScale,
		motionTarget,
		addPack,
		erasePack,
		activateMotionPack,
		activateMotionPackOnly,
		setPackPrio,
		setLoopMode,
		setYangle,
		setPartialLoop,
		resetBasePos
	}

	[Serializable]
	public class Command
	{
		[Serializable]
		public enum ActivationTypes
		{
			NONE,
			ACTIVATION_ONLY,
			DEACTIVATION_AND_ACTIVATION
		}

		[NonSerialized]
		private static int commandSerial;

		public CommandId id;

		public object param;

		public object param2;

		public object param3;

		public int serial;

		public bool isExecuted;

		public override string ToString()
		{
			return new StringBuilder().Append(id).Append("(").Append((object)serial)
				.Append(") prms=")
				.Append(param)
				.Append("/")
				.Append(param2)
				.Append("/")
				.Append(param3)
				.ToString();
		}

		public static Command play(AnimationClip clip, bool loop, float crossFadeTime)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.play);
			object obj = (command.param = clip);
			object obj2 = (command.param2 = loop);
			object obj3 = (command.param3 = crossFadeTime);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command playByName(string animName, float crossFadeTime)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.playByName);
			object obj = (command.param = animName);
			object obj2 = (command.param2 = crossFadeTime);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command playByType(int typeID, float crossFadeTime)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.playByType);
			object obj = (command.param = typeID);
			object obj2 = (command.param2 = crossFadeTime);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command playByReq(PlayReq req)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.playByReq);
			object obj = (command.param = req);
			return command;
		}

		public static Command setLoopMode(bool loop)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.setLoopMode);
			object obj = (command.param = loop);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command setPlayTime(float time)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.setPlayTime);
			object obj = (command.param = time);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command stop()
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.stop);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command timeScale(float scale)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.timeScale);
			object obj = (command.param = scale);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command motionTarget(Animation animation)
		{
			ActivationTypes activationTypes = ActivationTypes.NONE;
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.motionTarget);
			object obj = (command.param = animation);
			object obj2 = (command.param2 = activationTypes);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command motionTargetWithActivation(Animation animation, bool deactivateOld)
		{
			ActivationTypes activationTypes = ActivationTypes.ACTIVATION_ONLY;
			if (deactivateOld)
			{
				activationTypes = ActivationTypes.DEACTIVATION_AND_ACTIVATION;
			}
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.motionTarget);
			object obj = (command.param = animation);
			object obj2 = (command.param2 = activationTypes);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command addPack(MerlinMotionPack pack)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.addPack);
			object obj = (command.param = pack);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command erasePack(MerlinMotionPack[] excludes)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.erasePack);
			object obj = (command.param = excludes);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command activateMotionPack(string packName, bool b)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.activateMotionPack);
			object obj = (command.param = packName);
			object obj2 = (command.param2 = b);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command activateMotionPackOnly(string[] packNames)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.activateMotionPackOnly);
			object obj = (command.param = packNames);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command setPackPrio(string packName, bool makeHigh)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.setPackPrio);
			object obj = (command.param = packName);
			object obj2 = (command.param2 = makeHigh);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command setYangle(float yangle)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.setYangle);
			object obj = (command.param = yangle);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command setPartialLoop(float init, float start, float end)
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.setPartialLoop);
			object obj = (command.param = init);
			object obj2 = (command.param2 = start);
			object obj3 = (command.param3 = end);
			int num = (command.serial = checked(++commandSerial));
			return command;
		}

		public static Command resetBasePos()
		{
			Command command = new Command();
			CommandId commandId = (command.id = CommandId.resetBasePos);
			return command;
		}
	}

	[Serializable]
	private class PackInfo
	{
		public MerlinMotionPack pack;

		public bool enabled;

		public MerlinMotionPack.Executer executer;

		public PackInfo(MerlinMotionPack _pack)
		{
			if (!(_pack != null))
			{
				throw new AssertionFailedException("_pack != null");
			}
			pack = _pack;
			enabled = true;
		}

		public void dispose()
		{
			if (pack != null)
			{
				pack.dispose();
			}
			if (executer != null)
			{
				executer.dispose();
			}
			pack = null;
			enabled = false;
			executer = null;
		}

		public override string ToString()
		{
			return new StringBuilder("Pack:").Append(pack.Name).Append(" enabled:").Append(enabled)
				.Append(" executer=")
				.Append(executer)
				.ToString();
		}
	}

	[Serializable]
	public class PlayReq
	{
		public int typeID;

		public string animName;

		public string[] keywords;

		public float fadeTime;

		private bool _0024initialized__MerlinMotionPackControl_PlayReq_0024;

		public bool HasTypeID
		{
			get
			{
				bool num = typeID >= 0;
				if (num)
				{
					num = string.IsNullOrEmpty(animName);
				}
				return num;
			}
		}

		public bool HasAnimName
		{
			get
			{
				bool num = typeID < 0;
				if (num)
				{
					num = !string.IsNullOrEmpty(animName);
				}
				return num;
			}
		}

		public PlayReq(int _typeID, string[] _keywords, float _fadeTime)
		{
			if (!_0024initialized__MerlinMotionPackControl_PlayReq_0024)
			{
				typeID = -1;
				_0024initialized__MerlinMotionPackControl_PlayReq_0024 = true;
			}
			if (_typeID < 0)
			{
				throw new AssertionFailedException(new StringBuilder("invalid typeID:").Append((object)_typeID).Append("!!!").ToString());
			}
			typeID = _typeID;
			keywords = _keywords;
			fadeTime = _fadeTime;
		}

		public PlayReq(string _animName, string[] _keywords, float _fadeTime)
		{
			if (!_0024initialized__MerlinMotionPackControl_PlayReq_0024)
			{
				typeID = -1;
				_0024initialized__MerlinMotionPackControl_PlayReq_0024 = true;
			}
			if (string.IsNullOrEmpty(_animName))
			{
				throw new AssertionFailedException("empty animName!!!");
			}
			animName = _animName;
			keywords = _keywords;
			fadeTime = _fadeTime;
		}

		public override string ToString()
		{
			string text = "<null>";
			if (keywords != null)
			{
				text = string.Empty;
				int i = 0;
				string[] array = keywords;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					text += array[i] + " ";
				}
			}
			return (!HasTypeID) ? new StringBuilder("Req(nm:").Append(animName).Append(" kws:").Append(text)
				.Append(")")
				.ToString() : new StringBuilder("Req(id:").Append((object)typeID).Append(" kws:").Append(text)
				.Append(")")
				.ToString();
		}
	}

	[Serializable]
	internal class _0024execAddPack_0024locals_002414268
	{
		internal MerlinMotionPack _0024pack;
	}

	[Serializable]
	internal class _0024execSetPackPrioCommand_0024locals_002414269
	{
		internal string _0024packName;
	}

	[Serializable]
	internal class _0024loadClip_0024locals_002414270
	{
		internal string _0024mot;
	}

	[Serializable]
	internal class _0024execAddPack_0024closure_00243822
	{
		internal _0024execAddPack_0024locals_002414268 _0024_0024locals_002414586;

		public _0024execAddPack_0024closure_00243822(_0024execAddPack_0024locals_002414268 _0024_0024locals_002414586)
		{
			this._0024_0024locals_002414586 = _0024_0024locals_002414586;
		}

		public bool Invoke(PackInfo i)
		{
			return i.pack == _0024_0024locals_002414586._0024pack;
		}
	}

	[Serializable]
	internal class _0024execSetPackPrioCommand_0024closure_00243827
	{
		internal _0024execSetPackPrioCommand_0024locals_002414269 _0024_0024locals_002414587;

		public _0024execSetPackPrioCommand_0024closure_00243827(_0024execSetPackPrioCommand_0024locals_002414269 _0024_0024locals_002414587)
		{
			this._0024_0024locals_002414587 = _0024_0024locals_002414587;
		}

		public bool Invoke(PackInfo i)
		{
			return equals(i.pack.Name, _0024_0024locals_002414587._0024packName);
		}
	}

	[Serializable]
	internal class _0024loadClip_0024closure_00243833
	{
		internal PackInfo _0024pi_002414588;

		internal _0024loadClip_0024locals_002414270 _0024_0024locals_002414589;

		internal MerlinMotionPackControl _0024this_002414590;

		public _0024loadClip_0024closure_00243833(PackInfo _0024pi_002414588, _0024loadClip_0024locals_002414270 _0024_0024locals_002414589, MerlinMotionPackControl _0024this_002414590)
		{
			this._0024pi_002414588 = _0024pi_002414588;
			this._0024_0024locals_002414589 = _0024_0024locals_002414589;
			this._0024this_002414590 = _0024this_002414590;
		}

		public void Invoke(AnimationClip clip)
		{
			if (_0024pi_002414588.executer != null)
			{
				_0024pi_002414588.executer.updateClipOfAllEntries(_0024this_002414590.YangEffectTransform.gameObject, _0024_0024locals_002414589._0024mot, clip);
			}
		}
	}

	public string comment;

	public MerlinMotionPack[] motionPacks;

	public Animation motionTarget;

	public bool baseMode;

	public bool logging;

	private Queue<string> history;

	private Queue<string> historyExecs;

	private float baseMovementScale;

	public Transform baseTransform;

	private float timeScale;

	private float lastTimeScale;

	private bool hasReqTimeScale;

	private float reqTimeScale;

	private int pause;

	private float motionTime;

	private float prevMotionTime;

	private string currentAnimName;

	private int currentAnimType;

	private AnimationClip currentClip;

	private AnimationClip oldClip;

	private AnimationState currentState;

	private MerlinMotionPack.Entry currentEntry;

	private bool rejectPlayRequest;

	[NonSerialized]
	private const string BASE_BONE_NAME = "y_ang";

	private Transform cachedBaseBone;

	private Vector3 translationDelta;

	private ArrayList commandQueue;

	private System.Collections.Generic.List<PackInfo> packInfos;

	private AnimationClip prevClip;

	private float nextEndPoint;

	private Vector3 prevBasePos;

	private bool motionChanged;

	private float updateDeltaTime;

	private float fixedUpdateDeltaTime;

	private CharacterController charController;

	private MerlinMotionPack.Executer currentActionExecuter;

	private MerlinMotionPack.Entry lastExecutedMotDefEntry;

	private int lastExecutedMotDefResult;

	private MerlinMotionPack.Entry _executedEntryInThisFrame;

	private float partialLoopInit;

	private float partialLoopStart;

	private float partialLoopEnd;

	private bool initialized;

	private Command currentExecutingCommand;

	private ArrayList execCommands;

	private bool keepHistory;

	private __MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__ _0024event_0024MotionChanged;

	private __MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__ _0024event_0024MotionChangedAfter;

	public Vector3 FixedTranslationDelta => translationDelta * DeltaTimeRate;

	public Vector3 TranslationDelta => translationDelta * DeltaTimeRate;

	public float DeltaTimeRate => (updateDeltaTime > 0f) ? (fixedUpdateDeltaTime / updateDeltaTime) : 0f;

	public float TimeScale
	{
		get
		{
			return timeScale;
		}
		set
		{
			enqueueCommand(Command.timeScale(value));
		}
	}

	public Transform YangEffectTransform => (!(baseTransform != null)) ? transform : baseTransform;

	public bool Pause
	{
		get
		{
			return pause > 0;
		}
		set
		{
			checked
			{
				if (value)
				{
					if (pause == 0 && TimeScale != 0f)
					{
						lastTimeScale = timeScale;
						TimeScale = 0f;
					}
					pause++;
					return;
				}
				if (pause > 0)
				{
					pause--;
				}
				if (pause == 0)
				{
					TimeScale = lastTimeScale;
				}
			}
		}
	}

	public float MotionTime => motionTime;

	public float MotionLength => (!(currentState == null)) ? currentState.length : 0f;

	public float MotionRemainingTime => (!(currentState != null)) ? 0f : ((!IsLoop) ? Mathf.Max(0f, currentState.length - currentState.time) : float.MaxValue);

	public bool IsEndOfMotion
	{
		get
		{
			int num;
			if (currentState == null)
			{
				num = 1;
			}
			else
			{
				num = ((!IsLoop) ? 1 : 0);
				if (num != 0)
				{
					num = ((!(MotionRemainingTime > 0f)) ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	public bool IsLoop
	{
		get
		{
			bool num = currentState.wrapMode == WrapMode.Loop;
			if (!num)
			{
				num = hasPartialLoopInfo();
			}
			return num;
		}
	}

	public float CurrentStateTime => currentState.time;

	public float PrevMotionTime => prevMotionTime;

	public string[] CurrentKeywords => (currentEntry != null) ? currentEntry.keywords : null;

	public bool RejectPlayRequest
	{
		get
		{
			return rejectPlayRequest;
		}
		set
		{
			rejectPlayRequest = value;
		}
	}

	public bool HasAnyCommands => commandQueue.Count > 0;

	public MerlinMotionPack[] AllPacks
	{
		get
		{
			System.Collections.Generic.List<MerlinMotionPack> list = new System.Collections.Generic.List<MerlinMotionPack>();
			foreach (PackInfo packInfo in packInfos)
			{
				if (packInfo.pack != null)
				{
					list.Add(packInfo.pack);
				}
			}
			return (MerlinMotionPack[])Builtins.array(typeof(MerlinMotionPack), list);
		}
	}

	public MerlinMotionPack.Entry executedEntryInThisFrame
	{
		get
		{
			return _executedEntryInThisFrame;
		}
		set
		{
			if (!logging || !RuntimeServices.EqualityOperator(value, _executedEntryInThisFrame))
			{
			}
			_executedEntryInThisFrame = value;
		}
	}

	public bool HasPlayCommand
	{
		get
		{
			IEnumerator enumerator = commandQueue.GetEnumerator();
			int result;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Command))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Command));
					}
					Command command = (Command)obj;
					CommandId id = command.id;
					if (id == CommandId.play || id == CommandId.playByName || id == CommandId.playByType || id == CommandId.playByReq)
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
	}

	public float BaseMovementScale
	{
		get
		{
			return baseMovementScale;
		}
		set
		{
			baseMovementScale = value;
		}
	}

	public string CurrentAnimName => currentAnimName;

	public int CurrentAnimType => currentAnimType;

	public AnimationClip CurrentClip => currentClip;

	public AnimationState CurrentAnimationState => currentState;

	public MerlinMotionPack.Entry CurrentEntry => currentEntry;

	public Transform CurrentBaseBone => cachedBaseBone;

	public System.Collections.Generic.List<PackInfo> PackInfos => packInfos;

	public float UpdateDeltaTime => updateDeltaTime;

	public float FixedUpdateDeltaTime => fixedUpdateDeltaTime;

	public bool Initialized => initialized;

	public event __MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__ MotionChanged
	{
		add
		{
			_0024event_0024MotionChanged = (__MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__)Delegate.Combine(_0024event_0024MotionChanged, value);
		}
		remove
		{
			_0024event_0024MotionChanged = (__MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__)Delegate.Remove(_0024event_0024MotionChanged, value);
		}
	}

	public event __MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__ MotionChangedAfter
	{
		add
		{
			_0024event_0024MotionChangedAfter = (__MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__)Delegate.Combine(_0024event_0024MotionChangedAfter, value);
		}
		remove
		{
			_0024event_0024MotionChangedAfter = (__MerlinMotionPackControl_MotionChanged_0024callable3_002462_28__)Delegate.Remove(_0024event_0024MotionChangedAfter, value);
		}
	}

	public MerlinMotionPackControl()
	{
		baseMode = true;
		history = new Queue<string>();
		historyExecs = new Queue<string>();
		baseMovementScale = 1f;
		timeScale = 1f;
		lastTimeScale = 1f;
		currentAnimType = -1;
		commandQueue = new ArrayList();
		packInfos = new System.Collections.Generic.List<PackInfo>();
		execCommands = new ArrayList();
	}

	[SpecialName]
	protected internal void raise_MotionChanged(MerlinMotionPackControl arg0, MerlinMotionPack.Entry arg1)
	{
		_0024event_0024MotionChanged?.Invoke(arg0, arg1);
	}

	[SpecialName]
	protected internal void raise_MotionChangedAfter(MerlinMotionPackControl arg0, MerlinMotionPack.Entry arg1)
	{
		_0024event_0024MotionChangedAfter?.Invoke(arg0, arg1);
	}

	public void setPartialLoop(float init, float start, float end)
	{
		if (init < 0f || start < 0f || end <= 0f || !(end > start))
		{
			throw new AssertionFailedException(new StringBuilder("ループ時間設定が init(").Append(init).Append(") <= start(").Append(start)
				.Append(") < end(")
				.Append(end)
				.Append(")でない")
				.ToString());
		}
		enqueueCommand(Command.setPartialLoop(init, start, end));
	}

	public bool isAtTime(float tm)
	{
		bool num = prevMotionTime < tm;
		if (num)
		{
			num = !(tm > motionTime);
		}
		return num;
	}

	public bool isPassed(float tm)
	{
		return !(tm > motionTime);
	}

	public bool isInTime(float start, float end)
	{
		bool num = isPassed(start);
		if (num)
		{
			num = !isPassed(end);
		}
		return num;
	}

	public bool isAnimType(int animType)
	{
		return currentAnimType == animType;
	}

	public bool isInCurrentKeywords(string kw)
	{
		return currentEntry != null && currentEntry.containsKeyword(kw);
	}

	public Command play(AnimationClip animClip)
	{
		return play(animClip, 0f);
	}

	public Command play(AnimationClip animClip, float crossFadeTime)
	{
		return rejectPlayRequest ? null : ((!(animClip != null)) ? null : enqueueCommand(Command.play(animClip, loop: false, crossFadeTime)));
	}

	public Command playLoop(AnimationClip animClip)
	{
		return playLoop(animClip, 0f);
	}

	public Command playLoop(AnimationClip animClip, float crossFadeTime)
	{
		return rejectPlayRequest ? null : ((!(animClip != null)) ? null : enqueueCommand(Command.play(animClip, loop: true, crossFadeTime)));
	}

	public void stop()
	{
		setStopCommand();
	}

	public Command playByName(string animName)
	{
		return playByName(animName, 0f);
	}

	public Command playByName(string animName, float crossFadeTime)
	{
		return (!rejectPlayRequest) ? enqueueCommand(Command.playByName(animName, crossFadeTime)) : null;
	}

	public Command play(string animName)
	{
		return playByName(animName);
	}

	public Command play(string animName, float crossFadeTime)
	{
		return playByName(animName, crossFadeTime);
	}

	public Command playIfNot(string animName)
	{
		return playIfNot(animName, 0f);
	}

	public Command playIfNot(string animName, float crossFadeTime)
	{
		return rejectPlayRequest ? null : ((!(animName == currentAnimName)) ? play(animName, crossFadeTime) : null);
	}

	public Command playByType(int typeID)
	{
		return playByType(typeID, 0f);
	}

	public Command playByType(int typeID, float crossFadeTime)
	{
		return (!rejectPlayRequest) ? enqueueCommand(Command.playByType(typeID, crossFadeTime)) : null;
	}

	public Command play(int typeID)
	{
		return playByType(typeID, 0f);
	}

	public Command play(int typeID, float crossFadeTime)
	{
		return playByType(typeID, crossFadeTime);
	}

	public Command playIfNot(int typeID)
	{
		return playIfNot(typeID, 0f);
	}

	public Command playByReq(PlayReq req)
	{
		if (req == null)
		{
			throw new AssertionFailedException("req != null");
		}
		return enqueueCommand(Command.playByReq(req));
	}

	public Command playIfNot(int typeID, float crossFadeTime)
	{
		return rejectPlayRequest ? null : ((typeID != currentAnimType) ? play(typeID, crossFadeTime) : null);
	}

	public void setLoopMode(bool loop)
	{
		enqueueCommand(Command.setLoopMode(loop));
	}

	public void setPlayTime(float time)
	{
		enqueueCommand(Command.setPlayTime(time));
	}

	public void setMotionTarget(GameObject go)
	{
		enqueueCommand(Command.motionTarget(go.animation));
	}

	public void setMotionTargetWithActivation(GameObject go, bool deactivateOld)
	{
		enqueueCommand(Command.motionTargetWithActivation(go.animation, deactivateOld));
	}

	public void resetBasePos()
	{
		enqueueCommand(Command.resetBasePos());
	}

	public void forceStop()
	{
		stopAndClearAllClips();
		commandQueue.Clear();
	}

	public void addMotionPack(MerlinMotionPack motPack)
	{
		if (!(motPack == null) && motPack != null)
		{
			enqueueCommand(Command.addPack(motPack));
		}
	}

	public void eraseMotionPackExceptWith(params MerlinMotionPack[] excludes)
	{
		execErasePack(excludes);
	}

	public void activateMotionPack(string motPackName, bool b)
	{
		if (!string.IsNullOrEmpty(motPackName))
		{
			enqueueCommand(Command.activateMotionPack(motPackName, b));
		}
	}

	public void activateMotionPackOnly(params string[] motPackNames)
	{
		if (!(motPackNames == null) && motPackNames.Length > 0)
		{
			enqueueCommand(Command.activateMotionPackOnly(motPackNames));
		}
	}

	public bool isActivatedMotionPacks(params string[] motPackNames)
	{
		int num = 0;
		int length = motPackNames.Length;
		int num2 = 0;
		checked
		{
			while (num2 < length)
			{
				string b = motPackNames[RuntimeServices.NormalizeArrayIndex(motPackNames, num2++)];
				System.Collections.Generic.List<PackInfo> list = packInfos;
				int count = ((ICollection)list).Count;
				int num3 = 0;
				while (num3 < count)
				{
					PackInfo packInfo = list[num3++];
					if (equals(packInfo.pack.Name, b) && packInfo.enabled)
					{
						num++;
					}
				}
			}
			return num == motPackNames.Length;
		}
	}

	public void setPackHighPrio(string motPackName)
	{
		if (!string.IsNullOrEmpty(motPackName))
		{
			enqueueCommand(Command.setPackPrio(motPackName, makeHigh: true));
		}
	}

	public void setPackLowPrio(string motPackName)
	{
		if (!string.IsNullOrEmpty(motPackName))
		{
			enqueueCommand(Command.setPackPrio(motPackName, makeHigh: false));
		}
	}

	public MerlinMotionPack getPack(string motPackName)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		object result;
		while (true)
		{
			if (num < count)
			{
				PackInfo packInfo = list[checked(num++)];
				if (equals(packInfo.pack.Name, motPackName))
				{
					result = packInfo.pack;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (MerlinMotionPack)result;
	}

	public float getPackMiscInfoAsSingle(string motPackName, string infoName, float defaultVal)
	{
		MerlinMotionPack pack = getPack(motPackName);
		return (!(pack != null)) ? defaultVal : pack.getSingleMiscInfo(infoName, defaultVal);
	}

	public float getPackMiscInfoAsSingle(string infoName, float defaultVal)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		float result;
		while (true)
		{
			if (num < count)
			{
				PackInfo packInfo = list[checked(num++)];
				if (!packInfo.enabled || !packInfo.pack.containsMiscInfo(infoName))
				{
					continue;
				}
				result = packInfo.pack.getSingleMiscInfo(infoName, defaultVal);
				break;
			}
			result = defaultVal;
			break;
		}
		return result;
	}

	public bool getPackMiscInfoAsBool(string infoName, bool defaultVal)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		bool result;
		while (true)
		{
			if (num < count)
			{
				PackInfo packInfo = list[checked(num++)];
				if (!packInfo.enabled || !packInfo.pack.containsMiscInfo(infoName))
				{
					continue;
				}
				bool boolMiscInfo = packInfo.pack.getBoolMiscInfo(infoName, defaultVal);
				result = boolMiscInfo;
				break;
			}
			result = defaultVal;
			break;
		}
		return result;
	}

	public bool getPackMiscInfoAsBool(string motPackName, string infoName, bool defaultVal)
	{
		MerlinMotionPack pack = getPack(motPackName);
		return (!(pack != null)) ? defaultVal : pack.getBoolMiscInfo(infoName, defaultVal);
	}

	public void setYangle(float yangle)
	{
		enqueueCommand(Command.setYangle(yangle));
	}

	public AnimationClip findClipByName(string animName)
	{
		return findEntryInPacks(animName)?.clip;
	}

	public bool containsOfName(string animName)
	{
		MerlinMotionPack.Entry entry = findEntryInPacks(animName, logWhenError: false);
		return entry != null;
	}

	public AnimationClip findClipByType(int typeID)
	{
		return findEntryInPacks(typeID)?.clip;
	}

	public bool containsOfType(int typeID)
	{
		MerlinMotionPack.Entry entry = findEntryInPacks(typeID, logWhenError: false);
		return entry != null;
	}

	public float clipLength(string animName)
	{
		AnimationClip animationClip = findClipByName(animName);
		return (!(animationClip != null)) ? 0f : animationClip.length;
	}

	public float clipLength(int typeID)
	{
		AnimationClip animationClip = findClipByType(typeID);
		return (!(animationClip != null)) ? 0f : animationClip.length;
	}

	public void enqueueStringToHistory(string str)
	{
		if (keepHistory)
		{
			history.Enqueue(str);
		}
	}

	private Command enqueueCommand(Command cmd)
	{
		if (cmd == null)
		{
			throw new AssertionFailedException("cmd != null");
		}
		commandQueue.Add(cmd);
		if (logging)
		{
			string text = new StringBuilder("enqueue: ").Append(cmd).ToString();
		}
		if (keepHistory)
		{
			string text = new StringBuilder("ADD ").Append((object)Time.frameCount).Append(" ").Append(cmd)
				.Append("\n")
				.ToString() + Environment.StackTrace;
			history.Enqueue(text);
			while (history.Count > 100)
			{
				history.Dequeue();
			}
		}
		return cmd;
	}

	private void clearPartialLoop()
	{
		partialLoopInit = 0f;
		partialLoopStart = 0f;
		partialLoopEnd = 0f;
	}

	private bool hasPartialLoopInfo()
	{
		return partialLoopEnd > partialLoopStart;
	}

	public void Awake()
	{
		initialize();
	}

	private void initialize()
	{
		if (keepHistory)
		{
			historyExecs.Enqueue(new StringBuilder().Append((object)Time.frameCount).Append(" initialize").ToString());
		}
		charController = YangEffectTransform.gameObject.GetComponent<CharacterController>();
		clearPartialLoop();
		packInfos.Clear();
		int i = 0;
		MerlinMotionPack[] array = motionPacks;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				packInfos.Add(new PackInfo(array[i]));
			}
		}
		initBaseBone();
		initExecuters();
		execMotionTarget((!(motionTarget != null)) ? animation : motionTarget, Command.ActivationTypes.NONE);
		initialized = true;
	}

	public void OnEnable()
	{
		if (motionTarget != null)
		{
			GameObject gameObject = motionTarget.gameObject;
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				gameObject.SetActive(value: false);
				gameObject.SetActive(value: true);
			}
			if (keepHistory)
			{
				historyExecs.Enqueue(new StringBuilder().Append((object)Time.frameCount).Append(" enabled (").Append(motionTarget.gameObject)
					.Append(")")
					.ToString());
			}
		}
	}

	public void OnDisable()
	{
		if (motionTarget != null)
		{
			GameObject gameObject = motionTarget.gameObject;
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
				gameObject.SetActive(value: true);
				gameObject.SetActive(value: false);
			}
			if (keepHistory)
			{
				historyExecs.Enqueue(new StringBuilder().Append((object)Time.frameCount).Append(" disabled (").Append(motionTarget.gameObject)
					.Append(")")
					.ToString());
			}
		}
	}

	public void OnDestroy()
	{
		unloadActivatedMotionAssets();
	}

	public void Update()
	{
		updateDeltaTime = Time.deltaTime * timeScale;
		if (currentActionExecuter != null)
		{
			currentActionExecuter.update();
		}
		executedEntryInThisFrame = null;
		execCommands.Clear();
		IEnumerator enumerator = commandQueue.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Command))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Command));
			}
			Command value = (Command)obj;
			execCommands.Add(value);
		}
		commandQueue.Clear();
		while (execCommands.Count > 0)
		{
			if (commandQueue.Count > 0)
			{
				int num = 0;
				int count = commandQueue.Count;
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < count)
				{
					int index = num;
					num++;
					execCommands.Insert(index, commandQueue[index]);
				}
				commandQueue.Clear();
			}
			Command command = execCommands[0] as Command;
			execCommands.RemoveAt(0);
			if (command != null)
			{
				currentExecutingCommand = command;
				if (logging)
				{
				}
				if (keepHistory)
				{
					string value2 = new StringBuilder("exec: ").Append(command).ToString();
					value2 = new StringBuilder().Append((object)Time.frameCount).Append(" ").Append(value2)
						.Append("\n")
						.ToString() + Environment.StackTrace;
					historyExecs.Enqueue(value2);
				}
				if (command.id == CommandId.play)
				{
					execPlayCommand(command.param as AnimationClip, RuntimeServices.UnboxBoolean(command.param2), RuntimeServices.UnboxSingle(command.param3));
				}
				else if (command.id == CommandId.playByName)
				{
					execPlayByNameCommand(command.param as string, RuntimeServices.UnboxSingle(command.param2));
				}
				else if (command.id == CommandId.playByType)
				{
					execPlayByTypeCommand(RuntimeServices.UnboxInt32(command.param), RuntimeServices.UnboxSingle(command.param2));
				}
				else if (command.id == CommandId.playByReq)
				{
					execPlayByReqCommand(command.param as PlayReq);
				}
				else if (command.id == CommandId.setLoopMode)
				{
					execSetLoopMode(RuntimeServices.UnboxBoolean(command.param));
				}
				else if (command.id == CommandId.setPlayTime)
				{
					execSetPlayTime(RuntimeServices.UnboxSingle(command.param));
				}
				else if (command.id == CommandId.stop)
				{
					execStopCommand();
				}
				else if (command.id == CommandId.timeScale)
				{
					execTimeScaleCommand(RuntimeServices.UnboxSingle(command.param));
				}
				else if (command.id == CommandId.motionTarget)
				{
					Command.ActivationTypes activationType = (Command.ActivationTypes)command.param2;
					execMotionTarget(command.param as Animation, activationType);
				}
				else if (command.id == CommandId.addPack)
				{
					execAddPack(command.param as MerlinMotionPack);
				}
				else if (command.id == CommandId.activateMotionPack)
				{
					execActivateMotionPack(command.param as string, RuntimeServices.UnboxBoolean(command.param2));
				}
				else if (command.id == CommandId.activateMotionPackOnly)
				{
					execActivateMotionPackOnly(command.param as string[]);
				}
				else if (command.id == CommandId.setPackPrio)
				{
					execSetPackPrioCommand(command.param as string, RuntimeServices.UnboxBoolean(command.param2));
				}
				else if (command.id == CommandId.setYangle)
				{
					execSetYangle(RuntimeServices.UnboxSingle(command.param));
				}
				else if (command.id == CommandId.setPartialLoop)
				{
					execSetLoopTime(RuntimeServices.UnboxSingle(command.param), RuntimeServices.UnboxSingle(command.param2), RuntimeServices.UnboxSingle(command.param3));
				}
				else if (command.id == CommandId.resetBasePos)
				{
					execResetBasePos();
				}
				command.isExecuted = true;
			}
		}
		processTimeScale();
		if (keepHistory)
		{
			while (historyExecs.Count > 100)
			{
				historyExecs.Dequeue();
			}
		}
	}

	public void cleanupCommandQueue()
	{
		int count = commandQueue.Count;
		int num = -1;
		bool flag = false;
		__ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__ _ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__ = delegate(int cmdid)
		{
			bool num4 = cmdid == 2;
			if (!num4)
			{
				num4 = cmdid == 3;
			}
			if (!num4)
			{
				num4 = cmdid == 1;
			}
			return num4;
		};
		__ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__ _ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__2 = delegate(int cmdid)
		{
			bool num3 = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable374_0024893_37__(Command.setPlayTime));
			if (!num3)
			{
				num3 = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable375_0024893_69__(Command.setLoopMode));
			}
			if (!num3)
			{
				num3 = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable376_0024893_101__(Command.setPartialLoop));
			}
			return num3;
		};
		int num2 = checked(count - 1);
		while (num2 >= 0)
		{
			if (!(commandQueue[num2] is Command { id: var id }))
			{
				continue;
			}
			if (num < 0)
			{
				if (_ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__((int)id))
				{
					num = num2;
				}
			}
			else if (_ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__2((int)id) || _ArrayMapMain_RangeToBoxIds_0024callable124_0024109_87__((int)id))
			{
				commandQueue.RemoveAt(num2);
				num2 = checked(num2 - 1);
			}
			num2 = checked(num2 - 1);
		}
	}

	public void LateUpdate()
	{
		if (motionTarget == null)
		{
			return;
		}
		if (currentState != null)
		{
			prevMotionTime = motionTime;
			motionTime = currentState.time;
		}
		if (motionTarget.clip != prevClip && prevClip == null)
		{
			motionChanged = true;
		}
		if (currentState != null)
		{
			if (currentState.wrapMode == WrapMode.Loop && !(currentState.normalizedTime < nextEndPoint))
			{
				motionChanged = true;
				nextEndPoint += 1f;
			}
			if (hasPartialLoopInfo())
			{
				AnimationState animationState = currentState;
				if (animationState.time >= animationState.length || !(animationState.time < partialLoopEnd))
				{
					animationState.time = partialLoopStart;
				}
			}
		}
		prevClip = motionTarget.clip;
		Vector3 zero = Vector3.zero;
		if (cachedBaseBone != null && baseMode)
		{
			if (motionChanged)
			{
				prevBasePos = zero;
			}
			Vector3 localPosition = cachedBaseBone.localPosition;
			localPosition *= baseMovementScale;
			cachedBaseBone.localPosition = localPosition;
			Vector3 v = localPosition - prevBasePos;
			translationDelta = YangEffectTransform.localToWorldMatrix.MultiplyVector(v);
			if ((bool)charController)
			{
				motionTarget.transform.localPosition = -localPosition;
			}
			else if (cachedBaseBone != YangEffectTransform)
			{
				cachedBaseBone.localPosition = zero;
				if (motionTarget.transform != YangEffectTransform)
				{
					motionTarget.transform.localPosition = zero;
					YangEffectTransform.position += translationDelta;
				}
				else
				{
					YangEffectTransform.position += translationDelta;
				}
			}
			prevBasePos = localPosition;
		}
		motionChanged = false;
	}

	public void FixedUpdate()
	{
		fixedUpdateDeltaTime = Time.fixedDeltaTime * timeScale;
	}

	private void execStopCommand()
	{
		stopAndClearAllClips();
	}

	private void execTimeScaleCommand(float scale)
	{
		if (!(scale >= 0f))
		{
			throw new AssertionFailedException("MerlinMotionPackControl.TimeScale に負は指定できません");
		}
		hasReqTimeScale = true;
		reqTimeScale = scale;
	}

	private void processTimeScale()
	{
		if (hasReqTimeScale)
		{
			hasReqTimeScale = false;
			timeScale = reqTimeScale;
			initAllStateTimeScale();
		}
	}

	private void execPlayCommand(AnimationClip clip, bool loop, float crossFadeTime)
	{
		motionChanged = setAnimation(clip, MerlinMotionPack.PlayMode.UseWrapMode, crossFadeTime);
		currentAnimName = null;
		currentAnimType = -1;
		if (currentState != null && loop)
		{
			currentState.wrapMode = WrapMode.Loop;
		}
	}

	private void execPlayByNameCommand(string animName, float crossFadeTime)
	{
		MerlinMotionPack.Entry entry = findEntryInPacks(animName);
		if (entry != null && execPlayPackClip(entry, crossFadeTime))
		{
			currentAnimName = animName;
			currentAnimType = -1;
		}
	}

	private void execPlayByTypeCommand(int type, float crossFadeTime)
	{
		PlayReq req = new PlayReq(type, null, crossFadeTime);
		execPlayByReqCommand(req);
	}

	private void execPlayByReqCommand(PlayReq req)
	{
		if (req == null)
		{
			throw new AssertionFailedException("req != null");
		}
		MerlinMotionPack.Entry entry = null;
		if (req.HasTypeID)
		{
			entry = findEntryInPacks(req.typeID, req.keywords, logWhenError: true);
		}
		else
		{
			if (!req.HasAnimName)
			{
				string text = "request has neither typeID or animName.";
				return;
			}
			entry = findEntryInPacks(req.animName, req.keywords, logWhenError: true);
		}
		if (entry != null && execPlayPackClip(entry, req.fadeTime))
		{
			currentAnimName = null;
			currentAnimType = req.typeID;
		}
	}

	private void execSetLoopMode(bool loop)
	{
		if (!(currentState == null) && loop)
		{
			currentState.wrapMode = WrapMode.Loop;
		}
	}

	private void execSetPlayTime(float time)
	{
		if (!(currentState == null))
		{
			currentState.time = time;
			motionChanged = true;
		}
	}

	private bool execPlayPackClip(MerlinMotionPack.Entry entry, float crossFadeTime)
	{
		if (entry == null)
		{
			throw new AssertionFailedException(new StringBuilder("entry == null OBJECT=").Append(gameObject.name).ToString());
		}
		int result;
		if (!entry.IsValid)
		{
			result = 0;
		}
		else if (entry.Executer == null)
		{
			result = 0;
		}
		else
		{
			motionChanged = setAnimation(entry.clip, entry.playMode, crossFadeTime);
			if (motionChanged)
			{
				currentAnimName = entry.name;
				currentAnimType = entry.Executer.Parent.clipNameToTypeID(currentAnimName);
				currentEntry = entry;
			}
			executedEntryInThisFrame = entry;
			if (entry != null)
			{
				doMotionChanged();
			}
			if (logging)
			{
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private void doMotionChanged()
	{
		if (executedEntryInThisFrame != null)
		{
			MerlinMotionPack.Entry entry = executedEntryInThisFrame;
			raise_MotionChanged(this, entry);
			currentActionExecuter = entry.Executer;
			lastExecutedMotDefResult = currentActionExecuter.executeMotDefMethod(entry);
			lastExecutedMotDefEntry = entry;
			currentActionExecuter.execute(entry);
			raise_MotionChangedAfter(this, entry);
		}
	}

	private void execMotionTarget(Animation anim, Command.ActivationTypes activationType)
	{
		if (anim != null)
		{
			if (logging)
			{
			}
			Animation animation = motionTarget;
			if (baseMode && anim != null && animation != null && animation != anim)
			{
				anim.transform.localPosition = animation.transform.localPosition;
			}
			motionTarget = anim;
			motionTarget.cullingType = AnimationCullingType.AlwaysAnimate;
			if (activationType != 0)
			{
				motionTarget.gameObject.SetActive(value: true);
				motionTarget.enabled = false;
				motionTarget.enabled = true;
			}
			if (activationType == Command.ActivationTypes.DEACTIVATION_AND_ACTIVATION && animation != null && animation != motionTarget)
			{
				animation.gameObject.SetActive(value: false);
			}
			initBaseBone();
		}
		else
		{
			stopAndClearAllClips();
			motionTarget = null;
		}
	}

	private void execAddPack(MerlinMotionPack pack)
	{
		_0024execAddPack_0024locals_002414268 _0024execAddPack_0024locals_0024 = new _0024execAddPack_0024locals_002414268();
		_0024execAddPack_0024locals_0024._0024pack = pack;
		if (!(_0024execAddPack_0024locals_0024._0024pack == null) && packInfos.Find(_0024adaptor_0024__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33___0024Predicate_00241.Adapt(new _0024execAddPack_0024closure_00243822(_0024execAddPack_0024locals_0024).Invoke)) == null)
		{
			packInfos.Insert(0, new PackInfo(_0024execAddPack_0024locals_0024._0024pack));
			initBaseBone();
			initExecuters();
		}
	}

	private void execErasePack(MerlinMotionPack[] excludes)
	{
		if (excludes == null)
		{
			excludes = new MerlinMotionPack[0];
		}
		int i = 0;
		PackInfo[] array = (PackInfo[])Builtins.array(typeof(PackInfo), packInfos);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!RuntimeServices.op_Member(array[i].pack, excludes))
			{
				packInfos.Remove(array[i]);
				array[i].dispose();
			}
		}
		initBaseBone();
		initExecuters();
	}

	private static bool equals(string a, string b)
	{
		return (a == null && b == null) || a.ToLower() == b.ToLower();
	}

	private void execActivateMotionPack(string packName, bool b)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		while (num < count)
		{
			PackInfo packInfo = list[checked(num++)];
			if (equals(packInfo.pack.Name, packName))
			{
				packInfo.enabled = b;
				if (!logging)
				{
				}
				break;
			}
		}
	}

	private void execActivateMotionPackOnly(string[] packNames)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		checked
		{
			while (num < count)
			{
				PackInfo packInfo = list[num++];
				packInfo.enabled = false;
			}
			int length = packNames.Length;
			int num2 = 0;
			while (num2 < length)
			{
				string b = packNames[RuntimeServices.NormalizeArrayIndex(packNames, num2++)];
				bool flag = false;
				System.Collections.Generic.List<PackInfo> list2 = packInfos;
				int count2 = ((ICollection)list2).Count;
				int num3 = 0;
				while (num3 < count2)
				{
					PackInfo packInfo = list2[num3++];
					if (equals(packInfo.pack.Name, b))
					{
						packInfo.enabled = true;
						flag = true;
						break;
					}
				}
				if (flag)
				{
				}
			}
		}
	}

	private void execSetPackPrioCommand(string packName, bool makeHigh)
	{
		_0024execSetPackPrioCommand_0024locals_002414269 _0024execSetPackPrioCommand_0024locals_0024 = new _0024execSetPackPrioCommand_0024locals_002414269();
		_0024execSetPackPrioCommand_0024locals_0024._0024packName = packName;
		PackInfo packInfo = packInfos.Find(_0024adaptor_0024__MerlinMotionPackControl_execAddPack_0024callable372_00241174_33___0024Predicate_00241.Adapt(new _0024execSetPackPrioCommand_0024closure_00243827(_0024execSetPackPrioCommand_0024locals_0024).Invoke));
		if (packInfo != null)
		{
			packInfos.Remove(packInfo);
			if (makeHigh)
			{
				packInfos.Insert(0, packInfo);
			}
			else
			{
				packInfos.Add(packInfo);
			}
		}
	}

	private void execSetYangle(float yangle)
	{
		Vector3 eulerAngles = YangEffectTransform.eulerAngles;
		eulerAngles.y = yangle;
		YangEffectTransform.eulerAngles = eulerAngles;
	}

	private void execResetBasePos()
	{
		if (cachedBaseBone != null)
		{
			cachedBaseBone.localPosition = Vector3.zero;
			prevBasePos = Vector3.zero;
		}
	}

	private void execSetLoopTime(float init, float start, float end)
	{
		partialLoopInit = init;
		partialLoopStart = start;
		partialLoopEnd = end;
		if (!hasPartialLoopInfo())
		{
			throw new AssertionFailedException(new StringBuilder("ループ時間設定が init(").Append(init).Append(") <= start(").Append(start)
				.Append(") < end(")
				.Append(end)
				.Append(")でない")
				.ToString());
		}
		if (currentState != null)
		{
			currentState.wrapMode = WrapMode.ClampForever;
			currentState.time = init;
		}
	}

	private void initBaseBone()
	{
		Transform transform = cachedBaseBone;
		string n = "y_ang";
		if (((ICollection)packInfos).Count > 0)
		{
			string baseBoneName = packInfos[0].pack.baseBoneName;
			bool flag = false;
			System.Collections.Generic.List<PackInfo> list = packInfos;
			int count = ((ICollection)list).Count;
			int num = 0;
			while (num < count)
			{
				PackInfo packInfo = list[checked(num++)];
				MerlinMotionPack pack = packInfo.pack;
				if (pack.baseBoneName != baseBoneName)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				n = baseBoneName;
			}
		}
		if (motionTarget != null)
		{
			cachedBaseBone = ExtensionsModule.FindInDescendants(motionTarget.transform, n);
		}
		else
		{
			cachedBaseBone = ExtensionsModule.FindInDescendants(YangEffectTransform, n);
		}
		motionChanged = cachedBaseBone != transform;
		if (!logging)
		{
		}
	}

	private void initExecuters()
	{
		if (((ICollection)packInfos).Count <= 0)
		{
			return;
		}
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		while (num < count)
		{
			PackInfo packInfo = list[checked(num++)];
			if (packInfo.executer == null)
			{
				MerlinMotionPack pack = packInfo.pack;
				Component component = YangEffectTransform.gameObject.GetComponent(pack.TargetType);
				if (component == null)
				{
				}
				MerlinMotionPack.Executer executer = pack.createMotionOperationExecuter(YangEffectTransform.gameObject);
				if (executer != null)
				{
					packInfo.executer = executer;
					executer.init();
				}
			}
		}
	}

	private void setStopCommand()
	{
		enqueueCommand(Command.stop());
		motionChanged = true;
	}

	private bool setAnimation(AnimationClip clip, MerlinMotionPack.PlayMode playMode, float crossFadeTime)
	{
		int result;
		if (clip == null)
		{
			result = 0;
		}
		else
		{
			oldClip = currentClip;
			stopAndClearAllClips();
			currentEntry = null;
			currentClip = clip;
			currentState = null;
			motionTime = 0f;
			prevMotionTime = 0f;
			if (motionTarget != null)
			{
				motionTarget.AddClip(clip, clip.name);
				if (!(crossFadeTime > 0f))
				{
					motionTarget.Play(clip.name, PlayMode.StopAll);
				}
				else
				{
					motionTarget.CrossFade(clip.name, crossFadeTime);
				}
				currentState = motionTarget[clip.name];
			}
			initAllStateTimeScale();
			nextEndPoint = 1f;
			if (currentState != null)
			{
				switch (playMode)
				{
				case MerlinMotionPack.PlayMode.UseWrapMode:
				{
					WrapMode wrapMode = clip.wrapMode;
					if (wrapMode == WrapMode.Default || wrapMode == WrapMode.Once)
					{
						currentState.wrapMode = WrapMode.ClampForever;
					}
					break;
				}
				case MerlinMotionPack.PlayMode.Clamp:
					currentState.wrapMode = WrapMode.ClampForever;
					break;
				case MerlinMotionPack.PlayMode.Loop:
					currentState.wrapMode = WrapMode.Loop;
					break;
				}
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private void stopAndClearAllClips()
	{
		currentClip = null;
		if (currentActionExecuter != null)
		{
			currentActionExecuter.stop();
		}
		currentActionExecuter = null;
		clearPartialLoop();
		if (motionTarget != null)
		{
			motionTarget.clip = null;
		}
	}

	private void initAllStateTimeScale()
	{
		if (motionTarget == null)
		{
			return;
		}
		IEnumerator enumerator = motionTarget.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			animationState.speed = timeScale;
		}
	}

	private MerlinMotionPack.Entry findEntryInPacks(string animName)
	{
		return findEntryInPacks(animName, logWhenError: true);
	}

	private MerlinMotionPack.Entry findEntryInPacks(string animName, bool logWhenError)
	{
		return findEntryInPacks(animName, null, logWhenError);
	}

	private MerlinMotionPack.Entry findEntryInPacks(string animName, string[] keywords, bool logWhenError)
	{
		object result;
		if (((ICollection)packInfos).Count <= 0)
		{
			if (logWhenError)
			{
			}
			result = null;
		}
		else
		{
			System.Collections.Generic.List<PackInfo> list = packInfos;
			int count = ((ICollection)list).Count;
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					PackInfo packInfo = list[checked(num++)];
					MerlinMotionPack.Executer executer = packInfo.executer;
					if (!packInfo.enabled || executer == null)
					{
						continue;
					}
					if (keywords == null)
					{
						MerlinMotionPack.Entry entry = executer.findEntry(animName);
						if (entry != null)
						{
							result = entry;
							break;
						}
					}
					else
					{
						Boo.Lang.List<MerlinMotionPack.Entry> list2 = executer.findEntriesByKeywords(animName, keywords);
						if (list2 != null && ((ICollection)list2).Count > 0)
						{
							result = list2[0];
							break;
						}
					}
					continue;
				}
				if (keywords != null)
				{
					MerlinMotionPack.Entry entry2 = findEntryInPacks(animName, null, logWhenError);
					if (entry2 != null)
					{
						result = entry2;
						break;
					}
				}
				if (logWhenError)
				{
				}
				result = null;
				break;
			}
		}
		return (MerlinMotionPack.Entry)result;
	}

	private MerlinMotionPack.Entry findEntryInPacks(int typeID)
	{
		return findEntryInPacks(typeID, logWhenError: true);
	}

	private MerlinMotionPack.Entry findEntryInPacks(int typeID, bool logWhenError)
	{
		return findEntryInPacks(typeID, null, logWhenError);
	}

	private MerlinMotionPack.Entry findEntryInPacks(int typeID, string[] keywords, bool logWhenError)
	{
		object result;
		if (((ICollection)packInfos).Count <= 0)
		{
			if (logWhenError)
			{
			}
			result = null;
		}
		else
		{
			System.Collections.Generic.List<PackInfo> list = packInfos;
			int count = ((ICollection)list).Count;
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					PackInfo packInfo = list[checked(num++)];
					MerlinMotionPack.Executer executer = packInfo.executer;
					if (!packInfo.enabled || executer == null)
					{
						continue;
					}
					if (keywords == null)
					{
						MerlinMotionPack.Entry entry = executer.findEntry(typeID);
						if (entry != null)
						{
							result = entry;
							break;
						}
					}
					else
					{
						MerlinMotionPack.Entry entry = executer.findEntryByKeywords(typeID, keywords);
						if (entry != null)
						{
							result = entry;
							break;
						}
					}
					continue;
				}
				if (keywords != null)
				{
					MerlinMotionPack.Entry entry2 = findEntryInPacks(typeID, null, logWhenError);
					if (entry2 != null)
					{
						result = entry2;
						break;
					}
				}
				if (logWhenError)
				{
				}
				result = null;
				break;
			}
		}
		return (MerlinMotionPack.Entry)result;
	}

	public bool hasEntry(int typeID)
	{
		System.Collections.Generic.List<PackInfo> list = packInfos;
		int count = ((ICollection)list).Count;
		int num = 0;
		int result;
		while (true)
		{
			if (num < count)
			{
				PackInfo packInfo = list[checked(num++)];
				MerlinMotionPack.Executer executer = packInfo.executer;
				if (!packInfo.enabled || executer == null || !executer.hasEntry(typeID))
				{
					continue;
				}
				result = 1;
				break;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public bool loadClip(string mot)
	{
		_0024loadClip_0024locals_002414270 _0024loadClip_0024locals_0024 = new _0024loadClip_0024locals_002414270();
		_0024loadClip_0024locals_0024._0024mot = mot;
		bool flag;
		int result;
		if (!string.IsNullOrEmpty(_0024loadClip_0024locals_0024._0024mot))
		{
			foreach (PackInfo packInfo in packInfos)
			{
				MerlinMotionPack pack = packInfo.pack;
				if (!pack.contains(_0024loadClip_0024locals_0024._0024mot))
				{
					continue;
				}
				pack.loadClip(_0024loadClip_0024locals_0024._0024mot, new _0024loadClip_0024closure_00243833(packInfo, _0024loadClip_0024locals_0024, this).Invoke);
				flag = true;
				goto IL_009d;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		goto IL_009f;
		IL_009f:
		return (byte)result != 0;
		IL_009d:
		result = (flag ? 1 : 0);
		goto IL_009f;
	}

	public bool isLoaded(string mot)
	{
		bool flag;
		foreach (PackInfo packInfo in packInfos)
		{
			MerlinMotionPack pack = packInfo.pack;
			if (!pack.contains(mot))
			{
				continue;
			}
			flag = pack.isLoaded(mot);
			goto IL_0059;
		}
		int result = 0;
		goto IL_005a;
		IL_0059:
		result = (flag ? 1 : 0);
		goto IL_005a;
		IL_005a:
		return (byte)result != 0;
	}

	public MerlinMotionPackEffectLoader[] loadEffects()
	{
		System.Collections.Generic.List<MerlinMotionPackEffectLoader> list = new System.Collections.Generic.List<MerlinMotionPackEffectLoader>();
		foreach (PackInfo packInfo in packInfos)
		{
			if (packInfo.executer != null)
			{
				MerlinMotionPackEffectLoader merlinMotionPackEffectLoader = packInfo.executer.loadEffectsForLoadedMotions();
				if (merlinMotionPackEffectLoader != null)
				{
					list.Add(merlinMotionPackEffectLoader);
				}
			}
		}
		return (MerlinMotionPackEffectLoader[])Builtins.array(typeof(MerlinMotionPackEffectLoader), list);
	}

	public void loadActivatedMotionAssets()
	{
		foreach (PackInfo packInfo in packInfos)
		{
			if (!(packInfo.pack == null) && packInfo.executer != null)
			{
				packInfo.executer.loadSoundEffectsForLoadedMotions(null);
			}
		}
	}

	public void unloadActivatedMotionAssets()
	{
		foreach (PackInfo packInfo in packInfos)
		{
			if (!(packInfo.pack == null))
			{
				packInfo.dispose();
			}
		}
		packInfos.Clear();
	}

	internal bool _0024cleanupCommandQueue_0024isPlayCommand_00242904(int cmdid)
	{
		bool num = cmdid == 2;
		if (!num)
		{
			num = cmdid == 3;
		}
		if (!num)
		{
			num = cmdid == 1;
		}
		return num;
	}

	internal bool _0024cleanupCommandQueue_0024isPlayConfiCommand_00242905(int cmdid)
	{
		bool num = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable374_0024893_37__(Command.setPlayTime));
		if (!num)
		{
			num = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable375_0024893_69__(Command.setLoopMode));
		}
		if (!num)
		{
			num = RuntimeServices.EqualityOperator(cmdid, new __MerlinMotionPackControl__0024cleanupCommandQueue_0024isPlayConfiCommand_00242905_0024callable376_0024893_101__(Command.setPartialLoop));
		}
		return num;
	}
}
