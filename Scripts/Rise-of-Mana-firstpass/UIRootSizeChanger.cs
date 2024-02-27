using UnityEngine;

[ExecuteInEditMode]
public class UIRootSizeChanger : MonoBehaviour
{
	public const int defaultWidth = 960;

	public const int defaultHeight = 640;

	public UIRoot root;

	private float last_r = -1f;

	private void Start()
	{
		if (root == null)
		{
			root = base.gameObject.GetComponent<UIRoot>();
		}
		if (root != null)
		{
			root.scalingStyle = UIRoot.Scaling.FixedSize;
			UpdateRatio();
		}
	}

	private void UpdateRatio()
	{
		float num = (float)Screen.width / 960f;
		float num2 = (float)Screen.height / 640f;
		float num3 = num2 / num;
		if (num3 != last_r)
		{
			int num4 = 640;
			last_r = num3;
			if (1f < num3)
			{
				num4 = (int)((float)num4 * num3);
			}
			root.manualHeight = num4;
		}
	}
}
