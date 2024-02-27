using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using ObjUtil;
using UnityEngine;

[Serializable]
public class EventWindow : MonoBehaviour
{
	[Serializable]
	public class Window
	{
		[Serializable]
		internal class _0024Close_0024locals_002414470
		{
			internal HashSet<UITweener> _0024copyForIter;
		}

		[Serializable]
		internal class _0024Close_0024watcher_00242908
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024Invoke_002421339 : GenericGenerator<WaitForEndOfFrame>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<WaitForEndOfFrame>, IEnumerator
				{
					internal UITweener _0024tw_002421340;

					internal int _0024postCount_002421341;

					internal HashSet<UITweener>.Enumerator _0024_0024iterator_002414071_002421342;

					internal _0024Close_0024watcher_00242908 _0024self__002421343;

					public _0024(_0024Close_0024watcher_00242908 self_)
					{
						_0024self__002421343 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024iterator_002414071_002421342 = _0024self__002421343._0024_0024locals_002415040._0024copyForIter.GetEnumerator();
							try
							{
								while (_0024_0024iterator_002414071_002421342.MoveNext())
								{
									_0024tw_002421340 = _0024_0024iterator_002414071_002421342.Current;
									if (_0024tw_002421340 == null || _0024tw_002421340.gameObject == null || !_0024tw_002421340.enabled || !_0024tw_002421340.gameObject.activeInHierarchy)
									{
										if (_0024tw_002421340 == null)
										{
										}
										if (_0024self__002421343._0024this_002415039.openTweeners.Contains(_0024tw_002421340))
										{
											_0024self__002421343._0024this_002415039.openTweeners.Remove(_0024tw_002421340);
										}
									}
								}
							}
							finally
							{
								((IDisposable)_0024_0024iterator_002414071_002421342).Dispose();
							}
							_0024postCount_002421341 = _0024self__002421343._0024this_002415039.openTweeners.Count;
							if (_0024postCount_002421341 == 0)
							{
								_0024self__002421343._0024this_002415039.closeTweener = 0;
								_0024self__002421343._0024this_002415039.CloseCore();
								YieldDefault(1);
								goto case 1;
							}
							result = (Yield(2, new WaitForEndOfFrame()) ? 1 : 0);
							break;
						case 1:
							result = 0;
							break;
						}
						return (byte)result != 0;
					}
				}

				internal _0024Close_0024watcher_00242908 _0024self__002421344;

				public _0024Invoke_002421339(_0024Close_0024watcher_00242908 self_)
				{
					_0024self__002421344 = self_;
				}

				public override IEnumerator<WaitForEndOfFrame> GetEnumerator()
				{
					return new _0024(_0024self__002421344);
				}
			}

			internal Window _0024this_002415039;

			internal _0024Close_0024locals_002414470 _0024_0024locals_002415040;

			public _0024Close_0024watcher_00242908(Window _0024this_002415039, _0024Close_0024locals_002414470 _0024_0024locals_002415040)
			{
				this._0024this_002415039 = _0024this_002415039;
				this._0024_0024locals_002415040 = _0024_0024locals_002415040;
			}

			public IEnumerator Invoke()
			{
				return new _0024Invoke_002421339(this).GetEnumerator();
			}
		}

		protected GameObject window;

		protected Transform transform;

		public string[] message;

		public string[] title;

		public GameObject[][] chObjs;

		public bool autoChPosition;

		public Component onePageComponent;

		public int curPage;

		public string curMessage;

		public string curTitle;

		public GameObject curCh1Obj;

		public GameObject curCh2Obj;

		protected GameObject lastCh1OrgObj;

		protected GameObject lastCh2OrgObj;

		public int textDurationMSec;

		private float curMSec;

		private float lastRealTime;

		private int curTextIndex;

		private int curTextMax;

		private bool lastPage;

		public bool skip;

		public bool enableSkip;

		public float chInSpeedPerMSec;

		protected float lineWaitMSec;

		protected float curLineWaitMSec;

		protected float pageWaitMSec;

		protected float curPageWaitMSec;

		protected bool enablePrePushNext;

		protected bool prePushNext;

		public bool hideLastPageNextButton;

		private bool textFinishAutoClose;

		private bool textDisplayFinish;

		private bool curPageTextDisplayFinish;

		private bool textFinish;

		private bool textFinishClear;

		private bool result;

		private EventWindowTemplate template;

		private Transform ch1Obj;

		private Transform ch2Obj;

		private UIDynamicFontLabel messageLabel;

		private UIDynamicFontLabel titleLabel;

		private Transform nextButton;

		public bool useCustomSe;

		public SQEX_SoundPlayerData.SE cursorSeID;

		protected SQEX_SoundPlayer sndPlayer;

		public bool disableNextButton;

		private bool initFlag;

		[NonSerialized]
		private static GameObject wacherObject;

		private int wndPrefabIndex;

		private bool closeFlag;

		private HashSet<UITweener> openTweeners;

		private int closeTweener;

		private ICallable closeHandler;

		private ICallable closeHandlerCore;

		protected Hashtable tweensDuration;

		protected Animation shakeAnim;

		public float shake;

		protected int count;

		protected EventWindow root;

		public bool HideLastPageNextButton
		{
			get
			{
				return hideLastPageNextButton;
			}
			set
			{
				hideLastPageNextButton = value;
			}
		}

		public bool TextFinishAutoClose
		{
			get
			{
				return textFinishAutoClose;
			}
			set
			{
				textFinishAutoClose = value;
			}
		}

		public bool TextDisplayFinish
		{
			get
			{
				return textDisplayFinish;
			}
			private set
			{
				textDisplayFinish = value;
			}
		}

		public bool CurPageTextDisplayFinish
		{
			get
			{
				return curPageTextDisplayFinish;
			}
			private set
			{
				curPageTextDisplayFinish = value;
			}
		}

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

		public bool TextFinishClear
		{
			get
			{
				return textFinishClear;
			}
			private set
			{
				textFinishClear = value;
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

		public bool DisableNextButton
		{
			get
			{
				return disableNextButton;
			}
			set
			{
				disableNextButton = value;
				UIButtonMessage uIButtonMessage = default(UIButtonMessage);
				if ((bool)template)
				{
					uIButtonMessage = template.nextButton;
				}
				if ((bool)uIButtonMessage)
				{
					if (disableNextButton)
					{
						uIButtonMessage.eventHandler = null;
					}
					else
					{
						uIButtonMessage.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(delegate
						{
							OnNextButton();
						});
					}
				}
				disableNextButton = false;
			}
		}

		public GameObject gameObject => window;

		public Component OnePageComponent
		{
			get
			{
				return onePageComponent;
			}
			set
			{
				onePageComponent = value;
			}
		}

		public int TextDurationMSec
		{
			get
			{
				return textDurationMSec;
			}
			set
			{
				textDurationMSec = value;
			}
		}

		public bool Skip
		{
			get
			{
				return skip;
			}
			set
			{
				skip = value;
			}
		}

		public bool EnableSkip
		{
			get
			{
				return enableSkip;
			}
			set
			{
				enableSkip = value;
			}
		}

		public float LineWaitMSec
		{
			get
			{
				return lineWaitMSec;
			}
			set
			{
				lineWaitMSec = value;
			}
		}

		public float PageWaitMSec
		{
			get
			{
				return pageWaitMSec;
			}
			set
			{
				pageWaitMSec = value;
			}
		}

		public bool EnablePrePushNext
		{
			get
			{
				return enablePrePushNext;
			}
			set
			{
				enablePrePushNext = value;
			}
		}

		public bool CloseFlag
		{
			get
			{
				return closeFlag;
			}
			set
			{
				closeFlag = value;
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

		public float Shake
		{
			get
			{
				return shake;
			}
			set
			{
				shake = value;
			}
		}

		public Window(EventWindow evetnWindowRoot)
		{
			autoChPosition = true;
			enableSkip = true;
			enablePrePushNext = true;
			hideLastPageNextButton = true;
			cursorSeID = SQEX_SoundPlayerData.SE.cursor;
			openTweeners = new HashSet<UITweener>();
			tweensDuration = new Hashtable();
			root = evetnWindowRoot;
		}

		public void Init(string[][] chatList)
		{
			Boo.Lang.List<string> list = new Boo.Lang.List<string>();
			Boo.Lang.List<string> list2 = new Boo.Lang.List<string>();
			int i = 0;
			checked
			{
				for (int length = chatList.Length; i < length; i++)
				{
					if (chatList[i] == null)
					{
						continue;
					}
					string item = chatList[i][0];
					int j = 0;
					string[] array = (string[])RuntimeServices.GetRange1(chatList[i], 1);
					for (int length2 = array.Length; j < length2; j++)
					{
						if (!(array[j] == null))
						{
							list.Add(item);
							list2.Add(array[j]);
						}
					}
				}
				if (!(window != null))
				{
					throw new AssertionFailedException("WindowのGameObjectが存在しない");
				}
				Init((string[])Builtins.array(typeof(string), list), (string[])Builtins.array(typeof(string), list2), null, textDurationMSec, chInSpeedPerMSec, wndPrefabIndex);
			}
		}

		public void UpdateCore()
		{
			checked
			{
				count++;
				if (!initFlag)
				{
					return;
				}
				CheckPad();
				if (closeHandler != null)
				{
					closeHandlerCore = closeHandler;
					closeHandler = null;
				}
				bool flag = true;
				float num = 0f;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				if (!(lastRealTime <= 0f))
				{
					num = (realtimeSinceStartup - lastRealTime) * 1000f;
				}
				lastRealTime = realtimeSinceStartup;
				if (!flag)
				{
					return;
				}
				if ((bool)shakeAnim)
				{
					if (shake != 0f)
					{
						if (!(shake <= 0f))
						{
							shake -= num;
							if (!(shake >= 0f))
							{
								shake = 0f;
							}
						}
						if (!shakeAnim.isPlaying || !shakeAnim.enabled)
						{
							ShakeCore(shake != 0f);
						}
					}
					else if (shakeAnim.isPlaying)
					{
						ShakeCore(on: false);
					}
				}
				if ((bool)template && (bool)template.textRoot)
				{
					template.textRoot.gameObject.SetActive(value: true);
				}
				if (!string.IsNullOrEmpty(curMessage) && (bool)messageLabel)
				{
					if (curTextIndex < curTextMax)
					{
						if (!(curMSec < (float)textDurationMSec) && !(curLineWaitMSec > 0f))
						{
							curLineWaitMSec = 0f;
							int num2 = curTextIndex;
							curTextIndex++;
							if (num2 > 0)
							{
								int num3 = messageLabel.LineNum(num2);
								int num4 = messageLabel.LineNum(curTextIndex);
								if (num3 != num4)
								{
									curLineWaitMSec = lineWaitMSec;
								}
							}
							messageLabel.DispTextCount = curTextIndex;
							curMSec = 0f;
						}
						curMSec += num;
						curLineWaitMSec -= num;
						if (skip)
						{
							skip = false;
							if (enableSkip)
							{
								curTextIndex = curTextMax;
								messageLabel.DispTextCount = curTextIndex;
								curMSec = 0f;
								curPageWaitMSec = pageWaitMSec;
								return;
							}
						}
					}
					if (curTextIndex >= curTextMax && messageLabel.DrawDispTextCount == curTextMax)
					{
						curPageWaitMSec -= num;
						curLineWaitMSec = 0f;
						if (curPageWaitMSec > 0f)
						{
							return;
						}
						if (!CurPageTextDisplayFinish)
						{
							CurPageTextDisplayFinish = true;
							if (lastPage)
							{
								TextDisplayFinish = true;
							}
						}
						else if (enablePrePushNext && prePushNext)
						{
							PushWindow();
							prePushNext = false;
						}
					}
					else
					{
						curPageWaitMSec = pageWaitMSec;
					}
				}
				else if (curMessage == null)
				{
					CurPageTextDisplayFinish = true;
					if (lastPage)
					{
						TextDisplayFinish = true;
					}
				}
			}
		}

		public Window OpenEventWindowCore(Transform parentTf, GameObject windowPrefab, string[] message, string[] title, GameObject[][] chObjs, int wndPrefabIndex)
		{
			this.transform = parentTf;
			Transform transform = this.transform.Find("WindowCamera");
			object obj;
			if (transform == null)
			{
				obj = null;
			}
			else if (!windowPrefab)
			{
				obj = null;
			}
			else
			{
				window = ((GameObject)UnityEngine.Object.Instantiate(windowPrefab)) as GameObject;
				if (window == null)
				{
					obj = null;
				}
				else
				{
					window.transform.parent = transform;
					window.transform.localPosition = windowPrefab.transform.localPosition;
					float x = window.transform.localScale.x;
					if (!((double)x <= 0.1))
					{
						window.transform.localScale = window.transform.localScale * 0.004166667f;
					}
					NGUITools.SetLayer(window, transform.gameObject.layer);
					Init(title, message, chObjs, textDurationMSec, chInSpeedPerMSec, wndPrefabIndex);
					float x2 = 1f;
					Vector3 localScale = window.transform.localScale;
					float num = (localScale.x = x2);
					Vector3 vector2 = (window.transform.localScale = localScale);
					float y = 1f;
					Vector3 localScale2 = window.transform.localScale;
					float num2 = (localScale2.y = y);
					Vector3 vector4 = (window.transform.localScale = localScale2);
					float z = 1f;
					Vector3 localScale3 = window.transform.localScale;
					float num3 = (localScale3.z = z);
					Vector3 vector6 = (window.transform.localScale = localScale3);
					obj = this;
				}
			}
			return (Window)obj;
		}

		public void InitMessage(string[] title, string[] message, GameObject[][] chObjs)
		{
			curMSec = 0f;
			curLineWaitMSec = 0f;
			lastRealTime = Time.realtimeSinceStartup;
			TextFinish = false;
			TextDisplayFinish = false;
			closeFlag = false;
			lastPage = false;
			this.title = title;
			this.message = message;
			InitChars(chObjs);
		}

		public void EndOpenTween(UITweener tw)
		{
			openTweeners.Add(tw);
		}

		public void Init(string[] title, string[] message, GameObject[][] chObjs, int textDurationMSec, float chDispPerMSec, int wndPrefabIndex)
		{
			UIButtonMessage.AllDisable = false;
			UITweener[] array = null;
			if ((bool)window)
			{
				window.GetComponentsInChildren<UITweener>(includeInactive: true);
			}
			if (array != null)
			{
				int i = 0;
				UITweener[] array2 = array;
				for (int length = array2.Length; i < length; i = checked(i + 1))
				{
					int instanceID = array2[i].GetInstanceID();
					if (!tweensDuration.ContainsKey(instanceID))
					{
						tweensDuration[array2[i].GetInstanceID()] = array2[i].duration;
						array2[i].onFinished = EndOpenTween;
					}
					else
					{
						array2[i].duration = RuntimeServices.UnboxSingle(tweensDuration[array2[i].GetInstanceID()]);
					}
				}
			}
			sndPlayer = SQEX_SoundPlayer.Instance;
			if ((bool)window)
			{
				window.gameObject.SetActive(value: true);
			}
			if (!(chDispPerMSec > 1f))
			{
				chDispPerMSec = 1f;
			}
			if (DebugTextDurationMSec > 0)
			{
				textDurationMSec = DebugTextDurationMSec;
			}
			this.wndPrefabIndex = wndPrefabIndex;
			this.textDurationMSec = textDurationMSec;
			chInSpeedPerMSec = chDispPerMSec;
			lineWaitMSec = textDurationMSec;
			pageWaitMSec = textDurationMSec;
			if ((bool)window)
			{
				template = window.GetComponent<EventWindowTemplate>();
			}
			InitMessage(title, message, chObjs);
			if ((bool)template)
			{
				shakeAnim = template.shakeAnim;
				if ((bool)shakeAnim)
				{
				}
				UIButtonMessage pushWindow = template.pushWindow;
				if ((bool)pushWindow)
				{
					pushWindow.scaling = false;
					pushWindow.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(delegate
					{
						PushWindow();
					});
				}
				pushWindow = template.nextButton;
				if ((bool)pushWindow)
				{
					nextButton = pushWindow.transform;
					if (disableNextButton)
					{
						pushWindow.eventHandler = null;
					}
					else
					{
						pushWindow.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(delegate
						{
							OnNextButton();
						});
					}
				}
				disableNextButton = false;
				pushWindow = template.closeButton;
				if ((bool)pushWindow)
				{
					pushWindow.eventHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024EventHandler_0024156.Adapt(delegate
					{
						OnClose();
					});
				}
				messageLabel = template.message;
				titleLabel = template.title;
				SetPage(0);
				if (((bool)curCh1Obj || (bool)curCh2Obj) && (bool)template.textRoot)
				{
					template.textRoot.SetActive(value: false);
				}
			}
			initFlag = true;
		}

		public void InitChars(GameObject[][] chObjs)
		{
			if (!template)
			{
				template = window.GetComponent<EventWindowTemplate>();
			}
			if (!RuntimeServices.EqualityOperator(this.chObjs, chObjs))
			{
				if ((bool)curCh1Obj)
				{
					UnityEngine.Object.DestroyObject(curCh1Obj);
					curCh1Obj = null;
				}
				if ((bool)curCh2Obj)
				{
					UnityEngine.Object.DestroyObject(curCh2Obj);
					curCh2Obj = null;
				}
			}
			this.chObjs = chObjs;
			if (!template)
			{
				return;
			}
			if ((bool)template.chr1Anchor)
			{
				ch1Obj = template.chr1Anchor.transform;
				ch1Obj.gameObject.SetActive(value: false);
				UISprite component = ch1Obj.gameObject.GetComponent<UISprite>();
				if ((bool)component)
				{
					component.enabled = false;
				}
			}
			if ((bool)template.chr2Anchor)
			{
				ch2Obj = template.chr2Anchor.transform;
				ch2Obj.gameObject.SetActive(value: false);
				UISprite component = ch2Obj.gameObject.GetComponent<UISprite>();
				if ((bool)component)
				{
					component.enabled = false;
				}
			}
		}

		public bool SetPage(int page)
		{
			bool flag = true;
			CurPageTextDisplayFinish = false;
			curPage = page;
			curTextIndex = 0;
			curTextMax = 0;
			curMessage = null;
			curTitle = null;
			curMSec = 0f;
			lastPage = false;
			skip = false;
			prePushNext = false;
			curLineWaitMSec = 0f;
			curPageWaitMSec = pageWaitMSec;
			if ((bool)onePageComponent)
			{
				UnityEngine.Object.DestroyObject(onePageComponent);
				onePageComponent = null;
			}
			checked
			{
				if (page < message.Length)
				{
					string[] array = message;
					curMessage = array[RuntimeServices.NormalizeArrayIndex(array, page)];
					if ((bool)messageLabel)
					{
						messageLabel.Text = curMessage;
						int num = 0;
						while (true)
						{
							messageLabel.UpdateLabel();
							if (!messageLabel.LastRebuildFlag)
							{
								break;
							}
							num++;
						}
						curTextMax = messageLabel.TextCount;
						if (num > 0)
						{
						}
						messageLabel.DispTextCount = 0;
					}
					if (page < message.Length - 1)
					{
						flag = false;
					}
				}
				if (page < title.Length)
				{
					string[] array2 = title;
					curTitle = array2[RuntimeServices.NormalizeArrayIndex(array2, page)];
					if ((bool)titleLabel)
					{
						titleLabel.m_Text = curTitle;
					}
					if (page < title.Length - 1)
					{
						flag = false;
					}
				}
				object obj = null;
				object obj2 = null;
				if (chObjs != null && page < chObjs.Length)
				{
					if (page < chObjs.Length - 1)
					{
						flag = false;
					}
					GameObject[][] array3 = chObjs;
					if (array3[RuntimeServices.NormalizeArrayIndex(array3, page)] != null)
					{
						GameObject[][] array4 = chObjs;
						obj = array4[RuntimeServices.NormalizeArrayIndex(array4, page)][0];
						GameObject[][] array5 = chObjs;
						obj2 = array5[RuntimeServices.NormalizeArrayIndex(array5, page)][1];
					}
				}
				object obj3 = obj;
				if (!(obj3 is GameObject))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(GameObject));
				}
				SetChar1((GameObject)obj3);
				object obj4 = obj2;
				if (!(obj4 is GameObject))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(GameObject));
				}
				SetChar2((GameObject)obj4);
				if ((bool)nextButton)
				{
					nextButton.gameObject.SetActive(value: true);
				}
				lastPage = flag;
				return !flag;
			}
		}

		public void SetChar1(GameObject ch)
		{
			if (lastCh1OrgObj != ch && (bool)curCh1Obj)
			{
				UnityEngine.Object.DestroyObject(curCh1Obj);
				curCh1Obj = null;
			}
			if (!ch)
			{
				return;
			}
			Transform parent = transform.Find("ChrCamera");
			if ((bool)ch)
			{
				if (lastCh1OrgObj != ch || !curCh1Obj)
				{
					curCh1Obj = (GameObject)UnityEngine.Object.Instantiate(ch);
				}
				if ((bool)curCh1Obj)
				{
					SetChObjPosition(ch1Obj, parent, curCh1Obj, lastCh1OrgObj != ch);
				}
			}
			lastCh1OrgObj = ch;
		}

		public void SetChar2(GameObject ch)
		{
			if (lastCh2OrgObj != ch && (bool)curCh2Obj)
			{
				UnityEngine.Object.DestroyObject(curCh2Obj);
				curCh2Obj = null;
			}
			if (!ch)
			{
				return;
			}
			Transform parent = transform.Find("ChrCamera");
			if ((bool)ch)
			{
				if (lastCh2OrgObj != ch || !curCh2Obj)
				{
					curCh2Obj = (GameObject)UnityEngine.Object.Instantiate(ch);
				}
				if ((bool)curCh2Obj)
				{
					SetChObjPosition(ch2Obj, parent, curCh2Obj, lastCh2OrgObj != ch);
				}
			}
			lastCh2OrgObj = ch;
		}

		public void SetChObjPosition(Transform pos, Transform parent, GameObject ch, bool init)
		{
			if (!pos || !ch)
			{
				return;
			}
			NGUITools.SetLayer(ch, parent.gameObject.layer);
			ch.transform.parent = parent;
			ch.transform.localPosition = pos.transform.localPosition;
			ch.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			if (ch is UISprite)
			{
				ch.transform.localScale = pos.transform.localScale;
			}
			else if (autoChPosition)
			{
				Transform transform = ObjUtilModule.Find1stDescendant(ch.transform, "y_ang");
				if ((bool)transform)
				{
					if (ch.transform != transform.parent && (bool)transform.parent)
					{
						transform.parent.localEulerAngles = new Vector3(0f, 0f, 0f);
					}
					transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					float x = pos.transform.localScale.x;
					Vector3 localScale = ch.transform.localScale;
					float num = (localScale.x = x);
					Vector3 vector2 = (ch.transform.localScale = localScale);
					float x2 = pos.transform.localScale.x;
					Vector3 localScale2 = ch.transform.localScale;
					float num2 = (localScale2.y = x2);
					Vector3 vector4 = (ch.transform.localScale = localScale2);
					float x3 = pos.transform.localScale.x;
					Vector3 localScale3 = ch.transform.localScale;
					float num3 = (localScale3.z = x3);
					Vector3 vector6 = (ch.transform.localScale = localScale3);
				}
				SkinnedMeshRenderer skinnedMeshRenderer = ((SkinnedMeshRenderer)ch.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer;
				if ((bool)skinnedMeshRenderer)
				{
					Vector3 center = skinnedMeshRenderer.bounds.center;
					float y = ch.transform.localPosition.y - center.y * pos.transform.localScale.x;
					Vector3 localPosition = ch.transform.localPosition;
					float num4 = (localPosition.y = y);
					Vector3 vector8 = (ch.transform.localPosition = localPosition);
				}
			}
			CharacterCloseupPosition component = ch.GetComponent<CharacterCloseupPosition>();
			if ((bool)component)
			{
				ch.transform.localPosition = ch.transform.localPosition + component.offset;
				float x4 = ch.transform.localScale.x * component.scale.x;
				Vector3 localScale4 = ch.transform.localScale;
				float num5 = (localScale4.x = x4);
				Vector3 vector10 = (ch.transform.localScale = localScale4);
				float y2 = ch.transform.localScale.y * component.scale.y;
				Vector3 localScale5 = ch.transform.localScale;
				float num6 = (localScale5.y = y2);
				Vector3 vector12 = (ch.transform.localScale = localScale5);
				float z = ch.transform.localScale.z * component.scale.z;
				Vector3 localScale6 = ch.transform.localScale;
				float num7 = (localScale6.z = z);
				Vector3 vector14 = (ch.transform.localScale = localScale6);
			}
			if (init)
			{
				UITweener[] components = pos.parent.GetComponents<UITweener>();
				if (components != null)
				{
					int i = 0;
					UITweener[] array = components;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						UITweener uITweener = ObjUtilModule.CopyComponent(ch, array[i]) as UITweener;
						if ((bool)uITweener)
						{
							TweenPosition tweenPosition = uITweener as TweenPosition;
							if ((bool)tweenPosition)
							{
								tweenPosition.to = ch.transform.localPosition;
							}
							uITweener.enabled = true;
							uITweener.Reset();
							uITweener.Play(forward: true);
						}
					}
				}
			}
			if (autoChPosition)
			{
				ch.gameObject.SetActive(value: true);
				PlayerControl componentInChildren = ch.gameObject.GetComponentInChildren<PlayerControl>();
				if ((bool)componentInChildren)
				{
					componentInChildren.enabled = false;
				}
				CharacterController component2 = ch.GetComponent<CharacterController>();
				if ((bool)component2)
				{
					component2.enabled = false;
				}
				NPCControl component3 = ch.GetComponent<NPCControl>();
				if ((bool)component3)
				{
					component3.enabled = false;
				}
			}
		}

		private void ShakeCore(bool on)
		{
			if ((bool)shakeAnim)
			{
				shakeAnim.Rewind();
				shakeAnim.enabled = on;
				if (on)
				{
					shakeAnim.Play();
				}
				else
				{
					shakeAnim.Stop();
				}
			}
		}

		public void OnNextButton()
		{
			if (skip || prePushNext || !(curPageWaitMSec <= 0f) || !CurPageTextDisplayFinish)
			{
				return;
			}
			if (!useCustomSe && (bool)sndPlayer)
			{
				sndPlayer.PlaySe((int)cursorSeID);
			}
			if (!hideLastPageNextButton && lastPage)
			{
				TextFinish = true;
				if (TextFinishAutoClose)
				{
					Close(callCloseHandler: true);
				}
				else if (TextFinishClear)
				{
					Close(callCloseHandler: true);
				}
				else
				{
					closeFlag = true;
				}
			}
			else
			{
				bool flag = SetPage(checked(curPage + 1));
				if (hideLastPageNextButton && !flag)
				{
					nextButton.gameObject.SetActive(value: false);
				}
			}
		}

		public void PushWindow()
		{
			if (enablePrePushNext && (skip || (!(curPageWaitMSec <= 0f) && curTextIndex >= curTextMax)) && !prePushNext)
			{
				prePushNext = true;
				if (!useCustomSe && (bool)sndPlayer)
				{
					sndPlayer.PlaySe((int)cursorSeID);
				}
			}
			else if (!CurPageTextDisplayFinish)
			{
				if (!skip)
				{
					skip = true;
					prePushNext = false;
					if (!useCustomSe && (bool)sndPlayer)
					{
						sndPlayer.PlaySe((int)cursorSeID);
					}
				}
			}
			else
			{
				if (!(curPageWaitMSec <= 0f))
				{
					return;
				}
				prePushNext = false;
				skip = false;
				if ((nextButton == null || hideLastPageNextButton) && lastPage)
				{
					TextFinish = true;
					if (TextFinishAutoClose)
					{
						Close(callCloseHandler: true);
					}
					else if (TextFinishClear)
					{
						Close(callCloseHandler: true);
					}
					else
					{
						closeFlag = true;
					}
				}
				else
				{
					OnNextButton();
				}
			}
		}

		public void Clear()
		{
			if ((bool)messageLabel)
			{
				messageLabel.m_Text = string.Empty;
			}
			if ((bool)titleLabel)
			{
				titleLabel.m_Text = string.Empty;
			}
		}

		public void CallCloseHander()
		{
			if (closeHandlerCore != null)
			{
				closeHandlerCore.Call(new object[0]);
				closeHandlerCore = null;
			}
		}

		public void Close(bool callCloseHandler)
		{
			_0024Close_0024locals_002414470 _0024Close_0024locals_0024 = new _0024Close_0024locals_002414470();
			if (null != gameObject && tweensDuration != null)
			{
				UITweener[] componentsInChildren = gameObject.GetComponentsInChildren<UITweener>(includeInactive: true);
				closeTweener = 0;
				closeFlag = true;
				if (componentsInChildren != null)
				{
					int i = 0;
					UITweener[] array = componentsInChildren;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						if (array[i].gameObject.activeInHierarchy)
						{
							int instanceID = array[i].GetInstanceID();
							if (!tweensDuration.ContainsKey(instanceID))
							{
								tweensDuration[array[i].GetInstanceID()] = array[i].duration;
							}
							else
							{
								array[i].duration = RuntimeServices.UnboxSingle(tweensDuration[array[i].GetInstanceID()]);
							}
							array[i].onFinished = EndCloseTween;
							array[i].delay = 0f;
							array[i].duration = array[i].duration * 0.5f;
							array[i].Play(forward: false);
						}
					}
					closeTweener = openTweeners.Count;
					if (wacherObject == null)
					{
						wacherObject = new GameObject();
					}
					NullComponent nullComponent = wacherObject.GetComponent<NullComponent>();
					if (nullComponent == null)
					{
						nullComponent = wacherObject.AddComponent<NullComponent>();
					}
					_0024Close_0024locals_0024._0024copyForIter = new HashSet<UITweener>(openTweeners);
					__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024Close_0024watcher_00242908(this, _0024Close_0024locals_0024).Invoke;
					nullComponent.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
				}
			}
			CloseCore();
			if (callCloseHandler)
			{
				CallCloseHander();
			}
		}

		public void EndCloseTween(UITweener tw)
		{
			if (openTweeners.Contains(tw) && openTweeners.Contains(tw))
			{
				openTweeners.Remove(tw);
			}
		}

		public void CloseCore()
		{
			if (closeTweener > 0)
			{
				return;
			}
			if ((bool)curCh1Obj)
			{
				UnityEngine.Object.DestroyObject(curCh1Obj);
				curCh1Obj = null;
			}
			if ((bool)curCh2Obj)
			{
				UnityEngine.Object.DestroyObject(curCh2Obj);
				curCh2Obj = null;
			}
			if (!window)
			{
				return;
			}
			if ((bool)root)
			{
				Window[] eventWindows = root.eventWindows;
				if (RuntimeServices.EqualityOperator(eventWindows[RuntimeServices.NormalizeArrayIndex(eventWindows, wndPrefabIndex)], this))
				{
					Window[] eventWindows2 = root.eventWindows;
					eventWindows2[RuntimeServices.NormalizeArrayIndex(eventWindows2, wndPrefabIndex)] = null;
				}
			}
			UnityEngine.Object.DestroyObject(window);
			window = null;
		}

		public void OnClose()
		{
			Close(callCloseHandler: true);
		}

		public void CheckPad()
		{
			if (PlayerControl.NeedControllerInput)
			{
				DeviceController instance = DeviceController.Instance;
				if (instance.isDown(12) || instance.isDown(13) || instance.isDown(14) || instance.isDown(15))
				{
					PushWindow();
				}
			}
		}

		internal void _0024set_DisableNextButton_0024closure_00242909()
		{
			OnNextButton();
		}

		internal void _0024Init_0024closure_00242910()
		{
			PushWindow();
		}

		internal void _0024Init_0024closure_00242911()
		{
			OnNextButton();
		}

		internal void _0024Init_0024closure_00242912()
		{
			OnClose();
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/EventWindowRoot";

	[NonSerialized]
	private static EventWindow __instance;

	[NonSerialized]
	protected static bool quitApp;

	public bool testFlag;

	private bool isDontDestroyOnLoad;

	public GameObject[] windowPrefab;

	[NonSerialized]
	public static int defaultWindowPrefabIndex = 2;

	private int lastWndPrefabIndex;

	private Window[] eventWindows;

	protected string lastSceneName;

	[NonSerialized]
	protected static int debugTextDurationMSec;

	public static EventWindow Instance
	{
		get
		{
			EventWindow _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((EventWindow)UnityEngine.Object.FindObjectOfType(typeof(EventWindow))) as EventWindow;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static EventWindow CurrentInstance => __instance;

	public static bool isWindow
	{
		get
		{
			int result;
			if (!CurrentInstance)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				Window[] array = CurrentInstance.eventWindows;
				int length = array.Length;
				while (true)
				{
					if (num < length)
					{
						if (array[num] != null)
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
			}
			return (byte)result != 0;
		}
	}

	public Window[] Windows => eventWindows;

	public static int DebugTextDurationMSec
	{
		get
		{
			return debugTextDurationMSec;
		}
		set
		{
			debugTextDurationMSec = value;
		}
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242491();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static EventWindow _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/EventWindowRoot");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "EventWindow" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		EventWindow eventWindow = ExtensionsModule.SetComponent<EventWindow>(gameObject2);
		if ((bool)eventWindow)
		{
			eventWindow._createInstance_callback();
		}
		return eventWindow;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00242492()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242492();
		quitApp = true;
	}

	public static Window GetWindow(int type)
	{
		object result;
		if (!CurrentInstance)
		{
			result = null;
		}
		else if (type < 0 || CurrentInstance.windowPrefab.Length <= type)
		{
			result = null;
		}
		else
		{
			Window[] array = CurrentInstance.eventWindows;
			result = array[RuntimeServices.NormalizeArrayIndex(array, type)];
		}
		return (Window)result;
	}

	public void OnGUI_()
	{
		if (!testFlag)
		{
			return;
		}
		checked
		{
			if (GUILayout.Button("shake 1sec") && eventWindows != null)
			{
				int i = 0;
				Window[] array = eventWindows;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null)
					{
						array[i].Shake = 1000f;
					}
				}
			}
			if (!GUILayout.Button("shake 5sec") || eventWindows == null)
			{
				return;
			}
			int j = 0;
			Window[] array2 = eventWindows;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] != null)
				{
					array2[j].Shake = 5000f;
				}
			}
		}
	}

	public static Window OpenEventWindow()
	{
		return OpenEventWindow(new string[0], new string[0], null, defaultWindowPrefabIndex);
	}

	public static Window OpenEventWindow(string mesage, string title)
	{
		return OpenEventWindow(new string[1] { mesage }, new string[1] { title }, null, defaultWindowPrefabIndex);
	}

	public static Window OpenEventWindow(string mesage, string title, int wndPrefabIndex)
	{
		return OpenEventWindow(new string[1] { mesage }, new string[1] { title }, null, wndPrefabIndex);
	}

	public static Window OpenEventWindow(int wndPrefabIndex)
	{
		return OpenEventWindow(new string[0], new string[0], null, wndPrefabIndex);
	}

	public static Window OpenEventWindow(string[] message, string[] title, GameObject[][] chObjs, int wndPrefabIndex)
	{
		EventWindow instance = Instance;
		return instance ? instance.OpenEventWindowCore(message, title, chObjs, wndPrefabIndex, noCloseSameTypeWindow: true) : null;
	}

	public static bool PushWindow()
	{
		EventWindow instance = Instance;
		int result;
		if (!instance)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			Window[] array = instance.eventWindows;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (array[num] != null)
					{
						array[num].PushWindow();
						result = 1;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	public static bool PushWindow(int type)
	{
		EventWindow instance = Instance;
		int result;
		if (!instance)
		{
			result = 0;
		}
		else
		{
			Window window = GetWindow(type);
			if (window != null)
			{
				window.PushWindow();
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public Window OpenEventWindowCore(string[] message, string[] title, GameObject[][] chObjs, int wndPrefabIndex, bool noCloseSameTypeWindow)
	{
		UIButtonMessage.AllDisable = false;
		lastWndPrefabIndex = wndPrefabIndex;
		if (eventWindows == null)
		{
			goto IL_0121;
		}
		object result;
		if (wndPrefabIndex < 0 || windowPrefab.Length <= wndPrefabIndex)
		{
			result = null;
		}
		else
		{
			Window window = null;
			if (noCloseSameTypeWindow)
			{
				Window[] array = eventWindows;
				window = array[RuntimeServices.NormalizeArrayIndex(array, wndPrefabIndex)];
			}
			else
			{
				Window[] array2 = eventWindows;
				if (array2[RuntimeServices.NormalizeArrayIndex(array2, wndPrefabIndex)] != null)
				{
					Window[] array3 = eventWindows;
					array3[RuntimeServices.NormalizeArrayIndex(array3, wndPrefabIndex)].Close(callCloseHandler: true);
					Window[] array4 = eventWindows;
					array4[RuntimeServices.NormalizeArrayIndex(array4, wndPrefabIndex)] = null;
				}
			}
			if (window == null)
			{
				window = new Window(this);
			}
			if (window == null)
			{
				goto IL_0121;
			}
			if (!window.gameObject)
			{
				Window window2 = window;
				Transform parentTf = transform;
				GameObject[] array5 = windowPrefab;
				window2.OpenEventWindowCore(parentTf, array5[RuntimeServices.NormalizeArrayIndex(array5, wndPrefabIndex)], message, title, chObjs, wndPrefabIndex);
			}
			else
			{
				window.InitMessage(title, message, chObjs);
				window.SetPage(0);
			}
			Window[] array6 = eventWindows;
			array6[RuntimeServices.NormalizeArrayIndex(array6, wndPrefabIndex)] = window;
			result = window;
		}
		goto IL_0122;
		IL_0122:
		return (Window)result;
		IL_0121:
		result = null;
		goto IL_0122;
	}

	public void _0024singleton_0024awake_00242491()
	{
		if (isDontDestroyOnLoad)
		{
			SceneDontDestroyObject.dontDestroyOnLoad(this);
		}
		eventWindows = new Window[windowPrefab.Length];
		lastSceneName = SceneChanger.CurrentSceneName;
	}

	public void OnDestroy()
	{
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}

	public void Update()
	{
		string currentSceneName = SceneChanger.CurrentSceneName;
		if (currentSceneName != lastSceneName)
		{
			CloseAll();
			lastSceneName = currentSceneName;
		}
		if (eventWindows == null)
		{
			return;
		}
		int i = 0;
		Window[] array = eventWindows;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].UpdateCore();
			}
		}
	}

	public void CloseAll()
	{
		if (eventWindows != null)
		{
			int num = 0;
			int length = eventWindows.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int typeIndex = num;
				num++;
				Close(typeIndex);
			}
		}
	}

	public void Close(int typeIndex)
	{
		Window[] windows = Windows;
		if (windows[RuntimeServices.NormalizeArrayIndex(windows, typeIndex)] != null)
		{
			Window[] windows2 = Windows;
			windows2[RuntimeServices.NormalizeArrayIndex(windows2, typeIndex)].Close(callCloseHandler: true);
			Window[] windows3 = Windows;
			windows3[RuntimeServices.NormalizeArrayIndex(windows3, typeIndex)] = null;
		}
	}

	public static void CloseEventWindowAll()
	{
		EventWindow eventWindow = (EventWindow)UnityEngine.Object.FindObjectOfType(typeof(EventWindow));
		if (!eventWindow)
		{
			eventWindow = Instance;
		}
		eventWindow.CloseAll();
	}

	public static void CloseEventWindow(int typeIndex)
	{
		EventWindow eventWindow = (EventWindow)UnityEngine.Object.FindObjectOfType(typeof(EventWindow));
		if (!eventWindow)
		{
			eventWindow = Instance;
		}
		eventWindow.Close(typeIndex);
	}
}
