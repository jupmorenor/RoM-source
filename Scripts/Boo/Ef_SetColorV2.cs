using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_SetColorV2 : MonoBehaviour
{
	[Serializable]
	public class SetColorObj
	{
		public GameObject gameObj;

		public ComponentType componentType;

		public Color mulColor;

		public SetColorObj()
		{
			mulColor = new Color(1f, 1f, 1f, 0.5f);
		}
	}

	[Serializable]
	public enum ComponentType
	{
		ParticleSystem,
		Renderer,
		Ef_SwordTrail,
		Ef_RingMesh,
		Ef_DomeMesh,
		Ef_QuickAnimColor,
		Ef_ParticleEmit,
		SendColor
	}

	public SetColorObj[] setColorObjs;

	public bool checkComponent;

	public void Update()
	{
		if (checkComponent)
		{
			CheckComponentType();
			checkComponent = false;
		}
	}

	public void CheckComponentType()
	{
		int num = setColorObjs.Length;
		if (num == 0)
		{
			setColorObjs = new SetColorObj[1];
			setColorObjs[0].gameObj = gameObject;
			setColorObjs[0].mulColor = Color.white;
			num = 1;
		}
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			SetColorObj[] array = setColorObjs;
			SetColorObj setColorObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			GameObject gameObj = setColorObj.gameObj;
			if (!(gameObj == null))
			{
				if (gameObj.GetComponent<Ef_ParticleEmit>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_ParticleEmit;
				}
				else if (gameObj.particleSystem != null)
				{
					setColorObj.componentType = ComponentType.ParticleSystem;
				}
				else if (gameObj.renderer != null)
				{
					setColorObj.componentType = ComponentType.Renderer;
				}
				else if (gameObj.GetComponent<Ef_SwordTrailV2>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_SwordTrail>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_RingMeshV2>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_RingMesh;
				}
				else if (gameObj.GetComponent<Ef_RingMesh>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_RingMesh;
				}
				else if (gameObj.GetComponent<Ef_DomeMeshV2>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_DomeMesh;
				}
				else if (gameObj.GetComponent<Ef_DomeMesh>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_DomeMesh;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimColor>() != null)
				{
					setColorObj.componentType = ComponentType.Ef_QuickAnimColor;
				}
				else if (gameObj != gameObject)
				{
					setColorObj.componentType = ComponentType.SendColor;
				}
				if (setColorObj.mulColor == new Color(0f, 0f, 0f, 0f))
				{
					setColorObj.mulColor = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}
	}

	public void setColor(Color inColor)
	{
		if (inColor[0] > 1f || inColor[1] > 1f || inColor[2] > 1f || !(inColor[3] <= 1f))
		{
			inColor /= 255f;
		}
		int length = setColorObjs.Length;
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
			SetColorObj[] array = setColorObjs;
			GameObject gameObj = array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObj;
			if (gameObj == null)
			{
				continue;
			}
			Color color = inColor;
			SetColorObj[] array2 = setColorObjs;
			Color color2 = color * array2[RuntimeServices.NormalizeArrayIndex(array2, index)].mulColor;
			SetColorObj[] array3 = setColorObjs;
			switch (array3[RuntimeServices.NormalizeArrayIndex(array3, index)].componentType)
			{
			case ComponentType.ParticleSystem:
			{
				ParticleSystem particleSystem = gameObj.particleSystem;
				if (particleSystem != null)
				{
					particleSystem.startColor = color2;
				}
				break;
			}
			case ComponentType.Ef_ParticleEmit:
			{
				Ef_ParticleEmit component6 = gameObj.GetComponent<Ef_ParticleEmit>();
				if (component6 != null)
				{
					component6.color = color2;
				}
				break;
			}
			case ComponentType.Renderer:
			{
				Renderer renderer = gameObj.renderer;
				if (!(renderer != null))
				{
					break;
				}
				Material[] materials = renderer.materials;
				int i = 0;
				Material[] array4 = materials;
				for (int length2 = array4.Length; i < length2; i = checked(i + 1))
				{
					if (array4[i] != null && array4[i].HasProperty("_Color"))
					{
						array4[i].SetColor("_Color", color2);
					}
				}
				gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
				break;
			}
			case ComponentType.Ef_SwordTrail:
			{
				Ef_SwordTrailV2 component7 = gameObj.GetComponent<Ef_SwordTrailV2>();
				if (component7 != null)
				{
					component7.color = color2;
					break;
				}
				Ef_SwordTrail component8 = gameObj.GetComponent<Ef_SwordTrail>();
				if (component8 != null)
				{
					component8.color = color2;
				}
				break;
			}
			case ComponentType.Ef_RingMesh:
			{
				Ef_RingMeshV2 component = gameObj.GetComponent<Ef_RingMeshV2>();
				if (component != null)
				{
					component.color = color2;
					break;
				}
				Ef_RingMesh component2 = gameObj.GetComponent<Ef_RingMesh>();
				if (component2 != null)
				{
					component2.color = color2;
				}
				break;
			}
			case ComponentType.Ef_DomeMesh:
			{
				Ef_DomeMeshV2 component4 = gameObj.GetComponent<Ef_DomeMeshV2>();
				if (component4 != null)
				{
					component4.color = color2;
					break;
				}
				Ef_DomeMesh component5 = gameObj.GetComponent<Ef_DomeMesh>();
				if (component5 != null)
				{
					component5.color = color2;
				}
				break;
			}
			case ComponentType.Ef_QuickAnimColor:
			{
				Ef_QuickAnimColor component3 = gameObj.GetComponent<Ef_QuickAnimColor>();
				if (component3 != null)
				{
					component3.color = color2;
				}
				break;
			}
			case ComponentType.SendColor:
				if (gameObj != gameObject)
				{
					gameObj.SendMessage("setColor", inColor, SendMessageOptions.DontRequireReceiver);
				}
				break;
			}
		}
	}
}
