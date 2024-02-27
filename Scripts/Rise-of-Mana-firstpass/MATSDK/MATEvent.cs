using System;

namespace MATSDK;

public struct MATEvent
{
	public string name;

	public int? id;

	public double? revenue;

	public string currencyCode;

	public string advertiserRefId;

	public MATItem[] eventItems;

	public int? transactionState;

	public string receipt;

	public string receiptSignature;

	public string contentType;

	public string contentId;

	public int? level;

	public int? quantity;

	public string searchString;

	public double? rating;

	public DateTime? date1;

	public DateTime? date2;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	private MATEvent(int dummy1, int dummy2)
	{
		name = null;
		id = null;
		revenue = null;
		currencyCode = null;
		advertiserRefId = null;
		eventItems = null;
		transactionState = null;
		receipt = null;
		receiptSignature = null;
		contentType = null;
		contentId = null;
		level = null;
		quantity = null;
		searchString = null;
		rating = null;
		date1 = null;
		date2 = null;
		attribute1 = null;
		attribute2 = null;
		attribute3 = null;
		attribute4 = null;
		attribute5 = null;
	}

	public MATEvent(string name)
		: this(0, 0)
	{
		this.name = name;
	}

	public MATEvent(int id)
		: this(0, 0)
	{
		this.id = id;
	}
}
