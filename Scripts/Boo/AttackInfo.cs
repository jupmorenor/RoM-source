using System;
using UnityEngine;

[Serializable]
public class AttackInfo : MonoBehaviour
{
	public int power;

	public int breakPower;

	public bool noneDown;

	public bool invalidSuperArmor;

	public GameObject attackChar;

	public EnumElements zokuseiAtk;

	public GameObject nageBone;

	public float knockBackPow;
}
