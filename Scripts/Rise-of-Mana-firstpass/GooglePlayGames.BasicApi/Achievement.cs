namespace GooglePlayGames.BasicApi;

public class Achievement
{
	public string Id = string.Empty;

	public bool IsIncremental;

	public bool IsRevealed;

	public bool IsUnlocked;

	public int CurrentSteps;

	public int TotalSteps;

	public string Description = string.Empty;

	public string Name = string.Empty;

	public override string ToString()
	{
		return string.Format("[Achievement] id={0}, name={1}, desc={2}, type={3},  revealed={4}, unlocked={5}, steps={6}/{7}", Id, Name, Description, (!IsIncremental) ? "STANDARD" : "INCREMENTAL", IsRevealed, IsUnlocked, CurrentSteps, TotalSteps);
	}
}
