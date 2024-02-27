using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Collider))]
public class QuestLinker : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418888 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_002418889;

			internal float _0024_0024wait_sec_0024temp_00241719_002418890;

			internal Collider _0024c_002418891;

			internal int _0024_00249466_002418892;

			internal QuestLinker _0024self__002418893;

			public _0024(QuestLinker self_)
			{
				_0024self__002418893 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_00249466_002418892 = 0;
					goto IL_00c5;
				case 2:
					if (_0024_0024wait_sec_0024temp_00241719_002418890 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241719_002418890 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024c_002418891 = _0024self__002418893.gameObject.GetComponent<Collider>();
					if (_0024c_002418891 != null)
					{
						if (_0024c_002418891.isTrigger)
						{
							goto IL_00d1;
						}
						_0024c_002418891.isTrigger = true;
					}
					goto IL_00c5;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00c5:
					if (_0024_00249466_002418892 < 3)
					{
						_0024i_002418889 = _0024_00249466_002418892;
						_0024_00249466_002418892++;
						_0024_0024wait_sec_0024temp_00241719_002418890 = 0.1f;
						goto case 2;
					}
					goto IL_00d1;
					IL_00d1:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal QuestLinker _0024self__002418894;

		public _0024main_002418888(QuestLinker self_)
		{
			_0024self__002418894 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418894);
		}
	}

	public EnumMapLinkDir Direction;

	private bool disableEnter;

	public void Awake()
	{
		ExtensionsModule.SetLayer(gameObject, "MAP_JUMP");
		Collider component = gameObject.GetComponent<Collider>();
		if (component != null)
		{
			component.isTrigger = true;
		}
	}

	public void Start()
	{
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002418888(this).GetEnumerator();
	}

	public void OnTriggerEnter(Collider c)
	{
		if (QuestInitializer.IsInPlay && !QuestSession.IsSessionEnded && !QuestBattleStarter.IsPlaying)
		{
			PlayerControl component = c.transform.root.gameObject.GetComponent<PlayerControl>();
			if (!(component == null) && !disableEnter && !QuestLinkRoutine.Instance.IsJumpingNow)
			{
				disableEnter = true;
				QuestLinkRoutine.Instance.jump(Direction);
			}
		}
	}
}
