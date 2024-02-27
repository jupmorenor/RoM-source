using System;
using UnityEngine;

[Serializable]
public class Boobooboo : MonoBehaviour
{
	public GameObject target_activate;

	public GameObject target_deactivate;

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void activate()
	{
		if (target_activate != null)
		{
			target_activate.SetActive(value: true);
		}
	}

	public void deactivate()
	{
		if (target_deactivate != null)
		{
			target_deactivate.SetActive(value: false);
		}
	}

	public void activate_deactivate()
	{
		if (target_activate != null)
		{
			target_activate.SetActive(value: true);
		}
		if (target_deactivate != null)
		{
			target_deactivate.SetActive(value: false);
		}
	}
}
