using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public abstract class PlayerInputControl
{
	private PlayerControl player;

	private Transform playerTrans;

	private bool working;

	public override PlayerInputControlType Type => PlayerInputControlType.Default;

	public MerlinActionInput ActionInput => (!(player != null)) ? null : player.ActionInput;

	public PlayerLockOnControl LockOnControl => player.LockOnControl;

	protected bool IsAutoCombination
	{
		get
		{
			UserConfigData config = UserData.Current.Config;
			bool num = config != null;
			if (num)
			{
				num = config.AutoCombinationOn;
			}
			return num;
		}
	}

	public PlayerControl Player => player;

	public Transform PlayerTrans => playerTrans;

	public bool Working => working;

	public PlayerInputControl(PlayerControl _player)
	{
		if (!(_player != null))
		{
			throw new AssertionFailedException("_player != null");
		}
		player = _player;
		playerTrans = player.transform;
	}

	public void lockOn()
	{
		LockOnControl.searchAndStartIfNotLockedOn();
	}

	public void clear()
	{
		if (!(player == null))
		{
			ActionInput.clearAll();
			doClear();
		}
	}

	protected virtual void doClear()
	{
	}

	public void pause()
	{
		doPause();
	}

	protected virtual void doPause()
	{
	}

	public void update(float dt)
	{
		working = false;
		if (!canUpdate())
		{
			clear();
			return;
		}
		working = true;
		doUpdate(dt);
	}

	public void onGUI()
	{
		GUILayout.BeginVertical();
		GUILayout.Label("canUpdate:" + canUpdate());
		GUILayout.Label("player:" + player);
		GUILayout.Label("action input:" + ActionInput);
		GUILayout.Label("lockon:" + LockOnControl.IsLockedOn + " target:" + LockOnControl.Target);
		GUILayout.Label("### CONTROLLER TYPE: " + GetType() + " ###");
		doOnGUI();
		GUILayout.EndVertical();
	}

	public void onEnable()
	{
		doOnEnable();
	}

	public void onDisable()
	{
		doOnDisable();
	}

	protected virtual void doOnEnable()
	{
	}

	protected virtual void doOnDisable()
	{
	}

	protected virtual void doOnGUI()
	{
	}

	protected virtual void doUpdate(float dt)
	{
	}

	private bool canUpdate()
	{
		return !(player == null) && ActionInput != null && player.IsReady && player.InputActive && !player.IsDead && !NageManager.Instance.isEntried(player);
	}

	public void onTap()
	{
		if (canUpdate())
		{
			doOnTap();
		}
	}

	public void onDoubleTap()
	{
		if (canUpdate())
		{
			doOnDoubleTap();
		}
	}

	public void onSwipe(float dir, int fingerId)
	{
		if (canUpdate())
		{
			doOnSwipe(dir, fingerId);
		}
	}

	protected virtual void doOnTap()
	{
	}

	protected virtual void doOnDoubleTap()
	{
	}

	protected virtual void doOnSwipe(float dir, int fingerId)
	{
	}
}
