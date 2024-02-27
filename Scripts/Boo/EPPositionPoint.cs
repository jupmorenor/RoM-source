using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class EPPositionPoint : AbstractEventPoint
{
	[NonSerialized]
	private const float POINT_RADIUS = 1.5f;

	public string positionInfo;

	private bool initialized;

	private Vector3 vec3Pos;

	public EPPositionPoint(MScenes _scene, string _positionInfo)
	{
		vec3Pos = Vector3.zero;
		scene = _scene;
		positionInfo = _positionInfo;
	}

	public new bool isInScene(MScenes scn)
	{
		return RuntimeServices.EqualityOperator(scene, scn);
	}

	public override void initInScene()
	{
		object[] array = GameLevelManager.ParseNpcPos(positionInfo, Vector3.zero, Quaternion.identity);
		Vector3 vector = (Vector3)array[0];
		Quaternion quaternion = (Quaternion)array[1];
		vec3Pos = vector;
		initialized = true;
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		bool num = initialized;
		if (num)
		{
			num = (vec3Pos - env.playerPos).magnitude < 1.5f;
		}
		return num;
	}

	public override Vector3 position()
	{
		return (!initialized) ? Vector3.zero : vec3Pos;
	}

	public override void dump()
	{
	}
}
