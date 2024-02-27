using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonStatsGui : MonoBehaviour
{
	public Rect WindowRect = new Rect(0f, 0f, 200f, 50f);

	public float WidthWithText = 400f;

	public bool healthStatsOn;

	public bool trafficStatsOn;

	public bool buttonsOn;

	public bool Visible;

	public PhotonPeer Peer { get; set; }

	private void Start()
	{
		float num = WindowRect.width;
		if (trafficStatsOn)
		{
			num = WidthWithText;
		}
		WindowRect = new Rect((float)Screen.width - num, 133f, num, WindowRect.height);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
		{
			Visible = !Visible;
		}
	}

	private void OnGUI()
	{
		if (Visible)
		{
			if (Peer == null)
			{
				WindowRect = GUILayout.Window(10, WindowRect, NetSimHasNoPeerWindow, "Messages (shift+tab)");
			}
			else
			{
				WindowRect = GUILayout.Window(10, WindowRect, TrafficStatsWindow, "Messages (shift+tab)");
			}
		}
	}

	private void NetSimHasNoPeerWindow(int windowId)
	{
		GUILayout.Label("No peer to communicate with. ");
	}

	private void TrafficStatsWindow(int windowID)
	{
		bool flag = false;
		TrafficStatsGameLevel trafficStatsGameLevel = Peer.TrafficStatsGameLevel;
		long num = Peer.TrafficStatsElapsedMs / 1000;
		if (num == 0L)
		{
			num = 1L;
		}
		GUILayout.BeginHorizontal();
		buttonsOn = GUILayout.Toggle(buttonsOn, "buttons");
		if (Peer.TrafficStatsEnabled != Visible)
		{
			Peer.TrafficStatsEnabled = Visible;
		}
		trafficStatsOn = GUILayout.Toggle(trafficStatsOn, "traffic");
		healthStatsOn = GUILayout.Toggle(healthStatsOn, "health");
		GUILayout.EndHorizontal();
		string text = $"Out|In|Sum:\t{trafficStatsGameLevel.TotalOutgoingMessageCount,4} | {trafficStatsGameLevel.TotalIncomingMessageCount,4} | {trafficStatsGameLevel.TotalMessageCount,4}";
		string text2 = $"{num}sec average:";
		string text3 = $"Out|In|Sum:\t{trafficStatsGameLevel.TotalOutgoingMessageCount / num,4} | {trafficStatsGameLevel.TotalIncomingMessageCount / num,4} | {trafficStatsGameLevel.TotalMessageCount / num,4}";
		GUILayout.Label(text);
		GUILayout.Label(text2);
		GUILayout.Label(text3);
		if (buttonsOn)
		{
			GUILayout.BeginHorizontal();
			Visible = GUILayout.Toggle(Visible, "stats on");
			if (GUILayout.Button("Reset"))
			{
				Peer.TrafficStatsReset();
				Peer.TrafficStatsEnabled = true;
			}
			flag = GUILayout.Button("To Log");
			GUILayout.EndHorizontal();
		}
		string text4 = string.Empty;
		string text5 = string.Empty;
		if (trafficStatsOn)
		{
			text4 = "Incoming: " + Peer.TrafficStatsIncoming.ToString();
			text5 = "Outgoing: " + Peer.TrafficStatsOutgoing.ToString();
			GUILayout.Label(text4);
			GUILayout.Label(text5);
		}
		string text6 = string.Empty;
		if (healthStatsOn)
		{
			text6 = string.Format("longest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", trafficStatsGameLevel.LongestDeltaBetweenSending, trafficStatsGameLevel.LongestDeltaBetweenDispatching, trafficStatsGameLevel.LongestEventCallback, trafficStatsGameLevel.LongestEventCallbackCode, trafficStatsGameLevel.LongestOpResponseCallback, trafficStatsGameLevel.LongestOpResponseCallbackOpCode);
			GUILayout.Label(text6);
		}
		if (flag)
		{
			string message = $"{text}\n{text2}\n{text3}\n{text4}\n{text5}\n{text6}";
			Debug.Log(message);
		}
		GUI.DragWindow();
	}
}
