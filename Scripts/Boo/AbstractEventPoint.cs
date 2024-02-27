using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public abstract class AbstractEventPoint
{
	public MScenes scene;

	public bool isInScene(MScenes scn)
	{
		return RuntimeServices.EqualityOperator(scene, scn);
	}

	public virtual void initInScene()
	{
	}

	public virtual bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		return false;
	}

	public virtual Vector3 position()
	{
		return Vector3.zero;
	}

	public virtual void dump()
	{
	}
}
