using System;
using System.Collections;
using Boo.Lang.Runtime;

[Serializable]
public class UserConfigData
{
	[Serializable]
	public enum DeckTypes
	{
		None,
		Atk,
		Hp,
		Custom,
		Max
	}

	public float DefaultBGMVolume;

	public float DefaultSEVolume;

	public bool DefaultRealShadow;

	public bool DefaultLightOn;

	public float BGMVolume;

	public float SEVolume;

	public bool RealShadow;

	public bool LightOn;

	public DeckTypes[] DeckType;

	public int SortType;

	public bool DefaultAutoCombinationOn;

	public bool DefaultVirtualPadImageOn;

	public bool DefaultShowAutoBattleButton;

	public bool DefaultAutoBattleButtonOn;

	public bool DefaultSetShowAutoBattleButton;

	public bool VirtualPad;

	public bool AutoCombinationOn;

	public bool VirtualPadImageOn;

	public bool ShowAutoBattleButton;

	public bool AutoBattleButtonOn;

	public bool SetShowAutoBattleButton;

	public bool RecVoiceOverlay;

	public bool DefaultVirtualPad;

	private bool _0024initialized__UserConfigData_0024;

	public bool IsAutoBattleEnabled
	{
		get
		{
			bool num = ShowAutoBattleButton;
			if (num)
			{
				num = AutoBattleButtonOn;
			}
			return num;
		}
	}

	public UserConfigData()
	{
		if (!_0024initialized__UserConfigData_0024)
		{
			DefaultBGMVolume = 0.8f;
			DefaultSEVolume = 0.8f;
			DefaultRealShadow = ShadowCheck.DefaultFlag;
			DefaultLightOn = ShadowCheck.DefaultFlag;
			BGMVolume = 0.8f;
			SEVolume = 0.8f;
			DeckType = new DeckTypes[5]
			{
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None
			};
			DefaultVirtualPadImageOn = true;
			DefaultShowAutoBattleButton = true;
			VirtualPadImageOn = true;
			DefaultVirtualPad = true;
			_0024initialized__UserConfigData_0024 = true;
		}
		InitApply();
	}

	public UserConfigData(bool init)
	{
		if (!_0024initialized__UserConfigData_0024)
		{
			DefaultBGMVolume = 0.8f;
			DefaultSEVolume = 0.8f;
			DefaultRealShadow = ShadowCheck.DefaultFlag;
			DefaultLightOn = ShadowCheck.DefaultFlag;
			BGMVolume = 0.8f;
			SEVolume = 0.8f;
			DeckType = new DeckTypes[5]
			{
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None,
				DeckTypes.None
			};
			DefaultVirtualPadImageOn = true;
			DefaultShowAutoBattleButton = true;
			VirtualPadImageOn = true;
			DefaultVirtualPad = true;
			_0024initialized__UserConfigData_0024 = true;
		}
		Init();
		if (init)
		{
			Apply();
		}
	}

	public Hashtable ToHash()
	{
		Store();
		Hashtable hashtable = new Hashtable();
		hashtable["BGMVolume"] = BGMVolume;
		hashtable["SEVolume"] = SEVolume;
		hashtable["RealShadow"] = RealShadow;
		hashtable["LightOn"] = LightOn;
		hashtable["VirtualPad"] = VirtualPad;
		hashtable["AutoCombinationOn"] = AutoCombinationOn;
		hashtable["VirtualPadImageOn"] = VirtualPadImageOn;
		hashtable["ShowAutoBattleButton"] = ShowAutoBattleButton;
		hashtable["AutoBattleButtonOn"] = AutoBattleButtonOn;
		hashtable["SetShowAutoBattleButton"] = SetShowAutoBattleButton;
		hashtable["Deck1Type"] = DeckType[0].ToString();
		hashtable["Deck2Type"] = DeckType[1].ToString();
		hashtable["Deck3Type"] = DeckType[2].ToString();
		hashtable["Deck4Type"] = DeckType[3].ToString();
		hashtable["Deck5Type"] = DeckType[4].ToString();
		hashtable["SortType"] = SortType;
		hashtable["RecVoiceOverlay"] = RecVoiceOverlay;
		return hashtable;
	}

	public static UserConfigData FromHash(Hashtable table)
	{
		UserConfigData userConfigData = new UserConfigData(init: false);
		if (table != null)
		{
			userConfigData.BGMVolume = RuntimeServices.UnboxSingle(table["BGMVolume"]);
			userConfigData.SEVolume = RuntimeServices.UnboxSingle(table["SEVolume"]);
			userConfigData.RealShadow = RuntimeServices.UnboxBoolean(table["RealShadow"]);
			userConfigData.LightOn = RuntimeServices.UnboxBoolean(table["LightOn"]);
			userConfigData.VirtualPad = RuntimeServices.UnboxBoolean(table["VirtualPad"]);
			if (table.ContainsKey("VirtualPadImageOn"))
			{
				userConfigData.VirtualPadImageOn = RuntimeServices.UnboxBoolean(table["VirtualPadImageOn"]);
			}
			if (table.ContainsKey("ShowAutoBattleButton"))
			{
				userConfigData.ShowAutoBattleButton = RuntimeServices.UnboxBoolean(table["ShowAutoBattleButton"]);
			}
			if (table.ContainsKey("AutoBattleButtonOn"))
			{
				userConfigData.AutoBattleButtonOn = RuntimeServices.UnboxBoolean(table["AutoBattleButtonOn"]);
			}
			if (table.ContainsKey("SetShowAutoBattleButton"))
			{
				userConfigData.SetShowAutoBattleButton = RuntimeServices.UnboxBoolean(table["SetShowAutoBattleButton"]);
			}
			userConfigData.AutoCombinationOn = RuntimeServices.UnboxBoolean(table["AutoCombinationOn"]);
			try
			{
				if (table.ContainsKey("Deck1Type"))
				{
					DeckTypes[] deckType = userConfigData.DeckType;
					Type typeFromHandle = typeof(DeckTypes);
					object obj = table["Deck1Type"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					deckType[0] = (DeckTypes)Enum.Parse(typeFromHandle, (string)obj, ignoreCase: true);
				}
				if (table.ContainsKey("Deck2Type"))
				{
					DeckTypes[] deckType2 = userConfigData.DeckType;
					Type typeFromHandle2 = typeof(DeckTypes);
					object obj2 = table["Deck2Type"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					deckType2[1] = (DeckTypes)Enum.Parse(typeFromHandle2, (string)obj2, ignoreCase: true);
				}
				if (table.ContainsKey("Deck3Type"))
				{
					DeckTypes[] deckType3 = userConfigData.DeckType;
					Type typeFromHandle3 = typeof(DeckTypes);
					object obj3 = table["Deck3Type"];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					deckType3[2] = (DeckTypes)Enum.Parse(typeFromHandle3, (string)obj3, ignoreCase: true);
				}
				if (table.ContainsKey("Deck4Type"))
				{
					DeckTypes[] deckType4 = userConfigData.DeckType;
					Type typeFromHandle4 = typeof(DeckTypes);
					object obj4 = table["Deck4Type"];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					deckType4[3] = (DeckTypes)Enum.Parse(typeFromHandle4, (string)obj4, ignoreCase: true);
				}
				if (table.ContainsKey("Deck5Type"))
				{
					DeckTypes[] deckType5 = userConfigData.DeckType;
					Type typeFromHandle5 = typeof(DeckTypes);
					object obj5 = table["Deck5Type"];
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					deckType5[4] = (DeckTypes)Enum.Parse(typeFromHandle5, (string)obj5, ignoreCase: true);
				}
			}
			catch (Exception)
			{
			}
			if (table.ContainsKey("SortType"))
			{
				userConfigData.SortType = RuntimeServices.UnboxInt32(table["SortType"]);
			}
			if (table.ContainsKey("RecVoiceOverlay"))
			{
				userConfigData.RecVoiceOverlay = RuntimeServices.UnboxBoolean(table["RecVoiceOverlay"]);
			}
			userConfigData.Apply();
		}
		return userConfigData;
	}

	public void Init()
	{
		GraphicInit();
		SoudnInit();
		PadInit();
		RedcInit();
	}

	public void InitApply()
	{
		Init();
		GraphicApply();
		SoudnApply();
		PadApply();
		RecApply();
	}

	public void GraphicInit()
	{
		RealShadow = DefaultRealShadow;
		LightOn = DefaultLightOn;
	}

	public void SoudnInit()
	{
		BGMVolume = DefaultBGMVolume;
		SEVolume = DefaultSEVolume;
	}

	public void PadInit()
	{
		VirtualPad = DefaultVirtualPad;
		VirtualPadImageOn = true;
		AutoCombinationOn = DefaultAutoCombinationOn;
		ShowAutoBattleButton = DefaultShowAutoBattleButton;
		AutoBattleButtonOn = DefaultAutoBattleButtonOn;
		SetShowAutoBattleButton = DefaultSetShowAutoBattleButton;
	}

	public void RedcInit()
	{
	}

	public void Apply()
	{
		GraphicApply();
		SoudnApply();
		PadApply();
		RecApply();
		DeckTypeApply();
	}

	public void GraphicApply()
	{
		if (ShadowCheck.InitFlag)
		{
			bool num = LightOn;
			if (!num)
			{
				num = RealShadow;
			}
			ShadowSelector.SetupAll(num, RealShadow);
			SceneLightTable.EnableLightTable = LightOn;
		}
	}

	public void SoudnApply()
	{
		SQEX_SoundPlayer.MasterSeVolume = SEVolume;
		SQEX_SoundPlayer.MasterBgmVolume = BGMVolume;
	}

	public void PadApply()
	{
	}

	public void DeckTypeApply()
	{
		if (UserData.Current.userDeckData2 != null)
		{
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				DeckTypes[] deckTypes = UserData.Current.userDeckData2.DeckTypes;
				int num3 = RuntimeServices.NormalizeArrayIndex(deckTypes, index);
				DeckTypes[] deckType = DeckType;
				deckTypes[num3] = deckType[RuntimeServices.NormalizeArrayIndex(deckType, index)];
			}
		}
	}

	public void RecApply()
	{
	}

	public void Store()
	{
		GraphicStore();
		SoudnStore();
		PadStore();
		RecStore();
		DeckTypeStore();
	}

	public void GraphicStore()
	{
	}

	public void SoudnStore()
	{
	}

	public void PadStore()
	{
	}

	public void RecStore()
	{
	}

	public void DeckTypeStore()
	{
		if (UserData.Current.userDeckData2 != null)
		{
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				DeckTypes[] deckType = DeckType;
				int num3 = RuntimeServices.NormalizeArrayIndex(deckType, index);
				DeckTypes[] deckTypes = UserData.Current.userDeckData2.DeckTypes;
				deckType[num3] = deckTypes[RuntimeServices.NormalizeArrayIndex(deckTypes, index)];
			}
		}
	}

	public void ReInitShowAutoBattleButtonFlag()
	{
		if (!SetShowAutoBattleButton)
		{
			SetShowAutoBattleButton = true;
			ShowAutoBattleButton = true;
		}
	}
}
