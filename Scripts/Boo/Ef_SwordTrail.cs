using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SwordTrail : Ef_Base
{
	public Transform weaponAttachObj;

	public float weaponLength;

	public float endScale;

	public int step;

	public int division;

	public float profound;

	public float maxDistance;

	public float maxAngle;

	public Color color;

	public Vector3 offset;

	public Vector3 windVec;

	public Transform[] bones;

	public Material material;

	public bool makeMesh;

	public float slashTime;

	public bool slash;

	public bool destroyOne;

	private SkinnedMeshRenderer rend;

	private MeshFilter meshf;

	private Mesh mesh;

	private Material mat;

	private float fstLife;

	private float life;

	private Vector3[] poss;

	private Quaternion[] rots;

	private float[] wids;

	private int pt;

	private bool ready;

	private bool skip;

	public Ef_SwordTrail()
	{
		weaponLength = 1f;
		endScale = 1.5f;
		step = 46;
		division = 4;
		profound = 0.4f;
		maxDistance = 1f;
		maxAngle = 30f;
		color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		offset = Vector3.zero;
		windVec = Vector3.zero;
	}

	public void Start()
	{
	}

	public void LateUpdate()
	{
		if (!ready)
		{
			Initialize();
		}
		if (!weaponAttachObj)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!(life <= 0f))
		{
			UpdateTransform();
			UpdateBone();
			UpdateColor();
			life -= deltaTime;
			if (!(life > 0f))
			{
				life = 0f;
			}
			if (life == 0f)
			{
				renderer.enabled = false;
				if (destroyOne)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		if (windVec != Vector3.zero)
		{
			WindForce();
		}
		if (slash)
		{
			SlashTrail(slashTime);
			slash = false;
		}
	}

	public void SlashTrail(float time)
	{
		if (time != 0f)
		{
			if (!ready)
			{
				Initialize();
			}
			if (ready)
			{
				life = time;
				fstLife = time;
				BoneReset();
				UpdateBone();
				UpdateColor();
				renderer.enabled = true;
			}
		}
	}

	public void Initialize()
	{
		if (!weaponAttachObj)
		{
			if ((bool)transform.parent)
			{
				weaponAttachObj = ExtensionsModule.FindInDescendants(transform.parent, "r_weapon_1");
			}
			if ((bool)transform.parent)
			{
				weaponAttachObj = ExtensionsModule.FindInDescendants(transform.parent, "r_weapon");
			}
			if ((bool)transform.parent)
			{
				weaponAttachObj = ExtensionsModule.FindInDescendants(transform.parent, "r_hand");
			}
		}
		if ((bool)weaponAttachObj)
		{
			pt = 0;
			poss = new Vector3[step];
			rots = new Quaternion[step];
			wids = new float[step];
			int num = 0;
			int num2 = step;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				Vector3[] array = poss;
				ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
				reference = Vector3.zero;
				Quaternion[] array2 = rots;
				ref Quaternion reference2 = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				reference2 = Quaternion.identity;
				float[] array3 = wids;
				array3[RuntimeServices.NormalizeArrayIndex(array3, index)] = 1f;
			}
			mat = renderer.material;
			UpdateColor();
			BoneLength();
			ready = true;
		}
	}

	public void UpdateTransform()
	{
		Vector3[] array = poss;
		Vector3 vector = array[RuntimeServices.NormalizeArrayIndex(array, pt)];
		Quaternion[] array2 = rots;
		Quaternion quaternion = array2[RuntimeServices.NormalizeArrayIndex(array2, pt)];
		Vector3 vector2 = weaponAttachObj.position + weaponAttachObj.rotation * offset;
		Quaternion quaternion2 = Quaternion.FromToRotation(Vector3.forward, weaponAttachObj.rotation * Vector3.up);
		float num = (vector2 - vector).magnitude;
		if (!(num >= 0.001f))
		{
			num = 0.001f;
		}
		float num2 = Quaternion.Angle(quaternion, quaternion2);
		Vector3 vector3 = vector2 + quaternion2 * Vector3.forward;
		Vector3 vector4 = vector + quaternion * Vector3.forward;
		Vector3 upwards = vector3 - vector4;
		if (!(num <= 2f) && !skip)
		{
			skip = true;
			return;
		}
		skip = false;
		float from = default(float);
		float to = default(float);
		if (!(profound <= 0f))
		{
			quaternion2 = Quaternion.LookRotation(quaternion2 * Vector3.forward, upwards);
			float[] array3 = wids;
			from = array3[RuntimeServices.NormalizeArrayIndex(array3, pt)];
			to = Mathf.Clamp(num / deltaTime * 0.1f, 0.001f, 1f);
		}
		if (!(num2 >= 1f))
		{
			num2 = 1f;
		}
		float num3 = num / (Mathf.Sin((float)Math.PI / 360f * num2) * 2f);
		if (!(num <= upwards.magnitude))
		{
			num3 *= -1f;
		}
		Vector3 to2 = vector2 + quaternion2 * new Vector3(0f, 0f, 0f - num3);
		Vector3 from2 = vector + quaternion * new Vector3(0f, 0f, 0f - num3);
		checked
		{
			int num4 = (int)Mathf.Max(Mathf.Ceil(num / maxDistance), Mathf.Ceil(num2 / maxAngle));
			Vector3 vector5 = default(Vector3);
			Vector3 vector6 = default(Vector3);
			Quaternion quaternion3 = default(Quaternion);
			float num5 = 1f / (float)num4;
			int num6 = default(int);
			IEnumerator<int> enumerator = Builtins.range(num4).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num6 = enumerator.Current;
					float t = num5 * (float)(num6 + 1);
					pt++;
					if (pt >= step)
					{
						pt = 0;
					}
					vector6 = Vector3.Lerp(from2, to2, t);
					quaternion3 = Quaternion.Lerp(quaternion, quaternion2, t);
					vector5 = vector6 + quaternion3 * new Vector3(0f, 0f, num3);
					Vector3[] array4 = poss;
					array4[RuntimeServices.NormalizeArrayIndex(array4, pt)] = vector5;
					Quaternion[] array5 = rots;
					array5[RuntimeServices.NormalizeArrayIndex(array5, pt)] = quaternion3;
					if (!(profound <= 0f))
					{
						float[] array6 = wids;
						array6[RuntimeServices.NormalizeArrayIndex(array6, pt)] = Mathf.Lerp(from, to, t);
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public void BoneLength()
	{
		float num = 1f / (float)checked(step - 1);
		int num2 = default(int);
		float to = weaponLength * endScale;
		IEnumerator<int> enumerator = Builtins.range(step).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num2 = enumerator.Current;
				float z = Mathf.Lerp(weaponLength, to, num * (float)num2);
				Transform[] array = bones;
				array[RuntimeServices.NormalizeArrayIndex(array, num2)].localScale = new Vector3(0.001f, 1f, z);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void UpdateBone()
	{
		int num = pt;
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(step).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num2 = enumerator.Current;
					Transform[] array = bones;
					Transform obj = array[RuntimeServices.NormalizeArrayIndex(array, num2)];
					Vector3[] array2 = poss;
					obj.position = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					Transform[] array3 = bones;
					Transform obj2 = array3[RuntimeServices.NormalizeArrayIndex(array3, num2)];
					Quaternion[] array4 = rots;
					obj2.rotation = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					num--;
					if (num < 0)
					{
						num = step - 1;
					}
					if (!(profound <= 0f))
					{
						Transform[] array5 = bones;
						Vector3 localScale = array5[RuntimeServices.NormalizeArrayIndex(array5, num2)].localScale;
						float[] array6 = wids;
						localScale.x = array6[RuntimeServices.NormalizeArrayIndex(array6, num)];
						Transform[] array7 = bones;
						array7[RuntimeServices.NormalizeArrayIndex(array7, num2)].localScale = localScale;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public void UpdateColor()
	{
		Color color = this.color;
		color.a = Mathf.Min(4f / fstLife * life, this.color.a);
		mat.color = color;
	}

	public void BoneReset()
	{
		Vector3 vector = weaponAttachObj.position + weaponAttachObj.rotation * offset;
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.forward, weaponAttachObj.rotation * Vector3.up);
		int num = 0;
		int num2 = step;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Vector3[] array = poss;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = vector;
			Quaternion[] array2 = rots;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = quaternion;
		}
		pt = 0;
	}

	public void WindForce()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(step).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Vector3[] array = poss;
				ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num)];
				Vector3[] array2 = poss;
				reference = array2[RuntimeServices.NormalizeArrayIndex(array2, num)] + windVec * deltaTime;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		if ((bool)mesh)
		{
			UnityEngine.Object.Destroy(mesh);
		}
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
