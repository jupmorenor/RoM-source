using System;

namespace SharpUnit;

public class Assert
{
	private static Exception ms_exception;

	public static Exception Exception
	{
		get
		{
			return ms_exception;
		}
		set
		{
			ms_exception = value;
		}
	}

	public static void ExpectException(Exception ex)
	{
		ms_exception = ex;
	}

	public static void True(bool boolean)
	{
		if (!boolean)
		{
			throw new TestException("Expected True, got False.");
		}
	}

	public static void True(bool boolean, string msg)
	{
		if (!boolean)
		{
			throw new TestException(msg);
		}
	}

	public static void False(bool boolean)
	{
		if (boolean)
		{
			throw new TestException("Expected False, got True.");
		}
	}

	public static void False(bool boolean, string msg)
	{
		if (boolean)
		{
			throw new TestException(msg);
		}
	}

	public static void Null(object obj)
	{
		if (obj != null)
		{
			throw new TestException("Expected Null object, got " + obj);
		}
	}

	public static void Null(object obj, string msg)
	{
		if (obj != null)
		{
			throw new TestException(msg);
		}
	}

	public static void NotNull(object obj)
	{
		if (obj == null)
		{
			throw new TestException("The object is null.");
		}
	}

	public static void NotNull(object obj, string msg)
	{
		if (obj == null)
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(int wanted, int got)
	{
		if (wanted != got)
		{
			throw new TestException("Expected " + wanted + ", Got " + got);
		}
	}

	public static void Equal(int wanted, int got, string msg)
	{
		if (wanted != got)
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(float wanted, float got)
	{
		if (!(Math.Abs(wanted - got) <= float.Epsilon))
		{
			throw new TestException("Expected " + wanted + ", Got " + got);
		}
	}

	public static void Equal(float wanted, float got, string msg)
	{
		if (!(Math.Abs(wanted - got) <= float.Epsilon))
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(string wanted, string got)
	{
		if (wanted != got)
		{
			throw new TestException("Expected \"" + wanted + "\", Got \"" + got + "\"");
		}
	}

	public static void Equal(string wanted, string got, string msg)
	{
		if (wanted != got)
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(bool wanted, bool got)
	{
		if (wanted != got)
		{
			throw new TestException("Expected " + wanted + ", Got " + got);
		}
	}

	public static void Equal(bool wanted, bool got, string msg)
	{
		if (wanted != got)
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(Exception wanted, Exception got)
	{
		if (wanted.GetType() != got.GetType() || wanted.Message != got.Message)
		{
			throw new TestException(string.Concat("Exceptions do not match.\n\tExpected ", wanted, ",\n\tGot ", got));
		}
	}

	public static void Equal(Exception wanted, Exception got, string msg)
	{
		if (wanted.GetType() != got.GetType() || wanted.Message != got.Message)
		{
			throw new TestException(msg);
		}
	}

	public static void Equal(object wanted, object got)
	{
		if (wanted != got)
		{
			throw new TestException(string.Concat("Expected ", wanted, ", Got ", got));
		}
	}

	public static void Equal(object wanted, object got, string msg)
	{
		if (wanted != got)
		{
			throw new TestException(msg);
		}
	}
}
