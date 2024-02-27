using System;
using System.IO;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540BinaryVisitor
{
	private string[] stringTable;

	private MemoryStream stream;

	[NonSerialized]
	private static bool IsLitteEndian;

	[NonSerialized]
	private static byte[] singleBuf = new byte[4];

	public string[] StringTable => stringTable;

	public void traverse(byte[] data)
	{
		if (data == null)
		{
			throw new AssertionFailedException("data != null");
		}
		checkEndian();
		stream = new MemoryStream(data);
		traverseHeader();
		traverseStringTable();
		traverseBody();
	}

	private void checkEndian()
	{
		int value = 123;
		byte[] bytes = BitConverter.GetBytes(value);
		IsLitteEndian = bytes[0] == 123;
	}

	private void traverseHeader()
	{
		char c = (char)checked((ushort)unchecked((int)nextByte()));
		char c2 = (char)checked((ushort)unchecked((int)nextByte()));
		char c3 = (char)checked((ushort)unchecked((int)nextByte()));
		char c4 = (char)checked((ushort)unchecked((int)nextByte()));
		if (c != 'D')
		{
			throw new AssertionFailedException("hd == char('D')");
		}
		if (c2 != '5')
		{
			throw new AssertionFailedException("h5 == char('5')");
		}
		if (c3 != '4')
		{
			throw new AssertionFailedException("h4 == char('4')");
		}
		if (c4 != '0')
		{
			throw new AssertionFailedException("h0 == char('0')");
		}
		int version = nextByte();
		nextByte();
		nextByte();
		nextByte();
		doHeader(version);
	}

	private void traverseStringTable()
	{
		byte[] array = new byte[65536];
		int num = nextInt();
		string[] array2 = new string[checked(num + 1)];
		array2[0] = null;
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
			int count = nextShort();
			stream.Read(array, 0, count);
			array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num4 + 1))] = Encoding.UTF8.GetString(array, 0, count);
		}
		stringTable = array2;
		doStringTable(array2);
	}

	private void traverseBody()
	{
		int num = checked((int)(stream.Length - stream.Position));
		byte[] array = new byte[num];
		stream.Read(array, 0, num);
		analyseCode(array, 0, num);
	}

	private int analyseCode(byte[] buf, int top, int length)
	{
		int cp = top;
		int num = checked(cp + length);
		int num2 = 0;
		while (cp < num)
		{
			D540OpeCodeId d540OpeCodeId = (D540OpeCodeId)(int)buf[RuntimeServices.NormalizeArrayIndex(buf, cp)];
			checked
			{
				cp++;
				num2++;
			}
			switch (d540OpeCodeId)
			{
			case D540OpeCodeId.OpeNop:
				doOpeNop();
				break;
			case D540OpeCodeId.OpeCompound:
			{
				inOpeCompound();
				int codeNum = analyseBlockAndProgressCP(buf, ref cp);
				outOpeCompound(codeNum);
				break;
			}
			case D540OpeCodeId.OpeEcho:
			{
				string stringAndProgressCP15 = getStringAndProgressCP(buf, ref cp);
				doOpeEcho(stringAndProgressCP15);
				break;
			}
			case D540OpeCodeId.OpeSelf:
			{
				string stringAndProgressCP14 = getStringAndProgressCP(buf, ref cp);
				doOpeSelf(stringAndProgressCP14);
				break;
			}
			case D540OpeCodeId.OpePrint:
				analyseBlockAndProgressCP(buf, ref cp);
				doOpePrint();
				break;
			case D540OpeCodeId.OpeSlicing:
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeSlicing();
				break;
			case D540OpeCodeId.OpeBinary:
			{
				D540OpeBinary.EOpe @operator = (D540OpeBinary.EOpe)(int)buf[RuntimeServices.NormalizeArrayIndex(buf, checked(cp++))];
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeBinary(@operator);
				break;
			}
			case D540OpeCodeId.OpeUnary:
			{
				D540OpeUnary.EOpe operator2 = (D540OpeUnary.EOpe)(int)buf[RuntimeServices.NormalizeArrayIndex(buf, checked(cp++))];
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeUnary(operator2);
				break;
			}
			case D540OpeCodeId.OpeDup:
				doOpeDup();
				break;
			case D540OpeCodeId.OpePrefab:
			{
				string stringAndProgressCP12 = getStringAndProgressCP(buf, ref cp);
				doOpePrefab(stringAndProgressCP12);
				break;
			}
			case D540OpeCodeId.OpeIfElse:
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeIfElse();
				break;
			case D540OpeCodeId.OpeInvokeMethod:
			{
				string stringAndProgressCP13 = getStringAndProgressCP(buf, ref cp);
				byte byteAndProgressCP = getByteAndProgressCP(buf, ref cp);
				int num9 = 0;
				int num10 = byteAndProgressCP;
				if (num10 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num9 < num10)
				{
					int num11 = num9;
					num9++;
					analyseBlockAndProgressCP(buf, ref cp);
				}
				doOpeInvokeMethod(stringAndProgressCP13, byteAndProgressCP);
				break;
			}
			case D540OpeCodeId.OpeInvokeExtMethod:
			{
				string stringAndProgressCP13 = getStringAndProgressCP(buf, ref cp);
				string stringAndProgressCP10 = getStringAndProgressCP(buf, ref cp);
				bool boolAndProgressCP4 = getBoolAndProgressCP(buf, ref cp);
				if (boolAndProgressCP4)
				{
					analyseBlockAndProgressCP(buf, ref cp);
				}
				byte byteAndProgressCP = getByteAndProgressCP(buf, ref cp);
				int num6 = 0;
				int num7 = byteAndProgressCP;
				if (num7 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num6 < num7)
				{
					int num8 = num6;
					num6++;
					analyseBlockAndProgressCP(buf, ref cp);
				}
				doOpeInvokeExtMethod(stringAndProgressCP13, stringAndProgressCP10, byteAndProgressCP, boolAndProgressCP4);
				break;
			}
			case D540OpeCodeId.OpeArrayLiteral:
			{
				int intAndProgressCP2 = getIntAndProgressCP(buf, ref cp);
				int num3 = 0;
				int num4 = intAndProgressCP2;
				if (num4 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num3 < num4)
				{
					int num5 = num3;
					num3++;
					analyseBlockAndProgressCP(buf, ref cp);
				}
				doOpeArrayLiteral(intAndProgressCP2);
				break;
			}
			case D540OpeCodeId.OpePropertyValue:
			{
				string stringAndProgressCP11 = getStringAndProgressCP(buf, ref cp);
				doOpePropertyValue(stringAndProgressCP11);
				break;
			}
			case D540OpeCodeId.OpeField:
			{
				string stringAndProgressCP9 = getStringAndProgressCP(buf, ref cp);
				doOpeField(stringAndProgressCP9);
				break;
			}
			case D540OpeCodeId.OpeExtField:
			{
				string stringAndProgressCP9 = getStringAndProgressCP(buf, ref cp);
				string stringAndProgressCP10 = getStringAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeExtField(stringAndProgressCP9, stringAndProgressCP10);
				break;
			}
			case D540OpeCodeId.OpeAssignExtField:
			{
				string stringAndProgressCP9 = getStringAndProgressCP(buf, ref cp);
				string stringAndProgressCP10 = getStringAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeAssignExtField(stringAndProgressCP9, stringAndProgressCP10);
				break;
			}
			case D540OpeCodeId.OpeCast:
			{
				D540OpeCast.EOpe ope = (D540OpeCast.EOpe)(int)buf[RuntimeServices.NormalizeArrayIndex(buf, checked(cp++))];
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeCast(ope);
				break;
			}
			case D540OpeCodeId.OpeExprStatement:
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeExprStatement();
				break;
			case D540OpeCodeId.OpeWhile:
				analyseBlockAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeWhile();
				break;
			case D540OpeCodeId.OpeDeclVar:
			{
				string stringAndProgressCP8 = getStringAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeDeclVar(stringAndProgressCP8);
				break;
			}
			case D540OpeCodeId.OpeAssign:
			{
				D540OpeAssign.ELeftType leftType = (D540OpeAssign.ELeftType)(int)buf[RuntimeServices.NormalizeArrayIndex(buf, checked(cp++))];
				string stringAndProgressCP8 = getStringAndProgressCP(buf, ref cp);
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeAssign(leftType, stringAndProgressCP8);
				break;
			}
			case D540OpeCodeId.OpeLocalVar:
			{
				string stringAndProgressCP8 = getStringAndProgressCP(buf, ref cp);
				doOpeLocalVar(stringAndProgressCP8);
				break;
			}
			case D540OpeCodeId.OpeBuiltinFunc:
			{
				string stringAndProgressCP7 = getStringAndProgressCP(buf, ref cp);
				doOpeBuiltinFunc(stringAndProgressCP7);
				break;
			}
			case D540OpeCodeId.OpeMotionID:
			{
				string stringAndProgressCP5 = getStringAndProgressCP(buf, ref cp);
				bool boolAndProgressCP3 = getBoolAndProgressCP(buf, ref cp);
				if (boolAndProgressCP3)
				{
					doOpeMotionID(stringAndProgressCP5, boolAndProgressCP3, null);
					break;
				}
				string stringAndProgressCP6 = getStringAndProgressCP(buf, ref cp);
				doOpeMotionID(stringAndProgressCP5, boolAndProgressCP3, stringAndProgressCP6);
				break;
			}
			case D540OpeCodeId.OpeEnumOrString:
			{
				string stringAndProgressCP2 = getStringAndProgressCP(buf, ref cp);
				bool boolAndProgressCP2 = getBoolAndProgressCP(buf, ref cp);
				string stringAndProgressCP3 = getStringAndProgressCP(buf, ref cp);
				string stringAndProgressCP4 = getStringAndProgressCP(buf, ref cp);
				doOpeEnumOrString(stringAndProgressCP2, boolAndProgressCP2, stringAndProgressCP3, stringAndProgressCP4);
				break;
			}
			case D540OpeCodeId.OpeValue:
				doOpeValue();
				break;
			case D540OpeCodeId.OpeValueInt:
			{
				int intAndProgressCP = getIntAndProgressCP(buf, ref cp);
				doOpeValueInt(intAndProgressCP);
				break;
			}
			case D540OpeCodeId.OpeValueObject:
				throw new Exception("ヤヴァくね？ used OpeValueObject");
			case D540OpeCodeId.OpeValueSingle:
			{
				float singleAndProgressCP4 = getSingleAndProgressCP(buf, ref cp);
				doOpeValueSingle(singleAndProgressCP4);
				break;
			}
			case D540OpeCodeId.OpeValueString:
			{
				string stringAndProgressCP = getStringAndProgressCP(buf, ref cp);
				doOpeValueString(stringAndProgressCP);
				break;
			}
			case D540OpeCodeId.OpeValueVector2:
			{
				float singleAndProgressCP = getSingleAndProgressCP(buf, ref cp);
				float singleAndProgressCP2 = getSingleAndProgressCP(buf, ref cp);
				doOpeValueVector2(new Vector2(singleAndProgressCP, singleAndProgressCP2));
				break;
			}
			case D540OpeCodeId.OpeValueVector3:
			{
				float singleAndProgressCP = getSingleAndProgressCP(buf, ref cp);
				float singleAndProgressCP2 = getSingleAndProgressCP(buf, ref cp);
				float singleAndProgressCP3 = getSingleAndProgressCP(buf, ref cp);
				doOpeValueVector3(new Vector3(singleAndProgressCP, singleAndProgressCP2, singleAndProgressCP3));
				break;
			}
			case D540OpeCodeId.OpeValueBool:
			{
				bool boolAndProgressCP = getBoolAndProgressCP(buf, ref cp);
				doOpeValueBool(boolAndProgressCP);
				break;
			}
			case D540OpeCodeId.OpeAssert:
				analyseBlockAndProgressCP(buf, ref cp);
				doOpeAssert();
				break;
			default:
				throw new Exception(new StringBuilder("unknown ope code: ").Append(d540OpeCodeId).ToString());
			case D540OpeCodeId.OpeExecBlock:
				break;
			}
		}
		return num2;
	}

	private int analyseBlockAndProgressCP(byte[] buf, ref int cp)
	{
		int @int = getInt(buf, cp, 4);
		checked
		{
			int result = analyseCode(buf, cp + 4, @int - 4);
			cp += @int;
			return result;
		}
	}

	private byte nextByte()
	{
		return nextByte(stream);
	}

	private byte nextByte(MemoryStream strm)
	{
		return checked((byte)strm.ReadByte());
	}

	private int nextInt()
	{
		return nextInt(stream);
	}

	private int nextInt(MemoryStream strm)
	{
		int num = strm.ReadByte();
		int num2 = strm.ReadByte();
		int num3 = strm.ReadByte();
		int num4 = strm.ReadByte();
		return num | (num2 << 8) | (num3 << 16) | (num4 << 24);
	}

	private int nextShort()
	{
		return nextShort(stream);
	}

	private int nextShort(MemoryStream strm)
	{
		int num = strm.ReadByte();
		int num2 = strm.ReadByte();
		return num | (num2 << 8);
	}

	private int getInt(byte[] buf, int offset, int length)
	{
		int num = 0;
		int num2 = 0;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			num |= checked(buf[RuntimeServices.NormalizeArrayIndex(buf, offset + num3)] << 8 * num3);
		}
		return num;
	}

	private string getStringAndProgressCP(byte[] buf, ref int cp)
	{
		int @int = getInt(buf, cp, 2);
		if (0 > @int || @int >= stringTable.Length)
		{
			throw new AssertionFailedException("(0 <= strId) and (strId < len(stringTable))");
		}
		checked
		{
			cp += 2;
			string[] array = stringTable;
			return array[RuntimeServices.NormalizeArrayIndex(array, @int)];
		}
	}

	private int getIntAndProgressCP(byte[] buf, ref int cp)
	{
		int @int = getInt(buf, cp, 4);
		checked
		{
			cp += 4;
			return @int;
		}
	}

	private float getSingleAndProgressCP(byte[] buf, ref int cp)
	{
		checked
		{
			singleBuf[0] = buf[RuntimeServices.NormalizeArrayIndex(buf, cp + 0)];
			singleBuf[1] = buf[RuntimeServices.NormalizeArrayIndex(buf, cp + 1)];
			singleBuf[2] = buf[RuntimeServices.NormalizeArrayIndex(buf, cp + 2)];
			singleBuf[3] = buf[RuntimeServices.NormalizeArrayIndex(buf, cp + 3)];
			if (!IsLitteEndian)
			{
				_swap(ref singleBuf[0], ref singleBuf[3]);
				_swap(ref singleBuf[1], ref singleBuf[2]);
			}
			cp += 4;
			return BitConverter.ToSingle(singleBuf, 0);
		}
	}

	private static void _swap(ref byte a, ref byte b)
	{
		int num = a;
		a = b;
		b = checked((byte)num);
	}

	private bool getBoolAndProgressCP(byte[] buf, ref int cp)
	{
		return getByteAndProgressCP(buf, ref cp) != 0;
	}

	private byte getByteAndProgressCP(byte[] buf, ref int cp)
	{
		byte result = buf[RuntimeServices.NormalizeArrayIndex(buf, cp)];
		checked
		{
			cp++;
			return result;
		}
	}

	protected virtual void doHeader(int version)
	{
	}

	protected virtual void doStringTable(string[] tbl)
	{
	}

	protected virtual void doOpeCode()
	{
	}

	protected virtual void doOpeNop()
	{
	}

	protected virtual void doOpeExecBlock()
	{
	}

	protected virtual void inOpeCompound()
	{
	}

	protected virtual void outOpeCompound(int codeNum)
	{
	}

	protected virtual void doOpeEcho(string msg)
	{
	}

	protected virtual void doOpeSelf(string selfTypeName)
	{
	}

	protected virtual void doOpePrint()
	{
	}

	protected virtual void doOpeSlicing()
	{
	}

	protected virtual void doOpeBinary(D540OpeBinary.EOpe @operator)
	{
	}

	protected virtual void doOpeUnary(D540OpeUnary.EOpe @operator)
	{
	}

	protected virtual void doOpeDup()
	{
	}

	protected virtual void doOpePrefab(string prefabName)
	{
	}

	protected virtual void doOpeIfElse()
	{
	}

	protected virtual void doOpeInvokeMethod(string methodName, int argNum)
	{
	}

	protected virtual void doOpeInvokeExtMethod(string methodSignature, string declType, int argNum, bool withTarget)
	{
	}

	protected virtual void doOpeArrayLiteral(int elmNum)
	{
	}

	protected virtual void doOpePropertyValue(string propertyName)
	{
	}

	protected virtual void doOpeField(string fieldName)
	{
	}

	protected virtual void doOpeExtField(string fieldName, string declType)
	{
	}

	protected virtual void doOpeAssignExtField(string fieldName, string declType)
	{
	}

	protected virtual void doOpeCast(D540OpeCast.EOpe ope)
	{
	}

	protected virtual void doOpeExprStatement()
	{
	}

	protected virtual void doOpeWhile()
	{
	}

	protected virtual void doOpeDeclVar(string varName)
	{
	}

	protected virtual void doOpeAssign(D540OpeAssign.ELeftType leftType, string varName)
	{
	}

	protected virtual void doOpeLocalVar(string varName)
	{
	}

	protected virtual void doOpeBuiltinFunc(string typeName)
	{
	}

	protected virtual void doOpeMotionID(string motName, bool hasMotionName, string motionTypeName)
	{
	}

	protected virtual void doOpeEnumOrString(string stringValue, bool isEnum, string enumTypeName, string enumOrStringValueTypeName)
	{
	}

	protected virtual void doOpeValue()
	{
	}

	protected virtual void doOpeValueInt(int value)
	{
	}

	protected virtual void doOpeValueObject(object value)
	{
	}

	protected virtual void doOpeValueSingle(float value)
	{
	}

	protected virtual void doOpeValueString(string value)
	{
	}

	protected virtual void doOpeValueVector2(Vector2 value)
	{
	}

	protected virtual void doOpeValueVector3(Vector3 value)
	{
	}

	protected virtual void doOpeValueBool(bool value)
	{
	}

	protected virtual void doOpeAssert()
	{
	}
}
