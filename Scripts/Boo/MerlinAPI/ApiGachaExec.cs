using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ApiGachaExec : RequestBase
{
	[Serializable]
	public class Resp : GameApiResponseBase
	{
		public string BoxId;

		public RespPlayerBox[] Box;

		public RespPlayerInfo PlayerInfo;

		public BoxId[] BoxIdList
		{
			get
			{
				int[] array = Csv2Ints(BoxId);
				BoxId[] array2 = BoxIdArray(array.Length);
				int num = 0;
				int length = array.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int index = num;
					num++;
					ref BoxId reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					reference = new BoxId(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
				}
				return array2;
			}
		}
	}

	public int GachaId;

	public int Turn;

	public override bool IsOk
	{
		get
		{
			bool num;
			if (!(ResponseObj is GameApiResponseBase gameApiResponseBase))
			{
				num = base.IsOk;
			}
			else
			{
				num = base.IsOk;
				if (num)
				{
					num = gameApiResponseBase.IsOkStatusCode;
				}
			}
			return num;
		}
	}

	public override bool HasValidStatus
	{
		get
		{
			GameApiResponseBase gameApiResponseBase = ResponseObj as GameApiResponseBase;
			bool num = gameApiResponseBase != null;
			if (num)
			{
				num = !string.IsNullOrEmpty(gameApiResponseBase.StatusCode);
			}
			return num;
		}
	}

	public override string ApiPath => "/Gacha/Exec";

	public override ServerType Server => ServerType.Game;

	public Resp GetResponse()
	{
		return ResponseObj as Resp;
	}

	public override Type responseType()
	{
		return typeof(Resp);
	}

	private static BoxId[] BoxIdArray(int n)
	{
		return new BoxId[n];
	}

	public static int[] Csv2Ints(string s)
	{
		try
		{
			string[] array = s.Split(',');
			int[] array2 = new int[array.Length];
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = int.Parse(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			}
			return array2;
		}
		catch (Exception)
		{
			return new int[0];
		}
	}
}
