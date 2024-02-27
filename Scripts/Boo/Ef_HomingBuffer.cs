using System;
using UnityEngine;

[Serializable]
public class Ef_HomingBuffer : MonoBehaviour
{
	[Serializable]
	public enum Side
	{
		FromEffectMessage,
		TargetToEnemySide,
		TargetToPlayerSide,
		TargetToPlayer,
		TargetToAll,
		TargetToPlayerTarget,
		ReturnToSelf
	}

	[NonSerialized]
	private static Ef_HomingBuffer current;

	public BaseControl[] candidatesE;

	public BaseControl[] candidatesP;

	[NonSerialized]
	public const int maxCandidatesNumE = 10;

	[NonSerialized]
	public const int maxCandidatesNumP = 10;

	[NonSerialized]
	public const string playerLayer = "PlayerAttackColi";

	[NonSerialized]
	public const string enemyLayer = "EnemyAttackColi";

	public bool ready;

	public bool readyESide;

	public bool readyPSide;

	public bool destroyOnCandidatesEmpty;

	private float destroyCheckInterval;

	private float destroyCheckCount;

	private bool useTerrain;

	private bool usePlane;

	private GameObject terrainObj;

	private GameObject planeObj;

	public static Ef_HomingBuffer Current
	{
		get
		{
			if (current == null)
			{
				Ef_HomingBuffer ef_HomingBuffer = new GameObject("Ef_HomingBuffer").AddComponent<Ef_HomingBuffer>();
				ef_HomingBuffer.Initialize();
				current = ef_HomingBuffer;
			}
			return current;
		}
	}

	public Ef_HomingBuffer()
	{
		destroyOnCandidatesEmpty = true;
		destroyCheckInterval = 1f;
		destroyCheckCount = 1f;
	}

	public void Initialize()
	{
		if (candidatesE == null)
		{
			candidatesE = new BaseControl[0];
		}
		if (candidatesP == null)
		{
			candidatesP = new BaseControl[0];
		}
		int i = 0;
		BaseControl[] array = candidatesE;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] != null)
				{
					ready = true;
					return;
				}
			}
			int j = 0;
			BaseControl[] array2 = candidatesP;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] != null)
				{
					ready = true;
					return;
				}
			}
			candidatesE = new BaseControl[10];
			candidatesP = new BaseControl[10];
			GetCandidates();
			ready = true;
		}
	}

	public Transform FindTargetRoot(Vector3 pos, Side side)
	{
		return FindTarget(pos, side, randomChoice: false, ignoreAlive: false, findSpine: false);
	}

	public Transform FindTargetRoot(Vector3 pos, Side side, bool randomChoice)
	{
		return FindTarget(pos, side, randomChoice, ignoreAlive: false, findSpine: false);
	}

	public Transform FindTargetRoot(Vector3 pos, Side side, bool randomChoice, bool ignoreAlive)
	{
		return FindTarget(pos, side, randomChoice, ignoreAlive, findSpine: false);
	}

	public Transform FindTarget(Vector3 pos, Side side)
	{
		return FindTarget(pos, side, randomChoice: false, ignoreAlive: false, findSpine: true);
	}

	public Transform FindTarget(Vector3 pos, Side side, bool randomChoice)
	{
		return FindTarget(pos, side, randomChoice, ignoreAlive: false, findSpine: true);
	}

	public Transform FindTarget(Vector3 pos, Side side, bool randomChoice, bool ignoreAlive)
	{
		return FindTarget(pos, side, randomChoice, ignoreAlive, findSpine: true);
	}

	public Transform FindTarget(Vector3 pos, Side side, bool randomChoice, bool ignoreAlive, bool findSpine)
	{
		Transform transform = null;
		float num = default(float);
		float num2 = default(float);
		bool flag = default(bool);
		if (!ready)
		{
			Initialize();
		}
		if (!readyESide || !readyPSide)
		{
			GetCandidates();
		}
		object result;
		checked
		{
			if (side == Side.TargetToEnemySide)
			{
				if (!randomChoice)
				{
					num2 = 99999f;
					flag = false;
					int i = 0;
					BaseControl[] array = candidatesE;
					for (int length = array.Length; i < length; i++)
					{
						if (array[i] != null && (ignoreAlive || array[i].IsAlive))
						{
							flag = true;
							num = (array[i].transform.position - pos).sqrMagnitude;
							if (!(num >= num2))
							{
								transform = array[i].transform;
								num2 = num;
							}
						}
					}
					if (!flag)
					{
						readyESide = false;
					}
				}
				else
				{
					int j = 0;
					BaseControl[] array2 = candidatesE;
					for (int length2 = array2.Length; j < length2; j++)
					{
						if (array2[j] != null && (ignoreAlive || array2[j].IsAlive))
						{
							flag = true;
							num = (array2[j].transform.position - pos).sqrMagnitude;
							if (transform == null || UnityEngine.Random.Range(0, 3) < 1)
							{
								transform = array2[j].transform;
							}
						}
					}
					if (!flag)
					{
						readyESide = false;
					}
				}
			}
			else if (side == Side.TargetToPlayerSide)
			{
				if (!randomChoice)
				{
					num2 = 99999f;
					flag = false;
					int k = 0;
					BaseControl[] array3 = candidatesP;
					for (int length3 = array3.Length; k < length3; k++)
					{
						if (array3[k] != null && (ignoreAlive || array3[k].IsAlive))
						{
							flag = true;
							num = (array3[k].transform.position - pos).sqrMagnitude;
							if (!(num >= num2))
							{
								transform = array3[k].transform;
								num2 = num;
							}
						}
					}
					if (!flag)
					{
						readyPSide = false;
					}
				}
				else
				{
					int l = 0;
					BaseControl[] array4 = candidatesP;
					for (int length4 = array4.Length; l < length4; l++)
					{
						if (array4[l] != null && (ignoreAlive || array4[l].IsAlive))
						{
							flag = true;
							num = (array4[l].transform.position - pos).sqrMagnitude;
							if (transform == null || UnityEngine.Random.Range(0, 3) < 1)
							{
								transform = array4[l].transform;
							}
						}
					}
					if (!flag)
					{
						readyPSide = false;
					}
				}
			}
			else if (side == Side.TargetToPlayer)
			{
				PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
				if (!currentPlayer || !currentPlayer.IsReady)
				{
					result = null;
					goto IL_05f5;
				}
				GameObject gameObject = null;
				gameObject = ((!currentPlayer.IsTensi) ? currentPlayer.akumaModel : currentPlayer.tensiModel);
				if (gameObject != null)
				{
					transform = gameObject.transform;
				}
			}
			else if (side == Side.TargetToAll)
			{
				if (!randomChoice)
				{
					num2 = 99999f;
					flag = false;
					int m = 0;
					BaseControl[] array5 = candidatesP;
					for (int length5 = array5.Length; m < length5; m++)
					{
						if (array5[m] != null && (ignoreAlive || array5[m].IsAlive))
						{
							flag = true;
							num = (array5[m].transform.position - pos).sqrMagnitude;
							if (!(num >= num2))
							{
								transform = array5[m].transform;
								num2 = num;
							}
						}
					}
					int n = 0;
					BaseControl[] array6 = candidatesE;
					for (int length6 = array6.Length; n < length6; n++)
					{
						if (array6[n] != null && (ignoreAlive || array6[n].IsAlive))
						{
							flag = true;
							num = (array6[n].transform.position - pos).sqrMagnitude;
							if (!(num >= num2))
							{
								transform = array6[n].transform;
								num2 = num;
							}
						}
					}
					if (!flag)
					{
						readyESide = false;
						readyPSide = false;
					}
				}
				else
				{
					int num3 = 0;
					BaseControl[] array7 = candidatesP;
					for (int length7 = array7.Length; num3 < length7; num3++)
					{
						if (array7[num3] != null && (ignoreAlive || array7[num3].IsAlive))
						{
							flag = true;
							num = (array7[num3].transform.position - pos).sqrMagnitude;
							if (transform == null || UnityEngine.Random.Range(0, 6) < 1)
							{
								transform = array7[num3].transform;
							}
						}
					}
					int num4 = 0;
					BaseControl[] array8 = candidatesE;
					for (int length8 = array8.Length; num4 < length8; num4++)
					{
						if (array8[num4] != null && (ignoreAlive || array8[num4].IsAlive))
						{
							flag = true;
							num = (array8[num4].transform.position - pos).sqrMagnitude;
							if (transform == null || UnityEngine.Random.Range(0, 6) < 1)
							{
								transform = array8[num4].transform;
							}
						}
					}
					if (!flag)
					{
						readyESide = false;
						readyPSide = false;
					}
				}
			}
			if (transform != null && findSpine)
			{
				transform = FindSpine(transform);
			}
			result = transform;
			goto IL_05f5;
		}
		IL_05f5:
		return (Transform)result;
	}

	public void GetCandidates()
	{
		BaseControl baseControl = null;
		int num = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		if (!readyESide)
		{
			int num2 = BaseControl.CollectEnemySideChars(candidatesE, 10);
			if (num2 > 0)
			{
				readyESide = true;
			}
		}
		if (!readyPSide)
		{
			int num3 = BaseControl.CollectPlayerSideChars(candidatesP, 10);
			if (num3 > 0)
			{
				readyPSide = true;
			}
		}
	}

	public static Transform FindSpine(Transform trg)
	{
		MerlinMotionPackControl component = trg.GetComponent<MerlinMotionPackControl>();
		if (component == null && trg.childCount >= 1)
		{
			Transform child = trg.GetChild(0);
			if (child != null)
			{
				component = child.GetComponent<MerlinMotionPackControl>();
			}
		}
		if (component != null)
		{
			Animation motionTarget = component.motionTarget;
			if (motionTarget != null)
			{
				Transform transform = motionTarget.transform;
				if (transform != null)
				{
					trg = transform;
					Transform transform2 = transform.Find("y_ang");
					if (transform2 != null)
					{
						trg = transform2;
						Transform transform3 = transform2.Find("cog");
						if (transform3 != null)
						{
							trg = transform3;
							Transform transform4 = transform3.Find("c_spine_a");
							if (transform4 != null)
							{
								trg = transform4;
								Transform transform5 = transform3.Find("c_spine_b");
								if (transform5 != null)
								{
									trg = transform5;
									Transform transform6 = transform3.Find("c_spine_c");
									if (transform6 != null)
									{
										trg = transform6;
									}
								}
							}
						}
					}
				}
			}
		}
		return trg;
	}

	public void Update()
	{
		if (!destroyOnCandidatesEmpty)
		{
			return;
		}
		destroyCheckCount -= Time.deltaTime;
		if (destroyCheckCount > 0f)
		{
			return;
		}
		destroyCheckCount = destroyCheckInterval;
		int i = 0;
		BaseControl[] array = candidatesE;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] != null)
				{
					return;
				}
			}
			int j = 0;
			BaseControl[] array2 = candidatesP;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] != null)
				{
					return;
				}
			}
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
