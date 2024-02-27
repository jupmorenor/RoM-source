using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ColosseumDeckItemUi : DeckItemUiBase
{
	protected ColosseumEquipments _colosseumEquipments;

	[NonSerialized]
	private const string OVER_MAX_COLOR_FORMAT = "[fb4e92]";

	[NonSerialized]
	public const int PET_SET_NUM = 3;

	public GameObject deckItemUiPrefab;

	public float deckItemUiOffsetX;

	private GameObject[] poppetSetGos;

	private ColosseumPoppetSetInfo[] poppetSets;

	private int deckCostMax;

	public UILabelBase deckCostLabel;

	private ColosseumPoppetSetInfo.DispMode dispMode;

	public ColosseumEquipments colosseumEquipments => _colosseumEquipments;

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

	public ColosseumDeckItemUi()
	{
		deckItemUiOffsetX = 316f;
		deckCostMax = -1;
		dispMode = ColosseumPoppetSetInfo.DispMode.Skill;
	}

	public new void Awake()
	{
	}

	public void Start()
	{
	}

	protected override void InitPoppet()
	{
		if (!(null != deckItemUiPrefab))
		{
			throw new AssertionFailedException("null != deckItemUiPrefab");
		}
		if (!(null == poppetSets) || !(null == poppetSetGos))
		{
			return;
		}
		poppetSets = new ColosseumPoppetSetInfo[0];
		poppetSetGos = new GameObject[0];
		Vector3 localPosition = deckItemUiPrefab.transform.localPosition;
		Vector3 localScale = deckItemUiPrefab.transform.localScale;
		int num = 0;
		int num2 = 3;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int id = num;
			num++;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(deckItemUiPrefab);
			gameObject.transform.parent = deckItemUiPrefab.transform.parent;
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localScale = localScale;
			poppetSetGos = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), poppetSetGos, new GameObject[1] { gameObject });
			localPosition.x += deckItemUiOffsetX;
			ColosseumPoppetSetInfo component = gameObject.GetComponent<ColosseumPoppetSetInfo>();
			if (!(null != component))
			{
				throw new AssertionFailedException("null != petSet");
			}
			component.gameObject.SetActive(value: true);
			component.Init(id, dispMode);
			poppetSets = (ColosseumPoppetSetInfo[])RuntimeServices.AddArrays(typeof(ColosseumPoppetSetInfo), poppetSets, new ColosseumPoppetSetInfo[1] { component });
		}
	}

	public void SetDispMode(ColosseumPoppetSetInfo.DispMode mode)
	{
		dispMode = mode;
		if (poppetSets == null)
		{
			return;
		}
		int i = 0;
		ColosseumPoppetSetInfo[] array = poppetSets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (null != array[i])
			{
				array[i].SetDispMode(mode);
			}
		}
	}

	public new void Update()
	{
		UserData current = UserData.Current;
		if (poppetSets != null)
		{
			int i = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i].isPoppetUpdate || array[i].isWeaponUpdate)
				{
					_updateAtkHpGui = true;
				}
				if (null != array[i])
				{
					array[i].UpdatePetSet();
				}
			}
		}
		if (_updateAtkHpGui)
		{
			_updateAtkHp();
		}
	}

	public override void _updateAtkHp()
	{
		if (colosseumEquipments != null)
		{
			int atk = colosseumEquipments.GetAtk();
			int hp = colosseumEquipments.GetHp();
			setLabel(playerAttackPointLabel, atk.ToString("0"));
			setLabel(playerHitPointLabel, hp.ToString("0"));
			updateDeckCost();
			updateRarity();
			_updateAtkHpGui = false;
		}
	}

	public override void deselect()
	{
		if (poppetSets == null)
		{
			return;
		}
		int i = 0;
		ColosseumPoppetSetInfo[] array = poppetSets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(null == array[i]))
			{
				array[i].isPoppetUpdate = true;
				array[i].isWeaponUpdate = true;
			}
		}
	}

	public override void initialize(DeckItemState aOwner, int aDeckIndex, bool aEquip, bool aDebugZero)
	{
		_owner = aOwner;
		DeckSelector owner = aOwner.owner;
		if (null == poppetSets)
		{
			InitPoppet();
		}
		if (aDebugZero)
		{
			aDeckIndex = 0;
		}
		_deckIndex = aDeckIndex;
		if (aEquip)
		{
			_setEquipFromDeckIndex(aDeckIndex);
		}
	}

	protected override void _setEquipFromDeckIndex(int aDeckIndex)
	{
		ColosseumEquipments colosseumEquipments = null;
		if (0 <= aDeckIndex && aDeckIndex < UserData.Current.userPoppetDeckData.deckNum())
		{
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, aDeckIndex)];
		}
		_updateEquip(new ColosseumEquipments[1] { colosseumEquipments }, aDirty: false);
	}

	protected override void _updateEquip(EquipmentsBase[] equps, bool aDirty)
	{
		if (equps.Length < 1)
		{
			return;
		}
		_colosseumEquipments = equps[0] as ColosseumEquipments;
		if (_colosseumEquipments != null && poppetSets != null)
		{
			if (null != poppetSets[0])
			{
				ColosseumPoppetSetInfo petSet = poppetSets[0];
				_setPetSet(ref petSet, _colosseumEquipments.MainPoppet, leader: true);
			}
			if (null != poppetSets[1])
			{
				ColosseumPoppetSetInfo petSet2 = poppetSets[1];
				_setPetSet(ref petSet2, _colosseumEquipments.SubPoppets[0], leader: false);
			}
			if (null != poppetSets[2])
			{
				ColosseumPoppetSetInfo petSet3 = poppetSets[2];
				_setPetSet(ref petSet3, _colosseumEquipments.SubPoppets[1], leader: false);
			}
			_isDirty = aDirty;
		}
		updateEquip();
	}

	protected void _setPetSet(ref ColosseumPoppetSetInfo petSet, ColosseumEquipments.PoppetBattleUnit unit, bool leader)
	{
		petSet.Weapon = unit.Weapon;
		petSet.Poppet = unit.Poppet;
		petSet.Leader = leader;
		petSet.isPoppetUpdate = true;
		petSet.isWeaponUpdate = true;
	}

	private void updateDeckCost()
	{
		int cost = colosseumEquipments.GetCost();
		if (!(null != deckCostLabel))
		{
			return;
		}
		if (deckCostMax > 0)
		{
			if (cost > deckCostMax)
			{
				setLabel(deckCostLabel, string.Format("[fb4e92]" + "{0}[-]/{1}", cost, deckCostMax));
			}
			else
			{
				setLabel(deckCostLabel, $"{cost}/{deckCostMax}");
			}
		}
		else
		{
			setLabel(deckCostLabel, $"{cost}");
		}
	}

	private void updateRarity()
	{
	}

	public bool IsEnableDeck()
	{
		int result;
		if (null == poppetSets)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (null == array[num])
					{
						result = 0;
						break;
					}
					if (!array[num].IsEnableRarity())
					{
						result = 0;
						break;
					}
					if (!array[num].IsEnableElement())
					{
						result = 0;
						break;
					}
					if (!array[num].IsEnableStyle())
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	public void SetCostMax(int costMax)
	{
		deckCostMax = costMax;
		bool costOver = false;
		int cost = colosseumEquipments.GetCost();
		if (deckCostMax > 0 && deckCostMax < cost)
		{
			costOver = true;
		}
		if (poppetSets != null)
		{
			int i = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!(null == array[i]))
				{
					array[i].SetCostOver(costOver);
				}
			}
		}
		_updateAtkHpGui = true;
	}

	public void SetRarityLimit(int[] limits)
	{
		if (poppetSets != null)
		{
			int i = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!(null == array[i]))
				{
					array[i].SetRarityLimit(limits);
				}
			}
		}
		_updateAtkHpGui = true;
	}

	public void SetStyleLimit(int[] limits)
	{
		if (poppetSets != null)
		{
			int i = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!(null == array[i]))
				{
					array[i].SetStyleLimit(limits);
				}
			}
		}
		_updateAtkHpGui = true;
	}

	public void SetElementLimit(int[] limits)
	{
		if (poppetSets != null)
		{
			int i = 0;
			ColosseumPoppetSetInfo[] array = poppetSets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!(null == array[i]))
				{
					array[i].SetElementLimit(limits);
				}
			}
		}
		_updateAtkHpGui = true;
	}
}
