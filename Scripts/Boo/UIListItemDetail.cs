using System;
using UnityEngine;

[Serializable]
public abstract class UIListItemDetail : MonoBehaviour
{
	private interface SkillDataBase
	{
		bool IsValid { get; }

		int lv { get; }

		int lvMax { get; }

		string lvStr { get; }

		string name { get; }

		string detail { get; }

		string iconName { get; }
	}

	[Serializable]
	public class LevelInfo
	{
		public string levelFormat;

		public UILabelBase levelLabel;

		public UILabelBase maxLevelLabel;

		public LevelInfo()
		{
			levelFormat = "{0}";
		}
	}

	[Serializable]
	public class ProfileInfo
	{
		public LevelInfo levelInfo;

		public UILabelBase nameLabel;

		public UILabelBase explainLabel;

		public UILabelBase typeLabel;

		public UILabelBase elementLabel;

		public UILabelBase deckCostLabel;

		public UISprite traitSprite;
	}

	[Serializable]
	public class ExpInfo
	{
		public UISlider gaugeBar;

		public UILabelBase expLabel;

		public UILabelBase nextExpLabel;
	}

	[Serializable]
	public class IconInfo
	{
		public UIListItem icon;

		public UISprite sprite;

		public bool IsEmpty => sprite == null;
	}

	[Serializable]
	public class ForceInfo
	{
		public UILabelBase hpLabel;

		public UILabelBase attackLabel;
	}

	[Serializable]
	public class PriceInfo
	{
		public UILabelBase buyLabel;

		public UILabelBase sellLabel;
	}

	[Serializable]
	public class SkillInfo
	{
		public LevelInfo levelInfo;

		public UISprite sprite;

		public UILabelBase nameLabel;

		public UILabelBase explainLabel;
	}

	[Serializable]
	public class SupportInfo
	{
		[Serializable]
		public class Set
		{
			public ForceInfo force;

			public UISprite elemSprite;

			public UISprite styleSprite;
		}

		public Set baseSet;

		public Set maxSet;
	}

	[Serializable]
	public class TotalInfo
	{
		public ForceInfo forceInfo;

		public UILabelBase fireLabel;

		public UILabelBase waterLabel;

		public UILabelBase airLabel;

		public UILabelBase earthLabel;
	}

	public static void SetLevelLabel(LevelInfo info, int nowLv, int maxLv, bool show, Color lvColor, Color maxColor)
	{
		if (info != null)
		{
			string format = info.levelFormat;
			if (string.IsNullOrEmpty(info.levelFormat))
			{
				format = "{0}";
			}
			UILabelBase levelLabel = info.levelLabel;
			string text = UIBasicUtility.SafeFormat(format, nowLv);
			bool num = show;
			if (num)
			{
				num = 0 < nowLv;
			}
			UIBasicUtility.SetLabel(levelLabel, text, num);
			UILabelBase maxLevelLabel = info.maxLevelLabel;
			string text2 = UIBasicUtility.SafeFormat(format, maxLv);
			bool num2 = show;
			if (num2)
			{
				num2 = 0 < maxLv;
			}
			UIBasicUtility.SetLabel(maxLevelLabel, text2, num2);
			UIBasicUtility.SetLabelColor(info.levelLabel, lvColor);
			UIBasicUtility.SetLabelColor(info.maxLevelLabel, maxColor);
		}
	}

	public static void SetLevelOneLabel(LevelInfo info, int nowLv, int maxLv, bool show, Color color)
	{
		if (info != null)
		{
			string format = info.levelFormat;
			if (string.IsNullOrEmpty(info.levelFormat))
			{
				format = "{0}/{1}";
			}
			UIBasicUtility.SetLabelColor(info.levelLabel, color);
			UIBasicUtility.SetLabel(info.levelLabel, string.Format(format, nowLv, maxLv), show);
		}
	}

	public static void SetSkill(SkillInfo[] infos, SkillDataBase data, bool show)
	{
		if (infos == null)
		{
			return;
		}
		bool num = show;
		if (num)
		{
			num = data.IsValid;
		}
		show = num;
		int i = 0;
		for (int length = infos.Length; i < length; i = checked(i + 1))
		{
			bool num2 = 0 < data.lvMax;
			if (num2)
			{
				num2 = show;
			}
			bool show2 = num2;
			if (!string.IsNullOrEmpty(data.lvStr))
			{
				string format = infos[i].levelInfo.levelFormat;
				if (string.IsNullOrEmpty(infos[i].levelInfo.levelFormat))
				{
					format = "{0}";
				}
				string text = string.Format(format, data.lvStr);
				UIBasicUtility.SetLabel(infos[i].levelInfo.levelLabel, text, show2);
			}
			else
			{
				Color color = new Color(0.88235295f, 0.8156863f, 0.20392157f);
				SetLevelLabel(infos[i].levelInfo, data.lv, data.lvMax, show2, color, color);
			}
			UIBasicUtility.SetSpriteByIconAtlasPool(infos[i].sprite, data.iconName, show);
			UIBasicUtility.SetLabel(infos[i].nameLabel, data.name, show);
			UIBasicUtility.SetLabel(infos[i].explainLabel, data.detail, show);
		}
	}

	public static void SetExp(ExpInfo[] expInfo, int nowExp, int nextExp, int lv, int lvMax, bool show)
	{
		if (expInfo == null)
		{
			return;
		}
		int i = 0;
		for (int length = expInfo.Length; i < length; i = checked(i + 1))
		{
			string text = "Next " + nowExp.ToString("#,#,0");
			string text2 = "Next " + nextExp.ToString("#,#,0");
			if (lv == lvMax)
			{
				nowExp = (nextExp = 1);
				text = "MAX";
				text2 = "MAX";
			}
			UIBasicUtility.SetLabel(expInfo[i].expLabel, text, show);
			UIBasicUtility.SetLabel(expInfo[i].nextExpLabel, text2, show);
			UIBasicUtility.SetGauge(expInfo[i].gaugeBar, nowExp, nextExp, show);
		}
	}

	public static void SetTotal(TotalInfo[] totalInfo, int tap, int thp, int fp, int wp, int ap, int ep, bool show)
	{
		int i = 0;
		for (int length = totalInfo.Length; i < length; i = checked(i + 1))
		{
			UIBasicUtility.SetLabel(totalInfo[i].forceInfo.attackLabel, tap.ToString(), show);
			UIBasicUtility.SetLabel(totalInfo[i].forceInfo.hpLabel, thp.ToString(), show);
			UIBasicUtility.SetLabel(totalInfo[i].fireLabel, $"{fp:00}%", show);
			UIBasicUtility.SetLabel(totalInfo[i].waterLabel, $"{wp:00}%", show);
			UIBasicUtility.SetLabel(totalInfo[i].airLabel, $"{ap:00}%", show);
			UIBasicUtility.SetLabel(totalInfo[i].earthLabel, $"{ep:00}%", show);
		}
	}

	public static void SetSupport(SupportInfo[] supportInfo, int ba, int bh, int ma, int mh, int el, int st, bool show)
	{
		if (typeof(SupportInfo) != null)
		{
			show = true;
			int i = 0;
			for (int length = supportInfo.Length; i < length; i = checked(i + 1))
			{
				SupportInfo.Set baseSet = supportInfo[i].baseSet;
				UIBasicUtility.SetLabel(baseSet.force.attackLabel, ba.ToString(), show);
				UIBasicUtility.SetLabel(baseSet.force.hpLabel, bh.ToString(), show);
				UIBasicUtility.SetElementSprite(baseSet.elemSprite, el, light: false, show);
				UIBasicUtility.SetStyleSprite(baseSet.styleSprite, st, light: false, show);
				baseSet = supportInfo[i].maxSet;
				UIBasicUtility.SetLabel(baseSet.force.attackLabel, ma.ToString(), show);
				UIBasicUtility.SetLabel(baseSet.force.hpLabel, mh.ToString(), show);
				UIBasicUtility.SetElementSprite(baseSet.elemSprite, el, light: true, show);
				UIBasicUtility.SetStyleSprite(baseSet.styleSprite, st, light: true, show);
			}
		}
	}

	public virtual void SetDetail(UIListItem.Data data)
	{
		SetPowupDetail(data, null);
	}

	public abstract virtual void SetPowupDetail(UIListItem.Data data, UIListItem.Data newData);

	public abstract virtual UIListItem.Data GetDetail();
}
