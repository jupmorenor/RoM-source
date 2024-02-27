using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using MerlinAPI;
using SharpUnit;
using UnityEngine;

[Serializable]
public class TestApiBlackSmith : MerlinApiTestCase
{
	[Serializable]
	internal class _0024TestApiWeaponEvolution_0024locals_002414568
	{
		internal RespPlayerBox[] _0024box;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BlackSmithInit_002422515 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiEcho _0024req1_002422516;

			internal ApiPlatformExtServer _0024req2_002422517;

			internal ApiPlatformAccessInfo _0024req3_002422518;

			internal ApiIsCreate _0024req4_002422519;

			internal ApiGachaExec _0024_00245224_002422520;

			internal ApiGachaExec _0024req5_002422521;

			internal ApiGachaExec _0024_00245225_002422522;

			internal ApiGachaExec _0024_00245226_002422523;

			internal ApiGachaExec _0024_00245227_002422524;

			internal ApiGachaExec _0024_00245228_002422525;

			internal ApiGachaExec _0024_00245229_002422526;

			internal TestApiBlackSmith _0024self__002422527;

			public _0024(TestApiBlackSmith self_)
			{
				_0024self__002422527 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req1_002422516 = new ApiEcho();
					result = (Yield(2, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req1_002422516))) ? 1 : 0);
					break;
				case 2:
					_0024req2_002422517 = new ApiPlatformExtServer();
					result = (Yield(3, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req2_002422517))) ? 1 : 0);
					break;
				case 3:
					_0024req3_002422518 = new ApiPlatformAccessInfo();
					result = (Yield(4, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req3_002422518))) ? 1 : 0);
					break;
				case 4:
					_0024req4_002422519 = new ApiIsCreate();
					result = (Yield(5, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req4_002422519))) ? 1 : 0);
					break;
				case 5:
				{
					ApiGachaExec apiGachaExec6 = (_0024_00245224_002422520 = new ApiGachaExec());
					int num11 = (_0024_00245224_002422520.GachaId = 4);
					int num12 = (_0024_00245224_002422520.Turn = 10);
					_0024req5_002422521 = _0024_00245224_002422520;
					result = (Yield(6, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 6:
				{
					ApiGachaExec apiGachaExec5 = (_0024_00245225_002422522 = new ApiGachaExec());
					int num9 = (_0024_00245225_002422522.GachaId = 4);
					int num10 = (_0024_00245225_002422522.Turn = 10);
					_0024req5_002422521 = _0024_00245225_002422522;
					result = (Yield(7, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 7:
				{
					ApiGachaExec apiGachaExec4 = (_0024_00245226_002422523 = new ApiGachaExec());
					int num7 = (_0024_00245226_002422523.GachaId = 4);
					int num8 = (_0024_00245226_002422523.Turn = 10);
					_0024req5_002422521 = _0024_00245226_002422523;
					result = (Yield(8, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 8:
				{
					ApiGachaExec apiGachaExec3 = (_0024_00245227_002422524 = new ApiGachaExec());
					int num5 = (_0024_00245227_002422524.GachaId = 4);
					int num6 = (_0024_00245227_002422524.Turn = 10);
					_0024req5_002422521 = _0024_00245227_002422524;
					result = (Yield(9, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 9:
				{
					ApiGachaExec apiGachaExec2 = (_0024_00245228_002422525 = new ApiGachaExec());
					int num3 = (_0024_00245228_002422525.GachaId = 4);
					int num4 = (_0024_00245228_002422525.Turn = 10);
					_0024req5_002422521 = _0024_00245228_002422525;
					result = (Yield(10, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 10:
				{
					ApiGachaExec apiGachaExec = (_0024_00245229_002422526 = new ApiGachaExec());
					int num = (_0024_00245229_002422526.GachaId = 4);
					int num2 = (_0024_00245229_002422526.Turn = 10);
					_0024req5_002422521 = _0024_00245229_002422526;
					result = (Yield(11, _0024self__002422527.runner.StartCoroutine(_0024self__002422527.WaitRequest(_0024req5_002422521))) ? 1 : 0);
					break;
				}
				case 11:
					try
					{
						Assert.True(_0024req2_002422517.IsOk, new StringBuilder().Append("\n ").Append(_0024self__002422527.readResponeString(_0024req2_002422517)).ToString());
						Assert.True(_0024req3_002422518.IsOk, new StringBuilder().Append("アクセストークンが取得できません").Append("\n ").Append(_0024self__002422527.readResponeString(_0024req3_002422518))
							.ToString());
						Assert.True(_0024req4_002422519.GetResponse().Created, new StringBuilder().Append("既にキャラ作成済みかの確認").Append("\n ").Append(_0024self__002422527.readResponeString(_0024req4_002422519))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422527.MarkAsFailure(e);
					}
					_0024self__002422527.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiBlackSmith _0024self__002422528;

		public _0024BlackSmithInit_002422515(TestApiBlackSmith self_)
		{
			_0024self__002422528 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422528);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWeaponStrengthening_002422529 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHome _0024reqHome_002422530;

			internal ApiHome.Resp _0024responseHome_002422531;

			internal RespDeck _0024deck_002422532;

			internal RespPlayerBox[] _0024box_002422533;

			internal BoxId _0024baseID_002422534;

			internal BoxId _0024mat1ID_002422535;

			internal BoxId _0024mat2ID_002422536;

			internal ApiWeaponStrengthening _0024req1_002422537;

			internal ApiWeaponStrengthening _0024req2_002422538;

			internal ApiWeaponStrengthening _0024req3_002422539;

			internal TestApiBlackSmith _0024self__002422540;

			public _0024(TestApiBlackSmith self_)
			{
				_0024self__002422540 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024reqHome_002422530 = new ApiHome();
					result = (Yield(2, _0024self__002422540.runner.StartCoroutine(_0024self__002422540.WaitRequest(_0024reqHome_002422530))) ? 1 : 0);
					break;
				case 2:
					_0024responseHome_002422531 = _0024reqHome_002422530.GetResponse();
					_0024deck_002422532 = _0024responseHome_002422531.Decks[0];
					_0024box_002422533 = _0024responseHome_002422531.Box;
					_0024baseID_002422534 = _0024deck_002422532.TWeaponBoxId_1;
					_0024mat1ID_002422535 = _0024box_002422533[10].Id;
					_0024mat2ID_002422536 = _0024box_002422533[11].Id;
					_0024req1_002422537 = new ApiWeaponStrengthening();
					_0024req1_002422537.add(_0024baseID_002422534, new BoxId[2] { _0024mat1ID_002422535, _0024mat1ID_002422535 });
					result = (Yield(3, _0024self__002422540.runner.StartCoroutine(_0024self__002422540.WaitRequest(_0024req1_002422537))) ? 1 : 0);
					break;
				case 3:
					_0024baseID_002422534 = _0024deck_002422532.TWeaponBoxId_1;
					_0024mat1ID_002422535 = _0024deck_002422532.TWeaponBoxId_2;
					_0024mat2ID_002422536 = _0024box_002422533[11].Id;
					_0024req2_002422538 = new ApiWeaponStrengthening();
					_0024req2_002422538.add(_0024baseID_002422534, new BoxId[2] { _0024mat1ID_002422535, _0024mat2ID_002422536 });
					result = (Yield(4, _0024self__002422540.runner.StartCoroutine(_0024self__002422540.WaitRequest(_0024req2_002422538))) ? 1 : 0);
					break;
				case 4:
					_0024baseID_002422534 = _0024deck_002422532.TWeaponBoxId_1;
					_0024req3_002422539 = new ApiWeaponStrengthening();
					result = (Yield(5, _0024self__002422540.runner.StartCoroutine(_0024self__002422540.WaitRequest(_0024req3_002422539))) ? 1 : 0);
					break;
				case 5:
					_0024reqHome_002422530 = new ApiHome();
					result = (Yield(6, _0024self__002422540.runner.StartCoroutine(_0024self__002422540.WaitRequest(_0024reqHome_002422530))) ? 1 : 0);
					break;
				case 6:
					try
					{
						Assert.Equal(_0024self__002422540.lookStatusCodeInReq(_0024req1_002422537), "CoRlt001", new StringBuilder().Append("武器強化 素材重複").Append("\n ").Append(_0024self__002422540.readResponeString(_0024req1_002422537))
							.ToString());
						Assert.Equal(_0024self__002422540.lookStatusCodeInReq(_0024req2_002422538), "CoRlt003", new StringBuilder().Append("武器強化 装備中のものを指定").Append("\n ").Append(_0024self__002422540.readResponeString(_0024req2_002422538))
							.ToString());
						Assert.Equal(_0024self__002422540.lookStatusCodeInReq(_0024req3_002422539), "CoRlt002", new StringBuilder().Append("武器強化 未所持素材を指定").Append("\n ").Append(_0024self__002422540.readResponeString(_0024req3_002422539))
							.ToString());
					}
					catch (TestException e)
					{
						_0024self__002422540.MarkAsFailure(e);
					}
					_0024self__002422540.DoneTesting();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiBlackSmith _0024self__002422541;

		public _0024TestApiWeaponStrengthening_002422529(TestApiBlackSmith self_)
		{
			_0024self__002422541 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422541);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWeaponEvolution_002422542 : GenericGenerator<BoxId>
	{
		[Serializable]
		internal class Enumerator : IDisposable, ICloneable, IEnumerator<BoxId>
		{
			internal _0024TestApiWeaponEvolution_0024locals_002414568 _0024_0024locals_002422543;

			protected IEnumerator<RespPlayerBox> _0024_0024enumerator;

			protected BoxId _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override BoxId Current => _0024_0024current;

			public Enumerator(_0024TestApiWeaponEvolution_0024locals_002414568 _0024_0024locals_002422543)
			{
				this._0024_0024locals_002422543 = _0024_0024locals_002422543;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<RespPlayerBox>)_0024_0024locals_002422543._0024box).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					RespPlayerBox current = _0024_0024enumerator.Current;
					_0024_0024current = current.Id;
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

		internal _0024TestApiWeaponEvolution_0024locals_002414568 _0024_0024locals_002422544;

		public _0024TestApiWeaponEvolution_002422542(_0024TestApiWeaponEvolution_0024locals_002414568 _0024_0024locals_002422544)
		{
			this._0024_0024locals_002422544 = _0024_0024locals_002422544;
		}

		public override IEnumerator<BoxId> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002422544);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TestApiWeaponEvolution_002422545 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal ApiHome _0024reqHome_002422546;

			internal ApiHome.Resp _0024responseHome_002422547;

			internal RespDeck _0024deck_002422548;

			internal ApiWeaponEvolution _0024req1_002422549;

			internal BoxId _0024base_002422550;

			internal RespWeapon[] _0024respWeps_002422551;

			internal BoxId[] _0024materials_002422552;

			internal int _0024i_002422553;

			internal RespWeapon _0024wep_002422554;

			internal BoxId _0024newEquiped_002422555;

			internal RespPlayerBox _0024x_002422556;

			internal List _0024all_002422557;

			internal BoxId _0024mat_002422558;

			internal int _0024_002411991_002422559;

			internal int _0024_002411992_002422560;

			internal BoxId[] _0024_002411993_002422561;

			internal int _0024_002411994_002422562;

			internal _0024TestApiWeaponEvolution_0024locals_002414568 _0024_0024locals_002422563;

			internal TestApiBlackSmith _0024self__002422564;

			public _0024(TestApiBlackSmith self_)
			{
				_0024self__002422564 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002422563 = new _0024TestApiWeaponEvolution_0024locals_002414568();
					_0024reqHome_002422546 = new ApiHome();
					result = (Yield(2, _0024self__002422564.runner.StartCoroutine(_0024self__002422564.WaitRequest(_0024reqHome_002422546))) ? 1 : 0);
					break;
				case 2:
					_0024responseHome_002422547 = _0024reqHome_002422546.GetResponse();
					_0024deck_002422548 = _0024responseHome_002422547.Decks[0];
					_0024_0024locals_002422563._0024box = _0024responseHome_002422547.Box;
					_0024req1_002422549 = new ApiWeaponEvolution();
					_0024base_002422550 = _0024deck_002422548.TWeaponBoxId_1;
					_0024respWeps_002422551 = new RespWeapon[5];
					_0024self__002422564.CheckMaterial(_0024base_002422550, ref _0024respWeps_002422551);
					_0024materials_002422552 = new BoxId[0];
					_0024_002411991_002422559 = 0;
					while (_0024_002411991_002422559 < 5)
					{
						_0024i_002422553 = _0024_002411991_002422559;
						_0024_002411991_002422559++;
						RespWeapon[] array = _0024respWeps_002422551;
						_0024wep_002422554 = array[RuntimeServices.NormalizeArrayIndex(array, _0024i_002422553)];
						if (_0024wep_002422554 != null && _0024wep_002422554.Id.IsValid)
						{
							_0024materials_002422552 = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), _0024materials_002422552, new BoxId[1] { _0024wep_002422554.Id });
						}
					}
					_0024req1_002422549.add(_0024base_002422550, _0024materials_002422552);
					result = (Yield(3, _0024self__002422564.runner.StartCoroutine(_0024self__002422564.WaitRequest(_0024req1_002422549))) ? 1 : 0);
					break;
				case 3:
					_0024reqHome_002422546 = new ApiHome();
					result = (Yield(4, _0024self__002422564.runner.StartCoroutine(_0024self__002422564.WaitRequest(_0024reqHome_002422546))) ? 1 : 0);
					break;
				case 4:
					_0024responseHome_002422547 = _0024reqHome_002422546.GetResponse();
					_0024deck_002422548 = _0024responseHome_002422547.Decks[0];
					_0024_0024locals_002422563._0024box = _0024responseHome_002422547.Box;
					_0024newEquiped_002422555 = _0024deck_002422548.TWeaponBoxId_1;
					_0024all_002422557 = new List(new _0024TestApiWeaponEvolution_002422542(_0024_0024locals_002422563));
					checked
					{
						try
						{
							Assert.True(_0024req1_002422549.IsOk, new StringBuilder().Append("武器進化").Append("\n ").Append(_0024self__002422564.readResponeString(_0024req1_002422549))
								.ToString());
							Assert.True(!RuntimeServices.EqualityOperator(_0024base_002422550, _0024newEquiped_002422555), new StringBuilder().Append("装備武器進化でID変化").Append("\n ").Append(_0024self__002422564.readResponeString(_0024req1_002422549))
								.ToString());
							_0024_002411992_002422560 = 0;
							_0024_002411993_002422561 = _0024materials_002422552;
							for (_0024_002411994_002422562 = _0024_002411993_002422561.Length; _0024_002411992_002422560 < _0024_002411994_002422562; _0024_002411992_002422560++)
							{
								Assert.False(RuntimeServices.op_Member(_0024_002411993_002422561[_0024_002411992_002422560], _0024all_002422557), new StringBuilder().Append("武器進化素材消化").Append("\n ").Append(_0024self__002422564.readResponeString(_0024req1_002422549))
									.ToString());
							}
						}
						catch (TestException e)
						{
							_0024self__002422564.MarkAsFailure(e);
						}
						_0024self__002422564.DoneTesting();
						YieldDefault(1);
						goto case 1;
					}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TestApiBlackSmith _0024self__002422565;

		public _0024TestApiWeaponEvolution_002422545(TestApiBlackSmith self_)
		{
			_0024self__002422565 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002422565);
		}
	}

	public bool[] CheckMaterial(BoxId baseBoxId, ref RespWeapon[] distList)
	{
		bool[] array = new bool[5];
		UserData current = UserData.Current;
		RespWeapon respWeapon = current.boxWeapon(baseBoxId);
		bool[] result;
		if (respWeapon == null)
		{
			result = array;
		}
		else
		{
			if (respWeapon.Master == null)
			{
				throw new AssertionFailedException("あろうことかマスターがありません！！！");
			}
			if (respWeapon.Master.EvolutionWeaponId == null)
			{
				result = array;
			}
			else
			{
				Boo.Lang.List<int> list = new Boo.Lang.List<int>(5);
				int i = 0;
				MWeapons[] evolutionMaterials = respWeapon.EvolutionMaterials;
				for (int length = evolutionMaterials.Length; i < length; i = checked(i + 1))
				{
					list.Add((evolutionMaterials[i] != null) ? evolutionMaterials[i].Id : 0);
				}
				object[] array2 = CheckMaterialIds(baseBoxId, list.ToArray(), RespPlayerBox.EnumItemType.WEAPON);
				object enumerable = array2[0];
				object obj = array2[1];
				if (!(obj is bool[]))
				{
					obj = RuntimeServices.Coerce(obj, typeof(bool[]));
				}
				array = (bool[])obj;
				Boo.Lang.List<RespWeapon> list2 = new Boo.Lang.List<RespWeapon>();
				IEnumerator enumerator = RuntimeServices.GetEnumerable(enumerable).GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj2 = enumerator.Current;
					if (!(obj2 is RespPlayerBox))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(RespPlayerBox));
					}
					list2.Add(((RespPlayerBox)obj2)?.toRespWeapon());
				}
				distList = list2.ToArray();
				result = array;
			}
		}
		return result;
	}

	protected object[] CheckMaterialIds(BoxId baseBoxId, int[] masterIds, RespPlayerBox.EnumItemType type)
	{
		bool[] array = new bool[5];
		UserData current = UserData.Current;
		Dictionary<BoxId, RespPlayerBox> dictionary = new Dictionary<BoxId, RespPlayerBox>();
		int num = 0;
		while (num < 5)
		{
			int index = num;
			num++;
			int num2 = masterIds[RuntimeServices.NormalizeArrayIndex(masterIds, index)];
			if (num2 <= 0)
			{
				continue;
			}
			int i = 0;
			RespPlayerBox[] allItems = current.userBoxData.AllItems;
			for (int length = allItems.Length; i < length; i = checked(i + 1))
			{
				if (allItems[i].Id.IsValid && !dictionary.ContainsKey(allItems[i].Id) && (type != RespPlayerBox.EnumItemType.WEAPON || !allItems[i].IsPoppet) && (type != RespPlayerBox.EnumItemType.POPPET || !allItems[i].IsWeapon) && allItems[i].ItemId == num2)
				{
					dictionary[allItems[i].Id] = allItems[i];
				}
			}
		}
		Dictionary<BoxId, RespPlayerBox> dictionary2 = new Dictionary<BoxId, RespPlayerBox>();
		Boo.Lang.List<RespPlayerBox> list = new Boo.Lang.List<RespPlayerBox>();
		int num3 = 0;
		while (num3 < 5)
		{
			int index2 = num3;
			num3++;
			int num2 = masterIds[RuntimeServices.NormalizeArrayIndex(masterIds, index2)];
			bool flag = false;
			if (0 < num2)
			{
				foreach (RespPlayerBox value in dictionary.Values)
				{
					if (RuntimeServices.EqualityOperator(value.Id, baseBoxId) || dictionary2.ContainsKey(value.Id) || current.IsUsing(value.Id) || current.IsFavorite(value))
					{
						continue;
					}
					flag = true;
					dictionary2[value.Id] = value;
					break;
				}
				bool flag2 = false;
				if (flag)
				{
					flag2 = true;
				}
				else
				{
					foreach (RespPlayerBox value2 in dictionary.Values)
					{
						if (dictionary2.ContainsKey(value2.Id))
						{
							continue;
						}
						flag2 = true;
						dictionary2[value2.Id] = value2;
						break;
					}
				}
				if (!flag2)
				{
					RespPlayerBox respPlayerBox = new RespPlayerBox();
					respPlayerBox.Id = BoxId.InvalidId;
					respPlayerBox.ItemId = num2;
					respPlayerBox.ItemType = (int)type;
					list.Add(respPlayerBox);
				}
			}
			else
			{
				flag = true;
				list.Add(null);
			}
			array[RuntimeServices.NormalizeArrayIndex(array, index2)] = flag;
		}
		RespPlayerBox[] array2 = dictionary2.Values.Concat(list.ToArray()).ToArray();
		return new object[2] { array2, array };
	}

	[UnitTest]
	public IEnumerator BlackSmithInit()
	{
		return new _0024BlackSmithInit_002422515(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWeaponStrengthening()
	{
		return new _0024TestApiWeaponStrengthening_002422529(this).GetEnumerator();
	}

	[UnitTest]
	public IEnumerator TestApiWeaponEvolution()
	{
		return new _0024TestApiWeaponEvolution_002422545(this).GetEnumerator();
	}
}
