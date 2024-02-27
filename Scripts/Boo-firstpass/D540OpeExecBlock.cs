using System;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class D540OpeExecBlock : D540OpeCode
{
	private ICallable block;

	public ICallable Block
	{
		get
		{
			return block;
		}
		set
		{
			block = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeExecBlock(this);
	}

	public override D540OpeCode clone()
	{
		return New(block);
	}

	public override void clear()
	{
		block = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeExecBlock New(ICallable block)
	{
		D540OpeExecBlock d540OpeExecBlock = (D540OpeExecBlock)D540OpeCodePool.NewObj(D540OpeCodeId.OpeExecBlock);
		d540OpeExecBlock.Block = block;
		return d540OpeExecBlock;
	}
}
