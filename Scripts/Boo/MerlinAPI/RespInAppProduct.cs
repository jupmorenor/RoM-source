using System;

namespace MerlinAPI;

[Serializable]
public class RespInAppProduct : JsonBase
{
	public int Id;

	public string ProductIdCode;

	public string Name;

	public int Price;

	public int Quantity;

	public int Sort;

	public int MarketTypeValue;

	public int ProductSalesTypeValue;

	public int ProductSalesLimitCount;

	public string Icon => "icon_shop1";

	public string ElementIcon => "icon_fire";
}
