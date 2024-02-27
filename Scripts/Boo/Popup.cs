using System;
using ObjUtil;
using UnityEngine;

[Serializable]
public class Popup : MonoBehaviour
{
	public UILabel label;

	[NonSerialized]
	private const float LIFE_TIME_MAX = 0.8f;

	[NonSerialized]
	private const float DEFAULT_MOVE_TIME = 1f;

	[NonSerialized]
	private const float DEFAULT_DISTANCE = 150f;

	[NonSerialized]
	private static readonly Vector3 DEFAULT_MOVE_AT_TIME = Vector3.up * 150f / 1f;

	private Transform mTrans;

	private float lifeTime;

	private Vector3 moveAtTime;

	public float LifeTime
	{
		get
		{
			return lifeTime;
		}
		set
		{
			lifeTime = value;
		}
	}

	public Vector3 MoveAtTime
	{
		get
		{
			return moveAtTime;
		}
		set
		{
			moveAtTime = value;
		}
	}

	public Popup()
	{
		lifeTime = 0.8f;
	}

	public void Awake()
	{
		mTrans = transform;
	}

	public void Update()
	{
		mTrans.localPosition += moveAtTime * Time.deltaTime;
		lifeTime -= Time.deltaTime;
		if (!(lifeTime > 0f))
		{
			gameObject.SetActive(value: false);
		}
	}

	public void initLocal(Vector3 pos, string damage, Color color, float size)
	{
		lifeTime = 0.8f;
		mTrans.localPosition = pos;
		label.text = damage;
		label.color = color;
		label.transform.localScale = new Vector3(size, size, size);
		moveAtTime = DEFAULT_MOVE_AT_TIME;
	}

	public void initOnMainCam(Vector3 pos, int damage, Color color, float size)
	{
		initOnMainCam(pos, damage.ToString(), color, size);
	}

	public void initOnMainCam(Vector3 pos, string damage, Color color, float size)
	{
		initLocal(pos, damage, color, size);
		if (Camera.main != null)
		{
			pos = ObjUtilModule.GetScreenPostion(mTrans, pos, Camera.main);
			mTrans.localPosition = pos;
		}
	}
}
