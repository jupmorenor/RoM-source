using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ParticleEmit : Ef_Base
{
	public float delay;

	public Color color;

	public float lifeTime;

	public float lifeTime2;

	public float speed;

	public float speed2;

	public Vector3[] positions;

	public Vector3 velocity;

	public float particleSize;

	public float[] particleSizes;

	public Color32[] colors;

	public Vector3[] vecs;

	public float[] emitTimes;

	public bool rotationVec;

	public bool world;

	public float loopTime;

	public int loopNum;

	public bool destroy;

	public bool pause;

	private float life;

	private bool useTimer;

	private bool useColor;

	private bool usePos;

	private bool useSize;

	private float timer;

	private int emitPt;

	private bool emitEnd;

	private bool end;

	private int leng;

	private int loopCount;

	public Ef_ParticleEmit()
	{
		color = Color.white;
		lifeTime = 1f;
		speed = 1f;
		positions = new Vector3[0];
		velocity = Vector3.zero;
		particleSize = 0.1f;
		particleSizes = new float[0];
		colors = new Color32[0];
		vecs = new Vector3[0];
		emitTimes = new float[0];
		world = true;
		destroy = true;
	}

	public void Start()
	{
		if (!particleSystem)
		{
			gameObject.AddComponent<ParticleSystem>();
		}
		life = Mathf.Max(lifeTime, lifeTime2);
		leng = vecs.Length;
		useTimer = emitTimes.Length == leng;
		useSize = particleSizes.Length == leng;
		useColor = colors.Length == leng;
		usePos = positions.Length == leng;
	}

	public void Update()
	{
		if (pause)
		{
			return;
		}
		if (end)
		{
			if (!destroy)
			{
				return;
			}
			life -= deltaTime;
			if (life > 0f)
			{
				return;
			}
			Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
			if (component != null)
			{
				component.Release();
			}
			else
			{
				Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
				if (component2 != null)
				{
					component2.Release();
				}
			}
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		EmitTimer();
		if (!emitEnd)
		{
			return;
		}
		checked
		{
			if (!(loopTime <= 0f))
			{
				if (loopNum > 0)
				{
					loopCount++;
					if (loopCount >= loopNum)
					{
						end = true;
						return;
					}
				}
				delay = loopTime;
				timer = 0f;
				emitPt = 0;
				emitEnd = false;
			}
			else
			{
				end = true;
			}
		}
	}

	public void EmitTimer()
	{
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		if (useTimer)
		{
			timer += deltaTime;
			int num = emitPt;
			int num2 = leng;
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int num4 = num;
				num += num3;
				float[] array = emitTimes;
				if (!(array[RuntimeServices.NormalizeArrayIndex(array, num4)] > timer))
				{
					Emit(num4, position, rotation);
					if (num4 == checked(leng - 1))
					{
						emitPt = num4;
						emitEnd = true;
						break;
					}
					continue;
				}
				emitPt = num4;
				break;
			}
		}
		else
		{
			int num5 = 0;
			int num6 = leng;
			if (num6 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num5 < num6)
			{
				int pt = num5;
				num5++;
				Emit(pt, position, rotation);
			}
			emitEnd = true;
		}
	}

	public void Emit(int pt, Vector3 pos, Quaternion rot)
	{
		float num = lifeTime;
		if (lifeTime2 != 0f)
		{
			num = UnityEngine.Random.Range(num, lifeTime2);
		}
		float num2 = speed;
		if (speed2 != 0f)
		{
			num2 = UnityEngine.Random.Range(speed, speed2);
		}
		Vector3[] array = vecs;
		Vector3 vector = array[RuntimeServices.NormalizeArrayIndex(array, pt)] * num2 + velocity;
		if (world && rotationVec)
		{
			vector = rot * vector;
		}
		float num3 = default(float);
		if (useSize)
		{
			float[] array2 = particleSizes;
			num3 = array2[RuntimeServices.NormalizeArrayIndex(array2, pt)] * particleSize;
		}
		else
		{
			num3 = particleSize;
		}
		Color color = default(Color);
		if (useColor)
		{
			Color32[] array3 = colors;
			color = array3[RuntimeServices.NormalizeArrayIndex(array3, pt)] * this.color;
		}
		else
		{
			color = this.color;
		}
		Vector3 vector2 = default(Vector3);
		if (world)
		{
			if (usePos)
			{
				if (rotationVec)
				{
					Vector3[] array4 = positions;
					vector2 = pos + rot * array4[RuntimeServices.NormalizeArrayIndex(array4, pt)];
				}
				else
				{
					Vector3[] array5 = positions;
					vector2 = pos + array5[RuntimeServices.NormalizeArrayIndex(array5, pt)];
				}
			}
			else
			{
				vector2 = pos;
			}
		}
		else if (usePos)
		{
			Vector3[] array6 = positions;
			vector2 = array6[RuntimeServices.NormalizeArrayIndex(array6, pt)];
		}
		else
		{
			vector2 = Vector3.zero;
		}
		particleSystem.Emit(vector2, vector, num3, num, color);
	}

	public void Play()
	{
		pause = false;
	}

	public void Stop()
	{
		pause = true;
	}
}
