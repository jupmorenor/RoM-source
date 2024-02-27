using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class HUDSwitcher : MonoBehaviour
{
	[Serializable]
	public class SwitchObject
	{
		public string name;

		public GameObject root;

		public bool on;

		private bool last;

		private UIPanel uipanel;

		public SwitchObject()
		{
			on = true;
			last = true;
		}

		public void Update()
		{
			if (on != last)
			{
				last = on;
				if ((bool)root)
				{
					NGUITools.SetActive(root, on);
				}
			}
		}

		public void Refresh()
		{
			if ((bool)root)
			{
				if (!uipanel)
				{
					uipanel = NGUITools.GetPanel(root);
				}
				if ((bool)uipanel)
				{
					uipanel.Refresh();
				}
			}
		}
	}

	public SwitchObject[] switchObjects;

	public void SetActive(int index, bool on)
	{
		SwitchObject[] array = switchObjects;
		array[RuntimeServices.NormalizeArrayIndex(array, index)].on = on;
	}

	public void SwitchOnOff(int onIndex, int offIndex, bool on)
	{
		SetActive(onIndex, on);
		SetActive(offIndex, !on);
	}

	public void Switch()
	{
		if (switchObjects == null || switchObjects.Length <= 0)
		{
			return;
		}
		int i = 0;
		SwitchObject[] array = switchObjects;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].Update();
				if (Application.isEditor)
				{
					array[i].Refresh();
				}
			}
		}
	}

	public void Start()
	{
		Switch();
	}

	public void LateUpdate()
	{
		Switch();
	}
}
