using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PrologueStartMain : MonoBehaviour
{
	[Serializable]
	internal class _0024_0024main_0024closure_00245090_0024locals_002414535
	{
		internal int _0024downLoadType;

		internal Dialog _0024dlg;
	}

	[Serializable]
	internal class _0024_0024main_0024closure_00245090_0024closure_00245091
	{
		internal _0024_0024main_0024closure_00245090_0024locals_002414535 _0024_0024locals_002415194;

		public _0024_0024main_0024closure_00245090_0024closure_00245091(_0024_0024main_0024closure_00245090_0024locals_002414535 _0024_0024locals_002415194)
		{
			this._0024_0024locals_002415194 = _0024_0024locals_002415194;
		}

		public void Invoke(int btn)
		{
			_0024_0024locals_002415194._0024downLoadType = btn;
			_0024_0024locals_002415194._0024dlg = null;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421887 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiLocalDataUpload _0024reqlclDatUL_002421888;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024func_002421889;

			internal IEnumerator _0024_0024sco_0024temp_00242638_002421890;

			internal PrologueStartMain _0024self__002421891;

			public _0024(PrologueStartMain self_)
			{
				_0024self__002421891 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (SceneChanger.LastScene == SceneID.Ui_Download)
					{
						MerlinServer.Busy = true;
						_0024reqlclDatUL_002421888 = new ApiLocalDataUpload();
						MerlinServer.Request(_0024reqlclDatUL_002421888);
						goto case 2;
					}
					_0024func_002421889 = () => new _0024_0024main_0024closure_00245090_002421893().GetEnumerator();
					_0024_0024sco_0024temp_00242638_002421890 = _0024func_002421889();
					if (_0024_0024sco_0024temp_00242638_002421890 != null)
					{
						_0024self__002421891.StartCoroutine(_0024_0024sco_0024temp_00242638_002421890);
					}
					YieldDefault(1);
					goto case 1;
				case 2:
					if (!_0024reqlclDatUL_002421888.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					TutorialFlowControl.Create();
					MerlinServer.Busy = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PrologueStartMain _0024self__002421892;

		public _0024main_002421887(PrologueStartMain self_)
		{
			_0024self__002421892 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421892);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024main_0024closure_00245090_002421893 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024wifi_002421894;

			internal int _0024threeG_002421895;

			internal DialogManager _0024dlgMan_002421896;

			internal _0024_0024main_0024closure_00245090_0024locals_002414535 _0024_0024locals_002421897;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421897 = new _0024_0024main_0024closure_00245090_0024locals_002414535();
					_0024wifi_002421894 = 2;
					_0024threeG_002421895 = 4;
					_0024dlgMan_002421896 = DialogManager.Instance;
					_0024_0024locals_002421897._0024downLoadType = 0;
					_0024dlgMan_002421896.OnButton(0);
					_0024_0024locals_002421897._0024dlg = _0024dlgMan_002421896.OpenCustomDialog(new StringBuilder("ゲームデータをダウンロードします。\n加えてBGM・SEデータもダウンロードできます。\nなお、ダウンロードには時間がかかるため\nWi-Fi環境を推奨します。\n \n【推定所要時間\u3000Wi-Fi：").Append((object)_0024wifi_002421894).Append("分\u30003G：").Append((object)_0024threeG_002421895)
						.Append("分】\n <RED>※au回線（3G）では\nダウンロードに支障をきたす可能性があります。<COLOR_INIT>\n<RED>※BGM・SEデータは後から\nダウンロードすることもできます。<COLOR_INIT>")
						.ToString(), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[2] { "ゲームデータのみ", "BGM・SE含む" }, 2);
					_0024_0024locals_002421897._0024dlg.ButtonHandler = new _0024_0024main_0024closure_00245090_0024closure_00245091(_0024_0024locals_002421897).Invoke;
					goto case 2;
				case 2:
					if ((bool)_0024_0024locals_002421897._0024dlg)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002421897._0024downLoadType == 1)
					{
						DownloadMain.ChangeTo1stDataDownloadMode(SceneID.Ui_PrologueStart);
					}
					else
					{
						DownloadMain.ChangeTo1stDataAndBGMDownloadMode(SceneID.Ui_PrologueStart);
					}
					SceneChanger.ChangeTo(SceneID.Ui_Download);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	private bool debugDownloadSkip;

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
		return new _0024main_002421887(this).GetEnumerator();
	}

	public void OnGUI()
	{
	}

	internal IEnumerator _0024main_0024closure_00245090()
	{
		return new _0024_0024main_0024closure_00245090_002421893().GetEnumerator();
	}
}
