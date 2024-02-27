using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MobileMotionViewer : MerlinViewer
{
	[Serializable]
	private enum MENU_MODE
	{
		select_menu,
		select_stage,
		select_character,
		select_animation,
		select_weapon
	}

	[Serializable]
	internal class _0024OnGUIAnimationSelect_0024locals_002414578
	{
		internal __WebView_CommandLinkHandler_0024callable126_002420_34__ _0024isLoop;
	}

	[Serializable]
	internal class _0024listFilter_0024locals_002414579
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024mage_0024locals_002414580
	{
		internal string _0024name;

		internal List _0024exclude;
	}

	[Serializable]
	internal class _0024spawnMonster_0024locals_002414581
	{
		internal string _0024name;
	}

	[Serializable]
	internal class _0024spawnNPC_0024locals_002414582
	{
		internal string _0024name;
	}

	[Serializable]
	internal class _0024_setupComponent_core_0024locals_002414583
	{
		internal Type _0024type;

		internal bool _0024isEnable;
	}

	[Serializable]
	internal class _0024OnGUIAnimationSelect_0024_changeAnimation_00246562
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002424666 : GenericGenerator<YieldInstruction>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<YieldInstruction>, IEnumerator
			{
				internal Vector3 _0024_00246563_002424667;

				internal IEnumerator _0024_0024sco_0024temp_00242757_002424668;

				internal string _0024animName_002424669;

				internal _0024OnGUIAnimationSelect_0024_changeAnimation_00246562 _0024self__002424670;

				[NonSerialized]
				internal static Regex _0024re_002424744 = new Regex("idle");

				public _0024(string animName, _0024OnGUIAnimationSelect_0024_changeAnimation_00246562 self_)
				{
					_0024animName_002424669 = animName;
					_0024self__002424670 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002424670._0024this_002415271.mmpc)
						{
							if (_0024self__002424670._0024_0024locals_002415272._0024isLoop(_0024animName_002424669))
							{
								_0024self__002424670._0024this_002415271.target.animation.wrapMode = WrapMode.Loop;
							}
							_0024self__002424670._0024this_002415271.target.animation.Play(_0024animName_002424669);
						}
						else
						{
							Transform transform = _0024self__002424670._0024this_002415271.mmpc.gameObject.transform;
							_0024_00246563_002424667 = default(Vector3);
							transform.localPosition = _0024_00246563_002424667;
							if (_0024self__002424670._0024this_002415271.mmpc != null && _0024self__002424670._0024this_002415271.mmpc.findClipByName(_0024animName_002424669) != null)
							{
								_0024self__002424670._0024this_002415271.mmpc.playByName(_0024animName_002424669);
							}
							else
							{
								_0024self__002424670._0024this_002415271.mmpc.play(_0024self__002424670._0024this_002415271.target.animation[_0024animName_002424669].clip);
							}
							if (_0024self__002424670._0024_0024locals_002415272._0024isLoop(_0024animName_002424669))
							{
								result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
								break;
							}
						}
						goto case 1;
					case 2:
					case 3:
						if (!((double)_0024self__002424670._0024this_002415271.mmpc.MotionRemainingTime < 1.0 / 30.0) && _0024self__002424670._0024this_002415271.mmpc.MotionRemainingTime <= _0024self__002424670._0024this_002415271.mmpc.MotionLength && !_0024self__002424670._0024this_002415271.mmpc.IsEndOfMotion)
						{
							if (_0024self__002424670._0024this_002415271.mmpc.CurrentClip.name != _0024animName_002424669 && !RuntimeServices.op_Match(_0024self__002424670._0024this_002415271.mmpc.CurrentClip.name, _0024re_002424744))
							{
								goto case 1;
							}
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024_0024sco_0024temp_00242757_002424668 = _0024self__002424670.Invoke(_0024animName_002424669);
						if (_0024_0024sco_0024temp_00242757_002424668 != null)
						{
							result = (Yield(4, _0024self__002424670._0024this_002415271.StartCoroutine(_0024_0024sco_0024temp_00242757_002424668)) ? 1 : 0);
							break;
						}
						goto case 4;
					case 4:
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal string _0024animName_002424671;

			internal _0024OnGUIAnimationSelect_0024_changeAnimation_00246562 _0024self__002424672;

			public _0024Invoke_002424666(string animName, _0024OnGUIAnimationSelect_0024_changeAnimation_00246562 self_)
			{
				_0024animName_002424671 = animName;
				_0024self__002424672 = self_;
			}

			public override IEnumerator<YieldInstruction> GetEnumerator()
			{
				return new _0024(_0024animName_002424671, _0024self__002424672);
			}
		}

		internal MobileMotionViewer _0024this_002415271;

		internal _0024OnGUIAnimationSelect_0024locals_002414578 _0024_0024locals_002415272;

		public _0024OnGUIAnimationSelect_0024_changeAnimation_00246562(MobileMotionViewer _0024this_002415271, _0024OnGUIAnimationSelect_0024locals_002414578 _0024_0024locals_002415272)
		{
			this._0024this_002415271 = _0024this_002415271;
			this._0024_0024locals_002415272 = _0024_0024locals_002415272;
		}

		public IEnumerator Invoke(string animName)
		{
			return new _0024Invoke_002424666(animName, this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024listFilter_0024closure_00246565
	{
		internal _0024listFilter_0024locals_002414579 _0024_0024locals_002415273;

		public _0024listFilter_0024closure_00246565(_0024listFilter_0024locals_002414579 _0024_0024locals_002415273)
		{
			this._0024_0024locals_002415273 = _0024_0024locals_002415273;
		}

		public bool Invoke(string x)
		{
			return _0024_0024locals_002415273._0024r.Match(x).Success;
		}
	}

	[Serializable]
	internal class _0024mage_0024_isNotStageObj_00246566
	{
		internal _0024mage_0024locals_002414580 _0024_0024locals_002415274;

		[NonSerialized]
		internal static Regex _0024re_002424745 = new Regex("_");

		public _0024mage_0024_isNotStageObj_00246566(_0024mage_0024locals_002414580 _0024_0024locals_002415274)
		{
			this._0024_0024locals_002415274 = _0024_0024locals_002415274;
		}

		public bool Invoke(string target)
		{
			string lhs = target.Replace("_", string.Empty).ToLower();
			string rhs = _0024_0024locals_002415274._0024name.Replace("_", string.Empty).ToLower();
			string rhs2 = _0024re_002424745.Split(_0024_0024locals_002415274._0024name.ToLower())[0] + "_lightset";
			return !RuntimeServices.op_Member(target, _0024_0024locals_002415274._0024exclude) && !RuntimeServices.op_Member(lhs, rhs) && !RuntimeServices.op_Member(target.ToLower(), rhs2) && !RuntimeServices.op_Member(lhs, rhs2);
		}
	}

	[Serializable]
	internal class _0024spawnMonster_0024closure_00246567
	{
		internal MobileMotionViewer _0024this_002415275;

		internal _0024spawnMonster_0024locals_002414581 _0024_0024locals_002415276;

		public _0024spawnMonster_0024closure_00246567(MobileMotionViewer _0024this_002415275, _0024spawnMonster_0024locals_002414581 _0024_0024locals_002415276)
		{
			this._0024this_002415275 = _0024this_002415275;
			this._0024_0024locals_002415276 = _0024_0024locals_002415276;
		}

		public void Invoke(GameObject go)
		{
			go.transform.parent = _0024this_002415275.characterBase.transform;
			_0024this_002415275.StartCoroutine(_0024this_002415275.setupCharacter(go, _0024_0024locals_002415276._0024name));
		}
	}

	[Serializable]
	internal class _0024spawnNPC_0024closure_00246568
	{
		internal MobileMotionViewer _0024this_002415277;

		internal _0024spawnNPC_0024locals_002414582 _0024_0024locals_002415278;

		public _0024spawnNPC_0024closure_00246568(MobileMotionViewer _0024this_002415277, _0024spawnNPC_0024locals_002414582 _0024_0024locals_002415278)
		{
			this._0024this_002415277 = _0024this_002415277;
			this._0024_0024locals_002415278 = _0024_0024locals_002415278;
		}

		public void Invoke(GameObject go)
		{
			go.transform.parent = _0024this_002415277.characterBase.transform;
			_0024this_002415277.StartCoroutine(_0024this_002415277.setupCharacter(go, _0024_0024locals_002415278._0024name));
		}
	}

	[Serializable]
	internal class _0024_setupComponent_core_0024_each_00246569
	{
		internal _0024_setupComponent_core_0024locals_002414583 _0024_0024locals_002415279;

		public _0024_setupComponent_core_0024_each_00246569(_0024_setupComponent_core_0024locals_002414583 _0024_0024locals_002415279)
		{
			this._0024_0024locals_002415279 = _0024_0024locals_002415279;
		}

		public void Invoke(object comp)
		{
			PropertyInfo property = _0024_0024locals_002415279._0024type.GetProperty("enabled", BindingFlags.Instance | BindingFlags.Public);
			property.SetValue(comp, _0024_0024locals_002415279._0024isEnable, null);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_searchSceneElements_002424558 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024maxRetry_002424559;

			internal MobileMotionViewer _0024self__002424560;

			public _0024(MobileMotionViewer self_)
			{
				_0024self__002424560 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024maxRetry_002424559 = 0;
						goto case 2;
					case 2:
						if (_0024maxRetry_002424559 < 10 && _0024self__002424560.target == null && _0024self__002424560.characterBase == null && _0024self__002424560.stageBase == null)
						{
							if (_0024self__002424560.target == null)
							{
								_0024self__002424560.target = _0024self__002424560.transform.gameObject;
							}
							if (_0024self__002424560.characterBase == null)
							{
								_0024self__002424560.characterBase = GameObject.Find("_Characters");
							}
							if (_0024self__002424560.stageBase == null)
							{
								_0024self__002424560.stageBase = GameObject.Find("_Stage");
							}
							if (_0024self__002424560.cameraComponent == null)
							{
								_0024self__002424560.cameraComponent = _0024self__002424560.gameObject.GetComponent<ViewerCameraController>();
							}
							_0024maxRetry_002424559++;
							result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
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

		internal MobileMotionViewer _0024self__002424561;

		public _0024_searchSceneElements_002424558(MobileMotionViewer self_)
		{
			_0024self__002424561 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002424561);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mage_002424562 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal __WebView_CommandLinkHandler_0024callable126_002420_34__ _0024_isNotStageObj_002424563;

			internal RuntimeAssetBundleDB.Req _0024req_002424564;

			internal GameObject _0024o_002424565;

			internal QuestInitializer _0024questInitializer_002424566;

			internal bool _0024stage_load_finish_002424567;

			internal _0024mage_0024locals_002414580 _0024_0024locals_002424568;

			internal string _0024name_002424569;

			internal List _0024exclude_002424570;

			internal MobileMotionViewer _0024self__002424571;

			public _0024(string name, List exclude, MobileMotionViewer self_)
			{
				_0024name_002424569 = name;
				_0024exclude_002424570 = exclude;
				_0024self__002424571 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002424568 = new _0024mage_0024locals_002414580();
					_0024_0024locals_002424568._0024name = _0024name_002424569;
					_0024_0024locals_002424568._0024exclude = _0024exclude_002424570;
					_0024_isNotStageObj_002424563 = new _0024mage_0024_isNotStageObj_00246566(_0024_0024locals_002424568).Invoke;
					_0024req_002424564 = RuntimeAssetBundleDB.Instance.loadPackedScenePrefab(_0024_0024locals_002424568._0024name);
					goto case 2;
				case 2:
					if (!_0024req_002424564.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024req_002424564.Prefab == null))
					{
						_0024o_002424565 = (GameObject)UnityEngine.Object.Instantiate(_0024req_002424564.Prefab);
						_0024questInitializer_002424566 = _0024o_002424565.GetComponentInChildren<QuestInitializer>();
						if ((bool)_0024questInitializer_002424566)
						{
							UnityEngine.Object.DestroyImmediate(_0024questInitializer_002424566.gameObject);
						}
						_0024o_002424565.transform.parent = _0024self__002424571.stageBase.transform;
					}
					_0024stage_load_finish_002424567 = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_002424572;

		internal List _0024exclude_002424573;

		internal MobileMotionViewer _0024self__002424574;

		public _0024mage_002424562(string name, List exclude, MobileMotionViewer self_)
		{
			_0024name_002424572 = name;
			_0024exclude_002424573 = exclude;
			_0024self__002424574 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424572, _0024exclude_002424573, _0024self__002424574);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024changeCharacter_002424575 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal List _0024all_002424576;

			internal Transform _0024x_002424577;

			internal IEnumerator _0024_0024iterator_002414247_002424578;

			internal string _0024name_002424579;

			internal MobileMotionViewer _0024self__002424580;

			public _0024(string name, MobileMotionViewer self_)
			{
				_0024name_002424579 = name;
				_0024self__002424580 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002424580.characterBase)
					{
						goto case 1;
					}
					_0024all_002424576 = new List();
					_0024_0024iterator_002414247_002424578 = _0024self__002424580.characterBase.transform.GetEnumerator();
					while (_0024_0024iterator_002414247_002424578.MoveNext())
					{
						object obj = _0024_0024iterator_002414247_002424578.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024x_002424577 = (Transform)obj;
						_0024all_002424576.Add(_0024x_002424577);
					}
					_0024self__002424580.StartCoroutine(_0024self__002424580.unloadCharacters(_0024all_002424576));
					_0024self__002424580.loadCharacter(_0024name_002424579);
					_0024self__002424580.resetCamera();
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_002424581;

		internal MobileMotionViewer _0024self__002424582;

		public _0024changeCharacter_002424575(string name, MobileMotionViewer self_)
		{
			_0024name_002424581 = name;
			_0024self__002424582 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424581, _0024self__002424582);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024spawnPlayer_002424583 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal EnumGenders _0024g_002424584;

			internal PlayerControl _0024pl_002424585;

			internal GameObject _0024go_002424586;

			internal string _0024name_002424587;

			internal MobileMotionViewer _0024self__002424588;

			[NonSerialized]
			internal static Regex _0024re_002424746 = new Regex("c000[01]");

			[NonSerialized]
			internal static Regex _0024re_002424747 = new Regex("c000[23]");

			public _0024(string name, MobileMotionViewer self_)
			{
				_0024name_002424587 = name;
				_0024self__002424588 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024g_002424584 = EnumGenders.male;
					if (RuntimeServices.op_Match(_0024name_002424587, _0024re_002424746))
					{
						_0024g_002424584 = EnumGenders.male;
					}
					else if (RuntimeServices.op_Match(_0024name_002424587, _0024re_002424747))
					{
						_0024g_002424584 = EnumGenders.female;
					}
					_0024pl_002424585 = PlayerControl.Spawn(Vector3.zero, Quaternion.identity, _0024g_002424584, _0024g_002424584);
					goto case 2;
				case 2:
					if (!(_0024pl_002424585 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024go_002424586 = _0024pl_002424585.gameObject;
					goto case 3;
				case 3:
					if (!_0024pl_002424585.IsReady)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002424588.styleEquip(EnumStyles.Sword);
					_0024go_002424586.transform.parent = _0024self__002424588.characterBase.transform;
					_0024self__002424588.StartCoroutine(_0024self__002424588.setupCharacter(_0024go_002424586, _0024name_002424587));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_002424589;

		internal MobileMotionViewer _0024self__002424590;

		public _0024spawnPlayer_002424583(string name, MobileMotionViewer self_)
		{
			_0024name_002424589 = name;
			_0024self__002424590 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424589, _0024self__002424590);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024unloadCharacters_002424591 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024kid_002424592;

			internal IEnumerator<object> _0024_0024iterator_002414248_002424593;

			internal List _0024characters_002424594;

			public _0024(List characters)
			{
				_0024characters_002424594 = characters;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024iterator_002414248_002424593 = _0024characters_002424594.GetEnumerator();
						_state = 2;
						break;
					case 3:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002414248_002424593.MoveNext())
					{
						object obj = _0024_0024iterator_002414248_002424593.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024kid_002424592 = (Transform)obj;
						_0024kid_002424592.parent = null;
						UnityEngine.Object.Destroy(_0024kid_002424592.gameObject);
						Resources.UnloadUnusedAssets();
						flag = YieldDefault(3);
						goto IL_00cb;
					}
					_state = 1;
					_0024ensure2();
					YieldDefault(1);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_00cc;
				IL_00cb:
				result = (flag ? 1 : 0);
				goto IL_00cc;
				IL_00cc:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414248_002424593.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal List _0024characters_002424595;

		public _0024unloadCharacters_002424591(List characters)
		{
			_0024characters_002424595 = characters;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024characters_002424595);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024setupCharacter_002424596 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Transform _0024k_002424597;

			internal Transform _0024t_002424598;

			internal SkinnedMeshRenderer _0024m_002424599;

			internal PlayerControl _0024pc_002424600;

			internal IEnumerator _0024_0024iterator_002414249_002424601;

			internal GameObject _0024c_002424602;

			internal string _0024name_002424603;

			internal MobileMotionViewer _0024self__002424604;

			[NonSerialized]
			internal static Regex _0024re_002424748 = new Regex("c5\\d{3}");

			public _0024(GameObject c, string name, MobileMotionViewer self_)
			{
				_0024c_002424602 = c;
				_0024name_002424603 = name;
				_0024self__002424604 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024c_002424602.transform.parent = _0024self__002424604.characterBase.transform;
					if (!_0024c_002424602)
					{
						goto case 1;
					}
					_0024k_002424597 = _0024c_002424602.transform;
					_0024_0024iterator_002414249_002424601 = _0024c_002424602.transform.GetEnumerator();
					while (_0024_0024iterator_002414249_002424601.MoveNext())
					{
						object obj = _0024_0024iterator_002414249_002424601.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024t_002424598 = (Transform)obj;
						if (RuntimeServices.op_Member("y_ang", _0024t_002424598.name))
						{
							break;
						}
						if (RuntimeServices.op_Member(_0024name_002424603, _0024t_002424598.name))
						{
							_0024k_002424597 = _0024t_002424598;
							break;
						}
						_0024k_002424597 = _0024t_002424598;
					}
					if (RuntimeServices.op_Match(_0024name_002424603, _0024re_002424748))
					{
						_0024self__002424604.target = _0024c_002424602;
					}
					else
					{
						_0024self__002424604.target = _0024k_002424597.gameObject;
					}
					_0024self__002424604.target.tag = _0024self__002424604.VIEWR_CHAR_TAG;
					_0024self__002424604.target.animation.cullingType = AnimationCullingType.AlwaysAnimate;
					_0024self__002424604.selectIdleAnimation(_0024self__002424604.target);
					_0024m_002424599 = _0024self__002424604.target.GetComponentInChildren<SkinnedMeshRenderer>();
					if (_0024m_002424599 != null)
					{
						_0024m_002424599.quality = SkinQuality.Bone4;
					}
					_0024self__002424604.mmpc = _0024c_002424602.GetComponent<MerlinMotionPackControl>();
					if (_0024self__002424604.mmpc != null)
					{
						_0024self__002424604.mmpc.logging = false;
					}
					if (_0024self__002424604.mmpc != null)
					{
						_0024c_002424602.AddComponent(typeof(MMPCViewer));
					}
					_0024pc_002424600 = _0024c_002424602.GetComponent<PlayerControl>();
					if (_0024pc_002424600 != null)
					{
						goto case 2;
					}
					goto case 6;
				case 2:
					if (!_0024pc_002424600.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002424604.mmpc.setMotionTarget(_0024self__002424604.target);
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024pc_002424600.state = PlayerControl.STATE.Battle;
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					if (RuntimeServices.op_Member("0001", _0024name_002424603) || RuntimeServices.op_Member("0003", _0024name_002424603))
					{
						if (_0024pc_002424600.IsTensi)
						{
							_0024pc_002424600.OnSkill3Button();
						}
					}
					else if (_0024pc_002424600.IsAkuma)
					{
						_0024pc_002424600.OnSkill3Button();
					}
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					PlayerControl.ForceToSetInputType = PlayerInputControlType.ByController;
					_0024self__002424604.mmpc.setMotionTarget(_0024self__002424604.target);
					result = (YieldDefault(6) ? 1 : 0);
					break;
				case 6:
					_0024self__002424604.findAllAnimations();
					_0024self__002424604.componentDisabler(_0024c_002424602);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024c_002424605;

		internal string _0024name_002424606;

		internal MobileMotionViewer _0024self__002424607;

		public _0024setupCharacter_002424596(GameObject c, string name, MobileMotionViewer self_)
		{
			_0024c_002424605 = c;
			_0024name_002424606 = name;
			_0024self__002424607 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002424605, _0024name_002424606, _0024self__002424607);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024findAnimationsFromMMPC_002424608 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242765_002424609;

			internal MobileMotionViewer _0024self__002424610;

			public _0024(MobileMotionViewer self_)
			{
				_0024self__002424610 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00242765_002424609 = _0024self__002424610.findAnimationsFromMMPC(EnumStyles.Sword);
					if (_0024_0024sco_0024temp_00242765_002424609 != null)
					{
						result = (Yield(2, _0024self__002424610.StartCoroutine(_0024_0024sco_0024temp_00242765_002424609)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MobileMotionViewer _0024self__002424611;

		public _0024findAnimationsFromMMPC_002424608(MobileMotionViewer self_)
		{
			_0024self__002424611 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002424611);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024findAnimationsFromMMPC_002424612 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal List _0024res_002424613;

			internal Match _0024m_002424614;

			internal MerlinMotionPack _0024pack_002424615;

			internal object _0024prefix_002424616;

			internal string _0024pname_002424617;

			internal MerlinMotionPack.Entry _0024e_002424618;

			internal int _0024_002412212_002424619;

			internal MerlinMotionPack.Entry[] _0024_002412213_002424620;

			internal int _0024_002412214_002424621;

			internal IEnumerator<object> _0024_0024iterator_002414252_002424622;

			internal EnumStyles _0024etype_002424623;

			internal MobileMotionViewer _0024self__002424624;

			[NonSerialized]
			internal static Regex _0024re_002424749 = new Regex("([a-z]\\d{4})_([a-z0])(\\d{2})");

			public _0024(EnumStyles etype, MobileMotionViewer self_)
			{
				_0024etype_002424623 = etype;
				_0024self__002424624 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (!_0024self__002424624.mmpc)
						{
							goto case 1;
						}
						_0024res_002424613 = new List();
						if (RuntimeServices.op_Member("C000", _0024self__002424624.mmpc.gameObject.name))
						{
							_0024self__002424624.mmpc.activateMotionPack(_0024self__002424624.getPackName(_0024etype_002424623), b: true);
							goto case 2;
						}
						_0024m_002424614 = _0024re_002424749.Match(_0024self__002424624.mmpc.motionTarget.name);
						if (_0024m_002424614.Success)
						{
							_0024pack_002424615 = _0024self__002424624.mmpc.getPack(new StringBuilder("mp_").Append(_0024m_002424614.Groups[0].Value).ToString());
							if (!_0024pack_002424615)
							{
								_0024_0024iterator_002414252_002424622 = new List(new object[7] { "a", "b", "c", "d", "e", "f", "g" }, takeOwnership: true).GetEnumerator();
								try
								{
									while (_0024_0024iterator_002414252_002424622.MoveNext())
									{
										_0024prefix_002424616 = _0024_0024iterator_002414252_002424622.Current;
										_0024pname_002424617 = new StringBuilder("mp_").Append(_0024m_002424614.Groups[1].Value).Append("_").Append(_0024prefix_002424616)
											.Append(_0024m_002424614.Groups[3].Value)
											.ToString();
										_0024pack_002424615 = _0024self__002424624.mmpc.getPack(_0024pname_002424617);
										if ((bool)_0024pack_002424615)
										{
											break;
										}
									}
								}
								finally
								{
									_0024_0024iterator_002414252_002424622.Dispose();
								}
							}
							if (!_0024pack_002424615)
							{
								goto case 1;
							}
							_0024_002412212_002424619 = 0;
							_0024_002412213_002424620 = _0024pack_002424615.entries;
							for (_0024_002412214_002424621 = _0024_002412213_002424620.Length; _0024_002412212_002424619 < _0024_002412214_002424621; _0024_002412212_002424619++)
							{
								_0024res_002424613.Add(_0024_002412213_002424620[_0024_002412212_002424619].name);
							}
						}
						_0024self__002424624.animations = (List)_0024res_002424613.Sort();
						_0024self__002424624.filterdAnimations = _0024self__002424624.animations;
						goto IL_033d;
					case 2:
						if (!_0024self__002424624.mmpc.isActivatedMotionPacks("mp_player_000_event", _0024self__002424624.getPackName(_0024etype_002424623)))
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002424624.appendAnimListFromPack(_0024self__002424624.getPackName(_0024etype_002424623));
						goto IL_033d;
					case 1:
						{
							result = 0;
							break;
						}
						IL_033d:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal EnumStyles _0024etype_002424625;

		internal MobileMotionViewer _0024self__002424626;

		public _0024findAnimationsFromMMPC_002424612(EnumStyles etype, MobileMotionViewer self_)
		{
			_0024etype_002424625 = etype;
			_0024self__002424626 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024etype_002424625, _0024self__002424626);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024attachWeapon_002424627 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal GameObject _0024b_002424628;

			internal Transform _0024kid_002424629;

			internal IEnumerator _0024_0024sco_0024temp_00242766_002424630;

			internal IEnumerator _0024_0024iterator_002414253_002424631;

			internal string _0024boneName_002424632;

			internal string _0024wpnName_002424633;

			internal MobileMotionViewer _0024self__002424634;

			public _0024(string boneName, string wpnName, MobileMotionViewer self_)
			{
				_0024boneName_002424632 = boneName;
				_0024wpnName_002424633 = wpnName;
				_0024self__002424634 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024b_002424628 = GameObject.Find(_0024boneName_002424632);
					if (!_0024b_002424628)
					{
						goto case 1;
					}
					_0024_0024iterator_002414253_002424631 = _0024b_002424628.transform.GetEnumerator();
					while (_0024_0024iterator_002414253_002424631.MoveNext())
					{
						object obj = _0024_0024iterator_002414253_002424631.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024kid_002424629 = (Transform)obj;
						_0024kid_002424629.parent = null;
						UnityEngine.Object.Destroy(_0024kid_002424629.gameObject);
					}
					_0024_0024sco_0024temp_00242766_002424630 = _0024self__002424634.loadWeaponModel(_0024wpnName_002424633, ref _0024b_002424628);
					if (_0024_0024sco_0024temp_00242766_002424630 != null)
					{
						result = (Yield(2, _0024self__002424634.StartCoroutine(_0024_0024sco_0024temp_00242766_002424630)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024boneName_002424635;

		internal string _0024wpnName_002424636;

		internal MobileMotionViewer _0024self__002424637;

		public _0024attachWeapon_002424627(string boneName, string wpnName, MobileMotionViewer self_)
		{
			_0024boneName_002424635 = boneName;
			_0024wpnName_002424636 = wpnName;
			_0024self__002424637 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024boneName_002424635, _0024wpnName_002424636, _0024self__002424637);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadWeaponModel_002424638 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB.Req _0024r_002424639;

			internal string _0024model_002424640;

			internal GameObject _0024obj_002424641;

			public _0024(string model, GameObject obj)
			{
				_0024model_002424640 = model;
				_0024obj_002424641 = obj;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024r_002424639 = RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024model_002424640);
					goto case 2;
				case 2:
					if (!_0024r_002424639.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024r_002424639.IsOk)
					{
						throw new AssertionFailedException(new StringBuilder("could not load weapon ").Append(_0024model_002424640).ToString());
					}
					_0024r_002424639.Prefab.transform.position = _0024obj_002424641.transform.position;
					_0024r_002424639.Prefab.transform.rotation = _0024obj_002424641.transform.rotation;
					_0024r_002424639.Prefab.transform.parent = _0024obj_002424641.transform;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024model_002424642;

		internal GameObject _0024obj_002424643;

		public _0024loadWeaponModel_002424638(string model, GameObject obj)
		{
			_0024model_002424642 = model;
			_0024obj_002424643 = obj;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024model_002424642, _0024obj_002424643);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024OnGUIMenu_0024timer_00246559_002424644 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00242754_002424645;

			internal float _0024_0024wait_until_0024temp_00242755_002424646;

			internal MobileMotionViewer _0024self__002424647;

			public _0024(MobileMotionViewer self_)
			{
				_0024self__002424647 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002424647.dispMenu = false;
					_0024_0024wait_until_0024temp_00242754_002424645 = 20f;
					_0024_0024wait_until_0024temp_00242755_002424646 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (0 == 0 && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00242755_002424646 < _0024_0024wait_until_0024temp_00242754_002424645)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002424647.dispMenu = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MobileMotionViewer _0024self__002424648;

		public _0024_0024OnGUIMenu_0024timer_00246559_002424644(MobileMotionViewer self_)
		{
			_0024self__002424648 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002424648);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024OnGUIStageSelect_0024_changeStage_00246560_002424649 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024name_002424650;

			internal MobileMotionViewer _0024self__002424651;

			public _0024(string name, MobileMotionViewer self_)
			{
				_0024name_002424650 = name;
				_0024self__002424651 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002424651.unloadCurrentStage();
					_0024self__002424651.loadStage(_0024name_002424650);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_002424652;

		internal MobileMotionViewer _0024self__002424653;

		public _0024_0024OnGUIStageSelect_0024_changeStage_00246560_002424649(string name, MobileMotionViewer self_)
		{
			_0024name_002424652 = name;
			_0024self__002424653 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424652, _0024self__002424653);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024OnGUIWeaponSelect_0024_changeWeapon_00246564_002424654 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024wpn_002424655;

			internal IEnumerator _0024_0024sco_0024temp_00242759_002424656;

			internal IEnumerator _0024_0024sco_0024temp_00242760_002424657;

			internal IEnumerator _0024_0024sco_0024temp_00242761_002424658;

			internal IEnumerator _0024_0024sco_0024temp_00242762_002424659;

			internal IEnumerator _0024_0024sco_0024temp_00242763_002424660;

			internal PlayerControl _0024pc_002424661;

			internal string _0024weaponName_002424662;

			internal MobileMotionViewer _0024self__002424663;

			[NonSerialized]
			internal static Regex _0024re_002424750 = new Regex("prefab:([a-zA-Z0-9_]+)");

			public _0024(string weaponName, MobileMotionViewer self_)
			{
				_0024weaponName_002424662 = weaponName;
				_0024self__002424663 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002424663.stripAllWeapons();
					_0024wpn_002424655 = _0024re_002424750.Match(_0024weaponName_002424662).Groups[1].Value;
					if (RuntimeServices.op_Member("w04_", _0024wpn_002424655) || RuntimeServices.op_Member("W04_", _0024wpn_002424655))
					{
						_0024_0024sco_0024temp_00242759_002424656 = _0024self__002424663.attachWeapon(_0024self__002424663.weaponBoneR, _0024wpn_002424655.Replace("_l", "_r"));
						if (_0024_0024sco_0024temp_00242759_002424656 != null)
						{
							result = (Yield(2, _0024self__002424663.StartCoroutine(_0024_0024sco_0024temp_00242759_002424656)) ? 1 : 0);
							break;
						}
						goto case 2;
					}
					if (RuntimeServices.op_Member("w01_", _0024wpn_002424655) || RuntimeServices.op_Member("W01", _0024wpn_002424655))
					{
						_0024_0024sco_0024temp_00242761_002424658 = _0024self__002424663.attachWeapon(_0024self__002424663.weaponBoneR, _0024self__002424663.weaponArrow);
						if (_0024_0024sco_0024temp_00242761_002424658 != null)
						{
							result = (Yield(4, _0024self__002424663.StartCoroutine(_0024_0024sco_0024temp_00242761_002424658)) ? 1 : 0);
							break;
						}
						goto case 4;
					}
					_0024_0024sco_0024temp_00242763_002424660 = _0024self__002424663.attachWeapon(_0024self__002424663.weaponBoneR, _0024wpn_002424655);
					if (_0024_0024sco_0024temp_00242763_002424660 != null)
					{
						result = (Yield(6, _0024self__002424663.StartCoroutine(_0024_0024sco_0024temp_00242763_002424660)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 2:
					_0024_0024sco_0024temp_00242760_002424657 = _0024self__002424663.attachWeapon(_0024self__002424663.weaponBoneL, _0024wpn_002424655);
					if (_0024_0024sco_0024temp_00242760_002424657 != null)
					{
						result = (Yield(3, _0024self__002424663.StartCoroutine(_0024_0024sco_0024temp_00242760_002424657)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 4:
					_0024_0024sco_0024temp_00242762_002424659 = _0024self__002424663.attachWeapon(_0024self__002424663.weaponBoneL, _0024wpn_002424655);
					if (_0024_0024sco_0024temp_00242762_002424659 != null)
					{
						result = (Yield(5, _0024self__002424663.StartCoroutine(_0024_0024sco_0024temp_00242762_002424659)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
				case 5:
				case 6:
					_0024pc_002424661 = _0024self__002424663.mmpc.gameObject.GetComponent<PlayerControl>();
					if ((bool)_0024pc_002424661)
					{
						_0024self__002424663.changeStyle(_0024wpn_002424655);
						result = (YieldDefault(7) ? 1 : 0);
					}
					else
					{
						result = (YieldDefault(8) ? 1 : 0);
					}
					break;
				case 7:
				case 8:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024weaponName_002424664;

		internal MobileMotionViewer _0024self__002424665;

		public _0024_0024OnGUIWeaponSelect_0024_changeWeapon_00246564_002424654(string weaponName, MobileMotionViewer self_)
		{
			_0024weaponName_002424664 = weaponName;
			_0024self__002424665 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024weaponName_002424664, _0024self__002424665);
		}
	}

	private GameObject target;

	public MerlinMotionPackControl mmpc;

	private GameObject characterBase;

	private GameObject stageBase;

	public bool forceLoop;

	public bool dispMenu;

	public bool filterEnemyVariation;

	private ViewerCameraController cameraComponent;

	private readonly string VIEWR_CHAR_TAG;

	public MENU_MODE menu_mode;

	private int current_mode;

	private string[] mode_toolbar_label;

	private int cursor;

	private Vector2 scroll;

	private string listFilterStrings;

	private int cursor1;

	private Vector2 scroll1;

	private List stages;

	private List characters;

	private List animations;

	private List weapons;

	private List filterdStages;

	private List filterdCharacters;

	private List filterdAnimations;

	private List filterdWeapons;

	private int characterPrefabCount;

	private Hash characterPrefabList;

	private GUIStyle modeStyle;

	private GUIStyle filterStyle;

	private GUIStyle listStyle;

	public readonly string[][] MOBILE_MOTVIEWER_STAGE_FILTER;

	public readonly string[][] MOBILE_MOTVIEWER_CHARACTER_FILTER;

	public readonly string[][] MOBILE_MOTVIEWER_ANIMATION_FILTER;

	public readonly string[][] MOBILE_MOTVIEWER_WEAPON_FILTER;

	private string weaponBoneR;

	private string weaponBoneL;

	private string weaponAssetPath;

	private string characterAssetPath;

	private string weaponArrow;

	[NonSerialized]
	internal static Regex _0024re_002424732 = new Regex("[wW]0(\\d)");

	[NonSerialized]
	internal static Regex _0024re_002424733 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424734 = new Regex("\\/");

	[NonSerialized]
	internal static Regex _0024re_002424735 = new Regex("_.*");

	[NonSerialized]
	internal static Regex _0024re_002424736 = new Regex("c000");

	[NonSerialized]
	internal static Regex _0024re_002424737 = new Regex("c5");

	[NonSerialized]
	internal static Regex _0024re_002424738 = new Regex("ev_idle");

	[NonSerialized]
	internal static Regex _0024re_002424739 = new Regex("idle");

	[NonSerialized]
	internal static Regex _0024re_002424740 = new Regex("[cC][^0]\\d{3}");

	[NonSerialized]
	internal static Regex _0024re_002424741 = new Regex("idle");

	[NonSerialized]
	internal static Regex _0024re_002424742 = new Regex("run");

	[NonSerialized]
	internal static Regex _0024re_002424743 = new Regex("walk");

	public MobileMotionViewer()
	{
		dispMenu = true;
		VIEWR_CHAR_TAG = "TestChar";
		menu_mode = MENU_MODE.select_character;
		current_mode = (int)menu_mode;
		cursor = -1;
		listFilterStrings = string.Empty;
		cursor1 = -1;
		characterPrefabList = new Hash();
		MOBILE_MOTVIEWER_STAGE_FILTER = new string[10][]
		{
			new string[2]
			{
				"全",
				string.Empty
			},
			new string[2] { "洞", "cave" },
			new string[2] { "浜", "coast" },
			new string[2] { "砂", "desert" },
			new string[2] { "森", "forest" },
			new string[2] { "山", "mountain" },
			new string[2] { "殿", "temple|tower" },
			new string[2] { "天", "heaven|nightmare|sanctuary" },
			new string[2] { "火", "volcano|flame" },
			new string[2] { "雪", "snow" }
		};
		MOBILE_MOTVIEWER_CHARACTER_FILTER = new string[6][]
		{
			new string[2]
			{
				"全",
				string.Empty
			},
			new string[2] { "人", "^c|npc" },
			new string[2] { "敵", "^e0" },
			new string[2] { "月", "^e1" },
			new string[2] { "ボ", "^e5|^e6|^e9" },
			new string[2] { "ペ", "^p" }
		};
		MOBILE_MOTVIEWER_ANIMATION_FILTER = new string[8][]
		{
			new string[2]
			{
				"全",
				string.Empty
			},
			new string[2] { "儀", "_ev_" },
			new string[2] { "闘", "_bt_" },
			new string[2] { "剣", "_1hs_" },
			new string[2] { "弓", "_bow_" },
			new string[2] { "拳", "_hth_" },
			new string[2] { "槍", "_spr_" },
			new string[2] { "大", "_2hs_" }
		};
		MOBILE_MOTVIEWER_WEAPON_FILTER = new string[6][]
		{
			new string[2]
			{
				"全",
				string.Empty
			},
			new string[2] { "剣", "w00" },
			new string[2] { "弓", "w01" },
			new string[2] { "槍", "w03" },
			new string[2] { "拳", "w04" },
			new string[2] { "大", "w05" }
		};
		weaponBoneR = "y_ang/cog/c_spine_a/c_spine_b/r_clavicle/r_upperarm/r_forearm/r_hand/r_weapon_1";
		weaponBoneL = "y_ang/cog/c_spine_a/c_spine_b/l_clavicle/l_upperarm/l_forearm/l_hand/l_weapon_1";
		weaponAssetPath = "Assets/Resources/Prefab/Weapons";
		characterAssetPath = "Assets/Model";
		weaponArrow = "W02_0000_00";
	}

	public void Start()
	{
		characters = findAllCharacters();
		filterdCharacters = characters;
		weapons = (List)findAllWeapons();
		filterdWeapons = weapons;
		stages = findAllStages();
		filterdStages = stages;
		mode_toolbar_label = new string[5] { "制御", "場", "人", "動", "武" };
		IEnumerator enumerator = _searchSceneElements();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator _searchSceneElements()
	{
		return new _0024_searchSceneElements_002424558(this).GetEnumerator();
	}

	private void _loadSound()
	{
		GameSoundManager instance = GameSoundManager.Instance;
		if ((bool)instance)
		{
			int num = 0;
			int count = SQEX_SoundPlayerData.seTypes.Count;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < count)
			{
				int seType = num;
				num++;
				instance.LoadSeType(seType);
			}
		}
	}

	private void toggleBaseMode()
	{
		if (!(mmpc == null))
		{
			mmpc.baseMode = !mmpc.baseMode;
		}
	}

	public void OnGUI()
	{
		if (!dispMenu)
		{
			return;
		}
		int width = Screen.width;
		int height = Screen.height;
		GUILayout.BeginArea(new Rect(width / 2, 0f, width / 2, height));
		if (modeStyle == null || filterStyle == null || listStyle == null)
		{
			initGUIStyles();
		}
		if (GUI.changed)
		{
			refreshList();
		}
		OnGUIMenuModeSwitch();
		if (menu_mode == MENU_MODE.select_menu)
		{
			OnGUIMenu();
		}
		if (menu_mode == MENU_MODE.select_stage)
		{
			OnGUIStageSelect();
		}
		if (menu_mode == MENU_MODE.select_character)
		{
			OnGUICharacterSelect();
		}
		if (menu_mode == MENU_MODE.select_animation)
		{
			if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				OnGUICharacterSelectSub();
			}
			OnGUIAnimationSelect();
		}
		if (menu_mode == MENU_MODE.select_weapon)
		{
			OnGUIWeaponSelect();
		}
		GUILayout.EndArea();
		GUI.enabled = true;
	}

	public void initGUIStyles()
	{
		double num = ((Application.platform != RuntimePlatform.IPhonePlayer) ? 12.0 : 40.0);
		modeStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		modeStyle.alignment = TextAnchor.MiddleCenter;
		checked
		{
			modeStyle.margin = new RectOffset((int)(num * 0.25), 13, (int)(num * 0.6), 5);
			modeStyle.fontSize = (int)(num * 1.25);
			filterStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
			filterStyle.alignment = TextAnchor.MiddleCenter;
			filterStyle.fixedHeight = (float)(num * 1.5);
			filterStyle.fontSize = (int)num;
			listStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
			listStyle.alignment = TextAnchor.LowerLeft;
			listStyle.margin = new RectOffset((int)(num * 0.25), 3, (int)(num * 0.25), 5);
			listStyle.padding = new RectOffset((int)(num * 1.1), 3, (int)(num * 0.25), 5);
			listStyle.fontSize = (int)num;
		}
	}

	public void _onGUIFilter(string[][] buttons, ICallable filterFunc)
	{
		GUILayout.BeginHorizontal();
		int i = 0;
		for (int length = buttons.Length; i < length; i = checked(i + 1))
		{
			if (GUILayout.Button(buttons[i][0] as string, filterStyle))
			{
				filterFunc.Call(new object[1] { buttons[i][1] as string });
			}
		}
		GUILayout.EndHorizontal();
	}

	public void _onGUIList(List filterdList, ICallable callbackFunc)
	{
		if (filterdList == null)
		{
			return;
		}
		int num = cursor;
		scroll = GUILayout.BeginScrollView(scroll);
		string[] texts = (string[])Builtins.array(typeof(string), filterdList);
		cursor = GUILayout.SelectionGrid(cursor, texts, 1, listStyle);
		GUILayout.EndScrollView();
		if (GUI.changed && num != cursor)
		{
			object obj = callbackFunc.Call(new object[1] { filterdList[cursor] });
			if (!(obj is IEnumerator))
			{
				obj = RuntimeServices.Coerce(obj, typeof(IEnumerator));
			}
			StartCoroutine((IEnumerator)obj);
			cursor = -1;
		}
	}

	public void _onGUIListSub(List filterdList, ICallable callbackFunc)
	{
		if (filterdList == null)
		{
			return;
		}
		int num = cursor1;
		scroll1 = GUILayout.BeginScrollView(scroll1, GUILayout.Height(Screen.height / 4));
		string[] texts = (string[])Builtins.array(typeof(string), filterdList);
		cursor1 = GUILayout.SelectionGrid(cursor1, texts, 1, listStyle);
		GUILayout.EndScrollView();
		if (GUI.changed && num != cursor1)
		{
			object obj = callbackFunc.Call(new object[1] { filterdList[cursor1] });
			if (!(obj is IEnumerator))
			{
				obj = RuntimeServices.Coerce(obj, typeof(IEnumerator));
			}
			StartCoroutine((IEnumerator)obj);
		}
	}

	public void OnGUIMenuModeSwitch()
	{
		current_mode = GUILayout.Toolbar(current_mode, mode_toolbar_label, modeStyle);
		if (GUI.changed)
		{
			switchMode((MENU_MODE)current_mode);
		}
	}

	public void OnGUIStageSelect()
	{
		__PlayerControl_loadMotionPack_0024callable170_00241237_13__ callbackFunc = (string name) => new _0024_0024OnGUIStageSelect_0024_changeStage_00246560_002424649(name, this).GetEnumerator();
		if (filterdStages != null)
		{
			_onGUIFilter(MOBILE_MOTVIEWER_STAGE_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterStages));
			_onGUIList(filterdStages, callbackFunc);
		}
	}

	public void OnGUICharacterSelect()
	{
		if (filterdCharacters != null)
		{
			_onGUIFilter(MOBILE_MOTVIEWER_CHARACTER_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterCharacters));
			_onGUIList(filterdCharacters, new __PlayerControl_loadMotionPack_0024callable170_00241237_13__(changeCharacter));
		}
	}

	public void OnGUICharacterSelectSub()
	{
		if (filterdCharacters != null)
		{
			_onGUIFilter(MOBILE_MOTVIEWER_CHARACTER_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterCharacters));
			_onGUIListSub(filterdCharacters, new __PlayerControl_loadMotionPack_0024callable170_00241237_13__(changeCharacter));
		}
	}

	public void OnGUIMenu()
	{
		int selected = -1;
		selected = GUILayout.Toolbar(selected, new string[1] { "情報表示" }, listStyle);
		if (GUI.changed && selected == 0)
		{
			MMPCViewer mMPCViewer = ((MMPCViewer)UnityEngine.Object.FindObjectOfType(typeof(MMPCViewer))) as MMPCViewer;
			if ((bool)mMPCViewer)
			{
				mMPCViewer.dispInformation = !mMPCViewer.dispInformation;
			}
		}
		selected = -1;
		selected = GUILayout.Toolbar(selected, new string[1] { "強制ループ" }, listStyle);
		if (GUI.changed && selected == 0)
		{
			forceLoop = !forceLoop;
		}
		if (GUILayout.Button("カメラリセット", listStyle))
		{
			resetCamera();
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024OnGUIMenu_0024timer_00246559_002424644(this).GetEnumerator();
		selected = -1;
		selected = GUILayout.Toolbar(selected, new string[1] { "20秒間メニュー非表示" }, listStyle);
		if (GUI.changed && selected == 0)
		{
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
		if (GUILayout.Button("サウンド読み込み", listStyle))
		{
			_loadSound();
		}
		if (GUILayout.Button("敵バリエーション非表示", listStyle))
		{
			filterEnemyVariation = !filterEnemyVariation;
			filterCharacters();
		}
		if (GUILayout.Button("移動値反映", listStyle))
		{
			toggleBaseMode();
		}
	}

	public void OnGUIAnimationSelect()
	{
		_0024OnGUIAnimationSelect_0024locals_002414578 _0024OnGUIAnimationSelect_0024locals_0024 = new _0024OnGUIAnimationSelect_0024locals_002414578();
		_0024OnGUIAnimationSelect_0024locals_0024._0024isLoop = (string animName) => forceLoop || RuntimeServices.op_Match(animName.ToLower(), _0024re_002424741) || RuntimeServices.op_Match(animName.ToLower(), _0024re_002424742) || (RuntimeServices.op_Match(animName.ToLower(), _0024re_002424743) ? true : false);
		__PlayerControl_loadMotionPack_0024callable170_00241237_13__ callbackFunc = new _0024OnGUIAnimationSelect_0024_changeAnimation_00246562(this, _0024OnGUIAnimationSelect_0024locals_0024).Invoke;
		if (filterdAnimations != null)
		{
			_onGUIFilter(MOBILE_MOTVIEWER_ANIMATION_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterAnimations));
			_onGUIList(filterdAnimations, callbackFunc);
		}
	}

	public void changeStyle(string wpn)
	{
		int n = 0;
		Match match = _0024re_002424732.Match(wpn);
		if (match.Success)
		{
			n = Convert.ToInt32(match.Groups[1].Value);
		}
		if (RuntimeServices.op_Member("1hs", wpn))
		{
			n = 0;
		}
		else if (RuntimeServices.op_Member("bow", wpn))
		{
			n = 1;
		}
		else if (RuntimeServices.op_Member("spr", wpn))
		{
			n = 3;
		}
		else if (RuntimeServices.op_Member("hth", wpn))
		{
			n = 4;
		}
		else if (RuntimeServices.op_Member("2hs", wpn))
		{
			n = 5;
		}
		changeStyle(n);
	}

	public void changeStyle(int n)
	{
		EnumStyles enumStyles = default(EnumStyles);
		enumStyles = n switch
		{
			0 => EnumStyles.Sword, 
			1 => EnumStyles.Bow, 
			2 => EnumStyles.Sword, 
			3 => EnumStyles.Spear, 
			4 => EnumStyles.Knuckle, 
			5 => EnumStyles.GreatSword, 
			_ => EnumStyles.Sword, 
		};
		styleEquip(enumStyles);
		IEnumerator enumerator = findAnimationsFromMMPC(enumStyles);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void OnGUIWeaponSelect()
	{
		__PlayerControl_loadMotionPack_0024callable170_00241237_13__ callbackFunc = (string weaponName) => new _0024_0024OnGUIWeaponSelect_0024_changeWeapon_00246564_002424654(weaponName, this).GetEnumerator();
		if (weapons == null)
		{
			Boo.Lang.List<object> list = findAllWeapons();
			filterdWeapons = weapons;
		}
		_onGUIFilter(MOBILE_MOTVIEWER_WEAPON_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterWeapons));
		GUILayout.Space(10f);
		if ((bool)target)
		{
			_onGUIList(filterdWeapons, callbackFunc);
			GUILayout.Space(10f);
		}
	}

	public void switchMode(MENU_MODE to)
	{
		cursor = -1;
		scroll = new Vector2(0f, 0f);
		if (menu_mode == to)
		{
			menu_mode = (MENU_MODE)(-1);
		}
		else
		{
			menu_mode = to;
		}
	}

	public List listFilter(List l)
	{
		_0024listFilter_0024locals_002414579 _0024listFilter_0024locals_0024 = new _0024listFilter_0024locals_002414579();
		int i = 0;
		string[] array = _0024re_002424733.Split(listFilterStrings);
		List list = default(List);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024listFilter_0024locals_0024._0024r = new Regex(array[i], RegexOptions.IgnoreCase);
			list = ArrayMap.FilterStrings(l, new _0024listFilter_0024closure_00246565(_0024listFilter_0024locals_0024).Invoke);
		}
		return (list != null) ? list : l;
	}

	public List findAllStages()
	{
		List list;
		if (Application.platform == RuntimePlatform.WindowsEditor)
		{
			string path = AssetBundlePath.Current.JsonDBPathInProjectDir();
			string json = File.ReadAllText(path);
			Hashtable hashtable = NGUIJson.jsonDecode(json) as Hashtable;
			list = new List();
			IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				object obj = dictionaryEntry.Key;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				if (((string)obj).StartsWith("PKSCN"))
				{
					List list2 = list;
					object obj2 = dictionaryEntry.Key;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					list2.Add(((string)obj2).Replace("PKSCN_PFB_", string.Empty));
				}
			}
		}
		else
		{
			list = new List(new object[163]
			{
				"cave_000", "cave_001", "cave_002", "cave_003", "cave_004", "cave_005", "cave_006", "cave_007", "cave_008", "cave_009",
				"coast_000", "coast_001", "coast_002", "coast_003", "coast_004", "coast_005", "coast_006", "coast_007", "coast_008", "coast_009",
				"darkforest_000", "darkforest_001", "darkforest_002", "darkforest_003", "darkforest_004", "darkforest_005", "darkforest_006", "darkforest_007", "darkforest_008", "darkforest_009",
				"darkforest_010", "darkforest_011", "desert_000", "desert_001", "desert_002", "desert_003", "desert_004", "desert_005", "desert_006", "desert_007",
				"desert_008", "desert_009", "desert_010", "desert_011", "flamevalley_000", "flamevalley_001", "flamevalley_002", "flamevalley_003", "flamevalley_004", "flamevalley_005",
				"flamevalley_006", "flamevalley_007", "flamevalley_008", "flamevalley_009", "flamevalley_010", "flamevalley_011", "forest_000", "forest_001", "forest_002", "forest_003",
				"forest_004", "forest_005", "forest_006", "forest_007", "forest_008", "forest_009", "forest_010", "forest_011", "forest_012", "heaven",
				"icecave_000", "icecave_001", "icecave_002", "icecave_003", "icecave_004", "icecave_005", "icecave_006", "icecave_007", "icecave_008", "icecave_009",
				"icecave_010", "icecave_011", "mountain_000", "mountain_001", "mountain_002", "mountain_003", "mountain_004", "mountain_005", "mountain_006", "mountain_007",
				"mountain_008", "Nightmare", "RaidStory003", "sanctuary_000", "sanctuary_001", "sanctuary_002", "sanctuary_003", "sanctuary_004", "sanctuary_005", "sanctuary_006",
				"sanctuary_007", "sanctuary_008", "sanctuary_009", "snowfield_000", "snowfield_001", "snowfield_002", "snowfield_003", "snowfield_004", "snowfield_005", "snowfield_006",
				"snowfield_007", "snowfield_008", "snowfield_009", "snowfield_010", "snowfield_011", "snowfield_012", "temple_000", "temple_001", "temple_002", "temple_003",
				"temple_004", "temple_005", "temple_006", "temple_007", "temple_008", "temple_009", "temple_010", "temple_011", "temple_012", "temple_013",
				"temple_014", "TestScene1", "TestSceneZ", "test_cave_010", "TestScene2", "TestScene3", "tower_000", "tower_001", "tower_002", "tower_003",
				"tower_004", "tower_005", "tower_006", "tower_007", "tower_008", "tower_009", "tower_010", "tower_011", "tower_012", "tower_013",
				"volcano_000", "volcano_001", "volcano_002", "volcano_003", "volcano_004", "volcano_005", "volcano_006", "volcano_007", "volcano_008", "volcano_009",
				"volcano_010", "volcano_011", "volcano_012"
			}, takeOwnership: true);
		}
		return (List)list.Sort();
	}

	public void filterStages(string filter)
	{
		listFilterStrings = filter;
		filterStages();
	}

	public void filterStages()
	{
		filterdStages = listFilter(stages);
	}

	public void unloadCurrentStage()
	{
		IEnumerator enumerator = stageBase.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.parent = null;
			UnityEngine.Object.DestroyImmediate(transform.gameObject);
		}
	}

	public void loadStage(string name)
	{
		List exclude = new List(new object[12]
		{
			"_Characters", "_MotionViewer", "_Stage", "Finger Gestures", "TouchScreen Gestures", "Mouse Gestures", "Camera", "terrain", "Terrain", "DebugMode",
			"__RuntimeFingerGestures__", "Map"
		}, takeOwnership: true);
		IEnumerator enumerator = mage(name, exclude);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator mage(string name, List exclude)
	{
		return new _0024mage_002424562(name, exclude, this).GetEnumerator();
	}

	public List findAllCharacters()
	{
		List list = new List();
		list.Add("c0000_000_ma");
		list.Add("c0001_000_ma");
		list.Add("c0002_000_ma");
		list.Add("c0003_000_ma");
		int i = 0;
		MNpcs[] all = MNpcs.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (all[i].PrefabCond == null && !string.IsNullOrEmpty(all[i].Prefab))
			{
				string text = new StringBuilder().Append(all[i].Prefab).ToString();
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = _0024re_002424734.Split(all[i].Prefab);
				string text2 = stringBuilder.Append(array[(nint)array.LongLength + -1]).Append(" -\tid:").Append((object)all[i].Id)
					.Append(", 名前:")
					.Append(all[i].DisplayName)
					.ToString();
				if (!RuntimeServices.op_Member(text, characterPrefabList.Values))
				{
					characterPrefabList[text2] = text;
					list.Add(text2);
				}
			}
		}
		int j = 0;
		MMonsters[] all2 = MMonsters.All;
		checked
		{
			for (int length2 = all2.Length; j < length2; j++)
			{
				string text = new StringBuilder().Append(all2[j].PrefabName).ToString();
				string text2 = new StringBuilder().Append(all2[j].PrefabName).Append(" -\tid:").Append((object)all2[j].Id)
					.Append(", 名前:")
					.Append(all2[j].Name)
					.ToString();
				characterPrefabList[text2] = text;
				list.Add(text2);
			}
			int k = 0;
			MPoppets[] all3 = MPoppets.All;
			for (int length3 = all3.Length; k < length3; k++)
			{
				string text = new StringBuilder().Append(all3[k].PrefabName).ToString();
				string text2 = new StringBuilder().Append(all3[k].PrefabName).Append(" -\tid:").Append((object)all3[k].Id)
					.Append(", 名前:")
					.Append(all3[k].Name)
					.ToString();
				characterPrefabList[text2] = text;
				list.Add(text2);
			}
			return (List)list.Sort();
		}
	}

	public void filterCharacters(string filter)
	{
		listFilterStrings = filter;
		filterCharacters();
	}

	public void filterCharacters()
	{
		List list = new List();
		if (filterEnemyVariation)
		{
			List list2 = new List();
			IEnumerator<object> enumerator = listFilter(characters).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					Regex regex = _0024re_002424735;
					object obj = current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text = regex.Replace((string)obj, string.Empty);
					if (!string.IsNullOrEmpty(text))
					{
						if (!RuntimeServices.op_Member(text, list2))
						{
							list.Add(current);
						}
					}
					else
					{
						list.Add(current);
					}
					list2.Add(text);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		else
		{
			list = listFilter(characters);
		}
		filterdCharacters = list;
	}

	public IEnumerator changeCharacter(string name)
	{
		return new _0024changeCharacter_002424575(name, this).GetEnumerator();
	}

	public void resetCamera()
	{
		GameObject gameObject = GameObject.Find("c_head");
		GameObject gameObject2 = GameObject.Find("c_neck");
		GameObject gameObject3 = GameObject.Find("cog");
		if ((bool)gameObject)
		{
			cameraComponent.reset(gameObject.transform.position);
		}
		if ((bool)gameObject2 && !gameObject)
		{
			cameraComponent.reset(gameObject2.transform.position);
		}
		if ((bool)gameObject3 && !gameObject2 && !gameObject)
		{
			cameraComponent.reset(gameObject3.transform.position);
		}
	}

	public IEnumerator spawnPlayer(string name)
	{
		return new _0024spawnPlayer_002424583(name, this).GetEnumerator();
	}

	private void styleEquip(EnumStyles s)
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer == null))
		{
			int id = findWeaponByStyle(s).Id;
			WeaponEquipments weaponEquipments = WeaponEquipments.Default();
			weaponEquipments.MainTenshiWeapon = new RespWeapon(id);
			weaponEquipments.MainAkumaWeapon = new RespWeapon(id);
			currentPlayer.equipWeapons(weaponEquipments);
		}
	}

	private MWeapons findWeaponByStyle(EnumStyles s)
	{
		int num = 0;
		MWeapons[] all = MWeapons.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (RuntimeServices.EqualityOperator(all[num].MStyleId, all[num].Id))
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = MWeapons.Get(1);
			break;
		}
		return (MWeapons)result;
	}

	public IEnumerator spawnMonster(string name)
	{
		_0024spawnMonster_0024locals_002414581 _0024spawnMonster_0024locals_0024 = new _0024spawnMonster_0024locals_002414581();
		_0024spawnMonster_0024locals_0024._0024name = name;
		RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024spawnMonster_0024locals_0024._0024name, new _0024spawnMonster_0024closure_00246567(this, _0024spawnMonster_0024locals_0024).Invoke);
		return null;
	}

	public IEnumerator spawnNPC(string name)
	{
		_0024spawnNPC_0024locals_002414582 _0024spawnNPC_0024locals_0024 = new _0024spawnNPC_0024locals_002414582();
		_0024spawnNPC_0024locals_0024._0024name = name;
		RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024spawnNPC_0024locals_0024._0024name, new _0024spawnNPC_0024closure_00246568(this, _0024spawnNPC_0024locals_0024).Invoke);
		return null;
	}

	public void loadCharacter(string name)
	{
		object obj = characterPrefabList[name];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string value = (string)obj;
		if (RuntimeServices.op_Match(name, _0024re_002424736))
		{
			StartCoroutine("spawnPlayer", name);
		}
		else if (RuntimeServices.op_Match(name, _0024re_002424737))
		{
			StartCoroutine("spawnNPC", value);
		}
		else
		{
			StartCoroutine("spawnMonster", value);
		}
	}

	public IEnumerator unloadCharacters(List characters)
	{
		return new _0024unloadCharacters_002424591(characters).GetEnumerator();
	}

	public IEnumerator setupCharacter(GameObject c, string name)
	{
		return new _0024setupCharacter_002424596(c, name, this).GetEnumerator();
	}

	private void _setupComponent_core(Type type, GameObject obj, bool isEnable)
	{
		_0024_setupComponent_core_0024locals_002414583 _0024_setupComponent_core_0024locals_0024 = new _0024_setupComponent_core_0024locals_002414583();
		_0024_setupComponent_core_0024locals_0024._0024type = type;
		_0024_setupComponent_core_0024locals_0024._0024isEnable = isEnable;
		__LotteryBase_LoadResource_0024callable41_00241986_51__ _LotteryBase_LoadResource_0024callable41_00241986_51__ = new _0024_setupComponent_core_0024_each_00246569(_0024_setupComponent_core_0024locals_0024).Invoke;
		Type type2 = _0024_setupComponent_core_0024locals_0024._0024type.GetType();
		Component[] array = obj.GetComponents(_0024_setupComponent_core_0024locals_0024._0024type);
		if (array.Length == 0)
		{
			array = obj.GetComponentsInChildren(_0024_setupComponent_core_0024locals_0024._0024type);
		}
		if (array.Length <= 0)
		{
			return;
		}
		int i = 0;
		Component[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(_0024_setupComponent_core_0024locals_0024._0024type, typeof(PlayerControl)))
			{
				((PlayerControl)array2[i]).PlayAnimationIdle();
			}
			_LotteryBase_LoadResource_0024callable41_00241986_51__(array2[i]);
		}
	}

	public void componentDisabler(GameObject obj)
	{
		_setupComponent_core(typeof(MerlinMotionPackControl), obj, isEnable: true);
		_setupComponent_core(typeof(TapRecognizer), obj, isEnable: false);
		_setupComponent_core(typeof(SwipeRecognizer), obj, isEnable: false);
		_setupComponent_core(typeof(NPCControl), obj, isEnable: false);
		_setupComponent_core(typeof(AIControl), obj, isEnable: true);
		_setupComponent_core(typeof(PlayerControl), obj, isEnable: true);
		_setupComponent_core(typeof(D540ScriptRunner), obj, isEnable: false);
		_setupComponent_core(typeof(AttackHitManager), obj, isEnable: false);
		_setupComponent_core(typeof(CharacterController), obj, isEnable: true);
	}

	public void selectIdleAnimation(GameObject character)
	{
		IEnumerator enumerator = character.animation.GetEnumerator();
		bool flag = default(bool);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			if (RuntimeServices.op_Match(animationState.clip.name, _0024re_002424738))
			{
				character.animation.clip = animationState.clip;
				character.animation.Play();
				flag = true;
			}
			if (RuntimeServices.op_Match(animationState.clip.name, _0024re_002424739) && !flag)
			{
				character.animation.clip = animationState.clip;
				character.animation.Play();
			}
		}
	}

	public void findAllAnimations()
	{
		if (mmpc != null && !RuntimeServices.op_Match(target.name, _0024re_002424740))
		{
			StartCoroutine("findAnimationsFromMMPC");
			return;
		}
		List list = new List();
		IEnumerator enumerator = target.animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			list.Add(animationState.name);
		}
		list.Sort();
		if (((ICollection)list).Count != 0 && !target.animation.clip)
		{
			Animation obj2 = target.animation;
			Animation obj3 = target.animation;
			object obj4 = list[0];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			obj2.clip = obj3[(string)obj4].clip;
		}
		animations = list;
		filterdAnimations = animations;
	}

	public void appendAnimListFromPack(string n)
	{
		MerlinMotionPack pack = mmpc.getPack(n);
		if (!(pack != null))
		{
			throw new AssertionFailedException(new StringBuilder().Append(n).Append(", ").Append(pack)
				.Append(" をロードできません")
				.ToString());
		}
		List list = new List();
		int i = 0;
		MerlinMotionPack.Entry[] entries = pack.entries;
		for (int length = entries.Length; i < length; i = checked(i + 1))
		{
			list.Add(entries[i].name);
		}
		animations = (List)list.Sort();
		filterdAnimations = animations;
	}

	public IEnumerator findAnimationsFromMMPC()
	{
		return new _0024findAnimationsFromMMPC_002424608(this).GetEnumerator();
	}

	public IEnumerator findAnimationsFromMMPC(EnumStyles etype)
	{
		return new _0024findAnimationsFromMMPC_002424612(etype, this).GetEnumerator();
	}

	public string getPackName(EnumStyles etype)
	{
		return MStyles.Get((int)etype)?.MotPackName;
	}

	public void filterAnimations(string filter)
	{
		listFilterStrings = filter;
		filterAnimations();
		changeStyle(filter);
	}

	public void filterAnimations()
	{
		filterdAnimations = listFilter(animations);
	}

	public Boo.Lang.List<object> findAllWeapons()
	{
		List list = new List();
		int i = 0;
		MWeapons[] all = MWeapons.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			list.Add(new StringBuilder("prefab:").Append(all[i].PrefabName).Append("\t名前:").Append(all[i].Name)
				.Append("\t")
				.ToString());
		}
		return list.Sort();
	}

	public void filterWeapons(string filter)
	{
		listFilterStrings = filter;
		filterWeapons();
		changeStyle(filter);
	}

	public void filterWeapons()
	{
		filterdWeapons = listFilter(weapons);
	}

	private IEnumerator attachWeapon(string boneName, string wpnName)
	{
		return new _0024attachWeapon_002424627(boneName, wpnName, this).GetEnumerator();
	}

	private void stripAllWeapons()
	{
		GameObject gameObject = null;
		int i = 0;
		string[] array = new string[2] { weaponBoneR, weaponBoneL };
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			gameObject = GameObject.Find(array[i]);
			if (!gameObject)
			{
				break;
			}
			IEnumerator enumerator = gameObject.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				transform.parent = null;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
	}

	private IEnumerator loadWeaponModel(string model, ref GameObject obj)
	{
		return new _0024loadWeaponModel_002424638(model, obj).GetEnumerator();
	}

	public void refreshList()
	{
		filterCharacters(string.Empty);
		filterWeapons(string.Empty);
		filterAnimations(string.Empty);
	}

	internal IEnumerator _0024OnGUIMenu_0024timer_00246559()
	{
		return new _0024_0024OnGUIMenu_0024timer_00246559_002424644(this).GetEnumerator();
	}

	internal IEnumerator _0024OnGUIStageSelect_0024_changeStage_00246560(string name)
	{
		return new _0024_0024OnGUIStageSelect_0024_changeStage_00246560_002424649(name, this).GetEnumerator();
	}

	internal bool _0024OnGUIAnimationSelect_0024isLoop_00246561(string animName)
	{
		return forceLoop || RuntimeServices.op_Match(animName.ToLower(), _0024re_002424741) || RuntimeServices.op_Match(animName.ToLower(), _0024re_002424742) || (RuntimeServices.op_Match(animName.ToLower(), _0024re_002424743) ? true : false);
	}

	internal IEnumerator _0024OnGUIWeaponSelect_0024_changeWeapon_00246564(string weaponName)
	{
		return new _0024_0024OnGUIWeaponSelect_0024_changeWeapon_00246564_002424654(weaponName, this).GetEnumerator();
	}
}
