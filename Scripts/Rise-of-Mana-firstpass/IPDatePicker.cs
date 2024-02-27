using System;
using UnityEngine;

[ExecuteInEditMode]
public class IPDatePicker : IPPickerLabelBase
{
	[Serializable]
	public class Date
	{
		public int day;

		public int month;

		public int year;

		public Date(int iday, int imonth, int iyear)
		{
			day = iday;
			month = imonth;
			year = iyear;
		}

		public DateTime GetDateTime()
		{
			return new DateTime(year, month, day);
		}
	}

	public DateTimeLocalization.Language language = DateTimeLocalization.Language.English;

	public Date pickerMinDate = new Date(1, 1, 1900);

	public Date pickerMaxDate = new Date(31, 12, 2199);

	public Date initDate;

	public string dateFormat = "ddd d MMM yyyy";

	private DateTime _minDate;

	public DateTime CurrentDate { get; private set; }

	public bool TryResetPickerAtDate(Date date)
	{
		if (!TryResetPickerAtDateTime(date.GetDateTime()))
		{
			return false;
		}
		return true;
	}

	public bool TryResetPickerAtDateTime(DateTime dateTime)
	{
		int indexForDateTime = GetIndexForDateTime(dateTime);
		if (indexForDateTime < 0 || indexForDateTime >= _nbOfVirtualElements)
		{
			return false;
		}
		ResetPickerAtIndex(indexForDateTime);
		return true;
	}

	public void SetNewLanguage(DateTimeLocalization.Language newLanguage)
	{
		if (DateTimeLocalization.SetLanguage(newLanguage))
		{
			language = newLanguage;
			ResetPickerAtIndex(_selectedIndex);
		}
	}

	public void SetNewLanguage(string languageString)
	{
		if (DateTimeLocalization.TrySetLanguage(languageString))
		{
			ResetPickerAtIndex(_selectedIndex);
		}
		language = DateTimeLocalization.CurrentLanguage;
	}

	protected override void Init()
	{
		UpdateVirtualElementsCount();
		_selectedIndex = GetInitIndex();
		SetNewLanguage(language);
	}

	protected override int GetInitIndex()
	{
		if (initDate.day == 0 || initDate.month == 0 || initDate.year == 0)
		{
			CurrentDate = DateTime.Now;
		}
		else
		{
			CurrentDate = initDate.GetDateTime();
		}
		return GetIndexForDateTime(CurrentDate);
	}

	protected override void UpdateCurrentValue()
	{
		CurrentDate = GetDateTimeForIndex(_selectedIndex);
	}

	protected override void UpdateWidget(int widgetIndex, int contentIndex)
	{
		uiLabels[widgetIndex].text = GetDateTimeForIndex(contentIndex).Date.ToString(dateFormat, DateTimeLocalization.Culture);
	}

	protected override void UpdateVirtualElementsCount()
	{
		_minDate = pickerMinDate.GetDateTime();
		_nbOfVirtualElements = pickerMaxDate.GetDateTime().Subtract(_minDate).Days;
	}

	private DateTime GetDateTimeForIndex(int index)
	{
		return _minDate.AddDays(index);
	}

	private int GetIndexForDateTime(DateTime dateTime)
	{
		return dateTime.Subtract(_minDate).Days;
	}
}
