using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_SetColorFromRareElementV2_Edit : MonoBehaviour
{
	public bool checkComponent;

	private Ef_SetColorFromRareElementV2 scfre;

	private bool ready;

	public void Start()
	{
		scfre = gameObject.GetComponent<Ef_SetColorFromRareElementV2>();
		if (!(scfre == null))
		{
			ready = true;
		}
	}

	public void Update()
	{
		if (ready && checkComponent)
		{
			scfre.CheckComponentType();
			checkComponent = false;
		}
	}
}
