using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ColosseumCamera : MonoBehaviour
{
	[Serializable]
	public class TargetsInfo
	{
		public int charNum;

		public Vector3 interest;

		public float minX;

		public float maxX;

		public float depth;

		public Boo.Lang.List<BaseControl> allChars;

		public TargetsInfo()
		{
			depth = 10f;
			allChars = new Boo.Lang.List<BaseControl>();
			init();
		}

		public void init()
		{
			charNum = 0;
			interest = Vector3.zero;
			minX = float.MaxValue;
			maxX = float.MinValue;
			depth = 10f;
			allChars.Clear();
		}

		public void update(Transform camTransform, float fov, float depthOffset)
		{
			init();
			int i = 0;
			BaseControl[] allControls = BaseControl.AllControls;
			checked
			{
				for (int length = allControls.Length; i < length; i++)
				{
					if (allControls[i] != null && allControls[i].enabled && !allControls[i].IsDead)
					{
						allChars.Add(allControls[i]);
					}
				}
				IEnumerator<BaseControl> enumerator = allChars.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BaseControl current = enumerator.Current;
						Vector3 position = current.transform.position;
						interest += position;
						minX = Mathf.Min(minX, position.x);
						maxX = Mathf.Max(maxX, position.x);
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				charNum = ((ICollection)allChars).Count;
				if (charNum > 0)
				{
					interest *= 1f / (float)charNum;
				}
				float num = float.MinValue;
				float num2 = float.MinValue;
				int num3 = 0;
				IEnumerator<BaseControl> enumerator2 = allChars.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						BaseControl current2 = enumerator2.Current;
						Vector3 vector = camTransform.InverseTransformPoint(current2.transform.position);
						if (vector.z > 0f)
						{
							num = Mathf.Max(num, Mathf.Abs(vector.x));
							num2 = Mathf.Max(num2, Mathf.Abs(vector.y));
							num3++;
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				float f = fov * ((float)Math.PI / 180f);
				float f2 = fov * ((float)Math.PI / 180f);
				if (num3 > 0)
				{
					float a = num / Mathf.Tan(f2);
					float b = num2 / Mathf.Tan(f);
					depth = Mathf.Max(a, b) + depthOffset;
				}
				else
				{
					depth = 10f;
				}
			}
		}
	}

	[Serializable]
	public class SingleChaser
	{
		public float minDist;

		public float maxDist;

		public float maxSpeed;

		public float coef;

		private float target;

		private float current;

		private bool isMoving;

		public float Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		public float Current => current;

		public SingleChaser()
		{
			minDist = 1f;
			maxDist = 2f;
			maxSpeed = 10f;
			coef = 0.8f;
		}

		public void init(float _target, float _current)
		{
			target = _target;
			current = _current;
			isMoving = false;
		}

		public void update(float _target, float dt)
		{
			target = _target;
			update(dt);
		}

		public void update(float dt)
		{
			float f = target - current;
			float num = Mathf.Abs(f);
			if (isMoving)
			{
				if (!(Mathf.Abs(num) < minDist))
				{
					float num2 = Mathf.Min(num * coef, maxSpeed * dt);
					current += Mathf.Sign(f) * num2;
				}
				else
				{
					isMoving = false;
				}
			}
			else if (!(Mathf.Abs(num) <= maxDist))
			{
				isMoving = true;
			}
		}
	}

	[Serializable]
	public class PositionChaser
	{
		public float minDist;

		public float maxDist;

		public float maxSpeed;

		public float coef;

		private Vector3 target;

		private Vector3 current;

		private bool isMoving;

		public Vector3 Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		public Vector3 Current => current;

		public PositionChaser()
		{
			minDist = 1f;
			maxDist = 2f;
			maxSpeed = 10f;
			coef = 0.8f;
		}

		public void init(Vector3 _target, Vector3 _current)
		{
			target = _target;
			current = _current;
			isMoving = false;
		}

		public void update(Vector3 _target, float dt)
		{
			target = _target;
			update(dt);
		}

		public void update(float dt)
		{
			Vector3 vector = target - current;
			float magnitude = vector.magnitude;
			if (isMoving)
			{
				if (!(Mathf.Abs(magnitude) < minDist))
				{
					float num = Mathf.Min(magnitude * coef, maxSpeed * dt);
					current += vector.normalized * num;
				}
				else
				{
					isMoving = false;
				}
			}
			else if (!(Mathf.Abs(magnitude) <= maxDist))
			{
				isMoving = true;
			}
		}
	}

	public float defaultCenterChaserMinDist;

	public float defaultCenterChaserMaxDist;

	public float defaultCenterChaserCoef;

	public float defaultCenterChaserMaxSpeed;

	public float defaultDepthChaserMinDist;

	public float defaultDepthChaserMaxDist;

	public float defaultDepthChaserCoef;

	public float defaultDepthChaserMaxSpeed;

	public float minDepth;

	public float maxDepth;

	public float depthOffset;

	public float touchStopUpdateTime;

	public UltimateOrbitCamera orbitCamera;

	private float restStopUpdateTime;

	private PositionChaser centerChaser;

	private SingleChaser depthChaser;

	private bool notInitialized;

	private TargetsInfo targetsInfo;

	private Camera myCam;

	public ColosseumCamera()
	{
		defaultCenterChaserMinDist = 0.2f;
		defaultCenterChaserMaxDist = 1.8f;
		defaultCenterChaserCoef = 0.1f;
		defaultCenterChaserMaxSpeed = 10f;
		defaultDepthChaserMinDist = 0.1f;
		defaultDepthChaserMaxDist = 2f;
		defaultDepthChaserCoef = 0.05f;
		defaultDepthChaserMaxSpeed = 2f;
		minDepth = 10f;
		maxDepth = 30f;
		depthOffset = 7.5f;
		touchStopUpdateTime = 5f;
		centerChaser = new PositionChaser();
		depthChaser = new SingleChaser();
		notInitialized = true;
		targetsInfo = new TargetsInfo();
	}

	public void Init()
	{
		if (notInitialized)
		{
			myCam = GetComponent<Camera>();
			if (!(myCam != null))
			{
				throw new AssertionFailedException("myCam != null");
			}
			centerChaser.minDist = defaultCenterChaserMinDist;
			centerChaser.maxDist = defaultCenterChaserMaxDist;
			centerChaser.maxSpeed = defaultCenterChaserMaxSpeed;
			centerChaser.coef = defaultCenterChaserCoef;
			depthChaser.minDist = defaultDepthChaserMinDist;
			depthChaser.maxDist = defaultDepthChaserMaxDist;
			depthChaser.maxSpeed = defaultDepthChaserMaxSpeed;
			depthChaser.coef = defaultDepthChaserCoef;
			targetsInfo.update(transform, myCam.fieldOfView, depthOffset);
			centerChaser.init(targetsInfo.interest, targetsInfo.interest);
			depthChaser.init(targetsInfo.depth, orbitCamera.distance);
			notInitialized = false;
			orbitCamera.target.parent = null;
			orbitCamera.Init();
		}
	}

	public void LateUpdate()
	{
		if (notInitialized)
		{
			Init();
		}
		if (Input.GetMouseButton(0))
		{
			restStopUpdateTime = touchStopUpdateTime;
		}
		if (!(restStopUpdateTime <= 0f))
		{
			restStopUpdateTime -= Time.deltaTime;
			if (!(restStopUpdateTime > 0f))
			{
				depthChaser.init(orbitCamera.targetDistance, orbitCamera.distance);
			}
		}
		else
		{
			depthChaser.update(targetsInfo.depth, Time.deltaTime);
			orbitCamera.distance = (orbitCamera.targetDistance = Mathf.Clamp(depthChaser.Current, minDepth, maxDepth));
		}
		targetsInfo.update(transform, myCam.fieldOfView, depthOffset);
		centerChaser.update(targetsInfo.interest, Time.deltaTime);
		orbitCamera.target.position = centerChaser.Current;
	}

	public void OnDisable()
	{
		orbitCamera.enabled = false;
	}

	public void OnEnable()
	{
		orbitCamera.enabled = true;
	}
}
