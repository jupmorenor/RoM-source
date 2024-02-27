using System;
using System.Collections.Generic;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(UIButtonMessage))]
[RequireComponent(typeof(SortWindowCreator))]
public class SortButton : MonoBehaviour
{
	[Serializable]
	private class WindowSet
	{
		public SortListWindow window;

		public GameObject target;
	}

	public UILabelBase signLabel;

	public UILabelBase label;

	private UIButtonMessage button;

	private SortWindowCreator creator;

	private Boo.Lang.List<WindowSet> windowList;

	private __LotterySequence_startUpdateFunc_0024callable42_002410_31__ checkCloseFunc;

	private GameObject btnBackupTarget;

	private string btnBackupFunctionName;

	private UIButtonMessage.ImmadiateHandler btnBackupImmadiateHandler;

	public __LotterySequence_startUpdateFunc_0024callable42_002410_31__ CheckCloseFunc
	{
		get
		{
			return checkCloseFunc;
		}
		set
		{
			checkCloseFunc = value;
		}
	}

	public void SetCurrentSortName(string key)
	{
		if (!string.IsNullOrEmpty(key))
		{
			UIBasicUtility.SetLabel(label, key, show: true);
			if (4 < key.Length)
			{
				label.transform.localScale = new Vector3(0.8f, 1f, 1f);
			}
			else if (label.transform.localScale != Vector3.one)
			{
				label.transform.localScale = Vector3.one;
			}
		}
	}

	private WindowSet GetWindowSet(GameObject target)
	{
		IEnumerator<WindowSet> enumerator = windowList.GetEnumerator();
		WindowSet windowSet;
		try
		{
			while (enumerator.MoveNext())
			{
				WindowSet current = enumerator.Current;
				if (current == null || !(current.target == target))
				{
					continue;
				}
				windowSet = current;
				goto IL_0055;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_0056;
		IL_0055:
		result = windowSet;
		goto IL_0056;
		IL_0056:
		return (WindowSet)result;
	}

	private WindowSet GetActiveWindowSet()
	{
		IEnumerator<WindowSet> enumerator = windowList.GetEnumerator();
		WindowSet windowSet;
		try
		{
			while (enumerator.MoveNext())
			{
				WindowSet current = enumerator.Current;
				if (current == null || !current.target.activeInHierarchy)
				{
					continue;
				}
				windowSet = current;
				goto IL_0054;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_0055;
		IL_0054:
		result = windowSet;
		goto IL_0055;
		IL_0055:
		return (WindowSet)result;
	}

	public void Awake()
	{
		UIBasicUtility.SetLabel(signLabel, MTexts.Get("sort_button_sign").msg, show: true);
		button = GetComponent<UIButtonMessage>();
		button.target = gameObject;
		button.mode = UIButtonMessage.SendMode.Normal;
		button.functionName = "PushShowWindow";
		creator = GetComponent<SortWindowCreator>();
	}

	public void Initialize(Transform parent, GameObject target, string[] sortNames)
	{
		if (windowList == null)
		{
			windowList = new Boo.Lang.List<WindowSet>();
		}
		if (sortNames != null && 0 < sortNames.Length && GetWindowSet(target) == null)
		{
			SortListWindow sortListWindow = creator.Create(parent, target, sortNames);
			UIAutoTweenerStandAloneEx.Hide(sortListWindow.gameObject);
			WindowSet windowSet = new WindowSet();
			windowSet.window = sortListWindow;
			windowSet.target = target;
			windowList.Add(windowSet);
		}
		btnBackupTarget = null;
		btnBackupFunctionName = string.Empty;
	}

	public void Update()
	{
		if ((bool)btnBackupTarget && checkCloseFunc != null && checkCloseFunc())
		{
			WindowSet activeWindowSet = GetActiveWindowSet();
			HideWindow(activeWindowSet.target);
		}
	}

	public void ShowWindow(GameObject target)
	{
		SetWindowState(target, show: true);
	}

	public void HideWindow(GameObject target)
	{
		SetWindowState(target, show: false);
	}

	private void SetWindowState(GameObject target, bool show)
	{
		WindowSet windowSet = GetWindowSet(target);
		if (windowSet == null)
		{
			return;
		}
		SortListWindow window = windowSet.window;
		if ((bool)window)
		{
			if (show)
			{
				BackupButtonBackHUD();
				UIAutoTweenerStandAloneEx.In(window.gameObject);
				window.SelectButton(label.text);
			}
			else
			{
				RestoreButtonBackHUD();
				UIAutoTweenerStandAloneEx.Out(window.gameObject);
			}
		}
	}

	private void BackupButtonBackHUD()
	{
		UIButtonMessage uIButtonMessage = ButtonBackHUD.GetButton();
		if ((bool)uIButtonMessage)
		{
			btnBackupTarget = uIButtonMessage.target;
			btnBackupFunctionName = uIButtonMessage.functionName;
			btnBackupImmadiateHandler = uIButtonMessage.immadiateHandler;
			uIButtonMessage.target = gameObject;
			uIButtonMessage.functionName = "PushHideWindow";
			uIButtonMessage.immadiateHandler = null;
		}
	}

	private void RestoreButtonBackHUD()
	{
		if (!(btnBackupTarget == null) && !string.IsNullOrEmpty(btnBackupFunctionName))
		{
			UIButtonMessage uIButtonMessage = ButtonBackHUD.GetButton();
			if ((bool)uIButtonMessage)
			{
				uIButtonMessage.target = btnBackupTarget;
				uIButtonMessage.functionName = btnBackupFunctionName;
				uIButtonMessage.immadiateHandler = btnBackupImmadiateHandler;
			}
			btnBackupTarget = null;
			btnBackupFunctionName = string.Empty;
			object obj = null;
		}
	}

	public void PushShowWindow()
	{
		WindowSet activeWindowSet = GetActiveWindowSet();
		ShowWindow(activeWindowSet.target);
	}

	public void PushHideWindow()
	{
		WindowSet activeWindowSet = GetActiveWindowSet();
		HideWindow(activeWindowSet.target);
	}
}
