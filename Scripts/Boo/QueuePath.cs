using System;
using System.Text;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class QueuePath
{
	public Vector3 startPos;

	public Vector3 endPos;

	public __Pathfinder_InsertInQueue_0024callable59_0024465_84__ storeRef;

	public QueuePath(Vector3 sPos, Vector3 ePos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ theRefMethod)
	{
		startPos = sPos;
		endPos = ePos;
		storeRef = theRefMethod;
	}

	public override string ToString()
	{
		return new StringBuilder("QueuePath(s:").Append(startPos).Append(" e:").Append(endPos)
			.Append(")")
			.ToString();
	}
}
