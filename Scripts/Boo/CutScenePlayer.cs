using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class CutScenePlayer : MonoBehaviour
{
	[Serializable]
	public class Info
	{
		public bool autoPlay;

		public string playCutScene;

		public string assetBundleName;

		public string changeScene;

		public Info()
		{
			autoPlay = true;
		}
	}

	public Info info;

	[NonSerialized]
	private static bool isStarted;

	public void Awake()
	{
		SceneDontDestroyObject.dontDestroyOnLoad(this);
	}

	public void Update()
	{
		if (!isStarted)
		{
			Start();
		}
	}

	public virtual void Start()
	{
		CutScenePlayerInfomation cutScenePlayerInfomation = (CutScenePlayerInfomation)UnityEngine.Object.FindObjectOfType(typeof(CutScenePlayerInfomation));
		if ((bool)cutScenePlayerInfomation)
		{
			info = cutScenePlayerInfomation.info;
		}
		if (info != null && info.autoPlay)
		{
			Play();
			isStarted = true;
		}
		UnityEngine.Object.Destroy(cutScenePlayerInfomation);
	}

	public void Play()
	{
		if (string.IsNullOrEmpty(info.playCutScene))
		{
			return;
		}
		CutSceneManager cutSceneManager = CutSceneManager.CutSceneEx(info.playCutScene, null, info.assetBundleName, autoStart: true);
		cutSceneManager.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			EndCallback();
			if (!string.IsNullOrEmpty(info.changeScene))
			{
				SceneChanger.Change(info.changeScene);
			}
			info.changeScene = null;
		};
	}

	protected void exit()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	protected virtual void EndCallback()
	{
		exit();
	}

	public static void CreateAutoPlayCutScene(string playCutScene, string assetBundleName, string changeScene)
	{
		GameObject gameObject = new GameObject();
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		CutScenePlayerInfomation cutScenePlayerInfomation = gameObject.AddComponent<CutScenePlayerInfomation>();
		Info info = new Info();
		info.autoPlay = true;
		info.playCutScene = playCutScene;
		info.assetBundleName = assetBundleName;
		info.changeScene = changeScene;
		cutScenePlayerInfomation.info = info;
		isStarted = false;
	}

	internal void _0024Play_0024closure_00244411()
	{
		EndCallback();
		if (!string.IsNullOrEmpty(info.changeScene))
		{
			SceneChanger.Change(info.changeScene);
		}
		info.changeScene = null;
	}
}
