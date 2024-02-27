using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class MerlinMotionPack : MonoBehaviour
{
	[Serializable]
	public class CommonEntry
	{
		public string enumName;

		public string animName;

		public CommonEntry(string _enumName, string _animName)
		{
			enumName = _enumName;
			animName = _animName;
		}
	}

	[Serializable]
	public class Entry
	{
		public string name;

		public string assetPath;

		public AnimationClip clip;

		public PlayMode playMode;

		public D540OpeCode[] motDefMethodArgs;

		public string[] keywords;

		[HideInInspector]
		[SerializeField]
		private byte[] byteD540;

		private D540OpeCode _d540OpeCode;

		private Executer executer;

		private int typeID;

		private bool _0024initialized__MerlinMotionPack_Entry_0024;

		public D540OpeCode code
		{
			get
			{
				return _d540OpeCode;
			}
			set
			{
				if (!Application.isEditor)
				{
					throw new AssertionFailedException("assigning to code field from not editor code");
				}
				_d540OpeCode = value;
			}
		}

		public bool HasClip => clip != null;

		public bool HasD540 => _d540OpeCode != null;

		public bool IsValid
		{
			get
			{
				bool num = !string.IsNullOrEmpty(name);
				if (num)
				{
					num = clip != null;
				}
				return num;
			}
		}

		public bool IsValidName => !string.IsNullOrEmpty(name);

		public Executer Executer
		{
			get
			{
				return executer;
			}
			set
			{
				executer = value;
			}
		}

		public int TypeID
		{
			get
			{
				return typeID;
			}
			set
			{
				typeID = value;
			}
		}

		public Entry(Entry e)
		{
			if (!_0024initialized__MerlinMotionPack_Entry_0024)
			{
				playMode = PlayMode.UseWrapMode;
				typeID = -1;
				_0024initialized__MerlinMotionPack_Entry_0024 = true;
			}
			name = e.name;
			clip = e.clip;
			typeID = e.typeID;
			byteD540 = e.byteD540;
			if (byteD540 == null)
			{
				throw new AssertionFailedException(new StringBuilder("d540 not assigned to ").Append(name).ToString());
			}
			buildD540();
			playMode = e.playMode;
			if (e.motDefMethodArgs != null)
			{
				if (e.motDefMethodArgs.Length > 0)
				{
				}
				motDefMethodArgs = Gen_array_macrosModule.GenArray<D540OpeCode, D540OpeCode>(e.motDefMethodArgs, (__MerlinMotionPack_0024callable191_0024116_19__)((D540OpeCode _0024genarray_0024147) => _0024genarray_0024147.clone()), (__MerlinMotionPack_0024callable192_0024116_19__)((D540OpeCode _0024genarray_0024147) => _0024genarray_0024147 != null));
			}
			keywords = e.keywords;
		}

		public Entry(string _name, string _path, AnimationClip _clip, D540OpeCode _code)
		{
			if (!_0024initialized__MerlinMotionPack_Entry_0024)
			{
				playMode = PlayMode.UseWrapMode;
				typeID = -1;
				_0024initialized__MerlinMotionPack_Entry_0024 = true;
			}
			name = _name;
			assetPath = _path;
			clip = _clip;
		}

		public void setByteD540(byte[] d)
		{
			byteD540 = d;
		}

		public byte[] getByteD540()
		{
			return byteD540;
		}

		public bool containsKeyword(string kw)
		{
			int result;
			if (keywords == null)
			{
				result = 0;
			}
			else
			{
				kw = kw.ToLower();
				int num = 0;
				string[] array = keywords;
				int length = array.Length;
				while (true)
				{
					if (num < length)
					{
						if (array[num] == kw)
						{
							result = 1;
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = 0;
					break;
				}
			}
			return (byte)result != 0;
		}

		public bool containsKeywords(string[] kws)
		{
			int result;
			if (kws == null || kws.Length <= 0)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int length = kws.Length;
				while (true)
				{
					if (num < length)
					{
						if (!containsKeyword(kws[num]))
						{
							result = 0;
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = 1;
					break;
				}
			}
			return (byte)result != 0;
		}

		public void applyAllD540(D540OpeCodeVisitor visitor)
		{
			if (visitor == null)
			{
				return;
			}
			if (code != null)
			{
				code.apply(visitor);
			}
			if (motDefMethodArgs == null)
			{
				return;
			}
			int i = 0;
			D540OpeCode[] array = motDefMethodArgs;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] != null)
				{
					array[i].apply(visitor);
				}
			}
		}

		public override string ToString()
		{
			return new StringBuilder("Entry:").Append(name).Append(" clip=").Append(clip)
				.Append(" playMode=")
				.Append(playMode)
				.Append(" HasD540=")
				.Append(HasD540)
				.ToString();
		}

		private void buildD540()
		{
			if (_d540OpeCode == null && !(byteD540 == null))
			{
				_d540OpeCode = D540BinaryToCodeTree.BuildTree(byteD540);
			}
		}

		public void disposeD540()
		{
			D540OpeCodePool instance = D540OpeCodePool.Instance;
			if (_d540OpeCode != null)
			{
				instance.dispose(_d540OpeCode);
				_d540OpeCode = null;
			}
		}

		internal D540OpeCode _0024constructor_0024closure_00242906(D540OpeCode _0024genarray_0024147)
		{
			return _0024genarray_0024147.clone();
		}

		internal bool _0024constructor_0024closure_00242907(D540OpeCode _0024genarray_0024147)
		{
			return _0024genarray_0024147 != null;
		}
	}

	[Serializable]
	public class EffectEntry
	{
		public string name;

		public string path;

		public GameObject obj;

		public EffectEntry(string _name, string _path, GameObject _obj)
		{
			name = _name;
			path = _path;
			obj = _obj;
		}
	}

	[Serializable]
	public class MiscInfo
	{
		public string name;

		public string value;

		public MiscInfo(string _name, string _value)
		{
			name = _name;
			value = _value;
		}
	}

	[Serializable]
	public enum PlayMode
	{
		UseWrapMode,
		Clamp,
		Loop
	}

	[Serializable]
	public class Executer
	{
		public string name;

		private D540Interpreter interpreter;

		private MerlinMotionPack parent;

		private Dictionary<string, Boo.Lang.List<Entry>> entryDict;

		private object targetObject;

		private D540RuntimeAssetResolver seLoader;

		public Entry[] AllEntries
		{
			get
			{
				Boo.Lang.List<Entry> list = new Boo.Lang.List<Entry>();
				foreach (Boo.Lang.List<Entry> value in entryDict.Values)
				{
					IEnumerator<Entry> enumerator2 = value.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							Entry current2 = enumerator2.Current;
							list.Add(current2);
						}
					}
					finally
					{
						enumerator2.Dispose();
					}
				}
				return (Entry[])Builtins.array(typeof(Entry), list);
			}
		}

		public MerlinMotionPack Parent => parent;

		public Dictionary<string, Boo.Lang.List<Entry>> EntryDict => entryDict;

		public D540RuntimeAssetResolver SeLoader => seLoader;

		public Executer(GameObject go, MerlinMotionPack _parent)
		{
			if (!(go != null) || !(_parent != null))
			{
				throw new AssertionFailedException("(go != null) and (_parent != null)");
			}
			name = go.name;
			parent = _parent;
			seLoader = new D540RuntimeAssetResolver();
			D540RuntimeResolver rslvr = initializeInterpreter(go);
			initializeEntryDict(parent.entries, rslvr);
			if (parent.TargetType != null)
			{
				targetObject = go.GetComponent(parent.TargetType);
			}
		}

		private D540RuntimeResolver initializeInterpreter(GameObject go)
		{
			D540RuntimeResolver d540RuntimeResolver = new D540RuntimeResolver(go);
			interpreter = new D540Interpreter(d540RuntimeResolver.Receivers);
			interpreter.PrefabLoader = (string n) => parent.getEffect(n);
			return d540RuntimeResolver;
		}

		public void updateClipOfAllEntries(GameObject go, string mname, AnimationClip clip)
		{
			if (string.IsNullOrEmpty(mname) || clip == null || entryDict == null)
			{
				return;
			}
			D540RuntimeResolver rslvr = new D540RuntimeResolver(go);
			int i = 0;
			Entry[] entries = parent.entries;
			for (int length = entries.Length; i < length; i = checked(i + 1))
			{
				if (entries[i] != null && entries[i].name == mname)
				{
					initializeAnEntry(entries[i], rslvr);
				}
			}
		}

		private void initializeEntryDict(Entry[] entries, D540RuntimeResolver rslvr)
		{
			if (entries == null || rslvr == null)
			{
				throw new AssertionFailedException("(entries != null) and (rslvr != null)");
			}
			entryDict = new Dictionary<string, Boo.Lang.List<Entry>>();
			int i = 0;
			for (int length = entries.Length; i < length; i = checked(i + 1))
			{
				if (entries[i] != null && entries[i].IsValidName && entries[i].HasClip)
				{
					initializeAnEntry(entries[i], rslvr);
				}
			}
		}

		private void initializeAnEntry(Entry e, D540RuntimeResolver rslvr)
		{
			if (e == null || !e.IsValidName)
			{
				return;
			}
			Entry entry = new Entry(e);
			entry.Executer = this;
			if (entry.code != null)
			{
				entry.code.apply(rslvr);
			}
			if (entry.motDefMethodArgs != null)
			{
				int i = 0;
				D540OpeCode[] motDefMethodArgs = entry.motDefMethodArgs;
				for (int length = motDefMethodArgs.Length; i < length; i = checked(i + 1))
				{
					if (motDefMethodArgs[i] != null)
					{
						motDefMethodArgs[i].apply(rslvr);
					}
				}
			}
			addEntry(entry);
		}

		private void addEntry(Entry e)
		{
			if (e != null)
			{
				if (!entryDict.ContainsKey(e.name))
				{
					entryDict[e.name] = new Boo.Lang.List<Entry>();
				}
				entryDict[e.name].Add(e);
			}
		}

		public void dispose()
		{
			foreach (Boo.Lang.List<Entry> value in entryDict.Values)
			{
				IEnumerator<Entry> enumerator2 = value.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						Entry current2 = enumerator2.Current;
						current2.disposeD540();
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
			}
			entryDict.Clear();
			parent = null;
			interpreter = null;
			seLoader.unloadAssets();
		}

		public Entry findEntry(string n)
		{
			Boo.Lang.List<Entry> list = findEntries(n);
			return (list == null || ((ICollection)list).Count <= 0) ? null : list[0];
		}

		public Entry findEntry(int typeID)
		{
			string clipNameByType = parent.getClipNameByType(typeID);
			Boo.Lang.List<Entry> entries = findEntries(clipNameByType);
			string kw = ((EnumCharacterActionTypes)typeID).ToString();
			return _GetEntryWithKeyword(entries, kw);
		}

		public bool hasEntry(int typeID)
		{
			return !string.IsNullOrEmpty(parent.getClipNameByType(typeID));
		}

		public Entry findEntryByKeywords(int typeID, string[] kws)
		{
			Boo.Lang.List<Entry> entries = findEntriesByKeywords(typeID, kws);
			string kw = ((EnumCharacterActionTypes)typeID).ToString();
			return _GetEntryWithKeyword(entries, kw);
		}

		private static Entry _GetEntryWithKeyword(Boo.Lang.List<Entry> entries, string kw)
		{
			object result;
			Entry entry;
			if (entries == null || ((ICollection)entries).Count <= 0)
			{
				result = null;
			}
			else
			{
				IEnumerator<Entry> enumerator = entries.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Entry current = enumerator.Current;
						if (!current.containsKeyword(kw))
						{
							continue;
						}
						entry = current;
						goto IL_005e;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				result = entries[0];
			}
			goto IL_005f;
			IL_005f:
			return (Entry)result;
			IL_005e:
			result = entry;
			goto IL_005f;
		}

		public Boo.Lang.List<Entry> findEntries(string n)
		{
			return (string.IsNullOrEmpty(n) || !entryDict.ContainsKey(n)) ? null : entryDict[n];
		}

		public Boo.Lang.List<Entry> findEntriesByKeywords(int typeID, string[] kws)
		{
			string clipNameByType = parent.getClipNameByType(typeID);
			return findEntriesByKeywords(clipNameByType, kws);
		}

		public Boo.Lang.List<Entry> findEntriesByKeywords(string n, string[] kws)
		{
			Boo.Lang.List<Entry> list = findEntries(n);
			Boo.Lang.List<Entry> list2 = new Boo.Lang.List<Entry>();
			Boo.Lang.List<Entry> result;
			if (list == null || ((ICollection)list).Count <= 0)
			{
				result = list2;
			}
			else
			{
				IEnumerator<Entry> enumerator = list.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Entry current = enumerator.Current;
						if (current.containsKeywords(kws))
						{
							list2.Add(current);
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				result = list2;
			}
			return result;
		}

		public MerlinMotionPackEffectLoader loadEffectsForLoadedMotions()
		{
			MerlinMotionPackEffectLoader merlinMotionPackEffectLoader = new MerlinMotionPackEffectLoader(parent, AllEntries);
			merlinMotionPackEffectLoader.load();
			return merlinMotionPackEffectLoader;
		}

		public void loadSoundEffectsForLoadedMotions(__D540RuntimeAssetResolver_loadAssets_0024callable1_002459_64__ loadPred)
		{
			seLoader.loadAssets(AllEntries, loadPred);
		}

		public void init()
		{
		}

		public int executeMotDefMethod(Entry entry)
		{
			int result;
			if (parent.MotDefMethodArgType == null)
			{
				result = -1;
			}
			else if (entry == null)
			{
				result = -2;
			}
			else if (RuntimeServices.EqualityOperator(entry.Executer, this))
			{
				MethodInfo motDefMethod = parent.MotDefMethod;
				FieldInfo[] motDefMethodArgFields = parent.MotDefMethodArgFields;
				Type motDefMethodArgType = parent.MotDefMethodArgType;
				D540OpeCode[] motDefMethodArgs = entry.motDefMethodArgs;
				if (motDefMethod == null || motDefMethodArgFields == null || motDefMethodArgs == null || motDefMethodArgType == null)
				{
					result = -3;
				}
				else if (targetObject == null)
				{
					result = -5;
				}
				else
				{
					object obj = Activator.CreateInstance(motDefMethodArgType);
					int num = Mathf.Min(motDefMethodArgFields.Length, motDefMethodArgs.Length);
					int num2 = 0;
					int num3 = num;
					if (num3 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num2 < num3)
					{
						int index = num2;
						num2++;
						D540OpeCode code = motDefMethodArgs[RuntimeServices.NormalizeArrayIndex(motDefMethodArgs, index)];
						interpreter.clearStack();
						interpreter.execute(code);
						if (!interpreter.IsStackEmpty)
						{
							object value = interpreter.pop();
							try
							{
								motDefMethodArgFields[RuntimeServices.NormalizeArrayIndex(motDefMethodArgFields, index)].SetValue(obj, value);
							}
							catch (Exception)
							{
							}
						}
					}
					motDefMethod.Invoke(targetObject, new object[1] { obj });
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public void execute(Entry entry)
		{
			if (entry != null && RuntimeServices.EqualityOperator(entry.Executer, this) && entry.code != null)
			{
				interpreter.execute(entry.code);
			}
		}

		public void stop()
		{
		}

		public void update()
		{
		}

		internal GameObject _0024initializeInterpreter_0024closure_00243819(string n)
		{
			return parent.getEffect(n);
		}
	}

	[Serializable]
	internal class _0024loadClip_0024locals_002414267
	{
		internal Entry[] _0024es;

		internal __MerlinMotionPack_loadClip_0024callable2_0024381_51__ _0024c;
	}

	[Serializable]
	internal class _0024loadClip_0024closure_00243821
	{
		internal _0024loadClip_0024locals_002414267 _0024_0024locals_002414585;

		public _0024loadClip_0024closure_00243821(_0024loadClip_0024locals_002414267 _0024_0024locals_002414585)
		{
			this._0024_0024locals_002414585 = _0024_0024locals_002414585;
		}

		public void Invoke(object req, UnityEngine.Object o)
		{
			AnimationClip animationClip = o as AnimationClip;
			if (animationClip != null)
			{
				int i = 0;
				Entry[] _0024es = _0024_0024locals_002414585._0024es;
				for (int length = _0024es.Length; i < length; i = checked(i + 1))
				{
					_0024es[i].clip = animationClip;
				}
				if (animationClip != null)
				{
					_0024_0024locals_002414585._0024c(animationClip);
				}
			}
		}
	}

	public string targetTypeName;

	public string baseBoneName;

	public string motDefMethodName;

	public string enumTypeName;

	public Entry[] entries;

	public string[] commons;

	public EffectEntry[] effects;

	public CommonEntry[] commonEntries;

	public MiscInfo[] miscInfo;

	private Type cachedTargetType;

	private MethodInfo cachedMotDefMethod;

	private Type cachedMotDefMethodArgType;

	private FieldInfo[] cachedMotDefMethodArgFields;

	private Dictionary<string, EffectEntry> effectDict;

	public string Name => gameObject.name;

	public Type TargetType
	{
		get
		{
			if (cachedTargetType == null)
			{
				Type type = SystemTypeGetType.GetType(targetTypeName);
				if (typeof(Component).IsAssignableFrom(type))
				{
					cachedTargetType = type;
				}
			}
			return cachedTargetType;
		}
	}

	public MethodInfo MotDefMethod
	{
		get
		{
			if (!string.IsNullOrEmpty(motDefMethodName) && cachedMotDefMethod == null)
			{
				cachedMotDefMethod = TargetType.GetMethod(motDefMethodName);
			}
			return cachedMotDefMethod;
		}
	}

	public Type MotDefMethodArgType
	{
		get
		{
			if (cachedMotDefMethodArgType == null)
			{
				MethodInfo motDefMethod = MotDefMethod;
				if (motDefMethod != null)
				{
					ParameterInfo[] parameters = motDefMethod.GetParameters();
					if (parameters.Length != 1)
					{
						throw new AssertionFailedException("len(params) == 1");
					}
					Type parameterType = parameters[0].ParameterType;
					if (!parameterType.IsClass || parameterType.IsPrimitive)
					{
						throw new AssertionFailedException("pt.IsClass and (not pt.IsPrimitive)");
					}
					cachedMotDefMethodArgType = parameterType;
				}
			}
			return cachedMotDefMethodArgType;
		}
	}

	public FieldInfo[] MotDefMethodArgFields
	{
		get
		{
			if (cachedMotDefMethodArgFields == null)
			{
				Type motDefMethodArgType = MotDefMethodArgType;
				if (motDefMethodArgType != null)
				{
					FieldInfo[] motDefMethodArgFields = GetMotDefMethodArgFields(motDefMethodArgType);
					cachedMotDefMethodArgFields = motDefMethodArgFields;
				}
			}
			return cachedMotDefMethodArgFields;
		}
	}

	public override string ToString()
	{
		return (!(this == null)) ? new StringBuilder("MotPack ").Append(Name).ToString() : "MotPack(null)";
	}

	public void OnDestroy()
	{
		dispose();
	}

	public void dispose()
	{
		if (entries == null)
		{
			return;
		}
		int i = 0;
		Entry[] array = entries;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].disposeD540();
			}
		}
	}

	public static FieldInfo[] GetMotDefMethodArgFields(Type motDefArgType)
	{
		return (motDefArgType != null) ? motDefArgType.GetFields() : new FieldInfo[0];
	}

	public string getClipNameByType(int typeID)
	{
		buildCommonTable();
		object result;
		if (commons == null || typeID < 0 || typeID >= commons.Length)
		{
			result = null;
		}
		else
		{
			string[] array = commons;
			result = array[RuntimeServices.NormalizeArrayIndex(array, typeID)];
		}
		return (string)result;
	}

	public int clipNameToTypeID(string n)
	{
		int result;
		if (entries == null || commons == null)
		{
			result = -1;
		}
		else
		{
			int num = 0;
			int length = commons.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < length)
				{
					int num2 = num;
					num++;
					string[] array = commons;
					if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == n)
					{
						result = num2;
						break;
					}
					continue;
				}
				result = -1;
				break;
			}
		}
		return result;
	}

	public string dumpCommonTable()
	{
		return (commons == null) ? "<null>" : ("[" + Builtins.join(commons, "/") + "]");
	}

	private void buildCommonTable()
	{
		if ((!(commons == null) && commons.Length != 0) || commonEntries.Length <= 0)
		{
			return;
		}
		Type enumType = nameToEnumType(enumTypeName);
		checked
		{
			int num = enumMaxValue(enumType) + 1;
			commons = new string[num];
			try
			{
				int i = 0;
				CommonEntry[] array = commonEntries;
				for (int length = array.Length; i < length; i++)
				{
					int num2 = RuntimeServices.UnboxInt32(Enum.Parse(enumType, array[i].enumName));
					if (0 <= num2 && num2 < num)
					{
						string[] array2 = commons;
						array2[RuntimeServices.NormalizeArrayIndex(array2, num2)] = array[i].animName;
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private static Type nameToEnumType(string enumName)
	{
		Type type = SystemTypeGetType.GetType(enumName);
		if (type == null || !type.IsEnum)
		{
			throw new AssertionFailedException(new StringBuilder("enum ").Append(enumName).Append(" is not defined").ToString());
		}
		return type;
	}

	private static int enumMaxValue(Type enumType)
	{
		int num = 0;
		IEnumerator enumerator = Enum.GetValues(enumType).GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			num = Mathf.Max(num, RuntimeServices.UnboxInt32(current));
		}
		return num;
	}

	public EffectEntry getEffectEntry(string n)
	{
		object result;
		if (effects == null || effects.Length <= 0)
		{
			result = null;
		}
		else
		{
			if (effectDict == null)
			{
				effectDict = new Dictionary<string, EffectEntry>();
				int i = 0;
				EffectEntry[] array = effects;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					effectDict[array[i].name] = array[i];
				}
			}
			EffectEntry value = null;
			result = ((!effectDict.TryGetValue(n, out value)) ? null : value);
		}
		return (EffectEntry)result;
	}

	public GameObject getEffect(string n)
	{
		return getEffectEntry(n)?.obj;
	}

	public Entry find(string n)
	{
		int num = 0;
		Entry[] array = entries;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == n)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (Entry)result;
	}

	public bool contains(string n)
	{
		return find(n) != null;
	}

	public Entry[] findAll(string n)
	{
		Boo.Lang.List<Entry> list = new Boo.Lang.List<Entry>();
		int i = 0;
		Entry[] array = entries;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && array[i].name == n)
			{
				list.Add(array[i]);
			}
		}
		return (Entry[])Builtins.array(typeof(Entry), list);
	}

	public Executer createMotionOperationExecuter(GameObject go)
	{
		if (!(go != null))
		{
			throw new AssertionFailedException("go != null");
		}
		return new Executer(go, this);
	}

	public string getMiscInfo(string n)
	{
		int num = 0;
		MiscInfo[] array = miscInfo;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == n)
				{
					result = array[num].value;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (string)result;
	}

	public bool getBoolMiscInfo(string n, bool defValue)
	{
		int num = 0;
		MiscInfo[] array = miscInfo;
		int length = array.Length;
		bool result2;
		while (true)
		{
			if (num < length)
			{
				bool result = default(bool);
				if (array[num].name == n && bool.TryParse(array[num].value, out result))
				{
					result2 = result;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result2 = defValue;
			break;
		}
		return result2;
	}

	public int getIntMiscInfo(string n, int defValue)
	{
		int num = 0;
		MiscInfo[] array = miscInfo;
		int length = array.Length;
		int result2;
		while (true)
		{
			if (num < length)
			{
				int result = default(int);
				if (array[num].name == n && int.TryParse(array[num].value, out result))
				{
					result2 = result;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result2 = defValue;
			break;
		}
		return result2;
	}

	public float getSingleMiscInfo(string n, float defValue)
	{
		int num = 0;
		MiscInfo[] array = miscInfo;
		int length = array.Length;
		float result2;
		while (true)
		{
			if (num < length)
			{
				float result = default(float);
				if (array[num].name == n && float.TryParse(array[num].value, out result))
				{
					result2 = result;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result2 = defValue;
			break;
		}
		return result2;
	}

	public bool containsMiscInfo(string n)
	{
		int num = 0;
		MiscInfo[] array = miscInfo;
		int length = array.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].name == n)
				{
					result = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public bool isLoaded(string animName)
	{
		Entry entry = find(animName);
		bool num = entry != null;
		if (num)
		{
			num = entry.HasClip;
		}
		return num;
	}

	public void loadClip(string animName, __MerlinMotionPack_loadClip_0024callable2_0024381_51__ c)
	{
		_0024loadClip_0024locals_002414267 _0024loadClip_0024locals_0024 = new _0024loadClip_0024locals_002414267();
		_0024loadClip_0024locals_0024._0024c = c;
		_0024loadClip_0024locals_0024._0024es = findAll(animName);
		if (!(_0024loadClip_0024locals_0024._0024es == null) && _0024loadClip_0024locals_0024._0024es.Length > 0)
		{
			RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
			instance.loadAsset(animName, typeof(AnimationClip), _0024adaptor_0024__MerlinMotionPack_loadClip_0024callable370_0024389_23___0024__RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59___00240.Adapt(new _0024loadClip_0024closure_00243821(_0024loadClip_0024locals_0024).Invoke));
		}
	}
}
