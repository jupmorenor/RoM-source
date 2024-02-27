using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Comb_RockBlast_Rock : Ef_GroundHeight
{
	public Transform[] splintObjs;

	public Transform[] splintMeshs;

	public Transform smokeObj;

	public Transform smokeObj2;

	public Transform ringObj;

	public Transform splitObj;

	public float life;

	public float gravity;

	public float boundRate;

	public int boundNum;

	public float rapidTime;

	private Ef_SmokeColorData colorData;

	private Vector3 velocity;

	private Vector3 rotSpd;

	private Vector3[] splintVels;

	private Vector3[] splintRots;

	private Material mat;

	private float scale;

	private float fstTime;

	public Ef_Comb_RockBlast_Rock()
	{
		splintObjs = new Transform[3];
		splintMeshs = new Transform[3];
		life = 3f;
		gravity = 2f;
		boundRate = 0.6f;
		boundNum = 2;
		rapidTime = 1f;
		velocity = Vector3.zero;
		splintVels = new Vector3[3]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};
		splintRots = new Vector3[3]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};
	}

	public override void Start()
	{
		base.Start();
		if (!collider)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!splintObjs[0])
		{
			splintObjs[0] = transform.Find("Splinter1");
		}
		if (!splintObjs[1])
		{
			splintObjs[1] = transform.Find("Splinter2");
		}
		if (!splintObjs[2])
		{
			splintObjs[2] = transform.Find("Splinter3");
		}
		if (!splintMeshs[0])
		{
			splintMeshs[0] = splintObjs[0].Find("Mesh1");
		}
		if (!splintMeshs[1])
		{
			splintMeshs[1] = splintObjs[1].Find("Mesh2");
		}
		if (!splintMeshs[2])
		{
			splintMeshs[2] = splintObjs[2].Find("Mesh3");
		}
		mat = splintMeshs[0].renderer.material;
		Material material = splintMeshs[1].renderer.material;
		if ((bool)material)
		{
			UnityEngine.Object.Destroy(material);
		}
		splintMeshs[1].renderer.material = mat;
		Material material2 = splintMeshs[2].renderer.material;
		if ((bool)material2)
		{
			UnityEngine.Object.Destroy(material2);
		}
		splintMeshs[2].renderer.material = mat;
		if (!smokeObj)
		{
			smokeObj = transform.Find("Smoke");
		}
		if (!smokeObj2)
		{
			smokeObj2 = transform.Find("Smoke2");
		}
		if (!ringObj)
		{
			ringObj = smokeObj.Find("Ring");
		}
		if (!splitObj)
		{
			splitObj = transform.Find("Split");
		}
		smokeObj.gameObject.SetActive(value: false);
		smokeObj2.gameObject.SetActive(value: false);
		splitObj.gameObject.SetActive(value: false);
		velocity = transform.rotation * new Vector3(0f, 0f, 15f);
		rotSpd = new Vector3(UnityEngine.Random.Range(-360f, 360f), 0f, UnityEngine.Random.Range(-360f, 360f));
		scale = transform.localScale.x;
		fstTime = rapidTime;
		if ((bool)Ef_SmokeColorData.current)
		{
			colorData = Ef_SmokeColorData.current.GetComponent<Ef_SmokeColorData>();
		}
	}

	public void Update()
	{
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		float num = default(float);
		Vector3 vector2 = default(Vector3);
		if (boundNum >= 0)
		{
			vector = transform.position;
			quaternion = transform.rotation;
			vector += velocity * deltaTime;
			velocity.y -= gravity;
			quaternion = Quaternion.Euler(rotSpd * deltaTime) * quaternion;
			object[] groundHeight = GetGroundHeight(transform.position);
			object value = groundHeight[0];
			num = RuntimeServices.UnboxSingle(groundHeight[1]);
			vector2 = (Vector3)groundHeight[2];
			if (RuntimeServices.ToBool(value) && !(vector.y > num + scale))
			{
				vector.y = num + scale + 0.01f;
				if ((bool)smokeObj && (bool)smokeObj2)
				{
					if (!smokeObj.gameObject.activeSelf)
					{
						smokeObj.gameObject.SetActive(value: true);
						smokeObj.particleSystem.Play();
						ringObj.particleSystem.Play();
						smokeObj.parent = null;
						smokeObj.gameObject.AddComponent<Ef_DestroyTimer>().life = 2f;
					}
					else if (!smokeObj2.gameObject.activeSelf)
					{
						smokeObj2.gameObject.SetActive(value: true);
						smokeObj2.particleSystem.Play();
						smokeObj2.parent = null;
						smokeObj2.gameObject.AddComponent<Ef_DestroyTimer>().life = 2f;
					}
				}
				checked
				{
					boundNum--;
				}
				if (boundNum >= 0)
				{
					velocity.y *= 0f - boundRate;
					velocity.x *= UnityEngine.Random.Range(0.5f, 1.2f);
					velocity.z *= UnityEngine.Random.Range(0.5f, 1.2f);
					velocity.x += vector2.x * 10f;
					velocity.z += vector2.z * 10f;
					rotSpd *= -0.5f;
					rotSpd += new Vector3(velocity.z * 100f, 0f, velocity.x * 100f);
				}
				else
				{
					int num2 = 0;
					int length = splintObjs.Length;
					if (length < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num2 < length)
					{
						int index = num2;
						num2++;
						Vector3[] array = splintVels;
						ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
						Transform[] array2 = splintObjs;
						reference = (array2[RuntimeServices.NormalizeArrayIndex(array2, index)].position - vector) * 10f + new Vector3(0f, 10f, 0f);
						Vector3[] array3 = splintRots;
						ref Vector3 reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
						reference2 = new Vector3(UnityEngine.Random.Range(-360f, 360f), 0f, UnityEngine.Random.Range(-360f, 360f));
					}
					splitObj.gameObject.SetActive(value: true);
					splitObj.particleSystem.Play();
					collider.enabled = false;
				}
			}
			else if (!(fstTime <= 0f) && !collider.enabled)
			{
				rapidTime -= deltaTime;
				if (!(rapidTime > 0f))
				{
					collider.enabled = true;
					rapidTime = fstTime;
				}
			}
			velocity = WallCollide(vector, velocity);
			transform.position = vector;
			transform.rotation = quaternion;
		}
		else
		{
			int num3 = 0;
			int length2 = splintObjs.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < length2)
			{
				int index2 = num3;
				num3++;
				Transform[] array4 = splintObjs;
				vector = array4[RuntimeServices.NormalizeArrayIndex(array4, index2)].position;
				Transform[] array5 = splintObjs;
				quaternion = array5[RuntimeServices.NormalizeArrayIndex(array5, index2)].rotation;
				Vector3 vector3 = vector;
				Vector3[] array6 = splintVels;
				vector = vector3 + array6[RuntimeServices.NormalizeArrayIndex(array6, index2)] * deltaTime;
				Vector3[] array7 = splintVels;
				ref Vector3 reference3 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, index2)];
				Vector3[] array8 = splintVels;
				reference3.y = array8[RuntimeServices.NormalizeArrayIndex(array8, index2)].y - gravity;
				Vector3[] array9 = splintRots;
				quaternion = Quaternion.Euler(array9[RuntimeServices.NormalizeArrayIndex(array9, index2)] * deltaTime) * quaternion;
				object[] groundHeight2 = GetGroundHeight(transform.position);
				object value = groundHeight2[0];
				num = RuntimeServices.UnboxSingle(groundHeight2[1]);
				vector2 = (Vector3)groundHeight2[2];
				if (RuntimeServices.ToBool(value) && !(vector.y > num + scale * 0.5f))
				{
					vector.y = num + scale * 0.51f;
					Vector3[] array10 = splintVels;
					if (!(array10[RuntimeServices.NormalizeArrayIndex(array10, index2)].y >= -4f))
					{
						Vector3[] array11 = splintVels;
						ref Vector3 reference4 = ref array11[RuntimeServices.NormalizeArrayIndex(array11, index2)];
						Vector3[] array12 = splintVels;
						reference4.y = array12[RuntimeServices.NormalizeArrayIndex(array12, index2)].y * (0f - boundRate);
						Vector3[] array13 = splintVels;
						ref Vector3 reference5 = ref array13[RuntimeServices.NormalizeArrayIndex(array13, index2)];
						Vector3[] array14 = splintVels;
						reference5.x = array14[RuntimeServices.NormalizeArrayIndex(array14, index2)].x * UnityEngine.Random.Range(-0.5f, 2f);
						Vector3[] array15 = splintVels;
						ref Vector3 reference6 = ref array15[RuntimeServices.NormalizeArrayIndex(array15, index2)];
						Vector3[] array16 = splintVels;
						reference6.z = array16[RuntimeServices.NormalizeArrayIndex(array16, index2)].z * UnityEngine.Random.Range(-0.5f, 2f);
						Vector3[] array17 = splintVels;
						ref Vector3 reference7 = ref array17[RuntimeServices.NormalizeArrayIndex(array17, index2)];
						Vector3[] array18 = splintVels;
						reference7.x = array18[RuntimeServices.NormalizeArrayIndex(array18, index2)].x + vector2.x;
						Vector3[] array19 = splintVels;
						ref Vector3 reference8 = ref array19[RuntimeServices.NormalizeArrayIndex(array19, index2)];
						Vector3[] array20 = splintVels;
						reference8.z = array20[RuntimeServices.NormalizeArrayIndex(array20, index2)].z + vector2.z;
						Vector3[] array21 = splintRots;
						ref Vector3 reference9 = ref array21[RuntimeServices.NormalizeArrayIndex(array21, index2)];
						Vector3[] array22 = splintRots;
						reference9 = array22[RuntimeServices.NormalizeArrayIndex(array22, index2)] * -0.5f;
						Vector3[] array23 = splintRots;
						ref Vector3 reference10 = ref array23[RuntimeServices.NormalizeArrayIndex(array23, index2)];
						Vector3[] array24 = splintRots;
						Vector3 vector4 = array24[RuntimeServices.NormalizeArrayIndex(array24, index2)];
						Vector3[] array25 = splintVels;
						float x = array25[RuntimeServices.NormalizeArrayIndex(array25, index2)].z * 100f;
						float y = 0f;
						Vector3[] array26 = splintVels;
						reference10 = vector4 + new Vector3(x, y, array26[RuntimeServices.NormalizeArrayIndex(array26, index2)].x * 100f);
					}
					else
					{
						Vector3[] array27 = splintVels;
						ref Vector3 reference11 = ref array27[RuntimeServices.NormalizeArrayIndex(array27, index2)];
						reference11 = Vector3.zero;
						Vector3[] array28 = splintRots;
						ref Vector3 reference12 = ref array28[RuntimeServices.NormalizeArrayIndex(array28, index2)];
						reference12 = Vector3.zero;
					}
				}
				Vector3[] array29 = splintVels;
				ref Vector3 reference13 = ref array29[RuntimeServices.NormalizeArrayIndex(array29, index2)];
				Vector3 pos = vector;
				Vector3[] array30 = splintVels;
				reference13 = WallCollide(pos, array30[RuntimeServices.NormalizeArrayIndex(array30, index2)]);
				Transform[] array31 = splintObjs;
				array31[RuntimeServices.NormalizeArrayIndex(array31, index2)].position = vector;
				Transform[] array32 = splintObjs;
				array32[RuntimeServices.NormalizeArrayIndex(array32, index2)].rotation = quaternion;
			}
		}
		life -= deltaTime;
		if ((bool)Ef_SmokeColorData.current && colorData.lightTable != null)
		{
			mat.color = colorData.lightTable.CheckColor(transform.position) / 2f;
		}
		if (!(life > 1f))
		{
			float a = life;
			Color color = mat.color;
			float num4 = (color.a = a);
			Color color3 = (mat.color = color);
		}
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public Vector3 WallCollide(Vector3 pos, Vector3 vec)
	{
		RaycastHit hitInfo = default(RaycastHit);
		Rigidbody rigidbody = null;
		bool flag = default(bool);
		if ((vec.x >= 0f) ? Physics.Raycast(pos, Vector3.right, out hitInfo, 2f, -1) : Physics.Raycast(pos, Vector3.left, out hitInfo, 2f, -1))
		{
			vec.x *= 0f - boundRate;
		}
		if ((vec.z <= 0f) ? Physics.Raycast(pos, Vector3.back, out hitInfo, 2f, -1) : Physics.Raycast(pos, Vector3.forward, out hitInfo, 2f, -1))
		{
			vec.z *= 0f - boundRate;
		}
		return vec;
	}

	public void OnCollisionStay()
	{
		collider.enabled = false;
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
