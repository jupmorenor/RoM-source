using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class SwipePanel : MonoBehaviour
{
	[Serializable]
	public enum SwipeWrapType
	{
		None,
		Next,
		Prev,
		Both
	}

	[NonSerialized]
	public static float swipeWidth = 1280f;

	[NonSerialized]
	public static bool swipeSmoothStartParam = true;

	[NonSerialized]
	protected static bool lastSwipeSmoothStartParam = true;

	[NonSerialized]
	public static float swipeSpeedScaleParam = 2f;

	[NonSerialized]
	protected static float lastSwipeSpeedScaleParam = 2f;

	[NonSerialized]
	public static float swipeMomentParam = 60f;

	[NonSerialized]
	protected static float lastSwipeMomentParam = 60f;

	[NonSerialized]
	public static float springNextMinXParam = 10f;

	[NonSerialized]
	protected static float lastSpringNextMinXParam = 10f;

	[NonSerialized]
	public static float springStrengthParam = 5f;

	[NonSerialized]
	protected static float lastSpringStrengthParam = 5f;

	[NonSerialized]
	public static float springStartSpeedParam = 2f;

	[NonSerialized]
	protected static float lastSpringStartSpeedParam = 2f;

	[NonSerialized]
	public static float springDelayParam;

	[NonSerialized]
	protected static float lastSpringDelayParam;

	[NonSerialized]
	public static bool unifiedSwipeFunc = true;

	public bool ignoreEditorParam;

	public bool swipeSmoothStart;

	public float swipeSpeedScale;

	public float swipeMoment;

	public float springNextMinX;

	public float springStrength;

	public float springStartSpeed;

	public float springDelay;

	protected float springCurDelay;

	public GameObject[] swipeObjects;

	protected GameObject dummyObject;

	public UIDraggablePanel draggablePanel;

	public SpringPanel dragSpring;

	public int swipeMin;

	public int swipeMax;

	public bool swipeLoop;

	protected bool drag;

	protected bool lastDrag;

	protected float lastDragX;

	protected bool momentMove;

	protected __SwipePanel_updatePanelFunc_0024callable102_002481_24__ updatePanelFunc;

	protected __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ updateIndexFunc;

	protected __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ dragEndFunc;

	public bool isSwapBuffer;

	public SwipeWrapType swipeWrapType;

	private int[] swapBufferIndexes;

	private int targetIndex;

	public bool IsDrag
	{
		get
		{
			bool num = lastDrag;
			if (!num)
			{
				num = drag;
			}
			return num;
		}
	}

	public float LastDragX => lastDragX;

	public static float SwipeWidth => swipeWidth;

	public static bool SwipeSmoothStart
	{
		get
		{
			return swipeSmoothStartParam;
		}
		set
		{
			swipeSmoothStartParam = value;
		}
	}

	public static float SwipeSpeedScale
	{
		get
		{
			return swipeSpeedScaleParam;
		}
		set
		{
			swipeSpeedScaleParam = value;
		}
	}

	public static float SwipeMoment
	{
		get
		{
			return swipeMomentParam;
		}
		set
		{
			swipeMomentParam = value;
		}
	}

	public static float SpringNextMinX
	{
		get
		{
			return springNextMinXParam;
		}
		set
		{
			springNextMinXParam = value;
		}
	}

	public static float SpringStrength
	{
		get
		{
			return springStrengthParam;
		}
		set
		{
			springStrengthParam = value;
		}
	}

	public static float SpringStartSpeed
	{
		get
		{
			return springStartSpeedParam;
		}
		set
		{
			springStartSpeedParam = value;
		}
	}

	public static float SpringDelay
	{
		get
		{
			return springDelayParam;
		}
		set
		{
			springDelayParam = value;
		}
	}

	public static bool UnifiedSwipeFunc
	{
		get
		{
			return unifiedSwipeFunc;
		}
		set
		{
			unifiedSwipeFunc = value;
		}
	}

	public SwipePanel()
	{
		ignoreEditorParam = true;
		swipeSmoothStart = swipeSmoothStartParam;
		swipeSpeedScale = swipeSpeedScaleParam;
		swipeMoment = swipeMomentParam;
		springNextMinX = springNextMinXParam;
		springStrength = springStrengthParam;
		springStartSpeed = springStartSpeedParam;
		springDelay = springDelayParam;
		springCurDelay = -1f;
		swipeMax = 5;
		swipeWrapType = SwipeWrapType.None;
		targetIndex = -1;
	}

	public void Start()
	{
		if (!draggablePanel)
		{
			draggablePanel = gameObject.GetComponent<UIDraggablePanel>();
		}
		if (!dragSpring)
		{
			dragSpring = gameObject.GetComponent<SpringPanel>();
		}
	}

	public void Init(GameObject[] objs, int max, __SwipePanel_updatePanelFunc_0024callable102_002481_24__ panelFunc, __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ indexFunc, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endFunc)
	{
		if (objs != null)
		{
			swipeObjects = objs;
		}
		swipeMax = max;
		updatePanelFunc = panelFunc;
		updateIndexFunc = indexFunc;
		dragEndFunc = endFunc;
		if (swipeObjects.Length == 2)
		{
			swapBufferIndexes = new int[2] { -1, -1 };
		}
	}

	public void Reset()
	{
		drag = false;
		lastDrag = false;
		if ((bool)draggablePanel)
		{
			float x = 0f;
			Vector3 localPosition = draggablePanel.transform.localPosition;
			float num = (localPosition.x = x);
			Vector3 vector2 = (draggablePanel.transform.localPosition = localPosition);
		}
		if ((bool)dragSpring)
		{
			dragSpring.target.x = 0f;
			dragSpring.enabled = true;
		}
	}

	public void SetupParam()
	{
		if (ignoreEditorParam)
		{
			swipeSmoothStart = swipeSmoothStartParam;
			swipeSpeedScale = swipeSpeedScaleParam;
			swipeMoment = swipeMomentParam;
			springNextMinX = springNextMinXParam;
			springStrength = springStrengthParam;
			springStartSpeed = springStartSpeedParam;
			springDelay = springDelayParam;
		}
		if (springStrengthParam != lastSpringStrengthParam)
		{
			springStrength = springStrengthParam;
			lastSpringStrengthParam = springStrengthParam;
		}
		else
		{
			springStrengthParam = springStrength;
			lastSpringStrengthParam = springStrengthParam;
		}
		if (springStartSpeedParam != lastSpringStartSpeedParam)
		{
			springStartSpeed = springStartSpeedParam;
			lastSpringStartSpeedParam = springStartSpeedParam;
		}
		else
		{
			springStartSpeedParam = springStartSpeed;
			lastSpringStartSpeedParam = springStartSpeedParam;
		}
		if (springDelayParam != lastSpringDelayParam)
		{
			springDelay = springDelayParam;
			lastSpringDelayParam = springDelayParam;
		}
		else
		{
			springDelayParam = springDelay;
			lastSpringDelayParam = springDelayParam;
		}
		if (springNextMinXParam != lastSpringNextMinXParam)
		{
			springNextMinX = springNextMinXParam;
			lastSpringNextMinXParam = springNextMinXParam;
		}
		else
		{
			springNextMinXParam = springNextMinX;
			lastSpringNextMinXParam = springNextMinXParam;
		}
		if (swipeSpeedScaleParam != lastSwipeSpeedScaleParam)
		{
			swipeSpeedScale = swipeSpeedScaleParam;
			lastSwipeSpeedScaleParam = swipeSpeedScaleParam;
		}
		else
		{
			swipeSpeedScaleParam = swipeSpeedScale;
			lastSwipeSpeedScaleParam = swipeSpeedScaleParam;
		}
		if (swipeSmoothStartParam != lastSwipeSmoothStartParam)
		{
			swipeSmoothStart = swipeSmoothStartParam;
			lastSwipeSmoothStartParam = swipeSmoothStartParam;
		}
		else
		{
			swipeSmoothStartParam = swipeSmoothStart;
			lastSwipeSmoothStartParam = swipeSmoothStartParam;
		}
		if (swipeMomentParam != lastSwipeMomentParam)
		{
			swipeMoment = swipeMomentParam;
			lastSwipeMomentParam = swipeMomentParam;
		}
		else
		{
			swipeMomentParam = swipeMoment;
			lastSwipeMomentParam = swipeMomentParam;
		}
	}

	public void SwipeCtrl(int curIndex, int curObjectIndex)
	{
		drag = false;
		int num = 0;
		bool flag = true;
		if (!SceneChanger.isCompletelyReady)
		{
			flag = false;
		}
		if (!dragSpring)
		{
			flag = false;
		}
		if (!draggablePanel)
		{
			flag = false;
		}
		if (swipeObjects == null)
		{
			flag = false;
		}
		if (curObjectIndex < 0)
		{
			flag = false;
		}
		if (curObjectIndex > 1)
		{
			flag = false;
		}
		checked
		{
			if (flag)
			{
				SetupParam();
				bool flag2 = lastDrag;
				bool flag3 = false;
				GameObject[] array = swipeObjects;
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, curObjectIndex)];
				GameObject[] array2 = swipeObjects;
				dummyObject = array2[RuntimeServices.NormalizeArrayIndex(array2, 1 - curObjectIndex)];
				num = (int)draggablePanel.transform.localPosition.x;
				float x = draggablePanel.currentMomentum.x;
				draggablePanel.momentumAmount = swipeMoment;
				draggablePanel.smoothDragStart = swipeSmoothStart;
				draggablePanel.scale.x = swipeSpeedScale;
				dragSpring.strength = springStrength;
				if (x != 0f || num != 0)
				{
					flag3 = true;
				}
				if (!draggablePanel.Pressed)
				{
					if (!(springCurDelay >= 0f))
					{
						springCurDelay = springDelay;
					}
				}
				else
				{
					springCurDelay = -1f;
					dragSpring.enabled = false;
				}
				if (!(springCurDelay < 0f))
				{
					springCurDelay -= Time.deltaTime;
					if (!(springCurDelay >= 0f))
					{
						dragSpring.enabled = true;
					}
				}
				bool flag4 = false;
				if (!isSwapBuffer)
				{
					flag4 = true;
				}
				if (unifiedSwipeFunc)
				{
					flag4 = true;
				}
				if (flag4)
				{
					if (flag3 || dragSpring.enabled || !(springCurDelay < 0f))
					{
						if (!((float)num >= 0f))
						{
							drag = true;
							if (!swipeLoop && targetIndex >= swipeMax - 1)
							{
								float x2 = 100000f;
								Vector3 localPosition = dummyObject.transform.localPosition;
								float num2 = (localPosition.x = x2);
								Vector3 vector2 = (dummyObject.transform.localPosition = localPosition);
							}
							else
							{
								bool flag5 = false;
								if (!lastDrag || !(lastDragX < 0f))
								{
									targetIndex = curIndex;
									float x3 = swipeWidth;
									Vector3 localPosition2 = dummyObject.transform.localPosition;
									float num3 = (localPosition2.x = x3);
									Vector3 vector4 = (dummyObject.transform.localPosition = localPosition2);
									updatePanelFunc(dummyObject, curIndex + 1);
									dragSpring.target.x = 0f;
									gameObject.gameObject.SetActive(value: true);
									dummyObject.gameObject.SetActive(value: true);
								}
								else if (!((float)num > 0f - swipeWidth * 0.5f) && !(lastDragX <= 0f - swipeWidth * 0.5f))
								{
									if (updateIndexFunc != null)
									{
										updateIndexFunc(curIndex + 1);
									}
									dragSpring.target.x = 0f - swipeWidth;
									flag5 = true;
								}
								else if (!((float)num <= 0f - swipeWidth * 0.5f) && !(lastDragX > 0f - swipeWidth * 0.5f))
								{
									if (updateIndexFunc != null)
									{
										updateIndexFunc(curIndex - 1);
									}
									dragSpring.target.x = 0f;
									flag5 = true;
								}
								else if (!((float)num > 0f - swipeWidth) && !(lastDragX <= 0f - swipeWidth))
								{
									targetIndex = curIndex;
									if (updatePanelFunc != null)
									{
										updatePanelFunc(gameObject, curIndex);
									}
									if (updatePanelFunc != null)
									{
										updatePanelFunc(dummyObject, curIndex + 1);
									}
									dragSpring.target.x = 0f;
									gameObject.gameObject.SetActive(value: true);
									dummyObject.gameObject.SetActive(value: true);
									float x4 = swipeWidth;
									Vector3 localPosition3 = dummyObject.transform.localPosition;
									float num4 = (localPosition3.x = x4);
									Vector3 vector6 = (dummyObject.transform.localPosition = localPosition3);
									float x5 = draggablePanel.transform.localPosition.x + swipeWidth;
									Vector3 localPosition4 = draggablePanel.transform.localPosition;
									float num5 = (localPosition4.x = x5);
									Vector3 vector8 = (draggablePanel.transform.localPosition = localPosition4);
									num = (int)((float)num + swipeWidth);
								}
								if ((!flag5 && !((float)num > 0f - springNextMinX) && !((float)num <= 0f - (swipeWidth - springNextMinX)) && !dragSpring.enabled) || draggablePanel.Pressed)
								{
									if (!((float)num >= lastDragX))
									{
										dragSpring.target.x = 0f - swipeWidth;
									}
									if (!((float)num <= lastDragX))
									{
										dragSpring.target.x = 0f;
									}
								}
							}
						}
						else if (!((float)num <= 0f))
						{
							drag = true;
							if (!swipeLoop && targetIndex <= swipeMin)
							{
								float x6 = 100000f;
								Vector3 localPosition5 = dummyObject.transform.localPosition;
								float num6 = (localPosition5.x = x6);
								Vector3 vector10 = (dummyObject.transform.localPosition = localPosition5);
							}
							else
							{
								bool flag5 = false;
								if (!lastDrag || !(lastDragX > 0f))
								{
									targetIndex = curIndex;
									float x7 = 0f - swipeWidth;
									Vector3 localPosition6 = dummyObject.transform.localPosition;
									float num7 = (localPosition6.x = x7);
									Vector3 vector12 = (dummyObject.transform.localPosition = localPosition6);
									if (updatePanelFunc != null)
									{
										updatePanelFunc(dummyObject, curIndex - 1);
									}
									dragSpring.target.x = 0f;
									gameObject.gameObject.SetActive(value: true);
									dummyObject.gameObject.SetActive(value: true);
								}
								else if (!((float)num < swipeWidth * 0.5f) && !(lastDragX >= swipeWidth * 0.5f))
								{
									if (updateIndexFunc != null)
									{
										updateIndexFunc(curIndex - 1);
									}
									dragSpring.target.x = swipeWidth;
									flag5 = true;
								}
								else if (!((float)num >= swipeWidth * 0.5f) && !(lastDragX < swipeWidth * 0.5f))
								{
									if (updateIndexFunc != null)
									{
										updateIndexFunc(curIndex + 1);
									}
									dragSpring.target.x = 0f;
									flag5 = true;
								}
								else if (!((float)num < swipeWidth) && !(lastDragX >= swipeWidth))
								{
									targetIndex = curIndex;
									if (updatePanelFunc != null)
									{
										updatePanelFunc(gameObject, curIndex);
									}
									if (updatePanelFunc != null)
									{
										updatePanelFunc(dummyObject, curIndex - 1);
									}
									dragSpring.target.x = 0f;
									gameObject.gameObject.SetActive(value: true);
									dummyObject.gameObject.SetActive(value: true);
									float x8 = 0f - swipeWidth;
									Vector3 localPosition7 = dummyObject.transform.localPosition;
									float num8 = (localPosition7.x = x8);
									Vector3 vector14 = (dummyObject.transform.localPosition = localPosition7);
									float x9 = draggablePanel.transform.localPosition.x - swipeWidth;
									Vector3 localPosition8 = draggablePanel.transform.localPosition;
									float num9 = (localPosition8.x = x9);
									Vector3 vector16 = (draggablePanel.transform.localPosition = localPosition8);
									num = (int)((float)num - swipeWidth);
								}
								if ((!flag5 && !((float)num < springNextMinX) && !((float)num >= swipeWidth - springNextMinX) && !dragSpring.enabled) || draggablePanel.Pressed)
								{
									if (!((float)num >= lastDragX))
									{
										dragSpring.target.x = 0f;
									}
									if (!((float)num <= lastDragX))
									{
										dragSpring.target.x = swipeWidth;
									}
								}
							}
						}
					}
					if (!drag)
					{
						targetIndex = curIndex;
					}
				}
				else
				{
					bool flag6 = _hasTargetIndex();
					curIndex = _getIndexFromScrollX(num, aTrim: false);
					if (flag6)
					{
						if (curIndex == targetIndex)
						{
							_clearTargetIndex();
							flag6 = false;
						}
					}
					else
					{
						x = (float)num - lastDragX;
						int num10 = _getIndexFromScrollX((float)num - x, aTrim: false);
						if (curIndex != num10 && _isValidIndex(curIndex) && updateIndexFunc != null)
						{
							updateIndexFunc(curIndex);
						}
					}
					float num11 = _getTargetX(curIndex);
					bool flag7 = _updateSwapBufferIndex(curIndex);
					if (flag3 || dragSpring.enabled || !(springCurDelay < 0f))
					{
						drag = true;
						if (!flag6)
						{
							dragSpring.target.x = num11;
						}
						if (!((float)num >= num11))
						{
							int num12 = _getNextIndex(curIndex);
							if (num12 < swipeMax)
							{
								_updateSwapBufferIndex(num12);
							}
						}
						else if (!(num11 >= (float)num))
						{
							int num13 = _getPrevIndex(curIndex);
							if (0 <= num13)
							{
								_updateSwapBufferIndex(num13);
							}
						}
					}
				}
				if (!drag && lastDrag && dragEndFunc != null)
				{
					dragEndFunc();
				}
			}
			lastDrag = drag;
			lastDragX = num;
		}
	}

	public void setTargetIndex(int aIndex)
	{
		if (!(draggablePanel == null))
		{
			float x = draggablePanel.transform.localPosition.x;
			int num = _getIndexFromScrollX(x, aTrim: false);
			if (aIndex != num)
			{
				targetIndex = aIndex;
				float x2 = _getTargetX(aIndex);
				dragSpring.target.x = x2;
			}
		}
	}

	public Vector3 getTargetPositionFromSbIndex(int aSbIndex)
	{
		float x = 0f;
		int[] array = swapBufferIndexes;
		int aIndex = array[RuntimeServices.NormalizeArrayIndex(array, aSbIndex)];
		if (_isValidIndex(aIndex))
		{
			x = _getTargetX(aIndex);
		}
		return new Vector3(x, 0f, 0f);
	}

	private bool _isValidIndex(int aIndex)
	{
		bool result = false;
		if (0 <= aIndex && aIndex < swipeMax)
		{
			result = true;
		}
		return result;
	}

	private void _clearTargetIndex()
	{
		targetIndex = -1;
	}

	private bool _hasTargetIndex()
	{
		bool result = false;
		if (0 <= targetIndex)
		{
			result = true;
		}
		return result;
	}

	private bool _updateSwapBufferIndex(int aIndex)
	{
		bool result = false;
		if (_isValidIndex(aIndex))
		{
			int length = swapBufferIndexes.Length;
			int index = aIndex % length;
			int[] array = swapBufferIndexes;
			int num = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (num != aIndex)
			{
				int[] array2 = swapBufferIndexes;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = aIndex;
				if (updatePanelFunc != null)
				{
					_updateSwipeObjectPositionFromIndex(aIndex);
					_updatePanelFunc(aIndex, true);
					result = true;
				}
			}
		}
		return result;
	}

	private void _updatePanelFunc(int aIndex, object aUpdateBuffer)
	{
		int length = swapBufferIndexes.Length;
		int index = aIndex % length;
		if (RuntimeServices.ToBool(aUpdateBuffer))
		{
			int[] array = swapBufferIndexes;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = aIndex;
		}
		__SwipePanel_updatePanelFunc_0024callable102_002481_24__ _SwipePanel_updatePanelFunc_0024callable102_002481_24__ = updatePanelFunc;
		GameObject[] array2 = swipeObjects;
		_SwipePanel_updatePanelFunc_0024callable102_002481_24__(array2[RuntimeServices.NormalizeArrayIndex(array2, index)], aIndex);
	}

	private int _getNextIndex(int aIndex)
	{
		return _getAddIndex(aIndex, 1);
	}

	private int _getPrevIndex(int aIndex)
	{
		return _getAddIndex(aIndex, -1);
	}

	private int _getAddIndex(int aIndex, int aAdd)
	{
		int aIndex2 = checked(aIndex + aAdd);
		return _trimIndex(aIndex2);
	}

	private int _trimIndex(int aIndex)
	{
		int num = aIndex;
		if (num < 0)
		{
			num = (((swipeWrapType & SwipeWrapType.Prev) != 0) ? (num % swipeMax) : 0);
		}
		else if (swipeMax <= num)
		{
			num = (((swipeWrapType & SwipeWrapType.Next) == 0) ? checked(swipeMax - 1) : (num % swipeMax));
		}
		return num;
	}

	private int _getIndexFromScrollX(float aX, bool aTrim)
	{
		float num = aX - swipeWidth * 0.5f;
		int num2 = checked((int)(0f - num / swipeWidth));
		if (aTrim)
		{
			num2 = _trimIndex(num2);
		}
		return num2;
	}

	private float _getTargetX(int aIndex)
	{
		int num = _trimIndex(aIndex);
		return (0f - swipeWidth) * (float)num;
	}

	private GameObject _getSwipeObject(int aIndex, bool aTrim)
	{
		GameObject result = null;
		if (aTrim)
		{
			int num = _trimIndex(aIndex);
			if (0 <= num)
			{
				int index = num % swipeObjects.Length;
				GameObject[] array = swipeObjects;
				result = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			}
		}
		else
		{
			int index = aIndex % swipeObjects.Length;
			GameObject[] array2 = swipeObjects;
			result = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
		}
		return result;
	}

	private void _updateSwipeObjectPositionFromIndex(int aIndex)
	{
		if (_isValidIndex(aIndex))
		{
			GameObject gameObject = _getSwipeObject(aIndex, aTrim: false);
			float num = 0f;
			num = (float)aIndex * swipeWidth;
			float x = num;
			Vector3 localPosition = gameObject.transform.localPosition;
			float num2 = (localPosition.x = x);
			Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
		}
	}
}
