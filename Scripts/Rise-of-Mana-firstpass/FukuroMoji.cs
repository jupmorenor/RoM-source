using UnityEngine;

public class FukuroMoji : MonoBehaviour
{
	public UIDynamicFontLabel[] m_Label;

	public string m_Text = string.Empty;

	public string text
	{
		get
		{
			return m_Text;
		}
		set
		{
			m_Text = value;
			if (m_Label == null)
			{
				return;
			}
			UIDynamicFontLabel[] label = m_Label;
			foreach (UIDynamicFontLabel uIDynamicFontLabel in label)
			{
				if ((bool)uIDynamicFontLabel)
				{
					uIDynamicFontLabel.text = value;
				}
			}
		}
	}

	private void Start()
	{
		text = m_Text;
	}

	private void Update()
	{
		text = m_Text;
	}
}
