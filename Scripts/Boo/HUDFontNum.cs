using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class HUDFontNum : MonoBehaviour
{
	[Serializable]
	public enum Alignment
	{
		Left,
		Center,
		Right
	}

	public Alignment alignment;

	public UISprite[] sceneSetSprite;

	private BetterList<UISprite> sprites;

	public UISprite spritePrefab;

	public Color _color;

	public string _text;

	private Transform mTrans;

	public Color color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			SetColor();
		}
	}

	public string text
	{
		get
		{
			return _text;
		}
		set
		{
			if (!(_text == value))
			{
				string[] array = new string[value.Length];
				int num = 0;
				int length = array.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int index = num;
					num++;
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = value[index].ToString();
				}
				Show(array);
				_text = value;
			}
		}
	}

	public HUDFontNum()
	{
		sprites = new BetterList<UISprite>();
		_color = Color.white;
	}

	public void Awake()
	{
		mTrans = transform;
	}

	public void Start()
	{
		int num = 0;
		int length = sceneSetSprite.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			UISprite[] array = sceneSetSprite;
			array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObject.SetActive(value: false);
			BetterList<UISprite> betterList = sprites;
			UISprite[] array2 = sceneSetSprite;
			betterList.Add(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
		}
		string[] array3 = new string[_text.Length];
		int num2 = 0;
		int length2 = array3.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length2)
		{
			int index2 = num2;
			num2++;
			array3[RuntimeServices.NormalizeArrayIndex(array3, index2)] = _text[index2].ToString();
		}
		Show(array3);
	}

	public void Show(string[] spriteNames)
	{
		int i = 0;
		int length = spriteNames.Length;
		checked
		{
			if (length > 0)
			{
				IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						i = enumerator.Current;
						if (i >= sprites.size)
						{
							sprites.Add((UISprite)NGUITools.AddChild(gameObject, spritePrefab.gameObject).GetComponent(typeof(UISprite)));
						}
						sprites[i].gameObject.SetActive(value: true);
						sprites[i].spriteName = spriteNames[RuntimeServices.NormalizeArrayIndex(spriteNames, i)];
						sprites[i].transform.localPosition = GetPos(i, length - 1);
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				i++;
			}
			for (; i < sprites.size; i++)
			{
				sprites[i].gameObject.SetActive(value: false);
			}
			SetColor();
		}
	}

	public Vector3 GetPos(int index, int maxNum)
	{
		float x = 0f;
		if (alignment == Alignment.Left)
		{
			x = (float)checked(-(maxNum - index)) - 0.5f;
		}
		else if (alignment == Alignment.Center)
		{
			x = (float)index - (float)maxNum / 2f;
		}
		else if (alignment == Alignment.Right)
		{
			x = (float)index + 0.5f;
		}
		return new Vector3(x, 0f, 0f);
	}

	public void SetColor()
	{
		int num = 0;
		int size = sprites.size;
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < size)
		{
			int i = num;
			num++;
			sprites[i].color = _color;
		}
	}
}
