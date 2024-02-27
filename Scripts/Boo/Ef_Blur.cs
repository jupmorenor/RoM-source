using System;
using UnityEngine;

[Serializable]
public class Ef_Blur : MonoBehaviour
{
	public Color tensiColor;

	public Color akumaColor;

	public Ef_Blur()
	{
		tensiColor = Color.white;
		akumaColor = new Color(0.2f, 0.2f, 0.2f, 1f);
	}

	public void Start()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if ((bool)currentPlayer && currentPlayer.IsReady)
		{
			if (currentPlayer.IsTensi)
			{
				particleSystem.startColor = tensiColor;
			}
			else
			{
				particleSystem.startColor = akumaColor;
			}
		}
	}
}
