using System.Collections.Generic;

namespace ExitGames.Client.Photon.Lite;

public class LitePeer : PhotonPeer
{
	public LitePeer(IPhotonPeerListener listener, bool useTcp)
		: base(listener, useTcp)
	{
	}

	public virtual bool OpGetPropertiesOfActor(int[] actorNrList, byte[] properties, byte channelId)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary.Add(251, LitePropertyTypes.Actor);
		if (properties != null)
		{
			dictionary.Add(249, properties);
		}
		if (actorNrList != null)
		{
			dictionary.Add(252, actorNrList);
		}
		return OpCustom(251, dictionary, sendReliable: true, channelId);
	}
}
