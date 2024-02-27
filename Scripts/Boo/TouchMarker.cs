using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class TouchMarker
{
	private bool isMarked;

	private Vector3 markedPos;

	private PlayerMarkerObject _markerObj;

	protected PlayerMarkerObject markerObj
	{
		get
		{
			if (_markerObj == null)
			{
				_markerObj = new PlayerMarkerObject(PlayerAssets.Instance.instantiateTapEffect);
				if (_markerObj == null)
				{
					throw new AssertionFailedException("_markerObj != null");
				}
			}
			return _markerObj;
		}
	}

	public bool IsMarked => isMarked;

	public Vector3 MarkedPos => markedPos;

	public float distanceTo(Vector3 pos)
	{
		return (markedPos - pos).magnitude;
	}

	public void clear()
	{
		deleteMark();
		markerObj.kill();
	}

	public void newMark(Vector3 pos)
	{
		if (!isMarked)
		{
			isMarked = true;
			markerObj.enable(pos);
		}
		markedPos = pos;
	}

	public void updateMark(Vector3 pos)
	{
		if (!isMarked)
		{
			newMark(pos);
		}
		markedPos = pos;
		markerObj.enable(pos);
	}

	public void deleteMark()
	{
		if (isMarked)
		{
			isMarked = false;
		}
		markerObj.kill();
	}
}
