using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ABProxy : MonoBehaviour
{
	[Serializable]
	public enum InitModes
	{
		None,
		MonsterControlPlayerSide,
		MonsterControlMonsterSide
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002415291 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002415292;

			internal RuntimeAssetBundleDB.Req _0024r_002415293;

			internal GameObject _0024obj_002415294;

			internal AIControl _0024ai_002415295;

			internal PlayerControl _0024pl_002415296;

			internal MonsterControllerViaAIControl _0024mcvac_002415297;

			internal BaseControl _0024bc_002415298;

			internal GameObject _0024rco_002415299;

			internal RaidCamera _0024rc_002415300;

			internal ABProxy _0024self__002415301;

			public _0024(ABProxy self_)
			{
				_0024self__002415301 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002415292 = RuntimeAssetBundleDB.Instance;
					if (_0024self__002415301.WithInstantiation)
					{
						_0024r_002415293 = _0024abdb_002415292.instantiatePrefab(_0024self__002415301.NameOrPath);
					}
					else
					{
						_0024r_002415293 = _0024abdb_002415292.loadPrefab(_0024self__002415301.NameOrPath);
					}
					goto case 2;
				case 2:
					if (!_0024r_002415293.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024obj_002415294 = null;
					_0024obj_002415294 = _0024r_002415293.Prefab;
					if (_0024obj_002415294 != null)
					{
						_0024obj_002415294.transform.position = _0024self__002415301.transform.position;
						_0024obj_002415294.transform.rotation = _0024self__002415301.transform.rotation;
						if (_0024self__002415301.IsPoppetMode)
						{
							_0024ai_002415295 = _0024obj_002415294.GetComponent<AIControl>();
							if (_0024ai_002415295 != null)
							{
								_0024pl_002415296 = null;
								goto case 3;
							}
						}
						goto IL_01b2;
					}
					goto IL_0301;
				case 3:
					_0024pl_002415296 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024pl_002415296 != null)
					{
						goto case 4;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 4:
					if (!_0024pl_002415296.IsReady)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024pl_002415296.addPoppet(_0024ai_002415295);
					goto IL_01b2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01b2:
					_0024mcvac_002415297 = null;
					if (_0024self__002415301.InitializeMode == InitModes.MonsterControlPlayerSide)
					{
						_0024mcvac_002415297 = ExtensionsModule.SetComponent<MonsterControllerViaAIControl>(_0024obj_002415294);
						_0024mcvac_002415297.setPlayerSide(isPlayer: true);
					}
					else if (_0024self__002415301.InitializeMode == InitModes.MonsterControlMonsterSide)
					{
						_0024mcvac_002415297 = ExtensionsModule.SetComponent<MonsterControllerViaAIControl>(_0024obj_002415294);
						_0024mcvac_002415297.setPlayerSide(isPlayer: false);
					}
					if (_0024self__002415301.NoDamage)
					{
						_0024bc_002415298 = _0024obj_002415294.GetComponent<BaseControl>();
						if (_0024bc_002415298 != null)
						{
							_0024bc_002415298.noDamage = true;
						}
					}
					if (_0024self__002415301.RaidCam && !_0024self__002415301.IsPoppetMode)
					{
						_0024rco_002415299 = GameObject.Find("RaidCamera");
						if (_0024rco_002415299 != null)
						{
							_0024rc_002415300 = _0024rco_002415299.GetComponent<RaidCamera>();
							if (_0024obj_002415294.name.Substring(0, 1) == "C")
							{
								_0024rc_002415300.player = _0024obj_002415294.transform;
							}
							else
							{
								_0024rc_002415300.boss = _0024obj_002415294.transform;
							}
						}
					}
					goto IL_0301;
					IL_0301:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal ABProxy _0024self__002415302;

		public _0024main_002415291(ABProxy self_)
		{
			_0024self__002415302 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415302);
		}
	}

	public string 名前かパス;

	public bool 魔ペットモード;

	public bool Instantiateする;

	public bool 無敵モード;

	public bool RaidCameraに登録;

	public InitModes 初期モード;

	public string NameOrPath => 名前かパス;

	public bool IsPoppetMode => 魔ペットモード;

	public bool WithInstantiation => Instantiateする;

	public bool NoDamage => 無敵モード;

	public bool RaidCam => RaidCameraに登録;

	public InitModes InitializeMode => 初期モード;

	public ABProxy()
	{
		Instantiateする = true;
		初期モード = InitModes.None;
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002415291(this).GetEnumerator();
	}
}
