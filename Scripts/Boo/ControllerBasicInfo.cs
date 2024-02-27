using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ControllerBasicInfo
{
	[Serializable]
	public enum ButtonID
	{
		Up,
		Down,
		Left,
		Right,
		A,
		B,
		X,
		Y,
		L,
		R,
		Pause,
		Max
	}

	private bool[] currs;

	private bool[] prevs;

	private long curBit_;

	private long prevBit_;

	private long repeatBit_;

	private int repeatCount_;

	private Vector3 normalizedAnalogVector_;

	private bool hasAnalogVector_;

	[NonSerialized]
	private const int REPEAT_1ST_COUNT = 20;

	[NonSerialized]
	private const int REPEAT_CONT_COUNT = 4;

	[NonSerialized]
	private const float ANALOG_THRESOHLD = 0.1f;

	public bool isDirty => curBit_ != 0;

	public bool hasAnalogVector => hasAnalogVector_;

	public Vector3 normalizedAnalogVector => normalizedAnalogVector_;

	public bool[] Current => currs;

	public ControllerBasicInfo()
	{
		currs = new bool[11];
		prevs = new bool[11];
	}

	public void clear()
	{
		Array.Clear(currs, 0, currs.Length);
		Array.Clear(prevs, 0, prevs.Length);
		normalizedAnalogVector_ = Vector3.zero;
		hasAnalogVector_ = false;
	}

	public void update(float dt)
	{
		bool[] array = currs;
		currs = prevs;
		prevs = array;
		Array.Clear(currs, 0, currs.Length);
		normalizedAnalogVector_ = Vector3.zero;
		hasAnalogVector_ = false;
		setInputFromKeyboards(currs);
		long num = curBit_;
		curBit_ = 0L;
		int num2 = 0;
		int i = 0;
		bool[] array2 = currs;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i])
				{
					curBit_ |= 1 << num2;
				}
				num2++;
			}
			if (curBit_ != num)
			{
				long num3 = curBit_ & num;
				long num4 = num3 ^ -1L;
				repeatBit_ = curBit_ & num4;
				repeatCount_ = 20;
			}
			else if (repeatCount_ <= 0)
			{
				repeatBit_ = curBit_;
				repeatCount_ = 4;
			}
			else
			{
				repeatBit_ = 0L;
				repeatCount_--;
			}
			prevBit_ = num;
			Vector3 zero = Vector3.zero;
			zero.z = 0f - Input.GetAxis("Vertical");
			zero.x = 0f - Input.GetAxis("Horizontal");
			if (!(0.1f >= zero.magnitude))
			{
				normalizedAnalogVector_ = zero.normalized;
				hasAnalogVector_ = true;
			}
		}
	}

	public bool isRepeat(ButtonID id)
	{
		checked
		{
			long num = repeatBit_ & (long)(1 << unchecked((int)id));
			return num != 0;
		}
	}

	private static void setInputFromKeyboards(bool[] bs)
	{
		ref bool reference = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 0)];
		reference = Input.GetKey("up");
		ref bool reference2 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 1)];
		reference2 = Input.GetKey("down");
		ref bool reference3 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 2)];
		reference3 = Input.GetKey("left");
		ref bool reference4 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 3)];
		reference4 = Input.GetKey("right");
		ref bool reference5 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 4)];
		reference5 = Input.GetKeyDown("z");
		ref bool reference6 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 5)];
		reference6 = Input.GetKeyDown("x");
		ref bool reference7 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 6)];
		reference7 = Input.GetKeyDown("c");
		ref bool reference8 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 7)];
		reference8 = Input.GetKeyDown("v");
		ref bool reference9 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 8)];
		reference9 = Input.GetKey("b");
		ref bool reference10 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 9)];
		reference10 = Input.GetKeyDown("n");
		ref bool reference11 = ref bs[RuntimeServices.NormalizeArrayIndex(bs, 10)];
		reference11 = Input.GetKeyDown("p");
		DeviceController instance = DeviceController.Instance;
		if (instance.isDown(0))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 4)] = true;
		}
		if (instance.isDown(1))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 5)] = true;
		}
		if (instance.isDown(2))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 6)] = true;
		}
		if (instance.isDown(3))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 7)] = true;
		}
		if (instance.isOn(4))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 8)] = true;
		}
		if (instance.isDown(5))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 9)] = true;
		}
		if (instance.isOn(10))
		{
			bs[RuntimeServices.NormalizeArrayIndex(bs, 10)] = true;
		}
	}
}
