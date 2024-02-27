using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class JsonBase
{
	public static T CreateArrayFromJson<T>(object data)
	{
		if (!(data is ArrayList))
		{
			throw new Exception(new StringBuilder("与えられたjsonデータ(").Append(data.GetType()).Append(")はArrayListではありません").ToString());
		}
		Array array = CreateArrayFromJson(typeof(T), data as ArrayList);
		if (!(array is T))
		{
			throw new Exception(new StringBuilder().Append(data.GetType()).Append("のjsonを").Append(typeof(T))
				.Append("として生成できません(結果 ")
				.Append(array.GetType())
				.Append(")")
				.ToString());
		}
		return (T)((array is T) ? array : null);
	}

	public static object CreateFromJson(Type type, object data)
	{
		if (type == null)
		{
			throw new AssertionFailedException("type != null");
		}
		object result;
		if (data == null)
		{
			result = TypeConvert(data, type);
		}
		else
		{
			Type type2 = data.GetType();
			if (type.IsArray)
			{
				if (!RuntimeServices.EqualityOperator(type2, typeof(ArrayList)))
				{
					throw new Exception(new StringBuilder("配列でない").Append(type2).Append("(!= ").Append(typeof(ArrayList))
						.Append(")を")
						.Append(type)
						.Append("として生成しています\nJSON=\n")
						.ToString() + data);
				}
				result = CreateArrayFromJson(type, data as ArrayList);
			}
			else if (typeof(JsonBase).IsAssignableFrom(type))
			{
				if (!(data is Hashtable))
				{
					throw new Exception(new StringBuilder("ハッシュでないjson ").Append(type2).Append("を").Append(type)
						.Append("として生成しています(正解 = ")
						.Append(typeof(Hashtable))
						.Append(")")
						.ToString());
				}
				result = CreateJsonBaseFromJson(type, data as Hashtable);
			}
			else
			{
				result = TypeConvert(data, type);
			}
		}
		return result;
	}

	public static Array CreateArrayFromJson(Type type, ArrayList data)
	{
		if (!type.IsArray || !type.HasElementType)
		{
			throw new Exception(new StringBuilder().Append(type).Append("は配列型ではありません").ToString());
		}
		Type elementType = type.GetElementType();
		int count = data.Count;
		Array array = Array.CreateInstance(elementType, count);
		int num = 0;
		int num2 = count;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			array.SetValue(CreateFromJson(elementType, data[index]), index);
		}
		return array;
	}

	public static JsonBase CreateJsonBaseFromJson(Type type, Hashtable data)
	{
		object obj = Activator.CreateInstance(type);
		if (!(obj is JsonBase))
		{
			obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
		}
		JsonBase jsonBase = (JsonBase)obj;
		int i = 0;
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
		for (int length = fields.Length; i < length; i = checked(i + 1))
		{
			if (data.ContainsKey(fields[i].Name))
			{
				Type fieldType = fields[i].FieldType;
				object obj2 = data[fields[i].Name];
				if (obj2 != null)
				{
					object setVal = HashValueToMapValue(obj2, fieldType, fields[i]);
					SetValueToField(fields[i], jsonBase, setVal);
				}
				else if (fieldType.IsClass)
				{
					SetValueToField(fields[i], jsonBase, null);
				}
			}
		}
		return jsonBase;
	}

	private static object HashValueToMapValue(object jsonVal, Type type, FieldInfo finfo)
	{
		object obj = null;
		try
		{
			if (type.IsArray)
			{
				if (!(jsonVal is ArrayList))
				{
					throw new Exception(new StringBuilder().Append(finfo.DeclaringType).Append(".").Append(finfo.Name)
						.Append(" as ")
						.Append(type)
						.Append(" に配列ではない json '")
						.Append(jsonVal.GetType())
						.Append("' を代入しようとしています")
						.ToString());
				}
				obj = CreateArrayFromJson(type, jsonVal as ArrayList);
			}
			else
			{
				obj = CreateFromJson(type, jsonVal);
				if (obj != null)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return obj;
	}

	private static void SetValueToField(FieldInfo f, object obj, object setVal)
	{
		if (f == null)
		{
			throw new AssertionFailedException("f != null");
		}
		try
		{
			f.SetValue(obj, setVal);
		}
		catch (Exception ex)
		{
			Type fieldType = f.FieldType;
			throw ex;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(new StringBuilder("\n{ ").Append(GetType()).Append(":").ToString());
		Type type = GetType();
		int i = 0;
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
		for (int length = fields.Length; i < length; i = checked(i + 1))
		{
			Type fieldType = fields[i].FieldType;
			object value = fields[i].GetValue(this);
			if (fieldType.IsArray)
			{
				if (value is Array array)
				{
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append(" as ").Append(fieldType)
						.Append(" = [")
						.ToString());
					IEnumerator enumerator = array.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						stringBuilder.Append((current != null) ? current.ToString() : string.Empty);
					}
					stringBuilder.Append("],");
				}
				else
				{
					stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append(" as ").Append(fieldType)
						.Append(" = <<NULL?>>")
						.ToString());
				}
			}
			else
			{
				stringBuilder.Append(new StringBuilder().Append(fields[i].Name).Append(" as ").Append(fieldType)
					.Append(" = ")
					.Append(value)
					.Append(", ")
					.ToString());
			}
		}
		stringBuilder.Append("}, ");
		return stringBuilder.ToString();
	}

	public static object TypeConvert(object value, Type dstType)
	{
		object result;
		if (value == null)
		{
			result = (RuntimeServices.EqualityOperator(dstType, typeof(int)) ? ((object)0) : (RuntimeServices.EqualityOperator(dstType, typeof(long)) ? ((object)0L) : (RuntimeServices.EqualityOperator(dstType, typeof(ulong)) ? ((object)0L) : (RuntimeServices.EqualityOperator(dstType, typeof(string)) ? string.Empty : (RuntimeServices.EqualityOperator(dstType, typeof(float)) ? ((object)0) : (RuntimeServices.EqualityOperator(dstType, typeof(double)) ? ((object)0) : (RuntimeServices.EqualityOperator(dstType, typeof(bool)) ? ((object)false) : ((!RuntimeServices.EqualityOperator(dstType, typeof(BoxId))) ? null : ((object)BoxId.InvalidId)))))))));
		}
		else
		{
			Type type = value.GetType();
			if (RuntimeServices.EqualityOperator(type, dstType))
			{
				result = value;
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(string)))
			{
				result = value.ToString();
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(int)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj = value;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					result = intParse((string)obj);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(long)))
				{
					result = RuntimeServices.UnboxInt32(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = RuntimeServices.UnboxInt32(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(float)))
				{
					result = RuntimeServices.UnboxInt32(value);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(double)))
					{
						goto IL_097b;
					}
					result = RuntimeServices.UnboxInt32(value);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(BoxId)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj2 = value;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					result = new BoxId(longParse((string)obj2));
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = new BoxId(RuntimeServices.UnboxInt64(value));
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(long)))
				{
					result = new BoxId(RuntimeServices.UnboxInt64(value));
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = new BoxId(RuntimeServices.UnboxInt64(value));
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(double)))
				{
					result = new BoxId(RuntimeServices.UnboxInt64(value));
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(float)))
					{
						goto IL_097b;
					}
					result = new BoxId(RuntimeServices.UnboxInt64(value));
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(long)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj3 = value;
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					result = longParse((string)obj3);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = RuntimeServices.UnboxInt64(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = RuntimeServices.UnboxInt64(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(float)))
				{
					result = RuntimeServices.UnboxInt64(value);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(double)))
					{
						goto IL_097b;
					}
					result = RuntimeServices.UnboxInt64(value);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(ulong)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj4 = value;
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					result = ulongParse((string)obj4);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = RuntimeServices.UnboxUInt64(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = RuntimeServices.UnboxUInt64(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(float)))
				{
					result = RuntimeServices.UnboxUInt64(value);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(double)))
					{
						goto IL_097b;
					}
					result = RuntimeServices.UnboxUInt64(value);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(float)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj5 = value;
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					result = singleParse((string)obj5);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = RuntimeServices.UnboxSingle(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(long)))
				{
					result = RuntimeServices.UnboxSingle(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = RuntimeServices.UnboxSingle(value);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(double)))
					{
						goto IL_097b;
					}
					result = RuntimeServices.UnboxSingle(value);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(double)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj6 = value;
					if (!(obj6 is string))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(string));
					}
					result = doubleParse((string)obj6);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = RuntimeServices.UnboxDouble(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(long)))
				{
					result = RuntimeServices.UnboxDouble(value);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = RuntimeServices.UnboxDouble(value);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(float)))
					{
						goto IL_097b;
					}
					result = RuntimeServices.UnboxDouble(value);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(bool)))
			{
				if (RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					object obj7 = value;
					if (!(obj7 is string))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(string));
					}
					result = boolParse((string)obj7);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(int)))
				{
					result = !RuntimeServices.EqualityOperator(value, 0);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(long)))
				{
					result = !RuntimeServices.EqualityOperator(value, 0);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(ulong)))
				{
					result = !RuntimeServices.EqualityOperator(value, 0);
				}
				else if (RuntimeServices.EqualityOperator(type, typeof(float)))
				{
					result = !RuntimeServices.EqualityOperator(value, 0);
				}
				else
				{
					if (!RuntimeServices.EqualityOperator(type, typeof(double)))
					{
						goto IL_097b;
					}
					result = !RuntimeServices.EqualityOperator(value, 0);
				}
			}
			else if (RuntimeServices.EqualityOperator(dstType, typeof(DateTime)))
			{
				if (!RuntimeServices.EqualityOperator(type, typeof(string)))
				{
					goto IL_097b;
				}
				object obj8 = value;
				if (!(obj8 is string))
				{
					obj8 = RuntimeServices.Coerce(obj8, typeof(string));
				}
				if (((string)obj8).ToUpper().EndsWith("Z"))
				{
					object obj9 = value;
					if (!(obj9 is string))
					{
						obj9 = RuntimeServices.Coerce(obj9, typeof(string));
					}
					result = DateTime.Parse((string)obj9).ToUniversalTime();
				}
				else
				{
					result = DateTime.Parse(value + "Z").ToUniversalTime();
				}
			}
			else if (dstType.IsAssignableFrom(type))
			{
				result = value;
			}
			else
			{
				if (!RuntimeServices.EqualityOperator(dstType, typeof(Hashtable)) || !RuntimeServices.EqualityOperator(type, typeof(Hashtable)))
				{
					goto IL_097b;
				}
				result = value;
			}
		}
		goto IL_0983;
		IL_097b:
		castError(value, dstType);
		result = null;
		goto IL_0983;
		IL_0983:
		return result;
	}

	private static int intParse(string v)
	{
		return (!string.IsNullOrEmpty(v)) ? int.Parse(v) : 0;
	}

	private static long longParse(string v)
	{
		return (!string.IsNullOrEmpty(v)) ? long.Parse(v) : 0;
	}

	private static ulong ulongParse(string v)
	{
		return (!string.IsNullOrEmpty(v)) ? ulong.Parse(v) : 0u;
	}

	private static float singleParse(string v)
	{
		return (!string.IsNullOrEmpty(v)) ? float.Parse(v) : 0f;
	}

	private static double doubleParse(string v)
	{
		return (!string.IsNullOrEmpty(v)) ? double.Parse(v) : 0.0;
	}

	private static bool boolParse(string v)
	{
		return !string.IsNullOrEmpty(v) && bool.Parse(v);
	}

	private static void castError(object val, Type dstType)
	{
		string message = new StringBuilder("could not convert '").Append(val).Append(" as ").Append(val.GetType())
			.Append("' to '")
			.Append(dstType)
			.Append("'")
			.ToString();
		throw new Exception(message);
	}
}
