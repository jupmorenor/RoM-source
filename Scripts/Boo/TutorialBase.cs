using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using S540;
using UnityEngine;

[Serializable]
public class TutorialBase : S540Base
{
	[Serializable]
	internal class _0024S540_cutscene_0024locals_002414458
	{
		internal bool _0024endOfCS;
	}

	[Serializable]
	internal class _0024S540_cutscene_0024closure_00243256
	{
		internal _0024S540_cutscene_0024locals_002414458 _0024_0024locals_002415013;

		public _0024S540_cutscene_0024closure_00243256(_0024S540_cutscene_0024locals_002414458 _0024_0024locals_002415013)
		{
			this._0024_0024locals_002415013 = _0024_0024locals_002415013;
		}

		public void Invoke()
		{
			_0024_0024locals_002415013._0024endOfCS = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_chat_002419786 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string[][] _0024t1_002419787;

			internal string _0024speaker_002419788;

			internal string _0024message_002419789;

			internal int _0024windowType_002419790;

			public _0024(string speaker, string message, int windowType)
			{
				_0024speaker_002419788 = speaker;
				_0024message_002419789 = message;
				_0024windowType_002419790 = windowType;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024t1_002419787 = new string[1][] { new string[2] { _0024speaker_002419788, _0024message_002419789 } };
					SetChatWindow(_0024t1_002419787, _0024windowType_002419790);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					result = ((IsEndOfChat(_0024windowType_002419790) ? YieldDefault(4) : YieldDefault(3)) ? 1 : 0);
					break;
				case 4:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024speaker_002419791;

		internal string _0024message_002419792;

		internal int _0024windowType_002419793;

		public _0024S540_chat_002419786(string speaker, string message, int windowType)
		{
			_0024speaker_002419791 = speaker;
			_0024message_002419792 = message;
			_0024windowType_002419793 = windowType;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024speaker_002419791, _0024message_002419792, _0024windowType_002419793);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_chat_close_002419794 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					CloseChatWindow();
					goto case 2;
				case 2:
					result = (((!EventWindow.isWindow) ? YieldDefault(3) : YieldDefault(2)) ? 1 : 0);
					break;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_konnichiwa_002419795 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00241860_002419796;

			internal Component _0024c1_002419797;

			internal float _0024time_002419798;

			internal TutorialBase _0024self__002419799;

			public _0024(Component c1, float time, TutorialBase self_)
			{
				_0024c1_002419797 = c1;
				_0024time_002419798 = time;
				_0024self__002419799 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419799.lookAt(_0024c1_002419797, _0024self__002419799.PlayerPos, _0024time_002419798);
					_0024self__002419799.lookAt(Player, _0024c1_002419797.transform.position, _0024time_002419798);
					_0024_0024wait_sec_0024temp_00241860_002419796 = _0024time_002419798;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241860_002419796 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241860_002419796 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Component _0024c1_002419800;

		internal float _0024time_002419801;

		internal TutorialBase _0024self__002419802;

		public _0024S540_konnichiwa_002419795(Component c1, float time, TutorialBase self_)
		{
			_0024c1_002419800 = c1;
			_0024time_002419801 = time;
			_0024self__002419802 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c1_002419800, _0024time_002419801, _0024self__002419802);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024S540_cutscene_002419803 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CutSceneManager _0024cs_002419804;

			internal _0024S540_cutscene_0024locals_002414458 _0024_0024locals_002419805;

			internal string _0024cutSceneName_002419806;

			public _0024(string cutSceneName)
			{
				_0024cutSceneName_002419806 = cutSceneName;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002419805 = new _0024S540_cutscene_0024locals_002414458();
					_0024cs_002419804 = CutSceneManager.CutSceneEx(_0024cutSceneName_002419806, null, _0024cutSceneName_002419806, autoStart: true);
					_0024_0024locals_002419805._0024endOfCS = false;
					_0024cs_002419804.CloseHandler = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024S540_cutscene_0024closure_00243256(_0024_0024locals_002419805).Invoke);
					if (!_0024cs_002419804.autoStartFlag)
					{
						_0024cs_002419804.StartCutScene();
					}
					goto case 2;
				case 2:
					if (!_0024_0024locals_002419805._0024endOfCS)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024cutSceneName_002419807;

		public _0024S540_cutscene_002419803(string cutSceneName)
		{
			_0024cutSceneName_002419807 = cutSceneName;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024cutSceneName_002419807);
		}
	}

	private bool gimmickSystemIsInitialized;

	protected float dispIconPlayerDistance;

	[NonSerialized]
	private static Dictionary<int, int> eventChatWindows = new Dictionary<int, int>();

	[NonSerialized]
	private static PlayerControl _player;

	protected TouchSensor touchSensor => ExtensionsModule.SetComponent<TouchSensor>(gameObject);

	public float DispIconPlayerDistance
	{
		get
		{
			return dispIconPlayerDistance;
		}
		set
		{
			dispIconPlayerDistance = value;
			GimmickIconSystem instance = GimmickIconSystem.Instance;
			if ((bool)instance)
			{
				instance.setShowCondition(gameObject, (GameObject tobj) => nearPlayer(tobj));
			}
		}
	}

	public static MyHomeUI MyHomeUIObj => ((MyHomeUI)UnityEngine.Object.FindObjectOfType(typeof(MyHomeUI))) as MyHomeUI;

	public static PlayerControl Player
	{
		get
		{
			object result;
			if (_player == null)
			{
				PlayerControl playerControl = ((PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl))) as PlayerControl;
				if (playerControl == null)
				{
					result = null;
					goto IL_0047;
				}
				_player = playerControl;
			}
			result = _player;
			goto IL_0047;
			IL_0047:
			return (PlayerControl)result;
		}
	}

	public Vector3 PlayerPos => Player ? Player.transform.position : transform.position;

	public TutorialBase()
	{
		dispIconPlayerDistance = 4f;
	}

	public virtual void OnDestroy()
	{
		CloseChatWindow();
	}

	protected bool touch(CollisionMessage c)
	{
		return !(c == null) && touch(c.gameObject);
	}

	protected bool touch(Component obj)
	{
		return !(obj == null) && touch(obj.gameObject);
	}

	protected bool touch(GameObject gobj)
	{
		return !(gobj == null) && touchMarker(gobj);
	}

	protected bool touchMarker(Component obj)
	{
		return !(obj == null) && touchMarker(obj.gameObject);
	}

	protected bool touchMarker(GameObject gobj)
	{
		int num;
		if (gobj == null)
		{
			num = 0;
		}
		else if (touchSensor.touch(gobj))
		{
			num = 1;
		}
		else
		{
			GimmickIconSystem instance = GimmickIconSystem.Instance;
			if (instance == null)
			{
				num = 0;
			}
			else
			{
				GimmickIcon gimmickIcon = instance.icon(gobj);
				num = ((gimmickIcon != null) ? 1 : 0);
				if (num != 0)
				{
					num = (gimmickIcon.TouchIcon ? 1 : 0);
				}
			}
		}
		return (byte)num != 0;
	}

	protected void showTouchMarker(Component npc, GimmickIconTypes type)
	{
		showTouchMarker(npc.gameObject, type, Vector3.zero);
	}

	protected void showTouchMarker(Component npc, GimmickIconTypes type, Vector3 offset)
	{
		showTouchMarker(npc.gameObject, type, offset);
	}

	protected void showTouchMarker(GameObject npc, GimmickIconTypes type)
	{
		showTouchMarker(npc, type, Vector3.zero);
	}

	protected void showTouchMarker(GameObject npc, GimmickIconTypes type, Vector3 offset)
	{
		if (npc == null)
		{
			return;
		}
		GimmickIconSystem instance = GimmickIconSystem.Instance;
		if ((bool)instance)
		{
			GimmickIcon gimmickIcon = instance.show(npc, type);
			if (gimmickIcon != null)
			{
				gimmickIcon.LeastShowTime = 0.5f;
				gimmickIcon.Attach.setOffsetXY(0f, -180f, 0f);
				gimmickIcon.Offset3D = offset;
			}
		}
	}

	protected void hideTouchMarker(Component npc)
	{
		if (!(npc == null))
		{
			hideTouchMarker(npc.gameObject);
		}
	}

	protected void hideTouchMarker(GameObject npc)
	{
		if (!(npc == null))
		{
			GimmickIconSystem instance = GimmickIconSystem.Instance;
			if ((bool)instance)
			{
				instance.hide(npc);
			}
		}
	}

	protected GimmickIcon enableTownPeopleTouchMarker(NPCControl npc)
	{
		return (!(npc == null)) ? enableObjectTouchMarker(new GameObject[1] { npc.gameObject }, new GimmickIconTypes[1] { npc.iconType }, new Vector3[1] { Vector3.zero }) : null;
	}

	protected GimmickIcon enableTownPeopleTouchMarker(NPCControl npc, Vector3 offset)
	{
		return (!(npc == null)) ? enableObjectTouchMarker(new GameObject[1] { npc.gameObject }, new GimmickIconTypes[1] { npc.iconType }, new Vector3[1] { offset }) : null;
	}

	protected GimmickIcon enableTownPeopleTouchMarker(NPCControl[] _npcs, Vector3[] offsets)
	{
		NPCControl[] array = ArrayMapMain.NonNulls(_npcs);
		GameObject[] objs = ArrayMapMain.NpcsToGameObjects(array);
		GimmickIconTypes[] array2 = new GimmickIconTypes[array.Length];
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = array[RuntimeServices.NormalizeArrayIndex(array, index)].iconType;
		}
		return enableObjectTouchMarker(objs, array2, offsets);
	}

	protected GimmickIcon enableObjectTouchMarker(Component[] objs, GimmickIconTypes iconType, Vector3[] offsets)
	{
		return enableObjectTouchMarker(ArrayMap.ComponentsToGameObjects(objs), (GimmickIconTypes[])(new GimmickIconTypes[1] { iconType } * objs.Length), offsets);
	}

	protected GimmickIcon enableObjectTouchMarker(GameObject[] objs, GimmickIconTypes[] iconTypes, Vector3[] offsets)
	{
		GimmickIconSystem instance = GimmickIconSystem.Instance;
		object result;
		if (!instance)
		{
			result = null;
		}
		else
		{
			Builtins.ZipEnumerator zipEnumerator = Builtins.zip(objs, iconTypes, offsets);
			GimmickIcon icon = default(GimmickIcon);
			try
			{
				while (zipEnumerator.MoveNext())
				{
					object obj = zipEnumerator.Current;
					if (!(obj is object[]))
					{
						obj = RuntimeServices.Coerce(obj, typeof(object[]));
					}
					object[] array = (object[])obj;
					object obj2 = array[0];
					if (!(obj2 is GameObject))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
					}
					GameObject gameObject = (GameObject)obj2;
					GimmickIconTypes iconType = (GimmickIconTypes)array[1];
					Vector3 offset3D = (Vector3)array[2];
					icon = instance.getIcon(gameObject, 0f, iconType);
					if ((bool)icon)
					{
						icon.hide();
						icon.LeastShowTime = 0.5f;
						icon.Attach.setOffsetXY(0f, 0f, 0f);
						icon.Offset3D = offset3D;
					}
					instance.setShowCondition(gameObject, (GameObject tobj) => nearPlayer(tobj));
				}
			}
			finally
			{
				((IDisposable)zipEnumerator).Dispose();
			}
			result = icon;
		}
		return (GimmickIcon)result;
	}

	protected void disableTouchMarker()
	{
		GimmickIconSystem instance = GimmickIconSystem.Instance;
		if ((bool)instance)
		{
			instance.disableAll();
		}
	}

	protected void disableTouchMarker(Component obj)
	{
		disableTouchMarker(obj.gameObject);
	}

	protected void disableTouchMarker(GameObject obj)
	{
		GimmickIconSystem instance = GimmickIconSystem.Instance;
		if ((bool)instance)
		{
			instance.disable(obj);
		}
	}

	public static void DisableHUD()
	{
		BattleHUD.ActivateAllButtons(b: false);
	}

	public static void EnableHUD()
	{
		BattleHUD.ActivateAllButtons(b: true);
	}

	public static CollisionMessage CreateTouchArea(string prefabPath, Transform target)
	{
		GameObject obj = GameAssetModule.InstantiatePrefab(prefabPath);
		return SetTouchArea(obj, target);
	}

	public static CollisionMessage CreateTouchArea(string prefabPath)
	{
		return CreateTouchArea(prefabPath, Player.transform);
	}

	public static CollisionMessage SetTouchArea(string path)
	{
		return SetTouchArea(path, Player.transform);
	}

	public static CollisionMessage SetTouchArea(string path, Transform target)
	{
		return SetTouchArea(GameObject.Find(path), target);
	}

	public static CollisionMessage SetTouchArea(GameObject obj, Transform target)
	{
		if (!(obj != null) || !(target != null))
		{
			throw new AssertionFailedException(new StringBuilder("obj(").Append(obj).Append(")/target(").Append(target)
				.Append(")がnull")
				.ToString());
		}
		CollisionMessage collisionMessage = ExtensionsModule.SetComponent<CollisionMessage>(obj);
		collisionMessage.target = target;
		collisionMessage.trigger = CollisionMessage.Trigger.EnterExit;
		return collisionMessage;
	}

	public static EventWindow.Window OpenChatWindow(int windowType)
	{
		BattleHUD.TutorialWindow = true;
		EventWindow.Window window = EventWindow.GetWindow(windowType);
		if (window == null)
		{
			window = EventWindow.OpenEventWindow(windowType);
			if (window == null)
			{
				throw new AssertionFailedException("EventWindow開けない");
			}
		}
		window.HideLastPageNextButton = false;
		eventChatWindows[windowType] = 1;
		return window;
	}

	public static void CloseChatWindow()
	{
		int[] array = (int[])Builtins.array(typeof(int), eventChatWindows.Keys);
		int i = 0;
		int[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			EventWindow.GetWindow(array2[i])?.Close(callCloseHandler: true);
			eventChatWindows.Remove(array2[i]);
		}
	}

	public static void SetChatWindow(string[][] chatList, object windowType)
	{
		if (!(chatList == null) && chatList.Length > 0)
		{
			EventWindow.Window window = OpenChatWindow(RuntimeServices.UnboxInt32(windowType));
			if (window == null)
			{
				throw new AssertionFailedException(new StringBuilder("EventWindow開けない,").Append(chatList.ToString()).Append(", ").Append(windowType)
					.ToString());
			}
			if (window != null)
			{
				window.TextFinishAutoClose = false;
				window.Init(chatList);
			}
		}
	}

	public static bool IsEndOfChat(int wndType)
	{
		EventWindow.Window window = EventWindow.GetWindow(wndType);
		int num;
		if (window == null)
		{
			num = 1;
		}
		else
		{
			num = (window.TextFinish ? 1 : 0);
			if (num != 0)
			{
				num = (window.CloseFlag ? 1 : 0);
			}
		}
		return (byte)num != 0;
	}

	public static void ActivateMyHomeUI(bool b)
	{
		MyHomeUIObj.show(b);
	}

	public NPCControl findNPC(int npcID)
	{
		int num = 0;
		NPCControl[] array = (NPCControl[])UnityEngine.Object.FindObjectsOfType(typeof(NPCControl));
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].npcID == npcID)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (NPCControl)result;
	}

	public bool near(GameObject o1, GameObject o2, float dist)
	{
		int result;
		if (o1 == null || o2 == null)
		{
			result = 0;
		}
		else
		{
			float num = Vector3.Distance(o2.transform.position, o1.transform.position);
			result = ((num < dist) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool nearPlayer(GameObject o)
	{
		return !(Player == null) && !(o == null) && near(Player.gameObject, o, dispIconPlayerDistance);
	}

	public bool nearPlayer(Component c)
	{
		return !(Player == null) && !(c == null) && near(Player.gameObject, c.gameObject, dispIconPlayerDistance);
	}

	public bool nearPlayer(GameObject o, float dist)
	{
		return !(Player == null) && !(o == null) && near(Player.gameObject, o, dist);
	}

	public IEnumerator S540_chat(string speaker, string message, int windowType)
	{
		return new _0024S540_chat_002419786(speaker, message, windowType).GetEnumerator();
	}

	public IEnumerator S540_chat_close()
	{
		return new _0024S540_chat_close_002419794().GetEnumerator();
	}

	public IEnumerable<object> S540_konnichiwa(Component c1, float time)
	{
		return new _0024S540_konnichiwa_002419795(c1, time, this);
	}

	public IEnumerable<object> S540_cutscene(string cutSceneName)
	{
		return new _0024S540_cutscene_002419803(cutSceneName);
	}

	public void lookAt(Component c, Vector3 pos, float time)
	{
		GameObject target = c.gameObject;
		iTween.LookTo(target, pos, time);
	}

	public void objOff(string path)
	{
		GameObject gameObject = GameObject.Find(path);
		if (!(gameObject == null))
		{
			gameObject.SetActive(value: false);
		}
	}

	public void objOn(string path)
	{
		GameObject gameObject = GameObject.Find(path);
		if (!(gameObject == null))
		{
			gameObject.SetActive(value: true);
		}
	}

	internal bool _0024set_DispIconPlayerDistance_0024closure_00242923(GameObject tobj)
	{
		return nearPlayer(tobj);
	}

	internal bool _0024enableObjectTouchMarker_0024closure_00242926(GameObject tobj)
	{
		return nearPlayer(tobj);
	}
}
