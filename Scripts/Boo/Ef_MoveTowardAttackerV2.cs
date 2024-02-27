using System;
using UnityEngine;

[Serializable]
public class Ef_MoveTowardAttackerV2 : Ef_Base
{
	public Ef_MoveTowardV2 toward;

	public float atkDist;

	public float atkTimer;

	public float atkIntervalMin;

	public float atkIntervalMax;

	public Vector3 atkOffset;

	public bool yarareColi;

	public string playerYLayer;

	public string enemyYLayer;

	private bool activeMode;

	private Ef_EmitActiveManager emitActive;

	private Ef_EmitManager emitManager;

	private bool ready;

	public Ef_MoveTowardAttackerV2()
	{
		atkDist = 3f;
		atkIntervalMin = 2f;
		atkIntervalMax = 4f;
		atkOffset = new Vector3(0f, 0.5f, 0f);
		yarareColi = true;
		playerYLayer = "PlayerYarareColi";
		enemyYLayer = "EnemyYarareColi";
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		atkTimer = UnityEngine.Random.Range(atkIntervalMin, atkIntervalMax);
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
		toward = gameObject.GetComponent<Ef_MoveTowardV2>();
		if ((bool)toward)
		{
			atkTimer = UnityEngine.Random.Range(atkIntervalMin, atkIntervalMax);
			Ef_ActiveOn component = gameObject.GetComponent<Ef_ActiveOn>();
			bool num = component != null;
			if (num)
			{
				num = component.enable;
			}
			activeMode = num;
			emitActive = gameObject.GetComponent<Ef_EmitActiveManager>();
			emitManager = gameObject.GetComponent<Ef_EmitManager>();
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (emtr == null)
		{
			return;
		}
		GameObject gameObject = null;
		if (yarareColi)
		{
			gameObject = new GameObject("YarareColi");
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			SphereCollider component = this.gameObject.GetComponent<SphereCollider>();
			if ((bool)component)
			{
				SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
				sphereCollider.center = component.center;
				sphereCollider.radius = component.radius;
				Ef_SendMessageOnCollisionHit ef_SendMessageOnCollisionHit = gameObject.AddComponent<Ef_SendMessageOnCollisionHit>();
				ef_SendMessageOnCollisionHit.target = this.gameObject;
				ef_SendMessageOnCollisionHit.message = "YarareHit";
				ef_SendMessageOnCollisionHit.sendCollision = false;
			}
			if (emtr.IsSidePlayer)
			{
				gameObject.layer = LayerMask.NameToLayer(playerYLayer);
			}
			else if (emtr.IsSideEnemy)
			{
				gameObject.layer = LayerMask.NameToLayer(enemyYLayer);
			}
		}
	}

	public void Update()
	{
		if (!toward)
		{
			return;
		}
		Vector3 position = transform.position;
		if (!toward.target)
		{
			return;
		}
		Vector3 position2 = toward.target.position;
		float sqrMagnitude = new Vector2(position2[0] - position[0], position2[2] - position[2]).sqrMagnitude;
		if (sqrMagnitude <= atkDist * atkDist)
		{
			atkTimer -= deltaTime;
			if (!(atkTimer > 0f))
			{
				EmitAttack();
				toward.LookTarget();
				toward.speed = -1f;
				toward.angSpd = 0f;
				atkTimer = UnityEngine.Random.Range(atkIntervalMin, atkIntervalMax);
			}
		}
	}

	public void YarareHit()
	{
		if (activeMode)
		{
			if (emitActive != null)
			{
				emitActive.EmitOnHit();
			}
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(value: false);
			return;
		}
		if (emitManager != null)
		{
			emitManager.EmitOnHit();
		}
		Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public void EmitAttack()
	{
		if ((bool)toward)
		{
			Vector3 position = transform.position;
			Vector3 vector = default(Vector3);
			if (toward.target != null)
			{
				vector = toward.target.position;
			}
			Vector3 forward = new Vector3(vector[0] - position[0], 0f, vector[2] - position[2]);
			position += atkOffset;
			Quaternion rot = Quaternion.LookRotation(forward, Vector3.up);
			if (activeMode && emitActive != null)
			{
				emitActive.EmitOnShot(position, rot);
			}
			else if (emitManager != null)
			{
				emitManager.EmitOnShot(position, rot);
			}
		}
	}
}
