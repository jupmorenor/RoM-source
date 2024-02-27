using System;
using UnityEngine;

[Serializable]
public class MerlinActionMMPCSet : MonoBehaviour
{
	public Collider coliYarare;

	public Collider[] attackColliders;

	public EnumElements element;

	private MerlinMotionPackControl _mmpc;

	public MerlinMotionPackControl mmpc
	{
		get
		{
			MerlinMotionPackControl result;
			if (_mmpc == null)
			{
				_mmpc = GetComponent<MerlinMotionPackControl>();
				if (_mmpc == null)
				{
				}
				result = _mmpc;
			}
			else
			{
				result = _mmpc;
			}
			return result;
		}
	}
}
