using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BasicCamera : MonoBehaviour
{
	[Serializable]
	public enum FocusMode
	{
		player,
		point,
		none
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_setLookAt_002416867 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal GameObject _0024g_002416868;

			internal IEnumerator _0024_0024sco_0024temp_00241255_002416869;

			internal Vector3 _0024pos_002416870;

			internal float _0024speed_002416871;

			internal BasicCamera _0024self__002416872;

			public _0024(Vector3 pos, float speed, BasicCamera self_)
			{
				_0024pos_002416870 = pos;
				_0024speed_002416871 = speed;
				_0024self__002416872 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416872.isPositioning)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024g_002416868 = new GameObject(new StringBuilder().Append(_0024self__002416872.gameObject.name).Append("_dummy_lookat").ToString());
					_0024g_002416868.transform.position = _0024pos_002416870;
					_0024self__002416872.isPositioning = true;
					_0024_0024sco_0024temp_00241255_002416869 = _0024self__002416872._interpolate(_0024g_002416868.transform, _0024speed_002416871);
					if (_0024_0024sco_0024temp_00241255_002416869 != null)
					{
						result = (Yield(3, _0024self__002416872.StartCoroutine(_0024_0024sco_0024temp_00241255_002416869)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					result = (Yield(4, new WaitForFixedUpdate()) ? 1 : 0);
					break;
				case 4:
				case 5:
					if (_0024self__002416872.isInterpolating)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002416872.currentFocusMode = FocusMode.none;
					_0024self__002416872.target = null;
					UnityEngine.Object.Destroy(_0024g_002416868);
					_0024self__002416872.isPositioning = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024pos_002416873;

		internal float _0024speed_002416874;

		internal BasicCamera _0024self__002416875;

		public _0024_setLookAt_002416867(Vector3 pos, float speed, BasicCamera self_)
		{
			_0024pos_002416873 = pos;
			_0024speed_002416874 = speed;
			_0024self__002416875 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024pos_002416873, _0024speed_002416874, _0024self__002416875);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_setTarget_002416876 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241257_002416877;

			internal Transform _0024t_002416878;

			internal float _0024speed_002416879;

			internal BasicCamera _0024self__002416880;

			public _0024(Transform t, float speed, BasicCamera self_)
			{
				_0024t_002416878 = t;
				_0024speed_002416879 = speed;
				_0024self__002416880 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002416880.isPositioning = true;
					_0024_0024sco_0024temp_00241257_002416877 = _0024self__002416880._interpolate(_0024t_002416878, _0024speed_002416879);
					if (_0024_0024sco_0024temp_00241257_002416877 != null)
					{
						result = (Yield(2, _0024self__002416880.StartCoroutine(_0024_0024sco_0024temp_00241257_002416877)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					result = (Yield(3, new WaitForFixedUpdate()) ? 1 : 0);
					break;
				case 3:
				case 4:
					if (_0024self__002416880.isInterpolating)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002416880.isPositioning = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024t_002416881;

		internal float _0024speed_002416882;

		internal BasicCamera _0024self__002416883;

		public _0024_setTarget_002416876(Transform t, float speed, BasicCamera self_)
		{
			_0024t_002416881 = t;
			_0024speed_002416882 = speed;
			_0024self__002416883 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024t_002416881, _0024speed_002416882, _0024self__002416883);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_interpolate_002416884 : GenericGenerator<YieldInstruction>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
		{
			internal bool _0024isTargetMoving_002416885;

			internal Vector3 _0024prevTargetPos_002416886;

			internal float _0024duration_002416887;

			internal float _0024s_002416888;

			internal IEnumerator _0024_0024sco_0024temp_00241258_002416889;

			internal IEnumerator _0024_0024sco_0024temp_00241259_002416890;

			internal Transform _0024t_002416891;

			internal float _0024speed_002416892;

			internal BasicCamera _0024self__002416893;

			public _0024(Transform t, float speed, BasicCamera self_)
			{
				_0024t_002416891 = t;
				_0024speed_002416892 = speed;
				_0024self__002416893 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002416893.isInterpolating = true;
					_0024isTargetMoving_002416885 = false;
					_0024prevTargetPos_002416886 = _0024t_002416891.position;
					_0024duration_002416887 = 0f;
					_0024self__002416893.setMode(_0024t_002416891);
					_0024s_002416888 = _0024self__002416893._applyDistanceModToSmoothTime((_0024self__002416893.targetPosition - _0024self__002416893.target.position).magnitude, _0024speed_002416892);
					goto case 4;
				case 4:
					if (_0024self__002416893.target != null && _0024self__002416893.isMainCamera)
					{
						if (_0024isTargetMoving_002416885)
						{
							_0024self__002416893.targetPosition = Vector3.SmoothDamp(_0024self__002416893.targetPosition, _0024self__002416893.target.position, ref _0024self__002416893.tmp_velocity, _0024s_002416888 / 10f);
						}
						else
						{
							_0024self__002416893.targetPosition = Vector3.SmoothDamp(_0024self__002416893.targetPosition, _0024self__002416893.target.position, ref _0024self__002416893.tmp_velocity, _0024s_002416888);
						}
						if (_0024duration_002416887 <= _0024speed_002416892 * 3f && _0024self__002416893.isPositioning)
						{
							if (_0024isTargetMoving_002416885)
							{
								if ((_0024self__002416893.targetPosition - _0024self__002416893.target.position).magnitude >= _0024self__002416893.movingTolerance)
								{
									goto IL_0263;
								}
								_0024_0024sco_0024temp_00241258_002416889 = _0024self__002416893.shiftEnd(_0024s_002416888);
								if (_0024_0024sco_0024temp_00241258_002416889 != null)
								{
									result = (Yield(2, _0024self__002416893.StartCoroutine(_0024_0024sco_0024temp_00241258_002416889)) ? 1 : 0);
									break;
								}
							}
							else
							{
								if ((_0024self__002416893.targetPosition - _0024self__002416893.target.position).magnitude >= _0024self__002416893.tolerance)
								{
									goto IL_0263;
								}
								_0024_0024sco_0024temp_00241259_002416890 = _0024self__002416893.shiftEnd(_0024s_002416888);
								if (_0024_0024sco_0024temp_00241259_002416890 != null)
								{
									result = (Yield(3, _0024self__002416893.StartCoroutine(_0024_0024sco_0024temp_00241259_002416890)) ? 1 : 0);
									break;
								}
							}
							goto case 1;
						}
					}
					_0024self__002416893.isInterpolating = false;
					YieldDefault(1);
					goto case 1;
				case 1:
				case 2:
				case 3:
					{
						result = 0;
						break;
					}
					IL_0263:
					_0024isTargetMoving_002416885 = _0024prevTargetPos_002416886 != _0024self__002416893.target.position;
					_0024prevTargetPos_002416886 = _0024self__002416893.target.position;
					_0024duration_002416887 += Time.deltaTime;
					result = (Yield(4, new WaitForFixedUpdate()) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024t_002416894;

		internal float _0024speed_002416895;

		internal BasicCamera _0024self__002416896;

		public _0024_interpolate_002416884(Transform t, float speed, BasicCamera self_)
		{
			_0024t_002416894 = t;
			_0024speed_002416895 = speed;
			_0024self__002416896 = self_;
		}

		public override IEnumerator<YieldInstruction> GetEnumerator()
		{
			return new _0024(_0024t_002416894, _0024speed_002416895, _0024self__002416896);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024shiftEnd_002416897 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024s_002416898;

			internal IEnumerator _0024_0024sco_0024temp_00241260_002416899;

			internal BasicCamera _0024self__002416900;

			public _0024(BasicCamera self_)
			{
				_0024self__002416900 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__002416900.target != null))
					{
						throw new AssertionFailedException("target != null");
					}
					_0024s_002416898 = _0024self__002416900._applyDistanceModToSmoothTime((_0024self__002416900.targetPosition - _0024self__002416900.target.position).magnitude, _0024self__002416900.smoothTime);
					_0024_0024sco_0024temp_00241260_002416899 = _0024self__002416900.shiftEnd(_0024s_002416898);
					if (_0024_0024sco_0024temp_00241260_002416899 != null)
					{
						result = (Yield(2, _0024self__002416900.StartCoroutine(_0024_0024sco_0024temp_00241260_002416899)) ? 1 : 0);
						break;
					}
					goto case 2;
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

		internal BasicCamera _0024self__002416901;

		public _0024shiftEnd_002416897(BasicCamera self_)
		{
			_0024self__002416901 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416901);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024shiftEnd_002416902 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal double _0024duration_002416903;

			internal float _0024s_002416904;

			internal BasicCamera _0024self__002416905;

			public _0024(float s, BasicCamera self_)
			{
				_0024s_002416904 = s;
				_0024self__002416905 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024self__002416905.target != null))
					{
						throw new AssertionFailedException("target != null");
					}
					_0024duration_002416903 = 0.0;
					goto case 2;
				case 2:
					if (!(_0024duration_002416903 >= (double)_0024self__002416905.shiftTime) && _0024self__002416905.target != null && _0024self__002416905.isMainCamera)
					{
						_0024s_002416904 = _0024self__002416905._applyDistanceModToSmoothTime((_0024self__002416905.targetPosition - _0024self__002416905.target.position).magnitude, _0024self__002416905.smoothTime);
						_0024self__002416905.ns = Mathf.Lerp(_0024s_002416904, _0024self__002416905.smoothTime, (float)(_0024duration_002416903 / (double)_0024self__002416905.shiftTime));
						_0024self__002416905.targetPosition = Vector3.SmoothDamp(_0024self__002416905.targetPosition, _0024self__002416905.target.position, ref _0024self__002416905.tmp_velocity, _0024self__002416905.ns);
						_0024duration_002416903 += Time.deltaTime;
						if (_0024self__002416905.isPositioning)
						{
							result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
							break;
						}
					}
					_0024self__002416905.isPositioning = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024s_002416906;

		internal BasicCamera _0024self__002416907;

		public _0024shiftEnd_002416902(float s, BasicCamera self_)
		{
			_0024s_002416906 = s;
			_0024self__002416907 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024s_002416906, _0024self__002416907);
		}
	}

	public Transform target;

	public float distance;

	public float height;

	public float heightSmoothLag;

	public float distanceSmoothLag;

	public Vector3 centerOffset;

	public Vector3 targetPosition;

	public bool autoPlayerTarget;

	public Vector3 tmp_velocity;

	private float ns;

	public FocusMode currentFocusMode;

	public bool isPositioning;

	private bool isInterpolating;

	public float smoothTime;

	public float _movingTolerance;

	public float tolerance;

	public float shiftTime;

	public float speedRate;

	[NonSerialized]
	public const float SHIFT_TIMEOUT_RATE = 2.5f;

	private Vector3 prevPosition;

	public Vector3 diff;

	public float movingTolerance
	{
		get
		{
			float result;
			if (!target)
			{
				result = _movingTolerance;
			}
			else
			{
				PlayerControl componentInChildren = target.GetComponentInChildren<PlayerControl>();
				result = ((!componentInChildren) ? _movingTolerance : ((float)((double)componentInChildren.CurrentMoveSpeed / 6.0)));
			}
			return result;
		}
		set
		{
			_movingTolerance = value;
		}
	}

	public static int HiddenLayer => LayerMask.NameToLayer("Hidden");

	protected bool isMainCamera => gameObject == Camera.main.gameObject;

	public BasicCamera()
	{
		distance = 7f;
		height = 3f;
		heightSmoothLag = 0.3f;
		distanceSmoothLag = 0.3f;
		centerOffset = Vector3.zero;
		targetPosition = Vector3.zero;
		autoPlayerTarget = true;
		tmp_velocity = Vector3.zero;
		currentFocusMode = FocusMode.player;
		smoothTime = 0.125f;
		_movingTolerance = 1.25f;
		tolerance = 0.05f;
		shiftTime = 0.66f;
		speedRate = 1.3f;
		prevPosition = Vector3.zero;
		diff = Vector3.zero;
	}

	public void Awake()
	{
		EnableHiddenLayer();
	}

	public static void EnableHiddenLayer()
	{
		Camera[] allCameras = Camera.allCameras;
		int hiddenLayer = HiddenLayer;
		int i = 0;
		Camera[] array = allCameras;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].cullingMask = array[i].cullingMask & ~(1 << hiddenLayer);
		}
	}

	public virtual void FixedUpdate()
	{
		diff = targetPosition - prevPosition;
		prevPosition = targetPosition;
		if (isPositioning)
		{
			return;
		}
		float num = default(float);
		if (currentFocusMode == FocusMode.none)
		{
			return;
		}
		if (currentFocusMode == FocusMode.point)
		{
			num = _applyDistanceModToSmoothTime((targetPosition - target.position).magnitude, smoothTime);
			if ((bool)target)
			{
				targetPosition = Vector3.SmoothDamp(targetPosition, target.position, ref tmp_velocity, num);
			}
		}
		else if (currentFocusMode == FocusMode.player && PlayerControl.CurrentPlayer != null)
		{
			target = PlayerControl.CurrentPlayer.transform;
			num = _applyDistanceModToSmoothTime((targetPosition - target.position).magnitude, smoothTime);
			targetPosition = Vector3.SmoothDamp(targetPosition, target.position, ref tmp_velocity, num);
		}
	}

	public void setLookAt(Vector3 pos)
	{
		IEnumerator enumerator = _setLookAt(pos, smoothTime);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void setLookAt(Transform point)
	{
		target = transform;
		currentFocusMode = FocusMode.point;
	}

	public void setLookAt(Vector3 pos, float speed)
	{
		IEnumerator enumerator = _setLookAt(pos, speed);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void setTarget(Transform t)
	{
		IEnumerator enumerator = _setTarget(t);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void setTarget(Transform t, float speed)
	{
		IEnumerator enumerator = _setTarget(t, speed);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void Stop()
	{
		isPositioning = false;
		currentFocusMode = FocusMode.none;
	}

	public void setLookAtWithoutInterpol()
	{
		setLookAtWithoutInterpol(targetPosition);
	}

	public void setLookAtWithoutInterpol(Vector3 pos)
	{
		targetPosition = pos;
		target = null;
		currentFocusMode = FocusMode.none;
		isPositioning = false;
	}

	public void setBasicCameraModeNone()
	{
		currentFocusMode = FocusMode.none;
	}

	private IEnumerator _setLookAt(Vector3 pos, float speed)
	{
		return new _0024_setLookAt_002416867(pos, speed, this).GetEnumerator();
	}

	private IEnumerator _setTarget(Transform t)
	{
		IEnumerator enumerator = _setTarget(t, smoothTime);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	private IEnumerator _setTarget(Transform t, float speed)
	{
		return new _0024_setTarget_002416876(t, speed, this).GetEnumerator();
	}

	private IEnumerator _interpolate(Transform t, float speed)
	{
		return new _0024_interpolate_002416884(t, speed, this).GetEnumerator();
	}

	private IEnumerator shiftEnd()
	{
		return new _0024shiftEnd_002416897(this).GetEnumerator();
	}

	private IEnumerator shiftEnd(float s)
	{
		return new _0024shiftEnd_002416902(s, this).GetEnumerator();
	}

	private float _applyDistanceModToSmoothTime(float dist, float t)
	{
		return ((double)(dist / t) <= 330.0) ? (t / speedRate) : 0f;
	}

	public void ForceResetCameraMode()
	{
		isPositioning = false;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if ((bool)currentPlayer)
		{
			currentFocusMode = FocusMode.player;
			target = currentPlayer.transform;
		}
		else
		{
			currentFocusMode = FocusMode.none;
		}
	}

	public float GetTimeOut(float d)
	{
		return d * 2.5f;
	}

	private void setMode(Transform t)
	{
		target = t;
		PlayerControl componentInChildren = t.GetComponentInChildren<PlayerControl>();
		if ((bool)componentInChildren)
		{
			currentFocusMode = FocusMode.player;
		}
		else
		{
			currentFocusMode = FocusMode.point;
		}
	}

	public void OnDrawGizmos()
	{
	}
}
