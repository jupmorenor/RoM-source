using System;
using UnityEngine;

public abstract class IPPickerBase : MonoBehaviour
{
	public delegate void PickerValueUpdatedHandler();

	public bool initInAwake = true;

	public Vector3 widgetOffsetInPicker;

	public UIWidget.Pivot widgetsPivot = UIWidget.Pivot.Center;

	public Color widgetsColor = Color.white;

	public PickerValueUpdatedHandler onPickerValueUpdated;

	public IPCycler cycler;

	[SerializeField]
	protected int _nbOfWidgets;

	protected int _nbOfVirtualElements;

	protected int _selectedIndex;

	public bool IsCyclerMoving => cycler.IsMoving;

	protected virtual void Awake()
	{
		if (Application.isPlaying && initInAwake)
		{
			Setup();
		}
	}

	private void OnDestroy()
	{
		if (Application.isPlaying)
		{
			IPCycler iPCycler = cycler;
			iPCycler.onCyclerIndexChange = (IPCycler.CyclerIndexChangeHandler)Delegate.Remove(iPCycler.onCyclerIndexChange, new IPCycler.CyclerIndexChangeHandler(CyclerIndexChange));
		}
	}

	public void Setup()
	{
		cycler.Init();
		IPCycler iPCycler = cycler;
		iPCycler.onCyclerIndexChange = (IPCycler.CyclerIndexChangeHandler)Delegate.Combine(iPCycler.onCyclerIndexChange, new IPCycler.CyclerIndexChangeHandler(CyclerIndexChange));
		Init();
	}

	protected virtual void Init()
	{
		UpdateVirtualElementsCount();
		_selectedIndex = GetInitIndex();
		UpdateCurrentValue();
	}

	protected void ResetPickerAtIndex(int index)
	{
		_selectedIndex = index;
		UpdateCurrentValue();
		cycler.ResetCycler();
		ResetWidgetsContent();
	}

	public void ResetPicker()
	{
		ResetPickerAtIndex(_selectedIndex);
	}

	private void CyclerIndexChange(bool increment, int widgetIndex)
	{
		if (increment)
		{
			_selectedIndex = (_selectedIndex + 1) % _nbOfVirtualElements;
		}
		else
		{
			_selectedIndex--;
			if (_selectedIndex < 0)
			{
				_selectedIndex += _nbOfVirtualElements;
			}
		}
		CycleWidgets(increment, widgetIndex);
		UpdateCurrentValue();
		if (onPickerValueUpdated != null)
		{
			onPickerValueUpdated();
		}
	}

	private void CycleWidgets(bool indexIncremented, int widgetIndex)
	{
		int num;
		if (indexIncremented)
		{
			num = (_selectedIndex + _nbOfWidgets / 2) % _nbOfVirtualElements;
		}
		else
		{
			num = (_selectedIndex - _nbOfWidgets / 2) % _nbOfVirtualElements;
			if (num < 0)
			{
				num += _nbOfVirtualElements;
			}
		}
		UpdateWidget(widgetIndex, num);
	}

	public abstract UIWidget GetCenterWidget();

	protected abstract void InitWidgets();

	protected abstract void UpdateVirtualElementsCount();

	protected abstract void MakeWidgetComponents();

	protected abstract int GetInitIndex();

	protected abstract void UpdateCurrentValue();

	protected abstract void UpdateWidget(int widgetIndex, int newContentIndex);

	protected void RebuildWidgets()
	{
		if (cycler == null)
		{
			cycler = GetComponentInChildren(typeof(IPCycler)) as IPCycler;
		}
		MakeWidgetComponents();
		ResetWidgets();
	}

	public void ResetWidgets()
	{
		UpdateVirtualElementsCount();
		_selectedIndex = GetInitIndex();
		InitWidgets();
		ResetWidgetsContent();
	}

	protected void ResetWidgetsContent()
	{
		int num = _selectedIndex - _nbOfWidgets / 2;
		if (num < 0)
		{
			num += _nbOfVirtualElements;
		}
		if (num < 0)
		{
			num = 0;
		}
		for (int i = 0; i < _nbOfWidgets; i++)
		{
			UpdateWidget(i, num);
			num = (num + 1) % _nbOfVirtualElements;
		}
	}
}
