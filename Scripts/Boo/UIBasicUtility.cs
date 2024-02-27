using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class UIBasicUtility
{
	[Serializable]
	public class ButtonSet
	{
		public bool doDebug;

		public UIButtonMessage button;

		public UIValidController validControl;
	}

	[Serializable]
	internal class _0024SetSpriteByIconAtlasPool_0024locals_002414488
	{
		internal UISprite _0024sprite;

		internal bool _0024show;
	}

	[Serializable]
	internal class _0024SetWeaponIconSpriteEx_0024locals_002414489
	{
		internal UISprite _0024sprite;

		internal bool _0024show;
	}

	[Serializable]
	internal class _0024SetPoppetIconSpriteEx_0024locals_002414490
	{
		internal UISprite _0024sprite;

		internal bool _0024show;
	}

	[Serializable]
	internal class _0024SetSpriteByIconAtlasPool_0024closure_00244003
	{
		internal _0024SetSpriteByIconAtlasPool_0024locals_002414488 _0024_0024locals_002415074;

		public _0024SetSpriteByIconAtlasPool_0024closure_00244003(_0024SetSpriteByIconAtlasPool_0024locals_002414488 _0024_0024locals_002415074)
		{
			this._0024_0024locals_002415074 = _0024_0024locals_002415074;
		}

		public void Invoke(UIAtlas atlas)
		{
			GameObject gameObject = _0024_0024locals_002415074._0024sprite.gameObject;
			bool num = _0024_0024locals_002415074._0024show;
			if (num)
			{
				num = atlas != null;
			}
			gameObject.SetActive(num);
		}
	}

	[Serializable]
	internal class _0024SetWeaponIconSpriteEx_0024closure_00244004
	{
		internal _0024SetWeaponIconSpriteEx_0024locals_002414489 _0024_0024locals_002415075;

		public _0024SetWeaponIconSpriteEx_0024closure_00244004(_0024SetWeaponIconSpriteEx_0024locals_002414489 _0024_0024locals_002415075)
		{
			this._0024_0024locals_002415075 = _0024_0024locals_002415075;
		}

		public void Invoke(UIAtlas atlas)
		{
			if (!(_0024_0024locals_002415075._0024sprite == null) && !(_0024_0024locals_002415075._0024sprite.gameObject == null))
			{
				GameObject gameObject = _0024_0024locals_002415075._0024sprite.gameObject;
				bool num = _0024_0024locals_002415075._0024show;
				if (num)
				{
					num = atlas != null;
				}
				gameObject.SetActive(num);
			}
		}
	}

	[Serializable]
	internal class _0024SetPoppetIconSpriteEx_0024closure_00244005
	{
		internal _0024SetPoppetIconSpriteEx_0024locals_002414490 _0024_0024locals_002415076;

		public _0024SetPoppetIconSpriteEx_0024closure_00244005(_0024SetPoppetIconSpriteEx_0024locals_002414490 _0024_0024locals_002415076)
		{
			this._0024_0024locals_002415076 = _0024_0024locals_002415076;
		}

		public void Invoke(UIAtlas atlas)
		{
			if (!(_0024_0024locals_002415076._0024sprite == null) && !(_0024_0024locals_002415076._0024sprite.gameObject == null))
			{
				GameObject gameObject = _0024_0024locals_002415076._0024sprite.gameObject;
				bool num = _0024_0024locals_002415076._0024show;
				if (num)
				{
					num = atlas != null;
				}
				gameObject.SetActive(num);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetPoppetIconTexture_002421491 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024name_002421492;

			internal AssetBundleLoader.Request _0024req_002421493;

			internal UITexture _0024tex_002421494;

			internal RespPoppet _0024pet_002421495;

			internal bool _0024show_002421496;

			public _0024(UITexture tex, RespPoppet pet, bool show)
			{
				_0024tex_002421494 = tex;
				_0024pet_002421495 = pet;
				_0024show_002421496 = show;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024tex_002421494 && _0024pet_002421495 != null)
					{
						_0024name_002421492 = _0024pet_002421495.Icon;
						if (!(_0024tex_002421494.gameObject.name == _0024name_002421492))
						{
							_0024req_002421493 = AssetBundleLoader.ReqBundle("PoppetIcon");
							goto case 2;
						}
					}
					goto case 1;
				case 2:
					if (!_0024req_002421493.ok)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024tex_002421494.mainTexture = _0024req_002421493.load(_0024name_002421492, typeof(Texture)) as Texture;
					_0024tex_002421494.shader = Shader.Find("Unlit/Transparent Colored");
					_0024tex_002421494.gameObject.name = _0024name_002421492;
					_0024tex_002421494.gameObject.SetActive(_0024show_002421496);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UITexture _0024tex_002421497;

		internal RespPoppet _0024pet_002421498;

		internal bool _0024show_002421499;

		public _0024SetPoppetIconTexture_002421491(UITexture tex, RespPoppet pet, bool show)
		{
			_0024tex_002421497 = tex;
			_0024pet_002421498 = pet;
			_0024show_002421499 = show;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024tex_002421497, _0024pet_002421498, _0024show_002421499);
		}
	}

	public static ButtonSet CreateButtonSet(UIButtonMessage btn)
	{
		UIValidController uIValidController = default(UIValidController);
		if (btn != null)
		{
			uIValidController = btn.gameObject.GetComponent<UIValidController>();
			if (uIValidController == null)
			{
				uIValidController = btn.gameObject.AddComponent<UIValidController>();
			}
		}
		ButtonSet buttonSet = new ButtonSet();
		buttonSet.button = btn;
		buttonSet.validControl = uIValidController;
		return buttonSet;
	}

	public static void SetButtonValid(ButtonSet bset, bool e)
	{
		if (bset != null)
		{
			if (bset.button != null)
			{
				bset.button.collider.enabled = e;
			}
			if (bset.validControl != null)
			{
				bset.validControl.isValidColor = e;
			}
			if (!bset.doDebug)
			{
			}
		}
	}

	public static string SafeFormat(string format, params object[] args)
	{
		string empty = string.Empty;
		try
		{
			return string.Format(format, args);
		}
		catch (Exception)
		{
			return format;
		}
	}

	public static void SetLabel(UILabelBase label, string text, bool show)
	{
		if ((bool)label)
		{
			label.gameObject.SetActive(show);
			label.text = text;
		}
	}

	public static void SetLabel(UILabelBase label, string text)
	{
		if ((bool)label)
		{
			label.text = text;
		}
	}

	public static void SetSprite(UISprite sprite, string name, UIAtlas atlas, bool show)
	{
		if ((bool)sprite)
		{
			GameObject gameObject = sprite.gameObject;
			bool num = show;
			if (num)
			{
				num = !string.IsNullOrEmpty(name);
			}
			gameObject.SetActive(num);
			if ((bool)atlas)
			{
				sprite.atlas = atlas;
			}
			sprite.spriteName = name;
		}
	}

	public static void SetSpriteByIconAtlasPool(UISprite sprite, string name, bool show)
	{
		_0024SetSpriteByIconAtlasPool_0024locals_002414488 _0024SetSpriteByIconAtlasPool_0024locals_0024 = new _0024SetSpriteByIconAtlasPool_0024locals_002414488();
		_0024SetSpriteByIconAtlasPool_0024locals_0024._0024sprite = sprite;
		_0024SetSpriteByIconAtlasPool_0024locals_0024._0024show = show;
		if ((bool)_0024SetSpriteByIconAtlasPool_0024locals_0024._0024sprite)
		{
			IconAtlasPool.SetSprite(_0024SetSpriteByIconAtlasPool_0024locals_0024._0024sprite, name, new _0024SetSpriteByIconAtlasPool_0024closure_00244003(_0024SetSpriteByIconAtlasPool_0024locals_0024).Invoke);
		}
	}

	public static void SetGauge(UISlider gauge, float now, float max, bool show)
	{
		if ((bool)gauge)
		{
			gauge.gameObject.SetActive(show);
			float sliderValue = 0f;
			if (max != 0f)
			{
				sliderValue = now / max;
			}
			gauge.sliderValue = sliderValue;
		}
	}

	public static void SetWeaponIconSprite(UISprite sprite, RespWeapon weapon, bool show)
	{
		SetWeaponIconSpriteEx(sprite, weapon, show, igonreUnknown: false);
	}

	public static void SetPoppetIconSprite(UISprite sprite, RespPoppet poppet, bool show)
	{
		SetPoppetIconSpriteEx(sprite, poppet, show, igonreUnknown: false);
	}

	public static void SetWeaponIconSpriteEx(UISprite sprite, RespWeapon weapon, bool show, bool igonreUnknown)
	{
		SetWeaponIconSpriteEx(sprite, weapon, show, igonreUnknown, forceUnknow: false);
	}

	public static void SetWeaponIconSpriteEx(UISprite sprite, RespWeapon weapon, bool show, bool igonreUnknown, bool forceUnknow)
	{
		_0024SetWeaponIconSpriteEx_0024locals_002414489 _0024SetWeaponIconSpriteEx_0024locals_0024 = new _0024SetWeaponIconSpriteEx_0024locals_002414489();
		_0024SetWeaponIconSpriteEx_0024locals_0024._0024sprite = sprite;
		_0024SetWeaponIconSpriteEx_0024locals_0024._0024show = show;
		if (!_0024SetWeaponIconSpriteEx_0024locals_0024._0024sprite || weapon == null)
		{
			return;
		}
		string spriteName = weapon.Icon;
		if (forceUnknow)
		{
			spriteName = "W_none";
		}
		else if (!igonreUnknown)
		{
			UserData current = UserData.Current;
			if (!current.userMiscInfo.weaponBookData.isLook(weapon.Master))
			{
				spriteName = "W_none";
			}
		}
		IconAtlasPool.SetSprite(_0024SetWeaponIconSpriteEx_0024locals_0024._0024sprite, spriteName, new _0024SetWeaponIconSpriteEx_0024closure_00244004(_0024SetWeaponIconSpriteEx_0024locals_0024).Invoke);
	}

	public static void SetPoppetIconSpriteEx(UISprite sprite, RespPoppet poppet, bool show, bool igonreUnknown)
	{
		SetPoppetIconSpriteEx(sprite, poppet, show, igonreUnknown, forceUnknow: false);
	}

	public static void SetPoppetIconSpriteEx(UISprite sprite, RespPoppet poppet, bool show, bool igonreUnknown, bool forceUnknow)
	{
		_0024SetPoppetIconSpriteEx_0024locals_002414490 _0024SetPoppetIconSpriteEx_0024locals_0024 = new _0024SetPoppetIconSpriteEx_0024locals_002414490();
		_0024SetPoppetIconSpriteEx_0024locals_0024._0024sprite = sprite;
		_0024SetPoppetIconSpriteEx_0024locals_0024._0024show = show;
		if (!_0024SetPoppetIconSpriteEx_0024locals_0024._0024sprite || poppet == null)
		{
			return;
		}
		string spriteName = poppet.Icon;
		if (forceUnknow)
		{
			spriteName = "P_none";
		}
		else if (!igonreUnknown)
		{
			UserData current = UserData.Current;
			if (!current.userMiscInfo.poppetBookData.isLook(poppet.Master))
			{
				spriteName = "P_none";
			}
		}
		_0024SetPoppetIconSpriteEx_0024locals_0024._0024sprite.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(_0024SetPoppetIconSpriteEx_0024locals_0024._0024sprite, spriteName, new _0024SetPoppetIconSpriteEx_0024closure_00244005(_0024SetPoppetIconSpriteEx_0024locals_0024).Invoke);
	}

	public static IEnumerator SetPoppetIconTexture(UITexture tex, RespPoppet pet, bool show)
	{
		return new _0024SetPoppetIconTexture_002421491(tex, pet, show).GetEnumerator();
	}

	public static void SetPoppetIconTextureCoroutine(MonoBehaviour behaviour, UITexture tex, RespPoppet pet, bool show)
	{
		if ((bool)tex && pet != null)
		{
			string icon = pet.Icon;
			if (!(tex.gameObject.name == icon))
			{
				behaviour.StartCoroutine(SetPoppetIconTexture(tex, pet, show));
			}
		}
	}

	public static bool IsSpaseOnly(string str, int max)
	{
		int num = 0;
		int num2 = Mathf.Clamp(str.Length, 0, max);
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < num2)
			{
				int index = num;
				num++;
				if (!char.IsWhiteSpace(str, index))
				{
					result = 0;
					break;
				}
				continue;
			}
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static void InitDetailWindow(GameObject go)
	{
		if (!go.activeSelf)
		{
			go.SetActive(value: true);
		}
		DestroyTargetChild(go, "LevelText");
	}

	public static void DestroyTargetChild(GameObject go, string target)
	{
		UnityEngine.Object.Destroy(GetTargetChild(go.transform, target));
	}

	public static GameObject GetTargetChild(Transform trans, string target)
	{
		Transform transform;
		GameObject targetChild;
		if ((bool)trans)
		{
			IEnumerator enumerator = trans.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				transform = (Transform)obj;
				if (transform.name == target)
				{
					goto IL_004e;
				}
				if (!((targetChild = GetTargetChild(transform.transform, target)) != null))
				{
					continue;
				}
				goto IL_0072;
			}
		}
		object result = null;
		goto IL_0084;
		IL_004e:
		result = transform.gameObject;
		goto IL_0084;
		IL_0072:
		result = targetChild;
		goto IL_0084;
		IL_0084:
		return (GameObject)result;
	}

	public static T GetTargetChild<T>(Transform trans, string target) where T : Component
	{
		GameObject targetChild = GetTargetChild(trans, target);
		Component component = null;
		if (targetChild != null)
		{
			component = targetChild.GetComponent<T>();
		}
		return (T)component;
	}

	public static string GetElementSpriteName(int elem)
	{
		MElements mElements = MElements.Get(elem);
		return (mElements == null) ? string.Empty : mElements.MainIcon;
	}

	public static void SetElementSprite(UISprite sprite, int elem, bool light, bool show)
	{
		SetSprite(sprite, GetElementSpriteName(elem), null, show: true);
		if ((bool)sprite)
		{
			SetLight(sprite.gameObject, light);
		}
	}

	public static string GetStyleSpriteName(int style)
	{
		return style switch
		{
			1 => "weapon_sword", 
			2 => "weapon_spear", 
			3 => "weapon_bow", 
			4 => "weapon_hth", 
			5 => "weapon_greatsword", 
			_ => string.Empty, 
		};
	}

	public static void SetStyleSprite(UISprite sprite, int style, bool light, bool show)
	{
		SetSprite(sprite, GetStyleSpriteName(style), null, show);
		if ((bool)sprite)
		{
			SetLight(sprite.gameObject, light);
		}
	}

	public static void SetLight(GameObject go, bool b)
	{
		if ((bool)go)
		{
			TweenColor.Begin(go, 0.0001f, (!b) ? Color.gray : Color.white);
		}
	}

	public static void SetColor(GameObject go, Color c)
	{
		if ((bool)go)
		{
			TweenColor.Begin(go, 0.0001f, c);
		}
	}

	public static void SetLabelColor(UILabelBase label, Color c)
	{
		if ((bool)label)
		{
			SetColor(label.gameObject, c);
			UIValidObject component = label.GetComponent<UIValidObject>();
			if ((bool)component)
			{
				component.validColor = c;
				component.invalidColor = c / 2f;
				component.invalidColor.a = c.a;
			}
		}
	}

	public static Color GetColorInt(int r, int g, int b, int a)
	{
		return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)a / 255f);
	}

	public static Color GetColorInt(int r, int g, int b)
	{
		return GetColorInt(r, g, b, 255);
	}

	public static Color GetColor(float r, float g, float b, float a)
	{
		return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
	}

	public static Color GetColor(float r, float g, float b)
	{
		return GetColor(r, g, b, 255f);
	}

	public static string GetUseItemString(bool use, bool weapon)
	{
		return (!use) ? string.Empty : ((!weapon) ? MTexts.Get("exp_using").msg : MTexts.Get("exp_equiping").msg);
	}

	public static string GetMainSupportString(WeaponEquipments wepEq, PoppetEquipments petEq, BoxId id, bool equipOnly, bool ignoreSupport, bool ignoreRace)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (!current.IsValidDeck2)
		{
			goto IL_0698;
		}
		string result;
		if (RuntimeServices.EqualityOperator(id, wepEq.MainTenshiWeapon.Id))
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else if (ignoreRace)
			{
				result = MTexts.Get("exp_main").msg;
			}
			else
			{
				string msg = MTexts.Get("exp_angel").msg;
				string msg2 = MTexts.Get("exp_equiping").msg;
				result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
					.ToString();
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubTenshiWeapons[0].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_angel").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("1")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubTenshiWeapons[1].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_angel").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("2")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubTenshiWeapons[2].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_angel").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("3")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.MainAkumaWeapon.Id))
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else if (ignoreRace)
			{
				result = MTexts.Get("exp_main").msg;
			}
			else
			{
				string msg2 = MTexts.Get("exp_equiping").msg;
				string msg = MTexts.Get("exp_devil").msg;
				result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
					.ToString();
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubAkumaWeapons[0].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_devil").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("1")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubAkumaWeapons[1].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_devil").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("2")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubAkumaWeapons[2].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: true);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_devil").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.Append("3")
						.ToString();
				}
			}
		}
		else if (RuntimeServices.EqualityOperator(id, petEq.MainPoppet.Id))
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: false);
			}
			else if (ignoreRace)
			{
				result = MTexts.Get("exp_main").msg;
			}
			else
			{
				string msg2 = MTexts.Get("exp_using").msg;
				result = new StringBuilder().Append(msg2).ToString();
			}
		}
		else if (RuntimeServices.EqualityOperator(id, wepEq.SubTenshiPoppets[0].Id) && !ignoreSupport)
		{
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: false);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_angel").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.ToString();
				}
			}
		}
		else
		{
			if (!RuntimeServices.EqualityOperator(id, wepEq.SubAkumaPoppets[0].Id) || ignoreSupport)
			{
				goto IL_0698;
			}
			if (equipOnly)
			{
				result = GetUseItemString(use: true, weapon: false);
			}
			else
			{
				string msg2 = MTexts.Get("exp_support").msg;
				if (ignoreRace)
				{
					result = msg2;
				}
				else
				{
					string msg = MTexts.Get("exp_devil").msg;
					result = new StringBuilder().Append(msg).Append("\n").Append(msg2)
						.ToString();
				}
			}
		}
		goto IL_069d;
		IL_069d:
		return result;
		IL_0698:
		result = string.Empty;
		goto IL_069d;
	}

	public static string GetItemNameAddID(MTexts name, int id)
	{
		string text = name.ToString();
		if (GameParameter.showItemMasterId)
		{
			text += new StringBuilder(":").Append((object)id).ToString();
		}
		return text;
	}

	public static string GetBreederRankSpriteName(MBreederRanks rank, bool toLower)
	{
		string text = rank.Progname;
		if (toLower)
		{
			text = rank.Progname.ToLower();
		}
		return SafeFormat("breedrank_{0}", text);
	}

	public static void SetBreederRankSprite(UISprite sprite, RespBreeder breeder)
	{
		SetBreederRankSprite(sprite, breeder.BreederRankId, toLower: false);
	}

	public static void SetBreederRankSprite(UISprite sprite, int breederRankId, bool toLower)
	{
		SetBreederRankSprite(sprite, MBreederRanks.Get(breederRankId), toLower);
	}

	public static void SetBreederRankSprite(UISprite sprite, MBreederRanks rank, bool toLower)
	{
		SetSprite(sprite, GetBreederRankSpriteName(rank, toLower), null, show: true);
	}

	public static void SetPlusBonusLabel(UILabelBase label, int plusBonus, bool useMaxColor)
	{
		string text = SafeFormat("+{0}", plusBonus);
		SetLabel(label, text, 0 < plusBonus);
		Color white = Color.white;
		white = ((!useMaxColor) ? StaticLevelColor.NORMAL : StaticLevelColor.LIMIT_BREAK_MAX);
		SetLabelColor(label, white);
	}

	public static void SetSumPlusBonusLabel(UILabelBase label, JsonBase js)
	{
		if (js != null && label != null)
		{
			RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(js);
			SetPlusBonusLabel(label, respWeaponPoppet.SumPlusBonus, useMaxColor: false);
			Color white = Color.white;
			white = ((respWeaponPoppet.IsAttackPlusBonusMax && respWeaponPoppet.IsHpPlusBonusMax) ? StaticLevelColor.LIMIT_BREAK_MAX : ((!respWeaponPoppet.IsAttackPlusBonusMax && !respWeaponPoppet.IsHpPlusBonusMax) ? StaticLevelColor.NORMAL : StaticLevelColor.LIMIT_BREAK));
			SetLabelColor(label, white);
		}
		else
		{
			SetLabel(label, string.Empty, show: false);
		}
	}
}
