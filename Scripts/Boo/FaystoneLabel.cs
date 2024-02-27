using System;
using UnityEngine;

[Serializable]
public class FaystoneLabel : MonoBehaviour
{
	protected UILabelBase label;

	protected int lastStone;

	public bool debugFlag;

	public int debugStone;

	public FaystoneLabel()
	{
		lastStone = -1;
	}

	public void Start()
	{
		label = gameObject.GetComponent<UILabelBase>();
	}

	public void Update()
	{
		if (!(label == null))
		{
			int num = UserData.Current.FayStone;
			if (debugFlag)
			{
				num = debugStone;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (lastStone != num)
			{
				lastStone = num;
				label.text = UIBasicUtility.SafeFormat("{0:#,0}", num);
			}
		}
	}
}
