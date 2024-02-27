using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestDropManager
{
	[Serializable]
	public abstract class DropData
	{
		public bool placed;

		public float posX;

		public float posY;

		public float posZ;

		public bool pickedUp;

		public Vector3 position
		{
			get
			{
				return new Vector3(posX, posY, posZ);
			}
			set
			{
				posX = value.x;
				posY = value.y;
				posZ = value.z;
			}
		}

		public virtual GameObject doInstantiate()
		{
			if (string.IsNullOrEmpty("couldnot call abstract DropData.doInstantiate()"))
			{
				throw new AssertionFailedException("'couldnot call abstract DropData.doInstantiate()'");
			}
			return null;
		}

		public override string ToString()
		{
			return new StringBuilder().Append(GetType()).Append(" placed:").Append(placed)
				.Append(" pickedUp:")
				.Append(pickedUp)
				.Append(" position:")
				.Append(position)
				.ToString();
		}
	}

	[Serializable]
	public class Place
	{
		public MScenes scene;

		public Vector3 position;
	}

	private Dictionary<MScenes, Boo.Lang.List<DropData>> dropMap;

	public int TotalDropNum
	{
		get
		{
			int num = 0;
			foreach (MScenes key in DropMap.Keys)
			{
				num = checked(num + ((ICollection)DropMap[key]).Count);
			}
			return num;
		}
	}

	public int PickedUpNum
	{
		get
		{
			int num = 0;
			foreach (MScenes key in DropMap.Keys)
			{
				IEnumerator<DropData> enumerator2 = DropMap[key].GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						DropData current2 = enumerator2.Current;
						if (current2.pickedUp)
						{
							num = checked(num + 1);
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
			}
			return num;
		}
	}

	public int RemainingNum
	{
		get
		{
			int num = 0;
			foreach (MScenes key in DropMap.Keys)
			{
				IEnumerator<DropData> enumerator2 = DropMap[key].GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						DropData current2 = enumerator2.Current;
						if (!current2.pickedUp)
						{
							num = checked(num + 1);
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
			}
			return num;
		}
	}

	public Dictionary<MScenes, Boo.Lang.List<DropData>> DropMap => dropMap;

	public QuestDropManager()
	{
		dropMap = new Dictionary<MScenes, Boo.Lang.List<DropData>>();
	}

	public DropData[] GetDropData(MScenes scn)
	{
		return (scn != null && DropMap.ContainsKey(scn)) ? ((DropData[])Builtins.array(typeof(DropData), DropMap[scn])) : new DropData[0];
	}

	public int totalDropNum<T>() where T : DropData
	{
		int num = 0;
		foreach (MScenes key in DropMap.Keys)
		{
			IEnumerator<DropData> enumerator2 = DropMap[key].GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DropData current2 = enumerator2.Current;
					if (current2 is T)
					{
						num = checked(num + 1);
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		return num;
	}

	public int remainingDropNum<T>()
	{
		int num = 0;
		foreach (MScenes key in DropMap.Keys)
		{
			IEnumerator<DropData> enumerator2 = DropMap[key].GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DropData current2 = enumerator2.Current;
					if (!current2.pickedUp && current2 is T)
					{
						num = checked(num + 1);
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		return num;
	}

	public int pickedUpNum<T>()
	{
		int num = 0;
		foreach (MScenes key in DropMap.Keys)
		{
			IEnumerator<DropData> enumerator2 = DropMap[key].GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DropData current2 = enumerator2.Current;
					if (current2.pickedUp && current2 is T)
					{
						num = checked(num + 1);
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
		return num;
	}

	public void PickedDropUp(DropData kdata)
	{
		foreach (Boo.Lang.List<DropData> value in DropMap.Values)
		{
			IEnumerator<DropData> enumerator2 = value.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DropData current2 = enumerator2.Current;
					if (RuntimeServices.EqualityOperator(current2, kdata))
					{
						current2.pickedUp = true;
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	public void clear()
	{
		DropMap.Clear();
	}

	public void PlaceDrops(MQuests q, DropData[] dataList)
	{
		if (q == null)
		{
			throw new AssertionFailedException("q != null");
		}
		if (dataList == null || dataList.Length <= 0)
		{
			return;
		}
		DropMap.Clear();
		MScenes[] array = q.StartSceneId.collectAllLinkedScenes();
		Boo.Lang.List<MScenes> list = new Boo.Lang.List<MScenes>();
		int i = 0;
		MScenes[] array2 = array;
		int num;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (array2[i].HasKusamushiPositions)
				{
					list.Add(array2[i]);
				}
			}
			if (((ICollection)list).Count > 0)
			{
				Boo.Lang.List<Place> list2 = new Boo.Lang.List<Place>();
				IEnumerator<MScenes> enumerator = list.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						MScenes current = enumerator.Current;
						int j = 0;
						Vector3[] kusamushiPositionsAsVector = current.KusamushiPositionsAsVector3;
						for (int length2 = kusamushiPositionsAsVector.Length; j < length2; j++)
						{
							Place place = new Place();
							MScenes mScenes = (place.scene = current);
							Vector3 vector = (place.position = kusamushiPositionsAsVector[j] + Noise());
							list2.Add(place);
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				ShufflePlaces(list2);
				IEnumerator<MScenes> enumerator2 = list.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						MScenes current2 = enumerator2.Current;
						DropMap[current2] = new Boo.Lang.List<DropData>();
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				num = 0;
				int k = 0;
				for (int length3 = dataList.Length; k < length3; k++)
				{
					unchecked
					{
						if (dataList[k] != null)
						{
							Place place2 = list2[num];
							dataList[k].position = place2.position;
							dataList[k].placed = true;
							DropMap[place2.scene].Add(dataList[k]);
							num = checked(num + 1) % ((ICollection)list2).Count;
						}
					}
				}
				return;
			}
		}
		for (int l = 0; l < 30; l++)
		{
			int num2 = l;
		}
		IEnumerator enumerator3 = array.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			object obj = enumerator3.Current;
			if (!(obj is MScenes))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MScenes));
			}
			MScenes mScenes2 = (MScenes)obj;
			if (!RuntimeServices.EqualityOperator(mScenes2, q.StartSceneId))
			{
				list.Add(mScenes2);
			}
		}
		if (((ICollection)list).Count <= 0)
		{
			throw new AssertionFailedException("草虫配置に失敗（配置可能MScenes数＝0）");
		}
		ShuffleScenes(list);
		IEnumerator<MScenes> enumerator4 = list.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				MScenes current3 = enumerator4.Current;
				DropMap[current3] = new Boo.Lang.List<DropData>();
			}
		}
		finally
		{
			enumerator4.Dispose();
		}
		int num3 = Mathf.Max(1, dataList.Length / ((ICollection)list).Count);
		num = 0;
		int m = 0;
		for (int length4 = dataList.Length; m < length4; m = checked(m + 1))
		{
			MScenes key = list[num];
			DropMap[key].Add(dataList[m]);
			num = checked(num + 1) % ((ICollection)list).Count;
		}
	}

	private Vector3 Noise()
	{
		float x = UnityEngine.Random.Range(-0.5f, 0.5f);
		float z = UnityEngine.Random.Range(-0.5f, 0.5f);
		return new Vector3(x, 0f, z);
	}

	private void ShuffleScenes(Boo.Lang.List<MScenes> scenes)
	{
		if (scenes != null && ((ICollection)scenes).Count > 1)
		{
			int count = ((ICollection)scenes).Count;
			int num = 0;
			int num2 = checked(count * 2);
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				int index = UnityEngine.Random.Range(0, count);
				int index2 = UnityEngine.Random.Range(0, count);
				MScenes value = scenes[index];
				scenes[index] = scenes[index2];
				scenes[index2] = value;
			}
		}
	}

	private void ShufflePlaces(Boo.Lang.List<Place> places)
	{
		if (places != null && ((ICollection)places).Count > 1)
		{
			int count = ((ICollection)places).Count;
			int num = 0;
			int num2 = checked(count * 2);
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				int index = UnityEngine.Random.Range(0, count);
				int index2 = UnityEngine.Random.Range(0, count);
				Place value = places[index];
				places[index] = places[index2];
				places[index2] = value;
			}
		}
	}

	public GameObject[] PutDropObjects(MScenes scn, GameObject altObjBase, string altObjName, string prefabName)
	{
		DropData[] dropData = GetDropData(scn);
		Vector3[] altPlaces = getAltPlaces(altObjBase, altObjName);
		int num = 0;
		Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
		int i = 0;
		DropData[] array = dropData;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i].pickedUp)
			{
				continue;
			}
			Vector3 vector = default(Vector3);
			if (array[i].placed)
			{
				vector = array[i].position;
			}
			else
			{
				if (altPlaces.Length <= 0)
				{
					throw new AssertionFailedException("ステージドロップおく場所が無いよ？ - " + scn);
				}
				vector = altPlaces[RuntimeServices.NormalizeArrayIndex(altPlaces, num)];
				num = checked(num + 1) % altPlaces.Length;
			}
			GameObject gameObject = array[i].doInstantiate();
			if (!(gameObject != null))
			{
				throw new AssertionFailedException("obj != null");
			}
			DropBase component = gameObject.GetComponent<DropBase>();
			if (!(component != null))
			{
				throw new AssertionFailedException("dbase != null");
			}
			if (component != null)
			{
				list.Add(component.gameObject);
				component.add(array[i]);
				vector = BattleUtil.AdjustYpos(vector);
				vector.y += 0.5f;
				component.transform.position = vector;
				array[i].position = vector;
				array[i].placed = true;
			}
		}
		return (GameObject[])Builtins.array(typeof(GameObject), list);
	}

	private Vector3[] getAltPlaces(GameObject objRoot, string objName)
	{
		GameObject[] gs = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(objRoot, objName);
		Vector3[] array = ArrayMap.GameObjectsToPositions(gs);
		if (array.Length <= 0)
		{
			GameObject[] lhs = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(objRoot, "pop");
			GameObject[] rhs = ExtensionsModule.FindChildrenIgnoreCaseStartsWith(objRoot, "pos");
			array = ArrayMap.GameObjectsToPositions((GameObject[])RuntimeServices.AddArrays(typeof(GameObject), lhs, rhs));
		}
		return array;
	}

	public void serialize(QuestSerializer ser)
	{
		ser.serialize(((ICollection)dropMap.Keys).Count);
		foreach (MScenes key in dropMap.Keys)
		{
			ser.serialize(key.Id);
			ser.serialize(((ICollection)dropMap[key]).Count);
			IEnumerator<DropData> enumerator2 = dropMap[key].GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DropData current2 = enumerator2.Current;
					if (current2 == null)
					{
						throw new AssertionFailedException("d != null");
					}
					ser.serialize(current2.GetType().Name);
					ser.serialize(current2.placed);
					ser.serialize(current2.posX);
					ser.serialize(current2.posY);
					ser.serialize(current2.posZ);
					ser.serialize(current2.pickedUp);
					if (current2 is DropDataKusamushi)
					{
						ser.serialize((current2 as DropDataKusamushi).kusamushiMasterId);
					}
					else if (!(current2 is DropDataCandy) && !(current2 is DropDataNut))
					{
						if (current2 is DropDataStageCoin)
						{
							throw new Exception("まだできてない！！！ call 西森");
						}
						throw new Exception(new StringBuilder("未サポートdrop data: ").Append(current2.GetType()).ToString());
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	public void deserialize(QuestSerializer ser)
	{
		dropMap.Clear();
		int num = ser.typedDeserialize<int>();
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			int num5 = ser.typedDeserialize<int>();
			MScenes mScenes = MScenes.Get(num5);
			if (mScenes == null)
			{
				throw new AssertionFailedException(new StringBuilder("deserialize エラー: ").Append((object)num5).Append("のMScenesが無い").ToString());
			}
			dropMap[mScenes] = new Boo.Lang.List<DropData>();
			int num6 = ser.typedDeserialize<int>();
			int num7 = 0;
			int num8 = num6;
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num7 < num8)
			{
				int num9 = num7;
				num7++;
				string text = ser.typedDeserialize<string>();
				bool placed = ser.typedDeserialize<bool>();
				float posX = ser.typedDeserialize<float>();
				float posY = ser.typedDeserialize<float>();
				float posZ = ser.typedDeserialize<float>();
				bool pickedUp = ser.typedDeserialize<bool>();
				DropData dropData = null;
				if (text == typeof(DropDataKusamushi).Name)
				{
					DropDataKusamushi dropDataKusamushi = new DropDataKusamushi();
					dropDataKusamushi.kusamushiMasterId = ser.typedDeserialize<int>();
					dropData = dropDataKusamushi;
				}
				else if (text == typeof(DropDataCandy).Name)
				{
					dropData = new DropDataCandy();
				}
				else
				{
					if (!(text == typeof(DropDataNut).Name))
					{
						if (text == typeof(DropDataStageCoin).Name)
						{
							throw new Exception("まだできてない！！！ call 西森");
						}
						throw new Exception(new StringBuilder("未サポートdrop data: ").Append(text).ToString());
					}
					dropData = new DropDataNut();
				}
				if (dropData == null)
				{
					throw new AssertionFailedException(new StringBuilder("deserialize エラー: ").Append(text).Append(" 生成できない").ToString());
				}
				dropData.placed = placed;
				dropData.posX = posX;
				dropData.posY = posY;
				dropData.posZ = posZ;
				dropData.pickedUp = pickedUp;
				dropMap[mScenes].Add(dropData);
			}
		}
	}
}
