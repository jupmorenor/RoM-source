using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EPFlagPoint : AbstractEventPoint
{
	public string flagName;

	public string positionInfo;

	public float areaRange;

	private Vector3 vec3Pos;

	public EPFlagPoint(MScenes _scene, string _flagName, string _positionInfo)
	{
		areaRange = 1f;
		scene = _scene;
		flagName = _flagName;
		positionInfo = _positionInfo;
	}

	public override void initInScene()
	{
		if (!string.IsNullOrEmpty(positionInfo))
		{
			object[] array = GameLevelManager.ParseNpcPos(positionInfo, Vector3.zero, Quaternion.identity);
			Vector3 vector = (Vector3)array[0];
			Quaternion quaternion = (Quaternion)array[1];
			vec3Pos = vector;
		}
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		UserMiscInfo.FlagData flagData = UserData.Current.userMiscInfo.flagData;
		return flagData.hasFlag(flagName);
	}

	public override Vector3 position()
	{
		return vec3Pos;
	}

	public override string ToString()
	{
		return new StringBuilder("EPFlagPoint(").Append(scene).Append(" ").Append(flagName)
			.Append(" ")
			.Append(positionInfo)
			.Append(" R:")
			.Append(areaRange)
			.Append(")")
			.ToString();
	}
}
