using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_ParticleScaleFromEmitterNo : MonoBehaviour
{
	public int emitterNo;

	public GameObject[] particleObjs;

	public Ef_ParticleScaleFromEmitterNoScale[] scaleDatas;

	public bool sort;

	public void Update()
	{
		if (sort)
		{
			Sort();
			sort = false;
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			emitterNo = StringToInt(emtr.gameObject.name.Substring(1, 4));
			SetParticleScale(GetScale(emitterNo));
		}
	}

	public int StringToInt(string str)
	{
		int num = 0;
		int num2 = 1;
		checked
		{
			int num3 = str.Length - 1;
			int num4 = 1;
			if (0 < num3)
			{
				num4 = -1;
			}
			while (num3 != 0)
			{
				int startIndex = num3;
				num3 = unchecked(num3 + num4);
				switch (str.Substring(startIndex, 1))
				{
				case "1":
					num += 1 * num2;
					break;
				case "2":
					num += 1 * num2;
					break;
				case "3":
					num += 1 * num2;
					break;
				case "4":
					num += 1 * num2;
					break;
				case "5":
					num += 1 * num2;
					break;
				case "6":
					num += 1 * num2;
					break;
				case "7":
					num += 1 * num2;
					break;
				case "8":
					num += 1 * num2;
					break;
				case "9":
					num += 1 * num2;
					break;
				}
				num2 *= 10;
			}
			return num;
		}
	}

	public float GetScale(int emtrNo)
	{
		int length = scaleDatas.Length;
		float result;
		if (length == 0)
		{
			result = 1f;
		}
		else
		{
			int num = length;
			int num2 = 0;
			int num3 = 0;
			Ef_ParticleScaleFromEmitterNoScale[] array = scaleDatas;
			if (emtrNo > array[RuntimeServices.NormalizeArrayIndex(array, length / 2)].charNo)
			{
				Ef_ParticleScaleFromEmitterNoScale[] array2 = scaleDatas;
				num3 = ((emtrNo < array2[RuntimeServices.NormalizeArrayIndex(array2, checked(length * 3) / 4)].charNo) ? (length / 2) : (checked(length * 3) / 4));
			}
			else
			{
				Ef_ParticleScaleFromEmitterNoScale[] array3 = scaleDatas;
				if (emtrNo >= array3[RuntimeServices.NormalizeArrayIndex(array3, length / 4)].charNo)
				{
					num3 = length / 4;
				}
			}
			Ef_ParticleScaleFromEmitterNoScale[] array4 = scaleDatas;
			float num4 = array4[RuntimeServices.NormalizeArrayIndex(array4, checked(length - 1))].charNo;
			int num5 = num3;
			int num6 = length;
			int num7 = 1;
			if (num6 < num5)
			{
				num7 = -1;
			}
			while (num5 != num6)
			{
				int num8 = num5;
				num5 += num7;
				Ef_ParticleScaleFromEmitterNoScale[] array5 = scaleDatas;
				if (emtrNo == array5[RuntimeServices.NormalizeArrayIndex(array5, num8)].charNo)
				{
					Ef_ParticleScaleFromEmitterNoScale[] array6 = scaleDatas;
					num4 = array6[RuntimeServices.NormalizeArrayIndex(array6, num8)].particleScale;
					break;
				}
				Ef_ParticleScaleFromEmitterNoScale[] array7 = scaleDatas;
				if (emtrNo < array7[RuntimeServices.NormalizeArrayIndex(array7, num8)].charNo)
				{
					if (num8 > 0)
					{
						Ef_ParticleScaleFromEmitterNoScale[] array8 = scaleDatas;
						num4 = array8[RuntimeServices.NormalizeArrayIndex(array8, checked(num8 - 1))].particleScale;
					}
					else
					{
						Ef_ParticleScaleFromEmitterNoScale[] array9 = scaleDatas;
						num4 = array9[RuntimeServices.NormalizeArrayIndex(array9, num8)].particleScale;
					}
					break;
				}
			}
			result = num4;
		}
		return result;
	}

	public void SetParticleScale(float scale)
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(particleObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = particleObjs;
				ParticleSystem particleSystem = array[RuntimeServices.NormalizeArrayIndex(array, num)].particleSystem;
				GameObject[] array2 = particleObjs;
				Component component = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].GetComponent("WindZone");
				if ((bool)particleSystem)
				{
					particleSystem.startSize *= scale;
					particleSystem.startSpeed *= scale;
					particleSystem.transform.localPosition = particleSystem.transform.localPosition * scale;
					particleSystem.transform.localScale = particleSystem.transform.localScale * scale;
				}
				if ((bool)component)
				{
					component.transform.localPosition = component.transform.localPosition * scale;
					component.SendMessage("WindZoneScale", scale, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Sort()
	{
		int length = scaleDatas.Length;
		int[] array = new int[length];
		bool[] array2 = new bool[length];
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = false;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				int num3 = 9999;
				IEnumerator<int> enumerator3 = Builtins.range(length).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						num2 = enumerator3.Current;
						Ef_ParticleScaleFromEmitterNoScale[] array3 = scaleDatas;
						if (array3[RuntimeServices.NormalizeArrayIndex(array3, num2)].charNo < num3)
						{
							if (!array2[RuntimeServices.NormalizeArrayIndex(array2, num2)])
							{
								array[RuntimeServices.NormalizeArrayIndex(array, num)] = num2;
								Ef_ParticleScaleFromEmitterNoScale[] array4 = scaleDatas;
								num3 = array4[RuntimeServices.NormalizeArrayIndex(array4, num2)].charNo;
							}
						}
					}
				}
				finally
				{
					enumerator3.Dispose();
				}
				array2[RuntimeServices.NormalizeArrayIndex(array2, array[RuntimeServices.NormalizeArrayIndex(array, num)])] = true;
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		Ef_ParticleScaleFromEmitterNoScale[] array5 = new Ef_ParticleScaleFromEmitterNoScale[length];
		IEnumerator<int> enumerator4 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				num = enumerator4.Current;
				int num4 = RuntimeServices.NormalizeArrayIndex(array5, num);
				Ef_ParticleScaleFromEmitterNoScale[] array6 = scaleDatas;
				array5[num4] = array6[RuntimeServices.NormalizeArrayIndex(array6, array[RuntimeServices.NormalizeArrayIndex(array, num)])];
			}
		}
		finally
		{
			enumerator4.Dispose();
		}
		IEnumerator<int> enumerator5 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator5.MoveNext())
			{
				num = enumerator5.Current;
				Ef_ParticleScaleFromEmitterNoScale[] array7 = scaleDatas;
				array7[RuntimeServices.NormalizeArrayIndex(array7, num)] = array5[RuntimeServices.NormalizeArrayIndex(array5, num)];
			}
		}
		finally
		{
			enumerator5.Dispose();
		}
	}
}
