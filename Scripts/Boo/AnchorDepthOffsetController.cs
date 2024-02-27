using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class AnchorDepthOffsetController : MonoBehaviour
{
	public bool autoDepthOffsetSetting;

	public float depthOffset;

	private float prevDepthOffset;

	public void Start()
	{
		if (autoDepthOffsetSetting)
		{
			DoSet();
		}
	}

	public void Update()
	{
		if (autoDepthOffsetSetting && prevDepthOffset != depthOffset)
		{
			DoSet();
		}
	}

	public void DoSet()
	{
		prevDepthOffset = depthOffset;
		int i = 0;
		UIAnchor[] componentsInChildren = gameObject.GetComponentsInChildren<UIAnchor>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			float z = depthOffset;
			Vector3 position = componentsInChildren[i].transform.position;
			float num = (position.z = z);
			Vector3 vector2 = (componentsInChildren[i].transform.position = position);
		}
	}
}
