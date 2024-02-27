using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class DownloadTips
{
	[Serializable]
	public class Tips
	{
		[Serializable]
		public class Tip
		{
			public string title;

			public string msg;
		}

		private int no;

		private Dictionary<int, Tip> tips;

		public bool IsReady => 0 < tips.Count();

		public Tips()
		{
			tips = new Dictionary<int, Tip>();
		}

		public Tip Get()
		{
			object result;
			if (0 < tips.Count())
			{
				no %= tips.Count();
				Tip[] array = tips.Values.ToArray();
				int index;
				int num = (no = checked((index = no) + 1));
				result = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			}
			else
			{
				result = null;
			}
			return (Tip)result;
		}

		public void Add(int id, string title, string msg)
		{
			Tip tip = new Tip();
			tip.title = title;
			tip.msg = msg;
			tips[id] = tip;
		}

		public void Clear()
		{
			tips.Clear();
		}
	}

	private float tipsShowTime;

	private UILabelBase tipsTitle;

	private UILabelBase tipsMessage;

	private GameObject touchArea;

	public string linefeedWord;

	private Tips tips;

	private float lastTipsUpdateTime;

	public DownloadTips(float _tipsShowTime, UILabelBase _tipsTitle, UILabelBase _tipsMessage, GameObject _touchArea)
	{
		tipsShowTime = 5f;
		linefeedWord = "<p>";
		tipsShowTime = _tipsShowTime;
		tipsTitle = _tipsTitle;
		tipsMessage = _tipsMessage;
		touchArea = _touchArea;
	}

	private void InitTips()
	{
		if ((bool)touchArea)
		{
			touchArea.transform.localScale = new Vector3(Screen.width, Screen.height, 1f);
		}
		lastTipsUpdateTime = Time.timeSinceLevelLoad;
		if (tips != null)
		{
			tips.Clear();
		}
		else
		{
			tips = new Tips();
		}
		TextAsset textAsset = (TextAsset)GameAssetModule.LoadPrefab("Text/MTexts_Tips", typeof(TextAsset));
		if (textAsset == null)
		{
			return;
		}
		int num = 0;
		StringReader stringReader;
		IDisposable disposable = (stringReader = new StringReader(textAsset.text)) as IDisposable;
		try
		{
			string text;
			while ((text = stringReader.ReadLine()) != null)
			{
				string[] array = text.Split(',');
				if (array != null && array.Length == 2)
				{
					string title = array[0];
					string msg = array[1].Replace(linefeedWord, "\n");
					tips.Add(checked(num++), title, msg);
				}
			}
		}
		finally
		{
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
		}
		SetTips(tips.Get());
	}

	public void UpdateTips()
	{
		if (tips != null && tips.IsReady)
		{
			float timeSinceLevelLoad = Time.timeSinceLevelLoad;
			if (!(lastTipsUpdateTime + tipsShowTime >= timeSinceLevelLoad))
			{
				lastTipsUpdateTime = timeSinceLevelLoad;
				SetTips(tips.Get());
			}
		}
	}

	private void SetTips(Tips.Tip tip)
	{
		if (tip != null)
		{
			UIBasicUtility.SetLabel(tipsTitle, tip.title, show: true);
			UIBasicUtility.SetLabel(tipsMessage, tip.msg, show: true);
		}
	}

	private void PushTips()
	{
		if (tips != null && tips.IsReady)
		{
			lastTipsUpdateTime = Time.timeSinceLevelLoad;
			SetTips(tips.Get());
		}
	}
}
