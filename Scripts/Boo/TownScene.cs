using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class TownScene : MonoBehaviour
{
	[Serializable]
	public class PlayerStartPosition
	{
		[SceneIDEdit]
		public string preScene;

		public Transform position;
	}

	[Serializable]
	internal class _0024createPoppet_0024locals_002414339
	{
		internal AIControl _0024poppet;
	}

	[Serializable]
	internal class _0024createPoppet_0024closure_00243776
	{
		internal _0024createPoppet_0024locals_002414339 _0024_0024locals_002414784;

		public _0024createPoppet_0024closure_00243776(_0024createPoppet_0024locals_002414339 _0024_0024locals_002414784)
		{
			this._0024_0024locals_002414784 = _0024_0024locals_002414784;
		}

		public void Invoke(AIControl ai)
		{
			_0024_0024locals_002414784._0024poppet = ai;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024initialize_002416701 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241195_002416702;

			internal IEnumerator _0024_0024sco_0024temp_00241196_002416703;

			internal TownScene _0024self__002416704;

			public _0024(TownScene self_)
			{
				_0024self__002416704 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (noCreatePlayer)
					{
						noCreatePlayer = false;
						SceneChanger.Instance().dontReveal = false;
						goto case 1;
					}
					_0024_0024sco_0024temp_00241195_002416702 = _0024self__002416704.createPlayer();
					if (_0024_0024sco_0024temp_00241195_002416702 != null)
					{
						result = (Yield(2, _0024self__002416704.StartCoroutine(_0024_0024sco_0024temp_00241195_002416702)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024_0024sco_0024temp_00241196_002416703 = _0024self__002416704.createPoppet();
					if (_0024_0024sco_0024temp_00241196_002416703 != null)
					{
						result = (Yield(3, _0024self__002416704.StartCoroutine(_0024_0024sco_0024temp_00241196_002416703)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					SceneChanger.Instance().dontReveal = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TownScene _0024self__002416705;

		public _0024initialize_002416701(TownScene self_)
		{
			_0024self__002416705 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416705);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024createPlayer_002416706 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024basePos_002416707;

			internal string _0024preSceneName_002416708;

			internal PlayerStartPosition _0024psp_002416709;

			internal Vector3 _0024pos_002416710;

			internal Quaternion _0024rot_002416711;

			internal PlayerPoppetCache.PlayerParams _0024prm_002416712;

			internal int _0024_00248359_002416713;

			internal PlayerStartPosition[] _0024_00248360_002416714;

			internal int _0024_00248361_002416715;

			internal TownScene _0024self__002416716;

			public _0024(TownScene self_)
			{
				_0024self__002416716 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024basePos_002416707 = null;
						_0024preSceneName_002416708 = SceneChanger.LastSceneName;
						if (_0024self__002416716.playerPositions != null)
						{
							_0024_00248359_002416713 = 0;
							_0024_00248360_002416714 = _0024self__002416716.playerPositions;
							for (_0024_00248361_002416715 = _0024_00248360_002416714.Length; _0024_00248359_002416713 < _0024_00248361_002416715; _0024_00248359_002416713++)
							{
								if (_0024_00248360_002416714[_0024_00248359_002416713] != null && _0024preSceneName_002416708 == _0024_00248360_002416714[_0024_00248359_002416713].preScene)
								{
									_0024basePos_002416707 = _0024_00248360_002416714[_0024_00248359_002416713].position;
									break;
								}
							}
						}
						if (_0024basePos_002416707 == null)
						{
							_0024basePos_002416707 = _0024self__002416716.optPlayerInitialPos;
						}
						_0024pos_002416710 = _0024basePos_002416707.position;
						_0024rot_002416711 = _0024basePos_002416707.rotation;
						_0024prm_002416712 = new PlayerPoppetCache.PlayerParams();
						_0024prm_002416712.position = _0024pos_002416710;
						_0024prm_002416712.rotation = _0024rot_002416711;
						_0024prm_002416712.isBattleMode = false;
						_0024self__002416716.player = PlayerPoppetCache.Instance.getPlayer(_0024prm_002416712);
						goto case 2;
					case 2:
						if (!_0024self__002416716.player.IsReady)
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
				}
				return (byte)result != 0;
			}
		}

		internal TownScene _0024self__002416717;

		public _0024createPlayer_002416706(TownScene self_)
		{
			_0024self__002416717 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416717);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024createPoppet_002416718 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024t_002416719;

			internal _0024createPoppet_0024locals_002414339 _0024_0024locals_002416720;

			internal TownScene _0024self__002416721;

			public _0024(TownScene self_)
			{
				_0024self__002416721 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416720 = new _0024createPoppet_0024locals_002414339();
					_0024_0024locals_002416720._0024poppet = null;
					PlayerPoppetCache.Instance.getPoppetFromUserData(new _0024createPoppet_0024closure_00243776(_0024_0024locals_002416720).Invoke);
					goto case 2;
				case 2:
					if (!(_0024_0024locals_002416720._0024poppet != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024locals_002416720._0024poppet.AIMODE_ChasePlayer();
					if (_0024_0024locals_002416720._0024poppet != null && _0024self__002416721.optMuppetInitialPos != null && _0024self__002416721.optMuppetInitialPos.Length > 0)
					{
						_0024t_002416719 = _0024self__002416721.optMuppetInitialPos[0];
						if (_0024t_002416719 != null)
						{
							_0024_0024locals_002416720._0024poppet.transform.position = _0024t_002416719.position;
							_0024_0024locals_002416720._0024poppet.transform.rotation = _0024t_002416719.rotation;
						}
					}
					if (_0024self__002416721.player != null && _0024_0024locals_002416720._0024poppet != null)
					{
						_0024self__002416721.player.addPoppet(_0024_0024locals_002416720._0024poppet);
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

		internal TownScene _0024self__002416722;

		public _0024createPoppet_002416718(TownScene self_)
		{
			_0024self__002416722 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416722);
		}
	}

	[NonSerialized]
	public static bool noCreatePlayer;

	private PlayerControl player;

	public Transform optPlayerInitialPos;

	public Transform[] optMuppetInitialPos;

	public PlayerStartPosition[] playerPositions;

	public void Start()
	{
		SceneChanger.Instance().dontReveal = true;
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001Town");
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			IEnumerator enumerator = initialize();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		});
	}

	private IEnumerator initialize()
	{
		return new _0024initialize_002416701(this).GetEnumerator();
	}

	private IEnumerator createPlayer()
	{
		return new _0024createPlayer_002416706(this).GetEnumerator();
	}

	private IEnumerator createPoppet()
	{
		return new _0024createPoppet_002416718(this).GetEnumerator();
	}

	internal void _0024Start_0024closure_00243775()
	{
		IEnumerator enumerator = initialize();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}
}
