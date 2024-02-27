using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class PlayerMoveControl
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00241404;

		public string _0024act_0024t_00241405;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241406;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241407;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241408;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241409;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241410;

		public __ActionBase__0024act_0024t_00241406_0024callable66_002436_5__ _0024act_0024t_00241411;

		public __ActionBase__0024act_0024t_00241412_0024callable67_002436_5__ _0024act_0024t_00241412;

		public IEnumerator _0024act_0024t_00241416;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00241404.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassupdate : ActionBase
	{
		public RaycastHit chit;

		public float ldist;

		public float rdist;

		public Ray cray;

		public Ray lray;

		public Ray rray;

		public GameObject tobj1;

		public GameObject tobj2;

		public GameObject tobj3;

		public Vector3 gnorm;

		public Vector3 gpos;

		public float lrChangeTime;

		public bool curSideIsLeft;
	}

	[Serializable]
	public enum ActionEnum
	{
		update,
		NUM,
		_noaction_
	}

	private Transform player;

	private Vector3 target;

	private bool targetSet;

	private Vector3 front;

	private bool hasFrontDir;

	[NonSerialized]
	private static readonly float RANGE = 0.87266463f;

	[NonSerialized]
	private static readonly float FRONT_RANGE = 0.08726646f;

	[NonSerialized]
	private const float CAST_LIMIT = 5f;

	[NonSerialized]
	private const float LR_MINIMUM_LIMIT = 2f;

	[NonSerialized]
	private const string MARKER_PREFAB = "Prefab/Debug/DebugMarkerSphere";

	private Vector3 groundNormal;

	[NonSerialized]
	public static bool DispDebugInfo;

	private Dictionary<string, ActionBase> _0024act_0024t_00241413;

	private Dictionary<string, ActionEnum> _0024act_0024t_00241415;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00241414;

	public bool actionDebugFlag;

	private float ip;

	private float weight;

	private Vector3 prd;

	private Vector3 dir;

	public Vector3 Target
	{
		set
		{
			target = value;
			targetSet = true;
		}
	}

	public bool Isupdate => currActionID("$default$") == ActionEnum.update;

	public float actionTime => currActionTime("$default$");

	public ActionClassupdate updateData => currAction("$default$") as ActionClassupdate;

	public Transform Player
	{
		get
		{
			return player;
		}
		set
		{
			player = value;
		}
	}

	public Vector3 FrontDir => front;

	public bool HasFrontDir => hasFrontDir;

	public PlayerMoveControl(Transform _player)
	{
		_0024act_0024t_00241413 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00241415 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
		player = _player;
		update();
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00241413.ContainsKey(grp)) ? null : _0024act_0024t_00241413[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00241415.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00241415[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00241413.ContainsKey(grp)) ? 0f : _0024act_0024t_00241413[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00241413.ContainsKey(grp)) ? 0f : _0024act_0024t_00241413[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00241413.ContainsKey(grp)) ? 0f : _0024act_0024t_00241413[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00241415.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00241405) && _0024act_0024t_00241413.ContainsKey(act._0024act_0024t_00241405) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00241413[act._0024act_0024t_00241405]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.update <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_00241405))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$1405)");
			}
			_0024act_0024t_00241413[act._0024act_0024t_00241405] = act;
			_0024act_0024t_00241415[act._0024act_0024t_00241405] = act._0024act_0024t_00241404;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00241414) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00241405);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00241405)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00241405)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00241407 != null)
		{
			actionBase._0024act_0024t_00241407(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00241406 != null)
			{
				act._0024act_0024t_00241406(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00241412 != null)
			{
				act._0024act_0024t_00241416 = act._0024act_0024t_00241412(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_00241413.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241414 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_00241408 != null)
			{
				actionBase._0024act_0024t_00241408(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00241416 != null && !actionBase._0024act_0024t_00241416.MoveNext())
			{
				actionBase._0024act_0024t_00241416 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00241413.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241414 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_00241409 != null)
			{
				actionBase._0024act_0024t_00241409(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00241414 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241413.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00241413[array2[i]];
				if (actionBase._0024act_0024t_00241410 != null)
				{
					actionBase._0024act_0024t_00241410(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00241413.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00241405 + " - " + value._0024act_0024t_00241404 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00241414 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241413.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00241413[array2[i]];
			if (actionBase._0024act_0024t_00241411 != null)
			{
				actionBase._0024act_0024t_00241411(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "PlayerMoveControl" + " enum: " + actID);
		}
		return (actID != 0) ? null : createDataupdate();
	}

	public ActionClassupdate update()
	{
		ActionClassupdate actionClassupdate = createupdate();
		changeAction(actionClassupdate);
		return actionClassupdate;
	}

	public ActionClassupdate createDataupdate()
	{
		ActionClassupdate actionClassupdate = new ActionClassupdate();
		actionClassupdate._0024act_0024t_00241404 = ActionEnum.update;
		actionClassupdate._0024act_0024t_00241405 = "$default$";
		checked
		{
			actionClassupdate._0024act_0024t_00241410 = _0024adaptor_0024__PlayerMoveControl_0024callable336_002436_5___0024__ActionBase__0024act_0024t_00241406_0024callable66_002436_5___0024136.Adapt(delegate(ActionClassupdate _0024act_0024t_00241403)
			{
				if (DispDebugInfo)
				{
					GUIStyle gUIStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
					gUIStyle.fontSize = 18;
					int num = 100;
					Rect position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "hasFrontDir:" + hasFrontDir, gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "front:" + front, gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "chit:" + toString(_0024act_0024t_00241403.chit), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "ldist:" + toString(_0024act_0024t_00241403.ldist), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "rdist:" + toString(_0024act_0024t_00241403.rdist), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("l>r: ").Append(_0024act_0024t_00241403.ldist > _0024act_0024t_00241403.rdist).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "cray:" + toString(_0024act_0024t_00241403.cray), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "lray:" + toString(_0024act_0024t_00241403.lray), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "rray:" + toString(_0024act_0024t_00241403.rray), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("ip:").Append(ip).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("weight:").Append(weight).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("castlimit:").Append(5f).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("prd:").Append(prd).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("dir:").Append(dir).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("gnorm:").Append(groundNormal).ToString(), gUIStyle);
					num += 32;
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, new StringBuilder("gpos:").Append(_0024act_0024t_00241403.gpos).ToString(), gUIStyle);
					num += 32;
					if (_0024act_0024t_00241403.chit.transform != null)
					{
						position = new Rect(0f, num, 512f, 32f);
						GUI.Label(position, "chit obj:" + _0024act_0024t_00241403.chit.transform.root, gUIStyle);
						num += 32;
					}
				}
			});
			actionClassupdate._0024act_0024t_00241408 = _0024adaptor_0024__PlayerMoveControl_0024callable336_002436_5___0024__ActionBase__0024act_0024t_00241406_0024callable66_002436_5___0024136.Adapt(delegate(ActionClassupdate _0024act_0024t_00241403)
			{
				hasFrontDir = false;
				if (!(player == null))
				{
					if (_0024act_0024t_00241403.tobj1 == null)
					{
						_0024act_0024t_00241403.tobj1 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
					}
					if (_0024act_0024t_00241403.tobj2 == null)
					{
						_0024act_0024t_00241403.tobj2 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
					}
					if (_0024act_0024t_00241403.tobj3 == null)
					{
						_0024act_0024t_00241403.tobj3 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
					}
					__PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__ _PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__ = delegate(GameObject o, Vector3 pos)
					{
						if (!(o == null))
						{
							if (DispDebugInfo)
							{
								o.SetActive(value: true);
								o.transform.position = pos;
							}
							else
							{
								o.SetActive(value: false);
							}
						}
					};
					_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj1, target);
					hasFrontDir = false;
					int i = 0;
					float[] array = new float[2]
					{
						0f - FRONT_RANGE,
						FRONT_RANGE
					};
					for (int length = array.Length; i < length; i++)
					{
						_0024act_0024t_00241403.cray = createRay(0f);
						if (!(raycast(_0024act_0024t_00241403.cray, ref _0024act_0024t_00241403.chit) > 5f))
						{
							_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj2, _0024act_0024t_00241403.cray.origin);
							_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj3, _0024act_0024t_00241403.chit.point);
							hasFrontDir = true;
							break;
						}
						_0024act_0024t_00241403.tobj2.SetActive(value: false);
						_0024act_0024t_00241403.tobj3.SetActive(value: false);
					}
					Ray ray = createVRay();
					RaycastHit[] array2 = Physics.RaycastAll(ray);
					groundNormal = new Vector3(0f, 1f, 0f);
					_0024act_0024t_00241403.gpos = player.transform.position;
					int j = 0;
					RaycastHit[] array3 = array2;
					for (int length2 = array3.Length; j < length2; j++)
					{
						if (array3[j].transform.tag == "Plane")
						{
							groundNormal = array3[j].normal;
							_0024act_0024t_00241403.gpos = array3[j].point;
							break;
						}
					}
					_0024act_0024t_00241403.lray = createRay(0f - RANGE);
					_0024act_0024t_00241403.rray = createRay(RANGE);
					_0024act_0024t_00241403.ldist = raycast(_0024act_0024t_00241403.lray);
					_0024act_0024t_00241403.rdist = raycast(_0024act_0024t_00241403.rray);
					if (hasFrontDir || _0024act_0024t_00241403.ldist <= 2f || _0024act_0024t_00241403.rdist <= 2f)
					{
						_0024act_0024t_00241403.lrChangeTime -= Time.deltaTime;
						if (!(_0024act_0024t_00241403.lrChangeTime > 0f))
						{
							_0024act_0024t_00241403.curSideIsLeft = _0024act_0024t_00241403.ldist > _0024act_0024t_00241403.rdist;
							_0024act_0024t_00241403.lrChangeTime = 0.5f;
						}
						if (_0024act_0024t_00241403.curSideIsLeft)
						{
							front = calcFront(_0024act_0024t_00241403.cray, _0024act_0024t_00241403.chit, _0024act_0024t_00241403.lray);
						}
						else
						{
							front = calcFront(_0024act_0024t_00241403.cray, _0024act_0024t_00241403.chit, _0024act_0024t_00241403.rray);
						}
					}
				}
			});
			return actionClassupdate;
		}
	}

	public ActionClassupdate createupdate()
	{
		return createDataupdate();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00241413.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00241413["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	private static string toString(RaycastHit hit)
	{
		return new StringBuilder("RaycastHit(p:").Append(hit.point).Append(" d:").Append(hit.distance)
			.Append(" n:")
			.Append(hit.normal)
			.Append(")")
			.ToString();
	}

	private static string toString(Ray ray)
	{
		return new StringBuilder("Ray(o:").Append(ray.origin).Append(" d:").Append(ray.direction)
			.Append(")")
			.ToString();
	}

	private static string toString(float v)
	{
		return new StringBuilder().Append(v).ToString();
	}

	private Ray createVRay()
	{
		Vector3 origin = player.transform.position + new Vector3(0f, 10f, 0f);
		return new Ray(origin, new Vector3(0f, -1f, 0f));
	}

	private Ray createRay(float angle)
	{
		int num = 1;
		Vector3 position = player.position;
		position.y += num;
		Vector3 vector = target;
		vector.y = position.y;
		Vector3 vector2 = vector - player.position;
		float f = Mathf.Atan2(vector2.x, vector2.z) + angle;
		dir = new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f));
		return new Ray(position, projectionOnPlane(dir, groundNormal));
	}

	private float raycast(Ray ray)
	{
		RaycastHit hit = default(RaycastHit);
		return raycast(ray, ref hit);
	}

	private float raycast(Ray ray, ref RaycastHit hit)
	{
		return raycast(ray, ref hit, 5f);
	}

	private float raycast(Ray ray, ref RaycastHit hit, float limit)
	{
		RaycastHit[] array = Physics.RaycastAll(ray, limit, 1);
		RaycastHit[] array2 = array;
		int length = array2.Length;
		int num = 0;
		float result;
		while (true)
		{
			if (num < length)
			{
				RaycastHit raycastHit = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num++))];
				Collider collider = raycastHit.collider;
				if (!collider.isTrigger && collider.transform.root.gameObject.layer == 0)
				{
					hit = raycastHit;
					result = raycastHit.distance;
					break;
				}
				continue;
			}
			result = float.PositiveInfinity;
			break;
		}
		return result;
	}

	private static bool IsInfinity(float f)
	{
		if (f == float.PositiveInfinity)
		{
		}
		return false;
	}

	private Vector3 calcFront(Ray cray, RaycastHit chit, Ray eray)
	{
		prd = Vector3.Project(eray.direction, cray.direction);
		dir = eray.direction - prd;
		weight = (5f - Mathf.Clamp(chit.distance - 2f, 0f, 5f)) / 5f;
		weight *= weight;
		return Vector3.Slerp(cray.direction.normalized, dir.normalized, weight);
	}

	private Vector3 projectionOnPlane(Vector3 v, Vector3 norm)
	{
		return v - Vector3.Project(v, norm);
	}

	internal void _0024createDataupdate_0024closure_00243027(ActionClassupdate _0024act_0024t_00241403)
	{
		checked
		{
			if (DispDebugInfo)
			{
				GUIStyle gUIStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
				gUIStyle.fontSize = 18;
				int num = 100;
				Rect position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "hasFrontDir:" + hasFrontDir, gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "front:" + front, gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "chit:" + toString(_0024act_0024t_00241403.chit), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "ldist:" + toString(_0024act_0024t_00241403.ldist), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "rdist:" + toString(_0024act_0024t_00241403.rdist), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("l>r: ").Append(_0024act_0024t_00241403.ldist > _0024act_0024t_00241403.rdist).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "cray:" + toString(_0024act_0024t_00241403.cray), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "lray:" + toString(_0024act_0024t_00241403.lray), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, "rray:" + toString(_0024act_0024t_00241403.rray), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("ip:").Append(ip).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("weight:").Append(weight).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("castlimit:").Append(5f).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("prd:").Append(prd).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("dir:").Append(dir).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("gnorm:").Append(groundNormal).ToString(), gUIStyle);
				num += 32;
				position = new Rect(0f, num, 512f, 32f);
				GUI.Label(position, new StringBuilder("gpos:").Append(_0024act_0024t_00241403.gpos).ToString(), gUIStyle);
				num += 32;
				if (_0024act_0024t_00241403.chit.transform != null)
				{
					position = new Rect(0f, num, 512f, 32f);
					GUI.Label(position, "chit obj:" + _0024act_0024t_00241403.chit.transform.root, gUIStyle);
					num += 32;
				}
			}
		}
	}

	internal void _0024createDataupdate_0024closure_00243028(ActionClassupdate _0024act_0024t_00241403)
	{
		hasFrontDir = false;
		if (player == null)
		{
			return;
		}
		if (_0024act_0024t_00241403.tobj1 == null)
		{
			_0024act_0024t_00241403.tobj1 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
		}
		if (_0024act_0024t_00241403.tobj2 == null)
		{
			_0024act_0024t_00241403.tobj2 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
		}
		if (_0024act_0024t_00241403.tobj3 == null)
		{
			_0024act_0024t_00241403.tobj3 = GameAssetModule.InstantiatePrefab("Prefab/Debug/DebugMarkerSphere");
		}
		__PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__ _PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__ = delegate(GameObject o, Vector3 pos)
		{
			if (!(o == null))
			{
				if (DispDebugInfo)
				{
					o.SetActive(value: true);
					o.transform.position = pos;
				}
				else
				{
					o.SetActive(value: false);
				}
			}
		};
		_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj1, target);
		hasFrontDir = false;
		int i = 0;
		float[] array = new float[2]
		{
			0f - FRONT_RANGE,
			FRONT_RANGE
		};
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				_0024act_0024t_00241403.cray = createRay(0f);
				if (!(raycast(_0024act_0024t_00241403.cray, ref _0024act_0024t_00241403.chit) > 5f))
				{
					_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj2, _0024act_0024t_00241403.cray.origin);
					_PlayerMoveControl__0024createDataupdate_0024closure_00243028_0024callable132_002462_13__(_0024act_0024t_00241403.tobj3, _0024act_0024t_00241403.chit.point);
					hasFrontDir = true;
					break;
				}
				_0024act_0024t_00241403.tobj2.SetActive(value: false);
				_0024act_0024t_00241403.tobj3.SetActive(value: false);
			}
			Ray ray = createVRay();
			RaycastHit[] array2 = Physics.RaycastAll(ray);
			groundNormal = new Vector3(0f, 1f, 0f);
			_0024act_0024t_00241403.gpos = player.transform.position;
			int j = 0;
			RaycastHit[] array3 = array2;
			for (int length2 = array3.Length; j < length2; j++)
			{
				if (array3[j].transform.tag == "Plane")
				{
					groundNormal = array3[j].normal;
					_0024act_0024t_00241403.gpos = array3[j].point;
					break;
				}
			}
			_0024act_0024t_00241403.lray = createRay(0f - RANGE);
			_0024act_0024t_00241403.rray = createRay(RANGE);
			_0024act_0024t_00241403.ldist = raycast(_0024act_0024t_00241403.lray);
			_0024act_0024t_00241403.rdist = raycast(_0024act_0024t_00241403.rray);
			if (hasFrontDir || _0024act_0024t_00241403.ldist <= 2f || _0024act_0024t_00241403.rdist <= 2f)
			{
				_0024act_0024t_00241403.lrChangeTime -= Time.deltaTime;
				if (!(_0024act_0024t_00241403.lrChangeTime > 0f))
				{
					_0024act_0024t_00241403.curSideIsLeft = _0024act_0024t_00241403.ldist > _0024act_0024t_00241403.rdist;
					_0024act_0024t_00241403.lrChangeTime = 0.5f;
				}
				if (_0024act_0024t_00241403.curSideIsLeft)
				{
					front = calcFront(_0024act_0024t_00241403.cray, _0024act_0024t_00241403.chit, _0024act_0024t_00241403.lray);
				}
				else
				{
					front = calcFront(_0024act_0024t_00241403.cray, _0024act_0024t_00241403.chit, _0024act_0024t_00241403.rray);
				}
			}
		}
	}

	internal void _0024_0024createDataupdate_0024closure_00243028_0024setDebugBall_00243029(GameObject o, Vector3 pos)
	{
		if (!(o == null))
		{
			if (DispDebugInfo)
			{
				o.SetActive(value: true);
				o.transform.position = pos;
			}
			else
			{
				o.SetActive(value: false);
			}
		}
	}
}
