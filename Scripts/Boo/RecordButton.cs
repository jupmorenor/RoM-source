using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class RecordButton : MonoBehaviour
{
	[Serializable]
	internal class _0024_modalStartDialog_0024locals_002414480
	{
		internal GameObject _0024go;

		internal int _0024selectedBtn;
	}

	[Serializable]
	internal class _0024_modalStartDialog_0024closure_00245014
	{
		internal _0024_modalStartDialog_0024locals_002414480 _0024_0024locals_002415060;

		public _0024_modalStartDialog_0024closure_00245014(_0024_modalStartDialog_0024locals_002414480 _0024_0024locals_002415060)
		{
			this._0024_0024locals_002415060 = _0024_0024locals_002415060;
		}

		public void Invoke(int btn)
		{
			_0024_0024locals_002415060._0024selectedBtn = btn;
			UnityEngine.Object.DestroyObject(_0024_0024locals_002415060._0024go);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_modalStartDialog_002421444 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024run_002421445;

			internal _0024_modalStartDialog_0024locals_002414480 _0024_0024locals_002421446;

			internal RecordButton _0024self__002421447;

			public _0024(RecordButton self_)
			{
				_0024self__002421447 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421446 = new _0024_modalStartDialog_0024locals_002414480();
					_0024run_002421445 = false;
					_0024_0024locals_002421446._0024go = new GameObject();
					_0024_0024locals_002421446._0024go.layer = LayerMask.NameToLayer("Pause");
					_0024self__002421447.setModalCollider(_0024_0024locals_002421446._0024go);
					_0024self__002421447._dialog = _0024self__002421447._dialogManager.OpenDialog(MTexts.Msg("exp_rec_start_explain"), MTexts.Msg("exp_rec_start_title"), DialogManager.MB_FLAG.MB_NONE, new string[3]
					{
						MTexts.Msg("exp_video_view"),
						MTexts.Msg("exp_no"),
						MTexts.Msg("exp_yes")
					});
					_0024_0024locals_002421446._0024selectedBtn = -1;
					_0024self__002421447._dialog.ButtonHandler = new _0024_modalStartDialog_0024closure_00245014(_0024_0024locals_002421446).Invoke;
					goto case 2;
				case 2:
					if (0 > _0024_0024locals_002421446._0024selectedBtn)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421446._0024selectedBtn == 1)
					{
						_recorder.showWatchView();
					}
					else if (_0024_0024locals_002421446._0024selectedBtn == 3)
					{
						_0024self__002421447._startButtonCmp.Resume();
						_0024self__002421447._startRecording();
						_0024self__002421447._updateStartButtonGui();
						_0024self__002421447.setRecordButtonText(aRecord: true);
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

		internal RecordButton _0024self__002421448;

		public _0024_modalStartDialog_002421444(RecordButton self_)
		{
			_0024self__002421448 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421448);
		}
	}

	[NonSerialized]
	private static KamcordRecorder _recorder;

	private DialogManager _dialogManager;

	private Dialog _dialog;

	private GameObject _startButtonGo;

	private UISlicedSprite _startButtonSprite;

	private StartButton _startButtonCmp;

	private GameObject _recordButtonTextGo;

	private UIDynamicFontLabel _recordButtonTextFont;

	private bool init;

	private GameObject modalGameObject;

	public bool isRecord
	{
		get
		{
			bool result = false;
			if (_recorder != null)
			{
				result = _recorder.isRecord;
			}
			return result;
		}
	}

	public void Awake()
	{
		if (!Kamcord.IsEnabled())
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		else if (!PerformanceSettingBase.enableKamcord)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}

	public void Start()
	{
		_initialize();
	}

	public void Update()
	{
		BaseRecorder.RecorderMode recorderMode = _recorder.recorderMode;
		switch (_recorder.recorderMode)
		{
		case BaseRecorder.RecorderMode.Stop:
			if ((bool)modalGameObject && !_recorder.IsView)
			{
				UnityEngine.Object.DestroyObject(modalGameObject);
				modalGameObject = null;
			}
			break;
		}
	}

	public void OnClickedRecordButton()
	{
		_initialize();
		switch (_recorder.recorderMode)
		{
		case BaseRecorder.RecorderMode.Stop:
		{
			IEnumerator enumerator = _modalStartDialog();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			break;
		}
		case BaseRecorder.RecorderMode.Play:
			break;
		case BaseRecorder.RecorderMode.Record:
			StopRecord(modal: false);
			break;
		default:
			if (0 == 0)
			{
				throw new AssertionFailedException("false");
			}
			break;
		}
	}

	public void StopRecord(bool modal)
	{
		_initialize();
		BaseRecorder.RecorderMode recorderMode = _recorder.recorderMode;
		if (recorderMode == BaseRecorder.RecorderMode.Record && !modalGameObject)
		{
			if (modal)
			{
				modalGameObject = new GameObject();
				modalGameObject.layer = LayerMask.NameToLayer("Pause");
				setModalCollider(modalGameObject);
			}
			_stopRecording();
			_updateStartButtonGui();
			setRecordButtonText(aRecord: false);
			_showView();
		}
	}

	private void _initialize()
	{
		if (!init)
		{
			init = true;
			_recorder = KamcordRecorder.instance;
			if (_recorder == null && 0 == 0)
			{
				throw new AssertionFailedException("false");
			}
			_dialogManager = DialogManager.Instance;
			_initRecordButton();
			_initStartButton();
			bool recordButtonText = false;
			if (_recorder.recorderMode == BaseRecorder.RecorderMode.Record)
			{
				recordButtonText = true;
			}
			setRecordButtonText(recordButtonText);
		}
	}

	private void _startRecording()
	{
		_recorder.startRecording();
	}

	private void _stopRecording()
	{
		_recorder.stopRecording();
	}

	private void _showView()
	{
		_recorder.showView();
	}

	private BoxCollider setModalCollider(GameObject go)
	{
		BoxCollider boxCollider = ExtensionsModule.SetComponent<BoxCollider>(go);
		boxCollider.isTrigger = true;
		float x = 100f;
		Vector3 size = boxCollider.size;
		float num = (size.x = x);
		Vector3 vector2 = (boxCollider.size = size);
		float y = 100f;
		Vector3 size2 = boxCollider.size;
		float num2 = (size2.y = y);
		Vector3 vector4 = (boxCollider.size = size2);
		int num3 = 0;
		Vector3 center = boxCollider.center;
		float num4 = (center.x = num3);
		Vector3 vector6 = (boxCollider.center = center);
		int num5 = 0;
		Vector3 center2 = boxCollider.center;
		float num6 = (center2.y = num5);
		Vector3 vector8 = (boxCollider.center = center2);
		float z = -100f;
		Vector3 center3 = boxCollider.center;
		float num7 = (center3.z = z);
		Vector3 vector10 = (boxCollider.center = center3);
		return null;
	}

	private IEnumerator _modalStartDialog()
	{
		return new _0024_modalStartDialog_002421444(this).GetEnumerator();
	}

	private void _updateStartButtonGui()
	{
		if (_startButtonCmp != null)
		{
			_startButtonCmp.UpdateStartButtonGui();
		}
	}

	public void setRecordButtonText(bool aRecord)
	{
		string text = null;
		text = ((!aRecord) ? "動画撮影" : "録画停止");
		if ((bool)_recordButtonTextFont)
		{
			_recordButtonTextFont.text = text;
		}
	}

	private void _initRecordButton()
	{
		Transform transform = this.transform;
		int num = 0;
		int childCount = transform.childCount;
		if (childCount < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < childCount)
		{
			int index = num;
			num++;
			Transform child = transform.GetChild(index);
			GameObject gameObject = child.gameObject;
			string text = gameObject.name;
			if (text == "Text")
			{
				_recordButtonTextGo = gameObject;
				_recordButtonTextFont = gameObject.GetComponent<UIDynamicFontLabel>() as UIDynamicFontLabel;
				break;
			}
		}
	}

	private void _initStartButton()
	{
		Transform parent = this.gameObject.transform.parent;
		int num = 0;
		int childCount = parent.childCount;
		if (childCount < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < childCount)
		{
			int index = num;
			num++;
			Transform child = parent.GetChild(index);
			GameObject gameObject = child.gameObject;
			string text = gameObject.name;
			if (text == "StartButton")
			{
				_startButtonGo = gameObject;
				_startButtonCmp = gameObject.GetComponent<StartButton>() as StartButton;
				Transform child2 = _startButtonGo.transform.GetChild(0);
				GameObject gameObject2 = child2.gameObject;
				_startButtonSprite = gameObject2.GetComponent<UISlicedSprite>() as UISlicedSprite;
				break;
			}
		}
		if (!(_startButtonGo != null))
		{
		}
	}
}
