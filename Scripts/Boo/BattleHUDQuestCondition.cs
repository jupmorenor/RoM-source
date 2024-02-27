using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDQuestCondition : MonoBehaviour
{
	[Serializable]
	public class Label
	{
		public UILabel[] ラベル;

		public string Text
		{
			set
			{
				int i = 0;
				UILabel[] labels = Labels;
				for (int length = labels.Length; i < length; i = checked(i + 1))
				{
					if (labels[i] != null)
					{
						labels[i].text = value;
					}
				}
			}
		}

		public bool HasLabel
		{
			get
			{
				int num = 0;
				UILabel[] labels = Labels;
				int length = labels.Length;
				int result;
				while (true)
				{
					if (num < length)
					{
						if (labels[num] != null)
						{
							result = 1;
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public UILabel[] Labels => ラベル;
	}

	[Serializable]
	public class InfoBase
	{
		public GameObject 根元;

		private float aliveTime;

		private bool dispAllTime;

		public GameObject Root => 根元;

		public float AliveTime => aliveTime;

		public bool DispAllTime
		{
			get
			{
				return dispAllTime;
			}
			set
			{
				dispAllTime = value;
			}
		}

		public void start()
		{
			if (!(Root == null))
			{
				aliveTime = 10f;
				activate(b: true);
			}
		}

		public void activate(bool b)
		{
			if (!(Root == null) && Root.active != b)
			{
				Root.SetActive(b);
				int i = 0;
				UITweener[] components = Root.GetComponents<UITweener>();
				for (int length = components.Length; i < length; i = checked(i + 1))
				{
					components[i].Play(forward: true);
					components[i].Reset();
				}
			}
		}

		public void update(float dt)
		{
			if (!(Root == null))
			{
				bool num = dispAllTime;
				if (!num)
				{
					num = aliveTime > 0f;
				}
				activate(num);
			}
		}

		public void disable()
		{
			dispAllTime = false;
			aliveTime = 0f;
		}
	}

	[Serializable]
	public class MonsterInfo : InfoBase
	{
		public Label モンスタ名;

		public Label 討伐数;

		public Label クリア必要数;

		public Label MonsterName => モンスタ名;

		public Label KilledNum => 討伐数;

		public Label Total => クリア必要数;

		public void setInfo(string mname, int killed, int total)
		{
			start();
			if (MonsterName != null)
			{
				MonsterName.Text = new StringBuilder().Append(mname).ToString();
			}
			if (KilledNum.HasLabel && Total.HasLabel)
			{
				KilledNum.Text = new StringBuilder().Append((object)killed).ToString();
				Total.Text = new StringBuilder().Append((object)total).ToString();
			}
			else if (KilledNum != null)
			{
				KilledNum.Text = new StringBuilder().Append((object)killed).Append("/").Append((object)total)
					.ToString();
			}
		}
	}

	[Serializable]
	public class AllMonsterInfo : InfoBase
	{
		public Label ラベル;

		public Label 討伐数;

		public Label Name => ラベル;

		public Label Num => 討伐数;

		public void setInfo(string name, int killedNum, int total)
		{
			start();
			if (Name != null && !string.IsNullOrEmpty(name))
			{
				Name.Text = name;
			}
			if (Num.HasLabel)
			{
				Num.Text = new StringBuilder().Append((object)killedNum).Append("/").Append((object)total)
					.ToString();
			}
		}

		public void setInfo(string name, int killedNum)
		{
			start();
			if (Name != null && !string.IsNullOrEmpty(name))
			{
				Name.Text = name;
			}
			if (Num.HasLabel)
			{
				Num.Text = new StringBuilder().Append((object)killedNum).ToString();
			}
		}
	}

	[Serializable]
	public class KusamushiInfo : InfoBase
	{
		public Label 草虫名;

		public Label 拾得数;

		public Label 全草虫数;

		public Label Name => 草虫名;

		public Label PickedNum => 拾得数;

		public Label Total => 全草虫数;

		public void setNum(string name, int pickedNum, int total)
		{
			start();
			if (Name != null)
			{
				Name.Text = name;
			}
			if (PickedNum.HasLabel && PickedNum.HasLabel)
			{
				PickedNum.Text = new StringBuilder().Append((object)pickedNum).ToString();
				Total.Text = new StringBuilder().Append((object)total).ToString();
			}
			else if (PickedNum.HasLabel)
			{
				PickedNum.Text = new StringBuilder().Append((object)pickedNum).Append("/").Append((object)total)
					.ToString();
			}
		}
	}

	[Serializable]
	public class ChallengeInfo : InfoBase
	{
		public Label ポイント名;

		public Label 取得ポイント;

		public Label PointName => ポイント名;

		public Label Point => 取得ポイント;

		public void setPoint(int point)
		{
			start();
			Point.Text = new StringBuilder().Append((object)point).ToString();
		}
	}

	[NonSerialized]
	private const float DISP_TIME = 10f;

	public MonsterInfo 特定モンスター討伐情報;

	public AllMonsterInfo 全モンスター討伐情報;

	public KusamushiInfo 草虫クエスト情報;

	public ChallengeInfo チャレンジ情報;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDQuestCondition> _InstanceList = new Boo.Lang.List<BattleHUDQuestCondition>();

	public static BattleHUDQuestCondition Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public static MonsterInfo MonsterDisp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__MonsterDisp;
		}
	}

	public static AllMonsterInfo AllMonsterDisp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__AllMonsterDisp;
		}
	}

	public static KusamushiInfo KusamushiDisp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__KusamushiDisp;
		}
	}

	public static ChallengeInfo ChallengeDisp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__ChallengeDisp;
		}
	}

	public MonsterInfo __MonsterDisp => 特定モンスター討伐情報;

	public AllMonsterInfo __AllMonsterDisp => 全モンスター討伐情報;

	public KusamushiInfo __KusamushiDisp => 草虫クエスト情報;

	public ChallengeInfo __ChallengeDisp => チャレンジ情報;

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void dispCondAllEnemies(int killed, int num)
	{
		IEnumerator<BattleHUDQuestCondition> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDQuestCondition current = enumerator.Current;
				current.__dispCondAllEnemies(killed, num);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __dispCondAllEnemies(int killed, int num)
	{
		AllMonsterDisp.setInfo("討伐数", killed, num);
	}

	public static void dispCondSomeEnemies(int monsterId, int killed, int num)
	{
		IEnumerator<BattleHUDQuestCondition> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDQuestCondition current = enumerator.Current;
				current.__dispCondSomeEnemies(monsterId, killed, num);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __dispCondSomeEnemies(int monsterId, int killed, int num)
	{
		MMonsters mMonsters = MMonsters.Get(monsterId);
		string mname = ((mMonsters != null) ? mMonsters.Name.ToString() : "モンスター");
		MonsterDisp.setInfo(mname, killed, num);
	}

	public static void dispChallengeRankingPoint(int pointOfThisQuest)
	{
		IEnumerator<BattleHUDQuestCondition> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDQuestCondition current = enumerator.Current;
				current.__dispChallengeRankingPoint(pointOfThisQuest);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __dispChallengeRankingPoint(int pointOfThisQuest)
	{
		ChallengeDisp.setPoint(pointOfThisQuest);
	}

	public static void dispKusamushi(string kname, int pickedUpNum, int totalNum)
	{
		IEnumerator<BattleHUDQuestCondition> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDQuestCondition current = enumerator.Current;
				current.__dispKusamushi(kname, pickedUpNum, totalNum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __dispKusamushi(string kname, int pickedUpNum, int totalNum)
	{
		KusamushiDisp.setNum(kname, pickedUpNum, totalNum);
	}

	public void Start()
	{
		if (MonsterDisp == null)
		{
			throw new AssertionFailedException("「特定モンスター討伐情報」が未設定");
		}
		if (AllMonsterDisp == null)
		{
			throw new AssertionFailedException("「全モンスター討伐情報」が未設定");
		}
		if (KusamushiDisp == null)
		{
			throw new AssertionFailedException("「草生しクエスト情報」が未設定");
		}
		if (ChallengeDisp == null)
		{
			throw new AssertionFailedException("「チャレンジ情報」が未設定");
		}
	}

	public void Update()
	{
		float deltaTime = Time.deltaTime;
		int i = 0;
		InfoBase[] array = new InfoBase[4] { MonsterDisp, AllMonsterDisp, KusamushiDisp, ChallengeDisp };
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].update(deltaTime);
		}
	}
}
