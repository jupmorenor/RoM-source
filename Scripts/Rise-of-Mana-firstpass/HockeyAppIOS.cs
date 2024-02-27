using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HockeyAppIOS : MonoBehaviour
{
	protected const string HOCKEYAPP_BASEURL = "https://rink.hockeyapp.net/";

	protected const string HOCKEYAPP_CRASHESPATH = "api/2/apps/[APPID]/crashes/upload";

	protected const int MAX_CHARS = 199800;

	protected const string LOG_FILE_DIR = "/logs/";

	public string appID = "your-hockey-app-id";

	public string secret = "your-hockey-app-secret";

	public string authenticationType = "your-auth-type";

	public string serverURL = "your-custom-server-url";

	public bool autoUpload;

	public bool exceptionLogging;

	public bool updateManager;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		Application.RegisterLogCallback(null);
	}

	private void OnDestroy()
	{
		Application.RegisterLogCallback(null);
	}

	private void GameViewLoaded(string message)
	{
	}

	protected virtual List<string> GetLogHeaders()
	{
		return new List<string>();
	}

	protected virtual WWWForm CreateForm(string log)
	{
		WWWForm result = new WWWForm();
		byte[] array = null;
		return result;
	}

	protected virtual List<string> GetLogFiles()
	{
		return new List<string>();
	}

	protected virtual IEnumerator SendLogs(List<string> logs)
	{
		string crashPath = "api/2/apps/[APPID]/crashes/upload";
		string url = GetBaseURL() + crashPath.Replace("[APPID]", appID);
		foreach (string log in logs)
		{
			WWWForm postForm = CreateForm(log);
			string lContent2 = postForm.headers["Content-Type"].ToString();
			lContent2 = lContent2.Replace("\"", string.Empty);
			WWW www = new WWW(headers: new Hashtable { { "Content-Type", lContent2 } }, url: url, postData: postForm.data);
			yield return www;
			if (!string.IsNullOrEmpty(www.error))
			{
				continue;
			}
			try
			{
				File.Delete(log);
			}
			catch (Exception ex)
			{
				Exception e = ex;
				if (Debug.isDebugBuild)
				{
					Debug.Log("Failed to delete exception log: " + e);
				}
			}
		}
	}

	protected virtual void WriteLogToDisk(string logString, string stackTrace)
	{
	}

	protected virtual string GetBaseURL()
	{
		return string.Empty;
	}

	protected virtual bool IsConnected()
	{
		return false;
	}

	protected virtual void HandleException(string logString, string stackTrace)
	{
	}

	public void OnHandleLogCallback(string logString, string stackTrace, LogType type)
	{
	}

	public void OnHandleUnresolvedException(object sender, UnhandledExceptionEventArgs args)
	{
	}
}
