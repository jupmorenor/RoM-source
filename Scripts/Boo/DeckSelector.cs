using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DeckSelector : MonoBehaviour
{
	[Serializable]
	internal class _0024_changeDeck_0024locals_002414469
	{
		internal GameObject _0024spbGo0;
	}

	[Serializable]
	internal class _0024_changeDeck_0024closure_00243077
	{
		internal Vector3 _0024_002412632_002415033;

		internal float _0024_002412631_002415034;

		internal _0024_changeDeck_0024locals_002414469 _0024_0024locals_002415035;

		public _0024_changeDeck_0024closure_00243077(Vector3 _0024_002412632_002415033, float _0024_002412631_002415034, _0024_changeDeck_0024locals_002414469 _0024_0024locals_002415035)
		{
			this._0024_002412632_002415033 = _0024_002412632_002415033;
			this._0024_002412631_002415034 = _0024_002412631_002415034;
			this._0024_0024locals_002415035 = _0024_0024locals_002415035;
		}

		public void Invoke(UITweener tween)
		{
			float num = (_0024_002412631_002415034 = 10000f);
			Vector3 vector = (_0024_002412632_002415033 = _0024_0024locals_002415035._0024spbGo0.gameObject.transform.localPosition);
			float num2 = (_0024_002412632_002415033.x = _0024_002412631_002415034);
			Vector3 vector3 = (_0024_0024locals_002415035._0024spbGo0.gameObject.transform.localPosition = _0024_002412632_002415033);
		}
	}

	[Serializable]
	internal class _0024_changeDeck_0024closure_00243078
	{
		internal float _0024_002412633_002415036;

		internal Vector3 _0024_002412634_002415037;

		internal _0024_changeDeck_0024locals_002414469 _0024_0024locals_002415038;

		public _0024_changeDeck_0024closure_00243078(float _0024_002412633_002415036, Vector3 _0024_002412634_002415037, _0024_changeDeck_0024locals_002414469 _0024_0024locals_002415038)
		{
			this._0024_002412633_002415036 = _0024_002412633_002415036;
			this._0024_002412634_002415037 = _0024_002412634_002415037;
			this._0024_0024locals_002415038 = _0024_0024locals_002415038;
		}

		public void Invoke(UITweener tween)
		{
			float num = (_0024_002412633_002415036 = 10000f);
			Vector3 vector = (_0024_002412634_002415037 = _0024_0024locals_002415038._0024spbGo0.gameObject.transform.localPosition);
			float num2 = (_0024_002412634_002415037.x = _0024_002412633_002415036);
			Vector3 vector3 = (_0024_0024locals_002415038._0024spbGo0.gameObject.transform.localPosition = _0024_002412634_002415037);
		}
	}

	[NonSerialized]
	protected const int DECK_ITEM_STATE_CAP = 10;

	[NonSerialized]
	protected const int DECK_WIDTH = 1100;

	[NonSerialized]
	protected const float DECK_STRENGTH = 15f;

	[NonSerialized]
	protected static DeckSelector _current;

	[NonSerialized]
	protected static int _currentDeckIndex = -1;

	[NonSerialized]
	protected static System.Collections.Generic.List<DeckItemState> _deckItemStateList;

	protected int _deckCount;

	protected int _swipePanelDeckIndex;

	protected int _swipePanelBufferCount;

	protected System.Collections.Generic.List<GameObject> _swipePanelBufferList;

	protected System.Collections.Generic.List<GameObject> _deckButtonList;

	protected UIValidController _leftArrowValidController;

	protected UIValidController _rightArrowValidController;

	protected SwipePanel _swipePanelComponent;

	protected int _onSpringing;

	public GameObject deckButton;

	public UIButtonMessage leftArrow;

	public UIButtonMessage rightArrow;

	public GameObject swipePanel;

	[NonSerialized]
	protected static int initDeckIndex = -1;

	[NonSerialized]
	protected static int initDeckNum = -1;

	[NonSerialized]
	private static bool init;

	[NonSerialized]
	protected static Color[] _deckBackgroundColorArray = new Color[5]
	{
		new Color(0.95686275f, 33f / 85f, 33f / 85f, 1f),
		new Color(19f / 85f, 83f / 85f, 0.6039216f, 1f),
		new Color(0.101960786f, 0.69803923f, 0.99215686f, 1f),
		new Color(84f / 85f, 1f, 0.10980392f, 1f),
		new Color(83f / 85f, 0.6392157f, 3f / 85f, 1f)
	};

	[NonSerialized]
	protected static string[] _deckButtonBackSpArray = new string[5] { "06", "08", "07", "09", "05" };

	[NonSerialized]
	protected static Color[] _deckButtonNumColorArray = new Color[5]
	{
		new Color(1f, 0.7921569f, 0.7921569f, 1f),
		new Color(46f / 51f, 1f, 0.80784315f, 1f),
		new Color(0.85490197f, 0.9098039f, 1f, 1f),
		new Color(0.9372549f, 1f, 0.8235294f, 1f),
		new Color(0.9843137f, 14f / 15f, 40f / 51f, 1f)
	};

	public static bool isDirty => _current._isDirty();

	public static bool isSwipe => (bool)_current && (bool)_current._swipePanelComponent && _current._swipePanelComponent.IsDrag;

	public static int currentDeckIndex => _currentDeckIndex;

	public static DeckItemUiBase currentDeckItemUi
	{
		get
		{
			object result;
			if (_currentDeckIndex < 0)
			{
				result = null;
			}
			else
			{
				DeckItemState deckItemState = _deckItemStateList[_currentDeckIndex];
				DeckItemUiBase deckItemUi = deckItemState.deckItemUi;
				result = deckItemUi;
			}
			return (DeckItemUiBase)result;
		}
	}

	public int deckCount => _deckCount;

	public static bool IsInit => init;

	public DeckSelector()
	{
		_swipePanelBufferCount = 2;
	}

	public static DeckSelector Current()
	{
		if (!(null != _current))
		{
			throw new AssertionFailedException("null != _current");
		}
		return _current;
	}

	public static void SetCurEquip()
	{
		if (_deckItemStateList == null)
		{
			return;
		}
		foreach (DeckItemState deckItemState in _deckItemStateList)
		{
			deckItemState.setCurEquip();
		}
		if (null != _current)
		{
			_current.initDeckPos();
		}
	}

	public static void UpdateEquip()
	{
		if (_deckItemStateList == null)
		{
			return;
		}
		foreach (DeckItemState deckItemState in _deckItemStateList)
		{
			deckItemState.updateEquip();
		}
		if (null != _current)
		{
			_current.initDeckPos();
		}
	}

	public static void selFrMapet(RespFriendPoppet respPet, bool isFriend)
	{
		if (_deckItemStateList == null)
		{
			return;
		}
		foreach (DeckItemState deckItemState in _deckItemStateList)
		{
			deckItemState.selFrMapet(respPet, isFriend);
		}
	}

	public static void Init(int deckIndex, int deckNum)
	{
		initDeckIndex = deckIndex;
		initDeckNum = deckNum;
		init = true;
	}

	public void Awake()
	{
		_current = this;
		_initialize();
	}

	public void Start()
	{
		if (!init)
		{
			throw new AssertionFailedException("Please call 'DeckSelector.Init( deckIndex as int , deckNum as int )' before Start()");
		}
		UserData current = UserData.Current;
		_buildDeck();
		_createDeckButton();
		int num = 0;
		if (initDeckIndex >= 0)
		{
			num = initDeckIndex;
			initDeckIndex = -1;
		}
		setCurrentDeckIndex(num, aGui: true, aSpringScroll: true);
		_initSwipePanel(num);
	}

	public void OnDestroy()
	{
		_current = null;
		init = false;
	}

	public void Update()
	{
		_updateSwipePanel();
		if (_deckItemStateList == null)
		{
			return;
		}
		foreach (DeckItemState deckItemState in _deckItemStateList)
		{
			deckItemState.preUpdate();
		}
	}

	public void OnEnable()
	{
		if (null != _swipePanelComponent)
		{
			_swipePanelComponent.Reset();
		}
	}

	public static void deselect()
	{
		if (_deckItemStateList == null)
		{
			return;
		}
		foreach (DeckItemState deckItemState in _deckItemStateList)
		{
			deckItemState?.deselect();
		}
	}

	public void initDeckPos()
	{
		if (_swipePanelBufferList != null)
		{
			GameObject gameObject = _swipePanelBufferList[checked(1 - _swipePanelDeckIndex)];
			if ((bool)gameObject)
			{
				_unbindChildDeckItemUiGo(gameObject, aDeactive: true);
				float x = 10000f;
				Vector3 localPosition = gameObject.transform.localPosition;
				float num = (localPosition.x = x);
				Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
			}
		}
	}

	public void Close()
	{
		initDeckPos();
	}

	protected void _initialize()
	{
		_onSpringing = 0;
		UIDraggablePanel uIDraggablePanel = swipePanel.GetComponent<UIDraggablePanel>() as UIDraggablePanel;
		uIDraggablePanel.scale.y = 0f;
		_currentDeckIndex = -1;
		_deckItemStateList = new System.Collections.Generic.List<DeckItemState>();
		int num = 0;
		int num2 = 10;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int aIndex = num;
			num++;
			DeckItemState deckItemState = new DeckItemState();
			deckItemState.initialize(this, aIndex);
			_deckItemStateList.Add(deckItemState);
		}
		_leftArrowValidController = ExtensionsModule.SetComponent<UIValidController>(leftArrow.gameObject);
		_rightArrowValidController = ExtensionsModule.SetComponent<UIValidController>(rightArrow.gameObject);
	}

	protected void _buildDeck()
	{
		_buildDeckItem();
	}

	protected void _buildDeckItem()
	{
		if (!init)
		{
			throw new AssertionFailedException("init");
		}
		bool flag = false;
		UserData current = UserData.Current;
		System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>();
		bool aDebugZero = false;
		int num = initDeckNum;
		if (2 >= num)
		{
			throw new AssertionFailedException("2 < deckCount");
		}
		if (num >= 10)
		{
			throw new AssertionFailedException("deckCount < DECK_ITEM_STATE_CAP");
		}
		foreach (DeckItemState deckItemState2 in _deckItemStateList)
		{
		}
		GameObject gameObject = _getObjectFromName(transform, "Grid");
		GameObject gameObject2 = _getObjectFromName(gameObject.transform, "DeckItemUi");
		gameObject2.SetActive(value: false);
		int length = _deckBackgroundColorArray.Length;
		GameObject aGo = _getObjectFromName(gameObject2.transform, "Win");
		Color color = _getChildSpriteColor(aGo, 0);
		if (!(gameObject2 != null))
		{
			return;
		}
		GameObject[] array = new GameObject[0];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			GameObject gameObject3 = null;
			if (num4 == 0)
			{
				gameObject3 = gameObject2;
			}
			else
			{
				gameObject3 = NGUITools.InstantiateWithoutUIPanel(gameObject2) as GameObject;
				gameObject3.transform.parent = null;
				gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
				int num5 = checked(1100 * num4);
				gameObject3.transform.localPosition = new Vector3(num5, 0f, 0f);
				gameObject3.SetActive(value: false);
				int index = num4 % length;
				Color[] deckBackgroundColorArray = _deckBackgroundColorArray;
				Color aColor = deckBackgroundColorArray[RuntimeServices.NormalizeArrayIndex(deckBackgroundColorArray, index)];
				aColor.a = color.a;
				GameObject gameObject4 = _getObjectFromName(gameObject3.transform, "Win");
				int childCount = gameObject4.transform.childCount;
				int num6 = 0;
				int num7 = childCount;
				if (num7 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num6 < num7)
				{
					int aChildIndex = num6;
					num6++;
					_setChildSpriteColor(gameObject4, aChildIndex, aColor);
				}
			}
			array = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), array, new GameObject[1] { gameObject3 });
		}
		int num8 = 0;
		int num9 = num;
		if (num9 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num8 < num9)
		{
			int num10 = num8;
			num8++;
			DeckItemState deckItemState = _deckItemStateList[num10];
			GameObject[] array2 = array;
			GameObject gameObject3 = array2[RuntimeServices.NormalizeArrayIndex(array2, num10)];
			if (!(null != gameObject3))
			{
				throw new AssertionFailedException("null != diuGo");
			}
			deckItemState.setDeckItemUiGo(gameObject3);
			DeckItemUiBase deckItemUiBase = gameObject3.GetComponent<DeckItemUiBase>() as DeckItemUiBase;
			deckItemUiBase.initialize(deckItemState, num10, aEquip: false, aDebugZero);
			deckItemState.preUpdate();
		}
	}

	protected GameObject _getObjectFromName(Transform aRoot, string aName)
	{
		GameObject gameObject = null;
		int num = 0;
		int childCount = aRoot.childCount;
		if (childCount < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < childCount)
		{
			int index = num;
			num++;
			Transform child = aRoot.GetChild(index);
			GameObject gameObject2 = child.gameObject;
			if (gameObject2.name == aName)
			{
				gameObject = gameObject2;
				break;
			}
		}
		if (gameObject == null)
		{
			int num2 = 0;
			int childCount2 = aRoot.childCount;
			if (childCount2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < childCount2)
			{
				int index2 = num2;
				num2++;
				Transform child2 = aRoot.GetChild(index2);
				gameObject = _getObjectFromName(child2, aName);
				if (gameObject != null)
				{
					break;
				}
			}
		}
		return gameObject;
	}

	protected Color _getChildSpriteColor(GameObject aGo, int aChildIndex)
	{
		Color result = Color.clear;
		UISprite uISprite = _getChildSprite(aGo, aChildIndex);
		if (uISprite != null)
		{
			result = uISprite.color;
		}
		return result;
	}

	protected void _setChildSpriteColor(GameObject aGo, int aChildIndex, Color aColor)
	{
		UISprite uISprite = _getChildSprite(aGo, aChildIndex);
		if (uISprite != null)
		{
			uISprite.color = aColor;
		}
	}

	protected UISprite _getChildSprite(GameObject aGo, int aChildIndex)
	{
		UISprite result = null;
		Transform transform = aGo.transform;
		int childCount = transform.childCount;
		if (aChildIndex < childCount)
		{
			Transform child = transform.GetChild(aChildIndex);
			GameObject gameObject = child.gameObject;
			result = gameObject.GetComponent<UISprite>() as UISprite;
		}
		return result;
	}

	protected DeckItemUiBase _getDeckItemUi(int aDeckIndex)
	{
		DeckItemState deckItemState = _deckItemStateList[aDeckIndex];
		return deckItemState.deckItemUi;
	}

	public static WeaponEquipments[] CreateWeaponEquipmentsArray()
	{
		int num = _current.deckCount;
		WeaponEquipments[] array = new WeaponEquipments[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			DeckItemUi deckItemUi = (DeckItemUi)_current._getDeckItemUi(num4);
			WeaponEquipments weaponEquipments = null;
			if (null != deckItemUi)
			{
				weaponEquipments = deckItemUi.weaponEquipments;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, num4)] = weaponEquipments;
		}
		return array;
	}

	protected bool _isDirty()
	{
		bool flag = false;
		if (_isDirtyDeckIndex())
		{
			flag = true;
		}
		if (!flag)
		{
			flag = _isDirtyEquipments();
		}
		return flag;
	}

	protected bool _isDirtyDeckIndex()
	{
		UserData current = UserData.Current;
		bool flag = false;
		return true;
	}

	protected bool _isDirtyEquipments()
	{
		bool result = false;
		int num = 0;
		int num2 = _deckCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int aDeckIndex = num;
			num++;
			DeckItemUiBase deckItemUiBase = _getDeckItemUi(aDeckIndex);
			if (deckItemUiBase.isDirty)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static void OnSent()
	{
		_current._onSent();
	}

	protected virtual void _onSent()
	{
		int num = 0;
		int num2 = _deckCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int aDeckIndex = num;
			num++;
			DeckItemUiBase deckItemUiBase = _current._getDeckItemUi(aDeckIndex);
			deckItemUiBase.onSent();
		}
	}

	public void OnClickedDeckButton()
	{
		if (!_swipePanelComponent.IsDrag)
		{
			if (SwipePanel.UnifiedSwipeFunc)
			{
				_changeDeck(1);
			}
			else
			{
				_addCurrentDeckIndex(1, aGui: true, aSpringScroll: true);
			}
		}
	}

	public void OnClickedIncreaseDeck()
	{
		if (!_swipePanelComponent.IsDrag && _currentDeckIndex < checked(_deckCount - 1))
		{
			if (SwipePanel.UnifiedSwipeFunc)
			{
				_changeDeck(1);
			}
			else
			{
				_addCurrentDeckIndex(1, aGui: true, aSpringScroll: true);
			}
		}
	}

	public void OnClickedDecreaseDeck()
	{
		if (!_swipePanelComponent.IsDrag && _currentDeckIndex != 0)
		{
			if (SwipePanel.UnifiedSwipeFunc)
			{
				_changeDeck(-1);
			}
			else
			{
				_addCurrentDeckIndex(-1, aGui: true, aSpringScroll: true);
			}
		}
	}

	public void increaseDeckCount()
	{
		checked
		{
			_deckCount++;
		}
	}

	public void setCurrentDeckIndex(int aIndex, bool aGui, bool aSpringScroll)
	{
		if (aIndex != _currentDeckIndex)
		{
			_currentDeckIndex = aIndex;
			if (aGui)
			{
				_updateDeckGui();
			}
		}
	}

	protected void _invalidDrag()
	{
		_onSpringing = 4;
		UIDraggablePanel uIDraggablePanel = swipePanel.GetComponent<UIDraggablePanel>() as UIDraggablePanel;
		uIDraggablePanel.scale.x = 0f;
	}

	protected void _validDrag()
	{
		UIDraggablePanel uIDraggablePanel = swipePanel.GetComponent<UIDraggablePanel>() as UIDraggablePanel;
		uIDraggablePanel.scale.x = 1f;
	}

	protected void _addCurrentDeckIndex(int aAdd, bool aGui, bool aSpringScroll)
	{
		checked
		{
			int num = _currentDeckIndex + aAdd;
			if (0 <= aAdd)
			{
				if (_deckCount <= num)
				{
					num = 0;
				}
			}
			else if (num < 0)
			{
				num = _deckCount - 1;
			}
			setCurrentDeckIndex(num, aGui, aSpringScroll);
		}
	}

	protected void _createDeckButton()
	{
		int length = _deckButtonBackSpArray.Length;
		if (_deckButtonList != null)
		{
			return;
		}
		_deckButtonList = new System.Collections.Generic.List<GameObject>();
		_deckButtonList.Add(deckButton);
		int num = 0;
		int num2 = 10;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			if (num3 != 0 && num3 < length)
			{
				GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(deckButton)) as GameObject;
				_deckButtonList.Add(gameObject);
				gameObject.transform.parent = deckButton.transform.parent;
				gameObject.transform.localPosition = deckButton.transform.localPosition;
				gameObject.transform.localScale = deckButton.transform.localScale;
				UIButtonMessage uIButtonMessage = gameObject.GetComponent<UIButtonMessage>() as UIButtonMessage;
				uIButtonMessage.sendMessage = true;
				GameObject gameObject2 = _getObjectFromName(gameObject.transform, "DeckButtonBackEx");
				UISprite uISprite = gameObject2.GetComponent<UISprite>() as UISprite;
				string[] deckButtonBackSpArray = _deckButtonBackSpArray;
				string spriteName = $"button{deckButtonBackSpArray[RuntimeServices.NormalizeArrayIndex(deckButtonBackSpArray, num3)]}";
				uISprite.spriteName = spriteName;
				GameObject gameObject3 = _getObjectFromName(gameObject.transform, "DeckButtonNumEx");
				UISprite uISprite2 = gameObject3.GetComponent<UISprite>() as UISprite;
				string spriteName2 = $"deck_num{checked(num3 + 1):D2}";
				uISprite2.spriteName = spriteName2;
				Color[] deckButtonNumColorArray = _deckButtonNumColorArray;
				uISprite2.color = deckButtonNumColorArray[RuntimeServices.NormalizeArrayIndex(deckButtonNumColorArray, num3)];
			}
		}
	}

	protected virtual void _updateDeckGui()
	{
		int num = 0;
		int count = _deckButtonList.Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int num2 = num;
			num++;
			GameObject gameObject = _deckButtonList[num2];
			bool flag = false;
			if (num2 == _currentDeckIndex)
			{
				flag = true;
			}
			gameObject.SetActive(flag);
		}
		_leftArrowValidController.isValidColor = true;
		_rightArrowValidController.isValidColor = true;
		if (_currentDeckIndex == 0)
		{
			_leftArrowValidController.isValidColor = false;
		}
		else if (checked(_deckCount - 1) <= _currentDeckIndex)
		{
			_rightArrowValidController.isValidColor = false;
		}
	}

	protected void _onFinishedFromSpringPanel()
	{
		SpringPanel springPanel = swipePanel.GetComponent<SpringPanel>() as SpringPanel;
	}

	protected void _initSwipePanel(int index)
	{
		_swipePanelComponent = ExtensionsModule.SetComponent<SwipePanel>(swipePanel) as SwipePanel;
		_swipePanelComponent.isSwapBuffer = true;
		_swipePanelComponent.swipeWrapType = SwipePanel.SwipeWrapType.None;
		GameObject item = _getObjectFromName(swipePanel.transform, "SwipePanelBuffer");
		_swipePanelBufferList = new System.Collections.Generic.List<GameObject>();
		_swipePanelBufferList.Add(item);
		GameObject item2 = _getObjectFromName(swipePanel.transform, "SwipePanelBufferBack");
		_swipePanelBufferList.Add(item2);
		GameObject[] objs = (GameObject[])Builtins.array(typeof(GameObject), _swipePanelBufferList);
		_swipePanelComponent.Init(objs, 5, OnUpdateFromSwipePanel, OnIndexFromSwipePanel, OnEndFromSwipePanel);
		GameObject deckItemUiGo = _deckItemStateList[index].deckItemUiGo;
		_bindAndIdentity(_swipePanelBufferList[0], deckItemUiGo, aActive: true);
	}

	protected static void _bindAndIdentity(GameObject aParent, GameObject aChild, bool aActive)
	{
		aChild.transform.parent = aParent.transform;
		aChild.transform.localScale = new Vector3(1f, 1f, 1f);
		aChild.transform.localPosition = Vector3.zero;
		if (aActive)
		{
			aChild.SetActive(value: true);
		}
	}

	public static void OnUpdateFromSwipePanel(GameObject aGo, int aIndex)
	{
		_current._onUpdateFromSwipePanel(aGo, aIndex);
	}

	protected void _onUpdateFromSwipePanel(GameObject aGo, int aIndex)
	{
		if (_isValidDeckIndex(aIndex))
		{
			_unbindChildDeckItemUiGo(aGo, aDeactive: true);
			try
			{
				DeckItemState deckItemState = _deckItemStateList[aIndex];
				DeckItemUiBase deckItemUi = deckItemState.deckItemUi;
				GameObject deckItemUiGo = deckItemState.deckItemUiGo;
				_bindAndIdentity(aGo, deckItemUiGo, aActive: true);
			}
			catch (Exception)
			{
			}
			if (!SwipePanel.UnifiedSwipeFunc)
			{
				_resetTweenTarget(aIndex);
			}
		}
	}

	protected static void _unbindChildDeckItemUiGo(GameObject aGo, bool aDeactive)
	{
		int childCount = aGo.transform.childCount;
		System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>();
		int num = 0;
		int num2 = childCount;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform child = aGo.transform.GetChild(index);
			GameObject gameObject = child.gameObject;
			DeckItemUiBase deckItemUiBase = gameObject.GetComponent<DeckItemUiBase>() as DeckItemUiBase;
			if (deckItemUiBase != null)
			{
				list.Add(gameObject);
			}
		}
		int num3 = 0;
		int count = list.Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < count)
		{
			int index2 = num3;
			num3++;
			GameObject gameObject2 = list[index2];
			gameObject2.transform.parent = null;
			if (aDeactive)
			{
				gameObject2.SetActive(value: false);
			}
		}
	}

	public static void OnIndexFromSwipePanel(int aIndex)
	{
		_current._onIndexFromSwipePanel(aIndex);
	}

	protected virtual void _onIndexFromSwipePanel(int aIndex)
	{
		if (!_isValidDeckIndex(aIndex))
		{
			return;
		}
		int num = checked(aIndex - currentDeckIndex);
		if (num == 1 || num == -1)
		{
			_current._addCurrentDeckIndex(num, aGui: true, aSpringScroll: false);
		}
		if (!SwipePanel.UnifiedSwipeFunc)
		{
			int count = _swipePanelBufferList.Count;
			int num2 = 0;
			int num3 = count;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int aSbIndex = num2;
				num2++;
				_resetTweenTarget(aSbIndex);
			}
		}
	}

	public static void OnEndFromSwipePanel()
	{
		_current._onEndFromSwipePanel();
	}

	protected void _onEndFromSwipePanel()
	{
		if (SwipePanel.UnifiedSwipeFunc)
		{
			int swipePanelDeckIndex = _swipePanelDeckIndex;
			GameObject gameObject = _swipePanelBufferList[checked(1 - swipePanelDeckIndex)];
			GameObject gameObject2 = _swipePanelBufferList[swipePanelDeckIndex];
			int num = 0;
			Vector3 localPosition = gameObject.transform.localPosition;
			float num2 = (localPosition.x = num);
			Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
			int num3 = 10000;
			Vector3 localPosition2 = gameObject.transform.localPosition;
			float num4 = (localPosition2.x = num3);
			Vector3 vector4 = (gameObject.transform.localPosition = localPosition2);
		}
	}

	protected void _resetTweenTarget(int aSbIndex)
	{
		int count = _swipePanelBufferList.Count;
		int num = aSbIndex % count;
		int num2 = _currentDeckIndex % count;
		GameObject gameObject = _swipePanelBufferList[num];
		UIAutoTweener uIAutoTweener = gameObject.GetComponent<UIAutoTweener>() as UIAutoTweener;
		Vector3 targetPositionFromSbIndex = _swipePanelComponent.getTargetPositionFromSbIndex(num);
		if (num == num2)
		{
			uIAutoTweener.whereFrom = UIAutoTweener.WhereFrom.left;
		}
		else
		{
			uIAutoTweener.whereFrom = UIAutoTweener.WhereFrom.top;
		}
		targetPositionFromSbIndex.x = 0f - targetPositionFromSbIndex.x;
		uIAutoTweener.SetTargetPosition(targetPositionFromSbIndex);
	}

	protected void _changeDeck(int add)
	{
		_0024_changeDeck_0024locals_002414469 _0024_changeDeck_0024locals_0024 = new _0024_changeDeck_0024locals_002414469();
		_0024_changeDeck_0024locals_0024._0024spbGo0 = _swipePanelBufferList[_swipePanelDeckIndex];
		checked
		{
			GameObject gameObject = _swipePanelBufferList[1 - _swipePanelDeckIndex];
			if (!_0024_changeDeck_0024locals_0024._0024spbGo0 || !gameObject)
			{
				return;
			}
			_swipePanelDeckIndex = 1 - _swipePanelDeckIndex;
			int num = _currentDeckIndex;
			_current._addCurrentDeckIndex(add, aGui: true, aSpringScroll: false);
			_0024_changeDeck_0024locals_0024._0024spbGo0.SetActive(value: true);
			gameObject.SetActive(value: true);
			_unbindChildDeckItemUiGo(gameObject, aDeactive: true);
			DeckItemState deckItemState = _deckItemStateList[_currentDeckIndex];
			DeckItemUiBase deckItemUi = deckItemState.deckItemUi;
			GameObject deckItemUiGo = deckItemState.deckItemUiGo;
			_bindAndIdentity(gameObject, deckItemUiGo, aActive: true);
			if (_currentDeckIndex > num || (_currentDeckIndex == 0 && num >= 4))
			{
				TweenPosition tweenPosition = TweenPosition.Begin(_0024_changeDeck_0024locals_0024._0024spbGo0.gameObject, 0.2f, new Vector3(-2000f, 0f, 0f));
				Vector3 _0024_002412632_0024 = default(Vector3);
				float _0024_002412631_0024 = default(float);
				tweenPosition.onFinished = new _0024_changeDeck_0024closure_00243077(_0024_002412632_0024, _0024_002412631_0024, _0024_changeDeck_0024locals_0024).Invoke;
				TweenPosition tweenPosition2 = TweenPosition.Begin(gameObject.gameObject, 0.2f, new Vector3(0f, 0f, 0f));
				if ((bool)tweenPosition2)
				{
					tweenPosition2.From = new Vector3(2000f, 0f, 0f);
				}
			}
			else if (_currentDeckIndex < num)
			{
				TweenPosition tweenPosition = TweenPosition.Begin(_0024_changeDeck_0024locals_0024._0024spbGo0.gameObject, 0.2f, new Vector3(2000f, 0f, 0f));
				float _0024_002412633_0024 = default(float);
				Vector3 _0024_002412634_0024 = default(Vector3);
				tweenPosition.onFinished = new _0024_changeDeck_0024closure_00243078(_0024_002412633_0024, _0024_002412634_0024, _0024_changeDeck_0024locals_0024).Invoke;
				TweenPosition tweenPosition2 = TweenPosition.Begin(gameObject.gameObject, 0.2f, new Vector3(0f, 0f, 0f));
				if ((bool)tweenPosition2)
				{
					tweenPosition2.From = new Vector3(-2000f, 0f, 0f);
				}
			}
		}
	}

	protected void _updateSwipePanel()
	{
		if (_swipePanelComponent != null)
		{
			int num = 0;
			if (SwipePanel.UnifiedSwipeFunc)
			{
				num = _swipePanelDeckIndex;
			}
			else if (_swipePanelComponent.isSwapBuffer)
			{
				num = currentDeckIndex % _swipePanelBufferCount;
			}
			else if (0 == 0)
			{
				throw new AssertionFailedException("false");
			}
			_swipePanelComponent.SwipeCtrl(currentDeckIndex, num);
		}
	}

	public void updateSwipePanel()
	{
		_updateSwipePanel();
	}

	protected bool _isValidDeckIndex(int aIndex)
	{
		bool result = false;
		if (0 <= aIndex && aIndex < _deckCount)
		{
			result = true;
		}
		return result;
	}
}
