using System;
using UnityEngine;

[Serializable]
public class Ef_SwordTrailV2_FindWeapon : MonoBehaviour
{
	public GameObject effectObj;

	public bool useForRaidGuest;

	public Ef_SwordTrailV2_FindWeapon()
	{
		useForRaidGuest = true;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (emtr == null)
		{
			return;
		}
		if (!effectObj)
		{
			Transform transform = this.transform.Find("Ef_Sword_track");
			if (!transform)
			{
				this.gameObject.SetActive(value: false);
				return;
			}
			effectObj = transform.gameObject;
		}
		Ef_SwordTrailV2 component = effectObj.GetComponent<Ef_SwordTrailV2>();
		Transform transform2 = effectObj.transform;
		PlayerControl component2 = emtr.GetComponent<PlayerControl>();
		if (component2 != null)
		{
			GameObject gameObject;
			GameObject gameObject2;
			GameObject gameObject3;
			if (component2.IsTensi)
			{
				gameObject = component2.weaponRBaseTensi;
				gameObject2 = component2.weaponTensi[0];
				gameObject3 = component2.tensiModel;
			}
			else
			{
				gameObject = component2.weaponRBaseAkuma;
				gameObject2 = component2.weaponAkuma[0];
				gameObject3 = component2.akumaModel;
			}
			if (!gameObject)
			{
				this.gameObject.SetActive(value: false);
				return;
			}
			if (!gameObject2)
			{
				this.gameObject.SetActive(value: false);
				return;
			}
			if (!gameObject3)
			{
				this.gameObject.SetActive(value: false);
				return;
			}
			Transform transform3 = gameObject2.transform.Find("Bounds");
			if (!transform3)
			{
				this.gameObject.SetActive(value: false);
				return;
			}
			transform2.parent = null;
			transform2.position = gameObject3.transform.position;
			component.weaponAttachObj = gameObject.transform;
			component.weaponLength = transform3.localScale.y;
			component.offset = transform3.localPosition;
		}
		else if (useForRaidGuest)
		{
			MerlinMotionPackControl component3 = emtr.GetComponent<MerlinMotionPackControl>();
			if (component3 == null)
			{
				return;
			}
			Transform transform4 = component3.motionTarget.transform;
			if (transform4 == null)
			{
				return;
			}
			Transform transform5 = transform4.transform;
			Transform transform6 = default(Transform);
			if ((bool)transform5)
			{
				transform6 = transform5.Find("y_ang/cog/c_spine_a/c_spine_b/r_clavicle/r_upperarm/r_forearm/r_hand/r_weapon_1");
			}
			if (transform6 == null)
			{
			}
			transform2.parent = null;
			transform2.position = transform4.position;
			component.weaponAttachObj = transform6;
			component.weaponLength = 1.5f;
			component.offset = Vector3.zero;
		}
		this.gameObject.SetActive(value: false);
	}

	public void OnDestroy()
	{
		if ((bool)effectObj)
		{
			UnityEngine.Object.Destroy(effectObj);
		}
	}
}
