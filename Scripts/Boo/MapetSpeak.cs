using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MapetSpeak : MonoBehaviour
{
	[NonSerialized]
	private const float RANDOM_SPEAK_DELAY = 8f;

	private Dictionary<EnumPoppetChatTimings, Hashtable> speakText;

	private float speakLeftTime;

	private BaseControl baseControl;

	private PlayerControl playerControl;

	private float noneSpeakTime;

	protected MPoppets poppet;

	public MPoppets Poppet
	{
		get
		{
			return poppet;
		}
		set
		{
			poppet = value;
			speakText.Clear();
			IEnumerator enumerator = Enum.GetValues(typeof(EnumPoppetChatTimings)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				speakText[(EnumPoppetChatTimings)current] = new Hashtable();
			}
			MPoppetChats[] array = MPoppetChats.filterByPersonality(poppet);
			int i = 0;
			MPoppetChats[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				setSpeakText(array2[i].Condition, array2[i]);
			}
		}
	}

	public MapetSpeak()
	{
		speakText = new Dictionary<EnumPoppetChatTimings, Hashtable>();
		noneSpeakTime = 8f;
	}

	public void Start()
	{
		baseControl = GetComponent<BaseControl>();
		playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
	}

	private void setSpeakText(EnumPoppetChatTimings type, MPoppetChats mchat)
	{
		Hashtable hashtable = speakText[type];
		MPoppetChats[] array = null;
		string text = string.Empty;
		switch (type)
		{
		case EnumPoppetChatTimings.Area:
			text = mchat.AreaGroupName;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			break;
		case EnumPoppetChatTimings.Story:
			text = mchat.StoryName;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			break;
		}
		if (!hashtable.ContainsKey(text))
		{
			array = new MPoppetChats[1] { mchat };
		}
		else
		{
			object obj = hashtable[text];
			if (!(obj is MPoppetChats[]))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MPoppetChats[]));
			}
			array = (MPoppetChats[])obj;
			array = (MPoppetChats[])RuntimeServices.AddArrays(typeof(MPoppetChats), array, new MPoppetChats[1] { mchat });
		}
		hashtable[text] = array;
		speakText[type] = hashtable;
	}

	public void Speak(EnumPoppetChatTimings type)
	{
		Speak(type, overwrite: false);
	}

	public void Speak(EnumPoppetChatTimings type, bool overwrite)
	{
		if (!enabled)
		{
			return;
		}
		noneSpeakTime = 8f + (float)UnityEngine.Random.Range(0, 5);
		if (!(baseControl.HitPoint > 0f) && type != EnumPoppetChatTimings.Dead)
		{
			return;
		}
		MPoppetChats mPoppetChats = SelectChat(type);
		if (mPoppetChats == null)
		{
			return;
		}
		if (overwrite)
		{
			AttachMapetSpeak.show(gameObject, mPoppetChats);
			return;
		}
		MPoppetChats mPoppetChats2 = AttachMapetSpeak.IsActiveChat(gameObject);
		if (mPoppetChats2 == null || mPoppetChats2.Priority <= mPoppetChats.Priority)
		{
			AttachMapetSpeak.show(gameObject, mPoppetChats);
		}
	}

	public MPoppetChats SelectChat(EnumPoppetChatTimings type)
	{
		object result;
		if (!speakText.ContainsKey(type))
		{
			result = null;
			goto IL_01ae;
		}
		Hashtable hashtable = speakText[type];
		string key;
		MPoppetChats[] array;
		if (hashtable != null)
		{
			array = null;
			key = string.Empty;
			if (type == EnumPoppetChatTimings.Area)
			{
				if (GameLevelManager.Instance.CurMScene != null)
				{
					MScenes curMScene = GameLevelManager.Instance.CurMScene;
					if (curMScene != null && curMScene != null)
					{
						MAreas mAreaId = curMScene.MAreaId;
						if (mAreaId == null && curMScene.MQuestId != null)
						{
							mAreaId = curMScene.MQuestId.MAreaId;
						}
						if (mAreaId != null && mAreaId.AreaGroup != null && !string.IsNullOrEmpty(mAreaId.AreaGroup.Progname))
						{
							key = mAreaId.AreaGroup.Progname;
							goto IL_0117;
						}
					}
				}
			}
			else
			{
				if (type != EnumPoppetChatTimings.Story)
				{
					goto IL_0117;
				}
				if (QuestSession.Story != null)
				{
					MStories story = QuestSession.Story;
					if (story != null)
					{
						key = story.Progname;
						goto IL_0117;
					}
				}
			}
		}
		goto IL_01ad;
		IL_01ae:
		return (MPoppetChats)result;
		IL_01ad:
		result = null;
		goto IL_01ae;
		IL_0117:
		if (!hashtable.ContainsKey(key))
		{
			goto IL_01ad;
		}
		object obj = hashtable[key];
		if (!(obj is MPoppetChats[]))
		{
			obj = RuntimeServices.Coerce(obj, typeof(MPoppetChats[]));
		}
		array = (MPoppetChats[])obj;
		checked
		{
			int num = UnityEngine.Random.Range(0, array.Length * 100);
			float num2 = 0f;
			int num3 = 0;
			MPoppetChats[] array2 = array;
			int length = array2.Length;
			while (true)
			{
				if (num3 < length)
				{
					num2 += array2[num3].Rate;
					if (!((float)num > num2))
					{
						result = array2[num3];
						break;
					}
					num3++;
					continue;
				}
				result = null;
				break;
			}
			goto IL_01ae;
		}
	}

	public void Update()
	{
		if (!enabled)
		{
			return;
		}
		noneSpeakTime -= Time.deltaTime;
		if (noneSpeakTime > 0f)
		{
			return;
		}
		if (SceneChanger.CurrentSceneName == "Town")
		{
			Speak(EnumPoppetChatTimings.Area);
		}
		else if ((bool)playerControl && playerControl.battleMode == PlayerControl.BATTLE_MODE.Non_Battle)
		{
			if (UnityEngine.Random.Range(0, 100) < 50)
			{
				Speak(EnumPoppetChatTimings.Story);
			}
			else
			{
				Speak(EnumPoppetChatTimings.Area);
			}
		}
		else
		{
			Speak(EnumPoppetChatTimings.BattleRandom);
		}
	}
}
