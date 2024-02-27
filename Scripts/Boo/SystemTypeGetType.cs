using System;
using System.Collections.Generic;

[Serializable]
public class SystemTypeGetType
{
	[NonSerialized]
	private static Dictionary<string, Type> TypeDictionary;

	public static Type GetType(string typename)
	{
		if (TypeDictionary == null)
		{
			InitTypeDictionary();
		}
		return (!TypeDictionary.ContainsKey(typename)) ? Type.GetType(typename) : TypeDictionary[typename];
	}

	private static void InitTypeDictionary()
	{
		TypeDictionary = new Dictionary<string, Type>();
		TypeDictionary["AIControl"] = typeof(AIControl);
		TypeDictionary["MerlinActionControl"] = typeof(MerlinActionControl);
		TypeDictionary["PlayerControl"] = typeof(PlayerControl);
		TypeDictionary["EnumStatus"] = typeof(EnumStatus);
		TypeDictionary["EnumComparisonOperator"] = typeof(EnumComparisonOperator);
		TypeDictionary["EnumLevelUpTypes"] = typeof(EnumLevelUpTypes);
		TypeDictionary["EnumRaces"] = typeof(EnumRaces);
		TypeDictionary["EnumRares"] = typeof(EnumRares);
		TypeDictionary["EnumGenders"] = typeof(EnumGenders);
		TypeDictionary["EnumStyles"] = typeof(EnumStyles);
		TypeDictionary["EnumElements"] = typeof(EnumElements);
		TypeDictionary["EnumSellTypes"] = typeof(EnumSellTypes);
		TypeDictionary["EnumSkillEffectTypes"] = typeof(EnumSkillEffectTypes);
		TypeDictionary["EnumSkillActionTypes"] = typeof(EnumSkillActionTypes);
		TypeDictionary["EnumAreaTypes"] = typeof(EnumAreaTypes);
		TypeDictionary["EnumQuestTypes"] = typeof(EnumQuestTypes);
		TypeDictionary["EnumQuestClearTypes"] = typeof(EnumQuestClearTypes);
		TypeDictionary["EnumNpcTalkIcons"] = typeof(EnumNpcTalkIcons);
		TypeDictionary["EnumMasterTypeValues"] = typeof(EnumMasterTypeValues);
		TypeDictionary["EnumMapLinkDir"] = typeof(EnumMapLinkDir);
		TypeDictionary["EnumSaleTypeValues"] = typeof(EnumSaleTypeValues);
		TypeDictionary["EnumGachaTypeValues"] = typeof(EnumGachaTypeValues);
		TypeDictionary["EnumGachaTypesForClient"] = typeof(EnumGachaTypesForClient);
		TypeDictionary["EnumWindowTypes"] = typeof(EnumWindowTypes);
		TypeDictionary["EnumLoginBonusTypeValues"] = typeof(EnumLoginBonusTypeValues);
		TypeDictionary["EnumNpcTalkTypes"] = typeof(EnumNpcTalkTypes);
		TypeDictionary["EnumMarketTypeValues"] = typeof(EnumMarketTypeValues);
		TypeDictionary["EnumGameObjectNames"] = typeof(EnumGameObjectNames);
		TypeDictionary["EnumWeek"] = typeof(EnumWeek);
		TypeDictionary["EnumRankingRewardTypes"] = typeof(EnumRankingRewardTypes);
		TypeDictionary["EnumPoppetPersonalities"] = typeof(EnumPoppetPersonalities);
		TypeDictionary["EnumPoppetChatTimings"] = typeof(EnumPoppetChatTimings);
		TypeDictionary["EnumAbnormalStates"] = typeof(EnumAbnormalStates);
		TypeDictionary["EnumCharacterActionTypes"] = typeof(EnumCharacterActionTypes);
		TypeDictionary["EnumPlayerRaces"] = typeof(EnumPlayerRaces);
		TypeDictionary["EnumRaidWordTypes"] = typeof(EnumRaidWordTypes);
		TypeDictionary["EnumPresentTypes"] = typeof(EnumPresentTypes);
		TypeDictionary["EnumShopMessageTypes"] = typeof(EnumShopMessageTypes);
		TypeDictionary["EnumStepGachaTypes"] = typeof(EnumStepGachaTypes);
		TypeDictionary["EnumCampaignSegmentTypes"] = typeof(EnumCampaignSegmentTypes);
		TypeDictionary["EnumProductSalesTypeValues"] = typeof(EnumProductSalesTypeValues);
		TypeDictionary["EnumMissionTypeValues"] = typeof(EnumMissionTypeValues);
		TypeDictionary["EnumMissionConditionTypes"] = typeof(EnumMissionConditionTypes);
		TypeDictionary["EnumSeTypes"] = typeof(EnumSeTypes);
		TypeDictionary["AttackPartTypes"] = typeof(AttackPartTypes);
		TypeDictionary["YarareTypes"] = typeof(YarareTypes);
		TypeDictionary["ActionTypes"] = typeof(ActionTypes);
		TypeDictionary["ActionDirections"] = typeof(ActionDirections);
		TypeDictionary["AttackDamageActors"] = typeof(AttackDamageActors);
		TypeDictionary["PlayerAnimationTypes"] = typeof(PlayerAnimationTypes);
		TypeDictionary["EnumStatus"] = typeof(EnumStatus);
		TypeDictionary["EnumComparisonOperator"] = typeof(EnumComparisonOperator);
		TypeDictionary["EnumLevelUpTypes"] = typeof(EnumLevelUpTypes);
		TypeDictionary["EnumRaces"] = typeof(EnumRaces);
		TypeDictionary["EnumRares"] = typeof(EnumRares);
		TypeDictionary["EnumGenders"] = typeof(EnumGenders);
		TypeDictionary["EnumStyles"] = typeof(EnumStyles);
		TypeDictionary["EnumElements"] = typeof(EnumElements);
		TypeDictionary["EnumSellTypes"] = typeof(EnumSellTypes);
		TypeDictionary["EnumSkillEffectTypes"] = typeof(EnumSkillEffectTypes);
		TypeDictionary["EnumSkillActionTypes"] = typeof(EnumSkillActionTypes);
		TypeDictionary["EnumAreaTypes"] = typeof(EnumAreaTypes);
		TypeDictionary["EnumQuestTypes"] = typeof(EnumQuestTypes);
		TypeDictionary["EnumQuestClearTypes"] = typeof(EnumQuestClearTypes);
		TypeDictionary["EnumNpcTalkIcons"] = typeof(EnumNpcTalkIcons);
		TypeDictionary["EnumMasterTypeValues"] = typeof(EnumMasterTypeValues);
		TypeDictionary["EnumMapLinkDir"] = typeof(EnumMapLinkDir);
		TypeDictionary["EnumSaleTypeValues"] = typeof(EnumSaleTypeValues);
		TypeDictionary["EnumGachaTypeValues"] = typeof(EnumGachaTypeValues);
		TypeDictionary["EnumGachaTypesForClient"] = typeof(EnumGachaTypesForClient);
		TypeDictionary["EnumWindowTypes"] = typeof(EnumWindowTypes);
		TypeDictionary["EnumLoginBonusTypeValues"] = typeof(EnumLoginBonusTypeValues);
		TypeDictionary["EnumNpcTalkTypes"] = typeof(EnumNpcTalkTypes);
		TypeDictionary["EnumMarketTypeValues"] = typeof(EnumMarketTypeValues);
		TypeDictionary["EnumGameObjectNames"] = typeof(EnumGameObjectNames);
		TypeDictionary["EnumWeek"] = typeof(EnumWeek);
		TypeDictionary["EnumRankingRewardTypes"] = typeof(EnumRankingRewardTypes);
		TypeDictionary["EnumPoppetPersonalities"] = typeof(EnumPoppetPersonalities);
		TypeDictionary["EnumPoppetChatTimings"] = typeof(EnumPoppetChatTimings);
		TypeDictionary["EnumAbnormalStates"] = typeof(EnumAbnormalStates);
		TypeDictionary["EnumCharacterActionTypes"] = typeof(EnumCharacterActionTypes);
		TypeDictionary["EnumPlayerRaces"] = typeof(EnumPlayerRaces);
		TypeDictionary["EnumRaidWordTypes"] = typeof(EnumRaidWordTypes);
		TypeDictionary["EnumPresentTypes"] = typeof(EnumPresentTypes);
		TypeDictionary["EnumShopMessageTypes"] = typeof(EnumShopMessageTypes);
		TypeDictionary["EnumStepGachaTypes"] = typeof(EnumStepGachaTypes);
		TypeDictionary["EnumCampaignSegmentTypes"] = typeof(EnumCampaignSegmentTypes);
		TypeDictionary["EnumProductSalesTypeValues"] = typeof(EnumProductSalesTypeValues);
		TypeDictionary["EnumMissionTypeValues"] = typeof(EnumMissionTypeValues);
		TypeDictionary["EnumMissionConditionTypes"] = typeof(EnumMissionConditionTypes);
		TypeDictionary["EnumSeTypes"] = typeof(EnumSeTypes);
	}
}
