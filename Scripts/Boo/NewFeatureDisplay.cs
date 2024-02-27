using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class NewFeatureDisplay : MonoBehaviour
{
	[Serializable]
	internal class _0024main_0024locals_002414528
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024main_0024closure_00245064
	{
		internal _0024main_0024locals_002414528 _0024_0024locals_002415180;

		public _0024main_0024closure_00245064(_0024main_0024locals_002414528 _0024_0024locals_002415180)
		{
			this._0024_0024locals_002415180 = _0024_0024locals_002415180;
		}

		public void Invoke()
		{
			_0024_0024locals_002415180._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421845 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MNewFeatureDetails[] _0024newsMasters_002421846;

			internal MNewFeatureDetails _0024m_002421847;

			internal DialogManager _0024dlgMan_002421848;

			internal MNewFeatureDetails _0024mst_002421849;

			internal Dialog _0024dlg_002421850;

			internal int _0024_002411480_002421851;

			internal MNewFeatureDetails[] _0024_002411481_002421852;

			internal int _0024_002411482_002421853;

			internal int _0024_002411484_002421854;

			internal MNewFeatureDetails[] _0024_002411485_002421855;

			internal int _0024_002411486_002421856;

			internal _0024main_0024locals_002414528 _0024_0024locals_002421857;

			internal NewFeatureDisplay _0024self__002421858;

			public _0024(NewFeatureDisplay self_)
			{
				_0024self__002421858 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002421857 = new _0024main_0024locals_002414528();
						_0024newsMasters_002421846 = _0024self__002421858.getNewFeatureDetails();
						if (IsNotClearTutorial)
						{
							_0024_002411480_002421851 = 0;
							_0024_002411481_002421852 = _0024newsMasters_002421846;
							for (_0024_002411482_002421853 = _0024_002411481_002421852.Length; _0024_002411480_002421851 < _0024_002411482_002421853; _0024_002411480_002421851++)
							{
								_0024self__002421858.updateReadFlag(_0024_002411481_002421852[_0024_002411480_002421851]);
							}
							goto IL_01c3;
						}
						_0024dlgMan_002421848 = DialogManager.Instance;
						_0024dlgMan_002421848.OnButton(0);
						_0024_002411484_002421854 = 0;
						_0024_002411485_002421855 = _0024newsMasters_002421846;
						_0024_002411486_002421856 = _0024_002411485_002421855.Length;
						goto IL_01b2;
					case 2:
						if (!_0024_0024locals_002421857._0024ok)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421858.updateReadFlag(_0024_002411485_002421855[_0024_002411484_002421854]);
						goto IL_01a4;
					case 1:
						{
							result = 0;
							break;
						}
						IL_01a4:
						_0024_002411484_002421854++;
						goto IL_01b2;
						IL_01b2:
						if (_0024_002411484_002421854 < _0024_002411486_002421856)
						{
							if (_0024_002411485_002421855[_0024_002411484_002421854] == null)
							{
								goto IL_01a4;
							}
							_0024dlg_002421850 = _0024dlgMan_002421848.OpenCustomDialog(_0024_002411485_002421855[_0024_002411484_002421854].Message, _0024_002411485_002421855[_0024_002411484_002421854].Title, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" }, 3);
							_0024_0024locals_002421857._0024ok = false;
							_0024dlg_002421850.CloseHandler = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024main_0024closure_00245064(_0024_0024locals_002421857).Invoke);
							goto case 2;
						}
						goto IL_01c3;
						IL_01c3:
						_0024self__002421858.isEnd = true;
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal NewFeatureDisplay _0024self__002421859;

		public _0024main_002421845(NewFeatureDisplay self_)
		{
			_0024self__002421859 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421859);
		}
	}

	public bool startAutomatically;

	private bool isEnd;

	public bool IsEnd => isEnd;

	private static bool IsNotClearTutorial
	{
		get
		{
			UserMiscInfo userMiscInfo = UserData.Current.userMiscInfo;
			return userMiscInfo.tutorialStep < 5;
		}
	}

	public void Start()
	{
		if (startAutomatically)
		{
			show();
		}
	}

	public void show()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002421845(this).GetEnumerator();
	}

	private MNewFeatureDetails[] getNewFeatureDetails()
	{
		string n = "xDisplayedNewFeatureId";
		int currentDisplayedId = 0;
		UserData current = UserData.Current;
		if (current.hasFlag("xDisplayedNewFeatureId"))
		{
			currentDisplayedId = current.getIntFlag(n, 0);
		}
		return MNewFeatureDetails.GetNewDetails(currentDisplayedId);
	}

	private void updateReadFlag(MNewFeatureDetails m)
	{
		string n = "xDisplayedNewFeatureId";
		UserData current = UserData.Current;
		if (m != null && current.getIntFlag(n, 0) < m.NewsId)
		{
			current.setFlag(n, m.NewsId);
		}
	}
}
