using System;
using UnityEngine;

[Serializable]
public class GOEnabler : MonoBehaviour
{
	public GameObject[] enables;

	public GameObject[] disables;

	public void execEnabler()
	{
		checked
		{
			if (enables != null)
			{
				int i = 0;
				GameObject[] array = enables;
				for (int length = array.Length; i < length; i++)
				{
					if (array[i] != null)
					{
						array[i].SetActive(value: true);
					}
				}
			}
			if (disables == null)
			{
				return;
			}
			int j = 0;
			GameObject[] array2 = disables;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] != null)
				{
					array2[j].SetActive(value: true);
				}
			}
		}
	}
}
