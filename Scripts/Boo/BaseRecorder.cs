using System;
using UnityEngine;

[Serializable]
public class BaseRecorder : MonoBehaviour
{
	[Serializable]
	public enum RecorderMode
	{
		Stop,
		Play,
		Record
	}

	[NonSerialized]
	protected static RecorderMode _recorderMode = RecorderMode.Stop;

	[NonSerialized]
	protected static bool _hasRecord;

	public RecorderMode recorderMode => _recorderMode;

	public bool isRecord => _recorderMode == RecorderMode.Record;

	public bool isPlay => _recorderMode == RecorderMode.Play;

	public bool isStop => _recorderMode == RecorderMode.Stop;

	public bool hasRecord => _hasRecord;

	protected void _setRecorderMode(RecorderMode aMode)
	{
		_recorderMode = aMode;
	}

	public virtual void startRecording()
	{
	}

	public virtual void stopRecording()
	{
	}

	public virtual void showView()
	{
	}

	public virtual void showWatchView()
	{
	}
}
