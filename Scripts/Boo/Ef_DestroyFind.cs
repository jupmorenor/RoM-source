using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;
using UnityEngine;

[Serializable]
public class Ef_DestroyFind : MonoBehaviour
{
	[Serializable]
	internal class _0024Awake_0024locals_002414324
	{
		internal bool _0024hit;
	}

	[Serializable]
	internal class _0024Awake_0024_each_00244073
	{
		internal Ef_DestroyFind _0024this_002414751;

		internal _0024Awake_0024locals_002414324 _0024_0024locals_002414752;

		public _0024Awake_0024_each_00244073(Ef_DestroyFind _0024this_002414751, _0024Awake_0024locals_002414324 _0024_0024locals_002414752)
		{
			this._0024this_002414751 = _0024this_002414751;
			this._0024_0024locals_002414752 = _0024_0024locals_002414752;
		}

		public void Invoke(GameObject go, string name, bool isCallRecursive)
		{
			_0024_0024locals_002414752._0024hit = true;
			if (_0024this_002414751.fadeDestroy)
			{
				_0024this_002414751._destroy(go);
			}
			else
			{
				UnityEngine.Object.Destroy(go);
			}
			GameObject gameObject = ObjUtilModule.FindByName(name);
			if (gameObject != null && gameObject != go)
			{
				Invoke(go, name, isCallRecursive: true);
			}
		}
	}

	public string[] findNames;

	public bool fadeDestroy;

	public float life;

	public bool destroyThis;

	public Ef_DestroyFind()
	{
		fadeDestroy = true;
		destroyThis = true;
	}

	public void Start()
	{
	}

	public void Awake()
	{
		_0024Awake_0024locals_002414324 _0024Awake_0024locals_0024 = new _0024Awake_0024locals_002414324();
		_0024Awake_0024locals_0024._0024hit = false;
		__Ef_DestroyFind_Awake_0024callable182_002416_13__ _Ef_DestroyFind_Awake_0024callable182_002416_13__ = new _0024Awake_0024_each_00244073(this, _0024Awake_0024locals_0024).Invoke;
		int i = 0;
		string[] array = findNames;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			GameObject gameObject = ObjUtilModule.FindByName(array[i]);
			if ((bool)gameObject)
			{
				_Ef_DestroyFind_Awake_0024callable182_002416_13__(gameObject, array[i], forceLoop: false);
			}
		}
		if (!_0024Awake_0024locals_0024._0024hit)
		{
		}
		if (destroyThis)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public void _destroy(GameObject go)
	{
		if ((bool)go.particleSystem)
		{
			destroyParticle(go);
		}
		else if ((bool)go.GetComponent<TrailRenderer>())
		{
			destroyTrailrenderer(go);
		}
		else if ((bool)go.renderer)
		{
			destroyRenderer(go);
		}
		else
		{
			UnityEngine.Object.Destroy(go);
		}
	}

	public void destroyParticle(GameObject go)
	{
		go.transform.parent = null;
		Ef_DestroyParticle ef_DestroyParticle = go.AddComponent<Ef_DestroyParticle>();
		if (!(ef_DestroyParticle != null))
		{
			throw new AssertionFailedException("エフェクト削除スクリプト: パーティクルオブジェクトに Ef_DestroyParticle がついていない");
		}
		if (life == 0f)
		{
			ef_DestroyParticle.life = go.particleSystem.startLifetime;
		}
		else
		{
			ef_DestroyParticle.life = life;
		}
	}

	public void destroyTrailrenderer(GameObject go)
	{
		go.transform.parent = null;
		Ef_DestroyTrail ef_DestroyTrail = go.AddComponent<Ef_DestroyTrail>();
		if (!(ef_DestroyTrail != null))
		{
			throw new AssertionFailedException("エフェクト削除スクリプト: TrailRenderer に Ef_DestroyTrail がついていない");
		}
		if (life == 0f)
		{
			ef_DestroyTrail.life = go.GetComponent<TrailRenderer>().time;
		}
		else
		{
			ef_DestroyTrail.life = life;
		}
	}

	public void destroyRenderer(GameObject go)
	{
		go.transform.parent = null;
		Ef_DestroyAlpha ef_DestroyAlpha = go.AddComponent<Ef_DestroyAlpha>();
		if (!(ef_DestroyAlpha != null))
		{
			throw new AssertionFailedException("エフェクト削除スクリプト: renderer に Ef_DestroyAlpha がついていない");
		}
		if (life == 0f)
		{
			ef_DestroyAlpha.life = 1f;
		}
		else
		{
			ef_DestroyAlpha.life = life;
		}
	}
}
