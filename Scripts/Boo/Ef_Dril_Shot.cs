using System;
using UnityEngine;

[Serializable]
public class Ef_Dril_Shot : Ef_Base
{
	public float life;

	public float speed;

	private int rank;

	private Ef_SetActiveFromRank setActiveFromRank;

	private Animation anim;

	public Ef_Dril_Shot()
	{
		life = 3f;
		speed = 3f;
	}

	public void Start()
	{
		Transform transform = this.transform.Find("Ef_Dril_Shot");
		if (!transform)
		{
			return;
		}
		anim = transform.animation;
		if ((bool)anim)
		{
			anim.Play("Ef_Dril_Shot_s");
			anim.PlayQueued("Ef_Dril_Shot_l");
			if (rank <= 1)
			{
				transform.localScale = new Vector3(0.5f, 0.5f, 0.8f);
			}
		}
	}

	public void Update()
	{
		transform.Translate(Vector3.forward * speed * deltaTime);
		if (!(life <= 0.34f))
		{
			life -= deltaTime;
			if (!(life > 0.34f) && (bool)anim)
			{
				anim.CrossFade("Ef_Dril_Shot_e", 0.2f);
			}
		}
		else if (!(life <= 0f))
		{
			life -= deltaTime;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void setTime(float inTime)
	{
		life = inTime;
	}

	public void setRank(int inRank)
	{
		rank = inRank;
		if (Ef_SetActiveFromRank.rank2test)
		{
			rank = 2;
		}
	}
}
