using System;
using System.Text;

[Serializable]
public struct MotionID
{
	public string motionName;

	public int motionType;

	public bool hasMotionName;

	public bool notValid;

	public bool IsValid => !notValid;

	public static MotionID InvalidID()
	{
		MotionID result = default(MotionID);
		bool flag = (result.notValid = true);
		return result;
	}

	public static MotionID ByName(string n)
	{
		MotionID result = default(MotionID);
		string text = (result.motionName = n);
		bool flag = (result.hasMotionName = true);
		return result;
	}

	public static MotionID ByType(int n)
	{
		MotionID result = default(MotionID);
		int num = (result.motionType = n);
		bool flag = (result.hasMotionName = false);
		return result;
	}

	public override string ToString()
	{
		return (!hasMotionName) ? new StringBuilder("MotionID(type=").Append((object)motionType).Append(")").ToString() : new StringBuilder("MotionID(name=").Append(motionName).Append(")").ToString();
	}
}
