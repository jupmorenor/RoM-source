using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ModelChange : MonoBehaviour
{
	public GameObject[] models;

	protected int model;

	public void Start()
	{
		if (Application.loadedLevelName != "BGViewer")
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public void OnGUI()
	{
		if (!GUI.Button(new Rect(10f, 350f, 100f, 60f), "model change"))
		{
			return;
		}
		int num;
		int length;
		checked
		{
			model++;
			if (model > models.Length)
			{
				model = 0;
			}
			num = 0;
			length = models.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			if (num2 == model)
			{
				GameObject[] array = models;
				array[RuntimeServices.NormalizeArrayIndex(array, num2)].SetActive(value: true);
			}
			else
			{
				GameObject[] array2 = models;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].SetActive(value: false);
			}
		}
	}
}
