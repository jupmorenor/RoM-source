using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class CharMake3D : MonoBehaviour
{
	[NonSerialized]
	public static bool initialized;

	public int selectL;

	public int selectR;

	public bool accept;

	public AnimationClip idleMotL0;

	public AnimationClip trueMotL0;

	public AnimationClip falseMotL0;

	public AnimationClip idleMotL1;

	public AnimationClip trueMotL1;

	public AnimationClip falseMotL1;

	public AnimationClip idleMotR0;

	public AnimationClip trueMotR0;

	public AnimationClip falseMotR0;

	public AnimationClip idleMotR1;

	public AnimationClip trueMotR1;

	public AnimationClip falseMotR1;

	public Transform charObjL0;

	public Transform charObjL1;

	public Transform charObjR0;

	public Transform charObjR1;

	public GameObject meshL0;

	public GameObject meshL1;

	public GameObject meshR0;

	public GameObject meshR1;

	public Transform camRotL;

	public Transform camRotR;

	public float rotRate;

	public Color colorLF;

	public Color colorLB;

	public Color colorRF;

	public Color colorRB;

	public bool sideGui;

	public Texture blackTex;

	private int lstL;

	private int lstR;

	private Material matL00;

	private Material matL01;

	private Material matL02;

	private Material matL10;

	private Material matL11;

	private Material matL12;

	private Material matR00;

	private Material matR01;

	private Material matR02;

	private Material matR10;

	private Material matR11;

	private Material matR12;

	private float camAngL;

	private float camAngR;

	private float trgAngL;

	private float trgAngR;

	private float colRateL0;

	private float colRateL1;

	private float colRateR0;

	private float colRateR1;

	private float trgRateL0;

	private float trgRateL1;

	private float trgRateR0;

	private float trgRateR1;

	private Quaternion trgChrRotL;

	private Quaternion trgChrRotR;

	private bool lockCamL;

	private bool lockCamR;

	[NonSerialized]
	private static Boo.Lang.List<CharMake3D> _InstanceList = new Boo.Lang.List<CharMake3D>();

	public static CharMake3D Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public CharMake3D()
	{
		rotRate = 0.1f;
		colorLF = new Color(0.39f, 0.39f, 0.39f, 1f);
		colorLB = Color.black;
		colorRF = new Color(0.4f, 0.4f, 0.4f, 1f);
		colorRB = new Color(0.15f, 0.15f, 0.15f, 1f);
		sideGui = true;
		lstL = 1;
		lstR = 1;
		colRateL0 = 0.1f;
		colRateL1 = 0.9f;
		colRateR0 = 0.1f;
		colRateR1 = 0.9f;
		trgRateL1 = 1f;
		trgRateR1 = 1f;
		trgChrRotL = Quaternion.identity;
		trgChrRotR = Quaternion.identity;
	}

	public void Start()
	{
		selectL = 0;
		selectR = 0;
		charObjL0.animation.AddClip(idleMotL0, idleMotL0.name);
		charObjL0.animation[idleMotL0.name].wrapMode = WrapMode.Loop;
		charObjL0.animation.Play(idleMotL0.name);
		charObjL1.animation.AddClip(idleMotL1, idleMotL1.name);
		charObjL1.animation[idleMotL1.name].wrapMode = WrapMode.Loop;
		charObjL1.animation.Play(idleMotL1.name);
		charObjR0.animation.AddClip(idleMotR0, idleMotR0.name);
		charObjR0.animation[idleMotR0.name].wrapMode = WrapMode.Loop;
		charObjR0.animation.Play(idleMotR0.name);
		charObjR1.animation.AddClip(idleMotR1, idleMotR1.name);
		charObjR1.animation[idleMotR1.name].wrapMode = WrapMode.Loop;
		charObjR1.animation.Play(idleMotR1.name);
		matL00 = meshL0.renderer.materials[0];
		matL01 = meshL0.renderer.materials[1];
		matL02 = meshL0.renderer.materials[2];
		matL10 = meshL1.renderer.materials[0];
		matL11 = meshL1.renderer.materials[1];
		matL12 = meshL1.renderer.materials[2];
		matR00 = meshR0.renderer.materials[0];
		matR01 = meshR0.renderer.materials[1];
		matR02 = meshR0.renderer.materials[2];
		matR10 = meshR1.renderer.materials[0];
		matR11 = meshR1.renderer.materials[1];
		matR12 = meshR1.renderer.materials[2];
		Shader shader = Shader.Find("Custom/Cutout/Unlit with Shadow Color");
		matL00.shader = shader;
		matL01.shader = shader;
		matL02.shader = shader;
		matL10.shader = shader;
		matL11.shader = shader;
		matL12.shader = shader;
		matR00.shader = shader;
		matR01.shader = shader;
		matR02.shader = shader;
		matR10.shader = shader;
		matR11.shader = shader;
		matR12.shader = shader;
	}

	public void Update()
	{
		if (selectL != lstL)
		{
			if (selectL % 2 == 0)
			{
				if (trgAngL % 360f != 0f)
				{
					trgAngL += 180f;
				}
			}
			else if (trgAngL % 360f == 0f)
			{
				trgAngL += 180f;
			}
			lstL = selectL;
		}
		if (selectR != lstR)
		{
			if (selectR % 2 == 0)
			{
				if (trgAngR % 360f != 0f)
				{
					trgAngR += 180f;
				}
			}
			else if (trgAngR % 360f == 0f)
			{
				trgAngR += 180f;
			}
			lstR = selectR;
		}
		if (camAngL != trgAngL)
		{
			camAngL = Mathf.Lerp(camAngL, trgAngL, Mathf.Min(8f / Mathf.Abs(trgAngL - camAngL), 0.1f));
			if (!(trgAngL - camAngL >= 0.1f))
			{
				camAngL = trgAngL;
			}
			camRotL.localRotation = Quaternion.Euler(0f, camAngL, 0f);
		}
		if (camAngR != trgAngR)
		{
			camAngR = Mathf.Lerp(camAngR, trgAngR, Mathf.Min(8f / Mathf.Abs(trgAngR - camAngR), 0.1f));
			if (!(trgAngR - camAngR >= 0.1f))
			{
				camAngR = trgAngR;
			}
			camRotR.localRotation = Quaternion.Euler(0f, camAngR, 0f);
		}
		float num = camAngL % 360f;
		if (!(num <= 180f))
		{
			num -= 360f;
		}
		if (!(num >= -180f))
		{
			num += 360f;
		}
		if (!(Mathf.Abs(num) >= 20f))
		{
			trgRateL0 = 0f;
		}
		else
		{
			trgRateL0 = 1f;
		}
		if (!(Mathf.Abs(num) <= 160f))
		{
			trgRateL1 = 0f;
		}
		else
		{
			trgRateL1 = 1f;
		}
		float num2 = camAngR % 360f;
		if (!(num2 <= 180f))
		{
			num2 -= 360f;
		}
		if (!(num2 >= -180f))
		{
			num2 += 360f;
		}
		if (!(Mathf.Abs(num2) >= 20f))
		{
			trgRateR0 = 0f;
		}
		else
		{
			trgRateR0 = 1f;
		}
		if (!(Mathf.Abs(num2) <= 160f))
		{
			trgRateR1 = 0f;
		}
		else
		{
			trgRateR1 = 1f;
		}
		if (colRateL0 != trgRateL0)
		{
			colRateL0 = Mathf.Lerp(colRateL0, trgRateL0, 0.1f);
			if (!((double)Mathf.Abs(trgRateL0 - colRateL0) >= 0.01))
			{
				colRateL0 = trgRateL0;
			}
			matL00.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL0));
			matL01.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL0));
			matL02.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL0));
		}
		if (colRateL1 != trgRateL1)
		{
			colRateL1 = Mathf.Lerp(colRateL1, trgRateL1, 0.1f);
			if (!((double)Mathf.Abs(trgRateL1 - colRateL1) >= 0.01))
			{
				colRateL1 = trgRateL1;
			}
			matL10.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL1));
			matL11.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL1));
			matL12.SetColor("_Color", Color.Lerp(colorLF, colorLB, colRateL1));
		}
		if (colRateR0 != trgRateR0)
		{
			colRateR0 = Mathf.Lerp(colRateR0, trgRateR0, 0.1f);
			if (!((double)Mathf.Abs(trgRateR0 - colRateR0) >= 0.01))
			{
				colRateR0 = trgRateR0;
			}
			matR00.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR0));
			matR01.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR0));
			matR02.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR0));
		}
		if (colRateR1 != trgRateR1)
		{
			colRateR1 = Mathf.Lerp(colRateR1, trgRateR1, 0.1f);
			if (!((double)Mathf.Abs(trgRateR1 - colRateR1) >= 0.01))
			{
				colRateR1 = trgRateR1;
			}
			matR10.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR1));
			matR11.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR1));
			matR12.SetColor("_Color", Color.Lerp(colorRF, colorRB, colRateR1));
		}
		if (accept)
		{
			if (selectL == 0)
			{
				charObjL0.animation.AddClip(trueMotL0, trueMotL0.name);
				charObjL0.animation[trueMotL0.name].wrapMode = WrapMode.Once;
				charObjL0.animation.CrossFade(trueMotL0.name, 0.1f);
				charObjL0.animation.PlayQueued(idleMotL0.name);
				charObjL1.animation.AddClip(falseMotL1, falseMotL1.name);
				charObjL1.animation[falseMotL1.name].wrapMode = WrapMode.Once;
				charObjL1.animation.CrossFade(falseMotL1.name, 0.1f);
				charObjL1.animation.PlayQueued(idleMotL1.name);
			}
			else
			{
				charObjL1.animation.AddClip(trueMotL1, trueMotL1.name);
				charObjL1.animation[trueMotL1.name].wrapMode = WrapMode.Once;
				charObjL1.animation.CrossFade(trueMotL1.name, 0.1f);
				charObjL1.animation.PlayQueued(idleMotL1.name);
				charObjL0.animation.AddClip(falseMotL0, falseMotL0.name);
				charObjL0.animation[falseMotL0.name].wrapMode = WrapMode.Once;
				charObjL0.animation.CrossFade(falseMotL0.name, 0.1f);
				charObjL0.animation.PlayQueued(idleMotL0.name);
			}
			if (selectR == 0)
			{
				charObjR0.animation.AddClip(trueMotR0, trueMotR0.name);
				charObjR0.animation[trueMotR0.name].wrapMode = WrapMode.Once;
				charObjR0.animation.CrossFade(trueMotR0.name, 0.1f);
				charObjR0.animation.PlayQueued(idleMotR0.name);
				charObjR1.animation.AddClip(falseMotR1, falseMotR1.name);
				charObjR1.animation[falseMotR1.name].wrapMode = WrapMode.Once;
				charObjR1.animation.CrossFade(falseMotR1.name, 0.1f);
				charObjR1.animation.PlayQueued(idleMotR1.name);
			}
			else
			{
				charObjR1.animation.AddClip(trueMotR1, trueMotR1.name);
				charObjR1.animation[trueMotR1.name].wrapMode = WrapMode.Once;
				charObjR1.animation.CrossFade(trueMotR1.name, 0.1f);
				charObjR1.animation.PlayQueued(idleMotR1.name);
				charObjR0.animation.AddClip(falseMotR0, falseMotR0.name);
				charObjR0.animation[falseMotR0.name].wrapMode = WrapMode.Once;
				charObjR0.animation.CrossFade(falseMotR0.name, 0.1f);
				charObjR0.animation.PlayQueued(idleMotR0.name);
			}
			accept = false;
		}
		if (trgChrRotL != Quaternion.identity)
		{
			if (selectL % 2 == 0)
			{
				charObjL0.localRotation = Quaternion.Lerp(charObjL0.localRotation, trgChrRotL, 0.2f);
			}
			else
			{
				charObjL1.localRotation = Quaternion.Lerp(charObjL1.localRotation, trgChrRotL, 0.2f);
			}
		}
		if (trgChrRotR != Quaternion.identity)
		{
			if (selectR % 2 == 0)
			{
				charObjR0.localRotation = Quaternion.Lerp(charObjR0.localRotation, trgChrRotR, 0.2f);
			}
			else
			{
				charObjR1.localRotation = Quaternion.Lerp(charObjR1.localRotation, trgChrRotR, 0.2f);
			}
		}
		initialized = true;
	}

	public void OnGUI()
	{
		if (sideGui)
		{
			float num = (float)Screen.height * (1f * (float)Screen.width / (float)Screen.height - 1.5f) / 2f;
			GUI.DrawTexture(new Rect(0f, 0f, num, Screen.height), blackTex, ScaleMode.StretchToFill, alphaBlend: false, 10f);
			GUI.DrawTexture(new Rect((float)Screen.width - num, 0f, num, Screen.height), blackTex, ScaleMode.StretchToFill, alphaBlend: false, 10f);
		}
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void SetSelectL(int n)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__SetSelectL(n);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetSelectL(int n)
	{
		if (!lockCamL)
		{
			selectL = n;
		}
	}

	public static void SetSelectR(int n)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__SetSelectR(n);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetSelectR(int n)
	{
		if (!lockCamR)
		{
			selectR = n;
		}
	}

	public static void SetAccept(bool b)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__SetAccept(b);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetAccept(bool b)
	{
		accept = b;
	}

	public static void StopRotationL(bool v)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__StopRotationL(v);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __StopRotationL(bool v)
	{
		lockCamL = v;
	}

	public static void StopRotationR(bool v)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__StopRotationR(v);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __StopRotationR(bool v)
	{
		lockCamR = v;
	}

	public static void StopRotation(bool v)
	{
		IEnumerator<CharMake3D> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CharMake3D current = enumerator.Current;
				current.__StopRotation(v);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __StopRotation(bool v)
	{
		StopRotationL(v);
		StopRotationR(v);
	}
}
