using System;
using System.Collections;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MerlinMotionPackEffectLoader : D540DepthFirstTraverser
{
	[Serializable]
	internal class _0024inOpePrefab_0024locals_002414271
	{
		internal MerlinMotionPack.EffectEntry _0024efEntry;
	}

	[Serializable]
	internal class _0024inOpePrefab_0024closure_00243820
	{
		internal MerlinMotionPackEffectLoader _0024this_002414591;

		internal _0024inOpePrefab_0024locals_002414271 _0024_0024locals_002414592;

		public _0024inOpePrefab_0024closure_00243820(MerlinMotionPackEffectLoader _0024this_002414591, _0024inOpePrefab_0024locals_002414271 _0024_0024locals_002414592)
		{
			this._0024this_002414591 = _0024this_002414591;
			this._0024_0024locals_002414592 = _0024_0024locals_002414592;
		}

		public void Invoke(GameObject obj)
		{
			_0024_0024locals_002414592._0024efEntry.obj = obj;
			_0024this_002414591.loadedEffects.Add(_0024_0024locals_002414592._0024efEntry);
		}
	}

	private MerlinMotionPack motPack;

	private MerlinMotionPack.Entry[] entries;

	private List<MerlinMotionPack.EffectEntry> requestedEffects;

	private List<MerlinMotionPack.EffectEntry> loadedEffects;

	public bool IsLoaded => ((ICollection)requestedEffects).Count <= ((ICollection)loadedEffects).Count;

	public MerlinMotionPackEffectLoader(MerlinMotionPack _motPack, MerlinMotionPack.Entry[] _entries)
	{
		requestedEffects = new List<MerlinMotionPack.EffectEntry>();
		loadedEffects = new List<MerlinMotionPack.EffectEntry>();
		motPack = _motPack;
		entries = _entries;
	}

	public override string ToString()
	{
		return (!(motPack == null)) ? new StringBuilder("MMPEffLoader(").Append(motPack).Append(")").ToString() : "MMPEffLoader(pack=<null>)";
	}

	public void load()
	{
		if (!(motPack == null) && !(entries == null))
		{
			int i = 0;
			MerlinMotionPack.Entry[] array = entries;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				load(array[i]);
			}
		}
	}

	private void load(MerlinMotionPack.Entry e)
	{
		if (e == null || e.clip == null)
		{
			return;
		}
		if (e.code != null)
		{
			e.code.apply(this);
		}
		if (e.motDefMethodArgs != null)
		{
			int i = 0;
			D540OpeCode[] motDefMethodArgs = e.motDefMethodArgs;
			for (int length = motDefMethodArgs.Length; i < length; i = checked(i + 1))
			{
				motDefMethodArgs[i].apply(this);
			}
		}
	}

	public override bool inOpePrefab(D540OpePrefab node)
	{
		_0024inOpePrefab_0024locals_002414271 _0024inOpePrefab_0024locals_0024 = new _0024inOpePrefab_0024locals_002414271();
		string prefabName = node.PrefabName;
		_0024inOpePrefab_0024locals_0024._0024efEntry = motPack.getEffectEntry(prefabName);
		if (_0024inOpePrefab_0024locals_0024._0024efEntry != null && _0024inOpePrefab_0024locals_0024._0024efEntry.obj == null)
		{
			requestedEffects.Add(_0024inOpePrefab_0024locals_0024._0024efEntry);
			RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
			instance.loadPrefab(prefabName, new _0024inOpePrefab_0024closure_00243820(this, _0024inOpePrefab_0024locals_0024).Invoke);
		}
		return false;
	}
}
