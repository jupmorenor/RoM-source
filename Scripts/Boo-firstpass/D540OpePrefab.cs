using System;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpePrefab : D540OpeCode
{
	private string prefabName;

	public string PrefabName
	{
		get
		{
			return prefabName;
		}
		set
		{
			prefabName = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpePrefab(this);
	}

	public override D540OpeCode clone()
	{
		return New(prefabName);
	}

	public override void clear()
	{
		prefabName = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpePrefab New(string n)
	{
		D540OpePrefab d540OpePrefab = (D540OpePrefab)D540OpeCodePool.NewObj(D540OpeCodeId.OpePrefab);
		d540OpePrefab.prefabName = n;
		return d540OpePrefab;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpePrefab ").Append(prefabName).ToString();
	}
}
