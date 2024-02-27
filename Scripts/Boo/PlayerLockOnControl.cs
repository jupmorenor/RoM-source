using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PlayerLockOnControl
{
	private PlayerControl player;

	private BaseControl target;

	private TargetRing targetRing;

	protected bool useHUD => !(player != null) || player.useHUD;

	public GameObject TargetGameObject => (!(target != null)) ? null : target.gameObject;

	public Transform TargetTransform => (!(target != null)) ? null : target.transform;

	public bool IsLockedOn => target != null;

	public bool IsLockedAliveTargetOn
	{
		get
		{
			bool num = target != null;
			if (num)
			{
				num = !target.IsDead;
			}
			return num;
		}
	}

	public float Distance => (!(target != null)) ? float.MaxValue : (player.MYPOS - target.transform.position).magnitude;

	public float PlayerAttackRange => (!(target is AIControl)) ? float.MaxValue : (target as AIControl).playerAttackRange;

	public PlayerControl Player => player;

	public BaseControl Target => target;

	public PlayerLockOnControl(PlayerControl _player)
	{
		if (!(_player != null))
		{
			throw new AssertionFailedException("_player != null");
		}
		player = _player;
	}

	public void startLockOn(GameObject obj)
	{
		if (obj == null)
		{
			endLockOn();
			return;
		}
		BaseControl component = obj.GetComponent<BaseControl>();
		if (component == null || component.IsDead)
		{
			endLockOn();
		}
		else if (target != component)
		{
			target = component;
			startLockOnHUD();
		}
	}

	public void changeLockOn()
	{
		GameObject gameObject = searchNearestEnemyExcept(TargetGameObject);
		if (gameObject != null)
		{
			startLockOn(gameObject);
		}
	}

	public void searchAndStart()
	{
		GameObject obj = searchTargetEnemy();
		startLockOn(obj);
	}

	public void searchAndStartIfNotLockedOn()
	{
		if (!IsLockedOn)
		{
			searchAndStart();
		}
	}

	public void endLockOn()
	{
		endLockOnHUD();
		target = null;
	}

	public void update(float dt)
	{
		if (IsLockedOn)
		{
			showTargetRing();
		}
		else
		{
			hideTargetRing();
		}
	}

	private void startLockOnHUD()
	{
		if (!(target == null) && target is AIControl)
		{
			AIControl aIControl = target as AIControl;
			hudSetLockOnTarget(aIControl);
			BattleHUDTargetAbnormalState.SetTargetChar(aIControl);
		}
	}

	public void refreshLockOnInfo()
	{
		refreshLockOnInfo((AIControl)target);
	}

	public void refreshLockOnInfo(AIControl ai)
	{
		if (ai != null && target == ai)
		{
			hudSetLockOnTarget((AIControl)target);
			BattleHUDTargetAbnormalState.SetTargetChar((MerlinActionControl)target);
		}
	}

	private void endLockOnHUD()
	{
		if (!(target == null))
		{
			AIControl component = target.GetComponent<AIControl>();
			if (component != null)
			{
				disableTargetHitPointBar(component);
				BattleHUDTargetAbnormalState.Clear();
			}
		}
	}

	private void hudSetLockOnTarget(AIControl ai)
	{
		if (!(ai == null) && useHUD)
		{
			hudSetTargetHitPointBar(ai);
			hudSetTargetHitPointBarDamageMult(ai);
			if (targetRing != null)
			{
				targetRing.setColor(ai.MonsterData);
			}
		}
	}

	private void hudSetTargetHitPointBar(AIControl ai)
	{
		TargetHitPointBar.Show();
		TargetHitPointBar.SetTarget(target.gameObject);
		TargetHitPointBar.SetZokuseiIcon(ai.ElementMainIcon);
		if (ai.IS_ELITE)
		{
			TargetHitPointBar.EnableEliteIcon();
		}
		else
		{
			TargetHitPointBar.DisableEliteIcon();
		}
		TargetHitPointBar.AnimationLockOn();
	}

	private void hudSetTargetHitPointBarDamageMult(AIControl ai)
	{
		if (!(target == null))
		{
			int damageAdjustOnHUD = getDamageAdjustOnHUD(ai.MonsterData);
			TargetHitPointBar.SetZokuseiDamageAdjust(new StringBuilder().Append((object)damageAdjustOnHUD).Append("%").ToString());
			if (damageAdjustOnHUD > 100)
			{
				TargetHitPointBar.EnableZokuseiArrow("arrow_powup");
				TargetHitPointBar.SetZokuseiDamageAdjustColor(new Color(1f, 0.972549f, 0.062745094f));
			}
			else if (damageAdjustOnHUD < 100)
			{
				TargetHitPointBar.EnableZokuseiArrow("arrow_powdown");
				TargetHitPointBar.SetZokuseiDamageAdjustColor(new Color(0.007843137f, 0.9137255f, 50f / 51f));
			}
			else
			{
				TargetHitPointBar.EnableZokuseiArrow("arrow_powmid");
				TargetHitPointBar.SetZokuseiDamageAdjustColor(new Color(0.70980394f, 0.9490196f, 0.25098038f));
			}
		}
	}

	private void disableTargetHitPointBar(AIControl ai)
	{
		TargetHitPointBar.SetZokuseiDamageAdjust(string.Empty);
		TargetHitPointBar.Hide();
		if (ai != null)
		{
			ai.hitPointBar = null;
		}
	}

	private int getDamageAdjustOnHUD(RespMonster m)
	{
		int result;
		if (m == null)
		{
			result = 100;
		}
		else
		{
			PlayerSkillEffectControl skillEffectControl = player.SkillEffectControl;
			RespWeapon mainWeapon = player.getMainWeapon();
			MElements element = mainWeapon.Element;
			int styleId = mainWeapon.StyleId;
			float rate = MElementCorrelations.GetRate(element, m.Element);
			float num = DamageCalc.WeakStyleAttackMult((EnumStyles)styleId, m.WeakStyle);
			float num2 = skillEffectControl.attackMult(player.HasAnyAbnormalState, player.getMainWeapon().Style);
			int id = m.Element.Id;
			int id2 = m.Race.Id;
			bool enGuard = false;
			bool isElite = m.IsElite;
			bool isCritical = false;
			float num3 = skillEffectControl.attackDamageMult(player, (EnumElements)id, (EnumRaces)id2, enGuard, isElite, isCritical, null);
			float num4 = num * rate * num2 * num3 * 100f;
			result = checked((int)num4);
		}
		return result;
	}

	public GameObject searchTargetEnemy()
	{
		Vector3 mYPOS = player.MYPOS;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		float num = float.MaxValue;
		GameObject result = null;
		int i = 0;
		GameObject[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			BaseControl component = array2[i].GetComponent<BaseControl>();
			if (component != null && component.IsAlive)
			{
				Vector3 vector = mYPOS - array2[i].transform.position;
				if (!(vector.magnitude >= num))
				{
					num = vector.magnitude;
					result = array2[i];
				}
			}
		}
		return result;
	}

	private GameObject searchNearestEnemyExcept(GameObject ignoreTarget)
	{
		Vector3 mYPOS = player.MYPOS;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		float num = 10000f;
		GameObject result = null;
		int i = 0;
		GameObject[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if (array2[i] == ignoreTarget)
			{
				continue;
			}
			BaseControl component = array2[i].GetComponent<BaseControl>();
			if ((bool)component && component.IsAlive)
			{
				Vector3 vector = mYPOS - array2[i].transform.position;
				if (!(vector.magnitude >= num))
				{
					num = vector.magnitude;
					result = array2[i];
				}
			}
		}
		return result;
	}

	private void showTargetRing()
	{
		if (target == null || target.IsDead)
		{
			endLockOn();
			return;
		}
		if (targetRing == null)
		{
			GameObject gameObject = PlayerAssets.Instance.instantiateTargetRing();
			if (gameObject == null)
			{
				return;
			}
			targetRing = gameObject.GetComponent<TargetRing>();
			if (!(targetRing != null))
			{
				throw new AssertionFailedException(new StringBuilder().Append(gameObject).Append(" に TargetRing が貼ってありません").ToString());
			}
		}
		if (targetRing.CurrentTarget != target)
		{
			targetRing.StartLockOn(target.gameObject);
		}
	}

	private void hideTargetRing()
	{
		if (!(targetRing == null))
		{
			targetRing.EndLockOn();
		}
	}
}
