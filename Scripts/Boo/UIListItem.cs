using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class UIListItem : MonoBehaviour
{
	[Serializable]
	public class State
	{
		public bool autoUsingCheck;

		public bool usingFlag;

		public bool favoriteFlag;

		public bool disableFlag;

		public int number;

		public string cautionText;

		public string usingText;

		public bool igonreUnknown;

		public bool forceUnknown;

		public State()
		{
			cautionText = string.Empty;
			usingText = "使用中";
		}
	}

	[Serializable]
	public class CopyState
	{
		public bool copyForDebugCurrentItemPrint;

		public bool copyAutoUsingCheck;

		public bool copyUsingFlag;

		public bool copyFavoriteFlag;

		public bool copyDisableFlag;

		public bool copyNumber;

		public bool copyCautionText;

		public bool copyUsingText;

		public bool copyItemScale;

		public bool copyData;

		public bool copyWindow;

		public bool copyBaseBg;

		public bool copySelectAreaBase;

		public bool copySelectFrame;

		public bool copySelectNoSprite;

		public bool copySelectNo;

		public bool copyFocusAreaBase;

		public bool copyIconFavoriteSprite;

		public bool copyFavoObject;

		public bool copyIconNewSprite;

		public bool copyNewObject;

		public bool copyIconCautionLabel;

		public bool copyCautionObject;

		public bool copyAlphaTarget;

		public CopyState()
		{
			copyForDebugCurrentItemPrint = true;
			copyAutoUsingCheck = true;
			copyUsingFlag = true;
			copyFavoriteFlag = true;
			copyDisableFlag = true;
			copyNumber = true;
			copyCautionText = true;
			copyUsingText = true;
			copyItemScale = true;
			copyData = true;
			copyWindow = true;
			copyBaseBg = true;
			copySelectAreaBase = true;
			copySelectFrame = true;
			copySelectNoSprite = true;
			copySelectNo = true;
			copyFocusAreaBase = true;
		}
	}

	[Serializable]
	public class Data
	{
		public long id;

		public object core;

		public Data()
		{
			id = -1L;
		}

		public T GetData<T>()
		{
			return (T)core;
		}

		public bool IsData<T>()
		{
			return core is T;
		}
	}

	[Serializable]
	private enum LoopItems
	{
		Level,
		Plus,
		Max
	}

	[Serializable]
	public class AlphaLoopCtrl
	{
		public bool enabled;

		public float speed;

		private float alpha;

		public float maxAlpha;

		public int showCycle;

		public int showTiming;

		private UIWidget[] widgets;

		public string[] targetNames;

		private GameObject baseObjcet;

		public bool IsBlank
		{
			get
			{
				bool num = widgets == null;
				if (!num)
				{
					num = widgets.Length <= 0;
				}
				return num;
			}
		}

		public bool Enabled
		{
			get
			{
				bool num = !IsBlank;
				if (num)
				{
					num = enabled;
				}
				return num;
			}
		}

		public float Alpha
		{
			get
			{
				return alpha;
			}
			set
			{
				alpha = value;
			}
		}

		public AlphaLoopCtrl()
		{
			enabled = true;
			speed = 1f;
			maxAlpha = 1f;
			showCycle = 1;
			showTiming = 1;
		}

		public AlphaLoopCtrl Copy()
		{
			AlphaLoopCtrl alphaLoopCtrl = new AlphaLoopCtrl();
			alphaLoopCtrl.speed = speed;
			alphaLoopCtrl.alpha = alpha;
			alphaLoopCtrl.maxAlpha = maxAlpha;
			alphaLoopCtrl.showCycle = showCycle;
			alphaLoopCtrl.showTiming = showTiming;
			alphaLoopCtrl.targetNames = (string[])Builtins.array(typeof(string), targetNames);
			return alphaLoopCtrl;
		}

		public void Start(GameObject go)
		{
			baseObjcet = go;
			if (null == targetNames || null == baseObjcet)
			{
				return;
			}
			widgets = new UIWidget[0];
			UIWidget[] componentsInChildren = baseObjcet.GetComponentsInChildren<UIWidget>(includeInactive: true);
			int i = 0;
			string[] array = targetNames;
			checked
			{
				for (int length = array.Length; i < length; i++)
				{
					int j = 0;
					UIWidget[] array2 = componentsInChildren;
					for (int length2 = array2.Length; j < length2; j++)
					{
						if (array[i] == array2[j].name)
						{
							widgets = (UIWidget[])RuntimeServices.AddArrays(typeof(UIWidget), widgets, new UIWidget[1] { array2[j] });
						}
					}
				}
			}
		}

		public void SetEnable(string n, bool e)
		{
			if (widgets != null && 0 < widgets.Length)
			{
				UIWidget widget = GetWidget(n);
				if (widget != null)
				{
					enabled = e;
				}
			}
		}

		public void DeleteTarget(string n)
		{
			if (widgets != null && 0 < widgets.Length)
			{
				System.Collections.Generic.List<UIWidget> list = widgets.ToList();
				UIWidget widget = GetWidget(n);
				SetEnable(n, e: false);
				if (widget != null)
				{
					list.Remove(widget);
				}
				widgets = list.ToArray();
			}
		}

		public UIWidget GetWidget(string n)
		{
			int num;
			UIWidget[] array;
			if (widgets != null && 0 < widgets.Length)
			{
				num = 0;
				array = widgets;
				int length = array.Length;
				while (num < length)
				{
					if (array[num] == null || !(n == array[num].name))
					{
						num = checked(num + 1);
						continue;
					}
					goto IL_0057;
				}
			}
			object result = null;
			goto IL_006b;
			IL_006b:
			return (UIWidget)result;
			IL_0057:
			result = array[num];
			goto IL_006b;
		}

		public void Update()
		{
			if (null == widgets || 0 >= showCycle || !(0f < speed))
			{
				return;
			}
			alpha = 0f;
			int num = checked((int)(10000f * colorRadian * speed)) / 62831;
			if (showTiming == num % showCycle)
			{
				alpha = maxAlpha * 0.5f * (0f - Mathf.Cos(colorRadian * speed) + 1f);
			}
			if (!(alpha >= 0f))
			{
				alpha = 0f;
			}
			else if (!(alpha <= 1f))
			{
				alpha = 1f;
			}
			int i = 0;
			UIWidget[] array = widgets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (null != array[i])
				{
					float a = alpha;
					Color color = array[i].color;
					float num2 = (color.a = a);
					Color color3 = (array[i].color = color);
				}
			}
		}
	}

	[NonSerialized]
	public const string IconLevelTokenName = "LevelText";

	[NonSerialized]
	public const string IconPlusTokenName = "PlusText";

	public bool forDebugCurrentItemPrint;

	public UIIconsOptionBase iconOption;

	private State _state;

	public UISprite curIconFavoriteSprite;

	private GameObject favoObject;

	public bool canShowNew;

	public UISprite curIconNewSprite;

	private GameObject newObject;

	public UIDynamicFontLabel curIconCautionLabel;

	private GameObject cautionObject;

	public Vector3 itemScale;

	public CopyState copyState;

	private Data m_data;

	public GameObject window;

	private UISprite m_baseBg;

	public GameObject selectAreaBase;

	private bool _select;

	public GameObject selectFrame;

	public UISprite selectNoSprite;

	private int m_selectNo;

	public bool canFocus;

	public GameObject focusAreaBase;

	public Vector3 focusOffset;

	[NonSerialized]
	public static float colorRadian;

	[NonSerialized]
	public static int index;

	[NonSerialized]
	public static string[] loopItemNames = new string[2] { "LevelText", "PlusText" };

	public AlphaLoopCtrl[] alphaTargets;

	public State state
	{
		get
		{
			return _state;
		}
		set
		{
			_state = value;
		}
	}

	public bool AutoUsingCheck
	{
		get
		{
			return state.autoUsingCheck;
		}
		set
		{
			state.autoUsingCheck = value;
		}
	}

	public bool Using
	{
		get
		{
			return state.usingFlag;
		}
		set
		{
			state.usingFlag = value;
		}
	}

	public bool Favorite
	{
		get
		{
			return state.favoriteFlag;
		}
		set
		{
			state.favoriteFlag = value;
		}
	}

	public bool Disable
	{
		get
		{
			return state.disableFlag;
		}
		set
		{
			state.disableFlag = value;
		}
	}

	public int Number
	{
		get
		{
			return state.number;
		}
		set
		{
			state.number = value;
		}
	}

	public string CautionText
	{
		get
		{
			return state.cautionText;
		}
		set
		{
			state.cautionText = value;
		}
	}

	public string UsingText
	{
		get
		{
			return state.usingText;
		}
		set
		{
			state.usingText = value;
		}
	}

	public bool IgnoreUnknown
	{
		get
		{
			return state.igonreUnknown;
		}
		set
		{
			state.igonreUnknown = value;
		}
	}

	public bool ForceUnknown
	{
		get
		{
			return state.forceUnknown;
		}
		set
		{
			state.forceUnknown = value;
		}
	}

	public long ID => (m_data == null) ? (-1L) : m_data.id;

	public UISprite baseBg
	{
		get
		{
			object result;
			if (!m_baseBg)
			{
				if (!window)
				{
					result = null;
					goto IL_003d;
				}
				m_baseBg = window.GetComponent<UISprite>();
			}
			result = m_baseBg;
			goto IL_003d;
			IL_003d:
			return (UISprite)result;
		}
	}

	public bool Select
	{
		get
		{
			return (!selectAreaBase) ? _select : selectAreaBase.activeSelf;
		}
		set
		{
			if ((bool)selectAreaBase)
			{
				selectAreaBase.SetActive(value);
			}
			_select = value;
		}
	}

	private GameObject _selectFrame
	{
		get
		{
			if (!selectFrame)
			{
				selectFrame = getOption(0);
			}
			return selectFrame;
		}
	}

	private UISprite _selectNoSprite
	{
		get
		{
			if (!selectNoSprite && (bool)_selectFrame)
			{
				selectNoSprite = UIBasicUtility.GetTargetChild<UISprite>(_selectFrame.transform, "6 No");
			}
			return selectNoSprite;
		}
	}

	public int SelectNo
	{
		get
		{
			return m_selectNo;
		}
		set
		{
			m_selectNo = value;
			if (0 < value)
			{
				if ((bool)_selectFrame)
				{
					_selectFrame.SetActive(value: true);
				}
				if ((bool)_selectNoSprite)
				{
					_selectNoSprite.gameObject.SetActive(value: true);
					_selectNoSprite.spriteName = "icon_edit_num" + value;
				}
			}
			else if ((bool)selectFrame)
			{
				UnityEngine.Object.Destroy(_selectFrame);
			}
		}
	}

	public bool Focus
	{
		get
		{
			return canFocus && focusAreaBase != null && focusAreaBase.activeSelf;
		}
		set
		{
			if (!canFocus)
			{
				return;
			}
			if (focusAreaBase == null)
			{
				focusAreaBase = getOption(1);
				if (focusAreaBase != null)
				{
					focusAreaBase.transform.localPosition = focusAreaBase.transform.localPosition + focusOffset;
				}
			}
			if (focusAreaBase != null)
			{
				focusAreaBase.SetActive(value);
				if (!value)
				{
					UnityEngine.Object.DestroyImmediate(focusAreaBase);
					focusAreaBase = null;
				}
			}
		}
	}

	public Vector3 ItemScale
	{
		get
		{
			return itemScale;
		}
		set
		{
			itemScale = value;
		}
	}

	public UIListItem()
	{
		_state = new State();
		itemScale = new Vector3(128f, 128f, 0f);
		copyState = new CopyState();
		canFocus = true;
		focusOffset = Vector3.zero;
	}

	public virtual void DestroyLevel()
	{
		UnityEngine.Object.Destroy(GetLevelObject());
		RemoveAlphaTargets("LevelText");
	}

	public GameObject GetLevelObject()
	{
		return ExtensionsModule.FindChild(gameObject, "LevelText");
	}

	public virtual void DestroyPlus()
	{
		UnityEngine.Object.Destroy(GetPlusObject());
		RemoveAlphaTargets("PlusText");
	}

	public GameObject GetPlusObject()
	{
		return ExtensionsModule.FindChild(gameObject, "PlusText");
	}

	public void RemoveAlphaTargets(string n)
	{
		if (alphaTargets == null || 0 >= alphaTargets.Length)
		{
			return;
		}
		System.Collections.Generic.List<AlphaLoopCtrl> list = new System.Collections.Generic.List<AlphaLoopCtrl>(alphaTargets);
		int num = 0;
		int length = alphaTargets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			AlphaLoopCtrl[] array = alphaTargets;
			AlphaLoopCtrl alphaLoopCtrl = array[RuntimeServices.NormalizeArrayIndex(array, num2)];
			if (alphaLoopCtrl != null)
			{
				alphaLoopCtrl.DeleteTarget(n);
				if (alphaLoopCtrl.IsBlank)
				{
					list.Remove(alphaLoopCtrl);
				}
			}
		}
		alphaTargets = list.ToArray();
	}

	public void SetFavorite(bool favorite)
	{
		if (favorite)
		{
			SetNew(isNew: false);
			if (!curIconFavoriteSprite)
			{
				favoObject = getOption(2);
				if ((bool)favoObject)
				{
					GameObject targetChild = UIBasicUtility.GetTargetChild(favoObject.transform, "Favorite");
					curIconFavoriteSprite = targetChild.GetComponent<UISprite>();
				}
			}
			if ((bool)favoObject)
			{
				favoObject.SetActive(favorite);
			}
		}
		else if ((bool)curIconFavoriteSprite)
		{
			UnityEngine.Object.Destroy(favoObject);
			curIconFavoriteSprite = null;
		}
	}

	public void SetNew(bool isNew)
	{
		if (!canShowNew)
		{
			return;
		}
		if (isNew)
		{
			if (!curIconNewSprite)
			{
				newObject = getOption(4);
				if ((bool)newObject)
				{
					GameObject targetChild = UIBasicUtility.GetTargetChild(newObject.transform, "New");
					curIconNewSprite = targetChild.GetComponent<UISprite>();
				}
			}
			if ((bool)newObject)
			{
				newObject.SetActive(isNew);
			}
		}
		else if ((bool)curIconNewSprite)
		{
			UnityEngine.Object.Destroy(newObject);
			curIconNewSprite = null;
		}
	}

	public void ShowUsingText(bool use, bool disable)
	{
		Using = use;
		Disable = disable;
		bool num = Using;
		if (!num)
		{
			num = Disable;
		}
		bool show = num;
		string empty = string.Empty;
		if (Using)
		{
			empty = UsingText;
			if (!curIconCautionLabel)
			{
				cautionObject = getOption(3);
				if ((bool)cautionObject)
				{
					GameObject targetChild = UIBasicUtility.GetTargetChild(cautionObject.transform, "UseText");
					curIconCautionLabel = targetChild.GetComponent<UIDynamicFontLabel>();
				}
			}
		}
		else
		{
			empty = CautionText;
			if (string.IsNullOrEmpty(empty) && (bool)curIconCautionLabel)
			{
				UnityEngine.Object.Destroy(cautionObject);
				curIconCautionLabel = null;
			}
		}
		UIBasicUtility.SetLabel(curIconCautionLabel, empty, show);
	}

	public Data GetData()
	{
		return m_data;
	}

	public void SetData(Data d)
	{
		m_data = d;
	}

	public T GetData<T>()
	{
		T result = (T)null;
		if (m_data != null)
		{
			result = m_data.GetData<T>();
		}
		return result;
	}

	public bool IsData<T>()
	{
		return m_data != null && m_data.IsData<T>();
	}

	protected GameObject getOption(int index)
	{
		return (!iconOption) ? null : iconOption.GetObject(index);
	}

	public virtual void Init()
	{
	}

	public void Copy(UIListItem disp)
	{
		if (copyState.copyForDebugCurrentItemPrint)
		{
			forDebugCurrentItemPrint = disp.forDebugCurrentItemPrint;
		}
		if (copyState.copyAutoUsingCheck)
		{
			AutoUsingCheck = disp.AutoUsingCheck;
		}
		if (copyState.copyUsingFlag)
		{
			Using = disp.Using;
		}
		if (copyState.copyFavoriteFlag)
		{
			Favorite = disp.Favorite;
		}
		if (copyState.copyDisableFlag)
		{
			Disable = disp.Disable;
		}
		if (copyState.copyNumber)
		{
			Number = disp.Number;
		}
		if (copyState.copyCautionText)
		{
			CautionText = disp.CautionText;
		}
		if (copyState.copyUsingText)
		{
			UsingText = disp.UsingText;
		}
		if (copyState.copyItemScale)
		{
			ItemScale = disp.ItemScale;
		}
		if (copyState.copyData)
		{
			m_data = disp.m_data;
		}
		if (copyState.copyWindow)
		{
			window = disp.window;
		}
		if (copyState.copyBaseBg)
		{
			m_baseBg = disp.m_baseBg;
		}
		if (copyState.copySelectAreaBase)
		{
			selectAreaBase = disp.selectAreaBase;
		}
		if (copyState.copySelectFrame)
		{
			selectFrame = disp.selectFrame;
		}
		if (copyState.copySelectNoSprite)
		{
			selectNoSprite = disp.selectNoSprite;
		}
		if (copyState.copySelectNo)
		{
			m_selectNo = disp.m_selectNo;
		}
		if (copyState.copyFocusAreaBase)
		{
			focusAreaBase = disp.focusAreaBase;
		}
		if (copyState.copyIconFavoriteSprite)
		{
			curIconFavoriteSprite = disp.curIconFavoriteSprite;
		}
		if (copyState.copyFavoObject)
		{
			favoObject = disp.favoObject;
		}
		if (copyState.copyIconNewSprite)
		{
			curIconNewSprite = disp.curIconNewSprite;
		}
		if (copyState.copyNewObject)
		{
			newObject = disp.newObject;
		}
		if (copyState.copyIconCautionLabel)
		{
			curIconCautionLabel = disp.curIconCautionLabel;
		}
		if (copyState.copyCautionObject)
		{
			cautionObject = disp.cautionObject;
		}
		if (copyState.copyAlphaTarget && disp.alphaTargets != null)
		{
			alphaTargets = new AlphaLoopCtrl[0];
			int i = 0;
			AlphaLoopCtrl[] array = disp.alphaTargets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				alphaTargets = (AlphaLoopCtrl[])RuntimeServices.AddArrays(typeof(AlphaLoopCtrl), alphaTargets, new AlphaLoopCtrl[1] { array[i].Copy() });
			}
		}
	}

	public static void UpdateColorRadian(float delta)
	{
		colorRadian += delta;
	}

	public static void InitAlphaLoopCtrls(UIListItem icon)
	{
		if (!(icon == null))
		{
			AlphaLoopCtrl[] array = new AlphaLoopCtrl[2];
			int num = 0;
			int num2 = 2;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int showTiming = num;
				num++;
				AlphaLoopCtrl alphaLoopCtrl = new AlphaLoopCtrl();
				alphaLoopCtrl.enabled = true;
				alphaLoopCtrl.speed = 3f;
				alphaLoopCtrl.maxAlpha = 10f;
				alphaLoopCtrl.showCycle = 2;
				alphaLoopCtrl.showTiming = showTiming;
				string[] array2 = new string[1];
				string[] array3 = loopItemNames;
				array2[0] = array3[RuntimeServices.NormalizeArrayIndex(array3, showTiming)];
				alphaLoopCtrl.targetNames = array2;
				array[RuntimeServices.NormalizeArrayIndex(array, showTiming)] = alphaLoopCtrl;
			}
			icon.alphaTargets = array;
		}
	}

	private bool HasSomeTargets()
	{
		int result;
		checked
		{
			if (alphaTargets != null && 2 <= alphaTargets.Length)
			{
				int num = 0;
				int i = 0;
				AlphaLoopCtrl[] array = alphaTargets;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null && array[i].Enabled)
					{
						num++;
						if (1 < num)
						{
							break;
						}
					}
				}
				result = ((1 < num) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	public void StartAlphaLoopCtrl()
	{
		if (null == alphaTargets)
		{
			return;
		}
		int i = 0;
		AlphaLoopCtrl[] array = alphaTargets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].Start(gameObject);
			}
		}
	}

	public void UpdateAlphaLoopCtrl()
	{
		if (null == alphaTargets || !HasSomeTargets())
		{
			return;
		}
		int i = 0;
		AlphaLoopCtrl[] array = alphaTargets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].Update();
			}
		}
	}

	public void SetEnableAlphaTargets(string n, bool e)
	{
		if (null == alphaTargets)
		{
			return;
		}
		AlphaLoopCtrl alphaLoopCtrl = null;
		int i = 0;
		AlphaLoopCtrl[] array = alphaTargets;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UIWidget widget = array[i].GetWidget(n);
				if (widget != null)
				{
					array[i].SetEnable(n, e);
					alphaLoopCtrl = array[i];
					break;
				}
			}
		}
		if (alphaLoopCtrl != null && !HasSomeTargets())
		{
			alphaLoopCtrl.Alpha = 1f;
		}
	}
}
