using System;

namespace MATSDK;

internal struct MATEventIos
{
	public string name;

	public string eventId;

	public string revenue;

	public string currencyCode;

	public string advertiserRefId;

	public string transactionState;

	public string contentType;

	public string contentId;

	public string level;

	public string quantity;

	public string searchString;

	public string rating;

	public string date1;

	public string date2;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	private MATEventIos(int dummy1, int dummy2)
	{
		eventId = null;
		name = null;
		revenue = null;
		currencyCode = null;
		advertiserRefId = null;
		transactionState = null;
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

	public MATEventIos(string name)
		: this(0, 0)
	{
		this.name = name;
	}

	public MATEventIos(int id)
		: this(0, 0)
	{
		eventId = id.ToString();
	}

	public MATEventIos(MATEvent matEvent)
	{
		name = matEvent.name;
		eventId = ((matEvent.name != null) ? null : matEvent.id.ToString());
		advertiserRefId = matEvent.advertiserRefId;
		attribute1 = matEvent.attribute1;
		attribute2 = matEvent.attribute2;
		attribute3 = matEvent.attribute3;
		attribute4 = matEvent.attribute4;
		attribute5 = matEvent.attribute5;
		contentId = ((matEvent.contentId != null) ? matEvent.contentId.ToString() : null);
		contentType = matEvent.contentType;
		currencyCode = matEvent.currencyCode;
		int? num = matEvent.level;
		level = (num.HasValue ? matEvent.level.ToString() : null);
		int? num2 = matEvent.quantity;
		quantity = (num2.HasValue ? matEvent.quantity.ToString() : null);
		double? num3 = matEvent.rating;
		rating = (num3.HasValue ? matEvent.rating.ToString() : null);
		double? num4 = matEvent.revenue;
		revenue = (num4.HasValue ? matEvent.revenue.ToString() : null);
		searchString = matEvent.searchString;
		int? num5 = matEvent.transactionState;
		transactionState = (num5.HasValue ? matEvent.transactionState.ToString() : null);
		date1 = null;
		date2 = null;
		DateTime dateTime = new DateTime(1970, 1, 1);
		if (matEvent.date1.HasValue)
		{
			TimeSpan timeSpan = new TimeSpan(matEvent.date1.Value.Ticks);
			double totalMilliseconds = timeSpan.TotalMilliseconds;
			date1 = (totalMilliseconds - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
		}
		if (matEvent.date2.HasValue)
		{
			TimeSpan timeSpan2 = new TimeSpan(matEvent.date2.Value.Ticks);
			double totalMilliseconds2 = timeSpan2.TotalMilliseconds;
			date2 = (totalMilliseconds2 - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
		}
	}
}
