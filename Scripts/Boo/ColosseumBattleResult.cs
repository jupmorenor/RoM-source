using System;
using MerlinAPI;

[Serializable]
public class ColosseumBattleResult : JsonBase
{
	public int gameResult;

	public int hp;

	public int opponentHp;

	public int maxGivenDamage;

	public int totalGivenDamage;

	public int maxDamage;

	public int totalDamage;

	public ColosseumBattleResult()
	{
		gameResult = 2;
	}

	public void clear()
	{
		gameResult = 2;
		hp = 0;
		opponentHp = 0;
		maxGivenDamage = 0;
		totalGivenDamage = 0;
		maxDamage = 0;
		totalDamage = 0;
	}

	public void setResult(bool _isWin)
	{
		setResult(_isWin, 0, 0);
	}

	public void setResult(bool _isWin, int _playerHP, int _opponentHP)
	{
		if (_isWin)
		{
			gameResult = 2;
		}
		else
		{
			gameResult = 3;
		}
		hp = _playerHP;
	}
}
