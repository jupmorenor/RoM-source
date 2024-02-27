using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using ObjUtil;
using UnityEngine;

[Serializable]
public class EnvironmentSoundGenerator : MonoBehaviour
{
	[Serializable]
	public enum SoundDumpMode
	{
		linear,
		quadratic,
		cubic
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_playSE_002419703 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241844_002419704;

			internal EnvironmentSoundGenerator _0024self__002419705;

			public _0024(EnvironmentSoundGenerator self_)
			{
				_0024self__002419705 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002419705.sndmgr || !_0024self__002419705.isReady)
					{
						goto case 1;
					}
					_0024self__002419705._stopSE();
					goto case 2;
				case 2:
					if (!_0024self__002419705.sndmgr.IsLoadSe((int)_0024self__002419705.se))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002419705.seID = _0024self__002419705.sndmgr.PlaySe((int)_0024self__002419705.se, 0, _0024self__002419705.gameObject.GetInstanceID());
					_0024_0024sco_0024temp_00241844_002419704 = _0024self__002419705._setVolume(0f);
					if (_0024_0024sco_0024temp_00241844_002419704 != null)
					{
						_0024self__002419705.StartCoroutine(_0024_0024sco_0024temp_00241844_002419704);
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

		internal EnvironmentSoundGenerator _0024self__002419706;

		public _0024_playSE_002419703(EnvironmentSoundGenerator self_)
		{
			_0024self__002419706 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419706);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_setVolume_002419707 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241845_002419708;

			internal float _0024vol_002419709;

			internal float _0024v_002419710;

			internal EnvironmentSoundGenerator _0024self__002419711;

			public _0024(float v, EnvironmentSoundGenerator self_)
			{
				_0024v_002419710 = v;
				_0024self__002419711 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002419711.sndmgr)
					{
						goto case 1;
					}
					if (_0024self__002419711.seID == -1)
					{
						_0024_0024sco_0024temp_00241845_002419708 = _0024self__002419711._playSE();
						if (_0024_0024sco_0024temp_00241845_002419708 != null)
						{
							result = (Yield(2, _0024self__002419711.StartCoroutine(_0024_0024sco_0024temp_00241845_002419708)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
					_0024vol_002419709 = Mathf.Clamp(_0024v_002419710, 0f, 1f);
					_0024self__002419711.sndmgr.SetSeVoulme(_0024self__002419711.seID, _0024v_002419710);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024v_002419712;

		internal EnvironmentSoundGenerator _0024self__002419713;

		public _0024_setVolume_002419707(float v, EnvironmentSoundGenerator self_)
		{
			_0024v_002419712 = v;
			_0024self__002419713 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024v_002419712, _0024self__002419713);
		}
	}

	public SQEX_SoundPlayerData.BGM bgm;

	public SQEX_SoundPlayerData.SE se;

	public float fadeOut;

	private SphereCollider colli;

	private SQEX_SoundPlayer _sndmgr;

	private int seID;

	private bool isPlaying;

	public SoundDumpMode 減衰モード;

	public float 減衰力;

	private PlayerControl pc;

	private GameObject pcgo;

	public float dist;

	private float baseDist;

	private SQEX_SoundPlayer sndmgr
	{
		get
		{
			if (!_sndmgr)
			{
				_sndmgr = SQEX_SoundPlayer.Instance;
			}
			return (!_sndmgr) ? null : _sndmgr;
		}
	}

	private bool isReady
	{
		get
		{
			bool num = pcgo != null;
			if (num)
			{
				num = SceneChanger.isFadeOut;
			}
			return num;
		}
	}

	public SoundDumpMode dumpMode
	{
		get
		{
			return 減衰モード;
		}
		set
		{
			減衰モード = value;
		}
	}

	public float dumpRate
	{
		get
		{
			return 減衰力;
		}
		set
		{
			減衰力 = value;
		}
	}

	public EnvironmentSoundGenerator()
	{
		bgm = SQEX_SoundPlayerData.BGM.NONE;
		se = SQEX_SoundPlayerData.SE.NONE;
		fadeOut = 2000f;
		seID = -1;
		減衰モード = SoundDumpMode.quadratic;
		減衰力 = 1f;
	}

	public void Start()
	{
		colli = gameObject.GetComponent<SphereCollider>();
		baseDist = (transform.localScale.x + transform.localScale.z) / 2f * colli.radius;
		GameSoundManager.Instance.LoadSe((int)se);
	}

	public void OnDestroy()
	{
		if (seID != -1)
		{
			_stopSE();
			GameSoundManager.Instance.UnloadSe((int)se);
		}
	}

	private IEnumerator _playSE()
	{
		return new _0024_playSE_002419703(this).GetEnumerator();
	}

	private void _stopSE()
	{
		if ((bool)sndmgr)
		{
			sndmgr.StopSeById(seID, checked((int)fadeOut));
			seID = -1;
		}
	}

	private float getDist()
	{
		return ObjUtilModule.Distance(gameObject, pcgo);
	}

	private IEnumerator _setVolume(float v)
	{
		return new _0024_setVolume_002419707(v, this).GetEnumerator();
	}

	private void _dump()
	{
		dist = getDist();
		float v = default(float);
		if (dumpMode == SoundDumpMode.linear)
		{
			v = 1f - dist / baseDist * dumpRate;
		}
		else if (dumpMode == SoundDumpMode.quadratic)
		{
			v = Mathf.Pow(1f - dist / baseDist * dumpRate, 2f);
		}
		else if (dumpMode == SoundDumpMode.cubic)
		{
			v = Mathf.Pow(1f - dist / baseDist * dumpRate, 3f);
		}
		IEnumerator enumerator = _setVolume(v);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private bool isPlayer(Collider o)
	{
		PlayerControl component = o.gameObject.GetComponent<PlayerControl>();
		int result;
		if ((bool)component)
		{
			if (!pc)
			{
				pc = component;
			}
			if ((bool)pc && !pcgo)
			{
				pcgo = pc.gameObject;
			}
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void OnTriggerEnter(Collider o)
	{
		if (isPlayer(o))
		{
			IEnumerator enumerator = _playSE();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void OnTriggerStay(Collider o)
	{
		if (isPlayer(o))
		{
			_dump();
		}
	}

	public void OnTriggerExit(Collider o)
	{
		if (isPlayer(o))
		{
			_stopSE();
		}
	}
}
