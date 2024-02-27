using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class CameraControl : BasicCamera
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00241262;

		public string _0024act_0024t_00241263;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241264;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241265;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241266;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241267;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241268;

		public __ActionBase__0024act_0024t_00241264_0024callable54_0024127_5__ _0024act_0024t_00241269;

		public __ActionBase__0024act_0024t_00241270_0024callable55_0024127_5__ _0024act_0024t_00241270;

		public IEnumerator _0024act_0024t_00241274;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00241262.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassbattleCameraUpdate : ActionBase
	{
		public bool update1st;
	}

	[Serializable]
	public class ActionClassfieldCameraUpdate : ActionBase
	{
		public bool withInterpol;

		public bool update1st;
	}

	[Serializable]
	public enum ActionEnum
	{
		fieldCameraUpdate,
		battleCameraUpdate,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024createDatabattleCameraUpdate_0024closure_00243000
	{
		internal Vector3 _0024_002412356_002414804;

		internal float _0024_002412349_002414805;

		internal Vector3 _0024_002412353_002414806;

		internal float _0024_002412354_002414807;

		internal Quaternion _0024_002412352_002414808;

		internal CameraControl _0024this_002414809;

		internal Vector3 _0024_002412350_002414810;

		internal float _0024_002412351_002414811;

		internal Quaternion _0024_002412355_002414812;

		public _0024createDatabattleCameraUpdate_0024closure_00243000(Vector3 _0024_002412356_002414804, float _0024_002412349_002414805, Vector3 _0024_002412353_002414806, float _0024_002412354_002414807, Quaternion _0024_002412352_002414808, CameraControl _0024this_002414809, Vector3 _0024_002412350_002414810, float _0024_002412351_002414811, Quaternion _0024_002412355_002414812)
		{
			this._0024_002412356_002414804 = _0024_002412356_002414804;
			this._0024_002412349_002414805 = _0024_002412349_002414805;
			this._0024_002412353_002414806 = _0024_002412353_002414806;
			this._0024_002412354_002414807 = _0024_002412354_002414807;
			this._0024_002412352_002414808 = _0024_002412352_002414808;
			this._0024this_002414809 = _0024this_002414809;
			this._0024_002412350_002414810 = _0024_002412350_002414810;
			this._0024_002412351_002414811 = _0024_002412351_002414811;
			this._0024_002412355_002414812 = _0024_002412355_002414812;
		}

		public void Invoke(ActionClassbattleCameraUpdate _0024act_0024t_00241261)
		{
			Vector3 zero = Vector3.zero;
			zero = _0024this_002414809.targetPosition + _0024this_002414809.centerOffset;
			float y = _0024this_002414809.myTransform.eulerAngles.y;
			_0024this_002414809.targetHeight = zero.y + _0024this_002414809.height;
			float y2 = _0024this_002414809.myTransform.position.y;
			y2 = ((!_0024act_0024t_00241261.update1st) ? Mathf.SmoothDamp(y2, _0024this_002414809.targetHeight, ref _0024this_002414809.heightVelocity, _0024this_002414809.heightSmoothLag) : _0024this_002414809.targetHeight);
			if (_0024act_0024t_00241261.update1st)
			{
				_0024this_002414809.currentDistance = _0024this_002414809.distance;
			}
			else
			{
				_0024this_002414809.currentDistance = Mathf.SmoothDamp(_0024this_002414809.currentDistance, _0024this_002414809.distance, ref _0024this_002414809.distanceVelocity, _0024this_002414809.distanceSmoothLag);
			}
			Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
			_0024this_002414809.myTransform.position = zero;
			_0024this_002414809.myTransform.position = _0024this_002414809.myTransform.position + quaternion * Vector3.back * _0024this_002414809.currentDistance;
			float num = (_0024_002412349_002414805 = y2);
			Vector3 vector = (_0024_002412350_002414810 = _0024this_002414809.myTransform.position);
			float num2 = (_0024_002412350_002414810.y = _0024_002412349_002414805);
			Vector3 vector3 = (_0024this_002414809.myTransform.position = _0024_002412350_002414810);
			if (!_0024act_0024t_00241261.update1st)
			{
				float num3 = (_0024_002412354_002414807 = Mathf.SmoothDamp(_0024this_002414809.transform.rotation.eulerAngles.x, _0024this_002414809.battleAngleX, ref _0024this_002414809.eulerAnglesXVelocity, 0.5f));
				Quaternion quaternion2 = (_0024_002412355_002414812 = _0024this_002414809.transform.rotation);
				Vector3 vector4 = (_0024_002412356_002414804 = _0024_002412355_002414812.eulerAngles);
				float num4 = (_0024_002412356_002414804.x = _0024_002412354_002414807);
				Vector3 vector6 = (_0024_002412355_002414812.eulerAngles = _0024_002412356_002414804);
				Quaternion quaternion4 = (_0024this_002414809.transform.rotation = _0024_002412355_002414812);
			}
			else
			{
				float num5 = (_0024_002412351_002414811 = _0024this_002414809.battleAngleX);
				Quaternion quaternion5 = (_0024_002412352_002414808 = _0024this_002414809.transform.rotation);
				Vector3 vector7 = (_0024_002412353_002414806 = _0024_002412352_002414808.eulerAngles);
				float num6 = (_0024_002412353_002414806.x = _0024_002412351_002414811);
				Vector3 vector9 = (_0024_002412352_002414808.eulerAngles = _0024_002412353_002414806);
				Quaternion quaternion7 = (_0024this_002414809.transform.rotation = _0024_002412352_002414808);
			}
			_0024act_0024t_00241261.update1st = false;
		}
	}

	[Serializable]
	internal class _0024createDatafieldCameraUpdate_0024closure_00243002
	{
		internal float _0024_002412357_002414813;

		internal Quaternion _0024_002412360_002414814;

		internal float _0024_002412359_002414815;

		internal Vector3 _0024_002412358_002414816;

		internal Vector3 _0024_002412361_002414817;

		internal CameraControl _0024this_002414818;

		public _0024createDatafieldCameraUpdate_0024closure_00243002(float _0024_002412357_002414813, Quaternion _0024_002412360_002414814, float _0024_002412359_002414815, Vector3 _0024_002412358_002414816, Vector3 _0024_002412361_002414817, CameraControl _0024this_002414818)
		{
			this._0024_002412357_002414813 = _0024_002412357_002414813;
			this._0024_002412360_002414814 = _0024_002412360_002414814;
			this._0024_002412359_002414815 = _0024_002412359_002414815;
			this._0024_002412358_002414816 = _0024_002412358_002414816;
			this._0024_002412361_002414817 = _0024_002412361_002414817;
			this._0024this_002414818 = _0024this_002414818;
		}

		public void Invoke(ActionClassfieldCameraUpdate _0024act_0024t_00241277)
		{
			if (_0024this_002414818.FieldCameraActive)
			{
				float num = Time.deltaTime / 0.0166f;
				float num2 = ((!_0024act_0024t_00241277.update1st) ? 0.3f : 1f);
				_0024this_002414818.centerOffset.x = _0024this_002414818.centerOffset.x + (_0024this_002414818.targetPosition.x - _0024this_002414818.preTargetPos.x) * num2;
				_0024this_002414818.centerOffset.x = Mathf.Clamp(_0024this_002414818.centerOffset.x, 0f - _0024this_002414818.fieldCenterOffsetX, _0024this_002414818.fieldCenterOffsetX);
				num2 = ((!_0024act_0024t_00241277.update1st) ? 0.5f : 1f);
				_0024this_002414818.distance += (_0024this_002414818.targetPosition.z - _0024this_002414818.preTargetPos.z) * num2;
				_0024this_002414818.distance = Mathf.Clamp(_0024this_002414818.distance, _0024this_002414818.fieldDistanceMin, _0024this_002414818.fieldDistanceMax);
				Vector3 zero = Vector3.zero;
				zero = _0024this_002414818.targetPosition + _0024this_002414818.centerOffset;
				float y = _0024this_002414818.myTransform.eulerAngles.y;
				_0024this_002414818.targetHeight = zero.y + _0024this_002414818.height;
				float y2 = _0024this_002414818.myTransform.position.y;
				y2 = ((!_0024act_0024t_00241277.update1st || _0024this_002414818.heightVelocity == 0f) ? Mathf.SmoothDamp(y2, _0024this_002414818.targetHeight, ref _0024this_002414818.heightVelocity, _0024this_002414818.heightSmoothLag) : _0024this_002414818.targetHeight);
				if (_0024act_0024t_00241277.update1st && _0024this_002414818.distanceVelocity != 0f)
				{
					_0024this_002414818.currentDistance = _0024this_002414818.distance;
				}
				else
				{
					_0024this_002414818.currentDistance = Mathf.SmoothDamp(_0024this_002414818.currentDistance, _0024this_002414818.distance, ref _0024this_002414818.distanceVelocity, _0024this_002414818.distanceSmoothLag);
				}
				Quaternion quaternion = Quaternion.Euler(0f, y, 0f);
				_0024this_002414818.myTransform.position = zero;
				_0024this_002414818.myTransform.position = _0024this_002414818.myTransform.position + quaternion * Vector3.back * _0024this_002414818.currentDistance;
				float num3 = (_0024_002412357_002414813 = y2);
				Vector3 vector = (_0024_002412358_002414816 = _0024this_002414818.myTransform.position);
				float num4 = (_0024_002412358_002414816.y = _0024_002412357_002414813);
				Vector3 vector3 = (_0024this_002414818.myTransform.position = _0024_002412358_002414816);
				if (_0024act_0024t_00241277.update1st && _0024this_002414818.distanceVelocity != 0f)
				{
					_0024this_002414818.currentRotX = _0024this_002414818.fieldAngleX;
				}
				else
				{
					_0024this_002414818.currentRotX = Mathf.SmoothDamp(_0024this_002414818.currentRotX, _0024this_002414818.fieldAngleX, ref _0024this_002414818.eulerAnglesXVelocity, 0.5f);
				}
				float num5 = (_0024_002412359_002414815 = _0024this_002414818.currentRotX);
				Quaternion quaternion2 = (_0024_002412360_002414814 = _0024this_002414818.transform.rotation);
				Vector3 vector4 = (_0024_002412361_002414817 = _0024_002412360_002414814.eulerAngles);
				float num6 = (_0024_002412361_002414817.x = _0024_002412359_002414815);
				Vector3 vector6 = (_0024_002412360_002414814.eulerAngles = _0024_002412361_002414817);
				Quaternion quaternion4 = (_0024this_002414818.transform.rotation = _0024_002412360_002414814);
				_0024this_002414818.preTargetPos = _0024this_002414818.targetPosition;
				_0024act_0024t_00241277.update1st = false;
			}
		}
	}

	[NonSerialized]
	private static Boo.Lang.List<CameraControl> _EnabledCameras = new Boo.Lang.List<CameraControl>();

	[NonSerialized]
	private const double DEFAULT_FIELD_ANGLE_X = 25.36566;

	[NonSerialized]
	private const float BATTLE_DISTANCE_DEFAULT = 7.5f;

	[NonSerialized]
	private const float BATTLE_HEIGHT_DEFAULT = 7.5f;

	private float battleDistance;

	private float battleHeight;

	private float battleAngleX;

	private float fieldDistanceMin;

	private float fieldDistanceMax;

	private float fieldHeight;

	private float fieldCenterOffsetX;

	private float fieldAngleX;

	private Vector3 initRotation;

	private float initDistance;

	private float initHeight;

	private Vector3 initCenterOffset;

	private float initHeightSmoothLag;

	private float initDistanceSmoothLag;

	private float targetHeight;

	private float heightVelocity;

	private float eulerAnglesXVelocity;

	private Transform myTransform;

	private Vector3 preTargetPos;

	private float currentDistance;

	private float distanceVelocity;

	private float currentRotX;

	private bool fieldCameraActive;

	private Dictionary<string, ActionBase> _0024act_0024t_00241271;

	private Dictionary<string, ActionEnum> _0024act_0024t_00241273;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00241272;

	public bool actionDebugFlag;

	public static CameraControl Current => (_EnabledCameras.Count <= 0) ? null : _EnabledCameras[0];

	public bool FieldCameraActive
	{
		get
		{
			return isPositioning || fieldCameraActive;
		}
		set
		{
			fieldCameraActive = value;
		}
	}

	public float FieldDistanceMax
	{
		get
		{
			return fieldDistanceMax;
		}
		set
		{
			fieldDistanceMax = value;
		}
	}

	public bool IsbattleCameraUpdate => currActionID("$default$") == ActionEnum.battleCameraUpdate;

	public float actionTime => currActionTime("$default$");

	public ActionClassbattleCameraUpdate battleCameraUpdateData => currAction("$default$") as ActionClassbattleCameraUpdate;

	public bool IsfieldCameraUpdate => currActionID("$default$") == ActionEnum.fieldCameraUpdate;

	public ActionClassfieldCameraUpdate fieldCameraUpdateData => currAction("$default$") as ActionClassfieldCameraUpdate;

	public CameraControl()
	{
		battleDistance = 7.5f;
		battleHeight = 7.5f;
		battleAngleX = 40f;
		fieldDistanceMin = 7f;
		fieldDistanceMax = 10f;
		fieldHeight = 5.5f;
		fieldCenterOffsetX = 1f;
		fieldAngleX = 25.36566f;
		targetHeight = 100000f;
		currentDistance = 3f;
		fieldCameraActive = true;
		_0024act_0024t_00241271 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00241273 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public void OnEnable()
	{
		_EnabledCameras.Add(this);
	}

	public void OnDisable()
	{
		_EnabledCameras.Remove(this);
	}

	public void Start()
	{
		myTransform = transform;
		if (!IsbattleCameraUpdate)
		{
			fieldCameraUpdate();
		}
	}

	private void tempInitParam()
	{
		initRotation = new Vector3(40f, 180f, 0f);
		initDistance = distance;
		initHeight = height;
		initCenterOffset = centerOffset;
		initHeightSmoothLag = heightSmoothLag;
		initDistanceSmoothLag = 0.3f;
		currentDistance = initDistance;
	}

	public void setInitParam()
	{
		transform.eulerAngles = initRotation;
		distance = initDistance;
		height = initHeight;
		centerOffset = initCenterOffset;
		heightSmoothLag = initHeightSmoothLag;
		distanceSmoothLag = initDistanceSmoothLag;
		currentDistance = initDistance;
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (Time.timeScale != 0f)
		{
			actUpdate();
		}
	}

	public void setAreaParameter(string sceneName)
	{
		centerOffset.z = 0f;
		fieldAngleX = 25.36566f;
		if (Regex.IsMatch(sceneName, "mountain_*."))
		{
			centerOffset.z = 2f;
			fieldAngleX = 20f;
		}
		else if (Regex.IsMatch(sceneName, "volcano_*."))
		{
			switch (sceneName)
			{
			case "volcano_001":
			case "volcano_002":
			case "volcano_003":
			case "volcano_006":
			case "volcano_007":
			case "volcano_008":
				centerOffset.z = 2f;
				fieldAngleX = 20f;
				break;
			}
		}
		tempInitParam();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00241271.ContainsKey(grp)) ? null : _0024act_0024t_00241271[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00241273.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00241273[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00241271.ContainsKey(grp)) ? 0f : _0024act_0024t_00241271[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00241271.ContainsKey(grp)) ? 0f : _0024act_0024t_00241271[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00241271.ContainsKey(grp)) ? 0f : _0024act_0024t_00241271[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00241273.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00241263) && _0024act_0024t_00241271.ContainsKey(act._0024act_0024t_00241263) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00241271[act._0024act_0024t_00241263]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.fieldCameraUpdate <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_00241263))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$1263)");
			}
			_0024act_0024t_00241271[act._0024act_0024t_00241263] = act;
			_0024act_0024t_00241273[act._0024act_0024t_00241263] = act._0024act_0024t_00241262;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00241272) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00241263);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00241263)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00241263)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00241265 != null)
		{
			actionBase._0024act_0024t_00241265(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00241264 != null)
			{
				act._0024act_0024t_00241264(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00241270 != null)
			{
				act._0024act_0024t_00241274 = act._0024act_0024t_00241270(act);
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
		foreach (ActionBase value in _0024act_0024t_00241271.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241272 = 0;
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
			if (actionBase._0024act_0024t_00241266 != null)
			{
				actionBase._0024act_0024t_00241266(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00241274 != null && !actionBase._0024act_0024t_00241274.MoveNext())
			{
				actionBase._0024act_0024t_00241274 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00241271.Values)
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
		_0024act_0024t_00241272 = 0;
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
			if (actionBase._0024act_0024t_00241267 != null)
			{
				actionBase._0024act_0024t_00241267(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00241272 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241271.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00241271[array2[i]];
				if (actionBase._0024act_0024t_00241268 != null)
				{
					actionBase._0024act_0024t_00241268(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00241271.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00241263 + " - " + value._0024act_0024t_00241262 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00241272 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241271.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00241271[array2[i]];
			if (actionBase._0024act_0024t_00241269 != null)
			{
				actionBase._0024act_0024t_00241269(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "CameraControl" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.battleCameraUpdate => createDatabattleCameraUpdate(), 
			ActionEnum.fieldCameraUpdate => createDatafieldCameraUpdate(), 
			_ => null, 
		};
	}

	public ActionClassbattleCameraUpdate battleCameraUpdate()
	{
		ActionClassbattleCameraUpdate actionClassbattleCameraUpdate = createbattleCameraUpdate();
		changeAction(actionClassbattleCameraUpdate);
		return actionClassbattleCameraUpdate;
	}

	public ActionClassbattleCameraUpdate createDatabattleCameraUpdate()
	{
		ActionClassbattleCameraUpdate actionClassbattleCameraUpdate = new ActionClassbattleCameraUpdate();
		actionClassbattleCameraUpdate._0024act_0024t_00241262 = ActionEnum.battleCameraUpdate;
		actionClassbattleCameraUpdate._0024act_0024t_00241263 = "$default$";
		actionClassbattleCameraUpdate._0024act_0024t_00241264 = _0024adaptor_0024__CameraControl_0024callable329_0024127_5___0024__ActionBase__0024act_0024t_00241264_0024callable54_0024127_5___0024129.Adapt(delegate(ActionClassbattleCameraUpdate _0024act_0024t_00241261)
		{
			distance = battleDistance;
			height = battleHeight;
			centerOffset.x = 0f;
			tempInitParam();
			_0024act_0024t_00241261.update1st = true;
		});
		Vector3 _0024_002412356_0024 = default(Vector3);
		float _0024_002412349_0024 = default(float);
		Vector3 _0024_002412353_0024 = default(Vector3);
		float _0024_002412354_0024 = default(float);
		Quaternion _0024_002412352_0024 = default(Quaternion);
		Vector3 _0024_002412350_0024 = default(Vector3);
		float _0024_002412351_0024 = default(float);
		Quaternion _0024_002412355_0024 = default(Quaternion);
		actionClassbattleCameraUpdate._0024act_0024t_00241266 = _0024adaptor_0024__CameraControl_0024callable329_0024127_5___0024__ActionBase__0024act_0024t_00241264_0024callable54_0024127_5___0024129.Adapt(new _0024createDatabattleCameraUpdate_0024closure_00243000(_0024_002412356_0024, _0024_002412349_0024, _0024_002412353_0024, _0024_002412354_0024, _0024_002412352_0024, this, _0024_002412350_0024, _0024_002412351_0024, _0024_002412355_0024).Invoke);
		return actionClassbattleCameraUpdate;
	}

	public ActionClassbattleCameraUpdate createbattleCameraUpdate()
	{
		return createDatabattleCameraUpdate();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00241271.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00241271["$default$"];
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

	public void fieldCameraUpdate()
	{
		fieldCameraUpdate(withInterpol: false);
	}

	public ActionClassfieldCameraUpdate fieldCameraUpdate(bool withInterpol)
	{
		ActionClassfieldCameraUpdate actionClassfieldCameraUpdate = createfieldCameraUpdate(withInterpol);
		changeAction(actionClassfieldCameraUpdate);
		return actionClassfieldCameraUpdate;
	}

	public ActionClassfieldCameraUpdate createDatafieldCameraUpdate()
	{
		ActionClassfieldCameraUpdate actionClassfieldCameraUpdate = new ActionClassfieldCameraUpdate();
		actionClassfieldCameraUpdate._0024act_0024t_00241262 = ActionEnum.fieldCameraUpdate;
		actionClassfieldCameraUpdate._0024act_0024t_00241263 = "$default$";
		actionClassfieldCameraUpdate._0024act_0024t_00241264 = _0024adaptor_0024__CameraControl_0024callable330_0024172_5___0024__ActionBase__0024act_0024t_00241264_0024callable54_0024127_5___0024130.Adapt(delegate(ActionClassfieldCameraUpdate _0024act_0024t_00241277)
		{
			distance = fieldDistanceMin;
			height = fieldHeight;
			preTargetPos = targetPosition;
			currentRotX = transform.rotation.eulerAngles.x;
			_0024act_0024t_00241277.update1st = !_0024act_0024t_00241277.withInterpol;
		});
		float _0024_002412357_0024 = default(float);
		Quaternion _0024_002412360_0024 = default(Quaternion);
		float _0024_002412359_0024 = default(float);
		Vector3 _0024_002412358_0024 = default(Vector3);
		Vector3 _0024_002412361_0024 = default(Vector3);
		actionClassfieldCameraUpdate._0024act_0024t_00241266 = _0024adaptor_0024__CameraControl_0024callable330_0024172_5___0024__ActionBase__0024act_0024t_00241264_0024callable54_0024127_5___0024130.Adapt(new _0024createDatafieldCameraUpdate_0024closure_00243002(_0024_002412357_0024, _0024_002412360_0024, _0024_002412359_0024, _0024_002412358_0024, _0024_002412361_0024, this).Invoke);
		return actionClassfieldCameraUpdate;
	}

	public ActionClassfieldCameraUpdate createfieldCameraUpdate(bool withInterpol)
	{
		ActionClassfieldCameraUpdate actionClassfieldCameraUpdate = createDatafieldCameraUpdate();
		actionClassfieldCameraUpdate.withInterpol = withInterpol;
		return actionClassfieldCameraUpdate;
	}

	public void fieldCameraReset()
	{
		if ((bool)target)
		{
			float y = target.eulerAngles.y;
			if (!(22.5 > (double)y) && !((double)y > 67.5))
			{
				centerOffset.x = fieldCenterOffsetX / 2f;
				distance = fieldDistanceMax * 0.75f + fieldDistanceMin * 0.25f;
			}
			else if (!(67.5 > (double)y) && !((double)y > 112.5))
			{
				centerOffset.x = fieldCenterOffsetX;
				distance = fieldDistanceMax * 0.5f + fieldDistanceMin * 0.5f;
			}
			else if (!(112.5 > (double)y) && !((double)y > 157.5))
			{
				centerOffset.x = fieldCenterOffsetX / 2f;
				distance = fieldDistanceMax * 0.25f + fieldDistanceMin * 0.75f;
			}
			else if (!(157.5 > (double)y) && !((double)y > 202.5))
			{
				centerOffset.x = 0f;
				distance = fieldDistanceMax * 0f + fieldDistanceMin * 1f;
			}
			else if (!(202.5 > (double)y) && !((double)y > 247.5))
			{
				centerOffset.x = (0f - fieldCenterOffsetX) / 2f;
				distance = fieldDistanceMax * 0.25f + fieldDistanceMin * 0.75f;
			}
			else if (!(247.5 > (double)y) && !((double)y > 292.5))
			{
				centerOffset.x = 0f - fieldCenterOffsetX;
				distance = fieldDistanceMax * 0.5f + fieldDistanceMin * 0.5f;
			}
			else if (!(292.5 > (double)y) && !((double)y > 337.5))
			{
				centerOffset.x = (0f - fieldCenterOffsetX) / 2f;
				distance = fieldDistanceMax * 0.75f + fieldDistanceMin * 0.25f;
			}
			else
			{
				centerOffset.x = 0f;
				distance = fieldDistanceMax * 1f + fieldDistanceMin * 0f;
			}
			Vector3 zero = Vector3.zero;
			zero = targetPosition + centerOffset;
			float y2 = myTransform.eulerAngles.y;
			targetHeight = zero.y + height;
			float y3 = myTransform.position.y;
			y3 = Mathf.SmoothDamp(y3, targetHeight, ref heightVelocity, 0f);
			currentDistance = Mathf.SmoothDamp(currentDistance, distance, ref distanceVelocity, 0f);
			Quaternion quaternion = Quaternion.Euler(0f, y2, 0f);
			myTransform.position = zero;
			myTransform.position += quaternion * Vector3.back * distance;
			float y4 = targetHeight;
			Vector3 position = myTransform.position;
			float num = (position.y = y4);
			Vector3 vector2 = (myTransform.position = position);
			currentRotX = fieldAngleX;
			float x = currentRotX;
			Quaternion rotation = transform.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			float num2 = (eulerAngles.x = x);
			Vector3 vector4 = (rotation.eulerAngles = eulerAngles);
			Quaternion quaternion3 = (transform.rotation = rotation);
			preTargetPos = targetPosition;
		}
	}

	public void SetBattleDistanceAndHeight(float _distance, float _height)
	{
		if (!(_distance <= 0f))
		{
			battleDistance = _distance;
		}
		else
		{
			battleDistance = 7.5f;
		}
		if (!(_height <= 0f))
		{
			battleHeight = _height;
		}
		else
		{
			battleHeight = 7.5f;
		}
		if (_distance > 0f || !(_height <= 0f))
		{
			battleCameraInit();
		}
	}

	private void battleCameraInit()
	{
		distance = battleDistance;
		height = battleHeight;
		centerOffset.x = 0f;
		tempInitParam();
		bool flag = true;
	}

	internal void _0024createDatabattleCameraUpdate_0024closure_00242999(ActionClassbattleCameraUpdate _0024act_0024t_00241261)
	{
		distance = battleDistance;
		height = battleHeight;
		centerOffset.x = 0f;
		tempInitParam();
		_0024act_0024t_00241261.update1st = true;
	}

	internal void _0024createDatafieldCameraUpdate_0024closure_00243001(ActionClassfieldCameraUpdate _0024act_0024t_00241277)
	{
		distance = fieldDistanceMin;
		height = fieldHeight;
		preTargetPos = targetPosition;
		currentRotX = transform.rotation.eulerAngles.x;
		_0024act_0024t_00241277.update1st = !_0024act_0024t_00241277.withInterpol;
	}
}
