using System;
using System.Text;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class StoneListItem : MonoBehaviour
{
	public UILabelBase nameLabel;

	public UILabelBase typeLabel;

	public UILabelBase priceLabel;

	private RespInAppProduct stoneInfo;

	public GameObject bounsObj;

	public UILabelBase bounsLabel;

	public UISprite baseSprite;

	public GameObject campaignObj;

	public UILabelBase campaignLabel;

	public string campaignText;

	public Color[] colors;

	public RespInAppProduct StoneInfo => stoneInfo;

	public StoneListItem()
	{
		campaignText = "{0}回\n限定";
		colors = new Color[2]
		{
			new Color(1f, 1f, 1f, 1f),
			new Color(1f, 0.7137255f, 0.7137255f, 1f)
		};
	}

	public void SetStone(RespInAppProduct stone, RespInAppProduct baseStone, string extraPrice)
	{
		if (stone == null)
		{
			return;
		}
		stoneInfo = stone;
		UIBasicUtility.SetLabel(nameLabel, stone.Name, show: true);
		UIBasicUtility.SetLabel(typeLabel, stone.Quantity.ToString(), show: true);
		string text = string.Empty;
		if ((bool)priceLabel)
		{
			text = ((!string.IsNullOrEmpty(extraPrice)) ? extraPrice : PriceText(stone.Price));
		}
		UIBasicUtility.SetLabel(priceLabel, text, show: true);
		int num = CalcBonus(stone, baseStone);
		if ((bool)bounsObj)
		{
			bounsObj.SetActive(0 < num);
		}
		UIBasicUtility.SetLabel(bounsLabel, BonusText(num, baseStone.Quantity), 0 < num);
		int productSalesTypeValue = stone.ProductSalesTypeValue;
		switch (productSalesTypeValue)
		{
		case 0:
			if (null != baseSprite)
			{
				UISprite uISprite2 = baseSprite;
				Color[] array2 = colors;
				uISprite2.color = array2[RuntimeServices.NormalizeArrayIndex(array2, stone.ProductSalesTypeValue)];
			}
			if (null != campaignObj)
			{
				campaignObj.SetActive(value: false);
			}
			break;
		case 1:
			if (stone.ProductSalesLimitCount <= 0)
			{
				throw new AssertionFailedException("stone.ProductSalesLimitCount > 0");
			}
			if (null != baseSprite)
			{
				UISprite uISprite = baseSprite;
				Color[] array = colors;
				uISprite.color = array[RuntimeServices.NormalizeArrayIndex(array, stone.ProductSalesTypeValue)];
			}
			if (null != campaignObj)
			{
				campaignObj.SetActive(value: true);
			}
			if (null != campaignLabel)
			{
				campaignLabel.text = UIBasicUtility.SafeFormat(campaignText, stone.ProductSalesLimitCount);
			}
			break;
		default:
			throw new MatchError(new StringBuilder("`stone.ProductSalesTypeValue` failed to match `").Append((object)productSalesTypeValue).Append("`").ToString());
		}
	}

	private string PriceText(int p)
	{
		return UIBasicUtility.SafeFormat(MTexts.Msg("$SS_PRICE_SUFFIX"), p);
	}

	private string BonusText(int bonus, int @base)
	{
		return UIBasicUtility.SafeFormat(MTexts.Msg("$SS_BONUS_FORMAT"), bonus, @base);
	}

	private int CalcBonus(RespInAppProduct stone, RespInAppProduct baseStone)
	{
		int num2;
		checked
		{
			int num = stone.Quantity * baseStone.Price;
			num2 = num - stone.Price;
		}
		return num2 / baseStone.Price;
	}
}
