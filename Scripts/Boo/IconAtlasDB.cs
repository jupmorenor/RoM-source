using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class IconAtlasDB : MonoBehaviour
{
	[Serializable]
	internal class _0024loadDBJson_0024locals_002414471
	{
		internal string _0024atlasName;
	}

	[Serializable]
	internal class _0024loadDBJson_0024closure_00245006
	{
		internal IconAtlasDB _0024this_002415041;

		internal _0024loadDBJson_0024locals_002414471 _0024_0024locals_002415042;

		public _0024loadDBJson_0024closure_00245006(IconAtlasDB _0024this_002415041, _0024loadDBJson_0024locals_002414471 _0024_0024locals_002415042)
		{
			this._0024this_002415041 = _0024this_002415041;
			this._0024_0024locals_002415042 = _0024_0024locals_002415042;
		}

		public void Invoke(string sprName)
		{
			_0024this_002415041.spriteNameToAtlas[sprName] = _0024_0024locals_002415042._0024atlasName;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadDBMain_002421356 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002421357;

			internal RuntimeAssetBundleDB.Req _0024r_002421358;

			internal TextAsset _0024tasset_002421359;

			internal Hashtable _0024hash_002421360;

			internal string _0024iname_002421361;

			internal string _0024atname_002421362;

			internal Hashtable _0024atlasHash_002421363;

			internal IEnumerator _0024_0024iterator_002414085_002421364;

			internal IconAtlasDB _0024self__002421365;

			public _0024(IconAtlasDB self_)
			{
				_0024self__002421365 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002421365.loadingNum++;
						_0024abdb_002421357 = RuntimeAssetBundleDB.Instance;
						_0024r_002421358 = _0024abdb_002421357.loadAsset("IconAtlasDBJSON.txt", typeof(TextAsset));
						goto case 2;
					case 2:
						if (!_0024r_002421358.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024r_002421358.IsOk)
						{
							_0024tasset_002421359 = _0024r_002421358.Asset as TextAsset;
							_0024hash_002421360 = NGUIJson.jsonDecode(_0024tasset_002421359.text) as Hashtable;
							if (_0024hash_002421360 != null)
							{
								_0024_0024iterator_002414085_002421364 = _0024hash_002421360.Keys.GetEnumerator();
								while (_0024_0024iterator_002414085_002421364.MoveNext())
								{
									object obj = _0024_0024iterator_002414085_002421364.Current;
									if (!(obj is string))
									{
										obj = RuntimeServices.Coerce(obj, typeof(string));
									}
									_0024iname_002421361 = (string)obj;
									if (!string.IsNullOrEmpty(_0024iname_002421361))
									{
										_0024atname_002421362 = _0024self__002421365.toAtlasName(_0024iname_002421361);
										_0024atlasHash_002421363 = _0024hash_002421360[_0024iname_002421361] as Hashtable;
										if (_0024atlasHash_002421363 != null)
										{
											_0024self__002421365.loadDBJson(_0024atname_002421362, _0024atlasHash_002421363);
										}
									}
								}
							}
						}
						_0024self__002421365.loadingNum--;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal IconAtlasDB _0024self__002421366;

		public _0024loadDBMain_002421356(IconAtlasDB self_)
		{
			_0024self__002421366 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421366);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadMain_002421367 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002421368;

			internal string _0024txtName_002421369;

			internal RuntimeAssetBundleDB.Req _0024r_002421370;

			internal TextAsset _0024tasset_002421371;

			internal string _0024atlasName_002421372;

			internal string _0024txtAssetPath_002421373;

			internal IconAtlasDB _0024self__002421374;

			public _0024(string atlasName, string txtAssetPath, IconAtlasDB self_)
			{
				_0024atlasName_002421372 = atlasName;
				_0024txtAssetPath_002421373 = txtAssetPath;
				_0024self__002421374 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002421374.loadingNum++;
						_0024abdb_002421368 = RuntimeAssetBundleDB.Instance;
						_0024txtName_002421369 = Path.GetFileNameWithoutExtension(_0024txtAssetPath_002421373);
						_0024r_002421370 = _0024abdb_002421368.loadAsset(_0024txtName_002421369, typeof(TextAsset));
						goto case 2;
					case 2:
						if (!_0024r_002421370.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024r_002421370.IsOk)
						{
							_0024tasset_002421371 = _0024r_002421370.Asset as TextAsset;
							if (_0024tasset_002421371 != null)
							{
								_0024self__002421374.loadDBJson(_0024atlasName_002421372, _0024tasset_002421371.text);
							}
						}
						_0024self__002421374.loadingNum--;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024atlasName_002421375;

		internal string _0024txtAssetPath_002421376;

		internal IconAtlasDB _0024self__002421377;

		public _0024loadMain_002421367(string atlasName, string txtAssetPath, IconAtlasDB self_)
		{
			_0024atlasName_002421375 = atlasName;
			_0024txtAssetPath_002421376 = txtAssetPath;
			_0024self__002421377 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024atlasName_002421375, _0024txtAssetPath_002421376, _0024self__002421377);
		}
	}

	[NonSerialized]
	public const string DB_FILENAME = "IconAtlasDBJSON.txt";

	private Dictionary<string, string> spriteNameToAtlas;

	private int loadingNum;

	public bool IsBusy => loadingNum > 0;

	public Dictionary<string, string> SpriteNameToAtlas => spriteNameToAtlas;

	public IconAtlasDB()
	{
		spriteNameToAtlas = new Dictionary<string, string>();
	}

	public void loadDB()
	{
		IEnumerator enumerator = loadDBMain();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator loadDBMain()
	{
		return new _0024loadDBMain_002421356(this).GetEnumerator();
	}

	public void loadDBFromAssetPack(AssetPack assetPack)
	{
		if (assetPack == null)
		{
			return;
		}
		clear();
		int i = 0;
		string[] paths = assetPack.paths;
		for (int length = paths.Length; i < length; i = checked(i + 1))
		{
			if (!paths[i].ToLower().EndsWith(".txt"))
			{
				continue;
			}
			string text = toAtlasName(paths[i]);
			if (!string.IsNullOrEmpty(text))
			{
				IEnumerator enumerator = loadMain(text, paths[i]);
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
			}
		}
	}

	private void clear()
	{
		spriteNameToAtlas.Clear();
	}

	private IEnumerator loadMain(string atlasName, string txtAssetPath)
	{
		return new _0024loadMain_002421367(atlasName, txtAssetPath, this).GetEnumerator();
	}

	private string toAtlasName(string txtFilePath)
	{
		object result;
		if (string.IsNullOrEmpty(txtFilePath))
		{
			result = null;
		}
		else
		{
			string text = Path.GetFileNameWithoutExtension(txtFilePath).ToLower();
			if (text.StartsWith("icon_poppet"))
			{
				string value = text.Substring(11);
				result = new StringBuilder("IconPoppet").Append(value).Append("Atlas").ToString();
			}
			else if (text.StartsWith("icon_weapon_"))
			{
				string value = text.Substring(12);
				result = new StringBuilder("IconWeapon").Append(value.ToUpper()).Append("Atlas").ToString();
			}
			else if (text.StartsWith("icon_skill"))
			{
				string value = text.Substring(10);
				result = new StringBuilder("IconSkill").Append(value).Append("Atlas").ToString();
			}
			else
			{
				result = null;
			}
		}
		return (string)result;
	}

	private void loadDBJson(string atlasName, string json)
	{
		if (!string.IsNullOrEmpty(atlasName) && !string.IsNullOrEmpty(json))
		{
			if (!(NGUIJson.jsonDecode(json) is Hashtable hashtable) || !hashtable.ContainsKey("frames") || !(hashtable["frames"] is Hashtable))
			{
				throw new AssertionFailedException("((hash != null) and hash.ContainsKey('frames')) and (hash['frames'] isa Hashtable)");
			}
			loadDBJson(atlasName, hashtable);
		}
	}

	private void loadDBJson(string atlasName, Hashtable hash)
	{
		_0024loadDBJson_0024locals_002414471 _0024loadDBJson_0024locals_0024 = new _0024loadDBJson_0024locals_002414471();
		_0024loadDBJson_0024locals_0024._0024atlasName = atlasName;
		if (!string.IsNullOrEmpty(_0024loadDBJson_0024locals_0024._0024atlasName) && hash != null)
		{
			EachFrameSectionInJson(hash, new _0024loadDBJson_0024closure_00245006(this, _0024loadDBJson_0024locals_0024).Invoke);
		}
	}

	public static void EachFrameSectionInJson(Hashtable hash, __Req_FailHandler_0024callable6_0024440_32__ c)
	{
		if (hash == null || c == null)
		{
			return;
		}
		if (!hash.ContainsKey("frames") || !(hash["frames"] is Hashtable))
		{
			throw new AssertionFailedException("hash.ContainsKey('frames') and (hash['frames'] isa Hashtable)");
		}
		Hashtable hashtable = hash["frames"] as Hashtable;
		IEnumerator enumerator = hashtable.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			if (!string.IsNullOrEmpty(text))
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				if (!string.IsNullOrEmpty(fileNameWithoutExtension))
				{
					c(fileNameWithoutExtension);
				}
			}
		}
	}

	public void dump()
	{
		string lhs = string.Empty;
		foreach (string key in spriteNameToAtlas.Keys)
		{
			lhs += new StringBuilder().Append(key).Append("=").Append(spriteNameToAtlas[key])
				.Append(",")
				.ToString();
		}
	}

	public string atlasNameOfSprite(string spriteName)
	{
		return (!spriteNameToAtlas.ContainsKey(spriteName)) ? null : spriteNameToAtlas[spriteName];
	}

	public string[] atlasNamesOfSprites(string[] spriteNames)
	{
		HashSet<string> hashSet = new HashSet<string>();
		int i = 0;
		for (int length = spriteNames.Length; i < length; i = checked(i + 1))
		{
			string text = atlasNameOfSprite(spriteNames[i]);
			if (!string.IsNullOrEmpty(text))
			{
				hashSet.Add(text);
			}
		}
		return (string[])Builtins.array(typeof(string), hashSet);
	}
}
