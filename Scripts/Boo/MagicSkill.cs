using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MagicSkill : MonoBehaviour
{
	public Vector3 mapetPosOffset;

	private float maxMagicPoint;

	private float magicPoint;

	private AIControl poppetAI;

	private MagicSkillDelegate magicSkillDelegate;

	public bool IsFullCharge => !(magicPoint < maxMagicPoint);

	public float MaxMagicPoint
	{
		get
		{
			return maxMagicPoint;
		}
		set
		{
			maxMagicPoint = value;
		}
	}

	public float MagicPoint => magicPoint;

	public AIControl PoppetAI => poppetAI;

	public MagicSkill()
	{
		maxMagicPoint = 1000f;
	}

	public void Awake()
	{
		poppetAI = gameObject.GetComponent<AIControl>();
		magicSkillDelegate = new MagicSkillQuestDelegate();
	}

	public void Start()
	{
		magicSkillDelegate.start(this);
	}

	public void Update()
	{
		magicSkillDelegate.update(this);
	}

	public void setDelegate(MagicSkillDelegate d)
	{
		if (d == null)
		{
			throw new AssertionFailedException("d != null");
		}
		magicSkillDelegate = d;
	}

	public void useSkill()
	{
		magicSkillDelegate.useSkill(this);
	}

	public bool canUseSkill()
	{
		return magicSkillDelegate.canUseSkill(this);
	}

	public void zeroMagicPoint()
	{
		magicPoint = 0f;
		magicSkillDelegate.magicPointChanged(this);
	}

	public void addMagicPoint(int point)
	{
		if (!ChainSkillRoutine.IsPlayingPoppet(poppetAI))
		{
			bool flag = !canUseSkill();
			bool num = magicPoint < maxMagicPoint;
			if (num)
			{
				num = !(magicPoint + (float)point < maxMagicPoint);
			}
			bool flag2 = num;
			magicPoint = Mathf.Min(magicPoint + (float)point, maxMagicPoint);
			if (flag2 && flag)
			{
				magicSkillDelegate.magicPointFullCharged(this);
			}
			if (flag2)
			{
				PlayerEventDispatcher.InvokeMagicCharge(poppetAI);
			}
			magicSkillDelegate.magicPointChanged(this);
		}
	}

	public void setMagicPoint(float v)
	{
		magicPoint = Mathf.Clamp(v, 0f, maxMagicPoint);
	}

	public int addMagicPointRate(float rate)
	{
		float num = maxMagicPoint * rate;
		checked
		{
			addMagicPoint((int)num);
			return (int)num;
		}
	}

	public void setPoppetIndexOfPlayer(int index)
	{
		magicSkillDelegate.setPoppetIndexOfPlayer(this, index);
	}
}
