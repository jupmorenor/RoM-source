using System;
using UnityEngine;

[Serializable]
public class LightTableReciever : MonoBehaviour
{
	public Color color;

	public SceneLightTable lightTable;

	public void Start()
	{
		if (!lightTable)
		{
			lightTable = (SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable));
		}
	}

	public void Update()
	{
		if ((bool)lightTable)
		{
			color = lightTable.CheckColor(transform.position);
		}
	}
}
