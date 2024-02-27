using UnityEngine;

[ExecuteInEditMode]
public class CameraTarget : MonoBehaviour
{
	public Camera camObj;

	public Transform posObj;

	public Transform trgObj;

	private void Start()
	{
		if (!camObj)
		{
			camObj = Camera.main;
		}
		if (!trgObj)
		{
			trgObj = base.transform;
		}
		if (!posObj)
		{
			posObj = trgObj.parent.Find("CameraPosition");
		}
	}

	private void Update()
	{
		if ((bool)camObj && (bool)posObj && (bool)trgObj)
		{
			camObj.transform.position = posObj.position;
			Vector3 forward = trgObj.position - posObj.position;
			camObj.transform.rotation = Quaternion.LookRotation(forward, Vector3.up) * trgObj.localRotation;
		}
	}
}
