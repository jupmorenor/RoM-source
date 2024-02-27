using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PicBookMotionViewer : MonoBehaviour
{
	private MerlinMotionPackControl mmpc;

	private AIControl ai;

	private MerlinMotionPack.CommonEntry[] commonEntries;

	private int entryIndex;

	private string idleMotionName;

	public float startIdleTime;

	public float runInterval;

	public float motionInterval;

	public float fadeTime;

	public float idleFadeTime;

	public float idleWaitTime;

	private float restInterval;

	private bool waitEndMotion;

	public PicBookMotionViewer()
	{
		idleMotionName = string.Empty;
		startIdleTime = 4f;
		runInterval = 4f;
		motionInterval = 2f;
		fadeTime = 0.1f;
		idleFadeTime = 0.2f;
		idleWaitTime = 0.5f;
	}

	public void Init(GameObject model)
	{
		mmpc = model.GetComponent<MerlinMotionPackControl>();
		if (mmpc == null)
		{
			return;
		}
		ai = model.GetComponent<AIControl>();
		if (ai == null)
		{
			return;
		}
		MerlinMotionPack[] allPacks = mmpc.AllPacks;
		if (allPacks.Length == 0)
		{
			return;
		}
		MerlinMotionPack merlinMotionPack = allPacks[0];
		if (merlinMotionPack == null)
		{
			return;
		}
		commonEntries = merlinMotionPack.commonEntries;
		if (commonEntries == null)
		{
			return;
		}
		SetupDisplayMotion(model);
		restInterval = startIdleTime;
		entryIndex = 0;
		idleMotionName = string.Empty;
		int num = 0;
		int length = commonEntries.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			MerlinMotionPack.CommonEntry[] array = commonEntries;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)].enumName == "Idle")
			{
				MerlinMotionPack.CommonEntry[] array2 = commonEntries;
				idleMotionName = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].animName;
				entryIndex = index;
				break;
			}
		}
	}

	public void SetupDisplayMotion(GameObject model)
	{
		PicBookContents component = model.GetComponent<PicBookContents>();
		if (component == null || string.IsNullOrEmpty(component.PicBookDisplayMotion))
		{
			return;
		}
		string[] array = component.PicBookDisplayMotion.Split(',');
		if (array.Length == 0)
		{
			return;
		}
		List<MerlinMotionPack.CommonEntry> list = new List<MerlinMotionPack.CommonEntry>();
		int i = 0;
		MerlinMotionPack.CommonEntry[] array2 = commonEntries;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				int j = 0;
				string[] array3 = array;
				for (int length2 = array3.Length; j < length2; j++)
				{
					if (array2[i].enumName == array3[j])
					{
						list.Add(array2[i]);
					}
				}
			}
			if (((ICollection)list).Count != 0)
			{
				commonEntries = list.ToArray();
			}
		}
	}

	public void Update()
	{
		if (mmpc == null)
		{
			return;
		}
		if (waitEndMotion)
		{
			if (!IsFinishLastPlay() && !IsEntryRun())
			{
				return;
			}
			SetNextInterval();
			waitEndMotion = false;
		}
		if (!Input.GetMouseButton(0))
		{
			restInterval -= Time.deltaTime;
		}
		if (!(restInterval < 0f))
		{
			if (IsEntryRun() && !(restInterval <= idleWaitTime))
			{
				ai.inputMove();
			}
		}
		else if (!(restInterval >= 0f))
		{
			if (IsIdle())
			{
				NextMotion();
				waitEndMotion = true;
			}
			else
			{
				PlayIdle();
			}
		}
	}

	public void SetNextInterval()
	{
		if (IsEntryRun())
		{
			restInterval = runInterval;
		}
		else
		{
			restInterval = motionInterval;
		}
	}

	public void NextMotion()
	{
		restInterval = -100f;
		entryIndex = checked(entryIndex + 1) % commonEntries.Length;
		MerlinMotionPack.CommonEntry[] array = commonEntries;
		if (array[RuntimeServices.NormalizeArrayIndex(array, entryIndex)].enumName == "Idle")
		{
			entryIndex = checked(entryIndex + 1) % commonEntries.Length;
		}
		MerlinMotionPackControl merlinMotionPackControl = mmpc;
		MerlinMotionPack.CommonEntry[] array2 = commonEntries;
		merlinMotionPackControl.play(array2[RuntimeServices.NormalizeArrayIndex(array2, entryIndex)].animName, fadeTime);
	}

	public bool IsFinishLastPlay()
	{
		bool num = mmpc.IsEndOfMotion;
		if (!num)
		{
			num = mmpc.IsLoop;
			if (num)
			{
				num = mmpc.CurrentEntry != null;
				if (num)
				{
					num = mmpc.CurrentEntry.name == idleMotionName;
				}
			}
		}
		return num;
	}

	public bool IsEntryRun()
	{
		MerlinMotionPack.CommonEntry[] array = commonEntries;
		return array[RuntimeServices.NormalizeArrayIndex(array, entryIndex)].enumName == "Run";
	}

	public bool IsIdle()
	{
		bool num = mmpc.CurrentEntry != null;
		if (num)
		{
			num = mmpc.CurrentEntry.name == idleMotionName;
		}
		return num;
	}

	public void PlayIdle()
	{
		mmpc.play(idleMotionName, idleFadeTime);
		restInterval = idleWaitTime;
	}
}
