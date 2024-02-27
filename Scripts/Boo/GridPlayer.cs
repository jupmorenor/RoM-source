using System;
using UnityEngine;

[Serializable]
public class GridPlayer : Pathfinding
{
	private string IDLE;

	private string MOVE;

	private Animation Anim;

	public float movespeed;

	public GridPlayer()
	{
		IDLE = "Idle01";
		MOVE = "run";
		movespeed = 6f;
	}

	private float DirectionToDegreeRotationY(Vector3 vDir)
	{
		Vector3 rhs = vDir;
		if (rhs.y != 0f)
		{
			rhs.y = 0f;
			rhs.Normalize();
		}
		float f = Vector3.Dot(Vector3.forward, rhs);
		f = ((rhs.x >= 0f) ? (0f - Mathf.Acos(f)) : Mathf.Acos(f));
		return f * -57.29578f;
	}

	public void SetRotationY(Vector3 vTargetPos)
	{
		Vector3 vector = vTargetPos - transform.position;
		vector.y = 0f;
		vector.Normalize();
		if (!(vector == Vector3.zero))
		{
			float angle = DirectionToDegreeRotationY(vector);
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
			transform.rotation = rotation;
		}
	}

	public void Start()
	{
		Anim = GameObject.Find("C0000Test").GetComponent<Animation>();
		if (Anim == null)
		{
		}
		Anim[IDLE].wrapMode = WrapMode.Loop;
		Anim[MOVE].wrapMode = WrapMode.Loop;
		Anim.Play(IDLE);
	}

	public void Update()
	{
		if (!(Pathfinder.Instance == null))
		{
			if (!Pathfinder.Instance.IsEditMode)
			{
				FindPath();
			}
			if (Path.Count > 0)
			{
				MoveMethod();
			}
			else if (Anim != null)
			{
				Anim.Play(IDLE);
			}
		}
	}

	private void FindPath()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity))
			{
				Vector3 point = hitInfo.point;
				FindPath(transform.position, hitInfo.point);
			}
		}
	}

	private void MoveMethod()
	{
		if (Path.Count <= 0)
		{
			return;
		}
		Vector3 normalized = (Path[0] - transform.position).normalized;
		SetRotationY(Path[0]);
		transform.position = Vector3.MoveTowards(transform.position, transform.position + normalized, Time.deltaTime * movespeed);
		if (!(transform.position.x >= Path[0].x + 0.4f) && !(transform.position.x <= Path[0].x - 0.4f) && !(transform.position.z <= Path[0].z - 0.4f) && !(transform.position.z >= Path[0].z + 0.4f))
		{
			Path.RemoveAt(0);
		}
		RaycastHit[] array = Physics.RaycastAll(transform.position + Vector3.up * 20f, Vector3.down, 100f);
		float num = float.NegativeInfinity;
		int i = 0;
		RaycastHit[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (array2[i].transform.tag == "ground" && !(num >= array2[i].point.y))
			{
				num = array2[i].point.y;
			}
		}
		transform.position = new Vector3(transform.position.x, num + 1f, transform.position.z);
		Anim.Play(MOVE);
	}
}
