using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class TutorialUI : MonoBehaviour
{
	[Serializable]
	internal class _0024__PutAssetBundleGameObject_0024locals_002414467
	{
		internal int _0024bankId;

		internal string _0024prefabName;

		internal __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _0024callBack;
	}

	[Serializable]
	internal class _0024__PutAssetBundleGameObject_0024closure_00243254
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421226 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal GameObject _0024tmpObj_002421227;

				internal GameObject _0024newObj_002421228;

				internal RuntimeAssetBundleDB _0024abdb_002421229;

				internal RuntimeAssetBundleDB.Req _0024r_002421230;

				internal GameObject _0024obj_002421231;

				internal Vector3 _0024tempPos_002421232;

				internal Vector3 _0024tempScl_002421233;

				internal _0024__PutAssetBundleGameObject_0024closure_00243254 _0024self__002421234;

				public _0024(_0024__PutAssetBundleGameObject_0024closure_00243254 self_)
				{
					_0024self__002421234 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024tmpObj_002421227 = null;
						_0024newObj_002421228 = null;
						try
						{
							_0024abdb_002421229 = RuntimeAssetBundleDB.Instance;
							_0024r_002421230 = _0024abdb_002421229.loadAsset(_0024self__002421234._0024_0024locals_002415027._0024prefabName, typeof(GameObject));
						}
						catch (Exception)
						{
							_0024r_002421230 = null;
							if (_0024self__002421234._0024this_002415028.objectBanks.ContainsKey(_0024self__002421234._0024_0024locals_002415027._0024bankId))
							{
								_0024obj_002421231 = _0024self__002421234._0024this_002415028.objectBanks[_0024self__002421234._0024_0024locals_002415027._0024bankId];
								if (null != _0024obj_002421231)
								{
									UnityEngine.Object.DestroyObject(_0024obj_002421231);
								}
								_0024self__002421234._0024this_002415028.objectBanks.Remove(_0024self__002421234._0024_0024locals_002415027._0024bankId);
							}
						}
						if (_0024r_002421230 != null)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_02eb;
					case 2:
					case 3:
						if (!_0024r_002421230.IsEnd)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (_0024r_002421230.IsOk)
						{
							_0024tmpObj_002421227 = _0024r_002421230.Asset as GameObject;
						}
						if (null != _0024tmpObj_002421227)
						{
							_0024newObj_002421228 = null;
							if (_0024self__002421234._0024this_002415028.objectBanks.ContainsKey(_0024self__002421234._0024_0024locals_002415027._0024bankId))
							{
								_0024obj_002421231 = _0024self__002421234._0024this_002415028.objectBanks[_0024self__002421234._0024_0024locals_002415027._0024bankId];
								if (null != _0024obj_002421231)
								{
									UnityEngine.Object.DestroyObject(_0024obj_002421231);
								}
								_0024self__002421234._0024this_002415028.objectBanks.Remove(_0024self__002421234._0024_0024locals_002415027._0024bankId);
							}
							_0024newObj_002421228 = (GameObject)UnityEngine.Object.Instantiate(_0024tmpObj_002421227);
							if (null != _0024newObj_002421228)
							{
								_0024self__002421234._0024this_002415028.objectBanks[_0024self__002421234._0024_0024locals_002415027._0024bankId] = _0024newObj_002421228;
								_0024tempPos_002421232 = _0024tmpObj_002421227.transform.localPosition;
								_0024tempScl_002421233 = _0024tmpObj_002421227.transform.localScale;
								_0024newObj_002421228.transform.parent = _0024self__002421234._0024this_002415028.transform;
								_0024newObj_002421228.transform.localPosition = _0024tempPos_002421232;
								_0024newObj_002421228.transform.localScale = _0024tempScl_002421233;
								_0024newObj_002421228.SetActive(value: true);
							}
						}
						goto IL_02eb;
					case 1:
						{
							result = 0;
							break;
						}
						IL_02eb:
						if (null != _0024self__002421234._0024_0024locals_002415027._0024callBack)
						{
							_0024self__002421234._0024_0024locals_002415027._0024callBack(_0024newObj_002421228);
						}
						YieldDefault(1);
						goto case 1;
					}
					return (byte)result != 0;
				}
			}

			internal _0024__PutAssetBundleGameObject_0024closure_00243254 _0024self__002421235;

			public _0024Invoke_002421226(_0024__PutAssetBundleGameObject_0024closure_00243254 self_)
			{
				_0024self__002421235 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421235);
			}
		}

		internal _0024__PutAssetBundleGameObject_0024locals_002414467 _0024_0024locals_002415027;

		internal TutorialUI _0024this_002415028;

		public _0024__PutAssetBundleGameObject_0024closure_00243254(_0024__PutAssetBundleGameObject_0024locals_002414467 _0024_0024locals_002415027, TutorialUI _0024this_002415028)
		{
			this._0024_0024locals_002415027 = _0024_0024locals_002415027;
			this._0024this_002415028 = _0024this_002415028;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421226(this).GetEnumerator();
		}
	}

	public TutorialArrow[] arrows;

	public GameObject[] images;

	public Dictionary<int, GameObject> objectBanks;

	[NonSerialized]
	private static Boo.Lang.List<TutorialUI> _InstanceList = new Boo.Lang.List<TutorialUI>();

	public static TutorialUI Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public TutorialUI()
	{
		objectBanks = new Dictionary<int, GameObject>();
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void DisableArrows()
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DisableArrows();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableArrows()
	{
		int i = 0;
		TutorialArrow[] array = arrows;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].enableArrowSprite(b: false);
			}
		}
	}

	public static void DisableArrow(int index)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DisableArrow(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableArrow(int index)
	{
		TutorialArrow arrow = getArrow(index);
		if (arrow != null)
		{
			arrow.enableArrowSprite(b: false);
		}
	}

	public static void PointArrow(int index)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__PointArrow(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __PointArrow(int index)
	{
		PointArrow(index, null, Vector3.zero);
	}

	public static void PointArrow(int index, GameObject widget)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__PointArrow(index, widget);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __PointArrow(int index, GameObject widget)
	{
		PointArrow(index, widget, Vector3.zero);
	}

	public static void PointArrow(int index, GameObject widget, Vector3 offset)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__PointArrow(index, widget, offset);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __PointArrow(int index, GameObject widget, Vector3 offset)
	{
		TutorialArrow arrow = getArrow(index);
		if (arrow != null)
		{
			arrow.target = widget;
			arrow.offset = offset;
			arrow.enableArrowSprite(b: true);
		}
	}

	private TutorialArrow getArrow(int index)
	{
		object result;
		if (index < 0 || index >= arrows.Length)
		{
			result = null;
		}
		else
		{
			TutorialArrow[] array = arrows;
			result = array[RuntimeServices.NormalizeArrayIndex(array, index)];
		}
		return (TutorialArrow)result;
	}

	public static void DrawImage(int index)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DrawImage(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DrawImage(int index)
	{
		if (images == null || images.Length <= 0 || index < 0 || index >= images.Length)
		{
			return;
		}
		GameObject[] array = images;
		if (!(array[RuntimeServices.NormalizeArrayIndex(array, index)] == null))
		{
			GameObject[] array2 = images;
			UIAutoTweener uIAutoTweener = (UIAutoTweener)array2[RuntimeServices.NormalizeArrayIndex(array2, index)].GetComponent(typeof(UIAutoTweener));
			GameObject[] array3 = images;
			array3[RuntimeServices.NormalizeArrayIndex(array3, index)].SetActive(value: true);
			if ((bool)uIAutoTweener)
			{
				GameObject[] array4 = images;
				UIAutoTweenerStandAloneEx.In(array4[RuntimeServices.NormalizeArrayIndex(array4, index)]);
			}
		}
	}

	public static void DisableImages()
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DisableImages();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableImages()
	{
		int i = 0;
		GameObject[] array = images;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				UIAutoTweener uIAutoTweener = (UIAutoTweener)array[i].GetComponent(typeof(UIAutoTweener));
				if ((bool)uIAutoTweener)
				{
					UIAutoTweenerStandAloneEx.Out(array[i]);
				}
				else
				{
					array[i].SetActive(value: false);
				}
			}
		}
	}

	public static void PutAssetBundleGameObject(int bankId, string prefabName, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ callBack)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__PutAssetBundleGameObject(bankId, prefabName, callBack);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __PutAssetBundleGameObject(int bankId, string prefabName, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ callBack)
	{
		_0024__PutAssetBundleGameObject_0024locals_002414467 _0024__PutAssetBundleGameObject_0024locals_0024 = new _0024__PutAssetBundleGameObject_0024locals_002414467();
		_0024__PutAssetBundleGameObject_0024locals_0024._0024bankId = bankId;
		_0024__PutAssetBundleGameObject_0024locals_0024._0024prefabName = prefabName;
		_0024__PutAssetBundleGameObject_0024locals_0024._0024callBack = callBack;
		if (objectBanks == null)
		{
			throw new AssertionFailedException("null != objectBanks");
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024__PutAssetBundleGameObject_0024closure_00243254(_0024__PutAssetBundleGameObject_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public static void DestroyAssetBundleGameObject(int bankId)
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DestroyAssetBundleGameObject(bankId);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DestroyAssetBundleGameObject(int bankId)
	{
		if (objectBanks == null)
		{
			throw new AssertionFailedException("null != objectBanks");
		}
		if (objectBanks.ContainsKey(bankId))
		{
			GameObject gameObject = objectBanks[bankId];
			if (null != gameObject)
			{
				UnityEngine.Object.DestroyObject(gameObject);
				objectBanks.Remove(bankId);
			}
		}
	}

	public static void DestroyAllAssetBundleGameObject()
	{
		IEnumerator<TutorialUI> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TutorialUI current = enumerator.Current;
				current.__DestroyAllAssetBundleGameObject();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DestroyAllAssetBundleGameObject()
	{
		if (objectBanks == null)
		{
			throw new AssertionFailedException("null != objectBanks");
		}
		Dictionary<int, GameObject>.KeyCollection keys = objectBanks.Keys;
		foreach (int item in keys)
		{
			if (objectBanks.ContainsKey(item))
			{
				GameObject gameObject = objectBanks[item];
				if (null != gameObject)
				{
					UnityEngine.Object.DestroyObject(gameObject);
					objectBanks.Remove(item);
				}
			}
		}
	}
}
