using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class RaidCamera : BasicCamera
{
	public Transform player;

	public Transform boss;

	private float targetHeight;

	private float heightVelocity;

	[NonSerialized]
	private static RaidCamera _Instance;

	public static RaidCamera Instance => _Instance;

	public RaidCamera()
	{
		targetHeight = 100000f;
	}

	public new void Awake()
	{
		setFullMetalHuggerParam();
	}

	public void OnEnable()
	{
		_Instance = this;
	}

	public void OnDisable()
	{
		_Instance = null;
	}

	public void setFullMetalHuggerParam()
	{
		distance = 12f;
		height = 7f;
		heightSmoothLag = 0.3f;
		distanceSmoothLag = 0.3f;
		centerOffset = Vector3.zero;
	}

	public void setFushiKouteiParam()
	{
		distance = 12f;
		height = 7f;
		heightSmoothLag = 0.3f;
		distanceSmoothLag = 0.3f;
		centerOffset = Vector3.zero;
	}

	private Transform searchBoss()
	{
		BaseControl[] allControls = BaseControl.AllControls;
		BaseControl[] array = allControls;
		int length = array.Length;
		int num = 0;
		object result;
		while (true)
		{
			if (num < length)
			{
				BaseControl baseControl = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
				if (baseControl is AIControl && !(baseControl as AIControl).IsPlayer)
				{
					result = baseControl.transform;
					break;
				}
				continue;
			}
			result = null;
			break;
		}
		return (Transform)result;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (Time.timeScale != 0f && (!(boss == null) || !(player == null)))
		{
			if (boss == null && (bool)player && (bool)player)
			{
				boss = searchBoss();
			}
			Vector3 position = Vector3.zero;
			if (player != null)
			{
				position = player.position + centerOffset;
			}
			float y = transform.eulerAngles.y;
			targetHeight = position.y + height;
			float y2 = transform.position.y;
			y2 = Mathf.SmoothDamp(y2, targetHeight, ref heightVelocity, heightSmoothLag);
			Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
			transform.position = position;
			transform.position += quaternion * Vector3.back * distance;
			float y3 = y2;
			Vector3 position2 = transform.position;
			float num = (position2.y = y3);
			Vector3 vector2 = (transform.position = position2);
			if ((bool)boss)
			{
				transform.LookAt(boss);
			}
		}
	}
}
