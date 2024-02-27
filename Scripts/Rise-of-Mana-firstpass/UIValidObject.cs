using UnityEngine;

public class UIValidObject : MonoBehaviour
{
	public Color validColor = Color.white;

	public Color invalidColor = Color.gray;

	public Color GetValidColor(bool valid)
	{
		if (valid)
		{
			return validColor;
		}
		return invalidColor;
	}
}
