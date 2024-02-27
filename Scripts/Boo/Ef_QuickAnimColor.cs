using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimColor : Ef_Base
{
	public float maxDelta;

	public float life;

	public float delay;

	public bool pause;

	public GameObject[] meshObjs;

	public Gradient colorAnim;

	public bool loop;

	public float loopTime;

	public int loopCount;

	public bool firstColor;

	public bool waitAnimation;

	public bool linkQuickAnim;

	public bool play;

	public Color color;

	private Color[] fstColors;

	private float fstLife;

	private float fstDelay;

	private int fstLoop;

	private bool useLoopCount;

	private int leng;

	private Material[] mats;

	private bool ready;

	private Ef_QuickAnimTransCurve qar;

	private Ef_QuickAnimTransform qat;

	private Ef_QuickAnimTexture qax;

	private Ef_QuickAnimMatFloat qaf;

	public Ef_QuickAnimColor()
	{
		maxDelta = 0.05f;
		life = 1f;
		firstColor = true;
		waitAnimation = true;
		linkQuickAnim = true;
		color = Color.white;
		mats = new Material[0];
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		if (!pause)
		{
			Play();
		}
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		fstLife = life;
		fstDelay = delay;
		fstLoop = loopCount;
		useLoopCount = loopCount >= 1;
		if (loopTime == 0f && loop)
		{
			loopTime = life;
		}
		int num = meshObjs.Length;
		if (num == 0 && gameObject.renderer != null)
		{
			meshObjs = new GameObject[1];
			meshObjs[0] = gameObject;
			num = 1;
		}
		leng = 0;
		int num2 = 0;
		int num3 = default(int);
		IEnumerator<int> enumerator = Builtins.range(num).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num3 = enumerator.Current;
					GameObject[] array = meshObjs;
					if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num3)])
					{
						GameObject[] array2 = meshObjs;
						if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num3)].renderer)
						{
							int num4 = leng;
							GameObject[] array3 = meshObjs;
							leng = num4 + array3[RuntimeServices.NormalizeArrayIndex(array3, num3)].renderer.materials.Length;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			mats = new Material[leng];
			IEnumerator<int> enumerator2 = Builtins.range(num).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num3 = enumerator2.Current;
					GameObject[] array4 = meshObjs;
					if (array4[RuntimeServices.NormalizeArrayIndex(array4, num3)] == null)
					{
						continue;
					}
					GameObject[] array5 = meshObjs;
					if (array5[RuntimeServices.NormalizeArrayIndex(array5, num3)].renderer == null)
					{
						continue;
					}
					GameObject[] array6 = meshObjs;
					Material[] materials = array6[RuntimeServices.NormalizeArrayIndex(array6, num3)].renderer.materials;
					int num5 = default(int);
					IEnumerator<int> enumerator3 = Builtins.range(materials.Length).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							num5 = enumerator3.Current;
							if (materials[RuntimeServices.NormalizeArrayIndex(materials, num5)].HasProperty("_Color"))
							{
								Material[] array7 = mats;
								array7[RuntimeServices.NormalizeArrayIndex(array7, num2)] = materials[RuntimeServices.NormalizeArrayIndex(materials, num5)];
								num2++;
							}
						}
					}
					finally
					{
						enumerator3.Dispose();
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			leng = num2;
			if (firstColor)
			{
				fstColors = new Color[leng];
				IEnumerator<int> enumerator4 = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						num3 = enumerator4.Current;
						Material[] array8 = mats;
						if (array8[RuntimeServices.NormalizeArrayIndex(array8, num3)] != null)
						{
							Color[] array9 = fstColors;
							ref Color reference = ref array9[RuntimeServices.NormalizeArrayIndex(array9, num3)];
							Material[] array10 = mats;
							reference = array10[RuntimeServices.NormalizeArrayIndex(array10, num3)].GetColor("_Color");
						}
					}
				}
				finally
				{
					enumerator4.Dispose();
				}
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
		if (fstLife == 0f)
		{
			fstLife = life;
		}
		life = fstLife;
		delay = fstDelay;
		loopCount = fstLoop;
		pause = false;
		UpdateAnim();
		if (linkQuickAnim)
		{
			if (!qar)
			{
				qar = gameObject.GetComponent<Ef_QuickAnimTransCurve>();
			}
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
			}
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qaf)
			{
				qaf = gameObject.GetComponent<Ef_QuickAnimMatFloat>();
			}
			if ((bool)qar)
			{
				qar.linkQuickAnim = false;
				qar.Play();
			}
			if ((bool)qat)
			{
				qat.linkQuickAnim = false;
				qat.Play();
			}
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Play();
			}
			if ((bool)qaf)
			{
				qaf.linkQuickAnim = false;
				qaf.Play();
			}
		}
	}

	public void Stop()
	{
		if (!ready)
		{
			Init();
		}
		pause = true;
		if (linkQuickAnim)
		{
			if (!qar)
			{
				qar = gameObject.GetComponent<Ef_QuickAnimTransCurve>();
			}
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
			}
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qaf)
			{
				qaf = gameObject.GetComponent<Ef_QuickAnimMatFloat>();
			}
			if ((bool)qar)
			{
				qar.linkQuickAnim = false;
				qar.Stop();
			}
			if ((bool)qat)
			{
				qat.linkQuickAnim = false;
				qat.Stop();
			}
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Stop();
			}
			if ((bool)qaf)
			{
				qaf.linkQuickAnim = false;
				qaf.Stop();
			}
		}
	}

	public void Clear()
	{
		if (!ready)
		{
			Init();
		}
		if (fstLife == 0f)
		{
			fstLife = life;
		}
		life = fstLife;
		delay = fstDelay;
		loopCount = fstLoop;
		UpdateAnim();
		if (linkQuickAnim)
		{
			if (!qar)
			{
				qar = gameObject.GetComponent<Ef_QuickAnimTransCurve>();
			}
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
			}
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qaf)
			{
				qaf = gameObject.GetComponent<Ef_QuickAnimMatFloat>();
			}
			if ((bool)qar)
			{
				qar.linkQuickAnim = false;
				qar.Clear();
			}
			if ((bool)qat)
			{
				qat.linkQuickAnim = false;
				qat.Clear();
			}
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Clear();
			}
			if ((bool)qaf)
			{
				qaf.linkQuickAnim = false;
				qaf.Clear();
			}
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		if (play)
		{
			Play();
			play = false;
		}
		if (waitAnimation && (bool)animation)
		{
			if (!animation.isPlaying)
			{
				life = fstLife;
				delay = fstDelay;
				loopCount = fstLoop;
				pause = true;
				return;
			}
			pause = false;
		}
		if (pause)
		{
			return;
		}
		float num = deltaTime;
		if (!(num <= maxDelta))
		{
			num = maxDelta;
		}
		if (!(delay <= 0f))
		{
			delay -= num;
			return;
		}
		UpdateAnim();
		checked
		{
			if (!(life > 0f))
			{
				bool flag = false;
				if (loop)
				{
					if (useLoopCount)
					{
						loopCount--;
						if (loopCount >= 1)
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
				if (!flag)
				{
					pause = true;
					return;
				}
				life += loopTime;
			}
			life -= num;
			if (!(life >= 0f))
			{
				life = 0f;
			}
			UpdateAnim();
		}
	}

	public void UpdateAnim()
	{
		float time = (fstLife - life) / fstLife;
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
			Color color = colorAnim.Evaluate(time);
			if (this.color != Color.white)
			{
				color *= this.color;
			}
			if (firstColor)
			{
				Color obj = color;
				Color[] array = fstColors;
				color = obj * array[RuntimeServices.NormalizeArrayIndex(array, index)];
			}
			Material[] array2 = mats;
			if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)] != null)
			{
				Material[] array3 = mats;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, index)].HasProperty("_Color"))
				{
					Material[] array4 = mats;
					array4[RuntimeServices.NormalizeArrayIndex(array4, index)].SetColor("_Color", color);
				}
			}
		}
	}

	public void OnDestroy()
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
			if (mats != null)
			{
				Material[] array = mats;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
				{
					Material[] array2 = mats;
					UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
				}
			}
		}
	}
}
