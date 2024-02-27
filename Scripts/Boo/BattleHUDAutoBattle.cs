using System;
using System.Runtime.CompilerServices;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class BattleHUDAutoBattle : MonoBehaviour
{
	[NonSerialized]
	private static BattleHUDAutoBattle _Instance;

	public GameObject onButton;

	public GameObject offButton;

	private bool lastNeedButtons;

	private __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024event_0024handlers;

	private bool udNeedButtons
	{
		get
		{
			UserConfigData config = UserData.Current.Config;
			return config.ShowAutoBattleButton;
		}
		set
		{
			UserConfigData config = UserData.Current.Config;
			config.ShowAutoBattleButton = value;
		}
	}

	private bool udAutoBattleButtonOn
	{
		get
		{
			UserConfigData config = UserData.Current.Config;
			return config.AutoBattleButtonOn;
		}
		set
		{
			UserConfigData config = UserData.Current.Config;
			config.AutoBattleButtonOn = value;
		}
	}

	private bool udIsAutoBattleEnabled
	{
		get
		{
			UserConfigData config = UserData.Current.Config;
			return config.IsAutoBattleEnabled;
		}
	}

	private event __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ handlers
	{
		add
		{
			_0024event_0024handlers = (__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__)Delegate.Combine(_0024event_0024handlers, value);
		}
		remove
		{
			_0024event_0024handlers = (__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__)Delegate.Remove(_0024event_0024handlers, value);
		}
	}

	[SpecialName]
	private void raise_handlers(bool arg0)
	{
		_0024event_0024handlers?.Invoke(arg0);
	}

	public static void AddHandler(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ c)
	{
		if (_Instance != null && c != null)
		{
			_Instance.handlers += c;
		}
	}

	public static void RemoveHandler(__LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ c)
	{
		if (_Instance != null && c != null)
		{
			_Instance.handlers -= c;
		}
	}

	public static void DeactivateGameObject()
	{
		if (_Instance != null)
		{
			_Instance.gameObject.SetActive(value: false);
		}
	}

	public void OnEnable()
	{
		if (_Instance != null)
		{
		}
		_Instance = this;
	}

	public void OnDisable()
	{
		if (!(_Instance != this))
		{
			_Instance = null;
		}
	}

	public void Start()
	{
		refresh();
	}

	public void Update()
	{
		if (lastNeedButtons != udNeedButtons)
		{
			refresh();
			invokeHandlers();
		}
	}

	public void pushAutoBattleButton()
	{
		udAutoBattleButtonOn = !udAutoBattleButtonOn;
		refresh();
		invokeHandlers();
	}

	private void invokeHandlers()
	{
		raise_handlers(udIsAutoBattleEnabled);
	}

	private void refresh()
	{
		if (udNeedButtons)
		{
			showButton(udAutoBattleButtonOn);
		}
		else
		{
			disableAll();
		}
		lastNeedButtons = udNeedButtons;
	}

	private void showButton(bool b)
	{
		Activate(onButton, b);
		Activate(offButton, !b);
	}

	private void disableAll()
	{
		Activate(onButton, b: false);
		Activate(offButton, b: false);
	}

	public static void Activate(bool b)
	{
		if (!(_Instance == null))
		{
			Activate(_Instance.gameObject, b);
		}
	}

	private static void Activate(GameObject go, bool b)
	{
		if (go != null)
		{
			go.SetActive(b);
		}
	}
}
