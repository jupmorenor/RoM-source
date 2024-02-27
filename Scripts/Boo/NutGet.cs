using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class NutGet : DropBase
{
	[NonSerialized]
	public static Color NUT_GET_COLOR = new Color(0.11764706f, 0.5882353f, 1f);

	protected override void doPickMeUp(PlayerControl pc)
	{
		int[] array = pc.addMagicPointRate(0.2f);
		int num = 0;
		while (num < 2)
		{
			int index = num;
			num++;
			AIControl poppet = pc.getPoppet(index);
			if ((bool)poppet)
			{
				DamageDisplay.NutGet(poppet.transform.root.position, array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			}
		}
	}

	public void Update()
	{
		float y = transform.eulerAngles.y + Time.deltaTime * 30f;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector2 = (transform.eulerAngles = eulerAngles);
	}
}
