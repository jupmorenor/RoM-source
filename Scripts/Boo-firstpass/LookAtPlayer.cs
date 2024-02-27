using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class LookAtPlayer : MonoBehaviour
{
	public float delay;

	public Transform targetCharObj;

	public float maxHeadAngle;

	public float maxSpineAngle;

	public float headSpeed;

	public float spineSpeed;

	public float distance;

	public bool enableLookAt;

	public float fieldOfViewAng;

	public bool resetLastAnim;

	public bool ready;

	public bool ready2;

	private float sqrDist;

	private Transform headObj;

	public Transform spineObj;

	public Transform dumySpinObj;

	public string spineObjName;

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

	private Quaternion lstTestRot1;

	private Quaternion lstTestRot2;

	private SkinnedMeshRenderer[] rends;

	private int enableCount;

	private int cullingType;

	public LookAtPlayer()
	{
		delay = 5f;
		maxHeadAngle = 45f;
		maxSpineAngle = 20f;
		headSpeed = 6f;
		spineSpeed = 2f;
		distance = 6f;
		enableLookAt = true;
		fieldOfViewAng = 200f;
		spineObjName = string.Empty;
		lstTestRot1 = Quaternion.identity;
		lstTestRot2 = Quaternion.identity;
	}

	public void EnableLookAt(bool b)
	{
		enableLookAt = b;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
			RendererDisable();
			enableCount = 2;
			if (animation != null)
			{
				cullingType = (int)animation.cullingType;
				animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			resetLastAnim = true;
		}
	}

	public void OnEnable()
	{
		if (!ready)
		{
			Init();
			RendererDisable();
			enableCount = 2;
			if (animation != null)
			{
				cullingType = (int)animation.cullingType;
				animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			resetLastAnim = true;
		}
	}

	public void OnDisable()
	{
		if (ready)
		{
			if (spineObj != null)
			{
				spineObj.name = spineObjName;
			}
			if (dumySpinObj != null)
			{
				UnityEngine.Object.Destroy(dumySpinObj.gameObject);
			}
			gameObject.SendMessage("RestartLastAnim", SendMessageOptions.DontRequireReceiver);
			if (animation != null)
			{
				cullingType = (int)animation.cullingType;
				animation.cullingType = AnimationCullingType.AlwaysAnimate;
			}
			ready = false;
		}
	}

	public void FindPlayer()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		if ((bool)gameObject)
		{
			targetCharObj = gameObject.transform;
		}
	}

	public void Init()
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
		transform = this.transform.Find("y_ang");
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
			lstRot = this.transform.rotation;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(spineObj.gameObject);
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
			frontOfst1 = Quaternion.Inverse(this.transform.rotation) * spineParent.rotation;
			frontOfst2 = Quaternion.Inverse(this.transform.rotation) * headParent.rotation;
			viewAng = fieldOfViewAng / 2f;
			lstTestRot1 = Quaternion.identity;
			lstTestRot2 = Quaternion.identity;
			testCount = 30;
			ready = true;
		}
	}

	public void RendererDisable()
	{
		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		int length = componentsInChildren.Length;
		rends = new SkinnedMeshRenderer[length];
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			SkinnedMeshRenderer[] array = rends;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, index)] as SkinnedMeshRenderer;
			SkinnedMeshRenderer[] array2 = rends;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index)].enabled = false;
		}
	}

	public void RendererEnable()
	{
		if (rends == null)
		{
			return;
		}
		int num = 0;
		int length = rends.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			SkinnedMeshRenderer[] array = rends;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != null)
			{
				SkinnedMeshRenderer[] array2 = rends;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].enabled = true;
			}
		}
	}

	public void LateUpdate()
	{
		if (!ready)
		{
			return;
		}
		if (resetLastAnim)
		{
			gameObject.SendMessage("RestartLastAnim", SendMessageOptions.DontRequireReceiver);
			resetLastAnim = false;
		}
		if (enableLookAt && !targetCharObj)
		{
			FindPlayer();
		}
		checked
		{
			if (testCount > -1 && (bool)animation)
			{
				if (lstTestRot1 == Quaternion.identity)
				{
					Transform[] array = tfs0;
					lstTestRot1 = array[RuntimeServices.NormalizeArrayIndex(array, spineNo)].localRotation;
					Transform[] array2 = tfs0;
					lstTestRot2 = array2[RuntimeServices.NormalizeArrayIndex(array2, headNo)].localRotation;
				}
				else
				{
					Transform[] array3 = tfs0;
					float num = Quaternion.Dot(array3[RuntimeServices.NormalizeArrayIndex(array3, spineNo)].localRotation, lstTestRot1);
					Transform[] array4 = tfs0;
					float num2 = Quaternion.Dot(array4[RuntimeServices.NormalizeArrayIndex(array4, headNo)].localRotation, lstTestRot2);
					if (!(num <= 0.99999f) && !(num2 <= 0.99999f))
					{
						if (ready2)
						{
							testCount--;
							if (testCount <= 0)
							{
								enabled = false;
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
			if (lstRot != transform.rotation)
			{
				Quaternion quaternion = Quaternion.Inverse(lstRot) * transform.rotation;
				spinRot = quaternion * spinRot;
				headRot = quaternion * headRot;
				lstRot = transform.rotation;
			}
			bool flag = false;
			Vector3 zero = Vector3.zero;
			float num3 = 0f;
			Quaternion quaternion2 = Quaternion.identity;
			if ((bool)targetCharObj)
			{
				zero = targetCharObj.position - transform.position;
				num3 = zero.sqrMagnitude;
				quaternion2 = Quaternion.LookRotation(zero, Vector3.up);
				if (!(num3 >= sqrDist) && !(Vector3.Angle(transform.forward, zero) >= viewAng))
				{
					flag = true;
				}
			}
			bool num4 = enableLookAt;
			if (num4)
			{
				num4 = flag;
			}
			bool flag2 = num4;
			int num5 = default(int);
			IEnumerator<int> enumerator = Builtins.range(this.num).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num5 = enumerator.Current;
					Transform[] array5 = tfs1;
					Transform obj = array5[RuntimeServices.NormalizeArrayIndex(array5, num5)];
					Transform[] array6 = tfs0;
					obj.localPosition = array6[RuntimeServices.NormalizeArrayIndex(array6, num5)].localPosition;
					Transform[] array7 = tfs1;
					Transform obj2 = array7[RuntimeServices.NormalizeArrayIndex(array7, num5)];
					Transform[] array8 = tfs0;
					obj2.localScale = array8[RuntimeServices.NormalizeArrayIndex(array8, num5)].localScale;
					float num6 = default(float);
					Quaternion identity = Quaternion.identity;
					Quaternion identity2 = Quaternion.identity;
					if (num5 != spineNo && num5 != headNo)
					{
						Transform[] array9 = tfs1;
						Transform obj3 = array9[RuntimeServices.NormalizeArrayIndex(array9, num5)];
						Transform[] array10 = tfs0;
						obj3.localRotation = array10[RuntimeServices.NormalizeArrayIndex(array10, num5)].localRotation;
					}
					else if (num5 == spineNo)
					{
						identity2 = spineParent.rotation;
						if (flag2)
						{
							identity = quaternion2 * frontOfst1;
							num6 = Quaternion.Angle(identity2, identity);
							if (!(num6 <= maxSpineAngle))
							{
								identity = Quaternion.Lerp(identity2, identity, maxSpineAngle / num6);
							}
							spinRot = Quaternion.Lerp(spinRot, identity, spineSpeed * Time.deltaTime);
						}
						else
						{
							spinRot = Quaternion.Lerp(spinRot, identity2, spineSpeed * Time.deltaTime);
						}
						Transform[] array11 = tfs1;
						Transform obj4 = array11[RuntimeServices.NormalizeArrayIndex(array11, num5)];
						Quaternion quaternion3 = spinRot;
						Transform[] array12 = tfs0;
						obj4.rotation = quaternion3 * array12[RuntimeServices.NormalizeArrayIndex(array12, num5)].localRotation;
					}
					else
					{
						if (num5 != headNo)
						{
							continue;
						}
						identity2 = headParent.rotation;
						if (flag2)
						{
							identity = quaternion2 * frontOfst2;
							num6 = Quaternion.Angle(identity2, identity);
							if (!(num6 <= maxHeadAngle))
							{
								identity = Quaternion.Lerp(identity2, identity, maxHeadAngle / num6);
							}
							headRot = Quaternion.Lerp(headRot, identity, headSpeed * Time.deltaTime);
						}
						else
						{
							headRot = Quaternion.Lerp(headRot, identity2, headSpeed * Time.deltaTime);
						}
						Transform[] array13 = tfs1;
						Transform obj5 = array13[RuntimeServices.NormalizeArrayIndex(array13, num5)];
						Quaternion quaternion4 = headRot;
						Transform[] array14 = tfs0;
						obj5.rotation = quaternion4 * array14[RuntimeServices.NormalizeArrayIndex(array14, num5)].localRotation;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			if (enableCount > 0)
			{
				enableCount--;
				if (enableCount == 0)
				{
					RendererEnable();
					animation.cullingType = unchecked((AnimationCullingType)cullingType);
				}
			}
		}
	}

	public int ChildCount(Transform tf, int n)
	{
		if (tf.name == spineObj.name)
		{
			spineNo = n;
		}
		if (tf.name == headObj.name)
		{
			headNo = n;
		}
		n = checked(n + 1);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(tf.childCount).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				n = ChildCount(tf.GetChild(num), n);
			}
			return n;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public int DigChild0(Transform tf, int n)
	{
		Transform[] array = tfs0;
		array[RuntimeServices.NormalizeArrayIndex(array, n)] = tf;
		n = checked(n + 1);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(tf.childCount).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				n = DigChild0(tf.GetChild(num), n);
			}
			return n;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public int DigChild1(Transform tf, int n)
	{
		Transform[] array = tfs1;
		array[RuntimeServices.NormalizeArrayIndex(array, n)] = tf;
		n = checked(n + 1);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(tf.childCount).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				n = DigChild1(tf.GetChild(num), n);
			}
			return n;
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
