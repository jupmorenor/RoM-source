using System;
using UnityEngine;

[Serializable]
public class AnimationEventManager : MonoBehaviour
{
	private readonly string DEFAULT_TARGET_NAME;

	private readonly int SEARCH_RETRY_COUNT;

	public AnimationEventManager()
	{
		DEFAULT_TARGET_NAME = "C0000_000_MA_ROOT";
		SEARCH_RETRY_COUNT = 5;
	}
}
