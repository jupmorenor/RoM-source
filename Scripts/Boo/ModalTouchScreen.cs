using System;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ModalTouchScreen : MonoBehaviour
{
	public ICallable touchFunc;

	public void Start()
	{
	}

	public void Update()
	{
	}

	public static ModalTouchScreen Init(Transform parent, ICallable func)
	{
		GameObject gameObject = new GameObject();
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		gameObject.transform.localScale = Vector3.one;
		gameObject.name = "__ModalTouchScreen__";
		gameObject.layer = LayerMask.NameToLayer("2DUI");
		ModalTouchScreen modalTouchScreen = ExtensionsModule.SetComponent<ModalTouchScreen>(gameObject);
		modalTouchScreen.touchFunc = func;
		BoxCollider boxCollider = ExtensionsModule.SetComponent<BoxCollider>(gameObject);
		boxCollider.size = new Vector3(10000f, 10000f, 1f);
		boxCollider.isTrigger = true;
		UIButtonMessage uIButtonMessage = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
		uIButtonMessage.target = gameObject;
		uIButtonMessage.functionName = "TouchScreen";
		return modalTouchScreen;
	}

	public void TouchScreen(object obj)
	{
		if (touchFunc != null)
		{
			touchFunc.Call(new object[1] { obj });
		}
	}
}
