using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class DebugSubDebugCamera : RuntimeDebugModeGuiMixin
{
	protected Camera cam;

	protected Vector3 moveDir;

	protected Component[] components;

	protected bool[] compFlags;

	public override void Init()
	{
		cam = Camera.main;
		if (cam == null)
		{
			return;
		}
		components = Camera.main.gameObject.GetComponents<Component>();
		compFlags = new bool[components.Length];
		int num = 0;
		int length = components.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Component[] array = components;
			Behaviour behaviour = array[RuntimeServices.NormalizeArrayIndex(array, index)] as Behaviour;
			if (behaviour != null && cam != behaviour)
			{
				bool[] array2 = compFlags;
				ref bool reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				reference = behaviour.enabled;
				behaviour.enabled = false;
			}
		}
	}

	public override void Exit()
	{
		if (cam == null)
		{
			return;
		}
		int num = 0;
		int length = components.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Component[] array = components;
			Behaviour behaviour = array[RuntimeServices.NormalizeArrayIndex(array, index)] as Behaviour;
			if (behaviour != null && cam != behaviour)
			{
				bool[] array2 = compFlags;
				behaviour.enabled = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			}
		}
	}

	public override void HideModeUpdate()
	{
		if (!(cam == null))
		{
			cam.transform.position = cam.transform.position + moveDir * 0.1f;
		}
	}

	public override void HideModeOnGUI()
	{
		if (!(cam == null))
		{
			if (GUI.Button(new Rect(128f, 100f, 128f, 64f), "Forward"))
			{
				moveDir = cam.transform.rotation * Vector3.forward;
			}
			if (GUI.Button(new Rect(0f, 132f, 128f, 64f), "Left"))
			{
				moveDir = cam.transform.rotation * -Vector3.right;
			}
			if (GUI.Button(new Rect(256f, 132f, 128f, 64f), "Right"))
			{
				moveDir = cam.transform.rotation * Vector3.right;
			}
			if (GUI.Button(new Rect(128f, 164f, 128f, 64f), "Backward"))
			{
				moveDir = cam.transform.rotation * -Vector3.forward;
			}
			if (GUI.Button(new Rect(0f, 228f, 128f, 64f), "Up"))
			{
				moveDir = cam.transform.rotation * Vector3.up;
			}
			if (GUI.Button(new Rect(128f, 228f, 128f, 64f), "Down"))
			{
				moveDir = cam.transform.rotation * -Vector3.up;
			}
			if (GUI.Button(new Rect(128f, 300f, 128f, 64f), "Stop"))
			{
				moveDir = Vector3.zero;
			}
		}
	}

	public override void OnGUI()
	{
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.label("Let's *Hide* and move Camera.main!");
	}
}
