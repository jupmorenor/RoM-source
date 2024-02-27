using System;
using UnityEngine;

[Serializable]
public class StorageHUD : MonoBehaviour
{
	[NonSerialized]
	private static StorageHUD instance;

	public bool doUpdateNow;

	public UIAutoTweener tweener;

	public UILabelBase countLabel;

	public UILabelBase wepCountLabel;

	public UILabelBase petCountLabel;

	private UserData ud;

	private bool doUpdate => doUpdateNow;

	public StorageHUD()
	{
		doUpdateNow = true;
	}

	public static StorageHUD Instance()
	{
		if (!instance)
		{
			instance = (StorageHUD)UnityEngine.Object.FindObjectOfType(typeof(StorageHUD));
		}
		return instance;
	}

	public static void SetActive(bool a)
	{
		StorageHUD storageHUD = Instance();
		if ((bool)storageHUD)
		{
			storageHUD.gameObject.SetActive(a);
		}
	}

	public static void DoUpdateNow()
	{
		StorageHUD storageHUD = Instance();
		if ((bool)storageHUD)
		{
			storageHUD.doUpdateNow = true;
		}
	}

	private void Start()
	{
		ud = UserData.Current;
		OnEnabled();
	}

	private void OnEnabled()
	{
		doUpdateNow = true;
		Update();
	}

	private void Update()
	{
		if (doUpdate)
		{
			doUpdateNow = false;
			bool nowForward = tweener.nowForward;
			UIBasicUtility.SetLabel(countLabel, ud.BoxCount.ToString() + "/" + ud.BoxCapacity.ToString(), nowForward);
			if (ud.BoxCapacity < ud.BoxCount)
			{
				UIBasicUtility.SetColor(countLabel.gameObject, UIBasicUtility.GetColor(251f, 78f, 146f));
			}
			else
			{
				UIBasicUtility.SetColor(countLabel.gameObject, UIBasicUtility.GetColor(175f, 106f, 14f));
			}
			UIBasicUtility.SetLabel(wepCountLabel, ud.BoxWeaponNum.ToString(), nowForward);
			UIBasicUtility.SetLabel(petCountLabel, ud.BoxPoppetNum.ToString(), nowForward);
		}
	}
}
