using System;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TDManager : MonoBehaviour
{
	private GameObject tower;

	private List<GameObject> towers;

	public TDManager()
	{
		towers = new List<GameObject>();
	}

	public void Start()
	{
		tower = GameObject.Find("TDtower");
		if (!(tower == null))
		{
		}
	}

	public void CreateTD(int iIndex, Vector3 vPos)
	{
		vPos.y += 0.3f;
		GameObject item = ((GameObject)UnityEngine.Object.Instantiate(tower, vPos, Quaternion.identity)) as GameObject;
		towers.Add(item);
	}

	public void RemoveTDAll()
	{
		int count = towers.Count;
		int num = 0;
		int num2 = count;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject obj = towers[index];
			UnityEngine.Object.Destroy(obj);
		}
		towers.Clear();
	}

	public GameObject DebugGetTower()
	{
		return tower;
	}

	public int DebugGetTowerNum()
	{
		return towers.Count;
	}
}
