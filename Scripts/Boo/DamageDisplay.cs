using System;
using System.Text;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class DamageDisplay : MonoBehaviour
{
	[Serializable]
	public enum Type
	{
		Normal,
		Guard,
		PlayerTeam,
		Critical
	}

	public Popup[] popups;

	[NonSerialized]
	public const string DAMAGE_DISPLAY_PREFAB_PATH = "Prefab/GUI/DamageDisplay";

	[NonSerialized]
	public const float NORMAL_DAMAGE_LABEL_SIZE = 30f;

	[NonSerialized]
	public const float CRITICAL_DAMAGE_LABEL_SIZE = 48f;

	[NonSerialized]
	public const float CURE_DAMAGE_LABEL_SIZE = 30f;

	[NonSerialized]
	public const float COLOSSEUM_COST_LABEL_SIZE = 40f;

	[NonSerialized]
	private static readonly Color ENEMY_SIDE_COLOR = Color.white;

	[NonSerialized]
	private static readonly Color PLAYER_SIDE_COLOR = Color.red;

	[NonSerialized]
	private static readonly Color CRITICAL_COLOR = Color.yellow;

	[NonSerialized]
	private static readonly Color GUARD_COLOR = Color.gray;

	[NonSerialized]
	private static readonly Color CURE_COLOR = Color.green;

	[NonSerialized]
	private static readonly Color NUT_GET_COLOR = new Color(0.11764706f, 0.5882353f, 1f);

	[NonSerialized]
	private static readonly Color COLOSSEUM_COST_POP_COLOR_SIDE1 = new Color(2f / 85f, 0.39607844f, 0.7607843f);

	[NonSerialized]
	private static readonly Color COLOSSEUM_COST_POP_COLOR_SIDE2 = new Color(0.8745098f, 2f / 51f, 0f);

	[NonSerialized]
	private static DamageDisplay _instance;

	public Popup[] Popups
	{
		get
		{
			return popups;
		}
		set
		{
			popups = value;
		}
	}

	public static void DrawByType(Vector3 pos, int value, Type type)
	{
		switch (type)
		{
		case Type.Normal:
			DamageEnemySide(pos, value);
			break;
		case Type.PlayerTeam:
			DamagePlayerSide(pos, value);
			break;
		case Type.Critical:
			DamageCritical(pos, value);
			break;
		case Type.Guard:
			DamageGuard(pos, value);
			break;
		default:
			DamageEnemySide(pos, value);
			break;
		}
	}

	public static void DamageEnemySide(Vector3 pos, int damage)
	{
		Draw(pos, damage, ENEMY_SIDE_COLOR, 30f, critical: false);
	}

	public static void DamagePlayerSide(Vector3 pos, int damage)
	{
		Draw(pos, damage, PLAYER_SIDE_COLOR, 30f, critical: false);
	}

	public static void DamageCritical(Vector3 pos, int damage)
	{
		Draw(pos, damage, CRITICAL_COLOR, 48f, critical: true);
	}

	public static void DamageGuard(Vector3 pos, int damage)
	{
		Draw(pos, damage, GUARD_COLOR, 30f, critical: true);
	}

	public static void Heal(Vector3 pos, int recover)
	{
		Draw(pos, recover, CURE_COLOR, 30f);
	}

	public static void HealPlayer(PlayerControl pl, int recover)
	{
		if (pl != null)
		{
			Heal(pl.MYPOS, recover);
		}
	}

	public static void NutGet(Vector3 pos, int pnt)
	{
		Draw(pos, pnt, NUT_GET_COLOR, 30f);
	}

	public static void DisplayAddPlayerHp(PlayerControl pl, float val)
	{
		if (!(pl == null))
		{
			Draw(pl.transform.root.position, checked((int)val), CURE_COLOR, 30f);
		}
	}

	public static void DisplayColosseumForceChange(int cost, bool isPlayerSide)
	{
		Color color = ((!isPlayerSide) ? COLOSSEUM_COST_POP_COLOR_SIDE2 : COLOSSEUM_COST_POP_COLOR_SIDE1);
		float size = 40f;
		float num = 200f;
		float y = (float)Screen.height * 0.5f - 110f;
		Vector3 localPos = new Vector3(0f, y, 0f);
		localPos.x = ((!isPlayerSide) ? num : (0f - num));
		Popup popup = Instance().popLocalPos(localPos, new StringBuilder("DOWN\n").Append((object)cost).ToString(), color, size, critical: false);
		if (popup != null)
		{
			popup.LifeTime *= 2f;
			popup.MoveAtTime *= 0.5f;
		}
	}

	public static DamageDisplay Instance()
	{
		if (_instance == null)
		{
			GameObject gameObject = GameAssetModule.LoadPrefab("Prefab/GUI/DamageDisplay") as GameObject;
			if (!(gameObject != null))
			{
				throw new AssertionFailedException("prefab != null");
			}
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject);
			if (!(gameObject2 != null))
			{
				throw new AssertionFailedException("go != null");
			}
			DamageDisplay damageDisplay = ExtensionsModule.SetComponent<DamageDisplay>(gameObject2);
			if (!(damageDisplay != null))
			{
				throw new AssertionFailedException("o != null");
			}
			_instance = damageDisplay;
		}
		return _instance;
	}

	private static void Draw(Vector3 pos, int damage, Color color, float size)
	{
		if ((float)damage > 0f)
		{
			Instance().pop(pos, damage.ToString(), color, size, critical: false);
		}
	}

	private static void Draw(Vector3 pos, int damage, Color color, float size, bool critical)
	{
		Instance().pop(pos, damage.ToString(), color, size, critical);
	}

	private Popup pop(Vector3 pos, string damage, Color color, float size, bool critical)
	{
		if (critical)
		{
			damage = toCriticalNumbers(damage);
		}
		Popup popup = newPopup();
		if (popup != null)
		{
			popup.initOnMainCam(pos, damage, color, size);
		}
		return popup;
	}

	private Popup popLocalPos(Vector3 localPos, string damage, Color color, float size, bool critical)
	{
		if (critical)
		{
			damage = toCriticalNumbers(damage);
		}
		Popup popup = newPopup();
		if (popup != null)
		{
			popup.initLocal(localPos, damage, color, size);
		}
		return popup;
	}

	private string toCriticalNumbers(string str)
	{
		string text = "0123456789%";
		string text2 = "pqwertyuioa";
		string text3 = string.Empty;
		CharEnumerator enumerator = str.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				char current = enumerator.Current;
				int num = text.IndexOf(current);
				text3 += ((num < 0) ? current : text2[num]);
			}
			return text3;
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
		}
	}

	private Popup newPopup()
	{
		int num = 0;
		Popup[] array = popups;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (!(array[num] == null) && !array[num].gameObject.activeSelf)
				{
					array[num].gameObject.SetActive(value: true);
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (Popup)result;
	}
}
