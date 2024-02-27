using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class CreatePetNameWindow : MonoBehaviour
{
	public string defaultName;

	public GameObject inputAreaPrefab;

	public Transform inputAreaParent;

	private UILabelBase petNameLabel;

	private bool isEnd;

	public string petName
	{
		get
		{
			if (!(petNameLabel != null))
			{
				throw new AssertionFailedException("userNameLabel がアタッチされていません！");
			}
			return petNameLabel.text;
		}
	}

	public bool IsEnd => isEnd;

	public void Start()
	{
		isEnd = false;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(inputAreaPrefab);
		gameObject.transform.parent = inputAreaParent;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		UIInput component = gameObject.GetComponent<UIInput>();
		petNameLabel = component.label;
		petNameLabel.text = defaultName;
	}

	public void PushDecide()
	{
		if (!string.IsNullOrEmpty(petName))
		{
			ApiUpdatePoppetName apiUpdatePoppetName = new ApiUpdatePoppetName();
			apiUpdatePoppetName.PoppetName = petName;
			MerlinServer.Request(apiUpdatePoppetName, _0024adaptor_0024__CreatePetNameWindow_0024callable362_002437_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024184.Adapt(delegate
			{
				UserData.Current.userMiscInfo.flagData.set("s01Main02", 1);
				isEnd = true;
			}));
		}
	}

	internal void _0024PushDecide_0024closure_00245031(ApiUpdatePoppetName res)
	{
		UserData.Current.userMiscInfo.flagData.set("s01Main02", 1);
		isEnd = true;
	}
}
