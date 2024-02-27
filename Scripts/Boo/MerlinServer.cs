using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MerlinServer : MonoBehaviour
{
	[Serializable]
	public class DummyRequest : RequestBase
	{
		public DummyRequest()
		{
			Stealth = true;
		}

		public override IEnumerator sendRoutine()
		{
			Status = 200;
			return null;
		}
	}

	[Serializable]
	internal class _0024communicationError_0024locals_002414443
	{
		internal RequestBase _0024req;
	}

	[Serializable]
	internal class _0024enqueuePrecedingRequets_0024locals_002414444
	{
		internal ApiPlatformAccessInfo _0024aireq;
	}

	[Serializable]
	internal class _0024EditorCommunicationInitialize_0024locals_002414445
	{
		internal ICallable _0024callback;
	}

	[Serializable]
	internal class _0024FatalErrorDialog_0024locals_002414446
	{
		internal ICallable _0024c;
	}

	[Serializable]
	internal class _0024MaintenanceDialog_0024locals_002414447
	{
		internal ICallable _0024c;
	}

	[Serializable]
	internal class _0024communicationError_0024closure_00243976
	{
		internal _0024communicationError_0024locals_002414443 _0024_0024locals_002414994;

		public _0024communicationError_0024closure_00243976(_0024communicationError_0024locals_002414443 _0024_0024locals_002414994)
		{
			this._0024_0024locals_002414994 = _0024_0024locals_002414994;
		}

		public void Invoke()
		{
			try
			{
				if (_0024_0024locals_002414994._0024req != null)
				{
					_0024_0024locals_002414994._0024req.InvokeErrorHandler();
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[Serializable]
	internal class _0024enqueuePrecedingRequets_0024closure_00243978
	{
		internal _0024enqueuePrecedingRequets_0024locals_002414444 _0024_0024locals_002414995;

		public _0024enqueuePrecedingRequets_0024closure_00243978(_0024enqueuePrecedingRequets_0024locals_002414444 _0024_0024locals_002414995)
		{
			this._0024_0024locals_002414995 = _0024_0024locals_002414995;
		}

		public void Invoke(object r2)
		{
			if (!(r2 is ApiEntryCreateUser apiEntryCreateUser))
			{
				throw new AssertionFailedException("r3 != null");
			}
			_0024_0024locals_002414995._0024aireq.uuid = apiEntryCreateUser.uuid;
		}
	}

	[Serializable]
	internal class _0024EditorCommunicationInitialize_0024closure_00243979
	{
		internal _0024EditorCommunicationInitialize_0024locals_002414445 _0024_0024locals_002414996;

		public _0024EditorCommunicationInitialize_0024closure_00243979(_0024EditorCommunicationInitialize_0024locals_002414445 _0024_0024locals_002414996)
		{
			this._0024_0024locals_002414996 = _0024_0024locals_002414996;
		}

		public void Invoke(RequestBase r)
		{
			Instance.StartCoroutine(EditorCommunicationInitializeCallbackRoutine(_0024_0024locals_002414996._0024callback));
		}
	}

	[Serializable]
	internal class _0024EditorCommunicationInitialize_0024closure_00243980
	{
		internal _0024EditorCommunicationInitialize_0024locals_002414445 _0024_0024locals_002414997;

		public _0024EditorCommunicationInitialize_0024closure_00243980(_0024EditorCommunicationInitialize_0024locals_002414445 _0024_0024locals_002414997)
		{
			this._0024_0024locals_002414997 = _0024_0024locals_002414997;
		}

		public void Invoke(RequestBase r)
		{
			Instance.StartCoroutine(EditorCommunicationInitializeCallbackRoutine(_0024_0024locals_002414997._0024callback));
		}
	}

	[Serializable]
	internal class _0024FatalErrorDialog_0024closure_00243984
	{
		internal _0024FatalErrorDialog_0024locals_002414446 _0024_0024locals_002414998;

		public _0024FatalErrorDialog_0024closure_00243984(_0024FatalErrorDialog_0024locals_002414446 _0024_0024locals_002414998)
		{
			this._0024_0024locals_002414998 = _0024_0024locals_002414998;
		}

		public void Invoke()
		{
			ErrorDialogOpened = false;
			if (_0024_0024locals_002414998._0024c != null)
			{
				_0024_0024locals_002414998._0024c.Call(new object[0]);
			}
		}
	}

	[Serializable]
	internal class _0024MaintenanceDialog_0024closure_00243985
	{
		internal _0024MaintenanceDialog_0024locals_002414447 _0024_0024locals_002414999;

		public _0024MaintenanceDialog_0024closure_00243985(_0024MaintenanceDialog_0024locals_002414447 _0024_0024locals_002414999)
		{
			this._0024_0024locals_002414999 = _0024_0024locals_002414999;
		}

		public void Invoke()
		{
			SceneChanger.Kill();
			SceneChanger.Change("Boot");
			if (_0024_0024locals_002414999._0024c != null)
			{
				_0024_0024locals_002414999._0024c.Call(new object[0]);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002419488 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MerlinServer _0024self__002419489;

			public _0024(MerlinServer self_)
			{
				_0024self__002419489 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002419489.forceToRelogin = false;
					goto case 2;
				case 2:
					if (!_0024self__002419489.forceToRelogin)
					{
						_0024self__002419489.UpdateMain();
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002419489.clearRequestStatistics();
					ExRequest(new ApiHome());
					goto default;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MerlinServer _0024self__002419490;

		public _0024main_002419488(MerlinServer self_)
		{
			_0024self__002419490 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419490);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024HomeSlim_002419491 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiHomeSlimStealth _0024r_002419492;

			internal MerlinServer _0024self__002419493;

			public _0024(MerlinServer self_)
			{
				_0024self__002419493 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024r_002419492 = new ApiHomeSlimStealth();
					Request(_0024r_002419492);
					goto case 2;
				case 2:
					if (!_0024r_002419492.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002419493.homeSlimCheckTimer = 20f;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MerlinServer _0024self__002419494;

		public _0024HomeSlim_002419491(MerlinServer self_)
		{
			_0024self__002419494 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002419494);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024EditorCommunicationInitializeCallbackRoutine_002419495 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ICallable _0024callback_002419496;

			public _0024(ICallable callback)
			{
				_0024callback_002419496 = callback;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if (_0024callback_002419496 != null)
					{
						_0024callback_002419496.Call(new object[0]);
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

		internal ICallable _0024callback_002419497;

		public _0024EditorCommunicationInitializeCallbackRoutine_002419495(ICallable callback)
		{
			_0024callback_002419497 = callback;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024callback_002419497);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024CheckBlobSpeedRoutine_0024closure_00243983_002419498 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal byte[] _0024bytes100k_002419499;

			internal string _0024url100k_002419500;

			internal DateTime _0024before100k_002419501;

			internal WWW _0024www100k_002419502;

			internal DateTime _0024after100k_002419503;

			internal TimeSpan _0024time100k_002419504;

			internal byte[] _0024bytes50k_002419505;

			internal string _0024url50k_002419506;

			internal DateTime _0024before50k_002419507;

			internal WWW _0024www50k_002419508;

			internal DateTime _0024after50k_002419509;

			internal TimeSpan _0024time50k_002419510;

			internal float _0024msec100k_002419511;

			internal float _0024size100k_002419512;

			internal float _0024msec50k_002419513;

			internal float _0024size50k_002419514;

			internal float _0024per_002419515;

			internal float _0024msec_002419516;

			internal float _0024size_002419517;

			internal IEnumerator _0024_0024sco_0024temp_00241832_002419518;

			internal __MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ _0024cb_002419519;

			internal MerlinServer _0024self__002419520;

			public _0024(__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ cb, MerlinServer self_)
			{
				_0024cb_002419519 = cb;
				_0024self__002419520 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Busy = true;
					_0024bytes100k_002419499 = null;
					_0024url100k_002419500 = AssetBundlePath.RuntimeDataPath("connect_speed100k");
					_0024before100k_002419501 = DateTime.Now;
					_0024www100k_002419502 = new WWW(_0024url100k_002419500);
					goto case 2;
				case 2:
					if (!_0024www100k_002419502.isDone && _0024www100k_002419502.error == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024after100k_002419503 = DateTime.Now;
					_0024time100k_002419504 = _0024after100k_002419503 - _0024before100k_002419501;
					_0024bytes100k_002419499 = _0024www100k_002419502.bytes;
					_0024bytes50k_002419505 = null;
					_0024url50k_002419506 = AssetBundlePath.RuntimeDataPath("connect_speed50k");
					_0024before50k_002419507 = DateTime.Now;
					_0024www50k_002419508 = new WWW(_0024url50k_002419506);
					goto case 3;
				case 3:
					if (!_0024www50k_002419508.isDone && _0024www50k_002419508.error == null)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024after50k_002419509 = DateTime.Now;
					_0024time50k_002419510 = _0024after50k_002419509 - _0024before50k_002419507;
					_0024bytes50k_002419505 = _0024www50k_002419508.bytes;
					Busy = false;
					_0024msec100k_002419511 = (float)_0024time100k_002419504.TotalMilliseconds;
					_0024size100k_002419512 = _0024bytes100k_002419499.Length;
					_0024msec50k_002419513 = (float)_0024time50k_002419510.TotalMilliseconds;
					_0024size50k_002419514 = _0024bytes50k_002419505.Length;
					_0024per_002419515 = default(float);
					_0024msec_002419516 = _0024msec100k_002419511;
					_0024size_002419517 = _0024size100k_002419512;
					if (!(_0024msec100k_002419511 <= _0024msec50k_002419513))
					{
						_0024msec_002419516 = _0024msec100k_002419511 - _0024msec50k_002419513;
						_0024size_002419517 = _0024size100k_002419512 - _0024size50k_002419514;
					}
					if (!(_0024size_002419517 <= 0f))
					{
						_0024per_002419515 = _0024msec_002419516 / _0024size_002419517;
					}
					_0024_0024sco_0024temp_00241832_002419518 = _0024cb_002419519(_0024per_002419515);
					if (_0024_0024sco_0024temp_00241832_002419518 != null)
					{
						_0024self__002419520.StartCoroutine(_0024_0024sco_0024temp_00241832_002419518);
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

		internal __MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ _0024cb_002419521;

		internal MerlinServer _0024self__002419522;

		public _0024_0024CheckBlobSpeedRoutine_0024closure_00243983_002419498(__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ cb, MerlinServer self_)
		{
			_0024cb_002419521 = cb;
			_0024self__002419522 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024cb_002419521, _0024self__002419522);
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/ServerNego/ServerNego";

	[NonSerialized]
	private static MerlinServer __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public const string DEFAULT_ERR_TITLE = "通信エラー";

	[NonSerialized]
	public const string DEFAULT_ERR_MESSAGE = "通信エラーです";

	[NonSerialized]
	public const string DEFAULT_GOTO_TITLE_MESSAGE = "タイトルに戻ります";

	[NonSerialized]
	public const string NEWAPP_VERSION_TITLE = "新しいバージョンがあります";

	[NonSerialized]
	public const string NEWDATA_VERSION_TITLE = "更新データがあります";

	[NonSerialized]
	public const int CONCURRENT_LIMIT = 1;

	[NonSerialized]
	public static GameApiResponseBase LastGameSrvResponse;

	[NonSerialized]
	protected static bool busy;

	[NonSerialized]
	private static bool _ErrorDialogOpened;

	private bool forceToRelogin;

	public GameObject loadingLabelBgPrefab;

	public Transform loadingLabelBgRoot;

	private UIDynamicFontLabel loadingLabel;

	private GameObject loadingLabelBg;

	private Animation[] loadingAnims;

	public GameObject modalCol;

	public bool modal;

	public bool enableLoadingLabel;

	protected Boo.Lang.List<RequestBase> queuedReqs;

	protected Boo.Lang.List<RequestBase> workingReqs;

	private int count;

	[NonSerialized]
	public static __MerlinServer_Request_0024callable86_0024160_56__ DebugResponseHook;

	private Dictionary<Type, int> requestStatistics;

	[NonSerialized]
	private const float HOME_SLIM_CHECK_SPAN = 20f;

	private float homeSlimCheckTimer;

	[NonSerialized]
	protected const int GAME_DATA_SIZE = 157500000;

	[NonSerialized]
	protected const int SOUND_DATA_SIZE = 27000000;

	[NonSerialized]
	public static Hash ERR_MESSAGES = new Hash
	{
		{ "CoApi001", "通常とは違う形式のデータです" },
		{ "CoApi002", "ユーザー認証の有効期限切れです" },
		{ "CoApi003", "プレイヤー情報を取得できませんでした（#4）" },
		{ "CoApi004", "プレイヤー情報を取得できませんでした（#5）" },
		{ "CoApi005", "データの更新があります\n（#6）" },
		{ "CoApi006", "アプリを最新のバージョンへ\n更新してください" },
		{ "CoApi007", "データの更新があります\n（#8）" },
		{ "CoApi008", "精霊石が不足しています\n（#9）" },
		{ "CoApi009", "通信時の処理に不具合が発生しました（#10）" },
		{ "CoApi010", "利用規約違反のためご利用できません" },
		{ "CoApi011", "ボックスの容量がオーバーしています" },
		{ "CoApi012", "無効なアクセスです" },
		{ "CoApi999", "メンテナンス中です" },
		{ "EnCrt001", "禁止用語を使用しています" },
		{ "UsCrt001", "主人公の名前に禁止用語が含まれています" },
		{ "UsCrt002", "キャラクター作成済みです" },
		{ "PlTuu001", "チュートリアルは終了しています" },
		{ "PlTuu002", "チュートリアルの進行に不具合が発生しました（#19）" },
		{ "PlTuu003", "チュートリアルの進行に不具合が発生しました（#20）" },
		{ "DeDeu001", "無効なアイテムを装備しています" },
		{ "DeDeu002", "装備が重複しています" },
		{ "DeDeu003", "装備の指定に不具合が発生しました" },
		{ "DeDeu004", "メイン武器が装備されていません" },
		{ "QuAck001", "行動力が不足しています" },
		{ "QuAck002", "クエストの進行に不具合が発生しました（#26）" },
		{ "QuAck003", "指定不能なフレンド魔ペットが選択されています（#27）" },
		{ "QuAck004", "有効期間外のクエストが選択されています" },
		{ "QuAck005", "クエストの進行に不具合が発生しました（#29）" },
		{ "QuAck006", "当曜日イベントは終了しています" },
		{ "QuAck007", "精神力が不足しています\n（#31）" },
		{ "QuRlt001", "クエストが開始できません（#32）" },
		{ "QuRlt002", "クエスト情報に差異が発生しています" },
		{ "PuRlt001", "存在しない情報です（#34）" },
		{ "PuRlt002", "アイテム購入時に不具合が発生しました（#35）" },
		{ "PuRlt003", "アイテム購入時に不具合が発生しました（#36）" },
		{ "PuRlt004", "アイテム購入時に不具合が発生しました（#37）" },
		{ "PuRlt005", "すでに購入済みのアイテムです" },
		{ "PuRlt006", "トランザクションを開始できませんでした" },
		{ "PuRlt007", "ポイント消費処理結果のステータスコードが対象外です" },
		{ "PuRlt008", "トランザクションを終了できませんでした" },
		{ "PuRlt009", "所持ポイントを取得できませんでした" },
		{ "CoRlt001", "同じ素材を選択しています" },
		{ "CoRlt002", "所持していない素材が指定されています" },
		{ "CoRlt003", "装備中の武器・魔ペットが素材に指定されています" },
		{ "CoRlt005", "ルクが不足しています" },
		{ "CoRlt004", "進化素材が不足しています" },
		{ "CoRlt006", "進化素材以外の素材が指定されています" },
		{ "GaRlt001", "無効なくじびきが指定されました" },
		{ "GaRlt002", "本日用のくじびきはすでに終了しています" },
		{ "GaRlt003", "フレンドポイントが不足しています" },
		{ "GaRlt004", "精神力が不足しています\n（#65）" },
		{ "GaRlt005", "精霊石が不足しています\n（#66）" },
		{ "GuAck001", "レイドバトルイベントは現在開催されておりません" },
		{ "GuAck002", "御使は発見されていません" },
		{ "GuAck003", "御使は姿を消しました" },
		{ "GuAck004", "精神力が不足しています\n（#70）" },
		{ "GuAck005", "指定不能なフレンド魔ペットが選択されています（#71）" },
		{ "GuAck006", "サーバーに接続できない状態です" },
		{ "GuRlt001", "無効なレイドバトル情報です（#73）" },
		{ "GuRlt002", "無効なレイドバトル情報です（#74）" },
		{ "PrReu001", "無効な情報が指定されました（#75）" },
		{ "PrReu002", "既に受取済みです（#76）" },
		{ "PrReu005", "不正な情報が確認されました（#77）" },
		{ "FrGet001", "検索条件に禁止用語を使用しています" },
		{ "FrApp001", "無効なプレイヤーに申請されました（#79）" },
		{ "FrApp002", "すでにフレンド登録済みです（#80）" },
		{ "FrApp003", "フレンド人数が上限に達しています（#81）" },
		{ "FrApp004", "申請先のプレイヤーのフレンド人数が上限に達しています" },
		{ "FrApp005", "すでにフレンド申請済みです" },
		{ "FrAcc001", "無効な申請です（#84）" },
		{ "FrAcc002", "承認先のプレイヤーのフレンド人数が上限に達しています" },
		{ "FrAcc003", "フレンド人数が上限に達しています（#86）" },
		{ "FrAcc004", "すでにフレンド登録済みです（#87）" },
		{ "FrRej001", "無効な申請です（#88）" },
		{ "FrRem001", "無効なプレイヤーが指定されました" },
		{ "PaInv001", "送信及び受信したプレイヤーが同一です（#90）" },
		{ "PaInv002", "送信したプレイヤーはチームに所属していません（#91）" },
		{ "PaInv003", "受信したプレイヤーはすでにチームに所属しています（#92）" },
		{ "PaInv004", "すでにチームに招待しています" },
		{ "PaAcc001", "無効な申請です（#94）" },
		{ "PaAcc002", "通信時の処理に不具合が発生しました（#95）" },
		{ "PaAcc003", "チームの人数が上限に達しています" },
		{ "PaAcc004", "送信したプレイヤーはすでにチームに所属しています（#97）" },
		{ "PaAcc005", "受信したプレイヤーはチームリーダーではありません（#98）" },
		{ "PaAcc006", "送信したプレイヤーはチームに所属していません（#99）" },
		{ "PaAcc007", "受信したプレイヤーはすでにチームに所属しています（#100）" },
		{ "PaAcc008", "受信したプレイヤーがご本人ではありません（#101）" },
		{ "PaRej001", "受信したプレイヤーがご本人ではありません（#102）" },
		{ "PaRej002", "送信したプレイヤーはチームリーダーではありません" },
		{ "PaKic001", "対象プレイヤーはチームメンバーではありません（#104）" },
		{ "PaKic002", "プレイヤーはチームリーダーではありません" },
		{ "PaApp001", "送信及び受信したプレイヤーが同一です（#106）" },
		{ "PaApp002", "送信したプレイヤーはすでにチームに所属しています（#107）" },
		{ "PaApp003", "受信したプレイヤーはチームリーダーではありません（#108）" },
		{ "PaApp004", "すでに申請しています" },
		{ "PaLCh001", "対象プレイヤーがご本人です" },
		{ "PaLCh002", "チームリーダーのみ使用可能です" },
		{ "PaLCh003", "対象プレイヤーはチームメンバーではありません（#112）" },
		{ "PaLCh004", "すでにリーダー変更依頼を送信済みです" },
		{ "PaLCa001", "リーダー変更依頼に不具合が発生しました" },
		{ "PaLCa002", "チームリーダーのみ承認可能です（#115）" },
		{ "PaLCa003", "受信したプレイヤーがご本人ではありません（#116）" },
		{ "PaLCr001", "チームリーダーのみ承認可能です（#117）" },
		{ "PaLCr002", "受信したプレイヤーがご本人ではありません（#118）" },
		{ "PaCou001", "未使用です（#119）" },
		{ "PaRem001", "チームに所属していません" },
		{ "CoRlR001", "無効なアイテムが指定されました" },
		{ "CoRlR002", "装備中のアイテムが指定されました" },
		{ "TuPut001", "すでに付与されたアイテムです" },
		{ "TuPut002", "無効なアイテムです" },
		{ "BoExt002", "ボックスはこれ以上拡張できません" },
		{ "QuTck001", "当日外のクエストが開放中です" },
		{ "QuTck002", "無効な鍵でクエストを開放しようとしています" },
		{ "CoBst001", "コスト制限違反です" },
		{ "CoBst002", "属性制限違反です" },
		{ "CoBst003", "装備制限違反です" },
		{ "CoBst004", "レアリティ制限違反です（err131）" },
		{ "CoBst005", "レアリティ制限違反です（err132）" },
		{ "CoBst006", "無効な対戦相手が指定されました（err133）" },
		{ "CoBst007", "魔魂力が不足しています" },
		{ "CoBst008", "無効な対戦相手が指定されました（err135）" },
		{ "CoBst009", "援護スキルが当日用に切り替わりました" },
		{ "GuRlt003", "無効なレイドバトル情報です（err137）" }
	};

	public static MerlinServer Instance
	{
		get
		{
			MerlinServer _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((MerlinServer)UnityEngine.Object.FindObjectOfType(typeof(MerlinServer))) as MerlinServer;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static MerlinServer CurrentInstance => __instance;

	public static bool Busy
	{
		get
		{
			return busy;
		}
		set
		{
			busy = value;
		}
	}

	private static bool ErrorDialogOpened
	{
		get
		{
			return _ErrorDialogOpened;
		}
		set
		{
			_ErrorDialogOpened = value;
		}
	}

	public bool IsBusy
	{
		get
		{
			int num;
			if (busy)
			{
				num = 1;
			}
			else
			{
				__MerlinServer_get_IsBusy_0024callable127_002455_17__ _MerlinServer_get_IsBusy_0024callable127_002455_17__ = delegate(IEnumerable<RequestBase> c)
				{
					int num2 = 0;
					IEnumerator<RequestBase> enumerator = c.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							RequestBase current = enumerator.Current;
							if (!(current is DummyRequest) && !(current is ApiHomeSlimStealth) && !current.Stealth)
							{
								num2 = checked(num2 + 1);
							}
						}
						return num2;
					}
					finally
					{
						enumerator.Dispose();
					}
				};
				num = ((_MerlinServer_get_IsBusy_0024callable127_002455_17__(queuedReqs) > 0) ? 1 : 0);
				if (num == 0)
				{
					num = ((_MerlinServer_get_IsBusy_0024callable127_002455_17__(workingReqs) > 0) ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	public bool ForceToRelogin
	{
		get
		{
			return forceToRelogin;
		}
		set
		{
			forceToRelogin = value;
			if (!forceToRelogin)
			{
			}
		}
	}

	public bool EnableLoadingLabel
	{
		get
		{
			return enableLoadingLabel;
		}
		set
		{
			enableLoadingLabel = value;
		}
	}

	public Boo.Lang.List<RequestBase> QueuedReqs => queuedReqs;

	public Boo.Lang.List<RequestBase> WorkingReqs => workingReqs;

	public static int GameDataSize => 157500000;

	public static int SoundDataSize => 27000000;

	public MerlinServer()
	{
		modal = true;
		enableLoadingLabel = true;
		queuedReqs = new Boo.Lang.List<RequestBase>();
		workingReqs = new Boo.Lang.List<RequestBase>();
		requestStatistics = new Dictionary<Type, int>();
		homeSlimCheckTimer = 20f;
	}

	public void _0024singleton_0024awake_00241830()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241830();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static MerlinServer _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/ServerNego/ServerNego");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "MerlinServer" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		MerlinServer merlinServer = ExtensionsModule.SetComponent<MerlinServer>(gameObject2);
		if ((bool)merlinServer)
		{
			merlinServer._createInstance_callback();
		}
		return merlinServer;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241831();
		quitApp = true;
	}

	public static void Reset()
	{
		Instance.disposeRequests();
		busy = false;
		ErrorDialogOpened = false;
	}

	public static void setMember(object obj, string memberName, object val)
	{
		if (obj == null || memberName == null || val == null)
		{
			return;
		}
		Type type = obj.GetType();
		FieldInfo field = type.GetField(memberName, BindingFlags.Instance | BindingFlags.Public);
		if (field == null)
		{
			return;
		}
		if (RuntimeServices.EqualityOperator(field.FieldType, typeof(int)))
		{
			object obj2 = val;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			field.SetValue(obj, int.Parse((string)obj2));
		}
		else
		{
			field.SetValue(obj, val);
		}
	}

	public bool SendRequeset(string strUrl, string strRequest)
	{
		return SendRequesetEx(strUrl, strRequest, null, string.Empty);
	}

	public bool SendRequesetEx(string strUrl, string strRequest, GameObject callBackObj, string callBackFunc)
	{
		int num = 0;
		RequestBase requestBase = null;
		string[] array = strRequest.Split('&');
		int result;
		if (array.Length <= 0)
		{
			result = 0;
		}
		else
		{
			int i = 0;
			string[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				string[] array3 = array2[i].Split('=');
				if (array3.Length != 2)
				{
					continue;
				}
				string text = Uri.UnescapeDataString(array3[0]);
				string text2 = Uri.UnescapeDataString(array3[1]);
				if (text == "command")
				{
					Type type = Type.GetType("MerlinAPI." + text2);
					if (type == null)
					{
						throw new AssertionFailedException("type != null");
					}
					if (type != null)
					{
						object obj = Activator.CreateInstance(type);
						if (!(obj is RequestBase))
						{
							obj = RuntimeServices.Coerce(obj, typeof(RequestBase));
						}
						requestBase = (RequestBase)obj;
						if (requestBase == null)
						{
							throw new AssertionFailedException("req != null");
						}
						queuedReqs.Add(requestBase);
					}
				}
				if (requestBase != null)
				{
					setMember(requestBase, text, text2);
				}
			}
			if (requestBase != null)
			{
				requestBase.CallBackObject = callBackObj;
				requestBase.CallBackFunction = callBackFunc;
			}
			result = ((requestBase != null) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public static void Request(RequestBase req)
	{
		Instance.request(req, exclusive: false, null);
	}

	public static void Request(RequestBase req, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		Instance.request(req, exclusive: false, handler);
	}

	public static void RequestWithoutPrecedingRequests(RequestBase req)
	{
		Instance.request(req, exclusive: false, withoutPrecedingRequests: true, null);
	}

	public static void RequestWithoutPrecedingRequests(RequestBase req, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		Instance.request(req, exclusive: false, withoutPrecedingRequests: true, handler);
	}

	public static void StealthRequest(RequestBase req)
	{
		StealthRequest(req, null);
	}

	public static void StealthRequest(RequestBase req, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		req.retryCount = 3;
		req.Stealth = true;
		req.FinishedHandler = handler;
		Instance.request(req, exclusive: false, null);
	}

	public static void ExRequest(RequestBase req)
	{
		Instance.request(req, exclusive: true, null);
	}

	public static void ExRequest(RequestBase req, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		Instance.request(req, exclusive: true, handler);
	}

	private void request(RequestBase req, bool exclusive, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		request(req, exclusive, withoutPrecedingRequests: false, handler);
	}

	private void request(RequestBase req, bool exclusive, bool withoutPrecedingRequests, __MerlinServer_Request_0024callable86_0024160_56__ handler)
	{
		if (req == null || queuedReqs.Contains(req) || workingReqs.Contains(req))
		{
			throw new AssertionFailedException("((req != null) and (not queuedReqs.Contains(req))) and (not workingReqs.Contains(req))");
		}
		bookkeepRequest(req.GetType());
		if (withoutPrecedingRequests || enqueuePrecedingRequets(req))
		{
			if (handler != null)
			{
				req.Handler = handler;
			}
			req.exclusive = exclusive;
			queuedReqs.Add(req);
		}
	}

	public void Start()
	{
		StartCoroutine(main());
	}

	public void _0024singleton_0024appQuit_00241831()
	{
		UserData.Current.userMiscInfo.Save();
	}

	public void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			UserData.Current.userMiscInfo.Save();
		}
	}

	public IEnumerator main()
	{
		return new _0024main_002419488(this).GetEnumerator();
	}

	private void UpdateMain()
	{
		Recieve();
	}

	public void Update()
	{
		checked
		{
			count++;
			if ((bool)modalCol)
			{
				if (IsBusy && !ErrorDialogOpened)
				{
					modalCol.SetActive(modal);
				}
				else
				{
					modalCol.SetActive(value: false);
				}
			}
			ShowLoading();
		}
	}

	public void ShowLoading()
	{
		if (IsBusy && enableLoadingLabel)
		{
			if (null == loadingLabelBg)
			{
				loadingLabelBg = (GameObject)UnityEngine.Object.Instantiate(loadingLabelBgPrefab);
				if (null != loadingLabelBg)
				{
					loadingLabelBg.SetActive(value: false);
					Vector3 localPosition = loadingLabelBg.transform.localPosition;
					Vector3 localScale = loadingLabelBg.transform.localScale;
					loadingLabelBg.transform.parent = loadingLabelBgRoot;
					loadingLabelBg.transform.localPosition = localPosition;
					loadingLabelBg.transform.localScale = localScale;
					UIAutoTweener[] componentsInChildren = loadingLabelBg.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
					int i = 0;
					UIAutoTweener[] array = componentsInChildren;
					for (int length = array.Length; i < length; i = checked(i + 1))
					{
						array[i].Reset(null);
					}
					loadingLabel = (UIDynamicFontLabel)loadingLabelBg.GetComponentsInChildren<UILabelBase>(includeInactive: true).FirstOrDefault();
					loadingAnims = loadingLabelBg.GetComponentsInChildren<Animation>(includeInactive: true);
				}
			}
			else if (null != loadingLabel)
			{
				loadingLabelBg.SetActive(value: true);
				loadingLabel.gameObject.SetActive(value: true);
				int num = count / 40 % 4;
				if (num == 0)
				{
					loadingLabel.Text = "通信中\u3000\u3000\u3000\u3000";
				}
				if (num == 1)
				{
					loadingLabel.Text = "通信中・\u3000\u3000\u3000";
				}
				if (num == 2)
				{
					loadingLabel.Text = "通信中・・\u3000\u3000";
				}
				if (num == 3)
				{
					loadingLabel.Text = "通信中・・・\u3000";
				}
			}
			if (loadingAnims == null)
			{
				return;
			}
			int j = 0;
			Animation[] array2 = loadingAnims;
			for (int length2 = array2.Length; j < length2; j = checked(j + 1))
			{
				IEnumerator enumerator = array2[j].GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is AnimationState))
					{
						obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
					}
					AnimationState animationState = (AnimationState)obj;
					animationState.speed = 0f;
					animationState.time += Time.unscaledDeltaTime;
				}
				array2[j].Sample();
			}
		}
		else if (null != loadingLabelBg)
		{
			UnityEngine.Object.DestroyObject(loadingLabel);
			UnityEngine.Object.DestroyObject(loadingLabelBg);
			loadingLabelBg = null;
			loadingLabel = null;
			loadingAnims = null;
		}
	}

	public void Recieve()
	{
		RequestBase[] array = (RequestBase[])Builtins.array(typeof(RequestBase), workingReqs);
		bool flag = false;
		IEnumerator enumerator = array.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is RequestBase))
			{
				obj = RuntimeServices.Coerce(obj, typeof(RequestBase));
			}
			RequestBase requestBase = (RequestBase)obj;
			if (requestBase.exclusive)
			{
				flag = true;
			}
			if (requestBase.Status != 0)
			{
				workingReqs.Remove(requestBase);
				requestBase.UpdateParam();
				if (requestBase.ResponseObj is GameApiResponseBase lastGameSrvResponse)
				{
					LastGameSrvResponse = lastGameSrvResponse;
				}
				if (requestBase.IsOk)
				{
					addCurrentUUIDIntoHistory(requestBase);
					try
					{
						requestBase.InvokeHandler();
					}
					catch (Exception)
					{
					}
				}
				else if (!requestBase.ignoreAllErrors)
				{
					GameApiResponseBase gameApiResponseBase = requestBase.ResponseObj as GameApiResponseBase;
					bool flag2 = false;
					if (requestBase is ApiHomeSlimStealth || requestBase.Stealth)
					{
						flag2 = true;
					}
					else if (gameApiResponseBase != null && requestBase.IgnoreErrorCodes != null)
					{
						flag2 = requestBase.ShouldIgnoreError;
					}
					requestBase.ErrorIgnored = flag2;
					communicationError(requestBase, !flag2);
				}
				requestBase.InvokeFinishedHandler();
			}
			else if (requestBase.IsStoppedCoroutine)
			{
				workingReqs.Remove(requestBase);
				requestBase.InvokeFinishedHandler();
			}
		}
		if (flag)
		{
			return;
		}
		while (workingReqs.Count < 1 && queuedReqs.Count > 0)
		{
			RequestBase requestBase2 = queuedReqs[0];
			if (requestBase2 == null)
			{
				throw new AssertionFailedException("req != null");
			}
			if (requestBase2.exclusive && workingReqs.Count > 0)
			{
				break;
			}
			queuedReqs.RemoveAt(0);
			workingReqs.Add(requestBase2);
			if (requestBase2 != null)
			{
				IEnumerator enumerator2 = requestBase2.sendRoutine();
				if (enumerator2 != null)
				{
					StartCoroutine(enumerator2);
				}
			}
			if (requestBase2.exclusive)
			{
				break;
			}
		}
	}

	private void communicationError(RequestBase req, bool showDialog)
	{
		_0024communicationError_0024locals_002414443 _0024communicationError_0024locals_0024 = new _0024communicationError_0024locals_002414443();
		_0024communicationError_0024locals_0024._0024req = req;
		string text = new StringBuilder("通信エラー ").Append(_0024communicationError_0024locals_0024._0024req.GetType()).Append(" - ").Append(_0024communicationError_0024locals_0024._0024req.Result)
			.Append("\n\n")
			.Append(_0024communicationError_0024locals_0024._0024req.Error)
			.ToString();
		object obj = _0024communicationError_0024locals_0024._0024req.ResponseObj;
		if (!(obj is JsonBase))
		{
			obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
		}
		string errorMessage = GetErrorMessage((JsonBase)obj);
		string text2 = SafeGetStatusCode(_0024communicationError_0024locals_0024._0024req);
		if (_0024communicationError_0024locals_0024._0024req.Is500Error || _0024communicationError_0024locals_0024._0024req.Is400Error)
		{
			disposeRequests();
			_0024communicationError_0024locals_0024._0024req.setNotEnd();
			FatalErrorDialog(new StringBuilder("サーバー処理に失敗しました(").Append(text2).Append(")。").ToString(), "通信エラー", text2, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				SceneChanger.Kill();
				if (QuestInitializer.IsInQuest)
				{
					QuestInitializer.DisposeAll();
				}
				SceneChanger.Change("Boot");
			});
			return;
		}
		if (_0024communicationError_0024locals_0024._0024req.UnderMaintenance)
		{
			MaintenanceDialog(_0024communicationError_0024locals_0024._0024req);
			return;
		}
		if (_0024communicationError_0024locals_0024._0024req.GotoBootError)
		{
			disposeRequests();
			_0024communicationError_0024locals_0024._0024req.setNotEnd();
			text = GetErrorMessage(text2, "タイトルに戻ります");
			FatalErrorDialog(text, "通信エラー", text2, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				SceneChanger.Kill();
				if (QuestInitializer.IsInQuest)
				{
					QuestInitializer.DisposeAll();
				}
				SceneChanger.Change("Boot");
			});
			return;
		}
		if (showDialog)
		{
			if (_0024communicationError_0024locals_0024._0024req.HasClientVersionError)
			{
				string text3 = ((!(_0024communicationError_0024locals_0024._0024req.ResponseObj is GameApiResponseBase gameApiResponseBase)) ? "<unknown>" : gameApiResponseBase.ClientVersion);
				disposeRequests();
				_0024communicationError_0024locals_0024._0024req.setNotEnd();
				FatalErrorDialog(errorMessage, "新しいバージョンがあります", text2, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					SceneChanger.Kill();
					if (QuestInitializer.IsInQuest)
					{
						QuestInitializer.DisposeAll();
					}
					SceneChanger.Change("Boot");
					OpenApplicationSite();
				});
				return;
			}
			if (_0024communicationError_0024locals_0024._0024req.HasMasterVersionError || _0024communicationError_0024locals_0024._0024req.HasDataVersionError)
			{
				GameApiResponseBase gameApiResponseBase2 = _0024communicationError_0024locals_0024._0024req.ResponseObj as GameApiResponseBase;
				string text4 = ((gameApiResponseBase2 == null) ? "<unknown>" : gameApiResponseBase2.MasterVersion);
				string text5 = ((gameApiResponseBase2 == null) ? "<unknown>" : gameApiResponseBase2.DataVersion);
				disposeRequests();
				_0024communicationError_0024locals_0024._0024req.setNotEnd();
				FatalErrorDialog(errorMessage, "更新データがあります", text2, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					DownloadMain.ChangeToUpdateMode(SceneID.Boot);
					SceneChanger.Kill();
					if (QuestInitializer.IsInQuest)
					{
						QuestInitializer.DisposeAll();
					}
					SceneChanger.ChangeTo(SceneID.Ui_Download);
				});
				return;
			}
		}
		if (showDialog)
		{
			if (_0024communicationError_0024locals_0024._0024req != null)
			{
				_0024communicationError_0024locals_0024._0024req.InvokePreDialogErrorHandler();
			}
			FatalErrorDialog(errorMessage, "通信エラーです", text2, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024communicationError_0024closure_00243976(_0024communicationError_0024locals_0024).Invoke));
			return;
		}
		try
		{
			if (_0024communicationError_0024locals_0024._0024req != null)
			{
				_0024communicationError_0024locals_0024._0024req.InvokePreDialogErrorHandler();
			}
			if (_0024communicationError_0024locals_0024._0024req != null)
			{
				_0024communicationError_0024locals_0024._0024req.InvokeErrorHandler();
			}
		}
		catch (Exception)
		{
		}
	}

	private void addCurrentUUIDIntoHistory(RequestBase req)
	{
		if (req is ApiHome)
		{
			ApiHome.Resp response = (req as ApiHome).GetResponse();
			if (response != null && response.PlayerInfo != null)
			{
				UUIDHistory.Add(CurrentInfo.UUID, new StringBuilder().Append((object)response.PlayerInfo.TSocialPlayerId).Append(" ").Append(response.Player.Name)
					.Append(" - ")
					.Append(ServerURL.CurrentServerName)
					.ToString());
			}
		}
	}

	private bool enqueuePrecedingRequets(RequestBase r)
	{
		_0024enqueuePrecedingRequets_0024locals_002414444 _0024enqueuePrecedingRequets_0024locals_0024 = new _0024enqueuePrecedingRequets_0024locals_002414444();
		if (r is ApiPlatformExtServer)
		{
			ExRequest(new ApiExamVer());
		}
		int result;
		if (r.Server == ServerType.ExamVer)
		{
			result = 1;
		}
		else
		{
			if (r.Server != ServerType.Platform && notRequested(typeof(ApiPlatformExtServer)))
			{
				ExRequest(new ApiPlatformExtServer());
			}
			if (r is ApiPlatformAccessInfo)
			{
				_0024enqueuePrecedingRequets_0024locals_0024._0024aireq = r as ApiPlatformAccessInfo;
				if (CurrentInfo.HasUUID)
				{
					_0024enqueuePrecedingRequets_0024locals_0024._0024aireq.uuid = CurrentInfo.UUID;
				}
				else
				{
					ApiEntryCreateUser apiEntryCreateUser = new ApiEntryCreateUser();
					string text = (apiEntryCreateUser.uuid = _0024enqueuePrecedingRequets_0024locals_0024._0024aireq.uuid);
					string text2 = (apiEntryCreateUser.name = "私");
					ExRequest(apiEntryCreateUser, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__MerlinServer_Request_0024callable86_0024160_56___0024164.Adapt(new _0024enqueuePrecedingRequets_0024closure_00243978(_0024enqueuePrecedingRequets_0024locals_0024).Invoke));
				}
			}
			else if (r is ApiIsCreate || r is ApiEcho)
			{
				if (notRequested(typeof(ApiPlatformAccessInfo)) && !CurrentInfo.HasToken)
				{
					ExRequest(new ApiPlatformAccessInfo());
				}
			}
			else if (r is ApiCreateCharacter)
			{
				if (notRequested(typeof(ApiPlatformAccessInfo)) && !CurrentInfo.HasToken)
				{
					ExRequest(new ApiPlatformAccessInfo());
				}
			}
			else if (r is ApiWebContact)
			{
				if (notRequested(typeof(ApiPlatformAccessInfo)))
				{
					ExRequest(new ApiPlatformAccessInfo());
				}
			}
			else if (r is ApiHome)
			{
				if (CurrentInfo.NotCreatedCharacter && notRequested(typeof(ApiCreateCharacter)))
				{
					ApiCreateCharacter apiCreateCharacter = new ApiCreateCharacter();
					apiCreateCharacter.AngelName = "てんしさま";
					apiCreateCharacter.AngelGender = 1;
					apiCreateCharacter.DemonName = "あくまさま";
					apiCreateCharacter.AngelGender = 2;
					ExRequest(apiCreateCharacter);
				}
				else if (!CurrentInfo.HasToken && notRequested(typeof(ApiPlatformAccessInfo)))
				{
					ExRequest(new ApiPlatformAccessInfo());
					ExRequest(new ApiGetVersion());
				}
				else if (notRequested(typeof(ApiGetVersion)))
				{
					ExRequest(new ApiGetVersion());
				}
			}
			else if (!(r is ApiGetVersion) && r.Server == ServerType.Game && notRequested(typeof(ApiHome)))
			{
				ExRequest(new ApiHome());
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public void disposeRequests()
	{
		disposeRequests(null);
	}

	public void disposeRequests(RequestBase keep)
	{
		IEnumerator<RequestBase> enumerator = workingReqs.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RequestBase current = enumerator.Current;
				if (!RuntimeServices.EqualityOperator(current, keep))
				{
					current.Dispose();
					current.setNotEnd();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		workingReqs.Clear();
		queuedReqs.Clear();
	}

	public void clearRequestStatistics()
	{
		requestStatistics.Clear();
	}

	private bool notRequested(Type type)
	{
		return !requestStatistics.ContainsKey(type);
	}

	private bool alreadyRequested(Type type)
	{
		return requestStatistics.ContainsKey(type);
	}

	private void bookkeepRequest(Type type)
	{
		if (requestStatistics.ContainsKey(type))
		{
			requestStatistics[type] = checked(requestStatistics[type] + 1);
		}
		else
		{
			requestStatistics[type] = 1;
		}
	}

	public static bool PollingHomeSlim()
	{
		return Instance.PollingHomeSlimSub();
	}

	private bool PollingHomeSlimSub()
	{
		int result;
		if (!Input.GetMouseButton(0) && !CutSceneManager.Instance.exec)
		{
			homeSlimCheckTimer -= Time.deltaTime;
			if (!(homeSlimCheckTimer > 0f))
			{
				homeSlimCheckTimer = float.MaxValue;
				StartCoroutine(HomeSlim());
				result = 1;
				goto IL_0058;
			}
		}
		result = 0;
		goto IL_0058;
		IL_0058:
		return (byte)result != 0;
	}

	private IEnumerator HomeSlim()
	{
		return new _0024HomeSlim_002419491(this).GetEnumerator();
	}

	public static void EditorCommunicationInitialize(ICallable callback)
	{
		_0024EditorCommunicationInitialize_0024locals_002414445 _0024EditorCommunicationInitialize_0024locals_0024 = new _0024EditorCommunicationInitialize_0024locals_002414445();
		_0024EditorCommunicationInitialize_0024locals_0024._0024callback = callback;
		if (Application.isEditor)
		{
			if (_0024EditorCommunicationInitialize_0024locals_0024._0024callback == null)
			{
				throw new AssertionFailedException("待たないと！");
			}
			if (Instance.notRequested(typeof(ApiHome)))
			{
				ExRequest(new ApiHome());
				ExRequest(new DummyRequest(), new _0024EditorCommunicationInitialize_0024closure_00243979(_0024EditorCommunicationInitialize_0024locals_0024).Invoke);
			}
			else
			{
				ExRequest(new DummyRequest(), new _0024EditorCommunicationInitialize_0024closure_00243980(_0024EditorCommunicationInitialize_0024locals_0024).Invoke);
			}
		}
		else
		{
			Instance.StartCoroutine(EditorCommunicationInitializeCallbackRoutine(_0024EditorCommunicationInitialize_0024locals_0024._0024callback));
		}
	}

	private static IEnumerator EditorCommunicationInitializeCallbackRoutine(ICallable callback)
	{
		return new _0024EditorCommunicationInitializeCallbackRoutine_002419495(callback).GetEnumerator();
	}

	public static void Home(__MerlinServer_Home_0024callable87_0024671_34__ c)
	{
		Request(new ApiHome(), _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108.Adapt(c));
	}

	public static void CreateUser(string n, __MerlinServer_CreateUser_0024callable88_0024675_53__ c)
	{
		ApiEntryCreateUser apiEntryCreateUser = new ApiEntryCreateUser();
		string text = (apiEntryCreateUser.name = n);
		Request(apiEntryCreateUser, _0024adaptor_0024__MerlinServer_CreateUser_0024callable88_0024675_53___0024__MerlinServer_Request_0024callable86_0024160_56___0024165.Adapt(c));
	}

	public static void AccessInfo(__MerlinServer_AccessInfo_0024callable89_0024680_40__ c)
	{
		if (!CurrentInfo.HasUUID)
		{
			throw new AssertionFailedException("CurrentInfo.HasUUID");
		}
		ApiPlatformAccessInfo apiPlatformAccessInfo = new ApiPlatformAccessInfo();
		string text = (apiPlatformAccessInfo.uuid = CurrentInfo.UUID);
		ExRequest(apiPlatformAccessInfo, _0024adaptor_0024__MerlinServer_AccessInfo_0024callable89_0024680_40___0024__MerlinServer_Request_0024callable86_0024160_56___0024166.Adapt(c));
	}

	public static void CheckBlobSpeed(__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ callback)
	{
		Instance.CheckBlobSpeedRoutine(callback);
	}

	public void CheckBlobSpeedRoutine(__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ callback)
	{
		if (callback == null)
		{
			throw new AssertionFailedException("callback");
		}
		__MerlinServer_CheckBlobSpeedRoutine_0024callable176_0024696_16__ _MerlinServer_CheckBlobSpeedRoutine_0024callable176_0024696_16__ = (__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ cb) => new _0024_0024CheckBlobSpeedRoutine_0024closure_00243983_002419498(cb, this).GetEnumerator();
		IEnumerator enumerator = _MerlinServer_CheckBlobSpeedRoutine_0024callable176_0024696_16__(callback);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public static void NotifyTutorialStep(int step)
	{
		RespPlayerInfo userStatus = UserData.Current.userStatus;
		if (userStatus != null && userStatus.TutorialStep < step)
		{
			ApiUpdateTutorial apiUpdateTutorial = new ApiUpdateTutorial();
			apiUpdateTutorial.ignoreAllErrors = true;
			apiUpdateTutorial.Stealth = true;
			apiUpdateTutorial.retryCount = 0;
			apiUpdateTutorial.TutorialStep = step;
			Request(apiUpdateTutorial);
		}
	}

	private static string GetErrorMessage(JsonBase resp)
	{
		return GetErrorMessage(resp, "通信エラーです");
	}

	private static string GetErrorMessage(JsonBase resp, string altMsg)
	{
		return (!(resp is GameApiResponseBase)) ? altMsg : GetErrorMessage((resp as GameApiResponseBase).StatusCode, altMsg);
	}

	private static string GetErrorMessage(string statusCode, string altMsg)
	{
		string result = altMsg;
		if (!string.IsNullOrEmpty(statusCode) && ERR_MESSAGES.ContainsKey(statusCode))
		{
			object obj = ERR_MESSAGES[statusCode];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			result = (string)obj;
		}
		return result;
	}

	public static void OpenApplicationSite()
	{
		string text = null;
		text = "https://play.google.com/store/apps/details?id=com.square_enix.android_googleplay.riseofmana1";
		OpenBrowser(text);
	}

	public static void OpenBrowser(string url)
	{
		Application.OpenURL(url);
	}

	public static void FatalErrorDialog(string msg, string title, string errorCode)
	{
		FatalErrorDialog(msg, title, errorCode, null);
	}

	public static void FatalErrorDialog(string msg, string title, string errorCode, ICallable c)
	{
		_0024FatalErrorDialog_0024locals_002414446 _0024FatalErrorDialog_0024locals_0024 = new _0024FatalErrorDialog_0024locals_002414446();
		_0024FatalErrorDialog_0024locals_0024._0024c = c;
		ErrorDialogOpened = true;
		ErrorDialog.FatalError(msg, title, jumpBoot: true, errorCode, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(new _0024FatalErrorDialog_0024closure_00243984(_0024FatalErrorDialog_0024locals_0024).Invoke));
	}

	public static void RetryDialog(ICallable c)
	{
		RetryDialog("リトライします。\n通信状況をご確認ください。", "通信エラー", c);
	}

	public static void RetryDialogForDownload(ICallable c)
	{
		RetryDialog("リトライします。\n通信状況か空き容量を\nご確認ください。", "通信エラー", c);
	}

	public static void RetryDialog(string msg, string title, ICallable c)
	{
		FatalErrorDialog(msg, title, string.Empty, c);
	}

	public static void MaintenanceDialog(RequestBase r)
	{
		MaintenanceDialog(r, null);
	}

	public static void MaintenanceDialog(RequestBase r, ICallable c)
	{
		_0024MaintenanceDialog_0024locals_002414447 _0024MaintenanceDialog_0024locals_0024 = new _0024MaintenanceDialog_0024locals_002414447();
		_0024MaintenanceDialog_0024locals_0024._0024c = c;
		Instance.disposeRequests();
		r?.setNotEnd();
		string moveToUrlUnderMaintenance = r.MoveToUrlUnderMaintenance;
		if (!string.IsNullOrEmpty(moveToUrlUnderMaintenance))
		{
			OpenBrowser(moveToUrlUnderMaintenance);
		}
		string errorMessage = GetErrorMessage("CoApi999", "通信エラーです");
		string title = "通信エラー";
		string errorCode = SafeGetStatusCode(r);
		FatalErrorDialog(errorMessage, title, errorCode, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024MaintenanceDialog_0024closure_00243985(_0024MaintenanceDialog_0024locals_0024).Invoke));
	}

	private static string SafeGetStatusCode(RequestBase req)
	{
		return (req == null) ? string.Empty : ((req.ResponseObj is GameApiResponseBase) ? (req.ResponseObj as GameApiResponseBase).StatusCode : ((req.Response == null || !req.Response.ContainsKey("StatusCode")) ? SafeStringSlice(req.Error, 0, 4) : new StringBuilder().Append(req.Response["StatusCode"]).ToString()));
	}

	private static string SafeStringSlice(string s, int i0, int i1)
	{
		return (!string.IsNullOrEmpty(s)) ? RuntimeServices.Mid(s, i0, i1) : string.Empty;
	}

	internal int _0024get_IsBusy_0024countNonDummy_00242798(IEnumerable<RequestBase> c)
	{
		int num = 0;
		IEnumerator<RequestBase> enumerator = c.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RequestBase current = enumerator.Current;
				if (!(current is DummyRequest) && !(current is ApiHomeSlimStealth) && !current.Stealth)
				{
					num = checked(num + 1);
				}
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024communicationError_0024closure_00243972()
	{
		SceneChanger.Kill();
		if (QuestInitializer.IsInQuest)
		{
			QuestInitializer.DisposeAll();
		}
		SceneChanger.Change("Boot");
	}

	internal void _0024communicationError_0024closure_00243973()
	{
		SceneChanger.Kill();
		if (QuestInitializer.IsInQuest)
		{
			QuestInitializer.DisposeAll();
		}
		SceneChanger.Change("Boot");
	}

	internal void _0024communicationError_0024closure_00243974()
	{
		SceneChanger.Kill();
		if (QuestInitializer.IsInQuest)
		{
			QuestInitializer.DisposeAll();
		}
		SceneChanger.Change("Boot");
		OpenApplicationSite();
	}

	internal void _0024communicationError_0024closure_00243975()
	{
		DownloadMain.ChangeToUpdateMode(SceneID.Boot);
		SceneChanger.Kill();
		if (QuestInitializer.IsInQuest)
		{
			QuestInitializer.DisposeAll();
		}
		SceneChanger.ChangeTo(SceneID.Ui_Download);
	}

	internal IEnumerator _0024CheckBlobSpeedRoutine_0024closure_00243983(__MerlinServer_CheckBlobSpeed_0024callable90_0024691_44__ cb)
	{
		return new _0024_0024CheckBlobSpeedRoutine_0024closure_00243983_002419498(cb, this).GetEnumerator();
	}
}
