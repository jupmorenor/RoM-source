using System;
using System.Collections.Generic;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ActionCommandEffect : MerlinActionControl.ActTimeCommand
{
	[Serializable]
	public enum TransformMode
	{
		None,
		Pos,
		PosRot
	}

	[Serializable]
	public class Message
	{
		public string name;

		public object param;
	}

	public GameObject effect;

	public bool killAtDispose;

	public float lifeTime;

	public TransformMode emitMode;

	public TransformMode constraintMode;

	public string boneName;

	public Vector3 offset;

	public Vector3 rotation;

	public GameObject deadEffect;

	public RespPoppet chainSkillPoppet;

	public bool dangle;

	public bool aliveOverMotionChange;

	public Vector3 worldPosOffset;

	private Boo.Lang.List<Message> messages;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ emitCallback;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ deadCallback;

	private Transform source;

	private Transform clone;

	private bool emitted;

	private bool killed;

	private ThrowObject throwObjectComponent;

	private ThrowObjParams throwObjParams;

	private StateChangeAreaData areaData;

	private bool applyRotation;

	public override bool UpdateWithWorldTime
	{
		get
		{
			bool num = emitted;
			if (num)
			{
				num = !killAtDispose;
			}
			return num;
		}
	}

	public override bool DisposeAtMotionChange
	{
		get
		{
			bool num = !emitted;
			if (num)
			{
				num = !aliveOverMotionChange;
			}
			return num;
		}
	}

	public override bool IsDead => killed;

	public GameObject Instance => (!(clone != null)) ? null : clone.gameObject;

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ EmitCallback
	{
		get
		{
			return emitCallback;
		}
		set
		{
			emitCallback = value;
		}
	}

	public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ DeadCallback
	{
		get
		{
			return deadCallback;
		}
		set
		{
			deadCallback = value;
		}
	}

	public ThrowObjParams ThrowObjParams => throwObjParams;

	public StateChangeAreaData AreaData
	{
		get
		{
			return areaData;
		}
		set
		{
			areaData = value;
		}
	}

	public bool ApplyRotation
	{
		get
		{
			return applyRotation;
		}
		set
		{
			applyRotation = value;
		}
	}

	public ActionCommandEffect(GameObject prefab)
	{
		worldPosOffset = Vector3.zero;
		messages = new Boo.Lang.List<Message>();
		effect = prefab;
	}

	public void addMessage(string n, object param)
	{
		if (!string.IsNullOrEmpty(n))
		{
			Boo.Lang.List<Message> list = messages;
			Message message = new Message();
			string text = (message.name = n);
			object obj = (message.param = param);
			list.Add(message);
		}
	}

	public override bool doMain()
	{
		if (clone == null && effect != null)
		{
			emit();
		}
		return false;
	}

	public override void doUpdateAllTime()
	{
		if (clone != null && constraintMode != 0)
		{
			setCloneTransform(constraintMode);
		}
		if (!emitted)
		{
			return;
		}
		if (!killAtDispose)
		{
			lifeTime -= WorldDeltaTime;
			if (!(lifeTime > 0f))
			{
				kill();
			}
		}
		else if (Instance == null)
		{
			kill();
		}
	}

	public override void doDispose()
	{
		base.doDispose();
		if (killAtDispose)
		{
			kill();
		}
	}

	public void kill()
	{
		killed = true;
		if (clone != null)
		{
			if (deadEffect != null)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(deadEffect);
				gameObject.transform.position = clone.position;
				gameObject.transform.rotation = clone.rotation;
			}
			UnityEngine.Object.Destroy(clone.gameObject);
			clone = null;
		}
		if (deadCallback != null)
		{
			deadCallback();
		}
	}

	private void emit()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(effect, Vector3.zero, Quaternion.identity);
		if (!(gameObject != null))
		{
			return;
		}
		gameObject.SetActive(value: true);
		clone = gameObject.transform;
		emitted = true;
		setCloneTransform(emitMode);
		if (throwObjParams != null)
		{
			setupThrowObj();
		}
		if (areaData != null)
		{
			StateChangeArea stateChangeArea = ExtensionsModule.SetComponent<StateChangeArea>(gameObject);
			if (stateChangeArea != null)
			{
				stateChangeArea.AreaData = areaData;
			}
		}
		if (emitCallback != null)
		{
			emitCallback();
		}
		gameObject.SendMessage("emitEffectMessage", parent, SendMessageOptions.DontRequireReceiver);
		IEnumerator<Message> enumerator = messages.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Message current = enumerator.Current;
				gameObject.SendMessage(current.name, current.param, SendMessageOptions.DontRequireReceiver);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (parent != null)
		{
			parent.effectEmitHandler(gameObject);
		}
	}

	private void setCloneTransform(TransformMode mode)
	{
		Transform transform = sourceTransform();
		if (transform == null)
		{
			return;
		}
		if (dangle)
		{
			if (clone.parent != transform)
			{
				clone.parent = transform;
			}
			if (mode >= TransformMode.Pos)
			{
				clone.localPosition = offset;
			}
			if (mode == TransformMode.PosRot)
			{
				clone.localRotation = Quaternion.Euler(rotation);
			}
			return;
		}
		if (mode >= TransformMode.Pos)
		{
			clone.position = transform.position;
		}
		if (mode == TransformMode.PosRot)
		{
			clone.rotation = transform.rotation;
		}
		if (mode >= TransformMode.Pos)
		{
			Vector3 lossyScale = transform.lossyScale;
			Vector3 translation = new Vector3(offset.x * lossyScale.x, offset.y * lossyScale.y, offset.z * lossyScale.z);
			clone.Translate(translation);
		}
		if (mode == TransformMode.PosRot || applyRotation)
		{
			clone.Rotate(rotation);
		}
	}

	private Transform sourceTransform()
	{
		object result;
		if (source != null)
		{
			result = source;
		}
		else if (parent == null)
		{
			result = null;
		}
		else
		{
			Transform transform = ExtensionsModule.FindInActiveDescendants(parent.transform, boneName);
			if (transform == null)
			{
				source = parent.transform;
			}
			else
			{
				source = transform.transform;
			}
			result = source;
		}
		return (Transform)result;
	}

	public ThrowObjParams setThrowObjParam()
	{
		if (throwObjParams == null)
		{
			throwObjParams = new ThrowObjParams();
		}
		return throwObjParams;
	}

	public void setupThrowObj()
	{
		if (clone == null || throwObjParams == null)
		{
			return;
		}
		GameObject gameObject = clone.gameObject;
		ThrowObject throwObject = ExtensionsModule.SetComponent<ThrowObject>(gameObject);
		if (!(throwObject == null))
		{
			throwObject.init(throwObjParams);
			bool num = parent != null;
			if (num)
			{
				num = parent.TargetChar != null;
			}
			bool flag = num;
			if (throwObjParams.targetting && flag)
			{
				throwObject.target = parent.TargetChar.transform;
			}
			if (throwObjParams.adjustToLockOnY && flag)
			{
				Vector3 vector = parent.TargetChar.transform.position - gameObject.transform.position;
				float y = vector.y;
				Vector3 vector2 = vector;
				vector2.y = 0f;
				throwObject.worldSpeedY = y / (vector2.magnitude / Mathf.Abs(throwObject.speedZ));
			}
			throwObjectComponent = throwObject;
		}
	}
}
