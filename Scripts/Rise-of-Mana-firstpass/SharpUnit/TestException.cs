using System;
using System.Diagnostics;

namespace SharpUnit;

public class TestException : Exception
{
	private string m_desc;

	private StackFrame m_frame;

	public string Description
	{
		get
		{
			return m_desc;
		}
		set
		{
			m_desc = value;
		}
	}

	public StackFrame StackFrame => m_frame;

	public TestException(string msg)
		: base(msg)
	{
		int num = 2;
		StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
		if (stackTrace == null)
		{
			return;
		}
		StackFrame stackFrame = null;
		for (int i = 0; i < stackTrace.FrameCount; i++)
		{
			if (i == num)
			{
				stackFrame = stackTrace.GetFrame(i);
				if (stackFrame != null)
				{
					m_frame = stackFrame;
					break;
				}
			}
		}
	}
}
