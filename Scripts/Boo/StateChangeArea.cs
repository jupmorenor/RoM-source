using System;
using UnityEngine;

[Serializable]
public class StateChangeArea : Ef_Base
{
	private StateChangeAreaData areaData;

	public float leftExistTime;

	[NonSerialized]
	protected const float SE_MINUS_AREA_SMOKE_LEFT_TIME = 0.6f;

	public StateChangeAreaData AreaData
	{
		get
		{
			return areaData;
		}
		set
		{
			areaData = value;
		}
	}

	public void Start()
	{
		gameObject.layer = LayerMask.NameToLayer("Default");
		gameObject.tag = "StateChangeArea";
		UnityEngine.Object.Destroy(gameObject, leftExistTime);
	}

	public void Update()
	{
		if (areaData != null)
		{
			areaData.Position = gameObject.transform.position;
		}
		if (!(leftExistTime <= 0.6f) && !(leftExistTime - Time.deltaTime > 0.6f) && (bool)SQEX_SoundPlayer.Instance)
		{
			SQEX_SoundPlayer.Instance.PlaySe(104, 0, gameObject.GetInstanceID());
		}
		leftExistTime -= Time.deltaTime;
	}
}
