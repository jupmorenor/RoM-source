using System;

namespace ExitGames.Client.Photon;

internal class CustomType
{
	public readonly byte Code;

	public readonly Type Type;

	public readonly SerializeMethod SerializeFunction;

	public readonly DeserializeMethod DeserializeFunction;
}
