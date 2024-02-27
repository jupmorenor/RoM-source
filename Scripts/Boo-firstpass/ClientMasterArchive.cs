using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using Ionic.Zlib;
using UnityEngine;

[Serializable]
public class ClientMasterArchive
{
	[Serializable]
	public class Entry
	{
		public string fileName;

		public int bodyOffset;

		public int size;
	}

	[Serializable]
	internal class _0024ReadMasterArchiveASync_0024locals_00242310
	{
		internal byte[] _0024arcBin;

		internal ICallable _0024handler;
	}

	[Serializable]
	internal class _0024ReadMasterArchiveCacheASync_0024locals_00242311
	{
		internal string _0024path;
	}

	[Serializable]
	internal class _0024ReadMasterArchiveASync_0024_load_00241055
	{
		internal _0024ReadMasterArchiveASync_0024locals_00242310 _0024_0024locals_00242319;

		public _0024ReadMasterArchiveASync_0024_load_00241055(_0024ReadMasterArchiveASync_0024locals_00242310 _0024_0024locals_00242319)
		{
			this._0024_0024locals_00242319 = _0024_0024locals_00242319;
		}

		public void Invoke()
		{
			Monitor.Enter(_sync);
			try
			{
				IEnumerator enumerator = ReadMasterArchiveCoroutine(_0024_0024locals_00242319._0024arcBin);
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					Thread.Sleep(20);
				}
				if (_0024_0024locals_00242319._0024handler != null)
				{
					_0024_0024locals_00242319._0024handler.Call(new object[0]);
				}
			}
			catch (Exception ex)
			{
				WriteLineToConsole("ReadMasterArchiveASync error: " + ex + "\n" + ex.StackTrace);
			}
			finally
			{
				Monitor.Exit(_sync);
			}
		}
	}

	[Serializable]
	internal class _0024ReadMasterArchiveCacheASync_0024_load_00241056
	{
		internal _0024ReadMasterArchiveCacheASync_0024locals_00242311 _0024_0024locals_00242320;

		public _0024ReadMasterArchiveCacheASync_0024_load_00241056(_0024ReadMasterArchiveCacheASync_0024locals_00242311 _0024_0024locals_00242320)
		{
			this._0024_0024locals_00242320 = _0024_0024locals_00242320;
		}

		public void Invoke()
		{
			checked
			{
				_readMasterArchiveCacheASyncCount++;
				Monitor.Enter(_sync);
				try
				{
					ReadMasterArchiveCache(_0024_0024locals_00242320._0024path);
				}
				finally
				{
					Monitor.Exit(_sync);
					_readMasterArchiveCacheASyncEndCount++;
				}
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReadMasterArchiveCoroutine_00242324 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal HashSet<string> _0024hashSet_00242325;

			internal ClientMasterArchive _0024arc_00242326;

			internal int _0024n_00242327;

			internal int _0024i_00242328;

			internal string _0024m_00242329;

			internal HashSet<string>.Enumerator _0024_0024iterator_00242129_00242330;

			internal byte[] _0024arcBin_00242331;

			public _0024(byte[] arcBin)
			{
				_0024arcBin_00242331 = arcBin;
			}

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
							loadingMasterInfo = "<expanding>";
							_0024hashSet_00242325 = new HashSet<string>();
							_0024arc_00242326 = ReadMasterArchiveSub(_0024arcBin_00242331);
							loadingMasterInfo = "<preparing>";
							PreapareReadMaster(ref _0024hashSet_00242325, _0024arc_00242326);
							_0024n_00242327 = _0024hashSet_00242325.Count;
							_0024i_00242328 = 0;
							_0024_0024iterator_00242129_00242330 = _0024hashSet_00242325.GetEnumerator();
							_state = 2;
							break;
						case 3:
							break;
						case 1:
						case 2:
							goto end_IL_0000;
						}
						if (_0024_0024iterator_00242129_00242330.MoveNext())
						{
							_0024m_00242329 = _0024_0024iterator_00242129_00242330.Current;
							loadingMasterInfo = new StringBuilder().Append((object)_0024i_00242328).Append("/").Append(_0024m_00242329)
								.Append(" - ")
								.Append(_0024m_00242329)
								.ToString();
							_0024i_00242328++;
							MerlinMaster.LoadMasterFromBytes(_0024m_00242329, _0024arc_00242326);
							lastLoadedMasterInfo[_0024m_00242329] = GetMasterInfo(_0024m_00242329);
							flag = YieldDefault(3);
							goto IL_0170;
						}
						_state = 1;
						_0024ensure2();
						loadingMasterInfo = "<end>";
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
					goto IL_0171;
				}
				IL_0170:
				result = (flag ? 1 : 0);
				goto IL_0171;
				IL_0171:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				((IDisposable)_0024_0024iterator_00242129_00242330).Dispose();
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

		internal byte[] _0024arcBin_00242332;

		public _0024ReadMasterArchiveCoroutine_00242324(byte[] arcBin)
		{
			_0024arcBin_00242332 = arcBin;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arcBin_00242332);
		}
	}

	private Entry[] _entries;

	private byte[] body;

	[NonSerialized]
	private static Boo.Lang.List<string> preparedMasters = new Boo.Lang.List<string>();

	[NonSerialized]
	private static readonly object _sync = new object();

	[NonSerialized]
	private static int _readMasterArchiveCacheASyncCount;

	[NonSerialized]
	private static int _readMasterArchiveCacheASyncEndCount;

	[NonSerialized]
	private static int _isReadingMasterCheckCounter;

	[NonSerialized]
	private static string loadingMasterInfo = string.Empty;

	[NonSerialized]
	private static Dictionary<string, string> lastLoadedMasterInfo = new Dictionary<string, string>();

	public static bool HasCache => File.Exists(GetDefaultMasterArchivePath());

	public Entry[] Entries => _entries;

	public static Boo.Lang.List<string> PreparedMasters => preparedMasters;

	public static int ReadMasterArchiveCacheASyncCount => _readMasterArchiveCacheASyncCount;

	public static int ReadMasterArchiveCacheASyncEndCount => _readMasterArchiveCacheASyncEndCount;

	public static string LoadingMasterInfo => loadingMasterInfo;

	public static Dictionary<string, string> LastLoadedMasterInfo => lastLoadedMasterInfo;

	public static string GetDefaultMasterArchivePath()
	{
		string persistentDataPath = Application.persistentDataPath;
		persistentDataPath = ((!persistentDataPath.EndsWith("/")) ? (persistentDataPath + "/") : persistentDataPath);
		return persistentDataPath + "master-dat.dat";
	}

	public byte[] Read(string fileName)
	{
		Entry entry = null;
		int i = 0;
		Entry[] entries = _entries;
		for (int length = entries.Length; i < length; i = checked(i + 1))
		{
			if (entries[i].fileName == fileName)
			{
				entry = entries[i];
				break;
			}
		}
		object result;
		if (entry == null)
		{
			WriteLineToConsole(new StringBuilder("ReadMasterArchiveASync: error ").Append(fileName).ToString());
			result = null;
		}
		else
		{
			int size = entry.size;
			byte[] array = new byte[size];
			Buffer.BlockCopy(body, entry.bodyOffset, array, 0, entry.size);
			result = array;
		}
		return (byte[])result;
	}

	public static ClientMasterArchive Load(Stream file)
	{
		ClientMasterArchive clientMasterArchive2;
		try
		{
			ZlibStream input = new ZlibStream(file, CompressionMode.Decompress);
			BinaryReader binaryReader = new BinaryReader(input);
			int num = binaryReader.ReadInt32();
			Entry[] array = new Entry[num];
			int num2 = 0;
			WriteLineToConsole(new StringBuilder("ClientMasterArchive.Load entryNum ").Append((object)num).ToString());
			int num3 = 0;
			int num4 = num;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index = num3;
				num3++;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = new Entry();
				array[RuntimeServices.NormalizeArrayIndex(array, index)].fileName = binaryReader.ReadString();
				array[RuntimeServices.NormalizeArrayIndex(array, index)].bodyOffset = binaryReader.ReadInt32();
				array[RuntimeServices.NormalizeArrayIndex(array, index)].size = binaryReader.ReadInt32();
				num2 = checked(num2 + array[RuntimeServices.NormalizeArrayIndex(array, index)].size);
			}
			byte[] array2 = binaryReader.ReadBytes(num2);
			ClientMasterArchive clientMasterArchive = new ClientMasterArchive();
			clientMasterArchive._entries = array;
			clientMasterArchive.body = array2;
			clientMasterArchive2 = clientMasterArchive;
		}
		catch (Exception rhs)
		{
			WriteLineToConsole(new StringBuilder("ClientMasterArchive.Load error(").Append(file).Append("): ").ToString() + rhs);
			goto IL_0134;
		}
		object result = clientMasterArchive2;
		goto IL_0139;
		IL_0139:
		return (ClientMasterArchive)result;
		IL_0134:
		result = null;
		goto IL_0139;
	}

	private static ClientMasterArchive ReadMasterArchiveSub(byte[] arcBin)
	{
		MemoryStream file;
		IDisposable disposable = (file = new MemoryStream(arcBin)) as IDisposable;
		try
		{
			return Load(file);
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

	public static void PreapareReadMaster(ref HashSet<string> hashSet, ClientMasterArchive arc)
	{
		preparedMasters.Clear();
		int i = 0;
		Entry[] entries = arc.Entries;
		for (int length = entries.Length; i < length; i = checked(i + 1))
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(entries[i].fileName);
			if (MerlinMaster.IsLoadMarked(fileNameWithoutExtension))
			{
				MerlinMaster.MarkUnloaded(fileNameWithoutExtension);
			}
			hashSet.Add(fileNameWithoutExtension);
			preparedMasters.Add(fileNameWithoutExtension);
		}
	}

	public static void ReadMasterArchive(byte[] arcBin)
	{
		IEnumerator enumerator = ReadMasterArchiveCoroutine(arcBin);
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
		}
	}

	public static void ReadMasterArchiveASync(byte[] arcBin, ICallable handler)
	{
		_0024ReadMasterArchiveASync_0024locals_00242310 _0024ReadMasterArchiveASync_0024locals_0024 = new _0024ReadMasterArchiveASync_0024locals_00242310();
		_0024ReadMasterArchiveASync_0024locals_0024._0024arcBin = arcBin;
		_0024ReadMasterArchiveASync_0024locals_0024._0024handler = handler;
		__MasterLoadMethodEntry_unload_0024callable20_0024190_26__ from = new _0024ReadMasterArchiveASync_0024_load_00241055(_0024ReadMasterArchiveASync_0024locals_0024).Invoke;
		Thread thread = new Thread(_0024adaptor_0024__MasterLoadMethodEntry_unload_0024callable20_0024190_26___0024ThreadStart_00240.Adapt(from));
		thread.Start();
	}

	public static void ReadMasterArchiveCacheASync(string path)
	{
		_0024ReadMasterArchiveCacheASync_0024locals_00242311 _0024ReadMasterArchiveCacheASync_0024locals_0024 = new _0024ReadMasterArchiveCacheASync_0024locals_00242311();
		_0024ReadMasterArchiveCacheASync_0024locals_0024._0024path = path;
		__MasterLoadMethodEntry_unload_0024callable20_0024190_26__ from = new _0024ReadMasterArchiveCacheASync_0024_load_00241056(_0024ReadMasterArchiveCacheASync_0024locals_0024).Invoke;
		Thread thread = new Thread(_0024adaptor_0024__MasterLoadMethodEntry_unload_0024callable20_0024190_26___0024ThreadStart_00240.Adapt(from));
		thread.Start();
	}

	public static void WaitReadMasterArchiveASync()
	{
		Monitor.Enter(_sync);
		Monitor.Exit(_sync);
	}

	public static bool IsReadingMasterArchive()
	{
		int result;
		checked
		{
			if (Monitor.TryEnter(_sync))
			{
				_isReadingMasterCheckCounter++;
				if (_isReadingMasterCheckCounter > 30)
				{
					_isReadingMasterCheckCounter = 0;
				}
				Monitor.Exit(_sync);
				result = 0;
			}
			else
			{
				result = 1;
			}
		}
		return (byte)result != 0;
	}

	public static IEnumerator ReadMasterArchiveCoroutine(byte[] arcBin)
	{
		return new _0024ReadMasterArchiveCoroutine_00242324(arcBin).GetEnumerator();
	}

	private static string GetMasterInfo(string mname)
	{
		return new StringBuilder("master ").Append(mname).ToString();
	}

	public static void ReadMasterArchiveCache(string path)
	{
		ReadMasterArchive(File.ReadAllBytes(path));
	}

	private static void WriteLineToConsole(string str)
	{
	}
}
