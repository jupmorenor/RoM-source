using System.Runtime.CompilerServices;

[CompilerGlobalScope]
public sealed class MerlinActionEnumsModule
{
	private MerlinActionEnumsModule()
	{
	}

	public static bool IsValidAnimationType(PlayerAnimationTypes type)
	{
		bool num = type >= PlayerAnimationTypes.Idle;
		if (num)
		{
			num = type < PlayerAnimationTypes.Max;
		}
		return num;
	}

	public static bool IsAttackAnimationType(PlayerAnimationTypes type)
	{
		bool num = type == PlayerAnimationTypes.Attack1;
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack2;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack3;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack4;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack5;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack6;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack7;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.Attack8;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.RunAttack;
		}
		return num;
	}

	public static bool IsYarareAnimationType(PlayerAnimationTypes type)
	{
		bool num = type == PlayerAnimationTypes.YarareDead;
		if (!num)
		{
			num = type == PlayerAnimationTypes.YarareDown;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.YarareWeak;
		}
		if (!num)
		{
			num = type == PlayerAnimationTypes.YarareZuzaa;
		}
		return num;
	}

	public static PlayerAnimationTypes YarareTypeToAnimationType(YarareTypes type)
	{
		return type switch
		{
			YarareTypes.None => (PlayerAnimationTypes)(-1), 
			YarareTypes.Weak => PlayerAnimationTypes.YarareWeak, 
			YarareTypes.Down => PlayerAnimationTypes.YarareDown, 
			YarareTypes.Zuzaa => PlayerAnimationTypes.YarareZuzaa, 
			_ => (PlayerAnimationTypes)(-1), 
		};
	}
}
