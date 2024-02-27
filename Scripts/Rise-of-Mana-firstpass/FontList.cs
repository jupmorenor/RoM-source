using UnityEngine;

public class FontList : MonoBehaviour
{
	public Font[] fontList;

	private Font[] fontInstanceList;

	public bool dontDestroy;

	public Font GetFont(int index)
	{
		return fontInstanceList[index];
	}

	public Font GetFont(Font font)
	{
		for (int i = 0; i < fontList.Length; i++)
		{
			if (fontList[i] == font)
			{
				return fontInstanceList[i];
			}
		}
		return null;
	}

	public void Init()
	{
		DestroyFont();
		fontInstanceList = new Font[fontList.Length];
		for (int i = 0; i < fontList.Length; i++)
		{
			Font font = (Font)Object.Instantiate(fontList[i]);
			fontInstanceList[i] = font;
		}
	}

	public void DestroyFont()
	{
		fontInstanceList = new Font[fontList.Length];
		for (int i = 0; i < fontInstanceList.Length; i++)
		{
			if (fontInstanceList[i] != null)
			{
				Object.Destroy(fontInstanceList[i]);
				fontInstanceList[i] = null;
			}
		}
	}

	private void Awake()
	{
		if (dontDestroy)
		{
			Object.DontDestroyOnLoad(this);
		}
		Init();
	}
}
