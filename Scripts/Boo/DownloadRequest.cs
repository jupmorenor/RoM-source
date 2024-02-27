using System;
using System.Collections;
using System.IO;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DownloadRequest
{
	[Serializable]
	public enum Mode
	{
		init,
		download,
		cached,
		finished,
		error
	}

	[NonSerialized]
	private const float TIMEOUT = 1800f;

	[NonSerialized]
	private const bool WITH_GC = false;

	private Hashtable hash;

	private string url;

	private __DownloadRequest_0024callable108_002416_75__ callback;

	private WWW www;

	private string fileName;

	private bool isAssetBundle;

	private int abver;

	private uint crc;

	private uint size;

	private bool disposeIfFinish;

	private Mode _mode;

	private int errorCount;

	private int totalErrorCount;

	private int upCounter;

	private float reqTime;

	private float wwwProgress;

	public bool IsOk
	{
		get
		{
			bool num = mode == Mode.finished;
			if (!num)
			{
				num = mode == Mode.cached;
			}
			return num;
		}
	}

	public bool IsError => mode == Mode.error;

	public bool NotDownloaded => mode == Mode.cached;

	public bool IsAssetBundle => isAssetBundle;

	public bool IsCached
	{
		get
		{
			int num;
			if (isAssetBundle)
			{
				num = ((abver <= 0) ? 1 : 0);
				if (num == 0)
				{
					num = (Caching.IsVersionCached(url, abver) ? 1 : 0);
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}
	}

	public string Url => url;

	public int AssetBundleVersion => abver;

	public float Size
	{
		get
		{
			return (int)size;
		}
		set
		{
			size = checked((uint)value);
		}
	}

	public float ProgressSize => Progress * (float)(int)size;

	public float Progress => wwwProgress;

	public bool DisposeIfFinish
	{
		get
		{
			return disposeIfFinish;
		}
		set
		{
			disposeIfFinish = value;
		}
	}

	private Mode mode
	{
		get
		{
			return _mode;
		}
		set
		{
			_mode = value;
			upCounter = 0;
		}
	}

	public DownloadRequest(Hashtable hash, string url, __DownloadRequest_0024callable108_002416_75__ callback)
	{
		disposeIfFinish = true;
		_mode = Mode.init;
		this.hash = hash;
		this.url = url;
		this.callback = callback;
		www = null;
		errorCount = 0;
		fileName = Path.GetFileName(url);
		isAssetBundle = DownloadUtil.IsAssetBundleFile(fileName);
		if (isAssetBundle)
		{
			if (hash == null)
			{
				throw new AssertionFailedException("hash != null");
			}
			abver = DownloadUtil.GetAssetBundleVersion(hash, fileName);
			crc = DownloadUtil.GetAssetBundleCRC(hash, fileName);
			size = DownloadUtil.GetAssetBundleSize(hash, fileName);
		}
		checked
		{
			size = (uint)Mathf.Max(1f, unchecked((int)size));
			mode = Mode.init;
		}
	}

	public void finishIfCached()
	{
		if (isAssetBundle && Caching.IsVersionCached(url, abver))
		{
			finish();
			mode = Mode.cached;
		}
	}

	public void update()
	{
		reqTime += Time.deltaTime;
		checked
		{
			if (mode == Mode.init)
			{
				upCounter++;
				updateInit();
			}
			if (mode == Mode.download)
			{
				upCounter++;
				updateDownload();
			}
			if (mode == Mode.error)
			{
				upCounter++;
				updateError();
			}
			updateWWWProgress();
		}
	}

	public void resetDownloadIfError()
	{
		if (mode == Mode.error)
		{
			errorCount = 0;
			mode = Mode.init;
		}
	}

	public void dispose()
	{
		disposeWWW();
	}

	public override string ToString()
	{
		return new StringBuilder().Append(mode).Append(" err:").Append((object)totalErrorCount)
			.Append(" isAB:")
			.Append(isAssetBundle)
			.Append(" v:")
			.Append((object)abver)
			.Append(" p:")
			.Append(Progress)
			.Append(" ")
			.Append(url)
			.Append(" upC:")
			.Append((object)upCounter)
			.ToString();
	}

	private void updateInit()
	{
		disposeWWW();
		if (isAssetBundle)
		{
			www = WWW.LoadFromCacheOrDownload(url, abver, crc);
		}
		else
		{
			www = new WWW(url);
		}
		mode = Mode.download;
		reqTime = 0f;
	}

	private void updateDownload()
	{
		if (www.isDone || !string.IsNullOrEmpty(www.error))
		{
			bool num = www.isDone;
			if (num)
			{
				num = string.IsNullOrEmpty(www.error);
			}
			if (num)
			{
				finish();
			}
			else
			{
				setErrorMode(gotoErrorMode: false);
			}
		}
		else if (!(reqTime <= 1800f))
		{
			setErrorMode(gotoErrorMode: true);
		}
	}

	private void updateWWWProgress()
	{
		if (IsOk)
		{
			wwwProgress = 1f;
		}
		else if (www == null)
		{
			wwwProgress = 0f;
		}
		else
		{
			wwwProgress = www.progress;
		}
	}

	private void setErrorMode(bool gotoErrorMode)
	{
		checked
		{
			errorCount++;
			totalErrorCount++;
			if (errorCount >= 5 || gotoErrorMode)
			{
				mode = Mode.error;
			}
			else
			{
				mode = Mode.init;
			}
		}
	}

	private void updateError()
	{
	}

	private void disposeWWW()
	{
		if (www != null)
		{
			try
			{
				www.Dispose();
			}
			catch (Exception)
			{
			}
			www = null;
		}
	}

	private void finish()
	{
		mode = Mode.finished;
		postProcess();
		if (false)
		{
			GC.Collect();
		}
	}

	private void postProcess()
	{
		try
		{
			if (callback != null)
			{
				callback(www);
			}
		}
		catch (Exception)
		{
		}
		if (isAssetBundle)
		{
			try
			{
				if (www != null && www.assetBundle != null)
				{
					www.assetBundle.Unload(unloadAllLoadedObjects: true);
				}
			}
			catch (Exception)
			{
			}
		}
		if (disposeIfFinish)
		{
			disposeWWW();
		}
	}
}
