using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang;
using Boo.Lang.Runtime;

[Serializable]
public class UIBlinkSync : UIBlinkController
{
	public UIBlinkController[] controllers;

	private object InitSync()
	{
		object result;
		if (blinks == null || blinks.Count() == 0)
		{
			result = null;
		}
		else
		{
			Boo.Lang.List<UIBlinkController> list = new Boo.Lang.List<UIBlinkController>();
			int i = 0;
			UIBlinkController[] array = controllers;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (!array[i] || array[i].blinks == null || array[i].blinks.Count() != blinks.Count())
				{
					continue;
				}
				bool flag = true;
				int num = 0;
				int num2 = blinks.Count();
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int index = num;
					num++;
					Blink[] array2 = array[i].blinks;
					Blink blink = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					if (blink != null || contains(blink))
					{
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					list.Add(array[i]);
				}
			}
			IEnumerator<UIBlinkController> enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					UIBlinkController c = enumerator.Current;
					InitController(c);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			controllers = list.ToArray();
			result = null;
		}
		return result;
	}

	private void InitController(UIBlinkController c)
	{
		c.sync = this;
		int num = 0;
		int num2 = blinks.Count();
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Blink[] array = c.blinks;
			Blink blink = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (blink != null)
			{
				Blink b = find(blink);
				if (blink.enabled)
				{
					blink.Set(b);
				}
			}
		}
		c.Initialize();
		c.OnEnable();
	}

	public override void Initialize()
	{
		if (!finished)
		{
			base.Initialize();
			InitSync();
			finished = true;
		}
	}

	public void Add(UIBlinkController blink)
	{
		int i = 0;
		UIBlinkController[] array = controllers;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] == blink)
			{
				return;
			}
		}
		InitController(blink);
		controllers = (UIBlinkController[])RuntimeServices.AddArrays(typeof(UIBlinkController), controllers, new UIBlinkController[1] { blink });
	}

	public void Remove(UIBlinkController blink)
	{
		Boo.Lang.List<UIBlinkController> list = new Boo.Lang.List<UIBlinkController>();
		int i = 0;
		UIBlinkController[] array = controllers;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == blink))
			{
				list.Add(array[i]);
			}
		}
		controllers = list.ToArray();
	}

	public void Update()
	{
		if (play_mode == last_mode || controllers == null || controllers.Count() <= 0)
		{
			return;
		}
		int i = 0;
		UIBlinkController[] array = controllers;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!array[i] || array[i].Sync(this))
			{
			}
		}
	}
}
