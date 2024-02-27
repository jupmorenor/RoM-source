using System;
using UnityEngine;

[Serializable]
public class CubeY : MonoBehaviour
{
	public float posY;

	public GUISkin customSkin;

	public CubeY()
	{
		posY = 1.5f;
	}

	public virtual void OnGUI()
	{
		GUI.skin = customSkin;
		posY = GUI.HorizontalSlider(new Rect(610f, 30f, 220f, 50f), posY, 0.5f, 5f);
		GUI.Label(new Rect(610f, 50f, 200f, 50f), "posY " + posY);
	}

	public virtual void Update()
	{
		transform.position = new Vector3(0f, posY, 2.83f);
	}

	public virtual void Main()
	{
	}
}
