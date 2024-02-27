using System;
using UnityEngine;

[Serializable]
public class CampaignPanel : MonoBehaviour
{
	[Serializable]
	public enum CampaignType
	{
		Ap,
		Rp,
		Coin,
		Exp,
		Drop,
		PowPrice,
		PowExp,
		CoinAndExp
	}

	public UILabelBase label;

	public RaidNamePlate namePlate;

	public GameObject[] icons;

	protected bool init;

	public static Color UpColor => UIBasicUtility.GetColor(250f, 125f, 126f);

	public static Color DownColor => UIBasicUtility.GetColor(9f, 178f, 233f);

	public CampaignPanel()
	{
		icons = new GameObject[7 + 1];
	}

	public void Awake()
	{
		if (!init)
		{
			gameObject.SetActive(value: false);
		}
	}

	public void Init(CampaignType type, string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			gameObject.SetActive(value: false);
			return;
		}
		init = true;
		Color color = UpColor;
		if (icons != null)
		{
			int num = 0;
			int i = 0;
			GameObject[] array = icons;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if ((bool)array[i])
				{
					array[i].SetActive(num == (int)type);
				}
				if (num == (int)type && num == 5)
				{
					if (text == "1/2")
					{
						text = "半額";
					}
					color = DownColor;
				}
				num = checked(num + 1);
			}
		}
		if ((bool)namePlate)
		{
			namePlate.setName(text);
			namePlate.setColor(color);
			namePlate.gameObject.SetActive(value: true);
			if ((bool)label)
			{
				label.gameObject.SetActive(value: false);
			}
		}
		else if ((bool)label)
		{
			label.text = text;
			label.color = color;
			label.gameObject.SetActive(value: true);
		}
		gameObject.SetActive(value: true);
	}
}
