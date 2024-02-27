using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class QuestRaidCameraSwitcher : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416916 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal QuestRaidCameraSwitcher _0024self__002416917;

			public _0024(QuestRaidCameraSwitcher self_)
			{
				_0024self__002416917 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (Camera.main == null || Camera.main.GetComponent<CameraControl>() == null)
					{
						goto case 1;
					}
					_0024self__002416917.normalCam = Camera.main.gameObject;
					_0024self__002416917.newCam = GameAssetModule.InstantiatePrefab("Prefab/Camera/RaidCamera") as GameObject;
					if (!(_0024self__002416917.newCam != null))
					{
						throw new AssertionFailedException("newCam != null");
					}
					_0024self__002416917.newCamComp = _0024self__002416917.newCam.GetComponent<RaidCamera>();
					if (!(_0024self__002416917.newCamComp != null))
					{
						throw new AssertionFailedException("newCamComp != null");
					}
					_0024self__002416917.newCamComp.player = PlayerControl.CurrentPlayer.transform;
					_0024self__002416917.normalCam.SetActive(value: false);
					goto case 2;
				case 2:
					if (!QuestBattleStarter.IsPlaying)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (QuestBattleStarter.IsPlaying)
					{
						_0024self__002416917.normalCam.SetActive(value: false);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002416917.newCam.SetActive(value: false);
					_0024self__002416917.normalCam.SetActive(value: true);
					UnityEngine.Object.Destroy(_0024self__002416917.newCam);
					UnityEngine.Object.Destroy(_0024self__002416917);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal QuestRaidCameraSwitcher _0024self__002416918;

		public _0024main_002416916(QuestRaidCameraSwitcher self_)
		{
			_0024self__002416918 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416918);
		}
	}

	private GameObject normalCam;

	private GameObject newCam;

	private RaidCamera newCamComp;

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
		return new _0024main_002416916(this).GetEnumerator();
	}
}
