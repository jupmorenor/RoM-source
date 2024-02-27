using System;
using UnityEngine;

[Serializable]
public class QuestTrigger : MonoBehaviour
{
	private bool triggered;

	public void Awake()
	{
		Collider component = gameObject.GetComponent<Collider>();
		if (component != null)
		{
			component.isTrigger = true;
		}
	}

	public void OnTriggerEnter(Collider c)
	{
		if (!triggered)
		{
			PlayerControl component = c.transform.root.GetComponent<PlayerControl>();
			if (component != null)
			{
				QuestClearConditionChecker.Instance.satisfyArrive(gameObject);
				triggered = true;
			}
		}
	}
}
