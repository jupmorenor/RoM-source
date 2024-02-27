using System;

[Serializable]
public class ActionCommandSuperArmor : MerlinActionControl.ActTimeCommand
{
	public ActionCommandSuperArmor(float start, float end)
	{
		setTimeRange(start, end);
	}

	public override bool doStart()
	{
		parent.superArmor = true;
		return false;
	}

	public override bool doEnd()
	{
		parent.superArmor = false;
		return false;
	}
}
