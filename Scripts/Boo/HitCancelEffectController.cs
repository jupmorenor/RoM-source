using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class HitCancelEffectController
{
	private GameObject baseEffect;

	private PlayerControl parent;

	private GameObject _currentEffect;

	protected GameObject currentEffect
	{
		get
		{
			return _currentEffect;
		}
		set
		{
			_currentEffect = value;
		}
	}

	public bool IsAvailable
	{
		get
		{
			bool num = parent != null;
			if (num)
			{
				num = baseEffect != null;
			}
			return num;
		}
	}

	public HitCancelEffectController(PlayerControl _parent, GameObject _baseEffect)
	{
		parent = _parent;
		baseEffect = _baseEffect;
	}

	public void start(int n)
	{
		if (IsAvailable)
		{
			kill();
			currentEffect = GameAssetModule.Instantiate(baseEffect) as GameObject;
			if (currentEffect != null)
			{
				SceneDontDestroyObject.dontDestroyOnLoad(currentEffect);
				sendMessage(n);
			}
		}
	}

	public void setCount(int n)
	{
		if (n > 0)
		{
			if (currentEffect != null)
			{
				sendMessage(n);
			}
			else
			{
				start(n);
			}
		}
		else
		{
			kill();
		}
	}

	public void kill()
	{
		if (!(currentEffect == null))
		{
			UnityEngine.Object.Destroy(currentEffect);
			currentEffect = null;
			sendMessage(0);
		}
	}

	private void sendMessage(int n)
	{
		if (currentEffect != null)
		{
			currentEffect.SendMessage("notifyHitCancel", n, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void update(float dt)
	{
		if (!(currentEffect == null) && parent != null)
		{
			currentEffect.transform.position = parent.transform.position;
			currentEffect.transform.rotation = parent.transform.rotation;
			bool activeSelf = currentEffect.activeSelf;
			bool isBusy = CutSceneManager.IsBusy;
			if (activeSelf == isBusy)
			{
				currentEffect.SetActive(!isBusy);
			}
		}
	}
}
