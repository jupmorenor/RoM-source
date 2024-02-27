using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DeactiveCollision : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		CollisionAndGround,
		CollisionOnly,
		GroundOnly
	}

	public Mode mode;

	public float upLength;

	public bool emitOnHit;

	private Ef_EmitActiveManager eam;

	private Ef_HeightBuffer hBuf;

	private int destroyCount;

	private Transform targetObj;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	private bool ready;

	public Ef_DeactiveCollision()
	{
		mode = Mode.CollisionAndGround;
		upLength = 0.02f;
		emitOnHit = true;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (!ready)
		{
			eam = gameObject.GetComponent<Ef_EmitActiveManager>();
			if (emitOnHit && eam == null)
			{
				emitOnHit = false;
			}
			ready = true;
		}
	}

	public void OnCollisionEnter(Collision coli)
	{
		if (mode == Mode.GroundOnly)
		{
			return;
		}
		ContactPoint[] contacts = coli.contacts;
		if (emitOnHit)
		{
			if (contacts.Length > 0)
			{
				eam.Emit(contacts[0].point);
			}
			else
			{
				eam.Emit();
			}
		}
		destroyCount = 1;
		mode = Mode.GroundOnly;
	}

	public void Update()
	{
		if (mode != Mode.CollisionOnly)
		{
			if (hBuf == null)
			{
				hBuf = Ef_HeightBuffer.Current;
				if (hBuf == null)
				{
					UnityEngine.Object.Destroy(gameObject);
					return;
				}
			}
			object[] height = hBuf.GetHeight(transform.position);
			float num = RuntimeServices.UnboxSingle(height[0]);
			object obj = height[1];
			num += upLength;
			if (!(transform.position.y >= num))
			{
				float y = num;
				Vector3 position = transform.position;
				float num2 = (position.y = y);
				Vector3 vector2 = (transform.position = position);
				if (emitOnHit)
				{
					eam.Emit();
				}
				gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
				gameObject.SetActive(value: false);
				return;
			}
		}
		checked
		{
			if (destroyCount > 0)
			{
				destroyCount--;
				if (destroyCount <= 0)
				{
					gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
					gameObject.SetActive(value: false);
				}
			}
		}
	}
}
