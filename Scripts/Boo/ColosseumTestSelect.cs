using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumTestSelect : MonoBehaviour
{
	[Serializable]
	public class Team
	{
		public string teamName;

		public Boo.Lang.List<RespPoppet> members;

		public Boo.Lang.List<RespWeapon> weapons;

		public int Num => members.Count;

		public Boo.Lang.List<RespPoppet> Members => members;

		public Team(string _name)
		{
			members = new Boo.Lang.List<RespPoppet>();
			weapons = new Boo.Lang.List<RespWeapon>();
			teamName = _name;
		}

		public void add(RespPoppet ppt, RespWeapon weapon)
		{
			if (ppt == null || Num >= 3)
			{
				throw new AssertionFailedException("(ppt != null) and (Num < 3)");
			}
			members.Add(ppt);
			weapons.Add(weapon);
		}

		public RespPoppet member(int index)
		{
			return isValidIndex(index) ? members[index] : null;
		}

		public RespWeapon memberWeapon(int index)
		{
			return isValidIndex(index) ? weapons[index] : null;
		}

		public void setMemberWeapon(int index, RespWeapon weapon)
		{
			if (isValidIndex(index))
			{
				weapons[index] = weapon;
			}
		}

		public object remove(int index)
		{
			object result;
			if (!isValidIndex(index))
			{
				result = null;
			}
			else
			{
				members.RemoveAt(index);
				weapons.RemoveAt(index);
				result = null;
			}
			return result;
		}

		public void clear()
		{
			members.Clear();
			weapons.Clear();
		}

		private bool isValidIndex(int index)
		{
			bool num = 0 <= index;
			if (num)
			{
				num = index < ((ICollection)members).Count;
			}
			return num;
		}
	}

	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00241456;

		public string _0024act_0024t_00241457;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241458;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241459;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241460;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241461;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241462;

		public __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ _0024act_0024t_00241463;

		public __ActionBase__0024act_0024t_00241464_0024callable72_002474_5__ _0024act_0024t_00241464;

		public IEnumerator _0024act_0024t_00241468;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00241456.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmain : ActionBase
	{
	}

	[Serializable]
	public class ActionClassselEnd : ActionBase
	{
	}

	[Serializable]
	public class ActionClassselectFromBox : ActionBase
	{
		public Team team;
	}

	[Serializable]
	public class ActionClassselectFromFriends : ActionBase
	{
		public Team team;

		public ApiFriendPlayerSearch req;
	}

	[Serializable]
	public class ActionClassselectFromMaster : ActionBase
	{
		public Team team;

		public Boo.Lang.List<RespPoppet> poppets;

		public Boo.Lang.List<RespPoppet> maxPoppets;

		public int page;
	}

	[Serializable]
	public class ActionClassselectWeapons : ActionBase
	{
		public Team team;

		public int index;
	}

	[Serializable]
	public class ActionClassselectDailySkill : ActionBase
	{
	}

	[Serializable]
	public class ActionClassaddNewDailySkill : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		addNewDailySkill,
		selectDailySkill,
		selectWeapons,
		selectFromMaster,
		selectFromFriends,
		selectFromBox,
		selEnd,
		main,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024_0024createDatamain_0024closure_00244388_0024locals_002414378
	{
		internal GUILayoutOption _0024teamLabelStyle;

		internal GUILayoutOption _0024labelStyle;

		internal GUILayoutOption _0024vsStyle;
	}

	[Serializable]
	internal class _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379
	{
		internal Team _0024team;
	}

	[Serializable]
	internal class _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_002414380
	{
		internal RespPoppet _0024ppt;
	}

	[Serializable]
	internal class _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381
	{
		internal RespPoppet[] _0024ppts;

		internal ActionClassselectFromBox _0024_0024act_0024t_00241474;
	}

	[Serializable]
	internal class _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382
	{
		internal RespFriend[] _0024friends;

		internal ActionClassselectFromFriends _0024_0024act_0024t_00241477;
	}

	[Serializable]
	internal class _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383
	{
		internal int _0024pageStep;

		internal ActionClassselectFromMaster _0024_0024act_0024t_00241480;
	}

	[Serializable]
	internal class _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_002414384
	{
		internal RespPoppet _0024ppt;

		internal RespPoppet _0024maxppt;
	}

	[Serializable]
	internal class _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385
	{
		internal ActionClassselectWeapons _0024_0024act_0024t_00241483;
	}

	[Serializable]
	internal class _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386
	{
		internal int _0024sid;
	}

	[Serializable]
	internal class _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024closure_00244393
	{
		internal _0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414861;

		internal _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_002414380 _0024_0024locals_002414862;

		internal _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379 _0024_0024locals_002414863;

		internal ColosseumTestSelect _0024this_002414864;

		internal int _0024j_002414865;

		public _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024closure_00244393(_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414861, _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_002414380 _0024_0024locals_002414862, _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379 _0024_0024locals_002414863, ColosseumTestSelect _0024this_002414864, int _0024j_002414865)
		{
			this._0024_0024locals_002414861 = _0024_0024locals_002414861;
			this._0024_0024locals_002414862 = _0024_0024locals_002414862;
			this._0024_0024locals_002414863 = _0024_0024locals_002414863;
			this._0024this_002414864 = _0024this_002414864;
			this._0024j_002414865 = _0024j_002414865;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label(PoppetLabel(_0024_0024locals_002414862._0024ppt), _0024_0024locals_002414861._0024labelStyle);
			if (RuntimeDebugModeGuiMixin.button("remove"))
			{
				_0024_0024locals_002414863._0024team.remove(_0024j_002414865);
			}
		}
	}

	[Serializable]
	internal class _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392
	{
		internal _0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414866;

		internal ColosseumTestSelect _0024this_002414867;

		internal _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379 _0024_0024locals_002414868;

		public _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392(_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414866, ColosseumTestSelect _0024this_002414867, _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379 _0024_0024locals_002414868)
		{
			this._0024_0024locals_002414866 = _0024_0024locals_002414866;
			this._0024this_002414867 = _0024this_002414867;
			this._0024_0024locals_002414868 = _0024_0024locals_002414868;
		}

		public void Invoke()
		{
			_0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_002414380 _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024 = new _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_002414380();
			RuntimeDebugModeGuiMixin.label(_0024_0024locals_002414868._0024team.teamName, _0024_0024locals_002414866._0024teamLabelStyle);
			int num = 0;
			int num2 = _0024_0024locals_002414868._0024team.Num;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				_0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024._0024ppt = _0024_0024locals_002414868._0024team.member(num3);
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024closure_00244393(_0024_0024locals_002414866, _0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024, _0024_0024locals_002414868, _0024this_002414867, num3).Invoke));
				RespWeapon respWeapon = _0024_0024locals_002414868._0024team.memberWeapon(num3);
				if (RuntimeDebugModeGuiMixin.button(WeaponLabel(respWeapon)))
				{
					_0024this_002414867.selectWeapons(_0024_0024locals_002414868._0024team, num3);
					return;
				}
				if (_0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024._0024ppt != null && respWeapon != null)
				{
					float num4 = DamageCalc.ColosseumPoppetAttack(_0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024._0024ppt, respWeapon);
					float num5 = DamageCalc.ColosseumPoppetHP(_0024_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392_0024locals_0024._0024ppt, respWeapon);
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   atk=").Append(num4).Append(" hp=").Append(num5)
						.ToString());
				}
				else
				{
					RuntimeDebugModeGuiMixin.slabel("   atk=??? hp=???");
				}
				RuntimeDebugModeGuiMixin.space(10);
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (_0024_0024locals_002414868._0024team.Num < 3)
			{
				if (RuntimeDebugModeGuiMixin.button("add"))
				{
					_0024this_002414867.selectFromBox(_0024_0024locals_002414868._0024team);
				}
				RuntimeDebugModeGuiMixin.space(20);
				if (RuntimeDebugModeGuiMixin.button("random"))
				{
					_0024this_002414867.randomSelect(_0024_0024locals_002414868._0024team);
					return;
				}
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("clear"))
			{
				_0024_0024locals_002414868._0024team.clear();
			}
		}
	}

	[Serializable]
	internal class _0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391
	{
		internal _0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414869;

		internal ColosseumTestSelect _0024this_002414870;

		public _0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391(_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414869, ColosseumTestSelect _0024this_002414870)
		{
			this._0024_0024locals_002414869 = _0024_0024locals_002414869;
			this._0024this_002414870 = _0024this_002414870;
		}

		public void Invoke()
		{
			_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379 _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_0024 = new _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_002414379();
			int num = 0;
			while (num < 2)
			{
				int num2 = num;
				num++;
				Team[] teams = ColosseumTestSelect.teams;
				_0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_0024._0024team = teams[RuntimeServices.NormalizeArrayIndex(teams, num2)];
				RuntimeDebugModeGuiMixin.vertical(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024closure_00244392(_0024_0024locals_002414869, _0024this_002414870, _0024_0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391_0024locals_0024).Invoke));
				if (num2 == 0)
				{
					RuntimeDebugModeGuiMixin.label(" V.S. ", _0024_0024locals_002414869._0024vsStyle);
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatamain_0024closure_00244388_0024closure_00244389
	{
		internal _0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414871;

		internal ColosseumTestSelect _0024this_002414872;

		public _0024_0024createDatamain_0024closure_00244388_0024closure_00244389(_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024locals_002414871, ColosseumTestSelect _0024this_002414872)
		{
			this._0024_0024locals_002414871 = _0024_0024locals_002414871;
			this._0024this_002414872 = _0024this_002414872;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RuntimeDebugModeGuiMixin.label("select poppets");
				if (RuntimeDebugModeGuiMixin.button("daily skill"))
				{
					_0024this_002414872.selectDailySkill();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244391(_0024_0024locals_002414871, _0024this_002414872).Invoke));
			RuntimeDebugModeGuiMixin.space(30);
			if (teams[0].Num > 0 && teams[1].Num > 0 && RuntimeDebugModeGuiMixin.button("start"))
			{
				_0024this_002414872.changeToBattleScene();
				_0024this_002414872.selEnd();
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectFromBox_0024closure_00244394_0024closure_00244395
	{
		internal ColosseumTestSelect _0024this_002414873;

		internal _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381 _0024_0024locals_002414874;

		public _0024_0024createDataselectFromBox_0024closure_00244394_0024closure_00244395(ColosseumTestSelect _0024this_002414873, _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381 _0024_0024locals_002414874)
		{
			this._0024this_002414873 = _0024this_002414873;
			this._0024_0024locals_002414874 = _0024_0024locals_002414874;
		}

		public void Invoke()
		{
			int i = 0;
			RespPoppet[] _0024ppts = _0024_0024locals_002414874._0024ppts;
			for (int length = _0024ppts.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeDebugModeGuiMixin.button(PoppetLabel(_0024ppts[i])))
				{
					_0024_0024locals_002414874._0024_0024act_0024t_00241474.team.add(_0024ppts[i], _0024this_002414873.getDefaultWeapon());
					_0024this_002414873.main();
					break;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectFromFriends_0024closure_00244398_0024closure_00244399
	{
		internal ColosseumTestSelect _0024this_002414875;

		internal _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382 _0024_0024locals_002414876;

		public _0024_0024createDataselectFromFriends_0024closure_00244398_0024closure_00244399(ColosseumTestSelect _0024this_002414875, _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382 _0024_0024locals_002414876)
		{
			this._0024this_002414875 = _0024this_002414875;
			this._0024_0024locals_002414876 = _0024_0024locals_002414876;
		}

		public void Invoke()
		{
			int i = 0;
			RespFriend[] _0024friends = _0024_0024locals_002414876._0024friends;
			for (int length = _0024friends.Length; i < length; i = checked(i + 1))
			{
				RespPoppet friendPet = _0024friends[i].GetFriendPet();
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(_0024friends[i].Name).Append(" ").ToString() + PoppetLabel(friendPet)))
				{
					_0024_0024locals_002414876._0024_0024act_0024t_00241477.team.add(friendPet, _0024this_002414875.getDefaultWeapon());
					_0024this_002414875.main();
					break;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244402
	{
		internal _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414877;

		internal ColosseumTestSelect _0024this_002414878;

		public _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244402(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414877, ColosseumTestSelect _0024this_002414878)
		{
			this._0024_0024locals_002414877 = _0024_0024locals_002414877;
			this._0024this_002414878 = _0024this_002414878;
		}

		public void Invoke()
		{
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("前のページ"))
				{
					_0024_0024locals_002414877._0024_0024act_0024t_00241480.page = Mathf.Max(0, _0024_0024locals_002414877._0024_0024act_0024t_00241480.page - _0024_0024locals_002414877._0024pageStep);
				}
				if (RuntimeDebugModeGuiMixin.button("次のページ") && _0024_0024locals_002414877._0024_0024act_0024t_00241480.page + _0024_0024locals_002414877._0024pageStep < _0024_0024locals_002414877._0024_0024act_0024t_00241480.poppets.Count)
				{
					_0024_0024locals_002414877._0024_0024act_0024t_00241480.page = _0024_0024locals_002414877._0024_0024act_0024t_00241480.page + _0024_0024locals_002414877._0024pageStep;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024closure_00244404
	{
		internal _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414879;

		internal _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_002414384 _0024_0024locals_002414880;

		internal ColosseumTestSelect _0024this_002414881;

		public _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024closure_00244404(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414879, _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_002414384 _0024_0024locals_002414880, ColosseumTestSelect _0024this_002414881)
		{
			this._0024_0024locals_002414879 = _0024_0024locals_002414879;
			this._0024_0024locals_002414880 = _0024_0024locals_002414880;
			this._0024this_002414881 = _0024this_002414881;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button(PoppetLabel(_0024_0024locals_002414880._0024ppt)))
			{
				_0024_0024locals_002414879._0024_0024act_0024t_00241480.team.add(_0024_0024locals_002414880._0024ppt, _0024this_002414881.getDefaultWeapon());
				_0024this_002414881.main();
			}
			else if (RuntimeDebugModeGuiMixin.button(PoppetLabel(_0024_0024locals_002414880._0024maxppt)))
			{
				_0024_0024locals_002414879._0024_0024act_0024t_00241480.team.add(_0024_0024locals_002414880._0024maxppt, _0024this_002414881.getDefaultWeapon());
				_0024this_002414881.main();
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403
	{
		internal ColosseumTestSelect _0024this_002414882;

		internal _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414883;

		public _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403(ColosseumTestSelect _0024this_002414882, _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024locals_002414883)
		{
			this._0024this_002414882 = _0024this_002414882;
			this._0024_0024locals_002414883 = _0024_0024locals_002414883;
		}

		public void Invoke()
		{
			_0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_002414384 _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_0024 = new _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_002414384();
			int num = _0024_0024locals_002414883._0024_0024act_0024t_00241480.page;
			int num2 = Mathf.Min(checked(_0024_0024locals_002414883._0024_0024act_0024t_00241480.page + _0024_0024locals_002414883._0024pageStep), _0024_0024locals_002414883._0024_0024act_0024t_00241480.poppets.Count);
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int index = num;
				num += num3;
				_0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_0024._0024ppt = _0024_0024locals_002414883._0024_0024act_0024t_00241480.poppets[index];
				_0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_0024._0024maxppt = _0024_0024locals_002414883._0024_0024act_0024t_00241480.maxPoppets[index];
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024closure_00244404(_0024_0024locals_002414883, _0024_0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403_0024locals_0024, _0024this_002414882).Invoke));
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectWeapons_0024closure_00244405_0024closure_00244406
	{
		internal ColosseumTestSelect _0024this_002414884;

		internal _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385 _0024_0024locals_002414885;

		public _0024_0024createDataselectWeapons_0024closure_00244405_0024closure_00244406(ColosseumTestSelect _0024this_002414884, _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385 _0024_0024locals_002414885)
		{
			this._0024this_002414884 = _0024this_002414884;
			this._0024_0024locals_002414885 = _0024_0024locals_002414885;
		}

		public void Invoke()
		{
			_0024this_002414884.weaponSelectList(_0024_0024locals_002414885._0024_0024act_0024t_00241483.team, _0024_0024locals_002414885._0024_0024act_0024t_00241483.index);
		}
	}

	[Serializable]
	internal class _0024_0024createDataselectDailySkill_0024closure_00244407_0024closure_00244408
	{
		internal _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386 _0024_0024locals_002414886;

		internal ColosseumTestSelect _0024this_002414887;

		internal int _0024i_002414888;

		public _0024_0024createDataselectDailySkill_0024closure_00244407_0024closure_00244408(_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386 _0024_0024locals_002414886, ColosseumTestSelect _0024this_002414887, int _0024i_002414888)
		{
			this._0024_0024locals_002414886 = _0024_0024locals_002414886;
			this._0024this_002414887 = _0024this_002414887;
			this._0024i_002414888 = _0024i_002414888;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("削除"))
			{
				dailySkills.RemoveAt(_0024i_002414888);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(" " + MCoverSkills.Get(_0024_0024locals_002414886._0024sid));
			}
		}
	}

	[NonSerialized]
	private static Team[] teams;

	[NonSerialized]
	private static Boo.Lang.List<int> dailySkills = new Boo.Lang.List<int>();

	private RuntimeDebugModeGuiMixin gm;

	private Dictionary<string, ActionBase> _0024act_0024t_00241465;

	private Dictionary<string, ActionEnum> _0024act_0024t_00241467;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00241466;

	public bool actionDebugFlag;

	public bool Ismain => currActionID("$default$") == ActionEnum.main;

	public float actionTime => currActionTime("$default$");

	public ActionClassmain mainData => currAction("$default$") as ActionClassmain;

	public bool IsselEnd => currActionID("$default$") == ActionEnum.selEnd;

	public ActionClassselEnd selEndData => currAction("$default$") as ActionClassselEnd;

	public bool IsselectFromBox => currActionID("$default$") == ActionEnum.selectFromBox;

	public ActionClassselectFromBox selectFromBoxData => currAction("$default$") as ActionClassselectFromBox;

	public bool IsselectFromFriends => currActionID("$default$") == ActionEnum.selectFromFriends;

	public ActionClassselectFromFriends selectFromFriendsData => currAction("$default$") as ActionClassselectFromFriends;

	public bool IsselectFromMaster => currActionID("$default$") == ActionEnum.selectFromMaster;

	public ActionClassselectFromMaster selectFromMasterData => currAction("$default$") as ActionClassselectFromMaster;

	public bool IsselectWeapons => currActionID("$default$") == ActionEnum.selectWeapons;

	public ActionClassselectWeapons selectWeaponsData => currAction("$default$") as ActionClassselectWeapons;

	public bool IsselectDailySkill => currActionID("$default$") == ActionEnum.selectDailySkill;

	public ActionClassselectDailySkill selectDailySkillData => currAction("$default$") as ActionClassselectDailySkill;

	public bool IsaddNewDailySkill => currActionID("$default$") == ActionEnum.addNewDailySkill;

	public ActionClassaddNewDailySkill addNewDailySkillData => currAction("$default$") as ActionClassaddNewDailySkill;

	public ColosseumTestSelect()
	{
		gm = new RuntimeDebugModeGuiMixin();
		_0024act_0024t_00241465 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00241467 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public void Update()
	{
		actUpdate();
	}

	public void LateUpdate()
	{
		actLateUpdate();
	}

	public void FixedUpdate()
	{
		actFixedUpdate();
	}

	public void OnGUI()
	{
		RuntimeDebugModeGuiMixin.initOnGUI();
		actOnGUI();
	}

	public void Start()
	{
		if (teams == null)
		{
			teams = new Team[2];
			teams[0] = new Team("Team A");
			teams[1] = new Team("Team B");
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = delegate
		{
			MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				main();
			});
			return (IEnumerator)null;
		};
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00241465.ContainsKey(grp)) ? null : _0024act_0024t_00241465[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00241467.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00241467[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00241465.ContainsKey(grp)) ? 0f : _0024act_0024t_00241465[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00241465.ContainsKey(grp)) ? 0f : _0024act_0024t_00241465[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00241465.ContainsKey(grp)) ? 0f : _0024act_0024t_00241465[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00241467.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00241457) && _0024act_0024t_00241465.ContainsKey(act._0024act_0024t_00241457) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00241465[act._0024act_0024t_00241457]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.addNewDailySkill <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_00241457))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$1457)");
			}
			_0024act_0024t_00241465[act._0024act_0024t_00241457] = act;
			_0024act_0024t_00241467[act._0024act_0024t_00241457] = act._0024act_0024t_00241456;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00241466) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00241457);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00241457)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00241457)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00241459 != null)
		{
			actionBase._0024act_0024t_00241459(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00241458 != null)
			{
				act._0024act_0024t_00241458(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00241464 != null)
			{
				act._0024act_0024t_00241468 = act._0024act_0024t_00241464(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_00241465.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241466 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_00241460 != null)
			{
				actionBase._0024act_0024t_00241460(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00241468 != null && !actionBase._0024act_0024t_00241468.MoveNext())
			{
				actionBase._0024act_0024t_00241468 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00241465.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241466 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_00241461 != null)
			{
				actionBase._0024act_0024t_00241461(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00241466 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241465.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00241465[array2[i]];
				if (actionBase._0024act_0024t_00241462 != null)
				{
					actionBase._0024act_0024t_00241462(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00241465.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00241457 + " - " + value._0024act_0024t_00241456 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00241466 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241465.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00241465[array2[i]];
			if (actionBase._0024act_0024t_00241463 != null)
			{
				actionBase._0024act_0024t_00241463(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "ColosseumTestSelect" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.main => createDatamain(), 
			ActionEnum.selEnd => createDataselEnd(), 
			ActionEnum.selectFromBox => createDataselectFromBox(), 
			ActionEnum.selectFromFriends => createDataselectFromFriends(), 
			ActionEnum.selectFromMaster => createDataselectFromMaster(), 
			ActionEnum.selectWeapons => createDataselectWeapons(), 
			ActionEnum.selectDailySkill => createDataselectDailySkill(), 
			ActionEnum.addNewDailySkill => createDataaddNewDailySkill(), 
			_ => null, 
		};
	}

	public ActionClassmain main()
	{
		ActionClassmain actionClassmain = createmain();
		changeAction(actionClassmain);
		return actionClassmain;
	}

	public ActionClassmain createDatamain()
	{
		ActionClassmain actionClassmain = new ActionClassmain();
		actionClassmain._0024act_0024t_00241456 = ActionEnum.main;
		actionClassmain._0024act_0024t_00241457 = "$default$";
		actionClassmain._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable338_002474_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024141.Adapt(delegate
		{
			_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024createDatamain_0024closure_00244388_0024locals_0024 = new _0024_0024createDatamain_0024closure_00244388_0024locals_002414378();
			_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024teamLabelStyle = RuntimeDebugModeGuiMixin.optWidth(300);
			_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024labelStyle = RuntimeDebugModeGuiMixin.optWidth(300);
			_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024vsStyle = RuntimeDebugModeGuiMixin.optWidth(80);
			RuntimeDebugModeGuiMixin.vertical(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamain_0024closure_00244388_0024closure_00244389(_0024_0024createDatamain_0024closure_00244388_0024locals_0024, this).Invoke));
		});
		return actionClassmain;
	}

	public ActionClassmain createmain()
	{
		return createDatamain();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00241465.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00241465["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClassselEnd selEnd()
	{
		ActionClassselEnd actionClassselEnd = createselEnd();
		changeAction(actionClassselEnd);
		return actionClassselEnd;
	}

	public ActionClassselEnd createDataselEnd()
	{
		ActionClassselEnd actionClassselEnd = new ActionClassselEnd();
		actionClassselEnd._0024act_0024t_00241456 = ActionEnum.selEnd;
		actionClassselEnd._0024act_0024t_00241457 = "$default$";
		return actionClassselEnd;
	}

	public ActionClassselEnd createselEnd()
	{
		return createDataselEnd();
	}

	private void changeToBattleScene()
	{
		GameObject gameObject = new GameObject("ColosseumBattleControl");
		ColosseumBattleControl colosseumBattleControl = ColosseumBattleControl.Create();
		colosseumBattleControl.DebugGUI = true;
		int num = 0;
		while (num < 2)
		{
			int num2 = num;
			num++;
			int num3 = 0;
			Team[] array = teams;
			int num4 = array[RuntimeServices.NormalizeArrayIndex(array, num2)].Num;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int num5 = num3;
				num3++;
				Team[] array2 = teams;
				RespPoppet ppt = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].member(num5);
				Team[] array3 = teams;
				RespWeapon wpn = array3[RuntimeServices.NormalizeArrayIndex(array3, num2)].memberWeapon(num5);
				bool flag;
				colosseumBattleControl.addMember(num2, ppt, wpn, flag = num5 == 0);
			}
		}
		IEnumerator<int> enumerator = dailySkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				MCoverSkills mCoverSkills = MCoverSkills.Get(current);
				if (mCoverSkills != null)
				{
					colosseumBattleControl.addCoverSkill(mCoverSkills);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		colosseumBattleControl.exec();
	}

	private void randomSelect(Team team)
	{
		int num = checked(3 - team.Num);
		if (num <= 0)
		{
			return;
		}
		UserData current = UserData.Current;
		RespPoppet[] boxPoppets = current.BoxPoppets;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			int num5 = UnityEngine.Random.Range(0, boxPoppets.Length);
			int num6 = 0;
			int length = boxPoppets.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num6 < length)
			{
				int num7 = num6;
				num6++;
				RespPoppet respPoppet = boxPoppets[RuntimeServices.NormalizeArrayIndex(boxPoppets, num5)];
				if (respPoppet != null && respPoppet.LevelMax > 1)
				{
					team.add(respPoppet, getDefaultWeapon());
					break;
				}
				num5 = checked(num5 + 1);
				if (num5 >= boxPoppets.Length)
				{
					num5 = 0;
				}
			}
		}
	}

	public ActionClassselectFromBox selectFromBox(Team team)
	{
		ActionClassselectFromBox actionClassselectFromBox = createselectFromBox(team);
		changeAction(actionClassselectFromBox);
		return actionClassselectFromBox;
	}

	public ActionClassselectFromBox createDataselectFromBox()
	{
		ActionClassselectFromBox actionClassselectFromBox = new ActionClassselectFromBox();
		actionClassselectFromBox._0024act_0024t_00241456 = ActionEnum.selectFromBox;
		actionClassselectFromBox._0024act_0024t_00241457 = "$default$";
		actionClassselectFromBox._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable339_0024166_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024142.Adapt(delegate(ActionClassselectFromBox _0024act_0024t_00241474)
		{
			_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381 _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024 = new _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381();
			_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474 = _0024act_0024t_00241474;
			UserData current = UserData.Current;
			_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024ppts = current.BoxPoppets;
			RuntimeDebugModeGuiMixin.label("ボックスから追加モード");
			if (RuntimeDebugModeGuiMixin.button("友達/冒険者から追加する"))
			{
				selectFromFriends(_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474.team);
			}
			if (RuntimeDebugModeGuiMixin.button("マスタから追加する"))
			{
				selectFromMaster(_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474.team);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.scrollView("poppetView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromBox_0024closure_00244394_0024closure_00244395(this, _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024).Invoke));
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				main();
			}
		});
		return actionClassselectFromBox;
	}

	public ActionClassselectFromBox createselectFromBox(Team team)
	{
		ActionClassselectFromBox actionClassselectFromBox = createDataselectFromBox();
		actionClassselectFromBox.team = team;
		return actionClassselectFromBox;
	}

	public ActionClassselectFromFriends selectFromFriends(Team team)
	{
		ActionClassselectFromFriends actionClassselectFromFriends = createselectFromFriends(team);
		changeAction(actionClassselectFromFriends);
		return actionClassselectFromFriends;
	}

	public ActionClassselectFromFriends createDataselectFromFriends()
	{
		ActionClassselectFromFriends actionClassselectFromFriends = new ActionClassselectFromFriends();
		actionClassselectFromFriends._0024act_0024t_00241456 = ActionEnum.selectFromFriends;
		actionClassselectFromFriends._0024act_0024t_00241457 = "$default$";
		actionClassselectFromFriends._0024act_0024t_00241458 = _0024adaptor_0024__ColosseumTestSelect_0024callable340_0024186_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024143.Adapt(delegate(ActionClassselectFromFriends _0024act_0024t_00241477)
		{
			_0024act_0024t_00241477.req = new ApiFriendPlayerSearch();
			_0024act_0024t_00241477.req.IsRecommend = true;
			_0024act_0024t_00241477.req.Num = 100;
			_0024act_0024t_00241477.req.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				main();
			});
			MerlinServer.Request(_0024act_0024t_00241477.req);
		});
		actionClassselectFromFriends._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable340_0024186_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024143.Adapt(delegate(ActionClassselectFromFriends _0024act_0024t_00241477)
		{
			_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382 _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024 = new _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382();
			_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477 = _0024act_0024t_00241477;
			if (_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.req.IsOk)
			{
				_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024friends = _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.req.GetResponse().Friends;
				RuntimeDebugModeGuiMixin.label("友達/冒険者から追加モード");
				if (RuntimeDebugModeGuiMixin.button("ボックスから追加する"))
				{
					selectFromBox(_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.team);
				}
				if (RuntimeDebugModeGuiMixin.button("マスタから追加する"))
				{
					selectFromMaster(_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.team);
				}
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.scrollView("friendView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromFriends_0024closure_00244398_0024closure_00244399(this, _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024).Invoke));
				RuntimeDebugModeGuiMixin.space(20);
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					main();
				}
			}
		});
		return actionClassselectFromFriends;
	}

	public ActionClassselectFromFriends createselectFromFriends(Team team)
	{
		ActionClassselectFromFriends actionClassselectFromFriends = createDataselectFromFriends();
		actionClassselectFromFriends.team = team;
		return actionClassselectFromFriends;
	}

	public ActionClassselectFromMaster selectFromMaster(Team team)
	{
		ActionClassselectFromMaster actionClassselectFromMaster = createselectFromMaster(team);
		changeAction(actionClassselectFromMaster);
		return actionClassselectFromMaster;
	}

	public ActionClassselectFromMaster createDataselectFromMaster()
	{
		ActionClassselectFromMaster actionClassselectFromMaster = new ActionClassselectFromMaster();
		actionClassselectFromMaster._0024act_0024t_00241456 = ActionEnum.selectFromMaster;
		actionClassselectFromMaster._0024act_0024t_00241457 = "$default$";
		actionClassselectFromMaster._0024act_0024t_00241458 = _0024adaptor_0024__ColosseumTestSelect_0024callable341_0024216_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024144.Adapt(delegate(ActionClassselectFromMaster _0024act_0024t_00241480)
		{
			_0024act_0024t_00241480.poppets = new Boo.Lang.List<RespPoppet>();
			_0024act_0024t_00241480.maxPoppets = new Boo.Lang.List<RespPoppet>();
			int i = 0;
			MPoppets[] all = MPoppets.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				_0024act_0024t_00241480.poppets.Add(new RespPoppet(all[i]));
				RespPoppet respPoppet = new RespPoppet(all[i]);
				MPoppets master = respPoppet.Master;
				respPoppet.Level = master.LevelLimitMax;
				respPoppet.LevelMax = master.LevelLimitMax;
				respPoppet.ChainSkillLevel = master.ChainSkillId.LevelMax;
				if (master.CoverSkillId_1 != null)
				{
					respPoppet.CoverSkillLevel_1 = master.CoverSkillId_1.LevelMax;
				}
				if (master.CoverSkillId_2 != null)
				{
					respPoppet.CoverSkillLevel_2 = master.CoverSkillId_2.LevelMax;
				}
				_0024act_0024t_00241480.maxPoppets.Add(respPoppet);
			}
			_0024act_0024t_00241480.page = 0;
		});
		actionClassselectFromMaster._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable341_0024216_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024144.Adapt(delegate(ActionClassselectFromMaster _0024act_0024t_00241480)
		{
			_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024 = new _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383();
			_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480 = _0024act_0024t_00241480;
			_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024pageStep = 100;
			RuntimeDebugModeGuiMixin.label("マスタから追加モード");
			if (RuntimeDebugModeGuiMixin.button("ボックスから追加する"))
			{
				selectFromBox(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480.team);
			}
			if (RuntimeDebugModeGuiMixin.button("友達/冒険者から追加する"))
			{
				selectFromFriends(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480.team);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244402(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024, this).Invoke));
			RuntimeDebugModeGuiMixin.scrollView("masterView", 1000, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403(this, _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024).Invoke));
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				main();
			}
		});
		return actionClassselectFromMaster;
	}

	public ActionClassselectFromMaster createselectFromMaster(Team team)
	{
		ActionClassselectFromMaster actionClassselectFromMaster = createDataselectFromMaster();
		actionClassselectFromMaster.team = team;
		return actionClassselectFromMaster;
	}

	public ActionClassselectWeapons selectWeapons(Team team, int index)
	{
		ActionClassselectWeapons actionClassselectWeapons = createselectWeapons(team, index);
		changeAction(actionClassselectWeapons);
		return actionClassselectWeapons;
	}

	public ActionClassselectWeapons createDataselectWeapons()
	{
		ActionClassselectWeapons actionClassselectWeapons = new ActionClassselectWeapons();
		actionClassselectWeapons._0024act_0024t_00241456 = ActionEnum.selectWeapons;
		actionClassselectWeapons._0024act_0024t_00241457 = "$default$";
		actionClassselectWeapons._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable342_0024271_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024145.Adapt(delegate(ActionClassselectWeapons _0024act_0024t_00241483)
		{
			_0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385 _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024 = new _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385();
			_0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024._0024_0024act_0024t_00241483 = _0024act_0024t_00241483;
			RuntimeDebugModeGuiMixin.label("武器選択（ボックス）");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				main();
			}
			else
			{
				RuntimeDebugModeGuiMixin.scrollView("weaponView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectWeapons_0024closure_00244405_0024closure_00244406(this, _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024).Invoke));
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					main();
				}
			}
		});
		return actionClassselectWeapons;
	}

	public ActionClassselectWeapons createselectWeapons(Team team, int index)
	{
		ActionClassselectWeapons actionClassselectWeapons = createDataselectWeapons();
		actionClassselectWeapons.team = team;
		actionClassselectWeapons.index = index;
		return actionClassselectWeapons;
	}

	public ActionClassselectDailySkill selectDailySkill()
	{
		ActionClassselectDailySkill actionClassselectDailySkill = createselectDailySkill();
		changeAction(actionClassselectDailySkill);
		return actionClassselectDailySkill;
	}

	public ActionClassselectDailySkill createDataselectDailySkill()
	{
		ActionClassselectDailySkill actionClassselectDailySkill = new ActionClassselectDailySkill();
		actionClassselectDailySkill._0024act_0024t_00241456 = ActionEnum.selectDailySkill;
		actionClassselectDailySkill._0024act_0024t_00241457 = "$default$";
		actionClassselectDailySkill._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable343_0024283_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024146.Adapt(delegate
		{
			_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386 _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024 = new _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386();
			RuntimeDebugModeGuiMixin.label("デイリー援護スキル選択");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				main();
			}
			else
			{
				if (RuntimeDebugModeGuiMixin.button("新規追加"))
				{
					addNewDailySkill();
				}
				RuntimeDebugModeGuiMixin.space(10);
				int num = 0;
				int count = dailySkills.Count;
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < count)
				{
					int num2 = num;
					num++;
					_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024._0024sid = dailySkills[num2];
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectDailySkill_0024closure_00244407_0024closure_00244408(_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024, this, num2).Invoke));
				}
			}
		});
		return actionClassselectDailySkill;
	}

	public ActionClassselectDailySkill createselectDailySkill()
	{
		return createDataselectDailySkill();
	}

	public ActionClassaddNewDailySkill addNewDailySkill()
	{
		ActionClassaddNewDailySkill actionClassaddNewDailySkill = createaddNewDailySkill();
		changeAction(actionClassaddNewDailySkill);
		return actionClassaddNewDailySkill;
	}

	public ActionClassaddNewDailySkill createDataaddNewDailySkill()
	{
		ActionClassaddNewDailySkill actionClassaddNewDailySkill = new ActionClassaddNewDailySkill();
		actionClassaddNewDailySkill._0024act_0024t_00241456 = ActionEnum.addNewDailySkill;
		actionClassaddNewDailySkill._0024act_0024t_00241457 = "$default$";
		actionClassaddNewDailySkill._0024act_0024t_00241462 = _0024adaptor_0024__ColosseumTestSelect_0024callable344_0024302_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024147.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("追加援護スキル選択");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				selectDailySkill();
			}
			else
			{
				RuntimeDebugModeGuiMixin.scrollView("skillview", 800, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					int i = 0;
					MCoverSkills[] all = MCoverSkills.All;
					for (int length = all.Length; i < length; i = checked(i + 1))
					{
						if (RuntimeDebugModeGuiMixin.button(all[i].ToString()))
						{
							dailySkills.Add(all[i].Id);
							selectDailySkill();
							break;
						}
					}
				});
			}
		});
		return actionClassaddNewDailySkill;
	}

	public ActionClassaddNewDailySkill createaddNewDailySkill()
	{
		return createDataaddNewDailySkill();
	}

	private void weaponSelectList(Team team, int index)
	{
		int i = 0;
		RespWeapon[] boxWeapons = UserData.Current.BoxWeapons;
		for (int length = boxWeapons.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeDebugModeGuiMixin.button(WeaponLabel(boxWeapons[i])))
			{
				team.setMemberWeapon(index, boxWeapons[i]);
				main();
				break;
			}
		}
	}

	private RespWeapon getDefaultWeapon()
	{
		UserData current = UserData.Current;
		RespWeapon[] boxWeapons = current.BoxWeapons;
		return (0 >= boxWeapons.Length) ? new RespWeapon(2) : boxWeapons[0];
	}

	private static string PoppetLabel(RespPoppet ppt)
	{
		return (ppt != null) ? new StringBuilder().Append((object)ppt.Master.Id).Append(" ").Append(ppt.Name)
			.Append(" LV ")
			.Append((object)ppt.Level)
			.Append(" ")
			.Append((object)ppt.ChainSkillLevel)
			.Append("/")
			.Append((object)ppt.CoverSkillLevel_1)
			.Append("/")
			.Append((object)ppt.CoverSkillLevel_2)
			.ToString() : "<null>";
	}

	private static string WeaponLabel(RespWeapon wpn)
	{
		return (wpn != null) ? new StringBuilder().Append(wpn.Name).Append(" LV ").Append((object)wpn.Level)
			.Append("/")
			.Append((object)wpn.LevelMax)
			.Append(" ")
			.Append((object)wpn.AngelSkillLevel)
			.Append("/")
			.Append((object)wpn.DemonSkillLevel)
			.Append("/")
			.Append((object)wpn.CoverSkillLevel)
			.ToString() : "<null>";
	}

	internal IEnumerator _0024Start_0024init_00244385()
	{
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			main();
		});
		return null;
	}

	internal void _0024_0024Start_0024init_00244385_0024closure_00244386()
	{
		main();
	}

	internal void _0024createDatamain_0024closure_00244388(ActionClassmain _0024act_0024t_00241455)
	{
		_0024_0024createDatamain_0024closure_00244388_0024locals_002414378 _0024_0024createDatamain_0024closure_00244388_0024locals_0024 = new _0024_0024createDatamain_0024closure_00244388_0024locals_002414378();
		_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024teamLabelStyle = RuntimeDebugModeGuiMixin.optWidth(300);
		_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024labelStyle = RuntimeDebugModeGuiMixin.optWidth(300);
		_0024_0024createDatamain_0024closure_00244388_0024locals_0024._0024vsStyle = RuntimeDebugModeGuiMixin.optWidth(80);
		RuntimeDebugModeGuiMixin.vertical(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamain_0024closure_00244388_0024closure_00244389(_0024_0024createDatamain_0024closure_00244388_0024locals_0024, this).Invoke));
	}

	internal void _0024_0024_0024createDatamain_0024closure_00244388_0024closure_00244389_0024closure_00244390()
	{
		RuntimeDebugModeGuiMixin.label("select poppets");
		if (RuntimeDebugModeGuiMixin.button("daily skill"))
		{
			selectDailySkill();
		}
	}

	internal void _0024createDataselectFromBox_0024closure_00244394(ActionClassselectFromBox _0024act_0024t_00241474)
	{
		_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381 _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024 = new _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_002414381();
		_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474 = _0024act_0024t_00241474;
		UserData current = UserData.Current;
		_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024ppts = current.BoxPoppets;
		RuntimeDebugModeGuiMixin.label("ボックスから追加モード");
		if (RuntimeDebugModeGuiMixin.button("友達/冒険者から追加する"))
		{
			selectFromFriends(_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474.team);
		}
		if (RuntimeDebugModeGuiMixin.button("マスタから追加する"))
		{
			selectFromMaster(_0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024._0024_0024act_0024t_00241474.team);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.scrollView("poppetView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromBox_0024closure_00244394_0024closure_00244395(this, _0024_0024createDataselectFromBox_0024closure_00244394_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			main();
		}
	}

	internal void _0024createDataselectFromFriends_0024closure_00244396(ActionClassselectFromFriends _0024act_0024t_00241477)
	{
		_0024act_0024t_00241477.req = new ApiFriendPlayerSearch();
		_0024act_0024t_00241477.req.IsRecommend = true;
		_0024act_0024t_00241477.req.Num = 100;
		_0024act_0024t_00241477.req.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			main();
		});
		MerlinServer.Request(_0024act_0024t_00241477.req);
	}

	internal void _0024_0024createDataselectFromFriends_0024closure_00244396_0024closure_00244397()
	{
		main();
	}

	internal void _0024createDataselectFromFriends_0024closure_00244398(ActionClassselectFromFriends _0024act_0024t_00241477)
	{
		_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382 _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024 = new _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_002414382();
		_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477 = _0024act_0024t_00241477;
		if (_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.req.IsOk)
		{
			_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024friends = _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.req.GetResponse().Friends;
			RuntimeDebugModeGuiMixin.label("友達/冒険者から追加モード");
			if (RuntimeDebugModeGuiMixin.button("ボックスから追加する"))
			{
				selectFromBox(_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.team);
			}
			if (RuntimeDebugModeGuiMixin.button("マスタから追加する"))
			{
				selectFromMaster(_0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024._0024_0024act_0024t_00241477.team);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.scrollView("friendView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromFriends_0024closure_00244398_0024closure_00244399(this, _0024_0024createDataselectFromFriends_0024closure_00244398_0024locals_0024).Invoke));
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				main();
			}
		}
	}

	internal void _0024createDataselectFromMaster_0024closure_00244400(ActionClassselectFromMaster _0024act_0024t_00241480)
	{
		_0024act_0024t_00241480.poppets = new Boo.Lang.List<RespPoppet>();
		_0024act_0024t_00241480.maxPoppets = new Boo.Lang.List<RespPoppet>();
		int i = 0;
		MPoppets[] all = MPoppets.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			_0024act_0024t_00241480.poppets.Add(new RespPoppet(all[i]));
			RespPoppet respPoppet = new RespPoppet(all[i]);
			MPoppets master = respPoppet.Master;
			respPoppet.Level = master.LevelLimitMax;
			respPoppet.LevelMax = master.LevelLimitMax;
			respPoppet.ChainSkillLevel = master.ChainSkillId.LevelMax;
			if (master.CoverSkillId_1 != null)
			{
				respPoppet.CoverSkillLevel_1 = master.CoverSkillId_1.LevelMax;
			}
			if (master.CoverSkillId_2 != null)
			{
				respPoppet.CoverSkillLevel_2 = master.CoverSkillId_2.LevelMax;
			}
			_0024act_0024t_00241480.maxPoppets.Add(respPoppet);
		}
		_0024act_0024t_00241480.page = 0;
	}

	internal void _0024createDataselectFromMaster_0024closure_00244401(ActionClassselectFromMaster _0024act_0024t_00241480)
	{
		_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383 _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024 = new _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_002414383();
		_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480 = _0024act_0024t_00241480;
		_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024pageStep = 100;
		RuntimeDebugModeGuiMixin.label("マスタから追加モード");
		if (RuntimeDebugModeGuiMixin.button("ボックスから追加する"))
		{
			selectFromBox(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480.team);
		}
		if (RuntimeDebugModeGuiMixin.button("友達/冒険者から追加する"))
		{
			selectFromFriends(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024._0024_0024act_0024t_00241480.team);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244402(_0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024, this).Invoke));
		RuntimeDebugModeGuiMixin.scrollView("masterView", 1000, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectFromMaster_0024closure_00244401_0024closure_00244403(this, _0024_0024createDataselectFromMaster_0024closure_00244401_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			main();
		}
	}

	internal void _0024createDataselectWeapons_0024closure_00244405(ActionClassselectWeapons _0024act_0024t_00241483)
	{
		_0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385 _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024 = new _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_002414385();
		_0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024._0024_0024act_0024t_00241483 = _0024act_0024t_00241483;
		RuntimeDebugModeGuiMixin.label("武器選択（ボックス）");
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			main();
			return;
		}
		RuntimeDebugModeGuiMixin.scrollView("weaponView", 600, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectWeapons_0024closure_00244405_0024closure_00244406(this, _0024_0024createDataselectWeapons_0024closure_00244405_0024locals_0024).Invoke));
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			main();
		}
	}

	internal void _0024createDataselectDailySkill_0024closure_00244407(ActionClassselectDailySkill _0024act_0024t_00241486)
	{
		_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386 _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024 = new _0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_002414386();
		RuntimeDebugModeGuiMixin.label("デイリー援護スキル選択");
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			main();
			return;
		}
		if (RuntimeDebugModeGuiMixin.button("新規追加"))
		{
			addNewDailySkill();
		}
		RuntimeDebugModeGuiMixin.space(10);
		int num = 0;
		int count = dailySkills.Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int num2 = num;
			num++;
			_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024._0024sid = dailySkills[num2];
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataselectDailySkill_0024closure_00244407_0024closure_00244408(_0024_0024createDataselectDailySkill_0024closure_00244407_0024locals_0024, this, num2).Invoke));
		}
	}

	internal void _0024createDataaddNewDailySkill_0024closure_00244409(ActionClassaddNewDailySkill _0024act_0024t_00241489)
	{
		RuntimeDebugModeGuiMixin.label("追加援護スキル選択");
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			selectDailySkill();
			return;
		}
		RuntimeDebugModeGuiMixin.scrollView("skillview", 800, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			int i = 0;
			MCoverSkills[] all = MCoverSkills.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeDebugModeGuiMixin.button(all[i].ToString()))
				{
					dailySkills.Add(all[i].Id);
					selectDailySkill();
					break;
				}
			}
		});
	}

	internal void _0024_0024createDataaddNewDailySkill_0024closure_00244409_0024closure_00244410()
	{
		int i = 0;
		MCoverSkills[] all = MCoverSkills.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeDebugModeGuiMixin.button(all[i].ToString()))
			{
				dailySkills.Add(all[i].Id);
				selectDailySkill();
				break;
			}
		}
	}
}
