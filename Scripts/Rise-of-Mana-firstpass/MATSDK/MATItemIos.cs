namespace MATSDK;

internal struct MATItemIos
{
	public string name;

	public double unitPrice;

	public int quantity;

	public double revenue;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	public MATItemIos(string name)
	{
		this.name = name;
		unitPrice = 0.0;
		quantity = 0;
		revenue = 0.0;
		attribute1 = null;
		attribute2 = null;
		attribute3 = null;
		attribute4 = null;
		attribute5 = null;
	}

	public MATItemIos(MATItem matItem)
	{
		name = matItem.name;
		double? num = matItem.unitPrice;
		unitPrice = ((!num.HasValue) ? 0.0 : num.Value);
		int? num2 = matItem.quantity;
		quantity = (num2.HasValue ? num2.Value : 0);
		double? num3 = matItem.revenue;
		revenue = ((!num3.HasValue) ? 0.0 : num3.Value);
		attribute1 = matItem.attribute1;
		attribute2 = matItem.attribute2;
		attribute3 = matItem.attribute3;
		attribute4 = matItem.attribute4;
		attribute5 = matItem.attribute5;
	}
}
