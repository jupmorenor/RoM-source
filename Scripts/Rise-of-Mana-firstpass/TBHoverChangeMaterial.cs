using UnityEngine;

public class TBHoverChangeMaterial : MonoBehaviour
{
	public Material hoverMaterial;

	private Material normalMaterial;

	private void Start()
	{
		normalMaterial = base.renderer.sharedMaterial;
	}

	private void OnFingerHover(FingerHoverEvent e)
	{
		if (e.Phase == FingerHoverPhase.Enter)
		{
			base.renderer.sharedMaterial = hoverMaterial;
		}
		else
		{
			base.renderer.sharedMaterial = normalMaterial;
		}
	}
}
