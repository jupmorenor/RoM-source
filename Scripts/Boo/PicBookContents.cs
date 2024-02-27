using System;
using UnityEngine;

[Serializable]
public class PicBookContents : MonoBehaviour
{
	public Vector3 picBookDisplayScale;

	public Vector3 picBookDisplayPosition;

	public Vector3 picBookDisplayRotation;

	public string picBookDisplayMotion;

	public Vector3 PicBookDisplayScale
	{
		get
		{
			return picBookDisplayScale;
		}
		set
		{
			picBookDisplayScale = value;
		}
	}

	public Vector3 PicBookDisplayPosition
	{
		get
		{
			return picBookDisplayPosition;
		}
		set
		{
			picBookDisplayPosition = value;
		}
	}

	public Vector3 PicBookDisplayRotation
	{
		get
		{
			return picBookDisplayRotation;
		}
		set
		{
			picBookDisplayRotation = value;
		}
	}

	public string PicBookDisplayMotion
	{
		get
		{
			return picBookDisplayMotion;
		}
		set
		{
			picBookDisplayMotion = value;
		}
	}

	public PicBookContents()
	{
		picBookDisplayScale = Vector3.one;
		picBookDisplayPosition = Vector3.zero;
		picBookDisplayRotation = Vector3.zero;
		picBookDisplayMotion = string.Empty;
	}

	public void Start()
	{
	}

	public void Update()
	{
	}
}
