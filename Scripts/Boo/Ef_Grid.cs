using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_Grid : MonoBehaviour
{
	public float gridX;

	public float gridY;

	public float gridZ;

	public string fiastName;

	public int number;

	public Ef_Grid()
	{
		gridX = 1f;
		gridY = 1f;
		gridZ = 1f;
		fiastName = "b";
	}

	public void Update()
	{
		Vector3 localPosition = transform.localPosition;
		localPosition.x = Mathf.Ceil(localPosition.x / gridX) * gridX;
		localPosition.y = Mathf.Ceil(localPosition.y / gridY) * gridY;
		localPosition.z = Mathf.Ceil(localPosition.z / gridZ) * gridZ;
		transform.localPosition = localPosition;
	}

	public void Start()
	{
		string text = gameObject.name;
		gameObject.name = string.Empty;
		checked
		{
			if ((bool)transform.parent)
			{
				if ((bool)transform.parent.Find(text))
				{
					number++;
					text = fiastName;
					if (number < 10)
					{
						text += "0";
					}
					text += number;
					gameObject.name = text;
					return;
				}
			}
			else if ((bool)GameObject.Find(text))
			{
				number++;
				text = fiastName;
				if (number < 10)
				{
					text += "0";
				}
				text += number;
				gameObject.name = text;
				return;
			}
			gameObject.name = text;
		}
	}
}
