using System;
using System.Collections.Generic;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumBattleStartTeamHUD : MonoBehaviour
{
	public UILabelBase nameLabel;

	public UISprite rankSprite;

	public UISprite leaderIcon;

	public UILabelBase pointLabel;

	public void Init(ColosseumTeam setData)
	{
		nameLabel.text = setData.TeamName;
		RespPoppet respPoppet = null;
		IEnumerator<ColosseumTeamMember> enumerator = setData.MemberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				if (current.IsLeader)
				{
					respPoppet = current.PoppetData;
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IconAtlasPool.SetSprite(leaderIcon, respPoppet.Icon, delegate(UIAtlas atlas)
		{
			leaderIcon.gameObject.SetActive(atlas != null);
		});
		pointLabel.text = setData.TeamInfo.rankPoint.ToString();
		MBreederRanks mBreederRanks = MBreederRanks.Get(setData.TeamInfo.rankId);
		if (mBreederRanks != null)
		{
			bool flag;
			UIBasicUtility.SetBreederRankSprite(rankSprite, mBreederRanks, flag = true);
		}
		else
		{
			rankSprite.gameObject.SetActive(value: false);
		}
	}

	public bool IsIconLoaded()
	{
		return leaderIcon.atlas != null;
	}

	internal void _0024Init_0024closure_00244384(UIAtlas atlas)
	{
		leaderIcon.gameObject.SetActive(atlas != null);
	}
}
