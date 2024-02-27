using System;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SharpUnit;

public class TestCase : ITestCase
{
	private string m_testMethod;

	private Exception m_caughtEx;

	private TestResult _TestResult;

	public virtual void SetUp()
	{
	}

	public virtual void TearDown()
	{
	}

	public void SetTestMethod(string method)
	{
		m_testMethod = method;
	}

	public TestResult GetTestResult()
	{
		return _TestResult;
	}

	public IEnumerator Run(TestResult result)
	{
		if (m_testMethod == null)
		{
			throw new Exception("Invalid test method encountered, be sure to call TestCase::SetTestMethod()");
		}
		Type type = GetType();
		MethodInfo method = type.GetMethod(m_testMethod);
		if (method == null)
		{
			throw new Exception("Test method: " + m_testMethod + " does not exist in class: " + type.ToString());
		}
		if (result == null)
		{
			result = new TestResult();
		}
		SetUp();
		result.TestStarted();
		try
		{
			try
			{
				method.Invoke(this, null);
			}
			catch (TargetInvocationException caughtEx)
			{
				TargetInvocationException e = (TargetInvocationException)(m_caughtEx = caughtEx);
				if (Assert.Exception == null)
				{
					if (e.InnerException != null && typeof(TestException) == e.InnerException.GetType())
					{
						TestException te = e.InnerException as TestException;
						te.Description = string.Concat("Failed: ", GetType(), ".", m_testMethod, "()");
						if (te.StackFrame != null)
						{
							te.Description = te.Description + " in File: " + Path.GetFileName(te.StackFrame.GetFileName());
							te.Description = te.Description + " on Line: " + te.StackFrame.GetFileLineNumber();
						}
					}
					throw m_caughtEx.InnerException;
				}
				Assert.Equal(Assert.Exception, m_caughtEx.InnerException);
			}
			if (Assert.Exception != null && m_caughtEx == null)
			{
				Assert.NotNull(m_caughtEx, "Did not catch expected exception: " + Assert.Exception);
			}
			Debug.Log("[SharpUnit] " + type.Name + "." + method.Name + " runs ok");
		}
		catch (Exception ex)
		{
			result.TestFailed(ex);
			Debug.LogWarning("[SharpUnit] " + type.Name + "." + method.Name + " failed");
		}
		Assert.Exception = null;
		TearDown();
		_TestResult = result;
		yield break;
	}
}
