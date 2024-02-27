using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class TestAPI : MonoBehaviour
{
	[Serializable]
	internal class _0024api_0024locals_002414334
	{
		internal RequestBase _0024r;
	}

	[Serializable]
	internal class _0024api_fail_0024locals_002414335
	{
		internal RequestBase _0024r;
	}

	[Serializable]
	internal class _0024api_0024closure_00244231
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416623 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024api_0024closure_00244231 _0024self__002416624;

				public _0024(_0024api_0024closure_00244231 self_)
				{
					_0024self__002416624 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						MerlinServer.Request(_0024self__002416624._0024_0024locals_002414778._0024r);
						goto case 2;
					case 2:
						if (!_0024self__002416624._0024_0024locals_002414778._0024r.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024self__002416624._0024_0024locals_002414778._0024r.IsOk)
						{
							throw new AssertionFailedException("r.IsOk");
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

			internal _0024api_0024closure_00244231 _0024self__002416625;

			public _0024Invoke_002416623(_0024api_0024closure_00244231 self_)
			{
				_0024self__002416625 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002416625);
			}
		}

		internal _0024api_0024locals_002414334 _0024_0024locals_002414778;

		public _0024api_0024closure_00244231(_0024api_0024locals_002414334 _0024_0024locals_002414778)
		{
			this._0024_0024locals_002414778 = _0024_0024locals_002414778;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002416623(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024api_fail_0024closure_00244238
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002416626 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024api_fail_0024closure_00244238 _0024self__002416627;

				public _0024(_0024api_fail_0024closure_00244238 self_)
				{
					_0024self__002416627 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						MerlinServer.Request(_0024self__002416627._0024_0024locals_002414779._0024r);
						goto case 2;
					case 2:
						if (!_0024self__002416627._0024_0024locals_002414779._0024r.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002416627._0024_0024locals_002414779._0024r.IsOk)
						{
							throw new AssertionFailedException("not r.IsOk");
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

			internal _0024api_fail_0024closure_00244238 _0024self__002416628;

			public _0024Invoke_002416626(_0024api_fail_0024closure_00244238 self_)
			{
				_0024self__002416628 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002416628);
			}
		}

		internal _0024api_fail_0024locals_002414335 _0024_0024locals_002414779;

		public _0024api_fail_0024closure_00244238(_0024api_fail_0024locals_002414335 _0024_0024locals_002414779)
		{
			this._0024_0024locals_002414779 = _0024_0024locals_002414779;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002416626(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002416609 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal TestAPI _0024self__002416610;

			public _0024(TestAPI self_)
			{
				_0024self__002416610 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, _0024self__002416610.StartCoroutine(_0024self__002416610.test1())) ? 1 : 0);
					break;
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

		internal TestAPI _0024self__002416611;

		public _0024main_002416609(TestAPI self_)
		{
			_0024self__002416611 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416611);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024test1_002416612 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024uuid1_002416613;

			internal ApiPlatformAccessInfo _0024_00244232_002416614;

			internal ApiEntryCreateUser _0024_00244233_002416615;

			internal string _0024preUUID_002416616;

			internal ApiEntryCreateUser _0024_00244234_002416617;

			internal ApiEntryCreateUser _0024_00244235_002416618;

			internal ApiCreateCharacter _0024_00244236_002416619;

			internal ApiCreateCharacter _0024_00244237_002416620;

			internal TestAPI _0024self__002416621;

			public _0024(TestAPI self_)
			{
				_0024self__002416621 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					ClearData.ClearAllData();
					result = (Yield(2, _0024self__002416621.api("T1", new ApiPlatformExtServer())) ? 1 : 0);
					break;
				case 2:
					result = (Yield(3, _0024self__002416621.api("T2", new ApiPlatformExtServer())) ? 1 : 0);
					break;
				case 3:
					ClearData.ClearAllData();
					result = (Yield(4, _0024self__002416621.api("T3", new ApiPlatformAccessInfo())) ? 1 : 0);
					break;
				case 4:
				{
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					_0024uuid1_002416613 = CurrentInfo.UUID;
					TestAPI testAPI6 = _0024self__002416621;
					ApiPlatformAccessInfo apiPlatformAccessInfo = (_0024_00244232_002416614 = new ApiPlatformAccessInfo());
					string text8 = (_0024_00244232_002416614.uuid = _0024uuid1_002416613);
					result = (Yield(5, testAPI6.api("T4", _0024_00244232_002416614)) ? 1 : 0);
					break;
				}
				case 5:
				{
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					if (!(_0024uuid1_002416613 == CurrentInfo.UUID))
					{
						throw new AssertionFailedException("uuid1 == CurrentInfo.UUID");
					}
					ClearData.ClearAllData();
					TestAPI testAPI5 = _0024self__002416621;
					ApiEntryCreateUser apiEntryCreateUser3 = (_0024_00244233_002416615 = new ApiEntryCreateUser());
					string text7 = (_0024_00244233_002416615.name = "myname");
					result = (Yield(6, testAPI5.api("T5", _0024_00244233_002416615)) ? 1 : 0);
					break;
				}
				case 6:
				{
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					_0024preUUID_002416616 = CurrentInfo.UUID;
					TestAPI testAPI = _0024self__002416621;
					ApiEntryCreateUser apiEntryCreateUser = (_0024_00244234_002416617 = new ApiEntryCreateUser());
					string text = (_0024_00244234_002416617.name = "myname");
					result = (Yield(7, testAPI.api("T6", _0024_00244234_002416617)) ? 1 : 0);
					break;
				}
				case 7:
				{
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					if (!(_0024preUUID_002416616 != CurrentInfo.UUID))
					{
						throw new AssertionFailedException("preUUID != CurrentInfo.UUID");
					}
					_0024preUUID_002416616 = CurrentInfo.UUID;
					ClearData.ClearToken();
					TestAPI testAPI2 = _0024self__002416621;
					ApiEntryCreateUser apiEntryCreateUser2 = (_0024_00244235_002416618 = new ApiEntryCreateUser());
					string text2 = (_0024_00244235_002416618.name = "myname");
					result = (Yield(8, testAPI2.api("T7", _0024_00244235_002416618)) ? 1 : 0);
					break;
				}
				case 8:
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					if (!(_0024preUUID_002416616 != CurrentInfo.UUID))
					{
						throw new AssertionFailedException("preUUID != CurrentInfo.UUID");
					}
					result = (Yield(9, _0024self__002416621.api("T8", new ApiPlatformAccessInfo())) ? 1 : 0);
					break;
				case 9:
				{
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					TestAPI testAPI4 = _0024self__002416621;
					ApiCreateCharacter apiCreateCharacter2 = (_0024_00244236_002416619 = new ApiCreateCharacter());
					string text5 = (_0024_00244236_002416619.AngelName = "an");
					string text6 = (_0024_00244236_002416619.DemonName = "dn");
					int num3 = (_0024_00244236_002416619.AngelGender = 1);
					int num4 = (_0024_00244236_002416619.DemonGender = 2);
					result = (Yield(10, testAPI4.api("T9", _0024_00244236_002416619)) ? 1 : 0);
					break;
				}
				case 10:
				{
					ClearData.ClearAllData();
					TestAPI testAPI3 = _0024self__002416621;
					ApiCreateCharacter apiCreateCharacter = (_0024_00244237_002416620 = new ApiCreateCharacter());
					string text3 = (_0024_00244237_002416620.AngelName = "an");
					string text4 = (_0024_00244237_002416620.DemonName = "dn");
					int num = (_0024_00244237_002416620.AngelGender = 1);
					int num2 = (_0024_00244237_002416620.DemonGender = 2);
					result = (Yield(11, testAPI3.api("T11", _0024_00244237_002416620)) ? 1 : 0);
					break;
				}
				case 11:
					result = (Yield(12, _0024self__002416621.api("T12", new ApiHome())) ? 1 : 0);
					break;
				case 12:
					ClearData.ClearToken();
					if (!CurrentInfo.HasUUID)
					{
						throw new AssertionFailedException("CurrentInfo.HasUUID");
					}
					if (CurrentInfo.HasToken)
					{
						throw new AssertionFailedException("not CurrentInfo.HasToken");
					}
					result = (Yield(13, _0024self__002416621.api("T13", new ApiHome())) ? 1 : 0);
					break;
				case 13:
					ClearData.ClearAllData();
					result = (Yield(14, _0024self__002416621.api("T14", new ApiHome())) ? 1 : 0);
					break;
				case 14:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestAPI _0024self__002416622;

		public _0024test1_002416612(TestAPI self_)
		{
			_0024self__002416622 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416622);
		}
	}

	public void Start()
	{
		StartCoroutine(main());
	}

	private IEnumerator main()
	{
		return new _0024main_002416609(this).GetEnumerator();
	}

	private IEnumerator test1()
	{
		return new _0024test1_002416612(this).GetEnumerator();
	}

	private Coroutine api(string t, RequestBase r)
	{
		_0024api_0024locals_002414334 _0024api_0024locals_0024 = new _0024api_0024locals_002414334();
		_0024api_0024locals_0024._0024r = r;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024api_0024closure_00244231(_0024api_0024locals_0024).Invoke;
		return StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	private Coroutine api_fail(string t, RequestBase r)
	{
		_0024api_fail_0024locals_002414335 _0024api_fail_0024locals_0024 = new _0024api_fail_0024locals_002414335();
		_0024api_fail_0024locals_0024._0024r = r;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024api_fail_0024closure_00244238(_0024api_fail_0024locals_0024).Invoke;
		return StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}
}
