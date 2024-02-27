using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class JavaUtil
{
	private static Dictionary<string, AndroidJavaClass> mClassDict = new Dictionary<string, AndroidJavaClass>();

	private static Dictionary<string, AndroidJavaObject> mFieldDict = new Dictionary<string, AndroidJavaObject>();

	public static AndroidJavaClass GetGmsClass(string className)
	{
		return GetClass("com.google.android.gms." + className);
	}

	public static AndroidJavaClass GetClass(string className)
	{
		if (mClassDict.ContainsKey(className))
		{
			return mClassDict[className];
		}
		try
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass(className);
			mClassDict[className] = androidJavaClass;
			return androidJavaClass;
		}
		catch (Exception ex)
		{
			Logger.e("JavaUtil failed to load Java class: " + className);
			throw ex;
		}
	}

	public static AndroidJavaObject GetGmsField(string className, string fieldName)
	{
		string key = className + "/" + fieldName;
		if (mFieldDict.ContainsKey(key))
		{
			return mFieldDict[key];
		}
		AndroidJavaClass gmsClass = GetGmsClass(className);
		AndroidJavaObject @static = gmsClass.GetStatic<AndroidJavaObject>(fieldName);
		mFieldDict[key] = @static;
		return @static;
	}

	public static int GetStatusCode(AndroidJavaObject result)
	{
		if (result == null)
		{
			return -1;
		}
		AndroidJavaObject androidJavaObject = result.Call<AndroidJavaObject>("getStatus", new object[0]);
		return androidJavaObject.Call<int>("getStatusCode", new object[0]);
	}

	public static AndroidJavaObject CallNullSafeObjectMethod(AndroidJavaObject target, string methodName, params object[] args)
	{
		try
		{
			return target.Call<AndroidJavaObject>(methodName, args);
		}
		catch (Exception ex)
		{
			if (ex.Message.Contains("null"))
			{
				return null;
			}
			Logger.w("CallObjectMethod exception: " + ex);
			return null;
		}
	}

	public static byte[] ConvertByteArray(AndroidJavaObject byteArrayObj)
	{
		Debug.Log("ConvertByteArray.");
		if (byteArrayObj == null)
		{
			return null;
		}
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.reflect.Array");
		Debug.Log("Calling java.lang.reflect.Array.getLength.");
		int num = androidJavaClass.CallStatic<int>("getLength", new object[1] { byteArrayObj });
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = androidJavaClass.CallStatic<byte>("getByte", new object[2] { byteArrayObj, i });
		}
		return array;
	}

	public static int GetAndroidParticipantResult(MatchOutcome.ParticipantResult result)
	{
		return result switch
		{
			MatchOutcome.ParticipantResult.Win => 0, 
			MatchOutcome.ParticipantResult.Loss => 1, 
			MatchOutcome.ParticipantResult.Tie => 2, 
			MatchOutcome.ParticipantResult.None => 3, 
			_ => -1, 
		};
	}

	public static TurnBasedMatch.MatchStatus ConvertMatchStatus(int code)
	{
		switch (code)
		{
		case 1:
			return TurnBasedMatch.MatchStatus.Active;
		case 0:
			return TurnBasedMatch.MatchStatus.AutoMatching;
		case 4:
			return TurnBasedMatch.MatchStatus.Cancelled;
		case 2:
			return TurnBasedMatch.MatchStatus.Complete;
		case 3:
			return TurnBasedMatch.MatchStatus.Expired;
		default:
			Logger.e("Unknown match status code: " + code);
			return TurnBasedMatch.MatchStatus.Unknown;
		}
	}

	public static TurnBasedMatch.MatchTurnStatus ConvertTurnStatus(int code)
	{
		switch (code)
		{
		case 3:
			return TurnBasedMatch.MatchTurnStatus.Complete;
		case 0:
			return TurnBasedMatch.MatchTurnStatus.Invited;
		case 1:
			return TurnBasedMatch.MatchTurnStatus.MyTurn;
		case 2:
			return TurnBasedMatch.MatchTurnStatus.TheirTurn;
		default:
			Logger.e("Unknown match turn status: " + code);
			return TurnBasedMatch.MatchTurnStatus.Unknown;
		}
	}

	public static Participant ConvertParticipant(AndroidJavaObject participant)
	{
		string displayName = participant.Call<string>("getDisplayName", new object[0]);
		string participantId = participant.Call<string>("getParticipantId", new object[0]);
		Participant.ParticipantStatus participantStatus = Participant.ParticipantStatus.Unknown;
		Player player = null;
		bool connectedToRoom = participant.Call<bool>("isConnectedToRoom", new object[0]);
		participantStatus = participant.Call<int>("getStatus", new object[0]) switch
		{
			0 => Participant.ParticipantStatus.NotInvitedYet, 
			1 => Participant.ParticipantStatus.Invited, 
			2 => Participant.ParticipantStatus.Joined, 
			3 => Participant.ParticipantStatus.Declined, 
			4 => Participant.ParticipantStatus.Left, 
			5 => Participant.ParticipantStatus.Finished, 
			6 => Participant.ParticipantStatus.Unresponsive, 
			_ => Participant.ParticipantStatus.Unknown, 
		};
		AndroidJavaObject androidJavaObject = CallNullSafeObjectMethod(participant, "getPlayer");
		if (androidJavaObject != null)
		{
			player = new Player(androidJavaObject.Call<string>("getDisplayName", new object[0]), androidJavaObject.Call<string>("getPlayerId", new object[0]));
			androidJavaObject.Dispose();
			androidJavaObject = null;
		}
		return new Participant(displayName, participantId, participantStatus, player, connectedToRoom);
	}

	public static TurnBasedMatch ConvertMatch(string playerId, AndroidJavaObject matchObj)
	{
		List<AndroidJavaObject> list = new List<AndroidJavaObject>();
		Logger.d("AndroidTbmpClient.ConvertMatch, playerId=" + playerId);
		List<Participant> list2 = new List<Participant>();
		string matchId = matchObj.Call<string>("getMatchId", new object[0]);
		AndroidJavaObject androidJavaObject = CallNullSafeObjectMethod(matchObj, "getData");
		list.Add(androidJavaObject);
		byte[] data = ConvertByteArray(androidJavaObject);
		bool canRematch = matchObj.Call<bool>("canRematch", new object[0]);
		int availableAutomatchSlots = matchObj.Call<int>("getAvailableAutoMatchSlots", new object[0]);
		string selfParticipantId = matchObj.Call<string>("getParticipantId", new object[1] { playerId });
		AndroidJavaObject androidJavaObject2 = matchObj.Call<AndroidJavaObject>("getParticipantIds", new object[0]);
		list.Add(androidJavaObject2);
		int num = androidJavaObject2.Call<int>("size", new object[0]);
		for (int i = 0; i < num; i++)
		{
			string text = androidJavaObject2.Call<string>("get", new object[1] { i });
			AndroidJavaObject androidJavaObject3 = matchObj.Call<AndroidJavaObject>("getParticipant", new object[1] { text });
			list.Add(androidJavaObject3);
			Participant item = ConvertParticipant(androidJavaObject3);
			list2.Add(item);
		}
		string pendingParticipantId = matchObj.Call<string>("getPendingParticipantId", new object[0]);
		TurnBasedMatch.MatchTurnStatus turnStatus = ConvertTurnStatus(matchObj.Call<int>("getTurnStatus", new object[0]));
		TurnBasedMatch.MatchStatus matchStatus = ConvertMatchStatus(matchObj.Call<int>("getStatus", new object[0]));
		int variant = matchObj.Call<int>("getVariant", new object[0]);
		foreach (AndroidJavaObject item2 in list)
		{
			item2?.Dispose();
		}
		list2.Sort();
		return new TurnBasedMatch(matchId, data, canRematch, selfParticipantId, list2, availableAutomatchSlots, pendingParticipantId, turnStatus, matchStatus, variant);
	}
}
