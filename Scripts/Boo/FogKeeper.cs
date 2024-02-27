using System;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class FogKeeper : MonoBehaviour
{
	[Serializable]
	public class StackData
	{
		public FogKeeper originator;

		public bool isRoot;

		public bool fog;

		public Color fogColor;

		public FogMode fogMode;

		public float fogDensity;

		public float fogStartDistance;

		public float fogEndDistance;

		public float flareFadeSpeed;

		public float flareStrength;

		public StackData()
		{
			flareFadeSpeed = 3f;
			flareStrength = 1f;
			fog = false;
			fogColor = new Color(0.5f, 0.5f, 0.5f, 1f);
			fogDensity = 0.01f;
			fogEndDistance = 300f;
			fogMode = FogMode.ExponentialSquared;
			fogStartDistance = 0f;
		}

		public void saveCurrent()
		{
			flareFadeSpeed = RenderSettings.flareFadeSpeed;
			flareStrength = RenderSettings.flareStrength;
			fog = RenderSettings.fog;
			fogColor = RenderSettings.fogColor;
			fogDensity = RenderSettings.fogDensity;
			fogEndDistance = RenderSettings.fogEndDistance;
			fogMode = RenderSettings.fogMode;
			fogStartDistance = RenderSettings.fogStartDistance;
		}

		public void setRenderSettings()
		{
			RenderSettings.flareFadeSpeed = flareFadeSpeed;
			RenderSettings.flareStrength = flareStrength;
			RenderSettings.fog = fog;
			RenderSettings.fogColor = fogColor;
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.fogEndDistance = fogEndDistance;
			RenderSettings.fogMode = fogMode;
			RenderSettings.fogStartDistance = fogStartDistance;
		}
	}

	public StackData data;

	[NonSerialized]
	private static List<StackData> stack = new List<StackData>();

	public void OnEnable()
	{
		push();
	}

	public void OnDisable()
	{
		pop();
	}

	public void saveCurrent()
	{
		data = new StackData();
		data.saveCurrent();
	}

	private void push()
	{
		if (data != null)
		{
			data.originator = this;
			if (stack.Count <= 0)
			{
				StackData stackData = new StackData();
				stackData.isRoot = true;
				stack.Add(stackData);
			}
			stack.Add(data);
			data.setRenderSettings();
		}
	}

	private void pop()
	{
		int num = 0;
		int count = stack.Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int index = num;
			num++;
			StackData stackData = stack[index];
			if (stackData.originator == this)
			{
				stack.RemoveAt(index);
				if (stack.Count > 0)
				{
					StackData stackData2 = stack[checked(stack.Count - 1)];
					stackData2.setRenderSettings();
				}
				else
				{
					ClearRenderSetting();
				}
				break;
			}
		}
		stack.RemoveAll(_0024adaptor_0024__FogKeeper_0024callable193_002486_26___0024Predicate_00243.Adapt(delegate(StackData d)
		{
			bool num2 = d.originator == null;
			if (num2)
			{
				num2 = !d.isRoot;
			}
			return num2;
		}));
	}

	private static void ClearRenderSetting()
	{
		RenderSettings.fog = false;
		RenderSettings.fogColor = new Color(0.5f, 0.5f, 0.5f, 1f);
		RenderSettings.fogDensity = 0.01f;
		RenderSettings.fogEndDistance = 300f;
		RenderSettings.fogMode = FogMode.ExponentialSquared;
		RenderSettings.fogStartDistance = 0f;
		RenderSettings.flareFadeSpeed = 3f;
		RenderSettings.flareStrength = 1f;
	}

	internal bool _0024pop_0024closure_00244032(StackData d)
	{
		bool num = d.originator == null;
		if (num)
		{
			num = !d.isRoot;
		}
		return num;
	}
}
