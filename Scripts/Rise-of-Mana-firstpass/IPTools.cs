using UnityEngine;

public static class IPTools
{
	public static int GetSelectedIndexAfterRemoveElement(int removedIndex, int selectedIndex, int nbOfElements)
	{
		int num = selectedIndex;
		if (removedIndex <= selectedIndex)
		{
			num = ((selectedIndex != 0) ? (selectedIndex - 1) : (nbOfElements - 1));
			if (num < 0)
			{
				num = 0;
			}
		}
		return num;
	}

	public static void NormalizeSprite(UISprite sprite, float normalizedMax)
	{
		sprite.MakePixelPerfect();
		float num = ((!(sprite.cachedTransform.localScale.x >= sprite.cachedTransform.localScale.y)) ? (normalizedMax / sprite.cachedTransform.localScale.y) : (normalizedMax / sprite.cachedTransform.localScale.x));
		sprite.cachedTransform.localScale = new Vector3(sprite.cachedTransform.localScale.x * num, sprite.cachedTransform.localScale.y * num, 1f);
	}
}
