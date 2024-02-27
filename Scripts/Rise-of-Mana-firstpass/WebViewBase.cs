using System;
using UnityEngine;

public class WebViewBase : MonoBehaviour
{
	[Serializable]
	public class Padding
	{
		public float left;

		public float top;

		public float right;

		public float bottom;
	}

	public enum FULLSCREEN_MODE
	{
		NONE,
		HORZ,
		VERT,
		FULL_SIZE,
		FULL_FIT
	}

	protected static WebViewBase curWebView;

	protected static WebViewBase lastWebView;

	protected static bool curVisible;

	protected static string strHtmlSource = string.Empty;

	protected static bool pageFinished;

	protected static bool pageError;

	public string nextUrl = string.Empty;

	protected string lastUrl = string.Empty;

	public string requestUrl = string.Empty;

	private string lastRequestUrl = string.Empty;

	public string requestHtml = string.Empty;

	public string baseHtmlUrl = string.Empty;

	private string lastRequestHtml = string.Empty;

	public new bool active;

	private bool firstCloseCall;

	public Action CloseCallback;

	[HideInInspector]
	public Rect worldRect = new Rect(100f, 100f, 200f, 200f);

	private Rect lastRect;

	[HideInInspector]
	public bool autoRect = true;

	public FULLSCREEN_MODE fullScreenMode;

	[SerializeField]
	public Padding fullScreenPadding = new Padding();

	public bool enableLinkJump;

	public bool noPageScale = true;

	public bool enableScroll = true;

	public int offsetY;

	public Rect screenRect;

	private new GameObject collider;

	public bool testFlag;

	private static AndroidJavaClass webViewPlugin;

	private static bool start;

	public static WebViewBase Instance
	{
		get
		{
			if (curWebView == null)
			{
				curWebView = UnityEngine.Object.FindObjectOfType(typeof(WebViewBase)) as WebViewBase;
				if (curWebView == null)
				{
					GameObject gameObject = new GameObject("WebViewBase");
					curWebView = gameObject.AddComponent<WebViewBase>();
				}
			}
			return curWebView;
		}
	}

	public bool NoPageScale
	{
		set
		{
			noPageScale = value;
		}
	}

	public bool EnableScroll
	{
		set
		{
			enableScroll = value;
		}
	}

	private static void DebugLog(string s)
	{
		s += "\n";
		Debug.Log(s);
	}

	public void SetCollider(GameObject col)
	{
		collider = col;
	}

	public virtual bool WebViewAbortCheck()
	{
		return false;
	}

	private void Start()
	{
		screenRect = GetScreenRect();
		StartWebView();
		Visible(flag: false);
		curWebView = this;
		lastWebView = null;
		if (!string.IsNullOrEmpty(requestUrl))
		{
			Open(requestUrl);
		}
		else if (!string.IsNullOrEmpty(requestHtml))
		{
			OpenHtml(requestHtml, baseHtmlUrl);
		}
	}

	private void Update()
	{
		if (null == curWebView)
		{
			OnEnable();
		}
		active = this == curWebView;
		if (WebViewAbortCheck())
		{
			Visible(flag: false);
			return;
		}
		if ((!pageFinished || string.IsNullOrEmpty(strHtmlSource)) && IsPageFinish())
		{
			GetHtmlSource();
		}
		if (active)
		{
			if (!curVisible)
			{
				Visible(flag: true);
				screenRect = GetScreenRect();
			}
			nextUrl = GetNextUrl();
			if (lastUrl != nextUrl)
			{
				lastUrl = nextUrl;
				if (lastUrl != null)
				{
					if (lastUrl.StartsWith("command:"))
					{
						CommandLinkFunc(lastUrl);
					}
					else
					{
						string[] array = lastUrl.Split('/');
						if (array != null)
						{
							CommandLinkFunc(array[array.Length - 1]);
						}
					}
				}
			}
			bool enable = false;
			if (fullScreenMode == FULLSCREEN_MODE.FULL_FIT)
			{
				worldRect = new Rect(screenRect);
				worldRect.x += fullScreenPadding.left;
				worldRect.y += fullScreenPadding.top;
				worldRect.width -= fullScreenPadding.left + fullScreenPadding.right;
				worldRect.height -= fullScreenPadding.top + fullScreenPadding.bottom;
				if (lastRect != worldRect)
				{
					SetPosCore((int)worldRect.x, offsetY + (int)worldRect.y, (int)worldRect.width, (int)worldRect.height);
					lastRect = worldRect;
				}
				enable = true;
			}
			else if (!autoRect)
			{
				if (lastRect != worldRect)
				{
					SetPosCore((int)worldRect.x, offsetY + (int)worldRect.y, (int)worldRect.width, (int)worldRect.height);
					lastRect = worldRect;
				}
			}
			else
			{
				Transform root = base.transform.root;
				UIRoot uIRoot = null;
				float num = 1f;
				if (root != null)
				{
					uIRoot = root.gameObject.GetComponent<UIRoot>();
				}
				if ((bool)uIRoot)
				{
					num = uIRoot.pixelSizeAdjustment;
					if (fullScreenMode == FULLSCREEN_MODE.HORZ && screenRect.height > 0f)
					{
						num = (float)uIRoot.activeHeight / screenRect.height;
					}
					worldRect.width = base.transform.localScale.x / num;
					worldRect.height = base.transform.localScale.y / num;
					Vector3 position = base.transform.position;
					position = uIRoot.transform.worldToLocalMatrix * position;
					worldRect.x = position.x / num - worldRect.width / 2f + screenRect.width / 2f;
					worldRect.y = screenRect.height / 2f - (position.y / num + worldRect.height / 2f);
				}
				else
				{
					worldRect.width = base.transform.localScale.x;
					worldRect.height = base.transform.localScale.y;
					worldRect.x = base.transform.position.x + screenRect.width / 2f;
					worldRect.y = screenRect.height / 2f - base.transform.position.y;
				}
				if (fullScreenMode == FULLSCREEN_MODE.HORZ)
				{
					worldRect.x = fullScreenPadding.left;
					worldRect.width = screenRect.width - (fullScreenPadding.left + fullScreenPadding.right);
					float num2 = (screenRect.height - worldRect.height) / 2f;
					worldRect.y -= num2;
					worldRect.height += num2 * 2f;
					enable = true;
				}
				else if (fullScreenMode == FULLSCREEN_MODE.VERT)
				{
					float num3 = (screenRect.width - worldRect.width) / 2f;
					worldRect.x -= num3;
					worldRect.width += num3 * 2f;
					worldRect.y = fullScreenPadding.top;
					worldRect.height = screenRect.height - (fullScreenPadding.top + fullScreenPadding.bottom);
				}
				else if (fullScreenMode == FULLSCREEN_MODE.FULL_SIZE)
				{
					worldRect.x += fullScreenPadding.left;
					worldRect.y += fullScreenPadding.top;
					worldRect.width = screenRect.width - (fullScreenPadding.left + fullScreenPadding.right);
					worldRect.height = screenRect.height - (fullScreenPadding.top + fullScreenPadding.bottom);
					enable = true;
				}
				if (lastRect != worldRect)
				{
					SetPosCore((int)worldRect.x, offsetY + (int)worldRect.y, (int)worldRect.width, (int)worldRect.height);
					lastRect = worldRect;
				}
			}
			ShowCloseButton(enable);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if (this == curWebView || (curWebView == null && lastWebView == this))
		{
			EndWebView();
			curWebView = null;
			lastWebView = null;
		}
	}

	protected void OnEnable()
	{
		StartWebView();
		curWebView = this;
		Visible(flag: false);
		lastWebView = null;
		lastRect = new Rect(0f, 0f, 0f, 0f);
		nextUrl = string.Empty;
		if (!string.IsNullOrEmpty(requestUrl))
		{
			lastRequestUrl = string.Empty;
			Open(requestUrl);
		}
		else if (!string.IsNullOrEmpty(requestHtml))
		{
			lastRequestHtml = string.Empty;
			OpenHtml(requestHtml, baseHtmlUrl);
		}
	}

	protected void OnDisable()
	{
		if (curWebView == this)
		{
			SetPosCore(0, 0, 0, 0);
			Visible(flag: false);
			lastWebView = this;
			curWebView = null;
			lastUrl = string.Empty;
			StopWebView();
		}
	}

	private Rect GetScreenRect()
	{
		Transform root = base.transform.root;
		Camera camera = null;
		if (root != null)
		{
			Camera[] componentsInChildren = root.GetComponentsInChildren<Camera>(includeInactive: true);
			if (componentsInChildren.Length > 0)
			{
				camera = componentsInChildren[0];
			}
		}
		Rect result;
		if (camera != null)
		{
			result = new Rect(0f, 0f, camera.GetScreenWidth(), camera.GetScreenHeight());
			DebugLog(string.Concat("WebViewBase screenRect = ", screenRect.ToString(), ", camera = ", camera, ", Screen.width = ", Screen.width, ", Screen.height = ", Screen.height));
		}
		else
		{
			result = new Rect(0f, 0f, Screen.width, Screen.height);
			DebugLog("WebViewBase screenRect = " + screenRect.ToString());
		}
		return result;
	}

	public void Clear()
	{
		OpenHtmlFile(string.Empty, string.Empty);
		requestHtml = string.Empty;
		lastRequestHtml = string.Empty;
		requestUrl = string.Empty;
		lastRequestUrl = string.Empty;
	}

	public void Open(string url = null)
	{
		lastRect = new Rect(0f, 0f, 0f, 0f);
		StartWebView();
		requestHtml = string.Empty;
		lastRequestHtml = string.Empty;
		if (url != lastRequestUrl)
		{
			requestUrl = url;
			OpenUrl(url);
			lastRequestUrl = url;
			EnableLinkJump(enableLinkJump);
		}
		NoPageScale = noPageScale;
		EnableScroll = enableScroll;
	}

	public void OpenHtml(string html, string baseUrl)
	{
		lastRect = new Rect(0f, 0f, 0f, 0f);
		StartWebView();
		requestUrl = string.Empty;
		lastRequestUrl = string.Empty;
		if (html != lastRequestHtml)
		{
			requestHtml = html;
			baseHtmlUrl = baseUrl;
			OpenHtmlFile(html, baseUrl);
			lastRequestHtml = html;
			EnableLinkJump(enableLinkJump);
		}
		NoPageScale = noPageScale;
		EnableScroll = enableScroll;
	}

	public virtual void CommandLinkFunc(string command)
	{
		string text = "command:";
		if (command.StartsWith(text))
		{
			command = command.Substring(text.Length);
		}
		if (command == "close")
		{
			EndWebView();
			lastUrl = string.Empty;
		}
	}

	public void Close()
	{
		Clear();
		base.gameObject.SetActive(value: false);
		if (!firstCloseCall && CloseCallback != null)
		{
			CloseCallback();
		}
		firstCloseCall = false;
	}

	private static bool DROID_StartWebView()
	{
		if (webViewPlugin == null)
		{
			try
			{
				webViewPlugin = new AndroidJavaClass("jp.co.goshow.merlin.webview.WebViewPlugin");
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
				return webViewPlugin.CallStatic<bool>("StartWebView", new object[1] { @static });
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
		}
		return false;
	}

	private static bool DROID_EndWebView()
	{
		if (webViewPlugin != null)
		{
			webViewPlugin.CallStatic("EndWebView");
			webViewPlugin = null;
			return true;
		}
		return false;
	}

	private static void DROID_SetEnableLinkJump(bool enable)
	{
		if (webViewPlugin != null)
		{
			webViewPlugin.CallStatic("WebViewSetEnableLinkJump", enable);
		}
	}

	private static bool DROID_SetWebViewRect(int x, int y, int w, int h)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewSetRect", new object[4] { x, y, w, h });
		}
		return false;
	}

	private static bool DROID_SetWebViewAutoFit(bool bFit)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewSetAutoFit", new object[1] { bFit });
		}
		return false;
	}

	private static bool DROID_SetWebViewEnableScroll(bool bEnable)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewSetEnableScroll", new object[1] { bEnable });
		}
		return false;
	}

	private static bool DROID_WebViewShow(bool bShow, bool bFull)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewShow", new object[2] { bShow, bFull });
		}
		return false;
	}

	private static bool DROID_OpenUrl(string url)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewOpenUrl", new object[1] { url });
		}
		return false;
	}

	private static bool DROID_OpenHtmlFile(string htmlText, string baseUrl)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewOpenHtml", new object[2] { htmlText, baseUrl });
		}
		return false;
	}

	private static string DROID_GetNextUrl()
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<string>("WebViewGetNextUrl", new object[0]);
		}
		return string.Empty;
	}

	private static bool DROID_ClearNextUrl()
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewClearNextUrl", new object[0]);
		}
		return false;
	}

	private static string DROID_GetHtmlSource()
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<string>("WebViewGetHtmlSource", new object[0]);
		}
		return string.Empty;
	}

	private static bool DROID_ShowCloseButton(bool bShow)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewShowCloseButton", new object[1] { bShow });
		}
		return false;
	}

	private static bool DROID_WebViewLoaded()
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewIsLoaded", new object[0]);
		}
		return false;
	}

	private static bool DROID_WebViewError()
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewIsError", new object[0]);
		}
		return false;
	}

	private static bool DROID_WebViewColor(float r, float g, float b, float a)
	{
		if (webViewPlugin != null)
		{
			return webViewPlugin.CallStatic<bool>("WebViewSetColor", new object[4]
			{
				(int)(r * 255f),
				(int)(g * 255f),
				(int)(b * 255f),
				(int)(a * 255f)
			});
		}
		return false;
	}

	public static bool IsUsableWebView()
	{
		bool flag = false;
		return true;
	}

	public static WebViewBase StartWebView()
	{
		bool flag = true;
		if ((bool)curWebView)
		{
			if ((bool)curWebView.collider)
			{
				curWebView.collider.SetActive(value: true);
			}
			curWebView.lastRect = new Rect(0f, 0f, 0f, 0f);
		}
		flag = DROID_StartWebView();
		start = false;
		if (flag)
		{
			return curWebView;
		}
		return null;
	}

	public static void EndWebView()
	{
		DROID_EndWebView();
		if ((bool)curWebView && (bool)curWebView.collider)
		{
			curWebView.collider.SetActive(value: false);
		}
		start = false;
	}

	public static void StopWebView()
	{
	}

	public static void EnableLinkJump(bool enable)
	{
		DROID_SetEnableLinkJump(enable);
	}

	public static void ShowCloseButton(bool enable)
	{
		DROID_ShowCloseButton(enable);
	}

	public static void Visible(bool flag)
	{
		bool bFull = false;
		if (curWebView != null)
		{
			bFull = curWebView.fullScreenMode == FULLSCREEN_MODE.HORZ || curWebView.fullScreenMode == FULLSCREEN_MODE.FULL_SIZE;
		}
		DROID_WebViewShow(flag, bFull);
		curVisible = flag;
	}

	public static void ForceInvisible()
	{
		bool bShow = false;
		bool bFull = false;
		if (curWebView != null)
		{
			bFull = curWebView.fullScreenMode == FULLSCREEN_MODE.HORZ || curWebView.fullScreenMode == FULLSCREEN_MODE.FULL_SIZE;
		}
		DROID_WebViewShow(bShow, bFull);
	}

	public static void SetPos(int x, int y, int w, int h)
	{
		if ((bool)curWebView)
		{
			curWebView.worldRect = new Rect(x, y, w, h);
			curWebView.autoRect = false;
			curWebView.fullScreenMode = FULLSCREEN_MODE.NONE;
		}
	}

	private static void SetPosCore(int x, int y, int w, int h)
	{
		if (PerformanceSettingBase.screenRate != 0f)
		{
			x = (int)((float)x / PerformanceSettingBase.screenRate);
			y = (int)((float)y / PerformanceSettingBase.screenRate);
			w = (int)((float)w / PerformanceSettingBase.screenRate);
			h = (int)((float)h / PerformanceSettingBase.screenRate);
		}
		DROID_SetWebViewRect(x, y, w, h);
	}

	public static void OpenUrl(string url)
	{
		if (!start)
		{
			StartWebView();
		}
		strHtmlSource = string.Empty;
		pageFinished = false;
		pageError = false;
		DROID_OpenUrl(url);
		if ((bool)curWebView)
		{
			if ((bool)curWebView.collider)
			{
				curWebView.collider.SetActive(value: true);
			}
			curWebView.lastRect = new Rect(0f, 0f, 0f, 0f);
			curWebView.lastUrl = null;
		}
	}

	public static void OpenHtmlFile(string htmlText, string baseUrl)
	{
		if (!start)
		{
			StartWebView();
		}
		strHtmlSource = string.Empty;
		pageFinished = false;
		pageError = false;
		DROID_OpenHtmlFile(htmlText, baseUrl);
		if ((bool)curWebView)
		{
			if ((bool)curWebView.collider)
			{
				curWebView.collider.SetActive(value: true);
			}
			curWebView.lastRect = new Rect(0f, 0f, 0f, 0f);
			curWebView.lastUrl = null;
		}
	}

	public static string GetNextUrl()
	{
		string empty = string.Empty;
		return DROID_GetNextUrl();
	}

	public static bool ClearNextUrl()
	{
		bool flag = false;
		return DROID_ClearNextUrl();
	}

	public static string GetCommand()
	{
		string empty = string.Empty;
		empty = DROID_GetNextUrl();
		string text = "command:";
		if (empty.StartsWith(text))
		{
			return empty.Substring(text.Length);
		}
		return string.Empty;
	}

	public static string GetHtmlSource()
	{
		string empty = string.Empty;
		return strHtmlSource = DROID_GetHtmlSource();
	}

	public static bool IsPageFinish()
	{
		pageFinished = DROID_WebViewLoaded();
		pageError = DROID_WebViewError();
		return pageFinished || pageError;
	}

	private void OnApplicationQuit()
	{
		EndWebView();
		OnDestroy();
		UnityEngine.Object.DestroyObject(base.gameObject);
	}

	private void OnGUI()
	{
		if (testFlag)
		{
			GUILayout.BeginArea(new Rect(600f, 210f, 100f, 500f));
			if (GUILayout.Button("WebViewBase Test", GUILayout.MinHeight(80f)))
			{
				StartWebView();
				OpenUrl(requestUrl);
			}
			if (lastUrl != null)
			{
				GUILayout.Label("GetNextUrl=" + lastUrl);
			}
			GUILayout.EndArea();
		}
	}
}
