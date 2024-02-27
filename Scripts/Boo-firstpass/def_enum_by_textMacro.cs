using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class def_enum_by_textMacro : LexicalInfoPreservingGeneratorMacro
{
	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		ExpressionCollection arguments = mc.Arguments;
		if (arguments.Count != 2)
		{
			throw new AssertionFailedException("args.Count == 2");
		}
		ReferenceExpression referenceExpression = arguments[0] as ReferenceExpression;
		StringLiteralExpression stringLiteralExpression = arguments[1] as StringLiteralExpression;
		if (referenceExpression == null || stringLiteralExpression == null)
		{
			throw new AssertionFailedException("(a1 != null) and (a2 != null)");
		}
		string name = referenceExpression.Name;
		string value = stringLiteralExpression.Value;
		try
		{
			StreamReader streamReader;
			IDisposable disposable = (streamReader = new StreamReader(value)) as IDisposable;
			try
			{
				Boo.Lang.List<string> list = new Boo.Lang.List<string>();
				Boo.Lang.List<int> list2 = new Boo.Lang.List<int>();
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine();
					string[] array = text.Split(',');
					if (array.Length < 3)
					{
						throw new AssertionFailedException("toks.Length >= 3");
					}
					if (string.IsNullOrEmpty(array[0]))
					{
						throw new AssertionFailedException("not string.IsNullOrEmpty(toks[0])");
					}
					if (string.IsNullOrEmpty(array[2]))
					{
						throw new AssertionFailedException("not string.IsNullOrEmpty(toks[2])");
					}
					list.Add(array[0]);
					list2.Add(int.Parse(array[2]));
				}
				return (IEnumerable<Node>)genEnumCode(name, (string[])Builtins.array(typeof(string), list), (int[])Builtins.array(typeof(int), list2));
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
			throw new Exception(new StringBuilder("Cannot open/read ").Append(value).Append(" to define enum ").Append(name)
				.ToString());
		}
	}

	public EnumDefinition genEnumCode(string enumTypeName, string[] enumNames, int[] enumValues)
	{
		EnumDefinition enumDefinition = new EnumDefinition();
		string text2 = (enumDefinition.Name = enumTypeName);
		EnumDefinition enumDefinition2 = enumDefinition;
		Builtins.ZipEnumerator zipEnumerator = Builtins.zip(enumNames, enumValues);
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
				object obj2 = array[0];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string text3 = (string)obj2;
				int num = RuntimeServices.UnboxInt32(array[1]);
				IntegerLiteralExpression integerLiteralExpression = new IntegerLiteralExpression();
				long num3 = (integerLiteralExpression.Value = num);
				IntegerLiteralExpression integerLiteralExpression2 = integerLiteralExpression;
				TypeMemberCollection members = enumDefinition2.Members;
				EnumMember enumMember = new EnumMember();
				string text5 = (enumMember.Name = text3);
				Expression expression2 = (enumMember.Initializer = integerLiteralExpression2);
				members.Add(enumMember);
			}
			return enumDefinition2;
		}
		finally
		{
			((IDisposable)zipEnumerator).Dispose();
		}
	}
}
