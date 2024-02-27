using System;
using System.Collections;
using System.IO;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class DebugSubFont : RuntimeDebugModeGuiMixin
{
	protected int select;

	protected string[] enFonts;

	protected Font lastFont;

	protected int lastFontIndex;

	protected GameObject fontListObj;

	protected FontList fontList;

	protected int lastLangIndex;

	public DebugSubFont()
	{
		enFonts = new string[7] { "SE-ALORN", "SE-BEACHR", "SE-EGGON", "SE-EXPON", "SE-GE40", "SE-LYNDAR", "SE-VOGEN" };
		lastFontIndex = -1;
		lastLangIndex = -1;
	}

	public override void OnGUI()
	{
		title = "Font";
		GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
		bool debugEnglishFontFlag = UIDynamicFontLabel.debugEnglishFontFlag;
		bool debugLanguageFlag = MerlinLanguageSetting.debugLanguageFlag;
		if (UIDynamicFontLabel.useTextTable != null && RuntimeDebugModeGuiMixin.button("Output Dynamic Font Label Text", gUILayoutOption))
		{
			string text = string.Empty;
			IEnumerator enumerator = UIDynamicFontLabel.useTextTable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				object obj2 = UIDynamicFontLabel.useTextTable[text2];
				if (!(obj2 is Hashtable))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
				}
				Hashtable hashtable = (Hashtable)obj2;
				if (hashtable == null)
				{
					continue;
				}
				text += new StringBuilder().Append(text2).Append("\t").ToString();
				IEnumerator enumerator2 = hashtable.Keys.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object obj3 = enumerator2.Current;
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					string text3 = (string)obj3;
					object obj4 = hashtable[text3];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					string value = (string)obj4;
					text += new StringBuilder("Scene:").Append(text3).Append(",GameObject:").Append(value)
						.Append("\t")
						.ToString();
				}
				text += "\n";
			}
			DateTime utcNow = DateTime.UtcNow;
			string text4 = new StringBuilder("DynamicFontLabelText").Append(utcNow).Append(".tsv").ToString();
			text4 = text4.Replace("/", "_");
			File.WriteAllText(text4, text);
		}
		bool debugAllShadowOff = UIDynamicFontLabel.debugAllShadowOff;
		if (RuntimeDebugModeGuiMixin.button("Debug Font Shadow Off = " + debugAllShadowOff, gUILayoutOption))
		{
			UIDynamicFontLabel.debugAllShadowOff = !debugAllShadowOff;
		}
		if (RuntimeDebugModeGuiMixin.button("Debug Language = " + debugLanguageFlag, gUILayoutOption))
		{
			MerlinLanguageSetting.debugLanguageFlag = !debugLanguageFlag;
		}
		if (MerlinLanguageSetting.debugLanguageFlag)
		{
			int debugLanguageType = 0;
			IEnumerator enumerator3 = Enum.GetValues(typeof(LanguageType)).GetEnumerator();
			while (enumerator3.MoveNext())
			{
				int num = RuntimeServices.UnboxInt32(enumerator3.Current);
				string lhs = " ";
				if (lastLangIndex == num)
				{
					lhs = "*";
				}
				if (RuntimeDebugModeGuiMixin.button(lhs + "Language:" + num.ToString()))
				{
					MerlinLanguageSetting.debugLanguageType = (LanguageType)debugLanguageType;
					lastLangIndex = num;
				}
				num = checked(num + 1);
			}
		}
		if (RuntimeDebugModeGuiMixin.button("Debug English Font = " + debugEnglishFontFlag, gUILayoutOption))
		{
			UIDynamicFontLabel.debugEnglishFontFlag = !debugEnglishFontFlag;
		}
		checked
		{
			if (UIDynamicFontLabel.debugEnglishFontFlag)
			{
				GUILayout.Label(new StringBuilder("Font Size = ").Append((object)UIDynamicFontLabel.debugFontSize).ToString());
				UIDynamicFontLabel.debugFontSize = (int)GUILayout.HorizontalSlider(UIDynamicFontLabel.debugFontSize, 16f, 25f);
				if (!fontListObj)
				{
					UnityEngine.Object original = Resources.Load("Prefab/Debug/FontList");
					fontListObj = (GameObject)UnityEngine.Object.Instantiate(original);
					fontList = (FontList)fontListObj.GetComponent(typeof(FontList));
				}
				int debugLanguageType = 0;
				int i = 0;
				string[] array = enFonts;
				string lhs;
				for (int length = array.Length; i < length; i++)
				{
					lhs = " ";
					if (lastFontIndex == debugLanguageType)
					{
						lhs = "*";
					}
					if (RuntimeDebugModeGuiMixin.button(lhs + "Font:" + array[i]) && (bool)fontList)
					{
						Font[] array2 = fontList.fontList;
						UIDynamicFontLabel.debugEnglishFont = array2[RuntimeServices.NormalizeArrayIndex(array2, debugLanguageType)];
						Font[] array3 = fontList.fontList;
						lastFont = array3[RuntimeServices.NormalizeArrayIndex(array3, debugLanguageType)];
						lastFontIndex = debugLanguageType;
					}
					debugLanguageType++;
				}
				lhs = " ";
				if (lastFontIndex == -1)
				{
					lhs = "*";
				}
				if (RuntimeDebugModeGuiMixin.button(lhs + "Font:Default"))
				{
					UIDynamicFontLabel.debugEnglishFont = null;
					lastFontIndex = -1;
				}
			}
			else
			{
				lastFontIndex = -1;
			}
		}
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
		lastLangIndex = (int)MerlinLanguageSetting.GetCurrentLanguage();
		int num = 0;
		if (!fontListObj)
		{
			UnityEngine.Object original = Resources.Load("Prefab/Debug/FontList");
			fontListObj = (GameObject)UnityEngine.Object.Instantiate(original);
			fontList = (FontList)fontListObj.GetComponent(typeof(FontList));
		}
		int i = 0;
		string[] array = enFonts;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				Font debugEnglishFont = UIDynamicFontLabel.debugEnglishFont;
				Font[] array2 = fontList.fontList;
				if (debugEnglishFont == array2[RuntimeServices.NormalizeArrayIndex(array2, num)])
				{
					lastFontIndex = num;
				}
				num++;
			}
		}
	}

	public override void Exit()
	{
	}
}
