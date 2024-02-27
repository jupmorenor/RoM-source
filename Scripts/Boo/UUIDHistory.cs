using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class UUIDHistory
{
	[Serializable]
	public class Entry
	{
		public string uuid;

		public DateTime created;

		public string name;

		public Entry(string uuid, string name)
		{
			this.uuid = uuid;
			this.name = name;
			created = DateTime.Now;
		}

		public Entry(string uuid, string name, DateTime dt)
		{
			this.uuid = uuid;
			this.name = name;
			created = dt;
		}

		public override string ToString()
		{
			return (!string.IsNullOrEmpty(name)) ? new StringBuilder().Append((object)created.Month).Append("/").Append((object)created.Day)
				.Append(" ")
				.Append((object)created.Hour)
				.Append(":")
				.Append((object)created.Minute)
				.Append(" ")
				.Append(name)
				.ToString() : new StringBuilder().Append((object)created.Month).Append("/").Append((object)created.Day)
				.Append(" ")
				.Append((object)created.Hour)
				.Append(":")
				.Append((object)created.Minute)
				.Append(" ")
				.Append(uuid)
				.ToString();
		}
	}

	[NonSerialized]
	private static Queue<Entry> entries = new Queue<Entry>();

	public static Entry[] AllEntries => (Entry[])Builtins.array(typeof(Entry), entries);

	public static int Count => ((ICollection)entries).Count;

	public static void Save()
	{
		string text = string.Empty;
		int i = 0;
		Entry[] allEntries = AllEntries;
		for (int length = allEntries.Length; i < length; i = checked(i + 1))
		{
			text += new StringBuilder().Append(allEntries[i].uuid).Append("\t").Append(allEntries[i].created)
				.Append("\t")
				.Append(allEntries[i].name)
				.Append("\n")
				.ToString();
		}
		PlayerPrefs.SetString("Merlin-DebugMode-UUIDhistory", text);
	}

	public static void Load()
	{
		string @string = PlayerPrefs.GetString("Merlin-DebugMode-UUIDhistory", string.Empty);
		if (string.IsNullOrEmpty(@string))
		{
			return;
		}
		StringReader stringReader;
		IDisposable disposable = (stringReader = new StringReader(@string)) as IDisposable;
		try
		{
			entries.Clear();
			while (stringReader.Peek() >= 0)
			{
				string text = stringReader.ReadLine().Trim();
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split('\t');
					if (array.Length >= 3)
					{
						Entry item = new Entry(array[0], array[2], DateTime.Parse(array[1]));
						entries.Enqueue(item);
					}
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

	public static bool Add(string uuid, string name)
	{
		Load();
		Entry entry = findEntry(uuid);
		int result;
		if (entry != null)
		{
			entry.name = name;
			Save();
			result = 0;
		}
		else
		{
			entries.Enqueue(new Entry(uuid, name));
			while (((ICollection)entries).Count > 50)
			{
				entries.Dequeue();
			}
			Save();
			result = 1;
		}
		return (byte)result != 0;
	}

	private static Entry findEntry(string uuid)
	{
		object result;
		Entry entry;
		if (string.IsNullOrEmpty(uuid))
		{
			result = null;
		}
		else
		{
			foreach (Entry entry2 in entries)
			{
				if (!(entry2.uuid == uuid))
				{
					continue;
				}
				entry = entry2;
				goto IL_0061;
			}
			result = null;
		}
		goto IL_0062;
		IL_0062:
		return (Entry)result;
		IL_0061:
		result = entry;
		goto IL_0062;
	}

	public static void Clear()
	{
		entries.Clear();
		Save();
	}
}
