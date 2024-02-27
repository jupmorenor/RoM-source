using System.Collections;
using UnityEngine;

public class UIValidController : MonoBehaviour
{
	private class UIValidControllerInfo
	{
		public Color color = Color.white;

		public Color invalidColor = Color.gray;

		public UIWidget widget;
	}

	public GameObject validEffectTarget;

	public bool m_isValidColor = true;

	private bool m_lastIsValidColor = true;

	public Color invalidColor = Color.gray;

	private float time;

	private Hashtable colorTable = new Hashtable();

	public bool validColorIsForceWhite;

	public bool onlyGet1stColor = true;

	public bool keepAlpha = true;

	private bool get1stColor;

	public bool isValidColor
	{
		get
		{
			return GetValidColor();
		}
		set
		{
			SetValidColor(value);
		}
	}

	private void Start()
	{
		m_lastIsValidColor = m_isValidColor;
	}

	private void LateUpdate()
	{
		if (m_isValidColor != m_lastIsValidColor)
		{
			isValidColor = m_isValidColor;
		}
		if (m_isValidColor)
		{
			return;
		}
		foreach (int key in colorTable.Keys)
		{
			UIValidControllerInfo uIValidControllerInfo = (UIValidControllerInfo)colorTable[key];
			if (uIValidControllerInfo == null)
			{
				continue;
			}
			Color color = uIValidControllerInfo.invalidColor;
			UIWidget widget = uIValidControllerInfo.widget;
			if (uIValidControllerInfo != null && widget.color != color)
			{
				if (keepAlpha)
				{
					color.a = widget.color.a;
					widget.color = color;
				}
				else
				{
					widget.color = color;
				}
			}
		}
	}

	public bool GetValidColor()
	{
		return m_isValidColor;
	}

	public void SetValidColor(bool v)
	{
		bool saveValidColor = true;
		if (m_isValidColor == v)
		{
			saveValidColor = false;
		}
		if (get1stColor)
		{
			saveValidColor = false;
		}
		m_isValidColor = v;
		if (m_isValidColor != m_lastIsValidColor)
		{
			if (m_isValidColor)
			{
				RestoreColor();
			}
			else
			{
				SetInvalidColor(invalidColor, saveValidColor);
			}
			m_lastIsValidColor = m_isValidColor;
		}
	}

	public void SetInvalidColor(Color invalidColor, bool saveValidColor = false)
	{
		if (saveValidColor)
		{
			if (colorTable == null)
			{
				colorTable = new Hashtable();
			}
			else
			{
				colorTable.Clear();
			}
		}
		if (validEffectTarget == null)
		{
			validEffectTarget = base.gameObject;
		}
		UIWidget[] componentsInChildren = validEffectTarget.GetComponentsInChildren<UIWidget>(includeInactive: true);
		foreach (UIWidget uIWidget in componentsInChildren)
		{
			Color color = invalidColor;
			if (uIWidget == null)
			{
				continue;
			}
			UIValidObject component = uIWidget.gameObject.GetComponent<UIValidObject>();
			if (component != null)
			{
				color = component.GetValidColor(valid: false);
			}
			if (!validColorIsForceWhite)
			{
				color = uIWidget.color * color;
			}
			if (saveValidColor && colorTable != null)
			{
				if (onlyGet1stColor)
				{
					get1stColor = true;
				}
				UIValidControllerInfo uIValidControllerInfo = new UIValidControllerInfo();
				if (!validColorIsForceWhite)
				{
					uIValidControllerInfo.color = uIWidget.color;
				}
				else
				{
					uIValidControllerInfo.color = Color.white;
				}
				uIValidControllerInfo.invalidColor = color;
				uIValidControllerInfo.widget = uIWidget;
				colorTable[uIWidget.GetInstanceID()] = uIValidControllerInfo;
			}
			TweenColor.Begin(uIWidget.gameObject, time, color);
		}
	}

	public void RestoreColor()
	{
		if (colorTable == null)
		{
			return;
		}
		if (validEffectTarget == null)
		{
			validEffectTarget = base.gameObject;
		}
		UIWidget[] componentsInChildren = validEffectTarget.GetComponentsInChildren<UIWidget>(includeInactive: true);
		foreach (UIWidget uIWidget in componentsInChildren)
		{
			if (uIWidget == null || !colorTable.ContainsKey(uIWidget.GetInstanceID()))
			{
				continue;
			}
			UIValidControllerInfo uIValidControllerInfo = (UIValidControllerInfo)colorTable[uIWidget.GetInstanceID()];
			if (uIValidControllerInfo != null)
			{
				Color color = uIValidControllerInfo.color;
				UIValidObject component = uIWidget.gameObject.GetComponent<UIValidObject>();
				if (component != null)
				{
					color = component.GetValidColor(m_isValidColor);
				}
				TweenColor.Begin(uIWidget.gameObject, time, color);
			}
		}
	}
}
