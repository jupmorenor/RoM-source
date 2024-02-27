using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Ef_SpAtk_Ply_FireBall : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002415368 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024tm_002415369;

			internal Ef_SpAtk_Ply_FireBall _0024self__002415370;

			public _0024(Ef_SpAtk_Ply_FireBall self_)
			{
				_0024self__002415370 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__002415370.player != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024tm_002415369 = 0.3f;
					goto case 3;
				case 3:
					if (_0024tm_002415369 >= 0f)
					{
						_0024self__002415370.moveTargetTo(new Vector3(0f, 5f, 0f) + _0024self__002415370.player.MYPOS);
						_0024tm_002415369 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					_0024self__002415370.moveTargetTo(_0024self__002415370.targetPosition());
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Ef_SpAtk_Ply_FireBall _0024self__002415371;

		public _0024main_002415368(Ef_SpAtk_Ply_FireBall self_)
		{
			_0024self__002415371 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415371);
		}
	}

	private PlayerControl player;

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void emitEffectMessage(MerlinActionControl emitter)
	{
		player = emitter as PlayerControl;
	}

	private IEnumerator main()
	{
		return new _0024main_002415368(this).GetEnumerator();
	}

	private Vector3 targetPosition()
	{
		Vector3 result;
		if (player == null)
		{
			result = new Vector3(0f, 1f, 0f) + transform.position;
		}
		else
		{
			GameObject gameObject = player.TargetChar;
			if (gameObject == null)
			{
				gameObject = player.searchTargetEnemy();
			}
			result = ((!(gameObject != null)) ? (new Vector3(0f, 5f, 0f) + player.MYPOS) : (gameObject.transform.position + new Vector3(0f, 1f, 0f)));
		}
		return result;
	}

	private void moveTargetTo(Vector3 tpos)
	{
		Quaternion rotation = transform.rotation;
		Quaternion to = Quaternion.LookRotation(tpos - transform.position);
		transform.rotation = Quaternion.Slerp(rotation, to, 0.1f);
		float num = 13f;
		Vector3 forward = transform.forward;
		transform.position += forward * num * Time.deltaTime;
	}
}
