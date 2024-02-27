using UnityEngine;

public class UIPuwa : UITweener
{
	public float scaleTo = 1.3f;

	public float orgWidth;

	public float orgHeight;

	private Color orgColor;

	private GameObject shade;

	public UISprite baseSprite => base.gameObject.GetComponent<UISprite>();

	private void Start()
	{
		if (baseSprite != null)
		{
			orgWidth = baseSprite.transform.localScale.x;
			orgHeight = baseSprite.transform.localScale.y;
			orgColor = baseSprite.color;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (!(baseSprite == null))
		{
			float y = scaleTo * orgHeight * factor + (1f - factor) * orgHeight;
			float num = 1f + (scaleTo - 1f) * orgHeight / orgWidth;
			float x = (num * factor + (1f - factor)) * orgWidth;
			baseSprite.transform.localScale = new Vector3(x, y, 1f);
			Color color = baseSprite.color;
			color.a = 1f - factor;
			baseSprite.color = color;
		}
	}

	private void OnDisable()
	{
		Object.DestroyObject(base.gameObject);
	}
}
