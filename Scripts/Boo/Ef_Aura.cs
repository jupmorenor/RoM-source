using System;
using UnityEngine;

[Serializable]
public class Ef_Aura : Ef_Base
{
	public void Start()
	{
		Transform parent = this.transform.parent;
		if (!parent)
		{
			return;
		}
		if (parent.childCount > 0)
		{
			Transform transform = parent.GetChild(0).Find("y_ang");
			if ((bool)transform)
			{
				Transform transform2 = transform.Find("cog");
				if ((bool)transform2)
				{
					this.transform.parent = transform2;
				}
				else
				{
					this.transform.parent = transform;
				}
			}
			else
			{
				this.transform.parent = parent.GetChild(0);
			}
		}
		else
		{
			this.transform.parent = parent;
		}
	}

	public void Update()
	{
		Transform parent = transform.parent;
		if ((bool)parent)
		{
			Vector3 position = parent.position;
			position.y -= 1f;
			transform.position = position;
		}
	}
}
