using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PhotonBoss : MonoBehaviour
{
	private __PhotonBoss_HitDamageHandler_0024callable83_00245_33__ hitDamageHandler;

	public __PhotonBoss_HitDamageHandler_0024callable83_00245_33__ HitDamageHandler
	{
		get
		{
			return hitDamageHandler;
		}
		set
		{
			hitDamageHandler = value;
		}
	}

	public void raidDamageEffect(GameObject eff, Vector3 pos, Quaternion rot)
	{
		if (hitDamageHandler != null)
		{
			hitDamageHandler(eff, pos, rot);
		}
	}
}
