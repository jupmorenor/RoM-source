using UnityEngine;

public class ShadowCheck : MonoBehaviour
{
	protected static bool shadowShaderFlag;

	protected static bool realShadowFlag;

	protected static bool enableRealShadowFlag = true;

	private static string gpuName;

	private static bool init;

	public static bool InitFlag => init;

	public static bool ShadowShaderFlag
	{
		get
		{
			return shadowShaderFlag;
		}
		set
		{
			shadowShaderFlag = value;
		}
	}

	public static bool RealShadowFlag
	{
		get
		{
			if (!enableRealShadowFlag)
			{
				return false;
			}
			return realShadowFlag;
		}
		set
		{
			if (!enableRealShadowFlag)
			{
				realShadowFlag = false;
			}
			else
			{
				realShadowFlag = value;
			}
		}
	}

	public static bool EnableRealShadowFlag
	{
		get
		{
			return enableRealShadowFlag;
		}
		set
		{
			enableRealShadowFlag = value;
		}
	}

	public static bool DefaultFlag
	{
		get
		{
			if (!init)
			{
				return false;
			}
			if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
			{
				enableRealShadowFlag = false;
				return false;
			}
			bool flag = true;
			if (gpuName.ToLower().IndexOf("tegra") >= 0)
			{
				flag = false;
				enableRealShadowFlag = false;
			}
			else
			{
				flag = false;
			}
			return flag;
		}
	}

	public static void Init()
	{
		init = true;
		gpuName = SystemInfo.graphicsDeviceName;
	}
}
