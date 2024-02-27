using System;
using UnityEngine;

[Serializable]
public class Ef_CutSceneCameraEventHandler : MonoBehaviour
{
	private Ef_CutSceneCameraEventReciever reciever;

	private Animation anim;

	public AnimationState currentState;

	public void Start()
	{
		search();
	}

	public void LateUpdate()
	{
		if ((bool)anim && (bool)anim.clip && !(currentState == anim[anim.clip.name]))
		{
			currentState = anim[anim.clip.name];
			_fire();
		}
	}

	public void search()
	{
		anim = gameObject.animation;
		reciever = ((Ef_CutSceneCameraEventReciever)UnityEngine.Object.FindObjectOfType(typeof(Ef_CutSceneCameraEventReciever))) as Ef_CutSceneCameraEventReciever;
	}

	public void _fire()
	{
		if (!reciever)
		{
			search();
		}
		if ((bool)reciever && (bool)anim.clip)
		{
			Ef_CutSceneCameraEventReciever.OnCameraAnimationStart(anim.clip.name);
		}
	}
}
