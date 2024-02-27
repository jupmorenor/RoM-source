using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class UITweenController : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		Wait,
		In,
		Out
	}

	[Serializable]
	internal class _0024Play_0024locals_002414492
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024finished;
	}

	[Serializable]
	internal class _0024Play_0024closure_00245017
	{
		internal _0024Play_0024locals_002414492 _0024_0024locals_002415079;

		internal UITweenController _0024this_002415080;

		public _0024Play_0024closure_00245017(_0024Play_0024locals_002414492 _0024_0024locals_002415079, UITweenController _0024this_002415080)
		{
			this._0024_0024locals_002415079 = _0024_0024locals_002415079;
			this._0024this_002415080 = _0024this_002415080;
		}

		public void Invoke()
		{
			_0024this_002415080.tween.onFinished = null;
			_0024this_002415080.start_time = 0f;
			if (_0024this_002415080.last_mode == Mode.In)
			{
				_0024this_002415080.start_time = Time.realtimeSinceStartup;
			}
			_0024_0024locals_002415079._0024finished();
		}
	}

	public bool onDebugMsg;

	public UITweener tween;

	private Mode mode;

	private Mode last_mode;

	private float start_time;

	public UITweenSync sync;

	public void OnEnable()
	{
		if ((bool)sync)
		{
			Sync(sync);
		}
	}

	public void Start()
	{
		mode = Mode.In;
	}

	public void LateUpdate()
	{
		Run();
	}

	public virtual void Play(bool forward, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ finished)
	{
		_0024Play_0024locals_002414492 _0024Play_0024locals_0024 = new _0024Play_0024locals_002414492();
		_0024Play_0024locals_0024._0024finished = finished;
		tween.Play(forward);
		tween.Reset();
		last_mode = mode;
		tween.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(new _0024Play_0024closure_00245017(_0024Play_0024locals_0024, this).Invoke);
	}

	public void Run()
	{
		if (mode == Mode.Wait)
		{
			if (Time.realtimeSinceStartup >= start_time + 1.5f)
			{
				mode = Mode.In;
				if (last_mode == Mode.In)
				{
					mode = Mode.Out;
				}
			}
		}
		else if (mode != last_mode)
		{
			Play(mode == Mode.In, delegate
			{
				mode = Mode.Wait;
			});
		}
	}

	public void SetSync(UITweenSync tb)
	{
		sync = tb;
		tween.style = tb.tween.style;
		tween.method = tb.tween.method;
	}

	public void Sync(UITweenController tb)
	{
		mode = tb.mode;
		start_time = tb.start_time;
		tween.Sync(tb.tween);
	}

	private void ShowLog(string msg)
	{
		if (!onDebugMsg)
		{
		}
	}

	internal void _0024Run_0024closure_00245018()
	{
		mode = Mode.Wait;
	}
}
