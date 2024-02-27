using UnityEngine;

public static class Constant
{
	public const float animTimeScale = 1f;

	public const int deckMax = 7;

	public const string SyntheticMaterialObjectName = "SelectSyntheticMaterial";

	public const string SellMonsterObjectName = "SellMonster";

	public static Rect CreateRect(int vX, int vY, int vW, int vH)
	{
		float left = (float)Screen.width * ((float)vX / 960f);
		float top = (float)Screen.height * ((float)vY / 640f);
		float width = (float)Screen.width * ((float)vW / 960f);
		float height = (float)Screen.height * ((float)vH / 640f);
		return new Rect(left, top, width, height);
	}
}
