using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class CutsceneViewer : MonoBehaviour
{
	[Serializable]
	private enum MENU_MODE
	{
		menu,
		select_scene,
		control_scene
	}

	[Serializable]
	internal class _0024main_0024locals_002414575
	{
		internal bool _0024ok;
	}

	[Serializable]
	internal class _0024listFilter_0024locals_002414576
	{
		internal Regex _0024r;

		internal List _0024l;
	}

	[Serializable]
	internal class _0024destroyBeforeChangeScene_0024locals_002414577
	{
		internal Transform[] _0024all;
	}

	[Serializable]
	internal class _0024main_0024closure_00246557
	{
		internal _0024main_0024locals_002414575 _0024_0024locals_002415270;

		public _0024main_0024closure_00246557(_0024main_0024locals_002414575 _0024_0024locals_002415270)
		{
			this._0024_0024locals_002415270 = _0024_0024locals_002415270;
		}

		public void Invoke()
		{
			_0024_0024locals_002415270._0024ok = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002424487 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal _0024main_0024locals_002414575 _0024_0024locals_002424488;

			internal CutsceneViewer _0024self__002424489;

			public _0024(CutsceneViewer self_)
			{
				_0024self__002424489 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002424488 = new _0024main_0024locals_002414575();
					_0024self__002424489.menu_mode = MENU_MODE.menu;
					_0024self__002424489.filterdScenes = _0024self__002424489.scenes;
					_0024self__002424489.StartCoroutine(_0024self__002424489._storeOriginalGameObjects());
					_0024_0024locals_002424488._0024ok = false;
					MerlinServer.EditorCommunicationInitialize(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024main_0024closure_00246557(_0024_0024locals_002424488).Invoke));
					goto case 2;
				case 2:
					if (!_0024_0024locals_002424488._0024ok)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002424489.menu_mode = MENU_MODE.select_scene;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CutsceneViewer _0024self__002424490;

		public _0024main_002424487(CutsceneViewer self_)
		{
			_0024self__002424490 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002424490);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_storeOriginalGameObjects_002424491 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			internal CutsceneViewer _0024this_002424492;

			protected IEnumerator<Transform> _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator(CutsceneViewer _0024this_002424492)
			{
				this._0024this_002424492 = _0024this_002424492;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Transform>)_0024this_002424492.originalObjects).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					Transform current = _0024_0024enumerator.Current;
					_0024_0024current = current.name;
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal CutsceneViewer _0024this_002424493;

		public _0024_storeOriginalGameObjects_002424491(CutsceneViewer _0024this_002424493)
		{
			this._0024this_002424493 = _0024this_002424493;
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator(_0024this_002424493);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_storeOriginalGameObjects_002424494 : GenericGenerator<int>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<int>, ICloneable
		{
			internal CutsceneViewer _0024this_002424495;

			protected IEnumerator<Transform> _0024_0024enumerator;

			protected int _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override int Current => _0024_0024current;

			public Enumerator(CutsceneViewer _0024this_002424495)
			{
				this._0024this_002424495 = _0024this_002424495;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Transform>)_0024this_002424495.originalObjects).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					Transform current = _0024_0024enumerator.Current;
					_0024_0024current = current.GetInstanceID();
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal CutsceneViewer _0024this_002424496;

		public _0024_storeOriginalGameObjects_002424494(CutsceneViewer _0024this_002424496)
		{
			this._0024this_002424496 = _0024this_002424496;
		}

		public override IEnumerator<int> GetEnumerator()
		{
			return new Enumerator(_0024this_002424496);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_storeOriginalGameObjects_002424497 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024x_002424498;

			internal Transform _0024x_002424499;

			internal CutsceneViewer _0024self__002424500;

			public _0024(CutsceneViewer self_)
			{
				_0024self__002424500 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__002424500.originalObjects = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
					_0024self__002424500.originalObjectsTexts = (string[])Builtins.array(typeof(string), new List(new _0024_storeOriginalGameObjects_002424491(_0024self__002424500)));
					_0024self__002424500.originalObjectsIDs = (int[])Builtins.array(typeof(int), new List(new _0024_storeOriginalGameObjects_002424494(_0024self__002424500)));
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
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

		internal CutsceneViewer _0024self__002424501;

		public _0024_storeOriginalGameObjects_002424497(CutsceneViewer self_)
		{
			_0024self__002424501 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002424501);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024listFilter_002424502 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			internal _0024listFilter_0024locals_002414576 _0024_0024locals_002424503;

			protected IEnumerator _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator(_0024listFilter_0024locals_002414576 _0024_0024locals_002424503)
			{
				this._0024_0024locals_002424503 = _0024_0024locals_002424503;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable)_0024_0024locals_002424503._0024l).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				while (true)
				{
					if (_0024_0024enumerator.MoveNext())
					{
						object obj = _0024_0024enumerator.Current;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						string input = (string)obj;
						if (_0024_0024locals_002424503._0024r.Match(input).Success)
						{
							_0024_0024current = input;
							result = 1;
							break;
						}
						continue;
					}
					result = 0;
					break;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
			}
		}

		internal _0024listFilter_0024locals_002414576 _0024_0024locals_002424504;

		public _0024listFilter_002424502(_0024listFilter_0024locals_002414576 _0024_0024locals_002424504)
		{
			this._0024_0024locals_002424504 = _0024_0024locals_002424504;
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002424504);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024findAllscenes_002424505 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			protected IEnumerator _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator()
			{
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable)Enum.GetValues(typeof(SceneID))).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				while (true)
				{
					if (_0024_0024enumerator.MoveNext())
					{
						SceneID e = (SceneID)_0024_0024enumerator.Current;
						if (!RuntimeServices.op_Member("NONE", SceneIDModule.SceneIDToName(e)))
						{
							_0024_0024current = SceneIDModule.SceneIDToName(e);
							result = 1;
							break;
						}
						continue;
					}
					result = 0;
					break;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
			}
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024changeScene_002424506 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal object _0024stage_002424507;

			internal GameObject _0024hero_002424508;

			internal PlayerControl _0024pl_002424509;

			internal PlayerControl _0024p_002424510;

			internal BasicCamera _0024bc_002424511;

			internal GameObject _0024c_002424512;

			internal string _0024name_002424513;

			internal CutsceneViewer _0024self__002424514;

			public _0024(string name, CutsceneViewer self_)
			{
				_0024name_002424513 = name;
				_0024self__002424514 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002424514.manager)
					{
						CutSceneManager.Abort();
					}
					_0024self__002424514.manager = null;
					_0024self__002424514.destroyBeforeChangeScene();
					_0024stage_002424507 = _0024self__002424514.stages[_0024name_002424513];
					if (RuntimeServices.EqualityOperator(_0024stage_002424507, "Opening"))
					{
						_0024stage_002424507 = "heaven";
					}
					if (RuntimeServices.ToBool(_0024stage_002424507))
					{
						_0024self__002424514.stage_load_finish = false;
						CutsceneViewer cutsceneViewer = _0024self__002424514;
						object obj = _0024stage_002424507;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						cutsceneViewer.loadStage((string)obj);
					}
					else
					{
						_0024self__002424514.stage_load_finish = true;
					}
					goto case 2;
				case 2:
					if (!_0024self__002424514.stage_load_finish)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024hero_002424508 = PlayerControl.CurrentPlayerGO;
					if (!_0024hero_002424508)
					{
						_0024pl_002424509 = PlayerControl.Spawn();
						if (_0024pl_002424509 != null)
						{
							_0024hero_002424508 = _0024pl_002424509.gameObject;
						}
					}
					_0024p_002424510 = null;
					goto case 3;
				case 3:
					_0024p_002424510 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024p_002424510 != null)
					{
						goto case 4;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 4:
					if (!_0024p_002424510.IsReady)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024bc_002424511 = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera;
					_0024c_002424512 = GameObject.Find("Main Camera");
					if (((bool)_0024bc_002424511 || !_0024c_002424512) && !_0024bc_002424511)
					{
						if (!_0024c_002424512)
						{
							_0024c_002424512 = (GameObject)UnityEngine.Object.Instantiate(GameAssetModule.LoadPrefab("Prefab/Camera/Main Camera"));
						}
						_0024c_002424512.name = "Main Camera";
						_0024bc_002424511 = ((BasicCamera)UnityEngine.Object.FindObjectOfType(typeof(BasicCamera))) as BasicCamera;
					}
					if ((bool)_0024bc_002424511)
					{
						_0024bc_002424511.target = _0024hero_002424508.transform;
					}
					if ((bool)_0024self__002424514.manager)
					{
						_0024self__002424514.manager = CutSceneManager.CutSceneEx(_0024name_002424513, null, _0024name_002424513, autoStart: true);
					}
					if (!_0024self__002424514.manager)
					{
						_0024self__002424514.manager = CutSceneManager.CutSceneEx(_0024name_002424513, null, _0024name_002424513, autoStart: true);
					}
					_0024self__002424514.startFrame = Time.time;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024name_002424515;

		internal CutsceneViewer _0024self__002424516;

		public _0024changeScene_002424506(string name, CutsceneViewer self_)
		{
			_0024name_002424515 = name;
			_0024self__002424516 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424515, _0024self__002424516);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024destroyBeforeChangeScene_002424517 : GenericGenerator<Transform>
	{
		[Serializable]
		internal class Enumerator : IDisposable, ICloneable, IEnumerator<Transform>
		{
			internal CutsceneViewer _0024this_002424518;

			internal _0024destroyBeforeChangeScene_0024locals_002414577 _0024_0024locals_002424519;

			protected IEnumerator<Transform> _0024_0024enumerator;

			protected Transform _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override Transform Current => _0024_0024current;

			public Enumerator(CutsceneViewer _0024this_002424518, _0024destroyBeforeChangeScene_0024locals_002414577 _0024_0024locals_002424519)
			{
				this._0024this_002424518 = _0024this_002424518;
				this._0024_0024locals_002424519 = _0024_0024locals_002424519;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Transform>)_0024_0024locals_002424519._0024all).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				while (true)
				{
					if (_0024_0024enumerator.MoveNext())
					{
						Transform current = _0024_0024enumerator.Current;
						if (!_0024this_002424518.isViewerSceneObject(current))
						{
							_0024_0024current = current.root;
							result = 1;
							break;
						}
						continue;
					}
					result = 0;
					break;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal CutsceneViewer _0024this_002424520;

		internal _0024destroyBeforeChangeScene_0024locals_002414577 _0024_0024locals_002424521;

		public _0024destroyBeforeChangeScene_002424517(CutsceneViewer _0024this_002424520, _0024destroyBeforeChangeScene_0024locals_002414577 _0024_0024locals_002424521)
		{
			this._0024this_002424520 = _0024this_002424520;
			this._0024_0024locals_002424521 = _0024_0024locals_002424521;
		}

		public override IEnumerator<Transform> GetEnumerator()
		{
			return new Enumerator(_0024this_002424520, _0024_0024locals_002424521);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024destroyAfterLoadStage_002424522 : GenericGenerator<Transform>
	{
		[Serializable]
		internal class Enumerator : IDisposable, ICloneable, IEnumerator<Transform>
		{
			protected IEnumerator<Transform> _0024_0024enumerator;

			protected Transform _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override Transform Current => _0024_0024current;

			public Enumerator()
			{
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Transform>)(Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform))).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					Transform current = _0024_0024enumerator.Current;
					_0024_0024current = current.root;
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		public override IEnumerator<Transform> GetEnumerator()
		{
			return new Enumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_loadStage_002424523 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal SceneID _0024sid_002424524;

			internal IEnumerator _0024_0024sco_0024temp_00242751_002424525;

			internal IEnumerator _0024_0024sco_0024temp_00242752_002424526;

			internal string _0024sceneName_002424527;

			internal CutsceneViewer _0024self__002424528;

			public _0024(string sceneName, CutsceneViewer self_)
			{
				_0024sceneName_002424527 = sceneName;
				_0024self__002424528 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024sid_002424524 = SceneIDModule.StrToSceneID(_0024sceneName_002424527);
					if (SceneIDModule.IsValidSceneID(_0024sid_002424524))
					{
						_0024_0024sco_0024temp_00242751_002424525 = _0024self__002424528._loadSceneIdStage(_0024sid_002424524);
						if (_0024_0024sco_0024temp_00242751_002424525 != null)
						{
							result = (Yield(2, _0024self__002424528.StartCoroutine(_0024_0024sco_0024temp_00242751_002424525)) ? 1 : 0);
							break;
						}
					}
					else if (RuntimeAssetBundleDB.Instance.isPackedSceneName(_0024sceneName_002424527))
					{
						_0024_0024sco_0024temp_00242752_002424526 = _0024self__002424528._loadAssetBundleSceneStage(_0024sceneName_002424527);
						if (_0024_0024sco_0024temp_00242752_002424526 != null)
						{
							result = (Yield(3, _0024self__002424528.StartCoroutine(_0024_0024sco_0024temp_00242752_002424526)) ? 1 : 0);
							break;
						}
					}
					else
					{
						_0024self__002424528.stage_load_finish = true;
					}
					goto case 2;
				case 2:
				case 3:
					_0024self__002424528.destroyAfterLoadStage(_0024self__002424528.name);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sceneName_002424529;

		internal CutsceneViewer _0024self__002424530;

		public _0024_loadStage_002424523(string sceneName, CutsceneViewer self_)
		{
			_0024sceneName_002424529 = sceneName;
			_0024self__002424530 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024sceneName_002424529, _0024self__002424530);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_loadSceneIdStage_002424531 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal AsyncOperation _0024stats_002424532;

			internal SceneID _0024sceneID_002424533;

			internal CutsceneViewer _0024self__002424534;

			public _0024(SceneID sceneID, CutsceneViewer self_)
			{
				_0024sceneID_002424533 = sceneID;
				_0024self__002424534 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024stats_002424532 = Application.LoadLevelAdditiveAsync((int)_0024sceneID_002424533);
					goto case 2;
				case 2:
					if (!_0024stats_002424532.isDone)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002424534.stage_load_finish = true;
					_0024self__002424534.destroyAfterLoadStage(_0024self__002424534.name);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SceneID _0024sceneID_002424535;

		internal CutsceneViewer _0024self__002424536;

		public _0024_loadSceneIdStage_002424531(SceneID sceneID, CutsceneViewer self_)
		{
			_0024sceneID_002424535 = sceneID;
			_0024self__002424536 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024sceneID_002424535, _0024self__002424536);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_loadAssetBundleSceneStage_002424537 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB.Req _0024req_002424538;

			internal GameObject _0024o_002424539;

			internal QuestInitializer _0024questInitializer_002424540;

			internal string _0024sceneName_002424541;

			internal CutsceneViewer _0024self__002424542;

			public _0024(string sceneName, CutsceneViewer self_)
			{
				_0024sceneName_002424541 = sceneName;
				_0024self__002424542 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002424538 = RuntimeAssetBundleDB.Instance.loadPackedScenePrefab(_0024sceneName_002424541);
					goto case 2;
				case 2:
					if (!_0024req_002424538.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!(_0024req_002424538.Prefab == null))
					{
						_0024o_002424539 = (GameObject)UnityEngine.Object.Instantiate(_0024req_002424538.Prefab);
						_0024questInitializer_002424540 = _0024o_002424539.GetComponentInChildren<QuestInitializer>();
						if ((bool)_0024questInitializer_002424540)
						{
							UnityEngine.Object.DestroyImmediate(_0024questInitializer_002424540.gameObject);
						}
					}
					_0024self__002424542.stage_load_finish = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024sceneName_002424543;

		internal CutsceneViewer _0024self__002424544;

		public _0024_loadAssetBundleSceneStage_002424537(string sceneName, CutsceneViewer self_)
		{
			_0024sceneName_002424543 = sceneName;
			_0024self__002424544 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024sceneName_002424543, _0024self__002424544);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024OnGUISceneSelect_0024_changeScene_00246558_002424545 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024name_002424546;

			internal CutsceneViewer _0024self__002424547;

			public _0024(string name, CutsceneViewer self_)
			{
				_0024name_002424546 = name;
				_0024self__002424547 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002424547.switchMode((MENU_MODE)(-1));
					_0024self__002424547.StartCoroutine(_0024self__002424547.changeScene(_0024name_002424546));
					result = (YieldDefault(2) ? 1 : 0);
					break;
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

		internal string _0024name_002424548;

		internal CutsceneViewer _0024self__002424549;

		public _0024_0024OnGUISceneSelect_0024_changeScene_00246558_002424545(string name, CutsceneViewer self_)
		{
			_0024name_002424548 = name;
			_0024self__002424549 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024name_002424548, _0024self__002424549);
		}
	}

	public CutSceneManager manager;

	public MENU_MODE menu_mode;

	private int current_mode;

	private string[] mode_toolbar_label;

	private int cursor;

	private Vector2 scroll;

	private string listFilterStrings;

	public bool stage_load_finish;

	private List scenes;

	private Hash stages;

	private List filterdScenes;

	private GUIStyle modeStyle;

	private GUIStyle filterStyle;

	private GUIStyle listStyle;

	public readonly string[][] MOBILE_MOTVIEWER_SCENE_FILTER;

	public Transform[] originalObjects;

	public int[] originalObjectsIDs;

	public string[] originalObjectsTexts;

	public bool dispInformationFlag;

	private float currentFrame;

	private float startFrame;

	public GameObject cam;

	private string currentCameraMotionName;

	private string currentCameraMotionFrame;

	[NonSerialized]
	internal static Regex _0024re_002424728 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424729 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424730 = new Regex("_");

	public CutsceneViewer()
	{
		menu_mode = MENU_MODE.select_scene;
		current_mode = (int)menu_mode;
		mode_toolbar_label = new string[3] { "終了", "選択", "制御" };
		cursor = -1;
		listFilterStrings = string.Empty;
		scenes = new List(new object[384]
		{
			"Merlin_CutSceneSB00", "Merlin_CutSceneCH00", "Merlin_CutSceneCR01_ev01", "Merlin_CutSceneCR01_ev02", "Merlin_CutSceneCR02_ev01", "Merlin_CutSceneCR02_ev02", "Merlin_CutSceneCR02_ev03", "Merlin_CutSceneCR02_ev04", "Merlin_CutSceneCR03_ev01", "Merlin_CutSceneCR03_ev02",
			"Merlin_CutSceneCR03_ev03", "Merlin_CutSceneCR03_ev04", "Merlin_CutSceneCR03_ev05", "Merlin_CutSceneCR03_ev06", "Merlin_CutSceneCR03_ev07", "Merlin_CutSceneCR03_ev08", "Merlin_CutSceneCR04_ev01", "Merlin_CutSceneCR04_ev02", "Merlin_CutSceneCR05_ev01", "Merlin_CutSceneCR05_ev02",
			"Merlin_CutSceneCR05_ev03", "Merlin_CutSceneCR05_ev04", "Merlin_CutSceneCR05_ev05", "Merlin_CutSceneCR05_ev06", "Merlin_CutSceneCR05_ev07", "Merlin_CutSceneCR06_ev01", "Merlin_CutSceneCR06_ev02", "Merlin_CutSceneCR06_ev03", "Merlin_CutSceneCR06_ev04", "Merlin_CutSceneCR06_ev05",
			"Merlin_CutSceneCR06_ev06", "Merlin_CutSceneCR06_ev07", "Merlin_CutSceneCR07_ev01", "Merlin_CutSceneCR07_ev02", "Merlin_CutSceneCR07_ev03", "Merlin_CutSceneCR08_ev01", "Merlin_CutSceneCR08_ev02", "Merlin_CutSceneCR09_ev01", "Merlin_CutSceneCR09_ev02", "Merlin_CutSceneCR10_ev01",
			"Merlin_CutSceneCR10_ev02", "Merlin_CutSceneCR10_ev03", "Merlin_CutSceneCR10_ev04", "Merlin_CutSceneCR11_ev01", "Merlin_CutSceneCR11_ev02", "Merlin_CutSceneCR12_ev01", "Merlin_CutSceneCR12_ev02", "Merlin_CutSceneDR02_ev01", "Merlin_CutSceneDR02_ev02", "Merlin_CutSceneOpening1",
			"Merlin_CutScenePrologue1", "Merlin_CutScenePrologue_ev03", "Merlin_CutScenePrologue_ev04", "Merlin_CutSceneBE5001_01", "Merlin_CutSceneBE5001_02", "Merlin_CutSceneBE5003_01", "Merlin_CutSceneBE5003_02", "Merlin_CutSceneBE5015_01", "Merlin_CutSceneBE5015_02", "Merlin_CutSceneBE5016_01",
			"Merlin_CutSceneBE5016_02", "Merlin_CutSceneBE5017_01", "Merlin_CutSceneBE5017_02", "Merlin_CutSceneBE5018_01", "Merlin_CutSceneBE5018_02", "Merlin_CutSceneBE5023_01", "Merlin_CutSceneBE5023_02", "Merlin_CutSceneBE5024_01", "Merlin_CutSceneBE5024_02", "Merlin_CutSceneBE5025_01",
			"Merlin_CutSceneBE5025_02", "Merlin_CutSceneBE5027_01", "Merlin_CutSceneBE5028_01", "Merlin_CutSceneBE5030_01", "Merlin_CutSceneBE5031_01", "Merlin_CutSceneST01_ev01", "Merlin_CutSceneST01_ev02", "Merlin_CutSceneST01_ev03", "Merlin_CutSceneST01_ev04", "Merlin_CutSceneST01_ev05",
			"Merlin_CutSceneST01_ev06", "Merlin_CutSceneST01_ev07", "Merlin_CutSceneST01_ev08", "Merlin_CutSceneST01_ev09", "Merlin_CutSceneST01_ev10", "Merlin_CutSceneST01_ev11", "Merlin_CutSceneST01_ev12", "Merlin_CutSceneST02_ev01", "Merlin_CutSceneST02_ev02", "Merlin_CutSceneST02_ev03",
			"Merlin_CutSceneST02_ev04", "Merlin_CutSceneST02_ev05", "Merlin_CutSceneST02_ev06", "Merlin_CutSceneST02_ev07", "Merlin_CutSceneST02_ev08", "Merlin_CutSceneST03_ev01", "Merlin_CutSceneST03_ev02", "Merlin_CutSceneST03_ev03", "Merlin_CutSceneST03_ev04", "Merlin_CutSceneST04_ev01",
			"Merlin_CutSceneST04_ev03", "Merlin_CutSceneST04_ev04", "Merlin_CutSceneST04_ev05", "Merlin_CutSceneST04_ev06", "Merlin_CutSceneST05_ev01", "Merlin_CutSceneST05_ev02", "Merlin_CutSceneST05_ev03", "Merlin_CutSceneST05_ev04", "Merlin_CutSceneST05_ev05", "Merlin_CutSceneST05_ev06",
			"Merlin_CutSceneST05_ev07", "Merlin_CutSceneST05_ev08", "Merlin_CutSceneST05_ev09", "Merlin_CutSceneST06_ev01", "Merlin_CutSceneST06_ev02", "Merlin_CutSceneST06_ev03", "Merlin_CutSceneST06_ev04", "Merlin_CutSceneST06_ev05", "Merlin_CutSceneST06_ev06", "Merlin_CutSceneST07_ev01",
			"Merlin_CutSceneST07_ev02", "Merlin_CutSceneST07_ev03", "Merlin_CutSceneST07_ev04", "Merlin_CutSceneST07_ev05", "Merlin_CutSceneST07_ev06", "Merlin_CutSceneST07_ev07", "Merlin_CutSceneST07_ev08", "Merlin_CutSceneST07_ev09", "Merlin_CutSceneST07_ev10", "Merlin_CutSceneST08_ev01",
			"Merlin_CutSceneST08_ev02", "Merlin_CutSceneST08_ev03", "Merlin_CutSceneST08_ev04", "Merlin_CutSceneST08_ev05", "Merlin_CutSceneST09_ev01", "Merlin_CutSceneST09_ev02", "Merlin_CutSceneST09_ev03", "Merlin_CutSceneST09_ev04", "Merlin_CutSceneST09_ev05", "Merlin_CutSceneST09_ev07",
			"Merlin_CutSceneST09_ev08", "Merlin_CutSceneST10_ev01", "Merlin_CutSceneST10_ev02", "Merlin_CutSceneST10_ev03", "Merlin_CutSceneST10_ev04", "Merlin_CutSceneST10_ev06", "Merlin_CutSceneST10_ev07", "Merlin_CutSceneST10_ev08", "Merlin_CutSceneST11_ev01", "Merlin_CutSceneST11_ev02",
			"Merlin_CutSceneST11_ev03", "Merlin_CutSceneST11_ev04", "Merlin_CutSceneST11_ev05", "Merlin_CutSceneST11_ev06", "Merlin_CutSceneST11_ev07", "Merlin_CutSceneST12_ev01", "Merlin_CutSceneST12_ev02", "Merlin_CutSceneST12_ev03", "Merlin_CutSceneST12_ev04", "Merlin_CutSceneST12_ev05",
			"Merlin_CutSceneST12_ev06", "Merlin_CutSceneST12_ev07", "Merlin_CutSceneST13_ev01", "Merlin_CutSceneST13_ev02", "Merlin_CutSceneST13_ev03", "Merlin_CutSceneST13_ev04", "Merlin_CutSceneST13_ev05", "Merlin_CutSceneST13_ev06", "Merlin_CutSceneST13_ev07", "Merlin_CutSceneST13_ev08",
			"Merlin_CutSceneST14_ev01", "Merlin_CutSceneST14_ev02", "Merlin_CutSceneST14_ev03", "Merlin_CutSceneST14_ev04", "Merlin_CutSceneST14_ev05", "Merlin_CutSceneST14_ev06", "Merlin_CutSceneST15_ev01", "Merlin_CutSceneST15_ev02", "Merlin_CutSceneST15_ev03", "Merlin_CutSceneST15_ev04",
			"Merlin_CutSceneST15_ev05", "Merlin_CutSceneST15_ev06", "Merlin_CutSceneST15_ev07", "Merlin_CutSceneST15_ev08", "Merlin_CutSceneST16_ev01", "Merlin_CutSceneST16_ev02", "Merlin_CutSceneST16_ev03", "Merlin_CutSceneST16_ev04", "Merlin_CutSceneST16_ev05", "Merlin_CutSceneST16_ev06",
			"Merlin_CutSceneST16_ev07", "Merlin_CutSceneST17_ev01", "Merlin_CutSceneST17_ev02", "Merlin_CutSceneST17_ev03", "Merlin_CutSceneST17_ev04", "Merlin_CutSceneST17_ev05", "Merlin_CutSceneST17_ev06", "Merlin_CutSceneST17_ev07", "Merlin_CutSceneST17_ev08", "Merlin_CutSceneST18_ev01",
			"Merlin_CutSceneST18_ev02", "Merlin_CutSceneST18_ev03", "Merlin_CutSceneST19_ev01", "Merlin_CutSceneST19_ev02", "Merlin_CutSceneST19_ev03", "Merlin_CutSceneST19_ev04", "Merlin_CutSceneST19_ev05", "Merlin_CutSceneST19_ev06", "Merlin_CutSceneST20_ev01", "Merlin_CutSceneST20_ev02",
			"Merlin_CutSceneST20_ev03", "Merlin_CutSceneST20_ev04", "Merlin_CutSceneST20_ev06", "Merlin_CutSceneST20_ev07", "Merlin_CutSceneST20_ev08", "Merlin_CutSceneST20_ev09", "Merlin_CutSceneST21_ev01", "Merlin_CutSceneST21_ev02", "Merlin_CutSceneST21_ev03", "Merlin_CutSceneST21_ev04",
			"Merlin_CutSceneST22_ev01", "Merlin_CutSceneST22_ev02", "Merlin_CutSceneST22_ev03", "Merlin_CutSceneST23_ev01", "Merlin_CutSceneST23_ev02", "Merlin_CutSceneST23_ev03", "Merlin_CutSceneST23_ev04", "Merlin_CutSceneST23_ev05", "Merlin_CutSceneST24_ev01", "Merlin_CutSceneST24_ev02",
			"Merlin_CutSceneST24_ev03", "Merlin_CutSceneST24_ev04", "Merlin_CutSceneST25_ev01", "Merlin_CutSceneST25_ev02", "Merlin_CutSceneST25_ev03", "Merlin_CutSceneST25_ev04", "Merlin_CutSceneST25_ev05", "Merlin_CutSceneST25_ev06", "Merlin_CutSceneST26_ev01", "Merlin_CutSceneST26_ev02",
			"Merlin_CutSceneST26_ev03", "Merlin_CutSceneST26_ev04", "Merlin_CutSceneST26_ev05", "Merlin_CutSceneST27_ev01", "Merlin_CutSceneST27_ev02", "Merlin_CutSceneST27_ev03", "Merlin_CutSceneST27_ev04", "Merlin_CutSceneST28_ev01", "Merlin_CutSceneST28_ev02", "Merlin_CutSceneST28_ev03",
			"Merlin_CutSceneST28_ev04", "Merlin_CutSceneST28_ev05", "Merlin_CutSceneST28_ev06", "Merlin_CutSceneST28_ev07", "Merlin_CutSceneST29_ev01", "Merlin_CutSceneST29_ev02", "Merlin_CutSceneST29_ev03", "Merlin_CutSceneST29_ev04", "Merlin_CutSceneSS020104_ev01", "Merlin_CutSceneSS020104_ev02",
			"Merlin_CutSceneSS020104_ev03", "Merlin_CutSceneSS010104_ev01", "Merlin_CutSceneSS010104_ev02", "Merlin_CutSceneSS030105_ev01", "Merlin_CutSceneSS030105_ev02", "Merlin_CutSceneSS040105_ev01", "Merlin_CutSceneSS040105_ev02", "Merlin_CutSceneSS040105_ev03", "Merlin_CutSceneSS060103_ev01", "Merlin_CutSceneSS060103_ev02",
			"Merlin_CutSceneSS050103_ev01", "Merlin_CutSceneSS050103_ev02", "Merlin_CutSceneSS050103_ev03", "Merlin_CutSceneSS020206_ev01", "Merlin_CutSceneSS020206_ev02", "Merlin_CutSceneSS020206_ev03", "Merlin_CutSceneSS010206_ev01", "Merlin_CutSceneSS010206_ev02", "Merlin_CutSceneSS120105_ev01", "Merlin_CutSceneSS120105_ev02",
			"Merlin_CutSceneSS120205_ev01", "Merlin_CutSceneSS120205_ev02", "Merlin_CutSceneSS120304_ev01", "Merlin_CutSceneSS120304_ev02", "Merlin_CutSceneSS130104_ev01", "Merlin_CutSceneSS130104_ev02", "Merlin_CutSceneSS130104_ev03", "Merlin_CutSceneSS110107_ev01", "Merlin_CutSceneSS110107_ev02", "Merlin_CutSceneSS110107_ev03",
			"Merlin_CutSceneSS110107_ev04", "Merlin_CutSceneSS110107_ev05", "Merlin_CutSceneSS090107_ev01", "Merlin_CutSceneSS090107_ev02", "Merlin_CutSceneSS090107_ev03", "Merlin_CutSceneSS060208_ev01", "Merlin_CutSceneSS060208_ev02", "Merlin_CutSceneSS010308_ev01", "Merlin_CutSceneSS010308_ev02", "Merlin_CutSceneSS040204_ev01",
			"Merlin_CutSceneSS040204_ev02", "Merlin_CutSceneSS040204_ev03", "Merlin_CutSceneSS100104_ev01", "Merlin_CutSceneSS100104_ev02", "Merlin_CutSceneSS100104_ev03", "Merlin_CutSceneSS100104_ev04", "Merlin_CutSceneSS030206_ev01", "Merlin_CutSceneSS030206_ev02", "Merlin_CutSceneSS080106_ev01", "Merlin_CutSceneSS080106_ev02",
			"Merlin_CutSceneSS080106_ev03", "Merlin_CutSceneSS060305_ev01", "Merlin_CutSceneSS060305_ev02", "Merlin_CutSceneSS080205_ev01", "Merlin_CutSceneSS080205_ev02", "Merlin_CutSceneSS080205_ev03", "Merlin_CutSceneSS050209_ev01", "Merlin_CutSceneSS050209_ev02", "Merlin_CutSceneSS050209_ev03", "Merlin_CutSceneSS010409_ev01",
			"Merlin_CutSceneSS010409_ev02", "Merlin_CutSceneSS030310_ev01", "Merlin_CutSceneSS030310_ev02", "Merlin_CutSceneSS070110_ev01", "Merlin_CutSceneSS070110_ev02", "Merlin_CutSceneSS040308_ev01", "Merlin_CutSceneSS040308_ev02", "Merlin_CutSceneSS040308_ev03", "Merlin_CutSceneSS050308_ev01", "Merlin_CutSceneSS050308_ev02",
			"Merlin_CutSceneSS050308_ev03", "Merlin_CutSceneSS030407_ev01", "Merlin_CutSceneSS030407_ev02", "Merlin_CutSceneSS060407_ev01", "Merlin_CutSceneSS060407_ev02", "Merlin_CutSceneSS020303_ev01", "Merlin_CutSceneSS020303_ev02", "Merlin_CutSceneSS020303_ev03", "Merlin_CutSceneSS010503_ev01", "Merlin_CutSceneSS010503_ev02",
			"Merlin_CutSceneSS990105_ev01", "Merlin_CutSceneSS990105_ev02", "Merlin_CutSceneSS990105_ev03", "Merlin_CutSceneSS990206_ev02", "Merlin_CutSceneSS990206_ev03", "Merlin_CutSceneSS990206_ev04", "Merlin_CutSceneSS990303_ev02", "Merlin_CutSceneSS990303_ev03", "Merlin_CutSceneSS990303_ev04", "Merlin_CutSceneSS990407_ev02",
			"Merlin_CutSceneSS990407_ev03", "Merlin_CutSceneSS140114_ev01", "Merlin_CutSceneSS140114_ev02", "Merlin_CutSceneSS140210_ev01", "Merlin_CutSceneSS140210_ev02", "Merlin_CutSceneSS140317_ev01", "Merlin_CutSceneSS140317_ev02", "Merlin_CutSceneSS150114_ev01", "Merlin_CutSceneSS150114_ev02", "Merlin_CutSceneSS150114_ev03",
			"Merlin_CutSceneSS150216_ev01", "Merlin_CutSceneSS150216_ev02", "Merlin_CutSceneSS150216_ev03", "Merlin_CutSceneSS160105_ev01", "Merlin_CutSceneSS160105_ev02", "Merlin_CutSceneSS160105_ev03", "Merlin_CutSceneSS170105_ev01", "Merlin_CutSceneSS170105_ev02", "Merlin_CutSceneSS170215_ev01", "Merlin_CutSceneSS170215_ev02",
			"Merlin_CutSceneSS180115_ev01", "Merlin_CutSceneSS180115_ev02", "Merlin_CutSceneSS180210_ev01", "Merlin_CutSceneSS180210_ev02", "Merlin_CutSceneSS190109_ev01", "Merlin_CutSceneSS190109_ev02", "Merlin_CutSceneSS200109_ev01", "Merlin_CutSceneSS200109_ev02", "Merlin_CutSceneSS200109_ev03", "Merlin_CutSceneSS210116_ev01",
			"Merlin_CutSceneSS210116_ev02", "Merlin_CutSceneSS210116_ev03", "Merlin_CutSceneSS010617_ev01", "Merlin_CutSceneSS010617_ev02"
		}, takeOwnership: true);
		stages = new Hash
		{
			{ "Merlin_CutSceneSB00", "Myhome" },
			{ "Merlin_CutSceneCH00", "Nightmare" },
			{ "Merlin_CutSceneCR01_ev01", "desert_009" },
			{ "Merlin_CutSceneCR01_ev02", "desert_000" },
			{ "Merlin_CutSceneCR02_ev01", "volcano_012" },
			{ "Merlin_CutSceneCR02_ev02", "desert_011" },
			{ "Merlin_CutSceneCR02_ev03", "forest_008" },
			{ "Merlin_CutSceneCR02_ev04", "snowfield_012" },
			{ "Merlin_CutSceneCR03_ev01", "forest_002" },
			{ "Merlin_CutSceneCR03_ev02", "forest_010" },
			{ "Merlin_CutSceneCR03_ev03", "cave_002" },
			{ "Merlin_CutSceneCR03_ev04", "cave_009" },
			{ "Merlin_CutSceneCR03_ev05", "flamevalley_005" },
			{ "Merlin_CutSceneCR03_ev06", "flamevalley_007" },
			{ "Merlin_CutSceneCR03_ev07", "temple_000" },
			{ "Merlin_CutSceneCR03_ev08", "temple_003" },
			{ "Merlin_CutSceneCR04_ev01", "temple_010" },
			{ "Merlin_CutSceneCR04_ev02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneCR05_ev01", "flamevalley_010" },
			{ "Merlin_CutSceneCR05_ev02", "flamevalley_009" },
			{ "Merlin_CutSceneCR05_ev03", "darkforest_003" },
			{ "Merlin_CutSceneCR05_ev04", "darkforest_006" },
			{ "Merlin_CutSceneCR05_ev05", "temple_000" },
			{ "Merlin_CutSceneCR05_ev06", "temple_003" },
			{ "Merlin_CutSceneCR05_ev07", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneCR06_ev01", "cave_005" },
			{ "Merlin_CutSceneCR06_ev02", "cave_003" },
			{ "Merlin_CutSceneCR06_ev03", "forest_004" },
			{ "Merlin_CutSceneCR06_ev04", "forest_008" },
			{ "Merlin_CutSceneCR06_ev05", "temple_006" },
			{ "Merlin_CutSceneCR06_ev06", "temple_010" },
			{ "Merlin_CutSceneCR06_ev07", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneCR07_ev01", "mountain_002" },
			{ "Merlin_CutSceneCR07_ev02", "mountain_004" },
			{ "Merlin_CutSceneCR07_ev03", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneCR08_ev01", "forest_007" },
			{ "Merlin_CutSceneCR08_ev02", "forest_008" },
			{ "Merlin_CutSceneCR09_ev01", "temple_000" },
			{ "Merlin_CutSceneCR09_ev02", "temple_003" },
			{ "Merlin_CutSceneCR10_ev01", "temple_002" },
			{ "Merlin_CutSceneCR10_ev02", "temple_006" },
			{ "Merlin_CutSceneCR10_ev03", "sanctuary_006" },
			{ "Merlin_CutSceneCR10_ev04", "sanctuary_009" },
			{ "Merlin_CutSceneCR11_ev01", "forest_002" },
			{ "Merlin_CutSceneCR11_ev02", "forest_008" },
			{ "Merlin_CutSceneCR12_ev01", "desert_000" },
			{ "Merlin_CutSceneCR12_ev02", "desert_001" },
			{ "Merlin_CutSceneDR02_ev01", "flamevalley_005" },
			{ "Merlin_CutSceneDR02_ev02", "flamevalley_011" },
			{ "Merlin_CutSceneOpening1", "Opening" },
			{ "Merlin_CutScenePrologue1", "mountain_000" },
			{ "Merlin_CutScenePrologue_ev03", "mountain_005" },
			{ "Merlin_CutScenePrologue_ev04", "mountain_005" },
			{ "Merlin_Pro_Test2", "mountain_005" },
			{ "Merlin_CutSceneST01_ev01", "Myhome" },
			{ "Merlin_CutSceneST01_ev02", "Town" },
			{ "Merlin_CutSceneST01_ev03", "Town" },
			{ "Merlin_CutSceneST01_ev04", "Town" },
			{ "Merlin_CutSceneST01_ev05", "Town" },
			{ "Merlin_CutSceneST01_ev06", "cave_002" },
			{ "Merlin_CutSceneST01_ev07", "cave_000" },
			{ "Merlin_CutSceneST01_ev08", "cave_000" },
			{ "Merlin_CutSceneST01_ev09", "cave_000" },
			{ "Merlin_CutSceneST01_ev10", "Town" },
			{ "Merlin_CutSceneST01_ev11", "Town" },
			{ "Merlin_CutSceneST01_ev12", "Town" },
			{ "Merlin_CutSceneST02_ev01", "Myhome" },
			{ "Merlin_CutSceneST02_ev02", "Town" },
			{ "Merlin_CutSceneST02_ev03", "forest_002" },
			{ "Merlin_CutSceneST02_ev04", "forest_009" },
			{ "Merlin_CutSceneST02_ev05", "forest_001" },
			{ "Merlin_CutSceneST02_ev06", "forest_001" },
			{ "Merlin_CutSceneST02_ev07", "forest_000" },
			{ "Merlin_CutSceneST02_ev08", "forest_009" },
			{ "Merlin_CutSceneST03_ev01", "Myhome" },
			{ "Merlin_CutSceneST03_ev02", "Raid01" },
			{ "Merlin_CutSceneST03_ev03", "Raid01" },
			{ "Merlin_CutSceneST03_ev04", "Raid01" },
			{ "Merlin_CutSceneST04_ev01", "Myhome" },
			{ "Merlin_CutSceneST04_ev02", "Town" },
			{ "Merlin_CutSceneST04_ev03", "Town" },
			{ "Merlin_CutSceneST04_ev04", "mountain_001" },
			{ "Merlin_CutSceneST04_ev05", "mountain_004" },
			{ "Merlin_CutSceneST04_ev06", "mountain_004" },
			{ "Merlin_CutSceneST05_ev01", "Myhome" },
			{ "Merlin_CutSceneST05_ev02", "Town" },
			{ "Merlin_CutSceneST05_ev03", "Town" },
			{ "Merlin_CutSceneST05_ev04", "desert_000" },
			{ "Merlin_CutSceneST05_ev05", "desert_000" },
			{ "Merlin_CutSceneST05_ev06", "desert_000" },
			{ "Merlin_CutSceneST05_ev07", "desert_009" },
			{ "Merlin_CutSceneST05_ev08", "desert_009" },
			{ "Merlin_CutSceneST05_ev09", "desert_000" },
			{ "Merlin_CutSceneST06_ev01", "Myhome" },
			{ "Merlin_CutSceneST06_ev02", "forest_010" },
			{ "Merlin_CutSceneST06_ev03", "forest_010" },
			{ "Merlin_CutSceneST06_ev04", "forest_001" },
			{ "Merlin_CutSceneST06_ev05", "forest_001" },
			{ "Merlin_CutSceneST06_ev06", "forest_000" },
			{ "Merlin_CutSceneST07_ev01", "Myhome" },
			{ "Merlin_CutSceneST07_ev02", "Town" },
			{ "Merlin_CutSceneST07_ev03", "Town" },
			{ "Merlin_CutSceneST07_ev04", "cave_002" },
			{ "Merlin_CutSceneST07_ev05", "cave_000" },
			{ "Merlin_CutSceneST07_ev06", "cave_001" },
			{ "Merlin_CutSceneST07_ev07", "cave_001" },
			{ "Merlin_CutSceneST07_ev08", "cave_001" },
			{ "Merlin_CutSceneST07_ev09", "cave_001" },
			{ "Merlin_CutSceneST07_ev10", "cave_001" },
			{ "Merlin_CutSceneST08_ev01", "Myhome" },
			{ "Merlin_CutSceneST08_ev02", "temple_000" },
			{ "Merlin_CutSceneST08_ev03", "temple_000" },
			{ "Merlin_CutSceneST08_ev04", "temple_003" },
			{ "Merlin_CutSceneST08_ev05", "temple_003" },
			{ "Merlin_CutSceneST09_ev01", "Myhome" },
			{ "Merlin_CutSceneST09_ev02", "temple_000" },
			{ "Merlin_CutSceneST09_ev03", "temple_002" },
			{ "Merlin_CutSceneST09_ev04", "temple_003" },
			{ "Merlin_CutSceneST09_ev05", "temple_002" },
			{ "Merlin_CutSceneST09_ev07", "temple_014" },
			{ "Merlin_CutSceneST09_ev08", "temple_014" },
			{ "Merlin_CutSceneST10_ev01", "Myhome" },
			{ "Merlin_CutSceneST10_ev02", "Myhome" },
			{ "Merlin_CutSceneST10_ev03", "Town" },
			{ "Merlin_CutSceneST10_ev04", "volcano_000" },
			{ "Merlin_CutSceneST10_ev06", "volcano_012" },
			{ "Merlin_CutSceneST10_ev07", "volcano_012" },
			{ "Merlin_CutSceneST10_ev08", "volcano_012" },
			{ "Merlin_CutSceneST11_ev01", "Myhome" },
			{ "Merlin_CutSceneST11_ev02", "Town" },
			{ "Merlin_CutSceneST11_ev03", "Town" },
			{ "Merlin_CutSceneST11_ev04", "Town" },
			{ "Merlin_CutSceneST11_ev05", "Myhome" },
			{ "Merlin_CutSceneST11_ev06", "cave_000" },
			{ "Merlin_CutSceneST11_ev07", "cave_000" },
			{ "Merlin_CutSceneST12_ev01", "Myhome" },
			{ "Merlin_CutSceneST12_ev02", "Town" },
			{ "Merlin_CutSceneST12_ev03", "desert_000" },
			{ "Merlin_CutSceneST12_ev04", "desert_000" },
			{ "Merlin_CutSceneST12_ev05", "desert_004" },
			{ "Merlin_CutSceneST12_ev06", "desert_004" },
			{ "Merlin_CutSceneST12_ev07", "desert_006" },
			{ "Merlin_CutSceneST13_ev01", "Myhome" },
			{ "Merlin_CutSceneST13_ev02", "forest_011" },
			{ "Merlin_CutSceneST13_ev03", "forest_011" },
			{ "Merlin_CutSceneST13_ev04", "forest_005" },
			{ "Merlin_CutSceneST13_ev05", "forest_005" },
			{ "Merlin_CutSceneST13_ev06", "forest_001" },
			{ "Merlin_CutSceneST13_ev07", "forest_001" },
			{ "Merlin_CutSceneST13_ev08", "forest_000" },
			{ "Merlin_CutSceneST14_ev01", "Myhome" },
			{ "Merlin_CutSceneST14_ev02", "Town" },
			{ "Merlin_CutSceneST14_ev03", "Town" },
			{ "Merlin_CutSceneST14_ev04", "coast_000" },
			{ "Merlin_CutSceneST14_ev05", "coast_003" },
			{ "Merlin_CutSceneST14_ev06", "coast_003" },
			{ "Merlin_CutSceneST15_ev01", "Myhome" },
			{ "Merlin_CutSceneST15_ev02", "Town" },
			{ "Merlin_CutSceneST15_ev03", "Town" },
			{ "Merlin_CutSceneST15_ev04", "snowfield_009" },
			{ "Merlin_CutSceneST15_ev05", "snowfield_009" },
			{ "Merlin_CutSceneST15_ev06", "snowfield_009" },
			{ "Merlin_CutSceneST15_ev07", "snowfield_009" },
			{ "Merlin_CutSceneST15_ev08", "snowfield_009" },
			{ "Merlin_CutSceneST16_ev01", "Myhome" },
			{ "Merlin_CutSceneST16_ev02", "Town" },
			{ "Merlin_CutSceneST16_ev03", "Town" },
			{ "Merlin_CutSceneST16_ev04", "volcano_009" },
			{ "Merlin_CutSceneST16_ev05", "volcano_009" },
			{ "Merlin_CutSceneST16_ev06", "volcano_012" },
			{ "Merlin_CutSceneST16_ev07", "volcano_012" },
			{ "Merlin_CutSceneST17_ev01", "Myhome" },
			{ "Merlin_CutSceneST17_ev02", "Town" },
			{ "Merlin_CutSceneST17_ev03", "Town" },
			{ "Merlin_CutSceneST17_ev04", "temple_000" },
			{ "Merlin_CutSceneST17_ev05", "temple_009" },
			{ "Merlin_CutSceneST17_ev06", "temple_014" },
			{ "Merlin_CutSceneST17_ev07", "temple_014" },
			{ "Merlin_CutSceneST17_ev08", "temple_014" },
			{ "Merlin_CutSceneST18_ev01", "Myhome" },
			{ "Merlin_CutSceneST18_ev02", "mountain_000" },
			{ "Merlin_CutSceneST18_ev03", "mountain_000" },
			{ "Merlin_CutSceneST19_ev01", "Myhome" },
			{ "Merlin_CutSceneST19_ev02", "Myhome" },
			{ "Merlin_CutSceneST19_ev03", "mountain_000" },
			{ "Merlin_CutSceneST19_ev04", "heaven" },
			{ "Merlin_CutSceneST19_ev05", "heaven" },
			{ "Merlin_CutSceneST19_ev06", "Town" },
			{ "Merlin_CutSceneST20_ev01", "Myhome" },
			{ "Merlin_CutSceneST20_ev02", "Myhome" },
			{ "Merlin_CutSceneST20_ev03", "heaven" },
			{ "Merlin_CutSceneST20_ev04", "sanctuary_009" },
			{ "Merlin_CutSceneST20_ev05", "sanctuary_009" },
			{ "Merlin_CutSceneST20_ev06", "sanctuary_009" },
			{ "Merlin_CutSceneST20_ev07", "sanctuary_009" },
			{ "Merlin_CutSceneST20_ev08", "Town" },
			{ "Merlin_CutSceneST20_ev09", "Nightmare" },
			{ "Merlin_CutSceneST21_ev01", "Myhome" },
			{ "Merlin_CutSceneST21_ev02", "icecave_001" },
			{ "Merlin_CutSceneST21_ev03", "icecave_010" },
			{ "Merlin_CutSceneST21_ev04", "icecave_010" },
			{ "Merlin_CutSceneST22_ev01", "Myhome" },
			{ "Merlin_CutSceneST22_ev02", "heaven" },
			{ "Merlin_CutSceneST22_ev03", "heaven" },
			{ "Merlin_CutSceneST23_ev01", "Myhome" },
			{ "Merlin_CutSceneST23_ev02", "forest_002" },
			{ "Merlin_CutSceneST23_ev03", "forest_001" },
			{ "Merlin_CutSceneST23_ev04", "forest_001" },
			{ "Merlin_CutSceneST23_ev05", "forest_000" },
			{ "Merlin_CutSceneST24_ev01", "Myhome" },
			{ "Merlin_CutSceneST24_ev02", "flamevalley_000" },
			{ "Merlin_CutSceneST24_ev03", "flamevalley_009" },
			{ "Merlin_CutSceneST24_ev04", "flamevalley_009" },
			{ "Merlin_CutSceneST25_ev01", "Myhome" },
			{ "Merlin_CutSceneST25_ev02", "snowfield_008" },
			{ "Merlin_CutSceneST25_ev03", "snowfield_002" },
			{ "Merlin_CutSceneST25_ev04", "snowfield_002" },
			{ "Merlin_CutSceneST25_ev05", "snowfield_012" },
			{ "Merlin_CutSceneST25_ev06", "snowfield_012" },
			{ "Merlin_CutSceneST26_ev01", "Myhome" },
			{ "Merlin_CutSceneST26_ev02", "coast_005" },
			{ "Merlin_CutSceneST26_ev03", "coast_005" },
			{ "Merlin_CutSceneST26_ev04", "coast_009" },
			{ "Merlin_CutSceneST26_ev05", "coast_009" },
			{ "Merlin_CutSceneST27_ev01", "Myhome" },
			{ "Merlin_CutSceneST27_ev02", "darkforest_008" },
			{ "Merlin_CutSceneST27_ev03", "darkforest_006" },
			{ "Merlin_CutSceneST27_ev04", "darkforest_006" },
			{ "Merlin_CutSceneST28_ev01", "Myhome" },
			{ "Merlin_CutSceneST28_ev02", "tower_000" },
			{ "Merlin_CutSceneST28_ev03", "tower_004" },
			{ "Merlin_CutSceneST28_ev04", "tower_004" },
			{ "Merlin_CutSceneST28_ev05", "tower_010" },
			{ "Merlin_CutSceneST28_ev06", "tower_010" },
			{ "Merlin_CutSceneST28_ev07", "tower_013" },
			{ "Merlin_CutSceneST29_ev01", "Myhome" },
			{ "Merlin_CutSceneST29_ev02", "darksanctuary_009" },
			{ "Merlin_CutSceneST29_ev03", "darksanctuary_009" },
			{ "Merlin_CutSceneST29_ev04", "Town" },
			{ "Merlin_CutSceneSS010104_ev01", "Town" },
			{ "Merlin_CutSceneSS010104_ev02", "cave_002" },
			{ "Merlin_CutSceneSS010206_ev01", "Town" },
			{ "Merlin_CutSceneSS010206_ev02", "desert_000" },
			{ "Merlin_CutSceneSS010308_ev01", "Town" },
			{ "Merlin_CutSceneSS010308_ev02", "volcano_000" },
			{ "Merlin_CutSceneSS010409_ev01", "Town" },
			{ "Merlin_CutSceneSS010409_ev02", "coast_000" },
			{ "Merlin_CutSceneSS010503_ev01", "Town" },
			{ "Merlin_CutSceneSS010503_ev02", "mountain_008" },
			{ "Merlin_CutSceneSS010617_ev01", "Town" },
			{ "Merlin_CutSceneSS010617_ev02", "tower_012" },
			{ "Merlin_CutSceneSS020104_ev01", "Town" },
			{ "Merlin_CutSceneSS020104_ev02", "Town" },
			{ "Merlin_CutSceneSS020104_ev03", "cave_005" },
			{ "Merlin_CutSceneSS020206_ev01", "Town" },
			{ "Merlin_CutSceneSS020206_ev02", "Town" },
			{ "Merlin_CutSceneSS020206_ev03", "desert_008" },
			{ "Merlin_CutSceneSS020303_ev01", "Town" },
			{ "Merlin_CutSceneSS020303_ev02", "Town" },
			{ "Merlin_CutSceneSS020303_ev03", "mountain_000" },
			{ "Merlin_CutSceneSS030105_ev01", "Town" },
			{ "Merlin_CutSceneSS030105_ev02", "forest_006" },
			{ "Merlin_CutSceneSS030206_ev01", "Town" },
			{ "Merlin_CutSceneSS030206_ev02", "desert_011" },
			{ "Merlin_CutSceneSS030310_ev01", "Town" },
			{ "Merlin_CutSceneSS030310_ev02", "snowfield_001" },
			{ "Merlin_CutSceneSS030407_ev01", "Town" },
			{ "Merlin_CutSceneSS030407_ev02", "temple_007" },
			{ "Merlin_CutSceneSS040105_ev01", "Town" },
			{ "Merlin_CutSceneSS040105_ev02", "Town" },
			{ "Merlin_CutSceneSS040105_ev03", "forest_012" },
			{ "Merlin_CutSceneSS040204_ev01", "Town" },
			{ "Merlin_CutSceneSS040204_ev02", "Town" },
			{ "Merlin_CutSceneSS040204_ev03", "cave_007" },
			{ "Merlin_CutSceneSS040308_ev01", "Town" },
			{ "Merlin_CutSceneSS040308_ev02", "Town" },
			{ "Merlin_CutSceneSS040308_ev03", "volcano_010" },
			{ "Merlin_CutSceneSS050103_ev01", "Town" },
			{ "Merlin_CutSceneSS050103_ev02", "Town" },
			{ "Merlin_CutSceneSS050103_ev03", "mountain_008" },
			{ "Merlin_CutSceneSS050209_ev01", "Town" },
			{ "Merlin_CutSceneSS050209_ev02", "Town" },
			{ "Merlin_CutSceneSS050209_ev03", "coast_000" },
			{ "Merlin_CutSceneSS050308_ev01", "Town" },
			{ "Merlin_CutSceneSS050308_ev02", "Town" },
			{ "Merlin_CutSceneSS050308_ev03", "volcano_000" },
			{ "Merlin_CutSceneSS060103_ev01", "Town" },
			{ "Merlin_CutSceneSS060103_ev02", "mountain_001" },
			{ "Merlin_CutSceneSS060208_ev01", "Town" },
			{ "Merlin_CutSceneSS060208_ev02", "volcano_000" },
			{ "Merlin_CutSceneSS060305_ev01", "Town" },
			{ "Merlin_CutSceneSS060305_ev02", "forest_010" },
			{ "Merlin_CutSceneSS060407_ev01", "Town" },
			{ "Merlin_CutSceneSS060407_ev02", "temple_008" },
			{ "Merlin_CutSceneSS070110_ev01", "Town" },
			{ "Merlin_CutSceneSS070110_ev02", "snowfield_008" },
			{ "Merlin_CutSceneSS080106_ev01", "Town" },
			{ "Merlin_CutSceneSS080106_ev02", "Town" },
			{ "Merlin_CutSceneSS080106_ev03", "desert_006" },
			{ "Merlin_CutSceneSS080205_ev01", "Town" },
			{ "Merlin_CutSceneSS080205_ev02", "Town" },
			{ "Merlin_CutSceneSS080205_ev03", "forest_000" },
			{ "Merlin_CutSceneSS090107_ev01", "Town" },
			{ "Merlin_CutSceneSS090107_ev02", "temple_000" },
			{ "Merlin_CutSceneSS090107_ev03", "temple_000" },
			{ "Merlin_CutSceneSS100104_ev01", "Town" },
			{ "Merlin_CutSceneSS100104_ev02", "Town" },
			{ "Merlin_CutSceneSS100104_ev03", "cave_000" },
			{ "Merlin_CutSceneSS100104_ev04", "cave_000" },
			{ "Merlin_CutSceneSS110107_ev01", "Town" },
			{ "Merlin_CutSceneSS110107_ev02", "Town" },
			{ "Merlin_CutSceneSS110107_ev03", "temple_000" },
			{ "Merlin_CutSceneSS110107_ev04", "temple_003" },
			{ "Merlin_CutSceneSS110107_ev05", "temple_003" },
			{ "Merlin_CutSceneSS120105_ev01", "Town" },
			{ "Merlin_CutSceneSS120105_ev02", "forest_002" },
			{ "Merlin_CutSceneSS120205_ev01", "Town" },
			{ "Merlin_CutSceneSS120205_ev02", "forest_002" },
			{ "Merlin_CutSceneSS120304_ev01", "Town" },
			{ "Merlin_CutSceneSS120304_ev02", "cave_002" },
			{ "Merlin_CutSceneSS130104_ev01", "Town" },
			{ "Merlin_CutSceneSS130104_ev02", "Town" },
			{ "Merlin_CutSceneSS130104_ev03", "cave_000" },
			{ "Merlin_CutSceneSS990105_ev01", "Myhome" },
			{ "Merlin_CutSceneSS990105_ev02", "Town" },
			{ "Merlin_CutSceneSS990105_ev03", "forest_000" },
			{ "Merlin_CutSceneSS990206_ev02", "Town" },
			{ "Merlin_CutSceneSS990206_ev03", "Town" },
			{ "Merlin_CutSceneSS990206_ev04", "desert_006" },
			{ "Merlin_CutSceneSS990303_ev02", "Town" },
			{ "Merlin_CutSceneSS990303_ev03", "Town" },
			{ "Merlin_CutSceneSS990303_ev04", "mountain_000" },
			{ "Merlin_CutSceneSS990407_ev02", "Town" },
			{ "Merlin_CutSceneSS990407_ev03", "temple_014" },
			{ "Merlin_CutSceneSS140114_ev01", "Town" },
			{ "Merlin_CutSceneSS140114_ev02", "icecave_009" },
			{ "Merlin_CutSceneSS140210_ev01", "Town" },
			{ "Merlin_CutSceneSS140210_ev02", "snowfield_008" },
			{ "Merlin_CutSceneSS140317_ev01", "Town" },
			{ "Merlin_CutSceneSS140317_ev02", "tower_008" },
			{ "Merlin_CutSceneSS150114_ev01", "Town" },
			{ "Merlin_CutSceneSS150114_ev02", "Town" },
			{ "Merlin_CutSceneSS150114_ev03", "icecave_001" },
			{ "Merlin_CutSceneSS150216_ev01", "Town" },
			{ "Merlin_CutSceneSS150216_ev02", "Town" },
			{ "Merlin_CutSceneSS150216_ev03", "darkforest_000" },
			{ "Merlin_CutSceneSS160105_ev01", "Town" },
			{ "Merlin_CutSceneSS160105_ev02", "Town" },
			{ "Merlin_CutSceneSS160105_ev03", "forest_012" },
			{ "Merlin_CutSceneSS170105_ev01", "Town" },
			{ "Merlin_CutSceneSS170105_ev02", "forest_000" },
			{ "Merlin_CutSceneSS170215_ev01", "Town" },
			{ "Merlin_CutSceneSS170215_ev02", "flamevalley_003" },
			{ "Merlin_CutSceneSS180115_ev01", "Town" },
			{ "Merlin_CutSceneSS180115_ev02", "flamevalley_006" },
			{ "Merlin_CutSceneSS180210_ev01", "Town" },
			{ "Merlin_CutSceneSS180210_ev02", "snowfield_000" },
			{ "Merlin_CutSceneSS190109_ev01", "Town" },
			{ "Merlin_CutSceneSS190109_ev02", "coast_000" },
			{ "Merlin_CutSceneSS200109_ev01", "Town" },
			{ "Merlin_CutSceneSS200109_ev02", "Town" },
			{ "Merlin_CutSceneSS200109_ev03", "coast_000" },
			{ "Merlin_CutSceneSS210116_ev01", "Town" },
			{ "Merlin_CutSceneSS210116_ev02", "Town" },
			{ "Merlin_CutSceneSS210116_ev03", "darkforest_008" },
			{ "Merlin_CutSceneBE5001_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5001_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5003_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5003_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5015_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5015_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5016_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5016_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5017_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5017_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5018_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5018_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5023_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5023_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5024_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5024_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5025_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5025_02", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5027_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5028_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5030_01", "Ui_DiscoverBoss" },
			{ "Merlin_CutSceneBE5031_01", "Ui_DiscoverBoss" }
		};
		MOBILE_MOTVIEWER_SCENE_FILTER = new string[41][]
		{
			new string[2] { "01", "ST[02]1" },
			new string[2] { "02", "ST[02]2" },
			new string[2] { "03", "ST[02]3" },
			new string[2] { "04", "ST[02]4" },
			new string[2] { "05", "ST[02]5" },
			new string[2] { "06", "ST[02]6" },
			new string[2] { "07", "ST[02]7" },
			new string[2] { "08", "ST[02]8" },
			new string[2] { "09", "ST[02]9" },
			new string[2] { "10", "ST[13]0" },
			new string[2] { "11", "ST[13]1" },
			new string[2] { "12", "ST[13]2" },
			new string[2] { "13", "ST[13]3" },
			new string[2] { "14", "ST[13]4" },
			new string[2] { "15", "ST[13]5" },
			new string[2] { "16", "ST[13]6" },
			new string[2] { "17", "ST[13]7" },
			new string[2] { "18", "ST[13]8" },
			new string[2] { "19", "ST[13]9" },
			new string[2] { "20", "ST[24]0" },
			new string[2] { "01", "SS01" },
			new string[2] { "02", "SS02" },
			new string[2] { "03", "SS03" },
			new string[2] { "04", "SS04" },
			new string[2] { "05", "SS05" },
			new string[2] { "06", "SS06" },
			new string[2] { "07", "SS07" },
			new string[2] { "08", "SS08" },
			new string[2] { "09", "SS09" },
			new string[2] { "10", "SS10" },
			new string[2] { "11", "SS11" },
			new string[2] { "12", "SS12" },
			new string[2] { "13", "SS13" },
			new string[2] { "14", "SS14" },
			new string[2] { "15", "SS15" },
			new string[2] { "16", "SS16" },
			new string[2] { "17", "SS17" },
			new string[2] { "18", "SS18" },
			new string[2] { "19", "SS19" },
			new string[2] { "99", "SS20|SS99" },
			new string[2]
			{
				"全部",
				string.Empty
			}
		};
		dispInformationFlag = true;
		currentCameraMotionName = string.Empty;
		currentCameraMotionFrame = string.Empty;
	}

	public void Update()
	{
		if ((bool)manager)
		{
			currentFrame = Time.time - startFrame;
		}
	}

	public void LateUpdate()
	{
		if ((bool)manager)
		{
			if (baisokuPressed())
			{
				manager.animSpeed = 3f;
			}
			if (choBaisokuPressed())
			{
				manager.animSpeed = 10f;
			}
			if (baisokuReleased())
			{
				manager.animSpeed = 1f;
			}
			if (hyperBaisokuPressed())
			{
				manager.animSpeed = 100f;
			}
			if (skipPressed())
			{
				manager.SKIP_TO_NEXT_TAG();
			}
			if (skip2Pressed())
			{
				manager.SKIP_TO_NEXT_MESSAGE();
			}
			string cameraMotionName;
			currentCameraMotionName = (string.IsNullOrEmpty(cameraMotionName = getCameraMotionName()) ? (_0024re_002424728.Split(currentCameraMotionName)[0] + " (end)") : cameraMotionName);
			string cameraMotionFrame;
			currentCameraMotionFrame = (string.IsNullOrEmpty(cameraMotionFrame = getCameraMotionFrame()) ? currentCameraMotionFrame : cameraMotionFrame);
		}
	}

	public void Start()
	{
		StartCoroutine(main());
	}

	private IEnumerator main()
	{
		return new _0024main_002424487(this).GetEnumerator();
	}

	public IEnumerator _storeOriginalGameObjects()
	{
		return new _0024_storeOriginalGameObjects_002424497(this).GetEnumerator();
	}

	public bool skipPressed()
	{
		return Input.GetKey(KeyCode.Return);
	}

	public bool skip2Pressed()
	{
		return Input.GetKey(KeyCode.A);
	}

	public bool baisokuPressed()
	{
		return Input.GetKey(KeyCode.RightAlt);
	}

	public bool choBaisokuPressed()
	{
		return Input.GetKey(KeyCode.Space);
	}

	public bool baisokuReleased()
	{
		bool keyUp = Input.GetKeyUp(KeyCode.Space);
		if (!keyUp)
		{
			keyUp = Input.GetKeyUp(KeyCode.RightAlt);
		}
		return keyUp;
	}

	public bool hyperBaisokuPressed()
	{
		bool key = Input.GetKey(KeyCode.Space);
		if (key)
		{
			key = Input.GetKey(KeyCode.RightAlt);
		}
		return key;
	}

	public bool hyperBaisokuReleased()
	{
		bool keyUp = Input.GetKeyUp(KeyCode.Space);
		if (!keyUp)
		{
			keyUp = Input.GetKeyUp(KeyCode.RightAlt);
		}
		return keyUp;
	}

	public void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height;
		GUILayout.BeginArea(new Rect(0f, 0f, width, height));
		if (modeStyle == null || filterStyle == null || listStyle == null)
		{
			initGUIStyles();
		}
		if (GUI.changed)
		{
			refreshList();
		}
		OnGUIMenuModeSwitch();
		if (menu_mode == MENU_MODE.select_scene)
		{
			OnGUISceneSelect();
		}
		if (menu_mode == MENU_MODE.control_scene)
		{
			OnGUISceneControl();
		}
		GUILayout.EndArea();
		if ((bool)manager && dispInformationFlag)
		{
			dispTimeCode();
		}
	}

	public void dispTimeCode()
	{
		int num = checked((int)((double)Screen.width / 1.5));
		int num2 = Screen.height / 8;
		checked
		{
			GUILayout.BeginArea(new Rect(unchecked(Screen.width / 2) - unchecked(num / 2), Screen.height - num2, num, num2));
			string empty = string.Empty;
			empty = new StringBuilder().Append(empty).Append("カメラ名:\t").Append(currentCameraMotionName)
				.Append("\n")
				.ToString();
			empty = new StringBuilder().Append(empty).Append("カメラ:\t").Append(currentCameraMotionFrame)
				.Append("\n")
				.ToString();
			empty = new StringBuilder().Append(empty).Append("Time:\t").Append((currentFrame * 30f).ToString("0.0"))
				.Append("\n")
				.ToString();
			empty = new StringBuilder().Append(empty).Append("再生速度:\t").Append(manager.animSpeed)
				.Append("\n")
				.ToString();
			int fontSize = GUI.skin.box.fontSize;
			if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
			{
				GUI.skin.box.fontSize = 13;
			}
			else
			{
				GUI.skin.box.fontSize = 23;
			}
			GUI.Box(new Rect(0f, 0f, num, num2), empty);
			GUILayout.EndArea();
			GUI.skin.box.fontSize = fontSize;
		}
	}

	public void OnGUIMenuModeSwitch()
	{
		current_mode = GUILayout.Toolbar(current_mode, mode_toolbar_label, modeStyle);
		if (GUI.changed)
		{
			switchMode((MENU_MODE)current_mode);
		}
	}

	public void initGUIStyles()
	{
		modeStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		modeStyle.alignment = TextAnchor.MiddleCenter;
		modeStyle.margin = new RectOffset(13, 13, 20, 5);
		modeStyle.fontSize = 40;
		filterStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		filterStyle.alignment = TextAnchor.MiddleCenter;
		filterStyle.margin = new RectOffset(13, 15, 5, 5);
		filterStyle.fontSize = 32;
		listStyle = new GUIStyle(GUI.skin.GetStyle("Button"));
		listStyle.alignment = TextAnchor.LowerLeft;
		listStyle.margin = new RectOffset(13, 3, 10, 5);
		listStyle.padding = new RectOffset(33, 3, 10, 5);
		listStyle.fontSize = 32;
	}

	public void _onGUIFilter(string[][] buttons, ICallable filterFunc)
	{
		object obj = originalObjects;
		if (obj != null)
		{
			obj = originalObjects.Length > 0;
		}
		GUI.enabled = RuntimeServices.UnboxBoolean(obj);
		GUILayout.BeginHorizontal();
		IEnumerator<object[]> enumerator = Builtins.enumerate(buttons).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object[] current = enumerator.Current;
				int num = RuntimeServices.UnboxInt32(current[0]);
				object obj2 = current[1];
				if (!(obj2 is string[]))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string[]));
				}
				string[] array = (string[])obj2;
				if (num > 0 && num % 10 == 0)
				{
					GUILayout.EndHorizontal();
					GUILayout.BeginHorizontal();
				}
				if (GUILayout.Button(array[0] as string, filterStyle))
				{
					filterFunc.Call(new object[1] { array[1] as string });
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		GUILayout.EndHorizontal();
		GUI.enabled = true;
	}

	public void _onGUIList(List filterdList, ICallable callbackFunc)
	{
		if (filterdList == null)
		{
			return;
		}
		int num = cursor;
		object obj = originalObjects;
		if (obj != null)
		{
			obj = originalObjects.Length > 0;
		}
		GUI.enabled = RuntimeServices.UnboxBoolean(obj);
		scroll = GUILayout.BeginScrollView(scroll);
		string[] texts = (string[])Builtins.array(typeof(string), filterdList);
		cursor = GUILayout.SelectionGrid(cursor, texts, 1, listStyle);
		GUILayout.EndScrollView();
		GUI.enabled = true;
		if (GUI.changed && num != cursor)
		{
			object obj2 = callbackFunc.Call(new object[1] { filterdList[cursor] });
			if (!(obj2 is IEnumerator))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(IEnumerator));
			}
			StartCoroutine((IEnumerator)obj2);
			cursor = -1;
		}
	}

	public void OnGUISceneSelect()
	{
		__PlayerControl_loadMotionPack_0024callable170_00241237_13__ callbackFunc = (string name) => new _0024_0024OnGUISceneSelect_0024_changeScene_00246558_002424545(name, this).GetEnumerator();
		if (filterdScenes != null)
		{
			_onGUIFilter(MOBILE_MOTVIEWER_SCENE_FILTER, new __Req_FailHandler_0024callable6_0024440_32__(filterScenes));
			_onGUIList(filterdScenes, callbackFunc);
		}
	}

	public void OnGUISceneControl()
	{
		int selected = -1;
		GUI.enabled = manager != null;
		selected = GUILayout.Toolbar(selected, new string[2] { "□>", "1コマ>>" }, modeStyle);
		if (GUI.changed && (bool)manager)
		{
			switch (selected)
			{
			case 0:
				manager.pause = !manager.pause;
				if (!manager.pause)
				{
					manager.animSpeed = 1f;
				}
				else
				{
					manager.animSpeed = 0f;
				}
				break;
			case 1:
				manager.stepPlay = !manager.stepPlay;
				break;
			}
		}
		int selected2 = -1;
		selected2 = GUILayout.Toolbar(selected2, new string[3] { "<<", "1.0倍", ">>" }, modeStyle);
		if (GUI.changed && (bool)manager)
		{
			switch (selected2)
			{
			case 0:
				manager.animSpeed = (float)((double)manager.animSpeed - 0.25);
				break;
			case 1:
				manager.animSpeed = 1f;
				break;
			case 2:
				manager.animSpeed = (float)((double)manager.animSpeed + 0.25);
				break;
			}
		}
		int selected3 = -1;
		selected3 = GUILayout.Toolbar(selected3, new string[1] { "情報表示" }, modeStyle);
		if (GUI.changed && (bool)manager && selected3 == 0)
		{
			dispInformationFlag = !dispInformationFlag;
		}
		GUI.enabled = true;
	}

	public void switchMode(MENU_MODE to)
	{
		if (to == MENU_MODE.menu && (bool)manager)
		{
			CutSceneManager.Abort();
			manager = null;
		}
		cursor = -1;
		scroll = new Vector2(0f, 0f);
		if (menu_mode == to)
		{
			menu_mode = (MENU_MODE)(-1);
		}
		else
		{
			menu_mode = to;
		}
	}

	public void toggleDebugMenu()
	{
	}

	public void switchDebugMenu(bool flag)
	{
	}

	public List listFilter(List l)
	{
		_0024listFilter_0024locals_002414576 _0024listFilter_0024locals_0024 = new _0024listFilter_0024locals_002414576();
		_0024listFilter_0024locals_0024._0024l = l;
		int i = 0;
		string[] array = _0024re_002424729.Split(listFilterStrings);
		List list = default(List);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024listFilter_0024locals_0024._0024r = new Regex(array[i], RegexOptions.IgnoreCase);
			list = new List(new _0024listFilter_002424502(_0024listFilter_0024locals_0024));
		}
		return (list != null) ? list : _0024listFilter_0024locals_0024._0024l;
	}

	public List findAllscenes()
	{
		return new List(new _0024findAllscenes_002424505());
	}

	public void filterScenes(string filter)
	{
		listFilterStrings = filter;
		filterScenes();
	}

	public void filterScenes()
	{
		filterdScenes = listFilter(scenes);
	}

	public IEnumerator changeScene(string name)
	{
		return new _0024changeScene_002424506(name, this).GetEnumerator();
	}

	public void destroyBeforeChangeScene()
	{
		_0024destroyBeforeChangeScene_0024locals_002414577 _0024destroyBeforeChangeScene_0024locals_0024 = new _0024destroyBeforeChangeScene_0024locals_002414577();
		_0024destroyBeforeChangeScene_0024locals_0024._0024all = (Transform[])UnityEngine.Object.FindObjectsOfType(typeof(Transform));
		List source = new List(new _0024destroyBeforeChangeScene_002424517(this, _0024destroyBeforeChangeScene_0024locals_0024));
		IEnumerator<object> enumerator = source.Distinct().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (!isViewerSceneObject(transform))
				{
					Debug.LogWarning(new StringBuilder("clear scene obj: ").Append(transform).Append("\n").ToString());
					transform.parent = null;
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void destroyAfterLoadStage(string stageName)
	{
		List source = new List(new _0024destroyAfterLoadStage_002424522());
		IEnumerator<object> enumerator = source.Distinct().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				Debug.LogWarning(new StringBuilder().Append(transform).Append(" is stage object?").ToString());
				if (!isStageObj(stageName, transform.gameObject))
				{
					Debug.LogWarning(new StringBuilder("clear bg obj: ").Append(transform).Append("\n").ToString());
					transform.parent = null;
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		DiscoverBossMain discoverBossMain = ((DiscoverBossMain)UnityEngine.Object.FindObjectOfType(typeof(DiscoverBossMain))) as DiscoverBossMain;
		if (discoverBossMain != null)
		{
			UnityEngine.Object.DestroyImmediate(discoverBossMain);
			GameObject gameObject = GameObject.Find("__MerlinServer__");
			if ((bool)gameObject)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
		}
	}

	public bool isViewerSceneObject(Transform t)
	{
		List rhs = new List(new object[9] { "Finger Gestures", "TouchScreen Gestures", "Mouse Gestures", "Camera", "Fader", "DebugMode", "__AssetBundleLoader__", "Fader(Clone)", "CutSceneManager" }, takeOwnership: true);
		return RuntimeServices.op_Member(t, originalObjects) || RuntimeServices.op_Member(new __DebugSubModeMaster_createDatamainMode_0024callable15_002441_44__(t.GetInstanceID), originalObjectsIDs) || RuntimeServices.op_Member(t.name.Replace("(Clone)", string.Empty), originalObjectsTexts) || (RuntimeServices.op_Member(t.name, rhs) ? true : false);
	}

	public bool isStageObj(string stageName, GameObject target)
	{
		string text = target.name;
		string[] rhs = (string[])RuntimeServices.AddArrays(typeof(string), new string[22]
		{
			"_Characters", "_MotionViewer", "_Stage", "Finger Gestures", "TouchScreen Gestures", "Mouse Gestures", "Camera", "Main Camera", "Fader", "Fader(Clone)",
			"terrain", "Terrain", "DebugMode", "__AssetBundleLoader__", "Collision", "Collisions", "FloorCollision", "__CutSceneManager__", "C0000_000_MA_ROOT", "C0000_000_MA_ROOT(Clone)",
			"Plane", "Ui_DiscoverBoss"
		}, originalObjectsTexts);
		string lhs = text.Replace("_", string.Empty).ToLower();
		string rhs2 = stageName.Replace("_", string.Empty).ToLower();
		string rhs3 = _0024re_002424730.Split(stageName.ToLower())[0] + "_lightset";
		bool flag;
		try
		{
			if (text.StartsWith(ScenePackerMixin.PrefabName(stageName)))
			{
				flag = true;
				goto IL_031d;
			}
		}
		catch (Exception)
		{
		}
		int result = text switch
		{
			"__SceneChanger__" => 0, 
			"__QuestAssets__" => 0, 
			"Myhome" => 1, 
			"Town" => 1, 
			_ => text.StartsWith("PKSCN_") ? 1 : ((!hasComponent(target, typeof(QuestInitializer))) ? ((!hasComponent(target, typeof(QuestManager))) ? ((!hasComponent(target, typeof(GameLevelManager))) ? ((!(text == "QuestInitializer")) ? ((text.ToLower() == "map") ? 1 : ((text == "CastShadowLight") ? 1 : ((text == "SceneLightTable") ? 1 : (RuntimeServices.op_Member("Ef_SmokeColorData", text) ? 1 : (RuntimeServices.op_Member("Ef_Map", text) ? 1 : (RuntimeServices.op_Member("GAIA", text) ? 1 : (RuntimeServices.op_Member("Camera", text) ? 1 : (RuntimeServices.op_Member(text, rhs) ? 1 : (RuntimeServices.op_Member(lhs, rhs2) ? 1 : (RuntimeServices.op_Member(text.ToLower(), rhs3) ? 1 : (RuntimeServices.op_Member(lhs, rhs3) ? 1 : 0))))))))))) : 0) : 0) : 0) : 0), 
		};
		goto IL_031f;
		IL_031d:
		result = (flag ? 1 : 0);
		goto IL_031f;
		IL_031f:
		return (byte)result != 0;
	}

	public bool hasComponent(GameObject target, Type t)
	{
		Component componentInChildren = target.GetComponentInChildren(t);
		return componentInChildren ? true : false;
	}

	public void loadStage(string name)
	{
		IEnumerator enumerator = _loadStage(name);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator _loadStage(string sceneName)
	{
		return new _0024_loadStage_002424523(sceneName, this).GetEnumerator();
	}

	public IEnumerator _loadSceneIdStage(SceneID sceneID)
	{
		return new _0024_loadSceneIdStage_002424531(sceneID, this).GetEnumerator();
	}

	public IEnumerator _loadAssetBundleSceneStage(string sceneName)
	{
		return new _0024_loadAssetBundleSceneStage_002424537(sceneName, this).GetEnumerator();
	}

	public void refreshList()
	{
		filterScenes(string.Empty);
	}

	public string getCameraMotionName()
	{
		if (!cam)
		{
			cam = searchCutsceneCamera();
		}
		return (!cam || !cam.animation) ? null : cam.animation.clip.name;
	}

	public string getCameraMotionFrame()
	{
		if (!cam)
		{
			cam = searchCutsceneCamera();
		}
		object result;
		if ((bool)cam && (bool)cam.animation)
		{
			AnimationClip clip = cam.animation.clip;
			AnimationState animationState = cam.animation[clip.name];
			string text = new StringBuilder().Append((animationState.time * 30f).ToString("00.0")).Append("フレーム  ").Append((animationState.time * 1000f).ToString("000,000"))
				.Append("秒\n")
				.ToString();
			result = text;
		}
		else
		{
			result = null;
		}
		return (string)result;
	}

	public GameObject searchCutsceneCamera()
	{
		GameObject gameObject = GameObject.Find("CutSceneCameraRoot") as GameObject;
		if (!gameObject)
		{
			gameObject = GameObject.Find("CutSceneCameraRoot" + "(Clone)") as GameObject;
		}
		return gameObject;
	}

	internal IEnumerator _0024OnGUISceneSelect_0024_changeScene_00246558(string name)
	{
		return new _0024_0024OnGUISceneSelect_0024_changeScene_00246558_002424545(name, this).GetEnumerator();
	}
}
