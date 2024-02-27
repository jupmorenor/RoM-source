using System;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang.Runtime;

[CompilerGlobalScope]
public sealed class SceneIDModule
{
	[NonSerialized]
	private static string[] _0024genenum_0024SceneID_00243 = new string[58]
	{
		"Assets/Scenes/Boot.unity", "Assets/Scenes/CharMake/CharMake3D.unity", "Assets/Scenes/ColosseumMenuTest.unity", "Assets/Scenes/ColosseumResultTest.unity", "Assets/Scenes/ColosseumSelectTest.unity", "Assets/Scenes/CutScene/AutoPlay_CutScene.unity", "Assets/Scenes/CutScene/Opening.unity", "Assets/Scenes/CutsceneViewer.unity", "Assets/Scenes/Empty.unity", "Assets/Scenes/EmptyBlack.unity",
		"Assets/Scenes/Epilogue.unity", "Assets/Scenes/Event/Ui_DiscoverBoss.unity", "Assets/Scenes/Gousei/Gousei.unity", "Assets/Scenes/Lottery/Lottery_UI.unity", "Assets/Scenes/Merlin.unity", "Assets/Scenes/MotionViewerMobile.unity", "Assets/Scenes/Myhome.unity", "Assets/Scenes/Prologue.unity", "Assets/Scenes/RaidBattle/Raid01.unity", "Assets/Scenes/RaidBattle/RaidBattle.unity",
		"Assets/Scenes/Town.unity", "Assets/Scenes/TreasureBox.unity", "Assets/Scenes/TutorialTestBattle.unity", "Assets/Scenes/UI_Sequence/Ui_BlacksmithEvolution.unity", "Assets/Scenes/UI_Sequence/Ui_BlacksmithPowup.unity", "Assets/Scenes/UI_Sequence/Ui_BlacksmithSell.unity", "Assets/Scenes/UI_Sequence/Ui_CharMake.unity", "Assets/Scenes/UI_Sequence/Ui_CheckUpdate.unity", "Assets/Scenes/UI_Sequence/Ui_CreatePetName.unity", "Assets/Scenes/UI_Sequence/Ui_CreateUserID.unity",
		"Assets/Scenes/UI_Sequence/Ui_Download.unity", "Assets/Scenes/UI_Sequence/Ui_ItemOverflow.unity", "Assets/Scenes/UI_Sequence/Ui_LoginBonus.unity", "Assets/Scenes/UI_Sequence/Ui_MessageBoard.unity", "Assets/Scenes/UI_Sequence/Ui_MyHomeEquip.unity", "Assets/Scenes/UI_Sequence/Ui_MyHomeGift.unity", "Assets/Scenes/UI_Sequence/Ui_MyHomePicBook.unity", "Assets/Scenes/UI_Sequence/Ui_MyHomeStory.unity", "Assets/Scenes/UI_Sequence/Ui_PetEvolution.unity", "Assets/Scenes/UI_Sequence/Ui_PetPowup.unity",
		"Assets/Scenes/UI_Sequence/Ui_PrologueStart.unity", "Assets/Scenes/UI_Sequence/Ui_RankingChallenge.unity", "Assets/Scenes/UI_Sequence/Ui_RankingUnion.unity", "Assets/Scenes/UI_Sequence/Ui_RankingUser.unity", "Assets/Scenes/UI_Sequence/Ui_TerminalChange.unity", "Assets/Scenes/UI_Sequence/Ui_TitleLogo.unity", "Assets/Scenes/UI_Sequence/Ui_TownBlacksmith.unity", "Assets/Scenes/UI_Sequence/Ui_TownStoneShop.unity", "Assets/Scenes/UI_Sequence/Ui_World.unity", "Assets/Scenes/UI_Sequence/Ui_WorldChallenge 1.unity",
		"Assets/Scenes/UI_Sequence/Ui_WorldChallenge.unity", "Assets/Scenes/UI_Sequence/Ui_WorldChallengeResult.unity", "Assets/Scenes/UI_Sequence/Ui_WorldColosseum.unity", "Assets/Scenes/UI_Sequence/Ui_WorldColosseumResult.unity", "Assets/Scenes/UI_Sequence/Ui_WorldQuest.unity", "Assets/Scenes/UI_Sequence/Ui_WorldQuestResult.unity", "Assets/Scenes/UI_Sequence/Ui_WorldRaid.unity", "Assets/Scenes/UI_Sequence/Ui_WorldRaidResult.unity"
	};

	[NonSerialized]
	private static string[] _0024genenum_0024SceneID_00244 = new string[58]
	{
		"Boot", "CharMake3D", "ColosseumMenuTest", "ColosseumResultTest", "ColosseumSelectTest", "AutoPlay_CutScene", "Opening", "CutsceneViewer", "Empty", "EmptyBlack",
		"Epilogue", "Ui_DiscoverBoss", "Gousei", "Lottery_UI", "Merlin", "MotionViewerMobile", "Myhome", "Prologue", "Raid01", "RaidBattle",
		"Town", "TreasureBox", "TutorialTestBattle", "Ui_BlacksmithEvolution", "Ui_BlacksmithPowup", "Ui_BlacksmithSell", "Ui_CharMake", "Ui_CheckUpdate", "Ui_CreatePetName", "Ui_CreateUserID",
		"Ui_Download", "Ui_ItemOverflow", "Ui_LoginBonus", "Ui_MessageBoard", "Ui_MyHomeEquip", "Ui_MyHomeGift", "Ui_MyHomePicBook", "Ui_MyHomeStory", "Ui_PetEvolution", "Ui_PetPowup",
		"Ui_PrologueStart", "Ui_RankingChallenge", "Ui_RankingUnion", "Ui_RankingUser", "Ui_TerminalChange", "Ui_TitleLogo", "Ui_TownBlacksmith", "Ui_TownStoneShop", "Ui_World", "Ui_WorldChallenge 1",
		"Ui_WorldChallenge", "Ui_WorldChallengeResult", "Ui_WorldColosseum", "Ui_WorldColosseumResult", "Ui_WorldQuest", "Ui_WorldQuestResult", "Ui_WorldRaid", "Ui_WorldRaidResult"
	};

	private SceneIDModule()
	{
	}

	public static string SceneIDToPath(SceneID e)
	{
		object result;
		if (e == SceneID.__NONE__)
		{
			result = "<NONE>";
		}
		else
		{
			if (SceneID.Boot > e || e >= SceneID.__NONE__)
			{
				throw new AssertionFailedException("SceneID" + new StringBuilder("エラー: ").Append(e).ToString());
			}
			string[] array = _0024genenum_0024SceneID_00243;
			result = array[RuntimeServices.NormalizeArrayIndex(array, (int)e)];
		}
		return (string)result;
	}

	public static string SceneIDToName(SceneID e)
	{
		object result;
		if (e == SceneID.__NONE__)
		{
			result = "<NONE>";
		}
		else
		{
			if (SceneID.Boot > e || e >= SceneID.__NONE__)
			{
				throw new AssertionFailedException(58 + new StringBuilder("エラー: ").Append(e).ToString());
			}
			string[] array = _0024genenum_0024SceneID_00244;
			result = array[RuntimeServices.NormalizeArrayIndex(array, (int)e)];
		}
		return (string)result;
	}

	public static bool IsValidSceneID(SceneID e)
	{
		bool num = SceneID.Boot <= e;
		if (num)
		{
			num = e < SceneID.__NONE__;
		}
		return num;
	}

	public static SceneID StrToSceneID(string s)
	{
		int result;
		if (string.IsNullOrEmpty(s))
		{
			result = 58;
		}
		else
		{
			int num = 0;
			int length = _0024genenum_0024SceneID_00244.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < length)
				{
					int num2 = num;
					num++;
					string[] array = _0024genenum_0024SceneID_00244;
					if (s == array[RuntimeServices.NormalizeArrayIndex(array, num2)])
					{
						result = num2;
						break;
					}
					continue;
				}
				result = 58;
				break;
			}
		}
		return (SceneID)result;
	}
}
