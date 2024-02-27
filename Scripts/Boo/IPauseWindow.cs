using System;
using UnityEngine;

[Serializable]
public class IPauseWindow : UIMain
{
	[NonSerialized]
	protected static bool isPaused;

	public GameObject closeButtonPrefab;

	private UIButtonMessage closeButton;

	private StartButton m_startButton;

	public StartButton startButton => m_startButton;

	public static bool IsPaused => isPaused;

	public virtual void ReqStart()
	{
	}

	public virtual void ReqExit()
	{
	}

	public virtual bool CanExit()
	{
		return true;
	}

	public StartButton SetStartButton(StartButton btn)
	{
		m_startButton = btn;
		return null;
	}

	public UIButtonMessage GetCloseButton(GameObject col)
	{
		object result;
		if (!closeButtonPrefab)
		{
			result = null;
		}
		else
		{
			if (!closeButton)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(closeButtonPrefab);
				gameObject.transform.parent = this.gameObject.transform;
				float z = col.transform.position.z;
				Vector3 position = gameObject.transform.position;
				float num = (position.z = z);
				Vector3 vector2 = (gameObject.transform.position = position);
				gameObject.transform.localScale = Vector3.one;
				float z2 = gameObject.transform.localPosition.z - 1f;
				Vector3 localPosition = gameObject.transform.localPosition;
				float num2 = (localPosition.z = z2);
				Vector3 vector4 = (gameObject.transform.localPosition = localPosition);
				closeButton = gameObject.GetComponentInChildren<UIButtonMessage>();
			}
			result = closeButton;
		}
		return (UIButtonMessage)result;
	}
}
