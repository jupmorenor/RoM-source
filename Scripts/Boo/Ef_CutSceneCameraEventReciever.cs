using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_CutSceneCameraEventReciever : MonoBehaviour
{
	[Serializable]
	public class Ef_CutSceneCameraEvent_OneCut
	{
		public Ef_CutSceneEffects effs;

		public int leng;

		public int pt;

		public float nextTime;

		public Ef_CutSceneCameraEvent_OneCut(Ef_CutSceneEffects ef)
		{
			effs = ef;
			leng = effs.effects.Length;
			pt = 0;
			nextTime = 0f;
			if (leng <= 0)
			{
				throw new AssertionFailedException(new StringBuilder("No Frame Setting : ").Append(ef.name).ToString());
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Init_002415376 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject[] _0024prefabs_002415377;

			internal int _0024count_002415378;

			internal string _0024animName_002415379;

			internal GameObject[] _0024_0024sfor_0024675_002415380;

			internal int _0024_0024sfor_0024677_002415381;

			internal int _0024_0024sfor_0024676_002415382;

			internal int _0024_00244072_002415383;

			internal GameObject _0024p_002415384;

			internal Ef_CutSceneEffects _0024effs_002415385;

			internal Ef_CutSceneCameraEventReciever _0024self__002415386;

			public _0024(Ef_CutSceneCameraEventReciever self_)
			{
				_0024self__002415386 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002415386.manager = CutSceneManager.Instance;
					goto case 2;
				case 2:
					if (!(_0024self__002415386._cam = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if ((bool)_0024self__002415386.cutSceneEffs)
					{
						_0024prefabs_002415377 = _0024self__002415386.cutSceneEffs.prefabs;
						_0024count_002415378 = 0;
						_0024animName_002415379 = string.Empty;
						_0024_0024sfor_0024675_002415380 = _0024prefabs_002415377;
						_0024_0024sfor_0024677_002415381 = _0024_0024sfor_0024675_002415380.Length;
						_0024_0024sfor_0024676_002415382 = 0;
						while (_0024_0024sfor_0024676_002415382 < _0024_0024sfor_0024677_002415381)
						{
							GameObject[] array = _0024_0024sfor_0024675_002415380;
							int num = (_0024_0024sfor_0024676_002415382 = checked((_0024_00244072_002415383 = _0024_0024sfor_0024676_002415382) + 1));
							_0024p_002415384 = array[RuntimeServices.NormalizeArrayIndex(array, _0024_00244072_002415383)];
							_0024effs_002415385 = _0024p_002415384.GetComponent<Ef_CutSceneEffects>();
							if ((bool)_0024effs_002415385)
							{
								_0024self__002415386.cutEffs[_0024p_002415384.name] = new Ef_CutSceneCameraEvent_OneCut(_0024effs_002415385);
							}
						}
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Ef_CutSceneCameraEventReciever _0024self__002415387;

		public _0024Init_002415376(Ef_CutSceneCameraEventReciever self_)
		{
			_0024self__002415387 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415387);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024timeBomb_002415388 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024elapsed_002415389;

			internal int _0024i_002415390;

			internal float _0024nex_002415391;

			internal int _0024_00247425_002415392;

			internal int _0024_00247426_002415393;

			internal Ef_CutSceneCameraEvent_OneCut _0024cut_002415394;

			internal Ef_CutSceneCameraEventReciever _0024self__002415395;

			public _0024(Ef_CutSceneCameraEvent_OneCut cut, Ef_CutSceneCameraEventReciever self_)
			{
				_0024cut_002415394 = cut;
				_0024self__002415395 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024elapsed_002415389 = 0f;
					_0024_00247425_002415392 = 0;
					_0024_00247426_002415393 = _0024cut_002415394.leng;
					if (_0024_00247426_002415393 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					goto IL_016b;
				case 2:
					_0024elapsed_002415389 += Time.deltaTime * _0024self__002415395.manager.animSpeed;
					goto IL_012c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_012c:
					if (_0024elapsed_002415389 < _0024cut_002415394.nextTime)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002415395.Emit(_0024cut_002415394);
					_0024cut_002415394.pt = checked(_0024cut_002415394.pt + 1);
					goto IL_016b;
					IL_016b:
					if (_0024_00247425_002415392 < _0024_00247426_002415393)
					{
						_0024i_002415390 = _0024_00247425_002415392;
						_0024_00247425_002415392++;
						if (_0024cut_002415394.pt < _0024cut_002415394.leng)
						{
							Ef_CutSceneEffectParameter[] effects = _0024cut_002415394.effs.effects;
							_0024nex_002415391 = (float)effects[RuntimeServices.NormalizeArrayIndex(effects, _0024cut_002415394.pt)].frame * 0.0333333f;
							if (!(_0024nex_002415391 >= _0024cut_002415394.nextTime))
							{
								throw new AssertionFailedException("Effect 時間指定の順序間違えてるよ");
							}
							_0024cut_002415394.nextTime = _0024nex_002415391;
							goto IL_012c;
						}
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Ef_CutSceneCameraEvent_OneCut _0024cut_002415396;

		internal Ef_CutSceneCameraEventReciever _0024self__002415397;

		public _0024timeBomb_002415388(Ef_CutSceneCameraEvent_OneCut cut, Ef_CutSceneCameraEventReciever self_)
		{
			_0024cut_002415396 = cut;
			_0024self__002415397 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024cut_002415396, _0024self__002415397);
		}
	}

	public Ef_Prefabs cutSceneEffs;

	public bool sort;

	private int num;

	private Hashtable cutEffs;

	private BasicCamera _cam;

	private CutSceneManager manager;

	[NonSerialized]
	private const float FRAMESTEP = 0.0333333f;

	[NonSerialized]
	protected static string bulletName;

	private GameObject cam => (!_cam) ? null : _cam.gameObject;

	private bool ready
	{
		get
		{
			bool num = cam != null;
			if (num)
			{
				num = manager != null;
			}
			if (num)
			{
				num = cutSceneEffs != null;
			}
			return num;
		}
	}

	public Ef_CutSceneCameraEventReciever()
	{
		cutEffs = new Hashtable();
	}

	public IEnumerator Init()
	{
		return new _0024Init_002415376(this).GetEnumerator();
	}

	public static void OnCameraAnimationStart(string animName)
	{
		bulletName = new StringBuilder("Ef_").Append(animName).ToString();
	}

	public void Start()
	{
		if (sort)
		{
			Sort();
			sort = false;
		}
		IEnumerator enumerator = Init();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void LateUpdate()
	{
		if (sort)
		{
			Sort();
			sort = false;
		}
		if (ready && cutEffs != null && !string.IsNullOrEmpty(bulletName) && cutEffs.ContainsKey(bulletName))
		{
			object obj = cutEffs[bulletName];
			if (!(obj is Ef_CutSceneCameraEvent_OneCut))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Ef_CutSceneCameraEvent_OneCut));
			}
			Ef_CutSceneCameraEvent_OneCut cut = (Ef_CutSceneCameraEvent_OneCut)obj;
			IEnumerator enumerator = timeBomb(cut);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			bulletName = string.Empty;
		}
	}

	public IEnumerator timeBomb(Ef_CutSceneCameraEvent_OneCut cut)
	{
		return new _0024timeBomb_002415388(cut, this).GetEnumerator();
	}

	public void Emit(Ef_CutSceneCameraEvent_OneCut cut)
	{
		int pt = cut.pt;
		Ef_CutSceneEffects effs = cut.effs;
		Ef_CutSceneEffectParameter[] effects = effs.effects;
		int leng = cut.leng;
		GameObject original = null;
		string text = string.Empty;
		Vector3 vector = Vector3.zero;
		Quaternion quaternion = Quaternion.identity;
		if (leng > pt)
		{
			original = effects[RuntimeServices.NormalizeArrayIndex(effects, pt)].effectObj;
			text = effects[RuntimeServices.NormalizeArrayIndex(effects, pt)].attachObj;
			vector = effects[RuntimeServices.NormalizeArrayIndex(effects, pt)].offsetPos;
			quaternion = Quaternion.Euler(effects[RuntimeServices.NormalizeArrayIndex(effects, pt)].offsetRot);
		}
		Vector3 vector2 = default(Vector3);
		Quaternion quaternion2 = default(Quaternion);
		if (text == "Camera")
		{
			if (!cam)
			{
				return;
			}
			vector2 = cam.transform.position + cam.transform.rotation * vector;
			quaternion2 = cam.transform.rotation * quaternion;
			original = (GameObject)UnityEngine.Object.Instantiate(original, vector2, quaternion2);
		}
		else
		{
			original = (GameObject)UnityEngine.Object.Instantiate(original, vector, quaternion);
		}
		if (!(original != null))
		{
			throw new AssertionFailedException("gameObj != null");
		}
		original.SetActive(value: true);
	}

	public void Sort()
	{
		GameObject[] prefabs = cutSceneEffs.prefabs;
		int num = 0;
		int length = prefabs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Ef_CutSceneEffects component = prefabs[RuntimeServices.NormalizeArrayIndex(prefabs, index)].GetComponent<Ef_CutSceneEffects>();
			Ef_CutSceneEffectParameter[] effects = component.effects;
			int length2 = effects.Length;
			int[] array = new int[length2];
			bool[] array2 = new bool[length2];
			int num2 = 0;
			int num3 = length2;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index2 = num2;
				num2++;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index2)] = false;
			}
			int num4 = 0;
			int num5 = length2;
			if (num5 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num4 < num5)
			{
				int index3 = num4;
				num4++;
				int num6 = 9999;
				int num7 = 0;
				int num8 = length2;
				if (num8 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num7 < num8)
				{
					int num9 = num7;
					num7++;
					if (effects[RuntimeServices.NormalizeArrayIndex(effects, num9)].frame < num6)
					{
						if (!array2[RuntimeServices.NormalizeArrayIndex(array2, num9)])
						{
							array[RuntimeServices.NormalizeArrayIndex(array, index3)] = num9;
							num6 = effects[RuntimeServices.NormalizeArrayIndex(effects, num9)].frame;
						}
					}
				}
				array2[RuntimeServices.NormalizeArrayIndex(array2, array[RuntimeServices.NormalizeArrayIndex(array, index3)])] = true;
			}
			int[] array3 = new int[length2];
			GameObject[] array4 = new GameObject[length2];
			string[] array5 = new string[length2];
			Vector3[] array6 = new Vector3[length2];
			Vector3[] array7 = new Vector3[length2];
			int num10 = 0;
			int num11 = length2;
			if (num11 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num10 < num11)
			{
				int index4 = num10;
				num10++;
				array3[RuntimeServices.NormalizeArrayIndex(array3, index4)] = effects[RuntimeServices.NormalizeArrayIndex(effects, array[RuntimeServices.NormalizeArrayIndex(array, index4)])].frame;
				array4[RuntimeServices.NormalizeArrayIndex(array4, index4)] = effects[RuntimeServices.NormalizeArrayIndex(effects, array[RuntimeServices.NormalizeArrayIndex(array, index4)])].effectObj;
				array5[RuntimeServices.NormalizeArrayIndex(array5, index4)] = effects[RuntimeServices.NormalizeArrayIndex(effects, array[RuntimeServices.NormalizeArrayIndex(array, index4)])].attachObj;
				ref Vector3 reference = ref array6[RuntimeServices.NormalizeArrayIndex(array6, index4)];
				reference = effects[RuntimeServices.NormalizeArrayIndex(effects, array[RuntimeServices.NormalizeArrayIndex(array, index4)])].offsetPos;
				ref Vector3 reference2 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, index4)];
				reference2 = effects[RuntimeServices.NormalizeArrayIndex(effects, array[RuntimeServices.NormalizeArrayIndex(array, index4)])].offsetRot;
			}
			int num12 = 0;
			int num13 = length2;
			if (num13 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num12 < num13)
			{
				int index5 = num12;
				num12++;
				Ef_CutSceneEffectParameter[] effects2 = component.effects;
				Ef_CutSceneEffectParameter ef_CutSceneEffectParameter = effects2[RuntimeServices.NormalizeArrayIndex(effects2, index5)];
				ef_CutSceneEffectParameter.frame = array3[RuntimeServices.NormalizeArrayIndex(array3, index5)];
				ef_CutSceneEffectParameter.effectObj = array4[RuntimeServices.NormalizeArrayIndex(array4, index5)];
				ef_CutSceneEffectParameter.attachObj = array5[RuntimeServices.NormalizeArrayIndex(array5, index5)];
				ef_CutSceneEffectParameter.offsetPos = array6[RuntimeServices.NormalizeArrayIndex(array6, index5)];
				ef_CutSceneEffectParameter.offsetRot = array7[RuntimeServices.NormalizeArrayIndex(array7, index5)];
			}
		}
	}
}
