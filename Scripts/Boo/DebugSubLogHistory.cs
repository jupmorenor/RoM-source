using System;
using System.Text;

[Serializable]
public class DebugSubLogHistory : RuntimeDebugModeGuiMixin
{
	private int select;

	public override void OnGUI()
	{
		string[] texts = ArrayMap.AllEnumNames(typeof(MacroUtil.LogType));
		select = RuntimeDebugModeGuiMixin.grid(select, texts, 4);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (MacroUtil.LogEntry item in MacroUtil.GetQueue((MacroUtil.LogType)select))
		{
			stringBuilder.Append(item.message);
			stringBuilder.Append("\n");
		}
		RuntimeDebugModeGuiMixin.textArea(stringBuilder.ToString());
	}
}
