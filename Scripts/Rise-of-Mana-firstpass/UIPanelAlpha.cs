using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Panel Alpha")]
public class UIPanelAlpha : MonoBehaviour
{
	public float alpha = 1f;

	private Collider[] mColliders;

	private UIWidget[] mWidgets;

	private float mLastAlpha = 1f;

	private int mLevel = 2;

	private Dictionary<int, float> mAlpha = new Dictionary<int, float>();

	public bool needIgnoreParentAlpha;

	private void Start()
	{
		mColliders = GetComponentsInChildren<Collider>(includeInactive: true);
		mWidgets = GetComponentsInChildren<UIWidget>(includeInactive: true);
		UIPanelAlpha[] componentsInChildren = GetComponentsInChildren<UIPanelAlpha>(includeInactive: true);
		if (mWidgets.Length == 0)
		{
			Debug.LogWarning("Expected to find widgets to work with", this);
			base.enabled = false;
			return;
		}
		for (int i = 0; i < mWidgets.Length; i++)
		{
			mAlpha[mWidgets[i].GetInstanceID()] = mWidgets[i].alpha;
		}
		foreach (UIPanelAlpha uIPanelAlpha in componentsInChildren)
		{
			if (!(uIPanelAlpha != this))
			{
				continue;
			}
			for (int k = 0; k < mWidgets.Length; k++)
			{
				UIWidget uIWidget = mWidgets[k];
				if (uIWidget == null)
				{
					continue;
				}
				Transform parent = uIWidget.transform;
				while (!(parent == null))
				{
					if (uIPanelAlpha.gameObject == parent.gameObject)
					{
						mWidgets[k] = null;
						break;
					}
					parent = parent.parent;
				}
			}
		}
		mLastAlpha = Mathf.Clamp01(alpha);
		mLevel = ((mLastAlpha > 0.99f) ? 2 : ((!(mLastAlpha < 0.01f)) ? 1 : 0));
		UpdateAlpha();
	}

	private void Update()
	{
		alpha = Mathf.Clamp01(alpha);
		if (mLastAlpha != alpha)
		{
			mLastAlpha = alpha;
			UpdateAlpha();
		}
	}

	private void UpdateAlpha()
	{
		int i = 0;
		for (int num = mWidgets.Length; i < num; i++)
		{
			UIWidget uIWidget = mWidgets[i];
			if (!(uIWidget == null))
			{
				if (!mAlpha.ContainsKey(uIWidget.GetInstanceID()))
				{
					mAlpha[uIWidget.GetInstanceID()] = uIWidget.alpha;
				}
				uIWidget.alpha = mAlpha[uIWidget.GetInstanceID()] * alpha;
			}
		}
		if (mLevel == 0)
		{
			Transform transform = base.transform;
			int j = 0;
			for (int childCount = transform.childCount; j < childCount; j++)
			{
				NGUITools.SetActive(transform.GetChild(j).gameObject, state: true);
			}
			int k = 0;
			for (int num2 = mColliders.Length; k < num2; k++)
			{
				if ((bool)mColliders[k])
				{
					mColliders[k].enabled = false;
				}
			}
			mLevel = 1;
		}
		else if (mLevel == 2 && alpha < 0.99f)
		{
			TweenColor[] componentsInChildren = GetComponentsInChildren<TweenColor>();
			int l = 0;
			for (int num3 = componentsInChildren.Length; l < num3; l++)
			{
				componentsInChildren[l].enabled = false;
			}
			int m = 0;
			for (int num4 = mColliders.Length; m < num4; m++)
			{
				if ((bool)mColliders[m])
				{
					mColliders[m].enabled = false;
				}
			}
			mLevel = 1;
		}
		if (mLevel != 1)
		{
			return;
		}
		if (alpha < 0.01f)
		{
			Transform transform2 = base.transform;
			int n = 0;
			for (int childCount2 = transform2.childCount; n < childCount2; n++)
			{
				NGUITools.SetActive(transform2.GetChild(n).gameObject, state: false);
			}
			mLevel = 0;
		}
		else
		{
			if (!(alpha > 0.99f))
			{
				return;
			}
			int num5 = 0;
			for (int num6 = mColliders.Length; num5 < num6; num5++)
			{
				if ((bool)mColliders[num5])
				{
					mColliders[num5].enabled = true;
				}
			}
			mLevel = 2;
		}
	}
}
