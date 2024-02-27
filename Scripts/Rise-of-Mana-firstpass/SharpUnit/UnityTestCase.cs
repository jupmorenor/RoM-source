using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace SharpUnit;

public class UnityTestCase : MonoBehaviour, ITestCase
{
	private string m_testMethod;

	private Exception m_caughtEx;

	private TestResult _TestResult;

	private Unity3D_TestSuite _runner;

	protected bool _Failed = true;

	protected TestException _Exception;

	protected Unity3D_TestSuite runner
	{
		get
		{
			if (null == _runner)
			{
				_runner = GameObject.Find("TestRunner").GetComponent<Unity3D_TestSuite>();
			}
			return _runner;
		}
	}

	public TestResult GetTestResult()
	{
		return _TestResult;
	}

	protected void MarkAsFailure(TestException e)
	{
		_Failed = true;
		_Exception = e;
	}

	protected void DoneTesting()
	{
		_Failed = false;
	}

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
		yield return StartCoroutine((IEnumerator)method.Invoke(this, null));
		if (_Exception != null)
		{
			result.TestFailed(_Exception);
			Debug.LogWarning("[SharpUnit] " + type.Name + "." + method.Name + " failed");
		}
		else if (_Failed)
		{
			result.TestFailed(new TestException("DoneTesting for " + type.Name + "." + method.Name + " not called."));
			Debug.LogWarning("[SharpUnit] " + type.Name + "." + method.Name + " might be failed");
		}
		else
		{
			Debug.Log("[SharpUnit] " + type.Name + "." + method.Name + " runs ok");
		}
		Assert.Exception = null;
		TearDown();
		_TestResult = result;
	}
}
