using System;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DropDataStageCoin : QuestDropManager.DropData
{
	private RespMonster dummyMonster;

	private bool _0024initialized__DropDataStageCoin_0024;

	public RespMonster DummyMonster => dummyMonster;

	public DropDataStageCoin()
	{
		if (!_0024initialized__DropDataStageCoin_0024)
		{
			_0024initialized__DropDataStageCoin_0024 = true;
		}
	}

	public DropDataStageCoin(RespMonster dmon)
	{
		if (!_0024initialized__DropDataStageCoin_0024)
		{
			_0024initialized__DropDataStageCoin_0024 = true;
		}
		if (dmon == null)
		{
			throw new AssertionFailedException("dmon != null");
		}
		dummyMonster = dmon;
	}

	public override GameObject doInstantiate()
	{
		return QuestAssets.Instance.instantiateStageCoin().gameObject;
	}
}
