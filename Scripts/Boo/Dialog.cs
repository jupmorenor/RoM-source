using System;
using System.Collections;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class Dialog : MonoBehaviour
{
	public DialogManager dialogManager;

	public string message;

	public string title;

	public string[] button;

	public bool autoClose;

	public UISprite icon;

	private ICallable closeHandler;

	private __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ buttonHandler;

	public bool noCloseSceneChange;

	public int textDurationMSec;

	private float curMSec;

	private float lastRealTime;

	private int curTextIndex;

	public bool skip;

	private bool textFinish;

	private bool result;

	private UIDynamicFontLabel messageLabel;

	private UIDynamicFontLabel titleLabel;

	private UIDynamicFontLabel rightFooterLabel;

	private bool initFlag;

	protected bool closeSendManagerFlag;

	public bool doTyping;

	public bool TextFinish
	{
		get
		{
			return textFinish;
		}
		private set
		{
			textFinish = value;
		}
	}

	public bool Result
	{
		get
		{
			return result;
		}
		private set
		{
			result = value;
		}
	}

	public bool AutoClose
	{
		get
		{
			return autoClose;
		}
		set
		{
			autoClose = value;
		}
	}

	public ICallable CloseHandler
	{
		get
		{
			return closeHandler;
		}
		set
		{
			closeHandler = value;
		}
	}

	public __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ ButtonHandler
	{
		get
		{
			return buttonHandler;
		}
		set
		{
			buttonHandler = value;
		}
	}

	public bool NoCloseSceneChange
	{
		get
		{
			return noCloseSceneChange;
		}
		set
		{
			noCloseSceneChange = value;
		}
	}

	public void OnDestroy()
	{
		CloseSendManager();
	}

	public void Update()
	{
		checked
		{
			if (doTyping && initFlag && curTextIndex < message.Length)
			{
				if (!(curMSec < (float)textDurationMSec))
				{
					curTextIndex++;
					messageLabel.m_Text = message.Substring(0, curTextIndex);
					curMSec -= textDurationMSec;
				}
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				float num = realtimeSinceStartup - lastRealTime;
				lastRealTime = realtimeSinceStartup;
				curMSec += num * 1000f;
			}
		}
	}

	public void Init(DialogManager dialogManager, string title, string message, bool autoClose, int textDurationMSec, string[] button, UISprite icon)
	{
		this.dialogManager = dialogManager;
		this.title = title;
		this.message = message;
		this.autoClose = autoClose;
		this.textDurationMSec = textDurationMSec;
		this.icon = icon;
		this.button = button;
		initFlag = true;
		Transform transform = this.transform.Find("Icon");
		if (transform != null)
		{
			UISprite uISprite = (UISprite)transform.GetComponent(typeof(UISprite));
			transform.gameObject.SetActive(value: false);
			if ((bool)icon)
			{
				UISprite uISprite2 = (UISprite)UnityEngine.Object.Instantiate(icon);
				if (uISprite2 != null)
				{
					uISprite2.transform.parent = uISprite.transform.parent;
					uISprite2.transform.localPosition = transform.transform.localPosition;
					uISprite2.transform.localRotation = transform.transform.localRotation;
					uISprite2.transform.localScale = transform.transform.localScale;
					float z = uISprite2.transform.localPosition.z + -10f;
					Vector3 localPosition = uISprite2.transform.localPosition;
					float num = (localPosition.z = z);
					Vector3 vector2 = (uISprite2.transform.localPosition = localPosition);
					uISprite2.gameObject.SetActive(value: true);
				}
			}
		}
		int num2 = 0;
		int length = button.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			SetButton(checked(num3 + 1));
		}
		Transform transform2 = this.transform.Find("Close");
		if (transform2 != null)
		{
			UIButtonMessage uIButtonMessage = (UIButtonMessage)transform2.GetComponent(typeof(UIButtonMessage));
			if ((bool)uIButtonMessage)
			{
				uIButtonMessage.target = gameObject;
				uIButtonMessage.functionName = "OnClose";
			}
		}
		Transform transform3 = this.transform.Find("Message");
		if (transform3 != null)
		{
			messageLabel = (UIDynamicFontLabel)transform3.GetComponent(typeof(UIDynamicFontLabel));
		}
		Transform transform4 = this.transform.Find("Title");
		Transform transform5 = this.transform.Find("RightFooter");
		if (transform5 != null)
		{
			rightFooterLabel = (UIDynamicFontLabel)transform5.GetComponent(typeof(UIDynamicFontLabel));
		}
		if (transform4 != null)
		{
			titleLabel = (UIDynamicFontLabel)transform4.GetComponent(typeof(UIDynamicFontLabel));
		}
		if (messageLabel != null)
		{
			if (doTyping)
			{
				messageLabel.m_Text = string.Empty;
			}
			else
			{
				messageLabel.m_Text = message;
			}
			messageLabel.Align = UIDynamicFontLabel.Alignment.Center;
		}
		if (titleLabel != null)
		{
			titleLabel.m_Text = title;
		}
		curTextIndex = 0;
	}

	public void SetRightFooterText(string text)
	{
		if (rightFooterLabel != null && !string.IsNullOrEmpty(text))
		{
			rightFooterLabel.m_Text = text;
		}
	}

	private void SetButton(int i)
	{
		int num = checked(i - 1);
		Transform transform = this.transform.Find("Button" + i);
		if (!(transform != null))
		{
			return;
		}
		IEnumerator enumerator = transform.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform2 = (Transform)obj;
			UIDynamicFontLabel uIDynamicFontLabel = (UIDynamicFontLabel)transform2.GetComponent(typeof(UIDynamicFontLabel));
			if ((bool)uIDynamicFontLabel && button != null && num < button.Length)
			{
				string[] array = button;
				uIDynamicFontLabel.text = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			}
		}
		UIButtonMessage uIButtonMessage = (UIButtonMessage)transform.GetComponent(typeof(UIButtonMessage));
		if (uIButtonMessage != null)
		{
			uIButtonMessage.target = gameObject;
			uIButtonMessage.mode = UIButtonMessage.SendMode.Integer;
			uIButtonMessage.integer = i;
			uIButtonMessage.functionName = "OnButton";
		}
	}

	public void OnButton(int index)
	{
		bool flag = autoClose;
		if (!(dialogManager == null))
		{
			dialogManager.OnButton(index);
			if (buttonHandler != null)
			{
				buttonHandler(index);
			}
			if (flag)
			{
				Close();
			}
		}
	}

	public void CloseSendManager()
	{
		if (!closeSendManagerFlag)
		{
			dialogManager.OnClose(this);
			closeSendManagerFlag = true;
		}
	}

	public void CloseTweenFinished()
	{
		CloseSendManager();
		if (closeHandler != null)
		{
			closeHandler.Call(new object[0]);
		}
		closeHandler = null;
	}

	public void OnClose(GameObject button)
	{
		autoClose = true;
		OnButton(0);
		if (closeHandler != null)
		{
			closeHandler.Call(new object[0]);
		}
		closeHandler = null;
		buttonHandler = null;
	}

	public void Close()
	{
		buttonHandler = null;
		if (!(dialogManager == null))
		{
			TweenAlpha component = GetComponent<TweenAlpha>();
			if ((bool)component)
			{
				TweenAlpha.Begin(gameObject, component.duration * 0.3f, 0f);
			}
			TweenScale tweenScale = TweenScale.Begin(gameObject, GetComponent<TweenScale>().duration * 0.8f, new Vector3(0f, 0f, 1f));
			tweenScale.eventReceiver = gameObject;
			tweenScale.callWhenFinished = "CloseTweenFinished";
		}
	}

	public void CloseImmediate()
	{
		buttonHandler = null;
		if (!(dialogManager == null))
		{
			CloseTweenFinished();
		}
	}
}
