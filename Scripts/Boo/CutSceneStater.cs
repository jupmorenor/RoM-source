using System;
using UnityEngine;

[Serializable]
public class CutSceneStater : MonoBehaviour
{
	public string cutSceneName;

	public GameObject cutSceneChar;

	public bool cutSceneStart;

	public bool oneShot;

	protected CutSceneManager evntMgr;

	public CutSceneStater()
	{
		cutSceneName = "Merlin_CutScene1";
		cutSceneStart = true;
	}

	public void Start()
	{
		evntMgr = ((CutSceneManager)UnityEngine.Object.FindObjectOfType(typeof(CutSceneManager))) as CutSceneManager;
	}

	public void Update()
	{
		if ((bool)evntMgr && cutSceneStart)
		{
			CutSceneManager cutSceneManager = CutSceneManager.CutScene(cutSceneName, cutSceneChar);
			cutSceneStart = false;
			if ((bool)cutSceneManager)
			{
				cutSceneManager.StartCutScene();
			}
		}
		if (oneShot)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}
}
