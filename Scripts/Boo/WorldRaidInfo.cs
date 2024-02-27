using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WorldRaidInfo : MonoBehaviour
{
	public UILabelBase timeLimitLabel;

	public UILabelBase comboCountLabel;

	public UILabelBase comboBonusLabel;

	public UILabelBase comboTimeLimitLabel;

	public GameObject comboBgPanel;

	public UISlider bossHpBar;

	public UILabelBase bossHpLabel;

	public UILabelBase bossNameLabel;

	public UILabelBase bossLevelLabel;

	public UISprite bossElement;

	public GameObject bossRareIcon;

	public UISprite[] weaponBonusIcons;

	public UISprite[] elementBonusIcons;

	public UILabelBase raidRiankingLabel;

	public UILabelBase raidPointLabel;

	protected bool update;

	protected bool setup;

	protected bool skip_limittime;

	protected long nowTick;

	protected long sceneStartTick;

	protected int bossSec;

	protected int comboSec;

	protected int comboMaxLv;

	private RespCycleGuildPlayerRanking raidPlayerRanking;

	private MStageMonsters raidTutoralMonster;

	public MStageMonsters RaidTutoralMonster
	{
		get
		{
			return raidTutoralMonster;
		}
		set
		{
			update = true;
			raidTutoralMonster = value;
		}
	}

	public bool UpdateFlag
	{
		get
		{
			return update;
		}
		set
		{
			update = value;
		}
	}

	public bool SkipLimitTime
	{
		get
		{
			return skip_limittime;
		}
		set
		{
			skip_limittime = value;
		}
	}

	public int BossSec => bossSec;

	public int ComboSec => comboSec;

	public WorldRaidInfo()
	{
		bossSec = UserRaidData.RaidMaxTime;
	}

	public void Start()
	{
		init();
	}

	private void init()
	{
		comboMaxLv = MComboBonus.GetMaxLevel();
		RespTCycleRaidBattle raidBattle = UserData.Current.userRaidInfo.raidBattle;
		raidPlayerRanking = UserData.Current.userRaidInfo.guildPlayerRanking;
		timeLimitLabel.text = string.Empty;
		comboCountLabel.text = string.Empty;
		comboBonusLabel.text = string.Empty;
		comboTimeLimitLabel.text = string.Empty;
		if ((bool)comboBgPanel)
		{
			comboBgPanel.SetActive(value: false);
		}
		bossHpLabel.text = string.Empty;
		bossLevelLabel.text = string.Empty;
		bossNameLabel.text = string.Empty;
		bossRareIcon.SetActive(value: false);
		bossElement.spriteName = "icon_question";
		raidRiankingLabel.text = "------位";
		raidPointLabel.text = "-------";
		if (raidBattle != null)
		{
			update = true;
		}
	}

	public static string GetStyleIconName(EnumStyles s)
	{
		return UIBasicUtility.GetStyleSpriteName((int)s);
	}

	public void Update()
	{
		if (update)
		{
			update = false;
			Setup();
		}
		if (setup && !skip_limittime)
		{
			UpdateLimitTime();
		}
	}

	public void UpdateLimitTime()
	{
		long num = nowTick;
		RespTCycleRaidBattle raidBattle = UserData.Current.userRaidInfo.raidBattle;
		nowTick = MerlinDateTime.UtcNow.Ticks;
		if (num == nowTick)
		{
			return;
		}
		string text = null;
		checked
		{
			if (raidTutoralMonster != null)
			{
				bossSec = UserRaidData.RaidMaxTime - (int)unchecked(checked(nowTick - sceneStartTick) / 10000000L);
			}
			else
			{
				if (raidBattle == null)
				{
					return;
				}
				bossSec = UserData.Current.userRaidInfo.getRaidLimitSec();
				comboSec = UserData.Current.userRaidInfo.getRaidComboSec();
			}
		}
		if (0 < bossSec)
		{
			timeLimitLabel.text = UIBasicUtility.SafeFormat("{0:D2}分{1:D2}秒", bossSec / 60, bossSec % 60);
		}
		else
		{
			timeLimitLabel.text = "00分00秒";
		}
		if (0 < comboSec)
		{
			if ((bool)comboBgPanel)
			{
				comboBgPanel.SetActive(value: true);
			}
			comboTimeLimitLabel.text = UIBasicUtility.SafeFormat("残り {0:D2}分{1:D2}秒", comboSec / 60, comboSec % 60);
			if (raidBattle.ComboLevel < comboMaxLv)
			{
				comboCountLabel.text = raidBattle.ComboLevel.ToString();
			}
			else
			{
				comboCountLabel.text = "mx";
			}
			MComboBonus mComboBonus = MComboBonus.FindByLevel(raidBattle.ComboLevel);
			if (mComboBonus != null)
			{
				comboBonusLabel.text = new StringBuilder().Append(mComboBonus.Bonus * 100f).Append("%").ToString();
			}
		}
		else
		{
			if ((bool)comboBgPanel)
			{
				comboBgPanel.SetActive(value: false);
			}
			comboTimeLimitLabel.text = string.Empty;
			comboCountLabel.text = string.Empty;
			comboBonusLabel.text = string.Empty;
		}
	}

	private void Setup()
	{
		sceneStartTick = MerlinDateTime.UtcNow.Ticks;
		RespTCycleRaidBattle raidBattle = UserData.Current.userRaidInfo.raidBattle;
		MMonsters mMonsters = null;
		if (raidTutoralMonster != null)
		{
			setup = true;
			mMonsters = raidTutoralMonster.MMonsterId;
			bossHpBar.sliderValue = 1f;
			bossHpLabel.text = "500000";
			bossLevelLabel.text = "lv " + raidTutoralMonster.LevelMin.ToString();
			bossNameLabel.text = mMonsters.Name.msg;
			bossRareIcon.SetActive(value: false);
			bossElement.spriteName = mMonsters.MElementId.MainIcon;
		}
		else if (raidBattle != null)
		{
			setup = true;
			int i = 0;
			UISprite[] array = weaponBonusIcons;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if ((bool)array[i])
				{
					if (true)
					{
						array[i].gameObject.SetActive(value: true);
						array[i].spriteName = GetStyleIconName((EnumStyles)raidBattle.StyleId);
					}
					else
					{
						array[i].gameObject.SetActive(value: true);
						array[i].spriteName = "icon_question";
					}
				}
			}
			int j = 0;
			UISprite[] array2 = elementBonusIcons;
			for (int length2 = array2.Length; j < length2; j = checked(j + 1))
			{
				if ((bool)array2[j])
				{
					if (true)
					{
						array2[j].gameObject.SetActive(value: true);
						array2[j].spriteName = MElements.Get(raidBattle.ElementId).MainIcon;
					}
					else
					{
						array2[j].gameObject.SetActive(value: true);
						array2[j].spriteName = "icon_question";
					}
				}
			}
			mMonsters = MMonsters.Get(raidBattle.MMonsterId);
			float sliderValue = Mathf.Clamp01((float)raidBattle.Hp / (float)raidBattle.InitialHp);
			bossHpBar.sliderValue = sliderValue;
			bossHpLabel.text = raidBattle.Hp.ToString();
			bossLevelLabel.text = "lv " + raidBattle.GetCorrectLevel().ToString();
			bossNameLabel.text = mMonsters.Name.msg;
			bossRareIcon.SetActive(value: false);
			bossElement.spriteName = mMonsters.MElementId.MainIcon;
		}
		else if (0 == 0)
		{
			throw new AssertionFailedException("false");
		}
		if (raidPlayerRanking != null)
		{
			raidRiankingLabel.text = raidPlayerRanking.Ranking.ToString() + "位";
			raidPointLabel.text = raidPlayerRanking.RankingPoint.ToString();
		}
	}
}
