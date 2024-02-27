using System;
using System.Text;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubSample : RuntimeDebugModeGuiMixin
{
	protected int select;

	public override void OnGUI()
	{
		RuntimeDebugModeGuiMixin.label("Label Samples");
		RuntimeDebugModeGuiMixin.label("label");
		RuntimeDebugModeGuiMixin.slabel("small label");
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.label("hor1");
			RuntimeDebugModeGuiMixin.slabel("hor2");
			RuntimeDebugModeGuiMixin.vertical((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RuntimeDebugModeGuiMixin.label("hor3");
				if (!RuntimeDebugModeGuiMixin.button("btn1"))
				{
				}
			});
		});
		RuntimeDebugModeGuiMixin.label("grid1");
		int num = RuntimeDebugModeGuiMixin.grid(new string[4] { "a", "b", "c", "d" }, 2);
		if (num >= 0)
		{
		}
		RuntimeDebugModeGuiMixin.label("grid2:radio");
		int num2 = RuntimeDebugModeGuiMixin.grid(select, new string[4] { "sa", "sb", "sc", "sd" }, 2);
		if (num2 != select)
		{
			num2 = select;
		}
		RuntimeDebugModeGuiMixin.space(50);
		RuntimeDebugModeGuiMixin.label("text area");
		RuntimeDebugModeGuiMixin.textArea("hello\nhigehige\nhogehiogeihge");
		int i = 0;
		Touch[] touches = Input.touches;
		for (int length = touches.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("FID:").Append((object)touches[i].fingerId).Append(" phase:").Append(touches[i].phase)
				.Append(" dt:")
				.Append(touches[i].deltaTime)
				.Append(" tapc:")
				.Append((object)touches[i].tapCount)
				.ToString());
		}
		if (RuntimeDebugModeGuiMixin.button("レイド情報取得 /Build/RaidBattle"))
		{
			MerlinServer.Request(new ApiGuildRaidBattle(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
			}));
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
		GUI.Label(new Rect(100f, 100f, 400f, 20f), "HELLO DebugSubSample");
	}

	public override void Init()
	{
	}

	public override void Exit()
	{
	}

	internal void _0024OnGUI_0024closure_00243697()
	{
		RuntimeDebugModeGuiMixin.label("hor1");
		RuntimeDebugModeGuiMixin.slabel("hor2");
		RuntimeDebugModeGuiMixin.vertical((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.label("hor3");
			if (!RuntimeDebugModeGuiMixin.button("btn1"))
			{
			}
		});
	}

	internal void _0024_0024OnGUI_0024closure_00243697_0024closure_00243698()
	{
		RuntimeDebugModeGuiMixin.label("hor3");
		if (!RuntimeDebugModeGuiMixin.button("btn1"))
		{
		}
	}

	internal void _0024OnGUI_0024closure_00243699()
	{
	}
}
