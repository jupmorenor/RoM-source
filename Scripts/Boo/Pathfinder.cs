using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;
using UnityEngine;

[Serializable]
public class Pathfinder : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadTileAsync_002416919 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB.Req _0024r_002416920;

			internal TextAsset _0024tileData_002416921;

			internal string _0024resultLoadPath_002416922;

			internal Pathfinder _0024self__002416923;

			public _0024(string resultLoadPath, Pathfinder self_)
			{
				_0024resultLoadPath_002416922 = resultLoadPath;
				_0024self__002416923 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (string.IsNullOrEmpty(_0024resultLoadPath_002416922))
					{
						goto case 1;
					}
					_0024r_002416920 = RuntimeAssetBundleDB.Instance.loadAsset(_0024resultLoadPath_002416922, typeof(TextAsset));
					goto case 2;
				case 2:
					if (!_0024r_002416920.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024r_002416920.IsOk && _0024r_002416920.Asset is TextAsset)
					{
						_0024tileData_002416921 = _0024r_002416920.Asset as TextAsset;
						_0024self__002416923.LoadTileData(new BinaryReader(new MemoryStream(_0024tileData_002416921.bytes)));
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

		internal string _0024resultLoadPath_002416924;

		internal Pathfinder _0024self__002416925;

		public _0024LoadTileAsync_002416919(string resultLoadPath, Pathfinder self_)
		{
			_0024resultLoadPath_002416924 = resultLoadPath;
			_0024self__002416925 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024resultLoadPath_002416924, _0024self__002416925);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PathHandler_002416926 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal Vector3 _0024startPos_002416927;

			internal Vector3 _0024endPos_002416928;

			internal __Pathfinder_InsertInQueue_0024callable59_0024465_84__ _0024listMethod_002416929;

			internal Pathfinder _0024self__002416930;

			public _0024(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod, Pathfinder self_)
			{
				_0024startPos_002416927 = startPos;
				_0024endPos_002416928 = endPos;
				_0024listMethod_002416929 = listMethod;
				_0024self__002416930 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, _0024self__002416930.StartCoroutine(_0024self__002416930.SinglePath(_0024startPos_002416927, _0024endPos_002416928, _0024listMethod_002416929))) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024startPos_002416931;

		internal Vector3 _0024endPos_002416932;

		internal __Pathfinder_InsertInQueue_0024callable59_0024465_84__ _0024listMethod_002416933;

		internal Pathfinder _0024self__002416934;

		public _0024PathHandler_002416926(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod, Pathfinder self_)
		{
			_0024startPos_002416931 = startPos;
			_0024endPos_002416932 = endPos;
			_0024listMethod_002416933 = listMethod;
			_0024self__002416934 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024startPos_002416931, _0024endPos_002416932, _0024listMethod_002416933, _0024self__002416934);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SinglePath_002416935 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Vector3 _0024startPos_002416936;

			internal Vector3 _0024endPos_002416937;

			internal __Pathfinder_InsertInQueue_0024callable59_0024465_84__ _0024listMethod_002416938;

			internal Pathfinder _0024self__002416939;

			public _0024(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod, Pathfinder self_)
			{
				_0024startPos_002416936 = startPos;
				_0024endPos_002416937 = endPos;
				_0024listMethod_002416938 = listMethod;
				_0024self__002416939 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002416939.FindPath(_0024startPos_002416936, _0024endPos_002416937, _0024listMethod_002416938);
					result = (Yield(2, null) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Vector3 _0024startPos_002416940;

		internal Vector3 _0024endPos_002416941;

		internal __Pathfinder_InsertInQueue_0024callable59_0024465_84__ _0024listMethod_002416942;

		internal Pathfinder _0024self__002416943;

		public _0024SinglePath_002416935(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod, Pathfinder self_)
		{
			_0024startPos_002416940 = startPos;
			_0024endPos_002416941 = endPos;
			_0024listMethod_002416942 = listMethod;
			_0024self__002416943 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024startPos_002416940, _0024endPos_002416941, _0024listMethod_002416942, _0024self__002416943);
		}
	}

	[NonSerialized]
	private static Pathfinder instance;

	public TextAsset tile;

	private Node[,] Map;

	public float Tilesize;

	public float MaxFalldownHeight;

	public float ClimbLimit;

	public int HeuristicAggression;

	public float HighestPoint;

	public float LowestPoint;

	public Vector2 MapStartPosition;

	public Vector2 MapEndPosition;

	public System.Collections.Generic.List<string> DisallowedTags;

	public System.Collections.Generic.List<string> IgnoreTags;

	public bool MoveDiagonal;

	public bool DrawMapInEditor;

	public bool CheckFullTileSize;

	private float updateinterval;

	private int frames;

	private float timeleft;

	private int FPS;

	private int times;

	private int averageFPS;

	private int maxSearchRounds;

	private System.Collections.Generic.List<QueuePath> queue;

	public bool IsEditMode;

	public bool TDObjectView;

	private TDManager tdManager;

	private float fModifyTileSize;

	private float TILE_FILE_VERSION;

	[NonSerialized]
	private const string TILE_FILE_PATH_FMT = "Assets/AssetBundles/assetpack/Tile/Tile_{0}";

	[NonSerialized]
	private const string TILE_FILE_EXT = ".bytes";

	[NonSerialized]
	private const string TILE_FILENAME_FMT = "Tile_{0}.bytes";

	private float overalltimer;

	private int iterations;

	private Node[] openList;

	private Node[] closedList;

	private Node startNode;

	private Node endNode;

	private Node currentNode;

	private System.Collections.Generic.List<NodeSearch> sortedOpenList;

	public int QueueNum => queue.Count;

	public static Pathfinder Instance => instance;

	public Pathfinder()
	{
		Tilesize = 1f;
		MaxFalldownHeight = 1f;
		ClimbLimit = 1f;
		HeuristicAggression = 1;
		HighestPoint = 100f;
		LowestPoint = -50f;
		MapStartPosition = Vector2.zero;
		MapEndPosition = Vector2.zero;
		DisallowedTags = new System.Collections.Generic.List<string>();
		IgnoreTags = new System.Collections.Generic.List<string>();
		MoveDiagonal = true;
		updateinterval = 1f;
		timeleft = 1f;
		FPS = 60;
		queue = new System.Collections.Generic.List<QueuePath>();
		fModifyTileSize = 0.5f;
		TILE_FILE_VERSION = 1f;
		sortedOpenList = new System.Collections.Generic.List<NodeSearch>();
	}

	public void enumerateQueue(__Pathfinder_enumerateQueue_0024callable58_002466_37__ c)
	{
		foreach (QueuePath item in queue)
		{
			if (c != null)
			{
				c(item);
			}
		}
	}

	public void Awake()
	{
		instance = this;
	}

	public void Start()
	{
		if (!(Tilesize > 0f))
		{
			Tilesize = 1f;
		}
		fModifyTileSize = Tilesize / 2f;
		GameObject gameObject = GameObject.Find("TileEditor");
		if (gameObject != null)
		{
			tdManager = gameObject.GetComponent<TDManager>();
		}
		StartCoroutine(LoadTileAsync(CurrentSceneTileFilePath()));
	}

	public void OnDestroy()
	{
		destruct();
	}

	private void destruct()
	{
		Map = null;
		tile = null;
		queue.Clear();
		DisallowedTags.Clear();
		IgnoreTags.Clear();
	}

	private IEnumerator LoadTileAsync(string resultLoadPath)
	{
		return new _0024LoadTileAsync_002416919(resultLoadPath, this).GetEnumerator();
	}

	private string CurrentSceneTileFilePath()
	{
		return TileDataFilePath(CurrentSceneName());
	}

	private string CurrentSceneTileFilePathWithExtension()
	{
		return TileDataFilePathWithExtension(CurrentSceneName());
	}

	private string CurrentSceneName()
	{
		return SceneChanger.CurrentSceneName;
	}

	public static string TileDataFilePath(string sceneName)
	{
		return string.IsNullOrEmpty(sceneName) ? string.Empty : UIBasicUtility.SafeFormat("Assets/AssetBundles/assetpack/Tile/Tile_{0}", sceneName);
	}

	public static string TileDataFilePathWithExtension(string sceneName)
	{
		return TileDataFilePath(sceneName) + ".bytes";
	}

	public static string TileDataFileName(string sceneName)
	{
		return string.IsNullOrEmpty(sceneName) ? string.Empty : UIBasicUtility.SafeFormat("Tile_{0}.bytes", sceneName);
	}

	public void Update()
	{
		timeleft -= Time.deltaTime;
		checked
		{
			frames++;
			if (!(timeleft > 0f))
			{
				FPS = frames;
				averageFPS += frames;
				times++;
				timeleft = updateinterval;
				frames = 0;
			}
			float num = 0f;
			float num2 = 1000f / (float)FPS;
			while (queue.Count > 0 && num < num2)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				StartCoroutine(PathHandler(queue[0].startPos, queue[0].endPos, queue[0].storeRef));
				queue.RemoveAt(0);
				stopwatch.Stop();
				num += (float)stopwatch.ElapsedMilliseconds;
				overalltimer += stopwatch.ElapsedMilliseconds;
				iterations++;
			}
			DrawMapLines();
			UpdateEditMode();
		}
	}

	public void UpdateEditMode()
	{
		if (!IsEditMode || !TDObjectView || !(tdManager != null))
		{
			return;
		}
		Vector3 vector = CheckPosition();
		if (vector != Vector3.zero && Input.GetButtonDown("Fire2"))
		{
			int index = GetIndex(vector.x, vector.z);
			if (index > -1)
			{
				tdManager.CreateTD(index, vector);
			}
		}
	}

	public void CreateMap()
	{
		int num;
		int num2;
		int num5;
		int num7;
		int num8;
		checked
		{
			num = (int)MapStartPosition.x;
			num2 = (int)MapStartPosition.y;
			int num3 = (int)MapEndPosition.x;
			int num4 = (int)MapEndPosition.y;
			num5 = (int)((float)(num3 - num) / Tilesize);
			int num6 = (int)((float)(num4 - num2) / Tilesize);
			Map = (Node[,])Builtins.matrix(typeof(Node), num5, num6);
			int listsSize = num5 * num6;
			SetListsSize(listsSize);
			num7 = 0;
			num8 = num6;
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		while (num7 < num8)
		{
			int num9 = num7;
			num7++;
			int num10 = 0;
			int num11 = num5;
			if (num11 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num10 < num11)
			{
				int num12 = num10;
				num10++;
				float num13 = (float)num + (float)num12 * Tilesize + Tilesize / 2f;
				float num14 = (float)num2 + (float)num9 * Tilesize + Tilesize / 2f;
				int num15 = checked(num9 * num5 + num12);
				Vector3 zero = Vector3.zero;
				zero = ObjUtilModule.GetGroundHeight(num13, num14);
				bool flag = true;
				float num16 = float.NegativeInfinity;
				if (!(zero.y <= num16))
				{
					Map[num12, num9] = new Node(num12, num9, zero.y, num15, num13, num14, w: true, null);
					flag = false;
					if (TDObjectView && tdManager != null)
					{
						tdManager.CreateTD(num15, zero);
					}
				}
				if (flag)
				{
					Map[num12, num9] = new Node(num12, num9, 0f, num15, num13, num14, w: false, null);
				}
			}
		}
	}

	public void ClearMap()
	{
		DrawMapInEditor = false;
		if (!(tdManager == null))
		{
			tdManager.RemoveTDAll();
		}
	}

	public void SaveTileFileAsCurrentSceneData()
	{
		string savePath = CurrentSceneTileFilePathWithExtension();
		SaveTileFile(savePath);
	}

	public bool SaveTileFile(string savePath)
	{
		FileStream fileStream = new FileStream(savePath, FileMode.Create);
		int result;
		if (fileStream == null)
		{
			result = 0;
		}
		else
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			if (binaryWriter == null)
			{
				result = 0;
			}
			else
			{
				int num5;
				int num7;
				int num8;
				checked
				{
					int num = (int)MapStartPosition.x;
					int num2 = (int)MapStartPosition.y;
					int num3 = (int)MapEndPosition.x;
					int num4 = (int)MapEndPosition.y;
					num5 = (int)((float)(num3 - num) / Tilesize);
					int num6 = (int)((float)(num4 - num2) / Tilesize);
					binaryWriter.Write(TILE_FILE_VERSION);
					binaryWriter.Write(MapStartPosition.x);
					binaryWriter.Write(MapStartPosition.y);
					binaryWriter.Write(MapEndPosition.x);
					binaryWriter.Write(MapEndPosition.y);
					binaryWriter.Write(Tilesize);
					binaryWriter.Write(HighestPoint);
					binaryWriter.Write(LowestPoint);
					binaryWriter.Write(CheckFullTileSize);
					binaryWriter.Write(MoveDiagonal);
					num7 = 0;
					num8 = num6;
					if (num8 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
				}
				while (num7 < num8)
				{
					int num9 = num7;
					num7++;
					int num10 = 0;
					int num11 = num5;
					if (num11 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num10 < num11)
					{
						int num12 = num10;
						num10++;
						Node node = Map[num12, num9];
						binaryWriter.Write(node.walkable);
					}
				}
				binaryWriter.Close();
				result = 1;
			}
		}
		return (byte)result != 0;
	}

	public Node GetTileNode(Vector3 pos)
	{
		int num = ((MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - MapStartPosition.x) / Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(MapStartPosition.x)) / Tilesize));
		int num2 = ((MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - MapStartPosition.y) / Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(MapStartPosition.y)) / Tilesize));
		return (num >= 0 && num2 >= 0 && num <= Map.GetLength(0) && num2 <= Map.GetLength(1)) ? Map[num, num2] : null;
	}

	public bool LoadTileFile(string resultLoadPath, bool editMode)
	{
		BinaryReader binaryReader = null;
		int result;
		if (!editMode)
		{
			byte[] array = File.ReadAllBytes(resultLoadPath);
			if (array == null)
			{
				result = 0;
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream(array);
				if (memoryStream == null)
				{
					result = 0;
				}
				else
				{
					binaryReader = new BinaryReader(memoryStream);
					if (binaryReader != null)
					{
						goto IL_0073;
					}
					result = 0;
				}
			}
		}
		else
		{
			FileStream fileStream = new FileStream(resultLoadPath, FileMode.Open);
			if (fileStream == null)
			{
				result = 0;
			}
			else
			{
				binaryReader = new BinaryReader(fileStream);
				if (binaryReader != null)
				{
					goto IL_0073;
				}
				result = 0;
			}
		}
		goto IL_007c;
		IL_0073:
		LoadTileData(binaryReader);
		result = 0;
		goto IL_007c;
		IL_007c:
		return (byte)result != 0;
	}

	private bool LoadTileData(BinaryReader br)
	{
		if (br == null)
		{
			throw new AssertionFailedException("br != null");
		}
		float num = br.ReadSingle();
		MapStartPosition.x = br.ReadSingle();
		MapStartPosition.y = br.ReadSingle();
		MapEndPosition.x = br.ReadSingle();
		MapEndPosition.y = br.ReadSingle();
		Tilesize = br.ReadSingle();
		HighestPoint = br.ReadSingle();
		LowestPoint = br.ReadSingle();
		CheckFullTileSize = br.ReadBoolean();
		MoveDiagonal = br.ReadBoolean();
		int num2;
		int num3;
		int num6;
		int num8;
		int num9;
		checked
		{
			num2 = (int)MapStartPosition.x;
			num3 = (int)MapStartPosition.y;
			int num4 = (int)MapEndPosition.x;
			int num5 = (int)MapEndPosition.y;
			num6 = (int)((float)(num4 - num2) / Tilesize);
			int num7 = (int)((float)(num5 - num3) / Tilesize);
			Map = (Node[,])Builtins.matrix(typeof(Node), num6, num7);
			int listsSize = num6 * num7;
			SetListsSize(listsSize);
			num8 = 0;
			num9 = num7;
			if (num9 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		while (num8 < num9)
		{
			int num10 = num8;
			num8++;
			int num11 = 0;
			int num12 = num6;
			if (num12 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num11 < num12)
			{
				int num13 = num11;
				num11++;
				float num14 = (float)num2 + (float)num13 * Tilesize + Tilesize / 2f;
				float num15 = (float)num3 + (float)num10 * Tilesize + Tilesize / 2f;
				int num16 = checked(num10 * num6 + num13);
				Vector3 zero = Vector3.zero;
				zero = ObjUtilModule.GetGroundHeight(num14, num15);
				bool flag = true;
				float num17 = float.NegativeInfinity;
				bool flag2 = false;
				flag2 = br.ReadBoolean();
				if (!(zero.y <= num17))
				{
					Map[num13, num10] = new Node(num13, num10, zero.y, num16, num14, num15, flag2, null);
					flag = false;
					if (TDObjectView && flag2 && tdManager != null)
					{
						tdManager.CreateTD(num16, zero);
					}
				}
				if (flag)
				{
					Map[num13, num10] = new Node(num13, num10, 0f, num16, num14, num15, flag2, null);
				}
			}
		}
		br.Close();
		return true;
	}

	public void InsertInQueue(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod)
	{
		QueuePath item = new QueuePath(startPos, endPos, listMethod);
		queue.Add(item);
	}

	public bool IsQueuing()
	{
		return queue.Count > 0;
	}

	private void SetListsSize(int size)
	{
		openList = (Node[])Builtins.matrix(typeof(Node), size);
		closedList = (Node[])Builtins.matrix(typeof(Node), size);
	}

	private IEnumerator PathHandler(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod)
	{
		return new _0024PathHandler_002416926(startPos, endPos, listMethod, this).GetEnumerator();
	}

	private IEnumerator SinglePath(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod)
	{
		return new _0024SinglePath_002416935(startPos, endPos, listMethod, this).GetEnumerator();
	}

	public void FindPath(Vector3 startPos, Vector3 endPos, __Pathfinder_InsertInQueue_0024callable59_0024465_84__ listMethod)
	{
		System.Collections.Generic.List<Vector3> list = new System.Collections.Generic.List<Vector3>();
		bool flag = true;
		SetStartAndEndNode(ref startPos, ref endPos);
		checked
		{
			if (startNode != null)
			{
				if (endNode == null)
				{
					flag = false;
					FindEndNode(endPos);
					if (endNode == null)
					{
						maxSearchRounds = 0;
						listMethod(endPos, new System.Collections.Generic.List<Vector3>());
						return;
					}
				}
				Array.Clear(openList, 0, openList.Length);
				Array.Clear(closedList, 0, openList.Length);
				if (sortedOpenList.Count > 0)
				{
					sortedOpenList.Clear();
				}
				Node[] array = openList;
				array[RuntimeServices.NormalizeArrayIndex(array, startNode.ID)] = startNode;
				BHInsertNode(new NodeSearch(startNode.ID, startNode.F));
				bool flag2 = false;
				while (!flag2)
				{
					if (sortedOpenList.Count == 0)
					{
						listMethod(endPos, new System.Collections.Generic.List<Vector3>());
						return;
					}
					int index = BHGetLowest();
					Node[] array2 = openList;
					currentNode = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					Node[] array3 = closedList;
					array3[RuntimeServices.NormalizeArrayIndex(array3, currentNode.ID)] = currentNode;
					Node[] array4 = openList;
					array4[RuntimeServices.NormalizeArrayIndex(array4, index)] = null;
					if (currentNode.ID == endNode.ID)
					{
						flag2 = true;
					}
					else if (MoveDiagonal)
					{
						NeighbourCheck();
					}
					else
					{
						NonDiagonalNeighborCheck();
					}
				}
				while (currentNode.parent != null)
				{
					list.Add(new Vector3(currentNode.xCoord, currentNode.yCoord, currentNode.zCoord));
					currentNode = currentNode.parent;
				}
				list.Reverse();
				if (flag)
				{
				}
				if (list.Count > 2 && flag)
				{
					if (!(Vector3.Distance(list[list.Count - 1], list[list.Count - 3]) >= Vector3.Distance(list[list.Count - 3], list[list.Count - 2])))
					{
						list.RemoveAt(list.Count - 2);
					}
					if (!(Vector3.Distance(list[1], startPos) >= Vector3.Distance(list[0], list[1])))
					{
						list.RemoveAt(0);
					}
				}
				maxSearchRounds = 0;
				listMethod(endPos, list);
			}
			else
			{
				maxSearchRounds = 0;
				listMethod(endPos, new System.Collections.Generic.List<Vector3>());
			}
		}
	}

	private void SetStartAndEndNode(ref Vector3 start, ref Vector3 end)
	{
		startNode = FindClosestNode(start);
		endNode = FindClosestNode(end);
		if (endNode == null || !endNode.walkable)
		{
			endNode = FindClosestNode(end, 2);
			if (endNode != null)
			{
				end.x = endNode.xCoord;
				end.y = endNode.yCoord;
				end.z = endNode.zCoord;
			}
		}
	}

	public bool IsTheClosestNodeWalkable(Vector3 pos)
	{
		int result;
		if (Map == null)
		{
			result = 0;
		}
		else
		{
			int num = ((MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - MapStartPosition.x) / Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(MapStartPosition.x)) / Tilesize));
			int num2 = ((MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - MapStartPosition.y) / Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(MapStartPosition.y)) / Tilesize));
			if (num < 0 || num2 < 0 || num > Map.GetLength(0) || num2 > Map.GetLength(1))
			{
				result = 0;
			}
			else
			{
				Node node = Map[num, num2];
				result = (node.walkable ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	private Node FindClosestNode(Vector3 pos)
	{
		return FindClosestNode(pos, 1);
	}

	private Node FindClosestNode(Vector3 pos, int S)
	{
		object result;
		if (Map == null)
		{
			result = null;
		}
		else
		{
			int num = ((MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - MapStartPosition.x) / Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(MapStartPosition.x)) / Tilesize));
			int num2 = ((MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - MapStartPosition.y) / Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(MapStartPosition.y)) / Tilesize));
			if (num < 0 || num2 < 0 || num > Map.GetLength(0) || num2 > Map.GetLength(1))
			{
				result = null;
			}
			else
			{
				Node node = Map[num, num2];
				if (node.walkable)
				{
					result = new Node(num, num2, node.yCoord, node.ID, node.xCoord, node.zCoord, node.walkable, null);
				}
				else
				{
					int num3;
					int num4;
					int num5;
					checked
					{
						num3 = num2 - S;
						num4 = num2 + S + 1;
						num5 = 1;
						if (num4 < num3)
						{
							num5 = -1;
						}
					}
					while (true)
					{
						int num6;
						int num10;
						if (num3 != num4)
						{
							num6 = num3;
							num3 += num5;
							int num7;
							int num8;
							int num9;
							checked
							{
								num7 = num - S;
								num8 = num + S + 1;
								num9 = 1;
								if (num8 < num7)
								{
									num9 = -1;
								}
							}
							while (num7 != num8)
							{
								num10 = num7;
								num7 += num9;
								if (num6 <= -1 || num6 >= Map.GetLength(1) || num10 <= -1 || num10 >= Map.GetLength(0) || !Map[num10, num6].walkable)
								{
									continue;
								}
								goto IL_01fb;
							}
							continue;
						}
						result = null;
						break;
						IL_01fb:
						result = new Node(num10, num6, Map[num10, num6].yCoord, Map[num10, num6].ID, Map[num10, num6].xCoord, Map[num10, num6].zCoord, Map[num10, num6].walkable, null);
						break;
					}
				}
			}
		}
		return (Node)result;
	}

	private void FindEndNode(Vector3 pos)
	{
		if (Map == null)
		{
			endNode = null;
			return;
		}
		int num = ((MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - MapStartPosition.x) / Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(MapStartPosition.x)) / Tilesize));
		int num2 = ((MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - MapStartPosition.y) / Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(MapStartPosition.y)) / Tilesize));
		Node a = Map[num, num2];
		System.Collections.Generic.List<Node> list = new System.Collections.Generic.List<Node>();
		int num3 = 1;
		checked
		{
			while (list.Count < 1 && (float)maxSearchRounds < 10f / Tilesize)
			{
				list = EndNodeNeighbourCheck(num, num2, num3);
				num3++;
				maxSearchRounds++;
			}
			if (list.Count <= 0)
			{
				return;
			}
			int num4 = 99999999;
			Node node = null;
			foreach (Node item in list)
			{
				int heuristics = GetHeuristics(a, item);
				if (heuristics < num4)
				{
					num4 = heuristics;
					node = item;
				}
			}
			endNode = new Node(node.x, node.y, node.yCoord, node.ID, node.xCoord, node.zCoord, node.walkable, null);
		}
	}

	private System.Collections.Generic.List<Node> EndNodeNeighbourCheck(int x, int z, int r)
	{
		System.Collections.Generic.List<Node> list = new System.Collections.Generic.List<Node>();
		checked
		{
			int num = z - r;
			int num2 = z + r + 1;
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int num4 = num;
				num = unchecked(num + num3);
				int num5 = x - r;
				int num6 = x + r + 1;
				int num7 = 1;
				if (num6 < num5)
				{
					num7 = -1;
				}
				while (num5 != num6)
				{
					int num8 = num5;
					num5 = unchecked(num5 + num7);
					if (num4 > -1 && num8 > -1 && num4 < Map.GetLength(0) && num8 < Map.GetLength(1) && (num4 < z - r + 1 || num4 > z + r - 1 || num8 < x - r + 1 || num8 > x + r - 1) && Map[num8, num4].walkable)
					{
						list.Add(Map[num8, num4]);
					}
				}
			}
			return list;
		}
	}

	private void NeighbourCheck()
	{
		int x = currentNode.x;
		int y = currentNode.y;
		checked
		{
			int num = y - 1;
			int num2 = y + 2;
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int num4 = num;
				num = unchecked(num + num3);
				int num5 = x - 1;
				int num6 = x + 2;
				int num7 = 1;
				if (num6 < num5)
				{
					num7 = -1;
				}
				while (num5 != num6)
				{
					int num8 = num5;
					num5 = unchecked(num5 + num7);
					if (num4 <= -1 || num4 >= Map.GetLength(1) || num8 <= -1 || num8 >= Map.GetLength(0) || (num4 == y && num8 == x) || !Map[num8, num4].walkable || OnClosedList(Map[num8, num4].ID) || ((Map[num8, num4].yCoord - currentNode.yCoord >= ClimbLimit || !(Map[num8, num4].yCoord - currentNode.yCoord >= 0f)) && (currentNode.yCoord - Map[num8, num4].yCoord >= MaxFalldownHeight || currentNode.yCoord < Map[num8, num4].yCoord)))
					{
						continue;
					}
					if (!OnOpenList(Map[num8, num4].ID))
					{
						Node node = new Node(Map[num8, num4].x, Map[num8, num4].y, Map[num8, num4].yCoord, Map[num8, num4].ID, Map[num8, num4].xCoord, Map[num8, num4].zCoord, Map[num8, num4].walkable, currentNode);
						node.H = GetHeuristics(Map[num8, num4].x, Map[num8, num4].y);
						node.G = GetMovementCost(x, y, num8, num4) + currentNode.G;
						node.F = node.H + node.G;
						Node[] array = openList;
						array[RuntimeServices.NormalizeArrayIndex(array, node.ID)] = node;
						BHInsertNode(new NodeSearch(node.ID, node.F));
						continue;
					}
					Node nodeFromOpenList = GetNodeFromOpenList(Map[num8, num4].ID);
					int num9 = currentNode.G + GetMovementCost(x, y, num8, num4);
					Node[] array2 = openList;
					if (num9 < array2[RuntimeServices.NormalizeArrayIndex(array2, Map[num8, num4].ID)].G)
					{
						nodeFromOpenList.parent = currentNode;
						nodeFromOpenList.G = currentNode.G + GetMovementCost(x, y, num8, num4);
						nodeFromOpenList.F = nodeFromOpenList.G + nodeFromOpenList.H;
						BHSortNode(nodeFromOpenList.ID, nodeFromOpenList.F);
					}
				}
			}
		}
	}

	private void NonDiagonalNeighborCheck()
	{
		int x = currentNode.x;
		int y = currentNode.y;
		checked
		{
			int num = y - 1;
			int num2 = y + 2;
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int num4 = num;
				num = unchecked(num + num3);
				int num5 = x - 1;
				int num6 = x + 2;
				int num7 = 1;
				if (num6 < num5)
				{
					num7 = -1;
				}
				while (num5 != num6)
				{
					int num8 = num5;
					num5 = unchecked(num5 + num7);
					if (num4 <= -1 || num4 >= Map.GetLength(1) || num8 <= -1 || num8 >= Map.GetLength(0) || (num4 == y && num8 == x) || GetMovementCost(x, y, num8, num4) >= 14 || !Map[num8, num4].walkable || OnClosedList(Map[num8, num4].ID) || ((Map[num8, num4].yCoord - currentNode.yCoord >= ClimbLimit || !(Map[num8, num4].yCoord - currentNode.yCoord >= 0f)) && (currentNode.yCoord - Map[num8, num4].yCoord >= MaxFalldownHeight || currentNode.yCoord < Map[num8, num4].yCoord)))
					{
						continue;
					}
					if (!OnOpenList(Map[num8, num4].ID))
					{
						Node node = new Node(Map[num8, num4].x, Map[num8, num4].y, Map[num8, num4].yCoord, Map[num8, num4].ID, Map[num8, num4].xCoord, Map[num8, num4].zCoord, Map[num8, num4].walkable, currentNode);
						node.H = GetHeuristics(Map[num8, num4].x, Map[num8, num4].y);
						node.G = GetMovementCost(x, y, num8, num4) + currentNode.G;
						node.F = node.H + node.G;
						Node[] array = openList;
						array[RuntimeServices.NormalizeArrayIndex(array, node.ID)] = node;
						BHInsertNode(new NodeSearch(node.ID, node.F));
						continue;
					}
					Node nodeFromOpenList = GetNodeFromOpenList(Map[num8, num4].ID);
					int num9 = currentNode.G + GetMovementCost(x, y, num8, num4);
					Node[] array2 = openList;
					if (num9 < array2[RuntimeServices.NormalizeArrayIndex(array2, Map[num8, num4].ID)].G)
					{
						nodeFromOpenList.parent = currentNode;
						nodeFromOpenList.G = currentNode.G + GetMovementCost(x, y, num8, num4);
						nodeFromOpenList.F = nodeFromOpenList.G + nodeFromOpenList.H;
						BHSortNode(nodeFromOpenList.ID, nodeFromOpenList.F);
					}
				}
			}
		}
	}

	private void ChangeFValue(int id, int F)
	{
		foreach (NodeSearch sortedOpen in sortedOpenList)
		{
			if (sortedOpen.ID == id)
			{
				sortedOpen.F = F;
			}
		}
	}

	private bool OnOpenList(int id)
	{
		Node[] array = openList;
		return array[RuntimeServices.NormalizeArrayIndex(array, id)] != null;
	}

	private bool OnClosedList(int id)
	{
		Node[] array = closedList;
		return array[RuntimeServices.NormalizeArrayIndex(array, id)] != null;
	}

	private int GetHeuristics(int x, int y)
	{
		int num = ((HeuristicAggression >= 0) ? HeuristicAggression : 0);
		return checked((int)((float)Mathf.Abs(x - endNode.x) * (10f + 10f * (float)num) + (float)Mathf.Abs(y - endNode.y) * (10f + 10f * (float)num)));
	}

	private int GetHeuristics(Node a, Node b)
	{
		int num = ((HeuristicAggression >= 0) ? HeuristicAggression : 0);
		return checked((int)((float)Mathf.Abs(a.x - b.x) * (10f + 10f * (float)num) + (float)Mathf.Abs(a.y - b.y) * (10f + 10f * (float)num)));
	}

	private int GetMovementCost(int x, int y, int j, int i)
	{
		return (x == j || y == i) ? 10 : 14;
	}

	private Node GetNodeFromOpenList(int id)
	{
		Node[] array = openList;
		object result;
		if (array[RuntimeServices.NormalizeArrayIndex(array, id)] != null)
		{
			Node[] array2 = openList;
			result = array2[RuntimeServices.NormalizeArrayIndex(array2, id)];
		}
		else
		{
			result = null;
		}
		return (Node)result;
	}

	private void BHInsertNode(NodeSearch ns)
	{
		if (sortedOpenList.Count == 0)
		{
			sortedOpenList.Add(ns);
			Node[] array = openList;
			array[RuntimeServices.NormalizeArrayIndex(array, ns.ID)].sortedIndex = 0;
			return;
		}
		sortedOpenList.Add(ns);
		bool flag = true;
		int num = checked(sortedOpenList.Count - 1);
		Node[] array2 = openList;
		array2[RuntimeServices.NormalizeArrayIndex(array2, ns.ID)].sortedIndex = num;
		while (flag)
		{
			int num2 = Mathf.FloorToInt(checked(num - 1) / 2);
			if (num == 0)
			{
				flag = false;
				Node[] array3 = openList;
				array3[RuntimeServices.NormalizeArrayIndex(array3, sortedOpenList[num].ID)].sortedIndex = 0;
			}
			else if (sortedOpenList[num].F < sortedOpenList[num2].F)
			{
				NodeSearch value = sortedOpenList[num2];
				sortedOpenList[num2] = sortedOpenList[num];
				sortedOpenList[num] = value;
				Node[] array4 = openList;
				array4[RuntimeServices.NormalizeArrayIndex(array4, sortedOpenList[num].ID)].sortedIndex = num;
				Node[] array5 = openList;
				array5[RuntimeServices.NormalizeArrayIndex(array5, sortedOpenList[num2].ID)].sortedIndex = num2;
				num = num2;
			}
			else
			{
				flag = false;
			}
		}
	}

	private void BHSortNode(int id, int F)
	{
		bool flag = true;
		Node[] array = openList;
		int num = array[RuntimeServices.NormalizeArrayIndex(array, id)].sortedIndex;
		sortedOpenList[num].F = F;
		while (flag)
		{
			int num2 = Mathf.FloorToInt(checked(num - 1) / 2);
			if (num == 0)
			{
				flag = false;
				Node[] array2 = openList;
				array2[RuntimeServices.NormalizeArrayIndex(array2, sortedOpenList[num].ID)].sortedIndex = 0;
			}
			else if (sortedOpenList[num].F < sortedOpenList[num2].F)
			{
				NodeSearch value = sortedOpenList[num2];
				sortedOpenList[num2] = sortedOpenList[num];
				sortedOpenList[num] = value;
				Node[] array3 = openList;
				array3[RuntimeServices.NormalizeArrayIndex(array3, sortedOpenList[num].ID)].sortedIndex = num;
				Node[] array4 = openList;
				array4[RuntimeServices.NormalizeArrayIndex(array4, sortedOpenList[num2].ID)].sortedIndex = num2;
				num = num2;
			}
			else
			{
				flag = false;
			}
		}
	}

	private int BHGetLowest()
	{
		checked
		{
			int result;
			if (sortedOpenList.Count == 1)
			{
				int iD = sortedOpenList[0].ID;
				sortedOpenList.RemoveAt(0);
				result = iD;
			}
			else if (sortedOpenList.Count > 1)
			{
				int iD = sortedOpenList[0].ID;
				sortedOpenList[0] = sortedOpenList[sortedOpenList.Count - 1];
				sortedOpenList.RemoveAt(sortedOpenList.Count - 1);
				Node[] array = openList;
				array[RuntimeServices.NormalizeArrayIndex(array, sortedOpenList[0].ID)].sortedIndex = 0;
				int num = 0;
				bool flag = true;
				while (flag)
				{
					int num2 = num * 2 + 1;
					int num3 = num * 2 + 2;
					int num4 = -1;
					if (num2 < sortedOpenList.Count)
					{
						num4 = num2;
						if (num3 < sortedOpenList.Count && sortedOpenList[num3].F < sortedOpenList[num2].F)
						{
							num4 = num3;
						}
						if (sortedOpenList[num].F > sortedOpenList[num4].F)
						{
							NodeSearch value = sortedOpenList[num];
							sortedOpenList[num] = sortedOpenList[num4];
							sortedOpenList[num4] = value;
							Node[] array2 = openList;
							array2[RuntimeServices.NormalizeArrayIndex(array2, sortedOpenList[num].ID)].sortedIndex = num;
							Node[] array3 = openList;
							array3[RuntimeServices.NormalizeArrayIndex(array3, sortedOpenList[num4].ID)].sortedIndex = num4;
							num = num4;
							continue;
						}
						break;
					}
					break;
				}
				result = iD;
			}
			else
			{
				result = -1;
			}
			return result;
		}
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void DrawMapLines()
	{
		if (!DrawMapInEditor || Map == null)
		{
			return;
		}
		int num = 0;
		int length = Map.GetLength(1);
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			int num3 = 0;
			int length2 = Map.GetLength(0);
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < length2)
			{
				int num4 = num3;
				num3++;
				if (!Map[num4, num2].walkable)
				{
					continue;
				}
				int num5;
				int num6;
				int num7;
				checked
				{
					num5 = num2 - 1;
					num6 = num2 + 2;
					num7 = 1;
					if (num6 < num5)
					{
						num7 = -1;
					}
				}
				while (num5 != num6)
				{
					int num8 = num5;
					num5 += num7;
					int num9;
					int num10;
					int num11;
					checked
					{
						num9 = num4 - 1;
						num10 = num4 + 2;
						num11 = 1;
						if (num10 < num9)
						{
							num11 = -1;
						}
					}
					while (num9 != num10)
					{
						int num12 = num9;
						num9 += num11;
						if (num8 >= 0 && num12 >= 0 && num8 < Map.GetLength(1) && num12 < Map.GetLength(0) && Map[num12, num8].walkable && (Map[num4, num2].yCoord <= Map[num12, num8].yCoord || Mathf.Abs(Map[num4, num2].yCoord - Map[num12, num8].yCoord) <= MaxFalldownHeight) && (Map[num4, num2].yCoord >= Map[num12, num8].yCoord || Mathf.Abs(Map[num12, num8].yCoord - Map[num4, num2].yCoord) <= ClimbLimit))
						{
							Vector3 start = new Vector3(Map[num4, num2].xCoord, Map[num4, num2].yCoord + 0.1f, Map[num4, num2].zCoord);
							Vector3 end = new Vector3(Map[num12, num8].xCoord, Map[num12, num8].yCoord + 0.1f, Map[num12, num8].zCoord);
							UnityEngine.Debug.DrawLine(start, end, Color.green);
						}
					}
				}
			}
		}
	}

	public void DrawRect(Vector3 vPos)
	{
		Vector3 vector = vPos;
		vector.x -= fModifyTileSize;
		vector.z -= fModifyTileSize;
		Vector3 vector2 = vector;
		vector2.z += Instance.Tilesize;
		Vector3 vector3 = vPos;
		vector3.x += fModifyTileSize;
		vector3.z += fModifyTileSize;
		Vector3 vector4 = vector3;
		vector4.z -= Instance.Tilesize;
		UnityEngine.Debug.DrawLine(vector, vector4);
		UnityEngine.Debug.DrawLine(vector2, vector3);
		UnityEngine.Debug.DrawLine(vector, vector2);
		UnityEngine.Debug.DrawLine(vector4, vector3);
	}

	public Vector3 CheckPosition()
	{
		Vector3 zero = Vector3.zero;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		Vector3 result;
		if (!(currentPlayer == null))
		{
			zero = currentPlayer.transform.position;
			float num = zero.x % Instance.Tilesize - fModifyTileSize;
			float num2 = zero.z % Instance.Tilesize + fModifyTileSize;
			zero.Set(zero.x - num, zero.y + 0.4f, zero.z - num2);
			DrawRect(zero);
			result = zero;
		}
		else
		{
			Vector3 vector = default(Vector3);
			result = vector;
		}
		return result;
	}

	public void DynamicNodeAdd(System.Collections.Generic.List<Vector3> checkList, __Pathfinder_DynamicNodeAdd_0024callable60_0024992_76__ listMethod)
	{
		if (Map != null)
		{
			listMethod(DynamicNodeAddition(checkList));
		}
	}

	public void DynamicNodeRemove(System.Collections.Generic.List<Vector2> ids)
	{
		foreach (Vector2 id in ids)
		{
			checked(Map[(int)id.x, (int)id.y]).walkable = false;
		}
	}

	public void DynamicRaycastUpdate(Bounds b)
	{
		Vector3 pos = new Vector3(b.min.x, 0f, b.min.z);
		Node node = FindClosestNode(pos);
		if (node == null)
		{
			return;
		}
		checked
		{
			int num = Mathf.CeilToInt(Mathf.Abs((b.max.x - b.min.x) / Tilesize)) + 2;
			int num2 = Mathf.CeilToInt(Mathf.Abs((b.max.z - b.min.z) / Tilesize)) + 2;
			int num3 = node.x - 2;
			int num4 = node.x + num;
			int num5 = 1;
			if (num4 < num3)
			{
				num5 = -1;
			}
			while (num3 != num4)
			{
				int num6 = num3;
				num3 = unchecked(num3 + num5);
				int num7 = node.y - 2;
				int num8 = node.y + num2;
				int num9 = 1;
				if (num8 < num7)
				{
					num9 = -1;
				}
				while (num7 != num8)
				{
					int num10 = num7;
					num7 = unchecked(num7 + num9);
					if (num6 < 0 || num10 < 0 || num6 >= Map.GetLength(0) || num10 >= Map.GetLength(1))
					{
						continue;
					}
					float distance = Mathf.Abs(HighestPoint) + Mathf.Abs(LowestPoint);
					RaycastHit[] array = null;
					array = ((!CheckFullTileSize) ? Physics.SphereCastAll(new Vector3(Map[num6, num10].xCoord, HighestPoint, Map[num6, num10].zCoord), Tilesize / 16f, Vector3.down, distance) : Physics.SphereCastAll(new Vector3(Map[num6, num10].xCoord, HighestPoint, Map[num6, num10].zCoord), Tilesize / 2f, Vector3.down, distance));
					float num11 = float.NegativeInfinity;
					int i = 0;
					RaycastHit[] array2 = array;
					for (int length = array2.Length; i < length; i++)
					{
						if (DisallowedTags.Contains(array2[i].transform.tag))
						{
							if (!(array2[i].point.y <= num11))
							{
								Map[num6, num10].walkable = false;
								Map[num6, num10].yCoord = array2[i].point.y;
								num11 = array2[i].point.y;
							}
						}
						else if (!IgnoreTags.Contains(array2[i].transform.tag) && !(array2[i].point.y <= num11))
						{
							Map[num6, num10].walkable = true;
							Map[num6, num10].yCoord = array2[i].point.y;
							num11 = array2[i].point.y;
						}
					}
				}
			}
		}
	}

	private System.Collections.Generic.List<Vector2> DynamicNodeAddition(System.Collections.Generic.List<Vector3> vList)
	{
		System.Collections.Generic.List<Vector2> list = new System.Collections.Generic.List<Vector2>();
		foreach (Vector3 v in vList)
		{
			int num = ((MapStartPosition.x >= 0f) ? Mathf.FloorToInt((v.x - MapStartPosition.x) / Tilesize) : Mathf.FloorToInt((v.x + Mathf.Abs(MapStartPosition.x)) / Tilesize));
			int num2 = ((MapStartPosition.y >= 0f) ? Mathf.FloorToInt((v.z - MapStartPosition.y) / Tilesize) : Mathf.FloorToInt((v.z + Mathf.Abs(MapStartPosition.y)) / Tilesize));
			if (num >= 0 && num < Map.GetLength(0) && num2 >= 0 && num2 < Map.GetLength(1))
			{
				Map[num, num2].walkable = true;
				list.Add(new Vector2(num, num2));
			}
		}
		return list;
	}

	private int GetIndex(float worldPosX, float worldPosZ)
	{
		int num5;
		int num7;
		int num8;
		checked
		{
			int num = (int)MapStartPosition.x;
			int num2 = (int)MapStartPosition.y;
			int num3 = (int)MapEndPosition.x;
			int num4 = (int)MapEndPosition.y;
			num5 = (int)((float)(num3 - num) / Tilesize);
			int num6 = (int)((float)(num4 - num2) / Tilesize);
			num7 = 0;
			num8 = num6;
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		int result;
		while (true)
		{
			int num9;
			int num12;
			if (num7 < num8)
			{
				num9 = num7;
				num7++;
				int num10 = 0;
				int num11 = num5;
				if (num11 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num10 < num11)
				{
					num12 = num10;
					num10++;
					if (Map[num12, num9].xCoord != worldPosX || Map[num12, num9].zCoord != worldPosZ)
					{
						continue;
					}
					goto IL_00d6;
				}
				continue;
			}
			result = -1;
			break;
			IL_00d6:
			result = Map[num12, num9].ID;
			break;
		}
		return result;
	}

	public void TestPathfindStart(string portalName)
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer == null || currentPlayer.CharPathFinder == null)
		{
			return;
		}
		Vector3 vDestPos = Vector3.zero;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Portal");
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)].name == portalName)
			{
				vDestPos = array[RuntimeServices.NormalizeArrayIndex(array, index)].transform.position;
				break;
			}
		}
		currentPlayer.CharPathFinder.Goto(vDestPos);
	}

	public void TestPathfindEnd()
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (!(currentPlayer == null) && !(currentPlayer.CharPathFinder == null))
		{
			currentPlayer.CharPathFinder.Stop();
		}
	}

	public Node[,] DebugGetMap()
	{
		return Map;
	}

	public TDManager DebugGetTDManager()
	{
		return tdManager;
	}
}
