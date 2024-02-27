using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BlurManager : MonoBehaviour
{
	[Serializable]
	public enum POWER
	{
		LV0,
		LV1,
		Max
	}

	[Serializable]
	public class BlurParam
	{
		public float time;

		public float blurAmount;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartBlur_002418142 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024lv_002418143;

			internal BlurManager _0024self__002418144;

			public _0024(int lv, BlurManager self_)
			{
				_0024lv_002418143 = lv;
				_0024self__002418144 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					MotionBlur motionBlur = _0024self__002418144.motionBlur;
					BlurParam[] blurParam = _0024self__002418144.blurParam;
					motionBlur.blurAmount = blurParam[RuntimeServices.NormalizeArrayIndex(blurParam, _0024lv_002418143)].blurAmount;
					BlurParam[] blurParam2 = _0024self__002418144.blurParam;
					result = (Yield(2, new WaitForSeconds(blurParam2[RuntimeServices.NormalizeArrayIndex(blurParam2, _0024lv_002418143)].time)) ? 1 : 0);
					break;
				}
				case 2:
					_0024self__002418144.motionBlur.blurAmount = 0f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024lv_002418145;

		internal BlurManager _0024self__002418146;

		public _0024StartBlur_002418142(int lv, BlurManager self_)
		{
			_0024lv_002418145 = lv;
			_0024self__002418146 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024lv_002418145, _0024self__002418146);
		}
	}

	private MotionBlur motionBlur;

	public BlurParam[] blurParam;

	public BlurManager()
	{
		blurParam = new BlurParam[2];
	}

	public void Start()
	{
		motionBlur = GetComponent<MotionBlur>();
		if (motionBlur == null)
		{
			Debug.LogError("motionBlur not found");
		}
		motionBlur.blurAmount = 0f;
		blurParam[0].time = 0.3f;
		blurParam[0].blurAmount = 0.6f;
		blurParam[1].time = 0.6f;
		blurParam[1].blurAmount = 0.8f;
	}

	public void SetBlur(int lv)
	{
		if (lv >= 0 && 2 > lv)
		{
			StopCoroutine("StartBlur");
			StartCoroutine(StartBlur(lv));
		}
	}

	private IEnumerator StartBlur(int lv)
	{
		return new _0024StartBlur_002418142(lv, this).GetEnumerator();
	}
}
