namespace MATSDK;

public struct MATItem
{
	public string name;

	public double? unitPrice;

	public int? quantity;

	public double? revenue;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	public MATItem(string name)
	{
		this.name = name;
		unitPrice = null;
		quantity = null;
		revenue = null;
		attribute1 = null;
		attribute2 = null;
		attribute3 = null;
		attribute4 = null;
		attribute5 = null;
	}
}
