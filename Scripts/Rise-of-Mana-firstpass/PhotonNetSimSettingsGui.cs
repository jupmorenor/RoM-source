using ExitGames.Client.Photon.Lite;
using UnityEngine;

public class PhotonNetSimSettingsGui : MonoBehaviour
{
	public Rect WindowRect = new Rect(0f, 0f, 200f, 50f);

	public bool Visible;

	public LitePeer Peer { get; set; }

	private void Start()
	{
		WindowRect = new Rect(0f, 133f, 200f, WindowRect.height);
	}

	public void OnGUI()
	{
		if (Visible)
		{
			if (Peer == null)
			{
				WindowRect = GUILayout.Window(0, WindowRect, NetSimHasNoPeerWindow, "Netw. Sim.");
			}
			else
			{
				WindowRect = GUILayout.Window(0, WindowRect, NetSimWindow, "Netw. Sim.");
			}
		}
	}

	private void NetSimHasNoPeerWindow(int windowId)
	{
		GUILayout.Label("No peer to communicate with. ");
	}

	private void NetSimWindow(int windowId)
	{
		GUILayout.Label($"Rtt: {Peer.RoundTripTime,3} +/- {Peer.RoundTripTimeVariance,3}");
		bool isSimulationEnabled = Peer.IsSimulationEnabled;
		bool flag = GUILayout.Toggle(isSimulationEnabled, "sim");
		if (flag != isSimulationEnabled)
		{
			Peer.IsSimulationEnabled = flag;
		}
		float num = Peer.NetworkSimulationSettings.IncomingLag;
		GUILayout.Label("lag " + num);
		num = GUILayout.HorizontalSlider(num, 0f, 500f);
		Peer.NetworkSimulationSettings.IncomingLag = (int)num;
		Peer.NetworkSimulationSettings.OutgoingLag = (int)num;
		float num2 = Peer.NetworkSimulationSettings.IncomingJitter;
		GUILayout.Label("jit " + num2);
		num2 = GUILayout.HorizontalSlider(num2, 0f, 100f);
		Peer.NetworkSimulationSettings.IncomingJitter = (int)num2;
		Peer.NetworkSimulationSettings.OutgoingJitter = (int)num2;
		float num3 = Peer.NetworkSimulationSettings.IncomingLossPercentage;
		GUILayout.Label("loss " + num3);
		num3 = GUILayout.HorizontalSlider(num3, 0f, 10f);
		Peer.NetworkSimulationSettings.IncomingLossPercentage = (int)num3;
		Peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)num3;
		GUI.DragWindow();
	}
}
