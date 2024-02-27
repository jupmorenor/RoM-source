using System;

[Serializable]
public class MerlinCharParameters
{
	private bool noKnockBack;

	private bool noThrow;

	private bool noBaseMode;

	private bool initialized;

	private MerlinMotionPackControl mmpc;

	public bool NoKnockBack
	{
		get
		{
			initialize();
			return noKnockBack;
		}
	}

	public bool NoThrow
	{
		get
		{
			initialize();
			return noThrow;
		}
	}

	public bool NoBaseMode
	{
		get
		{
			initialize();
			return noBaseMode;
		}
	}

	public MerlinCharParameters(MerlinMotionPackControl mmpc)
	{
		this.mmpc = mmpc;
	}

	public void initialize()
	{
		if (!(mmpc == null) && !initialized)
		{
			noKnockBack = mmpc.getPackMiscInfoAsBool("I_NO_KNOCKBACK", defaultVal: false);
			noThrow = mmpc.getPackMiscInfoAsBool("I_NO_THROW", defaultVal: false);
			noBaseMode = mmpc.getPackMiscInfoAsBool("I_NO_BASEMODE", defaultVal: false);
			initialized = true;
		}
	}
}
