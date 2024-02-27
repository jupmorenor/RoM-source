using System;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DeckItemState
{
	[NonSerialized]
	private const int STATE_BIT_EQUIP = 1;

	[NonSerialized]
	private const int STATE_BIT_FRIEND = 2;

	[NonSerialized]
	private const int STATE_BIT_DESELECT = 4;

	private DeckSelector _owner;

	private int _index;

	private GameObject _diuGo;

	private DeckItemUiBase _diu;

	private int _stateBit;

	private RespFriendPoppet _selFrMapet;

	private bool _isFriendMapet;

	public DeckSelector owner => _owner;

	public DeckItemUiBase deckItemUi => _diu;

	public GameObject deckItemUiGo => _diuGo;

	public DeckItemState()
	{
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = delegate
		{
			clean();
		};
	}

	public void clean()
	{
		_diuGo = null;
		_stateBit = 0;
		object obj = null;
		bool flag = false;
	}

	public void initialize(DeckSelector aOwner, int aIndex)
	{
		_owner = aOwner;
		_index = aIndex;
	}

	public void preUpdate()
	{
		if (_diu != null && _stateBit != 0)
		{
			if (((uint)_stateBit & 4u) != 0)
			{
				_diu.deselect();
			}
			if (((uint)_stateBit & (true ? 1u : 0u)) != 0)
			{
				_diu.setCurEquip();
			}
			if (((uint)_stateBit & 2u) != 0)
			{
				_diu.selFrMapet(_selFrMapet, _isFriendMapet);
			}
			_stateBit = 0;
		}
	}

	public void setDeckItemUiGo(GameObject aDiuGo)
	{
		_diuGo = aDiuGo;
		_diu = _diuGo.GetComponent<DeckItemUiBase>() as DeckItemUiBase;
		_owner.increaseDeckCount();
	}

	public void deselect()
	{
		if (_diu != null)
		{
			_diu.deselect();
		}
		else
		{
			_stateBit = 4;
		}
	}

	public void selFrMapet(RespFriendPoppet aFriendPoppet, bool aIsFriend)
	{
		if (_diu != null)
		{
			_diu.selFrMapet(aFriendPoppet, aIsFriend);
			return;
		}
		_selFrMapet = aFriendPoppet;
		_isFriendMapet = aIsFriend;
		_stateBit |= 2;
	}

	public void setCurEquip()
	{
		if (_diu != null)
		{
			_diu.setCurEquip();
		}
		else
		{
			_stateBit |= 1;
		}
	}

	public void updateEquip()
	{
		if (_diu != null)
		{
			_diu.updateEquip();
		}
		else
		{
			_stateBit |= 1;
		}
	}

	internal void _0024_0024initializer_0024_0024Awake_00243074()
	{
		clean();
	}
}
