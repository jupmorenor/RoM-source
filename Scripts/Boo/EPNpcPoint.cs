using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EPNpcPoint : AbstractEventPoint
{
	public MNpcs npc;

	public MNpcTalks npcTalk;

	private Vector3 npcPos;

	private MFlags[] onFlags;

	private MFlags[] offFlags;

	private bool _0024initialized__EPNpcPoint_0024;

	public EPNpcPoint(MNpcTalks _npcTalk)
	{
		if (!_0024initialized__EPNpcPoint_0024)
		{
			_0024initialized__EPNpcPoint_0024 = true;
		}
		initByNpcTalk(_npcTalk);
	}

	public EPNpcPoint(int _npcTalkId)
	{
		if (!_0024initialized__EPNpcPoint_0024)
		{
			_0024initialized__EPNpcPoint_0024 = true;
		}
		initByNpcTalk(MNpcTalks.Get(_npcTalkId));
	}

	private void initByNpcTalk(MNpcTalks _npcTalk)
	{
		if (_npcTalk != null)
		{
			setNpc(MasterUtil.FindNpcByTalk(_npcTalk));
			npcTalk = _npcTalk;
			onFlags = npcTalk.AllResults;
			offFlags = npcTalk.AllNotResults;
		}
	}

	private void setNpc(MNpcs _npc)
	{
		scene = MasterUtil.FindSceneByNpc(_npc);
		if (_npc != null)
		{
			npc = _npc;
		}
	}

	public override void initInScene()
	{
		if (npc == null)
		{
			return;
		}
		int i = 0;
		NpcTalkControl[] array = (NpcTalkControl[])UnityEngine.Object.FindObjectsOfType(typeof(NpcTalkControl));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].MNpcs.Id == npc.Id)
			{
				npcPos = array[i].transform.position;
				break;
			}
		}
	}

	public override bool isReachedAndSatisfied(AutoFlowEnv env)
	{
		int result;
		checked
		{
			if (_IsEmptyOrNull(onFlags) && _IsEmptyOrNull(offFlags))
			{
				result = 0;
			}
			else
			{
				UserMiscInfo.FlagData flagData = UserData.Current.userMiscInfo.flagData;
				int num = 0;
				MFlags[] array = onFlags;
				int length = array.Length;
				while (true)
				{
					if (num < length)
					{
						if (array[num] != null && !flagData.hasFlag(array[num].Progname))
						{
							result = 0;
							break;
						}
						num++;
						continue;
					}
					int num2 = 0;
					MFlags[] array2 = offFlags;
					int length2 = array2.Length;
					while (true)
					{
						if (num2 < length2)
						{
							if (array2[num2] != null && flagData.hasFlag(array2[num2].Progname))
							{
								result = 0;
								break;
							}
							num2++;
							continue;
						}
						result = 1;
						break;
					}
					break;
				}
			}
		}
		return (byte)result != 0;
	}

	private static bool _IsEmptyOrNull(MFlags[] flags)
	{
		bool num = flags == null;
		if (!num)
		{
			num = flags.Length <= 0;
		}
		return num;
	}

	public override Vector3 position()
	{
		return npcPos;
	}

	public override void dump()
	{
	}

	public override string ToString()
	{
		return (npc == null || npcTalk == null) ? new StringBuilder("EPNpcPoint(").Append(scene).Append(" invalid)").ToString() : new StringBuilder("EPNpcPoint(").Append(scene).Append(" ").Append(npcTalk)
			.Append(") npc:")
			.Append((object)npc.Id)
			.Append(" npctalk:")
			.Append((object)npcTalk.Id)
			.Append(") pos=")
			.Append(npcPos)
			.ToString();
	}
}
