using System;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PlayerModelSettings : MonoBehaviour
{
	public GameObject 本体;

	public GameObject 右手装備位置;

	public GameObject 左手装備位置;

	public Collider やられCollider;

	[EnumArrayEdit(typeof(AttackPartTypes), "攻撃コリジョン列")]
	public Collider[] attackColliders;

	public GameObject Body => 本体;

	public GameObject WeaponRightBase => 右手装備位置;

	public GameObject WeaponLeftBase => 左手装備位置;

	public Collider YarareCollider => やられCollider;

	public void errorCheck()
	{
		if (!(Body != null))
		{
			throw new AssertionFailedException(new StringBuilder("PlayerModelSettings の Body 設定が ").Append(name).Append(" にない").ToString());
		}
		if (!(WeaponRightBase != null))
		{
			throw new AssertionFailedException(new StringBuilder("PlayerModelSettings の WeaponRightBase 設定が ").Append(name).Append(" にない").ToString());
		}
		if (!(WeaponLeftBase != null))
		{
			throw new AssertionFailedException(new StringBuilder("PlayerModelSettings の WeaponLeftBase 設定が ").Append(name).Append(" にない").ToString());
		}
		if (!(YarareCollider != null))
		{
			throw new AssertionFailedException(new StringBuilder("PlayerModelSettings の YarareCollider 設定が ").Append(name).Append(" にない").ToString());
		}
	}

	public void init(GameObject parent)
	{
		if (!(parent != null))
		{
			throw new AssertionFailedException("parent != null");
		}
		Body.transform.parent = parent.transform;
		Body.transform.localPosition = Vector3.zero;
		Body.transform.localRotation = Quaternion.identity;
		int layer = YarareCollider.gameObject.layer;
		ExtensionsModule.SetLayerRecursively(Body, parent.layer);
		YarareCollider.gameObject.layer = layer;
	}
}
