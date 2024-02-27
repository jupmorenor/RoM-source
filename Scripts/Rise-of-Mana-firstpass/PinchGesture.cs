public class PinchGesture : ContinuousGesture
{
	private float delta;

	private float gap;

	public float Delta
	{
		get
		{
			return delta;
		}
		internal set
		{
			delta = value;
		}
	}

	public float Gap
	{
		get
		{
			return gap;
		}
		internal set
		{
			gap = value;
		}
	}
}
