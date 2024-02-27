using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveByAnimCurveV2 : Ef_Base
{
	[Serializable]
	public class MinMaxAnim
	{
		public float animLength;

		public float max;

		public AnimationCurve anim;

		public float min;

		public bool loop;

		private float max_min;

		private bool active;

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
			}
		}

		public MinMaxAnim()
		{
			animLength = 1f;
		}

		public void Initialize()
		{
			bool num = anim.length > 0;
			if (num)
			{
				num = min != max;
			}
			active = num;
			max_min = max - min;
		}

		public float GetValue(float animTime)
		{
			float result;
			if (active)
			{
				float num = default(float);
				num = ((!(animTime > animLength)) ? (animTime / animLength) : ((!loop) ? 1f : (animTime % animLength / animLength)));
				result = min + max_min * anim.Evaluate(num);
			}
			else
			{
				result = min;
			}
			return result;
		}
	}

	[Serializable]
	public class Toward
	{
		public bool active;

		public Transform target;

		public MinMaxAnim angleSpeedAnim;

		public float radius;

		public Ef_HomingBuffer.Side targetSide;

		public bool randomChoice;

		public bool ignoreAlive;

		private Ef_HomingBuffer hmBuf;

		public bool updateTarget;

		public float interval;

		public float verticalForce;

		private bool activeMode;

		private Ef_EmitActiveManager emitActive;

		private Ef_EmitManager emitManager;

		private bool lstLeft;

		private float timer;

		private float vSpd;

		private GameObject thisGameObj;

		private float sqrRad;

		private Transform fstTrg;

		private Ef_HomingBuffer.Side fstTrgSide;

		public Toward()
		{
			radius = 0.5f;
			targetSide = Ef_HomingBuffer.Side.FromEffectMessage;
			updateTarget = true;
			interval = 1f;
		}

		public void Restart()
		{
			target = fstTrg;
			targetSide = fstTrgSide;
		}

		public void Initialize(GameObject gameObj)
		{
			thisGameObj = gameObj;
			angleSpeedAnim.Initialize();
			fstTrg = target;
			fstTrgSide = targetSide;
			sqrRad = radius * radius;
			Ef_ActiveOn component = thisGameObj.GetComponent<Ef_ActiveOn>();
			bool num = component != null;
			if (num)
			{
				num = component.enable;
			}
			activeMode = num;
			emitActive = thisGameObj.GetComponent<Ef_EmitActiveManager>();
			emitManager = thisGameObj.GetComponent<Ef_EmitManager>();
		}

		public void emitEffectMessage(MerlinActionControl emtr)
		{
			if (emtr == null)
			{
				return;
			}
			if (hmBuf == null)
			{
				hmBuf = Ef_HomingBuffer.Current;
				if (hmBuf == null)
				{
					active = false;
					return;
				}
			}
			if (targetSide == Ef_HomingBuffer.Side.ReturnToSelf)
			{
				target = emtr.transform;
				if (target != null)
				{
					target = Ef_HomingBuffer.FindSpine(target);
				}
				if (activeMode && emitActive != null)
				{
					emitActive.setTarget(target);
				}
				else if (emitManager != null)
				{
					emitManager.setTarget(target);
				}
				return;
			}
			if (targetSide == Ef_HomingBuffer.Side.TargetToPlayerTarget)
			{
				PlayerControl playerControl = emtr as PlayerControl;
				if (playerControl != null)
				{
					GameObject gameObject = playerControl.TargetChar;
					if (!gameObject)
					{
						gameObject = playerControl.searchTargetEnemy();
					}
					if ((bool)gameObject)
					{
						target = gameObject.transform;
						target = Ef_HomingBuffer.FindSpine(target);
						return;
					}
				}
			}
			if (targetSide != 0)
			{
				return;
			}
			string name = emtr.gameObject.name;
			if (name.Length > 0)
			{
				switch (name.Substring(0, 1))
				{
				case "P":
				case "C":
					targetSide = Ef_HomingBuffer.Side.TargetToEnemySide;
					break;
				case "E":
					targetSide = Ef_HomingBuffer.Side.TargetToPlayerSide;
					break;
				}
			}
		}

		public object[] Update(Vector3 pos, float ang, float animTime, float delta)
		{
			if (updateTarget)
			{
				timer -= delta;
				if (!(timer > 0f))
				{
					FindTarget(pos);
					timer = interval;
				}
			}
			bool flag = false;
			if ((bool)target)
			{
				float value = angleSpeedAnim.GetValue(animTime);
				Vector3 position = target.position;
				Vector3 trgVec = position - pos;
				float sqrMagnitude = trgVec.sqrMagnitude;
				if (VecToTurn(AngToVec(ang, 1f), trgVec))
				{
					if (lstLeft)
					{
						ang += value * delta;
					}
					else
					{
						ang += value * delta / 2f;
						lstLeft = true;
					}
					if (!(ang <= 360f))
					{
						ang -= 360f;
					}
				}
				else
				{
					if (lstLeft)
					{
						ang -= value * delta / 2f;
						lstLeft = false;
					}
					else
					{
						ang -= value * delta;
					}
					if (!(ang >= -360f))
					{
						ang += 360f;
					}
				}
				if (!(verticalForce <= 0f))
				{
					float num = position.y - pos.y;
					float num2 = default(float);
					if (!(num <= 0f))
					{
						vSpd += verticalForce * delta;
						num2 = num * verticalForce;
						if (!(vSpd <= num2))
						{
							vSpd = num2;
						}
					}
					else if (!(num >= 0f))
					{
						vSpd -= verticalForce * delta;
						num2 = num * verticalForce;
						if (!(vSpd >= num2))
						{
							vSpd = num2;
						}
					}
					pos.y += vSpd * delta;
				}
				if (!(radius <= 0f) && (bool)target && !(sqrMagnitude > sqrRad))
				{
					HitEnd();
					flag = true;
				}
			}
			return new object[3] { pos, ang, flag };
		}

		public void FindTarget(Vector3 pos)
		{
			if (hmBuf == null)
			{
				hmBuf = Ef_HomingBuffer.Current;
				if (hmBuf == null)
				{
					active = false;
					return;
				}
			}
			if (targetSide == Ef_HomingBuffer.Side.FromEffectMessage)
			{
				if (thisGameObj.layer == LayerMask.NameToLayer("PlayerAttackColi"))
				{
					targetSide = Ef_HomingBuffer.Side.TargetToEnemySide;
				}
				else if (thisGameObj.layer == LayerMask.NameToLayer("EnemyAttackColi"))
				{
					targetSide = Ef_HomingBuffer.Side.TargetToPlayerSide;
				}
			}
			target = hmBuf.FindTargetRoot(pos, targetSide, randomChoice, ignoreAlive);
			if (activeMode && emitActive != null)
			{
				emitActive.setTarget(target);
			}
			else if (emitManager != null)
			{
				emitManager.setTarget(target);
			}
		}

		public void HitEnd()
		{
			if (activeMode)
			{
				if (emitActive != null)
				{
					emitActive.EmitOnHit();
				}
				thisGameObj.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
				thisGameObj.SetActive(value: false);
				return;
			}
			if (emitManager != null)
			{
				emitManager.EmitOnHit();
			}
			Ef_DestroyReleaseV2 component = thisGameObj.GetComponent<Ef_DestroyReleaseV2>();
			if (component != null)
			{
				component.Release();
			}
			else
			{
				Ef_DestroyRelease component2 = thisGameObj.GetComponent<Ef_DestroyRelease>();
				if (component2 != null)
				{
					component2.Release();
				}
			}
			UnityEngine.Object.Destroy(thisGameObj);
		}

		public float VecToAng(Vector3 vec)
		{
			float num = 57.29578f;
			float z = vec.z;
			float x = vec.x;
			float num2 = 0f;
			if (!(Mathf.Abs(z) <= Mathf.Abs(x)))
			{
				if (!(z <= 0f))
				{
					num2 = Mathf.Atan(x / z) * num;
				}
				else if (!(z >= 0f))
				{
					num2 = Mathf.Atan(x / z) * num + 180f;
					if (!(num2 <= 180f))
					{
						num2 -= 360f;
					}
				}
			}
			else if (!(x <= 0f))
			{
				num2 = (0f - Mathf.Atan(z / x)) * num + 90f;
			}
			else if (!(x >= 0f))
			{
				num2 = (0f - Mathf.Atan(z / x)) * num - 90f;
			}
			return num2;
		}

		public bool VecToTurn(Vector3 vec, Vector3 trgVec)
		{
			return vec.x * trgVec.z - vec.z * trgVec.x < 0f;
		}

		public Vector3 AngToVec(float angle, float scala)
		{
			float f = angle * 0.01745329f;
			return new Vector3(scala * Mathf.Sin(f), 0f, scala * Mathf.Cos(f));
		}

		public Vector3 VecRotate(Vector3 vec, int angle)
		{
			float f = (float)angle * 0.01745329f;
			float num = Mathf.Sin(f);
			float num2 = Mathf.Cos(f);
			float x = vec.x;
			float z = vec.z;
			vec.x = x * num2 - z * num;
			vec.z = x * num + z * num2;
			return vec;
		}

		public Vector3 VecRotate90(Vector3 vec, int angle)
		{
			Vector3 result = vec;
			switch (angle)
			{
			case -270:
			case 90:
				result.x = 0f - vec.z;
				result.z = vec.x;
				break;
			case -90:
			case 270:
				result.x = vec.z;
				result.z = 0f - vec.x;
				break;
			case -180:
			case 180:
				result.x = 0f - vec.x;
				result.z = 0f - vec.z;
				break;
			}
			return result;
		}
	}

	public MinMaxAnim speedAnim;

	public MinMaxAnim angleAnim;

	public Toward towardToTarget;

	public MinMaxAnim forwardAnim;

	public MinMaxAnim lateralAnim;

	public MinMaxAnim verticalAnim;

	public float angOffset;

	public bool followGround;

	public float animTime;

	private float fstAng;

	private Vector2 nrmVel;

	private float lstFwd;

	private float lstLat;

	private float lstVrt;

	private float lstAng;

	private Ef_HeightBuffer hiBuf;

	private Ef_HomingBuffer hmBuf;

	private float lstHig;

	private bool ready;

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		Restart();
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!ready)
		{
			Init();
		}
		if (!(emtr == null) && towardToTarget.active)
		{
			towardToTarget.emitEffectMessage(emtr);
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		MoveUpdate();
	}

	public void Init()
	{
		if (followGround)
		{
			hiBuf = Ef_HeightBuffer.Current;
			if (hiBuf == null)
			{
				followGround = false;
			}
			else
			{
				object[] height = hiBuf.GetHeight(transform.position);
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
		Restart();
		ready = true;
	}

	public void Restart()
	{
		animTime = 0f;
		fstAng = transform.eulerAngles.y - angOffset;
		float num = fstAng + angleAnim.GetValue(0f);
		float f = num * 0.01745329f;
		nrmVel = new Vector2(Mathf.Sin(f), Mathf.Cos(f));
		Vector3 position = transform.position;
		lstFwd = forwardAnim.GetValue(0f);
		position.x += nrmVel.x * lstFwd;
		position.z += nrmVel.y * lstFwd;
		lstLat = lateralAnim.GetValue(0f);
		position.x += nrmVel.y * lstLat;
		position.z -= nrmVel.x * lstLat;
		lstVrt = verticalAnim.GetValue(0f);
		position.y += lstVrt;
		transform.position = position;
		transform.eulerAngles = new Vector3(0f, num + angOffset, 0f);
		if (towardToTarget.active)
		{
			towardToTarget.Restart();
		}
	}

	public void MoveUpdate()
	{
		float num = deltaTime;
		animTime += num;
		Vector3 vector = transform.position;
		float value = speedAnim.GetValue(animTime);
		float num2 = value * num;
		if (towardToTarget.active)
		{
			object[] array = towardToTarget.Update(vector, fstAng, animTime, num);
			vector = (Vector3)array[0];
			fstAng = RuntimeServices.UnboxSingle(array[1]);
			object value2 = array[2];
			if (RuntimeServices.ToBool(value2))
			{
				return;
			}
		}
		float num3 = fstAng + angleAnim.GetValue(animTime);
		if (angleAnim.Active || towardToTarget.active)
		{
			transform.eulerAngles = new Vector3(0f, num3 + angOffset, 0f);
			float f = num3 * 0.01745329f;
			nrmVel = new Vector2(Mathf.Sin(f), Mathf.Cos(f));
		}
		if (towardToTarget.active && towardToTarget.radius != 0f && (bool)towardToTarget.target)
		{
			Vector3 vector2 = towardToTarget.target.position - vector;
			float sqrMagnitude = new Vector2(vector2.x, vector2.z).sqrMagnitude;
			if (!(num2 * num2 <= sqrMagnitude))
			{
				num2 = Mathf.Sqrt(sqrMagnitude);
			}
		}
		vector.x += nrmVel.x * num2;
		vector.z += nrmVel.y * num2;
		if (forwardAnim.Active)
		{
			float value3 = forwardAnim.GetValue(animTime);
			float num4 = value3 - lstFwd;
			lstFwd = value3;
			vector.x += nrmVel.x * num4;
			vector.z += nrmVel.y * num4;
		}
		if (lateralAnim.Active)
		{
			float value4 = lateralAnim.GetValue(animTime);
			float num5 = value4 - lstLat;
			lstLat = value4;
			vector.x += nrmVel.y * num5;
			vector.z -= nrmVel.x * num5;
		}
		if (verticalAnim.Active)
		{
			float value5 = verticalAnim.GetValue(animTime);
			float num6 = value5 - lstVrt;
			lstVrt = value5;
			vector.y += num6;
		}
		if (followGround)
		{
			if (hiBuf == null)
			{
				followGround = false;
			}
			else
			{
				object[] height = hiBuf.GetHeight(vector);
				float num7 = RuntimeServices.UnboxSingle(height[0]);
				Vector3 vector3 = (Vector3)height[1];
				float num8 = num7 - lstHig;
				lstHig = num7;
				vector.y += num8;
			}
		}
		transform.position = vector;
	}
}
