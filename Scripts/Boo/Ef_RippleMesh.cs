using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_RippleMesh : MonoBehaviour
{
	public Mesh mesh;

	public int mapWidth;

	public int mapHeight;

	public float waterAccel;

	public float waterBrake;

	public float maxSpd;

	public bool useHeightBuffer;

	public float fstGroundHeight;

	public float fstWaterHeight;

	public float fluidity;

	public Color32 waterColor;

	public bool slopeColor;

	public Color32 slopeColorXp;

	public Color32 slopeColorXm;

	public Color32 slopeColorZp;

	public Color32 slopeColorZm;

	public bool calculateNormal;

	public float sideAlpha;

	public float depthAlpha;

	public float oneCellSize;

	public Material material;

	public bool quickCollision;

	public float contactPow;

	public float contactPow2;

	public float contactRadius;

	public bool movePosition;

	public GameObject splashParticle;

	private int vertNum;

	private int mapWidthp;

	private int mapHeightp;

	private float oneCellSizeHalf;

	private int mapPtX;

	private int mapPtZ;

	private float[] arrGroundHeight;

	private float[] arrWaterHeight;

	private float[] arrWaterHeightAdd;

	private float[] arrRippleHeight;

	private float[] arrRippleSpd;

	private Vector3[] verts;

	private Vector2[] uvs;

	private bool changeUV;

	private Color32[] colors;

	private int[] tris;

	private bool useFlow;

	private bool useSideAlpha;

	private bool useDepth;

	private float ofsHeight;

	private Vector3 lstPos;

	private int lstCellX;

	private int lstCellZ;

	private float sideAlpLMin;

	private float sideAlpLMax;

	private float sideAlpRMin;

	private float sideAlpRMax;

	private float sideAlpBMin;

	private float sideAlpBMax;

	private float sideAlpFMin;

	private float sideAlpFMax;

	private float particleTimer;

	public int maxCandidatesNum;

	public Transform[] candidates;

	private Vector3[] lstPoss;

	private bool ready;

	private Ef_HeightBuffer hBuf;

	public Ef_RippleMesh()
	{
		mapWidth = 12;
		mapHeight = 12;
		waterAccel = 20f;
		waterBrake = 10f;
		maxSpd = 10f;
		useHeightBuffer = true;
		fstWaterHeight = 1f;
		waterColor = Color.white;
		slopeColorXp = Color.white;
		slopeColorXm = Color.white;
		slopeColorZp = Color.white;
		slopeColorZm = Color.white;
		sideAlpha = 2f;
		depthAlpha = 1f;
		oneCellSize = 1f;
		quickCollision = true;
		contactPow = 1f;
		contactPow2 = -1f;
		contactRadius = 1f;
		oneCellSizeHalf = 0.5f;
		maxCandidatesNum = 10;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		ResetData();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		ResetData();
	}

	public void Update()
	{
		UpdateMesh();
		if (quickCollision)
		{
			QuickCollision();
		}
	}

	public void OnCollsionEnter(Collision coli)
	{
		if (contactPow != 0f || contactPow2 != 0f)
		{
			ContactPoint[] contacts = coli.contacts;
			if (contacts.Length > 0)
			{
				ContactWater(contacts[0].point);
			}
		}
	}

	public void OnCollsionStay(Collision coli)
	{
		if (contactPow != 0f || contactPow2 != 0f)
		{
			ContactPoint[] contacts = coli.contacts;
			if (contacts.Length > 0)
			{
				ContactWater(contacts[0].point);
			}
		}
	}

	public void OnTriggerEnter(Collider coli)
	{
		ContactWater(coli.transform.position);
	}

	public void OnTriggerStay(Collider coli)
	{
		ContactWater(coli.transform.position);
	}

	public void ContactWater(Transform trans)
	{
		ContactWater(trans, trans.position);
	}

	public void ContactWater(Transform trans, Vector3 hitPos)
	{
		if (!ready || (contactPow == 0f && contactPow2 == 0f))
		{
			return;
		}
		Vector3 position = trans.position;
		bool flag = false;
		bool flag2 = false;
		int num = -1;
		int num2 = 0;
		int num3 = maxCandidatesNum;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			if (num == -1)
			{
				Transform[] array = candidates;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num4)] == null)
				{
					num = num4;
				}
			}
			Transform[] array2 = candidates;
			if (trans == array2[RuntimeServices.NormalizeArrayIndex(array2, num4)])
			{
				flag = true;
				Vector3[] array3 = lstPoss;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num4)] == position)
				{
					flag2 = true;
					break;
				}
				Vector3[] array4 = lstPoss;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num4)] = position;
				break;
			}
		}
		if (!flag2)
		{
			if (!flag && num != -1)
			{
				Transform[] array5 = candidates;
				array5[RuntimeServices.NormalizeArrayIndex(array5, num)] = trans;
				Vector3[] array6 = lstPoss;
				array6[RuntimeServices.NormalizeArrayIndex(array6, num)] = position;
			}
			ContactWater(hitPos);
		}
	}

	public void ContactWater(Vector3 hitPos)
	{
		if (!ready || (contactPow == 0f && contactPow2 == 0f))
		{
			return;
		}
		Vector3 position = transform.position;
		Vector3 vector = hitPos - position;
		Quaternion rotation = transform.rotation;
		if (rotation != Quaternion.identity)
		{
			vector = Quaternion.Inverse(rotation) * vector;
		}
		if (oneCellSize != 1f)
		{
			vector /= oneCellSize;
		}
		int num = Mathf.FloorToInt(vector.x + 0.5f);
		int num2 = Mathf.FloorToInt(vector.z + 0.5f);
		if (num < 0 || num >= mapWidth || num2 < 0 || num2 >= mapHeight)
		{
			return;
		}
		checked
		{
			int num3 = mapPtX + num;
			int num4 = mapPtZ + num2;
			if (num3 >= mapWidthp)
			{
				num3 = unchecked(num3 % mapWidthp);
			}
			else if (num3 < 0)
			{
				num3 += mapWidthp;
			}
			if (num4 >= mapHeightp)
			{
				num4 = unchecked(num4 % mapHeightp);
			}
			else if (num4 < 0)
			{
				num4 += mapHeightp;
			}
			int index = num4 * mapWidthp + num3;
			float[] array = arrRippleHeight;
			float num5 = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (!movePosition)
			{
				num5 += position.y;
			}
			if (!(Mathf.Abs(hitPos.y - num5) <= contactRadius))
			{
				return;
			}
			float[] array2 = arrRippleSpd;
			int num6 = RuntimeServices.NormalizeArrayIndex(array2, index);
			float[] array3 = arrRippleSpd;
			array2[num6] = array3[RuntimeServices.NormalizeArrayIndex(array3, index)] - UnityEngine.Random.Range(contactPow, contactPow2);
			if (!(splashParticle != null))
			{
				return;
			}
			ParticleSystem particleSystem = splashParticle.particleSystem;
			if (particleSystem != null)
			{
				if (!(particleTimer > 0f))
				{
					float[] array4 = arrRippleHeight;
					hitPos.y = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
					splashParticle.transform.position = hitPos;
					particleSystem.Play();
					particleTimer = 0.2f;
				}
				else
				{
					particleTimer -= Time.deltaTime;
				}
			}
		}
	}

	public void Init()
	{
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = gameObject.AddComponent<MeshFilter>();
		}
		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			meshRenderer = gameObject.AddComponent<MeshRenderer>();
		}
		if (material != null)
		{
			meshRenderer.material = material;
		}
		mesh = meshFilter.mesh;
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.name = "RippleMesh";
			meshFilter.mesh = mesh;
		}
		mesh.MarkDynamic();
		mesh.Clear();
		checked
		{
			mapWidthp = mapWidth + 1;
			mapHeightp = mapHeight + 1;
			vertNum = mapWidthp * mapHeightp;
			arrWaterHeight = new float[vertNum];
			arrWaterHeightAdd = new float[vertNum];
			arrRippleHeight = new float[vertNum];
			arrRippleSpd = new float[vertNum];
			verts = new Vector3[vertNum];
			uvs = new Vector2[vertNum];
			colors = new Color32[vertNum];
			tris = new int[mapWidth * mapHeight * 6];
			useFlow = fluidity > 0f;
			useSideAlpha = sideAlpha > 0f;
			useDepth = depthAlpha > 0f;
			ready = true;
		}
	}

	public void ResetData()
	{
		if (!ready)
		{
			return;
		}
		lstPos = transform.position;
		lstCellX = Mathf.FloorToInt(lstPos.x / oneCellSize);
		lstCellZ = Mathf.FloorToInt(lstPos.z / oneCellSize);
		ofsHeight = 0f - lstPos.y;
		mapPtX = Mathf.FloorToInt(lstCellX % mapWidthp);
		mapPtZ = Mathf.FloorToInt(lstCellZ % mapHeightp);
		float num10;
		float num11;
		int num12;
		int num13;
		checked
		{
			if (mapPtX < 0)
			{
				mapPtX += mapWidthp;
			}
			if (mapPtZ < 0)
			{
				mapPtZ += mapHeightp;
			}
			if (arrGroundHeight == null || arrGroundHeight.Length != vertNum)
			{
				arrGroundHeight = new float[vertNum];
				int num = mapPtZ;
				if (num >= mapHeightp)
				{
					num = unchecked(num % mapHeightp);
				}
				else if (num < 0)
				{
					num += mapHeightp;
				}
				int num2 = 0;
				int num3 = mapHeightp;
				if (num3 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < num3)
				{
					int num4 = num2;
					num2 = unchecked(num2 + 1);
					int num5 = mapPtX;
					if (num5 >= mapWidthp)
					{
						num5 = unchecked(num5 % mapWidthp);
					}
					else if (num5 < 0)
					{
						num5 += mapWidthp;
					}
					int num6 = 0;
					int num7 = mapWidthp;
					if (num7 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num6 < num7)
					{
						int num8 = num6;
						num6 = unchecked(num6 + 1);
						int num9 = num4 * mapWidthp + num8;
						int index = num * mapWidthp + num5;
						if (useHeightBuffer)
						{
							float[] array = arrGroundHeight;
							array[RuntimeServices.NormalizeArrayIndex(array, index)] = RuntimeServices.UnboxSingle(GetHeight(new Vector3((float)(lstCellX + num8) * oneCellSize, 0f, (float)(lstCellZ + num4) * oneCellSize)));
						}
						else
						{
							float[] array2 = arrGroundHeight;
							array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = fstGroundHeight;
						}
						num5++;
						if (num5 >= mapWidthp)
						{
							num5 -= mapWidthp;
						}
					}
					num++;
					if (num >= mapHeightp)
					{
						num -= mapHeightp;
					}
				}
			}
			num10 = lstPos.x - (float)lstCellX * oneCellSize;
			num11 = lstPos.z - (float)lstCellZ * oneCellSize;
			num12 = 0;
			num13 = mapHeightp;
			if (num13 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		while (num12 < num13)
		{
			int num14 = num12;
			num12++;
			int num15 = 0;
			int num16 = mapWidthp;
			if (num16 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num15 < num16)
			{
				int num17 = num15;
				num15++;
				checked
				{
					int num9 = num14 * mapWidthp + num17;
					if (movePosition)
					{
						float[] array3 = arrWaterHeight;
						array3[RuntimeServices.NormalizeArrayIndex(array3, num9)] = fstWaterHeight + lstPos.y;
					}
					else
					{
						float[] array4 = arrWaterHeight;
						array4[RuntimeServices.NormalizeArrayIndex(array4, num9)] = fstWaterHeight;
					}
					float[] array5 = arrWaterHeightAdd;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num9)] = 0f;
					float[] array6 = arrRippleHeight;
					int num18 = RuntimeServices.NormalizeArrayIndex(array6, num9);
					float[] array7 = arrWaterHeight;
					array6[num18] = array7[RuntimeServices.NormalizeArrayIndex(array7, num9)];
					float[] array8 = arrRippleSpd;
					array8[RuntimeServices.NormalizeArrayIndex(array8, num9)] = 0f;
					Vector3 zero = Vector3.zero;
					zero = ((!movePosition) ? new Vector3((float)num17 * oneCellSize, fstWaterHeight, (float)num14 * oneCellSize) : new Vector3((float)num17 * oneCellSize - num10, fstWaterHeight + ofsHeight, (float)num14 * oneCellSize - num11));
					Vector3[] array9 = verts;
					array9[RuntimeServices.NormalizeArrayIndex(array9, num9)] = zero;
					Vector2[] array10 = uvs;
					ref Vector2 reference = ref array10[RuntimeServices.NormalizeArrayIndex(array10, num9)];
					reference = new Vector2((float)(lstCellX + num17) * oneCellSize, (float)(lstCellZ + num14) * oneCellSize);
					Color32[] array11 = colors;
					ref Color32 reference2 = ref array11[RuntimeServices.NormalizeArrayIndex(array11, num9)];
					reference2 = waterColor;
				}
			}
		}
		int num19 = 0;
		int num20 = mapHeight;
		if (num20 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num19 < num20)
		{
			int num21 = num19;
			num19++;
			int num22 = 0;
			int num23 = mapWidth;
			if (num23 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num22 < num23)
			{
				int num24 = num22;
				num22++;
				checked
				{
					int num9 = (num21 * mapWidth + num24) * 6;
					int num25 = num21 * mapWidthp + num24;
					int num26 = num21 * mapWidthp + num24 + 1;
					int num27 = (num21 + 1) * mapWidthp + num24;
					int num28 = (num21 + 1) * mapWidthp + num24 + 1;
					int[] array12 = tris;
					array12[RuntimeServices.NormalizeArrayIndex(array12, num9 + 0)] = num27;
					int[] array13 = tris;
					array13[RuntimeServices.NormalizeArrayIndex(array13, num9 + 1)] = num28;
					int[] array14 = tris;
					array14[RuntimeServices.NormalizeArrayIndex(array14, num9 + 2)] = num25;
					int[] array15 = tris;
					array15[RuntimeServices.NormalizeArrayIndex(array15, num9 + 3)] = num25;
					int[] array16 = tris;
					array16[RuntimeServices.NormalizeArrayIndex(array16, num9 + 4)] = num28;
					int[] array17 = tris;
					array17[RuntimeServices.NormalizeArrayIndex(array17, num9 + 5)] = num26;
				}
			}
		}
		mesh.vertices = verts;
		mesh.triangles = tris;
		mesh.uv = uvs;
		mesh.colors32 = colors;
		sideAlpLMin = oneCellSizeHalf;
		sideAlpLMax = oneCellSizeHalf + sideAlpha;
		sideAlpBMin = oneCellSizeHalf;
		sideAlpBMax = oneCellSizeHalf + sideAlpha;
		checked
		{
			if (movePosition)
			{
				sideAlpRMin = (float)(mapWidth - 1) * oneCellSize - sideAlpha;
				sideAlpRMax = (float)(mapWidth - 1) * oneCellSize;
				sideAlpFMin = (float)(mapHeight - 1) * oneCellSize - sideAlpha;
				sideAlpFMax = (float)(mapHeight - 1) * oneCellSize;
			}
			else
			{
				sideAlpRMin = (float)mapWidth * oneCellSize - sideAlpha;
				sideAlpRMax = (float)mapWidth * oneCellSize;
				sideAlpFMin = (float)mapHeight * oneCellSize - sideAlpha;
				sideAlpFMax = (float)mapHeight * oneCellSize;
			}
			candidates = new Transform[maxCandidatesNum];
			lstPoss = new Vector3[maxCandidatesNum];
		}
	}

	public void UpdateMesh()
	{
		if (!ready)
		{
			return;
		}
		if (movePosition)
		{
			MovePosition();
		}
		Vector3 vector = default(Vector3);
		float deltaTime = Time.deltaTime;
		int num = default(int);
		int num2 = mapPtX;
		int num3 = mapPtZ;
		int index = 0;
		int index2 = 0;
		int index3 = 0;
		int index4 = 0;
		int num4 = 0;
		int num5 = mapHeightp;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int num6 = num4;
			num4++;
			int num7 = 0;
			int num8 = mapWidthp;
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			checked
			{
				while (num7 < num8)
				{
					int num9 = num7;
					num7 = unchecked(num7 + 1);
					int index5 = num6 * mapWidthp + num9;
					num = num3 * mapWidthp + num2;
					if (num9 > 0)
					{
						index = num2 - 1;
						if (index < 0)
						{
							index += mapWidthp;
						}
						index = num3 * mapWidthp + index;
					}
					if (num9 < mapWidth)
					{
						index2 = num2 + 1;
						if (index2 >= mapWidthp)
						{
							index2 -= mapWidthp;
						}
						index2 = num3 * mapWidthp + index2;
					}
					if (num6 > 0)
					{
						index4 = num3 - 1;
						if (index4 < 0)
						{
							index4 += mapHeightp;
						}
						index4 = index4 * mapWidthp + num2;
					}
					if (num6 < mapHeight)
					{
						index3 = num3 + 1;
						if (index3 >= mapHeightp)
						{
							index3 -= mapHeightp;
						}
						index3 = index3 * mapWidthp + num2;
					}
					float[] array = arrGroundHeight;
					float num10 = array[RuntimeServices.NormalizeArrayIndex(array, num)];
					float[] array2 = arrWaterHeight;
					float num11 = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					float[] array3 = arrRippleHeight;
					float num12 = array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
					float[] array4 = arrWaterHeight;
					float num13 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					if (num9 > 0)
					{
						float num14 = num13;
						float[] array5 = arrRippleHeight;
						num13 = num14 + array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
					}
					else
					{
						float num15 = num13;
						float[] array6 = arrRippleHeight;
						num13 = num15 + array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
					}
					if (num9 < mapWidth)
					{
						float num16 = num13;
						float[] array7 = arrRippleHeight;
						num13 = num16 + array7[RuntimeServices.NormalizeArrayIndex(array7, index2)];
					}
					else
					{
						float num17 = num13;
						float[] array8 = arrRippleHeight;
						num13 = num17 + array8[RuntimeServices.NormalizeArrayIndex(array8, index)];
					}
					if (num6 > 0)
					{
						float num18 = num13;
						float[] array9 = arrRippleHeight;
						num13 = num18 + array9[RuntimeServices.NormalizeArrayIndex(array9, index4)];
					}
					else
					{
						float num19 = num13;
						float[] array10 = arrRippleHeight;
						num13 = num19 + array10[RuntimeServices.NormalizeArrayIndex(array10, index3)];
					}
					if (num6 < mapHeight)
					{
						float num20 = num13;
						float[] array11 = arrRippleHeight;
						num13 = num20 + array11[RuntimeServices.NormalizeArrayIndex(array11, index3)];
					}
					else
					{
						float num21 = num13;
						float[] array12 = arrRippleHeight;
						num13 = num21 + array12[RuntimeServices.NormalizeArrayIndex(array12, index4)];
					}
					num13 /= 5f;
					if (!(Mathf.Abs(num13 - num11) > 0.001f))
					{
						float[] array13 = arrRippleSpd;
						if (Mathf.Abs(array13[RuntimeServices.NormalizeArrayIndex(array13, num)]) <= 0.001f)
						{
							num12 = num11;
							float[] array14 = arrRippleSpd;
							array14[RuntimeServices.NormalizeArrayIndex(array14, num)] = 0f;
							goto IL_03be;
						}
					}
					float num22 = num12;
					float[] array15 = arrRippleSpd;
					num12 = num22 + array15[RuntimeServices.NormalizeArrayIndex(array15, num)] * deltaTime;
					if (useFlow && !(num12 >= num10))
					{
						num12 = num10;
					}
					float num23 = num13 - num12;
					float[] array16 = arrRippleSpd;
					float num24 = array16[RuntimeServices.NormalizeArrayIndex(array16, num)];
					num24 += num23 * waterAccel * deltaTime;
					float num25 = 30f - waterBrake * deltaTime;
					if (!(num25 >= 0f))
					{
						num25 = 0f;
					}
					num24 *= num25 / 30f;
					if (!(num24 <= maxSpd))
					{
						num24 = maxSpd;
					}
					else if (!(num24 >= 0f - maxSpd))
					{
						num24 = 0f - maxSpd;
					}
					float[] array17 = arrRippleSpd;
					array17[RuntimeServices.NormalizeArrayIndex(array17, num)] = num24;
					goto IL_03be;
					IL_03be:
					Vector3[] array18 = verts;
					vector = array18[RuntimeServices.NormalizeArrayIndex(array18, index5)];
					if (movePosition)
					{
						vector.y = num12 + ofsHeight;
					}
					else
					{
						vector.y = num12;
					}
					Vector3[] array19 = verts;
					array19[RuntimeServices.NormalizeArrayIndex(array19, index5)] = vector;
					float num26 = 0f;
					float num27 = 0f;
					float num28 = 0f;
					float num29 = 0f;
					float num30 = 0f;
					float num31 = 0f;
					if (useFlow || slopeColor)
					{
						if (num9 < mapWidth)
						{
							float[] array20 = arrRippleHeight;
							num28 = array20[RuntimeServices.NormalizeArrayIndex(array20, index2)];
						}
						else
						{
							num28 = num12;
						}
						if (num9 > 0)
						{
							float[] array21 = arrRippleHeight;
							num29 = array21[RuntimeServices.NormalizeArrayIndex(array21, index)];
						}
						else
						{
							num29 = num12;
						}
						if (num6 < mapHeight)
						{
							float[] array22 = arrRippleHeight;
							num30 = array22[RuntimeServices.NormalizeArrayIndex(array22, index3)];
						}
						else
						{
							num30 = num12;
						}
						if (num6 > 0)
						{
							float[] array23 = arrRippleHeight;
							num31 = array23[RuntimeServices.NormalizeArrayIndex(array23, index4)];
						}
						else
						{
							num31 = num12;
						}
						num26 = num29 - num28;
						if (!(num26 <= 1f))
						{
							num26 = 1f;
						}
						else if (!(num26 >= -1f))
						{
							num26 = -1f;
						}
						num27 = num31 - num30;
						if (!(num27 <= 1f))
						{
							num27 = 1f;
						}
						else if (!(num27 >= -1f))
						{
							num27 = -1f;
						}
					}
					if (useFlow)
					{
						float num32 = num11 - num10;
						if (!(num32 <= 0f) && (num26 != 0f || num27 != 0f))
						{
							float num33 = Mathf.Abs(num26);
							float num34 = Mathf.Abs(num27);
							float num35 = (num33 + num34) / 2f * fluidity * deltaTime;
							if (!(num35 <= num32))
							{
								num35 = num32;
							}
							float num36 = 1f / (num33 + num34) * num33;
							float num37 = 1f - num36;
							float num38 = 0f;
							if (!(num26 <= 0f))
							{
								if (num2 < mapWidth)
								{
									float num39 = num36 * num35;
									float[] array24 = arrWaterHeightAdd;
									int num40 = RuntimeServices.NormalizeArrayIndex(array24, index2);
									float[] array25 = arrWaterHeightAdd;
									array24[num40] = array25[RuntimeServices.NormalizeArrayIndex(array25, index2)] + num39;
									num38 += num39;
								}
							}
							else if (num9 > 0)
							{
								float num41 = num36 * num35;
								float[] array26 = arrWaterHeightAdd;
								int num42 = RuntimeServices.NormalizeArrayIndex(array26, index);
								float[] array27 = arrWaterHeightAdd;
								array26[num42] = array27[RuntimeServices.NormalizeArrayIndex(array27, index)] + num41;
								num38 += num41;
							}
							if (!(num27 <= 0f))
							{
								if (num3 < mapHeight)
								{
									float num43 = num37 * num35;
									float[] array28 = arrWaterHeightAdd;
									int num44 = RuntimeServices.NormalizeArrayIndex(array28, index3);
									float[] array29 = arrWaterHeightAdd;
									array28[num44] = array29[RuntimeServices.NormalizeArrayIndex(array29, index3)] + num43;
									num38 += num43;
								}
							}
							else if (num6 > 0)
							{
								float num45 = num37 * num35;
								float[] array30 = arrWaterHeightAdd;
								int num46 = RuntimeServices.NormalizeArrayIndex(array30, index4);
								float[] array31 = arrWaterHeightAdd;
								array30[num46] = array31[RuntimeServices.NormalizeArrayIndex(array31, index4)] + num45;
								num38 += num45;
							}
							float[] array32 = arrWaterHeight;
							int num47 = RuntimeServices.NormalizeArrayIndex(array32, num);
							float[] array33 = arrWaterHeight;
							array32[num47] = array33[RuntimeServices.NormalizeArrayIndex(array33, num)] - num38;
						}
					}
					Color color = waterColor;
					if (slopeColor)
					{
						Color color2 = Color.Lerp(slopeColorXm, slopeColorXp, num26 / 2f + 0.5f);
						Color color3 = Color.Lerp(slopeColorZm, slopeColorZp, num27 / 2f + 0.5f);
						color = color * color2 * color3;
						if (!useDepth)
						{
							Color32[] array34 = colors;
							ref Color32 reference = ref array34[RuntimeServices.NormalizeArrayIndex(array34, index5)];
							reference = color;
						}
					}
					if (useSideAlpha)
					{
						Vector3[] array35 = verts;
						vector = array35[RuntimeServices.NormalizeArrayIndex(array35, index5)];
						float x = vector.x;
						float z = vector.z;
						float num48 = 1f;
						if (!(x >= sideAlpLMax))
						{
							num48 *= (x - sideAlpLMin) / sideAlpha;
							if (!(num48 >= 0f))
							{
								num48 = 0f;
							}
							else if (!(num48 <= 1f))
							{
								num48 = 1f;
							}
						}
						else if (!(x <= sideAlpRMin))
						{
							num48 *= (sideAlpRMax - x) / sideAlpha;
							if (!(num48 >= 0f))
							{
								num48 = 0f;
							}
							else if (!(num48 <= 1f))
							{
								num48 = 1f;
							}
						}
						if (!(z >= sideAlpBMax))
						{
							num48 *= (z - sideAlpBMin) / sideAlpha;
							if (!(num48 >= 0f))
							{
								num48 = 0f;
							}
							else if (!(num48 <= 1f))
							{
								num48 = 1f;
							}
						}
						else if (!(z <= sideAlpFMin))
						{
							num48 *= (sideAlpFMax - z) / sideAlpha;
							if (!(num48 >= 0f))
							{
								num48 = 0f;
							}
							else if (!(num48 <= 1f))
							{
								num48 = 1f;
							}
						}
						color.a *= num48;
						if (!useDepth)
						{
							Color32[] array36 = colors;
							ref Color32 reference2 = ref array36[RuntimeServices.NormalizeArrayIndex(array36, index5)];
							reference2 = color;
						}
					}
					if (useDepth)
					{
						float num49 = num12 - num10;
						float num50 = num49 / depthAlpha;
						if (!(num50 >= 0f))
						{
							num50 = 0f;
						}
						else if (!(num50 <= 1f))
						{
							num50 = 1f;
						}
						color.a *= num50;
						Color32[] array37 = colors;
						ref Color32 reference3 = ref array37[RuntimeServices.NormalizeArrayIndex(array37, index5)];
						reference3 = color;
					}
					float[] array38 = arrRippleHeight;
					array38[RuntimeServices.NormalizeArrayIndex(array38, num)] = num12;
					num2++;
					if (num2 >= mapWidthp)
					{
						num2 -= mapWidthp;
					}
				}
				num3++;
				if (num3 >= mapHeightp)
				{
					num3 -= mapHeightp;
				}
			}
		}
		if (useFlow)
		{
			IEnumerator<int> enumerator = Builtins.range(vertNum).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					int index5 = enumerator.Current;
					float[] array39 = arrWaterHeight;
					int num51 = RuntimeServices.NormalizeArrayIndex(array39, index5);
					float[] array40 = arrWaterHeight;
					float num52 = array40[RuntimeServices.NormalizeArrayIndex(array40, index5)];
					float[] array41 = arrWaterHeightAdd;
					array39[num51] = num52 + array41[RuntimeServices.NormalizeArrayIndex(array41, index5)];
					float[] array42 = arrWaterHeightAdd;
					array42[RuntimeServices.NormalizeArrayIndex(array42, index5)] = 0f;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		mesh.vertices = verts;
		if (changeUV)
		{
			mesh.uv = uvs;
			changeUV = false;
		}
		if (calculateNormal)
		{
			mesh.RecalculateNormals();
		}
		if (useDepth || slopeColor)
		{
			mesh.colors32 = colors;
		}
	}

	public void MovePosition()
	{
		Vector3 position = transform.position;
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		if (position == lstPos)
		{
			return;
		}
		int num4 = Mathf.FloorToInt(position.x / oneCellSize);
		int num5 = Mathf.FloorToInt(position.z / oneCellSize);
		float num6 = position.x - (float)num4 * oneCellSize;
		float num7 = position.z - (float)num5 * oneCellSize;
		float num8 = position.y - lstPos.y;
		lstPos = position;
		int num9 = 0;
		int num10 = mapHeightp;
		if (num10 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num9 < num10)
		{
			int num11 = num9;
			num9++;
			int num12 = 0;
			int num13 = mapWidthp;
			if (num13 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num12 < num13)
			{
				int num14 = num12;
				num12++;
				checked
				{
					int index = num11 * mapWidthp + num14;
					Vector3[] array = verts;
					Vector3 vector = array[RuntimeServices.NormalizeArrayIndex(array, index)];
					vector.x = (float)num14 * oneCellSize - num6;
					vector.z = (float)num11 * oneCellSize - num7;
					Vector3[] array2 = verts;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = vector;
					Vector2[] array3 = uvs;
					ref Vector2 reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
					reference = new Vector2((float)(num4 + num14) * oneCellSize, (float)(num5 + num11) * oneCellSize);
					float[] array4 = arrWaterHeight;
					int num15 = RuntimeServices.NormalizeArrayIndex(array4, index);
					float[] array5 = arrWaterHeight;
					array4[num15] = array5[RuntimeServices.NormalizeArrayIndex(array5, index)] + num8;
					float[] array6 = arrRippleHeight;
					int num16 = RuntimeServices.NormalizeArrayIndex(array6, index);
					float[] array7 = arrRippleHeight;
					array6[num16] = array7[RuntimeServices.NormalizeArrayIndex(array7, index)] + num8;
				}
			}
		}
		changeUV = true;
		ofsHeight = 0f - position.y;
		if (num4 == lstCellX && num5 == lstCellZ)
		{
			return;
		}
		checked
		{
			int num17 = Mathf.FloorToInt(num4 - lstCellX);
			int num18 = Mathf.FloorToInt(num5 - lstCellZ);
			lstCellX = num4;
			lstCellZ = num5;
			float num19 = fstWaterHeight + position.y;
			Vector3 vector2 = default(Vector3);
			if (num17 > 0)
			{
				num2 = mapPtX;
				if (num2 >= mapWidthp)
				{
					num2 = unchecked(num2 % mapWidthp);
				}
				else if (num2 < 0)
				{
					num2 += mapWidthp;
				}
				int num20 = 0;
				int num21 = num17;
				if (num21 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num20 < num21)
				{
					int num22 = num20;
					num20 = unchecked(num20 + 1);
					num3 = mapPtZ;
					if (num3 >= mapHeightp)
					{
						num3 = unchecked(num3 % mapHeightp);
					}
					else if (num3 < 0)
					{
						num3 += mapHeightp;
					}
					int num23 = 0;
					int num24 = mapHeightp;
					if (num24 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num23 < num24)
					{
						int num25 = num23;
						num23 = unchecked(num23 + 1);
						num = num3 * mapWidthp + num2;
						if (useHeightBuffer)
						{
							float[] array8 = arrGroundHeight;
							array8[RuntimeServices.NormalizeArrayIndex(array8, num)] = RuntimeServices.UnboxSingle(GetHeight(new Vector3((float)(num4 + mapWidthp - num17 + num22) * oneCellSize, 0f, (float)(num5 + num25) * oneCellSize)));
						}
						else
						{
							float[] array9 = arrGroundHeight;
							array9[RuntimeServices.NormalizeArrayIndex(array9, num)] = fstGroundHeight;
						}
						float[] array10 = arrWaterHeight;
						array10[RuntimeServices.NormalizeArrayIndex(array10, num)] = num19;
						float[] array11 = arrRippleHeight;
						array11[RuntimeServices.NormalizeArrayIndex(array11, num)] = num19;
						float[] array12 = arrRippleSpd;
						array12[RuntimeServices.NormalizeArrayIndex(array12, num)] = 0f;
						num3++;
						if (num3 >= mapHeightp)
						{
							num3 -= mapHeightp;
						}
					}
					num2++;
					if (num2 >= mapWidthp)
					{
						num2 -= mapWidthp;
					}
				}
				mapPtX += num17;
			}
			else if (num17 < 0)
			{
				num2 = mapPtX + num17;
				if (num2 >= mapWidthp)
				{
					num2 = unchecked(num2 % mapWidthp);
				}
				else if (num2 < 0)
				{
					num2 += mapWidthp;
				}
				int num26 = 0;
				int num27 = -num17;
				if (num27 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num26 < num27)
				{
					int num28 = num26;
					num26 = unchecked(num26 + 1);
					num3 = mapPtZ;
					if (num3 >= mapHeightp)
					{
						num3 = unchecked(num3 % mapHeightp);
					}
					else if (num3 < 0)
					{
						num3 += mapHeightp;
					}
					int num29 = 0;
					int num30 = mapHeightp;
					if (num30 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num29 < num30)
					{
						int num31 = num29;
						num29 = unchecked(num29 + 1);
						num = num3 * mapWidthp + num2;
						if (useHeightBuffer)
						{
							float[] array13 = arrGroundHeight;
							array13[RuntimeServices.NormalizeArrayIndex(array13, num)] = RuntimeServices.UnboxSingle(GetHeight(new Vector3((float)(num4 + num28) * oneCellSize, 0f, (float)(num5 + num31) * oneCellSize)));
						}
						else
						{
							float[] array14 = arrGroundHeight;
							array14[RuntimeServices.NormalizeArrayIndex(array14, num)] = fstGroundHeight;
						}
						float[] array15 = arrWaterHeight;
						array15[RuntimeServices.NormalizeArrayIndex(array15, num)] = num19;
						float[] array16 = arrRippleHeight;
						array16[RuntimeServices.NormalizeArrayIndex(array16, num)] = num19;
						float[] array17 = arrRippleSpd;
						array17[RuntimeServices.NormalizeArrayIndex(array17, num)] = 0f;
						num3++;
						if (num3 >= mapHeightp)
						{
							num3 -= mapHeightp;
						}
					}
					num2++;
					if (num2 >= mapWidthp)
					{
						num2 -= mapWidthp;
					}
				}
				mapPtX += num17;
			}
			if (num18 > 0)
			{
				num3 = mapPtZ;
				if (num3 >= mapHeightp)
				{
					num3 = unchecked(num3 % mapHeightp);
				}
				else if (num3 < 0)
				{
					num3 += mapHeightp;
				}
				int num32 = 0;
				int num33 = num18;
				if (num33 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num32 < num33)
				{
					int num34 = num32;
					num32 = unchecked(num32 + 1);
					num2 = mapPtX;
					if (num2 >= mapWidthp)
					{
						num2 = unchecked(num2 % mapWidthp);
					}
					else if (num2 < 0)
					{
						num2 += mapWidthp;
					}
					int num35 = 0;
					int num36 = mapWidthp;
					if (num36 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num35 < num36)
					{
						int num37 = num35;
						num35 = unchecked(num35 + 1);
						num = num3 * mapWidthp + num2;
						if (useHeightBuffer)
						{
							float[] array18 = arrGroundHeight;
							array18[RuntimeServices.NormalizeArrayIndex(array18, num)] = RuntimeServices.UnboxSingle(GetHeight(new Vector3((float)(num4 + num37) * oneCellSize, 0f, (float)(num5 + mapHeightp - num18 + num34) * oneCellSize)));
						}
						else
						{
							float[] array19 = arrGroundHeight;
							array19[RuntimeServices.NormalizeArrayIndex(array19, num)] = fstGroundHeight;
						}
						float[] array20 = arrWaterHeight;
						array20[RuntimeServices.NormalizeArrayIndex(array20, num)] = num19;
						float[] array21 = arrRippleHeight;
						array21[RuntimeServices.NormalizeArrayIndex(array21, num)] = num19;
						float[] array22 = arrRippleSpd;
						array22[RuntimeServices.NormalizeArrayIndex(array22, num)] = 0f;
						num2++;
						if (num2 >= mapWidthp)
						{
							num2 -= mapWidthp;
						}
					}
					num3++;
					if (num3 >= mapHeightp)
					{
						num3 -= mapHeightp;
					}
				}
			}
			else if (num18 < 0)
			{
				num3 = mapPtZ + num18;
				if (num3 >= mapHeightp)
				{
					num3 = unchecked(num3 % mapHeightp);
				}
				else if (num3 < 0)
				{
					num3 += mapHeightp;
				}
				int num38 = 0;
				int num39 = -num18;
				if (num39 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num38 < num39)
				{
					int num40 = num38;
					num38 = unchecked(num38 + 1);
					num2 = mapPtX;
					if (num2 >= mapWidthp)
					{
						num2 = unchecked(num2 % mapWidthp);
					}
					else if (num2 < 0)
					{
						num2 += mapWidthp;
					}
					int num41 = 0;
					int num42 = mapWidthp;
					if (num42 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num41 < num42)
					{
						int num43 = num41;
						num41 = unchecked(num41 + 1);
						num = num3 * mapWidthp + num2;
						if (useHeightBuffer)
						{
							float[] array23 = arrGroundHeight;
							array23[RuntimeServices.NormalizeArrayIndex(array23, num)] = RuntimeServices.UnboxSingle(GetHeight(new Vector3((float)(num4 + num43) * oneCellSize, 0f, (float)(num5 + num40) * oneCellSize)));
						}
						else
						{
							float[] array24 = arrGroundHeight;
							array24[RuntimeServices.NormalizeArrayIndex(array24, num)] = fstGroundHeight;
						}
						float[] array25 = arrWaterHeight;
						array25[RuntimeServices.NormalizeArrayIndex(array25, num)] = num19;
						float[] array26 = arrRippleHeight;
						array26[RuntimeServices.NormalizeArrayIndex(array26, num)] = num19;
						float[] array27 = arrRippleSpd;
						array27[RuntimeServices.NormalizeArrayIndex(array27, num)] = 0f;
						num2++;
						if (num2 >= mapWidthp)
						{
							num2 -= mapWidthp;
						}
					}
					num3++;
					if (num3 >= mapHeightp)
					{
						num3 -= mapHeightp;
					}
				}
			}
		}
		mapPtX = Mathf.FloorToInt(num4 % mapWidthp);
		mapPtZ = Mathf.FloorToInt(num5 % mapHeightp);
		checked
		{
			if (mapPtX < 0)
			{
				mapPtX += mapWidthp;
			}
			if (mapPtZ < 0)
			{
				mapPtZ += mapHeightp;
			}
		}
	}

	public void QuickCollision()
	{
		Vector3 position = this.transform.position;
		float x = position.x;
		float num = position.x + (float)mapWidth * oneCellSize;
		float num2 = position.z + (float)mapHeight * oneCellSize;
		float z = position.z;
		BaseControl[] allControls = BaseControl.AllControls;
		int i = 0;
		BaseControl[] array = allControls;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				Transform transform = array[i].transform;
				Vector3 position2 = transform.position;
				if (!(position2.x < x) && !(position2.x > num) && !(position2.z < z) && position2.z <= num2)
				{
					ContactWater(transform);
				}
			}
		}
	}

	public object GetHeight(Vector3 pos)
	{
		object result;
		if (hBuf == null)
		{
			hBuf = Ef_HeightBuffer.Current;
			if (hBuf == null)
			{
				useHeightBuffer = false;
				result = 0f;
				goto IL_0063;
			}
		}
		object[] height = hBuf.GetHeight(pos);
		object obj = height[0];
		object lhs = height[1];
		RuntimeServices.EqualityOperator(lhs, 0);
		result = obj;
		goto IL_0063;
		IL_0063:
		return result;
	}
}
