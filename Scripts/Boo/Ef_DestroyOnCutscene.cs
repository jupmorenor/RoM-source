using System;
using UnityEngine;

[Serializable]
public class Ef_DestroyOnCutscene : MonoBehaviour
{
	public void Update()
	{
		CutSceneManager cutSceneManager = CutSceneManager.Instance as CutSceneManager;
		if (cutSceneManager != null && cutSceneManager.isBusy)
		{
			gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
