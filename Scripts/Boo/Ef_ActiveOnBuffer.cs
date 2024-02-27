using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ActiveOnBuffer : MonoBehaviour
{
	[Serializable]
	public class CharacterEffect
	{
		public GameObject charObj;

		public EffectData[] effects;

		public int maxIndx;

		public void Init()
		{
			charObj = null;
			if (effects != null)
			{
				int num = 0;
				int length = effects.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int index = num;
					num++;
					EffectData[] array = effects;
					if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != null)
					{
						EffectData[] array2 = effects;
						if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)].instance != null)
						{
							EffectData[] array3 = effects;
							UnityEngine.Object.Destroy(array3[RuntimeServices.NormalizeArrayIndex(array3, index)].instance);
						}
					}
				}
			}
			effects = new EffectData[50];
			int num2 = 0;
			int num3 = 50;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index2 = num2;
				num2++;
				EffectData[] array4 = effects;
				if (array4[RuntimeServices.NormalizeArrayIndex(array4, index2)] == null)
				{
					EffectData[] array5 = effects;
					array5[RuntimeServices.NormalizeArrayIndex(array5, index2)] = new EffectData();
				}
				EffectData[] array6 = effects;
				array6[RuntimeServices.NormalizeArrayIndex(array6, index2)].Init();
			}
			maxIndx = 0;
		}
	}

	[Serializable]
	public class EffectData
	{
		public string name;

		public GameObject instance;

		public float emitTime;

		public void Init()
		{
			name = string.Empty;
			object obj = null;
			if (instance != null)
			{
				UnityEngine.Object.Destroy(instance);
			}
		}
	}

	[NonSerialized]
	private static Ef_ActiveOnBuffer current;

	[NonSerialized]
	private const int characterBufferSize = 3;

	[NonSerialized]
	private const int effBufferSize = 50;

	[NonSerialized]
	private const int emitNumBufferSize = 10;

	public bool ready;

	public bool destroyOnCharEffsEmpty;

	private float destroyCheckInterval;

	private float destroyCheckCount;

	public CharacterEffect[] charEffs;

	public int[] emitIndex;

	public float[] emitTimes;

	public static Ef_ActiveOnBuffer Current
	{
		get
		{
			if (current == null)
			{
				Ef_ActiveOnBuffer ef_ActiveOnBuffer = new GameObject("Ef_ActiveOnBuffer").AddComponent<Ef_ActiveOnBuffer>();
				ef_ActiveOnBuffer.Initialize();
				current = ef_ActiveOnBuffer;
			}
			return current;
		}
	}

	public Ef_ActiveOnBuffer()
	{
		destroyOnCharEffsEmpty = true;
		destroyCheckInterval = 1f;
		destroyCheckCount = 1f;
	}

	public void Initialize()
	{
		charEffs = new CharacterEffect[3];
		int num = 0;
		int num2 = 3;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			CharacterEffect[] array = charEffs;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] == null)
			{
				CharacterEffect[] array2 = charEffs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = new CharacterEffect();
			}
			CharacterEffect[] array3 = charEffs;
			array3[RuntimeServices.NormalizeArrayIndex(array3, index)].Init();
		}
		emitIndex = new int[10];
		emitTimes = new float[10];
		ready = true;
	}

	public GameObject Emit(string name, GameObject prefab, GameObject emitterObj, Vector3 pos, Quaternion rot, int maxNum, bool dontEmitExist)
	{
		GameObject gameObject = null;
		object result;
		if (!ready)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			result = null;
		}
		else if (emitterObj == null)
		{
			result = null;
		}
		else if (string.IsNullOrEmpty(name))
		{
			result = null;
		}
		else if (prefab == null)
		{
			result = null;
		}
		else
		{
			if (maxNum == 0)
			{
				maxNum = 1;
			}
			CharacterEffect characterEffect = null;
			EffectData[] array = null;
			EffectData effectData = null;
			Ef_ActiveOn ef_ActiveOn = null;
			int num = 0;
			int num2 = 3;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			int num3 = default(int);
			while (true)
			{
				if (num < num2)
				{
					int index = num;
					num++;
					CharacterEffect[] array2 = charEffs;
					characterEffect = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					if (characterEffect.charObj != emitterObj)
					{
						continue;
					}
					array = characterEffect.effects;
					num3 = -1;
					int num4 = 0;
					int num5 = 0;
					int num6 = 50;
					if (num6 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (true)
					{
						if (num5 < num6)
						{
							int num7 = num5;
							num5++;
							EffectData[] array3 = array;
							effectData = array3[RuntimeServices.NormalizeArrayIndex(array3, num7)];
							if (num7 >= characterEffect.maxIndx)
							{
								num3 = num7;
							}
							else
							{
								if (!string.IsNullOrEmpty(effectData.name))
								{
									if (!(effectData.name == name))
									{
										continue;
									}
									gameObject = effectData.instance;
									if (gameObject != null)
									{
										if (maxNum > 1)
										{
											if (num4 < maxNum)
											{
												float[] array4 = emitTimes;
												array4[RuntimeServices.NormalizeArrayIndex(array4, num4)] = effectData.emitTime;
												int[] array5 = emitIndex;
												array5[RuntimeServices.NormalizeArrayIndex(array5, num4)] = num7;
												num4 = checked(num4 + 1);
											}
											if (num4 < maxNum)
											{
												continue;
											}
											goto IL_019e;
										}
										goto IL_0252;
									}
									goto IL_02dd;
								}
								num3 = num7;
							}
						}
						if (num3 == -1)
						{
							break;
						}
						goto IL_0348;
					}
					continue;
				}
				int num8 = 0;
				int num9 = 3;
				if (num9 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (true)
				{
					if (num8 < num9)
					{
						int index2 = num8;
						num8++;
						CharacterEffect[] array6 = charEffs;
						characterEffect = array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
						CharacterEffect[] array7 = charEffs;
						if (array7[RuntimeServices.NormalizeArrayIndex(array7, index2)].charObj == null)
						{
							CharacterEffect[] array8 = charEffs;
							characterEffect = array8[RuntimeServices.NormalizeArrayIndex(array8, index2)];
							characterEffect.Init();
							characterEffect.charObj = emitterObj;
							characterEffect.maxIndx = checked(num3 + 1);
							array = characterEffect.effects;
							effectData = array[0];
							effectData.name = name;
							gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab, pos, rot);
							ef_ActiveOn = gameObject.GetComponent<Ef_ActiveOn>();
							if ((bool)ef_ActiveOn)
							{
								ef_ActiveOn.ActiveOn();
							}
							else
							{
								gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
							}
							effectData.instance = gameObject;
							effectData.emitTime = Time.time;
							result = gameObject;
							break;
						}
						continue;
					}
					result = null;
					break;
				}
				break;
				IL_0252:
				ef_ActiveOn = gameObject.GetComponent<Ef_ActiveOn>();
				if ((bool)ef_ActiveOn)
				{
					gameObject.transform.position = pos;
					gameObject.transform.rotation = rot;
					ef_ActiveOn.ActiveOn();
					effectData.emitTime = Time.time;
					result = gameObject;
				}
				else
				{
					gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab, pos, rot);
					gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
					effectData.instance = gameObject;
					effectData.emitTime = Time.time;
					result = gameObject;
				}
				break;
				IL_019e:
				if (!dontEmitExist)
				{
					int num10 = -1;
					float num11 = 3.4028236E+36f;
					int num12 = 0;
					int num13 = maxNum;
					if (num13 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num12 < num13)
					{
						int index3 = num12;
						num12++;
						float[] array9 = emitTimes;
						if (!(array9[RuntimeServices.NormalizeArrayIndex(array9, index3)] >= num11))
						{
							float[] array10 = emitTimes;
							num11 = array10[RuntimeServices.NormalizeArrayIndex(array10, index3)];
							int[] array11 = emitIndex;
							num10 = array11[RuntimeServices.NormalizeArrayIndex(array11, index3)];
						}
					}
					if (num10 != -1)
					{
						EffectData[] array12 = array;
						effectData = array12[RuntimeServices.NormalizeArrayIndex(array12, num10)];
						gameObject = effectData.instance;
						goto IL_0252;
					}
				}
				result = null;
				break;
				IL_0348:
				characterEffect.maxIndx = checked(num3 + 1);
				EffectData[] array13 = array;
				effectData = array13[RuntimeServices.NormalizeArrayIndex(array13, num3)];
				effectData.name = name;
				gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab, pos, rot);
				ef_ActiveOn = gameObject.GetComponent<Ef_ActiveOn>();
				if ((bool)ef_ActiveOn)
				{
					ef_ActiveOn.ActiveOn();
				}
				else
				{
					gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
				}
				effectData.instance = gameObject;
				effectData.emitTime = Time.time;
				result = gameObject;
				break;
				IL_02dd:
				gameObject = (GameObject)UnityEngine.Object.Instantiate(prefab, pos, rot);
				ef_ActiveOn = gameObject.GetComponent<Ef_ActiveOn>();
				if ((bool)ef_ActiveOn)
				{
					ef_ActiveOn.ActiveOn();
				}
				else
				{
					gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
				}
				effectData.instance = gameObject;
				effectData.emitTime = Time.time;
				result = gameObject;
				break;
			}
		}
		return (GameObject)result;
	}

	public void Update()
	{
		if (!destroyOnCharEffsEmpty)
		{
			return;
		}
		destroyCheckCount -= Time.deltaTime;
		if (destroyCheckCount > 0f)
		{
			return;
		}
		destroyCheckCount = destroyCheckInterval;
		bool flag = false;
		if (charEffs != null)
		{
			int num = 0;
			int num2 = 3;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				CharacterEffect[] array = charEffs;
				CharacterEffect characterEffect = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				if (characterEffect.charObj == null)
				{
					EffectData[] effects = characterEffect.effects;
					if (effects == null)
					{
						continue;
					}
					int num3 = 0;
					int maxIndx = characterEffect.maxIndx;
					if (maxIndx < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num3 < maxIndx)
					{
						int index2 = num3;
						num3++;
						if (effects[RuntimeServices.NormalizeArrayIndex(effects, index2)] != null)
						{
							if (effects[RuntimeServices.NormalizeArrayIndex(effects, index2)].instance != null)
							{
								UnityEngine.Object.Destroy(effects[RuntimeServices.NormalizeArrayIndex(effects, index2)].instance);
							}
						}
					}
				}
				else
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void OnDestroy()
	{
		if (charEffs == null)
		{
			return;
		}
		int num = 0;
		int num2 = 3;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			CharacterEffect[] array = charEffs;
			CharacterEffect characterEffect = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (!(characterEffect.charObj == null))
			{
				continue;
			}
			EffectData[] effects = characterEffect.effects;
			if (effects == null)
			{
				continue;
			}
			int num3 = 0;
			int num4 = 50;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				if (effects[RuntimeServices.NormalizeArrayIndex(effects, index2)] != null)
				{
					if (effects[RuntimeServices.NormalizeArrayIndex(effects, index)].instance != null)
					{
						UnityEngine.Object.Destroy(effects[RuntimeServices.NormalizeArrayIndex(effects, index)].instance);
					}
				}
			}
		}
	}
}
