using System;
using System.IO;
using SharpUnit;

public class XML_TestReporter : TestReporter
{
	protected string m_fileName;

	protected StreamWriter m_file;

	public string FileName => m_fileName;

	public void Init(string fileName)
	{
		if (fileName == null)
		{
			throw new Exception("XML_TestReporter::Init() called with invalid file name.");
		}
		m_fileName = fileName;
	}

	public override void LogResults(TestResult result)
	{
		m_result = result;
		m_file = new StreamWriter(m_fileName, append: false);
		if (m_file == null)
		{
			return;
		}
		m_file.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
		m_file.WriteLine("<SharpUnit>");
		LogSummary();
		if (m_result != null)
		{
			foreach (Exception error in m_result.ErrorList)
			{
				LogFailure(error);
			}
		}
		m_file.WriteLine("</SharpUnit>");
		m_file.Close();
		m_file = null;
	}

	protected override void LogSummary()
	{
		string text = "No test results to report, did you add tests to the test suite?";
		if (base.Result != null)
		{
			text = base.Result.GetSummary();
		}
		m_file.WriteLine("\t<summary><![CDATA[" + text + "]]></summary>");
	}

	protected override void LogFailure(Exception error)
	{
		if (error != null)
		{
			m_file.WriteLine("\t<fail>");
			string text = "\t\t<description><![CDATA[";
			if (typeof(TestException) == error.GetType())
			{
				TestException ex = error as TestException;
				text += ex.Description;
			}
			text += "]]></description>";
			m_file.WriteLine(text);
			m_file.WriteLine(string.Concat("\t\t<exception><![CDATA[", error, "]]></exception>"));
			m_file.WriteLine("\t</fail>");
		}
	}
}
