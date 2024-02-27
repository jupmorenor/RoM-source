using UnityEngine;

[ExecuteInEditMode]
public class PanoramaMesh_Old : MonoBehaviour
{
	public Camera targetCam;

	public int divH = 100;

	public int divV = 100;

	public int texWidth = 512;

	public int texHeight = 512;

	public bool setDefaultCurve90;

	public AnimationCurve correctionCurveH;

	public AnimationCurve correctionCurveV;

	public PanoramaMesh texShareObj;

	public RenderTexture renderTex;

	public bool autoupdate;

	public bool update;

	public bool texToNull;

	public bool putCurveValue;

	private float viewAng = 60f;

	private void Start()
	{
		if (!targetCam)
		{
			targetCam = Camera.main;
			if (!targetCam)
			{
				Debug.LogError("No Camera.");
				return;
			}
		}
		targetCam.aspect = 1f;
		viewAng = targetCam.fieldOfView;
		renderTex = null;
		if ((bool)texShareObj)
		{
			texShareObj.renderTex = null;
		}
		if (setDefaultCurve90)
		{
			SetDefaultCurve90();
			setDefaultCurve90 = false;
		}
		if (update || autoupdate)
		{
			MakeMesh();
			update = false;
			autoupdate = false;
		}
	}

	private void Update()
	{
		if (setDefaultCurve90)
		{
			SetDefaultCurve90();
			setDefaultCurve90 = false;
		}
		if (update || autoupdate)
		{
			MakeMesh();
			update = false;
		}
		if (texToNull)
		{
			renderTex = null;
			if ((bool)texShareObj)
			{
				texShareObj.renderTex = null;
			}
			texToNull = false;
		}
		if (putCurveValue)
		{
			PutCurveValue();
			putCurveValue = false;
		}
	}

	private void MakeMesh()
	{
		int num = divH + 1;
		int num2 = divV + 1;
		Vector3[] array = new Vector3[num * num2];
		Vector2[] array2 = new Vector2[num * num2];
		int[] array3 = new int[divH * divV * 6];
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				float num3 = -0.5f + 1f / (float)divH * (float)j;
				float num4 = 0.5f - 1f / (float)divV * (float)i;
				num4 *= correctionCurveV.Evaluate(Mathf.Abs(num3) * 2f);
				num3 = ((!(num3 >= 0f)) ? ((0f - correctionCurveH.Evaluate(Mathf.Abs(num3) * 2f)) / 2f) : (correctionCurveH.Evaluate(Mathf.Abs(num3) * 2f) / 2f));
				ref Vector3 reference = ref array[i * num + j];
				reference = new Vector3(num3, num4, 0f);
				ref Vector2 reference2 = ref array2[i * num + j];
				reference2 = new Vector2(1f / (float)divH * (float)j, 1f - 1f / (float)divV * (float)i);
			}
		}
		for (int i = 0; i < divV; i++)
		{
			for (int j = 0; j < divH; j++)
			{
				int num5 = (i * divH + j) * 6;
				array3[num5] = i * num + j;
				array3[num5 + 1] = i * num + j + 1;
				array3[num5 + 2] = (i + 1) * num + j;
				array3[num5 + 3] = (i + 1) * num + j;
				array3[num5 + 4] = i * num + j + 1;
				array3[num5 + 5] = (i + 1) * num + j + 1;
			}
		}
		Material material;
		if (!base.renderer)
		{
			base.gameObject.AddComponent<MeshRenderer>();
			material = new Material(Shader.Find("Unlit/Texture"));
		}
		else
		{
			material = base.renderer.material;
		}
		MeshFilter meshFilter = base.gameObject.GetComponent<MeshFilter>();
		if (!meshFilter)
		{
			meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}
		Mesh mesh = meshFilter.mesh;
		if (!mesh)
		{
			mesh = new Mesh();
		}
		mesh.vertices = array;
		mesh.uv = array2;
		mesh.triangles = array3;
		mesh.RecalculateBounds();
		if ((bool)texShareObj)
		{
			if (!renderTex)
			{
				renderTex = new RenderTexture(texWidth, texHeight, 24, RenderTextureFormat.Default);
				texShareObj.renderTex = renderTex;
			}
		}
		else
		{
			renderTex = new RenderTexture(texWidth, texHeight, 24, RenderTextureFormat.Default);
		}
		targetCam.targetTexture = renderTex;
		material.mainTexture = renderTex;
		base.renderer.material = material;
		mesh.name = targetCam.name;
		material.name = targetCam.name;
		renderTex.name = targetCam.name;
	}

	private Vector2 Rotate2D(Vector2 vec, float radian)
	{
		return new Vector2(vec.x * Mathf.Cos(radian) - vec.y * Mathf.Sin(radian), vec.x * Mathf.Sin(radian) + vec.y * Mathf.Cos(radian));
	}

	private void PutCurveValue()
	{
		Debug.Log("correctionCurveH");
		Keyframe[] keys = correctionCurveH.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + "  V:" + keys[i].value + "  in:" + keys[i].inTangent + "  out:" + keys[i].outTangent);
		}
		Debug.Log("correctionCurveV");
		keys = correctionCurveV.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + "  V:" + keys[i].value + "  in:" + keys[i].inTangent + "  out:" + keys[i].outTangent);
		}
	}

	private void SetDefaultCurve90()
	{
		Keyframe key = default(Keyframe);
		for (int i = 0; i < correctionCurveH.keys.Length; i++)
		{
			correctionCurveH.RemoveKey(i);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1.316f;
		key.outTangent = 1.316f;
		correctionCurveH.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		key.inTangent = 0.771f;
		key.outTangent = 0.771f;
		correctionCurveH.AddKey(key);
		for (int i = 0; i < correctionCurveV.keys.Length; i++)
		{
			correctionCurveV.RemoveKey(0);
		}
		key.time = 0f;
		key.value = 1f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		correctionCurveV.AddKey(key);
		key.time = 1f;
		key.value = 0.7f;
		key.inTangent = -0.369f;
		key.outTangent = -0.369f;
	}
}
