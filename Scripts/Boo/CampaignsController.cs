using System;
using System.Linq;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CampaignsController
{
	[Serializable]
	public class CampaignsRate
	{
		[Serializable]
		public enum Index
		{
			Cost,
			Exp,
			Max
		}

		private float[] ary;

		public float cost
		{
			get
			{
				float[] array = ary;
				return checkDivNum(array[RuntimeServices.NormalizeArrayIndex(array, 0)], "cost");
			}
			set
			{
				float[] array = ary;
				array[RuntimeServices.NormalizeArrayIndex(array, 0)] = checkDivNum(value, "cost");
			}
		}

		public float exp
		{
			get
			{
				float[] array = ary;
				return array[RuntimeServices.NormalizeArrayIndex(array, 1)];
			}
			set
			{
				float[] array = ary;
				array[RuntimeServices.NormalizeArrayIndex(array, 1)] = value;
			}
		}

		public CampaignsRate()
		{
			ary = new float[2];
			Init();
		}

		private float checkDivNum(float v, string msg)
		{
			if (!(0f < v))
			{
				throw new AssertionFailedException(new StringBuilder().Append(msg).Append("の値が0以下です。MCampaignsを確認して下さい。: ").Append(v)
					.ToString());
			}
			if (!(v >= 1f))
			{
			}
			return v;
		}

		public void Init()
		{
			int num = 0;
			int num2 = 2;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				float[] array = ary;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = 1f;
			}
		}

		public int Get(int no)
		{
			float[] array = ary;
			return checked((int)array[RuntimeServices.NormalizeArrayIndex(array, no)]);
		}

		public string GetText(int no)
		{
			if (!Now(no))
			{
				goto IL_0062;
			}
			object result;
			if (no == 0)
			{
				result = UIBasicUtility.SafeFormat("1/{0}", cost);
			}
			else
			{
				if (no != 1)
				{
					goto IL_0062;
				}
				result = UIBasicUtility.SafeFormat("{0}倍", exp);
			}
			goto IL_0063;
			IL_0062:
			result = null;
			goto IL_0063;
			IL_0063:
			return (string)result;
		}

		public bool Now(int no)
		{
			return no switch
			{
				0 => 1f != cost, 
				1 => 1f != exp, 
				_ => false, 
			};
		}

		public static CampaignPanel.CampaignType ConvertType(int no)
		{
			return no switch
			{
				0 => CampaignPanel.CampaignType.PowPrice, 
				1 => CampaignPanel.CampaignType.PowExp, 
				_ => (CampaignPanel.CampaignType)(-1), 
			};
		}
	}

	public static MCampaigns[] Campaigns()
	{
		return MCampaignsUtil.GetCurrentCampaign();
	}

	public static CampaignsRate GetCampaignsRate(bool isPowup)
	{
		CampaignsRate campaignsRate = new CampaignsRate();
		int i = 0;
		MCampaigns[] array = Campaigns();
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				campaignsRate.cost *= array[i].ExplainValueForCompositionCostDownEffectValue;
				if (isPowup)
				{
					campaignsRate.exp *= array[i].ExplainValueForCompositionExpUpEffectValue;
				}
			}
		}
		return campaignsRate;
	}

	private static GameObject CreateBadge(Transform parent, GameObject prefab)
	{
		GameObject gameObject = NGUITools.InstantiateWithoutUIPanel(prefab);
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		return gameObject;
	}

	public static void InitCampaigns(Transform[] campaignPos, GameObject prefab, bool isPowup)
	{
		if (campaignPos == null || campaignPos.Count() <= 0 || !prefab)
		{
			return;
		}
		int num = 0;
		CampaignsRate campaignsRate = GetCampaignsRate(isPowup);
		int num2 = 0;
		int num3 = 2;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int no = num2;
			num2++;
			if (campaignsRate.Now(no))
			{
				GameObject component = CreateBadge(campaignPos[RuntimeServices.NormalizeArrayIndex(campaignPos, checked(num++))], prefab);
				CampaignPanel campaignPanel = ExtensionsModule.SetComponent<CampaignPanel>(component);
				campaignPanel.Init(CampaignsRate.ConvertType(no), campaignsRate.GetText(no));
			}
		}
	}
}
