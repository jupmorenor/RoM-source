using System;
using MerlinAPI;

[Serializable]
public class ClearData
{
	public static void ClearAllData()
	{
		ClearAllWithoutDownloadedData();
		ClearDownloadedData();
	}

	public static void ClearAllWithoutDownloadedData()
	{
		CurrentInfo.Clear();
		MerlinServer.Instance.disposeRequests();
		MerlinServer.Instance.clearRequestStatistics();
		MerlinServer.LastGameSrvResponse = null;
		UserData.ClearCurrent();
		MerlinGameCenter.ClearAuthOnBootFlag();
		QuestSession.DeleteSaveData();
		ColosseumSession.DeleteSaveData();
	}

	public static void ClearDownloadedData()
	{
		CurrentInfo.ClearDownloadedData();
		RuntimeAssetBundleDB.Instance.clearCurrentSavedData();
		DownloadMain.ClearAll();
	}

	public static void ClearToken()
	{
		CurrentInfo.ClearToken();
		MerlinServer.Instance.disposeRequests();
		MerlinServer.Instance.clearRequestStatistics();
	}
}
