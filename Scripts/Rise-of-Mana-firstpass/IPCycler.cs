using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UIPanel), typeof(UIDraggablePanel))]
[ExecuteInEditMode]
public class IPCycler : MonoBehaviour
{
	public enum Direction
	{
		Vertical,
		Horizontal
	}

	public delegate void CyclerIndexChangeHandler(bool increase, int indexToUpdate);

	public delegate void CyclerStoppedHandler();

	public delegate void SelectionStartedHandler();

	public delegate void CenterOnChildStartedHandler();

	public Direction direction;

	public float spacing = 30f;

	public float dragScale = 1f;

	public float recenterSpeedThreshold = 0.2f;

	public float recenterSpringStrength = 8f;

	public CyclerIndexChangeHandler onCyclerIndexChange;

	public CyclerStoppedHandler onCyclerStopped;

	public SelectionStartedHandler onCyclerSelectionStarted;

	public CenterOnChildStartedHandler onCenterOnChildStarted;

	public Transform[] _cycledTransforms;

	private UIDraggablePanel _draggablePanel;

	private UIPanel _panel;

	private UICenterOnChildManual _uiCenterOnChildManual;

	private BoxCollider _pickerCollider;

	private int _initFrame = -1;

	private int _lastResetFrame = -1;

	private float _decrementThreshold;

	private float _incrementThreshold;

	private float _transformJumpDelta;

	private float _panelSignificantPosVector;

	private float _panelPrevPos;

	private float _deltaPos;

	private Vector4 _initClipRange;

	private Vector3 _resetPosition;

	private bool _isInitialized;

	[SerializeField]
	private bool _isHorizontal;

	[SerializeField]
	private float _trueSpacing;

	public bool IsMoving { get; private set; }

	public int CenterWidgetIndex { get; private set; }

	public int NbOfTransforms => base.transform.childCount;

	public void Init()
	{
		if (_initFrame != Time.frameCount)
		{
			_initFrame = Time.frameCount;
			_draggablePanel = base.gameObject.GetComponent(typeof(UIDraggablePanel)) as UIDraggablePanel;
			_panel = base.gameObject.GetComponent(typeof(UIPanel)) as UIPanel;
			NGUITools.SetActive(base.transform.parent.gameObject, state: true);
			if (_pickerCollider == null)
			{
				_pickerCollider = base.transform.parent.GetComponentInChildren(typeof(BoxCollider)) as BoxCollider;
			}
			if (_pickerCollider != null)
			{
				(_pickerCollider.gameObject.AddComponent(typeof(UIDragPanelContents)) as UIDragPanelContents).draggablePanel = _draggablePanel;
				(_pickerCollider.gameObject.AddComponent(typeof(IPUserInteraction)) as IPUserInteraction).cycler = this;
			}
			else
			{
				Debug.Log("Could not get collider");
			}
			_uiCenterOnChildManual = base.gameObject.AddComponent(typeof(UICenterOnChildManual)) as UICenterOnChildManual;
			_uiCenterOnChildManual.springStrength = recenterSpringStrength;
			_uiCenterOnChildManual.onFinished = PickerStopped;
			ScrollWheelEvents.CheckInstance();
			if (dragScale != 0f)
			{
				_draggablePanel.scale = ((!_isHorizontal) ? new Vector3(0f, dragScale, 0f) : new Vector3(dragScale, 0f, 0f));
			}
			_resetPosition = _panel.cachedTransform.localPosition;
			_initClipRange = _panel.clipRange;
			_panelPrevPos = SignificantPosVector(_panel.cachedTransform);
			_transformJumpDelta = (0f - _trueSpacing) * (float)NbOfTransforms;
			CenterWidgetIndex = NbOfTransforms / 2;
			_decrementThreshold = (0f - _trueSpacing) / 2f;
			_incrementThreshold = _trueSpacing / 2f;
			_deltaPos = 0f;
			_isInitialized = true;
		}
	}

	public void ResetCycler()
	{
		if (_lastResetFrame != Time.frameCount)
		{
			_lastResetFrame = Time.frameCount;
			_panel.cachedTransform.localPosition = _resetPosition;
			_panel.clipRange = _initClipRange;
			_panelPrevPos = SignificantPosVector(_panel.cachedTransform);
			PlaceTransforms();
			CenterWidgetIndex = NbOfTransforms / 2;
			_decrementThreshold = (0f - _trueSpacing) / 2f;
			_incrementThreshold = _trueSpacing / 2f;
			_deltaPos = 0f;
		}
	}

	public void UpdateResetClipRange(Vector4 newRange)
	{
		_initClipRange = newRange;
	}

	private void Update()
	{
		if (!_isInitialized)
		{
			return;
		}
		_panelSignificantPosVector = SignificantPosVector(_panel.cachedTransform);
		if (!Mathf.Approximately(_panelSignificantPosVector, _panelPrevPos))
		{
			IsMoving = true;
			_deltaPos = _panelSignificantPosVector - _panelPrevPos;
			if (_isHorizontal)
			{
				_deltaPos = 0f - _deltaPos;
			}
			if (_deltaPos > 0f)
			{
				while (TryIncrement())
				{
				}
			}
			else
			{
				while (TryDecrement())
				{
				}
			}
		}
		else if (IsMoving)
		{
			IsMoving = false;
			_deltaPos = 0f;
		}
		_panelPrevPos = _panelSignificantPosVector;
	}

	private void PickerStopped()
	{
		if (onCyclerStopped != null)
		{
			onCyclerStopped();
		}
	}

	public void Scroll(float delta)
	{
		_draggablePanel.Scroll(delta);
	}

	public void CenterOnChild()
	{
		_uiCenterOnChildManual.CenterOnChild(_cycledTransforms[CenterWidgetIndex]);
	}

	public void AutoScrollToNextElement()
	{
		int index = (CenterWidgetIndex + 1) % NbOfTransforms;
		AutoScrollToElement(index);
	}

	public void AutoScrollToPreviousElement()
	{
		int num = CenterWidgetIndex - 1;
		if (num < 0)
		{
			num += NbOfTransforms;
		}
		AutoScrollToElement(num);
	}

	private void AutoScrollToElement(int index)
	{
		_uiCenterOnChildManual.CenterOnChild(_cycledTransforms[index]);
	}

	public void OnPress(bool press)
	{
		if (press)
		{
			StopAllCoroutines();
			_uiCenterOnChildManual.Abort();
			if (onCyclerSelectionStarted != null)
			{
				onCyclerSelectionStarted();
			}
		}
		else
		{
			StartCoroutine(RecenterOnThreshold());
		}
	}

	public void ScrollWheelStartOrStop(bool start)
	{
		if (start)
		{
			StopAllCoroutines();
			if (onCyclerSelectionStarted != null)
			{
				onCyclerSelectionStarted();
			}
		}
		else
		{
			StartCoroutine(RecenterOnThreshold());
		}
	}

	private IEnumerator RecenterOnThreshold()
	{
		while (Mathf.Abs(_deltaPos) > recenterSpeedThreshold)
		{
			yield return null;
		}
		_uiCenterOnChildManual.CenterOnChild(_cycledTransforms[CenterWidgetIndex]);
		if (onCenterOnChildStarted != null)
		{
			onCenterOnChildStarted();
		}
	}

	private float SignificantPosVector(Transform trans)
	{
		return (!_isHorizontal) ? trans.localPosition.y : trans.localPosition.x;
	}

	private void SetWidgetSignificantPos(Transform trans, float pos)
	{
		if (!_isHorizontal)
		{
			trans.localPosition = new Vector3(0f, pos, trans.localPosition.z);
		}
		else
		{
			trans.localPosition = new Vector3(pos, 0f, trans.localPosition.z);
		}
	}

	private bool TryIncrement()
	{
		if (_isHorizontal)
		{
			if (!(_panelSignificantPosVector < _incrementThreshold))
			{
				return false;
			}
		}
		else if (!(_panelSignificantPosVector > _incrementThreshold))
		{
			return false;
		}
		_incrementThreshold += _trueSpacing;
		_decrementThreshold += _trueSpacing;
		int firstWidgetIndex;
		Transform trans = FirstWidget(out firstWidgetIndex);
		SetWidgetSignificantPos(trans, SignificantPosVector(trans) + _transformJumpDelta);
		CenterWidgetIndex = (CenterWidgetIndex + 1) % NbOfTransforms;
		if (onCyclerIndexChange != null)
		{
			onCyclerIndexChange(increase: true, firstWidgetIndex);
		}
		return true;
	}

	private bool TryDecrement()
	{
		if (_isHorizontal)
		{
			if (!(_panelSignificantPosVector > _decrementThreshold))
			{
				return false;
			}
		}
		else if (!(_panelSignificantPosVector < _decrementThreshold))
		{
			return false;
		}
		_incrementThreshold -= _trueSpacing;
		_decrementThreshold -= _trueSpacing;
		int lastWidgetIndex;
		Transform trans = LastWidget(out lastWidgetIndex);
		SetWidgetSignificantPos(trans, SignificantPosVector(trans) - _transformJumpDelta);
		CenterWidgetIndex--;
		if (CenterWidgetIndex < 0)
		{
			CenterWidgetIndex += NbOfTransforms;
		}
		if (onCyclerIndexChange != null)
		{
			onCyclerIndexChange(increase: false, lastWidgetIndex);
		}
		return true;
	}

	private Transform FirstWidget(out int firstWidgetIndex)
	{
		firstWidgetIndex = CenterWidgetIndex - NbOfTransforms / 2;
		if (firstWidgetIndex < 0)
		{
			firstWidgetIndex += NbOfTransforms;
		}
		return _cycledTransforms[firstWidgetIndex];
	}

	private Transform LastWidget(out int lastWidgetIndex)
	{
		lastWidgetIndex = (CenterWidgetIndex + NbOfTransforms / 2) % NbOfTransforms;
		return _cycledTransforms[lastWidgetIndex];
	}

	public void EditorInit()
	{
		DestroyChildrenOfChildren();
		if (_cycledTransforms == null || _cycledTransforms.Length != NbOfTransforms)
		{
			_cycledTransforms = new Transform[NbOfTransforms];
		}
		for (int i = 0; i < NbOfTransforms; i++)
		{
			_cycledTransforms[i] = base.transform.GetChild(i);
		}
		UpdateTrueSpacing();
	}

	public void UpdateTrueSpacing()
	{
		_isHorizontal = direction == Direction.Horizontal;
		_trueSpacing = Mathf.Abs(spacing);
		if (_isHorizontal)
		{
			_trueSpacing = 0f - _trueSpacing;
		}
		PlaceTransforms();
	}

	public void PlaceTransforms()
	{
		float num = _trueSpacing * (float)(NbOfTransforms / 2);
		for (int i = 0; i < NbOfTransforms; i++)
		{
			SetWidgetSignificantPos(_cycledTransforms[i], num);
			num -= _trueSpacing;
		}
	}

	public void RebuildTransforms(int newNb)
	{
		int nbOfTransforms = NbOfTransforms;
		if (nbOfTransforms != 0)
		{
			Transform[] array = new Transform[nbOfTransforms];
			for (int i = 0; i < nbOfTransforms; i++)
			{
				array[i] = base.transform.GetChild(i);
			}
			for (int i = 0; i < nbOfTransforms; i++)
			{
				Object.DestroyImmediate(array[i].gameObject);
			}
		}
		_cycledTransforms = new Transform[newNb];
		for (int i = 0; i < newNb; i++)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = base.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.name = i.ToString();
			_cycledTransforms[i] = gameObject.transform;
		}
		PlaceTransforms();
	}

	private void DestroyChildrenOfChildren()
	{
		foreach (Transform item in base.transform)
		{
			Transform[] array = new Transform[item.childCount];
			for (int i = 0; i < item.childCount; i++)
			{
				array[i] = item.GetChild(i);
			}
			for (int j = 0; j < array.Length; j++)
			{
				Object.DestroyImmediate(array[j].gameObject);
			}
		}
	}

	public T[] MakeWidgets<T>() where T : UIWidget
	{
		T[] array = new T[NbOfTransforms];
		for (int i = 0; i < NbOfTransforms; i++)
		{
			array[i] = NGUITools.AddWidget<T>(_cycledTransforms[i].gameObject);
		}
		return array;
	}
}
