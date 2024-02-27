using System;
using UnityEngine;

[Serializable]
public class EquipSupportMagicCircle : MonoBehaviour
{
	[Serializable]
	public class Parts
	{
		[Serializable]
		public enum Match
		{
			None,
			One,
			Both
		}

		public Match state;

		protected Match lastState;

		protected bool setflag;

		protected bool element;

		protected bool style;

		public GameObject[] dispPartsByNone;

		public GameObject[] dispPartsByOne;

		public GameObject[] dispPartsByBoth;

		public bool Element
		{
			get
			{
				return element;
			}
			set
			{
				element = value;
				setflag = true;
			}
		}

		public bool Style
		{
			get
			{
				return style;
			}
			set
			{
				style = value;
				setflag = true;
			}
		}

		public bool Element1
		{
			get
			{
				return element;
			}
			set
			{
				element = value;
				setflag = true;
			}
		}

		public bool Element2
		{
			get
			{
				return style;
			}
			set
			{
				style = value;
				setflag = true;
			}
		}

		public Parts()
		{
			state = Match.None;
			lastState = Match.None;
		}

		public void Start()
		{
			lastState = Match.None;
			int i = 0;
			GameObject[] array = dispPartsByNone;
			checked
			{
				for (int length = array.Length; i < length; i++)
				{
					if ((bool)array[i])
					{
						array[i].SetActive(value: true);
					}
				}
				int j = 0;
				GameObject[] array2 = dispPartsByOne;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if ((bool)array2[j])
					{
						array2[j].SetActive(value: false);
					}
				}
				int k = 0;
				GameObject[] array3 = dispPartsByBoth;
				for (int length3 = array3.Length; k < length3; k++)
				{
					if ((bool)array3[k])
					{
						array3[k].SetActive(value: false);
					}
				}
			}
		}

		public void Update()
		{
			if (setflag)
			{
				if (element && style)
				{
					state = Match.Both;
				}
				else if (!element && !style)
				{
					state = Match.None;
				}
				else
				{
					state = Match.One;
				}
			}
			if (lastState == state)
			{
				return;
			}
			lastState = state;
			checked
			{
				if (dispPartsByNone != null)
				{
					int i = 0;
					GameObject[] array = dispPartsByNone;
					for (int length = array.Length; i < length; i++)
					{
						if ((bool)array[i])
						{
							array[i].SetActive(state == Match.None);
						}
					}
				}
				if (dispPartsByOne != null)
				{
					int j = 0;
					GameObject[] array2 = dispPartsByOne;
					for (int length2 = array2.Length; j < length2; j++)
					{
						if ((bool)array2[j])
						{
							array2[j].SetActive(state == Match.One);
						}
					}
				}
				if (dispPartsByBoth == null)
				{
					return;
				}
				int k = 0;
				GameObject[] array3 = dispPartsByBoth;
				for (int length3 = array3.Length; k < length3; k++)
				{
					if ((bool)array3[k])
					{
						array3[k].SetActive(state == Match.Both);
					}
				}
			}
		}
	}

	[Serializable]
	public class Race
	{
		public Parts weapon;

		public Parts sub1Weapon;

		public Parts sub2Weapon;

		public Parts sub3Weapon;

		public Parts poppet;

		public void Start()
		{
			weapon.Start();
			sub1Weapon.Start();
			sub2Weapon.Start();
			sub3Weapon.Start();
			poppet.Start();
		}

		public void Update()
		{
			weapon.Update();
			sub1Weapon.Update();
			sub2Weapon.Update();
			sub3Weapon.Update();
			poppet.Update();
		}
	}

	public Race angel;

	public Race devil;

	public Parts poppet;

	public bool AngelSub1WeaponStyle
	{
		get
		{
			return angel.sub1Weapon.Style;
		}
		set
		{
			angel.sub1Weapon.Style = value;
		}
	}

	public bool AngelSub2WeaponStyle
	{
		get
		{
			return angel.sub2Weapon.Style;
		}
		set
		{
			angel.sub2Weapon.Style = value;
		}
	}

	public bool AngelSub3WeaponStyle
	{
		get
		{
			return angel.sub3Weapon.Style;
		}
		set
		{
			angel.sub3Weapon.Style = value;
		}
	}

	public bool AngelSub1WeaponElement
	{
		get
		{
			return angel.sub1Weapon.Element;
		}
		set
		{
			angel.sub1Weapon.Element = value;
		}
	}

	public bool AngelSub2WeaponElement
	{
		get
		{
			return angel.sub2Weapon.Element;
		}
		set
		{
			angel.sub2Weapon.Element = value;
		}
	}

	public bool AngelSub3WeaponElement
	{
		get
		{
			return angel.sub3Weapon.Element;
		}
		set
		{
			angel.sub3Weapon.Element = value;
		}
	}

	public bool AngelPoppetElement
	{
		get
		{
			return angel.poppet.Element;
		}
		set
		{
			angel.poppet.Element = value;
		}
	}

	public bool DevilSub1WeaponStyle
	{
		get
		{
			return devil.sub1Weapon.Style;
		}
		set
		{
			devil.sub1Weapon.Style = value;
		}
	}

	public bool DevilSub2WeaponStyle
	{
		get
		{
			return devil.sub2Weapon.Style;
		}
		set
		{
			devil.sub2Weapon.Style = value;
		}
	}

	public bool DevilSub3WeaponStyle
	{
		get
		{
			return devil.sub3Weapon.Style;
		}
		set
		{
			devil.sub3Weapon.Style = value;
		}
	}

	public bool DevilSub1WeaponElement
	{
		get
		{
			return devil.sub1Weapon.Element;
		}
		set
		{
			devil.sub1Weapon.Element = value;
		}
	}

	public bool DevilSub2WeaponElement
	{
		get
		{
			return devil.sub2Weapon.Element;
		}
		set
		{
			devil.sub2Weapon.Element = value;
		}
	}

	public bool DevilSub3WeaponElement
	{
		get
		{
			return devil.sub3Weapon.Element;
		}
		set
		{
			devil.sub3Weapon.Element = value;
		}
	}

	public bool DevilPoppetElement
	{
		get
		{
			return devil.poppet.Element;
		}
		set
		{
			devil.poppet.Element = value;
		}
	}

	public bool PoppetAngelElement
	{
		get
		{
			return poppet.Element1;
		}
		set
		{
			poppet.Element1 = value;
		}
	}

	public bool PoppetDevilElement
	{
		get
		{
			return poppet.Element2;
		}
		set
		{
			poppet.Element2 = value;
		}
	}

	public void Start()
	{
		angel.Start();
		devil.Start();
		poppet.Start();
	}

	public void Update()
	{
		angel.Update();
		devil.Update();
		poppet.Update();
	}
}
