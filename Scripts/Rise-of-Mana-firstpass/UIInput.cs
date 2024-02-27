using UnityEngine;

[AddComponentMenu("NGUI/UI/Input (Basic)")]
public class UIInput : MonoBehaviour
{
	public enum KeyboardType
	{
		Default,
		ASCIICapable,
		NumbersAndPunctuation,
		URL,
		NumberPad,
		PhonePad,
		NamePhonePad,
		EmailAddress
	}

	public delegate char Validator(string currentText, char nextChar);

	public delegate void OnSubmit(string inputString);

	public static UIInput current;

	public UILabelBase label;

	public int maxChars;

	public string caratChar = "|";

	public Validator validator;

	public KeyboardType type;

	public bool isPassword;

	public bool autoCorrect;

	public bool useLabelTextAtStart;

	public Color activeColor = Color.white;

	public GameObject eventReceiver;

	public string functionName = "OnSubmit";

	public OnSubmit onSubmit;

	private string _mText = string.Empty;

	private string _mDefaultText = string.Empty;

	private Color mDefaultColor = Color.white;

	private UIWidget.Pivot mPivot = UIWidget.Pivot.Left;

	private float mPosition;

	private TouchScreenKeyboard mKeyboard;

	private bool mDoInit = true;

	private string mText
	{
		get
		{
			return Emoji.ConvertSafeCode(_mText);
		}
		set
		{
			_mText = Emoji.ConvertSafeCode(value);
		}
	}

	private string mDefaultText
	{
		get
		{
			return Emoji.ConvertSafeCode(_mDefaultText);
		}
		set
		{
			_mDefaultText = Emoji.ConvertSafeCode(value);
		}
	}

	public virtual string text
	{
		get
		{
			if (mDoInit)
			{
				Init();
			}
			return mText;
		}
		set
		{
			if (mDoInit)
			{
				Init();
			}
			mText = value;
			if (label != null)
			{
				if (string.IsNullOrEmpty(value))
				{
					value = mDefaultText;
				}
				label.supportEncoding = false;
				labelText = ((!selected) ? value : (value + caratChar));
				label.showLastPasswordChar = selected;
				label.color = ((!selected && !(value != mDefaultText)) ? mDefaultColor : activeColor);
			}
		}
	}

	public bool selected
	{
		get
		{
			return UICamera.selectedObject == base.gameObject;
		}
		set
		{
			if (!value && UICamera.selectedObject == base.gameObject)
			{
				UICamera.selectedObject = null;
			}
			else if (value)
			{
				UICamera.selectedObject = base.gameObject;
			}
		}
	}

	public string defaultText
	{
		get
		{
			return mDefaultText;
		}
		set
		{
			if (labelText == mDefaultText)
			{
				labelText = value;
			}
			mDefaultText = value;
		}
	}

	private string labelText
	{
		get
		{
			return UIDynamicFontLabel.UnEscapeFontTag(Emoji.ConvertSafeCode(label.text));
		}
		set
		{
			label.text = Emoji.ConvertSafeCode(UIDynamicFontLabel.EscapeFontTag(value));
		}
	}

	protected void Init()
	{
		if (!mDoInit)
		{
			return;
		}
		mDoInit = false;
		if (label == null)
		{
			label = GetComponentInChildren<UILabelBase>();
		}
		if (label != null)
		{
			if (useLabelTextAtStart)
			{
				mText = labelText;
			}
			mDefaultText = labelText;
			mDefaultColor = label.color;
			label.supportEncoding = false;
			mPivot = label.pivot;
			mPosition = label.cachedTransform.localPosition.x;
		}
		else
		{
			base.enabled = false;
		}
	}

	private void OnEnable()
	{
		if (UICamera.IsHighlighted(base.gameObject))
		{
			OnSelect(isSelected: true);
		}
	}

	private void OnDisable()
	{
		if (UICamera.IsHighlighted(base.gameObject))
		{
			OnSelect(isSelected: false);
		}
	}

	private void OnSelect(bool isSelected)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		if (isSelected)
		{
			mText = ((!(labelText == mDefaultText)) ? labelText : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = true;
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
			{
				TouchScreenKeyboard.hideInput = false;
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.Default, autocorrection: false, multiline: false, secure: true);
				}
				else
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, (TouchScreenKeyboardType)type, autoCorrect);
				}
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.On;
				Transform cachedTransform = label.cachedTransform;
				Vector3 position = label.pivotOffset;
				position.y += label.relativeSize.y;
				position = cachedTransform.TransformPoint(position);
				Input.compositionCursorPos = UICamera.currentCamera.WorldToScreenPoint(position);
			}
			UpdateLabel();
			return;
		}
		if (mKeyboard != null)
		{
			mKeyboard.active = false;
		}
		if (string.IsNullOrEmpty(mText))
		{
			labelText = mDefaultText;
			label.color = mDefaultColor;
			if (isPassword)
			{
				label.password = false;
			}
		}
		else
		{
			labelText = mText;
		}
		label.showLastPasswordChar = false;
		Input.imeCompositionMode = IMECompositionMode.Off;
		RestoreLabel();
	}

	private void Start()
	{
		if (mDoInit)
		{
			Init();
		}
	}

	private void Update()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (validator != null)
				{
					c = validator(mText, c);
				}
				if (c != 0)
				{
					mText += c;
				}
			}
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			UpdateLabel();
		}
		if (mKeyboard.done)
		{
			mKeyboard = null;
			current = this;
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.DontRequireReceiver);
			current = null;
			selected = false;
		}
	}

	private void OnInput(string input)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!selected || !base.enabled || !NGUITools.GetActive(base.gameObject) || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return;
		}
		int i = 0;
		for (int length = input.Length; i < length; i++)
		{
			char c = input[i];
			if (c == '\b')
			{
				if (mText.Length > 0)
				{
					mText = mText.Substring(0, mText.Length - 1);
					SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (c == '\r' || c == '\n')
			{
				if ((UICamera.current.submitKey0 == KeyCode.Return || UICamera.current.submitKey1 == KeyCode.Return) && (!label.multiLine || (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))))
				{
					current = this;
					if (onSubmit != null)
					{
						onSubmit(mText);
					}
					if (eventReceiver == null)
					{
						eventReceiver = base.gameObject;
					}
					eventReceiver.SendMessage(functionName, mText, SendMessageOptions.DontRequireReceiver);
					current = null;
					selected = false;
					return;
				}
				if (validator != null)
				{
					c = validator(mText, c);
				}
				if (c == '\0')
				{
					continue;
				}
				if (c == '\n' || c == '\r')
				{
					if (label.multiLine)
					{
						mText += "\n";
					}
				}
				else
				{
					mText += c;
				}
				SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
			}
			else if (c >= ' ')
			{
				if (validator != null)
				{
					c = validator(mText, c);
				}
				if (c != 0)
				{
					mText += c;
					SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		UpdateLabel();
	}

	private void UpdateLabel()
	{
		if (mDoInit)
		{
			Init();
		}
		if (maxChars > 0 && mText.Length > maxChars)
		{
			mText = mText.Substring(0, maxChars);
		}
		if (!(label.font != null))
		{
			return;
		}
		string text;
		if (isPassword && selected)
		{
			text = string.Empty;
			int i = 0;
			for (int length = mText.Length; i < length; i++)
			{
				text += "*";
			}
			text = text + Input.compositionString + caratChar;
		}
		else
		{
			text = ((!selected) ? mText : (mText + Input.compositionString + caratChar));
		}
		label.supportEncoding = false;
		if (label.multiLine)
		{
			text = label.font.WrapText(text, (float)label.lineWidth / label.cachedTransform.localScale.x, 0, encoding: false, UIFont.SymbolStyle.None);
		}
		else
		{
			string endOfLineThatFits = label.font.GetEndOfLineThatFits(text, (float)label.lineWidth / label.cachedTransform.localScale.x, encoding: false, UIFont.SymbolStyle.None);
			if (endOfLineThatFits != text)
			{
				text = endOfLineThatFits;
				Vector3 localPosition = label.cachedTransform.localPosition;
				localPosition.x = mPosition + (float)label.lineWidth;
				if (mPivot == UIWidget.Pivot.Left)
				{
					label.pivot = UIWidget.Pivot.Right;
				}
				else if (mPivot == UIWidget.Pivot.TopLeft)
				{
					label.pivot = UIWidget.Pivot.TopRight;
				}
				else if (mPivot == UIWidget.Pivot.BottomLeft)
				{
					label.pivot = UIWidget.Pivot.BottomRight;
				}
				label.cachedTransform.localPosition = localPosition;
			}
			else
			{
				RestoreLabel();
			}
		}
		labelText = text;
		label.showLastPasswordChar = selected;
	}

	private void RestoreLabel()
	{
		if (label != null)
		{
			label.pivot = mPivot;
			Vector3 localPosition = label.cachedTransform.localPosition;
			localPosition.x = mPosition;
			label.cachedTransform.localPosition = localPosition;
		}
	}

	private void OnGUI()
	{
	}
}
