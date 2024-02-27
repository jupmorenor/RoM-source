using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class YTweener : MonoBehaviour
{
	public float popY;

	public float time;

	public bool isLocal;

	public bool killWhenFinished;

	public YTweener()
	{
		popY = 5f;
		time = 0.5f;
		isLocal = true;
		killWhenFinished = true;
	}

	public void Start()
	{
		Hashtable args = iTween.Hash("y", transform.position.y + popY, "time", time, "islocal", isLocal, "oncomplete", "endOfAnimation");
		iTween.MoveTo(gameObject, args);
	}

	private void endOfAnimation()
	{
		if (killWhenFinished)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
