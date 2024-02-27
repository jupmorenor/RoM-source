using System;
using System.Text;
using UnityEngine;

namespace MATSDK;

public class MATDelegate : MonoBehaviour
{
	public void trackerDidSucceed(string data)
	{
		MonoBehaviour.print("MATDelegate trackerDidSucceed: " + data);
	}

	public void trackerDidFail(string error)
	{
		MonoBehaviour.print("MATDelegate trackerDidFail: " + error);
	}

	public void trackerDidEnqueueRequest(string refId)
	{
		MonoBehaviour.print("MATDelegate trackerDidEnqueueRequest: " + refId);
	}

	public void trackerDidReceiveDeeplink(string url)
	{
		MonoBehaviour.print("MATDelegate trackerDidReceiveDeeplink: " + url);
	}

	public void trackerDidFailDeeplink(string error)
	{
		MonoBehaviour.print("MATDelegate trackerDidFailDeeplink: " + error);
	}

	public void onAdLoad(string placement)
	{
		MonoBehaviour.print("MATDelegate onAdLoad: placement = " + placement);
	}

	public void onAdLoadFailed(string error)
	{
		MonoBehaviour.print("MATDelegate onAdLoadFailed: " + error);
	}

	public void onAdClick(string empty)
	{
		MonoBehaviour.print("MATDelegate onAdClick");
	}

	public void onAdShown(string empty)
	{
		MonoBehaviour.print("MATDelegate onAdShown");
	}

	public void onAdActionStart(string willLeaveApplication)
	{
		MonoBehaviour.print("MATDelegate onAdActionStart: willLeaveApplication = " + willLeaveApplication);
	}

	public void onAdActionEnd(string empty)
	{
		MonoBehaviour.print("MATDelegate onAdActionEnd");
	}

	public void onAdRequestFired(string request)
	{
		MonoBehaviour.print("MATDelegate onAdRequestFired: request = " + request);
	}

	public void onAdClosed(string empty)
	{
		MonoBehaviour.print("MATDelegate onAdClosed");
	}

	public static string DecodeFrom64(string encodedString)
	{
		string text = null;
		MonoBehaviour.print("MATDelegate.DecodeFrom64(string)");
		return Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
	}
}
