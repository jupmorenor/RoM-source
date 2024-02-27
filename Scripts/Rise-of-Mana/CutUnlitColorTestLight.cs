using UnityEngine;

public class CutUnlitColorTestLight : MonoBehaviour
{
	public GameObject animObj;

	public GameObject[] objs;

	private Material mat0;

	private Material mat1;

	private Color lstColor = Color.black;

	private float lstIntens = 0.5f;

	private void Start()
	{
		animObj.animation.wrapMode = WrapMode.Loop;
	}

	private void Update()
	{
		if (!(base.light.color != lstColor) && base.light.intensity == lstIntens)
		{
			return;
		}
		for (int i = 0; i < objs.Length; i++)
		{
			Material[] materials = objs[i].renderer.materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j].color = RenderSettings.ambientLight + base.light.color * base.light.intensity;
			}
		}
		lstColor = base.light.color;
		lstIntens = base.light.intensity;
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(100f, 100f, 500f, 50f), "Change Directional light Color and Intensity will be Reflected in material.");
	}
}
