using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimTransform : Ef_Base
{
	public float maxDelta;

	public float delay;

	public float life;

	public bool pause;

	public Ef_QuickAnimTransformObj[] animObjs;

	public bool loop;

	public float loopTime;

	public int loopCount;

	public bool linkQuickAnim;

	public bool play;

	private float fstLife;

	private float fstDelay;

	private int fstLoop;

	private bool useLoopCount;

	private int leng;

	private bool[] animPoss;

	private bool[] animRots;

	private bool[] animScales;

	private bool ready;

	private Ef_QuickAnimTransCurve qar;

	private Ef_QuickAnimTexture qax;

	private Ef_QuickAnimColor qac;

	private Ef_QuickAnimMatFloat qaf;

	public Ef_QuickAnimTransform()
	{
		maxDelta = 0.05f;
		life = 1f;
		linkQuickAnim = true;
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
		leng = animObjs.Length;
		animPoss = new bool[leng];
		animRots = new bool[leng];
		animScales = new bool[leng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_QuickAnimTransformObj[] array = animObjs;
				Ef_QuickAnimTransformObj ef_QuickAnimTransformObj = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				if ((bool)ef_QuickAnimTransformObj.transObj)
				{
					bool[] array2 = animPoss;
					ref bool reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					bool num2 = ef_QuickAnimTransformObj.posAnim.xMin == 0f;
					if (num2)
					{
						num2 = ef_QuickAnimTransformObj.posAnim.xMax == 0f;
					}
					if (num2)
					{
						num2 = ef_QuickAnimTransformObj.posAnim.yMin == 0f;
					}
					if (num2)
					{
						num2 = ef_QuickAnimTransformObj.posAnim.yMax == 0f;
					}
					if (num2)
					{
						num2 = ef_QuickAnimTransformObj.posAnim.zMin == 0f;
					}
					if (num2)
					{
						num2 = ef_QuickAnimTransformObj.posAnim.zMax == 0f;
					}
					reference = !num2;
					bool[] array3 = animRots;
					ref bool reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
					bool num3 = ef_QuickAnimTransformObj.rotAnim.xMin == 0f;
					if (num3)
					{
						num3 = ef_QuickAnimTransformObj.rotAnim.xMax == 0f;
					}
					if (num3)
					{
						num3 = ef_QuickAnimTransformObj.rotAnim.yMin == 0f;
					}
					if (num3)
					{
						num3 = ef_QuickAnimTransformObj.rotAnim.yMax == 0f;
					}
					if (num3)
					{
						num3 = ef_QuickAnimTransformObj.rotAnim.zMin == 0f;
					}
					if (num3)
					{
						num3 = ef_QuickAnimTransformObj.rotAnim.zMax == 0f;
					}
					reference2 = !num3;
					bool[] array4 = animScales;
					ref bool reference3 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					bool num4 = ef_QuickAnimTransformObj.scaleAnim.xMin == 0f;
					if (num4)
					{
						num4 = ef_QuickAnimTransformObj.scaleAnim.xMax == 0f;
					}
					if (num4)
					{
						num4 = ef_QuickAnimTransformObj.scaleAnim.yMin == 0f;
					}
					if (num4)
					{
						num4 = ef_QuickAnimTransformObj.scaleAnim.yMax == 0f;
					}
					if (num4)
					{
						num4 = ef_QuickAnimTransformObj.scaleAnim.zMin == 0f;
					}
					if (num4)
					{
						num4 = ef_QuickAnimTransformObj.scaleAnim.zMax == 0f;
					}
					reference3 = !num4;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		ready = true;
	}

	public void Play()
	{
		if (!ready)
		{
			Init();
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qac)
			{
				qac = gameObject.GetComponent<Ef_QuickAnimColor>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Play();
			}
			if ((bool)qac)
			{
				qac.linkQuickAnim = false;
				qac.Play();
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qac)
			{
				qac = gameObject.GetComponent<Ef_QuickAnimColor>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Stop();
			}
			if ((bool)qac)
			{
				qac.linkQuickAnim = false;
				qac.Stop();
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
			}
			if (!qac)
			{
				qac = gameObject.GetComponent<Ef_QuickAnimColor>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Clear();
			}
			if ((bool)qac)
			{
				qac.linkQuickAnim = false;
				qac.Clear();
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
			Ef_QuickAnimTransformObj[] array = animObjs;
			Ef_QuickAnimTransformObj ef_QuickAnimTransformObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if ((bool)ef_QuickAnimTransformObj.transObj)
			{
				float num3 = default(float);
				float num4 = default(float);
				float num5 = default(float);
				bool[] array2 = animPoss;
				if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)])
				{
					num3 = Mathf.Lerp(ef_QuickAnimTransformObj.posAnim.xMin, ef_QuickAnimTransformObj.posAnim.xMax, ef_QuickAnimTransformObj.posAnim.xAnim.Evaluate(time));
					num4 = Mathf.Lerp(ef_QuickAnimTransformObj.posAnim.yMin, ef_QuickAnimTransformObj.posAnim.yMax, ef_QuickAnimTransformObj.posAnim.yAnim.Evaluate(time));
					num5 = Mathf.Lerp(ef_QuickAnimTransformObj.posAnim.zMin, ef_QuickAnimTransformObj.posAnim.zMax, ef_QuickAnimTransformObj.posAnim.zAnim.Evaluate(time));
					ef_QuickAnimTransformObj.transObj.localPosition = new Vector3(num3, num4, num5);
				}
				bool[] array3 = animRots;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, index)])
				{
					num3 = Mathf.Lerp(ef_QuickAnimTransformObj.rotAnim.xMin, ef_QuickAnimTransformObj.rotAnim.xMax, ef_QuickAnimTransformObj.rotAnim.xAnim.Evaluate(time));
					num4 = Mathf.Lerp(ef_QuickAnimTransformObj.rotAnim.yMin, ef_QuickAnimTransformObj.rotAnim.yMax, ef_QuickAnimTransformObj.rotAnim.yAnim.Evaluate(time));
					num5 = Mathf.Lerp(ef_QuickAnimTransformObj.rotAnim.zMin, ef_QuickAnimTransformObj.rotAnim.zMax, ef_QuickAnimTransformObj.rotAnim.zAnim.Evaluate(time));
					ef_QuickAnimTransformObj.transObj.localRotation = Quaternion.Euler(num3, num4, num5);
				}
				bool[] array4 = animScales;
				if (array4[RuntimeServices.NormalizeArrayIndex(array4, index)])
				{
					num3 = Mathf.Lerp(ef_QuickAnimTransformObj.scaleAnim.xMin, ef_QuickAnimTransformObj.scaleAnim.xMax, ef_QuickAnimTransformObj.scaleAnim.xAnim.Evaluate(time));
					num4 = Mathf.Lerp(ef_QuickAnimTransformObj.scaleAnim.yMin, ef_QuickAnimTransformObj.scaleAnim.yMax, ef_QuickAnimTransformObj.scaleAnim.yAnim.Evaluate(time));
					num5 = Mathf.Lerp(ef_QuickAnimTransformObj.scaleAnim.zMin, ef_QuickAnimTransformObj.scaleAnim.zMax, ef_QuickAnimTransformObj.scaleAnim.zAnim.Evaluate(time));
					ef_QuickAnimTransformObj.transObj.localScale = new Vector3(num3, num4, num5);
				}
			}
		}
	}
}
