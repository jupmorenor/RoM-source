using System;
using UnityEngine;

[Serializable]
public class FolonClockSub : MonoBehaviour
{
	private float localSpeedRate;

	private FolonClockController _fcc;

	protected float speedRate => (!(fcc == null)) ? (fcc.GlobalSpeedRate * LocalSpeedRate) : LocalSpeedRate;

	protected FolonClockController fcc
	{
		get
		{
			if (_fcc == null)
			{
				_fcc = ExtensionsModule.FindComponentInChildrenOrSelf<FolonClockController>(gameObject);
			}
			return (!(_fcc != null)) ? null : _fcc;
		}
	}

	protected FolonClockController.BonesReference _bones => (!(fcc == null)) ? fcc.bones : null;

	public float LocalSpeedRate => localSpeedRate;

	public FolonClockSub()
	{
		localSpeedRate = 1f;
	}

	public virtual void StartMove()
	{
	}
}
