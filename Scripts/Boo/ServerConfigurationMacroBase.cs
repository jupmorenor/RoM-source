using System;
using System.Collections.Generic;
using System.IO;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class ServerConfigurationMacroBase : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	public class Setting
	{
		public int index;

		public string defName;

		public string displayName;

		public string blobAccoutName;

		public string blobSharedKey;

		public string platformServerURL;

		public string dbID;

		public string masterDefID;
	}

	[Serializable]
	public class Expander : DepthFirstTransformer
	{
		public Dictionary<string, Expression> replaceInfo;

		public Expander()
		{
			replaceInfo = new Dictionary<string, Expression>();
		}

		public void init(Setting s)
		{
			ReferenceExpression referenceExpression = new ReferenceExpression();
			string text = (referenceExpression.Name = s.defName);
			ReferenceExpression referenceExpression2 = referenceExpression;
			replaceInfo["_index_"] = new IntegerLiteralExpression(s.index);
			replaceInfo["_defName_"] = referenceExpression2;
			replaceInfo["_displayName_"] = new StringLiteralExpression(s.displayName);
			replaceInfo["_blobAccountName_"] = new StringLiteralExpression(s.blobAccoutName);
			replaceInfo["_blobSharedKey_"] = new StringLiteralExpression(s.blobSharedKey);
			replaceInfo["_platformServerURL_"] = new StringLiteralExpression(s.platformServerURL);
			Dictionary<string, Expression> dictionary = replaceInfo;
			ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
			string text3 = (referenceExpression3.Name = "EnumServerTypes");
			dictionary["_enum_"] = new MemberReferenceExpression(referenceExpression3, CodeSerializer.LiftName(referenceExpression2));
		}

		public override void OnReferenceExpression(ReferenceExpression node)
		{
			string name = node.Name;
			if (replaceInfo.ContainsKey(name))
			{
				ReplaceCurrentNode(replaceInfo[name].CloneNode());
			}
		}
	}

	[NonSerialized]
	private const string CONFIG_FILE = "Assets/ServerConfiguration.txt";

	[NonSerialized]
	private static Boo.Lang.List<Setting> _SettingList;

	public static Boo.Lang.List<Setting> SettingList
	{
		get
		{
			if (_SettingList == null)
			{
				ReadConfiguration();
			}
			return _SettingList;
		}
	}

	public static Setting FindSetting(string defName)
	{
		IEnumerator<Setting> enumerator = SettingList.GetEnumerator();
		Setting setting;
		try
		{
			while (enumerator.MoveNext())
			{
				Setting current = enumerator.Current;
				if (!(current.defName == defName))
				{
					continue;
				}
				setting = current;
				goto IL_0049;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_004a;
		IL_0049:
		result = setting;
		goto IL_004a;
		IL_004a:
		return (Setting)result;
	}

	private static void ReadConfiguration()
	{
		_SettingList = new Boo.Lang.List<Setting>();
		StreamReader streamReader;
		IDisposable disposable = (streamReader = new StreamReader("Assets/ServerConfiguration.txt")) as IDisposable;
		checked
		{
			try
			{
				int num = 0;
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine().Trim();
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					int num2 = text.IndexOf('#');
					if (num2 >= 0)
					{
						string text2 = text;
						text = text2.Substring(RuntimeServices.NormalizeStringIndex(text2, num2 + 1)).Trim();
					}
					if (string.IsNullOrEmpty(text))
					{
						continue;
					}
					string[] array = text.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length >= 5)
					{
						Setting setting = new Setting();
						setting.defName = array[0];
						setting.displayName = array[1];
						setting.blobAccoutName = array[2];
						setting.blobSharedKey = array[3];
						setting.platformServerURL = array[4];
						if (array.Length >= 6)
						{
							setting.dbID = array[5];
						}
						if (array.Length >= 7)
						{
							setting.masterDefID = array[6];
						}
						setting.index = num++;
						_SettingList.Add(setting);
					}
				}
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement macro)
	{
		throw new NotImplementedException();
	}
}
