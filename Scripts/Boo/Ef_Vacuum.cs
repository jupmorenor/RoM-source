using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Vacuum : Ef_Base
{
	public float delay;

	public float life;

	public float power;

	public float maxDistance;

	public float minDistance;

	public int halfAngle;

	public float offset;

	public int maxNum;

	public BaseControl[] targets;

	public bool fromEffectMessage;

	public bool puppet;

	public bool enemy;

	public bool ready;

	public bool end;

	private float fstDelay;

	private float fstLife;

	private CutSceneManager _cutSceneMan;

	private CutSceneManager cutSceneMan
	{
		get
		{
			CutSceneManager result;
			if ((bool)_cutSceneMan)
			{
				result = _cutSceneMan;
			}
			else
			{
				_cutSceneMan = CutSceneManager.Instance;
				result = _cutSceneMan;
			}
			return result;
		}
	}

	public Ef_Vacuum()
	{
		life = 1f;
		power = 8f;
		maxDistance = 8f;
		minDistance = 0.1f;
		halfAngle = 60;
		offset = 1.5f;
		maxNum = 10;
		fromEffectMessage = true;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (fromEffectMessage && !(emtr == null))
		{
			puppet = emtr.IsSidePlayer;
			enemy = emtr.IsSideEnemy;
		}
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		delay = fstDelay;
		life = fstLife;
		end = false;
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
		fstDelay = delay;
		fstLife = life;
		targets = new BaseControl[maxNum];
	}

	public void LateUpdate()
	{
		if (((bool)cutSceneMan && cutSceneMan.isBusy) || end)
		{
			return;
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		if (!ready)
		{
			FindTarget();
			if (!ready)
			{
				return;
			}
		}
		if (!(life <= 0f))
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				end = true;
				return;
			}
		}
		UpdateVacuum();
	}

	public void UpdateVacuum()
	{
		Vector3 forward = transform.forward;
		Vector3 position = transform.position;
		Vector3 vector = position + forward * offset;
		int i = 0;
		BaseControl[] array = targets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!array[i])
			{
				continue;
			}
			Vector3 position2 = array[i].transform.position;
			Vector3 to = position2 - position;
			to.y = 0f;
			float magnitude = to.magnitude;
			if (!(magnitude > maxDistance) && magnitude >= minDistance && Vector3.Angle(forward, to) <= (float)halfAngle)
			{
				Vector3 vector2 = vector - position2;
				vector2.y = 0f;
				vector2 = vector2.normalized * Mathf.Min(power * deltaTime, magnitude);
				MerlinActionControl component = array[i].gameObject.GetComponent<MerlinActionControl>();
				if (component != null)
				{
					component.addVolatileMovement(vector2);
					float fixedDeltaTime = Time.fixedDeltaTime;
					Time.fixedDeltaTime = 0f;
					component.FixedUpdate();
					Time.fixedDeltaTime = fixedDeltaTime;
				}
				else
				{
					array[i].transform.position = array[i].transform.position + vector2;
				}
			}
		}
	}

	public void FindTarget()
	{
		int num = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		BaseControl baseControl = null;
		checked
		{
			if (enemy)
			{
				IEnumerator enumerator = allControls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is BaseControl))
					{
						obj = RuntimeServices.Coerce(obj, typeof(BaseControl));
					}
					baseControl = (BaseControl)obj;
					if ((bool)baseControl.GetComponent<MagicSkill>() || (bool)baseControl.GetComponent<PlayerControl>())
					{
						BaseControl[] array = targets;
						array[RuntimeServices.NormalizeArrayIndex(array, num)] = baseControl;
						num++;
						if (num > maxNum)
						{
							break;
						}
					}
				}
				ready = true;
			}
			if (!puppet)
			{
				return;
			}
			IEnumerator enumerator2 = allControls.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is BaseControl))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(BaseControl));
				}
				baseControl = (BaseControl)obj2;
				MagicSkill component = baseControl.GetComponent<MagicSkill>();
				if (!baseControl.GetComponent<MagicSkill>() && !baseControl.GetComponent<PlayerControl>())
				{
					BaseControl[] array2 = targets;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = baseControl;
					num++;
					if (num > maxNum)
					{
						break;
					}
				}
			}
			ready = true;
		}
	}
}
