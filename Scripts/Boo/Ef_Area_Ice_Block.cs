using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Area_Ice_Block : Ef_Base
{
	public GameObject[] blockObjs;

	public float life;

	public Vector2 tex2Vec;

	public GameObject smokeObj;

	public Transform b0Obj;

	public Transform parentObj;

	private float timer;

	private int leng;

	private int pt;

	private float nextTime;

	private Material[] mats;

	private Vector2 texPos;

	private Transform posObj;

	private bool parFlg;

	public Ef_Area_Ice_Block()
	{
		life = 5.5f;
		tex2Vec = Vector2.zero;
		mats = new Material[0];
		texPos = Vector2.zero;
	}

	public void Start()
	{
		if (!parentObj)
		{
			parentObj = transform.parent;
		}
		if ((bool)parentObj)
		{
			parFlg = true;
		}
		leng = blockObjs.Length;
		if (leng == 0)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!renderer || !blockObjs[0].renderer)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		mats = gameObject.renderer.materials;
		if (mats.Length == 0)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		posObj = transform.Find("Pos");
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = blockObjs;
				if (!array[RuntimeServices.NormalizeArrayIndex(array, num)].renderer)
				{
					continue;
				}
				GameObject[] array2 = blockObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)].renderer.enabled = false;
				GameObject[] array3 = blockObjs;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num)].renderer.materials = mats;
				GameObject[] array4 = blockObjs;
				MeshFilter component = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].GetComponent<MeshFilter>();
				if (!component)
				{
					continue;
				}
				Mesh mesh = component.mesh;
				if (!mesh)
				{
					continue;
				}
				Vector2[] uv = mesh.uv;
				GameObject[] array5 = blockObjs;
				Vector3 localPosition = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].transform.localPosition;
				IEnumerator<int> enumerator2 = Builtins.range(uv.Length).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						ref Vector2 reference = ref uv[RuntimeServices.NormalizeArrayIndex(uv, num2)];
						reference = uv[RuntimeServices.NormalizeArrayIndex(uv, num2)] + new Vector2(Mathf.Floor(localPosition.x), Mathf.Floor(localPosition.z));
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				mesh.uv = uv;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Update()
	{
		texPos += tex2Vec * deltaTime;
		mats[1].SetTextureOffset("_MainTex", texPos);
		checked
		{
			if (!(nextTime <= -1f))
			{
				timer += deltaTime;
				if (!(timer < nextTime))
				{
					int num = default(int);
					IEnumerator<int> enumerator = Builtins.range(unchecked(pt / 10) + 1).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							num = enumerator.Current;
							GameObject[] array = blockObjs;
							if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, pt)].renderer)
							{
								GameObject[] array2 = blockObjs;
								array2[RuntimeServices.NormalizeArrayIndex(array2, pt)].renderer.enabled = true;
							}
							pt++;
							if (pt >= leng)
							{
								nextTime = -1f;
								Combine();
								break;
							}
						}
					}
					finally
					{
						enumerator.Dispose();
					}
					if (!(nextTime <= -1f))
					{
						nextTime += 0.02f;
					}
				}
			}
			if (!(life < 1f))
			{
				if (parFlg && !parentObj)
				{
					life = 1f;
				}
				life -= deltaTime;
				if (!(life >= 1f) && (bool)b0Obj && (bool)smokeObj)
				{
					UnityEngine.Object.Instantiate(smokeObj, b0Obj.position, b0Obj.rotation);
				}
			}
			else
			{
				life -= deltaTime;
				float a = life;
				Color color = mats[0].color;
				float num2 = (color.a = a);
				Color color3 = (mats[0].color = color);
				float a2 = life;
				Color color4 = mats[1].color;
				float num3 = (color4.a = a2);
				Color color6 = (mats[1].color = color4);
			}
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void Combine()
	{
		posObj.position = Vector3.zero;
		posObj.rotation = Quaternion.identity;
		CombineInstance[] array = new CombineInstance[leng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array2 = blockObjs;
				MeshFilter component = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].GetComponent<MeshFilter>();
				if (!(component == null))
				{
					Mesh mesh = component.mesh;
					if (!(mesh == null))
					{
						array[RuntimeServices.NormalizeArrayIndex(array, num)].mesh = mesh;
						UnityEngine.Object.Destroy(mesh);
						ref CombineInstance reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num)];
						GameObject[] array3 = blockObjs;
						reference.transform = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].transform.localToWorldMatrix;
						GameObject[] array4 = blockObjs;
						array4[RuntimeServices.NormalizeArrayIndex(array4, num)].SetActive(value: false);
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Mesh mesh2 = transform.GetComponent<MeshFilter>().mesh;
		if (mesh2 == null)
		{
			mesh2 = new Mesh();
		}
		mesh2.CombineMeshes(array);
		posObj.localPosition = Vector3.zero;
		posObj.localRotation = Quaternion.identity;
	}

	public void OnDestroy()
	{
		Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
		if ((bool)mesh)
		{
			UnityEngine.Object.Destroy(mesh);
		}
		int num = 0;
		int length = mats.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Material[] array = mats;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != null)
			{
				Material[] array2 = mats;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
		}
	}
}
