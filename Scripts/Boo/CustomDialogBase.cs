using System;
using UnityEngine;

[Serializable]
public class CustomDialogBase : MonoBehaviour
{
	protected PlayerControl player;

	protected virtual void EnterModalMode()
	{
		GameObject gameObject = ModalCollider.GetCollider();
		this.gameObject.transform.parent = gameObject.transform.parent;
		this.gameObject.transform.localPosition = Vector3.zero;
		this.gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
		player = ((PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl))) as PlayerControl;
		if (player != null && player.InputActive)
		{
			player.InputActive = false;
		}
		else
		{
			player = null;
		}
		ModalCollider.SetActive(this, active: true);
		UIButtonMessage button = ButtonBackHUD.GetButton();
		if ((bool)button && (bool)button.GetComponentInChildren<BoxCollider>())
		{
			button.GetComponentInChildren<BoxCollider>().enabled = false;
		}
	}

	protected virtual void ExitModalMode()
	{
		if (player != null)
		{
			player.InputActive = true;
		}
		ModalCollider.SetActive(this, active: false);
		UIButtonMessage button = ButtonBackHUD.GetButton();
		if ((bool)button && (bool)button.GetComponentInChildren<BoxCollider>())
		{
			button.GetComponentInChildren<BoxCollider>().enabled = true;
		}
	}
}
