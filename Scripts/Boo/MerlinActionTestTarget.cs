using System;
using System.Text;
using UnityEngine;

[Serializable]
public class MerlinActionTestTarget : MonoBehaviour
{
	[Serializable]
	public class MotDefParam
	{
		public int a;

		public bool b;

		public int c;
	}

	[Serializable]
	public enum TestEnum
	{
		Ea,
		Eb,
		Ec,
		Edef
	}

	[Serializable]
	public class MotDefParam2
	{
		public bool loop;

		public string message;

		public int intValue;

		public float singleValue;

		public bool boolValueDefaultTrue;

		public string stringValue;

		public TestEnum enumValue;

		public MotDefParam2()
		{
			message = "<default>";
			intValue = 99999;
			singleValue = 999999f;
			boolValueDefaultTrue = true;
			stringValue = "<default>";
			enumValue = TestEnum.Edef;
		}

		public override string ToString()
		{
			return new StringBuilder("MotDefParam2: loop:").Append(loop).Append(" message:").Append(message)
				.Append(" intValue:")
				.Append((object)intValue)
				.Append(" singleValue:")
				.Append(singleValue)
				.Append(" boolValueDefaultTrue:")
				.Append(boolValueDefaultTrue)
				.Append(" stringValue:")
				.Append(stringValue)
				.Append(" enumValue:")
				.Append(enumValue)
				.ToString();
		}
	}

	[Serializable]
	public enum TestEnum2
	{
		ENUM_1,
		ENUM_2,
		ENUM_3
	}

	private string HOGE;

	private MotDefParam2 lastMotDefParam2;

	private int motDef2Counter;

	public int FOO => 5;

	public string FOOS => "hoge";

	public static string BAR => "string";

	public MotDefParam2 LastMotDefParam2 => lastMotDefParam2;

	public int MotDef2Counter => motDef2Counter;

	public void Awake()
	{
	}

	public void Update()
	{
	}

	public float foo(int a)
	{
		return checked(a * 10);
	}

	public static float sfoo(int a)
	{
		return checked(a * 10);
	}

	public void d540_motdef(MotDefParam a)
	{
	}

	public void d540_motdef2(MotDefParam2 a)
	{
		lastMotDefParam2 = a;
		checked
		{
			motDef2Counter++;
		}
	}

	public void testcommand1()
	{
	}

	public void testcommand2(int a)
	{
	}

	public void testcommand3(int a, string b)
	{
	}

	public void testcommand4(int a, string b, TestEnum2 e)
	{
	}
}
