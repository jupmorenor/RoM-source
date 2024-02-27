using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using ObjUtil;
using UnityEngine;

[Serializable]
public class CutSceneManager : MonoBehaviour
{
	[Serializable]
	private enum PlaybackMode
	{
		normal,
		fast,
		skip,
		pause,
		jump
	}

	[Serializable]
	private enum RotDir
	{
		None = 0,
		Left = 1,
		Right = -1
	}

	[Serializable]
	private enum MotModeType
	{
		now,
		next
	}

	[Serializable]
	private struct MotCommand
	{
		public int id;

		public MotModeType type;

		public int fcount;

		[NonSerialized]
		internal static Regex _0024re_002424724 = new Regex("\\*");

		[NonSerialized]
		internal static Regex _0024re_002424725 = new Regex("\\*");
	}

	[Serializable]
	internal class _0024CutScene_0024locals_002414387
	{
		internal CutSceneManager _0024cutScenMan;
	}

	[Serializable]
	internal class _0024loadAssetBundle_0024locals_002414388
	{
		internal bool _0024isCutScene;

		internal int _0024n;
	}

	[Serializable]
	internal class _0024AnimPlay_0024locals_002414389
	{
		internal int _0024instId;

		internal Hashtable _0024tab;

		internal GameObject _0024obj;
	}

	[Serializable]
	internal class _0024StringApplyLangageAndGender_0024locals_002414390
	{
		internal bool _0024isPlayerTalking;

		internal string _0024rawTitle;
	}

	[Serializable]
	internal class _0024MOVE_TARGET_core_0024locals_002414391
	{
		internal GameObject _0024target;

		internal string _0024motionName;

		internal string _0024idlingName;

		internal Transform _0024parent;

		internal bool _0024willAnimated;

		internal Vector3 _0024pos;

		internal int _0024lastMoveWaitCount;

		internal CharacterController _0024cc;
	}

	[Serializable]
	internal class _0024ROTATE_TARGET_core_0024locals_002414392
	{
		internal GameObject _0024target;

		internal string _0024motionName;

		internal string _0024idlingName;

		internal float _0024rotY;

		internal Transform _0024parent;

		internal bool _0024willAnimated;

		internal int _0024lastMoveWaitCount;
	}

	[Serializable]
	internal class _0024MOVE_ROTATE_core_0024locals_002414393
	{
		internal GameObject _0024target;

		internal string _0024motionName;

		internal string _0024idlingName;

		internal float _0024rotY;

		internal Transform _0024parent;

		internal bool _0024willAnimated;

		internal Vector3 _0024pos;

		internal int _0024lastMoveWaitCount;

		internal CharacterController _0024cc;
	}

	[Serializable]
	internal class _0024PLAYER_CHR_INIT_core_0024locals_002414394
	{
		internal bool _0024spawnIsBusy;
	}

	[Serializable]
	internal class _0024registerSETable_0024locals_002414395
	{
		internal int _0024id;
	}

	[Serializable]
	internal class _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_002414396
	{
		internal Hashtable _0024tab;
	}

	[Serializable]
	internal class _0024CutScene_0024closure_00242913
	{
		internal _0024CutScene_0024locals_002414387 _0024_0024locals_002414889;

		public _0024CutScene_0024closure_00242913(_0024CutScene_0024locals_002414387 _0024_0024locals_002414889)
		{
			this._0024_0024locals_002414889 = _0024_0024locals_002414889;
		}

		public void Invoke(bool ok)
		{
			if (ok && _0024_0024locals_002414889._0024cutScenMan.isLoad)
			{
				if (_0024_0024locals_002414889._0024cutScenMan.autoStartFlag)
				{
					_0024_0024locals_002414889._0024cutScenMan.StartCutScene();
				}
			}
			else
			{
				_0024_0024locals_002414889._0024cutScenMan.isBusy = false;
			}
		}
	}

	[Serializable]
	internal class _0024loadAssetBundle_0024closure_00243790
	{
		internal CutSceneManager _0024this_002414890;

		internal _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414891;

		public _0024loadAssetBundle_0024closure_00243790(CutSceneManager _0024this_002414890, _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414891)
		{
			this._0024this_002414890 = _0024this_002414890;
			this._0024_0024locals_002414891 = _0024_0024locals_002414891;
		}

		public void Invoke(bool ok)
		{
			if (ok && _0024this_002414890.isLoad)
			{
				_0024_0024locals_002414891._0024isCutScene = true;
				_0024this_002414890.postprocessReadCutsceneScript();
				_0024this_002414890.nowLoading = false;
			}
			else
			{
				_0024this_002414890.nowLoading = false;
				Loading.End();
				Abort();
			}
		}
	}

	[Serializable]
	internal class _0024loadAssetBundle_0024closure_00243791
	{
		internal CutSceneManager _0024this_002414892;

		internal _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414893;

		public _0024loadAssetBundle_0024closure_00243791(CutSceneManager _0024this_002414892, _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414893)
		{
			this._0024this_002414892 = _0024this_002414892;
			this._0024_0024locals_002414893 = _0024_0024locals_002414893;
		}

		public void Invoke(RuntimeAssetBundleDB.Req req, UnityEngine.Object o)
		{
			checked
			{
				if (o is GameObject)
				{
					GameObject gameObject = _0024this_002414892._instantiateOrReUseSceneGameObject(o as GameObject) as GameObject;
					destroyThisTimed component = gameObject.GetComponent<destroyThisTimed>();
					if ((bool)component)
					{
						gameObject.SetActive(value: false);
					}
					_0024this_002414892.SetupComponentForCutSceneAnim(gameObject);
				}
				else if (o is AnimationClip)
				{
					_0024this_002414892.loadObjectList.Add(o);
				}
				else if (o is TextAsset)
				{
					if (req.AssetPath.EndsWith("_se.txt"))
					{
						TextAsset textAsset = (TextAsset)o;
						string @string = Encoding.UTF8.GetString(textAsset.bytes);
						string[] array = @string.Split('\n');
						int i = 0;
						string[] array2 = array;
						for (int length = array2.Length; i < length; i++)
						{
							if (_0024this_002414892.gameSndmgr.LoadSe(array2[i]))
							{
								_0024this_002414892.seLoadList.Add(SQEX_SoundPlayerData.seNames[array2[i]]);
							}
						}
					}
					else
					{
						_0024this_002414892.loadObjectList.Add(o);
					}
				}
				_0024_0024locals_002414893._0024n++;
			}
		}
	}

	[Serializable]
	internal class _0024loadAssetBundle_0024closure_00243792
	{
		internal _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414894;

		public _0024loadAssetBundle_0024closure_00243792(_0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002414894)
		{
			this._0024_0024locals_002414894 = _0024_0024locals_002414894;
		}

		public void Invoke(string assetPath)
		{
			_0024_0024locals_002414894._0024n = checked(_0024_0024locals_002414894._0024n + 1);
		}
	}

	[Serializable]
	internal class _0024AnimPlay_0024_fix_to_otherobj_00243798
	{
		internal _0024AnimPlay_0024locals_002414389 _0024_0024locals_002414895;

		internal CutSceneManager _0024this_002414896;

		public _0024AnimPlay_0024_fix_to_otherobj_00243798(_0024AnimPlay_0024locals_002414389 _0024_0024locals_002414895, CutSceneManager _0024this_002414896)
		{
			this._0024_0024locals_002414895 = _0024_0024locals_002414895;
			this._0024this_002414896 = _0024this_002414896;
		}

		public void Invoke()
		{
			if (_0024_0024locals_002414895._0024tab == null)
			{
				return;
			}
			object obj = _0024_0024locals_002414895._0024tab["target"];
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			GameObject gameObject = (GameObject)obj;
			object obj2 = _0024_0024locals_002414895._0024tab["other"];
			if (!(obj2 is GameObject))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
			}
			GameObject gameObject2 = (GameObject)obj2;
			int num = RuntimeServices.UnboxInt32(_0024_0024locals_002414895._0024tab["count"]);
			if ((bool)gameObject && (bool)gameObject2 && gameObject == _0024_0024locals_002414895._0024obj)
			{
				if (num > 0)
				{
					num = checked(num - 1);
				}
				Vector3 position = gameObject2.transform.position;
				Quaternion rotation = gameObject2.transform.rotation;
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localEulerAngles = Vector3.zero;
				_0024_0024locals_002414895._0024obj.transform.position = position;
				_0024_0024locals_002414895._0024obj.transform.rotation = rotation;
				if (num == 0)
				{
					_0024this_002414896.animStartSetPosTab[_0024_0024locals_002414895._0024instId] = null;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024hasSpecialOne_00243800
	{
		internal _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_002414396 _0024_0024locals_002414897;

		public _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024hasSpecialOne_00243800(_0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_002414396 _0024_0024locals_002414897)
		{
			this._0024_0024locals_002414897 = _0024_0024locals_002414897;
		}

		public bool Invoke(string a)
		{
			int result;
			if (!_0024_0024locals_002414897._0024tab.ContainsKey(a))
			{
				result = 0;
			}
			else
			{
				object obj = _0024_0024locals_002414897._0024tab[a];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				result = ((!string.IsNullOrEmpty((string)obj)) ? 1 : 0);
			}
			return (byte)result != 0;
		}
	}

	[Serializable]
	internal class _0024StringApplyLangageAndGender_0024_apply_00243799
	{
		internal _0024StringApplyLangageAndGender_0024locals_002414390 _0024_0024locals_002414898;

		public _0024StringApplyLangageAndGender_0024_apply_00243799(_0024StringApplyLangageAndGender_0024locals_002414390 _0024_0024locals_002414898)
		{
			this._0024_0024locals_002414898 = _0024_0024locals_002414898;
		}

		public string Invoke(Hashtable tab)
		{
			_0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_002414396 _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024 = new _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_002414396();
			_0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024._0024tab = tab;
			__WebView_CommandLinkHandler_0024callable126_002420_34__ _WebView_CommandLinkHandler_0024callable126_002420_34__ = new _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024hasSpecialOne_00243800(_0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024).Invoke;
			string text = ((!_0024_0024locals_002414898._0024isPlayerTalking) ? CutSceneText.GetHeaderNameCurrentGender() : ((CutSceneText.getRaceFromTextTag(_0024_0024locals_002414898._0024rawTitle) != 0) ? CutSceneText.GetHeaderNameForDevil() : CutSceneText.GetHeaderNameForAngel()));
			if (string.IsNullOrEmpty(text))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(h)");
			}
			string empty = string.Empty;
			if (_WebView_CommandLinkHandler_0024callable126_002420_34__(text))
			{
				object obj = _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024._0024tab[text];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				empty = (string)obj;
			}
			else
			{
				object obj2 = _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024._0024tab[CutSceneText.GetHeaderNameCurrentLanguageCommon()];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				empty = (string)obj2;
			}
			if (string.IsNullOrEmpty(empty))
			{
				object obj3 = _0024_0024StringApplyLangageAndGender_0024_apply_00243799_0024locals_0024._0024tab["ja_m"];
				if (!(obj3 is string))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(string));
				}
				empty = (string)obj3;
			}
			if (string.IsNullOrEmpty(empty))
			{
				throw new AssertionFailedException(new StringBuilder("IsNullOrEmpty check 1 in CutSceneManager:\ns:").Append(empty).ToString());
			}
			string text2 = TextTagCheck.CheckPlayerName(empty);
			if (string.IsNullOrEmpty(text2))
			{
				throw new AssertionFailedException(new StringBuilder("IsNullOrEmpty check 2 in CutSceneManager:\ns:").Append(empty).Append("\ns2:").Append(text2)
					.ToString());
			}
			return text2;
		}
	}

	[Serializable]
	internal class _0024MOVE_TARGET_core_0024arrive_00243802
	{
		internal CutSceneManager _0024this_002414899;

		internal Vector3 _0024_002412432_002414900;

		internal _0024MOVE_TARGET_core_0024locals_002414391 _0024_0024locals_002414901;

		internal float _0024_002412431_002414902;

		internal Vector3 _0024_002412434_002414903;

		internal float _0024_002412433_002414904;

		public _0024MOVE_TARGET_core_0024arrive_00243802(CutSceneManager _0024this_002414899, Vector3 _0024_002412432_002414900, _0024MOVE_TARGET_core_0024locals_002414391 _0024_0024locals_002414901, float _0024_002412431_002414902, Vector3 _0024_002412434_002414903, float _0024_002412433_002414904)
		{
			this._0024this_002414899 = _0024this_002414899;
			this._0024_002412432_002414900 = _0024_002412432_002414900;
			this._0024_0024locals_002414901 = _0024_0024locals_002414901;
			this._0024_002412431_002414902 = _0024_002412431_002414902;
			this._0024_002412434_002414903 = _0024_002412434_002414903;
			this._0024_002412433_002414904 = _0024_002412433_002414904;
		}

		public void Invoke()
		{
			float num = (_0024_002412431_002414902 = _0024_0024locals_002414901._0024pos.x);
			Vector3 vector = (_0024_002412432_002414900 = _0024_0024locals_002414901._0024parent.position);
			float num2 = (_0024_002412432_002414900.x = _0024_002412431_002414902);
			Vector3 vector3 = (_0024_0024locals_002414901._0024parent.position = _0024_002412432_002414900);
			float num3 = (_0024_002412433_002414904 = _0024_0024locals_002414901._0024pos.z);
			Vector3 vector4 = (_0024_002412434_002414903 = _0024_0024locals_002414901._0024parent.position);
			float num4 = (_0024_002412434_002414903.z = _0024_002412433_002414904);
			Vector3 vector6 = (_0024_0024locals_002414901._0024parent.position = _0024_002412434_002414903);
			_0024_0024locals_002414901._0024lastMoveWaitCount = _0024this_002414899.moveWaitCount;
			if ((bool)_0024_0024locals_002414901._0024cc && _0024_0024locals_002414901._0024cc.enabled)
			{
				_0024this_002414899.standGround(_0024_0024locals_002414901._0024target);
			}
			if (_0024_0024locals_002414901._0024willAnimated && _0024_0024locals_002414901._0024motionName != _0024_0024locals_002414901._0024idlingName)
			{
				_0024this_002414899.StartCoroutine("PLAY_MOTION_core", new Hash
				{
					{ "arg1", _0024_0024locals_002414901._0024target },
					{ "arg2", _0024_0024locals_002414901._0024idlingName },
					{ "arg3", "0" }
				});
			}
		}
	}

	[Serializable]
	internal class _0024ROTATE_TARGET_core_0024arrive_00243803
	{
		internal float _0024_002412443_002414905;

		internal CutSceneManager _0024this_002414906;

		internal _0024ROTATE_TARGET_core_0024locals_002414392 _0024_0024locals_002414907;

		internal Vector3 _0024_002412444_002414908;

		public _0024ROTATE_TARGET_core_0024arrive_00243803(float _0024_002412443_002414905, CutSceneManager _0024this_002414906, _0024ROTATE_TARGET_core_0024locals_002414392 _0024_0024locals_002414907, Vector3 _0024_002412444_002414908)
		{
			this._0024_002412443_002414905 = _0024_002412443_002414905;
			this._0024this_002414906 = _0024this_002414906;
			this._0024_0024locals_002414907 = _0024_0024locals_002414907;
			this._0024_002412444_002414908 = _0024_002412444_002414908;
		}

		public void Invoke()
		{
			float num = (_0024_002412443_002414905 = _0024_0024locals_002414907._0024rotY);
			Vector3 vector = (_0024_002412444_002414908 = _0024_0024locals_002414907._0024parent.localEulerAngles);
			float num2 = (_0024_002412444_002414908.y = _0024_002412443_002414905);
			Vector3 vector3 = (_0024_0024locals_002414907._0024parent.localEulerAngles = _0024_002412444_002414908);
			_0024_0024locals_002414907._0024lastMoveWaitCount = _0024this_002414906.moveWaitCount;
			if (_0024_0024locals_002414907._0024willAnimated && _0024_0024locals_002414907._0024motionName != _0024_0024locals_002414907._0024idlingName)
			{
				_0024this_002414906.StartCoroutine("PLAY_MOTION_core", new Hash
				{
					{ "arg1", _0024_0024locals_002414907._0024target },
					{ "arg2", _0024_0024locals_002414907._0024idlingName },
					{ "arg3", "0" }
				});
			}
		}
	}

	[Serializable]
	internal class _0024MOVE_ROTATE_core_0024arrive_00243804
	{
		internal float _0024_002412457_002414909;

		internal _0024MOVE_ROTATE_core_0024locals_002414393 _0024_0024locals_002414910;

		internal Vector3 _0024_002412462_002414911;

		internal float _0024_002412461_002414912;

		internal Vector3 _0024_002412460_002414913;

		internal CutSceneManager _0024this_002414914;

		internal Vector3 _0024_002412458_002414915;

		internal float _0024_002412459_002414916;

		public _0024MOVE_ROTATE_core_0024arrive_00243804(float _0024_002412457_002414909, _0024MOVE_ROTATE_core_0024locals_002414393 _0024_0024locals_002414910, Vector3 _0024_002412462_002414911, float _0024_002412461_002414912, Vector3 _0024_002412460_002414913, CutSceneManager _0024this_002414914, Vector3 _0024_002412458_002414915, float _0024_002412459_002414916)
		{
			this._0024_002412457_002414909 = _0024_002412457_002414909;
			this._0024_0024locals_002414910 = _0024_0024locals_002414910;
			this._0024_002412462_002414911 = _0024_002412462_002414911;
			this._0024_002412461_002414912 = _0024_002412461_002414912;
			this._0024_002412460_002414913 = _0024_002412460_002414913;
			this._0024this_002414914 = _0024this_002414914;
			this._0024_002412458_002414915 = _0024_002412458_002414915;
			this._0024_002412459_002414916 = _0024_002412459_002414916;
		}

		public void Invoke()
		{
			float num = (_0024_002412457_002414909 = _0024_0024locals_002414910._0024rotY);
			Vector3 vector = (_0024_002412458_002414915 = _0024_0024locals_002414910._0024parent.localEulerAngles);
			float num2 = (_0024_002412458_002414915.y = _0024_002412457_002414909);
			Vector3 vector3 = (_0024_0024locals_002414910._0024parent.localEulerAngles = _0024_002412458_002414915);
			float num3 = (_0024_002412459_002414916 = _0024_0024locals_002414910._0024pos.x);
			Vector3 vector4 = (_0024_002412460_002414913 = _0024_0024locals_002414910._0024parent.position);
			float num4 = (_0024_002412460_002414913.x = _0024_002412459_002414916);
			Vector3 vector6 = (_0024_0024locals_002414910._0024parent.position = _0024_002412460_002414913);
			float num5 = (_0024_002412461_002414912 = _0024_0024locals_002414910._0024pos.z);
			Vector3 vector7 = (_0024_002412462_002414911 = _0024_0024locals_002414910._0024parent.position);
			float num6 = (_0024_002412462_002414911.z = _0024_002412461_002414912);
			Vector3 vector9 = (_0024_0024locals_002414910._0024parent.position = _0024_002412462_002414911);
			_0024_0024locals_002414910._0024lastMoveWaitCount = _0024this_002414914.moveWaitCount;
			if ((bool)_0024_0024locals_002414910._0024cc && _0024_0024locals_002414910._0024cc.enabled)
			{
				_0024this_002414914.standGround(_0024_0024locals_002414910._0024target);
			}
			if (_0024_0024locals_002414910._0024willAnimated && _0024_0024locals_002414910._0024motionName != _0024_0024locals_002414910._0024idlingName)
			{
				_0024this_002414914.StartCoroutine("PLAY_MOTION_core", new Hash
				{
					{ "arg1", _0024_0024locals_002414910._0024target },
					{ "arg2", _0024_0024locals_002414910._0024idlingName },
					{ "arg3", "0" }
				});
			}
		}
	}

	[Serializable]
	internal class _0024PLAYER_CHR_INIT_core_0024_spawn_00243808
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002418129 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal RuntimeAssetBundleDB _0024abdb_002418130;

				internal RuntimeAssetBundleDB.Req _0024r_002418131;

				internal UnityEngine.Object _0024go_002418132;

				internal string _0024path_002418133;

				internal string _0024name_002418134;

				internal _0024PLAYER_CHR_INIT_core_0024_spawn_00243808 _0024self__002418135;

				public _0024(string path, string name, _0024PLAYER_CHR_INIT_core_0024_spawn_00243808 self_)
				{
					_0024path_002418133 = path;
					_0024name_002418134 = name;
					_0024self__002418135 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024self__002418135._0024_0024locals_002414918._0024spawnIsBusy = true;
						_0024abdb_002418130 = RuntimeAssetBundleDB.Instance;
						_0024r_002418131 = _0024abdb_002418130.instantiatePrefab(_0024path_002418133);
						goto case 2;
					case 2:
						if (!_0024r_002418131.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024r_002418131.IsOk)
						{
							throw new AssertionFailedException(new StringBuilder("CutSceneManager: could not load ").Append(_0024path_002418133).ToString());
						}
						_0024go_002418132 = _0024r_002418131.Asset;
						_0024go_002418132.name = _0024name_002418134;
						_0024self__002418135._0024this_002414917.loadObjectList.Add(_0024r_002418131.Asset);
						_0024self__002418135._0024this_002414917.HIDE_CHR_core((GameObject)_0024go_002418132);
						_0024self__002418135._0024_0024locals_002414918._0024spawnIsBusy = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal string _0024path_002418136;

			internal string _0024name_002418137;

			internal _0024PLAYER_CHR_INIT_core_0024_spawn_00243808 _0024self__002418138;

			public _0024Invoke_002418129(string path, string name, _0024PLAYER_CHR_INIT_core_0024_spawn_00243808 self_)
			{
				_0024path_002418136 = path;
				_0024name_002418137 = name;
				_0024self__002418138 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024path_002418136, _0024name_002418137, _0024self__002418138);
			}
		}

		internal CutSceneManager _0024this_002414917;

		internal _0024PLAYER_CHR_INIT_core_0024locals_002414394 _0024_0024locals_002414918;

		public _0024PLAYER_CHR_INIT_core_0024_spawn_00243808(CutSceneManager _0024this_002414917, _0024PLAYER_CHR_INIT_core_0024locals_002414394 _0024_0024locals_002414918)
		{
			this._0024this_002414917 = _0024this_002414917;
			this._0024_0024locals_002414918 = _0024_0024locals_002414918;
		}

		public IEnumerator Invoke(string path, string name)
		{
			return new _0024Invoke_002418129(path, name, this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024registerSETable_0024_recur_00243814
	{
		internal _0024registerSETable_0024locals_002414395 _0024_0024locals_002414919;

		internal CutSceneManager _0024this_002414920;

		public _0024registerSETable_0024_recur_00243814(_0024registerSETable_0024locals_002414395 _0024_0024locals_002414919, CutSceneManager _0024this_002414920)
		{
			this._0024_0024locals_002414919 = _0024_0024locals_002414919;
			this._0024this_002414920 = _0024this_002414920;
		}

		public void Invoke(string _name)
		{
			if (_0024this_002414920.seTable.ContainsKey(_name))
			{
				Invoke(new StringBuilder().Append(_name).Append("*").ToString());
			}
			else
			{
				_0024this_002414920.seTable[_name] = _0024_0024locals_002414919._0024id;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadAssetBundle_002417443 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024tmpr_002417444;

			internal float _0024tmpg_002417445;

			internal float _0024tmpb_002417446;

			internal RuntimeAssetBundleDB _0024abdb_002417447;

			internal string _0024resLst_002417448;

			internal RuntimeAssetBundleDB.Req _0024r_002417449;

			internal string[] _0024paths_002417450;

			internal string _0024path_002417451;

			internal string _0024ext_002417452;

			internal Type _0024type_002417453;

			internal float _0024_0024wait_until_0024temp_00241505_002417454;

			internal float _0024_0024wait_until_0024temp_00241506_002417455;

			internal int _0024_00248961_002417456;

			internal string[] _0024_00248962_002417457;

			internal int _0024_00248963_002417458;

			internal _0024loadAssetBundle_0024locals_002414388 _0024_0024locals_002417459;

			internal CutSceneManager _0024self__002417460;

			public _0024(CutSceneManager self_)
			{
				_0024self__002417460 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002417459 = new _0024loadAssetBundle_0024locals_002414388();
						_0024self__002417460.nowLoading = true;
						Loading.Begin();
						_0024_0024locals_002417459._0024isCutScene = false;
						goto case 2;
					case 2:
						if (GameLevelManager.IsBusy)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002417460.LoadCutScene(_0024self__002417460.cutSceneName, new _0024loadAssetBundle_0024closure_00243790(_0024self__002417460, _0024_0024locals_002417459).Invoke);
						if ((bool)_0024self__002417460.gameSndmgr)
						{
							goto case 3;
						}
						goto case 4;
					case 3:
						if (_0024self__002417460.gameSndmgr.NowLoading)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						goto case 4;
					case 4:
						if (_0024self__002417460.nowLoading)
						{
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						_0024self__002417460.nowLoading = true;
						_0024self__002417460.fader = FaderCore.Instance;
						_0024tmpr_002417444 = _0024self__002417460.fader.red;
						_0024tmpg_002417445 = _0024self__002417460.fader.green;
						_0024tmpb_002417446 = _0024self__002417460.fader.blue;
						if (_0024self__002417460.mustFadeInAtStart && _0024self__002417460.fader.isOutCompleted)
						{
							_0024self__002417460.fader.fadeInEx(_0024tmpr_002417444, _0024tmpg_002417445, _0024tmpb_002417446, (float)_0024self__002417460.initialFaderWaitMSec / 1000f);
						}
						_0024abdb_002417447 = RuntimeAssetBundleDB.Instance;
						_0024resLst_002417448 = new StringBuilder("RES_").Append(_0024self__002417460.cutSceneName).ToString();
						_0024r_002417449 = _0024abdb_002417447.loadAsset(_0024resLst_002417448, typeof(TextAsset));
						goto case 5;
					case 5:
						if (!_0024r_002417449.IsEnd)
						{
							result = (YieldDefault(5) ? 1 : 0);
							break;
						}
						if (!_0024r_002417449.IsOk)
						{
							SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
							goto case 1;
						}
						_0024paths_002417450 = (_0024r_002417449.Asset as TextAsset).text.Split(new char[4] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
						_0024_0024locals_002417459._0024n = 0;
						_0024_00248961_002417456 = 0;
						_0024_00248962_002417457 = _0024paths_002417450;
						for (_0024_00248963_002417458 = _0024_00248962_002417457.Length; _0024_00248961_002417456 < _0024_00248963_002417458; _0024_00248961_002417456++)
						{
							_0024ext_002417452 = Path.GetExtension(_0024_00248962_002417457[_0024_00248961_002417456]).ToLower();
							_0024type_002417453 = typeof(UnityEngine.Object);
							if (_0024ext_002417452 == ".prefab")
							{
								_0024type_002417453 = typeof(GameObject);
							}
							else if (_0024ext_002417452 == ".anim")
							{
								_0024type_002417453 = typeof(AnimationClip);
							}
							else if (_0024ext_002417452 == ".txt" || _0024ext_002417452 == ".bytes")
							{
								_0024type_002417453 = typeof(TextAsset);
							}
							_0024r_002417449 = _0024abdb_002417447.loadAsset(_0024_00248962_002417457[_0024_00248961_002417456], _0024type_002417453);
							_0024r_002417449.Silent = true;
							_0024r_002417449.Handler = new _0024loadAssetBundle_0024closure_00243791(_0024self__002417460, _0024_0024locals_002417459).Invoke;
							_0024r_002417449.FailHandler = new _0024loadAssetBundle_0024closure_00243792(_0024_0024locals_002417459).Invoke;
						}
						if (_0024self__002417460.fader.isIn)
						{
							_0024_0024wait_until_0024temp_00241505_002417454 = 15f;
							_0024_0024wait_until_0024temp_00241506_002417455 = Time.realtimeSinceStartup;
							goto case 6;
						}
						goto case 7;
					case 6:
						if (!_0024self__002417460.fader.isInCompleted && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241506_002417455 < _0024_0024wait_until_0024temp_00241505_002417454)
						{
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						goto case 7;
					case 7:
						if (_0024_0024locals_002417459._0024n < _0024paths_002417450.Length)
						{
							result = (YieldDefault(7) ? 1 : 0);
							break;
						}
						_0024self__002417460.nowLoading = false;
						Loading.End();
						if (_0024self__002417460.autoStartFlag)
						{
							_0024self__002417460.StartCutScene();
						}
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

		internal CutSceneManager _0024self__002417461;

		public _0024loadAssetBundle_002417443(CutSceneManager self_)
		{
			_0024self__002417461 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417461);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadCutSceneMain_002417462 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002417463;

			internal string _0024srcfile_002417464;

			internal RuntimeAssetBundleDB.Req _0024r1_002417465;

			internal string _0024text_002417466;

			internal Hashtable _0024table_002417467;

			internal object _0024strgnFileName_002417468;

			internal string _0024txtSrcFile_002417469;

			internal RuntimeAssetBundleDB.Req _0024r2_002417470;

			internal TextAsset _0024stringFile_002417471;

			internal string _0024cutSceneName_002417472;

			internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024handler_002417473;

			internal CutSceneManager _0024self__002417474;

			public _0024(string cutSceneName, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ handler, CutSceneManager self_)
			{
				_0024cutSceneName_002417472 = cutSceneName;
				_0024handler_002417473 = handler;
				_0024self__002417474 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024event_0024CutScenePlayStartEvent != null)
					{
						raise_CutScenePlayStartEvent(_0024cutSceneName_002417472);
					}
					_0024self__002417474.cutSceneCmd = null;
					_0024self__002417474.cutSceneString = null;
					BasicCamera.EnableHiddenLayer();
					_0024abdb_002417463 = RuntimeAssetBundleDB.Instance;
					_0024srcfile_002417464 = cutSceneDefaultPath + _0024cutSceneName_002417472;
					_0024r1_002417465 = _0024abdb_002417463.loadAsset(_0024srcfile_002417464, typeof(TextAsset));
					goto case 2;
				case 2:
					if (!_0024r1_002417465.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024r1_002417465.IsOk)
					{
						goto IL_02ec;
					}
					_0024self__002417474.cutSceneFile = _0024r1_002417465.Asset as TextAsset;
					if ((bool)_0024self__002417474.cutSceneFile)
					{
						_0024text_002417466 = CP932Converter.ToUTF8(_0024self__002417474.cutSceneFile.bytes);
						_0024table_002417467 = NGUIJson.jsonDecode(_0024text_002417466) as Hashtable;
						if (_0024table_002417467 != null)
						{
							CutSceneManager cutSceneManager = _0024self__002417474;
							object obj = _0024table_002417467["commands"];
							if (!(obj is Hashtable))
							{
								obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
							}
							cutSceneManager.cutSceneCmd = (Hashtable)obj;
							_0024strgnFileName_002417468 = _0024table_002417467["strings"];
							object obj2 = _0024strgnFileName_002417468;
							if (!(obj2 is string))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(string));
							}
							if (!string.IsNullOrEmpty((string)obj2))
							{
								_0024txtSrcFile_002417469 = cutSceneDefaultPath + _0024strgnFileName_002417468;
								if (!_0024txtSrcFile_002417469.EndsWith(".bytes"))
								{
									_0024txtSrcFile_002417469 += ".bytes";
								}
								_0024r2_002417470 = _0024abdb_002417463.loadAsset(_0024txtSrcFile_002417469, typeof(TextAsset));
								goto case 3;
							}
						}
					}
					goto IL_0294;
				case 3:
					if (!_0024r2_002417470.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!_0024r2_002417470.IsOk)
					{
						goto IL_02ec;
					}
					_0024stringFile_002417471 = _0024r2_002417470.Asset as TextAsset;
					_0024text_002417466 = CP932Converter.ToUTF8(_0024stringFile_002417471.bytes);
					_0024self__002417474.cutSceneString = NGUIJson.jsonDecode(_0024text_002417466) as Hashtable;
					goto IL_0294;
				case 1:
					{
						result = 0;
						break;
					}
					IL_02ec:
					try
					{
						if (_0024handler_002417473 != null)
						{
							_0024handler_002417473(arg0: false);
						}
					}
					catch (Exception)
					{
					}
					YieldDefault(1);
					goto case 1;
					IL_0294:
					_0024self__002417474.initializeFlags();
					if (_0024self__002417474.cutSceneCmd == null || _0024self__002417474.cutSceneString == null)
					{
						goto IL_02ec;
					}
					try
					{
						if (_0024handler_002417473 != null)
						{
							_0024handler_002417473(arg0: true);
						}
					}
					catch (Exception)
					{
						goto IL_02ec;
					}
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024cutSceneName_002417475;

		internal __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ _0024handler_002417476;

		internal CutSceneManager _0024self__002417477;

		public _0024LoadCutSceneMain_002417462(string cutSceneName, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ handler, CutSceneManager self_)
		{
			_0024cutSceneName_002417475 = cutSceneName;
			_0024handler_002417476 = handler;
			_0024self__002417477 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024cutSceneName_002417475, _0024handler_002417476, _0024self__002417477);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PLAY_MOTION_002417478 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417479;

			internal GameObject _0024target_002417480;

			internal Coroutine _0024_0024sco_0024temp_00241524_002417481;

			internal Hashtable _0024arg_002417482;

			internal CutSceneManager _0024self__002417483;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417482 = arg;
				_0024self__002417483 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417479 = _0024arg_002417482["arg1"];
					object obj = _0024targetName_002417479;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417480 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417480)
					{
						_0024target_002417480 = GameObject.Find(_0024targetName_002417479 + "(Clone)") as GameObject;
					}
					_0024arg_002417482["arg1"] = _0024target_002417480;
					if (!_0024target_002417480)
					{
						goto case 1;
					}
					_0024_0024sco_0024temp_00241524_002417481 = _0024self__002417483.StartCoroutine("PLAY_MOTION_core", _0024arg_002417482);
					if (_0024_0024sco_0024temp_00241524_002417481 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241524_002417481) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417484;

		internal CutSceneManager _0024self__002417485;

		public _0024PLAY_MOTION_002417478(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417484 = arg;
			_0024self__002417485 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417484, _0024self__002417485);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PLAY_MOTION_FOR_CUTSCENE_OBJID_002417486 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417487;

			internal GameObject _0024target_002417488;

			internal Coroutine _0024_0024sco_0024temp_00241525_002417489;

			internal Hashtable _0024arg_002417490;

			internal CutSceneManager _0024self__002417491;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417490 = arg;
				_0024self__002417491 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417487 = _0024arg_002417490["arg1"];
					object obj = _0024cutSceneObjId_002417487;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417488 = FindCutSceneObject((string)obj);
					_0024arg_002417490["arg1"] = _0024target_002417488;
					_0024_0024sco_0024temp_00241525_002417489 = _0024self__002417491.StartCoroutine("PLAY_MOTION_core", _0024arg_002417490);
					if (_0024_0024sco_0024temp_00241525_002417489 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241525_002417489) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417492;

		internal CutSceneManager _0024self__002417493;

		public _0024PLAY_MOTION_FOR_CUTSCENE_OBJID_002417486(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417492 = arg;
			_0024self__002417493 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417492, _0024self__002417493);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PLAY_MOTION_core_002417494 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024target_002417495;

			internal string _0024motion_002417496;

			internal int _0024loop_002417497;

			internal Animation _0024anim_002417498;

			internal MerlinMotionPackControl _0024mmpc_002417499;

			internal PlayerControl _0024pc_002417500;

			internal string _0024lastAnim_002417501;

			internal float _0024ox_002417502;

			internal float _0024oz_002417503;

			internal float _0024oy_002417504;

			internal Hashtable _0024orgX_002417505;

			internal Hashtable _0024orgZ_002417506;

			internal Hashtable _0024orgRotY_002417507;

			internal Hashtable _0024orgAnim_002417508;

			internal int _0024aid_002417509;

			internal int _0024tmpMotionWait_002417510;

			internal Hashtable _0024arg_002417511;

			internal CutSceneManager _0024self__002417512;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417511 = arg;
				_0024self__002417512 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						object obj = _0024arg_002417511["arg1"];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024target_002417495 = (GameObject)obj;
						object obj2 = _0024arg_002417511["arg2"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024motion_002417496 = (string)obj2;
						if (!(_0024target_002417495 != null))
						{
							throw new AssertionFailedException("target != null");
						}
						object obj3 = _0024arg_002417511["arg3"];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						_0024loop_002417497 = int.Parse((string)obj3);
						_0024anim_002417498 = _0024self__002417512._getAnim(_0024target_002417495);
						_0024mmpc_002417499 = _0024self__002417512._getMMPC(_0024target_002417495);
						_0024pc_002417500 = _0024target_002417495.GetComponentInChildren<PlayerControl>();
						if ((bool)_0024pc_002417500)
						{
							if (!(_0024pc_002417500 != null))
							{
								throw new AssertionFailedException(new StringBuilder("プレイヤが見つからない in: ").Append(_0024self__002417512.cutSceneName).ToString());
							}
							goto case 2;
						}
						goto IL_0185;
					}
					case 2:
						if (!_0024pc_002417500.IsReady)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_0185;
					case 3:
					case 4:
						if (_0024self__002417512.exec && _0024loop_002417497 != 0 && !(_0024target_002417495 == null))
						{
							_0024self__002417512.AnimSpeedCtrl(_0024target_002417495);
							if (!_0024self__002417512.localPlayFlag)
							{
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							if (_0024self__002417512.checkAnimIdentity(_0024target_002417495, _0024aid_002417509))
							{
								if (!_0024anim_002417498)
								{
									_0024anim_002417498 = _0024target_002417495.GetComponentInChildren<Animation>();
									if (!_0024anim_002417498)
									{
										goto IL_05b8;
									}
								}
								if (_0024self__002417512.isAnimEnd(_0024anim_002417498, _0024mmpc_002417499))
								{
									_0024self__002417512.motionWaitCount -= _0024tmpMotionWait_002417510;
									_0024tmpMotionWait_002417510 = 0;
									if (_0024loop_002417497 > 0)
									{
										_0024loop_002417497--;
										if (_0024loop_002417497 > 0)
										{
											_0024self__002417512.AnimPlay(_0024target_002417495, _0024motion_002417496, forceLoop: false);
										}
									}
									if (_0024loop_002417497 < 0)
									{
										_0024self__002417512.AnimPlay(_0024target_002417495, _0024motion_002417496, forceLoop: true);
									}
								}
								result = (YieldDefault(4) ? 1 : 0);
								break;
							}
						}
						goto IL_05b8;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0185:
						if (!_0024anim_002417498)
						{
							goto case 1;
						}
						_0024lastAnim_002417501 = null;
						if ((bool)_0024anim_002417498.clip)
						{
							_0024lastAnim_002417501 = _0024anim_002417498.clip.name;
						}
						_0024ox_002417502 = _0024target_002417495.transform.localPosition.x;
						_0024oz_002417503 = _0024target_002417495.transform.localPosition.z;
						_0024oy_002417504 = _0024target_002417495.transform.localEulerAngles.y;
						_0024orgX_002417505 = new Hashtable();
						_0024orgZ_002417506 = new Hashtable();
						_0024orgRotY_002417507 = new Hashtable();
						_0024orgX_002417505 = new Hash
						{
							{ "cmd", "target.transform.localPosition.x" },
							{ "obj", _0024target_002417495 },
							{
								"val",
								_0024target_002417495.transform.localPosition.x
							}
						};
						_0024orgZ_002417506 = new Hash
						{
							{ "cmd", "target.transform.localPosition.z" },
							{ "obj", _0024target_002417495 },
							{
								"val",
								_0024target_002417495.transform.localPosition.z
							}
						};
						_0024orgRotY_002417507 = new Hash
						{
							{ "cmd", "target.transform.localEulerAngles.y" },
							{ "obj", _0024target_002417495 },
							{
								"val",
								_0024target_002417495.transform.localEulerAngles.y
							}
						};
						_0024self__002417512.orgDataStack.Push(_0024orgX_002417505);
						_0024self__002417512.orgDataStack.Push(_0024orgZ_002417506);
						_0024self__002417512.orgDataStack.Push(_0024orgRotY_002417507);
						_0024orgAnim_002417508 = new Hashtable();
						_0024orgAnim_002417508 = new Hash
						{
							{ "cmd", "target.Animation" },
							{ "obj", _0024target_002417495 },
							{ "val", _0024lastAnim_002417501 }
						};
						_0024self__002417512.orgDataStack.Push(_0024orgAnim_002417508);
						_0024aid_002417509 = _0024self__002417512.registerAnimIdentity(_0024target_002417495);
						_0024self__002417512.AnimPlay(_0024target_002417495, _0024motion_002417496, forceLoop: false);
						if (_0024loop_002417497 <= 0)
						{
							_0024loop_002417497 = -1;
						}
						_0024tmpMotionWait_002417510 = 1;
						_0024self__002417512.motionWaitCount += _0024tmpMotionWait_002417510;
						goto case 3;
						IL_05b8:
						if (_0024self__002417512.exec)
						{
							_0024self__002417512.finishAnim(_0024target_002417495, _0024aid_002417509);
						}
						_0024self__002417512.motionWaitCount -= _0024tmpMotionWait_002417510;
						_0024tmpMotionWait_002417510 = 0;
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417513;

		internal CutSceneManager _0024self__002417514;

		public _0024PLAY_MOTION_core_002417494(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417513 = arg;
			_0024self__002417514 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002417513, _0024self__002417514);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024NEXT_MOTION_002417515 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417516;

			internal GameObject _0024target_002417517;

			internal Coroutine _0024_0024sco_0024temp_00241526_002417518;

			internal Hashtable _0024arg_002417519;

			internal CutSceneManager _0024self__002417520;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417519 = arg;
				_0024self__002417520 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417516 = _0024arg_002417519["arg1"];
					object obj = _0024targetName_002417516;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417517 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417517)
					{
						_0024target_002417517 = GameObject.Find(_0024targetName_002417516 + "(Clone)") as GameObject;
					}
					_0024arg_002417519["arg1"] = _0024target_002417517;
					if (!_0024target_002417517)
					{
						goto case 1;
					}
					_0024_0024sco_0024temp_00241526_002417518 = _0024self__002417520.StartCoroutine("NEXT_MOTION_core", _0024arg_002417519);
					if (_0024_0024sco_0024temp_00241526_002417518 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241526_002417518) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417521;

		internal CutSceneManager _0024self__002417522;

		public _0024NEXT_MOTION_002417515(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417521 = arg;
			_0024self__002417522 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417521, _0024self__002417522);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024NEXT_MOTION_FOR_CUTSCENE_OBJID_002417523 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417524;

			internal GameObject _0024target_002417525;

			internal Coroutine _0024_0024sco_0024temp_00241527_002417526;

			internal Hashtable _0024arg_002417527;

			internal CutSceneManager _0024self__002417528;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417527 = arg;
				_0024self__002417528 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417524 = _0024arg_002417527["arg1"];
					object obj = _0024cutSceneObjId_002417524;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417525 = FindCutSceneObject((string)obj);
					_0024arg_002417527["arg1"] = _0024target_002417525;
					_0024_0024sco_0024temp_00241527_002417526 = _0024self__002417528.StartCoroutine("NEXT_MOTION_core", _0024arg_002417527);
					if (_0024_0024sco_0024temp_00241527_002417526 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241527_002417526) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417529;

		internal CutSceneManager _0024self__002417530;

		public _0024NEXT_MOTION_FOR_CUTSCENE_OBJID_002417523(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417529 = arg;
			_0024self__002417530 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417529, _0024self__002417530);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024NEXT_MOTION_core_002417531 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal GameObject _0024target_002417532;

			internal string _0024motion_002417533;

			internal int _0024loop_002417534;

			internal Animation _0024anim_002417535;

			internal MerlinMotionPackControl _0024mmpc_002417536;

			internal PlayerControl _0024pc_002417537;

			internal int _0024nid_002417538;

			internal string _0024lastAnim_002417539;

			internal int _0024aid_002417540;

			internal float _0024ox_002417541;

			internal float _0024oz_002417542;

			internal float _0024oy_002417543;

			internal Hashtable _0024orgX_002417544;

			internal Hashtable _0024orgZ_002417545;

			internal Hashtable _0024orgRotY_002417546;

			internal Hashtable _0024orgAnim_002417547;

			internal int _0024tmpMotionWait_002417548;

			internal Hashtable _0024arg_002417549;

			internal CutSceneManager _0024self__002417550;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417549 = arg;
				_0024self__002417550 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						object obj = _0024arg_002417549["arg1"];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024target_002417532 = (GameObject)obj;
						object obj2 = _0024arg_002417549["arg2"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024motion_002417533 = (string)obj2;
						if ((bool)_0024target_002417532)
						{
							object obj3 = _0024arg_002417549["arg3"];
							if (!(obj3 is string))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(string));
							}
							_0024loop_002417534 = int.Parse((string)obj3);
							_0024anim_002417535 = _0024self__002417550._getAnim(_0024target_002417532);
							_0024mmpc_002417536 = _0024self__002417550._getMMPC(_0024target_002417532);
							_0024pc_002417537 = _0024target_002417532.GetComponentInChildren<PlayerControl>();
							if ((bool)_0024anim_002417535)
							{
								if ((bool)_0024pc_002417537)
								{
									goto case 2;
								}
								goto IL_0171;
							}
						}
						goto case 1;
					}
					case 2:
						if (!_0024pc_002417537.IsReady)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_0171;
					case 3:
						_0024nid_002417538 = _0024self__002417550.registerNextAnimIdentity(_0024target_002417532);
						goto case 4;
					case 4:
						if (!_0024self__002417550.isFirstInMotQueue(_0024target_002417532, _0024nid_002417538))
						{
							if (!_0024self__002417550.isInMotQueue(_0024target_002417532, _0024nid_002417538))
							{
								goto case 1;
							}
							result = (YieldDefault(4) ? 1 : 0);
							break;
						}
						_0024lastAnim_002417539 = null;
						if ((bool)_0024mmpc_002417536)
						{
							_0024lastAnim_002417539 = ((!_0024mmpc_002417536.CurrentClip) ? string.Empty : _0024mmpc_002417536.CurrentClip.name);
						}
						else if ((bool)_0024anim_002417535.clip && (bool)_0024anim_002417535.clip)
						{
							_0024lastAnim_002417539 = _0024anim_002417535.clip.name;
						}
						_0024aid_002417540 = _0024self__002417550.getCurrentAnimIdentity(_0024target_002417532);
						_0024ox_002417541 = _0024target_002417532.transform.localPosition.x;
						_0024oz_002417542 = _0024target_002417532.transform.localPosition.z;
						_0024oy_002417543 = _0024target_002417532.transform.localEulerAngles.y;
						_0024orgX_002417544 = new Hashtable();
						_0024orgZ_002417545 = new Hashtable();
						_0024orgRotY_002417546 = new Hashtable();
						_0024orgX_002417544 = new Hash
						{
							{ "cmd", "target.transform.localPosition.x" },
							{ "obj", _0024target_002417532 },
							{
								"val",
								_0024target_002417532.transform.localPosition.x
							}
						};
						_0024orgZ_002417545 = new Hash
						{
							{ "cmd", "target.transform.localPosition.z" },
							{ "obj", _0024target_002417532 },
							{
								"val",
								_0024target_002417532.transform.localPosition.z
							}
						};
						_0024orgRotY_002417546 = new Hash
						{
							{ "cmd", "target.transform.localEulerAngles.y" },
							{ "obj", _0024target_002417532 },
							{
								"val",
								_0024target_002417532.transform.localEulerAngles.y
							}
						};
						_0024self__002417550.orgDataStack.Push(_0024orgX_002417544);
						_0024self__002417550.orgDataStack.Push(_0024orgZ_002417545);
						_0024self__002417550.orgDataStack.Push(_0024orgRotY_002417546);
						_0024orgAnim_002417547 = new Hashtable();
						_0024orgAnim_002417547 = new Hash
						{
							{ "cmd", "target.Animation" },
							{ "obj", _0024target_002417532 },
							{ "val", _0024lastAnim_002417539 }
						};
						_0024self__002417550.orgDataStack.Push(_0024orgAnim_002417547);
						result = (YieldDefault(5) ? 1 : 0);
						break;
					case 5:
						if ((bool)_0024mmpc_002417536)
						{
							goto case 6;
						}
						goto case 7;
					case 6:
						if (_0024self__002417550.exec && (bool)_0024target_002417532 && !_0024mmpc_002417536.IsEndOfMotion)
						{
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						goto IL_05d7;
					case 7:
						if (_0024self__002417550.exec && (bool)_0024target_002417532)
						{
							if (!_0024anim_002417535)
							{
								_0024anim_002417535 = _0024target_002417532.GetComponentInChildren<Animation>();
								if (!_0024anim_002417535)
								{
									goto case 1;
								}
							}
							if (!(_0024anim_002417535 == null) && !string.IsNullOrEmpty(_0024lastAnim_002417539) && !((double)_0024anim_002417535[_0024lastAnim_002417539].normalizedTime >= 1.0) && _0024anim_002417535.IsPlaying(_0024lastAnim_002417539))
							{
								result = (YieldDefault(7) ? 1 : 0);
								break;
							}
						}
						goto IL_05d7;
					case 8:
					case 9:
						if (_0024self__002417550.exec && _0024loop_002417534 != 0 && (bool)_0024target_002417532)
						{
							_0024self__002417550.AnimSpeedCtrl(_0024target_002417532);
							if (!_0024self__002417550.localPlayFlag)
							{
								result = (YieldDefault(8) ? 1 : 0);
								break;
							}
							if (_0024self__002417550.checkAnimIdentity(_0024target_002417532, _0024aid_002417540, _0024nid_002417538))
							{
								if (!_0024anim_002417535)
								{
									_0024anim_002417535 = _0024target_002417532.GetComponentInChildren<Animation>();
									if (!_0024anim_002417535)
									{
										goto IL_07d5;
									}
								}
								if (_0024self__002417550.isAnimEnd(_0024anim_002417535, _0024mmpc_002417536))
								{
									_0024self__002417550.motionWaitCount -= _0024tmpMotionWait_002417548;
									_0024tmpMotionWait_002417548 = 0;
									if (_0024loop_002417534 > 0)
									{
										_0024loop_002417534--;
										if (_0024loop_002417534 > 0)
										{
											_0024self__002417550.AnimPlay(_0024target_002417532, _0024motion_002417533, forceLoop: true);
										}
									}
									if (_0024loop_002417534 < 0)
									{
										_0024self__002417550.AnimPlay(_0024target_002417532, _0024motion_002417533, forceLoop: false);
									}
									if (_0024loop_002417534 == 0)
									{
										_0024self__002417550.AnimPlay(_0024target_002417532, _0024motion_002417533, forceLoop: false);
										goto IL_07d5;
									}
								}
								result = (YieldDefault(9) ? 1 : 0);
								break;
							}
						}
						goto IL_07d5;
					case 1:
						{
							result = 0;
							break;
						}
						IL_07d5:
						if (_0024self__002417550.exec)
						{
							_0024self__002417550.finishNextAnim(_0024target_002417532, _0024nid_002417538);
						}
						_0024self__002417550.motionWaitCount -= _0024tmpMotionWait_002417548;
						_0024tmpMotionWait_002417548 = 0;
						goto case 1;
						IL_0171:
						result = (Yield(3, new WaitForFixedUpdate()) ? 1 : 0);
						break;
						IL_05d7:
						if (_0024self__002417550.exec && !_0024self__002417550.isInMotQueue(_0024target_002417532, _0024nid_002417538))
						{
							goto case 1;
						}
						if (_0024loop_002417534 <= 0)
						{
							_0024loop_002417534 = -1;
						}
						_0024tmpMotionWait_002417548 = 1;
						_0024self__002417550.motionWaitCount += _0024tmpMotionWait_002417548;
						goto case 8;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417551;

		internal CutSceneManager _0024self__002417552;

		public _0024NEXT_MOTION_core_002417531(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417551 = arg;
			_0024self__002417552 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024arg_002417551, _0024self__002417552);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_TARGET_002417553 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417554;

			internal GameObject _0024target_002417555;

			internal Coroutine _0024_0024sco_0024temp_00241528_002417556;

			internal Hashtable _0024arg_002417557;

			internal CutSceneManager _0024self__002417558;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417557 = arg;
				_0024self__002417558 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417554 = _0024arg_002417557["arg1"];
					object obj = _0024targetName_002417554;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417555 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417555)
					{
						_0024target_002417555 = GameObject.Find(_0024targetName_002417554 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417555)
					{
						goto case 1;
					}
					_0024arg_002417557["arg1"] = _0024target_002417555;
					_0024arg_002417557["arg7"] = 0;
					_0024_0024sco_0024temp_00241528_002417556 = _0024self__002417558.StartCoroutine("MOVE_TARGET_core", _0024arg_002417557);
					if (_0024_0024sco_0024temp_00241528_002417556 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241528_002417556) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417559;

		internal CutSceneManager _0024self__002417560;

		public _0024MOVE_TARGET_002417553(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417559 = arg;
			_0024self__002417560 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417559, _0024self__002417560);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_TARGET_FOR_CUTSCENE_OBJID_002417561 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417562;

			internal GameObject _0024target_002417563;

			internal Coroutine _0024_0024sco_0024temp_00241529_002417564;

			internal Hashtable _0024arg_002417565;

			internal CutSceneManager _0024self__002417566;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417565 = arg;
				_0024self__002417566 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417562 = _0024arg_002417565["arg1"];
					object obj = _0024cutSceneObjId_002417562;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417563 = FindCutSceneObject((string)obj);
					_0024arg_002417565["arg1"] = _0024target_002417563;
					_0024arg_002417565["arg7"] = 0;
					_0024_0024sco_0024temp_00241529_002417564 = _0024self__002417566.StartCoroutine("MOVE_TARGET_core", _0024arg_002417565);
					if (_0024_0024sco_0024temp_00241529_002417564 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241529_002417564) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417567;

		internal CutSceneManager _0024self__002417568;

		public _0024MOVE_TARGET_FOR_CUTSCENE_OBJID_002417561(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417567 = arg;
			_0024self__002417568 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417567, _0024self__002417568);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_TARGET_OVERTIME_002417569 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417570;

			internal float _0024msec_002417571;

			internal GameObject _0024target_002417572;

			internal Coroutine _0024_0024sco_0024temp_00241530_002417573;

			internal Hashtable _0024arg_002417574;

			internal CutSceneManager _0024self__002417575;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417574 = arg;
				_0024self__002417575 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417570 = _0024arg_002417574["arg1"];
					object obj = _0024arg_002417574["arg6"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024msec_002417571 = float.Parse((string)obj);
					object obj2 = _0024targetName_002417570;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024target_002417572 = GameObject.Find((string)obj2) as GameObject;
					if (!_0024target_002417572)
					{
						_0024target_002417572 = GameObject.Find(_0024targetName_002417570 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417572)
					{
						goto case 1;
					}
					_0024arg_002417574["arg1"] = _0024target_002417572;
					_0024arg_002417574["arg7"] = 1;
					_0024_0024sco_0024temp_00241530_002417573 = _0024self__002417575.StartCoroutine("MOVE_TARGET_core", _0024arg_002417574);
					if (_0024_0024sco_0024temp_00241530_002417573 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241530_002417573) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417576;

		internal CutSceneManager _0024self__002417577;

		public _0024MOVE_TARGET_OVERTIME_002417569(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417576 = arg;
			_0024self__002417577 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417576, _0024self__002417577);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417578 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417579;

			internal GameObject _0024target_002417580;

			internal Coroutine _0024_0024sco_0024temp_00241531_002417581;

			internal Hashtable _0024arg_002417582;

			internal CutSceneManager _0024self__002417583;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417582 = arg;
				_0024self__002417583 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417579 = _0024arg_002417582["arg1"];
					object obj = _0024cutSceneObjId_002417579;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417580 = FindCutSceneObject((string)obj);
					_0024arg_002417582["arg1"] = _0024target_002417580;
					_0024arg_002417582["arg7"] = 1;
					_0024_0024sco_0024temp_00241531_002417581 = _0024self__002417583.StartCoroutine("MOVE_TARGET_core", _0024arg_002417582);
					if (_0024_0024sco_0024temp_00241531_002417581 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241531_002417581) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417584;

		internal CutSceneManager _0024self__002417585;

		public _0024MOVE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417578(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417584 = arg;
			_0024self__002417585 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417584, _0024self__002417585);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_TARGET_core_002417586 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024posX_002417587;

			internal float _0024posZ_002417588;

			internal float _0024vel_002417589;

			internal object _0024msecMode_002417590;

			internal float _0024duration_002417591;

			internal bool _0024lookDirection_002417592;

			internal Animation _0024anim_002417593;

			internal MerlinMotionPackControl _0024mmpc_002417594;

			internal PlayerControl _0024ctrl_002417595;

			internal string _0024lastAnim_002417596;

			internal Hashtable _0024orgX_002417597;

			internal Hashtable _0024orgZ_002417598;

			internal Hashtable _0024orgRotY_002417599;

			internal Hashtable _0024orgAnim_002417600;

			internal Transform _0024yAng_002417601;

			internal Hashtable _0024orgRotY2_002417602;

			internal Hashtable _0024orgRotY3_002417603;

			internal int _0024aid_002417604;

			internal Vector3 _0024vec_002417605;

			internal Quaternion _0024lastRot_002417606;

			internal float _0024lastMag_002417607;

			internal float _0024curMag_002417608;

			internal int _0024tmpMoveWait_002417609;

			internal Quaternion _0024startRot_002417610;

			internal Quaternion _0024lookRot_002417611;

			internal float _0024elapsed_002417612;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024arrive_002417613;

			internal double _0024speedRate_002417614;

			internal Vector3 _0024v_002417615;

			internal int _0024_002412427_002417616;

			internal Vector3 _0024_002412428_002417617;

			internal int _0024_002412429_002417618;

			internal Vector3 _0024_002412430_002417619;

			internal float _0024_002412431_002417620;

			internal Vector3 _0024_002412432_002417621;

			internal float _0024_002412433_002417622;

			internal Vector3 _0024_002412434_002417623;

			internal float _0024_002412435_002417624;

			internal Vector3 _0024_002412436_002417625;

			internal float _0024_002412437_002417626;

			internal Vector3 _0024_002412438_002417627;

			internal _0024MOVE_TARGET_core_0024locals_002414391 _0024_0024locals_002417628;

			internal Hashtable _0024arg_002417629;

			internal CutSceneManager _0024self__002417630;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417629 = arg;
				_0024self__002417630 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						_0024_0024locals_002417628 = new _0024MOVE_TARGET_core_0024locals_002414391();
						_0024MOVE_TARGET_core_0024locals_002414391 _0024MOVE_TARGET_core_0024locals_0024 = _0024_0024locals_002417628;
						object obj = _0024arg_002417629["arg1"];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024MOVE_TARGET_core_0024locals_0024._0024target = (GameObject)obj;
						_0024MOVE_TARGET_core_0024locals_002414391 _0024MOVE_TARGET_core_0024locals_00242 = _0024_0024locals_002417628;
						object obj2 = _0024arg_002417629["arg2"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024MOVE_TARGET_core_0024locals_00242._0024motionName = (string)obj2;
						_0024MOVE_TARGET_core_0024locals_002414391 _0024MOVE_TARGET_core_0024locals_00243 = _0024_0024locals_002417628;
						object obj3 = _0024arg_002417629["arg3"];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						_0024MOVE_TARGET_core_0024locals_00243._0024idlingName = (string)obj3;
						object obj4 = _0024arg_002417629["arg4"];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						_0024posX_002417587 = float.Parse((string)obj4);
						object obj5 = _0024arg_002417629["arg5"];
						if (!(obj5 is string))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(string));
						}
						_0024posZ_002417588 = float.Parse((string)obj5);
						object obj6 = _0024arg_002417629["arg6"];
						if (!(obj6 is string))
						{
							obj6 = RuntimeServices.Coerce(obj6, typeof(string));
						}
						_0024vel_002417589 = float.Parse((string)obj6);
						_0024msecMode_002417590 = _0024arg_002417629["arg7"];
						_0024duration_002417591 = (float)((double)_0024vel_002417589 / 1000.0);
						_0024lookDirection_002417592 = true;
						if ((bool)_0024_0024locals_002417628._0024target)
						{
							_0024anim_002417593 = _0024self__002417630._getAnim(_0024_0024locals_002417628._0024target);
							_0024mmpc_002417594 = _0024self__002417630._getMMPC(_0024_0024locals_002417628._0024target);
							if ((bool)_0024anim_002417593)
							{
								_0024_0024locals_002417628._0024parent = _0024_0024locals_002417628._0024target.transform;
								_0024ctrl_002417595 = _0024_0024locals_002417628._0024parent.GetComponentInChildren<PlayerControl>();
								if ((bool)_0024ctrl_002417595 && _0024vel_002417589 == 0f)
								{
									if ((bool)_0024ctrl_002417595)
									{
										_0024vel_002417589 = _0024ctrl_002417595.CurrentMoveSpeed;
									}
									if (!(_0024vel_002417589 > 0f))
									{
										if (RuntimeServices.EqualityOperator(_0024msecMode_002417590, 1))
										{
											_0024vel_002417589 = 1000f;
										}
										else
										{
											_0024vel_002417589 = 1f;
										}
									}
								}
								_0024lastAnim_002417596 = null;
								if ((bool)_0024anim_002417593.clip)
								{
									_0024lastAnim_002417596 = _0024anim_002417593.clip.name;
								}
								_0024orgX_002417597 = new Hashtable();
								_0024orgZ_002417598 = new Hashtable();
								_0024orgRotY_002417599 = new Hashtable();
								_0024orgX_002417597 = new Hash
								{
									{ "cmd", "target.transform.localPosition.x" },
									{
										"obj",
										_0024_0024locals_002417628._0024parent.gameObject
									},
									{
										"val",
										_0024_0024locals_002417628._0024parent.localPosition.x
									}
								};
								_0024orgZ_002417598 = new Hash
								{
									{ "cmd", "target.transform.localPosition.z" },
									{
										"obj",
										_0024_0024locals_002417628._0024parent.gameObject
									},
									{
										"val",
										_0024_0024locals_002417628._0024parent.localPosition.z
									}
								};
								_0024orgRotY_002417599 = new Hash
								{
									{ "cmd", "target.transform.localEulerAngles.y" },
									{
										"obj",
										_0024_0024locals_002417628._0024parent.gameObject
									},
									{
										"val",
										_0024_0024locals_002417628._0024parent.localEulerAngles.y
									}
								};
								_0024self__002417630.orgDataStack.Push(_0024orgX_002417597);
								_0024self__002417630.orgDataStack.Push(_0024orgZ_002417598);
								_0024self__002417630.orgDataStack.Push(_0024orgRotY_002417599);
								_0024orgAnim_002417600 = new Hashtable();
								_0024orgAnim_002417600 = new Hash
								{
									{ "cmd", "target.Animation" },
									{ "obj", _0024_0024locals_002417628._0024target },
									{ "val", _0024lastAnim_002417596 }
								};
								_0024self__002417630.orgDataStack.Push(_0024orgAnim_002417600);
								_0024yAng_002417601 = ObjUtilModule.Find1stDescendant(_0024_0024locals_002417628._0024target.transform, "y_ang");
								if (_0024lookDirection_002417592 && (bool)_0024yAng_002417601)
								{
									if (_0024_0024locals_002417628._0024parent != _0024yAng_002417601.parent)
									{
										_0024orgRotY2_002417602 = new Hashtable();
										_0024orgRotY2_002417602 = new Hash
										{
											{ "cmd", "target.transform.localEulerAngles.y" },
											{
												"obj",
												_0024yAng_002417601.parent.gameObject
											},
											{
												"val",
												_0024yAng_002417601.parent.localEulerAngles.y
											}
										};
										_0024self__002417630.orgDataStack.Push(_0024orgRotY2_002417602);
										if ((bool)_0024yAng_002417601.parent)
										{
											int num = (_0024_002412427_002417616 = 0);
											Vector3 vector = (_0024_002412428_002417617 = _0024yAng_002417601.parent.localEulerAngles);
											float num2 = (_0024_002412428_002417617.y = _0024_002412427_002417616);
											Vector3 vector3 = (_0024yAng_002417601.parent.localEulerAngles = _0024_002412428_002417617);
										}
									}
									if (_0024_0024locals_002417628._0024parent != _0024yAng_002417601)
									{
										_0024orgRotY3_002417603 = new Hashtable();
										_0024orgRotY3_002417603 = new Hash
										{
											{ "cmd", "target.transform.localEulerAngles.y" },
											{ "obj", _0024yAng_002417601.gameObject },
											{
												"val",
												_0024yAng_002417601.localEulerAngles.y
											}
										};
										_0024self__002417630.orgDataStack.Push(_0024orgRotY3_002417603);
										int num3 = (_0024_002412429_002417618 = 0);
										Vector3 vector4 = (_0024_002412430_002417619 = _0024yAng_002417601.localEulerAngles);
										float num4 = (_0024_002412430_002417619.y = _0024_002412429_002417618);
										Vector3 vector6 = (_0024yAng_002417601.localEulerAngles = _0024_002412430_002417619);
									}
								}
								_0024_0024locals_002417628._0024willAnimated = true;
								if (_0024self__002417630.isPlayingAnim(_0024_0024locals_002417628._0024target, _0024_0024locals_002417628._0024motionName))
								{
									_0024aid_002417604 = _0024self__002417630.getCurrentAnimIdentity(_0024_0024locals_002417628._0024target);
								}
								else
								{
									_0024aid_002417604 = _0024self__002417630.registerAnimIdentity(_0024_0024locals_002417628._0024target);
									_0024self__002417630.AnimPlay(_0024_0024locals_002417628._0024target, _0024_0024locals_002417628._0024motionName, forceLoop: false);
								}
								_0024_0024locals_002417628._0024pos = new Vector3(_0024posX_002417587, _0024_0024locals_002417628._0024parent.position.y, _0024posZ_002417588);
								_0024vec_002417605 = _0024_0024locals_002417628._0024pos - _0024_0024locals_002417628._0024parent.position;
								_0024vec_002417605.y = 0f;
								_0024lastRot_002417606 = _0024_0024locals_002417628._0024parent.localRotation;
								_0024lastMag_002417607 = _0024vec_002417605.magnitude;
								_0024curMag_002417608 = 0f;
								if (RuntimeServices.EqualityOperator(_0024msecMode_002417590, 1))
								{
									_0024vel_002417589 = _0024lastMag_002417607 * 1000f / _0024vel_002417589;
								}
								_0024tmpMoveWait_002417609 = 1;
								_0024self__002417630.moveWaitCount += _0024tmpMoveWait_002417609;
								_0024_0024locals_002417628._0024lastMoveWaitCount = _0024self__002417630.moveWaitCount;
								_0024startRot_002417610 = _0024_0024locals_002417628._0024parent.rotation;
								_0024lookRot_002417611 = Quaternion.LookRotation(_0024vec_002417605);
								_0024elapsed_002417612 = 0f;
								_0024_0024locals_002417628._0024cc = (CharacterController)_0024_0024locals_002417628._0024target.GetComponent(typeof(CharacterController));
								_0024arrive_002417613 = new _0024MOVE_TARGET_core_0024arrive_00243802(_0024self__002417630, _0024_002412432_002417621, _0024_0024locals_002417628, _0024_002412431_002417620, _0024_002412434_002417623, _0024_002412433_002417622).Invoke;
								if (_0024_0024locals_002417628._0024motionName == _0024_0024locals_002417628._0024idlingName)
								{
									_0024self__002417630.StartCoroutine("NEXT_MOTION_core", new Hash
									{
										{ "arg1", _0024_0024locals_002417628._0024target },
										{ "arg2", _0024_0024locals_002417628._0024idlingName },
										{ "arg3", "0" }
									});
								}
								goto case 2;
							}
						}
						goto case 1;
					}
					case 2:
					case 3:
						if (_0024self__002417630.exec && _0024_0024locals_002417628._0024target.activeSelf)
						{
							_0024self__002417630.AnimSpeedCtrl(_0024_0024locals_002417628._0024target);
							if (!_0024self__002417630.localPlayFlag)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							if (!_0024self__002417630.checkAnimIdentity(_0024_0024locals_002417628._0024target, _0024aid_002417604))
							{
								_0024_0024locals_002417628._0024willAnimated = false;
							}
							if (_0024tmpMoveWait_002417609 != 0)
							{
								if (!_0024anim_002417593)
								{
									_0024anim_002417593 = _0024_0024locals_002417628._0024target.GetComponentInChildren<Animation>();
									if (!_0024anim_002417593)
									{
										goto IL_0d73;
									}
								}
								_0024vec_002417605 = _0024_0024locals_002417628._0024pos - _0024_0024locals_002417628._0024parent.position;
								_0024vec_002417605.y = 0f;
								_0024curMag_002417608 = _0024vec_002417605.magnitude;
								_0024speedRate_002417614 = 0.001;
								if (RuntimeServices.EqualityOperator(_0024msecMode_002417590, 1))
								{
									_0024speedRate_002417614 = Time.deltaTime;
								}
								_0024elapsed_002417612 += Time.deltaTime * _0024self__002417630.animSpeed;
								if (_0024tmpMoveWait_002417609 > 0)
								{
									_0024v_002417615 = _0024vel_002417589 * _0024vec_002417605.normalized * _0024self__002417630.animSpeed;
									if (!((double)_0024v_002417615.magnitude * _0024speedRate_002417614 <= (double)_0024vec_002417605.magnitude))
									{
										_0024curMag_002417608 = 0f;
									}
									else if (_0024_0024locals_002417628._0024cc != null && _0024_0024locals_002417628._0024cc.enabled)
									{
										if (_0024curMag_002417608 != 0f)
										{
											_0024_0024locals_002417628._0024cc.SimpleMove(_0024v_002417615);
										}
									}
									else if (_0024curMag_002417608 != 0f)
									{
										_0024_0024locals_002417628._0024parent.position = _0024_0024locals_002417628._0024parent.position + _0024v_002417615 * (float)_0024speedRate_002417614;
									}
									if (_0024lookDirection_002417592 && !((double)_0024elapsed_002417612 >= (double)_0024duration_002417591 * 0.5))
									{
										_0024_0024locals_002417628._0024parent.rotation = Quaternion.Lerp(_0024startRot_002417610, _0024lookRot_002417611, (float)((double)_0024elapsed_002417612 / ((double)_0024duration_002417591 * 0.5)));
									}
								}
								if (!(_0024elapsed_002417612 < _0024duration_002417591) && (_0024curMag_002417608 < 0.05f || _0024lastMag_002417607 <= _0024curMag_002417608 || !(_0024vel_002417589 > 0f)) && _0024tmpMoveWait_002417609 > 0)
								{
									_0024arrive_002417613();
								}
								else
								{
									if ((double)_0024elapsed_002417612 < (double)_0024duration_002417591 * 1.2)
									{
										if (_0024tmpMoveWait_002417609 > 0 && _0024self__002417630.isAnimEnd(_0024anim_002417593, _0024mmpc_002417594) && _0024_0024locals_002417628._0024willAnimated)
										{
											_0024self__002417630.AnimPlay(_0024_0024locals_002417628._0024target, _0024_0024locals_002417628._0024motionName, forceLoop: true);
										}
										_0024lastMag_002417607 = _0024curMag_002417608;
										result = (Yield(3, new WaitForFixedUpdate()) ? 1 : 0);
										break;
									}
									_0024arrive_002417613();
								}
							}
						}
						goto IL_0d73;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0d73:
						if ((bool)_0024_0024locals_002417628._0024parent)
						{
							float num5 = (_0024_002412435_002417624 = _0024_0024locals_002417628._0024pos.x);
							Vector3 vector7 = (_0024_002412436_002417625 = _0024_0024locals_002417628._0024parent.position);
							float num6 = (_0024_002412436_002417625.x = _0024_002412435_002417624);
							Vector3 vector9 = (_0024_0024locals_002417628._0024parent.position = _0024_002412436_002417625);
							float num7 = (_0024_002412437_002417626 = _0024_0024locals_002417628._0024pos.z);
							Vector3 vector10 = (_0024_002412438_002417627 = _0024_0024locals_002417628._0024parent.position);
							float num8 = (_0024_002412438_002417627.z = _0024_002412437_002417626);
							Vector3 vector12 = (_0024_0024locals_002417628._0024parent.position = _0024_002412438_002417627);
							if (_0024_0024locals_002417628._0024cc != null && _0024_0024locals_002417628._0024cc.enabled)
							{
								_0024self__002417630.standGround(_0024_0024locals_002417628._0024target);
							}
						}
						_0024self__002417630.moveWaitCount -= _0024tmpMoveWait_002417609;
						_0024tmpMoveWait_002417609 = 0;
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417631;

		internal CutSceneManager _0024self__002417632;

		public _0024MOVE_TARGET_core_002417586(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417631 = arg;
			_0024self__002417632 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024arg_002417631, _0024self__002417632);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ROTATE_TARGET_002417633 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417634;

			internal GameObject _0024target_002417635;

			internal Coroutine _0024_0024sco_0024temp_00241532_002417636;

			internal Hashtable _0024arg_002417637;

			internal CutSceneManager _0024self__002417638;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417637 = arg;
				_0024self__002417638 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417634 = _0024arg_002417637["arg1"];
					object obj = _0024targetName_002417634;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417635 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417635)
					{
						_0024target_002417635 = GameObject.Find(_0024targetName_002417634 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417635)
					{
						goto case 1;
					}
					_0024arg_002417637["arg1"] = _0024target_002417635;
					_0024arg_002417637["arg6"] = 0;
					_0024_0024sco_0024temp_00241532_002417636 = _0024self__002417638.StartCoroutine("ROTATE_TARGET_core", _0024arg_002417637);
					if (_0024_0024sco_0024temp_00241532_002417636 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241532_002417636) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417639;

		internal CutSceneManager _0024self__002417640;

		public _0024ROTATE_TARGET_002417633(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417639 = arg;
			_0024self__002417640 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417639, _0024self__002417640);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ROTATE_TARGET_FOR_CUTSCENE_OBJID_002417641 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417642;

			internal GameObject _0024target_002417643;

			internal Coroutine _0024_0024sco_0024temp_00241533_002417644;

			internal Hashtable _0024arg_002417645;

			internal CutSceneManager _0024self__002417646;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417645 = arg;
				_0024self__002417646 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417642 = _0024arg_002417645["arg1"];
					object obj = _0024cutSceneObjId_002417642;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417643 = FindCutSceneObject((string)obj);
					_0024arg_002417645["arg1"] = _0024target_002417643;
					_0024arg_002417645["arg6"] = 0;
					_0024_0024sco_0024temp_00241533_002417644 = _0024self__002417646.StartCoroutine("ROTATE_TARGET_core", _0024arg_002417645);
					if (_0024_0024sco_0024temp_00241533_002417644 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241533_002417644) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417647;

		internal CutSceneManager _0024self__002417648;

		public _0024ROTATE_TARGET_FOR_CUTSCENE_OBJID_002417641(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417647 = arg;
			_0024self__002417648 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417647, _0024self__002417648);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ROTATE_TARGET_OVERTIME_002417649 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417650;

			internal GameObject _0024target_002417651;

			internal Coroutine _0024_0024sco_0024temp_00241534_002417652;

			internal Hashtable _0024arg_002417653;

			internal CutSceneManager _0024self__002417654;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417653 = arg;
				_0024self__002417654 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417650 = _0024arg_002417653["arg1"];
					object obj = _0024targetName_002417650;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417651 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417651)
					{
						_0024target_002417651 = GameObject.Find(_0024targetName_002417650 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417651)
					{
						goto case 1;
					}
					_0024arg_002417653["arg1"] = _0024target_002417651;
					_0024arg_002417653["arg6"] = 1;
					_0024_0024sco_0024temp_00241534_002417652 = _0024self__002417654.StartCoroutine("ROTATE_TARGET_core", _0024arg_002417653);
					if (_0024_0024sco_0024temp_00241534_002417652 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241534_002417652) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417655;

		internal CutSceneManager _0024self__002417656;

		public _0024ROTATE_TARGET_OVERTIME_002417649(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417655 = arg;
			_0024self__002417656 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417655, _0024self__002417656);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ROTATE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417657 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417658;

			internal GameObject _0024target_002417659;

			internal Coroutine _0024_0024sco_0024temp_00241535_002417660;

			internal Hashtable _0024arg_002417661;

			internal CutSceneManager _0024self__002417662;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417661 = arg;
				_0024self__002417662 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417658 = _0024arg_002417661["arg1"];
					object obj = _0024cutSceneObjId_002417658;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417659 = FindCutSceneObject((string)obj);
					_0024arg_002417661["arg1"] = _0024target_002417659;
					_0024arg_002417661["arg6"] = 1;
					_0024_0024sco_0024temp_00241535_002417660 = _0024self__002417662.StartCoroutine("ROTATE_TARGET_core", _0024arg_002417661);
					if (_0024_0024sco_0024temp_00241535_002417660 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241535_002417660) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417663;

		internal CutSceneManager _0024self__002417664;

		public _0024ROTATE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417657(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417663 = arg;
			_0024self__002417664 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417663, _0024self__002417664);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ROTATE_TARGET_core_002417665 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024rotSpeed_002417666;

			internal object _0024msecMode_002417667;

			internal Animation _0024anim_002417668;

			internal MerlinMotionPackControl _0024mmpc_002417669;

			internal string _0024lastAnim_002417670;

			internal Hashtable _0024orgRotY_002417671;

			internal Hashtable _0024orgAnim_002417672;

			internal Transform _0024yAng_002417673;

			internal Hashtable _0024orgRotY2_002417674;

			internal Hashtable _0024orgRotY3_002417675;

			internal int _0024aid_002417676;

			internal double _0024tmpParentRotY1_002417677;

			internal RotDir _0024rotSign_002417678;

			internal float _0024lastRot_002417679;

			internal float _0024curRot_002417680;

			internal float _0024totalRot_002417681;

			internal int _0024tmpMoveWait_002417682;

			internal int _0024n_002417683;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024arrive_002417684;

			internal float _0024d_002417685;

			internal int _0024_002412439_002417686;

			internal Vector3 _0024_002412440_002417687;

			internal int _0024_002412441_002417688;

			internal Vector3 _0024_002412442_002417689;

			internal float _0024_002412443_002417690;

			internal Vector3 _0024_002412444_002417691;

			internal float _0024_002412445_002417692;

			internal Vector3 _0024_002412446_002417693;

			internal float _0024_002412447_002417694;

			internal Vector3 _0024_002412448_002417695;

			internal float _0024_002412449_002417696;

			internal Vector3 _0024_002412450_002417697;

			internal float _0024_002412451_002417698;

			internal Vector3 _0024_002412452_002417699;

			internal _0024ROTATE_TARGET_core_0024locals_002414392 _0024_0024locals_002417700;

			internal Hashtable _0024arg_002417701;

			internal CutSceneManager _0024self__002417702;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417701 = arg;
				_0024self__002417702 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024locals_002417700 = new _0024ROTATE_TARGET_core_0024locals_002414392();
					_0024ROTATE_TARGET_core_0024locals_002414392 _0024ROTATE_TARGET_core_0024locals_0024 = _0024_0024locals_002417700;
					object obj = _0024arg_002417701["arg1"];
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					_0024ROTATE_TARGET_core_0024locals_0024._0024target = (GameObject)obj;
					_0024ROTATE_TARGET_core_0024locals_002414392 _0024ROTATE_TARGET_core_0024locals_00242 = _0024_0024locals_002417700;
					object obj2 = _0024arg_002417701["arg2"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024ROTATE_TARGET_core_0024locals_00242._0024motionName = (string)obj2;
					_0024ROTATE_TARGET_core_0024locals_002414392 _0024ROTATE_TARGET_core_0024locals_00243 = _0024_0024locals_002417700;
					object obj3 = _0024arg_002417701["arg3"];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					_0024ROTATE_TARGET_core_0024locals_00243._0024idlingName = (string)obj3;
					_0024ROTATE_TARGET_core_0024locals_002414392 _0024ROTATE_TARGET_core_0024locals_00244 = _0024_0024locals_002417700;
					object obj4 = _0024arg_002417701["arg4"];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					_0024ROTATE_TARGET_core_0024locals_00244._0024rotY = float.Parse((string)obj4);
					object obj5 = _0024arg_002417701["arg5"];
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					_0024rotSpeed_002417666 = float.Parse((string)obj5);
					_0024msecMode_002417667 = _0024arg_002417701["arg6"];
					if ((bool)_0024_0024locals_002417700._0024target)
					{
						_0024anim_002417668 = _0024self__002417702._getAnim(_0024_0024locals_002417700._0024target);
						_0024mmpc_002417669 = _0024self__002417702._getMMPC(_0024_0024locals_002417700._0024target);
						if ((bool)_0024anim_002417668)
						{
							_0024_0024locals_002417700._0024parent = _0024_0024locals_002417700._0024target.transform;
							_0024lastAnim_002417670 = null;
							if ((bool)_0024anim_002417668.clip)
							{
								_0024lastAnim_002417670 = _0024anim_002417668.clip.name;
							}
							_0024orgRotY_002417671 = new Hashtable();
							_0024orgRotY_002417671 = new Hash
							{
								{ "cmd", "target.transform.localEulerAngles.y" },
								{
									"obj",
									_0024_0024locals_002417700._0024parent.gameObject
								},
								{
									"val",
									_0024_0024locals_002417700._0024parent.localEulerAngles.y
								}
							};
							_0024self__002417702.orgDataStack.Push(_0024orgRotY_002417671);
							_0024orgAnim_002417672 = new Hashtable();
							_0024orgAnim_002417672 = new Hash
							{
								{ "cmd", "target.Animation" },
								{ "obj", _0024_0024locals_002417700._0024target },
								{ "val", _0024lastAnim_002417670 }
							};
							_0024self__002417702.orgDataStack.Push(_0024orgAnim_002417672);
							_0024yAng_002417673 = ObjUtilModule.Find1stDescendant(_0024_0024locals_002417700._0024target.transform, "y_ang");
							if ((bool)_0024yAng_002417673)
							{
								if (_0024_0024locals_002417700._0024parent != _0024yAng_002417673.parent)
								{
									_0024orgRotY2_002417674 = new Hashtable();
									_0024orgRotY2_002417674 = new Hash
									{
										{ "cmd", "target.transform.localEulerAngles.y" },
										{
											"obj",
											_0024yAng_002417673.parent.gameObject
										},
										{
											"val",
											_0024yAng_002417673.parent.localEulerAngles.y
										}
									};
									_0024self__002417702.orgDataStack.Push(_0024orgRotY2_002417674);
									if ((bool)_0024yAng_002417673.parent)
									{
										int num = (_0024_002412439_002417686 = 0);
										Vector3 vector = (_0024_002412440_002417687 = _0024yAng_002417673.parent.localEulerAngles);
										float num2 = (_0024_002412440_002417687.y = _0024_002412439_002417686);
										Vector3 vector3 = (_0024yAng_002417673.parent.localEulerAngles = _0024_002412440_002417687);
									}
								}
								if (_0024_0024locals_002417700._0024parent != _0024yAng_002417673)
								{
									_0024orgRotY3_002417675 = new Hashtable();
									_0024orgRotY3_002417675 = new Hash
									{
										{ "cmd", "target.transform.localEulerAngles.y" },
										{ "obj", _0024yAng_002417673.gameObject },
										{
											"val",
											_0024yAng_002417673.localEulerAngles.y
										}
									};
									_0024self__002417702.orgDataStack.Push(_0024orgRotY3_002417675);
									int num3 = (_0024_002412441_002417688 = 0);
									Vector3 vector4 = (_0024_002412442_002417689 = _0024yAng_002417673.localEulerAngles);
									float num4 = (_0024_002412442_002417689.y = _0024_002412441_002417688);
									Vector3 vector6 = (_0024yAng_002417673.localEulerAngles = _0024_002412442_002417689);
								}
							}
							_0024_0024locals_002417700._0024willAnimated = true;
							if (_0024self__002417702.isPlayingAnim(_0024_0024locals_002417700._0024target, _0024_0024locals_002417700._0024motionName))
							{
								_0024aid_002417676 = _0024self__002417702.getCurrentAnimIdentity(_0024_0024locals_002417700._0024target);
							}
							else
							{
								_0024aid_002417676 = _0024self__002417702.registerAnimIdentity(_0024_0024locals_002417700._0024target);
								_0024self__002417702.AnimPlay(_0024_0024locals_002417700._0024target, _0024_0024locals_002417700._0024motionName, forceLoop: false);
							}
							_0024tmpParentRotY1_002417677 = (double)(checked((int)(_0024_0024locals_002417700._0024parent.localEulerAngles.y * 1000f)) % 360000) * 0.001;
							if (!(_0024tmpParentRotY1_002417677 >= 0.0))
							{
								_0024tmpParentRotY1_002417677 += 360.0;
							}
							_0024_0024locals_002417700._0024rotY = (float)((double)(checked((int)(_0024_0024locals_002417700._0024rotY * 1000f)) % 360000) * 0.001);
							if (!(_0024_0024locals_002417700._0024rotY >= 0f))
							{
								_0024_0024locals_002417700._0024rotY += 360f;
							}
							_0024rotSign_002417678 = RotDir.Left;
							_0024lastRot_002417679 = (float)((double)_0024_0024locals_002417700._0024rotY - _0024tmpParentRotY1_002417677);
							_0024curRot_002417680 = _0024lastRot_002417679;
							_0024totalRot_002417681 = 0f;
							if (!(0f >= _0024lastRot_002417679) && !(_0024lastRot_002417679 > 180f))
							{
								_0024rotSign_002417678 = RotDir.Left;
								_0024totalRot_002417681 = _0024lastRot_002417679;
							}
							else if (!(-360f >= _0024lastRot_002417679) && !(_0024lastRot_002417679 > -180f))
							{
								_0024rotSign_002417678 = RotDir.Left;
								_0024totalRot_002417681 = 360f + _0024lastRot_002417679;
							}
							else if (!(-180f >= _0024lastRot_002417679) && !(_0024lastRot_002417679 >= 0f))
							{
								_0024rotSign_002417678 = RotDir.Right;
								_0024totalRot_002417681 = _0024lastRot_002417679;
							}
							else if (!(180f >= _0024lastRot_002417679) && !(_0024lastRot_002417679 >= 360f))
							{
								_0024rotSign_002417678 = RotDir.Right;
								_0024totalRot_002417681 = 360f - _0024lastRot_002417679;
							}
							else
							{
								_0024rotSign_002417678 = RotDir.None;
								_0024totalRot_002417681 = 0f;
							}
							if (_0024rotSpeed_002417666 == 0f)
							{
								if (RuntimeServices.EqualityOperator(_0024msecMode_002417667, 1))
								{
									_0024rotSpeed_002417666 = 1000f;
								}
								else
								{
									_0024rotSpeed_002417666 = 1f;
								}
							}
							_0024totalRot_002417681 = Math.Abs(_0024totalRot_002417681);
							if (RuntimeServices.EqualityOperator(_0024msecMode_002417667, 1) && _0024rotSpeed_002417666 != 0f)
							{
								_0024rotSpeed_002417666 = _0024totalRot_002417681 * 1000f / _0024rotSpeed_002417666;
							}
							_0024rotSpeed_002417666 *= (float)_0024rotSign_002417678;
							_0024tmpMoveWait_002417682 = 1;
							_0024self__002417702.moveWaitCount = checked(_0024self__002417702.moveWaitCount + _0024tmpMoveWait_002417682);
							_0024_0024locals_002417700._0024lastMoveWaitCount = _0024self__002417702.moveWaitCount;
							_0024n_002417683 = 0;
							_0024arrive_002417684 = new _0024ROTATE_TARGET_core_0024arrive_00243803(_0024_002412443_002417690, _0024self__002417702, _0024_0024locals_002417700, _0024_002412444_002417691).Invoke;
							if (_0024_0024locals_002417700._0024motionName == _0024_0024locals_002417700._0024idlingName)
							{
								_0024self__002417702.StartCoroutine("NEXT_MOTION_core", new Hash
								{
									{ "arg1", _0024_0024locals_002417700._0024target },
									{ "arg2", _0024_0024locals_002417700._0024idlingName },
									{ "arg3", "0" }
								});
							}
							goto case 2;
						}
					}
					goto case 1;
				}
				case 2:
				case 3:
					if (_0024self__002417702.exec && _0024_0024locals_002417700._0024target.activeSelf)
					{
						_0024self__002417702.AnimSpeedCtrl(_0024_0024locals_002417700._0024target);
						if (!_0024self__002417702.localPlayFlag)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024self__002417702.checkAnimIdentity(_0024_0024locals_002417700._0024target, _0024aid_002417676))
						{
							if (_0024_0024locals_002417700._0024willAnimated)
							{
							}
							_0024_0024locals_002417700._0024willAnimated = false;
						}
						if (_0024tmpMoveWait_002417682 != 0)
						{
							if (!_0024anim_002417668)
							{
								_0024anim_002417668 = _0024_0024locals_002417700._0024target.GetComponentInChildren<Animation>();
								if (!_0024anim_002417668)
								{
									goto IL_0cfd;
								}
							}
							_0024tmpParentRotY1_002417677 = (double)(checked((int)(_0024_0024locals_002417700._0024parent.localEulerAngles.y * 1000f)) % 360000) * 0.001;
							if (!(_0024tmpParentRotY1_002417677 >= 0.0))
							{
								_0024tmpParentRotY1_002417677 += 360.0;
							}
							_0024curRot_002417680 = (float)((double)_0024_0024locals_002417700._0024rotY - _0024tmpParentRotY1_002417677);
							_0024d_002417685 = _0024self__002417702.animSpeed * _0024rotSpeed_002417666 * Time.deltaTime;
							if (_0024tmpMoveWait_002417682 > 0)
							{
								if (_0024totalRot_002417681 - Math.Abs(_0024d_002417685) > 0f)
								{
									float num7 = (_0024_002412449_002417696 = _0024_0024locals_002417700._0024parent.localEulerAngles.y + _0024d_002417685);
									Vector3 vector10 = (_0024_002412450_002417697 = _0024_0024locals_002417700._0024parent.localEulerAngles);
									float num8 = (_0024_002412450_002417697.y = _0024_002412449_002417696);
									Vector3 vector12 = (_0024_0024locals_002417700._0024parent.localEulerAngles = _0024_002412450_002417697);
								}
								else if (_0024d_002417685 <= 0f)
								{
									float num9 = (_0024_002412447_002417694 = _0024_0024locals_002417700._0024parent.localEulerAngles.y - _0024totalRot_002417681);
									Vector3 vector13 = (_0024_002412448_002417695 = _0024_0024locals_002417700._0024parent.localEulerAngles);
									float num10 = (_0024_002412448_002417695.y = _0024_002412447_002417694);
									Vector3 vector15 = (_0024_0024locals_002417700._0024parent.localEulerAngles = _0024_002412448_002417695);
								}
								else
								{
									float num11 = (_0024_002412445_002417692 = _0024_0024locals_002417700._0024parent.localEulerAngles.y + _0024totalRot_002417681);
									Vector3 vector16 = (_0024_002412446_002417693 = _0024_0024locals_002417700._0024parent.localEulerAngles);
									float num12 = (_0024_002412446_002417693.y = _0024_002412445_002417692);
									Vector3 vector18 = (_0024_0024locals_002417700._0024parent.localEulerAngles = _0024_002412446_002417693);
								}
								_0024totalRot_002417681 -= Math.Abs(_0024d_002417685);
							}
							checked
							{
								if ((!(_0024totalRot_002417681 <= 0f) && _0024rotSpeed_002417666 != 0f) || _0024tmpMoveWait_002417682 <= 0)
								{
									if (_0024tmpMoveWait_002417682 > 0 && _0024self__002417702.isAnimEnd(_0024anim_002417668, _0024mmpc_002417669))
									{
										_0024self__002417702.AnimPlay(_0024_0024locals_002417700._0024target, _0024_0024locals_002417700._0024motionName, forceLoop: true);
									}
									_0024lastRot_002417679 = _0024curRot_002417680;
									_0024n_002417683++;
									result = (Yield(3, new WaitForFixedUpdate()) ? 1 : 0);
									break;
								}
								_0024arrive_002417684();
							}
						}
					}
					goto IL_0cfd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0cfd:
					if ((bool)_0024_0024locals_002417700._0024parent)
					{
						float num5 = (_0024_002412451_002417698 = _0024_0024locals_002417700._0024rotY);
						Vector3 vector7 = (_0024_002412452_002417699 = _0024_0024locals_002417700._0024parent.localEulerAngles);
						float num6 = (_0024_002412452_002417699.y = _0024_002412451_002417698);
						Vector3 vector9 = (_0024_0024locals_002417700._0024parent.localEulerAngles = _0024_002412452_002417699);
					}
					_0024self__002417702.moveWaitCount = checked(_0024self__002417702.moveWaitCount - _0024tmpMoveWait_002417682);
					_0024tmpMoveWait_002417682 = 0;
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417703;

		internal CutSceneManager _0024self__002417704;

		public _0024ROTATE_TARGET_core_002417665(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417703 = arg;
			_0024self__002417704 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024arg_002417703, _0024self__002417704);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_ROTATE_002417705 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417706;

			internal float _0024msec_002417707;

			internal GameObject _0024target_002417708;

			internal Coroutine _0024_0024sco_0024temp_00241536_002417709;

			internal Hashtable _0024arg_002417710;

			internal CutSceneManager _0024self__002417711;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417710 = arg;
				_0024self__002417711 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417706 = _0024arg_002417710["arg1"];
					object obj = _0024arg_002417710["arg6"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024msec_002417707 = float.Parse((string)obj);
					object obj2 = _0024targetName_002417706;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024target_002417708 = GameObject.Find((string)obj2) as GameObject;
					if (!_0024target_002417708)
					{
						_0024target_002417708 = GameObject.Find(_0024targetName_002417706 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417708)
					{
						goto case 1;
					}
					_0024arg_002417710["arg1"] = _0024target_002417708;
					_0024arg_002417710["arg8"] = 0;
					_0024_0024sco_0024temp_00241536_002417709 = _0024self__002417711.StartCoroutine("MOVE_ROTATE_core", _0024arg_002417710);
					if (_0024_0024sco_0024temp_00241536_002417709 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241536_002417709) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417712;

		internal CutSceneManager _0024self__002417713;

		public _0024MOVE_ROTATE_002417705(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417712 = arg;
			_0024self__002417713 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417712, _0024self__002417713);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_ROTATE_FOR_CUTSCENE_OBJID_002417714 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417715;

			internal GameObject _0024target_002417716;

			internal Coroutine _0024_0024sco_0024temp_00241537_002417717;

			internal Hashtable _0024arg_002417718;

			internal CutSceneManager _0024self__002417719;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417718 = arg;
				_0024self__002417719 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417715 = _0024arg_002417718["arg1"];
					object obj = _0024cutSceneObjId_002417715;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417716 = FindCutSceneObject((string)obj);
					_0024arg_002417718["arg1"] = _0024target_002417716;
					_0024arg_002417718["arg8"] = 0;
					_0024_0024sco_0024temp_00241537_002417717 = _0024self__002417719.StartCoroutine("MOVE_ROTATE_core", _0024arg_002417718);
					if (_0024_0024sco_0024temp_00241537_002417717 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241537_002417717) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417720;

		internal CutSceneManager _0024self__002417721;

		public _0024MOVE_ROTATE_FOR_CUTSCENE_OBJID_002417714(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417720 = arg;
			_0024self__002417721 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417720, _0024self__002417721);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_ROTATE_OVERTIME_002417722 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417723;

			internal float _0024msec_002417724;

			internal GameObject _0024target_002417725;

			internal Coroutine _0024_0024sco_0024temp_00241538_002417726;

			internal Hashtable _0024arg_002417727;

			internal CutSceneManager _0024self__002417728;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417727 = arg;
				_0024self__002417728 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417723 = _0024arg_002417727["arg1"];
					object obj = _0024arg_002417727["arg6"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024msec_002417724 = float.Parse((string)obj);
					object obj2 = _0024targetName_002417723;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024target_002417725 = GameObject.Find((string)obj2) as GameObject;
					if (!_0024target_002417725)
					{
						_0024target_002417725 = GameObject.Find(_0024targetName_002417723 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417725)
					{
						goto case 1;
					}
					_0024arg_002417727["arg1"] = _0024target_002417725;
					_0024arg_002417727["arg8"] = 1;
					_0024_0024sco_0024temp_00241538_002417726 = _0024self__002417728.StartCoroutine("MOVE_ROTATE_core", _0024arg_002417727);
					if (_0024_0024sco_0024temp_00241538_002417726 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241538_002417726) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417729;

		internal CutSceneManager _0024self__002417730;

		public _0024MOVE_ROTATE_OVERTIME_002417722(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417729 = arg;
			_0024self__002417730 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417729, _0024self__002417730);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_ROTATE_OVERTIME_FOR_CUTSCENE_OBJID_002417731 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417732;

			internal GameObject _0024target_002417733;

			internal Coroutine _0024_0024sco_0024temp_00241539_002417734;

			internal Hashtable _0024arg_002417735;

			internal CutSceneManager _0024self__002417736;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417735 = arg;
				_0024self__002417736 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417732 = _0024arg_002417735["arg1"];
					object obj = _0024cutSceneObjId_002417732;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417733 = FindCutSceneObject((string)obj);
					_0024arg_002417735["arg1"] = _0024target_002417733;
					_0024arg_002417735["arg8"] = 1;
					_0024_0024sco_0024temp_00241539_002417734 = _0024self__002417736.StartCoroutine("MOVE_ROTATE_core", _0024arg_002417735);
					if (_0024_0024sco_0024temp_00241539_002417734 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241539_002417734) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417737;

		internal CutSceneManager _0024self__002417738;

		public _0024MOVE_ROTATE_OVERTIME_FOR_CUTSCENE_OBJID_002417731(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417737 = arg;
			_0024self__002417738 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417737, _0024self__002417738);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_ROTATE_core_002417739 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024posX_002417740;

			internal float _0024posZ_002417741;

			internal float _0024movWait_002417742;

			internal object _0024msecMode_002417743;

			internal float _0024rotSpeed_002417744;

			internal float _0024vel_002417745;

			internal Animation _0024anim_002417746;

			internal MerlinMotionPackControl _0024mmpc_002417747;

			internal string _0024lastAnim_002417748;

			internal Hashtable _0024orgX_002417749;

			internal Hashtable _0024orgZ_002417750;

			internal Hashtable _0024orgRotY_002417751;

			internal Hashtable _0024orgAnim_002417752;

			internal Transform _0024yAng_002417753;

			internal Hashtable _0024orgRotY2_002417754;

			internal Hashtable _0024orgRotY3_002417755;

			internal int _0024aid_002417756;

			internal Vector3 _0024vec_002417757;

			internal float _0024lastMag_002417758;

			internal float _0024curMag_002417759;

			internal float _0024duration_002417760;

			internal double _0024tmpParentRotY1_002417761;

			internal RotDir _0024rotSign_002417762;

			internal float _0024lastRot_002417763;

			internal float _0024curRot_002417764;

			internal float _0024totalRot_002417765;

			internal int _0024tmpMoveWait_002417766;

			internal int _0024tmpPosWait_002417767;

			internal int _0024tmpRotWait_002417768;

			internal float _0024elapsed_002417769;

			internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024arrive_002417770;

			internal double _0024speedRate_002417771;

			internal Vector3 _0024v_002417772;

			internal float _0024d_002417773;

			internal int _0024_002412453_002417774;

			internal Vector3 _0024_002412454_002417775;

			internal int _0024_002412455_002417776;

			internal Vector3 _0024_002412456_002417777;

			internal float _0024_002412457_002417778;

			internal Vector3 _0024_002412458_002417779;

			internal float _0024_002412459_002417780;

			internal Vector3 _0024_002412460_002417781;

			internal float _0024_002412461_002417782;

			internal Vector3 _0024_002412462_002417783;

			internal float _0024_002412463_002417784;

			internal Vector3 _0024_002412464_002417785;

			internal float _0024_002412465_002417786;

			internal Vector3 _0024_002412466_002417787;

			internal float _0024_002412467_002417788;

			internal Vector3 _0024_002412468_002417789;

			internal float _0024_002412469_002417790;

			internal Vector3 _0024_002412470_002417791;

			internal _0024MOVE_ROTATE_core_0024locals_002414393 _0024_0024locals_002417792;

			internal Hashtable _0024arg_002417793;

			internal CutSceneManager _0024self__002417794;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417793 = arg;
				_0024self__002417794 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024locals_002417792 = new _0024MOVE_ROTATE_core_0024locals_002414393();
					_0024MOVE_ROTATE_core_0024locals_002414393 _0024MOVE_ROTATE_core_0024locals_0024 = _0024_0024locals_002417792;
					object obj = _0024arg_002417793["arg1"];
					if (!(obj is GameObject))
					{
						obj = RuntimeServices.Coerce(obj, typeof(GameObject));
					}
					_0024MOVE_ROTATE_core_0024locals_0024._0024target = (GameObject)obj;
					_0024MOVE_ROTATE_core_0024locals_002414393 _0024MOVE_ROTATE_core_0024locals_00242 = _0024_0024locals_002417792;
					object obj2 = _0024arg_002417793["arg2"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024MOVE_ROTATE_core_0024locals_00242._0024motionName = (string)obj2;
					_0024MOVE_ROTATE_core_0024locals_002414393 _0024MOVE_ROTATE_core_0024locals_00243 = _0024_0024locals_002417792;
					object obj3 = _0024arg_002417793["arg3"];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					_0024MOVE_ROTATE_core_0024locals_00243._0024idlingName = (string)obj3;
					object obj4 = _0024arg_002417793["arg4"];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					_0024posX_002417740 = float.Parse((string)obj4);
					object obj5 = _0024arg_002417793["arg5"];
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					_0024posZ_002417741 = float.Parse((string)obj5);
					_0024MOVE_ROTATE_core_0024locals_002414393 _0024MOVE_ROTATE_core_0024locals_00244 = _0024_0024locals_002417792;
					object obj6 = _0024arg_002417793["arg6"];
					if (!(obj6 is string))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(string));
					}
					_0024MOVE_ROTATE_core_0024locals_00244._0024rotY = float.Parse((string)obj6);
					object obj7 = _0024arg_002417793["arg7"];
					if (!(obj7 is string))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(string));
					}
					_0024movWait_002417742 = float.Parse((string)obj7);
					_0024msecMode_002417743 = _0024arg_002417793["arg8"];
					_0024rotSpeed_002417744 = 0f;
					_0024vel_002417745 = 0f;
					if ((bool)_0024_0024locals_002417792._0024target)
					{
						_0024anim_002417746 = _0024self__002417794._getAnim(_0024_0024locals_002417792._0024target);
						_0024mmpc_002417747 = _0024self__002417794._getMMPC(_0024_0024locals_002417792._0024target);
						if ((bool)_0024anim_002417746)
						{
							_0024_0024locals_002417792._0024parent = _0024_0024locals_002417792._0024target.transform;
							_0024lastAnim_002417748 = null;
							if ((bool)_0024anim_002417746.clip)
							{
								_0024lastAnim_002417748 = _0024anim_002417746.clip.name;
							}
							_0024orgX_002417749 = new Hashtable();
							_0024orgZ_002417750 = new Hashtable();
							_0024orgRotY_002417751 = new Hashtable();
							_0024orgX_002417749 = new Hash
							{
								{ "cmd", "target.transform.localPosition.x" },
								{
									"obj",
									_0024_0024locals_002417792._0024parent.gameObject
								},
								{
									"val",
									_0024_0024locals_002417792._0024parent.localPosition.x
								}
							};
							_0024orgZ_002417750 = new Hash
							{
								{ "cmd", "target.transform.localPosition.z" },
								{
									"obj",
									_0024_0024locals_002417792._0024parent.gameObject
								},
								{
									"val",
									_0024_0024locals_002417792._0024parent.localPosition.z
								}
							};
							_0024orgRotY_002417751 = new Hash
							{
								{ "cmd", "target.transform.localEulerAngles.y" },
								{
									"obj",
									_0024_0024locals_002417792._0024parent.gameObject
								},
								{
									"val",
									_0024_0024locals_002417792._0024parent.localEulerAngles.y
								}
							};
							_0024self__002417794.orgDataStack.Push(_0024orgX_002417749);
							_0024self__002417794.orgDataStack.Push(_0024orgZ_002417750);
							_0024self__002417794.orgDataStack.Push(_0024orgRotY_002417751);
							_0024orgAnim_002417752 = new Hashtable();
							_0024orgAnim_002417752 = new Hash
							{
								{ "cmd", "target.Animation" },
								{ "obj", _0024_0024locals_002417792._0024target },
								{ "val", _0024lastAnim_002417748 }
							};
							_0024self__002417794.orgDataStack.Push(_0024orgAnim_002417752);
							_0024yAng_002417753 = ObjUtilModule.Find1stDescendant(_0024_0024locals_002417792._0024target.transform, "y_ang");
							if ((bool)_0024yAng_002417753)
							{
								if (_0024_0024locals_002417792._0024parent != _0024yAng_002417753.parent)
								{
									_0024orgRotY2_002417754 = new Hashtable();
									_0024orgRotY2_002417754 = new Hash
									{
										{ "cmd", "target.transform.localEulerAngles.y" },
										{
											"obj",
											_0024yAng_002417753.parent.gameObject
										},
										{
											"val",
											_0024yAng_002417753.parent.localEulerAngles.y
										}
									};
									_0024self__002417794.orgDataStack.Push(_0024orgRotY2_002417754);
									if ((bool)_0024yAng_002417753.parent)
									{
										int num = (_0024_002412453_002417774 = 0);
										Vector3 vector = (_0024_002412454_002417775 = _0024yAng_002417753.parent.localEulerAngles);
										float num2 = (_0024_002412454_002417775.y = _0024_002412453_002417774);
										Vector3 vector3 = (_0024yAng_002417753.parent.localEulerAngles = _0024_002412454_002417775);
									}
								}
								if (_0024_0024locals_002417792._0024parent != _0024yAng_002417753)
								{
									_0024orgRotY3_002417755 = new Hashtable();
									_0024orgRotY3_002417755 = new Hash
									{
										{ "cmd", "target.transform.localEulerAngles.y" },
										{ "obj", _0024yAng_002417753.gameObject },
										{
											"val",
											_0024yAng_002417753.localEulerAngles.y
										}
									};
									_0024self__002417794.orgDataStack.Push(_0024orgRotY3_002417755);
									int num3 = (_0024_002412455_002417776 = 0);
									Vector3 vector4 = (_0024_002412456_002417777 = _0024yAng_002417753.localEulerAngles);
									float num4 = (_0024_002412456_002417777.y = _0024_002412455_002417776);
									Vector3 vector6 = (_0024yAng_002417753.localEulerAngles = _0024_002412456_002417777);
								}
							}
							_0024_0024locals_002417792._0024willAnimated = true;
							if (_0024self__002417794.isPlayingAnim(_0024_0024locals_002417792._0024target, _0024_0024locals_002417792._0024motionName))
							{
								_0024aid_002417756 = _0024self__002417794.getCurrentAnimIdentity(_0024_0024locals_002417792._0024target);
							}
							else
							{
								_0024aid_002417756 = _0024self__002417794.registerAnimIdentity(_0024_0024locals_002417792._0024target);
								_0024self__002417794.AnimPlay(_0024_0024locals_002417792._0024target, _0024_0024locals_002417792._0024motionName, forceLoop: false);
							}
							_0024_0024locals_002417792._0024pos = new Vector3(_0024posX_002417740, _0024_0024locals_002417792._0024parent.position.y, _0024posZ_002417741);
							_0024vec_002417757 = _0024_0024locals_002417792._0024pos - _0024_0024locals_002417792._0024parent.position;
							_0024vec_002417757.y = 0f;
							_0024lastMag_002417758 = _0024vec_002417757.magnitude;
							_0024curMag_002417759 = 0f;
							_0024vel_002417745 = _0024lastMag_002417758;
							if (!(_0024movWait_002417742 <= 0f))
							{
								_0024vel_002417745 = _0024vel_002417745 * 1000f / _0024movWait_002417742;
							}
							_0024duration_002417760 = _0024movWait_002417742 / 1000f;
							_0024tmpParentRotY1_002417761 = (double)(checked((int)(_0024_0024locals_002417792._0024parent.localEulerAngles.y * 1000f)) % 360000) * 0.001;
							if (!(_0024tmpParentRotY1_002417761 >= 0.0))
							{
								_0024tmpParentRotY1_002417761 += 360.0;
							}
							_0024_0024locals_002417792._0024rotY = (float)((double)(checked((int)(_0024_0024locals_002417792._0024rotY * 1000f)) % 360000) * 0.001);
							if (!(_0024_0024locals_002417792._0024rotY >= 0f))
							{
								_0024_0024locals_002417792._0024rotY += 360f;
							}
							_0024rotSign_002417762 = RotDir.Left;
							_0024lastRot_002417763 = (float)((double)_0024_0024locals_002417792._0024rotY - _0024tmpParentRotY1_002417761);
							_0024curRot_002417764 = _0024lastRot_002417763;
							_0024totalRot_002417765 = 0f;
							if (!(0f >= _0024lastRot_002417763) && !(_0024lastRot_002417763 > 180f))
							{
								_0024rotSign_002417762 = RotDir.Left;
								_0024totalRot_002417765 = _0024lastRot_002417763;
							}
							else if (!(-360f >= _0024lastRot_002417763) && !(_0024lastRot_002417763 > -180f))
							{
								_0024rotSign_002417762 = RotDir.Left;
								_0024totalRot_002417765 = 360f + _0024lastRot_002417763;
							}
							else if (!(-180f >= _0024lastRot_002417763) && !(_0024lastRot_002417763 >= 0f))
							{
								_0024rotSign_002417762 = RotDir.Right;
								_0024totalRot_002417765 = _0024lastRot_002417763;
							}
							else if (!(180f >= _0024lastRot_002417763) && !(_0024lastRot_002417763 >= 360f))
							{
								_0024rotSign_002417762 = RotDir.Right;
								_0024totalRot_002417765 = 360f - _0024lastRot_002417763;
							}
							else
							{
								_0024rotSign_002417762 = RotDir.None;
								_0024totalRot_002417765 = 0f;
							}
							_0024totalRot_002417765 = Math.Abs(_0024totalRot_002417765);
							if (_0024rotSpeed_002417744 == 0f)
							{
								if (RuntimeServices.EqualityOperator(_0024msecMode_002417743, 1))
								{
									_0024rotSpeed_002417744 = _0024movWait_002417742;
								}
								else
								{
									_0024rotSpeed_002417744 = 1f;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024msecMode_002417743, 1) && _0024rotSpeed_002417744 != 0f)
							{
								_0024rotSpeed_002417744 = _0024totalRot_002417765 * 1000f / _0024rotSpeed_002417744;
							}
							_0024rotSpeed_002417744 *= (float)_0024rotSign_002417762;
							_0024tmpMoveWait_002417766 = 1;
							_0024tmpPosWait_002417767 = 1;
							_0024tmpRotWait_002417768 = 1;
							_0024self__002417794.moveWaitCount = checked(_0024self__002417794.moveWaitCount + _0024tmpMoveWait_002417766);
							_0024_0024locals_002417792._0024lastMoveWaitCount = _0024self__002417794.moveWaitCount;
							_0024_0024locals_002417792._0024cc = (CharacterController)_0024_0024locals_002417792._0024target.GetComponent(typeof(CharacterController));
							_0024elapsed_002417769 = 0f;
							_0024arrive_002417770 = new _0024MOVE_ROTATE_core_0024arrive_00243804(_0024_002412457_002417778, _0024_0024locals_002417792, _0024_002412462_002417783, _0024_002412461_002417782, _0024_002412460_002417781, _0024self__002417794, _0024_002412458_002417779, _0024_002412459_002417780).Invoke;
							if (_0024_0024locals_002417792._0024motionName == _0024_0024locals_002417792._0024idlingName)
							{
								_0024self__002417794.StartCoroutine("NEXT_MOTION_core", new Hash
								{
									{ "arg1", _0024_0024locals_002417792._0024target },
									{ "arg2", _0024_0024locals_002417792._0024idlingName },
									{ "arg3", "0" }
								});
							}
							goto case 2;
						}
					}
					goto case 1;
				}
				case 2:
				case 3:
					if (_0024self__002417794.exec && _0024_0024locals_002417792._0024target.activeSelf)
					{
						_0024self__002417794.AnimSpeedCtrl(_0024_0024locals_002417792._0024target);
						if (!_0024self__002417794.localPlayFlag)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024self__002417794.checkAnimIdentity(_0024_0024locals_002417792._0024target, _0024aid_002417756))
						{
							if (_0024_0024locals_002417792._0024willAnimated)
							{
							}
							_0024_0024locals_002417792._0024willAnimated = false;
						}
						if (_0024tmpMoveWait_002417766 != 0)
						{
							if (!_0024anim_002417746)
							{
								_0024anim_002417746 = _0024_0024locals_002417792._0024target.GetComponentInChildren<Animation>();
								if (!_0024anim_002417746)
								{
									goto IL_1096;
								}
							}
							_0024speedRate_002417771 = 0.001;
							if (RuntimeServices.EqualityOperator(_0024msecMode_002417743, 1))
							{
								_0024speedRate_002417771 = Time.deltaTime;
							}
							_0024elapsed_002417769 += Time.deltaTime * _0024self__002417794.animSpeed;
							if (_0024tmpPosWait_002417767 > 0)
							{
								_0024vec_002417757 = _0024_0024locals_002417792._0024pos - _0024_0024locals_002417792._0024parent.position;
								_0024curMag_002417759 = _0024vec_002417757.magnitude;
								_0024v_002417772 = _0024vel_002417745 * _0024vec_002417757.normalized * _0024self__002417794.animSpeed;
								if (!((double)_0024v_002417772.magnitude * _0024speedRate_002417771 <= (double)_0024vec_002417757.magnitude))
								{
									_0024vel_002417745 = 0f;
								}
								else if (_0024_0024locals_002417792._0024cc != null && _0024_0024locals_002417792._0024cc.enabled)
								{
									if (_0024curMag_002417759 != 0f)
									{
										_0024_0024locals_002417792._0024cc.SimpleMove(_0024v_002417772);
									}
								}
								else if (_0024curMag_002417759 != 0f)
								{
									_0024_0024locals_002417792._0024parent.position = _0024_0024locals_002417792._0024parent.position + _0024v_002417772 * (float)_0024speedRate_002417771;
								}
								if (!(_0024curMag_002417759 >= 0.05f) && !(_0024elapsed_002417769 < _0024duration_002417760))
								{
									_0024tmpPosWait_002417767 = 0;
								}
								if (!(_0024lastMag_002417758 > _0024curMag_002417759) && !(_0024elapsed_002417769 < _0024duration_002417760))
								{
									_0024tmpPosWait_002417767 = 0;
								}
							}
							if (_0024tmpRotWait_002417768 > 0)
							{
								_0024tmpParentRotY1_002417761 = (double)(checked((int)(_0024_0024locals_002417792._0024parent.localEulerAngles.y * 1000f)) % 360000) * 0.001;
								if (!(_0024tmpParentRotY1_002417761 >= 0.0))
								{
									_0024tmpParentRotY1_002417761 += 360.0;
								}
								_0024curRot_002417764 = (float)((double)_0024_0024locals_002417792._0024rotY - _0024tmpParentRotY1_002417761);
								_0024d_002417773 = _0024self__002417794.animSpeed * _0024rotSpeed_002417744 * Time.deltaTime;
								float num11 = (_0024_002412463_002417784 = _0024_0024locals_002417792._0024parent.localEulerAngles.y + _0024d_002417773);
								Vector3 vector16 = (_0024_002412464_002417785 = _0024_0024locals_002417792._0024parent.localEulerAngles);
								float num12 = (_0024_002412464_002417785.y = _0024_002412463_002417784);
								Vector3 vector18 = (_0024_0024locals_002417792._0024parent.localEulerAngles = _0024_002412464_002417785);
								_0024totalRot_002417765 -= Math.Abs(_0024d_002417773);
								if (_0024totalRot_002417765 <= 0f || _0024rotSpeed_002417744 == 0f)
								{
									_0024tmpRotWait_002417768 = 0;
								}
							}
							if (_0024tmpPosWait_002417767 == 0 && _0024tmpRotWait_002417768 == 0 && _0024tmpMoveWait_002417766 > 0)
							{
								_0024arrive_002417770();
							}
							else
							{
								if ((double)_0024elapsed_002417769 < (double)_0024duration_002417760 * 1.2)
								{
									if (_0024tmpMoveWait_002417766 > 0 && _0024self__002417794.isAnimEnd(_0024anim_002417746, _0024mmpc_002417747))
									{
										_0024self__002417794.AnimPlay(_0024_0024locals_002417792._0024target, _0024_0024locals_002417792._0024motionName, forceLoop: true);
									}
									_0024lastMag_002417758 = _0024curMag_002417759;
									_0024lastRot_002417763 = _0024curRot_002417764;
									result = (Yield(3, new WaitForFixedUpdate()) ? 1 : 0);
									break;
								}
								_0024arrive_002417770();
							}
						}
					}
					goto IL_1096;
				case 1:
					{
						result = 0;
						break;
					}
					IL_1096:
					if ((bool)_0024_0024locals_002417792._0024parent)
					{
						float num5 = (_0024_002412465_002417786 = _0024_0024locals_002417792._0024rotY);
						Vector3 vector7 = (_0024_002412466_002417787 = _0024_0024locals_002417792._0024parent.localEulerAngles);
						float num6 = (_0024_002412466_002417787.y = _0024_002412465_002417786);
						Vector3 vector9 = (_0024_0024locals_002417792._0024parent.localEulerAngles = _0024_002412466_002417787);
						float num7 = (_0024_002412467_002417788 = _0024_0024locals_002417792._0024pos.x);
						Vector3 vector10 = (_0024_002412468_002417789 = _0024_0024locals_002417792._0024parent.position);
						float num8 = (_0024_002412468_002417789.x = _0024_002412467_002417788);
						Vector3 vector12 = (_0024_0024locals_002417792._0024parent.position = _0024_002412468_002417789);
						float num9 = (_0024_002412469_002417790 = _0024_0024locals_002417792._0024pos.z);
						Vector3 vector13 = (_0024_002412470_002417791 = _0024_0024locals_002417792._0024parent.position);
						float num10 = (_0024_002412470_002417791.z = _0024_002412469_002417790);
						Vector3 vector15 = (_0024_0024locals_002417792._0024parent.position = _0024_002412470_002417791);
						if (_0024_0024locals_002417792._0024cc != null && _0024_0024locals_002417792._0024cc.enabled)
						{
							_0024self__002417794.standGround(_0024_0024locals_002417792._0024target);
						}
					}
					_0024self__002417794.moveWaitCount = checked(_0024self__002417794.moveWaitCount - _0024tmpMoveWait_002417766);
					_0024tmpMoveWait_002417766 = 0;
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417795;

		internal CutSceneManager _0024self__002417796;

		public _0024MOVE_ROTATE_core_002417739(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417795 = arg;
			_0024self__002417796 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024arg_002417795, _0024self__002417796);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PLAYER_CHR_INIT_core_002417797 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __CutSceneManager_PLAYER_CHR_INIT_core_0024callable167_00243222_13__ _0024_spawn_002417798;

			internal GameObject _0024target_002417799;

			internal UserData _0024ud_002417800;

			internal RespPlayerInfo _0024ui_002417801;

			internal string _0024angelPrefabName_002417802;

			internal string _0024demonPrefabName_002417803;

			internal IEnumerator _0024_0024sco_0024temp_00241551_002417804;

			internal IEnumerator _0024_0024sco_0024temp_00241552_002417805;

			internal PlayerControl _0024pc_002417806;

			internal Transform _0024m_002417807;

			internal IEnumerator _0024_0024iterator_002413611_002417808;

			internal _0024PLAYER_CHR_INIT_core_0024locals_002414394 _0024_0024locals_002417809;

			internal Hashtable _0024arg_002417810;

			internal CutSceneManager _0024self__002417811;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417810 = arg;
				_0024self__002417811 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024locals_002417809 = new _0024PLAYER_CHR_INIT_core_0024locals_002414394();
					if (_0024self__002417811.isDummyPlayerInitialized)
					{
						goto case 1;
					}
					_0024_0024locals_002417809._0024spawnIsBusy = false;
					_0024_spawn_002417798 = new _0024PLAYER_CHR_INIT_core_0024_spawn_00243808(_0024self__002417811, _0024_0024locals_002417809).Invoke;
					object obj2 = _0024arg_002417810["arg1"];
					if (!(obj2 is GameObject))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
					}
					_0024target_002417799 = (GameObject)obj2;
					if (!_0024target_002417799)
					{
					}
					_0024ud_002417800 = UserData.Current;
					_0024ui_002417801 = _0024ud_002417800.userStatus;
					if (_0024self__002417811.useDummyPlayer)
					{
						_0024angelPrefabName_002417802 = ((_0024ui_002417801.AngelGender != 2) ? _0024self__002417811.angelFemalePrefabName : _0024self__002417811.angelMalePrefabName);
						_0024demonPrefabName_002417803 = ((_0024ui_002417801.DemonGender != 2) ? _0024self__002417811.demonFemalePrefabName : _0024self__002417811.demonMalePrefabName);
						_0024_0024locals_002417809._0024spawnIsBusy = true;
						_0024_0024sco_0024temp_00241551_002417804 = _0024_spawn_002417798(new StringBuilder().Append(_0024angelPrefabName_002417802).ToString(), _0024self__002417811.angelGOName);
						if (_0024_0024sco_0024temp_00241551_002417804 != null)
						{
							result = (Yield(2, _0024self__002417811.StartCoroutine(_0024_0024sco_0024temp_00241551_002417804)) ? 1 : 0);
							break;
						}
						goto case 2;
					}
					goto IL_0256;
				}
				case 2:
				case 3:
					if (_0024_0024locals_002417809._0024spawnIsBusy)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024_0024locals_002417809._0024spawnIsBusy = true;
					_0024_0024sco_0024temp_00241552_002417805 = _0024_spawn_002417798(new StringBuilder().Append(_0024demonPrefabName_002417803).ToString(), _0024self__002417811.demonGOName);
					if (_0024_0024sco_0024temp_00241552_002417805 != null)
					{
						result = (Yield(4, _0024self__002417811.StartCoroutine(_0024_0024sco_0024temp_00241552_002417805)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
				case 5:
					if (_0024_0024locals_002417809._0024spawnIsBusy)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_0256;
				case 6:
					_0024self__002417811.SetupComponentForCutSceneAnim(_0024target_002417799);
					_0024self__002417811.storeObjTransform(_0024target_002417799);
					_0024_0024iterator_002413611_002417808 = _0024self__002417811.playerChar[0].transform.GetEnumerator();
					while (_0024_0024iterator_002413611_002417808.MoveNext())
					{
						object obj = _0024_0024iterator_002413611_002417808.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						_0024m_002417807 = (Transform)obj;
						_0024m_002417807.localPosition = Vector3.zero;
					}
					_0024self__002417811.isDummyPlayerInitialized = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0256:
					_0024self__002417811.playerChar[0] = GameObject.Find(new StringBuilder("/").Append(_0024self__002417811.playerCharName).ToString());
					if (!_0024self__002417811.playerChar[0])
					{
						_0024self__002417811.playerChar[0] = PlayerControl.CurrentPlayer.gameObject;
					}
					PlayerControl.CurrentPlayer.battleMode = PlayerControl.BATTLE_MODE.Non_Battle;
					PlayerControl.CurrentPlayer.forceToIdle();
					_0024pc_002417806 = PlayerControl.CurrentPlayer;
					_0024pc_002417806.NOUTOU(0f);
					_0024self__002417811.standGround(_0024pc_002417806.gameObject);
					result = (YieldDefault(6) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417812;

		internal CutSceneManager _0024self__002417813;

		public _0024PLAYER_CHR_INIT_core_002417797(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417812 = arg;
			_0024self__002417813 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417812, _0024self__002417813);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SUMMON_POPPET_core_002417814 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PoppetFactory _0024pfac_002417815;

			internal IEnumerator _0024_0024sco_0024temp_00241554_002417816;

			internal PoppetFactory.CreatedPoppets _0024cresult_002417817;

			internal AIControl _0024m_002417818;

			internal CutSceneManager _0024self__002417819;

			public _0024(CutSceneManager self_)
			{
				_0024self__002417819 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024pfac_002417815 = PoppetFactory.Instance;
					_0024_0024sco_0024temp_00241554_002417816 = _0024pfac_002417815.townPoppetCreationRoutine();
					if (_0024_0024sco_0024temp_00241554_002417816 != null)
					{
						_0024self__002417819.StartCoroutine(_0024_0024sco_0024temp_00241554_002417816);
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (!(_0024pfac_002417815.CreationResult.myPoppet != null))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024cresult_002417817 = _0024pfac_002417815.CreationResult;
					_0024m_002417818 = _0024cresult_002417817.myPoppet;
					_0024self__002417819.orgDataStack.Push(new Hash
					{
						{ "cmd", "poppet.summon" },
						{ "obj", _0024m_002417818.gameObject },
						{ "val", _0024m_002417818 }
					});
					_0024self__002417819.SetupComponentForCutSceneAnim(_0024m_002417818.gameObject);
					_0024self__002417819.IsWaitPoppetPop = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CutSceneManager _0024self__002417820;

		public _0024SUMMON_POPPET_core_002417814(CutSceneManager self_)
		{
			_0024self__002417820 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417820);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BETWEEN_CAMERA_002417821 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417822;

			internal GameObject _0024target_002417823;

			internal Coroutine _0024_0024sco_0024temp_00241565_002417824;

			internal Hashtable _0024arg_002417825;

			internal CutSceneManager _0024self__002417826;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417825 = arg;
				_0024self__002417826 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417822 = _0024arg_002417825["arg1"];
					object obj = _0024targetName_002417822;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417823 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417823)
					{
						_0024target_002417823 = GameObject.Find(_0024targetName_002417822 + "(Clone)") as GameObject;
					}
					if (!_0024target_002417823)
					{
						goto case 1;
					}
					_0024arg_002417825["arg1"] = _0024target_002417823;
					_0024arg_002417825["arg2"] = _0024self__002417826.cutSceneTalkPartnerChar;
					_0024_0024sco_0024temp_00241565_002417824 = _0024self__002417826.StartCoroutine("BETWEEN_CAMERA_core", _0024arg_002417825);
					if (_0024_0024sco_0024temp_00241565_002417824 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241565_002417824) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417827;

		internal CutSceneManager _0024self__002417828;

		public _0024BETWEEN_CAMERA_002417821(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417827 = arg;
			_0024self__002417828 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417827, _0024self__002417828);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BETWEEN_CAMERA_FOR_CUTSCENE_OBJID_002417829 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417830;

			internal GameObject _0024target_002417831;

			internal Coroutine _0024_0024sco_0024temp_00241566_002417832;

			internal Hashtable _0024arg_002417833;

			internal CutSceneManager _0024self__002417834;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417833 = arg;
				_0024self__002417834 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417830 = _0024arg_002417833["arg1"];
					object obj = _0024cutSceneObjId_002417830;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417831 = FindCutSceneObject((string)obj);
					_0024arg_002417833["arg1"] = _0024target_002417831;
					_0024arg_002417833["arg2"] = _0024self__002417834.cutSceneTalkPartnerChar;
					_0024_0024sco_0024temp_00241566_002417832 = _0024self__002417834.StartCoroutine("BETWEEN_CAMERA_core", _0024arg_002417833);
					if (_0024_0024sco_0024temp_00241566_002417832 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241566_002417832) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417835;

		internal CutSceneManager _0024self__002417836;

		public _0024BETWEEN_CAMERA_FOR_CUTSCENE_OBJID_002417829(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417835 = arg;
			_0024self__002417836 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417835, _0024self__002417836);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BETWEEN_CAMERA_EX_002417837 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024objName1_002417838;

			internal object _0024objName2_002417839;

			internal GameObject _0024target1_002417840;

			internal GameObject _0024target2_002417841;

			internal Coroutine _0024_0024sco_0024temp_00241567_002417842;

			internal Hashtable _0024arg_002417843;

			internal CutSceneManager _0024self__002417844;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417843 = arg;
				_0024self__002417844 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024objName1_002417838 = _0024arg_002417843["arg1"];
					_0024objName2_002417839 = _0024arg_002417843["arg2"];
					object obj = _0024objName1_002417838;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target1_002417840 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target1_002417840)
					{
						_0024target1_002417840 = GameObject.Find(_0024objName1_002417838 + "(Clone)") as GameObject;
					}
					object obj2 = _0024objName2_002417839;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024target2_002417841 = GameObject.Find((string)obj2) as GameObject;
					if (!_0024target2_002417841)
					{
						_0024target2_002417841 = GameObject.Find(_0024objName2_002417839 + "(Clone)") as GameObject;
					}
					if (!_0024target1_002417840 || !_0024target2_002417841)
					{
						goto case 1;
					}
					_0024arg_002417843["arg1"] = _0024target1_002417840;
					_0024arg_002417843["arg2"] = _0024target2_002417841;
					_0024_0024sco_0024temp_00241567_002417842 = _0024self__002417844.StartCoroutine("BETWEEN_CAMERA_core", _0024arg_002417843);
					if (_0024_0024sco_0024temp_00241567_002417842 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241567_002417842) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417845;

		internal CutSceneManager _0024self__002417846;

		public _0024BETWEEN_CAMERA_EX_002417837(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417845 = arg;
			_0024self__002417846 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417845, _0024self__002417846);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BETWEEN_CAMERA_EX_FOR_CUTSCENE_OBJID_002417847 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId1_002417848;

			internal object _0024cutSceneObjId2_002417849;

			internal GameObject _0024target1_002417850;

			internal GameObject _0024target2_002417851;

			internal Coroutine _0024_0024sco_0024temp_00241568_002417852;

			internal Hashtable _0024arg_002417853;

			internal CutSceneManager _0024self__002417854;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417853 = arg;
				_0024self__002417854 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId1_002417848 = _0024arg_002417853["arg1"];
					_0024cutSceneObjId2_002417849 = _0024arg_002417853["arg2"];
					object obj = _0024cutSceneObjId1_002417848;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target1_002417850 = FindCutSceneObject((string)obj);
					_0024arg_002417853["arg1"] = _0024target1_002417850;
					object obj2 = _0024cutSceneObjId2_002417849;
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024target2_002417851 = FindCutSceneObject((string)obj2);
					_0024arg_002417853["arg2"] = _0024target2_002417851;
					_0024_0024sco_0024temp_00241568_002417852 = _0024self__002417854.StartCoroutine("BETWEEN_CAMERA_core", _0024arg_002417853);
					if (_0024_0024sco_0024temp_00241568_002417852 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241568_002417852) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417855;

		internal CutSceneManager _0024self__002417856;

		public _0024BETWEEN_CAMERA_EX_FOR_CUTSCENE_OBJID_002417847(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417855 = arg;
			_0024self__002417856 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417855, _0024self__002417856);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CAMERA_MOTION_002417857 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal object _0024motionName_002417858;

			internal Camera _0024maincam_002417859;

			internal GameObject _0024target_002417860;

			internal int _0024ox_002417861;

			internal int _0024oy_002417862;

			internal int _0024oz_002417863;

			internal int _0024tmpframe_002417864;

			internal Animation _0024anim_002417865;

			internal AnimationClip _0024animClip_002417866;

			internal RuntimeAssetBundleDB.Req _0024r_002417867;

			internal Camera _0024camComp_002417868;

			internal bool _0024enableFlag_002417869;

			internal UnityEngine.Object _0024file_002417870;

			internal Hashtable _0024orgCamRoot_002417871;

			internal bool _0024isParentStacked_002417872;

			internal Hashtable _0024s_002417873;

			internal object _0024lastParent_002417874;

			internal Hashtable _0024orgParent_002417875;

			internal Hashtable _0024orgPos_002417876;

			internal Hashtable _0024orgRot_002417877;

			internal Hashtable _0024orgScl_002417878;

			internal Hashtable _0024orgFov_002417879;

			internal Vector3 _0024pos_002417880;

			internal Quaternion _0024rot_002417881;

			internal Vector3 _0024scl_002417882;

			internal float _0024fov_002417883;

			internal AnimationState _0024state_002417884;

			internal float _0024time_002417885;

			internal int _0024aid_002417886;

			internal IEnumerator _0024_0024iterator_002413612_002417887;

			internal Hashtable _0024arg_002417888;

			internal CutSceneManager _0024self__002417889;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417888 = arg;
				_0024self__002417889 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						_0024self__002417889.cameraWaitCount++;
						_0024self__002417889.RESET_CAMERA_core(0f);
						_0024motionName_002417858 = _0024arg_002417888["arg1"];
						_0024maincam_002417859 = Camera.main;
						_0024target_002417860 = _0024maincam_002417859.gameObject;
						_0024ox_002417861 = 0;
						_0024oy_002417862 = 0;
						_0024oz_002417863 = 0;
						_0024tmpframe_002417864 = 0;
						_0024anim_002417865 = null;
						if (!_0024maincam_002417859)
						{
							_0024self__002417889.cameraWaitCount--;
						}
						CutSceneManager cutSceneManager = _0024self__002417889;
						object obj = _0024motionName_002417858;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024animClip_002417866 = cutSceneManager.FindLoadObject((string)obj) as AnimationClip;
						if (_0024animClip_002417866 == null)
						{
							RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
							object obj2 = _0024motionName_002417858;
							if (!(obj2 is string))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(string));
							}
							_0024r_002417867 = instance.loadAsset((string)obj2, typeof(AnimationClip));
							goto case 2;
						}
						goto IL_0194;
					}
					case 2:
						if (!_0024r_002417867.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024r_002417867.IsOk)
						{
						}
						_0024animClip_002417866 = _0024r_002417867.Asset as AnimationClip;
						goto IL_0194;
					case 3:
					case 4:
						if (_0024self__002417889.exec && (bool)_0024state_002417884)
						{
							if (!_0024self__002417889.localPlayFlag)
							{
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							if (_0024self__002417889.checkAnimIdentity(_0024target_002417860, _0024aid_002417886) && !(_0024state_002417884.time >= _0024state_002417884.length))
							{
								_0024state_002417884.enabled = true;
								_0024state_002417884.weight = 1f;
								_0024state_002417884.time += _0024self__002417889.animSpeed * Time.deltaTime;
								_0024anim_002417865.Sample();
								_0024camComp_002417868.fieldOfView = _0024self__002417889.motionCameraRoot.transform.localScale.x;
								_0024state_002417884.enabled = false;
								result = (Yield(4, new WaitForFixedUpdate()) ? 1 : 0);
								break;
							}
						}
						_0024self__002417889.cameraWaitCount--;
						if (_0024self__002417889.cameraWaitCount <= 0 && !(_0024target_002417860 == null))
						{
							Transform transform = _0024target_002417860.transform;
							object obj3 = _0024lastParent_002417874;
							if (!(obj3 is Transform))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
							}
							transform.parent = (Transform)obj3;
							if (_0024self__002417889.motionCameraRoot != null && _0024self__002417889.motionCameraRoot.transform.childCount == 0)
							{
								UnityEngine.Object.DestroyImmediate(_0024self__002417889.motionCameraRoot);
							}
						}
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0194:
						if (!_0024animClip_002417866)
						{
							_0024self__002417889.cameraWaitCount--;
						}
						_0024camComp_002417868 = _0024target_002417860.GetComponentInChildren<Camera>();
						_0024enableFlag_002417869 = false;
						if (!_0024self__002417889.motionCameraRoot)
						{
							_0024file_002417870 = GameAssetModule.LoadPrefab(motionCameraRootPath);
							if ((bool)_0024file_002417870)
							{
								_0024self__002417889.motionCameraRoot = UnityEngine.Object.Instantiate(_0024file_002417870, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
							}
						}
						if (!_0024self__002417889.motionCameraRoot)
						{
							_0024self__002417889.cameraWaitCount--;
						}
						_0024orgCamRoot_002417871 = new Hashtable();
						_0024orgCamRoot_002417871 = new Hash
						{
							{ "cmd", "target.instantiate" },
							{ "obj", _0024self__002417889.motionCameraRoot }
						};
						_0024self__002417889.orgCamStack.Push(_0024orgCamRoot_002417871);
						_0024anim_002417865 = _0024self__002417889.motionCameraRoot.GetComponent<Animation>();
						if (!_0024anim_002417865)
						{
							_0024self__002417889.cameraWaitCount--;
						}
						_0024self__002417889.DISABLE_CAMERA_CONTROL(new Hashtable());
						_0024isParentStacked_002417872 = false;
						_0024_0024iterator_002413612_002417887 = _0024self__002417889.orgCamStack.GetEnumerator();
						while (_0024_0024iterator_002413612_002417887.MoveNext())
						{
							object obj4 = _0024_0024iterator_002413612_002417887.Current;
							if (!(obj4 is Hashtable))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(Hashtable));
							}
							_0024s_002417873 = (Hashtable)obj4;
							if (RuntimeServices.EqualityOperator("transform.parent", _0024s_002417873["cmd"]))
							{
								_0024isParentStacked_002417872 = true;
								_0024lastParent_002417874 = _0024s_002417873["val"];
							}
						}
						if (!_0024isParentStacked_002417872)
						{
							_0024lastParent_002417874 = _0024target_002417860.transform.parent;
						}
						_0024orgParent_002417875 = new Hashtable();
						_0024orgParent_002417875 = new Hash
						{
							{ "cmd", "transform.parent" },
							{ "obj", _0024target_002417860.transform },
							{ "val", _0024lastParent_002417874 }
						};
						_0024self__002417889.orgCamStack.Push(_0024orgParent_002417875);
						_0024target_002417860.transform.parent = _0024self__002417889.motionCameraRoot.transform;
						_0024orgPos_002417876 = new Hashtable();
						_0024orgRot_002417877 = new Hashtable();
						_0024orgScl_002417878 = new Hashtable();
						_0024orgFov_002417879 = new Hashtable();
						_0024pos_002417880 = _0024target_002417860.transform.localPosition;
						_0024rot_002417881 = _0024target_002417860.transform.localRotation;
						_0024scl_002417882 = _0024target_002417860.transform.localScale;
						_0024fov_002417883 = _0024camComp_002417868.fieldOfView;
						_0024orgPos_002417876 = new Hash
						{
							{ "cmd", "target.transform.localPosition" },
							{ "obj", _0024target_002417860 },
							{ "val", _0024pos_002417880 }
						};
						_0024orgRot_002417877 = new Hash
						{
							{ "cmd", "target.transform.localRotation" },
							{ "obj", _0024target_002417860 },
							{ "val", _0024rot_002417881 }
						};
						_0024orgScl_002417878 = new Hash
						{
							{ "cmd", "target.transform.localScale" },
							{ "obj", _0024target_002417860 },
							{ "val", _0024scl_002417882 }
						};
						_0024orgFov_002417879 = new Hash
						{
							{ "cmd", "cam.fieldOfView" },
							{ "obj", _0024camComp_002417868 },
							{ "val", _0024fov_002417883 }
						};
						_0024self__002417889.orgCamStack.Push(_0024orgPos_002417876);
						_0024self__002417889.orgCamStack.Push(_0024orgRot_002417877);
						_0024self__002417889.orgCamStack.Push(_0024orgScl_002417878);
						_0024self__002417889.orgCamStack.Push(_0024orgFov_002417879);
						_0024target_002417860.transform.localPosition = new Vector3(0f, 0f, 0f);
						_0024target_002417860.transform.localEulerAngles = ((!_0024self__002417889.leftHandAdjust) ? new Vector3(0f, 0f, 0f) : new Vector3(0f, 180f, 0f));
						if (_0024animClip_002417866 != null)
						{
							_0024anim_002417865.AddClip(_0024animClip_002417866, _0024animClip_002417866.name);
							_0024anim_002417865.clip = _0024animClip_002417866;
							_0024state_002417884 = _0024anim_002417865[_0024animClip_002417866.name];
							_0024state_002417884.wrapMode = WrapMode.Once;
						}
						_0024time_002417885 = 0f;
						if (_0024state_002417884 != null)
						{
							_0024state_002417884.enabled = true;
							_0024state_002417884.weight = 1f;
							_0024state_002417884.speed = 1f;
							_0024state_002417884.normalizedTime = 0f;
						}
						_0024aid_002417886 = _0024self__002417889.registerAnimIdentity(_0024target_002417860);
						_0024self__002417889.isCameraPlayedMotion = true;
						goto case 3;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417890;

		internal CutSceneManager _0024self__002417891;

		public _0024CAMERA_MOTION_002417857(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417890 = arg;
			_0024self__002417891 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024arg_002417890, _0024self__002417891);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RESET_CAMERA_002417892 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024duration_002417893;

			internal Coroutine _0024_0024sco_0024temp_00241569_002417894;

			internal Hashtable _0024arg_002417895;

			internal CutSceneManager _0024self__002417896;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417895 = arg;
				_0024self__002417896 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					object obj = _0024arg_002417895["arg1"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024duration_002417893 = float.Parse((string)obj);
					_0024_0024sco_0024temp_00241569_002417894 = _0024self__002417896.StartCoroutine("RESET_CAMERA_core", _0024duration_002417893);
					if (_0024_0024sco_0024temp_00241569_002417894 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241569_002417894) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417897;

		internal CutSceneManager _0024self__002417898;

		public _0024RESET_CAMERA_002417892(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417897 = arg;
			_0024self__002417898 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417897, _0024self__002417898);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RESET_CAMERA_core_002417899 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Stack _0024dataStack_002417900;

			internal Stack _0024tmpStack_002417901;

			internal BasicCamera _0024cam_002417902;

			internal Hash _0024orgData_002417903;

			internal double _0024tmpduration_002417904;

			internal Hash _0024orgData_002417905;

			internal IEnumerator _0024_0024iterator_002413613_002417906;

			internal IEnumerator _0024_0024iterator_002413614_002417907;

			internal float _0024duration_002417908;

			internal CutSceneManager _0024self__002417909;

			public _0024(float duration, CutSceneManager self_)
			{
				_0024duration_002417908 = duration;
				_0024self__002417909 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024dataStack_002417900 = _0024self__002417909.orgCamStack;
						_0024tmpStack_002417901 = new Stack();
						_0024cam_002417902 = null;
						if (_0024dataStack_002417900.Count == 0)
						{
							goto case 1;
						}
						_0024_0024iterator_002413613_002417906 = _0024dataStack_002417900.GetEnumerator();
						while (_0024_0024iterator_002413613_002417906.MoveNext())
						{
							object obj = _0024_0024iterator_002413613_002417906.Current;
							if (!(obj is Hash))
							{
								obj = RuntimeServices.Coerce(obj, typeof(Hash));
							}
							_0024orgData_002417903 = (Hash)obj;
							_0024cam_002417902 = null;
							if (RuntimeServices.EqualityOperator(_0024orgData_002417903["cmd"], "cam.centerOffset.x"))
							{
								object obj2 = _0024orgData_002417903["obj"];
								if (!(obj2 is BasicCamera))
								{
									obj2 = RuntimeServices.Coerce(obj2, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj2;
								if ((bool)_0024cam_002417902)
								{
									_0024orgData_002417903["ini"] = _0024cam_002417902.centerOffset.x;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417903["cmd"], "cam.centerOffset.y"))
							{
								object obj3 = _0024orgData_002417903["obj"];
								if (!(obj3 is BasicCamera))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj3;
								if ((bool)_0024cam_002417902)
								{
									_0024orgData_002417903["ini"] = _0024cam_002417902.centerOffset.y;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417903["cmd"], "cam.centerOffset.z"))
							{
								object obj4 = _0024orgData_002417903["obj"];
								if (!(obj4 is BasicCamera))
								{
									obj4 = RuntimeServices.Coerce(obj4, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj4;
								if ((bool)_0024cam_002417902)
								{
									_0024orgData_002417903["ini"] = _0024cam_002417902.centerOffset.z;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417903["cmd"], "cam.height"))
							{
								object obj5 = _0024orgData_002417903["obj"];
								if (!(obj5 is BasicCamera))
								{
									obj5 = RuntimeServices.Coerce(obj5, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj5;
								if ((bool)_0024cam_002417902)
								{
									_0024orgData_002417903["ini"] = _0024cam_002417902.height;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417903["cmd"], "cam.distance"))
							{
								object obj6 = _0024orgData_002417903["obj"];
								if (!(obj6 is BasicCamera))
								{
									obj6 = RuntimeServices.Coerce(obj6, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj6;
								if ((bool)_0024cam_002417902)
								{
									_0024orgData_002417903["ini"] = _0024cam_002417902.distance;
								}
							}
						}
						_0024tmpduration_002417904 = 0.0;
						_0024self__002417909.cameraWaitCount++;
						if (((ICollection)_0024dataStack_002417900).Count > 0)
						{
							_0024_0024iterator_002413614_002417907 = _0024dataStack_002417900.GetEnumerator();
							goto case 2;
						}
						goto IL_088f;
					case 2:
						if (_0024_0024iterator_002413614_002417907.MoveNext())
						{
							object obj7 = _0024_0024iterator_002413614_002417907.Current;
							if (!(obj7 is Hash))
							{
								obj7 = RuntimeServices.Coerce(obj7, typeof(Hash));
							}
							_0024orgData_002417905 = (Hash)obj7;
							_0024cam_002417902 = null;
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.centerOffset.x"))
							{
								object obj8 = _0024orgData_002417905["obj"];
								if (!(obj8 is BasicCamera))
								{
									obj8 = RuntimeServices.Coerce(obj8, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj8;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.centerOffset.x = _0024self__002417909.CalcSingle(RuntimeServices.UnboxSingle(_0024orgData_002417905["ini"]), RuntimeServices.UnboxSingle(_0024orgData_002417905["val"]), (float)_0024tmpduration_002417904, _0024duration_002417908);
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.centerOffset.y"))
							{
								object obj9 = _0024orgData_002417905["obj"];
								if (!(obj9 is BasicCamera))
								{
									obj9 = RuntimeServices.Coerce(obj9, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj9;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.centerOffset.y = _0024self__002417909.CalcSingle(RuntimeServices.UnboxSingle(_0024orgData_002417905["ini"]), RuntimeServices.UnboxSingle(_0024orgData_002417905["val"]), (float)_0024tmpduration_002417904, _0024duration_002417908);
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.centerOffset.z"))
							{
								object obj10 = _0024orgData_002417905["obj"];
								if (!(obj10 is BasicCamera))
								{
									obj10 = RuntimeServices.Coerce(obj10, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj10;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.centerOffset.z = _0024self__002417909.CalcSingle(RuntimeServices.UnboxSingle(_0024orgData_002417905["ini"]), RuntimeServices.UnboxSingle(_0024orgData_002417905["val"]), (float)_0024tmpduration_002417904, _0024duration_002417908);
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.height"))
							{
								object obj11 = _0024orgData_002417905["obj"];
								if (!(obj11 is BasicCamera))
								{
									obj11 = RuntimeServices.Coerce(obj11, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj11;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.height = _0024self__002417909.CalcSingle(RuntimeServices.UnboxSingle(_0024orgData_002417905["ini"]), RuntimeServices.UnboxSingle(_0024orgData_002417905["val"]), (float)_0024tmpduration_002417904, _0024duration_002417908);
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.distance"))
							{
								object obj12 = _0024orgData_002417905["obj"];
								if (!(obj12 is BasicCamera))
								{
									obj12 = RuntimeServices.Coerce(obj12, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj12;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.distance = _0024self__002417909.CalcSingle(RuntimeServices.UnboxSingle(_0024orgData_002417905["ini"]), RuntimeServices.UnboxSingle(_0024orgData_002417905["val"]), (float)_0024tmpduration_002417904, _0024duration_002417908);
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.target"))
							{
								object obj13 = _0024orgData_002417905["obj"];
								if (!(obj13 is BasicCamera))
								{
									obj13 = RuntimeServices.Coerce(obj13, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj13;
								if ((bool)_0024cam_002417902)
								{
									BasicCamera basicCamera = _0024cam_002417902;
									object obj14 = _0024orgData_002417905["val"];
									if (!(obj14 is Transform))
									{
										obj14 = RuntimeServices.Coerce(obj14, typeof(Transform));
									}
									basicCamera.target = (Transform)obj14;
								}
							}
							if (RuntimeServices.EqualityOperator(_0024orgData_002417905["cmd"], "cam.autoPlayerTarget"))
							{
								object obj15 = _0024orgData_002417905["obj"];
								if (!(obj15 is BasicCamera))
								{
									obj15 = RuntimeServices.Coerce(obj15, typeof(BasicCamera));
								}
								_0024cam_002417902 = (BasicCamera)obj15;
								if ((bool)_0024cam_002417902)
								{
									_0024cam_002417902.autoPlayerTarget = RuntimeServices.UnboxBoolean(_0024orgData_002417905["val"]);
								}
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto IL_088f;
					case 1:
						{
							result = 0;
							break;
						}
						IL_088f:
						_0024self__002417909.cameraWaitCount--;
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal float _0024duration_002417910;

		internal CutSceneManager _0024self__002417911;

		public _0024RESET_CAMERA_core_002417899(float duration, CutSceneManager self_)
		{
			_0024duration_002417910 = duration;
			_0024self__002417911 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024duration_002417910, _0024self__002417911);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PLAY_EFFECT_Core_002417912 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024effectName_002417913;

			internal float _0024posX_002417914;

			internal float _0024posY_002417915;

			internal float _0024posZ_002417916;

			internal float _0024rotX_002417917;

			internal float _0024rotY_002417918;

			internal float _0024rotZ_002417919;

			internal GameObject _0024parent_002417920;

			internal __D540Interpreter_PrefabLoader_0024callable0_002412_29__ _0024_search_002417921;

			internal GameObject _0024ef_002417922;

			internal GameObject _0024tmp_backup_ef_002417923;

			internal EffectTimeScale _0024cmp_002417924;

			internal Hash _0024addCmp_002417925;

			internal int _0024instId_002417926;

			internal float _0024_002412481_002417927;

			internal Vector3 _0024_002412482_002417928;

			internal float _0024_002412483_002417929;

			internal Vector3 _0024_002412484_002417930;

			internal float _0024_002412485_002417931;

			internal Vector3 _0024_002412486_002417932;

			internal float _0024_002412487_002417933;

			internal Vector3 _0024_002412488_002417934;

			internal float _0024_002412489_002417935;

			internal Vector3 _0024_002412490_002417936;

			internal float _0024_002412491_002417937;

			internal Vector3 _0024_002412492_002417938;

			internal Hashtable _0024arg_002417939;

			internal CutSceneManager _0024self__002417940;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417939 = arg;
				_0024self__002417940 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					object obj = _0024arg_002417939["arg1"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024effectName_002417913 = (string)obj;
					object obj2 = _0024arg_002417939["arg2"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024posX_002417914 = float.Parse((string)obj2);
					object obj3 = _0024arg_002417939["arg3"];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					_0024posY_002417915 = float.Parse((string)obj3);
					object obj4 = _0024arg_002417939["arg4"];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					_0024posZ_002417916 = float.Parse((string)obj4);
					object obj5 = _0024arg_002417939["arg5"];
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					_0024rotX_002417917 = float.Parse((string)obj5);
					object obj6 = _0024arg_002417939["arg6"];
					if (!(obj6 is string))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(string));
					}
					_0024rotY_002417918 = float.Parse((string)obj6);
					object obj7 = _0024arg_002417939["arg7"];
					if (!(obj7 is string))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(string));
					}
					_0024rotZ_002417919 = float.Parse((string)obj7);
					object obj8 = _0024arg_002417939["arg8"];
					if (!(obj8 is GameObject))
					{
						obj8 = RuntimeServices.Coerce(obj8, typeof(GameObject));
					}
					_0024parent_002417920 = (GameObject)obj8;
					_0024_search_002417921 = delegate(string n)
					{
						GameObject gameObject = _0024self__002417940.FindLoadObject(n) as GameObject;
						int instanceID = default(int);
						if ((bool)gameObject)
						{
							instanceID = gameObject.GetInstanceID();
						}
						object result2;
						if ((bool)gameObject && !_0024self__002417940.effectCheckTab.ContainsKey(instanceID))
						{
							result2 = gameObject;
						}
						else
						{
							if (!gameObject)
							{
								gameObject = GameObject.Find(n) as GameObject;
							}
							if (!gameObject)
							{
								gameObject = GameObject.Find(n + "(Clone)") as GameObject;
							}
							result2 = ((!gameObject) ? null : gameObject);
						}
						return (GameObject)result2;
					};
					_0024ef_002417922 = _0024_search_002417921(_0024effectName_002417913);
					if (!_0024ef_002417922)
					{
						throw new AssertionFailedException(new StringBuilder("エフェクトが見つからない ").Append(_0024effectName_002417913).ToString());
					}
					_0024ef_002417922.name = new StringBuilder("_played_effect_").Append(_0024effectName_002417913).Append("_id").Append((object)_0024self__002417940.curCommandIndex)
						.ToString();
					_0024tmp_backup_ef_002417923 = ((GameObject)UnityEngine.Object.Instantiate(_0024ef_002417922)) as GameObject;
					if (!(_0024tmp_backup_ef_002417923 != null))
					{
						throw new AssertionFailedException("tmp_backup_ef != null");
					}
					_0024tmp_backup_ef_002417923.name = new StringBuilder("_tmpbackup_").Append(_0024effectName_002417913).ToString();
					_0024tmp_backup_ef_002417923.SetActive(value: false);
					_0024tmp_backup_ef_002417923.name = _0024effectName_002417913;
					_0024self__002417940.loadObjectList.Add(_0024tmp_backup_ef_002417923);
					_0024cmp_002417924 = (EffectTimeScale)(((EffectTimeScale)_0024ef_002417922.AddComponent(typeof(EffectTimeScale))) as Component);
					_0024addCmp_002417925 = new Hash
					{
						{ "cmd", "add.comp" },
						{ "obj", _0024ef_002417922 },
						{ "val", _0024cmp_002417924 }
					};
					_0024self__002417940.orgDataStack.Push(_0024addCmp_002417925);
					if ((bool)_0024parent_002417920)
					{
						_0024ef_002417922.transform.parent = _0024parent_002417920.transform;
					}
					float num = (_0024_002412481_002417927 = _0024posX_002417914);
					Vector3 vector = (_0024_002412482_002417928 = _0024ef_002417922.transform.localPosition);
					float num2 = (_0024_002412482_002417928.x = _0024_002412481_002417927);
					Vector3 vector3 = (_0024ef_002417922.transform.localPosition = _0024_002412482_002417928);
					float num3 = (_0024_002412483_002417929 = _0024posY_002417915);
					Vector3 vector4 = (_0024_002412484_002417930 = _0024ef_002417922.transform.localPosition);
					float num4 = (_0024_002412484_002417930.y = _0024_002412483_002417929);
					Vector3 vector6 = (_0024ef_002417922.transform.localPosition = _0024_002412484_002417930);
					float num5 = (_0024_002412485_002417931 = _0024posZ_002417916);
					Vector3 vector7 = (_0024_002412486_002417932 = _0024ef_002417922.transform.localPosition);
					float num6 = (_0024_002412486_002417932.z = _0024_002412485_002417931);
					Vector3 vector9 = (_0024ef_002417922.transform.localPosition = _0024_002412486_002417932);
					float num7 = (_0024_002412487_002417933 = _0024rotX_002417917);
					Vector3 vector10 = (_0024_002412488_002417934 = _0024ef_002417922.transform.localEulerAngles);
					float num8 = (_0024_002412488_002417934.x = _0024_002412487_002417933);
					Vector3 vector12 = (_0024ef_002417922.transform.localEulerAngles = _0024_002412488_002417934);
					float num9 = (_0024_002412489_002417935 = _0024rotY_002417918);
					Vector3 vector13 = (_0024_002412490_002417936 = _0024ef_002417922.transform.localEulerAngles);
					float num10 = (_0024_002412490_002417936.y = _0024_002412489_002417935);
					Vector3 vector15 = (_0024ef_002417922.transform.localEulerAngles = _0024_002412490_002417936);
					float num11 = (_0024_002412491_002417937 = _0024rotZ_002417919);
					Vector3 vector16 = (_0024_002412492_002417938 = _0024ef_002417922.transform.localEulerAngles);
					float num12 = (_0024_002412492_002417938.z = _0024_002412491_002417937);
					Vector3 vector18 = (_0024ef_002417922.transform.localEulerAngles = _0024_002412492_002417938);
					_0024ef_002417922.SetActive(value: true);
					_0024self__002417940.SHOW_CHR_core(_0024ef_002417922);
					_0024instId_002417926 = _0024ef_002417922.GetInstanceID();
					_0024self__002417940.effectCheckTab[_0024instId_002417926] = _0024ef_002417922;
					goto case 2;
				}
				case 2:
					if (_0024self__002417940.exec && (bool)_0024ef_002417922)
					{
						_0024cmp_002417924 = (EffectTimeScale)_0024ef_002417922.GetComponent(typeof(EffectTimeScale));
						if ((bool)_0024cmp_002417924)
						{
							_0024cmp_002417924.timeScale = _0024self__002417940.animSpeed;
						}
						_0024ef_002417922.SetActive(value: true);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417941;

		internal CutSceneManager _0024self__002417942;

		public _0024PLAY_EFFECT_Core_002417912(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417941 = arg;
			_0024self__002417942 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002417941, _0024self__002417942);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WAIT_PLAYER_INIT_002417943 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal PlayerControl _0024p_002417944;

			internal CutSceneManager _0024self__002417945;

			public _0024(CutSceneManager self_)
			{
				_0024self__002417945 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002417945.IsWaitPlayerInit = true;
					result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (!PlayerControl.CurrentPlayer)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024p_002417944 = PlayerControl.CurrentPlayer;
					goto case 4;
				case 4:
					if (!_0024p_002417944.IsReady)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002417945.PLAYER_CHR_INIT(new Hash { { "arg1", "C0000_000_MA_ROOT" } });
					goto case 5;
				case 5:
					if (!_0024self__002417945.isDummyPlayerInitialized)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002417945.IsWaitPlayerInit = false;
					_0024self__002417945.isPlayerInitialized = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CutSceneManager _0024self__002417946;

		public _0024WAIT_PLAYER_INIT_002417943(CutSceneManager self_)
		{
			_0024self__002417946 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024self__002417946);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FADE_IN_core_002417947 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024r_002417948;

			internal float _0024g_002417949;

			internal float _0024b_002417950;

			internal float _0024s_002417951;

			internal int _0024tmpfWait_002417952;

			internal int _0024tmpFaderWaitIndex_002417953;

			internal Hashtable _0024arg_002417954;

			internal CutSceneManager _0024self__002417955;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417954 = arg;
				_0024self__002417955 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002417955.fader = FaderCore.Instance;
						if (!_0024self__002417955.fader.isInCompleted)
						{
							object obj = _0024arg_002417954["arg1"];
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							_0024r_002417948 = float.Parse((string)obj);
							object obj2 = _0024arg_002417954["arg2"];
							if (!(obj2 is string))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(string));
							}
							_0024g_002417949 = float.Parse((string)obj2);
							object obj3 = _0024arg_002417954["arg3"];
							if (!(obj3 is string))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(string));
							}
							_0024b_002417950 = float.Parse((string)obj3);
							object obj4 = _0024arg_002417954["arg4"];
							if (!(obj4 is string))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(string));
							}
							_0024s_002417951 = float.Parse((string)obj4);
							_0024s_002417951 = (float)((double)_0024s_002417951 / 1000.0);
							_0024tmpfWait_002417952 = _0024self__002417955.fadeWait;
							_0024self__002417955.fadeWait = 1;
							if (!(_0024self__002417955.fader != null))
							{
								throw new AssertionFailedException("fader != null");
							}
							if (_0024tmpfWait_002417952 != 0 || _0024self__002417955.fadeWaitCount > 0)
							{
								_0024tmpFaderWaitIndex_002417953 = _0024self__002417955.fadeWaitIndex;
								_0024self__002417955.fadeWaitIndex++;
								_0024self__002417955.fadeWaitCount++;
								goto case 2;
							}
							_0024self__002417955._push_fader_stack(_0024self__002417955.fader);
							FaderCore.Instance.fadeInEx(_0024r_002417948, _0024g_002417949, _0024b_002417950, _0024s_002417951);
						}
						goto case 1;
					case 2:
						if (_0024self__002417955.fadeWaitCount > 0 && _0024tmpFaderWaitIndex_002417953 != _0024self__002417955.curFaderIndex)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto case 3;
					case 3:
						if (_0024self__002417955.exec && _0024self__002417955.fadeWait > 0)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (!_0024self__002417955.isBusy || !_0024self__002417955.exec)
						{
							_0024self__002417955.fadeWaitCount--;
							_0024self__002417955.curFaderIndex++;
						}
						else
						{
							if (_0024self__002417955.fadeWait == 0)
							{
								_0024self__002417955._push_fader_stack(_0024self__002417955.fader);
								FaderCore.Instance.fadeInEx(_0024r_002417948, _0024g_002417949, _0024b_002417950, _0024s_002417951);
							}
							_0024self__002417955.fadeWaitCount--;
							_0024self__002417955.curFaderIndex++;
						}
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417956;

		internal CutSceneManager _0024self__002417957;

		public _0024FADE_IN_core_002417947(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417956 = arg;
			_0024self__002417957 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002417956, _0024self__002417957);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FADE_OUT_core_002417958 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024r_002417959;

			internal float _0024g_002417960;

			internal float _0024b_002417961;

			internal float _0024s_002417962;

			internal int _0024tmpfWait_002417963;

			internal int _0024tmpFaderWaitIndex_002417964;

			internal Hashtable _0024arg_002417965;

			internal CutSceneManager _0024self__002417966;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417965 = arg;
				_0024self__002417966 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002417966.fader = FaderCore.Instance;
						if (!_0024self__002417966.fader.isOutCompleted)
						{
							object obj = _0024arg_002417965["arg1"];
							if (!(obj is string))
							{
								obj = RuntimeServices.Coerce(obj, typeof(string));
							}
							_0024r_002417959 = float.Parse((string)obj);
							object obj2 = _0024arg_002417965["arg2"];
							if (!(obj2 is string))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(string));
							}
							_0024g_002417960 = float.Parse((string)obj2);
							object obj3 = _0024arg_002417965["arg3"];
							if (!(obj3 is string))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(string));
							}
							_0024b_002417961 = float.Parse((string)obj3);
							object obj4 = _0024arg_002417965["arg4"];
							if (!(obj4 is string))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(string));
							}
							_0024s_002417962 = float.Parse((string)obj4);
							_0024s_002417962 = (float)((double)_0024s_002417962 / 1000.0);
							_0024tmpfWait_002417963 = _0024self__002417966.fadeWait;
							_0024self__002417966.fadeWait = 1;
							if (!(_0024self__002417966.fader != null))
							{
								throw new AssertionFailedException("fader != null");
							}
							if (_0024tmpfWait_002417963 != 0 || _0024self__002417966.fadeWaitCount > 0)
							{
								_0024tmpFaderWaitIndex_002417964 = _0024self__002417966.fadeWaitIndex;
								_0024self__002417966.fadeWaitIndex++;
								_0024self__002417966.fadeWaitCount++;
								goto case 2;
							}
							_0024self__002417966._push_fader_stack(_0024self__002417966.fader);
							FaderCore.Instance.fadeOutEx(_0024r_002417959, _0024g_002417960, _0024b_002417961, _0024s_002417962);
						}
						goto case 1;
					case 2:
						if (_0024self__002417966.fadeWaitCount > 0 && _0024tmpFaderWaitIndex_002417964 != _0024self__002417966.curFaderIndex)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						goto case 3;
					case 3:
						if (_0024self__002417966.exec && _0024self__002417966.fadeWait > 0)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (_0024self__002417966.fadeWait == 0)
						{
							_0024self__002417966._push_fader_stack(_0024self__002417966.fader);
							FaderCore.Instance.fadeOutEx(_0024r_002417959, _0024g_002417960, _0024b_002417961, _0024s_002417962);
						}
						_0024self__002417966.fadeWaitCount--;
						_0024self__002417966.curFaderIndex++;
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417967;

		internal CutSceneManager _0024self__002417968;

		public _0024FADE_OUT_core_002417958(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417967 = arg;
			_0024self__002417968 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002417967, _0024self__002417968);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_POS_002417969 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417970;

			internal GameObject _0024target_002417971;

			internal Coroutine _0024_0024sco_0024temp_00241583_002417972;

			internal Hashtable _0024arg_002417973;

			internal CutSceneManager _0024self__002417974;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417973 = arg;
				_0024self__002417974 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417970 = _0024arg_002417973["arg1"];
					object obj = _0024targetName_002417970;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417971 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002417971)
					{
						_0024target_002417971 = GameObject.Find(_0024targetName_002417970 + "(Clone)") as GameObject;
					}
					_0024arg_002417973["arg1"] = _0024target_002417971;
					if (!_0024target_002417971)
					{
						goto case 1;
					}
					_0024_0024sco_0024temp_00241583_002417972 = _0024self__002417974.StartCoroutine("SET_OBJECT_POS_core", _0024arg_002417973);
					if (_0024_0024sco_0024temp_00241583_002417972 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241583_002417972) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417975;

		internal CutSceneManager _0024self__002417976;

		public _0024SET_OBJECT_POS_002417969(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417975 = arg;
			_0024self__002417976 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417975, _0024self__002417976);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_POS_FOR_CUTSCENE_OBJID_002417977 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417978;

			internal GameObject _0024target_002417979;

			internal Coroutine _0024_0024sco_0024temp_00241584_002417980;

			internal Hashtable _0024arg_002417981;

			internal CutSceneManager _0024self__002417982;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417981 = arg;
				_0024self__002417982 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417978 = _0024arg_002417981["arg1"];
					object obj = _0024cutSceneObjId_002417978;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417979 = FindCutSceneObject((string)obj);
					_0024arg_002417981["arg1"] = _0024target_002417979;
					_0024_0024sco_0024temp_00241584_002417980 = _0024self__002417982.StartCoroutine("SET_OBJECT_POS_core", _0024arg_002417981);
					if (_0024_0024sco_0024temp_00241584_002417980 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241584_002417980) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417983;

		internal CutSceneManager _0024self__002417984;

		public _0024SET_OBJECT_POS_FOR_CUTSCENE_OBJID_002417977(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417983 = arg;
			_0024self__002417984 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417983, _0024self__002417984);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_POS_TO_OTHER_OBJ_002417985 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002417986;

			internal GameObject _0024target_002417987;

			internal Coroutine _0024_0024sco_0024temp_00241585_002417988;

			internal Hashtable _0024arg_002417989;

			internal CutSceneManager _0024self__002417990;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417989 = arg;
				_0024self__002417990 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002417986 = _0024arg_002417989["arg1"];
					CutSceneManager cutSceneManager = _0024self__002417990;
					object obj = _0024targetName_002417986;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002417987 = cutSceneManager.FindByName((string)obj);
					if ((bool)_0024target_002417987)
					{
						_0024arg_002417989["arg1"] = _0024target_002417987;
						if ((bool)_0024target_002417987)
						{
							_0024_0024sco_0024temp_00241585_002417988 = _0024self__002417990.StartCoroutine("SET_POS_TO_OTHER_OBJ_core", _0024arg_002417989);
							if (_0024_0024sco_0024temp_00241585_002417988 != null)
							{
								result = (Yield(2, _0024_0024sco_0024temp_00241585_002417988) ? 1 : 0);
								break;
							}
						}
					}
					goto case 1;
				}
				case 1:
				case 2:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417991;

		internal CutSceneManager _0024self__002417992;

		public _0024SET_POS_TO_OTHER_OBJ_002417985(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417991 = arg;
			_0024self__002417992 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417991, _0024self__002417992);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_POS_TO_OTHER_OBJ_FOR_CUTSCENE_OBJID_002417993 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002417994;

			internal Coroutine _0024_0024sco_0024temp_00241586_002417995;

			internal Hashtable _0024arg_002417996;

			internal CutSceneManager _0024self__002417997;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002417996 = arg;
				_0024self__002417997 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002417994 = _0024arg_002417996["arg1"];
					Hashtable hashtable = _0024arg_002417996;
					object obj = _0024cutSceneObjId_002417994;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					hashtable["arg1"] = FindCutSceneObject((string)obj);
					_0024_0024sco_0024temp_00241586_002417995 = _0024self__002417997.StartCoroutine("SET_POS_TO_OTHER_OBJ_core", _0024arg_002417996);
					if (_0024_0024sco_0024temp_00241586_002417995 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241586_002417995) ? 1 : 0);
						break;
					}
					goto case 1;
				}
				case 1:
				case 2:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002417998;

		internal CutSceneManager _0024self__002417999;

		public _0024SET_POS_TO_OTHER_OBJ_FOR_CUTSCENE_OBJID_002417993(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002417998 = arg;
			_0024self__002417999 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002417998, _0024self__002417999);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_POS_TO_OTHER_OBJ_core_002418000 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024target_002418001;

			internal object _0024otherName_002418002;

			internal int _0024mode_002418003;

			internal int _0024soon_002418004;

			internal int _0024instId_002418005;

			internal GameObject _0024other_002418006;

			internal Transform _0024k_002418007;

			internal Transform _0024t_002418008;

			internal float _0024ox_002418009;

			internal float _0024oy_002418010;

			internal float _0024oz_002418011;

			internal Quaternion _0024rot_002418012;

			internal Hashtable _0024orgX_002418013;

			internal Hashtable _0024orgY_002418014;

			internal Hashtable _0024orgZ_002418015;

			internal Hash _0024orgR_002418016;

			internal Hashtable _0024orgCmd_002418017;

			internal float _0024_002412499_002418018;

			internal Vector3 _0024_002412500_002418019;

			internal float _0024_002412501_002418020;

			internal Vector3 _0024_002412502_002418021;

			internal float _0024_002412503_002418022;

			internal Vector3 _0024_002412504_002418023;

			internal IEnumerator _0024_0024iterator_002413617_002418024;

			internal Hashtable _0024arg_002418025;

			internal CutSceneManager _0024self__002418026;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418025 = arg;
				_0024self__002418026 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024target_002418001 = _0024arg_002418025["arg1"] as GameObject;
					_0024otherName_002418002 = _0024arg_002418025["arg2"];
					object obj = _0024arg_002418025["arg3"];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024mode_002418003 = int.Parse((string)obj);
					object obj2 = _0024arg_002418025["arg4"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					_0024soon_002418004 = int.Parse((string)obj2);
					if ((bool)_0024target_002418001)
					{
						_0024instId_002418005 = _0024target_002418001.GetInstanceID();
						if (!_0024target_002418001)
						{
							_0024self__002418026.animStartSetPosTab[_0024instId_002418005] = null;
						}
						else
						{
							_0024other_002418006 = null;
							if (_0024mode_002418003 == 0)
							{
								if (_0024target_002418001 == PlayerControl.CurrentPlayer.gameObject)
								{
									_0024_0024iterator_002413617_002418024 = _0024target_002418001.transform.GetEnumerator();
									while (_0024_0024iterator_002413617_002418024.MoveNext())
									{
										object obj3 = _0024_0024iterator_002413617_002418024.Current;
										if (!(obj3 is Transform))
										{
											obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
										}
										_0024k_002418007 = (Transform)obj3;
										if (_0024k_002418007.gameObject.activeInHierarchy)
										{
											_0024t_002418008 = _0024k_002418007;
										}
									}
								}
								else
								{
									_0024t_002418008 = _0024target_002418001.transform;
								}
								Transform transform = _0024t_002418008;
								object obj4 = _0024otherName_002418002;
								if (!(obj4 is string))
								{
									obj4 = RuntimeServices.Coerce(obj4, typeof(string));
								}
								_0024t_002418008 = ObjUtilModule.Find1stDescendant(transform, (string)obj4);
								if ((bool)_0024t_002418008)
								{
									_0024other_002418006 = _0024t_002418008.gameObject;
								}
							}
							else
							{
								CutSceneManager cutSceneManager = _0024self__002418026;
								object obj5 = _0024otherName_002418002;
								if (!(obj5 is string))
								{
									obj5 = RuntimeServices.Coerce(obj5, typeof(string));
								}
								_0024other_002418006 = cutSceneManager.FindByName((string)obj5);
							}
							if ((bool)_0024other_002418006)
							{
								if ((bool)_0024target_002418001)
								{
									_0024ox_002418009 = _0024target_002418001.transform.localPosition.x;
									_0024oy_002418010 = _0024target_002418001.transform.localPosition.y;
									_0024oz_002418011 = _0024target_002418001.transform.localPosition.z;
									_0024rot_002418012 = _0024target_002418001.transform.localRotation;
									_0024orgX_002418013 = new Hashtable();
									_0024orgY_002418014 = new Hashtable();
									_0024orgZ_002418015 = new Hashtable();
									_0024orgX_002418013 = new Hash
									{
										{ "cmd", "target.transform.localPosition.x" },
										{ "obj", _0024target_002418001 },
										{
											"val",
											_0024target_002418001.transform.localPosition.x
										}
									};
									_0024orgY_002418014 = new Hash
									{
										{ "cmd", "target.transform.localPosition.y" },
										{ "obj", _0024target_002418001 },
										{
											"val",
											_0024target_002418001.transform.localPosition.y
										}
									};
									_0024orgZ_002418015 = new Hash
									{
										{ "cmd", "target.transform.localPosition.z" },
										{ "obj", _0024target_002418001 },
										{
											"val",
											_0024target_002418001.transform.localPosition.z
										}
									};
									_0024orgR_002418016 = new Hash
									{
										{ "cmd", "target.transform.localRotation" },
										{ "obj", _0024target_002418001 },
										{ "val", _0024rot_002418012 }
									};
									_0024self__002418026.orgDataStack.Push(_0024orgX_002418013);
									_0024self__002418026.orgDataStack.Push(_0024orgY_002418014);
									_0024self__002418026.orgDataStack.Push(_0024orgZ_002418015);
									_0024self__002418026.orgDataStack.Push(_0024orgR_002418016);
								}
								if (_0024soon_002418004 != 0)
								{
									result = (YieldDefault(2) ? 1 : 0);
									break;
								}
								float num = (_0024_002412499_002418018 = _0024other_002418006.transform.position.x);
								Vector3 vector = (_0024_002412500_002418019 = _0024target_002418001.transform.position);
								float num2 = (_0024_002412500_002418019.x = _0024_002412499_002418018);
								Vector3 vector3 = (_0024target_002418001.transform.position = _0024_002412500_002418019);
								float num3 = (_0024_002412501_002418020 = _0024other_002418006.transform.position.z);
								Vector3 vector4 = (_0024_002412502_002418021 = _0024target_002418001.transform.position);
								float num4 = (_0024_002412502_002418021.z = _0024_002412501_002418020);
								Vector3 vector6 = (_0024target_002418001.transform.position = _0024_002412502_002418021);
								float num5 = (_0024_002412503_002418022 = _0024other_002418006.transform.localEulerAngles.y);
								Vector3 vector7 = (_0024_002412504_002418023 = _0024target_002418001.transform.localEulerAngles);
								float num6 = (_0024_002412504_002418023.y = _0024_002412503_002418022);
								Vector3 vector9 = (_0024target_002418001.transform.localEulerAngles = _0024_002412504_002418023);
							}
						}
					}
					goto case 1;
				}
				case 2:
					_0024self__002418026.count = 1;
					if (_0024soon_002418004 == 2)
					{
						_0024self__002418026.count = -1;
					}
					_0024orgCmd_002418017 = new Hash
					{
						{ "target", _0024target_002418001 },
						{ "other", _0024other_002418006 },
						{ "count", _0024self__002418026.count }
					};
					_0024self__002418026.animStartSetPosTab[_0024instId_002418005] = _0024orgCmd_002418017;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418027;

		internal CutSceneManager _0024self__002418028;

		public _0024SET_POS_TO_OTHER_OBJ_core_002418000(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418027 = arg;
			_0024self__002418028 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002418027, _0024self__002418028);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_SCL_002418029 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002418030;

			internal GameObject _0024target_002418031;

			internal Coroutine _0024_0024sco_0024temp_00241587_002418032;

			internal Hashtable _0024arg_002418033;

			internal CutSceneManager _0024self__002418034;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418033 = arg;
				_0024self__002418034 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002418030 = _0024arg_002418033["arg1"];
					object obj = _0024targetName_002418030;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418031 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002418031)
					{
						_0024target_002418031 = GameObject.Find(_0024targetName_002418030 + "(Clone)") as GameObject;
					}
					if (!_0024target_002418031)
					{
						goto case 1;
					}
					_0024arg_002418033["arg1"] = _0024target_002418031;
					_0024_0024sco_0024temp_00241587_002418032 = _0024self__002418034.StartCoroutine("SET_OBJECT_SCL_core", _0024arg_002418033);
					if (_0024_0024sco_0024temp_00241587_002418032 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241587_002418032) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418035;

		internal CutSceneManager _0024self__002418036;

		public _0024SET_OBJECT_SCL_002418029(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418035 = arg;
			_0024self__002418036 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418035, _0024self__002418036);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_SCL_FOR_CUTSCENE_OBJID_002418037 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002418038;

			internal GameObject _0024target_002418039;

			internal Coroutine _0024_0024sco_0024temp_00241588_002418040;

			internal Hashtable _0024arg_002418041;

			internal CutSceneManager _0024self__002418042;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418041 = arg;
				_0024self__002418042 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002418038 = _0024arg_002418041["arg1"];
					object obj = _0024cutSceneObjId_002418038;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418039 = FindCutSceneObject((string)obj);
					_0024arg_002418041["arg1"] = _0024target_002418039;
					_0024_0024sco_0024temp_00241588_002418040 = _0024self__002418042.StartCoroutine("SET_OBJECT_SCL_core", _0024arg_002418041);
					if (_0024_0024sco_0024temp_00241588_002418040 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241588_002418040) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418043;

		internal CutSceneManager _0024self__002418044;

		public _0024SET_OBJECT_SCL_FOR_CUTSCENE_OBJID_002418037(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418043 = arg;
			_0024self__002418044 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418043, _0024self__002418044);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_DIR_002418045 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002418046;

			internal GameObject _0024target_002418047;

			internal Coroutine _0024_0024sco_0024temp_00241589_002418048;

			internal Hashtable _0024arg_002418049;

			internal CutSceneManager _0024self__002418050;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418049 = arg;
				_0024self__002418050 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002418046 = _0024arg_002418049["arg1"];
					object obj = _0024targetName_002418046;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418047 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002418047)
					{
						_0024target_002418047 = GameObject.Find(_0024targetName_002418046 + "(Clone)") as GameObject;
					}
					if (!_0024target_002418047)
					{
						goto case 1;
					}
					_0024arg_002418049["arg1"] = _0024target_002418047;
					_0024_0024sco_0024temp_00241589_002418048 = _0024self__002418050.StartCoroutine("SET_OBJECT_DIR_core", _0024arg_002418049);
					if (_0024_0024sco_0024temp_00241589_002418048 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241589_002418048) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418051;

		internal CutSceneManager _0024self__002418052;

		public _0024SET_OBJECT_DIR_002418045(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418051 = arg;
			_0024self__002418052 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418051, _0024self__002418052);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SET_OBJECT_DIR_FOR_CUTSCENE_OBJID_002418053 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002418054;

			internal GameObject _0024target_002418055;

			internal Coroutine _0024_0024sco_0024temp_00241590_002418056;

			internal Hashtable _0024arg_002418057;

			internal CutSceneManager _0024self__002418058;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418057 = arg;
				_0024self__002418058 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002418054 = _0024arg_002418057["arg1"];
					object obj = _0024cutSceneObjId_002418054;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418055 = FindCutSceneObject((string)obj);
					_0024arg_002418057["arg1"] = _0024target_002418055;
					_0024_0024sco_0024temp_00241590_002418056 = _0024self__002418058.StartCoroutine("SET_OBJECT_DIR_core", _0024arg_002418057);
					if (_0024_0024sco_0024temp_00241590_002418056 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241590_002418056) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418059;

		internal CutSceneManager _0024self__002418060;

		public _0024SET_OBJECT_DIR_FOR_CUTSCENE_OBJID_002418053(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418059 = arg;
			_0024self__002418060 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418059, _0024self__002418060);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MOVE_CAMERA_TO_core_002418061 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024dstPosX_002418062;

			internal float _0024dstPosY_002418063;

			internal float _0024dstPosZ_002418064;

			internal float _0024dstRotY_002418065;

			internal float _0024duration_002418066;

			internal float _0024originalPosX_002418067;

			internal float _0024originalPosY_002418068;

			internal float _0024originalPosZ_002418069;

			internal float _0024originalRotY_002418070;

			internal double _0024tmpduration_002418071;

			internal float _0024_002412513_002418072;

			internal Vector3 _0024_002412514_002418073;

			internal float _0024_002412515_002418074;

			internal Vector3 _0024_002412516_002418075;

			internal float _0024_002412517_002418076;

			internal Vector3 _0024_002412518_002418077;

			internal float _0024_002412519_002418078;

			internal Quaternion _0024_002412520_002418079;

			internal Hashtable _0024arg_002418080;

			internal CutSceneManager _0024self__002418081;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418080 = arg;
				_0024self__002418081 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						object obj = _0024arg_002418080["arg1"];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024dstPosX_002418062 = float.Parse((string)obj);
						object obj2 = _0024arg_002418080["arg2"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024dstPosY_002418063 = float.Parse((string)obj2);
						object obj3 = _0024arg_002418080["arg3"];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						_0024dstPosZ_002418064 = float.Parse((string)obj3);
						object obj4 = _0024arg_002418080["arg4"];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						_0024dstRotY_002418065 = float.Parse((string)obj4);
						object obj5 = _0024arg_002418080["arg5"];
						if (!(obj5 is string))
						{
							obj5 = RuntimeServices.Coerce(obj5, typeof(string));
						}
						_0024duration_002418066 = float.Parse((string)obj5);
						if (!(_0024self__002418081.cam != null))
						{
							throw new AssertionFailedException("cam != null");
						}
						_0024self__002418081._store_camera_transform(_0024self__002418081.cam);
						_0024originalPosX_002418067 = _0024self__002418081.cam.transform.position.x;
						_0024originalPosY_002418068 = _0024self__002418081.cam.transform.position.y;
						_0024originalPosZ_002418069 = _0024self__002418081.cam.transform.position.z;
						_0024originalRotY_002418070 = _0024self__002418081.cam.transform.rotation.y;
						_0024tmpduration_002418071 = 0.0;
						_0024self__002418081.cameraWaitCount++;
						goto case 2;
					}
					case 2:
					case 3:
						if (_0024self__002418081.exec)
						{
							if (!_0024self__002418081.localPlayFlag)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							float num = (_0024_002412513_002418072 = _0024self__002418081.CalcSingle(_0024originalPosX_002418067, _0024dstPosX_002418062, (float)_0024tmpduration_002418071, _0024duration_002418066));
							Vector3 vector = (_0024_002412514_002418073 = _0024self__002418081.cam.transform.position);
							float num2 = (_0024_002412514_002418073.x = _0024_002412513_002418072);
							Vector3 vector3 = (_0024self__002418081.cam.transform.position = _0024_002412514_002418073);
							float num3 = (_0024_002412515_002418074 = _0024self__002418081.CalcSingle(_0024originalPosY_002418068, _0024dstPosY_002418063, (float)_0024tmpduration_002418071, _0024duration_002418066));
							Vector3 vector4 = (_0024_002412516_002418075 = _0024self__002418081.cam.transform.position);
							float num4 = (_0024_002412516_002418075.y = _0024_002412515_002418074);
							Vector3 vector6 = (_0024self__002418081.cam.transform.position = _0024_002412516_002418075);
							float num5 = (_0024_002412517_002418076 = _0024self__002418081.CalcSingle(_0024originalPosZ_002418069, _0024dstPosZ_002418064, (float)_0024tmpduration_002418071, _0024duration_002418066));
							Vector3 vector7 = (_0024_002412518_002418077 = _0024self__002418081.cam.transform.position);
							float num6 = (_0024_002412518_002418077.z = _0024_002412517_002418076);
							Vector3 vector9 = (_0024self__002418081.cam.transform.position = _0024_002412518_002418077);
							float num7 = (_0024_002412519_002418078 = _0024self__002418081.CalcSingle(_0024originalRotY_002418070, _0024dstRotY_002418065, (float)_0024tmpduration_002418071, _0024duration_002418066));
							Quaternion quaternion = (_0024_002412520_002418079 = _0024self__002418081.cam.transform.rotation);
							float num8 = (_0024_002412520_002418079.y = _0024_002412519_002418078);
							Quaternion quaternion3 = (_0024self__002418081.cam.transform.rotation = _0024_002412520_002418079);
							if (!(_0024tmpduration_002418071 >= (double)_0024duration_002418066))
							{
								_0024tmpduration_002418071 += Time.deltaTime * _0024self__002418081.animSpeed;
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
						}
						_0024self__002418081.cameraWaitCount--;
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418082;

		internal CutSceneManager _0024self__002418083;

		public _0024MOVE_CAMERA_TO_core_002418061(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418082 = arg;
			_0024self__002418083 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002418082, _0024self__002418083);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ZOOM_CAMERA_TO_002418084 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024targetName_002418085;

			internal GameObject _0024target_002418086;

			internal Coroutine _0024_0024sco_0024temp_00241592_002418087;

			internal Hashtable _0024arg_002418088;

			internal CutSceneManager _0024self__002418089;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418088 = arg;
				_0024self__002418089 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024targetName_002418085 = _0024arg_002418088["arg1"];
					object obj = _0024targetName_002418085;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418086 = GameObject.Find((string)obj) as GameObject;
					if (!_0024target_002418086)
					{
						_0024target_002418086 = GameObject.Find(_0024targetName_002418085 + "(Clone)") as GameObject;
					}
					_0024arg_002418088["arg1"] = _0024target_002418086;
					_0024_0024sco_0024temp_00241592_002418087 = _0024self__002418089.StartCoroutine("ZOOM_CAMERA_TO_core", _0024arg_002418088);
					if (_0024_0024sco_0024temp_00241592_002418087 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241592_002418087) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418090;

		internal CutSceneManager _0024self__002418091;

		public _0024ZOOM_CAMERA_TO_002418084(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418090 = arg;
			_0024self__002418091 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418090, _0024self__002418091);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ZOOM_CAMERA_TO_FOR_CUTSCENE_OBJID_002418092 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal object _0024cutSceneObjId_002418093;

			internal GameObject _0024target_002418094;

			internal Coroutine _0024_0024sco_0024temp_00241593_002418095;

			internal Hashtable _0024arg_002418096;

			internal CutSceneManager _0024self__002418097;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418096 = arg;
				_0024self__002418097 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024cutSceneObjId_002418093 = _0024arg_002418096["arg1"];
					object obj = _0024cutSceneObjId_002418093;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					_0024target_002418094 = FindCutSceneObject((string)obj);
					_0024arg_002418096["arg1"] = _0024target_002418094;
					_0024_0024sco_0024temp_00241593_002418095 = _0024self__002418097.StartCoroutine("ZOOM_CAMERA_TO_core", _0024arg_002418096);
					if (_0024_0024sco_0024temp_00241593_002418095 != null)
					{
						result = (Yield(2, _0024_0024sco_0024temp_00241593_002418095) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418098;

		internal CutSceneManager _0024self__002418099;

		public _0024ZOOM_CAMERA_TO_FOR_CUTSCENE_OBJID_002418092(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418098 = arg;
			_0024self__002418099 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024arg_002418098, _0024self__002418099);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ZOOM_CAMERA_TO_core_002418100 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024target_002418101;

			internal float _0024h_002418102;

			internal float _0024d_002418103;

			internal float _0024duration_002418104;

			internal int _0024oh_002418105;

			internal int _0024od_002418106;

			internal double _0024tmpduration_002418107;

			internal Hashtable _0024orgH_002418108;

			internal Hashtable _0024orgD_002418109;

			internal Hashtable _0024orgT_002418110;

			internal Hashtable _0024arg_002418111;

			internal CutSceneManager _0024self__002418112;

			public _0024(Hashtable arg, CutSceneManager self_)
			{
				_0024arg_002418111 = arg;
				_0024self__002418112 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						object obj = _0024arg_002418111["arg1"];
						if (!(obj is GameObject))
						{
							obj = RuntimeServices.Coerce(obj, typeof(GameObject));
						}
						_0024target_002418101 = (GameObject)obj;
						object obj2 = _0024arg_002418111["arg2"];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024h_002418102 = float.Parse((string)obj2);
						object obj3 = _0024arg_002418111["arg3"];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						_0024d_002418103 = float.Parse((string)obj3);
						if (_0024arg_002418111.ContainsKey("arg4"))
						{
							object obj4 = _0024arg_002418111["arg4"];
							if (!(obj4 is string))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(string));
							}
							if (!string.IsNullOrEmpty((string)obj4))
							{
								object obj5 = _0024arg_002418111["arg4"];
								if (!(obj5 is string))
								{
									obj5 = RuntimeServices.Coerce(obj5, typeof(string));
								}
								_0024duration_002418104 = float.Parse((string)obj5) / 1000f;
								goto IL_0168;
							}
						}
						_0024duration_002418104 = 0.7f;
						goto IL_0168;
					}
					case 2:
					case 3:
						if (_0024self__002418112.exec && (bool)_0024self__002418112.cam)
						{
							if (!_0024self__002418112.localPlayFlag)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							if ((bool)_0024target_002418101)
							{
								_0024self__002418112.cam.target = _0024target_002418101.transform;
							}
							_0024self__002418112.cam.height = _0024self__002418112.CalcSingle(_0024oh_002418105, _0024h_002418102, (float)_0024tmpduration_002418107, _0024duration_002418104);
							_0024self__002418112.cam.distance = _0024self__002418112.CalcSingle(_0024od_002418106, _0024d_002418103, (float)_0024tmpduration_002418107, _0024duration_002418104);
							if (!(_0024tmpduration_002418107 >= (double)_0024duration_002418104))
							{
								_0024tmpduration_002418107 += Time.deltaTime * _0024self__002418112.animSpeed;
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
						}
						_0024self__002418112.cameraWaitCount--;
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0168:
						_0024oh_002418105 = 0;
						_0024od_002418106 = 0;
						_0024tmpduration_002418107 = 0.0;
						if ((bool)_0024self__002418112.cam)
						{
							_0024oh_002418105 = (int)_0024self__002418112.cam.height;
							_0024od_002418106 = (int)_0024self__002418112.cam.distance;
							_0024orgH_002418108 = new Hashtable();
							_0024orgD_002418109 = new Hashtable();
							_0024orgH_002418108 = new Hash
							{
								{ "cmd", "cam.height" },
								{ "obj", _0024self__002418112.cam },
								{
									"val",
									_0024self__002418112.cam.height
								}
							};
							_0024orgD_002418109 = new Hash
							{
								{ "cmd", "cam.distance" },
								{ "obj", _0024self__002418112.cam },
								{
									"val",
									_0024self__002418112.cam.distance
								}
							};
							_0024self__002418112.orgCamStack.Push(_0024orgH_002418108);
							_0024self__002418112.orgCamStack.Push(_0024orgD_002418109);
							if ((bool)_0024target_002418101)
							{
								_0024orgT_002418110 = new Hashtable();
								_0024orgT_002418110 = new Hash
								{
									{ "cmd", "cam.target" },
									{ "obj", _0024self__002418112.cam },
									{
										"val",
										_0024self__002418112.cam.target
									}
								};
								_0024self__002418112.orgCamStack.Push(_0024orgT_002418110);
							}
						}
						_0024self__002418112.cameraWaitCount++;
						goto case 2;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Hashtable _0024arg_002418113;

		internal CutSceneManager _0024self__002418114;

		public _0024ZOOM_CAMERA_TO_core_002418100(Hashtable arg, CutSceneManager self_)
		{
			_0024arg_002418113 = arg;
			_0024self__002418114 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024arg_002418113, _0024self__002418114);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DEFAULT_CAMERA_002418115 : GenericGenerator<WaitForFixedUpdate>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForFixedUpdate>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00241594_002418116;

			internal float _0024_0024wait_until_0024temp_00241595_002418117;

			internal double _0024duration_002418118;

			internal PlayerControl _0024pc_002418119;

			internal __LotterySequence_startUpdateFunc_0024callable42_002410_31__ _0024camBreak_002418120;

			internal Stack _0024ns_002418121;

			internal Stack _0024hs_002418122;

			internal Hashtable _0024s_002418123;

			internal float _0024_0024wait_until_0024temp_00241596_002418124;

			internal float _0024_0024wait_until_0024temp_00241597_002418125;

			internal IEnumerator<object> _0024_0024iterator_002413618_002418126;

			internal CutSceneManager _0024self__002418127;

			public _0024(CutSceneManager self_)
			{
				_0024self__002418127 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002418127.StopCoroutine("ZOOM_CAMERA_TO_core");
					_0024self__002418127.StopCoroutine("MOVE_CAMERA_TO_core");
					_0024self__002418127.StopCoroutine("BETWEEN_CAMERA_core");
					_0024self__002418127.StopCoroutine("CAMERA_LOOKAT");
					result = (Yield(2, new WaitForFixedUpdate()) ? 1 : 0);
					break;
				case 2:
					_0024_0024wait_until_0024temp_00241594_002418116 = 1f;
					_0024_0024wait_until_0024temp_00241595_002418117 = Time.realtimeSinceStartup;
					goto case 3;
				case 3:
					if (_0024self__002418127.cameraWaitCount != 0 && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241595_002418117 < _0024_0024wait_until_0024temp_00241594_002418116)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (SceneChanger.isCompletelyReady)
					{
						_0024self__002418127.StopCoroutine("CAMERA_MOTION");
						_0024duration_002418118 = 2.0;
						_0024pc_002418119 = PlayerControl.CurrentPlayer;
						if ((bool)_0024self__002418127.cam && (bool)_0024pc_002418119)
						{
							if (_0024self__002418127.cam.isPositioning)
							{
								_0024self__002418127.cam.Stop();
								result = (Yield(4, new WaitForFixedUpdate()) ? 1 : 0);
								break;
							}
							goto IL_0173;
						}
					}
					goto case 1;
				case 4:
					if (SceneChanger.isCompletelyReady)
					{
						goto IL_0173;
					}
					goto case 1;
				case 5:
					if (!_0024camBreak_002418120() && _0024self__002418127.cam.isPositioning && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241597_002418125 < _0024_0024wait_until_0024temp_00241596_002418124)
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024self__002418127.orgCamStack = _0024ns_002418121;
					goto IL_03f2;
				case 6:
					_0024self__002418127.RestoreParam(_0024self__002418127.orgCamStack);
					if (_0024self__002418127.cam != null && _0024self__002418127.cam.isPositioning)
					{
						_0024self__002418127.cam.ForceResetCameraMode();
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0173:
					if (!_0024self__002418127.cam || !_0024pc_002418119)
					{
						goto case 1;
					}
					_0024camBreak_002418120 = delegate
					{
						bool num = !SceneChanger.isCompletelyReady;
						if (!num)
						{
							num = _0024self__002418127.cam == null;
						}
						if (!num)
						{
							num = Camera.main == null;
						}
						if (!num)
						{
							num = _0024self__002418127.cam.gameObject != Camera.main.gameObject;
						}
						return num;
					};
					if (!_0024self__002418127.isCameraPlayedMotion && !_0024camBreak_002418120())
					{
						_0024ns_002418121 = new Stack();
						_0024hs_002418122 = new Stack();
						if (_0024self__002418127.orgCamStack != null)
						{
							_0024_0024iterator_002413618_002418126 = _0024self__002418127.orgCamStack.ToArray().Reverse().GetEnumerator();
							try
							{
								while (_0024_0024iterator_002413618_002418126.MoveNext())
								{
									object obj = _0024_0024iterator_002413618_002418126.Current;
									if (!(obj is Hashtable))
									{
										obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
									}
									_0024s_002418123 = (Hashtable)obj;
									if (!RuntimeServices.op_Member("target.transform", _0024s_002418123["cmd"] as string))
									{
										if (RuntimeServices.op_Member("cam.height", _0024s_002418123["cmd"] as string))
										{
											_0024hs_002418122.Push(_0024s_002418123);
										}
										else if (RuntimeServices.op_Member("cam.distance", _0024s_002418123["cmd"] as string))
										{
											_0024hs_002418122.Push(_0024s_002418123);
										}
										else
										{
											_0024ns_002418121.Push(_0024s_002418123);
										}
									}
								}
							}
							finally
							{
								_0024_0024iterator_002413618_002418126.Dispose();
							}
						}
						_0024self__002418127.cam.enabled = true;
						_0024self__002418127.cam.setTarget(_0024pc_002418119.transform, (float)_0024duration_002418118);
						_0024self__002418127.RestoreParam(_0024hs_002418122);
						_0024_0024wait_until_0024temp_00241596_002418124 = _0024self__002418127.cam.GetTimeOut((float)_0024duration_002418118);
						_0024_0024wait_until_0024temp_00241597_002418125 = Time.realtimeSinceStartup;
						goto case 5;
					}
					goto IL_03f2;
					IL_03f2:
					if (!SceneChanger.isCompletelyReady || _0024self__002418127.cam == null)
					{
						goto case 1;
					}
					if (_0024self__002418127.cam.target == null)
					{
					}
					if (_0024self__002418127.CutSceneName == "Merlin_CutSceneST17_ev07")
					{
						result = (Yield(6, new WaitForFixedUpdate()) ? 1 : 0);
						break;
					}
					goto case 6;
				}
				return (byte)result != 0;
			}
		}

		internal CutSceneManager _0024self__002418128;

		public _0024DEFAULT_CAMERA_002418115(CutSceneManager self_)
		{
			_0024self__002418128 = self_;
		}

		public override IEnumerator<WaitForFixedUpdate> GetEnumerator()
		{
			return new _0024(_0024self__002418128);
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/CutSceneManager";

	[NonSerialized]
	private static CutSceneManager __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public static string cutSceneDefaultPath = "CutScene/";

	[NonSerialized]
	public static string effectDefaultPath = "Prefab/Effect/";

	[NonSerialized]
	public static string playerDefaultPath = "Prefab/Character/Player/";

	private readonly string startTagName;

	private readonly string resumeBGMTagName;

	private readonly string intoBattleTagName;

	private readonly string[] dontSkipFunctions;

	private readonly string[] dontSkipTags;

	public TextAsset cutSceneFile;

	public int curIndex;

	public int curCommandIndex;

	public string curTag;

	private string lastTag;

	public Hashtable cutSceneCmd;

	public Hashtable cutSceneString;

	public bool isBusy;

	public bool hasStartTag;

	public bool isPassedStartTag;

	public bool mustFadeInAtStart;

	public int initialFaderWaitMSec;

	public bool exec;

	public bool abort;

	public bool jumpTo;

	public int count;

	public float wait;

	public float waitMsec;

	private string jumpTag;

	private bool isTagWait;

	public bool IsWaitPoppetPop;

	public bool IsWaitPlayerInit;

	public bool isPlayerInitialized;

	public bool isDummyPlayerInitialized;

	public int fadeWait;

	private int fadeWaitCount;

	private int fadeWaitIndex;

	private int curFaderIndex;

	private int moveWaitCount;

	private bool isMoveWait;

	public int motionWaitCount;

	private bool isMotionWait;

	public int cameraWaitCount;

	private bool isCameraWait;

	private bool isCameraPlayedMotion;

	public bool[] buttonWait;

	private bool isWaitMessage;

	public bool testFlag;

	protected string testCutSceneFile;

	public bool fadeOutWithEnd;

	private FaderCore fader;

	private Stack orgDataStack;

	private Stack orgCamStack;

	private SQEX_SoundPlayer _sndmgr;

	private GameSoundManager _gameSndmgr;

	private Hashtable seTable;

	private bool resumeBgm;

	private bool intoBattle;

	private bool useDummyPlayer;

	public GameObject cutSceneTalkPartnerChar;

	private int lastMsgWndType;

	private GameObject[] curCutSceneBustShotArray;

	private string[] curCutSceneBustShotMotionArray;

	private GameObject motionCameraRoot;

	private bool leftHandAdjust;

	[NonSerialized]
	public static string motionCameraRootPath = "Prefab/Camera/CutSceneCameraRoot";

	private int animCheckId;

	private Hashtable animCheckTab;

	private int nextAnimCheckId;

	private Hashtable nextAnimCheckTab;

	private Hashtable animStartSetPosTab;

	private Hashtable _animCompCacheTable;

	private Hashtable _mmpcCompCacheTable;

	private Hashtable effectCheckTab;

	private string cutSceneName;

	public bool autoStartFlag;

	public bool nowLoading;

	private List loadObjectList;

	public float animSpeed;

	public bool pause;

	public bool stepPlay;

	protected bool localPlayFlag;

	private GameObject[] playerChar;

	private string playerCharName;

	private readonly string angelGOName;

	private readonly string demonGOName;

	private readonly string angelMalePrefabName;

	private readonly string demonMalePrefabName;

	private readonly string angelFemalePrefabName;

	private readonly string demonFemalePrefabName;

	private readonly string seFuncName;

	private readonly string loopSeFuncName;

	private string angelName;

	private string demonName;

	private string poppetName;

	public PlaybackMode currentPlaybackMode;

	private float skipSpeed;

	private float fastSpeed;

	public float lastAnimSpeed;

	public bool enableSkipButton;

	private bool showSkipButtonFlag;

	public float delaySecSkipButtonShow;

	private float curSecShowSkipButton;

	private SkipButtonHUD skipButtonObject;

	private Camera skipButtonCamera;

	public GameObject skipButtonObjectPrefab;

	public Transform skipButtonObjectParent;

	private Boo.Lang.List<int> seLoadList;

	private bool result;

	private ICallable closeHandler;

	public float MotBlendTime;

	private BasicCamera _cam;

	private Hashtable animQueues;

	[NonSerialized]
	private static __Req_FailHandler_0024callable6_0024440_32__ _0024event_0024CutScenePlayStartEvent;

	[NonSerialized]
	private static __Req_FailHandler_0024callable6_0024440_32__ _0024event_0024CutScenePlayEndEvent;

	public static CutSceneManager Instance
	{
		get
		{
			CutSceneManager _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((CutSceneManager)UnityEngine.Object.FindObjectOfType(typeof(CutSceneManager))) as CutSceneManager;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static CutSceneManager CurrentInstance => __instance;

	public static bool IsBusy => (bool)CurrentInstance && CurrentInstance.isBusy;

	public bool isLoad => cutSceneCmd != null;

	public bool IsSceneReady
	{
		get
		{
			int num;
			if (!isBusy || !exec)
			{
				num = 0;
			}
			else if (hasStartTag)
			{
				if (!isPassedStartTag)
				{
					goto IL_004f;
				}
				num = 1;
			}
			else
			{
				if (curIndex <= 4)
				{
					goto IL_004f;
				}
				num = 1;
			}
			goto IL_0050;
			IL_0050:
			return (byte)num != 0;
			IL_004f:
			num = 0;
			goto IL_0050;
		}
	}

	public bool IsTagWait
	{
		get
		{
			int num;
			if (!isTagWait)
			{
				num = 0;
			}
			else if (curTag != lastTag)
			{
				isTagWait = false;
				num = 1;
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}
		set
		{
			isTagWait = value;
		}
	}

	public bool IsBreakSkipByTag => IsTagWait;

	public bool IsTimeWait
	{
		get
		{
			bool num = wait > 0f;
			if (!num)
			{
				num = waitMsec > 0f;
			}
			return num;
		}
	}

	public bool IsMoveWait
	{
		get
		{
			return moveWaitCount < 0 && (isMoveWait ? true : false);
		}
		set
		{
			isMoveWait = value;
			if (!value)
			{
				moveWaitCount = 0;
			}
		}
	}

	public bool IsMotionWait
	{
		get
		{
			int num;
			if (motionWaitCount > 0)
			{
				num = (isMotionWait ? 1 : 0);
			}
			else
			{
				isMotionWait = false;
				num = 0;
			}
			return (byte)num != 0;
		}
		set
		{
			isMotionWait = value;
			if (!value)
			{
				motionWaitCount = 0;
			}
		}
	}

	public bool IsCameraWait
	{
		get
		{
			int num;
			if (isCameraWait && cameraWaitCount > 0)
			{
				num = 1;
			}
			else if (isCameraWait)
			{
				isCameraWait = false;
				num = 0;
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}
		set
		{
			isCameraWait = value;
		}
	}

	public bool IsWaitButton
	{
		get
		{
			EventWindow instance = EventWindow.Instance;
			int num2;
			if (!instance)
			{
				int num = 0;
				int length = buttonWait.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int index = num;
					num++;
					bool[] array = buttonWait;
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = false;
				}
				num2 = 0;
			}
			else
			{
				bool flag = false;
				IEnumerator<object[]> enumerator = Builtins.enumerate(instance.Windows).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object[] current = enumerator.Current;
						object value = current[0];
						object obj = current[1];
						if (!(obj is EventWindow.Window))
						{
							obj = RuntimeServices.Coerce(obj, typeof(EventWindow.Window));
						}
						EventWindow.Window window = (EventWindow.Window)obj;
						if (window != null && (bool)window.gameObject)
						{
							if (window.gameObject.activeSelf && !window.TextFinish)
							{
								bool[] array2 = buttonWait;
								if (array2[RuntimeServices.NormalizeArrayIndex(array2, RuntimeServices.UnboxInt32(value))])
								{
									flag = true;
								}
							}
							else
							{
								bool[] array3 = buttonWait;
								array3[RuntimeServices.NormalizeArrayIndex(array3, RuntimeServices.UnboxInt32(value))] = false;
							}
						}
						else
						{
							bool[] array4 = buttonWait;
							array4[RuntimeServices.NormalizeArrayIndex(array4, RuntimeServices.UnboxInt32(value))] = false;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				num2 = (flag ? 1 : 0);
			}
			return (byte)num2 != 0;
		}
	}

	public bool IsMessageFinish
	{
		get
		{
			EventWindow instance = EventWindow.Instance;
			int num;
			bool flag;
			if (!instance)
			{
				num = 0;
			}
			else
			{
				IEnumerator<object[]> enumerator = Builtins.enumerate(instance.Windows).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object[] current = enumerator.Current;
						object obj = current[0];
						object obj2 = current[1];
						if (!(obj2 is EventWindow.Window))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(EventWindow.Window));
						}
						EventWindow.Window window = (EventWindow.Window)obj2;
						if (window == null || !window.gameObject || !window.gameObject.activeSelf || window.TextDisplayFinish)
						{
							continue;
						}
						flag = false;
						goto IL_00b4;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				num = 1;
			}
			goto IL_00b6;
			IL_00b6:
			return (byte)num != 0;
			IL_00b4:
			num = (flag ? 1 : 0);
			goto IL_00b6;
		}
	}

	public bool IsWaitMessage
	{
		get
		{
			return isWaitMessage;
		}
		private set
		{
			isWaitMessage = value;
		}
	}

	private SQEX_SoundPlayer sndmgr
	{
		get
		{
			SQEX_SoundPlayer sQEX_SoundPlayer;
			if ((bool)_sndmgr)
			{
				sQEX_SoundPlayer = _sndmgr;
			}
			else
			{
				_sndmgr = SQEX_SoundPlayer.Instance;
				sQEX_SoundPlayer = _sndmgr;
			}
			return sQEX_SoundPlayer;
		}
	}

	private GameSoundManager gameSndmgr
	{
		get
		{
			GameSoundManager gameSoundManager;
			if ((bool)_gameSndmgr)
			{
				gameSoundManager = _gameSndmgr;
			}
			else
			{
				_gameSndmgr = GameSoundManager.Instance;
				gameSoundManager = _gameSndmgr;
			}
			return gameSoundManager;
		}
	}

	public bool IsResumeBgm
	{
		get
		{
			return resumeBgm;
		}
		set
		{
			resumeBgm = value;
		}
	}

	public string CutSceneName
	{
		get
		{
			return cutSceneName;
		}
		set
		{
			if (testFlag)
			{
				cutSceneName = value;
				testCutSceneFile = value;
			}
		}
	}

	public bool IsSkipping => currentPlaybackMode == PlaybackMode.skip;

	public bool IsJumping => currentPlaybackMode == PlaybackMode.jump;

	private BasicCamera cam
	{
		get
		{
			object obj;
			if (_cam != null)
			{
				obj = _cam;
			}
			else
			{
				_cam = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera;
				obj = ((!(_cam != null)) ? null : _cam);
			}
			return (BasicCamera)obj;
		}
	}

	public bool FadeOutWithEnd
	{
		get
		{
			return fadeOutWithEnd;
		}
		set
		{
			fadeOutWithEnd = value;
		}
	}

	public bool Result
	{
		get
		{
			return result;
		}
		set
		{
			result = value;
		}
	}

	public ICallable CloseHandler
	{
		get
		{
			return closeHandler;
		}
		set
		{
			closeHandler = value;
		}
	}

	public static event __Req_FailHandler_0024callable6_0024440_32__ CutScenePlayStartEvent
	{
		add
		{
			_0024event_0024CutScenePlayStartEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Combine(_0024event_0024CutScenePlayStartEvent, value);
		}
		remove
		{
			_0024event_0024CutScenePlayStartEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Remove(_0024event_0024CutScenePlayStartEvent, value);
		}
	}

	public static event __Req_FailHandler_0024callable6_0024440_32__ CutScenePlayEndEvent
	{
		add
		{
			_0024event_0024CutScenePlayEndEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Combine(_0024event_0024CutScenePlayEndEvent, value);
		}
		remove
		{
			_0024event_0024CutScenePlayEndEvent = (__Req_FailHandler_0024callable6_0024440_32__)Delegate.Remove(_0024event_0024CutScenePlayEndEvent, value);
		}
	}

	public CutSceneManager()
	{
		startTagName = "start";
		resumeBGMTagName = "resume_bgm";
		intoBattleTagName = "into_battle";
		dontSkipFunctions = new string[13]
		{
			"SET_OBJECT", "SET_CHR", "EXIT", "MOVE_TARGET_OVERTIME", "MOVE_ROTATE_OVERTIME", "ROTATE_TARGET_OVERTIME", "PLAY_BGM", "STOP_BGM", "CHANGE_ANGEL", "CHANGE_DEMON",
			"CHANGE_ANGEL_SILENT", "CHANGE_DEMON_SILENT", "STOP_BGM"
		};
		dontSkipTags = new string[1] { "no_skip" };
		jumpTag = string.Empty;
		testCutSceneFile = string.Empty;
		fadeOutWithEnd = true;
		orgDataStack = new Stack();
		orgCamStack = new Stack();
		lastMsgWndType = 2;
		curCutSceneBustShotArray = new GameObject[2];
		curCutSceneBustShotMotionArray = new string[2];
		leftHandAdjust = true;
		animCheckTab = new Hashtable();
		nextAnimCheckTab = new Hashtable();
		animStartSetPosTab = new Hashtable();
		_animCompCacheTable = new Hashtable();
		_mmpcCompCacheTable = new Hashtable();
		effectCheckTab = new Hashtable();
		loadObjectList = new List();
		animSpeed = 1f;
		playerChar = new GameObject[3];
		playerCharName = "C0000_000_MA_ROOT";
		angelGOName = "_cutscene_player_angel";
		demonGOName = "_cutscene_player_devil";
		angelMalePrefabName = "CS_C0000_000_MA_ROOT";
		demonMalePrefabName = "CS_C0001_000_MA_ROOT";
		angelFemalePrefabName = "CS_C0002_000_MA_ROOT";
		demonFemalePrefabName = "CS_C0003_000_MA_ROOT";
		seFuncName = "PLAY_SE";
		loopSeFuncName = "PLAY_LOOP_SE";
		angelName = string.Empty;
		demonName = string.Empty;
		poppetName = string.Empty;
		currentPlaybackMode = PlaybackMode.normal;
		skipSpeed = 1f;
		fastSpeed = 5f;
		lastAnimSpeed = 1f;
		delaySecSkipButtonShow = 2f;
		seLoadList = new Boo.Lang.List<int>();
		MotBlendTime = 0.2f;
		animQueues = new Hashtable();
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241497();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static CutSceneManager _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/CutSceneManager");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "CutSceneManager" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		CutSceneManager cutSceneManager = ExtensionsModule.SetComponent<CutSceneManager>(gameObject2);
		if ((bool)cutSceneManager)
		{
			cutSceneManager._createInstance_callback();
		}
		return cutSceneManager;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241498()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241498();
		quitApp = true;
	}

	[SpecialName]
	protected internal static void raise_CutScenePlayStartEvent(string arg0)
	{
		_0024event_0024CutScenePlayStartEvent?.Invoke(arg0);
	}

	[SpecialName]
	protected internal static void raise_CutScenePlayEndEvent(string arg0)
	{
		_0024event_0024CutScenePlayEndEvent?.Invoke(arg0);
	}

	public static CutSceneManager CutScene(string cutSceneName, GameObject cutSceneTalkPartnerChar)
	{
		_0024CutScene_0024locals_002414387 _0024CutScene_0024locals_0024 = new _0024CutScene_0024locals_002414387();
		_0024CutScene_0024locals_0024._0024cutScenMan = Instance as CutSceneManager;
		if ((bool)_0024CutScene_0024locals_0024._0024cutScenMan)
		{
			if (_0024CutScene_0024locals_0024._0024cutScenMan.exec && _0024CutScene_0024locals_0024._0024cutScenMan.isBusy)
			{
				_0024CutScene_0024locals_0024._0024cutScenMan.EndCutSceneCore();
			}
			_0024CutScene_0024locals_0024._0024cutScenMan.exec = false;
			_0024CutScene_0024locals_0024._0024cutScenMan.abort = false;
			_0024CutScene_0024locals_0024._0024cutScenMan.cutSceneTalkPartnerChar = cutSceneTalkPartnerChar;
			_0024CutScene_0024locals_0024._0024cutScenMan.LoadCutScene(cutSceneName, new _0024CutScene_0024closure_00242913(_0024CutScene_0024locals_0024).Invoke);
			_0024CutScene_0024locals_0024._0024cutScenMan.isBusy = true;
		}
		return _0024CutScene_0024locals_0024._0024cutScenMan;
	}

	public static CutSceneManager CutSceneEx(string cutSceneFile, GameObject cutSceneTalkPartnerChar, string assetBundleFile, bool autoStart)
	{
		CutSceneManager cutSceneManager = Instance as CutSceneManager;
		object obj;
		if (!cutSceneManager)
		{
			obj = null;
		}
		else
		{
			if (cutSceneManager.exec && cutSceneManager.isBusy)
			{
				cutSceneManager.EndCutSceneCore();
			}
			cutSceneManager.exec = false;
			cutSceneManager.abort = false;
			cutSceneManager.cutSceneTalkPartnerChar = cutSceneTalkPartnerChar;
			cutSceneManager.cutSceneName = cutSceneFile;
			cutSceneManager.autoStartFlag = autoStart;
			cutSceneManager.CutSceneExCore();
			cutSceneManager.isBusy = true;
			obj = cutSceneManager;
		}
		return (CutSceneManager)obj;
	}

	public CutSceneManager CutSceneExCore()
	{
		result = false;
		exec = false;
		abort = false;
		StartCoroutine(loadAssetBundle());
		return null;
	}

	public void ClearLoadObject()
	{
		List list = loadObjectList;
		int num = ((ICollection)list).Count;
		int num2 = 0;
		while (num2 < num)
		{
			object obj = list[checked(num2++)];
			if (!RuntimeServices.ToBool(obj))
			{
				continue;
			}
			try
			{
				if (RuntimeServices.ToBool(obj) && obj.GetType() != typeof(AnimationClip))
				{
					object obj2 = obj;
					if (!(obj2 is UnityEngine.Object))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(UnityEngine.Object));
					}
					UnityEngine.Object.DestroyObject((UnityEngine.Object)obj2);
				}
			}
			catch (Exception)
			{
			}
		}
		loadObjectList.Clear();
		if (PlayerControl.CurrentPlayer != null)
		{
			PlayerControl.CurrentPlayer.cleanUpAnimations();
		}
		UnloadResource.UnloadUnusedAssets();
	}

	public UnityEngine.Object FindLoadObject(string objName)
	{
		List list = loadObjectList;
		int num = ((ICollection)list).Count;
		int num2 = 0;
		object obj2;
		while (true)
		{
			if (num2 < num)
			{
				object obj = list[checked(num2++)];
				UnityEngine.Object @object = obj as UnityEngine.Object;
				if (!@object || (!(@object.name == objName) && !(objName + "(Clone)" == @object.name)))
				{
					continue;
				}
				obj2 = @object;
				break;
			}
			obj2 = null;
			break;
		}
		return (UnityEngine.Object)obj2;
	}

	public GameObject _instantiateOrReUseSceneGameObject(GameObject o)
	{
		GameObject gameObject = FindByName(o.name);
		GameObject obj;
		if ((bool)gameObject && !gameObject.name.ToLower().StartsWith("ef_"))
		{
			obj = gameObject;
		}
		else
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(o);
			HIDE_CHR_core(gameObject);
			gameObject.name = gameObject.name.Replace("(Clone)", string.Empty);
			if ((bool)gameObject)
			{
				loadObjectList.Add(gameObject);
			}
			SetupComponentForCutSceneAnim(gameObject);
			if (gameObject.name.ToLower().StartsWith("ef_") && gameObject.activeSelf)
			{
				gameObject.SetActive(value: false);
			}
			obj = gameObject;
		}
		return obj;
	}

	public IEnumerator loadAssetBundle()
	{
		return new _0024loadAssetBundle_002417443(this).GetEnumerator();
	}

	public static void Abort()
	{
		CutSceneManager cutSceneManager = Instance as CutSceneManager;
		if ((bool)cutSceneManager)
		{
			cutSceneManager.abort = true;
			cutSceneManager.exec = false;
			cutSceneManager.EndCutScene(error: true);
		}
	}

	public void _0024singleton_0024awake_00241497()
	{
		SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
	}

	public void Start()
	{
	}

	public void OnDestory()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(ScenePreChangeEvent);
	}

	public static void ScenePreChangeEvent()
	{
		CutSceneManager cutSceneManager = CurrentInstance as CutSceneManager;
		if ((bool)cutSceneManager && cutSceneManager.exec)
		{
			Abort();
		}
	}

	public void FixedUpdate()
	{
		SkipButtonControl();
		ExecCutScene();
	}

	public void SkipButtonControl()
	{
		if (!enableSkipButton)
		{
			return;
		}
		if (exec)
		{
			if (!IsSceneReady)
			{
				return;
			}
			if (!skipButtonObject)
			{
				skipButtonObject = loadSkipButton(skipButtonObjectParent);
			}
			skipButtonCamera = GetComponentInChildren<Camera>();
			if ((bool)skipButtonObject)
			{
				showSkipButtonFlag = true;
				if ((bool)skipButtonCamera)
				{
					skipButtonCamera.enabled = true;
				}
				if (SkipButtonHUD.CanSkip())
				{
					onPressSkipButton();
				}
			}
			else if ((bool)skipButtonCamera)
			{
				skipButtonCamera.enabled = false;
			}
		}
		else
		{
			removeSkipButton();
		}
	}

	public SkipButtonHUD loadSkipButton(Transform parent)
	{
		GameObject gameObject = default(GameObject);
		if ((bool)skipButtonObjectPrefab)
		{
			gameObject = ((GameObject)UnityEngine.Object.Instantiate(skipButtonObjectPrefab)) as GameObject;
		}
		SkipButtonHUD component = default(SkipButtonHUD);
		if ((bool)gameObject)
		{
			component = gameObject.GetComponent<SkipButtonHUD>();
		}
		if (!gameObject)
		{
			throw new AssertionFailedException("skipObj");
		}
		if (!component)
		{
			throw new AssertionFailedException("obj");
		}
		if (!parent)
		{
			throw new AssertionFailedException("parent");
		}
		Vector3 localPosition = component.transform.localPosition;
		Vector3 localScale = component.transform.localScale;
		component.transform.parent = parent;
		component.transform.localScale = localScale;
		component.transform.localPosition = localPosition;
		component.hideStart = true;
		component.UseTouchScreen = false;
		component.hideTime = 0f;
		SkipButtonHUD.SetActive(a: true);
		SkipButtonHUD.Reset();
		SkipButtonHUD.SetShow(show: true);
		return component;
	}

	public void removeSkipButton()
	{
		if (showSkipButtonFlag)
		{
			showSkipButtonFlag = false;
			if ((bool)skipButtonCamera)
			{
				skipButtonCamera.enabled = false;
			}
		}
		if ((bool)skipButtonObject)
		{
			SkipButtonHUD.SetShow(show: false);
			UnityEngine.Object.DestroyObject(skipButtonObject.gameObject);
			skipButtonObject = null;
			skipButtonCamera = null;
		}
	}

	public void onPressSkipButton()
	{
		Skip();
		SkipButtonHUD.Reset();
	}

	public void onStartSkipButton()
	{
		if ((bool)skipButtonObject)
		{
			if ((bool)skipButtonCamera)
			{
				skipButtonCamera.enabled = true;
			}
			SkipButtonHUD.SetActive(a: true);
			SkipButtonHUD.Reset();
		}
	}

	public void onEndSkipButton()
	{
		if ((bool)skipButtonObject)
		{
			SkipButtonHUD.Reset();
			SkipButtonHUD.SetShow(show: false);
			SkipButtonHUD.SetActive(a: false);
			if ((bool)skipButtonCamera)
			{
				skipButtonCamera.enabled = false;
			}
		}
	}

	public static GameObject FindCutSceneObject(string cutSceneObjId)
	{
		CutSceneObject[] array = (CutSceneObject[])Resources.FindObjectsOfTypeAll(typeof(CutSceneObject));
		object obj;
		if (array == null)
		{
			obj = null;
		}
		else
		{
			CutSceneObject[] array2 = array;
			int length = array2.Length;
			int num = 0;
			while (true)
			{
				if (num < length)
				{
					CutSceneObject cutSceneObject = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num++))];
					if (cutSceneObject.Id == cutSceneObjId)
					{
						obj = cutSceneObject.gameObject;
						break;
					}
					continue;
				}
				obj = null;
				break;
			}
		}
		return (GameObject)obj;
	}

	private void _setupComponent_core(Type type, GameObject obj, bool isEnable)
	{
		Type type2 = type.GetType();
		Component[] array = obj.GetComponents(type);
		if (array.Length == 0)
		{
			array = obj.GetComponentsInChildren(type);
		}
		if (RuntimeServices.EqualityOperator(type, typeof(AnimationEventHandler)) && array.Length == 0)
		{
			Animation animation = (Animation)obj.GetComponentInChildren(typeof(Animation));
			if ((bool)animation)
			{
				AnimationEventHandler value = (AnimationEventHandler)(((AnimationEventHandler)animation.gameObject.AddComponent(typeof(AnimationEventHandler))) as Component);
				Hash obj2 = new Hash
				{
					{ "cmd", "add.comp" },
					{ "obj", obj },
					{ "val", value }
				};
				orgDataStack.Push(obj2);
			}
		}
		if (array.Length <= 0)
		{
			return;
		}
		Component[] array2 = array;
		int length = array2.Length;
		int num = 0;
		while (num < length)
		{
			Component component = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(num++))];
			if (RuntimeServices.EqualityOperator(type, typeof(PlayerControl)))
			{
				((PlayerControl)component).PlayAnimationIdle();
				orgDataStack.Push(new Hash
				{
					{ "cmd", "player.input" },
					{
						"obj",
						(PlayerControl)component
					},
					{
						"val",
						((PlayerControl)component).InputActive
					}
				});
				((PlayerControl)component).InputActive = false;
			}
			if (RuntimeServices.EqualityOperator(type, typeof(NPCControl)))
			{
				((NPCControl)component).StopMove = true;
				((NPCControl)component).isMove = false;
			}
			if (RuntimeServices.EqualityOperator(type, typeof(LookAtPlayer)))
			{
				PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
				if ((bool)currentPlayer)
				{
					((LookAtPlayer)component).targetCharObj = currentPlayer.transform;
				}
			}
			if (RuntimeServices.EqualityOperator(type, typeof(MerlinMotionPackControl)))
			{
				MerlinMotionPackControl merlinMotionPackControl = (MerlinMotionPackControl)component;
				Animation animation2 = _getAnim(component.gameObject);
				animation2.Stop();
				merlinMotionPackControl.forceStop();
				merlinMotionPackControl.motionTarget.Stop();
				Transform currentBaseBone = merlinMotionPackControl.CurrentBaseBone;
				Transform transform = merlinMotionPackControl.motionTarget.gameObject.transform;
				if (!(transform == component.gameObject.transform))
				{
					transform.localPosition = Vector3.zero;
				}
				currentBaseBone.localPosition = Vector3.zero;
			}
			pushCmdTargetEnabledAndSet(orgDataStack, component, isEnable);
		}
	}

	public void SetupComponentForCutSceneAnim(GameObject obj)
	{
		_setupComponent_core(typeof(NPCControl), obj, isEnable: true);
		_setupComponent_core(typeof(NpcTalkControl), obj, isEnable: false);
		_setupComponent_core(typeof(LookAtPlayer), obj, isEnable: false);
		_setupComponent_core(typeof(AIControl), obj, isEnable: false);
		_setupComponent_core(typeof(PlayerControl), obj, isEnable: false);
		_setupComponent_core(typeof(AnimationEventHandler), obj, isEnable: true);
		_setupComponent_core(typeof(D540ScriptRunner), obj, isEnable: false);
		_setupComponent_core(typeof(AttackHitManager), obj, isEnable: false);
		_setupComponent_core(typeof(CharacterController), obj, isEnable: false);
		_setupComponent_core(typeof(MerlinMotionPackControl), obj, isEnable: true);
		_setupComponent_core(typeof(TapRecognizer), obj, isEnable: false);
		_setupComponent_core(typeof(SwipeRecognizer), obj, isEnable: false);
	}

	public AnimationClip FindAnimClip(GameObject obj, string motionName)
	{
		if (!(obj != null))
		{
			throw new AssertionFailedException(new StringBuilder().Append(motionName).Append(" の探索に失敗、キャラクタオブジェクト指定が間違ってるよ").ToString());
		}
		AnimationClip animationClip = null;
		Animation animation = _getAnim(obj);
		animationClip = FindLoadObject(motionName) as AnimationClip;
		AnimationClip animationClip2;
		AnimationClip animationClip3;
		MerlinMotionPack.Entry entry;
		checked
		{
			if ((bool)animationClip)
			{
				animationClip2 = animationClip;
			}
			else
			{
				if ((bool)animation)
				{
					try
					{
						AnimationState animationState = animation[motionName];
						if ((bool)animationState)
						{
							animationClip = animationState.clip;
							if ((bool)animationClip)
							{
								animationClip3 = animationClip;
								goto IL_0239;
							}
						}
					}
					catch (Exception value)
					{
						MonoBehaviour.print(new StringBuilder("anim clip error = ").Append(value).ToString());
					}
				}
				MerlinMotionPackControl component = obj.GetComponent<MerlinMotionPackControl>();
				if ((bool)component)
				{
					MerlinMotionPack[] motionPacks = component.motionPacks;
					if (motionPacks != null)
					{
						MerlinMotionPack[] array = motionPacks;
						int length = array.Length;
						int num = 0;
						while (num < length)
						{
							MerlinMotionPack merlinMotionPack = array[RuntimeServices.NormalizeArrayIndex(array, num++)];
							if (!merlinMotionPack)
							{
								continue;
							}
							MerlinMotionPack.Entry[] entries = merlinMotionPack.entries;
							int length2 = entries.Length;
							int num2 = 0;
							while (num2 < length2)
							{
								entry = entries[RuntimeServices.NormalizeArrayIndex(entries, num2++)];
								if (!entry.clip || !(entry.clip.name == motionName))
								{
									continue;
								}
								goto IL_0168;
							}
						}
					}
				}
				NPCControl component2 = obj.GetComponent<NPCControl>();
				if (!component2)
				{
					goto IL_0236;
				}
				if ((bool)component2.idleAnim && component2.idleAnim.name == motionName)
				{
					animationClip2 = component2.idleAnim;
				}
				else if ((bool)component2.walkAnim && component2.walkAnim.name == motionName)
				{
					animationClip2 = component2.walkAnim;
				}
				else
				{
					if (!component2.runAnim || !(component2.runAnim.name == motionName))
					{
						goto IL_0236;
					}
					animationClip2 = component2.runAnim;
				}
			}
			goto IL_023b;
		}
		IL_023b:
		return animationClip2;
		IL_0168:
		animationClip2 = entry.clip;
		goto IL_023b;
		IL_0236:
		animationClip2 = animationClip;
		goto IL_023b;
		IL_0239:
		animationClip2 = animationClip3;
		goto IL_023b;
	}

	public void AnimPlay(GameObject obj, string motionName, bool forceLoop)
	{
		_0024AnimPlay_0024locals_002414389 _0024AnimPlay_0024locals_0024 = new _0024AnimPlay_0024locals_002414389();
		_0024AnimPlay_0024locals_0024._0024obj = obj;
		if (!(_0024AnimPlay_0024locals_0024._0024obj != null))
		{
			throw new AssertionFailedException(new StringBuilder().Append(motionName).Append(" の再生に失敗 in: ").Append(CutSceneName)
				.ToString());
		}
		motionName = MotionApplyWeaponType(motionName);
		AnimationClip animationClip = FindAnimClip(_0024AnimPlay_0024locals_0024._0024obj, motionName);
		if (!(animationClip != null))
		{
			throw new AssertionFailedException(new StringBuilder().Append(motionName).Append(" の再生に失敗 clip が見つからない in: ").Append(cutSceneName)
				.ToString());
		}
		if (!animationClip)
		{
			return;
		}
		Animation animation = _getAnim(_0024AnimPlay_0024locals_0024._0024obj);
		MerlinMotionPackControl componentInChildren = _0024AnimPlay_0024locals_0024._0024obj.GetComponentInChildren<MerlinMotionPackControl>();
		if (!animation && !componentInChildren)
		{
			return;
		}
		bool flag = false;
		_0024AnimPlay_0024locals_0024._0024instId = _0024AnimPlay_0024locals_0024._0024obj.GetInstanceID();
		_0024AnimPlay_0024locals_0024._0024tab = animStartSetPosTab[_0024AnimPlay_0024locals_0024._0024instId] as Hashtable;
		double num = ((animationClip.length >= MotBlendTime) ? ((double)MotBlendTime) : ((double)animationClip.length - 0.001));
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024AnimPlay_0024_fix_to_otherobj_00243798(_0024AnimPlay_0024locals_0024, this).Invoke;
		if ((bool)componentInChildren)
		{
			orgDataStack.Push(new Hash
			{
				{ "cmd", "mmpc.baseMode" },
				{ "obj", componentInChildren },
				{ "val", componentInChildren.baseMode }
			});
			orgDataStack.Push(new Hash
			{
				{ "cmd", "mmpc.CurrentAnimType" },
				{ "obj", componentInChildren },
				{ "val", componentInChildren.CurrentAnimType }
			});
			componentInChildren.baseMode = false;
			flag = componentInChildren.CurrentClip == animationClip;
			if (!flag)
			{
				_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
			}
			if (flag || _0024AnimPlay_0024locals_0024._0024tab != null)
			{
				if ((bool)animation)
				{
					animation.Stop();
				}
				componentInChildren.play(animationClip);
			}
			else
			{
				_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
				componentInChildren.play(animationClip, (float)num);
			}
		}
		else
		{
			animation.cullingType = AnimationCullingType.AlwaysAnimate;
			flag = animation.clip == animationClip;
			animation.clip = null;
			if (!animation[animationClip.name])
			{
				animation.AddClip(animationClip, animationClip.name);
				animation.clip = animationClip;
			}
			else
			{
				animation.clip = animation[animationClip.name].clip;
			}
			if (!flag)
			{
				_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
			}
			if (flag || _0024AnimPlay_0024locals_0024._0024tab != null)
			{
				animation[animationClip.name].time = 0f;
				animation.Play(animationClip.name, PlayMode.StopAll);
			}
			else
			{
				animation.CrossFadeQueued(animationClip.name, (float)num, QueueMode.PlayNow);
			}
		}
		AnimSpeedCtrl(_0024AnimPlay_0024locals_0024._0024obj);
		if ((bool)animation && (bool)animation[animationClip.name])
		{
			AnimSpeedCtrl(animation[animationClip.name]);
		}
	}

	public AnimationState GetAnimState(GameObject obj, string motionName)
	{
		object obj2;
		if ((bool)obj)
		{
			Animation animation = _getAnim(obj);
			if ((bool)animation)
			{
				obj2 = animation[motionName];
				goto IL_0032;
			}
		}
		obj2 = null;
		goto IL_0032;
		IL_0032:
		return (AnimationState)obj2;
	}

	public void AnimSpeedCtrl(AnimationState animState)
	{
		if (exec && (bool)animState)
		{
			float speed = 0f;
			if (localPlayFlag)
			{
				speed = animSpeed;
			}
			animState.speed = speed;
		}
	}

	public void AnimSpeedCtrl(GameObject go)
	{
		if (!exec)
		{
			return;
		}
		if (!(go != null))
		{
			throw new AssertionFailedException("go != null");
		}
		Animation animation = _getAnim(go);
		MerlinMotionPackControl merlinMotionPackControl = _getMMPC(go);
		if ((bool)merlinMotionPackControl)
		{
			float timeScale = 0f;
			if (localPlayFlag)
			{
				timeScale = animSpeed;
			}
			merlinMotionPackControl.TimeScale = timeScale;
		}
		else
		{
			if (!animation)
			{
				return;
			}
			IEnumerator enumerator = animation.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animState = (AnimationState)obj;
				AnimSpeedCtrl(animState);
			}
		}
	}

	private void LoadCutScene(string cutSceneName, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ handler)
	{
		IEnumerator enumerator = LoadCutSceneMain(cutSceneName, handler);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator LoadCutSceneMain(string cutSceneName, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ handler)
	{
		return new _0024LoadCutSceneMain_002417462(cutSceneName, handler, this).GetEnumerator();
	}

	public void initializeFlags()
	{
		curIndex = 0;
		curCommandIndex = 0;
		curTag = string.Empty;
		lastTag = string.Empty;
		IsTagWait = false;
		jumpTag = string.Empty;
		count = 0;
		wait = 0f;
		waitMsec = 0f;
		nowLoading = false;
		playerChar = new GameObject[3];
		buttonWait = new bool[EventWindow.Instance.windowPrefab.Length];
		IsMoveWait = false;
		moveWaitCount = 0;
		IsMotionWait = false;
		IsCameraWait = false;
		IsWaitMessage = false;
		cameraWaitCount = 0;
		SetPlaybackMode(PlaybackMode.normal);
		seTable = new Hashtable();
		animSpeed = 1f;
		IsWaitPlayerInit = false;
		IsWaitPoppetPop = false;
		isDummyPlayerInitialized = false;
		isPlayerInitialized = false;
		hasStartTag = false;
		resumeBgm = false;
		useDummyPlayer = false;
		intoBattle = false;
		isPassedStartTag = false;
		isCameraPlayedMotion = false;
		mustFadeInAtStart = false;
		initialFaderWaitMSec = 700;
		UserData current = UserData.Current;
		RespPlayerInfo userStatus = current.userStatus;
		string text;
		angelName = (string.IsNullOrEmpty(text = userStatus.AngelName) ? "ENTER ANGEL NAME" : text);
		string text2;
		demonName = (string.IsNullOrEmpty(text2 = userStatus.DemonName) ? "ENTER DEMON NAME" : text2);
		string text3;
		poppetName = (string.IsNullOrEmpty(text3 = userStatus.PoppetName) ? "ENTER POPPETNAME" : text3);
	}

	public void postprocessReadCutsceneScript()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer != null)
		{
			standGround(currentPlayer.gameObject);
		}
		IEnumerator enumerator = cutSceneCmd.Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable hashtable = (Hashtable)obj;
			if (hashtable.ContainsKey("tag") && RuntimeServices.EqualityOperator(hashtable["tag"], startTagName))
			{
				hasStartTag = true;
			}
			if (hashtable.ContainsKey("tag") && RuntimeServices.EqualityOperator(hashtable["tag"], resumeBGMTagName))
			{
				resumeBgm = true;
			}
			if (hashtable.ContainsKey("arg1") && (RuntimeServices.EqualityOperator(hashtable["arg1"], angelGOName) || RuntimeServices.EqualityOperator(hashtable["arg1"], demonGOName)))
			{
				useDummyPlayer = true;
			}
			if (hashtable.ContainsKey("function") && hashtable.ContainsKey("arg1") && (RuntimeServices.EqualityOperator(hashtable["function"], seFuncName) || RuntimeServices.EqualityOperator(hashtable["function"], loopSeFuncName)))
			{
				object obj2 = hashtable["arg1"];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string text = (string)obj2;
				if (gameSndmgr.LoadSe(text))
				{
					seLoadList.Add(SQEX_SoundPlayerData.seNames[text]);
				}
			}
		}
		if (hasStartTag)
		{
			bool flag = false;
			bool flag2 = false;
			int num = 0;
			int num2 = cutSceneCmd.Count;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				if (!cutSceneCmd.ContainsKey(num3.ToString()))
				{
					continue;
				}
				object obj3 = cutSceneCmd[num3.ToString()];
				if (!(obj3 is Hashtable))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Hashtable));
				}
				Hashtable hashtable2 = (Hashtable)obj3;
				object obj4 = hashtable2["tag"];
				if (!(obj4 is string))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(string));
				}
				string text2 = (string)obj4;
				object obj5 = hashtable2["function"];
				if (!(obj5 is string))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(string));
				}
				string text3 = (string)obj5;
				if (!string.IsNullOrEmpty(text3) && text3.StartsWith("FADE_IN"))
				{
					if (flag2)
					{
					}
					flag = true;
				}
				if (!string.IsNullOrEmpty(text3) && text3.StartsWith("FADE_OUT"))
				{
					flag2 = true;
				}
				if (string.IsNullOrEmpty(text2) || !(text2 == startTagName))
				{
					continue;
				}
				break;
			}
			if (flag && flag2)
			{
				mustFadeInAtStart = true;
			}
			else if (!flag && !flag2)
			{
			}
		}
		string value = new StringBuilder("カットシーン ").Append(cutSceneName).Append("\n hasStartTag:").Append(hasStartTag)
			.ToString();
		value = new StringBuilder().Append(value).Append("\nIsResumeBgm:").Append(IsResumeBgm)
			.ToString();
		value = new StringBuilder().Append(value).Append("\nuseDummyPlayer:").Append(useDummyPlayer)
			.ToString();
		value = new StringBuilder().Append(value).Append("\nmustFadeInAtStart:").Append(mustFadeInAtStart)
			.ToString();
	}

	public void StartCutScene()
	{
		if (!abort)
		{
			UIButtonMessage.AllDisable = false;
			if (cutSceneCmd == null)
			{
				throw new AssertionFailedException("cutSceneCmd");
			}
			onStartSkipButton();
			cameraInit();
			exec = true;
			jumpTo = false;
			if ((bool)sndmgr)
			{
				sndmgr.StopAllSe(2000);
			}
			storeUIRootActivity();
			activateUIRoot();
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if (currentPlayer != null)
			{
				standGround(currentPlayer.gameObject);
			}
			if (_0024event_0024CutScenePlayStartEvent != null)
			{
				raise_CutScenePlayStartEvent(cutSceneName);
			}
		}
	}

	public void EndCutScene(bool error)
	{
		IEnumerator enumerator = DEFAULT_CAMERA(null);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		onEndSkipButton();
		EndCutSceneCore();
		result = !error;
		if (closeHandler != null)
		{
			closeHandler.Call(new object[0]);
		}
		closeHandler = null;
		if (fadeOutWithEnd)
		{
			FaderCore.Instance.fadeOut();
		}
		deactivateUIRoot();
		raise_CutScenePlayEndEvent(cutSceneName);
	}

	private void EndCutSceneCore()
	{
		animSpeed = 1f;
		RestoreParam(orgDataStack);
		STOP_ALL_SE();
		SetPlaybackMode(PlaybackMode.normal);
		PlayerFree();
		CharacterFree();
		EventWindow instance = EventWindow.Instance;
		if ((bool)instance)
		{
			instance.CloseAll();
		}
		ClearLoadObject();
		curCutSceneBustShotArray[0] = null;
		curCutSceneBustShotArray[1] = null;
		isBusy = false;
		animSpeed = 1f;
		gameSndmgr.UnloadSe(seLoadList.ToArray());
		seLoadList.Clear();
	}

	public void DataCommand(Hashtable orgData)
	{
		if (orgData == null)
		{
			return;
		}
		BasicCamera basicCamera = null;
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		bool flag = default(bool);
		FaderCore faderCore = null;
		object obj = null;
		Behaviour behaviour = null;
		Renderer renderer = null;
		Vector3 vector = default(Vector3);
		float num = default(float);
		try
		{
			if (RuntimeServices.op_Member("target.transform", orgData["cmd"] as string) && (orgData["obj"] == null || Camera.main == null || !RuntimeServices.EqualityOperator(orgData["obj"], Camera.main.gameObject)))
			{
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.centerOffset.x"))
			{
				object obj2 = orgData["obj"];
				if (!(obj2 is BasicCamera))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj2;
				if ((bool)basicCamera)
				{
					basicCamera.centerOffset.x = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.centerOffset.y"))
			{
				object obj3 = orgData["obj"];
				if (!(obj3 is BasicCamera))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj3;
				if ((bool)basicCamera)
				{
					basicCamera.centerOffset.y = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.centerOffset.z"))
			{
				object obj4 = orgData["obj"];
				if (!(obj4 is BasicCamera))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj4;
				if ((bool)basicCamera)
				{
					basicCamera.centerOffset.z = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.targetPosition.x"))
			{
				object obj5 = orgData["obj"];
				if (!(obj5 is BasicCamera))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj5;
				if ((bool)basicCamera)
				{
					basicCamera.targetPosition.x = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.targetPosition.y"))
			{
				object obj6 = orgData["obj"];
				if (!(obj6 is BasicCamera))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj6;
				if ((bool)basicCamera)
				{
					basicCamera.targetPosition.y = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.targetPosition.z"))
			{
				object obj7 = orgData["obj"];
				if (!(obj7 is BasicCamera))
				{
					obj7 = RuntimeServices.Coerce(obj7, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj7;
				if ((bool)basicCamera)
				{
					basicCamera.targetPosition.z = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.height"))
			{
				object obj8 = orgData["obj"];
				if (!(obj8 is BasicCamera))
				{
					obj8 = RuntimeServices.Coerce(obj8, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj8;
				if ((bool)basicCamera)
				{
					basicCamera.height = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.distance"))
			{
				object obj9 = orgData["obj"];
				if (!(obj9 is BasicCamera))
				{
					obj9 = RuntimeServices.Coerce(obj9, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj9;
				if ((bool)basicCamera)
				{
					basicCamera.distance = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.target"))
			{
				object obj10 = orgData["obj"];
				if (!(obj10 is BasicCamera))
				{
					obj10 = RuntimeServices.Coerce(obj10, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj10;
				if ((bool)basicCamera)
				{
					BasicCamera basicCamera2 = basicCamera;
					object obj11 = orgData["val"];
					if (!(obj11 is Transform))
					{
						obj11 = RuntimeServices.Coerce(obj11, typeof(Transform));
					}
					basicCamera2.target = (Transform)obj11;
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.currentFocusMode"))
			{
				object obj12 = orgData["obj"];
				if (!(obj12 is BasicCamera))
				{
					obj12 = RuntimeServices.Coerce(obj12, typeof(BasicCamera));
				}
				basicCamera = (BasicCamera)obj12;
				if ((bool)basicCamera)
				{
					basicCamera.currentFocusMode = (BasicCamera.FocusMode)orgData["val"];
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localPosition"))
			{
				object obj13 = orgData["obj"];
				if (!(obj13 is GameObject))
				{
					obj13 = RuntimeServices.Coerce(obj13, typeof(GameObject));
				}
				gameObject = (GameObject)obj13;
				if ((bool)gameObject)
				{
					gameObject.transform.localPosition = (Vector3)orgData["val"];
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localPosition.x"))
			{
				object obj14 = orgData["obj"];
				if (!(obj14 is GameObject))
				{
					obj14 = RuntimeServices.Coerce(obj14, typeof(GameObject));
				}
				gameObject = (GameObject)obj14;
				if ((bool)gameObject)
				{
					object value = orgData["val"];
					Vector3 localPosition = gameObject.transform.localPosition;
					float num2 = (localPosition.x = RuntimeServices.UnboxSingle(value));
					Vector3 vector3 = (gameObject.transform.localPosition = localPosition);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localPosition.y"))
			{
				object obj15 = orgData["obj"];
				if (!(obj15 is GameObject))
				{
					obj15 = RuntimeServices.Coerce(obj15, typeof(GameObject));
				}
				gameObject = (GameObject)obj15;
				if ((bool)gameObject)
				{
					object value2 = orgData["val"];
					Vector3 localPosition2 = gameObject.transform.localPosition;
					float num3 = (localPosition2.y = RuntimeServices.UnboxSingle(value2));
					Vector3 vector5 = (gameObject.transform.localPosition = localPosition2);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localPosition.z"))
			{
				object obj16 = orgData["obj"];
				if (!(obj16 is GameObject))
				{
					obj16 = RuntimeServices.Coerce(obj16, typeof(GameObject));
				}
				gameObject = (GameObject)obj16;
				if ((bool)gameObject)
				{
					object value3 = orgData["val"];
					Vector3 localPosition3 = gameObject.transform.localPosition;
					float num4 = (localPosition3.z = RuntimeServices.UnboxSingle(value3));
					Vector3 vector7 = (gameObject.transform.localPosition = localPosition3);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localRotation"))
			{
				object obj17 = orgData["obj"];
				if (!(obj17 is GameObject))
				{
					obj17 = RuntimeServices.Coerce(obj17, typeof(GameObject));
				}
				gameObject = (GameObject)obj17;
				if ((bool)gameObject)
				{
					gameObject.transform.localRotation = (Quaternion)orgData["val"];
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localRotation.x"))
			{
				object obj18 = orgData["obj"];
				if (!(obj18 is GameObject))
				{
					obj18 = RuntimeServices.Coerce(obj18, typeof(GameObject));
				}
				gameObject = (GameObject)obj18;
				if ((bool)gameObject)
				{
					object value4 = orgData["val"];
					Quaternion localRotation = gameObject.transform.localRotation;
					float num5 = (localRotation.x = RuntimeServices.UnboxSingle(value4));
					Quaternion quaternion2 = (gameObject.transform.localRotation = localRotation);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localRotation.y"))
			{
				object obj19 = orgData["obj"];
				if (!(obj19 is GameObject))
				{
					obj19 = RuntimeServices.Coerce(obj19, typeof(GameObject));
				}
				gameObject = (GameObject)obj19;
				if ((bool)gameObject)
				{
					object value5 = orgData["val"];
					Quaternion localRotation2 = gameObject.transform.localRotation;
					float num6 = (localRotation2.y = RuntimeServices.UnboxSingle(value5));
					Quaternion quaternion4 = (gameObject.transform.localRotation = localRotation2);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localRotation.z"))
			{
				object obj20 = orgData["obj"];
				if (!(obj20 is GameObject))
				{
					obj20 = RuntimeServices.Coerce(obj20, typeof(GameObject));
				}
				gameObject = (GameObject)obj20;
				if ((bool)gameObject)
				{
					object value6 = orgData["val"];
					Quaternion localRotation3 = gameObject.transform.localRotation;
					float num7 = (localRotation3.z = RuntimeServices.UnboxSingle(value6));
					Quaternion quaternion6 = (gameObject.transform.localRotation = localRotation3);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localScale"))
			{
				object obj21 = orgData["obj"];
				if (!(obj21 is GameObject))
				{
					obj21 = RuntimeServices.Coerce(obj21, typeof(GameObject));
				}
				gameObject = (GameObject)obj21;
				vector = (Vector3)orgData["val"];
				if ((bool)gameObject && isValidScale(vector))
				{
					gameObject.transform.localScale = (Vector3)orgData["val"];
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localScale.x"))
			{
				object obj22 = orgData["obj"];
				if (!(obj22 is GameObject))
				{
					obj22 = RuntimeServices.Coerce(obj22, typeof(GameObject));
				}
				gameObject = (GameObject)obj22;
				num = RuntimeServices.UnboxSingle(orgData["val"]);
				if ((bool)gameObject && isValidScale(num))
				{
					object value7 = orgData["val"];
					Vector3 localScale = gameObject.transform.localScale;
					float num8 = (localScale.x = RuntimeServices.UnboxSingle(value7));
					Vector3 vector9 = (gameObject.transform.localScale = localScale);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localScale.y"))
			{
				object obj23 = orgData["obj"];
				if (!(obj23 is GameObject))
				{
					obj23 = RuntimeServices.Coerce(obj23, typeof(GameObject));
				}
				gameObject = (GameObject)obj23;
				num = RuntimeServices.UnboxSingle(orgData["val"]);
				if ((bool)gameObject && isValidScale(num))
				{
					object value8 = orgData["val"];
					Vector3 localScale2 = gameObject.transform.localScale;
					float num9 = (localScale2.y = RuntimeServices.UnboxSingle(value8));
					Vector3 vector11 = (gameObject.transform.localScale = localScale2);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localScale.z"))
			{
				object obj24 = orgData["obj"];
				if (!(obj24 is GameObject))
				{
					obj24 = RuntimeServices.Coerce(obj24, typeof(GameObject));
				}
				gameObject = (GameObject)obj24;
				num = RuntimeServices.UnboxSingle(orgData["val"]);
				if ((bool)gameObject && isValidScale(num))
				{
					object value9 = orgData["val"];
					Vector3 localScale3 = gameObject.transform.localScale;
					float num10 = (localScale3.z = RuntimeServices.UnboxSingle(value9));
					Vector3 vector13 = (gameObject.transform.localScale = localScale3);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localEulerAngles"))
			{
				object obj25 = orgData["obj"];
				if (!(obj25 is GameObject))
				{
					obj25 = RuntimeServices.Coerce(obj25, typeof(GameObject));
				}
				gameObject = (GameObject)obj25;
				if ((bool)gameObject)
				{
					gameObject.transform.localEulerAngles = (Vector3)orgData["val"];
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localEulerAngles.x"))
			{
				object obj26 = orgData["obj"];
				if (!(obj26 is GameObject))
				{
					obj26 = RuntimeServices.Coerce(obj26, typeof(GameObject));
				}
				gameObject = (GameObject)obj26;
				if ((bool)gameObject)
				{
					object value10 = orgData["val"];
					Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
					float num11 = (localEulerAngles.x = RuntimeServices.UnboxSingle(value10));
					Vector3 vector15 = (gameObject.transform.localEulerAngles = localEulerAngles);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localEulerAngles.y"))
			{
				object obj27 = orgData["obj"];
				if (!(obj27 is GameObject))
				{
					obj27 = RuntimeServices.Coerce(obj27, typeof(GameObject));
				}
				gameObject = (GameObject)obj27;
				if ((bool)gameObject)
				{
					object value11 = orgData["val"];
					Vector3 localEulerAngles2 = gameObject.transform.localEulerAngles;
					float num12 = (localEulerAngles2.y = RuntimeServices.UnboxSingle(value11));
					Vector3 vector17 = (gameObject.transform.localEulerAngles = localEulerAngles2);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.transform.localEulerAngles.z"))
			{
				object obj28 = orgData["obj"];
				if (!(obj28 is GameObject))
				{
					obj28 = RuntimeServices.Coerce(obj28, typeof(GameObject));
				}
				gameObject = (GameObject)obj28;
				if ((bool)gameObject)
				{
					object value12 = orgData["val"];
					Vector3 localEulerAngles3 = gameObject.transform.localEulerAngles;
					float num13 = (localEulerAngles3.z = RuntimeServices.UnboxSingle(value12));
					Vector3 vector19 = (gameObject.transform.localEulerAngles = localEulerAngles3);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "other.transform.position.xz"))
			{
				object obj29 = orgData["obj"];
				if (!(obj29 is GameObject))
				{
					obj29 = RuntimeServices.Coerce(obj29, typeof(GameObject));
				}
				gameObject = (GameObject)obj29;
				object obj30 = orgData["val"];
				if (!(obj30 is GameObject))
				{
					obj30 = RuntimeServices.Coerce(obj30, typeof(GameObject));
				}
				gameObject2 = (GameObject)obj30;
				if ((bool)gameObject && (bool)gameObject2)
				{
					float x = gameObject2.transform.position.x;
					Vector3 position = gameObject.transform.position;
					float num14 = (position.x = x);
					Vector3 vector21 = (gameObject.transform.position = position);
					float z = gameObject2.transform.position.z;
					Vector3 position2 = gameObject.transform.position;
					float num15 = (position2.z = z);
					Vector3 vector23 = (gameObject.transform.position = position2);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.sleep"))
			{
				object obj31 = orgData["obj"];
				if (!(obj31 is GameObject))
				{
					obj31 = RuntimeServices.Coerce(obj31, typeof(GameObject));
				}
				gameObject = (GameObject)obj31;
				obj = gameObject.GetComponentInChildren<NPCControl>();
				if (RuntimeServices.ToBool(obj))
				{
					RuntimeServices.SetProperty(obj, "StopMove", true);
				}
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.enabled"))
			{
				execCmdTargetEnabled(orgData);
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "renderer.enabled"))
			{
				object obj32 = orgData["obj"];
				if (!(obj32 is Renderer))
				{
					obj32 = RuntimeServices.Coerce(obj32, typeof(Renderer));
				}
				Renderer renderer2 = (Renderer)obj32;
				if ((bool)renderer2)
				{
					flag = RuntimeServices.UnboxBoolean(orgData["val"]);
					renderer2.enabled = flag;
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "renderer.updateWhenOffscreen"))
			{
				object obj33 = orgData["obj"];
				if (!(obj33 is SkinnedMeshRenderer))
				{
					obj33 = RuntimeServices.Coerce(obj33, typeof(SkinnedMeshRenderer));
				}
				SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)obj33;
				if ((bool)skinnedMeshRenderer)
				{
					flag = RuntimeServices.UnboxBoolean(orgData["val"]);
					skinnedMeshRenderer.updateWhenOffscreen = flag;
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "add.comp"))
			{
				object obj34 = orgData["obj"];
				if (!(obj34 is GameObject))
				{
					obj34 = RuntimeServices.Coerce(obj34, typeof(GameObject));
				}
				gameObject = (GameObject)obj34;
				if ((bool)gameObject)
				{
					obj = orgData["val"];
					object obj35 = obj;
					if (!(obj35 is UnityEngine.Object))
					{
						obj35 = RuntimeServices.Coerce(obj35, typeof(UnityEngine.Object));
					}
					UnityEngine.Object.Destroy((UnityEngine.Object)obj35);
				}
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "play.anim"))
			{
				object obj36 = orgData["obj"];
				if (!(obj36 is Animation))
				{
					obj36 = RuntimeServices.Coerce(obj36, typeof(Animation));
				}
				Animation animation = (Animation)obj36;
				if ((bool)animation)
				{
					object obj37 = orgData["val"];
					object obj38 = obj37;
					if (!(obj38 is string))
					{
						obj38 = RuntimeServices.Coerce(obj38, typeof(string));
					}
					animation.Stop((string)obj38);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "transform.parent"))
			{
				object obj39 = orgData["obj"];
				if (!(obj39 is Transform))
				{
					obj39 = RuntimeServices.Coerce(obj39, typeof(Transform));
				}
				Transform transform = (Transform)obj39;
				if ((bool)transform)
				{
					object obj40 = orgData["val"];
					if (!(obj40 is Transform))
					{
						obj40 = RuntimeServices.Coerce(obj40, typeof(Transform));
					}
					Transform parent = (Transform)obj40;
					transform.parent = parent;
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.name"))
			{
				object obj41 = orgData["obj"];
				if (!(obj41 is GameObject))
				{
					obj41 = RuntimeServices.Coerce(obj41, typeof(GameObject));
				}
				gameObject = (GameObject)obj41;
				if ((bool)gameObject)
				{
					GameObject obj42 = gameObject;
					object obj43 = orgData["val"];
					if (!(obj43 is string))
					{
						obj43 = RuntimeServices.Coerce(obj43, typeof(string));
					}
					obj42.name = (string)obj43;
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.active"))
			{
				object obj44 = orgData["obj"];
				if (!(obj44 is GameObject))
				{
					obj44 = RuntimeServices.Coerce(obj44, typeof(GameObject));
				}
				gameObject = (GameObject)obj44;
				if ((bool)gameObject)
				{
					flag = RuntimeServices.UnboxBoolean(orgData["val"]);
					gameObject.SetActive(flag);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.instantiate"))
			{
				object obj45 = orgData["obj"];
				if (!(obj45 is GameObject))
				{
					obj45 = RuntimeServices.Coerce(obj45, typeof(GameObject));
				}
				gameObject = (GameObject)obj45;
				if ((bool)gameObject)
				{
					UnityEngine.Object.DestroyObject(gameObject);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "target.layer"))
			{
				object obj46 = orgData["obj"];
				if (!(obj46 is GameObject))
				{
					obj46 = RuntimeServices.Coerce(obj46, typeof(GameObject));
				}
				gameObject = (GameObject)obj46;
				if ((bool)gameObject)
				{
					object value13 = orgData["val"];
					gameObject.layer = RuntimeServices.UnboxInt32(value13);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "cam.fieldOfView"))
			{
				object obj47 = orgData["obj"];
				if (!(obj47 is Camera))
				{
					obj47 = RuntimeServices.Coerce(obj47, typeof(Camera));
				}
				Camera camera = (Camera)obj47;
				if ((bool)camera)
				{
					camera.fieldOfView = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "mmpc.baseMode"))
			{
				object obj48 = orgData["obj"];
				if (!(obj48 is MerlinMotionPackControl))
				{
					obj48 = RuntimeServices.Coerce(obj48, typeof(MerlinMotionPackControl));
				}
				MerlinMotionPackControl merlinMotionPackControl = (MerlinMotionPackControl)obj48;
				if ((bool)merlinMotionPackControl)
				{
					merlinMotionPackControl.baseMode = RuntimeServices.UnboxBoolean(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "mmpc.CurrentAnimType"))
			{
				object obj49 = orgData["obj"];
				if (!(obj49 is MerlinMotionPackControl))
				{
					obj49 = RuntimeServices.Coerce(obj49, typeof(MerlinMotionPackControl));
				}
				MerlinMotionPackControl merlinMotionPackControl = (MerlinMotionPackControl)obj49;
				if ((bool)merlinMotionPackControl && !RuntimeServices.EqualityOperator(orgData["val"], -1))
				{
					merlinMotionPackControl.playByType(RuntimeServices.UnboxInt32(orgData["val"]));
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "sound.bgm"))
			{
				if (!sndmgr || !resumeBgm)
				{
					return;
				}
				object obj50 = orgData["name"];
				if (!(obj50 is string))
				{
					obj50 = RuntimeServices.Coerce(obj50, typeof(string));
				}
				string text = (string)obj50;
				int loop = RuntimeServices.UnboxInt32(orgData["loop"]);
				float num16 = RuntimeServices.UnboxSingle(orgData["vol"]);
				float pan = RuntimeServices.UnboxSingle(orgData["pan"]);
				if (!string.IsNullOrEmpty(text))
				{
					if (!sndmgr.IsPlayBgm() || !sndmgr.IsLastBgm(text))
					{
						GameSoundManager.PlayBgmDirect(text, 1f, pan, 2000, loop);
					}
				}
				else
				{
					sndmgr.StopBgm(500);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "fader.r"))
			{
				object obj51 = orgData["obj"];
				if (!(obj51 is FaderCore))
				{
					obj51 = RuntimeServices.Coerce(obj51, typeof(FaderCore));
				}
				faderCore = (FaderCore)obj51;
				if ((bool)faderCore)
				{
					faderCore.red = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "fader.g"))
			{
				object obj52 = orgData["obj"];
				if (!(obj52 is FaderCore))
				{
					obj52 = RuntimeServices.Coerce(obj52, typeof(FaderCore));
				}
				faderCore = (FaderCore)obj52;
				if ((bool)faderCore)
				{
					faderCore.green = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "fader.b"))
			{
				object obj53 = orgData["obj"];
				if (!(obj53 is FaderCore))
				{
					obj53 = RuntimeServices.Coerce(obj53, typeof(FaderCore));
				}
				faderCore = (FaderCore)obj53;
				if ((bool)faderCore)
				{
					faderCore.blue = RuntimeServices.UnboxSingle(orgData["val"]);
				}
				return;
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "poppet.summon"))
			{
				object obj54 = orgData["val"];
				if (!(obj54 is AIControl))
				{
					obj54 = RuntimeServices.Coerce(obj54, typeof(AIControl));
				}
				AIControl aIControl = (AIControl)obj54;
				aIControl.forceToIdle();
			}
			if (RuntimeServices.EqualityOperator(orgData["cmd"], "player.input"))
			{
				object obj55 = orgData["obj"];
				if (!(obj55 is PlayerControl))
				{
					obj55 = RuntimeServices.Coerce(obj55, typeof(PlayerControl));
				}
				PlayerControl playerControl = (PlayerControl)obj55;
				playerControl.InputActive = RuntimeServices.UnboxBoolean(orgData["val"]);
			}
		}
		catch (Exception)
		{
			object obj56 = orgData["cmd"];
			if (!(obj56 is string))
			{
				obj56 = RuntimeServices.Coerce(obj56, typeof(string));
			}
			string lhs = (string)obj56;
			if (orgData.ContainsKey("obj"))
			{
				lhs += ": " + orgData["obj"];
			}
			if (orgData.ContainsKey("val"))
			{
				lhs += ": " + orgData["val"];
			}
		}
	}

	private void pushCmdTargetEnabledAndSet(Stack stack, object comp, bool newEnabled)
	{
		if (comp is Behaviour)
		{
			Behaviour behaviour = comp as Behaviour;
			stack.Push(new Hash
			{
				{ "cmd", "target.enabled" },
				{ "obj", behaviour },
				{ "val", behaviour.enabled }
			});
			behaviour.enabled = newEnabled;
		}
		else if (comp is Renderer)
		{
			Renderer renderer = comp as Renderer;
			stack.Push(new Hash
			{
				{ "cmd", "target.enabled" },
				{ "obj", renderer },
				{ "val", renderer.enabled }
			});
			renderer.enabled = newEnabled;
		}
		else if (comp is Collider)
		{
			Collider collider = comp as Collider;
			stack.Push(new Hash
			{
				{ "cmd", "target.enabled" },
				{ "obj", collider },
				{ "val", collider.enabled }
			});
			collider.enabled = newEnabled;
		}
		else if (comp is ParticleEmitter)
		{
			ParticleEmitter particleEmitter = comp as ParticleEmitter;
			stack.Push(new Hash
			{
				{ "cmd", "target.enabled" },
				{ "obj", particleEmitter },
				{ "val", particleEmitter.enabled }
			});
			particleEmitter.enabled = newEnabled;
		}
	}

	private void execCmdTargetEnabled(Hashtable cmdData)
	{
		object obj = cmdData["val"];
		object obj2 = cmdData["obj"];
		Behaviour behaviour = obj2 as Behaviour;
		Renderer renderer = obj2 as Renderer;
		Collider collider = obj2 as Collider;
		ParticleEmitter particleEmitter = obj2 as ParticleEmitter;
		if (behaviour != null)
		{
			behaviour.enabled = RuntimeServices.UnboxBoolean(obj);
			if (!RuntimeServices.EqualityOperator(behaviour.enabled, obj))
			{
				throw new AssertionFailedException("beh.enabled == flag");
			}
		}
		else if (renderer != null)
		{
			renderer.enabled = RuntimeServices.UnboxBoolean(obj);
			if (!RuntimeServices.EqualityOperator(renderer.enabled, obj))
			{
				throw new AssertionFailedException("rdr.enabled == flag");
			}
		}
		else if (collider != null)
		{
			collider.enabled = RuntimeServices.UnboxBoolean(obj);
			if (!RuntimeServices.EqualityOperator(collider.enabled, obj))
			{
				throw new AssertionFailedException("col.enabled == flag");
			}
		}
		else if (particleEmitter != null)
		{
			particleEmitter.enabled = RuntimeServices.UnboxBoolean(obj);
			if (!RuntimeServices.EqualityOperator(particleEmitter.enabled, obj))
			{
				throw new AssertionFailedException("pe.enabled == flag");
			}
		}
	}

	public void RestoreParam(Stack dataStack)
	{
		BasicCamera basicCamera = null;
		GameObject gameObject = null;
		bool flag = default(bool);
		while (dataStack.Count > 0)
		{
			object obj = dataStack.Pop();
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable orgData = (Hashtable)obj;
			DataCommand(orgData);
		}
	}

	public void _tickWaitCount()
	{
		wait -= animSpeed;
		if (!(wait >= 0f))
		{
			wait = 0f;
		}
		waitMsec -= animSpeed * (Time.deltaTime * 1000f);
		if (!(waitMsec >= 0f))
		{
			waitMsec = 0f;
		}
	}

	public bool WaitCheck()
	{
		bool flag = false;
		if (IsSkipping)
		{
			if (IsBreakSkipByTag)
			{
				HIDE_MESSAGE(null);
				StopSkip();
				flag = true;
			}
			if (IsWaitButton && IsWaitMessage && !IsMessageFinish)
			{
				StopSkip();
				flag = true;
			}
		}
		if (IsWaitButton && !IsSkipping)
		{
			flag = true;
		}
		_tickWaitCount();
		if (!IsSkipping)
		{
			if (IsTimeWait)
			{
				flag = true;
			}
			if (IsMoveWait)
			{
				flag = true;
			}
			if (IsMotionWait)
			{
				flag = true;
			}
			if (IsCameraWait)
			{
				flag = true;
			}
		}
		return flag;
	}

	public void PlayerFree()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer != null))
		{
			return;
		}
		currentPlayer.forceToIdle();
		standGround(currentPlayer.gameObject);
		currentPlayer.setSkillIcon();
		IEnumerator enumerator = currentPlayer.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.localPosition = Vector3.zero;
		}
		if (intoBattle)
		{
			currentPlayer.ChangeBattleMode(PlayerControl.BATTLE_MODE.Battle);
		}
		else
		{
			currentPlayer.ChangeBattleMode(PlayerControl.BATTLE_MODE.Non_Battle);
		}
	}

	public void CharacterFree()
	{
		int i = 0;
		Animation[] array = (Animation[])UnityEngine.Object.FindObjectsOfType(typeof(Animation));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			IEnumerator enumerator = array[i].GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				animationState.speed = 1f;
			}
		}
	}

	public void OnSceneReady()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer != null))
		{
			return;
		}
		standGround(currentPlayer.gameObject);
		IEnumerator enumerator = currentPlayer.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			transform.localPosition = Vector3.zero;
		}
	}

	public void ExecCutScene()
	{
		if (pause)
		{
			if (!stepPlay)
			{
				localPlayFlag = false;
				return;
			}
			stepPlay = false;
		}
		localPlayFlag = true;
		if (cutSceneFile == null || cutSceneCmd == null || !exec || WaitCheck())
		{
			return;
		}
		bool flag = exec;
		fadeWait = 0;
		if ((bool)fader && !fader.isCompleted)
		{
			fadeWait = 1;
		}
		checked
		{
			count++;
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			while (exec && curIndex <= cutSceneCmd.Count)
			{
				string key = curCommandIndex.ToString();
				if (!cutSceneCmd.ContainsKey(key))
				{
					curCommandIndex++;
					continue;
				}
				object obj = cutSceneCmd[key];
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				Hashtable hashtable = (Hashtable)obj;
				object obj2 = hashtable["tag"];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string value = (string)obj2;
				object obj3 = hashtable["function"];
				if (!(obj3 is string))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(string));
				}
				string text = (string)obj3;
				if (!string.IsNullOrEmpty(value))
				{
					curTag = value;
				}
				if (!string.IsNullOrEmpty(curTag) && startTagName == curTag && !IsSceneReady)
				{
					isPassedStartTag = true;
					OnSceneReady();
				}
				if (currentPlayer != null && !string.IsNullOrEmpty(curTag) && intoBattleTagName == curTag && !intoBattle)
				{
					intoBattle = true;
				}
				if (IsJumping)
				{
					if (!(curTag == jumpTag))
					{
						curIndex++;
						curCommandIndex++;
						if (cutSceneCmd == null)
						{
							break;
						}
						continue;
					}
					breakJump();
				}
				if (RuntimeServices.EqualityOperator(hashtable["function"], "PLAYER_CHR_INIT") && !IsJumping && !IsSkipping)
				{
					if (!isPlayerInitialized && !IsWaitPlayerInit)
					{
						StartCoroutine("WAIT_PLAYER_INIT");
						break;
					}
					if (!isPlayerInitialized)
					{
						break;
					}
				}
				if (!RuntimeServices.EqualityOperator(hashtable["function"], "SUMMON_POPPET") || IsJumping || IsSkipping)
				{
				}
				if (IsWaitPlayerInit || IsWaitPoppetPop)
				{
					break;
				}
				if (text.Length > 0)
				{
					if (IsSkipping)
					{
						object obj4 = hashtable["function"];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						if (!isFuncDontSkip((string)obj4))
						{
							object obj5 = hashtable["tag"];
							if (!(obj5 is string))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(string));
							}
							if (!isTagDontSkip((string)obj5))
							{
								goto IL_03b8;
							}
						}
					}
					StartCoroutine(text, hashtable);
				}
				goto IL_03b8;
				IL_03b8:
				curIndex++;
				curCommandIndex++;
				if (WaitCheck() || cutSceneCmd == null)
				{
					break;
				}
			}
			if (cutSceneCmd == null)
			{
				exec = false;
			}
			else if (curIndex > cutSceneCmd.Count)
			{
				exec = false;
			}
			if (flag && !exec)
			{
				EndCutScene(error: false);
			}
		}
	}

	public float CalcSingle(float frm, float to, float cur, float max)
	{
		return (cur != 0f && max != 0f) ? Mathf.Lerp(frm, to, cur / max) : to;
	}

	public float CalcSingle(float frm, float to, int cur, int max)
	{
		return CalcSingle(frm, to, (float)cur, (float)max);
	}

	public string[] StringApplyLangageAndGender(string titleId, string messageId)
	{
		_0024StringApplyLangageAndGender_0024locals_002414390 _0024StringApplyLangageAndGender_0024locals_0024 = new _0024StringApplyLangageAndGender_0024locals_002414390();
		string empty = string.Empty;
		string empty2 = string.Empty;
		_0024StringApplyLangageAndGender_0024locals_0024._0024isPlayerTalking = false;
		RACE_TYPE rACE_TYPE = RACE_TYPE.Tensi;
		object obj = cutSceneString[titleId];
		if (!(obj is Hashtable))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
		}
		Hashtable hashtable = (Hashtable)obj;
		object obj2 = cutSceneString[messageId];
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		Hashtable hashtable2 = (Hashtable)obj2;
		if (hashtable == null)
		{
			throw new AssertionFailedException("titleTab != null");
		}
		if (hashtable2 == null)
		{
			throw new AssertionFailedException("messageTab != null");
		}
		object obj3 = hashtable["ja_m"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		_0024StringApplyLangageAndGender_0024locals_0024._0024rawTitle = (string)obj3;
		__CutSceneManager_StringApplyLangageAndGender_0024callable166_00241819_13__ _CutSceneManager_StringApplyLangageAndGender_0024callable166_00241819_13__ = new _0024StringApplyLangageAndGender_0024_apply_00243799(_0024StringApplyLangageAndGender_0024locals_0024).Invoke;
		if (!string.IsNullOrEmpty(_0024StringApplyLangageAndGender_0024locals_0024._0024rawTitle))
		{
			Regex regex = new Regex(new StringBuilder().Append("PC_NAME_[AD]").ToString());
			_0024StringApplyLangageAndGender_0024locals_0024._0024isPlayerTalking = regex.Match(_0024StringApplyLangageAndGender_0024locals_0024._0024rawTitle).Success;
		}
		empty = _CutSceneManager_StringApplyLangageAndGender_0024callable166_00241819_13__(hashtable);
		empty2 = _CutSceneManager_StringApplyLangageAndGender_0024callable166_00241819_13__(hashtable2);
		return new string[2] { empty, empty2 };
	}

	public string MotionApplyWeaponType(string motionName)
	{
		string text;
		if (string.IsNullOrEmpty(motionName))
		{
			text = motionName;
		}
		else
		{
			UserData current;
			try
			{
				current = UserData.Current;
			}
			catch (Exception)
			{
				goto IL_0119;
			}
			RespWeapon respWeapon = null;
			respWeapon = ((!current.IsValidDeck2) ? current.MainWeapon : current.ActiveWeapon);
			if (respWeapon == null)
			{
				throw new AssertionFailedException("UserDataから武器を取得出来ませんでした");
			}
			string newValue = string.Empty;
			if (respWeapon != null)
			{
				if (respWeapon.Style.Id == 1)
				{
					newValue = "1hs";
				}
				else if (respWeapon.Style.Id == 2)
				{
					newValue = "spr";
				}
				else if (respWeapon.Style.Id == 1)
				{
					newValue = "1hs";
				}
				else if (respWeapon.Style.Id == 3)
				{
					newValue = "bow";
				}
				else if (respWeapon.Style.Id == 4)
				{
					newValue = "hth";
				}
				else if (respWeapon.Style.Id == 5)
				{
					newValue = "2hs";
				}
			}
			motionName.Replace("{weapon_type}", newValue);
			text = motionName;
		}
		goto IL_011a;
		IL_0119:
		text = motionName;
		goto IL_011a;
		IL_011a:
		return text;
	}

	public void Pause()
	{
		SetPlaybackMode(PlaybackMode.pause);
	}

	public void Skip()
	{
		SetPlaybackMode(PlaybackMode.skip);
	}

	public void PlayFast()
	{
		SetPlaybackMode(PlaybackMode.fast);
	}

	public void PlayNormal()
	{
		SetPlaybackMode(PlaybackMode.normal);
	}

	public void StopSkip()
	{
		SetPlaybackMode(PlaybackMode.normal);
		IsWaitMessage = false;
		IsTagWait = false;
	}

	public void SetPlaybackMode()
	{
		SetPlaybackMode(PlaybackMode.normal);
	}

	public void SetPlaybackMode(PlaybackMode mode)
	{
		if (mode == PlaybackMode.skip && !IsSkipping)
		{
			lastAnimSpeed = animSpeed;
			animSpeed = skipSpeed;
		}
		else
		{
			switch (mode)
			{
			case PlaybackMode.normal:
				animSpeed = 1f;
				break;
			case PlaybackMode.fast:
				animSpeed = fastSpeed;
				break;
			default:
				if (mode == currentPlaybackMode)
				{
					return;
				}
				switch (mode)
				{
				}
				break;
			}
		}
		currentPlaybackMode = mode;
	}

	public void storeUIRootActivity()
	{
		UIRoot componentInChildren = gameObject.GetComponentInChildren<UIRoot>();
		UIRoot[] array = (UIRoot[])UnityEngine.Object.FindObjectsOfType(typeof(UIRoot));
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			UIRoot uIRoot = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			if (uIRoot.name.Contains("UI Root") && componentInChildren != uIRoot && !uIRoot.name.Contains("Fader"))
			{
				Hashtable hashtable = new Hashtable();
				hashtable = new Hash
				{
					{ "cmd", "target.active" },
					{ "obj", uIRoot.gameObject },
					{
						"val",
						uIRoot.gameObject.active
					}
				};
				orgDataStack.Push(hashtable);
				uIRoot.gameObject.SetActive(value: false);
			}
		}
	}

	public void activateUIRoot()
	{
		Transform transform = this.transform.Find("UI Root (2D)");
		if ((bool)transform)
		{
			transform.gameObject.SetActive(value: true);
		}
	}

	public void deactivateUIRoot()
	{
		Transform transform = this.transform.Find("UI Root (2D)");
		if ((bool)transform)
		{
			transform.gameObject.SetActive(value: false);
		}
	}

	public IEnumerator PLAY_MOTION(Hashtable arg)
	{
		return new _0024PLAY_MOTION_002417478(arg, this).GetEnumerator();
	}

	public IEnumerator PLAY_MOTION_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024PLAY_MOTION_FOR_CUTSCENE_OBJID_002417486(arg, this).GetEnumerator();
	}

	public IEnumerator PLAY_MOTION_core(Hashtable arg)
	{
		return new _0024PLAY_MOTION_core_002417494(arg, this).GetEnumerator();
	}

	public IEnumerator NEXT_MOTION(Hashtable arg)
	{
		return new _0024NEXT_MOTION_002417515(arg, this).GetEnumerator();
	}

	public IEnumerator NEXT_MOTION_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024NEXT_MOTION_FOR_CUTSCENE_OBJID_002417523(arg, this).GetEnumerator();
	}

	public IEnumerator NEXT_MOTION_core(Hashtable arg)
	{
		return new _0024NEXT_MOTION_core_002417531(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_TARGET(Hashtable arg)
	{
		return new _0024MOVE_TARGET_002417553(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_TARGET_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024MOVE_TARGET_FOR_CUTSCENE_OBJID_002417561(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_TARGET_OVERTIME(Hashtable arg)
	{
		return new _0024MOVE_TARGET_OVERTIME_002417569(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024MOVE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417578(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_TARGET_core(Hashtable arg)
	{
		return new _0024MOVE_TARGET_core_002417586(arg, this).GetEnumerator();
	}

	public IEnumerator ROTATE_TARGET(Hashtable arg)
	{
		return new _0024ROTATE_TARGET_002417633(arg, this).GetEnumerator();
	}

	public IEnumerator ROTATE_TARGET_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024ROTATE_TARGET_FOR_CUTSCENE_OBJID_002417641(arg, this).GetEnumerator();
	}

	public IEnumerator ROTATE_TARGET_OVERTIME(Hashtable arg)
	{
		return new _0024ROTATE_TARGET_OVERTIME_002417649(arg, this).GetEnumerator();
	}

	public IEnumerator ROTATE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024ROTATE_TARGET_OVERTIME_FOR_CUTSCENE_OBJID_002417657(arg, this).GetEnumerator();
	}

	public IEnumerator ROTATE_TARGET_core(Hashtable arg)
	{
		return new _0024ROTATE_TARGET_core_002417665(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_ROTATE(Hashtable arg)
	{
		return new _0024MOVE_ROTATE_002417705(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_ROTATE_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024MOVE_ROTATE_FOR_CUTSCENE_OBJID_002417714(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_ROTATE_OVERTIME(Hashtable arg)
	{
		return new _0024MOVE_ROTATE_OVERTIME_002417722(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_ROTATE_OVERTIME_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024MOVE_ROTATE_OVERTIME_FOR_CUTSCENE_OBJID_002417731(arg, this).GetEnumerator();
	}

	public IEnumerator MOVE_ROTATE_core(Hashtable arg)
	{
		return new _0024MOVE_ROTATE_core_002417739(arg, this).GetEnumerator();
	}

	public void SET_CHR(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			arg["arg1"] = gameObject;
			SET_CHR_core(arg);
		}
	}

	public void SET_CHR_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg1"] = value;
		SET_CHR_core(arg);
	}

	public void SET_CHR_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float num = float.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		float num2 = float.Parse((string)obj3);
		object obj4 = arg["arg4"];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		float num3 = float.Parse((string)obj4);
		if (!gameObject)
		{
			return;
		}
		float x = gameObject.transform.localPosition.x;
		float z = gameObject.transform.localPosition.z;
		float y = gameObject.transform.localEulerAngles.y;
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		Hashtable hashtable3 = new Hashtable();
		hashtable = new Hash
		{
			{ "cmd", "target.transform.localPosition.x" },
			{ "obj", gameObject },
			{
				"val",
				gameObject.transform.localPosition.x
			}
		};
		hashtable2 = new Hash
		{
			{ "cmd", "target.transform.localPosition.z" },
			{ "obj", gameObject },
			{
				"val",
				gameObject.transform.localPosition.z
			}
		};
		hashtable3 = new Hash
		{
			{ "cmd", "target.transform.localEulerAngles.y" },
			{ "obj", gameObject },
			{
				"val",
				gameObject.transform.localEulerAngles.y
			}
		};
		orgDataStack.Push(hashtable);
		orgDataStack.Push(hashtable2);
		orgDataStack.Push(hashtable3);
		float x2 = num;
		Vector3 localPosition = gameObject.transform.localPosition;
		float num4 = (localPosition.x = x2);
		Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
		float z2 = num2;
		Vector3 localPosition2 = gameObject.transform.localPosition;
		float num5 = (localPosition2.z = z2);
		Vector3 vector4 = (gameObject.transform.localPosition = localPosition2);
		float y2 = num3;
		Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
		float num6 = (localEulerAngles.y = y2);
		Vector3 vector6 = (gameObject.transform.localEulerAngles = localEulerAngles);
		CharacterController characterController = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
		if (characterController != null && characterController.enabled)
		{
			standGround(gameObject);
		}
		Transform transform = ObjUtilModule.Find1stDescendant(gameObject.transform, "y_ang");
		if (!transform)
		{
			return;
		}
		if (gameObject.transform != transform.parent)
		{
			Hashtable hashtable4 = new Hashtable();
			hashtable4 = new Hash
			{
				{ "cmd", "target.transform.localEulerAngles.y" },
				{
					"obj",
					transform.parent.gameObject
				},
				{
					"val",
					transform.parent.localEulerAngles.y
				}
			};
			orgDataStack.Push(hashtable4);
			if ((bool)transform.parent)
			{
				int num7 = 0;
				Vector3 localEulerAngles2 = transform.parent.localEulerAngles;
				float num8 = (localEulerAngles2.y = num7);
				Vector3 vector8 = (transform.parent.localEulerAngles = localEulerAngles2);
			}
		}
		if (gameObject.transform != transform)
		{
			Hashtable hashtable5 = new Hashtable();
			hashtable5 = new Hash
			{
				{ "cmd", "target.transform.localEulerAngles.y" },
				{ "obj", transform.gameObject },
				{
					"val",
					transform.localEulerAngles.y
				}
			};
			orgDataStack.Push(hashtable5);
			int num9 = 0;
			Vector3 localEulerAngles3 = transform.localEulerAngles;
			float num10 = (localEulerAngles3.y = num9);
			Vector3 vector10 = (transform.localEulerAngles = localEulerAngles3);
		}
	}

	public void HIDE_CHR(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		HIDE_CHR_core(gameObject);
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			GameObject gameObject2 = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			if (RuntimeServices.EqualityOperator(obj, gameObject2.name))
			{
				HIDE_CHR_core(gameObject2);
			}
		}
	}

	public void HIDE_CHR_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject target = FindCutSceneObject((string)obj2);
		HIDE_CHR_core(target);
	}

	public void HIDE_CHR_core(GameObject target)
	{
		if (!target)
		{
			return;
		}
		Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>();
		Renderer[] array = componentsInChildren;
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			Renderer renderer = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			if (RuntimeServices.EqualityOperator(renderer.GetType(), typeof(ParticleRenderer)))
			{
				continue;
			}
			Hash obj = new Hash
			{
				{ "cmd", "renderer.enabled" },
				{ "obj", renderer },
				{ "val", renderer.enabled }
			};
			orgDataStack.Push(obj);
			renderer.enabled = false;
			if (RuntimeServices.EqualityOperator(renderer.GetType(), typeof(SkinnedMeshRenderer)))
			{
				SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)renderer;
				obj = new Hash
				{
					{ "cmd", "renderer.updateWhenOffscreen" },
					{ "obj", renderer },
					{ "val", skinnedMeshRenderer.updateWhenOffscreen }
				};
				orgDataStack.Push(obj);
				if ((bool)skinnedMeshRenderer)
				{
					skinnedMeshRenderer.updateWhenOffscreen = true;
				}
			}
		}
	}

	public void SHOW_CHR(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			SHOW_CHR_core(gameObject);
		}
	}

	public void SHOW_CHR_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject target = FindCutSceneObject((string)obj2);
		SHOW_CHR_core(target);
	}

	public void SHOW_CHR_core(GameObject target)
	{
		if (!target)
		{
			return;
		}
		Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>(includeInactive: true);
		AnimationEventHandler component = target.GetComponent<AnimationEventHandler>();
		Animation componentInChildren = target.GetComponentInChildren<Animation>();
		if (componentInChildren != null)
		{
			componentInChildren.cullingType = AnimationCullingType.AlwaysAnimate;
		}
		Renderer[] array = componentsInChildren;
		int length = array.Length;
		int num = 0;
		while (num < length)
		{
			Renderer renderer = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
			bool flag = renderer.gameObject.active;
			if (renderer.gameObject.layer == BasicCamera.HiddenLayer && (bool)component)
			{
				component.RestoreFromHidden = true;
				flag = true;
			}
			if (!flag || RuntimeServices.EqualityOperator(renderer.GetType(), typeof(ParticleRenderer)))
			{
				continue;
			}
			Hash obj = new Hash
			{
				{ "cmd", "renderer.enabled" },
				{ "obj", renderer },
				{ "val", renderer.enabled }
			};
			orgDataStack.Push(obj);
			renderer.enabled = true;
			if (RuntimeServices.EqualityOperator(renderer.GetType(), typeof(SkinnedMeshRenderer)))
			{
				SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)renderer;
				obj = new Hash
				{
					{ "cmd", "renderer.updateWhenOffscreen" },
					{ "obj", renderer },
					{ "val", skinnedMeshRenderer.updateWhenOffscreen }
				};
				orgDataStack.Push(obj);
				if ((bool)skinnedMeshRenderer)
				{
					skinnedMeshRenderer.updateWhenOffscreen = true;
				}
			}
		}
	}

	public void COPY_CHR(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			arg["arg1"] = gameObject;
			COPY_CHR_core(arg);
		}
	}

	public void COPY_CHR_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg1"] = value;
		COPY_CHR_core(arg);
	}

	public void COPY_CHR_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string text = (string)obj2;
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		int num = int.Parse((string)obj3);
		GameObject gameObject2 = null;
		if ((bool)gameObject)
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
		}
		if ((bool)gameObject2)
		{
			Hashtable hashtable = new Hashtable();
			hashtable = new Hash
			{
				{ "cmd", "target.instantiate" },
				{ "obj", gameObject2 }
			};
			orgDataStack.Push(hashtable);
			gameObject2.name = text;
			gameObject2.SetActive(value: true);
			if (num != 0)
			{
				SHOW_CHR_core(gameObject2);
			}
			else
			{
				HIDE_CHR_core(gameObject2);
			}
		}
	}

	public void SHOW_SIGNBOSS(Hashtable arg)
	{
		GameObject item = GameAssetModule.InstantiatePrefab("Prefab/GUI/SignBoss");
		loadObjectList.Add(item);
	}

	public void SHOW_SIGNMITUKAISYUTUGEN(Hashtable arg)
	{
		GameObject item = GameAssetModule.InstantiatePrefab("Prefab/GUI/SignMitukaiSyutugen");
		loadObjectList.Add(item);
	}

	public void PLAYER_CHR_INIT(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			arg["arg1"] = gameObject;
			IEnumerator enumerator = PLAYER_CHR_INIT_core(arg);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void PLAYER_CHR_INIT_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg1"] = value;
		IEnumerator enumerator = PLAYER_CHR_INIT_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator PLAYER_CHR_INIT_core(Hashtable arg)
	{
		return new _0024PLAYER_CHR_INIT_core_002417797(arg, this).GetEnumerator();
	}

	public void SUMMON_POPPET(Hashtable arg)
	{
		if (IsWaitPoppetPop)
		{
			throw new AssertionFailedException(new StringBuilder("魔ペット多重召還しようとしている？ ").Append(CutSceneName).ToString());
		}
		IsWaitPoppetPop = true;
		IEnumerator enumerator = SUMMON_POPPET_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator SUMMON_POPPET_core(Hashtable arg)
	{
		return new _0024SUMMON_POPPET_core_002417814(this).GetEnumerator();
	}

	public void storeObjTransform(GameObject target)
	{
		Hashtable hashtable = new Hashtable();
		hashtable = new Hash
		{
			{ "cmd", "transform.parent" },
			{ "obj", target.transform },
			{
				"val",
				target.transform.parent
			}
		};
		orgDataStack.Push(hashtable);
		Hashtable hashtable2 = new Hashtable();
		hashtable2 = new Hash
		{
			{ "cmd", "target.name" },
			{ "obj", target },
			{ "val", target.name }
		};
		orgDataStack.Push(hashtable2);
		Hashtable hashtable3 = new Hashtable();
		hashtable3 = new Hash
		{
			{ "cmd", "target.active" },
			{ "obj", target },
			{ "val", target.active }
		};
		orgDataStack.Push(hashtable3);
		Hashtable hashtable4 = new Hashtable();
		hashtable4 = new Hash
		{
			{ "cmd", "target.transform.localPosition" },
			{ "obj", target },
			{
				"val",
				target.transform.localPosition
			}
		};
		orgDataStack.Push(hashtable4);
		Hashtable hashtable5 = new Hashtable();
		hashtable5 = new Hash
		{
			{ "cmd", "target.transform.localRotation" },
			{ "obj", target },
			{
				"val",
				target.transform.localRotation
			}
		};
		orgDataStack.Push(hashtable5);
		Hashtable hashtable6 = new Hashtable();
		if (isValidScale(target.transform.localScale))
		{
			hashtable6 = new Hash
			{
				{ "cmd", "target.transform.localScale" },
				{ "obj", target },
				{
					"val",
					target.transform.localScale
				}
			};
			orgDataStack.Push(hashtable6);
		}
	}

	public void PLAYER_CHR_CHANGE(Hashtable arg)
	{
		object obj = arg["arg1"];
		PLAYER_CHR_CHANGE_core(arg);
	}

	public void PLAYER_CHR_CHANGE_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg1"] = value;
		PLAYER_CHR_CHANGE_core(arg);
	}

	public void PLAYER_CHR_CHANGE_core(Hashtable arg)
	{
		GameObject gameObject = playerChar[0];
		PlayerControl componentInChildren = gameObject.GetComponentInChildren<PlayerControl>();
		IEnumerator enumerator = componentInChildren.ChangeTensiAkuma();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		IEnumerator enumerator2 = WAIT_PLAYER_INIT();
		if (enumerator2 != null)
		{
			StartCoroutine(enumerator2);
		}
	}

	public void CHANGE_ANGEL(Hashtable arg)
	{
		GameObject gameObject = playerChar[0];
		PlayerControl componentInChildren = gameObject.GetComponentInChildren<PlayerControl>();
		if (componentInChildren.IsAkuma)
		{
			IEnumerator enumerator = componentInChildren.ChangeToTensi();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			IEnumerator enumerator2 = WAIT_PLAYER_INIT();
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
	}

	public void CHANGE_DEMON(Hashtable arg)
	{
		GameObject gameObject = playerChar[0];
		PlayerControl componentInChildren = gameObject.GetComponentInChildren<PlayerControl>();
		if (componentInChildren.IsTensi)
		{
			IEnumerator enumerator = componentInChildren.ChangeToAkuma();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			IEnumerator enumerator2 = WAIT_PLAYER_INIT();
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
	}

	public void CHANGE_ANGEL_SILENT(Hashtable arg)
	{
		GameObject gameObject = playerChar[0];
		PlayerControl componentInChildren = gameObject.GetComponentInChildren<PlayerControl>();
		if (componentInChildren.IsAkuma)
		{
			IEnumerator enumerator = componentInChildren.ChangeToTensi(withSe: false, withEffect: false);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			IEnumerator enumerator2 = WAIT_PLAYER_INIT();
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
	}

	public void CHANGE_DEMON_SILENT(Hashtable arg)
	{
		GameObject gameObject = playerChar[0];
		PlayerControl componentInChildren = gameObject.GetComponentInChildren<PlayerControl>();
		if (componentInChildren.IsTensi)
		{
			IEnumerator enumerator = componentInChildren.ChangeToAkuma(withSe: false, withEffect: false);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
			IEnumerator enumerator2 = WAIT_PLAYER_INIT();
			if (enumerator2 != null)
			{
				StartCoroutine(enumerator2);
			}
		}
	}

	public void cameraInit()
	{
		if (!(cam != null))
		{
			throw new AssertionFailedException("カットシーン開始時\u3000カメラが存在しない");
		}
		if (cam is CameraControl)
		{
			CameraControl cameraControl = cam as CameraControl;
			cameraControl.FieldCameraActive = true;
			cameraControl.fieldCameraUpdate(withInterpol: true);
		}
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.currentFocusMode" },
			{ "obj", cam },
			{ "val", cam.currentFocusMode }
		});
		cam.ForceResetCameraMode();
	}

	public IEnumerator BETWEEN_CAMERA(Hashtable arg)
	{
		return new _0024BETWEEN_CAMERA_002417821(arg, this).GetEnumerator();
	}

	public IEnumerator BETWEEN_CAMERA_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024BETWEEN_CAMERA_FOR_CUTSCENE_OBJID_002417829(arg, this).GetEnumerator();
	}

	public IEnumerator BETWEEN_CAMERA_EX(Hashtable arg)
	{
		return new _0024BETWEEN_CAMERA_EX_002417837(arg, this).GetEnumerator();
	}

	public IEnumerator BETWEEN_CAMERA_EX_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024BETWEEN_CAMERA_EX_FOR_CUTSCENE_OBJID_002417847(arg, this).GetEnumerator();
	}

	public IEnumerator BETWEEN_CAMERA_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is GameObject))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
		}
		GameObject gameObject2 = (GameObject)obj2;
		float num = default(float);
		num = ((!arg.ContainsKey("arg3")) ? 0.7f : RuntimeServices.UnboxSingle(arg["arg3"]));
		if ((bool)gameObject && (bool)gameObject2)
		{
			Transform parent = gameObject.transform;
			while ((bool)parent.parent)
			{
				parent = parent.parent;
			}
			Transform parent2 = gameObject2.transform;
			while ((bool)parent2.parent)
			{
				parent2 = parent2.parent;
			}
			if ((bool)cam)
			{
				Vector3 pos = (parent.localPosition + parent2.localPosition) * 0.5f;
				cam.setLookAt(pos, num);
			}
		}
		return null;
	}

	public IEnumerator CAMERA_LOOKAT(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		float x = float.Parse((string)obj);
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float y = float.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		float z = float.Parse((string)obj3);
		float num;
		if (arg.ContainsKey("arg4"))
		{
			object obj4 = arg["arg4"];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			if (!string.IsNullOrEmpty((string)obj4))
			{
				object obj5 = arg["arg4"];
				if (!(obj5 is string))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(string));
				}
				num = float.Parse((string)obj5) / 1000f;
				goto IL_011b;
			}
		}
		num = 0.7f;
		goto IL_011b;
		IL_011b:
		if ((bool)cam)
		{
			Hashtable hashtable = new Hashtable();
			hashtable = new Hash
			{
				{ "cmd", "cam.target" },
				{ "obj", cam.target }
			};
			hashtable = new Hash
			{
				{ "cmd", "cam.currentFocusMode" },
				{ "obj", cam },
				{ "val", cam.currentFocusMode }
			};
			orgCamStack.Push(hashtable);
			if (!(num > 0f))
			{
				cam.setLookAtWithoutInterpol(new Vector3(x, y, z));
			}
			else
			{
				cam.setLookAt(new Vector3(x, y, z), num);
			}
		}
		return null;
	}

	public void CAMERA_CONTROL_RESET()
	{
		if (cam is CameraControl)
		{
			CameraControl cameraControl = cam as CameraControl;
			if (cameraControl.IsfieldCameraUpdate)
			{
				cameraControl.fieldCameraUpdate();
			}
			else if (cameraControl.IsbattleCameraUpdate)
			{
				cameraControl.battleCameraUpdate();
			}
		}
	}

	public IEnumerator CAMERA_MOTION(Hashtable arg)
	{
		return new _0024CAMERA_MOTION_002417857(arg, this).GetEnumerator();
	}

	public IEnumerator RESET_CAMERA(Hashtable arg)
	{
		return new _0024RESET_CAMERA_002417892(arg, this).GetEnumerator();
	}

	public IEnumerator RESET_CAMERA_core(float duration)
	{
		return new _0024RESET_CAMERA_core_002417899(duration, this).GetEnumerator();
	}

	public void SET_TALK_PARTNER(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			cutSceneTalkPartnerChar = gameObject;
		}
	}

	public void SET_TALK_PARTNER_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = FindCutSceneObject((string)obj2);
		cutSceneTalkPartnerChar = gameObject;
	}

	public void SHOW_MODAL_MESSAGE(Hashtable arg)
	{
		object obj = arg["arg3"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int index = int.Parse((string)obj);
		bool[] array = buttonWait;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
		SHOW_MESSAGE_core(arg);
	}

	public void SHOW_MESSAGE(Hashtable arg)
	{
		object obj = arg["arg3"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int index = int.Parse((string)obj);
		bool[] array = buttonWait;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
		SHOW_MESSAGE_core(arg);
	}

	public void SHOW_MESSAGE_NO_WAIT(Hashtable arg)
	{
		object obj = arg["arg3"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int index = int.Parse((string)obj);
		bool[] array = buttonWait;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = false;
		SHOW_MESSAGE_core(arg);
	}

	public void SHOW_MESSAGE_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string titleId = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string messageId = (string)obj2;
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		int wndPrefabIndex = int.Parse((string)obj3);
		float shake = 0f;
		if (arg.ContainsKey("arg4"))
		{
			object obj4 = arg["arg4"];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			if (!string.IsNullOrEmpty((string)obj4))
			{
				object obj5 = arg["arg4"];
				if (!(obj5 is string))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(string));
				}
				float.TryParse((string)obj5, out shake);
			}
		}
		string text = string.Empty;
		string text2 = string.Empty;
		lastMsgWndType = wndPrefabIndex;
		if (cutSceneString != null)
		{
			string[] array = StringApplyLangageAndGender(titleId, messageId);
			text = array[0];
			text2 = array[1];
		}
		string[] multiLineArray = TextTagCheck.GetMultiLineArray(text2);
		string[] array2 = new string[1];
		GameObject[][] array3 = new GameObject[1][];
		array2[0] = text;
		array3[0] = curCutSceneBustShotArray;
		EventWindow.Window window = EventWindow.OpenEventWindow(multiLineArray, array2, array3, wndPrefabIndex);
		if (window != null)
		{
			window.DisableNextButton = true;
			window.HideLastPageNextButton = false;
			window.TextFinishAutoClose = false;
			if ((bool)window.curCh1Obj)
			{
				AnimPlay(window.curCh1Obj, curCutSceneBustShotMotionArray[0], forceLoop: true);
			}
			if ((bool)window.curCh2Obj)
			{
				AnimPlay(window.curCh2Obj, curCutSceneBustShotMotionArray[1], forceLoop: true);
			}
			window.Shake = shake;
		}
	}

	public void HIDE_MESSAGE(Hashtable arg)
	{
		EventWindow instance = EventWindow.Instance;
		if ((bool)instance)
		{
			instance.CloseAll();
		}
	}

	public void SHAKE_MESSAGE(Hashtable arg)
	{
		object obj = arg["arg3"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int index = int.Parse((string)obj);
		bool[] array = buttonWait;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
		SHOW_MESSAGE_core(arg);
	}

	public void SHOW_BUSTSHOT(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			arg["arg1"] = gameObject;
			SHOW_BUSTSHOT_core(arg);
		}
	}

	public void SHOW_BUSTSHOT_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg1"] = value;
		SHOW_BUSTSHOT_core(arg);
	}

	public void SHOW_BUSTSHOT_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		int index = int.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		int num = int.Parse((string)obj3);
		GameObject[] array = curCutSceneBustShotArray;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = gameObject;
		EventWindow.Window window = EventWindow.GetWindow(num);
		if (window != null)
		{
			window.SetChar1(curCutSceneBustShotArray[0]);
			window.SetChar2(curCutSceneBustShotArray[1]);
		}
		else
		{
			string[] array2 = new string[1];
			string[] array3 = new string[1];
			GameObject[][] array4 = new GameObject[1][];
			array2[0] = string.Empty;
			array3[0] = string.Empty;
			array4[0] = curCutSceneBustShotArray;
			window = EventWindow.OpenEventWindow(array3, array2, array4, num);
		}
		if (window != null)
		{
			window.DisableNextButton = true;
			window.HideLastPageNextButton = false;
			window.TextFinishAutoClose = false;
			if ((bool)window.curCh1Obj)
			{
				AnimPlay(window.curCh1Obj, curCutSceneBustShotMotionArray[0], forceLoop: true);
			}
			if ((bool)window.curCh2Obj)
			{
				AnimPlay(window.curCh2Obj, curCutSceneBustShotMotionArray[1], forceLoop: true);
			}
		}
	}

	public void HIDE_BUSTSHOT(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		int type = int.Parse((string)obj2);
		EventWindow.Window window = EventWindow.GetWindow(type);
		if ((bool)curCutSceneBustShotArray[0] && (text == string.Empty || curCutSceneBustShotArray[0].name == text || curCutSceneBustShotArray[0].name == text + "(Clone)"))
		{
			window?.SetChar1(null);
			curCutSceneBustShotArray[0] = null;
			curCutSceneBustShotMotionArray[0] = string.Empty;
		}
		if ((bool)curCutSceneBustShotArray[1] && (text == string.Empty || curCutSceneBustShotArray[1].name == text || curCutSceneBustShotArray[1].name == text + "(Clone)"))
		{
			window?.SetChar2(null);
			curCutSceneBustShotArray[1] = null;
			curCutSceneBustShotMotionArray[1] = string.Empty;
		}
	}

	public void HIDE_BUSTSHOT_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		int type = int.Parse((string)obj2);
		EventWindow.Window window = EventWindow.GetWindow(type);
		if ((bool)curCutSceneBustShotArray[0])
		{
			CutSceneObject component = curCutSceneBustShotArray[0].GetComponent<CutSceneObject>();
			if ((RuntimeServices.EqualityOperator(obj, string.Empty) || (bool)component) && (RuntimeServices.EqualityOperator(obj, string.Empty) || RuntimeServices.EqualityOperator(component.Id, obj)))
			{
				window?.SetChar1(null);
				curCutSceneBustShotArray[0] = null;
				curCutSceneBustShotMotionArray[0] = string.Empty;
			}
		}
		if ((bool)curCutSceneBustShotArray[1])
		{
			CutSceneObject component = curCutSceneBustShotArray[1].GetComponent<CutSceneObject>();
			if ((RuntimeServices.EqualityOperator(obj, string.Empty) || (bool)component) && (RuntimeServices.EqualityOperator(obj, string.Empty) || RuntimeServices.EqualityOperator(component.Id, obj)))
			{
				window?.SetChar2(null);
				curCutSceneBustShotArray[1] = null;
				curCutSceneBustShotMotionArray[1] = string.Empty;
			}
		}
	}

	public void PLAY_BUSTMOTION(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = arg["arg2"];
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		int type = int.Parse((string)obj3);
		EventWindow.Window window = EventWindow.GetWindow(type);
		object obj4 = null;
		object obj5 = null;
		if ((bool)curCutSceneBustShotArray[0])
		{
			if (RuntimeServices.EqualityOperator(curCutSceneBustShotArray[0].name, obj) || curCutSceneBustShotArray[0].name == obj + "(Clone)")
			{
				if (window != null)
				{
					obj4 = window.curCh1Obj;
				}
				string[] array = curCutSceneBustShotMotionArray;
				object obj6 = obj2;
				if (!(obj6 is string))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(string));
				}
				array[0] = (string)obj6;
			}
			else
			{
				Transform transform = ObjUtilModule.Find1stDescendant(curCutSceneBustShotArray[0].transform, "y_ang");
				if ((bool)transform && (bool)transform.parent && (RuntimeServices.EqualityOperator(transform.parent.name, obj) || transform.parent.name == obj + "(Clone)"))
				{
					if (window != null)
					{
						obj4 = window.curCh1Obj;
					}
					string[] array2 = curCutSceneBustShotMotionArray;
					object obj7 = obj2;
					if (!(obj7 is string))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(string));
					}
					array2[0] = (string)obj7;
				}
			}
		}
		if ((bool)curCutSceneBustShotArray[1])
		{
			if (RuntimeServices.EqualityOperator(curCutSceneBustShotArray[1].name, obj) || curCutSceneBustShotArray[1].name == obj + "(Clone)")
			{
				if (window != null)
				{
					obj5 = window.curCh2Obj;
				}
				string[] array3 = curCutSceneBustShotMotionArray;
				object obj8 = obj2;
				if (!(obj8 is string))
				{
					obj8 = RuntimeServices.Coerce(obj8, typeof(string));
				}
				array3[1] = (string)obj8;
			}
			else
			{
				Transform transform = ObjUtilModule.Find1stDescendant(curCutSceneBustShotArray[1].transform, "y_ang");
				if ((bool)transform && (bool)transform.parent && (RuntimeServices.EqualityOperator(transform.parent.name, obj) || transform.parent.name == obj + "(Clone)"))
				{
					if (window != null)
					{
						obj5 = window.curCh2Obj;
					}
					string[] array4 = curCutSceneBustShotMotionArray;
					object obj9 = obj2;
					if (!(obj9 is string))
					{
						obj9 = RuntimeServices.Coerce(obj9, typeof(string));
					}
					array4[1] = (string)obj9;
				}
			}
		}
		if (RuntimeServices.ToBool(obj4))
		{
			object obj10 = obj4;
			if (!(obj10 is GameObject))
			{
				obj10 = RuntimeServices.Coerce(obj10, typeof(GameObject));
			}
			GameObject obj11 = (GameObject)obj10;
			object obj12 = obj2;
			if (!(obj12 is string))
			{
				obj12 = RuntimeServices.Coerce(obj12, typeof(string));
			}
			AnimPlay(obj11, (string)obj12, forceLoop: true);
		}
		if (RuntimeServices.ToBool(obj5))
		{
			object obj13 = obj5;
			if (!(obj13 is GameObject))
			{
				obj13 = RuntimeServices.Coerce(obj13, typeof(GameObject));
			}
			GameObject obj14 = (GameObject)obj13;
			object obj15 = obj2;
			if (!(obj15 is string))
			{
				obj15 = RuntimeServices.Coerce(obj15, typeof(string));
			}
			AnimPlay(obj14, (string)obj15, forceLoop: true);
		}
	}

	public void PLAY_BUSTMOTION_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object rhs = arg["arg1"];
		object obj = arg["arg2"];
		object obj2 = arg["arg3"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		int type = int.Parse((string)obj2);
		EventWindow.Window window = EventWindow.GetWindow(type);
		object obj3 = null;
		object obj4 = null;
		if ((bool)curCutSceneBustShotArray[0])
		{
			CutSceneObject component = curCutSceneBustShotArray[0].GetComponent<CutSceneObject>();
			if ((bool)component && RuntimeServices.EqualityOperator(component.Id, rhs))
			{
				if (window != null)
				{
					obj3 = window.curCh1Obj;
				}
				string[] array = curCutSceneBustShotMotionArray;
				object obj5 = obj;
				if (!(obj5 is string))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(string));
				}
				array[0] = (string)obj5;
			}
		}
		if ((bool)curCutSceneBustShotArray[1])
		{
			CutSceneObject component = curCutSceneBustShotArray[1].GetComponent<CutSceneObject>();
			if ((bool)component && RuntimeServices.EqualityOperator(component.Id, rhs))
			{
				if (window != null)
				{
					obj4 = window.curCh2Obj;
				}
				string[] array2 = curCutSceneBustShotMotionArray;
				object obj6 = obj;
				if (!(obj6 is string))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(string));
				}
				array2[1] = (string)obj6;
			}
		}
		if (RuntimeServices.ToBool(obj3))
		{
			object obj7 = obj3;
			if (!(obj7 is GameObject))
			{
				obj7 = RuntimeServices.Coerce(obj7, typeof(GameObject));
			}
			GameObject obj8 = (GameObject)obj7;
			object obj9 = obj;
			if (!(obj9 is string))
			{
				obj9 = RuntimeServices.Coerce(obj9, typeof(string));
			}
			AnimPlay(obj8, (string)obj9, forceLoop: true);
		}
		if (RuntimeServices.ToBool(obj4))
		{
			object obj10 = obj4;
			if (!(obj10 is GameObject))
			{
				obj10 = RuntimeServices.Coerce(obj10, typeof(GameObject));
			}
			GameObject obj11 = (GameObject)obj10;
			object obj12 = obj;
			if (!(obj12 is string))
			{
				obj12 = RuntimeServices.Coerce(obj12, typeof(string));
			}
			AnimPlay(obj11, (string)obj12, forceLoop: true);
		}
	}

	public void PLAY_SE(Hashtable arg)
	{
		if (!IsJumping && !IsSkipping)
		{
			object obj = arg["arg1"];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			object obj2 = arg["arg2"];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			float vol = float.Parse((string)obj2);
			object obj3 = arg["arg3"];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			float pan = float.Parse((string)obj3);
			if (!sndmgr)
			{
				throw new AssertionFailedException("サウンドマネージャ不在");
			}
			int num = sndmgr.PlaySeEx(text, 0, -1, 0);
			if (num != 0)
			{
				registerSETable(text, num);
				sndmgr.SetSeVoulme(num, vol);
				sndmgr.SetSePan(num, pan);
			}
		}
	}

	public void PLAY_LOOP_SE(Hashtable arg)
	{
		if (!IsJumping && !IsSkipping)
		{
			object obj = arg["arg1"];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string value = (string)obj;
			object obj2 = arg["arg2"];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			float vol = float.Parse((string)obj2);
			object obj3 = arg["arg3"];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			float pan = float.Parse((string)obj3);
			if (!sndmgr)
			{
				throw new AssertionFailedException("サウンドマネージャ不在");
			}
			int num = sndmgr.PlaySeEx(value, 0, -1, 0);
			if (num == 0)
			{
				throw new AssertionFailedException(new StringBuilder("SE 再生失敗 ").Append(value).ToString());
			}
			registerSETable(value, num);
			sndmgr.SetSeVoulme(num, vol);
			sndmgr.SetSePan(num, pan);
		}
	}

	public void STOP_SE(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		if (!sndmgr)
		{
			throw new AssertionFailedException("サウンドマネージャ不在");
		}
		if (IsJumping || IsSkipping)
		{
			STOP_ALL_SE();
			return;
		}
		if (string.IsNullOrEmpty(text))
		{
			STOP_ALL_SE();
			return;
		}
		if (!seTable.ContainsKey(text))
		{
			throw new AssertionFailedException(new StringBuilder().Append(text).Append(" SE テーブルにないものを消そうとしている").ToString());
		}
		int soundID = RuntimeServices.UnboxInt32(seTable[text]);
		sndmgr.StopSeById(soundID, 2000);
		unregisterSETable(text);
	}

	public void STOP_ALL_SE()
	{
		STOP_ALL_SE(null);
	}

	public void STOP_ALL_SE(Hashtable arg)
	{
		if (!quitApp && !sndmgr)
		{
			throw new AssertionFailedException("サウンドマネージャ不在");
		}
		if (seTable != null)
		{
			IDictionaryEnumerator enumerator = seTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				sndmgr.StopSeById(RuntimeServices.UnboxInt32(dictionaryEntry.Value), 2000);
			}
			seTable = null;
		}
	}

	public void PLAY_BGM(Hashtable arg)
	{
		PLAY_BGM_core(arg, -1);
	}

	public void PLAY_BGM_ONCE(Hashtable arg)
	{
		PLAY_BGM_core(arg, 0);
	}

	public void PLAY_BGM_core(Hashtable arg, int loop)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float num = float.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		float pan = float.Parse((string)obj3);
		if (!sndmgr)
		{
			throw new AssertionFailedException("サウンドマネージャ不在");
		}
		if (sndmgr.IsPlayBgm())
		{
			Hashtable obj4 = new Hash
			{
				{ "cmd", "sound.bgm" },
				{ "name", sndmgr.lastBgm },
				{ "loop", sndmgr.lastBgmLoop },
				{ "vol", sndmgr.lastBgmVol },
				{ "pan", sndmgr.lastBgmPan }
			};
			orgDataStack.Push(obj4);
			if (!sndmgr.IsLastBgm(text))
			{
				GameSoundManager.PlayBgmDirect(text, 1f, pan, 2000, loop);
			}
		}
		else
		{
			GameSoundManager.PlayBgmDirect(text, 1f, pan, 0, loop);
		}
	}

	public void STOP_BGM(Hashtable arg)
	{
		if ((bool)sndmgr)
		{
			sndmgr.StopBgm(2000);
		}
	}

	public void PLAY_EFFECT(Hashtable arg)
	{
		arg["arg8"] = null;
		IEnumerator enumerator = PLAY_EFFECT_Core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator PLAY_EFFECT_Core(Hashtable arg)
	{
		return new _0024PLAY_EFFECT_Core_002417912(arg, this).GetEnumerator();
	}

	public void EFFECT_PARENT(Hashtable arg)
	{
		object obj = arg["arg2"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = FindByName((string)obj2);
		if ((bool)gameObject)
		{
			arg["arg2"] = gameObject;
			EFFECT_PARENT_core(arg);
		}
	}

	public void EFFECT_PARENT_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		object obj = arg["arg2"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject value = FindCutSceneObject((string)obj2);
		arg["arg2"] = value;
		EFFECT_PARENT_core(arg);
	}

	public void EFFECT_PARENT_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string value = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is GameObject))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
		}
		GameObject value2 = (GameObject)obj2;
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		string value3 = (string)obj3;
		object obj4 = arg["arg4"];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		string value4 = (string)obj4;
		object obj5 = arg["arg5"];
		if (!(obj5 is string))
		{
			obj5 = RuntimeServices.Coerce(obj5, typeof(string));
		}
		string value5 = (string)obj5;
		object obj6 = arg["arg6"];
		if (!(obj6 is string))
		{
			obj6 = RuntimeServices.Coerce(obj6, typeof(string));
		}
		string value6 = (string)obj6;
		object obj7 = arg["arg7"];
		if (!(obj7 is string))
		{
			obj7 = RuntimeServices.Coerce(obj7, typeof(string));
		}
		string value7 = (string)obj7;
		object obj8 = arg["arg8"];
		if (!(obj8 is string))
		{
			obj8 = RuntimeServices.Coerce(obj8, typeof(string));
		}
		string value8 = (string)obj8;
		arg = new Hash
		{
			{ "arg1", value },
			{ "arg2", value3 },
			{ "arg3", value4 },
			{ "arg4", value5 },
			{ "arg5", value6 },
			{ "arg6", value7 },
			{ "arg7", value8 },
			{ "arg8", value2 }
		};
		IEnumerator enumerator = PLAY_EFFECT_Core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void STOP_EFFECT(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string lhs = (string)obj;
		GameObject gameObject = null;
		List list = loadObjectList;
		int num = ((ICollection)list).Count;
		int num2 = 0;
		while (num2 < num)
		{
			object obj2 = list[checked(num2++)];
			UnityEngine.Object @object = obj2 as UnityEngine.Object;
			if ((bool)@object && RuntimeServices.op_Member(lhs, @object.name) && @object.name.StartsWith("_played_effect_"))
			{
				gameObject = (GameObject)@object;
			}
		}
		if (!gameObject)
		{
			gameObject = GameObject.Find(lhs) as GameObject;
		}
		if (!gameObject)
		{
			gameObject = GameObject.Find(lhs + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			effectCheckTab.Remove(gameObject.GetInstanceID());
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}

	public IEnumerator ATTACH(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		GameObject gameObject = GameObject.Find(text) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(text + "(Clone)") as GameObject;
		}
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject2 = GameObject.Find((string)obj2) as GameObject;
		if (!(gameObject != null))
		{
			throw new AssertionFailedException(new StringBuilder("アタッチするオブジェクトが見つからないよ, ").Append(text).Append("  in: ").Append(cutSceneName)
				.ToString());
		}
		if (!(gameObject2 != null))
		{
			throw new AssertionFailedException(new StringBuilder("アタッチ先オブジェクトが見つからないよ, ").Append(arg["arg2"]).Append("  in: ").Append(cutSceneName)
				.ToString());
		}
		ATTACH_core(gameObject, gameObject2);
		return null;
	}

	public IEnumerator ATTACH_core(GameObject dst, GameObject src)
	{
		Hashtable hashtable = new Hashtable();
		hashtable = new Hash
		{
			{ "cmd", "transform.parent" },
			{ "obj", dst.transform },
			{
				"val",
				dst.transform.parent
			}
		};
		orgDataStack.Push(hashtable);
		dst.transform.parent = src.transform;
		dst.transform.localPosition = Vector3.zero;
		dst.transform.localEulerAngles = Vector3.zero;
		return null;
	}

	public void EXIT(Hashtable arg)
	{
		EXIT_Core();
	}

	public void EXIT_Core()
	{
		if (!jumpTo)
		{
			exec = false;
		}
	}

	public void WAIT(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		wait = int.Parse((string)obj);
	}

	public void WAIT_MSEC(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int num = int.Parse((string)obj);
		if (curTag == "init")
		{
			num = checked(num - initialFaderWaitMSec);
			initialFaderWaitMSec = 0;
			if (num < 0)
			{
				num = 0;
			}
		}
		waitMsec = num;
	}

	public void WAIT_OK_BUTTON(Hashtable arg)
	{
		int num = 0;
		int length = buttonWait.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			bool[] array = buttonWait;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
		}
		EventWindow instance = EventWindow.Instance;
	}

	public void WAIT_OK_BUTTON_WNDTYPE(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		int index = int.Parse((string)obj);
		bool[] array = buttonWait;
		array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
		EventWindow instance = EventWindow.Instance;
	}

	public void WAIT_MOTION_END()
	{
		isMotionWait = true;
	}

	public void WAIT_THEYARRIVE()
	{
		IsMoveWait = true;
	}

	public void WAIT_CAMERAEND()
	{
		isCameraWait = true;
	}

	public IEnumerator WAIT_PLAYER_INIT()
	{
		return new _0024WAIT_PLAYER_INIT_002417943(this).GetEnumerator();
	}

	public IEnumerator SKIP_TO_NEXT_TAG()
	{
		lastTag = curTag;
		IsTagWait = true;
		SetPlaybackMode(PlaybackMode.skip);
		return null;
	}

	public IEnumerator SKIP_TO_NEXT_MESSAGE()
	{
		IsWaitMessage = true;
		SetPlaybackMode(PlaybackMode.skip);
		return null;
	}

	public IEnumerator JUMP_TO_TAG(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		jumpTag = (string)obj;
		SetPlaybackMode(PlaybackMode.jump);
		return null;
	}

	public IEnumerator GOTO(Hashtable arg)
	{
		JUMP_TO_TAG(arg);
		return null;
	}

	public IEnumerator DEMON_GOTO(Hashtable arg)
	{
		if (UserData.Current.PlayerRace == RACE_TYPE.Akuma)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator ANGEL_GOTO(Hashtable arg)
	{
		if (UserData.Current.PlayerRace == RACE_TYPE.Tensi)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator ANGEL_FEMALE_GOTO(Hashtable arg)
	{
		if (UserData.Current.AngelGender == 1)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator ANGEL_MALE_GOTO(Hashtable arg)
	{
		if (UserData.Current.AngelGender == 2)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator DEMON_FEMALE_GOTO(Hashtable arg)
	{
		if (UserData.Current.DemonGender == 1)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator DEMON_MALE_GOTO(Hashtable arg)
	{
		if (UserData.Current.DemonGender == 2)
		{
			JUMP_TO_TAG(arg);
		}
		return null;
	}

	public IEnumerator GENDERS_GOTO(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string value = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string value2 = (string)obj2;
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		string value3 = (string)obj3;
		object obj4 = arg["arg4"];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		string value4 = (string)obj4;
		bool flag = UserData.Current.AngelGender == 2;
		bool flag2 = UserData.Current.DemonGender == 2;
		if (flag && flag2)
		{
			GOTO(new Hash { { "arg1", value } });
		}
		else if (flag && !flag2)
		{
			GOTO(new Hash { { "arg1", value2 } });
		}
		else if (!flag && flag2)
		{
			GOTO(new Hash { { "arg1", value3 } });
		}
		else if (!flag && !flag2)
		{
			GOTO(new Hash { { "arg1", value4 } });
		}
		return null;
	}

	public void breakJump()
	{
		jumpTag = string.Empty;
		SetPlaybackMode(PlaybackMode.normal);
	}

	public void JUMP_TO(Hashtable arg)
	{
		object obj = arg["arg1"];
		exec = false;
		jumpTo = true;
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		CutSceneManager cutSceneManager = CutScene((string)obj2, cutSceneTalkPartnerChar);
		if ((bool)cutSceneManager)
		{
			cutSceneManager.StartCutScene();
		}
	}

	public void SET_FLAG(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = arg["arg2"];
	}

	public void _push_fader_stack(FaderCore fader)
	{
		orgDataStack.Push(new Hash
		{
			{ "cmd", "fader.r" },
			{ "obj", fader },
			{ "val", fader.red }
		});
		orgDataStack.Push(new Hash
		{
			{ "cmd", "fader.g" },
			{ "obj", fader },
			{ "val", fader.green }
		});
		orgDataStack.Push(new Hash
		{
			{ "cmd", "fader.b" },
			{ "obj", fader },
			{ "val", fader.blue }
		});
	}

	public IEnumerator FADE_IN_core(Hashtable arg)
	{
		return new _0024FADE_IN_core_002417947(arg, this).GetEnumerator();
	}

	public IEnumerator FADE_OUT_core(Hashtable arg)
	{
		return new _0024FADE_OUT_core_002417958(arg, this).GetEnumerator();
	}

	public IEnumerator FADE_IN(Hashtable arg)
	{
		FaderCore instance = FaderCore.Instance;
		arg["arg1"] = new StringBuilder().Append(instance.red).ToString();
		arg["arg2"] = new StringBuilder().Append(instance.green).ToString();
		arg["arg3"] = new StringBuilder().Append(instance.blue).ToString();
		arg["arg4"] = "1000.0";
		IEnumerator enumerator = FADE_IN_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_OUT(Hashtable arg)
	{
		FaderCore instance = FaderCore.Instance;
		arg["arg1"] = new StringBuilder().Append(instance.red).ToString();
		arg["arg2"] = new StringBuilder().Append(instance.green).ToString();
		arg["arg3"] = new StringBuilder().Append(instance.blue).ToString();
		arg["arg4"] = "1000.0";
		IEnumerator enumerator = FADE_OUT_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_IN_EX(Hashtable arg)
	{
		arg["arg4"] = "1000.0";
		IEnumerator enumerator = FADE_IN_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_OUT_EX(Hashtable arg)
	{
		arg["arg4"] = "1000.0";
		IEnumerator enumerator = FADE_OUT_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_IN_OVERTIME(Hashtable arg)
	{
		arg["arg4"] = arg["arg1"];
		FaderCore instance = FaderCore.Instance;
		arg["arg1"] = new StringBuilder().Append(instance.red).ToString();
		arg["arg2"] = new StringBuilder().Append(instance.green).ToString();
		arg["arg3"] = new StringBuilder().Append(instance.blue).ToString();
		IEnumerator enumerator = FADE_IN_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_OUT_OVERTIME(Hashtable arg)
	{
		arg["arg4"] = arg["arg1"];
		FaderCore instance = FaderCore.Instance;
		arg["arg1"] = new StringBuilder().Append(instance.red).ToString();
		arg["arg2"] = new StringBuilder().Append(instance.green).ToString();
		arg["arg3"] = new StringBuilder().Append(instance.blue).ToString();
		IEnumerator enumerator = FADE_OUT_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_IN_EX_OVERTIME(Hashtable arg)
	{
		IEnumerator enumerator = FADE_IN_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator FADE_OUT_EX_OVERTIME(Hashtable arg)
	{
		IEnumerator enumerator = FADE_OUT_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator SET_OBJECT_POS(Hashtable arg)
	{
		return new _0024SET_OBJECT_POS_002417969(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_POS_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024SET_OBJECT_POS_FOR_CUTSCENE_OBJID_002417977(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_POS_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float num = float.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		float num2 = float.Parse((string)obj3);
		object obj4 = arg["arg4"];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		float num3 = float.Parse((string)obj4);
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		checked
		{
			if ((bool)gameObject)
			{
				num4 = (int)gameObject.transform.localPosition.x;
				num5 = (int)gameObject.transform.localPosition.y;
				num6 = (int)gameObject.transform.localPosition.z;
				Hashtable hashtable = new Hashtable();
				Hashtable hashtable2 = new Hashtable();
				Hashtable hashtable3 = new Hashtable();
				hashtable = new Hash
				{
					{ "cmd", "target.transform.localPosition.x" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localPosition.x
					}
				};
				hashtable2 = new Hash
				{
					{ "cmd", "target.transform.localPosition.y" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localPosition.y
					}
				};
				hashtable3 = new Hash
				{
					{ "cmd", "target.transform.localPosition.z" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localPosition.z
					}
				};
				orgDataStack.Push(hashtable);
				orgDataStack.Push(hashtable2);
				orgDataStack.Push(hashtable3);
				float x = num;
				Vector3 localPosition = gameObject.transform.localPosition;
				float num7 = (localPosition.x = x);
				Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
				float y = num2;
				Vector3 localPosition2 = gameObject.transform.localPosition;
				float num8 = (localPosition2.y = y);
				Vector3 vector4 = (gameObject.transform.localPosition = localPosition2);
				float z = num3;
				Vector3 localPosition3 = gameObject.transform.localPosition;
				float num9 = (localPosition3.z = z);
				Vector3 vector6 = (gameObject.transform.localPosition = localPosition3);
			}
			return null;
		}
	}

	public IEnumerator SET_POS_TO_OTHER_OBJ(Hashtable arg)
	{
		return new _0024SET_POS_TO_OTHER_OBJ_002417985(arg, this).GetEnumerator();
	}

	public IEnumerator SET_POS_TO_OTHER_OBJ_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024SET_POS_TO_OTHER_OBJ_FOR_CUTSCENE_OBJID_002417993(arg, this).GetEnumerator();
	}

	public IEnumerator SET_POS_TO_OTHER_OBJ_core(Hashtable arg)
	{
		return new _0024SET_POS_TO_OTHER_OBJ_core_002418000(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_SCL(Hashtable arg)
	{
		return new _0024SET_OBJECT_SCL_002418029(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_SCL_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024SET_OBJECT_SCL_FOR_CUTSCENE_OBJID_002418037(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_SCL_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float num = float.Parse((string)obj2);
		object obj3 = arg["arg3"];
		if (!(obj3 is string))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(string));
		}
		float num2 = float.Parse((string)obj3);
		object obj4 = arg["arg4"];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		float num3 = float.Parse((string)obj4);
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		checked
		{
			if ((bool)gameObject)
			{
				num4 = (int)gameObject.transform.localScale.x;
				num5 = (int)gameObject.transform.localScale.y;
				num6 = (int)gameObject.transform.localScale.z;
				Hashtable hashtable = new Hashtable();
				Hashtable hashtable2 = new Hashtable();
				Hashtable hashtable3 = new Hashtable();
				hashtable = new Hash
				{
					{ "cmd", "target.transform.localScale.x" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localScale.x
					}
				};
				hashtable2 = new Hash
				{
					{ "cmd", "target.transform.localScale.y" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localScale.y
					}
				};
				hashtable3 = new Hash
				{
					{ "cmd", "target.transform.localScale.z" },
					{ "obj", gameObject },
					{
						"val",
						gameObject.transform.localScale.z
					}
				};
				orgDataStack.Push(hashtable);
				orgDataStack.Push(hashtable2);
				orgDataStack.Push(hashtable3);
			}
			float x = num;
			Vector3 localScale = gameObject.transform.localScale;
			float num7 = (localScale.x = x);
			Vector3 vector2 = (gameObject.transform.localScale = localScale);
			float y = num2;
			Vector3 localScale2 = gameObject.transform.localScale;
			float num8 = (localScale2.y = y);
			Vector3 vector4 = (gameObject.transform.localScale = localScale2);
			float z = num3;
			Vector3 localScale3 = gameObject.transform.localScale;
			float num9 = (localScale3.z = z);
			Vector3 vector6 = (gameObject.transform.localScale = localScale3);
			return null;
		}
	}

	public IEnumerator SET_OBJECT_DIR(Hashtable arg)
	{
		return new _0024SET_OBJECT_DIR_002418045(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_DIR_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024SET_OBJECT_DIR_FOR_CUTSCENE_OBJID_002418053(arg, this).GetEnumerator();
	}

	public IEnumerator SET_OBJECT_DIR_core(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is GameObject))
		{
			obj = RuntimeServices.Coerce(obj, typeof(GameObject));
		}
		GameObject gameObject = (GameObject)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		float num = float.Parse((string)obj2);
		int num2 = 0;
		if ((bool)gameObject)
		{
			num2 = checked((int)gameObject.transform.localEulerAngles.y);
			Hashtable hashtable = new Hashtable();
			hashtable = new Hash
			{
				{ "cmd", "target.transform.localEulerAngles.y" },
				{ "obj", gameObject },
				{
					"val",
					gameObject.transform.localEulerAngles.y
				}
			};
			orgDataStack.Push(hashtable);
		}
		float y = num;
		Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
		float num3 = (localEulerAngles.y = y);
		Vector3 vector2 = (gameObject.transform.localEulerAngles = localEulerAngles);
		return null;
	}

	public void SET_OBJ_ACTIVE(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			gameObject.SetActive(RuntimeServices.EqualityOperator(arg["arg1"], 1));
		}
	}

	public IEnumerator DISABLE_CAMERA_CONTROL(Hashtable arg)
	{
		SET_CAMERA_CONTROL_core(flag: false);
		return null;
	}

	public IEnumerator ENABLE_CAMERA_CONTROL(Hashtable arg)
	{
		SET_CAMERA_CONTROL_core(flag: true);
		return null;
	}

	public IEnumerator SET_CAMERA_CONTROL_core(bool flag)
	{
		if ((bool)cam)
		{
			BasicCamera componentInChildren = cam.gameObject.GetComponentInChildren<BasicCamera>();
			if ((bool)componentInChildren)
			{
				pushCmdTargetEnabledAndSet(orgCamStack, componentInChildren, flag);
				bool flag2 = componentInChildren.enabled;
			}
			LinearCamera linearCamera = ((LinearCamera)UnityEngine.Object.FindObjectOfType(typeof(LinearCamera))) as LinearCamera;
			if ((bool)linearCamera && (bool)linearCamera)
			{
				pushCmdTargetEnabledAndSet(orgCamStack, linearCamera, flag);
				bool flag2 = linearCamera.enabled;
			}
		}
		return null;
	}

	public IEnumerator SET_CAMERA_MODE(BasicCamera.FocusMode mode)
	{
		if ((bool)cam)
		{
			BasicCamera componentInChildren = cam.gameObject.GetComponentInChildren<BasicCamera>();
			if ((bool)componentInChildren)
			{
				Hashtable hashtable = new Hashtable();
				hashtable = new Hash
				{
					{ "cmd", "cam.currentFocusMode" },
					{ "obj", componentInChildren },
					{ "val", cam.currentFocusMode }
				};
				orgCamStack.Push(hashtable);
			}
			componentInChildren.currentFocusMode = mode;
		}
		return null;
	}

	public void _store_camera_transform(BasicCamera cam)
	{
		Transform transform = cam.transform;
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localPosition.x" },
			{ "obj", cam },
			{
				"val",
				transform.localPosition.x
			}
		});
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localPosition.y" },
			{ "obj", cam },
			{
				"val",
				transform.localPosition.y
			}
		});
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localPosition.z" },
			{ "obj", cam },
			{
				"val",
				transform.localPosition.z
			}
		});
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localRotation.x" },
			{ "obj", cam },
			{
				"val",
				transform.localRotation.x
			}
		});
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localRotation.y" },
			{ "obj", cam },
			{
				"val",
				transform.localRotation.y
			}
		});
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.transform.localRotation.z" },
			{ "obj", cam },
			{
				"val",
				transform.localRotation.z
			}
		});
	}

	public IEnumerator MOVE_CAMERA_TO(Hashtable arg)
	{
		IEnumerator enumerator = MOVE_CAMERA_TO_core(arg);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		return null;
	}

	public IEnumerator MOVE_CAMERA_TO_core(Hashtable arg)
	{
		return new _0024MOVE_CAMERA_TO_core_002418061(arg, this).GetEnumerator();
	}

	public IEnumerator ZOOM_CAMERA_TO(Hashtable arg)
	{
		return new _0024ZOOM_CAMERA_TO_002418084(arg, this).GetEnumerator();
	}

	public IEnumerator ZOOM_CAMERA_TO_FOR_CUTSCENE_OBJID(Hashtable arg)
	{
		return new _0024ZOOM_CAMERA_TO_FOR_CUTSCENE_OBJID_002418092(arg, this).GetEnumerator();
	}

	public IEnumerator ZOOM_CAMERA_TO_core(Hashtable arg)
	{
		return new _0024ZOOM_CAMERA_TO_core_002418100(arg, this).GetEnumerator();
	}

	public IEnumerator CAMERA_FOV(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		float num = float.Parse((string)obj);
		if (!(cam != null))
		{
			throw new AssertionFailedException("cam != null");
		}
		GameObject gameObject = cam.gameObject;
		Camera componentInChildren = gameObject.GetComponentInChildren<Camera>();
		orgCamStack.Push(new Hash
		{
			{ "cmd", "cam.fieldOfView" },
			{ "obj", componentInChildren },
			{ "val", num }
		});
		componentInChildren.fieldOfView = num;
		return null;
	}

	public IEnumerator DEFAULT_CAMERA(Hashtable arg)
	{
		return new _0024DEFAULT_CAMERA_002418115(this).GetEnumerator();
	}

	public IEnumerator ACTIVATE_COLLISION(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			SET_COLLISION_core(gameObject, flag: true);
		}
		return null;
	}

	public IEnumerator DEACTIVATE_COLLISION(Hashtable arg)
	{
		object obj = arg["arg1"];
		object obj2 = obj;
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		GameObject gameObject = GameObject.Find((string)obj2) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(obj + "(Clone)") as GameObject;
		}
		if ((bool)gameObject)
		{
			SET_COLLISION_core(gameObject, flag: false);
		}
		return null;
	}

	private void SET_COLLISION_core(GameObject target, bool flag)
	{
		if (!target)
		{
			return;
		}
		CharacterController characterController = (CharacterController)target.GetComponent(typeof(CharacterController));
		if ((bool)characterController)
		{
			Hash hash = new Hash
			{
				{ "cmd", "target.enabled" },
				{ "obj", characterController },
				{ "val", characterController.enabled }
			};
			hash = new Hash
			{
				{ "cmd", "target.layer" },
				{ "obj", target },
				{ "val", target.layer }
			};
			orgDataStack.Push(hash);
			characterController.enabled = flag;
			if (characterController.slopeLimit == 0f)
			{
				throw new AssertionFailedException(new StringBuilder().Append(target.name).Append(" の CharacterController.slopeLimit がゼロで坂登れないよ").ToString());
			}
			characterController.slopeLimit = 90f;
			target.layer = LayerMask.NameToLayer("CHR_NOPUSHOUT");
		}
	}

	public IEnumerator HIDE_MESH(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string value = (string)obj2;
		GameObject g = FindByName(text);
		if (string.IsNullOrEmpty(value))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(meshName)");
		}
		setMeshVisibility(g, value, b: false);
		return null;
	}

	public IEnumerator SHOW_MESH(Hashtable arg)
	{
		object obj = arg["arg1"];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = (string)obj;
		object obj2 = arg["arg2"];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		string value = (string)obj2;
		GameObject g = FindByName(text);
		if (string.IsNullOrEmpty(value))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(meshName)");
		}
		setMeshVisibility(g, value, b: true);
		return null;
	}

	private void setMeshVisibility(GameObject g, string name, bool b)
	{
		int i = 0;
		SkinnedMeshRenderer[] componentsInChildren = g.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			if (componentsInChildren[i].gameObject.name.ToLower().EndsWith(name))
			{
				pushCmdTargetEnabledAndSet(orgDataStack, componentsInChildren[i], b);
			}
		}
	}

	private bool isAnimEnd(Animation anim, MerlinMotionPackControl mmpc)
	{
		int num;
		bool flag;
		if (!anim && !mmpc)
		{
			num = 1;
		}
		else if ((bool)mmpc)
		{
			num = (mmpc.IsEndOfMotion ? 1 : 0);
		}
		else
		{
			try
			{
				if ((bool)anim && (bool)anim.clip && (!anim.isPlaying || !((double)anim[anim.clip.name].normalizedTime < 1.0)))
				{
					flag = true;
					goto IL_009c;
				}
			}
			catch (Exception)
			{
				flag = false;
				goto IL_009c;
			}
			num = 0;
		}
		goto IL_009d;
		IL_009d:
		return (byte)num != 0;
		IL_009c:
		num = (flag ? 1 : 0);
		goto IL_009d;
	}

	private void enqueueMot(GameObject target, MotCommand cmd)
	{
		if (!animQueues.ContainsKey(target.GetInstanceID()))
		{
			animQueues[target.GetInstanceID()] = new Queue<MotCommand>();
		}
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		bool flag = false;
		MotCommand item = default(MotCommand);
		if (cmd.type == MotModeType.now)
		{
			while (queue.Count > 0)
			{
				MotCommand motCommand = queue.Dequeue();
				if (motCommand.fcount >= cmd.fcount)
				{
					item = motCommand;
					queue.Clear();
					flag = true;
					break;
				}
			}
		}
		queue.Enqueue(cmd);
		if (flag)
		{
			queue.Enqueue(item);
		}
	}

	private bool isFirstInMotQueue(GameObject target, int id)
	{
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		bool flag;
		foreach (MotCommand item in queue)
		{
			if (item.type != MotModeType.next)
			{
				continue;
			}
			flag = item.id == id;
			goto IL_0087;
		}
		int num = 0;
		goto IL_0088;
		IL_0088:
		return (byte)num != 0;
		IL_0087:
		num = (flag ? 1 : 0);
		goto IL_0088;
	}

	private bool isInMotQueue(GameObject target, int id)
	{
		int num;
		if (!target)
		{
			num = 0;
		}
		else
		{
			object obj = animQueues[target.GetInstanceID()];
			if (!(obj is Queue<MotCommand>))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
			}
			Queue<MotCommand> queue = (Queue<MotCommand>)obj;
			if (queue.Count <= 0)
			{
				throw new AssertionFailedException(new StringBuilder("モーションキューがから ").Append(target.name).ToString());
			}
			bool flag = false;
			foreach (MotCommand item in queue)
			{
				if (item.type == MotModeType.next && item.id == id)
				{
					flag = true;
				}
			}
			num = (flag ? 1 : 0);
		}
		return (byte)num != 0;
	}

	private void dequeueMotNow(GameObject target, int id)
	{
		if (!target)
		{
			return;
		}
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		if (queue.Count <= 0)
		{
			throw new AssertionFailedException(new StringBuilder("モーションキューがから ").Append(target.name).ToString());
		}
		if (queue != null && queue.Count != 0 && !isInMotQueue(target, id))
		{
			MotCommand motCommand = queue.Peek();
			if (motCommand.type == MotModeType.now && motCommand.id == id)
			{
				queue.Dequeue();
			}
		}
	}

	private void dequeueMotNext(GameObject target, int id)
	{
		if (!target)
		{
			return;
		}
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		if (queue.Count <= 0)
		{
			throw new AssertionFailedException(new StringBuilder("モーションキューがから ").Append(target.name).ToString());
		}
		if (!isInMotQueue(target, id))
		{
			return;
		}
		while (queue.Count > 0)
		{
			MotCommand motCommand = queue.Dequeue();
			if (motCommand.type == MotModeType.next && motCommand.id == id)
			{
				break;
			}
		}
	}

	private bool checkAnimIdentity(GameObject target, int animId, int nextId)
	{
		return isFirstInMotQueue(target, nextId);
	}

	private int registerAnimIdentity(GameObject target)
	{
		int num = animCheckId;
		animCheckTab[target.GetInstanceID()] = num;
		checked
		{
			animCheckId++;
			MotCommand motCommand = default(MotCommand);
			int num2 = (motCommand.id = num);
			MotModeType motModeType = (motCommand.type = MotModeType.now);
			int num3 = (motCommand.fcount = Time.frameCount);
			MotCommand cmd = motCommand;
			enqueueMot(target, cmd);
			return num;
		}
	}

	private bool checkAnimIdentity(GameObject target, int animId)
	{
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		int num;
		if (queue.Count == 0)
		{
			num = 0;
		}
		else
		{
			MotCommand motCommand = queue.Peek();
			num = ((motCommand.type == MotModeType.now && motCommand.id == animId) ? 1 : 0);
		}
		return (byte)num != 0;
	}

	private int getCurrentAnimIdentity(GameObject target)
	{
		object obj = animQueues[target.GetInstanceID()];
		if (!(obj is Queue<MotCommand>))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Queue<MotCommand>));
		}
		Queue<MotCommand> queue = (Queue<MotCommand>)obj;
		return (queue.Count != 0) ? queue.Peek().id : 0;
	}

	private int registerNextAnimIdentity(GameObject target)
	{
		int num = animCheckId;
		nextAnimCheckTab[target.GetInstanceID()] = num;
		checked
		{
			animCheckId++;
			MotCommand motCommand = default(MotCommand);
			int num2 = (motCommand.id = num);
			MotModeType motModeType = (motCommand.type = MotModeType.next);
			int num3 = (motCommand.fcount = Time.frameCount);
			MotCommand cmd = motCommand;
			enqueueMot(target, cmd);
			return num;
		}
	}

	private bool checkNextAnimIdentity(GameObject target, int animId)
	{
		return RuntimeServices.EqualityOperator(nextAnimCheckTab[target.GetInstanceID()], animId);
	}

	private void finishNextAnim(GameObject target, int id)
	{
		dequeueMotNext(target, id);
	}

	private void finishAnim(GameObject target, int id)
	{
		dequeueMotNow(target, id);
	}

	private bool isNextAnimEmpty(GameObject target)
	{
		int instanceID = target.GetInstanceID();
		return nextAnimCheckTab.Count == 0 || !nextAnimCheckTab.ContainsKey(instanceID) || nextAnimCheckTab[instanceID] == null;
	}

	private bool hasMMPC(GameObject target)
	{
		MerlinMotionPackControl merlinMotionPackControl = _getMMPC(target);
		return merlinMotionPackControl != null;
	}

	private bool isPlayingAnim(GameObject target, string motionName)
	{
		MerlinMotionPackControl merlinMotionPackControl = _getMMPC(target);
		Animation animation = _getAnim(target);
		int num;
		if (hasMMPC(target))
		{
			if (!merlinMotionPackControl.CurrentClip)
			{
				num = 0;
			}
			else
			{
				num = ((merlinMotionPackControl.CurrentClip.name == motionName) ? 1 : 0);
				if (num != 0)
				{
					num = ((!isAnimEnd(animation, merlinMotionPackControl)) ? 1 : 0);
				}
			}
		}
		else
		{
			if (!animation)
			{
				throw new AssertionFailedException("anim");
			}
			if (!animation.clip)
			{
				num = 0;
			}
			else
			{
				num = ((animation.clip.name == motionName) ? 1 : 0);
				if (num != 0)
				{
					num = (animation.IsPlaying(motionName) ? 1 : 0);
				}
			}
		}
		return (byte)num != 0;
	}

	private GameObject FindByName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(name)");
		}
		GameObject gameObject = GameObject.Find(name) as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find(name + "(Clone)") as GameObject;
		}
		return gameObject;
	}

	private int registerSETable(string name, int id)
	{
		_0024registerSETable_0024locals_002414395 _0024registerSETable_0024locals_0024 = new _0024registerSETable_0024locals_002414395();
		_0024registerSETable_0024locals_0024._0024id = id;
		if (seTable == null)
		{
			throw new AssertionFailedException("seTable が未初期化");
		}
		if (MotCommand._0024re_002424724.Match(name).Success)
		{
			throw new AssertionFailedException(new StringBuilder("seName ").Append(name).Append(" に不正な文字が使用されている '*' はダメ").ToString());
		}
		__Req_FailHandler_0024callable6_0024440_32__ _Req_FailHandler_0024callable6_0024440_32__ = new _0024registerSETable_0024_recur_00243814(_0024registerSETable_0024locals_0024, this).Invoke;
		_Req_FailHandler_0024callable6_0024440_32__(name);
		return 0;
	}

	private void unregisterSETable(string name)
	{
		if (seTable == null)
		{
			throw new AssertionFailedException("seTable が未初期化");
		}
		if (MotCommand._0024re_002424725.Match(name).Success)
		{
			throw new AssertionFailedException(new StringBuilder("seName ").Append(name).Append(" に不正な文字が使用されている '*' はダメ").ToString());
		}
		__Req_FailHandler_0024callable6_0024440_32__ _Req_FailHandler_0024callable6_0024440_32__ = delegate(string _name)
		{
			seTable.Remove(_name);
			if (seTable.ContainsKey(new StringBuilder().Append(_name).Append("*").ToString()))
			{
				seTable[_name] = seTable[new StringBuilder().Append(_name).Append("*").ToString()];
				_0024unregisterSETable_0024_recur_00243815(new StringBuilder().Append(_name).Append("*").ToString());
			}
		};
		_Req_FailHandler_0024callable6_0024440_32__(name);
	}

	public void standGround(GameObject target)
	{
		float num = RuntimeServices.UnboxSingle(ObjUtilModule.GetGroundHeight(target)[1]);
		float y = num;
		Vector3 position = target.transform.position;
		float num2 = (position.y = y);
		Vector3 vector2 = (target.transform.position = position);
		CharacterController characterController = (CharacterController)target.GetComponent(typeof(CharacterController));
		if (characterController != null)
		{
			bool flag = characterController.enabled;
			double num3 = (double)target.transform.position.y + (double)characterController.radius * 0.3;
			Vector3 position2 = target.transform.position;
			float num4 = (position2.y = (float)num3);
			Vector3 vector4 = (target.transform.position = position2);
			characterController.enabled = true;
			characterController.Move(new Vector3(0f, (float)(-100.0 * (double)Time.deltaTime), 0f));
			characterController.enabled = flag;
			if (!(target.transform.position.y >= num))
			{
				float y2 = num;
				Vector3 position3 = target.transform.position;
				float num5 = (position3.y = y2);
				Vector3 vector6 = (target.transform.position = position3);
			}
		}
	}

	public float standTerrain(GameObject target)
	{
		return target.transform.position.y;
	}

	public bool isValidScale(GameObject g)
	{
		return isValidScale(g.transform.localScale);
	}

	public bool isValidScale(Transform t)
	{
		return isValidScale(t.localScale);
	}

	public bool isValidScale(Vector3 v)
	{
		bool num = isValidScale(v.x);
		if (num)
		{
			num = isValidScale(v.y);
		}
		if (num)
		{
			num = isValidScale(v.z);
		}
		return num;
	}

	public bool isValidScale(float f)
	{
		return (double)f <= 180.0 && f != 0f && f != float.NaN && f != float.PositiveInfinity && f != float.NegativeInfinity;
	}

	public bool isFuncDontSkip(string funcname)
	{
		int num = 0;
		string[] array = dontSkipFunctions;
		int length = array.Length;
		int num2;
		while (true)
		{
			if (num < length)
			{
				if (RuntimeServices.op_Member(array[num], funcname))
				{
					num2 = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			num2 = 0;
			break;
		}
		return (byte)num2 != 0;
	}

	public bool isTagDontSkip(string tagname)
	{
		int num;
		if (string.IsNullOrEmpty(tagname))
		{
			num = 0;
		}
		else
		{
			int num2 = 0;
			string[] array = dontSkipTags;
			int length = array.Length;
			while (true)
			{
				if (num2 < length)
				{
					if (RuntimeServices.op_Member(array[num2], tagname))
					{
						num = 1;
						break;
					}
					num2 = checked(num2 + 1);
					continue;
				}
				num = 0;
				break;
			}
		}
		return (byte)num != 0;
	}

	public Animation _getAnim(GameObject go)
	{
		int instanceID = go.GetInstanceID();
		if (!_animCompCacheTable.ContainsKey(instanceID))
		{
			_animCompCacheTable[instanceID] = go.GetComponentInChildren<Animation>();
		}
		if (_animCompCacheTable[instanceID] == null)
		{
			throw new AssertionFailedException("_animCompCacheTable[id] != null");
		}
		object obj = _animCompCacheTable[instanceID];
		if (!(obj is Animation))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Animation));
		}
		return (Animation)obj;
	}

	public MerlinMotionPackControl _getMMPC(GameObject go)
	{
		int instanceID = go.GetInstanceID();
		if (!_mmpcCompCacheTable.ContainsKey(instanceID))
		{
			_mmpcCompCacheTable[instanceID] = go.GetComponentInChildren<MerlinMotionPackControl>();
		}
		object obj2;
		if (_mmpcCompCacheTable[instanceID] != null)
		{
			object obj = _mmpcCompCacheTable[instanceID];
			if (!(obj is MerlinMotionPackControl))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MerlinMotionPackControl));
			}
			obj2 = (MerlinMotionPackControl)obj;
		}
		else
		{
			obj2 = null;
		}
		return (MerlinMotionPackControl)obj2;
	}

	internal GameObject _0024PLAY_EFFECT_Core_0024_search_00243809(string n)
	{
		GameObject gameObject = FindLoadObject(n) as GameObject;
		int instanceID = default(int);
		if ((bool)gameObject)
		{
			instanceID = gameObject.GetInstanceID();
		}
		object obj;
		if ((bool)gameObject && !effectCheckTab.ContainsKey(instanceID))
		{
			obj = gameObject;
		}
		else
		{
			if (!gameObject)
			{
				gameObject = GameObject.Find(n) as GameObject;
			}
			if (!gameObject)
			{
				gameObject = GameObject.Find(n + "(Clone)") as GameObject;
			}
			obj = ((!gameObject) ? null : gameObject);
		}
		return (GameObject)obj;
	}

	internal bool _0024DEFAULT_CAMERA_0024camBreak_00243811()
	{
		bool num = !SceneChanger.isCompletelyReady;
		if (!num)
		{
			num = cam == null;
		}
		if (!num)
		{
			num = Camera.main == null;
		}
		if (!num)
		{
			num = cam.gameObject != Camera.main.gameObject;
		}
		return num;
	}

	internal void _0024unregisterSETable_0024_recur_00243815(string _name)
	{
		seTable.Remove(_name);
		if (seTable.ContainsKey(new StringBuilder().Append(_name).Append("*").ToString()))
		{
			seTable[_name] = seTable[new StringBuilder().Append(_name).Append("*").ToString()];
			_0024unregisterSETable_0024_recur_00243815(new StringBuilder().Append(_name).Append("*").ToString());
		}
	}
}
