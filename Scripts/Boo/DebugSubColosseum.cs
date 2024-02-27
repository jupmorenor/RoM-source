using System;
using System.Text;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubColosseum : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024OnGUI_0024locals_002414274
	{
		internal int _0024skill1;

		internal int _0024skill2;
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243682
	{
		internal int _0024_00246776_002414595;

		internal RespColosseumEvent[] _0024_00246777_002414596;

		public _0024OnGUI_0024closure_00243682(int _0024_00246776_002414595, RespColosseumEvent[] _0024_00246777_002414596)
		{
			this._0024_00246776_002414595 = _0024_00246776_002414595;
			this._0024_00246777_002414596 = _0024_00246777_002414596;
		}

		public void Invoke()
		{
			bool isCostLimit = GUILayout.Toggle(_0024_00246777_002414596[_0024_00246776_002414595].IsCostLimit, "IsCostLimit");
			_0024_00246777_002414596[_0024_00246776_002414595].IsCostLimit = isCostLimit;
			RuntimeDebugModeGuiMixin.label("CostLimit");
			int result = _0024_00246777_002414596[_0024_00246776_002414595].CostLimit;
			if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
			{
				_0024_00246777_002414596[_0024_00246776_002414595].CostLimit = result;
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243683
	{
		internal int _0024_00246776_002414597;

		internal RespColosseumEvent[] _0024_00246777_002414598;

		public _0024OnGUI_0024closure_00243683(int _0024_00246776_002414597, RespColosseumEvent[] _0024_00246777_002414598)
		{
			this._0024_00246776_002414597 = _0024_00246776_002414597;
			this._0024_00246777_002414598 = _0024_00246777_002414598;
		}

		public void Invoke()
		{
			bool isElementLimit = GUILayout.Toggle(_0024_00246777_002414598[_0024_00246776_002414597].IsElementLimit, "IsElementLimit");
			_0024_00246777_002414598[_0024_00246776_002414597].IsElementLimit = isElementLimit;
			RuntimeDebugModeGuiMixin.label("ElementLimit");
			int result = _0024_00246777_002414598[_0024_00246776_002414597].ElementLimit;
			if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
			{
				_0024_00246777_002414598[_0024_00246776_002414597].ElementLimit = result;
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243684
	{
		internal int _0024_00246776_002414599;

		internal RespColosseumEvent[] _0024_00246777_002414600;

		public _0024OnGUI_0024closure_00243684(int _0024_00246776_002414599, RespColosseumEvent[] _0024_00246777_002414600)
		{
			this._0024_00246776_002414599 = _0024_00246776_002414599;
			this._0024_00246777_002414600 = _0024_00246777_002414600;
		}

		public void Invoke()
		{
			bool isStyleLimit = GUILayout.Toggle(_0024_00246777_002414600[_0024_00246776_002414599].IsStyleLimit, "IsStyleLimit");
			_0024_00246777_002414600[_0024_00246776_002414599].IsStyleLimit = isStyleLimit;
			RuntimeDebugModeGuiMixin.label("StyleLimit");
			int result = _0024_00246777_002414600[_0024_00246776_002414599].StyleLimit;
			if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
			{
				_0024_00246777_002414600[_0024_00246776_002414599].StyleLimit = result;
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243685
	{
		internal int _0024_00246776_002414601;

		internal RespColosseumEvent[] _0024_00246777_002414602;

		public _0024OnGUI_0024closure_00243685(int _0024_00246776_002414601, RespColosseumEvent[] _0024_00246777_002414602)
		{
			this._0024_00246776_002414601 = _0024_00246776_002414601;
			this._0024_00246777_002414602 = _0024_00246777_002414602;
		}

		public void Invoke()
		{
			bool isMinRarityLimit = GUILayout.Toggle(_0024_00246777_002414602[_0024_00246776_002414601].IsMinRarityLimit, "IsMinRarityLimit");
			_0024_00246777_002414602[_0024_00246776_002414601].IsMinRarityLimit = isMinRarityLimit;
			RuntimeDebugModeGuiMixin.label("MinRarityLimit");
			int result = _0024_00246777_002414602[_0024_00246776_002414601].MinRarityLimit;
			if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
			{
				_0024_00246777_002414602[_0024_00246776_002414601].MinRarityLimit = result;
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243686
	{
		internal int _0024_00246776_002414603;

		internal RespColosseumEvent[] _0024_00246777_002414604;

		public _0024OnGUI_0024closure_00243686(int _0024_00246776_002414603, RespColosseumEvent[] _0024_00246777_002414604)
		{
			this._0024_00246776_002414603 = _0024_00246776_002414603;
			this._0024_00246777_002414604 = _0024_00246777_002414604;
		}

		public void Invoke()
		{
			bool isMaxRarityLimit = GUILayout.Toggle(_0024_00246777_002414604[_0024_00246776_002414603].IsMaxRarityLimit, "IsMaxRarityLimit");
			_0024_00246777_002414604[_0024_00246776_002414603].IsMaxRarityLimit = isMaxRarityLimit;
			RuntimeDebugModeGuiMixin.label("MaxRarityLimit");
			int result = _0024_00246777_002414604[_0024_00246776_002414603].MaxRarityLimit;
			if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
			{
				_0024_00246777_002414604[_0024_00246776_002414603].MaxRarityLimit = result;
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243687
	{
		internal int _0024_00246776_002414605;

		internal RespColosseumEvent[] _0024_00246777_002414606;

		public _0024OnGUI_0024closure_00243687(int _0024_00246776_002414605, RespColosseumEvent[] _0024_00246777_002414606)
		{
			this._0024_00246776_002414605 = _0024_00246776_002414605;
			this._0024_00246777_002414606 = _0024_00246777_002414606;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label("colEv.BannerHtml");
			string text = string.Empty;
			if (null != _0024_00246777_002414606[_0024_00246776_002414605].BannerHtml)
			{
				text = _0024_00246777_002414606[_0024_00246776_002414605].BannerHtml;
			}
			text = GUILayout.TextField(text);
			_0024_00246777_002414606[_0024_00246776_002414605].BannerHtml = text;
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243688
	{
		internal int _0024_00246776_002414607;

		internal RespColosseumEvent[] _0024_00246777_002414608;

		public _0024OnGUI_0024closure_00243688(int _0024_00246776_002414607, RespColosseumEvent[] _0024_00246777_002414608)
		{
			this._0024_00246776_002414607 = _0024_00246776_002414607;
			this._0024_00246777_002414608 = _0024_00246777_002414608;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label("NoFrCompeOpponentListCount");
			MColosseumEvents mColosseumEvents = MColosseumEvents.Get(_0024_00246777_002414608[_0024_00246776_002414607].Id);
			if (mColosseumEvents != null)
			{
				int result = mColosseumEvents.NoFrCompeOpponentListCount;
				if (int.TryParse(GUILayout.TextField(result.ToString()), out result))
				{
					mColosseumEvents.setField("NoFrCompeOpponentListCount", result);
				}
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243689
	{
		internal _0024OnGUI_0024locals_002414274 _0024_0024locals_002414609;

		public _0024OnGUI_0024closure_00243689(_0024OnGUI_0024locals_002414274 _0024_0024locals_002414609)
		{
			this._0024_0024locals_002414609 = _0024_0024locals_002414609;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label("Daily Skill");
			int[] dailyPassiveSkills = UserData.Current.userColosseumEvent.DailyPassiveSkills;
			if (dailyPassiveSkills != null)
			{
				if (dailyPassiveSkills.Length >= 1)
				{
					_0024_0024locals_002414609._0024skill1 = dailyPassiveSkills[0];
				}
				if (dailyPassiveSkills.Length >= 2)
				{
					_0024_0024locals_002414609._0024skill2 = dailyPassiveSkills[1];
				}
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243690
	{
		internal _0024OnGUI_0024locals_002414274 _0024_0024locals_002414610;

		public _0024OnGUI_0024closure_00243690(_0024OnGUI_0024locals_002414274 _0024_0024locals_002414610)
		{
			this._0024_0024locals_002414610 = _0024_0024locals_002414610;
		}

		public void Invoke()
		{
			int.TryParse(GUILayout.TextField(_0024_0024locals_002414610._0024skill1.ToString()), out _0024_0024locals_002414610._0024skill1);
			MCoverSkills mCoverSkills = MCoverSkills.Get(_0024_0024locals_002414610._0024skill1);
			string value = "none";
			if (mCoverSkills != null)
			{
				value = mCoverSkills.Name.msg;
			}
			RuntimeDebugModeGuiMixin.label(new StringBuilder("skill1:").Append(value).ToString());
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243691
	{
		internal _0024OnGUI_0024locals_002414274 _0024_0024locals_002414611;

		public _0024OnGUI_0024closure_00243691(_0024OnGUI_0024locals_002414274 _0024_0024locals_002414611)
		{
			this._0024_0024locals_002414611 = _0024_0024locals_002414611;
		}

		public void Invoke()
		{
			int.TryParse(GUILayout.TextField(_0024_0024locals_002414611._0024skill2.ToString()), out _0024_0024locals_002414611._0024skill2);
			MCoverSkills mCoverSkills = MCoverSkills.Get(_0024_0024locals_002414611._0024skill2);
			string value = "none";
			if (mCoverSkills != null)
			{
				value = mCoverSkills.Name.msg;
			}
			RuntimeDebugModeGuiMixin.label(new StringBuilder("skill1:").Append(value).ToString());
		}
	}

	protected int select;

	public override void OnGUI()
	{
		_0024OnGUI_0024locals_002414274 _0024OnGUI_0024locals_0024 = new _0024OnGUI_0024locals_002414274();
		int num = 250;
		RuntimeDebugModeGuiMixin.label("Colosseum Events");
		int i = 0;
		RespColosseumEvent[] colosseumEvent = UserData.Current.userColosseumEvent.ColosseumEvent;
		for (int length = colosseumEvent.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.label("#########################################");
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Id = ").Append((object)colosseumEvent[i].Id).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Name = ").Append(colosseumEvent[i].Name).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("BeginDate = ").Append(colosseumEvent[i].BeginDate).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("EndDate = ").Append(colosseumEvent[i].EndDate).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("BpCost = ").Append((object)colosseumEvent[i].BpCost).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("IsFriendCompetition = ").Append(colosseumEvent[i].IsFriendCompetition).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("MItemGroupId = ").Append((object)colosseumEvent[i].MItemGroupId).ToString());
			RuntimeDebugModeGuiMixin.label(new StringBuilder("IsRankingEvent = ").Append(colosseumEvent[i].IsRankingEvent).ToString());
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243682(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243683(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243684(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243685(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243686(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243687(i, colosseumEvent).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243688(i, colosseumEvent).Invoke));
		}
		RuntimeDebugModeGuiMixin.label("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
		_0024OnGUI_0024locals_0024._0024skill1 = 0;
		_0024OnGUI_0024locals_0024._0024skill2 = 0;
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243689(_0024OnGUI_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243690(_0024OnGUI_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243691(_0024OnGUI_0024locals_0024).Invoke));
		UserData.Current.userColosseumEvent.setDailyPassiveSkills(new int[2] { _0024OnGUI_0024locals_0024._0024skill1, _0024OnGUI_0024locals_0024._0024skill2 });
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
		GUI.Label(new Rect(100f, 100f, 400f, 20f), "HELLO DebugSubSample");
	}

	public override void Init()
	{
	}

	public override void Exit()
	{
	}
}
