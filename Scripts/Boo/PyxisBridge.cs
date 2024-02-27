using System;
using MATSDK;

[Serializable]
public class PyxisBridge
{
	[NonSerialized]
	private static bool _InvokeInitializeFuckPyxis;

	[NonSerialized]
	private const string MAT_ADVERTISER_ID = "156396";

	[NonSerialized]
	private const string MAT_CONVERSION_KEY = "3fdaa49a54c17e16f65c03ea13d5e922";

	public static void InitializeFuckPyxis()
	{
		if (!_InvokeInitializeFuckPyxis)
		{
			MATBinding.Init("156396", "3fdaa49a54c17e16f65c03ea13d5e922");
			MATBinding.MeasureSession();
			MATBinding.MeasureEvent("Install");
		}
	}

	public static void SendTutorialFinishingToFuckPyxisService()
	{
		MATBinding.MeasureEvent("ClearTutorial");
	}

	public static void SendPaymentInfoToFuckPyxisService(double sales, int volume)
	{
		string name = "Purchase";
		string currencyCode = "JPY";
		string text = "refId";
		MATEvent tuneEvent = new MATEvent(name);
		tuneEvent.revenue = sales;
		tuneEvent.currencyCode = currencyCode;
		MATBinding.MeasureEvent(tuneEvent);
	}
}
