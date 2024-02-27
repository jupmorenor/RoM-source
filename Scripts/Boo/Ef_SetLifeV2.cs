using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_SetLifeV2 : MonoBehaviour
{
	[Serializable]
	public class SetLifeObj
	{
		public GameObject gameObj;

		public ComponentType componentType;

		public float minus;
	}

	[Serializable]
	public enum ComponentType
	{
		ParticleSystem_Lifetime,
		ParticleSystem_Delay,
		Ef_ParticleDuration,
		Ef_ParticleDuration_Delay,
		Ef_ParticleEmit_Delay,
		Ef_ParticleEmit_Life,
		Ef_DeactiveTimer,
		Ef_DeactiveParticle,
		Ef_DeactiveTrail,
		Ef_DeactiveAlpha,
		Ef_DeactiveScale,
		Ef_DestroyTimer,
		Ef_DestroyParticle,
		Ef_DestroyTrail,
		Ef_DestroyAlpha,
		Ef_DestroyScale,
		Ef_QuickAnimColor,
		Ef_QuickAnimMatFloat,
		Ef_QuickAnimTexture,
		Ef_QuickAnimTransCurve,
		Ef_QuickAnimTransform,
		Ef_SwordTrail,
		Ef_Laser,
		Ef_FlyingObject,
		Ef_WeaponScale,
		Ef_Twister,
		Ef_MoveByAnimCurve,
		Ef_MoveParabolic,
		Ef_ColliderRadiusAnim,
		Ef_ColliderSizeAnim,
		Ef_EmitTime_Delay,
		Ef_EmitActiveOnTime_Delay,
		Ef_EmitActiveOnDistance_Delay,
		StateChangeArea,
		SendLife
	}

	public SetLifeObj[] setLifeObjs;

	public bool checkComponent;

	public void Update()
	{
		if (checkComponent)
		{
			CheckComponentType();
			checkComponent = false;
		}
	}

	public void CheckComponentType()
	{
		int num = setLifeObjs.Length;
		if (num == 0)
		{
			setLifeObjs = new SetLifeObj[1];
			setLifeObjs[0].gameObj = gameObject;
			setLifeObjs[0].minus = 0f;
			num = 1;
		}
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
			SetLifeObj[] array = setLifeObjs;
			SetLifeObj setLifeObj = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			GameObject gameObj = setLifeObj.gameObj;
			if (!(gameObj == null))
			{
				if (gameObj.GetComponent<Ef_ParticleDuration>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_ParticleDuration;
				}
				else if (gameObj.particleSystem != null)
				{
					setLifeObj.componentType = ComponentType.ParticleSystem_Lifetime;
				}
				else if (gameObj.GetComponent<Ef_ParticleEmit>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_ParticleEmit_Delay;
				}
				else if (gameObj.GetComponent<Ef_DeactiveTimer>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DeactiveTimer;
				}
				else if (gameObj.GetComponent<Ef_DeactiveParticle>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DeactiveParticle;
				}
				else if (gameObj.GetComponent<Ef_DeactiveTrail>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DeactiveTrail;
				}
				else if (gameObj.GetComponent<Ef_DeactiveAlpha>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DeactiveAlpha;
				}
				else if (gameObj.GetComponent<Ef_DeactiveScale>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DeactiveScale;
				}
				else if (gameObj.GetComponent<Ef_DestroyTimer>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DestroyTimer;
				}
				else if (gameObj.GetComponent<Ef_DestroyParticle>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DestroyParticle;
				}
				else if (gameObj.GetComponent<Ef_DestroyTrail>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DestroyTrail;
				}
				else if (gameObj.GetComponent<Ef_DestroyAlpha>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DestroyAlpha;
				}
				else if (gameObj.GetComponent<Ef_DestroyScale>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_DestroyScale;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimColor>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_QuickAnimColor;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimMatFloat>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_QuickAnimMatFloat;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimTransCurve>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_QuickAnimTransCurve;
				}
				else if (gameObj.GetComponent<Ef_QuickAnimTransform>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_QuickAnimTransform;
				}
				else if (gameObj.GetComponent<Ef_SwordTrailV2>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_SwordTrail>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_SwordTrail;
				}
				else if (gameObj.GetComponent<Ef_LaserV2>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_Laser;
				}
				else if (gameObj.GetComponent<Ef_Laser>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_Laser;
				}
				else if (gameObj.GetComponent<Ef_FlyingObject>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_FlyingObject;
				}
				else if (gameObj.GetComponent<Ef_WeaponScale>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_WeaponScale;
				}
				else if (gameObj.GetComponent<Ef_Twister>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_Twister;
				}
				else if (gameObj.GetComponent<Ef_MoveParabolicV2>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_MoveParabolic;
				}
				else if (gameObj.GetComponent<Ef_MoveParabolic>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_MoveParabolic;
				}
				else if (gameObj.GetComponent<Ef_ColliderRadiusAnim>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_ColliderRadiusAnim;
				}
				else if (gameObj.GetComponent<Ef_ColliderSizeAnim>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_ColliderSizeAnim;
				}
				else if (gameObj.GetComponent<Ef_EmitTime>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_EmitTime_Delay;
				}
				else if (gameObj.GetComponent<Ef_EmitActiveOnTime>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_EmitActiveOnTime_Delay;
				}
				else if (gameObj.GetComponent<Ef_EmitActiveOnDistance>() != null)
				{
					setLifeObj.componentType = ComponentType.Ef_EmitActiveOnDistance_Delay;
				}
				else if (gameObj.GetComponent<StateChangeArea>() != null)
				{
					setLifeObj.componentType = ComponentType.StateChangeArea;
				}
				else if (gameObj != gameObject)
				{
					setLifeObj.componentType = ComponentType.SendLife;
				}
			}
		}
	}

	public void setTime(float inLife)
	{
		int length = setLifeObjs.Length;
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
			SetLifeObj[] array = setLifeObjs;
			GameObject gameObj = array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObj;
			if (gameObj == null)
			{
				continue;
			}
			SetLifeObj[] array2 = setLifeObjs;
			float num3 = inLife - array2[RuntimeServices.NormalizeArrayIndex(array2, index)].minus;
			if (!(num3 >= 0f))
			{
				num3 = 0f;
			}
			SetLifeObj[] array3 = setLifeObjs;
			ComponentType componentType = array3[RuntimeServices.NormalizeArrayIndex(array3, index)].componentType;
			if (componentType == ComponentType.Ef_ParticleDuration)
			{
				Ef_ParticleDuration component = gameObj.GetComponent<Ef_ParticleDuration>();
				if (component != null)
				{
					num3 -= component.delay;
					if (!(num3 >= 0f))
					{
						num3 = 0f;
					}
					component.duration = num3;
				}
			}
			switch (componentType)
			{
			case ComponentType.Ef_ParticleDuration_Delay:
			{
				Ef_ParticleDuration component11 = gameObj.GetComponent<Ef_ParticleDuration>();
				if (component11 != null)
				{
					if (!(num3 >= 0f))
					{
						num3 = 0f;
					}
					component11.delay = num3;
				}
				break;
			}
			case ComponentType.ParticleSystem_Lifetime:
			{
				ParticleSystem particleSystem = gameObj.particleSystem;
				if (particleSystem != null)
				{
					num3 -= particleSystem.startDelay;
					if (!(num3 >= 0f))
					{
						num3 = 0f;
					}
					particleSystem.startLifetime = num3;
				}
				break;
			}
			case ComponentType.ParticleSystem_Delay:
			{
				ParticleSystem particleSystem2 = gameObj.particleSystem;
				if (particleSystem2 != null)
				{
					particleSystem2.startDelay = num3;
				}
				break;
			}
			case ComponentType.Ef_ParticleEmit_Delay:
			{
				Ef_ParticleEmit component26 = gameObj.GetComponent<Ef_ParticleEmit>();
				if (component26 != null)
				{
					component26.delay = num3;
				}
				break;
			}
			case ComponentType.Ef_ParticleEmit_Life:
			{
				Ef_ParticleEmit component3 = gameObj.GetComponent<Ef_ParticleEmit>();
				if (component3 != null)
				{
					num3 -= component3.delay;
					if (!(num3 >= 0f))
					{
						num3 = 0f;
					}
					float lifeTime = component3.lifeTime;
					float lifeTime2 = component3.lifeTime2;
					if (!(lifeTime <= lifeTime2))
					{
						component3.lifeTime = num3;
						component3.lifeTime2 = lifeTime2 / lifeTime * num3;
					}
					else
					{
						component3.lifeTime = lifeTime / lifeTime2 * num3;
						component3.lifeTime2 = num3;
					}
				}
				break;
			}
			case ComponentType.Ef_DeactiveTimer:
			{
				Ef_DeactiveTimer component28 = gameObj.GetComponent<Ef_DeactiveTimer>();
				if (component28 != null)
				{
					component28.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DeactiveParticle:
			{
				Ef_DeactiveParticle component21 = gameObj.GetComponent<Ef_DeactiveParticle>();
				if (component21 != null)
				{
					component21.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DeactiveTrail:
			{
				Ef_DeactiveTrail component16 = gameObj.GetComponent<Ef_DeactiveTrail>();
				if (component16 != null)
				{
					component16.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DeactiveAlpha:
			{
				Ef_DeactiveAlpha component7 = gameObj.GetComponent<Ef_DeactiveAlpha>();
				if (component7 != null)
				{
					component7.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DeactiveScale:
			{
				Ef_DeactiveScale component32 = gameObj.GetComponent<Ef_DeactiveScale>();
				if (component32 != null)
				{
					component32.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DestroyTimer:
			{
				Ef_DestroyTimer component31 = gameObj.GetComponent<Ef_DestroyTimer>();
				if (component31 != null)
				{
					component31.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DestroyParticle:
			{
				Ef_DestroyParticle component27 = gameObj.GetComponent<Ef_DestroyParticle>();
				if (component27 != null)
				{
					component27.fadeDelay = num3 - component27.life + component27.fadeDelay;
					component27.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DestroyTrail:
			{
				Ef_DestroyTrail component23 = gameObj.GetComponent<Ef_DestroyTrail>();
				if (component23 != null)
				{
					component23.fadeDelay = num3 - component23.life + component23.fadeDelay;
					component23.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DestroyAlpha:
			{
				Ef_DestroyAlpha component19 = gameObj.GetComponent<Ef_DestroyAlpha>();
				if (component19 != null)
				{
					component19.fadeDelay = num3 - component19.life + component19.fadeDelay;
					component19.life = num3;
				}
				break;
			}
			case ComponentType.Ef_DestroyScale:
			{
				Ef_DestroyScale component17 = gameObj.GetComponent<Ef_DestroyScale>();
				if (component17 != null)
				{
					component17.fadeDelay = num3 - component17.life + component17.fadeDelay;
					component17.life = num3;
				}
				break;
			}
			case ComponentType.Ef_QuickAnimColor:
			{
				Ef_QuickAnimColor component13 = gameObj.GetComponent<Ef_QuickAnimColor>();
				if (component13 != null)
				{
					component13.life = num3 - component13.delay;
				}
				break;
			}
			case ComponentType.Ef_QuickAnimMatFloat:
			{
				Ef_QuickAnimMatFloat component9 = gameObj.GetComponent<Ef_QuickAnimMatFloat>();
				if (component9 != null)
				{
					component9.life = num3 - component9.delay;
				}
				break;
			}
			case ComponentType.Ef_QuickAnimTransform:
			{
				Ef_QuickAnimTransform component5 = gameObj.GetComponent<Ef_QuickAnimTransform>();
				if (component5 != null)
				{
					component5.life = num3 - component5.delay;
				}
				break;
			}
			case ComponentType.Ef_QuickAnimTransCurve:
			{
				Ef_QuickAnimTransCurve component33 = gameObj.GetComponent<Ef_QuickAnimTransCurve>();
				if (component33 != null)
				{
					component33.SetLife(num3);
				}
				break;
			}
			case ComponentType.Ef_SwordTrail:
			{
				Ef_SwordTrailV2 component29 = gameObj.GetComponent<Ef_SwordTrailV2>();
				if (component29 != null)
				{
					component29.slashTime = num3;
					break;
				}
				Ef_SwordTrail component30 = gameObj.GetComponent<Ef_SwordTrail>();
				if (component30 != null)
				{
					component30.slashTime = num3;
				}
				break;
			}
			case ComponentType.Ef_Laser:
			{
				Ef_LaserV2 component24 = gameObj.GetComponent<Ef_LaserV2>();
				if (component24 != null)
				{
					component24.life = num3;
					break;
				}
				Ef_Laser component25 = gameObj.GetComponent<Ef_Laser>();
				if (component25 != null)
				{
					component25.life = num3;
				}
				break;
			}
			case ComponentType.Ef_FlyingObject:
			{
				Ef_FlyingObject component22 = gameObj.GetComponent<Ef_FlyingObject>();
				if (component22 != null)
				{
					component22.life = num3;
				}
				break;
			}
			case ComponentType.Ef_WeaponScale:
			{
				Ef_WeaponScale component20 = gameObj.GetComponent<Ef_WeaponScale>();
				if (component20 != null)
				{
					component20.life = num3 - component20.delay;
				}
				break;
			}
			case ComponentType.Ef_Twister:
			{
				Ef_Twister component18 = gameObj.GetComponent<Ef_Twister>();
				if (component18 != null)
				{
					component18.life = num3;
				}
				break;
			}
			case ComponentType.Ef_MoveParabolic:
			{
				Ef_MoveParabolicV2 component14 = gameObj.GetComponent<Ef_MoveParabolicV2>();
				if (component14 != null)
				{
					component14.life = num3;
					break;
				}
				Ef_MoveParabolic component15 = gameObj.GetComponent<Ef_MoveParabolic>();
				if (component15 != null)
				{
					component15.life = num3;
				}
				break;
			}
			case ComponentType.Ef_ColliderRadiusAnim:
			{
				Ef_ColliderRadiusAnim component12 = gameObj.GetComponent<Ef_ColliderRadiusAnim>();
				if (component12 != null)
				{
					component12.life = num3 - component12.delay;
				}
				break;
			}
			case ComponentType.Ef_ColliderSizeAnim:
			{
				Ef_ColliderSizeAnim component10 = gameObj.GetComponent<Ef_ColliderSizeAnim>();
				if (component10 != null)
				{
					component10.life = num3 - component10.delay;
				}
				break;
			}
			case ComponentType.Ef_EmitTime_Delay:
			{
				Ef_EmitTime component8 = gameObj.GetComponent<Ef_EmitTime>();
				if (component8 != null)
				{
					component8.delay = num3;
				}
				break;
			}
			case ComponentType.Ef_EmitActiveOnTime_Delay:
			{
				Ef_EmitActiveOnTime component6 = gameObj.GetComponent<Ef_EmitActiveOnTime>();
				if (component6 != null)
				{
					component6.delay = num3;
				}
				break;
			}
			case ComponentType.Ef_EmitActiveOnDistance_Delay:
			{
				Ef_EmitActiveOnDistance component4 = gameObj.GetComponent<Ef_EmitActiveOnDistance>();
				if (component4 != null)
				{
					component4.delay = num3;
				}
				break;
			}
			case ComponentType.StateChangeArea:
			{
				StateChangeArea component2 = gameObj.GetComponent<StateChangeArea>();
				if (component2 != null)
				{
					component2.leftExistTime = num3;
				}
				break;
			}
			case ComponentType.SendLife:
				gameObj.SendMessage("setTime", inLife, SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
	}
}
