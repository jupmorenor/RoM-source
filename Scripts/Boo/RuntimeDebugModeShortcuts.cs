using System;

[Serializable]
public class RuntimeDebugModeShortcuts
{
	public static void Battle()
	{
		ChangeScene("Merlin");
	}

	public static void MotionViewer()
	{
		ChangeScene("MotionViewerMobile");
	}

	public static void Town()
	{
		ChangeScene("Town");
	}

	public static void Myhome()
	{
		ChangeScene("Myhome");
	}

	public static void CutsceneViewer()
	{
		ChangeScene("CutsceneViewer");
	}

	public static void Raid_Tiamat()
	{
		ChangeScene("Raid_Tiamat");
	}

	public static void RaidTest4()
	{
		ChangeScene("RaidTest4");
	}

	public static void Raid_MantisAnt()
	{
		ChangeScene("Raid_MantisAnt");
	}

	public static void Boot()
	{
		ChangeScene("Boot");
	}

	public static void Sanctuary()
	{
		ChangeScene("sanctuary_000");
	}

	public static void Snowfield()
	{
		ChangeScene("snowfield_008");
	}

	public static void Volcano()
	{
		ChangeScene("volcano_000");
	}

	public static void Mountain()
	{
		ChangeScene("mountain_000");
	}

	public static void Forest()
	{
		ChangeScene("forest_002");
	}

	public static void Cave()
	{
		ChangeScene("cave_002");
	}

	public static void Coast()
	{
		ChangeScene("coast_000");
	}

	public static void Temple()
	{
		ChangeScene("temple_000");
	}

	public static void Desert()
	{
		ChangeScene("desert_000");
	}

	public static void Challenge()
	{
		ChangeScene("Ui_WorldChallenge");
	}

	public static void RankUser()
	{
		ChangeScene("Ui_RankingUser");
	}

	public static void Empty()
	{
		ChangeScene("Empty");
	}

	public static void ChangeScene(string scene)
	{
		RuntimeDebugMode.DebugChangeScene(scene);
	}
}
