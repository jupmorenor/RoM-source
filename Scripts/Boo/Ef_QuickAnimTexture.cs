using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimTexture : Ef_Base
{
	[Serializable]
	public class Ef_QuickAnimTextureObj
	{
		public GameObject textureObj;

		public Ef_QuickAnimTextureMinMaxAnim offsetAnim;

		public Ef_QuickAnimTextureMinMaxAnim scaleAnim;

		private Material[] mats;

		private int matId;

		public Material[] materials
		{
			get
			{
				return mats;
			}
			set
			{
				mats = value;
			}
		}

		public int matIndex
		{
			get
			{
				return matId;
			}
			set
			{
				matId = value;
			}
		}
	}

	[Serializable]
	public class Ef_QuickAnimTextureMinMaxAnim
	{
		public float xMax;

		public AnimationCurve xAnim;

		public float xMin;

		public float yMax;

		public AnimationCurve yAnim;

		public float yMin;
	}

	public float maxDelta;

	public float delay;

	public float life;

	public bool pause;

	public Ef_QuickAnimTextureObj[] textureObjs;

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

	private bool[] animOfss;

	private bool[] animScales;

	private bool ready;

	private Ef_QuickAnimTransCurve qar;

	private Ef_QuickAnimTransform qat;

	private Ef_QuickAnimColor qac;

	private Ef_QuickAnimMatFloat qaf;

	public Ef_QuickAnimTexture()
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
		leng = textureObjs.Length;
		animOfss = new bool[leng];
		animScales = new bool[leng];
		Ef_QuickAnimTextureObj ef_QuickAnimTextureObj = null;
		GameObject gameObject = null;
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Ef_QuickAnimTextureObj[] array = textureObjs;
			ef_QuickAnimTextureObj = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			gameObject = ef_QuickAnimTextureObj.textureObj;
			if (!gameObject || !gameObject.renderer || !gameObject.renderer.material)
			{
				continue;
			}
			bool[] array2 = animOfss;
			ref bool reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
			bool num4 = ef_QuickAnimTextureObj.offsetAnim.xMin == 0f;
			if (num4)
			{
				num4 = ef_QuickAnimTextureObj.offsetAnim.xMax == 0f;
			}
			if (num4)
			{
				num4 = ef_QuickAnimTextureObj.offsetAnim.yMin == 0f;
			}
			if (num4)
			{
				num4 = ef_QuickAnimTextureObj.offsetAnim.yMax == 0f;
			}
			reference = !num4;
			bool[] array3 = animScales;
			ref bool reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num3)];
			bool num5 = ef_QuickAnimTextureObj.scaleAnim.xMin == 0f;
			if (num5)
			{
				num5 = ef_QuickAnimTextureObj.scaleAnim.xMax == 0f;
			}
			if (num5)
			{
				num5 = ef_QuickAnimTextureObj.scaleAnim.yMin == 0f;
			}
			if (num5)
			{
				num5 = ef_QuickAnimTextureObj.scaleAnim.yMax == 0f;
			}
			reference2 = !num5;
			Ef_QuickAnimTextureObj[] array4 = textureObjs;
			array4[RuntimeServices.NormalizeArrayIndex(array4, num3)].materials = gameObject.renderer.materials;
			int num6 = -1;
			int num7 = 0;
			int num8 = num3;
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num7 < num8)
			{
				int index = num7;
				num7++;
				Ef_QuickAnimTextureObj[] array5 = textureObjs;
				if (array5[RuntimeServices.NormalizeArrayIndex(array5, index)].textureObj == gameObject)
				{
					num6 = checked(num6 + 1);
				}
			}
			Ef_QuickAnimTextureObj[] array6 = textureObjs;
			array6[RuntimeServices.NormalizeArrayIndex(array6, num3)].matIndex = num6;
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
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
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
			if ((bool)qat)
			{
				qat.linkQuickAnim = false;
				qat.Play();
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
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
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
			if ((bool)qat)
			{
				qat.linkQuickAnim = false;
				qat.Stop();
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
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
			}
			if (!qac)
			{
				qac = gameObject.GetComponent<Ef_QuickAnimColor>();
			}
			if (!qaf)
			{
				qaf = gameObject.GetComponent<Ef_QuickAnimMatFloat>();
			}
			if (qac.linkQuickAnim)
			{
				qac.linkQuickAnim = false;
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
			Ef_QuickAnimTextureObj[] array = textureObjs;
			Ef_QuickAnimTextureObj ef_QuickAnimTextureObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Material[] materials = ef_QuickAnimTextureObj.materials;
			int matIndex = ef_QuickAnimTextureObj.matIndex;
			if (materials == null)
			{
				continue;
			}
			int length = materials.Length;
			float num3 = default(float);
			float num4 = default(float);
			float num5 = 1f;
			float num6 = 1f;
			bool[] array2 = animScales;
			if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)])
			{
				num5 = Mathf.Lerp(ef_QuickAnimTextureObj.scaleAnim.xMin, ef_QuickAnimTextureObj.scaleAnim.xMax, ef_QuickAnimTextureObj.scaleAnim.xAnim.Evaluate(time));
				num6 = Mathf.Lerp(ef_QuickAnimTextureObj.scaleAnim.yMin, ef_QuickAnimTextureObj.scaleAnim.yMax, ef_QuickAnimTextureObj.scaleAnim.yAnim.Evaluate(time));
				num5 = ((num5 == 0f) ? 100f : (1f / num5));
				num6 = ((num6 == 0f) ? 100f : (1f / num6));
				if (matIndex >= 0 && length >= checked(matIndex + 1))
				{
					if (materials[RuntimeServices.NormalizeArrayIndex(materials, matIndex)] != null)
					{
						materials[RuntimeServices.NormalizeArrayIndex(materials, matIndex)].mainTextureScale = new Vector2(num5, num6);
					}
				}
				else
				{
					int num7 = 0;
					int num8 = length;
					if (num8 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num7 < num8)
					{
						int index2 = num7;
						num7++;
						if (materials[RuntimeServices.NormalizeArrayIndex(materials, index2)] != null)
						{
							materials[RuntimeServices.NormalizeArrayIndex(materials, index2)].mainTextureScale = new Vector2(num5, num6);
						}
					}
				}
			}
			bool[] array3 = animOfss;
			if (array3[RuntimeServices.NormalizeArrayIndex(array3, index)])
			{
				bool[] array4 = animScales;
				if (!array4[RuntimeServices.NormalizeArrayIndex(array4, index)])
				{
					Vector2 mainTextureScale = materials[0].mainTextureScale;
					num5 = mainTextureScale.x;
					num6 = mainTextureScale.y;
				}
				num3 = Mathf.Lerp(ef_QuickAnimTextureObj.offsetAnim.xMin, ef_QuickAnimTextureObj.offsetAnim.xMax, ef_QuickAnimTextureObj.offsetAnim.xAnim.Evaluate(time));
				num4 = Mathf.Lerp(ef_QuickAnimTextureObj.offsetAnim.yMin, ef_QuickAnimTextureObj.offsetAnim.yMax, ef_QuickAnimTextureObj.offsetAnim.yAnim.Evaluate(time));
				num3 += (0f - num5) / 2f + 0.5f;
				num4 += (0f - num6) / 2f + 0.5f;
			}
			else
			{
				num3 = (0f - num5) / 2f + 0.5f;
				num4 = (0f - num6) / 2f + 0.5f;
			}
			if (matIndex >= 0 && length >= checked(matIndex + 1))
			{
				if (materials[RuntimeServices.NormalizeArrayIndex(materials, matIndex)] != null)
				{
					materials[RuntimeServices.NormalizeArrayIndex(materials, matIndex)].mainTextureOffset = new Vector2(num3, num4);
				}
				continue;
			}
			int num9 = 0;
			int num10 = length;
			if (num10 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num9 < num10)
			{
				int index3 = num9;
				num9++;
				if (materials[RuntimeServices.NormalizeArrayIndex(materials, index3)] != null)
				{
					materials[RuntimeServices.NormalizeArrayIndex(materials, index3)].mainTextureOffset = new Vector2(num3, num4);
				}
			}
		}
	}

	public void OnDestroy()
	{
		if (textureObjs == null)
		{
			return;
		}
		int i = 0;
		Ef_QuickAnimTextureObj[] array = textureObjs;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == null || array[i].materials == null)
				{
					continue;
				}
				int j = 0;
				Material[] materials = array[i].materials;
				for (int length2 = materials.Length; j < length2; j++)
				{
					if (materials[j] != null)
					{
						UnityEngine.Object.Destroy(materials[j]);
					}
				}
			}
		}
	}
}
