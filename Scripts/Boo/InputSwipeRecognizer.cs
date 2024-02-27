using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class InputSwipeRecognizer
{
	[Serializable]
	public class FingerInfo
	{
		public bool touches;

		public Vector2 startPosition;

		public float swipingTime;

		public bool updated;

		public bool swiped;

		public float speed;

		public Vector2 move;

		public float distance;

		public void clear()
		{
			touches = false;
			swipingTime = 0f;
			swiped = false;
			distance = 0f;
		}

		public bool updateTouch(bool began, Vector2 position, float dt)
		{
			swiped = false;
			updated = true;
			speed = 0f;
			distance = 0f;
			move = Vector2.zero;
			int result;
			if (began)
			{
				startPosition = position;
				swipingTime = 0f;
				touches = true;
				result = 0;
			}
			else
			{
				swipingTime += dt;
				if (!(swipingTime > 0f))
				{
					result = 0;
				}
				else
				{
					move = position - startPosition;
					distance = move.magnitude;
					speed = distance / swipingTime;
					if (!(distance >= MIN_DISTANCE))
					{
						result = 0;
					}
					else if (!(speed >= MIN_VELOCITY))
					{
						result = 0;
					}
					else
					{
						startPosition = position;
						swiped = true;
						result = 1;
					}
				}
			}
			return (byte)result != 0;
		}

		public void updateNotTouch(float dt)
		{
			clear();
		}

		public void onGUI()
		{
			GUILayout.Label(new StringBuilder("[t:").Append(onoff(touches)).Append(" swiped:").Append(onoff(swiped))
				.Append(" spd:")
				.Append(speed)
				.Append(" distance:")
				.Append(distance)
				.Append(" tm:")
				.Append(swipingTime)
				.Append("]")
				.ToString());
		}

		private string onoff(bool b)
		{
			return (!b) ? "x" : "o";
		}
	}

	[NonSerialized]
	public static float MIN_VELOCITY = 400f;

	[NonSerialized]
	public static float MIN_DISTANCE = 40f;

	private bool swiped;

	private Vector3 swipeDir;

	private FingerInfo[] fingerInfo;

	public bool Swiped => swiped;

	public Vector3 SwipeDir => swipeDir;

	public InputSwipeRecognizer()
	{
		fingerInfo = new FingerInfo[5];
		clear();
	}

	public void clear()
	{
		swiped = false;
		int num = 0;
		int length = fingerInfo.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			FingerInfo[] array = fingerInfo;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = new FingerInfo();
		}
	}

	public bool isSwiped(int fingerId)
	{
		int result;
		if (0 <= fingerId && fingerId < fingerInfo.Length)
		{
			FingerInfo[] array = fingerInfo;
			result = (array[RuntimeServices.NormalizeArrayIndex(array, fingerId)].swiped ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool isSwipedNot(int fingerId)
	{
		int num = 0;
		int length = fingerInfo.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < length)
			{
				int num2 = num;
				num++;
				if (num2 != fingerId)
				{
					FingerInfo[] array = fingerInfo;
					if (array[RuntimeServices.NormalizeArrayIndex(array, num2)].swiped)
					{
						result = 1;
						break;
					}
				}
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public int swipeFingerIndexNot(int fingerId)
	{
		int num = 0;
		int length = fingerInfo.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < length)
			{
				int num2 = num;
				num++;
				if (num2 != fingerId)
				{
					FingerInfo[] array = fingerInfo;
					if (array[RuntimeServices.NormalizeArrayIndex(array, num2)].swiped)
					{
						result = num2;
						break;
					}
				}
				continue;
			}
			result = -1;
			break;
		}
		return result;
	}

	public Vector2 getMoveDir(int fingerId)
	{
		Vector2 result;
		if (0 <= fingerId && fingerId < fingerInfo.Length)
		{
			FingerInfo[] array = fingerInfo;
			result = array[RuntimeServices.NormalizeArrayIndex(array, fingerId)].move;
		}
		else
		{
			result = Vector2.zero;
		}
		return result;
	}

	public void update(Boo.Lang.List<MTouch> touches, float dt)
	{
		swiped = false;
		if (touches == null)
		{
			clear();
			return;
		}
		int length = fingerInfo.Length;
		int i = 0;
		FingerInfo[] array = fingerInfo;
		checked
		{
			for (int length2 = array.Length; i < length2; i++)
			{
				array[i].updated = false;
			}
			IEnumerator<MTouch> enumerator = touches.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					MTouch current = enumerator.Current;
					int fingerId = current.fingerId;
					if (fingerId >= 0 && fingerId < length)
					{
						FingerInfo[] array2 = fingerInfo;
						if (array2[RuntimeServices.NormalizeArrayIndex(array2, fingerId)].updateTouch(current.phase == TouchPhase.Began, current.position, dt))
						{
							swiped = true;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			int j = 0;
			FingerInfo[] array3 = fingerInfo;
			for (int length3 = array3.Length; j < length3; j++)
			{
				if (!array3[j].updated)
				{
					array3[j].updateNotTouch(dt);
				}
			}
		}
	}

	public void onGUI()
	{
		int i = 0;
		FingerInfo[] array = fingerInfo;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].onGUI();
		}
	}
}
