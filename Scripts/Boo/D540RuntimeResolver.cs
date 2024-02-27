using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class D540RuntimeResolver : D540DepthFirstTraverser
{
	private Type[] receiverTypes;

	private Component[] receivers;

	private readonly BindingFlags bindingFlags;

	[NonSerialized]
	private static Dictionary<Type, Dictionary<string, MethodInfo>> methodDict = new Dictionary<Type, Dictionary<string, MethodInfo>>();

	[NonSerialized]
	private static Dictionary<string, Type> typeCache = new Dictionary<string, Type>();

	public Type[] ReceiverTypes => receiverTypes;

	public Component[] Receivers => receivers;

	public D540RuntimeResolver(GameObject go)
	{
		bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		if (!(go != null))
		{
			throw new AssertionFailedException("go != null");
		}
		init(go);
	}

	private Dictionary<string, MethodInfo> getMethodDic(Type type)
	{
		if (type == null)
		{
			throw new AssertionFailedException("type != null");
		}
		Dictionary<string, MethodInfo> value = null;
		Dictionary<string, MethodInfo> result;
		if (methodDict.TryGetValue(type, out value))
		{
			result = value;
		}
		else
		{
			value = new Dictionary<string, MethodInfo>();
			int i = 0;
			MethodInfo[] methods = type.GetMethods(bindingFlags);
			for (int length = methods.Length; i < length; i = checked(i + 1))
			{
				value[methods[i].ToString()] = methods[i];
			}
			methodDict[type] = value;
			result = value;
		}
		return result;
	}

	private FieldInfo getFieldInfo(string fieldName, string decTypeName)
	{
		Type type = findType(decTypeName);
		if (type == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(decTypeName).Append("というクラスが見つかりません").ToString());
		}
		FieldInfo field = type.GetField(fieldName);
		if (field == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(fieldName).Append("というフィールドが").Append(decTypeName)
				.Append("に見つかりません")
				.ToString());
		}
		return field;
	}

	private MethodInfo getMethodInfo(string sig, string decTypeName)
	{
		Type type = findType(decTypeName);
		if (type == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(decTypeName).Append("というクラスが見つかりません").ToString());
		}
		Dictionary<string, MethodInfo> methodDic = getMethodDic(type);
		MethodInfo value = null;
		if (methodDic.TryGetValue(sig, out value))
		{
			return value;
		}
		throw new Exception(new StringBuilder("メソッド").Append(sig).Append("は").Append(type)
			.Append("に定義されていません")
			.ToString());
	}

	private void init(GameObject go)
	{
		Component[] components = go.GetComponents<Component>();
		Type[] array = Gen_array_macrosModule.GenArray<Type, Component>(components, (__D540RuntimeResolver_0024callable190_002457_19__)((Component _0024genarray_0024146) => _0024genarray_0024146.GetType()));
		System.Collections.Generic.List<Type> list = new System.Collections.Generic.List<Type>();
		System.Collections.Generic.List<Component> list2 = new System.Collections.Generic.List<Component>();
		int num = 0;
		int length = components.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Type type = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (type == null)
			{
				throw new AssertionFailedException("RuntimeResolver: receiver type must not be null!");
			}
			list.Add(type);
			list2.Add(components[RuntimeServices.NormalizeArrayIndex(components, index)]);
		}
		receiverTypes = (Type[])Builtins.array(typeof(Type), list);
		receivers = (Component[])Builtins.array(typeof(Component), list2);
	}

	public void dispose()
	{
		receiverTypes = null;
		receivers = null;
		methodDict = null;
		typeCache = null;
	}

	public override void caseOpeBuiltinFunc(D540OpeBuiltinFunc node)
	{
		Type type = findType(node.TypeName);
		if (type == null)
		{
			throw new Exception(new StringBuilder("cannot resolve type: ").Append(node.TypeName).ToString());
		}
		node.Type = type;
	}

	public override void caseOpeMotionID(D540OpeMotionID node)
	{
		if (node.HasMotionName)
		{
			node.MotionID = MotionID.ByName(node.Name);
			return;
		}
		int n = parseEnum(node.MotionTypeName, node.Name);
		node.MotionID = MotionID.ByType(n);
	}

	public override void caseOpeEnumOrString(D540OpeEnumOrString node)
	{
		Type type = findType(node.EnumOrStringValueTypeName);
		if (type == null)
		{
			throw new AssertionFailedException(new StringBuilder("unknown type '").Append(node.EnumOrStringValueTypeName).Append("'").ToString());
		}
		if (node.IsEnum)
		{
			int num = parseEnum(node.EnumTypeName, node.StringValue);
			node.setValue(type.GetMethod("ByEnum").Invoke(null, new object[1] { num }));
		}
		else
		{
			node.setValue(type.GetMethod("ByString").Invoke(null, new string[1] { node.StringValue }));
		}
	}

	private int parseEnum(string enumTypeName, string enumMemberName)
	{
		Type type = findType(enumTypeName);
		if (type == null)
		{
			throw new Exception(new StringBuilder().Append(enumTypeName).Append(" is not defined").ToString());
		}
		if (!type.IsEnum)
		{
			throw new Exception(new StringBuilder().Append(enumTypeName).Append(" is not enum type").ToString());
		}
		try
		{
			return RuntimeServices.UnboxInt32(Enum.Parse(type, enumMemberName));
		}
		catch (Exception)
		{
			throw new Exception(new StringBuilder().Append(enumTypeName).Append(" has no member '").Append(enumMemberName)
				.Append("'")
				.ToString());
		}
	}

	public override void caseOpeSelf(D540OpeSelf node)
	{
		if (receiverTypes == null)
		{
			return;
		}
		int num = 0;
		int length = receiverTypes.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			Type[] array = receiverTypes;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num2)].Name == node.SelfTypeName)
			{
				node.ReceiverIndex = num2;
				return;
			}
		}
		throw new Exception(new StringBuilder("type '").Append(node.SelfTypeName).Append("' could not be resolved").ToString());
	}

	public override void outOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		int num = -1;
		int num2 = 0;
		int length = ReceiverTypes.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			Type[] array = ReceiverTypes;
			Type type = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			MethodInfo method = type.GetMethod(node.MethodName, bindingFlags);
			if (method != null)
			{
				num = num3;
				node.Method = method;
				node.ReceiverIndex = ((!method.IsStatic) ? num : (-1));
				object[] argumentObjectsIfConstantAll = getArgumentObjectsIfConstantAll(node.Arguments);
				if (argumentObjectsIfConstantAll != null)
				{
					node.setConstantValueArguments(argumentObjectsIfConstantAll);
				}
				return;
			}
		}
		throw new Exception(new StringBuilder("could not find method '").Append(node.MethodName).Append("' in (").ToString() + Builtins.join(ReceiverTypes, " or ") + ")");
	}

	public override void outOpePropertyValue(D540OpePropertyValue node)
	{
		object[] array = resolveProperty(node.PropertyName);
		int receiverIndex = RuntimeServices.UnboxInt32(array[0]);
		object obj = array[1];
		if (!(obj is PropertyInfo))
		{
			obj = RuntimeServices.Coerce(obj, typeof(PropertyInfo));
		}
		PropertyInfo property = (PropertyInfo)obj;
		node.Property = property;
		node.ReceiverIndex = receiverIndex;
	}

	public override void outOpeField(D540OpeField node)
	{
		object[] array = resolveField(node.FieldName);
		int receiverIndex = RuntimeServices.UnboxInt32(array[0]);
		object obj = array[1];
		if (!(obj is FieldInfo))
		{
			obj = RuntimeServices.Coerce(obj, typeof(FieldInfo));
		}
		FieldInfo field = (FieldInfo)obj;
		node.Field = field;
		node.ReceiverIndex = receiverIndex;
	}

	public override void outOpeAssign(D540OpeAssign node)
	{
		D540OpeAssign.ELeftType leftType = node.LeftType;
		switch (leftType)
		{
		case D540OpeAssign.ELeftType.LOCAL:
			break;
		case D540OpeAssign.ELeftType.FIELD:
		{
			object[] array2 = resolveField(node.LeftVarName);
			int receiverIndex2 = RuntimeServices.UnboxInt32(array2[0]);
			object obj2 = array2[1];
			if (!(obj2 is FieldInfo))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(FieldInfo));
			}
			FieldInfo field = (FieldInfo)obj2;
			node.ReceiverIndex = receiverIndex2;
			node.Field = field;
			break;
		}
		case D540OpeAssign.ELeftType.PROPERTY:
		{
			object[] array = resolveProperty(node.LeftVarName);
			int receiverIndex = RuntimeServices.UnboxInt32(array[0]);
			object obj = array[1];
			if (!(obj is PropertyInfo))
			{
				obj = RuntimeServices.Coerce(obj, typeof(PropertyInfo));
			}
			PropertyInfo property = (PropertyInfo)obj;
			node.ReceiverIndex = receiverIndex;
			node.Property = property;
			break;
		}
		default:
			throw new Exception(new StringBuilder("unknown lefttype ").Append(leftType).Append(" of OpeAssign").ToString());
		}
	}

	public override void outOpeExtField(D540OpeExtField node)
	{
		node.Field = getFieldInfo(node.FieldName, node.DeclaringTypeName);
	}

	public override void outOpeAssignExtField(D540OpeAssignExtField node)
	{
		outOpeExtField(node);
	}

	public override void outOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		node.Method = getMethodInfo(node.MethodSignature, node.DeclaringTypeName);
		object[] argumentObjectsIfConstantAll = getArgumentObjectsIfConstantAll(node.Arguments);
		if (argumentObjectsIfConstantAll != null)
		{
			node.setConstantValueArguments(argumentObjectsIfConstantAll);
		}
	}

	private object[] getArgumentObjectsIfConstantAll(System.Collections.Generic.List<D540OpeCode> args)
	{
		System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
		int num = args.Count;
		object result;
		while (true)
		{
			if (num > 0)
			{
				num = checked(num - 1);
				D540OpeCode d540OpeCode = args[num];
				if (!d540OpeCode.IsValueNode)
				{
					result = null;
					break;
				}
				list.Add(d540OpeCode.Value);
				continue;
			}
			result = list.ToArray();
			break;
		}
		return (object[])result;
	}

	private Module findModule(string n)
	{
		int num = 0;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		int length = assemblies.Length;
		checked
		{
			object result;
			while (true)
			{
				int num2;
				Module[] modules;
				if (num < length)
				{
					num2 = 0;
					modules = assemblies[num].GetModules();
					int length2 = modules.Length;
					while (num2 < length2)
					{
						if (!(modules[num2].Name == n))
						{
							num2++;
							continue;
						}
						goto IL_004a;
					}
					num++;
					continue;
				}
				result = null;
				break;
				IL_004a:
				result = modules[num2];
				break;
			}
			return (Module)result;
		}
	}

	private Type findType(string typeFullName)
	{
		object result;
		if (string.IsNullOrEmpty(typeFullName))
		{
			result = null;
		}
		else
		{
			Type value = null;
			if (typeCache.TryGetValue(typeFullName, out value))
			{
				result = value;
			}
			else
			{
				int num = 0;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				int length = assemblies.Length;
				while (true)
				{
					if (num < length)
					{
						Type type = assemblies[num].GetType(typeFullName);
						if (type != null)
						{
							typeCache[typeFullName] = type;
							result = type;
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = null;
					break;
				}
			}
		}
		return (Type)result;
	}

	public object[] resolveField(string fieldName)
	{
		int num = -1;
		int num2 = 0;
		int length = ReceiverTypes.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		FieldInfo field = default(FieldInfo);
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			Type[] array = ReceiverTypes;
			Type type = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			field = type.GetField(fieldName, bindingFlags);
			if (field != null)
			{
				num = num3;
				break;
			}
		}
		if (num < 0)
		{
			throw new Exception(new StringBuilder("could not find field '").Append(fieldName).Append("' in these classes (").ToString() + Builtins.join(ReceiverTypes, "/") + ")");
		}
		return new object[2] { num, field };
	}

	public object[] resolveProperty(string propName)
	{
		int num = -1;
		int num2 = 0;
		int length = ReceiverTypes.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		PropertyInfo property = default(PropertyInfo);
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			Type[] array = ReceiverTypes;
			Type type = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			property = type.GetProperty(propName, bindingFlags);
			if (property != null)
			{
				num = num3;
				return new object[2] { num, property };
			}
		}
		throw new Exception(new StringBuilder("could not find property '").Append(property).Append("' in (").ToString() + Builtins.join(ReceiverTypes, "/") + ")");
	}

	internal Type _0024init_0024closure_00243795(Component _0024genarray_0024146)
	{
		return _0024genarray_0024146.GetType();
	}
}
