using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class RuntimeAssetBundleDBTest : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadObjectTest_002415325 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002415326;

			internal RuntimeAssetBundleDB.Req _0024req_002415327;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002415326 = RuntimeAssetBundleDB.Instance;
					_0024req_002415327 = _0024abdb_002415326.loadPrefab("testcube1");
					goto case 2;
				case 2:
					if (!_0024req_002415327.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Instantiate(_0024req_002415327.Prefab);
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
	internal sealed class _0024loadAndUnloadTest_002415328 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002415329;

			internal RuntimeAssetBundleDB.Req _0024r1_002415330;

			internal RuntimeAssetBundleDB.Req _0024r2_002415331;

			internal string[] _0024bs_002415332;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002415329 = RuntimeAssetBundleDB.Instance;
					_0024r1_002415330 = _0024abdb_002415329.loadPrefab("testcube1");
					goto case 2;
				case 2:
					if (!_0024r1_002415330.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024r1_002415330.Prefab != null))
					{
						throw new AssertionFailedException("r1.Prefab != null");
					}
					_0024r2_002415331 = _0024abdb_002415329.loadPrefab("testcube2");
					goto case 3;
				case 3:
					if (!_0024r2_002415331.IsOk)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!(_0024r2_002415331.Prefab != null))
					{
						throw new AssertionFailedException("r2.Prefab != null");
					}
					_0024bs_002415332 = AssetBundleLoader.OpenedBundleNames;
					if (_0024bs_002415332.Length != 2)
					{
						throw new AssertionFailedException("len(bs) == 2");
					}
					if (!RuntimeServices.op_Member("test1", _0024bs_002415332))
					{
						throw new AssertionFailedException("'test1' in bs");
					}
					if (!RuntimeServices.op_Member("test2", _0024bs_002415332))
					{
						throw new AssertionFailedException("'test2' in bs");
					}
					_0024bs_002415332 = AssetBundleLoader.OpenedBundleNames;
					if (_0024bs_002415332.Length != 0)
					{
						throw new AssertionFailedException(new StringBuilder("bs=").Append(Builtins.join(_0024bs_002415332)).ToString());
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadTypedAssets_002415333 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002415334;

			internal RuntimeAssetBundleDB.Req _0024r1_002415335;

			internal RuntimeAssetBundleDB.Req _0024r2_002415336;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002415334 = RuntimeAssetBundleDB.Instance;
					_0024r1_002415335 = _0024abdb_002415334.loadAsset("testmaterial1");
					goto case 2;
				case 2:
					if (!_0024r1_002415335.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024r1_002415335.Asset is Material))
					{
						throw new AssertionFailedException("r1.Asset isa Material");
					}
					_0024r2_002415336 = _0024abdb_002415334.loadAsset("testbinary1", typeof(TextAsset));
					goto case 3;
				case 3:
					if (!_0024r2_002415336.IsOk)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!(_0024r2_002415336.Asset is TextAsset))
					{
						throw new AssertionFailedException("r2.Asset isa TextAsset");
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadFromResources_002415337 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002415338;

			internal RuntimeAssetBundleDB.Req _0024r1_002415339;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002415338 = RuntimeAssetBundleDB.Instance;
					_0024r1_002415339 = _0024abdb_002415338.loadAsset("Misc/PlayerAttackAndHpForDebug");
					goto case 2;
				case 2:
					if (!_0024r1_002415339.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024r1_002415339.IsOk)
					{
						throw new AssertionFailedException(new StringBuilder("error: ").Append(_0024r1_002415339.Error).ToString());
					}
					if (!(_0024r1_002415339.Asset is TextAsset))
					{
						throw new AssertionFailedException("r1.Asset isa TextAsset");
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	public void Start()
	{
	}

	public void OnGUI()
	{
		if (GUILayout.Button("DB test"))
		{
			testDB();
		}
		if (GUILayout.Button("DB load object test"))
		{
			IEnumerator enumerator = loadObjectTest();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
		if (GUILayout.Button("DB unload test"))
		{
			IEnumerator enumerator2 = loadAndUnloadTest();
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
		if (GUILayout.Button("typed asset load"))
		{
			IEnumerator enumerator3 = loadTypedAssets();
			if (enumerator3 != null)
			{
				StartCoroutine(enumerator3);
			}
		}
		if (GUILayout.Button("load from Resources/"))
		{
			IEnumerator enumerator4 = loadFromResources();
			if (enumerator4 != null)
			{
				StartCoroutine(enumerator4);
			}
		}
	}

	private void testDB()
	{
		RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
		if (!(instance != null))
		{
			throw new AssertionFailedException("abdb != null");
		}
		string[] array = instance.allBundleNamesOf("testmaterial1", string.Empty);
		if (array.Length != 1)
		{
			throw new AssertionFailedException(new StringBuilder("lens(s)!=1 -- ").Append(Builtins.join(array)).ToString());
		}
		if (!(array[0] == "test1"))
		{
			throw new AssertionFailedException("s[0] == 'test1'");
		}
		array = instance.allBundleNamesOf("testmaterial2", typeof(Material));
		if (array.Length != 1)
		{
			throw new AssertionFailedException(new StringBuilder("lens(s)!=1 -- ").Append(Builtins.join(array)).ToString());
		}
		if (!(array[0] == "test2"))
		{
			throw new AssertionFailedException("s[0] == 'test2'");
		}
		array = instance.allBundleNamesOf("abcde", string.Empty);
		if (array.Length != 0)
		{
			throw new AssertionFailedException(new StringBuilder("len(s)!=0 -- ").Append(Builtins.join(array)).ToString());
		}
	}

	private IEnumerator loadObjectTest()
	{
		return new _0024loadObjectTest_002415325().GetEnumerator();
	}

	private IEnumerator loadAndUnloadTest()
	{
		return new _0024loadAndUnloadTest_002415328().GetEnumerator();
	}

	public IEnumerator loadTypedAssets()
	{
		return new _0024loadTypedAssets_002415333().GetEnumerator();
	}

	public IEnumerator loadFromResources()
	{
		return new _0024loadFromResources_002415337().GetEnumerator();
	}
}
