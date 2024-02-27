using UnityEngine;

public class Ef_Arrow_Rain_Shot_Bullet : Ef_Base
{
	public Transform arrowObj;

	public Transform flareObj;

	public Transform trailObj;

	public float timer = 0.15f;

	public float life = 1f;

	public float speed = 20f;

	public Vector3 rndVecMin = new Vector3(-10f, -10f, -10f);

	public Vector3 rndVecMax = new Vector3(10f, 5f, 10f);

	public float rndRot = 720f;

	public float upForce = 60f;

	private Vector3 velocity = Vector3.zero;

	private Quaternion rotVec = Quaternion.identity;

	private void Start()
	{
		if (!arrowObj)
		{
			arrowObj = base.transform.Find("Arrow");
		}
		if (!flareObj)
		{
			flareObj = base.transform.Find("Flare");
		}
		if (!trailObj)
		{
			trailObj = base.transform.Find("Trail");
		}
		arrowObj.gameObject.SetActive(value: false);
		flareObj.particleSystem.Stop();
		flareObj.particleSystem.Clear();
		trailObj.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (timer > 0f)
		{
			timer -= base.deltaTime;
			if (timer <= 0f)
			{
				velocity = new Vector3(Random.Range(rndVecMin.x, rndVecMax.x), Random.Range(rndVecMin.y, rndVecMax.y), Random.Range(rndVecMin.z, rndVecMax.z)).normalized * speed;
				rotVec = Quaternion.Euler(0f, Random.Range(0f - rndRot, rndRot), 0f);
				arrowObj.gameObject.SetActive(value: true);
				flareObj.particleSystem.Play();
				trailObj.gameObject.SetActive(value: true);
			}
		}
		else
		{
			velocity = Quaternion.Lerp(Quaternion.identity, rotVec, base.deltaTime) * velocity;
			velocity.y += upForce * base.deltaTime;
			base.transform.position += velocity * base.deltaTime;
			base.transform.rotation = Quaternion.LookRotation(velocity);
			life -= base.deltaTime;
			if (life <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
