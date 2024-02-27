using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetTextureFromRareElement : MonoBehaviour
{
	[Serializable]
	public class RareElementTex
	{
		public int rareNo;

		public int elementNo;

		public Side side;

		public Texture texture;

		public RareElementTex()
		{
			side = Side.None;
		}
	}

	[Serializable]
	public enum Side
	{
		None,
		PlayerSide,
		EnemySide
	}

	public RareElementTex[] rareElemTextures;

	public GameObject[] setObjs;

	public bool setNoSetPM;

	public int testRare;

	public int testElem;

	public Side testSide;

	private Side emitterSide;

	private bool end;

	public Ef_SetTextureFromRareElement()
	{
		rareElemTextures = new RareElementTex[1];
		setNoSetPM = true;
		testSide = Side.None;
		emitterSide = Side.None;
	}

	public void Start()
	{
		if ((testRare > 0 && testElem > 0) || testSide != 0)
		{
			emitterSide = testSide;
			SetTexture(testRare, testElem);
			setNoSetPM = false;
		}
		if (!end)
		{
			if (setNoSetPM && rareElemTextures.Length > 0)
			{
				emitterSide = rareElemTextures[0].side;
				SetTexture(0, 0);
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
			SetTexture(mpets.Rare, mpets.MElementId);
		}
	}

	public void SetTexture(int inRare, int inElem)
	{
		int length = setObjs.Length;
		int length2 = rareElemTextures.Length;
		if (length == 0 || length2 == 0)
		{
			return;
		}
		Texture texture = rareElemTextures[0].texture;
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
			RareElementTex[] array = rareElemTextures;
			int rareNo = array[RuntimeServices.NormalizeArrayIndex(array, index)].rareNo;
			RareElementTex[] array2 = rareElemTextures;
			int elementNo = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].elementNo;
			RareElementTex[] array3 = rareElemTextures;
			Side side = array3[RuntimeServices.NormalizeArrayIndex(array3, index)].side;
			if (emitterSide == Side.None)
			{
			}
			if ((side == emitterSide || side == Side.None) && ((rareNo == inRare && elementNo == inElem) || (rareNo <= 0 && elementNo == inElem) || (rareNo == inRare && elementNo <= 0) || (rareNo <= 0 && elementNo <= 0)))
			{
				RareElementTex[] array4 = rareElemTextures;
				texture = array4[RuntimeServices.NormalizeArrayIndex(array4, index)].texture;
				break;
			}
		}
		int num3 = 0;
		int num4 = length;
		if (num4 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < num4)
		{
			int index2 = num3;
			num3++;
			GameObject[] array5 = setObjs;
			GameObject gameObject = array5[RuntimeServices.NormalizeArrayIndex(array5, index2)];
			if (gameObject == null)
			{
				continue;
			}
			Renderer renderer = gameObject.renderer;
			if (renderer != null)
			{
				Material material2 = (renderer.material = renderer.material);
				if (material2 != null)
				{
					material2.HasProperty("_MainTex");
					material2.SetTexture("_MainTex", texture);
					gameObject.AddComponent<Ef_DestroyMaterialOnDestroy>();
				}
			}
		}
		end = true;
	}
}
