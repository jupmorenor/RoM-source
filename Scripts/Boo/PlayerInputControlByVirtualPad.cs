using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PlayerInputControlByVirtualPad : PlayerInputControl
{
	[NonSerialized]
	public static float MoveStartDistThreashold = 10f;

	private int moveFingerId;

	private Vector2 moveBasePos;

	private Vector2 moveTouchDif;

	private Vector2 moveTouchDifNorm;

	private Boo.Lang.List<MTouch> touches;

	private TouchRayInfo atkRayInfo;

	private int attackingFingerId;

	[NonSerialized]
	private static readonly Rect LEFT_SIDE = new Rect(0f, 0f, (float)Screen.width * 0.5f, Screen.height);

	[NonSerialized]
	private static readonly Rect RIGHT_SIDE = new Rect((float)Screen.width * 0.5f, 0f, (float)Screen.width * 0.5f, Screen.height);

	private InputSwipeRecognizer swipeRecognizer;

	private bool reqDoubleTap;

	public override PlayerInputControlType Type => PlayerInputControlType.ByVirtualPad;

	public PlayerInputControlByVirtualPad(PlayerControl _player)
		: base(_player)
	{
		moveFingerId = -1;
		touches = new Boo.Lang.List<MTouch>();
		atkRayInfo = new TouchRayInfo();
		attackingFingerId = -1;
		swipeRecognizer = new InputSwipeRecognizer();
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
		atkRayInfo.clear();
		moveTouchDif = Vector2.zero;
		moveTouchDifNorm = Vector2.zero;
		attackingFingerId = -1;
		swipeRecognizer.clear();
	}

	protected override void doUpdate(float dt)
	{
		if (!UICamera.allowMultiTouch)
		{
		}
		UICamera.allowMultiTouch = true;
		updateTouches();
		lockOn();
		controlMove();
		controlAttack();
		processExternalEvents();
	}

	private void updateTouches()
	{
		touches.Clear();
		int i = 0;
		Touch[] array = Input.touches;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			touches.Add(new MTouch(array[i]));
		}
		swipeRecognizer.update(touches, Time.deltaTime);
	}

	private new void lockOn()
	{
		PlayerLockOnControl lockOnControl = LockOnControl;
		if (findBeganInRect(RIGHT_SIDE) != 0 && !lockOnControl.IsLockedOn)
		{
			lockOnControl.searchAndStart();
		}
		if (reqDoubleTap && !lockOnControl.IsLockedOn)
		{
			lockOnControl.searchAndStart();
		}
	}

	private void controlMove()
	{
		MerlinActionInput actionInput = ActionInput;
		if (moveFingerId < 0)
		{
			moveFingerId = findBeganInRect(LEFT_SIDE);
			if (moveFingerId >= 0)
			{
				moveBasePos = touchPos(moveFingerId);
				VirtualPadUIRoot.ShowVirtualPad(moveBasePos);
			}
			return;
		}
		if (VirtualPadUIRoot.TouchIcon)
		{
			moveFingerId = -1;
		}
		if (isTouching(moveFingerId))
		{
			Vector3 zero = Vector3.zero;
			Vector2 vector = touchPos(moveFingerId);
			moveTouchDif = vector - moveBasePos;
			if (!(moveTouchDif.magnitude < MoveStartDistThreashold))
			{
				moveTouchDifNorm = moveTouchDif.normalized;
				float num = 50f;
				Camera main = Camera.main;
				Vector3 direction;
				if (main != null)
				{
					direction = new Vector3(moveTouchDif.x, 0f, moveTouchDif.y);
					direction = main.transform.TransformDirection(direction);
					direction.y = 0f;
					direction.x *= num;
					direction.z *= num;
				}
				else
				{
					direction = new Vector3((0f - moveTouchDif.x) * num, 0f, (0f - moveTouchDif.y) * num);
				}
				actionInput.move(Player.MYPOS + direction);
				VirtualPadUIRoot.MoveVirtualPad(vector);
			}
		}
		else
		{
			moveFingerId = -1;
			VirtualPadUIRoot.HideVirtualPad();
		}
	}

	private void controlAttack()
	{
		MerlinActionInput actionInput = ActionInput;
		attackingFingerId = -1;
		if (hasTouchInfoNot(moveFingerId))
		{
			MTouch touchInfoNot = getTouchInfoNot(moveFingerId);
			Vector3 touchScreenPos = new Vector3(touchInfoNot.position.x, touchInfoNot.position.y, 0f);
			atkRayInfo.updateTouchInfo(touched: true, touchScreenPos);
			if (touchInfoNot.phase == TouchPhase.Began)
			{
				attackingFingerId = touchInfoNot.fingerId;
			}
		}
		else
		{
			atkRayInfo.updateTouchInfo(touched: false, Vector3.zero);
		}
		if (isBeganNot(moveFingerId) && getTouchFingerCountNot(moveFingerId) == 2)
		{
			PlayerLockOnControl lockOnControl = LockOnControl;
			if (lockOnControl.IsLockedOn)
			{
				lockOnControl.changeLockOn();
			}
			else
			{
				lockOnControl.searchAndStartIfNotLockedOn();
			}
		}
		if (attackingFingerId >= 0)
		{
			actionInput.attack(1);
			actionInput.runAttack();
		}
		if (IsAutoCombination && !actionInput.HasMove && (Player.IsActionTypeAttack || Player.IsActionTypeSkill))
		{
			actionInput.attack(1);
		}
	}

	private void processExternalEvents()
	{
		int num = swipeRecognizer.swipeFingerIndexNot(moveFingerId);
		if (num >= 0)
		{
			FingerGestures.SwipeDirection swipeDirection = FingerGestures.GetSwipeDirection(swipeRecognizer.getMoveDir(num));
			float angle = PlayerControl.FingerGestureDirToAngle((int)swipeDirection);
			ActionInput.kaihi(angle);
			ActionInput.clearMove();
			ActionInput.clearAttack();
		}
		clearExternalEvents();
	}

	private int findBeganInRect(Rect rect)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		int fingerId;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.phase != 0 || !rect.Contains(current.position))
				{
					continue;
				}
				fingerId = current.fingerId;
				goto IL_0060;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = -1;
		goto IL_0061;
		IL_0060:
		result = fingerId;
		goto IL_0061;
		IL_0061:
		return result;
	}

	private bool isTouching(int fid)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId != fid || current.phase == TouchPhase.Ended || current.phase == TouchPhase.Canceled)
				{
					continue;
				}
				flag = true;
				goto IL_0062;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_0063;
		IL_0062:
		result = (flag ? 1 : 0);
		goto IL_0063;
		IL_0063:
		return (byte)result != 0;
	}

	private bool isTouchingInRect(int fid, Rect rect)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId != fid || !rect.Contains(current.position))
				{
					continue;
				}
				flag = true;
				goto IL_005b;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_005c;
		IL_005b:
		result = (flag ? 1 : 0);
		goto IL_005c;
		IL_005c:
		return (byte)result != 0;
	}

	private Vector2 touchPos(int fid)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		Vector2 position;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId != fid)
				{
					continue;
				}
				position = current.position;
				goto IL_004e;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Vector2 result = Vector2.zero;
		goto IL_004f;
		IL_004e:
		result = position;
		goto IL_004f;
		IL_004f:
		return result;
	}

	private bool hasTouchInfoNot(int ignoreFingerId)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId == ignoreFingerId)
				{
					continue;
				}
				flag = true;
				goto IL_0045;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_0046;
		IL_0045:
		result = (flag ? 1 : 0);
		goto IL_0046;
		IL_0046:
		return (byte)result != 0;
	}

	private MTouch getTouchInfoNot(int ignoreFingerId)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		MTouch mTouch;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId == ignoreFingerId)
				{
					continue;
				}
				mTouch = current;
				goto IL_0049;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		MTouch result = new MTouch();
		goto IL_004a;
		IL_0049:
		result = mTouch;
		goto IL_004a;
		IL_004a:
		return result;
	}

	private int getTouchFingerCountNot(int ignoreFingerId)
	{
		int num = 0;
		int num2 = 0;
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId != ignoreFingerId && current.IsTouched)
				{
					int num3 = 1 << current.fingerId;
					if ((num & num3) == 0)
					{
						num |= num3;
						num2 = checked(num2 + 1);
					}
				}
			}
			return num2;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private bool isBeganNot(int ignoreFingerId)
	{
		IEnumerator<MTouch> enumerator = touches.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				MTouch current = enumerator.Current;
				if (current.fingerId == ignoreFingerId || current.phase != 0)
				{
					continue;
				}
				flag = true;
				goto IL_0051;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_0052;
		IL_0051:
		result = (flag ? 1 : 0);
		goto IL_0052;
		IL_0052:
		return (byte)result != 0;
	}

	protected override void doOnEnable()
	{
	}

	protected override void doOnDisable()
	{
		UICamera.allowMultiTouch = false;
		VirtualPadUIRoot.HideVirtualPad();
	}

	protected override void doOnTap()
	{
	}

	protected override void doOnSwipe(float dir, int fingerId)
	{
	}

	protected override void doOnDoubleTap()
	{
		reqDoubleTap = true;
	}

	private void clearExternalEvents()
	{
		reqDoubleTap = false;
	}

	protected override void doOnGUI()
	{
		GUILayout.BeginVertical();
		GUILayout.Label(new StringBuilder("MOVE FINGER: ").Append((object)moveFingerId).ToString());
		GUILayout.Label(new StringBuilder("MOVE BASE:   ").Append(moveBasePos).ToString());
		GUILayout.Label(new StringBuilder("MOVE TDIF:   ").Append(moveTouchDif).ToString());
		GUILayout.Label(new StringBuilder("TOUCH NUM:   ").Append((object)((ICollection)touches).Count).ToString());
		GUILayout.Label(new StringBuilder("ENEMY RAY:   ").Append(atkRayInfo.Enemy.ToString()).ToString());
		GUILayout.Label("---- swipe recognizers ----");
		swipeRecognizer.onGUI();
		GUILayout.Label("---- touches ----");
		int num = 0;
		int count = ((ICollection)touches).Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int num2 = num;
			num++;
			MTouch mTouch = touches[num2];
			GUILayout.Label(new StringBuilder("TOUCH ").Append((object)num2).Append(":").ToString());
			GUILayout.Label(new StringBuilder("  FID:").Append((object)mTouch.fingerId).Append(" TAPNUM:").Append((object)mTouch.tapCount)
				.Append(" Phase:")
				.Append(mTouch.phase)
				.ToString());
			GUILayout.Label(new StringBuilder("  POS:  ").Append(mTouch.position).ToString());
			GUILayout.Label(new StringBuilder("  DPOS: ").Append(mTouch.deltaPosition).ToString());
			GUILayout.Label(new StringBuilder("  DTIM: ").Append(mTouch.deltaTime).ToString());
		}
		GUILayout.EndVertical();
	}
}
