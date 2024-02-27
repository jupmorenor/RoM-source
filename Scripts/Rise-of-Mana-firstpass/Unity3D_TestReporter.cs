using System;
using SharpUnit;
using UnityEngine;

public class Unity3D_TestReporter : TestReporter
{
	protected override void LogSummary()
	{
		if (base.Result == null)
		{
			Debug.LogWarning("No test results to report, did you add tests to the test suite?");
		}
		else
		{
			Debug.Log(base.Result.GetSummary());
		}
	}

	protected override void LogFailure(Exception error)
	{
		if (error != null)
		{
			string text = string.Empty;
			if (typeof(TestException) == error.GetType())
			{
				TestException ex = error as TestException;
				text = ex.Description;
			}
			Debug.LogError(text + "\n" + error);
		}
	}
}
