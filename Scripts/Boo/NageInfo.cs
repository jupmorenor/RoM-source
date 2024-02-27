using System;
using ObjUtil;
using UnityEngine;

[Serializable]
public class NageInfo
{
	[NonSerialized]
	private static int serialID = 1;

	public int id;

	public string nageBone;

	public float endTime;

	public MotionID attackMot;

	public float attackMotStart;

	public MotionID yarareMot;

	public MotionID yarareResultMot;

	public float yarareResultMotStartTime;

	public float yarareStopTime;

	public Quaternion yarareLocalRot;

	public Vector3 yarareLocalPos;

	public float hideTime;

	public float showTime;

	public float damageTime;

	public float knockBackPow;

	public bool IsValid => nageBone != null;

	public bool NeedHideAndShow
	{
		get
		{
			bool num = hideTime < showTime;
			if (num)
			{
				num = !(hideTime < 0f);
			}
			return num;
		}
	}

	public NageInfo()
	{
		yarareLocalRot = Quaternion.identity;
		yarareLocalPos = Vector3.zero;
		id = checked(++serialID);
	}

	public override int GetHashCode()
	{
		return serialID;
	}

	public override string ToString()
	{
		return ObjUtilModule.DebugObjectInspection(this);
	}
}
