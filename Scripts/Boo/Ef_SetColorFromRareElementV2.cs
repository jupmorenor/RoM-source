using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromRareElementV2 : MonoBehaviour
{
	[Serializable]
	public class RareElementColor
	{
		public int rareNo;

		public int elementNo;

		public Side side;

		public Color color;

		public RareElementColor()
		{
			side = Side.None;
			color = Color.white;
		}
	}

	[Serializable]
	public class RareElementObj
	{
		public GameObject gameObj;

		public ComponentType componentType;

		public Color mulColor;

		public RareElementObj()
		{
			mulColor = new Color(1f, 1f, 1f, 0.5f);
		}
	}

	[Serializable]
	public enum Side
	{
		None,
		PlayerSide,
		EnemySide
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

	public RareElementColor[] rareElemColors;

	public RareElementObj[] setObjs;

	public bool setNoSetPM;

	public int testRare;

	public int testElem;

	public Side testSide;

	private Side emitterSide;

	private bool end;

	public Ef_SetColorFromRareElementV2()
	{
		rareElemColors = new RareElementColor[1];
		setObjs = new RareElementObj[1];
		setNoSetPM = true;
		testSide = Side.None;
		emitterSide = Side.None;
	}

	public void CheckComponentType()
	{
		int num = setObjs.Length;
		if (num == 0)
		{
			setObjs = new RareElementObj[1];
			setObjs[0].gameObj = gameObject;
			setObjs[0].mulColor = new Color(1f, 1f, 1f, 0.5f);
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
			RareElementObj[] array = setObjs;
			RareElementObj rareElementObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			GameObject gameObj = rareElementObj.gameObj;
			if (!(gameObj == null))
			{
				if (gameObj.GetComponent<Ef_ParticleEmit>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_ParticleEmit;
				}
				else if (gameObj.particleSystem != null)
				{
					rareElementObj.componentType = ComponentType.ParticleSystem;
				}
				else if (gameObj.renderer != null)
				{
					rareElementObj.componentType = ComponentType.Renderer;
				}
				else if (gameObj.GetComponent<Ef_SwordTrailV2>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_SwordTrail>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_RingMeshV2>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_RingMesh;
				}
				else if (gameObj.GetComponent<Ef_RingMesh>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_RingMesh;
				}
				else if (gameObj.GetComponent<Ef_DomeMeshV2>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_DomeMesh;
				}
				else if (gameObj.GetComponent<Ef_DomeMesh>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_DomeMesh;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimColor>() != null)
				{
					rareElementObj.componentType = ComponentType.Ef_QuickAnimColor;
				}
				else if (gameObj != gameObject)
				{
					rareElementObj.componentType = ComponentType.SendColor;
				}
				if (rareElementObj.mulColor == new Color(0f, 0f, 0f, 0f))
				{
					rareElementObj.mulColor = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}
	}

	public void Start()
	{
		Ef_Mesh_BillboardEdit component = gameObject.GetComponent<Ef_Mesh_BillboardEdit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		if ((testRare > 0 && testElem > 0) || testSide != 0)
		{
			emitterSide = testSide;
			SetColor(testRare, testElem);
			setNoSetPM = false;
		}
		if (!end)
		{
			if (setNoSetPM && rareElemColors.Length > 0)
			{
				emitterSide = rareElemColors[0].side;
				SetColor(0, 0);
				setNoSetPM = false;
			}
			end = true;
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			if (emtr.IsSidePlayer)
			{
				emitterSide = Side.PlayerSide;
			}
			else if (emtr.IsSideEnemy)
			{
				emitterSide = Side.EnemySide;
			}
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (mpets != null)
		{
			SetColor(mpets.Rare, mpets.MElementId);
			end = true;
		}
	}

	public void SetColor(int rare, int elem)
	{
		int length = setObjs.Length;
		int length2 = rareElemColors.Length;
		if (length == 0 || length2 == 0)
		{
			return;
		}
		Color color = rareElemColors[0].color;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length2).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				RareElementColor[] array = rareElemColors;
				int rareNo = array[RuntimeServices.NormalizeArrayIndex(array, num)].rareNo;
				RareElementColor[] array2 = rareElemColors;
				int elementNo = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].elementNo;
				RareElementColor[] array3 = rareElemColors;
				Side side = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].side;
				if (emitterSide == Side.None)
				{
				}
				if ((side == emitterSide || side == Side.None) && ((rareNo == rare && elementNo == elem) || (rareNo == 0 && elementNo == elem) || (rareNo == rare && elementNo == 0) || (rareNo <= 0 && elementNo <= 0)))
				{
					RareElementColor[] array4 = rareElemColors;
					color = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].color;
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				RareElementObj[] array5 = setObjs;
				if (array5[RuntimeServices.NormalizeArrayIndex(array5, num)] == null)
				{
					continue;
				}
				RareElementObj[] array6 = setObjs;
				GameObject gameObj = array6[RuntimeServices.NormalizeArrayIndex(array6, num)].gameObj;
				if (gameObj == null)
				{
					continue;
				}
				Color color2 = color;
				RareElementObj[] array7 = setObjs;
				Color color3 = color2 * array7[RuntimeServices.NormalizeArrayIndex(array7, num)].mulColor;
				RareElementObj[] array8 = setObjs;
				switch (array8[RuntimeServices.NormalizeArrayIndex(array8, num)].componentType)
				{
				case ComponentType.ParticleSystem:
				{
					ParticleSystem particleSystem = gameObj.particleSystem;
					if (particleSystem != null)
					{
						particleSystem.startColor = color3;
					}
					break;
				}
				case ComponentType.Ef_ParticleEmit:
				{
					Ef_ParticleEmit component4 = gameObj.GetComponent<Ef_ParticleEmit>();
					if (component4 != null)
					{
						component4.color = color3;
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
					Material[] array9 = materials;
					for (int length3 = array9.Length; i < length3; i = checked(i + 1))
					{
						if (array9[i] != null && array9[i].HasProperty("_Color"))
						{
							array9[i].SetColor("_Color", color3);
						}
					}
					gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
					break;
				}
				case ComponentType.Ef_SwordTrail:
				{
					Ef_SwordTrailV2 component5 = gameObj.GetComponent<Ef_SwordTrailV2>();
					if (component5 != null)
					{
						component5.color = color3;
						break;
					}
					Ef_SwordTrail component6 = gameObj.GetComponent<Ef_SwordTrail>();
					if (component6 != null)
					{
						component6.color = color3;
					}
					break;
				}
				case ComponentType.Ef_RingMesh:
				{
					Ef_RingMeshV2 component7 = gameObj.GetComponent<Ef_RingMeshV2>();
					if (component7 != null)
					{
						component7.color = color3;
						break;
					}
					Ef_RingMesh component8 = gameObj.GetComponent<Ef_RingMesh>();
					if (component8 != null)
					{
						component8.color = color3;
					}
					break;
				}
				case ComponentType.Ef_DomeMesh:
				{
					Ef_DomeMeshV2 component2 = gameObj.GetComponent<Ef_DomeMeshV2>();
					if (component2 != null)
					{
						component2.color = color3;
						break;
					}
					Ef_DomeMesh component3 = gameObj.GetComponent<Ef_DomeMesh>();
					if (component3 != null)
					{
						component3.color = color3;
					}
					break;
				}
				case ComponentType.Ef_QuickAnimColor:
				{
					Ef_QuickAnimColor component = gameObj.GetComponent<Ef_QuickAnimColor>();
					if (component != null)
					{
						component.color = color3;
					}
					break;
				}
				case ComponentType.SendColor:
					gameObj.SendMessage("setColor", color, SendMessageOptions.DontRequireReceiver);
					break;
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}
}
