using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using ObjUtil;
using UnityEngine;

[Serializable]
public class AttachText : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024drawRoutine_002421269 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024pos_002421270;

			internal AttachText _0024self__002421271;

			public _0024(AttachText self_)
			{
				_0024self__002421271 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__002421271.target)
					{
						_0024pos_002421270 = ObjUtilModule.GetScreenPostion(_0024self__002421271.transform, _0024self__002421271.target.gameObject, Camera.main);
						_0024pos_002421270.x += _0024self__002421271.drawOffsetX;
						_0024pos_002421270.y += _0024self__002421271.drawOffsetY;
						_0024self__002421271.transform.localPosition = _0024pos_002421270;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421271.uiLabel.enabled = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AttachText _0024self__002421272;

		public _0024drawRoutine_002421269(AttachText self_)
		{
			_0024self__002421272 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421272);
		}
	}

	private Transform target;

	public float drawOffsetX;

	public float drawOffsetY;

	private float offsetX;

	private float offsetY;

	private UILabel uiLabel;

	public void Start()
	{
		uiLabel = GetComponent<UILabel>();
		uiLabel.enabled = false;
	}

	private IEnumerator drawRoutine()
	{
		return new _0024drawRoutine_002421269(this).GetEnumerator();
	}

	public void setTarget(Transform _target)
	{
		target = _target;
		StopAllCoroutines();
		StartCoroutine(drawRoutine());
		uiLabel.enabled = true;
	}

	public void setText(string _text)
	{
		uiLabel.text = _text;
	}

	public void hide()
	{
		target = null;
		StopAllCoroutines();
		uiLabel.enabled = false;
	}
}
