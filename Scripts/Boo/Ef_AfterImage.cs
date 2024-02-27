using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_AfterImage : Ef_Base
{
	public float life;

	public Material material;

	public bool player;

	public string findCharName;

	public string[] meshObjNames;

	public Ef_AfterImageMinMaxAnim posAnim;

	public Ef_AfterImageMinMaxAnim rotAnim;

	public Ef_AfterImageMinMaxAnim scaleAnim;

	public Gradient colorAnim;

	public bool alpha2RimPow;

	public bool rendererOff;

	private float fstLife;

	private Vector3 fstPos;

	private Quaternion fstRot;

	private GameObject[] imgObjs;

	private Mesh[] meshs;

	private Material mat;

	private int leng;

	private float scalePlus;

	public Ef_AfterImage()
	{
		life = 1f;
		player = true;
		findCharName = string.Empty;
		alpha2RimPow = true;
		scalePlus = 1f;
	}

	public void Start()
	{
		GameObject gameObject = null;
		if (player)
		{
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if (!currentPlayer || !currentPlayer.IsReady)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
			gameObject = ((!currentPlayer.IsTensi) ? currentPlayer.akumaModel : currentPlayer.tensiModel);
			if (!gameObject)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
		}
		else
		{
			GameObject gameObject2 = GameObject.Find(findCharName);
			if (!gameObject2)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
			MerlinMotionPackControl component = gameObject2.GetComponent<MerlinMotionPackControl>();
			if (!component)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
			gameObject = component.motionTarget.gameObject;
			if (!gameObject)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
		}
		Transform transform = null;
		if ((bool)gameObject)
		{
			transform = gameObject.transform.Find("poly");
			if ((bool)transform)
			{
			}
		}
		SkinnedMeshRenderer[] componentsInChildren = transform.GetComponentsInChildren<SkinnedMeshRenderer>();
		int length = componentsInChildren.Length;
		if (length == 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		int num = default(int);
		int num2 = default(int);
		int length2 = meshObjNames.Length;
		checked
		{
			if (length2 > 0)
			{
				leng = 0;
				IEnumerator<int> enumerator = Builtins.range(meshObjNames.Length).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								num2 = enumerator2.Current;
								string text = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num2)].name;
								string[] array = meshObjNames;
								if (text == array[RuntimeServices.NormalizeArrayIndex(array, num)])
								{
									if (componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num2)].enabled)
									{
										componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, leng)] = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num2)];
										leng++;
									}
								}
							}
						}
						finally
						{
							enumerator2.Dispose();
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				if (leng == 0)
				{
					UnityEngine.Object.Destroy(this.gameObject);
					return;
				}
			}
			else
			{
				leng = length;
			}
			meshs = new Mesh[leng];
			mat = new Material(material);
			if (!mat.HasProperty("_Color"))
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
			imgObjs = new GameObject[leng];
			IEnumerator<int> enumerator3 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					num = enumerator3.Current;
					if (!componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num)].enabled)
					{
						continue;
					}
					GameObject gameObject3 = new GameObject("Ef_AfterImage_Char " + num);
					gameObject3.transform.position = gameObject.transform.position;
					gameObject3.transform.rotation = gameObject.transform.rotation;
					MeshRenderer meshRenderer = gameObject3.AddComponent<MeshRenderer>();
					MeshFilter meshFilter = gameObject3.AddComponent<MeshFilter>();
					Mesh[] array2 = meshs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = new Mesh();
					SkinnedMeshRenderer obj = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num)];
					Mesh[] array3 = meshs;
					obj.BakeMesh(array3[RuntimeServices.NormalizeArrayIndex(array3, num)]);
					Mesh[] array4 = meshs;
					meshFilter.sharedMesh = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					int length3 = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num)].materials.Length;
					Material[] array5 = new Material[length3];
					IEnumerator<int> enumerator4 = Builtins.range(length3).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							num2 = enumerator4.Current;
							array5[RuntimeServices.NormalizeArrayIndex(array5, num2)] = mat;
						}
					}
					finally
					{
						enumerator4.Dispose();
					}
					meshRenderer.materials = array5;
					meshRenderer.castShadows = false;
					meshRenderer.receiveShadows = false;
					GameObject[] array6 = imgObjs;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)] = gameObject3;
				}
			}
			finally
			{
				enumerator3.Dispose();
			}
			if (rendererOff)
			{
				IEnumerator<int> enumerator5 = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						num = enumerator5.Current;
						componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num)].enabled = false;
					}
				}
				finally
				{
					enumerator5.Dispose();
				}
			}
			fstLife = life;
			fstPos = imgObjs[0].transform.position;
			fstRot = imgObjs[0].transform.rotation;
		}
	}

	public void Update()
	{
		int num = default(int);
		float time = 1f - life / fstLife;
		float num2 = default(float);
		float num3 = default(float);
		float num4 = default(float);
		num2 = Mathf.Lerp(posAnim.xMin, posAnim.xMax, posAnim.xAnim.Evaluate(time));
		num3 = Mathf.Lerp(posAnim.yMin, posAnim.yMax, posAnim.yAnim.Evaluate(time));
		num4 = Mathf.Lerp(posAnim.zMin, posAnim.zMax, posAnim.zAnim.Evaluate(time));
		Vector3 vector = new Vector3(num2, num3, num4);
		num2 = Mathf.Lerp(rotAnim.xMin, rotAnim.xMax, rotAnim.xAnim.Evaluate(time));
		num3 = Mathf.Lerp(rotAnim.yMin, rotAnim.yMax, rotAnim.yAnim.Evaluate(time));
		num4 = Mathf.Lerp(rotAnim.zMin, rotAnim.zMax, rotAnim.zAnim.Evaluate(time));
		Quaternion quaternion = Quaternion.Euler(num2, num3, num4);
		num2 = Mathf.Lerp(scaleAnim.xMin, scaleAnim.xMax, scaleAnim.xAnim.Evaluate(time));
		num3 = Mathf.Lerp(scaleAnim.yMin, scaleAnim.yMax, scaleAnim.yAnim.Evaluate(time));
		num4 = Mathf.Lerp(scaleAnim.zMin, scaleAnim.zMax, scaleAnim.zAnim.Evaluate(time));
		Vector3 localScale = new Vector3(num2, num3, num4);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = imgObjs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					GameObject[] array2 = imgObjs;
					Transform transform = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].transform;
					transform.rotation = fstRot * quaternion;
					transform.position = fstPos + transform.rotation * vector;
					transform.localScale = localScale;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Color color = colorAnim.Evaluate(time);
		mat.SetColor("_Color", color);
		if (alpha2RimPow)
		{
			mat.SetFloat("_RimPlus", -1f + color.a * 2f);
		}
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void OnDestroy()
	{
		if (imgObjs == null)
		{
			return;
		}
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject[] array = imgObjs;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != null)
			{
				GameObject[] array2 = imgObjs;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
			Mesh[] array3 = meshs;
			if (array3[RuntimeServices.NormalizeArrayIndex(array3, index)] != null)
			{
				Mesh[] array4 = meshs;
				UnityEngine.Object.Destroy(array4[RuntimeServices.NormalizeArrayIndex(array4, index)]);
			}
		}
		if (mat != null)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
