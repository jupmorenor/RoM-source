using System;
using UnityEngine;

[Serializable]
public class Ef_FindWeapon : MonoBehaviour
{
	public bool strech;

	public bool bow;

	public Ef_FindWeapon()
	{
		strech = true;
	}

	public void Start()
	{
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		GameObject gameObject3 = null;
		MerlinMotionPackControl merlinMotionPackControl = null;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!currentPlayer)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (currentPlayer.IsTensi)
		{
			gameObject2 = (bow ? currentPlayer.weaponLBaseTensi : currentPlayer.weaponRBaseTensi);
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
		Transform transform = gameObject.transform.Find("Bounds");
		if ((bool)transform)
		{
			this.transform.parent = gameObject2.transform;
			this.transform.localPosition = transform.localPosition;
			this.transform.localRotation = Quaternion.identity;
			this.transform.localScale = transform.localScale;
		}
	}
}
