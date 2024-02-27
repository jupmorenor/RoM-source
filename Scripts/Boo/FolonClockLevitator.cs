using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class FolonClockLevitator : FolonClockSub
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024levi_y_002418290 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024ram_002418291;

			internal double _0024oscill_002418292;

			internal float _0024_002412547_002418293;

			internal Vector3 _0024_002412548_002418294;

			internal Transform _0024root_002418295;

			internal FolonClockLevitator _0024self__002418296;

			public _0024(Transform root, FolonClockLevitator self_)
			{
				_0024root_002418295 = root;
				_0024self__002418296 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024ram_002418291 = 0f;
					goto case 2;
				case 2:
					if (_0024self__002418296.isLevitate && _0024self__002418296._bones != null && !(_0024self__002418296._bones.folon == null))
					{
						_0024oscill_002418292 = (double)_0024self__002418296._bones.cog.localPosition.y - 1.55;
						_0024oscill_002418292 = ((_0024oscill_002418292 <= 0.0) ? 0.0 : _0024oscill_002418292);
						_0024oscill_002418292 += (double)(Mathf.Sin((float)((double)Time.time * 0.01 * (double)_0024self__002418296.ySpeedRate * (double)_0024self__002418296.speedRate)) + 1f) / 2.0 * (double)_0024self__002418296.yRange;
						_0024ram_002418291 = Mathf.PerlinNoise(Time.timeSinceLevelLoad, 0f);
						_0024self__002418296.dst.y = (float)((double)(_0024self__002418296._bones.yang.position.y + _0024ram_002418291 * _0024self__002418296.yNoiseModifierRate) + _0024oscill_002418292);
						float num = (_0024_002412547_002418293 = Mathf.SmoothDamp(_0024root_002418295.position.y, _0024self__002418296.dst.y, ref _0024self__002418296.tmp_velocity.y, _0024self__002418296.ySpeedRate2 / _0024self__002418296.speedRate));
						Vector3 vector = (_0024_002412548_002418294 = _0024root_002418295.position);
						float num2 = (_0024_002412548_002418294.y = _0024_002412547_002418293);
						Vector3 vector3 = (_0024root_002418295.position = _0024_002412548_002418294);
						result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024root_002418297;

		internal FolonClockLevitator _0024self__002418298;

		public _0024levi_y_002418290(Transform root, FolonClockLevitator self_)
		{
			_0024root_002418297 = root;
			_0024self__002418298 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024root_002418297, _0024self__002418298);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024levi_xz_002418299 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024rt_002418300;

			internal double _0024ramx_002418301;

			internal double _0024ramz_002418302;

			internal float _0024_002412549_002418303;

			internal Vector3 _0024_002412550_002418304;

			internal float _0024_002412551_002418305;

			internal Vector3 _0024_002412552_002418306;

			internal Transform _0024root_002418307;

			internal Transform _0024cog_002418308;

			internal FolonClockLevitator _0024self__002418309;

			public _0024(Transform root, Transform cog, FolonClockLevitator self_)
			{
				_0024root_002418307 = root;
				_0024cog_002418308 = cog;
				_0024self__002418309 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002418309.isLevitate && _0024self__002418309._bones != null && !(_0024self__002418309._bones.folon == null))
					{
						_0024self__002418309.headDiffLocalSpace = _0024self__002418309._bones.yang.InverseTransformPoint(_0024self__002418309._bones.head.position);
						if (!(_0024self__002418309.headDiffLocalSpace.z >= _0024self__002418309.headDefaultOffsetZ))
						{
							_0024self__002418309.dst.z = (_0024self__002418309.headDiffLocalSpace.z - _0024self__002418309.headDefaultOffsetZ) * _0024self__002418309.headOffsetRate + _0024cog_002418308.localPosition.z;
						}
						else
						{
							_0024self__002418309.dst.z = _0024cog_002418308.localPosition.z;
						}
						_0024self__002418309.dst.x = _0024cog_002418308.localPosition.x * 2f;
						_0024self__002418309.dst = _0024self__002418309._bones.yang.TransformPoint(_0024self__002418309.dst);
						_0024rt_002418300 = Time.timeSinceLevelLoad;
						_0024ramx_002418301 = (double)Mathf.PerlinNoise(_0024rt_002418300, 0f) * 0.1;
						_0024ramz_002418302 = (double)Mathf.PerlinNoise(0f, _0024rt_002418300) * 0.1;
						_0024self__002418309.dst += new Vector3((float)_0024ramx_002418301, 0f, (float)_0024ramz_002418302);
						float num = (_0024_002412549_002418303 = Mathf.SmoothDamp(_0024root_002418307.position.x, _0024self__002418309.dst.x, ref _0024self__002418309.tmp_velocity.x, 1f / _0024self__002418309.speedRate));
						Vector3 vector = (_0024_002412550_002418304 = _0024root_002418307.position);
						float num2 = (_0024_002412550_002418304.x = _0024_002412549_002418303);
						Vector3 vector3 = (_0024root_002418307.position = _0024_002412550_002418304);
						float num3 = (_0024_002412551_002418305 = Mathf.SmoothDamp(_0024root_002418307.position.z, _0024self__002418309.dst.z, ref _0024self__002418309.tmp_velocity.z, 1f / _0024self__002418309.speedRate));
						Vector3 vector4 = (_0024_002412552_002418306 = _0024root_002418307.position);
						float num4 = (_0024_002412552_002418306.z = _0024_002412551_002418305);
						Vector3 vector6 = (_0024root_002418307.position = _0024_002412552_002418306);
						result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024root_002418310;

		internal Transform _0024cog_002418311;

		internal FolonClockLevitator _0024self__002418312;

		public _0024levi_xz_002418299(Transform root, Transform cog, FolonClockLevitator self_)
		{
			_0024root_002418310 = root;
			_0024cog_002418311 = cog;
			_0024self__002418312 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024root_002418310, _0024cog_002418311, _0024self__002418312);
		}
	}

	public bool isLevitate;

	private float headDefaultOffsetZ;

	public float headOffsetRate;

	public Vector3 headDiffLocalSpace;

	public float ySpeedRate;

	public float ySpeedRate2;

	public float yRange;

	public float yNoiseModifierRate;

	public Vector3 tmp_velocity;

	public Vector3 dst;

	public FolonClockLevitator()
	{
		headDefaultOffsetZ = -0.25f;
		headOffsetRate = 2f;
		ySpeedRate = 0.3f;
		ySpeedRate2 = 0.3f;
		yRange = 0.5f;
		yNoiseModifierRate = 0.125f;
		tmp_velocity = Vector3.zero;
		dst = Vector3.zero;
	}

	public override void StartMove()
	{
		base.StartMove();
		StartLevitate();
	}

	public void StartLevitate()
	{
		isLevitate = true;
		IEnumerator enumerator = levi_xz(_bones.clockRoot, _bones.cog);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		IEnumerator enumerator2 = levi_y(_bones.clockRoot, _bones.cog);
		if (enumerator2 != null)
		{
			StartCoroutine(enumerator2);
		}
	}

	public void StopAll()
	{
		isLevitate = false;
		StopAllCoroutines();
	}

	public IEnumerator levi_y(Transform root, Transform cog)
	{
		return new _0024levi_y_002418290(root, this).GetEnumerator();
	}

	public IEnumerator levi_xz(Transform root, Transform cog)
	{
		return new _0024levi_xz_002418299(root, cog, this).GetEnumerator();
	}

	public void OnDrawGizmos()
	{
	}
}
