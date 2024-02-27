using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class DropDataKusamushi : QuestDropManager.DropData
{
	public int kusamushiMasterId;

	private bool _0024initialized__DropDataKusamushi_0024;

	public MKusamushi Master => MKusamushi.Get(kusamushiMasterId);

	public DropDataKusamushi()
	{
		if (!_0024initialized__DropDataKusamushi_0024)
		{
			_0024initialized__DropDataKusamushi_0024 = true;
		}
	}

	public DropDataKusamushi(int kmId)
	{
		if (!_0024initialized__DropDataKusamushi_0024)
		{
			_0024initialized__DropDataKusamushi_0024 = true;
		}
		if (MKusamushi.Get(kmId) == null)
		{
			throw new AssertionFailedException("MKusamushi.Get(kmId) != null");
		}
		kusamushiMasterId = kmId;
	}

	public DropDataKusamushi(MKusamushi km)
	{
		if (!_0024initialized__DropDataKusamushi_0024)
		{
			_0024initialized__DropDataKusamushi_0024 = true;
		}
		if (km == null)
		{
			throw new AssertionFailedException("km != null");
		}
		kusamushiMasterId = km.Id;
	}

	public override GameObject doInstantiate()
	{
		return QuestAssets.Instance.instantiateKusamushi().gameObject;
	}
}
