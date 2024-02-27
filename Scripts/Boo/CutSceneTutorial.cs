using System;

[Serializable]
public class CutSceneTutorial : CutScenePlayer
{
	public override void EndCallback()
	{
		exit();
	}
}
