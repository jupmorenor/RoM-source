using System;
using UnityEngine;

[Serializable]
public class Ef_CastShadowsOnRealMode : MonoBehaviour
{
	public GameObject meshObj;

	public GameObject shadowObj;

	public void Start()
	{
		if (!meshObj)
		{
			meshObj = gameObject;
		}
		if ((bool)meshObj.renderer)
		{
			meshObj.renderer.castShadows = ShadowCheck.RealShadowFlag;
		}
		if ((bool)shadowObj)
		{
			shadowObj.SetActive(!ShadowCheck.RealShadowFlag);
		}
	}
}
