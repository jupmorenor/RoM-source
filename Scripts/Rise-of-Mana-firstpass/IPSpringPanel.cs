using UnityEngine;

[RequireComponent(typeof(UIPanel))]
public class IPSpringPanel : IgnoreTimeScale
{
	public delegate void OnFinished();

	public Vector3 target = Vector3.zero;

	public float strength = 10f;

	public OnFinished onFinished;

	private UIPanel mPanel;

	private Transform mTrans;

	private float mThreshold;

	private UIDraggablePanel mDrag;

	private void Start()
	{
		mPanel = GetComponent<UIPanel>();
		mDrag = GetComponent<UIDraggablePanel>();
		mTrans = base.transform;
	}

	private void Update()
	{
		float deltaTime = UpdateRealTimeDelta();
		if (mThreshold == 0f)
		{
			mThreshold = (target - mTrans.localPosition).magnitude * 0.005f;
		}
		bool flag = false;
		Vector3 localPosition = mTrans.localPosition;
		Vector3 vector = NGUIMath.SpringLerp(mTrans.localPosition, target, strength, deltaTime);
		if (mThreshold >= Vector3.Magnitude(vector - target) || Vector3.Magnitude(vector - target) < 0.001f)
		{
			vector = target;
			base.enabled = false;
			flag = true;
		}
		mTrans.localPosition = vector;
		Vector3 vector2 = vector - localPosition;
		Vector4 clipRange = mPanel.clipRange;
		clipRange.x -= vector2.x;
		clipRange.y -= vector2.y;
		mPanel.clipRange = clipRange;
		if (mDrag != null)
		{
			mDrag.UpdateScrollbars(recalculateBounds: false);
		}
		if (flag && onFinished != null)
		{
			onFinished();
		}
	}

	public void Begin(Vector3 pos)
	{
		target = pos;
		target.z = 0f;
		if (!base.enabled)
		{
			mThreshold = 0f;
			base.enabled = true;
		}
	}
}
