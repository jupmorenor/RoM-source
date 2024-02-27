using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

namespace S540;

[Serializable]
public class S540Base : MonoBehaviour
{
	[Serializable]
	public class Exec
	{
		[NonSerialized]
		private static int sid;

		public int id;

		public string name;

		public Boo.Lang.List<Exec> children;

		public Exec parent;

		public string execPoint;

		public __GouseiSequense_S540_init_0024callable40_002410_5__ callBody;

		public bool executing;

		public bool NotExecuting => !executing;

		public Exec()
		{
			children = new Boo.Lang.List<Exec>();
			execPoint = "?";
			executing = true;
			id = checked(++sid);
		}

		public bool contains(Exec e)
		{
			int result;
			bool flag;
			if (RuntimeServices.EqualityOperator(e, this))
			{
				result = 1;
			}
			else
			{
				IEnumerator<Exec> enumerator = children.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Exec current = enumerator.Current;
						if (!current.contains(e))
						{
							continue;
						}
						flag = true;
						goto IL_0057;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				result = 0;
			}
			goto IL_0058;
			IL_0058:
			return (byte)result != 0;
			IL_0057:
			result = (flag ? 1 : 0);
			goto IL_0058;
		}

		public string seqString()
		{
			string text = name + ":" + execPoint;
			int count = children.Count;
			object result;
			if (count == 0)
			{
				result = text;
			}
			else
			{
				text += ((count < 2) ? " " : " {");
				IEnumerator<Exec> enumerator = children.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Exec current = enumerator.Current;
						text += current.seqString();
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				text += ((count < 2) ? " " : "} ");
				result = null;
			}
			return (string)result;
		}

		public Exec stop()
		{
			Exec[] array = (Exec[])Builtins.array(typeof(Exec), children);
			while (children.Count > 0)
			{
				int i = 0;
				Exec[] array2 = array;
				for (int length = array2.Length; i < length; i = checked(i + 1))
				{
					array2[i].stop();
					children.Remove(array2[i]);
				}
			}
			children.Clear();
			if (parent != null)
			{
				parent.children.Remove(this);
			}
			executing = false;
			return this;
		}

		public override string ToString()
		{
			return name + new StringBuilder("(").Append((object)id).Append(")").ToString();
		}
	}

	[NonSerialized]
	protected const int INFLOOP_CHECK_LIMIT = 100;

	public bool p命令ON;

	public bool 実行トレース出力;

	private int startFrame;

	private float startTime;

	protected int goInThisUpdate;

	protected Exec currentExec;

	protected Exec lastCreatedExec;

	private SQEX_SoundPlayer soundManager;

	private readonly float seDelay;

	private readonly float bgmDelay;

	protected int CurrentFrame => checked(Time.frameCount - startFrame);

	protected float CurrentTime => Time.time - startTime;

	protected SQEX_SoundPlayer sndmgr
	{
		get
		{
			SQEX_SoundPlayer result;
			if ((bool)soundManager)
			{
				result = soundManager;
			}
			else
			{
				soundManager = SQEX_SoundPlayer.Instance;
				result = soundManager;
			}
			return result;
		}
	}

	protected string CurrentStateName => (currentExec == null) ? "<???>" : currentExec.name;

	public bool EnableDebugLog => p命令ON;

	public bool EnableDebugTrace => 実行トレース出力;

	public S540Base()
	{
		p命令ON = true;
		seDelay = 1000f;
		bgmDelay = 2000f;
	}

	public virtual void Start()
	{
		startFrame = Time.frameCount;
		startTime = Time.time;
		startInitialState();
	}

	public virtual void Update()
	{
		goInThisUpdate = 0;
	}

	public void OnGUI_()
	{
		checked
		{
			if (EnableDebugTrace)
			{
				int num = 120;
				GUI.Label(new Rect(0f, num, 320f, 30f), name + " S540@" + CurrentStateName);
				num += 20;
				Exec exec = currentExec;
				while (exec != null)
				{
					int count = exec.children.Count;
					GUI.Label(new Rect(16f, num, 320f, 60f), "exec:" + exec.name + " - " + exec.execPoint + " " + ((count < 2) ? string.Empty : new StringBuilder("child:").Append((object)count).ToString()));
					exec = ((exec.children.Count <= 0) ? null : exec.children[0]);
					num += 20;
				}
			}
		}
	}

	protected virtual void startInitialState()
	{
		throw new Exception("初期状態が定義されていません:" + GetType());
	}

	protected string logLeader()
	{
		return new StringBuilder("(").Append((object)CurrentFrame).Append("fr/").Append(CurrentTime)
			.Append("sec) - ")
			.ToString();
	}

	protected string logLeader(string posInfo)
	{
		return new StringBuilder("(").Append((object)CurrentFrame).Append("fr/").Append(CurrentTime)
			.Append("sec) - ")
			.ToString() + posInfo + " - ";
	}

	protected void dlog(string sinfo, string s)
	{
		if (EnableDebugLog)
		{
		}
	}

	protected void dlog(string s)
	{
		if (EnableDebugLog)
		{
		}
	}

	protected void dtrace(Exec e, string sinfo, string s)
	{
		if (e != null)
		{
			e.execPoint = sinfo;
		}
		if (EnableDebugTrace)
		{
		}
	}

	protected Exec createExecAsCurrent(string n)
	{
		stopAll();
		Exec exec = new Exec();
		string text = (exec.name = n);
		return lastCreatedExec = (currentExec = exec);
	}

	protected Exec createExec(string n, Exec parent)
	{
		Exec exec = new Exec();
		string text = (exec.name = n);
		Exec exec2 = exec;
		if (parent == null)
		{
			throw new AssertionFailedException("CALL NISTAKE!");
		}
		exec2.parent = parent;
		parent.children.Add(exec2);
		lastCreatedExec = exec2;
		return exec2;
	}

	protected void stopAll()
	{
		if (currentExec != null)
		{
			currentExec.stop();
		}
		currentExec = null;
	}

	protected Coroutine entryCoroutine(Exec e, IEnumerator r)
	{
		if (e == null)
		{
			throw new AssertionFailedException(new StringBuilder("CALL NISTAKE2!! e=").Append(e).ToString());
		}
		return (r == null) ? null : StartCoroutine(r);
	}

	protected bool isExecuting(Exec e)
	{
		return e != null && currentExec != null && currentExec.contains(e);
	}

	protected void dumpExecInfo(string lead)
	{
		if (currentExec != null)
		{
		}
	}

	protected void stop(Exec e)
	{
		if (e != null)
		{
			e.stop();
			if (RuntimeServices.EqualityOperator(e, currentExec))
			{
				currentExec = null;
			}
		}
	}

	protected void PlayBGM(string bgmName)
	{
		if (sndmgr.IsPlayBgm())
		{
			GameSoundManager.PlayBgmDirect(bgmName, 1f, 1f, 2000, -1);
		}
		else
		{
			GameSoundManager.PlayBgmDirect(bgmName, 1f, 1f, 0, -1);
		}
	}

	protected int PlaySE(string seName)
	{
		int result;
		if ((bool)sndmgr)
		{
			int num = sndmgr.PlaySe(seName, checked((int)seDelay), gameObject.GetInstanceID());
			sndmgr.SetSeVoulme(num, 1f);
			result = num;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	protected int PlayJingle(string seName, bool resumeBgm)
	{
		GameSoundManager.PlaySeJingle(seName, checked((int)seDelay), resumeBgm);
		return GameSoundManager.LastSeId;
	}

	protected void StopSE()
	{
		if ((bool)sndmgr)
		{
			sndmgr.StopAllSe(checked((int)seDelay));
		}
	}
}
