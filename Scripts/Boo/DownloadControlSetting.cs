using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DownloadControlSetting
{
	[Serializable]
	internal class _0024OpenControllSetting_0024locals_002414500
	{
		internal UserData _0024ud;

		internal PadSettingMenu _0024pad;

		internal __UserMiscInfo_postLoadEvent_0024callable73_00241616_35__ _0024func;
	}

	[Serializable]
	internal class _0024OpenControllSetting_0024closure_00243995
	{
		internal _0024OpenControllSetting_0024locals_002414500 _0024_0024locals_002415097;

		public _0024OpenControllSetting_0024closure_00243995(_0024OpenControllSetting_0024locals_002414500 _0024_0024locals_002415097)
		{
			this._0024_0024locals_002415097 = _0024_0024locals_002415097;
		}

		public void Invoke(UserMiscInfo umisc)
		{
			_0024_0024locals_002415097._0024ud.Config.VirtualPad = _0024_0024locals_002415097._0024pad.VirtualPad;
			_0024_0024locals_002415097._0024ud.Config.AutoCombinationOn = _0024_0024locals_002415097._0024pad.AutoCombinationOn;
			_0024_0024locals_002415097._0024ud.Config.VirtualPadImageOn = _0024_0024locals_002415097._0024pad.VirtualPadImageOn;
			_0024_0024locals_002415097._0024ud.Config.PadApply();
			_0024_0024locals_002415097._0024ud.setFlag("s01ControlSettingTuto");
			UserMiscInfo.postLoadEvent -= _0024_0024locals_002415097._0024func;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OpenControllSetting_002421561 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024cs_002421562;

			internal ModalCollider _0024modalColInst_002421563;

			internal GameObject _0024modalCol_002421564;

			internal UIMain _0024uimain_002421565;

			internal PauseTown _0024pause_002421566;

			internal Transform _0024winMain_002421567;

			internal UIAutoTweener _0024tweener_002421568;

			internal Transform _0024hudTrans_002421569;

			internal int _0024i_002421570;

			internal Transform _0024child_002421571;

			internal GameObject _0024go_002421572;

			internal UISituation _0024situ_002421573;

			internal Transform _0024okBtn_002421574;

			internal UIButtonMessage _0024btn_002421575;

			internal float _0024_0024wait_sec_0024temp_00242585_002421576;

			internal DialogManager _0024dlgMan_002421577;

			internal float _0024_0024wait_sec_0024temp_00242586_002421578;

			internal int _0024_002411285_002421579;

			internal int _0024_002411286_002421580;

			internal _0024OpenControllSetting_0024locals_002414500 _0024_0024locals_002421581;

			internal GameObject _0024dlMainGameObj_002421582;

			internal DownloadControlSetting _0024self__002421583;

			public _0024(GameObject dlMainGameObj, DownloadControlSetting self_)
			{
				_0024dlMainGameObj_002421582 = dlMainGameObj;
				_0024self__002421583 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421581 = new _0024OpenControllSetting_0024locals_002414500();
					_0024self__002421583.endControllSetting = false;
					_0024cs_002421562 = null;
					if ((bool)_0024self__002421583.controllSettings)
					{
						_0024cs_002421562 = _0024self__002421583.controllSettings;
					}
					_0024modalColInst_002421563 = ModalCollider.Instance;
					_0024modalColInst_002421563.AddLayer(LayerMask.NameToLayer("Pause"));
					_0024modalCol_002421564 = ModalCollider.GetCollider();
					_0024cs_002421562.transform.parent = _0024modalCol_002421564.transform.parent;
					_0024cs_002421562.transform.localPosition = new Vector3(0f, 0f, 100f);
					_0024cs_002421562.transform.localScale = Vector3.one;
					_0024cs_002421562.SetActive(value: false);
					_0024uimain_002421565 = _0024cs_002421562.GetComponent<UIMain>();
					_0024uimain_002421565.baseBg.SetActive(value: true);
					_0024uimain_002421565.baseBg = null;
					_0024uimain_002421565.enabled = false;
					_0024pause_002421566 = _0024cs_002421562.GetComponent<PauseTown>();
					_0024pause_002421566.enabled = false;
					_0024winMain_002421567 = null;
					_0024tweener_002421568 = null;
					_0024hudTrans_002421569 = _0024cs_002421562.transform.GetChild(0);
					_0024hudTrans_002421569.localPosition = Vector3.zero;
					_0024hudTrans_002421569.localScale = Vector3.one;
					_0024_002411285_002421579 = 0;
					_0024_002411286_002421580 = _0024hudTrans_002421569.childCount;
					if (_0024_002411286_002421580 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (_0024_002411285_002421579 < _0024_002411286_002421580)
					{
						_0024i_002421570 = _0024_002411285_002421579;
						_0024_002411285_002421579++;
						_0024child_002421571 = _0024hudTrans_002421569.GetChild(_0024i_002421570);
						if ((bool)_0024child_002421571)
						{
							if (_0024child_002421571.name == "float PadSettingMenu")
							{
								_0024winMain_002421567 = _0024child_002421571;
								_0024go_002421572 = _0024child_002421571.gameObject;
								_0024go_002421572.SetActive(value: true);
								_0024situ_002421573 = _0024go_002421572.GetComponent<UISituation>();
								_0024situ_002421573.enabled = false;
								_0024tweener_002421568 = _0024go_002421572.GetComponent<UIAutoTweener>();
								_0024tweener_002421568.isStandAlone = true;
							}
							else if (_0024child_002421571.name == "BG")
							{
								_0024child_002421571.gameObject.SetActive(value: true);
							}
							else
							{
								_0024child_002421571.gameObject.SetActive(value: false);
							}
						}
					}
					_0024okBtn_002421574 = _0024winMain_002421567.Find("PadSettingMenu/5 ButtonOK");
					_0024btn_002421575 = _0024okBtn_002421574.gameObject.GetComponent<UIButtonMessage>();
					_0024btn_002421575.functionName = _0024self__002421583.handlerMethodName;
					_0024btn_002421575.target = _0024dlMainGameObj_002421582;
					UIButtonMessage.AllDisable = false;
					_0024_0024locals_002421581._0024ud = UserData.Current;
					_0024_0024locals_002421581._0024pad = _0024winMain_002421567.gameObject.GetComponent<PadSettingMenu>();
					_0024_0024locals_002421581._0024pad.UpdateDisplays();
					_0024_0024locals_002421581._0024pad.VirtualPad = _0024_0024locals_002421581._0024ud.Config.VirtualPad;
					_0024_0024locals_002421581._0024pad.AutoCombinationOn = _0024_0024locals_002421581._0024ud.Config.AutoCombinationOn;
					_0024_0024locals_002421581._0024pad.VirtualPadImageOn = _0024_0024locals_002421581._0024ud.Config.VirtualPadImageOn;
					_0024tweener_002421568.Initialize();
					_0024_0024wait_sec_0024temp_00242585_002421576 = 1f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242585_002421576 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242585_002421576 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024dlgMan_002421577 = DialogManager.Instance;
					_0024dlgMan_002421577.OnButton(0);
					_0024dlgMan_002421577.OpenDialog("操作方法を選んでください。\nあとで変更することも可能です。", "操作方法選択", DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
					goto case 3;
				case 3:
					if (DialogManager.LastResult == 0)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00242586_002421578 = 1f;
					goto case 4;
				case 4:
					if (_0024_0024wait_sec_0024temp_00242586_002421578 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242586_002421578 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024cs_002421562.SetActive(value: true);
					_0024tweener_002421568.PlayAnimation(forward: true);
					goto case 5;
				case 5:
					if (!_0024self__002421583.endControllSetting)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024_0024locals_002421581._0024func = null;
					_0024_0024locals_002421581._0024func = new _0024OpenControllSetting_0024closure_00243995(_0024_0024locals_002421581).Invoke;
					UserMiscInfo.postLoadEvent += _0024_0024locals_002421581._0024func;
					_0024tweener_002421568.PlayAnimation(forward: false);
					goto case 6;
				case 6:
					if (_0024tweener_002421568.isPlayingAnimation)
					{
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					_0024modalColInst_002421563.RemoveLayer(LayerMask.NameToLayer("Pause"));
					UnityEngine.Object.Destroy(_0024cs_002421562);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject _0024dlMainGameObj_002421584;

		internal DownloadControlSetting _0024self__002421585;

		public _0024OpenControllSetting_002421561(GameObject dlMainGameObj, DownloadControlSetting self_)
		{
			_0024dlMainGameObj_002421584 = dlMainGameObj;
			_0024self__002421585 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024dlMainGameObj_002421584, _0024self__002421585);
		}
	}

	[NonSerialized]
	private const string FIRST_CONTROLL_SETTINGS_FLAG = "s01ControlSettingTuto";

	private GameObject controllSettings;

	private bool endControllSetting;

	private string handlerMethodName;

	public DownloadControlSetting(GameObject _controllSettings, string _handlerMethodName)
	{
		if (!(_controllSettings != null) || string.IsNullOrEmpty(_handlerMethodName))
		{
			throw new AssertionFailedException("(_controllSettings != null) and (not string.IsNullOrEmpty(_handlerMethodName))");
		}
		controllSettings = _controllSettings;
		handlerMethodName = _handlerMethodName;
	}

	public bool needControlSetting()
	{
		UserMiscInfo userMiscInfo = UserData.Current.userMiscInfo;
		if (!userMiscInfo.IsAbleToSave)
		{
			userMiscInfo = new UserMiscInfo();
			userMiscInfo.Load();
		}
		return (userMiscInfo.IsAbleToSave && !userMiscInfo.flagData.hasFlag("s01ControlSettingTuto")) ? true : false;
	}

	public IEnumerator OpenControllSetting(GameObject dlMainGameObj)
	{
		return new _0024OpenControllSetting_002421561(dlMainGameObj, this).GetEnumerator();
	}

	public void Close()
	{
		endControllSetting = true;
	}
}
