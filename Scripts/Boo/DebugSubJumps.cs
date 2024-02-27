using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubJumps : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024OnGUI_0024locals_002414282
	{
		internal GUILayoutOption _0024w;
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243014
	{
		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414630;

		internal DebugSubJumps _0024this_002414631;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243014(_0024OnGUI_0024locals_002414282 _0024_0024locals_002414630, DebugSubJumps _0024this_002414631)
		{
			this._0024_0024locals_002414630 = _0024_0024locals_002414630;
			this._0024this_002414631 = _0024this_002414631;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("Battle", _0024_0024locals_002414630._0024w))
			{
				_0024this_002414631.ChangeScene("Merlin");
			}
			if (RuntimeDebugModeGuiMixin.button("MotionViewer", _0024_0024locals_002414630._0024w))
			{
				_0024this_002414631.ChangeScene("MotionViewerMobile");
			}
			if (RuntimeDebugModeGuiMixin.button("Town", _0024_0024locals_002414630._0024w))
			{
				_0024this_002414631.ChangeScene("Town");
			}
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243015
	{
		internal DebugSubJumps _0024this_002414632;

		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414633;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243015(DebugSubJumps _0024this_002414632, _0024OnGUI_0024locals_002414282 _0024_0024locals_002414633)
		{
			this._0024this_002414632 = _0024this_002414632;
			this._0024_0024locals_002414633 = _0024_0024locals_002414633;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("Colosseum Battle Test", _0024_0024locals_002414633._0024w))
			{
				_0024this_002414632.ChangeScene("ColosseumSelectTest");
			}
			if (RuntimeDebugModeGuiMixin.button("Colosseum Cycle Test", _0024_0024locals_002414633._0024w))
			{
				_0024this_002414632.ChangeScene("ColosseumMenuTest");
			}
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243016
	{
		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414634;

		internal DebugSubJumps _0024this_002414635;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243016(_0024OnGUI_0024locals_002414282 _0024_0024locals_002414634, DebugSubJumps _0024this_002414635)
		{
			this._0024_0024locals_002414634 = _0024_0024locals_002414634;
			this._0024this_002414635 = _0024this_002414635;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("Myhome", _0024_0024locals_002414634._0024w))
			{
				_0024this_002414635.ChangeScene("Myhome");
			}
			if (RuntimeDebugModeGuiMixin.button("Ui_WorldRaid", _0024_0024locals_002414634._0024w))
			{
				_0024this_002414635.ChangeScene("Ui_WorldRaid");
			}
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243017
	{
		internal DebugSubJumps _0024this_002414636;

		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414637;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243017(DebugSubJumps _0024this_002414636, _0024OnGUI_0024locals_002414282 _0024_0024locals_002414637)
		{
			this._0024this_002414636 = _0024this_002414636;
			this._0024_0024locals_002414637 = _0024_0024locals_002414637;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("GouseiSample", _0024_0024locals_002414637._0024w))
			{
				_0024this_002414636.ChangeScene("Gousei_sample");
			}
			if (RuntimeDebugModeGuiMixin.button("Opening", _0024_0024locals_002414637._0024w))
			{
				_0024this_002414636.ChangeScene("Opening");
			}
			if (RuntimeDebugModeGuiMixin.button("Prologue", _0024_0024locals_002414637._0024w))
			{
				_0024this_002414636.ChangeScene("Prologue");
			}
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243018
	{
		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414638;

		internal DebugSubJumps _0024this_002414639;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243018(_0024OnGUI_0024locals_002414282 _0024_0024locals_002414638, DebugSubJumps _0024this_002414639)
		{
			this._0024_0024locals_002414638 = _0024_0024locals_002414638;
			this._0024this_002414639 = _0024this_002414639;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("QuestResult", _0024_0024locals_002414638._0024w))
			{
				_0024this_002414639.ChangeScene("Ui_WorldQuestResult");
			}
			if (RuntimeDebugModeGuiMixin.button("Ui_MyHomeEquip", _0024_0024locals_002414638._0024w))
			{
				_0024this_002414639.ChangeScene("Ui_MyHomeEquip");
			}
		}
	}

	[Serializable]
	internal class _0024_0024OnGUI_0024closure_00243013_0024closure_00243019
	{
		internal DebugSubJumps _0024this_002414640;

		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414641;

		public _0024_0024OnGUI_0024closure_00243013_0024closure_00243019(DebugSubJumps _0024this_002414640, _0024OnGUI_0024locals_002414282 _0024_0024locals_002414641)
		{
			this._0024this_002414640 = _0024this_002414640;
			this._0024_0024locals_002414641 = _0024_0024locals_002414641;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("ChallengeResult", _0024_0024locals_002414641._0024w))
			{
				_0024this_002414640.ChangeScene("Ui_WorldChallengeResult");
			}
			if (RuntimeDebugModeGuiMixin.button("StoneShop", _0024_0024locals_002414641._0024w))
			{
				_0024this_002414640.ChangeScene("Ui_TownStoneShop");
			}
			if (RuntimeDebugModeGuiMixin.button("WorldMap", _0024_0024locals_002414641._0024w))
			{
				_0024this_002414640.ChangeScene("Ui_World");
			}
		}
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243013
	{
		internal _0024OnGUI_0024locals_002414282 _0024_0024locals_002414642;

		internal DebugSubJumps _0024this_002414643;

		public _0024OnGUI_0024closure_00243013(_0024OnGUI_0024locals_002414282 _0024_0024locals_002414642, DebugSubJumps _0024this_002414643)
		{
			this._0024_0024locals_002414642 = _0024_0024locals_002414642;
			this._0024this_002414643 = _0024this_002414643;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243014(_0024_0024locals_002414642, _0024this_002414643).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243015(_0024this_002414643, _0024_0024locals_002414642).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243016(_0024_0024locals_002414642, _0024this_002414643).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243017(_0024this_002414643, _0024_0024locals_002414642).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243018(_0024_0024locals_002414642, _0024this_002414643).Invoke));
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024OnGUI_0024closure_00243013_0024closure_00243019(_0024this_002414643, _0024_0024locals_002414642).Invoke));
		}
	}

	public override void OnGUI()
	{
		_0024OnGUI_0024locals_002414282 _0024OnGUI_0024locals_0024 = new _0024OnGUI_0024locals_002414282();
		title = "jumps";
		_0024OnGUI_0024locals_0024._0024w = RuntimeDebugModeGuiMixin.optWidth(200);
		RuntimeDebugModeGuiMixin.vertical(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243013(_0024OnGUI_0024locals_0024, this).Invoke));
	}

	public void ChangeScene(string scene)
	{
		RuntimeDebugMode.DebugChangeScene(scene);
	}
}
