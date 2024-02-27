using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class TargetRing : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002421474 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_002412821_002421475;

			internal Vector3 _0024_002412822_002421476;

			internal float _0024_002412823_002421477;

			internal Vector3 _0024_002412824_002421478;

			internal float _0024_002412825_002421479;

			internal Vector3 _0024_002412826_002421480;

			internal float _0024_002412827_002421481;

			internal Vector3 _0024_002412828_002421482;

			internal TargetRing _0024self__002421483;

			public _0024(TargetRing self_)
			{
				_0024self__002421483 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002421483.targetTransform)
					{
						float num = (_0024_002412821_002421475 = _0024self__002421483.targetTransform.position.x);
						Vector3 vector = (_0024_002412822_002421476 = _0024self__002421483.transform.position);
						float num2 = (_0024_002412822_002421476.x = _0024_002412821_002421475);
						Vector3 vector3 = (_0024self__002421483.transform.position = _0024_002412822_002421476);
						float num3 = (_0024_002412823_002421477 = _0024self__002421483.targetTransform.position.z);
						Vector3 vector4 = (_0024_002412824_002421478 = _0024self__002421483.transform.position);
						float num4 = (_0024_002412824_002421478.z = _0024_002412823_002421477);
						Vector3 vector6 = (_0024self__002421483.transform.position = _0024_002412824_002421478);
						if (!_0024self__002421483.hasGroundFollow)
						{
							float num5 = (_0024_002412825_002421479 = _0024self__002421483.targetTransform.position.y);
							Vector3 vector7 = (_0024_002412826_002421480 = _0024self__002421483.transform.position);
							float num6 = (_0024_002412826_002421480.y = _0024_002412825_002421479);
							Vector3 vector9 = (_0024self__002421483.transform.position = _0024_002412826_002421480);
							float num7 = (_0024_002412827_002421481 = 0.00125f);
							Vector3 vector10 = (_0024_002412828_002421482 = _0024self__002421483.transform.position);
							float num8 = (_0024_002412828_002421482.y = _0024_002412827_002421481);
							Vector3 vector12 = (_0024self__002421483.transform.position = _0024_002412828_002421482);
						}
					}
					else if (_0024self__002421483.uiSprite.enabled)
					{
						_0024self__002421483.uiSprite.enabled = false;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TargetRing _0024self__002421484;

		public _0024mainRoutine_002421474(TargetRing self_)
		{
			_0024self__002421484 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421484);
		}
	}

	private Renderer uiSprite;

	private Transform targetTransform;

	private bool hasGroundFollow;

	public GameObject CurrentTarget => (!(targetTransform == null)) ? targetTransform.gameObject : null;

	public bool HasTarget => targetTransform != null;

	public bool IsActivated
	{
		get
		{
			bool num = uiSprite != null;
			if (num)
			{
				num = uiSprite.enabled;
			}
			return num;
		}
	}

	public void Start()
	{
		setInit();
	}

	public void setInit()
	{
		uiSprite = GetComponentInChildren<Renderer>();
		if (!(uiSprite == null))
		{
			uiSprite.enabled = false;
			int num = 90;
			Vector3 eulerAngles = transform.eulerAngles;
			float num2 = (eulerAngles.x = num);
			Vector3 vector2 = (transform.eulerAngles = eulerAngles);
			StartCoroutine(mainRoutine());
			Ef_HeightFollow component = gameObject.GetComponent<Ef_HeightFollow>();
			if ((bool)component)
			{
				hasGroundFollow = true;
			}
			else
			{
				hasGroundFollow = false;
			}
		}
	}

	public void StartLockOn(GameObject target)
	{
		if (uiSprite == null)
		{
			return;
		}
		if (target == null)
		{
			EndLockOn();
		}
		else
		{
			if (target.transform == targetTransform)
			{
				return;
			}
			uiSprite.enabled = true;
			AIControl component = target.GetComponent<AIControl>();
			if (!(component == null))
			{
				RespMonster monsterData = component.MonsterData;
				setColor(monsterData);
				targetTransform = target.transform;
				uiSprite.transform.localScale = component.targetRingScale;
				float num = component.targetRingScale.x * 0.333f;
				iTween component2 = uiSprite.GetComponent<iTween>();
				if ((bool)component2)
				{
					UnityEngine.Object.Destroy(component2);
				}
				iTween.ScaleTo(uiSprite.gameObject, iTween.Hash("delay", 0.1f, "x", num, "y", num, "time", 2f));
			}
		}
	}

	public void setColor(RespMonster mdata)
	{
		if (mdata != null)
		{
			Color color = Color.white;
			if (mdata.Element != null)
			{
				color = mdata.Element.Color;
			}
			setColor(color);
		}
	}

	private void setColor(Color color)
	{
		if (!(uiSprite == null))
		{
			uiSprite.material.color = color;
			BlinkLine component = Camera.main.GetComponent<BlinkLine>();
			if (component != null)
			{
				component.startColor = uiSprite.material.color;
				component.endColor = uiSprite.material.color;
				component.endColor.a = 0.1f;
			}
		}
	}

	public void EndLockOn()
	{
		if (uiSprite != null)
		{
			uiSprite.enabled = false;
		}
		targetTransform = null;
	}

	public IEnumerator mainRoutine()
	{
		return new _0024mainRoutine_002421474(this).GetEnumerator();
	}
}
