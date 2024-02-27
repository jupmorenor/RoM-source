using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestListItem : UIListItem
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SkipOpenAnim_0024closure_00245009_002421436 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UITweener[] _0024openTweens_002421437;

			internal UITweener _0024tw_002421438;

			internal int _0024_002410950_002421439;

			internal UITweener[] _0024_002410951_002421440;

			internal int _0024_002410952_002421441;

			internal QuestListItem _0024self__002421442;

			public _0024(QuestListItem self_)
			{
				_0024self__002421442 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!_0024self__002421442.keyOpen)
						{
							goto case 1;
						}
						goto case 2;
					case 2:
						if (!_0024self__002421442.keyOpen.active)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024openTweens_002421437 = _0024self__002421442.keyOpen.GetComponentsInChildren<UITweener>(includeInactive: true);
						if (_0024openTweens_002421437 != null)
						{
							_0024_002410950_002421439 = 0;
							_0024_002410951_002421440 = _0024openTweens_002421437;
							for (_0024_002410952_002421441 = _0024_002410951_002421440.Length; _0024_002410950_002421439 < _0024_002410952_002421441; _0024_002410950_002421439++)
							{
								_0024_002410951_002421440[_0024_002410950_002421439].Sample(1f, isFinished: true);
								_0024_002410951_002421440[_0024_002410950_002421439].enabled = false;
							}
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal QuestListItem _0024self__002421443;

		public _0024_0024SkipOpenAnim_0024closure_00245009_002421436(QuestListItem self_)
		{
			_0024self__002421443 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421443);
		}
	}

	public UILabelBase nameLabel;

	public UILabelBase timeLabel;

	public UILabelBase typeLabel;

	public UILabelBase placeLabel;

	public UILabelBase infoLabel;

	public UILabelBase costLabel;

	protected CampaignPanel[] campaignPanels;

	public GameObject campaignPanelPrefab;

	public Transform[] campaignTrfs;

	public GameObject disalbelPanel;

	public GameObject newPanel;

	protected UISprite[] newIcons;

	public GameObject timePanel;

	public MQuests questInfo;

	public MAreas areaInfo;

	protected MWeekEvents weekEvent;

	protected bool disable;

	protected bool lastDisable;

	protected UserData userData;

	public UILabelBase[] extraParamLabel;

	public UISprite bgPanelSprite;

	public UISprite costIcon;

	protected Color color;

	public UITweener[] tweens;

	public GameObject keyClose;

	public GameObject keyOpen;

	public string customKeyIconPrefabPath;

	protected bool isKey;

	protected bool isOpen;

	protected RespQuestTicket ticket;

	protected bool skipOpenAnim;

	public CampaignPanel[] CampaignPanels
	{
		get
		{
			return campaignPanels;
		}
		set
		{
			campaignPanels = value;
		}
	}

	public QuestListItem()
	{
		customKeyIconPrefabPath = "Prefab/GUI/";
	}

	public void SkipOpenAnim()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024SkipOpenAnim_0024closure_00245009_002421436(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public override void Init()
	{
		UIPanel component = GetComponent<UIPanel>();
		if ((bool)newPanel)
		{
			newIcons = newPanel.GetComponentsInChildren<UISprite>(includeInactive: true);
		}
		if ((bool)newPanel)
		{
			tweens = newPanel.GetComponentsInChildren<UITweener>(includeInactive: true);
		}
		if ((bool)component)
		{
			UnityEngine.Object.DestroyObject(component);
		}
	}

	public void InitCampaigns()
	{
		if (campaignPanels == null && campaignTrfs != null)
		{
			campaignPanels = new CampaignPanel[0];
			int num = 0;
			int length = campaignTrfs.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			GameObject gameObject = default(GameObject);
			while (num < length)
			{
				int num2 = num;
				num++;
				Transform[] array = campaignTrfs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num2)])
				{
					if ((bool)campaignPanelPrefab)
					{
						gameObject = NGUITools.InstantiateWithoutUIPanel(campaignPanelPrefab);
					}
					if ((bool)gameObject)
					{
						Transform obj = gameObject.transform;
						Transform[] array2 = campaignTrfs;
						obj.parent = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)];
						gameObject.transform.localPosition = Vector3.zero;
						gameObject.transform.localScale = Vector3.one;
						campaignPanels = (CampaignPanel[])RuntimeServices.AddArrays(typeof(CampaignPanel), campaignPanels, new CampaignPanel[1] { ExtensionsModule.SetComponent<CampaignPanel>(gameObject) });
					}
					num2 = checked(num2 + 1);
				}
			}
		}
		if (campaignPanels == null)
		{
			return;
		}
		int i = 0;
		CampaignPanel[] array3 = campaignPanels;
		for (int length2 = array3.Length; i < length2; i = checked(i + 1))
		{
			if ((bool)array3[i])
			{
				array3[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void SetCampaign(MCampaigns[] allCampaigns)
	{
		InitCampaigns();
		MCampaigns[] lhs = new MCampaigns[0];
		lhs = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), lhs, allCampaigns);
		lhs = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), lhs, MCampaignsUtil.GetCurrentQuestCampaign(questInfo));
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		int i = 0;
		MCampaigns[] array = lhs;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] != null)
				{
					if (!(array[i].ExplainValueForGetCoinUpEffectValue <= 0f))
					{
						num *= array[i].ExplainValueForGetCoinUpEffectValue;
					}
					if (!(array[i].ExplainValueForGetExpUpEffectValue <= 0f))
					{
						num2 *= array[i].ExplainValueForGetExpUpEffectValue;
					}
					if (!(array[i].ExplainValueForDropUpEffectValue <= 0f))
					{
						num3 *= array[i].ExplainValueForDropUpEffectValue;
					}
				}
			}
			if (CampaignPanels == null)
			{
				return;
			}
			int num4 = 0;
			if (num == num2 && num != 1f)
			{
				CampaignPanel[] array2 = CampaignPanels;
				if ((bool)array2[RuntimeServices.NormalizeArrayIndex(array2, num4)])
				{
					CampaignPanel[] array3 = CampaignPanels;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num4++)].Init(CampaignPanel.CampaignType.CoinAndExp, new StringBuilder().Append(num).Append("倍").ToString());
				}
			}
			else
			{
				if (num != 1f)
				{
					CampaignPanel[] array4 = CampaignPanels;
					if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num4)])
					{
						CampaignPanel[] array5 = CampaignPanels;
						array5[RuntimeServices.NormalizeArrayIndex(array5, num4++)].Init(CampaignPanel.CampaignType.Coin, new StringBuilder().Append(num).Append("倍").ToString());
					}
				}
				if (num2 != 1f)
				{
					CampaignPanel[] array6 = CampaignPanels;
					if ((bool)array6[RuntimeServices.NormalizeArrayIndex(array6, num4)])
					{
						CampaignPanel[] array7 = CampaignPanels;
						array7[RuntimeServices.NormalizeArrayIndex(array7, num4++)].Init(CampaignPanel.CampaignType.Exp, new StringBuilder().Append(num2).Append("倍").ToString());
					}
				}
			}
			if (num3 != 1f)
			{
				CampaignPanel[] array8 = CampaignPanels;
				if ((bool)array8[RuntimeServices.NormalizeArrayIndex(array8, num4)])
				{
					CampaignPanel[] array9 = CampaignPanels;
					array9[RuntimeServices.NormalizeArrayIndex(array9, num4++)].Init(CampaignPanel.CampaignType.Drop, new StringBuilder().Append(num3).Append("倍").ToString());
				}
			}
		}
	}

	public void Start()
	{
		userData = UserData.Current;
	}

	public void OnEnable()
	{
		if (!isOpen)
		{
			CheckOpen();
			if (isOpen)
			{
				skipOpenAnim = true;
			}
		}
	}

	public void OnDisable()
	{
		int i = 0;
		UITweener[] array = tweens;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].Reset();
		}
	}

	public bool IsKey(MQuests quest)
	{
		return quest.NeedTicket || MasterExtensionsModule.IsTicket(quest);
	}

	public bool IsKeyOpen(MQuests quest)
	{
		return MasterExtensionsModule.IsOpen(quest);
	}

	private bool setCustomKeyIcon(MQuests quest)
	{
		if (quest != null && !(null == keyOpen))
		{
			ticket = MasterExtensionsModule.GetCustomIconTicket(quest);
			if (ticket != null)
			{
				string path = customKeyIconPrefabPath + ticket.GetIcon();
				GameObject gameObject = Resources.Load(path) as GameObject;
				if (!(null == gameObject))
				{
					GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject);
					if (!(gameObject2 != null))
					{
						throw new AssertionFailedException("go != null");
					}
					Transform parent = keyOpen.transform.parent;
					gameObject2.transform.parent = parent;
					gameObject2.transform.localPosition = keyOpen.transform.localPosition;
					gameObject2.transform.localScale = keyOpen.transform.localScale;
					GameObject obj = keyOpen;
					GameObject obj2 = keyClose;
					TicketQuestKeyIcon component = gameObject2.GetComponent<TicketQuestKeyIcon>();
					if (null == component)
					{
						UnityEngine.Object.DestroyObject(gameObject2);
					}
					else
					{
						GameObject keyOpenIcon = component.KeyOpenIcon;
						GameObject keyCloseIcon = component.KeyCloseIcon;
						if (null != keyOpenIcon && null != keyCloseIcon)
						{
							keyOpen = keyOpenIcon.gameObject;
							UnityEngine.Object.DestroyObject(obj);
							keyClose = keyCloseIcon.gameObject;
							UnityEngine.Object.DestroyObject(obj2);
						}
						else
						{
							UnityEngine.Object.DestroyObject(gameObject2);
						}
					}
				}
			}
		}
		return false;
	}

	public void SetQuest(int index, MQuests quest, MAreas area, MCampaigns[] allCampaigns)
	{
		if (userData == null)
		{
			userData = UserData.Current;
		}
		if ((bool)nameLabel)
		{
			nameLabel.text = string.Empty;
		}
		if ((bool)placeLabel)
		{
			placeLabel.text = string.Empty;
		}
		if ((bool)infoLabel)
		{
			infoLabel.text = string.Empty;
		}
		if ((bool)costLabel)
		{
			costLabel.text = string.Empty;
		}
		if ((bool)typeLabel)
		{
			typeLabel.text = string.Empty;
		}
		object obj = null;
		if ((bool)disalbelPanel)
		{
			disalbelPanel.SetActive(value: false);
		}
		if ((bool)newPanel)
		{
			newPanel.SetActive(value: false);
		}
		if (quest == null || area == null)
		{
			return;
		}
		if (userData != null)
		{
			UserMiscInfo.QuestData.STATE sTATE = userData.userMiscInfo.questData.getState(quest.Id);
			if (sTATE <= UserMiscInfo.QuestData.STATE.Discover)
			{
				if ((bool)newPanel)
				{
					newPanel.SetActive(value: true);
				}
			}
			else if (sTATE == UserMiscInfo.QuestData.STATE.Clear && (bool)newPanel)
			{
				newPanel.SetActive(value: true);
				UISprite component = newPanel.GetComponent<UISprite>();
				component.spriteName = "icon_clear2";
			}
		}
		questInfo = quest;
		areaInfo = area;
		weekEvent = null;
		if (quest != null)
		{
			obj = MWeekEventsUtil.GetWeekEvent(quest.Id);
			if (RuntimeServices.ToBool(obj))
			{
				DateTime utcNow = MerlinDateTime.UtcNow;
				DateTime now = MerlinDateTime.Now;
				TimeSpan localNow = new TimeSpan(now.Hour, now.Minute, now.Second);
				int dayOfWeek = (int)now.DayOfWeek;
				IEnumerator enumerator = RuntimeServices.GetEnumerable(obj).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					object obj2 = current;
					if (!(obj2 is MWeekEvents))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(MWeekEvents));
					}
					if (QuestManager.IsWeekEventReady((MWeekEvents)obj2, utcNow, localNow, dayOfWeek))
					{
						object obj3 = current;
						if (!(obj3 is MWeekEvents))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(MWeekEvents));
						}
						weekEvent = (MWeekEvents)obj3;
						break;
					}
				}
			}
		}
		if ((bool)nameLabel)
		{
			nameLabel.text = quest.GetName();
		}
		if ((bool)placeLabel)
		{
			placeLabel.text = area.GetName();
		}
		if ((bool)infoLabel)
		{
			infoLabel.text = quest.GetExplain();
		}
		if ((bool)costLabel)
		{
			costLabel.text = UIBasicUtility.SafeFormat("{0:00}", quest.ApCost.ToString());
		}
		if ((bool)baseBg)
		{
			if (QuestManager.IsQuestStory(quest))
			{
				baseBg.spriteName = "subwindow_a03";
			}
			else
			{
				baseBg.spriteName = "subwindow_a04";
			}
		}
		if ((bool)bgPanelSprite)
		{
			if (index % 2 == 0)
			{
				bgPanelSprite.color = Color.white;
			}
			else
			{
				bgPanelSprite.color = new Color(0.7f, 0.7f, 0.7f);
			}
		}
		SetCampaign(allCampaigns);
		isKey = IsKey(quest);
		isOpen = IsKeyOpen(quest);
		if (!isKey)
		{
			if ((bool)keyOpen)
			{
				keyOpen.SetActive(value: false);
			}
			if ((bool)keyClose)
			{
				keyClose.SetActive(value: false);
			}
		}
		else
		{
			setCustomKeyIcon(quest);
			ticket = MasterExtensionsModule.GetOpenTicket(quest);
			if ((bool)keyOpen)
			{
				keyOpen.SetActive(isOpen);
			}
			if ((bool)keyClose)
			{
				keyClose.SetActive(!isOpen);
			}
		}
		if (isOpen)
		{
			skipOpenAnim = true;
		}
	}

	public void Selected()
	{
		if (questInfo != null && userData != null && userData.userMiscInfo.questData.getState(questInfo.Id) == UserMiscInfo.QuestData.STATE.Discover)
		{
			userData.userMiscInfo.questData.look(questInfo.Id);
			if ((bool)newPanel)
			{
				newPanel.SetActive(value: false);
			}
		}
	}

	public void Update()
	{
		if (skipOpenAnim)
		{
			skipOpenAnim = false;
			SkipOpenAnim();
		}
		CheckOpen();
		CheckCost();
		RestTime();
	}

	public void CheckOpen()
	{
		if (questInfo == null || !isKey)
		{
			return;
		}
		bool flag = IsKeyOpen(questInfo);
		if (flag != isOpen)
		{
			isOpen = flag;
			ticket = MasterExtensionsModule.GetOpenTicket(questInfo);
			if ((bool)keyOpen)
			{
				keyOpen.SetActive(isOpen);
			}
			if ((bool)keyClose)
			{
				keyClose.SetActive(!isOpen);
			}
		}
	}

	public void CheckCost()
	{
		if (questInfo == null || !disalbelPanel)
		{
			return;
		}
		disable = userData.Ap < questInfo.ApCost;
		if (disable == lastDisable)
		{
			return;
		}
		lastDisable = disable;
		disalbelPanel.SetActive(disable);
		checked
		{
			if (disable)
			{
				if ((bool)nameLabel)
				{
					nameLabel.color /= 2f;
				}
				if ((bool)placeLabel)
				{
					placeLabel.color /= 2f;
				}
				if ((bool)infoLabel)
				{
					infoLabel.color /= 2f;
				}
				if ((bool)costLabel)
				{
					costLabel.color /= 2f;
				}
				if ((bool)typeLabel)
				{
					typeLabel.color /= 2f;
				}
				if ((bool)timeLabel)
				{
					timeLabel.color /= 2f;
				}
				if ((bool)costIcon)
				{
					costIcon.color /= 2f;
				}
				if (newIcons != null)
				{
					int i = 0;
					UISprite[] array = newIcons;
					for (int length = array.Length; i < length; i++)
					{
						array[i].color = array[i].color / 2f;
					}
				}
				return;
			}
			if ((bool)nameLabel)
			{
				nameLabel.color *= 2f;
			}
			if ((bool)placeLabel)
			{
				placeLabel.color *= 2f;
			}
			if ((bool)infoLabel)
			{
				infoLabel.color *= 2f;
			}
			if ((bool)costLabel)
			{
				costLabel.color *= 2f;
			}
			if ((bool)typeLabel)
			{
				typeLabel.color *= 2f;
			}
			if ((bool)timeLabel)
			{
				timeLabel.color *= 2f;
			}
			if ((bool)costIcon)
			{
				costIcon.color *= 2f;
			}
			if (newIcons != null)
			{
				int j = 0;
				UISprite[] array2 = newIcons;
				for (int length2 = array2.Length; j < length2; j++)
				{
					array2[j].color = array2[j].color * 2f;
				}
			}
		}
	}

	public void RestTime()
	{
		if (questInfo == null || !timeLabel || !timePanel)
		{
			return;
		}
		GameObject obj = timePanel;
		bool num = questInfo.QuestType == EnumQuestTypes.Special;
		if (!num)
		{
			num = questInfo.QuestType == EnumQuestTypes.Boost;
		}
		if (!num)
		{
			num = questInfo.QuestType == EnumQuestTypes.LongTerm;
		}
		obj.SetActive(num);
		if (questInfo.QuestType != EnumQuestTypes.Special && questInfo.QuestType != EnumQuestTypes.Boost && questInfo.QuestType != EnumQuestTypes.LongTerm)
		{
			return;
		}
		DateTime now = MerlinDateTime.Now;
		DateTime utcNow = MerlinDateTime.UtcNow;
		TimeSpan timeSpan = default(TimeSpan);
		string empty = string.Empty;
		empty = ((MerlinLanguageSetting.GetCurrentLanguage() != 0) ? "Finished" : "終了");
		checked
		{
			if (!isKey)
			{
				if (weekEvent != null && (questInfo.QuestType == EnumQuestTypes.Special || questInfo.QuestType == EnumQuestTypes.Boost))
				{
					int num2 = unchecked((int)now.DayOfWeek) - unchecked((int)weekEvent.Week);
					TimeSpan timeSpan2 = new TimeSpan(now.Hour - num2 * 24, now.Minute, now.Second);
					timeSpan = weekEvent.EndTime - timeSpan2;
				}
				else
				{
					timeSpan = questInfo.EndDate - utcNow;
				}
			}
			else if (!isOpen || ticket == null)
			{
				timeSpan = new TimeSpan(-1L);
				empty = ((MerlinLanguageSetting.GetCurrentLanguage() != 0) ? "locked" : "未開放");
			}
			else
			{
				timeSpan = ticket.EndDate - utcNow;
			}
			if (MerlinLanguageSetting.GetCurrentLanguage() == LanguageType.Ja)
			{
				if (!(timeSpan.TotalDays < 1.0))
				{
					timeLabel.text = UIBasicUtility.SafeFormat("あと{0:n00}日", timeSpan.TotalDays);
				}
				else if (!(timeSpan.TotalHours < 1.0))
				{
					timeLabel.text = UIBasicUtility.SafeFormat("あと{0:00}時間{1:00}分", timeSpan.Hours, timeSpan.Minutes);
				}
				else if (!(timeSpan.TotalSeconds < 1.0))
				{
					timeLabel.text = UIBasicUtility.SafeFormat("あと{0:n00}分", timeSpan.TotalMinutes);
				}
				else if (timeSpan.Ticks < 0)
				{
					timeLabel.text = empty;
				}
			}
			else if (!(timeSpan.TotalDays < 1.0))
			{
				timeLabel.text = UIBasicUtility.SafeFormat("rest {0:n00}d", timeSpan.TotalDays);
			}
			else if (!(timeSpan.TotalHours < 1.0))
			{
				timeLabel.text = UIBasicUtility.SafeFormat("rest {0:00}h{1:00}m", timeSpan.Hours, timeSpan.Minutes);
			}
			else if (!(timeSpan.TotalSeconds < 1.0))
			{
				timeLabel.text = UIBasicUtility.SafeFormat("rest {0:n00}m", timeSpan.TotalMinutes);
			}
			else if (timeSpan.Ticks < 0)
			{
				timeLabel.text = empty;
			}
		}
	}

	public void SetExtraParam(string[] @params)
	{
		if (@params == null || extraParamLabel == null)
		{
			return;
		}
		int length = @params.Length;
		if (extraParamLabel.Length < length)
		{
			length = extraParamLabel.Length;
		}
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			UILabelBase[] array = extraParamLabel;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num3)])
			{
				UILabelBase[] array2 = extraParamLabel;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num3)].text = @params[RuntimeServices.NormalizeArrayIndex(@params, num3)];
			}
		}
	}

	public void SetExtraParam(int index, string param)
	{
		if (extraParamLabel != null && index >= 0 && extraParamLabel.Length > index)
		{
			UILabelBase[] array = extraParamLabel;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				UILabelBase[] array2 = extraParamLabel;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].text = param;
			}
		}
	}

	public void SetBgPanelSprite(string spriteName)
	{
		if ((bool)bgPanelSprite && (bool)bgPanelSprite)
		{
			bgPanelSprite.spriteName = spriteName;
		}
	}

	internal IEnumerator _0024SkipOpenAnim_0024closure_00245009()
	{
		return new _0024_0024SkipOpenAnim_0024closure_00245009_002421436(this).GetEnumerator();
	}
}
