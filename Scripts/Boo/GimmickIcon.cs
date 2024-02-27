using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class GimmickIcon : MonoBehaviour
{
	[Serializable]
	private enum Command
	{
		NONE,
		INIT,
		SHOW,
		HIDE
	}

	public UIButtonMessage button;

	public AttachUI attach;

	public UISprite icon;

	private Vector3 initScale;

	public float LeastShowTime;

	private float showTimer;

	private Command command;

	private bool isIconShow;

	private bool touchIcon;

	protected bool isDestroy;

	public GameObject @base => gameObject;

	public GameObject Target
	{
		get
		{
			return attach.target.gameObject;
		}
		set
		{
			if (value != null)
			{
				attach.target = value.transform;
			}
		}
	}

	public Vector3 DispOffset
	{
		get
		{
			return attach.Offset;
		}
		set
		{
			attach.Offset = value;
		}
	}

	public Vector3 Offset3D
	{
		get
		{
			return attach.offset3D;
		}
		set
		{
			attach.offset3D = value;
		}
	}

	public bool TouchIcon
	{
		get
		{
			bool result = touchIcon;
			touchIcon = false;
			return result;
		}
	}

	public UIButtonMessage Button => button;

	public AttachUI Attach => attach;

	public UISprite Icon => icon;

	public bool IsIconShow => isIconShow;

	public GimmickIcon()
	{
		command = Command.NONE;
	}

	public void Awake()
	{
	}

	public void Start()
	{
		Init();
	}

	public void Init()
	{
		if (button == null)
		{
			button = ExtensionsModule.FindComponentInChildrenOrSelf<UIButtonMessage>(gameObject);
		}
		if (attach == null)
		{
			attach = ExtensionsModule.FindComponentInChildrenOrSelf<AttachUI>(gameObject);
		}
		if (icon == null)
		{
			icon = ExtensionsModule.FindComponentInChildrenOrSelf<UISprite>(gameObject);
		}
		if (button == null)
		{
			button = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
		}
		if (attach == null)
		{
			attach = ExtensionsModule.SetComponent<AttachUI>(gameObject);
		}
		if (!(button != null))
		{
			throw new AssertionFailedException("GimmickRaceIcon に UIButtonMessage がなーい");
		}
		if (!(attach != null))
		{
			throw new AssertionFailedException("GimmickRaceIcon に AttachUI がなーい");
		}
		if (!(icon != null))
		{
			throw new AssertionFailedException("GimmickRaceIcon に UISprite がなーい");
		}
		initScale = @base.transform.localScale;
		@base.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
		button.target = gameObject;
		button.functionName = "touchRaceIcon";
		if (command == Command.NONE)
		{
			command = Command.INIT;
		}
	}

	public void Update()
	{
		if (!(showTimer <= 0f))
		{
			showTimer -= Time.deltaTime;
		}
		switch (command)
		{
		case Command.INIT:
			isIconShow = false;
			command = Command.NONE;
			@base.transform.localScale = new Vector3(0f, 0f, 0f);
			break;
		case Command.HIDE:
			if (!(showTimer > 0f))
			{
				command = Command.NONE;
				_hide();
			}
			break;
		case Command.SHOW:
			command = Command.NONE;
			_show();
			break;
		}
	}

	public void setAttachTarget(GameObject obj)
	{
		if (!(obj == null))
		{
			attach.target = obj.transform;
		}
	}

	public void destroy()
	{
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void show()
	{
		command = Command.SHOW;
	}

	public void hide()
	{
		command = Command.HIDE;
	}

	private void _show()
	{
		if (!isDestroy && !isIconShow)
		{
			showTimer = LeastShowTime;
			@base.SetActive(value: true);
			isIconShow = true;
			float num = 0.8f;
			iTween.ScaleTo(@base.gameObject, iTween.Hash("x", initScale.x, "y", initScale.y, "time", num, "oncompletetarget", gameObject, "oncomplete", "onShowComplete"));
		}
	}

	private void _hide()
	{
		if (!isDestroy && isIconShow)
		{
			isIconShow = false;
			float num = 0.8f;
			iTween.ScaleTo(@base.gameObject, iTween.Hash("x", 0.0, "y", 0.0, "time", num, "oncompletetarget", gameObject, "oncomplete", "onHideComplete"));
		}
	}

	public void destroyMe()
	{
		if (!isDestroy)
		{
			if (attach != null)
			{
				UnityEngine.Object.Destroy(attach);
			}
			if (button != null)
			{
				UnityEngine.Object.Destroy(button);
			}
			float num = 0.8f;
			iTween.ScaleTo(@base.gameObject, iTween.Hash("x", 0.0, "y", 0.0, "time", num, "oncompletetarget", gameObject, "oncomplete", "onDestroyComplete"));
		}
	}

	public void OnDestroy()
	{
		isDestroy = true;
	}

	protected void onShowComplete()
	{
	}

	protected void onHideComplete()
	{
		touchIcon = false;
	}

	protected void onDestroyComplete()
	{
		UnityEngine.Object.DestroyObject(gameObject);
	}

	public void touchRaceIcon()
	{
		touchIcon = true;
	}
}
