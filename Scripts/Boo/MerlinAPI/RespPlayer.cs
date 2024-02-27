using System;

namespace MerlinAPI;

[Serializable]
public class RespPlayer : JsonBase
{
	public int Id;

	public string Name;

	public string BeforeQuestTicketIssueDate;
}
