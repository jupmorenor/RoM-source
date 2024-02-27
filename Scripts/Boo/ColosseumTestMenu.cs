using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumTestMenu : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024play_002417410 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumSession _0024session_002417411;

			internal ColosseumSession.StartParams _0024param_002417412;

			internal RespOpponent _0024op_002417413;

			public _0024(RespOpponent op)
			{
				_0024op_002417413 = op;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024op_002417413 == null)
					{
						throw new AssertionFailedException("op != null");
					}
					_0024session_002417411 = ColosseumSession.Instance;
					_0024param_002417412 = new ColosseumSession.StartParams(_0024op_002417413);
					_0024param_002417412.nextScene = "ColosseumResultTest";
					_0024session_002417411.startSessionCustom(_0024param_002417412);
					goto case 2;
				case 2:
					if (_0024session_002417411.IsPreparing)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RespOpponent _0024op_002417414;

		public _0024play_002417410(RespOpponent op)
		{
			_0024op_002417414 = op;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024op_002417414);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024commTest_002417415 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ColosseumSession _0024session_002417416;

			internal ColosseumSession.StartParams _0024param_002417417;

			internal RespOpponent _0024op_002417418;

			public _0024(RespOpponent op)
			{
				_0024op_002417418 = op;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024session_002417416 = ColosseumSession.Instance;
					_0024param_002417417 = new ColosseumSession.StartParams(_0024op_002417418);
					_0024param_002417417.execBattle = false;
					_0024session_002417416.startSessionCustom(_0024param_002417417);
					goto case 2;
				case 2:
					if (_0024session_002417416.IsPreparing)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024session_002417416.HasError)
					{
						_0024session_002417416.closeSession();
						goto case 3;
					}
					goto IL_00b1;
				case 3:
					if (_0024session_002417416.IsClosing)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_00b1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b1:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal RespOpponent _0024op_002417419;

		public _0024commTest_002417415(RespOpponent op)
		{
			_0024op_002417419 = op;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024op_002417419);
		}
	}

	private RespOpponent[] opponents;

	private Vector2 scrollPos;

	private RespOpponentWithOrganize[] friends;

	public void Start()
	{
		init();
	}

	private void init()
	{
		opponents = null;
		ApiColosseumOpponentList req = new ApiColosseumOpponentList();
		MerlinServer.Request(req, _0024adaptor_0024__ColosseumTestMenu_init_0024callable527_002413_36___0024__MerlinServer_Request_0024callable86_0024160_56___0024139.Adapt(initFin));
		ApiColosseumFriendOpponentList req2 = new ApiColosseumFriendOpponentList();
		MerlinServer.Request(req2, _0024adaptor_0024__ColosseumTestMenu_init_0024callable529_002415_37___0024__MerlinServer_Request_0024callable86_0024160_56___0024140.Adapt(initFriendFin));
	}

	private void initFin(ApiColosseumOpponentList r)
	{
		if (r == null)
		{
			throw new AssertionFailedException("r != null");
		}
		opponents = r.GetResponse().Opponent;
	}

	private void initFriendFin(ApiColosseumFriendOpponentList r)
	{
		if (r == null)
		{
			throw new AssertionFailedException("r != null");
		}
		friends = r.GetResponse().Opponent;
	}

	public void OnGUI()
	{
		GUILayout.Label("Opponents");
		scrollPos = GUILayout.BeginScrollView(scrollPos);
		if (GUILayout.Button("<refresh>"))
		{
			init();
		}
		if (opponents == null)
		{
			GUILayout.Label("requesting...");
		}
		else
		{
			int i = 0;
			RespOpponent[] array = opponents;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				string value = ((!array[i].IsNPC) ? string.Empty : "NPC");
				string text = new StringBuilder().Append(value).Append(" ").Append((object)array[i].TSocialPlayerId)
					.Append(" ")
					.Append(array[i].Name)
					.Append(" lv")
					.Append((object)array[i].Level)
					.Append(" point:")
					.Append(array[i].BreederRankPoint)
					.ToString();
				if (GUILayout.Button(text))
				{
					IEnumerator enumerator = play(array[i]);
					if (enumerator != null)
					{
						StartCoroutine(enumerator);
					}
				}
			}
		}
		GUILayout.EndScrollView();
		if (GUILayout.Button("test using Opponent[0]"))
		{
			IEnumerator enumerator2 = commTest(opponents[0]);
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
		GUILayout.Space(20f);
		if (GUILayout.Button("load file test"))
		{
			ColosseumSession.Instance.load();
		}
	}

	private IEnumerator play(RespOpponent op)
	{
		return new _0024play_002417410(op).GetEnumerator();
	}

	private IEnumerator commTest(RespOpponent op)
	{
		return new _0024commTest_002417415(op).GetEnumerator();
	}
}
