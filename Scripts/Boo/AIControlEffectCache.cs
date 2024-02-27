using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class AIControlEffectCache : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024cacheChainEffectRoutine_002416643 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespPoppet _0024pd_002416644;

			internal MChainSkills _0024cskill_002416645;

			internal string _0024prefabPath_002416646;

			internal RuntimeAssetBundleDB.Req _0024r_002416647;

			internal AIControlEffectCache _0024self__002416648;

			public _0024(AIControlEffectCache self_)
			{
				_0024self__002416648 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002416648.ai.HasPoppetData || _0024self__002416648.isStartedCaching)
					{
						goto case 1;
					}
					_0024self__002416648.healHitEffect = (GameObject)GameAssetModule.LoadPrefab("Prefab/Effect/Ef_ContinueAttack_ChainBuff_RES");
					_0024pd_002416644 = _0024self__002416648.ai.PoppetData;
					_0024cskill_002416645 = _0024pd_002416644.ChainSkill;
					if (_0024cskill_002416645 != null && !string.IsNullOrEmpty(_0024cskill_002416645.EffectPrefab))
					{
						_0024prefabPath_002416646 = _0024cskill_002416645.EffectPrefab;
						_0024r_002416647 = RuntimeAssetBundleDB.Instance.loadPrefab(_0024prefabPath_002416646);
						goto case 2;
					}
					goto IL_011f;
				case 2:
					if (!_0024r_002416647.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024r_002416647.IsOk)
					{
						_0024self__002416648.chainEffect = (GameObject)_0024r_002416647.Asset;
					}
					goto IL_011f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_011f:
					_0024self__002416648.isStartedCaching = true;
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AIControlEffectCache _0024self__002416649;

		public _0024cacheChainEffectRoutine_002416643(AIControlEffectCache self_)
		{
			_0024self__002416649 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416649);
		}
	}

	[NonSerialized]
	private const string HEAL_HIT_EFFECT_PATH = "Prefab/Effect/Ef_ContinueAttack_ChainBuff_RES";

	private GameObject chainEffect;

	private GameObject healHitEffect;

	private bool isStartedCaching;

	private AIControl ai;

	public GameObject ChainEffect => chainEffect;

	public GameObject HealHitEffect => healHitEffect;

	public bool IsStartedCaching => isStartedCaching;

	public void Awake()
	{
		ai = gameObject.GetComponent<AIControl>();
	}

	public void OnDestroy()
	{
		ai = null;
		chainEffect = null;
		healHitEffect = null;
	}

	public void startCacheChainEffect()
	{
		IEnumerator enumerator = cacheChainEffectRoutine();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator cacheChainEffectRoutine()
	{
		return new _0024cacheChainEffectRoutine_002416643(this).GetEnumerator();
	}
}
