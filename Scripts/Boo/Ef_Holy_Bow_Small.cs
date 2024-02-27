using System;
using UnityEngine;

[Serializable]
public class Ef_Holy_Bow_Small : Ef_Base
{
	public bool strech;

	private GameObject weaponObj;

	private float time;

	public Ef_Holy_Bow_Small()
	{
		strech = true;
	}

	public void Start()
	{
		GameObject gameObject = null;
		Transform transform = null;
		MerlinMotionPackControl merlinMotionPackControl = null;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!currentPlayer || !currentPlayer.IsReady)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		transform = currentPlayer.transform;
		if (currentPlayer.IsTensi)
		{
			gameObject = currentPlayer.weaponLBaseTensi;
			weaponObj = currentPlayer.weaponTensi[0];
		}
		else
		{
			gameObject = currentPlayer.weaponLBaseAkuma;
			weaponObj = currentPlayer.weaponAkuma[0];
		}
		if (!gameObject)
		{
		}
		if ((bool)weaponObj)
		{
		}
	}

	public void Update()
	{
		if (!weaponObj)
		{
			return;
		}
		float num = default(float);
		if (!(time >= 0.5f))
		{
			num = 1f - time * 2f;
			weaponObj.transform.localScale = new Vector3(num, num, num);
			time += deltaTime;
			if (!(time < 0.5f))
			{
				weaponObj.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
			}
		}
		else if (!(time >= 2.5f))
		{
			time += deltaTime;
		}
		else if (!(time >= 3.5f))
		{
			num = time - 2.5f;
			weaponObj.transform.localScale = new Vector3(num, num, num);
			time += deltaTime;
			if (!(time < 3.5f))
			{
				weaponObj.transform.localScale = Vector3.one;
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)weaponObj)
		{
			weaponObj.transform.localScale = Vector3.one;
		}
	}
}
