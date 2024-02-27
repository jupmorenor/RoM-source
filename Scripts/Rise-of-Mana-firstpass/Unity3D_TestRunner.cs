using System;
using System.Collections;
using System.Reflection;
using SharpUnit;
using UnityEngine;

public class Unity3D_TestRunner : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(StartTest());
	}

	public IEnumerator StartTest()
	{
		Unity3D_TestSuite suite = base.gameObject.AddComponent<Unity3D_TestSuite>();
		AddComponents(suite);
		yield return StartCoroutine(suite.Run(null));
		TestResult res = suite.TestResult;
		Unity3D_TestReporter reporter = new Unity3D_TestReporter();
		reporter.LogResults(res);
	}

	protected virtual void AddComponents(Unity3D_TestSuite suite)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(UnityTestCase).IsAssignableFrom(type) && type != typeof(UnityTestCase) && !type.IsAbstract)
				{
					UnityTestCase test = base.gameObject.AddComponent(type.Name) as UnityTestCase;
					suite.AddAll(test);
				}
				else if (typeof(TestCase).IsAssignableFrom(type) && type != typeof(TestCase) && !type.IsAbstract)
				{
					suite.AddAll(type.GetConstructor(new Type[0]).Invoke(new object[0]) as TestCase);
				}
			}
		}
	}
}
