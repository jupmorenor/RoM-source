using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DeckColosseum : DeckSelector
{
	[NonSerialized]
	private const string OVER_MAX_COLOR_FORMAT = "[fb4e92]";

	public GameObject sendTargetOfPushMessage;

	public UILabelBase deckDispModeButtonLabel;

	private ColosseumPoppetSetInfo.DispMode deckDispMode;

	private bool initDeckLimit;

	public GameObject deckLimitTable;

	public float deckLimitTableWidth;

	private float deckLimitTableInitX;

	public GameObject deckRarityIconPrefab;

	public GameObject deckElementIconPrefab;

	public GameObject deckStyleIconPrefab;

	public string deckRarityIconFormat;

	public string deckElementIconFormat;

	public string deckStyleIconFormat;

	public float[] rarityIconOffsets;

	public float rarityIconHeight;

	public float elementIconOffset;

	public float elementIconHeight;

	public float styleIconOffset;

	public float styleIconHeight;

	public GameObject noLimitText;

	private int[] rarityLimits;

	private int[] elementLimits;

	private int[] styleLimits;

	private UISprite[] deckLimitRarityIcons;

	private UISprite[] deckLimitElementIcons;

	private UISprite[] deckLimitStyleIcons;

	private bool updateRarity;

	private bool updateElement;

	private bool updateStyle;

	private int deckCostMax;

	public UILabelBase deckCostLabel;

	private bool updateCost;

	private bool updateLimit
	{
		get
		{
			bool num = updateRarity;
			if (!num)
			{
				num = updateElement;
			}
			if (!num)
			{
				num = updateStyle;
			}
			return num;
		}
		set
		{
			updateRarity = value;
			updateElement = value;
			updateStyle = value;
		}
	}

	public int DeckCostMax
	{
		get
		{
			return deckCostMax;
		}
		set
		{
			deckCostMax = value;
		}
	}

	public DeckColosseum()
	{
		deckDispMode = ColosseumPoppetSetInfo.DispMode.Skill;
		deckLimitTableWidth = 250f;
		deckRarityIconFormat = "{0}";
		deckElementIconFormat = "icon_{0}";
		deckStyleIconFormat = "{0}";
		rarityIconOffsets = new float[9] { 40f, 30f, 35f, 30f, 35f, 30f, 40f, 30f, 40f };
		rarityIconHeight = 28f;
		elementIconOffset = 35f;
		elementIconHeight = 32f;
		styleIconOffset = 35f;
		styleIconHeight = 32f;
		rarityLimits = new int[0];
		elementLimits = new int[0];
		styleLimits = new int[0];
		deckLimitRarityIcons = new UISprite[0];
		deckLimitElementIcons = new UISprite[0];
		deckLimitStyleIcons = new UISprite[0];
		deckCostMax = -1;
	}

	public new static DeckColosseum Current()
	{
		if (!(null != DeckSelector._current))
		{
			throw new AssertionFailedException("null != _current");
		}
		return DeckSelector._current as DeckColosseum;
	}

	public new void Awake()
	{
		base.Awake();
		InitLimit();
	}

	public new void Start()
	{
		base.Start();
	}

	public new void Close()
	{
		base.Close();
	}

	public new void Update()
	{
		base.Update();
		if (updateLimit)
		{
			UpdateLimit();
			updateLimit = false;
		}
		if (updateCost)
		{
			UpdateDeckCost();
			updateCost = false;
		}
	}

	private void UpdateDeckCost()
	{
		ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(DeckSelector.currentDeckIndex);
		if (!(null != colosseumDeckItemUi))
		{
			return;
		}
		int cost = colosseumDeckItemUi.colosseumEquipments.GetCost();
		if (!(null != deckCostLabel))
		{
			return;
		}
		if (deckCostMax > 0)
		{
			if (cost > deckCostMax)
			{
				deckCostLabel.text = string.Format("[fb4e92]" + "{0}[-]/{1}", cost, deckCostMax);
			}
			else
			{
				deckCostLabel.text = $"{cost}/{deckCostMax}";
			}
		}
		else
		{
			deckCostLabel.text = $"{cost}";
		}
	}

	private void InitLimit()
	{
		if (!(null != deckLimitTable))
		{
			throw new AssertionFailedException("null != deckLimitTable");
		}
		deckLimitTableInitX = deckLimitTable.transform.localPosition.x;
		initDeckLimit = true;
	}

	private void UpdateLimit()
	{
		if (!(null != deckLimitTable))
		{
			throw new AssertionFailedException("null != deckLimitTable");
		}
		if (!initDeckLimit)
		{
			InitLimit();
		}
		float x = 0f;
		float w = 0f;
		bool flag = false;
		int num = 0;
		checked
		{
			if (updateRarity)
			{
				__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ iconFunc = delegate(int id)
				{
					MRares mRares = MRares.Get(id);
					return (mRares != null) ? UIBasicUtility.SafeFormat(deckRarityIconFormat, mRares.Icon) : string.Empty;
				};
				RemoveLimit(ref deckLimitRarityIcons);
				deckLimitRarityIcons = SetLimitIcon(ref x, ref w, deckRarityIconPrefab, rarityLimits, iconFunc, rarityIconOffsets, rarityIconHeight);
				flag = true;
				if (deckLimitRarityIcons != null)
				{
					num += deckLimitRarityIcons.Length;
				}
			}
			if (updateElement)
			{
				__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ iconFunc2 = delegate(int id)
				{
					MElements mElements = MElements.Get(id);
					return (mElements != null) ? UIBasicUtility.SafeFormat(deckElementIconFormat, mElements.Icon) : string.Empty;
				};
				RemoveLimit(ref deckLimitElementIcons);
				deckLimitElementIcons = SetLimitIcon(ref x, ref w, deckElementIconPrefab, elementLimits, iconFunc2, new float[1] { elementIconOffset }, elementIconHeight);
				flag = true;
				if (deckLimitElementIcons != null)
				{
					num += deckLimitElementIcons.Length;
				}
			}
			if (updateStyle)
			{
				__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ iconFunc3 = delegate(int id)
				{
					MStyles mStyles = MStyles.Get(id);
					return (mStyles != null) ? UIBasicUtility.SafeFormat(deckStyleIconFormat, mStyles.Icon) : string.Empty;
				};
				RemoveLimit(ref deckLimitStyleIcons);
				deckLimitStyleIcons = SetLimitIcon(ref x, ref w, deckStyleIconPrefab, styleLimits, iconFunc3, new float[1] { styleIconOffset }, styleIconHeight);
				flag = true;
				if (deckLimitStyleIcons != null)
				{
					num += deckLimitStyleIcons.Length;
				}
			}
			if (!flag)
			{
				return;
			}
			if (!(w <= 0f))
			{
				if (!(deckLimitTableWidth <= w))
				{
					float x2 = deckLimitTableInitX - 0.5f * w;
					Vector3 localPosition = deckLimitTable.transform.localPosition;
					float num2 = (localPosition.x = x2);
					Vector3 vector2 = (deckLimitTable.transform.localPosition = localPosition);
				}
				else
				{
					float x3 = deckLimitTableWidth / w;
					Vector3 localScale = deckLimitTable.transform.localScale;
					float num3 = (localScale.x = x3);
					Vector3 vector4 = (deckLimitTable.transform.localScale = localScale);
					float x4 = deckLimitTableInitX - 0.5f * deckLimitTableWidth;
					Vector3 localPosition2 = deckLimitTable.transform.localPosition;
					float num4 = (localPosition2.x = x4);
					Vector3 vector6 = (deckLimitTable.transform.localPosition = localPosition2);
				}
			}
			if (null != noLimitText)
			{
				noLimitText.SetActive(0 == num);
			}
		}
	}

	private void UpdateCurrentDeckGui()
	{
		ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(DeckSelector.currentDeckIndex);
		if (null != colosseumDeckItemUi)
		{
			colosseumDeckItemUi._updateAtkHp();
		}
		updateLimit = true;
		updateCost = true;
	}

	private void RemoveLimit(ref UISprite[] sprites)
	{
		if (!(null == sprites))
		{
			int i = 0;
			UISprite[] array = sprites;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				UnityEngine.Object.Destroy(array[i]);
			}
			sprites = new UISprite[0];
		}
	}

	private UISprite[] SetLimitIcon(ref float x, ref float w, GameObject prefab, int[] ids, __DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ iconFunc, float[] iconOffset, float iconHeight)
	{
		if (!(null != deckLimitTable))
		{
			throw new AssertionFailedException("null != deckLimitTable");
		}
		if (!(null != prefab))
		{
			throw new AssertionFailedException("null != prefab");
		}
		if (iconOffset == null)
		{
			throw new AssertionFailedException("null != iconOffset");
		}
		if (!(0f < iconHeight))
		{
			throw new AssertionFailedException("0.0F < iconHeight");
		}
		UISprite[] result;
		if (null == ids)
		{
			result = new UISprite[0];
		}
		else
		{
			UISprite[] array = new UISprite[0];
			int i = 0;
			for (int length = ids.Length; i < length; i = checked(i + 1))
			{
				string text = iconFunc(ids[i]);
				if (!string.IsNullOrEmpty(text))
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab);
					Vector3 localScale = gameObject.transform.localScale;
					gameObject.transform.parent = deckLimitTable.transform;
					gameObject.transform.localPosition = new Vector3(x, 0f, 0f);
					w = x;
					if (iconOffset.Length <= ids[i])
					{
						x += iconOffset[0];
					}
					else
					{
						x += iconOffset[RuntimeServices.NormalizeArrayIndex(iconOffset, ids[i])];
					}
					gameObject.transform.localScale = new Vector3(localScale.x / (localScale.y / iconHeight), iconHeight, 0f);
					UISprite component = gameObject.GetComponent<UISprite>();
					if (null != component)
					{
						component.spriteName = text;
						array = (UISprite[])RuntimeServices.AddArrays(typeof(UISprite), array, new UISprite[1] { component });
					}
				}
			}
			result = array;
		}
		return result;
	}

	public static ApiPoppetDeckUpdate CreatePoppetDeckRequest()
	{
		UserData current = UserData.Current;
		ApplyPoppetDeckData();
		return (ApiPoppetDeckUpdate)current.userPoppetDeckData.createRequest();
	}

	public static ColosseumEquipments[] CreateColosseumEquipmentsArray()
	{
		int num = DeckSelector._current.deckCount;
		ColosseumEquipments[] array = new ColosseumEquipments[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(num4);
			ColosseumEquipments colosseumEquipments = null;
			if (null != colosseumDeckItemUi)
			{
				colosseumEquipments = colosseumDeckItemUi.colosseumEquipments;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, num4)] = colosseumEquipments;
		}
		return array;
	}

	public static void ApplyPoppetDeckData()
	{
		UserData.Current.userPoppetDeckData.CurrentDeck = DeckSelector.currentDeckIndex;
		UserData.Current.userPoppetDeckData.ColEquips = CreateColosseumEquipmentsArray();
	}

	public void PushWeapon(int id)
	{
		if (null != sendTargetOfPushMessage)
		{
			sendTargetOfPushMessage.SendMessage("PushWeapon", id);
		}
	}

	public void PushPoppet(int id)
	{
		if (null != sendTargetOfPushMessage)
		{
			sendTargetOfPushMessage.SendMessage("PushPoppet", id);
		}
	}

	public void SetDeckItemDipsMode(ColosseumPoppetSetInfo.DispMode mode)
	{
		int num = DeckSelector._current.deckCount;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int aDeckIndex = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(aDeckIndex);
			colosseumDeckItemUi.SetDispMode(mode);
		}
	}

	public void SetCostMax(int costMax)
	{
		updateCost = true;
		deckCostMax = costMax;
		int num = DeckSelector._current.deckCount;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int aDeckIndex = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(aDeckIndex);
			colosseumDeckItemUi.SetCostMax(costMax);
		}
	}

	public void SetRarityLimit(int[] limits)
	{
		updateRarity = true;
		rarityLimits = limits;
		int num = DeckSelector._current.deckCount;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int aDeckIndex = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(aDeckIndex);
			colosseumDeckItemUi.SetRarityLimit(limits);
		}
	}

	public void SetStyleLimit(int[] limits)
	{
		updateStyle = true;
		styleLimits = limits;
		int num = DeckSelector._current.deckCount;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int aDeckIndex = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(aDeckIndex);
			colosseumDeckItemUi.SetStyleLimit(limits);
		}
	}

	public void SetElementLimit(int[] limits)
	{
		updateElement = true;
		elementLimits = limits;
		int num = DeckSelector._current.deckCount;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int aDeckIndex = num2;
			num2++;
			ColosseumDeckItemUi colosseumDeckItemUi = (ColosseumDeckItemUi)DeckSelector._current._getDeckItemUi(aDeckIndex);
			colosseumDeckItemUi.SetElementLimit(limits);
		}
	}

	public void OnClickedDeckItemDipsModeButton()
	{
		if (deckDispMode == ColosseumPoppetSetInfo.DispMode.Skill)
		{
			deckDispMode = ColosseumPoppetSetInfo.DispMode.Status;
			UIBasicUtility.SetLabel(deckDispModeButtonLabel, MTexts.Msg("exp_status"));
		}
		else if (deckDispMode == ColosseumPoppetSetInfo.DispMode.Status)
		{
			deckDispMode = ColosseumPoppetSetInfo.DispMode.Skill;
			UIBasicUtility.SetLabel(deckDispModeButtonLabel, MTexts.Msg("exp_skill"));
		}
		SetDeckItemDipsMode(deckDispMode);
	}

	protected override void _onSent()
	{
		base._onSent();
	}

	protected override void _updateDeckGui()
	{
		base._updateDeckGui();
		UpdateCurrentDeckGui();
	}

	internal string _0024UpdateLimit_0024closure_00243138(int id)
	{
		MRares mRares = MRares.Get(id);
		return (mRares != null) ? UIBasicUtility.SafeFormat(deckRarityIconFormat, mRares.Icon) : string.Empty;
	}

	internal string _0024UpdateLimit_0024closure_00243139(int id)
	{
		MElements mElements = MElements.Get(id);
		return (mElements != null) ? UIBasicUtility.SafeFormat(deckElementIconFormat, mElements.Icon) : string.Empty;
	}

	internal string _0024UpdateLimit_0024closure_00243140(int id)
	{
		MStyles mStyles = MStyles.Get(id);
		return (mStyles != null) ? UIBasicUtility.SafeFormat(deckStyleIconFormat, mStyles.Icon) : string.Empty;
	}
}
