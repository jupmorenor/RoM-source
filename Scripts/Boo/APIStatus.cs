using System;
using Boo.Lang.Runtime;

[Serializable]
public class APIStatus
{
	[NonSerialized]
	public const string CMN_QUERY_ERROR = "CoApi001";

	[NonSerialized]
	public const string CMN_INVALID_TOKEN = "CoApi002";

	[NonSerialized]
	public const string CMN_NO_PLAYER_INFO = "CoApi003";

	[NonSerialized]
	public const string CMN_NO_SOCIALPLAYER_INFO = "CoApi004";

	[NonSerialized]
	public const string CMN_INVALID_DATA_VERSION = "CoApi005";

	[NonSerialized]
	public const string CMN_INVALID_CLIENT_VERSION = "CoApi006";

	[NonSerialized]
	public const string CMN_INVALID_MASTER_VERSION = "CoApi007";

	[NonSerialized]
	public const string CMN_LACK_OF_FAYSTONE = "CoApi008";

	[NonSerialized]
	public const string CMN_OPTIMISTIC_LOCK_ERROR = "CoApi009";

	[NonSerialized]
	public const string CMN_BAN_ACCOUNT = "CoApi010";

	[NonSerialized]
	public const string CMN_BOX_CAPA_OVER = "CoApi011";

	[NonSerialized]
	public const string CMN_ILLEGAL_ACCESS = "CoApi012";

	[NonSerialized]
	public const string CMN_BUSY = "CoApi013";

	[NonSerialized]
	public const string CMN_WORKING = "CoApi014";

	[NonSerialized]
	public const string CMN_TIMEOUT = "CoApi015";

	[NonSerialized]
	public const string CMN_MAINTENANCE = "CoApi999";

	[NonSerialized]
	private static readonly string[] GotoBootStatus = new string[6] { "CoApi001", "CoApi002", "CoApi003", "CoApi004", "CoApi010", "CoApi012" };

	[NonSerialized]
	private static readonly string[] RetryStatuses = new string[4] { "CoApi009", "CoApi013", "CoApi014", "CoApi015" };

	public static bool IsGotoBootStatusError(string s)
	{
		return RuntimeServices.op_Member(s, GotoBootStatus);
	}

	public static bool IsRetryStatus(string s)
	{
		return RuntimeServices.op_Member(s, RetryStatuses);
	}
}
