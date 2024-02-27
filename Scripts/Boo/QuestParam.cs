using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class QuestParam : MonoBehaviour
{
	private int _killEnemyNum;

	public HUDNum treasureNumUI;

	public HUDNumMoney moneyNumUI;

	public SQEX_SoundPlayerData.SE getCoin_4SQEX_SE;

	private SQEX_SoundPlayer sndmgr;

	[NonSerialized]
	private static Boo.Lang.List<QuestParam> _InstanceList = new Boo.Lang.List<QuestParam>();

	public int __getTreasureNum
	{
		get
		{
			return (treasureNumUI != null) ? treasureNumUI.Num : 0;
		}
		set
		{
			if (treasureNumUI != null)
			{
				treasureNumUI.Num = value;
			}
		}
	}

	public int __getMoney
	{
		get
		{
			return (moneyNumUI != null && moneyNumUI.gameObject.activeSelf) ? moneyNumUI.Num : 0;
		}
		set
		{
			if (moneyNumUI != null && moneyNumUI.gameObject.activeSelf)
			{
				moneyNumUI.Num = value;
			}
		}
	}

	public static QuestParam Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public static int getTreasureNum
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__getTreasureNum;
		}
		set
		{
			IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					QuestParam current = enumerator.Current;
					current.__getTreasureNum = value;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public static int getMoney
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__getMoney;
		}
		set
		{
			IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					QuestParam current = enumerator.Current;
					current.__getMoney = value;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public static int killEnemyNum
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__killEnemyNum;
		}
		set
		{
			IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					QuestParam current = enumerator.Current;
					current.__killEnemyNum = value;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public int __killEnemyNum
	{
		get
		{
			return _killEnemyNum;
		}
		set
		{
			_killEnemyNum = value;
		}
	}

	public QuestParam()
	{
		getCoin_4SQEX_SE = SQEX_SoundPlayerData.SE.coin_get;
	}

	public void Start()
	{
		sndmgr = SQEX_SoundPlayer.Instance;
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void Show()
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__Show();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Show()
	{
		if (treasureNumUI != null)
		{
			treasureNumUI.gameObject.SetActive(value: true);
		}
		if (moneyNumUI != null)
		{
			moneyNumUI.gameObject.SetActive(value: true);
		}
		if (treasureNumUI != null)
		{
			treasureNumUI.show();
		}
		if (moneyNumUI != null)
		{
			moneyNumUI.show();
		}
	}

	public static void Hide()
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__Hide();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Hide()
	{
		if (treasureNumUI != null)
		{
			treasureNumUI.hide();
		}
		if (moneyNumUI != null)
		{
			moneyNumUI.hide();
		}
	}

	public static void ClearNum()
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__ClearNum();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ClearNum()
	{
		getTreasureNum = 0;
		getMoney = 0;
	}

	public static void EarnTreasure()
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__EarnTreasure();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EarnTreasure()
	{
		checked
		{
			getTreasureNum++;
		}
	}

	public static void EarnMoney(int _money)
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__EarnMoney(_money);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EarnMoney(int _money)
	{
		checked
		{
			getMoney += _money;
			if (!sndmgr)
			{
				sndmgr = SQEX_SoundPlayer.Instance;
			}
		}
		if ((bool)sndmgr)
		{
			sndmgr.PlaySe((int)getCoin_4SQEX_SE, 0, gameObject.GetInstanceID());
		}
	}

	public static void SetEarnedTreasureNum(int n)
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__SetEarnedTreasureNum(n);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetEarnedTreasureNum(int n)
	{
		getTreasureNum = n;
	}

	public static void SetEarnedCoinNum(int n)
	{
		IEnumerator<QuestParam> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestParam current = enumerator.Current;
				current.__SetEarnedCoinNum(n);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetEarnedCoinNum(int n)
	{
		getMoney = n;
	}
}
