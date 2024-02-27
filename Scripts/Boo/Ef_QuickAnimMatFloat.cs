using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimMatFloat : Ef_Base
{
	public float maxDelta;

	public float delay;

	public float life;

	public bool pause;

	public Ef_QuickAnimMatFloatObj[] materialObjs;

	public bool loop;

	public float loopTime;

	public bool linkQuickAnim;

	public bool play;

	private float fstLife;

	private float fstDelay;

	private int leng;

	private bool ready;

	private Ef_QuickAnimTransCurve qar;

	private Ef_QuickAnimTransform qat;

	private Ef_QuickAnimColor qac;

	private Ef_QuickAnimTexture qax;

	public Ef_QuickAnimMatFloat()
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
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		fstLife = life;
		fstDelay = delay;
		if (loopTime == 0f && loop)
		{
			loopTime = life;
		}
		leng = materialObjs.Length;
		int num = default(int);
		int num2 = default(int);
		Ef_QuickAnimMatFloatObj ef_QuickAnimMatFloatObj = null;
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_QuickAnimMatFloatObj[] array = materialObjs;
				ef_QuickAnimMatFloatObj = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				if (!ef_QuickAnimMatFloatObj.materialObj || !ef_QuickAnimMatFloatObj.materialObj.renderer || !ef_QuickAnimMatFloatObj.materialObj.renderer.material)
				{
					continue;
				}
				int num3 = 0;
				IEnumerator<int> enumerator2 = Builtins.range(num).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						GameObject materialObj = ef_QuickAnimMatFloatObj.materialObj;
						Ef_QuickAnimMatFloatObj[] array2 = materialObjs;
						if (materialObj == array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].materialObj)
						{
							num3 = checked(num3 + 1);
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				if (num3 >= ef_QuickAnimMatFloatObj.materialObj.renderer.materials.Length)
				{
				}
				Ef_QuickAnimMatFloatObj ef_QuickAnimMatFloatObj2 = ef_QuickAnimMatFloatObj;
				Material[] materials = ef_QuickAnimMatFloatObj.materialObj.renderer.materials;
				ef_QuickAnimMatFloatObj2.material = materials[RuntimeServices.NormalizeArrayIndex(materials, num3)];
				ef_QuickAnimMatFloatObj.number = ef_QuickAnimMatFloatObj.parameters.Length;
				Ef_QuickAnimMatFloatObj[] array3 = materialObjs;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = ef_QuickAnimMatFloatObj;
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Play();
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Stop();
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
			if (!qax)
			{
				qax = gameObject.GetComponent<Ef_QuickAnimTexture>();
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
			if ((bool)qax)
			{
				qax.linkQuickAnim = false;
				qax.Clear();
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
		if (!(life > 0f))
		{
			if (!loop)
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

	public void UpdateAnim()
	{
		float time = (fstLife - life) / fstLife;
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_QuickAnimMatFloatObj[] array = materialObjs;
				Ef_QuickAnimMatFloatObj ef_QuickAnimMatFloatObj = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				Material material = ef_QuickAnimMatFloatObj.material;
				IEnumerator<int> enumerator2 = Builtins.range(ef_QuickAnimMatFloatObj.number).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						Ef_QuickAnimMatFloatElem[] parameters = ef_QuickAnimMatFloatObj.parameters;
						Ef_QuickAnimMatFloatElem ef_QuickAnimMatFloatElem = parameters[RuntimeServices.NormalizeArrayIndex(parameters, num2)];
						string parameterName = ef_QuickAnimMatFloatElem.parameterName;
						float value = Mathf.Lerp(ef_QuickAnimMatFloatElem.min, ef_QuickAnimMatFloatElem.max, ef_QuickAnimMatFloatElem.anim.Evaluate(time));
						if (material.HasProperty(parameterName))
						{
							material.SetFloat(parameterName, value);
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
