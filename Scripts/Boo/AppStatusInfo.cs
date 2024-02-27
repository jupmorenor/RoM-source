using System;
using UnityEngine;

[Serializable]
public class AppStatusInfo : MonoBehaviour
{
	private bool display;

	public float m_updateInterval;

	protected float m_accumulated;

	protected float m_timeUntilNextInterval;

	protected int m_numFrames;

	protected string m_buildDate;

	protected string format;

	public bool m_enableObjCount;

	private PlayerControl player;

	public AppStatusInfo()
	{
		display = true;
		m_updateInterval = 1f;
		format = string.Empty;
	}

	public void Start()
	{
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
				format = UIBasicUtility.SafeFormat("FPS: {0:F2}", num);
				m_timeUntilNextInterval = m_updateInterval;
				m_accumulated = 0f;
				m_numFrames = 0;
			}
		}
	}

	public void OnGUI()
	{
		if (!display)
		{
			return;
		}
		GUI.Box(new Rect(125f, 5f, 205f, 125f), string.Empty);
		GUI.Label(new Rect(130f, 10f, 100f, 40f), format);
		GUI.Label(new Rect(130f, 30f, 300f, 40f), "Scene: " + Application.loadedLevelName);
		string rhs = "2016/01/28 13:12";
		string rhs2 = "7302";
		GUI.Label(new Rect(130f, 50f, 300f, 40f), "Build: " + rhs + " REV: " + rhs2);
		if ((bool)player)
		{
			GUI.Label(new Rect(130f, 70f, 300f, 40f), "Pos: " + player.transform.position);
		}
		else
		{
			player = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
		}
		GUILayout.BeginArea(new Rect(330f, 10f, 300f, 300f));
		m_enableObjCount = GUILayout.Toggle(m_enableObjCount, "Show Objects Counts (very high cost)");
		UnityEngine.Object[] array = null;
		if (m_enableObjCount)
		{
			array = Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object));
			GUILayout.Label("All " + array.Length + "(" + getUseMemSize(array) / 1024 + "k bytes)");
			array = (Texture[])Resources.FindObjectsOfTypeAll(typeof(Texture));
			GUILayout.Label("Textures " + array.Length + "(" + getUseMemSize(array) / 1024 + "k bytes)");
			array = (AudioClip[])Resources.FindObjectsOfTypeAll(typeof(AudioClip));
			GUILayout.Label("AudioClips " + array.Length + "(" + getUseMemSize(array) / 1024 + "k bytes)");
			array = (Mesh[])Resources.FindObjectsOfTypeAll(typeof(Mesh));
			GUILayout.Label("Meshes " + array.Length + "(" + getUseMemSize(array) / 1024 + "k bytes)");
			array = (Material[])Resources.FindObjectsOfTypeAll(typeof(Material));
			GUILayout.Label("Materials " + array.Length + "(" + getUseMemSize(array) / 1024 + "k bytes)");
			array = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
			GUILayout.Label("GameObjects " + array.Length);
			array = (Component[])Resources.FindObjectsOfTypeAll(typeof(Component));
			GUILayout.Label("Components " + array.Length);
			GUILayout.Label("Allocated Mono heap size " + checked((long)unchecked((int)Profiler.GetMonoHeapSize())) / 1024L + "k bytes");
			if (m_numFrames == 0)
			{
				GC.Collect();
			}
			GUILayout.Label("Mono used size " + checked((long)unchecked((int)Profiler.GetMonoUsedSize())) / 1024L + "k bytes");
		}
		GUILayout.EndArea();
	}

	public int getUseMemSize(UnityEngine.Object[] objs)
	{
		int num = 0;
		int i = 0;
		checked
		{
			for (int length = objs.Length; i < length; i++)
			{
				num += Profiler.GetRuntimeMemorySize(objs[i]);
			}
			return num;
		}
	}
}
