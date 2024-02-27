using System;
using UnityEngine;

[Serializable]
public class Ef_RingMesh : Ef_Base
{
	public Color color;

	public float startDelay;

	public float delay;

	public float life;

	public float fadeIn;

	public float fadeOut;

	public float endScale;

	public AnimationCurve scaleAnim;

	public float startScale;

	public float endWidth;

	public AnimationCurve widthAnim;

	public float startWidth;

	public float startRot;

	public float rotSpeed;

	public bool randomStartRot;

	public bool randomRotSpeed;

	public bool worldPos;

	public bool worldRot;

	public int loop;

	public GameObject meshObj;

	public Transform b01;

	public Transform b02;

	private Material mat;

	private float fstDelay;

	private float fstLife;

	private float angle;

	private float fadeInEnd;

	private Vector3 fstPos1;

	private Vector3 fstPos2;

	private Quaternion fstRot1;

	private Quaternion fstRot2;

	private Vector3 wldPos1;

	private Vector3 wldPos2;

	private Quaternion wldRot1;

	private Quaternion wldRot2;

	public Ef_RingMesh()
	{
		color = Color.white;
		life = 1f;
		fadeIn = 0.2f;
		fadeOut = 0.8f;
		endScale = 10f;
		startScale = 1f;
		endWidth = 0.1f;
		startWidth = 0.5f;
		rotSpeed = 180f;
		worldPos = true;
	}

	public void Start()
	{
		if (!b01)
		{
			b01 = this.transform.Find("b01");
		}
		if (!b02)
		{
			b02 = this.transform.Find("b02");
		}
		if (!meshObj)
		{
			Transform transform = this.transform.Find("Mesh");
			if ((bool)transform)
			{
				meshObj = transform.gameObject;
			}
		}
		if (!b01 || !b02 || !meshObj)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		mat = meshObj.renderer.material;
		if (worldPos)
		{
			fstPos1 = b01.localPosition;
			fstPos2 = b02.localPosition;
		}
		if (worldRot)
		{
			fstRot1 = b01.localRotation;
			fstRot2 = b02.localRotation;
		}
		b01.localScale = Vector3.zero;
		b02.localScale = Vector3.zero;
		fstDelay = delay;
		fstLife = life;
		if (startDelay == 0f && delay == 0f)
		{
			Emit();
		}
	}

	public void Emit()
	{
		life = fstLife;
		if (worldPos)
		{
			wldPos1 = transform.position + transform.rotation * fstPos1;
			wldPos2 = transform.position + transform.rotation * fstPos2;
		}
		if (worldRot)
		{
			wldRot1 = transform.rotation * fstRot1;
			wldRot2 = transform.rotation * fstRot1;
		}
		if (randomStartRot)
		{
			startRot = UnityEngine.Random.Range(0f - startRot, startRot);
		}
		if (randomRotSpeed)
		{
			rotSpeed = UnityEngine.Random.Range(0f - rotSpeed, rotSpeed);
		}
		angle = startRot;
		fadeInEnd = fstLife - fadeIn;
	}

	public void LateUpdate()
	{
		if (!(startDelay <= 0f))
		{
			startDelay -= deltaTime;
			if (startDelay > 0f || delay != 0f)
			{
				return;
			}
			Emit();
		}
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			if (delay > 0f)
			{
				return;
			}
			Emit();
		}
		if (worldPos)
		{
			b01.position = wldPos1;
			b02.position = wldPos2;
		}
		angle += rotSpeed * deltaTime;
		Quaternion quaternion = Quaternion.Euler(new Vector3(0f, 0f, angle));
		if (worldRot)
		{
			b01.rotation = wldRot1 * quaternion;
			b02.rotation = wldRot2 * quaternion;
		}
		else
		{
			b01.localRotation = quaternion;
			b02.localRotation = quaternion;
		}
		float time = (fstLife - life) / fstLife;
		float t = scaleAnim.Evaluate(time);
		float t2 = widthAnim.Evaluate(time);
		float num = Mathf.SmoothStep(startWidth, endWidth, t2);
		float num2 = Mathf.SmoothStep(startScale, endScale, t);
		float num3 = num2 - num * 2f;
		if (!(num3 >= 0f))
		{
			num3 = 0f;
		}
		b01.localScale = new Vector3(num2, num2, 1f);
		b02.localScale = new Vector3(num3, num3, 1f);
		float num4 = default(float);
		num4 = ((!(life <= fadeInEnd)) ? ((fstLife - life) / fadeIn) : ((life >= fadeOut) ? 1f : (life / fadeOut)));
		Color color = this.color;
		color.a *= num4;
		if (mat.HasProperty("_Color"))
		{
			mat.SetColor("_Color", color);
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		b01.localScale = Vector3.zero;
		b02.localScale = Vector3.zero;
		checked
		{
			if (loop > 1)
			{
				loop--;
				if (fstDelay == 0f)
				{
					Emit();
				}
				delay = fstDelay;
				life = fstLife;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
