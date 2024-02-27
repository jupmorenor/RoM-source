using System;
using UnityEngine;

[Serializable]
public class Ef_DestroyFindExists : MonoBehaviour
{
	public GameObject findObj;

	public void Start()
	{
		if (!findObj)
		{
			findObj = this.gameObject;
		}
		GameObject gameObject = null;
		gameObject = GameObject.Find(findObj.name);
		if (!gameObject)
		{
			gameObject = GameObject.Find(findObj.name + "(Clone)");
		}
		if ((bool)gameObject && gameObject != this.gameObject)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}
}
