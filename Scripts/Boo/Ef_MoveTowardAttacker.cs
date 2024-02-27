using System;
using UnityEngine;

[Serializable]
public class Ef_MoveTowardAttacker : Ef_Base
{
	private Ef_MoveToward toward;

	public float atkDist;

	public float atkTimer;

	public float atkIntervalMin;

	public float atkIntervalMax;

	public GameObject atkObj;

	public Vector3 atkOffset;

	public Vector3 atkRotOffset;

	public bool destroyOnCollision;

	public GameObject destroyEmitObj;

	public bool yarareColi;

	public string playerYLayer;

	public string enemyYLayer;

	public Ef_MoveTowardAttacker()
	{
		atkDist = 3f;
		atkIntervalMin = 2f;
		atkIntervalMax = 4f;
		atkOffset = new Vector3(0f, 0.5f, 0f);
		atkRotOffset = Vector3.zero;
		destroyOnCollision = true;
		yarareColi = true;
		playerYLayer = "PlayerYarareColi";
		enemyYLayer = "EnemyYarareColi";
	}

	public void Start()
	{
		toward = gameObject.GetComponent<Ef_MoveToward>();
		if ((bool)toward)
		{
			atkTimer = UnityEngine.Random.Range(atkIntervalMin, atkIntervalMax);
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
				Ef_MessageOnCollisionHit ef_MessageOnCollisionHit = gameObject.AddComponent<Ef_MessageOnCollisionHit>();
				ef_MessageOnCollisionHit.target = this.gameObject;
				ef_MessageOnCollisionHit.message = "YarareHit";
				ef_MessageOnCollisionHit.sendCollision = false;
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
		if ((bool)destroyEmitObj)
		{
			UnityEngine.Object.Instantiate(destroyEmitObj, transform.position, transform.rotation);
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

	public void OnCollisionEnter()
	{
		if (!destroyOnCollision)
		{
			return;
		}
		if ((bool)destroyEmitObj)
		{
			UnityEngine.Object.Instantiate(destroyEmitObj, transform.position, transform.rotation);
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
		if (!toward)
		{
			return;
		}
		Vector3 position = transform.position;
		Vector3 position2 = toward.target.position;
		Vector3 forward = new Vector3(position2[0] - position[0], 0f, position2[2] - position[2]);
		position += atkOffset;
		Quaternion rotation = Quaternion.LookRotation(forward, Vector3.up);
		if (atkRotOffset != Vector3.zero)
		{
			rotation *= Quaternion.Euler(atkRotOffset);
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(atkObj, position, rotation);
		MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component != null)
		{
			if (component.Command.parent != null)
			{
				gameObject.layer = this.gameObject.layer;
				MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject.AddComponent<MerlinAttackCommandHolder>();
				merlinAttackCommandHolder.Command = component.Command;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
