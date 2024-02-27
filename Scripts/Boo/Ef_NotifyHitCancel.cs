using System;
using UnityEngine;

[Serializable]
public class Ef_NotifyHitCancel : MonoBehaviour
{
	public Ef_NotifyHitCancelState[] states;

	public void notifyHitCancel(int durability)
	{
		int i = 0;
		Ef_NotifyHitCancelState[] array = states;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == null || array[i].durability != durability)
				{
					continue;
				}
				Ef_NotifyHitCancelObj[] objects = array[i].objects;
				int j = 0;
				Ef_NotifyHitCancelObj[] array2 = objects;
				for (int length2 = array2.Length; j < length2; j++)
				{
					if (array2[j] == null)
					{
						continue;
					}
					GameObject gameObj = array2[j].gameObj;
					if (gameObj == null)
					{
						continue;
					}
					if (array2[j].destroy)
					{
						UnityEngine.Object.Destroy(gameObj);
						continue;
					}
					if (array2[j].setColor)
					{
						gameObj.SendMessage("setColor", array2[j].color, SendMessageOptions.DontRequireReceiver);
					}
					if (array2[j].setScale)
					{
						gameObj.transform.localScale = new Vector3(array2[j].scale, array2[j].scale, array2[j].scale);
					}
					if (array2[j].particle && (bool)gameObj.particleSystem)
					{
						gameObj.particleSystem.Play();
					}
					if (!array2[j].quickAnim)
					{
						continue;
					}
					Ef_QuickAnimTransform component = gameObj.GetComponent<Ef_QuickAnimTransform>();
					if ((bool)component)
					{
						component.Play();
						continue;
					}
					Ef_QuickAnimColor component2 = gameObj.GetComponent<Ef_QuickAnimColor>();
					if ((bool)component2)
					{
						component2.Play();
						continue;
					}
					Ef_QuickAnimMatFloat component3 = gameObj.GetComponent<Ef_QuickAnimMatFloat>();
					if ((bool)component3)
					{
						component3.Play();
						continue;
					}
					Ef_QuickAnimTexture component4 = gameObj.GetComponent<Ef_QuickAnimTexture>();
					if ((bool)component4)
					{
						component4.Play();
					}
				}
			}
		}
	}
}
