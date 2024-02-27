using System;
using UnityEngine;

[Serializable]
public class ButtonBackHUD : MonoBehaviour
{
	public UIButtonMessage button;

	public UIAutoTweener tweener;

	private bool isActive;

	[NonSerialized]
	private static ButtonBackHUD m_instance;

	public static ButtonBackHUD Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = (ButtonBackHUD)UnityEngine.Object.FindObjectOfType(typeof(ButtonBackHUD));
				if (m_instance != null)
				{
					m_instance.isActive = m_instance.gameObject.activeInHierarchy;
				}
			}
			return m_instance;
		}
	}

	public static bool IsActive => Instance != null && Instance.isActive;

	public void Awake()
	{
		if (m_instance == null)
		{
			m_instance = this;
		}
	}

	public static UIButtonMessage GetButton()
	{
		return (!(Instance != null)) ? null : Instance.button;
	}

	public static void SetActive(bool setActive)
	{
		if (!(Instance != null))
		{
			return;
		}
		Instance.isActive = setActive;
		if (Instance.tweener != null && Instance.tweener.IsInit)
		{
			if (setActive)
			{
				UIAutoTweenerStandAloneEx.In(Instance.gameObject);
			}
			else
			{
				UIAutoTweenerStandAloneEx.Out(Instance.gameObject);
			}
		}
		else
		{
			Instance.gameObject.SetActive(setActive);
		}
		if (Instance.button != null)
		{
			Instance.button.collider.enabled = setActive;
		}
	}
}
