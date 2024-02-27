using UnityEngine;

public class ScrollWheelEvents : MonoBehaviour
{
	public delegate void ScrollStartStopHandler(bool start);

	private static ScrollWheelEvents _instance;

	public static ScrollStartStopHandler onScrollStartOrStop;

	private bool _isScrolling;

	private void Awake()
	{
		if (_instance != null)
		{
			Debug.LogWarning("ScrollWheelEvents is pseudo-singleton, destroying new instance");
			Object.Destroy(this);
		}
		else
		{
			_instance = this;
		}
	}

	public static void CheckInstance()
	{
		if (_instance == null)
		{
			GameObject gameObject = new GameObject("ScrollWheelEvents");
			gameObject.AddComponent(typeof(ScrollWheelEvents));
		}
	}

	private void Update()
	{
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis != 0f)
		{
			if (!_isScrolling)
			{
				_isScrolling = true;
				if (onScrollStartOrStop != null)
				{
					onScrollStartOrStop(start: true);
				}
			}
		}
		else if (_isScrolling)
		{
			_isScrolling = false;
			if (onScrollStartOrStop != null)
			{
				onScrollStartOrStop(start: false);
			}
		}
	}
}
