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
public class CharMakeMain : UIMain
{
	[Serializable]
	private enum Mode
	{
		Wait,
		Decide,
		End
	}

	[Serializable]
	public enum CHARMAKE_GENDER
	{
		male,
		female
	}

	[Serializable]
	internal class _0024OpenOKDialog_0024locals_002414497
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024cb;
	}

	[Serializable]
	internal class _0024OpenOKDialog_0024closure_00245026
	{
		internal CharMakeMain _0024this_002415091;

		internal _0024OpenOKDialog_0024locals_002414497 _0024_0024locals_002415092;

		public _0024OpenOKDialog_0024closure_00245026(CharMakeMain _0024this_002415091, _0024OpenOKDialog_0024locals_002414497 _0024_0024locals_002415092)
		{
			this._0024this_002415091 = _0024this_002415091;
			this._0024_0024locals_002415092 = _0024_0024locals_002415092;
		}

		public void Invoke(int btn)
		{
			_0024this_002415091.LockTouch(on: false);
			if (_0024_0024locals_002415092._0024cb != null)
			{
				_0024_0024locals_002415092._0024cb();
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421544 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024startTime_002421545;

			internal CharMakeMain _0024self__002421546;

			public _0024(CharMakeMain self_)
			{
				_0024self__002421546 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002421546.charMakeEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421546.LockTouch(on: true);
					_0024startTime_002421545 = Time.timeSinceLevelLoad;
					goto case 3;
				case 3:
					if (_0024startTime_002421545 + _0024self__002421546.faderInTime >= Time.timeSinceLevelLoad)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					FaderCore.Instance.fadeIn();
					goto case 4;
				case 4:
					if (!FaderCore.Instance.isInCompleted)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					SceneChanger.ChangeTo(SceneID.Ui_PrologueStart, doFade: false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CharMakeMain _0024self__002421547;

		public _0024main_002421544(CharMakeMain self_)
		{
			_0024self__002421547 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421547);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SendName_0024closure_00245029_002421548 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiCreateCharacter _0024req_002421549;

			internal CharMakeMain _0024self__002421550;

			public _0024(CharMakeMain self_)
			{
				_0024self__002421550 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002421549 = new ApiCreateCharacter();
					_0024req_002421549.AngelName = _0024self__002421550.AngelName;
					_0024req_002421549.DemonName = _0024self__002421550.DemonName;
					_0024req_002421549.AngelGender = (int)_0024self__002421550.toApiGender(_0024self__002421550.genderAngel);
					_0024req_002421549.DemonGender = (int)_0024self__002421550.toApiGender(_0024self__002421550.genderDemon);
					_0024req_002421549.IgnoreErrorCodes = new string[1] { "UsCrt001" };
					_0024req_002421549.ErrorHandler = delegate(RequestBase r)
					{
						if (r.ResponseObj is GameApiResponseBase { StatusCode: var statusCode })
						{
							string text = statusCode.ToLower();
							string text2 = text;
							if (text2 == "uscrt001")
							{
								_0024self__002421550.OpenOKDialog("再度入力して下さい。", "不正なキャラ名です");
							}
							else
							{
								_0024self__002421550.OpenOKDialog($"再度入力して下さい。\n{statusCode}", "ERROR！");
							}
						}
						_0024self__002421550.mode = Mode.Wait;
					};
					MerlinServer.Request(_0024req_002421549);
					goto case 2;
				case 2:
					if (!_0024req_002421549.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024req_002421549.IsOk)
					{
						UserData.Current.userMiscInfo.AllowToSave();
						UserData.Current.userMiscInfo.Save();
						CharMake3D.SetAccept(b: true);
						_0024self__002421550.charMakeEnd = true;
						_0024self__002421550.charMakeTimer = 100;
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

		internal CharMakeMain _0024self__002421551;

		public _0024_0024SendName_0024closure_00245029_002421548(CharMakeMain self_)
		{
			_0024self__002421551 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421551);
		}
	}

	[NonSerialized]
	public const int NAME_STRING_MAX = 8;

	public UIInput angelNameInput;

	public UIInput demonNameInput;

	public string[] nameDefaultAngel;

	public string[] nameDefaultDemon;

	public UISprite angelGenIcon;

	public UISprite demonGenIcon;

	public string genMIconName;

	public string genFIconName;

	private Camera leftCamera;

	private Camera rightCamera;

	public Camera ui2DCamera;

	public GameObject leftCamera2DTarget;

	public GameObject rightCamera2DTarget;

	public bool alwaysCalcCamera;

	public float 決定後フェードインまでの時間;

	private Mode mode;

	private Mode lastMode;

	private DialogManager dlgMan;

	protected bool charMakeEnd;

	protected int charMakeTimer;

	protected CHARMAKE_GENDER genderAngel;

	protected CHARMAKE_GENDER genderDemon;

	public UIButtonMessage decisionButton;

	private bool onDecide;

	public string AngelName
	{
		get
		{
			return angelNameInput.text;
		}
		set
		{
			angelNameInput.text = value;
		}
	}

	public string DemonName
	{
		get
		{
			return demonNameInput.text;
		}
		set
		{
			demonNameInput.text = value;
		}
	}

	public float faderInTime => 決定後フェードインまでの時間;

	public CharMakeMain()
	{
		genMIconName = "man";
		genFIconName = "woman";
		決定後フェードインまでの時間 = 3f;
		mode = Mode.Wait;
		lastMode = Mode.Wait;
		genderAngel = CHARMAKE_GENDER.male;
		genderDemon = CHARMAKE_GENDER.male;
	}

	public EnumGenders toApiGender(CHARMAKE_GENDER n)
	{
		return n switch
		{
			CHARMAKE_GENDER.female => EnumGenders.female, 
			CHARMAKE_GENDER.male => EnumGenders.male, 
			_ => EnumGenders.female, 
		};
	}

	private void ButtonInit()
	{
		decisionButton.immadiateHandler = delegate
		{
			DecideLock(on: true);
		};
	}

	public override void LockTouch(bool on)
	{
		UIButtonMessage.AllDisable = on;
		base.LockTouch(on);
	}

	private void immadiateFunc()
	{
		LockTouch(on: true);
	}

	public override void SceneStart()
	{
		__Req_FailHandler_0024callable6_0024440_32__ handler = delegate
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			LockTouch(on: false);
			SceneChanger.ScenePreChangeEvent -= _0024SceneStart_0024endScene_00245025;
		};
		SceneChanger.ScenePreChangeEvent += handler;
		ButtonInit();
		string[] array = nameDefaultAngel;
		AngelName = array[RuntimeServices.NormalizeArrayIndex(array, (int)genderAngel)];
		string[] array2 = nameDefaultDemon;
		DemonName = array2[RuntimeServices.NormalizeArrayIndex(array2, (int)genderDemon)];
		CharMake3D.initialized = true;
		Application.LoadLevelAdditive("CharMake3D");
		dlgMan = DialogManager.Instance;
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private void DecideLock(bool on)
	{
		LockTouch(on);
		CharMake3D.StopRotation(on);
		onDecide = on;
	}

	public void OnDestroy()
	{
		ModalCollider.SetActive(this, active: false);
	}

	private void OpenOKDialog(string msg, string title)
	{
		OpenOKDialog(msg, title, null);
	}

	private void OpenOKDialog(string msg, string title, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ cb)
	{
		_0024OpenOKDialog_0024locals_002414497 _0024OpenOKDialog_0024locals_0024 = new _0024OpenOKDialog_0024locals_002414497();
		_0024OpenOKDialog_0024locals_0024._0024cb = cb;
		LockTouch(on: true);
		Dialog dialog = dlgMan.OpenDialog(msg, title, DialogManager.MB_FLAG.MB_ICONWARNING, new string[1] { "OK" });
		dialog.ButtonHandler = new _0024OpenOKDialog_0024closure_00245026(this, _0024OpenOKDialog_0024locals_0024).Invoke;
	}

	private bool IsNoName(string n)
	{
		bool num = string.IsNullOrEmpty(n);
		if (!num)
		{
			num = UIBasicUtility.IsSpaseOnly(n, 8);
		}
		return num;
	}

	private void CalcCamera()
	{
		if (!ui2DCamera)
		{
			return;
		}
		if (!leftCamera || alwaysCalcCamera)
		{
			if (!leftCamera)
			{
				GameObject gameObject = GameObject.Find("Left Camera");
				if ((bool)gameObject)
				{
					leftCamera = gameObject.GetComponent<Camera>();
				}
			}
			if ((bool)leftCamera2DTarget && (bool)leftCamera)
			{
				float num = ui2DCamera.WorldToScreenPoint(leftCamera2DTarget.transform.position).x / (float)Screen.width;
				float num2 = (0.5f - num) * 2f;
				Rect rect = leftCamera.rect;
				float num4 = (rect.width = num2);
				Rect rect3 = (leftCamera.rect = rect);
				float num5 = 0.5f - leftCamera.rect.width;
				Rect rect4 = leftCamera.rect;
				float num7 = (rect4.x = num5);
				Rect rect6 = (leftCamera.rect = rect4);
			}
		}
		if ((bool)rightCamera && !alwaysCalcCamera)
		{
			return;
		}
		if (!rightCamera)
		{
			GameObject gameObject2 = GameObject.Find("Right Camera");
			if ((bool)gameObject2)
			{
				rightCamera = gameObject2.GetComponent<Camera>();
			}
		}
		if ((bool)rightCamera2DTarget && (bool)rightCamera)
		{
			float num8 = ui2DCamera.WorldToScreenPoint(rightCamera2DTarget.transform.position).x / (float)Screen.width;
			float num9 = (num8 - 0.5f) * 2f;
			Rect rect7 = rightCamera.rect;
			float num11 = (rect7.width = num9);
			Rect rect9 = (rightCamera.rect = rect7);
		}
	}

	public override void SceneUpdate()
	{
		CalcCamera();
		if (mode == lastMode)
		{
			return;
		}
		lastMode = mode;
		if (mode != Mode.Decide)
		{
			return;
		}
		mode = Mode.Wait;
		bool flag = true;
		string text = string.Empty;
		string msg = string.Empty;
		bool flag2 = IsNoName(AngelName);
		bool flag3 = IsNoName(DemonName);
		bool flag4 = 8 < AngelName.Length;
		bool flag5 = 8 < DemonName.Length;
		if (flag2 || flag3)
		{
			text = "名前が入力されていません！";
			msg = string.Empty;
			if (flag2 && flag3)
			{
				msg = "<RED>天使<COLOR_INIT>と<RED>悪魔<COLOR_INIT>の名前を\n入力して下さい。";
			}
			else if (flag2)
			{
				msg = "<RED>天使<COLOR_INIT>の名前を\n入力して下さい。";
			}
			else if (flag3)
			{
				msg = "<RED>悪魔<COLOR_INIT>の名前を\n入力して下さい。";
			}
		}
		else if (flag4 || flag5)
		{
			text = string.Empty;
			msg = "名前の文字数が多過ぎます！";
			if (flag4 || flag5)
			{
				text = "名前の文字数が多過ぎます！";
			}
			else if (flag4)
			{
				text = "天使名の文字数が多過ぎます！";
			}
			else if (flag5)
			{
				text = "悪魔名の文字数が多過ぎます！";
			}
		}
		else
		{
			flag = false;
		}
		if (flag)
		{
			OpenOKDialog(msg, text, delegate
			{
				DecideLock(on: false);
			});
			return;
		}
		dlgMan.OnButton(0);
		string arg = UIDynamicFontLabel.EscapeFontTag(AngelName);
		string arg2 = UIDynamicFontLabel.EscapeFontTag(DemonName);
		msg = $"天使は<RED>{arg}<COLOR_INIT>\n悪魔は<RED>{arg2}<COLOR_INIT>\nでよろしいですか？";
		text = "主人公名確認";
		Dialog dialog = dlgMan.OpenDialog(msg, text, DialogManager.MB_FLAG.MB_ICONWARNING, new string[2] { "いいえ", "はい" });
		dialog.ButtonHandler = delegate(int btn)
		{
			if (btn == 2)
			{
				mode = Mode.End;
				SendName();
			}
			else
			{
				dlgMan.OnButton(0);
				DecideLock(on: false);
			}
		};
	}

	private void SendName()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024SendName_0024closure_00245029_002421548(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002421544(this).GetEnumerator();
	}

	public void ChangeGenderAngel()
	{
		if (!onDecide)
		{
			string[] array = nameDefaultAngel;
			array[RuntimeServices.NormalizeArrayIndex(array, (int)genderAngel)] = AngelName;
			if (genderAngel == CHARMAKE_GENDER.male)
			{
				genderAngel = CHARMAKE_GENDER.female;
				angelGenIcon.spriteName = genFIconName;
			}
			else
			{
				genderAngel = CHARMAKE_GENDER.male;
				angelGenIcon.spriteName = genMIconName;
			}
			CharMake3D.SetSelectL((int)genderAngel);
			string[] array2 = nameDefaultAngel;
			AngelName = array2[RuntimeServices.NormalizeArrayIndex(array2, (int)genderAngel)];
		}
	}

	public void ChangeGenderDemon()
	{
		if (!onDecide)
		{
			string[] array = nameDefaultDemon;
			array[RuntimeServices.NormalizeArrayIndex(array, (int)genderDemon)] = DemonName;
			if (genderDemon == CHARMAKE_GENDER.male)
			{
				genderDemon = CHARMAKE_GENDER.female;
				demonGenIcon.spriteName = genFIconName;
			}
			else
			{
				genderDemon = CHARMAKE_GENDER.male;
				demonGenIcon.spriteName = genMIconName;
			}
			CharMake3D.SetSelectR((int)genderDemon);
			string[] array2 = nameDefaultDemon;
			DemonName = array2[RuntimeServices.NormalizeArrayIndex(array2, (int)genderDemon)];
		}
	}

	public void CheckInputData()
	{
		mode = Mode.Decide;
	}

	internal void _0024ButtonInit_0024closure_00245024()
	{
		DecideLock(on: true);
	}

	internal void _0024SceneStart_0024endScene_00245025(string str)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		LockTouch(on: false);
		SceneChanger.ScenePreChangeEvent -= _0024SceneStart_0024endScene_00245025;
	}

	internal void _0024SceneUpdate_0024closure_00245027()
	{
		DecideLock(on: false);
	}

	internal void _0024SceneUpdate_0024closure_00245028(int btn)
	{
		if (btn == 2)
		{
			mode = Mode.End;
			SendName();
		}
		else
		{
			dlgMan.OnButton(0);
			DecideLock(on: false);
		}
	}

	internal IEnumerator _0024SendName_0024closure_00245029()
	{
		return new _0024_0024SendName_0024closure_00245029_002421548(this).GetEnumerator();
	}

	internal void _0024_0024SendName_0024closure_00245029_0024closure_00245030(RequestBase r)
	{
		if (r.ResponseObj is GameApiResponseBase { StatusCode: var statusCode })
		{
			string text = statusCode.ToLower();
			string text2 = text;
			if (text2 == "uscrt001")
			{
				OpenOKDialog("再度入力して下さい。", "不正なキャラ名です");
			}
			else
			{
				OpenOKDialog($"再度入力して下さい。\n{statusCode}", "ERROR！");
			}
		}
		mode = Mode.Wait;
	}
}
