using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class ErrorDialog
{
	[Serializable]
	internal class _0024FatalError_0024locals_002414569
	{
		internal Dialog _0024tmpDlg;

		internal __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ _0024handler;
	}

	[Serializable]
	internal class _0024FatalError_0024closure_00243008
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002423066 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024FatalError_0024closure_00243008 _0024self__002423067;

				public _0024(_0024FatalError_0024closure_00243008 self_)
				{
					_0024self__002423067 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (_0024self__002423067._0024_0024locals_002415261._0024tmpDlg != null)
						{
							WebViewBase.ForceInvisible();
							result = (YieldDefault(2) ? 1 : 0);
							break;
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

			internal _0024FatalError_0024closure_00243008 _0024self__002423068;

			public _0024Invoke_002423066(_0024FatalError_0024closure_00243008 self_)
			{
				_0024self__002423068 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002423068);
			}
		}

		internal _0024FatalError_0024locals_002414569 _0024_0024locals_002415261;

		public _0024FatalError_0024closure_00243008(_0024FatalError_0024locals_002414569 _0024_0024locals_002415261)
		{
			this._0024_0024locals_002415261 = _0024_0024locals_002415261;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002423066(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024FatalError_0024closure_00243009
	{
		internal _0024FatalError_0024locals_002414569 _0024_0024locals_002415262;

		public _0024FatalError_0024closure_00243009(_0024FatalError_0024locals_002414569 _0024_0024locals_002415262)
		{
			this._0024_0024locals_002415262 = _0024_0024locals_002415262;
		}

		public void Invoke(int button)
		{
			_0024_0024locals_002415262._0024handler(button);
			_0024_0024locals_002415262._0024tmpDlg = null;
		}
	}

	[NonSerialized]
	private static Dialog _OpenedDialog;

	public static void FatalError(string title, string msg, bool jumpBoot)
	{
		FatalError(title, msg, jumpBoot, string.Empty, null);
	}

	public static void FatalError(string title, string msg, bool jumpBoot, __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ handler)
	{
		FatalError(title, msg, jumpBoot, string.Empty, handler);
	}

	public static void FatalError(string title, string msg, bool jumpBoot, string errorCode)
	{
		FatalError(title, msg, jumpBoot, errorCode, null);
	}

	public static void FatalError(string title, string msg, bool jumpBoot, string errorCode, __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ handler)
	{
		_0024FatalError_0024locals_002414569 _0024FatalError_0024locals_0024 = new _0024FatalError_0024locals_002414569();
		_0024FatalError_0024locals_0024._0024handler = handler;
		if (_OpenedDialog != null)
		{
			GameObject gameObject = _OpenedDialog.gameObject;
			if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			_OpenedDialog = null;
		}
		Dialog dialog = DialogManager.Instance.OpenDialog(title, msg, DialogManager.MB_FLAG.MB_ICONERROR, new string[1] { "OK" });
		if (dialog != null)
		{
			_OpenedDialog = dialog.GetComponent<Dialog>();
		}
		if (!(_OpenedDialog != null))
		{
			return;
		}
		_OpenedDialog.NoCloseSceneChange = true;
		_OpenedDialog.SetRightFooterText(errorCode);
		UIButtonMessage.AllDisable = false;
		_0024FatalError_0024locals_0024._0024tmpDlg = _OpenedDialog;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024FatalError_0024closure_00243008(_0024FatalError_0024locals_0024).Invoke;
		_OpenedDialog.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		_OpenedDialog.ButtonHandler = new _0024FatalError_0024closure_00243009(_0024FatalError_0024locals_0024).Invoke;
		_OpenedDialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			_OpenedDialog = null;
			GameObject gameObject4 = GameObject.Find("UIRoot Dialog");
			if (gameObject4 != null)
			{
				Dialog[] componentsInChildren2 = gameObject4.GetComponentsInChildren<Dialog>();
				if (componentsInChildren2.Length <= 1)
				{
					UnityEngine.Object.DestroyObject(gameObject4.gameObject);
				}
			}
		};
		GameObject gameObject2 = GameObject.Find("UIRoot Dialog");
		if (gameObject2 != null)
		{
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		}
		Transform parent = _OpenedDialog.transform.parent;
		if (parent != null)
		{
			Dialog[] componentsInChildren = parent.GetComponentsInChildren<Dialog>();
			int i = 0;
			Dialog[] array = componentsInChildren;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!(array[i] == _OpenedDialog) && !(_OpenedDialog.transform.localPosition.z < array[i].transform.localPosition.z))
				{
					float z = array[i].transform.localPosition.z - 100f;
					Vector3 localPosition = _OpenedDialog.transform.localPosition;
					float num = (localPosition.z = z);
					Vector3 vector2 = (_OpenedDialog.transform.localPosition = localPosition);
				}
			}
		}
		GameObject gameObject3 = GameObject.Find("UIRoot Dialog/Camera");
		if (gameObject3 != null)
		{
			Camera component = gameObject3.GetComponent<Camera>();
			UICamera component2 = gameObject3.GetComponent<UICamera>();
			if (component != null && component2 != null)
			{
				component.cullingMask = 1 << LayerMask.NameToLayer("Dialog");
				component2.eventReceiverMask = component.cullingMask;
				component.depth = 90f;
				NGUITools.SetLayer(gameObject3, LayerMask.NameToLayer("Dialog"));
			}
		}
	}

	internal static void _0024FatalError_0024closure_00243010()
	{
		_OpenedDialog = null;
		GameObject gameObject = GameObject.Find("UIRoot Dialog");
		if (gameObject != null)
		{
			Dialog[] componentsInChildren = gameObject.GetComponentsInChildren<Dialog>();
			if (componentsInChildren.Length <= 1)
			{
				UnityEngine.Object.DestroyObject(gameObject.gameObject);
			}
		}
	}
}
