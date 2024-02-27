using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetLife : MonoBehaviour
{
	public Ef_SetLifeObj[] setObjs;

	public float minusFadeDelay;

	public Ef_SetLife()
	{
		minusFadeDelay = 1f;
	}

	public void setTime(float inLife)
	{
		int length = setObjs.Length;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetLifeObj[] array = setObjs;
				GameObject gameObj = array[RuntimeServices.NormalizeArrayIndex(array, num)].gameObj;
				if ((bool)gameObj)
				{
					Ef_SetLifeObj[] array2 = setObjs;
					GameObject gameObj2 = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObj;
					Ef_SetLifeObj[] array3 = setObjs;
					Set(gameObj2, inLife - array3[RuntimeServices.NormalizeArrayIndex(array3, num)].minus);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (length == 0)
		{
			Set(gameObject, inLife);
		}
	}

	public void Set(GameObject gameObj, float life)
	{
		bool flag = false;
		ParticleSystem particleSystem = gameObj.particleSystem;
		if ((bool)particleSystem)
		{
			particleSystem.startLifetime = life;
			flag = true;
		}
		else
		{
			Ef_DeactiveTimer component = gameObj.GetComponent<Ef_DeactiveTimer>();
			if ((bool)component)
			{
				component.SetLife(life);
				flag = true;
			}
			else
			{
				Ef_DeactiveParticle component2 = gameObj.GetComponent<Ef_DeactiveParticle>();
				if ((bool)component2)
				{
					component2.SetLife(life);
					flag = true;
				}
				else
				{
					Ef_DeactiveTrail component3 = gameObj.GetComponent<Ef_DeactiveTrail>();
					if ((bool)component3)
					{
						component3.SetLife(life);
						flag = true;
					}
					else
					{
						Ef_DeactiveAlpha component4 = gameObj.GetComponent<Ef_DeactiveAlpha>();
						if ((bool)component4)
						{
							component4.SetLife(life);
							flag = true;
						}
						else
						{
							Ef_DeactiveScale component5 = gameObj.GetComponent<Ef_DeactiveScale>();
							if ((bool)component5)
							{
								component5.SetLife(life);
								flag = true;
							}
							else
							{
								Ef_DestroyTimer component6 = gameObj.GetComponent<Ef_DestroyTimer>();
								if ((bool)component6)
								{
									component6.life = life;
									flag = true;
								}
								else
								{
									Ef_DestroyParticle component7 = gameObj.GetComponent<Ef_DestroyParticle>();
									if ((bool)component7)
									{
										component7.life = life;
										component7.fadeDelay = life - minusFadeDelay;
										flag = true;
									}
									else
									{
										Ef_DestroyTrail component8 = gameObj.GetComponent<Ef_DestroyTrail>();
										if ((bool)component8)
										{
											component8.life = life;
											component8.fadeDelay = life - minusFadeDelay;
											flag = true;
										}
										else
										{
											Ef_DestroyAlpha component9 = gameObj.GetComponent<Ef_DestroyAlpha>();
											if ((bool)component9)
											{
												component9.life = life;
												component9.fadeDelay = life - minusFadeDelay;
												flag = true;
											}
											else
											{
												Ef_DestroyScale component10 = gameObj.GetComponent<Ef_DestroyScale>();
												if ((bool)component10)
												{
													component10.life = life;
													component10.fadeDelay = life - minusFadeDelay;
													flag = true;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		Ef_ColliderRadiusAnim ef_ColliderRadiusAnim = null;
		if ((bool)ef_ColliderRadiusAnim)
		{
			ef_ColliderRadiusAnim.life = life;
			flag = true;
		}
		else
		{
			Ef_ColliderSizeAnim component11 = gameObj.GetComponent<Ef_ColliderSizeAnim>();
			if ((bool)component11)
			{
				component11.life = life;
				flag = true;
			}
			else
			{
				Ef_SwordTrailV2 component12 = gameObj.GetComponent<Ef_SwordTrailV2>();
				if ((bool)component12)
				{
					component12.slashTime = life;
					flag = true;
				}
				else
				{
					Ef_SwordTrail component13 = gameObj.GetComponent<Ef_SwordTrail>();
					if ((bool)component13)
					{
						component13.slashTime = life;
						flag = true;
					}
					else
					{
						Ef_Laser component14 = gameObj.GetComponent<Ef_Laser>();
						if ((bool)component14)
						{
							component14.life = life;
							flag = true;
						}
						else
						{
							Ef_FlyingObject component15 = gameObj.GetComponent<Ef_FlyingObject>();
							if ((bool)component15)
							{
								component15.life = life;
								flag = true;
							}
							else
							{
								Ef_WeaponScale component16 = gameObj.GetComponent<Ef_WeaponScale>();
								if ((bool)component16)
								{
									component16.life = life;
									flag = true;
								}
								else
								{
									Ef_Twister component17 = gameObj.GetComponent<Ef_Twister>();
									if ((bool)component17)
									{
										component17.life = life;
										flag = true;
									}
								}
							}
						}
					}
				}
			}
		}
		if (!flag && gameObj != gameObject)
		{
			gameObj.SendMessage("setTime", life, SendMessageOptions.DontRequireReceiver);
		}
	}
}
