using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[CompilerGlobalScope]
public sealed class ServerUtilModule
{
	private ServerUtilModule()
	{
	}

	public static Hashtable GetResultHashtable(string res)
	{
		Hashtable hashtable = new Hashtable();
		Hashtable result;
		if (!string.IsNullOrEmpty(res))
		{
			string[] array = res.Split('&');
			if (array.Length <= 0)
			{
				result = hashtable;
				goto IL_011a;
			}
			int i = 0;
			string[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				string[] array3 = array2[i].Split('=');
				if (array3.Length != 2)
				{
					continue;
				}
				string key = Uri.UnescapeDataString(array3[0]);
				string value = Uri.UnescapeDataString(array3[1]);
				object obj = hashtable[key];
				if (obj == null)
				{
					hashtable[key] = value;
					continue;
				}
				ArrayList arrayList = null;
				if (RuntimeServices.EqualityOperator(obj.GetType(), typeof(ArrayList)))
				{
					object obj2 = obj;
					if (!(obj2 is ArrayList))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(ArrayList));
					}
					arrayList = (ArrayList)obj2;
				}
				else
				{
					arrayList = new ArrayList();
					arrayList.Add(obj);
				}
				arrayList.Add(value);
				hashtable[key] = arrayList;
			}
		}
		result = hashtable;
		goto IL_011a;
		IL_011a:
		return result;
	}

	public static string HttpGetMethodURL(string url, Hashtable @params)
	{
		string text = HttpEncodedParameter(@params);
		return (!string.IsNullOrEmpty(text)) ? (url + "?" + text) : url;
	}

	public static string HttpEncodedParameter(Hashtable d)
	{
		List<string> list = new List<string>();
		IEnumerator enumerator = d.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			object obj = current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string lhs = Uri.EscapeDataString((string)obj);
			string rhs = MerlinEscapeDataString(new StringBuilder().Append(d[current]).ToString());
			list.Add(lhs + "=" + rhs);
		}
		return Builtins.join(list, '&');
	}

	public static string MerlinEscapeDataString(string d)
	{
		int i = 0;
		int num = 16384;
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			string text;
			for (; i < d.Length; i += text.Length)
			{
				text = RuntimeServices.Mid(d, i, i + num);
				stringBuilder.Append(Uri.EscapeDataString(text));
			}
			return stringBuilder.ToString();
		}
	}

	public static string GenerateUUID()
	{
		return "M" + (DateTime.UtcNow - DateTime.Parse("1900/1/1")).TotalSeconds + "-" + Guid.NewGuid();
	}

	public static string ArrayToDebugString<T>(T[] vals)
	{
		string value = typeof(T).ToString();
		string result;
		if (vals == null)
		{
			result = new StringBuilder().Append(value).Append(": <null>\n").ToString();
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(new StringBuilder().Append(value).Append("(length=").Append((object)vals.Length)
				.Append("):[\n")
				.ToString());
			int i = 0;
			for (int length = vals.Length; i < length; i = checked(i + 1))
			{
				stringBuilder.Append(new StringBuilder("  ").Append(vals[i]).Append("\n").ToString());
			}
			stringBuilder.Append("]\n");
			result = stringBuilder.ToString();
		}
		return result;
	}
}
