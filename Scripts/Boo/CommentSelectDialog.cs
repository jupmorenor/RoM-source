using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class CommentSelectDialog : CustomDialogBase
{
	[Serializable]
	internal class _0024_0024Close_0024closure_00243749_0024locals_002414333
	{
		internal bool _0024finished;
	}

	[Serializable]
	internal class _0024_0024Close_0024closure_00243749_0024closure_00243750
	{
		internal _0024_0024Close_0024closure_00243749_0024locals_002414333 _0024_0024locals_002414777;

		public _0024_0024Close_0024closure_00243749_0024closure_00243750(_0024_0024Close_0024closure_00243749_0024locals_002414333 _0024_0024locals_002414777)
		{
			this._0024_0024locals_002414777 = _0024_0024locals_002414777;
		}

		public void Invoke(UITweener t)
		{
			_0024_0024locals_002414777._0024finished = true;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Close_0024closure_00243749_002416566 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal __CommentSelectDialog__0024Close_0024closure_00243749_0024callable163_0024149_25__ _0024tweenWait_002416567;

			internal TweenScale _0024tw_002416568;

			internal _0024_0024Close_0024closure_00243749_0024locals_002414333 _0024_0024locals_002416569;

			internal CommentSelectDialog _0024self__002416570;

			public _0024(CommentSelectDialog self_)
			{
				_0024self__002416570 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002416569 = new _0024_0024Close_0024closure_00243749_0024locals_002414333();
					_0024self__002416570.UpdateCommentData(_0024self__002416570.commentData, finished: true);
					_0024_0024locals_002416569._0024finished = false;
					_0024tweenWait_002416567 = new _0024_0024Close_0024closure_00243749_0024closure_00243750(_0024_0024locals_002416569).Invoke;
					TweenAlpha.Begin(_0024self__002416570.gameObject, _0024self__002416570.GetComponent<TweenAlpha>().duration * 0.3f, 0f);
					_0024tw_002416568 = TweenScale.Begin(_0024self__002416570.gameObject, _0024self__002416570.GetComponent<TweenScale>().duration * 0.8f, new Vector3(0f, 0f, 0f));
					_0024tw_002416568.onFinished = _0024adaptor_0024__CommentSelectDialog__0024Close_0024closure_00243749_0024callable163_0024149_25___0024OnFinished_0024115.Adapt(_0024tweenWait_002416567);
					goto case 2;
				case 2:
					if (!_0024_0024locals_002416569._0024finished)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002416570.ExitModalMode();
					UnityEngine.Object.Destroy(_0024self__002416570.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal CommentSelectDialog _0024self__002416571;

		public _0024_0024Close_0024closure_00243749_002416566(CommentSelectDialog self_)
		{
			_0024self__002416571 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416571);
		}
	}

	[NonSerialized]
	private static bool bRunning_;

	private IPDynamicFontTextPicker commentPicker;

	private System.Collections.Generic.List<string> commentData;

	public UILabelBase counterLabel;

	public UILabelBase titleLabel;

	private __CommentSelectDialog_UpdateCommentCallback_0024callable44_002412_38__ updateCommentCallback;

	public bool enableModalCollider;

	public GameObject modalCollider;

	public Color SelectedColor;

	private float logtap;

	private bool waitLongTap;

	private bool exitingLongTap;

	public bool ModalCollider
	{
		get
		{
			return enableModalCollider;
		}
		set
		{
			enableModalCollider = value;
			if ((bool)modalCollider)
			{
				modalCollider.SetActive(value);
			}
		}
	}

	public static bool IsRunning => bRunning_;

	public __CommentSelectDialog_UpdateCommentCallback_0024callable44_002412_38__ UpdateCommentCallback
	{
		get
		{
			return updateCommentCallback;
		}
		set
		{
			updateCommentCallback = value;
		}
	}

	private CommentSelectDialog()
	{
		SelectedColor = Color.red;
		bRunning_ = false;
	}

	public void Initialize(string[] commentArray, string oldSelectData)
	{
		bRunning_ = true;
		commentPicker = gameObject.GetComponentInChildren<IPDynamicFontTextPicker>();
		int i = 0;
		UIAutoTweener[] componentsInChildren = gameObject.GetComponentsInChildren<UIAutoTweener>();
		checked
		{
			for (int length = componentsInChildren.Length; i < length; i++)
			{
				componentsInChildren[i].ignoreTimeScale = true;
			}
			if (!(commentPicker != null))
			{
				throw new AssertionFailedException("commentPicker != null");
			}
			System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
			int j = 0;
			for (int length2 = commentArray.Length; j < length2; j++)
			{
				if (!string.IsNullOrEmpty(commentArray[j]))
				{
					list.Add(commentArray[j]);
				}
			}
			string[] elements = (string[])Builtins.array(typeof(string), list);
			commentPicker.ReplaceElements(elements);
			RestoreSelectCommentState(oldSelectData);
			EnterModalMode();
		}
	}

	private void RestoreSelectCommentState(string oldSelectData)
	{
		char c = "\n".ToCharArray()[0];
		string[] array = oldSelectData.Split(c);
		int length = array.Length;
		commentData = null;
		commentData = new System.Collections.Generic.List<string>();
		for (int i = 0; i < length; i = checked(i + 1))
		{
			string text = array[RuntimeServices.NormalizeArrayIndex(array, i)];
			if (!string.IsNullOrEmpty(text))
			{
				commentData.Add(text);
			}
		}
		System.Collections.Generic.List<string> labelsText = commentPicker.labelsText;
		int selectedIndex = 0;
		string text2 = null;
		int num = 0;
		int count = commentData.Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int index = num;
			num++;
			text2 = commentData[index];
			int num2 = labelsText.IndexOf(text2);
			if (num2 < 0)
			{
				commentData[index] = null;
			}
			else
			{
				commentPicker.UpdateColor(num2, SelectedColor);
			}
		}
		if (0 < commentData.Count)
		{
			text2 = commentData[checked(commentData.Count - 1)];
			selectedIndex = labelsText.IndexOf(text2);
		}
		commentPicker.SelectedIndex = selectedIndex;
		UpdateCommentData(commentData);
	}

	private void PushSelectComment()
	{
		if (!commentPicker || commentPicker.IsCyclerMoving)
		{
			return;
		}
		int selectedIndex = commentPicker.SelectedIndex;
		if (commentPicker.GetColor(selectedIndex) == SelectedColor)
		{
			commentPicker.ResetColor(selectedIndex);
			commentData.Remove(commentPicker.labelsText[selectedIndex]);
		}
		else
		{
			if (3 <= commentData.Count)
			{
				return;
			}
			commentPicker.UpdateColor(selectedIndex, SelectedColor);
			commentData.Add(commentPicker.labelsText[selectedIndex]);
		}
		int count = commentData.Count;
		UpdateCommentData(commentData);
	}

	private void PushEnter()
	{
		if ((bool)commentPicker && !commentPicker.IsCyclerMoving)
		{
			logtap = Time.realtimeSinceStartup;
			waitLongTap = true;
			exitingLongTap = false;
		}
	}

	private void ReleaseEnter()
	{
		waitLongTap = false;
		if ((bool)commentPicker && !commentPicker.IsCyclerMoving && exitingLongTap)
		{
			exitingLongTap = false;
		}
		else if (0 < commentData.Count)
		{
			Close();
		}
	}

	private void Update()
	{
		if (!waitLongTap)
		{
			return;
		}
		float num = Time.realtimeSinceStartup - logtap;
		if (1.2f >= num)
		{
			return;
		}
		System.Collections.Generic.List<string> labelsText = commentPicker.labelsText;
		foreach (string commentDatum in commentData)
		{
			int num2 = labelsText.IndexOf(commentDatum);
			if (0 <= num2)
			{
				commentPicker.ResetColor(num2);
			}
		}
		commentData.Clear();
		UpdateCommentData(commentData);
		exitingLongTap = true;
		waitLongTap = false;
	}

	private void Close()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Close_0024closure_00243749_002416566(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		bRunning_ = false;
	}

	private void UpdateCommentData(System.Collections.Generic.List<string> lines)
	{
		UpdateCommentData(lines, finished: false);
	}

	private void UpdateCommentData(System.Collections.Generic.List<string> lines, bool finished)
	{
		int count = commentData.Count;
		int num = checked(3 - count);
		counterLabel.text = UIBasicUtility.SafeFormat("あと\u3000{0}\n選択できます", num);
		if (finished && UpdateCommentCallback != null)
		{
			updateCommentCallback(lines);
		}
	}

	internal IEnumerator _0024Close_0024closure_00243749()
	{
		return new _0024_0024Close_0024closure_00243749_002416566(this).GetEnumerator();
	}
}
