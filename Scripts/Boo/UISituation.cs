using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class UISituation : MonoBehaviour
{
	public string title;

	public string help;

	public bool ignoreTimeScale;

	public float tweenInTimeLimit;

	public float tweenOutTimeLimit;

	public bool showBg;

	public GameObject bg;

	public bool previewMode;

	private bool m_forward;

	private bool finished_initialize;

	private List<UIAutoTweener> runTweenerList;

	private __UISituation_forwardAnimationDelegateList_0024callable109_002432_50__ _0024event_0024forwardAnimationDelegateList;

	private __UISituation_forwardAnimationDelegateList_0024callable109_002432_50__ _0024event_0024backAnimationDelegateList;

	private __UISituation_stopAnimationDelegateList_0024callable110_002434_47__ _0024event_0024stopAnimationDelegateList;

	public bool isPlayingAnimation
	{
		get
		{
			bool flag;
			foreach (UIAutoTweener runTweener in runTweenerList)
			{
				if (!(null != runTweener) || !runTweener.gameObject.activeSelf || !runTweener.isPlayingAnimation)
				{
					continue;
				}
				flag = true;
				goto IL_0067;
			}
			int result = 0;
			goto IL_0068;
			IL_0067:
			result = (flag ? 1 : 0);
			goto IL_0068;
			IL_0068:
			return (byte)result != 0;
		}
	}

	public event __UISituation_forwardAnimationDelegateList_0024callable109_002432_50__ forwardAnimationDelegateList
	{
		add
		{
			_0024event_0024forwardAnimationDelegateList = (__UISituation_forwardAnimationDelegateList_0024callable109_002432_50__)Delegate.Combine(_0024event_0024forwardAnimationDelegateList, value);
		}
		remove
		{
			_0024event_0024forwardAnimationDelegateList = (__UISituation_forwardAnimationDelegateList_0024callable109_002432_50__)Delegate.Remove(_0024event_0024forwardAnimationDelegateList, value);
		}
	}

	public event __UISituation_forwardAnimationDelegateList_0024callable109_002432_50__ backAnimationDelegateList
	{
		add
		{
			_0024event_0024backAnimationDelegateList = (__UISituation_forwardAnimationDelegateList_0024callable109_002432_50__)Delegate.Combine(_0024event_0024backAnimationDelegateList, value);
		}
		remove
		{
			_0024event_0024backAnimationDelegateList = (__UISituation_forwardAnimationDelegateList_0024callable109_002432_50__)Delegate.Remove(_0024event_0024backAnimationDelegateList, value);
		}
	}

	public event __UISituation_stopAnimationDelegateList_0024callable110_002434_47__ stopAnimationDelegateList
	{
		add
		{
			_0024event_0024stopAnimationDelegateList = (__UISituation_stopAnimationDelegateList_0024callable110_002434_47__)Delegate.Combine(_0024event_0024stopAnimationDelegateList, value);
		}
		remove
		{
			_0024event_0024stopAnimationDelegateList = (__UISituation_stopAnimationDelegateList_0024callable110_002434_47__)Delegate.Remove(_0024event_0024stopAnimationDelegateList, value);
		}
	}

	public UISituation()
	{
		showBg = true;
		runTweenerList = new List<UIAutoTweener>();
	}

	[SpecialName]
	protected internal void raise_forwardAnimationDelegateList(UISituation arg0, bool arg1)
	{
		_0024event_0024forwardAnimationDelegateList?.Invoke(arg0, arg1);
	}

	[SpecialName]
	protected internal void raise_backAnimationDelegateList(UISituation arg0, bool arg1)
	{
		_0024event_0024backAnimationDelegateList?.Invoke(arg0, arg1);
	}

	[SpecialName]
	protected internal void raise_stopAnimationDelegateList(UISituation arg0)
	{
		_0024event_0024stopAnimationDelegateList?.Invoke(arg0);
	}

	public static void Activate(UISituation situation, bool activate)
	{
		NGUITools.SetActive(situation.gameObject, activate);
		if (activate)
		{
			situation.Prepare();
		}
	}

	public static UISituation Find(Transform trans)
	{
		UISituation uISituation = null;
		while (uISituation == null && trans != null)
		{
			uISituation = trans.GetComponent<UISituation>();
			if (uISituation != null || trans.parent == null)
			{
				break;
			}
			trans = trans.parent;
		}
		return uISituation;
	}

	public void OnEnable()
	{
		if (previewMode)
		{
			Prepare();
		}
	}

	private void Prepare()
	{
		if (!finished_initialize)
		{
			InitTween();
		}
	}

	public void InitTween()
	{
		UIAutoTweener[] componentsInChildren = gameObject.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
		if (componentsInChildren != null)
		{
			int i = 0;
			UIAutoTweener[] array = componentsInChildren;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!array[i].isStandAlone)
				{
					array[i].ignoreTimeScale = ignoreTimeScale;
					array[i].Initialize(this);
				}
			}
		}
		finished_initialize = true;
	}

	public float GetLimit(bool forward)
	{
		return (!forward) ? tweenOutTimeLimit : tweenInTimeLimit;
	}

	public void PlayAnimation(bool forward)
	{
		m_forward = forward;
		if (forward)
		{
			Activate(this, activate: true);
			runTweenerList.Clear();
			raise_forwardAnimationDelegateList(this, forward);
		}
		else if (beAnimation(_0024event_0024backAnimationDelegateList))
		{
			raise_backAnimationDelegateList(this, forward);
		}
		else
		{
			Activate(this, activate: false);
		}
	}

	public void StopAnimation()
	{
		raise_stopAnimationDelegateList(this);
	}

	public void AddTweener(UIAutoTweener tweener)
	{
		if (!runTweenerList.Contains(tweener))
		{
			runTweenerList.Add(tweener);
		}
	}

	public void RemoveTweener(UIAutoTweener tweener)
	{
		if (runTweenerList.Contains(tweener))
		{
			runTweenerList.Remove(tweener);
		}
	}

	public void EndTweener(UIAutoTweener tweener)
	{
		if (!runTweenerList.Contains(tweener))
		{
			throw new AssertionFailedException("登録されてないUIAutoTweenerから呼ばれてます！");
		}
		if (finished_initialize && !m_forward && !isPlayingAnimation)
		{
			Activate(this, activate: false);
		}
	}

	public bool beAnimation(__UISituation_forwardAnimationDelegateList_0024callable109_002432_50__ listener)
	{
		bool num = 0 < runTweenerList.Count;
		if (!num)
		{
			num = listener != null;
			if (num)
			{
				num = 0 < listener.GetInvocationList().Length;
			}
		}
		return num;
	}
}
