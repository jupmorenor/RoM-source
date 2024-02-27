using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestBattlePopPosGetter
{
	[NonSerialized]
	private const string ENEMY_POP_AREA_PREFIX = "poparea";

	[NonSerialized]
	private const string POPPET_POP_AREA_PREFIX = "petarea";

	private GameObject rootObj;

	private GameObject[] poppetPopAreas;

	private GameObject[] monsterPopAreas;

	private Vector3 BasePosition => rootObj.transform.position;

	public QuestBattlePopPosGetter(GameObject _rootObj, Vector3 playerPos)
	{
		if (!(_rootObj != null))
		{
			throw new AssertionFailedException("_rootObj != null");
		}
		rootObj = _rootObj;
		monsterPopAreas = getAndDisableMonsterPopAreas();
		poppetPopAreas = getAndDisablePoppetPopAreas(playerPos);
	}

	public Vector3 getPoppetPos(PlayerControl player)
	{
		Vector3 position = player.transform.position;
		return (poppetPopAreas == null || poppetPopAreas.Length <= 0) ? getRandomPoppetPos(player, BasePosition, position) : randomPopPos(poppetPopAreas);
	}

	public Vector3 getMonsterPos(Vector3 altPopPos)
	{
		Vector3 result;
		if (monsterPopAreas != null && monsterPopAreas.Length > 0)
		{
			Vector3 pos = randomPopPos(monsterPopAreas);
			result = BattleUtil.AdjustYpos(pos);
		}
		else
		{
			result = randomPopPos(BasePosition, 6f, 6f, altPopPos);
		}
		return result;
	}

	public static Vector3 randomPopPos(Vector3 @base, float xrange, float zrange)
	{
		xrange *= 0.5f;
		zrange *= 0.5f;
		Vector3 vector = default(Vector3);
		int num = 0;
		Vector3 result;
		while (true)
		{
			if (num < 50)
			{
				int num2 = num;
				num++;
				float x = UnityEngine.Random.Range(0f - xrange, xrange);
				float z = UnityEngine.Random.Range(0f - zrange, zrange);
				vector = BattleUtil.AdjustYpos(@base + new Vector3(x, 0f, z));
				if (!(Mathf.Abs(@base.y - vector.y) >= 1f))
				{
					result = vector;
					break;
				}
				continue;
			}
			result = BattleUtil.AdjustYpos(vector);
			break;
		}
		return result;
	}

	public static Vector3 randomPopPos(Vector3 @base, float xrange, float zrange, Vector3 altPopPos)
	{
		float num = xrange * 0.5f;
		float num2 = zrange * 0.5f;
		Vector3 vector = default(Vector3);
		int num3 = 0;
		Vector3 result;
		while (true)
		{
			if (num3 < 50)
			{
				int num4 = num3;
				num3++;
				float x = UnityEngine.Random.Range(0f - num, num);
				float z = UnityEngine.Random.Range(0f - num2, num2);
				vector = BattleUtil.AdjustYpos(@base + new Vector3(x, 0f, z));
				if (!(Mathf.Abs(@base.y - vector.y) >= 1f))
				{
					result = vector;
					break;
				}
				continue;
			}
			result = randomPopPos(altPopPos, xrange, zrange);
			break;
		}
		return result;
	}

	public static Vector3 randomPopPos(GameObject[] popAreas)
	{
		if (popAreas == null || popAreas.Length <= 0)
		{
			throw new AssertionFailedException("(popAreas != null) and (len(popAreas) > 0)");
		}
		GameObject gameObject = popAreas[RuntimeServices.NormalizeArrayIndex(popAreas, UnityEngine.Random.Range(0, popAreas.Length))];
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("go != null");
		}
		BoxCollider component = gameObject.GetComponent<BoxCollider>();
		Vector3 result;
		if (component != null)
		{
			float x = component.size.x;
			float z = component.size.z;
			float x2 = UnityEngine.Random.Range(0f, x) - x * 0.5f + component.center.x;
			float z2 = UnityEngine.Random.Range(0f, z) - z * 0.5f + component.center.z;
			Vector3 pos = gameObject.transform.TransformPoint(new Vector3(x2, 0f, z2));
			result = BattleUtil.AdjustYpos(pos);
		}
		else
		{
			result = gameObject.transform.position;
		}
		return result;
	}

	private GameObject[] getAndDisableMonsterPopAreas()
	{
		GameObject[] chilren = getChilren("poparea");
		disableAll(chilren);
		return chilren;
	}

	private GameObject[] getAndDisablePoppetPopAreas(Vector3 basePos)
	{
		GameObject[] chilren = getChilren("petarea");
		disableAll(chilren);
		float num = float.PositiveInfinity;
		GameObject gameObject = null;
		int i = 0;
		GameObject[] array = chilren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			Vector3 position = array[i].transform.position;
			float magnitude = (position - basePos).magnitude;
			if (!(num <= magnitude))
			{
				num = magnitude;
				gameObject = array[i];
			}
		}
		return (!(gameObject != null)) ? new GameObject[0] : new GameObject[1] { gameObject };
	}

	private GameObject[] getChilren(string prefix)
	{
		Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
		int i = 0;
		GameObject[] array = ExtensionsModule.Children(rootObj);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].name.ToLower().StartsWith(prefix))
			{
				list.Add(array[i]);
			}
		}
		return (GameObject[])Builtins.array(typeof(GameObject), list);
	}

	private void disableAll(GameObject[] goList)
	{
		if (!(goList == null))
		{
			int i = 0;
			for (int length = goList.Length; i < length; i = checked(i + 1))
			{
				disable(goList[i]);
			}
		}
	}

	private static void disable(GameObject go)
	{
		if (!(go == null))
		{
			Collider component = go.GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = false;
			}
			go.SetActive(value: false);
		}
	}

	private Vector3 getRandomPoppetPos(PlayerControl player, Vector3 basePos, Vector3 altPos)
	{
		Vector3 position = player.transform.position;
		Boo.Lang.List<Vector3> list = new Boo.Lang.List<Vector3>();
		IEnumerator<Vector3> enumerator = player.Trajectory.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Vector3 current = enumerator.Current;
				if (isInRange(current, position, 0.5f, 2f))
				{
					list.Add(current);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Vector3[] array = (Vector3[])Builtins.array(typeof(Vector3), list);
		Vector3 result;
		if (array.Length > 0)
		{
			result = BattleUtil.AdjustYpos(array[RuntimeServices.NormalizeArrayIndex(array, UnityEngine.Random.Range(0, array.Length))]);
		}
		else
		{
			result = randomPopPos(basePos, 2f, 2f, altPos);
		}
		return result;
	}

	private bool isInRange(Vector3 pos, Vector3 target, float min, float max)
	{
		float magnitude = (pos - target).magnitude;
		bool num = !(min > magnitude);
		if (num)
		{
			num = !(max > magnitude);
		}
		return num;
	}
}
