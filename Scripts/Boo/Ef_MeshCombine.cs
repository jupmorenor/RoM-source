using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MeshCombine : Ef_Base
{
	public GameObject[] combineObjs;

	public GameObject meshObj;

	public Mesh mesh;

	public CombineInstance[] combs;

	public int leng;

	public float delay;

	private float fstDelay;

	private bool[] fstActives;

	private bool ready;

	private bool end;

	public Ef_MeshCombine()
	{
		delay = 1f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		end = false;
		delay = fstDelay;
		int num = 0;
		int length = combineObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = combineObjs;
			GameObject obj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			bool[] array2 = fstActives;
			obj.SetActive(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
		}
		if (mesh != null)
		{
			mesh.Clear();
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Update()
	{
		if (ready && !end)
		{
			delay -= deltaTime;
			if (!(delay > 0f))
			{
				Combine();
				end = true;
			}
		}
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		leng = 0;
		int num = 0;
		int length = combineObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			GameObject[] array = combineObjs;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == null)
			{
				continue;
			}
			GameObject[] array2 = combineObjs;
			MeshFilter component = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].GetComponent<MeshFilter>();
			checked
			{
				if (!(component == null) && !(component.mesh == null))
				{
					if (num2 != leng)
					{
						GameObject[] array3 = combineObjs;
						int num3 = RuntimeServices.NormalizeArrayIndex(array3, leng);
						GameObject[] array4 = combineObjs;
						array3[num3] = array4[RuntimeServices.NormalizeArrayIndex(array4, num2)];
						GameObject[] array5 = combineObjs;
						_ = array5[RuntimeServices.NormalizeArrayIndex(array5, num2)] == null;
					}
					leng++;
				}
			}
		}
		combs = new CombineInstance[leng];
		fstActives = new bool[leng];
		int num4 = 0;
		int num5 = leng;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int index = num4;
			num4++;
			GameObject[] array6 = combineObjs;
			Mesh mesh = array6[RuntimeServices.NormalizeArrayIndex(array6, index)].GetComponent<MeshFilter>().mesh;
			CombineInstance[] array7 = combs;
			array7[RuntimeServices.NormalizeArrayIndex(array7, index)].mesh = mesh;
			bool[] array8 = fstActives;
			ref bool reference = ref array8[RuntimeServices.NormalizeArrayIndex(array8, index)];
			GameObject[] array9 = combineObjs;
			reference = array9[RuntimeServices.NormalizeArrayIndex(array9, index)].activeSelf;
		}
		MeshFilter component2 = meshObj.GetComponent<MeshFilter>();
		if (!(component2 == null))
		{
			this.mesh = component2.sharedMesh;
			if (this.mesh == null)
			{
				this.mesh = new Mesh();
				this.mesh.name = "CombinedMesh";
				component2.sharedMesh = this.mesh;
			}
			fstDelay = delay;
			ready = true;
			end = false;
		}
	}

	public void Combine()
	{
		Vector3 position = meshObj.transform.position;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = combineObjs;
				Vector3 position2 = array[RuntimeServices.NormalizeArrayIndex(array, num)].transform.position;
				GameObject[] array2 = combineObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)].transform.position = position2 - position;
				CombineInstance[] array3 = combs;
				ref CombineInstance reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
				GameObject[] array4 = combineObjs;
				reference.transform = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].transform.localToWorldMatrix;
				GameObject[] array5 = combineObjs;
				array5[RuntimeServices.NormalizeArrayIndex(array5, num)].transform.position = position2;
				GameObject[] array6 = combineObjs;
				array6[RuntimeServices.NormalizeArrayIndex(array6, num)].SetActive(value: false);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		mesh.CombineMeshes(combs);
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
