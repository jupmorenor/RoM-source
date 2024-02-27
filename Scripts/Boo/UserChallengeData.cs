using System;
using MerlinAPI;

[Serializable]
public class UserChallengeData
{
	public RespChallengeQuestRankings challengRanking;

	public void setChallengeQuestRanking(RespChallengeQuestRankings d)
	{
		if (d != null)
		{
			challengRanking = d;
		}
	}
}
