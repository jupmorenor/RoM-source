using UnityEngine;

[ExecuteInEditMode]
public class PanoramaMesh : MonoBehaviour
{
	public Camera targetCam;

	public int divH = 100;

	public int divV = 100;

	public int texWidth = 512;

	public int texHeight = 512;

	public bool setDefaultCurve;

	public bool setDefaultCurve90;

	public AnimationCurve meshCurveXLeft;

	public AnimationCurve meshCurveXRight;

	public AnimationCurve meshCurveYTop;

	public AnimationCurve meshCurveYBottom;

	public AnimationCurve meshDensityH;

	public AnimationCurve meshDensityV;

	public AnimationCurve meshZPosH;

	public AnimationCurve meshZPosV;

	public AnimationCurve uvCurveXLeft;

	public AnimationCurve uvCurveXRight;

	public AnimationCurve uvCurveYTop;

	public AnimationCurve uvCurveYBottom;

	public AnimationCurve uvDensityH;

	public AnimationCurve uvDensityV;

	public PanoramaMesh texShareObj;

	public RenderTexture renderTex;

	public bool autoupdate;

	public bool mirrorH;

	public bool mirrorV;

	public bool update;

	public bool texToNull;

	public bool putCurveValue;

	private float viewAng = 60f;

	private int lstVertNum;

	private void Start()
	{
		if ((bool)targetCam)
		{
			targetCam.aspect = 1f;
			viewAng = targetCam.fieldOfView;
		}
		renderTex = null;
		if ((bool)texShareObj)
		{
			texShareObj.renderTex = null;
		}
		if (setDefaultCurve)
		{
			SetDefaultCurve();
			setDefaultCurve = false;
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
		if (update || autoupdate)
		{
			MakeMesh();
			update = false;
		}
		if (mirrorH)
		{
			MirrorH();
			update = true;
			if (!autoupdate)
			{
				mirrorH = false;
			}
		}
		if (mirrorV)
		{
			MirrorV();
			update = true;
			if (!autoupdate)
			{
				mirrorV = false;
			}
		}
		if (setDefaultCurve)
		{
			SetDefaultCurve();
			update = true;
			setDefaultCurve = false;
		}
		if (setDefaultCurve90)
		{
			SetDefaultCurve90();
			update = true;
			setDefaultCurve90 = false;
		}
		if (texToNull)
		{
			renderTex = null;
			if (texShareObj != null)
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
		int num3 = num * num2;
		Vector3[] array = new Vector3[num3];
		Vector2[] array2 = new Vector2[num3];
		int[] array3 = new int[divH * divV * 6];
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				float time = 1f / (float)divH * (float)j;
				float time2 = 1f / (float)divV * (float)i;
				float from = meshCurveXLeft.Evaluate(time2);
				float to = meshCurveXRight.Evaluate(time2);
				float from2 = meshCurveYTop.Evaluate(time);
				float to2 = meshCurveYBottom.Evaluate(time);
				float t = meshDensityH.Evaluate(time);
				float t2 = meshDensityV.Evaluate(time2);
				float num4 = meshZPosH.Evaluate(time);
				float num5 = meshZPosV.Evaluate(time2);
				float x = Mathf.Lerp(from, to, t);
				float y = Mathf.Lerp(from2, to2, t2);
				float z = num4 + num5;
				float from3 = uvCurveXLeft.Evaluate(time2);
				float to3 = uvCurveXRight.Evaluate(time2);
				float from4 = uvCurveYTop.Evaluate(time);
				float to4 = uvCurveYBottom.Evaluate(time);
				float t3 = uvDensityH.Evaluate(time);
				float t4 = uvDensityV.Evaluate(time2);
				float x2 = Mathf.Lerp(from3, to3, t3);
				float y2 = Mathf.Lerp(from4, to4, t4);
				ref Vector3 reference = ref array[i * num + j];
				reference = new Vector3(x, y, z);
				ref Vector2 reference2 = ref array2[i * num + j];
				reference2 = new Vector3(x2, y2, z);
			}
		}
		for (int i = 0; i < divV; i++)
		{
			for (int j = 0; j < divH; j++)
			{
				int num6 = (i * divH + j) * 6;
				array3[num6] = i * num + j;
				array3[num6 + 1] = i * num + j + 1;
				array3[num6 + 2] = (i + 1) * num + j;
				array3[num6 + 3] = (i + 1) * num + j;
				array3[num6 + 4] = i * num + j + 1;
				array3[num6 + 5] = (i + 1) * num + j + 1;
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
		if (num3 < lstVertNum)
		{
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.triangles = array3;
		}
		else
		{
			mesh.triangles = array3;
			mesh.vertices = array;
			mesh.uv = array2;
		}
		lstVertNum = num3;
		mesh.RecalculateBounds();
		if (targetCam != null)
		{
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
		else
		{
			mesh.name = base.gameObject.name + "_Mesh";
		}
	}

	private Vector2 Rotate2D(Vector2 vec, float radian)
	{
		return new Vector2(vec.x * Mathf.Cos(radian) - vec.y * Mathf.Sin(radian), vec.x * Mathf.Sin(radian) + vec.y * Mathf.Cos(radian));
	}

	private void PutCurveValue()
	{
		Debug.Log("meshCurveXLeft");
		Keyframe[] keys = meshCurveXLeft.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshCurveXRight");
		keys = meshCurveXRight.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshCurveYTop");
		keys = meshCurveYTop.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshCurveYBottom");
		keys = meshCurveYBottom.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshDensityH");
		keys = meshDensityH.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshDensityV");
		keys = meshDensityV.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshZPosH");
		keys = meshZPosH.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("meshZPosV");
		keys = meshZPosV.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvCurveXLeft");
		keys = uvCurveXLeft.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvCurveXRight");
		keys = uvCurveXRight.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvCurveYTop");
		keys = uvCurveYTop.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvCurveYBottom");
		keys = uvCurveYBottom.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvDensityH");
		keys = uvDensityH.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
		Debug.Log("uvDensityV");
		keys = uvDensityV.keys;
		for (int i = 0; i < keys.Length; i++)
		{
			Debug.Log("T:" + keys[i].time + " V:" + keys[i].value + " in:" + keys[i].inTangent + " out:" + keys[i].outTangent);
		}
	}

	private void MirrorH()
	{
		Keyframe keyframe = default(Keyframe);
		for (int num = meshCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			meshCurveXRight.RemoveKey(num);
		}
		for (int num = 0; num < meshCurveXLeft.keys.Length; num++)
		{
			keyframe = meshCurveXLeft.keys[num];
			keyframe.value *= -1f;
			keyframe.inTangent *= -1f;
			keyframe.outTangent *= -1f;
			meshCurveXRight.AddKey(keyframe);
		}
		bool flag = false;
		for (int num = meshZPosH.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshZPosH.keys[num];
			if (keyframe.time > 0.5f)
			{
				meshZPosH.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshZPosH.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshZPosH.keys.Length; num++)
		{
			keyframe = meshZPosH.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshZPosH.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshCurveYTop.keys[num];
			if (keyframe.time > 0.5f)
			{
				meshCurveYTop.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshCurveYTop.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshCurveYTop.keys.Length; num++)
		{
			keyframe = meshCurveYTop.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshCurveYTop.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshCurveYBottom.keys[num];
			if (keyframe.time > 0.5f)
			{
				meshCurveYBottom.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshCurveYBottom.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshCurveYBottom.keys.Length; num++)
		{
			keyframe = meshCurveYBottom.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshCurveYBottom.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshDensityH.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshDensityH.keys[num];
			if (keyframe.time > 0.5f)
			{
				meshDensityH.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshDensityH.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshDensityH.keys.Length; num++)
		{
			keyframe = meshDensityH.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.value *= -1f;
				keyframe.value += 1f;
				float inTangent = keyframe.inTangent;
				keyframe.inTangent = keyframe.outTangent;
				keyframe.outTangent = inTangent;
			}
			meshDensityH.AddKey(keyframe);
		}
		for (int num = uvCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			uvCurveXRight.RemoveKey(num);
		}
		for (int num = 0; num < uvCurveXLeft.keys.Length; num++)
		{
			keyframe = uvCurveXLeft.keys[num];
			keyframe.value = keyframe.value * -1f + 1f;
			keyframe.inTangent *= -1f;
			keyframe.outTangent *= -1f;
			uvCurveXRight.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvCurveYTop.keys[num];
			if (keyframe.time > 0.5f)
			{
				uvCurveYTop.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvCurveYTop.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvCurveYTop.keys.Length; num++)
		{
			keyframe = uvCurveYTop.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			uvCurveYTop.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvCurveYBottom.keys[num];
			if (keyframe.time > 0.5f)
			{
				uvCurveYBottom.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvCurveYBottom.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvCurveYBottom.keys.Length; num++)
		{
			keyframe = uvCurveYBottom.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			uvCurveYBottom.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvDensityH.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvDensityH.keys[num];
			if (keyframe.time > 0.5f)
			{
				uvDensityH.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvDensityH.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvDensityH.keys.Length; num++)
		{
			keyframe = uvDensityH.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.value *= -1f;
				keyframe.value += 1f;
				float inTangent = keyframe.inTangent;
				keyframe.inTangent = keyframe.outTangent;
				keyframe.outTangent = inTangent;
			}
			uvDensityH.AddKey(keyframe);
		}
	}

	private void MirrorV()
	{
		Keyframe keyframe = default(Keyframe);
		bool flag = false;
		for (int num = meshZPosV.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshZPosV.keys[num];
			if (keyframe.time > 0.5f)
			{
				meshZPosV.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshZPosV.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshZPosV.keys.Length; num++)
		{
			keyframe = meshZPosV.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshZPosV.AddKey(keyframe);
		}
		for (int num = meshCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			meshCurveYBottom.RemoveKey(num);
		}
		for (int num = 0; num < meshCurveYTop.keys.Length; num++)
		{
			keyframe = meshCurveYTop.keys[num];
			keyframe.value *= -1f;
			keyframe.inTangent *= -1f;
			keyframe.outTangent *= -1f;
			meshCurveYBottom.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshCurveXLeft.keys[num];
			if (keyframe.time < 0.5f)
			{
				meshCurveXLeft.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshCurveXLeft.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshCurveXLeft.keys.Length; num++)
		{
			keyframe = meshCurveXLeft.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshCurveXLeft.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshCurveXRight.keys[num];
			if (keyframe.time < 0.5f)
			{
				meshCurveXRight.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshCurveXRight.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshCurveXRight.keys.Length; num++)
		{
			keyframe = meshCurveXRight.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			meshCurveXRight.AddKey(keyframe);
		}
		flag = false;
		for (int num = meshDensityV.keys.Length - 1; num >= 0; num--)
		{
			keyframe = meshDensityV.keys[num];
			if (keyframe.time < 0.5f)
			{
				meshDensityV.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					meshDensityV.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < meshDensityV.keys.Length; num++)
		{
			keyframe = meshDensityV.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.value *= -1f;
				keyframe.value += 1f;
				float inTangent = keyframe.inTangent;
				keyframe.inTangent = keyframe.outTangent;
				keyframe.outTangent = inTangent;
			}
			meshDensityV.AddKey(keyframe);
		}
		for (int num = uvCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			uvCurveYBottom.RemoveKey(num);
		}
		for (int num = 0; num < uvCurveYTop.keys.Length; num++)
		{
			keyframe = uvCurveYTop.keys[num];
			keyframe.value = keyframe.value * -1f + 1f;
			keyframe.inTangent *= -1f;
			keyframe.outTangent *= -1f;
			uvCurveYBottom.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvCurveXLeft.keys[num];
			if (keyframe.time < 0.5f)
			{
				uvCurveXLeft.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvCurveXLeft.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvCurveXLeft.keys.Length; num++)
		{
			keyframe = uvCurveXLeft.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			uvCurveXLeft.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvCurveXRight.keys[num];
			if (keyframe.time < 0.5f)
			{
				uvCurveXRight.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvCurveXRight.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvCurveXRight.keys.Length; num++)
		{
			keyframe = uvCurveXRight.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.inTangent *= -1f;
				keyframe.outTangent *= -1f;
			}
			uvCurveXRight.AddKey(keyframe);
		}
		flag = false;
		for (int num = uvDensityV.keys.Length - 1; num >= 0; num--)
		{
			keyframe = uvDensityV.keys[num];
			if (keyframe.time < 0.5f)
			{
				uvDensityV.RemoveKey(num);
			}
			else if (keyframe.time == 0.5f)
			{
				if (flag)
				{
					uvDensityV.RemoveKey(num);
				}
				else
				{
					flag = true;
				}
			}
		}
		for (int num = 0; num < uvDensityV.keys.Length; num++)
		{
			keyframe = uvDensityV.keys[num];
			if (keyframe.time == 0.5f)
			{
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
			}
			else
			{
				keyframe.time *= -1f;
				keyframe.time += 1f;
				keyframe.value *= -1f;
				keyframe.value += 1f;
				float inTangent = keyframe.inTangent;
				keyframe.inTangent = keyframe.outTangent;
				keyframe.outTangent = inTangent;
			}
			uvDensityV.AddKey(keyframe);
		}
	}

	private void SetDefaultCurve()
	{
		Keyframe key = default(Keyframe);
		for (int num = meshCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			meshCurveXLeft.RemoveKey(num);
		}
		key.time = 0f;
		key.value = -0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveXLeft.AddKey(key);
		key.time = 1f;
		meshCurveXLeft.AddKey(key);
		for (int num = meshCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			meshCurveXRight.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveXRight.AddKey(key);
		key.time = 1f;
		meshCurveXRight.AddKey(key);
		for (int num = meshCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			meshCurveYTop.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveYTop.AddKey(key);
		key.time = 1f;
		meshCurveYTop.AddKey(key);
		for (int num = meshCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			meshCurveYBottom.RemoveKey(num);
		}
		key.time = 0f;
		key.value = -0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveYBottom.AddKey(key);
		key.time = 1f;
		meshCurveYBottom.AddKey(key);
		for (int num = meshDensityH.keys.Length - 1; num >= 0; num--)
		{
			meshDensityH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		meshDensityH.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		meshDensityH.AddKey(key);
		for (int num = meshDensityV.keys.Length - 1; num >= 0; num--)
		{
			meshDensityV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		meshDensityV.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		meshDensityV.AddKey(key);
		for (int num = meshZPosH.keys.Length - 1; num >= 0; num--)
		{
			meshZPosH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshZPosH.AddKey(key);
		key.time = 1f;
		meshZPosH.AddKey(key);
		for (int num = meshZPosV.keys.Length - 1; num >= 0; num--)
		{
			meshZPosV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshZPosV.AddKey(key);
		key.time = 1f;
		meshZPosV.AddKey(key);
		for (int num = uvCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			uvCurveXLeft.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveXLeft.AddKey(key);
		key.time = 1f;
		uvCurveXLeft.AddKey(key);
		for (int num = uvCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			uvCurveXRight.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 1f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveXRight.AddKey(key);
		key.time = 1f;
		uvCurveXRight.AddKey(key);
		for (int num = uvCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			uvCurveYTop.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 1f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveYTop.AddKey(key);
		key.time = 1f;
		uvCurveYTop.AddKey(key);
		for (int num = uvCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			uvCurveYBottom.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveYBottom.AddKey(key);
		key.time = 1f;
		uvCurveYBottom.AddKey(key);
		for (int num = uvDensityH.keys.Length - 1; num >= 0; num--)
		{
			uvDensityH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		uvDensityH.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		uvDensityH.AddKey(key);
		for (int num = uvDensityV.keys.Length - 1; num >= 0; num--)
		{
			uvDensityV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		uvDensityV.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		uvDensityV.AddKey(key);
	}

	private void SetDefaultCurve90()
	{
		Keyframe key = default(Keyframe);
		for (int num = meshCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			meshCurveXLeft.RemoveKey(num);
		}
		key.time = 0f;
		key.value = -0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveXLeft.AddKey(key);
		key.time = 1f;
		meshCurveXLeft.AddKey(key);
		for (int num = meshCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			meshCurveXRight.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveXRight.AddKey(key);
		key.time = 1f;
		meshCurveXRight.AddKey(key);
		for (int num = meshCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			meshCurveYTop.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveYTop.AddKey(key);
		key.time = 1f;
		meshCurveYTop.AddKey(key);
		for (int num = meshCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			meshCurveYBottom.RemoveKey(num);
		}
		key.time = 0f;
		key.value = -0.5f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshCurveYBottom.AddKey(key);
		key.time = 1f;
		meshCurveYBottom.AddKey(key);
		for (int num = meshDensityH.keys.Length - 1; num >= 0; num--)
		{
			meshDensityH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		meshDensityH.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		meshDensityH.AddKey(key);
		for (int num = meshDensityV.keys.Length - 1; num >= 0; num--)
		{
			meshDensityV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		meshDensityV.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		meshDensityV.AddKey(key);
		for (int num = meshZPosH.keys.Length - 1; num >= 0; num--)
		{
			meshZPosH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshZPosH.AddKey(key);
		key.time = 1f;
		meshZPosH.AddKey(key);
		for (int num = meshZPosV.keys.Length - 1; num >= 0; num--)
		{
			meshZPosV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		meshZPosV.AddKey(key);
		key.time = 1f;
		meshZPosV.AddKey(key);
		for (int num = uvCurveXLeft.keys.Length - 1; num >= 0; num--)
		{
			uvCurveXLeft.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveXLeft.AddKey(key);
		key.time = 1f;
		uvCurveXLeft.AddKey(key);
		for (int num = uvCurveXRight.keys.Length - 1; num >= 0; num--)
		{
			uvCurveXRight.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 1f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveXRight.AddKey(key);
		key.time = 1f;
		uvCurveXRight.AddKey(key);
		for (int num = uvCurveYTop.keys.Length - 1; num >= 0; num--)
		{
			uvCurveYTop.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 1f;
		key.inTangent = -0.67f;
		key.outTangent = -0.67f;
		uvCurveYTop.AddKey(key);
		key.time = 0.5f;
		key.value = 0.865f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveYTop.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		key.inTangent = 0.67f;
		key.outTangent = 0.67f;
		uvCurveYTop.AddKey(key);
		for (int num = uvCurveYBottom.keys.Length - 1; num >= 0; num--)
		{
			uvCurveYBottom.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 0.67f;
		key.outTangent = 0.67f;
		uvCurveYBottom.AddKey(key);
		key.time = 0.5f;
		key.value = 0.135f;
		key.inTangent = 0f;
		key.outTangent = 0f;
		uvCurveYBottom.AddKey(key);
		key.time = 1f;
		key.value = 0f;
		key.inTangent = -0.67f;
		key.outTangent = -0.67f;
		uvCurveYBottom.AddKey(key);
		for (int num = uvDensityH.keys.Length - 1; num >= 0; num--)
		{
			uvDensityH.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1.423f;
		key.outTangent = 1.423f;
		uvDensityH.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		uvDensityH.AddKey(key);
		for (int num = uvDensityV.keys.Length - 1; num >= 0; num--)
		{
			uvDensityV.RemoveKey(num);
		}
		key.time = 0f;
		key.value = 0f;
		key.inTangent = 1f;
		key.outTangent = 1f;
		uvDensityV.AddKey(key);
		key.time = 1f;
		key.value = 1f;
		uvDensityV.AddKey(key);
	}
}
