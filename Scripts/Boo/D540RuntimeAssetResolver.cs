using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class D540RuntimeAssetResolver : D540DepthFirstTraverser
{
	[Serializable]
	public class SEPool
	{
		public HashSet<string> allNames;

		public Dictionary<string, int> loadedSEs;

		public SEPool()
		{
			allNames = new HashSet<string>();
			loadedSEs = new Dictionary<string, int>();
		}

		public void addSEName(string seName)
		{
			if (!string.IsNullOrEmpty(seName) && !allNames.Contains(seName))
			{
				allNames.Add(seName);
			}
		}

		public int loadedSEID(string seName)
		{
			return (!loadedSEs.ContainsKey(seName)) ? (-1) : loadedSEs[seName];
		}

		public void loadAll()
		{
			foreach (string allName in allNames)
			{
				loadSE(allName);
			}
		}

		public void unloadAll()
		{
			foreach (string allName in allNames)
			{
				unloadSE(allName);
			}
			loadedSEs.Clear();
		}

		public void clearAll()
		{
			unloadAll();
			allNames.Clear();
		}

		private void loadSE(string seName)
		{
			if (!string.IsNullOrEmpty(seName) && GameSoundManager.Instance.LoadSe(seName))
			{
				loadedSEs[seName] = 1;
			}
		}

		private int unloadSE(string seName)
		{
			if (!string.IsNullOrEmpty(seName) && loadedSEs.ContainsKey(seName))
			{
				GameSoundManager.Instance.UnloadSe(seName);
				loadedSEs.Remove(seName);
			}
			return 0;
		}
	}

	private SEPool sePool;

	public SEPool SePool => sePool;

	public D540RuntimeAssetResolver()
	{
		sePool = new SEPool();
	}

	public void loadAssets(MerlinMotionPack motion)
	{
		loadAssets(motion, null);
	}

	public void loadAssets(MerlinMotionPack motion, __D540RuntimeAssetResolver_loadAssets_0024callable1_002459_64__ pred)
	{
		GameSoundManager.Instance.LoadSeGroup("mp_" + motion.Name);
	}

	public void loadAssets(MerlinMotionPack.Entry[] entries)
	{
		loadAssets(entries, null);
	}

	public void loadAssets(MerlinMotionPack.Entry[] entries, __D540RuntimeAssetResolver_loadAssets_0024callable1_002459_64__ pred)
	{
		unloadAssets();
		retrieveAssets(entries, pred);
		sePool.loadAll();
	}

	public void unloadAssets()
	{
		sePool.clearAll();
	}

	public void unloadSEAssets(MerlinMotionPack motion)
	{
		GameSoundManager.Instance.UnloadSeGroup(motion.Name);
	}

	public void retrieveAssets(MerlinMotionPack.Entry[] entries, __D540RuntimeAssetResolver_loadAssets_0024callable1_002459_64__ pred)
	{
		if (entries == null)
		{
			return;
		}
		int i = 0;
		for (int length = entries.Length; i < length; i = checked(i + 1))
		{
			if (entries[i] != null && !(entries[i].clip == null) && (!(pred != null) || pred(entries[i])))
			{
				entries[i].applyAllD540(this);
			}
		}
	}

	public override void outOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		if (node != null)
		{
			string methodName = node.MethodName;
			string text = methodName;
			if (text == "SOUND")
			{
				processSound(node);
			}
		}
	}

	private void processSound(D540OpeInvokeMethod node)
	{
		int index = 1;
		string text = null;
		object[] constantArguments = node.ConstantArguments;
		if (constantArguments != null && 2 <= constantArguments.Length)
		{
			text = constantArguments[RuntimeServices.NormalizeArrayIndex(constantArguments, index)] as string;
		}
		else if (2 <= node.Arguments.Count)
		{
			List<D540OpeCode> arguments = node.Arguments;
			D540OpeCode d540OpeCode = arguments[index];
			if (d540OpeCode is D540OpeValueString)
			{
				text = (d540OpeCode as D540OpeValueString).valueString;
			}
			else if (d540OpeCode is D540OpeEnumOrString)
			{
				D540OpeEnumOrString d540OpeEnumOrString = d540OpeCode as D540OpeEnumOrString;
				text = d540OpeEnumOrString.StringValue;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			sePool.addSEName(text);
		}
	}
}
