using UnityEngine;

[ExecuteInEditMode]
public class Billboard_Scale : MonoBehaviour
{
	private void Start()
	{
		base.transform.localScale *= Random.Range(0.99f, 1.01f);
	}
}
