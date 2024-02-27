using System;
using UnityEngine;

[Serializable]
public class DoubleTapMovingControl
{
	private bool active;

	private Vector3 moveDir;

	private MerlinActionInput.MerlinActionInputTypes prevInput;

	private bool updated;

	public bool Active => active;

	public Vector3 MoveDir => moveDir;

	public bool Updated => updated;

	public void update(MerlinActionInput actInput, Vector3 curPlayerPos)
	{
		if (actInput == null || !active)
		{
			updated = false;
			return;
		}
		actInput.move(curPlayerPos + moveDir * 100f);
		prevInput = actInput.CurrentInput;
		updated = true;
	}

	public void enable(Vector3 dir)
	{
		active = true;
		moveDir = dir;
	}

	public void disable()
	{
		active = false;
		prevInput = MerlinActionInput.MerlinActionInputTypes.None;
	}
}
