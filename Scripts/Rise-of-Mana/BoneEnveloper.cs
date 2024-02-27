using UnityEngine;

[ExecuteInEditMode]
public class BoneEnveloper : MonoBehaviour
{
	public Transform meshObj;

	public bool showNull = true;

	private bool oldShow = true;

	public int weightIndex = 2;

	public Transform[] bones = new Transform[0];

	public bool childPick;

	public bool envelop;

	private Transform oldMesh;

	private Transform[] ptrs = new Transform[0];

	private Vector3[] oldPos = new Vector3[0];

	private Quaternion[] oldRot = new Quaternion[0];

	private Material ptrMat;

	private void Update()
	{
		if (weightIndex < 1)
		{
			weightIndex = 1;
		}
		if (weightIndex > 4)
		{
			weightIndex = 4;
		}
		if (childPick)
		{
			bones = ChildPick(bones);
			childPick = false;
		}
		if (showNull)
		{
			if (ptrs.Length != bones.Length || !oldShow)
			{
				MakePointer(bones.Length);
				oldPos = new Vector3[bones.Length];
				oldRot = new Quaternion[bones.Length];
			}
			for (int i = 0; i < bones.Length; i++)
			{
				if ((bool)bones[i])
				{
					if (oldPos[i] != ptrs[i].position || oldRot[i] != ptrs[i].rotation)
					{
						bones[i].position = ptrs[i].position;
						bones[i].rotation = ptrs[i].rotation;
						ref Vector3 reference = ref oldPos[i];
						reference = ptrs[i].position;
						ref Quaternion reference2 = ref oldRot[i];
						reference2 = ptrs[i].rotation;
					}
					else
					{
						ptrs[i].position = bones[i].position;
						ptrs[i].rotation = bones[i].rotation;
						ref Vector3 reference3 = ref oldPos[i];
						reference3 = ptrs[i].position;
						ref Quaternion reference4 = ref oldRot[i];
						reference4 = ptrs[i].rotation;
					}
				}
			}
			oldShow = true;
		}
		else if (oldShow)
		{
			DeletePointer(0);
			oldShow = false;
		}
		if (envelop)
		{
			Envelop();
			envelop = false;
		}
		if ((bool)meshObj && meshObj != oldMesh)
		{
			MeshRenderer meshRenderer = meshObj.GetComponent("MeshRenderer") as MeshRenderer;
			SkinnedMeshRenderer skinnedMeshRenderer = meshObj.GetComponent("SkinnedMeshRenderer") as SkinnedMeshRenderer;
			if (!meshRenderer && !skinnedMeshRenderer)
			{
				meshObj = null;
			}
			oldMesh = meshObj;
		}
	}

	private Transform[] ChildPick(Transform[] tfs)
	{
		if (tfs.Length == 0)
		{
			return tfs;
		}
		if (tfs[0] == null)
		{
			return tfs;
		}
		Transform[] array;
		if (tfs[0].GetChildCount() == 0)
		{
			if (!tfs[0].parent)
			{
				return tfs;
			}
			int num = ObjCount(tfs[0].parent, 0, noFst: false);
			array = new Transform[num];
			Dig(tfs[0].parent, 0, array, noFst: false);
			NameCheck(array);
		}
		else
		{
			int num = ObjCount(tfs[0], 0, noFst: true);
			array = new Transform[num];
			Dig(tfs[0], 0, array, noFst: true);
		}
		NameCheck(array);
		return array;
	}

	private int ObjCount(Transform tf, int num, bool noFst)
	{
		if (noFst && !tf.renderer)
		{
			num++;
		}
		for (int i = 0; i < tf.GetChildCount(); i++)
		{
			num = ObjCount(tf.GetChild(i), num, noFst: true);
		}
		return num;
	}

	private int Dig(Transform tf, int no, Transform[] tfs, bool noFst)
	{
		if (noFst && !tf.renderer)
		{
			tfs[no] = tf;
			no++;
		}
		for (int i = 0; i < tf.GetChildCount(); i++)
		{
			no = Dig(tf.GetChild(i), no, tfs, noFst: true);
		}
		return no;
	}

	private void NameCheck(Transform[] tfs)
	{
		for (int i = 0; i < tfs.Length; i++)
		{
			string text = tfs[i].name;
			bool flag = false;
			for (int j = i + 1; j < tfs.Length; j++)
			{
				if (text == tfs[j].name)
				{
					string text2 = tfs[j].name;
					if (j < 10)
					{
						text2 += "0";
					}
					text2 += j;
					tfs[j].name = text2;
					flag = true;
				}
			}
			if (flag)
			{
				if (i < 10)
				{
					text += "0";
				}
				text += i;
				tfs[i].name = text;
			}
		}
	}

	private void Envelop()
	{
		if (!meshObj)
		{
			return;
		}
		for (int i = 0; i < bones.Length; i++)
		{
			if (!bones[i])
			{
				return;
			}
		}
		Mesh mesh = null;
		Material material = null;
		MeshFilter meshFilter = meshObj.GetComponent("MeshFilter") as MeshFilter;
		MeshRenderer meshRenderer = meshObj.GetComponent("MeshRenderer") as MeshRenderer;
		if ((bool)meshFilter)
		{
			mesh = meshFilter.sharedMesh;
			if ((bool)meshRenderer)
			{
				material = meshRenderer.sharedMaterial;
			}
		}
		else
		{
			SkinnedMeshRenderer skinnedMeshRenderer = meshObj.GetComponent("SkinnedMeshRenderer") as SkinnedMeshRenderer;
			if ((bool)skinnedMeshRenderer)
			{
				mesh = skinnedMeshRenderer.sharedMesh;
				material = skinnedMeshRenderer.sharedMaterial;
			}
		}
		if (!mesh)
		{
			return;
		}
		GameObject gameObject = new GameObject(meshObj.name);
		gameObject.transform.parent = meshObj.parent;
		gameObject.transform.localPosition = meshObj.localPosition;
		gameObject.transform.localRotation = meshObj.localRotation;
		gameObject.transform.localScale = meshObj.localScale;
		SkinnedMeshRenderer skinnedMeshRenderer2 = gameObject.AddComponent("SkinnedMeshRenderer") as SkinnedMeshRenderer;
		if ((bool)material)
		{
			gameObject.renderer.material = material;
		}
		Transform parent = TrashObj();
		meshObj.parent = parent;
		meshObj.gameObject.SetActive(value: false);
		meshObj = gameObject.transform;
		Vector3[] vertices = mesh.vertices;
		BoneWeight[] array = new BoneWeight[vertices.Length];
		for (int i = 0; i < vertices.Length; i++)
		{
			int[] array2 = new int[4] { -1, -1, -1, -1 };
			float[] array3 = new float[4] { 9999f, 9999f, 9999f, 9999f };
			Quaternion[] array4 = new Quaternion[4]
			{
				Quaternion.identity,
				Quaternion.identity,
				Quaternion.identity,
				Quaternion.identity
			};
			Matrix4x4 matrix4x = Matrix4x4.TRS(meshObj.position, meshObj.rotation, meshObj.localScale);
			Vector3 vector = matrix4x * vertices[i];
			for (int j = 0; j < bones.Length; j++)
			{
				Vector3 position = bones[j].position;
				Vector3 fromDirection = vector - position;
				float magnitude = fromDirection.magnitude;
				if (magnitude < array3[0])
				{
					array2[0] = j;
					array3[0] = magnitude;
					ref Quaternion reference = ref array4[0];
					reference = Quaternion.FromToRotation(fromDirection, Vector3.up);
				}
			}
			if (weightIndex >= 2)
			{
				for (int j = 0; j < bones.Length; j++)
				{
					if (j == array2[0])
					{
						continue;
					}
					Vector3 position = bones[j].position;
					Vector3 fromDirection = vector - position;
					if (!((array4[0] * fromDirection).y * 0.999f > array3[0]))
					{
						float magnitude = fromDirection.magnitude;
						if (magnitude < array3[1])
						{
							array2[1] = j;
							array3[1] = magnitude;
							ref Quaternion reference2 = ref array4[1];
							reference2 = Quaternion.FromToRotation(fromDirection, Vector3.up);
						}
					}
				}
			}
			if (weightIndex >= 3)
			{
				for (int j = 0; j < bones.Length; j++)
				{
					if (j == array2[0] || j == array2[1])
					{
						continue;
					}
					Vector3 position = bones[j].position;
					Vector3 fromDirection = vector - position;
					if (!((array4[0] * fromDirection).y * 0.999f > array3[0]) && !((array4[1] * fromDirection).y * 0.999f > array3[1]))
					{
						float magnitude = fromDirection.magnitude;
						if (magnitude < array3[2])
						{
							array2[2] = j;
							array3[2] = magnitude;
							ref Quaternion reference3 = ref array4[2];
							reference3 = Quaternion.FromToRotation(fromDirection, Vector3.up);
						}
					}
				}
			}
			if (weightIndex >= 4)
			{
				for (int j = 0; j < bones.Length; j++)
				{
					if (j == array2[0] || j == array2[1] || j == array2[2])
					{
						continue;
					}
					Vector3 position = bones[j].position;
					Vector3 fromDirection = vector - position;
					if (!((array4[0] * fromDirection).y * 0.999f > array3[0]) && !((array4[1] * fromDirection).y * 0.999f > array3[1]) && !((array4[2] * fromDirection).y * 0.999f > array3[2]))
					{
						float magnitude = fromDirection.magnitude;
						if (magnitude < array3[3])
						{
							array2[3] = j;
							array3[3] = magnitude;
							ref Quaternion reference4 = ref array4[3];
							reference4 = Quaternion.FromToRotation(fromDirection, Vector3.up);
						}
					}
				}
			}
			float num = 0f;
			for (int j = 0; j < weightIndex; j++)
			{
				num += array3[j];
			}
			if (weightIndex == 1 || array2[1] == -1)
			{
				array[i].boneIndex0 = array2[0];
				array[i].weight0 = 1f;
			}
			else if (weightIndex == 2 || array2[2] == -1)
			{
				Vector3 vector2 = bones[array2[1]].position - bones[array2[0]].position;
				Quaternion quaternion = Quaternion.FromToRotation(vector2, Vector3.up);
				vector2 = quaternion * vector2;
				Vector3 position = bones[array2[0]].position;
				Vector3 fromDirection = vector - position;
				fromDirection = quaternion * fromDirection;
				float num2 = 1f - 1f / vector2.y * fromDirection.y;
				array[i].boneIndex0 = array2[0];
				array[i].boneIndex1 = array2[1];
				array[i].weight0 = num2;
				array[i].weight1 = 1f - num2;
			}
			else if (weightIndex == 3 || array2[3] == -1)
			{
				array[i].boneIndex0 = array2[0];
				array[i].boneIndex1 = array2[1];
				array[i].boneIndex2 = array2[2];
				float num3 = 1f / num * (num - array3[0]);
				float num4 = 1f / num * (num - array3[1]);
				float num5 = 1f / num * (num - array3[2]);
				float num6 = num3 + num4 + num5;
				array[i].weight0 = num3 / num6;
				array[i].weight1 = num4 / num6;
				array[i].weight2 = num5 / num6;
			}
			else if (weightIndex == 4)
			{
				array[i].boneIndex0 = array2[0];
				array[i].boneIndex1 = array2[1];
				array[i].boneIndex2 = array2[2];
				array[i].boneIndex3 = array2[3];
				float num3 = 1f / num * (num - array3[0]);
				float num4 = 1f / num * (num - array3[1]);
				float num5 = 1f / num * (num - array3[2]);
				float num7 = 1f / num * (num - array3[3]);
				float num6 = num3 + num4 + num5 + num7;
				array[i].weight0 = num3 / num6;
				array[i].weight1 = num4 / num6;
				array[i].weight2 = num5 / num6;
				array[i].weight3 = num7 / num6;
			}
		}
		Matrix4x4[] array5 = new Matrix4x4[bones.Length];
		for (int i = 0; i < bones.Length; i++)
		{
			ref Matrix4x4 reference5 = ref array5[i];
			reference5 = bones[i].worldToLocalMatrix * meshObj.localToWorldMatrix;
		}
		mesh.boneWeights = array;
		mesh.bindposes = array5;
		skinnedMeshRenderer2.bones = bones;
		skinnedMeshRenderer2.sharedMesh = mesh;
	}

	private void MakePointer(int num)
	{
		int i;
		for (i = 0; i < num; i++)
		{
			if (!bones[i])
			{
				return;
			}
		}
		ptrs = new Transform[num];
		for (i = 0; i < num; i++)
		{
			GameObject gameObject = GameObject.Find("Pointer" + i);
			if ((bool)gameObject)
			{
				ptrs[i] = gameObject.transform;
				ptrs[i].parent = base.transform;
				continue;
			}
			ptrs[i] = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			ptrs[i].name = "Pointer" + i;
			ptrs[i].parent = base.transform;
			ptrs[i].position = bones[i].position;
			ptrs[i].rotation = bones[i].rotation;
			ptrs[i].localScale = new Vector3(0.1f, 0.1f, 0.1f);
			if (!ptrMat)
			{
				ptrMat = MakePtrMat();
			}
			ptrs[i].renderer.material = ptrMat;
		}
		DeletePointer(i);
	}

	private Material MakePtrMat()
	{
		Material material = new Material(Shader.Find("GUI/Text Shader"));
		material.name = "Pointer";
		material.color = new Color(1f, 0f, 1f);
		return material;
	}

	private void DeletePointer(int start)
	{
		Transform parent = TrashObj();
		for (int i = start; i < 100; i++)
		{
			GameObject gameObject = GameObject.Find("Pointer" + i);
			if ((bool)gameObject)
			{
				gameObject.transform.parent = parent;
				gameObject.SetActive(value: false);
				i--;
			}
		}
	}

	private Transform TrashObj()
	{
		GameObject gameObject = GameObject.Find("Trash");
		if ((bool)gameObject)
		{
			return gameObject.transform;
		}
		return new GameObject("Trash").transform;
	}
}
