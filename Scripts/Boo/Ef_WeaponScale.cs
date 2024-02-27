using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_WeaponScale : Ef_Base
{
	[NonSerialized]
	public static GameObject current;

	public float life;

	public float delay;

	public float scaleTime;

	public Vector3 targetScale;

	public int weaponNo;

	public GameObject weaponObj;

	public bool destroy;

	private Vector3 fstScale;

	private float time;

	private float time0;

	private float time1;

	public Ef_WeaponScale()
	{
		life = 3.5f;
		scaleTime = 0.5f;
		targetScale = new Vector3(0.01f, 0.01f, 0.01f);
		fstScale = Vector3.zero;
	}

	public void Start()
	{
		if ((bool)current)
		{
			Ef_WeaponScale component = current.GetComponent<Ef_WeaponScale>();
			if (component != null)
			{
				fstScale = component.fstScale;
			}
			UnityEngine.Object.Destroy(current);
		}
		current = this.gameObject;
		GameObject gameObject = null;
		Transform transform = null;
		MerlinMotionPackControl merlinMotionPackControl = null;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!currentPlayer)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		transform = currentPlayer.transform;
		if (currentPlayer.IsTensi)
		{
			gameObject = currentPlayer.weaponLBaseTensi;
			GameObject[] weaponTensi = currentPlayer.weaponTensi;
			weaponObj = weaponTensi[RuntimeServices.NormalizeArrayIndex(weaponTensi, weaponNo)];
		}
		else
		{
			gameObject = currentPlayer.weaponLBaseAkuma;
			GameObject[] weaponAkuma = currentPlayer.weaponAkuma;
			weaponObj = weaponAkuma[RuntimeServices.NormalizeArrayIndex(weaponAkuma, weaponNo)];
		}
		if (!gameObject)
		{
		}
		if (!weaponObj)
		{
		}
		if (fstScale == Vector3.zero)
		{
			fstScale = weaponObj.transform.localScale;
		}
		time0 = life - delay;
		time1 = life - delay - scaleTime;
	}

	public void Update()
	{
		if (!weaponObj)
		{
			return;
		}
		life -= deltaTime;
		Vector3 vector = default(Vector3);
		if (!(life < time0))
		{
			return;
		}
		if (!(life <= time1))
		{
			vector = Vector3.Lerp(targetScale, fstScale, (life - time1) / scaleTime);
		}
		else if (!(life < scaleTime))
		{
			vector = targetScale;
		}
		else if (!(life <= 0f))
		{
			vector = Vector3.Lerp(fstScale, targetScale, life / scaleTime);
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		else
		{
			vector = fstScale;
		}
		weaponObj.transform.localScale = vector;
	}

	public void OnDestroy()
	{
		if ((bool)weaponObj)
		{
			weaponObj.transform.localScale = fstScale;
		}
	}
}
