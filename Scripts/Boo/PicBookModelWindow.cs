using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PicBookModelWindow : MonoBehaviour
{
	public string modelLayerName;

	private GameObject[] curModels;

	public UILabelBase nameLabel;

	public UISprite iconRankTextSprite;

	public GameObject showModelRoot;

	private PicBookData selectedData;

	public PicBookModelWindow()
	{
		modelLayerName = "Default";
		curModels = new GameObject[0];
	}

	public void SetSelectedData(PicBookData selectData)
	{
		selectedData = selectData;
	}

	public void ShowSelectData(PicBookData data)
	{
		if (data.IsWeapon())
		{
			SendMessage("SetWeaponItem", data);
		}
		else if (data.IsPoppet())
		{
			SendMessage("SetPoppetsItem", data);
		}
		else
		{
			SetNoInfo();
		}
	}

	public void SetNoInfo()
	{
		if (nameLabel != null)
		{
			nameLabel.text = string.Empty;
		}
		if (iconRankTextSprite != null)
		{
			iconRankTextSprite.gameObject.SetActive(value: false);
		}
	}

	public void SetDetail(string modelName, string rareIcon)
	{
		nameLabel.text = modelName;
		if (iconRankTextSprite != null)
		{
			iconRankTextSprite.spriteName = rareIcon + "_text";
		}
		if (iconRankTextSprite != null)
		{
			iconRankTextSprite.gameObject.SetActive(value: true);
		}
	}

	public void SetModelObject(GameObject model, Transform setParent)
	{
		if (model == null)
		{
			return;
		}
		if (!gameObject.activeInHierarchy || setParent == null)
		{
			UnityEngine.Object.Destroy(model);
			return;
		}
		setParent.localScale = Vector3.one;
		Transform transform = model.transform;
		transform.parent = setParent;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
		PicBookContents component = model.GetComponent<PicBookContents>();
		if (component != null)
		{
			model.transform.localScale = component.PicBookDisplayScale;
			model.transform.localPosition = component.PicBookDisplayPosition;
			model.transform.localEulerAngles = component.PicBookDisplayRotation;
		}
		curModels = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), curModels, new GameObject[1] { model });
		NGUITools.SetLayer(model, LayerMask.NameToLayer(modelLayerName));
	}

	public void OnEnable()
	{
		showModelRoot.SetActive(value: true);
		if (selectedData != null)
		{
			SendMessage("ShowSelectData", selectedData);
		}
	}

	public void OnDisable()
	{
		showModelRoot.SetActive(value: false);
		int i = 0;
		GameObject[] array = curModels;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.Destroy(array[i]);
		}
		curModels = new GameObject[0];
	}

	public void OnDestroy()
	{
		curModels = null;
	}

	public void OnApplicationQuit()
	{
		enabled = false;
	}
}
