using UnityEngine;

public class CaptureFrame : MonoBehaviour
{
	private void OnPreRender()
	{
		Kamcord.CaptureFrame();
	}
}
