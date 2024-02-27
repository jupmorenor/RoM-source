using System;

namespace SharpUnit;

public class TestReporter
{
	protected TestResult m_result;

	protected TestResult Result => m_result;

	public virtual void LogResults(TestResult result)
	{
		m_result = result;
		LogSummary();
		if (m_result == null)
		{
			return;
		}
		foreach (Exception error in m_result.ErrorList)
		{
			LogFailure(error);
		}
	}

	protected virtual void LogSummary()
	{
		if (m_result == null)
		{
			Console.WriteLine("No test results to report, did you add test cases to the test suite?");
		}
		else
		{
			Console.WriteLine(m_result.GetSummary() + "\n");
		}
	}

	protected virtual void LogFailure(Exception error)
	{
		if (error != null)
		{
			if (typeof(TestException) == error.GetType())
			{
				TestException ex = error as TestException;
				Console.WriteLine(ex.Description);
			}
			Console.WriteLine(string.Concat(error, "\n"));
		}
	}
}
