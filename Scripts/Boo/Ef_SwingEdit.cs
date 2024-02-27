using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_SwingEdit : MonoBehaviour
{
	public Ef_Swing sw;

	public bool initialize;

	public bool childPic;

	public void Update()
	{
		SwingSet();
	}

	public void SwingSet()
	{
		if (initialize)
		{
			initialize = false;
			if (!sw)
			{
				sw = gameObject.GetComponent<Ef_Swing>();
			}
			if (!sw)
			{
				return;
			}
			sw.Initialize();
		}
		if (childPic)
		{
			childPic = false;
			if (!sw)
			{
				sw = gameObject.GetComponent<Ef_Swing>();
			}
			if ((bool)sw && (bool)sw.arrTransform[0])
			{
				sw.arrTransform = sw.ChildPick(sw.arrTransform[0]);
			}
		}
	}
}
