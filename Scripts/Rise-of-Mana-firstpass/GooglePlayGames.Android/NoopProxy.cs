using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class NoopProxy : AndroidJavaProxy
{
	private string mInterfaceClass;

	internal NoopProxy(string javaInterfaceClass)
		: base(javaInterfaceClass)
	{
		mInterfaceClass = javaInterfaceClass;
	}

	public override AndroidJavaObject Invoke(string methodName, object[] args)
	{
		Logger.d("NoopProxy for " + mInterfaceClass + " got call to " + methodName);
		return null;
	}

	public override AndroidJavaObject Invoke(string methodName, AndroidJavaObject[] javaArgs)
	{
		Logger.d("NoopProxy for " + mInterfaceClass + " got call to " + methodName);
		return null;
	}
}
