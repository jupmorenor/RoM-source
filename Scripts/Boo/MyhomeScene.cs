using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class MyhomeScene : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416696 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024pos_002416697;

			internal Quaternion _0024rot_002416698;

			internal PlayerPoppetCache.PlayerParams _0024prm_002416699;

			internal PlayerControl _0024pl_002416700;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (ControlFader)
					{
						SceneChanger.Instance().dontReveal = true;
					}
					if (noCreatePlayer)
					{
						noCreatePlayer = false;
						if (ControlFader)
						{
							SceneChanger.Instance().dontReveal = false;
						}
						goto case 1;
					}
					_0024pos_002416697 = new Vector3(-0.2583922f, 0f, 4.478821f);
					_0024rot_002416698 = Quaternion.identity;
					_0024prm_002416699 = new PlayerPoppetCache.PlayerParams();
					_0024prm_002416699.position = _0024pos_002416697;
					_0024prm_002416699.rotation = _0024rot_002416698;
					_0024prm_002416699.isBattleMode = false;
					_0024pl_002416700 = PlayerPoppetCache.Instance.getPlayer(_0024prm_002416699);
					goto case 2;
				case 2:
					if (!_0024pl_002416700.IsReady)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (ControlFader)
					{
						SceneChanger.Instance().dontReveal = false;
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

	[NonSerialized]
	public static bool noCreatePlayer;

	[NonSerialized]
	public static bool ControlFader = true;

	public void Start()
	{
		RuntimeAssetBundleDB.Instance.instantiatePrefab("ZPatch001Myhome");
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator main()
	{
		return new _0024main_002416696().GetEnumerator();
	}
}
