using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(ColorCorrectionCurves))]
public class DebugColorCorrector : MonoBehaviour
{
	[NonSerialized]
	private static bool _Enabled;

	[NonSerialized]
	private static Boo.Lang.List<DebugColorCorrector> _Instances = new Boo.Lang.List<DebugColorCorrector>();

	public Material material;

	private Vector3 mousePos;

	private bool moveMode;

	private AnimationCurve curDragAnimation;

	private int curDragKeyIndex;

	public static bool Enabled
	{
		get
		{
			return _Enabled;
		}
		set
		{
			if (value == _Enabled)
			{
				return;
			}
			_Enabled = value;
			if (value && _Instances.Count <= 0)
			{
				GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugColorCorrector");
			}
			IEnumerator<DebugColorCorrector> enumerator = _Instances.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DebugColorCorrector current = enumerator.Current;
					current.gameObject.SetActive(value);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public void Start()
	{
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		if (!_Instances.Contains(this))
		{
			_Instances.Add(this);
		}
	}

	public void OnGUI()
	{
		ColorCorrectionCurves component = GetComponent<ColorCorrectionCurves>();
		if (!(component == null))
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePos = new Vector3(mousePosition.x / (float)Screen.width, mousePosition.y / (float)Screen.height, 0f);
			if (Input.GetMouseButtonDown(0))
			{
				moveMode = true;
			}
			else if (!Input.GetMouseButton(0))
			{
				moveMode = false;
				curDragAnimation = null;
			}
		}
	}

	public void OnPostRender()
	{
		GL.Clear(clearDepth: true, clearColor: false, Color.red);
		material.SetPass(0);
		GL.PushMatrix();
		GL.LoadOrtho();
		double num = 0.29;
		double num2 = 0.6;
		ColorCorrectionCurves component = GetComponent<ColorCorrectionCurves>();
		if (component != null)
		{
			bool flag = drawGraph(component.redChannel, 0.05f, 0.1f, (float)num, (float)num2, Color.red);
			bool flag2 = drawGraph(component.greenChannel, (float)(0.05 + num), 0.1f, (float)num, (float)num2, Color.green);
			bool flag3 = drawGraph(component.blueChannel, (float)(0.05 + num * 2.0), 0.1f, (float)num, (float)num2, Color.blue);
			if (flag || flag2 || flag3)
			{
				component.UpdateParameters();
			}
		}
		GL.PopMatrix();
	}

	private bool drawGraph(AnimationCurve anim, float x, float y, float w, float h, Color col)
	{
		double num = 0.001;
		double num2 = num * (double)Screen.width / (double)(float)Screen.height;
		drawGraphSub(anim, (float)((double)x + num), (float)((double)y - num2), w, h, Color.black, edit: false);
		return drawGraphSub(anim, x, y, w, h, col, edit: true);
	}

	private bool drawGraphSub(AnimationCurve anim, float x, float y, float w, float h, Color col, bool edit)
	{
		bool result = false;
		GL.Begin(1);
		line(x, y, x + w, y, col);
		line(x, y, x, y + h, col);
		if (anim != null)
		{
			int num = 20;
			int num2 = 0;
			int num3 = num;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int num4 = num2;
				num2++;
				float num5 = (float)num4 / (float)num;
				float num6 = (float)checked(num4 + 1) / (float)num;
				float num7 = anim.Evaluate(num5);
				float num8 = anim.Evaluate(num6);
				float x2 = num5 * w + x;
				float x3 = num6 * w + x;
				float y2 = num7 * h + y;
				float y3 = num8 * h + y;
				line(x2, y2, x3, y3, col);
			}
			Keyframe[] keys = anim.keys;
			int num9 = 0;
			int length = keys.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num9 < length)
			{
				int index = num9;
				num9++;
				Keyframe keyframe = keys[RuntimeServices.NormalizeArrayIndex(keys, index)];
				float x2 = keyframe.time * w + x;
				float y2 = keyframe.value * h + y;
				if (point(x2, y2, 0.01f, col))
				{
					curDragAnimation = anim;
					curDragKeyIndex = index;
				}
			}
			if (edit && moveMode && curDragKeyIndex >= 0 && RuntimeServices.EqualityOperator(curDragAnimation, anim))
			{
				keys[RuntimeServices.NormalizeArrayIndex(keys, curDragKeyIndex)].time = (mousePos.x - x) / w;
				keys[RuntimeServices.NormalizeArrayIndex(keys, curDragKeyIndex)].value = (mousePos.y - y) / h;
				anim.keys = keys;
				result = true;
			}
		}
		GL.End();
		return result;
	}

	private void line(float x0, float y0, float x1, float y1, Color c)
	{
		GL.Color(c);
		GL.Vertex(new Vector3(x0, y0));
		GL.Vertex(new Vector3(x1, y1));
	}

	private bool point(float x, float y, float s, Color c)
	{
		bool flag = false;
		float num = s * (float)Screen.width / (float)Screen.height;
		flag = (double)Vector3.Distance(new Vector3(x, y, 0f), mousePos) < 0.08;
		if (flag)
		{
			GL.Color(Color.white);
		}
		else
		{
			GL.Color(c);
		}
		GL.Vertex(new Vector3(x, y - num));
		GL.Vertex(new Vector3(x + s, y));
		GL.Vertex(new Vector3(x + s, y));
		GL.Vertex(new Vector3(x, y + num));
		GL.Vertex(new Vector3(x, y + num));
		GL.Vertex(new Vector3(x - s, y));
		GL.Vertex(new Vector3(x - s, y));
		GL.Vertex(new Vector3(x, y - num));
		return flag;
	}
}
