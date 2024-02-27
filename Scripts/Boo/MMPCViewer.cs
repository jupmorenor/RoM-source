using System;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MMPCViewer : MonoBehaviour
{
	private string current_label;

	public AnimationClip state;

	private List clips;

	public bool dispPlaycontrol;

	public bool dispInformation;

	private bool play;

	private bool loop;

	private MerlinMotionPackControl mmpc;

	public MMPCViewer()
	{
		dispInformation = true;
		play = true;
		loop = true;
	}

	public void Awake()
	{
		mmpc = gameObject.GetComponent<MerlinMotionPackControl>();
	}

	public void Update()
	{
		if ((bool)mmpc)
		{
			state = mmpc.CurrentClip;
			if (!play)
			{
				mmpc.stop();
			}
			string lhs = null;
			if ((bool)state)
			{
				lhs += "[animation]\t" + state.name + "\n";
				lhs += "[sec  ]\t\t\t" + Mathf.Floor(mmpc.MotionTime * 100f) / 100f + "\n";
				lhs += "[frame]\t\t\t" + Mathf.Floor(MMPCViewerModule.seconds_to_frame(mmpc.MotionTime) * 100f) / 100f + "\n";
				lhs += "[total]\t\t\t" + MMPCViewerModule.seconds_to_frame(mmpc.MotionLength) + " frame\n";
			}
			current_label = lhs;
		}
	}

	public void OnGUI()
	{
		if (dispInformation)
		{
			GUI.skin.box.alignment = TextAnchor.MiddleLeft;
			GUI.Box(new Rect(130f, 50f, 250f, 90f), current_label);
		}
		if (dispPlaycontrol)
		{
			if (GUI.Button(new Rect(10f, 170f, 100f, 50f), "<<Prev"))
			{
				prev_frame();
			}
			if (GUI.Button(new Rect(160f, 170f, 100f, 50f), "Play?"))
			{
				toggle_play();
			}
			if (GUI.Button(new Rect(320f, 170f, 100f, 50f), "Next>>"))
			{
				next_frame();
			}
		}
	}

	public void toggle_play()
	{
		play = !play;
		loop = true;
	}

	public void play_anim()
	{
		play = true;
	}

	public void stop_anim()
	{
		play = false;
	}

	public void prev_frame()
	{
		stop_anim();
	}

	public void next_frame()
	{
		stop_anim();
	}
}
