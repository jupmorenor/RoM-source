using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using ObjUtil;
using UnityEngine;

[Serializable]
public class TargetChaseMaker : MonoBehaviour
{
	[Serializable]
	private struct TargetInfo
	{
		public AIControl ai;

		public Transform target;

		public GameObject maker;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024drawRoutine_002421460 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024pos_002421461;

			internal int _0024index_002421462;

			internal TargetChaseMaker _0024self__002421463;

			public _0024(int index, TargetChaseMaker self_)
			{
				_0024index_002421462 = index;
				_0024self__002421463 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					TargetInfo[] targetInfos = _0024self__002421463.targetInfos;
					targetInfos[RuntimeServices.NormalizeArrayIndex(targetInfos, _0024index_002421462)].maker.SetActive(value: true);
					goto case 2;
				}
				case 2:
				{
					TargetInfo[] targetInfos2 = _0024self__002421463.targetInfos;
					if ((bool)targetInfos2[RuntimeServices.NormalizeArrayIndex(targetInfos2, _0024index_002421462)].target && _0024self__002421463.IsOutScreen(_0024index_002421462))
					{
						if ((bool)Camera.main)
						{
							_0024pos_002421461 = _0024self__002421463.GetScreenPosition(_0024index_002421462);
							Vector3 forward = Camera.main.transform.forward;
							TargetInfo[] targetInfos3 = _0024self__002421463.targetInfos;
							if (!(Vector3.Dot(forward, targetInfos3[RuntimeServices.NormalizeArrayIndex(targetInfos3, _0024index_002421462)].target.position - Camera.main.transform.position) > 0f))
							{
								_0024pos_002421461.x *= -1f;
								_0024pos_002421461.y *= -1f;
							}
							_0024pos_002421461.x = Mathf.Clamp(_0024pos_002421461.x, _0024self__002421463.screen.xMin, _0024self__002421463.screen.xMax);
							_0024pos_002421461.y = Mathf.Clamp(_0024pos_002421461.y, _0024self__002421463.screen.yMin, _0024self__002421463.screen.yMax);
							_0024pos_002421461.z = 100f;
							TargetInfo[] targetInfos4 = _0024self__002421463.targetInfos;
							targetInfos4[RuntimeServices.NormalizeArrayIndex(targetInfos4, _0024index_002421462)].maker.transform.localPosition = _0024pos_002421461;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					TargetInfo[] targetInfos5 = _0024self__002421463.targetInfos;
					targetInfos5[RuntimeServices.NormalizeArrayIndex(targetInfos5, _0024index_002421462)].ai = null;
					TargetInfo[] targetInfos6 = _0024self__002421463.targetInfos;
					targetInfos6[RuntimeServices.NormalizeArrayIndex(targetInfos6, _0024index_002421462)].target = null;
					TargetInfo[] targetInfos7 = _0024self__002421463.targetInfos;
					targetInfos7[RuntimeServices.NormalizeArrayIndex(targetInfos7, _0024index_002421462)].maker.SetActive(value: false);
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024index_002421464;

		internal TargetChaseMaker _0024self__002421465;

		public _0024drawRoutine_002421460(int index, TargetChaseMaker self_)
		{
			_0024index_002421464 = index;
			_0024self__002421465 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024index_002421464, _0024self__002421465);
		}
	}

	public GameObject[] makers;

	private TargetInfo[] targetInfos;

	private Rect screen;

	private PlayerControl plyrCtrl;

	[NonSerialized]
	private static Boo.Lang.List<TargetChaseMaker> _InstanceList = new Boo.Lang.List<TargetChaseMaker>();

	public static TargetChaseMaker Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public void Awake()
	{
		int i = 0;
		GameObject[] array = makers;
		float pixelSizeAdjustment;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].SetActive(value: false);
				}
			}
			targetInfos = new TargetInfo[makers.Length];
			pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(gameObject);
			screen = default(Rect);
			screen.xMin = (float)(-unchecked(Screen.width / 2)) * pixelSizeAdjustment;
			screen.xMax = (float)unchecked(Screen.width / 2) * pixelSizeAdjustment;
			screen.yMin = (float)(-unchecked(Screen.height / 2)) * pixelSizeAdjustment;
		}
		screen.yMax = (float)(Screen.height / 2) * pixelSizeAdjustment;
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void setTarget(AIControl _target)
	{
		IEnumerator<TargetChaseMaker> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetChaseMaker current = enumerator.Current;
				current.__setTarget(_target);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setTarget(AIControl _target)
	{
		if (_target == null)
		{
			return;
		}
		plyrCtrl = PlayerControl.CurrentPlayer;
		if ((bool)plyrCtrl && 0 < plyrCtrl.getPoppetIndex(_target))
		{
			int num = 0;
			int length = makers.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				TargetInfo[] array = targetInfos;
				if (array[RuntimeServices.NormalizeArrayIndex(array, index)].target == _target.transform)
				{
					TargetInfo[] array2 = targetInfos;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index)].ai = null;
					TargetInfo[] array3 = targetInfos;
					array3[RuntimeServices.NormalizeArrayIndex(array3, index)].target = null;
					TargetInfo[] array4 = targetInfos;
					if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, index)].maker)
					{
						TargetInfo[] array5 = targetInfos;
						array5[RuntimeServices.NormalizeArrayIndex(array5, index)].maker.SetActive(value: false);
					}
					TargetInfo[] array6 = targetInfos;
					array6[RuntimeServices.NormalizeArrayIndex(array6, index)].maker = null;
					break;
				}
			}
			return;
		}
		int num2 = 0;
		int length2 = makers.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length2)
		{
			int index2 = num2;
			num2++;
			TargetInfo[] array7 = targetInfos;
			if (array7[RuntimeServices.NormalizeArrayIndex(array7, index2)].target == _target.transform)
			{
				return;
			}
		}
		int num3 = 0;
		int length3 = makers.Length;
		if (length3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < length3)
		{
			int index3 = num3;
			num3++;
			GameObject[] array8 = makers;
			if (!array8[RuntimeServices.NormalizeArrayIndex(array8, index3)].gameObject.activeSelf)
			{
				TargetInfo[] array9 = targetInfos;
				array9[RuntimeServices.NormalizeArrayIndex(array9, index3)].ai = _target;
				TargetInfo[] array10 = targetInfos;
				array10[RuntimeServices.NormalizeArrayIndex(array10, index3)].target = _target.transform;
				TargetInfo[] array11 = targetInfos;
				ref TargetInfo reference = ref array11[RuntimeServices.NormalizeArrayIndex(array11, index3)];
				GameObject[] array12 = makers;
				reference.maker = array12[RuntimeServices.NormalizeArrayIndex(array12, index3)];
				StartCoroutine(drawRoutine(index3));
				break;
			}
		}
	}

	private IEnumerator drawRoutine(int index)
	{
		return new _0024drawRoutine_002421460(index, this).GetEnumerator();
	}

	private bool IsOutScreen(int index)
	{
		return OverScreen(GetScreenPosition(index));
	}

	private Vector3 GetScreenPosition(int index)
	{
		Vector3 result;
		if ((bool)Camera.main)
		{
			TargetInfo[] array = targetInfos;
			Transform selfTransform = array[RuntimeServices.NormalizeArrayIndex(array, index)].maker.transform;
			TargetInfo[] array2 = targetInfos;
			result = ObjUtilModule.GetScreenPostion(selfTransform, array2[RuntimeServices.NormalizeArrayIndex(array2, index)].target.gameObject, Camera.main);
		}
		else
		{
			result = Vector3.zero;
		}
		return result;
	}

	private bool OverScreen(Vector3 pos)
	{
		return pos.x <= screen.xMin || !(screen.xMax > pos.x) || ((pos.y <= screen.yMin || !(screen.yMax > pos.y)) ? true : false);
	}
}
