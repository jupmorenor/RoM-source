using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PlayerInputControlByController : PlayerInputControl
{
	private ControllerBasicInfo basicInfo;

	public override PlayerInputControlType Type => PlayerInputControlType.ByController;

	public ControllerBasicInfo BasicInfo => basicInfo;

	public PlayerInputControlByController(PlayerControl _player)
		: base(_player)
	{
		basicInfo = new ControllerBasicInfo();
	}

	protected override void doClear()
	{
		basicInfo.clear();
	}

	protected override void doUpdate(float dt)
	{
		basicInfo.update(dt);
		bool[] current = basicInfo.Current;
		if (basicInfo.isDirty)
		{
			preventSleep();
		}
		Vector3 vector = (basicInfo.hasAnalogVector ? dirVectorFromAnalog(basicInfo.normalizedAnalogVector) : dirVector(current));
		float magnitude = vector.magnitude;
		MerlinActionInput actionInput = ActionInput;
		if (!(magnitude <= 0f))
		{
			actionInput.move(vector + Player.MYPOS);
		}
		if (current[RuntimeServices.NormalizeArrayIndex(current, 4)])
		{
			float num = ((magnitude <= 0f) ? Player.transform.eulerAngles.y : (Mathf.Atan2(vector.x, vector.z) * 57.29578f));
			actionInput.kaihi(num - Camera.main.transform.eulerAngles.y + 180f);
		}
		if (current[RuntimeServices.NormalizeArrayIndex(current, 5)])
		{
			lockOn();
			actionInput.change();
		}
		if (Player.IsBattleMode)
		{
			if (current[RuntimeServices.NormalizeArrayIndex(current, 6)])
			{
				lockOn();
				actionInput.attack(1);
				actionInput.runAttack();
			}
			if (current[RuntimeServices.NormalizeArrayIndex(current, 7)])
			{
				lockOn();
				actionInput.skill1();
			}
			if (current[RuntimeServices.NormalizeArrayIndex(current, 8)])
			{
				if (current[RuntimeServices.NormalizeArrayIndex(current, 6)])
				{
					lockOn();
					actionInput.chainMySkill();
				}
			}
			if (current[RuntimeServices.NormalizeArrayIndex(current, 8)])
			{
				if (current[RuntimeServices.NormalizeArrayIndex(current, 7)])
				{
					lockOn();
					actionInput.chainFriendSkill();
				}
			}
			if (basicInfo.isRepeat(ControllerBasicInfo.ButtonID.L))
			{
				LockOnControl.changeLockOn();
			}
		}
		else if (current[RuntimeServices.NormalizeArrayIndex(current, 6)])
		{
			NpcTalkControl.CheckTalkWithPlayerDirection(check: true);
		}
		else
		{
			NpcTalkControl.CheckTalkWithPlayerDirection(check: false);
		}
	}

	private Vector3 dirVector(bool[] bs)
	{
		Vector3 vector = Vector3.zero;
		if (bs[RuntimeServices.NormalizeArrayIndex(bs, 0)])
		{
			vector -= upVector();
		}
		if (bs[RuntimeServices.NormalizeArrayIndex(bs, 1)])
		{
			vector += upVector();
		}
		if (bs[RuntimeServices.NormalizeArrayIndex(bs, 2)])
		{
			vector += rightVector();
		}
		if (bs[RuntimeServices.NormalizeArrayIndex(bs, 3)])
		{
			vector -= rightVector();
		}
		Camera main = Camera.main;
		if (main != null)
		{
			vector = main.transform.TransformDirection(vector);
		}
		return vector;
	}

	private Vector3 upVector()
	{
		return new Vector3(0f, 0f, -1f);
	}

	private Vector3 rightVector()
	{
		return new Vector3(-1f, 0f, 0f);
	}

	private void preventSleep()
	{
		int sleepTimeout = Screen.sleepTimeout;
		if (sleepTimeout != -1)
		{
			Screen.sleepTimeout = -1;
			Screen.sleepTimeout = sleepTimeout;
		}
	}

	private Vector3 dirVectorFromAnalog(Vector3 aV)
	{
		Vector3 vector = default(Vector3);
		vector = aV.normalized;
		Camera main = Camera.main;
		if (main != null)
		{
			vector = -vector;
			vector = main.transform.TransformDirection(vector);
		}
		return vector;
	}
}
