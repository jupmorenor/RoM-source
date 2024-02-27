using System;

[Serializable]
public class DebugSubKamcord : RuntimeDebugModeGuiMixin
{
	protected KamcordRecorder kamcord;

	public override void OnGUI()
	{
		if (!kamcord.isRecord)
		{
			if (RuntimeDebugModeGuiMixin.button("Record Start"))
			{
				kamcord.startRecording();
			}
			if (RuntimeDebugModeGuiMixin.button("Show view"))
			{
				kamcord.showView();
			}
		}
		else if (RuntimeDebugModeGuiMixin.button("Record Stop"))
		{
			kamcord.stopRecording();
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
		kamcord = KamcordRecorder.Instance;
	}

	public override void Exit()
	{
	}
}
