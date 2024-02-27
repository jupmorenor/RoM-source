using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class UIHUDLayer : MonoBehaviour
{
	public GameObject[] tops;

	public GameObject[] bots;

	private Boo.Lang.List<UIAutoTweener> tweener;

	public UIHUDLayer()
	{
		tweener = new Boo.Lang.List<UIAutoTweener>();
	}

	public void Start()
	{
		IEnumerator<GameObject> enumerator = tops.Concat(bots).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				UIAutoTweener componentInChildren = current.GetComponentInChildren<UIAutoTweener>();
				componentInChildren.ignoreTimeScale = true;
				componentInChildren.Initialize();
				componentInChildren.isStandAlone = true;
				tweener.Add(componentInChildren);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void SetIn(bool isIn)
	{
		IEnumerator<UIAutoTweener> enumerator = tweener.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				UIAutoTweener current = enumerator.Current;
				current.PlayAnimation(isIn);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
