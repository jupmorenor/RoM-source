using UnityEngine;

public class Ef_Sonic_Cone_Particle : Ef_Base
{
	private Vector3 lstPos = Vector3.zero;

	private void Update()
	{
		Vector3 vector = base.transform.position - lstPos;
		if (vector != Vector3.zero)
		{
			base.transform.rotation = Quaternion.LookRotation(vector, base.transform.parent.up);
			float num = base.deltaTime;
			if (num <= 0f)
			{
				num = 0.001f;
			}
			base.particleSystem.startSpeed = vector.magnitude / num * 2f;
		}
		lstPos = base.transform.position;
	}
}
