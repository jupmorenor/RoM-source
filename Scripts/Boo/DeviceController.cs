using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class DeviceController : MonoBehaviour
{
	[NonSerialized]
	private static DeviceController _instance;

	private string[] joyNames;

	protected bool lastPlugged;

	private int on;

	private int up;

	private int down;

	private float axisPositiveMargin;

	private float axisNegativeMargin;

	private int axis_plus;

	private int axis_minus;

	public static DeviceController Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("__SSAL_DeviceController__");
				if (!(gameObject != null))
				{
					throw new AssertionFailedException("go != null");
				}
				_instance = ExtensionsModule.SetComponent<DeviceController>(gameObject);
				if (!(_instance != null))
				{
					throw new AssertionFailedException("_instance != null");
				}
			}
			return _instance;
		}
	}

	public bool IsPlugged => joyNames.Length > 0;

	public string[] JoyNames => joyNames;

	public int On => on;

	public int Up => up;

	public int Down => down;

	public int AxisPlus => axis_plus;

	public int AxisMinus => axis_minus;

	public DeviceController()
	{
		joyNames = new string[0];
		axisPositiveMargin = 0.3f;
		axisNegativeMargin = -0.3f;
	}

	public bool isOn(int n)
	{
		return (on & (1 << n)) != 0;
	}

	public bool isUp(int n)
	{
		return (up & (1 << n)) != 0;
	}

	public bool isDown(int n)
	{
		return (down & (1 << n)) != 0;
	}

	public bool isPlus(int n)
	{
		return (axis_plus & (1 << n)) != 0;
	}

	public bool isMinus(int n)
	{
		return (axis_minus & (1 << n)) != 0;
	}

	public void OnDestroy()
	{
		Screen.sleepTimeout = -2;
	}

	public void Update()
	{
		on = 0;
		up = 0;
		down = 0;
		axis_plus = 0;
		axis_minus = 0;
		lastPlugged = IsPlugged;
		joyNames = Input.GetJoystickNames();
		if (lastPlugged != IsPlugged)
		{
			if (IsPlugged)
			{
				Screen.sleepTimeout = -1;
			}
			else
			{
				Screen.sleepTimeout = -2;
			}
		}
		if (IsPlugged)
		{
			getButton();
			getAxis();
		}
	}

	private void getButton()
	{
		try
		{
			KeyCode[] array = new KeyCode[20]
			{
				KeyCode.JoystickButton0,
				KeyCode.JoystickButton1,
				KeyCode.JoystickButton2,
				KeyCode.JoystickButton3,
				KeyCode.JoystickButton4,
				KeyCode.JoystickButton5,
				KeyCode.JoystickButton6,
				KeyCode.JoystickButton7,
				KeyCode.JoystickButton8,
				KeyCode.JoystickButton9,
				KeyCode.JoystickButton10,
				KeyCode.JoystickButton11,
				KeyCode.JoystickButton12,
				KeyCode.JoystickButton13,
				KeyCode.JoystickButton14,
				KeyCode.JoystickButton15,
				KeyCode.JoystickButton16,
				KeyCode.JoystickButton17,
				KeyCode.JoystickButton18,
				KeyCode.JoystickButton19
			};
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				if (Input.GetKey(array[RuntimeServices.NormalizeArrayIndex(array, num2)]))
				{
					on |= 1 << num2;
				}
				if (Input.GetKeyUp(array[RuntimeServices.NormalizeArrayIndex(array, num2)]))
				{
					up |= 1 << num2;
				}
				if (Input.GetKeyDown(array[RuntimeServices.NormalizeArrayIndex(array, num2)]))
				{
					down |= 1 << num2;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void getAxis()
	{
		string[] array = new string[8] { "X axis", "Y axis", "3rd axis", "4th axis", "5th axis", "6th axis", "7th axis", "8th axis" };
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			try
			{
				if (!(Input.GetAxisRaw(array[RuntimeServices.NormalizeArrayIndex(array, num2)]) <= axisPositiveMargin))
				{
					axis_plus |= 1 << num2;
				}
				if (!(Input.GetAxisRaw(array[RuntimeServices.NormalizeArrayIndex(array, num2)]) >= axisNegativeMargin))
				{
					axis_minus |= 1 << num2;
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
