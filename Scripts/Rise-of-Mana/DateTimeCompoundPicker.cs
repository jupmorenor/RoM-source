using System;
using System.Collections;
using UnityEngine;

public class DateTimeCompoundPicker : MonoBehaviour
{
	public IPDatePicker datePicker;

	public IPNumberPicker hourPicker;

	public IPNumberPicker minutesPicker;

	public bool initAtNow;

	public IPDatePicker.Date initDate;

	public int initHour;

	public int initMinute;

	private bool _isInitialized;

	public bool IsMoving => datePicker.IsCyclerMoving || hourPicker.IsCyclerMoving || minutesPicker.IsCyclerMoving;

	private void Awake()
	{
		if (datePicker.initInAwake || hourPicker.initInAwake || minutesPicker.initInAwake)
		{
			Debug.LogError("All three pickers of DateTimeCompoundPicker should have initInAwake set to false");
		}
		if (initAtNow)
		{
			DateTime now = DateTime.Now;
			initDate = new IPDatePicker.Date(now.Day, now.Month, now.Year);
			initHour = now.Hour;
			initMinute = now.Minute;
		}
		datePicker.initDate = initDate;
	}

	private void Start()
	{
		datePicker.Setup();
		hourPicker.Setup();
		hourPicker.ResetPickerAtValue(initHour);
		minutesPicker.Setup();
		minutesPicker.ResetPickerAtValue(initMinute);
		_isInitialized = true;
	}

	public DateTime GetSelectedDateTime(out bool isStillMoving)
	{
		isStillMoving = IsMoving;
		return datePicker.CurrentDate.AddMinutes(minutesPicker.CurrentValue + hourPicker.CurrentValue * 60);
	}

	public void SetSelectedDateTime(DateTime dateTime)
	{
		if (datePicker.TryResetPickerAtDateTime(dateTime))
		{
			hourPicker.ResetPickerAtValue(dateTime.Hour);
			minutesPicker.ResetPickerAtValue(dateTime.Minute);
		}
		else
		{
			Debug.LogError("date is out of picker range");
		}
	}

	private IEnumerator SetNewLanguage(string language)
	{
		if (!_isInitialized)
		{
			yield return null;
		}
		datePicker.SetNewLanguage(language);
	}
}
