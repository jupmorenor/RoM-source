using System;
using UnityEngine;

[Serializable]
public class HelpMenu : MonoBehaviour
{
	public UILabelBase helpTitleLabel;

	public UILabelBase helpBodyLabel;

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void PushBasic()
	{
		helpTitleLabel.text = "基本ルール";
		helpBodyLabel.text = "ゲームの基本ルールについての説明です。";
	}

	public void PushBattle()
	{
		helpTitleLabel.text = "バトル";
		helpBodyLabel.text = "バトルの説明です。";
	}

	public void PushSkill()
	{
		helpTitleLabel.text = "スキル";
		helpBodyLabel.text = "スキルの説明です。";
	}

	public void PushPoppet()
	{
		helpTitleLabel.text = "魔ペット";
		helpBodyLabel.text = "魔ペットの説明です。";
	}

	public void PushTechnique()
	{
		helpTitleLabel.text = "ゲームのテクニック";
		helpBodyLabel.text = "説明を書いてくれる人を募集しています。";
	}

	public void PushPow()
	{
		helpTitleLabel.text = "強化合成";
		helpBodyLabel.text = "強化合成の説明です。\n説明を書いてくれる人を募集しています。";
	}

	public void PushEvo()
	{
		helpTitleLabel.text = "進化合成";
		helpBodyLabel.text = "進化合成の説明です。";
	}

	public void PushGacha()
	{
		helpTitleLabel.text = "くじ引き";
		helpBodyLabel.text = "くじ引きの説明です。";
	}
}
