using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ColosseumTeamHUD : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_show_002417400 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241448_002417401;

			internal bool _0024forward_002417402;

			internal ColosseumTeamHUD _0024self__002417403;

			public _0024(ColosseumTeamHUD self_)
			{
				_0024self__002417403 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241448_002417401 = _0024self__002417403.WaitForLoad();
					if (_0024_0024sco_0024temp_00241448_002417401 != null)
					{
						result = (Yield(2, _0024self__002417403.StartCoroutine(_0024_0024sco_0024temp_00241448_002417401)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__002417403.teamTweener.PlayAnimation(_0024forward_002417402 = true);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ColosseumTeamHUD _0024self__002417404;

		public _0024_show_002417400(ColosseumTeamHUD self_)
		{
			_0024self__002417404 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417404);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitForLoad_002417405 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_until_0024temp_00241449_002417406;

			internal float _0024_0024wait_until_0024temp_00241450_002417407;

			internal ColosseumTeamHUD _0024self__002417408;

			public _0024(ColosseumTeamHUD self_)
			{
				_0024self__002417408 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024wait_until_0024temp_00241449_002417406 = 2f;
					_0024_0024wait_until_0024temp_00241450_002417407 = Time.realtimeSinceStartup;
					goto case 2;
				case 2:
					if (!_0024self__002417408.IsIconLoaded() && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241450_002417407 < _0024_0024wait_until_0024temp_00241449_002417406)
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

		internal ColosseumTeamHUD _0024self__002417409;

		public _0024WaitForLoad_002417405(ColosseumTeamHUD self_)
		{
			_0024self__002417409 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417409);
		}
	}

	[NonSerialized]
	private ColosseumTeam data;

	private Boo.Lang.List<ColosseumTeamMember> memList;

	public RaidNamePlate teamNameLabel;

	public UISlider gageSlider;

	public float moveValueSpeed;

	public UILabelBase gageLabel;

	public ColosseumTeamMemberHUD[] teamHUDs;

	public UIAutoTweener teamTweener;

	public ColosseumTeamHUD()
	{
		moveValueSpeed = 1f;
	}

	public void Start()
	{
		teamTweener.Initialize();
		teamTweener.StopAnimation();
		teamTweener.transform.localPosition = new Vector3(0f, -10000f, 0f);
	}

	public void Init(ColosseumTeam setData)
	{
		data = setData;
		if (data == null)
		{
			return;
		}
		teamNameLabel.setName(setData.TeamName);
		memList = data.MemberList;
		int num = 0;
		int length = teamHUDs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			if (num2 < memList.Count)
			{
				ColosseumTeamMemberHUD[] array = teamHUDs;
				array[RuntimeServices.NormalizeArrayIndex(array, num2)].Init(memList[num2]);
			}
			else
			{
				ColosseumTeamMemberHUD[] array2 = teamHUDs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].SetNoData();
			}
		}
	}

	public void Update()
	{
		if (data != null)
		{
			float num = data.Force / data.MaxForce - gageSlider.sliderValue;
			if (!(num <= 0f))
			{
				gageSlider.sliderValue += Mathf.Min(num, Time.deltaTime * moveValueSpeed);
			}
			else if (!(num >= 0f))
			{
				gageSlider.sliderValue += Mathf.Max(num, (0f - Time.deltaTime) * moveValueSpeed);
			}
			gageLabel.text = data.Force.ToString();
		}
	}

	public void Show()
	{
		IEnumerator enumerator = _show();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public IEnumerator _show()
	{
		return new _0024_show_002417400(this).GetEnumerator();
	}

	public IEnumerator WaitForLoad()
	{
		return new _0024WaitForLoad_002417405(this).GetEnumerator();
	}

	public bool IsIconLoaded()
	{
		int num = 0;
		ColosseumTeamMemberHUD[] array = teamHUDs;
		int length = array.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (!array[num].IsIconLoaded())
				{
					result = 0;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 1;
			break;
		}
		return (byte)result != 0;
	}
}
