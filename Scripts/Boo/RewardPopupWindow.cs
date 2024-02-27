using System;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class RewardPopupWindow : MonoBehaviour
{
	[Serializable]
	public class RewardTypeGroup
	{
		public GameObject topPanel;

		public UILabelBase titleLabel;

		public UILabelBase messageLabel;
	}

	[Serializable]
	public enum Type
	{
		rewardTypeNormal,
		rewardTypeRaid,
		Max
	}

	[Serializable]
	internal class _0024SetupButton_0024closure_00244268
	{
		internal int _0024n_002415061;

		internal RewardPopupWindow _0024this_002415062;

		public _0024SetupButton_0024closure_00244268(int _0024n_002415061, RewardPopupWindow _0024this_002415062)
		{
			this._0024n_002415061 = _0024n_002415061;
			this._0024this_002415062 = _0024this_002415062;
		}

		public void Invoke()
		{
			if (_0024this_002415062.pushIconFunc != null)
			{
				__RewardPopupWindow_pushIconFunc_0024callable101_002447_21__ pushIconFunc = _0024this_002415062.pushIconFunc;
				RespReward[] curRewards = _0024this_002415062.curRewards;
				pushIconFunc(curRewards[RuntimeServices.NormalizeArrayIndex(curRewards, _0024n_002415061)]);
			}
		}
	}

	public GameObject weaponIconPrefab;

	public GameObject poppetIconPrefab;

	public GameObject fayStoneIconPrefab;

	public GameObject moneyIconPrefab;

	public GameObject pointIconPrefab;

	public GameObject manaPointIconPrefab;

	public GameObject commonIconPrefab;

	public Transform reward1IconParent;

	public GameObject reward1IconFrame;

	public UILabelBase reward1IconQuantity;

	public Transform[] reward2IconParent;

	public GameObject reward2IconFrame;

	public Type rewardType;

	public RewardTypeGroup[] rewardTypeGroups;

	protected GameObject[] rewardIcon;

	protected RespReward[] curRewards;

	protected __RewardPopupWindow_pushIconFunc_0024callable101_002447_21__ pushIconFunc;

	protected bool init;

	protected bool setupIcon;

	protected bool setupButton;

	public Type RewardType
	{
		get
		{
			return rewardType;
		}
		set
		{
			rewardType = value;
		}
	}

	public RespReward[] CurRewards
	{
		get
		{
			return curRewards;
		}
		set
		{
			curRewards = value;
		}
	}

	public RewardPopupWindow()
	{
		reward2IconParent = new Transform[2];
		rewardTypeGroups = new RewardTypeGroup[2];
	}

	public void Start()
	{
		if (!init)
		{
			InitRerewards();
		}
	}

	public void Update()
	{
		if (setupIcon)
		{
			SetupIcon();
		}
		if (setupButton)
		{
			SetupButton();
		}
	}

	public void InitRerewards()
	{
		init = true;
		curRewards = null;
		pushIconFunc = null;
		checked
		{
			if (rewardIcon != null)
			{
				int i = 0;
				GameObject[] array = rewardIcon;
				for (int length = array.Length; i < length; i++)
				{
					UnityEngine.Object.DestroyObject(array[i]);
				}
				rewardIcon = null;
			}
			reward1IconFrame.SetActive(value: false);
			reward2IconFrame.SetActive(value: false);
			object[] array2 = new object[0];
			object[] array3 = new object[0];
			int j = 0;
			RewardTypeGroup[] array4 = rewardTypeGroups;
			for (int length2 = array4.Length; j < length2; j++)
			{
				if (array4[j] != null)
				{
					if ((bool)array4[j].topPanel)
					{
						array4[j].topPanel.SetActive(value: false);
					}
					if ((bool)array4[j].messageLabel)
					{
						array4[j].messageLabel.text = string.Empty;
					}
					if ((bool)array4[j].titleLabel)
					{
						array4[j].titleLabel.text = string.Empty;
					}
				}
			}
			if ((bool)reward1IconQuantity)
			{
				reward1IconQuantity.text = string.Empty;
			}
		}
	}

	public void SetRespRewards(Type type, RespReward[] rewards, string title, string message, __RewardPopupWindow_pushIconFunc_0024callable101_002447_21__ pushIconFunc)
	{
		InitRerewards();
		rewardType = type;
		curRewards = rewards;
		this.pushIconFunc = pushIconFunc;
		RewardTypeGroup[] array = rewardTypeGroups;
		RewardTypeGroup rewardTypeGroup = array[RuntimeServices.NormalizeArrayIndex(array, (int)type)];
		if (rewardTypeGroup != null)
		{
			if ((bool)rewardTypeGroup.topPanel)
			{
				rewardTypeGroup.topPanel.SetActive(value: true);
			}
			if ((bool)rewardTypeGroup.messageLabel)
			{
				rewardTypeGroup.messageLabel.text = message;
			}
			if ((bool)rewardTypeGroup.titleLabel)
			{
				rewardTypeGroup.titleLabel.text = title;
			}
		}
		setupButton = true;
		setupIcon = true;
		if (curRewards != null)
		{
			if (curRewards.Length == 1)
			{
				reward2IconFrame.SetActive(value: false);
				reward1IconFrame.SetActive(value: true);
			}
			else if (curRewards.Length >= 2)
			{
				reward1IconFrame.SetActive(value: false);
				reward2IconFrame.SetActive(value: true);
			}
		}
	}

	private void SetRerewardCore(RespReward reward, Transform parent, int quantity)
	{
		if (reward == null || !parent)
		{
			return;
		}
		int typeValue = reward.TypeValue;
		GameObject gameObject = null;
		switch (typeValue)
		{
		case 3:
		{
			gameObject = SetIcon(weaponIconPrefab, parent);
			WeaponInfo component = gameObject.GetComponent<WeaponInfo>();
			RespWeapon weapon = reward.toRespWeapon();
			component.SetWeapon(weapon, ignoreUnknown: true);
			break;
		}
		case 4:
		{
			gameObject = SetIcon(poppetIconPrefab, parent);
			MuppetInfo component2 = gameObject.GetComponent<MuppetInfo>();
			RespPoppet muppet = reward.toRespPoppet();
			component2.SetMuppet(muppet, ignoreUnknown: true);
			break;
		}
		default:
		{
			MMasterTypeValues mMasterTypeValues = MMasterTypeValues.Get(reward.TypeValue);
			if (mMasterTypeValues != null)
			{
				gameObject = SetIconEx(commonIconPrefab, parent, mMasterTypeValues.Icon);
			}
			break;
		}
		case 0:
			break;
		}
		if (quantity > 0 && (bool)reward1IconQuantity)
		{
			reward1IconQuantity.text = new StringBuilder("*").Append((object)quantity).ToString();
			reward1IconQuantity.gameObject.SetActive(value: true);
		}
		if ((bool)gameObject)
		{
			if (rewardIcon == null)
			{
				rewardIcon = new GameObject[0];
			}
			rewardIcon = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), rewardIcon, new GameObject[1] { gameObject });
		}
	}

	private void SetupIcon()
	{
		RespReward[] array = curRewards;
		if (array != null)
		{
			setupIcon = false;
			if (array.Length == 1)
			{
				reward1IconFrame.SetActive(value: true);
				SetRerewardCore(array[0], reward1IconParent, array[0].Quantity);
			}
			else if (array.Length >= 2)
			{
				reward2IconFrame.SetActive(value: true);
				SetRerewardCore(array[0], reward2IconParent[0], 0);
				SetRerewardCore(array[1], reward2IconParent[1], 0);
			}
		}
	}

	private void SetupButton()
	{
		UITweener[] components = this.gameObject.GetComponents<UITweener>();
		int i = 0;
		UITweener[] array = components;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].enabled)
			{
				return;
			}
		}
		if (rewardIcon != null)
		{
			setupButton = false;
			int num = 0;
			int length2 = rewardIcon.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length2)
			{
				int num2 = num;
				num++;
				GameObject[] array2 = rewardIcon;
				GameObject gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)];
				UIButtonMessage uIButtonMessage = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
				BoxCollider boxCollider = NGUITools.AddWidgetCollider(gameObject);
				uIButtonMessage.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(new _0024SetupButton_0024closure_00244268(num2, this).Invoke);
			}
		}
	}

	private GameObject SetIcon(GameObject prefab, Transform parent)
	{
		return SetIconEx(prefab, parent, null);
	}

	private GameObject SetIconEx(GameObject prefab, Transform parent, string iconName)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab);
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = new Vector3(0f, 0f, -50f);
		gameObject.transform.localScale = Vector3.one;
		if (!string.IsNullOrEmpty(iconName))
		{
			UISprite componentInChildren = gameObject.GetComponentInChildren<UISprite>();
			if ((bool)componentInChildren)
			{
				componentInChildren.spriteName = iconName;
				int num = 96;
				Vector3 localScale = componentInChildren.transform.localScale;
				float num2 = (localScale.x = num);
				Vector3 vector2 = (componentInChildren.transform.localScale = localScale);
				int num3 = 96;
				Vector3 localScale2 = componentInChildren.transform.localScale;
				float num4 = (localScale2.y = num3);
				Vector3 vector4 = (componentInChildren.transform.localScale = localScale2);
			}
		}
		return gameObject;
	}
}
