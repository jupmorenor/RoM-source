using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestGeometricSessionData
{
	public Vector3 playerPosition;

	public float playerYAngle;

	public float playerHP;

	public float playerRecoveryDamage;

	public float playerSkillCooldown;

	public float playerChangeCooldown;

	public float[] playerMagicPoint;

	public Vector3[] poppetPositions;

	public QuestGeometricSessionData()
	{
		playerPosition = Vector3.zero;
		playerMagicPoint = new float[0];
		poppetPositions = new Vector3[0];
		clear();
	}

	public void clear()
	{
		playerPosition = Vector3.zero;
		playerHP = 0f;
		playerRecoveryDamage = 0f;
		playerSkillCooldown = 0f;
		playerChangeCooldown = 0f;
		playerMagicPoint = new float[0];
		poppetPositions = new Vector3[0];
	}

	public void bookkeep(PlayerControl p)
	{
		if (p == null)
		{
			return;
		}
		playerPosition = p.transform.position;
		playerYAngle = p.transform.rotation.eulerAngles.y;
		playerHP = p.HitPoint;
		playerRecoveryDamage = p.RecoveryDamage;
		playerSkillCooldown = p.WeaponSkillCooldown?.Current ?? 0f;
		playerChangeCooldown = p.ChangeCooldown.Current;
		playerMagicPoint = p.getMagicPointList();
		AIControl[] poppets = p.Poppets;
		Vector3[] array = new Vector3[poppets.Length];
		int num = 0;
		int length = poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)] != null)
			{
				ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
				reference = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)].transform.position;
			}
		}
		poppetPositions = array;
	}

	public void restore(PlayerControl p)
	{
		if (p == null)
		{
			return;
		}
		p.setHP(playerHP);
		p.setRecoveryDamage(playerRecoveryDamage);
		if (p.WeaponSkillCooldown != null)
		{
			p.WeaponSkillCooldown.Current = playerSkillCooldown;
		}
		p.setMagicPoints(playerMagicPoint);
		p.transform.position = playerPosition;
		p.transform.rotation = Quaternion.Euler(0f, playerYAngle, 0f);
		AIControl[] poppets = p.Poppets;
		int num = 0;
		int length = poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
			if (!(aIControl == null))
			{
				Transform transform = aIControl.transform;
				Vector3[] array = poppetPositions;
				transform.position = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			}
		}
	}
}
