using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PicBookModelWindow))]
public class PicBookModelPoppetWindow : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TPoseCounter_002421869 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024model_002421870;

			internal PicBookModelPoppetWindow _0024self__002421871;

			public _0024(GameObject model, PicBookModelPoppetWindow self_)
			{
				_0024model_002421870 = model;
				_0024self__002421871 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421871.PicBookPoppetModelSetting(_0024model_002421870);
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__002421871.modelWindow.SetModelObject(_0024model_002421870, _0024self__002421871.modelParent);
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024self__002421871.SetPoppetCenter(_0024model_002421870);
					if (_0024self__002421871.modelViewer != null)
					{
						_0024self__002421871.modelViewer.Init(_0024model_002421870);
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

		internal GameObject _0024model_002421872;

		internal PicBookModelPoppetWindow _0024self__002421873;

		public _0024TPoseCounter_002421869(GameObject model, PicBookModelPoppetWindow self_)
		{
			_0024model_002421872 = model;
			_0024self__002421873 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024model_002421872, _0024self__002421873);
		}
	}

	public PicBookModelWindow modelWindow;

	public Transform modelCameraTarget;

	public Transform modelParent;

	private Vector3 parentDefaultPosition;

	public PicBookMotionViewer modelViewer;

	private MPoppets data;

	public void Awake()
	{
		if (modelWindow == null)
		{
			modelWindow = GetComponent<PicBookModelWindow>();
		}
		parentDefaultPosition = modelParent.position;
	}

	public void SetPoppetsItem(PicBookData picBookData)
	{
		data = picBookData.poppet;
		modelParent.position = new Vector3(0f, -10000f, 0f);
		modelWindow.SetDetail(data.Name.msg, data.Rare.Icon);
		RuntimeAssetBundleDB.Instance.instantiatePrefab(data.PrefabName, delegate(GameObject model)
		{
			StartCoroutine(TPoseCounter(model));
			GameSoundManager.Instance.LoadSeGroup(data.Monster.SoundID);
			GameSoundManager.Instance.LoadSeGroup("e_common");
		});
	}

	public IEnumerator TPoseCounter(GameObject model)
	{
		return new _0024TPoseCounter_002421869(model, this).GetEnumerator();
	}

	public void PicBookPoppetModelSetting(GameObject model)
	{
		AIControl component = model.GetComponent<AIControl>();
		if (component != null)
		{
			component.PoppetData = new RespPoppet(data);
			component.disableTargetRingStar();
		}
		CharacterController component2 = model.GetComponent<CharacterController>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		D540ScriptRunner component3 = model.GetComponent<D540ScriptRunner>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
	}

	public void SetPoppetCenter(GameObject model)
	{
		if (model == null || modelCameraTarget == null)
		{
			return;
		}
		modelParent.position = parentDefaultPosition;
		Transform transform = model.transform;
		Transform transform2 = null;
		IEnumerator enumerator = transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform3 = (Transform)obj;
			transform2 = transform3.Find("y_ang/cog");
			if (transform2 != null)
			{
				break;
			}
		}
		if (transform2 != null && !(transform2.position.y <= modelCameraTarget.position.y))
		{
			float y = modelParent.position.y + (modelCameraTarget.position.y - transform2.position.y);
			Vector3 position = modelParent.position;
			float num = (position.y = y);
			Vector3 vector2 = (modelParent.position = position);
		}
	}

	public void OnEnable()
	{
		modelParent.position = new Vector3(0f, -10000f, 0f);
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance != null)
		{
			instance.UnloadSeType(6);
			instance.UnloadSeType(7);
			instance.UnloadSeType(1);
		}
	}

	public void OnDestroy()
	{
		data = null;
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (instance != null)
		{
			instance.UnloadSeType(6);
			instance.UnloadSeType(7);
			instance.UnloadSeType(1);
		}
	}

	internal void _0024SetPoppetsItem_0024closure_00245087(GameObject model)
	{
		StartCoroutine(TPoseCounter(model));
		GameSoundManager.Instance.LoadSeGroup(data.Monster.SoundID);
		GameSoundManager.Instance.LoadSeGroup("e_common");
	}
}
