using System;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpeMotionID : D540OpeCode
{
	private string _name;

	private bool hasMotionName;

	private string motionTypeName;

	private MotionID motionID;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public bool HasMotionName
	{
		get
		{
			return hasMotionName;
		}
		set
		{
			hasMotionName = value;
		}
	}

	public string MotionTypeName
	{
		get
		{
			return motionTypeName;
		}
		set
		{
			motionTypeName = value;
		}
	}

	public MotionID MotionID
	{
		get
		{
			return motionID;
		}
		set
		{
			motionID = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeMotionID(this);
	}

	public override void clear()
	{
		_name = null;
		hasMotionName = false;
		motionTypeName = null;
		motionID = default(MotionID);
	}

	public override D540OpeCode clone()
	{
		D540OpeMotionID d540OpeMotionID = New();
		d540OpeMotionID._name = _name;
		d540OpeMotionID.hasMotionName = hasMotionName;
		d540OpeMotionID.motionTypeName = motionTypeName;
		return d540OpeMotionID;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeMotionID New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeMotionID) as D540OpeMotionID;
	}

	public static D540OpeMotionID NewByName(string _name)
	{
		D540OpeMotionID d540OpeMotionID = New();
		d540OpeMotionID._name = _name;
		d540OpeMotionID.hasMotionName = true;
		return d540OpeMotionID;
	}

	public static D540OpeMotionID NewByEnumType(string _name, string _enumName)
	{
		D540OpeMotionID d540OpeMotionID = New();
		d540OpeMotionID._name = _name;
		d540OpeMotionID.motionTypeName = _enumName;
		d540OpeMotionID.hasMotionName = false;
		return d540OpeMotionID;
	}

	public override string ToString()
	{
		return GetType().ToString() + new StringBuilder("('").Append(_name).Append("' motname=").Append(hasMotionName)
			.Append(" mottypename=")
			.Append(motionTypeName)
			.Append(")")
			.ToString();
	}
}
