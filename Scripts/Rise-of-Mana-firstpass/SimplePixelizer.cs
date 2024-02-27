using UnityEngine;

[AddComponentMenu("Image Effects/Pixelizer")]
[ExecuteInEditMode]
public class SimplePixelizer : MonoBehaviour
{
	public int pixelize = 1;

	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(source.width / pixelize, source.height / pixelize, 0);
		temporary.filterMode = FilterMode.Point;
		Graphics.Blit(source, temporary);
		Graphics.Blit(temporary, destination);
		RenderTexture.ReleaseTemporary(temporary);
	}
}
