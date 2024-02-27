using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DomeMeshV2 : Ef_Base
{
	public Color color;

	public Gradient colorAnim;

	public float startDelay;

	public float delay;

	public float life;

	public Vector3 maxScale;

	public AnimationCurve scaleAnim;

	public Vector3 minScale;

	public float maxLatitudeA;

	public AnimationCurve latitudeAAnim;

	public float minLatitudeA;

	public float maxLatitudeB;

	public AnimationCurve latitudeBAnim;

	public float minLatitudeB;

	public float maxHoleWidth;

	public AnimationCurve holeWidthAnim;

	public float minHoleWidth;

	public float maxTwist;

	public AnimationCurve twistAnim;

	public float minTwist;

	public float startRot;

	public float rotSpeed;

	public bool zOrigin;

	public bool aOrigin;

	public bool randomStartRot;

	public bool randomRotSpeed;

	public bool worldPos;

	public bool worldRot;

	public int loop;

	public GameObject meshObj;

	public Transform[] bones;

	private Material mat;

	private int leng;

	private int lengm;

	private float fstStartDelay;

	private float fstDelay;

	private float fstLife;

	private int fstLoop;

	private float angle;

	private Vector3 fstPos1;

	private Vector3 fstPos2;

	private Quaternion fstRot1;

	private Quaternion fstRot2;

	private Vector3 wldPos;

	private Quaternion wldRot;

	private bool scaleEnable;

	private bool latiAEnable;

	private bool latiBEnable;

	private bool holeEnable;

	private bool twistEnable;

	private bool ready;

	public Ef_DomeMeshV2()
	{
		color = Color.white;
		life = 1f;
		maxScale = Vector3.one;
		minScale = Vector3.one;
		maxLatitudeA = 1f;
		maxLatitudeB = 1f;
		rotSpeed = 180f;
		zOrigin = true;
		worldPos = true;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Play();
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		fstStartDelay = startDelay;
		fstDelay = delay;
		fstLife = life;
		fstLoop = loop;
		leng = bones.Length;
		if (leng == 0)
		{
			bones = new Transform[11];
			leng = 11;
		}
		checked
		{
			lengm = leng - 1;
			if (!meshObj)
			{
				Transform transform = this.transform.Find("Mesh");
				if ((bool)transform)
				{
					meshObj = transform.gameObject;
				}
			}
			int num = default(int);
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Transform[] array = bones;
					if (!array[RuntimeServices.NormalizeArrayIndex(array, num)])
					{
						string lhs = "b";
						if (num < 9)
						{
							lhs += "0";
						}
						lhs += num + 1;
						Transform[] array2 = bones;
						array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = this.transform.Find(lhs);
						Transform[] array3 = bones;
						if (!array3[RuntimeServices.NormalizeArrayIndex(array3, num)])
						{
							UnityEngine.Object.Destroy(gameObject);
							return;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			if (!meshObj)
			{
				Transform transform2 = this.transform.Find("Mesh");
				if (!transform2)
				{
					UnityEngine.Object.Destroy(gameObject);
					return;
				}
				meshObj = transform2.gameObject;
			}
			mat = meshObj.renderer.material;
			scaleEnable = minScale != maxScale;
			latiAEnable = minLatitudeA != maxLatitudeA;
			latiBEnable = minLatitudeB != maxLatitudeB;
			holeEnable = minHoleWidth != maxHoleWidth;
			twistEnable = minTwist != maxTwist;
			if (worldPos)
			{
				fstPos1 = bones[0].localPosition;
				Transform[] array4 = bones;
				fstPos2 = array4[RuntimeServices.NormalizeArrayIndex(array4, lengm)].localPosition;
			}
			if (worldRot)
			{
				fstRot1 = bones[0].localRotation;
				Transform[] array5 = bones;
				fstRot2 = array5[RuntimeServices.NormalizeArrayIndex(array5, lengm)].localRotation;
			}
			IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					Transform[] array6 = bones;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)].localScale = Vector3.zero;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			ready = true;
		}
	}

	public void Play()
	{
		if (!ready)
		{
			Init();
		}
		startDelay = fstStartDelay;
		delay = fstDelay;
		life = fstLife;
		loop = fstLoop;
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
			Transform[] array = bones;
			array[RuntimeServices.NormalizeArrayIndex(array, index)].localScale = Vector3.zero;
		}
		if (startDelay == 0f && delay == 0f)
		{
			Emit();
		}
	}

	public void Emit()
	{
		life = fstLife;
		if (worldPos)
		{
			wldPos = transform.position;
		}
		if (worldRot)
		{
			wldRot = transform.rotation;
		}
		if (randomStartRot)
		{
			startRot = UnityEngine.Random.Range(0f - startRot, startRot);
		}
		if (randomRotSpeed)
		{
			rotSpeed = UnityEngine.Random.Range(0f - rotSpeed, rotSpeed);
		}
		angle = startRot;
	}

	public void LateUpdate()
	{
		if (!(startDelay <= 0f))
		{
			startDelay -= deltaTime;
			if (startDelay > 0f || delay != 0f)
			{
				return;
			}
			Emit();
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			if (delay > 0f)
			{
				return;
			}
			Emit();
		}
		if (!worldPos)
		{
			wldPos = transform.position;
		}
		if (!worldRot)
		{
			wldRot = transform.rotation;
		}
		float time = (fstLife - life) / fstLife;
		Vector3 vector = default(Vector3);
		if (scaleEnable)
		{
			float t = scaleAnim.Evaluate(time);
			vector = Vector3.Lerp(minScale, maxScale, t);
		}
		else
		{
			vector = minScale;
		}
		float num = default(float);
		if (latiAEnable)
		{
			float t2 = latitudeAAnim.Evaluate(time);
			num = Mathf.SmoothStep(minLatitudeA, maxLatitudeA, t2);
		}
		else
		{
			num = minLatitudeA;
		}
		float num2 = 1.57075f * num;
		float num3 = default(float);
		if (latiBEnable)
		{
			float t3 = latitudeBAnim.Evaluate(time);
			num3 = Mathf.SmoothStep(minLatitudeB, maxLatitudeB, t3);
		}
		else
		{
			num3 = minLatitudeB;
		}
		float num4 = 1.57075f * num3;
		float num5 = default(float);
		if (holeEnable)
		{
			float t4 = holeWidthAnim.Evaluate(time);
			num5 = Mathf.SmoothStep(minHoleWidth, maxHoleWidth, t4);
		}
		else
		{
			num5 = minHoleWidth;
		}
		float num6 = default(float);
		if (twistEnable)
		{
			float t5 = twistAnim.Evaluate(time);
			num6 = Mathf.SmoothStep(minTwist, maxTwist, t5);
		}
		else
		{
			num6 = minTwist;
		}
		float num7 = num2;
		float num8 = (num4 - num2) / 10f;
		Quaternion quaternion = Quaternion.Euler(0f, 0f, num6 / 10f);
		float num9 = vector.z / 2f;
		Vector3 localScale = vector * Mathf.Sin(num7);
		localScale.x += num5;
		localScale.y += num5;
		float num10 = num9 * Mathf.Cos(num7);
		float num11 = 0f;
		if (zOrigin)
		{
			num10 -= num9;
		}
		if (aOrigin)
		{
			num11 = 0f - num10;
		}
		int num12 = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num12 = enumerator.Current;
				Transform[] array = bones;
				array[RuntimeServices.NormalizeArrayIndex(array, num12)].position = wldPos + wldRot * new Vector3(0f, 0f, num10 + num11);
				Transform[] array2 = bones;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num12)].localScale = localScale;
				num7 += num8;
				localScale = vector * Mathf.Sin(num7);
				localScale.x += num5;
				localScale.y += num5;
				num10 = num9 * Mathf.Cos(num7);
				if (zOrigin)
				{
					num10 -= num9;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		angle += rotSpeed * deltaTime;
		Quaternion quaternion2 = Quaternion.Euler(new Vector3(0f, 0f, angle));
		quaternion2 = wldRot * quaternion2;
		IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num12 = enumerator2.Current;
				Transform[] array3 = bones;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num12)].rotation = quaternion2;
				quaternion2 *= quaternion;
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		if (mat.HasProperty("_Color"))
		{
			Color color = this.color * colorAnim.Evaluate(time);
			mat.SetColor("_Color", color);
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		IEnumerator<int> enumerator3 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				num12 = enumerator3.Current;
				Transform[] array4 = bones;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num12)].localScale = Vector3.zero;
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
		checked
		{
			if (loop > 1)
			{
				loop--;
				if (fstDelay == 0f)
				{
					Emit();
				}
				delay = fstDelay;
				life = fstLife;
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
