using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Boo.Lang;

[Serializable]
public class BinPackLoader : IEnumerable
{
	[Serializable]
	public class FileInfo
	{
		public string fileName;

		public int size;

		public byte[] data;

		public FileInfo(string _fileName, int _size)
		{
			fileName = _fileName;
			size = _size;
		}
	}

	[NonSerialized]
	public const int VERSION = 1;

	[NonSerialized]
	public const string HEADER_STRING = "BPK";

	private BinaryReader reader;

	private int version;

	private Boo.Lang.List<FileInfo> fileInfos;

	public int Version => version;

	public Boo.Lang.List<FileInfo> FileInfos => fileInfos;

	public BinPackLoader(byte[] data)
	{
		fileInfos = new Boo.Lang.List<FileInfo>();
		MemoryStream input = new MemoryStream(data);
		reader = new BinaryReader(input);
		readHeader();
		readBody();
	}

	private void readHeader()
	{
		fileInfos.Clear();
		try
		{
			string text = reader.ReadString();
			if (text != "BPK")
			{
				return;
			}
			version = reader.ReadInt32();
			if (1 == version)
			{
				int num = reader.ReadInt32();
				int num2 = 0;
				int num3 = num;
				if (num3 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < num3)
				{
					int num4 = num2;
					num2++;
					string fileName = reader.ReadString();
					int size = reader.ReadInt32();
					fileInfos.Add(new FileInfo(fileName, size));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void readBody()
	{
		IEnumerator<FileInfo> enumerator = fileInfos.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				FileInfo current = enumerator.Current;
				try
				{
					current.data = reader.ReadBytes(current.size);
				}
				catch (Exception)
				{
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
