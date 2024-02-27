using System;
using UnityEngine;

[Serializable]
public class D540OpeCode
{
	public D540OpeCodeId poolId;

	[NonSerialized]
	protected static readonly HideFlags DEFAULT_HIDE_FLAG = HideFlags.HideInHierarchy;

	public string sourceFile;

	public string sourcePosition;

	public override bool IsValueNode => false;

	public override object Value => null;

	public string SourceFile => sourceFile;

	public string SourcePosition => sourcePosition;

	public D540OpeCode()
	{
		poolId = (D540OpeCodeId)(-1);
		if (!Application.isEditor && D540OpeCodePool.Instance.IsInAllocation)
		{
		}
	}

	public virtual void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeCode(this);
	}

	public virtual D540OpeCode clone()
	{
		return New();
	}

	public virtual void clear()
	{
	}

	public virtual void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = DEFAULT_HIDE_FLAG;
	}

	public virtual void OnGUI()
	{
	}

	public static D540OpeCode New()
	{
		return new D540OpeCode();
	}
}
