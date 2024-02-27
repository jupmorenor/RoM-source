using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CutSceneSkipButton : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024process_002418139 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CutSceneSkipButton _0024self__002418140;

			public _0024(CutSceneSkipButton self_)
			{
				_0024self__002418140 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418140.doFast();
					goto case 2;
				case 2:
					if (_0024self__002418140.b_down)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002418140.doNormal();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CutSceneSkipButton _0024self__002418141;

		public _0024process_002418139(CutSceneSkipButton self_)
		{
			_0024self__002418141 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418141);
		}
	}

	public GameObject panel;

	protected bool skip;

	public bool b_down;

	public bool b_dclick;

	public void OnSkip(GameObject obj)
	{
		CutSceneManager instance = CutSceneManager.Instance;
		if (!instance || !instance.exec)
		{
			return;
		}
		EventWindow instance2 = EventWindow.Instance;
		if ((bool)instance2)
		{
			IEnumerator<object[]> enumerator = Builtins.enumerate(instance2.Windows).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object[] current = enumerator.Current;
					object obj2 = current[0];
					object obj3 = current[1];
					if (!(obj3 is EventWindow.Window))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(EventWindow.Window));
					}
					((EventWindow.Window)obj3)?.PushWindow();
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		if (!instance.IsSkipping)
		{
			skip = true;
			instance.Skip();
		}
	}

	public void OnCutsceneFFPress()
	{
		b_down = true;
	}

	public void OnFastPlay(GameObject obj)
	{
		CutSceneManager instance = CutSceneManager.Instance;
		if ((bool)instance && instance.exec && !instance.IsSkipping)
		{
			skip = true;
			instance.SKIP_TO_NEXT_TAG();
		}
	}

	public void OnCutsceneFFDoubleClick(GameObject obj)
	{
		b_down = true;
		CutSceneManager instance = CutSceneManager.Instance;
		instance.SKIP_TO_NEXT_MESSAGE();
	}

	public void OnCutsceneFFRelease()
	{
		b_down = false;
	}

	public IEnumerator process()
	{
		return new _0024process_002418139(this).GetEnumerator();
	}

	public void OnButtonDown()
	{
	}

	public void OnButtonRelease()
	{
	}

	public void doFast()
	{
		CutSceneManager instance = CutSceneManager.Instance;
		if ((bool)instance && instance.exec && !instance.IsSkipping)
		{
			instance.PlayFast();
		}
	}

	public void doNormal()
	{
		CutSceneManager instance = CutSceneManager.Instance;
		if ((bool)instance && instance.exec && !instance.IsSkipping)
		{
			instance.PlayNormal();
		}
	}

	public void Update()
	{
		CutSceneManager instance = CutSceneManager.Instance;
		if (!instance)
		{
			return;
		}
		if (instance.exec)
		{
			panel.SetActive(skip);
			if (!instance.IsSkipping)
			{
				skip = false;
			}
		}
		else
		{
			skip = false;
			panel.SetActive(value: false);
		}
	}
}
