using System;
using UnityEngine;

[Serializable]
public class MotionViewerMMPCSet : MonoBehaviour
{
	public float interval;

	public Transform charcters;

	public MerlinMotionPack[] motionPacks;

	private float timer;

	private bool end;

	public MotionViewerMMPCSet()
	{
		interval = 5f;
	}

	public void Update()
	{
		timer -= Time.deltaTime;
		if (!(timer > 0f))
		{
			SetMMPC();
			timer = interval;
		}
	}

	public void SetMMPC()
	{
		if (!charcters)
		{
			GameObject gameObject = GameObject.Find("_Characters");
			if ((bool)gameObject)
			{
				charcters = gameObject.transform;
			}
			if (!charcters)
			{
				return;
			}
		}
		MerlinMotionPackControl[] componentsInChildren = charcters.GetComponentsInChildren<MerlinMotionPackControl>();
		checked
		{
			if (componentsInChildren.Length == 0)
			{
				end = false;
			}
			else
			{
				if (end)
				{
					return;
				}
				int i = 0;
				MerlinMotionPackControl[] array = componentsInChildren;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i].gameObject.name.Substring(0, 5) == "C0000" && array[i].motionPacks.Length == 0)
					{
						array[i].motionPacks = motionPacks;
					}
					int j = 0;
					MerlinMotionPack[] array2 = array[i].motionPacks;
					for (int length2 = array2.Length; j < length2; j++)
					{
						int k = 0;
						MerlinMotionPack.Entry[] entries = array2[j].entries;
						for (int length3 = entries.Length; k < length3; k++)
						{
							if (entries[k].clip == null && (bool)animation[entries[k].name])
							{
								entries[k].clip = animation[entries[k].name].clip;
							}
						}
					}
					array[i].Awake();
					end = true;
				}
			}
		}
	}
}
