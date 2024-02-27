using UnityEngine;

public class FPSCounter : MonoBehaviour
{
	public float m_updateInterval = 1f;

	private float m_accumulated;

	private float m_timeUntilNextInterval;

	private int m_numFrames;

	private string format;

	private void Start()
	{
		m_timeUntilNextInterval = m_updateInterval;
	}

	private void Update()
	{
		m_timeUntilNextInterval -= Time.deltaTime;
		m_accumulated += Time.timeScale / Time.deltaTime;
		m_numFrames++;
		if ((double)m_timeUntilNextInterval <= 0.0)
		{
			float num = m_accumulated / (float)m_numFrames;
			format = $"FPS: {num:F2}";
			m_timeUntilNextInterval = m_updateInterval;
			m_accumulated = 0f;
			m_numFrames = 0;
		}
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(130f, 10f, 100f, 20f), format);
		GUI.Label(new Rect(130f, 30f, 300f, 20f), "Scene: " + Application.loadedLevelName);
	}
}
