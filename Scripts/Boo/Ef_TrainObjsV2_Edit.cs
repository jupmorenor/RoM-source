using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_TrainObjsV2_Edit : MonoBehaviour
{
	public bool initialize;

	private Ef_TrainObjsV2 to;

	private bool ready;

	public void Start()
	{
		to = gameObject.GetComponent<Ef_TrainObjsV2>();
		if (!(to == null))
		{
			ready = true;
		}
	}

	public void Update()
	{
		if (ready && initialize)
		{
			to.Initialize();
			initialize = false;
		}
	}
}
