using System;
using UnityEngine;

[Serializable]
public class DummyDummy : MonoBehaviour
{
	public void OnGUI()
	{
		Rect position = new Rect(100f, 100f, 320f, 100f);
		GUI.Label(position, "このbundle id のアプリは廃止しました。");
	}
}
