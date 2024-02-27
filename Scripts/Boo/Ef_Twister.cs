using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Twister : Ef_GroundHeight
{
	public float speed;

	public float life;

	public Transform trget;

	public float rotSpeed;

	public float scale;

	public float upLength;

	public Transform coneMesh;

	public Transform shadeMesh;

	public Transform hemMesh;

	public Transform smokeObj;

	public Transform[] bones;

	public float accel;

	public float brake;

	public float wave;

	public float radOfst;

	public float maxDist;

	public Transform parentObj;

	private float fstLife;

	private float rand;

	private Material coneMat;

	private Material shadeMat;

	private Material hemMat;

	private Vector3[] poss;

	private Vector3[] fstPoss;

	private Vector3[] velocitys;

	private bool parentFlg;

	public Ef_Twister()
	{
		speed = 5f;
		life = 5f;
		rotSpeed = 10f;
		scale = 0.6f;
		upLength = 0.1f;
		accel = 0.3f;
		brake = 0.3f;
		wave = 0.3f;
		radOfst = 0.5f;
		maxDist = 0.1f;
	}

	public override void Start()
	{
		base.Start();
		if (!coneMesh)
		{
			coneMesh = transform.Find("Cone");
		}
		if (!shadeMesh)
		{
			shadeMesh = transform.Find("Shade");
		}
		if (!hemMesh)
		{
			hemMesh = transform.Find("Hem");
		}
		if (!smokeObj)
		{
			smokeObj = transform.Find("Smoke");
		}
		coneMat = coneMesh.renderer.material;
		shadeMat = shadeMesh.renderer.material;
		hemMat = hemMesh.renderer.material;
		if (bones.Length < 6)
		{
			bones = new Transform[6];
			bones[0] = transform.Find("b00");
			bones[1] = bones[0].Find("b01");
			bones[2] = bones[1].Find("b02");
			bones[3] = bones[2].Find("b03");
			bones[4] = bones[3].Find("b04");
			bones[5] = bones[4].Find("b05");
		}
		transform.localScale = new Vector3(0.1f, 0.1f, 0.1f) * scale;
		poss = new Vector3[6];
		fstPoss = new Vector3[6];
		velocitys = new Vector3[6];
		int num = 0;
		while (num < 6)
		{
			int index = num;
			num++;
			Vector3[] array = poss;
			ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform[] array2 = bones;
			reference = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].position;
			Vector3[] array3 = fstPoss;
			ref Vector3 reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
			Transform[] array4 = bones;
			reference2 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)].localPosition;
			Vector3[] array5 = velocitys;
			ref Vector3 reference3 = ref array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
			reference3 = Vector3.zero;
		}
		fstLife = life;
		rand = UnityEngine.Random.Range(0f, 100f);
		if (!parentObj)
		{
			parentObj = transform.parent;
		}
		if ((bool)parentObj)
		{
			parentFlg = true;
		}
		transform.parent = null;
	}

	public void Update()
	{
		if (parentFlg)
		{
			if ((bool)parentObj)
			{
				transform.position = parentObj.position;
				transform.rotation = parentObj.rotation;
			}
			else if (!(life <= 1f))
			{
				life = 1f;
			}
		}
		transform.Translate(new Vector3(0f, 0f, speed * deltaTime));
		if ((bool)trget)
		{
			Vector3 forward = trget.position - transform.position;
			Quaternion quaternion = Quaternion.LookRotation(forward);
			float t = rotSpeed / Quaternion.Angle(transform.rotation, quaternion) * deltaTime;
			transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, t);
		}
		object[] groundHeight = GetGroundHeight(transform.position);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		Vector3 toDirection = (Vector3)groundHeight[2];
		if (flag)
		{
			num += upLength;
		}
		if ((bool)parentObj)
		{
			float y = num;
			Vector3 position = parentObj.position;
			float num2 = (position.y = y);
			Vector3 vector2 = (parentObj.position = position);
			parentObj.rotation = Quaternion.FromToRotation(transform.up, toDirection) * transform.rotation;
		}
		else
		{
			float y2 = num;
			Vector3 position2 = transform.position;
			float num3 = (position2.y = y2);
			Vector3 vector4 = (transform.position = position2);
			transform.rotation = Quaternion.FromToRotation(transform.up, toDirection) * transform.rotation;
		}
		float num4 = 1f;
		life -= deltaTime;
		if (!(life <= fstLife - 2f))
		{
			float num5 = 1f - (fstLife - life) / 2f;
			num4 = 1f - num5 * num5;
			transform.localScale = new Vector3(num4, num4, num4) * scale;
		}
		else if (!(life >= 1f))
		{
			transform.localScale = new Vector3(life, 1f, life) * scale;
			if ((bool)smokeObj)
			{
				smokeObj.gameObject.particleSystem.emissionRate = 0f;
			}
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		else
		{
			transform.localScale = Vector3.one * scale;
		}
		int num6 = 0;
		while (num6 < 6)
		{
			int num7 = num6;
			num6++;
			Vector3 vector5 = transform.position;
			if (num7 > 0)
			{
				Vector3[] array = poss;
				vector5 = array[RuntimeServices.NormalizeArrayIndex(array, checked(num7 - 1))];
			}
			float f = life + life * (float)num7 * radOfst + rand;
			Vector3[] array2 = fstPoss;
			Vector3 vector6 = array2[RuntimeServices.NormalizeArrayIndex(array2, num7)];
			vector6.y *= num4;
			Vector3 vector7 = vector5 + vector6 * scale + new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f)) * wave;
			Vector3[] array3 = poss;
			Vector3 vector8 = vector7 - array3[RuntimeServices.NormalizeArrayIndex(array3, num7)];
			vector8.y = 0f;
			vector8 *= 1f - brake * deltaTime;
			Vector3[] array4 = velocitys;
			ref Vector3 reference = ref array4[RuntimeServices.NormalizeArrayIndex(array4, num7)];
			Vector3[] array5 = velocitys;
			reference = array5[RuntimeServices.NormalizeArrayIndex(array5, num7)] + vector8 * accel * deltaTime;
			Vector3 vector9 = vector8;
			Vector3[] array6 = velocitys;
			vector8 = vector9 - array6[RuntimeServices.NormalizeArrayIndex(array6, num7)];
			if (!(vector8.magnitude <= maxDist))
			{
				vector8 = vector8.normalized * maxDist;
			}
			Vector3[] array7 = poss;
			ref Vector3 reference2 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, num7)];
			reference2 = vector7 - vector8;
			Transform[] array8 = bones;
			Transform obj = array8[RuntimeServices.NormalizeArrayIndex(array8, num7)];
			Vector3[] array9 = poss;
			obj.position = array9[RuntimeServices.NormalizeArrayIndex(array9, num7)];
		}
		Vector2 mainTextureOffset = coneMat.mainTextureOffset;
		mainTextureOffset.x += 3f * deltaTime;
		mainTextureOffset.y += 1f * deltaTime;
		coneMat.mainTextureOffset = mainTextureOffset;
		mainTextureOffset = shadeMat.mainTextureOffset;
		mainTextureOffset.x += 2f * deltaTime;
		mainTextureOffset.y -= 1f * deltaTime;
		shadeMat.mainTextureOffset = mainTextureOffset;
		mainTextureOffset = hemMat.mainTextureOffset;
		mainTextureOffset.x += 0.5f * deltaTime;
		mainTextureOffset.y += 2f * deltaTime;
		hemMat.mainTextureOffset = mainTextureOffset;
		if ((bool)smokeObj)
		{
			smokeObj.localRotation *= Quaternion.Euler(0f, -360f * deltaTime, 0f);
		}
	}

	public void OnDestroy()
	{
		if ((bool)coneMat)
		{
			UnityEngine.Object.Destroy(coneMat);
		}
		if ((bool)shadeMat)
		{
			UnityEngine.Object.Destroy(shadeMat);
		}
		if ((bool)hemMat)
		{
			UnityEngine.Object.Destroy(hemMat);
		}
	}
}
