using System;
using UnityEngine;

[Serializable]
public class TargetRingStar : MonoBehaviour
{
	public GameObject spriteRing;

	public GameObject spriteStar;

	private Transform targetTransform;

	private PlayerControl playerControl;

	private SkinnedMeshRenderer skinRender;

	private bool hasGroundFollow;

	protected float ringScale;

	protected float starScale;

	[NonSerialized]
	private const float TARGET_RING_SCALE_OFFSET = 0.25f;

	public TargetRingStar()
	{
		ringScale = 1.5f;
		starScale = 1f;
	}

	public void Start()
	{
		setInit();
	}

	public void setInit()
	{
		playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		hasGroundFollow = gameObject.GetComponent<Ef_HeightFollow>() != null;
	}

	public void StartLockOn(GameObject target)
	{
		AIControl component = target.GetComponent<AIControl>();
		if (!(component == null))
		{
			skinRender = target.GetComponentInChildren<SkinnedMeshRenderer>();
			targetTransform = target.transform;
			if (!(spriteRing.particleSystem == null) && !(spriteStar.particleSystem == null))
			{
				Vector3 targetRingScale = component.targetRingScale;
				float num = (targetRingScale.x + targetRingScale.y + targetRingScale.z) / 3f;
				spriteRing.particleSystem.startSize = ringScale * num * 0.25f;
				spriteStar.particleSystem.startSize = starScale * num * 0.25f;
			}
		}
	}

	public void Update()
	{
		if (targetTransform != null && spriteRing != null && spriteStar != null && skinRender != null)
		{
			spriteRing.SetActive(skinRender.enabled);
			spriteStar.SetActive(skinRender.enabled);
			Vector3 position = targetTransform.position;
			Vector3 position2 = transform.position;
			position2.x = position.x;
			position2.z = position.z;
			if (!hasGroundFollow)
			{
				position2.y = position.y + 0.00125f;
			}
			transform.position = position2;
		}
		else
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
