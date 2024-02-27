using UnityEngine;

public class Ef_Base : MonoBehaviour
{
	public float timeScale = 1f;

	public static bool isShuttingDown;

	public float deltaTime => Time.deltaTime * timeScale;

	public void OnApplicationQuit()
	{
		isShuttingDown = true;
	}
}
