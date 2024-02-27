using System;
using UnityEngine;

[Serializable]
public class QuestLinkPosition : MonoBehaviour
{
	public EnumMapLinkDir Direction;

	public Vector3 Position => transform.position;
}
