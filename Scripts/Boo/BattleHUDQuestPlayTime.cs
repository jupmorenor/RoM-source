using System;
using UnityEngine;

[Serializable]
public class BattleHUDQuestPlayTime : MonoBehaviour
{
	[Serializable]
	public class NumPair
	{
		public UILabelBase base10;

		public UILabelBase base1;

		private int lastSetValue;

		public NumPair()
		{
			lastSetValue = int.MinValue;
		}

		public void setValue(int n)
		{
			int num = Mathf.Min(n, 99);
			if (lastSetValue != num)
			{
				UIBasicUtility.SetLabel(base10, (num / 10).ToString(), show: true);
				UIBasicUtility.SetLabel(base1, (num % 10).ToString(), show: true);
				lastSetValue = num;
			}
		}
	}

	public GameObject root;

	public NumPair minLabel;

	public NumPair secLabel;

	public NumPair dsecLabel;

	private bool display;

	public void Start()
	{
		MQuests quest = QuestSession.Quest;
		display = UserData.Current.userQuestMission.hasClearTimeMission(quest);
		if (root != null)
		{
			root.SetActive(display);
		}
	}

	public void Update()
	{
		if (display)
		{
			updateLabel(QuestEventHandler.PlayerCurrentPlayTime);
		}
	}

	private void updateLabel(float tm)
	{
		checked
		{
			int num = (int)(tm / 60f);
			int value = (int)(tm - (float)(num * 60));
			int value2 = (int)((tm - Mathf.Floor(tm)) * 100f);
			if (minLabel != null)
			{
				minLabel.setValue(num);
			}
			if (secLabel != null)
			{
				secLabel.setValue(value);
			}
			if (dsecLabel != null)
			{
				dsecLabel.setValue(value2);
			}
		}
	}
}
