using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using S540;
using UnityEngine;

[Serializable]
public class Event540 : TutorialBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_init_002418147 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_002430_002418148;

			internal object _0024___item_002418149;

			internal IEnumerator _0024_0024iterator_002413623_002418150;

			internal Event540 _0024self__002418151;

			public _0024(Event540 self_)
			{
				_0024self__002418151 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_002430_002418148 = _0024self__002418151.S540_init(null);
					if (_0024_0024s540_0024ycode_002430_002418148 != null)
					{
						_0024_0024iterator_002413623_002418150 = _0024_0024s540_0024ycode_002430_002418148;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413623_002418150.MoveNext())
					{
						_0024___item_002418149 = _0024_0024iterator_002413623_002418150.Current;
						result = (Yield(2, _0024___item_002418149) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418152;

		public _0024S540_init_002418147(Event540 self_)
		{
			_0024self__002418152 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418152);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_main_002418153 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_002435_002418154;

			internal object _0024___item_002418155;

			internal IEnumerator _0024_0024iterator_002413624_002418156;

			internal Event540 _0024self__002418157;

			public _0024(Event540 self_)
			{
				_0024self__002418157 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_002435_002418154 = _0024self__002418157.S540_main(null);
					if (_0024_0024s540_0024ycode_002435_002418154 != null)
					{
						_0024_0024iterator_002413624_002418156 = _0024_0024s540_0024ycode_002435_002418154;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413624_002418156.MoveNext())
					{
						_0024___item_002418155 = _0024_0024iterator_002413624_002418156.Current;
						result = (Yield(2, _0024___item_002418155) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418158;

		public _0024S540_main_002418153(Event540 self_)
		{
			_0024self__002418158 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418158);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_e5000_IN_002418159 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241603_002418160;

			internal object _0024___item_002418161;

			internal IEnumerator _0024_0024iterator_002413625_002418162;

			internal Event540 _0024self__002418163;

			public _0024(Event540 self_)
			{
				_0024self__002418163 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241603_002418160 = _0024self__002418163.S540_e5000_IN(null);
					if (_0024_0024s540_0024ycode_00241603_002418160 != null)
					{
						_0024_0024iterator_002413625_002418162 = _0024_0024s540_0024ycode_00241603_002418160;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413625_002418162.MoveNext())
					{
						_0024___item_002418161 = _0024_0024iterator_002413625_002418162.Current;
						result = (Yield(2, _0024___item_002418161) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418164;

		public _0024S540_e5000_IN_002418159(Event540 self_)
		{
			_0024self__002418164 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418164);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_e5000_IN_002418165 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002418166;

			internal Exec _0024_0024CUR_EXEC_0024_002418167;

			internal float _0024_0024wait_sec_0024temp_00241598_002418168;

			internal GameObject _0024obj_002418169;

			internal float _0024_0024wait_until_0024temp_00241599_002418170;

			internal float _0024_0024wait_until_0024temp_00241600_002418171;

			internal Exec _0024_0024s540_0024go_00241601_002418172;

			internal IEnumerator _0024_0024s540_0024tmp_00241602_002418173;

			internal Event540 _0024self__002418174;

			public _0024(Event540 self_)
			{
				_0024self__002418174 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002418166 = "S540_e5000_IN";
					_0024_0024CUR_EXEC_0024_002418167 = _0024self__002418174.lastCreatedExec;
					_0024_0024wait_sec_0024temp_00241598_002418168 = 1f;
					goto IL_007a;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002418167.NotExecuting)
					{
						goto IL_007a;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002418167.NotExecuting)
					{
						goto IL_00ee;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007a:
					if (_0024_0024wait_sec_0024temp_00241598_002418168 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241598_002418168 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024obj_002418169 = GameAssetModule.InstantiatePrefab("Prefab/GUI/SignMitukaiSyutugen");
					_0024obj_002418169.transform.parent = _0024self__002418174.transform;
					_0024_0024wait_until_0024temp_00241599_002418170 = 5f;
					_0024_0024wait_until_0024temp_00241600_002418171 = Time.realtimeSinceStartup;
					goto IL_00ee;
					IL_00ee:
					if (!SkipButtonHUD.CanSkip() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241600_002418171 < _0024_0024wait_until_0024temp_00241599_002418170)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002418174.dtrace(_0024_0024CUR_EXEC_0024_002418167, "Event540.boo:26", "go命令 " + _0024self__002418174.CurrentStateName + "->" + "S540_GoToNextScene" + "(" + string.Empty + ")");
					_0024_0024s540_0024go_00241601_002418172 = _0024self__002418174.createExecAsCurrent("S540_GoToNextScene");
					_0024_0024s540_0024tmp_00241602_002418173 = _0024self__002418174.S540_GoToNextScene();
					_0024self__002418174.entryCoroutine(_0024_0024s540_0024go_00241601_002418172, _0024_0024s540_0024tmp_00241602_002418173);
					_0024self__002418174.stop(_0024_0024CUR_EXEC_0024_002418167);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418175;

		public _0024S540_e5000_IN_002418165(Event540 self_)
		{
			_0024self__002418175 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418175);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_GoToNextScene_002418176 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241604_002418177;

			internal object _0024___item_002418178;

			internal IEnumerator _0024_0024iterator_002413626_002418179;

			internal Event540 _0024self__002418180;

			public _0024(Event540 self_)
			{
				_0024self__002418180 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241604_002418177 = _0024self__002418180.S540_GoToNextScene(null);
					if (_0024_0024s540_0024ycode_00241604_002418177 != null)
					{
						_0024_0024iterator_002413626_002418179 = _0024_0024s540_0024ycode_00241604_002418177;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413626_002418179.MoveNext())
					{
						_0024___item_002418178 = _0024_0024iterator_002413626_002418179.Current;
						result = (Yield(2, _0024___item_002418178) ? 1 : 0);
						break;
					}
					goto IL_0078;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0078:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418181;

		public _0024S540_GoToNextScene_002418176(Event540 self_)
		{
			_0024self__002418181 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418181);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_GoToNextScene_002418182 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002418183;

			internal Exec _0024_0024CUR_EXEC_0024_002418184;

			internal Event540 _0024self__002418185;

			public _0024(Event540 self_)
			{
				_0024self__002418185 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002418183 = "S540_GoToNextScene";
					_0024_0024CUR_EXEC_0024_002418184 = _0024self__002418185.lastCreatedExec;
					if (_0024self__002418185.gomi_isEffectOnly)
					{
						_0024self__002418185.dtrace(_0024_0024CUR_EXEC_0024_002418184, "Event540.boo:30", "scene命令");
						if ("Town" != SceneChanger.CurrentSceneName)
						{
							SceneChanger.ChangeTo(SceneID.Town);
						}
						goto case 2;
					}
					_0024self__002418185.dtrace(_0024_0024CUR_EXEC_0024_002418184, "Event540.boo:33", "scene命令");
					if ("Ui_WorldRaid" != SceneChanger.CurrentSceneName)
					{
						SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
					}
					goto case 3;
				case 2:
					if (!SceneChanger.isFadeOut)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024CUR_EXEC_0024_002418184.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0122;
				case 3:
					if (!SceneChanger.isFadeOut)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!_0024_0024CUR_EXEC_0024_002418184.NotExecuting)
					{
						goto IL_0122;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0122:
					_0024self__002418185.stop(_0024_0024CUR_EXEC_0024_002418184);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Event540 _0024self__002418186;

		public _0024S540_GoToNextScene_002418182(Event540 self_)
		{
			_0024self__002418186 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418186);
		}
	}

	private bool gomi_isEffectOnly;

	public IEnumerator S540_init()
	{
		return new _0024S540_init_002418147(this).GetEnumerator();
	}

	public IEnumerator S540_init(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_init";
		Exec e = lastCreatedExec;
		gomi_isEffectOnly = false;
		GameObject gameObject = GameObject.Find("gomi arrival raid boss");
		if ((bool)gameObject)
		{
			gomi_isEffectOnly = true;
		}
		UnityEngine.Object.Destroy(gameObject);
		dtrace(e, "Event540.boo:14", "go命令 " + CurrentStateName + "->" + "S540_main" + "(" + string.Empty + ")");
		Exec e2 = createExecAsCurrent("S540_main");
		IEnumerator r = S540_main();
		entryCoroutine(e2, r);
		stop(e);
		return null;
	}

	protected override void startInitialState()
	{
		object obj = null;
		object obj2 = obj;
		if (!(obj2 is Exec))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Exec));
		}
		dtrace((Exec)obj2, "Event540.boo:7", "go命令 " + CurrentStateName + "->" + "S540_init" + "(" + string.Empty + ")");
		Exec e = createExecAsCurrent("S540_init");
		IEnumerator r = S540_init();
		entryCoroutine(e, r);
	}

	public IEnumerator S540_main()
	{
		return new _0024S540_main_002418153(this).GetEnumerator();
	}

	public IEnumerator S540_main(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_main";
		Exec e = lastCreatedExec;
		if (SceneChanger.CurrentSceneName == "cam5000_bossin")
		{
			dtrace(e, "Event540.boo:18", "go命令 " + CurrentStateName + "->" + "S540_e5000_IN" + "(" + string.Empty + ")");
			Exec e2 = createExecAsCurrent("S540_e5000_IN");
			IEnumerator r = S540_e5000_IN();
			entryCoroutine(e2, r);
			stop(e);
		}
		else
		{
			stop(e);
		}
		return null;
	}

	public IEnumerator S540_e5000_IN()
	{
		return new _0024S540_e5000_IN_002418159(this).GetEnumerator();
	}

	public IEnumerator S540_e5000_IN(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_e5000_IN_002418165(this).GetEnumerator();
	}

	public IEnumerator S540_GoToNextScene()
	{
		return new _0024S540_GoToNextScene_002418176(this).GetEnumerator();
	}

	public IEnumerator S540_GoToNextScene(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_GoToNextScene_002418182(this).GetEnumerator();
	}
}
