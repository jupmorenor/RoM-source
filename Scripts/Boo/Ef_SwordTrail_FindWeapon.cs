using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SwordTrail_FindWeapon : MonoBehaviour
{
	public Transform trailEff;

	public Transform r_weapon;

	private Ef_SwordTrail swordTrail;

	public bool checkObj(object obj, string mes)
	{
		int result;
		if (!RuntimeServices.ToBool(obj))
		{
			UnityEngine.Object.Destroy(gameObject);
			result = 0;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public void Awake()
	{
		if (!trailEff)
		{
			trailEff = this.transform.Find("Ef_Sword_Trail");
			if (!trailEff)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
		}
		swordTrail = trailEff.GetComponent<Ef_SwordTrail>();
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		GameObject gameObject3 = null;
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
			gameObject2 = currentPlayer.weaponRBaseTensi;
			gameObject = currentPlayer.weaponTensi[0];
			gameObject3 = currentPlayer.tensiModel;
		}
		else
		{
			gameObject2 = currentPlayer.weaponRBaseAkuma;
			gameObject = currentPlayer.weaponAkuma[0];
			gameObject3 = currentPlayer.akumaModel;
		}
		if (!gameObject2)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (!gameObject)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (!gameObject3)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		Transform transform2 = gameObject.transform.Find("Bounds");
		if (!transform2)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		trailEff.parent = null;
		trailEff.position = gameObject3.transform.position;
		swordTrail.weaponAttachObj = gameObject2.transform;
		swordTrail.weaponLength = transform2.localScale.y;
		Vector3 localPosition = transform2.localPosition;
		localPosition.y -= transform2.localScale.y / 2f;
		swordTrail.offset = localPosition;
		swordTrail.destroyOne = true;
		UnityEngine.Object.Destroy(this.gameObject);
	}
}
