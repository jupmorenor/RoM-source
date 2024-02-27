using System;
using System.Text;
using UnityEngine;

[Serializable]
public class TouchRayInfo
{
	[Serializable]
	public class Info
	{
		public bool Touch;

		public RaycastHit hit;

		public GameObject hitObject;

		public float distance;

		public Vector3 Point => hit.point;

		public void clear()
		{
			Touch = false;
			distance = float.MaxValue;
		}

		public void setInfo(RaycastHit _hit)
		{
			setInfo(_hit, null);
		}

		public void setInfo(RaycastHit _hit, GameObject obj)
		{
			Touch = true;
			hit = _hit;
			hitObject = obj;
		}

		public float distanceTo(Vector3 pos)
		{
			return (pos - hit.point).magnitude;
		}

		public override string ToString()
		{
			return new StringBuilder("Touch:").Append(Touch).Append(" hit:").Append(hit.point)
				.Append(" obj:")
				.Append(hitObject)
				.ToString();
		}
	}

	private Info any;

	private Info plane;

	private Info enemy;

	private Info poppet;

	private bool casted;

	public bool Touched => any.Touch;

	public bool TouchedPlane => plane.Touch;

	public Info Any => any;

	public Info Plane => plane;

	public Info Enemy => enemy;

	public Info Poppet => poppet;

	public bool Casted => casted;

	public TouchRayInfo()
	{
		any = new Info();
		plane = new Info();
		enemy = new Info();
		poppet = new Info();
	}

	public void clear()
	{
		any.clear();
		enemy.clear();
		poppet.clear();
		plane.clear();
	}

	public void updateTouchInfo(bool touched, Vector3 touchScreenPos)
	{
		clear();
		casted = false;
		if (!touched)
		{
			return;
		}
		casted = true;
		Camera main = Camera.main;
		if (main == null)
		{
			return;
		}
		Ray ray = main.ScreenPointToRay(touchScreenPos);
		int i = 0;
		RaycastHit[] array = Physics.RaycastAll(ray);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			any.setInfo(array[i]);
			string tag = array[i].transform.root.tag;
			string tag2 = array[i].transform.tag;
			if (tag == "Enemy")
			{
				enemy.setInfo(array[i], array[i].transform.root.gameObject);
			}
			else if (tag2 == "Player")
			{
				poppet.setInfo(array[i], array[i].transform.root.gameObject);
			}
			else if (tag2 == "Plane")
			{
				plane.setInfo(array[i]);
			}
		}
	}
}
