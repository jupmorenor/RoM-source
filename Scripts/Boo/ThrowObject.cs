using System;
using UnityEngine;

[Serializable]
public class ThrowObject : MonoBehaviour
{
	public Vector2 initVelocity;

	public float randVelocityXMin;

	public float randVelocityXMax;

	public float randVelocityYMin;

	public float randVelocityYMax;

	public float randRot;

	public float speedZ;

	public float speedY;

	public Transform target;

	public float existTime;

	public bool pause;

	public GameObject destroyEffect;

	public float moveDelay;

	public GameObject hitAfterCreateObj;

	public float secScaleAdd;

	public bool adjustToLockOnY;

	public float worldSpeedY;

	private Transform mTrans;

	private Rigidbody mRigid;

	public ThrowObject()
	{
		speedZ = 30f;
		existTime = 3f;
	}

	public void Awake()
	{
		mTrans = transform;
		mRigid = rigidbody;
	}

	public void init(ThrowObjParams p)
	{
		initVelocity = p.initVelocity;
		randVelocityXMin = p.randVelocityXMin;
		randVelocityXMax = p.randVelocityXMax;
		randVelocityYMin = p.randVelocityYMin;
		randVelocityYMax = p.randVelocityYMax;
		randRot = p.randRot;
		speedZ = p.speedZ;
		speedY = p.speedY;
		existTime = p.existTime;
		destroyEffect = p.destroyEffect;
		moveDelay = p.moveDelay;
		hitAfterCreateObj = p.hitAfterCreateObj;
		secScaleAdd = p.secScaleAdd;
		adjustToLockOnY = p.adjustToLockOnY;
	}

	public void Start()
	{
		float y = mTrans.eulerAngles.y + UnityEngine.Random.Range(0f - randRot, randRot);
		Vector3 eulerAngles = mTrans.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector2 = (mTrans.eulerAngles = eulerAngles);
		float num2 = UnityEngine.Random.Range(randVelocityXMin, randVelocityXMax);
		float num3 = UnityEngine.Random.Range(randVelocityYMin, randVelocityYMax);
		if ((bool)mRigid)
		{
			mRigid.AddRelativeForce(Vector3.right * (0f - initVelocity.x + num2));
			mRigid.AddRelativeForce(Vector3.up * (initVelocity.y + num3));
		}
		UnityEngine.Object.Destroy(gameObject, existTime);
	}

	public void Update()
	{
		if (pause)
		{
			return;
		}
		moveDelay -= Time.deltaTime;
		if (moveDelay <= 0f)
		{
			if ((bool)target)
			{
				Vector3 vector = target.position - transform.position;
				vector.y = 0.1f;
				vector = vector.normalized * speedZ * Time.deltaTime;
				mTrans.position += vector;
			}
			else
			{
				mTrans.position += mTrans.right * (0f - speedZ) * Time.deltaTime;
				mTrans.position += mTrans.up * (0f - speedY) * Time.deltaTime;
				float y = mTrans.position.y + worldSpeedY * Time.deltaTime;
				Vector3 position = mTrans.position;
				float num = (position.y = y);
				Vector3 vector3 = (mTrans.position = position);
			}
			float num2 = secScaleAdd * Time.deltaTime;
			mTrans.localScale += new Vector3(num2, num2, num2);
		}
	}

	public void OnCollisionStay(Collision coli)
	{
	}

	public void CreateHitAfterObj()
	{
		if (!(hitAfterCreateObj == null))
		{
			GameObject gameObject = default(GameObject);
			if (hitAfterCreateObj != null)
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(hitAfterCreateObj, mTrans.position, Quaternion.identity);
			}
			AttackInfo component = this.gameObject.GetComponent<AttackInfo>();
			if ((bool)gameObject && (bool)component)
			{
				AttackInfo component2 = gameObject.GetComponent<AttackInfo>();
				component2.attackChar = component.attackChar;
				component2.zokuseiAtk = component.zokuseiAtk;
			}
		}
	}
}
