using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PlayerMarkerObject
{
	private Transform tapObj;

	private ParticleSystem tapEff;

	private __PlayerMarkerObject_creator_0024callable65_002411_24__ creator;

	public PlayerMarkerObject(__PlayerMarkerObject_creator_0024callable65_002411_24__ markerCreator)
	{
		creator = markerCreator;
	}

	public void enable(Vector3 pos)
	{
		if (tapObj == null && creator != null)
		{
			GameObject gameObject = creator();
			if (gameObject != null)
			{
				tapEff = gameObject.GetComponentInChildren<ParticleSystem>();
				tapObj = gameObject.transform;
			}
		}
		tapObj.position = pos;
	}

	public void kill()
	{
		if (tapObj != null)
		{
			if (tapEff != null)
			{
				tapEff.loop = false;
			}
			UnityEngine.Object.Destroy(tapObj.gameObject, 1f);
		}
		tapObj = null;
		tapEff = null;
	}
}
