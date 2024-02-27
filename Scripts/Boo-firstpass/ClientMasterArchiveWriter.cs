using System;
using System.Collections.Generic;
using System.IO;
using Ionic.Zlib;

[Serializable]
public class ClientMasterArchiveWriter
{
	private Dictionary<string, byte[]> entries;

	public ClientMasterArchiveWriter()
	{
		entries = new Dictionary<string, byte[]>();
	}

	public void AddEntry(string fileName, byte[] bytes)
	{
		entries[fileName] = bytes;
	}

	public byte[] Export()
	{
		MemoryStream memoryStream;
		IDisposable disposable = (memoryStream = new MemoryStream()) as IDisposable;
		try
		{
			ZlibStream zlibStream;
			IDisposable disposable2 = (zlibStream = new ZlibStream(memoryStream, CompressionMode.Compress)) as IDisposable;
			try
			{
				BinaryWriter binaryWriter;
				IDisposable disposable3 = (binaryWriter = new BinaryWriter(zlibStream)) as IDisposable;
				try
				{
					binaryWriter.Write(entries.Count);
					int num = 0;
					foreach (KeyValuePair<string, byte[]> entry in entries)
					{
						binaryWriter.Write(entry.Key);
						binaryWriter.Write(num);
						binaryWriter.Write(entry.Value.Length);
						num = checked(num + entry.Value.Length);
					}
					foreach (KeyValuePair<string, byte[]> entry2 in entries)
					{
						binaryWriter.Write(entry2.Value);
					}
					binaryWriter.Flush();
					zlibStream.Flush();
					zlibStream.Close();
					return memoryStream.ToArray();
				}
				finally
				{
					if (disposable3 != null)
					{
						disposable3.Dispose();
						disposable3 = null;
					}
				}
			}
			finally
			{
				if (disposable2 != null)
				{
					disposable2.Dispose();
					disposable2 = null;
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
}
