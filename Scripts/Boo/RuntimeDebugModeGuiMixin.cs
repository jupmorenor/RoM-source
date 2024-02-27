using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024boolButtons_0024locals_002414319
	{
		internal GUILayoutOption[] _0024targs;

		internal GUILayoutOption[] _0024hargs;

		internal bool _0024v;

		internal string _0024text;

		internal GUILayoutOption[] _0024args;
	}

	[Serializable]
	internal class _0024snamevalue_0024locals_002414320
	{
		internal GUILayoutOption[] _0024targs;

		internal string _0024title;

		internal object _0024value;

		internal GUILayoutOption[] _0024args;
	}

	[Serializable]
	internal class _0024listFilter_0024locals_002414321
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024listFilter_0024locals_002414322
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024boolButtons_0024closure_00242800
	{
		internal _0024boolButtons_0024locals_002414319 _0024_0024locals_002414743;

		public _0024boolButtons_0024closure_00242800(_0024boolButtons_0024locals_002414319 _0024_0024locals_002414743)
		{
			this._0024_0024locals_002414743 = _0024_0024locals_002414743;
		}

		public void Invoke()
		{
			string text = ((!_0024_0024locals_002414743._0024v) ? "-" : "[ON]");
			slabel(text, _0024_0024locals_002414743._0024targs);
			if (sbutton(_0024_0024locals_002414743._0024text, _0024_0024locals_002414743._0024hargs))
			{
				_0024_0024locals_002414743._0024v = !_0024_0024locals_002414743._0024v;
			}
			else if (sbutton("オン", _0024_0024locals_002414743._0024args))
			{
				_0024_0024locals_002414743._0024v = true;
			}
			else if (sbutton("解除", _0024_0024locals_002414743._0024args))
			{
				_0024_0024locals_002414743._0024v = false;
			}
		}
	}

	[Serializable]
	internal class _0024snamevalue_0024closure_00242801
	{
		internal _0024snamevalue_0024locals_002414320 _0024_0024locals_002414744;

		public _0024snamevalue_0024closure_00242801(_0024snamevalue_0024locals_002414320 _0024_0024locals_002414744)
		{
			this._0024_0024locals_002414744 = _0024_0024locals_002414744;
		}

		public void Invoke()
		{
			GUILayout.Label(_0024_0024locals_002414744._0024title + ": ", smallLabelStyle, _0024_0024locals_002414744._0024targs);
			GUILayout.Label(_0024_0024locals_002414744._0024value.ToString(), smallLabelStyle, _0024_0024locals_002414744._0024args);
		}
	}

	[Serializable]
	internal class _0024listFilter_0024closure_00242802
	{
		internal _0024listFilter_0024locals_002414321 _0024_0024locals_002414745;

		public _0024listFilter_0024closure_00242802(_0024listFilter_0024locals_002414321 _0024_0024locals_002414745)
		{
			this._0024_0024locals_002414745 = _0024_0024locals_002414745;
		}

		public bool Invoke(string x)
		{
			return _0024_0024locals_002414745._0024r.Match(x).Success;
		}
	}

	[Serializable]
	internal class _0024listFilter_0024closure_00242803
	{
		internal _0024listFilter_0024locals_002414322 _0024_0024locals_002414746;

		public _0024listFilter_0024closure_00242803(_0024listFilter_0024locals_002414322 _0024_0024locals_002414746)
		{
			this._0024_0024locals_002414746 = _0024_0024locals_002414746;
		}

		public bool Invoke(string x)
		{
			return _0024_0024locals_002414746._0024r.Match(x).Success;
		}
	}

	[NonSerialized]
	protected static GUIStyle labelStyle;

	[NonSerialized]
	protected static GUIStyle smallLabelStyle;

	[NonSerialized]
	protected static GUIStyle textAreaStyle;

	[NonSerialized]
	protected static GUIStyle buttonStyle;

	[NonSerialized]
	protected static GUIStyle smallButtonStyle;

	[NonSerialized]
	protected static GUIStyle boxStyle;

	[NonSerialized]
	protected static GUIStyle mainViewStyle;

	[NonSerialized]
	protected static GUIStyle vscrlBarStyle;

	[NonSerialized]
	protected static GUIStyle hscrlBarStyle;

	[NonSerialized]
	private static Dictionary<string, Vector2> scrollPos = new Dictionary<string, Vector2>();

	public string title;

	[NonSerialized]
	private static Texture2D viewBackground;

	[NonSerialized]
	private static bool _0024dmode_0024input_0024667;

	[NonSerialized]
	private static bool _0024dmode_0024input_0024668;

	[NonSerialized]
	private static bool _0024dmode_0024input_0024669;

	[NonSerialized]
	private static bool _0024dmode_0024input_0024670;

	[NonSerialized]
	private static bool _0024dmode_0024input_0024671;

	private bool _killed;

	private bool _endOfDebugMode;

	[NonSerialized]
	public static GameObject debugModeObject;

	[NonSerialized]
	internal static Regex _0024re_002424722 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424723 = new Regex(" ");

	public static bool InputEnterMode
	{
		get
		{
			return _0024dmode_0024input_0024667;
		}
		set
		{
			_0024dmode_0024input_0024667 = value;
		}
	}

	public static bool InputExitMode
	{
		get
		{
			return _0024dmode_0024input_0024668;
		}
		set
		{
			_0024dmode_0024input_0024668 = value;
		}
	}

	public static bool InputHide
	{
		get
		{
			return _0024dmode_0024input_0024669;
		}
		set
		{
			_0024dmode_0024input_0024669 = value;
		}
	}

	public static bool InputStep
	{
		get
		{
			return _0024dmode_0024input_0024670;
		}
		set
		{
			_0024dmode_0024input_0024670 = value;
		}
	}

	public static bool InputBack
	{
		get
		{
			return _0024dmode_0024input_0024671;
		}
		set
		{
			_0024dmode_0024input_0024671 = value;
		}
	}

	public override string Name => GetType().Name;

	public bool IsKilled => _killed;

	public bool IsEndOfDebugMode => _endOfDebugMode;

	public static GUIStyle MainViewStyle => mainViewStyle;

	public RuntimeDebugModeGuiMixin()
	{
		title = string.Empty;
	}

	public static void initOnGUI()
	{
		labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
		labelStyle.fontSize = getNormalizedSizeByScreen(24);
		labelStyle.alignment = TextAnchor.LowerLeft;
		smallLabelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
		smallLabelStyle.fontSize = getNormalizedSizeByScreen(18);
		smallLabelStyle.alignment = TextAnchor.LowerLeft;
		textAreaStyle = new GUIStyle(GUI.skin.GetStyle("TextArea"));
		buttonStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		buttonStyle.alignment = TextAnchor.LowerLeft;
		buttonStyle.fontSize = getNormalizedSizeByScreen(24);
		smallButtonStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		smallButtonStyle.alignment = TextAnchor.LowerLeft;
		smallButtonStyle.fontSize = getNormalizedSizeByScreen(18);
		boxStyle = new GUIStyle(GUI.skin.GetStyle("Box"));
		boxStyle.fontSize = getNormalizedSizeByScreen(20);
		boxStyle.fontStyle = FontStyle.Bold;
		if (viewBackground == null)
		{
			viewBackground = bgtex(new Color(0.1f, 0.2f, 0.1f, 0.7f));
		}
		mainViewStyle = new GUIStyle(GUI.skin.GetStyle("Box"));
		mainViewStyle.normal.background = viewBackground;
		vscrlBarStyle = new GUIStyle(GUI.skin.GetStyle("VerticalScrollbar"));
		hscrlBarStyle = new GUIStyle(GUI.skin.GetStyle("HorizontalScrollbar"));
		vscrlBarStyle.fixedWidth = getNormalizedSizeByScreen(50);
		hscrlBarStyle.fixedHeight = getNormalizedSizeByScreen(50);
	}

	public static int getNormalizedSizeByScreen(int s)
	{
		return (Screen.width >= 720) ? s : checked((Screen.width >= 640) ? ((int)Math.Round((double)s * 0.8)) : ((Screen.width >= 480) ? ((int)Math.Round((double)s * 0.6)) : ((Screen.width < 320) ? ((int)Math.Round((double)s * 0.2)) : ((int)Math.Round((double)s * 0.4)))));
	}

	public static void scrollView(string id, ICallable disp)
	{
		scrollView(id, 0, disp);
	}

	public static void scrollView(string id, int width, ICallable disp)
	{
		GUILayoutOption[] array = new GUILayoutOption[1] { optExpandHeight(b: true) };
		if (width > 0)
		{
			array = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), array, new GUILayoutOption[1] { optWidth(width) });
		}
		if (!scrollPos.ContainsKey(id))
		{
			scrollPos[id] = Vector2.zero;
		}
		scrollPos[id] = GUILayout.BeginScrollView(scrollPos[id], alwaysShowHorizontal: false, alwaysShowVertical: false, hscrlBarStyle, vscrlBarStyle, array);
		disp.Call(new object[0]);
		GUILayout.EndScrollView();
	}

	public static void horizontal(ICallable m)
	{
		GUILayout.BeginHorizontal();
		m.Call(new object[0]);
		GUILayout.EndHorizontal();
	}

	public static void vertical(GUIStyle style, ICallable m)
	{
		GUILayout.BeginVertical(style);
		m.Call(new object[0]);
		GUILayout.EndVertical();
	}

	public static void vertical(ICallable m)
	{
		GUILayout.BeginVertical();
		m.Call(new object[0]);
		GUILayout.EndVertical();
	}

	public static bool button(string text, int width, params GUILayoutOption[] args)
	{
		GUILayoutOption[] args2 = default(GUILayoutOption[]);
		if (width > 0)
		{
			args2 = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), args, new GUILayoutOption[1] { optWidth(width) });
		}
		return button(text, args2);
	}

	public static bool button(string text, params GUILayoutOption[] args)
	{
		return GUILayout.Button(text, buttonStyle, args);
	}

	public static bool sbutton(string text, params GUILayoutOption[] args)
	{
		return GUILayout.Button(text, smallButtonStyle, args);
	}

	public static void toggle(ref bool var, string text, params GUILayoutOption[] args)
	{
		var = GUILayout.Toggle(var, text, args);
	}

	public static bool boolButtons(bool v, string text, params GUILayoutOption[] args)
	{
		_0024boolButtons_0024locals_002414319 _0024boolButtons_0024locals_0024 = new _0024boolButtons_0024locals_002414319();
		_0024boolButtons_0024locals_0024._0024v = v;
		_0024boolButtons_0024locals_0024._0024text = text;
		_0024boolButtons_0024locals_0024._0024args = args;
		_0024boolButtons_0024locals_0024._0024targs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024boolButtons_0024locals_0024._0024args, new GUILayoutOption[1] { optWidth(getNormalizedSizeByScreen(40)) });
		_0024boolButtons_0024locals_0024._0024hargs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024boolButtons_0024locals_0024._0024args, new GUILayoutOption[1] { optWidth(getNormalizedSizeByScreen(256)) });
		horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024boolButtons_0024closure_00242800(_0024boolButtons_0024locals_0024).Invoke));
		return _0024boolButtons_0024locals_0024._0024v;
	}

	public static void label(string text, int width, params GUILayoutOption[] args)
	{
		GUILayoutOption[] args2 = default(GUILayoutOption[]);
		if (width > 0)
		{
			args2 = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), args, new GUILayoutOption[1] { optWidth(width) });
		}
		label(text, args2);
	}

	public static void label(string text, params GUILayoutOption[] args)
	{
		GUILayout.Label(text, labelStyle, args);
	}

	public static void slabel(string text, params GUILayoutOption[] args)
	{
		GUILayout.Label(text, smallLabelStyle, args);
	}

	public static void snamevalue(string title, object value, int titleWidth, params GUILayoutOption[] args)
	{
		_0024snamevalue_0024locals_002414320 _0024snamevalue_0024locals_0024 = new _0024snamevalue_0024locals_002414320();
		_0024snamevalue_0024locals_0024._0024title = title;
		_0024snamevalue_0024locals_0024._0024value = value;
		_0024snamevalue_0024locals_0024._0024args = args;
		if (_0024snamevalue_0024locals_0024._0024value == null)
		{
			_0024snamevalue_0024locals_0024._0024value = string.Empty;
		}
		_0024snamevalue_0024locals_0024._0024targs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024snamevalue_0024locals_0024._0024args, new GUILayoutOption[1] { optWidth(titleWidth) });
		horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024snamevalue_0024closure_00242801(_0024snamevalue_0024locals_0024).Invoke));
	}

	public static void textArea(string text, params GUILayoutOption[] args)
	{
		GUILayout.TextArea(text, textAreaStyle, args);
	}

	public static void box(string text, params GUILayoutOption[] args)
	{
		GUILayout.Box(text, boxStyle, args);
	}

	public static GUILayoutOption optWidth(int w)
	{
		return GUILayout.Width(w);
	}

	public static GUILayoutOption optHeight(int h)
	{
		return GUILayout.Height(h);
	}

	public static GUILayoutOption optExpandHeight(bool b)
	{
		return GUILayout.ExpandHeight(b);
	}

	public static void space(int h)
	{
		GUILayout.Space(h);
	}

	public static int grid(string[] texts, int xCount)
	{
		return grid(-1, texts, xCount);
	}

	public static int grid(int selected, string[] texts, int xCount, params GUILayoutOption[] args)
	{
		return GUILayout.SelectionGrid(selected, texts, xCount, buttonStyle, args);
	}

	public static int grid(List texts, int xCount)
	{
		return grid((string[])Builtins.array(typeof(string), texts), xCount);
	}

	public static int grid(int selected, List texts, int xCount, params GUILayoutOption[] args)
	{
		return grid(selected, (string[])Builtins.array(typeof(string), texts), xCount, args);
	}

	private static Texture2D bgtex(Color col)
	{
		int num = 1;
		int num2 = 1;
		Color[] array = new Color[checked(num * num2)];
		int num3 = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < length)
		{
			int index = num3;
			num3++;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = col;
		}
		Texture2D texture2D = new Texture2D(num, num2);
		texture2D.SetPixels(array);
		texture2D.Apply();
		return texture2D;
	}

	public virtual bool AutoReturn()
	{
		return true;
	}

	public virtual void Init()
	{
	}

	public virtual void Exit()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void HideModeUpdate()
	{
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void FixedUpdate()
	{
	}

	public virtual void OnGUI()
	{
	}

	public virtual void HideModeOnGUI()
	{
	}

	public void KillMe()
	{
		_killed = true;
	}

	public void ExitDebugMode()
	{
		_endOfDebugMode = true;
	}

	public static List listFilter(List l, string exp)
	{
		_0024listFilter_0024locals_002414321 _0024listFilter_0024locals_0024 = new _0024listFilter_0024locals_002414321();
		int i = 0;
		string[] array = _0024re_002424722.Split(exp);
		List list = default(List);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024listFilter_0024locals_0024._0024r = new Regex(array[i], RegexOptions.IgnoreCase);
			list = ArrayMap.FilterStrings(l, new _0024listFilter_0024closure_00242802(_0024listFilter_0024locals_0024).Invoke);
		}
		return (list != null) ? list : l;
	}

	public static string[] listFilter(string[] l, string exp)
	{
		_0024listFilter_0024locals_002414322 _0024listFilter_0024locals_0024 = new _0024listFilter_0024locals_002414322();
		int i = 0;
		string[] array = _0024re_002424723.Split(exp);
		string[] array2 = default(string[]);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024listFilter_0024locals_0024._0024r = new Regex(array[i], RegexOptions.IgnoreCase);
			array2 = ArrayMap.FilterStrings(l, new _0024listFilter_0024closure_00242803(_0024listFilter_0024locals_0024).Invoke);
		}
		return (array2 != null) ? array2 : l;
	}

	public static void listWithFilter(string[][] buttons, ICallable filterFunc)
	{
		GUILayout.BeginHorizontal();
		int i = 0;
		for (int length = buttons.Length; i < length; i = checked(i + 1))
		{
			if (GUILayout.Button(buttons[i][0] as string))
			{
				filterFunc.Call(new object[1] { buttons[i][1] as string });
			}
		}
		GUILayout.EndHorizontal();
	}
}
