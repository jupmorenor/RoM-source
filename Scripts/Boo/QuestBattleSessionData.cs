using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestBattleSessionData
{
	[Serializable]
	public class PoppedMonster
	{
		public RespMonster data;

		public float hp;

		public Vector3 pos;

		public PoppedMonster()
		{
		}

		public PoppedMonster(RespMonster _data, float _hp, Vector3 _pos)
		{
			if (_data == null)
			{
				throw new AssertionFailedException("_data != null");
			}
			data = _data;
			hp = _hp;
			pos = _pos;
		}

		public PoppedMonster(AIControl ai)
		{
			if (!(ai != null))
			{
				throw new AssertionFailedException("ai != null");
			}
			if (!ai.HasMonsterData)
			{
				throw new AssertionFailedException("ai.HasMonsterData");
			}
			data = ai.MonsterData;
			hp = ai.HitPoint;
			pos = ai.transform.position;
		}
	}

	public bool stopped;

	public Boo.Lang.List<PoppedMonster> pops;

	public int wave;

	public bool afterContinue;

	public int stageBattleId;

	public string continueApiKey;

	public QuestBattleSessionData()
	{
		pops = new Boo.Lang.List<PoppedMonster>();
		clear();
	}

	public override string ToString()
	{
		return new StringBuilder("QuestBattleSessionData(stopped:").Append(stopped).Append(" pops=").Append((object)((ICollection)pops).Count)
			.Append(" wave=")
			.Append((object)wave)
			.Append(" afterContinue=")
			.Append(afterContinue)
			.Append(" stageBattleId=")
			.Append((object)stageBattleId)
			.Append(")")
			.ToString();
	}

	public void clear()
	{
		stopped = false;
		pops.Clear();
		wave = 0;
		afterContinue = false;
		stageBattleId = 0;
		continueApiKey = string.Empty;
	}

	public bool contains(RespMonster m)
	{
		int result;
		bool flag;
		if (m == null)
		{
			result = 0;
		}
		else
		{
			IEnumerator<PoppedMonster> enumerator = pops.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PoppedMonster current = enumerator.Current;
					if (!RuntimeServices.EqualityOperator(current.data, m))
					{
						continue;
					}
					flag = true;
					goto IL_0056;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = 0;
		}
		goto IL_0057;
		IL_0057:
		return (byte)result != 0;
		IL_0056:
		result = (flag ? 1 : 0);
		goto IL_0057;
	}
}
