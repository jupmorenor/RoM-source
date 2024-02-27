using UnityEngine;

public class LookAtCharacter : MonoBehaviour
{
	public float delay = 5f;

	public Transform targetCharObj;

	public float maxHeadAngle = 45f;

	public float maxSpineAngle = 20f;

	public float headSpeed = 6f;

	public float spineSpeed = 2f;

	public float distance = 6f;

	public bool enableLookAt = true;

	public float fieldOfViewAng = 200f;

	public bool resetLastAnim;

	public bool ready;

	public bool ready2;

	private float sqrDist;

	private Transform headObj;

	public Transform spineObj;

	public Transform dumySpinObj;

	public string spineObjName = string.Empty;

	public Transform[] tfs0;

	public Transform[] tfs1;

	private int num;

	private Transform spineParent;

	private Transform headParent;

	private Quaternion frontOfst1;

	private Quaternion frontOfst2;

	public int spineNo;

	public int headNo;

	private float viewAng;

	private Quaternion headRot;

	private Quaternion spinRot;

	private Quaternion lstRot;

	private int testCount;

	private Quaternion lstTestRot1 = Quaternion.identity;

	private Quaternion lstTestRot2 = Quaternion.identity;

	private SkinnedMeshRenderer[] rends;

	private int enableCount;

	private AnimationCullingType cullingType;

	private void EnableLookAt(bool b)
	{
		enableLookAt = b;
	}

	private void Start()
	{
		if (!ready)
		{
			Init();
			RendererDisable();
			enableCount = 2;
			cullingType = base.animation.cullingType;
			base.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			resetLastAnim = true;
		}
	}

	private void OnEnable()
	{
		if (!ready)
		{
			Init();
			RendererDisable();
			enableCount = 2;
			cullingType = base.animation.cullingType;
			base.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			resetLastAnim = true;
		}
	}

	private void OnDisable()
	{
		if (ready)
		{
			spineObj.name = spineObjName;
			if ((bool)dumySpinObj)
			{
				Object.Destroy(dumySpinObj.gameObject);
			}
			base.gameObject.SendMessage("RestartLastAnim", SendMessageOptions.DontRequireReceiver);
			cullingType = base.animation.cullingType;
			base.animation.cullingType = AnimationCullingType.AlwaysAnimate;
			ready = false;
		}
	}

	private void FindPlayer()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		if ((bool)gameObject)
		{
			targetCharObj = gameObject.transform;
		}
	}

	private void Init()
	{
		sqrDist = distance * distance;
		Transform transform = null;
		Transform transform2 = null;
		Transform transform3 = null;
		Transform transform4 = null;
		Transform transform5 = null;
		Transform transform6 = null;
		Transform transform7 = null;
		Transform transform8 = null;
		transform = base.transform.Find("y_ang");
		if ((bool)transform)
		{
			transform2 = transform.Find("cog");
			if ((bool)transform2)
			{
				transform3 = transform2.Find("c_spine_a");
				if ((bool)transform3)
				{
					transform4 = transform3.Find("c_spine_b");
					if ((bool)transform4)
					{
						transform6 = transform4.Find("c_neck");
						if ((bool)transform6)
						{
							transform7 = transform6.Find("c_head");
						}
						else
						{
							transform7 = transform4.Find("c_head");
							if (!transform7)
							{
								transform5 = transform4.Find("c_spine_c");
								if ((bool)transform5)
								{
									transform6 = transform4.Find("c_neck");
									if ((bool)transform6)
									{
										transform7 = transform6.Find("c_head");
									}
								}
							}
						}
					}
					else
					{
						transform6 = transform3.Find("c_neck");
						if ((bool)transform6)
						{
							transform4 = transform3;
							transform7 = transform6.Find("c_head");
						}
						else
						{
							transform4 = transform3;
							transform7 = transform4.Find("c_head");
						}
					}
				}
				else
				{
					transform4 = transform2.Find("c_spine");
					if ((bool)transform4)
					{
						transform6 = transform4.Find("c_neck");
						transform7 = ((!transform6) ? transform4.Find("c_head") : transform6.Find("c_head"));
					}
				}
			}
		}
		if (!spineObj && (bool)transform4)
		{
			spineObj = transform4;
		}
		if (!headObj && (bool)transform7)
		{
			headObj = transform7;
		}
		if ((bool)spineObj && (bool)headObj)
		{
			spineParent = spineObj.parent;
			headParent = headObj.parent;
			spinRot = spineParent.rotation;
			headRot = headParent.rotation;
			lstRot = base.transform.rotation;
			GameObject gameObject = Object.Instantiate(spineObj.gameObject) as GameObject;
			dumySpinObj = gameObject.transform;
			spineObjName = spineObj.name;
			dumySpinObj.name = spineObjName;
			dumySpinObj.parent = spineParent;
			dumySpinObj.localPosition = spineObj.localPosition;
			dumySpinObj.localRotation = spineObj.localRotation;
			dumySpinObj.localScale = spineObj.localScale;
			spineObj.name = spineObjName + "_original";
			num = ChildCount(spineObj, 0);
			tfs0 = new Transform[num];
			tfs1 = new Transform[num];
			DigChild0(dumySpinObj, 0);
			DigChild1(spineObj, 0);
			frontOfst1 = Quaternion.Inverse(base.transform.rotation) * spineParent.rotation;
			frontOfst2 = Quaternion.Inverse(base.transform.rotation) * headParent.rotation;
			viewAng = fieldOfViewAng / 2f;
			lstTestRot1 = Quaternion.identity;
			lstTestRot2 = Quaternion.identity;
			testCount = 30;
			ready = true;
		}
	}

	private void RendererDisable()
	{
		Object[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		int num = componentsInChildren.Length;
		rends = new SkinnedMeshRenderer[num];
		for (int i = 0; i > num; i++)
		{
			rends[i] = componentsInChildren[i] as SkinnedMeshRenderer;
			rends[i].enabled = false;
		}
	}

	private void RendererEnable()
	{
		if (rends == null)
		{
			return;
		}
		for (int i = 0; i < rends.Length; i++)
		{
			if (rends[i] != null)
			{
				rends[i].enabled = true;
			}
		}
	}

	private void LateUpdate()
	{
		if (!ready)
		{
			return;
		}
		if (resetLastAnim)
		{
			base.gameObject.SendMessage("RestartLastAnim", SendMessageOptions.DontRequireReceiver);
			resetLastAnim = false;
		}
		if (enableLookAt && !targetCharObj)
		{
			FindPlayer();
		}
		if (testCount > -1 && (bool)base.animation)
		{
			if (lstTestRot1 == Quaternion.identity)
			{
				lstTestRot1 = tfs0[spineNo].localRotation;
				lstTestRot2 = tfs0[headNo].localRotation;
			}
			else
			{
				float num = Quaternion.Dot(tfs0[spineNo].localRotation, lstTestRot1);
				float num2 = Quaternion.Dot(tfs0[headNo].localRotation, lstTestRot2);
				if (num > 0.99999f && num2 > 0.99999f)
				{
					if (ready2)
					{
						testCount--;
						if (testCount <= 0)
						{
							base.enabled = false;
							return;
						}
					}
				}
				else
				{
					ready2 = true;
					testCount = -1;
				}
			}
		}
		if (lstRot != base.transform.rotation)
		{
			Quaternion quaternion = Quaternion.Inverse(lstRot) * base.transform.rotation;
			spinRot = quaternion * spinRot;
			headRot = quaternion * headRot;
			lstRot = base.transform.rotation;
		}
		bool flag = false;
		Vector3 zero = Vector3.zero;
		float num3 = 0f;
		Quaternion quaternion2 = Quaternion.identity;
		if ((bool)targetCharObj)
		{
			zero = targetCharObj.position - base.transform.position;
			num3 = zero.sqrMagnitude;
			quaternion2 = Quaternion.LookRotation(zero, Vector3.up);
			if (num3 < sqrDist && Vector3.Angle(base.transform.forward, zero) < viewAng)
			{
				flag = true;
			}
		}
		bool flag2 = enableLookAt && flag;
		for (int i = 0; i < this.num; i++)
		{
			tfs1[i].localPosition = tfs0[i].localPosition;
			tfs1[i].localScale = tfs0[i].localScale;
			Quaternion identity = Quaternion.identity;
			Quaternion identity2 = Quaternion.identity;
			if (i != spineNo && i != headNo)
			{
				tfs1[i].localRotation = tfs0[i].localRotation;
			}
			else if (i == spineNo)
			{
				identity2 = spineParent.rotation;
				if (flag2)
				{
					identity = quaternion2 * frontOfst1;
					float num4 = Quaternion.Angle(identity2, identity);
					if (num4 > maxSpineAngle)
					{
						identity = Quaternion.Lerp(identity2, identity, maxSpineAngle / num4);
					}
					spinRot = Quaternion.Lerp(spinRot, identity, spineSpeed * Time.deltaTime);
				}
				else
				{
					spinRot = Quaternion.Lerp(spinRot, identity2, spineSpeed * Time.deltaTime);
				}
				tfs1[i].rotation = spinRot * tfs0[i].localRotation;
			}
			else
			{
				if (i != headNo)
				{
					continue;
				}
				identity2 = headParent.rotation;
				if (flag2)
				{
					identity = quaternion2 * frontOfst2;
					float num4 = Quaternion.Angle(identity2, identity);
					if (num4 > maxHeadAngle)
					{
						identity = Quaternion.Lerp(identity2, identity, maxHeadAngle / num4);
					}
					headRot = Quaternion.Lerp(headRot, identity, headSpeed * Time.deltaTime);
				}
				else
				{
					headRot = Quaternion.Lerp(headRot, identity2, headSpeed * Time.deltaTime);
				}
				tfs1[i].rotation = headRot * tfs0[i].localRotation;
			}
		}
		if (enableCount > 0)
		{
			enableCount--;
			if (enableCount == 0)
			{
				RendererEnable();
				base.animation.cullingType = cullingType;
			}
		}
	}

	private int ChildCount(Transform tf, int n)
	{
		if (tf.name == spineObj.name)
		{
			spineNo = n;
		}
		if (tf.name == headObj.name)
		{
			headNo = n;
		}
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = ChildCount(tf.GetChild(i), n);
		}
		return n;
	}

	private int DigChild0(Transform tf, int n)
	{
		tfs0[n] = tf;
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = DigChild0(tf.GetChild(i), n);
		}
		return n;
	}

	private int DigChild1(Transform tf, int n)
	{
		tfs1[n] = tf;
		n++;
		for (int i = 0; i < tf.childCount; i++)
		{
			n = DigChild1(tf.GetChild(i), n);
		}
		return n;
	}
}
