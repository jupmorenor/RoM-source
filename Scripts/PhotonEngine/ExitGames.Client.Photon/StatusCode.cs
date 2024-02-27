namespace ExitGames.Client.Photon;

public enum StatusCode
{
	Connect = 1024,
	Disconnect = 1025,
	Exception = 1026,
	ExceptionOnConnect = 1023,
	SecurityExceptionOnConnect = 1022,
	QueueOutgoingReliableWarning = 1027,
	QueueOutgoingUnreliableWarning = 1029,
	SendError = 1030,
	QueueOutgoingAcksWarning = 1031,
	QueueIncomingReliableWarning = 1033,
	QueueIncomingUnreliableWarning = 1035,
	QueueSentWarning = 1037,
	InternalReceiveException = 1039,
	TimeoutDisconnect = 1040,
	DisconnectByServer = 1041,
	DisconnectByServerUserLimit = 1042,
	DisconnectByServerLogic = 1043,
	TcpRouterResponseOk = 1044,
	TcpRouterResponseNodeIdUnknown = 1045,
	TcpRouterResponseEndpointUnknown = 1046,
	TcpRouterResponseNodeNotReady = 1047,
	EncryptionEstablished = 1048,
	EncryptionFailedToEstablish = 1049
}
