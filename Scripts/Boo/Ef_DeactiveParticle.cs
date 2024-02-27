using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DeactiveParticle : Ef_Base
{
	public bool sleep;

	public GameObject[] particleObjs;

	public float life;

	public float fadeTime;

	public Transform releaseParent;

	public bool clearOnPlay;

	private float fstLife;

	private ParticleSystem[] particles;

	private int leng;

	private float[] fstRates;

	private bool[] fstLoops;

	private Vector3[] fstPoss;

	private Quaternion[] fstRots;

	private bool ready;

	private bool isFading;

	public Ef_DeactiveParticle()
	{
		particleObjs = new GameObject[0];
		life = 1f;
	}

	public void SetLife(float inLife)
	{
		life = inLife;
		fstLife = inLife;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		EndAndNext();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Initialize()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		fstLife = life;
		if (fadeTime == 0f)
		{
			fadeTime = life;
		}
		leng = particleObjs.Length;
		if (leng == 0)
		{
			particleObjs = new GameObject[1];
			particleObjs[0] = gameObject;
			leng = 1;
		}
		particles = new ParticleSystem[leng];
		fstRates = new float[leng];
		fstLoops = new bool[leng];
		if ((bool)releaseParent)
		{
			fstPoss = new Vector3[leng];
			fstRots = new Quaternion[leng];
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = particleObjs;
				if (!array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					continue;
				}
				ParticleSystem[] array2 = particles;
				int num2 = RuntimeServices.NormalizeArrayIndex(array2, num);
				GameObject[] array3 = particleObjs;
				array2[num2] = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].particleSystem;
				ParticleSystem[] array4 = particles;
				if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
				{
					float[] array5 = fstRates;
					int num3 = RuntimeServices.NormalizeArrayIndex(array5, num);
					ParticleSystem[] array6 = particles;
					array5[num3] = array6[RuntimeServices.NormalizeArrayIndex(array6, num)].emissionRate;
					bool[] array7 = fstLoops;
					ref bool reference = ref array7[RuntimeServices.NormalizeArrayIndex(array7, num)];
					ParticleSystem[] array8 = particles;
					reference = array8[RuntimeServices.NormalizeArrayIndex(array8, num)].loop;
					ParticleSystem[] array9 = particles;
					if (array9[RuntimeServices.NormalizeArrayIndex(array9, num)].simulationSpace == ParticleSystemSimulationSpace.Local)
					{
						clearOnPlay = true;
					}
					if ((bool)releaseParent)
					{
						GameObject[] array10 = particleObjs;
						Transform transform = array10[RuntimeServices.NormalizeArrayIndex(array10, num)].transform;
						Vector3[] array11 = fstPoss;
						ref Vector3 reference2 = ref array11[RuntimeServices.NormalizeArrayIndex(array11, num)];
						reference2 = transform.localPosition;
						Quaternion[] array12 = fstRots;
						ref Quaternion reference3 = ref array12[RuntimeServices.NormalizeArrayIndex(array12, num)];
						reference3 = transform.localRotation;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		ready = true;
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		if (sleep)
		{
			return;
		}
		int num = default(int);
		if (!(life <= 0f))
		{
			if (!isFading && !(life >= fadeTime))
			{
				IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						ParticleSystem[] array = particles;
						if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
						{
							ParticleSystem[] array2 = particles;
							array2[RuntimeServices.NormalizeArrayIndex(array2, num)].emissionRate = 0f;
							ParticleSystem[] array3 = particles;
							array3[RuntimeServices.NormalizeArrayIndex(array3, num)].loop = false;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				isFading = true;
			}
		}
		else
		{
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			EndAndNext();
			if (!releaseParent)
			{
				gameObject.SetActive(value: false);
			}
		}
		life -= deltaTime;
	}

	public void EndAndNext()
	{
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
			ParticleSystem[] array = particles;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				ParticleSystem[] array2 = particles;
				ParticleSystem obj = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				float[] array3 = fstRates;
				obj.emissionRate = array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				ParticleSystem[] array4 = particles;
				ParticleSystem obj2 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
				bool[] array5 = fstLoops;
				obj2.loop = array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
				if (clearOnPlay)
				{
					ParticleSystem[] array6 = particles;
					array6[RuntimeServices.NormalizeArrayIndex(array6, index)].Clear();
				}
				ParticleSystem[] array7 = particles;
				array7[RuntimeServices.NormalizeArrayIndex(array7, index)].Play();
			}
			if ((bool)releaseParent)
			{
				GameObject[] array8 = particleObjs;
				if ((bool)array8[RuntimeServices.NormalizeArrayIndex(array8, index)])
				{
					GameObject[] array9 = particleObjs;
					Transform transform = array9[RuntimeServices.NormalizeArrayIndex(array9, index)].transform;
					transform.parent = releaseParent;
					Vector3[] array10 = fstPoss;
					transform.localPosition = array10[RuntimeServices.NormalizeArrayIndex(array10, index)];
					Quaternion[] array11 = fstRots;
					transform.localRotation = array11[RuntimeServices.NormalizeArrayIndex(array11, index)];
				}
			}
		}
		if ((bool)releaseParent)
		{
			sleep = true;
		}
		isFading = false;
		life = fstLife;
	}
}
