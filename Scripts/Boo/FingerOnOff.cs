using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class FingerOnOff : MonoBehaviour
{
	public bool loadPrefab;

	public GameObject[] enemyPrefabs;

	private FingerGestures fing;

	private PlayerControl player;

	private bool mc;

	private GameObject lookAtObj;

	private Vector3 camVec;

	private Quaternion camRot;

	private GameObject enemy1;

	private GameObject enemy2;

	private GameObject enemy3;

	private bool coli;

	public FingerOnOff()
	{
		coli = true;
	}

	public void LoadPrefab()
	{
	}

	public void LateUpdate()
	{
		if (loadPrefab)
		{
			LoadPrefab();
			loadPrefab = false;
		}
		if (!fing)
		{
			GameObject gameObject = GameObject.Find("__RuntimeFingerGestures__");
			if ((bool)gameObject)
			{
				fing = gameObject.GetComponent<FingerGestures>();
			}
			GameObject gameObject2 = GameObject.Find("_Characters/C0000_000_MA_ROOT");
			if ((bool)gameObject2)
			{
				player = gameObject2.GetComponent<PlayerControl>();
			}
		}
		if (!mc)
		{
			if (!(Input.mousePosition.x >= (float)(Screen.width / 2)))
			{
				if (!fing.enabled)
				{
					fing.enabled = true;
					if ((bool)player)
					{
						player.InputActive = true;
					}
				}
			}
			else if (fing.enabled)
			{
				fing.enabled = false;
				if ((bool)player)
				{
					player.InputActive = false;
				}
			}
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
			{
				mc = true;
			}
		}
		else if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
		{
			mc = false;
			camVec = Vector3.zero;
		}
		else
		{
			if (!lookAtObj || Input.mousePosition.x >= (float)(Screen.width / 2))
			{
				return;
			}
			if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
			{
				if (camVec == Vector3.zero)
				{
					Quaternion quaternion = Quaternion.Inverse(lookAtObj.transform.rotation);
					camVec = quaternion * (Camera.main.transform.position - lookAtObj.transform.position);
					camRot = quaternion * Camera.main.transform.rotation;
				}
				if (fing.enabled)
				{
					fing.enabled = false;
				}
				Vector3 eulerAngles = lookAtObj.transform.rotation.eulerAngles;
				eulerAngles.x += Input.GetAxis("Mouse Y") * 10f;
				eulerAngles.y += Input.GetAxis("Mouse X") * 10f;
				lookAtObj.transform.eulerAngles = eulerAngles;
				Camera.main.transform.rotation = lookAtObj.transform.rotation * camRot;
				Camera.main.transform.position = lookAtObj.transform.position + lookAtObj.transform.rotation * camVec;
			}
			else if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
			{
				if (camVec == Vector3.zero)
				{
					Quaternion quaternion = Quaternion.Inverse(lookAtObj.transform.rotation);
					camVec = quaternion * (Camera.main.transform.position - lookAtObj.transform.position);
				}
				if (fing.enabled)
				{
					fing.enabled = false;
				}
				float magnitude = camVec.magnitude;
				magnitude += Input.GetAxis("Mouse X");
				if (!(magnitude >= 1f))
				{
					magnitude = 1f;
				}
				camVec = camVec.normalized * magnitude;
				Camera.main.transform.position = lookAtObj.transform.position + lookAtObj.transform.rotation * camVec;
			}
		}
	}

	public void OnGUI()
	{
		if ((bool)enemy1 || (bool)enemy2 || (bool)enemy3)
		{
			GUI.color = Color.green;
		}
		else
		{
			GUI.color = Color.white;
		}
		if (GUI.Button(new Rect(80f, 0f, 80f, 20f), "Put Enemy"))
		{
			if ((bool)enemy1 || (bool)enemy2 || (bool)enemy3)
			{
				if ((bool)enemy1)
				{
					UnityEngine.Object.Destroy(enemy1);
				}
				if ((bool)enemy2)
				{
					UnityEngine.Object.Destroy(enemy2);
				}
				if ((bool)enemy3)
				{
					UnityEngine.Object.Destroy(enemy3);
				}
			}
			else
			{
				if (!enemy1)
				{
					GameObject[] array = enemyPrefabs;
					enemy1 = (GameObject)UnityEngine.Object.Instantiate(array[RuntimeServices.NormalizeArrayIndex(array, Mathf.FloorToInt(UnityEngine.Random.Range(0, enemyPrefabs.Length)))], new Vector3(UnityEngine.Random.Range(-10, 10), 0f, UnityEngine.Random.Range(5, 25)), Quaternion.Euler(0f, 180f, 0f));
				}
				if (!enemy2)
				{
					GameObject[] array2 = enemyPrefabs;
					enemy2 = (GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, Mathf.FloorToInt(UnityEngine.Random.Range(0, enemyPrefabs.Length)))], new Vector3(UnityEngine.Random.Range(-10, 10), 0f, UnityEngine.Random.Range(5, 25)), Quaternion.Euler(0f, 180f, 0f));
				}
				if (!enemy3)
				{
					GameObject[] array3 = enemyPrefabs;
					enemy3 = (GameObject)UnityEngine.Object.Instantiate(array3[RuntimeServices.NormalizeArrayIndex(array3, Mathf.FloorToInt(UnityEngine.Random.Range(0, enemyPrefabs.Length)))], new Vector3(UnityEngine.Random.Range(-10, 10), 0f, UnityEngine.Random.Range(5, 25)), Quaternion.Euler(0f, 180f, 0f));
				}
			}
		}
		if ((bool)enemy1 || (bool)enemy2 || (bool)enemy3)
		{
			string text = null;
			if (coli)
			{
				GUI.color = Color.white;
				text = "On";
			}
			else
			{
				GUI.color = Color.green;
				text = "Off";
			}
			if (GUI.Button(new Rect(80f, 25f, 120f, 20f), "PlayerCollision:" + text))
			{
				coli = !coli;
				GameObject gameObject = GameObject.Find("_Characters/C0000_000_MA_ROOT/c0000_000_ma/y_ang/cog/ColiYarare");
				if ((bool)gameObject && (bool)gameObject.collider)
				{
					gameObject.collider.enabled = coli;
				}
			}
		}
		Ef_SetActiveFromRank ef_SetActiveFromRank = null;
		string text2 = null;
		if (Ef_SetActiveFromRank.rank2test)
		{
			text2 = "Rank 2";
			GUI.color = Color.green;
		}
		else
		{
			text2 = "Rank 1";
			GUI.color = Color.white;
		}
		if (GUI.Button(new Rect(0f, 0f, 80f, 20f), text2))
		{
			Ef_SetActiveFromRank.rank2test = !Ef_SetActiveFromRank.rank2test;
		}
		GUI.color = Color.white;
		if (GUI.Button(new Rect(160f, 0f, 120f, 20f), "Camera Reset"))
		{
			Vector3 vector = default(Vector3);
			GameObject gameObject2 = GameObject.Find("_Characters/C0000_000_MA_ROOT");
			if ((bool)gameObject2)
			{
				vector = gameObject2.transform.position;
			}
			lookAtObj = GameObject.Find("_MotionViewer/Camera LookAt (Dummy)");
			if ((bool)lookAtObj)
			{
				lookAtObj.transform.position = new Vector3(0f, 1f, 0f) + vector;
				lookAtObj.transform.rotation = Quaternion.Euler(new Vector3(345f, 54f, 0f));
			}
			Camera.main.transform.position = new Vector3(6f, 6f, 12f) + vector;
			Camera.main.transform.rotation = Quaternion.Euler(new Vector3(19f, 231f, 0f));
		}
	}
}
