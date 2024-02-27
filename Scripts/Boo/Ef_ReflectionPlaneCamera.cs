using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ReflectionPlaneCamera : Ef_Base
{
	public Camera targetCam;

	public string[] displayLayerNames;

	public string[] displayTargetCamLayer;

	public float planeHeight;

	public Transform colorShader;

	public Transform yZShader;

	public float findWait;

	public int maxMeshObj;

	private int dispLayer;

	private float findTimer;

	private bool ready;

	public Ef_ReflectionPlaneCamera()
	{
		displayLayerNames = new string[3] { "CHR", "CHR_RAID", "ScreenMask" };
		displayTargetCamLayer = new string[2] { "CHR", "CHR_RAID" };
		findWait = 1f;
		maxMeshObj = 10;
	}

	public void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		if (!targetCam)
		{
			targetCam = Camera.main;
		}
		if ((bool)targetCam)
		{
			if (!camera)
			{
				gameObject.AddComponent<Camera>();
			}
			camera.depth = Camera.main.depth - 1f;
			camera.backgroundColor = targetCam.backgroundColor;
			camera.clearFlags = targetCam.clearFlags;
			targetCam.clearFlags = CameraClearFlags.Nothing;
			if (displayTargetCamLayer.Length > 0)
			{
				dispLayer = LayerMask.NameToLayer(displayTargetCamLayer[0]);
			}
			int num = default(int);
			int[] array = null;
			int num2 = default(int);
			int num3 = default(int);
			camera.cullingMask = MakeMask(0, displayLayerNames);
			targetCam.cullingMask = MakeMask(targetCam.cullingMask, displayTargetCamLayer);
			if ((bool)colorShader)
			{
				colorShader.localPosition = new Vector3(0f, 0f, 96f);
				colorShader.localScale = new Vector3(200f, 120f, 1f);
			}
			if ((bool)yZShader)
			{
				float y = planeHeight;
				Vector3 position = yZShader.position;
				float num4 = (position.y = y);
				Vector3 vector2 = (yZShader.position = position);
				yZShader.localScale = new Vector3(50f, 50f, 50f);
			}
			ready = true;
		}
	}

	public void OnPreCull()
	{
		if (ready)
		{
			camera.ResetWorldToCameraMatrix();
			camera.ResetProjectionMatrix();
			camera.projectionMatrix *= Matrix4x4.Scale(new Vector3(1f, -1f, 1f));
		}
	}

	public void OnPreRender()
	{
		if (ready)
		{
			GL.SetRevertBackfacing(revertBackFaces: true);
		}
	}

	public void OnPostRender()
	{
		if (ready)
		{
			GL.SetRevertBackfacing(revertBackFaces: false);
		}
	}

	public void Update()
	{
		if (!SceneChanger.isCompletelyReady)
		{
			return;
		}
		if (!ready)
		{
			Initialize();
			if (!ready)
			{
				return;
			}
		}
		findTimer -= deltaTime;
		if (!(findTimer > 0f))
		{
			FindAndSetLayer();
			findTimer = findWait;
		}
		camera.fieldOfView = targetCam.fieldOfView;
		Transform transform = targetCam.transform;
		Vector3 position = transform.position;
		position.y = planeHeight - (position.y - planeHeight);
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		eulerAngles.x *= -1f;
		eulerAngles.z *= -1f;
		Quaternion rotation = Quaternion.Euler(eulerAngles);
		this.transform.position = position;
		this.transform.rotation = rotation;
		if ((bool)yZShader)
		{
			position.y = planeHeight;
			yZShader.position = position;
			yZShader.rotation = Quaternion.identity;
		}
	}

	public int MakeMask(int mask, string[] dispLayers)
	{
		int length = dispLayers.Length;
		int result;
		if (length == 0)
		{
			result = 0;
		}
		else
		{
			if (dispLayers[0] == "all")
			{
				mask = -1;
			}
			else
			{
				int num = default(int);
				IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						mask |= 1 << LayerMask.NameToLayer(dispLayers[RuntimeServices.NormalizeArrayIndex(dispLayers, num)]);
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
			result = mask;
		}
		return result;
	}

	public void FindAndSetLayer()
	{
		BaseControl[] allControls = BaseControl.AllControls;
		int i = 0;
		BaseControl[] array = allControls;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				SkinnedMeshRenderer[] componentsInChildren = array[i].transform.GetComponentsInChildren<SkinnedMeshRenderer>();
				int j = 0;
				SkinnedMeshRenderer[] array2 = componentsInChildren;
				for (int length2 = array2.Length; j < length2; j++)
				{
					array2[j].gameObject.layer = dispLayer;
				}
				MeshRenderer[] componentsInChildren2 = array[i].transform.GetComponentsInChildren<MeshRenderer>();
				int k = 0;
				MeshRenderer[] array3 = componentsInChildren2;
				for (int length3 = array3.Length; k < length3; k++)
				{
					array3[k].gameObject.layer = dispLayer;
				}
			}
		}
	}

	public void OnDestroy()
	{
		if (ready && (bool)targetCam)
		{
			targetCam.clearFlags = camera.clearFlags;
		}
	}
}
