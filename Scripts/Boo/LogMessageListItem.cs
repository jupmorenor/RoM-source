using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class LogMessageListItem : UIListItem
{
	public UILabelBase nameLabel;

	public UILabelBase levelLabel;

	public UILabelBase damageLabel;

	public GameObject bg;

	public GameObject nameBg;

	private readonly Color bgKillColor;

	private readonly Color nameBgKillColor;

	private readonly string killTagColor;

	private readonly string defTagColor;

	public LogMessageListItem()
	{
		bgKillColor = UIBasicUtility.GetColorInt(229, 198, 178);
		nameBgKillColor = UIBasicUtility.GetColorInt(167, 82, 56, 68);
		killTagColor = "f94b64";
		defTagColor = "d9a51a";
	}

	public void SetInfo(RespBattleLogs info)
	{
		if (info == null)
		{
			throw new AssertionFailedException("ログがnullです");
		}
		string value = defTagColor;
		string text = MTexts.Msg("$WR_RAID_LOG_BATTLE_ATTACK");
		if (info.IsKill)
		{
			UIBasicUtility.SetColor(bg, bgKillColor);
			UIBasicUtility.SetColor(nameBg, nameBgKillColor);
			value = killTagColor;
			text = MTexts.Msg("$WR_RAID_LOG_BATTLE_KILL");
		}
		string text2 = UIBasicUtility.SafeFormat(new StringBuilder("{0}  [").Append(value).Append("]{1}").ToString(), info.Name, text);
		UIBasicUtility.SetLabel(nameLabel, text2, show: true);
		UIBasicUtility.SetLabel(levelLabel, "lv" + info.Level, show: true);
		text = MTexts.Msg("$WR_RAID_LOG_DAMAGE");
		string text3 = UIBasicUtility.SafeFormat(new StringBuilder("{0}  [").Append(killTagColor).Append("]{1}").ToString(), info.Damage.ToString("#,#,#,#,0"), text);
		UIBasicUtility.SetLabel(damageLabel, text3, show: true);
	}
}
