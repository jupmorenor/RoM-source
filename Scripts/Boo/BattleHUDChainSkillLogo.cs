using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BattleHUDChainSkillLogo : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421313 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UISprite _0024ln_002421314;

			internal int _0024_002410357_002421315;

			internal UISprite[] _0024_002410358_002421316;

			internal int _0024_002410359_002421317;

			internal string _0024skillName_002421318;

			internal Color _0024nameCol_002421319;

			internal Color _0024lineColor_002421320;

			internal BattleHUDChainSkillLogo _0024self__002421321;

			public _0024(string skillName, Color nameCol, Color lineColor, BattleHUDChainSkillLogo self_)
			{
				_0024skillName_002421318 = skillName;
				_0024nameCol_002421319 = nameCol;
				_0024lineColor_002421320 = lineColor;
				_0024self__002421321 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024self__002421321.Root == null)
						{
							goto case 1;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
						_0024self__002421321.Root.SetActive(value: true);
						if (_0024self__002421321.Label != null && _0024skillName_002421318 != null)
						{
							_0024self__002421321.Label.text = _0024skillName_002421318;
							_0024self__002421321.Label.color = _0024nameCol_002421319;
						}
						if (_0024self__002421321.ElemLines != null)
						{
							_0024_002410357_002421315 = 0;
							_0024_002410358_002421316 = _0024self__002421321.ElemLines;
							for (_0024_002410359_002421317 = _0024_002410358_002421316.Length; _0024_002410357_002421315 < _0024_002410359_002421317; _0024_002410357_002421315++)
							{
								if (_0024_002410358_002421316[_0024_002410357_002421315] != null)
								{
									_0024_002410358_002421316[_0024_002410357_002421315].color = _0024lineColor_002421320;
								}
							}
						}
						_0024self__002421321.resetTweeners();
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal string _0024skillName_002421322;

		internal Color _0024nameCol_002421323;

		internal Color _0024lineColor_002421324;

		internal BattleHUDChainSkillLogo _0024self__002421325;

		public _0024main_002421313(string skillName, Color nameCol, Color lineColor, BattleHUDChainSkillLogo self_)
		{
			_0024skillName_002421322 = skillName;
			_0024nameCol_002421323 = nameCol;
			_0024lineColor_002421324 = lineColor;
			_0024self__002421325 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024skillName_002421322, _0024nameCol_002421323, _0024lineColor_002421324, _0024self__002421325);
		}
	}

	public GameObject オンオフ根元;

	public UILabelBase 連携技名ラベル;

	public UISprite[] 連携属性線;

	private UITweener[] tweeners;

	public GameObject Root => オンオフ根元;

	public UILabelBase Label => 連携技名ラベル;

	public UISprite[] ElemLines => 連携属性線;

	public void Awake()
	{
		if (!(Root == null))
		{
			tweeners = Root.GetComponents<UITweener>();
			Root.SetActive(value: false);
		}
	}

	public void show(MChainSkills cskl, MElements elm)
	{
		if (cskl != null)
		{
			string skillName = new StringBuilder().Append(cskl.Name).ToString();
			Color nameCol = new Color(1f, 1f, 1f, 1f);
			Color lineColor = new Color(1f, 1f, 1f, 0f);
			if (elm != null)
			{
				nameCol = elm.RenkeiForeColor;
				lineColor = elm.RenkeiBackColor;
			}
			IEnumerator enumerator = main(skillName, nameCol, lineColor);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void show(string msg)
	{
		if (!string.IsNullOrEmpty(msg))
		{
			MElements mElements = MElements.Get(1);
			IEnumerator enumerator = main(msg, mElements.RenkeiForeColor, mElements.RenkeiBackColor);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator main(string skillName, Color nameCol, Color lineColor)
	{
		return new _0024main_002421313(skillName, nameCol, lineColor, this).GetEnumerator();
	}

	public void hide()
	{
		Root.SetActive(value: false);
		UnityEngine.Object.Destroy(gameObject);
	}

	private void resetTweeners()
	{
		int i = 0;
		UITweener[] array = tweeners;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].Play(forward: true);
			array[i].Reset();
		}
	}
}
