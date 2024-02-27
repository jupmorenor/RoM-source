using System.Collections;

namespace SharpUnit;

public interface ITestCase
{
	void SetUp();

	void TearDown();

	void SetTestMethod(string method);

	IEnumerator Run(TestResult result);

	TestResult GetTestResult();
}
