using System;
using UnityEngine;

[Serializable]
public class FPSDisp : MonoBehaviour
{
	private float m_timeUntilNextInterval;

	private float m_accumulated;

	private int m_numFrames;

	private float m_updateInterval;

	private string format;

	private float x;

	private float y;

	public FPSDisp()
	{
		m_updateInterval = 1f;
		format = string.Empty;
	}

	public void Start()
	{
		x = (float)((double)Screen.width * 0.8);
		y = (float)((double)Screen.height * 0.92);
		m_timeUntilNextInterval = m_updateInterval;
	}

	public void Update()
	{
		m_timeUntilNextInterval -= Time.deltaTime;
		m_accumulated += Time.timeScale / Time.deltaTime;
		checked
		{
			m_numFrames++;
			if (!((double)m_timeUntilNextInterval > 0.0))
			{
				float num = m_accumulated / (float)m_numFrames;
				m_accumulated = 0f;
				m_timeUntilNextInterval = m_updateInterval;
				m_numFrames = 0;
				format = UIBasicUtility.SafeFormat("FPS: {0:F2}", num);
			}
		}
	}

	public void OnGUI()
	{
		GUI.Label(new Rect(x, y, 100f, 40f), format);
	}
}
