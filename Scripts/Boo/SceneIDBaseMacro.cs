using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class SceneIDBaseMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReadBuildSceneList_002415479 : GenericGenerator<string>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<string>, IEnumerator
		{
			internal string[] _0024files_002415480;

			internal Boo.Lang.List<string> _0024paths_002415481;

			internal string _0024s_002415482;

			internal string _0024p_002415483;

			internal string _0024path_002415484;

			internal int _0024_00248088_002415485;

			internal string[] _0024_00248089_002415486;

			internal int _0024_00248090_002415487;

			internal IEnumerator<string> _0024_0024iterator_002413289_002415488;

			public override bool MoveNext()
			{
				bool flag;
				int result;
				checked
				{
					try
					{
						switch (_state)
						{
						default:
							_0024files_002415480 = Directory.GetFiles("Assets/Scenes/", "*.unity", SearchOption.AllDirectories);
							Array.Sort(_0024files_002415480);
							_0024paths_002415481 = new Boo.Lang.List<string>();
							_0024_00248088_002415485 = 0;
							_0024_00248089_002415486 = _0024files_002415480;
							for (_0024_00248090_002415487 = _0024_00248089_002415486.Length; _0024_00248088_002415485 < _0024_00248090_002415487; _0024_00248088_002415485++)
							{
								_0024_00248089_002415486[_0024_00248088_002415485] = _0024_00248089_002415486[_0024_00248088_002415485].Replace("\\", "/");
								if (_0024_00248089_002415486[_0024_00248088_002415485].IndexOf("/Sandboxes/") < 0)
								{
									_0024p_002415483 = Path.GetFileNameWithoutExtension(_0024_00248089_002415486[_0024_00248088_002415485]).ToUpper();
									if (_0024p_002415483 == "BOOT")
									{
										_0024paths_002415481.Insert(0, _0024_00248089_002415486[_0024_00248088_002415485]);
									}
									else
									{
										_0024paths_002415481.Add(_0024_00248089_002415486[_0024_00248088_002415485]);
									}
								}
							}
							_0024_0024iterator_002413289_002415488 = _0024paths_002415481.GetEnumerator();
							_state = 2;
							break;
						case 3:
							break;
						case 1:
						case 2:
							goto end_IL_0000;
						}
						if (_0024_0024iterator_002413289_002415488.MoveNext())
						{
							_0024path_002415484 = _0024_0024iterator_002413289_002415488.Current;
							flag = Yield(3, _0024path_002415484);
							goto IL_01b9;
						}
						_state = 1;
						_0024ensure2();
						YieldDefault(1);
						end_IL_0000:;
					}
					catch
					{
						//try-fault
						Dispose();
						throw;
					}
					result = 0;
					goto IL_01ba;
				}
				IL_01b9:
				result = (flag ? 1 : 0);
				goto IL_01ba;
				IL_01ba:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413289_002415488.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		public override IEnumerator<string> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[NonSerialized]
	protected const string BOOT_SCENE_NAME = "BOOT";

	[NonSerialized]
	protected const string BASE_PATH = "Assets/Scenes/";

	[NonSerialized]
	protected const string IGNORE_PATH = "/Sandboxes/";

	[NonSerialized]
	protected const string SCENE_LIST_FILE = "DontDeleteSceneList.lst";

	[NonSerialized]
	protected const string DUMMY_BOO_SRC = "Assets/Scripts/dummy.boo";

	public static string[] ScenePathList(bool forceUpdate)
	{
		string text = "DontDeleteSceneList.lst";
		if (File.Exists(text) && !forceUpdate)
		{
			Console.WriteLine(new StringBuilder("exists ").Append(text).ToString());
			return ReadLines(text);
		}
		Console.WriteLine(new StringBuilder("not exists ").Append(text).ToString());
		return CreateSceneListFile(text);
	}

	public static string[] CreateSceneListFile(string slistFile)
	{
		StreamWriter streamWriter;
		IDisposable disposable = (streamWriter = new StreamWriter(slistFile)) as IDisposable;
		try
		{
			Console.WriteLine(new StringBuilder("writing ").Append(slistFile).ToString());
			string[] array = (string[])Builtins.array(typeof(string), ReadBuildSceneList());
			int i = 0;
			string[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				streamWriter.Write(array2[i]);
				streamWriter.Write("\n");
			}
			Console.WriteLine(new StringBuilder("finished to write: ").Append(slistFile).ToString());
			return array;
		}
		finally
		{
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
		}
	}

	public static string[] ReadLines(string srcPath)
	{
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		string[] array;
		try
		{
			StreamReader streamReader;
			IDisposable disposable = (streamReader = new StreamReader(srcPath)) as IDisposable;
			try
			{
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine().Trim();
					if (text.Length > 0)
					{
						list.Add(text);
					}
				}
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
		}
		catch (Exception)
		{
			array = null;
			goto IL_0089;
		}
		object result = (string[])Builtins.array(typeof(string), list);
		goto IL_008b;
		IL_008b:
		return (string[])result;
		IL_0089:
		result = array;
		goto IL_008b;
	}

	public static IEnumerable<string> ReadBuildSceneList()
	{
		return new _0024ReadBuildSceneList_002415479();
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement macro)
	{
		throw new NotImplementedException();
	}
}
