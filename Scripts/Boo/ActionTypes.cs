using System;

[Serializable]
public enum ActionTypes
{
	Idle = 1,
	Moving = 2,
	Attack = 4,
	Kaihi = 8,
	Dead = 0x10,
	Yarare = 0x20,
	Event = 0x40,
	Skill = 0x80,
	Magic = 0x100,
	Cancel = 0x200,
	Down = 0x400
}
