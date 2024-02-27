using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SortWindowCreator : MonoBehaviour
{
	public GameObject windowPrefab;

	public GameObject buttonPrefab;

	public bool isSimpleSort;

	public SortWindowCreator()
	{
		isSimpleSort = true;
	}

	public SortListWindow Create(Transform parent, GameObject target, string[] sortNameList)
	{
		GameObject gameObject = BasicCreate(parent, windowPrefab, isWindow: true);
		SortListWindow component = gameObject.GetComponent<SortListWindow>();
		int num = 0;
		int length = sortNameList.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			string text = sortNameList[RuntimeServices.NormalizeArrayIndex(sortNameList, num2)];
			Transform buttonTrans = component.GetButtonTrans(num2);
			GameObject gameObject2 = BasicCreate(buttonTrans, buttonPrefab, isWindow: false);
			SortListButton component2 = gameObject2.GetComponent<SortListButton>();
			component2.Initialize(target, text, isSimpleSort);
			component.AddButton(text, component2);
		}
		return component;
	}

	private GameObject BasicCreate(Transform parent, GameObject prefab, bool isWindow)
	{
		GameObject gameObject = ((!isWindow) ? NGUITools.InstantiateWithoutUIPanel(prefab) : ((GameObject)UnityEngine.Object.Instantiate(prefab)));
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}
}
