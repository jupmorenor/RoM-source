using System;
using UnityEngine;

[Serializable]
public class Ef_Coin_Scatter_Test : Ef_Base
{
	public int numberOfCoins;

	public bool scatted;

	public GameObject coinScatterObj;

	public Ef_Coin_Scatter_Test()
	{
		numberOfCoins = 6;
	}

	public void Update()
	{
		if (scatted)
		{
			ScatteredCoins(numberOfCoins);
			scatted = false;
		}
	}

	public void ScatteredCoins(int num)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(coinScatterObj, transform.position, Quaternion.identity);
		if ((bool)gameObject)
		{
			Ef_Coin_Scatter component = gameObject.GetComponent<Ef_Coin_Scatter>();
			component.money = checked(num * 2);
		}
	}
}
