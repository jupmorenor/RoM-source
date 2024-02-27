using System;
using Boo.Lang.Runtime;
using UnityEngine;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024EventHandler_0024179
{
	protected __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _0024from;

	public _0024adaptor_0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024EventHandler_0024179(__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ from)
	{
		_0024from = from;
	}

	public void Invoke(object arg0)
	{
		__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ = _0024from;
		object obj = arg0;
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__((GameObject)obj);
	}

	public static UpdateManager.EventHandler Adapt(__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ from)
	{
		return new _0024adaptor_0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024EventHandler_0024179(from).Invoke;
	}
}
