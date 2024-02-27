using UnityEngine;

public class UICenterOnChildManual : MonoBehaviour
{
	public float springStrength = 8f;

	public IPSpringPanel.OnFinished onFinished;

	private UIDraggablePanel mDrag;

	private GameObject mCenteredObject;

	private IPSpringPanel _springPanel;

	private void Start()
	{
		mDrag = base.gameObject.GetComponent(typeof(UIDraggablePanel)) as UIDraggablePanel;
		_springPanel = base.gameObject.AddComponent(typeof(IPSpringPanel)) as IPSpringPanel;
		_springPanel.strength = springStrength;
		_springPanel.enabled = false;
	}

	public void CenterOnChild(Transform targetTrans)
	{
		if (!(mDrag.panel == null))
		{
			Vector4 clipRange = mDrag.panel.clipRange;
			Transform cachedTransform = mDrag.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			mDrag.currentMomentum = Vector3.zero;
			Vector3 vector = cachedTransform.InverseTransformPoint(targetTrans.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (mDrag.scale.x == 0f)
			{
				vector3.x = 0f;
			}
			if (mDrag.scale.y == 0f)
			{
				vector3.y = 0f;
			}
			if (mDrag.scale.z == 0f)
			{
				vector3.z = 0f;
			}
			_springPanel.Begin(cachedTransform.localPosition - vector3);
			_springPanel.onFinished = onFinished;
		}
	}

	public void Abort()
	{
		_springPanel.onFinished = null;
		_springPanel.enabled = false;
	}
}
