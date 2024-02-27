using UnityEngine;

public class EffectDestroyScript2 : Ef_Base
{
	private void Start()
	{
	}

	private void Update()
	{
		bool flag = false;
		ParticleSystem componentInChildren = base.gameObject.GetComponentInChildren<ParticleSystem>();
		if ((bool)componentInChildren && componentInChildren.IsAlive())
		{
			flag = true;
		}
		if (!flag)
		{
			ParticleAnimator componentInChildren2 = base.gameObject.GetComponentInChildren<ParticleAnimator>();
			if (componentInChildren2 == null)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
