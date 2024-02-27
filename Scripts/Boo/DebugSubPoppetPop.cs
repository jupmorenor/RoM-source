using System;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubPoppetPop : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024OnGUI_0024locals_002414307
	{
		internal MPoppets[] _0024allPoppets;

		internal int _0024n;
	}

	[Serializable]
	internal class _0024OnGUI_0024closure_00243471
	{
		internal _0024OnGUI_0024locals_002414307 _0024_0024locals_002414716;

		internal DebugSubPoppetPop _0024this_002414717;

		public _0024OnGUI_0024closure_00243471(_0024OnGUI_0024locals_002414307 _0024_0024locals_002414716, DebugSubPoppetPop _0024this_002414717)
		{
			this._0024_0024locals_002414716 = _0024_0024locals_002414716;
			this._0024this_002414717 = _0024this_002414717;
		}

		public void Invoke(GameObject go)
		{
			AIControl component = go.GetComponent<AIControl>();
			if (component != null)
			{
				MPoppets[] _0024allPoppets = _0024_0024locals_002414716._0024allPoppets;
				component.PoppetData = new RespPoppet(_0024allPoppets[RuntimeServices.NormalizeArrayIndex(_0024allPoppets, _0024_0024locals_002414716._0024n)]);
				component.transform.position = _0024this_002414717.playerControl.transform.position;
				List<AIControl> list = new List<AIControl>();
				if (_0024this_002414717.playerControl.PoppetNum >= 2)
				{
					list.Add(_0024this_002414717.playerControl.Poppets[1]);
					UnityEngine.Object.Destroy(_0024this_002414717.playerControl.Poppets[0]);
				}
				list.Add(component);
				_0024this_002414717.playerControl.setPoppets((AIControl[])Builtins.array(typeof(AIControl), list));
			}
		}
	}

	[NonSerialized]
	private const string POPPET_PREFAB_PATH = "Prefab/Character/Tukaima/";

	protected int select;

	private GameObject playerObj;

	private PlayerControl playerControl;

	public override void OnGUI()
	{
		_0024OnGUI_0024locals_002414307 _0024OnGUI_0024locals_0024 = new _0024OnGUI_0024locals_002414307();
		RuntimeDebugModeGuiMixin.label("魔ペット生成：Merlinシーンでのみ使用して下さい。");
		_0024OnGUI_0024locals_0024._0024allPoppets = ArrayMap.FilterAllMPoppets((MPoppets m) => !string.IsNullOrEmpty(m.PrefabName));
		MRares[] array = (MRares[])Builtins.array(typeof(MRares), MRares.All);
		if (playerObj == null)
		{
			playerObj = PlayerControl.CurrentPlayerGO;
			if ((bool)playerObj)
			{
				playerControl = playerObj.GetComponent<PlayerControl>();
			}
		}
		if (playerObj == null)
		{
			return;
		}
		int i = 0;
		AIControl[] poppets = playerControl.Poppets;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			string text = poppets[i].namae + "を削除";
			if (RuntimeDebugModeGuiMixin.button(text))
			{
				playerControl.deletePoppet(poppets[i]);
				if (poppets[i] != null)
				{
					UnityEngine.Object.Destroy(poppets[i].gameObject);
				}
			}
		}
		RuntimeDebugModeGuiMixin.space(20);
		string[] texts = ArrayMap.AllMPoppetsToStr((MPoppets m) => new StringBuilder().Append((object)m.Id).Append(":").Append(m.Name)
			.Append(":")
			.Append(m.Rare.Abbr)
			.ToString());
		_0024OnGUI_0024locals_0024._0024n = RuntimeDebugModeGuiMixin.grid(select, texts, 2);
		if (_0024OnGUI_0024locals_0024._0024n != select)
		{
			select = _0024OnGUI_0024locals_0024._0024n;
			MPoppets[] _0024allPoppets = _0024OnGUI_0024locals_0024._0024allPoppets;
			string prefabName = "Prefab/Character/Tukaima/" + _0024allPoppets[RuntimeServices.NormalizeArrayIndex(_0024allPoppets, _0024OnGUI_0024locals_0024._0024n)].PrefabName;
			RuntimeAssetBundleDB.Instance.instantiatePrefab(prefabName, new _0024OnGUI_0024closure_00243471(_0024OnGUI_0024locals_0024, this).Invoke);
		}
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
		playerObj = PlayerControl.CurrentPlayerGO;
		if ((bool)playerObj)
		{
			playerControl = playerObj.GetComponent<PlayerControl>();
		}
	}

	public override void Exit()
	{
	}

	internal bool _0024OnGUI_0024closure_00243469(MPoppets m)
	{
		return !string.IsNullOrEmpty(m.PrefabName);
	}

	internal string _0024OnGUI_0024closure_00243470(MPoppets m)
	{
		return new StringBuilder().Append((object)m.Id).Append(":").Append(m.Name)
			.Append(":")
			.Append(m.Rare.Abbr)
			.ToString();
	}
}
