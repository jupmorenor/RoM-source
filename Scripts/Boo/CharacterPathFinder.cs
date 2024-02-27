using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CharacterPathFinder : Pathfinding
{
	private PlayerControl player;

	private float totalPathDistance;

	private CharacterController charControl;

	private MerlinMotionPackControl mmpc;

	public float TotalPathDistance => totalPathDistance;

	public void Reset()
	{
		pathQueue.Clear();
		isMovement = false;
	}

	public void Goto(Vector3 vDestPos)
	{
		FindPath(transform.position, vDestPos);
	}

	public void Stop()
	{
		pathQueue.Clear();
		isMovement = false;
		if (PlayerControl.ForceToSetInputType == PlayerInputControlType.ByTouch)
		{
			player.standGround(transform);
			player.UpdateMakerPos(transform.position);
		}
		player.ActionInput.move(transform.position);
		player.ActionInput.clearMove();
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

	private bool IsArriveAtPathNode(Vector3 vNextPos)
	{
		float currentMoveSpeed = player.CurrentMoveSpeed;
		if (!(currentMoveSpeed > 0f))
		{
		}
		float num = Time.deltaTime * player.CurrentMoveSpeed;
		num *= num;
		float sqrMagnitude = (vNextPos - transform.position).sqrMagnitude;
		int result;
		if (!(num < sqrMagnitude))
		{
			transform.position = vNextPos;
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void Start()
	{
		mmpc = GetComponent<MerlinMotionPackControl>();
		if (!(mmpc != null))
		{
			throw new AssertionFailedException("Cannot found MMPC!");
		}
		player = gameObject.GetComponent("PlayerControl") as PlayerControl;
		charControl = GetComponent<CharacterController>();
		if (!(charControl != null))
		{
			throw new AssertionFailedException("Cannot found CharacterController!");
		}
	}

	public void Update()
	{
		if (isMovement || !DebugLine || charControl == null)
		{
			return;
		}
		float height = charControl.height;
		Vector3 zero = Vector3.zero;
		Vector3 vector = Vector3.zero;
		foreach (Vector3 drawPath in drawPathList)
		{
			zero = drawPath;
			zero.y += height;
			if (vector == Vector3.zero)
			{
				vector = zero;
				Debug.DrawLine(drawPath, zero, Color.red);
			}
			else
			{
				Debug.DrawLine(vector, zero, Color.red);
				Debug.DrawLine(drawPath, zero, Color.red);
				vector = zero;
			}
		}
	}

	public void updateActionInput()
	{
		if (mmpc == null || player.Pause || !isMovement)
		{
			return;
		}
		if (pathQueue.Count > 0)
		{
			Vector3 vector = pathQueue.Peek();
			if (IsArriveAtPathNode(vector))
			{
				pathQueue.Dequeue();
				if (pathQueue.Count > 0)
				{
					player.ActionInput.move(vector);
				}
			}
			else
			{
				player.ActionInput.move(vector);
			}
		}
		else
		{
			isMovement = false;
		}
	}
}
