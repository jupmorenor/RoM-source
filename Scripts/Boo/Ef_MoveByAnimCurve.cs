using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveByAnimCurve : Ef_Base
{
	public Ef_MoveByAnimCurveMinMaxAnim speedAnim;

	public Ef_MoveByAnimCurveMinMaxAnim angleAnim;

	public Ef_MoveByAnimCurveToward towardToTarget;

	public Ef_MoveByAnimCurveMinMaxAnim forwardAnim;

	public Ef_MoveByAnimCurveMinMaxAnim lateralAnim;

	public Ef_MoveByAnimCurveMinMaxAnim verticalAnim;

	public float angOffset;

	public bool followGround;

	public float animTime;

	private float fstAng;

	private Vector2 nrmVel;

	private float lstFwd;

	private float lstLat;

	private float lstVrt;

	private float lstAng;

	private Ef_HeightBuffer hBuf;

	private float lstHig;

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (towardToTarget.active && towardToTarget.quickCollision.active)
		{
			towardToTarget.quickCollision.setEmtr(emtr);
		}
		if (!(emtr == null) && towardToTarget.active)
		{
			towardToTarget.emitEffectMessage(emtr);
		}
	}

	public void Start()
	{
		if (followGround)
		{
			hBuf = Ef_HeightBuffer.Current;
			if (hBuf == null)
			{
				followGround = false;
			}
			else
			{
				object[] height = hBuf.GetHeight(transform.position);
				lstHig = RuntimeServices.UnboxSingle(height[0]);
				Vector3 vector = (Vector3)height[1];
			}
		}
		speedAnim.Initialize();
		angleAnim.Initialize();
		forwardAnim.Initialize();
		lateralAnim.Initialize();
		verticalAnim.Initialize();
		if (towardToTarget.active)
		{
			towardToTarget.Initialize(gameObject);
		}
		fstAng = transform.eulerAngles[1] - angOffset;
		float num = fstAng + angleAnim.GetValue(0f);
		float f = num * 0.01745329f;
		nrmVel = new Vector2(Mathf.Sin(f), Mathf.Cos(f));
		Vector3 position = transform.position;
		lstFwd = forwardAnim.GetValue(0f);
		position[0] += nrmVel[0] * lstFwd;
		position[2] += nrmVel[1] * lstFwd;
		lstLat = lateralAnim.GetValue(0f);
		position[0] += nrmVel[1] * lstLat;
		position[2] -= nrmVel[0] * lstLat;
		lstVrt = verticalAnim.GetValue(0f);
		position[1] += lstVrt;
		transform.position = position;
		transform.eulerAngles = new Vector3(0f, num + angOffset, 0f);
	}

	public void Update()
	{
		float num = deltaTime;
		animTime += num;
		Vector3 vector = transform.position;
		if (towardToTarget.active)
		{
			object[] array = towardToTarget.Update(vector, fstAng, animTime, deltaTime);
			vector = (Vector3)array[0];
			fstAng = RuntimeServices.UnboxSingle(array[1]);
		}
		float num2 = fstAng + angleAnim.GetValue(animTime);
		if (angleAnim.Active || towardToTarget.active)
		{
			transform.eulerAngles = new Vector3(0f, num2 + angOffset, 0f);
			float f = num2 * 0.01745329f;
			nrmVel = new Vector2(Mathf.Sin(f), Mathf.Cos(f));
		}
		float value = speedAnim.GetValue(animTime);
		float num3 = value * num;
		if (towardToTarget.active && towardToTarget.quickCollision.active && (bool)towardToTarget.target)
		{
			Vector3 vector2 = towardToTarget.target.position - vector;
			float sqrMagnitude = new Vector2(vector2[0], vector2[2]).sqrMagnitude;
			if (!(num3 * num3 <= sqrMagnitude))
			{
				num3 = Mathf.Sqrt(sqrMagnitude);
			}
		}
		vector[0] += nrmVel[0] * num3;
		vector[2] += nrmVel[1] * num3;
		if (forwardAnim.Active)
		{
			float value2 = forwardAnim.GetValue(animTime);
			float num4 = value2 - lstFwd;
			lstFwd = value2;
			vector[0] += nrmVel[0] * num4;
			vector[2] += nrmVel[1] * num4;
		}
		if (lateralAnim.Active)
		{
			float value3 = lateralAnim.GetValue(animTime);
			float num5 = value3 - lstLat;
			lstLat = value3;
			vector[0] += nrmVel[1] * num5;
			vector[2] -= nrmVel[0] * num5;
		}
		if (verticalAnim.Active)
		{
			float value4 = verticalAnim.GetValue(animTime);
			float num6 = value4 - lstVrt;
			lstVrt = value4;
			vector[1] += num6;
		}
		if (followGround)
		{
			if (hBuf == null)
			{
				followGround = false;
			}
			else
			{
				object[] height = hBuf.GetHeight(vector);
				float num7 = RuntimeServices.UnboxSingle(height[0]);
				Vector3 vector3 = (Vector3)height[1];
				float num8 = num7 - lstHig;
				lstHig = num7;
				vector[1] += num8;
			}
		}
		transform.position = vector;
	}

	public void setTarget(Transform trgObj)
	{
		if (towardToTarget.active)
		{
			towardToTarget.setTarget(trgObj);
		}
	}

	public void setColor(Color color)
	{
		if (towardToTarget.active && towardToTarget.quickCollision.active)
		{
			towardToTarget.quickCollision.setColor(color);
		}
	}

	public void setTime(float time)
	{
		if (towardToTarget.active && towardToTarget.quickCollision.active)
		{
			towardToTarget.quickCollision.setTime(time);
		}
	}

	public void setRank(int rank)
	{
		if (towardToTarget.active && towardToTarget.quickCollision.active)
		{
			towardToTarget.quickCollision.setRank(rank);
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (towardToTarget.active && towardToTarget.quickCollision.active)
		{
			towardToTarget.quickCollision.setPoppetMaster(mpets);
		}
	}
}
