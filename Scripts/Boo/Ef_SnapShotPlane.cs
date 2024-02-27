using System;
using UnityEngine;

[Serializable]
public class Ef_SnapShotPlane : MonoBehaviour
{
	public GameObject renderObj;

	public float resolution;

	public float orthographicSize;

	public string planeTagName;

	public int cullingMask;

	private GameObject camObj;

	private Camera cam;

	private Texture2D texshot;

	private RenderTexture rendTex;

	private Material mat;

	private bool ready;

	public Ef_SnapShotPlane()
	{
		resolution = 128f;
		orthographicSize = 2.5f;
		planeTagName = "Plane";
		cullingMask = 4096;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			Shot();
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		if (ready)
		{
			Shot();
		}
	}

	public void Init()
	{
		if ((bool)renderObj)
		{
			mat = renderObj.renderer.material;
			cullingMask = ((LayerMask)(1 << LayerMask.NameToLayer(planeTagName))).value;
			camObj = new GameObject("SnapCamera");
			camObj.AddComponent<Camera>();
			cam = camObj.camera;
			cam.orthographic = true;
			cam.orthographicSize = transform.localScale.x * orthographicSize;
			cam.nearClipPlane = -2f;
			cam.farClipPlane = 10f;
			cam.backgroundColor = Color.gray;
			cam.cullingMask = cullingMask;
			rendTex = checked(new RenderTexture((int)resolution, (int)resolution, 24));
			cam.targetTexture = rendTex;
			ready = true;
		}
	}

	public void Shot()
	{
		if (!(renderObj == null) && !(camObj == null) && !(cam == null))
		{
			int layer = default(int);
			if ((bool)Terrain.activeTerrain)
			{
				layer = Terrain.activeTerrain.gameObject.layer;
				Terrain.activeTerrain.gameObject.layer = 18;
			}
			camObj.transform.position = renderObj.transform.position;
			camObj.transform.rotation = renderObj.transform.rotation * new Quaternion(0.7071068f, 0f, 0f, 0.7071068f);
			cam.Render();
			RenderTexture.active = rendTex;
			texshot = checked(new Texture2D((int)resolution, (int)resolution, TextureFormat.RGB24, mipmap: false));
			texshot.ReadPixels(new Rect(0f, 0f, resolution, resolution), 0, 0);
			texshot.Apply();
			texshot.wrapMode = TextureWrapMode.Clamp;
			RenderTexture.active = null;
			if (mat.mainTexture != null)
			{
				UnityEngine.Object.Destroy(mat.mainTexture);
			}
			mat.mainTexture = texshot;
			camObj.transform.position = Vector3.zero;
			if ((bool)Terrain.activeTerrain)
			{
				Terrain.activeTerrain.gameObject.layer = layer;
			}
		}
	}

	public void OnDestroy()
	{
		if (texshot != null)
		{
			UnityEngine.Object.Destroy(texshot);
		}
		if (rendTex != null)
		{
			UnityEngine.Object.Destroy(rendTex);
		}
		if (mat != null)
		{
			UnityEngine.Object.Destroy(mat);
		}
		if (camObj != null)
		{
			UnityEngine.Object.Destroy(camObj);
		}
	}
}
