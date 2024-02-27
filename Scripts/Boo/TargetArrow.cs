using System;
using ObjUtil;
using UnityEngine;

[Serializable]
public class TargetArrow : MonoBehaviour
{
	[Serializable]
	public enum ARROW_STATE
	{
		Attack,
		Run,
		Max
	}

	public GameObject target;

	public float moveY;

	private UISprite uiSprite;

	protected readonly float X_SIZE;

	protected readonly float Y_SIZE;

	protected readonly float DRAW_OFFSET_Y;

	protected readonly float DEFAULT_SCALE;

	protected readonly float SMALL_SCALE;

	protected readonly float SCALL_CHANGE_TIME;

	private ARROW_STATE arrowState;

	public TargetArrow()
	{
		moveY = 3f;
		X_SIZE = 80f;
		Y_SIZE = 135f;
		DRAW_OFFSET_Y = 200f;
		DEFAULT_SCALE = 1f;
		SMALL_SCALE = 0.8f;
		SCALL_CHANGE_TIME = 1f;
		arrowState = ARROW_STATE.Attack;
	}

	public void Awake()
	{
		uiSprite = GetComponent<UISprite>();
	}

	public void Update()
	{
		if (!(target == null))
		{
			Vector3 screenPostion = ObjUtilModule.GetScreenPostion(transform, target, Camera.main);
			screenPostion.y += DRAW_OFFSET_Y;
			transform.localPosition = screenPostion;
		}
	}

	public void AttackRange()
	{
		if (arrowState != 0)
		{
			arrowState = ARROW_STATE.Attack;
			float a = 1f;
			Color color = uiSprite.color;
			float num = (color.a = a);
			Color color3 = (uiSprite.color = color);
			iTween.ScaleTo(gameObject, iTween.Hash("X", DEFAULT_SCALE * X_SIZE, "y", DEFAULT_SCALE * Y_SIZE, "time", SCALL_CHANGE_TIME, "islocal", true, "easetype", iTween.EaseType.easeOutElastic));
		}
	}

	public void RunRange()
	{
		if (arrowState != ARROW_STATE.Run)
		{
			arrowState = ARROW_STATE.Run;
			float a = 0.5f;
			Color color = uiSprite.color;
			float num = (color.a = a);
			Color color3 = (uiSprite.color = color);
			iTween.ScaleTo(gameObject, iTween.Hash("X", SMALL_SCALE * X_SIZE, "y", SMALL_SCALE * Y_SIZE, "time", SCALL_CHANGE_TIME, "islocal", true, "easetype", iTween.EaseType.easeOutElastic));
		}
	}
}
