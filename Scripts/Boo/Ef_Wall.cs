using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class Ef_Wall : Ef_Base
{
	[Serializable]
	internal class _0024Start_0024locals_002414323
	{
		internal Ef_HeightBuffer _0024hBuf;

		internal float _0024terY;

		internal Vector3 _0024terN;
	}

	[Serializable]
	internal class _0024Start_0024setHeight_00244071
	{
		internal Ef_Wall _0024this_002414747;

		internal Vector3 _0024_002412264_002414748;

		internal float _0024_002412263_002414749;

		internal _0024Start_0024locals_002414323 _0024_0024locals_002414750;

		public _0024Start_0024setHeight_00244071(Ef_Wall _0024this_002414747, Vector3 _0024_002412264_002414748, float _0024_002412263_002414749, _0024Start_0024locals_002414323 _0024_0024locals_002414750)
		{
			this._0024this_002414747 = _0024this_002414747;
			this._0024_002412264_002414748 = _0024_002412264_002414748;
			this._0024_002412263_002414749 = _0024_002412263_002414749;
			this._0024_0024locals_002414750 = _0024_0024locals_002414750;
		}

		public void Invoke(GameObject obj)
		{
			if ((bool)obj)
			{
				if (_0024_0024locals_002414750._0024hBuf != null && _0024this_002414747.upLength != -1f)
				{
					object[] height = _0024_0024locals_002414750._0024hBuf.GetHeight(obj.transform.position);
					_0024_0024locals_002414750._0024terY = RuntimeServices.UnboxSingle(height[0]);
					_0024_0024locals_002414750._0024terN = (Vector3)height[1];
					_0024_0024locals_002414750._0024terY += _0024this_002414747.upLength;
					float num = (_0024_002412263_002414749 = _0024_0024locals_002414750._0024terY);
					Vector3 vector = (_0024_002412264_002414748 = obj.transform.position);
					float num2 = (_0024_002412264_002414748.y = _0024_002412263_002414749);
					Vector3 vector3 = (obj.transform.position = _0024_002412264_002414748);
				}
				if ((bool)obj.renderer)
				{
					obj.renderer.material = _0024this_002414747.mat;
				}
			}
		}
	}

	public Vector2 scrollVec1;

	public GameObject meshObj1;

	public GameObject meshObj2;

	public GameObject meshObj3;

	public GameObject meshObj4;

	public GameObject meshObj5;

	public GameObject meshObj6;

	public GameObject meshObj7;

	public GameObject meshObj8;

	public GameObject meshObj9;

	public GameObject meshObjA;

	public float upLength;

	public bool setLocalPos;

	private Ef_HeightBuffer hBuf;

	private Material mat;

	private Vector2 pos;

	public Ef_Wall()
	{
		scrollVec1 = new Vector2(0.02f, -0.03f);
		upLength = 0.1f;
		setLocalPos = true;
		pos = Vector2.zero;
	}

	public void Start()
	{
		_0024Start_0024locals_002414323 _0024Start_0024locals_0024 = new _0024Start_0024locals_002414323();
		if (!mat && (bool)meshObj1 && (bool)meshObj1.renderer)
		{
			mat = meshObj1.renderer.material;
		}
		if (!mat && (bool)meshObj2 && (bool)meshObj2.renderer)
		{
			mat = meshObj2.renderer.material;
		}
		if (!mat && (bool)meshObj3 && (bool)meshObj3.renderer)
		{
			mat = meshObj3.renderer.material;
		}
		if (!mat && (bool)meshObj4 && (bool)meshObj4.renderer)
		{
			mat = meshObj4.renderer.material;
		}
		if (!mat && (bool)meshObj5 && (bool)meshObj5.renderer)
		{
			mat = meshObj5.renderer.material;
		}
		if (!mat && (bool)meshObj6 && (bool)meshObj6.renderer)
		{
			mat = meshObj6.renderer.material;
		}
		if (!mat && (bool)meshObj7 && (bool)meshObj7.renderer)
		{
			mat = meshObj7.renderer.material;
		}
		if (!mat && (bool)meshObj8 && (bool)meshObj8.renderer)
		{
			mat = meshObj8.renderer.material;
		}
		if (!mat && (bool)meshObj9 && (bool)meshObj9.renderer)
		{
			mat = meshObj9.renderer.material;
		}
		if (!mat && (bool)meshObjA && (bool)meshObjA.renderer)
		{
			mat = meshObjA.renderer.material;
		}
		if (setLocalPos)
		{
			if ((bool)meshObj1)
			{
				meshObj1.transform.localPosition = Vector3.zero;
				meshObj1.transform.localRotation = Quaternion.Euler(4f, 0f, 0f);
				meshObj1.transform.localScale = Vector3.one;
				if ((bool)meshObj2)
				{
					meshObj2.transform.localPosition = new Vector3(0f, 0f, 0.1f);
					meshObj2.transform.localRotation = Quaternion.Euler(2f, 180f, 0f);
					meshObj2.transform.localScale = new Vector3(1f, 1.5f, 1f);
				}
			}
			if ((bool)meshObj3)
			{
				meshObj3.transform.localPosition = Vector3.zero;
				meshObj3.transform.localRotation = Quaternion.Euler(4f, 0f, 0f);
				meshObj3.transform.localScale = Vector3.one;
				if ((bool)meshObj4)
				{
					meshObj4.transform.localPosition = new Vector3(0f, 0f, 0.1f);
					meshObj4.transform.localRotation = Quaternion.Euler(2f, 180f, 0f);
					meshObj4.transform.localScale = new Vector3(1f, 1.5f, 1f);
				}
			}
			if ((bool)meshObj5)
			{
				meshObj5.transform.localPosition = Vector3.zero;
				meshObj5.transform.localRotation = Quaternion.Euler(4f, 0f, 0f);
				meshObj5.transform.localScale = Vector3.one;
				if ((bool)meshObj6)
				{
					meshObj6.transform.localPosition = new Vector3(0f, 0f, 0.1f);
					meshObj6.transform.localRotation = Quaternion.Euler(2f, 180f, 0f);
					meshObj6.transform.localScale = new Vector3(1f, 1.5f, 1f);
				}
			}
			if ((bool)meshObj7)
			{
				meshObj7.transform.localPosition = Vector3.zero;
				meshObj7.transform.localRotation = Quaternion.Euler(4f, 0f, 0f);
				meshObj7.transform.localScale = Vector3.one;
				if ((bool)meshObj8)
				{
					meshObj8.transform.localPosition = new Vector3(0f, 0f, 0.1f);
					meshObj8.transform.localRotation = Quaternion.Euler(2f, 180f, 0f);
					meshObj8.transform.localScale = new Vector3(1f, 1.5f, 1f);
				}
			}
			if ((bool)meshObj9)
			{
				meshObj9.transform.localPosition = Vector3.zero;
				meshObj9.transform.localRotation = Quaternion.Euler(4f, 0f, 0f);
				meshObj9.transform.localScale = Vector3.one;
				if ((bool)meshObjA)
				{
					meshObjA.transform.localPosition = new Vector3(0f, 0f, 0.1f);
					meshObjA.transform.localRotation = Quaternion.Euler(2f, 180f, 0f);
					meshObjA.transform.localScale = new Vector3(1f, 1.5f, 1f);
				}
			}
		}
		_0024Start_0024locals_0024._0024hBuf = Ef_HeightBuffer.Current;
		bool flag = default(bool);
		_0024Start_0024locals_0024._0024terY = default(float);
		_0024Start_0024locals_0024._0024terN = default(Vector3);
		Vector3 _0024_002412264_0024 = default(Vector3);
		float _0024_002412263_0024 = default(float);
		__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ = new _0024Start_0024setHeight_00244071(this, _0024_002412264_0024, _0024_002412263_0024, _0024Start_0024locals_0024).Invoke;
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj1);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj2);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj3);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj4);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj5);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj6);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj7);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj8);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObj9);
		_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__(meshObjA);
	}

	public void Update()
	{
		if ((bool)mat)
		{
			pos += scrollVec1 * deltaTime;
			mat.SetTextureOffset("_MainTex", pos);
		}
	}
}
