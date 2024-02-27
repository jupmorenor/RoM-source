using UnityEngine;

public class AnimeFadeTest : MonoBehaviour
{
	public Transform yAng;

	private int numOf;

	private Transform[] tfs = new Transform[0];

	private string[] paths = new string[0];

	public bool idle;

	public bool atack;

	private void Start()
	{
		if (!yAng)
		{
			yAng = base.transform.Find("y_ang");
		}
		numOf = ChildCount(yAng, 0);
		tfs = new Transform[numOf];
		paths = new string[numOf];
		DigChild(yAng, 0, string.Empty);
	}

	private int ChildCount(Transform tf, int n)
	{
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = ChildCount(tf.GetChild(i), n);
		}
		return n;
	}

	private int DigChild(Transform tf, int n, string path)
	{
		tfs[n] = tf;
		if (path != string.Empty)
		{
			path += "/";
		}
		path += tf.name;
		paths[n] = path;
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = DigChild(tf.GetChild(i), n, path);
		}
		return n;
	}

	private void Update()
	{
		if (idle)
		{
			FadeAnim("c0000_bt_1hs_idle", 0.2f);
			idle = false;
		}
		if (atack)
		{
			FadeAnim("c0000_bt_1hs_skill3", 0.2f);
			atack = false;
		}
	}

	private void FadeAnim(string name, float fade)
	{
		base.transform.position = yAng.position;
		base.transform.rotation = yAng.rotation;
		base.animation.AddClip(PoseClip(), "pose");
		base.animation.Play("pose");
		base.animation.CrossFade(name, fade);
	}

	private AnimationClip PoseClip()
	{
		AnimationClip animationClip = new AnimationClip();
		animationClip.wrapMode = WrapMode.ClampForever;
		animationClip.SetCurve(paths[0], typeof(Transform), "localPosition.x", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localPosition.y", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localPosition.z", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localRotation.x", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localRotation.y", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localRotation.z", AnimationCurve.Linear(0f, 0f, 1f, 0f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localRotation.w", AnimationCurve.Linear(0f, 1f, 1f, 1f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localScale.x", AnimationCurve.Linear(0f, 1f, 1f, 1f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localScale.y", AnimationCurve.Linear(0f, 1f, 1f, 1f));
		animationClip.SetCurve(paths[0], typeof(Transform), "localScale.z", AnimationCurve.Linear(0f, 1f, 1f, 1f));
		for (int i = 1; i < numOf; i++)
		{
			animationClip.SetCurve(paths[i], typeof(Transform), "localPosition.x", AnimationCurve.Linear(0f, tfs[i].localPosition.x, 1f, tfs[i].localPosition.x));
			animationClip.SetCurve(paths[i], typeof(Transform), "localPosition.y", AnimationCurve.Linear(0f, tfs[i].localPosition.y, 1f, tfs[i].localPosition.y));
			animationClip.SetCurve(paths[i], typeof(Transform), "localPosition.z", AnimationCurve.Linear(0f, tfs[i].localPosition.z, 1f, tfs[i].localPosition.z));
			animationClip.SetCurve(paths[i], typeof(Transform), "localRotation.x", AnimationCurve.Linear(0f, tfs[i].localRotation.x, 1f, tfs[i].localRotation.x));
			animationClip.SetCurve(paths[i], typeof(Transform), "localRotation.y", AnimationCurve.Linear(0f, tfs[i].localRotation.y, 1f, tfs[i].localRotation.y));
			animationClip.SetCurve(paths[i], typeof(Transform), "localRotation.z", AnimationCurve.Linear(0f, tfs[i].localRotation.z, 1f, tfs[i].localRotation.z));
			animationClip.SetCurve(paths[i], typeof(Transform), "localRotation.w", AnimationCurve.Linear(0f, tfs[i].localRotation.w, 1f, tfs[i].localRotation.w));
			animationClip.SetCurve(paths[i], typeof(Transform), "localScale.x", AnimationCurve.Linear(0f, tfs[i].localScale.x, 1f, tfs[i].localScale.x));
			animationClip.SetCurve(paths[i], typeof(Transform), "localScale.y", AnimationCurve.Linear(0f, tfs[i].localScale.y, 1f, tfs[i].localScale.y));
			animationClip.SetCurve(paths[i], typeof(Transform), "localScale.z", AnimationCurve.Linear(0f, tfs[i].localScale.z, 1f, tfs[i].localScale.z));
		}
		return animationClip;
	}
}
