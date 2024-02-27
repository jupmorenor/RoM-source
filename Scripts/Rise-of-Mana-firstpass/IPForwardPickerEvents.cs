using System;
using UnityEngine;

public class IPForwardPickerEvents : MonoBehaviour
{
	[Serializable]
	public class GameObjectAndMessage
	{
		public GameObject gameObject;

		public string message;

		public bool notifyInStart;
	}

	public IPPickerBase observedPicker;

	public bool notifyOnSelectionChange;

	public GameObjectAndMessage onSelectionChangeNotification;

	public bool notifyOnSelectionStarted;

	public GameObjectAndMessage onStartedNotification;

	public bool notifyOnCenterOnChildStarted;

	public GameObjectAndMessage onCenterOnChildNotification;

	public bool notifyOnPickerStopped;

	public GameObjectAndMessage onStoppedNotification;

	private IPCycler _cycler;

	private void Start()
	{
		if (observedPicker == null)
		{
			observedPicker = base.gameObject.GetComponent(typeof(IPPickerBase)) as IPPickerBase;
		}
		if (observedPicker == null)
		{
			Debug.LogError("Needs an IPPicker!");
			return;
		}
		_cycler = observedPicker.cycler;
		SetDelegates();
		if (notifyOnSelectionChange && onSelectionChangeNotification.notifyInStart)
		{
			Notify(onSelectionChangeNotification);
		}
		if (notifyOnSelectionStarted && onStartedNotification.notifyInStart)
		{
			Notify(onStartedNotification);
		}
		if (notifyOnCenterOnChildStarted && onCenterOnChildNotification.notifyInStart)
		{
			Notify(onCenterOnChildNotification);
		}
		if (notifyOnPickerStopped && onStoppedNotification.notifyInStart)
		{
			Notify(onStoppedNotification);
		}
	}

	private void SetDelegates()
	{
		if (notifyOnSelectionChange)
		{
			IPPickerBase iPPickerBase = observedPicker;
			iPPickerBase.onPickerValueUpdated = (IPPickerBase.PickerValueUpdatedHandler)Delegate.Combine(iPPickerBase.onPickerValueUpdated, new IPPickerBase.PickerValueUpdatedHandler(OnPickerSelectionChange));
		}
		if (notifyOnSelectionStarted)
		{
			IPCycler cycler = _cycler;
			cycler.onCyclerSelectionStarted = (IPCycler.SelectionStartedHandler)Delegate.Combine(cycler.onCyclerSelectionStarted, new IPCycler.SelectionStartedHandler(OnCyclerSelectionStarted));
		}
		if (notifyOnCenterOnChildStarted)
		{
			IPCycler cycler2 = _cycler;
			cycler2.onCenterOnChildStarted = (IPCycler.CenterOnChildStartedHandler)Delegate.Combine(cycler2.onCenterOnChildStarted, new IPCycler.CenterOnChildStartedHandler(OnCenterOnChildStarted));
		}
		if (notifyOnPickerStopped)
		{
			IPCycler cycler3 = _cycler;
			cycler3.onCyclerStopped = (IPCycler.CyclerStoppedHandler)Delegate.Combine(cycler3.onCyclerStopped, new IPCycler.CyclerStoppedHandler(OnCyclerStopped));
		}
	}

	private void OnEnable()
	{
		if (_cycler != null)
		{
			SetDelegates();
		}
	}

	private void OnDisable()
	{
		if (notifyOnSelectionChange)
		{
			IPPickerBase iPPickerBase = observedPicker;
			iPPickerBase.onPickerValueUpdated = (IPPickerBase.PickerValueUpdatedHandler)Delegate.Remove(iPPickerBase.onPickerValueUpdated, new IPPickerBase.PickerValueUpdatedHandler(OnPickerSelectionChange));
		}
		if (notifyOnSelectionStarted)
		{
			IPCycler cycler = _cycler;
			cycler.onCyclerSelectionStarted = (IPCycler.SelectionStartedHandler)Delegate.Remove(cycler.onCyclerSelectionStarted, new IPCycler.SelectionStartedHandler(OnCyclerSelectionStarted));
		}
		if (notifyOnCenterOnChildStarted)
		{
			IPCycler cycler2 = _cycler;
			cycler2.onCenterOnChildStarted = (IPCycler.CenterOnChildStartedHandler)Delegate.Remove(cycler2.onCenterOnChildStarted, new IPCycler.CenterOnChildStartedHandler(OnCenterOnChildStarted));
		}
		if (notifyOnPickerStopped)
		{
			IPCycler cycler3 = _cycler;
			cycler3.onCyclerStopped = (IPCycler.CyclerStoppedHandler)Delegate.Remove(cycler3.onCyclerStopped, new IPCycler.CyclerStoppedHandler(OnCyclerStopped));
		}
	}

	private void OnCyclerSelectionStarted()
	{
		Notify(onStartedNotification);
	}

	private void OnCenterOnChildStarted()
	{
		Notify(onCenterOnChildNotification);
	}

	private void OnCyclerStopped()
	{
		Notify(onStoppedNotification);
	}

	private void OnPickerSelectionChange()
	{
		Notify(onSelectionChangeNotification);
	}

	private void Notify(GameObjectAndMessage goAndMessage)
	{
		if (goAndMessage.gameObject != null)
		{
			goAndMessage.gameObject.SendMessage(goAndMessage.message);
		}
	}
}
