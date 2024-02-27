using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

[Serializable]
public class CaptureVideo : MonoBehaviour
{
	public string capName;

	public int frameRate;

	private string realFolder;

	private string basePath;

	private int currentFrame;

	private int startFrame;

	private bool isCap;

	public bool タイムスタンプ打刻;

	public bool isCapturing => isCap;

	public bool TimeStampVisible
	{
		get
		{
			return タイムスタンプ打刻;
		}
		set
		{
			タイムスタンプ打刻 = value;
		}
	}

	public CaptureVideo()
	{
		capName = "hoehoe";
		frameRate = 30;
		realFolder = string.Empty;
		basePath = string.Empty;
	}

	public void Start()
	{
		basePath = Path.GetFullPath(Path.Combine(Application.dataPath, "../VideoCapture/"));
	}

	public void Update()
	{
		if (isCap)
		{
			currentFrame = checked(Time.frameCount - startFrame);
			string filename = UIBasicUtility.SafeFormat("{0}/{1:D04}_shot.png", realFolder, currentFrame);
			Application.CaptureScreenshot(filename);
		}
	}

	public void OnGUI()
	{
		if (isCap && TimeStampVisible)
		{
			dispTimeCode();
		}
	}

	public void dispTimeCode()
	{
		int num = Screen.width / 4;
		int num2 = Screen.height / 8;
		checked
		{
			GUILayout.BeginArea(new Rect(unchecked(Screen.width / 2) - unchecked(num / 2), Screen.height - num2, 1000f, 1000f));
			int fontSize = GUI.skin.box.fontSize;
			GUI.skin.box.fontSize = 33;
			GUI.Box(new Rect(0f, 0f, num, num2), "Cap: " + currentFrame);
			GUILayout.EndArea();
			GUI.skin.box.fontSize = fontSize;
		}
	}

	public void startCapture()
	{
		Time.captureFramerate = frameRate;
		startFrame = Time.frameCount;
		makeDirectory();
		isCap = true;
	}

	public void stopCapture()
	{
		isCap = false;
		Time.captureFramerate = 0;
		encodeVideo();
	}

	public void encodeVideo()
	{
		string rhs = makeOutputname();
		string text = " -r 30 -i " + realFolder + "/%04d_shot.png" + " -b 5000000 -r 60 " + rhs;
		UnityEngine.Debug.Log("ffmpeg options: " + text);
		try
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "ffmpeg.exe";
			process.StartInfo.Arguments = text;
			process.Start();
			process.WaitForExit();
			UnityEngine.Debug.Log("encode success!!!");
		}
		catch (Exception message)
		{
			UnityEngine.Debug.Log(message);
		}
	}

	public string makeOutputname()
	{
		string fullPath = Path.GetFullPath(Path.Combine(basePath, capName + ".avi"));
		int num = 1;
		while (File.Exists(fullPath))
		{
			fullPath = Path.GetFullPath(Path.Combine(basePath, capName + num + ".avi"));
			num = checked(num + 1);
		}
		return fullPath;
	}

	public void makeDirectory()
	{
		realFolder = Path.GetFullPath(Path.Combine(basePath, capName));
		int num = 1;
		while (Directory.Exists(realFolder))
		{
			realFolder += num;
			num = checked(num + 1);
		}
		Directory.CreateDirectory(realFolder);
	}
}
