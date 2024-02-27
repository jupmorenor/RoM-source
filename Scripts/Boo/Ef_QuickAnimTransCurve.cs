using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimTransCurve : Ef_Base
{
	[Serializable]
	public enum AnimOfHow
	{
		PositionX,
		PositionY,
		PositionZ,
		RotationX,
		RotationY,
		RotationZ,
		ScaleXYZ,
		ScaleX,
		ScaleY,
		ScaleZ,
		BaseOffsetX,
		BaseOffsetY,
		BaseOffsetZ,
		BaseRotationX,
		BaseRotationY,
		BaseRotationZ
	}

	[Serializable]
	public class AnimObject
	{
		public Transform transObj;

		public AnimData[] animations;

		[HideInInspector]
		public bool usePos;

		[HideInInspector]
		public bool useRot;

		[HideInInspector]
		public bool useScl;

		[HideInInspector]
		public bool useBOfs;

		[HideInInspector]
		public bool useBRot;

		[HideInInspector]
		public Vector3 pos;

		[HideInInspector]
		public Vector3 fstPos;

		[HideInInspector]
		public Vector3 euler;

		[HideInInspector]
		public Vector3 scl;

		[HideInInspector]
		public Vector3 fstScl;

		[HideInInspector]
		public Vector3 ofsEuler;

		[HideInInspector]
		public bool offsetMode;

		[HideInInspector]
		public Vector3 ofsPos;

		[HideInInspector]
		public Vector3 basePos;

		[HideInInspector]
		public Quaternion baseRot;

		[HideInInspector]
		public int leng;
	}

	[Serializable]
	public class AnimData
	{
		public bool active;

		public AnimOfHow how;

		public float animLength;

		public float max;

		public AnimationCurve curve;

		public float min;

		public bool loop;

		public int loopCount;

		[HideInInspector]
		public float max_min;

		[HideInInspector]
		public float fstLength;

		[HideInInspector]
		public int fstLoop;

		[HideInInspector]
		public bool useLoopCount;

		public AnimData()
		{
			active = true;
			how = AnimOfHow.PositionX;
			animLength = 1f;
		}
	}

	public float maxDelta;

	public float delay;

	public bool pause;

	public AnimObject[] animObjs;

	public bool linkQuickAnim;

	public float animTime;

	public bool play;

	private int leng;

	private float fstDelay;

	private float[] fstLengs;

	private bool ready;

	private Ef_QuickAnimTransform qat;

	private Ef_QuickAnimTexture qax;

	private Ef_QuickAnimColor qac;

	private Ef_QuickAnimMatFloat qaf;

	public Ef_QuickAnimTransCurve()
	{
		maxDelta = 0.05f;
		linkQuickAnim = true;
	}

	public void SetLife(float inLife)
	{
		float num = 0.1f;
		int i = 0;
		AnimObject[] array = animObjs;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				int j = 0;
				AnimData[] animations = array[i].animations;
				for (int length2 = animations.Length; j < length2; j++)
				{
					if (!(animations[j].fstLength <= num))
					{
						num = animations[j].fstLength;
					}
				}
			}
			float num2 = (inLife - delay) / num;
			int k = 0;
			AnimObject[] array2 = animObjs;
			for (int length3 = array2.Length; k < length3; k++)
			{
				int l = 0;
				AnimData[] animations2 = array2[k].animations;
				for (int length4 = animations2.Length; l < length4; l++)
				{
					animations2[l].animLength = animations2[l].fstLength * num2;
				}
			}
		}
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
		fstDelay = delay;
		leng = animObjs.Length;
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
			AnimObject[] array = animObjs;
			AnimObject animObject = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform transObj = animObject.transObj;
			if (!transObj)
			{
				if (leng != 1)
				{
					continue;
				}
				animObject.transObj = transform;
				transObj = transform;
			}
			AnimData[] animations = animObject.animations;
			animObject.leng = animations.Length;
			int num3 = 0;
			int num4 = animObject.leng;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				AnimData animData = animations[RuntimeServices.NormalizeArrayIndex(animations, index2)];
				animData.fstLength = animData.animLength;
				animData.fstLoop = animData.loopCount;
				animData.useLoopCount = animData.loopCount >= 1;
				if (animData.active)
				{
					if (animData.animLength == 0f)
					{
						animData.animLength = 1f;
					}
					animData.max_min = animData.max - animData.min;
					if (animData.how == AnimOfHow.PositionX || animData.how == AnimOfHow.PositionY || animData.how == AnimOfHow.PositionZ)
					{
						animObject.usePos = true;
					}
					else if (animData.how == AnimOfHow.RotationX || animData.how == AnimOfHow.RotationY || animData.how == AnimOfHow.RotationZ)
					{
						animObject.useRot = true;
					}
					else if (animData.how == AnimOfHow.ScaleX || animData.how == AnimOfHow.ScaleY || animData.how == AnimOfHow.ScaleZ || animData.how == AnimOfHow.ScaleXYZ)
					{
						animObject.useScl = true;
					}
					else if (animData.how == AnimOfHow.BaseOffsetX || animData.how == AnimOfHow.BaseOffsetY || animData.how == AnimOfHow.BaseOffsetZ)
					{
						animObject.usePos = true;
						animObject.useBOfs = true;
					}
					else
					{
						animObject.usePos = true;
						animObject.useRot = true;
						animObject.useBRot = true;
					}
				}
			}
			if (transObj.parent == null)
			{
				animObject.offsetMode = true;
			}
			animObject.pos = Vector3.zero;
			animObject.euler = Vector3.zero;
			animObject.scl = Vector3.one;
			animObject.ofsPos = Vector3.zero;
			animObject.ofsEuler = Vector3.zero;
			if (animObject.offsetMode)
			{
				animObject.basePos = transObj.position;
				animObject.baseRot = transObj.rotation;
				animObject.fstPos = Vector3.zero;
			}
			else
			{
				animObject.basePos = Vector3.zero;
				animObject.baseRot = Quaternion.identity;
				animObject.fstPos = transObj.localPosition;
			}
			animObject.fstScl = transObj.localScale;
		}
		ready = true;
	}

	public void Play()
	{
		if (!ready)
		{
			Init();
		}
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
			AnimObject[] array = animObjs;
			AnimObject animObject = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform transObj = animObject.transObj;
			animObject.euler = Vector3.zero;
			animObject.ofsPos = Vector3.zero;
			animObject.ofsEuler = Vector3.zero;
			if (animObject.offsetMode)
			{
				animObject.basePos = transObj.position;
				animObject.baseRot = transObj.rotation;
			}
			animObject.pos = animObject.fstPos;
			animObject.scl = animObject.fstScl;
			AnimData[] animations = animObject.animations;
			int num3 = 0;
			int num4 = animObject.leng;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				animations[RuntimeServices.NormalizeArrayIndex(animations, index2)].loopCount = animations[RuntimeServices.NormalizeArrayIndex(animations, index2)].fstLoop;
			}
		}
		animTime = 0f;
		delay = fstDelay;
		pause = false;
		UpdateAnim();
		if (linkQuickAnim)
		{
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
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
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
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
		animTime = 0f;
		delay = fstDelay;
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
			AnimObject[] array = animObjs;
			AnimData[] animations = array[RuntimeServices.NormalizeArrayIndex(array, index)].animations;
			int num3 = 0;
			AnimObject[] array2 = animObjs;
			int num4 = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].leng;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				animations[RuntimeServices.NormalizeArrayIndex(animations, index2)].loopCount = animations[RuntimeServices.NormalizeArrayIndex(animations, index2)].fstLoop;
			}
		}
		UpdateAnim();
		if (linkQuickAnim)
		{
			if (!qat)
			{
				qat = gameObject.GetComponent<Ef_QuickAnimTransform>();
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
		if (!pause)
		{
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
			animTime += num;
		}
	}

	public void UpdateAnim()
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
			AnimObject[] array = animObjs;
			AnimObject animObject = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			Transform transObj = animObject.transObj;
			if (!transObj)
			{
				continue;
			}
			AnimData[] animations = animObject.animations;
			int num3 = 0;
			int num4 = animObject.leng;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				AnimData animData = animations[RuntimeServices.NormalizeArrayIndex(animations, index2)];
				if (animData.active)
				{
					AnimOfHow how = animData.how;
					float animLength = animData.animLength;
					float num5 = default(float);
					num5 = ((!(animTime > animLength)) ? (animTime / animLength) : ((!animData.loop) ? 1f : ((animData.useLoopCount && animTime >= (float)animData.loopCount * animLength) ? 1f : (animTime % animLength / animLength))));
					float num6 = animData.min + animData.max_min * animData.curve.Evaluate(num5);
					switch (how)
					{
					case AnimOfHow.PositionX:
						animObject.pos.x = num6;
						break;
					case AnimOfHow.PositionY:
						animObject.pos.y = num6;
						break;
					case AnimOfHow.PositionZ:
						animObject.pos.z = num6;
						break;
					case AnimOfHow.RotationX:
						animObject.euler.x = num6;
						break;
					case AnimOfHow.RotationY:
						animObject.euler.y = num6;
						break;
					case AnimOfHow.RotationZ:
						animObject.euler.z = num6;
						break;
					case AnimOfHow.ScaleXYZ:
						animObject.scl = new Vector3(num6, num6, num6);
						break;
					case AnimOfHow.ScaleX:
						animObject.scl.x = num6;
						break;
					case AnimOfHow.ScaleY:
						animObject.scl.y = num6;
						break;
					case AnimOfHow.ScaleZ:
						animObject.scl.z = num6;
						break;
					case AnimOfHow.BaseOffsetX:
						animObject.ofsPos.x = num6;
						break;
					case AnimOfHow.BaseOffsetY:
						animObject.ofsPos.y = num6;
						break;
					case AnimOfHow.BaseOffsetZ:
						animObject.ofsPos.z = num6;
						break;
					case AnimOfHow.BaseRotationX:
						animObject.ofsEuler.x = num6;
						break;
					case AnimOfHow.BaseRotationY:
						animObject.ofsEuler.y = num6;
						break;
					default:
						animObject.ofsEuler.z = num6;
						break;
					}
				}
			}
			Quaternion quaternion = default(Quaternion);
			if (animObject.useRot)
			{
				quaternion = Quaternion.Euler(animObject.euler);
			}
			Quaternion quaternion2 = default(Quaternion);
			if (animObject.useBRot)
			{
				quaternion2 = Quaternion.Euler(animObject.ofsEuler);
			}
			if (animObject.offsetMode)
			{
				if (animObject.usePos)
				{
					if (animObject.useBOfs)
					{
						if (animObject.useBRot)
						{
							transObj.position = animObject.basePos + animObject.baseRot * animObject.ofsPos + animObject.baseRot * quaternion2 * animObject.pos;
						}
						else
						{
							transObj.position = animObject.basePos + animObject.baseRot * animObject.ofsPos + animObject.baseRot * animObject.pos;
						}
					}
					else if (animObject.useBRot)
					{
						transObj.position = animObject.basePos + animObject.baseRot * quaternion2 * animObject.pos;
					}
					else
					{
						transObj.position = animObject.basePos + animObject.baseRot * animObject.pos;
					}
				}
				if (animObject.useRot)
				{
					if (animObject.useBRot)
					{
						transObj.rotation = animObject.baseRot * quaternion2 * quaternion;
					}
					else
					{
						transObj.rotation = animObject.baseRot * quaternion;
					}
				}
				if (animObject.useScl)
				{
					transObj.localScale = animObject.scl;
				}
				continue;
			}
			if (animObject.usePos)
			{
				if (animObject.useBOfs)
				{
					if (animObject.useBRot)
					{
						transObj.localPosition = animObject.baseRot * animObject.ofsPos + quaternion2 * animObject.pos;
					}
					else
					{
						transObj.localPosition = animObject.baseRot * animObject.ofsPos + animObject.pos;
					}
				}
				else if (animObject.useBRot)
				{
					transObj.localPosition = quaternion2 * animObject.pos;
				}
				else
				{
					transObj.localPosition = animObject.pos;
				}
			}
			if (animObject.useRot)
			{
				if (animObject.useBRot)
				{
					transObj.localRotation = quaternion2 * quaternion;
				}
				else
				{
					transObj.localRotation = quaternion;
				}
			}
			if (animObject.useScl)
			{
				transObj.localScale = animObject.scl;
			}
		}
	}
}
