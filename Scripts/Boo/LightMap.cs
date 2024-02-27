using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class LightMap : MonoBehaviour
{
	[Serializable]
	public class TexData
	{
		public Texture2D far;

		public Texture2D near;

		private bool _0024initialized__LightMap_TexData_0024;

		public TexData()
		{
			if (!_0024initialized__LightMap_TexData_0024)
			{
				_0024initialized__LightMap_TexData_0024 = true;
			}
		}

		public TexData(Texture2D _far, Texture2D _near)
		{
			if (!_0024initialized__LightMap_TexData_0024)
			{
				_0024initialized__LightMap_TexData_0024 = true;
			}
			far = _far;
			near = _near;
		}
	}

	[Serializable]
	public class StackData
	{
		public LightmapData[] lightmaps;

		public MonoBehaviour originator;

		public StackData(MonoBehaviour _orig, LightmapData[] _maps)
		{
			originator = _orig;
			lightmaps = _maps;
		}

		public void setLightMap()
		{
			if (!(lightmaps == null))
			{
				LightmapSettings.lightmaps = (LightmapData[])Builtins.array(typeof(LightmapData), lightmaps);
			}
		}
	}

	protected SceneID lastSceneId;

	public TexData[] ライトマップデータ;

	[NonSerialized]
	private static List<StackData> stack = new List<StackData>();

	public TexData[] mapData => ライトマップデータ;

	public LightMap()
	{
		lastSceneId = (SceneID)(-1);
	}

	public void addLightMapData(Texture2D far, Texture2D near)
	{
		TexData[] array = mapData;
		int length = array.Length;
		TexData[] array2 = new TexData[checked(length + 1)];
		Array.Copy(array, array2, length);
		TexData texData = new TexData();
		texData.far = far;
		texData.near = near;
		array2[RuntimeServices.NormalizeArrayIndex(array2, length)] = texData;
		ライトマップデータ = array2;
	}

	public void setLightMapData(LightmapData[] lmdata)
	{
		int length = lmdata.Length;
		TexData[] array = new TexData[length];
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
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = new TexData(lmdata[RuntimeServices.NormalizeArrayIndex(lmdata, index)].lightmapFar, lmdata[RuntimeServices.NormalizeArrayIndex(lmdata, index)].lightmapNear);
		}
		ライトマップデータ = array;
	}

	public void OnEnable()
	{
		int length = mapData.Length;
		LightmapData[] array = new LightmapData[length];
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
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = new LightmapData();
			LightmapData obj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			TexData[] array2 = mapData;
			obj.lightmapFar = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].far;
			LightmapData obj2 = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			TexData[] array3 = mapData;
			obj2.lightmapNear = array3[RuntimeServices.NormalizeArrayIndex(array3, index)].near;
		}
		push(this, array);
	}

	public void OnDisable()
	{
		pop(this);
	}

	public void Update()
	{
		if (lastSceneId != SceneChanger.CurrentScene)
		{
			lastSceneId = SceneChanger.CurrentScene;
			OnDisable();
			OnEnable();
		}
	}

	private static void push(LightMap orig, LightmapData[] data)
	{
		if (!(orig == null))
		{
			StackData stackData = new StackData(orig, data);
			stackData.setLightMap();
			stack.Add(stackData);
		}
	}

	private void pop(MonoBehaviour orig)
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
			if (stackData.originator == orig)
			{
				stack.RemoveAt(index);
				if (stack.Count > 0)
				{
					StackData stackData2 = stack[checked(stack.Count - 1)];
					stackData2.setLightMap();
				}
				break;
			}
		}
	}
}
