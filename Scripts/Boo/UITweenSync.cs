using System;

[Serializable]
public class UITweenSync : UITweenController
{
	public UITweenController[] list;

	public void Awake()
	{
		int i = 0;
		UITweenController[] array = list;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].SetSync(this);
			}
		}
	}

	public void Update()
	{
		int i = 0;
		UITweenController[] array = list;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].Sync(this);
			}
		}
	}
}
