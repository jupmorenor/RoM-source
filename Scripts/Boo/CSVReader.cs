using System;
using System.Collections;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CSVReader
{
	[NonSerialized]
	private static Regex exp = new Regex("((?<=^|,)(?<field>)(?=,|$)|(?<field>[^\",\\r\\n]+)|\"(?<field>([^\"]|\"\")*)\")(,|(?<rowbreak>\\r\\n|\\n|$))");

	[NonSerialized]
	internal static Regex _0024re_002424727 = new Regex("\\n");

	public static List read(TextAsset t)
	{
		List list = new List();
		int i = 0;
		string[] array = _0024re_002424727.Split(t.text);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].StartsWith("#"))
			{
				continue;
			}
			MatchCollection matchCollection = exp.Matches(array[i]);
			List list2 = new List();
			IEnumerator enumerator = matchCollection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Match))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Match));
				}
				Match item = (Match)obj;
				list2.Add(item);
			}
			list.Add(list2);
		}
		return list;
	}
}
