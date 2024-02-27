using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubGameObjectInspector : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024225;

		public string _0024act_0024t_0024226;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024227;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024228;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024229;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024230;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024231;

		public __ActionBase__0024act_0024t_0024227_0024callable9_002448_5__ _0024act_0024t_0024232;

		public __ActionBase__0024act_0024t_0024233_0024callable10_002448_5__ _0024act_0024t_0024233;

		public IEnumerator _0024act_0024t_0024237;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024225.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassMainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassComponentListMode : ActionBase
	{
		public GameObject obj;

		public Component[] components;
	}

	[Serializable]
	public class ActionClassInspectorMode : ActionBase
	{
		public object c;

		public GameObject go;

		public string objectName;

		public Stack<InspectionData> viewStack;
	}

	[Serializable]
	private class InspectionData
	{
		public string name;

		public object target;

		public string typeName;

		public Hashtable fields;

		public bool fullInspect;

		private bool _0024initialized__DebugSubGameObjectInspector_InspectionData_0024;

		public InspectionData(string _name, object obj)
		{
			if (!_0024initialized__DebugSubGameObjectInspector_InspectionData_0024)
			{
				fullInspect = true;
				_0024initialized__DebugSubGameObjectInspector_InspectionData_0024 = true;
			}
			init(_name, obj);
		}

		public InspectionData(object obj)
		{
			if (!_0024initialized__DebugSubGameObjectInspector_InspectionData_0024)
			{
				fullInspect = true;
				_0024initialized__DebugSubGameObjectInspector_InspectionData_0024 = true;
			}
			init("<<unknown>>", obj);
		}

		public void init(string _name, object obj)
		{
			name = _name;
			target = obj;
			Type type = obj.GetType();
			typeName = type.Name;
			fields = getAllFieldAndProperties(obj);
		}

		public void update()
		{
			init(name, target);
		}

		private Hashtable getAllFieldAndProperties(object obj)
		{
			fields = new Hashtable();
			Type type = obj.GetType();
			BindingFlags bindingAttr = ((!fullInspect) ? (BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy));
			checked
			{
				if (obj is IDictionary)
				{
					IDictionary dictionary = obj as IDictionary;
					IEnumerator enumerator = dictionary.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						fields[current] = dictionary[current];
					}
				}
				else if (obj is string)
				{
					fields["<string>"] = obj;
				}
				else if (obj is ICollection)
				{
					int num = 0;
					IEnumerator enumerator2 = (obj as ICollection).GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object current2 = enumerator2.Current;
						fields[num++] = current2;
					}
				}
				else
				{
					int i = 0;
					FieldInfo[] array = type.GetFields(bindingAttr);
					for (int length = array.Length; i < length; i++)
					{
						try
						{
							fields[array[i].Name] = array[i].GetValue(obj);
						}
						catch (Exception)
						{
							fields[array[i].Name] = new Unknown();
						}
					}
					int j = 0;
					PropertyInfo[] properties = type.GetProperties(bindingAttr);
					for (int length2 = properties.Length; j < length2; j++)
					{
						try
						{
							fields[properties[j].Name] = properties[j].GetValue(obj, null);
						}
						catch (Exception)
						{
							fields[properties[j].Name] = new Unknown();
						}
					}
				}
				return fields;
			}
		}
	}

	[Serializable]
	public class TreeNode
	{
		public GameObject obj;

		public TreeNode[] children;

		public bool hasChildren;

		public TreeNode(GameObject o)
		{
			obj = o;
			if (o != null)
			{
				hasChildren = o.transform.childCount > 0;
			}
		}

		public void toggleShowChildren()
		{
			if (!(obj == null))
			{
				if (children == null)
				{
					children = _ToTreeNode(ExtensionsModule.Children(obj));
				}
				else
				{
					children = null;
				}
			}
		}
	}

	[Serializable]
	public class Unknown
	{
		public string value;

		public override string ToString()
		{
			return "<<UNKNOWN>>";
		}
	}

	[Serializable]
	public enum ActionEnum
	{
		InspectorMode,
		ComponentListMode,
		MainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024activationSwitch_0024locals_002414278
	{
		internal ICallable _0024on;

		internal ICallable _0024off;
	}

	[Serializable]
	internal class _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279
	{
		internal GameObject _0024o;

		internal TreeNode _0024node;

		internal int _0024level;
	}

	[Serializable]
	internal class _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280
	{
		internal ActionClassComponentListMode _0024_0024act_0024t_0024240;
	}

	[Serializable]
	internal class _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281
	{
		internal MonoBehaviour _0024m;

		internal GUILayoutOption _0024nameWidth;

		internal GUILayoutOption _0024valWidth;

		internal Hashtable _0024fields;

		internal ActionClassInspectorMode _0024_0024act_0024t_0024243;
	}

	[Serializable]
	internal class _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024closure_00243366
	{
		internal DebugSubGameObjectInspector _0024this_002414617;

		internal _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279 _0024_0024locals_002414618;

		public _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024closure_00243366(DebugSubGameObjectInspector _0024this_002414617, _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279 _0024_0024locals_002414618)
		{
			this._0024this_002414617 = _0024this_002414617;
			this._0024_0024locals_002414618 = _0024_0024locals_002414618;
		}

		public void Invoke()
		{
			if (_0024_0024locals_002414618._0024level > 0)
			{
				RuntimeDebugModeGuiMixin.space(checked(32 * _0024_0024locals_002414618._0024level));
			}
			RuntimeDebugModeGuiMixin.label((!_0024_0024locals_002414618._0024o.activeSelf) ? "x" : "o", 32);
			if (RuntimeDebugModeGuiMixin.button(_0024_0024locals_002414618._0024o.name))
			{
				_0024this_002414617.ComponentListMode(_0024_0024locals_002414618._0024o);
			}
			string text = ((!(_0024_0024locals_002414618._0024node.children == null)) ? "^" : "v");
			if (_0024_0024locals_002414618._0024node.hasChildren && RuntimeDebugModeGuiMixin.button(text, 32))
			{
				_0024_0024locals_002414618._0024node.toggleShowChildren();
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243369
	{
		internal _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024locals_002414619;

		public _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243369(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024locals_002414619)
		{
			this._0024_0024locals_002414619 = _0024_0024locals_002414619;
		}

		public void Invoke()
		{
			_0024_0024locals_002414619._0024_0024act_0024t_0024240.obj.SetActive(value: true);
		}
	}

	[Serializable]
	internal class _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243370
	{
		internal _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024locals_002414620;

		public _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243370(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024locals_002414620)
		{
			this._0024_0024locals_002414620 = _0024_0024locals_002414620;
		}

		public void Invoke()
		{
			_0024_0024locals_002414620._0024_0024act_0024t_0024240.obj.SetActive(value: false);
		}
	}

	[Serializable]
	internal class _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243371
	{
		internal Component[] _0024_00246863_002414621;

		internal DebugSubGameObjectInspector _0024this_002414622;

		internal int _0024_00246862_002414623;

		public _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243371(Component[] _0024_00246863_002414621, DebugSubGameObjectInspector _0024this_002414622, int _0024_00246862_002414623)
		{
			this._0024_00246863_002414621 = _0024_00246863_002414621;
			this._0024this_002414622 = _0024this_002414622;
			this._0024_00246862_002414623 = _0024_00246862_002414623;
		}

		public void Invoke()
		{
			Behaviour behaviour = _0024_00246863_002414621[_0024_00246862_002414623] as Behaviour;
			if (behaviour == null)
			{
				RuntimeDebugModeGuiMixin.label("-", 32);
			}
			else if (behaviour.enabled)
			{
				RuntimeDebugModeGuiMixin.label("o", 32);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("x", 32);
			}
			if (RuntimeDebugModeGuiMixin.button(_0024_00246863_002414621[_0024_00246862_002414623].GetType().ToString()))
			{
				_0024this_002414622.InspectorMode(_0024_00246863_002414621[_0024_00246862_002414623], _0024_00246863_002414621[_0024_00246862_002414623].gameObject);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243376
	{
		internal _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414624;

		public _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243376(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414624)
		{
			this._0024_0024locals_002414624 = _0024_0024locals_002414624;
		}

		public bool Invoke()
		{
			return _0024_0024locals_002414624._0024m.enabled = true;
		}
	}

	[Serializable]
	internal class _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243377
	{
		internal _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414625;

		public _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243377(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414625)
		{
			this._0024_0024locals_002414625 = _0024_0024locals_002414625;
		}

		public bool Invoke()
		{
			return _0024_0024locals_002414625._0024m.enabled = false;
		}
	}

	[Serializable]
	internal class _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243378
	{
		internal _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414626;

		public _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243378(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414626)
		{
			this._0024_0024locals_002414626 = _0024_0024locals_002414626;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.box("name", _0024_0024locals_002414626._0024nameWidth);
			RuntimeDebugModeGuiMixin.box("value", _0024_0024locals_002414626._0024valWidth);
		}
	}

	[Serializable]
	internal class _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243379
	{
		internal object _0024key_002414627;

		internal _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414628;

		public _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243379(object _0024key_002414627, _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024locals_002414628)
		{
			this._0024key_002414627 = _0024key_002414627;
			this._0024_0024locals_002414628 = _0024_0024locals_002414628;
		}

		public void Invoke()
		{
			string text = _0024key_002414627.ToString();
			object obj = _0024_0024locals_002414628._0024fields[_0024key_002414627];
			bool flag = true;
			if (obj == null)
			{
				RuntimeDebugModeGuiMixin.slabel(text, _0024_0024locals_002414628._0024nameWidth);
			}
			else if (obj.GetType().IsPrimitive || obj is Unknown)
			{
				RuntimeDebugModeGuiMixin.slabel(_0024key_002414627.ToString(), _0024_0024locals_002414628._0024nameWidth);
			}
			else if (text == "<string>")
			{
				object obj2 = obj;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				RuntimeDebugModeGuiMixin.textArea((string)obj2, RuntimeDebugModeGuiMixin.optWidth(800));
				flag = false;
			}
			else
			{
				string text2 = _0024key_002414627.ToString();
				if (RuntimeDebugModeGuiMixin.sbutton(text2, _0024_0024locals_002414628._0024nameWidth))
				{
					_0024_0024locals_002414628._0024_0024act_0024t_0024243.viewStack.Push(new InspectionData(_0024key_002414627.ToString(), obj));
				}
			}
			if (flag)
			{
				string text3 = new StringBuilder().Append(obj).ToString();
				if (text3.Length > 64)
				{
					text3 = text3.Substring(0, 64);
				}
				RuntimeDebugModeGuiMixin.slabel(text3, _0024_0024locals_002414628._0024valWidth);
			}
		}
	}

	[Serializable]
	internal class _0024activationSwitch_0024closure_00243381
	{
		internal _0024activationSwitch_0024locals_002414278 _0024_0024locals_002414629;

		public _0024activationSwitch_0024closure_00243381(_0024activationSwitch_0024locals_002414278 _0024_0024locals_002414629)
		{
			this._0024_0024locals_002414629 = _0024_0024locals_002414629;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.sbutton("ON") && _0024_0024locals_002414629._0024on != null)
			{
				_0024_0024locals_002414629._0024on.Call(new object[0]);
			}
			if (RuntimeDebugModeGuiMixin.sbutton("OFF") && _0024_0024locals_002414629._0024off != null)
			{
				_0024_0024locals_002414629._0024off.Call(new object[0]);
			}
		}
	}

	private TreeNode root;

	private Dictionary<string, ActionBase> _0024act_0024t_0024234;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024236;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024235;

	public bool actionDebugFlag;

	public bool IsMainMode => currActionID("$default$") == ActionEnum.MainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassMainMode MainModeData => currAction("$default$") as ActionClassMainMode;

	public bool IsComponentListMode => currActionID("$default$") == ActionEnum.ComponentListMode;

	public ActionClassComponentListMode ComponentListModeData => currAction("$default$") as ActionClassComponentListMode;

	public bool IsInspectorMode => currActionID("$default$") == ActionEnum.InspectorMode;

	public ActionClassInspectorMode InspectorModeData => currAction("$default$") as ActionClassInspectorMode;

	public DebugSubGameObjectInspector()
	{
		root = new TreeNode(null);
		_0024act_0024t_0024234 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024236 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override bool AutoReturn()
	{
		return false;
	}

	public override void Init()
	{
		Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
		int i = 0;
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].transform.parent == null)
			{
				list.Add(array[i]);
			}
		}
		list.Sort((GameObject a, GameObject b) => a.name.CompareTo(b.name));
		root = new TreeNode(null);
		root.children = _ToTreeNode(list.ToArray());
		MainMode();
	}

	private static TreeNode[] _ToTreeNode(GameObject[] gs)
	{
		System.Collections.Generic.List<TreeNode> list = new System.Collections.Generic.List<TreeNode>();
		int i = 0;
		for (int length = gs.Length; i < length; i = checked(i + 1))
		{
			list.Add(new TreeNode(gs[i]));
		}
		return list.ToArray();
	}

	public override void Update()
	{
		actUpdate();
	}

	public override void LateUpdate()
	{
		actLateUpdate();
	}

	public override void FixedUpdate()
	{
		actFixedUpdate();
	}

	public override void OnGUI()
	{
		actOnGUI();
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024234.ContainsKey(grp)) ? null : _0024act_0024t_0024234[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024236.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024236[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024234.ContainsKey(grp)) ? 0f : _0024act_0024t_0024234[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024234.ContainsKey(grp)) ? 0f : _0024act_0024t_0024234[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024234.ContainsKey(grp)) ? 0f : _0024act_0024t_0024234[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024236.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024226) && _0024act_0024t_0024234.ContainsKey(act._0024act_0024t_0024226) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024234[act._0024act_0024t_0024226]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.InspectorMode <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_0024226))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$226)");
			}
			_0024act_0024t_0024234[act._0024act_0024t_0024226] = act;
			_0024act_0024t_0024236[act._0024act_0024t_0024226] = act._0024act_0024t_0024225;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024235) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024226);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024226)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024226)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024228 != null)
		{
			actionBase._0024act_0024t_0024228(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024227 != null)
			{
				act._0024act_0024t_0024227(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024233 != null)
			{
				act._0024act_0024t_0024237 = act._0024act_0024t_0024233(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_0024234.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024235 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024229 != null)
			{
				actionBase._0024act_0024t_0024229(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024237 != null && !actionBase._0024act_0024t_0024237.MoveNext())
			{
				actionBase._0024act_0024t_0024237 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024234.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024235 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024230 != null)
			{
				actionBase._0024act_0024t_0024230(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024235 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024234.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024234[array2[i]];
				if (actionBase._0024act_0024t_0024231 != null)
				{
					actionBase._0024act_0024t_0024231(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024234.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024226 + " - " + value._0024act_0024t_0024225 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024235 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024234.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024234[array2[i]];
			if (actionBase._0024act_0024t_0024232 != null)
			{
				actionBase._0024act_0024t_0024232(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubGameObjectInspector" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.MainMode => createDataMainMode(), 
			ActionEnum.ComponentListMode => createDataComponentListMode(), 
			ActionEnum.InspectorMode => createDataInspectorMode(), 
			_ => null, 
		};
	}

	public ActionClassMainMode MainMode()
	{
		ActionClassMainMode actionClassMainMode = createMainMode();
		changeAction(actionClassMainMode);
		return actionClassMainMode;
	}

	public ActionClassMainMode createDataMainMode()
	{
		ActionClassMainMode actionClassMainMode = new ActionClassMainMode();
		actionClassMainMode._0024act_0024t_0024225 = ActionEnum.MainMode;
		actionClassMainMode._0024act_0024t_0024226 = "$default$";
		actionClassMainMode._0024act_0024t_0024231 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable197_002448_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___00248.Adapt(delegate
		{
			__DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__ _DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__ = checked(delegate(TreeNode node, int level)
			{
				_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279 _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024 = new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279();
				_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node = node;
				_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level = level;
				_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.obj;
				if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o != null)
				{
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024closure_00243366(this, _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024).Invoke));
				}
				if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children != null)
				{
					int i = 0;
					TreeNode[] children = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children;
					for (int length = children.Length; i < length; i++)
					{
						_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365(children[i], _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level + 1);
					}
				}
			});
			title = "Hierarchy";
			_DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__(root, 0);
		});
		actionClassMainMode._0024act_0024t_0024229 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable197_002448_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___00248.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				KillMe();
			}
		});
		return actionClassMainMode;
	}

	public ActionClassMainMode createMainMode()
	{
		return createDataMainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024234.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024234["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClassComponentListMode ComponentListMode(GameObject obj)
	{
		ActionClassComponentListMode actionClassComponentListMode = createComponentListMode(obj);
		changeAction(actionClassComponentListMode);
		return actionClassComponentListMode;
	}

	public ActionClassComponentListMode createDataComponentListMode()
	{
		ActionClassComponentListMode actionClassComponentListMode = new ActionClassComponentListMode();
		actionClassComponentListMode._0024act_0024t_0024225 = ActionEnum.ComponentListMode;
		actionClassComponentListMode._0024act_0024t_0024226 = "$default$";
		actionClassComponentListMode._0024act_0024t_0024231 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable198_002479_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___00249.Adapt(delegate(ActionClassComponentListMode _0024act_0024t_0024240)
		{
			_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024 = new _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280();
			_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240 = _0024act_0024t_0024240;
			if (_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj == null)
			{
				MainMode();
			}
			else
			{
				title = "Component List";
				RuntimeDebugModeGuiMixin.label(new StringBuilder("name:").Append(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.name).Append(" tag:").Append(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.tag)
					.Append(" layer:")
					.Append(LayerMask.LayerToName(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.layer))
					.ToString());
				activationSwitch(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.active, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243369(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024).Invoke), new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243370(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024).Invoke));
				int i = 0;
				Component[] components = _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.components;
				for (int length = components.Length; i < length; i = checked(i + 1))
				{
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243371(components, this, i).Invoke));
				}
			}
		});
		actionClassComponentListMode._0024act_0024t_0024229 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable198_002479_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___00249.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassComponentListMode;
	}

	public ActionClassComponentListMode createComponentListMode(GameObject obj)
	{
		ActionClassComponentListMode actionClassComponentListMode = createDataComponentListMode();
		actionClassComponentListMode.obj = obj;
		actionClassComponentListMode.components = obj.GetComponents(typeof(Component));
		return actionClassComponentListMode;
	}

	public ActionClassInspectorMode InspectorMode(object c, GameObject go)
	{
		ActionClassInspectorMode actionClassInspectorMode = createInspectorMode(c, go);
		changeAction(actionClassInspectorMode);
		return actionClassInspectorMode;
	}

	public ActionClassInspectorMode createDataInspectorMode()
	{
		ActionClassInspectorMode actionClassInspectorMode = new ActionClassInspectorMode();
		actionClassInspectorMode._0024act_0024t_0024225 = ActionEnum.InspectorMode;
		actionClassInspectorMode._0024act_0024t_0024226 = "$default$";
		actionClassInspectorMode._0024act_0024t_0024227 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable199_0024121_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___002410.Adapt(delegate(ActionClassInspectorMode _0024act_0024t_0024243)
		{
			_0024act_0024t_0024243.objectName = _0024act_0024t_0024243.go.name;
			_0024act_0024t_0024243.viewStack.Push(new InspectionData(_0024act_0024t_0024243.c.GetType().ToString(), _0024act_0024t_0024243.c));
		});
		actionClassInspectorMode._0024act_0024t_0024231 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable199_0024121_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___002410.Adapt(delegate(ActionClassInspectorMode _0024act_0024t_0024243)
		{
			_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024 = new _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281();
			_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243 = _0024act_0024t_0024243;
			if (_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c == null)
			{
				MainMode();
			}
			else
			{
				if (_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c is MonoBehaviour)
				{
					_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024m = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c as MonoBehaviour;
					activationSwitch(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024m.enabled, new __LotterySequence_startUpdateFunc_0024callable42_002410_31__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243376(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke), new __LotterySequence_startUpdateFunc_0024callable42_002410_31__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243377(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
				}
				InspectionData inspectionData = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.viewStack.Peek();
				string text = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c.GetType().ToString();
				title = "Inspector";
				string lhs = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.objectName + "\n";
				string rhs = string.Empty;
				foreach (InspectionData item in _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.viewStack)
				{
					rhs = item.name + " > " + rhs;
				}
				lhs += rhs;
				RuntimeDebugModeGuiMixin.box(lhs);
				if (inspectionData.fullInspect)
				{
					if (RuntimeDebugModeGuiMixin.button("full inspect"))
					{
						inspectionData.fullInspect = !inspectionData.fullInspect;
					}
				}
				else if (RuntimeDebugModeGuiMixin.button("self inspect"))
				{
					inspectionData.fullInspect = !inspectionData.fullInspect;
				}
				_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024nameWidth = RuntimeDebugModeGuiMixin.optWidth(200);
				_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024valWidth = RuntimeDebugModeGuiMixin.optWidth(400);
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243378(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
				inspectionData.update();
				_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024fields = inspectionData.fields;
				IEnumerator enumerator2 = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024fields.Keys.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object current2 = enumerator2.Current;
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243379(current2, _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
				}
			}
		});
		actionClassInspectorMode._0024act_0024t_0024229 = _0024adaptor_0024__DebugSubGameObjectInspector_0024callable199_0024121_5___0024__ActionBase__0024act_0024t_0024227_0024callable9_002448_5___002410.Adapt(delegate(ActionClassInspectorMode _0024act_0024t_0024243)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				if (_0024act_0024t_0024243.viewStack.Count <= 1)
				{
					ComponentListMode(_0024act_0024t_0024243.go);
				}
				else
				{
					_0024act_0024t_0024243.viewStack.Pop();
				}
			}
		});
		return actionClassInspectorMode;
	}

	public ActionClassInspectorMode createInspectorMode(object c, GameObject go)
	{
		ActionClassInspectorMode actionClassInspectorMode = createDataInspectorMode();
		actionClassInspectorMode.c = c;
		actionClassInspectorMode.go = go;
		actionClassInspectorMode.viewStack = new Stack<InspectionData>();
		return actionClassInspectorMode;
	}

	private void activationSwitch(bool val, ICallable on, ICallable off)
	{
		_0024activationSwitch_0024locals_002414278 _0024activationSwitch_0024locals_0024 = new _0024activationSwitch_0024locals_002414278();
		_0024activationSwitch_0024locals_0024._0024on = on;
		_0024activationSwitch_0024locals_0024._0024off = off;
		RuntimeDebugModeGuiMixin.label("Active:" + val);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024activationSwitch_0024closure_00243381(_0024activationSwitch_0024locals_0024).Invoke));
	}

	internal int _0024Init_0024closure_00243362(GameObject a, GameObject b)
	{
		return a.name.CompareTo(b.name);
	}

	internal void _0024createDataMainMode_0024closure_00243364(ActionClassMainMode _0024act_0024t_0024224)
	{
		__DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__ _DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__ = checked(delegate(TreeNode node, int level)
		{
			_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279 _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024 = new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279();
			_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node = node;
			_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level = level;
			_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.obj;
			if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o != null)
			{
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024closure_00243366(this, _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024).Invoke));
			}
			if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children != null)
			{
				int i = 0;
				TreeNode[] children = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children;
				for (int length = children.Length; i < length; i++)
				{
					_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365(children[i], _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level + 1);
				}
			}
		});
		title = "Hierarchy";
		_DebugSubGameObjectInspector__0024createDataMainMode_0024closure_00243364_0024callable158_002459_17__(root, 0);
	}

	internal void _0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365(TreeNode node, int level)
	{
		_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279 _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024 = new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_002414279();
		_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node = node;
		_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level = level;
		_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.obj;
		if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024o != null)
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024closure_00243366(this, _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024).Invoke));
		}
		checked
		{
			if (_0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children != null)
			{
				int i = 0;
				TreeNode[] children = _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024node.children;
				for (int length = children.Length; i < length; i++)
				{
					_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365(children[i], _0024_0024_0024createDataMainMode_0024closure_00243364_0024showTree_00243365_0024locals_0024._0024level + 1);
				}
			}
		}
	}

	internal void _0024createDataMainMode_0024closure_00243367(ActionClassMainMode _0024act_0024t_0024224)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDataComponentListMode_0024closure_00243368(ActionClassComponentListMode _0024act_0024t_0024240)
	{
		_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280 _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024 = new _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_002414280();
		_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240 = _0024act_0024t_0024240;
		if (_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj == null)
		{
			MainMode();
			return;
		}
		title = "Component List";
		RuntimeDebugModeGuiMixin.label(new StringBuilder("name:").Append(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.name).Append(" tag:").Append(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.tag)
			.Append(" layer:")
			.Append(LayerMask.LayerToName(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.layer))
			.ToString());
		activationSwitch(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.obj.active, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243369(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024).Invoke), new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243370(_0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024).Invoke));
		int i = 0;
		Component[] components = _0024_0024createDataComponentListMode_0024closure_00243368_0024locals_0024._0024_0024act_0024t_0024240.components;
		for (int length = components.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataComponentListMode_0024closure_00243368_0024closure_00243371(components, this, i).Invoke));
		}
	}

	internal void _0024createDataComponentListMode_0024closure_00243372(ActionClassComponentListMode _0024act_0024t_0024240)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataInspectorMode_0024closure_00243373(ActionClassInspectorMode _0024act_0024t_0024243)
	{
		_0024act_0024t_0024243.objectName = _0024act_0024t_0024243.go.name;
		_0024act_0024t_0024243.viewStack.Push(new InspectionData(_0024act_0024t_0024243.c.GetType().ToString(), _0024act_0024t_0024243.c));
	}

	internal void _0024createDataInspectorMode_0024closure_00243375(ActionClassInspectorMode _0024act_0024t_0024243)
	{
		_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281 _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024 = new _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_002414281();
		_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243 = _0024act_0024t_0024243;
		if (_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c == null)
		{
			MainMode();
			return;
		}
		if (_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c is MonoBehaviour)
		{
			_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024m = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c as MonoBehaviour;
			activationSwitch(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024m.enabled, new __LotterySequence_startUpdateFunc_0024callable42_002410_31__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243376(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke), new __LotterySequence_startUpdateFunc_0024callable42_002410_31__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243377(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
		}
		InspectionData inspectionData = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.viewStack.Peek();
		string text = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.c.GetType().ToString();
		title = "Inspector";
		string lhs = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.objectName + "\n";
		string rhs = string.Empty;
		foreach (InspectionData item in _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024_0024act_0024t_0024243.viewStack)
		{
			rhs = item.name + " > " + rhs;
		}
		lhs += rhs;
		RuntimeDebugModeGuiMixin.box(lhs);
		if (inspectionData.fullInspect)
		{
			if (RuntimeDebugModeGuiMixin.button("full inspect"))
			{
				inspectionData.fullInspect = !inspectionData.fullInspect;
			}
		}
		else if (RuntimeDebugModeGuiMixin.button("self inspect"))
		{
			inspectionData.fullInspect = !inspectionData.fullInspect;
		}
		_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024nameWidth = RuntimeDebugModeGuiMixin.optWidth(200);
		_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024valWidth = RuntimeDebugModeGuiMixin.optWidth(400);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243378(_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
		inspectionData.update();
		_0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024fields = inspectionData.fields;
		IEnumerator enumerator2 = _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024._0024fields.Keys.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			object current2 = enumerator2.Current;
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataInspectorMode_0024closure_00243375_0024closure_00243379(current2, _0024_0024createDataInspectorMode_0024closure_00243375_0024locals_0024).Invoke));
		}
	}

	internal void _0024createDataInspectorMode_0024closure_00243380(ActionClassInspectorMode _0024act_0024t_0024243)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			if (_0024act_0024t_0024243.viewStack.Count <= 1)
			{
				ComponentListMode(_0024act_0024t_0024243.go);
			}
			else
			{
				_0024act_0024t_0024243.viewStack.Pop();
			}
		}
	}
}
