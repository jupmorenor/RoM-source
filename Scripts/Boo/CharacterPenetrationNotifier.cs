using System;
using System.Runtime.CompilerServices;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class CharacterPenetrationNotifier : MonoBehaviour
{
	private float threasholdTime;

	private int collisionLayer;

	private bool working;

	private float enteringTime;

	private Collider enteringCollider;

	private __CharacterPenetrationNotifier_Message_0024callable57_002412_22__ _0024event_0024Message;

	public float ThreasholdTime
	{
		get
		{
			return threasholdTime;
		}
		set
		{
			threasholdTime = value;
		}
	}

	public int CollisionLayer
	{
		get
		{
			return collisionLayer;
		}
		set
		{
			collisionLayer = value;
		}
	}

	public bool Active
	{
		get
		{
			return working;
		}
		set
		{
			working = value;
		}
	}

	public event __CharacterPenetrationNotifier_Message_0024callable57_002412_22__ Message
	{
		add
		{
			_0024event_0024Message = (__CharacterPenetrationNotifier_Message_0024callable57_002412_22__)Delegate.Combine(_0024event_0024Message, value);
		}
		remove
		{
			_0024event_0024Message = (__CharacterPenetrationNotifier_Message_0024callable57_002412_22__)Delegate.Remove(_0024event_0024Message, value);
		}
	}

	public CharacterPenetrationNotifier()
	{
		threasholdTime = 5f;
		working = true;
	}

	[SpecialName]
	protected internal void raise_Message(CharacterPenetrationNotifier arg0, GameObject arg1, Collider arg2)
	{
		_0024event_0024Message?.Invoke(arg0, arg1, arg2);
	}

	public void activate()
	{
		enteringTime = 0f;
		enteringCollider = null;
		working = true;
	}

	public void deactivate()
	{
		working = false;
	}

	public void OnCollisionEnter(Collision coli)
	{
		enteringTime = 0f;
		enteringCollider = null;
	}

	public void OnCollisionExit(Collision coli)
	{
		enteringTime = 0f;
		enteringCollider = null;
	}

	public void OnCollisionStay(Collision coli)
	{
		Collider collider = coli.collider;
		if (working && !(collider == null) && !collider.isTrigger)
		{
			enteringTime += Time.fixedDeltaTime;
			enteringCollider = collider;
			if (!(enteringTime <= threasholdTime))
			{
				raise_Message(this, gameObject, collider);
				enteringTime = 0f;
			}
		}
	}
}
