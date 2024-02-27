using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDAbnormalStateBase : MonoBehaviour
{
	public UISprite[] 状態異常アイコン;

	private EnumAbnormalStates[] lastCached;

	private List<UITweener[]> tweeners;

	public UISprite[] Icons => 状態異常アイコン;

	public BattleHUDAbnormalStateBase()
	{
		lastCached = new EnumAbnormalStates[0];
		tweeners = new List<UITweener[]>();
	}

	public void Start()
	{
		initTweeners();
		resetAllIcons();
	}

	private void initTweeners()
	{
		int length = Icons.Length;
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			UISprite[] icons = Icons;
			if (icons[RuntimeServices.NormalizeArrayIndex(icons, index)] != null)
			{
				UISprite[] icons2 = Icons;
				UITweener[] components = icons2[RuntimeServices.NormalizeArrayIndex(icons2, index)].GetComponents<UITweener>();
				tweeners.Add(components);
			}
			else
			{
				tweeners.Add(new UITweener[0]);
			}
		}
	}

	protected void setStateIcons(EnumAbnormalStates[] states)
	{
		if (tweeners.Count <= 0)
		{
			return;
		}
		if (states == null)
		{
			states = new EnumAbnormalStates[0];
		}
		int length = Icons.Length;
		int length2 = states.Length;
		if (!isChanged(states))
		{
			return;
		}
		lastCached = new EnumAbnormalStates[length2];
		int num = 0;
		int num2 = length2;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			EnumAbnormalStates[] array = lastCached;
			int num3 = RuntimeServices.NormalizeArrayIndex(array, index);
			EnumAbnormalStates[] array2 = states;
			array[num3] = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
		}
		int num4 = Mathf.Min(length2, length);
		int num5 = 0;
		int num6 = num4;
		if (num6 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num5 < num6)
		{
			int num7 = num5;
			num5++;
			EnumAbnormalStates[] array3 = states;
			MAbnormalStates mAbnormalStates = MAbnormalStates.Get((int)array3[RuntimeServices.NormalizeArrayIndex(array3, num7)]);
			if (mAbnormalStates != null)
			{
				enable(num7, mAbnormalStates.Icon);
			}
			else
			{
				disable(num7);
			}
		}
		int num8 = length2;
		int num9 = length;
		int num10 = 1;
		if (num9 < num8)
		{
			num10 = -1;
		}
		while (num8 != num9)
		{
			int idx = num8;
			num8 += num10;
			disable(idx);
		}
	}

	protected void resetAllIcons()
	{
		int i = 0;
		UISprite[] icons = Icons;
		for (int length = icons.Length; i < length; i = checked(i + 1))
		{
			icons[i].gameObject.SetActive(value: false);
		}
	}

	private bool isChanged(EnumAbnormalStates[] states)
	{
		int length = states.Length;
		int result;
		if (length != lastCached.Length)
		{
			result = 1;
		}
		else
		{
			int num = 0;
			int num2 = length;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < num2)
				{
					int index = num;
					num++;
					EnumAbnormalStates[] array = lastCached;
					if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != states[RuntimeServices.NormalizeArrayIndex(states, index)])
					{
						result = 1;
						break;
					}
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	private void disable(int idx)
	{
		UISprite[] icons = Icons;
		UISprite uISprite = icons[RuntimeServices.NormalizeArrayIndex(icons, idx)];
		if (!(uISprite == null))
		{
			uISprite.gameObject.SetActive(value: false);
		}
	}

	private void enable(int idx, string spriteName)
	{
		UISprite[] icons = Icons;
		UISprite uISprite = icons[RuntimeServices.NormalizeArrayIndex(icons, idx)];
		if (uISprite == null)
		{
			return;
		}
		uISprite.gameObject.SetActive(value: true);
		uISprite.gameObject.SetActive(value: false);
		uISprite.gameObject.SetActive(value: true);
		uISprite.enabled = true;
		uISprite.spriteName = spriteName;
		int i = 0;
		UITweener[] array = tweeners[idx];
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].Play(forward: true);
				array[i].Reset();
			}
		}
	}
}
