using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PrologueMain : UIMain
{
	public bool IsEndOfPlay;

	public float[] 時間設定;

	public int firstSituation;

	private int currentSituationIndex;

	private float changeSituationTimer;

	private int FinalSituationIndex => checked(situations.Length - 1);

	public PrologueMain()
	{
		時間設定 = new float[0];
	}

	public override void SceneStart()
	{
		currentSituationIndex = SetNextSituation(firstSituation);
		IsEndOfPlay = false;
	}

	public override void SceneUpdate()
	{
		if (currentSituationIndex != FinalSituationIndex && SkipButtonHUD.CanSkip())
		{
			currentSituationIndex = FinalSituationIndex;
			IsEndOfPlay = true;
		}
		changeSituationTimer -= Time.deltaTime;
		if (!(changeSituationTimer > 0f))
		{
			if (currentSituationIndex == FinalSituationIndex)
			{
				IsEndOfPlay = true;
			}
			else
			{
				currentSituationIndex = SetNextSituation(checked(currentSituationIndex + 1));
			}
		}
	}

	private void DoSkip()
	{
	}

	private int SetNextSituation(int situationIndex)
	{
		currentSituationIndex = situationIndex;
		ChangeSituation(GetSituation(currentSituationIndex));
		float[] array = 時間設定;
		changeSituationTimer = array[RuntimeServices.NormalizeArrayIndex(array, currentSituationIndex)];
		return currentSituationIndex;
	}
}
