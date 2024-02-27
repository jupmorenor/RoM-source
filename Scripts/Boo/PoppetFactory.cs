using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PoppetFactory : MonoBehaviour
{
	[Serializable]
	public class CreatedPoppets
	{
		public AIControl myPoppet;

		public AIControl friendPoppet;

		public RespPoppet myPoppetSource;

		public RespPoppet friendPoppetSource;
	}

	[Serializable]
	public class PoppetParam
	{
		public RespPoppet myPoppet;

		public RespPoppet friendPoppet;

		public string myPoppetObjName;

		public string friendPoppetObjName;

		public bool IsMyPoppetValid
		{
			get
			{
				bool num = myPoppet != null;
				if (num)
				{
					num = myPoppet.IsValidMaster;
				}
				return num;
			}
		}

		public bool IsFriendPoppetValid
		{
			get
			{
				bool num = friendPoppet != null;
				if (num)
				{
					num = friendPoppet.IsValidMaster;
				}
				return num;
			}
		}

		public PoppetParam()
		{
			defaultInit();
		}

		public void defaultInit()
		{
			UserData current = UserData.Current;
			if (current.IsValidDeck2 && current.CurrentDeck2 != null)
			{
				myPoppet = current.CurrentDeck2.MainPoppet;
			}
			else if (current.IsCurrentPoppetValid)
			{
				myPoppet = current.CurrentPoppet;
			}
			else
			{
				myPoppet = new RespPoppet(1);
			}
			myPoppetObjName = MGameObjectNames.ObjectName(EnumGameObjectNames.PlayerPoppet);
			friendPoppetObjName = MGameObjectNames.ObjectName(EnumGameObjectNames.FriendPoppet);
		}
	}

	[Serializable]
	internal class _0024createPoppetObj_0024locals_002414350
	{
		internal __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ _0024handler;
	}

	[Serializable]
	internal class _0024poppetsCreationRoutine_0024locals_002414351
	{
		internal AIControl _0024ai;
	}

	[Serializable]
	internal class _0024createPoppetObj_0024closure_00242996
	{
		internal _0024createPoppetObj_0024locals_002414350 _0024_0024locals_002414802;

		public _0024createPoppetObj_0024closure_00242996(_0024createPoppetObj_0024locals_002414350 _0024_0024locals_002414802)
		{
			this._0024_0024locals_002414802 = _0024_0024locals_002414802;
		}

		public void Invoke(GameObject go)
		{
			AIControl component = go.GetComponent<AIControl>();
			if (!(component != null))
			{
				throw new AssertionFailedException("ai != null");
			}
			if (_0024_0024locals_002414802._0024handler != null)
			{
				_0024_0024locals_002414802._0024handler(component);
			}
		}
	}

	[Serializable]
	internal class _0024poppetsCreationRoutine_0024closure_00242997
	{
		internal _0024poppetsCreationRoutine_0024locals_002414351 _0024_0024locals_002414803;

		public _0024poppetsCreationRoutine_0024closure_00242997(_0024poppetsCreationRoutine_0024locals_002414351 _0024_0024locals_002414803)
		{
			this._0024_0024locals_002414803 = _0024_0024locals_002414803;
		}

		public void Invoke(AIControl _ai)
		{
			_0024_0024locals_002414803._0024ai = _ai;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024questPoppetsCreationRoutine_002416837 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal PoppetParam _0024param_002416838;

			internal IEnumerator _0024_0024sco_0024temp_00241249_002416839;

			internal CreatedPoppets _0024result_002416840;

			internal RespPoppet _0024friendPoppet_002416841;

			internal PoppetFactory _0024self__002416842;

			public _0024(RespPoppet friendPoppet, PoppetFactory self_)
			{
				_0024friendPoppet_002416841 = friendPoppet;
				_0024self__002416842 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024friendPoppet_002416841 == null)
					{
					}
					_0024param_002416838 = new PoppetParam();
					_0024param_002416838.friendPoppet = _0024friendPoppet_002416841;
					_0024_0024sco_0024temp_00241249_002416839 = _0024self__002416842.poppetsCreationRoutine(_0024param_002416838);
					if (_0024_0024sco_0024temp_00241249_002416839 != null)
					{
						result = (Yield(2, _0024self__002416842.StartCoroutine(_0024_0024sco_0024temp_00241249_002416839)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024result_002416840 = _0024self__002416842.CreationResult;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RespPoppet _0024friendPoppet_002416843;

		internal PoppetFactory _0024self__002416844;

		public _0024questPoppetsCreationRoutine_002416837(RespPoppet friendPoppet, PoppetFactory self_)
		{
			_0024friendPoppet_002416843 = friendPoppet;
			_0024self__002416844 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024friendPoppet_002416843, _0024self__002416844);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024townPoppetCreationRoutine_002416845 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal PoppetParam _0024param_002416846;

			internal IEnumerator _0024_0024sco_0024temp_00241250_002416847;

			internal CreatedPoppets _0024result_002416848;

			internal PoppetFactory _0024self__002416849;

			public _0024(PoppetFactory self_)
			{
				_0024self__002416849 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024param_002416846 = new PoppetParam();
					_0024_0024sco_0024temp_00241250_002416847 = _0024self__002416849.poppetsCreationRoutine(_0024param_002416846);
					if (_0024_0024sco_0024temp_00241250_002416847 != null)
					{
						result = (Yield(2, _0024self__002416849.StartCoroutine(_0024_0024sco_0024temp_00241250_002416847)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024result_002416848 = _0024self__002416849.CreationResult;
					if (_0024result_002416848 == null || !(_0024result_002416848.myPoppet != null))
					{
						throw new AssertionFailedException("could not create poppet for town");
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

		internal PoppetFactory _0024self__002416850;

		public _0024townPoppetCreationRoutine_002416845(PoppetFactory self_)
		{
			_0024self__002416850 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416850);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024poppetsCreationRoutine_002416851 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CreatedPoppets _0024result_002416852;

			internal PlayerPoppetCache _0024ppc_002416853;

			internal RuntimeAssetBundleDB.Req _0024req_002416854;

			internal GameObject _0024obj_002416855;

			internal _0024poppetsCreationRoutine_0024locals_002414351 _0024_0024locals_002416856;

			internal PoppetParam _0024param_002416857;

			internal PoppetFactory _0024self__002416858;

			public _0024(PoppetParam param, PoppetFactory self_)
			{
				_0024param_002416857 = param;
				_0024self__002416858 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416856 = new _0024poppetsCreationRoutine_0024locals_002414351();
					_0024result_002416852 = new CreatedPoppets();
					_0024self__002416858.creationResult = _0024result_002416852;
					if (_0024param_002416857.IsMyPoppetValid)
					{
						_0024ppc_002416853 = PlayerPoppetCache.Instance;
						_0024_0024locals_002416856._0024ai = null;
						_0024ppc_002416853.getPoppet(_0024param_002416857.myPoppet, new _0024poppetsCreationRoutine_0024closure_00242997(_0024_0024locals_002416856).Invoke);
						goto case 2;
					}
					goto IL_0108;
				case 2:
					if (!(_0024_0024locals_002416856._0024ai != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024result_002416852.myPoppet = InitAPoppet(_0024_0024locals_002416856._0024ai.gameObject, _0024param_002416857.myPoppetObjName, _0024param_002416857.myPoppet);
					_0024result_002416852.myPoppetSource = _0024param_002416857.myPoppet;
					goto IL_0108;
				case 3:
					if (!_0024req_002416854.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (!_0024req_002416854.IsOk)
					{
						throw new AssertionFailedException(new StringBuilder("could not load ").Append(_0024req_002416854.PrefabName).ToString());
					}
					_0024obj_002416855 = ((GameObject)UnityEngine.Object.Instantiate(_0024req_002416854.Prefab, Vector3.zero, Quaternion.identity)) as GameObject;
					if (!(_0024obj_002416855 != null))
					{
						throw new AssertionFailedException("obj != null");
					}
					_0024result_002416852.friendPoppet = InitAPoppet(_0024obj_002416855, _0024param_002416857.friendPoppetObjName, _0024param_002416857.friendPoppet);
					_0024result_002416852.friendPoppetSource = _0024param_002416857.friendPoppet;
					goto IL_0212;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0212:
					if (_0024param_002416857.IsMyPoppetValid || !_0024param_002416857.IsFriendPoppetValid)
					{
					}
					YieldDefault(1);
					goto case 1;
					IL_0108:
					if (_0024param_002416857.IsFriendPoppetValid)
					{
						_0024req_002416854 = _0024self__002416858.reqCreateAPoppet(_0024param_002416857.friendPoppet);
						goto case 3;
					}
					goto IL_0212;
				}
				return (byte)result != 0;
			}
		}

		internal PoppetParam _0024param_002416859;

		internal PoppetFactory _0024self__002416860;

		public _0024poppetsCreationRoutine_002416851(PoppetParam param, PoppetFactory self_)
		{
			_0024param_002416859 = param;
			_0024self__002416860 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024param_002416859, _0024self__002416860);
		}
	}

	[NonSerialized]
	private static PoppetFactory _instance;

	private CreatedPoppets creationResult;

	public static PoppetFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject component = AssetBundleLoader.Instance.gameObject;
				_instance = ExtensionsModule.SetComponent<PoppetFactory>(component);
				if (!(_instance != null))
				{
					throw new AssertionFailedException("_instance != null");
				}
			}
			return _instance;
		}
	}

	public CreatedPoppets CreationResult => creationResult;

	public IEnumerator questPoppetsCreationRoutine(RespPoppet friendPoppet)
	{
		return new _0024questPoppetsCreationRoutine_002416837(friendPoppet, this).GetEnumerator();
	}

	public IEnumerator townPoppetCreationRoutine()
	{
		return new _0024townPoppetCreationRoutine_002416845(this).GetEnumerator();
	}

	public void createPoppetObj(RespPoppet poppet, __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ handler)
	{
		_0024createPoppetObj_0024locals_002414350 _0024createPoppetObj_0024locals_0024 = new _0024createPoppetObj_0024locals_002414350();
		_0024createPoppetObj_0024locals_0024._0024handler = handler;
		if (poppet == null)
		{
			throw new AssertionFailedException("poppet != null");
		}
		MPoppets master = poppet.Master;
		if (master == null)
		{
			throw new AssertionFailedException("mst != null");
		}
		RuntimeAssetBundleDB.Instance.instantiatePrefab(master.PrefabName, new _0024createPoppetObj_0024closure_00242996(_0024createPoppetObj_0024locals_0024).Invoke);
	}

	private IEnumerator poppetsCreationRoutine(PoppetParam param)
	{
		return new _0024poppetsCreationRoutine_002416851(param, this).GetEnumerator();
	}

	private RuntimeAssetBundleDB.Req reqCreateAPoppet(RespPoppet ppt)
	{
		if (ppt == null)
		{
			throw new AssertionFailedException("ppt != null");
		}
		MPoppets master = ppt.Master;
		return RuntimeAssetBundleDB.Instance.loadPrefab(master.PrefabName);
	}

	private static AIControl InitAPoppet(GameObject obj, string objName, RespPoppet ppt)
	{
		if (!(obj != null))
		{
			throw new AssertionFailedException("obj != null");
		}
		if (ppt == null)
		{
			throw new AssertionFailedException("ppt != null");
		}
		MPoppets master = ppt.Master;
		obj.name = ((!string.IsNullOrEmpty(objName)) ? objName : master.PrefabName);
		AIControl component = obj.GetComponent<AIControl>();
		component.PoppetData = ppt;
		component.AIMODE_ChasePlayer();
		component.setHitPointAndHitPointMax(ppt.TotalHP);
		MapetSpeak component2 = obj.GetComponent<MapetSpeak>();
		if ((bool)component2)
		{
			component2.Poppet = master;
		}
		MagicSkill component3 = obj.GetComponent<MagicSkill>();
		if (component3 != null)
		{
			component3.MaxMagicPoint = ppt.RequiredMagicPoint;
			component3.zeroMagicPoint();
		}
		return component;
	}
}
