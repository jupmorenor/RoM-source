using System;
using UnityEngine;

[Serializable]
public class UIRootSceneSample : UIMain
{
	[Serializable]
	public enum SAMPLE_SCENE_MODE
	{
		None,
		Scene1,
		Scene2,
		Scene3,
		Scene4,
		Max
	}

	public GameObject scene1;

	public GameObject scene2;

	public GameObject scene3;

	public Transform buttonsParent;

	public GameObject buttonPrefabs;

	private GameObject buttons;

	private DialogManager dlgMan;

	private SAMPLE_SCENE_MODE mode;

	private SAMPLE_SCENE_MODE lastMode;

	public override void SceneStart()
	{
		dlgMan = DialogManager.Instance;
		mode = SAMPLE_SCENE_MODE.Scene1;
		lastMode = mode;
		buttons = (GameObject)UnityEngine.Object.Instantiate(buttonPrefabs);
		buttons.transform.parent = buttonsParent;
		buttons.transform.localPosition = Vector3.zero;
		buttons.transform.localScale = Vector3.one;
		int i = 0;
		UIButtonMessage[] componentsInChildren = buttons.GetComponentsInChildren<UIButtonMessage>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			componentsInChildren[i].functionName = componentsInChildren[i].functionName;
			componentsInChildren[i].message = componentsInChildren[i].functionName;
			componentsInChildren[i].mode = UIButtonMessage.SendMode.Message;
		}
		InitScene();
	}

	private void InitScene()
	{
		scene1.SetActive(value: true);
		scene2.SetActive(value: false);
		scene3.SetActive(value: false);
		buttons.SetActive(value: false);
		InfomationBarHUD.UpdateText("クエスト成功！");
	}

	public override void SceneUpdate()
	{
		if (mode == SAMPLE_SCENE_MODE.Scene4 && DialogManager.LastResult == 1)
		{
			TouchScreen(null);
			dlgMan.OnButton(0);
			InfomationBarHUD.SetActive(a: true);
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			if (mode == SAMPLE_SCENE_MODE.Scene1)
			{
				InitScene();
			}
			if (mode == SAMPLE_SCENE_MODE.Scene2)
			{
				scene1.SetActive(value: false);
				scene2.SetActive(value: true);
				scene3.SetActive(value: false);
				buttons.SetActive(value: false);
				InfomationBarHUD.UpdateText("ボス出現！");
			}
			if (mode == SAMPLE_SCENE_MODE.Scene3)
			{
				scene1.SetActive(value: false);
				scene2.SetActive(value: false);
				scene3.SetActive(value: true);
				buttons.SetActive(value: true);
				InfomationBarHUD.UpdateText("タイムオーバー");
			}
			if (mode == SAMPLE_SCENE_MODE.Scene4)
			{
				scene1.SetActive(value: false);
				scene2.SetActive(value: false);
				scene3.SetActive(value: false);
				buttons.SetActive(value: false);
				InfomationBarHUD.SetActive(a: false);
				dlgMan.OpenDialog("だいあろぐだよ", "サンプルダイアログ", DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
			}
			SetupAllNullButton();
		}
	}

	public void TouchScreen(GameObject obj)
	{
		mode = (SAMPLE_SCENE_MODE)checked(unchecked((int)mode % (5 - 1)) + 1);
	}

	public void PushBack()
	{
		if (SAMPLE_SCENE_MODE.None < mode)
		{
			mode--;
		}
		if (mode <= SAMPLE_SCENE_MODE.None)
		{
			mode = SAMPLE_SCENE_MODE.Scene3;
		}
	}

	public void PushYes(string str)
	{
		Debug.Log(str);
	}
}
