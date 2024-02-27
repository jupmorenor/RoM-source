using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Camera/Look At Tap")]
[RequireComponent(typeof(TapRecognizer))]
public class TBLookAtTap : MonoBehaviour
{
	private TBDragView dragView;

	private void Awake()
	{
		dragView = GetComponent<TBDragView>();
	}

	private void Start()
	{
		if (!GetComponent<TapRecognizer>())
		{
			Debug.LogWarning("No tap recognizer found on " + base.name + ". Disabling TBLookAtTap.");
			base.enabled = false;
		}
	}

	private void OnTap(TapGesture gesture)
	{
		Ray ray = Camera.main.ScreenPointToRay(gesture.Position);
		if (Physics.Raycast(ray, out var hitInfo))
		{
			if ((bool)dragView)
			{
				dragView.LookAt(hitInfo.point);
			}
			else
			{
				base.transform.LookAt(hitInfo.point);
			}
		}
	}
}
