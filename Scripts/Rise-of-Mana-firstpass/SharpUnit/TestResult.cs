using System;
using System.Collections.Generic;

namespace SharpUnit;

public class TestResult
{
	private int m_numRun;

	private List<Exception> m_errors;

	public List<Exception> ErrorList => m_errors;

	public int NumRun => m_numRun;

	public int NumFailed => m_errors.Count;

	public TestResult()
	{
		m_errors = new List<Exception>();
	}

	~TestResult()
	{
		m_errors = null;
	}

	public void TestStarted()
	{
		m_numRun++;
	}

	public void TestFailed(Exception error)
	{
		if (error == null)
		{
			throw new Exception("Encountered invalid exception.");
		}
		m_errors.Add(error);
	}

	public string GetSummary()
	{
		return "Ran " + m_numRun + " tests, " + NumFailed + " failed.";
	}
}
