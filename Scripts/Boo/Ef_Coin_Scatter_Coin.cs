using System;
using UnityEngine;

[Serializable]
public class Ef_Coin_Scatter_Coin : Ef_Base
{
	public Transform target;

	public float life;

	public Vector3 velocity;

	public float fastBrake;

	public float accel;

	public float homing;

	public float jumpPow;

	public float gravity;

	public Vector3 rotVec;

	public GameObject getObj;

	public int money;

	private Vector3 pos;

	private bool brake;

	private float jumpVel;

	private float jumpPos;

	private Vector3 targetPosition;

	private Vector3 vec;

	private float mag;

	public Ef_Coin_Scatter_Coin()
	{
		life = 5f;
		velocity = new Vector3(0f, 0f, 10f);
		fastBrake = 3f;
		accel = 0.5f;
		homing = 10f;
		jumpPow = 0.2f;
		gravity = 0.5f;
		rotVec = new Vector3(0f, 720f, 0f);
		money = 10;
		brake = true;
		jumpVel = jumpPow;
		jumpPos = 0.5f;
		targetPosition = Vector3.zero;
		vec = Vector3.zero;
	}

	public void Start()
	{
		pos = this.transform.position;
		jumpVel *= UnityEngine.Random.Range(0.2f, 1f);
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if ((bool)currentPlayer)
		{
			target = currentPlayer.transform;
			Transform transform = target.Find("y_ang");
			if ((bool)transform)
			{
				target = transform;
			}
		}
		else
		{
			target = this.transform;
		}
	}

	public void FixedUpdate()
	{
		if ((bool)target)
		{
			targetPosition = target.position;
		}
		vec = targetPosition - pos;
		mag = vec.magnitude;
		if (mag < 0.5f || !(mag <= 100f))
		{
			life = 0f;
		}
		life -= deltaTime;
		if (!(life > 0f))
		{
			if ((bool)getObj)
			{
				UnityEngine.Object.Instantiate(getObj, transform.position, Quaternion.identity);
			}
			QuestParam.EarnMoney(money);
			money = 0;
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (brake)
		{
			velocity *= 1f - fastBrake * deltaTime;
			if (!(velocity.magnitude > 0.05f))
			{
				brake = false;
			}
		}
		else
		{
			velocity += vec * (1f + accel) * deltaTime;
			Quaternion to = Quaternion.FromToRotation(velocity, vec);
			velocity = Quaternion.Lerp(Quaternion.identity, to, homing * deltaTime) * velocity;
		}
		pos += velocity * deltaTime;
		if (!(jumpPos > 0.25f))
		{
			jumpPos = 0.25f;
			jumpVel = jumpPow;
			jumpPow *= 0.9f;
		}
		jumpPos += jumpVel;
		jumpVel -= gravity * deltaTime;
		Vector3 position = pos;
		position.y += jumpPos;
		transform.position = position;
		transform.rotation *= Quaternion.Euler(rotVec * deltaTime);
	}

	public void OnDestroy()
	{
		QuestParam.EarnMoney(money);
	}
}
