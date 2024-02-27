using System;

[Serializable]
public class TeamAdminDialog : CustomDialogBase
{
	private MessageBoard messageBoard;

	public void Initialize(MessageBoard mb)
	{
		messageBoard = mb;
		UIButtonMessage componentInChildren = ExtensionsModule.FindChild(gameObject, "0 TeamLeader").GetComponentInChildren<UIButtonMessage>();
		UIButtonMessage componentInChildren2 = ExtensionsModule.FindChild(gameObject, "1 MemberErase").GetComponentInChildren<UIButtonMessage>();
		UIButtonMessage componentInChildren3 = ExtensionsModule.FindChild(gameObject, "2 Cansel").GetComponentInChildren<UIButtonMessage>();
		componentInChildren.target = gameObject;
		componentInChildren.functionName = "LeaderChange";
		componentInChildren2.target = gameObject;
		componentInChildren2.functionName = "MembeKick";
		componentInChildren3.target = gameObject;
		componentInChildren3.functionName = "Cancel";
		EnterModalMode();
		int i = 0;
		UIAutoTweener[] componentsInChildren = gameObject.GetComponentsInChildren<UIAutoTweener>();
		checked
		{
			for (int length = componentsInChildren.Length; i < length; i++)
			{
				componentsInChildren[i].ignoreTimeScale = true;
			}
			int j = 0;
			UITweener[] componentsInChildren2 = gameObject.GetComponentsInChildren<UITweener>();
			for (int length2 = componentsInChildren2.Length; j < length2; j++)
			{
				componentsInChildren2[j].ignoreTimeScale = true;
				componentsInChildren2[j].Reset();
			}
			UIAutoTweenerStandAloneEx.In(gameObject);
		}
	}

	private void LeaderChange()
	{
		UIAutoTweenerStandAloneEx.Out(gameObject);
		ExitModalMode();
		messageBoard.PushLeaderChange();
	}

	private void MembeKick()
	{
		UIAutoTweenerStandAloneEx.Out(gameObject);
		ExitModalMode();
		messageBoard.PushTeamLeaveMenber();
	}

	private void Cancel()
	{
		UIAutoTweenerStandAloneEx.Out(gameObject);
		ExitModalMode();
	}
}
