using System;
using UnityEngine;

[Serializable]
public class MasterTest : MonoBehaviour
{
	public void Start()
	{
		int i = 0;
		MWeapons[] all = MWeapons.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
			}
			int j = 0;
			MPoppets[] all2 = MPoppets.All;
			for (int length2 = all2.Length; j < length2; j++)
			{
			}
			int k = 0;
			MStyles[] all3 = MStyles.All;
			for (int length3 = all3.Length; k < length3; k++)
			{
			}
			int l = 0;
			MElements[] all4 = MElements.All;
			for (int length4 = all4.Length; l < length4; l++)
			{
			}
			int m = 0;
			MAreas[] all5 = MAreas.All;
			for (int length5 = all5.Length; m < length5; m++)
			{
			}
		}
	}
}
