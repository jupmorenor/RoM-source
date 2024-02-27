using UnityEngine;

public class BoneToRigid : MonoBehaviour
{
	public float sideLen = 0.1f;

	public Transform physRoot;

	private Transform[] physMeshs = new Transform[0];

	private MeshFilter[] meshfs = new MeshFilter[0];

	private MeshCollider mcollider;

	private void Start()
	{
		if ((bool)physRoot)
		{
			int num = ObjCount(physRoot, 0);
			physMeshs = new Transform[num];
			meshfs = new MeshFilter[num];
			AttachPhysMesh(physRoot, 0);
		}
	}

	private void Update()
	{
		if ((bool)physRoot)
		{
			if (!mcollider)
			{
				mcollider = base.gameObject.GetComponent<MeshCollider>();
			}
			if (!mcollider)
			{
				mcollider = base.gameObject.AddComponent("MeshCollider") as MeshCollider;
			}
			if (!base.rigidbody)
			{
				base.gameObject.AddComponent("Rigidbody");
			}
			Debug.Log(base.rigidbody);
			if (meshfs.Length != 0)
			{
				ConbinePhysMesh();
			}
		}
	}

	private int ObjCount(Transform tf, int num)
	{
		num++;
		for (int i = 0; i < tf.childCount; i++)
		{
			num = ObjCount(tf.GetChild(i), num);
		}
		return num;
	}

	private int AttachPhysMesh(Transform tf, int n)
	{
		int num = 8;
		if (num > tf.name.Length - 1)
		{
			num = tf.name.Length - 1;
		}
		if (tf.name.Substring(0, num) == "PhysMesh")
		{
			return n;
		}
		string text = "PhysMesh";
		if (n < 10)
		{
			text += "0";
		}
		text += n;
		physMeshs[n] = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		Object.Destroy(physMeshs[n].GetComponent<BoxCollider>());
		physMeshs[n].name = text;
		physMeshs[n].parent = tf;
		Vector3 vector = new Vector3((0f - sideLen) / 2f, (0f - sideLen) / 2f, (0f - sideLen) / 2f);
		Vector3 vector2 = new Vector3(sideLen / 2f, sideLen / 2f, sideLen / 2f);
		for (int i = 0; i < tf.childCount; i++)
		{
			num = 8;
			if (num > tf.GetChild(i).name.Length - 1)
			{
				num = tf.GetChild(i).name.Length - 1;
			}
			if (!(tf.GetChild(i).name.Substring(0, num) == "PhysMesh"))
			{
				Vector3 localPosition = tf.GetChild(i).localPosition;
				if (localPosition.x < vector.x)
				{
					vector.x = localPosition.x;
				}
				if (localPosition.x > vector2.x)
				{
					vector2.x = localPosition.x;
				}
				if (localPosition.y < vector.y)
				{
					vector.y = localPosition.y;
				}
				if (localPosition.y > vector2.y)
				{
					vector2.y = localPosition.y;
				}
				if (localPosition.z < vector.z)
				{
					vector.z = localPosition.z;
				}
				if (localPosition.z > vector2.z)
				{
					vector2.z = localPosition.z;
				}
			}
		}
		physMeshs[n].localScale = vector2 - vector;
		physMeshs[n].localPosition = (vector + vector2) / 2f;
		physMeshs[n].localRotation = Quaternion.identity;
		physMeshs[n].gameObject.SetActive(value: false);
		meshfs[n] = physMeshs[n].GetComponent<MeshFilter>();
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = AttachPhysMesh(tf.GetChild(i), n);
		}
		return n;
	}

	private void ConbinePhysMesh()
	{
		CombineInstance[] array = new CombineInstance[meshfs.Length];
		for (int i = 0; i < meshfs.Length; i++)
		{
			array[i].mesh = meshfs[i].sharedMesh;
			array[i].transform = physRoot.worldToLocalMatrix * meshfs[i].transform.localToWorldMatrix;
			meshfs[i].gameObject.SetActive(value: false);
		}
		Mesh mesh = new Mesh();
		mesh.name = "RigidBodyMesh";
		mesh.CombineMeshes(array);
		mcollider.sharedMesh = mesh;
		base.transform.gameObject.SetActive(value: true);
	}
}
