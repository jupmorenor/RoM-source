using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class EnemyInstantiationData
{
	public RespMonster monster;

	public bool withPopEffect;

	public Vector3 pos;

	public Quaternion rot;

	public bool useNPCPos;

	public AIControl resultAI;

	public EnemyInstantiationData()
	{
		withPopEffect = true;
		pos = Vector3.zero;
		rot = Quaternion.identity;
	}
}
