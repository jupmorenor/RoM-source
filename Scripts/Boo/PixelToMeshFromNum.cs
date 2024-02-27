using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class PixelToMeshFromNum : MonoBehaviour
{
	public int number;

	public PixelToMeshBoo[] meshObjs;

	public int offsetCharNo;

	public bool left;

	private int oldNum;

	public PixelToMeshFromNum()
	{
		left = true;
		oldNum = -1;
	}

	public void Start()
	{
		SetCharNo(number);
	}

	public void Update()
	{
		if (number != oldNum)
		{
			SetCharNo(number);
			oldNum = number;
		}
	}

	public void SetCharNo(int num)
	{
		int length = meshObjs.Length;
		int num2 = default(int);
		int num3 = default(int);
		if (left)
		{
			int num4 = 1;
			IEnumerator<int> enumerator2;
			checked
			{
				IEnumerator<int> enumerator = Builtins.range(length - 1).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num2 = enumerator.Current;
						num4 *= 10;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				enumerator2 = Builtins.range(length).GetEnumerator();
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					num2 = enumerator2.Current;
					if (num < num4)
					{
						PixelToMeshBoo[] array = meshObjs;
						array[RuntimeServices.NormalizeArrayIndex(array, num2)].charNo = -1;
					}
					else
					{
						num3 = num % 10;
						PixelToMeshBoo[] array2 = meshObjs;
						array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].charNo = checked(num3 + offsetCharNo);
						num /= 10;
					}
					num4 /= 10;
					PixelToMeshBoo[] array3 = meshObjs;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num2)].update = true;
				}
				return;
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		IEnumerator<int> enumerator3 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				num2 = enumerator3.Current;
				num3 = num % 10;
				if (num2 == 0 || num > 0)
				{
					PixelToMeshBoo[] array4 = meshObjs;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num2)].charNo = checked(num3 + offsetCharNo);
				}
				else
				{
					PixelToMeshBoo[] array5 = meshObjs;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num2)].charNo = -1;
				}
				PixelToMeshBoo[] array6 = meshObjs;
				array6[RuntimeServices.NormalizeArrayIndex(array6, num2)].update = true;
				num /= 10;
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
	}
}
