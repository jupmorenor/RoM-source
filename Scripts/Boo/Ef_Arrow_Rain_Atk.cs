using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Ef_Arrow_Rain_Atk : Ef_Base
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024playse_002415364 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal SQEX_SoundPlayer _0024sndmgr_002415365;

			internal Ef_Arrow_Rain_Atk _0024self__002415366;

			public _0024(Ef_Arrow_Rain_Atk self_)
			{
				_0024self__002415366 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(2.25f)) ? 1 : 0);
					break;
				case 2:
					_0024sndmgr_002415365 = SQEX_SoundPlayer.Instance;
					if ((bool)_0024sndmgr_002415365)
					{
						_0024sndmgr_002415365.PlaySe(201, 0, _0024self__002415366.gameObject.GetInstanceID());
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Ef_Arrow_Rain_Atk _0024self__002415367;

		public _0024playse_002415364(Ef_Arrow_Rain_Atk self_)
		{
			_0024self__002415367 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002415367);
		}
	}

	public float radius;

	public float radiusRank2;

	public float timer;

	public float life;

	public float lifeRank2;

	public int arrowNum;

	public int arrowNumRank2;

	public Transform meshObj;

	public GameObject bulletObj;

	private float oneTime;

	private float nxtTime;

	private Vector3 tgtScale;

	private Ef_SetActiveFromRank setActiveFromRank;

	private int sendRank;

	private Material mat;

	public Ef_Arrow_Rain_Atk()
	{
		radius = 4f;
		radiusRank2 = 6f;
		timer = 2f;
		life = 3f;
		lifeRank2 = 6f;
		arrowNum = 30;
		arrowNumRank2 = 30;
	}

	public void Start()
	{
		if (!meshObj)
		{
			meshObj = transform.Find("Mesh");
		}
		if (!bulletObj)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		oneTime = life / (float)arrowNum + 0.01f;
		nxtTime = life;
		transform.localScale = new Vector3(0f, 1f, 0f);
		tgtScale = new Vector3(radius * 2f, 1f, radius * 2f);
		IEnumerator enumerator = playse();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		if ((bool)meshObj && (bool)meshObj.renderer)
		{
			mat = meshObj.renderer.material;
		}
	}

	public void Update()
	{
		if (meshObj == null)
		{
			return;
		}
		if (!(timer <= 0f))
		{
			timer -= deltaTime;
		}
		else if (!(life <= 0f))
		{
			life -= deltaTime;
			if (!(life > nxtTime))
			{
				Emit();
			}
		}
		else if (!(life <= -1f))
		{
			life -= deltaTime;
			if (!(life > -1f))
			{
				tgtScale = new Vector3(0f, 1f, 0f);
			}
		}
		else
		{
			life -= deltaTime;
			if (!(life >= -3f))
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		if (!(transform.localScale == tgtScale))
		{
			transform.localScale = Vector3.Lerp(transform.localScale, tgtScale, 10f * deltaTime);
			if (!((tgtScale - transform.localScale).magnitude >= 0.001f))
			{
				transform.localScale = tgtScale;
			}
		}
		if ((bool)mat)
		{
			Vector2 mainTextureOffset = mat.mainTextureOffset;
			mainTextureOffset.x -= 4f * deltaTime;
			mainTextureOffset.y += 0.5f * deltaTime;
			if (!(mainTextureOffset.x >= 0f))
			{
				mainTextureOffset.y += 1f;
			}
			if (!(mainTextureOffset.y <= 1f))
			{
				mainTextureOffset.y += 1f;
			}
			mat.mainTextureOffset = mainTextureOffset;
		}
	}

	public void Emit()
	{
		Quaternion quaternion = Quaternion.Euler(UnityEngine.Random.Range(60, 90), UnityEngine.Random.Range(0, 360), 0f);
		Vector3 position = Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f) * new Vector3(0f, 0f, Mathf.Sin(UnityEngine.Random.Range(0f, 1.57f)) * radius);
		position += quaternion * new Vector3(0f, 0f, -15f);
		position += transform.position;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bulletObj, position, quaternion);
		Ef_Arrow_Rain_Bullet component = gameObject.GetComponent<Ef_Arrow_Rain_Bullet>();
		if (!component)
		{
			return;
		}
		component.pHeight = transform.position.y;
		nxtTime -= oneTime;
		if (sendRank != 0)
		{
			gameObject.SendMessage("setRank", sendRank, SendMessageOptions.DontRequireReceiver);
		}
		MerlinAttackCommandHolder component2 = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component2 != null)
		{
			if (component2.Command.parent != null)
			{
				gameObject.layer = this.gameObject.layer;
				MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject.AddComponent<MerlinAttackCommandHolder>();
				merlinAttackCommandHolder.Command = component2.Command;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public IEnumerator playse()
	{
		return new _0024playse_002415364(this).GetEnumerator();
	}

	public void setTime(int inTime)
	{
		float num = lifeRank2 / life;
		if (life == lifeRank2)
		{
			life = inTime;
			lifeRank2 = life;
		}
		else
		{
			life = inTime;
			lifeRank2 = (float)inTime * num;
		}
	}

	public void setRank(int rank)
	{
		sendRank = rank;
		if (Ef_SetActiveFromRank.rank2test)
		{
			rank = 2;
		}
		if (rank >= 2)
		{
			radius = radiusRank2;
			life = lifeRank2;
			arrowNum = arrowNumRank2;
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
