using System;
using System.Collections.Generic;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PlayerLabelControl : MonoBehaviour
{
	[Serializable]
	public class Pair
	{
		public PlayerControl player;

		public RaidNamePlate plate;

		public void destroy()
		{
			if (plate != null)
			{
				UnityEngine.Object.Destroy(plate.gameObject);
			}
			plate = null;
		}
	}

	public RaidNamePlate ネームプレート;

	public Vector3 プレートサイズ;

	[NonSerialized]
	private static Boo.Lang.List<PlayerLabelControl> _InstanceList = new Boo.Lang.List<PlayerLabelControl>();

	private Boo.Lang.List<Pair> plates;

	public static PlayerLabelControl Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public static RaidNamePlate NamePlate
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__NamePlate;
		}
	}

	public static Vector3 PlateSize
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__PlateSize;
		}
	}

	public RaidNamePlate __NamePlate => ネームプレート;

	public Vector3 __PlateSize => プレートサイズ;

	public PlayerLabelControl()
	{
		プレートサイズ = new Vector3(1f, 1f, 1f);
		plates = new Boo.Lang.List<Pair>();
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void clearAll()
	{
		IEnumerator<PlayerLabelControl> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerLabelControl current = enumerator.Current;
				current.__clearAll();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __clearAll()
	{
		IEnumerator<Pair> enumerator = plates.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Pair current = enumerator.Current;
				current.destroy();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		plates.Clear();
	}

	public static void setLabel(PlayerControl pl, string myName)
	{
		IEnumerator<PlayerLabelControl> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerLabelControl current = enumerator.Current;
				current.__setLabel(pl, myName);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setLabel(PlayerControl pl, string myName)
	{
		if (!(pl == null))
		{
			RaidNamePlate plate = getPlate(pl);
			if (plate != null)
			{
				plate.setName(myName);
				Vector3 position = Camera.main.WorldToScreenPoint(pl.transform.position);
				position.z = 1f;
				position.y += 75f;
				Camera camera = CameraInAncestors(plate.gameObject);
				Vector3 position2 = camera.ScreenToWorldPoint(position);
				plate.transform.position = position2;
			}
		}
	}

	private static Camera CameraInAncestors(GameObject o)
	{
		return ExtensionsModule.ComponentInAncestors<Camera>(o);
	}

	public void Update()
	{
		IEnumerator<Pair> enumerator = plates.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Pair current = enumerator.Current;
				if (current.player == null)
				{
					current.destroy();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		plates.RemoveAll(_0024adaptor_0024__PlayerLabelControl_0024callable354_002451_27___0024Predicate_0024163.Adapt((Pair pair) => pair.player == null));
	}

	private RaidNamePlate getPlate(PlayerControl pl)
	{
		object result;
		RaidNamePlate plate;
		if (NamePlate == null)
		{
			result = null;
		}
		else
		{
			IEnumerator<Pair> enumerator = plates.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Pair current = enumerator.Current;
					if (!(current.player == pl))
					{
						continue;
					}
					plate = current.plate;
					goto IL_011e;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(NamePlate.gameObject)) as GameObject;
			if (gameObject == null)
			{
				result = null;
			}
			else
			{
				ExtensionsModule.SetParent(gameObject, this.gameObject);
				gameObject.transform.localScale = PlateSize;
				RaidNamePlate raidNamePlate = ExtensionsModule.SetComponent<RaidNamePlate>(gameObject);
				if (raidNamePlate == null)
				{
					result = null;
				}
				else
				{
					TutorialArrow tutorialArrow = ExtensionsModule.SetComponent<TutorialArrow>(gameObject);
					if (tutorialArrow != null)
					{
						tutorialArrow.target = pl.gameObject;
					}
					Boo.Lang.List<Pair> list = plates;
					Pair pair = new Pair();
					PlayerControl playerControl = (pair.player = pl);
					RaidNamePlate raidNamePlate2 = (pair.plate = raidNamePlate);
					list.Add(pair);
					result = raidNamePlate;
				}
			}
		}
		goto IL_0120;
		IL_0120:
		return (RaidNamePlate)result;
		IL_011e:
		result = plate;
		goto IL_0120;
	}

	internal bool _0024Update_0024closure_00243104(Pair pair)
	{
		return pair.player == null;
	}
}
