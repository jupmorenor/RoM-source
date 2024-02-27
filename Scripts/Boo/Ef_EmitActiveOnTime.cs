using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Ef_EmitActiveManager))]
public class Ef_EmitActiveOnTime : Ef_Base
{
	public bool sleep;

	public float delay;

	public float duration;

	public int numberOfEmit;

	public bool loop;

	public bool deactiveOnEnd;

	private Ef_EmitActiveManager eam;

	private Ef_EmitManager emm;

	private float fstDelay;

	private float fstDuration;

	private int fstNumber;

	private float nextTime;

	private float oneShotTime;

	private bool ready;

	public Ef_EmitActiveOnTime()
	{
		numberOfEmit = 1;
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
		nextTime = fstDuration - oneShotTime;
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
		if (numberOfEmit <= 0)
		{
			numberOfEmit = 1;
		}
		oneShotTime = duration / (float)numberOfEmit;
		nextTime = fstDuration - oneShotTime;
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
		float num = deltaTime;
		if (!(delay <= 0f))
		{
			delay -= num;
			return;
		}
		duration -= num;
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(3).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num2 = enumerator.Current;
					if (duration > nextTime)
					{
						break;
					}
					if (eam != null)
					{
						eam.Emit();
					}
					else if (emm != null)
					{
						emm.Emit();
					}
					numberOfEmit--;
					if (numberOfEmit > 0)
					{
						nextTime -= oneShotTime;
						continue;
					}
					if (loop)
					{
						duration = fstDuration;
						numberOfEmit = fstNumber;
						nextTime = fstDuration - oneShotTime;
						continue;
					}
					sleep = true;
					break;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			if (deactiveOnEnd && sleep)
			{
				gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
				gameObject.SetActive(value: false);
			}
		}
	}
}
