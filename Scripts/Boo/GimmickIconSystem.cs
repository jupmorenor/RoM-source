using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using ObjUtil;
using UnityEngine;

[Serializable]
public class GimmickIconSystem : MonoBehaviour
{
	[Serializable]
	public class IconEntry
	{
		public bool enableCondtion;

		public GimmickIcon icon;

		public GameObject target;

		public __IconEntry_showCondition_0024callable95_002428_33__ showCondition;

		public GimmickIconTypes type;

		public bool HasIcon => icon != null;

		public IconEntry()
		{
			enableCondtion = true;
		}

		public void show()
		{
			if (!(icon == null))
			{
				icon.show();
				enableCondtion = true;
			}
		}

		public void hide()
		{
			if (!(icon == null))
			{
				icon.hide();
				enableCondtion = false;
			}
		}

		public void enableShowCondition()
		{
			enableCondtion = true;
		}

		public void showByCondition()
		{
			if (!(icon == null) && showCondition != null && enableCondtion)
			{
				if (showCondition(target))
				{
					icon.show();
				}
				else
				{
					icon.hide();
				}
			}
		}

		public void destroy()
		{
			enableCondtion = false;
			if ((bool)icon)
			{
				icon.destroy();
			}
		}
	}

	[NonSerialized]
	protected static GimmickIconSystem _instance;

	public GimmickIconTypes DefaultType;

	[EnumArrayEdit(typeof(GimmickIconTypes), "吹き出しリスト")]
	public Transform[] InstantiateRootList;

	private Dictionary<string, IconEntry> icons;

	public static GimmickIconSystem Instance => _instance;

	public GimmickIconSystem()
	{
		DefaultType = GimmickIconTypes.TALK;
		icons = new Dictionary<string, IconEntry>();
	}

	private IconEntry getIconEntry(GameObject obj)
	{
		if (!(obj != null))
		{
			throw new AssertionFailedException("obj != null");
		}
		string myID = ExtensionsModule.GetMyID(obj);
		IconEntry result;
		if (icons.ContainsKey(myID))
		{
			result = icons[myID];
		}
		else
		{
			IconEntry iconEntry = new IconEntry();
			iconEntry.target = obj;
			icons[myID] = iconEntry;
			result = iconEntry;
		}
		return result;
	}

	private void removeIconEntry(GameObject obj)
	{
		if (!(obj == null))
		{
			removeIconEntry(ExtensionsModule.GetMyID(obj));
		}
	}

	private void removeIconEntry(string key)
	{
		if (!string.IsNullOrEmpty(key) && icons.ContainsKey(key))
		{
			IconEntry iconEntry = icons[key];
			icons.Remove(key);
			iconEntry?.destroy();
		}
	}

	public static GimmickIconSystem Create()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(GameAssetModule.LoadPrefab("Prefab/GUI/GimmickRaceIcon")) as GameObject;
		return gameObject ? gameObject.GetComponent<GimmickIconSystem>() : null;
	}

	public void Awake()
	{
		if (!_instance)
		{
			_instance = this;
		}
		int i = 0;
		Transform[] instantiateRootList = InstantiateRootList;
		for (int length = instantiateRootList.Length; i < length; i = checked(i + 1))
		{
			if (instantiateRootList[i] != null)
			{
				instantiateRootList[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void OnDestroy()
	{
		disableAll();
		if (this == _instance)
		{
			_instance = null;
		}
	}

	public void Update()
	{
		foreach (IconEntry value in icons.Values)
		{
			value.showByCondition();
		}
	}

	public GimmickIcon show(Component pointObj, GimmickIconTypes iconType)
	{
		return _show(pointObj.gameObject, 0f, iconType);
	}

	public GimmickIcon show(GameObject pointObj, GimmickIconTypes iconType)
	{
		return _show(pointObj, 0f, iconType);
	}

	private GimmickIcon _show(GameObject pointObj, float leastShowTime, GimmickIconTypes iconType)
	{
		GimmickIcon gimmickIcon = getIcon(pointObj, leastShowTime, iconType);
		if (gimmickIcon != null)
		{
			gimmickIcon.show();
		}
		return gimmickIcon;
	}

	public void setShowCondition(GameObject tobj, __IconEntry_showCondition_0024callable95_002428_33__ pred)
	{
		if (!(tobj == null))
		{
			IconEntry iconEntry = getIconEntry(tobj);
			if (iconEntry == null)
			{
				throw new AssertionFailedException("entry != null");
			}
			iconEntry.showCondition = pred;
			iconEntry.enableShowCondition();
		}
	}

	public void enableShowCondition(GameObject tobj)
	{
		if (!(tobj == null))
		{
			IconEntry iconEntry = getIconEntry(tobj);
			if (iconEntry == null)
			{
				throw new AssertionFailedException("entry != null");
			}
			iconEntry.enableShowCondition();
		}
	}

	public GimmickIcon getIcon(GameObject pointObj)
	{
		return _getIcon(pointObj, 0f, GimmickIconTypes.__NONE__);
	}

	public GimmickIcon getIcon(GameObject pointObj, GimmickIconTypes iconType)
	{
		return _getIcon(pointObj, 0f, iconType);
	}

	public GimmickIcon getIcon(GameObject pointObj, float leastShowTime, GimmickIconTypes iconType)
	{
		return _getIcon(pointObj, leastShowTime, iconType);
	}

	private GimmickIcon _getIcon(GameObject pointObj, float leastShowTime, GimmickIconTypes iconType)
	{
		object result;
		if (pointObj == null)
		{
			result = null;
		}
		else
		{
			GimmickIcon gimmickIcon = null;
			IconEntry iconEntry = getIconEntry(pointObj);
			if (iconEntry.HasIcon)
			{
				if (iconEntry.type == iconType)
				{
					result = iconEntry.icon;
					goto IL_0088;
				}
				iconEntry.icon.destroyMe();
			}
			gimmickIcon = duplicateIcon(iconType);
			if ((bool)gimmickIcon)
			{
				iconEntry.icon = gimmickIcon;
				iconEntry.type = iconType;
				gimmickIcon.Target = pointObj;
				gimmickIcon.LeastShowTime = leastShowTime;
				gimmickIcon.Offset3D = new Vector3(0f, 2f);
			}
			result = gimmickIcon;
		}
		goto IL_0088;
		IL_0088:
		return (GimmickIcon)result;
	}

	public void hide(Component pointObj)
	{
		if (!(pointObj == null))
		{
			_hide(pointObj.gameObject);
		}
	}

	public void hide(GameObject pointObj)
	{
		if (!(pointObj == null))
		{
			_hide(pointObj);
		}
	}

	private void _hide(GameObject pointObj)
	{
		if (!(pointObj == null))
		{
			getIconEntry(pointObj)?.hide();
		}
	}

	public void disable(Component pointObj)
	{
		if (!(pointObj == null))
		{
			_disable(pointObj.gameObject);
		}
	}

	public void disable(GameObject pointObj)
	{
		if (!(pointObj == null))
		{
			_disable(pointObj);
		}
	}

	private void _disable(GameObject pointObj)
	{
		if (!(pointObj == null))
		{
			removeIconEntry(pointObj);
		}
	}

	public void hideAll()
	{
		foreach (IconEntry value in icons.Values)
		{
			value.hide();
		}
	}

	public void disableAll()
	{
		foreach (string key in icons.Keys)
		{
			icons[key]?.destroy();
		}
		icons.Clear();
	}

	public GimmickIcon icon(Component pointObj)
	{
		return (!(pointObj == null)) ? _icon(pointObj.gameObject) : (null as GimmickIcon);
	}

	public GimmickIcon icon(GameObject pointObj)
	{
		return _icon(pointObj);
	}

	private GimmickIcon _icon(GameObject pointObj)
	{
		return getIconEntry(pointObj)?.icon;
	}

	private GimmickIcon duplicateIcon(GimmickIconTypes iconType)
	{
		Transform transform = null;
		if (GimmickIconTypes.ANGEL <= iconType && iconType < GimmickIconTypes.__MAX__)
		{
			Transform[] instantiateRootList = InstantiateRootList;
			transform = instantiateRootList[RuntimeServices.NormalizeArrayIndex(instantiateRootList, (int)iconType)];
		}
		object result;
		if (!transform)
		{
			result = null;
		}
		else
		{
			GimmickIcon gimmickIcon = ObjUtilModule.CloneObject<GimmickIcon>(transform);
			gimmickIcon.gameObject.SetActive(value: true);
			gimmickIcon.transform.parent = transform.parent;
			gimmickIcon.Init();
			Transform transform2 = gimmickIcon.transform;
			transform2.localPosition = transform.localPosition;
			transform2.localRotation = transform.localRotation;
			transform2.localScale = transform.localScale;
			result = gimmickIcon;
		}
		return (GimmickIcon)result;
	}
}
