using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class EffectViewer : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_start_002424550 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal List _0024clips_002424551;

			internal AnimationState _0024x_002424552;

			internal AnimationClip _0024c_002424553;

			internal IEnumerator _0024_0024iterator_002414241_002424554;

			internal IEnumerator<object> _0024_0024iterator_002414242_002424555;

			internal EffectViewer _0024self__002424556;

			public _0024(EffectViewer self_)
			{
				_0024self__002424556 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024clips_002424551 = new List();
					_0024_0024iterator_002414241_002424554 = _0024self__002424556.animation.GetEnumerator();
					while (_0024_0024iterator_002414241_002424554.MoveNext())
					{
						object obj = _0024_0024iterator_002414241_002424554.Current;
						if (!(obj is AnimationState))
						{
							obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
						}
						_0024x_002424552 = (AnimationState)obj;
						_0024clips_002424551.Add(_0024x_002424552.clip);
					}
					_0024_0024iterator_002414242_002424555 = _0024clips_002424551.GetEnumerator();
					try
					{
						while (_0024_0024iterator_002414242_002424555.MoveNext())
						{
							object obj2 = _0024_0024iterator_002414242_002424555.Current;
							if (!(obj2 is AnimationClip))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(AnimationClip));
							}
							_0024c_002424553 = (AnimationClip)obj2;
							registerEvent(_0024c_002424553);
						}
					}
					finally
					{
						_0024_0024iterator_002414242_002424555.Dispose();
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EffectViewer _0024self__002424557;

		public _0024_start_002424550(EffectViewer self_)
		{
			_0024self__002424557 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002424557);
		}
	}

	private List clips;

	private GameObject parent;

	[NonSerialized]
	internal static Regex _0024re_002424731 = new Regex("([fF]ly|[lL]and)_");

	public void Start()
	{
		StartCoroutine(_start());
	}

	public IEnumerator _start()
	{
		return new _0024_start_002424550(this).GetEnumerator();
	}

	public static void registerEvent(AnimationClip clip)
	{
		string key = _0024re_002424731.Replace(clip.name, string.Empty).ToLower();
		object obj = ViewerTable.MOT2EFF_TABLE[key];
		if (!(obj is Array))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Array));
		}
		Array array = (Array)obj;
		if (array == null)
		{
			return;
		}
		IEnumerator enumerator = array.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj2 = enumerator.Current;
			if (!(obj2 is Array))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(Array));
			}
			Array array2 = (Array)obj2;
			try
			{
				if (RuntimeServices.ToBool(((IList)array2)[1]))
				{
					object obj3 = ((IList)array2)[1];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					makeEvent(clip, (string)obj3, RuntimeServices.UnboxSingle(((IList)array2)[0]));
				}
			}
			catch (Exception)
			{
				Debug.Log("failed attach event: " + ((IList)array2)[1]);
			}
		}
	}

	public static void makeEvent(AnimationClip clip, string ef_name, float timing)
	{
		AnimationEvent animationEvent = new AnimationEvent();
		animationEvent.time = timing;
		animationEvent.functionName = "effectEventHandler";
		animationEvent.stringParameter = ef_name;
		clip.AddEvent(animationEvent);
	}

	public void fire(string efPath)
	{
		fire(efPath, "poly", is_homing: false);
	}

	public void fire(string efPath, string bone)
	{
		fire(efPath, bone, is_homing: false);
	}

	public void fire(string efPath, string bone, bool is_homing)
	{
		fire(efPath, bone, is_homing, rotate: false);
	}

	public void fire(string efPath, string bone, bool is_homing, bool rotate)
	{
		fire(efPath, bone, is_homing, rotate, Vector3.zero);
	}

	public void fire(string efPath, string bone, bool is_homing, bool rotate, Vector3 offset)
	{
		if (string.IsNullOrEmpty(bone))
		{
			bone = "Root";
		}
		GameObject original = loadResource(efPath);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(original);
		parent = findBone(bone);
		gameObject.transform.position = parent.transform.position + offset;
		if (is_homing)
		{
			gameObject.transform.parent = parent.transform;
			gameObject.transform.localPosition = offset;
		}
		if (rotate)
		{
			gameObject.transform.rotation = parent.transform.rotation;
		}
	}

	public void effectEventHandler(string ef_name)
	{
		object obj = ViewerTable.EFFECT_TABLE[ef_name];
		if (!(obj is Array))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Array));
		}
		Array array = (Array)obj;
		object obj2 = ((IList)array)[0];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string text;
		string efPath = (string.IsNullOrEmpty(text = (string)obj2) ? ef_name : text);
		object obj3 = ((IList)array)[1];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		string text2;
		string text3 = (string.IsNullOrEmpty(text2 = (string)obj3) ? name : text2);
		bool is_homing = RuntimeServices.UnboxBoolean(((IList)array)[2]);
		bool rotate = RuntimeServices.UnboxBoolean(((IList)array)[3]);
		if (((IList)array)[4] == null)
		{
			if (!string.IsNullOrEmpty(ef_name))
			{
				if (string.IsNullOrEmpty(text3))
				{
					text3 = name;
				}
				fire(efPath, text3, is_homing, rotate);
			}
		}
		else
		{
			object obj4 = ((IList)array)[4];
			if (!(obj4 is double[]))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(double[]));
			}
			Vector3 offset = parseStringIntoVector((double[])obj4);
			fire(efPath, text3, is_homing, rotate, offset);
		}
	}

	public Vector3 parseStringIntoVector(double[] s)
	{
		float x = (float)s[0];
		float y = (float)s[1];
		float z = (float)s[2];
		return new Vector3(x, y, z);
	}

	public object findEffecByEf_name(string ef_name)
	{
		return ViewerTable.EFFECT_TABLE[ef_name];
	}

	public GameObject findBone(string bone)
	{
		return GameObject.Find(bone);
	}

	public GameObject loadResource(string asset_name)
	{
		string assetPath = ((!RuntimeServices.op_Member("/", asset_name)) ? ("Assets/Effect/_Ef_Prefab" + "/" + asset_name + ".prefab") : asset_name);
		return ((GameObject)Resources.LoadAssetAtPath(assetPath, typeof(GameObject))) as GameObject;
	}
}
