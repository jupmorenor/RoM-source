using UnityEngine;

public class Move : MonoBehaviour
{
	public float pushPower = 10f;

	private float angH;

	private float angV;

	private bool isGround;

	private void Start()
	{
		Screen.lockCursor = true;
	}

	private void Update()
	{
		angH += Input.GetAxis("Mouse X") * 10f;
		angV += Input.GetAxis("Mouse Y") * 10f;
		Quaternion quaternion = Quaternion.Euler(0f - angV, angH, 0f);
		Vector3 zero = Vector3.zero;
		if (Input.GetKey(KeyCode.W))
		{
			zero.z = 2f;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			zero.z = -2f;
		}
		if (Input.GetKey(KeyCode.A))
		{
			zero.x = -2f;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			zero.x = 2f;
		}
		zero = quaternion * zero;
		zero.y = 0f;
		zero = zero.normalized;
		base.rigidbody.AddForce(zero * 10f);
		base.rigidbody.velocity = base.rigidbody.velocity * 0.9f;
		base.transform.rotation = quaternion;
		if (Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			base.rigidbody.AddForce(0f, 1000f, 0f);
		}
		if (Input.GetMouseButton(0))
		{
			Screen.lockCursor = !Screen.lockCursor;
		}
		isGround = false;
	}

	private void OnCollisionStay()
	{
		isGround = true;
	}

	private void OnCollisionEnter(Collision hit)
	{
		Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;
		if (!(attachedRigidbody == null) && !attachedRigidbody.isKinematic)
		{
			Vector3 normalized = (hit.transform.position - base.transform.position).normalized;
			attachedRigidbody.velocity = normalized * pushPower;
		}
	}
}
