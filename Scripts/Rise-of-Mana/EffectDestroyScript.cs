using UnityEngine;

public class EffectDestroyScript : Ef_Base
{
	private ParticleSystem ps;

	private float destroyTime = 3f;

	public GameObject target;

	public string invoke;

	private void Awake()
	{
		ps = base.gameObject.GetComponentInChildren<ParticleSystem>();
		Object.Destroy(base.gameObject, destroyTime);
	}

	private void Update()
	{
		if (ps == null)
		{
			Object.Destroy(base.gameObject);
		}
		else if (!ps.IsAlive())
		{
			ParticleAnimator componentInChildren = base.gameObject.GetComponentInChildren<ParticleAnimator>();
			if (componentInChildren == null)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	private void OnDestroy()
	{
		if ((bool)target)
		{
			target.SendMessage(invoke, base.gameObject);
		}
	}
}
