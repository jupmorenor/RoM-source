using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class WeaponBounds : MonoBehaviour
{
	public bool check;

	public bool remove;

	public void Update()
	{
		if (check)
		{
			Check();
			check = false;
		}
		if (remove)
		{
			Remove();
			remove = false;
		}
	}

	public void Check()
	{
		int childCount = this.transform.childCount;
		GameObject[] array = new GameObject[childCount];
		int num = 0;
		int num2 = childCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = this.transform.GetChild(index).gameObject;
			MeshFilter componentInChildren = array[RuntimeServices.NormalizeArrayIndex(array, index)].GetComponentInChildren<MeshFilter>();
			if (!componentInChildren)
			{
				Debug.LogError("No MeshFilter " + array[RuntimeServices.NormalizeArrayIndex(array, index)].name);
				continue;
			}
			Mesh sharedMesh = componentInChildren.sharedMesh;
			if (!sharedMesh)
			{
				Debug.LogError("No Mesh " + array[RuntimeServices.NormalizeArrayIndex(array, index)].name);
				continue;
			}
			Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, index)].transform.Find("Bounds");
			if (!transform)
			{
				transform = new GameObject("Bounds").transform;
			}
			transform.parent = array[RuntimeServices.NormalizeArrayIndex(array, index)].transform;
			transform.localRotation = Quaternion.identity;
			transform.localPosition = sharedMesh.bounds.center;
			transform.localScale = sharedMesh.bounds.size;
		}
		int num3 = 0;
		int num4 = childCount;
		if (num4 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < num4)
		{
			int index2 = num3;
			num3++;
			array[RuntimeServices.NormalizeArrayIndex(array, index2)].transform.parent = null;
		}
	}

	public void Remove()
	{
		GameObject gameObject = GameObject.Find("Trash");
		if (!gameObject)
		{
			gameObject = new GameObject("Trash");
		}
		gameObject.SetActive(value: false);
		int childCount = this.transform.childCount;
		int num = 0;
		int num2 = childCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject gameObject2 = this.transform.GetChild(index).gameObject;
			Transform transform = gameObject2.transform.Find("Bounds");
			if ((bool)transform)
			{
				transform.parent = gameObject.transform;
			}
		}
	}
}
