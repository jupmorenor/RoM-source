using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ShadowSelector : ShadowCheck
{
	[NonSerialized]
	public static Hashtable useShadowShader = new Hash
	{
		{ "Mobile/Unlit (Supports Lightmap)", "Custom/Cutout/Unlit with Shadow Color" },
		{ "Unlit/Transparent", "Custom/Cutout/Unlit with Shadow Color Alpha" },
		{ "Unlit/Transparent Colored", "Custom/Cutout/Unlit with Shadow Color Alpha" },
		{ "Unlit/Transparent Cutout", "Custom/Cutout/Unlit with Shadow Color Cutout" }
	};

	[NonSerialized]
	public static Hashtable unuseShadowShader = new Hash
	{
		{
			"Merlin/FX/Anim 2texture",
			string.Empty
		},
		{
			"Merlin/FX/Anim 2texture For Coast",
			string.Empty
		}
	};

	public static GameObject[] AllShadowSetActive(Transform tr, bool active)
	{
		GameObject[] array = new GameObject[0];
		GameObject[] result;
		if (!tr)
		{
			result = array;
		}
		else
		{
			if (tr.name == "shadow")
			{
				tr.gameObject.SetActive(active);
				array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, new GameObject[1] { tr.gameObject });
			}
			IEnumerator enumerator = tr.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform tr2 = (Transform)obj;
				array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, AllShadowSetActive(tr2, active));
			}
			result = array;
		}
		return result;
	}

	public static void Setup(GameObject obj)
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo || !obj)
		{
			return;
		}
		GameObject[] array = AllShadowSetActive(obj.transform, !ShadowCheck.RealShadowFlag);
		bool flag = array.Length > 0;
		bool flag2 = false;
		if (!flag)
		{
			return;
		}
		checked
		{
			if (ShadowCheck.RealShadowFlag && flag)
			{
				int i = 0;
				GameObject[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					Renderer component = array2[i].GetComponent<Renderer>();
					if ((bool)component)
					{
						flag2 = true;
						break;
					}
				}
			}
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			Renderer shadowObjectRenderer = null;
			IEnumerator enumerator = componentsInChildren.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				if (!(obj2 is Renderer))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Renderer));
				}
				Renderer component = (Renderer)obj2;
				if (component.name == "shadow")
				{
					shadowObjectRenderer = component;
					break;
				}
			}
			IEnumerator enumerator2 = componentsInChildren.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj3 = enumerator2.Current;
				if (!(obj3 is Renderer))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Renderer));
				}
				Renderer component = (Renderer)obj3;
				if (!component || component.name == "shadow")
				{
					continue;
				}
				Material[] materials = component.materials;
				if (materials == null)
				{
					continue;
				}
				ShadowReceiver shadowReceiver = ExtensionsModule.SetComponent<ShadowReceiver>(component.gameObject);
				shadowReceiver.ShadowCastRenderer = component;
				shadowReceiver.ShadowObjectRenderer = shadowObjectRenderer;
				int j = 0;
				Material[] array3 = materials;
				for (int length2 = array3.Length; j < length2; j++)
				{
					if (!array3[j] || unuseShadowShader.ContainsKey(array3[j].shader.name) || string.IsNullOrEmpty(array3[j].shader.name))
					{
						continue;
					}
					string text = array3[j].shader.name;
					if (!ShadowCheck.ShadowShaderFlag)
					{
						if (useShadowShader.ContainsValue(text) && !ShadowCheck.ShadowShaderFlag && (bool)shadowReceiver)
						{
							shadowReceiver.SetOriginalShader(array3[j]);
						}
						continue;
					}
					if (!useShadowShader.ContainsValue(text))
					{
						string text2 = string.Empty;
						if (useShadowShader.ContainsKey(text))
						{
							object obj4 = useShadowShader[text];
							if (!(obj4 is string))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(string));
							}
							text2 = (string)obj4;
						}
						if (string.IsNullOrEmpty(text2))
						{
							continue;
						}
						if ((bool)shadowReceiver)
						{
							shadowReceiver.SetShadowShader(array3[j], text2);
						}
					}
					if (!flag2)
					{
						array3[j].SetFloat("_EnableShadow", 0f);
					}
					else
					{
						array3[j].SetFloat("_EnableShadow", 1f);
					}
					array3[j].SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
				}
			}
		}
	}

	public static void SetupAll(bool shadownShaderFlag, bool realShadowFlag)
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			return;
		}
		ShadowCheck.ShadowShaderFlag = shadownShaderFlag;
		ShadowCheck.RealShadowFlag = realShadowFlag;
		if ((GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) is GameObject[] array)
		{
			int i = 0;
			GameObject[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				Setup(array2[i]);
			}
		}
	}

	public void Start()
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public void OnEnable()
	{
		Setup(gameObject);
	}
}
