using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class NageTest : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024nageRoutine_002419768 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241857_002419769;

			internal float _0024_0024wait_sec_0024temp_00241858_002419770;

			internal float _0024_0024wait_sec_0024temp_00241859_002419771;

			internal int _0024_002412579_002419772;

			internal Vector3 _0024_002412580_002419773;

			internal double _0024_002412581_002419774;

			internal Vector3 _0024_002412582_002419775;

			internal double _0024_002412583_002419776;

			internal Vector3 _0024_002412584_002419777;

			internal float _0024_002412585_002419778;

			internal Vector3 _0024_002412586_002419779;

			internal float _0024_002412587_002419780;

			internal Vector3 _0024_002412588_002419781;

			internal float _0024_002412589_002419782;

			internal Vector3 _0024_002412590_002419783;

			internal NageTest _0024self__002419784;

			public _0024(NageTest self_)
			{
				_0024self__002419784 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_sec_0024temp_00241857_002419769 = 1.1f;
					goto case 2;
				case 2:
				{
					if (_0024_0024wait_sec_0024temp_00241857_002419769 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241857_002419769 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002419784.yarare.transform.parent = _0024self__002419784.nageBone.transform;
					int num = (_0024_002412579_002419772 = 150);
					Vector3 vector = (_0024_002412580_002419773 = _0024self__002419784.yarare.transform.localEulerAngles);
					float num2 = (_0024_002412580_002419773.x = _0024_002412579_002419772);
					Vector3 vector3 = (_0024self__002419784.yarare.transform.localEulerAngles = _0024_002412580_002419773);
					double num3 = (_0024_002412581_002419774 = -0.9295582);
					Vector3 vector4 = (_0024_002412582_002419775 = _0024self__002419784.yarare.transform.localPosition);
					float num4 = (_0024_002412582_002419775.x = (float)_0024_002412581_002419774);
					Vector3 vector6 = (_0024self__002419784.yarare.transform.localPosition = _0024_002412582_002419775);
					double num5 = (_0024_002412583_002419776 = 0.1563765);
					Vector3 vector7 = (_0024_002412584_002419777 = _0024self__002419784.yarare.transform.localPosition);
					float num6 = (_0024_002412584_002419777.y = (float)_0024_002412583_002419776);
					Vector3 vector9 = (_0024self__002419784.yarare.transform.localPosition = _0024_002412584_002419777);
					_0024_0024wait_sec_0024temp_00241858_002419770 = 0.9f;
					goto case 3;
				}
				case 3:
					if (_0024_0024wait_sec_0024temp_00241858_002419770 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241858_002419770 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002419784.yarare.transform.parent = null;
					goto case 4;
				case 4:
				{
					if (_0024self__002419784.yarare.transform.position.y > 0f)
					{
						float num7 = (_0024_002412585_002419778 = _0024self__002419784.yarare.transform.position.y - 15f * Time.deltaTime);
						Vector3 vector10 = (_0024_002412586_002419779 = _0024self__002419784.yarare.transform.position);
						float num8 = (_0024_002412586_002419779.y = _0024_002412585_002419778);
						Vector3 vector12 = (_0024self__002419784.yarare.transform.position = _0024_002412586_002419779);
						float num9 = (_0024_002412587_002419780 = _0024self__002419784.yarare.transform.position.x + 15f * Time.deltaTime);
						Vector3 vector13 = (_0024_002412588_002419781 = _0024self__002419784.yarare.transform.position);
						float num10 = (_0024_002412588_002419781.x = _0024_002412587_002419780);
						Vector3 vector15 = (_0024self__002419784.yarare.transform.position = _0024_002412588_002419781);
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					iTween.ShakePosition(Camera.main.gameObject, new Vector3(0f, 0.5f, 0f), 0.2f);
					float num11 = (_0024_002412589_002419782 = 0f);
					Vector3 vector16 = (_0024_002412590_002419783 = _0024self__002419784.yarare.transform.position);
					float num12 = (_0024_002412590_002419783.y = _0024_002412589_002419782);
					Vector3 vector18 = (_0024self__002419784.yarare.transform.position = _0024_002412590_002419783);
					_0024self__002419784.yarare.transform.rotation = _0024self__002419784.yarareInitRot;
					_0024self__002419784.yarare.animation.Play("c0000_bt_1hs_down");
					_0024_0024wait_sec_0024temp_00241859_002419771 = 1.5f;
					goto case 5;
				}
				case 5:
					if (_0024_0024wait_sec_0024temp_00241859_002419771 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241859_002419771 -= Time.deltaTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002419784.nage.transform.position = _0024self__002419784.nageInitPos;
					_0024self__002419784.nage.transform.rotation = _0024self__002419784.nageInitRot;
					_0024self__002419784.yarare.transform.position = _0024self__002419784.yarareInitPos;
					_0024self__002419784.yarare.transform.rotation = _0024self__002419784.yarareInitRot;
					_0024self__002419784.nage.animation.Play("e0004_bt_atk4");
					_0024self__002419784.yarare.animation.Play("c0000_bt_1hs_idle");
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal NageTest _0024self__002419785;

		public _0024nageRoutine_002419768(NageTest self_)
		{
			_0024self__002419785 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419785);
		}
	}

	public GameObject nage;

	public GameObject yarare;

	public GameObject nageBone;

	private Vector3 nageInitPos;

	private Quaternion nageInitRot;

	private Vector3 yarareInitPos;

	private Quaternion yarareInitRot;

	public void Start()
	{
		StartCoroutine(nageRoutine());
		nageInitPos = nage.transform.position;
		nageInitRot = nage.transform.rotation;
		yarareInitPos = yarare.transform.position;
		yarareInitRot = yarare.transform.rotation;
	}

	public IEnumerator nageRoutine()
	{
		return new _0024nageRoutine_002419768(this).GetEnumerator();
	}
}
