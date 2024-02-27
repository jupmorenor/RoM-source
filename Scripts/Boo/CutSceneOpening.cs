using System;

[Serializable]
public class CutSceneOpening : CutScenePlayer
{
	public bool IsEndOfPlay;

	public override void EndCallback()
	{
		IsEndOfPlay = true;
	}
}
