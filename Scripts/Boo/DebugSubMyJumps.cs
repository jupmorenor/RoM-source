using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubMyJumps : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024Init_0024locals_002414300
	{
		internal string _0024s;
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243020
	{
		internal DebugSubMyJumps _0024this_002414692;

		internal string _0024s_002414693;

		internal int _0024i_002414694;

		public _0024OnGUI_0024closure_00243020(DebugSubMyJumps _0024this_002414692, string _0024s_002414693, int _0024i_002414694)
		{
			this._0024this_002414692 = _0024this_002414692;
			this._0024s_002414693 = _0024s_002414693;
			this._0024i_002414694 = _0024i_002414694;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button(_0024s_002414693, 320))
			{
				_0024this_002414692.ChangeScene(_0024s_002414693);
			}
			if (RuntimeDebugModeGuiMixin.button("DEL", 80))
			{
				_0024this_002414692.names.Remove(_0024s_002414693);
				_0024this_002414692.save();
			}
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("^", 80))
				{
					_0024this_002414692.names.RemoveAt(_0024i_002414694);
					_0024this_002414692.names.Insert(_0024i_002414694 - 1, _0024s_002414693);
					_0024this_002414692.save();
				}
				if (RuntimeDebugModeGuiMixin.button("v", 80) && _0024i_002414694 < _0024this_002414692.names.Count - 1)
				{
					_0024this_002414692.names.RemoveAt(_0024i_002414694);
					_0024this_002414692.names.Insert(_0024i_002414694 + 1, _0024s_002414693);
					_0024this_002414692.save();
				}
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Init_002415340 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			internal _0024Init_0024locals_002414300 _0024_0024locals_002415341;

			protected IEnumerator<string> _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator(_0024Init_0024locals_002414300 _0024_0024locals_002415341)
			{
				this._0024_0024locals_002415341 = _0024_0024locals_002415341;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<string>)_0024_0024locals_002415341._0024s.Split(',')).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				while (true)
				{
					if (_0024_0024enumerator.MoveNext())
					{
						string current = _0024_0024enumerator.Current;
						if (SceneIDModule.StrToSceneID(current) != SceneID.__NONE__)
						{
							_0024_0024current = current;
							result = 1;
							break;
						}
						continue;
					}
					result = 0;
					break;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal _0024Init_0024locals_002414300 _0024_0024locals_002415342;

		public _0024Init_002415340(_0024Init_0024locals_002414300 _0024_0024locals_002415342)
		{
			this._0024_0024locals_002415342 = _0024_0024locals_002415342;
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002415342);
		}
	}

	private Boo.Lang.List<string> names;

	public DebugSubMyJumps()
	{
		names = new Boo.Lang.List<string>();
	}

	public override void Init()
	{
		_0024Init_0024locals_002414300 _0024Init_0024locals_0024 = new _0024Init_0024locals_002414300();
		_0024Init_0024locals_0024._0024s = PlayerPrefs.GetString("Merlin-DebugMode-SubJumps", string.Empty);
		names = new Boo.Lang.List<string>(new _0024Init_002415340(_0024Init_0024locals_0024));
	}

	private void save()
	{
		PlayerPrefs.SetString("Merlin-DebugMode-SubJumps", Builtins.join(names, ","));
	}

	public override void Exit()
	{
		save();
	}

	public override void OnGUI()
	{
		title = "Bookmark";
		if (RuntimeDebugModeGuiMixin.button("<<add this scene>>"))
		{
			string loadedLevelName = Application.loadedLevelName;
			if (!names.Contains(loadedLevelName) && SceneIDModule.StrToSceneID(loadedLevelName) != SceneID.__NONE__)
			{
				names.Add(loadedLevelName);
			}
			save();
		}
		RuntimeDebugModeGuiMixin.space(40);
		Builtins.ZipEnumerator zipEnumerator = Builtins.zip(Builtins.range(names.Count), (string[])Builtins.array(typeof(string), names));
		try
		{
			while (zipEnumerator.MoveNext())
			{
				object obj = zipEnumerator.Current;
				if (!(obj is object[]))
				{
					obj = RuntimeServices.Coerce(obj, typeof(object[]));
				}
				object[] array = (object[])obj;
				int _0024i_0024 = RuntimeServices.UnboxInt32(array[0]);
				object obj2 = array[1];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string _0024s_0024 = (string)obj2;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024OnGUI_0024closure_00243020(this, _0024s_0024, _0024i_0024).Invoke));
			}
		}
		finally
		{
			((IDisposable)zipEnumerator).Dispose();
		}
	}

	public void ChangeScene(string scene)
	{
		RuntimeDebugMode.DebugChangeScene(scene);
	}
}
