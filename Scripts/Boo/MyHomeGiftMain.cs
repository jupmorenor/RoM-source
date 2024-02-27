using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MyHomeGiftMain : MyhomeSubSceneTopMain
{
	[Serializable]
	private enum ReceiveGiftTypeGroup
	{
		ALL,
		EXCLUDING_EQUIP
	}

	[Serializable]
	internal class _0024PushAccept_0024locals_002414524
	{
		internal RespPlayerPresentBox _0024item;

		internal GameObject _0024go;
	}

	[Serializable]
	internal class _0024ReceivePresent_0024locals_002414525
	{
		internal bool _0024fin;
	}

	[Serializable]
	internal class _0024ReceiveSomePresent_0024locals_002414526
	{
		internal UIListBase.Container[] _0024deleteContainers;

		internal ApiPresentReceipt _0024apiReceipt;
	}

	[Serializable]
	internal class _0024PushAccept_0024f_00245054
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421766 : GenericGenerator<Coroutine>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
			{
				internal int _0024presentIndex_002421767;

				internal IEnumerator _0024_0024sco_0024temp_00242624_002421768;

				internal _0024PushAccept_0024f_00245054 _0024self__002421769;

				public _0024(_0024PushAccept_0024f_00245054 self_)
				{
					_0024self__002421769 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024presentIndex_002421767 = _0024self__002421769._0024_0024locals_002415164._0024item.Id;
						_0024_0024sco_0024temp_00242624_002421768 = _0024self__002421769._0024this_002415165.ReceivePresent(_0024self__002421769._0024_0024locals_002415164._0024go.transform.parent.gameObject, _0024self__002421769._0024_0024locals_002415164._0024item);
						if (_0024_0024sco_0024temp_00242624_002421768 != null)
						{
							result = (Yield(2, _0024self__002421769._0024this_002415165.StartCoroutine(_0024_0024sco_0024temp_00242624_002421768)) ? 1 : 0);
							break;
						}
						goto case 2;
					case 2:
						StorageHUD.DoUpdateNow();
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024PushAccept_0024f_00245054 _0024self__002421770;

			public _0024Invoke_002421766(_0024PushAccept_0024f_00245054 self_)
			{
				_0024self__002421770 = self_;
			}

			public override IEnumerator<Coroutine> GetEnumerator()
			{
				return new _0024(_0024self__002421770);
			}
		}

		internal _0024PushAccept_0024locals_002414524 _0024_0024locals_002415164;

		internal MyHomeGiftMain _0024this_002415165;

		public _0024PushAccept_0024f_00245054(_0024PushAccept_0024locals_002414524 _0024_0024locals_002415164, MyHomeGiftMain _0024this_002415165)
		{
			this._0024_0024locals_002415164 = _0024_0024locals_002415164;
			this._0024this_002415165 = _0024this_002415165;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421766(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024ReceivePresent_0024closure_00245055
	{
		internal _0024ReceivePresent_0024locals_002414525 _0024_0024locals_002415166;

		public _0024ReceivePresent_0024closure_00245055(_0024ReceivePresent_0024locals_002414525 _0024_0024locals_002415166)
		{
			this._0024_0024locals_002415166 = _0024_0024locals_002415166;
		}

		public void Invoke(UITweener tw)
		{
			_0024_0024locals_002415166._0024fin = true;
		}
	}

	[Serializable]
	internal class _0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421771 : GenericGenerator<WaitForSeconds>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
			{
				internal int _0024count_002421772;

				internal UIListBase.Container _0024cont_002421773;

				internal GameObject _0024go_002421774;

				internal GiftListItem _0024item_002421775;

				internal EnumMasterTypeValues _0024targetItemType_002421776;

				internal TweenAlpha _0024alph_002421777;

				internal TweenScale _0024scale_002421778;

				internal int _0024listCount_002421779;

				internal UIListBase.Container _0024cont_002421780;

				internal int _0024deleteContainerIndex_002421781;

				internal bool _0024canDisableUnEquipButton_002421782;

				internal int _0024_002411404_002421783;

				internal UIListBase.Container[] _0024_002411405_002421784;

				internal int _0024_002411406_002421785;

				internal int _0024_002411408_002421786;

				internal UIListBase.Container[] _0024_002411409_002421787;

				internal int _0024_002411410_002421788;

				internal _0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058 _0024self__002421789;

				public _0024(_0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058 self_)
				{
					_0024self__002421789 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024self__002421789._0024this_002415167.SwitchStateReceiveAllButton(state: false);
							_0024self__002421789._0024this_002415167.SwitchStateReceiveUnequipButton(state: false);
							_0024count_002421772 = 0;
							_0024_002411404_002421783 = 0;
							_0024_002411405_002421784 = _0024self__002421789._0024_0024locals_002415168._0024deleteContainers;
							for (_0024_002411406_002421785 = _0024_002411405_002421784.Length; _0024_002411404_002421783 < _0024_002411406_002421785; _0024_002411404_002421783++)
							{
								_0024go_002421774 = _0024_002411405_002421784[_0024_002411404_002421783].obj;
								if (_0024go_002421774 != null)
								{
									_0024item_002421775 = _0024go_002421774.GetComponent<GiftListItem>();
									_0024targetItemType_002421776 = unchecked((EnumMasterTypeValues)RuntimeServices.UnboxInt32(_0024item_002421775.hash["MasterTypeValue"]));
									_0024count_002421772++;
									_0024alph_002421777 = TweenAlpha.Begin(_0024go_002421774, 0.08f, 0f);
									_0024scale_002421778 = TweenScale.Begin(_0024go_002421774, 0.08f, new Vector3(0f, 0f, 0f));
									_0024scale_002421778.delay = (float)_0024count_002421772 * 0.06f;
									_0024alph_002421777.delay = (float)_0024count_002421772 * 0.06f;
								}
							}
							result = (Yield(2, new WaitForSeconds((float)_0024count_002421772 * 0.03f + 0.1f)) ? 1 : 0);
							break;
						case 2:
							_0024listCount_002421779 = _0024self__002421789._0024this_002415167.PresentListUI.Count();
							_0024_002411408_002421786 = 0;
							_0024_002411409_002421787 = _0024self__002421789._0024_0024locals_002415168._0024deleteContainers;
							for (_0024_002411410_002421788 = _0024_002411409_002421787.Length; _0024_002411408_002421786 < _0024_002411410_002421788; _0024_002411408_002421786++)
							{
								_0024deleteContainerIndex_002421781 = _0024self__002421789._0024this_002415167.PresentListUI.GetIndex(_0024_002411409_002421787[_0024_002411408_002421786].data);
								_0024self__002421789._0024this_002415167.PresentListUI.DeleteItem(_0024deleteContainerIndex_002421781);
							}
							_0024canDisableUnEquipButton_002421782 = _0024self__002421789._0024this_002415167.CanDisableReceiveUnEquipPresentButton();
							_0024self__002421789._0024this_002415167.SwitchStateReceiveUnequipButton(!_0024canDisableUnEquipButton_002421782);
							_0024listCount_002421779 = _0024self__002421789._0024this_002415167.PresentListUI.Count();
							if (_0024listCount_002421779 == 0)
							{
								UnityEngine.Object.Destroy(_0024self__002421789._0024this_002415167.listRoot);
							}
							_0024self__002421789._0024this_002415167.SwitchStateReceiveAllButton(_0024listCount_002421779 != 0);
							if ((bool)QuestManager.CurrentInstance)
							{
								QuestManager.CurrentInstance.CheckBoxOver = true;
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							goto IL_02ff;
						case 3:
							if (!InventoryOverDialog.IsOpenInventoryOverDialog())
							{
								goto IL_02ff;
							}
							goto case 1;
						case 4:
							if (0 > DialogManager.LastResult)
							{
								result = (YieldDefault(4) ? 1 : 0);
								break;
							}
							_0024self__002421789._0024this_002415167.LockButton(on: false);
							_0024self__002421789._0024this_002415167.PushBack();
							goto IL_039c;
						case 1:
							{
								result = 0;
								break;
							}
							IL_02ff:
							if (_0024listCount_002421779 == 0)
							{
								DialogManager.InitLastResult = -1;
								_0024self__002421789._0024this_002415167.dlgMan.OpenDialog(MTexts.Msg("$MHG_RECEIVE_ALL_ITEMS"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
								goto case 4;
							}
							_0024self__002421789._0024this_002415167.PresentListUI.ScrollToTarget(0);
							goto IL_039c;
							IL_039c:
							YieldDefault(1);
							goto case 1;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058 _0024self__002421790;

			public _0024Invoke_002421771(_0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058 self_)
			{
				_0024self__002421790 = self_;
			}

			public override IEnumerator<WaitForSeconds> GetEnumerator()
			{
				return new _0024(_0024self__002421790);
			}
		}

		internal MyHomeGiftMain _0024this_002415167;

		internal _0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415168;

		public _0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058(MyHomeGiftMain _0024this_002415167, _0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415168)
		{
			this._0024this_002415167 = _0024this_002415167;
			this._0024_0024locals_002415168 = _0024_0024locals_002415168;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421771(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057
	{
		internal _0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415169;

		internal MyHomeGiftMain _0024this_002415170;

		public _0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057(_0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415169, MyHomeGiftMain _0024this_002415170)
		{
			this._0024_0024locals_002415169 = _0024_0024locals_002415169;
			this._0024this_002415170 = _0024this_002415170;
		}

		public void Invoke(RequestBase r)
		{
			ExtensionsModule.PostStartCoroutine(_0024this_002415170, new _0024_0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057_0024closure_00245058(_0024this_002415170, _0024_0024locals_002415169).Invoke);
		}
	}

	[Serializable]
	internal class _0024ReceiveSomePresent_0024f_00245056
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421791 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal __MerlinServer_Request_0024callable86_0024160_56__ _0024cb_002421792;

				internal _0024ReceiveSomePresent_0024f_00245056 _0024self__002421793;

				public _0024(_0024ReceiveSomePresent_0024f_00245056 self_)
				{
					_0024self__002421793 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024cb_002421792 = new _0024_0024ReceiveSomePresent_0024f_00245056_0024cb_00245057(_0024self__002421793._0024_0024locals_002415172, _0024self__002421793._0024this_002415171).Invoke;
						if (_0024self__002421793._0024this_002415171.テスト)
						{
							_0024cb_002421792(null);
							goto IL_00c4;
						}
						MerlinServer.Request(_0024self__002421793._0024_0024locals_002415172._0024apiReceipt, _0024cb_002421792);
						goto case 2;
					case 2:
						if (!_0024self__002421793._0024_0024locals_002415172._0024apiReceipt.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421793._0024this_002415171.LockButton(on: false);
						goto IL_00c4;
					case 3:
						StorageHUD.DoUpdateNow();
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00c4:
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024ReceiveSomePresent_0024f_00245056 _0024self__002421794;

			public _0024Invoke_002421791(_0024ReceiveSomePresent_0024f_00245056 self_)
			{
				_0024self__002421794 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421794);
			}
		}

		internal MyHomeGiftMain _0024this_002415171;

		internal _0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415172;

		public _0024ReceiveSomePresent_0024f_00245056(MyHomeGiftMain _0024this_002415171, _0024ReceiveSomePresent_0024locals_002414526 _0024_0024locals_002415172)
		{
			this._0024this_002415171 = _0024this_002415171;
			this._0024_0024locals_002415172 = _0024_0024locals_002415172;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421791(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SetList_002421746 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiPresent _0024apiPresent_002421747;

			internal bool _0024canDisableUnEquipButton_002421748;

			internal MyHomeGiftMain _0024self__002421749;

			public _0024(MyHomeGiftMain self_)
			{
				_0024self__002421749 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024apiPresent_002421747 = new ApiPresent();
					MerlinServer.Request(_0024apiPresent_002421747);
					goto case 2;
				case 2:
					if (!_0024apiPresent_002421747.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					StorageHUD.DoUpdateNow();
					_0024self__002421749.LockButton(on: false);
					_0024self__002421749.presentBoxes = ArrayMapMain.FilterResps(_0024apiPresent_002421747.GetResponse().PresentBox, (RespPlayerPresentBox x) => !x.IsReceive);
					Array.Sort(_0024self__002421749.presentBoxes, _0024adaptor_0024__MyHomeGiftMain_0024callable366_002486_42___0024Comparison_0024204.Adapt((RespPlayerPresentBox a, RespPlayerPresentBox b) => DateTime.Compare(b.SendDate, a.SendDate)));
					_0024self__002421749.ChangeSituation(_0024self__002421749.GetSituation(0));
					_0024self__002421749.SwitchStateReceiveAllButton(state: false);
					_0024self__002421749.SwitchStateReceiveUnequipButton(state: false);
					_0024self__002421749.PresentListUI.SetResponse(_0024self__002421749.presentBoxes, _0024self__002421749.gameObject);
					goto case 3;
				case 3:
					result = ((_0024self__002421749.PresentListUI.isInitFinished ? YieldDefault(4) : YieldDefault(3)) ? 1 : 0);
					break;
				case 4:
					_0024self__002421749.SwitchStateReceiveAllButton(0 < _0024self__002421749.presentBoxes.Length);
					_0024canDisableUnEquipButton_002421748 = _0024self__002421749.CanDisableReceiveUnEquipPresentButton();
					_0024self__002421749.SwitchStateReceiveUnequipButton(!_0024canDisableUnEquipButton_002421748);
					UserData.Current.NewPresentData = _0024self__002421749.presentBoxes.Length;
					_0024self__002421749.setListFlag = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeGiftMain _0024self__002421750;

		public _0024SetList_002421746(MyHomeGiftMain self_)
		{
			_0024self__002421750 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421750);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RunInventoryOverCheck_002421751 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024inst_002421752;

			internal MyHomeGiftMain _0024self__002421753;

			public _0024(MyHomeGiftMain self_)
			{
				_0024self__002421753 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!InventoryOverDialog.IsInventoryOver())
					{
						goto case 1;
					}
					goto case 2;
				case 2:
					if (!(_0024inst_002421752 = InventoryOverDialog.Instance))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421753.overItemDlg = _0024inst_002421752;
					_0024self__002421753.overItemDlg.SetActive(value: false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeGiftMain _0024self__002421754;

		public _0024RunInventoryOverCheck_002421751(MyHomeGiftMain self_)
		{
			_0024self__002421754 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421754);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReceivePresent_002421755 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ApiPresentReceipt _0024apiReceipt_002421756;

			internal bool _0024ok_002421757;

			internal bool _0024canDisableUnEquipButton_002421758;

			internal _0024ReceivePresent_0024locals_002414525 _0024_0024locals_002421759;

			internal GameObject _0024go_002421760;

			internal RespPlayerPresentBox _0024presentData_002421761;

			internal MyHomeGiftMain _0024self__002421762;

			public _0024(GameObject go, RespPlayerPresentBox presentData, MyHomeGiftMain self_)
			{
				_0024go_002421760 = go;
				_0024presentData_002421761 = presentData;
				_0024self__002421762 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421759 = new _0024ReceivePresent_0024locals_002414525();
					_0024self__002421762.LockButton(on: true);
					_0024_0024locals_002421759._0024fin = false;
					_0024apiReceipt_002421756 = new ApiPresentReceipt();
					_0024apiReceipt_002421756.Id = _0024presentData_002421761.Id.ToString();
					_0024ok_002421757 = default(bool);
					if (_0024self__002421762.テスト)
					{
						_0024ok_002421757 = true;
						goto IL_00d5;
					}
					MerlinServer.Request(_0024apiReceipt_002421756);
					goto case 2;
				case 2:
					if (!_0024apiReceipt_002421756.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024ok_002421757 = _0024apiReceipt_002421756.IsOk;
					goto IL_00d5;
				case 3:
					result = ((_0024_0024locals_002421759._0024fin ? Yield(4, new WaitForSeconds(0.3f)) : YieldDefault(3)) ? 1 : 0);
					break;
				case 4:
					_0024self__002421762.PresentListUI.DeleteItem(_0024go_002421760);
					_0024self__002421762.SwitchStateReceiveAllButton(0 < _0024self__002421762.PresentListUI.Count());
					_0024canDisableUnEquipButton_002421758 = _0024self__002421762.CanDisableReceiveUnEquipPresentButton();
					_0024self__002421762.SwitchStateReceiveUnequipButton(!_0024canDisableUnEquipButton_002421758);
					result = (YieldDefault(5) ? 1 : 0);
					break;
				case 5:
					_0024self__002421762.LockButton(on: false);
					if ((bool)QuestManager.CurrentInstance)
					{
						QuestManager.CurrentInstance.CheckBoxOver = true;
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					goto IL_0217;
				case 6:
					if (InventoryOverDialog.IsOpenInventoryOverDialog())
					{
						goto case 1;
					}
					goto IL_0217;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00d5:
					if (_0024ok_002421757)
					{
						TweenAlpha.Begin(_0024go_002421760, 0.08f, 0f);
						TweenScale.Begin(_0024go_002421760, 0.08f, new Vector3(0f, 0f, 0f)).onFinished = new _0024ReceivePresent_0024closure_00245055(_0024_0024locals_002421759).Invoke;
						goto case 3;
					}
					_0024self__002421762.LockButton(on: false);
					goto IL_0217;
					IL_0217:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024go_002421763;

		internal RespPlayerPresentBox _0024presentData_002421764;

		internal MyHomeGiftMain _0024self__002421765;

		public _0024ReceivePresent_002421755(GameObject go, RespPlayerPresentBox presentData, MyHomeGiftMain self_)
		{
			_0024go_002421763 = go;
			_0024presentData_002421764 = presentData;
			_0024self__002421765 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024go_002421763, _0024presentData_002421764, _0024self__002421765);
		}
	}

	private DialogManager dlgMan;

	private RespPlayerPresentBox[] presentBoxes;

	private GameObject listRoot;

	public bool テスト;

	public PresentList PresentListUI;

	public UIButtonMessage lumpButton;

	private bool setListFlag;

	private GameObject overItemDlg;

	public WeaponInfo weaponInfo;

	public MuppetInfo petInfo;

	protected bool lockButton;

	private bool isShowDetail;

	private bool isWeaponDetal;

	private bool isInAnim;

	public bool IsEnableButton()
	{
		return !lockButton && SceneChanger.isCompletelyReady && !IsChangingSituation && !MerlinServer.Busy;
	}

	public void LockButton(bool on)
	{
		lockButton = on;
	}

	public override void StartCore()
	{
		weaponInfo.DestroyLevel();
		petInfo.DestroyLevel();
		IEnumerator enumerator = RunInventoryOverCheck();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		StartInit();
	}

	public override void SceneUpdate()
	{
		if (PresentListUI.Count() == 0)
		{
			LockButton(on: false);
		}
	}

	private void StartInit()
	{
		テスト = false;
		dlgMan = DialogManager.Instance;
		IEnumerator enumerator = SetList();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	protected IEnumerator SetList()
	{
		return new _0024SetList_002421746(this).GetEnumerator();
	}

	public void SwitchStateReceiveAllButton(bool state)
	{
		ButtonStateChange(GetSituation(0).gameObject, "AnchorCenter", new string[1] { "0 lump all" }, state, null);
	}

	public void SwitchStateReceiveUnequipButton(bool state)
	{
		ButtonStateChange(GetSituation(0).gameObject, "AnchorCenter", new string[1] { "1 lump unequip" }, state, null);
	}

	public IEnumerator RunInventoryOverCheck()
	{
		return new _0024RunInventoryOverCheck_002421751(this).GetEnumerator();
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state, string text)
	{
		GameObject go = ExtensionsModule.FindChild(situationRoot, panelName);
		Color color = ((!state) ? Color.grey : Color.white);
		int i = 0;
		for (int length = buttonNames.Length; i < length; i = checked(i + 1))
		{
			GameObject gameObject = ExtensionsModule.FindChild(go, buttonNames[i]);
			GameObject gameObject2 = ExtensionsModule.FindChild(gameObject, "Text");
			gameObject2.GetComponent<UIWidget>().color = color;
			if (text != null)
			{
				gameObject2.GetComponent<UILabelBase>().text = text;
			}
			UIButtonMessage uIButtonMessage = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
			uIButtonMessage.enabled = true;
			uIButtonMessage.merlinPuwaEnable = state;
			uIButtonMessage.sendMessage = state;
			ExtensionsModule.FindChild(gameObject, "Background").GetComponent<UIWidget>().color = color;
			TweenScale component = gameObject.GetComponent<TweenScale>();
			if ((bool)component)
			{
				component._from = Vector3.zero;
				component.to = Vector3.one;
				component.Play(forward: true);
			}
			gameObject.gameObject.collider.enabled = state;
		}
	}

	public void ButtonKill(GameObject situationRoot, string panelName, string[] buttonNames)
	{
		GameObject go = ExtensionsModule.FindChild(situationRoot, panelName);
		Color grey = Color.grey;
		int i = 0;
		for (int length = buttonNames.Length; i < length; i = checked(i + 1))
		{
			GameObject gameObject = ExtensionsModule.FindChild(go, buttonNames[i]);
			GameObject gameObject2 = ExtensionsModule.FindChild(gameObject, "Text");
			gameObject2.GetComponent<UIWidget>().color = grey;
			UIButtonMessage component = gameObject.GetComponent<UIButtonMessage>();
			if ((bool)component)
			{
				component.enabled = false;
			}
			GameObject go2 = ExtensionsModule.FindChild(gameObject, "Background");
			TweenColor.Begin(go2, 0f, grey);
		}
	}

	public void ActiveOverItemDlg()
	{
		if (!overItemDlg)
		{
			return;
		}
		InventoryOverDialog.PushCallBack = delegate(InventoryOverDialog.Mode dlgMode)
		{
			int result;
			if (dlgMode == InventoryOverDialog.Mode.Back)
			{
				overItemDlg.SetActive(value: false);
				result = 1;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		};
		overItemDlg.SetActive(value: true);
		LockButton(on: false);
	}

	public void PushAccept(GameObject go)
	{
		_0024PushAccept_0024locals_002414524 _0024PushAccept_0024locals_0024 = new _0024PushAccept_0024locals_002414524();
		_0024PushAccept_0024locals_0024._0024go = go;
		if (!IsEnableButton())
		{
			return;
		}
		GiftListItem component = _0024PushAccept_0024locals_0024._0024go.transform.parent.GetComponent<GiftListItem>();
		if (!component)
		{
			return;
		}
		_0024PushAccept_0024locals_0024._0024item = component.GetData<RespPlayerPresentBox>();
		if ((bool)overItemDlg && component.hash != null)
		{
			EnumMasterTypeValues enumMasterTypeValues = (EnumMasterTypeValues)RuntimeServices.UnboxInt32(component.hash["MasterTypeValue"]);
			if (enumMasterTypeValues == EnumMasterTypeValues.Weapon || enumMasterTypeValues == EnumMasterTypeValues.Poppet)
			{
				ActiveOverItemDlg();
				return;
			}
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PushAccept_0024f_00245054(_0024PushAccept_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator ReceivePresent(GameObject go, RespPlayerPresentBox presentData)
	{
		return new _0024ReceivePresent_002421755(go, presentData, this).GetEnumerator();
	}

	private void PushAcceptAll()
	{
		if (!IsEnableButton())
		{
			return;
		}
		checked
		{
			if ((bool)overItemDlg)
			{
				int num = 0;
				num += PresentListUI.GetMasterTypeCount(EnumMasterTypeValues.Weapon);
				num += PresentListUI.GetMasterTypeCount(EnumMasterTypeValues.Poppet);
				if (num > 0)
				{
					ActiveOverItemDlg();
					return;
				}
			}
			ReceiveSomePresent(ReceiveGiftTypeGroup.ALL);
		}
	}

	private void PushAcceptAllUnEquip()
	{
		if (IsEnableButton())
		{
			ReceiveSomePresent(ReceiveGiftTypeGroup.EXCLUDING_EQUIP);
		}
	}

	private void PushAcceptSomeType(ReceiveGiftTypeGroup giftGroupType)
	{
		if (IsEnableButton())
		{
			ReceiveSomePresent(giftGroupType);
		}
	}

	private EnumMasterTypeValues[] ReceiveGiftTypeGroup2EnumMasterTypeValues(ReceiveGiftTypeGroup giftGroupType)
	{
		object result;
		switch (giftGroupType)
		{
		case ReceiveGiftTypeGroup.ALL:
		{
			EnumMasterTypeValues[] lhs = ReceiveGiftTypeGroup2EnumMasterTypeValues(ReceiveGiftTypeGroup.EXCLUDING_EQUIP);
			lhs = (EnumMasterTypeValues[])RuntimeServices.AddArrays(typeof(EnumMasterTypeValues), lhs, new EnumMasterTypeValues[2]
			{
				EnumMasterTypeValues.Weapon,
				EnumMasterTypeValues.Poppet
			});
			result = lhs;
			break;
		}
		case ReceiveGiftTypeGroup.EXCLUDING_EQUIP:
			result = new EnumMasterTypeValues[7]
			{
				EnumMasterTypeValues.Exp,
				EnumMasterTypeValues.Coin,
				EnumMasterTypeValues.Candy,
				EnumMasterTypeValues.FayStone,
				EnumMasterTypeValues.KeyItem,
				EnumMasterTypeValues.FriendPoint,
				EnumMasterTypeValues.ManaPoint
			};
			break;
		default:
			if (0 == 0)
			{
				throw new AssertionFailedException("false");
			}
			result = null;
			break;
		}
		return (EnumMasterTypeValues[])result;
	}

	private bool CanDisableReceiveUnEquipPresentButton()
	{
		EnumMasterTypeValues[] masterTypes = ReceiveGiftTypeGroup2EnumMasterTypeValues(ReceiveGiftTypeGroup.EXCLUDING_EQUIP);
		return GetDeleteTargetContainers(masterTypes).Length == 0;
	}

	private void ReceiveSomePresent(ReceiveGiftTypeGroup giftGroupType)
	{
		ReceiveSomePresent(ReceiveGiftTypeGroup2EnumMasterTypeValues(giftGroupType));
	}

	private UIListBase.Container[] GetDeleteTargetContainers(EnumMasterTypeValues[] masterTypes)
	{
		__MyHomeGiftMain_GetDeleteTargetContainers_0024callable186_0024281_13__ _MyHomeGiftMain_GetDeleteTargetContainers_0024callable186_0024281_13__ = delegate(EnumMasterTypeValues itemType, EnumMasterTypeValues[] types)
		{
			int num = 0;
			int length = types.Length;
			int result;
			while (true)
			{
				if (num >= length)
				{
					result = 0;
					break;
				}
				if (itemType == types[num])
				{
					result = 1;
					break;
				}
				num = checked(num + 1);
			}
			return (byte)result != 0;
		};
		UIListBase.Container[] array = new UIListBase.Container[0];
		IEnumerator<UIListBase.Container> enumerator = PresentListUI.EnumerateContainer().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				UIListBase.Container current = enumerator.Current;
				UIListItem.Data data = current.data;
				RespPlayerPresentBox data2 = data.GetData<RespPlayerPresentBox>();
				Hashtable hashtable = NGUIJson.jsonDecode(data2.ItemData) as Hashtable;
				EnumMasterTypeValues itemType2 = (EnumMasterTypeValues)RuntimeServices.UnboxInt32(hashtable["MasterTypeValue"]);
				if (_MyHomeGiftMain_GetDeleteTargetContainers_0024callable186_0024281_13__(itemType2, masterTypes))
				{
					array = (UIListBase.Container[])RuntimeServices.AddArrays(typeof(UIListBase.Container), array, new UIListBase.Container[1] { current });
				}
			}
			return array;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private void ReceiveSomePresent(EnumMasterTypeValues[] masterTypes)
	{
		_0024ReceiveSomePresent_0024locals_002414526 _0024ReceiveSomePresent_0024locals_0024 = new _0024ReceiveSomePresent_0024locals_002414526();
		LockButton(on: true);
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		UIListItem.Data[] dataList = PresentListUI.GetDataList();
		_0024ReceiveSomePresent_0024locals_0024._0024deleteContainers = GetDeleteTargetContainers(masterTypes);
		int i = 0;
		UIListBase.Container[] _0024deleteContainers = _0024ReceiveSomePresent_0024locals_0024._0024deleteContainers;
		for (int length = _0024deleteContainers.Length; i < length; i = checked(i + 1))
		{
			RespPlayerPresentBox data = _0024deleteContainers[i].data.GetData<RespPlayerPresentBox>();
			string item = data.Id.ToString();
			list.Add(item);
		}
		if (list.Count == 0)
		{
			LockButton(on: false);
			return;
		}
		string id = Builtins.join(list, ",");
		_0024ReceiveSomePresent_0024locals_0024._0024apiReceipt = new ApiPresentReceipt();
		_0024ReceiveSomePresent_0024locals_0024._0024apiReceipt.Id = id;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024ReceiveSomePresent_0024f_00245056(this, _0024ReceiveSomePresent_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void PushDetail(GameObject obj)
	{
		if (isShowDetail || !IsEnableButton() || obj == null)
		{
			return;
		}
		UIListItem component = obj.GetComponent<UIListItem>();
		if (component == null)
		{
			return;
		}
		LockButton(on: true);
		if (component is WeaponListItem)
		{
			isInAnim = true;
			UIAutoTweenerStandAloneEx.In(weaponInfo.gameObject, delegate
			{
				isInAnim = false;
				LockButton(on: false);
			});
			weaponInfo.SetWeapon(((WeaponListItem)component).weaponInfo);
			isWeaponDetal = true;
		}
		else if (component is MapetListItem)
		{
			isInAnim = true;
			UIAutoTweenerStandAloneEx.In(petInfo.gameObject, delegate
			{
				isInAnim = false;
				LockButton(on: false);
			});
			petInfo.SetMuppet(((MapetListItem)component).mapetInfo);
			isWeaponDetal = false;
		}
		isShowDetail = true;
	}

	public void PushBack()
	{
		if (!IsEnableButton())
		{
			return;
		}
		if (isShowDetail)
		{
			if (isInAnim)
			{
				return;
			}
			LockButton(on: true);
			isShowDetail = false;
			if (isWeaponDetal)
			{
				UIAutoTweenerStandAloneEx.Out(weaponInfo.gameObject, delegate
				{
					LockButton(on: false);
				});
			}
			else
			{
				UIAutoTweenerStandAloneEx.Out(petInfo.gameObject, delegate
				{
					LockButton(on: false);
				});
			}
		}
		else
		{
			LockButton(on: false);
			BackMyhome();
		}
	}

	internal bool _0024SetList_0024closure_00245051(RespPlayerPresentBox x)
	{
		return !x.IsReceive;
	}

	internal int _0024SetList_0024closure_00245052(RespPlayerPresentBox a, RespPlayerPresentBox b)
	{
		return DateTime.Compare(b.SendDate, a.SendDate);
	}

	internal bool _0024ActiveOverItemDlg_0024closure_00245053(InventoryOverDialog.Mode dlgMode)
	{
		int result;
		if (dlgMode == InventoryOverDialog.Mode.Back)
		{
			overItemDlg.SetActive(value: false);
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal bool _0024GetDeleteTargetContainers_0024matchType_00245059(EnumMasterTypeValues itemType, EnumMasterTypeValues[] types)
	{
		int num = 0;
		int length = types.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (itemType == types[num])
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

	internal void _0024PushDetail_0024closure_00245060(GameObject go)
	{
		isInAnim = false;
		LockButton(on: false);
	}

	internal void _0024PushDetail_0024closure_00245061(GameObject go)
	{
		isInAnim = false;
		LockButton(on: false);
	}

	internal void _0024PushBack_0024closure_00245062(GameObject go)
	{
		LockButton(on: false);
	}

	internal void _0024PushBack_0024closure_00245063(GameObject go)
	{
		LockButton(on: false);
	}
}
