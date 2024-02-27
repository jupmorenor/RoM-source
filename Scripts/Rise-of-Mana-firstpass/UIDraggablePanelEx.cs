using UnityEngine;

public class UIDraggablePanelEx : MonoBehaviour
{
	public enum Direction
	{
		vertical,
		horizontal
	}

	public GameObject target;

	public Vector2 offset;

	private UIDraggablePanel dragPanel;

	private UIPanel mPanel;

	private UIDragPanelContents[] dragCont;

	public GameObject selectObject;

	public bool keepVertSizeRate = true;

	public float vertRate;

	public bool keepHorzSizeRate = true;

	public float horzRate;

	private BoxCollider boxCol;

	public int dragEndReCheckWait = 100;

	private int reCheckWait;

	private bool reCheckFlag;

	private SpringPanel spring;

	public Direction direction;

	public UIDragPanelContents[] ItemList => dragCont;

	public GameObject SelectObject
	{
		get
		{
			return selectObject;
		}
		set
		{
			selectObject = value;
			RestrictWithinBounds(move: true, selectObject, spring: false);
		}
	}

	public void Start()
	{
		spring = base.gameObject.GetComponent<SpringPanel>();
		mPanel = GetComponent<UIPanel>();
		dragPanel = GetComponent<UIDraggablePanel>();
		boxCol = GetComponent<BoxCollider>();
		if ((bool)mPanel)
		{
			if (horzRate == 0f)
			{
				horzRate = mPanel.clipRange.z / (float)Screen.width;
			}
			if (vertRate == 0f)
			{
				vertRate = mPanel.clipRange.w / (float)Screen.height;
			}
		}
		if ((bool)dragPanel)
		{
			dragPanel.onDragFinished = OnDragFinished;
			dragPanel.restrictWithinPanel = false;
			dragPanel.dragEffect = UIDraggablePanel.DragEffect.MomentumAndSpring;
			if (direction == Direction.vertical)
			{
				dragPanel.Scroll(0f - offset.y);
			}
			else
			{
				dragPanel.Scroll(0f - offset.x);
			}
		}
		InitListItem();
	}

	public void Update()
	{
		spring = base.gameObject.GetComponent<SpringPanel>();
		if ((bool)spring)
		{
			if (reCheckWait > 0)
			{
				reCheckFlag = false;
				reCheckWait--;
				if (reCheckWait == 0)
				{
					reCheckFlag = true;
				}
			}
			if (!spring.enabled && reCheckFlag)
			{
				reCheckFlag = false;
				RestrictWithinBounds(move: true);
			}
		}
		if ((bool)dragPanel)
		{
			dragPanel.disableDragIfFits = false;
			if ((bool)boxCol)
			{
				boxCol.center = new Vector3(mPanel.clipRange.x, mPanel.clipRange.y, boxCol.center.z);
				boxCol.size = new Vector3(mPanel.clipRange.z, mPanel.clipRange.w, 1f);
			}
		}
		if ((bool)mPanel)
		{
			Vector4 clipRange = mPanel.clipRange;
			if (horzRate >= 0f)
			{
				clipRange.z = horzRate * (float)Screen.width;
			}
			if (vertRate >= 0f)
			{
				clipRange.w = vertRate * (float)Screen.height;
			}
		}
	}

	public void InitListItem()
	{
		dragCont = base.gameObject.GetComponentsInChildren<UIDragPanelContents>();
		for (int i = 0; i < dragCont.Length; i++)
		{
			if ((bool)dragCont[i])
			{
				dragCont[i].draggablePanel = dragPanel;
			}
		}
		RestrictWithinBounds(move: true, null, spring: false);
	}

	public void OnDragFinished()
	{
		reCheckWait = dragEndReCheckWait;
		RestrictWithinBounds(move: true);
	}

	private void OnPress(bool pressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && dragPanel != null)
		{
			dragPanel.Press(pressed);
			if (pressed && (bool)spring)
			{
				spring.enabled = false;
			}
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && dragPanel != null)
		{
			dragPanel.Drag();
		}
	}

	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && dragPanel != null)
		{
			dragPanel.Scroll(delta);
		}
	}

	public bool DisplaySelect()
	{
		if (selectObject == null)
		{
			return false;
		}
		return true;
	}

	public float SpringList(Vector3 constraint, float pow = 13f)
	{
		constraint.z = dragPanel.transform.localPosition.z;
		float num = 0f;
		if (direction == Direction.vertical)
		{
			constraint.x = dragPanel.transform.localPosition.x;
			constraint.y -= offset.y;
			num = dragPanel.transform.localPosition.y - constraint.y;
		}
		else
		{
			constraint.y = dragPanel.transform.localPosition.y;
			constraint.x -= offset.x;
			num = dragPanel.transform.localPosition.x - constraint.x;
		}
		SpringPanel.Begin(dragPanel.gameObject, constraint, pow);
		return num;
	}

	public void UpdateColor()
	{
		for (int i = 0; i < dragCont.Length; i++)
		{
			if (!(dragCont[i] == null))
			{
				if (dragCont[i].gameObject == selectObject)
				{
					TweenColor.Begin(dragCont[i].gameObject, 0.1f, new Color(1f, 1f, 1f, 1f));
				}
				else
				{
					TweenColor.Begin(dragCont[i].gameObject, 0.1f, new Color(0.5f, 0.5f, 0.5f, 1f));
				}
			}
		}
	}

	public bool RestrictWithinBounds(bool move, GameObject newSelect = null, bool spring = true)
	{
		if (dragCont == null)
		{
			return false;
		}
		if (dragPanel == null)
		{
			return false;
		}
		bool result = false;
		int num = -1;
		float num2 = 0f;
		Vector3 position = new Vector3(0f, 0f, 0f);
		Vector3 vector = new Vector3(0f, 0f, 0f);
		selectObject = null;
		vector = ((!(target != null)) ? base.transform.position : target.transform.position);
		for (int i = 0; i < dragCont.Length; i++)
		{
			if (!(dragCont[i] == null) && (!newSelect || !(dragCont[i].gameObject != newSelect)))
			{
				Vector3 position2 = dragCont[i].transform.position;
				position2 -= vector;
				float magnitude = position2.magnitude;
				if (num == -1)
				{
					num = i;
					num2 = magnitude;
					position = position2;
				}
				else if (magnitude < num2)
				{
					num2 = magnitude;
					num = i;
					position = position2;
				}
			}
		}
		if (num >= 0)
		{
			selectObject = dragCont[num].gameObject;
			Vector3 constraint = -dragPanel.transform.InverseTransformPoint(position);
			if (move)
			{
				if (spring)
				{
					SpringList(constraint);
				}
				else
				{
					SpringList(constraint, 1000f);
				}
				result = true;
			}
		}
		UpdateColor();
		return result;
	}
}
