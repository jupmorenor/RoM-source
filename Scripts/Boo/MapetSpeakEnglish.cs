using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MapetSpeakEnglish : MonoBehaviour
{
	[Serializable]
	public enum SPEAK_TYPE
	{
		BattleStart,
		BattleEnd,
		Damage,
		Down,
		Revive,
		UseMagic,
		MagicMax,
		BossBattle,
		BattleRandom,
		ForestRandom,
		TownRandom,
		Tutorial,
		Dead,
		Max
	}

	public bool debugFlag;

	protected readonly int SPEAK_RANDOM_RANGE_MAX;

	[NonSerialized]
	private const float RANDOM_SPEAK_DELAY = 8f;

	private string[,] speakText;

	private int[] speakTextMax;

	private float speakLeftTime;

	private BaseControl baseControl;

	private PlayerControl playerControl;

	private float noneSpeakTime;

	public string curText;

	protected int count;

	public MapetSpeakEnglish()
	{
		SPEAK_RANDOM_RANGE_MAX = 20;
		speakText = (string[,])Builtins.matrix(typeof(string), 13, SPEAK_RANDOM_RANGE_MAX);
		speakTextMax = new int[13];
		noneSpeakTime = 8f;
	}

	public void Start()
	{
		setSpeakText(SPEAK_TYPE.BattleStart, "Enemy has come !");
		setSpeakText(SPEAK_TYPE.BattleStart, "Please \n be careful!");
		setSpeakText(SPEAK_TYPE.BattleStart, "I looked \n something");
		setSpeakText(SPEAK_TYPE.BattleStart, "( . _ . )");
		setSpeakText(SPEAK_TYPE.BattleStart, "~ I say more");
		setSpeakText(SPEAK_TYPE.BattleStart, "We can defeat \n these guys ?");
		setSpeakText(SPEAK_TYPE.BattleStart, "We can run away · · · \n to ?");
		setSpeakText(SPEAK_TYPE.BattleStart, "Time or rice ?");
		setSpeakText(SPEAK_TYPE.BattleStart, "Rock On!");
		setSpeakText(SPEAK_TYPE.BattleStart, "Rock n roll!");
		setSpeakText(SPEAK_TYPE.BattleEnd, "It is a cinch !");
		setSpeakText(SPEAK_TYPE.BattleEnd, "Operation complete !");
		setSpeakText(SPEAK_TYPE.BattleEnd, "Truly master");
		setSpeakText(SPEAK_TYPE.BattleEnd, "(' - ') ( , _ , )");
		setSpeakText(SPEAK_TYPE.BattleEnd, "#NAME?");
		setSpeakText(SPEAK_TYPE.BattleEnd, "#NAME?");
		setSpeakText(SPEAK_TYPE.BattleEnd, "Victory o (^ _ ^) o");
		setSpeakText(SPEAK_TYPE.Damage, "Went well");
		setSpeakText(SPEAK_TYPE.Damage, "Ouch !");
		setSpeakText(SPEAK_TYPE.Damage, "/ (- _- ) /");
		setSpeakText(SPEAK_TYPE.Damage, "( ^ - ^ * )");
		setSpeakText(SPEAK_TYPE.Damage, "Innovation Innovation husband");
		setSpeakText(SPEAK_TYPE.Damage, "Is a formidable enemy");
		setSpeakText(SPEAK_TYPE.Damage, "It made \u200b\u200bdid dare");
		setSpeakText(SPEAK_TYPE.Damage, "Now the 're Gonna worked");
		setSpeakText(SPEAK_TYPE.Down, "Do not do quite");
		setSpeakText(SPEAK_TYPE.Down, "All Over ...");
		setSpeakText(SPEAK_TYPE.Down, "Oops!");
		setSpeakText(SPEAK_TYPE.Down, "Mugyu~tsu");
		setSpeakText(SPEAK_TYPE.Down, "There fuzz");
		setSpeakText(SPEAK_TYPE.Down, "N or ~");
		setSpeakText(SPEAK_TYPE.Dead, "Please help");
		setSpeakText(SPEAK_TYPE.Dead, "I will ask the rescue");
		setSpeakText(SPEAK_TYPE.Dead, "Is fatal");
		setSpeakText(SPEAK_TYPE.Dead, "<( __) > <( __) >");
		setSpeakText(SPEAK_TYPE.Dead, "N Well I'm sorry (> _ <) \n");
		setSpeakText(SPEAK_TYPE.Dead, "Does not work · · · \n body ...");
		setSpeakText(SPEAK_TYPE.Dead, "I was left · · · \n after ...");
		setSpeakText(SPEAK_TYPE.Dead, "I want to meet \n cocoa ...");
		setSpeakText(SPEAK_TYPE.Dead, "There was no \n not expect this to happen ... ...");
		setSpeakText(SPEAK_TYPE.Dead, "I become remote · · · \n consciousness ...");
		setSpeakText(SPEAK_TYPE.Revive, "Over still !");
		setSpeakText(SPEAK_TYPE.Revive, "Is nice");
		setSpeakText(SPEAK_TYPE.Revive, "Thank You \n master");
		setSpeakText(SPEAK_TYPE.Revive, "( ^ - ^ ) /");
		setSpeakText(SPEAK_TYPE.Revive, "I still work hard !");
		setSpeakText(SPEAK_TYPE.Revive, "I'll say thanks");
		setSpeakText(SPEAK_TYPE.Revive, "Innovation ... by Korase");
		setSpeakText(SPEAK_TYPE.UseMagic, "The ~ I spend magic");
		setSpeakText(SPEAK_TYPE.UseMagic, "Aaa Aaa gong !");
		setSpeakText(SPEAK_TYPE.UseMagic, "Leave it !");
		setSpeakText(SPEAK_TYPE.UseMagic, "( ^ - ^ ) /");
		setSpeakText(SPEAK_TYPE.UseMagic, "To receive the magic");
		setSpeakText(SPEAK_TYPE.UseMagic, "I gather power");
		setSpeakText(SPEAK_TYPE.UseMagic, "It's ! \n Showtime ♪");
		setSpeakText(SPEAK_TYPE.MagicMax, "I can use magic !");
		setSpeakText(SPEAK_TYPE.MagicMax, "- Which has been Minagi~tsu");
		setSpeakText(SPEAK_TYPE.MagicMax, "Magic tea - di");
		setSpeakText(SPEAK_TYPE.BossBattle, "This is a reinforcing layer \n!");
		setSpeakText(SPEAK_TYPE.BossBattle, "Different \n is until now ! \n Watch out!");
		setSpeakText(SPEAK_TYPE.BattleRandom, "- I'm over here !");
		setSpeakText(SPEAK_TYPE.BattleRandom, "It went left \n is here !");
		setSpeakText(SPEAK_TYPE.BattleRandom, "I'm disturbed !");
		setSpeakText(SPEAK_TYPE.BattleRandom, "Ahaha~tsu ☆");
		setSpeakText(SPEAK_TYPE.BattleRandom, "Is there!");
		setSpeakText(SPEAK_TYPE.ForestRandom, "It is also good mon forest \n once in a while");
		setSpeakText(SPEAK_TYPE.ForestRandom, "Leaves leaves ~");
		setSpeakText(SPEAK_TYPE.ForestRandom, "\n ~ I have a tree full");
		setSpeakText(SPEAK_TYPE.ForestRandom, "I passed \n also here a little while ago");
		setSpeakText(SPEAK_TYPE.ForestRandom, "~ I want to go");
		setSpeakText(SPEAK_TYPE.ForestRandom, "Mr. Trent wonder if \n Where am I?");
		setSpeakText(SPEAK_TYPE.TownRandom, "Stomach - I was reduced");
		setSpeakText(SPEAK_TYPE.TownRandom, "Tool:");
		setSpeakText(SPEAK_TYPE.TownRandom, "Cacao get Hisa ~");
		setSpeakText(SPEAK_TYPE.TownRandom, "Has become sleepy");
		setSpeakText(SPEAK_TYPE.TownRandom, "Soon . \n ~ Let's go somewhere");
		setSpeakText(SPEAK_TYPE.TownRandom, "I will sing one song \n number of spare time!");
		setSpeakText(SPEAK_TYPE.TownRandom, "♪ you sing third \n song of hungry");
		setSpeakText(SPEAK_TYPE.TownRandom, "~ Y ~ ♪ Ru et al ~ \n fees.");
		setSpeakText(SPEAK_TYPE.TownRandom, "Here I settle down \n most");
		setSpeakText(SPEAK_TYPE.Tutorial, "Tutorial ~");
		setSpeakText(SPEAK_TYPE.Tutorial, "♪ Good luck");
		setSpeakText(SPEAK_TYPE.Tutorial, "~ Some Chu ~ Chu ~ \n take");
		setSpeakText(SPEAK_TYPE.Tutorial, "Only some practice !");
		setSpeakText(SPEAK_TYPE.Tutorial, "\n The ~ Let Owaraseyo quickly");
		baseControl = GetComponent<BaseControl>();
		playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
	}

	private void setSpeakText(SPEAK_TYPE type, string text)
	{
		string[,] array = speakText;
		int[] array2 = speakTextMax;
		array[(int)type, array2[RuntimeServices.NormalizeArrayIndex(array2, (int)type)]] = text;
		int[] array3 = speakTextMax;
		int num = RuntimeServices.NormalizeArrayIndex(array3, (int)type);
		int[] array4 = speakTextMax;
		checked
		{
			array3[num] = array4[RuntimeServices.NormalizeArrayIndex(array4, unchecked((int)type))] + 1;
		}
	}

	public void Speak(SPEAK_TYPE type)
	{
		Speak(type, overwrite: false);
	}

	public void Speak(SPEAK_TYPE type, bool overwrite)
	{
		if (enabled)
		{
			noneSpeakTime = 8f + (float)UnityEngine.Random.Range(0, 5);
			if (baseControl.HitPoint > 0f || type == SPEAK_TYPE.Dead)
			{
				string[,] array = speakText;
				int[] array2 = speakTextMax;
				string text = array[(int)type, UnityEngine.Random.Range(0, array2[RuntimeServices.NormalizeArrayIndex(array2, (int)type)])];
				curText = text;
			}
		}
	}

	public void Update()
	{
		if (!enabled)
		{
			return;
		}
		noneSpeakTime -= Time.deltaTime;
		checked
		{
			if (!(noneSpeakTime > 0f))
			{
				count++;
				if (count == 0)
				{
					Speak(SPEAK_TYPE.TownRandom);
					return;
				}
				if (count == 1)
				{
					Speak(SPEAK_TYPE.Tutorial);
					return;
				}
				if (count == 2)
				{
					Speak(SPEAK_TYPE.ForestRandom);
					return;
				}
				Speak(SPEAK_TYPE.BattleRandom);
				count = 0;
			}
		}
	}
}
