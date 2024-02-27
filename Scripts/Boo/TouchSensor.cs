using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TouchSensor : MonoBehaviour
{
	[Serializable]
	internal class _0024Update_0024locals_002414487
	{
		internal RaycastHit[] _0024hits;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Update_002421485 : GenericGenerator<GameObject>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<GameObject>, ICloneable
		{
			internal _0024Update_0024locals_002414487 _0024_0024locals_002421486;

			protected IEnumerator<RaycastHit> _0024_0024enumerator;

			protected GameObject _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override GameObject Current => _0024_0024current;

			public Enumerator(_0024Update_0024locals_002414487 _0024_0024locals_002421486)
			{
				this._0024_0024locals_002421486 = _0024_0024locals_002421486;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<RaycastHit>)_0024_0024locals_002421486._0024hits).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					_0024_0024current = _0024_0024enumerator.Current.transform.root.gameObject;
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal _0024Update_0024locals_002414487 _0024_0024locals_002421487;

		public _0024Update_002421485(_0024Update_0024locals_002414487 _0024_0024locals_002421487)
		{
			this._0024_0024locals_002421487 = _0024_0024locals_002421487;
		}

		public override IEnumerator<GameObject> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002421487);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Update_002421488 : GenericGenerator<GameObject>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<GameObject>, ICloneable
		{
			internal _0024Update_0024locals_002414487 _0024_0024locals_002421489;

			protected IEnumerator<RaycastHit> _0024_0024enumerator;

			protected GameObject _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override GameObject Current => _0024_0024current;

			public Enumerator(_0024Update_0024locals_002414487 _0024_0024locals_002421489)
			{
				this._0024_0024locals_002421489 = _0024_0024locals_002421489;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<RaycastHit>)_0024_0024locals_002421489._0024hits).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					_0024_0024current = _0024_0024enumerator.Current.transform.gameObject;
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal _0024Update_0024locals_002414487 _0024_0024locals_002421490;

		public _0024Update_002421488(_0024Update_0024locals_002414487 _0024_0024locals_002421490)
		{
			this._0024_0024locals_002421490 = _0024_0024locals_002421490;
		}

		public override IEnumerator<GameObject> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002421490);
		}
	}

	private Boo.Lang.List<GameObject> touchedObjects;

	public TouchSensor()
	{
		touchedObjects = new Boo.Lang.List<GameObject>();
	}

	public void Update()
	{
		_0024Update_0024locals_002414487 _0024Update_0024locals_0024 = new _0024Update_0024locals_002414487();
		touchedObjects.Clear();
		if (!Input.GetMouseButtonDown(0) || !(Camera.main != null))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		_0024Update_0024locals_0024._0024hits = Physics.RaycastAll(ray);
		IEnumerator<GameObject> enumerator = ((IEnumerable<GameObject>)new _0024Update_002421485(_0024Update_0024locals_0024)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				touchedObjects.Add(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<GameObject> enumerator2 = ((IEnumerable<GameObject>)new _0024Update_002421488(_0024Update_0024locals_0024)).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				GameObject current2 = enumerator2.Current;
				touchedObjects.Add(current2);
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	public bool touch(GameObject obj)
	{
		return !(obj == null) && touchedObjects.Contains(obj);
	}
}
