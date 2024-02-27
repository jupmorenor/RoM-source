using System;
using UnityEngine;

[Serializable]
public class TicketQuestKeyIcon : MonoBehaviour
{
	public GameObject _keyOpenIcon;

	public GameObject _keyCloseIcon;

	public GameObject KeyOpenIcon => _keyOpenIcon;

	public GameObject KeyCloseIcon => _keyCloseIcon;

	public void Start()
	{
	}

	public void Update()
	{
	}
}
