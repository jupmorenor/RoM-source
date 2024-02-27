using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class HUDNumMoney : HUDNum
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024drawRoutine_002421349 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024delta_002421350;

			internal float _0024_0024wait_sec_0024temp_00242517_002421351;

			internal float _0024_002412673_002421352;

			internal Vector3 _0024_002412674_002421353;

			internal HUDNumMoney _0024self__002421354;

			public _0024(HUDNumMoney self_)
			{
				_0024self__002421354 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002421354.tweenGetMoney)
					{
						_0024self__002421354.tweenGetMoney.enabled = true;
						_0024self__002421354.tweenGetMoney.style = UITweener.Style.PingPong;
					}
					_0024delta_002421350 = checked(_0024self__002421354.number - _0024self__002421354.drawNumber) / 30;
					if (_0024delta_002421350 < 1)
					{
						_0024delta_002421350 = 1;
					}
					goto IL_0119;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242517_002421351 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242517_002421351 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0119;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0119:
					if (checked(_0024self__002421354.drawNumber + _0024delta_002421350) < _0024self__002421354.number)
					{
						_0024self__002421354.drawNumber = checked(_0024self__002421354.drawNumber + _0024delta_002421350);
						if (_0024self__002421354.label != null)
						{
							_0024self__002421354.label.text = _0024self__002421354.drawNumber.ToString();
						}
						_0024_0024wait_sec_0024temp_00242517_002421351 = 0.1f;
						goto case 2;
					}
					if ((bool)_0024self__002421354.tweenGetMoney)
					{
						_0024self__002421354.tweenGetMoney.style = UITweener.Style.Once;
						_0024self__002421354.tweenGetMoney.enabled = false;
					}
					if ((bool)_0024self__002421354.label)
					{
						if (_0024self__002421354.label != null)
						{
							_0024self__002421354.label.text = _0024self__002421354.number.ToString();
						}
						float num = (_0024_002412673_002421352 = _0024self__002421354.initPosY);
						Vector3 vector = (_0024_002412674_002421353 = _0024self__002421354.label.transform.localPosition);
						float num2 = (_0024_002412674_002421353.y = _0024_002412673_002421352);
						Vector3 vector3 = (_0024self__002421354.label.transform.localPosition = _0024_002412674_002421353);
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal HUDNumMoney _0024self__002421355;

		public _0024drawRoutine_002421349(HUDNumMoney self_)
		{
			_0024self__002421355 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421355);
		}
	}

	public TweenPosition tweenGetMoney;

	private int drawNumber;

	private float initPosY;

	public override int Num
	{
		get
		{
			return number;
		}
		set
		{
			if (number != value)
			{
				number = value;
				StartCoroutine(drawRoutine());
			}
		}
	}

	public HUDNumMoney()
	{
		initPosY = -30f;
	}

	public void Start()
	{
		if ((bool)label)
		{
			initPosY = label.transform.localPosition.y;
		}
	}

	private IEnumerator drawRoutine()
	{
		return new _0024drawRoutine_002421349(this).GetEnumerator();
	}
}
