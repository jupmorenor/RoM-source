using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EPObjectPoint : AbstractEventPoint
{
	public string objName;

	public float inRange;

	private Transform obj;

	public EPObjectPoint(MScenes _scene, string _objName)
	{
		inRange = 2f;
		scene = _scene;
		objName = _objName;
	}

	public override void initInScene()
	{
		GameObject gameObject = GameObject.Find(objName);
		if (gameObject != null)
		{
			obj = gameObject.transform;
		}
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		int result;
		if (obj == null)
		{
			result = 0;
		}
		else
		{
			Vector3 vector = obj.position;
			result = (((vector - env.playerPos).magnitude < inRange) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public override Vector3 position()
	{
		return obj.position;
	}

	public override string ToString()
	{
		return new StringBuilder("EPObjectPoint(").Append(scene).Append(" ").Append(objName)
			.Append(") obj=")
			.Append(obj)
			.ToString();
	}
}
