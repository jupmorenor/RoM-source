using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_ActiveOn : MonoBehaviour
{
	[Serializable]
	public class SetPlayObj
	{
		public GameObject gameObj;

		public ComponentType componentType;
	}

	[Serializable]
	public enum ComponentType
	{
		ParticleSystem,
		Animation,
		Ef_QuickAnimTransCurve,
		Ef_QuickAnimTransform,
		Ef_QuickAnimColor,
		Ef_QuickAnimTexture,
		Ef_QuickAnimMatFloat,
		Ef_RingMesh,
		Ef_DomeMesh,
		Ef_SwordTrail,
		SendActive
	}

	public bool enable;

	public SetPlayObj[] setPlayObjs;

	public bool checkComponent;

	public Ef_ActiveOn()
	{
		enable = true;
	}

	public void ActiveOn()
	{
		gameObject.SetActive(value: true);
		gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
	}

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
		int num = setPlayObjs.Length;
		if (num == 0)
		{
			setPlayObjs = new SetPlayObj[1];
			setPlayObjs[0].gameObj = gameObject;
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
			SetPlayObj[] array = setPlayObjs;
			SetPlayObj setPlayObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			GameObject gameObj = setPlayObj.gameObj;
			if (!(gameObj == null))
			{
				if (gameObj.particleSystem != null)
				{
					setPlayObj.componentType = ComponentType.ParticleSystem;
				}
				else if (gameObj.animation != null)
				{
					setPlayObj.componentType = ComponentType.Animation;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimTransCurve>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_QuickAnimTransCurve;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimTransform>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_QuickAnimTransform;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimColor>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_QuickAnimColor;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimTexture>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_QuickAnimTexture;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimMatFloat>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_QuickAnimMatFloat;
				}
				else if (gameObj.GetComponent<Ef_RingMeshV2>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_RingMesh;
				}
				else if (gameObj.GetComponent<Ef_DomeMeshV2>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_DomeMesh;
				}
				else if (gameObj.GetComponent<Ef_SwordTrailV2>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_SwordTrail>() != null)
				{
					setPlayObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj != gameObject)
				{
					setPlayObj.componentType = ComponentType.SendActive;
				}
			}
		}
	}

	public void OnActive()
	{
		int length = setPlayObjs.Length;
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
			SetPlayObj[] array = setPlayObjs;
			GameObject gameObj = array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObj;
			if (gameObj == null)
			{
				continue;
			}
			SetPlayObj[] array2 = setPlayObjs;
			switch (array2[RuntimeServices.NormalizeArrayIndex(array2, index)].componentType)
			{
			case ComponentType.ParticleSystem:
			{
				ParticleSystem particleSystem = gameObj.particleSystem;
				if (particleSystem != null)
				{
					if (particleSystem.simulationSpace == ParticleSystemSimulationSpace.Local)
					{
						particleSystem.Clear();
					}
					particleSystem.Play();
				}
				break;
			}
			case ComponentType.Animation:
			{
				Animation animation = gameObj.animation;
				if (animation != null)
				{
					animation.Play();
				}
				break;
			}
			case ComponentType.Ef_QuickAnimTransCurve:
			{
				Ef_QuickAnimTransCurve component4 = gameObj.GetComponent<Ef_QuickAnimTransCurve>();
				if (component4 != null)
				{
					component4.Play();
				}
				break;
			}
			case ComponentType.Ef_QuickAnimTransform:
			{
				Ef_QuickAnimTransform component8 = gameObj.GetComponent<Ef_QuickAnimTransform>();
				if (component8 != null)
				{
					component8.Play();
				}
				break;
			}
			case ComponentType.Ef_QuickAnimColor:
			{
				Ef_QuickAnimColor component5 = gameObj.GetComponent<Ef_QuickAnimColor>();
				if (component5 != null)
				{
					component5.Play();
				}
				break;
			}
			case ComponentType.Ef_QuickAnimTexture:
			{
				Ef_QuickAnimTexture component3 = gameObj.GetComponent<Ef_QuickAnimTexture>();
				if (component3 != null)
				{
					component3.Play();
				}
				break;
			}
			case ComponentType.Ef_QuickAnimMatFloat:
			{
				Ef_QuickAnimMatFloat component9 = gameObj.GetComponent<Ef_QuickAnimMatFloat>();
				if (component9 != null)
				{
					component9.Play();
				}
				break;
			}
			case ComponentType.Ef_RingMesh:
			{
				Ef_RingMeshV2 component7 = gameObj.GetComponent<Ef_RingMeshV2>();
				if (component7 != null)
				{
					component7.Play();
				}
				break;
			}
			case ComponentType.Ef_DomeMesh:
			{
				Ef_DomeMeshV2 component6 = gameObj.GetComponent<Ef_DomeMeshV2>();
				if (component6 != null)
				{
					component6.Play();
				}
				break;
			}
			case ComponentType.Ef_SwordTrail:
			{
				Ef_SwordTrailV2 component = gameObj.GetComponent<Ef_SwordTrailV2>();
				if (component != null)
				{
					component.slash = true;
					break;
				}
				Ef_SwordTrail component2 = gameObj.GetComponent<Ef_SwordTrail>();
				if (component2 != null)
				{
					component2.slash = true;
				}
				break;
			}
			case ComponentType.SendActive:
				gameObj.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
	}
}
