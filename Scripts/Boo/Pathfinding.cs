using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pathfinding : MonoBehaviour
{
	[NonSerialized]
	public static bool ENABLE_ERRLOG;

	private List<Vector3> _path;

	private List<Vector3> _calPath;

	private float _fVerifyLength;

	private bool _pathModify;

	private bool _moreModify;

	private bool _debugLine;

	private List<Vector3> _removeNodeList;

	protected bool isMovement;

	protected Queue<Vector3> pathQueue;

	protected List<Vector3> drawPathList;

	public int PathLength => (_path != null) ? _path.Count : 0;

	public int CalPathLength => (_calPath != null) ? _calPath.Count : 0;

	public List<Vector3> Path => _path;

	public List<Vector3> CalPath => _calPath;

	public float fVerifyLength => _fVerifyLength;

	public bool PathModify => _pathModify;

	public bool MoreModify => _moreModify;

	public bool DebugLine
	{
		get
		{
			return _debugLine;
		}
		set
		{
			_debugLine = value;
		}
	}

	public List<Vector3> RemoveNodeList => _removeNodeList;

	public bool IsMovement => isMovement;

	public Pathfinding()
	{
		_path = new List<Vector3>();
		_calPath = new List<Vector3>();
		_fVerifyLength = 0.5f;
		_pathModify = true;
		_moreModify = true;
		_removeNodeList = new List<Vector3>();
		pathQueue = new Queue<Vector3>();
		drawPathList = new List<Vector3>();
	}

	public void OnDestroy()
	{
		destruct();
	}

	private void destruct()
	{
		_removeNodeList = null;
		_calPath = null;
		pathQueue = null;
	}

	public void FindPath(Vector3 startPosition, Vector3 endPosition)
	{
		if (Pathfinder.Instance != null && !Pathfinder.Instance.IsQueuing())
		{
			Pathfinder.Instance.InsertInQueue(startPosition, endPosition, SetList);
		}
	}

	public bool IsMovableNode(Vector3 vNode, Vector3 vTarget)
	{
		int result;
		if (Pathfinder.Instance == null)
		{
			result = 0;
		}
		else
		{
			Vector2 zero = Vector2.zero;
			zero.x = vTarget.x;
			zero.y = vTarget.z;
			Vector2 zero2 = Vector2.zero;
			zero2.x = vNode.x;
			zero2.y = vNode.z;
			Vector2 vector = zero - zero2;
			vector.Normalize();
			float num = Vector2.Distance(zero, zero2);
			_fVerifyLength = Pathfinder.Instance.Tilesize / 2f;
			float num2 = fVerifyLength;
			Vector3 zero3 = Vector3.zero;
			while (true)
			{
				if (num2 < num)
				{
					Vector2 vector2 = zero2 + vector * num2;
					zero3.x = vector2.x;
					zero3.z = vector2.y;
					if (!Pathfinder.Instance.IsTheClosestNodeWalkable(zero3))
					{
						result = 0;
						break;
					}
					num2 += fVerifyLength;
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	protected virtual void SetList(Vector3 vDestPos, List<Vector3> path)
	{
		Path.Clear();
		CalPath.Clear();
		if (!PathModify)
		{
			_path = path;
		}
		else
		{
			RemoveNodeList.Clear();
			bool flag = IsMovableNode(transform.position, vDestPos);
			if (flag)
			{
				path.Clear();
				CalPath.Add(vDestPos);
			}
			else
			{
				int count = path.Count;
				if (count == 0)
				{
					if (!ENABLE_ERRLOG)
					{
					}
					return;
				}
				CalPath.Add(transform.position);
				int num = 0;
				int num2 = count;
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int index = num;
					num++;
					Vector3 item = path[index];
					CalPath.Add(item);
				}
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				Vector2 zero3 = Vector2.zero;
				int count2 = CalPath.Count;
				int num3 = 0;
				int num4 = count2;
				if (num4 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num3 < num4)
				{
					int num5 = num3;
					num3++;
					zero.x = CalPath[num5].x;
					zero.y = CalPath[num5].z;
					checked
					{
						if (num5 + 1 >= count2)
						{
							continue;
						}
						zero2.x = CalPath[num5 + 1].x;
						zero2.y = CalPath[num5 + 1].z;
						if (num5 + 2 < count2)
						{
							zero3.x = CalPath[num5 + 2].x;
							zero3.y = CalPath[num5 + 2].z;
							Vector2 lhs = zero2 - zero;
							Vector2 rhs = zero3 - zero2;
							lhs.Normalize();
							rhs.Normalize();
							float num6 = Vector2.Dot(lhs, rhs);
							if (!(num6 <= 0.98f))
							{
								Vector3 item2 = CalPath[num5 + 1];
								RemoveNodeList.Add(item2);
							}
						}
					}
				}
				int num7 = 0;
				int count3 = RemoveNodeList.Count;
				if (count3 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num7 < count3)
				{
					int index2 = num7;
					num7++;
					Vector3 vector = RemoveNodeList[index2];
					int num8 = 0;
					int count4 = CalPath.Count;
					if (count4 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num8 < count4)
					{
						int index3 = num8;
						num8++;
						Vector3 vector2 = CalPath[index3];
						if (vector == vector2)
						{
							CalPath.RemoveAt(index3);
							break;
						}
					}
				}
				RemoveNodeList.Clear();
				if (MoreModify)
				{
					count2 = CalPath.Count;
					Vector3 vector3 = Vector2.zero;
					Vector3 vector4 = Vector2.zero;
					Vector3 vector5 = Vector2.zero;
					int num9 = 0;
					int num10 = count2;
					if (num10 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num9 < num10)
					{
						int num11 = num9;
						num9++;
						vector3 = CalPath[num11];
						checked
						{
							if (num11 + 1 >= count2)
							{
								continue;
							}
							vector4 = CalPath[num11 + 1];
							if (num11 + 2 < count2)
							{
								vector5 = CalPath[num11 + 2];
								if (IsMovableNode(vector3, vector5))
								{
									RemoveNodeList.Add(vector4);
								}
							}
						}
					}
					int num12 = 0;
					int count5 = RemoveNodeList.Count;
					if (count5 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num12 < count5)
					{
						int index4 = num12;
						num12++;
						Vector3 vector6 = RemoveNodeList[index4];
						int num13 = 0;
						int count6 = CalPath.Count;
						if (count6 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (num13 < count6)
						{
							int index5 = num13;
							num13++;
							Vector3 vector7 = CalPath[index5];
							if (vector6 == vector7)
							{
								CalPath.RemoveAt(index5);
								break;
							}
						}
					}
				}
			}
			_path = CalPath;
		}
		ContentPathListSetup();
	}

	public void ContentPathListSetup()
	{
		pathQueue.Clear();
		drawPathList.Clear();
		for (int i = 0; i < Path.Count; i = checked(i + 1))
		{
			Vector3 item = Path[i];
			pathQueue.Enqueue(item);
			drawPathList.Add(item);
		}
		if (pathQueue.Count > 0)
		{
			isMovement = true;
		}
	}
}
