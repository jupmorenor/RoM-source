using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class CameraActiveCollision : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024setPlayerControl_002417318 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024player_002417319;

			internal CollisionMessage _0024cm_002417320;

			internal CameraActiveCollision _0024self__002417321;

			public _0024(CameraActiveCollision self_)
			{
				_0024self__002417321 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024player_002417319 = PlayerControl.CurrentPlayer;
					_0024cm_002417320 = _0024self__002417321.offCollision.GetComponent<CollisionMessage>();
					if ((bool)_0024cm_002417320)
					{
						_0024cm_002417320.target = _0024player_002417319.transform;
					}
					_0024cm_002417320 = _0024self__002417321.onCollision.GetComponent<CollisionMessage>();
					if ((bool)_0024cm_002417320)
					{
						_0024cm_002417320.target = _0024player_002417319.transform;
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

		internal CameraActiveCollision _0024self__002417322;

		public _0024setPlayerControl_002417318(CameraActiveCollision self_)
		{
			_0024self__002417322 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417322);
		}
	}

	public Collider offCollision;

	public Collider onCollision;

	public bool debugMeshDraw;

	public void Start()
	{
		if (!offCollision || !onCollision)
		{
			throw new AssertionFailedException("offCollision and onCollision");
		}
		MeshRenderer component = offCollision.GetComponent<MeshRenderer>();
		if ((bool)component)
		{
			component.enabled = debugMeshDraw;
		}
		component = onCollision.GetComponent<MeshRenderer>();
		if ((bool)component)
		{
			component.enabled = debugMeshDraw;
		}
		offCollision.enabled = false;
		onCollision.enabled = true;
		StartCoroutine(setPlayerControl());
	}

	private IEnumerator setPlayerControl()
	{
		return new _0024setPlayerControl_002417318(this).GetEnumerator();
	}

	public void cameraMoveOff()
	{
		offCollision.enabled = false;
		onCollision.enabled = true;
		if ((bool)Camera.main)
		{
			CameraControl component = Camera.main.GetComponent<CameraControl>();
			if ((bool)component)
			{
				component.FieldCameraActive = false;
			}
		}
	}

	public void cameraMoveOn()
	{
		offCollision.enabled = true;
		onCollision.enabled = false;
		if ((bool)Camera.main)
		{
			CameraControl component = Camera.main.GetComponent<CameraControl>();
			if ((bool)component)
			{
				component.FieldCameraActive = true;
			}
		}
	}
}
