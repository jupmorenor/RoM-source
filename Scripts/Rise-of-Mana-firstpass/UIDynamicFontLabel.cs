using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Dynamic Font Label")]
public class UIDynamicFontLabel : UILabelBase
{
	public enum Alignment
	{
		Left,
		Center,
		Right
	}

	public enum VAlignment
	{
		Top,
		Center,
		Bottom
	}

	private static string shaderName = "Unlit/Transparent Colored (Packed) Soft";

	private static Shader shader = null;

	public static Hashtable useTextTable = null;

	private static FontList fontList = null;

	public static bool debugEnglishFontFlag = false;

	public static Font debugEnglishFont;

	public static int debugFontSize = 0;

	public static bool debugAllShadowOff = false;

	private char[] m_cInTab = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'a', 'b', 'c', 'd', 'e', 'f'
	};

	public string m_FontName;

	private Font m_CurFont;

	public float m_fChSpace;

	private float m_fLastChSpace;

	public float m_fLineW;

	public float m_fLineH;

	private float m_fLastLineW;

	private float m_fLastLineH;

	public Vector2 m_vDefaultScale = Vector2.one;

	public bool m_bFitWidth;

	public Font m_Font;

	public Font m_OrgFont;

	private Font m_LastFont;

	private Rect m_Bounds;

	public Alignment m_Align;

	public VAlignment m_VAlign;

	private Alignment m_LastAlign;

	private VAlignment m_LastVAlign;

	private Vector3[] m_Verts;

	private Vector2[] m_Uvs;

	private Color32[] m_Cols;

	private float[] m_LineOfs;

	private int[] m_LineChangeIndex;

	public int m_iDispTextCount = -1;

	public int m_iDrawDispTextCount = -1;

	private int m_DispCharLength;

	public string m_Text = string.Empty;

	private string m_strSaveText;

	private Color m_LastColor;

	public bool m_bShadow;

	public Vector2 m_vShadow = Vector2.zero;

	public Vector2 m_vShadowScale = Vector2.one;

	public Color m_ShadowColor;

	public bool m_bBackGround;

	public Color m_BackGround;

	public int m_iAutoWrapCharNum;

	private int m_iLastAutoWrapCharNum;

	public FontStyle m_FontStyle;

	private FontStyle m_LastFontStyle;

	public int m_FontSize;

	private int m_LastFontSize;

	private int m_DefFontSize;

	public float m_fSoftX = 1f;

	public float m_fSoftY = 1f;

	public float m_fSoftWeight;

	public float m_fMarginX;

	public float m_fMarginY;

	private char[] m_ChArray;

	private int[] m_ChSizeArray;

	private FontStyle[] m_ChStyleArray;

	private float[] m_ChUvCheckArray;

	private int m_iChCount;

	private int m_iTextCount;

	private int m_iLineIndex;

	public List<CharacterInfo> m_ChInfoList;

	public char m_cInitAllocWord = 'O';

	public int m_iInitAllocWordSize = 640;

	private bool rebuild;

	private bool m_bLastRebuildFlag;

	private static int resetCount = 0;

	private int curResetCount;

	private static Hashtable m_FontHash = new Hashtable();

	private bool doneWaitOneFrame;

	public override string text
	{
		get
		{
			return m_Text;
		}
		set
		{
			setText(value);
		}
	}

	public bool LastRebuildFlag => m_bLastRebuildFlag;

	public static bool Reset
	{
		set
		{
			if (value)
			{
				resetCount++;
				if (fontList != null)
				{
					fontList.Init();
					m_FontHash.Clear();
				}
			}
		}
	}

	public Font Font
	{
		get
		{
			return m_Font;
		}
		set
		{
			m_Font = value;
		}
	}

	public Material FontMaterial => material;

	public Texture FontTexture
	{
		get
		{
			if ((bool)material)
			{
				return material.mainTexture;
			}
			return null;
		}
	}

	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
		}
	}

	public int TextCount => m_iTextCount;

	public float ChSpace
	{
		get
		{
			return m_fChSpace;
		}
		set
		{
			m_fChSpace = value;
		}
	}

	public float LineH
	{
		get
		{
			return m_fLineH;
		}
		set
		{
			m_fLineH = value;
		}
	}

	public float LineW
	{
		get
		{
			return m_fLineW;
		}
		set
		{
			m_fLineW = value;
		}
	}

	public bool FitWidth
	{
		get
		{
			return m_bFitWidth;
		}
		set
		{
			m_bFitWidth = value;
		}
	}

	public int DispTextCount
	{
		get
		{
			return m_iDispTextCount;
		}
		set
		{
			m_iDispTextCount = value;
			MarkAsChanged();
		}
	}

	public int DrawDispTextCount
	{
		get
		{
			return m_iDrawDispTextCount;
		}
		set
		{
			m_iDrawDispTextCount = value;
		}
	}

	public Alignment Align
	{
		get
		{
			return m_Align;
		}
		set
		{
			m_Align = value;
		}
	}

	public VAlignment VAlign
	{
		get
		{
			return m_VAlign;
		}
		set
		{
			m_VAlign = value;
		}
	}

	public bool IsShadow
	{
		get
		{
			return m_bShadow;
		}
		set
		{
			m_bShadow = value;
		}
	}

	public Vector2 ShadowOffset
	{
		get
		{
			return m_vShadow;
		}
		set
		{
			m_vShadow = value;
		}
	}

	public Vector2 ShadowScale
	{
		get
		{
			return m_vShadowScale;
		}
		set
		{
			m_vShadowScale = value;
		}
	}

	public Color ShadowColor
	{
		get
		{
			return m_ShadowColor;
		}
		set
		{
			m_ShadowColor = value;
		}
	}

	public bool IsBackGround
	{
		get
		{
			return m_bBackGround;
		}
		set
		{
			m_bBackGround = value;
		}
	}

	public Color BackGroundColor
	{
		get
		{
			return m_BackGround;
		}
		set
		{
			m_BackGround = value;
		}
	}

	public int AutoWrapCharNum
	{
		get
		{
			return m_iAutoWrapCharNum;
		}
		set
		{
			m_iAutoWrapCharNum = value;
		}
	}

	public FontStyle FontStyle
	{
		get
		{
			return m_FontStyle;
		}
		set
		{
			m_FontStyle = value;
		}
	}

	public int FontSize
	{
		get
		{
			return m_FontSize;
		}
		set
		{
			m_FontSize = value;
		}
	}

	public static Hashtable FontHash => m_FontHash;

	public override bool keepMaterial => true;

	public override Vector2 relativeSize
	{
		get
		{
			Vector2 result = base.relativeSize;
			result.x *= m_Bounds.width;
			result.y *= m_Bounds.height;
			return result;
		}
	}

	public override void setText(string t)
	{
		m_iDispTextCount = -1;
		m_Text = t;
	}

	private int ByteCharToInt(char c)
	{
		for (int i = 0; i < m_cInTab.Length; i++)
		{
			if (c == m_cInTab[i])
			{
				return i;
			}
		}
		return 0;
	}

	public int LineNum(int index)
	{
		for (int i = 0; i <= m_iLineIndex; i++)
		{
			if (index * 4 < m_LineChangeIndex[i])
			{
				return i;
			}
		}
		return 0;
	}

	public void RebuildCharactersInTexture()
	{
		m_iChCount = 0;
		m_strSaveText = null;
		material = null;
		rebuild = true;
		m_LastFont = null;
		if ((bool)m_CurFont)
		{
			m_FontHash[m_CurFont] = true;
			material = m_CurFont.material;
			if ((bool)material)
			{
				material.hideFlags = HideFlags.DontSave;
				shader = Shader.Find(shaderName);
				material.shader = shader;
			}
		}
	}

	public bool RequestCharactersInTexture(char c, int size, FontStyle style)
	{
		if (!m_CurFont)
		{
			return false;
		}
		string text = c.ToString();
		int length = text.Length;
		if (length <= 0 || length > 1)
		{
			return false;
		}
		bool result = true;
		try
		{
			m_CurFont.RequestCharactersInTexture(text, size, style);
		}
		catch (ArgumentException)
		{
			Debug.LogError("Illigal Char RequestCharactersInTexture = " + (int)c);
			result = false;
		}
		return result;
	}

	public bool GetCharacterInfo(char c, out CharacterInfo ci, int size, FontStyle style)
	{
		ci = default(CharacterInfo);
		if (!m_CurFont)
		{
			return false;
		}
		return m_CurFont.GetCharacterInfo(c, out ci, size, style);
	}

	public bool HasCharacter(char c, int size, FontStyle style)
	{
		CharacterInfo info = default(CharacterInfo);
		return m_CurFont.GetCharacterInfo(c, out info, size, style);
	}

	protected override void Awake()
	{
		base.Awake();
		m_strSaveText = null;
		m_OrgFont = m_Font;
		if (fontList == null)
		{
			UnityEngine.Object @object = Resources.Load("Prefab/Font/FontList");
			if (@object != null)
			{
				fontList = ((GameObject)UnityEngine.Object.Instantiate(@object)).GetComponent<FontList>();
				if (fontList != null)
				{
					fontList.gameObject.name = "__FontList__";
				}
			}
		}
		curResetCount = resetCount;
		SetCurFont(m_Font);
		m_vDefaultScale.x = base.transform.localScale.x;
		m_vDefaultScale.y = base.transform.localScale.y;
	}

	private IEnumerator WaitOneDraw()
	{
		if (!doneWaitOneFrame)
		{
			yield return new WaitForEndOfFrame();
			doneWaitOneFrame = true;
			mChanged = true;
		}
	}

	protected override void OnStart()
	{
	}

	private void SetCurFont(Font font)
	{
		if (m_LastFont == font)
		{
			return;
		}
		if (fontList != null)
		{
			m_CurFont = fontList.GetFont(font);
		}
		if ((bool)m_CurFont)
		{
			m_CurFont.textureRebuildCallback = RebuildCharactersInTexture;
			material = m_CurFont.material;
			if ((bool)material)
			{
				material.hideFlags = HideFlags.DontSave;
				shader = Shader.Find(shaderName);
				material.shader = shader;
				if (!GetCharacterInfo(' ', out var ci, 0, FontStyle.Normal))
				{
					m_CurFont.RequestCharactersInTexture(" ");
				}
				if (GetCharacterInfo(' ', out ci, 0, FontStyle.Normal))
				{
					m_DefFontSize = (int)(ci.width * 2f);
				}
				if (!GetCharacterInfo(m_cInitAllocWord, out ci, m_iInitAllocWordSize, FontStyle.Normal))
				{
					m_CurFont.RequestCharactersInTexture(m_cInitAllocWord.ToString(), m_iInitAllocWordSize, FontStyle.Normal);
				}
			}
		}
		m_LastFont = font;
	}

	private new void OnEnable()
	{
		m_strSaveText = null;
		if ((bool)m_CurFont)
		{
			material = m_CurFont.material;
			material.hideFlags = HideFlags.DontSave;
			material.shader = shader;
		}
		if ((bool)base.panel)
		{
			base.panel.generateNormals = true;
		}
		StartCoroutine(WaitOneDraw());
	}

	public override bool OnUpdate()
	{
		if (!doneWaitOneFrame)
		{
			return false;
		}
		return UpdateLabel();
	}

	private void LateUpdate()
	{
		if (fontList != null && curResetCount != resetCount)
		{
			m_CurFont = fontList.GetFont(m_Font);
			curResetCount = resetCount;
		}
	}

	public bool UpdateLabel()
	{
		bool flag = false;
		if (m_Text == null)
		{
			m_Text = string.Empty;
		}
		if (debugEnglishFontFlag)
		{
			if (debugEnglishFont != null)
			{
				m_Font = debugEnglishFont;
			}
			else if (m_Font != m_OrgFont)
			{
				m_Font = m_OrgFont;
			}
		}
		if (debugFontSize != 0)
		{
			m_FontSize = debugFontSize;
		}
		if (m_Font != m_LastFont)
		{
			SetCurFont(m_Font);
			m_LastFont = m_Font;
			m_strSaveText = null;
		}
		if (!m_CurFont)
		{
			return true;
		}
		if (m_LastColor != base.color)
		{
			m_LastColor = base.color;
			m_strSaveText = null;
		}
		if (m_LastAlign != m_Align || m_LastVAlign != m_VAlign)
		{
			m_LastAlign = m_Align;
			m_LastVAlign = m_VAlign;
			m_strSaveText = null;
		}
		if (m_fLastChSpace != m_fChSpace)
		{
			m_fLastChSpace = m_fChSpace;
			m_strSaveText = null;
		}
		if (m_fLastLineH != m_fLineH)
		{
			m_fLastLineH = m_fLineH;
			m_strSaveText = null;
		}
		if (m_fLastLineW != m_fLineW)
		{
			m_fLastLineW = m_fLineW;
			m_strSaveText = null;
		}
		if (m_LastFontStyle != m_FontStyle)
		{
			m_LastFontStyle = m_FontStyle;
			m_strSaveText = null;
		}
		if (m_LastFontSize != m_FontSize)
		{
			m_LastFontSize = m_FontSize;
			m_strSaveText = null;
		}
		if (m_iLastAutoWrapCharNum != m_iAutoWrapCharNum)
		{
			m_iLastAutoWrapCharNum = m_iAutoWrapCharNum;
			m_strSaveText = null;
		}
		if (m_strSaveText != null && m_ChArray != null && m_ChSizeArray != null && m_ChStyleArray != null && m_ChUvCheckArray != null)
		{
			CharacterInfo ci = default(CharacterInfo);
			for (int i = 0; i < m_iChCount && i < m_ChArray.Length; i++)
			{
				if (m_ChArray[i] != 0)
				{
					if (!GetCharacterInfo(m_ChArray[i], out ci, m_ChSizeArray[i], m_ChStyleArray[i]))
					{
						m_strSaveText = null;
						break;
					}
					float num = ci.uv.x + ci.uv.y + ci.uv.width + ci.uv.height;
					if (m_ChUvCheckArray[i] != num)
					{
						m_strSaveText = null;
						break;
					}
				}
			}
		}
		if (m_strSaveText != m_Text)
		{
			bool flag2 = true;
			int num2 = 0;
			float num3 = 0f;
			float num4 = 0f;
			if (material != null)
			{
				num3 = m_fMarginX / (float)material.mainTexture.width;
				num4 = (0f - m_fMarginY) / (float)material.mainTexture.height;
			}
			m_iChCount = 0;
			m_iTextCount = 0;
			m_iLineIndex = 0;
			m_Verts = null;
			m_Uvs = null;
			m_Cols = null;
			m_LineOfs = null;
			m_LineChangeIndex = null;
			m_bLastRebuildFlag = false;
			m_iDrawDispTextCount = 0;
			if (m_Text.Length > 0)
			{
				m_ChInfoList = new List<CharacterInfo>();
				char[] array = m_Text.ToCharArray();
				m_ChArray = new char[m_Text.Length];
				m_ChSizeArray = new int[m_Text.Length];
				m_ChStyleArray = new FontStyle[m_Text.Length];
				m_ChUvCheckArray = new float[m_Text.Length];
				CharacterInfo[] array2 = new CharacterInfo[m_Text.Length];
				m_Verts = new Vector3[4 * m_Text.Length];
				m_Uvs = new Vector2[4 * m_Text.Length];
				m_Cols = new Color32[4 * m_Text.Length];
				m_LineOfs = new float[m_Text.Length * 2];
				m_LineChangeIndex = new int[m_Text.Length * 2];
				Color32 col = new Color32((byte)(127f * base.color.r), (byte)(127f * base.color.g), (byte)(127f * base.color.b), (byte)(127f * base.color.a + 128f));
				float num5 = 0f;
				float num6 = 0f;
				int num7 = 0;
				FontStyle fontStyle = m_FontStyle;
				int fontSize = m_FontSize;
				int num8;
				for (num8 = 0; num8 < m_Text.Length; num8++)
				{
					num8 = CheckColor(array, num8, ref col);
					if (num8 >= m_Text.Length)
					{
						break;
					}
					num8 = CheckSpecialTag(array, num8, ref col, ref fontStyle, ref fontSize);
					if (num8 >= m_Text.Length)
					{
						break;
					}
					if (array[num8] == '\a' || (array[num8] == '\r' && num8 + 1 < m_Text.Length && array[num8 + 1] == '\n'))
					{
						continue;
					}
					if (array[num8] == '\n' || array[num8] == '\r' || (num2 >= m_iAutoWrapCharNum && m_iAutoWrapCharNum > 0))
					{
						m_LineOfs[m_iLineIndex] = num5;
						m_LineChangeIndex[m_iLineIndex] = num7;
						num6 -= m_fLineH;
						num5 = 0f;
						m_iLineIndex++;
						num2 = 0;
						if (array[num8] == '\n' || array[num8] == '\r')
						{
							continue;
						}
					}
					num2++;
					RequestCharactersInTexture(array[num8], fontSize, fontStyle);
					if (rebuild)
					{
						rebuild = false;
						flag2 = false;
						m_Verts = null;
						m_bLastRebuildFlag = true;
						break;
					}
					int iChCount = m_iChCount;
					if (iChCount >= m_ChArray.Length)
					{
						break;
					}
					m_iChCount++;
					m_ChArray[iChCount] = '\0';
					if (!GetCharacterInfo(array[num8], out array2[num8], fontSize, fontStyle))
					{
						flag2 = false;
					}
					else
					{
						m_ChUvCheckArray[iChCount] = array2[num8].uv.x + array2[num8].uv.y + array2[num8].uv.width + array2[num8].uv.height;
						m_ChArray[iChCount] = array[num8];
						m_ChSizeArray[iChCount] = fontSize;
						m_ChStyleArray[iChCount] = fontStyle;
					}
					if (m_fLineH <= 0f)
					{
						m_fLineH = 2f * array2[num8].width;
					}
					ref Vector3 reference = ref m_Verts[num7];
					reference = new Vector3(num5 + array2[num8].vert.x, num6 + array2[num8].vert.y, 0f);
					ref Vector3 reference2 = ref m_Verts[num7 + 1];
					reference2 = new Vector3(num5 + array2[num8].vert.x + array2[num8].vert.width, num6 + array2[num8].vert.y, 0f);
					ref Vector3 reference3 = ref m_Verts[num7 + 2];
					reference3 = new Vector3(num5 + array2[num8].vert.x + array2[num8].vert.width, num6 + array2[num8].vert.y + array2[num8].vert.height, 0f);
					ref Vector3 reference4 = ref m_Verts[num7 + 3];
					reference4 = new Vector3(num5 + array2[num8].vert.x, num6 + array2[num8].vert.y + array2[num8].vert.height, 0f);
					num5 += array2[num8].width + m_fChSpace;
					if (!array2[num8].flipped)
					{
						ref Vector2 reference5 = ref m_Uvs[num7];
						reference5 = new Vector2(array2[num8].uv.x - num3, array2[num8].uv.y + array2[num8].uv.height + num4);
						ref Vector2 reference6 = ref m_Uvs[num7 + 1];
						reference6 = new Vector2(array2[num8].uv.x + array2[num8].uv.width + num3, array2[num8].uv.y + array2[num8].uv.height + num4);
						ref Vector2 reference7 = ref m_Uvs[num7 + 2];
						reference7 = new Vector2(array2[num8].uv.x + array2[num8].uv.width + num3, array2[num8].uv.y - num4);
						ref Vector2 reference8 = ref m_Uvs[num7 + 3];
						reference8 = new Vector2(array2[num8].uv.x - num3, array2[num8].uv.y - num4);
					}
					else
					{
						ref Vector2 reference9 = ref m_Uvs[num7 + 2];
						reference9 = new Vector2(array2[num8].uv.x - num3, array2[num8].uv.y + array2[num8].uv.height + num4);
						ref Vector2 reference10 = ref m_Uvs[num7 + 1];
						reference10 = new Vector2(array2[num8].uv.x + array2[num8].uv.width + num3, array2[num8].uv.y + array2[num8].uv.height + num4);
						ref Vector2 reference11 = ref m_Uvs[num7];
						reference11 = new Vector2(array2[num8].uv.x + array2[num8].uv.width + num3, array2[num8].uv.y - num4);
						ref Vector2 reference12 = ref m_Uvs[num7 + 3];
						reference12 = new Vector2(array2[num8].uv.x - num3, array2[num8].uv.y - num4);
					}
					m_Cols[num7] = col;
					m_Cols[num7 + 1] = col;
					m_Cols[num7 + 2] = col;
					m_Cols[num7 + 3] = col;
					num7 += 4;
				}
				m_LineOfs[m_iLineIndex] = num5;
				m_LineChangeIndex[m_iLineIndex] = num7;
			}
			if (flag2)
			{
				m_strSaveText = m_Text;
			}
			flag = true;
		}
		m_iTextCount = m_iChCount;
		if (flag)
		{
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			m_Bounds = new Rect(0f, 0f, 0f, 0f);
			if (m_Verts != null)
			{
				for (int j = 0; j < m_Verts.Length; j++)
				{
					if (num9 > m_Verts[j].x)
					{
						num9 = m_Verts[j].x;
					}
					if (num11 < m_Verts[j].x)
					{
						num11 = m_Verts[j].x;
					}
					if (num10 > m_Verts[j].y)
					{
						num10 = m_Verts[j].y;
					}
					if (num12 < m_Verts[j].y)
					{
						num12 = m_Verts[j].y;
					}
				}
				m_Bounds.x = num9;
				m_Bounds.y = num10;
				m_Bounds.width = num11 - num9;
				m_Bounds.height = num12 - num10;
				if (m_bFitWidth && m_fLineW > 0f)
				{
					float num13 = m_vDefaultScale.x;
					float y = m_vDefaultScale.y;
					if (m_Bounds.width > 0f && m_Bounds.width > m_fLineW)
					{
						float num14 = m_fLineW / m_Bounds.width;
						num13 *= num14;
					}
					base.transform.localScale = new Vector3(num13, y, 1f);
				}
				if (m_Align == Alignment.Center)
				{
					int k = 0;
					for (int l = 0; l < m_Verts.Length; l++)
					{
						if (k >= m_iChCount)
						{
							break;
						}
						for (; m_LineChangeIndex[k] <= l && k + 1 < m_iChCount; k++)
						{
						}
						m_Verts[l].x += (m_Bounds.width - m_LineOfs[k]) * 0.5f;
					}
				}
				else if (m_Align == Alignment.Right)
				{
					int num15 = 0;
					for (int m = 0; m < m_Verts.Length; m++)
					{
						if (num15 >= m_iChCount)
						{
							break;
						}
						if (m_LineChangeIndex[num15] <= m)
						{
							num15++;
						}
						m_Verts[m].x += m_Bounds.width - m_LineOfs[num15];
					}
				}
				m_Bounds.y += m_Bounds.height;
				if (m_VAlign == VAlignment.Center)
				{
					m_Bounds.y += (0f - m_Bounds.height) * 0.5f;
				}
				else if (m_VAlign == VAlignment.Bottom)
				{
					m_Bounds.y += 0f - m_Bounds.height;
				}
			}
			if ((bool)m_CurFont)
			{
				m_FontHash[m_CurFont] = false;
			}
		}
		if (flag)
		{
			mChanged = true;
		}
		return flag;
	}

	private int CheckColor(char[] chArray, int pos, ref Color32 color)
	{
		int num = pos;
		bool flag = false;
		if (chArray[num] == '[' && (num <= 0 || chArray[num - 1] != '\a'))
		{
			int num2 = 0;
			int num3 = 0;
			num2 = num + 1;
			for (num3 = 0; num2 < m_Text.Length; num2++, num3++)
			{
				if (chArray[num2] != ']' || (num3 != 8 && num3 != 6))
				{
					continue;
				}
				try
				{
					flag = true;
					int num4 = num + 1;
					int num5 = ByteCharToInt(chArray[num4++]) * 16 + ByteCharToInt(chArray[num4++]);
					int num6 = ByteCharToInt(chArray[num4++]) * 16 + ByteCharToInt(chArray[num4++]);
					int num7 = ByteCharToInt(chArray[num4++]) * 16 + ByteCharToInt(chArray[num4++]);
					int num8 = 255;
					if (num3 > 6)
					{
						num8 = ByteCharToInt(chArray[num4++]) * 16 + ByteCharToInt(chArray[num4++]);
					}
					color = new Color32((byte)(num5 >> 1), (byte)(num6 >> 1), (byte)(num7 >> 1), (byte)((num8 >> 1) + 128));
					num2++;
					num = num2;
				}
				catch (Exception)
				{
					flag = false;
					continue;
				}
				break;
			}
		}
		if (flag)
		{
			pos = num;
		}
		return pos;
	}

	private int CheckSpecialTag(char[] chArray, int pos, ref Color32 col, ref FontStyle fontStyle, ref int fontSize)
	{
		int num = pos;
		bool flag = false;
		if (chArray[num] == '<' && (num <= 0 || chArray[num - 1] != '\a'))
		{
			int num2 = 0;
			int num3 = 0;
			num2 = num + 1;
			num3 = 0;
			while (num2 < m_Text.Length)
			{
				if (chArray[num2] == '>')
				{
					if (num3 >= 1)
					{
						if (num3 == 6 && chArray[num + 1] == 'I' && chArray[num + 2] == 'T' && chArray[num + 3] == 'A' && chArray[num + 4] == 'L' && chArray[num + 5] == 'I' && chArray[num + 6] == 'C')
						{
							flag = true;
							if (fontStyle == FontStyle.Bold)
							{
								fontStyle = FontStyle.BoldAndItalic;
							}
							else if (fontStyle == FontStyle.Normal)
							{
								fontStyle = FontStyle.Italic;
							}
						}
						else if (num3 == 4 && chArray[num + 1] == 'B' && chArray[num + 2] == 'O' && chArray[num + 3] == 'L' && chArray[num + 4] == 'D')
						{
							flag = true;
							if (fontStyle == FontStyle.Italic)
							{
								fontStyle = FontStyle.BoldAndItalic;
							}
							else if (fontStyle == FontStyle.Normal)
							{
								fontStyle = FontStyle.Bold;
							}
						}
						else if (num3 == 9 && chArray[num + 1] == 'F' && chArray[num + 2] == 'O' && chArray[num + 3] == 'N' && chArray[num + 4] == 'T' && chArray[num + 5] == '_' && chArray[num + 6] == 'I' && chArray[num + 7] == 'N' && chArray[num + 8] == 'I' && chArray[num + 9] == 'T')
						{
							flag = true;
							fontStyle = m_FontStyle;
						}
						else if (num3 == 5 && chArray[num + 1] == 'G' && chArray[num + 2] == 'R' && chArray[num + 3] == 'E' && chArray[num + 4] == 'E' && chArray[num + 5] == 'N')
						{
							flag = true;
							col = new Color32(0, 127, 0, col.a);
						}
						else if (num3 == 6 && chArray[num + 1] == 'Y' && chArray[num + 2] == 'E' && chArray[num + 3] == 'L' && chArray[num + 4] == 'L' && chArray[num + 5] == 'O' && chArray[num + 6] == 'W')
						{
							flag = true;
							col = new Color32(127, 127, 0, col.a);
						}
						else if (num3 == 4 && chArray[num + 1] == 'B' && chArray[num + 2] == 'L' && chArray[num + 3] == 'U' && chArray[num + 4] == 'E')
						{
							flag = true;
							col = new Color32(0, 0, 127, col.a);
						}
						else if (num3 == 4 && chArray[num + 1] == 'P' && chArray[num + 2] == 'I' && chArray[num + 3] == 'N' && chArray[num + 4] == 'K')
						{
							flag = true;
							col = new Color32(127, 0, 127, col.a);
						}
						else if (num3 == 3 && chArray[num + 1] == 'R' && chArray[num + 2] == 'E' && chArray[num + 3] == 'D')
						{
							flag = true;
							col = new Color32(127, 0, 0, col.a);
						}
						else if (num3 == 5 && chArray[num + 1] == 'B' && chArray[num + 2] == 'L' && chArray[num + 3] == 'A' && chArray[num + 4] == 'C' && chArray[num + 5] == 'K')
						{
							flag = true;
							col = new Color32(0, 0, 0, col.a);
						}
						else if (num3 == 10 && chArray[num + 1] == 'C' && chArray[num + 2] == 'O' && chArray[num + 3] == 'L' && chArray[num + 4] == 'O' && chArray[num + 5] == 'R' && chArray[num + 6] == '_' && chArray[num + 7] == 'I' && chArray[num + 8] == 'N' && chArray[num + 9] == 'I' && chArray[num + 10] == 'T')
						{
							flag = true;
							col = new Color32((byte)(127f * base.color.r), (byte)(127f * base.color.g), (byte)(127f * base.color.b), (byte)(127f * base.color.a + 128f));
						}
						else if (num3 == 6 && chArray[num + 1] == 'S' && chArray[num + 2] == 'I' && chArray[num + 3] == 'Z' && chArray[num + 4] == 'E' && chArray[num + 5] == '_' && chArray[num + 6] == 'L')
						{
							flag = true;
							if (m_FontSize != 0)
							{
								fontSize = m_FontSize * 2;
							}
							else
							{
								fontSize = m_DefFontSize * 2;
							}
						}
						else if (num3 == 6 && chArray[num + 1] == 'S' && chArray[num + 2] == 'I' && chArray[num + 3] == 'Z' && chArray[num + 4] == 'E' && chArray[num + 5] == '_' && chArray[num + 6] == 'S')
						{
							flag = true;
							if (m_FontSize != 0)
							{
								fontSize = m_FontSize / 2;
							}
							else
							{
								fontSize = m_DefFontSize / 2;
							}
						}
						else if (num3 == 7 && chArray[num + 1] == 'S' && chArray[num + 2] == 'I' && chArray[num + 3] == 'Z' && chArray[num + 4] == 'E' && chArray[num + 5] == '_' && chArray[num + 6] == 'L' && chArray[num + 7] == 'L')
						{
							flag = true;
							if (m_FontSize != 0)
							{
								fontSize = m_FontSize * 3;
							}
							else
							{
								fontSize = m_DefFontSize * 3;
							}
						}
						else if (num3 == 7 && chArray[num + 1] == 'S' && chArray[num + 2] == 'I' && chArray[num + 3] == 'Z' && chArray[num + 4] == 'E' && chArray[num + 5] == '_' && chArray[num + 6] == 'X')
						{
							flag = true;
							int result = 0;
							if (int.TryParse(chArray[num + 7].ToString(), out result))
							{
								if (m_FontSize != 0)
								{
									fontSize = m_FontSize * result;
								}
								else
								{
									fontSize = m_DefFontSize * result;
								}
							}
						}
						else if (num3 == 9 && chArray[num + 1] == 'S' && chArray[num + 2] == 'I' && chArray[num + 3] == 'Z' && chArray[num + 4] == 'E' && chArray[num + 5] == '_' && chArray[num + 6] == 'I' && chArray[num + 7] == 'N' && chArray[num + 8] == 'I' && chArray[num + 9] == 'T')
						{
							flag = true;
							fontSize = m_FontSize;
						}
					}
					num2++;
					num = num2;
					break;
				}
				num2++;
				num3++;
			}
		}
		if (flag)
		{
			pos = num;
		}
		return pos;
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (!doneWaitOneFrame || m_CurFont == null || !m_FontHash.ContainsKey(m_CurFont) || (bool)m_FontHash[m_CurFont] || m_Verts == null)
		{
			return;
		}
		int num = m_Verts.Length;
		if (m_iDispTextCount >= 0 && m_iDispTextCount * 4 < num)
		{
			num = m_iDispTextCount * 4;
		}
		if (num <= 0)
		{
			return;
		}
		m_iDrawDispTextCount = m_iDispTextCount;
		float x = m_Bounds.x;
		float num2 = 0f - m_Bounds.y;
		Color32 item = new Color32((byte)(127f * m_ShadowColor.r), (byte)(127f * m_ShadowColor.g), (byte)(127f * m_ShadowColor.b), (byte)(127f * m_ShadowColor.a + 128f));
		int a = item.a;
		float num3 = 0f;
		float num4 = 0f;
		bool flag = m_bShadow;
		if (debugAllShadowOff)
		{
			flag = false;
		}
		if (flag)
		{
			int num5 = 0;
			int num6 = 0;
			while (num5 < num)
			{
				if (num6 >= 4)
				{
					num6 = 0;
				}
				if (num6 == 0)
				{
					num3 = m_Verts[num5].x;
					num4 = m_Verts[num5].y;
				}
				Vector3 zero = Vector3.zero;
				zero.x = num3 + (m_Verts[num5].x - num3) * m_vShadowScale.x;
				zero.y = num4 + (m_Verts[num5].y - num4) * m_vShadowScale.y;
				zero.z = -0.5f;
				item.a = (byte)((float)(a * m_Cols[num5].a >> 8) * mPanel.alpha);
				zero.x += x + m_vShadow.x;
				zero.y += num2 - m_vShadow.y;
				verts.Add(zero);
				uvs.Add(m_Uvs[num5]);
				cols.Add(item);
				num5++;
				num6++;
			}
		}
		for (int i = 0; i < num; i++)
		{
			Vector3 item2 = new Vector3(m_Verts[i].x, m_Verts[i].y, -1f);
			item2.x += x;
			item2.y += num2;
			verts.Add(item2);
			uvs.Add(m_Uvs[i]);
			Color32 item3 = m_Cols[i];
			item3.a = (byte)((float)(int)item3.a * mPanel.alpha);
			cols.Add(item3);
		}
	}

	protected void OnDestroy()
	{
		material = null;
	}

	public static string EscapeFontTag(string text)
	{
		string text2 = string.Empty;
		char c = '\0';
		char[] array = text.ToCharArray();
		for (int i = 0; i < text.Length; i++)
		{
			if (c != '\a')
			{
				if (array[i] == '[')
				{
					text2 += "\a";
				}
				else if (array[i] == ']')
				{
					text2 += "\a";
				}
				else if (array[i] == '<')
				{
					text2 += "\a";
				}
				else if (array[i] == '>')
				{
					text2 += "\a";
				}
			}
			c = array[i];
			text2 += c;
		}
		return text2;
	}

	public static string UnEscapeFontTag(string text)
	{
		return text.Replace("\a", string.Empty);
	}
}
