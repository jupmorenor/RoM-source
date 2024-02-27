using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EPJumpPoint : AbstractEventPoint
{
	public MScenes jumpTo;

	public EnumMapLinkDir dir;

	private GameObject linkObj;

	public EPJumpPoint(MScenes _scene, MScenes _jumpTo, EnumMapLinkDir _dir)
	{
		scene = _scene;
		jumpTo = _jumpTo;
		dir = _dir;
	}

	public EPJumpPoint(MScenes _scene)
	{
		scene = _scene;
		jumpTo = null;
	}

	public override void initInScene()
	{
		if (QuestMapper.Current != null && jumpTo != null)
		{
			linkObj = QuestMapper.Current.GetLinkObject(dir);
		}
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		return false;
	}

	public override Vector3 position()
	{
		return (!(linkObj != null) || jumpTo == null) ? Vector3.zero : linkObj.transform.position;
	}

	public override string ToString()
	{
		return (jumpTo == null) ? new StringBuilder("EPJumpPoint(").Append(scene).Append(" stop)").ToString() : new StringBuilder("EPJumpPoint(").Append(scene).Append(" <").Append(dir)
			.Append(">-> ")
			.Append(jumpTo)
			.Append(") obj=")
			.Append(linkObj)
			.ToString();
	}
}
