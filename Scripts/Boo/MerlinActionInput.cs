using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MerlinActionInput
{
	[Serializable]
	[Flags]
	public enum MerlinActionInputTypes
	{
		None = 0,
		Idle = 1,
		Move = 2,
		Attack = 4,
		Skill1 = 8,
		Skill2 = 0x10,
		Change = 0x20,
		Tap = 0x40,
		Kaihi = 0x80,
		RunAttack = 0x100,
		Battou = 0x200,
		Noutou = 0x400,
		ChangeLockOn = 0x800,
		ChainMySkill = 0x1000,
		ChainFriendSkill = 0x2000
	}

	private MerlinActionInputTypes currentInput;

	private Vector3 moveToPosition;

	private GameObject moveToObject;

	private Boo.Lang.List<int> attackNoList;

	private float kaihiAngle;

	private int chainSkillNo;

	private bool disabled;

	public bool HasMove => (currentInput & MerlinActionInputTypes.Move) != 0;

	public bool HasSkill1 => (currentInput & MerlinActionInputTypes.Skill1) != 0;

	public bool HasSkill2 => (currentInput & MerlinActionInputTypes.Skill2) != 0;

	public bool HasChainMySkill => (currentInput & MerlinActionInputTypes.ChainMySkill) != 0;

	public bool HasChainFriendSkill => (currentInput & MerlinActionInputTypes.ChainFriendSkill) != 0;

	public bool HasChange => (currentInput & MerlinActionInputTypes.Change) != 0;

	public bool HasTap => (currentInput & MerlinActionInputTypes.Tap) != 0;

	public bool HasRunAttack => (currentInput & MerlinActionInputTypes.RunAttack) != 0;

	public bool HasKaihi => (currentInput & MerlinActionInputTypes.Kaihi) != 0;

	public bool HasNoutou => (currentInput & MerlinActionInputTypes.Noutou) != 0;

	public bool HasBattou => (currentInput & MerlinActionInputTypes.Battou) != 0;

	public Vector3 MoveToPosition => (!(moveToObject != null)) ? moveToPosition : moveToObject.transform.position;

	public float KaihiAngle => kaihiAngle;

	public MerlinActionInputTypes CurrentInput => currentInput;

	public int ChainSkillNo => chainSkillNo;

	public MerlinActionInput()
	{
		attackNoList = new Boo.Lang.List<int>();
	}

	public Vector3 moveToDir(Vector3 myPos)
	{
		return MoveToPosition - myPos;
	}

	public bool hasAttack(int atkNo)
	{
		int result;
		bool flag;
		if ((currentInput & MerlinActionInputTypes.Attack) == 0)
		{
			result = 0;
		}
		else
		{
			IEnumerator<int> enumerator = attackNoList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					if (current != atkNo)
					{
						continue;
					}
					flag = true;
					goto IL_0053;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = 0;
		}
		goto IL_0054;
		IL_0054:
		return (byte)result != 0;
		IL_0053:
		result = (flag ? 1 : 0);
		goto IL_0054;
	}

	public void idle()
	{
		setInput(MerlinActionInputTypes.Idle);
	}

	public bool move(Vector3 moveTo)
	{
		setInput(MerlinActionInputTypes.Move);
		moveToPosition = moveTo;
		moveToObject = null;
		return true;
	}

	public bool move(GameObject obj)
	{
		setInput(MerlinActionInputTypes.Move);
		int result;
		if (obj != null)
		{
			moveToPosition = obj.transform.position;
			moveToObject = obj;
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool move()
	{
		setInput(MerlinActionInputTypes.Move);
		return true;
	}

	public bool attack(int _attackNo)
	{
		if (_attackNo <= 0)
		{
			throw new AssertionFailedException(new StringBuilder("入力攻撃番号(attackNo)は１以上(_attackNo=").Append((object)_attackNo).Append(")").ToString());
		}
		setInput(MerlinActionInputTypes.Attack);
		if (!attackNoList.Contains(_attackNo))
		{
			attackNoList.Add(_attackNo);
		}
		return true;
	}

	public void battou()
	{
		setInput(MerlinActionInputTypes.Battou);
	}

	public void noutou()
	{
		setInput(MerlinActionInputTypes.Noutou);
	}

	public void runAttack()
	{
		setInput(MerlinActionInputTypes.RunAttack);
	}

	public void kaihi(float angle)
	{
		setInput(MerlinActionInputTypes.Kaihi);
		kaihiAngle = angle;
	}

	public void skill1()
	{
		setInput(MerlinActionInputTypes.Skill1);
	}

	public void skill2()
	{
		setInput(MerlinActionInputTypes.Skill2);
	}

	public void change()
	{
		setInput(MerlinActionInputTypes.Change);
	}

	public void chainMySkill()
	{
		setInput(MerlinActionInputTypes.ChainMySkill);
	}

	public void chainFriendSkill()
	{
		setInput(MerlinActionInputTypes.ChainFriendSkill);
	}

	public void setInput(MerlinActionInputTypes type)
	{
		if (!disabled)
		{
			currentInput |= type;
		}
	}

	public void enable(bool b)
	{
		disabled = !b;
		if (!b)
		{
			clearAll();
		}
	}

	public bool isEnable()
	{
		return !disabled;
	}

	public void clearAll()
	{
		currentInput = MerlinActionInputTypes.None;
	}

	public void clearEveryFrame()
	{
		clearMove();
		clearKaihi();
		clearTap();
		clearChangeLockOn();
	}

	public void clearEveryMotionChange()
	{
		clearIdle();
		clearAttack();
		clearNoutouBattou();
	}

	public void clearIdle()
	{
		currentInput &= ~MerlinActionInputTypes.Idle;
	}

	public void clearMove()
	{
		currentInput &= ~MerlinActionInputTypes.Move;
	}

	public void clearKaihi()
	{
		currentInput &= ~MerlinActionInputTypes.Kaihi;
	}

	public void clearTap()
	{
		currentInput &= ~MerlinActionInputTypes.Tap;
	}

	public void clearChangeLockOn()
	{
		currentInput &= ~MerlinActionInputTypes.ChangeLockOn;
	}

	public void clearSkillAndChange()
	{
		currentInput &= ~MerlinActionInputTypes.Skill1;
		currentInput &= ~MerlinActionInputTypes.Skill2;
		currentInput &= ~MerlinActionInputTypes.Change;
		currentInput &= ~MerlinActionInputTypes.ChainMySkill;
		currentInput &= ~MerlinActionInputTypes.ChainFriendSkill;
	}

	public void clearSkills()
	{
		currentInput &= ~MerlinActionInputTypes.Skill1;
		currentInput &= ~MerlinActionInputTypes.Skill2;
		currentInput &= ~MerlinActionInputTypes.ChainMySkill;
		currentInput &= ~MerlinActionInputTypes.ChainFriendSkill;
	}

	public void clearNoutouBattou()
	{
		currentInput &= ~MerlinActionInputTypes.Noutou;
		currentInput &= ~MerlinActionInputTypes.Battou;
	}

	public void clearAttack()
	{
		currentInput &= ~MerlinActionInputTypes.Attack;
		currentInput &= ~MerlinActionInputTypes.RunAttack;
		attackNoList.Clear();
	}
}
