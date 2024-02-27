using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class D540OpeCodePool
{
	[Serializable]
	public class Disposer : D540DepthFirstTraverser
	{
		private D540OpeCodePool pool;

		public Disposer(D540OpeCodePool _pool)
		{
			pool = _pool;
		}

		public override void defaultOut(D540OpeCode node)
		{
			if (node != null)
			{
				pool._dispose(node);
			}
		}
	}

	[NonSerialized]
	private static D540OpeCodePool _instance;

	[NonSerialized]
	private static ICallable[] ALLOCATORS = new ICallable[37]
	{
		(__D540OpeCodePool_0024callable26_002415_9__)(() => new D540OpeNop()),
		(__D540OpeCodePool_0024callable27_002416_9__)(() => new D540OpeExecBlock()),
		(__D540OpeCodePool_0024callable28_002417_9__)(() => new D540OpeCompound()),
		(__D540OpeCodePool_0024callable29_002418_9__)(() => new D540OpeEcho()),
		(__D540OpeCodePool_0024callable30_002419_9__)(() => new D540OpeSelf()),
		(__D540OpeCodePool_0024callable31_002420_9__)(() => new D540OpePrint()),
		(__D540OpeCodePool_0024callable32_002421_9__)(() => new D540OpeSlicing()),
		(__D540OpeCodePool_0024callable33_002422_9__)(() => new D540OpeBinary()),
		(__D540OpeCodePool_0024callable34_002423_9__)(() => new D540OpeUnary()),
		(__D540OpeCodePool_0024callable35_002424_9__)(() => new D540OpeDup()),
		(__D540OpeCodePool_0024callable36_002425_9__)(() => new D540OpePrefab()),
		(__D540OpeCodePool_0024callable37_002426_9__)(() => new D540OpeIfElse()),
		(__D540OpeCodePool_0024callable38_002427_9__)(() => new D540OpeInvokeMethod()),
		(__D540OpeCodePool_0024callable39_002428_9__)(() => new D540OpeInvokeExtMethod()),
		(__D540OpeCodePool_0024callable40_002429_9__)(() => new D540OpeArrayLiteral()),
		(__D540OpeCodePool_0024callable41_002430_9__)(() => new D540OpePropertyValue()),
		(__D540OpeCodePool_0024callable42_002431_9__)(() => new D540OpeField()),
		(__D540OpeCodePool_0024callable43_002432_9__)(() => new D540OpeExtField()),
		(__D540OpeCodePool_0024callable44_002433_9__)(() => new D540OpeAssignExtField()),
		(__D540OpeCodePool_0024callable45_002434_9__)(() => new D540OpeCast()),
		(__D540OpeCodePool_0024callable46_002435_9__)(() => new D540OpeExprStatement()),
		(__D540OpeCodePool_0024callable47_002436_9__)(() => new D540OpeWhile()),
		(__D540OpeCodePool_0024callable48_002437_9__)(() => new D540OpeDeclVar()),
		(__D540OpeCodePool_0024callable49_002438_9__)(() => new D540OpeAssign()),
		(__D540OpeCodePool_0024callable50_002439_9__)(() => new D540OpeLocalVar()),
		(__D540OpeCodePool_0024callable51_002440_9__)(() => new D540OpeBuiltinFunc()),
		(__D540OpeCodePool_0024callable52_002441_9__)(() => new D540OpeMotionID()),
		(__D540OpeCodePool_0024callable53_002442_9__)(() => new D540OpeEnumOrString()),
		(__D540OpeCodePool_0024callable54_002443_9__)(() => new D540OpeValue()),
		(__D540OpeCodePool_0024callable55_002444_9__)(() => new D540OpeValueInt()),
		(__D540OpeCodePool_0024callable56_002445_9__)(() => new D540OpeValueObject()),
		(__D540OpeCodePool_0024callable57_002446_9__)(() => new D540OpeValueSingle()),
		(__D540OpeCodePool_0024callable58_002447_9__)(() => new D540OpeValueString()),
		(__D540OpeCodePool_0024callable59_002448_9__)(() => new D540OpeValueVector2()),
		(__D540OpeCodePool_0024callable60_002449_9__)(() => new D540OpeValueVector3()),
		(__D540OpeCodePool_0024callable61_002450_9__)(() => new D540OpeValueBool()),
		(__D540OpeCodePool_0024callable62_002451_9__)(() => new D540OpeAssert())
	};

	private Queue<D540OpeCode>[] codePool;

	private Disposer disposer;

	private int totalAllocationCount;

	private int totalDeallocationCount;

	private bool isInAllocation;

	public static D540OpeCodePool Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new D540OpeCodePool();
			}
			return _instance;
		}
	}

	public int ExpectedCurrentAllocationCount => checked(totalAllocationCount - totalDeallocationCount);

	public int TotalAllocationCount => totalAllocationCount;

	public int TotalDeallocationCount => totalDeallocationCount;

	public bool IsInAllocation => isInAllocation;

	public D540OpeCodePool()
	{
		initialize();
	}

	public void initialize()
	{
		int length = ALLOCATORS.Length;
		codePool = new Queue<D540OpeCode>[length];
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Queue<D540OpeCode>[] array = codePool;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = new Queue<D540OpeCode>();
		}
		disposer = new Disposer(this);
	}

	public void reserve()
	{
		__D540OpeCodePool_reserve_0024callable63_002483_13__ _D540OpeCodePool_reserve_0024callable63_002483_13__ = delegate(D540OpeCodeId id, int n)
		{
			int num = 0;
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < n)
			{
				int num2 = num;
				num++;
				D540OpeCode node = newObj(id) as D540OpeCode;
				_dispose(node);
			}
		};
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeNop, 50);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeExecBlock, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeCompound, 300);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeEcho, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeSelf, 170);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpePrint, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeSlicing, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeBinary, 90);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeUnary, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeDup, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpePrefab, 370);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeIfElse, 80);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeInvokeMethod, 2200);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeInvokeExtMethod, 180);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeArrayLiteral, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpePropertyValue, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeField, 30);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeExtField, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeAssignExtField, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeCast, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeExprStatement, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeWhile, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeDeclVar, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeAssign, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeLocalVar, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeBuiltinFunc, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeMotionID, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeEnumOrString, 110);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValue, 80);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueInt, 5400);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueObject, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueSingle, 1600);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueString, 790);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueVector2, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueVector3, 0);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeValueBool, 230);
		_D540OpeCodePool_reserve_0024callable63_002483_13__(D540OpeCodeId.OpeAssert, 0);
	}

	public int getPoolingNum(D540OpeCodeId id)
	{
		int result;
		if (id < D540OpeCodeId.OpeNop || (int)id >= codePool.Length)
		{
			result = 0;
		}
		else
		{
			Queue<D540OpeCode>[] array = codePool;
			result = array[RuntimeServices.NormalizeArrayIndex(array, (int)id)].Count;
		}
		return result;
	}

	public static D540OpeCode NewObj(D540OpeCodeId id)
	{
		return Instance.newObj(id);
	}

	public D540OpeCode newObj(D540OpeCodeId id)
	{
		if (D540OpeCodeId.OpeNop > id || (int)id >= codePool.Length)
		{
			throw new AssertionFailedException(new StringBuilder("OpeCodePool.newObj id=").Append(id).ToString());
		}
		isInAllocation = true;
		Queue<D540OpeCode>[] array = codePool;
		Queue<D540OpeCode> queue = array[RuntimeServices.NormalizeArrayIndex(array, (int)id)];
		D540OpeCode d540OpeCode = null;
		if (queue.Count <= 0)
		{
			ICallable[] aLLOCATORS = ALLOCATORS;
			d540OpeCode = aLLOCATORS[RuntimeServices.NormalizeArrayIndex(aLLOCATORS, (int)id)].Call(new object[0]) as D540OpeCode;
		}
		else
		{
			d540OpeCode = queue.Dequeue();
		}
		checked
		{
			totalAllocationCount++;
			isInAllocation = false;
			if (d540OpeCode == null)
			{
				throw new AssertionFailedException(new StringBuilder("could not allocate D540OpeCode ").Append(id).ToString());
			}
			d540OpeCode.poolId = id;
			d540OpeCode.clear();
			return d540OpeCode;
		}
	}

	public void dispose(D540OpeCode node)
	{
		node?.apply(disposer);
	}

	public void _dispose(D540OpeCode node)
	{
		if (node != null)
		{
			D540OpeCodeId poolId = node.poolId;
			if (poolId >= D540OpeCodeId.OpeNop && ALLOCATORS.Length > (int)poolId)
			{
				Queue<D540OpeCode>[] array = codePool;
				array[RuntimeServices.NormalizeArrayIndex(array, (int)poolId)].Enqueue(node);
				node.poolId = (D540OpeCodeId)(-1);
				checked
				{
					totalDeallocationCount++;
				}
			}
		}
	}

	internal static D540OpeNop _0024constructor_0024closure_00241004()
	{
		return new D540OpeNop();
	}

	internal static D540OpeExecBlock _0024constructor_0024closure_00241005()
	{
		return new D540OpeExecBlock();
	}

	internal static D540OpeCompound _0024constructor_0024closure_00241006()
	{
		return new D540OpeCompound();
	}

	internal static D540OpeEcho _0024constructor_0024closure_00241007()
	{
		return new D540OpeEcho();
	}

	internal static D540OpeSelf _0024constructor_0024closure_00241008()
	{
		return new D540OpeSelf();
	}

	internal static D540OpePrint _0024constructor_0024closure_00241009()
	{
		return new D540OpePrint();
	}

	internal static D540OpeSlicing _0024constructor_0024closure_00241010()
	{
		return new D540OpeSlicing();
	}

	internal static D540OpeBinary _0024constructor_0024closure_00241011()
	{
		return new D540OpeBinary();
	}

	internal static D540OpeUnary _0024constructor_0024closure_00241012()
	{
		return new D540OpeUnary();
	}

	internal static D540OpeDup _0024constructor_0024closure_00241013()
	{
		return new D540OpeDup();
	}

	internal static D540OpePrefab _0024constructor_0024closure_00241014()
	{
		return new D540OpePrefab();
	}

	internal static D540OpeIfElse _0024constructor_0024closure_00241015()
	{
		return new D540OpeIfElse();
	}

	internal static D540OpeInvokeMethod _0024constructor_0024closure_00241016()
	{
		return new D540OpeInvokeMethod();
	}

	internal static D540OpeInvokeExtMethod _0024constructor_0024closure_00241017()
	{
		return new D540OpeInvokeExtMethod();
	}

	internal static D540OpeArrayLiteral _0024constructor_0024closure_00241018()
	{
		return new D540OpeArrayLiteral();
	}

	internal static D540OpePropertyValue _0024constructor_0024closure_00241019()
	{
		return new D540OpePropertyValue();
	}

	internal static D540OpeField _0024constructor_0024closure_00241020()
	{
		return new D540OpeField();
	}

	internal static D540OpeExtField _0024constructor_0024closure_00241021()
	{
		return new D540OpeExtField();
	}

	internal static D540OpeAssignExtField _0024constructor_0024closure_00241022()
	{
		return new D540OpeAssignExtField();
	}

	internal static D540OpeCast _0024constructor_0024closure_00241023()
	{
		return new D540OpeCast();
	}

	internal static D540OpeExprStatement _0024constructor_0024closure_00241024()
	{
		return new D540OpeExprStatement();
	}

	internal static D540OpeWhile _0024constructor_0024closure_00241025()
	{
		return new D540OpeWhile();
	}

	internal static D540OpeDeclVar _0024constructor_0024closure_00241026()
	{
		return new D540OpeDeclVar();
	}

	internal static D540OpeAssign _0024constructor_0024closure_00241027()
	{
		return new D540OpeAssign();
	}

	internal static D540OpeLocalVar _0024constructor_0024closure_00241028()
	{
		return new D540OpeLocalVar();
	}

	internal static D540OpeBuiltinFunc _0024constructor_0024closure_00241029()
	{
		return new D540OpeBuiltinFunc();
	}

	internal static D540OpeMotionID _0024constructor_0024closure_00241030()
	{
		return new D540OpeMotionID();
	}

	internal static D540OpeEnumOrString _0024constructor_0024closure_00241035()
	{
		return new D540OpeEnumOrString();
	}

	internal static D540OpeValue _0024constructor_0024closure_00241036()
	{
		return new D540OpeValue();
	}

	internal static D540OpeValueInt _0024constructor_0024closure_00241037()
	{
		return new D540OpeValueInt();
	}

	internal static D540OpeValueObject _0024constructor_0024closure_00241038()
	{
		return new D540OpeValueObject();
	}

	internal static D540OpeValueSingle _0024constructor_0024closure_00241039()
	{
		return new D540OpeValueSingle();
	}

	internal static D540OpeValueString _0024constructor_0024closure_00241040()
	{
		return new D540OpeValueString();
	}

	internal static D540OpeValueVector2 _0024constructor_0024closure_00241041()
	{
		return new D540OpeValueVector2();
	}

	internal static D540OpeValueVector3 _0024constructor_0024closure_00241042()
	{
		return new D540OpeValueVector3();
	}

	internal static D540OpeValueBool _0024constructor_0024closure_00241043()
	{
		return new D540OpeValueBool();
	}

	internal static D540OpeAssert _0024constructor_0024closure_00241044()
	{
		return new D540OpeAssert();
	}

	internal void _0024reserve_0024_rsrv_00241045(D540OpeCodeId id, int n)
	{
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int num2 = num;
			num++;
			D540OpeCode node = newObj(id) as D540OpeCode;
			_dispose(node);
		}
	}
}
