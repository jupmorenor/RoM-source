using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MerlinTaskQueue : MonoBehaviour
{
	[Serializable]
	public class Task : IComparable<Task>
	{
		[Serializable]
		public enum PresetPriority
		{
			LoginBonus = 100
		}

		private int priority;

		private Action onStart;

		private Func<bool> isCompleted;

		private Action onExit;

		public int Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}

		public Action OnStart
		{
			get
			{
				return onStart;
			}
			set
			{
				onStart = value;
			}
		}

		public Func<bool> IsCompleted
		{
			get
			{
				return isCompleted;
			}
			set
			{
				isCompleted = value;
			}
		}

		public Action OnExit
		{
			get
			{
				return onExit;
			}
			set
			{
				onExit = value;
			}
		}

		public virtual int CompareTo(Task obj)
		{
			return priority.CompareTo(obj.priority);
		}
	}

	[Serializable]
	public class CoroutineTask : Task
	{
		[Serializable]
		internal class _0024constructor_0024locals_002414574
		{
			internal bool _0024finish;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024cr;

			internal __GouseiSequense_S540_init_0024callable40_002410_5__ _0024fun;
		}

		[Serializable]
		internal class _0024constructor_0024cr_00242928
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024Invoke_002423079 : GenericGenerator<Coroutine>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
				{
					internal _0024constructor_0024cr_00242928 _0024self__002423080;

					public _0024(_0024constructor_0024cr_00242928 self_)
					{
						_0024self__002423080 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							result = (Yield(2, Instance.StartCoroutine(_0024self__002423080._0024_0024locals_002415267._0024fun())) ? 1 : 0);
							break;
						case 2:
							_0024self__002423080._0024_0024locals_002415267._0024finish = true;
							YieldDefault(1);
							goto case 1;
						case 1:
							result = 0;
							break;
						}
						return (byte)result != 0;
					}
				}

				internal _0024constructor_0024cr_00242928 _0024self__002423081;

				public _0024Invoke_002423079(_0024constructor_0024cr_00242928 self_)
				{
					_0024self__002423081 = self_;
				}

				public override IEnumerator<Coroutine> GetEnumerator()
				{
					return new _0024(_0024self__002423081);
				}
			}

			internal _0024constructor_0024locals_002414574 _0024_0024locals_002415267;

			public _0024constructor_0024cr_00242928(_0024constructor_0024locals_002414574 _0024_0024locals_002415267)
			{
				this._0024_0024locals_002415267 = _0024_0024locals_002415267;
			}

			public IEnumerator Invoke()
			{
				return new _0024Invoke_002423079(this).GetEnumerator();
			}
		}

		[Serializable]
		internal class _0024constructor_0024closure_00242929
		{
			internal _0024constructor_0024locals_002414574 _0024_0024locals_002415268;

			public _0024constructor_0024closure_00242929(_0024constructor_0024locals_002414574 _0024_0024locals_002415268)
			{
				this._0024_0024locals_002415268 = _0024_0024locals_002415268;
			}

			public void Invoke()
			{
				Instance.StartCoroutine(_0024_0024locals_002415268._0024cr());
			}
		}

		[Serializable]
		internal class _0024constructor_0024closure_00242930
		{
			internal _0024constructor_0024locals_002414574 _0024_0024locals_002415269;

			public _0024constructor_0024closure_00242930(_0024constructor_0024locals_002414574 _0024_0024locals_002415269)
			{
				this._0024_0024locals_002415269 = _0024_0024locals_002415269;
			}

			public bool Invoke()
			{
				return _0024_0024locals_002415269._0024finish;
			}
		}

		public CoroutineTask(__GouseiSequense_S540_init_0024callable40_002410_5__ fun)
		{
			_0024constructor_0024locals_002414574 _0024constructor_0024locals_0024 = new _0024constructor_0024locals_002414574
			{
				_0024fun = fun
			};
			base._002Ector();
			_0024constructor_0024locals_0024._0024finish = false;
			_0024constructor_0024locals_0024._0024cr = new _0024constructor_0024cr_00242928(_0024constructor_0024locals_0024).Invoke;
			OnStart = new _0024constructor_0024closure_00242929(_0024constructor_0024locals_0024).Invoke;
			IsCompleted = new _0024constructor_0024closure_00242930(_0024constructor_0024locals_0024).Invoke;
			OnExit = delegate
			{
			};
		}

		internal void _0024constructor_0024closure_00242931()
		{
		}
	}

	[NonSerialized]
	private static MerlinTaskQueue instance;

	private Boo.Lang.List<Task> queue;

	private Task current;

	public static MerlinTaskQueue Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject gameObject = new GameObject();
				gameObject.name = "MerlinTaskQueue Holder";
				instance = gameObject.AddComponent<MerlinTaskQueue>();
				instance.Initialize();
			}
			return instance;
		}
	}

	public bool IsEmpty => current == null && queue.Count == 0;

	public void Initialize()
	{
		current = null;
		queue = new Boo.Lang.List<Task>();
	}

	public void Enqueue(Task task)
	{
		queue.Add(task);
		queue.Sort();
		queue.Reverse();
		if (!(task.OnStart != null))
		{
			throw new AssertionFailedException("task.OnStart != null");
		}
		if (!(task.IsCompleted != null))
		{
			throw new AssertionFailedException("task.IsCompleted != null");
		}
		if (!(task.OnExit != null))
		{
			throw new AssertionFailedException("task.OnExit != null");
		}
	}

	public bool IsEnableStartTask()
	{
		return SceneChanger.isCompletelyReady ? true : false;
	}

	public void Update()
	{
		if (current == null && IsEnableStartTask() && 0 < queue.Count)
		{
			current = queue[0];
			queue.RemoveAt(0);
			if (current != null)
			{
				if (!(current.OnStart != null))
				{
					throw new AssertionFailedException("current.OnStart != null");
				}
				if (!(current.IsCompleted != null))
				{
					throw new AssertionFailedException("current.IsCompleted != null");
				}
				if (!(current.OnExit != null))
				{
					throw new AssertionFailedException("current.OnExit != null");
				}
				current.OnStart();
			}
		}
		if (current != null && current.IsCompleted())
		{
			current.OnExit();
			current = null;
		}
	}
}
