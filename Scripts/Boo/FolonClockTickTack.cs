using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class FolonClockTickTack : FolonClockSub
{
	[Serializable]
	internal class _0024rotate_0024locals_002414399
	{
		internal Transform _0024t;

		internal float _0024rate;

		internal float _0024duration;
	}

	[Serializable]
	internal class _0024_tickTack_0024locals_002414400
	{
		internal Transform _0024t;

		internal float _0024deg;
	}

	[Serializable]
	internal class _0024rotate_0024_inner_00244414
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002418342 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal float _0024passed_002418343;

				internal _0024rotate_0024_inner_00244414 _0024self__002418344;

				public _0024(_0024rotate_0024_inner_00244414 self_)
				{
					_0024self__002418344 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024passed_002418343 = 0f;
						goto case 2;
					case 2:
						if (_0024passed_002418343 <= _0024self__002418344._0024_0024locals_002414925._0024duration)
						{
							_0024passed_002418343 += Time.deltaTime;
							_0024self__002418344._0024_0024locals_002414925._0024t.Rotate(new Vector3(0f, 0f, _0024self__002418344._0024_0024locals_002414925._0024rate) * Time.deltaTime * _0024self__002418344._0024this_002414924.speedRate);
							result = (YieldDefault(2) ? 1 : 0);
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

			internal _0024rotate_0024_inner_00244414 _0024self__002418345;

			public _0024Invoke_002418342(_0024rotate_0024_inner_00244414 self_)
			{
				_0024self__002418345 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002418345);
			}
		}

		internal FolonClockTickTack _0024this_002414924;

		internal _0024rotate_0024locals_002414399 _0024_0024locals_002414925;

		public _0024rotate_0024_inner_00244414(FolonClockTickTack _0024this_002414924, _0024rotate_0024locals_002414399 _0024_0024locals_002414925)
		{
			this._0024this_002414924 = _0024this_002414924;
			this._0024_0024locals_002414925 = _0024_0024locals_002414925;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002418342(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024_tickTack_0024_inner_00244415
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002418346 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal float _0024passed_002418347;

				internal float _0024sr_002418348;

				internal _0024_tickTack_0024_inner_00244415 _0024self__002418349;

				public _0024(_0024_tickTack_0024_inner_00244415 self_)
				{
					_0024self__002418349 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024passed_002418347 = 0f;
						_0024sr_002418348 = 1f;
						goto case 2;
					case 2:
						if ((double)_0024passed_002418347 < 0.266666666666)
						{
							_0024sr_002418348 = Time.deltaTime * _0024self__002418349._0024this_002414926.speedRate;
							if (!(0.0 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.03333))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(28.773 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.03333 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.06666))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(63.024 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.06666 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.1))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(70.278 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.1 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.13333))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(36.03 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.13333 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.16666))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(-23.727 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.16666 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.2))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(8.226 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.2 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.23333))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(-2.481 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							else if (!(0.23333 >= (double)_0024passed_002418347) && !((double)_0024passed_002418347 > 0.26666))
							{
								_0024self__002418349._0024_0024locals_002414927._0024t.Rotate(new Vector3(0f, 0f, (float)(-0.123 * (double)_0024self__002418349._0024_0024locals_002414927._0024deg / 6.0 * (double)_0024sr_002418348)));
							}
							_0024passed_002418347 += Time.deltaTime;
							result = (YieldDefault(2) ? 1 : 0);
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

			internal _0024_tickTack_0024_inner_00244415 _0024self__002418350;

			public _0024Invoke_002418346(_0024_tickTack_0024_inner_00244415 self_)
			{
				_0024self__002418350 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002418350);
			}
		}

		internal FolonClockTickTack _0024this_002414926;

		internal _0024_tickTack_0024locals_002414400 _0024_0024locals_002414927;

		public _0024_tickTack_0024_inner_00244415(FolonClockTickTack _0024this_002414926, _0024_tickTack_0024locals_002414400 _0024_0024locals_002414927)
		{
			this._0024this_002414926 = _0024this_002414926;
			this._0024_0024locals_002414927 = _0024_0024locals_002414927;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002418346(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024setHour_002418313 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024c_002418314;

			internal float _0024diff_002418315;

			internal int _0024h_002418316;

			internal FolonClockTickTack _0024self__002418317;

			public _0024(int h, FolonClockTickTack self_)
			{
				_0024h_002418316 = h;
				_0024self__002418317 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024c_002418314 = _0024self__002418317.fcc.getHour();
						_0024h_002418316 = ((_0024h_002418316 >= 12) ? (_0024h_002418316 - 12) : _0024h_002418316);
						_0024diff_002418315 = ((_0024h_002418316 <= _0024c_002418314) ? (_0024h_002418316 - _0024c_002418314 + 12) : (_0024h_002418316 - _0024c_002418314));
						_0024self__002418317.rotate(_0024self__002418317._bones.shortHand, _0024self__002418317.setRate, (float)((double)_0024diff_002418315 / 12.0 * (double)_0024self__002418317.maximumResetDuration));
						_0024self__002418317.startHour();
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal int _0024h_002418318;

		internal FolonClockTickTack _0024self__002418319;

		public _0024setHour_002418313(int h, FolonClockTickTack self_)
		{
			_0024h_002418318 = h;
			_0024self__002418319 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024h_002418318, _0024self__002418319);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024setMinute_002418320 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024c_002418321;

			internal float _0024diff_002418322;

			internal int _0024m_002418323;

			internal FolonClockTickTack _0024self__002418324;

			public _0024(int m, FolonClockTickTack self_)
			{
				_0024m_002418323 = m;
				_0024self__002418324 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024c_002418321 = _0024self__002418324.fcc.getMinute();
					_0024diff_002418322 = checked((_0024m_002418323 <= _0024c_002418321) ? (_0024m_002418323 - _0024c_002418321 + 60) : (_0024m_002418323 - _0024c_002418321));
					_0024self__002418324.rotate(_0024self__002418324._bones.minuteHand, _0024self__002418324.setRate * 2f, (float)((double)_0024diff_002418322 / 60.0 * (double)_0024self__002418324.maximumResetDuration / 2.0));
					_0024self__002418324.startMinute();
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

		internal int _0024m_002418325;

		internal FolonClockTickTack _0024self__002418326;

		public _0024setMinute_002418320(int m, FolonClockTickTack self_)
		{
			_0024m_002418325 = m;
			_0024self__002418326 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024m_002418325, _0024self__002418326);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024rotateDial_002418327 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024ram_002418328;

			internal FolonClockTickTack _0024self__002418329;

			public _0024(FolonClockTickTack self_)
			{
				_0024self__002418329 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024ram_002418328 = (float)UnityEngine.Random.Range(3, 13) * Time.deltaTime * _0024self__002418329.gearRotRate * _0024self__002418329.speedRate;
					_0024self__002418329._bones.dial.Rotate(new Vector3(0f, 0f, _0024self__002418329.dialGearRotRate) * _0024ram_002418328);
					_0024self__002418329._bones.smallGear.Rotate(new Vector3(0f, 0f, _0024self__002418329.smallGearRotRate) * _0024ram_002418328);
					_0024self__002418329._bones.largeGear.Rotate(new Vector3(0f, 0f, _0024self__002418329.largeGearRotRate) * _0024ram_002418328);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FolonClockTickTack _0024self__002418330;

		public _0024rotateDial_002418327(FolonClockTickTack self_)
		{
			_0024self__002418330 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418330);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_tickTack_002418331 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024_inner_002418332;

			internal _0024_tickTack_0024locals_002414400 _0024_0024locals_002418333;

			internal Transform _0024t_002418334;

			internal float _0024deg_002418335;

			internal float _0024delay_002418336;

			internal FolonClockTickTack _0024self__002418337;

			public _0024(Transform t, float deg, float delay, FolonClockTickTack self_)
			{
				_0024t_002418334 = t;
				_0024deg_002418335 = deg;
				_0024delay_002418336 = delay;
				_0024self__002418337 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418333 = new _0024_tickTack_0024locals_002414400();
					_0024_0024locals_002418333._0024t = _0024t_002418334;
					_0024_0024locals_002418333._0024deg = _0024deg_002418335;
					_0024_inner_002418332 = new _0024_tickTack_0024_inner_00244415(_0024self__002418337, _0024_0024locals_002418333).Invoke;
					goto IL_006b;
				case 2:
					_0024self__002418337.StartCoroutine(_0024_inner_002418332());
					goto IL_006b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_006b:
					result = (Yield(2, new WaitForSeconds(_0024delay_002418336 / _0024self__002418337.speedRate)) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024t_002418338;

		internal float _0024deg_002418339;

		internal float _0024delay_002418340;

		internal FolonClockTickTack _0024self__002418341;

		public _0024_tickTack_002418331(Transform t, float deg, float delay, FolonClockTickTack self_)
		{
			_0024t_002418338 = t;
			_0024deg_002418339 = deg;
			_0024delay_002418340 = delay;
			_0024self__002418341 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024t_002418338, _0024deg_002418339, _0024delay_002418340, _0024self__002418341);
		}
	}

	private readonly float dialGearRadius;

	private readonly float smallGearRadius;

	private readonly float largeGearRadius;

	private readonly float dialGearRotRate;

	private readonly float smallGearRotRate;

	private readonly float largeGearRotRate;

	public float gearRotRate;

	private bool isActiveHour;

	private bool isActiveMinute;

	private bool isActiveDialGear;

	private bool isActiveSmallGear;

	private bool isActiveLargeGear;

	private float maximumResetDuration;

	private float setRate;

	public FolonClockTickTack()
	{
		dialGearRadius = 115f;
		smallGearRadius = 23f;
		largeGearRadius = 50f;
		dialGearRotRate = 1f / dialGearRadius * 3f;
		smallGearRotRate = -1f / smallGearRadius * 3f;
		largeGearRotRate = 1f / largeGearRadius * 3f;
		gearRotRate = 100f;
		maximumResetDuration = 12f;
		setRate = 360f / maximumResetDuration;
	}

	public override void StartMove()
	{
		base.StartMove();
		StartTickTack();
	}

	public void StartTickTack()
	{
		startClock();
		startGear();
		setTime(MerlinDateTime.Now.Hour, MerlinDateTime.Now.Minute);
	}

	public void FixedUpdate()
	{
	}

	public void stopAll()
	{
		isActiveDialGear = (isActiveHour = (isActiveLargeGear = (isActiveMinute = (isActiveSmallGear = false))));
		StopAllCoroutines();
	}

	public void setTime(int h, int m)
	{
		stopAll();
		startGear();
		IEnumerator enumerator = setHour(h);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		IEnumerator enumerator2 = setMinute(m);
		if (enumerator2 != null)
		{
			StartCoroutine(enumerator2);
		}
	}

	public IEnumerator setHour(int h)
	{
		return new _0024setHour_002418313(h, this).GetEnumerator();
	}

	public IEnumerator setMinute(int m)
	{
		return new _0024setMinute_002418320(m, this).GetEnumerator();
	}

	public void rotate(Transform t, float rate, float duration)
	{
		_0024rotate_0024locals_002414399 _0024rotate_0024locals_0024 = new _0024rotate_0024locals_002414399();
		_0024rotate_0024locals_0024._0024t = t;
		_0024rotate_0024locals_0024._0024rate = rate;
		_0024rotate_0024locals_0024._0024duration = duration;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024rotate_0024_inner_00244414(this, _0024rotate_0024locals_0024).Invoke;
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	public IEnumerator rotateDial()
	{
		return new _0024rotateDial_002418327(this).GetEnumerator();
	}

	public void startGear()
	{
		if (!isActiveDialGear && !isActiveSmallGear && !isActiveLargeGear)
		{
			StartCoroutine(rotateDial());
			isActiveDialGear = (isActiveSmallGear = (isActiveLargeGear = true));
		}
	}

	public void startClock()
	{
		startHour();
		startMinute();
	}

	public void startMinute()
	{
		if (!isActiveMinute)
		{
			IEnumerator enumerator = _tickTack(_bones.minuteHand, 6f, 5f);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			isActiveMinute = true;
		}
	}

	public void startHour()
	{
		if (!isActiveHour)
		{
			IEnumerator enumerator = _tickTack(_bones.shortHand, 0.05f, 0.15f);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			isActiveHour = true;
		}
	}

	public IEnumerator _tickTack(Transform t, float deg, float delay)
	{
		return new _0024_tickTack_002418331(t, deg, delay, this).GetEnumerator();
	}
}
