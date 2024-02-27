using System;
using UnityEngine;

[Serializable]
public class CoinLabel : MonoBehaviour
{
	private UILabelBase label;

	private int lastCoin;

	public CoinLabel()
	{
		lastCoin = -1;
	}

	public void Start()
	{
		label = gameObject.GetComponent<UILabelBase>();
	}

	public void Update()
	{
		if (!(label == null))
		{
			int num = UserData.Current.Coin;
			if (num < 0)
			{
				num = 0;
			}
			if (lastCoin != num)
			{
				lastCoin = num;
				label.text = num.ToString("#,#,#,0");
			}
		}
	}
}
