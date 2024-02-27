using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Ef_EmitActiveManager))]
public class Ef_EmitActiveOnDistance : Ef_Base
{
	public bool sleep;

	public float delay;

	public float duration;

	public float distance;

	public bool deactiveOnEnd;

	public int numberOfEmit;

	public float maxMove;

	private Ef_EmitActiveManager eam;

	private Ef_EmitManager emm;

	private float fstDelay;

	private float fstDuration;

	private int fstNumber;

	public Vector3 lstPos;

	public float nextDist;

	private bool ready;

	public Ef_EmitActiveOnDistance()
	{
		distance = 2f;
		maxMove = 1f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		delay = fstDelay;
		duration = fstDuration;
		numberOfEmit = fstNumber;
		lstPos = transform.position;
		nextDist = distance;
		if (eam != null)
		{
			eam.PtReset();
		}
		else if (emm != null)
		{
			emm.PtReset();
		}
		sleep = false;
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
		eam = gameObject.GetComponent<Ef_EmitActiveManager>();
		if (eam == null)
		{
			emm = gameObject.GetComponent<Ef_EmitManager>();
			if (emm == null)
			{
				sleep = true;
			}
		}
		fstDelay = delay;
		fstDuration = duration;
		fstNumber = numberOfEmit;
		lstPos = transform.position;
		nextDist = distance;
		ready = true;
	}

	public void Update()
	{
		if (sleep)
		{
			return;
		}
		if (!ready)
		{
			Init();
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		if (!(duration <= 0f))
		{
			duration -= deltaTime;
			if (!(duration > 0f))
			{
				sleep = true;
			}
		}
		Vector3 position = transform.position;
		Vector3 vector = position - lstPos;
		float num = vector.magnitude;
		if (!(num < maxMove))
		{
			lstPos = position;
			return;
		}
		int num2 = 0;
		while (num2 < 4)
		{
			int num3 = num2;
			num2++;
			if (num < nextDist)
			{
				break;
			}
			if (eam != null)
			{
				eam.Emit(lstPos + vector * nextDist / num);
			}
			else if (emm != null)
			{
				emm.Emit(lstPos + vector * nextDist / num);
			}
			num -= nextDist;
			nextDist = distance;
			checked
			{
				if (numberOfEmit > 0)
				{
					numberOfEmit--;
					if (numberOfEmit == 0)
					{
						sleep = true;
					}
				}
			}
		}
		nextDist -= num;
		lstPos = position;
		if (deactiveOnEnd && sleep)
		{
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(value: false);
		}
	}
}
