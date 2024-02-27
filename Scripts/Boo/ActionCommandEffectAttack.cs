using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ActionCommandEffectAttack : ActionCommandAttack
{
	private bool killEffectIfNotHitAnyMore;

	private ActionCommandEffect effectCommand;

	public override bool UpdateWithWorldTime => effectCommand != null && effectCommand.UpdateWithWorldTime;

	public override bool IsDead
	{
		get
		{
			bool num = effectCommand == null;
			if (!num)
			{
				num = effectCommand.IsDead;
			}
			return num;
		}
	}

	public bool KillEffectIfNotHitAnyMore
	{
		get
		{
			return killEffectIfNotHitAnyMore;
		}
		set
		{
			killEffectIfNotHitAnyMore = value;
		}
	}

	public ActionCommandEffect EffectCommand => effectCommand;

	public ActionCommandEffectAttack(ActionCommandEffect effCmd)
	{
		if (effCmd == null)
		{
			throw new AssertionFailedException("effCmd != null");
		}
		base._002Ector(null);
		killEffectIfNotHitAnyMore = true;
		effectCommand = effCmd;
		effectCommand.EmitCallback = emitted;
		useMyTimer = true;
		myTimer = float.MinValue;
		stopMyTimer = true;
	}

	public void emitted()
	{
		GameObject instance = effectCommand.Instance;
		Collider component = instance.GetComponent<Collider>();
		if (parent != null && component != null)
		{
			Collider collider = component;
			parent.setMyAttackLayer(component);
			myTimer = 0f;
			stopMyTimer = false;
			MerlinAttackCommandHolder merlinAttackCommandHolder = ExtensionsModule.SetComponent<MerlinAttackCommandHolder>(component.gameObject);
			if (!(merlinAttackCommandHolder != null))
			{
				throw new AssertionFailedException("holder != null");
			}
			merlinAttackCommandHolder.Command = this;
		}
	}

	public override bool canHit(object obj)
	{
		bool result = base.canHit(obj);
		if (cannotHitAnyMore() && killEffectIfNotHitAnyMore)
		{
			effectCommand.kill();
		}
		return result;
	}
}
