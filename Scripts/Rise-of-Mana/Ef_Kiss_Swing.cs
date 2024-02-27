using UnityEngine;

public class Ef_Kiss_Swing : Ef_Base
{
	public Transform[] bones = new Transform[1];

	public bool childPick;

	private Vector3[] basePoss = new Vector3[0];

	private Vector3[] baseRots = new Vector3[0];

	private Vector3[] pVecs = new Vector3[0];

	private Vector3[] rVecs = new Vector3[0];

	private Vector3[] lstPoss = new Vector3[0];

	private Vector3[] lstRots = new Vector3[0];

	public float posAccel = 3000f;

	public float rotAccel = 12000f;

	public float brake = 8f;

	public float rbrake = 8f;

	public float maxSwg = 0.1f;

	public float maxRot = 30f;

	private int numOf;

	private void Start()
	{
		if (childPick && (bool)bones[0])
		{
			bones = ChildPick(bones[0]);
			childPick = false;
		}
		numOf = bones.Length;
		basePoss = new Vector3[numOf];
		baseRots = new Vector3[numOf];
		pVecs = new Vector3[numOf];
		rVecs = new Vector3[numOf];
		lstPoss = new Vector3[numOf];
		lstRots = new Vector3[numOf];
		for (int i = 0; i < numOf; i++)
		{
			if ((bool)bones[i])
			{
				ref Vector3 reference = ref basePoss[i];
				reference = bones[i].localPosition;
				ref Vector3 reference2 = ref baseRots[i];
				reference2 = bones[i].localRotation.eulerAngles;
				ref Vector3 reference3 = ref pVecs[i];
				reference3 = Vector3.zero;
				ref Vector3 reference4 = ref rVecs[i];
				reference4 = Vector3.zero;
				ref Vector3 reference5 = ref lstPoss[i];
				reference5 = bones[i].position;
				ref Vector3 reference6 = ref lstRots[i];
				reference6 = bones[i].localRotation.eulerAngles;
			}
		}
	}

	private void Update()
	{
		ChildSwing();
	}

	private void ChildSwing()
	{
		for (int i = 0; i < numOf; i++)
		{
			if (!bones[i])
			{
				continue;
			}
			Transform parent = bones[i].parent;
			Vector3 vector = ((!parent) ? basePoss[i] : (parent.position + parent.rotation * basePoss[i] * parent.localScale.x));
			Vector3 vector2 = vector - lstPoss[i];
			if (vector2 != Vector3.zero)
			{
				if (vector2.magnitude > maxSwg)
				{
					vector2 = vector2.normalized * maxSwg;
				}
				vector2 *= 1f - brake * base.deltaTime;
				pVecs[i] += vector2 * posAccel * base.deltaTime;
				if (vector2.magnitude < 0.01f && pVecs[i].magnitude < 0.01f)
				{
					vector2 = Vector3.zero;
					ref Vector3 reference = ref pVecs[i];
					reference = Vector3.zero;
				}
				ref Vector3 reference2 = ref lstPoss[i];
				reference2 = vector - vector2;
			}
			Vector3 vector3 = vector2;
			Vector3 vector4 = baseRots[i] - lstRots[i] + new Vector3(0f - vector3.z, 0f, vector3.x);
			if (vector4 != Vector3.zero)
			{
				if (vector4.magnitude > maxRot)
				{
					vector4 = vector4.normalized * maxRot;
				}
				vector4 *= 1f - rbrake * base.deltaTime;
				rVecs[i] += vector4 * rotAccel * base.deltaTime;
				if (vector4.magnitude < 0.01f && rVecs[i].magnitude < 0.01f)
				{
					vector4 = Vector3.zero;
					ref Vector3 reference3 = ref rVecs[i];
					reference3 = Vector3.zero;
				}
				ref Vector3 reference4 = ref lstRots[i];
				reference4 = baseRots[i] - vector4;
			}
			bones[i].position = lstPoss[i] + pVecs[i] * base.deltaTime;
			ref Vector3 reference5 = ref lstPoss[i];
			reference5 = bones[i].position;
			Vector3 vector5 = lstRots[i] + rVecs[i] * base.deltaTime;
			bones[i].localRotation = Quaternion.Euler(vector5);
			lstRots[i] = vector5;
		}
	}

	private Transform[] ChildPick(Transform tf)
	{
		int num = ChildCount(tf, 0);
		Transform[] array = new Transform[num];
		ChildDig(array, tf, 0);
		return array;
	}

	private int ChildCount(Transform tf, int n)
	{
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = ChildCount(tf.GetChild(i), n);
		}
		return n;
	}

	private int ChildDig(Transform[] tfs, Transform tf, int n)
	{
		tfs[n] = tf;
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = ChildDig(tfs, tf.GetChild(i), n);
		}
		return n;
	}
}
