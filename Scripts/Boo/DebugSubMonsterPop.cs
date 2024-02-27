using System;
using System.Text;
using Boo.Lang.Runtime;

[Serializable]
public class DebugSubMonsterPop : RuntimeDebugModeGuiMixin
{
	[NonSerialized]
	private const string MONSTER_PREFAB_PATH = "Prefab/Character/Monster/";

	protected int select;

	public override void OnGUI()
	{
		RuntimeDebugModeGuiMixin.label("モンスター生成：Merlinシーンでのみ使用して下さい。");
		MMonsters[] array = ArrayMap.FilterAllMMonsters((MMonsters m) => !string.IsNullOrEmpty(m.PrefabName));
		string[] texts = ArrayMap.AllMMonstersToStr((MMonsters m) => new StringBuilder().Append((object)m.Id).Append(":").Append(m.Name)
			.ToString());
		int num = RuntimeDebugModeGuiMixin.grid(select, texts, 2);
		if (num != select)
		{
			select = num;
			string prefabName = "Prefab/Character/Monster/" + array[RuntimeServices.NormalizeArrayIndex(array, num)].PrefabName;
			RuntimeAssetBundleDB.Instance.instantiatePrefab(prefabName);
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
	}

	public override void Exit()
	{
	}

	internal bool _0024OnGUI_0024closure_00243467(MMonsters m)
	{
		return !string.IsNullOrEmpty(m.PrefabName);
	}

	internal string _0024OnGUI_0024closure_00243468(MMonsters m)
	{
		return new StringBuilder().Append((object)m.Id).Append(":").Append(m.Name)
			.ToString();
	}
}
