using UnityEngine;

[RequireComponent(typeof(UISprite))]
public class DisplayPickerSprite : MonoBehaviour
{
	public enum DisplayMode
	{
		MakePixelPerfect,
		Normalize,
		KeepScale
	}

	public IPSpritePicker picker;

	public DisplayMode displayMode;

	public float normalizedMax;

	private UISprite _sprite;

	private void Awake()
	{
		_sprite = base.gameObject.GetComponent(typeof(UISprite)) as UISprite;
	}

	public void DisplaySprite()
	{
		_sprite.spriteName = picker.CurrentSpriteName;
		if (displayMode == DisplayMode.Normalize)
		{
			IPTools.NormalizeSprite(_sprite, normalizedMax);
		}
		else if (displayMode == DisplayMode.MakePixelPerfect)
		{
			_sprite.MakePixelPerfect();
		}
	}
}
