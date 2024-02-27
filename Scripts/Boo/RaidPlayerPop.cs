using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class RaidPlayerPop : MonoBehaviour
{
	[Serializable]
	public struct PlayerInfo
	{
		public GameObject instance;

		public string name;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002416861 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_002416862;

			internal int _0024_00248468_002416863;

			internal int _0024_00248469_002416864;

			internal RaidPlayerPop _0024self__002416865;

			public _0024(RaidPlayerPop self_)
			{
				_0024self__002416865 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				case 2:
					_0024_00248468_002416863 = 0;
					_0024_00248469_002416864 = _0024self__002416865.playersInfo.Length;
					if (_0024_00248469_002416864 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (_0024_00248468_002416863 < _0024_00248469_002416864)
					{
						_0024i_002416862 = _0024_00248468_002416863;
						_0024_00248468_002416863++;
						PlayerInfo[] playersInfo = _0024self__002416865.playersInfo;
						if (playersInfo[RuntimeServices.NormalizeArrayIndex(playersInfo, _0024i_002416862)].instance == null)
						{
							PlayerInfo[] playersInfo2 = _0024self__002416865.playersInfo;
							playersInfo2[RuntimeServices.NormalizeArrayIndex(playersInfo2, _0024i_002416862)].instance = (GameObject)UnityEngine.Object.Instantiate(_0024self__002416865.playerPrefab, new Vector3(0f, 0f, 25f), Quaternion.identity);
							PlayerInfo[] playersInfo3 = _0024self__002416865.playersInfo;
							playersInfo3[RuntimeServices.NormalizeArrayIndex(playersInfo3, _0024i_002416862)].name = _0024self__002416865.getRandomName();
							PlayerInfo[] playersInfo4 = _0024self__002416865.playersInfo;
							BaseControl component = playersInfo4[RuntimeServices.NormalizeArrayIndex(playersInfo4, _0024i_002416862)].instance.GetComponent<BaseControl>();
							PlayerInfo[] playersInfo5 = _0024self__002416865.playersInfo;
							component.namae = playersInfo5[RuntimeServices.NormalizeArrayIndex(playersInfo5, _0024i_002416862)].name;
							break;
						}
					}
					goto default;
				default:
					result = (((!(_0024self__002416865.bossControl.HitPoint > 0f)) ? Yield(3, new WaitForSeconds(2f)) : Yield(2, new WaitForSeconds(5f))) ? 1 : 0);
					break;
				case 3:
					SceneChanger.ChangeTo(SceneID.Ui_WorldRaidResult);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RaidPlayerPop _0024self__002416866;

		public _0024mainRoutine_002416861(RaidPlayerPop self_)
		{
			_0024self__002416866 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002416866);
		}
	}

	protected readonly int MAX_RAID_PLAYER_NUM;

	public PlayerInfo[] playersInfo;

	public GameObject playerPrefab;

	private UIDynamicFontLabel playerList;

	private AIControl bossControl;

	public RaidPlayerPop()
	{
		MAX_RAID_PLAYER_NUM = 16;
		playersInfo = new PlayerInfo[MAX_RAID_PLAYER_NUM];
	}

	public void Start()
	{
		playersInfo[0].instance = PlayerControl.CurrentPlayer.gameObject;
		playersInfo[0].name = "マーリン";
		GameObject gameObject = GameObject.Find("UI Root (2D)/Camera/Panel/AnchorCenter/Panel/PlayerList");
		if ((bool)gameObject)
		{
			playerList = gameObject.GetComponent<UIDynamicFontLabel>();
		}
		gameObject = GameObject.Find("E5001_ROOT");
		if ((bool)gameObject)
		{
			bossControl = gameObject.GetComponent<AIControl>();
		}
		StartCoroutine(mainRoutine());
	}

	public void Update()
	{
		playerList.m_Text = string.Empty;
		int num = 0;
		int length = playersInfo.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			PlayerInfo[] array = playersInfo;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)].instance)
			{
				UIDynamicFontLabel uIDynamicFontLabel = playerList;
				string text = playerList.m_Text;
				PlayerInfo[] array2 = playersInfo;
				uIDynamicFontLabel.m_Text = text + (array2[RuntimeServices.NormalizeArrayIndex(array2, index)].name + "\n");
			}
		}
	}

	public IEnumerator mainRoutine()
	{
		return new _0024mainRoutine_002416861(this).GetEnumerator();
	}

	public string getRandomName()
	{
		string text = null;
		return UnityEngine.Random.Range(0, 23) switch
		{
			0 => "前野 信太郎", 
			1 => "堀内 雅史", 
			2 => "相田 倫太郎", 
			3 => "井澤 一海", 
			4 => "早稲田 広一", 
			5 => "徳舛 久妙子", 
			6 => "神田 祥司", 
			7 => "山本 学", 
			8 => "鈴木 健吾", 
			9 => "松本 隆芳", 
			10 => "西森 丈俊", 
			11 => "八木 正人", 
			12 => "小山田 将", 
			13 => "娯匠", 
			14 => "Fixer", 
			15 => "鈴木 裕之", 
			16 => "釜野 竜", 
			17 => "松岡 清一", 
			18 => "中村 次男", 
			19 => "田口 晃啓", 
			20 => "堀ノ内 健太", 
			21 => "中島 翌", 
			_ => "スクエニ", 
		};
	}
}
