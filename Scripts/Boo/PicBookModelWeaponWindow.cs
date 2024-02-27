using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PicBookModelWindow))]
public class PicBookModelWeaponWindow : MonoBehaviour
{
	[Serializable]
	public class WeaponModelParent
	{
		public EnumStyles style;

		public Transform model;

		public Transform altModel;
	}

	[Serializable]
	internal class _0024SetWeaponItem_0024locals_002414532
	{
		internal WeaponModelParent _0024parent;
	}

	[Serializable]
	internal class _0024SetWeaponItem_0024closure_00245088
	{
		internal PicBookModelWeaponWindow _0024this_002415187;

		internal _0024SetWeaponItem_0024locals_002414532 _0024_0024locals_002415188;

		public _0024SetWeaponItem_0024closure_00245088(PicBookModelWeaponWindow _0024this_002415187, _0024SetWeaponItem_0024locals_002414532 _0024_0024locals_002415188)
		{
			this._0024this_002415187 = _0024this_002415187;
			this._0024_0024locals_002415188 = _0024_0024locals_002415188;
		}

		public void Invoke(GameObject model)
		{
			_0024this_002415187.modelWindow.SetModelObject(model, _0024_0024locals_002415188._0024parent.model);
			_0024this_002415187.SetWeaponCenter(model, _0024_0024locals_002415188._0024parent.model);
		}
	}

	[Serializable]
	internal class _0024SetWeaponItem_0024closure_00245089
	{
		internal PicBookModelWeaponWindow _0024this_002415189;

		internal _0024SetWeaponItem_0024locals_002414532 _0024_0024locals_002415190;

		public _0024SetWeaponItem_0024closure_00245089(PicBookModelWeaponWindow _0024this_002415189, _0024SetWeaponItem_0024locals_002414532 _0024_0024locals_002415190)
		{
			this._0024this_002415189 = _0024this_002415189;
			this._0024_0024locals_002415190 = _0024_0024locals_002415190;
		}

		public void Invoke(GameObject model)
		{
			_0024this_002415189.modelWindow.SetModelObject(model, _0024_0024locals_002415190._0024parent.altModel);
			_0024this_002415189.SetWeaponCenter(model, _0024_0024locals_002415190._0024parent.altModel);
		}
	}

	public PicBookModelWindow modelWindow;

	public WeaponModelParent[] modelParents;

	public void Awake()
	{
		if (modelWindow == null)
		{
			modelWindow = GetComponent<PicBookModelWindow>();
		}
	}

	public void SetWeaponItem(PicBookData picBookData)
	{
		_0024SetWeaponItem_0024locals_002414532 _0024SetWeaponItem_0024locals_0024 = new _0024SetWeaponItem_0024locals_002414532();
		MWeapons weapon = picBookData.weapon;
		modelWindow.SetDetail(weapon.Name.msg, weapon.Rare.Icon);
		_0024SetWeaponItem_0024locals_0024._0024parent = GetWeaponParent((EnumStyles)weapon.MStyleId.Id);
		if (_0024SetWeaponItem_0024locals_0024._0024parent == null)
		{
			return;
		}
		string prefabName = weapon.PrefabName;
		string text = string.Empty;
		if (weapon.MStyleId.Id == 3)
		{
			text = "W02_0000_00";
		}
		else
		{
			string text2 = prefabName;
			if (text2.Substring(RuntimeServices.NormalizeStringIndex(text2, -2)) == "_l")
			{
				text = RuntimeServices.Mid(prefabName, 0, -2) + "_r";
			}
		}
		bool flag = !string.IsNullOrEmpty(text);
		RuntimeAssetBundleDB.Instance.instantiatePrefab(prefabName, new _0024SetWeaponItem_0024closure_00245088(this, _0024SetWeaponItem_0024locals_0024).Invoke);
		if (flag)
		{
			RuntimeAssetBundleDB.Instance.instantiatePrefab(text, new _0024SetWeaponItem_0024closure_00245089(this, _0024SetWeaponItem_0024locals_0024).Invoke);
		}
	}

	public WeaponModelParent GetWeaponParent(EnumStyles style)
	{
		int num = 0;
		WeaponModelParent[] array = modelParents;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].style == style)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (WeaponModelParent)result;
	}

	public void SetWeaponCenter(GameObject model, Transform setParent)
	{
		if (!(model == null))
		{
			Transform transform = model.transform;
			Transform transform2 = transform.Find("Bounds");
			if (transform2 != null)
			{
				transform.position += transform.position - transform2.position;
			}
		}
	}
}
