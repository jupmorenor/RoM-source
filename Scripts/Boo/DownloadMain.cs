using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DownloadMain : UIMain
{
	[Serializable]
	public enum Mode
	{
		All,
		AllWithoutBgm,
		BgmOnly,
		Update
	}

	[Serializable]
	internal class _0024downloadResourceHash_0024locals_002414501
	{
		internal bool _0024endOfDL;
	}

	[Serializable]
	internal class _0024downloadMaster_0024locals_002414502
	{
		internal byte[] _0024bytes;

		internal string _0024savePath;
	}

	[Serializable]
	internal class _0024downloadResourceHash_0024closure_00243990
	{
		internal DownloadMain _0024this_002415098;

		internal _0024downloadResourceHash_0024locals_002414501 _0024_0024locals_002415099;

		public _0024downloadResourceHash_0024closure_00243990(DownloadMain _0024this_002415098, _0024downloadResourceHash_0024locals_002414501 _0024_0024locals_002415099)
		{
			this._0024this_002415098 = _0024this_002415098;
			this._0024_0024locals_002415099 = _0024_0024locals_002415099;
		}

		public void Invoke(WWW www)
		{
			if (www != null)
			{
				string text = www.text;
				_0024this_002415098.resourceHash = NGUIJson.jsonDecode(text) as Hashtable;
				LastLoadedResourceHash = _0024this_002415098.resourceHash.Clone() as Hashtable;
				if (LastLoadedResourceHash == null)
				{
					throw new AssertionFailedException("LastLoadedResourceHash != null");
				}
				PlayerPrefs.SetString("Merlin-Resource-Hash", text);
				PlayerPrefs.Save();
			}
			_0024_0024locals_002415099._0024endOfDL = true;
		}
	}

	[Serializable]
	internal class _0024downloadMaster_0024closure_00243991
	{
		internal _0024downloadMaster_0024locals_002414502 _0024_0024locals_002415100;

		public _0024downloadMaster_0024closure_00243991(_0024downloadMaster_0024locals_002414502 _0024_0024locals_002415100)
		{
			this._0024_0024locals_002415100 = _0024_0024locals_002415100;
		}

		public void Invoke(WWW www)
		{
			if (www != null)
			{
				_0024_0024locals_002415100._0024bytes = www.bytes;
			}
		}
	}

	[Serializable]
	internal class _0024downloadMaster_0024closure_00243992
	{
		internal _0024downloadMaster_0024locals_002414502 _0024_0024locals_002415101;

		public _0024downloadMaster_0024closure_00243992(_0024downloadMaster_0024locals_002414502 _0024_0024locals_002415101)
		{
			this._0024_0024locals_002415101 = _0024_0024locals_002415101;
		}

		public void Invoke()
		{
			File.WriteAllBytes(_0024_0024locals_002415101._0024savePath, _0024_0024locals_002415101._0024bytes);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024downloadMain_002421586 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242589_002421587;

			internal IEnumerator _0024_0024sco_0024temp_00242590_002421588;

			internal IEnumerator _0024_0024sco_0024temp_00242591_002421589;

			internal IEnumerator _0024_0024sco_0024temp_00242592_002421590;

			internal IEnumerator _0024_0024sco_0024temp_00242593_002421591;

			internal IEnumerator _0024_0024sco_0024temp_00242594_002421592;

			internal IEnumerator _0024_0024sco_0024temp_00242595_002421593;

			internal IEnumerator _0024_0024sco_0024temp_00242596_002421594;

			internal DownloadMain _0024self__002421595;

			public _0024(DownloadMain self_)
			{
				_0024self__002421595 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421595.logDownloadInfo();
					_0024_0024wait_sec_0024temp_00242589_002421587 = 1.5f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242589_002421587 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242589_002421587 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421595.startProgressBarUpdate();
					_0024_0024sco_0024temp_00242590_002421588 = _0024self__002421595.dlmInit();
					if (_0024_0024sco_0024temp_00242590_002421588 != null)
					{
						result = (Yield(3, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242590_002421588)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024_0024sco_0024temp_00242591_002421589 = _0024self__002421595.dlmDownload();
					if (_0024_0024sco_0024temp_00242591_002421589 != null)
					{
						result = (Yield(4, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242591_002421589)) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					_0024_0024sco_0024temp_00242592_002421590 = _0024self__002421595.dlmWaitAllDownload();
					if (_0024_0024sco_0024temp_00242592_002421590 != null)
					{
						result = (Yield(5, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242592_002421590)) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					_0024self__002421595.dlmCacheCheck();
					_0024self__002421595.dlmStartIconAtlasInit();
					_0024_0024sco_0024temp_00242593_002421591 = _0024self__002421595.dlmWaitMasterLoad();
					if (_0024_0024sco_0024temp_00242593_002421591 != null)
					{
						result = (Yield(6, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242593_002421591)) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					_0024_0024sco_0024temp_00242594_002421592 = _0024self__002421595.dlmWaitIconAtlasInit();
					if (_0024_0024sco_0024temp_00242594_002421592 != null)
					{
						result = (Yield(7, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242594_002421592)) ? 1 : 0);
						break;
					}
					goto case 7;
				case 7:
					_0024self__002421595.dlmSetVersions();
					_0024self__002421595.dlmPostSoundInit(needBgmBundleDownload(), initialDownload);
					_0024self__002421595.fixProgressBar(1f);
					if (!initialDownload)
					{
						_0024_0024sco_0024temp_00242595_002421593 = _0024self__002421595.dlmReqApiHome();
						if (_0024_0024sco_0024temp_00242595_002421593 != null)
						{
							result = (Yield(8, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242595_002421593)) ? 1 : 0);
							break;
						}
					}
					goto case 8;
				case 8:
					_0024_0024sco_0024temp_00242596_002421594 = _0024self__002421595.dlmPostDownloadUserOperation();
					if (_0024_0024sco_0024temp_00242596_002421594 != null)
					{
						result = (Yield(9, _0024self__002421595.StartCoroutine(_0024_0024sco_0024temp_00242596_002421594)) ? 1 : 0);
						break;
					}
					goto case 9;
				case 9:
					_0024self__002421595.dlmFinishAndChangeScene();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DownloadMain _0024self__002421596;

		public _0024downloadMain_002421586(DownloadMain self_)
		{
			_0024self__002421596 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421596);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmInit_002421597 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DownloadMain _0024self__002421598;

			public _0024(DownloadMain self_)
			{
				_0024self__002421598 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					IconAtlasPool.DestroyInstance();
					PlayerPoppetCache.Instance.dispose();
					AssetBundleLoader.DestroyAll();
					goto case 2;
				case 2:
					if (!Caching.ready)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002421598.resourceHash = null;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DownloadMain _0024self__002421599;

		public _0024dlmInit_002421597(DownloadMain self_)
		{
			_0024self__002421599 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421599);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmDownload_002421600 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242597_002421601;

			internal IEnumerator _0024_0024sco_0024temp_00242598_002421602;

			internal IEnumerator _0024_0024sco_0024temp_00242599_002421603;

			internal IEnumerator _0024_0024sco_0024temp_00242600_002421604;

			internal DownloadMain _0024self__002421605;

			public _0024(DownloadMain self_)
			{
				_0024self__002421605 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421605.needUpdateMaster())
					{
						_0024_0024sco_0024temp_00242597_002421601 = _0024self__002421605.downloadMaster();
						if (_0024_0024sco_0024temp_00242597_002421601 != null)
						{
							_0024self__002421605.StartCoroutine(_0024_0024sco_0024temp_00242597_002421601);
						}
					}
					_0024_0024sco_0024temp_00242598_002421602 = _0024self__002421605.updateResourceHash(IsBgmOnly);
					if (_0024_0024sco_0024temp_00242598_002421602 != null)
					{
						result = (Yield(2, _0024self__002421605.StartCoroutine(_0024_0024sco_0024temp_00242598_002421602)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (_0024self__002421605.needUpdateAssetBundles())
					{
						_0024_0024sco_0024temp_00242599_002421603 = _0024self__002421605.downloadAssetBundleDB();
						if (_0024_0024sco_0024temp_00242599_002421603 != null)
						{
							_0024self__002421605.StartCoroutine(_0024_0024sco_0024temp_00242599_002421603);
						}
						_0024_0024sco_0024temp_00242600_002421604 = _0024self__002421605.downloadAllAssetBundles(_0024self__002421605.resourceHash);
						if (_0024_0024sco_0024temp_00242600_002421604 != null)
						{
							result = (Yield(3, _0024self__002421605.StartCoroutine(_0024_0024sco_0024temp_00242600_002421604)) ? 1 : 0);
							break;
						}
					}
					goto case 3;
				case 3:
				case 4:
					if (_0024self__002421605.WorkingReqNum > 0)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
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

		internal DownloadMain _0024self__002421606;

		public _0024dlmDownload_002421600(DownloadMain self_)
		{
			_0024self__002421606 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421606);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmWaitAllDownload_002421607 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal DownloadMain _0024self__002421608;

			public _0024(DownloadMain self_)
			{
				_0024self__002421608 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421608.WorkingReqNum > 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal DownloadMain _0024self__002421609;

		public _0024dlmWaitAllDownload_002421607(DownloadMain self_)
		{
			_0024self__002421609 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421609);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmWaitMasterLoad_002421610 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024cnt_002421611;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (1 == 0)
					{
						goto case 1;
					}
					_0024cnt_002421611 = 0;
					goto case 2;
				case 2:
					if (ClientMasterArchive.IsReadingMasterArchive())
					{
						if (checked(++_0024cnt_002421611) > 60)
						{
							_0024cnt_002421611 = 0;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmWaitIconAtlasInit_002421612 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (IconAtlasPool.IsLoading)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		public override IEnumerator<object> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmReqApiHome_002421613 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiHome _0024r_002421614;

			internal ApiCampaignURLScheme _0024ffrkReq_002421615;

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024r_002421614 = new ApiHome();
					MerlinServer.Request(_0024r_002421614);
					goto case 2;
				case 2:
					if (!_0024r_002421614.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024ffrkReq_002421615 = ApiCampaignURLScheme.CreateFFRKColaboApiReq();
					if (_0024ffrkReq_002421615 != null)
					{
						MerlinServer.Request(_0024ffrkReq_002421615);
						goto case 3;
					}
					goto IL_0094;
				case 3:
					if (!_0024ffrkReq_002421615.IsEnd)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_0094;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0094:
					YieldDefault(1);
					goto case 1;
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

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024dlmPostDownloadUserOperation_002421616 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242601_002421617;

			internal IEnumerator _0024_0024sco_0024temp_00242602_002421618;

			internal DownloadMain _0024self__002421619;

			public _0024(DownloadMain self_)
			{
				_0024self__002421619 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00242601_002421617 = _0024self__002421619.displayNewFeatureDetailRoutine();
					if (_0024_0024sco_0024temp_00242601_002421617 != null)
					{
						result = (Yield(2, _0024self__002421619.StartCoroutine(_0024_0024sco_0024temp_00242601_002421617)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (mode != Mode.BgmOnly)
					{
						_0024_0024sco_0024temp_00242602_002421618 = _0024self__002421619.openControlSettingPanel();
						if (_0024_0024sco_0024temp_00242602_002421618 != null)
						{
							result = (Yield(3, _0024self__002421619.StartCoroutine(_0024_0024sco_0024temp_00242602_002421618)) ? 1 : 0);
							break;
						}
					}
					goto case 3;
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DownloadMain _0024self__002421620;

		public _0024dlmPostDownloadUserOperation_002421616(DownloadMain self_)
		{
			_0024self__002421620 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421620);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024updateResourceHash_002421621 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242603_002421622;

			internal bool _0024loadFromCachedResourceHash_002421623;

			internal DownloadMain _0024self__002421624;

			public _0024(bool loadFromCachedResourceHash, DownloadMain self_)
			{
				_0024loadFromCachedResourceHash_002421623 = loadFromCachedResourceHash;
				_0024self__002421624 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024loadFromCachedResourceHash_002421623)
					{
						_0024self__002421624.resourceHash = _0024self__002421624.getBgmInfo(LoadCachedResourceHash());
						goto IL_00b6;
					}
					_0024_0024sco_0024temp_00242603_002421622 = _0024self__002421624.downloadResourceHash();
					if (_0024_0024sco_0024temp_00242603_002421622 != null)
					{
						result = (Yield(2, _0024self__002421624.StartCoroutine(_0024_0024sco_0024temp_00242603_002421622)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					if (!needBgmBundleDownload())
					{
						_0024self__002421624.resourceHash = _0024self__002421624.eliminateBgmBundleInfo(_0024self__002421624.resourceHash);
					}
					goto IL_00b6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00b6:
					if (_0024self__002421624.resourceHash == null)
					{
						throw new AssertionFailedException("resourceHash != null");
					}
					_0024self__002421624.dumpResourceHash(_0024self__002421624.resourceHash);
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024loadFromCachedResourceHash_002421625;

		internal DownloadMain _0024self__002421626;

		public _0024updateResourceHash_002421621(bool loadFromCachedResourceHash, DownloadMain self_)
		{
			_0024loadFromCachedResourceHash_002421625 = loadFromCachedResourceHash;
			_0024self__002421626 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024loadFromCachedResourceHash_002421625, _0024self__002421626);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024downloadResourceHash_002421627 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal __DownloadRequest_0024callable108_002416_75__ _0024cb_002421628;

			internal string _0024url_002421629;

			internal DownloadRequest _0024r_002421630;

			internal _0024downloadResourceHash_0024locals_002414501 _0024_0024locals_002421631;

			internal DownloadMain _0024self__002421632;

			public _0024(DownloadMain self_)
			{
				_0024self__002421632 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421631 = new _0024downloadResourceHash_0024locals_002414501();
					_0024_0024locals_002421631._0024endOfDL = false;
					_0024cb_002421628 = new _0024downloadResourceHash_0024closure_00243990(_0024self__002421632, _0024_0024locals_002421631).Invoke;
					_0024url_002421629 = AssetBundlePath.RuntimeRoutingFileURL(_0024self__002421632.targetDataVersion);
					_0024r_002421630 = _0024self__002421632.reqDownload(_0024url_002421629, _0024cb_002421628);
					_0024r_002421630.Size = 6551f;
					goto case 2;
				case 2:
					if (!_0024_0024locals_002421631._0024endOfDL)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal DownloadMain _0024self__002421633;

		public _0024downloadResourceHash_002421627(DownloadMain self_)
		{
			_0024self__002421633 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421633);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024downloadMaster_002421634 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal __DownloadRequest_0024callable108_002416_75__ _0024cb_002421635;

			internal string _0024url_002421636;

			internal DownloadRequest _0024r_002421637;

			internal _0024downloadMaster_0024locals_002414502 _0024_0024locals_002421638;

			internal DownloadMain _0024self__002421639;

			public _0024(DownloadMain self_)
			{
				_0024self__002421639 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421638 = new _0024downloadMaster_0024locals_002414502();
					_0024_0024locals_002421638._0024bytes = null;
					_0024cb_002421635 = new _0024downloadMaster_0024closure_00243991(_0024_0024locals_002421638).Invoke;
					_0024url_002421636 = AssetBundlePath.RuntimeMasterZipURL(_0024self__002421639.targetMasterVersion);
					_0024r_002421637 = _0024self__002421639.reqDownload(_0024url_002421636, _0024cb_002421635);
					_0024r_002421637.Size = 875053f;
					goto case 2;
				case 2:
					if (!_0024r_002421637.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (1 == 0)
					{
						result = (Yield(3, _0024self__002421639.StartCoroutine(ClientMasterArchive.ReadMasterArchiveCoroutine(_0024_0024locals_002421638._0024bytes))) ? 1 : 0);
						break;
					}
					_0024_0024locals_002421638._0024savePath = ClientMasterArchive.GetDefaultMasterArchivePath();
					ClientMasterArchive.ReadMasterArchiveASync(_0024_0024locals_002421638._0024bytes, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024downloadMaster_0024closure_00243992(_0024_0024locals_002421638).Invoke));
					goto IL_0130;
				case 3:
					File.WriteAllBytes(ClientMasterArchive.GetDefaultMasterArchivePath(), _0024_0024locals_002421638._0024bytes);
					goto IL_0130;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0130:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal DownloadMain _0024self__002421640;

		public _0024downloadMaster_002421634(DownloadMain self_)
		{
			_0024self__002421640 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421640);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024downloadAssetBundleDB_002421641 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal __DownloadRequest_0024callable108_002416_75__ _0024cb_002421642;

			internal string _0024url_002421643;

			internal DownloadRequest _0024r_002421644;

			internal DownloadMain _0024self__002421645;

			public _0024(DownloadMain self_)
			{
				_0024self__002421645 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024cb_002421642 = delegate(WWW www)
					{
						if (www != null)
						{
							RuntimeAssetBundleDB.Instance.initialize(www.text);
						}
					};
					RuntimeAssetBundleDB.Instance.unloadAll();
					_0024url_002421643 = AssetBundlePath.RuntimeAssetBundleDBJsonURL(_0024self__002421645.targetDataVersion);
					_0024r_002421644 = _0024self__002421645.reqDownload(_0024url_002421643, _0024cb_002421642);
					_0024r_002421644.Size = 482849f;
					goto case 2;
				case 2:
					if (!_0024r_002421644.IsOk)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal DownloadMain _0024self__002421646;

		public _0024downloadAssetBundleDB_002421641(DownloadMain self_)
		{
			_0024self__002421646 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421646);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024downloadAllAssetBundles_002421647 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Boo.Lang.List<string> _0024ablist_002421648;

			internal string _0024key_002421649;

			internal string _0024url_002421650;

			internal int _0024avail_002421651;

			internal IEnumerator<string> _0024_0024iterator_002414162_002421652;

			internal Hashtable _0024hash_002421653;

			internal DownloadMain _0024self__002421654;

			public _0024(Hashtable hash, DownloadMain self_)
			{
				_0024hash_002421653 = hash;
				_0024self__002421654 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!Caching.ready)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024ablist_002421648 = GetAssetBundleFiles(_0024hash_002421653);
					_0024_0024iterator_002414162_002421652 = _0024ablist_002421648.GetEnumerator();
					try
					{
						while (_0024_0024iterator_002414162_002421652.MoveNext())
						{
							_0024key_002421649 = _0024_0024iterator_002414162_002421652.Current;
							_0024url_002421650 = AssetBundlePath.RuntimeAssetBundleURL(_0024key_002421649, _0024self__002421654.targetDataVersion);
							_0024self__002421654.reqAssetBundleDownload(_0024hash_002421653, _0024url_002421650);
						}
					}
					finally
					{
						_0024_0024iterator_002414162_002421652.Dispose();
					}
					goto case 3;
				case 3:
					if (_0024self__002421654.PendingNum > 0)
					{
						_0024avail_002421651 = checked(10 - _0024self__002421654.WorkingReqNum);
						if (_0024avail_002421651 > 0)
						{
							_0024self__002421654.startPendingRequests(_0024avail_002421651);
						}
						result = (YieldDefault(3) ? 1 : 0);
						break;
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

		internal Hashtable _0024hash_002421655;

		internal DownloadMain _0024self__002421656;

		public _0024downloadAllAssetBundles_002421647(Hashtable hash, DownloadMain self_)
		{
			_0024hash_002421655 = hash;
			_0024self__002421656 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024hash_002421655, _0024self__002421656);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024displayNewFeatureDetailRoutine_002421657 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal NewFeatureDisplay _0024nfd_002421658;

			internal DownloadMain _0024self__002421659;

			public _0024(DownloadMain self_)
			{
				_0024self__002421659 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024nfd_002421658 = ExtensionsModule.SetComponent<NewFeatureDisplay>(_0024self__002421659.gameObject);
					_0024nfd_002421658.show();
					goto case 2;
				case 2:
					if (!_0024nfd_002421658.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
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

		internal DownloadMain _0024self__002421660;

		public _0024displayNewFeatureDetailRoutine_002421657(DownloadMain self_)
		{
			_0024self__002421660 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421660);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024openControlSettingPanel_002421661 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00242604_002421662;

			internal DownloadMain _0024self__002421663;

			public _0024(DownloadMain self_)
			{
				_0024self__002421663 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421663.downloadControlSetting = new DownloadControlSetting(_0024self__002421663.controllSettings, "PushPadOK");
					if (_0024self__002421663.downloadControlSetting.needControlSetting() || _0024self__002421663.debugPadSetting)
					{
						_0024self__002421663.debugPadSetting = false;
						_0024_0024sco_0024temp_00242604_002421662 = _0024self__002421663.downloadControlSetting.OpenControllSetting(_0024self__002421663.gameObject);
						if (_0024_0024sco_0024temp_00242604_002421662 != null)
						{
							result = (Yield(2, _0024self__002421663.StartCoroutine(_0024_0024sco_0024temp_00242604_002421662)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal DownloadMain _0024self__002421664;

		public _0024openControlSettingPanel_002421661(DownloadMain self_)
		{
			_0024self__002421664 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002421664);
		}
	}

	public UISlider gauge;

	public UILabel gaugeText;

	[NonSerialized]
	public const float MINIMUN_DOWNLOAD_MODE_TIME = 2f;

	public float tipsShowTime;

	public UILabelBase tipsTitle;

	public UILabelBase tipsMessage;

	public GameObject touchArea;

	public GameObject NormalBG;

	public GameObject FirstAndBGMBG;

	public GameObject controllSettings;

	[NonSerialized]
	private const bool USE_CONTROLL_SETTING_FLAG = true;

	[NonSerialized]
	private const bool SCREEN_TEST_MODE = false;

	[NonSerialized]
	private const int MAX_CONCURRENT_DOWNLOAD = 10;

	[NonSerialized]
	private const bool LOAD_MASTER_ASYNC = true;

	[NonSerialized]
	private const string PREFS_KEY_RESOURCE_HASH = "Merlin-Resource-Hash";

	[NonSerialized]
	private const string BGM_FILENAME_PREFIX = "BGM";

	[NonSerialized]
	private const int ROUGH_MASTER_ZIP_SIZE = 875053;

	[NonSerialized]
	private const int ROUGH_RESOURCEHASH_SIZE = 6551;

	[NonSerialized]
	private const int ROUGH_RUNTIME_ASSET_BUNDLE_DB_JSON_SIZE = 482849;

	private string targetClientVersion;

	private string targetDataVersion;

	private string targetMasterVersion;

	[NonSerialized]
	private static Mode mode = Mode.All;

	[NonSerialized]
	private static bool initialDownload;

	[NonSerialized]
	private static SceneID backSceneID = SceneID.Boot;

	[NonSerialized]
	private static Hashtable LastLoadedResourceHash;

	private Hashtable resourceHash;

	private bool endControllSetting;

	private bool isErrorMode;

	private bool progressBarEnabled;

	private Queue<DownloadRequest> pendingQueue;

	private Boo.Lang.List<DownloadRequest> workingRequests;

	private Boo.Lang.List<DownloadRequest> allRequests;

	private DownloadTips downloadTipsControl;

	private DownloadControlSetting downloadControlSetting;

	private bool debugPadSetting;

	public static Hashtable ResourceHash
	{
		get
		{
			if (LastLoadedResourceHash == null)
			{
				LastLoadedResourceHash = LoadCachedResourceHash();
			}
			return LastLoadedResourceHash;
		}
	}

	private static bool IsBgmOnly => mode == Mode.BgmOnly;

	private int WorkingReqNum => workingRequests.Count;

	private int PendingNum => pendingQueue.Count;

	private int AllReqNum => allRequests.Count;

	public DownloadMain()
	{
		tipsShowTime = 5f;
		pendingQueue = new Queue<DownloadRequest>();
		workingRequests = new Boo.Lang.List<DownloadRequest>();
		allRequests = new Boo.Lang.List<DownloadRequest>();
	}

	public static void ChangeToBGMDownloadMode(SceneID sceneID)
	{
		mode = Mode.BgmOnly;
		backSceneID = sceneID;
	}

	public static void ChangeToUpdateMode(SceneID sceneID)
	{
		mode = Mode.Update;
		backSceneID = SceneID.Boot;
	}

	public static void ChangeTo1stDataDownloadMode(SceneID sceneID)
	{
		mode = Mode.AllWithoutBgm;
		initialDownload = true;
		backSceneID = sceneID;
	}

	public static void ChangeTo1stDataAndBGMDownloadMode(SceneID sceneID)
	{
		mode = Mode.All;
		initialDownload = true;
		backSceneID = sceneID;
	}

	public static bool IsBgmCached()
	{
		Hashtable hashtable = ResourceHash;
		int result;
		if (hashtable == null)
		{
			result = 0;
		}
		else
		{
			string text = AssetBundleLoader.BundleURL("BGM");
			int assetBundleVersion = DownloadUtil.GetAssetBundleVersion(hashtable, text);
			bool flag = Caching.IsVersionCached(text, assetBundleVersion);
			result = (flag ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public static void ClearAll()
	{
		PlayerPrefs.DeleteKey("Merlin-Resource-Hash");
		PlayerPrefs.Save();
		LastLoadedResourceHash = null;
	}

	public override void SceneStart()
	{
		GameApiResponseBase lastGameSrvResponse = MerlinServer.LastGameSrvResponse;
		if (lastGameSrvResponse == null)
		{
			targetClientVersion = new StringBuilder().Append((object)CurrentBuildableVersion.CLIENT_VERSION).ToString();
			targetDataVersion = new StringBuilder().Append((object)CurrentBuildableVersion.DATA_VERSION).ToString();
			targetMasterVersion = new StringBuilder().Append((object)CurrentBuildableVersion.MASTER_VERSION).ToString();
		}
		else
		{
			targetClientVersion = lastGameSrvResponse.ClientVersion;
			targetDataVersion = lastGameSrvResponse.DataVersion;
			targetMasterVersion = lastGameSrvResponse.MasterVersion;
		}
		InitBG();
		downloadTipsControl = new DownloadTips(tipsShowTime, tipsTitle, tipsMessage, touchArea);
		startDownload();
	}

	protected override void SceneUpdate()
	{
		updateDownloadRequests();
		if (downloadTipsControl != null)
		{
			downloadTipsControl.UpdateTips();
		}
		updateProgressBar();
	}

	private void startDownload()
	{
		if (0 == 0)
		{
			IEnumerator enumerator = downloadMain();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void OnEnable()
	{
		DisableSleep();
	}

	public new void OnDisable()
	{
		EnableSleep();
	}

	public void OnDestroy()
	{
		EnableSleep();
		IEnumerator<DownloadRequest> enumerator = allRequests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				current.dispose();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		pendingQueue.Clear();
		workingRequests.Clear();
		allRequests.Clear();
	}

	public void OnApplicationQuit()
	{
		EnableSleep();
	}

	public void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			DisableSleep();
		}
		else
		{
			EnableSleep();
		}
	}

	private static void DisableSleep()
	{
		Screen.sleepTimeout = -1;
	}

	private static void EnableSleep()
	{
		Screen.sleepTimeout = -2;
	}

	private void updateDownloadRequests()
	{
		if (isErrorMode)
		{
			updateErrorMode();
		}
		else
		{
			updateWorkingRequests();
		}
	}

	private void updateWorkingRequests()
	{
		IEnumerator<DownloadRequest> enumerator = workingRequests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				current.update();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		workingRequests.RemoveAll(_0024adaptor_0024__DownloadMain_0024callable364_0024273_36___0024Predicate_0024187.Adapt((DownloadRequest r) => r.IsOk));
		IEnumerator<DownloadRequest> enumerator2 = workingRequests.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				DownloadRequest current2 = enumerator2.Current;
				if (current2.IsError)
				{
					isErrorMode = true;
					MerlinServer.RetryDialogForDownload((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						isErrorMode = false;
					});
					break;
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	private void updateErrorMode()
	{
		IEnumerator<DownloadRequest> enumerator = workingRequests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				current.resetDownloadIfError();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private IEnumerator downloadMain()
	{
		return new _0024downloadMain_002421586(this).GetEnumerator();
	}

	private IEnumerator dlmInit()
	{
		return new _0024dlmInit_002421597(this).GetEnumerator();
	}

	private IEnumerator dlmDownload()
	{
		return new _0024dlmDownload_002421600(this).GetEnumerator();
	}

	private IEnumerator dlmWaitAllDownload()
	{
		return new _0024dlmWaitAllDownload_002421607(this).GetEnumerator();
	}

	private void dlmCacheCheck()
	{
		if (!isCachedCompletely())
		{
			assetBundleCacheError();
		}
	}

	private IEnumerator dlmWaitMasterLoad()
	{
		return new _0024dlmWaitMasterLoad_002421610().GetEnumerator();
	}

	private void dlmStartIconAtlasInit()
	{
		IconAtlasPool.InitFromAssetbundles();
	}

	private IEnumerator dlmWaitIconAtlasInit()
	{
		return new _0024dlmWaitIconAtlasInit_002421612().GetEnumerator();
	}

	private void dlmPostSoundInit(bool needBgmInit, bool needCommonSEInit)
	{
		if (needBgmInit)
		{
			UserMiscInfo userMiscInfo = UserData.Current.userMiscInfo;
			userMiscInfo.bgmLoad = IsBgmCached();
			GameSoundManager.Reset = true;
		}
		GameSoundManager.Instance.InitSeTableBySeMaster();
		if (needCommonSEInit)
		{
			GameSoundManager.Instance.LoadCommonSeFromBinPack();
		}
	}

	private IEnumerator dlmReqApiHome()
	{
		return new _0024dlmReqApiHome_002421613().GetEnumerator();
	}

	private void dlmSetVersions()
	{
		CurrentInfo.MasterVersion = targetMasterVersion;
		CurrentInfo.DataVersion = targetDataVersion;
		CurrentInfo.DownloadCompleted = true;
		CurrentInfo.SetAppVerOnLastDownloadAsCurrentVer();
	}

	private IEnumerator dlmPostDownloadUserOperation()
	{
		return new _0024dlmPostDownloadUserOperation_002421616(this).GetEnumerator();
	}

	private void dlmFinishAndChangeScene()
	{
		SceneChanger.ChangeTo(backSceneID);
		backSceneID = SceneID.Boot;
		mode = Mode.All;
		initialDownload = false;
	}

	private IEnumerator updateResourceHash(bool loadFromCachedResourceHash)
	{
		return new _0024updateResourceHash_002421621(loadFromCachedResourceHash, this).GetEnumerator();
	}

	private IEnumerator downloadResourceHash()
	{
		return new _0024downloadResourceHash_002421627(this).GetEnumerator();
	}

	private IEnumerator downloadMaster()
	{
		return new _0024downloadMaster_002421634(this).GetEnumerator();
	}

	private IEnumerator downloadAssetBundleDB()
	{
		return new _0024downloadAssetBundleDB_002421641(this).GetEnumerator();
	}

	private DownloadRequest reqDownload(string url, __DownloadRequest_0024callable108_002416_75__ callback)
	{
		return reqDownloadSub(null, url, pending: false, callback);
	}

	private DownloadRequest reqAssetBundleDownload(Hashtable hash, string url)
	{
		return reqDownloadSub(hash, url, pending: true, null);
	}

	private DownloadRequest reqDownloadSub(Hashtable hash, string url, bool pending, __DownloadRequest_0024callable108_002416_75__ callback)
	{
		DownloadRequest downloadRequest = new DownloadRequest(hash, url, callback);
		downloadRequest.finishIfCached();
		if (!downloadRequest.IsOk)
		{
			allRequests.Add(downloadRequest);
			if (pending)
			{
				pendingQueue.Enqueue(downloadRequest);
			}
			else
			{
				workingRequests.Add(downloadRequest);
			}
		}
		return downloadRequest;
	}

	private void logDownloadInfo()
	{
	}

	private bool needUpdateMaster()
	{
		return targetMasterVersion != CurrentInfo.MasterVersion;
	}

	private bool needUpdateAssetBundles()
	{
		return targetDataVersion != CurrentInfo.DataVersion || !RuntimeAssetBundleDB.Instance.HasSavedData || (needBgmBundleDownload() ? true : false);
	}

	private bool isCachedCompletely()
	{
		IEnumerator<DownloadRequest> enumerator = allRequests.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				if (!current.IsAssetBundle || current.IsCached)
				{
					continue;
				}
				flag = false;
				goto IL_004f;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 1;
		goto IL_0050;
		IL_004f:
		result = (flag ? 1 : 0);
		goto IL_0050;
		IL_0050:
		return (byte)result != 0;
	}

	private void assetBundleCacheError()
	{
		string text = "ダウンロードエラー";
		string msg = "データを正しくダウンロードできませんでした。通信状況か空き容量をご確認ください。";
		MerlinServer.FatalErrorDialog(msg, text, string.Empty, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			ClearData.ClearDownloadedData();
			SceneChanger.Kill();
			SceneChanger.Change("Boot");
		});
	}

	private void startPendingRequests(int n)
	{
		if (n <= 0 || PendingNum <= 0)
		{
			return;
		}
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int num2 = num;
			num++;
			if (pendingQueue.Count > 0)
			{
				workingRequests.Add(pendingQueue.Dequeue());
				continue;
			}
			break;
		}
	}

	private static Boo.Lang.List<string> GetAssetBundleFiles(Hashtable hash)
	{
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		IEnumerator enumerator = hash.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			if (DownloadUtil.IsAssetBundleFile(text))
			{
				list.Add(text);
			}
		}
		return list;
	}

	private IEnumerator downloadAllAssetBundles(Hashtable hash)
	{
		return new _0024downloadAllAssetBundles_002421647(hash, this).GetEnumerator();
	}

	private void dumpResourceHash(Hashtable hash)
	{
		StringBuilder stringBuilder = new StringBuilder();
		IEnumerator enumerator = hash.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			stringBuilder.Append(new StringBuilder().Append(text).Append(":").Append(hash[text])
				.Append("\n")
				.ToString());
		}
	}

	private Hashtable getBgmInfo(Hashtable hash)
	{
		Hashtable hashtable = new Hashtable();
		IEnumerator enumerator = hash.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			if (text != null && text.StartsWith("BGM"))
			{
				hashtable[text] = hash[text];
			}
		}
		return hashtable;
	}

	private Hashtable eliminateBgmBundleInfo(Hashtable hash)
	{
		Hashtable hashtable = new Hashtable();
		IEnumerator enumerator = hash.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			if (text != null && !text.StartsWith("BGM"))
			{
				hashtable[text] = hash[text];
			}
		}
		return hashtable;
	}

	private static bool needBgmBundleDownload()
	{
		bool flag = false;
		UserMiscInfo userMiscInfo = UserData.Current.userMiscInfo;
		if (!userMiscInfo.IsAbleToSave)
		{
			userMiscInfo = new UserMiscInfo();
			userMiscInfo.Load();
		}
		if (userMiscInfo.IsAbleToSave)
		{
			flag = userMiscInfo.bgmLoad;
		}
		bool num = mode == Mode.All;
		if (!num)
		{
			num = mode == Mode.BgmOnly;
		}
		if (!num)
		{
			num = mode == Mode.Update;
			if (num)
			{
				num = flag;
			}
		}
		return num;
	}

	private static Hashtable LoadCachedResourceHash()
	{
		string @string = PlayerPrefs.GetString("Merlin-Resource-Hash", string.Empty);
		PlayerPrefs.Save();
		return (!string.IsNullOrEmpty(@string)) ? (NGUIJson.jsonDecode(@string) as Hashtable) : null;
	}

	private IEnumerator displayNewFeatureDetailRoutine()
	{
		return new _0024displayNewFeatureDetailRoutine_002421657(this).GetEnumerator();
	}

	private IEnumerator openControlSettingPanel()
	{
		return new _0024openControlSettingPanel_002421661(this).GetEnumerator();
	}

	private void PushPadOK()
	{
		if (downloadControlSetting != null)
		{
			downloadControlSetting.Close();
		}
	}

	private void startProgressBarUpdate()
	{
		progressBarEnabled = true;
	}

	private void fixProgressBar(float val)
	{
		progressBarEnabled = false;
		setProgressBar(val);
	}

	private void updateProgressBar()
	{
		if (!isErrorMode && progressBarEnabled)
		{
			float progress = getProgress();
			float total = getTotal();
			if (!(total <= 0f))
			{
				setProgressBar(progress * 0.999f / total);
			}
			else
			{
				setProgressBar(0f);
			}
		}
	}

	private void setProgressBar(float val)
	{
		if (!(val <= 1f))
		{
			val = 1f;
		}
		gauge.sliderValue = val;
		gaugeText.text = UIBasicUtility.SafeFormat("{0}%", checked((int)(val * 100f)));
	}

	private float getProgress()
	{
		float num = 0f;
		IEnumerator<DownloadRequest> enumerator = allRequests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				num += current.ProgressSize;
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private float getTotal()
	{
		float num = 0f;
		IEnumerator<DownloadRequest> enumerator = allRequests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				DownloadRequest current = enumerator.Current;
				num += current.Size;
			}
			return num;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private void InitBG()
	{
		bool flag = IsBgmOnly;
		if (!IsBgmOnly)
		{
			flag = UnityEngine.Random.Range(0, 1000000) < 500000;
		}
		FirstAndBGMBG.SetActive(flag);
		NormalBG.SetActive(!flag);
	}

	public void OnGUI()
	{
	}

	internal bool _0024updateWorkingRequests_0024closure_00243988(DownloadRequest r)
	{
		return r.IsOk;
	}

	internal void _0024updateWorkingRequests_0024closure_00243989()
	{
		isErrorMode = false;
	}

	internal void _0024downloadAssetBundleDB_0024closure_00243993(WWW www)
	{
		if (www != null)
		{
			RuntimeAssetBundleDB.Instance.initialize(www.text);
		}
	}

	internal void _0024assetBundleCacheError_0024closure_00243994()
	{
		ClearData.ClearDownloadedData();
		SceneChanger.Kill();
		SceneChanger.Change("Boot");
	}
}
