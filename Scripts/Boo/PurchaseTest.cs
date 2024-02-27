using System;
using System.Collections;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PurchaseTest : MonoBehaviour
{
	public RespInAppProduct[] ProductInfo;

	public string strProdcuts;

	protected bool prepare;

	public void Start()
	{
		MerlinServer.Request(new ApiPurchaseProductIdList(), _0024adaptor_0024__DebugSubGacha_Init_0024callable381_002416_59___0024__MerlinServer_Request_0024callable86_0024160_56___00245.Adapt(ProductIdListInitialize));
	}

	private void ProductIdListInitialize(ApiPurchaseProductIdList req)
	{
		if (req == null)
		{
			throw new AssertionFailedException("req != null");
		}
		strProdcuts = req.GetResponse().ToString();
		prepare = true;
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		if (prepare)
		{
			if (GUILayout.Button("Purchase Test", GUILayout.MinHeight(80f)))
			{
				PurchaseUtil.StartPurchase(null);
				PurchaseUtil.SetProductsList(strProdcuts, null);
			}
			if (PurchaseUtil.productsListTable != null)
			{
				IEnumerator enumerator = PurchaseUtil.productsListTable.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text = (string)obj;
					object obj2 = PurchaseUtil.productsListTable[text];
					if (!(obj2 is Hashtable))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
					}
					Hashtable hashtable = (Hashtable)obj2;
					if (hashtable != null && GUILayout.Button(text, GUILayout.MinHeight(60f)))
					{
						PurchaseUtil.Purchase(text, null);
					}
				}
				GUILayout.Label("Purchase Result");
				if (!string.IsNullOrEmpty(PurchaseUtil.purchaseResult.transactionIdentifier))
				{
					GUILayout.TextArea(PurchaseUtil.purchaseResult.transactionIdentifier);
				}
				if (!string.IsNullOrEmpty(PurchaseUtil.purchaseResult.transactionReceipt))
				{
					GUILayout.TextArea(PurchaseUtil.purchaseResult.transactionReceipt);
				}
				if (!string.IsNullOrEmpty(PurchaseUtil.purchaseResult.transactionDate))
				{
					GUILayout.TextArea(PurchaseUtil.purchaseResult.transactionDate);
				}
				if (!string.IsNullOrEmpty(PurchaseUtil.purchaseResult.signature))
				{
					GUILayout.TextArea(PurchaseUtil.purchaseResult.signature);
				}
			}
		}
		else
		{
			GUILayout.Label("Prepare Procuts list");
		}
		GUILayout.BeginArea(new Rect(250f, 0f, 1000f, 1000f));
		GUILayout.Label("PurchaseUtil log");
		GUILayout.Label(PurchaseUtil.log);
		GUILayout.EndArea();
	}
}
