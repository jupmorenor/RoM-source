using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SharpUnit;
using UnityEngine;

public class Unity3D_TestSuite : MonoBehaviour
{
	private List<ITestCase> m_tests;

	private TestResult _TestResult;

	public TestResult TestResult => _TestResult;

	public Unity3D_TestSuite()
	{
		m_tests = new List<ITestCase>();
	}

	~Unity3D_TestSuite()
	{
		m_tests = null;
	}

	public void AddAll(UnityTestCase test)
	{
		if (null == test)
		{
			throw new Exception("Invalid test case encountered.");
		}
		Type type = test.GetType();
		MethodInfo[] methods = type.GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			object[] customAttributes = methodInfo.GetCustomAttributes(typeof(UnitTest), inherit: false);
			foreach (object obj in customAttributes)
			{
				if (obj is Attribute)
				{
					GameObject gameObject = new GameObject("Test" + type.Name + "_" + methodInfo.Name);
					UnityTestCase unityTestCase = gameObject.AddComponent(type.Name) as UnityTestCase;
					unityTestCase.SetTestMethod(methodInfo.Name);
					m_tests.Add(unityTestCase);
				}
			}
		}
	}

	public void AddAll(TestCase test)
	{
		if (test == null)
		{
			throw new Exception("Invalid test case encountered.");
		}
		Type type = test.GetType();
		MethodInfo[] methods = type.GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			object[] customAttributes = methodInfo.GetCustomAttributes(typeof(UnitTest), inherit: false);
			foreach (object obj in customAttributes)
			{
				if (obj is Attribute)
				{
					ConstructorInfo[] constructors = type.GetConstructors();
					if (0 < constructors.Length)
					{
						TestCase testCase = constructors[0].Invoke(null) as TestCase;
						testCase.SetTestMethod(methodInfo.Name);
						m_tests.Add(testCase);
					}
				}
			}
		}
	}

	public IEnumerator Run(TestResult result)
	{
		foreach (ITestCase test in m_tests)
		{
			yield return StartCoroutine(test.Run(result));
			result = test.GetTestResult();
		}
		_TestResult = result;
	}
}
