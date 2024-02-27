using System;
using UnityEngine;

[Serializable]
public class Ef_Tag : MonoBehaviour
{
	public string effTag;

	private Ef_TagDatas tagDats;

	public void Start()
	{
		tagDats = Ef_TagDatas.Current;
		if (tagDats == null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			tagDats.SetTag(effTag, gameObject);
		}
	}
}
