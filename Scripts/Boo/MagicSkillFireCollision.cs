using System;
using UnityEngine;

[Serializable]
public class MagicSkillFireCollision : MonoBehaviour
{
	public GameObject fireEff;

	public SQEX_SoundPlayerData.SE fire_4SQEX_SE;

	private float scale;

	private SQEX_SoundPlayer sndmgr;

	public MagicSkillFireCollision()
	{
		fire_4SQEX_SE = SQEX_SoundPlayerData.SE.combination_fire;
		scale = 1f;
	}

	public void Start()
	{
		sndmgr = SQEX_SoundPlayer.Instance;
		iTween.ShakePosition(Camera.main.gameObject, new Vector3(0f, 0.7f, 0f), 2.5f);
		float y = 0f;
		Vector3 position = transform.position;
		float num = (position.y = y);
		Vector3 vector2 = (transform.position = position);
		UnityEngine.Object.Instantiate(fireEff, transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(gameObject, 2.2f);
	}

	public void Update()
	{
		if ((bool)sndmgr)
		{
			sndmgr.PlaySe((int)fire_4SQEX_SE, 0, gameObject.GetInstanceID());
		}
		scale += 6f * Time.deltaTime;
		transform.localScale = new Vector3(scale, scale, scale);
		collider.enabled = !collider.enabled;
	}
}
