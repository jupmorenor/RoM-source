using System;
using System.Text;

namespace S540;

[Serializable]
public class S540Expception : ApplicationException
{
	public S540Expception(string msg)
		: base(msg)
	{
	}

	public static void Err(string eid, string msg)
	{
		Err(eid, msg, null);
	}

	public static void Err(string eid, string msg, string sinfo)
	{
		if (string.IsNullOrEmpty(sinfo))
		{
			throw new S540Expception(new StringBuilder("[").Append(eid).Append(" error] ").Append(msg)
				.ToString());
		}
		throw new S540Expception(sinfo + new StringBuilder(" -- [").Append(eid).Append(" error] ").Append(msg)
			.ToString());
	}
}
