using System;
using UnityEngine;

[Serializable]
public class ResultShortcut
{
	[Serializable]
	public enum IntoScene
	{
		Normal,
		Limited,
		Grow,
		Raid,
		Challenge,
		Colosseum,
		Max
	}

	private static UserMiscInfo.ResultShortcutFlagData userOption => UserData.Current.userMiscInfo.resultShortcutData;

	public static bool ValidArea(EnumAreaTypes area)
	{
		return area switch
		{
			EnumAreaTypes.Town => false, 
			EnumAreaTypes.Myhome => false, 
			_ => true, 
		};
	}

	public static MAreas GetArea(EnumAreaTypes area)
	{
		QuestManager instance = QuestManager.Instance;
		object result;
		if (instance != null)
		{
			instance.areas = instance.SetupAreaIcon(null);
			result = QuestManager.getArea(area);
		}
		else
		{
			result = null;
		}
		return (MAreas)result;
	}

	public static ResultShortcutWindow Initialize(IntoScene scene, bool valid)
	{
		if (IsEnabled(scene))
		{
			UIMain uIMain = (UIMain)UnityEngine.Object.FindObjectOfType(typeof(UIMain));
			if (!(uIMain == null))
			{
				ResultShortcutWindow[] componentsInChildren = uIMain.gameObject.GetComponentsInChildren<ResultShortcutWindow>(includeInactive: true);
				if (componentsInChildren != null && 0 < componentsInChildren.Length)
				{
					if (1 < componentsInChildren.Length)
					{
					}
					ResultShortcutWindow resultShortcutWindow = componentsInChildren[0];
					resultShortcutWindow.Init(scene, valid);
				}
			}
		}
		return null;
	}

	public static bool IsEnabled(IntoScene scene)
	{
		return scene != IntoScene.Max && !QuestSession.IsLoaded && (GameParameter.alwaysOpenResultShortcut || userOption.IsEnabled(scene.ToString()));
	}

	public static bool HasEnabled()
	{
		int result;
		if (GameParameter.alwaysOpenResultShortcut)
		{
			result = 1;
		}
		else
		{
			int num = 0;
			int num2 = 6;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < num2)
				{
					int scene = num;
					num++;
					if (IsEnabled((IntoScene)scene))
					{
						result = 1;
						break;
					}
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	public static void SetEnable(IntoScene scene, bool enable)
	{
		if (scene != IntoScene.Max)
		{
			if (enable)
			{
				userOption.Enable(scene.ToString());
			}
			else
			{
				userOption.Disable(scene.ToString());
			}
		}
	}

	public static void SetAllEnabled(bool enable)
	{
		int num = 0;
		int num2 = 6;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int scene = num;
			num++;
			SetEnable((IntoScene)scene, enable);
		}
	}

	public static void Activate(bool activate)
	{
		if (activate)
		{
			BattleHUDShortcut.Show();
		}
		else
		{
			BattleHUDShortcut.Hide();
		}
	}

	public static void Retry(EnumAreaTypes area)
	{
		QuestManager instance = QuestManager.Instance;
		if (instance != null)
		{
			MAreas area2 = GetArea(area);
			if (area2 == null)
			{
				End();
			}
			else if (!instance.SetAndJumpArea(area2))
			{
			}
		}
	}

	public static void End()
	{
		SceneChanger.ChangeTo(SceneID.Town);
	}
}
