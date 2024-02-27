using System;
using UnityEngine;

[Serializable]
public class ColosseumBattleMainHUD : MonoBehaviour
{
	[NonSerialized]
	public ColosseumBattleControl battleControl;

	public ColosseumTeamHUD leftTeam;

	public ColosseumTeamHUD rightTeam;

	public UILabelBase timeLabel;

	public UIAutoTweener mainTweener;

	public void Start()
	{
		mainTweener.Initialize();
		mainTweener.StopAnimation();
		mainTweener.transform.localPosition = new Vector3(0f, -10000f, 0f);
	}

	public void Init(ColosseumBattleControl setBattleControl)
	{
		battleControl = setBattleControl;
	}

	public void SetTeamData(ColosseumTeam setLeft, ColosseumTeam setRight)
	{
		leftTeam.Init(setLeft);
		rightTeam.Init(setRight);
	}

	public void Show()
	{
		bool flag;
		mainTweener.PlayAnimation(flag = true);
		leftTeam.Show();
		rightTeam.Show();
	}

	public void Update()
	{
		if (!(battleControl == null))
		{
			timeLabel.text = battleControl.BattleTimer.ToString();
		}
	}
}
