using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MotionViewer : MonoBehaviour
{
	[Serializable]
	private enum MaterialCheckMode
	{
		Default,
		Diffuse,
		Outline
	}

	[Serializable]
	internal class _0024changeMaterial_0024locals_002414584
	{
		internal MaterialCheckMode _0024mode;
	}

	[Serializable]
	internal class _0024changeMaterial_0024_change_00246570
	{
		internal _0024changeMaterial_0024locals_002414584 _0024_0024locals_002415280;

		internal MotionViewer _0024this_002415281;

		public _0024changeMaterial_0024_change_00246570(_0024changeMaterial_0024locals_002414584 _0024_0024locals_002415280, MotionViewer _0024this_002415281)
		{
			this._0024_0024locals_002415280 = _0024_0024locals_002415280;
			this._0024this_002415281 = _0024this_002415281;
		}

		public void Invoke(string m)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = _0024this_002415281.searchPolyMeshRenderer();
			Texture mainTexture = null;
			IEnumerator<object[]> enumerator = Builtins.enumerate(skinnedMeshRenderer.materials).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object[] current = enumerator.Current;
					object value = current[0];
					object obj = current[1];
					if (!(obj is Material))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Material));
					}
					Material material = (Material)obj;
					material.shader = Shader.Find(m);
					if (_0024_0024locals_002415280._0024mode == MaterialCheckMode.Diffuse)
					{
						_0024this_002415281.defaultMaterialList.Add(material.mainTexture);
						material.mainTexture = mainTexture;
						material.color = new Color(0.8f, 0.8f, 0.8f, 0.3f);
					}
					else if (((ICollection)_0024this_002415281.defaultMaterialList).Count > 1)
					{
						object obj2 = _0024this_002415281.defaultMaterialList[RuntimeServices.UnboxInt32(value)];
						if (!(obj2 is Texture))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(Texture));
						}
						material.mainTexture = (Texture)obj2;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	private string current_label;

	public AnimationState state;

	private List clips;

	public bool dispPlaycontrol;

	public bool dispInformation;

	private bool play;

	private bool loop;

	private readonly string defaultMat;

	private readonly string diffuseMat;

	private readonly string outlineMat;

	private List defaultMaterialList;

	public MotionViewer()
	{
		dispInformation = true;
		play = true;
		loop = true;
		defaultMat = "Mobile/Unlit (Supports Lightmap)";
		diffuseMat = "Diffuse";
		outlineMat = "Outlined/Silhouetted Unlit";
		defaultMaterialList = new List();
	}

	public void Awake()
	{
		if (!animation || !animation.clip)
		{
			return;
		}
		clips = new List();
		IEnumerator enumerator = animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			clips.Add(animationState.clip);
		}
	}

	public void Update()
	{
		if ((bool)animation && (bool)animation.clip)
		{
			state = animation[animation.clip.name];
			if (!play)
			{
				state.speed = 0f;
			}
			else
			{
				state.speed = 1f;
			}
			if (loop && !animation.IsPlaying(animation.clip.name))
			{
				animation.Play();
			}
			string lhs = null;
			if ((bool)state)
			{
				lhs += "[animation]\t" + state.name + "\n";
				lhs += "[sec]\t\t\t\t" + state.time + "\n";
				lhs += "[frame]\t\t\t" + MotionViewerModule.seconds_to_frame(state.time) + "\n";
				lhs += "[total]\t\t\t" + MotionViewerModule.seconds_to_frame(state.length) + " frame\n";
			}
			current_label = lhs;
		}
	}

	public void OnGUI()
	{
		if (dispInformation)
		{
			GUI.skin.box.alignment = TextAnchor.MiddleLeft;
			GUI.Box(new Rect(130f, 50f, 250f, 90f), current_label);
		}
		if (dispPlaycontrol)
		{
			if (GUI.Button(new Rect(10f, 140f, 120f, 30f), "<<PrevMot"))
			{
				prev_motion();
			}
			if (GUI.Button(new Rect(300f, 140f, 120f, 30f), "NextMot>>"))
			{
				next_motion();
			}
			if (GUI.Button(new Rect(10f, 170f, 100f, 50f), "<<Prev"))
			{
				prev_frame();
			}
			if (GUI.Button(new Rect(160f, 170f, 100f, 50f), "Play?"))
			{
				toggle_play();
			}
			if (GUI.Button(new Rect(320f, 170f, 100f, 50f), "Next>>"))
			{
				next_frame();
			}
		}
	}

	public void toggle_play()
	{
		char_active();
		play = !play;
		loop = true;
	}

	public void play_anim()
	{
		char_active();
		play = true;
	}

	public void stop_anim()
	{
		char_active();
		play = false;
	}

	public void prev_frame()
	{
		char_active();
		stop_anim();
		state.time = (float)((double)state.time - MotionViewerModule.get_one_frame());
	}

	public void next_frame()
	{
		char_active();
		stop_anim();
		state.time = (float)((double)state.time + MotionViewerModule.get_one_frame());
	}

	public void OnEnable()
	{
		if (!animation.isPlaying)
		{
			next_motion();
		}
	}

	public void next_motion()
	{
		char_active();
		char_active();
		string empty = string.Empty;
		IEnumerator enumerator = animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			if (!animation.isPlaying)
			{
				animation.clip = animation[animationState.name].clip;
				animation.Play(animationState.name);
				break;
			}
			if (!(animationState.time <= 0f))
			{
				if (empty != string.Empty)
				{
					animation.clip = animation[empty].clip;
					animation.Play(empty);
				}
				break;
			}
			empty = animationState.name;
		}
	}

	public void prev_motion()
	{
		char_active();
		bool flag = false;
		IEnumerator enumerator = animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			if (!animation.isPlaying)
			{
				animation.clip = animation[animationState.name].clip;
				animation.Play(animationState.name);
				break;
			}
			if (flag)
			{
				animation.clip = animation[animationState.name].clip;
				animation.Play(animationState.name);
				break;
			}
			if (!(animationState.time <= 0f))
			{
				flag = true;
			}
		}
	}

	public void char_active()
	{
		if (!gameObject.active && (bool)transform.parent)
		{
			int num = 0;
			int childCount = transform.parent.childCount;
			if (childCount < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < childCount)
			{
				int index = num;
				num++;
				transform.parent.GetChild(index).gameObject.SetActive(value: false);
			}
			gameObject.SetActive(value: true);
		}
	}

	public void next_char()
	{
		bool flag = false;
		if (!transform.parent)
		{
			return;
		}
		int childCount = transform.parent.childCount;
		int num = 0;
		int num2 = childCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			if (flag || num3 == checked(childCount - 1))
			{
				transform.parent.GetChild(num3).gameObject.SetActive(value: true);
				break;
			}
			if (transform.parent.GetChild(num3).active)
			{
				flag = true;
				transform.parent.GetChild(num3).gameObject.SetActive(value: false);
			}
		}
	}

	public void prev_char()
	{
		bool flag = false;
		if (!transform.parent)
		{
			return;
		}
		int num = checked(transform.parent.childCount - 1);
		int num2 = 1;
		if (0 < num)
		{
			num2 = -1;
		}
		while (num != 0)
		{
			int num3 = num;
			num += num2;
			if (flag || num3 == 0)
			{
				transform.parent.GetChild(num3).gameObject.SetActive(value: true);
				break;
			}
			if (transform.parent.GetChild(num3).active)
			{
				flag = true;
				transform.parent.GetChild(num3).gameObject.SetActive(value: false);
			}
		}
	}

	public void changeMaterialDefault()
	{
		changeMaterial(MaterialCheckMode.Default);
	}

	public void changeMaterialDiffuse()
	{
		changeMaterial(MaterialCheckMode.Diffuse);
	}

	public void changeMaterialOutline()
	{
		changeMaterial(MaterialCheckMode.Outline);
	}

	private void changeMaterial(MaterialCheckMode mode)
	{
		_0024changeMaterial_0024locals_002414584 _0024changeMaterial_0024locals_0024 = new _0024changeMaterial_0024locals_002414584();
		_0024changeMaterial_0024locals_0024._0024mode = mode;
		__Req_FailHandler_0024callable6_0024440_32__ _Req_FailHandler_0024callable6_0024440_32__ = new _0024changeMaterial_0024_change_00246570(_0024changeMaterial_0024locals_0024, this).Invoke;
		if (_0024changeMaterial_0024locals_0024._0024mode == MaterialCheckMode.Default)
		{
			_Req_FailHandler_0024callable6_0024440_32__(defaultMat);
		}
		else if (_0024changeMaterial_0024locals_0024._0024mode == MaterialCheckMode.Outline)
		{
			_Req_FailHandler_0024callable6_0024440_32__(outlineMat);
		}
		else if (_0024changeMaterial_0024locals_0024._0024mode == MaterialCheckMode.Diffuse)
		{
			_Req_FailHandler_0024callable6_0024440_32__(diffuseMat);
		}
		else
		{
			Debug.Log("そんモードねーぞ");
		}
	}

	private SkinnedMeshRenderer searchPolyMeshRenderer()
	{
		return GetComponentInChildren<SkinnedMeshRenderer>();
	}
}
