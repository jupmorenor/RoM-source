using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class GameLevelManager : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadAssetObject_002418187 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024path_002418188;

			internal UnityEngine.Object _0024o_002418189;

			internal GameObject _0024dst_002418190;

			internal RuntimeAssetBundleDB _0024abdb_002418191;

			internal RuntimeAssetBundleDB.Req _0024r_002418192;

			internal string _0024fileName_002418193;

			public _0024(string fileName)
			{
				_0024fileName_002418193 = fileName;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					loadAssetObject[_0024fileName_002418193] = null;
					_0024path_002418188 = Path.Combine("Prefab/", _0024fileName_002418193);
					_0024o_002418189 = GameAssetModule.LoadPrefab(_0024path_002418188);
					_0024dst_002418190 = null;
					if (_0024o_002418189 == null)
					{
						_0024abdb_002418191 = RuntimeAssetBundleDB.Instance;
						_0024r_002418192 = _0024abdb_002418191.loadPrefab(_0024path_002418188);
						goto case 2;
					}
					if ((bool)_0024o_002418189)
					{
						_0024dst_002418190 = UnityEngine.Object.Instantiate(_0024o_002418189) as GameObject;
					}
					goto IL_012b;
				case 2:
					if (!_0024r_002418192.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024r_002418192.IsOk)
					{
						if (!(_0024r_002418192.Prefab != null))
						{
							throw new AssertionFailedException("r.Prefab != null");
						}
						_0024dst_002418190 = ((GameObject)UnityEngine.Object.Instantiate(_0024r_002418192.Prefab)) as GameObject;
					}
					goto IL_012b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_012b:
					if (_0024dst_002418190 != null)
					{
						_0024dst_002418190.SetActive(value: false);
					}
					loadAssetObject[_0024fileName_002418193] = _0024dst_002418190;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024fileName_002418194;

		public _0024LoadAssetObject_002418187(string fileName)
		{
			_0024fileName_002418194 = fileName;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024fileName_002418194);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupGameLevel_002418195 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal DateTime _0024today_002418196;

			internal UserData _0024ud_002418197;

			internal MScenes _0024defGl_002418198;

			internal MScenes _0024extGl_002418199;

			internal int _0024questId_002418200;

			internal QuestManager _0024questMan_002418201;

			internal int _0024n_002418202;

			internal MScenes _0024gl_002418203;

			internal IEnumerator _0024_0024sco_0024temp_00241616_002418204;

			internal bool _0024res_002418205;

			internal IEnumerator _0024_0024sco_0024temp_00241617_002418206;

			internal int _0024_00249138_002418207;

			internal MScenes[] _0024_00249139_002418208;

			internal int _0024_00249140_002418209;

			internal string _0024sceneName_002418210;

			internal int _0024divCount_002418211;

			internal GameLevelManager _0024self__002418212;

			public _0024(string sceneName, int divCount, GameLevelManager self_)
			{
				_0024sceneName_002418210 = sceneName;
				_0024divCount_002418211 = divCount;
				_0024self__002418212 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024sceneName_002418210 == "Ui_TitleLogo" || _0024sceneName_002418210 == "Boot" || _0024sceneName_002418210 == "Ui_Download")
						{
							goto case 1;
						}
						goto case 2;
					case 2:
						if (isBusy)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						isBusy = true;
						_0024self__002418212.lastSetupScene = _0024sceneName_002418210;
						_0024today_002418196 = MerlinDateTime.UtcNow;
						_0024ud_002418197 = UserData.Current;
						_0024defGl_002418198 = null;
						_0024extGl_002418199 = null;
						_0024self__002418212.CurMScene = null;
						_0024questId_002418200 = -1;
						_0024questMan_002418201 = QuestManager.Instance;
						if ((bool)_0024questMan_002418201 && _0024questMan_002418201.CurQuest != null)
						{
							_0024questId_002418200 = _0024questMan_002418201.CurQuest.Id;
						}
						_0024n_002418202 = 0;
						_0024_00249138_002418207 = 0;
						_0024_00249139_002418208 = MScenes.All;
						_0024_00249140_002418209 = _0024_00249139_002418208.Length;
						goto IL_01e2;
					case 3:
						_0024n_002418202++;
						if (_0024self__002418212.CheckArea(_0024sceneName_002418210, _0024questId_002418200, _0024today_002418196, _0024_00249139_002418208[_0024_00249138_002418207], ref _0024defGl_002418198))
						{
							_0024self__002418212.curMScene = _0024_00249139_002418208[_0024_00249138_002418207];
						}
						_0024_00249138_002418207++;
						goto IL_01e2;
					case 4:
						_0024_0024sco_0024temp_00241616_002418204 = _0024self__002418212.SetupGameLevelCore(_0024self__002418212.curMScene);
						if (_0024_0024sco_0024temp_00241616_002418204 != null)
						{
							result = (Yield(5, _0024self__002418212.StartCoroutine(_0024_0024sco_0024temp_00241616_002418204)) ? 1 : 0);
							break;
						}
						goto case 5;
					case 5:
						GameSoundManager.Instance.LoadSceneSe(_0024self__002418212.curMScene);
						if (_0024self__002418212.curMScene != null)
						{
							_0024extGl_002418199 = _0024self__002418212.curMScene.ExtMScenes;
						}
						if (_0024extGl_002418199 != null)
						{
							_0024res_002418205 = true;
							if (!CheckCondition(_0024extGl_002418199.AllConditions, notFlag: false))
							{
								_0024res_002418205 = false;
							}
							if (!CheckCondition(_0024extGl_002418199.AllNotConditions, notFlag: true))
							{
								_0024res_002418205 = false;
							}
							if (_0024res_002418205)
							{
								_0024_0024sco_0024temp_00241617_002418206 = _0024self__002418212.SetupGameLevelCore(_0024extGl_002418199);
								if (_0024_0024sco_0024temp_00241617_002418206 != null)
								{
									result = (Yield(6, _0024self__002418212.StartCoroutine(_0024_0024sco_0024temp_00241617_002418206)) ? 1 : 0);
									break;
								}
							}
						}
						goto case 6;
					case 6:
						isBusy = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01e2:
						if (_0024_00249138_002418207 < _0024_00249140_002418209)
						{
							if (_0024divCount_002418211 <= _0024n_002418202 && _0024divCount_002418211 > 0)
							{
								_0024n_002418202 = 0;
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							goto case 3;
						}
						if (_0024self__002418212.curMScene == null)
						{
							_0024self__002418212.curMScene = _0024defGl_002418198;
						}
						GameSoundManager.Instance.CurMScene = _0024self__002418212.curMScene;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sceneName_002418213;

		internal int _0024divCount_002418214;

		internal GameLevelManager _0024self__002418215;

		public _0024SetupGameLevel_002418195(string sceneName, int divCount, GameLevelManager self_)
		{
			_0024sceneName_002418213 = sceneName;
			_0024divCount_002418214 = divCount;
			_0024self__002418215 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024sceneName_002418213, _0024divCount_002418214, _0024self__002418215);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupGameLevelCore_002418216 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal UserData _0024ud_002418217;

			internal MNpcs _0024npc_002418218;

			internal IEnumerator _0024_0024sco_0024temp_00241618_002418219;

			internal int _0024_00249142_002418220;

			internal MNpcs[] _0024_00249143_002418221;

			internal int _0024_00249144_002418222;

			internal MScenes _0024gl_002418223;

			internal GameLevelManager _0024self__002418224;

			public _0024(MScenes gl, GameLevelManager self_)
			{
				_0024gl_002418223 = gl;
				_0024self__002418224 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024gl_002418223 != null)
						{
							_0024self__002418224.SetSceneTmpFlag(_0024gl_002418223);
							_0024ud_002418217 = UserData.Current;
							if (_0024ud_002418217 != null)
							{
								_0024self__002418224.playerConditionNumber = _0024ud_002418217.userMiscInfo.flagData.ConditionNumber;
							}
							_0024_00249142_002418220 = 0;
							_0024_00249143_002418221 = _0024gl_002418223.AllNpcs;
							_0024_00249144_002418222 = _0024_00249143_002418221.Length;
							goto IL_00eb;
						}
						goto IL_00fc;
					case 2:
						_0024_00249142_002418220++;
						goto IL_00eb;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00fc:
						YieldDefault(1);
						goto case 1;
						IL_00eb:
						if (_0024_00249142_002418220 < _0024_00249144_002418222)
						{
							_0024_0024sco_0024temp_00241618_002418219 = _0024self__002418224.PutNpc(_0024_00249143_002418221[_0024_00249142_002418220]);
							if (_0024_0024sco_0024temp_00241618_002418219 != null)
							{
								result = (Yield(2, _0024self__002418224.StartCoroutine(_0024_0024sco_0024temp_00241618_002418219)) ? 1 : 0);
								break;
							}
							goto case 2;
						}
						goto IL_00fc;
					}
				}
				return (byte)result != 0;
			}
		}

		internal MScenes _0024gl_002418225;

		internal GameLevelManager _0024self__002418226;

		public _0024SetupGameLevelCore_002418216(MScenes gl, GameLevelManager self_)
		{
			_0024gl_002418225 = gl;
			_0024self__002418226 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024gl_002418225, _0024self__002418226);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetupSceneCore_002418227 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal MNpcs _0024npc_002418228;

			internal IEnumerator _0024_0024sco_0024temp_00241619_002418229;

			internal int _0024_00249146_002418230;

			internal MNpcs[] _0024_00249147_002418231;

			internal int _0024_00249148_002418232;

			internal MScenes _0024scene_002418233;

			internal GameLevelManager _0024self__002418234;

			public _0024(MScenes scene, GameLevelManager self_)
			{
				_0024scene_002418233 = scene;
				_0024self__002418234 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024scene_002418233 != null)
						{
							_0024_00249146_002418230 = 0;
							_0024_00249147_002418231 = _0024scene_002418233.AllNpcs;
							_0024_00249148_002418232 = _0024_00249147_002418231.Length;
							goto IL_00a4;
						}
						goto IL_00b5;
					case 2:
						_0024_00249146_002418230++;
						goto IL_00a4;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00a4:
						if (_0024_00249146_002418230 < _0024_00249148_002418232)
						{
							_0024_0024sco_0024temp_00241619_002418229 = _0024self__002418234.PutNpc(_0024_00249147_002418231[_0024_00249146_002418230]);
							if (_0024_0024sco_0024temp_00241619_002418229 != null)
							{
								result = (Yield(2, _0024self__002418234.StartCoroutine(_0024_0024sco_0024temp_00241619_002418229)) ? 1 : 0);
								break;
							}
							goto case 2;
						}
						goto IL_00b5;
						IL_00b5:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal MScenes _0024scene_002418235;

		internal GameLevelManager _0024self__002418236;

		public _0024SetupSceneCore_002418227(MScenes scene, GameLevelManager self_)
		{
			_0024scene_002418235 = scene;
			_0024self__002418236 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024scene_002418235, _0024self__002418236);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReplaceBg_002418237 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal GameObject _0024newBg_002418238;

			internal GameObject _0024oldBg_002418239;

			internal string _0024fileName_002418240;

			internal IEnumerator _0024_0024sco_0024temp_00241620_002418241;

			internal IEnumerator _0024_0024sco_0024temp_00241621_002418242;

			internal TweenAlpha _0024twAlpOld_002418243;

			internal float _0024_002412529_002418244;

			internal Quaternion _0024_002412530_002418245;

			internal string[] _0024prefabArray_002418246;

			internal GameLevelManager _0024self__002418247;

			public _0024(string[] prefabArray, GameLevelManager self_)
			{
				_0024prefabArray_002418246 = prefabArray;
				_0024self__002418247 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024prefabArray_002418246 != null)
					{
						_0024newBg_002418238 = null;
						_0024oldBg_002418239 = null;
						if (_0024prefabArray_002418246.Length >= 2)
						{
							_0024fileName_002418240 = _0024prefabArray_002418246[1];
							loadAssetObject.Remove(_0024fileName_002418240);
							_0024_0024sco_0024temp_00241620_002418241 = _0024self__002418247.LoadAssetObject(_0024fileName_002418240);
							if (_0024_0024sco_0024temp_00241620_002418241 != null)
							{
								result = (Yield(2, _0024self__002418247.StartCoroutine(_0024_0024sco_0024temp_00241620_002418241)) ? 1 : 0);
								break;
							}
							goto case 2;
						}
						if (_0024prefabArray_002418246.Length == 1)
						{
							_0024fileName_002418240 = _0024prefabArray_002418246[0];
							loadAssetObject.Remove(_0024fileName_002418240);
							_0024_0024sco_0024temp_00241621_002418242 = _0024self__002418247.LoadAssetObject(_0024fileName_002418240);
							if (_0024_0024sco_0024temp_00241621_002418242 != null)
							{
								result = (Yield(4, _0024self__002418247.StartCoroutine(_0024_0024sco_0024temp_00241621_002418242)) ? 1 : 0);
								break;
							}
							goto case 4;
						}
						goto IL_02b8;
					}
					goto IL_0331;
				case 2:
				case 3:
				{
					if (!loadAssetObject.ContainsKey(_0024fileName_002418240))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					object obj2 = loadAssetObject[_0024fileName_002418240];
					if (!(obj2 is GameObject))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
					}
					_0024newBg_002418238 = (GameObject)obj2;
					loadAssetObject.Remove(_0024fileName_002418240);
					_0024oldBg_002418239 = GameObject.Find(_0024prefabArray_002418246[0]) as GameObject;
					if ((bool)_0024oldBg_002418239 && (bool)_0024newBg_002418238)
					{
						_0024newBg_002418238.transform.localPosition = _0024oldBg_002418239.transform.localPosition;
						float num = (_0024_002412529_002418244 = _0024oldBg_002418239.transform.localRotation.y);
						Quaternion quaternion = (_0024_002412530_002418245 = _0024newBg_002418238.transform.localRotation);
						float num2 = (_0024_002412530_002418245.y = _0024_002412529_002418244);
						Quaternion quaternion3 = (_0024newBg_002418238.transform.localRotation = _0024_002412530_002418245);
					}
					goto IL_02b8;
				}
				case 4:
				case 5:
				{
					if (!loadAssetObject.ContainsKey(_0024fileName_002418240))
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					object obj = loadAssetObject[_0024fileName_002418240];
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					_0024newBg_002418238 = (GameObject)obj;
					loadAssetObject.Remove(_0024fileName_002418240);
					goto IL_02b8;
				}
				case 1:
					{
						result = 0;
						break;
					}
					IL_02b8:
					if ((bool)_0024oldBg_002418239)
					{
						_0024twAlpOld_002418243 = TweenAlpha.Begin(_0024oldBg_002418239, 0.5f, 0f);
						_0024twAlpOld_002418243._from = 1f;
						_0024twAlpOld_002418243.to = 0f;
						UnityEngine.Object.DestroyObject(_0024oldBg_002418239, 1f);
					}
					if ((bool)_0024newBg_002418238)
					{
						_0024newBg_002418238.SetActive(value: true);
					}
					goto IL_0331;
					IL_0331:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string[] _0024prefabArray_002418248;

		internal GameLevelManager _0024self__002418249;

		public _0024ReplaceBg_002418237(string[] prefabArray, GameLevelManager self_)
		{
			_0024prefabArray_002418248 = prefabArray;
			_0024self__002418249 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024prefabArray_002418248, _0024self__002418249);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PutNpc_002418250 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal bool _0024posFlag_002418251;

			internal GameObject _0024newNpc_002418252;

			internal bool _0024needNpcParent_002418253;

			internal NpcTalkControl _0024npcTalkCtrl_002418254;

			internal NpcTalkControl _0024tmpNpcTalkCtrl_002418255;

			internal NPCControl _0024tmpNpcCtrl_002418256;

			internal string _0024actPrefab_002418257;

			internal string _0024inactPrefab_002418258;

			internal IEnumerator _0024_0024sco_0024temp_00241622_002418259;

			internal GameObject _0024altNpc_002418260;

			internal IEnumerator _0024_0024sco_0024temp_00241623_002418261;

			internal GameObject _0024oldNpc_002418262;

			internal AnimationEventHandler _0024animEventHandler_002418263;

			internal GimmickControl[] _0024gimmicks_002418264;

			internal GimmickControl _0024gimmick_002418265;

			internal GameObject _0024npcParent_002418266;

			internal int _0024_00249168_002418267;

			internal GimmickControl[] _0024_00249169_002418268;

			internal int _0024_00249170_002418269;

			internal object[] _0024_002413650_002418270;

			internal MNpcs _0024npc_002418271;

			internal GameLevelManager _0024self__002418272;

			public _0024(MNpcs npc, GameLevelManager self_)
			{
				_0024npc_002418271 = npc;
				_0024self__002418272 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024posFlag_002418251 = true;
						if (_0024npc_002418271 != null)
						{
							_0024newNpc_002418252 = null;
							_0024needNpcParent_002418253 = default(bool);
							if (_0024self__002418272.npcTable.ContainsKey(_0024npc_002418271.Id))
							{
								object obj = _0024self__002418272.npcTable[_0024npc_002418271.Id];
								if (!(obj is NpcTalkControl))
								{
									obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
								}
								_0024npcTalkCtrl_002418254 = (NpcTalkControl)obj;
								if ((bool)_0024npcTalkCtrl_002418254)
								{
									_0024newNpc_002418252 = _0024npcTalkCtrl_002418254.gameObject;
								}
								if ((bool)_0024newNpc_002418252)
								{
									_0024posFlag_002418251 = false;
								}
							}
							if (CheckNpc(_0024npc_002418271))
							{
								if (!_0024newNpc_002418252)
								{
									if (!string.IsNullOrEmpty(_0024npc_002418271.SceneObject))
									{
										_0024newNpc_002418252 = GameObject.Find(_0024npc_002418271.SceneObject);
										if ((bool)_0024newNpc_002418252)
										{
											_0024self__002418272.putSceneOriginalObjectTable[_0024newNpc_002418252.GetInstanceID()] = _0024newNpc_002418252;
										}
										if ((bool)_0024newNpc_002418252)
										{
											_0024tmpNpcTalkCtrl_002418255 = _0024newNpc_002418252.GetComponent<NpcTalkControl>();
											if (!_0024tmpNpcTalkCtrl_002418255)
											{
												_0024newNpc_002418252.AddComponent(typeof(TempNpcTalkControl));
											}
											_0024tmpNpcCtrl_002418256 = _0024newNpc_002418252.GetComponent<NPCControl>();
											if (!_0024tmpNpcCtrl_002418256)
											{
												_0024tmpNpcCtrl_002418256 = (TempNPCControl)_0024newNpc_002418252.AddComponent(typeof(TempNPCControl));
												_0024tmpNpcCtrl_002418256.Pause = true;
											}
											_0024needNpcParent_002418253 = false;
										}
									}
									if (!_0024newNpc_002418252)
									{
										_0024_002413650_002418270 = _0024self__002418272.activeDeactivePrefab(_0024npc_002418271);
										object obj2 = _0024_002413650_002418270[0];
										if (!(obj2 is string))
										{
											obj2 = RuntimeServices.Coerce(obj2, typeof(string));
										}
										_0024actPrefab_002418257 = (string)obj2;
										object obj3 = _0024_002413650_002418270[1];
										if (!(obj3 is string))
										{
											obj3 = RuntimeServices.Coerce(obj3, typeof(string));
										}
										_0024inactPrefab_002418258 = (string)obj3;
										if (!string.IsNullOrEmpty(_0024inactPrefab_002418258))
										{
											loadAssetObject.Remove(_0024inactPrefab_002418258);
											_0024_0024sco_0024temp_00241622_002418259 = _0024self__002418272.LoadAssetObject(_0024inactPrefab_002418258);
											if (_0024_0024sco_0024temp_00241622_002418259 != null)
											{
												result = (Yield(2, _0024self__002418272.StartCoroutine(_0024_0024sco_0024temp_00241622_002418259)) ? 1 : 0);
												break;
											}
											goto case 2;
										}
										goto IL_0369;
									}
									goto IL_044a;
								}
							}
							else
							{
								if ((bool)_0024newNpc_002418252)
								{
									_0024self__002418272.npcTable.Remove(_0024npc_002418271.Id);
									_0024self__002418272.DestroyNpc(_0024newNpc_002418252);
									_0024newNpc_002418252 = null;
								}
								if (_0024npc_002418271.DestroySceneObjectIfNotShow)
								{
									_0024self__002418272.DisableObjectIfExists(_0024npc_002418271.SceneObject);
								}
							}
							goto IL_05ef;
						}
						goto IL_08df;
					case 2:
					case 3:
					{
						if (!loadAssetObject.ContainsKey(_0024inactPrefab_002418258))
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						object obj4 = loadAssetObject[_0024inactPrefab_002418258];
						if (!(obj4 is GameObject))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(GameObject));
						}
						_0024altNpc_002418260 = (GameObject)obj4;
						loadAssetObject.Remove(_0024inactPrefab_002418258);
						if (_0024altNpc_002418260 != null)
						{
							UnityEngine.Object.Destroy(_0024altNpc_002418260);
						}
						goto IL_0369;
					}
					case 4:
					{
						object obj5 = loadAssetObject[_0024actPrefab_002418257];
						if (!(obj5 is GameObject))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(GameObject));
						}
						_0024newNpc_002418252 = (GameObject)obj5;
						if (!(_0024newNpc_002418252 != null))
						{
							throw new AssertionFailedException(new StringBuilder("could not load ").Append(_0024npc_002418271.Prefab).ToString());
						}
						loadAssetObject.Remove(_0024actPrefab_002418257);
						_0024needNpcParent_002418253 = true;
						goto IL_044a;
					}
					case 1:
						{
							result = 0;
							break;
						}
						IL_044a:
						if (!_0024newNpc_002418252)
						{
							_0024newNpc_002418252 = new GameObject();
							_0024newNpc_002418252.name = "no_prefab";
							_0024needNpcParent_002418253 = true;
						}
						if (!string.IsNullOrEmpty(_0024npc_002418271.NpcNoDupId))
						{
							if (_0024self__002418272.npcNoDupIdTable.ContainsKey(_0024npc_002418271.NpcNoDupId))
							{
								object obj6 = _0024self__002418272.npcNoDupIdTable[_0024npc_002418271.NpcNoDupId];
								if (!(obj6 is GameObject))
								{
									obj6 = RuntimeServices.Coerce(obj6, typeof(GameObject));
								}
								_0024oldNpc_002418262 = (GameObject)obj6;
								if ((bool)_0024oldNpc_002418262)
								{
									_0024newNpc_002418252.transform.position = _0024oldNpc_002418262.transform.position;
									_0024newNpc_002418252.transform.rotation = _0024oldNpc_002418262.transform.rotation;
									_0024posFlag_002418251 = false;
									_0024self__002418272.DestroyNpc(_0024oldNpc_002418262);
								}
							}
							_0024self__002418272.npcNoDupIdTable[_0024npc_002418271.NpcNoDupId] = _0024newNpc_002418252;
						}
						goto IL_05ef;
						IL_05ef:
						if ((bool)_0024newNpc_002418252)
						{
							_0024newNpc_002418252.SetActive(value: true);
							_0024npcTalkCtrl_002418254 = ExtensionsModule.SetComponent<NpcTalkControl>(_0024newNpc_002418252);
							if ((bool)_0024npcTalkCtrl_002418254)
							{
								_0024animEventHandler_002418263 = _0024newNpc_002418252.GetComponent<AnimationEventHandler>();
								_0024npcTalkCtrl_002418254.enabled = true;
								_0024npcTalkCtrl_002418254.Init(_0024npc_002418271);
								_0024self__002418272.npcTable[_0024npc_002418271.Id] = _0024npcTalkCtrl_002418254;
								if (_0024posFlag_002418251)
								{
									SetNpcPos(_0024newNpc_002418252.transform, _0024npc_002418271.PositionObject);
								}
								NpcTalkControl.SetupNpcAction(_0024npcTalkCtrl_002418254.NPCControl, _0024npc_002418271.Action, _0024npc_002418271.Loop);
								_0024self__002418272.PauseNpc(_0024npcTalkCtrl_002418254.NPCControl, _0024npc_002418271.Pause);
								_0024self__002418272.SetNpcMoveType(_0024npcTalkCtrl_002418254.NPCControl, _0024npc_002418271.MoveInitType);
								if (_0024npc_002418271.GimmickFlag != null)
								{
									_0024gimmicks_002418264 = new GimmickControl[0];
									_0024gimmicks_002418264 = (GimmickControl[])RuntimeServices.AddArrays(typeof(GimmickControl), _0024gimmicks_002418264, _0024newNpc_002418252.GetComponentsInChildren<GimmickControl>(includeInactive: true));
									if (_0024gimmicks_002418264.Length == 0)
									{
										_0024gimmicks_002418264 = new GimmickControl[1] { _0024newNpc_002418252.AddComponent<GimmickControl>() };
									}
									_0024_00249168_002418267 = 0;
									_0024_00249169_002418268 = _0024gimmicks_002418264;
									for (_0024_00249170_002418269 = _0024_00249169_002418268.Length; _0024_00249168_002418267 < _0024_00249170_002418269; _0024_00249168_002418267++)
									{
										if ((bool)_0024_00249169_002418268[_0024_00249168_002418267])
										{
											_0024_00249169_002418268[_0024_00249168_002418267].Flag = _0024npc_002418271.GimmickFlag;
											_0024_00249169_002418268[_0024_00249168_002418267].enabled = true;
										}
									}
								}
								if (_0024needNpcParent_002418253)
								{
									_0024npcParent_002418266 = new GameObject();
									_0024npcParent_002418266.name = _0024npc_002418271.Progname;
									_0024newNpc_002418252.transform.parent = _0024npcParent_002418266.transform;
								}
								if ((bool)_0024animEventHandler_002418263)
								{
									_0024animEventHandler_002418263.RestoreFromHidden = true;
								}
							}
							else
							{
								_0024self__002418272.DestroyNpc(_0024newNpc_002418252);
								_0024newNpc_002418252 = null;
								if (_0024self__002418272.npcTable.ContainsKey(_0024npc_002418271.Id))
								{
									_0024self__002418272.npcTable.Remove(_0024npc_002418271.Id);
								}
							}
						}
						goto IL_08df;
						IL_08df:
						YieldDefault(1);
						goto case 1;
						IL_0369:
						if (!string.IsNullOrEmpty(_0024actPrefab_002418257))
						{
							loadAssetObject.Remove(_0024actPrefab_002418257);
							_0024_0024sco_0024temp_00241623_002418261 = _0024self__002418272.LoadAssetObject(_0024actPrefab_002418257);
							if (_0024_0024sco_0024temp_00241623_002418261 != null)
							{
								result = (Yield(4, _0024self__002418272.StartCoroutine(_0024_0024sco_0024temp_00241623_002418261)) ? 1 : 0);
								break;
							}
							goto case 4;
						}
						goto IL_044a;
					}
				}
				return (byte)result != 0;
			}
		}

		internal MNpcs _0024npc_002418273;

		internal GameLevelManager _0024self__002418274;

		public _0024PutNpc_002418250(MNpcs npc, GameLevelManager self_)
		{
			_0024npc_002418273 = npc;
			_0024self__002418274 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024npc_002418273, _0024self__002418274);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024setFlagWithFade_0024routine_00243789_002418275 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002418276;

			internal PlayerControl _0024pl_002418277;

			internal FaderCore _0024fader_002418278;

			internal float _0024_0024wait_sec_0024temp_00241626_002418279;

			internal MFlags _0024flag_002418280;

			public _0024(MFlags flag)
			{
				_0024flag_002418280 = flag;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024flag_002418280 != null)
					{
						_0024ud_002418276 = UserData.Current;
						if (!_0024ud_002418276.hasFlag(_0024flag_002418280.Progname))
						{
							_0024pl_002418277 = PlayerControl.CurrentPlayer;
							if (_0024pl_002418277 != null)
							{
								_0024pl_002418277.forceToIdle();
								_0024pl_002418277.InputActive = false;
							}
							_0024fader_002418278 = FaderCore.Instance;
							_0024fader_002418278.fadeInEx(1f, 1f, 1f, 0.5f);
							goto case 2;
						}
					}
					goto case 1;
				case 2:
					if (!_0024fader_002418278.isCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024ud_002418276.setFlag(_0024flag_002418280.Progname);
					SendNpcTalkEndEvent();
					_0024_0024wait_sec_0024temp_00241626_002418279 = 0.5f;
					goto case 3;
				case 3:
					if (_0024_0024wait_sec_0024temp_00241626_002418279 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241626_002418279 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024fader_002418278.fadeOutEx(1f, 1f, 1f, 0.5f);
					if (_0024pl_002418277 != null)
					{
						_0024pl_002418277.InputActive = true;
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

		internal MFlags _0024flag_002418281;

		public _0024_0024setFlagWithFade_0024routine_00243789_002418275(MFlags flag)
		{
			_0024flag_002418281 = flag;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024flag_002418281);
		}
	}

	[NonSerialized]
	private static GameLevelManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public static bool isBusy;

	[NonSerialized]
	protected static Hashtable loadAssetObject = new Hashtable();

	public bool testFlag;

	protected GameObject player;

	protected int playerConditionNumber;

	protected string lastSceneName;

	protected string lastSetupScene;

	protected Hashtable npcTable;

	protected Hashtable npcNoDupIdTable;

	protected Hashtable putSceneOriginalObjectTable;

	protected Hashtable nextKeepSceneObjectTable;

	protected Hashtable curKeepSceneObjectTable;

	public MScenes curMScene;

	public string sceneTmpFlag;

	public bool simulate;

	public bool sceneChangeWait;

	protected CutSceneManager cutSceneManager;

	protected EventWindow eventWindow;

	[NonSerialized]
	protected static int stopWorldCount;

	[NonSerialized]
	protected const int initStopWorldCount = 10;

	[NonSerialized]
	private static __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024event_0024NpcTalkEndEvent;

	public static GameLevelManager Instance
	{
		get
		{
			GameLevelManager _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((GameLevelManager)UnityEngine.Object.FindObjectOfType(typeof(GameLevelManager))) as GameLevelManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static GameLevelManager CurrentInstance => __instance;

	public GameObject KeepSceneObject
	{
		set
		{
			nextKeepSceneObjectTable[value.GetInstanceID()] = value;
		}
	}

	public static bool IsBusy => isBusy;

	public MScenes CurMScene
	{
		get
		{
			return curMScene;
		}
		set
		{
			curMScene = value;
		}
	}

	public string SceneTmpFlag
	{
		get
		{
			return sceneTmpFlag;
		}
		set
		{
			sceneTmpFlag = value;
		}
	}

	public bool SimulateFlag
	{
		get
		{
			return simulate;
		}
		set
		{
			simulate = value;
		}
	}

	public bool SceneChangeWait
	{
		get
		{
			return sceneChangeWait;
		}
		set
		{
			sceneChangeWait = value;
		}
	}

	public static event __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ NpcTalkEndEvent
	{
		add
		{
			_0024event_0024NpcTalkEndEvent = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Combine(_0024event_0024NpcTalkEndEvent, value);
		}
		remove
		{
			_0024event_0024NpcTalkEndEvent = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)Delegate.Remove(_0024event_0024NpcTalkEndEvent, value);
		}
	}

	public GameLevelManager()
	{
		playerConditionNumber = -1;
		npcTable = new Hashtable();
		npcNoDupIdTable = new Hashtable();
		putSceneOriginalObjectTable = new Hashtable();
		nextKeepSceneObjectTable = new Hashtable();
		curKeepSceneObjectTable = new Hashtable();
	}

	public void _0024singleton_0024awake_00241612()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241612();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static GameLevelManager _createInstance()
	{
		string text = "__" + "GameLevelManager" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		GameLevelManager gameLevelManager = ExtensionsModule.SetComponent<GameLevelManager>(gameObject);
		if ((bool)gameLevelManager)
		{
			gameLevelManager._createInstance_callback();
		}
		return gameLevelManager;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241613()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241613();
		quitApp = true;
	}

	[SpecialName]
	protected internal static void raise_NpcTalkEndEvent()
	{
		_0024event_0024NpcTalkEndEvent?.Invoke();
	}

	public void OnGUI_()
	{
		if (testFlag && GUILayout.Button("GameLevelManager Test"))
		{
			IEnumerator enumerator = SetupGameLevel(SceneChanger.CurrentSceneName, 0);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void Start()
	{
		if (!player)
		{
			PlayerControl playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
			if ((bool)playerControl)
			{
				player = playerControl.gameObject;
			}
		}
		UserData current = UserData.Current;
		if (current != null)
		{
			playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
		}
	}

	public void OnDestory()
	{
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void Update()
	{
		NpcManagement();
		SceneTmpFlagCtrl();
	}

	public void SceneTmpFlagCtrl()
	{
		SetSceneTmpFlag(curMScene);
	}

	public void SetSceneTmpFlag(MScenes scene)
	{
		UserData current = UserData.Current;
		if (current != null)
		{
			SetSceneTmpFlagCore(current.userMiscInfo.flagData, scene, ref sceneTmpFlag);
		}
	}

	public static void SetSceneTmpFlagCore(UserMiscInfo.FlagData flagData, MScenes scene, ref string tmpFlaga)
	{
		if (scene == null || scene.TempFlag == null || scene.TempFlag.Progname == tmpFlaga)
		{
			return;
		}
		if (!string.IsNullOrEmpty(tmpFlaga))
		{
			flagData.delete(tmpFlaga);
			flagData.deleteAllStartWith(tmpFlaga + "_");
		}
		if (scene.TempFlag != null)
		{
			tmpFlaga = scene.TempFlag.Progname;
			if (!string.IsNullOrEmpty(tmpFlaga))
			{
				flagData.set(tmpFlaga, 1);
			}
		}
	}

	public IEnumerator LoadAssetObject(string fileName)
	{
		return new _0024LoadAssetObject_002418187(fileName).GetEnumerator();
	}

	public bool CheckArea(string sceneName, int questId, DateTime today, MScenes scene, ref MScenes defScene)
	{
		UserData current = UserData.Current;
		return current != null && CheckAreaCore(current.userMiscInfo.flagData, sceneName, questId, today, scene, ref defScene);
	}

	public static bool CheckAreaCore(UserMiscInfo.FlagData flagData, string sceneName, int questId, DateTime today, MScenes scene, ref MScenes defScene)
	{
		int result;
		if (scene.SceneName != sceneName)
		{
			result = 0;
		}
		else if (scene.MQuestId != null && scene.MQuestId.Id != questId)
		{
			result = 0;
		}
		else if (today < scene.BeginPeriod)
		{
			result = 0;
		}
		else if (scene.EndPeriod <= today && (int)scene.EndPeriod.Ticks != 0)
		{
			result = 0;
		}
		else
		{
			if (!IsValidCondition(scene.AllConditions) && !IsValidCondition(scene.AllNotConditions) && defScene == null)
			{
				defScene = scene;
			}
			result = (CheckConditionCore(flagData, scene.AllConditions, notFlag: false) ? (CheckConditionCore(flagData, scene.AllNotConditions, notFlag: true) ? 1 : 0) : 0);
		}
		return (byte)result != 0;
	}

	public void Setup(string sceneName)
	{
		IEnumerator enumerator = SetupGameLevel(sceneName, 100);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator SetupGameLevel(string sceneName, int divCount)
	{
		return new _0024SetupGameLevel_002418195(sceneName, divCount, this).GetEnumerator();
	}

	public IEnumerator SetupGameLevelCore(MScenes gl)
	{
		return new _0024SetupGameLevelCore_002418216(gl, this).GetEnumerator();
	}

	public IEnumerator SetupSceneCore(MScenes scene)
	{
		return new _0024SetupSceneCore_002418227(scene, this).GetEnumerator();
	}

	public static MNpcTalks[] SimulateGameLevel(string sceneName)
	{
		MNpcTalks[] array = new MNpcTalks[0];
		UserData current = UserData.Current;
		checked
		{
			MNpcTalks[] result;
			if (current == null)
			{
				result = array;
			}
			else
			{
				UserMiscInfo.FlagData flagData = new UserMiscInfo.FlagData();
				object obj = current.userMiscInfo.flagData.Flags.Clone();
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				flagData.Flags = (Hashtable)obj;
				DateTime utcNow = MerlinDateTime.UtcNow;
				MScenes defScene = null;
				MScenes mScenes = null;
				int questId = -1;
				QuestManager instance = QuestManager.Instance;
				if ((bool)instance && instance.CurQuest != null)
				{
					questId = instance.CurQuest.Id;
				}
				MScenes mScenes2 = null;
				int i = 0;
				MScenes[] all = MScenes.All;
				for (int length = all.Length; i < length; i++)
				{
					if (CheckAreaCore(flagData, sceneName, questId, utcNow, all[i], ref defScene))
					{
						mScenes2 = all[i];
					}
				}
				if (mScenes2 == null)
				{
					mScenes2 = defScene;
				}
				if (mScenes2 != null)
				{
					string tmpFlaga = Instance.sceneTmpFlag;
					SetSceneTmpFlagCore(flagData, mScenes2, ref tmpFlaga);
					int j = 0;
					MNpcs[] allNpcs = mScenes2.AllNpcs;
					for (int length2 = allNpcs.Length; j < length2; j++)
					{
						array = (MNpcTalks[])RuntimeServices.AddArrays(typeof(MNpcTalks), array, SimulateNpc(flagData, mScenes2, allNpcs[j]));
					}
					mScenes = mScenes2.ExtMScenes;
					if (mScenes != null)
					{
						bool flag = true;
						if (!CheckConditionCore(flagData, mScenes.AllConditions, notFlag: false))
						{
							flag = false;
						}
						if (!CheckConditionCore(flagData, mScenes.AllNotConditions, notFlag: true))
						{
							flag = false;
						}
						int k = 0;
						MNpcs[] allNpcs2 = mScenes.AllNpcs;
						for (int length3 = allNpcs2.Length; k < length3; k++)
						{
							array = (MNpcTalks[])RuntimeServices.AddArrays(typeof(MNpcTalks), array, SimulateNpc(flagData, mScenes, allNpcs2[k]));
						}
					}
				}
				result = array;
			}
			return result;
		}
	}

	public IEnumerator ReplaceBg(string[] prefabArray)
	{
		return new _0024ReplaceBg_002418237(prefabArray, this).GetEnumerator();
	}

	public static bool CheckNpc(MNpcs npc)
	{
		int result;
		if (npc == null)
		{
			result = 0;
		}
		else
		{
			UserData current = UserData.Current;
			result = ((current != null && CheckNpcCore(current.userMiscInfo.flagData, npc)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public static bool CheckNpcCore(UserMiscInfo.FlagData flagData, MNpcs npc)
	{
		return npc != null && CheckConditionCore(flagData, npc.AllConditions, notFlag: false) && (CheckConditionCore(flagData, npc.AllNotConditions, notFlag: true) ? true : false);
	}

	public static void SetNpcPos(Transform tf, string posString)
	{
		if (string.IsNullOrEmpty(posString))
		{
			return;
		}
		GameObject gameObject = GameObject.Find(posString) as GameObject;
		if ((bool)gameObject)
		{
			tf.position = gameObject.transform.position;
			tf.rotation = gameObject.transform.rotation;
			return;
		}
		if (posString.ToLower().StartsWith("yang:"))
		{
			try
			{
				float y = float.Parse(posString.Substring(5));
				tf.rotation = Quaternion.Euler(0f, y, 0f);
				return;
			}
			catch (Exception)
			{
				string message = new StringBuilder("position string format error: '").Append(posString).Append("'").ToString();
				throw new Exception(message);
			}
		}
		string[] array = posString.Split(',');
		try
		{
			float[] array2 = new float[0];
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				Type typeFromHandle = typeof(float);
				float[] lhs = array2;
				float[] array3 = new float[1];
				array3[0] = float.Parse(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
				array2 = (float[])RuntimeServices.AddArrays(typeFromHandle, lhs, array3);
			}
			int length2 = array2.Length;
			if (length2 >= 1)
			{
				float x = array2[0];
				Vector3 position = tf.position;
				float num2 = (position.x = x);
				Vector3 vector2 = (tf.position = position);
			}
			if (length2 >= 2)
			{
				float y2 = array2[1];
				Vector3 position2 = tf.position;
				float num3 = (position2.y = y2);
				Vector3 vector4 = (tf.position = position2);
			}
			if (length2 >= 3)
			{
				float z = array2[2];
				Vector3 position3 = tf.position;
				float num4 = (position3.z = z);
				Vector3 vector6 = (tf.position = position3);
			}
			if (length2 >= 4)
			{
				tf.rotation = Quaternion.Euler(0f, array2[3], 0f);
			}
		}
		catch (Exception)
		{
			string message = new StringBuilder("position string format error: '").Append(posString).Append("'\ntoks: ").ToString();
			int num5 = 0;
			int length3 = array.Length;
			if (length3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num5 < length3)
			{
				int index2 = num5;
				num5++;
				message += array[RuntimeServices.NormalizeArrayIndex(array, index2)] + " ";
			}
			throw new Exception(message);
		}
	}

	public static object[] ParseNpcPos(string posString, Vector3 defaultPos, Quaternion defaultRot)
	{
		if (string.IsNullOrEmpty(posString))
		{
			throw new Exception("position string format error: posString is null or empty");
		}
		GameObject gameObject = GameObject.Find(posString) as GameObject;
		object result;
		if ((bool)gameObject)
		{
			result = new object[2]
			{
				gameObject.transform.position,
				gameObject.transform.rotation
			};
		}
		else
		{
			object[] array;
			if (posString.ToLower().StartsWith("yang:"))
			{
				try
				{
					float y = float.Parse(posString.Substring(5));
					array = new object[2]
					{
						defaultPos,
						Quaternion.Euler(0f, y, 0f)
					};
				}
				catch (Exception)
				{
					string message = new StringBuilder("position string format error: '").Append(posString).Append("'").ToString();
					throw new Exception(message);
				}
			}
			else
			{
				string[] array2 = posString.Split(',');
				try
				{
					float[] array3 = new float[0];
					int num = 0;
					int length = array2.Length;
					if (length < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num < length)
					{
						int index = num;
						num++;
						Type typeFromHandle = typeof(float);
						float[] lhs = array3;
						float[] array4 = new float[1];
						array4[0] = float.Parse(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
						array3 = (float[])RuntimeServices.AddArrays(typeFromHandle, lhs, array4);
					}
					int length2 = array3.Length;
					Vector3 vector = defaultPos;
					Quaternion quaternion = defaultRot;
					if (length2 >= 1)
					{
						vector.x = array3[0];
					}
					if (length2 >= 2)
					{
						vector.y = array3[1];
					}
					if (length2 >= 3)
					{
						vector.z = array3[2];
					}
					if (length2 >= 4)
					{
						quaternion = Quaternion.Euler(0f, array3[3], 0f);
					}
					array = new object[2] { vector, quaternion };
				}
				catch (Exception)
				{
					string message = new StringBuilder("position string format error: '").Append(posString).Append("'\ntoks: ").ToString() + Builtins.join(array2, "\n");
					throw new Exception(message);
				}
			}
			result = array;
		}
		return (object[])result;
	}

	public bool DestroyNpc(GameObject npcObj)
	{
		int result;
		if (!npcObj)
		{
			result = 0;
		}
		else
		{
			string text = null;
			GameObject gameObject = null;
			TempNpcTalkControl component = npcObj.GetComponent<TempNpcTalkControl>();
			if ((bool)component && component.MNpcs != null)
			{
				text = component.MNpcs.Progname;
			}
			if (!component)
			{
				UnityEngine.Object.Destroy(component);
			}
			TempNPCControl component2 = npcObj.GetComponent<TempNPCControl>();
			if (!component2)
			{
				UnityEngine.Object.Destroy(component2);
			}
			if (putSceneOriginalObjectTable.ContainsKey(npcObj.GetInstanceID()))
			{
				putSceneOriginalObjectTable.Remove(npcObj.GetInstanceID());
				result = 1;
			}
			else
			{
				if ((bool)npcObj.transform.parent)
				{
					gameObject = npcObj.transform.parent.gameObject;
				}
				UnityEngine.Object.DestroyObject(npcObj);
				if ((bool)gameObject && gameObject.name == text)
				{
					UnityEngine.Object.DestroyObject(gameObject);
				}
				result = 1;
			}
		}
		return (byte)result != 0;
	}

	private void DisableObjectIfExists(string objPath)
	{
		if (!string.IsNullOrEmpty(objPath))
		{
			GameObject gameObject = GameObject.Find(objPath);
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void HideNpc(int npcId)
	{
		if (npcTable.ContainsKey(npcId))
		{
			object obj = npcTable[npcId];
			if (!(obj is NpcTalkControl))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
			}
			NpcTalkControl npcTalkControl = (NpcTalkControl)obj;
			if (npcTalkControl != null)
			{
				npcTalkControl.gameObject.SetActive(value: false);
			}
		}
	}

	public Transform GetNpcTransform(int npcId)
	{
		object result;
		if (!npcTable.ContainsKey(npcId))
		{
			result = null;
		}
		else
		{
			object obj = npcTable[npcId];
			if (!(obj is NpcTalkControl))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
			}
			NpcTalkControl npcTalkControl = (NpcTalkControl)obj;
			result = ((!(npcTalkControl != null)) ? null : npcTalkControl.transform);
		}
		return (Transform)result;
	}

	public IEnumerator PutNpc(MNpcs npc)
	{
		return new _0024PutNpc_002418250(npc, this).GetEnumerator();
	}

	public static MNpcTalks[] SimulateNpc(UserMiscInfo.FlagData flagData, MScenes scnene, MNpcs npc)
	{
		MNpcTalks[] array = new MNpcTalks[0];
		string dstGroupId = null;
		int dstTalkId = default(int);
		int dstRaceTalkId = default(int);
		int dstRaceTalkId2 = default(int);
		if (npc != null && CheckNpcCore(flagData, npc))
		{
			array = (MNpcTalks[])RuntimeServices.AddArrays(typeof(MNpcTalks), array, NpcTalkControl.CheckTalksCore(flagData, scnene, npc, ref dstGroupId, ref dstTalkId, ref dstRaceTalkId, ref dstRaceTalkId2));
		}
		return array;
	}

	private object[] activeDeactivePrefab(MNpcs npc)
	{
		return (npc == null) ? new object[2] : ((npc.PrefabCond != null && !CheckCondition(new MFlags[1] { npc.PrefabCond }, notFlag: true)) ? new string[2] { npc.AltPrefab, npc.Prefab } : new string[2] { npc.Prefab, npc.AltPrefab });
	}

	public void SetNpcMoveType(NPCControl npcCtrl, EnumNPCMoveInitTypes t)
	{
		if (!(npcCtrl == null))
		{
			switch (t)
			{
			case EnumNPCMoveInitTypes.On:
				npcCtrl.isMove = true;
				break;
			case EnumNPCMoveInitTypes.Off:
				npcCtrl.isMove = false;
				break;
			}
		}
	}

	public void PauseNpc(NPCControl npcCtrl, bool pause)
	{
		if ((bool)npcCtrl.animation)
		{
			IEnumerator enumerator = npcCtrl.animation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				if (pause)
				{
					animationState.speed = 0f;
				}
			}
		}
		if ((bool)npcCtrl)
		{
			npcCtrl.Pause = pause;
		}
	}

	public void KeepSceneObjectAllClear()
	{
		if (curKeepSceneObjectTable != null)
		{
			object[] array = Builtins.array(curKeepSceneObjectTable.Keys);
			int i = 0;
			object[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.ToBool(curKeepSceneObjectTable[array2[i]]))
				{
					object obj = curKeepSceneObjectTable[array2[i]];
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					DestroyNpc((GameObject)obj);
				}
			}
			curKeepSceneObjectTable.Clear();
		}
		else
		{
			curKeepSceneObjectTable = new Hashtable();
		}
		Hashtable hashtable = curKeepSceneObjectTable;
		curKeepSceneObjectTable = nextKeepSceneObjectTable;
		nextKeepSceneObjectTable = hashtable;
	}

	public GameObject[] DontDestroyFromKeepSceneObjectAll()
	{
		GameObject[] array = new GameObject[0];
		GameObject gameObject = null;
		object[] array2 = Builtins.array(npcTable.Keys);
		int i = 0;
		object[] array3 = array2;
		for (int length = array3.Length; i < length; i = checked(i + 1))
		{
			object obj = npcTable[array3[i]];
			if (!(obj is NpcTalkControl))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
			}
			NpcTalkControl npcTalkControl = (NpcTalkControl)obj;
			if ((bool)npcTalkControl && npcTalkControl.IsKeepChangeScene)
			{
				array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, new GameObject[1] { npcTalkControl.gameObject });
				npcTable.Remove(array3[i]);
			}
		}
		if (curKeepSceneObjectTable != null)
		{
			IEnumerator enumerator = curKeepSceneObjectTable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				gameObject = curKeepSceneObjectTable[current] as GameObject;
				if ((bool)gameObject)
				{
					array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, new GameObject[1] { gameObject });
				}
			}
			curKeepSceneObjectTable.Clear();
		}
		if (nextKeepSceneObjectTable != null)
		{
			IEnumerator enumerator2 = nextKeepSceneObjectTable.Keys.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object current2 = enumerator2.Current;
				gameObject = nextKeepSceneObjectTable[current2] as GameObject;
				if ((bool)gameObject)
				{
					array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, new GameObject[1] { gameObject });
				}
			}
			nextKeepSceneObjectTable.Clear();
		}
		return array;
	}

	public void NpcAllClear(bool changeScenen)
	{
		object[] array = Builtins.array(npcTable.Keys);
		int i = 0;
		object[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			object obj = npcTable[array2[i]];
			if (!(obj is NpcTalkControl))
			{
				obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
			}
			NpcTalkControl npcTalkControl = (NpcTalkControl)obj;
			if ((bool)npcTalkControl)
			{
				if (changeScenen && npcTalkControl.IsKeepChangeScene)
				{
					KeepSceneObject = npcTalkControl.gameObject;
					npcTable.Remove(array2[i]);
				}
				else
				{
					npcTable.Remove(array2[i]);
					DestroyNpc(npcTalkControl.gameObject);
				}
			}
		}
	}

	public void NpcManagement()
	{
		if (isBusy || SceneChanger.isVeryBusy || ((bool)cutSceneManager && cutSceneManager.isBusy) || ((bool)eventWindow && EventWindow.isWindow))
		{
			return;
		}
		checked
		{
			if (stopWorldCount > 0)
			{
				stopWorldCount--;
				if (stopWorldCount <= 0)
				{
					stopWorldCount = 0;
					TheWorld.RestartWorld();
				}
			}
			UserData current = UserData.Current;
			if (SceneChanger.CurrentSceneName != lastSceneName)
			{
				NpcTalkControl.TalkReset();
				loadAssetObject.Clear();
				npcNoDupIdTable.Clear();
				lastSceneName = SceneChanger.CurrentSceneName;
				NpcAllClear(changeScenen: true);
				KeepSceneObjectAllClear();
				IEnumerator enumerator = SetupGameLevel(SceneChanger.CurrentSceneName, 0);
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
				if (current != null)
				{
					playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
				}
				cutSceneManager = CutSceneManager.Instance;
				eventWindow = EventWindow.Instance;
				sceneChangeWait = false;
			}
			else
			{
				if (!SceneChanger.isCompletelyReady || sceneChangeWait)
				{
					return;
				}
				int num = playerConditionNumber;
				if (current != null)
				{
					playerConditionNumber = current.userMiscInfo.flagData.ConditionNumber;
				}
				if (playerConditionNumber == num)
				{
					return;
				}
				loadAssetObject.Clear();
				object[] array = Builtins.array(npcTable.Keys);
				int i = 0;
				object[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					object obj = npcTable[array2[i]];
					if (!(obj is NpcTalkControl))
					{
						obj = RuntimeServices.Coerce(obj, typeof(NpcTalkControl));
					}
					NpcTalkControl npcTalkControl = (NpcTalkControl)obj;
					if (!npcTalkControl || npcTalkControl.IsKeepChangeScene)
					{
						continue;
					}
					if (npcTalkControl.MNpcs != null)
					{
						if (!CheckNpc(npcTalkControl.MNpcs))
						{
							npcTable.Remove(array2[i]);
							DestroyNpc(npcTalkControl.gameObject);
						}
					}
					else
					{
						npcTable.Remove(array2[i]);
						DestroyNpc(npcTalkControl.gameObject);
					}
				}
				IEnumerator enumerator2 = SetupGameLevel(SceneChanger.CurrentSceneName, 100);
				if (enumerator2 != null)
				{
					StartCoroutine(enumerator2);
				}
			}
		}
	}

	public static int SetResultCondition(MFlags[] resultConditions, bool notFlag)
	{
		checked
		{
			int result;
			if (resultConditions == null)
			{
				result = 0;
			}
			else
			{
				UserData current = UserData.Current;
				if (current == null)
				{
					result = 0;
				}
				else
				{
					int num = 0;
					int i = 0;
					for (int length = resultConditions.Length; i < length; i++)
					{
						if (resultConditions[i] != null)
						{
							if (notFlag)
							{
								current.userMiscInfo.flagData.delete(resultConditions[i].Progname);
								num++;
							}
							else
							{
								current.userMiscInfo.flagData.set(resultConditions[i].Progname, 1);
								num++;
							}
						}
					}
					if (num != 0)
					{
						stopWorldCount = 10;
						if ((bool)CurrentInstance)
						{
							TheWorld.StopWorldForTalk(CurrentInstance, null);
						}
					}
					result = num;
				}
			}
			return result;
		}
	}

	public static bool CheckCondition(MFlags condition, bool notFlag)
	{
		return condition != null && CheckCondition(new MFlags[1] { condition }, notFlag);
	}

	public static bool CheckCondition(MFlags[] conditions, bool notFlag)
	{
		UserData current = UserData.Current;
		return current != null && CheckConditionCore(current.userMiscInfo.flagData, conditions, notFlag);
	}

	public static bool CheckConditionCore(UserMiscInfo.FlagData flagData, MFlags[] conditions, bool notFlag)
	{
		int result;
		checked
		{
			if (conditions == null)
			{
				result = 0;
			}
			else if (flagData == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				bool flag = true;
				int i = 0;
				for (int length = conditions.Length; i < length; i++)
				{
					if (conditions[i] != null)
					{
						bool num2 = flag;
						if (num2)
						{
							num2 = flagData.hasFlag(conditions[i].Progname);
						}
						flag = num2;
						num++;
					}
				}
				result = ((num <= 0 || ((!notFlag) ? flag : (!flag))) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	public static bool IsValidCondition(MFlags[] conditions)
	{
		int num = 0;
		int length = conditions.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (conditions[num] != null && conditions[num].Id != 0)
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

	public static void SetFlagWithFade(MFlags flag)
	{
		Instance.setFlagWithFade(flag);
	}

	private void setFlagWithFade(MFlags flag)
	{
		__GameLevelManager_setFlagWithFade_0024callable165_00241012_13__ _GameLevelManager_setFlagWithFade_0024callable165_00241012_13__ = (MFlags flag) => new _0024_0024setFlagWithFade_0024routine_00243789_002418275(flag).GetEnumerator();
		IEnumerator enumerator = _GameLevelManager_setFlagWithFade_0024callable165_00241012_13__(flag);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public static void SendNpcTalkEndEvent()
	{
		raise_NpcTalkEndEvent();
	}

	internal IEnumerator _0024setFlagWithFade_0024routine_00243789(MFlags flag)
	{
		return new _0024_0024setFlagWithFade_0024routine_00243789_002418275(flag).GetEnumerator();
	}
}
