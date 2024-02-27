using System;
using UnityEngine;

[Serializable]
public class DebugSubShadow : RuntimeDebugModeGuiMixin
{
	protected int select;

	public override void OnGUI()
	{
		title = "Shadow";
		GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
		bool realShadowFlag = ShadowCheck.RealShadowFlag;
		if (RuntimeDebugModeGuiMixin.button("Current Real Shadow = " + realShadowFlag, gUILayoutOption))
		{
			ShadowSelector.SetupAll(shadownShaderFlag: true, !realShadowFlag);
		}
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
	}

	public override void Exit()
	{
	}
}
