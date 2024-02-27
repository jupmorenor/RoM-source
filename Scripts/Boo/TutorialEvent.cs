using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using ChatTest;
using CompilerGenerated;
using GameAsset;
using ObjUtil;
using S540;
using UnityEngine;

[Serializable]
public class TutorialEvent : TutorialBase
{
	[Serializable]
	internal class _0024S540_tutorial_lottery_0024locals_002414459
	{
		internal int _0024lotteryStep;
	}

	[Serializable]
	internal class _0024S540_call_tutorials_0024locals_002414460
	{
		internal GameObject _0024prefabObj;

		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024S540_wait_button_0024locals_002414461
	{
		internal bool _0024on;
	}

	[Serializable]
	internal class _0024S540_tutorial_lottery_0024closure_00243252
	{
		internal _0024S540_tutorial_lottery_0024locals_002414459 _0024_0024locals_002415014;

		public _0024S540_tutorial_lottery_0024closure_00243252(_0024S540_tutorial_lottery_0024locals_002414459 _0024_0024locals_002415014)
		{
			this._0024_0024locals_002415014 = _0024_0024locals_002415014;
		}

		public bool Invoke()
		{
			if (_0024_0024locals_002415014._0024lotteryStep == 0)
			{
				_0024_0024locals_002415014._0024lotteryStep = 1;
			}
			return _0024_0024locals_002415014._0024lotteryStep == 2;
		}
	}

	[Serializable]
	internal class _0024S540_tutorial_lottery_0024closure_00243253
	{
		internal _0024S540_tutorial_lottery_0024locals_002414459 _0024_0024locals_002415015;

		public _0024S540_tutorial_lottery_0024closure_00243253(_0024S540_tutorial_lottery_0024locals_002414459 _0024_0024locals_002415015)
		{
			this._0024_0024locals_002415015 = _0024_0024locals_002415015;
		}

		public bool Invoke()
		{
			if (_0024_0024locals_002415015._0024lotteryStep == 2)
			{
				_0024_0024locals_002415015._0024lotteryStep = 3;
			}
			return _0024_0024locals_002415015._0024lotteryStep == 4;
		}
	}

	[Serializable]
	internal class _0024S540_call_tutorials_0024closure_00243257
	{
		internal _0024S540_call_tutorials_0024locals_002414460 _0024_0024locals_002415016;

		public _0024S540_call_tutorials_0024closure_00243257(_0024S540_call_tutorials_0024locals_002414460 _0024_0024locals_002415016)
		{
			this._0024_0024locals_002415016 = _0024_0024locals_002415016;
		}

		public void Invoke(GameObject go)
		{
			_0024_0024locals_002415016._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024S540_call_tutorials_0024closure_00243258
	{
		internal _0024S540_call_tutorials_0024locals_002414460 _0024_0024locals_002415017;

		public _0024S540_call_tutorials_0024closure_00243258(_0024S540_call_tutorials_0024locals_002414460 _0024_0024locals_002415017)
		{
			this._0024_0024locals_002415017 = _0024_0024locals_002415017;
		}

		public void Invoke(GameObject go)
		{
			_0024_0024locals_002415017._0024prefabObj = go;
			_0024_0024locals_002415017._0024ok = true;
		}
	}

	[Serializable]
	internal class _0024S540_wait_button_0024closure_00243259
	{
		internal _0024S540_wait_button_0024locals_002414461 _0024_0024locals_002415018;

		public _0024S540_wait_button_0024closure_00243259(_0024S540_wait_button_0024locals_002414461 _0024_0024locals_002415018)
		{
			this._0024_0024locals_002415018 = _0024_0024locals_002415018;
		}

		public void Invoke()
		{
			_0024_0024locals_002415018._0024on = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_init_002419808 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_002445_002419809;

			internal object _0024___item_002419810;

			internal IEnumerator _0024_0024iterator_002413786_002419811;

			internal TutorialEvent _0024self__002419812;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419812 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_002445_002419809 = _0024self__002419812.S540_init(null);
					if (_0024_0024s540_0024ycode_002445_002419809 != null)
					{
						_0024_0024iterator_002413786_002419811 = _0024_0024s540_0024ycode_002445_002419809;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413786_002419811.MoveNext())
					{
						_0024___item_002419810 = _0024_0024iterator_002413786_002419811.Current;
						result = (Yield(2, _0024___item_002419810) ? 1 : 0);
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

		internal TutorialEvent _0024self__002419813;

		public _0024S540_init_002419808(TutorialEvent self_)
		{
			_0024self__002419813 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419813);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_main_002419814 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241891_002419815;

			internal object _0024___item_002419816;

			internal IEnumerator _0024_0024iterator_002413787_002419817;

			internal TutorialEvent _0024self__002419818;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419818 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241891_002419815 = _0024self__002419818.S540_main(null);
					if (_0024_0024s540_0024ycode_00241891_002419815 != null)
					{
						_0024_0024iterator_002413787_002419817 = _0024_0024s540_0024ycode_00241891_002419815;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413787_002419817.MoveNext())
					{
						_0024___item_002419816 = _0024_0024iterator_002413787_002419817.Current;
						result = (Yield(2, _0024___item_002419816) ? 1 : 0);
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

		internal TutorialEvent _0024self__002419819;

		public _0024S540_main_002419814(TutorialEvent self_)
		{
			_0024self__002419819 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419819);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_main_002419820 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002419821;

			internal Exec _0024_0024CUR_EXEC_0024_002419822;

			internal Exec _0024_0024s540_0024go_00241861_002419823;

			internal IEnumerator _0024_0024s540_0024tmp_00241862_002419824;

			internal Exec _0024_0024s540_0024go_00241863_002419825;

			internal IEnumerator _0024_0024s540_0024tmp_00241864_002419826;

			internal Exec _0024_0024s540_0024go_00241865_002419827;

			internal IEnumerator _0024_0024s540_0024tmp_00241866_002419828;

			internal Exec _0024_0024s540_0024go_00241867_002419829;

			internal IEnumerator _0024_0024s540_0024tmp_00241868_002419830;

			internal Exec _0024_0024s540_0024go_00241869_002419831;

			internal IEnumerator _0024_0024s540_0024tmp_00241870_002419832;

			internal Exec _0024_0024s540_0024go_00241871_002419833;

			internal IEnumerator _0024_0024s540_0024tmp_00241872_002419834;

			internal Exec _0024_0024s540_0024go_00241873_002419835;

			internal IEnumerator _0024_0024s540_0024tmp_00241874_002419836;

			internal Exec _0024_0024s540_0024go_00241875_002419837;

			internal IEnumerator _0024_0024s540_0024tmp_00241876_002419838;

			internal Exec _0024_0024s540_0024go_00241877_002419839;

			internal IEnumerator _0024_0024s540_0024tmp_00241878_002419840;

			internal Exec _0024_0024s540_0024go_00241879_002419841;

			internal IEnumerator _0024_0024s540_0024tmp_00241880_002419842;

			internal Exec _0024_0024s540_0024go_00241881_002419843;

			internal IEnumerator _0024_0024s540_0024tmp_00241882_002419844;

			internal Exec _0024_0024s540_0024go_00241883_002419845;

			internal IEnumerator _0024_0024s540_0024tmp_00241884_002419846;

			internal Exec _0024_0024s540_0024go_00241885_002419847;

			internal IEnumerator _0024_0024s540_0024tmp_00241886_002419848;

			internal Exec _0024_0024s540_0024go_00241887_002419849;

			internal IEnumerator _0024_0024s540_0024tmp_00241888_002419850;

			internal Exec _0024_0024s540_0024go_00241889_002419851;

			internal IEnumerator _0024_0024s540_0024tmp_00241890_002419852;

			internal TutorialEvent _0024self__002419853;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419853 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002419821 = "S540_main";
					_0024_0024CUR_EXEC_0024_002419822 = _0024self__002419853.lastCreatedExec;
					goto IL_005d;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002419822.NotExecuting)
					{
						goto IL_005d;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002419822.NotExecuting)
					{
						goto IL_05fd;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005d:
					if (!_0024self__002419853.IsTutorialStartOk())
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (SceneChanger.CurrentSceneName == "Lottery_UI")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:117", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_lottery" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241861_002419823 = _0024self__002419853.createExecAsCurrent("S540_tutorial_lottery");
						_0024_0024s540_0024tmp_00241862_002419824 = _0024self__002419853.S540_tutorial_lottery();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241861_002419823, _0024_0024s540_0024tmp_00241862_002419824);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "Ui_WorldQuest")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:119", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_ui_worldQuest" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241863_002419825 = _0024self__002419853.createExecAsCurrent("S540_tutorial_ui_worldQuest");
						_0024_0024s540_0024tmp_00241864_002419826 = _0024self__002419853.S540_tutorial_ui_worldQuest();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241863_002419825, _0024_0024s540_0024tmp_00241864_002419826);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "Ui_MyHomeEquip")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:121", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_ui_myHomeEquip" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241865_002419827 = _0024self__002419853.createExecAsCurrent("S540_tutorial_ui_myHomeEquip");
						_0024_0024s540_0024tmp_00241866_002419828 = _0024self__002419853.S540_tutorial_ui_myHomeEquip();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241865_002419827, _0024_0024s540_0024tmp_00241866_002419828);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "Ui_WorldRaid")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:123", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_ui_worldRaid" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241867_002419829 = _0024self__002419853.createExecAsCurrent("S540_tutorial_ui_worldRaid");
						_0024_0024s540_0024tmp_00241868_002419830 = _0024self__002419853.S540_tutorial_ui_worldRaid();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241867_002419829, _0024_0024s540_0024tmp_00241868_002419830);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "Town")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:125", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_town" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241869_002419831 = _0024self__002419853.createExecAsCurrent("S540_tutorial_town");
						_0024_0024s540_0024tmp_00241870_002419832 = _0024self__002419853.S540_tutorial_town();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241869_002419831, _0024_0024s540_0024tmp_00241870_002419832);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "Ui_TownBlacksmith")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:127", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_ui_townBlacksmith" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241871_002419833 = _0024self__002419853.createExecAsCurrent("S540_tutorial_ui_townBlacksmith");
						_0024_0024s540_0024tmp_00241872_002419834 = _0024self__002419853.S540_tutorial_ui_townBlacksmith();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241871_002419833, _0024_0024s540_0024tmp_00241872_002419834);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else
					{
						if (!(SceneChanger.CurrentSceneName == "Ui_WorldColosseum"))
						{
							goto IL_05fd;
						}
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:129", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_ui_colosseumu" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241873_002419835 = _0024self__002419853.createExecAsCurrent("S540_tutorial_ui_colosseumu");
						_0024_0024s540_0024tmp_00241874_002419836 = _0024self__002419853.S540_tutorial_ui_colosseumu();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241873_002419835, _0024_0024s540_0024tmp_00241874_002419836);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					goto case 1;
					IL_05fd:
					if (!QuestInitializer.IsInQuest)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (QuestInitializer.IsInQuestScene("TutorialM000"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:137", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_mountain_000" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241875_002419837 = _0024self__002419853.createExecAsCurrent("S540_tutorial_mountain_000");
						_0024_0024s540_0024tmp_00241876_002419838 = _0024self__002419853.S540_tutorial_mountain_000();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241875_002419837, _0024_0024s540_0024tmp_00241876_002419838);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("TutorialM002"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:140", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_mountain_002" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241877_002419839 = _0024self__002419853.createExecAsCurrent("S540_tutorial_mountain_002");
						_0024_0024s540_0024tmp_00241878_002419840 = _0024self__002419853.S540_tutorial_mountain_002();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241877_002419839, _0024_0024s540_0024tmp_00241878_002419840);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("TutorialM001"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:143", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_mountain_001" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241879_002419841 = _0024self__002419853.createExecAsCurrent("S540_tutorial_mountain_001");
						_0024_0024s540_0024tmp_00241880_002419842 = _0024self__002419853.S540_tutorial_mountain_001();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241879_002419841, _0024_0024s540_0024tmp_00241880_002419842);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("TutorialM007"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:146", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_mountain_007" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241881_002419843 = _0024self__002419853.createExecAsCurrent("S540_tutorial_mountain_007");
						_0024_0024s540_0024tmp_00241882_002419844 = _0024self__002419853.S540_tutorial_mountain_007();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241881_002419843, _0024_0024s540_0024tmp_00241882_002419844);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("TutorialM005"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:149", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_mountain_005" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241883_002419845 = _0024self__002419853.createExecAsCurrent("S540_tutorial_mountain_005");
						_0024_0024s540_0024tmp_00241884_002419846 = _0024self__002419853.S540_tutorial_mountain_005();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241883_002419845, _0024_0024s540_0024tmp_00241884_002419846);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("Main001M006"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:152", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_cave_006" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241885_002419847 = _0024self__002419853.createExecAsCurrent("S540_tutorial_cave_006");
						_0024_0024s540_0024tmp_00241886_002419848 = _0024self__002419853.S540_tutorial_cave_006();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241885_002419847, _0024_0024s540_0024tmp_00241886_002419848);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (QuestInitializer.IsInQuestScene("Main001M009"))
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:155", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_cave_009" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241887_002419849 = _0024self__002419853.createExecAsCurrent("S540_tutorial_cave_009");
						_0024_0024s540_0024tmp_00241888_002419850 = _0024self__002419853.S540_tutorial_cave_009();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241887_002419849, _0024_0024s540_0024tmp_00241888_002419850);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else if (SceneChanger.CurrentSceneName == "RaidStory003")
					{
						_0024self__002419853.dtrace(_0024_0024CUR_EXEC_0024_002419822, "TutorialEvent.boo:157", "go命令 " + _0024self__002419853.CurrentStateName + "->" + "S540_tutorial_raid_story003" + "(" + string.Empty + ")");
						_0024_0024s540_0024go_00241889_002419851 = _0024self__002419853.createExecAsCurrent("S540_tutorial_raid_story003");
						_0024_0024s540_0024tmp_00241890_002419852 = _0024self__002419853.S540_tutorial_raid_story003();
						_0024self__002419853.entryCoroutine(_0024_0024s540_0024go_00241889_002419851, _0024_0024s540_0024tmp_00241890_002419852);
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					else
					{
						_0024self__002419853.stop(_0024_0024CUR_EXEC_0024_002419822);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002419854;

		public _0024S540_main_002419820(TutorialEvent self_)
		{
			_0024self__002419854 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419854);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_colosseumu_002419855 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241940_002419856;

			internal object _0024___item_002419857;

			internal IEnumerator _0024_0024iterator_002413788_002419858;

			internal TutorialEvent _0024self__002419859;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419859 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241940_002419856 = _0024self__002419859.S540_tutorial_ui_colosseumu(null);
					if (_0024_0024s540_0024ycode_00241940_002419856 != null)
					{
						_0024_0024iterator_002413788_002419858 = _0024_0024s540_0024ycode_00241940_002419856;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413788_002419858.MoveNext())
					{
						_0024___item_002419857 = _0024_0024iterator_002413788_002419858.Current;
						result = (Yield(2, _0024___item_002419857) ? 1 : 0);
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

		internal TutorialEvent _0024self__002419860;

		public _0024S540_tutorial_ui_colosseumu_002419855(TutorialEvent self_)
		{
			_0024self__002419860 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419860);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_colosseumu_002419861 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002419862;

			internal Exec _0024_0024CUR_EXEC_0024_002419863;

			internal UserData _0024ud_002419864;

			internal GameObject _0024go_002419865;

			internal GameObject _0024tutoRoot_002419866;

			internal bool _0024flagID1_002419867;

			internal FaderCore _0024fader_002419868;

			internal WorldColosseumMain _0024worldColosseumMain_002419869;

			internal Exec _0024_0024s540_0024call_00241893_002419870;

			internal IEnumerator _0024_0024s540_0024call_00241892_002419871;

			internal object _0024_0024s540_0024call_00241894_002419872;

			internal Exec _0024_0024s540_0024call_00241896_002419873;

			internal IEnumerator _0024_0024s540_0024call_00241895_002419874;

			internal object _0024_0024s540_0024call_00241897_002419875;

			internal Exec _0024_0024s540_0024call_00241899_002419876;

			internal IEnumerator _0024_0024s540_0024call_00241898_002419877;

			internal object _0024_0024s540_0024call_00241900_002419878;

			internal Exec _0024_0024s540_0024call_00241902_002419879;

			internal IEnumerator _0024_0024s540_0024call_00241901_002419880;

			internal object _0024_0024s540_0024call_00241903_002419881;

			internal Exec _0024_0024s540_0024call_00241905_002419882;

			internal IEnumerator _0024_0024s540_0024call_00241904_002419883;

			internal object _0024_0024s540_0024call_00241906_002419884;

			internal Exec _0024_0024s540_0024call_00241908_002419885;

			internal IEnumerator _0024_0024s540_0024call_00241907_002419886;

			internal object _0024_0024s540_0024call_00241909_002419887;

			internal Exec _0024_0024s540_0024call_00241911_002419888;

			internal IEnumerator _0024_0024s540_0024call_00241910_002419889;

			internal object _0024_0024s540_0024call_00241912_002419890;

			internal Exec _0024_0024s540_0024call_00241914_002419891;

			internal IEnumerator _0024_0024s540_0024call_00241913_002419892;

			internal object _0024_0024s540_0024call_00241915_002419893;

			internal bool _0024flagID2_002419894;

			internal Exec _0024_0024s540_0024call_00241917_002419895;

			internal IEnumerator _0024_0024s540_0024call_00241916_002419896;

			internal object _0024_0024s540_0024call_00241918_002419897;

			internal Exec _0024_0024s540_0024call_00241920_002419898;

			internal IEnumerator _0024_0024s540_0024call_00241919_002419899;

			internal object _0024_0024s540_0024call_00241921_002419900;

			internal Exec _0024_0024s540_0024call_00241923_002419901;

			internal IEnumerator _0024_0024s540_0024call_00241922_002419902;

			internal object _0024_0024s540_0024call_00241924_002419903;

			internal Exec _0024_0024s540_0024call_00241926_002419904;

			internal IEnumerator _0024_0024s540_0024call_00241925_002419905;

			internal object _0024_0024s540_0024call_00241927_002419906;

			internal Exec _0024_0024s540_0024call_00241929_002419907;

			internal IEnumerator _0024_0024s540_0024call_00241928_002419908;

			internal object _0024_0024s540_0024call_00241930_002419909;

			internal Exec _0024_0024s540_0024call_00241932_002419910;

			internal IEnumerator _0024_0024s540_0024call_00241931_002419911;

			internal object _0024_0024s540_0024call_00241933_002419912;

			internal Exec _0024_0024s540_0024call_00241935_002419913;

			internal IEnumerator _0024_0024s540_0024call_00241934_002419914;

			internal object _0024_0024s540_0024call_00241936_002419915;

			internal Exec _0024_0024s540_0024call_00241938_002419916;

			internal IEnumerator _0024_0024s540_0024call_00241937_002419917;

			internal object _0024_0024s540_0024call_00241939_002419918;

			internal IEnumerator _0024_0024iterator_002413789_002419919;

			internal IEnumerator _0024_0024iterator_002413790_002419920;

			internal IEnumerator _0024_0024iterator_002413791_002419921;

			internal IEnumerator _0024_0024iterator_002413792_002419922;

			internal IEnumerator _0024_0024iterator_002413793_002419923;

			internal IEnumerator _0024_0024iterator_002413794_002419924;

			internal IEnumerator _0024_0024iterator_002413795_002419925;

			internal IEnumerator _0024_0024iterator_002413796_002419926;

			internal IEnumerator _0024_0024iterator_002413797_002419927;

			internal IEnumerator _0024_0024iterator_002413798_002419928;

			internal IEnumerator _0024_0024iterator_002413799_002419929;

			internal IEnumerator _0024_0024iterator_002413800_002419930;

			internal IEnumerator _0024_0024iterator_002413801_002419931;

			internal IEnumerator _0024_0024iterator_002413802_002419932;

			internal IEnumerator _0024_0024iterator_002413803_002419933;

			internal IEnumerator _0024_0024iterator_002413804_002419934;

			internal TutorialEvent _0024self__002419935;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419935 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002419862 = "S540_tutorial_ui_colosseumu";
					_0024_0024CUR_EXEC_0024_002419863 = _0024self__002419935.lastCreatedExec;
					_0024ud_002419864 = UserData.Current;
					if (_0024ud_002419864 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002419865 = null;
					_0024tutoRoot_002419866 = null;
					_0024flagID1_002419867 = _0024ud_002419864.hasFlag("s01ColosseumTopTuto");
					if (!_0024flagID1_002419867)
					{
						_0024ud_002419864.setFlag("s01ColosseumTopTuto");
						_0024flagID1_002419867 = true;
						_0024fader_002419868 = FaderCore.Instance;
						goto IL_0127;
					}
					goto IL_095a;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_0127;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_01fe;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_0235;
					}
					goto case 1;
				case 5:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_026b;
					}
					goto case 1;
				case 6:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_02a7;
					}
					goto case 1;
				case 7:
					if (_0024_0024iterator_002413789_002419919.MoveNext())
					{
						_0024_0024s540_0024call_00241894_002419872 = _0024_0024iterator_002413789_002419919.Current;
						result = (Yield(7, _0024_0024s540_0024call_00241894_002419872) ? 1 : 0);
						break;
					}
					goto IL_0389;
				case 8:
					if (_0024_0024iterator_002413790_002419920.MoveNext())
					{
						_0024_0024s540_0024call_00241897_002419875 = _0024_0024iterator_002413790_002419920.Current;
						result = (Yield(8, _0024_0024s540_0024call_00241897_002419875) ? 1 : 0);
						break;
					}
					goto IL_046a;
				case 9:
					if (_0024_0024iterator_002413791_002419921.MoveNext())
					{
						_0024_0024s540_0024call_00241900_002419878 = _0024_0024iterator_002413791_002419921.Current;
						result = (Yield(9, _0024_0024s540_0024call_00241900_002419878) ? 1 : 0);
						break;
					}
					goto IL_0522;
				case 10:
					if (_0024_0024iterator_002413792_002419922.MoveNext())
					{
						_0024_0024s540_0024call_00241903_002419881 = _0024_0024iterator_002413792_002419922.Current;
						result = (Yield(10, _0024_0024s540_0024call_00241903_002419881) ? 1 : 0);
						break;
					}
					goto IL_0604;
				case 11:
					if (_0024_0024iterator_002413793_002419923.MoveNext())
					{
						_0024_0024s540_0024call_00241906_002419884 = _0024_0024iterator_002413793_002419923.Current;
						result = (Yield(11, _0024_0024s540_0024call_00241906_002419884) ? 1 : 0);
						break;
					}
					goto IL_06cb;
				case 12:
					if (_0024_0024iterator_002413794_002419924.MoveNext())
					{
						_0024_0024s540_0024call_00241909_002419887 = _0024_0024iterator_002413794_002419924.Current;
						result = (Yield(12, _0024_0024s540_0024call_00241909_002419887) ? 1 : 0);
						break;
					}
					goto IL_0783;
				case 13:
					if (_0024_0024iterator_002413795_002419925.MoveNext())
					{
						_0024_0024s540_0024call_00241912_002419890 = _0024_0024iterator_002413795_002419925.Current;
						result = (Yield(13, _0024_0024s540_0024call_00241912_002419890) ? 1 : 0);
						break;
					}
					goto IL_0865;
				case 14:
					if (_0024_0024iterator_002413796_002419926.MoveNext())
					{
						_0024_0024s540_0024call_00241915_002419893 = _0024_0024iterator_002413796_002419926.Current;
						result = (Yield(14, _0024_0024s540_0024call_00241915_002419893) ? 1 : 0);
						break;
					}
					goto IL_091d;
				case 15:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_09d0;
					}
					goto case 1;
				case 16:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_0aa7;
					}
					goto case 1;
				case 17:
					if (!_0024_0024CUR_EXEC_0024_002419863.NotExecuting)
					{
						goto IL_0adf;
					}
					goto case 1;
				case 18:
					if (_0024_0024iterator_002413797_002419927.MoveNext())
					{
						_0024_0024s540_0024call_00241918_002419897 = _0024_0024iterator_002413797_002419927.Current;
						result = (Yield(18, _0024_0024s540_0024call_00241918_002419897) ? 1 : 0);
						break;
					}
					goto IL_0bb6;
				case 19:
					if (_0024_0024iterator_002413798_002419928.MoveNext())
					{
						_0024_0024s540_0024call_00241921_002419900 = _0024_0024iterator_002413798_002419928.Current;
						result = (Yield(19, _0024_0024s540_0024call_00241921_002419900) ? 1 : 0);
						break;
					}
					goto IL_0c87;
				case 20:
					if (_0024_0024iterator_002413799_002419929.MoveNext())
					{
						_0024_0024s540_0024call_00241924_002419903 = _0024_0024iterator_002413799_002419929.Current;
						result = (Yield(20, _0024_0024s540_0024call_00241924_002419903) ? 1 : 0);
						break;
					}
					goto IL_0d62;
				case 21:
					if (_0024_0024iterator_002413800_002419930.MoveNext())
					{
						_0024_0024s540_0024call_00241927_002419906 = _0024_0024iterator_002413800_002419930.Current;
						result = (Yield(21, _0024_0024s540_0024call_00241927_002419906) ? 1 : 0);
						break;
					}
					goto IL_0e1a;
				case 22:
					if (_0024_0024iterator_002413801_002419931.MoveNext())
					{
						_0024_0024s540_0024call_00241930_002419909 = _0024_0024iterator_002413801_002419931.Current;
						result = (Yield(22, _0024_0024s540_0024call_00241930_002419909) ? 1 : 0);
						break;
					}
					goto IL_0ef0;
				case 23:
					if (_0024_0024iterator_002413802_002419932.MoveNext())
					{
						_0024_0024s540_0024call_00241933_002419912 = _0024_0024iterator_002413802_002419932.Current;
						result = (Yield(23, _0024_0024s540_0024call_00241933_002419912) ? 1 : 0);
						break;
					}
					goto IL_0fc1;
				case 24:
					if (_0024_0024iterator_002413803_002419933.MoveNext())
					{
						_0024_0024s540_0024call_00241936_002419915 = _0024_0024iterator_002413803_002419933.Current;
						result = (Yield(24, _0024_0024s540_0024call_00241936_002419915) ? 1 : 0);
						break;
					}
					goto IL_1092;
				case 25:
					if (_0024_0024iterator_002413804_002419934.MoveNext())
					{
						_0024_0024s540_0024call_00241939_002419918 = _0024_0024iterator_002413804_002419934.Current;
						result = (Yield(25, _0024_0024s540_0024call_00241939_002419918) ? 1 : 0);
						break;
					}
					goto IL_114a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0783:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					_0024worldColosseumMain_002419869.CurWebView.gameObject.SetActive(value: false);
					BattleHUD.PointTutorialArrowToColossumFrinendBattle();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:211", "call命令");
					_0024_0024s540_0024call_00241911_002419888 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241910_002419889 = _0024self__002419935.S540_tutorial_npc(string.Empty, "フレンドと対戦するモードだ。\nブリーダーポイントは増減しないぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241910_002419889 != null)
					{
						_0024_0024iterator_002413795_002419925 = _0024_0024s540_0024call_00241910_002419889;
						goto case 13;
					}
					goto IL_0865;
					IL_0127:
					if (!_0024fader_002419868 || !_0024fader_002419868.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024go_002419865)
					{
						_0024go_002419865 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002419866 && (bool)_0024go_002419865)
					{
						_0024tutoRoot_002419866 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002419865);
					}
					_0024worldColosseumMain_002419869 = (WorldColosseumMain)UnityEngine.Object.FindObjectOfType(typeof(WorldColosseumMain));
					if (!(null != _0024worldColosseumMain_002419869))
					{
						throw new AssertionFailedException("null != worldColosseumMain");
					}
					goto IL_01fe;
					IL_0bb6:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToColossumPoppet1();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:247", "call命令");
					_0024_0024s540_0024call_00241920_002419898 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241919_002419899 = _0024self__002419935.S540_tutorial_npc(string.Empty, "左端の魔ペットがリーダーとなる。\nリーダーのみ援護スキルが２つ発動可能だ！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241919_002419899 != null)
					{
						_0024_0024iterator_002413798_002419928 = _0024_0024s540_0024call_00241919_002419899;
						goto case 19;
					}
					goto IL_0c87;
					IL_0ef0:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					goto IL_0f10;
					IL_0865:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:213", "call命令");
					_0024_0024s540_0024call_00241914_002419891 = _0024self__002419935.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241913_002419892 = _0024self__002419935.S540_message_end();
					if (_0024_0024s540_0024call_00241913_002419892 != null)
					{
						_0024_0024iterator_002413796_002419926 = _0024_0024s540_0024call_00241913_002419892;
						goto case 14;
					}
					goto IL_091d;
					IL_091d:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002419935, active: false);
					_0024worldColosseumMain_002419869.CurWebView.gameObject.SetActive(value: true);
					goto IL_095a;
					IL_01fe:
					if (_0024worldColosseumMain_002419869.Mode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0235;
					IL_0235:
					if (_0024worldColosseumMain_002419869.IsChangingSituation)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_026b;
					IL_026b:
					if (!(null != _0024worldColosseumMain_002419869.CurWebView))
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_02a7;
					IL_02a7:
					if (!_0024worldColosseumMain_002419869.CurWebView.active)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024worldColosseumMain_002419869.CurWebView.gameObject.SetActive(value: false);
					ModalCollider.SetActive(_0024self__002419935, active: true);
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:194", "call命令");
					_0024_0024s540_0024call_00241893_002419870 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241892_002419871 = _0024self__002419935.S540_tutorial_npc(string.Empty, "闘技場では、魔ペット同士を\n戦わせることができるぞ！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241892_002419871 != null)
					{
						_0024_0024iterator_002413789_002419919 = _0024_0024s540_0024call_00241892_002419871;
						goto case 7;
					}
					goto IL_0389;
					IL_0f10:
					BattleHUD.PointTutorialArrowToColosseumDeckCost();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:263", "call命令");
					_0024_0024s540_0024call_00241932_002419910 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241931_002419911 = _0024self__002419935.S540_tutorial_npc(string.Empty, "魔ペットにはそれぞれコストがある。\nイベントによってはデッキ制限もあるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241931_002419911 != null)
					{
						_0024_0024iterator_002413802_002419932 = _0024_0024s540_0024call_00241931_002419911;
						goto case 23;
					}
					goto IL_0fc1;
					IL_095a:
					_0024flagID2_002419894 = _0024ud_002419864.hasFlag("s01ColosseumConfTuto");
					if (!_0024flagID2_002419894 && _0024flagID1_002419867)
					{
						_0024ud_002419864.setFlag("s01ColosseumConfTuto");
						_0024flagID2_002419894 = true;
						_0024fader_002419868 = FaderCore.Instance;
						goto IL_09d0;
					}
					goto IL_1171;
					IL_0389:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					_0024worldColosseumMain_002419869.CurWebView.gameObject.SetActive(value: false);
					BattleHUD.PointTutorialArrowToColossumRandombattle();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:198", "call命令");
					_0024_0024s540_0024call_00241896_002419873 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241895_002419874 = _0024self__002419935.S540_tutorial_npc(string.Empty, "自動で選択された相手と対戦するモードだ。\n結果次第でブリーダーポイントが増減する！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241895_002419874 != null)
					{
						_0024_0024iterator_002413790_002419920 = _0024_0024s540_0024call_00241895_002419874;
						goto case 8;
					}
					goto IL_046a;
					IL_0c87:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToColossumWeapon1();
					BattleHUD.PointTutorialArrowToColossumWeapon2();
					BattleHUD.PointTutorialArrowToColossumWeapon3();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:253", "call命令");
					_0024_0024s540_0024call_00241923_002419901 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241922_002419902 = _0024self__002419935.S540_tutorial_npc(string.Empty, "魔ペットは武器を装備できるぞ。武器の\n援護スキルは装備した魔ペットのみ有効だ！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241922_002419902 != null)
					{
						_0024_0024iterator_002413799_002419929 = _0024_0024s540_0024call_00241922_002419902;
						goto case 20;
					}
					goto IL_0d62;
					IL_09d0:
					if (!_0024fader_002419868 || !_0024fader_002419868.isOutCompleted)
					{
						result = (YieldDefault(15) ? 1 : 0);
						break;
					}
					if (!_0024go_002419865)
					{
						_0024go_002419865 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002419866 && (bool)_0024go_002419865)
					{
						_0024tutoRoot_002419866 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002419865);
					}
					_0024worldColosseumMain_002419869 = (WorldColosseumMain)UnityEngine.Object.FindObjectOfType(typeof(WorldColosseumMain));
					if (!_0024worldColosseumMain_002419869)
					{
						throw new AssertionFailedException("worldColosseumMain");
					}
					goto IL_0aa7;
					IL_046a:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:200", "call命令");
					_0024_0024s540_0024call_00241899_002419876 = _0024self__002419935.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241898_002419877 = _0024self__002419935.S540_message_end();
					if (_0024_0024s540_0024call_00241898_002419877 != null)
					{
						_0024_0024iterator_002413791_002419921 = _0024_0024s540_0024call_00241898_002419877;
						goto case 9;
					}
					goto IL_0522;
					IL_1171:
					_0024self__002419935.stop(_0024_0024CUR_EXEC_0024_002419863);
					goto case 1;
					IL_0fc1:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToColossumStart();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:267", "call命令");
					_0024_0024s540_0024call_00241935_002419913 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241934_002419914 = _0024self__002419935.S540_tutorial_npc(string.Empty, "準備がよければ\n『出撃する！』でバトル開始だ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241934_002419914 != null)
					{
						_0024_0024iterator_002413803_002419933 = _0024_0024s540_0024call_00241934_002419914;
						goto case 24;
					}
					goto IL_1092;
					IL_0522:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					_0024worldColosseumMain_002419869.CurWebView.gameObject.SetActive(value: false);
					BattleHUD.PointTutorialArrowToColossumRank();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:204", "call命令");
					_0024_0024s540_0024call_00241902_002419879 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241901_002419880 = _0024self__002419935.S540_tutorial_npc(string.Empty, "ブリーダーランクを上げることで強い相手と\n戦えるようになったり報酬が得られる。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241901_002419880 != null)
					{
						_0024_0024iterator_002413792_002419922 = _0024_0024s540_0024call_00241901_002419880;
						goto case 10;
					}
					goto IL_0604;
					IL_0d62:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:255", "call命令");
					_0024_0024s540_0024call_00241926_002419904 = _0024self__002419935.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241925_002419905 = _0024self__002419935.S540_message_end();
					if (_0024_0024s540_0024call_00241925_002419905 != null)
					{
						_0024_0024iterator_002413800_002419930 = _0024_0024s540_0024call_00241925_002419905;
						goto case 21;
					}
					goto IL_0e1a;
					IL_0604:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:205", "call命令");
					_0024_0024s540_0024call_00241905_002419882 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241904_002419883 = _0024self__002419935.S540_tutorial_npc(string.Empty, "ブリーダーランクは、ブリーダーポイントを\n増やすことでランクアップするぞ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241904_002419883 != null)
					{
						_0024_0024iterator_002413793_002419923 = _0024_0024s540_0024call_00241904_002419883;
						goto case 11;
					}
					goto IL_06cb;
					IL_114a:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002419935, active: false);
					goto IL_1171;
					IL_0e1a:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					if (Kamcord.IsEnabled())
					{
						BattleHUD.PointTutorialArrowToColossumRecord();
						_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:259", "call命令");
						_0024_0024s540_0024call_00241929_002419907 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
						_0024_0024s540_0024call_00241928_002419908 = _0024self__002419935.S540_tutorial_npc(string.Empty, "対戦撮影ボタンをONにすると\nバトル開始から終了まで自動撮影されるぞ。", TUTORIAL_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00241928_002419908 != null)
						{
							_0024_0024iterator_002413801_002419931 = _0024_0024s540_0024call_00241928_002419908;
							goto case 22;
						}
						goto IL_0ef0;
					}
					goto IL_0f10;
					IL_0aa7:
					if (_0024worldColosseumMain_002419869.Mode != WorldColosseumMain.WORLD_POPPET_BATTLE_MODE.DeckColosseum)
					{
						result = (YieldDefault(16) ? 1 : 0);
						break;
					}
					goto IL_0adf;
					IL_06cb:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:207", "call命令");
					_0024_0024s540_0024call_00241908_002419885 = _0024self__002419935.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241907_002419886 = _0024self__002419935.S540_message_end();
					if (_0024_0024s540_0024call_00241907_002419886 != null)
					{
						_0024_0024iterator_002413794_002419924 = _0024_0024s540_0024call_00241907_002419886;
						goto case 12;
					}
					goto IL_0783;
					IL_0adf:
					if (_0024worldColosseumMain_002419869.IsChangingSituation)
					{
						result = (YieldDefault(17) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002419935, active: true);
					BattleHUD.PointTutorialArrowToColossumPoppet1();
					BattleHUD.PointTutorialArrowToColossumPoppet2();
					BattleHUD.PointTutorialArrowToColossumPoppet3();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:243", "call命令");
					_0024_0024s540_0024call_00241917_002419895 = _0024self__002419935.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241916_002419896 = _0024self__002419935.S540_tutorial_npc(string.Empty, "闘技場で戦う魔ペットを選択しよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241916_002419896 != null)
					{
						_0024_0024iterator_002413797_002419927 = _0024_0024s540_0024call_00241916_002419896;
						goto case 18;
					}
					goto IL_0bb6;
					IL_1092:
					if (!_0024self__002419935.isExecuting(_0024_0024CUR_EXEC_0024_002419863))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002419935.dtrace(_0024_0024CUR_EXEC_0024_002419863, "TutorialEvent.boo:269", "call命令");
					_0024_0024s540_0024call_00241938_002419916 = _0024self__002419935.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419863);
					_0024_0024s540_0024call_00241937_002419917 = _0024self__002419935.S540_message_end();
					if (_0024_0024s540_0024call_00241937_002419917 != null)
					{
						_0024_0024iterator_002413804_002419934 = _0024_0024s540_0024call_00241937_002419917;
						goto case 25;
					}
					goto IL_114a;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002419936;

		public _0024S540_tutorial_ui_colosseumu_002419861(TutorialEvent self_)
		{
			_0024self__002419936 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419936);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_townBlacksmith_002419937 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241959_002419938;

			internal object _0024___item_002419939;

			internal IEnumerator _0024_0024iterator_002413805_002419940;

			internal TutorialEvent _0024self__002419941;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419941 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241959_002419938 = _0024self__002419941.S540_tutorial_ui_townBlacksmith(null);
					if (_0024_0024s540_0024ycode_00241959_002419938 != null)
					{
						_0024_0024iterator_002413805_002419940 = _0024_0024s540_0024ycode_00241959_002419938;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413805_002419940.MoveNext())
					{
						_0024___item_002419939 = _0024_0024iterator_002413805_002419940.Current;
						result = (Yield(2, _0024___item_002419939) ? 1 : 0);
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

		internal TutorialEvent _0024self__002419942;

		public _0024S540_tutorial_ui_townBlacksmith_002419937(TutorialEvent self_)
		{
			_0024self__002419942 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419942);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_townBlacksmith_002419943 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002419944;

			internal Exec _0024_0024CUR_EXEC_0024_002419945;

			internal UserData _0024ud_002419946;

			internal FaderCore _0024fader_002419947;

			internal TownBlacksmithMain _0024townBlacksmithMain_002419948;

			internal Exec _0024_0024s540_0024call_00241942_002419949;

			internal IEnumerator _0024_0024s540_0024call_00241941_002419950;

			internal object _0024_0024s540_0024call_00241943_002419951;

			internal Exec _0024_0024s540_0024call_00241945_002419952;

			internal IEnumerator _0024_0024s540_0024call_00241944_002419953;

			internal object _0024_0024s540_0024call_00241946_002419954;

			internal Exec _0024_0024s540_0024call_00241948_002419955;

			internal IEnumerator _0024_0024s540_0024call_00241947_002419956;

			internal object _0024_0024s540_0024call_00241949_002419957;

			internal Exec _0024_0024s540_0024call_00241951_002419958;

			internal IEnumerator _0024_0024s540_0024call_00241950_002419959;

			internal object _0024_0024s540_0024call_00241952_002419960;

			internal Exec _0024_0024s540_0024call_00241954_002419961;

			internal IEnumerator _0024_0024s540_0024call_00241953_002419962;

			internal object _0024_0024s540_0024call_00241955_002419963;

			internal Exec _0024_0024s540_0024call_00241957_002419964;

			internal IEnumerator _0024_0024s540_0024call_00241956_002419965;

			internal object _0024_0024s540_0024call_00241958_002419966;

			internal IEnumerator _0024_0024iterator_002413806_002419967;

			internal IEnumerator _0024_0024iterator_002413807_002419968;

			internal IEnumerator _0024_0024iterator_002413808_002419969;

			internal IEnumerator _0024_0024iterator_002413809_002419970;

			internal IEnumerator _0024_0024iterator_002413810_002419971;

			internal IEnumerator _0024_0024iterator_002413811_002419972;

			internal TutorialEvent _0024self__002419973;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419973 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002419944 = "S540_tutorial_ui_townBlacksmith";
					_0024_0024CUR_EXEC_0024_002419945 = _0024self__002419973.lastCreatedExec;
					_0024ud_002419946 = UserData.Current;
					if (_0024ud_002419946 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					if (!_0024ud_002419946.hasFlag("s01GouseiKyoukaTuto"))
					{
						_0024ud_002419946.setFlag("s01GouseiKyoukaTuto");
						_0024fader_002419947 = FaderCore.Instance;
						goto IL_00ca;
					}
					goto IL_0636;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002419945.NotExecuting)
					{
						goto IL_00ca;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002419945.NotExecuting)
					{
						goto IL_0145;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002419945.NotExecuting)
					{
						goto IL_017c;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413806_002419967.MoveNext())
					{
						_0024_0024s540_0024call_00241943_002419951 = _0024_0024iterator_002413806_002419967.Current;
						result = (Yield(5, _0024_0024s540_0024call_00241943_002419951) ? 1 : 0);
						break;
					}
					goto IL_0243;
				case 6:
					if (_0024_0024iterator_002413807_002419968.MoveNext())
					{
						_0024_0024s540_0024call_00241946_002419954 = _0024_0024iterator_002413807_002419968.Current;
						result = (Yield(6, _0024_0024s540_0024call_00241946_002419954) ? 1 : 0);
						break;
					}
					goto IL_0309;
				case 7:
					if (_0024_0024iterator_002413808_002419969.MoveNext())
					{
						_0024_0024s540_0024call_00241949_002419957 = _0024_0024iterator_002413808_002419969.Current;
						result = (Yield(7, _0024_0024s540_0024call_00241949_002419957) ? 1 : 0);
						break;
					}
					goto IL_03cf;
				case 8:
					if (_0024_0024iterator_002413809_002419970.MoveNext())
					{
						_0024_0024s540_0024call_00241952_002419960 = _0024_0024iterator_002413809_002419970.Current;
						result = (Yield(8, _0024_0024s540_0024call_00241952_002419960) ? 1 : 0);
						break;
					}
					goto IL_0495;
				case 9:
					if (_0024_0024iterator_002413810_002419971.MoveNext())
					{
						_0024_0024s540_0024call_00241955_002419963 = _0024_0024iterator_002413810_002419971.Current;
						result = (Yield(9, _0024_0024s540_0024call_00241955_002419963) ? 1 : 0);
						break;
					}
					goto IL_055c;
				case 10:
					if (_0024_0024iterator_002413811_002419972.MoveNext())
					{
						_0024_0024s540_0024call_00241958_002419966 = _0024_0024iterator_002413811_002419972.Current;
						result = (Yield(10, _0024_0024s540_0024call_00241958_002419966) ? 1 : 0);
						break;
					}
					goto IL_060f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0309:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:291", "call命令");
					_0024_0024s540_0024call_00241948_002419955 = _0024self__002419973.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241947_002419956 = _0024self__002419973.S540_tutorial_npc(string.Empty, "なお、進化合成には、武器、魔ペットごとに\n必要な素材があるぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241947_002419956 != null)
					{
						_0024_0024iterator_002413808_002419969 = _0024_0024s540_0024call_00241947_002419956;
						goto case 7;
					}
					goto IL_03cf;
					IL_00ca:
					if (!_0024fader_002419947 || !_0024fader_002419947.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024townBlacksmithMain_002419948 = (TownBlacksmithMain)UnityEngine.Object.FindObjectOfType(typeof(TownBlacksmithMain));
					if (!_0024townBlacksmithMain_002419948)
					{
						throw new AssertionFailedException("townBlacksmithMain");
					}
					goto IL_0145;
					IL_055c:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:294", "call命令");
					_0024_0024s540_0024call_00241957_002419964 = _0024self__002419973.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241956_002419965 = _0024self__002419973.S540_message_end();
					if (_0024_0024s540_0024call_00241956_002419965 != null)
					{
						_0024_0024iterator_002413811_002419972 = _0024_0024s540_0024call_00241956_002419965;
						goto case 10;
					}
					goto IL_060f;
					IL_03cf:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:292", "call命令");
					_0024_0024s540_0024call_00241951_002419958 = _0024self__002419973.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241950_002419959 = _0024self__002419973.S540_tutorial_npc(string.Empty, "合成用の素材は、曜日限定クエストや\nゲリラクエストなどで入手可能だ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241950_002419959 != null)
					{
						_0024_0024iterator_002413809_002419970 = _0024_0024s540_0024call_00241950_002419959;
						goto case 8;
					}
					goto IL_0495;
					IL_0145:
					if (_0024townBlacksmithMain_002419948.Mode != TownBlacksmithMain.MODE_TOWN_BLACKSMITH.TopMenu)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_017c;
					IL_017c:
					if (_0024townBlacksmithMain_002419948.IsChangingSituation)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002419973, active: true);
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:289", "call命令");
					_0024_0024s540_0024call_00241942_002419949 = _0024self__002419973.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241941_002419950 = _0024self__002419973.S540_tutorial_npc(string.Empty, "工房では、武器や魔ペットを\nパワーアップすることができるぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241941_002419950 != null)
					{
						_0024_0024iterator_002413806_002419967 = _0024_0024s540_0024call_00241941_002419950;
						goto case 5;
					}
					goto IL_0243;
					IL_0636:
					_0024self__002419973.stop(_0024_0024CUR_EXEC_0024_002419945);
					goto case 1;
					IL_0495:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:293", "call命令");
					_0024_0024s540_0024call_00241954_002419961 = _0024self__002419973.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241953_002419962 = _0024self__002419973.S540_tutorial_npc(string.Empty, "合成に使った素材はなくなってしまうので\n気をつけよう！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241953_002419962 != null)
					{
						_0024_0024iterator_002413810_002419971 = _0024_0024s540_0024call_00241953_002419962;
						goto case 9;
					}
					goto IL_055c;
					IL_0243:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					_0024self__002419973.dtrace(_0024_0024CUR_EXEC_0024_002419945, "TutorialEvent.boo:290", "call命令");
					_0024_0024s540_0024call_00241945_002419952 = _0024self__002419973.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419945);
					_0024_0024s540_0024call_00241944_002419953 = _0024self__002419973.S540_tutorial_npc(string.Empty, "レベルを上げたいときは強化合成。\n上位に進化させたいときは進化合成だ！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241944_002419953 != null)
					{
						_0024_0024iterator_002413807_002419968 = _0024_0024s540_0024call_00241944_002419953;
						goto case 6;
					}
					goto IL_0309;
					IL_060f:
					if (!_0024self__002419973.isExecuting(_0024_0024CUR_EXEC_0024_002419945))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002419973, active: false);
					goto IL_0636;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002419974;

		public _0024S540_tutorial_ui_townBlacksmith_002419943(TutorialEvent self_)
		{
			_0024self__002419974 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419974);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_town_002419975 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00241976_002419976;

			internal object _0024___item_002419977;

			internal IEnumerator _0024_0024iterator_002413812_002419978;

			internal TutorialEvent _0024self__002419979;

			public _0024(TutorialEvent self_)
			{
				_0024self__002419979 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00241976_002419976 = _0024self__002419979.S540_tutorial_town(null);
					if (_0024_0024s540_0024ycode_00241976_002419976 != null)
					{
						_0024_0024iterator_002413812_002419978 = _0024_0024s540_0024ycode_00241976_002419976;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413812_002419978.MoveNext())
					{
						_0024___item_002419977 = _0024_0024iterator_002413812_002419978.Current;
						result = (Yield(2, _0024___item_002419977) ? 1 : 0);
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

		internal TutorialEvent _0024self__002419980;

		public _0024S540_tutorial_town_002419975(TutorialEvent self_)
		{
			_0024self__002419980 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419980);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_town_002419981 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002419982;

			internal Exec _0024_0024CUR_EXEC_0024_002419983;

			internal UserData _0024ud_002419984;

			internal int _0024_0024s540_0024loop_00241960_002419985;

			internal FaderCore _0024fader_002419986;

			internal GameObject _0024go_002419987;

			internal Exec _0024_0024s540_0024call_00241962_002419988;

			internal IEnumerator _0024_0024s540_0024call_00241961_002419989;

			internal object _0024_0024s540_0024call_00241963_002419990;

			internal Exec _0024_0024s540_0024call_00241965_002419991;

			internal IEnumerator _0024_0024s540_0024call_00241964_002419992;

			internal object _0024_0024s540_0024call_00241966_002419993;

			internal Exec _0024_0024s540_0024call_00241968_002419994;

			internal IEnumerator _0024_0024s540_0024call_00241967_002419995;

			internal object _0024_0024s540_0024call_00241969_002419996;

			internal Exec _0024_0024s540_0024call_00241971_002419997;

			internal IEnumerator _0024_0024s540_0024call_00241970_002419998;

			internal object _0024_0024s540_0024call_00241972_002419999;

			internal Exec _0024_0024s540_0024call_00241974_002420000;

			internal IEnumerator _0024_0024s540_0024call_00241973_002420001;

			internal object _0024_0024s540_0024call_00241975_002420002;

			internal IEnumerator _0024_0024iterator_002413813_002420003;

			internal IEnumerator _0024_0024iterator_002413814_002420004;

			internal IEnumerator _0024_0024iterator_002413815_002420005;

			internal IEnumerator _0024_0024iterator_002413816_002420006;

			internal IEnumerator _0024_0024iterator_002413817_002420007;

			internal TutorialEvent _0024self__002420008;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420008 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002419982 = "S540_tutorial_town";
					_0024_0024CUR_EXEC_0024_002419983 = _0024self__002420008.lastCreatedExec;
					_0024ud_002419984 = UserData.Current;
					if (_0024ud_002419984 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:333", "loop命令");
					goto IL_008c;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002419983.NotExecuting)
					{
						goto IL_0103;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413813_002420003.MoveNext())
					{
						_0024_0024s540_0024call_00241963_002419990 = _0024_0024iterator_002413813_002420003.Current;
						result = (Yield(3, _0024_0024s540_0024call_00241963_002419990) ? 1 : 0);
						break;
					}
					goto IL_01f4;
				case 4:
					if (_0024_0024iterator_002413814_002420004.MoveNext())
					{
						_0024_0024s540_0024call_00241966_002419993 = _0024_0024iterator_002413814_002420004.Current;
						result = (Yield(4, _0024_0024s540_0024call_00241966_002419993) ? 1 : 0);
						break;
					}
					goto IL_02c4;
				case 5:
					if (_0024_0024iterator_002413815_002420005.MoveNext())
					{
						_0024_0024s540_0024call_00241969_002419996 = _0024_0024iterator_002413815_002420005.Current;
						result = (Yield(5, _0024_0024s540_0024call_00241969_002419996) ? 1 : 0);
						break;
					}
					goto IL_038a;
				case 6:
					if (_0024_0024iterator_002413816_002420006.MoveNext())
					{
						_0024_0024s540_0024call_00241972_002419999 = _0024_0024iterator_002413816_002420006.Current;
						result = (Yield(6, _0024_0024s540_0024call_00241972_002419999) ? 1 : 0);
						break;
					}
					goto IL_0450;
				case 7:
					if (_0024_0024iterator_002413817_002420007.MoveNext())
					{
						_0024_0024s540_0024call_00241975_002420002 = _0024_0024iterator_002413817_002420007.Current;
						result = (Yield(7, _0024_0024s540_0024call_00241975_002420002) ? 1 : 0);
						break;
					}
					goto IL_0507;
				case 8:
					if (_0024_0024CUR_EXEC_0024_002419983.NotExecuting)
					{
						goto case 1;
					}
					goto IL_008c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0450:
					if (!_0024self__002420008.isExecuting(_0024_0024CUR_EXEC_0024_002419983))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:351", "call命令");
					_0024_0024s540_0024call_00241974_002420000 = _0024self__002420008.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002419983);
					_0024_0024s540_0024call_00241973_002420001 = _0024self__002420008.S540_message_end();
					if (_0024_0024s540_0024call_00241973_002420001 != null)
					{
						_0024_0024iterator_002413817_002420007 = _0024_0024s540_0024call_00241973_002420001;
						goto case 7;
					}
					goto IL_0507;
					IL_02c4:
					if (!_0024self__002420008.isExecuting(_0024_0024CUR_EXEC_0024_002419983))
					{
						goto case 1;
					}
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:348", "call命令");
					_0024_0024s540_0024call_00241968_002419994 = _0024self__002420008.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419983);
					_0024_0024s540_0024call_00241967_002419995 = _0024self__002420008.S540_tutorial_npc(string.Empty, "『白』は天使のときだけ\n『黒』は悪魔のときだけ見えるぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241967_002419995 != null)
					{
						_0024_0024iterator_002413815_002420005 = _0024_0024s540_0024call_00241967_002419995;
						goto case 5;
					}
					goto IL_038a;
					IL_008c:
					_0024_0024s540_0024loop_00241960_002419985 = Time.frameCount;
					if (!_0024ud_002419984.hasFlag("s01TamagoeTuto") && _0024ud_002419984.hasFlag("s01Main05"))
					{
						_0024ud_002419984.setFlag("s01TamagoeTuto");
						_0024fader_002419986 = FaderCore.Instance;
						goto IL_0103;
					}
					goto IL_0522;
					IL_0522:
					if (_0024_0024s540_0024loop_00241960_002419985 == Time.frameCount)
					{
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					goto case 8;
					IL_0103:
					if (!_0024fader_002419986 || !_0024fader_002419986.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024go_002419987 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Town") as GameObject;
					UnityEngine.Object.Instantiate(_0024go_002419987);
					BattleHUD.DrawTutorialTalkImage();
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:344", "call命令");
					_0024_0024s540_0024call_00241962_002419988 = _0024self__002420008.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419983);
					_0024_0024s540_0024call_00241961_002419989 = _0024self__002420008.S540_tutorial_npc(string.Empty, "魂声（たまごえ）は心の声だ。\n町の人々に近づいて見てみよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241961_002419989 != null)
					{
						_0024_0024iterator_002413813_002420003 = _0024_0024s540_0024call_00241961_002419989;
						goto case 3;
					}
					goto IL_01f4;
					IL_038a:
					if (!_0024self__002420008.isExecuting(_0024_0024CUR_EXEC_0024_002419983))
					{
						goto case 1;
					}
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:349", "call命令");
					_0024_0024s540_0024call_00241971_002419997 = _0024self__002420008.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419983);
					_0024_0024s540_0024call_00241970_002419998 = _0024self__002420008.S540_tutorial_npc(string.Empty, "もし片方の姿で見えなくても\n転身してもういちど試してみよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241970_002419998 != null)
					{
						_0024_0024iterator_002413816_002420006 = _0024_0024s540_0024call_00241970_002419998;
						goto case 6;
					}
					goto IL_0450;
					IL_0507:
					if (_0024self__002420008.isExecuting(_0024_0024CUR_EXEC_0024_002419983))
					{
						goto IL_0522;
					}
					goto case 1;
					IL_01f4:
					if (!_0024self__002420008.isExecuting(_0024_0024CUR_EXEC_0024_002419983))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialSoulVoicesImage();
					_0024self__002420008.dtrace(_0024_0024CUR_EXEC_0024_002419983, "TutorialEvent.boo:347", "call命令");
					_0024_0024s540_0024call_00241965_002419991 = _0024self__002420008.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002419983);
					_0024_0024s540_0024call_00241964_002419992 = _0024self__002420008.S540_tutorial_npc(string.Empty, "魂声は『白』と『黒』の二種類が存在する。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241964_002419992 != null)
					{
						_0024_0024iterator_002413814_002420004 = _0024_0024s540_0024call_00241964_002419992;
						goto case 4;
					}
					goto IL_02c4;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420009;

		public _0024S540_tutorial_town_002419981(TutorialEvent self_)
		{
			_0024self__002420009 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420009);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_worldRaid_002420010 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242001_002420011;

			internal object _0024___item_002420012;

			internal IEnumerator _0024_0024iterator_002413818_002420013;

			internal TutorialEvent _0024self__002420014;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420014 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242001_002420011 = _0024self__002420014.S540_tutorial_ui_worldRaid(null);
					if (_0024_0024s540_0024ycode_00242001_002420011 != null)
					{
						_0024_0024iterator_002413818_002420013 = _0024_0024s540_0024ycode_00242001_002420011;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413818_002420013.MoveNext())
					{
						_0024___item_002420012 = _0024_0024iterator_002413818_002420013.Current;
						result = (Yield(2, _0024___item_002420012) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420015;

		public _0024S540_tutorial_ui_worldRaid_002420010(TutorialEvent self_)
		{
			_0024self__002420015 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420015);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_worldRaid_002420016 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420017;

			internal Exec _0024_0024CUR_EXEC_0024_002420018;

			internal UserData _0024ud_002420019;

			internal GameObject _0024go_002420020;

			internal GameObject _0024tutoRoot_002420021;

			internal FaderCore _0024fader_002420022;

			internal WorldRaidMain _0024worldRaidMain_002420023;

			internal Exec _0024_0024s540_0024call_00241978_002420024;

			internal IEnumerator _0024_0024s540_0024call_00241977_002420025;

			internal object _0024_0024s540_0024call_00241979_002420026;

			internal Exec _0024_0024s540_0024call_00241981_002420027;

			internal IEnumerator _0024_0024s540_0024call_00241980_002420028;

			internal object _0024_0024s540_0024call_00241982_002420029;

			internal Exec _0024_0024s540_0024call_00241984_002420030;

			internal IEnumerator _0024_0024s540_0024call_00241983_002420031;

			internal object _0024_0024s540_0024call_00241985_002420032;

			internal Exec _0024_0024s540_0024call_00241987_002420033;

			internal IEnumerator _0024_0024s540_0024call_00241986_002420034;

			internal object _0024_0024s540_0024call_00241988_002420035;

			internal Exec _0024_0024s540_0024call_00241990_002420036;

			internal IEnumerator _0024_0024s540_0024call_00241989_002420037;

			internal object _0024_0024s540_0024call_00241991_002420038;

			internal Exec _0024_0024s540_0024call_00241993_002420039;

			internal IEnumerator _0024_0024s540_0024call_00241992_002420040;

			internal object _0024_0024s540_0024call_00241994_002420041;

			internal Exec _0024_0024s540_0024call_00241996_002420042;

			internal IEnumerator _0024_0024s540_0024call_00241995_002420043;

			internal object _0024_0024s540_0024call_00241997_002420044;

			internal Exec _0024_0024s540_0024call_00241999_002420045;

			internal IEnumerator _0024_0024s540_0024call_00241998_002420046;

			internal object _0024_0024s540_0024call_00242000_002420047;

			internal IEnumerator _0024_0024iterator_002413819_002420048;

			internal IEnumerator _0024_0024iterator_002413820_002420049;

			internal IEnumerator _0024_0024iterator_002413821_002420050;

			internal IEnumerator _0024_0024iterator_002413822_002420051;

			internal IEnumerator _0024_0024iterator_002413823_002420052;

			internal IEnumerator _0024_0024iterator_002413824_002420053;

			internal IEnumerator _0024_0024iterator_002413825_002420054;

			internal IEnumerator _0024_0024iterator_002413826_002420055;

			internal TutorialEvent _0024self__002420056;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420056 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420017 = "S540_tutorial_ui_worldRaid";
					_0024_0024CUR_EXEC_0024_002420018 = _0024self__002420056.lastCreatedExec;
					_0024ud_002420019 = UserData.Current;
					if (_0024ud_002420019 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002420020 = null;
					_0024tutoRoot_002420021 = null;
					if (!_0024ud_002420019.hasFlag("s01RaidMenuTuto"))
					{
						_0024ud_002420019.setFlag("s01RaidMenuTuto");
						_0024fader_002420022 = FaderCore.Instance;
						goto IL_00e4;
					}
					goto IL_0892;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420018.NotExecuting)
					{
						goto IL_00e4;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420018.NotExecuting)
					{
						goto IL_01ba;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420018.NotExecuting)
					{
						goto IL_01f1;
					}
					goto case 1;
				case 5:
					if (!_0024_0024CUR_EXEC_0024_002420018.NotExecuting)
					{
						goto IL_0227;
					}
					goto case 1;
				case 6:
					if (_0024_0024iterator_002413819_002420048.MoveNext())
					{
						_0024_0024s540_0024call_00241979_002420026 = _0024_0024iterator_002413819_002420048.Current;
						result = (Yield(6, _0024_0024s540_0024call_00241979_002420026) ? 1 : 0);
						break;
					}
					goto IL_0306;
				case 7:
					if (_0024_0024iterator_002413820_002420049.MoveNext())
					{
						_0024_0024s540_0024call_00241982_002420029 = _0024_0024iterator_002413820_002420049.Current;
						result = (Yield(7, _0024_0024s540_0024call_00241982_002420029) ? 1 : 0);
						break;
					}
					goto IL_03cc;
				case 8:
					if (_0024_0024iterator_002413821_002420050.MoveNext())
					{
						_0024_0024s540_0024call_00241985_002420032 = _0024_0024iterator_002413821_002420050.Current;
						result = (Yield(8, _0024_0024s540_0024call_00241985_002420032) ? 1 : 0);
						break;
					}
					goto IL_0483;
				case 9:
					if (_0024_0024iterator_002413822_002420051.MoveNext())
					{
						_0024_0024s540_0024call_00241988_002420035 = _0024_0024iterator_002413822_002420051.Current;
						result = (Yield(9, _0024_0024s540_0024call_00241988_002420035) ? 1 : 0);
						break;
					}
					goto IL_054f;
				case 10:
					if (_0024_0024iterator_002413823_002420052.MoveNext())
					{
						_0024_0024s540_0024call_00241991_002420038 = _0024_0024iterator_002413823_002420052.Current;
						result = (Yield(10, _0024_0024s540_0024call_00241991_002420038) ? 1 : 0);
						break;
					}
					goto IL_0616;
				case 11:
					if (_0024_0024iterator_002413824_002420053.MoveNext())
					{
						_0024_0024s540_0024call_00241994_002420041 = _0024_0024iterator_002413824_002420053.Current;
						result = (Yield(11, _0024_0024s540_0024call_00241994_002420041) ? 1 : 0);
						break;
					}
					goto IL_06ec;
				case 12:
					if (_0024_0024iterator_002413825_002420054.MoveNext())
					{
						_0024_0024s540_0024call_00241997_002420044 = _0024_0024iterator_002413825_002420054.Current;
						result = (Yield(12, _0024_0024s540_0024call_00241997_002420044) ? 1 : 0);
						break;
					}
					goto IL_07b3;
				case 13:
					if (_0024_0024iterator_002413826_002420055.MoveNext())
					{
						_0024_0024s540_0024call_00242000_002420047 = _0024_0024iterator_002413826_002420055.Current;
						result = (Yield(13, _0024_0024s540_0024call_00242000_002420047) ? 1 : 0);
						break;
					}
					goto IL_086b;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0892:
					_0024self__002420056.stop(_0024_0024CUR_EXEC_0024_002420018);
					goto case 1;
					IL_00e4:
					if (!_0024fader_002420022 || !_0024fader_002420022.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024worldRaidMain_002420023 = (WorldRaidMain)UnityEngine.Object.FindObjectOfType(typeof(WorldRaidMain));
					if (!_0024worldRaidMain_002420023)
					{
						throw new AssertionFailedException("worldRaidMain");
					}
					if (!_0024go_002420020)
					{
						_0024go_002420020 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002420021 && (bool)_0024go_002420020)
					{
						_0024tutoRoot_002420021 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420020);
					}
					goto IL_01ba;
					IL_086b:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420056, active: false);
					goto IL_0892;
					IL_06ec:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:414", "call命令");
					_0024_0024s540_0024call_00241996_002420042 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241995_002420043 = _0024self__002420056.S540_tutorial_npc(string.Empty, "『全力攻撃』は、精神力を３消費するが\nボーナスダメージを与えることができるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241995_002420043 != null)
					{
						_0024_0024iterator_002413825_002420054 = _0024_0024s540_0024call_00241995_002420043;
						goto case 12;
					}
					goto IL_07b3;
					IL_07b3:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:416", "call命令");
					_0024_0024s540_0024call_00241999_002420045 = _0024self__002420056.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241998_002420046 = _0024self__002420056.S540_message_end();
					if (_0024_0024s540_0024call_00241998_002420046 != null)
					{
						_0024_0024iterator_002413826_002420055 = _0024_0024s540_0024call_00241998_002420046;
						goto case 13;
					}
					goto IL_086b;
					IL_0483:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToRaidBattleBonus();
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:406", "call命令");
					_0024_0024s540_0024call_00241987_002420033 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241986_002420034 = _0024self__002420056.S540_tutorial_npc(string.Empty, "現在判明している、御使に有効な\n武器や属性をここで確認できるぞ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241986_002420034 != null)
					{
						_0024_0024iterator_002413822_002420051 = _0024_0024s540_0024call_00241986_002420034;
						goto case 9;
					}
					goto IL_054f;
					IL_01ba:
					if (_0024worldRaidMain_002420023.Mode != WorldRaidMain.WORLD_RAID_MODE.Conf)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_01f1;
					IL_01f1:
					if (_0024worldRaidMain_002420023.IsChangingSituation)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto IL_0227;
					IL_0227:
					if (DialogManager.DialogCount != 0 || CutSceneManager.Instance.isBusy)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002420056, active: true);
					BattleHUD.PointTutorialArrowToWeaponSelect();
					BattleHUD.PointTutorialArrowToPoppetSelect();
					BattleHUD.PointTutorialArrowToFriendPoppetSelect();
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:399", "call命令");
					_0024_0024s540_0024call_00241978_002420024 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241977_002420025 = _0024self__002420056.S540_tutorial_npc(string.Empty, "武器や魔ペットを変更したいときは\nそれぞれのアイコンをタップ！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241977_002420025 != null)
					{
						_0024_0024iterator_002413819_002420048 = _0024_0024s540_0024call_00241977_002420025;
						goto case 6;
					}
					goto IL_0306;
					IL_054f:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:407", "call命令");
					_0024_0024s540_0024call_00241990_002420036 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241989_002420037 = _0024self__002420056.S540_tutorial_npc(string.Empty, "御使に有効な武器や属性が不明のときは\nここは「？」となる。御使と戦って探そう！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241989_002420037 != null)
					{
						_0024_0024iterator_002413823_002420052 = _0024_0024s540_0024call_00241989_002420037;
						goto case 10;
					}
					goto IL_0616;
					IL_03cc:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:402", "call命令");
					_0024_0024s540_0024call_00241984_002420030 = _0024self__002420056.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241983_002420031 = _0024self__002420056.S540_message_end();
					if (_0024_0024s540_0024call_00241983_002420031 != null)
					{
						_0024_0024iterator_002413821_002420050 = _0024_0024s540_0024call_00241983_002420031;
						goto case 8;
					}
					goto IL_0483;
					IL_0616:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToRaidNormalAttack();
					BattleHUD.PointTutorialArrowToRaidFullAttack();
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:413", "call命令");
					_0024_0024s540_0024call_00241993_002420039 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241992_002420040 = _0024self__002420056.S540_tutorial_npc(string.Empty, "準備がよければ\n『通常攻撃』か『全力攻撃』でバトル開始！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241992_002420040 != null)
					{
						_0024_0024iterator_002413824_002420053 = _0024_0024s540_0024call_00241992_002420040;
						goto case 11;
					}
					goto IL_06ec;
					IL_0306:
					if (!_0024self__002420056.isExecuting(_0024_0024CUR_EXEC_0024_002420018))
					{
						goto case 1;
					}
					_0024self__002420056.dtrace(_0024_0024CUR_EXEC_0024_002420018, "TutorialEvent.boo:400", "call命令");
					_0024_0024s540_0024call_00241981_002420027 = _0024self__002420056.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420018);
					_0024_0024s540_0024call_00241980_002420028 = _0024self__002420056.S540_tutorial_npc(string.Empty, "魔ペットはシオン界には入れないが\n援護スキルは使えるので上手に活用しよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00241980_002420028 != null)
					{
						_0024_0024iterator_002413820_002420049 = _0024_0024s540_0024call_00241980_002420028;
						goto case 7;
					}
					goto IL_03cc;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420057;

		public _0024S540_tutorial_ui_worldRaid_002420016(TutorialEvent self_)
		{
			_0024self__002420057 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420057);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_myHomeEquip_002420058 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242071_002420059;

			internal object _0024___item_002420060;

			internal IEnumerator _0024_0024iterator_002413827_002420061;

			internal TutorialEvent _0024self__002420062;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420062 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242071_002420059 = _0024self__002420062.S540_tutorial_ui_myHomeEquip(null);
					if (_0024_0024s540_0024ycode_00242071_002420059 != null)
					{
						_0024_0024iterator_002413827_002420061 = _0024_0024s540_0024ycode_00242071_002420059;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413827_002420061.MoveNext())
					{
						_0024___item_002420060 = _0024_0024iterator_002413827_002420061.Current;
						result = (Yield(2, _0024___item_002420060) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420063;

		public _0024S540_tutorial_ui_myHomeEquip_002420058(TutorialEvent self_)
		{
			_0024self__002420063 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420063);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_myHomeEquip_002420064 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420065;

			internal Exec _0024_0024CUR_EXEC_0024_002420066;

			internal UserData _0024ud_002420067;

			internal GameObject _0024go_002420068;

			internal GameObject _0024tutoRoot_002420069;

			internal FaderCore _0024fader_002420070;

			internal MyHomeEquipMain _0024myHomeEquipMain_002420071;

			internal Exec _0024_0024s540_0024call_00242003_002420072;

			internal IEnumerator _0024_0024s540_0024call_00242002_002420073;

			internal object _0024_0024s540_0024call_00242004_002420074;

			internal Exec _0024_0024s540_0024call_00242006_002420075;

			internal IEnumerator _0024_0024s540_0024call_00242005_002420076;

			internal object _0024_0024s540_0024call_00242007_002420077;

			internal Exec _0024_0024s540_0024call_00242009_002420078;

			internal IEnumerator _0024_0024s540_0024call_00242008_002420079;

			internal object _0024_0024s540_0024call_00242010_002420080;

			internal Exec _0024_0024s540_0024call_00242012_002420081;

			internal IEnumerator _0024_0024s540_0024call_00242011_002420082;

			internal object _0024_0024s540_0024call_00242013_002420083;

			internal Exec _0024_0024s540_0024call_00242015_002420084;

			internal IEnumerator _0024_0024s540_0024call_00242014_002420085;

			internal object _0024_0024s540_0024call_00242016_002420086;

			internal Exec _0024_0024s540_0024call_00242018_002420087;

			internal IEnumerator _0024_0024s540_0024call_00242017_002420088;

			internal object _0024_0024s540_0024call_00242019_002420089;

			internal Exec _0024_0024s540_0024call_00242021_002420090;

			internal IEnumerator _0024_0024s540_0024call_00242020_002420091;

			internal object _0024_0024s540_0024call_00242022_002420092;

			internal Exec _0024_0024s540_0024call_00242024_002420093;

			internal IEnumerator _0024_0024s540_0024call_00242023_002420094;

			internal object _0024_0024s540_0024call_00242025_002420095;

			internal Exec _0024_0024s540_0024call_00242027_002420096;

			internal IEnumerator _0024_0024s540_0024call_00242026_002420097;

			internal object _0024_0024s540_0024call_00242028_002420098;

			internal Exec _0024_0024s540_0024call_00242030_002420099;

			internal IEnumerator _0024_0024s540_0024call_00242029_002420100;

			internal object _0024_0024s540_0024call_00242031_002420101;

			internal Exec _0024_0024s540_0024call_00242033_002420102;

			internal IEnumerator _0024_0024s540_0024call_00242032_002420103;

			internal object _0024_0024s540_0024call_00242034_002420104;

			internal Exec _0024_0024s540_0024call_00242036_002420105;

			internal IEnumerator _0024_0024s540_0024call_00242035_002420106;

			internal object _0024_0024s540_0024call_00242037_002420107;

			internal Exec _0024_0024s540_0024call_00242039_002420108;

			internal IEnumerator _0024_0024s540_0024call_00242038_002420109;

			internal object _0024_0024s540_0024call_00242040_002420110;

			internal Exec _0024_0024s540_0024call_00242042_002420111;

			internal IEnumerator _0024_0024s540_0024call_00242041_002420112;

			internal object _0024_0024s540_0024call_00242043_002420113;

			internal Exec _0024_0024s540_0024call_00242045_002420114;

			internal IEnumerator _0024_0024s540_0024call_00242044_002420115;

			internal object _0024_0024s540_0024call_00242046_002420116;

			internal Exec _0024_0024s540_0024call_00242048_002420117;

			internal IEnumerator _0024_0024s540_0024call_00242047_002420118;

			internal object _0024_0024s540_0024call_00242049_002420119;

			internal Exec _0024_0024s540_0024call_00242051_002420120;

			internal IEnumerator _0024_0024s540_0024call_00242050_002420121;

			internal object _0024_0024s540_0024call_00242052_002420122;

			internal Exec _0024_0024s540_0024call_00242054_002420123;

			internal IEnumerator _0024_0024s540_0024call_00242053_002420124;

			internal object _0024_0024s540_0024call_00242055_002420125;

			internal Exec _0024_0024s540_0024call_00242057_002420126;

			internal IEnumerator _0024_0024s540_0024call_00242056_002420127;

			internal object _0024_0024s540_0024call_00242058_002420128;

			internal Exec _0024_0024s540_0024call_00242060_002420129;

			internal IEnumerator _0024_0024s540_0024call_00242059_002420130;

			internal object _0024_0024s540_0024call_00242061_002420131;

			internal Exec _0024_0024s540_0024call_00242063_002420132;

			internal IEnumerator _0024_0024s540_0024call_00242062_002420133;

			internal object _0024_0024s540_0024call_00242064_002420134;

			internal Exec _0024_0024s540_0024call_00242066_002420135;

			internal IEnumerator _0024_0024s540_0024call_00242065_002420136;

			internal object _0024_0024s540_0024call_00242067_002420137;

			internal Exec _0024_0024s540_0024call_00242069_002420138;

			internal IEnumerator _0024_0024s540_0024call_00242068_002420139;

			internal object _0024_0024s540_0024call_00242070_002420140;

			internal IEnumerator _0024_0024iterator_002413828_002420141;

			internal IEnumerator _0024_0024iterator_002413829_002420142;

			internal IEnumerator _0024_0024iterator_002413830_002420143;

			internal IEnumerator _0024_0024iterator_002413831_002420144;

			internal IEnumerator _0024_0024iterator_002413832_002420145;

			internal IEnumerator _0024_0024iterator_002413833_002420146;

			internal IEnumerator _0024_0024iterator_002413834_002420147;

			internal IEnumerator _0024_0024iterator_002413835_002420148;

			internal IEnumerator _0024_0024iterator_002413836_002420149;

			internal IEnumerator _0024_0024iterator_002413837_002420150;

			internal IEnumerator _0024_0024iterator_002413838_002420151;

			internal IEnumerator _0024_0024iterator_002413839_002420152;

			internal IEnumerator _0024_0024iterator_002413840_002420153;

			internal IEnumerator _0024_0024iterator_002413841_002420154;

			internal IEnumerator _0024_0024iterator_002413842_002420155;

			internal IEnumerator _0024_0024iterator_002413843_002420156;

			internal IEnumerator _0024_0024iterator_002413844_002420157;

			internal IEnumerator _0024_0024iterator_002413845_002420158;

			internal IEnumerator _0024_0024iterator_002413846_002420159;

			internal IEnumerator _0024_0024iterator_002413847_002420160;

			internal IEnumerator _0024_0024iterator_002413848_002420161;

			internal IEnumerator _0024_0024iterator_002413849_002420162;

			internal IEnumerator _0024_0024iterator_002413850_002420163;

			internal TutorialEvent _0024self__002420164;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420164 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420065 = "S540_tutorial_ui_myHomeEquip";
					_0024_0024CUR_EXEC_0024_002420066 = _0024self__002420164.lastCreatedExec;
					_0024ud_002420067 = UserData.Current;
					if (_0024ud_002420067 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002420068 = null;
					_0024tutoRoot_002420069 = null;
					if (!_0024ud_002420067.hasFlag("s01BoxTuto"))
					{
						_0024ud_002420067.setFlag("s01BoxTuto");
						_0024fader_002420070 = FaderCore.Instance;
						goto IL_0128;
					}
					goto IL_0953;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_0128;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_01fe;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_0235;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413828_002420141.MoveNext())
					{
						_0024_0024s540_0024call_00242004_002420074 = _0024_0024iterator_002413828_002420141.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242004_002420074) ? 1 : 0);
						break;
					}
					goto IL_02fc;
				case 6:
					if (_0024_0024iterator_002413829_002420142.MoveNext())
					{
						_0024_0024s540_0024call_00242007_002420077 = _0024_0024iterator_002413829_002420142.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242007_002420077) ? 1 : 0);
						break;
					}
					goto IL_03c2;
				case 7:
					if (_0024_0024iterator_002413830_002420143.MoveNext())
					{
						_0024_0024s540_0024call_00242010_002420080 = _0024_0024iterator_002413830_002420143.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242010_002420080) ? 1 : 0);
						break;
					}
					goto IL_0492;
				case 8:
					if (_0024_0024iterator_002413831_002420144.MoveNext())
					{
						_0024_0024s540_0024call_00242013_002420083 = _0024_0024iterator_002413831_002420144.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242013_002420083) ? 1 : 0);
						break;
					}
					goto IL_0549;
				case 9:
					if (_0024_0024iterator_002413832_002420145.MoveNext())
					{
						_0024_0024s540_0024call_00242016_002420086 = _0024_0024iterator_002413832_002420145.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242016_002420086) ? 1 : 0);
						break;
					}
					goto IL_0615;
				case 10:
					if (_0024_0024iterator_002413833_002420146.MoveNext())
					{
						_0024_0024s540_0024call_00242019_002420089 = _0024_0024iterator_002413833_002420146.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242019_002420089) ? 1 : 0);
						break;
					}
					goto IL_06dc;
				case 11:
					if (_0024_0024iterator_002413834_002420147.MoveNext())
					{
						_0024_0024s540_0024call_00242022_002420092 = _0024_0024iterator_002413834_002420147.Current;
						result = (Yield(11, _0024_0024s540_0024call_00242022_002420092) ? 1 : 0);
						break;
					}
					goto IL_07ad;
				case 12:
					if (_0024_0024iterator_002413835_002420148.MoveNext())
					{
						_0024_0024s540_0024call_00242025_002420095 = _0024_0024iterator_002413835_002420148.Current;
						result = (Yield(12, _0024_0024s540_0024call_00242025_002420095) ? 1 : 0);
						break;
					}
					goto IL_0874;
				case 13:
					if (_0024_0024iterator_002413836_002420149.MoveNext())
					{
						_0024_0024s540_0024call_00242028_002420098 = _0024_0024iterator_002413836_002420149.Current;
						result = (Yield(13, _0024_0024s540_0024call_00242028_002420098) ? 1 : 0);
						break;
					}
					goto IL_092c;
				case 14:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_09aa;
					}
					goto case 1;
				case 15:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_0a81;
					}
					goto case 1;
				case 16:
					if (!_0024_0024CUR_EXEC_0024_002420066.NotExecuting)
					{
						goto IL_0ab9;
					}
					goto case 1;
				case 17:
					if (_0024_0024iterator_002413837_002420150.MoveNext())
					{
						_0024_0024s540_0024call_00242031_002420101 = _0024_0024iterator_002413837_002420150.Current;
						result = (Yield(17, _0024_0024s540_0024call_00242031_002420101) ? 1 : 0);
						break;
					}
					goto IL_0b81;
				case 18:
					if (_0024_0024iterator_002413838_002420151.MoveNext())
					{
						_0024_0024s540_0024call_00242034_002420104 = _0024_0024iterator_002413838_002420151.Current;
						result = (Yield(18, _0024_0024s540_0024call_00242034_002420104) ? 1 : 0);
						break;
					}
					goto IL_0c52;
				case 19:
					if (_0024_0024iterator_002413839_002420152.MoveNext())
					{
						_0024_0024s540_0024call_00242037_002420107 = _0024_0024iterator_002413839_002420152.Current;
						result = (Yield(19, _0024_0024s540_0024call_00242037_002420107) ? 1 : 0);
						break;
					}
					goto IL_0d28;
				case 20:
					if (_0024_0024iterator_002413840_002420153.MoveNext())
					{
						_0024_0024s540_0024call_00242040_002420110 = _0024_0024iterator_002413840_002420153.Current;
						result = (Yield(20, _0024_0024s540_0024call_00242040_002420110) ? 1 : 0);
						break;
					}
					goto IL_0dfe;
				case 21:
					if (_0024_0024iterator_002413841_002420154.MoveNext())
					{
						_0024_0024s540_0024call_00242043_002420113 = _0024_0024iterator_002413841_002420154.Current;
						result = (Yield(21, _0024_0024s540_0024call_00242043_002420113) ? 1 : 0);
						break;
					}
					goto IL_0ec5;
				case 22:
					if (_0024_0024iterator_002413842_002420155.MoveNext())
					{
						_0024_0024s540_0024call_00242046_002420116 = _0024_0024iterator_002413842_002420155.Current;
						result = (Yield(22, _0024_0024s540_0024call_00242046_002420116) ? 1 : 0);
						break;
					}
					goto IL_0f7d;
				case 23:
					if (_0024_0024iterator_002413843_002420156.MoveNext())
					{
						_0024_0024s540_0024call_00242049_002420119 = _0024_0024iterator_002413843_002420156.Current;
						result = (Yield(23, _0024_0024s540_0024call_00242049_002420119) ? 1 : 0);
						break;
					}
					goto IL_1049;
				case 24:
					if (_0024_0024iterator_002413844_002420157.MoveNext())
					{
						_0024_0024s540_0024call_00242052_002420122 = _0024_0024iterator_002413844_002420157.Current;
						result = (Yield(24, _0024_0024s540_0024call_00242052_002420122) ? 1 : 0);
						break;
					}
					goto IL_1110;
				case 25:
					if (_0024_0024iterator_002413845_002420158.MoveNext())
					{
						_0024_0024s540_0024call_00242055_002420125 = _0024_0024iterator_002413845_002420158.Current;
						result = (Yield(25, _0024_0024s540_0024call_00242055_002420125) ? 1 : 0);
						break;
					}
					goto IL_11e6;
				case 26:
					if (_0024_0024iterator_002413846_002420159.MoveNext())
					{
						_0024_0024s540_0024call_00242058_002420128 = _0024_0024iterator_002413846_002420159.Current;
						result = (Yield(26, _0024_0024s540_0024call_00242058_002420128) ? 1 : 0);
						break;
					}
					goto IL_129e;
				case 27:
					if (_0024_0024iterator_002413847_002420160.MoveNext())
					{
						_0024_0024s540_0024call_00242061_002420131 = _0024_0024iterator_002413847_002420160.Current;
						result = (Yield(27, _0024_0024s540_0024call_00242061_002420131) ? 1 : 0);
						break;
					}
					goto IL_1374;
				case 28:
					if (_0024_0024iterator_002413848_002420161.MoveNext())
					{
						_0024_0024s540_0024call_00242064_002420134 = _0024_0024iterator_002413848_002420161.Current;
						result = (Yield(28, _0024_0024s540_0024call_00242064_002420134) ? 1 : 0);
						break;
					}
					goto IL_142c;
				case 29:
					if (_0024_0024iterator_002413849_002420162.MoveNext())
					{
						_0024_0024s540_0024call_00242067_002420137 = _0024_0024iterator_002413849_002420162.Current;
						result = (Yield(29, _0024_0024s540_0024call_00242067_002420137) ? 1 : 0);
						break;
					}
					goto IL_14f8;
				case 30:
					if (_0024_0024iterator_002413850_002420163.MoveNext())
					{
						_0024_0024s540_0024call_00242070_002420140 = _0024_0024iterator_002413850_002420163.Current;
						result = (Yield(30, _0024_0024s540_0024call_00242070_002420140) ? 1 : 0);
						break;
					}
					goto IL_15b0;
				case 1:
					{
						result = 0;
						break;
					}
					IL_11e6:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:505", "call命令");
					_0024_0024s540_0024call_00242057_002420126 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242056_002420127 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242056_002420127 != null)
					{
						_0024_0024iterator_002413846_002420159 = _0024_0024s540_0024call_00242056_002420127;
						goto case 26;
					}
					goto IL_129e;
					IL_0dfe:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:492", "call命令");
					_0024_0024s540_0024call_00242042_002420111 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242041_002420112 = _0024self__002420164.S540_tutorial_npc(string.Empty, "画面中央にいるのがメイン魔ペット。\nリング外側にいるのがサポート魔ペットだ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242041_002420112 != null)
					{
						_0024_0024iterator_002413841_002420154 = _0024_0024s540_0024call_00242041_002420112;
						goto case 21;
					}
					goto IL_0ec5;
					IL_0128:
					if (!_0024fader_002420070 || !_0024fader_002420070.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024myHomeEquipMain_002420071 = (MyHomeEquipMain)UnityEngine.Object.FindObjectOfType(typeof(MyHomeEquipMain));
					if (!_0024myHomeEquipMain_002420071)
					{
						throw new AssertionFailedException("myHomeEquipMain");
					}
					if (!_0024go_002420068)
					{
						_0024go_002420068 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Box") as GameObject;
					}
					if (!_0024tutoRoot_002420069 && (bool)_0024go_002420068)
					{
						_0024tutoRoot_002420069 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420068);
					}
					goto IL_01fe;
					IL_15b0:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420164, active: false);
					goto IL_15d7;
					IL_129e:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxSupportWeaponDemonMain();
					BattleHUD.PointTutorialArrowToBoxSupportPoppetMain();
					BattleHUD.PointTutorialArrowToBoxSupportPoppetSub();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:510", "call命令");
					_0024_0024s540_0024call_00242060_002420129 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242059_002420130 = _0024self__002420164.S540_tutorial_npc(string.Empty, "さらに、メイン武器と魔ペットの属性が\n同じでもＡＴＫとＨＰがアップする！！", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242059_002420130 != null)
					{
						_0024_0024iterator_002413847_002420160 = _0024_0024s540_0024call_00242059_002420130;
						goto case 27;
					}
					goto IL_1374;
					IL_0ec5:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:494", "call命令");
					_0024_0024s540_0024call_00242045_002420114 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242044_002420115 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242044_002420115 != null)
					{
						_0024_0024iterator_002413842_002420155 = _0024_0024s540_0024call_00242044_002420115;
						goto case 22;
					}
					goto IL_0f7d;
					IL_092c:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420164, active: false);
					goto IL_0953;
					IL_0953:
					if (!_0024ud_002420067.hasFlag("s01BoxCustomizeTuto"))
					{
						_0024ud_002420067.setFlag("s01BoxCustomizeTuto");
						_0024fader_002420070 = FaderCore.Instance;
						goto IL_09aa;
					}
					goto IL_15d7;
					IL_09aa:
					if (!_0024fader_002420070 || !_0024fader_002420070.isOutCompleted)
					{
						result = (YieldDefault(14) ? 1 : 0);
						break;
					}
					_0024myHomeEquipMain_002420071 = (MyHomeEquipMain)UnityEngine.Object.FindObjectOfType(typeof(MyHomeEquipMain));
					if (!_0024myHomeEquipMain_002420071)
					{
						throw new AssertionFailedException("myHomeEquipMain");
					}
					if (!_0024go_002420068)
					{
						_0024go_002420068 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Box") as GameObject;
					}
					if (!_0024tutoRoot_002420069 && (bool)_0024go_002420068)
					{
						_0024tutoRoot_002420069 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420068);
					}
					goto IL_0a81;
					IL_01fe:
					if (_0024myHomeEquipMain_002420071.Mode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0235;
					IL_0235:
					if (_0024myHomeEquipMain_002420071.IsChangingSituation)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002420164, active: true);
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:441", "call命令");
					_0024_0024s540_0024call_00242003_002420072 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242002_002420073 = _0024self__002420164.S540_tutorial_npc(string.Empty, "ここでは、プレイヤーのメイン武器と\nメイン魔ペットが確認できる。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242002_002420073 != null)
					{
						_0024_0024iterator_002413828_002420141 = _0024_0024s540_0024call_00242002_002420073;
						goto case 5;
					}
					goto IL_02fc;
					IL_02fc:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:442", "call命令");
					_0024_0024s540_0024call_00242006_002420075 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242005_002420076 = _0024self__002420164.S540_tutorial_npc(string.Empty, "メイン武器は\n天使用と悪魔用が存在するぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242005_002420076 != null)
					{
						_0024_0024iterator_002413829_002420142 = _0024_0024s540_0024call_00242005_002420076;
						goto case 6;
					}
					goto IL_03c2;
					IL_0f7d:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxSupportAtkHp();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:497", "call命令");
					_0024_0024s540_0024call_00242048_002420117 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242047_002420118 = _0024self__002420164.S540_tutorial_npc(string.Empty, "プレイヤーのＡＴＫとＨＰは\nメイン武器がベースになる。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242047_002420118 != null)
					{
						_0024_0024iterator_002413843_002420156 = _0024_0024s540_0024call_00242047_002420118;
						goto case 23;
					}
					goto IL_1049;
					IL_14f8:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:517", "call命令");
					_0024_0024s540_0024call_00242069_002420138 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242068_002420139 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242068_002420139 != null)
					{
						_0024_0024iterator_002413850_002420163 = _0024_0024s540_0024call_00242068_002420139;
						goto case 30;
					}
					goto IL_15b0;
					IL_0a81:
					if (_0024myHomeEquipMain_002420071.Mode != MyHomeEquipMain.MY_HOME_EQUIP_MAIN.Support)
					{
						result = (YieldDefault(15) ? 1 : 0);
						break;
					}
					goto IL_0ab9;
					IL_03c2:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxWeapon();
					BattleHUD.PointTutorialArrowToBoxPoppet();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:445", "call命令");
					_0024_0024s540_0024call_00242009_002420078 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242008_002420079 = _0024self__002420164.S540_tutorial_npc(string.Empty, "メイン武器や魔ペットを変更したいときは\nそれぞれのアイコンをタップしよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242008_002420079 != null)
					{
						_0024_0024iterator_002413830_002420143 = _0024_0024s540_0024call_00242008_002420079;
						goto case 7;
					}
					goto IL_0492;
					IL_0ab9:
					if (_0024myHomeEquipMain_002420071.IsChangingSituation)
					{
						result = (YieldDefault(16) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002420164, active: true);
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:477", "call命令");
					_0024_0024s540_0024call_00242030_002420099 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242029_002420100 = _0024self__002420164.S540_tutorial_npc(string.Empty, "ここでは\n自分で装備のカスタマイズができる。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242029_002420100 != null)
					{
						_0024_0024iterator_002413837_002420150 = _0024_0024s540_0024call_00242029_002420100;
						goto case 17;
					}
					goto IL_0b81;
					IL_1049:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:498", "call命令");
					_0024_0024s540_0024call_00242051_002420120 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242050_002420121 = _0024self__002420164.S540_tutorial_npc(string.Empty, "そこからサポート武器や魔ペットによって\n最終的なＡＴＫとＨＰが決定するぞ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242050_002420121 != null)
					{
						_0024_0024iterator_002413844_002420157 = _0024_0024s540_0024call_00242050_002420121;
						goto case 24;
					}
					goto IL_1110;
					IL_0492:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:447", "call命令");
					_0024_0024s540_0024call_00242012_002420081 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242011_002420082 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242011_002420082 != null)
					{
						_0024_0024iterator_002413831_002420144 = _0024_0024s540_0024call_00242011_002420082;
						goto case 8;
					}
					goto IL_0549;
					IL_1374:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:512", "call命令");
					_0024_0024s540_0024call_00242063_002420132 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242062_002420133 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242062_002420133 != null)
					{
						_0024_0024iterator_002413848_002420161 = _0024_0024s540_0024call_00242062_002420133;
						goto case 28;
					}
					goto IL_142c;
					IL_0b81:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxSupportWeaponAngelMain();
					BattleHUD.PointTutorialArrowToBoxSupportWeaponDemonMain();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:481", "call命令");
					_0024_0024s540_0024call_00242033_002420102 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242032_002420103 = _0024self__002420164.S540_tutorial_npc(string.Empty, "左側のリングが天使用装備。\n右側のリングが悪魔用装備だ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242032_002420103 != null)
					{
						_0024_0024iterator_002413838_002420151 = _0024_0024s540_0024call_00242032_002420103;
						goto case 18;
					}
					goto IL_0c52;
					IL_0549:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxSupport();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:450", "call命令");
					_0024_0024s540_0024call_00242015_002420084 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242014_002420085 = _0024self__002420164.S540_tutorial_npc(string.Empty, "また、右下のカスタマイズボタンで\n目的に合った装備に自動変更ができる。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242014_002420085 != null)
					{
						_0024_0024iterator_002413832_002420145 = _0024_0024s540_0024call_00242014_002420085;
						goto case 9;
					}
					goto IL_0615;
					IL_0615:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:451", "call命令");
					_0024_0024s540_0024call_00242018_002420087 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242017_002420088 = _0024self__002420164.S540_tutorial_npc(string.Empty, "自分で装備をカスタマイズしたいときは\n「カスタム」を選択しよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242017_002420088 != null)
					{
						_0024_0024iterator_002413833_002420146 = _0024_0024s540_0024call_00242017_002420088;
						goto case 10;
					}
					goto IL_06dc;
					IL_0c52:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToBoxSupportWeaponAngelMain();
					BattleHUD.PointTutorialArrowToBoxSupportWeaponSub();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:486", "call命令");
					_0024_0024s540_0024call_00242036_002420105 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242035_002420106 = _0024self__002420164.S540_tutorial_npc(string.Empty, "リングの真ん中にある武器がメイン武器。\n外側にあるのがサポート武器だ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242035_002420106 != null)
					{
						_0024_0024iterator_002413839_002420152 = _0024_0024s540_0024call_00242035_002420106;
						goto case 19;
					}
					goto IL_0d28;
					IL_1110:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToBoxSupportWeaponAngelMain();
					BattleHUD.PointTutorialArrowToBoxSupportWeaponSub();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:503", "call命令");
					_0024_0024s540_0024call_00242054_002420123 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242053_002420124 = _0024self__002420164.S540_tutorial_npc(string.Empty, "メイン武器とサポート武器の属性や種類が\n同じならＡＴＫとＨＰがアップ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242053_002420124 != null)
					{
						_0024_0024iterator_002413845_002420158 = _0024_0024s540_0024call_00242053_002420124;
						goto case 25;
					}
					goto IL_11e6;
					IL_06dc:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToBoxDeck();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:455", "call命令");
					_0024_0024s540_0024call_00242021_002420090 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242020_002420091 = _0024self__002420164.S540_tutorial_npc(string.Empty, "さらに、デッキの切り替えも\nここでおこなうことができるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242020_002420091 != null)
					{
						_0024_0024iterator_002413834_002420147 = _0024_0024s540_0024call_00242020_002420091;
						goto case 11;
					}
					goto IL_07ad;
					IL_15d7:
					_0024self__002420164.stop(_0024_0024CUR_EXEC_0024_002420066);
					goto case 1;
					IL_07ad:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:456", "call命令");
					_0024_0024s540_0024call_00242024_002420093 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242023_002420094 = _0024self__002420164.S540_tutorial_npc(string.Empty, "ステータス部分をスワイプするか\n左下のデッキボタンを押して切り替えよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242023_002420094 != null)
					{
						_0024_0024iterator_002413835_002420148 = _0024_0024s540_0024call_00242023_002420094;
						goto case 12;
					}
					goto IL_0874;
					IL_0d28:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToBoxSupportPoppetMain();
					BattleHUD.PointTutorialArrowToBoxSupportPoppetSub();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:491", "call命令");
					_0024_0024s540_0024call_00242039_002420108 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242038_002420109 = _0024self__002420164.S540_tutorial_npc(string.Empty, "さらに、魔ペットにもメイン魔ペットと\nサポート魔ペットが存在するぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242038_002420109 != null)
					{
						_0024_0024iterator_002413840_002420153 = _0024_0024s540_0024call_00242038_002420109;
						goto case 20;
					}
					goto IL_0dfe;
					IL_142c:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToBoxDeck();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:515", "call命令");
					_0024_0024s540_0024call_00242066_002420135 = _0024self__002420164.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242065_002420136 = _0024self__002420164.S540_tutorial_npc(string.Empty, "なお、ここでもデッキの切り替えが可能だ。\n左下のデッキボタンを押して切り替えよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242065_002420136 != null)
					{
						_0024_0024iterator_002413849_002420162 = _0024_0024s540_0024call_00242065_002420136;
						goto case 29;
					}
					goto IL_14f8;
					IL_0874:
					if (!_0024self__002420164.isExecuting(_0024_0024CUR_EXEC_0024_002420066))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420164.dtrace(_0024_0024CUR_EXEC_0024_002420066, "TutorialEvent.boo:458", "call命令");
					_0024_0024s540_0024call_00242027_002420096 = _0024self__002420164.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420066);
					_0024_0024s540_0024call_00242026_002420097 = _0024self__002420164.S540_message_end();
					if (_0024_0024s540_0024call_00242026_002420097 != null)
					{
						_0024_0024iterator_002413836_002420149 = _0024_0024s540_0024call_00242026_002420097;
						goto case 13;
					}
					goto IL_092c;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420165;

		public _0024S540_tutorial_ui_myHomeEquip_002420064(TutorialEvent self_)
		{
			_0024self__002420165 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420165);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_boxCustomize_002420166 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242072_002420167;

			internal object _0024___item_002420168;

			internal IEnumerator _0024_0024iterator_002413851_002420169;

			internal TutorialEvent _0024self__002420170;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420170 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242072_002420167 = _0024self__002420170.S540_tutorial_ui_boxCustomize(null);
					if (_0024_0024s540_0024ycode_00242072_002420167 != null)
					{
						_0024_0024iterator_002413851_002420169 = _0024_0024s540_0024ycode_00242072_002420167;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413851_002420169.MoveNext())
					{
						_0024___item_002420168 = _0024_0024iterator_002413851_002420169.Current;
						result = (Yield(2, _0024___item_002420168) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420171;

		public _0024S540_tutorial_ui_boxCustomize_002420166(TutorialEvent self_)
		{
			_0024self__002420171 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420171);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_boxCustomize_002420172 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420173;

			internal Exec _0024_0024CUR_EXEC_0024_002420174;

			internal UserData _0024ud_002420175;

			internal GameObject _0024go_002420176;

			internal GameObject _0024tutoRoot_002420177;

			internal FaderCore _0024fader_002420178;

			internal TutorialEvent _0024self__002420179;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420179 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420173 = "S540_tutorial_ui_boxCustomize";
					_0024_0024CUR_EXEC_0024_002420174 = _0024self__002420179.lastCreatedExec;
					_0024ud_002420175 = UserData.Current;
					if (_0024ud_002420175 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002420176 = null;
					_0024tutoRoot_002420177 = null;
					if (!_0024ud_002420175.hasFlag("s01BoxCustomizeTuto"))
					{
						_0024ud_002420175.setFlag("s01BoxCustomizeTuto");
						_0024fader_002420178 = FaderCore.Instance;
						goto IL_00b8;
					}
					goto IL_0133;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420174.NotExecuting)
					{
						goto IL_00b8;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b8:
					if (!_0024fader_002420178 || !_0024fader_002420178.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024go_002420176)
					{
						_0024go_002420176 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Box") as GameObject;
					}
					if (!_0024tutoRoot_002420177 && (bool)_0024go_002420176)
					{
						_0024tutoRoot_002420177 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420176);
					}
					goto IL_0133;
					IL_0133:
					_0024self__002420179.stop(_0024_0024CUR_EXEC_0024_002420174);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420180;

		public _0024S540_tutorial_ui_boxCustomize_002420172(TutorialEvent self_)
		{
			_0024self__002420180 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420180);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_boxList_002420181 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242073_002420182;

			internal object _0024___item_002420183;

			internal IEnumerator _0024_0024iterator_002413852_002420184;

			internal TutorialEvent _0024self__002420185;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420185 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242073_002420182 = _0024self__002420185.S540_tutorial_ui_boxList(null);
					if (_0024_0024s540_0024ycode_00242073_002420182 != null)
					{
						_0024_0024iterator_002413852_002420184 = _0024_0024s540_0024ycode_00242073_002420182;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413852_002420184.MoveNext())
					{
						_0024___item_002420183 = _0024_0024iterator_002413852_002420184.Current;
						result = (Yield(2, _0024___item_002420183) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420186;

		public _0024S540_tutorial_ui_boxList_002420181(TutorialEvent self_)
		{
			_0024self__002420186 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420186);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_boxList_002420187 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420188;

			internal Exec _0024_0024CUR_EXEC_0024_002420189;

			internal UserData _0024ud_002420190;

			internal GameObject _0024go_002420191;

			internal GameObject _0024tutoRoot_002420192;

			internal FaderCore _0024fader_002420193;

			internal TutorialEvent _0024self__002420194;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420194 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420188 = "S540_tutorial_ui_boxList";
					_0024_0024CUR_EXEC_0024_002420189 = _0024self__002420194.lastCreatedExec;
					_0024ud_002420190 = UserData.Current;
					if (_0024ud_002420190 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002420191 = null;
					_0024tutoRoot_002420192 = null;
					if (!_0024ud_002420190.hasFlag("s01BoxListTuto"))
					{
						_0024ud_002420190.setFlag("s01BoxListTuto");
						_0024fader_002420193 = FaderCore.Instance;
						goto IL_00b8;
					}
					goto IL_0133;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420189.NotExecuting)
					{
						goto IL_00b8;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b8:
					if (!_0024fader_002420193 || !_0024fader_002420193.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024go_002420191)
					{
						_0024go_002420191 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Box") as GameObject;
					}
					if (!_0024tutoRoot_002420192 && (bool)_0024go_002420191)
					{
						_0024tutoRoot_002420192 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420191);
					}
					goto IL_0133;
					IL_0133:
					_0024self__002420194.stop(_0024_0024CUR_EXEC_0024_002420189);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420195;

		public _0024S540_tutorial_ui_boxList_002420187(TutorialEvent self_)
		{
			_0024self__002420195 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420195);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_worldQuest_002420196 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242122_002420197;

			internal object _0024___item_002420198;

			internal IEnumerator _0024_0024iterator_002413853_002420199;

			internal TutorialEvent _0024self__002420200;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420200 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242122_002420197 = _0024self__002420200.S540_tutorial_ui_worldQuest(null);
					if (_0024_0024s540_0024ycode_00242122_002420197 != null)
					{
						_0024_0024iterator_002413853_002420199 = _0024_0024s540_0024ycode_00242122_002420197;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413853_002420199.MoveNext())
					{
						_0024___item_002420198 = _0024_0024iterator_002413853_002420199.Current;
						result = (Yield(2, _0024___item_002420198) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420201;

		public _0024S540_tutorial_ui_worldQuest_002420196(TutorialEvent self_)
		{
			_0024self__002420201 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420201);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_ui_worldQuest_002420202 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420203;

			internal Exec _0024_0024CUR_EXEC_0024_002420204;

			internal UserData _0024ud_002420205;

			internal GameObject _0024go_002420206;

			internal GameObject _0024tutoRoot_002420207;

			internal bool _0024flagID1_002420208;

			internal FaderCore _0024fader_002420209;

			internal WorldQuestMain _0024worldQuestMain_002420210;

			internal Exec _0024_0024s540_0024call_00242075_002420211;

			internal IEnumerator _0024_0024s540_0024call_00242074_002420212;

			internal object _0024_0024s540_0024call_00242076_002420213;

			internal Exec _0024_0024s540_0024call_00242078_002420214;

			internal IEnumerator _0024_0024s540_0024call_00242077_002420215;

			internal object _0024_0024s540_0024call_00242079_002420216;

			internal Exec _0024_0024s540_0024call_00242081_002420217;

			internal IEnumerator _0024_0024s540_0024call_00242080_002420218;

			internal object _0024_0024s540_0024call_00242082_002420219;

			internal Exec _0024_0024s540_0024call_00242084_002420220;

			internal IEnumerator _0024_0024s540_0024call_00242083_002420221;

			internal object _0024_0024s540_0024call_00242085_002420222;

			internal Exec _0024_0024s540_0024call_00242087_002420223;

			internal IEnumerator _0024_0024s540_0024call_00242086_002420224;

			internal object _0024_0024s540_0024call_00242088_002420225;

			internal Exec _0024_0024s540_0024call_00242090_002420226;

			internal IEnumerator _0024_0024s540_0024call_00242089_002420227;

			internal object _0024_0024s540_0024call_00242091_002420228;

			internal bool _0024flagID2_002420229;

			internal Exec _0024_0024s540_0024call_00242093_002420230;

			internal IEnumerator _0024_0024s540_0024call_00242092_002420231;

			internal object _0024_0024s540_0024call_00242094_002420232;

			internal Exec _0024_0024s540_0024call_00242096_002420233;

			internal IEnumerator _0024_0024s540_0024call_00242095_002420234;

			internal object _0024_0024s540_0024call_00242097_002420235;

			internal bool _0024flagID3_002420236;

			internal Exec _0024_0024s540_0024call_00242099_002420237;

			internal IEnumerator _0024_0024s540_0024call_00242098_002420238;

			internal object _0024_0024s540_0024call_00242100_002420239;

			internal Exec _0024_0024s540_0024call_00242102_002420240;

			internal IEnumerator _0024_0024s540_0024call_00242101_002420241;

			internal object _0024_0024s540_0024call_00242103_002420242;

			internal Exec _0024_0024s540_0024call_00242105_002420243;

			internal IEnumerator _0024_0024s540_0024call_00242104_002420244;

			internal object _0024_0024s540_0024call_00242106_002420245;

			internal Exec _0024_0024s540_0024call_00242108_002420246;

			internal IEnumerator _0024_0024s540_0024call_00242107_002420247;

			internal object _0024_0024s540_0024call_00242109_002420248;

			internal Exec _0024_0024s540_0024call_00242111_002420249;

			internal IEnumerator _0024_0024s540_0024call_00242110_002420250;

			internal object _0024_0024s540_0024call_00242112_002420251;

			internal Exec _0024_0024s540_0024call_00242114_002420252;

			internal IEnumerator _0024_0024s540_0024call_00242113_002420253;

			internal object _0024_0024s540_0024call_00242115_002420254;

			internal Exec _0024_0024s540_0024call_00242117_002420255;

			internal IEnumerator _0024_0024s540_0024call_00242116_002420256;

			internal object _0024_0024s540_0024call_00242118_002420257;

			internal Exec _0024_0024s540_0024call_00242120_002420258;

			internal IEnumerator _0024_0024s540_0024call_00242119_002420259;

			internal object _0024_0024s540_0024call_00242121_002420260;

			internal IEnumerator _0024_0024iterator_002413854_002420261;

			internal IEnumerator _0024_0024iterator_002413855_002420262;

			internal IEnumerator _0024_0024iterator_002413856_002420263;

			internal IEnumerator _0024_0024iterator_002413857_002420264;

			internal IEnumerator _0024_0024iterator_002413858_002420265;

			internal IEnumerator _0024_0024iterator_002413859_002420266;

			internal IEnumerator _0024_0024iterator_002413860_002420267;

			internal IEnumerator _0024_0024iterator_002413861_002420268;

			internal IEnumerator _0024_0024iterator_002413862_002420269;

			internal IEnumerator _0024_0024iterator_002413863_002420270;

			internal IEnumerator _0024_0024iterator_002413864_002420271;

			internal IEnumerator _0024_0024iterator_002413865_002420272;

			internal IEnumerator _0024_0024iterator_002413866_002420273;

			internal IEnumerator _0024_0024iterator_002413867_002420274;

			internal IEnumerator _0024_0024iterator_002413868_002420275;

			internal IEnumerator _0024_0024iterator_002413869_002420276;

			internal TutorialEvent _0024self__002420277;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420277 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420203 = "S540_tutorial_ui_worldQuest";
					_0024_0024CUR_EXEC_0024_002420204 = _0024self__002420277.lastCreatedExec;
					_0024ud_002420205 = UserData.Current;
					if (_0024ud_002420205 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024go_002420206 = null;
					_0024tutoRoot_002420207 = null;
					_0024flagID1_002420208 = _0024ud_002420205.hasFlag("s01QuestMenuListTuto");
					if (!_0024flagID1_002420208)
					{
						_0024ud_002420205.setFlag("s01QuestMenuListTuto");
						_0024flagID1_002420208 = true;
						_0024fader_002420209 = FaderCore.Instance;
						goto IL_012b;
					}
					goto IL_0706;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_012b;
					}
					goto case 1;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_0206;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_023d;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413854_002420261.MoveNext())
					{
						_0024_0024s540_0024call_00242076_002420213 = _0024_0024iterator_002413854_002420261.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242076_002420213) ? 1 : 0);
						break;
					}
					goto IL_0309;
				case 6:
					if (_0024_0024iterator_002413855_002420262.MoveNext())
					{
						_0024_0024s540_0024call_00242079_002420216 = _0024_0024iterator_002413855_002420262.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242079_002420216) ? 1 : 0);
						break;
					}
					goto IL_03cf;
				case 7:
					if (_0024_0024iterator_002413856_002420263.MoveNext())
					{
						_0024_0024s540_0024call_00242082_002420219 = _0024_0024iterator_002413856_002420263.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242082_002420219) ? 1 : 0);
						break;
					}
					goto IL_0486;
				case 8:
					if (_0024_0024iterator_002413857_002420264.MoveNext())
					{
						_0024_0024s540_0024call_00242085_002420222 = _0024_0024iterator_002413857_002420264.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242085_002420222) ? 1 : 0);
						break;
					}
					goto IL_0556;
				case 9:
					if (_0024_0024iterator_002413858_002420265.MoveNext())
					{
						_0024_0024s540_0024call_00242088_002420225 = _0024_0024iterator_002413858_002420265.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242088_002420225) ? 1 : 0);
						break;
					}
					goto IL_0627;
				case 10:
					if (_0024_0024iterator_002413859_002420266.MoveNext())
					{
						_0024_0024s540_0024call_00242091_002420228 = _0024_0024iterator_002413859_002420266.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242091_002420228) ? 1 : 0);
						break;
					}
					goto IL_06df;
				case 11:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_077c;
					}
					goto case 1;
				case 12:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_0853;
					}
					goto case 1;
				case 13:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_088b;
					}
					goto case 1;
				case 14:
					if (_0024_0024iterator_002413860_002420267.MoveNext())
					{
						_0024_0024s540_0024call_00242094_002420232 = _0024_0024iterator_002413860_002420267.Current;
						result = (Yield(14, _0024_0024s540_0024call_00242094_002420232) ? 1 : 0);
						break;
					}
					goto IL_0953;
				case 15:
					if (_0024_0024iterator_002413861_002420268.MoveNext())
					{
						_0024_0024s540_0024call_00242097_002420235 = _0024_0024iterator_002413861_002420268.Current;
						result = (Yield(15, _0024_0024s540_0024call_00242097_002420235) ? 1 : 0);
						break;
					}
					goto IL_0a06;
				case 16:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_0aaf;
					}
					goto case 1;
				case 17:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_0b86;
					}
					goto case 1;
				case 18:
					if (!_0024_0024CUR_EXEC_0024_002420204.NotExecuting)
					{
						goto IL_0bbe;
					}
					goto case 1;
				case 19:
					if (_0024_0024iterator_002413862_002420269.MoveNext())
					{
						_0024_0024s540_0024call_00242100_002420239 = _0024_0024iterator_002413862_002420269.Current;
						result = (Yield(19, _0024_0024s540_0024call_00242100_002420239) ? 1 : 0);
						break;
					}
					goto IL_0c95;
				case 20:
					if (_0024_0024iterator_002413863_002420270.MoveNext())
					{
						_0024_0024s540_0024call_00242103_002420242 = _0024_0024iterator_002413863_002420270.Current;
						result = (Yield(20, _0024_0024s540_0024call_00242103_002420242) ? 1 : 0);
						break;
					}
					goto IL_0d66;
				case 21:
					if (_0024_0024iterator_002413864_002420271.MoveNext())
					{
						_0024_0024s540_0024call_00242106_002420245 = _0024_0024iterator_002413864_002420271.Current;
						result = (Yield(21, _0024_0024s540_0024call_00242106_002420245) ? 1 : 0);
						break;
					}
					goto IL_0e2d;
				case 22:
					if (_0024_0024iterator_002413865_002420272.MoveNext())
					{
						_0024_0024s540_0024call_00242109_002420248 = _0024_0024iterator_002413865_002420272.Current;
						result = (Yield(22, _0024_0024s540_0024call_00242109_002420248) ? 1 : 0);
						break;
					}
					goto IL_0efe;
				case 23:
					if (_0024_0024iterator_002413866_002420273.MoveNext())
					{
						_0024_0024s540_0024call_00242112_002420251 = _0024_0024iterator_002413866_002420273.Current;
						result = (Yield(23, _0024_0024s540_0024call_00242112_002420251) ? 1 : 0);
						break;
					}
					goto IL_0fc5;
				case 24:
					if (_0024_0024iterator_002413867_002420274.MoveNext())
					{
						_0024_0024s540_0024call_00242115_002420254 = _0024_0024iterator_002413867_002420274.Current;
						result = (Yield(24, _0024_0024s540_0024call_00242115_002420254) ? 1 : 0);
						break;
					}
					goto IL_107d;
				case 25:
					if (_0024_0024iterator_002413868_002420275.MoveNext())
					{
						_0024_0024s540_0024call_00242118_002420257 = _0024_0024iterator_002413868_002420275.Current;
						result = (Yield(25, _0024_0024s540_0024call_00242118_002420257) ? 1 : 0);
						break;
					}
					goto IL_1149;
				case 26:
					if (_0024_0024iterator_002413869_002420276.MoveNext())
					{
						_0024_0024s540_0024call_00242121_002420260 = _0024_0024iterator_002413869_002420276.Current;
						result = (Yield(26, _0024_0024s540_0024call_00242121_002420260) ? 1 : 0);
						break;
					}
					goto IL_1201;
				case 1:
					{
						result = 0;
						break;
					}
					IL_1201:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420277, active: false);
					goto IL_1228;
					IL_0706:
					_0024flagID2_002420229 = _0024ud_002420205.hasFlag("s01QuestMenuPetTuto");
					if (!_0024flagID2_002420229 && _0024flagID1_002420208)
					{
						_0024ud_002420205.setFlag("s01QuestMenuPetTuto");
						_0024flagID2_002420229 = true;
						_0024fader_002420209 = FaderCore.Instance;
						goto IL_077c;
					}
					goto IL_0a2d;
					IL_012b:
					if (!_0024fader_002420209 || !_0024fader_002420209.isOutCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024go_002420206)
					{
						_0024go_002420206 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002420207 && (bool)_0024go_002420206)
					{
						_0024tutoRoot_002420207 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420206);
					}
					BattleHUD.PointTutorialArrowToQuestNew();
					_0024worldQuestMain_002420210 = (WorldQuestMain)UnityEngine.Object.FindObjectOfType(typeof(WorldQuestMain));
					if (!_0024worldQuestMain_002420210)
					{
						throw new AssertionFailedException("worldQuestMain");
					}
					goto IL_0206;
					IL_0d66:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:654", "call命令");
					_0024_0024s540_0024call_00242105_002420243 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242104_002420244 = _0024self__002420277.S540_tutorial_npc(string.Empty, "自分で装備をカスタマイズしたいときは\n「カスタム」を選択しよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242104_002420244 != null)
					{
						_0024_0024iterator_002413864_002420271 = _0024_0024s540_0024call_00242104_002420244;
						goto case 21;
					}
					goto IL_0e2d;
					IL_1228:
					_0024self__002420277.stop(_0024_0024CUR_EXEC_0024_002420204);
					goto case 1;
					IL_077c:
					if (!_0024fader_002420209 || !_0024fader_002420209.isOutCompleted)
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					if (!_0024go_002420206)
					{
						_0024go_002420206 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002420207 && (bool)_0024go_002420206)
					{
						_0024tutoRoot_002420207 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420206);
					}
					_0024worldQuestMain_002420210 = (WorldQuestMain)UnityEngine.Object.FindObjectOfType(typeof(WorldQuestMain));
					if (!_0024worldQuestMain_002420210)
					{
						throw new AssertionFailedException("worldQuestMain");
					}
					goto IL_0853;
					IL_107d:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToQuestStart();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:664", "call命令");
					_0024_0024s540_0024call_00242117_002420255 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242116_002420256 = _0024self__002420277.S540_tutorial_npc(string.Empty, "準備がよければ\n『クエスト開始！』をタップ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242116_002420256 != null)
					{
						_0024_0024iterator_002413868_002420275 = _0024_0024s540_0024call_00242116_002420256;
						goto case 25;
					}
					goto IL_1149;
					IL_0e2d:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToQuestDeck();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:658", "call命令");
					_0024_0024s540_0024call_00242108_002420246 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242107_002420247 = _0024self__002420277.S540_tutorial_npc(string.Empty, "さらに、デッキの切り替えも\nここでおこなうことができるぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242107_002420247 != null)
					{
						_0024_0024iterator_002413865_002420272 = _0024_0024s540_0024call_00242107_002420247;
						goto case 22;
					}
					goto IL_0efe;
					IL_0206:
					if (_0024worldQuestMain_002420210.Mode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_023d;
					IL_023d:
					if (_0024worldQuestMain_002420210.IsChangingSituation)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					BattleHUD.PointTutorialArrowToQuestNew();
					ModalCollider.SetActive(_0024self__002420277, active: true);
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:590", "call命令");
					_0024_0024s540_0024call_00242075_002420211 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242074_002420212 = _0024self__002420277.S540_tutorial_npc(string.Empty, "新しく発生したクエストには\n『ＮＥＷ！』というマークが表示される。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242074_002420212 != null)
					{
						_0024_0024iterator_002413854_002420261 = _0024_0024s540_0024call_00242074_002420212;
						goto case 5;
					}
					goto IL_0309;
					IL_0853:
					if (_0024worldQuestMain_002420210.Mode != WorldQuestMain.WORLD_QUEST_MODE.SelectPet)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					goto IL_088b;
					IL_088b:
					if (_0024worldQuestMain_002420210.IsChangingSituation)
					{
						result = (YieldDefault(13) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002420277, active: true);
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:624", "call命令");
					_0024_0024s540_0024call_00242093_002420230 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242092_002420231 = _0024self__002420277.S540_tutorial_npc(string.Empty, "ここでは、助っ人となる\n魔ペットを選択できる。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242092_002420231 != null)
					{
						_0024_0024iterator_002413860_002420267 = _0024_0024s540_0024call_00242092_002420231;
						goto case 14;
					}
					goto IL_0953;
					IL_0309:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:591", "call命令");
					_0024_0024s540_0024call_00242078_002420214 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242077_002420215 = _0024self__002420277.S540_tutorial_npc(string.Empty, "そのクエストをクリアすることで\nゲームが進行していくぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242077_002420215 != null)
					{
						_0024_0024iterator_002413855_002420262 = _0024_0024s540_0024call_00242077_002420215;
						goto case 6;
					}
					goto IL_03cf;
					IL_0bbe:
					if (_0024worldQuestMain_002420210.IsChangingSituation)
					{
						result = (YieldDefault(18) ? 1 : 0);
						break;
					}
					ModalCollider.SetActive(_0024self__002420277, active: true);
					BattleHUD.PointTutorialArrowToWeaponSelect();
					BattleHUD.PointTutorialArrowToPoppetSelect();
					BattleHUD.PointTutorialArrowToFriendPoppetSelect();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:650", "call命令");
					_0024_0024s540_0024call_00242099_002420237 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242098_002420238 = _0024self__002420277.S540_tutorial_npc(string.Empty, "メイン武器や魔ペットを変更したいときは\nそれぞれのアイコンをタップしよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242098_002420238 != null)
					{
						_0024_0024iterator_002413862_002420269 = _0024_0024s540_0024call_00242098_002420238;
						goto case 19;
					}
					goto IL_0c95;
					IL_03cf:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:593", "call命令");
					_0024_0024s540_0024call_00242081_002420217 = _0024self__002420277.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242080_002420218 = _0024self__002420277.S540_message_end();
					if (_0024_0024s540_0024call_00242080_002420218 != null)
					{
						_0024_0024iterator_002413856_002420263 = _0024_0024s540_0024call_00242080_002420218;
						goto case 7;
					}
					goto IL_0486;
					IL_0953:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:626", "call命令");
					_0024_0024s540_0024call_00242096_002420233 = _0024self__002420277.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242095_002420234 = _0024self__002420277.S540_message_end();
					if (_0024_0024s540_0024call_00242095_002420234 != null)
					{
						_0024_0024iterator_002413861_002420268 = _0024_0024s540_0024call_00242095_002420234;
						goto case 15;
					}
					goto IL_0a06;
					IL_0efe:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:659", "call命令");
					_0024_0024s540_0024call_00242111_002420249 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242110_002420250 = _0024self__002420277.S540_tutorial_npc(string.Empty, "ステータス部分をスワイプするか\n上のデッキボタンを押して切り替えよう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242110_002420250 != null)
					{
						_0024_0024iterator_002413866_002420273 = _0024_0024s540_0024call_00242110_002420250;
						goto case 23;
					}
					goto IL_0fc5;
					IL_0486:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToQuestEnemyInfo();
					BattleHUD.PointTutorialArrowToQuestTreasureInfo();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:597", "call命令");
					_0024_0024s540_0024call_00242084_002420220 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242083_002420221 = _0024self__002420277.S540_tutorial_npc(string.Empty, "各クエストに出現する敵モンスターや\n宝箱の情報はここで確認しよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242083_002420221 != null)
					{
						_0024_0024iterator_002413857_002420264 = _0024_0024s540_0024call_00242083_002420221;
						goto case 8;
					}
					goto IL_0556;
					IL_0c95:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToQuestSupport();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:653", "call命令");
					_0024_0024s540_0024call_00242102_002420240 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242101_002420241 = _0024self__002420277.S540_tutorial_npc(string.Empty, "右上のカスタマイズボタンで\n目的に合った装備に自動変更ができるぞ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242101_002420241 != null)
					{
						_0024_0024iterator_002413863_002420270 = _0024_0024s540_0024call_00242101_002420241;
						goto case 20;
					}
					goto IL_0d66;
					IL_0fc5:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:661", "call命令");
					_0024_0024s540_0024call_00242114_002420252 = _0024self__002420277.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242113_002420253 = _0024self__002420277.S540_message_end();
					if (_0024_0024s540_0024call_00242113_002420253 != null)
					{
						_0024_0024iterator_002413867_002420274 = _0024_0024s540_0024call_00242113_002420253;
						goto case 24;
					}
					goto IL_107d;
					IL_0556:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.PointTutorialArrowToQuestEnemyInfoWeak();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:600", "call命令");
					_0024_0024s540_0024call_00242087_002420223 = _0024self__002420277.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242086_002420224 = _0024self__002420277.S540_tutorial_npc(string.Empty, "モンスターのアイコンについた武器マークは\nそのモンスターの弱点を表しているぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242086_002420224 != null)
					{
						_0024_0024iterator_002413858_002420265 = _0024_0024s540_0024call_00242086_002420224;
						goto case 9;
					}
					goto IL_0627;
					IL_0a06:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420277, active: false);
					goto IL_0a2d;
					IL_1149:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:666", "call命令");
					_0024_0024s540_0024call_00242120_002420258 = _0024self__002420277.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242119_002420259 = _0024self__002420277.S540_message_end();
					if (_0024_0024s540_0024call_00242119_002420259 != null)
					{
						_0024_0024iterator_002413869_002420276 = _0024_0024s540_0024call_00242119_002420259;
						goto case 26;
					}
					goto IL_1201;
					IL_0627:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420277.dtrace(_0024_0024CUR_EXEC_0024_002420204, "TutorialEvent.boo:602", "call命令");
					_0024_0024s540_0024call_00242090_002420226 = _0024self__002420277.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420204);
					_0024_0024s540_0024call_00242089_002420227 = _0024self__002420277.S540_message_end();
					if (_0024_0024s540_0024call_00242089_002420227 != null)
					{
						_0024_0024iterator_002413859_002420266 = _0024_0024s540_0024call_00242089_002420227;
						goto case 10;
					}
					goto IL_06df;
					IL_0b86:
					if (_0024worldQuestMain_002420210.Mode != WorldQuestMain.WORLD_QUEST_MODE.ConfQuest)
					{
						result = (YieldDefault(17) ? 1 : 0);
						break;
					}
					goto IL_0bbe;
					IL_0aaf:
					if (!_0024fader_002420209 || !_0024fader_002420209.isOutCompleted)
					{
						result = (YieldDefault(16) ? 1 : 0);
						break;
					}
					if (!_0024go_002420206)
					{
						_0024go_002420206 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Quest") as GameObject;
					}
					if (!_0024tutoRoot_002420207 && (bool)_0024go_002420206)
					{
						_0024tutoRoot_002420207 = (GameObject)UnityEngine.Object.Instantiate(_0024go_002420206);
					}
					_0024worldQuestMain_002420210 = (WorldQuestMain)UnityEngine.Object.FindObjectOfType(typeof(WorldQuestMain));
					if (!_0024worldQuestMain_002420210)
					{
						throw new AssertionFailedException("worldQuestMain");
					}
					goto IL_0b86;
					IL_0a2d:
					_0024flagID3_002420236 = _0024ud_002420205.hasFlag("s01QuestMenuConfTuto");
					if (!_0024flagID3_002420236 && _0024flagID1_002420208 && _0024flagID2_002420229)
					{
						_0024ud_002420205.setFlag("s01QuestMenuConfTuto");
						_0024flagID3_002420236 = true;
						_0024fader_002420209 = FaderCore.Instance;
						goto IL_0aaf;
					}
					goto IL_1228;
					IL_06df:
					if (!_0024self__002420277.isExecuting(_0024_0024CUR_EXEC_0024_002420204))
					{
						goto case 1;
					}
					ModalCollider.SetActive(_0024self__002420277, active: false);
					goto IL_0706;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420278;

		public _0024S540_tutorial_ui_worldQuest_002420202(TutorialEvent self_)
		{
			_0024self__002420278 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420278);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_lottery_002420279 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242141_002420280;

			internal object _0024___item_002420281;

			internal IEnumerator _0024_0024iterator_002413870_002420282;

			internal TutorialEvent _0024self__002420283;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420283 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242141_002420280 = _0024self__002420283.S540_tutorial_lottery(null);
					if (_0024_0024s540_0024ycode_00242141_002420280 != null)
					{
						_0024_0024iterator_002413870_002420282 = _0024_0024s540_0024ycode_00242141_002420280;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413870_002420282.MoveNext())
					{
						_0024___item_002420281 = _0024_0024iterator_002413870_002420282.Current;
						result = (Yield(2, _0024___item_002420281) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420284;

		public _0024S540_tutorial_lottery_002420279(TutorialEvent self_)
		{
			_0024self__002420284 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420284);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_lottery_002420285 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420286;

			internal Exec _0024_0024CUR_EXEC_0024_002420287;

			internal UserData _0024ud_002420288;

			internal bool _0024flagID_002420289;

			internal GameObject _0024go_002420290;

			internal __LotterySequence_startUpdateFunc_0024callable42_002410_31__ _0024lotteryStart_002420291;

			internal __LotterySequence_startUpdateFunc_0024callable42_002410_31__ _0024lotteryEnd_002420292;

			internal Exec _0024_0024s540_0024call_00242124_002420293;

			internal IEnumerator _0024_0024s540_0024call_00242123_002420294;

			internal object _0024_0024s540_0024call_00242125_002420295;

			internal Exec _0024_0024s540_0024call_00242127_002420296;

			internal IEnumerator _0024_0024s540_0024call_00242126_002420297;

			internal object _0024_0024s540_0024call_00242128_002420298;

			internal Exec _0024_0024s540_0024call_00242130_002420299;

			internal IEnumerator _0024_0024s540_0024call_00242129_002420300;

			internal object _0024_0024s540_0024call_00242131_002420301;

			internal Exec _0024_0024s540_0024call_00242133_002420302;

			internal IEnumerator _0024_0024s540_0024call_00242132_002420303;

			internal object _0024_0024s540_0024call_00242134_002420304;

			internal Exec _0024_0024s540_0024call_00242136_002420305;

			internal IEnumerator _0024_0024s540_0024call_00242135_002420306;

			internal object _0024_0024s540_0024call_00242137_002420307;

			internal Exec _0024_0024s540_0024call_00242139_002420308;

			internal IEnumerator _0024_0024s540_0024call_00242138_002420309;

			internal object _0024_0024s540_0024call_00242140_002420310;

			internal IEnumerator _0024_0024iterator_002413871_002420311;

			internal IEnumerator _0024_0024iterator_002413872_002420312;

			internal IEnumerator _0024_0024iterator_002413873_002420313;

			internal IEnumerator _0024_0024iterator_002413874_002420314;

			internal IEnumerator _0024_0024iterator_002413875_002420315;

			internal IEnumerator _0024_0024iterator_002413876_002420316;

			internal _0024S540_tutorial_lottery_0024locals_002414459 _0024_0024locals_002420317;

			internal TutorialEvent _0024self__002420318;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420318 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002420317 = new _0024S540_tutorial_lottery_0024locals_002414459();
					_0024_0024STATE_NAME_0024_002420286 = "S540_tutorial_lottery";
					_0024_0024CUR_EXEC_0024_002420287 = _0024self__002420318.lastCreatedExec;
					_0024_0024locals_002420317._0024lotteryStep = 0;
					_0024ud_002420288 = UserData.Current;
					if (_0024ud_002420288 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024flagID_002420289 = _0024ud_002420288.hasFlag("s01GatyaTuto");
					if (!_0024flagID_002420289)
					{
						_0024ud_002420288.setFlag("s01GatyaTuto");
						MerlinServer.NotifyTutorialStep(250);
						_0024go_002420290 = GameAssetModule.LoadPrefab("Prefab/HUD/Tutorial UI Root Lottery") as GameObject;
						UnityEngine.Object.Instantiate(_0024go_002420290);
						_0024lotteryStart_002420291 = new _0024S540_tutorial_lottery_0024closure_00243252(_0024_0024locals_002420317).Invoke;
						_0024lotteryEnd_002420292 = new _0024S540_tutorial_lottery_0024closure_00243253(_0024_0024locals_002420317).Invoke;
						LotterySequence.EnableTutorial(_0024lotteryStart_002420291, _0024lotteryEnd_002420292);
						goto IL_0153;
					}
					goto IL_0658;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420287.NotExecuting)
					{
						goto IL_0153;
					}
					goto case 1;
				case 3:
					if (_0024_0024iterator_002413871_002420311.MoveNext())
					{
						_0024_0024s540_0024call_00242125_002420295 = _0024_0024iterator_002413871_002420311.Current;
						result = (Yield(3, _0024_0024s540_0024call_00242125_002420295) ? 1 : 0);
						break;
					}
					goto IL_020f;
				case 4:
					if (_0024_0024iterator_002413872_002420312.MoveNext())
					{
						_0024_0024s540_0024call_00242128_002420298 = _0024_0024iterator_002413872_002420312.Current;
						result = (Yield(4, _0024_0024s540_0024call_00242128_002420298) ? 1 : 0);
						break;
					}
					goto IL_02da;
				case 5:
					if (_0024_0024iterator_002413873_002420313.MoveNext())
					{
						_0024_0024s540_0024call_00242131_002420301 = _0024_0024iterator_002413873_002420313.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242131_002420301) ? 1 : 0);
						break;
					}
					goto IL_03aa;
				case 6:
					if (_0024_0024iterator_002413874_002420314.MoveNext())
					{
						_0024_0024s540_0024call_00242134_002420304 = _0024_0024iterator_002413874_002420314.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242134_002420304) ? 1 : 0);
						break;
					}
					goto IL_0470;
				case 7:
					if (_0024_0024iterator_002413875_002420315.MoveNext())
					{
						_0024_0024s540_0024call_00242137_002420307 = _0024_0024iterator_002413875_002420315.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242137_002420307) ? 1 : 0);
						break;
					}
					goto IL_0536;
				case 8:
					if (_0024_0024iterator_002413876_002420316.MoveNext())
					{
						_0024_0024s540_0024call_00242140_002420310 = _0024_0024iterator_002413876_002420316.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242140_002420310) ? 1 : 0);
						break;
					}
					goto IL_05ed;
				case 9:
					if (!_0024_0024CUR_EXEC_0024_002420287.NotExecuting)
					{
						goto IL_063b;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0536:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:706", "call命令");
					_0024_0024s540_0024call_00242139_002420308 = _0024self__002420318.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242138_002420309 = _0024self__002420318.S540_message_end();
					if (_0024_0024s540_0024call_00242138_002420309 != null)
					{
						_0024_0024iterator_002413876_002420316 = _0024_0024s540_0024call_00242138_002420309;
						goto case 8;
					}
					goto IL_05ed;
					IL_03aa:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:702", "call命令");
					_0024_0024s540_0024call_00242133_002420302 = _0024self__002420318.createExec("S540_gatya_npc", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242132_002420303 = _0024self__002420318.S540_gatya_npc("ニキータ", "精霊石くじは、精霊石が必要な分\n必ずイイものがアタるにゃ！！", GATYA_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242132_002420303 != null)
					{
						_0024_0024iterator_002413874_002420314 = _0024_0024s540_0024call_00242132_002420303;
						goto case 6;
					}
					goto IL_0470;
					IL_0153:
					if (_0024_0024locals_002420317._0024lotteryStep != 1)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:695", "call命令");
					_0024_0024s540_0024call_00242124_002420293 = _0024self__002420318.createExec("S540_gatya_npc", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242123_002420294 = _0024self__002420318.S540_gatya_npc("ニキータ", "くじびきは、大きくわけると\nふたつ種類があるにゃ。", GATYA_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242123_002420294 != null)
					{
						_0024_0024iterator_002413871_002420311 = _0024_0024s540_0024call_00242123_002420294;
						goto case 3;
					}
					goto IL_020f;
					IL_063b:
					if (_0024_0024locals_002420317._0024lotteryStep != 3)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					_0024_0024locals_002420317._0024lotteryStep = 4;
					goto IL_0658;
					IL_020f:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					BattleHUD.DrawTutorialFriendpointGatya();
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:697", "call命令");
					_0024_0024s540_0024call_00242127_002420296 = _0024self__002420318.createExec("S540_gatya_npc", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242126_002420297 = _0024self__002420318.S540_gatya_npc("ニキータ", "（１）フレンドくじ\nフレンドポイント２００で一回ひけるにゃ。", GATYA_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242126_002420297 != null)
					{
						_0024_0024iterator_002413872_002420312 = _0024_0024s540_0024call_00242126_002420297;
						goto case 4;
					}
					goto IL_02da;
					IL_0470:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:703", "call命令");
					_0024_0024s540_0024call_00242136_002420305 = _0024self__002420318.createExec("S540_gatya_npc", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242135_002420306 = _0024self__002420318.S540_gatya_npc("ニキータ", "アンタ、ちょうど精霊石５個持ってるにゃ。\nダマされたと思って一回ひいてみるにゃ！！", GATYA_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242135_002420306 != null)
					{
						_0024_0024iterator_002413875_002420315 = _0024_0024s540_0024call_00242135_002420306;
						goto case 7;
					}
					goto IL_0536;
					IL_05ed:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					_0024_0024locals_002420317._0024lotteryStep = 2;
					goto IL_063b;
					IL_02da:
					if (!_0024self__002420318.isExecuting(_0024_0024CUR_EXEC_0024_002420287))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialFaystoneGatya();
					_0024self__002420318.dtrace(_0024_0024CUR_EXEC_0024_002420287, "TutorialEvent.boo:700", "call命令");
					_0024_0024s540_0024call_00242130_002420299 = _0024self__002420318.createExec("S540_gatya_npc", _0024_0024CUR_EXEC_0024_002420287);
					_0024_0024s540_0024call_00242129_002420300 = _0024self__002420318.S540_gatya_npc("ニキータ", "（２）精霊石くじ\n精霊石５個で一回ひけるにゃ。", GATYA_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242129_002420300 != null)
					{
						_0024_0024iterator_002413873_002420313 = _0024_0024s540_0024call_00242129_002420300;
						goto case 5;
					}
					goto IL_03aa;
					IL_0658:
					_0024self__002420318.stop(_0024_0024CUR_EXEC_0024_002420287);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420319;

		public _0024S540_tutorial_lottery_002420285(TutorialEvent self_)
		{
			_0024self__002420319 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420319);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_000_new_002420320 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242157_002420321;

			internal object _0024___item_002420322;

			internal IEnumerator _0024_0024iterator_002413877_002420323;

			internal TutorialEvent _0024self__002420324;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420324 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242157_002420321 = _0024self__002420324.S540_tutorial_mountain_000_new(null);
					if (_0024_0024s540_0024ycode_00242157_002420321 != null)
					{
						_0024_0024iterator_002413877_002420323 = _0024_0024s540_0024ycode_00242157_002420321;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413877_002420323.MoveNext())
					{
						_0024___item_002420322 = _0024_0024iterator_002413877_002420323.Current;
						result = (Yield(2, _0024___item_002420322) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420325;

		public _0024S540_tutorial_mountain_000_new_002420320(TutorialEvent self_)
		{
			_0024self__002420325 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420325);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_000_new_002420326 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420327;

			internal Exec _0024_0024CUR_EXEC_0024_002420328;

			internal UserData _0024ud_002420329;

			internal PlayerControl _0024Player_002420330;

			internal Exec _0024_0024s540_0024call_00242143_002420331;

			internal IEnumerator _0024_0024s540_0024call_00242142_002420332;

			internal object _0024_0024s540_0024call_00242144_002420333;

			internal Exec _0024_0024s540_0024call_00242146_002420334;

			internal IEnumerator _0024_0024s540_0024call_00242145_002420335;

			internal object _0024_0024s540_0024call_00242147_002420336;

			internal Exec _0024_0024s540_0024call_00242149_002420337;

			internal IEnumerator _0024_0024s540_0024call_00242148_002420338;

			internal object _0024_0024s540_0024call_00242150_002420339;

			internal Exec _0024_0024s540_0024call_00242152_002420340;

			internal IEnumerator _0024_0024s540_0024call_00242151_002420341;

			internal object _0024_0024s540_0024call_00242153_002420342;

			internal Exec _0024_0024s540_0024call_00242155_002420343;

			internal IEnumerator _0024_0024s540_0024call_00242154_002420344;

			internal object _0024_0024s540_0024call_00242156_002420345;

			internal IEnumerator _0024_0024iterator_002413878_002420346;

			internal IEnumerator _0024_0024iterator_002413879_002420347;

			internal IEnumerator _0024_0024iterator_002413880_002420348;

			internal IEnumerator _0024_0024iterator_002413881_002420349;

			internal IEnumerator _0024_0024iterator_002413882_002420350;

			internal TutorialEvent _0024self__002420351;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420351 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420327 = "S540_tutorial_mountain_000_new";
					_0024_0024CUR_EXEC_0024_002420328 = _0024self__002420351.lastCreatedExec;
					_0024ud_002420329 = UserData.Current;
					goto IL_008c;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto IL_008c;
					}
					goto case 1;
				case 3:
					if (_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto case 1;
					}
					goto IL_00a2;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto IL_0128;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413878_002420346.MoveNext())
					{
						_0024_0024s540_0024call_00242144_002420333 = _0024_0024iterator_002413878_002420346.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242144_002420333) ? 1 : 0);
						break;
					}
					goto IL_01ff;
				case 6:
					if (!_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto IL_0245;
					}
					goto case 1;
				case 7:
					if (_0024_0024iterator_002413879_002420347.MoveNext())
					{
						_0024_0024s540_0024call_00242147_002420336 = _0024_0024iterator_002413879_002420347.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242147_002420336) ? 1 : 0);
						break;
					}
					goto IL_0331;
				case 8:
					if (_0024_0024iterator_002413880_002420348.MoveNext())
					{
						_0024_0024s540_0024call_00242150_002420339 = _0024_0024iterator_002413880_002420348.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242150_002420339) ? 1 : 0);
						break;
					}
					goto IL_03ed;
				case 9:
					if (!_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto IL_0442;
					}
					goto case 1;
				case 10:
					if (_0024_0024iterator_002413881_002420349.MoveNext())
					{
						_0024_0024s540_0024call_00242153_002420342 = _0024_0024iterator_002413881_002420349.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242153_002420342) ? 1 : 0);
						break;
					}
					goto IL_0520;
				case 11:
					if (!_0024_0024CUR_EXEC_0024_002420328.NotExecuting)
					{
						goto IL_0567;
					}
					goto case 1;
				case 12:
					if (_0024_0024iterator_002413882_002420350.MoveNext())
					{
						_0024_0024s540_0024call_00242156_002420345 = _0024_0024iterator_002413882_002420350.Current;
						result = (Yield(12, _0024_0024s540_0024call_00242156_002420345) ? 1 : 0);
						break;
					}
					goto IL_063f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008c:
					if (!QuestInitializer.IsInPlay)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024Player_002420330 = null;
					goto IL_00a2;
					IL_0331:
					if (!_0024self__002420351.isExecuting(_0024_0024CUR_EXEC_0024_002420328))
					{
						goto case 1;
					}
					goto IL_0408;
					IL_00a2:
					_0024Player_002420330 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420330 != null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (MountainTutorialStep == 0)
					{
						goto IL_0128;
					}
					goto IL_066a;
					IL_0128:
					if (!(_0024Player_002420330 != null) || _0024Player_002420330.transform.position.z <= -20f)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					_0024self__002420351.dtrace(_0024_0024CUR_EXEC_0024_002420328, "TutorialEvent.boo:751", "call命令");
					_0024_0024s540_0024call_00242143_002420331 = _0024self__002420351.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420328);
					_0024_0024s540_0024call_00242142_002420332 = _0024self__002420351.S540_call_tutorials("TutorialMountain_000_AutoBattle");
					if (_0024_0024s540_0024call_00242142_002420332 != null)
					{
						_0024_0024iterator_002413878_002420346 = _0024_0024s540_0024call_00242142_002420332;
						goto case 5;
					}
					goto IL_01ff;
					IL_03ed:
					if (_0024self__002420351.isExecuting(_0024_0024CUR_EXEC_0024_002420328))
					{
						goto IL_0408;
					}
					goto case 1;
					IL_0408:
					MerlinServer.NotifyTutorialStep(30);
					MerlinServer.NotifyTutorialStep(40);
					ScreenMask.deactivate();
					goto IL_0442;
					IL_0442:
					if (!(_0024Player_002420330 != null) || _0024Player_002420330.transform.position.z <= 0f)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					MerlinServer.NotifyTutorialStep(50);
					_0024self__002420351.dtrace(_0024_0024CUR_EXEC_0024_002420328, "TutorialEvent.boo:770", "call命令");
					_0024_0024s540_0024call_00242152_002420340 = _0024self__002420351.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420328);
					_0024_0024s540_0024call_00242151_002420341 = _0024self__002420351.S540_call_tutorials("TutorialMountain_000_Change");
					if (_0024_0024s540_0024call_00242151_002420341 != null)
					{
						_0024_0024iterator_002413881_002420349 = _0024_0024s540_0024call_00242151_002420341;
						goto case 10;
					}
					goto IL_0520;
					IL_01ff:
					if (!_0024self__002420351.isExecuting(_0024_0024CUR_EXEC_0024_002420328))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_0245;
					IL_063f:
					if (!_0024self__002420351.isExecuting(_0024_0024CUR_EXEC_0024_002420328))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					MountainTutorialStep = 1;
					TutorialUI.DestroyAllAssetBundleGameObject();
					goto IL_066a;
					IL_0245:
					if (!(_0024Player_002420330 != null) || _0024Player_002420330.transform.position.z <= -15f)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					if (_0024ud_002420329.Config.VirtualPad)
					{
						_0024self__002420351.dtrace(_0024_0024CUR_EXEC_0024_002420328, "TutorialEvent.boo:758", "call命令");
						_0024_0024s540_0024call_00242146_002420334 = _0024self__002420351.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420328);
						_0024_0024s540_0024call_00242145_002420335 = _0024self__002420351.S540_call_tutorials("TutorialMountain_000_VirtualPad");
						if (_0024_0024s540_0024call_00242145_002420335 != null)
						{
							_0024_0024iterator_002413879_002420347 = _0024_0024s540_0024call_00242145_002420335;
							goto case 7;
						}
						goto IL_0331;
					}
					_0024self__002420351.dtrace(_0024_0024CUR_EXEC_0024_002420328, "TutorialEvent.boo:760", "call命令");
					_0024_0024s540_0024call_00242149_002420337 = _0024self__002420351.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420328);
					_0024_0024s540_0024call_00242148_002420338 = _0024self__002420351.S540_call_tutorials("TutorialMountain_000_Tap");
					if (_0024_0024s540_0024call_00242148_002420338 != null)
					{
						_0024_0024iterator_002413880_002420348 = _0024_0024s540_0024call_00242148_002420338;
						goto case 8;
					}
					goto IL_03ed;
					IL_0520:
					if (!_0024self__002420351.isExecuting(_0024_0024CUR_EXEC_0024_002420328))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_0567;
					IL_0567:
					if (!(_0024Player_002420330 != null) || _0024Player_002420330.transform.position.z <= 40f)
					{
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					_0024self__002420351.dtrace(_0024_0024CUR_EXEC_0024_002420328, "TutorialEvent.boo:775", "call命令");
					_0024_0024s540_0024call_00242155_002420343 = _0024self__002420351.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420328);
					_0024_0024s540_0024call_00242154_002420344 = _0024self__002420351.S540_call_tutorials("TutorialMountain_000_Bunyu");
					if (_0024_0024s540_0024call_00242154_002420344 != null)
					{
						_0024_0024iterator_002413882_002420350 = _0024_0024s540_0024call_00242154_002420344;
						goto case 12;
					}
					goto IL_063f;
					IL_066a:
					_0024self__002420351.stop(_0024_0024CUR_EXEC_0024_002420328);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420352;

		public _0024S540_tutorial_mountain_000_new_002420326(TutorialEvent self_)
		{
			_0024self__002420352 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420352);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_000_002420353 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242194_002420354;

			internal object _0024___item_002420355;

			internal IEnumerator _0024_0024iterator_002413883_002420356;

			internal TutorialEvent _0024self__002420357;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420357 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242194_002420354 = _0024self__002420357.S540_tutorial_mountain_000(null);
					if (_0024_0024s540_0024ycode_00242194_002420354 != null)
					{
						_0024_0024iterator_002413883_002420356 = _0024_0024s540_0024ycode_00242194_002420354;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413883_002420356.MoveNext())
					{
						_0024___item_002420355 = _0024_0024iterator_002413883_002420356.Current;
						result = (Yield(2, _0024___item_002420355) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420358;

		public _0024S540_tutorial_mountain_000_002420353(TutorialEvent self_)
		{
			_0024self__002420358 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420358);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_000_002420359 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420360;

			internal Exec _0024_0024CUR_EXEC_0024_002420361;

			internal UserData _0024ud_002420362;

			internal PlayerControl _0024Player_002420363;

			internal Exec _0024_0024s540_0024call_00242159_002420364;

			internal IEnumerator _0024_0024s540_0024call_00242158_002420365;

			internal object _0024_0024s540_0024call_00242160_002420366;

			internal Exec _0024_0024s540_0024call_00242162_002420367;

			internal IEnumerator _0024_0024s540_0024call_00242161_002420368;

			internal object _0024_0024s540_0024call_00242163_002420369;

			internal Exec _0024_0024s540_0024call_00242165_002420370;

			internal IEnumerator _0024_0024s540_0024call_00242164_002420371;

			internal object _0024_0024s540_0024call_00242166_002420372;

			internal Exec _0024_0024s540_0024call_00242168_002420373;

			internal IEnumerator _0024_0024s540_0024call_00242167_002420374;

			internal object _0024_0024s540_0024call_00242169_002420375;

			internal Exec _0024_0024s540_0024call_00242171_002420376;

			internal IEnumerator _0024_0024s540_0024call_00242170_002420377;

			internal object _0024_0024s540_0024call_00242172_002420378;

			internal Exec _0024_0024s540_0024call_00242174_002420379;

			internal IEnumerator _0024_0024s540_0024call_00242173_002420380;

			internal object _0024_0024s540_0024call_00242175_002420381;

			internal Exec _0024_0024s540_0024call_00242177_002420382;

			internal IEnumerator _0024_0024s540_0024call_00242176_002420383;

			internal object _0024_0024s540_0024call_00242178_002420384;

			internal Exec _0024_0024s540_0024call_00242180_002420385;

			internal IEnumerator _0024_0024s540_0024call_00242179_002420386;

			internal object _0024_0024s540_0024call_00242181_002420387;

			internal Exec _0024_0024s540_0024call_00242183_002420388;

			internal IEnumerator _0024_0024s540_0024call_00242182_002420389;

			internal object _0024_0024s540_0024call_00242184_002420390;

			internal Exec _0024_0024s540_0024call_00242186_002420391;

			internal IEnumerator _0024_0024s540_0024call_00242185_002420392;

			internal object _0024_0024s540_0024call_00242187_002420393;

			internal Exec _0024_0024s540_0024call_00242189_002420394;

			internal IEnumerator _0024_0024s540_0024call_00242188_002420395;

			internal object _0024_0024s540_0024call_00242190_002420396;

			internal Exec _0024_0024s540_0024call_00242192_002420397;

			internal IEnumerator _0024_0024s540_0024call_00242191_002420398;

			internal object _0024_0024s540_0024call_00242193_002420399;

			internal IEnumerator _0024_0024iterator_002413884_002420400;

			internal IEnumerator _0024_0024iterator_002413885_002420401;

			internal IEnumerator _0024_0024iterator_002413886_002420402;

			internal IEnumerator _0024_0024iterator_002413887_002420403;

			internal IEnumerator _0024_0024iterator_002413888_002420404;

			internal IEnumerator _0024_0024iterator_002413889_002420405;

			internal IEnumerator _0024_0024iterator_002413890_002420406;

			internal IEnumerator _0024_0024iterator_002413891_002420407;

			internal IEnumerator _0024_0024iterator_002413892_002420408;

			internal IEnumerator _0024_0024iterator_002413893_002420409;

			internal IEnumerator _0024_0024iterator_002413894_002420410;

			internal IEnumerator _0024_0024iterator_002413895_002420411;

			internal TutorialEvent _0024self__002420412;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420412 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420360 = "S540_tutorial_mountain_000";
					_0024_0024CUR_EXEC_0024_002420361 = _0024self__002420412.lastCreatedExec;
					_0024ud_002420362 = UserData.Current;
					goto IL_00a8;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto IL_00a8;
					}
					goto case 1;
				case 3:
					if (_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto case 1;
					}
					goto IL_00be;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto IL_0144;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413884_002420400.MoveNext())
					{
						_0024_0024s540_0024call_00242160_002420366 = _0024_0024iterator_002413884_002420400.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242160_002420366) ? 1 : 0);
						break;
					}
					goto IL_022f;
				case 6:
					if (_0024_0024iterator_002413885_002420401.MoveNext())
					{
						_0024_0024s540_0024call_00242163_002420369 = _0024_0024iterator_002413885_002420401.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242163_002420369) ? 1 : 0);
						break;
					}
					goto IL_02f5;
				case 7:
					if (_0024_0024iterator_002413886_002420402.MoveNext())
					{
						_0024_0024s540_0024call_00242166_002420372 = _0024_0024iterator_002413886_002420402.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242166_002420372) ? 1 : 0);
						break;
					}
					goto IL_03bb;
				case 8:
					if (_0024_0024iterator_002413887_002420403.MoveNext())
					{
						_0024_0024s540_0024call_00242169_002420375 = _0024_0024iterator_002413887_002420403.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242169_002420375) ? 1 : 0);
						break;
					}
					goto IL_0472;
				case 9:
					if (!_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto IL_04b9;
					}
					goto case 1;
				case 10:
					if (_0024_0024iterator_002413888_002420404.MoveNext())
					{
						_0024_0024s540_0024call_00242172_002420378 = _0024_0024iterator_002413888_002420404.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242172_002420378) ? 1 : 0);
						break;
					}
					goto IL_05e0;
				case 11:
					if (_0024_0024iterator_002413889_002420405.MoveNext())
					{
						_0024_0024s540_0024call_00242175_002420381 = _0024_0024iterator_002413889_002420405.Current;
						result = (Yield(11, _0024_0024s540_0024call_00242175_002420381) ? 1 : 0);
						break;
					}
					goto IL_06ac;
				case 12:
					if (_0024_0024iterator_002413890_002420406.MoveNext())
					{
						_0024_0024s540_0024call_00242178_002420384 = _0024_0024iterator_002413890_002420406.Current;
						result = (Yield(12, _0024_0024s540_0024call_00242178_002420384) ? 1 : 0);
						break;
					}
					goto IL_0799;
				case 13:
					if (_0024_0024iterator_002413891_002420407.MoveNext())
					{
						_0024_0024s540_0024call_00242181_002420387 = _0024_0024iterator_002413891_002420407.Current;
						result = (Yield(13, _0024_0024s540_0024call_00242181_002420387) ? 1 : 0);
						break;
					}
					goto IL_0851;
				case 14:
					if (!_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto IL_0898;
					}
					goto case 1;
				case 15:
					if (_0024_0024iterator_002413892_002420408.MoveNext())
					{
						_0024_0024s540_0024call_00242184_002420390 = _0024_0024iterator_002413892_002420408.Current;
						result = (Yield(15, _0024_0024s540_0024call_00242184_002420390) ? 1 : 0);
						break;
					}
					goto IL_098f;
				case 16:
					if (_0024_0024iterator_002413893_002420409.MoveNext())
					{
						_0024_0024s540_0024call_00242187_002420393 = _0024_0024iterator_002413893_002420409.Current;
						result = (Yield(16, _0024_0024s540_0024call_00242187_002420393) ? 1 : 0);
						break;
					}
					goto IL_0a47;
				case 17:
					if (!_0024_0024CUR_EXEC_0024_002420361.NotExecuting)
					{
						goto IL_0a98;
					}
					goto case 1;
				case 18:
					if (_0024_0024iterator_002413894_002420410.MoveNext())
					{
						_0024_0024s540_0024call_00242190_002420396 = _0024_0024iterator_002413894_002420410.Current;
						result = (Yield(18, _0024_0024s540_0024call_00242190_002420396) ? 1 : 0);
						break;
					}
					goto IL_0b8b;
				case 19:
					if (_0024_0024iterator_002413895_002420411.MoveNext())
					{
						_0024_0024s540_0024call_00242193_002420399 = _0024_0024iterator_002413895_002420411.Current;
						result = (Yield(19, _0024_0024s540_0024call_00242193_002420399) ? 1 : 0);
						break;
					}
					goto IL_0c3e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00a8:
					if (!QuestInitializer.IsInPlay)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024Player_002420363 = null;
					goto IL_00be;
					IL_0c69:
					_0024self__002420412.stop(_0024_0024CUR_EXEC_0024_002420361);
					goto case 1;
					IL_00be:
					_0024Player_002420363 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420363 != null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (MountainTutorialStep == 0)
					{
						goto IL_0144;
					}
					goto IL_0c69;
					IL_0144:
					if (!(_0024Player_002420363 != null) || _0024Player_002420363.transform.position.z <= -20f)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.PointTutorialArrowToAutoBattle();
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:810", "call命令");
					_0024_0024s540_0024call_00242159_002420364 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242158_002420365 = _0024self__002420412.S540_tutorial_npc(string.Empty, "オートバトルボタンをオンにすると\nオートバトル＆オートラン機能が起動する！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242158_002420365 != null)
					{
						_0024_0024iterator_002413884_002420400 = _0024_0024s540_0024call_00242158_002420365;
						goto case 5;
					}
					goto IL_022f;
					IL_098f:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:854", "call命令");
					_0024_0024s540_0024call_00242186_002420391 = _0024self__002420412.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242185_002420392 = _0024self__002420412.S540_message_end();
					if (_0024_0024s540_0024call_00242185_002420392 != null)
					{
						_0024_0024iterator_002413893_002420409 = _0024_0024s540_0024call_00242185_002420392;
						goto case 16;
					}
					goto IL_0a47;
					IL_06ac:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialMoveHoldImage();
					goto IL_06d1;
					IL_022f:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:811", "call命令");
					_0024_0024s540_0024call_00242162_002420367 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242161_002420368 = _0024self__002420412.S540_tutorial_npc(string.Empty, "オートラン機能は\n一部のクエストのみ有効となるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242161_002420368 != null)
					{
						_0024_0024iterator_002413885_002420401 = _0024_0024s540_0024call_00242161_002420368;
						goto case 6;
					}
					goto IL_02f5;
					IL_06d1:
					MerlinServer.NotifyTutorialStep(40);
					if (!_0024ud_002420362.Config.VirtualPad)
					{
						_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:837", "call命令");
						_0024_0024s540_0024call_00242177_002420382 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
						_0024_0024s540_0024call_00242176_002420383 = _0024self__002420412.S540_tutorial_npc(string.Empty, "画面長押しでも移動は可能だ。\n長押しした方向に移動し続けるぞ。", TUTORIAL_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242176_002420383 != null)
						{
							_0024_0024iterator_002413890_002420406 = _0024_0024s540_0024call_00242176_002420383;
							goto case 12;
						}
						goto IL_0799;
					}
					goto IL_07b4;
					IL_05e0:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					goto IL_06d1;
					IL_02f5:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:812", "call命令");
					_0024_0024s540_0024call_00242165_002420370 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242164_002420371 = _0024self__002420412.S540_tutorial_npc(string.Empty, "オートバトルボタンの表示／非表示は\nポーズメニューの操作設定で設定可能だ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242164_002420371 != null)
					{
						_0024_0024iterator_002413886_002420402 = _0024_0024s540_0024call_00242164_002420371;
						goto case 7;
					}
					goto IL_03bb;
					IL_0a47:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					goto IL_0a98;
					IL_0c3e:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					MountainTutorialStep = 1;
					goto IL_0c69;
					IL_03bb:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:814", "call命令");
					_0024_0024s540_0024call_00242168_002420373 = _0024self__002420412.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242167_002420374 = _0024self__002420412.S540_message_end();
					if (_0024_0024s540_0024call_00242167_002420374 != null)
					{
						_0024_0024iterator_002413887_002420403 = _0024_0024s540_0024call_00242167_002420374;
						goto case 8;
					}
					goto IL_0472;
					IL_0799:
					if (_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto IL_07b4;
					}
					goto case 1;
					IL_07b4:
					BattleHUD.DisableTutorialImages();
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:839", "call命令");
					_0024_0024s540_0024call_00242180_002420385 = _0024self__002420412.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242179_002420386 = _0024self__002420412.S540_message_end();
					if (_0024_0024s540_0024call_00242179_002420386 != null)
					{
						_0024_0024iterator_002413891_002420407 = _0024_0024s540_0024call_00242179_002420386;
						goto case 13;
					}
					goto IL_0851;
					IL_0a98:
					if (!(_0024Player_002420363 != null) || _0024Player_002420363.transform.position.z <= 40f)
					{
						result = (YieldDefault(17) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.DrawTutorialBunyuImage();
					MerlinServer.NotifyTutorialStep(60);
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:863", "call命令");
					_0024_0024s540_0024call_00242189_002420394 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242188_002420395 = _0024self__002420412.S540_tutorial_npc(string.Empty, "このピンクの生物は『ぶにゅ』。\n彼女がふさいでいる道には入れないぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242188_002420395 != null)
					{
						_0024_0024iterator_002413894_002420410 = _0024_0024s540_0024call_00242188_002420395;
						goto case 18;
					}
					goto IL_0b8b;
					IL_0472:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_04b9;
					IL_04b9:
					if (!(_0024Player_002420363 != null) || _0024Player_002420363.transform.position.z <= -15f)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					if (_0024ud_002420362.Config.VirtualPad)
					{
						BattleHUD.DrawTutorialMoveHoldImageVirtualPad();
					}
					else
					{
						BattleHUD.DrawTutorialMoveTapImage();
					}
					MerlinServer.NotifyTutorialStep(30);
					if (_0024ud_002420362.Config.VirtualPad)
					{
						_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:828", "call命令");
						_0024_0024s540_0024call_00242171_002420376 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
						_0024_0024s540_0024call_00242170_002420377 = _0024self__002420412.S540_tutorial_npc(string.Empty, "画面左側に指を置いた位置を中心とし\n指を動かした方向に主人公は移動するぞ。", TUTORIAL_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242170_002420377 != null)
						{
							_0024_0024iterator_002413888_002420404 = _0024_0024s540_0024call_00242170_002420377;
							goto case 10;
						}
						goto IL_05e0;
					}
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:830", "call命令");
					_0024_0024s540_0024call_00242174_002420379 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242173_002420380 = _0024self__002420412.S540_tutorial_npc(string.Empty, "主人公は、タップした場所に移動するぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242173_002420380 != null)
					{
						_0024_0024iterator_002413889_002420405 = _0024_0024s540_0024call_00242173_002420380;
						goto case 11;
					}
					goto IL_06ac;
					IL_0851:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_0898;
					IL_0898:
					if (!(_0024Player_002420363 != null) || _0024Player_002420363.transform.position.z <= 0f)
					{
						result = (YieldDefault(14) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.PointTutorialArrowToChangeButton();
					BattleHUD.DrawTutorialChangeImage();
					MerlinServer.NotifyTutorialStep(50);
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:848", "call命令");
					_0024_0024s540_0024call_00242183_002420388 = _0024self__002420412.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242182_002420389 = _0024self__002420412.S540_tutorial_npc(string.Empty, "転身アイコンをタップすると転身。\nタップごとに天使と悪魔が入れ替わるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242182_002420389 != null)
					{
						_0024_0024iterator_002413892_002420408 = _0024_0024s540_0024call_00242182_002420389;
						goto case 15;
					}
					goto IL_098f;
					IL_0b8b:
					if (!_0024self__002420412.isExecuting(_0024_0024CUR_EXEC_0024_002420361))
					{
						goto case 1;
					}
					_0024self__002420412.dtrace(_0024_0024CUR_EXEC_0024_002420361, "TutorialEvent.boo:864", "call命令");
					_0024_0024s540_0024call_00242192_002420397 = _0024self__002420412.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420361);
					_0024_0024s540_0024call_00242191_002420398 = _0024self__002420412.S540_message_end();
					if (_0024_0024s540_0024call_00242191_002420398 != null)
					{
						_0024_0024iterator_002413895_002420411 = _0024_0024s540_0024call_00242191_002420398;
						goto case 19;
					}
					goto IL_0c3e;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420413;

		public _0024S540_tutorial_mountain_000_002420359(TutorialEvent self_)
		{
			_0024self__002420413 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420413);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_002_new_002420414 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242203_002420415;

			internal object _0024___item_002420416;

			internal IEnumerator _0024_0024iterator_002413896_002420417;

			internal TutorialEvent _0024self__002420418;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420418 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242203_002420415 = _0024self__002420418.S540_tutorial_mountain_002_new(null);
					if (_0024_0024s540_0024ycode_00242203_002420415 != null)
					{
						_0024_0024iterator_002413896_002420417 = _0024_0024s540_0024ycode_00242203_002420415;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413896_002420417.MoveNext())
					{
						_0024___item_002420416 = _0024_0024iterator_002413896_002420417.Current;
						result = (Yield(2, _0024___item_002420416) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420419;

		public _0024S540_tutorial_mountain_002_new_002420414(TutorialEvent self_)
		{
			_0024self__002420419 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420419);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_002_new_002420420 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420421;

			internal Exec _0024_0024CUR_EXEC_0024_002420422;

			internal UserData _0024ud_002420423;

			internal PlayerControl _0024Player_002420424;

			internal IEnumerator _0024_0024sco_0024temp_00242195_002420425;

			internal float _0024_0024wait_sec_0024temp_00242196_002420426;

			internal Exec _0024_0024s540_0024call_00242198_002420427;

			internal IEnumerator _0024_0024s540_0024call_00242197_002420428;

			internal object _0024_0024s540_0024call_00242199_002420429;

			internal Exec _0024_0024s540_0024call_00242201_002420430;

			internal IEnumerator _0024_0024s540_0024call_00242200_002420431;

			internal object _0024_0024s540_0024call_00242202_002420432;

			internal IEnumerator _0024_0024iterator_002413897_002420433;

			internal IEnumerator _0024_0024iterator_002413898_002420434;

			internal TutorialEvent _0024self__002420435;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420435 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420421 = "S540_tutorial_mountain_002_new";
					_0024_0024CUR_EXEC_0024_002420422 = _0024self__002420435.lastCreatedExec;
					_0024ud_002420423 = UserData.Current;
					_0024Player_002420424 = null;
					goto IL_005a;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420422.NotExecuting)
					{
						goto case 1;
					}
					goto IL_005a;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420422.NotExecuting)
					{
						goto IL_0115;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420422.NotExecuting)
					{
						goto IL_017a;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413897_002420433.MoveNext())
					{
						_0024_0024s540_0024call_00242199_002420429 = _0024_0024iterator_002413897_002420433.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242199_002420429) ? 1 : 0);
						break;
					}
					goto IL_0249;
				case 6:
					if (_0024_0024iterator_002413898_002420434.MoveNext())
					{
						_0024_0024s540_0024call_00242202_002420432 = _0024_0024iterator_002413898_002420434.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242202_002420432) ? 1 : 0);
						break;
					}
					goto IL_0305;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005a:
					_0024Player_002420424 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420424 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242195_002420425 = _0024self__002420435.revivePlayer(_0024Player_002420424);
					if (_0024_0024sco_0024temp_00242195_002420425 != null)
					{
						_0024self__002420435.StartCoroutine(_0024_0024sco_0024temp_00242195_002420425);
					}
					if (MountainTutorialStep == 1)
					{
						goto IL_0115;
					}
					goto IL_032b;
					IL_0305:
					if (_0024self__002420435.isExecuting(_0024_0024CUR_EXEC_0024_002420422))
					{
						goto IL_0320;
					}
					goto case 1;
					IL_0249:
					if (!_0024self__002420435.isExecuting(_0024_0024CUR_EXEC_0024_002420422))
					{
						goto case 1;
					}
					goto IL_0320;
					IL_0115:
					if (!(_0024Player_002420424 != null) || _0024Player_002420424.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242196_002420426 = 0.5f;
					goto IL_017a;
					IL_032b:
					TutorialUI.DestroyAllAssetBundleGameObject();
					_0024self__002420435.stop(_0024_0024CUR_EXEC_0024_002420422);
					goto case 1;
					IL_017a:
					if (_0024_0024wait_sec_0024temp_00242196_002420426 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242196_002420426 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					MerlinServer.NotifyTutorialStep(70);
					if (_0024ud_002420423.Config.VirtualPad)
					{
						_0024self__002420435.dtrace(_0024_0024CUR_EXEC_0024_002420422, "TutorialEvent.boo:905", "call命令");
						_0024_0024s540_0024call_00242198_002420427 = _0024self__002420435.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420422);
						_0024_0024s540_0024call_00242197_002420428 = _0024self__002420435.S540_call_tutorials("TutorialMountain_002_AttackVirtualPad");
						if (_0024_0024s540_0024call_00242197_002420428 != null)
						{
							_0024_0024iterator_002413897_002420433 = _0024_0024s540_0024call_00242197_002420428;
							goto case 5;
						}
						goto IL_0249;
					}
					_0024self__002420435.dtrace(_0024_0024CUR_EXEC_0024_002420422, "TutorialEvent.boo:907", "call命令");
					_0024_0024s540_0024call_00242201_002420430 = _0024self__002420435.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420422);
					_0024_0024s540_0024call_00242200_002420431 = _0024self__002420435.S540_call_tutorials("TutorialMountain_002_AttackTap");
					if (_0024_0024s540_0024call_00242200_002420431 != null)
					{
						_0024_0024iterator_002413898_002420434 = _0024_0024s540_0024call_00242200_002420431;
						goto case 6;
					}
					goto IL_0305;
					IL_0320:
					ScreenMask.deactivate();
					MountainTutorialStep = 2;
					goto IL_032b;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420436;

		public _0024S540_tutorial_mountain_002_new_002420420(TutorialEvent self_)
		{
			_0024self__002420436 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420436);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_002_002420437 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242227_002420438;

			internal object _0024___item_002420439;

			internal IEnumerator _0024_0024iterator_002413899_002420440;

			internal TutorialEvent _0024self__002420441;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420441 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242227_002420438 = _0024self__002420441.S540_tutorial_mountain_002(null);
					if (_0024_0024s540_0024ycode_00242227_002420438 != null)
					{
						_0024_0024iterator_002413899_002420440 = _0024_0024s540_0024ycode_00242227_002420438;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413899_002420440.MoveNext())
					{
						_0024___item_002420439 = _0024_0024iterator_002413899_002420440.Current;
						result = (Yield(2, _0024___item_002420439) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420442;

		public _0024S540_tutorial_mountain_002_002420437(TutorialEvent self_)
		{
			_0024self__002420442 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420442);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_002_002420443 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420444;

			internal Exec _0024_0024CUR_EXEC_0024_002420445;

			internal UserData _0024ud_002420446;

			internal PlayerControl _0024Player_002420447;

			internal IEnumerator _0024_0024sco_0024temp_00242204_002420448;

			internal float _0024_0024wait_sec_0024temp_00242205_002420449;

			internal Exec _0024_0024s540_0024call_00242207_002420450;

			internal IEnumerator _0024_0024s540_0024call_00242206_002420451;

			internal object _0024_0024s540_0024call_00242208_002420452;

			internal Exec _0024_0024s540_0024call_00242210_002420453;

			internal IEnumerator _0024_0024s540_0024call_00242209_002420454;

			internal object _0024_0024s540_0024call_00242211_002420455;

			internal Exec _0024_0024s540_0024call_00242213_002420456;

			internal IEnumerator _0024_0024s540_0024call_00242212_002420457;

			internal object _0024_0024s540_0024call_00242214_002420458;

			internal Exec _0024_0024s540_0024call_00242216_002420459;

			internal IEnumerator _0024_0024s540_0024call_00242215_002420460;

			internal object _0024_0024s540_0024call_00242217_002420461;

			internal Exec _0024_0024s540_0024call_00242219_002420462;

			internal IEnumerator _0024_0024s540_0024call_00242218_002420463;

			internal object _0024_0024s540_0024call_00242220_002420464;

			internal Exec _0024_0024s540_0024call_00242222_002420465;

			internal IEnumerator _0024_0024s540_0024call_00242221_002420466;

			internal object _0024_0024s540_0024call_00242223_002420467;

			internal Exec _0024_0024s540_0024call_00242225_002420468;

			internal IEnumerator _0024_0024s540_0024call_00242224_002420469;

			internal object _0024_0024s540_0024call_00242226_002420470;

			internal IEnumerator _0024_0024iterator_002413900_002420471;

			internal IEnumerator _0024_0024iterator_002413901_002420472;

			internal IEnumerator _0024_0024iterator_002413902_002420473;

			internal IEnumerator _0024_0024iterator_002413903_002420474;

			internal IEnumerator _0024_0024iterator_002413904_002420475;

			internal IEnumerator _0024_0024iterator_002413905_002420476;

			internal IEnumerator _0024_0024iterator_002413906_002420477;

			internal TutorialEvent _0024self__002420478;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420478 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420444 = "S540_tutorial_mountain_002";
					_0024_0024CUR_EXEC_0024_002420445 = _0024self__002420478.lastCreatedExec;
					_0024ud_002420446 = UserData.Current;
					_0024Player_002420447 = null;
					goto IL_006e;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420445.NotExecuting)
					{
						goto case 1;
					}
					goto IL_006e;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420445.NotExecuting)
					{
						goto IL_0129;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420445.NotExecuting)
					{
						goto IL_018e;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413900_002420471.MoveNext())
					{
						_0024_0024s540_0024call_00242208_002420452 = _0024_0024iterator_002413900_002420471.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242208_002420452) ? 1 : 0);
						break;
					}
					goto IL_0290;
				case 6:
					if (_0024_0024iterator_002413901_002420472.MoveNext())
					{
						_0024_0024s540_0024call_00242211_002420455 = _0024_0024iterator_002413901_002420472.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242211_002420455) ? 1 : 0);
						break;
					}
					goto IL_0360;
				case 7:
					if (_0024_0024iterator_002413902_002420473.MoveNext())
					{
						_0024_0024s540_0024call_00242214_002420458 = _0024_0024iterator_002413902_002420473.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242214_002420458) ? 1 : 0);
						break;
					}
					goto IL_042b;
				case 8:
					if (_0024_0024iterator_002413903_002420474.MoveNext())
					{
						_0024_0024s540_0024call_00242217_002420461 = _0024_0024iterator_002413903_002420474.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242217_002420461) ? 1 : 0);
						break;
					}
					goto IL_04f1;
				case 9:
					if (_0024_0024iterator_002413904_002420475.MoveNext())
					{
						_0024_0024s540_0024call_00242220_002420464 = _0024_0024iterator_002413904_002420475.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242220_002420464) ? 1 : 0);
						break;
					}
					goto IL_05c2;
				case 10:
					if (_0024_0024iterator_002413905_002420476.MoveNext())
					{
						_0024_0024s540_0024call_00242223_002420467 = _0024_0024iterator_002413905_002420476.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242223_002420467) ? 1 : 0);
						break;
					}
					goto IL_0689;
				case 11:
					if (_0024_0024iterator_002413906_002420477.MoveNext())
					{
						_0024_0024s540_0024call_00242226_002420470 = _0024_0024iterator_002413906_002420477.Current;
						result = (Yield(11, _0024_0024s540_0024call_00242226_002420470) ? 1 : 0);
						break;
					}
					goto IL_073c;
				case 1:
					{
						result = 0;
						break;
					}
					IL_006e:
					_0024Player_002420447 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420447 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242204_002420448 = _0024self__002420478.revivePlayer(_0024Player_002420447);
					if (_0024_0024sco_0024temp_00242204_002420448 != null)
					{
						_0024self__002420478.StartCoroutine(_0024_0024sco_0024temp_00242204_002420448);
					}
					if (MountainTutorialStep == 1)
					{
						goto IL_0129;
					}
					goto IL_0767;
					IL_0129:
					if (!(_0024Player_002420447 != null) || _0024Player_002420447.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242205_002420449 = 0.5f;
					goto IL_018e;
					IL_042b:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:945", "call命令");
					_0024_0024s540_0024call_00242216_002420459 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242215_002420460 = _0024self__002420478.S540_tutorial_npc(string.Empty, "ロックオンを切り替えたいときは\nロックオンしたい敵を直接タップしよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242215_002420460 != null)
					{
						_0024_0024iterator_002413903_002420474 = _0024_0024s540_0024call_00242215_002420460;
						goto case 8;
					}
					goto IL_04f1;
					IL_018e:
					if (_0024_0024wait_sec_0024temp_00242205_002420449 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242205_002420449 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					if (_0024ud_002420446.Config.VirtualPad)
					{
						BattleHUD.DrawTutorialAttackImageVirtualPad();
					}
					else
					{
						BattleHUD.DrawTutorialLockonImage();
					}
					MerlinServer.NotifyTutorialStep(70);
					if (_0024ud_002420446.Config.VirtualPad)
					{
						_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:939", "call命令");
						_0024_0024s540_0024call_00242207_002420450 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
						_0024_0024s540_0024call_00242206_002420451 = _0024self__002420478.S540_tutorial_npc(string.Empty, "画面右側をタップすると攻撃だ！", TUTORIAL_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242206_002420451 != null)
						{
							_0024_0024iterator_002413900_002420471 = _0024_0024s540_0024call_00242206_002420451;
							goto case 5;
						}
						goto IL_0290;
					}
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:944", "call命令");
					_0024_0024s540_0024call_00242213_002420456 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242212_002420457 = _0024self__002420478.S540_tutorial_npc(string.Empty, "画面をタップすると自動で敵にロックオン。\nロックオン中にタップで攻撃だ！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242212_002420457 != null)
					{
						_0024_0024iterator_002413902_002420473 = _0024_0024s540_0024call_00242212_002420457;
						goto case 7;
					}
					goto IL_042b;
					IL_0689:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:950", "call命令");
					_0024_0024s540_0024call_00242225_002420468 = _0024self__002420478.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242224_002420469 = _0024self__002420478.S540_message_end();
					if (_0024_0024s540_0024call_00242224_002420469 != null)
					{
						_0024_0024iterator_002413906_002420477 = _0024_0024s540_0024call_00242224_002420469;
						goto case 11;
					}
					goto IL_073c;
					IL_0767:
					_0024self__002420478.stop(_0024_0024CUR_EXEC_0024_002420445);
					goto case 1;
					IL_04f1:
					if (_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto IL_050c;
					}
					goto case 1;
					IL_050c:
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialKaihiImage();
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:948", "call命令");
					_0024_0024s540_0024call_00242219_002420462 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242218_002420463 = _0024self__002420478.S540_tutorial_npc(string.Empty, "フリックすると、その方向に回避できるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242218_002420463 != null)
					{
						_0024_0024iterator_002413904_002420475 = _0024_0024s540_0024call_00242218_002420463;
						goto case 9;
					}
					goto IL_05c2;
					IL_05c2:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:949", "call命令");
					_0024_0024s540_0024call_00242222_002420465 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242221_002420466 = _0024self__002420478.S540_tutorial_npc(string.Empty, "回避は、ダウン中にも出すことができる。\n上手に使って、ピンチを切り抜けよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242221_002420466 != null)
					{
						_0024_0024iterator_002413905_002420476 = _0024_0024s540_0024call_00242221_002420466;
						goto case 10;
					}
					goto IL_0689;
					IL_0290:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialLockonImageVirtualPad();
					_0024self__002420478.dtrace(_0024_0024CUR_EXEC_0024_002420445, "TutorialEvent.boo:942", "call命令");
					_0024_0024s540_0024call_00242210_002420453 = _0024self__002420478.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420445);
					_0024_0024s540_0024call_00242209_002420454 = _0024self__002420478.S540_tutorial_npc(string.Empty, "ロックオンを切り替えたいときは\n二本指タップしよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242209_002420454 != null)
					{
						_0024_0024iterator_002413901_002420472 = _0024_0024s540_0024call_00242209_002420454;
						goto case 6;
					}
					goto IL_0360;
					IL_073c:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					MountainTutorialStep = 2;
					goto IL_0767;
					IL_0360:
					if (!_0024self__002420478.isExecuting(_0024_0024CUR_EXEC_0024_002420445))
					{
						goto case 1;
					}
					goto IL_050c;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420479;

		public _0024S540_tutorial_mountain_002_002420443(TutorialEvent self_)
		{
			_0024self__002420479 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420479);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_001_new_002420480 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242237_002420481;

			internal object _0024___item_002420482;

			internal IEnumerator _0024_0024iterator_002413907_002420483;

			internal TutorialEvent _0024self__002420484;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420484 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242237_002420481 = _0024self__002420484.S540_tutorial_mountain_001_new(null);
					if (_0024_0024s540_0024ycode_00242237_002420481 != null)
					{
						_0024_0024iterator_002413907_002420483 = _0024_0024s540_0024ycode_00242237_002420481;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413907_002420483.MoveNext())
					{
						_0024___item_002420482 = _0024_0024iterator_002413907_002420483.Current;
						result = (Yield(2, _0024___item_002420482) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420485;

		public _0024S540_tutorial_mountain_001_new_002420480(TutorialEvent self_)
		{
			_0024self__002420485 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420485);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_001_new_002420486 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420487;

			internal Exec _0024_0024CUR_EXEC_0024_002420488;

			internal PlayerControl _0024Player_002420489;

			internal IEnumerator _0024_0024sco_0024temp_00242228_002420490;

			internal float _0024_0024wait_sec_0024temp_00242229_002420491;

			internal Exec _0024_0024s540_0024call_00242232_002420492;

			internal IEnumerator _0024_0024s540_0024call_00242231_002420493;

			internal object _0024_0024s540_0024call_00242233_002420494;

			internal float _0024_0024wait_sec_0024temp_00242230_002420495;

			internal Exec _0024_0024s540_0024call_00242235_002420496;

			internal IEnumerator _0024_0024s540_0024call_00242234_002420497;

			internal object _0024_0024s540_0024call_00242236_002420498;

			internal IEnumerator _0024_0024iterator_002413908_002420499;

			internal IEnumerator _0024_0024iterator_002413909_002420500;

			internal TutorialEvent _0024self__002420501;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420501 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420487 = "S540_tutorial_mountain_001_new";
					_0024_0024CUR_EXEC_0024_002420488 = _0024self__002420501.lastCreatedExec;
					_0024Player_002420489 = null;
					goto IL_0057;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420488.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0057;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420488.NotExecuting)
					{
						goto IL_0107;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420488.NotExecuting)
					{
						goto IL_016c;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413908_002420499.MoveNext())
					{
						_0024_0024s540_0024call_00242233_002420494 = _0024_0024iterator_002413908_002420499.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242233_002420494) ? 1 : 0);
						break;
					}
					goto IL_0231;
				case 6:
					if (!_0024_0024CUR_EXEC_0024_002420488.NotExecuting)
					{
						goto IL_0277;
					}
					goto case 1;
				case 7:
					if (!_0024_0024CUR_EXEC_0024_002420488.NotExecuting)
					{
						goto IL_02dc;
					}
					goto case 1;
				case 8:
					if (_0024_0024iterator_002413909_002420500.MoveNext())
					{
						_0024_0024s540_0024call_00242236_002420498 = _0024_0024iterator_002413909_002420500.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242236_002420498) ? 1 : 0);
						break;
					}
					goto IL_038f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0057:
					_0024Player_002420489 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420489 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242228_002420490 = _0024self__002420501.revivePlayer(_0024Player_002420489);
					if (_0024_0024sco_0024temp_00242228_002420490 != null)
					{
						_0024self__002420501.StartCoroutine(_0024_0024sco_0024temp_00242228_002420490);
					}
					goto IL_0107;
					IL_0277:
					if (!(_0024Player_002420489 != null) || _0024Player_002420489.battleMode != PlayerControl.BATTLE_MODE.Non_Battle)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242230_002420495 = 0.5f;
					goto IL_02dc;
					IL_038f:
					if (!_0024self__002420501.isExecuting(_0024_0024CUR_EXEC_0024_002420488))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					MountainTutorialStep = 3;
					goto IL_03b5;
					IL_0107:
					if (!(_0024Player_002420489 != null) || _0024Player_002420489.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242229_002420491 = 0.5f;
					goto IL_016c;
					IL_0231:
					if (!_0024self__002420501.isExecuting(_0024_0024CUR_EXEC_0024_002420488))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_0277;
					IL_016c:
					if (_0024_0024wait_sec_0024temp_00242229_002420491 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242229_002420491 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (MountainTutorialStep == 2)
					{
						ScreenMask.Instance.activate();
						MerlinServer.NotifyTutorialStep(80);
						_0024self__002420501.dtrace(_0024_0024CUR_EXEC_0024_002420488, "TutorialEvent.boo:978", "call命令");
						_0024_0024s540_0024call_00242232_002420492 = _0024self__002420501.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420488);
						_0024_0024s540_0024call_00242231_002420493 = _0024self__002420501.S540_call_tutorials("TutorialMountain_001_WeaponSkill");
						if (_0024_0024s540_0024call_00242231_002420493 != null)
						{
							_0024_0024iterator_002413908_002420499 = _0024_0024s540_0024call_00242231_002420493;
							goto case 5;
						}
						goto IL_0231;
					}
					goto IL_03b5;
					IL_02dc:
					if (_0024_0024wait_sec_0024temp_00242230_002420495 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242230_002420495 -= Time.deltaTime;
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					_0024self__002420501.dtrace(_0024_0024CUR_EXEC_0024_002420488, "TutorialEvent.boo:986", "call命令");
					_0024_0024s540_0024call_00242235_002420496 = _0024self__002420501.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420488);
					_0024_0024s540_0024call_00242234_002420497 = _0024self__002420501.S540_call_tutorials("TutorialMountain_001_PlayerHPGauge");
					if (_0024_0024s540_0024call_00242234_002420497 != null)
					{
						_0024_0024iterator_002413909_002420500 = _0024_0024s540_0024call_00242234_002420497;
						goto case 8;
					}
					goto IL_038f;
					IL_03b5:
					TutorialUI.DestroyAllAssetBundleGameObject();
					_0024self__002420501.stop(_0024_0024CUR_EXEC_0024_002420488);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420502;

		public _0024S540_tutorial_mountain_001_new_002420486(TutorialEvent self_)
		{
			_0024self__002420502 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420502);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_001_002420503 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242262_002420504;

			internal object _0024___item_002420505;

			internal IEnumerator _0024_0024iterator_002413910_002420506;

			internal TutorialEvent _0024self__002420507;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420507 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242262_002420504 = _0024self__002420507.S540_tutorial_mountain_001(null);
					if (_0024_0024s540_0024ycode_00242262_002420504 != null)
					{
						_0024_0024iterator_002413910_002420506 = _0024_0024s540_0024ycode_00242262_002420504;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413910_002420506.MoveNext())
					{
						_0024___item_002420505 = _0024_0024iterator_002413910_002420506.Current;
						result = (Yield(2, _0024___item_002420505) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420508;

		public _0024S540_tutorial_mountain_001_002420503(TutorialEvent self_)
		{
			_0024self__002420508 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420508);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_001_002420509 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420510;

			internal Exec _0024_0024CUR_EXEC_0024_002420511;

			internal PlayerControl _0024Player_002420512;

			internal IEnumerator _0024_0024sco_0024temp_00242238_002420513;

			internal float _0024_0024wait_sec_0024temp_00242239_002420514;

			internal Exec _0024_0024s540_0024call_00242242_002420515;

			internal IEnumerator _0024_0024s540_0024call_00242241_002420516;

			internal object _0024_0024s540_0024call_00242243_002420517;

			internal Exec _0024_0024s540_0024call_00242245_002420518;

			internal IEnumerator _0024_0024s540_0024call_00242244_002420519;

			internal object _0024_0024s540_0024call_00242246_002420520;

			internal Exec _0024_0024s540_0024call_00242248_002420521;

			internal IEnumerator _0024_0024s540_0024call_00242247_002420522;

			internal object _0024_0024s540_0024call_00242249_002420523;

			internal Exec _0024_0024s540_0024call_00242251_002420524;

			internal IEnumerator _0024_0024s540_0024call_00242250_002420525;

			internal object _0024_0024s540_0024call_00242252_002420526;

			internal Exec _0024_0024s540_0024call_00242254_002420527;

			internal IEnumerator _0024_0024s540_0024call_00242253_002420528;

			internal object _0024_0024s540_0024call_00242255_002420529;

			internal float _0024_0024wait_sec_0024temp_00242240_002420530;

			internal Exec _0024_0024s540_0024call_00242257_002420531;

			internal IEnumerator _0024_0024s540_0024call_00242256_002420532;

			internal object _0024_0024s540_0024call_00242258_002420533;

			internal Exec _0024_0024s540_0024call_00242260_002420534;

			internal IEnumerator _0024_0024s540_0024call_00242259_002420535;

			internal object _0024_0024s540_0024call_00242261_002420536;

			internal IEnumerator _0024_0024iterator_002413911_002420537;

			internal IEnumerator _0024_0024iterator_002413912_002420538;

			internal IEnumerator _0024_0024iterator_002413913_002420539;

			internal IEnumerator _0024_0024iterator_002413914_002420540;

			internal IEnumerator _0024_0024iterator_002413915_002420541;

			internal IEnumerator _0024_0024iterator_002413916_002420542;

			internal IEnumerator _0024_0024iterator_002413917_002420543;

			internal TutorialEvent _0024self__002420544;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420544 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420510 = "S540_tutorial_mountain_001";
					_0024_0024CUR_EXEC_0024_002420511 = _0024self__002420544.lastCreatedExec;
					_0024Player_002420512 = null;
					goto IL_006b;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420511.NotExecuting)
					{
						goto case 1;
					}
					goto IL_006b;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420511.NotExecuting)
					{
						goto IL_011b;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420511.NotExecuting)
					{
						goto IL_0180;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413911_002420537.MoveNext())
					{
						_0024_0024s540_0024call_00242243_002420517 = _0024_0024iterator_002413911_002420537.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242243_002420517) ? 1 : 0);
						break;
					}
					goto IL_0259;
				case 6:
					if (_0024_0024iterator_002413912_002420538.MoveNext())
					{
						_0024_0024s540_0024call_00242246_002420520 = _0024_0024iterator_002413912_002420538.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242246_002420520) ? 1 : 0);
						break;
					}
					goto IL_0324;
				case 7:
					if (_0024_0024iterator_002413913_002420539.MoveNext())
					{
						_0024_0024s540_0024call_00242249_002420523 = _0024_0024iterator_002413913_002420539.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242249_002420523) ? 1 : 0);
						break;
					}
					goto IL_03ea;
				case 8:
					if (_0024_0024iterator_002413914_002420540.MoveNext())
					{
						_0024_0024s540_0024call_00242252_002420526 = _0024_0024iterator_002413914_002420540.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242252_002420526) ? 1 : 0);
						break;
					}
					goto IL_04ba;
				case 9:
					if (_0024_0024iterator_002413915_002420541.MoveNext())
					{
						_0024_0024s540_0024call_00242255_002420529 = _0024_0024iterator_002413915_002420541.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242255_002420529) ? 1 : 0);
						break;
					}
					goto IL_056d;
				case 10:
					if (!_0024_0024CUR_EXEC_0024_002420511.NotExecuting)
					{
						goto IL_05be;
					}
					goto case 1;
				case 11:
					if (!_0024_0024CUR_EXEC_0024_002420511.NotExecuting)
					{
						goto IL_0624;
					}
					goto case 1;
				case 12:
					if (_0024_0024iterator_002413916_002420542.MoveNext())
					{
						_0024_0024s540_0024call_00242258_002420533 = _0024_0024iterator_002413916_002420542.Current;
						result = (Yield(12, _0024_0024s540_0024call_00242258_002420533) ? 1 : 0);
						break;
					}
					goto IL_06ec;
				case 13:
					if (_0024_0024iterator_002413917_002420543.MoveNext())
					{
						_0024_0024s540_0024call_00242261_002420536 = _0024_0024iterator_002413917_002420543.Current;
						result = (Yield(13, _0024_0024s540_0024call_00242261_002420536) ? 1 : 0);
						break;
					}
					goto IL_079f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_006b:
					_0024Player_002420512 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420512 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242238_002420513 = _0024self__002420544.revivePlayer(_0024Player_002420512);
					if (_0024_0024sco_0024temp_00242238_002420513 != null)
					{
						_0024self__002420544.StartCoroutine(_0024_0024sco_0024temp_00242238_002420513);
					}
					goto IL_011b;
					IL_0624:
					if (_0024_0024wait_sec_0024temp_00242240_002420530 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242240_002420530 -= Time.deltaTime;
						result = (YieldDefault(11) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.DrawTutorialPlayerHPGaugeImage();
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1030", "call命令");
					_0024_0024s540_0024call_00242257_002420531 = _0024self__002420544.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242256_002420532 = _0024self__002420544.S540_tutorial_npc(string.Empty, "転身すると、敵から受けたダメージのうち\n赤色部（リカバリーダメージ）が回復する。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242256_002420532 != null)
					{
						_0024_0024iterator_002413916_002420542 = _0024_0024s540_0024call_00242256_002420532;
						goto case 12;
					}
					goto IL_06ec;
					IL_03ea:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialCoolDownImage();
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1018", "call命令");
					_0024_0024s540_0024call_00242251_002420524 = _0024self__002420544.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242250_002420525 = _0024self__002420544.S540_tutorial_npc(string.Empty, "武器スキルは、一度使うと\n一定時間使用できなくなるので注意！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242250_002420525 != null)
					{
						_0024_0024iterator_002413914_002420540 = _0024_0024s540_0024call_00242250_002420525;
						goto case 8;
					}
					goto IL_04ba;
					IL_011b:
					if (!(_0024Player_002420512 != null) || _0024Player_002420512.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242239_002420514 = 0.5f;
					goto IL_0180;
					IL_0180:
					if (_0024_0024wait_sec_0024temp_00242239_002420514 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242239_002420514 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if (MountainTutorialStep == 2)
					{
						ScreenMask.Instance.activate();
						BattleHUD.DrawTutorialWeaponSkillImage();
						MerlinServer.NotifyTutorialStep(80);
						_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1012", "call命令");
						_0024_0024s540_0024call_00242242_002420515 = _0024self__002420544.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420511);
						_0024_0024s540_0024call_00242241_002420516 = _0024self__002420544.S540_tutorial_npc(string.Empty, "武器は、天使と悪魔それぞれに装備可能だ。\n転身によって切り替わるぞ。", TUTORIAL_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242241_002420516 != null)
						{
							_0024_0024iterator_002413911_002420537 = _0024_0024s540_0024call_00242241_002420516;
							goto case 5;
						}
						goto IL_0259;
					}
					goto IL_07cf;
					IL_04ba:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1019", "call命令");
					_0024_0024s540_0024call_00242254_002420527 = _0024self__002420544.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242253_002420528 = _0024self__002420544.S540_message_end();
					if (_0024_0024s540_0024call_00242253_002420528 != null)
					{
						_0024_0024iterator_002413915_002420541 = _0024_0024s540_0024call_00242253_002420528;
						goto case 9;
					}
					goto IL_056d;
					IL_06ec:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1031", "call命令");
					_0024_0024s540_0024call_00242260_002420534 = _0024self__002420544.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242259_002420535 = _0024self__002420544.S540_message_end();
					if (_0024_0024s540_0024call_00242259_002420535 != null)
					{
						_0024_0024iterator_002413917_002420543 = _0024_0024s540_0024call_00242259_002420535;
						goto case 13;
					}
					goto IL_079f;
					IL_0259:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					BattleHUD.PointTutorialArrowToSkillButtons();
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1014", "call命令");
					_0024_0024s540_0024call_00242245_002420518 = _0024self__002420544.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242244_002420519 = _0024self__002420544.S540_tutorial_npc(string.Empty, "武器スキルアイコンをタップすると\n武器スキルが発動する！", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242244_002420519 != null)
					{
						_0024_0024iterator_002413912_002420538 = _0024_0024s540_0024call_00242244_002420519;
						goto case 6;
					}
					goto IL_0324;
					IL_056d:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DisableTutorialArrows();
					ScreenMask.deactivate();
					goto IL_05be;
					IL_07cf:
					_0024self__002420544.stop(_0024_0024CUR_EXEC_0024_002420511);
					goto case 1;
					IL_05be:
					if (!(_0024Player_002420512 != null) || _0024Player_002420512.battleMode != PlayerControl.BATTLE_MODE.Non_Battle)
					{
						result = (YieldDefault(10) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242240_002420530 = 0.5f;
					goto IL_0624;
					IL_0324:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					_0024self__002420544.dtrace(_0024_0024CUR_EXEC_0024_002420511, "TutorialEvent.boo:1015", "call命令");
					_0024_0024s540_0024call_00242248_002420521 = _0024self__002420544.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420511);
					_0024_0024s540_0024call_00242247_002420522 = _0024self__002420544.S540_tutorial_npc(string.Empty, "武器スキルの効果は、武器によって変わる。\nまた、天使か悪魔でも変わるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242247_002420522 != null)
					{
						_0024_0024iterator_002413913_002420539 = _0024_0024s540_0024call_00242247_002420522;
						goto case 7;
					}
					goto IL_03ea;
					IL_079f:
					if (!_0024self__002420544.isExecuting(_0024_0024CUR_EXEC_0024_002420511))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					MountainTutorialStep = 3;
					goto IL_07cf;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420545;

		public _0024S540_tutorial_mountain_001_002420509(TutorialEvent self_)
		{
			_0024self__002420545 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420545);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_007_new_002420546 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242274_002420547;

			internal object _0024___item_002420548;

			internal IEnumerator _0024_0024iterator_002413918_002420549;

			internal TutorialEvent _0024self__002420550;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420550 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242274_002420547 = _0024self__002420550.S540_tutorial_mountain_007_new(null);
					if (_0024_0024s540_0024ycode_00242274_002420547 != null)
					{
						_0024_0024iterator_002413918_002420549 = _0024_0024s540_0024ycode_00242274_002420547;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413918_002420549.MoveNext())
					{
						_0024___item_002420548 = _0024_0024iterator_002413918_002420549.Current;
						result = (Yield(2, _0024___item_002420548) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420551;

		public _0024S540_tutorial_mountain_007_new_002420546(TutorialEvent self_)
		{
			_0024self__002420551 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420551);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_007_new_002420552 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420553;

			internal Exec _0024_0024CUR_EXEC_0024_002420554;

			internal PlayerControl _0024Player_002420555;

			internal IEnumerator _0024_0024sco_0024temp_00242263_002420556;

			internal float _0024_0024wait_sec_0024temp_00242264_002420557;

			internal Exec _0024_0024s540_0024call_00242269_002420558;

			internal IEnumerator _0024_0024s540_0024call_00242268_002420559;

			internal object _0024_0024s540_0024call_00242270_002420560;

			internal float _0024_0024wait_sec_0024temp_00242265_002420561;

			internal bool _0024drawOnce_002420562;

			internal int _0024_0024s540_0024loop_00242267_002420563;

			internal float _0024_0024wait_sec_0024temp_00242266_002420564;

			internal Exec _0024_0024s540_0024call_00242272_002420565;

			internal IEnumerator _0024_0024s540_0024call_00242271_002420566;

			internal object _0024_0024s540_0024call_00242273_002420567;

			internal IEnumerator _0024_0024iterator_002413919_002420568;

			internal IEnumerator _0024_0024iterator_002413920_002420569;

			internal TutorialEvent _0024self__002420570;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420570 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420553 = "S540_tutorial_mountain_007_new";
					_0024_0024CUR_EXEC_0024_002420554 = _0024self__002420570.lastCreatedExec;
					_0024Player_002420555 = null;
					goto IL_005b;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto case 1;
					}
					goto IL_005b;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto IL_0116;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto IL_017b;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413919_002420568.MoveNext())
					{
						_0024_0024s540_0024call_00242270_002420560 = _0024_0024iterator_002413919_002420568.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242270_002420560) ? 1 : 0);
						break;
					}
					goto IL_0235;
				case 6:
					if (!_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto IL_029e;
					}
					goto case 1;
				case 7:
					if (!_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto IL_0358;
					}
					goto case 1;
				case 8:
					if (_0024_0024iterator_002413920_002420569.MoveNext())
					{
						_0024_0024s540_0024call_00242273_002420567 = _0024_0024iterator_002413920_002420569.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242273_002420567) ? 1 : 0);
						break;
					}
					goto IL_040b;
				case 9:
					if (_0024_0024CUR_EXEC_0024_002420554.NotExecuting)
					{
						goto case 1;
					}
					goto IL_02d2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005b:
					_0024Player_002420555 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420555 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242263_002420556 = _0024self__002420570.revivePlayer(_0024Player_002420555);
					if (_0024_0024sco_0024temp_00242263_002420556 != null)
					{
						_0024self__002420570.StartCoroutine(_0024_0024sco_0024temp_00242263_002420556);
					}
					if (MountainTutorialStep == 3)
					{
						goto IL_0116;
					}
					goto IL_025b;
					IL_029e:
					if (_0024_0024wait_sec_0024temp_00242265_002420561 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242265_002420561 -= Time.deltaTime;
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024drawOnce_002420562 = false;
					_0024self__002420570.dtrace(_0024_0024CUR_EXEC_0024_002420554, "TutorialEvent.boo:1078", "loop命令");
					goto IL_02d2;
					IL_025b:
					_0024_0024wait_sec_0024temp_00242265_002420561 = 0.1f;
					goto IL_029e;
					IL_0116:
					if (!(_0024Player_002420555 != null) || _0024Player_002420555.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242264_002420557 = 0.5f;
					goto IL_017b;
					IL_02d2:
					_0024_0024s540_0024loop_00242267_002420563 = Time.frameCount;
					if (!_0024drawOnce_002420562 && _0024Player_002420555 != null && (bool)_0024Player_002420555.TargetChar)
					{
						_0024drawOnce_002420562 = true;
						_0024_0024wait_sec_0024temp_00242266_002420564 = 0.1f;
						goto IL_0358;
					}
					goto IL_042b;
					IL_040b:
					if (!_0024self__002420570.isExecuting(_0024_0024CUR_EXEC_0024_002420554))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_042b;
					IL_017b:
					if (_0024_0024wait_sec_0024temp_00242264_002420557 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242264_002420557 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					MerlinServer.NotifyTutorialStep(90);
					_0024self__002420570.dtrace(_0024_0024CUR_EXEC_0024_002420554, "TutorialEvent.boo:1071", "call命令");
					_0024_0024s540_0024call_00242269_002420558 = _0024self__002420570.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420554);
					_0024_0024s540_0024call_00242268_002420559 = _0024self__002420570.S540_call_tutorials("TutorialMountain_007_PlayerElement");
					if (_0024_0024s540_0024call_00242268_002420559 != null)
					{
						_0024_0024iterator_002413919_002420568 = _0024_0024s540_0024call_00242268_002420559;
						goto case 5;
					}
					goto IL_0235;
					IL_0358:
					if (_0024_0024wait_sec_0024temp_00242266_002420564 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242266_002420564 -= Time.deltaTime;
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					_0024self__002420570.dtrace(_0024_0024CUR_EXEC_0024_002420554, "TutorialEvent.boo:1083", "call命令");
					_0024_0024s540_0024call_00242272_002420565 = _0024self__002420570.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420554);
					_0024_0024s540_0024call_00242271_002420566 = _0024self__002420570.S540_call_tutorials("TutorialMountain_007_EnemyElement");
					if (_0024_0024s540_0024call_00242271_002420566 != null)
					{
						_0024_0024iterator_002413920_002420569 = _0024_0024s540_0024call_00242271_002420566;
						goto case 8;
					}
					goto IL_040b;
					IL_042b:
					if (_0024_0024s540_0024loop_00242267_002420563 == Time.frameCount)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					goto case 9;
					IL_0235:
					if (!_0024self__002420570.isExecuting(_0024_0024CUR_EXEC_0024_002420554))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					MountainTutorialStep = 4;
					goto IL_025b;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420571;

		public _0024S540_tutorial_mountain_007_new_002420552(TutorialEvent self_)
		{
			_0024self__002420571 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420571);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_007_002420572 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242295_002420573;

			internal object _0024___item_002420574;

			internal IEnumerator _0024_0024iterator_002413921_002420575;

			internal TutorialEvent _0024self__002420576;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420576 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242295_002420573 = _0024self__002420576.S540_tutorial_mountain_007(null);
					if (_0024_0024s540_0024ycode_00242295_002420573 != null)
					{
						_0024_0024iterator_002413921_002420575 = _0024_0024s540_0024ycode_00242295_002420573;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413921_002420575.MoveNext())
					{
						_0024___item_002420574 = _0024_0024iterator_002413921_002420575.Current;
						result = (Yield(2, _0024___item_002420574) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420577;

		public _0024S540_tutorial_mountain_007_002420572(TutorialEvent self_)
		{
			_0024self__002420577 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420577);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_007_002420578 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420579;

			internal Exec _0024_0024CUR_EXEC_0024_002420580;

			internal PlayerControl _0024Player_002420581;

			internal IEnumerator _0024_0024sco_0024temp_00242275_002420582;

			internal float _0024_0024wait_sec_0024temp_00242276_002420583;

			internal Exec _0024_0024s540_0024call_00242281_002420584;

			internal IEnumerator _0024_0024s540_0024call_00242280_002420585;

			internal object _0024_0024s540_0024call_00242282_002420586;

			internal Exec _0024_0024s540_0024call_00242284_002420587;

			internal IEnumerator _0024_0024s540_0024call_00242283_002420588;

			internal object _0024_0024s540_0024call_00242285_002420589;

			internal float _0024_0024wait_sec_0024temp_00242277_002420590;

			internal bool _0024drawOnce_002420591;

			internal int _0024_0024s540_0024loop_00242279_002420592;

			internal float _0024_0024wait_sec_0024temp_00242278_002420593;

			internal Exec _0024_0024s540_0024call_00242287_002420594;

			internal IEnumerator _0024_0024s540_0024call_00242286_002420595;

			internal object _0024_0024s540_0024call_00242288_002420596;

			internal Exec _0024_0024s540_0024call_00242290_002420597;

			internal IEnumerator _0024_0024s540_0024call_00242289_002420598;

			internal object _0024_0024s540_0024call_00242291_002420599;

			internal Exec _0024_0024s540_0024call_00242293_002420600;

			internal IEnumerator _0024_0024s540_0024call_00242292_002420601;

			internal object _0024_0024s540_0024call_00242294_002420602;

			internal IEnumerator _0024_0024iterator_002413922_002420603;

			internal IEnumerator _0024_0024iterator_002413923_002420604;

			internal IEnumerator _0024_0024iterator_002413924_002420605;

			internal IEnumerator _0024_0024iterator_002413925_002420606;

			internal IEnumerator _0024_0024iterator_002413926_002420607;

			internal TutorialEvent _0024self__002420608;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420608 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420579 = "S540_tutorial_mountain_007";
					_0024_0024CUR_EXEC_0024_002420580 = _0024self__002420608.lastCreatedExec;
					_0024Player_002420581 = null;
					goto IL_0067;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0067;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto IL_0122;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto IL_0187;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413922_002420603.MoveNext())
					{
						_0024_0024s540_0024call_00242282_002420586 = _0024_0024iterator_002413922_002420603.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242282_002420586) ? 1 : 0);
						break;
					}
					goto IL_0255;
				case 6:
					if (_0024_0024iterator_002413923_002420604.MoveNext())
					{
						_0024_0024s540_0024call_00242285_002420589 = _0024_0024iterator_002413923_002420604.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242285_002420589) ? 1 : 0);
						break;
					}
					goto IL_0307;
				case 7:
					if (!_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto IL_0375;
					}
					goto case 1;
				case 8:
					if (!_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto IL_042f;
					}
					goto case 1;
				case 9:
					if (_0024_0024iterator_002413924_002420605.MoveNext())
					{
						_0024_0024s540_0024call_00242288_002420596 = _0024_0024iterator_002413924_002420605.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242288_002420596) ? 1 : 0);
						break;
					}
					goto IL_04f7;
				case 10:
					if (_0024_0024iterator_002413925_002420606.MoveNext())
					{
						_0024_0024s540_0024call_00242291_002420599 = _0024_0024iterator_002413925_002420606.Current;
						result = (Yield(10, _0024_0024s540_0024call_00242291_002420599) ? 1 : 0);
						break;
					}
					goto IL_05c8;
				case 11:
					if (_0024_0024iterator_002413926_002420607.MoveNext())
					{
						_0024_0024s540_0024call_00242294_002420602 = _0024_0024iterator_002413926_002420607.Current;
						result = (Yield(11, _0024_0024s540_0024call_00242294_002420602) ? 1 : 0);
						break;
					}
					goto IL_067b;
				case 12:
					if (_0024_0024CUR_EXEC_0024_002420580.NotExecuting)
					{
						goto case 1;
					}
					goto IL_03a9;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0067:
					_0024Player_002420581 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420581 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242275_002420582 = _0024self__002420608.revivePlayer(_0024Player_002420581);
					if (_0024_0024sco_0024temp_00242275_002420582 != null)
					{
						_0024self__002420608.StartCoroutine(_0024_0024sco_0024temp_00242275_002420582);
					}
					if (MountainTutorialStep == 3)
					{
						goto IL_0122;
					}
					goto IL_0332;
					IL_03a9:
					_0024_0024s540_0024loop_00242279_002420592 = Time.frameCount;
					if (!_0024drawOnce_002420591 && _0024Player_002420581 != null && (bool)_0024Player_002420581.TargetChar)
					{
						_0024drawOnce_002420591 = true;
						_0024_0024wait_sec_0024temp_00242278_002420593 = 0.1f;
						goto IL_042f;
					}
					goto IL_06a0;
					IL_0375:
					if (_0024_0024wait_sec_0024temp_00242277_002420590 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242277_002420590 -= Time.deltaTime;
						result = (YieldDefault(7) ? 1 : 0);
						break;
					}
					_0024drawOnce_002420591 = false;
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1117", "loop命令");
					goto IL_03a9;
					IL_0122:
					if (!(_0024Player_002420581 != null) || _0024Player_002420581.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242276_002420583 = 0.5f;
					goto IL_0187;
					IL_06a0:
					if (_0024_0024s540_0024loop_00242279_002420592 == Time.frameCount)
					{
						result = (YieldDefault(12) ? 1 : 0);
						break;
					}
					goto case 12;
					IL_05c8:
					if (!_0024self__002420608.isExecuting(_0024_0024CUR_EXEC_0024_002420580))
					{
						goto case 1;
					}
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1128", "call命令");
					_0024_0024s540_0024call_00242293_002420600 = _0024self__002420608.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420580);
					_0024_0024s540_0024call_00242292_002420601 = _0024self__002420608.S540_message_end();
					if (_0024_0024s540_0024call_00242292_002420601 != null)
					{
						_0024_0024iterator_002413926_002420607 = _0024_0024s540_0024call_00242292_002420601;
						goto case 11;
					}
					goto IL_067b;
					IL_0187:
					if (_0024_0024wait_sec_0024temp_00242276_002420583 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242276_002420583 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.PointTutorialArrowToPlayerElement();
					MerlinServer.NotifyTutorialStep(90);
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1108", "call命令");
					_0024_0024s540_0024call_00242281_002420584 = _0024self__002420608.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420580);
					_0024_0024s540_0024call_00242280_002420585 = _0024self__002420608.S540_tutorial_npc(string.Empty, "これは自分の属性を表している。\n属性は、武器によって変わるぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242280_002420585 != null)
					{
						_0024_0024iterator_002413922_002420603 = _0024_0024s540_0024call_00242280_002420585;
						goto case 5;
					}
					goto IL_0255;
					IL_0332:
					_0024_0024wait_sec_0024temp_00242277_002420590 = 0.1f;
					goto IL_0375;
					IL_0255:
					if (!_0024self__002420608.isExecuting(_0024_0024CUR_EXEC_0024_002420580))
					{
						goto case 1;
					}
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1109", "call命令");
					_0024_0024s540_0024call_00242284_002420587 = _0024self__002420608.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420580);
					_0024_0024s540_0024call_00242283_002420588 = _0024self__002420608.S540_message_end();
					if (_0024_0024s540_0024call_00242283_002420588 != null)
					{
						_0024_0024iterator_002413923_002420604 = _0024_0024s540_0024call_00242283_002420588;
						goto case 6;
					}
					goto IL_0307;
					IL_067b:
					if (!_0024self__002420608.isExecuting(_0024_0024CUR_EXEC_0024_002420580))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					goto IL_06a0;
					IL_04f7:
					if (!_0024self__002420608.isExecuting(_0024_0024CUR_EXEC_0024_002420580))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					BattleHUD.DrawTutorialElementImage();
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1127", "call命令");
					_0024_0024s540_0024call_00242290_002420597 = _0024self__002420608.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420580);
					_0024_0024s540_0024call_00242289_002420598 = _0024self__002420608.S540_tutorial_npc(string.Empty, "属性には、それぞれ有利・不利がある。\n関係性を把握しておこう。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242289_002420598 != null)
					{
						_0024_0024iterator_002413925_002420606 = _0024_0024s540_0024call_00242289_002420598;
						goto case 10;
					}
					goto IL_05c8;
					IL_0307:
					if (!_0024self__002420608.isExecuting(_0024_0024CUR_EXEC_0024_002420580))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialArrows();
					ScreenMask.deactivate();
					MountainTutorialStep = 4;
					goto IL_0332;
					IL_042f:
					if (_0024_0024wait_sec_0024temp_00242278_002420593 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242278_002420593 -= Time.deltaTime;
						result = (YieldDefault(8) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.PointTutorialArrowToEnemyElement();
					_0024self__002420608.dtrace(_0024_0024CUR_EXEC_0024_002420580, "TutorialEvent.boo:1123", "call命令");
					_0024_0024s540_0024call_00242287_002420594 = _0024self__002420608.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420580);
					_0024_0024s540_0024call_00242286_002420595 = _0024self__002420608.S540_tutorial_npc(string.Empty, "これはロックオンした敵の属性だ。", TOWN_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242286_002420595 != null)
					{
						_0024_0024iterator_002413924_002420605 = _0024_0024s540_0024call_00242286_002420595;
						goto case 9;
					}
					goto IL_04f7;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420609;

		public _0024S540_tutorial_mountain_007_002420578(TutorialEvent self_)
		{
			_0024self__002420609 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420609);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_005_new_002420610 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242302_002420611;

			internal object _0024___item_002420612;

			internal IEnumerator _0024_0024iterator_002413927_002420613;

			internal TutorialEvent _0024self__002420614;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420614 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242302_002420611 = _0024self__002420614.S540_tutorial_mountain_005_new(null);
					if (_0024_0024s540_0024ycode_00242302_002420611 != null)
					{
						_0024_0024iterator_002413927_002420613 = _0024_0024s540_0024ycode_00242302_002420611;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413927_002420613.MoveNext())
					{
						_0024___item_002420612 = _0024_0024iterator_002413927_002420613.Current;
						result = (Yield(2, _0024___item_002420612) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420615;

		public _0024S540_tutorial_mountain_005_new_002420610(TutorialEvent self_)
		{
			_0024self__002420615 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420615);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_005_new_002420616 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420617;

			internal Exec _0024_0024CUR_EXEC_0024_002420618;

			internal PlayerControl _0024Player_002420619;

			internal IEnumerator _0024_0024sco_0024temp_00242296_002420620;

			internal float _0024_0024wait_sec_0024temp_00242297_002420621;

			internal bool _0024drawABST_002420622;

			internal int _0024_0024s540_0024loop_00242298_002420623;

			internal AIControl _0024ai_002420624;

			internal Exec _0024_0024s540_0024call_00242300_002420625;

			internal IEnumerator _0024_0024s540_0024call_00242299_002420626;

			internal object _0024_0024s540_0024call_00242301_002420627;

			internal IEnumerator _0024_0024iterator_002413928_002420628;

			internal TutorialEvent _0024self__002420629;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420629 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420617 = "S540_tutorial_mountain_005_new";
					_0024_0024CUR_EXEC_0024_002420618 = _0024self__002420629.lastCreatedExec;
					_0024Player_002420619 = null;
					goto IL_004f;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420618.NotExecuting)
					{
						goto case 1;
					}
					goto IL_004f;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420618.NotExecuting)
					{
						goto IL_00ff;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420618.NotExecuting)
					{
						goto IL_0164;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413928_002420628.MoveNext())
					{
						_0024_0024s540_0024call_00242301_002420627 = _0024_0024iterator_002413928_002420628.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242301_002420627) ? 1 : 0);
						break;
					}
					goto IL_02c2;
				case 6:
					if (_0024_0024CUR_EXEC_0024_002420618.NotExecuting)
					{
						goto case 1;
					}
					goto IL_0198;
				case 1:
					{
						result = 0;
						break;
					}
					IL_004f:
					_0024Player_002420619 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420619 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242296_002420620 = _0024self__002420629.revivePlayer(_0024Player_002420619);
					if (_0024_0024sco_0024temp_00242296_002420620 != null)
					{
						_0024self__002420629.StartCoroutine(_0024_0024sco_0024temp_00242296_002420620);
					}
					goto IL_00ff;
					IL_02c2:
					if (!_0024self__002420629.isExecuting(_0024_0024CUR_EXEC_0024_002420618))
					{
						goto case 1;
					}
					ScreenMask.deactivate();
					goto IL_02e2;
					IL_02e2:
					if (_0024_0024s540_0024loop_00242298_002420623 == Time.frameCount)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto case 6;
					IL_00ff:
					if (!(_0024Player_002420619 != null) || _0024Player_002420619.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242297_002420621 = 0.5f;
					goto IL_0164;
					IL_0164:
					if (_0024_0024wait_sec_0024temp_00242297_002420621 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242297_002420621 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024drawABST_002420622 = false;
					_0024self__002420629.dtrace(_0024_0024CUR_EXEC_0024_002420618, "TutorialEvent.boo:1159", "loop命令");
					goto IL_0198;
					IL_0198:
					_0024_0024s540_0024loop_00242298_002420623 = Time.frameCount;
					if (_0024Player_002420619 != null && !_0024drawABST_002420622 && _0024Player_002420619.AbnormalStateControl.CurrentStates.Length > 0)
					{
						_0024ai_002420624 = (AIControl)UnityEngine.Object.FindObjectOfType(typeof(AIControl));
						if (_0024ai_002420624 != null && !_0024ai_002420624.IsDead)
						{
							_0024drawABST_002420622 = true;
							ScreenMask.Instance.activate();
							_0024self__002420629.dtrace(_0024_0024CUR_EXEC_0024_002420618, "TutorialEvent.boo:1165", "call命令");
							_0024_0024s540_0024call_00242300_002420625 = _0024self__002420629.createExec("S540_call_tutorials", _0024_0024CUR_EXEC_0024_002420618);
							_0024_0024s540_0024call_00242299_002420626 = _0024self__002420629.S540_call_tutorials("TutorialMountain_005_Abst");
							if (_0024_0024s540_0024call_00242299_002420626 != null)
							{
								_0024_0024iterator_002413928_002420628 = _0024_0024s540_0024call_00242299_002420626;
								goto case 5;
							}
							goto IL_02c2;
						}
					}
					goto IL_02e2;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420630;

		public _0024S540_tutorial_mountain_005_new_002420616(TutorialEvent self_)
		{
			_0024self__002420630 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420630);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_005_002420631 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242318_002420632;

			internal object _0024___item_002420633;

			internal IEnumerator _0024_0024iterator_002413929_002420634;

			internal TutorialEvent _0024self__002420635;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420635 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242318_002420632 = _0024self__002420635.S540_tutorial_mountain_005(null);
					if (_0024_0024s540_0024ycode_00242318_002420632 != null)
					{
						_0024_0024iterator_002413929_002420634 = _0024_0024s540_0024ycode_00242318_002420632;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413929_002420634.MoveNext())
					{
						_0024___item_002420633 = _0024_0024iterator_002413929_002420634.Current;
						result = (Yield(2, _0024___item_002420633) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420636;

		public _0024S540_tutorial_mountain_005_002420631(TutorialEvent self_)
		{
			_0024self__002420636 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420636);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_mountain_005_002420637 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420638;

			internal Exec _0024_0024CUR_EXEC_0024_002420639;

			internal PlayerControl _0024Player_002420640;

			internal IEnumerator _0024_0024sco_0024temp_00242303_002420641;

			internal float _0024_0024wait_sec_0024temp_00242304_002420642;

			internal bool _0024drawABST_002420643;

			internal int _0024_0024s540_0024loop_00242305_002420644;

			internal AIControl _0024ai_002420645;

			internal Exec _0024_0024s540_0024call_00242307_002420646;

			internal IEnumerator _0024_0024s540_0024call_00242306_002420647;

			internal object _0024_0024s540_0024call_00242308_002420648;

			internal Exec _0024_0024s540_0024call_00242310_002420649;

			internal IEnumerator _0024_0024s540_0024call_00242309_002420650;

			internal object _0024_0024s540_0024call_00242311_002420651;

			internal Exec _0024_0024s540_0024call_00242313_002420652;

			internal IEnumerator _0024_0024s540_0024call_00242312_002420653;

			internal object _0024_0024s540_0024call_00242314_002420654;

			internal Exec _0024_0024s540_0024call_00242316_002420655;

			internal IEnumerator _0024_0024s540_0024call_00242315_002420656;

			internal object _0024_0024s540_0024call_00242317_002420657;

			internal IEnumerator _0024_0024iterator_002413930_002420658;

			internal IEnumerator _0024_0024iterator_002413931_002420659;

			internal IEnumerator _0024_0024iterator_002413932_002420660;

			internal IEnumerator _0024_0024iterator_002413933_002420661;

			internal TutorialEvent _0024self__002420662;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420662 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420638 = "S540_tutorial_mountain_005";
					_0024_0024CUR_EXEC_0024_002420639 = _0024self__002420662.lastCreatedExec;
					_0024Player_002420640 = null;
					goto IL_005b;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420639.NotExecuting)
					{
						goto case 1;
					}
					goto IL_005b;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420639.NotExecuting)
					{
						goto IL_010b;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420639.NotExecuting)
					{
						goto IL_0170;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413930_002420658.MoveNext())
					{
						_0024_0024s540_0024call_00242308_002420648 = _0024_0024iterator_002413930_002420658.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242308_002420648) ? 1 : 0);
						break;
					}
					goto IL_02e2;
				case 6:
					if (_0024_0024iterator_002413931_002420659.MoveNext())
					{
						_0024_0024s540_0024call_00242311_002420651 = _0024_0024iterator_002413931_002420659.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242311_002420651) ? 1 : 0);
						break;
					}
					goto IL_03a8;
				case 7:
					if (_0024_0024iterator_002413932_002420660.MoveNext())
					{
						_0024_0024s540_0024call_00242314_002420654 = _0024_0024iterator_002413932_002420660.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242314_002420654) ? 1 : 0);
						break;
					}
					goto IL_046e;
				case 8:
					if (_0024_0024iterator_002413933_002420661.MoveNext())
					{
						_0024_0024s540_0024call_00242317_002420657 = _0024_0024iterator_002413933_002420661.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242317_002420657) ? 1 : 0);
						break;
					}
					goto IL_0520;
				case 9:
					if (_0024_0024CUR_EXEC_0024_002420639.NotExecuting)
					{
						goto case 1;
					}
					goto IL_01a4;
				case 1:
					{
						result = 0;
						break;
					}
					IL_005b:
					_0024Player_002420640 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (!(_0024Player_002420640 != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024_0024sco_0024temp_00242303_002420641 = _0024self__002420662.revivePlayer(_0024Player_002420640);
					if (_0024_0024sco_0024temp_00242303_002420641 != null)
					{
						_0024self__002420662.StartCoroutine(_0024_0024sco_0024temp_00242303_002420641);
					}
					goto IL_010b;
					IL_02e2:
					if (!_0024self__002420662.isExecuting(_0024_0024CUR_EXEC_0024_002420639))
					{
						goto case 1;
					}
					_0024self__002420662.dtrace(_0024_0024CUR_EXEC_0024_002420639, "TutorialEvent.boo:1192", "call命令");
					_0024_0024s540_0024call_00242310_002420649 = _0024self__002420662.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420639);
					_0024_0024s540_0024call_00242309_002420650 = _0024self__002420662.S540_tutorial_npc(string.Empty, "状態異常の効果は\n自分のＨＰゲージの上に表示される。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242309_002420650 != null)
					{
						_0024_0024iterator_002413931_002420659 = _0024_0024s540_0024call_00242309_002420650;
						goto case 6;
					}
					goto IL_03a8;
					IL_010b:
					if (!(_0024Player_002420640 != null) || _0024Player_002420640.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242304_002420642 = 0.5f;
					goto IL_0170;
					IL_03a8:
					if (!_0024self__002420662.isExecuting(_0024_0024CUR_EXEC_0024_002420639))
					{
						goto case 1;
					}
					_0024self__002420662.dtrace(_0024_0024CUR_EXEC_0024_002420639, "TutorialEvent.boo:1193", "call命令");
					_0024_0024s540_0024call_00242313_002420652 = _0024self__002420662.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420639);
					_0024_0024s540_0024call_00242312_002420653 = _0024self__002420662.S540_tutorial_npc(string.Empty, "状態異常の効果は、一定時間経過するか\n戦闘終了で消える。冷静に対処しよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242312_002420653 != null)
					{
						_0024_0024iterator_002413932_002420660 = _0024_0024s540_0024call_00242312_002420653;
						goto case 7;
					}
					goto IL_046e;
					IL_0170:
					if (_0024_0024wait_sec_0024temp_00242304_002420642 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242304_002420642 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024drawABST_002420643 = false;
					_0024self__002420662.dtrace(_0024_0024CUR_EXEC_0024_002420639, "TutorialEvent.boo:1184", "loop命令");
					goto IL_01a4;
					IL_0520:
					if (!_0024self__002420662.isExecuting(_0024_0024CUR_EXEC_0024_002420639))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					ScreenMask.deactivate();
					goto IL_0545;
					IL_01a4:
					_0024_0024s540_0024loop_00242305_002420644 = Time.frameCount;
					if (_0024Player_002420640 != null && !_0024drawABST_002420643 && _0024Player_002420640.AbnormalStateControl.CurrentStates.Length > 0)
					{
						_0024ai_002420645 = (AIControl)UnityEngine.Object.FindObjectOfType(typeof(AIControl));
						if (_0024ai_002420645 != null && !_0024ai_002420645.IsDead)
						{
							_0024drawABST_002420643 = true;
							ScreenMask.Instance.activate();
							BattleHUD.DrawTutorialAbstImage();
							_0024self__002420662.dtrace(_0024_0024CUR_EXEC_0024_002420639, "TutorialEvent.boo:1191", "call命令");
							_0024_0024s540_0024call_00242307_002420646 = _0024self__002420662.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420639);
							_0024_0024s540_0024call_00242306_002420647 = _0024self__002420662.S540_tutorial_npc(string.Empty, "敵の攻撃には\n状態異常を引き起こすものがあるぞ。", TUTORIAL_WINDOW_TYPE);
							if (_0024_0024s540_0024call_00242306_002420647 != null)
							{
								_0024_0024iterator_002413930_002420658 = _0024_0024s540_0024call_00242306_002420647;
								goto case 5;
							}
							goto IL_02e2;
						}
					}
					goto IL_0545;
					IL_0545:
					if (_0024_0024s540_0024loop_00242305_002420644 == Time.frameCount)
					{
						result = (YieldDefault(9) ? 1 : 0);
						break;
					}
					goto case 9;
					IL_046e:
					if (!_0024self__002420662.isExecuting(_0024_0024CUR_EXEC_0024_002420639))
					{
						goto case 1;
					}
					_0024self__002420662.dtrace(_0024_0024CUR_EXEC_0024_002420639, "TutorialEvent.boo:1194", "call命令");
					_0024_0024s540_0024call_00242316_002420655 = _0024self__002420662.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420639);
					_0024_0024s540_0024call_00242315_002420656 = _0024self__002420662.S540_message_end();
					if (_0024_0024s540_0024call_00242315_002420656 != null)
					{
						_0024_0024iterator_002413933_002420661 = _0024_0024s540_0024call_00242315_002420656;
						goto case 8;
					}
					goto IL_0520;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420663;

		public _0024S540_tutorial_mountain_005_002420637(TutorialEvent self_)
		{
			_0024self__002420663 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420663);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_cave_006_002420664 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242329_002420665;

			internal object _0024___item_002420666;

			internal IEnumerator _0024_0024iterator_002413934_002420667;

			internal TutorialEvent _0024self__002420668;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420668 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242329_002420665 = _0024self__002420668.S540_tutorial_cave_006(null);
					if (_0024_0024s540_0024ycode_00242329_002420665 != null)
					{
						_0024_0024iterator_002413934_002420667 = _0024_0024s540_0024ycode_00242329_002420665;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413934_002420667.MoveNext())
					{
						_0024___item_002420666 = _0024_0024iterator_002413934_002420667.Current;
						result = (Yield(2, _0024___item_002420666) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420669;

		public _0024S540_tutorial_cave_006_002420664(TutorialEvent self_)
		{
			_0024self__002420669 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420669);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_cave_006_002420670 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420671;

			internal Exec _0024_0024CUR_EXEC_0024_002420672;

			internal UserData _0024ud_002420673;

			internal bool _0024flagID_002420674;

			internal PlayerControl _0024Player_002420675;

			internal float _0024_0024wait_sec_0024temp_00242319_002420676;

			internal Exec _0024_0024s540_0024call_00242321_002420677;

			internal IEnumerator _0024_0024s540_0024call_00242320_002420678;

			internal object _0024_0024s540_0024call_00242322_002420679;

			internal Exec _0024_0024s540_0024call_00242324_002420680;

			internal IEnumerator _0024_0024s540_0024call_00242323_002420681;

			internal object _0024_0024s540_0024call_00242325_002420682;

			internal Exec _0024_0024s540_0024call_00242327_002420683;

			internal IEnumerator _0024_0024s540_0024call_00242326_002420684;

			internal object _0024_0024s540_0024call_00242328_002420685;

			internal IEnumerator _0024_0024iterator_002413935_002420686;

			internal IEnumerator _0024_0024iterator_002413936_002420687;

			internal IEnumerator _0024_0024iterator_002413937_002420688;

			internal TutorialEvent _0024self__002420689;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420689 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420671 = "S540_tutorial_cave_006";
					_0024_0024CUR_EXEC_0024_002420672 = _0024self__002420689.lastCreatedExec;
					_0024ud_002420673 = UserData.Current;
					if (_0024ud_002420673 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024flagID_002420674 = _0024ud_002420673.hasFlag("s01Main001Tuto");
					if (_0024flagID_002420674)
					{
						_0024self__002420689.stop(_0024_0024CUR_EXEC_0024_002420672);
						goto case 1;
					}
					_0024Player_002420675 = null;
					goto IL_00ac;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420672.NotExecuting)
					{
						goto case 1;
					}
					goto IL_00ac;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420672.NotExecuting)
					{
						goto IL_0128;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420672.NotExecuting)
					{
						goto IL_018d;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413935_002420686.MoveNext())
					{
						_0024_0024s540_0024call_00242322_002420679 = _0024_0024iterator_002413935_002420686.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242322_002420679) ? 1 : 0);
						break;
					}
					goto IL_0254;
				case 6:
					if (_0024_0024iterator_002413936_002420687.MoveNext())
					{
						_0024_0024s540_0024call_00242325_002420682 = _0024_0024iterator_002413936_002420687.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242325_002420682) ? 1 : 0);
						break;
					}
					goto IL_031a;
				case 7:
					if (_0024_0024iterator_002413937_002420688.MoveNext())
					{
						_0024_0024s540_0024call_00242328_002420685 = _0024_0024iterator_002413937_002420688.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242328_002420685) ? 1 : 0);
						break;
					}
					goto IL_03cc;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0254:
					if (!_0024self__002420689.isExecuting(_0024_0024CUR_EXEC_0024_002420672))
					{
						goto case 1;
					}
					_0024self__002420689.dtrace(_0024_0024CUR_EXEC_0024_002420672, "TutorialEvent.boo:1220", "call命令");
					_0024_0024s540_0024call_00242324_002420680 = _0024self__002420689.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420672);
					_0024_0024s540_0024call_00242323_002420681 = _0024self__002420689.S540_tutorial_npc(string.Empty, "連れていくだけで効果のある援護スキルや\n強力な連携スキルを持っているぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242323_002420681 != null)
					{
						_0024_0024iterator_002413936_002420687 = _0024_0024s540_0024call_00242323_002420681;
						goto case 6;
					}
					goto IL_031a;
					IL_00ac:
					_0024Player_002420675 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024Player_002420675 != null)
					{
						goto IL_0128;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
					IL_0128:
					if (!(_0024Player_002420675 != null) || _0024Player_002420675.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242319_002420676 = 0.5f;
					goto IL_018d;
					IL_03cc:
					if (_0024self__002420689.isExecuting(_0024_0024CUR_EXEC_0024_002420672))
					{
						BattleHUD.DisableTutorialImages();
						ScreenMask.deactivate();
						_0024self__002420689.stop(_0024_0024CUR_EXEC_0024_002420672);
					}
					goto case 1;
					IL_018d:
					if (_0024_0024wait_sec_0024temp_00242319_002420676 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242319_002420676 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.DrawTutorialPoppetImage();
					_0024self__002420689.dtrace(_0024_0024CUR_EXEC_0024_002420672, "TutorialEvent.boo:1219", "call命令");
					_0024_0024s540_0024call_00242321_002420677 = _0024self__002420689.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420672);
					_0024_0024s540_0024call_00242320_002420678 = _0024self__002420689.S540_tutorial_npc(string.Empty, "魔ペットは、使い魔の魂を宿した\nモンスター型のぬいぐるみだ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242320_002420678 != null)
					{
						_0024_0024iterator_002413935_002420686 = _0024_0024s540_0024call_00242320_002420678;
						goto case 5;
					}
					goto IL_0254;
					IL_031a:
					if (!_0024self__002420689.isExecuting(_0024_0024CUR_EXEC_0024_002420672))
					{
						goto case 1;
					}
					_0024self__002420689.dtrace(_0024_0024CUR_EXEC_0024_002420672, "TutorialEvent.boo:1221", "call命令");
					_0024_0024s540_0024call_00242327_002420683 = _0024self__002420689.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420672);
					_0024_0024s540_0024call_00242326_002420684 = _0024self__002420689.S540_message_end();
					if (_0024_0024s540_0024call_00242326_002420684 != null)
					{
						_0024_0024iterator_002413937_002420688 = _0024_0024s540_0024call_00242326_002420684;
						goto case 7;
					}
					goto IL_03cc;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420690;

		public _0024S540_tutorial_cave_006_002420670(TutorialEvent self_)
		{
			_0024self__002420690 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420690);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_cave_009_002420691 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242346_002420692;

			internal object _0024___item_002420693;

			internal IEnumerator _0024_0024iterator_002413938_002420694;

			internal TutorialEvent _0024self__002420695;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420695 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242346_002420692 = _0024self__002420695.S540_tutorial_cave_009(null);
					if (_0024_0024s540_0024ycode_00242346_002420692 != null)
					{
						_0024_0024iterator_002413938_002420694 = _0024_0024s540_0024ycode_00242346_002420692;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413938_002420694.MoveNext())
					{
						_0024___item_002420693 = _0024_0024iterator_002413938_002420694.Current;
						result = (Yield(2, _0024___item_002420693) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420696;

		public _0024S540_tutorial_cave_009_002420691(TutorialEvent self_)
		{
			_0024self__002420696 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420696);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_cave_009_002420697 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420698;

			internal Exec _0024_0024CUR_EXEC_0024_002420699;

			internal UserData _0024ud_002420700;

			internal bool _0024flagID_002420701;

			internal PlayerControl _0024Player_002420702;

			internal float _0024_0024wait_sec_0024temp_00242330_002420703;

			internal Exec _0024_0024s540_0024call_00242332_002420704;

			internal IEnumerator _0024_0024s540_0024call_00242331_002420705;

			internal object _0024_0024s540_0024call_00242333_002420706;

			internal Exec _0024_0024s540_0024call_00242335_002420707;

			internal IEnumerator _0024_0024s540_0024call_00242334_002420708;

			internal object _0024_0024s540_0024call_00242336_002420709;

			internal Exec _0024_0024s540_0024call_00242338_002420710;

			internal IEnumerator _0024_0024s540_0024call_00242337_002420711;

			internal object _0024_0024s540_0024call_00242339_002420712;

			internal Exec _0024_0024s540_0024call_00242341_002420713;

			internal IEnumerator _0024_0024s540_0024call_00242340_002420714;

			internal object _0024_0024s540_0024call_00242342_002420715;

			internal Exec _0024_0024s540_0024call_00242344_002420716;

			internal IEnumerator _0024_0024s540_0024call_00242343_002420717;

			internal object _0024_0024s540_0024call_00242345_002420718;

			internal IEnumerator _0024_0024iterator_002413939_002420719;

			internal IEnumerator _0024_0024iterator_002413940_002420720;

			internal IEnumerator _0024_0024iterator_002413941_002420721;

			internal IEnumerator _0024_0024iterator_002413942_002420722;

			internal IEnumerator _0024_0024iterator_002413943_002420723;

			internal TutorialEvent _0024self__002420724;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420724 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002420698 = "S540_tutorial_cave_009";
					_0024_0024CUR_EXEC_0024_002420699 = _0024self__002420724.lastCreatedExec;
					_0024ud_002420700 = UserData.Current;
					if (_0024ud_002420700 == null)
					{
						throw new AssertionFailedException("ud != null");
					}
					_0024flagID_002420701 = _0024ud_002420700.hasFlag("s01Main001Tuto");
					if (_0024flagID_002420701)
					{
						_0024self__002420724.stop(_0024_0024CUR_EXEC_0024_002420699);
						goto case 1;
					}
					_0024ud_002420700.setFlag("s01Main001Tuto");
					_0024Player_002420702 = null;
					goto IL_00c4;
				case 2:
					if (_0024_0024CUR_EXEC_0024_002420699.NotExecuting)
					{
						goto case 1;
					}
					goto IL_00c4;
				case 3:
					if (!_0024_0024CUR_EXEC_0024_002420699.NotExecuting)
					{
						goto IL_0140;
					}
					goto case 1;
				case 4:
					if (!_0024_0024CUR_EXEC_0024_002420699.NotExecuting)
					{
						goto IL_01a5;
					}
					goto case 1;
				case 5:
					if (_0024_0024iterator_002413939_002420719.MoveNext())
					{
						_0024_0024s540_0024call_00242333_002420706 = _0024_0024iterator_002413939_002420719.Current;
						result = (Yield(5, _0024_0024s540_0024call_00242333_002420706) ? 1 : 0);
						break;
					}
					goto IL_0271;
				case 6:
					if (_0024_0024iterator_002413940_002420720.MoveNext())
					{
						_0024_0024s540_0024call_00242336_002420709 = _0024_0024iterator_002413940_002420720.Current;
						result = (Yield(6, _0024_0024s540_0024call_00242336_002420709) ? 1 : 0);
						break;
					}
					goto IL_0337;
				case 7:
					if (_0024_0024iterator_002413941_002420721.MoveNext())
					{
						_0024_0024s540_0024call_00242339_002420712 = _0024_0024iterator_002413941_002420721.Current;
						result = (Yield(7, _0024_0024s540_0024call_00242339_002420712) ? 1 : 0);
						break;
					}
					goto IL_03fd;
				case 8:
					if (_0024_0024iterator_002413942_002420722.MoveNext())
					{
						_0024_0024s540_0024call_00242342_002420715 = _0024_0024iterator_002413942_002420722.Current;
						result = (Yield(8, _0024_0024s540_0024call_00242342_002420715) ? 1 : 0);
						break;
					}
					goto IL_04cd;
				case 9:
					if (_0024_0024iterator_002413943_002420723.MoveNext())
					{
						_0024_0024s540_0024call_00242345_002420718 = _0024_0024iterator_002413943_002420723.Current;
						result = (Yield(9, _0024_0024s540_0024call_00242345_002420718) ? 1 : 0);
						break;
					}
					goto IL_0580;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03fd:
					if (!_0024self__002420724.isExecuting(_0024_0024CUR_EXEC_0024_002420699))
					{
						goto case 1;
					}
					BattleHUD.DisableTutorialImages();
					BattleHUD.DrawTutorialChainSkillImage();
					_0024self__002420724.dtrace(_0024_0024CUR_EXEC_0024_002420699, "TutorialEvent.boo:1247", "call命令");
					_0024_0024s540_0024call_00242341_002420713 = _0024self__002420724.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420699);
					_0024_0024s540_0024call_00242340_002420714 = _0024self__002420724.S540_tutorial_npc(string.Empty, "連携スキルの効果は、魔ペットごとに違う。\nいろいろ連れてきて試してみよう。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242340_002420714 != null)
					{
						_0024_0024iterator_002413942_002420722 = _0024_0024s540_0024call_00242340_002420714;
						goto case 8;
					}
					goto IL_04cd;
					IL_04cd:
					if (!_0024self__002420724.isExecuting(_0024_0024CUR_EXEC_0024_002420699))
					{
						goto case 1;
					}
					_0024self__002420724.dtrace(_0024_0024CUR_EXEC_0024_002420699, "TutorialEvent.boo:1248", "call命令");
					_0024_0024s540_0024call_00242344_002420716 = _0024self__002420724.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420699);
					_0024_0024s540_0024call_00242343_002420717 = _0024self__002420724.S540_message_end();
					if (_0024_0024s540_0024call_00242343_002420717 != null)
					{
						_0024_0024iterator_002413943_002420723 = _0024_0024s540_0024call_00242343_002420717;
						goto case 9;
					}
					goto IL_0580;
					IL_00c4:
					_0024Player_002420702 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024Player_002420702 != null)
					{
						goto IL_0140;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
					IL_0140:
					if (!(_0024Player_002420702 != null) || _0024Player_002420702.battleMode != 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242330_002420703 = 0.5f;
					goto IL_01a5;
					IL_0337:
					if (!_0024self__002420724.isExecuting(_0024_0024CUR_EXEC_0024_002420699))
					{
						goto case 1;
					}
					_0024self__002420724.dtrace(_0024_0024CUR_EXEC_0024_002420699, "TutorialEvent.boo:1244", "call命令");
					_0024_0024s540_0024call_00242338_002420710 = _0024self__002420724.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420699);
					_0024_0024s540_0024call_00242337_002420711 = _0024self__002420724.S540_tutorial_npc(string.Empty, "魔力がいっぱいのとき、魔ペットアイコンを\nタップすると、連携スキルが発動する。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242337_002420711 != null)
					{
						_0024_0024iterator_002413941_002420721 = _0024_0024s540_0024call_00242337_002420711;
						goto case 7;
					}
					goto IL_03fd;
					IL_01a5:
					if (_0024_0024wait_sec_0024temp_00242330_002420703 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242330_002420703 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					ScreenMask.Instance.activate();
					BattleHUD.PointTutorialArrowToMapetButton();
					BattleHUD.DrawTutorialMagicGaugeImage();
					_0024self__002420724.dtrace(_0024_0024CUR_EXEC_0024_002420699, "TutorialEvent.boo:1242", "call命令");
					_0024_0024s540_0024call_00242332_002420704 = _0024self__002420724.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420699);
					_0024_0024s540_0024call_00242331_002420705 = _0024self__002420724.S540_tutorial_npc(string.Empty, "左下の魔ペットアイコンは\n魔ペットの魔力の状態を表している。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242331_002420705 != null)
					{
						_0024_0024iterator_002413939_002420719 = _0024_0024s540_0024call_00242331_002420705;
						goto case 5;
					}
					goto IL_0271;
					IL_0580:
					if (_0024self__002420724.isExecuting(_0024_0024CUR_EXEC_0024_002420699))
					{
						if ((bool)_0024Player_002420702)
						{
							_0024Player_002420702.addMagicPointRate(1f);
						}
						BattleHUD.DisableTutorialImages();
						BattleHUD.DisableTutorialArrows();
						ScreenMask.deactivate();
						_0024self__002420724.stop(_0024_0024CUR_EXEC_0024_002420699);
					}
					goto case 1;
					IL_0271:
					if (!_0024self__002420724.isExecuting(_0024_0024CUR_EXEC_0024_002420699))
					{
						goto case 1;
					}
					_0024self__002420724.dtrace(_0024_0024CUR_EXEC_0024_002420699, "TutorialEvent.boo:1243", "call命令");
					_0024_0024s540_0024call_00242335_002420707 = _0024self__002420724.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420699);
					_0024_0024s540_0024call_00242334_002420708 = _0024self__002420724.S540_tutorial_npc(string.Empty, "魔力は、敵に攻撃を当てたり\n敵からダメージを受けると溜まっていくぞ。", TUTORIAL_WINDOW_TYPE);
					if (_0024_0024s540_0024call_00242334_002420708 != null)
					{
						_0024_0024iterator_002413940_002420720 = _0024_0024s540_0024call_00242334_002420708;
						goto case 6;
					}
					goto IL_0337;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002420725;

		public _0024S540_tutorial_cave_009_002420697(TutorialEvent self_)
		{
			_0024self__002420725 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420725);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_raid_story003_002420726 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242395_002420727;

			internal object _0024___item_002420728;

			internal IEnumerator _0024_0024iterator_002413944_002420729;

			internal TutorialEvent _0024self__002420730;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420730 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242395_002420727 = _0024self__002420730.S540_tutorial_raid_story003(null);
					if (_0024_0024s540_0024ycode_00242395_002420727 != null)
					{
						_0024_0024iterator_002413944_002420729 = _0024_0024s540_0024ycode_00242395_002420727;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413944_002420729.MoveNext())
					{
						_0024___item_002420728 = _0024_0024iterator_002413944_002420729.Current;
						result = (Yield(2, _0024___item_002420728) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420731;

		public _0024S540_tutorial_raid_story003_002420726(TutorialEvent self_)
		{
			_0024self__002420731 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420731);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_raid_story003_002420732 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420733;

			internal Exec _0024_0024CUR_EXEC_0024_002420734;

			internal PlayerControl _0024Player_002420735;

			internal IEnumerator _0024_0024sco_0024temp_00242347_002420736;

			internal AIControl _0024boss_002420737;

			internal CameraControl _0024cc_002420738;

			internal RaidCamera _0024rc_002420739;

			internal GameObject[] _0024npcPrefabs_002420740;

			internal GameObject[] _0024npcObj_002420741;

			internal Exec _0024_0024s540_0024call_00242354_002420742;

			internal IEnumerator _0024_0024s540_0024call_00242353_002420743;

			internal object _0024_0024s540_0024call_00242355_002420744;

			internal Exec _0024_0024s540_0024call_00242357_002420745;

			internal IEnumerator _0024_0024s540_0024call_00242356_002420746;

			internal object _0024_0024s540_0024call_00242358_002420747;

			internal Exec _0024_0024s540_0024call_00242360_002420748;

			internal IEnumerator _0024_0024s540_0024call_00242359_002420749;

			internal object _0024_0024s540_0024call_00242361_002420750;

			internal Exec _0024_0024s540_0024call_00242363_002420751;

			internal IEnumerator _0024_0024s540_0024call_00242362_002420752;

			internal object _0024_0024s540_0024call_00242364_002420753;

			internal Exec _0024_0024s540_0024call_00242366_002420754;

			internal IEnumerator _0024_0024s540_0024call_00242365_002420755;

			internal object _0024_0024s540_0024call_00242367_002420756;

			internal Exec _0024_0024s540_0024call_00242369_002420757;

			internal IEnumerator _0024_0024s540_0024call_00242368_002420758;

			internal object _0024_0024s540_0024call_00242370_002420759;

			internal float _0024_0024wait_sec_0024temp_00242348_002420760;

			internal GameObject _0024npc_002420761;

			internal AIControl _0024ai_002420762;

			internal Exec _0024_0024s540_0024call_00242372_002420763;

			internal IEnumerator _0024_0024s540_0024call_00242371_002420764;

			internal object _0024_0024s540_0024call_00242373_002420765;

			internal Exec _0024_0024s540_0024call_00242375_002420766;

			internal IEnumerator _0024_0024s540_0024call_00242374_002420767;

			internal object _0024_0024s540_0024call_00242376_002420768;

			internal Exec _0024_0024s540_0024call_00242378_002420769;

			internal IEnumerator _0024_0024s540_0024call_00242377_002420770;

			internal object _0024_0024s540_0024call_00242379_002420771;

			internal int _0024recoveryHP_002420772;

			internal Exec _0024_0024s540_0024call_00242381_002420773;

			internal IEnumerator _0024_0024s540_0024call_00242380_002420774;

			internal object _0024_0024s540_0024call_00242382_002420775;

			internal float _0024_0024wait_sec_0024temp_00242349_002420776;

			internal GameObject _0024npc_002420777;

			internal Exec _0024_0024s540_0024call_00242384_002420778;

			internal IEnumerator _0024_0024s540_0024call_00242383_002420779;

			internal object _0024_0024s540_0024call_00242385_002420780;

			internal float _0024_0024wait_sec_0024temp_00242350_002420781;

			internal GameObject _0024npc_002420782;

			internal Exec _0024_0024s540_0024call_00242387_002420783;

			internal IEnumerator _0024_0024s540_0024call_00242386_002420784;

			internal object _0024_0024s540_0024call_00242388_002420785;

			internal float _0024_0024wait_sec_0024temp_00242351_002420786;

			internal GameObject _0024npc_002420787;

			internal Exec _0024_0024s540_0024call_00242390_002420788;

			internal IEnumerator _0024_0024s540_0024call_00242389_002420789;

			internal object _0024_0024s540_0024call_00242391_002420790;

			internal float _0024_0024wait_sec_0024temp_00242352_002420791;

			internal GameObject _0024npc_002420792;

			internal Exec _0024_0024s540_0024call_00242393_002420793;

			internal IEnumerable<object> _0024_0024s540_0024call_00242392_002420794;

			internal object _0024_0024s540_0024call_00242394_002420795;

			internal int _0024_002410244_002420796;

			internal GameObject[] _0024_002410245_002420797;

			internal int _0024_002410246_002420798;

			internal int _0024_002410248_002420799;

			internal GameObject[] _0024_002410249_002420800;

			internal int _0024_002410250_002420801;

			internal int _0024_002410252_002420802;

			internal GameObject[] _0024_002410253_002420803;

			internal int _0024_002410254_002420804;

			internal int _0024_002410256_002420805;

			internal GameObject[] _0024_002410257_002420806;

			internal int _0024_002410258_002420807;

			internal int _0024_002410260_002420808;

			internal GameObject[] _0024_002410261_002420809;

			internal int _0024_002410262_002420810;

			internal IEnumerator _0024_0024iterator_002413945_002420811;

			internal IEnumerator _0024_0024iterator_002413946_002420812;

			internal IEnumerator _0024_0024iterator_002413947_002420813;

			internal IEnumerator _0024_0024iterator_002413948_002420814;

			internal IEnumerator _0024_0024iterator_002413949_002420815;

			internal IEnumerator _0024_0024iterator_002413950_002420816;

			internal IEnumerator _0024_0024iterator_002413951_002420817;

			internal IEnumerator _0024_0024iterator_002413952_002420818;

			internal IEnumerator _0024_0024iterator_002413953_002420819;

			internal IEnumerator _0024_0024iterator_002413954_002420820;

			internal IEnumerator _0024_0024iterator_002413955_002420821;

			internal IEnumerator _0024_0024iterator_002413956_002420822;

			internal IEnumerator _0024_0024iterator_002413957_002420823;

			internal IEnumerator<object> _0024_0024iterator_002413958_002420824;

			internal TutorialEvent _0024self__002420825;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420825 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				int result;
				checked
				{
					try
					{
						switch (_state)
						{
						default:
							_0024_0024STATE_NAME_0024_002420733 = "S540_tutorial_raid_story003";
							_0024_0024CUR_EXEC_0024_002420734 = _0024self__002420825.lastCreatedExec;
							goto IL_00dc;
						case 2:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_00dc;
							}
							goto end_IL_0000;
						case 3:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_00f2;
							}
							goto end_IL_0000;
						case 4:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_01c6;
							}
							goto end_IL_0000;
						case 5:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_01c6;
							}
							goto end_IL_0000;
						case 6:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_01e1;
							}
							goto end_IL_0000;
						case 7:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_0244;
							}
							goto end_IL_0000;
						case 8:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1319", "call命令");
								_0024_0024s540_0024call_00242354_002420742 = _0024self__002420825.createExec("S540_deleteAllTargetRingStar", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242353_002420743 = _0024self__002420825.S540_deleteAllTargetRingStar();
								if (_0024_0024s540_0024call_00242353_002420743 != null)
								{
									_0024_0024iterator_002413945_002420811 = _0024_0024s540_0024call_00242353_002420743;
									goto case 9;
								}
								goto IL_04d2;
							}
							goto end_IL_0000;
						case 9:
							if (!_0024_0024iterator_002413945_002420811.MoveNext())
							{
								goto IL_04d2;
							}
							_0024_0024s540_0024call_00242355_002420744 = _0024_0024iterator_002413945_002420811.Current;
							flag = Yield(9, _0024_0024s540_0024call_00242355_002420744);
							goto IL_1649;
						case 10:
							if (!_0024_0024iterator_002413946_002420812.MoveNext())
							{
								goto IL_05a4;
							}
							_0024_0024s540_0024call_00242358_002420747 = _0024_0024iterator_002413946_002420812.Current;
							flag = Yield(10, _0024_0024s540_0024call_00242358_002420747);
							goto IL_1649;
						case 11:
							if (!_0024_0024iterator_002413947_002420813.MoveNext())
							{
								goto IL_066c;
							}
							_0024_0024s540_0024call_00242361_002420750 = _0024_0024iterator_002413947_002420813.Current;
							flag = Yield(11, _0024_0024s540_0024call_00242361_002420750);
							goto IL_1649;
						case 12:
							if (!_0024_0024iterator_002413948_002420814.MoveNext())
							{
								goto IL_0734;
							}
							_0024_0024s540_0024call_00242364_002420753 = _0024_0024iterator_002413948_002420814.Current;
							flag = Yield(12, _0024_0024s540_0024call_00242364_002420753);
							goto IL_1649;
						case 13:
							if (!_0024_0024iterator_002413949_002420815.MoveNext())
							{
								goto IL_07fc;
							}
							_0024_0024s540_0024call_00242367_002420756 = _0024_0024iterator_002413949_002420815.Current;
							flag = Yield(13, _0024_0024s540_0024call_00242367_002420756);
							goto IL_1649;
						case 14:
							if (!_0024_0024iterator_002413950_002420816.MoveNext())
							{
								goto IL_08b0;
							}
							_0024_0024s540_0024call_00242370_002420759 = _0024_0024iterator_002413950_002420816.Current;
							flag = Yield(14, _0024_0024s540_0024call_00242370_002420759);
							goto IL_1649;
						case 15:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_091d;
							}
							goto end_IL_0000;
						case 16:
							if (!_0024_0024iterator_002413951_002420817.MoveNext())
							{
								goto IL_0a96;
							}
							_0024_0024s540_0024call_00242373_002420765 = _0024_0024iterator_002413951_002420817.Current;
							flag = Yield(16, _0024_0024s540_0024call_00242373_002420765);
							goto IL_1649;
						case 17:
							if (!_0024_0024iterator_002413952_002420818.MoveNext())
							{
								goto IL_0b5e;
							}
							_0024_0024s540_0024call_00242376_002420768 = _0024_0024iterator_002413952_002420818.Current;
							flag = Yield(17, _0024_0024s540_0024call_00242376_002420768);
							goto IL_1649;
						case 18:
							if (!_0024_0024iterator_002413953_002420819.MoveNext())
							{
								goto IL_0c12;
							}
							_0024_0024s540_0024call_00242379_002420771 = _0024_0024iterator_002413953_002420819.Current;
							flag = Yield(18, _0024_0024s540_0024call_00242379_002420771);
							goto IL_1649;
						case 19:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1357", "call命令");
								_0024_0024s540_0024call_00242381_002420773 = _0024self__002420825.createExec("S540_deleteAllTargetRingStar", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242380_002420774 = _0024self__002420825.S540_deleteAllTargetRingStar();
								if (_0024_0024s540_0024call_00242380_002420774 != null)
								{
									_0024_0024iterator_002413954_002420820 = _0024_0024s540_0024call_00242380_002420774;
									goto case 20;
								}
								goto IL_0d61;
							}
							goto end_IL_0000;
						case 20:
							if (!_0024_0024iterator_002413954_002420820.MoveNext())
							{
								goto IL_0d61;
							}
							_0024_0024s540_0024call_00242382_002420775 = _0024_0024iterator_002413954_002420820.Current;
							flag = Yield(20, _0024_0024s540_0024call_00242382_002420775);
							goto IL_1649;
						case 21:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_0dc1;
							}
							goto end_IL_0000;
						case 22:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1370", "call命令");
								_0024_0024s540_0024call_00242384_002420778 = _0024self__002420825.createExec("S540_deleteAllTargetRingStar", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242383_002420779 = _0024self__002420825.S540_deleteAllTargetRingStar();
								if (_0024_0024s540_0024call_00242383_002420779 != null)
								{
									_0024_0024iterator_002413955_002420821 = _0024_0024s540_0024call_00242383_002420779;
									goto case 23;
								}
								goto IL_0fa6;
							}
							goto end_IL_0000;
						case 23:
							if (!_0024_0024iterator_002413955_002420821.MoveNext())
							{
								goto IL_0fa6;
							}
							_0024_0024s540_0024call_00242385_002420780 = _0024_0024iterator_002413955_002420821.Current;
							flag = Yield(23, _0024_0024s540_0024call_00242385_002420780);
							goto IL_1649;
						case 24:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_1006;
							}
							goto end_IL_0000;
						case 25:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1383", "call命令");
								_0024_0024s540_0024call_00242387_002420783 = _0024self__002420825.createExec("S540_deleteAllTargetRingStar", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242386_002420784 = _0024self__002420825.S540_deleteAllTargetRingStar();
								if (_0024_0024s540_0024call_00242386_002420784 != null)
								{
									_0024_0024iterator_002413956_002420822 = _0024_0024s540_0024call_00242386_002420784;
									goto case 26;
								}
								goto IL_11eb;
							}
							goto end_IL_0000;
						case 26:
							if (!_0024_0024iterator_002413956_002420822.MoveNext())
							{
								goto IL_11eb;
							}
							_0024_0024s540_0024call_00242388_002420785 = _0024_0024iterator_002413956_002420822.Current;
							flag = Yield(26, _0024_0024s540_0024call_00242388_002420785);
							goto IL_1649;
						case 27:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_124b;
							}
							goto end_IL_0000;
						case 28:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1396", "call命令");
								_0024_0024s540_0024call_00242390_002420788 = _0024self__002420825.createExec("S540_deleteAllTargetRingStar", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242389_002420789 = _0024self__002420825.S540_deleteAllTargetRingStar();
								if (_0024_0024s540_0024call_00242389_002420789 != null)
								{
									_0024_0024iterator_002413957_002420823 = _0024_0024s540_0024call_00242389_002420789;
									goto case 29;
								}
								goto IL_1430;
							}
							goto end_IL_0000;
						case 29:
							if (!_0024_0024iterator_002413957_002420823.MoveNext())
							{
								goto IL_1430;
							}
							_0024_0024s540_0024call_00242391_002420790 = _0024_0024iterator_002413957_002420823.Current;
							flag = Yield(29, _0024_0024s540_0024call_00242391_002420790);
							goto IL_1649;
						case 30:
							if (!_0024_0024CUR_EXEC_0024_002420734.NotExecuting)
							{
								goto IL_1490;
							}
							goto end_IL_0000;
						case 32:
							if (_0024_0024iterator_002413958_002420824.MoveNext())
							{
								_0024_0024s540_0024call_00242394_002420795 = _0024_0024iterator_002413958_002420824.Current;
								flag = Yield(32, _0024_0024s540_0024call_00242394_002420795);
								goto IL_1649;
							}
							_state = 1;
							_0024ensure31();
							break;
						case 1:
						case 31:
							goto end_IL_0000;
							IL_07fc:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1333", "call命令");
								_0024_0024s540_0024call_00242369_002420757 = _0024self__002420825.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242368_002420758 = _0024self__002420825.S540_message_end();
								if (_0024_0024s540_0024call_00242368_002420758 != null)
								{
									_0024_0024iterator_002413950_002420816 = _0024_0024s540_0024call_00242368_002420758;
									goto case 14;
								}
								goto IL_08b0;
							}
							goto end_IL_0000;
							IL_0dc1:
							if (_0024_0024wait_sec_0024temp_00242349_002420776 > 0f)
							{
								_0024_0024wait_sec_0024temp_00242349_002420776 -= Time.deltaTime;
								flag = YieldDefault(21);
							}
							else
							{
								_0024_002410248_002420799 = 0;
								_0024_002410249_002420800 = _0024npcObj_002420741;
								for (_0024_002410250_002420801 = _0024_002410249_002420800.Length; _0024_002410248_002420799 < _0024_002410250_002420801; _0024_002410248_002420799++)
								{
									if (!(_0024_002410249_002420800[_0024_002410248_002420799] == null))
									{
										_0024ai_002420762 = _0024_002410249_002420800[_0024_002410248_002420799].GetComponent<AIControl>();
										if ((bool)_0024ai_002420762 && _0024ai_002420762.IsDead)
										{
											UnityEngine.Object.Destroy(_0024_002410249_002420800[_0024_002410248_002420799]);
										}
									}
								}
								_0024npcObj_002420741[3] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[3], new Vector3(0f, 0f, 11f), Quaternion.identity);
								if ((bool)_0024Player_002420735)
								{
									_0024recoveryHP_002420772 = (int)_0024Player_002420735.RecoverByCandy();
									DamageDisplay.Heal(_0024Player_002420735.transform.root.position, _0024recoveryHP_002420772);
								}
								flag = YieldDefault(22);
							}
							goto IL_1649;
							IL_1430:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024_0024wait_sec_0024temp_00242352_002420791 = 15f;
								goto IL_1490;
							}
							goto end_IL_0000;
							IL_1490:
							if (_0024_0024wait_sec_0024temp_00242352_002420791 > 0f)
							{
								_0024_0024wait_sec_0024temp_00242352_002420791 -= Time.deltaTime;
								flag = YieldDefault(30);
								goto IL_1649;
							}
							_0024_002410260_002420808 = 0;
							_0024_002410261_002420809 = _0024npcObj_002420741;
							for (_0024_002410262_002420810 = _0024_002410261_002420809.Length; _0024_002410260_002420808 < _0024_002410262_002420810; _0024_002410260_002420808++)
							{
								if (!(_0024_002410261_002420809[_0024_002410260_002420808] == null))
								{
									UnityEngine.Object.Destroy(_0024_002410261_002420809[_0024_002410260_002420808]);
								}
							}
							_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1403", "call命令");
							_0024_0024s540_0024call_00242393_002420793 = _0024self__002420825.createExec("S540_cutscene", _0024_0024CUR_EXEC_0024_002420734);
							_0024_0024s540_0024call_00242392_002420794 = _0024self__002420825.S540_cutscene("Merlin_CutSceneST03_ev03");
							if (_0024_0024s540_0024call_00242392_002420794 == null)
							{
								break;
							}
							_0024_0024iterator_002413958_002420824 = _0024_0024s540_0024call_00242392_002420794.GetEnumerator();
							_state = 31;
							goto case 32;
							IL_0c12:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								ScreenMask.deactivate();
								HUDHappaTimer.SetAutoTimer(b: true);
								_0024npcObj_002420741[2] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[2], new Vector3(0f, 0f, 11f), Quaternion.identity);
								if ((bool)_0024Player_002420735)
								{
									_0024recoveryHP_002420772 = (int)_0024Player_002420735.RecoverByCandy();
									DamageDisplay.Heal(_0024Player_002420735.transform.root.position, _0024recoveryHP_002420772);
								}
								flag = YieldDefault(19);
								goto IL_1649;
							}
							goto end_IL_0000;
							IL_08b0:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								ScreenMask.deactivate();
								HUDHappaTimer.ShowAutoTimer(60f);
								_0024_0024wait_sec_0024temp_00242348_002420760 = 10f;
								goto IL_091d;
							}
							goto end_IL_0000;
							IL_0244:
							_0024cc_002420738 = (CameraControl)UnityEngine.Object.FindObjectOfType(typeof(CameraControl));
							if (!(_0024cc_002420738 != null))
							{
								flag = YieldDefault(7);
							}
							else
							{
								FaderCore.Instance.fadeOut();
								if ((bool)Camera.main)
								{
									if ((bool)_0024cc_002420738)
									{
										UnityEngine.Object.Destroy(_0024cc_002420738);
									}
									_0024rc_002420739 = Camera.main.gameObject.AddComponent<RaidCamera>();
									if ((bool)_0024rc_002420739)
									{
										if ((bool)_0024Player_002420735)
										{
											_0024rc_002420739.player = _0024Player_002420735.transform;
										}
										if ((bool)_0024boss_002420737)
										{
											_0024rc_002420739.boss = _0024boss_002420737.transform;
										}
										_0024rc_002420739.setFullMetalHuggerParam();
									}
								}
								_0024npcPrefabs_002420740 = new GameObject[4];
								_0024npcPrefabs_002420740[0] = GameAssetModule.LoadPrefab("Prefab/Character/Player/P_RAID_C0000_000_MA_ROOT") as GameObject;
								_0024npcPrefabs_002420740[1] = GameAssetModule.LoadPrefab("Prefab/Character/Player/P_RAID_C0001_000_MA_ROOT") as GameObject;
								_0024npcPrefabs_002420740[2] = GameAssetModule.LoadPrefab("Prefab/Character/Player/P_RAID_C0002_000_MA_ROOT") as GameObject;
								_0024npcPrefabs_002420740[3] = GameAssetModule.LoadPrefab("Prefab/Character/Player/P_RAID_C0003_000_MA_ROOT") as GameObject;
								_0024npcObj_002420741 = new GameObject[6];
								_0024npcObj_002420741[0] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[0], new Vector3(-10f, 0f, 11f), Quaternion.identity);
								_0024npcObj_002420741[1] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[1], new Vector3(10f, 0f, 11f), Quaternion.identity);
								flag = YieldDefault(8);
							}
							goto IL_1649;
							IL_091d:
							if (_0024_0024wait_sec_0024temp_00242348_002420760 > 0f)
							{
								_0024_0024wait_sec_0024temp_00242348_002420760 -= Time.deltaTime;
								flag = YieldDefault(15);
								goto IL_1649;
							}
							_0024_002410244_002420796 = 0;
							_0024_002410245_002420797 = _0024npcObj_002420741;
							for (_0024_002410246_002420798 = _0024_002410245_002420797.Length; _0024_002410244_002420796 < _0024_002410246_002420798; _0024_002410244_002420796++)
							{
								if (!(_0024_002410245_002420797[_0024_002410244_002420796] == null))
								{
									_0024ai_002420762 = _0024_002410245_002420797[_0024_002410244_002420796].GetComponent<AIControl>();
									if ((bool)_0024ai_002420762 && _0024ai_002420762.IsDead)
									{
										UnityEngine.Object.Destroy(_0024_002410245_002420797[_0024_002410244_002420796]);
									}
								}
							}
							ScreenMask.Instance.activate();
							HUDHappaTimer.SetAutoTimer(b: false);
							_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1346", "call命令");
							_0024_0024s540_0024call_00242372_002420763 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
							_0024_0024s540_0024call_00242371_002420764 = _0024self__002420825.S540_tutorial_npc(string.Empty, "他のプレイヤーが途中参戦すると\n御使にボーナスダメージを与えてくれる。", TUTORIAL_WINDOW_TYPE);
							if (_0024_0024s540_0024call_00242371_002420764 != null)
							{
								_0024_0024iterator_002413951_002420817 = _0024_0024s540_0024call_00242371_002420764;
								goto case 16;
							}
							goto IL_0a96;
							IL_00f2:
							_0024Player_002420735 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
							if (!(_0024Player_002420735 != null))
							{
								flag = YieldDefault(3);
							}
							else
							{
								_0024_0024sco_0024temp_00242347_002420736 = _0024self__002420825.revivePlayer(_0024Player_002420735);
								if (_0024_0024sco_0024temp_00242347_002420736 != null)
								{
									_0024self__002420825.StartCoroutine(_0024_0024sco_0024temp_00242347_002420736);
								}
								flag = YieldDefault(4);
							}
							goto IL_1649;
							IL_00dc:
							if (!SceneChanger.isCompletelyReady)
							{
								FaderCore.Instance.In();
								flag = YieldDefault(2);
								goto IL_1649;
							}
							_0024Player_002420735 = null;
							goto IL_00f2;
							IL_11eb:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024_0024wait_sec_0024temp_00242351_002420786 = 10f;
								goto IL_124b;
							}
							goto end_IL_0000;
							IL_04d2:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								ScreenMask.Instance.activate();
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1328", "call命令");
								_0024_0024s540_0024call_00242357_002420745 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242356_002420746 = _0024self__002420825.S540_tutorial_npc(string.Empty, "レイドバトルは複数のプレイヤーで協力して\n巨大な御使（みつかい）と戦うモードだ。", TUTORIAL_WINDOW_TYPE);
								if (_0024_0024s540_0024call_00242356_002420746 != null)
								{
									_0024_0024iterator_002413946_002420812 = _0024_0024s540_0024call_00242356_002420746;
									goto case 10;
								}
								goto IL_05a4;
							}
							goto end_IL_0000;
							IL_124b:
							if (_0024_0024wait_sec_0024temp_00242351_002420786 > 0f)
							{
								_0024_0024wait_sec_0024temp_00242351_002420786 -= Time.deltaTime;
								flag = YieldDefault(27);
							}
							else
							{
								_0024_002410256_002420805 = 0;
								_0024_002410257_002420806 = _0024npcObj_002420741;
								for (_0024_002410258_002420807 = _0024_002410257_002420806.Length; _0024_002410256_002420805 < _0024_002410258_002420807; _0024_002410256_002420805++)
								{
									if (!(_0024_002410257_002420806[_0024_002410256_002420805] == null))
									{
										_0024ai_002420762 = _0024_002410257_002420806[_0024_002410256_002420805].GetComponent<AIControl>();
										if ((bool)_0024ai_002420762 && _0024ai_002420762.IsDead)
										{
											UnityEngine.Object.Destroy(_0024_002410257_002420806[_0024_002410256_002420805]);
										}
									}
								}
								_0024npcObj_002420741[5] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[1], new Vector3(0f, 0f, 11f), Quaternion.identity);
								if ((bool)_0024Player_002420735)
								{
									_0024recoveryHP_002420772 = (int)_0024Player_002420735.RecoverByCandy();
									DamageDisplay.Heal(_0024Player_002420735.transform.root.position, _0024recoveryHP_002420772);
								}
								flag = YieldDefault(28);
							}
							goto IL_1649;
							IL_05a4:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1329", "call命令");
								_0024_0024s540_0024call_00242360_002420748 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242359_002420749 = _0024self__002420825.S540_tutorial_npc(string.Empty, "左下のマナの葉か、自分のＨＰが０になると\nシオン界からはじき出されてしまう。", TUTORIAL_WINDOW_TYPE);
								if (_0024_0024s540_0024call_00242359_002420749 != null)
								{
									_0024_0024iterator_002413947_002420813 = _0024_0024s540_0024call_00242359_002420749;
									goto case 11;
								}
								goto IL_066c;
							}
							goto end_IL_0000;
							IL_0a96:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1347", "call命令");
								_0024_0024s540_0024call_00242375_002420766 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242374_002420767 = _0024self__002420825.S540_tutorial_npc(string.Empty, "また、その場にいるプレイヤーのＨＰを\n少しだけ回復してくれるぞ。", TUTORIAL_WINDOW_TYPE);
								if (_0024_0024s540_0024call_00242374_002420767 != null)
								{
									_0024_0024iterator_002413952_002420818 = _0024_0024s540_0024call_00242374_002420767;
									goto case 17;
								}
								goto IL_0b5e;
							}
							goto end_IL_0000;
							IL_0fa6:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024_0024wait_sec_0024temp_00242350_002420781 = 10f;
								goto IL_1006;
							}
							goto end_IL_0000;
							IL_066c:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1330", "call命令");
								_0024_0024s540_0024call_00242363_002420751 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242362_002420752 = _0024self__002420825.S540_tutorial_npc(string.Empty, "シオン界からはじき出された場合\n精神力を消費して再挑戦が可能だ！", TUTORIAL_WINDOW_TYPE);
								if (_0024_0024s540_0024call_00242362_002420752 != null)
								{
									_0024_0024iterator_002413948_002420814 = _0024_0024s540_0024call_00242362_002420752;
									goto case 12;
								}
								goto IL_0734;
							}
							goto end_IL_0000;
							IL_1006:
							if (_0024_0024wait_sec_0024temp_00242350_002420781 > 0f)
							{
								_0024_0024wait_sec_0024temp_00242350_002420781 -= Time.deltaTime;
								flag = YieldDefault(24);
							}
							else
							{
								_0024_002410252_002420802 = 0;
								_0024_002410253_002420803 = _0024npcObj_002420741;
								for (_0024_002410254_002420804 = _0024_002410253_002420803.Length; _0024_002410252_002420802 < _0024_002410254_002420804; _0024_002410252_002420802++)
								{
									if (!(_0024_002410253_002420803[_0024_002410252_002420802] == null))
									{
										_0024ai_002420762 = _0024_002410253_002420803[_0024_002410252_002420802].GetComponent<AIControl>();
										if ((bool)_0024ai_002420762 && _0024ai_002420762.IsDead)
										{
											UnityEngine.Object.Destroy(_0024_002410253_002420803[_0024_002410252_002420802]);
										}
									}
								}
								_0024npcObj_002420741[4] = (GameObject)UnityEngine.Object.Instantiate(_0024npcPrefabs_002420740[0], new Vector3(0f, 0f, 11f), Quaternion.identity);
								if ((bool)_0024Player_002420735)
								{
									_0024recoveryHP_002420772 = (int)_0024Player_002420735.RecoverByCandy();
									DamageDisplay.Heal(_0024Player_002420735.transform.root.position, _0024recoveryHP_002420772);
								}
								flag = YieldDefault(25);
							}
							goto IL_1649;
							IL_01c6:
							if (CutSceneManager.Instance.isBusy)
							{
								flag = YieldDefault(5);
								goto IL_1649;
							}
							_0024boss_002420737 = null;
							goto IL_01e1;
							IL_0b5e:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1348", "call命令");
								_0024_0024s540_0024call_00242378_002420769 = _0024self__002420825.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242377_002420770 = _0024self__002420825.S540_message_end();
								if (_0024_0024s540_0024call_00242377_002420770 != null)
								{
									_0024_0024iterator_002413953_002420819 = _0024_0024s540_0024call_00242377_002420770;
									goto case 18;
								}
								goto IL_0c12;
							}
							goto end_IL_0000;
							IL_0734:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024self__002420825.dtrace(_0024_0024CUR_EXEC_0024_002420734, "TutorialEvent.boo:1332", "call命令");
								_0024_0024s540_0024call_00242366_002420754 = _0024self__002420825.createExec("S540_tutorial_npc", _0024_0024CUR_EXEC_0024_002420734);
								_0024_0024s540_0024call_00242365_002420755 = _0024self__002420825.S540_tutorial_npc(string.Empty, "御使を倒すことができれば\n様々な報酬を入手できる。がんばろう！", TUTORIAL_WINDOW_TYPE);
								if (_0024_0024s540_0024call_00242365_002420755 != null)
								{
									_0024_0024iterator_002413949_002420815 = _0024_0024s540_0024call_00242365_002420755;
									goto case 13;
								}
								goto IL_07fc;
							}
							goto end_IL_0000;
							IL_01e1:
							_0024boss_002420737 = (AIControl)UnityEngine.Object.FindObjectOfType(typeof(AIControl));
							if (!(_0024boss_002420737 != null))
							{
								flag = YieldDefault(6);
								goto IL_1649;
							}
							_0024cc_002420738 = null;
							goto IL_0244;
							IL_0d61:
							if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
							{
								_0024_0024wait_sec_0024temp_00242349_002420776 = 10f;
								goto IL_0dc1;
							}
							goto end_IL_0000;
						}
						if (_0024self__002420825.isExecuting(_0024_0024CUR_EXEC_0024_002420734))
						{
							if ((bool)_0024boss_002420737)
							{
								_0024boss_002420737.kill();
								UnityEngine.Object.Destroy(_0024boss_002420737.transform.root.gameObject);
							}
							_0024self__002420825.stop(_0024_0024CUR_EXEC_0024_002420734);
						}
						end_IL_0000:;
					}
					catch
					{
						//try-fault
						Dispose();
						throw;
					}
					result = 0;
					goto IL_164a;
				}
				IL_164a:
				return (byte)result != 0;
				IL_1649:
				result = (flag ? 1 : 0);
				goto IL_164a;
			}

			private void _0024ensure31()
			{
				_0024_0024iterator_002413958_002420824.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 31:
				case 32:
					_state = 1;
					_0024ensure31();
					break;
				}
			}
		}

		internal TutorialEvent _0024self__002420826;

		public _0024S540_tutorial_raid_story003_002420732(TutorialEvent self_)
		{
			_0024self__002420826 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420826);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024revivePlayer_002420827 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242396_002420828;

			internal PlayerControl _0024_pc_002420829;

			public _0024(PlayerControl _pc)
			{
				_0024_pc_002420829 = _pc;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024_pc_002420829 == null)
					{
						goto case 1;
					}
					goto case 3;
				case 3:
					if (_0024_pc_002420829 != null && _0024_pc_002420829.IsDead)
					{
						_0024_0024wait_sec_0024temp_00242396_002420828 = 0.5f;
						goto case 2;
					}
					goto IL_00ad;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242396_002420828 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242396_002420828 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if ((bool)_0024_pc_002420829)
					{
						_0024_pc_002420829.reviveTutorial();
					}
					goto IL_00ad;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ad:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024_pc_002420830;

		public _0024revivePlayer_002420827(PlayerControl _pc)
		{
			_0024_pc_002420830 = _pc;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024_pc_002420830);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_recoverPlayerHP_002420831 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242397_002420832;

			internal object _0024___item_002420833;

			internal IEnumerator _0024_0024iterator_002413959_002420834;

			internal PlayerControl _0024_pc_002420835;

			internal TutorialEvent _0024self__002420836;

			public _0024(PlayerControl _pc, TutorialEvent self_)
			{
				_0024_pc_002420835 = _pc;
				_0024self__002420836 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242397_002420832 = _0024self__002420836.S540_recoverPlayerHP(_0024_pc_002420835, null);
					if (_0024_0024s540_0024ycode_00242397_002420832 != null)
					{
						_0024_0024iterator_002413959_002420834 = _0024_0024s540_0024ycode_00242397_002420832;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413959_002420834.MoveNext())
					{
						_0024___item_002420833 = _0024_0024iterator_002413959_002420834.Current;
						result = (Yield(2, _0024___item_002420833) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024_pc_002420837;

		internal TutorialEvent _0024self__002420838;

		public _0024S540_recoverPlayerHP_002420831(PlayerControl _pc, TutorialEvent self_)
		{
			_0024_pc_002420837 = _pc;
			_0024self__002420838 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024_pc_002420837, _0024self__002420838);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_createPlayerNPC_002420839 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242398_002420840;

			internal object _0024___item_002420841;

			internal IEnumerator _0024_0024iterator_002413960_002420842;

			internal GameObject _0024obj_002420843;

			internal Vector3 _0024pos_002420844;

			internal Vector3 _0024rot_002420845;

			internal TutorialEvent _0024self__002420846;

			public _0024(GameObject obj, Vector3 pos, Vector3 rot, TutorialEvent self_)
			{
				_0024obj_002420843 = obj;
				_0024pos_002420844 = pos;
				_0024rot_002420845 = rot;
				_0024self__002420846 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242398_002420840 = _0024self__002420846.S540_createPlayerNPC(_0024obj_002420843, _0024pos_002420844, _0024rot_002420845, null);
					if (_0024_0024s540_0024ycode_00242398_002420840 != null)
					{
						_0024_0024iterator_002413960_002420842 = _0024_0024s540_0024ycode_00242398_002420840;
						goto case 2;
					}
					goto IL_008a;
				case 2:
					if (_0024_0024iterator_002413960_002420842.MoveNext())
					{
						_0024___item_002420841 = _0024_0024iterator_002413960_002420842.Current;
						result = (Yield(2, _0024___item_002420841) ? 1 : 0);
						break;
					}
					goto IL_008a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024obj_002420847;

		internal Vector3 _0024pos_002420848;

		internal Vector3 _0024rot_002420849;

		internal TutorialEvent _0024self__002420850;

		public _0024S540_createPlayerNPC_002420839(GameObject obj, Vector3 pos, Vector3 rot, TutorialEvent self_)
		{
			_0024obj_002420847 = obj;
			_0024pos_002420848 = pos;
			_0024rot_002420849 = rot;
			_0024self__002420850 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024obj_002420847, _0024pos_002420848, _0024rot_002420849, _0024self__002420850);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_deleteAllTargetRingStar_002420851 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242399_002420852;

			internal object _0024___item_002420853;

			internal IEnumerator _0024_0024iterator_002413961_002420854;

			internal TutorialEvent _0024self__002420855;

			public _0024(TutorialEvent self_)
			{
				_0024self__002420855 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242399_002420852 = _0024self__002420855.S540_deleteAllTargetRingStar(null);
					if (_0024_0024s540_0024ycode_00242399_002420852 != null)
					{
						_0024_0024iterator_002413961_002420854 = _0024_0024s540_0024ycode_00242399_002420852;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413961_002420854.MoveNext())
					{
						_0024___item_002420853 = _0024_0024iterator_002413961_002420854.Current;
						result = (Yield(2, _0024___item_002420853) ? 1 : 0);
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

		internal TutorialEvent _0024self__002420856;

		public _0024S540_deleteAllTargetRingStar_002420851(TutorialEvent self_)
		{
			_0024self__002420856 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002420856);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npcchat_stop_002420857 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242407_002420858;

			internal object _0024___item_002420859;

			internal IEnumerator _0024_0024iterator_002413962_002420860;

			internal NPCControl _0024c_002420861;

			internal object _0024charname_002420862;

			internal object _0024message_002420863;

			internal TutorialEvent _0024self__002420864;

			public _0024(NPCControl c, object charname, object message, TutorialEvent self_)
			{
				_0024c_002420861 = c;
				_0024charname_002420862 = charname;
				_0024message_002420863 = message;
				_0024self__002420864 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242407_002420858 = _0024self__002420864.S540_npcchat_stop(_0024c_002420861, _0024charname_002420862, _0024message_002420863, null);
					if (_0024_0024s540_0024ycode_00242407_002420858 != null)
					{
						_0024_0024iterator_002413962_002420860 = _0024_0024s540_0024ycode_00242407_002420858;
						goto case 2;
					}
					goto IL_008a;
				case 2:
					if (_0024_0024iterator_002413962_002420860.MoveNext())
					{
						_0024___item_002420859 = _0024_0024iterator_002413962_002420860.Current;
						result = (Yield(2, _0024___item_002420859) ? 1 : 0);
						break;
					}
					goto IL_008a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal NPCControl _0024c_002420865;

		internal object _0024charname_002420866;

		internal object _0024message_002420867;

		internal TutorialEvent _0024self__002420868;

		public _0024S540_npcchat_stop_002420857(NPCControl c, object charname, object message, TutorialEvent self_)
		{
			_0024c_002420865 = c;
			_0024charname_002420866 = charname;
			_0024message_002420867 = message;
			_0024self__002420868 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002420865, _0024charname_002420866, _0024message_002420867, _0024self__002420868);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npcchat_stop_002420869 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420870;

			internal Exec _0024_0024CUR_EXEC_0024_002420871;

			internal int _0024_0024s540_0024loop_00242400_002420872;

			internal Exec _0024_0024s540_0024call_00242402_002420873;

			internal IEnumerable<object> _0024_0024s540_0024call_00242401_002420874;

			internal object _0024_0024s540_0024call_00242403_002420875;

			internal Exec _0024_0024s540_0024call_00242405_002420876;

			internal IEnumerator _0024_0024s540_0024call_00242404_002420877;

			internal object _0024_0024s540_0024call_00242406_002420878;

			internal IEnumerator<object> _0024_0024iterator_002413963_002420879;

			internal IEnumerator _0024_0024iterator_002413964_002420880;

			internal NPCControl _0024c_002420881;

			internal object _0024charname_002420882;

			internal object _0024message_002420883;

			internal TutorialEvent _0024self__002420884;

			public _0024(NPCControl c, object charname, object message, TutorialEvent self_)
			{
				_0024c_002420881 = c;
				_0024charname_002420882 = charname;
				_0024message_002420883 = message;
				_0024self__002420884 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024STATE_NAME_0024_002420870 = "S540_npcchat_stop";
						_0024_0024CUR_EXEC_0024_002420871 = _0024self__002420884.lastCreatedExec;
						_0024self__002420884.dtrace(_0024_0024CUR_EXEC_0024_002420871, "TutorialEvent.boo:1440", "loop命令");
						goto IL_005f;
					case 3:
						if (_0024_0024iterator_002413963_002420879.MoveNext())
						{
							_0024_0024s540_0024call_00242403_002420875 = _0024_0024iterator_002413963_002420879.Current;
							flag = Yield(3, _0024_0024s540_0024call_00242403_002420875);
							goto IL_02c2;
						}
						_state = 1;
						_0024ensure2();
						goto IL_0163;
					case 4:
						if (!_0024_0024iterator_002413964_002420880.MoveNext())
						{
							goto IL_022c;
						}
						_0024_0024s540_0024call_00242406_002420878 = _0024_0024iterator_002413964_002420880.Current;
						flag = Yield(4, _0024_0024s540_0024call_00242406_002420878);
						goto IL_02c2;
					case 5:
						if (_0024_0024CUR_EXEC_0024_002420871.NotExecuting)
						{
							break;
						}
						goto IL_005f;
					case 1:
					case 2:
						break;
						IL_005f:
						_0024_0024s540_0024loop_00242400_002420872 = Time.frameCount;
						if (_0024self__002420884.nearPlayer(_0024c_002420881) && _0024self__002420884.touch(_0024c_002420881))
						{
							_0024self__002420884.disableTouchMarker(_0024c_002420881);
							_0024self__002420884.dtrace(_0024_0024CUR_EXEC_0024_002420871, "TutorialEvent.boo:1443", "call命令");
							_0024_0024s540_0024call_00242402_002420873 = _0024self__002420884.createExec("S540_konnichiwa", _0024_0024CUR_EXEC_0024_002420871);
							_0024_0024s540_0024call_00242401_002420874 = _0024self__002420884.S540_konnichiwa(_0024c_002420881, 0.5f);
							if (_0024_0024s540_0024call_00242401_002420874 != null)
							{
								_0024_0024iterator_002413963_002420879 = _0024_0024s540_0024call_00242401_002420874.GetEnumerator();
								_state = 2;
								goto case 3;
							}
							goto IL_0163;
						}
						if (_0024_0024s540_0024loop_00242400_002420872 != Time.frameCount)
						{
							goto case 5;
						}
						flag = YieldDefault(5);
						goto IL_02c2;
						IL_0163:
						if (!_0024self__002420884.isExecuting(_0024_0024CUR_EXEC_0024_002420871))
						{
							break;
						}
						_0024self__002420884.dtrace(_0024_0024CUR_EXEC_0024_002420871, "TutorialEvent.boo:1444", "call命令");
						_0024_0024s540_0024call_00242405_002420876 = _0024self__002420884.createExec("S540_npc", _0024_0024CUR_EXEC_0024_002420871);
						_0024_0024s540_0024call_00242404_002420877 = _0024self__002420884.S540_npc(_0024charname_002420882, _0024message_002420883, TOWN_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242404_002420877 != null)
						{
							_0024_0024iterator_002413964_002420880 = _0024_0024s540_0024call_00242404_002420877;
							goto case 4;
						}
						goto IL_022c;
						IL_022c:
						if (_0024self__002420884.isExecuting(_0024_0024CUR_EXEC_0024_002420871))
						{
							_0024self__002420884.enableTownPeopleTouchMarker(_0024c_002420881);
							_0024self__002420884.stop(_0024_0024CUR_EXEC_0024_002420871);
						}
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_02c3;
				IL_02c2:
				result = (flag ? 1 : 0);
				goto IL_02c3;
				IL_02c3:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413963_002420879.Dispose();
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

		internal NPCControl _0024c_002420885;

		internal object _0024charname_002420886;

		internal object _0024message_002420887;

		internal TutorialEvent _0024self__002420888;

		public _0024S540_npcchat_stop_002420869(NPCControl c, object charname, object message, TutorialEvent self_)
		{
			_0024c_002420885 = c;
			_0024charname_002420886 = charname;
			_0024message_002420887 = message;
			_0024self__002420888 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002420885, _0024charname_002420886, _0024message_002420887, _0024self__002420888);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npcchat_002420889 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242417_002420890;

			internal object _0024___item_002420891;

			internal IEnumerator _0024_0024iterator_002413965_002420892;

			internal NPCControl _0024c_002420893;

			internal object _0024charname_002420894;

			internal object _0024message_002420895;

			internal bool _0024furimuki_002420896;

			internal TutorialEvent _0024self__002420897;

			public _0024(NPCControl c, object charname, object message, bool furimuki, TutorialEvent self_)
			{
				_0024c_002420893 = c;
				_0024charname_002420894 = charname;
				_0024message_002420895 = message;
				_0024furimuki_002420896 = furimuki;
				_0024self__002420897 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242417_002420890 = _0024self__002420897.S540_npcchat(_0024c_002420893, _0024charname_002420894, _0024message_002420895, _0024furimuki_002420896, null);
					if (_0024_0024s540_0024ycode_00242417_002420890 != null)
					{
						_0024_0024iterator_002413965_002420892 = _0024_0024s540_0024ycode_00242417_002420890;
						goto case 2;
					}
					goto IL_0090;
				case 2:
					if (_0024_0024iterator_002413965_002420892.MoveNext())
					{
						_0024___item_002420891 = _0024_0024iterator_002413965_002420892.Current;
						result = (Yield(2, _0024___item_002420891) ? 1 : 0);
						break;
					}
					goto IL_0090;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0090:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal NPCControl _0024c_002420898;

		internal object _0024charname_002420899;

		internal object _0024message_002420900;

		internal bool _0024furimuki_002420901;

		internal TutorialEvent _0024self__002420902;

		public _0024S540_npcchat_002420889(NPCControl c, object charname, object message, bool furimuki, TutorialEvent self_)
		{
			_0024c_002420898 = c;
			_0024charname_002420899 = charname;
			_0024message_002420900 = message;
			_0024furimuki_002420901 = furimuki;
			_0024self__002420902 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002420898, _0024charname_002420899, _0024message_002420900, _0024furimuki_002420901, _0024self__002420902);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npcchat_002420903 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420904;

			internal Exec _0024_0024CUR_EXEC_0024_002420905;

			internal Exec _0024_0024s540_0024call_00242409_002420906;

			internal IEnumerable<object> _0024_0024s540_0024call_00242408_002420907;

			internal object _0024_0024s540_0024call_00242410_002420908;

			internal Exec _0024_0024s540_0024call_00242412_002420909;

			internal IEnumerator _0024_0024s540_0024call_00242411_002420910;

			internal object _0024_0024s540_0024call_00242413_002420911;

			internal Exec _0024_0024s540_0024call_00242415_002420912;

			internal IEnumerator _0024_0024s540_0024call_00242414_002420913;

			internal object _0024_0024s540_0024call_00242416_002420914;

			internal IEnumerator<object> _0024_0024iterator_002413966_002420915;

			internal IEnumerator _0024_0024iterator_002413967_002420916;

			internal IEnumerator _0024_0024iterator_002413968_002420917;

			internal NPCControl _0024c_002420918;

			internal object _0024charname_002420919;

			internal object _0024message_002420920;

			internal bool _0024furimuki_002420921;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024_0024INNER_BLOCK_0024_002420922;

			internal TutorialEvent _0024self__002420923;

			public _0024(NPCControl c, object charname, object message, bool furimuki, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024, TutorialEvent self_)
			{
				_0024c_002420918 = c;
				_0024charname_002420919 = charname;
				_0024message_002420920 = message;
				_0024furimuki_002420921 = furimuki;
				_0024_0024INNER_BLOCK_0024_002420922 = _0024INNER_BLOCK_0024;
				_0024self__002420923 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024STATE_NAME_0024_002420904 = "S540_npcchat";
						_0024_0024CUR_EXEC_0024_002420905 = _0024self__002420923.lastCreatedExec;
						if (!_0024self__002420923.nearPlayer(_0024c_002420918) || !_0024self__002420923.touch(_0024c_002420918))
						{
							break;
						}
						if (_0024furimuki_002420921)
						{
							_0024c_002420918.UpdateLastRotY();
							_0024self__002420923.dtrace(_0024_0024CUR_EXEC_0024_002420905, "TutorialEvent.boo:1453", "call命令");
							_0024_0024s540_0024call_00242409_002420906 = _0024self__002420923.createExec("S540_konnichiwa", _0024_0024CUR_EXEC_0024_002420905);
							_0024_0024s540_0024call_00242408_002420907 = _0024self__002420923.S540_konnichiwa(_0024c_002420918, 0.5f);
							if (_0024_0024s540_0024call_00242408_002420907 != null)
							{
								_0024_0024iterator_002413966_002420915 = _0024_0024s540_0024call_00242408_002420907.GetEnumerator();
								_state = 2;
								goto case 3;
							}
							goto IL_013d;
						}
						goto IL_0158;
					case 3:
						if (_0024_0024iterator_002413966_002420915.MoveNext())
						{
							_0024_0024s540_0024call_00242410_002420908 = _0024_0024iterator_002413966_002420915.Current;
							flag = Yield(3, _0024_0024s540_0024call_00242410_002420908);
							goto IL_0335;
						}
						_state = 1;
						_0024ensure2();
						goto IL_013d;
					case 4:
						if (!_0024_0024iterator_002413967_002420916.MoveNext())
						{
							goto IL_0217;
						}
						_0024_0024s540_0024call_00242413_002420911 = _0024_0024iterator_002413967_002420916.Current;
						flag = Yield(4, _0024_0024s540_0024call_00242413_002420911);
						goto IL_0335;
					case 5:
						if (!_0024_0024iterator_002413968_002420917.MoveNext())
						{
							goto IL_02ed;
						}
						_0024_0024s540_0024call_00242416_002420914 = _0024_0024iterator_002413968_002420917.Current;
						flag = Yield(5, _0024_0024s540_0024call_00242416_002420914);
						goto IL_0335;
					case 1:
					case 2:
						goto end_IL_0000;
						IL_013d:
						if (_0024self__002420923.isExecuting(_0024_0024CUR_EXEC_0024_002420905))
						{
							goto IL_0158;
						}
						goto end_IL_0000;
						IL_0158:
						_0024self__002420923.disableTouchMarker(_0024c_002420918);
						_0024self__002420923.dtrace(_0024_0024CUR_EXEC_0024_002420905, "TutorialEvent.boo:1455", "call命令");
						_0024_0024s540_0024call_00242412_002420909 = _0024self__002420923.createExec("S540_npc", _0024_0024CUR_EXEC_0024_002420905);
						_0024_0024s540_0024call_00242411_002420910 = _0024self__002420923.S540_npc(_0024charname_002420919, _0024message_002420920, TOWN_WINDOW_TYPE);
						if (_0024_0024s540_0024call_00242411_002420910 != null)
						{
							_0024_0024iterator_002413967_002420916 = _0024_0024s540_0024call_00242411_002420910;
							goto case 4;
						}
						goto IL_0217;
						IL_02ed:
						if (_0024self__002420923.isExecuting(_0024_0024CUR_EXEC_0024_002420905))
						{
							break;
						}
						goto end_IL_0000;
						IL_0217:
						if (_0024self__002420923.isExecuting(_0024_0024CUR_EXEC_0024_002420905))
						{
							_0024self__002420923.enableTownPeopleTouchMarker(_0024c_002420918);
							if (!(_0024_0024INNER_BLOCK_0024_002420922 != null))
							{
								break;
							}
							_0024self__002420923.dtrace(_0024_0024CUR_EXEC_0024_002420905, "TutorialEvent.boo:1457", "call命令");
							_0024_0024s540_0024call_00242415_002420912 = _0024self__002420923.createExec("$INNER_BLOCK$", _0024_0024CUR_EXEC_0024_002420905);
							_0024_0024s540_0024call_00242414_002420913 = _0024_0024INNER_BLOCK_0024_002420922();
							if (_0024_0024s540_0024call_00242414_002420913 != null)
							{
								_0024_0024iterator_002413968_002420917 = _0024_0024s540_0024call_00242414_002420913;
								goto case 5;
							}
							goto IL_02ed;
						}
						goto end_IL_0000;
					}
					_0024self__002420923.stop(_0024_0024CUR_EXEC_0024_002420905);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0336;
				IL_0335:
				result = (flag ? 1 : 0);
				goto IL_0336;
				IL_0336:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413966_002420915.Dispose();
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

		internal NPCControl _0024c_002420924;

		internal object _0024charname_002420925;

		internal object _0024message_002420926;

		internal bool _0024furimuki_002420927;

		internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024_0024INNER_BLOCK_0024_002420928;

		internal TutorialEvent _0024self__002420929;

		public _0024S540_npcchat_002420903(NPCControl c, object charname, object message, bool furimuki, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024, TutorialEvent self_)
		{
			_0024c_002420924 = c;
			_0024charname_002420925 = charname;
			_0024message_002420926 = message;
			_0024furimuki_002420927 = furimuki;
			_0024_0024INNER_BLOCK_0024_002420928 = _0024INNER_BLOCK_0024;
			_0024self__002420929 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002420924, _0024charname_002420925, _0024message_002420926, _0024furimuki_002420927, _0024_0024INNER_BLOCK_0024_002420928, _0024self__002420929);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npc_002420930 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242424_002420931;

			internal object _0024___item_002420932;

			internal IEnumerator _0024_0024iterator_002413969_002420933;

			internal object _0024speaker_002420934;

			internal object _0024msg_002420935;

			internal object _0024windowType_002420936;

			internal TutorialEvent _0024self__002420937;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002420934 = speaker;
				_0024msg_002420935 = msg;
				_0024windowType_002420936 = windowType;
				_0024self__002420937 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242424_002420931 = _0024self__002420937.S540_npc(_0024speaker_002420934, _0024msg_002420935, _0024windowType_002420936, null);
					if (_0024_0024s540_0024ycode_00242424_002420931 != null)
					{
						_0024_0024iterator_002413969_002420933 = _0024_0024s540_0024ycode_00242424_002420931;
						goto case 2;
					}
					goto IL_008a;
				case 2:
					if (_0024_0024iterator_002413969_002420933.MoveNext())
					{
						_0024___item_002420932 = _0024_0024iterator_002413969_002420933.Current;
						result = (Yield(2, _0024___item_002420932) ? 1 : 0);
						break;
					}
					goto IL_008a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002420938;

		internal object _0024msg_002420939;

		internal object _0024windowType_002420940;

		internal TutorialEvent _0024self__002420941;

		public _0024S540_npc_002420930(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002420938 = speaker;
			_0024msg_002420939 = msg;
			_0024windowType_002420940 = windowType;
			_0024self__002420941 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002420938, _0024msg_002420939, _0024windowType_002420940, _0024self__002420941);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_npc_002420942 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420943;

			internal Exec _0024_0024CUR_EXEC_0024_002420944;

			internal Exec _0024_0024s540_0024call_00242419_002420945;

			internal IEnumerator _0024_0024s540_0024call_00242418_002420946;

			internal object _0024_0024s540_0024call_00242420_002420947;

			internal Exec _0024_0024s540_0024call_00242422_002420948;

			internal IEnumerator _0024_0024s540_0024call_00242421_002420949;

			internal object _0024_0024s540_0024call_00242423_002420950;

			internal IEnumerator _0024_0024iterator_002413970_002420951;

			internal IEnumerator _0024_0024iterator_002413971_002420952;

			internal object _0024speaker_002420953;

			internal object _0024msg_002420954;

			internal object _0024windowType_002420955;

			internal TutorialEvent _0024self__002420956;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002420953 = speaker;
				_0024msg_002420954 = msg;
				_0024windowType_002420955 = windowType;
				_0024self__002420956 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024STATE_NAME_0024_002420943 = "S540_npc";
					_0024_0024CUR_EXEC_0024_002420944 = _0024self__002420956.lastCreatedExec;
					isBusy = true;
					TheWorld.StopWorldAll(_0024self__002420956);
					BattleHUD.HideTemporary();
					_0024self__002420956.dtrace(_0024_0024CUR_EXEC_0024_002420944, "TutorialEvent.boo:1465", "call命令");
					_0024_0024s540_0024call_00242419_002420945 = _0024self__002420956.createExec("S540_chat", _0024_0024CUR_EXEC_0024_002420944);
					TutorialEvent tutorialEvent = _0024self__002420956;
					object obj = _0024speaker_002420953;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string speaker = (string)obj;
					object obj2 = _0024msg_002420954;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024_0024s540_0024call_00242418_002420946 = tutorialEvent.S540_chat(speaker, (string)obj2, RuntimeServices.UnboxInt32(_0024windowType_002420955));
					if (_0024_0024s540_0024call_00242418_002420946 != null)
					{
						_0024_0024iterator_002413970_002420951 = _0024_0024s540_0024call_00242418_002420946;
						goto case 2;
					}
					goto IL_0139;
				}
				case 2:
					if (_0024_0024iterator_002413970_002420951.MoveNext())
					{
						_0024_0024s540_0024call_00242420_002420947 = _0024_0024iterator_002413970_002420951.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242420_002420947) ? 1 : 0);
						break;
					}
					goto IL_0139;
				case 3:
					if (_0024_0024iterator_002413971_002420952.MoveNext())
					{
						_0024_0024s540_0024call_00242423_002420950 = _0024_0024iterator_002413971_002420952.Current;
						result = (Yield(3, _0024_0024s540_0024call_00242423_002420950) ? 1 : 0);
						break;
					}
					goto IL_01eb;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0139:
					if (!_0024self__002420956.isExecuting(_0024_0024CUR_EXEC_0024_002420944))
					{
						goto case 1;
					}
					_0024self__002420956.dtrace(_0024_0024CUR_EXEC_0024_002420944, "TutorialEvent.boo:1466", "call命令");
					_0024_0024s540_0024call_00242422_002420948 = _0024self__002420956.createExec("S540_chat_close", _0024_0024CUR_EXEC_0024_002420944);
					_0024_0024s540_0024call_00242421_002420949 = _0024self__002420956.S540_chat_close();
					if (_0024_0024s540_0024call_00242421_002420949 != null)
					{
						_0024_0024iterator_002413971_002420952 = _0024_0024s540_0024call_00242421_002420949;
						goto case 3;
					}
					goto IL_01eb;
					IL_01eb:
					if (_0024self__002420956.isExecuting(_0024_0024CUR_EXEC_0024_002420944))
					{
						BattleHUD.RestoreTemporaryHide();
						TheWorld.RestartWorld();
						isBusy = false;
						_0024self__002420956.stop(_0024_0024CUR_EXEC_0024_002420944);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002420957;

		internal object _0024msg_002420958;

		internal object _0024windowType_002420959;

		internal TutorialEvent _0024self__002420960;

		public _0024S540_npc_002420942(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002420957 = speaker;
			_0024msg_002420958 = msg;
			_0024windowType_002420959 = windowType;
			_0024self__002420960 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002420957, _0024msg_002420958, _0024windowType_002420959, _0024self__002420960);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_npc_002420961 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242428_002420962;

			internal object _0024___item_002420963;

			internal IEnumerator _0024_0024iterator_002413972_002420964;

			internal object _0024speaker_002420965;

			internal object _0024msg_002420966;

			internal object _0024windowType_002420967;

			internal TutorialEvent _0024self__002420968;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002420965 = speaker;
				_0024msg_002420966 = msg;
				_0024windowType_002420967 = windowType;
				_0024self__002420968 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242428_002420962 = _0024self__002420968.S540_tutorial_npc(_0024speaker_002420965, _0024msg_002420966, _0024windowType_002420967, null);
					if (_0024_0024s540_0024ycode_00242428_002420962 != null)
					{
						_0024_0024iterator_002413972_002420964 = _0024_0024s540_0024ycode_00242428_002420962;
						goto case 2;
					}
					goto IL_008a;
				case 2:
					if (_0024_0024iterator_002413972_002420964.MoveNext())
					{
						_0024___item_002420963 = _0024_0024iterator_002413972_002420964.Current;
						result = (Yield(2, _0024___item_002420963) ? 1 : 0);
						break;
					}
					goto IL_008a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002420969;

		internal object _0024msg_002420970;

		internal object _0024windowType_002420971;

		internal TutorialEvent _0024self__002420972;

		public _0024S540_tutorial_npc_002420961(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002420969 = speaker;
			_0024msg_002420970 = msg;
			_0024windowType_002420971 = windowType;
			_0024self__002420972 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002420969, _0024msg_002420970, _0024windowType_002420971, _0024self__002420972);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_tutorial_npc_002420973 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420974;

			internal Exec _0024_0024CUR_EXEC_0024_002420975;

			internal Exec _0024_0024s540_0024call_00242426_002420976;

			internal IEnumerator _0024_0024s540_0024call_00242425_002420977;

			internal object _0024_0024s540_0024call_00242427_002420978;

			internal IEnumerator _0024_0024iterator_002413973_002420979;

			internal object _0024speaker_002420980;

			internal object _0024msg_002420981;

			internal object _0024windowType_002420982;

			internal TutorialEvent _0024self__002420983;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002420980 = speaker;
				_0024msg_002420981 = msg;
				_0024windowType_002420982 = windowType;
				_0024self__002420983 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024STATE_NAME_0024_002420974 = "S540_tutorial_npc";
					_0024_0024CUR_EXEC_0024_002420975 = _0024self__002420983.lastCreatedExec;
					isBusy = true;
					TheWorld.StopWorldAll(_0024self__002420983);
					_0024self__002420983.dtrace(_0024_0024CUR_EXEC_0024_002420975, "TutorialEvent.boo:1477", "call命令");
					_0024_0024s540_0024call_00242426_002420976 = _0024self__002420983.createExec("S540_chat", _0024_0024CUR_EXEC_0024_002420975);
					TutorialEvent tutorialEvent = _0024self__002420983;
					object obj = _0024speaker_002420980;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string speaker = (string)obj;
					object obj2 = _0024msg_002420981;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024_0024s540_0024call_00242425_002420977 = tutorialEvent.S540_chat(speaker, (string)obj2, RuntimeServices.UnboxInt32(_0024windowType_002420982));
					if (_0024_0024s540_0024call_00242425_002420977 != null)
					{
						_0024_0024iterator_002413973_002420979 = _0024_0024s540_0024call_00242425_002420977;
						goto case 2;
					}
					goto IL_0130;
				}
				case 2:
					if (_0024_0024iterator_002413973_002420979.MoveNext())
					{
						_0024_0024s540_0024call_00242427_002420978 = _0024_0024iterator_002413973_002420979.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242427_002420978) ? 1 : 0);
						break;
					}
					goto IL_0130;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0130:
					if (_0024self__002420983.isExecuting(_0024_0024CUR_EXEC_0024_002420975))
					{
						TheWorld.RestartWorld();
						isBusy = false;
						_0024self__002420983.stop(_0024_0024CUR_EXEC_0024_002420975);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002420984;

		internal object _0024msg_002420985;

		internal object _0024windowType_002420986;

		internal TutorialEvent _0024self__002420987;

		public _0024S540_tutorial_npc_002420973(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002420984 = speaker;
			_0024msg_002420985 = msg;
			_0024windowType_002420986 = windowType;
			_0024self__002420987 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002420984, _0024msg_002420985, _0024windowType_002420986, _0024self__002420987);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_call_tutorials_002420988 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242435_002420989;

			internal object _0024___item_002420990;

			internal IEnumerator _0024_0024iterator_002413974_002420991;

			internal object _0024progname_002420992;

			internal TutorialEvent _0024self__002420993;

			public _0024(object progname, TutorialEvent self_)
			{
				_0024progname_002420992 = progname;
				_0024self__002420993 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242435_002420989 = _0024self__002420993.S540_call_tutorials(_0024progname_002420992, null);
					if (_0024_0024s540_0024ycode_00242435_002420989 != null)
					{
						_0024_0024iterator_002413974_002420991 = _0024_0024s540_0024ycode_00242435_002420989;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413974_002420991.MoveNext())
					{
						_0024___item_002420990 = _0024_0024iterator_002413974_002420991.Current;
						result = (Yield(2, _0024___item_002420990) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024progname_002420994;

		internal TutorialEvent _0024self__002420995;

		public _0024S540_call_tutorials_002420988(object progname, TutorialEvent self_)
		{
			_0024progname_002420994 = progname;
			_0024self__002420995 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024progname_002420994, _0024self__002420995);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_call_tutorials_002420996 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002420997;

			internal Exec _0024_0024CUR_EXEC_0024_002420998;

			internal MTutorials _0024mstTuto_002420999;

			internal MTutorialMessages[] _0024tutoMsgs_002421000;

			internal bool _0024worldStop_002421001;

			internal string _0024prefabName_002421002;

			internal MTutorialMessages _0024tutoMsg_002421003;

			internal string _0024speaker_002421004;

			internal string _0024msg_002421005;

			internal int _0024windowType_002421006;

			internal string _0024nextPrefabName_002421007;

			internal bool _0024prefabFlag_002421008;

			internal Exec _0024_0024s540_0024call_00242430_002421009;

			internal IEnumerator _0024_0024s540_0024call_00242429_002421010;

			internal object _0024_0024s540_0024call_00242431_002421011;

			internal Exec _0024_0024s540_0024call_00242433_002421012;

			internal IEnumerator _0024_0024s540_0024call_00242432_002421013;

			internal object _0024_0024s540_0024call_00242434_002421014;

			internal int _0024_002410268_002421015;

			internal MTutorialMessages[] _0024_002410269_002421016;

			internal int _0024_002410270_002421017;

			internal IEnumerator _0024_0024iterator_002413975_002421018;

			internal IEnumerator _0024_0024iterator_002413976_002421019;

			internal _0024S540_call_tutorials_0024locals_002414460 _0024_0024locals_002421020;

			internal object _0024progname_002421021;

			internal TutorialEvent _0024self__002421022;

			public _0024(object progname, TutorialEvent self_)
			{
				_0024progname_002421021 = progname;
				_0024self__002421022 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						_0024_0024locals_002421020 = new _0024S540_call_tutorials_0024locals_002414460();
						_0024_0024STATE_NAME_0024_002420997 = "S540_call_tutorials";
						_0024_0024CUR_EXEC_0024_002420998 = _0024self__002421022.lastCreatedExec;
						object obj = _0024progname_002421021;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024mstTuto_002420999 = MasterUtil.FindTutorial((string)obj);
						if (_0024mstTuto_002420999 == null)
						{
							_0024self__002421022.stop(_0024_0024CUR_EXEC_0024_002420998);
						}
						else
						{
							_0024tutoMsgs_002421000 = _0024mstTuto_002420999.AllTutorialMessages;
							if (!(null == _0024tutoMsgs_002421000))
							{
								_0024worldStop_002421001 = false;
								_0024prefabName_002421002 = string.Empty;
								_0024_0024locals_002421020._0024prefabObj = null;
								if (!string.IsNullOrEmpty(_0024mstTuto_002420999.PrefabName))
								{
									_0024_0024locals_002421020._0024ok = false;
									TutorialUI.PutAssetBundleGameObject(1, _0024mstTuto_002420999.PrefabName, new _0024S540_call_tutorials_0024closure_00243257(_0024_0024locals_002421020).Invoke);
									goto IL_015f;
								}
								goto IL_016f;
							}
							_0024self__002421022.stop(_0024_0024CUR_EXEC_0024_002420998);
						}
						goto case 1;
					}
					case 2:
						if (!_0024_0024CUR_EXEC_0024_002420998.NotExecuting)
						{
							goto IL_015f;
						}
						goto case 1;
					case 3:
						if (!_0024_0024CUR_EXEC_0024_002420998.NotExecuting)
						{
							goto IL_035c;
						}
						goto case 1;
					case 4:
						if (_0024_0024iterator_002413975_002421018.MoveNext())
						{
							_0024_0024s540_0024call_00242431_002421011 = _0024_0024iterator_002413975_002421018.Current;
							result = (Yield(4, _0024_0024s540_0024call_00242431_002421011) ? 1 : 0);
							break;
						}
						goto IL_0448;
					case 5:
						if (_0024_0024iterator_002413976_002421019.MoveNext())
						{
							_0024_0024s540_0024call_00242434_002421014 = _0024_0024iterator_002413976_002421019.Current;
							result = (Yield(5, _0024_0024s540_0024call_00242434_002421014) ? 1 : 0);
							break;
						}
						goto IL_053b;
					case 1:
						{
							result = 0;
							break;
						}
						IL_035c:
						if (!_0024_0024locals_002421020._0024ok)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024prefabName_002421002 = _0024nextPrefabName_002421007;
						goto IL_0378;
						IL_0469:
						_0024_002410268_002421015++;
						goto IL_0477;
						IL_0448:
						if (!_0024self__002421022.isExecuting(_0024_0024CUR_EXEC_0024_002420998))
						{
							goto case 1;
						}
						isBusy = false;
						goto IL_0469;
						IL_039f:
						_0024self__002421022.dtrace(_0024_0024CUR_EXEC_0024_002420998, "TutorialEvent.boo:1538", "call命令");
						_0024_0024s540_0024call_00242430_002421009 = _0024self__002421022.createExec("S540_chat", _0024_0024CUR_EXEC_0024_002420998);
						_0024_0024s540_0024call_00242429_002421010 = _0024self__002421022.S540_chat(_0024speaker_002421004, _0024msg_002421005, _0024windowType_002421006);
						if (_0024_0024s540_0024call_00242429_002421010 != null)
						{
							_0024_0024iterator_002413975_002421018 = _0024_0024s540_0024call_00242429_002421010;
							goto case 4;
						}
						goto IL_0448;
						IL_053b:
						if (_0024self__002421022.isExecuting(_0024_0024CUR_EXEC_0024_002420998))
						{
							_0024self__002421022.stop(_0024_0024CUR_EXEC_0024_002420998);
						}
						goto case 1;
						IL_015f:
						if (!_0024_0024locals_002421020._0024ok)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_016f;
						IL_0378:
						if (null != _0024_0024locals_002421020._0024prefabObj)
						{
							_0024_0024locals_002421020._0024prefabObj.SetActive(value: true);
						}
						goto IL_039f;
						IL_016f:
						_0024_002410268_002421015 = 0;
						_0024_002410269_002421016 = _0024tutoMsgs_002421000;
						_0024_002410270_002421017 = _0024_002410269_002421016.Length;
						goto IL_0477;
						IL_0477:
						if (_0024_002410268_002421015 < _0024_002410270_002421017)
						{
							if (_0024_002410269_002421016[_0024_002410268_002421015] == null)
							{
								goto IL_0469;
							}
							if (_0024mstTuto_002420999.WorldStopFlag || _0024mstTuto_002420999.WorldStopFlag)
							{
								if (!_0024worldStop_002421001)
								{
									_0024worldStop_002421001 = true;
									TheWorld.StopWorldAll(_0024self__002421022);
								}
							}
							else if (_0024worldStop_002421001)
							{
								_0024worldStop_002421001 = false;
								TheWorld.RestartWorld();
							}
							isBusy = true;
							_0024speaker_002421004 = _0024_002410269_002421016[_0024_002410268_002421015].GetTitle();
							_0024msg_002421005 = _0024_002410269_002421016[_0024_002410268_002421015].GetText();
							unchecked
							{
								_0024windowType_002421006 = (int)checked(_0024_002410269_002421016[_0024_002410268_002421015].WindowType - 1);
								_0024nextPrefabName_002421007 = _0024_002410269_002421016[_0024_002410268_002421015].PrefabName;
								_0024prefabFlag_002421008 = _0024_002410269_002421016[_0024_002410268_002421015].PrefabFlag;
								if (!string.IsNullOrEmpty(_0024nextPrefabName_002421007))
								{
									_0024prefabFlag_002421008 = true;
								}
								if (!_0024prefabFlag_002421008)
								{
									if (null != _0024_0024locals_002421020._0024prefabObj)
									{
										_0024_0024locals_002421020._0024prefabObj.SetActive(value: false);
									}
									goto IL_039f;
								}
								if (!string.IsNullOrEmpty(_0024nextPrefabName_002421007) && _0024nextPrefabName_002421007 != _0024prefabName_002421002)
								{
									_0024_0024locals_002421020._0024prefabObj = null;
									_0024_0024locals_002421020._0024ok = false;
									TutorialUI.PutAssetBundleGameObject(2, _0024nextPrefabName_002421007, new _0024S540_call_tutorials_0024closure_00243258(_0024_0024locals_002421020).Invoke);
									goto IL_035c;
								}
								goto IL_0378;
							}
						}
						if (_0024worldStop_002421001)
						{
							TheWorld.RestartWorld();
						}
						TutorialUI.DestroyAssetBundleGameObject(1);
						TutorialUI.DestroyAssetBundleGameObject(2);
						_0024self__002421022.dtrace(_0024_0024CUR_EXEC_0024_002420998, "TutorialEvent.boo:1546", "call命令");
						_0024_0024s540_0024call_00242433_002421012 = _0024self__002421022.createExec("S540_message_end", _0024_0024CUR_EXEC_0024_002420998);
						_0024_0024s540_0024call_00242432_002421013 = _0024self__002421022.S540_message_end();
						if (_0024_0024s540_0024call_00242432_002421013 != null)
						{
							_0024_0024iterator_002413976_002421019 = _0024_0024s540_0024call_00242432_002421013;
							goto case 5;
						}
						goto IL_053b;
					}
				}
				return (byte)result != 0;
			}
		}

		internal object _0024progname_002421023;

		internal TutorialEvent _0024self__002421024;

		public _0024S540_call_tutorials_002420996(object progname, TutorialEvent self_)
		{
			_0024progname_002421023 = progname;
			_0024self__002421024 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024progname_002421023, _0024self__002421024);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_gatya_npc_002421025 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242439_002421026;

			internal object _0024___item_002421027;

			internal IEnumerator _0024_0024iterator_002413977_002421028;

			internal object _0024speaker_002421029;

			internal object _0024msg_002421030;

			internal object _0024windowType_002421031;

			internal TutorialEvent _0024self__002421032;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002421029 = speaker;
				_0024msg_002421030 = msg;
				_0024windowType_002421031 = windowType;
				_0024self__002421032 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242439_002421026 = _0024self__002421032.S540_gatya_npc(_0024speaker_002421029, _0024msg_002421030, _0024windowType_002421031, null);
					if (_0024_0024s540_0024ycode_00242439_002421026 != null)
					{
						_0024_0024iterator_002413977_002421028 = _0024_0024s540_0024ycode_00242439_002421026;
						goto case 2;
					}
					goto IL_008a;
				case 2:
					if (_0024_0024iterator_002413977_002421028.MoveNext())
					{
						_0024___item_002421027 = _0024_0024iterator_002413977_002421028.Current;
						result = (Yield(2, _0024___item_002421027) ? 1 : 0);
						break;
					}
					goto IL_008a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002421033;

		internal object _0024msg_002421034;

		internal object _0024windowType_002421035;

		internal TutorialEvent _0024self__002421036;

		public _0024S540_gatya_npc_002421025(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002421033 = speaker;
			_0024msg_002421034 = msg;
			_0024windowType_002421035 = windowType;
			_0024self__002421036 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002421033, _0024msg_002421034, _0024windowType_002421035, _0024self__002421036);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_gatya_npc_002421037 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421038;

			internal Exec _0024_0024CUR_EXEC_0024_002421039;

			internal Exec _0024_0024s540_0024call_00242437_002421040;

			internal IEnumerator _0024_0024s540_0024call_00242436_002421041;

			internal object _0024_0024s540_0024call_00242438_002421042;

			internal IEnumerator _0024_0024iterator_002413978_002421043;

			internal object _0024speaker_002421044;

			internal object _0024msg_002421045;

			internal object _0024windowType_002421046;

			internal TutorialEvent _0024self__002421047;

			public _0024(object speaker, object msg, object windowType, TutorialEvent self_)
			{
				_0024speaker_002421044 = speaker;
				_0024msg_002421045 = msg;
				_0024windowType_002421046 = windowType;
				_0024self__002421047 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024STATE_NAME_0024_002421038 = "S540_gatya_npc";
					_0024_0024CUR_EXEC_0024_002421039 = _0024self__002421047.lastCreatedExec;
					_0024self__002421047.dtrace(_0024_0024CUR_EXEC_0024_002421039, "TutorialEvent.boo:1550", "call命令");
					_0024_0024s540_0024call_00242437_002421040 = _0024self__002421047.createExec("S540_chat", _0024_0024CUR_EXEC_0024_002421039);
					TutorialEvent tutorialEvent = _0024self__002421047;
					object obj = _0024speaker_002421044;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string speaker = (string)obj;
					object obj2 = _0024msg_002421045;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024_0024s540_0024call_00242436_002421041 = tutorialEvent.S540_chat(speaker, (string)obj2, RuntimeServices.UnboxInt32(_0024windowType_002421046));
					if (_0024_0024s540_0024call_00242436_002421041 != null)
					{
						_0024_0024iterator_002413978_002421043 = _0024_0024s540_0024call_00242436_002421041;
						goto case 2;
					}
					goto IL_011f;
				}
				case 2:
					if (_0024_0024iterator_002413978_002421043.MoveNext())
					{
						_0024_0024s540_0024call_00242438_002421042 = _0024_0024iterator_002413978_002421043.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242438_002421042) ? 1 : 0);
						break;
					}
					goto IL_011f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_011f:
					if (_0024self__002421047.isExecuting(_0024_0024CUR_EXEC_0024_002421039))
					{
						_0024self__002421047.stop(_0024_0024CUR_EXEC_0024_002421039);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024speaker_002421048;

		internal object _0024msg_002421049;

		internal object _0024windowType_002421050;

		internal TutorialEvent _0024self__002421051;

		public _0024S540_gatya_npc_002421037(object speaker, object msg, object windowType, TutorialEvent self_)
		{
			_0024speaker_002421048 = speaker;
			_0024msg_002421049 = msg;
			_0024windowType_002421050 = windowType;
			_0024self__002421051 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002421048, _0024msg_002421049, _0024windowType_002421050, _0024self__002421051);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_message_end_002421052 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242443_002421053;

			internal object _0024___item_002421054;

			internal IEnumerator _0024_0024iterator_002413979_002421055;

			internal TutorialEvent _0024self__002421056;

			public _0024(TutorialEvent self_)
			{
				_0024self__002421056 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242443_002421053 = _0024self__002421056.S540_message_end(null);
					if (_0024_0024s540_0024ycode_00242443_002421053 != null)
					{
						_0024_0024iterator_002413979_002421055 = _0024_0024s540_0024ycode_00242443_002421053;
						goto case 2;
					}
					goto IL_0078;
				case 2:
					if (_0024_0024iterator_002413979_002421055.MoveNext())
					{
						_0024___item_002421054 = _0024_0024iterator_002413979_002421055.Current;
						result = (Yield(2, _0024___item_002421054) ? 1 : 0);
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

		internal TutorialEvent _0024self__002421057;

		public _0024S540_message_end_002421052(TutorialEvent self_)
		{
			_0024self__002421057 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421057);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_message_end_002421058 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421059;

			internal Exec _0024_0024CUR_EXEC_0024_002421060;

			internal Exec _0024_0024s540_0024call_00242441_002421061;

			internal IEnumerator _0024_0024s540_0024call_00242440_002421062;

			internal object _0024_0024s540_0024call_00242442_002421063;

			internal IEnumerator _0024_0024iterator_002413980_002421064;

			internal TutorialEvent _0024self__002421065;

			public _0024(TutorialEvent self_)
			{
				_0024self__002421065 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002421059 = "S540_message_end";
					_0024_0024CUR_EXEC_0024_002421060 = _0024self__002421065.lastCreatedExec;
					_0024self__002421065.dtrace(_0024_0024CUR_EXEC_0024_002421060, "TutorialEvent.boo:1553", "call命令");
					_0024_0024s540_0024call_00242441_002421061 = _0024self__002421065.createExec("S540_chat_close", _0024_0024CUR_EXEC_0024_002421060);
					_0024_0024s540_0024call_00242440_002421062 = _0024self__002421065.S540_chat_close();
					if (_0024_0024s540_0024call_00242440_002421062 != null)
					{
						_0024_0024iterator_002413980_002421064 = _0024_0024s540_0024call_00242440_002421062;
						goto case 2;
					}
					goto IL_00ca;
				case 2:
					if (_0024_0024iterator_002413980_002421064.MoveNext())
					{
						_0024_0024s540_0024call_00242442_002421063 = _0024_0024iterator_002413980_002421064.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242442_002421063) ? 1 : 0);
						break;
					}
					goto IL_00ca;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ca:
					if (_0024self__002421065.isExecuting(_0024_0024CUR_EXEC_0024_002421060))
					{
						TheWorld.RestartWorld();
						isBusy = false;
						_0024self__002421065.stop(_0024_0024CUR_EXEC_0024_002421060);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TutorialEvent _0024self__002421066;

		public _0024S540_message_end_002421058(TutorialEvent self_)
		{
			_0024self__002421066 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421066);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_sysmsg_002421067 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242444_002421068;

			internal object _0024___item_002421069;

			internal IEnumerator _0024_0024iterator_002413981_002421070;

			internal object _0024msg_002421071;

			internal TutorialEvent _0024self__002421072;

			public _0024(object msg, TutorialEvent self_)
			{
				_0024msg_002421071 = msg;
				_0024self__002421072 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242444_002421068 = _0024self__002421072.S540_sysmsg(_0024msg_002421071, null);
					if (_0024_0024s540_0024ycode_00242444_002421068 != null)
					{
						_0024_0024iterator_002413981_002421070 = _0024_0024s540_0024ycode_00242444_002421068;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413981_002421070.MoveNext())
					{
						_0024___item_002421069 = _0024_0024iterator_002413981_002421070.Current;
						result = (Yield(2, _0024___item_002421069) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024msg_002421073;

		internal TutorialEvent _0024self__002421074;

		public _0024S540_sysmsg_002421067(object msg, TutorialEvent self_)
		{
			_0024msg_002421073 = msg;
			_0024self__002421074 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg_002421073, _0024self__002421074);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_sysmsg_002421075 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421076;

			internal Exec _0024_0024CUR_EXEC_0024_002421077;

			internal object _0024msg_002421078;

			internal TutorialEvent _0024self__002421079;

			public _0024(object msg, TutorialEvent self_)
			{
				_0024msg_002421078 = msg;
				_0024self__002421079 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024STATE_NAME_0024_002421076 = "S540_sysmsg";
					_0024_0024CUR_EXEC_0024_002421077 = _0024self__002421079.lastCreatedExec;
					isBusy = true;
					TheWorld.StopWorldAll(_0024self__002421079);
					DialogManager dlgMan = _0024self__002421079.dlgMan;
					object obj = _0024msg_002421078;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					dlgMan.OpenDialog((string)obj, string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
					goto IL_00b4;
				}
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002421077.NotExecuting)
					{
						goto IL_00b4;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b4:
					if (0 > DialogManager.LastResult)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					TheWorld.RestartWorld();
					isBusy = false;
					_0024self__002421079.stop(_0024_0024CUR_EXEC_0024_002421077);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024msg_002421080;

		internal TutorialEvent _0024self__002421081;

		public _0024S540_sysmsg_002421075(object msg, TutorialEvent self_)
		{
			_0024msg_002421080 = msg;
			_0024self__002421081 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024msg_002421080, _0024self__002421081);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_message_stop_002421082 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242448_002421083;

			internal object _0024___item_002421084;

			internal IEnumerator _0024_0024iterator_002413982_002421085;

			internal object _0024pop_002421086;

			internal object _0024msg_002421087;

			internal TutorialEvent _0024self__002421088;

			public _0024(object pop, object msg, TutorialEvent self_)
			{
				_0024pop_002421086 = pop;
				_0024msg_002421087 = msg;
				_0024self__002421088 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242448_002421083 = _0024self__002421088.S540_message_stop(_0024pop_002421086, _0024msg_002421087, null);
					if (_0024_0024s540_0024ycode_00242448_002421083 != null)
					{
						_0024_0024iterator_002413982_002421085 = _0024_0024s540_0024ycode_00242448_002421083;
						goto case 2;
					}
					goto IL_0084;
				case 2:
					if (_0024_0024iterator_002413982_002421085.MoveNext())
					{
						_0024___item_002421084 = _0024_0024iterator_002413982_002421085.Current;
						result = (Yield(2, _0024___item_002421084) ? 1 : 0);
						break;
					}
					goto IL_0084;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0084:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024pop_002421089;

		internal object _0024msg_002421090;

		internal TutorialEvent _0024self__002421091;

		public _0024S540_message_stop_002421082(object pop, object msg, TutorialEvent self_)
		{
			_0024pop_002421089 = pop;
			_0024msg_002421090 = msg;
			_0024self__002421091 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024pop_002421089, _0024msg_002421090, _0024self__002421091);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_message_stop_002421092 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421093;

			internal Exec _0024_0024CUR_EXEC_0024_002421094;

			internal Exec _0024_0024s540_0024call_00242446_002421095;

			internal IEnumerator _0024_0024s540_0024call_00242445_002421096;

			internal object _0024_0024s540_0024call_00242447_002421097;

			internal IEnumerator _0024_0024iterator_002413983_002421098;

			internal object _0024pop_002421099;

			internal object _0024msg_002421100;

			internal TutorialEvent _0024self__002421101;

			public _0024(object pop, object msg, TutorialEvent self_)
			{
				_0024pop_002421099 = pop;
				_0024msg_002421100 = msg;
				_0024self__002421101 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002421093 = "S540_message_stop";
					_0024_0024CUR_EXEC_0024_002421094 = _0024self__002421101.lastCreatedExec;
					RuntimeServices.SetProperty(_0024pop_002421099, "Text", _0024msg_002421100);
					RuntimeServices.Invoke(_0024pop_002421099, "startBigSizeAnimation", new object[0]);
					_0024self__002421101.dtrace(_0024_0024CUR_EXEC_0024_002421094, "TutorialEvent.boo:1571", "call命令");
					_0024_0024s540_0024call_00242446_002421095 = _0024self__002421101.createExec("S540_stop", _0024_0024CUR_EXEC_0024_002421094);
					_0024_0024s540_0024call_00242445_002421096 = _0024self__002421101.S540_stop(1);
					if (_0024_0024s540_0024call_00242445_002421096 != null)
					{
						_0024_0024iterator_002413983_002421098 = _0024_0024s540_0024call_00242445_002421096;
						goto case 2;
					}
					goto IL_00fe;
				case 2:
					if (_0024_0024iterator_002413983_002421098.MoveNext())
					{
						_0024_0024s540_0024call_00242447_002421097 = _0024_0024iterator_002413983_002421098.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242447_002421097) ? 1 : 0);
						break;
					}
					goto IL_00fe;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00fe:
					if (_0024self__002421101.isExecuting(_0024_0024CUR_EXEC_0024_002421094))
					{
						_0024self__002421101.stop(_0024_0024CUR_EXEC_0024_002421094);
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024pop_002421102;

		internal object _0024msg_002421103;

		internal TutorialEvent _0024self__002421104;

		public _0024S540_message_stop_002421092(object pop, object msg, TutorialEvent self_)
		{
			_0024pop_002421102 = pop;
			_0024msg_002421103 = msg;
			_0024self__002421104 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024pop_002421102, _0024msg_002421103, _0024self__002421104);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_stop_002421105 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242450_002421106;

			internal object _0024___item_002421107;

			internal IEnumerator _0024_0024iterator_002413984_002421108;

			internal object _0024time_002421109;

			internal TutorialEvent _0024self__002421110;

			public _0024(object time, TutorialEvent self_)
			{
				_0024time_002421109 = time;
				_0024self__002421110 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242450_002421106 = _0024self__002421110.S540_stop(_0024time_002421109, null);
					if (_0024_0024s540_0024ycode_00242450_002421106 != null)
					{
						_0024_0024iterator_002413984_002421108 = _0024_0024s540_0024ycode_00242450_002421106;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413984_002421108.MoveNext())
					{
						_0024___item_002421107 = _0024_0024iterator_002413984_002421108.Current;
						result = (Yield(2, _0024___item_002421107) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024time_002421111;

		internal TutorialEvent _0024self__002421112;

		public _0024S540_stop_002421105(object time, TutorialEvent self_)
		{
			_0024time_002421111 = time;
			_0024self__002421112 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024time_002421111, _0024self__002421112);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_stop_002421113 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421114;

			internal Exec _0024_0024CUR_EXEC_0024_002421115;

			internal float _0024_0024wait_sec_0024temp_00242449_002421116;

			internal object _0024time_002421117;

			internal TutorialEvent _0024self__002421118;

			public _0024(object time, TutorialEvent self_)
			{
				_0024time_002421117 = time;
				_0024self__002421118 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002421114 = "S540_stop";
					_0024_0024CUR_EXEC_0024_002421115 = _0024self__002421118.lastCreatedExec;
					isBusy = true;
					TheWorld.StopWorldAll(_0024self__002421118);
					_0024_0024wait_sec_0024temp_00242449_002421116 = RuntimeServices.UnboxSingle(_0024time_002421117);
					goto IL_008d;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002421115.NotExecuting)
					{
						goto IL_008d;
					}
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_008d:
					if (_0024_0024wait_sec_0024temp_00242449_002421116 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242449_002421116 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					TheWorld.RestartWorld();
					isBusy = false;
					_0024self__002421118.stop(_0024_0024CUR_EXEC_0024_002421115);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal object _0024time_002421119;

		internal TutorialEvent _0024self__002421120;

		public _0024S540_stop_002421113(object time, TutorialEvent self_)
		{
			_0024time_002421119 = time;
			_0024self__002421120 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024time_002421119, _0024self__002421120);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_wait_button_002421121 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242451_002421122;

			internal object _0024___item_002421123;

			internal IEnumerator _0024_0024iterator_002413985_002421124;

			internal UIButtonMessage _0024btn_002421125;

			internal TutorialEvent _0024self__002421126;

			public _0024(UIButtonMessage btn, TutorialEvent self_)
			{
				_0024btn_002421125 = btn;
				_0024self__002421126 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242451_002421122 = _0024self__002421126.S540_wait_button(_0024btn_002421125, null);
					if (_0024_0024s540_0024ycode_00242451_002421122 != null)
					{
						_0024_0024iterator_002413985_002421124 = _0024_0024s540_0024ycode_00242451_002421122;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413985_002421124.MoveNext())
					{
						_0024___item_002421123 = _0024_0024iterator_002413985_002421124.Current;
						result = (Yield(2, _0024___item_002421123) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal UIButtonMessage _0024btn_002421127;

		internal TutorialEvent _0024self__002421128;

		public _0024S540_wait_button_002421121(UIButtonMessage btn, TutorialEvent self_)
		{
			_0024btn_002421127 = btn;
			_0024self__002421128 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024btn_002421127, _0024self__002421128);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_wait_button_002421129 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421130;

			internal Exec _0024_0024CUR_EXEC_0024_002421131;

			internal _0024S540_wait_button_0024locals_002414461 _0024_0024locals_002421132;

			internal UIButtonMessage _0024btn_002421133;

			internal TutorialEvent _0024self__002421134;

			public _0024(UIButtonMessage btn, TutorialEvent self_)
			{
				_0024btn_002421133 = btn;
				_0024self__002421134 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421132 = new _0024S540_wait_button_0024locals_002414461();
					_0024_0024STATE_NAME_0024_002421130 = "S540_wait_button";
					_0024_0024CUR_EXEC_0024_002421131 = _0024self__002421134.lastCreatedExec;
					_0024self__002421134.stop(_0024_0024CUR_EXEC_0024_002421131);
					goto case 1;
				case 2:
					if (!_0024_0024CUR_EXEC_0024_002421131.NotExecuting)
					{
						if (!_0024_0024locals_002421132._0024on)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421134.stop(_0024_0024CUR_EXEC_0024_002421131);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal UIButtonMessage _0024btn_002421135;

		internal TutorialEvent _0024self__002421136;

		public _0024S540_wait_button_002421129(UIButtonMessage btn, TutorialEvent self_)
		{
			_0024btn_002421135 = btn;
			_0024self__002421136 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024btn_002421135, _0024self__002421136);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_wait_button_002421137 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024s540_0024ycode_00242455_002421138;

			internal object _0024___item_002421139;

			internal IEnumerator _0024_0024iterator_002413986_002421140;

			internal string _0024objPath_002421141;

			internal TutorialEvent _0024self__002421142;

			public _0024(string objPath, TutorialEvent self_)
			{
				_0024objPath_002421141 = objPath;
				_0024self__002421142 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024s540_0024ycode_00242455_002421138 = _0024self__002421142.S540_wait_button(_0024objPath_002421141, null);
					if (_0024_0024s540_0024ycode_00242455_002421138 != null)
					{
						_0024_0024iterator_002413986_002421140 = _0024_0024s540_0024ycode_00242455_002421138;
						goto case 2;
					}
					goto IL_007e;
				case 2:
					if (_0024_0024iterator_002413986_002421140.MoveNext())
					{
						_0024___item_002421139 = _0024_0024iterator_002413986_002421140.Current;
						result = (Yield(2, _0024___item_002421139) ? 1 : 0);
						break;
					}
					goto IL_007e;
				case 1:
					{
						result = 0;
						break;
					}
					IL_007e:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024objPath_002421143;

		internal TutorialEvent _0024self__002421144;

		public _0024S540_wait_button_002421137(string objPath, TutorialEvent self_)
		{
			_0024objPath_002421143 = objPath;
			_0024self__002421144 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024objPath_002421143, _0024self__002421144);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_wait_button_002421145 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024STATE_NAME_0024_002421146;

			internal Exec _0024_0024CUR_EXEC_0024_002421147;

			internal UIButtonMessage _0024btn_002421148;

			internal Exec _0024_0024s540_0024call_00242453_002421149;

			internal IEnumerator _0024_0024s540_0024call_00242452_002421150;

			internal object _0024_0024s540_0024call_00242454_002421151;

			internal IEnumerator _0024_0024iterator_002413987_002421152;

			internal string _0024objPath_002421153;

			internal TutorialEvent _0024self__002421154;

			public _0024(string objPath, TutorialEvent self_)
			{
				_0024objPath_002421153 = objPath;
				_0024self__002421154 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024STATE_NAME_0024_002421146 = "S540_wait_button";
					_0024_0024CUR_EXEC_0024_002421147 = _0024self__002421154.lastCreatedExec;
					isBusy = true;
					_0024btn_002421148 = ObjUtilModule.FindWithComponent<UIButtonMessage>(_0024objPath_002421153);
					_0024self__002421154.stop(_0024_0024CUR_EXEC_0024_002421147);
					goto case 1;
				case 2:
					if (_0024_0024iterator_002413987_002421152.MoveNext())
					{
						_0024_0024s540_0024call_00242454_002421151 = _0024_0024iterator_002413987_002421152.Current;
						result = (Yield(2, _0024_0024s540_0024call_00242454_002421151) ? 1 : 0);
						break;
					}
					if (_0024self__002421154.isExecuting(_0024_0024CUR_EXEC_0024_002421147))
					{
						isBusy = false;
						_0024self__002421154.stop(_0024_0024CUR_EXEC_0024_002421147);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024objPath_002421155;

		internal TutorialEvent _0024self__002421156;

		public _0024S540_wait_button_002421145(string objPath, TutorialEvent self_)
		{
			_0024objPath_002421155 = objPath;
			_0024self__002421156 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024objPath_002421155, _0024self__002421156);
		}
	}

	[NonSerialized]
	protected static bool isBusy;

	public AIControl mapet;

	[NonSerialized]
	private static readonly int TUTORIAL_WINDOW_TYPE = 5 - 1;

	[NonSerialized]
	private static readonly int TOWN_WINDOW_TYPE = 2 - 1;

	[NonSerialized]
	private static readonly int GATYA_WINDOW_TYPE = 3 - 1;

	[NonSerialized]
	private const string RAID_PLAYER0_PAth = "Prefab/Character/Player/P_RAID_C0000_000_MA_ROOT";

	[NonSerialized]
	private const string RAID_PLAYER1_PAth = "Prefab/Character/Player/P_RAID_C0001_000_MA_ROOT";

	[NonSerialized]
	private const string RAID_PLAYER2_PAth = "Prefab/Character/Player/P_RAID_C0002_000_MA_ROOT";

	[NonSerialized]
	private const string RAID_PLAYER3_PAth = "Prefab/Character/Player/P_RAID_C0003_000_MA_ROOT";

	[NonSerialized]
	public static readonly string[] RAID_PLAYER_NAMES = new string[4] { "Prefab/Character/Player/P_RAID_C0000_000_MA_ROOT", "Prefab/Character/Player/P_RAID_C0001_000_MA_ROOT", "Prefab/Character/Player/P_RAID_C0002_000_MA_ROOT", "Prefab/Character/Player/P_RAID_C0003_000_MA_ROOT" };

	[NonSerialized]
	private const string UI_TUTORIAL_ROOT_LOTTERY_PATH = "Prefab/HUD/Tutorial UI Root Lottery";

	[NonSerialized]
	private const string UI_TUTORIAL_ROOT_QUEST_PATH = "Prefab/HUD/Tutorial UI Root Quest";

	[NonSerialized]
	private const string UI_TUTORIAL_ROOT_BOX_PATH = "Prefab/HUD/Tutorial UI Root Box";

	[NonSerialized]
	private const string UI_TUTORIAL_ROOT_TOWN_PATH = "Prefab/HUD/Tutorial UI Root Town";

	[NonSerialized]
	private static int MountainTutorialStep;

	private DialogManager dlgMan;

	[NonSerialized]
	private const string GATYA_TUTORIAL_FLAG = "s01GatyaTuto";

	[NonSerialized]
	private const string QUEST_MENU_LIST_TUTORIAL_FLAG = "s01QuestMenuListTuto";

	[NonSerialized]
	private const string QUEST_MENU_PET_TUTORIAL_FLAG = "s01QuestMenuPetTuto";

	[NonSerialized]
	private const string QUEST_MENU_CONF_TUTORIAL_FLAG = "s01QuestMenuConfTuto";

	[NonSerialized]
	private const string MAIN001_CLEAR_FLAG = "s01Main001Tuto";

	[NonSerialized]
	private const string BOX_MENU_TUTORIAL_FLAG = "s01BoxTuto";

	[NonSerialized]
	private const string BOX_CUSTOMIZE_MENU_TUTORIAL_FLAG = "s01BoxCustomizeTuto";

	[NonSerialized]
	private const string BOX_LIST_MENU_TUTORIAL_FLAG = "s01BoxListTuto";

	[NonSerialized]
	private const string RAID_MENU_TUTORIAL_FLAG = "s01RaidMenuTuto";

	[NonSerialized]
	private const string SHORTCUT_TUTORIAL_FLAG = "s01ShortcutTuto";

	[NonSerialized]
	private const string GOUSEI_KYOUKA_TUTORIAL_FLAG = "s01GouseiKyoukaTuto";

	[NonSerialized]
	private const string GOUSEI_SHINKA_TUTORIAL_FLAG = "s01GouseiShinkaTuto";

	[NonSerialized]
	private const string DEAD_TUTORIAL_FLAG = "s01DeadTuto";

	[NonSerialized]
	private const string TAMAGOE_TUTORIAL_FLAG = "s01TamagoeTuto";

	[NonSerialized]
	private const string COLOSSEUMU_TOP_TUTORIAL_FLAG = "s01ColosseumTopTuto";

	[NonSerialized]
	private const string COLOSSEUMU_FRIEND_TUTORIAL_FLAG = "s01ColosseumFriendTuto";

	[NonSerialized]
	private const string COLOSSEUMU_CONF_TUTORIAL_FLAG = "s01ColosseumConfTuto";

	[NonSerialized]
	private const string SCENE_NAME_RAID_TUTORIAL = "RaidStory003";

	[NonSerialized]
	private const string SCENE_NAME_RAID_MENU = "Ui_WorldRaid";

	[NonSerialized]
	private const string SCENE_NAME_QUEST_MENU = "Ui_WorldQuest";

	[NonSerialized]
	private const string SCENE_NAME_EQUIP_MENU = "Ui_MyHomeEquip";

	[NonSerialized]
	private const string SCENE_NAME_BLACKSMITH_MENU = "Ui_TownBlacksmith";

	[NonSerialized]
	private const string SCENE_NAME_LOTTERY_MENU = "Lottery_UI";

	[NonSerialized]
	private const string SCENE_NAME_TOWN = "Town";

	[NonSerialized]
	private const string SCENE_NAME_COLOSSEUM = "Ui_WorldColosseum";

	[NonSerialized]
	private const int TUTORIAL_UI_BAANK_ID_COMMON = 0;

	[NonSerialized]
	private const int TUTORIAL_UI_BAANK_ID_TEMP_0 = 1;

	[NonSerialized]
	private const int TUTORIAL_UI_BAANK_ID_TEMP_1 = 2;

	public static bool IsBusy => isBusy;

	public static bool IsRaidTutorialNow()
	{
		return SceneChanger.CurrentSceneName == "RaidStory003";
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		ScreenMask.DestroyInstance();
		ModalCollider.SetActive(this, active: false);
		isBusy = false;
	}

	private void showTutorialText(TutorialText tutorialText, string text)
	{
		tutorialText.Text = text;
		tutorialText.gameObject.SetActive(value: true);
	}

	public bool IsTutorialStartOk()
	{
		return UserData.Current != null && DialogManager.DialogCount <= 0 && !NpcTalkControl.IsBusy && !MerlinServer.Busy && !TheWorld.WorldIsStopped && SceneChanger.isFadeOut && FaderCore.Instance.isOutCompleted && (MerlinTaskQueue.Instance.IsEmpty ? true : false);
	}

	public IEnumerator S540_init()
	{
		return new _0024S540_init_002419808(this).GetEnumerator();
	}

	public IEnumerator S540_init(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_init";
		Exec e = lastCreatedExec;
		dlgMan = DialogManager.Instance;
		dtrace(e, "TutorialEvent.boo:96", "go命令 " + CurrentStateName + "->" + "S540_main" + "(" + string.Empty + ")");
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
		dtrace((Exec)obj2, "TutorialEvent.boo:94", "go命令 " + CurrentStateName + "->" + "S540_init" + "(" + string.Empty + ")");
		Exec e = createExecAsCurrent("S540_init");
		IEnumerator r = S540_init();
		entryCoroutine(e, r);
	}

	public IEnumerator S540_main()
	{
		return new _0024S540_main_002419814(this).GetEnumerator();
	}

	public IEnumerator S540_main(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_main_002419820(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_colosseumu()
	{
		return new _0024S540_tutorial_ui_colosseumu_002419855(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_colosseumu(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_colosseumu_002419861(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_townBlacksmith()
	{
		return new _0024S540_tutorial_ui_townBlacksmith_002419937(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_townBlacksmith(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_townBlacksmith_002419943(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_town()
	{
		return new _0024S540_tutorial_town_002419975(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_town(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_town_002419981(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_worldRaid()
	{
		return new _0024S540_tutorial_ui_worldRaid_002420010(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_worldRaid(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_worldRaid_002420016(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_myHomeEquip()
	{
		return new _0024S540_tutorial_ui_myHomeEquip_002420058(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_myHomeEquip(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_myHomeEquip_002420064(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_boxCustomize()
	{
		return new _0024S540_tutorial_ui_boxCustomize_002420166(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_boxCustomize(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_boxCustomize_002420172(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_boxList()
	{
		return new _0024S540_tutorial_ui_boxList_002420181(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_boxList(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_boxList_002420187(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_worldQuest()
	{
		return new _0024S540_tutorial_ui_worldQuest_002420196(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_ui_worldQuest(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_ui_worldQuest_002420202(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_lottery()
	{
		return new _0024S540_tutorial_lottery_002420279(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_lottery(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_lottery_002420285(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_000_new()
	{
		return new _0024S540_tutorial_mountain_000_new_002420320(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_000_new(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_000_new_002420326(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_000()
	{
		return new _0024S540_tutorial_mountain_000_002420353(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_000(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_000_002420359(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_002_new()
	{
		return new _0024S540_tutorial_mountain_002_new_002420414(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_002_new(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_002_new_002420420(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_002()
	{
		return new _0024S540_tutorial_mountain_002_002420437(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_002(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_002_002420443(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_001_new()
	{
		return new _0024S540_tutorial_mountain_001_new_002420480(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_001_new(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_001_new_002420486(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_001()
	{
		return new _0024S540_tutorial_mountain_001_002420503(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_001(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_001_002420509(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_007_new()
	{
		return new _0024S540_tutorial_mountain_007_new_002420546(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_007_new(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_007_new_002420552(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_007()
	{
		return new _0024S540_tutorial_mountain_007_002420572(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_007(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_007_002420578(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_005_new()
	{
		return new _0024S540_tutorial_mountain_005_new_002420610(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_005_new(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_005_new_002420616(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_005()
	{
		return new _0024S540_tutorial_mountain_005_002420631(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_mountain_005(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_mountain_005_002420637(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_cave_006()
	{
		return new _0024S540_tutorial_cave_006_002420664(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_cave_006(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_cave_006_002420670(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_cave_009()
	{
		return new _0024S540_tutorial_cave_009_002420691(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_cave_009(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_cave_009_002420697(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_raid_story003()
	{
		return new _0024S540_tutorial_raid_story003_002420726(this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_raid_story003(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_raid_story003_002420732(this).GetEnumerator();
	}

	private IEnumerator revivePlayer(PlayerControl _pc)
	{
		return new _0024revivePlayer_002420827(_pc).GetEnumerator();
	}

	public IEnumerator S540_recoverPlayerHP(PlayerControl _pc)
	{
		return new _0024S540_recoverPlayerHP_002420831(_pc, this).GetEnumerator();
	}

	public IEnumerator S540_recoverPlayerHP(PlayerControl _pc, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_recoverPlayerHP";
		Exec e = lastCreatedExec;
		stop(e);
		return null;
	}

	public IEnumerator S540_createPlayerNPC(GameObject obj, Vector3 pos, Vector3 rot)
	{
		return new _0024S540_createPlayerNPC_002420839(obj, pos, rot, this).GetEnumerator();
	}

	public IEnumerator S540_createPlayerNPC(GameObject obj, Vector3 pos, Vector3 rot, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_createPlayerNPC";
		Exec e = lastCreatedExec;
		stop(e);
		return null;
	}

	public IEnumerator S540_deleteAllTargetRingStar()
	{
		return new _0024S540_deleteAllTargetRingStar_002420851(this).GetEnumerator();
	}

	public IEnumerator S540_deleteAllTargetRingStar(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		string text = "S540_deleteAllTargetRingStar";
		Exec e = lastCreatedExec;
		TargetRingStar[] array = (TargetRingStar[])UnityEngine.Object.FindObjectsOfType(typeof(TargetRingStar));
		int i = 0;
		TargetRingStar[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array2[i])
			{
				UnityEngine.Object.Destroy(array2[i].gameObject);
			}
		}
		stop(e);
		return null;
	}

	public IEnumerator S540_npcchat_stop(NPCControl c, object charname, object message)
	{
		return new _0024S540_npcchat_stop_002420857(c, charname, message, this).GetEnumerator();
	}

	public IEnumerator S540_npcchat_stop(NPCControl c, object charname, object message, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_npcchat_stop_002420869(c, charname, message, this).GetEnumerator();
	}

	public IEnumerator S540_npcchat(NPCControl c, object charname, object message, bool furimuki)
	{
		return new _0024S540_npcchat_002420889(c, charname, message, furimuki, this).GetEnumerator();
	}

	public IEnumerator S540_npcchat(NPCControl c, object charname, object message, bool furimuki, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_npcchat_002420903(c, charname, message, furimuki, _0024INNER_BLOCK_0024, this).GetEnumerator();
	}

	public IEnumerator S540_npc(object speaker, object msg, object windowType)
	{
		return new _0024S540_npc_002420930(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_npc(object speaker, object msg, object windowType, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_npc_002420942(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_npc(object speaker, object msg, object windowType)
	{
		return new _0024S540_tutorial_npc_002420961(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_tutorial_npc(object speaker, object msg, object windowType, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_tutorial_npc_002420973(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_call_tutorials(object progname)
	{
		return new _0024S540_call_tutorials_002420988(progname, this).GetEnumerator();
	}

	public IEnumerator S540_call_tutorials(object progname, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_call_tutorials_002420996(progname, this).GetEnumerator();
	}

	public IEnumerator S540_gatya_npc(object speaker, object msg, object windowType)
	{
		return new _0024S540_gatya_npc_002421025(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_gatya_npc(object speaker, object msg, object windowType, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_gatya_npc_002421037(speaker, msg, windowType, this).GetEnumerator();
	}

	public IEnumerator S540_message_end()
	{
		return new _0024S540_message_end_002421052(this).GetEnumerator();
	}

	public IEnumerator S540_message_end(__GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_message_end_002421058(this).GetEnumerator();
	}

	public IEnumerator S540_sysmsg(object msg)
	{
		return new _0024S540_sysmsg_002421067(msg, this).GetEnumerator();
	}

	public IEnumerator S540_sysmsg(object msg, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_sysmsg_002421075(msg, this).GetEnumerator();
	}

	public IEnumerator S540_message_stop(object pop, object msg)
	{
		return new _0024S540_message_stop_002421082(pop, msg, this).GetEnumerator();
	}

	public IEnumerator S540_message_stop(object pop, object msg, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_message_stop_002421092(pop, msg, this).GetEnumerator();
	}

	public IEnumerator S540_stop(object time)
	{
		return new _0024S540_stop_002421105(time, this).GetEnumerator();
	}

	public IEnumerator S540_stop(object time, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_stop_002421113(time, this).GetEnumerator();
	}

	public IEnumerator S540_wait_button(UIButtonMessage btn)
	{
		return new _0024S540_wait_button_002421121(btn, this).GetEnumerator();
	}

	public IEnumerator S540_wait_button(UIButtonMessage btn, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_wait_button_002421129(btn, this).GetEnumerator();
	}

	public IEnumerator S540_wait_button(string objPath)
	{
		return new _0024S540_wait_button_002421137(objPath, this).GetEnumerator();
	}

	public IEnumerator S540_wait_button(string objPath, __GouseiSequense_S540_init_0024callable40_002410_5__ _0024INNER_BLOCK_0024)
	{
		return new _0024S540_wait_button_002421145(objPath, this).GetEnumerator();
	}
}
