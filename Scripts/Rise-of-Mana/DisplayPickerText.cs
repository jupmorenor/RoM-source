using UnityEngine;

[RequireComponent(typeof(UILabel))]
public class DisplayPickerText : MonoBehaviour
{
	public IPTextPicker picker;

	private UILabel _label;

	private void Awake()
	{
		_label = base.gameObject.GetComponent(typeof(UILabel)) as UILabel;
	}

	private void DisplayText()
	{
		_label.text = picker.CurrentLabelText;
	}
}
