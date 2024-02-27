using System;
using System.Linq;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class UIBlinkController : MonoBehaviour
{
	[Serializable]
	public class Blink
	{
		public string id;

		public bool enabled;

		public GameObject widget;

		public float showTime;

		public float duration;

		private TweenAlpha alpha;

		private bool finished;

		private UIBlinkController ctrl;

		private bool playing;

		public bool isEmpty
		{
			get
			{
				bool num = string.IsNullOrEmpty(id);
				if (!num)
				{
					num = !enabled;
				}
				return num;
			}
		}

		public bool isPlaying => playing;

		public float getDuration => duration;

		public float getShowTime => showTime;

		public Blink()
		{
			enabled = true;
			showTime = 1.5f;
			duration = 1.5f;
		}

		public void SetActive(bool a)
		{
			if ((bool)widget)
			{
				widget.SetActive(a);
			}
		}

		public float GetShowTime(bool isAnim)
		{
			return (!isAnim) ? showTime : duration;
		}

		public float GetAllShowTime()
		{
			return duration * 2f + showTime;
		}

		public void Init(Transform trans, UIBlinkController c)
		{
			if (!finished)
			{
				ctrl = c;
				ShowLog("                Blink.Init()");
				showTime = Mathf.Max(0f, showTime);
				duration = Mathf.Max(0f, duration);
				if (!widget)
				{
					widget = new GameObject(id);
					widget.transform.parent = trans;
					widget.transform.localPosition = Vector3.zero;
					widget.transform.localScale = Vector3.one;
					widget.AddComponent<UITweenBlankWidget>();
				}
				alpha = TweenAlpha.Begin(widget, duration, 1f);
				alpha._from = 0f;
				alpha.style = UITweener.Style.Once;
				alpha.method = UITweener.Method.Linear;
				alpha.delay = 0f;
				alpha.duration = duration;
				alpha.Reset();
				UIWidget component = widget.GetComponent<UIWidget>();
				float a = component.color.a;
				float a2 = 0f;
				Color color = component.color;
				float num = (color.a = a2);
				Color color3 = (component.color = color);
				widget.SetActive(value: true);
				widget.SetActive(value: false);
				float a3 = a;
				Color color4 = component.color;
				float num2 = (color4.a = a3);
				Color color6 = (component.color = color4);
				ShowLog(new StringBuilder("                        name:").Append(id).Append(", showTime:").Append(showTime)
					.ToString());
				bool flag = true;
			}
		}

		public void Show(bool show)
		{
			if ((bool)alpha)
			{
				alpha.Sample((!show) ? 0f : 1f, isFinished: true);
			}
			SetActive(show);
		}

		public void Set(Blink b)
		{
			if (b != null)
			{
				ShowLog(new StringBuilder("                Set( name:").Append(id).Append(", showTime:").Append(showTime)
					.Append(" )")
					.ToString());
				showTime = b.showTime;
				duration = b.duration;
			}
		}

		public void Sync(Blink b)
		{
			if (b != null)
			{
				ShowLog("    " + id + ": Sync()");
				if ((bool)alpha && (bool)b.alpha)
				{
					alpha.Sync(b.alpha);
				}
			}
		}

		public void Play(bool forward)
		{
			if (isEmpty || isPlaying)
			{
				return;
			}
			ShowLog(new StringBuilder("                Play( ").Append(forward).Append(" )").ToString());
			if ((bool)alpha)
			{
				widget.SetActive(value: true);
				alpha.onFinished = delegate(UITweener t)
				{
					t.onFinished = null;
					playing = false;
				};
				alpha.Play(forward);
				alpha.Reset();
				playing = true;
			}
			else if ((bool)widget)
			{
				widget.SetActive(forward);
			}
		}

		private void ShowLog(string str)
		{
			if ((bool)ctrl)
			{
				ctrl.ShowLog(str);
			}
		}

		public bool Equale(Blink b)
		{
			return b != null && id == b.id;
		}

		internal void _0024Play_0024closure_00245016(UITweener t)
		{
			t.onFinished = null;
			playing = false;
		}
	}

	[Serializable]
	public enum Mode
	{
		Start,
		Wait,
		In,
		Out,
		End
	}

	public readonly int START_NO;

	public Blink[] blinks;

	protected Mode play_mode;

	protected Mode last_mode;

	private float start_time;

	private float wait_time;

	private int lastNo;

	private int currentNo;

	private float last_sync_start_time;

	public bool debugLog;

	public UIBlinkSync sync;

	protected bool finished;

	private int currentMax => blinks.Count();

	private int prev_currentNo => get_valid_prevNo(currentNo);

	private int next_currentNo => get_valid_nextNo(currentNo);

	private Blink last => get_blink(lastNo);

	private Blink current => get_blink(currentNo);

	private Blink prev => get_blink(prev_currentNo);

	private Blink next => get_blink(next_currentNo);

	private bool notting
	{
		get
		{
			bool num = blinks == null;
			if (!num)
			{
				num = blinks.Count() <= 0;
			}
			return num;
		}
	}

	public bool isEnd => play_mode == Mode.End;

	public UIBlinkController()
	{
		START_NO = -1;
		lastNo = -1;
	}

	private int get_nextNo(int no)
	{
		return checked(no + 1) % currentMax;
	}

	private int get_prevNo(int no)
	{
		return checked(no - 1 + currentMax) % currentMax;
	}

	private Blink get_blink(int no)
	{
		object result;
		if (blinks != null && 0 < blinks.Count() && 0 <= no && no < blinks.Count())
		{
			Blink[] array = blinks;
			result = array[RuntimeServices.NormalizeArrayIndex(array, no)];
		}
		else
		{
			result = new Blink();
		}
		return (Blink)result;
	}

	private int get_shift_no(int no, bool isNext)
	{
		return (!isNext) ? get_prevNo(no) : get_nextNo(no);
	}

	private int get_valid_nextNo(int no)
	{
		return get_valid_no(no, isNext: true);
	}

	private int get_valid_prevNo(int no)
	{
		return get_valid_no(no, isNext: false);
	}

	private int get_valid_no(int no, bool isNext)
	{
		int num = 0;
		int num2 = currentMax;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			no = get_shift_no(no, isNext);
			if (isValidBlinkNo(no))
			{
				break;
			}
		}
		return no;
	}

	private bool isValidBlink(Blink b)
	{
		bool num = b == null;
		if (!num)
		{
			num = b.isEmpty;
		}
		return !num;
	}

	private bool isValidBlinkNo(int no)
	{
		return isValidBlink(get_blink(no));
	}

	protected Blink find(Blink blink)
	{
		return (blink == null) ? null : find(blink.id);
	}

	protected Blink find(string id)
	{
		int num;
		Blink[] array;
		if (!string.IsNullOrEmpty(id))
		{
			num = 0;
			array = blinks;
			int length = array.Length;
			while (num < length)
			{
				if (array[num] == null || !(array[num].id == id))
				{
					num = checked(num + 1);
					continue;
				}
				goto IL_0040;
			}
		}
		object result = null;
		goto IL_0054;
		IL_0054:
		return (Blink)result;
		IL_0040:
		result = array[num];
		goto IL_0054;
	}

	protected bool contains(Blink blink)
	{
		return find(blink) != null;
	}

	public void SetBlinkEnabled(string id, bool e)
	{
		Blink blink = find(id);
		if (blink != null)
		{
			blink.enabled = e;
		}
	}

	public bool Sync(UIBlinkController sync)
	{
		bool flag = false;
		int result;
		if (finished)
		{
			if (last_sync_start_time == sync.start_time)
			{
				result = 0;
				goto IL_0081;
			}
			last_sync_start_time = sync.start_time;
			if (isValidBlinkNo(sync.currentNo))
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			start_time = sync.start_time;
			wait_time = sync.wait_time;
			currentNo = sync.currentNo;
			play_mode = sync.play_mode;
		}
		result = 1;
		goto IL_0081;
		IL_0081:
		return (byte)result != 0;
	}

	private void ShowLog(string str)
	{
		if (!debugLog)
		{
		}
	}

	private void wait_start(float t)
	{
		ShowLog("wait_start:" + t);
		wait_time = t;
		start_time = Time.realtimeSinceStartup;
	}

	public float wait_end()
	{
		return start_time + wait_time;
	}

	private bool is_waiting()
	{
		return Time.realtimeSinceStartup < wait_end();
	}

	private float get_wait_time(float time, int no)
	{
		int num = no;
		int num2 = checked(currentMax + no);
		int num3 = 1;
		if (num2 < num)
		{
			num3 = -1;
		}
		while (num != num2)
		{
			int num4 = num;
			num += num3;
			int num5 = get_nextNo(num4 % currentMax);
			if (num5 == currentNo)
			{
				break;
			}
			Blink blink = get_blink(num5);
			if (blink != null && !blink.enabled)
			{
				time += blink.GetAllShowTime();
			}
		}
		return time;
	}

	private void Run()
	{
		if (!is_waiting() && play_mode != last_mode)
		{
			ShowLog("Change( " + last_mode.ToString() + " > " + play_mode.ToString() + " )");
			last_mode = play_mode;
			if (play_mode == Mode.Start)
			{
				ShowLog("Start");
				play_mode = Mode.In;
				ChangeNo(next_currentNo);
				ActiveAllCheck();
				current.SetActive(a: true);
				current.Play(forward: true);
				wait_start(current.getDuration);
			}
			else if (play_mode == Mode.In)
			{
				ShowLog("In");
				play_mode = Mode.Wait;
				wait_start(get_wait_time(current.getShowTime, currentNo));
			}
			else if (play_mode == Mode.Wait)
			{
				ShowLog("Wait");
				play_mode = Mode.Out;
				current.Play(forward: false);
				wait_start(current.getDuration);
			}
			else if (play_mode == Mode.Out)
			{
				ShowLog("Out");
				play_mode = Mode.End;
				wait_start(0f);
			}
			else if (play_mode == Mode.End)
			{
				ShowLog("End");
				play_mode = Mode.Start;
				current.SetActive(a: false);
			}
			else
			{
				ShowLog("else");
			}
		}
	}

	private void ChangeNo(int nextNo)
	{
		if (currentNo != nextNo)
		{
			lastNo = currentNo;
			currentNo = nextNo;
		}
	}

	private void ActiveAllCheck()
	{
		int num = 0;
		int num2 = currentMax;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Blink[] array = blinks;
			Blink blink = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
			if (blink != null)
			{
				blink.SetActive(a: true);
				bool flag = false;
				if (blink.enabled)
				{
					flag = num3 == currentNo;
				}
				blink.SetActive(flag);
			}
		}
	}

	public virtual void Initialize()
	{
		if (finished)
		{
			return;
		}
		ShowLog("Initialize()");
		if (blinks != null)
		{
			int i = 0;
			Blink[] array = blinks;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] != null)
				{
					array[i].Init(transform, this);
				}
			}
		}
		currentNo = START_NO;
		lastNo = START_NO;
		play_mode = Mode.Start;
		last_mode = Mode.End;
		wait_start(0f);
		finished = true;
	}

	public void OnEnable()
	{
		if (finished)
		{
			ShowLog("OnEnable()");
			if ((bool)sync)
			{
				Sync(sync);
			}
			ActiveAllCheck();
		}
	}

	private void Start()
	{
		Initialize();
		ShowLog("Start()");
	}

	private void LateUpdate()
	{
		if (!notting)
		{
			Run();
		}
	}
}
