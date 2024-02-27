using System;
using UnityEngine;

[Serializable]
public class TreasureInfo : MonoBehaviour
{
	public UISprite sprite;

	public GameObject plusMark;

	public void SetState(int rare)
	{
		bool flag = default(bool);
		string spriteName = "icon_treasure";
		if (5 <= rare)
		{
			flag = 6 == rare;
			spriteName = "icon_treasure_sr";
		}
		else if (3 <= rare)
		{
			flag = 4 == rare;
			spriteName = "icon_treasure_r";
		}
		else if (1 <= rare)
		{
			flag = 2 == rare;
			spriteName = "icon_treasure_n";
		}
		sprite.spriteName = spriteName;
		plusMark.SetActive(flag);
	}
}
