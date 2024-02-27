using System.Collections.Generic;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Multiplayer;

public class TurnBasedMatch
{
	public enum MatchStatus
	{
		Active,
		AutoMatching,
		Cancelled,
		Complete,
		Expired,
		Unknown,
		Deleted
	}

	public enum MatchTurnStatus
	{
		Complete,
		Invited,
		MyTurn,
		TheirTurn,
		Unknown
	}

	private string mMatchId;

	private byte[] mData;

	private bool mCanRematch;

	private int mAvailableAutomatchSlots;

	private string mSelfParticipantId;

	private List<Participant> mParticipants;

	private string mPendingParticipantId;

	private MatchTurnStatus mTurnStatus;

	private MatchStatus mMatchStatus;

	private int mVariant;

	public string MatchId => mMatchId;

	public byte[] Data => mData;

	public bool CanRematch => mCanRematch;

	public string SelfParticipantId => mSelfParticipantId;

	public Participant Self => GetParticipant(mSelfParticipantId);

	public List<Participant> Participants => mParticipants;

	public string PendingParticipantId => mPendingParticipantId;

	public Participant PendingParticipant => (mPendingParticipantId != null) ? GetParticipant(mPendingParticipantId) : null;

	public MatchTurnStatus TurnStatus => mTurnStatus;

	public MatchStatus Status => mMatchStatus;

	public int Variant => mVariant;

	public int AvailableAutomatchSlots => mAvailableAutomatchSlots;

	internal TurnBasedMatch(string matchId, byte[] data, bool canRematch, string selfParticipantId, List<Participant> participants, int availableAutomatchSlots, string pendingParticipantId, MatchTurnStatus turnStatus, MatchStatus matchStatus, int variant)
	{
		mMatchId = matchId;
		mData = data;
		mCanRematch = canRematch;
		mSelfParticipantId = selfParticipantId;
		mParticipants = participants;
		mParticipants.Sort();
		mAvailableAutomatchSlots = availableAutomatchSlots;
		mPendingParticipantId = pendingParticipantId;
		mTurnStatus = turnStatus;
		mMatchStatus = matchStatus;
		mVariant = variant;
	}

	public Participant GetParticipant(string participantId)
	{
		foreach (Participant mParticipant in mParticipants)
		{
			if (mParticipant.ParticipantId.Equals(participantId))
			{
				return mParticipant;
			}
		}
		Logger.w("Participant not found in turn-based match: " + participantId);
		return null;
	}

	public override string ToString()
	{
		return $"[TurnBasedMatch: mMatchId={mMatchId}, mData={mData}, mCanRematch={mCanRematch}, mSelfParticipantId={mSelfParticipantId}, mParticipants={mParticipants}, mPendingParticipantId={mPendingParticipantId}, mTurnStatus={mTurnStatus}, mMatchStatus={mMatchStatus}, mVariant={mVariant}]";
	}
}
