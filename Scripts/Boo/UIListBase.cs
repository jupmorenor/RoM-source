using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class UIListBase : AbstractUIListBase
{
	[Serializable]
	public class Container
	{
		public UIListItem.Data data;

		public GameObject obj;

		public int delay;

		public Container()
		{
			delay = DELAY_RESET;
		}
	}

	[Serializable]
	[CompilerGenerated]
	public delegate Boo.Lang.List<Container> ListSortFunc(Boo.Lang.List<Container> container);

	[Serializable]
	internal class _0024CreateItemLater_0024locals_002414491
	{
		internal int _0024index;

		internal int _0024delay;
	}

	[Serializable]
	internal class _0024CreateItemLater_0024closure_00243230
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421510 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024CreateItemLater_0024closure_00243230 _0024self__002421511;

				public _0024(_0024CreateItemLater_0024closure_00243230 self_)
				{
					_0024self__002421511 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay > 0)
						{
							goto case 1;
						}
						_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay = _0024self__002421511._0024_0024locals_002415077._0024delay;
						goto IL_00ed;
					case 2:
						_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay = checked(_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay - 1);
						goto IL_00ed;
					case 1:
						{
							result = 0;
							break;
						}
						IL_00ed:
						if (_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay > 0)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index] != null && _0024self__002421511._0024this_002415078.containers[_0024self__002421511._0024_0024locals_002415077._0024index].delay >= 0)
						{
							_0024self__002421511._0024this_002415078.CreateItem(_0024self__002421511._0024_0024locals_002415077._0024index);
							YieldDefault(1);
						}
						goto case 1;
					}
					return (byte)result != 0;
				}
			}

			internal _0024CreateItemLater_0024closure_00243230 _0024self__002421512;

			public _0024Invoke_002421510(_0024CreateItemLater_0024closure_00243230 self_)
			{
				_0024self__002421512 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421512);
			}
		}

		internal _0024CreateItemLater_0024locals_002414491 _0024_0024locals_002415077;

		internal UIListBase _0024this_002415078;

		public _0024CreateItemLater_0024closure_00243230(_0024CreateItemLater_0024locals_002414491 _0024_0024locals_002415077, UIListBase _0024this_002415078)
		{
			this._0024_0024locals_002415077 = _0024_0024locals_002415077;
			this._0024this_002415078 = _0024this_002415078;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421510(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024EnumerateContainer_002421500 : GenericGenerator<Container>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Container>, IEnumerator
		{
			internal Container _0024cont_002421501;

			internal IEnumerator<Container> _0024_0024iterator_002414153_002421502;

			internal UIListBase _0024self__002421503;

			public _0024(UIListBase self_)
			{
				_0024self__002421503 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024iterator_002414153_002421502 = _0024self__002421503.containers.GetEnumerator();
						_state = 2;
						break;
					case 3:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002414153_002421502.MoveNext())
					{
						_0024cont_002421501 = _0024_0024iterator_002414153_002421502.Current;
						flag = Yield(3, _0024cont_002421501);
						goto IL_0095;
					}
					_state = 1;
					_0024ensure2();
					YieldDefault(1);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0096;
				IL_0095:
				result = (flag ? 1 : 0);
				goto IL_0096;
				IL_0096:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414153_002421502.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal UIListBase _0024self__002421504;

		public _0024EnumerateContainer_002421500(UIListBase self_)
		{
			_0024self__002421504 = self_;
		}

		public override IEnumerator<Container> GetEnumerator()
		{
			return new _0024(_0024self__002421504);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Initialize_0024createIcons_00243226_002421505 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024n_002421506;

			internal int _0024_00243227_002421507;

			internal UIListBase _0024self__002421508;

			public _0024(UIListBase self_)
			{
				_0024self__002421508 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024n_002421506 = _0024self__002421508.endIndex;
					goto case 2;
				case 2:
					if (_0024n_002421506 < _0024self__002421508.containers.Count())
					{
						UIListBase uIListBase = _0024self__002421508;
						int num = (_0024n_002421506 = checked((_0024_00243227_002421507 = _0024n_002421506) + 1));
						uIListBase.CreateItem(_0024_00243227_002421507);
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

		internal UIListBase _0024self__002421509;

		public _0024_0024Initialize_0024createIcons_00243226_002421505(UIListBase self_)
		{
			_0024self__002421509 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421509);
		}
	}

	private Boo.Lang.List<Container> containers;

	public string myUniqId;

	public GameObject listItemPrefab;

	public float itemScale;

	public Vector2 padding;

	private Vector2 itemSize;

	private GameObject msgTarget;

	public UIListItemDetail detailWindow;

	public GameObject listTable;

	public int tableColumn;

	private int startIndex;

	private int endIndex;

	private Vector3 startPosition;

	private UIPanel clippingPanel;

	public UIDraggablePanel draggablePanel;

	public float selectedMoveStrength;

	public UIScrollBar scrollBar;

	private int lastContainersCount;

	[NonSerialized]
	public static readonly int DELAY_RESET = -1;

	public int listItemDragDelayFrame;

	private UIListItem.Data m_focusItem;

	private Boo.Lang.List<UIListItem> m_selectItems;

	public int selectMax;

	private bool allowAutoTweenPosition;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ delegateDecide;

	public __UIListBase_HookAutoFocusItem_0024callable103_0024108_33__ hookAutoFocusItem;

	public __UIListBase_HookSettingListItem_0024callable104_0024110_35__ hookSettingListItem;

	public __UIListBase_HookConvertDataList_0024callable105_0024112_35__ hookConvertDataList;

	public __UIListBase_HookSettingListItem_0024callable104_0024110_35__ hookSelectItem;

	public __UIListBase_HookSetDetail_0024callable106_0024116_29__ hookSetDetail;

	public __UIListBase_HookSort_0024callable107_0024118_24__ hookSort;

	private bool initFinished;

	private int delayCount;

	private bool scrollBarCallbackAdded;

	public SortButton sortButton;

	public Transform sortWindowParent;

	protected string[] sortTypeName;

	protected int defaultSortNo;

	protected string currentSortName;

	private Dictionary<string, ListSortFunc> sortFuncs;

	public UIListItem.Data focusItem => m_focusItem;

	public UIListItem[] SelectItems => m_selectItems.ToArray();

	public UIListItem OneSelectItem => m_selectItems[0];

	public int selectCount => m_selectItems.Count();

	public bool isSelectCountStop => selectMax <= selectCount;

	private bool CanUseScrollBar
	{
		get
		{
			bool num = draggablePanel.uiListBase == this;
			if (num)
			{
				num = scrollBar != null;
			}
			return num;
		}
	}

	public bool isInitFinished => initFinished;

	private int sortFuncMax => sortFuncs.Count();

	private string sortSceneKey => string.IsNullOrEmpty(myUniqId) ? string.Empty : ("sort_key_" + SceneChanger.CurrentSceneName + "_" + myUniqId);

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ DelegateDecide
	{
		get
		{
			return delegateDecide;
		}
		set
		{
			delegateDecide = value;
		}
	}

	public __UIListBase_HookAutoFocusItem_0024callable103_0024108_33__ HookAutoFocusItem
	{
		get
		{
			return hookAutoFocusItem;
		}
		set
		{
			hookAutoFocusItem = value;
		}
	}

	public __UIListBase_HookSettingListItem_0024callable104_0024110_35__ HookSettingListItem
	{
		get
		{
			return hookSettingListItem;
		}
		set
		{
			hookSettingListItem = value;
		}
	}

	public __UIListBase_HookConvertDataList_0024callable105_0024112_35__ HookConvertDataList
	{
		get
		{
			return hookConvertDataList;
		}
		set
		{
			hookConvertDataList = value;
		}
	}

	public __UIListBase_HookSettingListItem_0024callable104_0024110_35__ HookSelectItem
	{
		get
		{
			return hookSelectItem;
		}
		set
		{
			hookSelectItem = value;
		}
	}

	public __UIListBase_HookSetDetail_0024callable106_0024116_29__ HookSetDetail
	{
		get
		{
			return hookSetDetail;
		}
		set
		{
			hookSetDetail = value;
		}
	}

	public __UIListBase_HookSort_0024callable107_0024118_24__ HookSort
	{
		get
		{
			return hookSort;
		}
		set
		{
			hookSort = value;
		}
	}

	public UIListBase()
	{
		containers = new Boo.Lang.List<Container>();
		itemScale = 1f;
		padding = Vector2.zero;
		tableColumn = 5;
		startIndex = -10;
		endIndex = 19;
		selectedMoveStrength = 13f;
		lastContainersCount = -1;
		listItemDragDelayFrame = 5;
		m_selectItems = new Boo.Lang.List<UIListItem>();
		selectMax = 1;
		defaultSortNo = 1;
		sortFuncs = new Dictionary<string, ListSortFunc>();
	}

	public UIListItem.Data[] GetDataList()
	{
		Boo.Lang.List<UIListItem.Data> list = new Boo.Lang.List<UIListItem.Data>();
		Boo.Lang.List<Container> list2 = containers;
		int count = ((ICollection)list2).Count;
		int num = 0;
		while (num < count)
		{
			Container container = list2[checked(num++)];
			if (container != null)
			{
				list.Add(container.data);
			}
		}
		return list.ToArray();
	}

	public GameObject[] GetItemObjectList()
	{
		Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
		Boo.Lang.List<Container> list2 = containers;
		int count = ((ICollection)list2).Count;
		int num = 0;
		while (num < count)
		{
			Container container = list2[checked(num++)];
			if (container != null)
			{
				list.Add(container.obj);
			}
		}
		return list.ToArray();
	}

	public T GetFocusData<T>()
	{
		T result = (T)null;
		if (m_focusItem != null)
		{
			result = m_focusItem.GetData<T>();
		}
		return result;
	}

	public void SetFocusItem(long id)
	{
		SetFocusItem(Find(id));
	}

	public void SetFocusItem(UIListItem.Data item)
	{
		if (item != null && (m_focusItem == null || m_focusItem.id != item.id))
		{
			IEnumerator<Container> enumerator = containers.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Container current = enumerator.Current;
					SetFocusToContainer(current, m_focusItem, focus: false);
					SetFocusToContainer(current, item, focus: true);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		m_focusItem = item;
		SetDetail(item);
	}

	private void SetFocusToContainer(Container c, UIListItem.Data data, bool focus)
	{
		if (data != null && c.data.id == data.id && (bool)c.obj)
		{
			UIListItem component = c.obj.GetComponent<UIListItem>();
			component.Focus = focus;
		}
	}

	public object[] GetSelectItemDatas()
	{
		object result;
		if (1 >= selectMax)
		{
			result = new object[1] { focusItem.core };
		}
		else
		{
			Boo.Lang.List<object> list = new Boo.Lang.List<object>();
			IEnumerator<UIListItem> enumerator = m_selectItems.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					UIListItem current = enumerator.Current;
					list.Add(current.GetData().core);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = list.ToArray();
		}
		return (object[])result;
	}

	private void OnEnable()
	{
		SetSortButtonAndLabelName(currentSortName);
	}

	public void Reset()
	{
		initFinished = false;
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				UnityEngine.Object.Destroy(current.obj);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		containers = new Boo.Lang.List<Container>();
		SetFocusItem(null);
		if ((bool)clippingPanel)
		{
			float y = 0f;
			Vector4 clipRange = clippingPanel.clipRange;
			float num = (clipRange.y = y);
			Vector4 vector2 = (clippingPanel.clipRange = clipRange);
			clippingPanel.transform.localPosition = Vector3.zero;
			UpdateScroll();
		}
	}

	public void UpdateData(object[] list)
	{
		Boo.Lang.List<UIListItem.Data> list2 = ConvertDataList(list);
		Boo.Lang.List<Container> list3 = new Boo.Lang.List<Container>();
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				if (0L >= current.data.id)
				{
					throw new AssertionFailedException(new StringBuilder("error: conのデータがおかしいです!! \u3000con.data.id == ").Append((object)current.data.id).ToString());
				}
				UIListItem.Data data = null;
				IEnumerator<UIListItem.Data> enumerator2 = list2.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						UIListItem.Data current2 = enumerator2.Current;
						if (current2 == null || current2.id < 1 || current2.id != current.data.id)
						{
							continue;
						}
						data = current2;
						break;
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				if (data == null)
				{
					list3.Add(current);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<Container> enumerator3 = list3.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Container current3 = enumerator3.Current;
				DeleteContainer(current3);
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
		bool isFocus = false;
		IEnumerator<UIListItem.Data> enumerator4 = list2.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				UIListItem.Data current4 = enumerator4.Current;
				UpdateContainer(current4, ref isFocus);
			}
		}
		finally
		{
			enumerator4.Dispose();
		}
		if (!isFocus)
		{
			SetDefaultFocus();
		}
	}

	public void Initialize(object[] list, GameObject target, bool autoTween)
	{
		if (initFinished || list == null)
		{
			return;
		}
		delayCount = 0;
		allowAutoTweenPosition = autoTween;
		msgTarget = target;
		if (!(listTable != null))
		{
			throw new AssertionFailedException("List Table が nullでした");
		}
		if (!(draggablePanel != null))
		{
			throw new AssertionFailedException("UIDraggablePanel が nullでした");
		}
		UnityEngine.Object.Destroy(listTable.GetComponent<UITable>());
		if (list == null)
		{
			throw new AssertionFailedException("作ろうとしたリストのdata配列がnullでした");
		}
		IEnumerator<UIListItem.Data> enumerator = ConvertDataList(list).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				UIListItem.Data current = enumerator.Current;
				AddContainer(current, null);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		UIListItem component = listItemPrefab.GetComponent<UIListItem>();
		Vector3 vector = default(Vector3);
		vector = ((!component.baseBg) ? component.ItemScale : component.baseBg.transform.localScale);
		itemSize.x = vector.x * itemScale;
		itemSize.y = vector.y * itemScale;
		clippingPanel = draggablePanel.GetComponent<UIPanel>();
		startPosition = clippingPanel.transform.localPosition;
		float num = clippingPanel.clipRange.z - clippingPanel.clipRange.x - clippingPanel.clipSoftness.x;
		float num2 = clippingPanel.clipRange.w - clippingPanel.clipRange.y - clippingPanel.clipSoftness.y;
		startPosition.x -= (num - (num - (itemSize.x + padding.x) * (float)tableColumn)) / 2f;
		startPosition.y = num2 / 2f - 8f;
		if (!scrollBar)
		{
			scrollBar = draggablePanel.verticalScrollBar;
		}
		if ((bool)scrollBar)
		{
			scrollBar.onChange = null;
		}
		int num3 = Mathf.RoundToInt(num2 / (itemSize.y + padding.y));
		checked
		{
			startIndex = tableColumn * -3;
			endIndex = tableColumn * (num3 + 3);
			draggablePanel.disableDragIfFits = containers.Count() <= endIndex;
			draggablePanel.restrictWhenPress = false;
			lastContainersCount = containers.Count();
			if (false)
			{
				UIMain uIMain = (UIMain)UnityEngine.Object.FindObjectOfType(typeof(UIMain));
				if ((bool)uIMain)
				{
					__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Initialize_0024createIcons_00243226_002421505(this).GetEnumerator();
					uIMain.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
				}
			}
			SetDefaultFocus();
			InitSort();
			initFinished = true;
			TopTailIndexInit();
		}
	}

	private void CreateTop(int tailIndex)
	{
		UIListItem uIListItem = CreateItem(tailIndex);
		uIListItem.gameObject.SetActive(value: true);
	}

	private void TopTailIndexInit()
	{
		if (CanUseScrollBar && 0 < containers.Count)
		{
			CreateTop(0);
			CreateTop(checked(containers.Count - 1));
		}
	}

	public void SetDefaultFocus()
	{
		SetFocusItem(AutoFocusItem());
	}

	protected UIListItem.Data AutoFocusItem()
	{
		object result;
		if (hookAutoFocusItem != null)
		{
			UIListItem.Data arg = null;
			if (hookAutoFocusItem(ref arg))
			{
				result = arg;
				goto IL_004d;
			}
		}
		result = ((containers.Count > 0) ? containers[0].data : null);
		goto IL_004d;
		IL_004d:
		return (UIListItem.Data)result;
	}

	private UIListItem CreateItem(int index)
	{
		if (0 > index && index >= containers.Count)
		{
			throw new AssertionFailedException("index が配列の範囲外です!!");
		}
		object result;
		if (containers[index] != null)
		{
			containers[index].delay = 0;
			GameObject obj = containers[index].obj;
			if (obj != null)
			{
				obj.name = "Item " + index.ToString();
				containers[index].obj = obj;
				result = obj.GetComponent<UIListItem>();
			}
			else
			{
				obj = GameAssetModule.Instantiate(listItemPrefab);
				obj.name = "Item " + index.ToString();
				tableColumn = Mathf.Max(1, tableColumn);
				obj.transform.parent = listTable.transform;
				obj.transform.localScale = Vector3.one * itemScale;
				obj.transform.localPosition = GetPosition(index);
				UIButtonMessage component = obj.gameObject.GetComponent<UIButtonMessage>();
				if ((bool)component)
				{
					component.target = msgTarget;
					component.functionName = "PushSelectItem";
				}
				UIListItem component2 = obj.GetComponent<UIListItem>();
				if (0 <= index && index < containers.Count)
				{
					component2.SetData(containers[index].data);
				}
				component2.Init();
				SettingListItem(component2);
				containers[index].obj = obj;
				SetFocusToContainer(containers[index], m_focusItem, focus: true);
				result = component2;
			}
		}
		else
		{
			result = null;
		}
		return (UIListItem)result;
	}

	private void CreateItemLater(int index, int delay)
	{
		_0024CreateItemLater_0024locals_002414491 _0024CreateItemLater_0024locals_0024 = new _0024CreateItemLater_0024locals_002414491();
		_0024CreateItemLater_0024locals_0024._0024index = index;
		_0024CreateItemLater_0024locals_0024._0024delay = delay;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024CreateItemLater_0024closure_00243230(_0024CreateItemLater_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	protected void SettingListItem(UIListItem item)
	{
		if ((hookSettingListItem != null && hookSettingListItem(item)) || !allowAutoTweenPosition)
		{
			return;
		}
		GameObject gameObject = item.gameObject;
		if (isInitFinished)
		{
			TweenPosition[] components = gameObject.GetComponents<TweenPosition>();
			int num = 0;
			int length = components.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				UnityEngine.Object.Destroy(components[RuntimeServices.NormalizeArrayIndex(components, index)]);
			}
			UnityEngine.Object.Destroy(gameObject.GetComponent<UIAutoTweener>());
		}
		else
		{
			UIAutoTweener uIAutoTweener = gameObject.GetComponent<UIAutoTweener>();
			if (!uIAutoTweener)
			{
				uIAutoTweener = gameObject.AddComponent<UIAutoTweener>();
			}
			uIAutoTweener.delay = (float)delayCount / ((float)tableColumn * 10f);
			gameObject.transform.localPosition = new Vector3(float.MaxValue, float.MaxValue, gameObject.transform.localPosition.z);
			checked
			{
				delayCount++;
			}
		}
	}

	public void ResetListItem(long id)
	{
		UIListItem itemObject = GetItemObject(id);
		if ((bool)itemObject)
		{
			SettingListItem(itemObject);
		}
	}

	public void ResetListAllItems()
	{
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				if (current != null && current.data != null && !(null == current.obj))
				{
					SettingListItem(current.obj.GetComponent<UIListItem>());
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected Boo.Lang.List<UIListItem.Data> ConvertDataList(object[] list)
	{
		Boo.Lang.List<UIListItem.Data> result;
		if (hookConvertDataList != null)
		{
			Boo.Lang.List<UIListItem.Data> arg = null;
			if (hookConvertDataList(list, ref arg))
			{
				result = arg;
				goto IL_007a;
			}
		}
		Boo.Lang.List<UIListItem.Data> list2 = new Boo.Lang.List<UIListItem.Data>();
		int i = 0;
		for (int length = list.Length; i < length; i = checked(i + 1))
		{
			UIListItem.Data data = new UIListItem.Data();
			data.core = list[i];
			data.id = CreateID(list[i]);
			list2.Add(data);
		}
		result = list2;
		goto IL_007a;
		IL_007a:
		return result;
	}

	protected virtual long CreateID(object data)
	{
		return 0L;
	}

	private Vector3 GetPosition(int index)
	{
		Vector3 vector = new Vector3(startPosition.x, startPosition.y, 0f);
		Vector3 vector2 = vector;
		vector.x += (float)(index % tableColumn) * (itemSize.x + padding.x) + (itemSize.x - padding.x) * 0.5f;
		vector.y -= (float)(index / tableColumn) * (itemSize.y + padding.y) + (itemSize.y - padding.y) * 0.5f;
		return vector;
	}

	private void ApplyTweenPos(Container con, Vector3 targetPos)
	{
		UIAutoTweener component = con.obj.GetComponent<UIAutoTweener>();
		TweenPosition component2 = con.obj.GetComponent<TweenPosition>();
		if ((bool)component2 && (bool)component)
		{
			if (!component.isStandAlone)
			{
				throw new AssertionFailedException("autoTween.isStandAlone");
			}
			UIAutoTweener.WhereFrom whereFrom = component.whereFrom;
			switch (whereFrom)
			{
			case UIAutoTweener.WhereFrom.left:
				component2.From = targetPos + new Vector3(0f - component.horizonPosition, 0f, 0f);
				break;
			case UIAutoTweener.WhereFrom.top:
				component2.From = targetPos + new Vector3(0f, component.verticalPosition, 0f);
				break;
			case UIAutoTweener.WhereFrom.right:
				component2.From = targetPos + new Vector3(component.horizonPosition, 0f, 0f);
				break;
			case UIAutoTweener.WhereFrom.bottom:
				component2.From = targetPos + new Vector3(0f, 0f - component.verticalPosition, 0f);
				break;
			default:
				throw new MatchError(new StringBuilder("`autoTween.whereFrom` failed to match `").Append(whereFrom).Append("`").ToString());
			}
			component2.to = targetPos;
			component2.Sample(component2.tweenFactor, isFinished: false);
		}
	}

	private void ShowItem(int i)
	{
		if (0 > i || i >= containers.Count)
		{
			return;
		}
		Container container = containers[i];
		if (container.obj == null)
		{
			int delay = 0;
			if (CanUseScrollBar && scrollBar.IsBeingDragged)
			{
				delay = listItemDragDelayFrame;
			}
			CreateItemLater(i, delay);
		}
		else
		{
			Vector3 position = GetPosition(i);
			if (container.obj.transform.localPosition != position)
			{
				container.obj.transform.localPosition = position;
			}
			if (allowAutoTweenPosition)
			{
				ApplyTweenPos(container, position);
			}
		}
		if (null != container.obj)
		{
			container.obj.SetActive(value: true);
		}
	}

	private void HideItem(int i)
	{
		HideItem(i, destroy: false);
	}

	private void HideItem(int i, bool destroy)
	{
		if (0 > i || i >= containers.Count)
		{
			return;
		}
		Container container = containers[i];
		if (container.delay >= 0)
		{
			container.delay = DELAY_RESET;
		}
		if (!(container.obj != null))
		{
			return;
		}
		if (destroy)
		{
			if (ContainsSelect(container))
			{
				container.obj.transform.localPosition = GetPosition(i);
				container.obj.SetActive(value: false);
			}
			else
			{
				UnityEngine.Object.Destroy(container.obj);
				container.obj = null;
			}
		}
		else
		{
			if ((CanUseScrollBar && i == checked(containers.Count - 1)) || (CanUseScrollBar && i < tableColumn))
			{
				return;
			}
			container.obj.SetActive(value: false);
		}
		containers[i] = container;
	}

	private int MakeCanSeeLength()
	{
		checked
		{
			int num = (int)(clippingPanel.transform.localPosition.y / (itemSize.y + padding.y));
			return (int)Mathf.Round(num * tableColumn);
		}
	}

	private IEnumerable<int> MakeCanSeeRange()
	{
		int num = MakeCanSeeLength();
		return checked(Builtins.range(startIndex + num, endIndex + num));
	}

	protected void UpdateList()
	{
		if (containers.Count > 0)
		{
			int num = MakeCanSeeLength();
			int num8;
			int count;
			int num9;
			checked
			{
				int num2 = startIndex + num;
				int num3 = endIndex + num;
				int num4 = 1;
				if (num3 < num2)
				{
					num4 = -1;
				}
				while (num2 != num3)
				{
					int i = num2;
					num2 = unchecked(num2 + num4);
					ShowItem(i);
				}
				int num5 = startIndex - 1;
				int num6 = Mathf.Min(startIndex + num, containers.Count - endIndex);
				int num7 = 1;
				if (num6 < num5)
				{
					num7 = -1;
				}
				while (num5 != num6)
				{
					int i2 = num5;
					num5 = unchecked(num5 + num7);
					HideItem(i2);
				}
				num8 = Mathf.Max(endIndex + num, startIndex + endIndex);
				count = containers.Count;
				num9 = 1;
				if (count < num8)
				{
					num9 = -1;
				}
			}
			while (num8 != count)
			{
				int i3 = num8;
				num8 += num9;
				HideItem(i3);
			}
		}
	}

	private float CalcScrollPosY(int cnt)
	{
		float num = 0f;
		return Mathf.Ceil((float)cnt / (float)tableColumn) * (itemSize.y + padding.y) - (clippingPanel.clipRange.w + num);
	}

	protected void UpdateScroll()
	{
		Vector3 localPosition = clippingPanel.transform.localPosition;
		if (!(scrollBar != null))
		{
			return;
		}
		float num = CalcScrollPosY(containers.Count);
		if (!scrollBar.IsBeingDragged || !CanUseScrollBar)
		{
			if (localPosition.y < 0f || !(num >= localPosition.y))
			{
				draggablePanel.restrictWithinPanel = true;
			}
			else if (draggablePanel.restrictWithinPanel)
			{
				draggablePanel.restrictWithinPanel = false;
			}
			clippingPanel.transform.localPosition = localPosition;
			if ((bool)scrollBar)
			{
				scrollBar.onChange = null;
				if (!(num <= 0f))
				{
					scrollBar.scrollValue = localPosition.y / num;
				}
				scrollBar.barSize = clippingPanel.clipRange.w / (num + clippingPanel.clipRange.w);
				scrollBar.ForceUpdate();
			}
		}
		else
		{
			draggablePanel.SetDragAmount(0f, scrollBar.scrollValue, updateScrollbars: false);
		}
	}

	protected virtual void Update()
	{
		if (initFinished)
		{
			UpdateList();
		}
	}

	protected virtual void LateUpdate()
	{
		if (!initFinished)
		{
			return;
		}
		if (lastContainersCount != containers.Count)
		{
			Debug.Log("\tif lastContainersCount != containers.Count:");
			int num = Mathf.CeilToInt((float)lastContainersCount / (float)tableColumn);
			int num2 = Mathf.CeilToInt((float)containers.Count / (float)tableColumn);
			int num3 = checked(num - num2);
			if (0 < num3)
			{
				Vector3 localPosition = clippingPanel.transform.localPosition;
				float num4 = CalcScrollPosY(lastContainersCount);
				if (!(num4 > localPosition.y) && !(0f > num4))
				{
					float num5 = CalcScrollPosY(containers.Count);
					float y = Mathf.Clamp01(localPosition.y / num5);
					draggablePanel.UpdateScrollbars(recalculateBounds: true);
					draggablePanel.SetDragAmount(0f, y, updateScrollbars: false);
					int num6 = 0;
					Vector4 clipRange = clippingPanel.clipRange;
					float num7 = (clipRange.x = num6);
					Vector4 vector2 = (clippingPanel.clipRange = clipRange);
					localPosition = clippingPanel.transform.localPosition;
					localPosition.x = 0f;
					clippingPanel.transform.localPosition = localPosition;
				}
			}
			lastContainersCount = containers.Count;
		}
		UpdateScroll();
	}

	protected void InitSort()
	{
		if (!(sortButton == null))
		{
			sortButton.Initialize(sortWindowParent, gameObject, sortTypeName);
		}
		__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ from = delegate(Boo.Lang.List<Container> container)
		{
			Container[] enumerable = ExtensionsModule.StableSort(container.ToArray(), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt((Container a, Container b) => a.data.id.CompareTo(b.data.id)));
			return new Boo.Lang.List<Container>(enumerable);
		};
		SetSortFunc("default", _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183.Adapt(from));
		string key = "default";
		if (sortTypeName != null && 0 < sortTypeName.Length)
		{
			int index = defaultSortNo;
			Dictionary<string, ListSortFunc> dictionary = sortFuncs;
			string[] array = sortTypeName;
			if (dictionary.ContainsKey(array[RuntimeServices.NormalizeArrayIndex(array, index)]))
			{
				string[] array2 = sortTypeName;
				key = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			}
		}
		SimpleSort(key);
	}

	public void SetSortTypeName(string[] names, int no)
	{
		sortTypeName = names;
		defaultSortNo = no;
		object obj = UserData.Current.userMiscInfo.sortData.get(sortSceneKey);
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		if (!string.IsNullOrEmpty((string)obj2))
		{
			defaultSortNo = Array.IndexOf((Array)sortTypeName, obj);
		}
	}

	public void ResetSortFunc()
	{
		if ((bool)clippingPanel)
		{
		}
		sortFuncs.Clear();
		sortTypeName = null;
	}

	public void SetSortFunc(string key, ListSortFunc func)
	{
		if (string.IsNullOrEmpty(key))
		{
		}
		if (func == null)
		{
		}
		if (sortFuncs.ContainsValue(func))
		{
		}
		if (sortFuncs.ContainsKey(key))
		{
		}
		sortFuncs[key] = func;
	}

	public void SetSortButtonAndLabelName(string sortName)
	{
		if ((bool)sortButton)
		{
			sortButton.SetCurrentSortName(sortName);
		}
	}

	public void Sort(string key)
	{
		if (hookSort != null && hookSort(ref key))
		{
			PostSort();
		}
		else
		{
			SimpleSort(key);
		}
	}

	private void PostSort()
	{
		if (initFinished)
		{
			int num = 0;
			int count = containers.Count;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < count)
			{
				int i = num;
				num++;
				HideItem(i, destroy: true);
			}
			TopTailIndexInit();
			UpdateList();
		}
	}

	public void SimpleSort(string key)
	{
		if (sortFuncs.ContainsKey(key))
		{
			containers = sortFuncs[key](containers);
			SetSortButtonAndLabelName(key);
			currentSortName = key;
			UserData.Current.userMiscInfo.sortData.set(sortSceneKey, key);
			PostSort();
		}
	}

	public void RefreshSort()
	{
		bool activeSelf = gameObject.activeSelf;
		if (!activeSelf)
		{
			gameObject.SetActive(value: true);
		}
		UpdateList();
		SimpleSort(currentSortName);
		UpdateScroll();
		draggablePanel.gameObject.SendMessage("LateUpdate", null, SendMessageOptions.DontRequireReceiver);
		if (!activeSelf)
		{
			gameObject.SetActive(activeSelf);
		}
	}

	private void UpdateContainer(UIListItem.Data data, ref bool isFocus)
	{
		if (0L >= data.id)
		{
			throw new AssertionFailedException(new StringBuilder("error: data.id == ").Append((object)data.id).ToString());
		}
		Container container = FindContainer(data);
		if (container != null)
		{
			container.data = data;
			if ((bool)container.obj)
			{
				UIListItem component = container.obj.GetComponent<UIListItem>();
				if (1 < selectMax && component.Select)
				{
					RemoveSelect(component);
				}
				component.SetData(data);
				component.Init();
				SettingListItem(component);
			}
			if (focusItem != null && data.id == focusItem.id)
			{
				SetFocusItem(data);
				isFocus = true;
			}
		}
		else
		{
			AddContainer(data, null);
		}
	}

	private void AddContainer(UIListItem.Data data, GameObject obj)
	{
		Container container = new Container();
		container.data = data;
		container.obj = obj;
		containers.Add(container);
	}

	private void DeleteContainer(Container con)
	{
		if ((bool)con.obj)
		{
			UIListItem component = con.obj.GetComponent<UIListItem>();
			RemoveSelect(component);
		}
		UnityEngine.Object.Destroy(con.obj);
		containers.Remove(con);
	}

	private Container FindContainer(UIListItem.Data data)
	{
		Container container;
		if (data != null && 0L < data.id)
		{
			IEnumerator<Container> enumerator = containers.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Container current = enumerator.Current;
					if (current == null || current.data == null || current.data.id != data.id)
					{
						continue;
					}
					container = current;
					goto IL_007b;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		object result = null;
		goto IL_007c;
		IL_007b:
		result = container;
		goto IL_007c;
		IL_007c:
		return (Container)result;
	}

	public void DeleteItem(int index)
	{
		if (0 <= index && index < containers.Count)
		{
			DeleteContainer(containers[index]);
		}
	}

	public void DeleteItem(GameObject obj)
	{
		if (obj == null)
		{
		}
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				if (current.obj == obj)
				{
					DeleteContainer(current);
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public int GetIndex(GameObject obj)
	{
		int num = 0;
		int num2 = containers.Count();
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < num2)
			{
				int num3 = num;
				num++;
				Container container = containers[num3];
				if (container.obj == obj)
				{
					result = num3;
					break;
				}
				continue;
			}
			result = -1;
			break;
		}
		return result;
	}

	public int GetIndex(UIListItem.Data data)
	{
		int num = 0;
		int num2 = containers.Count();
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < num2)
			{
				int num3 = num;
				num++;
				Container container = containers[num3];
				if (RuntimeServices.EqualityOperator(container.data, data))
				{
					result = num3;
					break;
				}
				continue;
			}
			result = -1;
			break;
		}
		return result;
	}

	public GameObject At(int index)
	{
		return (0 > index || index >= containers.Count() || containers[index] == null) ? null : containers[index].obj;
	}

	public UIListItem.Data GetData(int index)
	{
		return (0 > index || index >= containers.Count() || containers[index] == null) ? null : containers[index].data;
	}

	public int Count()
	{
		return containers.Count();
	}

	public bool Empty()
	{
		return containers.Count() <= 0;
	}

	public UIListItem.Data Find(long id)
	{
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		UIListItem.Data data;
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				if (current == null || current.data == null || current.data.id != id)
				{
					continue;
				}
				data = current.data;
				goto IL_0065;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_0066;
		IL_0065:
		result = data;
		goto IL_0066;
		IL_0066:
		return (UIListItem.Data)result;
	}

	public UIListItem GetItemObject(long id)
	{
		IEnumerator<Container> enumerator = containers.GetEnumerator();
		UIListItem component;
		try
		{
			while (enumerator.MoveNext())
			{
				Container current = enumerator.Current;
				if (current == null || current.data == null || current.data.id != id || !current.obj)
				{
					continue;
				}
				component = current.obj.GetComponent<UIListItem>();
				goto IL_007a;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_007b;
		IL_007a:
		result = component;
		goto IL_007b;
		IL_007b:
		return (UIListItem)result;
	}

	public void SelectItemById(long id)
	{
		SelectItemById(id, canDecide: true);
	}

	public void SelectItemById(long id, bool canDecide)
	{
		int index = -1;
		int num = 0;
		int num2 = containers.Count();
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Container container = containers[num3];
			if (container == null || container.data == null || container.data.id != id)
			{
				continue;
			}
			index = num3;
			break;
		}
		SelectItem(index, canDecide);
	}

	public void SelectItem(int index)
	{
		SelectItem(index, canDecide: true);
	}

	public void SelectItem(int index, bool canDecide)
	{
		if (containers.Count() > 0 && containers.Count() > index && index >= 0)
		{
			if (!containers[index].obj)
			{
				CreateItem(index);
			}
			UIListItem component = containers[index].obj.GetComponent<UIListItem>();
			if (!component)
			{
			}
			SelectItem(component, canDecide);
		}
	}

	public void SelectItem(UIListItem item)
	{
		SelectItem(item, canDecide: true);
	}

	public void SelectItem(UIListItem item, bool canDecide)
	{
		if (hookSelectItem != null && hookSelectItem(item))
		{
			return;
		}
		if ((bool)item && !item.Disable)
		{
			if (1 < selectMax)
			{
				if (ContainsSelect(item))
				{
					RemoveSelect(item);
				}
				else if (!isSelectCountStop)
				{
					AddSelect(item);
				}
				UpdateSelectNo(m_selectItems.ToArray());
			}
			else
			{
				if (1 != selectMax)
				{
					return;
				}
				if (ContainsSelect(item) && m_selectItems.Count() == 1)
				{
					if (DelegateDecide != null && canDecide)
					{
						DelegateDecide();
					}
					return;
				}
				ClearSelectItems();
				AddSelect(item);
			}
		}
		else if (1 == selectMax)
		{
			ClearSelectItems();
		}
		SetFocusItem((!item) ? null : item.GetData());
	}

	public bool ContainsSelect(Container con)
	{
		return con != null && con.obj != null && ContainsSelect(con.obj.GetComponent<UIListItem>());
	}

	public bool ContainsSelect(UIListItem item)
	{
		return m_selectItems.Contains(item);
	}

	public bool ContainsSelect(long id)
	{
		return ContainsSelect(GetItemObject(id));
	}

	public void AddSelect(UIListItem item)
	{
		if ((bool)item)
		{
			m_selectItems.Add(item);
			item.Select = true;
		}
	}

	public void RemoveSelect(UIListItem item)
	{
		if (!(item == null))
		{
			m_selectItems.Remove(item);
			item.Select = false;
			item.SelectNo = 0;
		}
	}

	public void ClearSelectItems()
	{
		IEnumerator<UIListItem> enumerator = m_selectItems.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				UIListItem current = enumerator.Current;
				current.Select = false;
				current.SelectNo = 0;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		m_selectItems.Clear();
	}

	public void UpdateSelectNo(UIListItem[] items)
	{
		if (items != null)
		{
			int num = 0;
			int length = items.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				items[RuntimeServices.NormalizeArrayIndex(items, num2)].SelectNo = checked(num2 + 1);
			}
		}
	}

	public GameObject GetIndexItem(int index)
	{
		return CreateItem(index).gameObject;
	}

	public int GetItemIndex(GameObject item)
	{
		GameObject[] itemObjectList = GetItemObjectList();
		int result = -1;
		int num = 0;
		int length = itemObjectList.Length;
		int num2 = 1;
		if (length < num)
		{
			num2 = -1;
		}
		while (num != length)
		{
			int num3 = num;
			num += num2;
			if (itemObjectList[RuntimeServices.NormalizeArrayIndex(itemObjectList, num3)] == item)
			{
				result = num3;
				break;
			}
		}
		return result;
	}

	public int GetItemIndex(UIListItem.Data data)
	{
		UIListItem.Data[] dataList = GetDataList();
		int result = -1;
		int num = 0;
		int length = dataList.Length;
		int num2 = 1;
		if (length < num)
		{
			num2 = -1;
		}
		while (num != length)
		{
			int num3 = num;
			num += num2;
			if (RuntimeServices.EqualityOperator(dataList[RuntimeServices.NormalizeArrayIndex(dataList, num3)], data))
			{
				result = num3;
				break;
			}
		}
		return result;
	}

	public void ScrollToTarget(UIListItem.Data target)
	{
		ScrollToTarget(GetItemIndex(target));
	}

	public void ScrollToTarget(int showId)
	{
		ScrollToTarget(GetIndexItem(showId), showId);
	}

	public void ScrollToTarget(GameObject target)
	{
		ScrollToTarget(target, GetItemIndex(target));
	}

	public void ScrollToTarget(GameObject target, int index)
	{
		if (target == null || index < 0)
		{
			return;
		}
		target.SetActive(value: true);
		target.transform.localPosition = GetPosition(index);
		Bounds bounds = draggablePanel.bounds;
		Bounds bounds2 = NGUIMath.CalculateRelativeWidgetBounds(draggablePanel.transform, target.transform);
		UIPanel panel = draggablePanel.panel;
		Vector3 vector = panel.CalculateConstrainOffset(bounds2.min, bounds2.max);
		int num = 0;
		while (num < 3)
		{
			int index2 = num;
			num++;
			if (draggablePanel.scale[index2] == 0f)
			{
				vector[index2] = 0f;
			}
		}
		if (!(vector.sqrMagnitude <= 0.001f))
		{
			SpringPanel.Begin(panel.gameObject, panel.transform.localPosition + vector, selectedMoveStrength);
		}
	}

	public void SetDetail(UIListItem.Data data)
	{
		if ((hookSetDetail == null || !hookSetDetail(data)) && (bool)detailWindow)
		{
			detailWindow.gameObject.SetActive(value: true);
			detailWindow.SetDetail(data);
		}
	}

	public void ReceiveChangeItemData(UIListItem.Data data)
	{
		bool isFocus = default(bool);
		UpdateContainer(data, ref isFocus);
	}

	public void PushSelectItem(GameObject obj)
	{
		SelectItem(obj.GetComponent<UIListItem>());
	}

	public void PushSort(string key)
	{
		Sort(key);
		if ((bool)sortButton)
		{
			sortButton.HideWindow(gameObject);
		}
	}

	public void PushSimpleSort(string key)
	{
		SimpleSort(key);
		if ((bool)sortButton)
		{
			sortButton.HideWindow(gameObject);
		}
	}

	public IEnumerable<Container> EnumerateContainer()
	{
		return new _0024EnumerateContainer_002421500(this);
	}

	internal IEnumerator _0024Initialize_0024createIcons_00243226()
	{
		return new _0024_0024Initialize_0024createIcons_00243226_002421505(this).GetEnumerator();
	}

	internal Boo.Lang.List<Container> _0024InitSort_0024defaultSort_00243228(Boo.Lang.List<Container> container)
	{
		Container[] enumerable = ExtensionsModule.StableSort(container.ToArray(), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt((Container a, Container b) => a.data.id.CompareTo(b.data.id)));
		return new Boo.Lang.List<Container>(enumerable);
	}

	internal int _0024_0024InitSort_0024defaultSort_00243228_0024closure_00243229(Container a, Container b)
	{
		return a.data.id.CompareTo(b.data.id);
	}
}
