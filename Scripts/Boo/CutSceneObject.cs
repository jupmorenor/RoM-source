using System;
using UnityEngine;

[Serializable]
public class CutSceneObject : MonoBehaviour
{
	private string id;

	public string Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
		}
	}

	public void Start()
	{
	}

	public void Update()
	{
	}
}
