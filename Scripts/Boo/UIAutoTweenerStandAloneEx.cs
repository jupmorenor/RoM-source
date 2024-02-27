using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class UIAutoTweenerStandAloneEx : UIAutoTweener
{
	[Serializable]
	internal class _0024In_0024locals_002414546
	{
		internal UIAutoTweenerStandAloneEx[] _0024autoTweens;

		internal int _0024num;

		internal UIAutoTweenerStandAloneEx _0024checkTween;
	}

	[Serializable]
	internal class _0024Out_0024locals_002414547
	{
		internal UIAutoTweenerStandAloneEx[] _0024autoTweens;

		internal int _0024num;

		internal UIAutoTweenerStandAloneEx _0024checkTween;

		internal GameObject _0024obj;
	}

	[Serializable]
	internal class _0024In_0024startCheck_00242944
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422010 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal int _0024tmpnum_002422011;

				internal UIAutoTweenerStandAloneEx _0024autoTween_002422012;

				internal int _0024_002411742_002422013;

				internal UIAutoTweenerStandAloneEx[] _0024_002411743_002422014;

				internal int _0024_002411744_002422015;

				internal _0024In_0024startCheck_00242944 _0024self__002422016;

				public _0024(_0024In_0024startCheck_00242944 self_)
				{
					_0024self__002422016 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024tmpnum_002422011 = 0;
							_0024self__002422016._0024_0024locals_002415218._0024checkTween.isStartCheckNow = true;
							goto IL_00d4;
						case 2:
							_0024_002411742_002422013 = 0;
							_0024_002411743_002422014 = _0024self__002422016._0024_0024locals_002415218._0024autoTweens;
							for (_0024_002411744_002422015 = _0024_002411743_002422014.Length; _0024_002411742_002422013 < _0024_002411744_002422015; _0024_002411742_002422013++)
							{
								if (_0024_002411743_002422014[_0024_002411742_002422013] != null && _0024_002411743_002422014[_0024_002411742_002422013].isNowEnd)
								{
									_0024tmpnum_002422011++;
								}
							}
							goto IL_00d4;
						case 1:
							{
								result = 0;
								break;
							}
							IL_00d4:
							if (_0024tmpnum_002422011 != _0024self__002422016._0024_0024locals_002415218._0024num)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							_0024self__002422016._0024_0024locals_002415218._0024checkTween.isStartCheckNow = false;
							YieldDefault(1);
							goto case 1;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024In_0024startCheck_00242944 _0024self__002422017;

			public _0024Invoke_002422010(_0024In_0024startCheck_00242944 self_)
			{
				_0024self__002422017 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422017);
			}
		}

		internal _0024In_0024locals_002414546 _0024_0024locals_002415218;

		public _0024In_0024startCheck_00242944(_0024In_0024locals_002414546 _0024_0024locals_002415218)
		{
			this._0024_0024locals_002415218 = _0024_0024locals_002415218;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422010(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024Out_0024endCheck_00242945
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422018 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal int _0024tmpnum_002422019;

				internal UIAutoTweenerStandAloneEx _0024autoTween_002422020;

				internal int _0024_002411746_002422021;

				internal UIAutoTweenerStandAloneEx[] _0024_002411747_002422022;

				internal int _0024_002411748_002422023;

				internal _0024Out_0024endCheck_00242945 _0024self__002422024;

				public _0024(_0024Out_0024endCheck_00242945 self_)
				{
					_0024self__002422024 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024tmpnum_002422019 = 0;
							_0024self__002422024._0024_0024locals_002415219._0024checkTween.isEndCheckNow = true;
							goto IL_00d8;
						case 2:
							_0024_002411746_002422021 = 0;
							_0024_002411747_002422022 = _0024self__002422024._0024_0024locals_002415219._0024autoTweens;
							for (_0024_002411748_002422023 = _0024_002411747_002422022.Length; _0024_002411746_002422021 < _0024_002411748_002422023; _0024_002411746_002422021++)
							{
								if (_0024_002411747_002422022[_0024_002411746_002422021] != null && _0024_002411747_002422022[_0024_002411746_002422021].isNowEnd)
								{
									_0024tmpnum_002422019++;
								}
							}
							goto IL_00d8;
						case 3:
							if (_0024self__002422024._0024_0024locals_002415219._0024checkTween.disableFlag)
							{
								result = (YieldDefault(3) ? 1 : 0);
								break;
							}
							if (_0024self__002422024._0024_0024locals_002415219._0024obj.activeSelf)
							{
								_0024self__002422024._0024_0024locals_002415219._0024obj.SetActive(value: false);
							}
							YieldDefault(1);
							goto case 1;
						case 1:
							{
								result = 0;
								break;
							}
							IL_00d8:
							if (_0024tmpnum_002422019 != _0024self__002422024._0024_0024locals_002415219._0024num)
							{
								result = (YieldDefault(2) ? 1 : 0);
								break;
							}
							_0024self__002422024._0024_0024locals_002415219._0024checkTween.isEndCheckNow = false;
							goto case 3;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024Out_0024endCheck_00242945 _0024self__002422025;

			public _0024Invoke_002422018(_0024Out_0024endCheck_00242945 self_)
			{
				_0024self__002422025 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422025);
			}
		}

		internal _0024Out_0024locals_002414547 _0024_0024locals_002415219;

		public _0024Out_0024endCheck_00242945(_0024Out_0024locals_002414547 _0024_0024locals_002415219)
		{
			this._0024_0024locals_002415219 = _0024_0024locals_002415219;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422018(this).GetEnumerator();
		}
	}

	public bool standAloneHideStart;

	private bool hideFlag;

	private bool disableFlag;

	private bool started;

	private __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler;

	private __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler;

	private bool _isOut;

	private bool isStartCheckNow;

	private bool isEndCheckNow;

	private bool finished;

	public bool StandAloneHideStart
	{
		get
		{
			return standAloneHideStart;
		}
		set
		{
			standAloneHideStart = value;
		}
	}

	public __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ InHandler
	{
		get
		{
			return inHandler;
		}
		set
		{
			inHandler = value;
		}
	}

	public __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ OutHandler
	{
		get
		{
			return outHandler;
		}
		set
		{
			outHandler = value;
		}
	}

	public bool IsOut
	{
		get
		{
			return _isOut;
		}
		set
		{
			_isOut = value;
		}
	}

	public UIAutoTweenerStandAloneEx()
	{
		_isOut = true;
	}

	public static void In(GameObject obj)
	{
		In(obj, null);
	}

	public static void In(GameObject obj, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler)
	{
		_0024In_0024locals_002414546 _0024In_0024locals_0024 = new _0024In_0024locals_002414546();
		if (obj == null)
		{
			return;
		}
		if (!obj.activeSelf)
		{
			obj.SetActive(value: true);
		}
		_0024In_0024locals_0024._0024autoTweens = obj.GetComponentsInChildren<UIAutoTweenerStandAloneEx>(includeInactive: true);
		if (_0024In_0024locals_0024._0024autoTweens == null || _0024In_0024locals_0024._0024autoTweens.Length <= 0)
		{
			return;
		}
		_0024In_0024locals_0024._0024num = 0;
		_0024In_0024locals_0024._0024checkTween = null;
		int i = 0;
		UIAutoTweenerStandAloneEx[] _0024autoTweens = _0024In_0024locals_0024._0024autoTweens;
		checked
		{
			for (int length = _0024autoTweens.Length; i < length; i++)
			{
				if (!(_0024autoTweens[i] == null))
				{
					_0024autoTweens[i].In(inHandler);
					if (_0024In_0024locals_0024._0024checkTween == null)
					{
						_0024In_0024locals_0024._0024checkTween = _0024autoTweens[i];
					}
					_0024In_0024locals_0024._0024num++;
				}
			}
			if (_0024In_0024locals_0024._0024checkTween != null)
			{
				__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024In_0024startCheck_00242944(_0024In_0024locals_0024).Invoke;
				_0024In_0024locals_0024._0024checkTween.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
			}
		}
	}

	public static void Out(GameObject obj)
	{
		Out(obj, null);
	}

	public static void Out(GameObject obj, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler)
	{
		_0024Out_0024locals_002414547 _0024Out_0024locals_0024 = new _0024Out_0024locals_002414547();
		_0024Out_0024locals_0024._0024obj = obj;
		if (_0024Out_0024locals_0024._0024obj == null)
		{
			return;
		}
		_0024Out_0024locals_0024._0024autoTweens = _0024Out_0024locals_0024._0024obj.GetComponentsInChildren<UIAutoTweenerStandAloneEx>(includeInactive: true);
		if (_0024Out_0024locals_0024._0024autoTweens == null || _0024Out_0024locals_0024._0024autoTweens.Length <= 0)
		{
			return;
		}
		_0024Out_0024locals_0024._0024num = 0;
		_0024Out_0024locals_0024._0024checkTween = null;
		int i = 0;
		UIAutoTweenerStandAloneEx[] _0024autoTweens = _0024Out_0024locals_0024._0024autoTweens;
		checked
		{
			for (int length = _0024autoTweens.Length; i < length; i++)
			{
				if (!(_0024autoTweens[i] == null))
				{
					_0024autoTweens[i].Out(outHandler);
					if (_0024Out_0024locals_0024._0024checkTween == null)
					{
						_0024Out_0024locals_0024._0024checkTween = _0024autoTweens[i];
					}
					_0024Out_0024locals_0024._0024num++;
				}
			}
			if (_0024Out_0024locals_0024._0024checkTween != null)
			{
				__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024Out_0024endCheck_00242945(_0024Out_0024locals_0024).Invoke;
				if (_0024Out_0024locals_0024._0024checkTween.gameObject.active)
				{
					_0024Out_0024locals_0024._0024checkTween.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
				}
			}
		}
	}

	public static void Hide(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		UIAutoTweenerStandAloneEx[] componentsInChildren = obj.GetComponentsInChildren<UIAutoTweenerStandAloneEx>(includeInactive: true);
		if (componentsInChildren == null || componentsInChildren.Length <= 0)
		{
			return;
		}
		int i = 0;
		UIAutoTweenerStandAloneEx[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].Hide();
			}
		}
		obj.SetActive(value: false);
	}

	public static void InitUIAutoTweenerToStandAloneEx(GameObject obj, bool hide)
	{
		UIAutoTweener[] componentsInChildren = obj.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
		int i = 0;
		UIAutoTweener[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UIAutoTweenerStandAloneEx uIAutoTweenerStandAloneEx = ExtensionsModule.SetComponent<UIAutoTweenerStandAloneEx>(array[i].gameObject);
			uIAutoTweenerStandAloneEx.isStandAlone = array[i].isStandAlone;
			uIAutoTweenerStandAloneEx.ignoreTimeScale = array[i].ignoreTimeScale;
			uIAutoTweenerStandAloneEx.ignoreDelayWithOut = array[i].ignoreDelayWithOut;
			uIAutoTweenerStandAloneEx.doPosition = array[i].doPosition;
			uIAutoTweenerStandAloneEx.whereFrom = array[i].whereFrom;
			uIAutoTweenerStandAloneEx.horizonPosition = array[i].horizonPosition;
			uIAutoTweenerStandAloneEx.verticalPosition = array[i].verticalPosition;
			uIAutoTweenerStandAloneEx.delay = array[i].delay;
			uIAutoTweenerStandAloneEx.duration = array[i].duration;
			uIAutoTweenerStandAloneEx.method = array[i].method;
			uIAutoTweenerStandAloneEx.doAlpha = array[i].doAlpha;
			uIAutoTweenerStandAloneEx.alphaTo = array[i].alphaTo;
			uIAutoTweenerStandAloneEx.alphaFrom = array[i].alphaFrom;
			uIAutoTweenerStandAloneEx.alphaDelay = array[i].alphaDelay;
			uIAutoTweenerStandAloneEx.alphaDuration = array[i].alphaDuration;
			uIAutoTweenerStandAloneEx.alphaMethod = array[i].alphaMethod;
			uIAutoTweenerStandAloneEx.doScale = array[i].doScale;
			uIAutoTweenerStandAloneEx.scaleTo = array[i].scaleTo;
			uIAutoTweenerStandAloneEx.scaleFrom = array[i].scaleFrom;
			uIAutoTweenerStandAloneEx.scaleDelay = array[i].scaleDelay;
			uIAutoTweenerStandAloneEx.scaleDuration = array[i].scaleDuration;
			uIAutoTweenerStandAloneEx.scaleMethod = array[i].scaleMethod;
			UnityEngine.Object.DestroyObject(array[i]);
			if (hide)
			{
				uIAutoTweenerStandAloneEx.Hide();
			}
		}
	}

	private void OnEnable()
	{
		hideFlag = false;
	}

	private void OnDisable()
	{
		if (!hideFlag && !started)
		{
			standAloneHideStart = false;
		}
	}

	public void SetActive(bool active)
	{
		if (active)
		{
			In();
		}
		else
		{
			Out();
		}
	}

	public void In()
	{
		isStandAlone = true;
		__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ = null;
		In(_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__);
	}

	public void In(__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler)
	{
		this.inHandler = inHandler;
		IsOut = false;
		isStandAlone = true;
		disableFlag = false;
		if (!IsInit)
		{
			Initialize();
		}
		gameObject.SetActive(value: true);
		PlayAnimation(forward: true);
		finished = false;
	}

	public void Out()
	{
		isStandAlone = true;
		__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ = null;
		Out(_RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__);
	}

	public void Out(__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler)
	{
		this.outHandler = outHandler;
		if (!gameObject.activeSelf)
		{
			if (outHandler != null)
			{
				outHandler(gameObject);
			}
			return;
		}
		IsOut = true;
		isStandAlone = true;
		if (gameObject != null)
		{
			disableFlag = true;
			PlayAnimation(forward: false);
		}
		finished = false;
	}

	public void Hide()
	{
		hideFlag = true;
		isStandAlone = true;
		gameObject.SetActive(value: false);
		standAloneHideStart = false;
	}

	private new void Update()
	{
		if (!started)
		{
			started = true;
			isStandAlone = true;
			if (standAloneHideStart)
			{
				Hide();
				return;
			}
		}
		base.Update();
		if (finished || FinishCount != 0)
		{
			return;
		}
		if (disableFlag)
		{
			if (!isEndCheckNow)
			{
				gameObject.SetActive(value: false);
			}
			disableFlag = false;
			if (outHandler != null)
			{
				outHandler(gameObject);
			}
		}
		else if (!isStartCheckNow && inHandler != null)
		{
			inHandler(gameObject);
		}
		finished = true;
	}
}
