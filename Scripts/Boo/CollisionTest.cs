using System;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class CollisionTest : MonoBehaviour
{
	[Serializable]
	public class ATTACK_INFO
	{
		public Collider bone;

		public float start;

		public float end;
	}

	public CharacterController coli;

	public Transform y_ang;

	private Vector3 centerInit;

	public ATTACK_INFO[] attackInfo;

	public ATTACK_INFO[,] testArray;

	public CollisionTest()
	{
		attackInfo = new ATTACK_INFO[2];
		testArray = (ATTACK_INFO[,])Builtins.matrix(typeof(ATTACK_INFO), 2, 3);
	}

	public void Start()
	{
		centerInit = coli.center;
	}

	public void Update()
	{
		Vector3 center = centerInit + y_ang.position - transform.position;
		center.x *= transform.right.z;
		center.z *= transform.right.x;
		coli.center = center;
		Debug.Log(transform.right);
	}
}
