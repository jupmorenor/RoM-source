using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class SupportEquipInfo : MonoBehaviour
{
	[Serializable]
	public class AtkHpLabel
	{
		public UILabelBase label;

		public float atk;

		public float hp;

		protected bool flag;

		public void Set(float atk, float hp, UILabelBase label)
		{
			this.atk = atk;
			this.hp = hp;
			this.label = label;
		}

		public void Update(float alpha, bool atkFlag)
		{
			if (!label)
			{
				return;
			}
			if (flag != atkFlag)
			{
				flag = atkFlag;
				if (flag)
				{
					label.color = MyHomeEquipMain.AtkHpColors[0];
					label.text = atk.ToString("#,0");
				}
				else
				{
					label.color = MyHomeEquipMain.AtkHpColors[1];
					label.text = hp.ToString("#,0");
				}
			}
			if ((bool)label)
			{
				Color color = label.color;
				float num = (color.a = alpha);
				Color color3 = (label.color = color);
			}
		}
	}

	[Serializable]
	public class SupportWeaponInfo
	{
		[Serializable]
		public class SupportSubWeaponInfo
		{
			public IconCreatorEx subIcon;

			protected WeaponInfo sub;

			public UISprite subStyle;

			public UISprite subElements;

			public UILabelBase subStatus;

			public AtkHpLabel subAtkHp;

			public WeaponInfo Sub
			{
				get
				{
					return sub;
				}
				set
				{
					sub = value;
				}
			}

			public SupportSubWeaponInfo()
			{
				subAtkHp = new AtkHpLabel();
			}
		}

		public IconCreatorEx mainIcon;

		protected WeaponInfo main;

		public SupportSubWeaponInfo[] subWeapons;

		public IconCreatorEx petIcon;

		protected MuppetInfo pet;

		public UISprite petElements;

		public UILabelBase petStatus;

		public AtkHpLabel petAtkHp;

		public SupportWeaponInfo()
		{
			subWeapons = new SupportSubWeaponInfo[3];
			petAtkHp = new AtkHpLabel();
		}

		public void Update(float alpha, bool atkFlag)
		{
			int num = 0;
			while (num < 3)
			{
				int index = num;
				num++;
				SupportSubWeaponInfo[] array = subWeapons;
				array[RuntimeServices.NormalizeArrayIndex(array, index)].subAtkHp.Update(alpha, atkFlag);
			}
			petAtkHp.Update(alpha, atkFlag);
		}

		public int[] SetWeapons(RespWeapon respMainWep, RespWeapon[] respSubWep, RespPoppet respPet, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[] subElemFuncs, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[] subStyleFuncs, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ petElemFunc)
		{
			main = mainIcon.WeaponInfo;
			int num = 0;
			int num2 = 0;
			checked
			{
				if (respMainWep != null && respSubWep != null)
				{
					if ((bool)main)
					{
						main.SetWeapon(respMainWep);
					}
					int num3 = 0;
					while (num3 < 3)
					{
						int num4 = num3;
						num3 = unchecked(num3 + 1);
						SupportSubWeaponInfo[] array = subWeapons;
						if (array[RuntimeServices.NormalizeArrayIndex(array, num4)] == null)
						{
							continue;
						}
						SupportSubWeaponInfo[] array2 = subWeapons;
						SupportSubWeaponInfo obj = array2[RuntimeServices.NormalizeArrayIndex(array2, num4)];
						SupportSubWeaponInfo[] array3 = subWeapons;
						obj.Sub = array3[RuntimeServices.NormalizeArrayIndex(array3, num4)].subIcon.WeaponInfo;
						if (respSubWep.Length >= num4 + 1)
						{
							SupportSubWeaponInfo[] array4 = subWeapons;
							if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num4)].Sub)
							{
								SupportSubWeaponInfo[] array5 = subWeapons;
								array5[RuntimeServices.NormalizeArrayIndex(array5, num4)].Sub.SetWeapon(respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)]);
							}
						}
						SupportSubWeaponInfo[] array6 = subWeapons;
						if ((bool)array6[RuntimeServices.NormalizeArrayIndex(array6, num4)].subElements)
						{
							SupportSubWeaponInfo[] array7 = subWeapons;
							array7[RuntimeServices.NormalizeArrayIndex(array7, num4)].subElements.enabled = true;
							SupportSubWeaponInfo[] array8 = subWeapons;
							array8[RuntimeServices.NormalizeArrayIndex(array8, num4)].subElements.spriteName = UIBasicUtility.GetElementSpriteName(respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)].ElementId);
							if (respMainWep != null)
							{
								if (respMainWep.ElementId == respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)].ElementId)
								{
									float r = 1f;
									SupportSubWeaponInfo[] array9 = subWeapons;
									Color color = array9[RuntimeServices.NormalizeArrayIndex(array9, num4)].subElements.color;
									float num5 = (color.r = r);
									SupportSubWeaponInfo[] array10 = subWeapons;
									Color color3 = (array10[RuntimeServices.NormalizeArrayIndex(array10, num4)].subElements.color = color);
									float g = 1f;
									SupportSubWeaponInfo[] array11 = subWeapons;
									Color color4 = array11[RuntimeServices.NormalizeArrayIndex(array11, num4)].subElements.color;
									float num6 = (color4.g = g);
									SupportSubWeaponInfo[] array12 = subWeapons;
									Color color6 = (array12[RuntimeServices.NormalizeArrayIndex(array12, num4)].subElements.color = color4);
									float b = 1f;
									SupportSubWeaponInfo[] array13 = subWeapons;
									Color color7 = array13[RuntimeServices.NormalizeArrayIndex(array13, num4)].subElements.color;
									float num7 = (color7.b = b);
									SupportSubWeaponInfo[] array14 = subWeapons;
									Color color9 = (array14[RuntimeServices.NormalizeArrayIndex(array14, num4)].subElements.color = color7);
									num++;
									subElemFuncs[RuntimeServices.NormalizeArrayIndex(subElemFuncs, num4)](arg0: true);
									goto IL_0388;
								}
							}
							float r2 = 0.5f;
							SupportSubWeaponInfo[] array15 = subWeapons;
							Color color10 = array15[RuntimeServices.NormalizeArrayIndex(array15, num4)].subElements.color;
							float num8 = (color10.r = r2);
							SupportSubWeaponInfo[] array16 = subWeapons;
							Color color12 = (array16[RuntimeServices.NormalizeArrayIndex(array16, num4)].subElements.color = color10);
							float g2 = 0.5f;
							SupportSubWeaponInfo[] array17 = subWeapons;
							Color color13 = array17[RuntimeServices.NormalizeArrayIndex(array17, num4)].subElements.color;
							float num9 = (color13.g = g2);
							SupportSubWeaponInfo[] array18 = subWeapons;
							Color color15 = (array18[RuntimeServices.NormalizeArrayIndex(array18, num4)].subElements.color = color13);
							float b2 = 0.5f;
							SupportSubWeaponInfo[] array19 = subWeapons;
							Color color16 = array19[RuntimeServices.NormalizeArrayIndex(array19, num4)].subElements.color;
							float num10 = (color16.b = b2);
							SupportSubWeaponInfo[] array20 = subWeapons;
							Color color18 = (array20[RuntimeServices.NormalizeArrayIndex(array20, num4)].subElements.color = color16);
							subElemFuncs[RuntimeServices.NormalizeArrayIndex(subElemFuncs, num4)](arg0: false);
						}
						goto IL_0388;
						IL_0632:
						SupportSubWeaponInfo[] array21 = subWeapons;
						if ((bool)array21[RuntimeServices.NormalizeArrayIndex(array21, num4)].subStatus)
						{
							SupportSubWeaponInfo[] array22 = subWeapons;
							array22[RuntimeServices.NormalizeArrayIndex(array22, num4)].subStatus.enabled = true;
							if (respMainWep != null)
							{
								float num11 = DamageCalc.SupportWeaponAttackRevise(respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)], respMainWep);
								float num12 = DamageCalc.SupportWeaponHpRevise(respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)], respMainWep);
								SupportSubWeaponInfo[] array23 = subWeapons;
								AtkHpLabel subAtkHp = array23[RuntimeServices.NormalizeArrayIndex(array23, num4)].subAtkHp;
								float atk = num11;
								float hp = num12;
								SupportSubWeaponInfo[] array24 = subWeapons;
								subAtkHp.Set(atk, hp, array24[RuntimeServices.NormalizeArrayIndex(array24, num4)].subStatus);
							}
						}
						continue;
						IL_0388:
						SupportSubWeaponInfo[] array25 = subWeapons;
						if ((bool)array25[RuntimeServices.NormalizeArrayIndex(array25, num4)].subStyle)
						{
							SupportSubWeaponInfo[] array26 = subWeapons;
							array26[RuntimeServices.NormalizeArrayIndex(array26, num4)].subStyle.enabled = true;
							SupportSubWeaponInfo[] array27 = subWeapons;
							array27[RuntimeServices.NormalizeArrayIndex(array27, num4)].subStyle.spriteName = UIBasicUtility.GetStyleSpriteName(respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)].StyleId);
							if (respMainWep != null)
							{
								if (respMainWep.StyleId == respSubWep[RuntimeServices.NormalizeArrayIndex(respSubWep, num4)].StyleId)
								{
									float r3 = 1f;
									SupportSubWeaponInfo[] array28 = subWeapons;
									Color color19 = array28[RuntimeServices.NormalizeArrayIndex(array28, num4)].subStyle.color;
									float num13 = (color19.r = r3);
									SupportSubWeaponInfo[] array29 = subWeapons;
									Color color21 = (array29[RuntimeServices.NormalizeArrayIndex(array29, num4)].subStyle.color = color19);
									float g3 = 1f;
									SupportSubWeaponInfo[] array30 = subWeapons;
									Color color22 = array30[RuntimeServices.NormalizeArrayIndex(array30, num4)].subStyle.color;
									float num14 = (color22.g = g3);
									SupportSubWeaponInfo[] array31 = subWeapons;
									Color color24 = (array31[RuntimeServices.NormalizeArrayIndex(array31, num4)].subStyle.color = color22);
									float b3 = 1f;
									SupportSubWeaponInfo[] array32 = subWeapons;
									Color color25 = array32[RuntimeServices.NormalizeArrayIndex(array32, num4)].subStyle.color;
									float num15 = (color25.b = b3);
									SupportSubWeaponInfo[] array33 = subWeapons;
									Color color27 = (array33[RuntimeServices.NormalizeArrayIndex(array33, num4)].subStyle.color = color25);
									num2++;
									subStyleFuncs[RuntimeServices.NormalizeArrayIndex(subStyleFuncs, num4)](arg0: true);
									goto IL_0632;
								}
							}
							float r4 = 0.5f;
							SupportSubWeaponInfo[] array34 = subWeapons;
							Color color28 = array34[RuntimeServices.NormalizeArrayIndex(array34, num4)].subStyle.color;
							float num16 = (color28.r = r4);
							SupportSubWeaponInfo[] array35 = subWeapons;
							Color color30 = (array35[RuntimeServices.NormalizeArrayIndex(array35, num4)].subStyle.color = color28);
							float g4 = 0.5f;
							SupportSubWeaponInfo[] array36 = subWeapons;
							Color color31 = array36[RuntimeServices.NormalizeArrayIndex(array36, num4)].subStyle.color;
							float num17 = (color31.g = g4);
							SupportSubWeaponInfo[] array37 = subWeapons;
							Color color33 = (array37[RuntimeServices.NormalizeArrayIndex(array37, num4)].subStyle.color = color31);
							float b4 = 0.5f;
							SupportSubWeaponInfo[] array38 = subWeapons;
							Color color34 = array38[RuntimeServices.NormalizeArrayIndex(array38, num4)].subStyle.color;
							float num18 = (color34.b = b4);
							SupportSubWeaponInfo[] array39 = subWeapons;
							Color color36 = (array39[RuntimeServices.NormalizeArrayIndex(array39, num4)].subStyle.color = color34);
							subStyleFuncs[RuntimeServices.NormalizeArrayIndex(subStyleFuncs, num4)](arg0: false);
						}
						goto IL_0632;
					}
				}
				if (respPet != null)
				{
					pet = petIcon.MuppetInfo;
					if ((bool)pet)
					{
						pet.SetMuppet(respPet);
					}
					if ((bool)petElements)
					{
						petElements.enabled = true;
						petElements.spriteName = UIBasicUtility.GetElementSpriteName(respPet.ElementId);
						if (respMainWep != null && respMainWep.ElementId == respPet.ElementId)
						{
							float r5 = 1f;
							Color color37 = petElements.color;
							float num19 = (color37.r = r5);
							Color color39 = (petElements.color = color37);
							float g5 = 1f;
							Color color40 = petElements.color;
							float num20 = (color40.g = g5);
							Color color42 = (petElements.color = color40);
							float b5 = 1f;
							Color color43 = petElements.color;
							float num21 = (color43.b = b5);
							Color color45 = (petElements.color = color43);
							num++;
							petElemFunc(arg0: true);
						}
						else
						{
							float r6 = 0.5f;
							Color color46 = petElements.color;
							float num22 = (color46.r = r6);
							Color color48 = (petElements.color = color46);
							float g6 = 0.5f;
							Color color49 = petElements.color;
							float num23 = (color49.g = g6);
							Color color51 = (petElements.color = color49);
							float b6 = 0.5f;
							Color color52 = petElements.color;
							float num24 = (color52.b = b6);
							Color color54 = (petElements.color = color52);
							petElemFunc(arg0: false);
						}
					}
					if ((bool)petStatus)
					{
						petStatus.enabled = false;
						if (respMainWep != null)
						{
							float num11 = DamageCalc.TotalPoppetPlayerAttackRevise(new RespPoppet[1] { respPet }, respMainWep);
							float num12 = DamageCalc.TotalPoppetPlayerHpRevise(new RespPoppet[1] { respPet }, respMainWep);
							petStatus.enabled = true;
							petAtkHp.Set(num11, num12, petStatus);
						}
					}
				}
				return new int[2] { num, num2 };
			}
		}
	}

	[Serializable]
	public class SupportPoppetInfo
	{
		public IconCreatorEx mainIcon;

		protected MuppetInfo main;

		public UILabelBase mainStatus;

		public UISprite petElements1;

		public UISprite petElements2;

		public AtkHpLabel petAtkHp;

		public SupportPoppetInfo()
		{
			petAtkHp = new AtkHpLabel();
		}

		public void Update(float alpha, bool atkFlag)
		{
			petAtkHp.Update(alpha, atkFlag);
		}

		public int[] SetPoppet(RespWeapon[] respWep, RespPoppet respPet, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[] elemFuncs)
		{
			main = mainIcon.MuppetInfo;
			if (respPet != null && (bool)main)
			{
				main.SetMuppet(respPet);
			}
			if ((bool)petElements1)
			{
				petElements1.enabled = false;
			}
			if ((bool)petElements2)
			{
				petElements2.enabled = false;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			checked
			{
				if (respWep != null && respWep.Length >= 2)
				{
					if ((bool)petElements1)
					{
						petElements1.enabled = true;
						petElements1.spriteName = UIBasicUtility.GetElementSpriteName(respPet.ElementId);
						if (respWep[0] != null && respWep[0].ElementId == respPet.ElementId)
						{
							float r = 1f;
							Color color = petElements1.color;
							float num5 = (color.r = r);
							Color color3 = (petElements1.color = color);
							float g = 1f;
							Color color4 = petElements1.color;
							float num6 = (color4.g = g);
							Color color6 = (petElements1.color = color4);
							float b = 1f;
							Color color7 = petElements1.color;
							float num7 = (color7.b = b);
							Color color9 = (petElements1.color = color7);
							num++;
							elemFuncs[0](arg0: true);
						}
						else
						{
							float r2 = 0.5f;
							Color color10 = petElements1.color;
							float num8 = (color10.r = r2);
							Color color12 = (petElements1.color = color10);
							float g2 = 0.5f;
							Color color13 = petElements1.color;
							float num9 = (color13.g = g2);
							Color color15 = (petElements1.color = color13);
							float b2 = 0.5f;
							Color color16 = petElements1.color;
							float num10 = (color16.b = b2);
							Color color18 = (petElements1.color = color16);
							elemFuncs[0](arg0: false);
						}
					}
					if ((bool)petElements2)
					{
						petElements2.enabled = true;
						petElements2.spriteName = UIBasicUtility.GetElementSpriteName(respPet.ElementId);
						if (respWep[1] != null && respWep[1].ElementId == respPet.ElementId)
						{
							float r3 = 1f;
							Color color19 = petElements2.color;
							float num11 = (color19.r = r3);
							Color color21 = (petElements2.color = color19);
							float g3 = 1f;
							Color color22 = petElements2.color;
							float num12 = (color22.g = g3);
							Color color24 = (petElements2.color = color22);
							float b3 = 1f;
							Color color25 = petElements2.color;
							float num13 = (color25.b = b3);
							Color color27 = (petElements2.color = color25);
							num2++;
							elemFuncs[1](arg0: true);
						}
						else
						{
							float r4 = 0.5f;
							Color color28 = petElements2.color;
							float num14 = (color28.r = r4);
							Color color30 = (petElements2.color = color28);
							float g4 = 0.5f;
							Color color31 = petElements2.color;
							float num15 = (color31.g = g4);
							Color color33 = (petElements2.color = color31);
							float b4 = 0.5f;
							Color color34 = petElements2.color;
							float num16 = (color34.b = b4);
							Color color36 = (petElements2.color = color34);
							elemFuncs[1](arg0: false);
						}
					}
				}
				if ((bool)mainStatus)
				{
					mainStatus.enabled = false;
					if (respPet != null && respWep != null && respWep.Length >= 2)
					{
						float num17 = DamageCalc.TotalPoppetPlayerAttackRevise(new RespPoppet[1] { respPet }, respWep[0]);
						float num18 = DamageCalc.TotalPoppetPlayerAttackRevise(new RespPoppet[1] { respPet }, respWep[1]);
						num3 = (int)(num17 + num18);
						float num19 = DamageCalc.TotalPoppetPlayerHpRevise(new RespPoppet[1] { respPet }, respWep[0]);
						float num20 = DamageCalc.TotalPoppetPlayerHpRevise(new RespPoppet[1] { respPet }, respWep[1]);
						num4 = (int)(num19 + num20);
						mainStatus.enabled = true;
						petAtkHp.Set(num3, num4, mainStatus);
					}
				}
				return new int[2] { num, num2 };
			}
		}
	}

	protected float alpha;

	protected bool flagAtk;

	protected float wait;

	protected float delta;

	protected int linkAngelCount;

	protected int linkDevilCount;

	public UILabelBase atkLabel;

	public UILabelBase hpLabel;

	public SupportWeaponInfo AngelInfo;

	public SupportWeaponInfo DevilInfo;

	public SupportPoppetInfo popetInfo;

	public GameObject targetGameObject;

	public string targetGameObjectFunc;

	protected WeaponEquipments weaponEquipments;

	protected PoppetEquipments poppetEquipments;

	protected UserConfigData.DeckTypes deckType;

	protected int deckIndex;

	public MyHomeEquipMain.SupportButtonIconPanel supportButtonPanel;

	public GameObject magicCirclePrefab;

	public EquipSupportMagicCircle magicCircle;

	public UISprite deckBgWindow;

	public WeaponEquipments Weapon
	{
		get
		{
			return weaponEquipments;
		}
		set
		{
			weaponEquipments = value;
		}
	}

	public PoppetEquipments Poppet
	{
		get
		{
			return poppetEquipments;
		}
		set
		{
			poppetEquipments = value;
		}
	}

	public UserConfigData.DeckTypes DeckType
	{
		get
		{
			return deckType;
		}
		set
		{
			deckType = value;
		}
	}

	public int DeckIndex
	{
		get
		{
			return deckIndex;
		}
		set
		{
			deckIndex = value;
		}
	}

	public SupportEquipInfo()
	{
		targetGameObjectFunc = "MessageFromSuppotEquip";
	}

	public void Awake()
	{
		if (!magicCircle)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(magicCirclePrefab);
			gameObject.transform.parent = this.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			magicCircle = gameObject.GetComponent<EquipSupportMagicCircle>();
		}
	}

	public void Start()
	{
		if (!targetGameObject)
		{
			UIMain uIMain = (UIMain)UnityEngine.Object.FindObjectOfType(typeof(UIMain));
			if ((bool)uIMain)
			{
				targetGameObject = uIMain.gameObject;
			}
		}
	}

	public void Init(int deckIndex, UserConfigData.DeckTypes deckType, WeaponEquipments wep, PoppetEquipments pet)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (!current.IsValidDeck2)
		{
			wep = WeaponEquipments.FromUserData();
			pet = PoppetEquipments.FromUserData();
		}
		if ((bool)deckBgWindow)
		{
			float a = deckBgWindow.color.a;
			UISprite uISprite = deckBgWindow;
			Color[] deckColors = MyHomeEquipMain.DeckColors;
			uISprite.color = deckColors[RuntimeServices.NormalizeArrayIndex(deckColors, deckIndex)];
			float a2 = a;
			Color color = deckBgWindow.color;
			float num = (color.a = a2);
			Color color3 = (deckBgWindow.color = color);
		}
		supportButtonPanel.SwitchButton((int)deckType);
		DeckIndex = deckIndex;
		DeckType = deckType;
		Weapon = wep;
		Poppet = pet;
		int num2 = 0;
		int num3 = 0;
		checked
		{
			if (wep != null && pet != null)
			{
				int[] array = AngelInfo.SetWeapons(wep.MainTenshiWeapon, wep.SubTenshiWeapons, wep.SubTenshiPoppets[0], new __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[3] { AngelSub1WeaponElement, AngelSub2WeaponElement, AngelSub3WeaponElement }, new __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[3] { AngelSub1WeaponStyle, AngelSub2WeaponStyle, AngelSub3WeaponStyle }, AngelPoppetElement);
				int[] array2 = DevilInfo.SetWeapons(wep.MainAkumaWeapon, wep.SubAkumaWeapons, wep.SubAkumaPoppets[0], new __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[3] { DevilSub1WeaponElement, DevilSub2WeaponElement, DevilSub3WeaponElement }, new __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[3] { DevilSub1WeaponStyle, DevilSub2WeaponStyle, DevilSub3WeaponStyle }, DevilPoppetElement);
				int[] array3 = popetInfo.SetPoppet(new RespWeapon[2] { wep.MainTenshiWeapon, wep.MainAkumaWeapon }, pet.MainPoppet, new __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__[2] { PoppetAngelElement, PoppetDevilElement });
				num2 = (int)DamageCalc.TotalPlayerAttack(wep, new RespPoppet[1] { pet.MainPoppet });
				num3 = (int)DamageCalc.TotalPlayerHP(wep, new RespPoppet[1] { pet.MainPoppet });
			}
			if ((bool)atkLabel)
			{
				atkLabel.text = num2.ToString("#,0");
			}
			if ((bool)hpLabel)
			{
				hpLabel.text = num3.ToString("#,0");
			}
		}
	}

	public void Update()
	{
		if (!(wait < 0f))
		{
			wait -= Time.deltaTime;
		}
		if (!(wait > 0f))
		{
			delta += Time.deltaTime;
			alpha = Mathf.Cos(delta) * 5f;
			if (!(alpha >= 0f))
			{
				alpha = 0f - alpha;
				flagAtk = false;
			}
			else
			{
				flagAtk = true;
			}
			if (!(alpha <= 1f))
			{
				alpha = 1f;
			}
		}
		AngelInfo.Update(alpha, flagAtk);
		DevilInfo.Update(alpha, flagAtk);
		popetInfo.Update(alpha, flagAtk);
	}

	public void PushIconAngelMain(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AngelMain", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconAngelSub1(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AngelSub1", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconAngelSub2(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AngelSub2", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconAngelSub3(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AngelSub3", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconAngelPet(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AngelPet", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconDevilMain(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "DevilMain", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconDevilSub1(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "DevilSub1", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconDevilSub2(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "DevilSub2", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconDevilSub3(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "DevilSub3", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconDevilPet(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "DevilPet", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushIconPetMain(GameObject gameObjce)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "PetMain", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushDecide(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "Decide", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushDeckChange(GameObject gameObject)
	{
		if (supportButtonPanel != null)
		{
			supportButtonPanel.SwitchButton((int)deckType);
		}
	}

	public void PushATK(GameObject gameObject)
	{
		wait = 5f;
		flagAtk = true;
		alpha = 1f;
		delta = 0f;
	}

	public void PushHP(GameObject gameObject)
	{
		wait = 5f;
		flagAtk = false;
		alpha = 1f;
		delta = 1f;
	}

	public void PushAtkMax(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "AtkMax", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushHpMax(GameObject gameObject)
	{
		if ((bool)targetGameObject)
		{
			targetGameObject.SendMessage(targetGameObjectFunc, "HpMax", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void PushCustom(GameObject gameObject)
	{
		deckType = UserConfigData.DeckTypes.Custom;
		supportButtonPanel.SwitchButton((int)deckType);
	}

	public void PushMaxEquip(GameObject gameObject)
	{
		if (deckType == UserConfigData.DeckTypes.Atk)
		{
			PushHpMax(null);
		}
		else
		{
			PushAtkMax(null);
		}
	}

	public void AngelSub1WeaponStyle(bool flag)
	{
		magicCircle.AngelSub1WeaponStyle = flag;
	}

	public void AngelSub2WeaponStyle(bool flag)
	{
		magicCircle.AngelSub2WeaponStyle = flag;
	}

	public void AngelSub3WeaponStyle(bool flag)
	{
		magicCircle.AngelSub3WeaponStyle = flag;
	}

	public void AngelSub1WeaponElement(bool flag)
	{
		magicCircle.AngelSub1WeaponElement = flag;
	}

	public void AngelSub2WeaponElement(bool flag)
	{
		magicCircle.AngelSub2WeaponElement = flag;
	}

	public void AngelSub3WeaponElement(bool flag)
	{
		magicCircle.AngelSub3WeaponElement = flag;
	}

	public void AngelPoppetElement(bool flag)
	{
		magicCircle.AngelPoppetElement = flag;
	}

	public void DevilSub1WeaponStyle(bool flag)
	{
		magicCircle.DevilSub1WeaponStyle = flag;
	}

	public void DevilSub2WeaponStyle(bool flag)
	{
		magicCircle.DevilSub2WeaponStyle = flag;
	}

	public void DevilSub3WeaponStyle(bool flag)
	{
		magicCircle.DevilSub3WeaponStyle = flag;
	}

	public void DevilSub1WeaponElement(bool flag)
	{
		magicCircle.DevilSub1WeaponElement = flag;
	}

	public void DevilSub2WeaponElement(bool flag)
	{
		magicCircle.DevilSub2WeaponElement = flag;
	}

	public void DevilSub3WeaponElement(bool flag)
	{
		magicCircle.DevilSub3WeaponElement = flag;
	}

	public void DevilPoppetElement(bool flag)
	{
		magicCircle.DevilPoppetElement = flag;
	}

	public void PoppetAngelElement(bool flag)
	{
		magicCircle.PoppetAngelElement = flag;
	}

	public void PoppetDevilElement(bool flag)
	{
		magicCircle.PoppetDevilElement = flag;
	}
}
