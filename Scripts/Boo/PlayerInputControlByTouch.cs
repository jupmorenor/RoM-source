using System;
using System.Runtime.CompilerServices;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PlayerInputControlByTouch : PlayerInputControl
{
	[Serializable]
	public class CurrentFrameInfo
	{
		public bool noAttack;

		public void clear()
		{
			noAttack = false;
		}
	}

	private TouchMarker marker;

	private TouchBasicInfo curTouch;

	private TouchBasicInfo preTouch;

	private TouchRayInfo curRayInfo;

	private TouchRayInfo preRayInfo;

	private ConditionalTimer runStopTimer;

	private DisplacementMeasure displacementMeasure;

	private bool reqTap;

	private bool reqSwipe;

	private float reqSwipeDir;

	private bool reqDoubleTap;

	private DoubleTapMovingControl doubleTapMovingControl;

	private CurrentFrameInfo curFrameInfo;

	private __PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27__ _0024event_0024OnTouchEvent;

	public override PlayerInputControlType Type => PlayerInputControlType.ByTouch;

	public bool IsTapped
	{
		get
		{
			bool touchUp = curTouch.TouchUp;
			if (!touchUp)
			{
				touchUp = reqTap;
			}
			return touchUp;
		}
	}

	public TouchMarker Marker => marker;

	public TouchBasicInfo CurTouch => curTouch;

	public TouchBasicInfo PreTouch => preTouch;

	public TouchRayInfo CurRayInfo => curRayInfo;

	public TouchRayInfo PreRayInfo => preRayInfo;

	public ConditionalTimer RunStopTimer => runStopTimer;

	public DisplacementMeasure DisplacementMeasure => displacementMeasure;

	public event __PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27__ OnTouchEvent
	{
		add
		{
			_0024event_0024OnTouchEvent = (__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27__)Delegate.Combine(_0024event_0024OnTouchEvent, value);
		}
		remove
		{
			_0024event_0024OnTouchEvent = (__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27__)Delegate.Remove(_0024event_0024OnTouchEvent, value);
		}
	}

	public PlayerInputControlByTouch(PlayerControl _player)
		: base(_player)
	{
		marker = new TouchMarker();
		curTouch = new TouchBasicInfo();
		preTouch = new TouchBasicInfo();
		curRayInfo = new TouchRayInfo();
		preRayInfo = new TouchRayInfo();
		doubleTapMovingControl = new DoubleTapMovingControl();
		curFrameInfo = new CurrentFrameInfo();
		init();
	}

	[SpecialName]
	protected internal void raise_OnTouchEvent(PlayerInputControlByTouch arg0, Vector3 arg1)
	{
		_0024event_0024OnTouchEvent?.Invoke(arg0, arg1);
	}

	protected override void doOnTap()
	{
		reqTap = true;
	}

	protected override void doOnSwipe(float dir, int fingerId)
	{
		reqSwipe = true;
		reqSwipeDir = dir;
	}

	protected override void doOnDoubleTap()
	{
		reqDoubleTap = true;
		reqTap = false;
	}

	private void init()
	{
		curTouch.clear();
		preTouch.clear();
		curRayInfo.clear();
		preRayInfo.clear();
		marker.clear();
		initRunStopTimer();
		displacementMeasure = new DisplacementMeasure();
		doubleTapMovingControl.disable();
		reqTap = false;
		reqSwipe = false;
		reqDoubleTap = false;
	}

	private void initRunStopTimer()
	{
		runStopTimer = new ConditionalTimer();
		runStopTimer.CallbackTime = 1f;
		runStopTimer.Condition = () => Player.isRun() && Player.IsNonBattleMode && !curTouch.Touch && displacementMeasure.length <= 0.003f;
		runStopTimer.Callback = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			marker.deleteMark();
			ActionInput.clearMove();
			doubleTapMovingControl.disable();
		};
	}

	protected override void doPause()
	{
		if (UICamera.allowMultiTouch)
		{
		}
		UICamera.allowMultiTouch = false;
	}

	protected override void doClear()
	{
		if (UICamera.allowMultiTouch)
		{
		}
		UICamera.allowMultiTouch = false;
		init();
	}

	protected override void doUpdate(float dt)
	{
		if (!UICamera.allowMultiTouch)
		{
		}
		UICamera.allowMultiTouch = true;
		if (dt > 0f)
		{
			displacementMeasure.updateCurrentPos(dt, Player.MYPOS);
			deleteMarkerCheck();
			updateBasicInfo(dt);
			updateRayInfo();
			updateLockOn(dt);
			setActionInputs(dt);
			runStopTimer.update(dt);
			reqTap = false;
			reqSwipe = false;
			reqDoubleTap = false;
		}
	}

	protected override void doOnEnable()
	{
	}

	protected override void doOnDisable()
	{
		UICamera.allowMultiTouch = false;
	}

	private void updateBasicInfo(float dt)
	{
		TouchBasicInfo touchBasicInfo = curTouch;
		curTouch = preTouch;
		preTouch = touchBasicInfo;
		curTouch.update(dt);
	}

	private void updateRayInfo()
	{
		TouchRayInfo touchRayInfo = curRayInfo;
		curRayInfo = preRayInfo;
		preRayInfo = touchRayInfo;
		curRayInfo.updateTouchInfo(curTouch.Touch, curTouch.ScrnPos);
	}

	private void updateLockOn(object dt)
	{
		if (LockOnControl != null)
		{
			if (preRayInfo.Enemy.Touch && !curRayInfo.Enemy.Touch)
			{
				LockOnControl.startLockOn(preRayInfo.Enemy.hitObject);
			}
			if (IsTapped)
			{
				LockOnControl.searchAndStartIfNotLockedOn();
			}
			if (curTouch.TouchNum >= 2 && preTouch.TouchNum < 2)
			{
				LockOnControl.searchAndStartIfNotLockedOn();
			}
		}
	}

	private void setActionInputs(float dt)
	{
		curFrameInfo.clear();
		setMovingInputs();
		setAttackInputs();
		doubleTapMovingControl.update(ActionInput, Player.MYPOS);
	}

	private void deleteMarkerCheck()
	{
		if (marker.IsMarked)
		{
			if (Player.isKaihi())
			{
				marker.deleteMark();
			}
			if (Player.isActionType(ActionTypes.Yarare))
			{
				marker.deleteMark();
			}
			if (Player.isActionType(ActionTypes.Attack))
			{
				marker.deleteMark();
			}
			if (Player.isActionType(ActionTypes.Skill))
			{
				marker.deleteMark();
			}
			if (Player.isActionType(ActionTypes.Magic))
			{
				marker.deleteMark();
			}
		}
	}

	private void setMovingInputs()
	{
		MerlinActionInput actionInput = ActionInput;
		bool num = !preRayInfo.Plane.Touch;
		if (num)
		{
			num = curRayInfo.Plane.Touch;
		}
		bool flag = num;
		if (reqDoubleTap)
		{
			Vector3 forward = Player.transform.forward;
			doubleTapMovingControl.enable(Player.MYPOS + forward * 100f);
			marker.deleteMark();
		}
		if (doubleTapMovingControl.Active)
		{
			if (!reqSwipe && !reqTap && !LockOnControl.IsLockedOn && !flag)
			{
				return;
			}
			doubleTapMovingControl.disable();
		}
		if (reqSwipe)
		{
			actionInput.kaihi(reqSwipeDir);
			return;
		}
		if (marker.IsMarked)
		{
			actionInput.move(marker.MarkedPos);
			if (curRayInfo.Plane.Touch)
			{
				marker.deleteMark();
			}
			else if (!(marker.distanceTo(Player.MYPOS) >= 0.2f))
			{
				marker.deleteMark();
			}
			else if (!(preTouch.TouchTime <= 0.2f))
			{
				marker.deleteMark();
			}
		}
		else
		{
			TouchRayInfo.Info plane = curRayInfo.Plane;
			if (plane.Touch)
			{
				float num2 = plane.distanceTo(Player.MYPOS);
				if (num2 > 1.2f || (Player.isRun() && !(num2 <= 0.2f)))
				{
					actionInput.move(curRayInfo.Plane.Point);
					raise_OnTouchEvent(this, curRayInfo.Plane.Point);
				}
			}
			else if (preRayInfo.Plane.Touch && !curRayInfo.Plane.Touch)
			{
				actionInput.move(preRayInfo.Plane.Point);
				if (!(preTouch.TouchTime <= 0.2f))
				{
					actionInput.clearMove();
					curFrameInfo.noAttack = true;
				}
				else
				{
					marker.newMark(preRayInfo.Plane.Point);
				}
			}
		}
		if (!(LockOnControl.Distance >= 0.1f))
		{
			actionInput.clearMove();
		}
	}

	private void setAttackInputs()
	{
		float distance = LockOnControl.Distance;
		MerlinActionInput actionInput = ActionInput;
		if (!LockOnControl.IsLockedOn || curFrameInfo.noAttack)
		{
			actionInput.clearAttack();
			return;
		}
		if (!(curTouch.TouchTime <= 0.02f))
		{
			actionInput.clearAttack();
			return;
		}
		if (IsTapped && !(preTouch.TouchTime > 0.02f))
		{
			if (!(distance > Player.TapNormalAttackDistance))
			{
				actionInput.attack(1);
				actionInput.clearMove();
			}
			else if (!(distance > Player.TapRunAttackDistance))
			{
				actionInput.runAttack();
				actionInput.clearMove();
			}
		}
		if (IsAutoCombination)
		{
			if (!Player.isIdle() && !Player.isRun())
			{
				actionInput.attack(1);
				actionInput.runAttack();
				actionInput.clearMove();
			}
			else if (IsTapped)
			{
				actionInput.attack(1);
				actionInput.runAttack();
			}
		}
		else if (IsTapped)
		{
			actionInput.attack(1);
			actionInput.runAttack();
		}
		if (actionInput != null)
		{
			doubleTapMovingControl.disable();
		}
	}

	protected override void doOnGUI()
	{
		GUILayout.Label("double tap active: " + doubleTapMovingControl.Active);
		GUILayout.Label("double tap moveDir: " + doubleTapMovingControl.MoveDir);
		GUILayout.Label("double tap updated: " + doubleTapMovingControl.Updated);
		GUILayout.Label("curFrameInfo.noAttack: " + curFrameInfo.noAttack);
	}

	internal bool _0024initRunStopTimer_0024closure_00243905()
	{
		return Player.isRun() && Player.IsNonBattleMode && !curTouch.Touch && displacementMeasure.length <= 0.003f;
	}

	internal void _0024initRunStopTimer_0024closure_00243906()
	{
		marker.deleteMark();
		ActionInput.clearMove();
		doubleTapMovingControl.disable();
	}
}
