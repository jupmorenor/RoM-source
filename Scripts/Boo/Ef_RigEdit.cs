using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_RigEdit : MonoBehaviour
{
	public Ef_RigIK ik;

	public Ef_RigSpine sp;

	public Ef_RigHead hd;

	public Ef_RigClavicle cv;

	public bool initialize;

	public bool setMinDistAngs;

	public bool resetRotation;

	public Transform target;

	public Transform upVector;

	public Quaternion[] fstRots;

	public bool initializeSpine;

	public bool initializeHead;

	public bool initialzieClavicle;

	public bool setDefaultClavicle;

	public void Update()
	{
		IKSet();
		SpineSet();
		HeadSet();
		ClavicleSet();
		DefaultClavicle();
	}

	public void IKSet()
	{
		if (initialize)
		{
			initialize = false;
			if (!ik)
			{
				ik = gameObject.GetComponent<Ef_RigIK>();
			}
			if (!ik)
			{
				return;
			}
			ik.Initialize();
			fstRots = new Quaternion[ik.arrTfs.Length];
			int num = 0;
			int length = ik.arrTfs.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				Transform[] arrTfs = ik.arrTfs;
				if ((bool)arrTfs[RuntimeServices.NormalizeArrayIndex(arrTfs, index)])
				{
					Quaternion[] array = fstRots;
					ref Quaternion reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
					Transform[] arrTfs2 = ik.arrTfs;
					reference = arrTfs2[RuntimeServices.NormalizeArrayIndex(arrTfs2, index)].localRotation;
				}
			}
		}
		if (setMinDistAngs)
		{
			setMinDistAngs = false;
			if (!ik)
			{
				ik = gameObject.GetComponent<Ef_RigIK>();
			}
			if (!ik)
			{
				return;
			}
			ik.SetMinDistAngs();
		}
		if (!resetRotation)
		{
			return;
		}
		resetRotation = false;
		int num2 = 0;
		int length2 = ik.arrTfs.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length2)
		{
			int index2 = num2;
			num2++;
			Transform[] arrTfs3 = ik.arrTfs;
			if ((bool)arrTfs3[RuntimeServices.NormalizeArrayIndex(arrTfs3, index2)])
			{
				Transform[] arrTfs4 = ik.arrTfs;
				Transform obj = arrTfs4[RuntimeServices.NormalizeArrayIndex(arrTfs4, index2)];
				Quaternion[] array2 = fstRots;
				obj.localRotation = array2[RuntimeServices.NormalizeArrayIndex(array2, index2)];
			}
		}
	}

	public void SpineSet()
	{
		if (initializeSpine)
		{
			if (!sp)
			{
				sp = gameObject.GetComponent<Ef_RigSpine>();
			}
			if ((bool)sp)
			{
				sp.Initialize();
				initializeSpine = false;
			}
		}
	}

	public void HeadSet()
	{
		if (initializeHead)
		{
			if (!hd)
			{
				hd = gameObject.GetComponent<Ef_RigHead>();
			}
			if ((bool)hd)
			{
				hd.Initialize();
				initializeHead = false;
			}
		}
	}

	public void ClavicleSet()
	{
		if (initialzieClavicle)
		{
			if (!cv)
			{
				cv = gameObject.GetComponent<Ef_RigClavicle>();
			}
			if ((bool)cv)
			{
				cv.Initialize();
				initialzieClavicle = false;
			}
		}
	}

	public void DefaultClavicle()
	{
		if (setDefaultClavicle)
		{
			if (!cv)
			{
				cv = gameObject.GetComponent<Ef_RigClavicle>();
			}
			if ((bool)cv)
			{
				cv.maxDistanceRange = 0.4f;
				cv.minDistanceRange = 0.1f;
				cv.maxDistanceAng = 20f;
				cv.minDistanceAng = 0f;
				cv.distancePivot = Ef_RigClavicle.Axis.Z;
				cv.maxPosRangeX = 0.1f;
				cv.minPosRangeX = -0.4f;
				cv.maxXPosAng = -20f;
				cv.minXPosAng = 0f;
				cv.xPosPivot = Ef_RigClavicle.Axis.Z;
				cv.maxPosRangeY = 0.5f;
				cv.minPosRangeY = -0.2f;
				cv.maxYPosAng = -20f;
				cv.minYPosAng = 5f;
				cv.yPosPivot = Ef_RigClavicle.Axis.Y;
				cv.maxPosRangeZ = 0.5f;
				cv.minPosRangeZ = 0f;
				cv.maxZposAng = -20f;
				cv.minZposAng = 0f;
				cv.zPosPivot = Ef_RigClavicle.Axis.Z;
				cv.maxUpVectorY = 0.5f;
				cv.minUpVectorY = -0.5f;
				cv.maxUpVectorYAng = 20f;
				cv.minUpVectorYAng = -20f;
				cv.minUpVectorYPivot = Ef_RigClavicle.Axis.X;
				setDefaultClavicle = false;
			}
		}
	}
}
