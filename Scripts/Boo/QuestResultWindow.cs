using System;
using UnityEngine;

[Serializable]
public class QuestResultWindow : MonoBehaviour
{
	public UILabelBase coinLabel;

	public UILabelBase expLabel;

	public UILabelBase nextExpLabel;

	public UILabelBase challengPointLabel;

	public UILabelBase totalChallengePointLabel;

	public UILabelBase raidPointLabel;

	public UILabelBase totalRaidPointLabel;

	public int Coin
	{
		set
		{
			int v = Mathf.Min(value, 99999999);
			UIBasicUtility.SetLabel(coinLabel, its(v), show: true);
		}
	}

	public int Exp
	{
		set
		{
			UIBasicUtility.SetLabel(expLabel, its(value), show: true);
		}
	}

	public int NextLevelExp
	{
		set
		{
			UIBasicUtility.SetLabel(nextExpLabel, its(value), show: true);
		}
	}

	public long ChallengePoint
	{
		set
		{
			UIBasicUtility.SetLabel(challengPointLabel, lts(value), show: true);
		}
	}

	public long TotalChallengePoint
	{
		set
		{
			UIBasicUtility.SetLabel(totalChallengePointLabel, lts(value), show: true);
		}
	}

	public long RaidPoint
	{
		set
		{
			UIBasicUtility.SetLabel(raidPointLabel, lts(value), show: true);
		}
	}

	public long TotalRaidPoint
	{
		set
		{
			UIBasicUtility.SetLabel(totalRaidPointLabel, lts(value), show: true);
		}
	}

	private string its(int v)
	{
		return v.ToString("#,#,#,0");
	}

	private string lts(long v)
	{
		return v.ToString("#,#,#,0");
	}
}
