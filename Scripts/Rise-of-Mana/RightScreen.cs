using UnityEngine;

[ExecuteInEditMode]
public class RightScreen : MonoBehaviour
{
	public Camera cam;

	private void Update()
	{
		base.transform.localPosition = new Vector3(Screen.height / 20 * 9, 0f, 0f);
		base.transform.localScale = new Vector3(Screen.height, Screen.height, 1f);
	}
}
