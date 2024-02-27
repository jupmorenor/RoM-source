using System;
using System.Text;
using Boo.Lang.PatternMatching;
using UnityEngine;

[Serializable]
public class RaidBossInfo : MonoBehaviour
{
	[Serializable]
	public enum INFO_MODE
	{
		Mini,
		Full
	}

	private INFO_MODE rankInfoMode;

	public string debugBossName;

	public int debugBossLevel;

	public int debugPoint;

	public int debugRank;

	public int debugCombo;

	public int debugRate;

	public int debugMember;

	private bool debugTimeInfo;

	private bool debugBossInfo;

	private bool debugComboInfo;

	private bool debugMemberInfo;

	private bool debugMiniInfo;

	private bool debugFullInfo;

	public UILabelBase textTime;

	public UILabelBase textBossName;

	public UILabelBase textBossLevel;

	public UILabelBase textBossHP;

	public UILabelBase textPoint;

	public UILabelBase textRank;

	public UILabelBase textComboCount;

	public UILabelBase textComboRate;

	public UILabelBase textComboTime;

	public UILabelBase textMemberNum;

	public GameObject rankInfoFull;

	public GameObject rankInfoMini;

	public GameObject comboInfo;

	public GameObject comboInfoBg;

	public GameObject timeInfoBg;

	public GameObject bossInfoBg;

	public GameObject memberInfoBg;

	public GameObject rankInfoMiniBg;

	public GameObject rankInfoFullBg;

	public RaidBossInfo()
	{
		rankInfoMode = INFO_MODE.Mini;
		debugTimeInfo = true;
		debugBossInfo = true;
		debugComboInfo = true;
		debugMemberInfo = true;
		debugMiniInfo = true;
		debugFullInfo = true;
	}

	public void Start()
	{
		textBossName.text = debugBossName;
		textBossLevel.text = "lv" + new StringBuilder().Append((object)debugBossLevel).ToString();
		textPoint.text = UIBasicUtility.SafeFormat("{0:#,#,0}", debugPoint);
		textRank.text = UIBasicUtility.SafeFormat("{0:0}位", debugRank);
		if (debugCombo > 0)
		{
			comboInfo.SetActive(value: true);
			textComboCount.text = new StringBuilder().Append((object)debugCombo).ToString();
			textComboRate.text = new StringBuilder().Append((object)debugRate).ToString() + "%";
		}
		else
		{
			comboInfo.SetActive(value: false);
		}
		UIBasicUtility.SetLabel(textMemberNum, new StringBuilder().Append((object)debugMember).ToString());
	}

	public void Update()
	{
	}

	public void OnSliderChange(float _hp)
	{
		textBossHP.text = UIBasicUtility.SafeFormat("{0:0}%", (double)_hp * 100.0);
	}

	public void PushRankInfo()
	{
		INFO_MODE iNFO_MODE = rankInfoMode;
		switch (iNFO_MODE)
		{
		case INFO_MODE.Mini:
			if (debugMiniInfo)
			{
				debugMiniInfo = false;
			}
			else
			{
				debugMiniInfo = true;
				rankInfoMode = INFO_MODE.Full;
				rankInfoFull.SetActive(value: true);
				rankInfoMini.SetActive(value: false);
			}
			rankInfoMiniBg.SetActive(debugMiniInfo);
			break;
		case INFO_MODE.Full:
			if (debugFullInfo)
			{
				debugFullInfo = false;
			}
			else
			{
				debugFullInfo = true;
				rankInfoMode = INFO_MODE.Mini;
				rankInfoFull.SetActive(value: false);
				rankInfoMini.SetActive(value: true);
			}
			rankInfoFullBg.SetActive(debugFullInfo);
			break;
		default:
			throw new MatchError(new StringBuilder("`rankInfoMode` failed to match `").Append(iNFO_MODE).Append("`").ToString());
		}
	}

	public void PushTimeInfo()
	{
		if (debugTimeInfo)
		{
			debugTimeInfo = false;
		}
		else
		{
			debugTimeInfo = true;
		}
		timeInfoBg.SetActive(debugTimeInfo);
	}

	public void PushBossInfo()
	{
		if (debugBossInfo)
		{
			debugBossInfo = false;
		}
		else
		{
			debugBossInfo = true;
		}
		bossInfoBg.SetActive(debugBossInfo);
	}

	public void PushComboInfo()
	{
		if (debugComboInfo)
		{
			debugComboInfo = false;
		}
		else
		{
			debugComboInfo = true;
		}
		comboInfoBg.SetActive(debugComboInfo);
	}

	public void PushMemberInfo()
	{
		if (debugMemberInfo)
		{
			debugMemberInfo = false;
		}
		else
		{
			debugMemberInfo = true;
		}
		memberInfoBg.SetActive(debugMemberInfo);
	}
}
